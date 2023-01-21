using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.Classes;
using KlonsFM.UI;
using KlonsFM.DataSets;
using KlonsLIB.Components;
using KlonsLIB.Data;
using KlonsLIB.Misc;

namespace KlonsFM.Forms
{
    public partial class Form_Persons : MyFormBaseF
    {
        public Form_Persons()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            bsBanks.Fill();
            bsPersons.Fill();
            cbAct.SelectedIndex = 0;
            CheckFilter();
        }

        private void FormPersons_Load(object sender, EventArgs e)
        {
            CheckSave();
            WindowState = FormWindowState.Maximized;
        }
        private void FormPersons_Shown(object sender, EventArgs e)
        {
        }

        private void CheckFilter()
        {
            string fs = "", s1 = "", s2 = "", s = tbSearch.Text;
            int k = cbAct.SelectedIndex;
            if (s == "" && k == 0)
            {
                bsPersons.RemoveFilter();
            }
            else
            {
                if (k == 1)
                    s1 = "ACT = 1";
                if (s != "")
                    s2 = string.Format("(Name LIKE '*{0}*' OR RegNr LIKE '*{0}*')", s);
                if (s1 != "" && s2 != "")
                    fs = s1 + " AND " + s2;
                else
                    fs = s1 + s2;
                bsPersons.Filter = fs;
            }
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                CheckFilter();
            }
        }

        private void tbClid_Enter(object sender, EventArgs e)
        {
            tbClid.SelectAll();
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.SelectAll();
        }

        private void dgvPersons_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }
        }

        private void tbClid_RowSelectedEvent(object sender, RowSelectedEventArgs e)
        {
            SetSelectedValue(e.Value);
        }

        private void SelectCurrent()
        {
            if (dgvPersons.CurrentRow == null || dgvPersons.CurrentRow.IsNewRow) return;
            string clid = dgvPersons.CurrentRow.Cells[0].Value.AsString();
            if (!dgvPersons.EndEdit()) return;
            if (!SaveData()) return;
            if (!this.IsMyDialog) return;
            SetSelectedValue(clid);
        }

        private void dgvPersons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectCurrent();
        }

        private void dgvPersons_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null);
            }
        }

        private void bnavPersons_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvPersons_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvPersons_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                dgvPersons.MoveToNewRow();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                bnavPersons.DeleteCurrent();
                e.Handled = true;
            }
        }

        private void cbAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckFilter();
        }

        private void dgvPersons_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvPersons.NewRowIndex) return;

            var dr = dgvPersons.GetDataRow(e.RowIndex) as klonsDataSet.PersonsRow;
            if (dr == null) return;

            if (e.ColumnIndex == dgcBankId.Index)
            {
                string s = dgvPersons.CurrentRow.Cells[dgcBankId.Index].Value.AsString();
                dr.Bank = MyData.GetBankName(s);
                dgvPersons.InvalidateRow(e.RowIndex);
            }
            else if (e.ColumnIndex == dgcRegNr.Index)
            {
                string s = dgvPersons.CurrentRow.Cells[dgcRegNr.Index].Value.AsString();
                if (!string.IsNullOrEmpty(s) && s.Length == 11)
                {
                    dr.PVNRegNr = "LV" + s;
                    dgvPersons.InvalidateRow(e.RowIndex);
                }
            }
        }


        private void SetSaveButton(bool red)
        {
            bnavPersons.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvPersons.EndEditX()) return false;
            var ret = bsPersons.SaveTable();
            CheckSave();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsPersons.HasChanges());
        }


        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvPersons_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void bsPersons_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            SetSaveButton(bsPersons.HasChanges());
        }


    }
}
