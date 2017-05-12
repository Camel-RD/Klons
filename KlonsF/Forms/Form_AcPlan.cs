
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsF.UI;
using KlonsF.Classes;
using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.Forms
{
    public partial class Form_AcPlan : MyFormBaseF
    {
        public Form_AcPlan()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            bsAcPlan.Fill();
        }

        private void FormAcPlan_Load(object sender, EventArgs e)
        {
            CheckSave();
            WindowState = FormWindowState.Maximized;
        }

        private void SelectCurrent()
        {
            if (dgvAcp21.CurrentRow == null || dgvAcp21.CurrentRow.IsNewRow) return;
            if (!dgvAcp21.EndEdit()) return;
            string ac = dgvAcp21.CurrentRow.Cells[0].Value as string;
            if (!SaveData()) return;
            if (!this.IsMyDialog) return;
            SetSelectedValue(ac);
        }

        private void acP21DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                SelectCurrent();
            }
        }

        private void tbAcc_RowSelectedEvent(object sender, RowSelectedEventArgs e)
        {
            SetSelectedValue(e.Value);
        }

        private void acP21DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }
        }

        private void acP21DataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null);
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.SelectAll();
        }

        private void tbAcc_Enter(object sender, EventArgs e)
        {
            tbAcc.SelectAll();
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                string s = tbSearch.Text;
                if (s == "")
                {
                    bsAcPlan.RemoveFilter();
                }
                else
                {
                    bsAcPlan.Filter = string.Format("Name LIKE '*{0}*'", s);
                }
            }
        }

        private void acP21BindingNavigator_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void acP21DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void acP21DataGridView_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                dgvAcp21.MoveToNewRow();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                if (dgvAcp21.CurrentRow != null && !dgvAcp21.CurrentRow.IsNewRow)
                {
                    if (!dgvAcp21.EndEdit()) return;
                    bnavAcp21.DeleteCurrent();
                    e.Handled = true;
                }
            }
        }

        private void SetSaveButton(bool red)
        {
            bnavAcp21.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvAcp21.EndEditX()) return false;
            var ret = bsAcPlan.SaveTable();
            CheckSave();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsAcPlan.HasChanges());
        }

        private void dgvAcp21_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bsAcPlan_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            SetSaveButton(bsAcPlan.HasChanges());
        }

        private void toolStripButtonInfo_Click(object sender, EventArgs e)
        {
            if (!dgvAcp21.EndEdit()) return;
            bsAcPlan.ShowStats();
        }
    }
}
