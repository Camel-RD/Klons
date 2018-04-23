using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using KlonsP.DataSets;
using KlonsP.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Components;
using KlonsLIB.Misc;
using KlonsLIB.MySourceGrid.GridRows;
using KlonsLIB.Data;
using Microsoft.Reporting.WinForms;

namespace KlonsP.Forms
{
    public partial class Form_Items : MyFormBaseP
    {
        public Form_Items()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            try
            {
                MakeGrid();
            }
            catch (Exception ex)
            {
                Form_Error.ShowException(ex);
            }
            bsRows.CurrentChanged += bsRows_CurrentChanged;

            ShowDataPanel(MyData.Params.ShowItemDataPanel);
            ShowFilterPanel(MyData.Params.ShowItemsFilterPanel);

            InsertInToolStrip(bnNav, tbDate, -1);

            dgvFilter.AutoGenerateColumns = false;
            dgcFilterSate.DataSource = SomeDataDefs.FilterList;
            dgcFilterSate.ValueMember = "Key";
            dgcFilterSate.DisplayMember = "Val";

        }

        public DateTime CurrentDate { get; private set; } = DateTime.MinValue;

        private void Form_Items_Load(object sender, EventArgs e)
        {
            MyData.DataSetKlons.ITEMS_EVENTS.ColumnChanged += ITEMS_EVENTS_ColumnChanged;

            mySplitContainer1.Panel1.Select();
            dgvItems.Select();

            IsLoading = false;
            SetDate(MyData.Params.ActiveDate);
            CheckSave();
        }

