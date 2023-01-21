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
using KlonsLIB.Data;
using KlonsFM.UI;

namespace KlonsFM.Forms
{
    public partial class Form_Currency : MyFormBaseF
    {
        public Form_Currency()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            bsCurrency.Fill();
        }

        private void banksBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bsCurrency.SaveTable();
        }

        private void Form_Currency_Load(object sender, EventArgs e)
        {
            CheckSave();
            WindowState = FormWindowState.Maximized;
        }

        private void bnavCurrency_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvCurrency_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvCurrency_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                dgvCurrency.MoveToNewRow();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                if (dgvCurrency.CurrentRow != null && !dgvCurrency.CurrentRow.IsNewRow)
                {
                    if (!dgvCurrency.EndEdit()) return;
                    bnavCurrency.DeleteCurrent();
                    e.Handled = true;
                }
            }
        }

        private void Filter()
        {
            string sdate = tbDate.Text;
            DateTime date;
            if (sdate == "" || !DateTime.TryParse(sdate, out date))
            {
                bsCurrency.RemoveFilter();
                return;
            }
            bsCurrency.Filter = "dete = '" + date.ToString("yyyy-MM-dd")  + "'";
        }

        private void tbDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                Filter();
            }
        }
        private void cmFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }


        private void SetSaveButton(bool red)
        {
            bnavCurrency.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvCurrency.EndEditX()) return false;
            var ret = bsCurrency.SaveTable();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsCurrency.HasChanges());
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
            CheckSave();
        }

        private void bsCurrency_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvCurrency_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }
    }
}
