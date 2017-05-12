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
using KlonsLIB.Components;
using KlonsLIB.Data;
using KlonsLIB.Forms;

namespace KlonsA.Forms
{
    public partial class Form_PieceWorkCatalog : MyFormBaseA
    {
        public Form_PieceWorkCatalog()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            SetupToolStrips();
            cbCat.SelectedIndex = -1;
            cbActive.SelectedIndex = 0;

            var timeunits = SomeDataDefs.MakeListB("0", "st", "1", "min", "2", "sec");
            dgcTimeUnit.DataSource = timeunits;
            dgcTimeUnit.DisplayMember = "Val";
            dgcTimeUnit.ValueMember = "Key";
        }

        private void Form_PieceWorkCatalog_Load(object sender, EventArgs e)
        {
            MyData.DataSetKlons.PIECEWORK_CATALOG.ColumnChanged += PIECEWORK_CATALOG_ColumnChanged;
            CheckSave();
        }

        private void Form_PieceWorkCatalog_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlons.PIECEWORK_CATALOG.ColumnChanged -= PIECEWORK_CATALOG_ColumnChanged;
        }

        private void PIECEWORK_CATALOG_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            var dr = e.Row as KlonsADataSet.PIECEWORK_CATALOGRow;
            if (dr == null) return;

            if (e.Column == MyData.DataSetKlons.PIECEWORK_CATALOG.TIMEUNITColumn ||
                e.Column == MyData.DataSetKlons.PIECEWORK_CATALOG.TIMEUSEColumn)
            {
                float tm = dr.TIMEUSE;
                if (dr.TIMEUNIT == 1) tm /= 60.0f;
                else if (dr.TIMEUNIT == 2) tm /= 3600.0f;
                tm = (float)Math.Round(tm, 7);
                if (dr.TIMEUSEINHOURS != tm) dr.TIMEUSEINHOURS = tm;
            }
        }

        private void SetupToolStrips()
        {
            InsertInToolStrip(toolStrip1, cbCat, 0);
            InsertInToolStrip(toolStrip1, tbFilter, 2);
            InsertInToolStrip(toolStrip1, cbActive, 4);
        }

        private void SelectCurrent()
        {
            if (dgvSar.CurrentRow == null || dgvSar.CurrentRow.IsNewRow) return;
            var dr = bsSar.CurrentDataRow as KlonsADataSet.PIECEWORK_CATALOGRow;
            if (!dgvSar.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            if (!this.IsMyDialog) return;
            int id = dr.ID;
            SetSelectedValue(id);
        }

        public void DeleteCurrent()
        {
            bnavSar.DeleteCurrent();
            SaveData();
        }

        private void dgvSar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgcCode.Index || e.ColumnIndex == dgcDescr.Index)
            {
                SelectCurrent();
            }
            if (e.ColumnIndex == dgcIDS.Index)
            {
                GetIDKFromDialog();
            }
        }

        public void GetIDKFromDialog()
        {
            if (bsSar.Count == 0 || bsSar.Current == null) return;
            if (dgvSar.CurrentRow == null || dgvSar.CurrentRow.IsNewRow) return;
            var fm = new Form_PieceWorkCatStruct();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            var dr = (dgvSar.CurrentRow.DataBoundItem as DataRowView).Row as KlonsADataSet.PIECEWORK_CATALOGRow;
            if (dgvSar.CurrentCell != null)
            {
                try
                {
                    int ids = fm.SelectedValueInt;

                    dgvSar.BeginEdit(false);
                    var c = dgvSar.EditingControl as MyDgvMcComboBox;
                    c.SelectedValue = ids;

                    dgvSar.EndEdit();
                }
                catch (Exception) { }
            }
        }

        private void tbCode_RowSelectedEvent(object sender, KlonsLIB.Components.RowSelectedEventArgs e)
        {
            SetSelectedValue(e.Value);
        }

        private void dgvSar_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvSar.CurrentCell == null) return;
            if (e.KeyCode == Keys.F5)
            {
                if (dgvSar.CurrentCell.ColumnIndex == dgcIDS.Index)
                {
                    GetIDKFromDialog();
                    e.Handled = true;
                    return;
                }
            }
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

        private void dgvSar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null);
            }
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void tbFilter_Enter(object sender, EventArgs e)
        {
            tbFilter.SelectAll();
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

            if (!string.IsNullOrEmpty(cbCat.Text) && cbCat.SelectedValue != null)
            {
                string s3 = (string)cbCat.SelectedValue;
                if (!string.IsNullOrEmpty(s3))
                {
                    s3 = string.Format("(KATCODE = '{0}')", s3);
                }
                if (string.IsNullOrEmpty(s1))
                {
                    s1 = s3;
                }
                else
                { 
                    s1 = s1 + " AND " + s3;
                }
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

        private void cbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckFilter();
        }

        private void bnavSar_ItemDeleting(object sender, CancelEventArgs e)
        {
            if (dgvSar.CurrentRow == null || dgvSar.CurrentRow.IsNewRow)
            {
                e.Cancel = true;
                return;
            }
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

        private void dgvSar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int ci = e.ColumnIndex;
            int ri = e.RowIndex;
            if (ri == -1 || ci == -1) return;
            dgvSar.InvalidateRow(ri);
        }

    }
}
