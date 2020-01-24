using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using KlonsA.DataSets;
using DataObjectsA;

namespace KlonsA.Forms
{
    public partial class Form_FpPayLists : MyFormBaseA
    {
        public Form_FpPayLists()
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

        private void Form_FpPayLists_Load(object sender, EventArgs e)
        {
            dgcRowsTaxTP.DataSource = SomeDataDefs.FPMaksNodVeids;
            dgcRowsTaxTP.DisplayMember = "Val";
            dgcRowsTaxTP.ValueMember = "Key";

            dgcRowsSIRateTP.DataSource = SomeDataDefs.FPMaksSILikmesVeids;
            dgcRowsSIRateTP.DisplayMember = "Val";
            dgcRowsSIRateTP.ValueMember = "Key";

            ShowPayLists(MyData.Settings.ShowFpPayLists);
            ShowPayDataPanel(MyData.Settings.ShowFpPayDataPanel);
            tslPeriod.Text = DataLoader.GetPeriodStr();
            MyData.DataSetKlons.FP_PAYLISTS_R.ColumnChanged += FP_PAYLISTS_R_ColumnChanged;
            rwSAITitle.Expanded = false;
            CheckEnableRows();
            CheckSave();
        }

        private void Form_FpPayLists_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlons.FP_PAYLISTS_R.ColumnChanged -= FP_PAYLISTS_R_ColumnChanged;
        }


        private bool ignoreColumnChangeEvent = false;
        private bool InPAYLISTS_R_ColumnChanged = false;

