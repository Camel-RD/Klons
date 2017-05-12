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
    public partial class Form_PastData : MyFormBaseA
    {
        public Form_PastData()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            InsertInToolStrip(toolStrip1, tbFilter, -1);
            bsPrevMonths.Fill();
        }

        private void Form_PastData_Load(object sender, EventArgs e)
        {
            CheckSave();
            MyData.DataSetKlons.PASTDATA.ColumnChanged += PASTDATA_ColumnChanged;
        }
        private void Form_PastData_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlons.PASTDATA.ColumnChanged -= PASTDATA_ColumnChanged;
        }

        private int? LastIDP = null;
        private int? LastYR = null;

        private void PASTDATA_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column != MyData.DataSetKlons.PASTDATA.IDPColumn &&
                e.Column != MyData.DataSetKlons.PASTDATA.YRColumn) return;
            var dr = e.Row as KlonsADataSet.PASTDATARow;
            if (dr.RowState == DataRowState.Detached) return;
            LastIDP = dr.IDP;
            LastYR = dr.YR;
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                string s = tbFilter.Text;
                if (s == "")
                {
                    bsPrevMonths.RemoveFilter();
                }
                else
                {
                    bsPrevMonths.Filter = string.Format("ZNAME LIKE '*{0}*'", s);
                }
            }
        }

        public void GetIDPFromDialog()
        {
            if (bsPrevMonths.Count == 0 || bsPrevMonths.Current == null) return;
            if (dgvPrevMonths.CurrentRow == null || dgvPrevMonths.CurrentRow.IsNewRow) return;
            var fm = new Form_Persons();
            fm.WhatToSelect = Form_Persons.EWhatToSelect.Person;
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            var dr = (dgvPrevMonths.CurrentRow.DataBoundItem as DataRowView).Row as KlonsADataSet.PASTDATARow;
            if (dgvPrevMonths.CurrentCell != null)
            {
                try
                {
                    dgvPrevMonths.BeginEdit(false);
                    var c = dgvPrevMonths.EditingControl as DataGridViewComboBoxEditingControl;
                    c.SelectedValue = fm.SelectedValueInt;
                    dgvPrevMonths.EndEdit();
                }
                catch (Exception) { }
            }
        }

        private void dgvPrevMonths_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPrevMonths.CurrentCell == null) return;
            if (e.RowIndex == -1 || e.RowIndex == dgvPrevMonths.NewRowIndex) return;
            if (e.ColumnIndex == dgcIDP.Index)
            {
                GetIDPFromDialog();
                return;
            }

        }

        private void dgvPrevMonths_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvPrevMonths.CurrentCell == null) return;
            if (e.KeyCode == Keys.F5)
            {
                if (dgvPrevMonths.CurrentCell.ColumnIndex == dgcIDP.Index)
                {
                    GetIDPFromDialog();
                    e.Handled = true;
                    return;
                }
            }
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvPrevMonths.EndEdit()) return;
                dgvPrevMonths.MoveToNewRow();
                e.Handled = true;
                return;
            }
        }


        private void bnavPrevMonths_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvPrevMonths_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void SetSaveButton(bool red)
        {
            bnavPrevMonths.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvPrevMonths.EndEditX()) return false;

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

        private void CheckSave()
        {
            SetSaveButton(bsPrevMonths.HasChanges());
        }


        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvPrevMonths_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void bsPrevMonths_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvPrevMonths_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            object mt = dgvPrevMonths[dgcMT.Index, e.RowIndex]?.Value;
            if (mt == null || (int)mt < 1 || (int)mt > 12)
            {
                MyMainForm.ShowWarning("Nekorekts mēnesis.");
                e.Cancel = true;
                return;
            }
        }

        public void DeleteCurrent()
        {
            bnavPrevMonths.DeleteCurrent();
            SaveData();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void dgvPrevMonths_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (LastIDP == null) return;
            e.Row.Cells[dgcIDP.Index].Value = LastIDP.Value;
            e.Row.Cells[dgcYR.Index].Value = LastYR.Value;
        }

    }
}