        private void Form_Items_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlons.ITEMS_EVENTS.ColumnChanged -= ITEMS_EVENTS_ColumnChanged;
            bsRows.CurrentChanged -= bsRows_CurrentChanged;
        }

        private void MakeGrid()
        {
            sgrEvents.MakeGrid();
            sgrEvents.LinkGrid();
        }

        public override void SaveParams()
        {
            MyData.Params.ActiveDate = CurrentDate;
        }

        public void DeleteCurrent()
        {
            bnNav.DeleteCurrent();
            if (bnNav.BindingSource == bsRows)
            {
                RecalcCurrent();
            }
            else if (bnNav.BindingSource == bsItems)
            {

            }
            SaveData();
        }


        private int Ignore_ITEMS_EVENTS_ColumnChanged = 0;

        private void ITEMS_EVENTS_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (Ignore_ITEMS_EVENTS_ColumnChanged > 0) return;
            Ignore_ITEMS_EVENTS_ColumnChanged ++;
            ITEMS_EVENTS_ColumnChangedA(sender, e);
            Ignore_ITEMS_EVENTS_ColumnChanged --;
        }

        private void ITEMS_EVENTS_ColumnChangedA(object sender, DataColumnChangeEventArgs e)
        {
            var table_itemsevents = MyData.DataSetKlons.ITEMS_EVENTS;
            var dr = e.Row as KlonsPDataSet.ITEMS_EVENTSRow;

            //var dr_prev = GetPrevRow(dr);
            //if (dr_prev != null) CheckChangedColumns(dr, dr_prev);

            if (dr.RowState == DataRowState.Detached)
            {
                return;
            }

            if (e.Column == table_itemsevents.VALUE_CColumn)
            {
                dr.TAX_VAL_C = dr.VALUE_C;
            }

            if (e.Column == table_itemsevents.DTColumn ||
                e.Column == table_itemsevents.EVENTColumn ||
                e.Column == table_itemsevents.CATDColumn ||
                e.Column == table_itemsevents.MT_TOTALColumn ||
                e.Column == table_itemsevents.VALUE_0Column ||
                e.Column == table_itemsevents.VALUE_CColumn ||
                e.Column == table_itemsevents.DEPREC_0Column ||
                e.Column == table_itemsevents.DEPREC_CColumn ||
                e.Column == table_itemsevents.SELL_VALUEColumn ||
                e.Column == table_itemsevents.TAX_VALColumn ||
                e.Column == table_itemsevents.TAX_VAL_LEFTColumn)
            {
                RecalcCurrent();
                dgvEvents.RefreshCurrent();
            }

        }

        public int FindItem(int id)
        {
            for (int i = 0; i < bsItems.Count; i++)
            {
                var dr = bsItems.CurrentDataRow as KlonsPDataSet.ITEMSRow;
                if (dr.RowState == DataRowState.Detached) continue;
                if (dr.ID == id) return i;
            }
            return -1;
        }

        public void SelectItem(int id)
        {
            int pos = FindItem(id);
            if (pos == -1) return;
            bsItems.Position = pos;
        }


        private KlonsPDataSet.ITEMS_EVENTSRow GetPrevRow(KlonsPDataSet.ITEMS_EVENTSRow dr)
        {
            var drs = bsRows.Cast<DataRowView>()
                .Select(d => d.Row as KlonsPDataSet.ITEMS_EVENTSRow)
                .OrderBy(d => d.DT)
                .ThenBy(d => d.EVENTSRow.SNR)
                .ToArray();
            int k = drs.IndexOf(dr);
            if (k < 1) return null;
            return drs[k - 1];
        }

        private KlonsPDataSet.ITEMS_EVENTSRow GetLastRow(KlonsPDataSet.ITEMS_EVENTSRow dr_excl)
        {
            return bsRows.Cast<DataRowView>()
                .Select(d => d.Row as KlonsPDataSet.ITEMS_EVENTSRow)
                .Where(d => d.RowState != DataRowState.Detached && d != dr_excl)
                .OrderBy(d => d.DT)
                .ThenBy(d => d.EVENTSRow.SNR)
                .LastOrDefault();
        }

        private void CheckChangedColumns(KlonsPDataSet.ITEMS_EVENTSRow dr_cur, KlonsPDataSet.ITEMS_EVENTSRow dr_prev)
        {
            EChColInd ch = EChColInd.none;
            if(dr_prev == null)
            {
                if (dr_cur.VALUE_0 != 0.0M) ch |= EChColInd.value0;
                if (dr_cur.DEPREC_0 != 0.0M) ch |= EChColInd.deprec0;
                if (dr_cur.VALUE_C != 0.0M) ch |= EChColInd.valuec;
                if (dr_cur.DEPREC_C != 0.0M) ch |= EChColInd.deprecc;
                if (dr_cur.TAX_VAL != 0.0M) ch |= EChColInd.taxvalue;
                if (dr_cur.TAX_VAL_C != 0.0M) ch |= EChColInd.taxvaluec;
                dr_cur.XChColSet = ch;
                return;
            }
            if (dr_cur.CAT1 != dr_prev.CAT1) ch |= EChColInd.cat1;
            if (dr_cur.CATD != dr_prev.CATD) ch |= EChColInd.catd;
            if (dr_cur.CATT != dr_prev.CATT) ch |= EChColInd.catt;
            if (dr_cur.PLACE != dr_prev.PLACE) ch |= EChColInd.place;
            if (dr_cur.DEPARTMENT != dr_prev.DEPARTMENT) ch |= EChColInd.department;
            if (dr_cur.VALUE_C != 0.0M) ch |= EChColInd.valuec;
            if (dr_cur.DEPREC_C != 0.0M) ch |= EChColInd.deprecc;
            if (dr_cur.SELL_VALUE != dr_prev.SELL_VALUE) ch |= EChColInd.sellvalue;
            if (dr_cur.MT_TOTAL != dr_prev.MT_TOTAL) ch |= EChColInd.mttotal;
            if (dr_cur.TAX_VAL != dr_prev.MT_TOTAL) ch |= EChColInd.taxvalue;
            if (dr_cur.TAX_VAL_C != 0.0M) ch |= EChColInd.taxvaluec;
            dr_cur.XChColSet = ch;
        }


        private void dgvItems_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvEvents_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void bnNav_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvItems_Enter(object sender, EventArgs e)
        {
            bnNav.BindingSource = bsItems;
            bnNav.DataGrid = dgvItems;
            tslActiveTable.Text = "Pamatlīdzekļi:";
        }

        private void dgvEvents_Enter(object sender, EventArgs e)
        {
            bnNav.BindingSource = bsRows;
            bnNav.DataGrid = dgvEvents;
            tslActiveTable.Text = "Notikumi:";
        }

        private void dgvItems_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvItems.CurrentCell == null) return;
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvItems.EndEdit()) return;
                dgvItems.MoveToNewRow();
                e.Handled = true;
                return;
            }
        }

        private void dgvEvents_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvEvents.CurrentCell == null) return;
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvEvents.EndEdit()) return;
                dgvEvents.MoveToNewRow();
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.F5)
            {
                if(SetEventsCellFromDialog())
                    e.Handled = true;
                return;
            }

        }

        private void dgvEvents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SetEventsCellFromDialog();
        }

        private bool SetEventsCellFromDialog()
        {
            if (bsEvents.Count == 0 || bsEvents.Current == null) return false;
            if (dgvEvents.CurrentRow == null || dgvEvents.CurrentRow.IsNewRow ||
                dgvEvents.CurrentCell == null) return false;
            int colnr = dgvEvents.CurrentCell.ColumnIndex;

            //var dr = (dgvEvents.CurrentRow.DataBoundItem as DataRowView).Row as KlonsPDataSet.ITEMS_EVENTSRow;
            int id = int.MinValue;

            if (colnr == dgcEventsCat1.Index)
            {
                if (!GetCat1FromDialog(out id)) return false;
            }
            else if (colnr == dgcEventsCatD.Index)
            {
                if (!GetCatDFromDialog(out id)) return false;
            }
            else if (colnr == dgcEventsCatT.Index)
            {
                if (!GetCatTFromDialog(out id)) return false;
            }
            else if (colnr == dgcEventsDepartment.Index)
            {
                if (!GetDepFromDialog(out id)) return false;
            }
            else if (colnr == dgcEventsPlace.Index)
            {
                if (!GetPlaceFromDialog(out id)) return false;
            }

            if (id == int.MinValue) return false;

            try
            {
                dgvEvents.BeginEdit(false);
                var c = dgvEvents.EditingControl as MyDgvMcComboBox;
                c.SelectedValue = id;
                dgvEvents.EndEdit();
            }
            catch (Exception) { }

            return true;
        }

        private void dgvFilter_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SetFilterCellFromDialog();
        }

        private bool SetFilterCellFromDialog()
        {
            if (bsFilter.Count == 0 || bsFilter.Current == null) return false;
            if (dgvFilter.CurrentRow == null || dgvFilter.CurrentRow.IsNewRow ||
                dgvFilter.CurrentCell == null) return false;
            int colnr = dgvFilter.CurrentCell.ColumnIndex;

            //var dr = (dgvEvents.CurrentRow.DataBoundItem as DataRowView).Row as KlonsPDataSet.ITEMS_EVENTSRow;
            int id = int.MinValue;

            if (colnr == dgcFilterCat1.Index)
            {
                if (!GetCat1FromDialog(out id)) return false;
            }
            else if (colnr == dgcFilterCatD.Index)
            {
                if (!GetCatDFromDialog(out id)) return false;
            }
            else if (colnr == dgcFilterCatT.Index)
            {
                if (!GetCatTFromDialog(out id)) return false;
            }
            else if (colnr == dgcFilterDepartment.Index)
            {
                if (!GetDepFromDialog(out id)) return false;
            }
            else if (colnr == dgcFilterPlace.Index)
            {
                if (!GetPlaceFromDialog(out id)) return false;
            }

            if (id == int.MinValue) return false;

            try
            {
                dgvFilter.BeginEdit(false);
                var c = dgvFilter.EditingControl as MyDgvMcComboBox;
                c.SelectedValue = id;
                dgvFilter.EndEdit();
            }
            catch (Exception) { }

            return true;
        }


        public bool GetCat1FromDialog(out int id)
        {
            id = int.MinValue;
            var fm = new Form_Cat1();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return false;
            id = fm.SelectedValueInt;
            return true;
        }

        public bool GetCatDFromDialog(out int id)
        {
            id = int.MinValue;
            var fm = new Form_CatD();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return false;
            id = fm.SelectedValueInt;
            return true;
        }

        public bool GetCatTFromDialog(out int id)
        {
            id = int.MinValue;
            var fm = new Form_CatT();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return false;
            id = fm.SelectedValueInt;
            return true;
        }

        public bool GetDepFromDialog(out int id)
        {
            id = int.MinValue;
            var fm = new Form_Departments();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return false;
            id = fm.SelectedValueInt;
            return true;
        }

        public bool GetPlaceFromDialog(out int id)
        {
            id = int.MinValue;
            var fm = new Form_Places();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return false;
            id = fm.SelectedValueInt;
            return true;
        }

        private void dgvItems_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if(e.ColumnIndex == dgcItemsDate1.Index || e.ColumnIndex == dgcItemsDate2.Index)
            {
                Utils.DGVParseDateCell(e);
            }
        }

        private void dgvEvents_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcEventsDT.Index || e.ColumnIndex == dgcEventsDtReg.Index)
            {
                Utils.DGVParseDateCell(e);
            }
        }

        private void CheckEnableEvents()
        {
            dgvEvents.Enabled = dgvItems.RowCount > 0 && dgvItems.CurrentRow != null &&
                !dgvItems.CurrentRow.IsNewRow;

            CheckEnableSGR();
        }

        private void CheckEnableSGR()
        {
            sgrEvents.Enabled = dgvEvents.Enabled && bsRows.Count > 0 &&
                dgvEvents.CurrentRow != null && !dgvEvents.CurrentRow.IsNewRow;
        }

        private void dgvItems_CurrentCellChanged(object sender, EventArgs e)
        {
            CheckEnableEvents();
        }

        private void dgvEvents_CurrentCellChanged(object sender, EventArgs e)
        {
            CheckEnableSGR();
        }

        public override bool SaveData()
        {
            if (!dgvItems.EndEditX()) return false;
            if (!dgvEvents.EndEditX()) return false;

            if (!this.Validate()) return false;
            try
            {
                DataTasks.SetNewIDs(myAdapterManager1);
                myAdapterManager1.UpdateAll();
                CheckSave();
            }
            catch (Exception e)
            {
                CheckSave();
                SetSaveButton(HasChanges());
                Form_Error.ShowException(e, "Neizdevās saglabāt izmaiņas.");
                return false;
            }
            return true;
        }

        private void SetSaveButton(bool red)
        {
            bnNav.SetSaveButtonRed(red);
        }

        private bool HasChanges()
        {
            return myAdapterManager1.HasChanges();
        }

        private void CheckSave()
        {
            SetSaveButton(HasChanges());
        }

        private void bnNav_SaveClicked(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvItems_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void bsItems_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void bsRows_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (e.ListChangedType == ListChangedType.Reset) return;
            CheckSave();
        }

        private void SetItemEventRowFrom(KlonsPDataSet.ITEMS_EVENTSRow dr, KlonsPDataSet.ITEMS_EVENTSRow dr_from)
        {
            dr.BeginEdit();

            dr.CAT1 = dr_from.CAT1;
            dr.CATD = dr_from.CATD;
            dr.CATT = dr_from.CATT;
            dr.PLACE = dr_from.PLACE;
            dr.DEPARTMENT = dr_from.DEPARTMENT;

            dr.VALUE_0 = dr_from.VALUE_0;
            dr.DEPREC_0 = dr_from.DEPREC_0;
            dr.SELL_VALUE = dr_from.SELL_VALUE;
            dr.RATE_D = dr_from.RATE_D;
            dr.RATE_D_MT = dr_from.RATE_D_MT;

            dr.MT_TOTAL = dr_from.MT_TOTAL;

            dr.TAX_VAL = dr_from.TAX_VAL;
            dr.TAX_VAL = dr_from.TAX_VAL;
            dr.TAX_RATE = dr_from.TAX_RATE;
            dr.TAX_EACH = dr_from.TAX_EACH;

            dr.EndEdit();
        }

        private void SetItemEventRowFrom(DataGridViewRow dr, KlonsPDataSet.ITEMS_EVENTSRow dr_from)
        {
            dr.Cells[dgcEventsCat1.Index].Value = dr_from.CAT1;
            dr.Cells[dgcEventsCatD.Index].Value = dr_from.CATD;
            dr.Cells[dgcEventsCatT.Index].Value = dr_from.CATT;
            dr.Cells[dgcEventsPlace.Index].Value = dr_from.PLACE;
            dr.Cells[dgcEventsDepartment.Index].Value = dr_from.DEPARTMENT;

            dr.Cells[dgcEventsValue0.Index].Value = dr_from.VALUE_0 + dr_from.VALUE_C;
            dr.Cells[dgcEventsDeprec0.Index].Value = dr_from.DEPREC_0 + dr_from.DEPREC_C;
            dr.Cells[dgcEventsSellValue.Index].Value = dr_from.SELL_VALUE;
            dr.Cells[dgcEventsRateD.Index].Value = dr_from.RATE_D;
            dr.Cells[dgcEventsRateDMt.Index].Value = dr_from.RATE_D_MT;

            dr.Cells[dgcEventsMtTotal.Index].Value = dr_from.MT_TOTAL;

            dr.Cells[dgcEventsTaxVal.Index].Value = dr_from.TAX_VAL + dr_from.TAX_VAL_C;
            dr.Cells[dgcEventsTaxRate.Index].Value = dr_from.TAX_RATE;
            dr.Cells[dgcEventsTaxEach.Index].Value = dr_from.TAX_EACH;
        }

        private void dgvEvents_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[dgcEventsDT.Index].Value = DateTime.Today;
            e.Row.Cells[dgcEventsDtReg.Index].Value = DateTime.Today;
            e.Row.Cells[dgcEventsZDT.Index].Value = DateTime.Now;
            e.Row.Cells[dgcEventsZU.Index].Value = MyData.CurrentUserName;
            if (bsRows.Count == 0) return;
            KlonsPDataSet.ITEMS_EVENTSRow dr = null;
            try { dr = (e.Row.DataBoundItem as DataRowView)?.Row as KlonsPDataSet.ITEMS_EVENTSRow; }
            catch (Exception) { }
            var dr_last = GetLastRow(dr);
            if (dr_last == null || dr_last.RowState == DataRowState.Detached) return;
            e.Row.Cells[dgcEventsSNR.Index].Value = dr_last.SNR + 1;
            SetItemEventRowFrom(e.Row, dr_last);
        }

        public void RecalcCurrent(KlonsPDataSet.ITEMS_EVENTSRow drtoinit = null)
        {
            if (bsItems.Count == 0 || bsItems.Current == null) return;
            if (dgvItems.CurrentRow == null || dgvItems.CurrentRow.IsNewRow) return;
            var dr = bsItems.CurrentDataRow as KlonsPDataSet.ITEMSRow;
            var rt = RecalcItem(dr, drtoinit);
            if(rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }
        }

        public void RecalcAll()
        {
            if (bsItems.Count == 0) return;
            var table_items = MyData.DataSetKlons.ITEMS;
            var drs_items = table_items.WhereNotDeleted();
            int k = 0;
            foreach (var dr in drs_items)
            {
                var rt = RecalcItem(dr);
                if (rt != "OK") k++;
            }
            if (k > 0)
            {
                MyMainForm.ShowWarning(
                    "Pārrēķinot datus, tika konstatētas kļūdas.\n" +
                    "Pamatlīdzekļu skaits ar kļūdainiem datiem: " + k);
            }
        }

        public string RecalcItem(KlonsPDataSet.ITEMSRow dritem, KlonsPDataSet.ITEMS_EVENTSRow drtoinit = null)
        {
            var it = new ItemInfo();
            it.SetFromRow(dritem);
            it.SetEventToInit(drtoinit);

            Ignore_ITEMS_EVENTS_ColumnChanged++;

            var rt = it.UpdateItemToDate(CurrentDate);
            if (rt != "OK")
            {
                Ignore_ITEMS_EVENTS_ColumnChanged--;
                return rt;
            }

            Ignore_ITEMS_EVENTS_ColumnChanged--;
            return "OK";
        }

        public void AddItem()
        {
            var fm = new Form_Items_New();
            if(fm.ShowDialog() != DialogResult.OK) return;
            var table_items = MyData.DataSetKlons.ITEMS;
            var table_events = MyData.DataSetKlons.ITEMS_EVENTS;
            var dr_new_item = table_items.NewITEMSRow();

            Ignore_ITEMS_EVENTS_ColumnChanged++;

            dr_new_item.REG_NR = fm.itemsEventsData1.fITEM_REG_NR;
            dr_new_item.NAME = fm.itemsEventsData1.fITEM_NAME;
            table_items.AddITEMSRow(dr_new_item);
            if (fm.AddEvent)
            {
                var dr_new_event = table_events.NewITEMS_EVENTSRow();

                dr_new_event.IDIT = dr_new_item.ID;
                dr_new_event.ITEMSRow = dr_new_item;
                dr_new_event.XEvent = EEvent.iegeks;
                dr_new_event.DT = fm.itemsEventsData1.fDT;
                dr_new_event.DTREG = fm.itemsEventsData1.fDT;
                dr_new_event.DOCNR = fm.itemsEventsData1.fDOCNR;
                dr_new_event.VALUE_C = fm.itemsEventsData1.fVALUE_0;
                dr_new_event.TAX_VAL_C = fm.itemsEventsData1.fVALUE_0;
                dr_new_event.CAT1 = fm.itemsEventsData1.fCAT1;
                dr_new_event.CATD = fm.itemsEventsData1.fCATD;
                dr_new_event.CATT = fm.itemsEventsData1.fCATT;
                dr_new_event.DEPARTMENT = fm.itemsEventsData1.fDEPARTMENT;
                dr_new_event.PLACE = fm.itemsEventsData1.fPLACE;

                table_events.AddITEMS_EVENTSRow(dr_new_event);
            }
            Ignore_ITEMS_EVENTS_ColumnChanged--;
            RecalcItem(dr_new_item);
            SaveData();
            SelectItem(dr_new_item.ID);
        }

        public void AddEvent()
        {
            if (bsItems.Current == null) return;
            var fm = new Form_Items_NewEvent();
            var rt = fm.ShowDialog();
            if (rt != DialogResult.OK) return;
            var dr_item = bsItems.CurrentDataRow as KlonsPDataSet.ITEMSRow;
            var dt = fm.Date;
            int evid = fm.EventId;
            var table = MyData.DataSetKlons.ITEMS_EVENTS;
            var dr_new = table.NewITEMS_EVENTSRow();
            Ignore_ITEMS_EVENTS_ColumnChanged++;
            dr_new.IDIT = dr_item.ID;
            dr_new.DT = dt;
            dr_new.DTREG = dt;
            dr_new.EVENT = evid;
            dr_new.DESCR = dr_new.XEvent.ToMyStringFull();
            table.AddITEMS_EVENTSRow(dr_new);
            Ignore_ITEMS_EVENTS_ColumnChanged--;
            RecalcCurrent(dr_new);
        }

        public void ReplacePart()
        {
            if (bsItems.Current == null) return;
            var dr_item = bsItems.CurrentDataRow as KlonsPDataSet.ITEMSRow;
            var fm = new Form_ReplacePart();
            fm.InitData(dr_item.ID);
            var rt = fm.ShowDialog(MyMainForm);
            if (rt != DialogResult.OK) return;

            var dt = fm.replacePartData1.fDATE.Value;
            var table = MyData.DataSetKlons.ITEMS_EVENTS;

            Ignore_ITEMS_EVENTS_ColumnChanged++;

            var dr_new = table.NewITEMS_EVENTSRow();
            dr_new.IDIT = dr_item.ID;
            dr_new.DT = dt;
            dr_new.DTREG = dt;
            dr_new.XEvent = EEvent.kapit;
            dr_new.DESCR = fm.replacePartData1.fDescr;
            dr_new.DOCNR = fm.replacePartData1.fDoc;
            dr_new.VALUE_C = fm.replacePartData1.fValueC;
            dr_new.DEPREC_C = fm.replacePartData1.fDeprecC;
            dr_new.TAX_VAL_C = fm.replacePartData1.fTaxValueC;
            table.AddITEMS_EVENTSRow(dr_new);
            RecalcCurrent(dr_new);

            Ignore_ITEMS_EVENTS_ColumnChanged--;
        }


        private EChColInd GetEventColInd(int ind)
        {
            if (ind == dgcEventsCat1.Index) return EChColInd.cat1;
            if (ind == dgcEventsCatD.Index) return EChColInd.catd;
            if (ind == dgcEventsCatT.Index) return EChColInd.catt;
            if (ind == dgcEventsPlace.Index) return EChColInd.place;
            if (ind == dgcEventsDepartment.Index) return EChColInd.department;
            if (ind == dgcEventsValue0.Index) return EChColInd.value0;
            if (ind == dgcEventsDeprec0.Index) return EChColInd.deprec0;
            if (ind == dgcEventsValueC.Index) return EChColInd.valuec;
            if (ind == dgcEventsDeprecC.Index) return EChColInd.deprecc;
            if (ind == dgcEventsSellValue.Index) return EChColInd.sellvalue;
            if (ind == dgcEventsTaxVal.Index) return EChColInd.taxvalue;
            if (ind == dgcEventsTaxValLeft.Index) return EChColInd.taxvalueleft;
            if (ind == dgcEventsTaxValC.Index) return EChColInd.taxvaluec;
            if (ind == dgcEventsMtTotal.Index) return EChColInd.mttotal;
            if (ind == dgcEventsMtUsed.Index) return EChColInd.mtused;
            return EChColInd.none;
        }

        private EChColInd GetEventColInd(MyGridRowBase row)
        {
            if (row == grCat1) return EChColInd.cat1;
            if (row == grCatD) return EChColInd.catd;
            if (row == grCatT) return EChColInd.catt;
            if (row == grPlace) return EChColInd.place;
            if (row == grDepartment) return EChColInd.department;
            if (row == grValue0) return EChColInd.value0;
            if (row == grDeprec0) return EChColInd.deprec0;
            if (row == grValueC) return EChColInd.valuec;
            if (row == grDeprecC) return EChColInd.deprecc;
            if (row == grSellValue) return EChColInd.sellvalue;
            if (row == grTaxVal) return EChColInd.taxvalue;
            if (row == grTaxValLeft) return EChColInd.taxvalueleft;
            if (row == grTaxValC) return EChColInd.taxvaluec;
            if (row == grMtTotal) return EChColInd.mttotal;
            if (row == grMtUsed) return EChColInd.mtused;
            return EChColInd.none;
        }

        private void dgvEvents_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var dr = dgvEvents.GetDataRow(e.RowIndex) as KlonsPDataSet.ITEMS_EVENTSRow;
            if (dr == null) return;
            var col_ind = GetEventColInd(e.ColumnIndex);
            if (col_ind == EChColInd.none) return;
            var cols_editable = SomeDataDefs.GetEditableFields(dr.XEvent);
            if (!cols_editable.HasFlag(col_ind))
            {
                e.Cancel = true;
                return;
            }
        }

        private void sgrEvents_EditStarting(object sender, CancelEventArgs e)
        {
            if(bsItems.Current == null || bsRows.Current == null)
            {
                e.Cancel = true;
                return;
            }
            var dr = bsRows.CurrentDataRow as KlonsPDataSet.ITEMS_EVENTSRow;
            if (dr == null) return;
            var col_ind = GetEventColInd(sender as MyGridRowBase);
            if (col_ind == EChColInd.none) return;
            var cols_editable = SomeDataDefs.GetEditableFields(dr.XEvent);
            if (!cols_editable.HasFlag(col_ind))
            {
                e.Cancel = true;
                return;
            }

        }

        private void MarkEventRowCell(int rownr, int colnr, bool red)
        {
            var cell = dgvEvents[colnr, rownr];
            var column = dgvEvents.Columns[colnr];
            var cell_style = column.DefaultCellStyle;
            if (red)
            {
                cell_style = new DataGridViewCellStyle(cell_style);
                cell_style.ForeColor = MyMainForm.myStyleDefs.MarkedCellFore;
                cell_style.BackColor = MyMainForm.myStyleDefs.MarkedCellBack;
            }
            cell.Style = cell_style;
        }

        private void dgvEvents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.ColumnIndex == dgcEventsRateD.Index || e.ColumnIndex == dgcEventsTaxRate.Index)
            {
                float f = (float)e.Value;
                e.Value = (f * 100.0f).ToString();
                e.FormattingApplied = true;
            }
            if(Utils.IN(e.ColumnIndex, 
                dgcEventsCat1.Index, 
                dgcEventsCatD.Index,
                dgcEventsCatT.Index,
                dgcEventsPlace.Index,
                dgcEventsDepartment.Index,
                dgcEventsValueC.Index,
                dgcEventsDeprecC.Index,
                dgcEventsSellValue.Index,
                dgcEventsMtTotal.Index,
                dgcEventsTaxValC.Index
               ))
            {
                var dr = dgvEvents.GetDataRow(e.RowIndex) as KlonsPDataSet.ITEMS_EVENTSRow;
                if (dr == null) return;
                var propname = dgvEvents.Columns[e.ColumnIndex].DataPropertyName;
                var val_cur = dr[propname];

                if (Utils.IN(e.ColumnIndex,
                    dgcEventsValueC.Index,
                    dgcEventsDeprecC.Index,
                    dgcEventsTaxValC.Index
                   ))
                {
                    MarkEventRowCell(e.RowIndex, e.ColumnIndex, (decimal)val_cur != 0.0M);
                    return;
                }

                var dr_prev = GetPrevRow(dr);
                if (dr_prev == null)
                {
                    MarkEventRowCell(e.RowIndex, e.ColumnIndex, false);
                }
                else
                {
                    var val_prev = dr_prev[propname];
                    MarkEventRowCell(e.RowIndex, e.ColumnIndex, !object.Equals(val_prev, val_cur));
                }
            }
        }

        private MyGridRowPropEditorBase[] checkRedRows = null;
        private MyGridRowPropEditorBase[] checkRedRows2 = null;

        private void SetCheckRedRows()
        {
            checkRedRows = new MyGridRowPropEditorBase[] {grCat1, grCatD, grCatT, grPlace, grDepartment
                , grValueC ,grDeprecC, grSellValue, grTaxValC, grMtTotal};
            checkRedRows2 = new MyGridRowPropEditorBase[] {grValueC ,grDeprecC, grTaxValC};
        }

        public void CheckEventRedRows()
        {
            if (checkRedRows == null) SetCheckRedRows();
            var dr = bsRows.CurrentDataRow as KlonsPDataSet.ITEMS_EVENTSRow;
            if (dr == null) return;
            if (bsRows.Position == 0)
            {
                sgrEvents.ClearRed();
            }
            else
            {
                var dr_prev = (bsRows[bsRows.Position - 1] as DataRowView)?.Row as KlonsPDataSet.ITEMS_EVENTSRow;
                if (dr_prev == null) return;
                sgrEvents.CheckRedRows(new[] { dr_prev }, new[] { dr }, new[] { bsRows }
                    ,d =>
                    {
                        if (!checkRedRows.Contains(d)) return false;
                        if (checkRedRows2.Contains(d))
                            return (decimal)d.Value != 0.0M;
                        return d.IsRed(new[] { dr_prev }, new[] { dr }, new[] { bsRows });
                    });
            }
        }

        public void CheckEventRedRows(KlonsLIB.MySourceGrid.GridRows.MyGridRowPropEditorBase row)
        {
            if (row == null || !row.CheckRed) return;
            var dr = bsRows.CurrentDataRow as KlonsPDataSet.ITEMS_EVENTSRow;
            if (dr == null) return;
            if (bsRows.Position == bsRows.Count - 1) return;
            var dr_prev = (bsRows[bsRows.Position + 1] as DataRowView)?.Row as KlonsPDataSet.ITEMS_EVENTSRow;
            if (dr_prev == null) return;
            row.CheckRedRow(new[] { dr_prev }, new[] { dr }, new[] { bsRows });
        }

        public void ShowDataPanel(bool b)
        {
            sgrEvents.Visible = b;
            MyData.Params.ShowItemDataPanel = b;
            rādītPaslēptDatuPaneliToolStripMenuItem.Checked = b;
        }

        public void ShowFilterPanel(bool b)
        {
            pnFilter.Visible = b;
            MyData.Params.ShowItemsFilterPanel = b;
            rādītPaslēptFiltraPaneliToolStripMenuItem.Checked = b;
        }

        private void bsItems_CurrentChanged(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckChildGrid();
        }

        private void bsRows_CurrentChanged(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckEventRedRows();
        }

        private void sgrEvents_EditEnded(object sender, EventArgs e)
        {
            var row = sender as KlonsLIB.MySourceGrid.GridRows.MyGridRowPropEditorBase;
            CheckEventRedRows(row);
        }

        private bool detail_update_enabled = true;
        public void CheckChildGrid(bool setnull = false)
        {
            DataRowView dv = bsItems.Current as DataRowView;
            if (dv == null
                || setnull
                || dv.Row.RowState == DataRowState.Deleted
                )
            {
                //bsRows.DataSource = null;
                bsRows.DataSource = new DataView(MyData.DataSetKlons.ITEMS_EVENTS, null, null, DataViewRowState.None);
                dgvEvents.Enabled = false;
            }
            else
            {
                if (!detail_update_enabled) return;

                DataView dv1 = dv.CreateChildView(dv.Row.Table.ChildRelations[0]);
                dgvEvents.Enabled = true;
                bsRows.DataSource = dv1;
            }
        }

        public void EnableDetailUpdate(bool b)
        {
            detail_update_enabled = b;
            CheckChildGrid(!b);
        }

        public void SetDate(DateTime dt)
        {
            if (!SaveData()) return;
            if (bsItems.Count == 0) return;
            CurrentDate = dt;
            filterData1.fDATE1 = dt;
            var dts = Utils.DateToString(dt);
            if (tbDate.Text != dts) tbDate.Text = dts;
            RecalcAll();
            CheckChildGrid();
        }

        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgcItemsState.Index)
            {
                if (e.Value == null || e.Value == DBNull.Value) return;
                int ist = (int)e.Value;
                EState est = (EState)ist;
                e.Value = est.ToMyString();
                e.FormattingApplied = true;
            }
        }

        private void myDataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if(e.ColumnIndex == dgcFilterDate.Index)
            {
                Utils.DGVParseDateCell(e);
            }
        }

        public void DoFilter()
        {
            if (!filterData1.fDATE1.HasValue) return;
            if (CurrentDate != filterData1.fDATE1.Value)
                SetDate(filterData1.fDATE1.Value);

            string fs = "";
            if (filterData1.fSTATE != null)
            {
                var fs1 = "";
                if (filterData1.fSTATE.Value == 1)
                    fs1 = "TSTATE IN (0, 2)";
                else
                    fs1 = "TSTATE = 4";
                fs = fs == "" ? fs1 : fs + " AND (" + fs1 + ")";
            }
            if (filterData1.fCAT1 != null)
            {
                string fs1 = "";
                var drf = MyData.DataSetKlons.CAT1.FindByID(filterData1.fCAT1.Value);
                if (drf.GROUP == 0)
                {
                    fs1 = "TCAT1=" + filterData1.fCAT1.Value;
                }
                else
                {
                    fs1 = $"Parent(FK_ITEMS_TCAT1).CODE LIKE '{drf.CODE}*'";
                }
                fs = fs == "" ? fs1 : fs + " AND (" + fs1 + ")";
            }
            if (filterData1.fCATD != null)
            {
                var fs1 = "TCATD=" + filterData1.fCATD.Value;
                fs = fs == "" ? fs1 : fs + " AND (" + fs1 + ")";
            }
            if (filterData1.fCATT != null)
            {
                var fs1 = "TCATT=" + filterData1.fCATT.Value;
                fs = fs == "" ? fs1 : fs + " AND (" + fs1 + ")";
            }
            if (filterData1.fDEPARTMENT != null)
            {
                string fs1 = "";
                var drf = MyData.DataSetKlons.DEPARTMENTS.FindByID(filterData1.fDEPARTMENT.Value);
                if (drf.GROUP == 0)
                {
                    fs1 = "TDEPARTMENT=" + filterData1.fDEPARTMENT.Value;
                }
                else
                {
                    fs1 = $"Parent(FK_ITEMS_TDEPARTMENT).CODE LIKE '{drf.CODE}*'";
                }
                fs = fs == "" ? fs1 : fs + " AND (" + fs1 + ")";
            }
            if (filterData1.fPLACE != null)
            {
                string fs1 = "";
                var drf = MyData.DataSetKlons.PLACES.FindByID(filterData1.fPLACE.Value);
                if (drf.GROUP == 0)
                {
                    fs1 = "TPLACE=" + filterData1.fPLACE.Value;
                }
                else
                {
                    fs1 = $"Parent(FK_ITEMS_TPLACE).CODE LIKE '{drf.CODE}*'";
                }
                fs = fs == "" ? fs1 : fs + " AND (" + fs1 + ")";
            }

            if (fs == "")
                bsItems.RemoveFilter();
            else if (bsItems.Filter != fs)
                bsItems.Filter = fs;
            CheckChildGrid();
        }

        private void dgvFilter_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!filterData1.fDATE1.HasValue)
            {
                MyMainForm.ShowWarning("Janorāda aprēķina datums.");
                return;
            }
            DoFilter();
        }

        private void dgvFilter_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgcFilterDate.Index)
            {
                if (e.FormattedValue == null || e.FormattedValue == DBNull.Value)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void tbDate_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
            {
                DateTime dt;
                if (tbDate.Text == "" || !Utils.StringToDate(tbDate.Text, out dt) 
                    || dt.Year < 1900 || dt.Year > 2100)
                {
                    MyMainForm.ShowWarning("Jānorāda korekts datums.");
                    tbDate.Text = Utils.DateToString(CurrentDate);
                    return;
                }
                SetDate(dt);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.D))
            {
                ShowDataPanel(!sgrEvents.Visible);
                return true;
            }
            if (keyData == (Keys.Control | Keys.G))
            {
                ShowFilterPanel(!pnFilter.Visible);
                return true;
            }
            if (keyData == (Keys.Control | Keys.F))
            {
                ShowSearchForm();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowSearchForm()
        {
            if (bsItems.Count == 0 || bsItems.Current == null) return;
            Form_Search.Show(DoSearch, this);
        }

        public void DoSearch(string text, Form_Search.ESerchDirection dir)
        {
            if (bsItems.Count == 0 || bsItems.Current == null) return;
            var stext = text.ToLower();
            int pos = dir == Form_Search.ESerchDirection.FromTop ? 0 : bsItems.Position;
            int step = dir == Form_Search.ESerchDirection.Up ? -1 : 1;
            pos += step;
            while(pos >= 0 && pos < bsItems.Count)
            {
                var dr = bsItems.CurrentDataRow as KlonsPDataSet.ITEMSRow;
                if (dr.REG_NR == text || (dr.NAME != null && dr.NAME.ToLower().Contains(stext)))
                {
                    bsItems.Position = pos;
                    return;
                }
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (bnNav.BindingSource == bsRows)
            {
                AddEvent();
            }
            if (bnNav.BindingSource == bsItems)
            {
                AddItem();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void tsbInfo_Click(object sender, EventArgs e)
        {
            var msg = string.Format("Pamatlīdzekļi: {0}\nNotikumi: {1}",
                bsItems.GetStats(),
                bsRows.GetStats());
            MyMainForm.ShowInfo(msg);

            /*
            var sb = new StringBuilder();
            sb.AppendLine(msg);
            sb.AppendLine(MyData.DataSetKlons.ITEMS.GetChangesAsString(0));
            MyMainForm.ShowInfo(sb.ToString());
            */
        }

        private void MakeReportMT()
        {
            if (!SaveData()) return;
            if (bsItems.Count == 0 || bsItems.Current == null) return;
            var dr = bsItems.CurrentDataRow as KlonsPDataSet.ITEMSRow;
            var it = new ItemInfo();
            it.SetFromRow(dr);
            var rt = it.MakeReport_MT(DateTime.MinValue, CurrentDate);
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }
            var fm = MyMainForm.ShowForm(typeof(Form_RepMT)) as Form_RepMT;
            fm.SetItemDataMt(it, CurrentDate);
        }

        private void MakeReportYR()
        {
            if (!SaveData()) return;
            if (bsItems.Count == 0 || bsItems.Current == null) return;
            var dr = bsItems.CurrentDataRow as KlonsPDataSet.ITEMSRow;
            var it = new ItemInfo();
            it.SetFromRow(dr);
            var rt = it.MakeReport_YR(DateTime.MinValue, CurrentDate);
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }
            var fm = MyMainForm.ShowForm(typeof(Form_RepMT)) as Form_RepMT;
            fm.SetItemDataYr(it, new DateTime(CurrentDate.Year, 12, 31));
        }

        private void MakeReportYRMergedTable()
        {
            if (!SaveData()) return;
            if (bsItems.Count == 0 || bsItems.Current == null) return;
            var dr = bsItems.CurrentDataRow as KlonsPDataSet.ITEMSRow;
            var it = new ItemInfo();
            it.SetFromRow(dr);
            var rt = it.MakeReportYrMerged(DateTime.MinValue, CurrentDate);
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }
            var fm = MyMainForm.ShowForm(typeof(FormRep_ItemMovement)) as FormRep_ItemMovement;
            fm.SetItemDataYr(it, new DateTime(CurrentDate.Year, 12, 31));
        }

        private void MakeReportYRMergedPrint(int repnr)
        {
            if (!SaveData()) return;
            if (bsItems.Count == 0 || bsItems.Current == null) return;
            var dr = bsItems.CurrentDataRow as KlonsPDataSet.ITEMSRow;
            var it = new ItemRepInfo();
            it.SetFromRow(dr);
            var rt = it.MakeReportYrMerged(DateTime.MinValue, CurrentDate);
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }
            it.SetSFields();
            it.FormatDescr();

            ReportViewerData rd = new ReportViewerData();
            if (repnr == 1)
                rd.FileName = "ReportP_Kartina_1";
            else if (repnr == 2)
                rd.FileName = "ReportP_Kartina_2";
            else
                rd.FileName = "ReportP_Kartina_4";
            rd.Sources["DataSet1"] = it.GetEventRepList();
            rd.Sources["DataSetItem"] = new List<ItemRepInfo>() { it };
            rd.AddReportParameters(
                new string[]
                {
                    "PCompany", MyData.Params.CompNameX,
                    "PDate", Utils.DateToString(CurrentDate),
                    "PIDIT", "0"
                });
            MyMainForm.ShowReport(rd);

        }

        private void MakeReportYRMergedPrintSelected()
        {
            if (!SaveData()) return;
            if (bsItems.Count == 0)
            {
                MyMainForm.ShowWarning("Nav atlasīti pamatlīdzekļi.");
                return;
            }
            var list_it = new List<ItemRepInfo>();
            var dic_it = new Dictionary<int, ItemRepInfo>();
            foreach(var bsit in bsItems)
            {
                var dr = (bsit as DataRowView).Row as KlonsPDataSet.ITEMSRow;
                var it = new ItemRepInfo();
                it.SetFromRow(dr);
                var rt = it.MakeReportYrMerged(DateTime.MinValue, CurrentDate);
                if (rt != "OK")
                {
                    rt = $"Pamatlīdzeklis:[{dr.REG_NR.Nz()}]:\n{rt}";
                    MyMainForm.ShowWarning(rt);
                    return;
                }
                it.SetSFields();
                it.FormatDescr();
                list_it.Add(it);
                dic_it[it.IdIt] = it;
            }

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportP_Kartina_2x";
            rd.Sources["DataSet1"] = list_it;
            rd.AddReportParameters(
                new string[]
                {
                    "PCompany", MyData.Params.CompNameX,
                    "PDate", Utils.DateToString(CurrentDate)
                });
            rd.OnSubreport = p =>
            {
                int idit = int.Parse(p.Parameters["PIDIT"].Values[0]);
                var itc = dic_it[idit];
                p.DataSources.Add(new ReportDataSource("DataSetItem", new[] { itc }));
                p.DataSources.Add(new ReportDataSource("DataSet1", itc.GetEventRepList()));
            };
            MyMainForm.ShowReport(rd);

        }

        private void MakeReportTaxDeprec()
        {
            if (!SaveData()) return;
            if (bsItems.Count == 0 || bsItems.Current == null) return;
            var dr = bsItems.CurrentDataRow as KlonsPDataSet.ITEMSRow;
            var it = new ItemRepInfo();
            it.SetFromRow(dr);
            var rt = it.MakeReport_YR(DateTime.MinValue, CurrentDate);
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportP_NodNolPL_1";
            rd.Sources["dsItem"] = new List<ItemRepInfo>() { it };
            rd.Sources["dsEvents"] = it.GetEventRepList(); ;
            rd.AddReportParameters(
                new string[]
                {
                    "PCompany", MyData.Params.CompNameX
                });
            MyMainForm.ShowReport(rd);
        }

        private void MakeReportTaxDeprecSelected()
        {
            if (!SaveData()) return;
            if (bsItems.Count == 0)
            {
                MyMainForm.ShowWarning("Nav atlasīti pamatlīdzekļi.");
                return;
            }
            var list_it = new List<ItemRepInfo>();
            var dic_it = new Dictionary<int, ItemRepInfo>();
            foreach (var bsit in bsItems)
            {
                var dr = (bsit as DataRowView).Row as KlonsPDataSet.ITEMSRow;
                var it = new ItemRepInfo();
                it.SetFromRow(dr);
                var rt = it.MakeReport_YR(DateTime.MinValue, CurrentDate);
                if (rt != "OK")
                {
                    rt = $"Pamatlīdzeklis:[{dr.REG_NR.Nz()}]:\n{rt}";
                    MyMainForm.ShowWarning(rt);
                    return;
                }
                list_it.Add(it);
                dic_it[it.IdIt] = it;
            }

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportP_NodNolPL_1x";
            rd.Sources["DataSet1"] = list_it;
            rd.AddReportParameters(
                new string[]
                {
                    "PCompany", MyData.Params.CompNameX
                });
            rd.OnSubreport = p =>
            {
                int idit = int.Parse(p.Parameters["PIDIT"].Values[0]);
                var itc = dic_it[idit];
                p.DataSources.Add(new ReportDataSource("dsItem", new[] { itc }));
                p.DataSources.Add(new ReportDataSource("dsEvents", itc.GetEventRepList()));
            };
            MyMainForm.ShowReport(rd);

        }

        private void pārrēķinātToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecalcCurrent();
        }
        private void jaunsPamatlīdzeklisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }
        private void jaunsNotikumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEvent();
        }
        private void amortizētāsAizstāšanasIzmaksasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplacePart();
        }
        private void meklētPamatlīdzekliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSearchForm();
        }
        private void rādītPaslēptDatuPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDataPanel(!sgrEvents.Visible);
        }

        private void rādītPaslēptFiltraPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFilterPanel(!sgrEvents.Visible);
        }

        private void aprēķinaIzklāstsPaMēnešiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeReportMT();
        }

        private void aprēķinaIzklāstsPaGadiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeReportYR();
        }

        private void miKartiņaTabula_Click(object sender, EventArgs e)
        {
            MakeReportYRMergedTable();
        }

        private void izdruka1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                MakeReportYRMergedPrint(2);
            });
        }

        private void izdruka2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                MakeReportYRMergedPrint(1);
            });
        }
        private void izdruka3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                MakeReportYRMergedPrint(3);
            });
        }

        private void izdruka1VisiemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                MakeReportYRMergedPrintSelected();
            });
        }

        private void nolietojumsNodokļaVajadzībāmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                MakeReportTaxDeprec();
            });
        }

        private void nolietojumsNodokļaVajadzībāmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                MakeReportTaxDeprecSelected();
            });
        }

    }
}
