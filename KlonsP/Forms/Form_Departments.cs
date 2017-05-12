using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsP.DataSets;
using KlonsP.Classes;
using KlonsLIB.Forms;

namespace KlonsP.Forms
{
    public partial class Form_Departments : MyFormBaseP
    {
        public Form_Departments()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void Form_Departments_Load(object sender, EventArgs e)
        {

        }

        private void SelectCurrent()
        {
            if (dgvDepartments.CurrentRow == null || dgvDepartments.CurrentRow.IsNewRow) return;
            var dr = bsDepartments.CurrentDataRow;
            if (!dgvDepartments.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            int id = (int)dr["ID"];
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }


        public override bool SaveData()
        {
            if (!dgvDepartments.EndEditX()) return false;

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
            SetSaveButton(bsDepartments.HasChanges());
        }

        private void SetSaveButton(bool red)
        {
            bnDepartments.SetSaveButtonRed(red);
        }

        private void bnDepartments_SaveClicked(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvDepartments_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void bsDepartments_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvDepartments_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvDepartments.EndEdit()) return;
                dgvDepartments.MoveToNewRow();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                SetSelectedValue(null);
                e.Handled = true;
            }
        }

        private void dgvDepartments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null, true);
            }
        }

        public void DeleteCurrent()
        {
            bnDepartments.DeleteCurrent();
            SaveData();
        }

        private bool IsRow0(int rownr)
        {
            if (rownr == dgvDepartments.NewRowIndex) return false;
            var dr = dgvDepartments.GetDataRow(rownr) as KlonsPDataSet.CAT1Row;
            if (dr == null) return false;
            return dr.ID == 0;
        }

        private void dgvDepartments_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = e.Row.IsNewRow || IsRow0(e.Row.Index) || !AskCanDelete();
        }

        private void bnDepartments_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = IsRow0(bsDepartments.Position) || !AskCanDelete();
        }

        private void dgvDepartments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDepartments.CurrentRow == null || dgvDepartments.CurrentRow.IsNewRow) return;
            if (e.ColumnIndex == dgcCode.Index)
            {
                SelectCurrent();
            }
        }

        private void dgvDepartments_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dgvDepartments.NewRowIndex) return;
            if (IsRow0(e.RowIndex))
                e.Cancel = true;
        }
    }
}
