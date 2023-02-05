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
using KlonsFM.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Data;
using KlonsFM.UI;
using KlonsLIB.Components;

namespace KlonsFM.FormsM
{
    public partial class FormM_Items : MyFormBaseF, IMyDgvTextboxEditingControlEvents2
    {
        public FormM_Items()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void FormM_Items_Load(object sender, EventArgs e)
        {
            tbCode.Focus();
            tbItemsCatFilter.SelectedIndex = -1;
            if (SelectedCode != null)
                tbCode.Text = SelectedCode;

            MyData.DataSetKlonsM.M_ITEMS.ColumnChanged += M_ITEMS_ColumnChanged;
        }
        private void FormM_Items_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlonsM.M_ITEMS.ColumnChanged -= M_ITEMS_ColumnChanged;
        }

        private void M_ITEMS_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            var table = MyData.DataSetKlonsM.M_ITEMS;
            var dr = e.Row as KlonsMDataSet.M_ITEMSRow;
            if (e.Column == table.CATColumn)
            {
                int isservice = dr.M_ITEMS_CATRow.ISSERVICES;
                int isproduced = dr.M_ITEMS_CATRow.ISPRODUCED;
                if (dr.ISSERVICE != isservice)
                    dr.ISSERVICE = isservice;
                if (dr.ISPRODUCED != isproduced)
                    dr.ISPRODUCED = isproduced;
            }
        }

        public string SelectedCode = null;
        private int FilterItemsCat = -1;
        private string FilterText = null;

        public static string GetItemCode(string code)
        {
            var fm = new FormM_Items();
            //fm.tbCode.Text = code;
            fm.SelectedCode = code;
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedCode;
        }

        public static int? GetItemId(string code)
        {
            var fm = new FormM_Items();
            //fm.tbCode.Text = code;
            fm.SelectedCode = code;
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedValueInt;
        }

        private void SelectCurrent()
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var dr = bsItems.CurrentDataRow as KlonsMDataSet.M_ITEMSRow;
            if (!dgvRows.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            int id = dr.ID;
            SelectedCode = dr.BARCODE;
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }

        public void DoFilter()
        {
            int filteritemscat = tbItemsCatFilter.SelectedIndex;
            string filteritemscatcode = "";
            if (filteritemscat > -1)
            {
                var dr = (tbItemsCatFilter.SelectedItem as DataRowView)?.Row as KlonsMDataSet.M_ITEMS_CATRow;
                if (dr == null) return;
                filteritemscat = dr.ID;
                filteritemscatcode = dr.CODE;
            }
            string filtertext = tbFilter.Text;
            if (filteritemscat == FilterItemsCat && filtertext == FilterText) return;
            FilterItemsCat = filteritemscat;
            FilterText = filtertext;
            if (filteritemscat == -1 && string.IsNullOrEmpty(filtertext))
            {
                bsItems.RemoveFilter();
                return;
            }
            var fb = new FilterBuilder();
            if (filteritemscat > -1)
                fb.AddFilterPart($"Parent(FK_M_ITEMS_CAT).CODE LIKE '{filteritemscatcode}*'");
            if (!string.IsNullOrEmpty(filtertext))
                fb.AddFilterPart($"NAME LIKE '*{filtertext}*'");
            bsItems.Filter = fb.FilterString;
        }

        private int SearchText(string text, int colindex,
            int startindex = 0, bool forward = true)
        {
            string propname = dgvRows.Columns[colindex].DataPropertyName;
            if (bsItems.Count == 0) return -1;
            if (startindex < 0 || startindex >= bsItems.Count) return -1;
            if (string.IsNullOrEmpty(text)) return -1;
            if (startindex == 0 && !forward) return -1;
            if (startindex == bsItems.Count - 1 && forward) return -1;
            var rv = bsItems[startindex] as DataRowView;
            if (rv == null) return -1;
            int colnr = rv.Row.Table.Columns.IndexOf(propname);
            if (colnr == -1) return -1;
            int di = forward ? 1 : -1;
            object o;
            string val;
            text = text.ToLower();
            for (int i = startindex; i >= 0 && i < bsItems.Count; i += di)
            {
                var rv1 = bsItems[i] as DataRowView;
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
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            if (!dgvRows.EndEditX()) return;

            int startindex = dgvRows.CurrentRow.Index;
            startindex = fromfirst ? 0 : (forward ? startindex + 1 : startindex - 1);
            string text = tsbFind.Text;
            if (text == "") return;
            int newindex = SearchText(text, dgvRows.CurrentCell.ColumnIndex, startindex, forward);
            if (newindex == -1)
            {
                MyMainForm.ShowInfo("Teksts [" + text + "] netika atrasts.");
                return;
            }
            dgvRows.CurrentCell = dgvRows[dgvRows.CurrentCell.ColumnIndex, newindex];
        }


        private void dgvRowGetCellValue(object sender, int colind)
        {
            Action<int> act =
                value =>
                {
                    try
                    {
                        if (value > -1 && dgvRows.CurrentCell != null)
                        {
                            dgvRows.BeginEdit(false);
                            var code = MyData.DataSetKlonsM.M_ITEMS_CAT.FindByID(value).CODE;
                            dgvRows.EditingControl.Text = code;
                            dgvRows.EndEdit();
                        }

                        dgvRows.Select();
                        if (dgvRows.EditingControl != null)
                            ActiveControl = dgvRows.EditingControl;
                    }
                    finally
                    {
                        dgvRows.GoingToDialog = false;
                    }
                };
            if (colind == dgcCat.Index)
            {
                dgvRows.GoingToDialog = true;
                MyMainForm.ShowFormMDialog<FormM_ItemsCat>(act);
                return;
            }

        }

        public int? GetCatId(string code)
        {
            return FormM_ItemsCat.GetItemsCatId(code);
        }

        public int? GetStoreId(string code)
        {
            return FormM_Stores.GetStoreId(code, EStoreType.Noliktava);
        }

        public int? GetPVNRateId(string code)
        {
            return FormM_PVNRates.GetPVNRateId();
        }

        public int? GetUnitId(string code)
        {
            return FormM_Units.GetUnitsId();
        }


        private bool CanEditCurrentCell()
        {
            if (bsItems.Count == 0 || bsItems.Current == null) return false;
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return false;
            if (dgvRows.CurrentCell == null) return false;
            return true;
        }

        private void SetCurrentCellValue(int value)
        {
            if (dgvRows.CurrentCell == null) return;
            try
            {
                dgvRows.BeginEdit(false);
                var c = dgvRows.EditingControl as KlonsLIB.Components.MyMcComboBox;
                if (c != null) c.SelectedValue = value;
                var c2 = dgvRows.EditingControl as KlonsLIB.Components.MyPickRowTextBox2;
                if (c2 != null) c2.SelectedValue = value;
                dgvRows.EndEdit();
            }
            catch (Exception) { }
        }

        public void GetCatId()
        {
            if (!CanEditCurrentCell()) return;
            var dv = dgvRows.CurrentCell.FormattedValue as string;
            var rt = GetCatId(dv);
            if (rt == null) return;
            SetCurrentCellValue(rt.Value);
        }

        public void GetStoreId()
        {
            if (!CanEditCurrentCell()) return;
            var dv = dgvRows.CurrentCell.FormattedValue as string;
            var rt = GetStoreId(dv);
            if (rt == null) return;
            SetCurrentCellValue(rt.Value);
        }

        public void GetPVNRateId()
        {
            if (!CanEditCurrentCell()) return;
            var dv = dgvRows.CurrentCell.FormattedValue as string;
            var rt = GetPVNRateId(dv);
            if (rt == null) return;
            SetCurrentCellValue(rt.Value);
        }

        public void GetUnitId()
        {
            if (!CanEditCurrentCell()) return;
            var dv = dgvRows.CurrentCell.FormattedValue as string;
            var rt = GetUnitId(dv);
            if (rt == null) return;
            SetCurrentCellValue(rt.Value);
        }


        private bool GetRowCellValue(object sender, int colind)
        {
            if (colind == dgcCat.Index)
            {
                GetCatId();
                return true;
            }
            if (colind == dgcStore1.Index)
            {
                GetStoreId();
                return true;
            }
            if (colind == dgcPVNRate.Index)
            {
                GetPVNRateId();
                return true;
            }
            if (colind == dgcUints.Index)
            {
                GetUnitId();
                return true;
            }
            return false;
        }


        public override bool SaveData()
        {
            if (!dgvRows.EndEditX()) return false;

            if (!this.Validate()) return false;
            try
            {
                DataTasks.SetNewIDs(myAdapterManager1);
                bool rt = myAdapterManager1.UpdateAll();
                CheckSave();
                return rt;
            }
            catch (Exception e)
            {
                CheckSave();
                Form_Error.ShowException(e, "Neizdevās saglabāt izmaiņas.");
                return false;
            }
        }

        private void CheckSave()
        {
            SetSaveButton(bsItems.HasChanges());
        }

        private void SetSaveButton(bool red)
        {
            bNav.SetSaveButtonRed(red);
        }

        public void DeleteCurrent()
        {
            bNav.DeleteCurrent();
            SaveData();
        }

        private bool IsRow0(int rownr)
        {
            if (rownr == dgvRows.NewRowIndex) return false;
            var dr = dgvRows.GetDataRow(rownr) as KlonsMDataSet.M_ITEMSRow;
            if (dr == null) return false;
            return dr.ID == 1;
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvRows_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void bsItems_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvRows_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvRows.CurrentCell == null) return;
            if (e.KeyCode == Keys.F4)
            {
                if (IsRow0(dgvRows.CurrentCell.ColumnIndex)) return;
                var rt = GetRowCellValue(dgvRows, dgvRows.CurrentCell.ColumnIndex);
                e.Handled = rt;
                return;
            }
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvRows.EndEdit()) return;
                dgvRows.MoveToNewRow();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                SelectedCode = null;
                SetSelectedValue(null, true);
                e.Handled = true;
            }
        }

        private void dgvRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SelectedCode = null;
                SetSelectedValue(null, true);
            }
        }

        private void dgvRows_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = e.Row.IsNewRow || IsRow0(e.Row.Index) || !AskCanDelete();
        }

        private void bNav_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = IsRow0(bsItems.Position) || !AskCanDelete();
        }

        private void dgvRows_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            if (e.ColumnIndex == dgcCode.Index)
            {
                SelectCurrent();
                return;
            }
            if (e.ColumnIndex == dgcCat.Index)
            {
                GetCatId();
                //dgvRowGetCellValue(sender, e.ColumnIndex);
                return;
            }
            if (e.ColumnIndex == dgcStore1.Index)
            {
                GetStoreId();
                return;
            }
            if (e.ColumnIndex == dgcPVNRate.Index)
            {
                GetPVNRateId();
                return;
            }
            if (e.ColumnIndex == dgcUints.Index)
            {
                GetUnitId();
                return;
            }
        }

        private void dgvRows_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dgvRows.NewRowIndex) return;
            if (IsRow0(e.RowIndex))
                e.Cancel = true;
        }

        private void tbCode_RowSelectedEvent(object sender, KlonsLIB.Components.RowSelectedEventArgs e)
        {
            if (e.RowNr == -1 || e.Value == null)
            {
                SelectedCode = null;
                SetSelectedValue(null, true);
                return;
            }
            SelectCurrent();
        }

        private void tbCode_Enter(object sender, EventArgs e)
        {
            tbCode.SelectAll();
        }

        private void tbItemsCatFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbItemsCatFilter.SelectedIndex == -1 && FilterItemsCat == -1) return;
            DoFilter();
        }

        private void tbItemsCatFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                tbItemsCatFilter.Text = null;
                DoFilter();
                e.Handled = true;
            }
        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                DoFilter();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                tbFilter.Text = null;
                DoFilter();
                e.Handled = true;
            }
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SearchText();
                dgvRows.Focus();
                e.Handled = true;
                return;
            }
        }

        private void tsbFindPrev_Click(object sender, EventArgs e)
        {
            SearchText(false, false);
            dgvRows.Focus();
        }

        private void tsbFindNext_Click(object sender, EventArgs e)
        {
            SearchText(false, true);
            dgvRows.Focus();
        }

        private void tsbFind_Enter(object sender, EventArgs e)
        {
            tsbFind.Text = "";
        }

        void IMyDgvTextboxEditingControlEvents2.OnButtonClicked(MyDgvTextboxEditingControl2 control)
        {
            if (control.DataSource == bsItemsCat)
            {
                GetCatId();
                return;
            }
            if (control.DataSource == bsStore)
            {
                GetStoreId();
                return;
            }
            if (control.DataSource == bsPVNRate)
            {
                GetPVNRateId();
                return;
            }
            if (control.DataSource == bsUnits)
            {
                GetUnitId();
                return;
            }
        }

        private void tbItemsCatFilter_ButtonClicked(object sender, EventArgs e)
        {
            var cat_code = FormM_ItemsCat.GetItemsCatCode(tbItemsCatFilter.Text);
            if (string.IsNullOrEmpty(cat_code)) return;
            tbItemsCatFilter.Text = cat_code;
        }

        private void aktuālieArtikulaAtlikumiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var dr_item = bsItems.CurrentDataRow as KlonsMDataSet.M_ITEMSRow;
            var fm = MyMainForm.ShowForm(typeof(FormM_ItemCurrentStock)) as FormM_ItemCurrentStock;
            fm.MakeReport(dr_item.ID);

            //var fm = new FormM_ItemCurrentStock();
            //fm.MakeReport(dr_item.ID);
            //fm.ShowDialog(this);
        }

    }
}
