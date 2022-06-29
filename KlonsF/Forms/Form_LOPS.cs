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
    public partial class Form_LOPS : MyFormBaseF
    {
        public Form_LOPS()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void lOPSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
        }

        private void FormLOPS_Load(object sender, EventArgs e)
        {
            this.bsLOPS.Fill();
            WindowState = FormWindowState.Maximized;
        }

        private int SearchText(string text, int colindex,
            int startindex = 0, bool forward = true)
        {
            string propname = dgvLOPS.Columns[colindex].DataPropertyName;
            if (bsLOPS.Count == 0) return -1;
            if (startindex < 0 || startindex >= bsLOPS.Count) return -1;
            if (string.IsNullOrEmpty(text)) return -1;
            if (startindex == 0 && !forward) return -1;
            if (startindex == bsLOPS.Count - 1 && forward) return -1;
            var rv = bsLOPS[startindex] as DataRowView;
            if (rv == null) return -1;
            int colnr = rv.Row.Table.Columns.IndexOf(propname);
            if (colnr == -1) return -1;
            int di = forward ? 1 : -1;
            object o;
            string val;
            text = text.ToLower();
            for (int i = startindex; i >= 0 && i < bsLOPS.Count; i += di)
            {
                var rv1 = bsLOPS[i] as DataRowView;
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
            if (dgvLOPS.CurrentRow == null ||
                dgvLOPS.CurrentRow.IsNewRow) return;

            int startindex = dgvLOPS.CurrentRow.Index;
            startindex = fromfirst ? 0 : (forward ? startindex + 1 : startindex - 1);
            string text = tsbSearch.Text;
            if (text == "") return;
            int newindex = SearchText(text, dgvLOPS.CurrentCell.ColumnIndex, startindex, forward);
            if (newindex == -1)
            {
                MyMainForm.ShowInfo("Texts [" + text + "] netika atrasts.");
                return;
            }
            dgvLOPS.CurrentCell = dgvLOPS[dgvLOPS.CurrentCell.ColumnIndex, newindex];
        }

        private void tsbSearchPrev_Click(object sender, EventArgs e)
        {
            SearchText(false, false);
            dgvLOPS.Focus();
        }

        private void tsbSearchNext_Click(object sender, EventArgs e)
        {
            SearchText(false, true);
            dgvLOPS.Focus();
        }

        private void tsbSearch_Enter(object sender, EventArgs e)
        {
            tsbSearch.SelectAll();
        }

        private void tsbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SearchText();
                dgvLOPS.Focus();
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                dgvLOPS.Focus();
                e.Handled = true;
                return;
            }
        }

        private void dgvLOPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.F | Keys.Control))
            {
                tsbSearch.Focus();
            }
        }

        private void tsbDocLog_Click(object sender, EventArgs e)
        {
            if (bsLOPS.DataSource == null || bsLOPS.Count == 0 || bsLOPS.Position == -1) return;
            var row = (bsLOPS.Current as DataRowView).Row as DataSets.klonsDataSet.LOPSRow;
            if (row == null) return;
            var frm = MyMainForm.ShowForm(typeof(Form_LogDoc)) as Form_LogDoc;
            frm.GetData2(row.DocId);
        }
    }
}
