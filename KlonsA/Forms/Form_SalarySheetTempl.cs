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

namespace KlonsA.Forms
{
    public partial class Form_SalarySheetTempl : MyFormBaseA
    {
        public Form_SalarySheetTempl()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void Form_SalarySheetTempl_Load(object sender, EventArgs e)
        {
            MyData.DataSetKlons.SALARY_SHEET_TEMPL_R.ColumnChanged += SALARY_SHEET_TEMPL_R_ColumnChanged;

            CheckEnableGrid();
            CheckSave();
        }

        private void Form_SalarySheetTempl_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlons.SALARY_SHEET_TEMPL_R.ColumnChanged -= SALARY_SHEET_TEMPL_R_ColumnChanged;
        }

        private void SALARY_SHEET_TEMPL_R_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if(e.Column == MyData.DataSetKlons.SALARY_SHEET_TEMPL_R.IDPColumn)
            {
                if (e.ProposedValue == null || e.ProposedValue == DBNull.Value) return;
                int idp = (int)e.ProposedValue;
                var drp = MyData.DataSetKlons.PERSONS.FindByID(idp);
                e.Row["IDAM"] = drp.GetPOSITIONSRows()[0].ID;
                e.Row.EndEdit();
            }
        }

        private void SelectCurrent()
        {
            if (dgvShL.CurrentRow == null || dgvShL.CurrentRow.IsNewRow) return;
            var dr = bsShL.CurrentDataRow as KlonsA.DataSets.KlonsADataSet.SALARY_SHEET_TEMPLRow;
            if (!dgvShL.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            if (!this.IsMyDialog) return;
            SetSelectedValue(dr.ID);
        }


        private void dgvShL_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void dgvShR_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void bnavSh_ItemDeleting(object sender, CancelEventArgs e)
        {
            if (!AskCanDelete()) e.Cancel = true;
        }

        private void dgvShL_Enter(object sender, EventArgs e)
        {
            bnavSh.BindingSource = bsShL;
            bnavSh.DataGrid = dgvShL;
            toolStripLabel1.Text = "Saraksti:";
        }

        private void dgvShR_Enter(object sender, EventArgs e)
        {
            bnavSh.BindingSource = bsShR;
            bnavSh.DataGrid = dgvShR;
            toolStripLabel1.Text = "Saraksta rindas:";
        }

        public void DeleteCurrent()
        {
            bnavSh.DeleteCurrent();
            SaveData();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void dgvShL_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvShL.CurrentRow == null || dgvShL.CurrentRow.IsNewRow ||
                dgvShL.CurrentCell == null) return;
            int colnr = dgvShL.CurrentCell.ColumnIndex;

            if (e.KeyCode == Keys.F5)
            {
                if (colnr != dgcShLDep.Index) return;
                GetIDDepFromDialog();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvShL.EndEdit()) return;
                dgvShL.MoveToNewRow();
                e.Handled = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }
        }

        private void dgvShR_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvShR.CurrentRow == null || dgvShR.CurrentRow.IsNewRow ||
                dgvShR.CurrentCell == null) return;
            int colnr = dgvShR.CurrentCell.ColumnIndex;

            if (e.KeyCode == Keys.F5)
            {
                if (colnr != dgcShRIdP.Index && colnr != dgcShRIdAM.Index) return;
                GetIDPFromDialog();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvShR.EndEdit()) return;
                dgvShR.MoveToNewRow();
                e.Handled = true;
                return;
            }
        }

        private void dgvShL_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvShL.CurrentRow == null || dgvShL.CurrentRow.IsNewRow ||
                dgvShL.CurrentCell == null) return;
            int colnr = dgvShL.CurrentCell.ColumnIndex;
            if (colnr != e.ColumnIndex) return;

            if (colnr == dgcShLDep.Index)
            {
                GetIDDepFromDialog();
            }
            if (colnr == dgcShLCode.Index || colnr == dgcShLSnr.Index)
            {
                SelectCurrent();
            }
        }

        private void dgvShR_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvShR.CurrentRow == null || dgvShR.CurrentRow.IsNewRow ||
                dgvShR.CurrentCell == null) return;
            int colnr = dgvShR.CurrentCell.ColumnIndex;
            if (colnr != dgcShRIdP.Index && colnr != dgcShRIdAM.Index) return;
            GetIDPFromDialog();
        }

        public void GetIDPFromDialog()
        {
            if (bsShR.Count == 0 || bsShR.Current == null) return;
            if (dgvShR.CurrentRow == null || dgvShR.CurrentRow.IsNewRow) return;
            var fm = new Form_Persons();
            fm.WhatToSelect = Form_Persons.EWhatToSelect.Both;
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            var dr = (dgvShR.CurrentRow.DataBoundItem as DataRowView).Row as KlonsADataSet.SALARY_SHEET_TEMPL_RRow;
            if (dgvShR.CurrentCell != null)
            {
                try
                {
                    if (dgvShR.CurrentCell.OwningColumn == dgcShRIdP)
                    {
                        dgvShR.BeginEdit(false);
                        var c = dgvShR.EditingControl as DataGridViewComboBoxEditingControl;
                        c.SelectedValue = fm.SelectedIDP;
                        dgvShR.EndEdit();

                        dr.IDAM = fm.SelectedIDAM;
                    }
                    if (dgvShR.CurrentCell.OwningColumn == dgcShRIdAM)
                    {
                        dgvShR.EndEdit();

                        dr.IDP = fm.SelectedIDP;

                        dgvShR.BeginEdit(false);
                        var c = dgvShR.EditingControl as DataGridViewComboBoxEditingControl;
                        c.SelectedValue = fm.SelectedIDAM;
                        dgvShR.EndEdit();
                    }
                }
                catch (Exception) { }
            }
        }

        public void GetIDDepFromDialog()
        {
            if (bsShL.Count == 0 || bsShL.Current == null) return;
            if (dgvShL.CurrentRow == null || dgvShL.CurrentRow.IsNewRow) return;
            var fm = new Form_Departments();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            var dr = (dgvShL.CurrentRow.DataBoundItem as DataRowView).Row as KlonsADataSet.SALARY_SHEET_TEMPLRow;
            if (dgvShL.CurrentCell != null)
            {
                try
                {
                    dgvShL.BeginEdit(false);
                    var c = dgvShL.EditingControl as DataGridViewComboBoxEditingControl;
                    c.SelectedValue = fm.SelectedValue;
                    dgvShL.EndEdit();
                }
                catch (Exception) { }
            }
        }

        private void CheckEnableGrid()
        {
            dgvShR.Enabled = bsShL.Count > 0 && dgvShL.CurrentRow != null && !dgvShL.CurrentRow.IsNewRow;
        }

        private void dgvShL_CurrentCellChanged(object sender, EventArgs e)
        {
            CheckEnableGrid();
        }

        public override bool SaveData()
        {
            if (!dgvShL.EndEditX()) return false;
            if (!dgvShR.EndEditX()) return false;

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
            bnavSh.SetSaveButton(tsbSave, red);
        }
        private bool HasChanges()
        {
            return bsShL.HasChanges() || bsShR.HasChanges();
        }

        private void CheckSave()
        {
            SetSaveButton(HasChanges());
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvShL_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void dgvShR_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == dgcShRIdAM.Index)
            {
                var val_idp = dgvShR[dgcShRIdP.Index, e.RowIndex].Value;
                if (val_idp == null || val_idp == DBNull.Value)
                {
                    e.Cancel = true;
                    return;
                }
                var c0 = dgvShR[e.ColumnIndex, e.RowIndex];
                var c = c0 as DataGridViewComboBoxCell;
                if (c == null) return;
                int idp = (int)val_idp;
                bsAmatiF.Filter = "USED=1 and IDP=" + idp;
                c.DataSource = bsAmatiF;
            }
        }

        private void dgvShR_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgcShRIdAM.Index)
            {
                var c = dgvShR[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                c.DataSource = bsAmati;
            }
        }

        private void dgvShL_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[dgcShLSnr.Index].Value = dgvShL.Rows.Count;
        }

        private void dgvShR_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[dgcShRSNR.Index].Value = dgvShR.Rows.Count;
        }

        private void bsShL_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void bsShR_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (e.ListChangedType == ListChangedType.Reset) return;
            CheckSave();
        }

        private void RenumRows()
        {
            for (int i = 0; i < bsShR.Count; i++)
            {
                var dr = (bsShR[i] as DataRowView).Row as KlonsADataSet.SALARY_SHEET_TEMPL_RRow;
                if (dr.SNR != (short)(i + 1)) dr.SNR = (short)(i + 1);
            }
        }

        private void tsbRenum_Click(object sender, EventArgs e)
        {
            RenumRows();
        }
    }
}
