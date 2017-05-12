using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsF.Classes;
using KlonsLIB.Components;
using KlonsLIB.Data;
using KlonsF.UI;

namespace KlonsF.Forms
{
    public partial class Form_AcP4 : MyFormBaseF
    {
        public Form_AcP4()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            bsAcP4.Fill();
            CheckSave();
        }

        private void FormAcP4_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            CheckSave();
        }

        private void SelectCurrent()
        {
            if (dgvAcP4.CurrentRow == null || dgvAcP4.CurrentRow.IsNewRow) return;
            if (!dgvAcP4.EndEdit()) return;
            string ac = dgvAcP4.CurrentRow.Cells[0].Value as string;
            if (!SaveData()) return;
            if (!this.IsMyDialog) return;
            SetSelectedValue(ac);
        }

        private void dgvAcP4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectCurrent();
        }

        private void tbIdx_RowSelectedEvent(object sender, RowSelectedEventArgs e)
        {
            SetSelectedValue(e.Value);
        }

        private void dgvAcP4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }
        }

        private void tbIdx_Enter(object sender, EventArgs e)
        {
            tbIdx.SelectAll();
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.SelectAll();
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                string s = tbSearch.Text;
                if (s == "")
                {
                    bsAcP4.RemoveFilter();
                }
                else
                {
                    bsAcP4.Filter = string.Format("Name LIKE '*{0}*'", s);
                }
            }
        }

        private void FormAcP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Escape)
            {
                SetSelectedValue(null);
            }
        }

        private void dgvAcP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null);
            }
        }

        private void dgvAcP4_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvAcP4.ReadOnly)
            {
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                dgvAcP4.MoveToNewRow();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                if (dgvAcP4.CurrentRow != null && !dgvAcP4.CurrentRow.IsNewRow)
                {
                    if (!dgvAcP4.EndEdit()) return;
                    bnavAcp4.DeleteCurrent();
                }
                e.Handled = true;
            }
        }

        private void bnavAcp4_ItemDeleting(object sender, CancelEventArgs e)
        {
            if (dgvAcP4.ReadOnly)
            {
                e.Cancel = true;
                return;
            }
            e.Cancel = !AskCanDelete();
        }

        private void dgvAcP4_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                if (!AskCanDelete()) e.Cancel = true;
            }
        }

        private void SetSaveButton(bool red)
        {
            bnavAcp4.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvAcP4.EndEditX()) return false;
            var ret = bsAcP4.SaveTable();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsAcP4.HasChanges());
        }

        private void dgvAcP4_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
            SetSaveButton(bsAcP4.HasChanges());
        }

        private void bsAcP4_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            SetSaveButton(bsAcP4.HasChanges());
        }
    }
}
