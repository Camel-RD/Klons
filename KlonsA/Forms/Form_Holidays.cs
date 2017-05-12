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
using KlonsLIB.Misc;

namespace KlonsA.Forms
{
    public partial class Form_Holidays : MyFormBaseA
    {
        public Form_Holidays()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            bsSvetki.Fill();
        }

        private void Form_Holidays_Load(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void dgvSvetki_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Decimal)
            {
                bnavSvetki.DeleteCurrent();
                e.Handled = true;
            }
        }

        private void dgvSvetki_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                string s = tbSearch.Text;
                if (s == "")
                {
                    bsSvetki.RemoveFilter();
                }
                else
                {
                    int k;
                    if (!int.TryParse(s, out k)) return;
                    if (k < 1950 || k > 2300) return;
                    bsSvetki.Filter = string.Format("DT>=#01/01/{0}# AND DT<=#12/31/{0}#", s);
                }
            }
        }

        private void bnavSvetki_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvSvetki_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void SetSaveButton(bool red)
        {
            bnavSvetki.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvSvetki.EndEditX()) return false;
            var ret = bsSvetki.SaveTable();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsSvetki.HasChanges());
        }

        private void dgvSvetki_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
            CheckSave();
        }

        private void bsSvetki_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvSvetki_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcDT.Index)
            {
                Utils.DGVParseDateCell(e);
            }
        }
    }
}
