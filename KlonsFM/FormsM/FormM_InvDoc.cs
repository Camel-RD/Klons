using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.DataSets;
using KlonsFM.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Data;
using KlonsLIB.Misc;
using KlonsFM.UI;
using KlonsLIB.Components;

namespace KlonsFM.FormsM
{
    public partial class FormM_InvDoc : MyFormBaseF, 
        IMyDgvTextboxEditingControlEvents2, IMyDgvTextboxEditingControlEvents
    {
        public FormM_InvDoc()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            MakeGrid();
        }

        private void FormM_InvDoc_Load(object sender, EventArgs e)
        {
            CheckSave();
            CheckEnableRows();

            MyData.DataSetKlonsM.M_INV_ROWS.ColumnChanged += M_INV_ROWS_ColumnChanged; ;
            grDocStore.ButtonClicked += GrDocStore_ButtonClicked;
            grDocIdStoreNor.ButtonClicked += GrDocStore_ButtonClicked;
            grDocIdStorePier.ButtonClicked += GrDocStore_ButtonClicked;
        }

        private void FormM_InvDoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlonsM.M_INV_ROWS.ColumnChanged -= M_INV_ROWS_ColumnChanged; ;
            grDocStore.ButtonClicked -= GrDocStore_ButtonClicked;
            grDocIdStoreNor.ButtonClicked -= GrDocStore_ButtonClicked;
            grDocIdStorePier.ButtonClicked -= GrDocStore_ButtonClicked;
        }

        private void MakeGrid()
        {
            sgrDoc.MakeGrid2();
            sgrDoc.LinkGrid();
        }

        public bool FindDoc(int iddoc)
        {
            if (bsDocs.Count == 0) return false;
            for (int i = 0; i < bsDocs.Count; i++)
            {
                var dr = (bsDocs[i] as DataRowView).Row as KlonsMDataSet.M_INV_DOCSRow;
                if (dr.ID != iddoc) continue;
                bsDocs.Position = i;
                ActiveDocId = iddoc;
                return true;
            }
            return false;
        }

        public static bool ShowDocMyDialog(int iddoc)
        {
            var form = KlonsData.St.MyMainForm.ShowFormMDialog<FormM_InvDoc>((Action<int>)null);
            bool rt = form.FindDoc(iddoc);
            if (!rt)
            {
                form.Close();
                KlonsData.St.MyMainForm.ShowError("Neizdevās atvērt dokumentu.");
                return false;
            }
            form.CheckColumnsVisible();
            return true;
        }

        public int? ActiveDocId = null;
        private bool ignoreColumnChangeEvent = false;
        private bool InRows_ColumnChanged = false;

        private void M_INV_ROWS_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (ignoreColumnChangeEvent) return;
            if (InRows_ColumnChanged) return;
            InRows_ColumnChanged = true;
            M_INV_ROWS_ColumnChangedA(e);
            InRows_ColumnChanged = false;
        }

        private void M_INV_ROWS_ColumnChangedA(DataColumnChangeEventArgs e)
        {
            var table = MyData.DataSetKlonsM.M_INV_ROWS;
            var table_items = MyData.DataSetKlonsM.M_ITEMS;
            var dr = e.Row as KlonsMDataSet.M_INV_ROWSRow;
            if (e.Column == table.IDITEMColumn)
            {
                int iditem = dr.IDITEM;
                var dr_item = table_items.FindByID(iditem);
                if (dr_item == null) return;
                dr.BeginEdit();
                dr.IDUNITS = dr_item.UNITS;
                dr.EndEdit();
                dgvRows.RefreshCurrent();
            }
            if (e.Column == table.AM_COUNTED_2Column)
            {
                dr.BeginEdit();
                var am_counted = dr.IsAM_COUNTED_2Null() ? dr.AM_COUNTED_1 : dr.AM_COUNTED_2;
                dr.AM_DIFF = dr.AM_CALC - am_counted;
                dr.EndEdit();
                dgvRows.RefreshCurrent();
            }
        }

        public void CheckColumnsVisible()
        {
            var dr_doc = GetCurrentDocRow();
            if (dr_doc == null) return;
            var b = dr_doc.XState != EInventoryDocState.Melnraksts;
            dgcRowsAmCounted2.Visible = b;
            dgcRowsAmCalc.Visible = b;
            dgcRowsAmDiff.Visible = b;
        }

        private void GetDocStoreCellValue(KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grow)
        {
            var id = (int?)grow.Value;
            string code = null;
            if (id != null)
                code = DataTasks.GetStoreCode(id.Value);
            int? new_id = FormM_Stores.GetStoreId(code);
            if (!new_id.HasValue) return;
            grow.Value = new_id.Value;
        }

        private void GrDocStore_ButtonClicked(object sender, EventArgs e)
        {
            var grow = sender as KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox;
            GetDocStoreCellValue(grow);
        }


        private KlonsMDataSet.M_INV_DOCSRow GetCurrentDocRow()
        {
            if (bsDocs.Count == 0 || bsDocs.Current == null) return null;
            var dr_doc = bsDocs.CurrentDataRow as KlonsMDataSet.M_INV_DOCSRow;
            return dr_doc;
        }

        private KlonsMDataSet.M_INV_DOCSRow GetGoodCurrentDocRow()
        {
            var dr_doc = GetCurrentDocRow();
            if (dr_doc == null) return null;
            if (!SaveData())
            {
                MyMainForm.ShowWarning("Neizdevās nesaglabāt datus.");
                return null;
            }
            if (myAdapterManager1.HasChanges())
            {
                MyMainForm.ShowWarning("Ir nesaglabāti dati.");
                return null;
            }
            return dr_doc;
        }


        private void CheckEnableRows()
        {
            sgrDoc.Visible = bsDocs.Count > 0 && bsDocs.Current != null;
            dgvRows.Enabled = bsDocs.Count > 0 && bsDocs.Current != null;
        }

        public override bool SaveData()
        {
            if (!dgvRows.EndEditX()) return false;
            if (!this.Validate()) return false;
            try
            {
                DataTasks.SetNewIDs(myAdapterManager1);
                bool rt = myAdapterManager1.UpdateAll();
                CheckSave();
                return rt;
            }
            catch (Exception e)
            {
                CheckSave();
                Form_Error.ShowException(e, "Neizdevās saglabāt izmaiņas.");
                return false;
            }
        }

        private bool HasChanges()
        {
            return myAdapterManager1.HasChanges();
        }

        private void CheckSave()
        {
            SetSaveButton(HasChanges());
        }

        private void SetSaveButton(bool red)
        {
            bNav.SetSaveButtonRed(red);
        }

        public void DeleteCurrent()
        {
            if (!CanEditCurrentDoc()) return;
            var dr_doc = GetCurrentDocRow();
            if (dr_doc.XState != EInventoryDocState.Melnraksts)
            {
                MyMainForm.ShowWarning("Pēc salīdzīnāšanas ierakstus dzēst nevar.", owner: this);
                return;
            }
            bNav.DeleteCurrent();
            SaveData();
        }

        public bool IsOpenToChanges(KlonsMDataSet.M_INV_DOCSRow dr_doc)
        {
            return dr_doc.XState != EInventoryDocState.Apstiprināts &&
                dr_doc.XState != EInventoryDocState.Iegrāmatots;
        }

        public bool CanEditDoc(KlonsMDataSet.M_INV_DOCSRow dr_doc)
        {
            if (dr_doc == null) return false;
            return IsOpenToChanges(dr_doc);
        }

        public bool CanEditCurrentDoc()
        {
            if (bsDocs.Count == 0 || bsDocs.Current == null) return false;
            var dr_doc = bsDocs.CurrentDataRow as KlonsMDataSet.M_INV_DOCSRow;
            if (dr_doc == null) return false;
            return IsOpenToChanges(dr_doc);
        }

        public bool CanDeleteCurrentRow()
        {
            if (bsDocs.Count == 0 || bsDocs.Current == null) return false;
            var dr_doc = bsDocs.CurrentDataRow as KlonsMDataSet.M_INV_DOCSRow;
            if (dr_doc == null) return false;
            if (bsRows.Count == 0 || bsRows.Current == null) return false;
            return dr_doc.XState == EInventoryDocState.Melnraksts;
        }

        public int? GetStoreId(string code, EStoreType storefilter = EStoreType.Nenoteikts)
        {
            return FormM_Stores.GetStoreId(code, storefilter);
        }

        public string GetStoreCode(string code)
        {
            return FormM_Stores.GetStoreCode(code);
        }

        public int? GetItemId(string code)
        {
            return FormM_Items.GetItemId(code);
        }

        public string GetItemCode(string code)
        {
            return FormM_Items.GetItemCode(code);
        }

        private bool CanEditDocsCurrentCell()
        {
            if (bsDocs.Count == 0 || bsDocs.Current == null) return false;
            return true;
        }

        private bool CanEditRowsCurrentCell()
        {
            if (bsRows.Count == 0 || bsRows.Current == null) return false;
            if (dgvRows.CurrentRow == null) return false;
            //if (dgvRows.CurrentRow.IsNewRow) return false;
            if (dgvRows.CurrentCell == null) return false;
            return true;
        }

        private void SetCurrentDocEditorValue(int value)
        {
            if (this.ActiveControl == null) return;
            try
            {
                if (this.ActiveControl is KlonsLIB.Components.MyMcComboBox)
                {
                    var c = this.ActiveControl as KlonsLIB.Components.MyMcComboBox;
                    c.SelectedValue = value;
                }
                else if (this.ActiveControl is KlonsLIB.Components.MyPickRowTextBox2)
                {
                    var c = this.ActiveControl as KlonsLIB.Components.MyPickRowTextBox2;
                    c.SelectedValue = value;
                }
            }
            catch (Exception) { }
        }

        private void SetCurrentRowsItemId(int itemid)
        {
            if (dgvRows.CurrentCell == null) return;
            try
            {
                var dr_item = MyData.DataSetKlonsM.M_ITEMS.FindByID(itemid);
                if (dr_item == null) return;
                dgvRows.BeginEdit(false);
                var s = dgvRows.EditingControl.GetType().Name;
                if (dgvRows.EditingControl is KlonsLIB.Components.MyMcComboBox)
                {
                    var c = dgvRows.EditingControl as KlonsLIB.Components.MyMcComboBox;
                    c.SelectedValue = itemid;
                }
                else if (dgvRows.EditingControl is KlonsLIB.Components.MyPickRowTextBox2)
                {
                    var c = dgvRows.EditingControl as KlonsLIB.Components.MyPickRowTextBox2;
                    c.Text = dr_item.BARCODE;
                }
                dgvRows.EndEdit();
            }
            catch (Exception) { }
        }

        public void GetDocStoreId()
        {
            if (!CanEditDocsCurrentCell()) return;
            var dv = this.ActiveControl.Text;
            var rt = GetStoreId(dv);
            if (rt == null) return;
            SetCurrentDocEditorValue(rt.Value);
        }

        public void GetRowItemID()
        {
            if (!CanEditRowsCurrentCell()) return;
            var cv = dgvRows.CurrentCell.FormattedValue as string;
            var ret = GetItemId(cv);
            if (ret == null) return;
            //var dr = (dgvRows.CurrentRow.DataBoundItem as DataRowView).Row as KlonsMDataSet.M_ROWSRow;
            SetCurrentRowsItemId(ret.Value);
        }

        private int SearchRowText(string text, int colindex,
            int startindex = 0, bool forward = true)
        {
            string propname = dgvRows.Columns[colindex].DataPropertyName;
            if (bsRows.Count == 0) return -1;
            if (startindex < 0 || startindex >= bsRows.Count) return -1;
            if (string.IsNullOrEmpty(text)) return -1;
            if (startindex == 0 && !forward) return -1;
            if (startindex == bsRows.Count - 1 && forward) return -1;
            var rv = bsRows[startindex] as DataRowView;
            if (rv == null) return -1;
            int colnr = rv.Row.Table.Columns.IndexOf(propname);
            if (colnr == -1) return -1;
            string columnname = rv.Row.Table.Columns[colnr].ColumnName;
            int di = forward ? 1 : -1;
            string val;
            text = text.ToLower();
            for (int i = startindex; i >= 0 && i < bsRows.Count; i += di)
            {
                var dr = (bsRows[i] as DataRowView).Row as KlonsMDataSet.M_INV_ROWSRow;
                if (dr == null) continue;
                val = null;
                if (colindex == dgcRowsItemName.Index)
                    val = MyData.DataSetKlonsM.M_ITEMS.FindByID(dr.IDITEM)?.NAME;
                else if (colindex == dgcRowsIdItem.Index)
                    val = MyData.DataSetKlonsM.M_ITEMS.FindByID(dr.IDITEM)?.BARCODE;
                if (val == null) continue;
                if (val.ToLower().Contains(text))
                {
                    return i;
                }
            }
            return -1;
        }

        private void SearchRowText(bool fromfirst = true, bool forward = true)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            if (!dgvRows.EndEditX()) return;

            int startindex = dgvRows.CurrentRow.Index;
            startindex = fromfirst ? 0 : (forward ? startindex + 1 : startindex - 1);
            string text = tsbFind.Text;
            if (text == "") return;
            int newindex = SearchRowText(text, dgvRows.CurrentCell.ColumnIndex, startindex, forward);
            if (newindex == -1)
            {
                MyMainForm.ShowInfo("Tekts [" + text + "] netika atrasts.");
                return;
            }
            dgvRows.CurrentCell = dgvRows[dgvRows.CurrentCell.ColumnIndex, newindex];
        }

        private void dgvRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value) return;

            if (e.ColumnIndex == dgcRowsItemName.Index)
            {
                int id = (int)e.Value;
                var table_items = MyData.DataSetKlonsM.M_ITEMS;
                var dr = table_items.FindByID(id);
                if (dr == null) return;
                e.Value = dr.NAME;
                e.FormattingApplied = true;
            }
            if (e.ColumnIndex == dgcRowsIdUnits.Index)
            {
                int id = (int)e.Value;
                var table_units = MyData.DataSetKlonsM.M_UNITS;
                var dr = table_units.FindByID(id);
                if (dr == null) return;
                e.Value = dr.CODE;
                e.FormattingApplied = true;
            }
        }

        private void bniSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bniDelete_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void bniNew_Click(object sender, EventArgs e)
        {
            dgvRows.MoveToNewRow();
        }

        private void dgvRows_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!CanDeleteCurrentRow()) return;
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void bNav_ItemDeleting(object sender, CancelEventArgs e)
        {
            if (!CanDeleteCurrentRow()) return;
            e.Cancel = !AskCanDelete();
        }

        private void dgvRows_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvRows.CurrentCell == null) return;
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvRows.EndEdit()) return;
                dgvRows.MoveToNewRow();
                e.Handled = true;
                return;
            }

            if (dgvRows.CurrentRow == null ||
                //dgvRows.CurrentRow.IsNewRow ||
                dgvRows.CurrentCell == null) return;
            int colnr = dgvRows.CurrentCell.ColumnIndex;

            if (e.KeyCode == Keys.F4)
            {
                if (!CanEditCurrentDoc()) return;
                if (colnr == dgcRowsIdItem.Index)
                {
                    GetRowItemID();
                    e.Handled = true;
                    return;
                }
            }
        }

        private void dgvRows_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRows.CurrentRow == null ||
                //dgvRows.CurrentRow.IsNewRow ||
                dgvRows.CurrentCell == null) return;
            if (!CanEditCurrentDoc()) return;
            int colnr = dgvRows.CurrentCell.ColumnIndex;

            if (colnr == dgcRowsIdItem.Index)
            {
                GetRowItemID();
                return;
            }
        }

        private void dgvRows_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void bsDocs_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckEnableRows();
            CheckSave();
        }

        private void bsDocs_CurrentChanged(object sender, EventArgs e)
        {
            CheckEnableRows();
        }

        private void bsRows_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (e.ListChangedType == ListChangedType.Reset) return;
            CheckSave();
        }

        private void dgvRows_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }

        void IMyDgvTextboxEditingControlEvents2.OnButtonClicked(MyDgvTextboxEditingControl2 control)
        {
            if (control.DataSource == bsStore)
            {
                GetDocStoreId();
                return;
            }
            if (control.DataSource == bsItems)
            {
                GetRowItemID();
                return;
            }
        }

        void IMyDgvTextboxEditingControlEvents.OnButtonClicked(MyDgvTextboxEditingControl control)
        {
            if (control.DataSource == bsStore)
            {
                GetDocStoreId();
                return;
            }
            if (control.DataSource == bsItems)
            {
                GetRowItemID();
                return;
            }
        }

        private bool CanEditAmCounted2(KlonsMDataSet.M_INV_DOCSRow dr_doc)
        {
            return dr_doc.XState == EInventoryDocState.Salīdzināts;
        }

        private void dgvRows_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var dr_row = (bsRows[e.RowIndex] as DataRowView).Row as KlonsMDataSet.M_INV_ROWSRow;
            if (dr_row == null) return;
            var dr_doc = dr_row.M_INV_DOCSRow;
            if (!CanEditDoc(dr_doc))
                e.Cancel = true;
            if (e.ColumnIndex == dgcRowsAmCounted2.Index && !CanEditAmCounted2(dr_doc))
                e.Cancel = true;
            if (e.ColumnIndex == dgcRowsAmCounted1.Index && CanEditAmCounted2(dr_doc))
                e.Cancel = true;
        }

        private void sgrDoc_ConvertingValueToDisplayString(object sender, DevAge.ComponentModel.ConvertingObjectEventArgs e)
        {
            if (sender == grDocState)
            {
                var state = (EInventoryDocState)e.Value;
                var val = SomeDataDefs.GetInventoryDocStateText(state);
                e.Value = val;
                e.ConvertingStatus = DevAge.ComponentModel.ConvertingStatus.Completed;
            }
        }

        private void tsbFindPrev_Click(object sender, EventArgs e)
        {
            SearchRowText(false, false);
            dgvRows.Focus();
        }

        private void tsbFindNext_Click(object sender, EventArgs e)
        {
            SearchRowText(false, true);
            dgvRows.Focus();
        }

        private void tsbFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SearchRowText();
                dgvRows.Focus();
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                dgvRows.Focus();
                e.Handled = true;
                return;
            }
        }

        private void tsbFind_Enter(object sender, EventArgs e)
        {
            tsbFind.Text = "";
        }

        private void sgrDoc_EditStarting(object sender, CancelEventArgs e)
        {
            if (!CanEditCurrentDoc())
            {
                e.Cancel = true;
            }
        }

        public ErrorList CheckOneEntryPerItem(KlonsMDataSet.M_INV_DOCSRow dr_doc)
        {
            var ret = new ErrorList();
            var drs_rows = dr_doc.GetM_INV_ROWSRows();
            var bad_ids = drs_rows
                .GroupBy(x => x.IDITEM)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)
                .ToList();
            foreach (var id in bad_ids)
                ret.AddItemError(id, "Artikuls ir ievadīts vairāk kā 1 reizi.");
            return ret;
        }

        public void DoCompareWithDB()
        {
            var err = new ErrorList();
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return;
            if (bsRows.Count == 0)
            {
                MyMainForm.ShowWarning("Dokumentā nav ievadīti dati.", owner: this);
                return;
            }
            if(dr_doc.XState != EInventoryDocState.Melnraksts)
            {
                MyMainForm.ShowWarning("Datu salīdzināšana jau ir veikta.", owner: this);
                return;
            }
            err = CheckOneEntryPerItem(dr_doc);
            if (err.HasErrors)
            {
                FormM_ErrorList.ShowErrorList(this, err);
                return;
            }
            var table_rows = MyData.DataSetKlonsM.M_INV_ROWS;
            var table_items = MyData.DataSetKlonsM.M_ITEMS;
            var ad = new DataSets.KlonsMRepDataSetTableAdapters.SP_M_REP_ITEMSINSTORE_1TableAdapter();
            var table_rep = ad.GetDataBy_SP_M_REP_ITEMSINSTORE_1(dr_doc.IDSTORE);
            var drs_rows = dr_doc.GetM_INV_ROWSRows();
            var dic_drs_rows = drs_rows.ToDictionary(x => x.IDITEM);
            var dic_drs_rep = table_rep.ToDictionary(x => x.IDITEM);

            table_rep
               .Where(x => table_items.FindByID(x.IDITEM) == null)
               .ForEach(x => err.AddError($"{x.ITEMCODE}", "Artiukuls nav atrasts artikulu sarakstā."));
            if (err.HasErrors)
            {
                FormM_ErrorList.ShowErrorList(this, err);
                return;
            }

            ignoreColumnChangeEvent = true;
            foreach (var dr_rep in table_rep)
            {
                if (dic_drs_rows.TryGetValue(dr_rep.IDITEM, out var dr_row))
                {
                    dr_row.AM_CALC = dr_rep.AMOUNT;
                    dr_row.AM_DIFF = dr_rep.AMOUNT - dr_row.AM_COUNTED_1;
                }
                else
                {
                    var dr_new = table_rows.NewM_INV_ROWSRow();
                    dr_new.IDDOC = dr_doc.ID;
                    dr_new.M_INV_DOCSRow = dr_doc;
                    dr_new.IDITEM = dr_rep.IDITEM;
                    var dr_item = table_items.FindByID(dr_rep.IDITEM);
                    dr_new.IDUNITS = dr_item == null ? 1 : dr_item.UNITS;
                    dr_new.AM_COUNTED_1 = 0M;
                    dr_new.AM_COUNTED_2 = 0M;
                    dr_new.AM_CALC = dr_rep.AMOUNT;
                    dr_new.AM_DIFF = dr_rep.AMOUNT;
                    table_rows.AddM_INV_ROWSRow(dr_new);
                }
            }
            foreach (var dr_row in drs_rows)
            {
                if (!dic_drs_rep.TryGetValue(dr_row.IDITEM, out var dr_rep))
                {
                    dr_row.AM_CALC = 0M;
                    dr_row.AM_DIFF = -dr_row.AM_COUNTED_1;
                }
            }

            ignoreColumnChangeEvent = false;
            dr_doc.XState = EInventoryDocState.Salīdzināts;
            dgvRows.AllowUserToAddRows = false;
            SaveData();
            CheckColumnsVisible();
            dgvRows.Refresh();
        }

        public void DoCloseDoc()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return;
            if (bsRows.Count == 0)
            {
                MyMainForm.ShowWarning("Dokumentā nav ievadīti dati.", owner: this);
                return;
            }
            if (dr_doc.XState != EInventoryDocState.Salīdzināts)
            {
                MyMainForm.ShowWarning("Datu salīdzināšana nav veikta.", owner: this);
                return;
            }
            if (dr_doc.XState == EInventoryDocState.Apstiprināts ||
                dr_doc.XState == EInventoryDocState.Iegrāmatots)
            {
                MyMainForm.ShowWarning("Dokuments jau ir apstiprināts.", owner: this);
                return;
            }
            dr_doc.XState = EInventoryDocState.Apstiprināts;
            SaveData();
            CheckColumnsVisible();
        }

        public void DoMakeStoreDoc()
        {
            ErrorList err;
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return;
            if (bsRows.Count == 0)
            {
                MyMainForm.ShowWarning("Dokumentā nav ievadīti dati.", owner: this);
                return;
            }
            if (dr_doc.XState != EInventoryDocState.Melnraksts)
            {
                MyMainForm.ShowWarning("Datu salīdzināšana nav veikta.", owner: this);
                return;
            }
            if (dr_doc.XState != EInventoryDocState.Apstiprināts)
            {
                MyMainForm.ShowWarning("Dokuments nav apstiprināts.", owner: this);
                return;
            }
            if (dr_doc.XState == EInventoryDocState.Iegrāmatots)
            {
                bool rt = MyMainForm.AskSomething("Dokuments jau ir iegrāmatots.\n"+
                    "Vai veidot norakstīšanas / pierakstīšanas atkārtoti?", owner: this);
                if (!rt) return;
            }
            err = CheckOneEntryPerItem(dr_doc);
            if (err.HasErrors)
            {
                FormM_ErrorList.ShowErrorList(this, err);
                return;
            }
            if (inventoryDocData1._IDSTORE_NOR == 1 || inventoryDocData1._IDSTORE_PIER == 1)
            {
                MyMainForm.ShowWarning("Jānorāda kodi uz kuriem tiks veikta norakstīšana / pierakstīšana. ", owner: this);
                return;
            }

            if (inventoryDocData1._NR_NOR.IsNOE() || inventoryDocData1._NR_PIER.IsNOE())
            {
                MyMainForm.ShowWarning("Jānorāda norakstīšanas / pierakstīšanas dokumentu numuri. ", owner: this);
                return;
            }

            var dr_store_nor = MyData.DataSetKlonsM.M_STORES.FindByID(inventoryDocData1._IDSTORE_NOR);
            var dr_store_pier = MyData.DataSetKlonsM.M_STORES.FindByID(inventoryDocData1._IDSTORE_PIER);

            if (dr_store_nor.XStoreType != EStoreType.Citi || dr_store_pier.XStoreType != EStoreType.Citi)
            {
                MyMainForm.ShowWarning("Norakstīšanas / pierakstīšanas noliktavas veidam jābūt 'Cits'. ", owner: this);
                return;
            }

            var table_docs = MyData.DataSetKlonsM.M_DOCS;
            var table_rows = MyData.DataSetKlonsM.M_ROWS;
            var drs_rows = dr_doc.GetM_INV_ROWSRows();
            var drs_rows_nor = drs_rows
                .Where(x => x.AM_DIFF < 0M)
                .ToList();
            var drs_rows_pier = drs_rows
                .Where(x => x.AM_DIFF > 0M)
                .ToList();

            if(drs_rows_nor.Count > 0)
            {
                var drnew_doc = table_docs.NewM_DOCSRow();
                drnew_doc.DT = DateTime.Today;
                drnew_doc.NR = inventoryDocData1._NR_NOR;
                drnew_doc.XDocType = EDocType.Norakstīts;
                drnew_doc.XState = EDocState.Melnraksts;
                drnew_doc.IDSTOREOUT = dr_doc.IDSTORE;
                drnew_doc.IDSTOREIN = inventoryDocData1._IDSTORE_NOR;
                table_docs.AddM_DOCSRow(drnew_doc);
                foreach (var dr_nor in drs_rows_nor)
                {
                    var drnew_row = table_rows.NewM_ROWSRow();
                    drnew_row.IDDOC = drnew_doc.ID;
                    drnew_row.M_DOCSRow = drnew_doc;
                    drnew_row.IDITEM = dr_nor.IDITEM;
                    drnew_row.UNITS = dr_nor.IDUNITS;
                    drnew_row.AMOUNT = -dr_nor.AM_DIFF;
                    drnew_row.PRICE0 = dr_nor.M_ITEMSRow.SELLPRICE;
                    drnew_row.PRICE = dr_nor.M_ITEMSRow.SELLPRICE;
                    drnew_row.TPRICE = drnew_row.PRICE * -dr_nor.AM_DIFF;
                    table_rows.AddM_ROWSRow(drnew_row);
                }
            }
            if (drs_rows_pier.Count > 0)
            {
                var drnew_doc = table_docs.NewM_DOCSRow();
                drnew_doc.DT = DateTime.Today;
                drnew_doc.NR = inventoryDocData1._NR_PIER;
                drnew_doc.XDocType = EDocType.Pierakstīts;
                drnew_doc.XState = EDocState.Melnraksts;
                drnew_doc.IDSTOREOUT = inventoryDocData1._IDSTORE_NOR;
                drnew_doc.IDSTOREIN = dr_doc.IDSTORE;
                table_docs.AddM_DOCSRow(drnew_doc);
                foreach (var dr_nor in drs_rows_nor)
                {
                    var drnew_row = table_rows.NewM_ROWSRow();
                    drnew_row.IDDOC = drnew_doc.ID;
                    drnew_row.M_DOCSRow = drnew_doc;
                    drnew_row.IDITEM = dr_nor.IDITEM;
                    drnew_row.UNITS = dr_nor.IDUNITS;
                    drnew_row.AMOUNT = dr_nor.AM_DIFF;
                    drnew_row.PRICE0 = dr_nor.M_ITEMSRow.SELLPRICE;
                    drnew_row.PRICE = dr_nor.M_ITEMSRow.SELLPRICE;
                    drnew_row.TPRICE = drnew_row.PRICE * -dr_nor.AM_DIFF;
                    table_rows.AddM_ROWSRow(drnew_row);
                }
            }
            dr_doc.XState = EInventoryDocState.Iegrāmatots;
            SaveData();
            MyMainForm.ShowInfo("Norakstīšanas / pierakstīšanas dokumenti izveidoti.", owner: this);
        }

        public void DoFilter(bool applyfilter)
        {
            if (!applyfilter)
            {
                bsRows.RemoveFilter();
                return;
            }
            bsRows.Filter = "AM_DIFF <> 0";
        }

        private void miCompareWithDB_Click(object sender, EventArgs e)
        {
            DoCompareWithDB();
        }

        private void miCloseDoc_Click(object sender, EventArgs e)
        {
            DoCloseDoc();
        }

        private void miMakeStoreDoc_Click(object sender, EventArgs e)
        {
            DoMakeStoreDoc();
        }

        private void miFilterRows_Click(object sender, EventArgs e)
        {
            bool b = !miFilterRows.Checked;
            miFilterRows.Checked = b;
            DoFilter(b);
        }
    }
}
