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
using KlonsFM.DataSets.klonsDataSetTableAdapters;
using KlonsLIB.Components;
using KlonsLIB.Data;
using KlonsLIB.Misc;

namespace KlonsFM.Forms
{
    public partial class Form_DocTyp : MyFormBaseF
    {
        public Form_DocTyp()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            bsDocTyp.Fill();
            bsDocTypA.Fill();
            bsDocTypB.Fill();
        }

        private void FormDocTyp_Load(object sender, EventArgs e)
        {
            //this.bsDocTypA.CurrentChanged += new System.EventHandler(this.bsDocTypA_CurrentChanged);
            //ChecChildGrid();
            CheckSave();
            WindowState = FormWindowState.Maximized;
        }

        private void FormDocTyp_Shown(object sender, EventArgs e)
        {
        }


        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                string s = tbSearch.Text;
                if (s == "")
                {
                    bsDocTyp.RemoveFilter();
                }
                else
                {
                    bsDocTyp.Filter = string.Format("Name LIKE '*{0}*'", s);
                }
            }
        }

        private void tbId_Enter(object sender, EventArgs e)
        {
            tbId.SelectAll();
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.SelectAll();
        }

        private void SelectCurrent()
        {
            if (dgvDocTyp.CurrentRow == null || dgvDocTyp.CurrentRow.IsNewRow) return;
            var dr = bsDocTyp.CurrentDataRow as klonsDataSet.DocTypRow;
            if (dr == null) return;
            if (!dgvDocTyp.EndEdit()) return;
            if (!SaveData()) return;
            if (!this.IsMyDialog) return;
            string id = dr.id;
            SetSelectedValue(id);
        }

        private void dgvDocTyp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }
        }

        private void tbId_RowSelectedEvent(object sender, RowSelectedEventArgs e)
        {
            SetSelectedValue(e.Value);
        }

        private void dgvDocTyp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                SetSelectedValue(dgvDocTyp.CurrentRow.Cells[0].Value as string);
            }
        }

        private void dgvDocTyp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null);
            }
        }

        private void dgvDocTyp_Enter(object sender, EventArgs e)
        {
            bnavDocTyp.BindingSource = bsDocTyp;
            bnavDocTyp.DataGrid = dgvDocTyp;
            toolStripLabel1.Text = "Dokumentu veids:";
        }

        private void dgvDocTypA_Enter(object sender, EventArgs e)
        {
            bnavDocTyp.BindingSource = bsDocTypA;
            bnavDocTyp.DataGrid = dgvDocTypA;
            toolStripLabel1.Text = "Dokumentu grupa:";
            dgvDocTypB.Enabled = true;
        }

        private void dgvDocTypA_CurrentCellChanged(object sender, EventArgs e)
        {
            dgvDocTypB.Enabled = !(dgvDocTypA.CurrentRow == null ||
                dgvDocTypA.RowCount == 1 || dgvDocTypA.CurrentRow.IsNewRow);
            dgcDocTypAId.ReadOnly = dgvDocTypA.CurrentRow == null || !dgvDocTypA.CurrentRow.IsNewRow;
        }

        private void dgvDocTypB_Enter(object sender, EventArgs e)
        {
            bnavDocTyp.BindingSource = bsDocTypB;
            bnavDocTyp.DataGrid = dgvDocTypB;
            toolStripLabel1.Text = "Grupā ietilpst:";
        }

        private void bnavDocTyp_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvDocTyp_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvDocTypA_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvDocTypB_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvDocTyp_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                dgvDocTyp.MoveToNewRow();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                if (dgvDocTyp.CurrentRow != null && !dgvDocTyp.CurrentRow.IsNewRow)
                {
                    if (!dgvDocTyp.EndEdit()) return;
                    bnavDocTyp.DeleteCurrent();
                    e.Handled = true;
                }
            }
        }

        private void dgvDocTypA_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                dgvDocTypA.MoveToNewRow();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                if (dgvDocTypA.CurrentRow != null && !dgvDocTypA.CurrentRow.IsNewRow)
                {
                    if (!dgvDocTypA.EndEdit()) return;
                    bnavDocTyp.DeleteCurrent();
                    e.Handled = true;
                }
            }
        }

        private void dgvDocTypB_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                dgvDocTypB.MoveToNewRow();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                if (dgvDocTypB.CurrentRow != null && !dgvDocTypB.CurrentRow.IsNewRow)
                {
                    if (!dgvDocTypB.EndEdit()) return;
                    bnavDocTyp.DeleteCurrent();
                    e.Handled = true;
                }
            }
        }

        private void tsbInfo_Click(object sender, EventArgs e)
        {
            string s1 = bsDocTyp.GetStats();
            string s2 = bsDocTypA.GetStats();
            string s3 = bsDocTypB.GetStats();
            var s = string.Format("Mainīti ieraksti:\n  dokumentu veidi - {0}\n" +
                          "  dokumentu grupas - {1}\n  grupas saturs - {2}", s1, s2, s3);
            MyMainForm.ShowInfo(s);
        }

        private void dgvDocTypA_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvDocTypA[dgcDocTypAId.Index, e.RowIndex].Value == null)
                e.Cancel = true;
        }


        private void SetSaveButton(bool red)
        {
            bnavDocTyp.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvDocTyp.EndEditX()) return false;
            if (!dgvDocTypA.EndEditX()) return false;
            if (!dgvDocTypB.EndEditX()) return false;
            var ret1 = bsDocTyp.SaveTable();
            var ret2 = bsDocTypA.SaveTable();
            return ret1 != EBsSaveResult.Error && ret2 != EBsSaveResult.Error;
        }

        private bool HasChanges()
        {
            return bsDocTyp.HasChanges() || bsDocTypA.HasChanges() ||
                   bsDocTypB.HasChanges();
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

        private void dgvDocTyp_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SetSaveButton(HasChanges());
        }

        private void bsDocTyp_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            SetSaveButton(HasChanges());
        }

        public void ChecChildGrid()
        {
            DataRowView dv = bsDocTypA.Current as DataRowView;
            if (dv == null
                || dv.Row.RowState == DataRowState.Deleted
                )
            {
                bsDocTypB.DataSource = null;
                dgvDocTypB.Enabled = false;
            }
            else
            {
                DataRelation rel = dv.Row.Table.ChildRelations["FK_DOCTYPB_IDA_DOCTYPA_ID"];
                DataView dv1 = dv.CreateChildView(rel);
                dgvDocTypB.Enabled = true;
                bsDocTypB.DataSource = dv1;
            }
        }

        private void bsDocTypA_CurrentChanged(object sender, EventArgs e)
        {
            //ChecChildGrid();
        }

    }
}
