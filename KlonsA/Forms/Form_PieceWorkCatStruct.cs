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
using KlonsLIB.Forms;

namespace KlonsA.Forms
{
    public partial class Form_PieceWorkCatStruct : MyFormBaseA
    {
        public Form_PieceWorkCatStruct()
        {
            InitializeComponent();
            SetupToolStrips();
            CheckMyFontAndColors();
            cbActive.SelectedIndex = 0;
        }

        private void Form_PieceWorkCatStruct_Load(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void SetupToolStrips()
        {
            var si1 = InsertInToolStrip(toolStrip1, tbCode, 0);
            InsertInToolStrip(toolStrip1, tbFilter, 2);
            InsertInToolStrip(toolStrip1, cbActive, 4);
        }

        private void SelectCurrent()
        {
            if (dgvSar.CurrentRow == null || dgvSar.CurrentRow.IsNewRow) return;
            var dr = bsSar.CurrentDataRow as KlonsADataSet.PIECEWORK_CATSTRUCTRow;
            if (!dgvSar.EndEditX()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            int id = dr.ID;
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }

        public void DeleteCurrent()
        {
            bnavSar.DeleteCurrent();
            SaveData();
        }

        private void dgvSar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgcCode.Index)
            {
                SelectCurrent();
            }
        }

        private void tbCode_RowSelectedEvent(object sender, KlonsLIB.Components.RowSelectedEventArgs e)
        {
            SelectCurrent();
        }

        private void dgvSar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }
        }

        private void dgvSar_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvSar.CurrentCell == null) return;
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                dgvSar.MoveToNewRow();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                DeleteCurrent();
                e.Handled = true;
            }
        }

        private void dgvSar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null);
            }
        }

        private void tbFilter_Enter(object sender, EventArgs e)
        {
            tbFilter.SelectAll();
        }

        private void tbFilter_MouseDown(object sender, MouseEventArgs e)
        {
            tbFilter.SelectAll();
        }

        private void tbCode_Enter(object sender, EventArgs e)
        {
            tbCode.SelectAll();
        }

        private void tbCode_MouseDown(object sender, MouseEventArgs e)
        {
            tbCode.SelectAll();
        }

        private void CheckFilter()
        {
            string s1 = tbFilter.Text;
            int k = cbActive.SelectedIndex;
            string s2 = k == 0 ? "(USED = 1)" : null;
            if (s1 != "")
            {
                s1 = string.Format("(CODE LIKE '*{0}*')", s1);
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
                bsSar.RemoveFilter();
            }
            else
            {
                bsSar.Filter = s1;
            }
        }
        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckFilter();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                CheckFilter();
        }

        private void bnavSar_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvSar_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void SetSaveButton(bool red)
        {
            bnavSar.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvSar.EndEditX()) return false;
            if (!this.Validate()) return false;
            try
            {
                DataTasks.SetNewIDs(myAdapterManager1);
                myAdapterManager1.UpdateAll();
                CheckSave();
            }
            catch (Exception e)
            {
                CheckSave();
                Form_Error.ShowException(e, "Neizdevâs saglabât izmaiòas.");
                return false;
            }
            return true;
        }

        private void CheckSave()
        {
            SetSaveButton(bsSar.HasChanges());
        }

        private void dgvSar_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bsSar_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }
    }
}
