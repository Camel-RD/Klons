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
using KlonsF.DataSets;
using KlonsLIB.Components;
using KlonsLIB.Data;
using KlonsLIB.Misc;
using KlonsF.UI;

namespace KlonsF.Forms
{
    public partial class Form_AcPVN : MyFormBaseF
    {
        public Form_AcPVN()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            bsAcP5.Fill();
            bsAcPVN.Fill();
        }

        private void FormAcPVN_Load(object sender, EventArgs e)
        {
            CheckSave();
            WindowState = FormWindowState.Maximized;
            MyData.DataSetKlons.Acp25.ColumnChanged += Acp25_ColumnChanged;
        }
        private void Form_AcPVN_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlons.Acp25.ColumnChanged -= Acp25_ColumnChanged;
        }

        private void Acp25_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            var dr = e.Row as klonsDataSet.Acp25Row;
            if (e.Column != MyData.DataSetKlons.Acp25.idxColumn) return;
            var drp = MyData.DataSetKlons.AcPVN.FindByid(dr.idx);
            if (drp == null) return;
            dr.Name = drp.NM.LeftMax(150);
            
        }

        private void SelectCurrent()
        {
            if (dgvAcPVN.CurrentRow == null || dgvAcPVN.CurrentRow.IsNewRow) return;
            string ac = dgvAcPVN.CurrentRow.Cells[dgcIdx.Index].Value.AsString();
            if (!dgvAcPVN.EndEdit()) return;
            if (!SaveData()) return;
            if (!this.IsMyDialog) return;
            SetSelectedValue(ac);
        }
        private void dgvAcPVN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectCurrent();
        }
        private void tbIdx_RowSelectedEvent(object sender, RowSelectedEventArgs e)
        {
            SetSelectedValue(e.Value);
        }
        private void dgvAcPVN_KeyDown(object sender, KeyEventArgs e)
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

        private void FormAcPVN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Escape)
            {
                SetSelectedValue(null);
            }
        }

        private void dgvAcPVN_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex != dgcIdx.Index) return;
            var dr = dgvAcPVN.GetDataRow(e.RowIndex) as klonsDataSet.AcP25aRow;
            if (dr == null) return;
            var o = dgvAcPVN.Rows[e.RowIndex].Cells[0].Value;
            string s = null;
            if (o != null)
            {
                DataTable dt = bsAcPVN.GetTable();
                var dr1 = dt.Rows.Find(o.ToString());
                if (dr1 == null) return;
                s = dr1[1].ToString();
            }
            dr.Name = s;
            dgvAcPVN.RefreshCurrent();
            */
        }

        private void bnavAcp5_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvAcPVN_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                if (!AskCanDelete()) e.Cancel = true;
            }
        }

        private void dgvAcPVN_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                dgvAcPVN.MoveToNewRow();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                bnavAcp5.DeleteCurrent();
                e.Handled = true;
            }
        }
        private void SetSaveButton(bool red)
        {
            bnavAcp5.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvAcPVN.EndEditX()) return false;
            var ret = bsAcP5.SaveTable();
            CheckSave();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsAcP5.HasChanges());
        }

        private void dgvAcPVN_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void bsAcP5_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

    }
}
