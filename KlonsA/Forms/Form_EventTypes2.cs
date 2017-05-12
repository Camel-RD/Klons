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
using KlonsA.DataSets;

namespace KlonsA.Forms
{
    public partial class Form_EventTypes2 : MyFormBaseA
    {
        public Form_EventTypes2()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void Form_EventTypes2_Load(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void SelectCurrent()
        {
            if (dgvEv.CurrentRow == null || dgvEv.CurrentRow.IsNewRow) return;
            var dr = bsEv.CurrentDataRow as KlonsADataSet.EVENT_TYPES2Row;
            if (!dgvEv.EndEditX()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            int id = dr.ID;
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }

        private void dgvEv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void bnavEv_ItemDeleting(object sender, CancelEventArgs e)
        {
            if (!AskCanDelete()) e.Cancel = true;
        }

        public void DeleteCurrent()
        {
            bnavEv.DeleteCurrent();
            SaveData();
        }

        private void dgvEv_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvEv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null);
                e.Handled = true;
            }
        }

        public override bool SaveData()
        {
            if (!dgvEv.EndEditX()) return false;
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
            bnavEv.SetSaveButton(tsbSave, red);
        }
        private bool HasChanges()
        {
            return bsEv.HasChanges();
        }

        private void CheckSave()
        {
            SetSaveButton(HasChanges());
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvEv_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void bsEv_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }
    }
}
