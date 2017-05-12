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
    public partial class Form_CatD : MyFormBaseP
    {
        public Form_CatD()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void Form_CatD_Load(object sender, EventArgs e)
        {

        }

        private void SelectCurrent()
        {
            if (dgvCatD.CurrentRow == null || dgvCatD.CurrentRow.IsNewRow) return;
            var dr = bsCatD.CurrentDataRow;
            if (!dgvCatD.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            int id = (int)dr["ID"];
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }


        public override bool SaveData()
        {
            if (!dgvCatD.EndEditX()) return false;

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
            SetSaveButton(bsCatD.HasChanges());
        }

        private void SetSaveButton(bool red)
        {
            bnCatd.SetSaveButtonRed(red);
        }

        private void bnCatd_SaveClicked(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvCatD_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void bsCatD_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvCatD_MyKeyDown(object sender, KeyEventArgs e)
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
                if (!dgvCatD.EndEdit()) return;
                dgvCatD.MoveToNewRow();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                SetSelectedValue(null);
                e.Handled = true;
            }
        }

        private void dgvCatD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null, true);
            }
        }

        public void DeleteCurrent()
        {
            bnCatd.DeleteCurrent();
            SaveData();
        }

        private bool IsRow0(int rownr)
        {
            if (rownr == dgvCatD.NewRowIndex) return false;
            var dr = dgvCatD.GetDataRow(rownr) as KlonsPDataSet.CATDRow;
            if (dr == null) return false;
            return dr.ID == 0;
        }

        private void dgvCatD_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = e.Row.IsNewRow || IsRow0(bsCatD.Position) || !AskCanDelete();
        }

        private void bnCatd_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = IsRow0(bsCatD.Position) || !AskCanDelete();
        }

        private void dgvCatD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCatD.CurrentRow == null || dgvCatD.CurrentRow.IsNewRow) return;
            if (e.ColumnIndex == dgcCode.Index)
            {
                SelectCurrent();
            }
        }

        private void dgvCatD_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dgvCatD.NewRowIndex) return;
            if (IsRow0(e.RowIndex))
                e.Cancel = true;
        }
    }
}
