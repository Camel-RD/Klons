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
using KlonsLIB.Forms;

namespace KlonsFM.Forms
{
    public partial class Form_BilancesFormula : MyFormBaseF
    {
        public Form_BilancesFormula()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            MyData.DataSetKlons.BalA3.Clear();
            MyData.DataSetKlons.BalA2.Clear();
            MyData.DataSetKlons.BalA1.Clear();
            bsBalA1.Fill();
            bsBalA2.Fill();
            bsBalA3.Fill();
            cbReportPart.SelectedIndex = 0;
            CheckReportPart();
        }

        private void Form_Bilance_Load(object sender, EventArgs e)
        {
            dgvBalA3.Top = dgvBalA2.Top;
            panel1.Top = dgvBalA3.Top;
            panel1.Left = dgvBalA3.Left;
            panel2.Top = dgvBalA3.Top;
            panel2.Left = dgvBalA3.Left;
            dgcBalA3id.Visible = false;
            dgcBalA3id2.Visible = false;

            CheckSave();
            WindowState = FormWindowState.Maximized;
        }

        private void dgvBalA1_Enter(object sender, EventArgs e)
        {
            bnavBalsA1.BindingSource = bsBalA1;
            bnavBalsA1.DataGrid = dgvBalA1;
            tslbActiveTable.Text = "Atskaites:";
        }

        private void dgvBalA2_Enter(object sender, EventArgs e)
        {
            bnavBalsA1.BindingSource = bsBalA2;
            bnavBalsA1.DataGrid = dgvBalA2;
            tslbActiveTable.Text = "Rindas:";
        }

        private void dgvBalA3_Enter(object sender, EventArgs e)
        {
            bnavBalsA1.BindingSource = bsBalA3;
            bnavBalsA1.DataGrid = dgvBalA3;
            tslbActiveTable.Text = "Summējums:";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MyBindingSource2 bs = bnavBalsA1.BindingSource as MyBindingSource2;
            if (bs == null) return;
            bs.ShowStats();
        }

        private void bsBalA2_CurrentItemChanged(object sender, EventArgs e)
        {
            object o = bsBalA2.Current;
            if (o == null)
            {
                panel1.Visible = false;
                dgvBalA3.Visible = false;
            }
            DataRowView dv = o as DataRowView;
            if (dv == null) return;
            klonsDataSet.BalA2Row dr = dv.Row as klonsDataSet.BalA2Row;
            if (dr == null) return;
            switch (dr.tp)
            {
                case null:
                case "V":
                    panel1.Visible = false;
                    panel2.Visible = true;
                    dgvBalA3.Visible = false;
                    break;
                case "S":
                    panel1.Visible = false;
                    panel2.Visible = false;
                    dgvBalA3.Visible = true;
                    break;
                case "K":
                    panel1.Visible = true;
                    panel2.Visible = false;
                    dgvBalA3.Visible = false;
                    break;
                default:
                    panel1.Visible = false;
                    panel2.Visible = false;
                    dgvBalA3.Visible = false;
                    break;
            }
            panel1.Top = dgvBalA3.Top;
            panel1.Left = dgvBalA3.Left;
            panel2.Top = dgvBalA3.Top;
            panel2.Left = dgvBalA3.Left;
        }

        private void CheckReportPart()
        {
            int k = cbReportPart.SelectedIndex;
            if (k == -1) return;
            string s = k == 0 ? "AK" : "PA";
            bsBalA2.Filter = "dc = '" + s + "'";
        }

