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

namespace KlonsF.Forms
{
    public partial class Form_LOPSd : MyFormBaseF
    {
        public Form_LOPSd()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void lOPSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
        }

        private void FormLOPSd_Load(object sender, EventArgs e)
        {
            this.bsLOPSd.Fill();
            WindowState = FormWindowState.Maximized;
        }

        private int SearchText(string text, int colindex,
            int startindex = 0, bool forward = true)
        {
            string propname = dgvLOPSd.Columns[colindex].DataPropertyName;
            if (bsLOPSd.Count == 0) return -1;
            if (startindex < 0 || startindex >= bsLOPSd.Count) return -1;
            if (string.IsNullOrEmpty(text)) return -1;
            if (startindex == 0 && !forward) return -1;
            if (startindex == bsLOPSd.Count - 1 && forward) return -1;
            var rv = bsLOPSd[startindex] as DataRowView;
            if (rv == null) return -1;
            int colnr = rv.Row.Table.Columns.IndexOf(propname);
            if (colnr == -1) return -1;
            int di = forward ? 1 : -1;
            object o;
            string val;
            text = text.ToLower();
            for (int i = startindex; i >= 0 && i < bsLOPSd.Count; i += di)
            {
                var rv1 = bsLOPSd[i] as DataRowView;
                o = rv1.Row[colnr];
                if (o == null || o == DBNull.Value) continue;
                val = o.ToString();
                if (val.ToLower().Contains(text))
                {
                    return i;
                }
            }
            return -1;
        }

        private void SearchText(bool fromfirst = true, bool forward = true)
        {
            if (dgvLOPSd.CurrentRow == null ||
                dgvLOPSd.CurrentRow.IsNewRow) return;

            int startindex = dgvLOPSd.CurrentRow.Index;
            startindex = fromfirst ? 0 : (forward ? startindex + 1 : startindex - 1);
            string text = tsbSearch.Text;
            if (text == "") return;
            int newindex = SearchText(text, dgvLOPSd.CurrentCell.ColumnIndex, startindex, forward);
            if (newindex == -1)
            {
                MyMainForm.ShowInfo("Texts [" + text + "] netika atrasts.");
                return;
            }
            dgvLOPSd.CurrentCell = dgvLOPSd[dgvLOPSd.CurrentCell.ColumnIndex, newindex];
        }

        private void tsbSearchPrev_Click(object sender, EventArgs e)
        {
            SearchText(false, false);
            dgvLOPSd.Focus();
        }

        private void tsbSearchNext_Click(object sender, EventArgs e)
        {
            SearchText(false, true);
            dgvLOPSd.Focus();
        }

        private void tsbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SearchText();
                dgvLOPSd.Focus();
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                dgvLOPSd.Focus();
                e.Handled = true;
                return;
            }
        }

        private void dgvLOPSd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.F | Keys.Control))
            {
                tsbSearch.Focus();
            }
        }

        private void tsbSearch_Enter(object sender, EventArgs e)
        {
            tsbSearch.SelectAll();
        }
    }
}
