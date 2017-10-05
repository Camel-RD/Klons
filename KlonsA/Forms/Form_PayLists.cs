using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsA.DataSets;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using KlonsLIB.Components;

namespace KlonsA.Forms
{
    public partial class Form_PayLists : MyFormBaseA
    {
        public Form_PayLists()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            SetupToolStrips();

            try
            {
                MakeGrid();
            }
            catch (Exception ex)
            {
                Form_Error.ShowException(ex);
            }
        }

        private void Form_PayLists_Load(object sender, EventArgs e)
        {
            ShowPayLists(MyData.Settings.ShowPayLists);
            ShowPayDataPanel(MyData.Settings.ShowPayDataPanel);
            tslPeriod.Text = DataLoader.GetPeriodStr();
            MyData.DataSetKlons.PAYLISTS_R.ColumnChanged += PAYLISTS_R_ColumnChanged;
            MyData.DataSetKlons.PAYLISTS_R.PAYLISTS_RRowChanged += PAYLISTS_R_PAYLISTS_RRowChanged;
            MyData.DataSetKlons.PAYLISTS_R.PAYLISTS_RRowDeleted += PAYLISTS_R_PAYLISTS_RRowDeleted;
            MyData.DataSetKlons.PAYLISTS_R.PAYLISTS_RRowDeleting += PAYLISTS_R_PAYLISTS_RRowDeleting;
            MyData.DataSetKlons.PAYLISTS.ColumnChanged += PAYLISTS_ColumnChanged;
            CheckEnableRows();
            CheckEnableSGR();
            CheckSave();
        }

        private KlonsADataSet.PAYLISTSRow last_list_RowDeleting_parent = null;
        private void PAYLISTS_R_PAYLISTS_RRowDeleting(object sender, KlonsADataSet.PAYLISTS_RRowChangeEvent e)
        {
            last_list_RowDeleting_parent = e.Row.PAYLISTSRow;
        }

        private void PAYLISTS_R_PAYLISTS_RRowDeleted(object sender, KlonsADataSet.PAYLISTS_RRowChangeEvent e)
        {
            if (e.Action == DataRowAction.Add || e.Action == DataRowAction.Change)
            {
                CheckListTotal(e.Row.PAYLISTSRow);
            }
        }

        private void PAYLISTS_R_PAYLISTS_RRowChanged(object sender, KlonsADataSet.PAYLISTS_RRowChangeEvent e)
        {
            KlonsADataSet.PAYLISTSRow dr = null;

            if (e.Row.HasVersion(DataRowVersion.Original))
            {
                int listid = (int)e.Row["IDS", DataRowVersion.Original];
                dr = MyData.DataSetKlons.PAYLISTS.FindByID(listid);
            }
            else
            {
                dr = last_list_RowDeleting_parent;
            }
            if (dr == null) return;
            CheckListTotal(dr);
        }

        private void CheckListTotal(KlonsADataSet.PAYLISTSRow listrow)
        {
            if (listrow == null) return;
            var total = SumTotal(listrow);
            if (listrow.TOTAL_PAY != total) listrow.TOTAL_PAY = total;
        }

        private decimal SumTotal(KlonsADataSet.PAYLISTSRow listrow)
        {
            if (listrow == null) return 0.0M;
            decimal ret = 0.0M;
            var rows = listrow.GetPAYLISTS_RRows();
            foreach(var row in rows)
            {
                ret += row.TPAY;
            }
            return ret;
        }

