using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsF.Classes;
using KlonsF.UI;
using KlonsF.DataSets;
using KlonsLIB.Data;
using KlonsLIB.Misc;
using KlonsLIB.Forms;

namespace KlonsF.Forms
{
    public partial class Form_Docs0 : MyFormBaseF
    {
        public Form_Docs0()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            LoadColumnWidthsFromSettings();
            bsDocs0.Fill();
        }


        private void Form_Docs0_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            CheckSave();
        }

        private int CW(int w)
        {
            return (int)Math.Round((float)w * dgvDocs0.ScaleFactor.Width, 0);
        }

        private void LoadColumnWidthsFromSettings()
        {
            int[] cw = MyData.Settings.ColumnWidths_Docs;

            if (cw.Length > 0)
            {
                dgcDate.Width = CW(cw[2]);
                dgcDocTp.Width = CW(cw[3]);
                dgcDocSt.Width = CW(cw[4]);
                dgcDocNr.Width = CW(cw[5]);
                dgcClid.Width = CW(cw[6]);
                dgcDescr.Width = CW(cw[7]);
                dgcSum.Width = CW(cw[8]);
                dgcPVN.Width = CW(cw[9]);
            }
            cw = MyData.Settings.ColumnWidths_Ops;
            if (cw.Length > 0)
            {
                dgcAC.Width = CW(cw[2]);
            }
        }

        private void dgvDocs0_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcDate.Index)
            {
                if (e.Value == null || e.Value == DBNull.Value) return;
                if (!(e.Value is string)) return;
                string s = (string)e.Value;
                if (string.IsNullOrEmpty(s)) return;
                DateTime dt;
                if (Utils.StringToDate(s, out dt))
                {
                    e.Value = dt;
                    e.ParsingApplied = true;
                    return;
                }
            }
        }

        private void dgvDocs0GetCellValue(object sender, int colind)
        {
            Action<string> act =
                value =>
                {
                    try
                    {
                        if (value != null && dgvDocs0.CurrentCell != null)
                        {
                            dgvDocs0.CurrentCell.Value = value;
                            dgvDocs0.RefreshEdit();
                            dgvDocs0.EndEdit();
                            dgvDocs0.Focus();
                        }
                        dgvDocs0.GoingToDialog = false;
                        dgvDocs0.Select();
                        if (dgvDocs0.EditingControl != null)
                            ActiveControl = dgvDocs0.EditingControl;
                    }
                    finally
                    {
                        dgvDocs0.GoingToDialog = false;
                    }
                };

            if (colind == dgcAC.Index)
            {
                dgvDocs0.GoingToDialog = true;
                MyMainForm.ShowFormAcplanDialog(act);
                return;
            }

            if (colind == dgcClid.Index)
            {
                dgvDocs0.GoingToDialog = true;
                MyMainForm.ShowFormAcp5Dialog(act);
                return;
            }
        }

        private void dgvDocs0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDocs0GetCellValue(sender, e.ColumnIndex);
        }

        private void dgvDocs0_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDocs0.CurrentCell == null) return;
            if (e.KeyCode == Keys.F5)
            {
                dgvDocs0GetCellValue(sender, dgvDocs0.CurrentCell.ColumnIndex);
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                dgvDocs0.MoveToNewRow();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                if (!dgvDocs0.EndEdit()) return;
                if (dgvDocs0.CurrentRow != null && !dgvDocs0.CurrentRow.IsNewRow)
                {
                    bnavDocs0.DeleteCurrent();
                    e.Handled = true;
                }
            }
        }

        private void SetSaveButton(bool red)
        {
            bnavDocs0.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvDocs0.EndEditX()) return false;
            var ret = bsDocs0.SaveTable();
            CheckSave();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsDocs0.HasChanges());
        }


        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvDocs0_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvDocs0_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex == -1 || e.RowIndex == dgvDocs0.NewRowIndex || e.ColumnIndex == -1) return;
            var o = dgvDocs0[e.ColumnIndex, e.RowIndex].Value;
            if (o == null || o == DBNull.Value) return;
            string s = o.ToString();
            if (string.IsNullOrEmpty(s)) return;
            if (e.ColumnIndex == dgcAC.Index)
            {
                e.ToolTipText = MyData.GetAcName(s);
                return;
            }
            if (e.ColumnIndex == dgcClid.Index)
            {
                e.ToolTipText = MyData.GetClName(s);
                return;
            }
        }

        private void dgvDocs0_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                if (!AskCanDelete()) e.Cancel = true;
            }
        }

        private void bnavDocs0_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void bsDocs0_MyBeforeRowInsert(MyRowUpdateEventArgs e)
        {
            var dr = e.DataRow as klonsDataSet.Bal0Row;
            if (dr == null) return;
            dr.id = (int)MyData.KlonsQueriesTableAdapter.SP_DOCS0_ID();
        }

        private void bsDocs0_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            SetSaveButton(bsDocs0.HasChanges());
        }

        private void tspRefresh_Click(object sender, EventArgs e)
        {
            bsDocs0.Fill();
        }

        private int SearchText(string text, int colindex,
            int startindex = 0, bool forward = true)
        {
            string propname = dgvDocs0.Columns[colindex].DataPropertyName;
            if (bsDocs0.Count == 0) return -1;
            if (startindex < 0 || startindex >= bsDocs0.Count) return -1;
            if (string.IsNullOrEmpty(text)) return -1;
            if (startindex == 0 && !forward) return -1;
            if (startindex == bsDocs0.Count - 1 && forward) return -1;
            var rv = bsDocs0[startindex] as DataRowView;
            if (rv == null) return -1;
            int colnr = rv.Row.Table.Columns.IndexOf(propname);
            if (colnr == -1) return -1;
            int di = forward ? 1 : -1;
            object o;
            string val;
            text = text.ToLower();
            for (int i = startindex; i >= 0 && i < bsDocs0.Count; i += di)
            {
                var rv1 = bsDocs0[i] as DataRowView;
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
            if (dgvDocs0.CurrentRow == null || dgvDocs0.CurrentRow.IsNewRow) return;
            if (!dgvDocs0.EndEditX()) return;

            int startindex = dgvDocs0.CurrentRow.Index;
            startindex = fromfirst ? 0 : (forward ? startindex + 1 : startindex - 1);
            string text = tsbSearch.Text;
            if (text == "") return;
            int newindex = SearchText(text, dgvDocs0.CurrentCell.ColumnIndex, startindex, forward);
            if (newindex == -1)
            {
                MyMainForm.ShowInfo("Tekts [" + text + "] netika atrasts.");
                return;
            }
            dgvDocs0.CurrentCell = dgvDocs0[dgvDocs0.CurrentCell.ColumnIndex, newindex];
        }

        private void dgvDocs0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.F | Keys.Control))
            {
                tsbSearch.Focus();
            }
        }

        private void tsbSearch_Enter(object sender, EventArgs e)
        {
            tsbSearch.Text = "";
        }

        private void tsbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SearchText();
                dgvDocs0.Focus();
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                dgvDocs0.Focus();
                e.Handled = true;
                return;
            }
        }

        private void tsbSearchPrev_Click(object sender, EventArgs e)
        {
            SearchText(false, false);
            dgvDocs0.Focus();
        }

        private void tsbSearchNext_Click(object sender, EventArgs e)
        {
            SearchText(false, true);
            dgvDocs0.Focus();
        }


    }
}
