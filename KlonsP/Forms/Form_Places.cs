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
    public partial class Form_Places : MyFormBaseP
    {
        public Form_Places()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void Form_Places_Load(object sender, EventArgs e)
        {

        }

        private void SelectCurrent()
        {
            if (dgvPlaces.CurrentRow == null || dgvPlaces.CurrentRow.IsNewRow) return;
            var dr = bsPlaces.CurrentDataRow;
            if (!dgvPlaces.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            int id = (int)dr["ID"];
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }


        public override bool SaveData()
        {
            if (!dgvPlaces.EndEditX()) return false;

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
            SetSaveButton(bsPlaces.HasChanges());
        }

        private void SetSaveButton(bool red)
        {
            bnPlaces.SetSaveButtonRed(red);
        }

        private void bnPlaces_SaveClicked(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvPlaces_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void bsPlaces_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvPlaces_MyKeyDown(object sender, KeyEventArgs e)
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
                if (!dgvPlaces.EndEdit()) return;
                dgvPlaces.MoveToNewRow();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                SetSelectedValue(null);
                e.Handled = true;
            }
        }

        private void dgvPlaces_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null, true);
            }
        }

        public void DeleteCurrent()
        {
            bnPlaces.DeleteCurrent();
            SaveData();
        }

        private bool IsRow0(int rownr)
        {
            if (rownr == dgvPlaces.NewRowIndex) return false;
            var dr = dgvPlaces.GetDataRow(rownr) as KlonsPDataSet.PLACESRow;
            if (dr == null) return false;
            return dr.ID == 0;
        }

        private void dgvPlaces_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = e.Row.IsNewRow || IsRow0(e.Row.Index) || !AskCanDelete();
        }

        private void bnPlaces_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = IsRow0(bsPlaces.Position) || !AskCanDelete();
        }

        private void dgvPlaces_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPlaces.CurrentRow == null || dgvPlaces.CurrentRow.IsNewRow) return;
            if (e.ColumnIndex == dgcCode.Index)
            {
                SelectCurrent();
            }
        }

        private void dgvPlaces_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dgvPlaces.NewRowIndex) return;
            if (IsRow0(e.RowIndex))
                e.Cancel = true;
        }
    }
}