        private void cbReportPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckReportPart();
        }

        private void dgvBalA2_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            int k = cbReportPart.SelectedIndex;
            string s = k == 1 ? "PA" : "AK";
            e.Row.Cells[dgcBalA2dc.Index].Value = s;
        }

        private void bnavBalsA1_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvBalA1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvBalA1_MyKeyDown(object sender, KeyEventArgs e)
        {
            var dgv = sender as MyDataGridView;
            if (dgv == null) return;
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                dgv.MoveToNewRow();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                if (!dgvBalA1.EndEdit()) return;
                if (!dgvBalA2.EndEdit()) return;
                if (!dgvBalA3.EndEdit()) return;
                if (bnavBalsA1.BindingSource == bsBalA1 &&
                    dgvBalA1.CurrentRow != null && !dgvBalA1.CurrentRow.IsNewRow ||
                    bnavBalsA1.BindingSource == bsBalA2 &&
                    dgvBalA2.CurrentRow != null && !dgvBalA2.CurrentRow.IsNewRow ||
                    bnavBalsA1.BindingSource == bsBalA3 &&
                    dgvBalA3.CurrentRow != null && !dgvBalA3.CurrentRow.IsNewRow)
                {
                    bnavBalsA1.DeleteCurrent();
                    e.Handled = true;
                }
            }
        }

        private void DoCopy()
        {
            if (!SaveData()) return;
            var dr = dgvBalA1.GetCurrentDataRow() as klonsDataSet.BalA1Row;
            if (dr == null) return;
            Form_InputBox f = new Form_InputBox("Bilances atskaites", "Jaunās atskaites kods", "");
            if (f.ShowDialog(MyMainForm) != DialogResult.OK) return;
            string newid = f.SelectedValue;
            if (newid == "" || newid.Length > 10 ||
                MyData.DataSetKlons.BalA1.FindBybalid(newid) != null)
            {
                MyMainForm.ShowWarning("Nekorekts atskaites kods: " + newid);
                return;
            }
            try
            {
                DataSetHelper.CopyRowWithChildRows(dr, null, newid);
            }
            catch (Exception e)
            {
                Form_Error.ShowException(MyMainForm, e);
            }
            SaveData();
            Refresh();
        }
        private void DoRename()
        {
            if (!SaveData()) return;
            var dr = dgvBalA1.GetCurrentDataRow() as klonsDataSet.BalA1Row;
            if (dr == null) return;
            Form_InputBox f = new Form_InputBox("Bilances atskaites", "Mainīt atskaites kodu", dr.balid);
            if (f.ShowDialog(MyMainForm) != DialogResult.OK) return;
            string newid = f.SelectedValue;
            if (newid == dr.balid) return;
            if (newid == "" || newid.Length > 10 ||
                MyData.DataSetKlons.BalA1.FindBybalid(newid) != null)
            {
                MyMainForm.ShowWarning("Nekorekts atskaites kods: " + newid);
                return;
            }
            dr.balid = newid;
            bsBalA2.GetTable().AcceptChanges();
            dgvBalA1.RefreshCurrent();
            SaveData();
        }

        private void CheckFormulas(bool pza = false)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                CheckFormulasA(pza);
            });
        }

        private void CheckFormulasA(bool pza = false)
        {
            if (!SaveData()) return;
            var o = dgvBalA1.GetCurrentDataItem();
            if (o == null) return;

            string balid = (string) dgvBalA1.CurrentRow.Cells[dgcBalA1balid.Index].Value;
            
            var dt = MyData.KlonsTableAdapterManager.AcP21TableAdapter.GetDataBy_bal_13(balid);
            if (pza)
            {
                dt.DefaultView.RowFilter = "AC >= '6' AND AC < '9'";
            }
            int k = dt.DefaultView.Count;
            if (k == 0)
            {
                MyMainForm.ShowInfo("Kļūdas netika atrastas\n(bet tas nenozīmē kā tādu tur nav)");
                return;
            }
            if (k > 20) k = 20;
            StringBuilder sb = new StringBuilder();
            sb.Append("Šie konti nav iekļauti formulās:\n");
            for (int i = 0; i < k; i++)
            {
                sb.Append(dt.DefaultView[i].Row[0]);
                if (i < k - 1)
                    sb.Append(", ");
            }
            if (k < dt.DefaultView.Count)
                sb.Append(", ...");

            MyMainForm.ShowInfo(sb.ToString());
        }

        private void mainītAtskaitesKoduToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoRename();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CheckFormulas(false);
        }

        private void pārbaudītFormulasPZAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckFormulas(true);
        }

        private void kopētAtskaitesFormuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoCopy();
        }

        private void pārbaudītFormulasBilanceiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckFormulas(false);
        }

        private void dgvBalA1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvBalA1.CurrentCell == null) return;
            dgvBalA2.Enabled = !dgvBalA1.CurrentRow.IsNewRow;
            dgvBalA3.Enabled = !(dgvBalA1.CurrentRow.IsNewRow ||
                (dgvBalA2.CurrentRow != null && dgvBalA2.CurrentRow.IsNewRow));
            panel1.Enabled = dgvBalA2.Enabled;
            panel2.Enabled = dgvBalA2.Enabled;
            dgcBalA1balid.ReadOnly =
                dgvBalA1.NewRowIndex != dgvBalA1.CurrentCell.RowIndex;
        }
        private void dgvBalA1_Leave(object sender, EventArgs e)
        {
            if (dgvBalA1.CurrentRow == null) return;
            if (dgvBalA1.CurrentRow.IsNewRow)
            {
                if (dgvBalA1.RowCount == 1) return;
                dgvBalA1.CurrentCell = dgvBalA1[0, dgvBalA1.RowCount - 2];
            }
        }

        private void dgvBalA2_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvBalA2.CurrentCell == null) return;
            dgvBalA3.Enabled = !(dgvBalA2.CurrentRow.IsNewRow);
        }

        private void dgvBalA2_Leave(object sender, EventArgs e)
        {
            if (dgvBalA2.CurrentRow == null) return;
            if (dgvBalA2.CurrentRow.IsNewRow)
            {
                if (dgvBalA2.RowCount == 1) return;
                dgvBalA2.CurrentCell = dgvBalA2[0, dgvBalA2.RowCount - 2];
            }
        }

        private void bsBalA2_MyBeforeRowInsert(MyRowUpdateEventArgs e)
        {
            var dr = e.DataRow as klonsDataSet.BalA2Row;
            if (dr == null) return;
            dr.id = (int)MyData.KlonsQueriesTableAdapter.SP_BALA2_ID();
        }

        private void bsBalA3_MyBeforeRowInsert(MyRowUpdateEventArgs e)
        {
            var dr = e.DataRow as klonsDataSet.BalA3Row;
            if (dr == null) return;
            dr.id = (int)MyData.KlonsQueriesTableAdapter.SP_BALA3_ID();
        }

        public void CheckGridA1()
        {
            DataRowView dv = bsBalA1.Current as DataRowView;
            if (dv == null
                || dv.Row.RowState == DataRowState.Deleted)
            {
                bsBalA2.Sort = null;
                bsBalA2.DataSource = null;
                dgvBalA2.Enabled = false;
            }
            else
            {
                DataView dv1 = dv.CreateChildView(dv.Row.Table.ChildRelations[0]);
                dgvBalA2.Enabled = true;
                bsBalA2.DataSource = dv1;
                bsBalA2.Sort = "nr";
            }
        }

        public void CheckGridA2()
        {
            DataRowView dv = bsBalA2.Current as DataRowView;
            if (dv == null
                || dv.Row.RowState == DataRowState.Deleted)
            {
                bsBalA3.Sort = null;
                bsBalA3.DataSource = null;
                dgvBalA3.Enabled = false;
            }
            else
            {
                DataView dv1 = dv.CreateChildView(dv.Row.Table.ChildRelations[0]);
                dgvBalA3.Enabled = true;
                bsBalA3.DataSource = dv1;
                bsBalA3.Sort = "ac";
            }
        }

        private void bsBalA1_CurrentChanged(object sender, EventArgs e)
        {
            //CheckGridA1();
        }

        private void bsBalA2_CurrentChanged(object sender, EventArgs e)
        {
            //CheckGridA2();
        }

        public override bool SaveData()
        {
            if (!dgvBalA1.EndEditX()) return false;
            if (!dgvBalA2.EndEditX()) return false;
            if (!dgvBalA3.EndEditX()) return false;
            var ret1 = bsBalA1.SaveTable();
            //var ret1 = bsBalA1.SaveTable();
            return ret1 != EBsSaveResult.Error;
        }

        private bool HasChanges()
        {
            return bsBalA1.HasChanges() || bsBalA2.HasChanges() ||
                   bsBalA3.HasChanges();
        }
        private void SetSaveButton(bool red)
        {
            bnavBalsA1.SetSaveButton(tsbSave, red);
        }

        private void CheckSave()
        {
            SetSaveButton(HasChanges());
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            CheckSave();
            SetSaveButton(HasChanges());
        }

        private void bsBalA1_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            SetSaveButton(HasChanges());
        }

        private void bsBalA2_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void bsBalA3_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void bsBalA1_MyItemRemoved(object sender, MyItemRemovedEventArgs e)
        {
            bsBalA2.GetTable().AcceptChanges();
        }

        private void dgvBalA3_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[dgcBalA3tp.Index].Value = cbReportPart.SelectedIndex == 0 ? "Db" : "Kr";
        }
    }
}
