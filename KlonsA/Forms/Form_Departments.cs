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
    public partial class Form_Departments : MyFormBaseA
    {
        public Form_Departments()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            cbActive.SelectedIndex = 0;
            InsertInToolStrip(toolStrip1, tbID, 0);
            InsertInToolStrip(toolStrip1, tbSearch, 2);
            InsertInToolStrip(toolStrip1, cbActive, 4);
        }

        private void Form_Departments_Load(object sender, EventArgs e)
        {
            if (Modal || IsMyDialog)
                tbID.Select();

            CheckSave();
        }

        private void SelectCurrent()
        {
            if (dgvDep.CurrentRow == null || dgvDep.CurrentRow.IsNewRow) return;
            var dr = bsDep.CurrentDataRow as KlonsA.DataSets.KlonsADataSet.DEPARTMENTSRow;
            if (!dgvDep.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            if (!this.IsMyDialog) return;
            SetSelectedValue(dr.ID);
        }

        private void dgvDep_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDep.CurrentRow == null || dgvDep.CurrentRow.IsNewRow) return;
            if (e.ColumnIndex == dgcDepId.Index || e.ColumnIndex == dgcDepDescr.Index)
            {
                SelectCurrent();
            }
        }

        private void tbID_RowSelectedEvent(object sender, KlonsLIB.Components.RowSelectedEventArgs e)
        {
            if (e.RowNr == -1)
            {
                SetSelectedValue(null, true);
                return;
            }
            if (bsDep.Current == null) return;
            SelectCurrent();
        }

        public void DeleteCurrent()
        {
            bnavDep.DeleteCurrent();
            SaveData();
        }

        private void dgvDep_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvDep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null, true);
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.SelectAll();
        }

        private void tbID_Enter(object sender, EventArgs e)
        {
            tbID.SelectAll();
        }

        private void CheckFilter()
        {
            string s1 = tbSearch.Text;
            int k = cbActive.SelectedIndex;
            string s2 = k == 0 ? "(USED = 1)" : null;
            if (s1 != "")
            {
                s1 = string.Format("(DESCR LIKE '*{0}*')", s1);
            }
            if (s2 != null)
            {
                if (s1 == "")
                    s1 = s2;
                else
                    s1 = s1 + " AND " + s2;
            }
            if (s1 == "")
            {
                bsDep.RemoveFilter();
            }
            else
            {
                bsDep.Filter = s1;
            }
        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckFilter();
        }


        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                CheckFilter();
        }

        private void bnavDep_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvDep_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void SetSaveButton(bool red)
        {
            bnavDep.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvDep.EndEditX()) return false;
            var ret = bsDep.SaveTable();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsDep.HasChanges());
        }

        private void dgvDep_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
            CheckSave();
        }

        private void bsDep_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            SetSaveButton(bsDep.HasChanges());
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void dgvDep_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcDepUsedDT1.Index || e.ColumnIndex == dgcDepUsedDT2.Index)
            {
                Utils.DGVParseDateCell(e);
            }
        }
    }
}
