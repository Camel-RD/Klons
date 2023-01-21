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
using KlonsFM.UI;

namespace KlonsFM.FormsM
{
    public partial class FormM_TransactionType : MyFormBaseF
    {
        public FormM_TransactionType()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void FormM_TransactionType_Load(object sender, EventArgs e)
        {

        }

        public static int? GetTransactionTypeId(int? idstore)
        {
            var fm = new FormM_TransactionType();
            if (idstore.HasValue)
                fm.FindDocType(idstore.Value);
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedValueInt;
        }

        public void FindDocType(int id)
        {
            for (int i = 0; i < bsRows.Count; i++)
            {
                var dr = (bsRows[i] as DataRowView).Row as KlonsMDataSet.M_TRANSACTIONTYPERow;
                if (dr.ID == id)
                {
                    bsRows.Position = i;
                    return;
                }
            }
        }

        private void SelectCurrent()
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var dr = (bsRows.Current as DataRowView)?.Row as KlonsMDataSet.M_TRANSACTIONTYPERow;
            if (!dgvRows.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            int id = dr.ID;
            //SelectedCode = dr.CODE;
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
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

        private void CheckSave()
        {
            SetSaveButton(bsRows.HasChanges());
        }

        private void SetSaveButton(bool red)
        {
            bNav.SetSaveButtonRed(red);
        }

        public void DeleteCurrent()
        {
            bNav.DeleteCurrent();
            SaveData();
        }

        private void dgvRows_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvRows.CurrentCell == null) return;
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
                if (!dgvRows.EndEdit()) return;
                dgvRows.MoveToNewRow();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                //SelectedCode = null;
                SetSelectedValue(null, true);
                e.Handled = true;
            }
        }

        private void dgvRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                //SelectedCode = null;
                SetSelectedValue(null, true);
            }
        }

        private void dgvRows_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            if (e.ColumnIndex == dgcName.Index)
            {
                SelectCurrent();
                return;
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvRows_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void bsRows_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvRows_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = e.Row.IsNewRow || !AskCanDelete();
        }

        private void bNav_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

    }
}