        private void FP_PAYLISTS_R_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (ignoreColumnChangeEvent) return;
            if (InPAYLISTS_R_ColumnChanged) return;
            InPAYLISTS_R_ColumnChanged = true;
            FP_PAYLISTS_R_ColumnChangedA(e);
            InPAYLISTS_R_ColumnChanged = false;
        }


        public void GetRates(DateTime dt, int rtp, out decimal riin,
            out decimal rsidd, out decimal rsidn)
        {
            riin = 0.0M;
            rsidd = 0.0M;
            rsidn = 0.0M;

            var dr = DataTasks.GetRates(dt);
            if (dr == null) return;
            riin = dr.IIN_LIKME;
            switch (rtp)
            {
                case 0:
                    rsidd = dr.SIDD_PAMATLIKME;
                    rsidn = dr.SIDN_PAMATLIKME;
                    break;
                case 1:
                    rsidd = dr.SIDD_PENS;
                    rsidn = dr.SIDN_PENS;
                    break;
                case 2:
                    rsidd = dr.SIDD_IZDPENS;
                    rsidn = dr.SIDN_IZDPENS;
                    break;
                case 3:
                    rsidd = dr.SIDD_IESLODZ;
                    rsidn = dr.SIDN_IESLODZ;
                    break;
                case 4:
                    rsidd = dr.SIDD_IESLODZ_PENS;
                    rsidn = dr.SIDN_IESLODZ_PENS;
                    break;
            }

        }

        public void FullRecalc(KlonsADataSet.FP_PAYLISTS_RRow dr, bool useiinrate = false)
        {
            decimal riin = 0M, rsidd = 0M, rsidn = 0M;
            decimal pay = 0M, sidd = 0M, sidn = 0M, iinex = 0m;
            decimal iinfrom = 0M, iin = 0M, cash = 0M;

            GetRates(dr.PAYDATE, dr.SIRATETP, out riin, out rsidd, out rsidn);
            if (useiinrate || dr.IIN_RATE != 0.0M)
                riin = dr.IIN_RATE;
            pay = dr.PAY0;
            if (dr.TAX_TP == 0)
            {
                sidd = Math.Round(pay * rsidd / 100.0M, 2);
                sidn = Math.Round(pay * rsidn / 100.0M, 2);
            }
            if (dr.TAX_TP != 2)
            {
                if (dr.IINEX_PERC == 0.0M)
                    iinex = dr.IINEX;
                else
                    iinex = Math.Round(dr.IINEX_PERC / 100.0M * pay, 2);
                iinfrom = pay - sidn - iinex;
                iin = Math.Round(iinfrom * riin / 100.0M, 2);
            }
            cash = pay - sidn - iin;

            if (dr.SIDD == sidd && dr.SIDN == sidn && dr.IINEX == iinex &&
                dr.IIN == iin && dr.CASH == cash) return;

            dr.BeginEdit();
            if (dr.SIRATEDD != rsidd) dr.SIRATEDD = rsidd;
            if (dr.SIRATEDN != rsidn) dr.SIRATEDN = rsidn;
            if (dr.IIN_RATE != riin) dr.IIN_RATE = riin;
            if (dr.SIDD != sidd) dr.SIDD = sidd;
            if (dr.SIDN != sidd) dr.SIDN = sidn;
            if (dr.IINEX != iinex) dr.IINEX = iinex;
            if (dr.IIN_FROM != iinfrom) dr.IIN_FROM = iinfrom;
            if (dr.IIN != iin) dr.IIN = iin;
            if (dr.CASH != cash) dr.CASH = cash;
            dr.EndEdit();
            dgvList.RefreshCurrent();
        }

        private void FP_PAYLISTS_R_ColumnChangedA(DataColumnChangeEventArgs e)
        {
            var dr = e.Row as KlonsADataSet.FP_PAYLISTS_RRow;
            var table = MyData.DataSetKlons.FP_PAYLISTS_R;

            bool dorecalc = false;
            bool userate = false;
            decimal iinexperc = 0.0M;
            decimal iinrate = 23.0M;

            if (e.Column == table.INCOME_IDColumn)
            {
                if (dr.INCOME_ID == "1003")
                {
                    iinexperc = 15.0M;
                }
                else if (!string.IsNullOrEmpty(dr.INCOME_ID) && dr.INCOME_ID.StartsWith("3"))
                {
                    iinexperc = 0.0M;
                    iinrate = 0.0M;
                }
                else if (dr.INCOME_ID == "1010")
                {
                    iinexperc = 50.0M;
                    iinrate = 10.0M;
                }
                else
                {
                    iinexperc = 0.0M;
                    dr.IINEX = 0.0M;
                }

                if (dr.IINEX_PERC != iinexperc)
                {
                    dr.IINEX_PERC = iinexperc;
                    dorecalc = true;
                }
                if (dr.IIN_RATE != iinrate)
                {
                    dr.IIN_RATE = iinrate;
                    dorecalc = true;
                    userate = true;
                }

            }

            if (e.Column == table.IINEX_PERCColumn)
            {
                if (dr.IINEX_PERC == 0.0M)
                {
                    dr.IINEX = 0.0M;
                    dorecalc = true;
                }
            }

            if (e.Column == table.IIN_RATEColumn)
            {
                dorecalc = true;
                userate = true;
            }

            if (dorecalc ||
                e.Column == table.PAY0Column ||
                e.Column == table.DATE1Column ||
                e.Column == table.SIRATETPColumn ||
                e.Column == table.TAX_TPColumn ||
                e.Column == table.IINEX_PERCColumn ||
                e.Column == table.IINEXColumn)
            {
                FullRecalc(dr, userate);
                return;
            }
        }

        private void SetupToolStrips()
        {
            InsertInToolStrip(toolStrip1, cbLists, 2);
        }

        private void MakeGrid()
        {
            sgrRow.MakeGrid();
            sgrRow.LinkGrid();
        }

        private void dgvList_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcListPayDate.Index)
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

        private void dgvRows_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcRowsPayDate.Index ||
                e.ColumnIndex == dgcRowsDate1.Index ||
                e.ColumnIndex == dgcRowsDate2.Index)
            {
                if (!Utils.DGVParseDateCell(e))
                {
                    e.Value = null;
                    e.ParsingApplied = true;
                    return;
                }
            }
        }

        private void dgvList_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[dgcListYR.Index].Value = DataLoader.LoadedDT2.Year;
            e.Row.Cells[dgcListMT.Index].Value = DataLoader.LoadedDT2.Month;
            e.Row.Cells[dgcListSNR.Index].Value = DataTasks.GetNextFpPayListNr(DataLoader.LoadedDT2.Year);
            e.Row.Cells[dgcListPayDate.Index].Value = DateTime.Today;
        }

        private void dgvRows_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[dgcRowsSNR.Index].Value = bsRows.Count;
            var dr_l = bsList.CurrentDataRow as KlonsADataSet.FP_PAYLISTSRow;
            e.Row.Cells[dgcRowsPayDate.Index].Value = dr_l.PAYDATE;
            var dt = new DateTime(dr_l.YR, dr_l.MT, 1);
            e.Row.Cells[dgcRowsDate1.Index].Value = dt;
            e.Row.Cells[dgcRowsDate2.Index].Value = dt.LastDayOfMonth();
        }

        private void dgvList_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvRows_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvList.CurrentCell == null) return;
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvList.EndEdit()) return;
                dgvList.MoveToNewRow();
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

        private void dgvRows_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow ||
                dgvRows.CurrentCell == null) return;
            int colnr = dgvRows.CurrentCell.ColumnIndex;

            if (e.KeyCode == Keys.F5)
            {
                if (colnr != dgcRowsIDP.Index) return;
                GetIDPFromDialog();
                e.Handled = true;
                return;
            }

        }

        private void dgvRows_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow ||
                dgvRows.CurrentCell == null) return;
            int colnr = dgvRows.CurrentCell.ColumnIndex;
            if (colnr != e.ColumnIndex) return;

            if (colnr == dgcRowsIDP.Index)
            {
                GetIDPFromDialog();
            }
        }

        public void GetIDPFromDialog()
        {
            if (bsRows.Count == 0 || bsRows.Current == null) return;
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var fm = new Form_FizPersons();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            var dr = (dgvRows.CurrentRow.DataBoundItem as DataRowView).Row as KlonsADataSet.FP_PAYLISTS_RRow;
            if (dgvRows.CurrentCell != null)
            {
                try
                {
                    dgvRows.BeginEdit(false);
                    var c = dgvRows.EditingControl as DataGridViewComboBoxEditingControl;
                    c.SelectedValue = fm.OnSelectedValueInt;
                    dgvRows.EndEdit();
                }
                catch (Exception) { }
            }
        }


        private void cbLists_Format(object sender, ListControlConvertEventArgs e)
        {
            var drv = e.ListItem as DataRowView;
            if (drv == null) return;
            var dr = drv.Row as KlonsADataSet.FP_PAYLISTSRow;
            if (dr == null) return;
            if (dr.RowState == DataRowState.Detached || dr.RowState == DataRowState.Deleted)
            {
                e.Value = "?";
                return;
            }
            var s = string.Format("{0:dd.MM.yyyy} {1} {2}", dr.PAYDATE, dr.SNR, dr.DESCR);
            e.Value = s;
        }

        public void ShowPayLists(bool b)
        {
            splitContainer1.Panel1Collapsed = !b;
            cbLists.Visible = !b;
            MyData.Settings.ShowFpPayLists = b;
            miShowList.Checked = b;
        }

        public void ShowPayDataPanel(bool b)
        {
            sgrRow.Visible = b;
            MyData.Settings.ShowFpPayDataPanel = b;
            miShowPanel.Checked = b;
        }


        private void CheckEnableRows()
        {
            dgvRows.Enabled = bsList.Count > 0 && dgvList.CurrentRow != null &&
                               !dgvList.CurrentRow.IsNewRow;
            CheckEnableSGR();
        }

        private void CheckEnableSGR()
        {
            sgrRow.Enabled = dgvRows.Enabled && bsRows.Count > 0 && 
                dgvRows.CurrentRow != null && !dgvRows.CurrentRow.IsNewRow;
        }

        private void dgvList_CurrentCellChanged(object sender, EventArgs e)
        {
            CheckEnableRows();
        }

        private void dgvRows_CurrentCellChanged(object sender, EventArgs e)
        {
            CheckEnableSGR();
        }

        private void dgvList_Enter(object sender, EventArgs e)
        {
            bnavList.BindingSource = bsList;
            bnavList.DataGrid = dgvList;
            tslGrid.Text = "Saraksti:";
        }

        private void dgvRows_Enter(object sender, EventArgs e)
        {
            bnavList.BindingSource = bsRows;
            bnavList.DataGrid = dgvRows;
            tslGrid.Text = "Rindas:";
        }


        public void DeleteCurrent()
        {
            bnavList.DeleteCurrent();
            SaveData();
        }

        public override bool SaveData()
        {
            if (!dgvList.EndEditX()) return false;
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
                Form_Error.ShowException(e, "Neizdevās saglabāt izmaiņas.");
                return false;
            }
            return true;
        }

        private void SetSaveButton(bool red)
        {
            bnavList.SetSaveButton(tsbSave, red);
        }

        private bool HasChanges()
        {
            return myAdapterManager1.HasChanges();
        }

        private void CheckSave()
        {
            SetSaveButton(HasChanges());
        }

        private void dgvList_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bsList_ListChanged(object sender, ListChangedEventArgs e)
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

        private void bnavList_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void miShowList_Click(object sender, EventArgs e)
        {
            ShowPayLists(splitContainer1.Panel1Collapsed);
        }

        private void miShowPanel_Click(object sender, EventArgs e)
        {
            ShowPayDataPanel(!sgrRow.Visible);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void sgrRow_ConvertingValueToDisplayString(object sender, DevAge.ComponentModel.ConvertingObjectEventArgs e)
        {
            if (bsRows.Count == 0 || bsRows.Current == null ||
                dgvRows.CurrentRow != null && dgvRows.CurrentRow.IsNewRow)
            {
                e.Value = "";
                e.ConvertingStatus = DevAge.ComponentModel.ConvertingStatus.Completed;
                return;
            }
            if (sender == rwName)
            {
                int idp = (int)e.Value;
                var ss = DataTasks.GetFPPersonNameAndPK(idp);
                e.Value = ss == null ? null : ss[0] + " " + ss[1];
                e.ConvertingStatus = DevAge.ComponentModel.ConvertingStatus.Completed;
                return;
            }
            if (sender == rwPK)
            {
                int idp = (int)e.Value;
                var ss = DataTasks.GetFPPersonNameAndPK(idp);
                e.Value = ss == null ? "" : ss.GetValue(2);
                e.ConvertingStatus = DevAge.ComponentModel.ConvertingStatus.Completed;
                return;
            }
            if (sender == rwIncomeStr)
            {
                string incid = e.Value.AsString();
                e.Value = MyData.DataSetKlons.INCOME_CODES.FindByID(incid)?.DESCR;
                e.ConvertingStatus = DevAge.ComponentModel.ConvertingStatus.Completed;
                return;
            }
        }

        private void dgvRows_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var o = dgvRows[dgcRowsIDP.Index, e.RowIndex].Value;
            if (o == null || o == DBNull.Value) return;
            dgvRows.EndEditX();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            bnavList.DataGrid.MoveToNewRow();
        }

        private decimal titleSAIDD = decimal.MinValue;
        private decimal titleSAIDN = decimal.MinValue;
        private decimal titleIIN = decimal.MinValue;

        private void UpdateTitleData()
        {
            if (titleSAIDD != fpPaylistsRowData1._SIDD ||
                titleSAIDN != fpPaylistsRowData1._SIDN)
            {
                titleSAIDD = fpPaylistsRowData1._SIDD;
                titleSAIDN = fpPaylistsRowData1._SIDN;
                rwSAITitle.ValueStr = string.Format("{0}; {1}", titleSAIDD, titleSAIDN);
            }

            if (titleIIN != fpPaylistsRowData1._IIN)
            {
                titleIIN = fpPaylistsRowData1._IIN;
                rwIINTitle2.ValueStr = string.Format("{0:N2}", titleIIN);
            }

        }

        private void sgrRow_ValueChanged(object sender, EventArgs e)
        {
            UpdateTitleData();
        }

    }
}
