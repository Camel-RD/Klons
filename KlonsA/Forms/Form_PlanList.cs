using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsA.DataSets;
using KlonsLIB.Data;

namespace KlonsA.Forms
{
    public partial class Form_PlanList : MyFormBaseA
    {
        public Form_PlanList()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            dgcKind1.DataSource = SomeDataDefs.LaikaPlanuSarK1;
            dgcKind1.DisplayMember = "Val";
            dgcKind1.ValueMember = "Key";

            dgcKind2.DataSource = SomeDataDefs.LaikaPlanuSarK2;
            dgcKind2.DisplayMember = "Val";
            dgcKind2.ValueMember = "Key";

            cbActive.SelectedIndex = 0;
            InsertInToolStrip(toolStrip1, tbSearch, 1);
            InsertInToolStrip(toolStrip1, cbActive, 2);
        }

        private void Form_PlanList_Load(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void SelectCurrent()
        {
            if (dgvPlanuSar.CurrentRow == null || dgvPlanuSar.CurrentRow.IsNewRow) return;
            var dr = bsPlanuSar.CurrentDataRow as KlonsADataSet.TIMEPLAN_LISTRow;
            if (!dgvPlanuSar.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            int id = dr.ID;
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }

        public void DeleteCurrent()
        {
            bnavPlanuSar.DeleteCurrent();
            SaveData();
        }

        private void dgvPlanuSar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgcDescr.Index || e.ColumnIndex == dgcSnr.Index)
            {
                SelectCurrent();
            }
        }

        private void dgvPlanuSar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                DeleteCurrent();
                e.Handled = true;
            }
        }

        private void dgvPlanuSar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CheckFilter()
        {
            string s = tbSearch.Text;
            if (s != null)
                s = string.Format("DESCR LIKE '*{0}*'", s);
            string sa = cbActive.SelectedIndex == 0 ? "USED = 1" : "";
            if(sa != "")
            {
                if (s == "")
                    s = sa;
                else
                    s += " AND " + sa;
            }

            if (s == "")
                bsPlanuSar.RemoveFilter();
            else
                bsPlanuSar.Filter = s;
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                CheckFilter();
            }
        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckFilter();
        }

        private void bnavPlanuSar_ItemDeleting(object sender, CancelEventArgs e)
        {
            if (!CanDelete() || !AskCanDelete())
                e.Cancel = true;
        }

        public bool CanDelete()
        {
            if (MyMainForm.FindForm(typeof(Form_Plan)) != null)
            {
                MyMainForm.ShowWarning("Vispirms jāaizver forma [Darba laika kopplāns].");
                return false; ;
            }
            return true;
        }

        private void dgvPlanuSar_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!CanDelete() || e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void SetSaveButton(bool red)
        {
            bnavPlanuSar.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvPlanuSar.EndEditX()) return false;
            var ret = bsPlanuSar.SaveTable();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsPlanuSar.HasChanges());
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
            SetSaveButton(bsPlanuSar.HasChanges());
        }

        private void bsPlanuSar_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvPlanuSar_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void bsPlanuSar_MyBeforeRowInsert(MyRowUpdateEventArgs e)
        {
            var dr = e.DataRow as KlonsADataSet.TIMEPLAN_LISTRow;
            if (dr == null) return;
            dr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_TIMEPLAN_LIST_ID();
        }

        private void dgvPlanuSar_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[dgcSnr.Index].Value = dgvPlanuSar.Rows.Count;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

    }
}

