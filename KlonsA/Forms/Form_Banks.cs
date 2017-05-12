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
using KlonsA.DataSets;

namespace KlonsA.Forms
{
    public partial class Form_Banks : MyFormBaseA
    {
        public Form_Banks()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void Form_Banks_Load(object sender, EventArgs e)
        {

        }

        private void SelectCurrent()
        {
            if (dgvBanks.CurrentRow == null || dgvBanks.CurrentRow.IsNewRow) return;
            var dr = bsBanks.CurrentDataRow;
            if (!dgvBanks.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            int id = (int)dr["ID"];
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }

        private void dgvBanks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBanks.CurrentRow == null || dgvBanks.CurrentRow.IsNewRow) return;
            if (e.ColumnIndex == dgcSID.Index)
            {
                SelectCurrent();
            }
        }

        public void DeleteCurrent()
        {
            bnavBanks.DeleteCurrent();
            SaveData();
        }

        private void dgvBanks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                DeleteCurrent();
                e.Handled = true;
            }
        }

        private void dgvBanks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null);
                e.Handled = true;
            }
        }

        private void bnavBanks_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvBanks_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
            {
                e.Cancel = true;
            }
        }

        private void SetSaveButton(bool red)
        {
            bnavBanks.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvBanks.EndEditX()) return false;
            var ret = bsBanks.SaveTable();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsBanks.HasChanges());
        }

        private void dgvBanks_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
            CheckSave();
        }

        private void bsBanks_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void bsBanks_MyBeforeRowInsert(MyRowUpdateEventArgs e)
        {
            var dr = e.DataRow as KlonsA.DataSets.KlonsADataSet.BANKSRow;
            dr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_BANKS_ID();
        }

    }
}
