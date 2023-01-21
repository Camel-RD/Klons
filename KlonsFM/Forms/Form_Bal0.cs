using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.DataSets;
using KlonsFM.UI;
using KlonsFM.Classes;
using KlonsLIB.Data;
using KlonsLIB.Misc;

namespace KlonsFM.Forms
{
    public partial class Form_Bal0 : MyFormBaseF
    {
        public Form_Bal0()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            suspend_table_events = true;
            this.bsBal0.Fill();
            suspend_table_events = false;
            GetSums();
        }

        private void FormBal0_Load(object sender, EventArgs e)
        {
            CheckSave();
            WindowState = FormWindowState.Maximized;
            MyData.DataSetKlons.Bal0.ColumnChanged += Bal0_ColumnChenged;
        }

        private bool suspend_table_events = false;

        private void Bal0_ColumnChenged(object sender, DataColumnChangeEventArgs e)
        {
            if (suspend_table_events) return;

            var dr = e.Row as klonsDataSet.Bal0Row;
            if (dr == null) return;

            if (e.Column == MyData.DataSetKlons.Bal0.SummCCColumn ||
                e.Column == MyData.DataSetKlons.Bal0.SummDCColumn ||
                e.Column == MyData.DataSetKlons.Bal0.CurColumn ||
                e.Column == MyData.DataSetKlons.Bal0.CurRateColumn)
            {
                dr.SummD = Math.Round(dr.SummDC*dr.CurRate, 2);
                dr.SummC = Math.Round(dr.SummCC*dr.CurRate, 2);
            }
       }

        private void bnavB0_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvBal0_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void dgvBal0_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvBal0.CurrentCell == null) return;
            if (e.KeyCode == Keys.F5)
            {
                dgvBal0GetCellValue(sender, dgvBal0.CurrentCell.ColumnIndex);
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                dgvBal0.MoveToNewRow();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                if (!dgvBal0.EndEdit()) return;
                if (dgvBal0.CurrentRow != null && !dgvBal0.CurrentRow.IsNewRow)
                {
                    bnavB0.DeleteCurrent();
                    e.Handled = true;
                }
            }
        }

        private void GetSums()
        {
            if (bsBal0.Count == 0)
            {
                lbSumDeb.Text = "0.00";
                lbSumKred.Text = "0.00";
                return;
            }
            var o1 = bsBal0.GetTable().Compute("Sum(SummD)", null);
            var o2 = bsBal0.GetTable().Compute("Sum(SummC)", null);
            if (o1 == null || o1 == DBNull.Value || o2 == null || o2 == DBNull.Value)
            {
                lbSumDeb.Text = "0.00";
                lbSumKred.Text = "0.00";
                return;
            }
            decimal sdeb = (decimal) o1;
            decimal skred = (decimal) o2;
            lbSumDeb.Text = sdeb.ToString("N2");
            lbSumKred.Text = skred.ToString("N2");
        }

        private void dgvBal0GetCellValue(object sender, int colind)
        {
            Action<string> act =
                value =>
                {
                    try
                    {
                        if (value != null && dgvBal0.CurrentCell != null)
                        {
                            dgvBal0.CurrentCell.Value = value;
                            dgvBal0.RefreshEdit();
                            dgvBal0.EndEdit();
                            dgvBal0.Focus();
                        }
                        dgvBal0.GoingToDialog = false;
                        dgvBal0.Select();
                        if (dgvBal0.EditingControl != null)
                            ActiveControl = dgvBal0.EditingControl;
                    }
                    finally
                    {
                        dgvBal0.GoingToDialog = false;
                    }
                };
            if (colind == dgcBal0AC11.Index)
            {
                dgvBal0.GoingToDialog = true;
                MyMainForm.ShowFormAcplanDialog(act);
                return;
            }

            if (colind == dgcBal0AC24.Index)
            {
                dgvBal0.GoingToDialog = true;
                MyMainForm.ShowFormAcp4Dialog(act);
                return;
            }

            if (colind == dgcBal0Clid.Index)
            {
                dgvBal0.GoingToDialog = true;
                MyMainForm.ShowFormAcp5Dialog(act);
                return;
            }
        }

        private void dgvBal0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBal0GetCellValue(sender, e.ColumnIndex);
        }

        private void dgvBal0_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBal0.CurrentRow == null ||
                dgvBal0.CurrentRow.IsNewRow) return;
            if(Utils.IN(e.ColumnIndex, dgcSummDC.Index, 
                dgcSummCC.Index, dgcCur.Index, dgcCurRate.Index))
            {
                dgvBal0.RefreshCurrent();
            }
        }

        private void bsBal0_MyBeforeRowInsert(MyRowUpdateEventArgs e)
        {
            var dr = e.DataRow as klonsDataSet.Bal0Row;
            if (dr == null) return;
            dr.id = (int)MyData.KlonsQueriesTableAdapter.SP_OPS_ID();
        }

        private void dgvBal0_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex == -1 || e.RowIndex == dgvBal0.NewRowIndex || e.ColumnIndex == -1) return;
            var o = dgvBal0[e.ColumnIndex, e.RowIndex].Value;
            if (o == null || o == DBNull.Value) return;
            string s = o.ToString();
            if (string.IsNullOrEmpty(s)) return;
            if (e.ColumnIndex == dgcBal0AC11.Index)
            {
                e.ToolTipText = MyData.GetAcName(s);
                return;
            }
            if (e.ColumnIndex == dgcBal0AC24.Index)
            {
                e.ToolTipText = MyData.GetAc4Name(s);
                return;
            }
            if (e.ColumnIndex == dgcBal0Clid.Index)
            {
                e.ToolTipText = MyData.GetClName(s);
                return;
            }
        }

        private void SetSaveButton(bool red)
        {
            bnavB0.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvBal0.EndEditX()) return false;
            var ret = bsBal0.SaveTable();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsBal0.HasChanges());
        }


        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
            SetSaveButton(bsBal0.HasChanges());
        }

        private void dgvBal0_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }
        private void bsBal0_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            SetSaveButton(bsBal0.HasChanges());
            GetSums();
        }

    }
}