        private void Form_PayLists_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlons.PAYLISTS_R.ColumnChanged -= PAYLISTS_R_ColumnChanged;
            MyData.DataSetKlons.PAYLISTS.ColumnChanged -= PAYLISTS_ColumnChanged;
            MyData.DataSetKlons.PAYLISTS_R.PAYLISTS_RRowChanged -= PAYLISTS_R_PAYLISTS_RRowChanged;
            MyData.DataSetKlons.PAYLISTS_R.PAYLISTS_RRowDeleted -= PAYLISTS_R_PAYLISTS_RRowDeleted;
            MyData.DataSetKlons.PAYLISTS_R.PAYLISTS_RRowDeleting -= PAYLISTS_R_PAYLISTS_RRowDeleting;
        }

        private void SetupToolStrips()
        {
            InsertInToolStrip(toolStrip1, cbLists, 2);
        }

        private void MakeGrid()
        {
            sgrPayRow.MakeGrid();
            sgrPayRow.LinkGrid();
        }

        private bool ignoreColumnChangeEvent = false;
        private bool InPAYLISTS_R_ColumnChanged = false;

        private void PAYLISTS_R_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (ignoreColumnChangeEvent) return;
            if (InPAYLISTS_R_ColumnChanged) return;
            InPAYLISTS_R_ColumnChanged = true;
            PAYLISTS_R_ColumnChangedA(e);
            InPAYLISTS_R_ColumnChanged = false;
        }

        private void PAYLISTS_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column == MyData.DataSetKlons.PAYLISTS.DTColumn)
            {
                if (e.ProposedValue == null || e.ProposedValue == DBNull.Value) return;
                var dr = e.Row as KlonsADataSet.PAYLISTSRow;
                var dt = (DateTime)e.ProposedValue;
                dr.YR = dt.Year;
                dr.MT = dt.Month;
            }
        }

        private void PAYLISTS_R_ColumnChangedA(DataColumnChangeEventArgs e)
        {
            var table = MyData.DataSetKlons.PAYLISTS_R;
            if (e.Column == table.IDPColumn)
            {
                if (e.ProposedValue == null || e.ProposedValue == DBNull.Value) return;
                int idp = (int)e.ProposedValue;
                var drp = MyData.DataSetKlons.PERSONS.FindByID(idp);
                e.Row.BeginEdit();
                e.Row["IDAM"] = drp.GetPOSITIONSRows()[0].ID;
                e.Row.EndEdit();
                dgvRows.RefreshCurrent();
                return;
            }

            /*
            if (e.Column == table.PAY0Column ||
                e.Column == table.ADVANCE0Column)
            {
                var dr = e.Row as KlonsADataSet.PAYLISTS_RRow;
                var d = dr.PAY0 + dr.ADVANCE0;
                if(d != dr.TPAY0)
                {
                    dr.BeginEdit();
                    dr.TPAY0 = d;
                    dr.EndEdit();
                    dgvRows.RefreshCurrent();
                }
                return;
            }
            */

            if (e.Column == table.PAYColumn ||
                e.Column == table.ADVANCEColumn ||
                e.Column == table.WITHHOLDINGSColumn)
            {
                var dr = e.Row as KlonsADataSet.PAYLISTS_RRow;
                var pay = dr.PAY;
                bool b1 = false;
                if (dr.PAY > 0.0M && dr.PAY > dr.PAY0)
                {
                    b1 = true;
                    pay = dr.PAY0;
                }
                var d = pay + dr.ADVANCE - dr.WITHHOLDINGS;
                if (d != dr.TPAY || pay != dr.PAY)
                {
                    dr.BeginEdit();
                    dr.TPAY = d;
                    dr.PAY = pay;
                    if (b1 || e.Column == table.PAYColumn)
                        UpdateListMatch(dr);
                    dr.EndEdit();
                    dgvRows.RefreshCurrent();
                }
                return;
            }

            if (e.Column == table.TPAYColumn)
            {
                var dr = e.Row as KlonsADataSet.PAYLISTS_RRow;
                var d = dr.PAY + dr.ADVANCE;
                var AW0 = dr.ADVANCE0 - dr.WITHHOLDINGS0;

                dr.BeginEdit();
                if (dr.TPAY >= dr.TPAY0 || dr.PAY0 < 0.0M)
                {
                    dr.PAY = dr.PAY0;
                }
                else
                {
                    if (AW0 >= 0.0M)
                    {
                        if (dr.TPAY >= 0.0M)
                            dr.PAY = Math.Min(dr.PAY0, dr.TPAY);
                        else
                            dr.PAY = 0.0M;
                    }
                    else
                    {
                        if (dr.TPAY >= 0.0M)
                            dr.PAY = Math.Min(dr.PAY0, dr.TPAY - AW0);
                        else
                            dr.PAY = Math.Min(dr.PAY0, - AW0);
                    }
                }
                var AW = dr.TPAY - dr.PAY;
                if (AW > AW0 && dr.WITHHOLDINGS > 0.0M)
                {
                    dr.WITHHOLDINGS = Math.Max(dr.WITHHOLDINGS0 - (AW - AW0), 0.0M);
                }
                else
                {
                    dr.WITHHOLDINGS = dr.WITHHOLDINGS0;
                }
                dr.ADVANCE = AW + dr.WITHHOLDINGS;


                /*
                dr.IIN = dr.IIN0;
                if (dr.PAY0 < 0.0M)
                {
                    dr.IIN_REVERSE = dr.IIN0;
                    dr.PAY_REVERSE = dr.PAY0;
                }
                else if (dr.PAY0 == 0.0M)
                    dr.IIN = 0.0M;
                else
                    dr.IIN = Math.Round(dr.PAY / dr.PAY0 * dr.IIN0);
                */

                UpdateListMatch(dr);

                dr.EndEdit();
                dgvRows.RefreshCurrent();

                return;
            }
        }

        public void UpdateListMatch(KlonsADataSet.PAYLISTS_RRow dr)
        {
            /*
            var ad = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.SP_PAY_MATCHLISTSTableAdapter();
            var tab = ad.GetData_SP_REP_PAY_MATCHLISTS_02(dr.IDAM, dr.PAY, dr.PAYLISTSRow.DT);
            var pr = tab[0];
            DataTasks.FillPayRowB(dr, pr);
            */

                var ad2 = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.SP_PAY_MATCHLISTS_1XTableAdapter();
            var tab2 = ad2.GetDataBy_SP_PAY_MATCHLISTS_12(dr.IDAM, dr.PAY, dr.PAYLISTSRow.DT);
            var pr2 = tab2[0];
            DataTasks.FillPayRowC(dr, pr2);
  
        }

        public void DeleteCurrent()
        {
            bNav.DeleteCurrent();
            SaveData();
        }

        private void dgvLists_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvRows_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void bNav_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvLists_Enter(object sender, EventArgs e)
        {
            bNav.BindingSource = bsLists;
            bNav.DataGrid = dgvLists;
            tsLabel1.Text = "Saraksti:";
        }

        private void dgvRows_Enter(object sender, EventArgs e)
        {
            bNav.BindingSource = bsRows;
            bNav.DataGrid = dgvRows;
            tsLabel1.Text = "Rindas:";
        }

        private void dgvLists_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvLists.CurrentCell == null) return;
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvLists.EndEdit()) return;
                dgvLists.MoveToNewRow();
                e.Handled = true;
                return;
            }
        }

        private void dgvRows_KeyDown(object sender, KeyEventArgs e)
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
        }

        private void dgvLists_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvLists.CurrentRow == null || dgvLists.CurrentRow.IsNewRow ||
                dgvLists.CurrentCell == null) return;
            int colnr = dgvLists.CurrentCell.ColumnIndex;

            if (e.KeyCode == Keys.F5)
            {
                if (colnr != dgcListsDep.Index) return;
                GetIDDepFromDialog();
                e.Handled = true;
                return;
            }
        }

        private void dgvRows_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow ||
                dgvRows.CurrentCell == null) return;
            int colnr = dgvRows.CurrentCell.ColumnIndex;

            if (e.KeyCode == Keys.F5)
            {
                if (colnr != dgcRowsIDP.Index && colnr != dgcRowsIDAM.Index) return;
                GetIDPFromDialog();
                e.Handled = true;
                return;
            }
        }

        private void dgvLists_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLists.CurrentRow == null || dgvLists.CurrentRow.IsNewRow ||
                dgvLists.CurrentCell == null) return;
            int colnr = dgvLists.CurrentCell.ColumnIndex;
            if (colnr != e.ColumnIndex) return;

            if (colnr == dgcListsDep.Index)
            {
                GetIDDepFromDialog();
            }
        }

        private void dgvRows_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow ||
                dgvRows.CurrentCell == null) return;
            int colnr = dgvRows.CurrentCell.ColumnIndex;
            if (colnr != dgcRowsIDP.Index && colnr != dgcRowsIDAM.Index) return;
            GetIDPFromDialog();
        }

        public void GetIDPFromDialog()
        {
            if (bsRows.Count == 0 || bsRows.Current == null) return;
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var fm = new Form_Persons();
            fm.WhatToSelect = Form_Persons.EWhatToSelect.Both;
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            var dr = (dgvRows.CurrentRow.DataBoundItem as DataRowView).Row as KlonsADataSet.PAYLISTS_RRow;
            if (dgvRows.CurrentCell != null)
            {
                try
                {
                    if(dgvRows.CurrentCell.OwningColumn == dgcRowsIDP)
                    {
                        dgvRows.BeginEdit(false);
                        var c = dgvRows.EditingControl as DataGridViewComboBoxEditingControl;
                        c.SelectedValue = fm.SelectedIDP;
                        dgvRows.EndEdit();

                        dr.IDAM = fm.SelectedIDAM;
                    }
                    if (dgvRows.CurrentCell.OwningColumn == dgcRowsIDAM)
                    {
                        dgvRows.EndEdit();

                        dr.IDP = fm.SelectedIDP;

                        dgvRows.BeginEdit(false);
                        var c = dgvRows.EditingControl as DataGridViewComboBoxEditingControl;
                        c.SelectedValue = fm.SelectedIDAM;
                        dgvRows.EndEdit();
                    }
                }
                catch (Exception) { }
            }
        }

        public void GetIDDepFromDialog()
        {
            if (bsLists.Count == 0 || bsLists.Current == null) return;
            if (dgvLists.CurrentRow == null || dgvLists.CurrentRow.IsNewRow) return;
            var fm = new Form_Departments();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            var dr = (dgvLists.CurrentRow.DataBoundItem as DataRowView).Row as KlonsADataSet.PAYLISTSRow;
            if (dgvLists.CurrentCell != null)
            {
                try
                {
                    dgvLists.BeginEdit(false);
                    var c = dgvLists.EditingControl as MyMcComboBox;
                    c.SelectedValue = fm.SelectedValue;
                    dgvLists.EndEdit();
                }
                catch (Exception) { }
            }
        }

        private void CheckEnableRows()
        {
            dgvRows.Enabled = dgvLists.RowCount > 0 && dgvLists.CurrentRow != null && 
                dgvLists.CurrentRow != null && !dgvLists.CurrentRow.IsNewRow;

            CheckEnableSGR();
        }

        private void CheckEnableSGR()
        {
            sgrPayRow.Enabled = dgvRows.Enabled && bsRows.Count > 0 &&
                dgvRows.CurrentRow != null && !dgvRows.CurrentRow.IsNewRow;
        }

        private void dgvLists_CurrentCellChanged(object sender, EventArgs e)
        {
            CheckEnableRows();
        }

        private void dgvRows_CurrentCellChanged(object sender, EventArgs e)
        {
            CheckEnableSGR();
        }


        public override bool SaveData()
        {
            if (!dgvLists.EndEditX()) return false;
            if (!dgvRows.EndEditX()) return false;

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
            bNav.SetSaveButton(tsbSave, red);
        }

        private bool HasChanges()
        {
            return myAdapterManager1.HasChanges();
        }

        private void CheckSave()
        {
            SetSaveButton(HasChanges());
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvLists_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void bsLists_ListChanged(object sender, ListChangedEventArgs e)
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

        private void dgvRows_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == dgcRowsIDAM.Index)
            {
                var val_idp = dgvRows[dgcRowsIDP.Index, e.RowIndex].Value;
                if (val_idp == null || val_idp == DBNull.Value)
                {
                    e.Cancel = true;
                    return;
                }
                var c0 = dgvRows[e.ColumnIndex, e.RowIndex];
                var c = c0 as DataGridViewComboBoxCell;
                if (c == null) return;
                int idp = (int)val_idp;
                bsAmatiF.Filter = "USED=1 and IDP=" + idp;
                c.DataSource = bsAmatiF;
            }
        }

        private void dgvRows_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgcRowsIDAM.Index)
            {
                var c = dgvRows[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                c.DataSource = bsAmati;
            }
        }

        private void dgvLists_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[dgcListsYR.Index].Value = DataLoader.LoadedDT2.Year;
            e.Row.Cells[dgcListsMT.Index].Value = DataLoader.LoadedDT2.Month;
            e.Row.Cells[dgcListsSNR.Index].Value = DataTasks.GetNextPayListNr(DataLoader.LoadedDT2.Year);
            e.Row.Cells[dgcListsDT.Index].Value = DateTime.Today;
        }

        private void dgvRows_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[dgcRowsSNR.Index].Value = dgvRows.Rows.Count;
        }

        private void dgvLists_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcListsDT.Index)
            {
                if (e.Value == null) return;
                if (!Utils.DGVParseDateCell(e))
                {
                    e.Value = null;
                    e.ParsingApplied = true;
                    return;
                }
            }
        }

        private void AddNew(int yr, int mt, DateTime dt, string iddep, string descr)
        {
            var table_paylists = MyData.DataSetKlons.PAYLISTS;
            var new_dr = table_paylists.NewPAYLISTSRow();
            new_dr.YR = yr;
            new_dr.MT = mt;
            new_dr.SNR = DataTasks.GetNextPayListNr(yr);
            new_dr.DT = dt;
            new_dr.DEP = iddep;
            new_dr.DESCR = descr.Nz();
            table_paylists.Rows.Add(new_dr);
        }

        public void MakeNewList()
        {
            if (MyData.DataSetKlons.PAYLIST_TEMPL.Count == 0)
            {
                MyMainForm.ShowWarning("Nav izveidotas sagataves.");
                return;
            }

            string er = "OK";

            var fm = new Form_PayListsNew();
            if (fm.ShowDialog(MyMainForm) != DialogResult.OK) return;

            ignoreColumnChangeEvent = true;

            if (fm.MakeEmpty)
            {
                AddNew(fm.Year, fm.Month, fm.PayDate, fm.IdDepartment, fm.Descr);
            }
            else if (fm.MakeAll)
            {
                er = DataTasks.MakePayListsFromTempl(fm.PayDate, fm.Year, fm.Month, true);
            }
            else
            {
                er = DataTasks.MakePayListFromTempl(fm.PayDate, fm.IdSh, fm.Year, fm.Month, true);
            }

            if (er != "OK")
            {
                MyMainForm.ShowWarning(er);
            }

            ignoreColumnChangeEvent = false;

            SaveData();
        }

        public void RecalcListA(bool fullrecalc)
        {
            if (bsLists.Count == 0 || bsLists.Current == null) return;
            if (!SaveBeforeProceed()) return;
            var dr = (bsLists.Current as DataRowView).Row as KlonsADataSet.PAYLISTSRow;
            ignoreColumnChangeEvent = true;
            DataTasks.FillPayListA(dr.ID, fullrecalc);
            if (!SaveData())
            {
                ignoreColumnChangeEvent = false;
                return;
            }
            DataTasks.FillPayListB(dr.ID);
            ignoreColumnChangeEvent = false;
            dgvLists.RefreshCurrent();
            SaveData();
        }

        public void RecalcRowA(bool fullrecalc)
        {
            if (bsRows.Count == 0 || bsRows.Current == null) return;
            if (!SaveBeforeProceed()) return;
            var dr = (bsRows.Current as DataRowView).Row as KlonsADataSet.PAYLISTS_RRow;
            ignoreColumnChangeEvent = true;
            DataTasks.FillPayListRowA(dr.ID, fullrecalc);
            if (!SaveData())
            {
                ignoreColumnChangeEvent = false;
                return;
            }
            DataTasks.FillPayListRowB(dr.ID);
            ignoreColumnChangeEvent = false;
            dgvRows.RefreshCurrent();
            SaveData();
        }

        public void RecalcListB()
        {
            if (bsLists.Count == 0 || bsLists.Current == null) return;
            if (!SaveBeforeProceed()) return;
            var dr = (bsLists.Current as DataRowView).Row as KlonsADataSet.PAYLISTSRow;
            ignoreColumnChangeEvent = true;
            DataTasks.FillPayListB(dr.ID);
            ignoreColumnChangeEvent = false;
            dgvLists.RefreshCurrent();
            SaveData();
        }

        public void RecalcRowB()
        {
            if (bsRows.Count == 0 || bsRows.Current == null) return;
            if (!SaveBeforeProceed()) return;
            var dr = (bsRows.Current as DataRowView).Row as KlonsADataSet.PAYLISTS_RRow;
            ignoreColumnChangeEvent = true;
            DataTasks.FillPayListRowB(dr.ID);
            ignoreColumnChangeEvent = false;
            dgvRows.RefreshCurrent();
            SaveData();
        }

        private void izveidotJaunuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeNewList();
        }

        private void pārrēķinātSarakstuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecalcListA(true);
        }

        private void pārrēķinātDarbiniekamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecalcRowA(true);
        }

        private void pārrēķinātSarakstuNemainotMaksājumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecalcListA(false);
        }

        private void pārrēķinātDarbiniekamNemainotMaksājumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecalcRowA(false);
        }

        private void myMcFlatComboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            var drv = e.ListItem as DataRowView;
            if (drv == null) return;
            var dr = drv.Row as KlonsADataSet.PAYLISTSRow;
            if (dr == null) return;
            var s = string.Format("{0:dd.MM.yyyy} {1} {2}", dr.DT, dr.SNR, dr.DESCR);
            e.Value = s;
        }

        public void ShowPayLists(bool b)
        {
            mySplitContainer1.Panel1Collapsed = !b;
            cbLists.Visible = !b;
            MyData.Settings.ShowPayLists = b;
            rādītPaslēptSarakstuTabuluToolStripMenuItem.Checked = b;
        }

        public void ShowPayDataPanel(bool b)
        {
            sgrPayRow.Visible = b;
            MyData.Settings.ShowPayDataPanel = b;
            rādītPaslēptDatuPaneliToolStripMenuItem.Checked = b;
        }

        private void rādītPaslēptSarakstuTabuluToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPayLists(mySplitContainer1.Panel1Collapsed);
        }

        private void rādītPaslēptDatuPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPayDataPanel(!sgrPayRow.Visible);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if(bNav.BindingSource == bsRows)
            {
                dgvRows.MoveToNewRow();
                return;
            }
            else
            {
                MakeNewList();
            }
        }

        private void dgvRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 && e.ColumnIndex < 0) return;
            if (e.ColumnIndex == dgcRowsR1.Index || e.ColumnIndex == dgcRowsR2.Index)
            {
                if (e.Value == null) return;
                float f = (float)e.Value * 100.0f;
                e.Value = f.ToString("0.00");
                e.FormattingApplied = true;
            }
        }


        private void sgrPayRow_ConvertingValueToDisplayString(object sender, DevAge.ComponentModel.ConvertingObjectEventArgs e)
        {
            if (bsRows.Count == 0 || bsRows.Current == null ||
                dgvRows.CurrentRow != null && dgvRows.CurrentRow.IsNewRow)
            {
                e.Value = "";
                e.ConvertingStatus = DevAge.ComponentModel.ConvertingStatus.Completed;
                return;
            }
            if (sender == grRowFName)
            {
                int idp = (int)e.Value;
                var ss = DataTasks.GetPersonNameAndPK(idp);
                e.Value = ss == null ? null : ss[0];
                e.ConvertingStatus = DevAge.ComponentModel.ConvertingStatus.Completed;
                return; 
            }
            if (sender == grRowLName)
            {
                int idp = (int)e.Value;
                var ss = DataTasks.GetPersonNameAndPK(idp);
                e.Value = ss == null ? null : ss[1];
                e.ConvertingStatus = DevAge.ComponentModel.ConvertingStatus.Completed;
                return;
            }
            if (sender == grRowPosition)
            {
                int idam = (int)e.Value;
                e.Value = DataTasks.GetPositionTitle(idam);
                e.ConvertingStatus = DevAge.ComponentModel.ConvertingStatus.Completed;
                return;
            }

        }

        private Report_PayList FillReport()
        {
            if (bsLists.Count == 0 || bsLists.Current == null) return null;
            if (bsRows.Count == 0) return null;
            if (dgvLists.Rows.Count == 0 || dgvLists.CurrentRow == null) return null;

            var drs_list = new List<KlonsADataSet.PAYLISTSRow>();
            if (dgvLists.SelectedRows.Count == 0)
            {
                drs_list.Add(bsLists.CurrentDataRow as KlonsADataSet.PAYLISTSRow);
            }
            else
            {
                for (int i = 0; i < dgvLists.SelectedRows.Count; i++)
                {
                    if (dgvLists.SelectedRows[i].IsNewRow) continue;
                    drs_list.Add((dgvLists.SelectedRows[i].DataBoundItem as DataRowView).Row as KlonsADataSet.PAYLISTSRow);
                }
            }

            drs_list = drs_list
                .OrderBy(d => d.SNR)
                .ToList();

            var rr = new Report_PayList();

            for (int i = 0; i < drs_list.Count; i++)
            {
                var dr_list = drs_list[i];
                var drs_rows = dr_list.GetPAYLISTS_RRows()
                    .Where(d => d.TPAY > 0.0M)
                    .OrderBy(d => d.SNR)
                    .ToArray();
                rr.AddToReport(dr_list, drs_rows);
            }

            return rr;
        }

        private void ShowReport1()
        {
            var rr = FillReport();
            if (rr == null) return;
            rr.ShowReport1();
        }

        private void ShowReport2()
        {
            var rr = FillReport();
            if (rr == null) return;
            rr.ShowReport2();
        }

        private void ShowReport3()
        {
            var rr = FillReport();
            if (rr == null) return;
            rr.GroupWithoutPositions();
            rr.ShowReport1();
        }

        private void ShowReport4()
        {
            var rr = FillReport();
            if (rr == null) return;
            rr.GroupWithoutPositions();
            rr.ShowReport2();
        }

        private void RenumRows()
        {
            for (int i = 0; i < bsRows.Count; i++)
            {
                var dr = (bsRows[i] as DataRowView).Row as KlonsADataSet.PAYLISTS_RRow;
                if (dr.SNR != (short)(i + 1)) dr.SNR = (short)(i + 1);
            }
        }


        private void miReport1_Click(object sender, EventArgs e)
        {
            ShowReport1();
        }

        private void miReport2_Click(object sender, EventArgs e)
        {
            ShowReport2();
        }

        private void miReport3_Click(object sender, EventArgs e)
        {
            ShowReport3();
        }

        private void miReport4_Click(object sender, EventArgs e)
        {
            ShowReport4();
        }

        private void miRepShList_Click(object sender, EventArgs e)
        {
            if (!SaveData()) return;
            if (bsRows.Current == null || dgvRows.CurrentRow == null ||
                dgvRows.CurrentRow.IsNewRow) return;

            var dr = bsRows.CurrentDataRow as KlonsADataSet.PAYLISTS_RRow;

            var ci = new PayListCalcInfo(true);
            ci.MakeReportB(dr);
            Form_PayCalc.Show(ci, Form_PayCalc.EReportType.SalarySheetList);
        }

        private void miRepSplitPay_Click(object sender, EventArgs e)
        {
            if (!SaveData()) return;
            if (bsRows.Current == null || dgvRows.CurrentRow == null ||
                dgvRows.CurrentRow.IsNewRow) return;

            var dr = bsRows.CurrentDataRow as KlonsADataSet.PAYLISTS_RRow;

            var ad2 = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.SP_PAY_MATCHLISTS_1XTableAdapter();
            var tab2 = ad2.GetDataBy_SP_PAY_MATCHLISTS_12(dr.IDAM, dr.PAY, dr.PAYLISTSRow.DT);
            var dr2 = tab2[0];
            int idam = dr.IDAM;
            var dt = dr.PAYLISTSRow.DT;

            var ci = new PayListCalcInfo(true);
            var ret = ci.Calc(dr, dr2);
            if (ret != "OK")
            {
                MyMainForm.ShowWarning(ret);
                return;
            }
            Form_PayCalc.Show(ci, Form_PayCalc.EReportType.Splitpay);
        }

        private void tsbRenum_Click(object sender, EventArgs e)
        {
            RenumRows();
        }
    }
}
