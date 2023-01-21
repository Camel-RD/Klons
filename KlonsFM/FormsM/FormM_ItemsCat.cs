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
using KlonsLIB.Misc;

namespace KlonsFM.FormsM
{
    public partial class FormM_ItemsCat : MyFormBaseF
    {
        public FormM_ItemsCat()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            dgcMethod.DataSource = SomeDataDefs.StoreCalcMethods;
            dgcMethod.DisplayMember = "Val";
            dgcMethod.ValueMember = "Key";
        }

        private void FormM_ItemsCat_Load(object sender, EventArgs e)
        {
            tbCode.Focus();

            if (SelectedCode != null)
                tbCode.Text = SelectedCode;
        }

        public string SelectedCode = null;
        private string FilterText = null;


        public static string GetItemsCatCode(string code)
        {
            var fm = new FormM_ItemsCat();
            //fm.tbCode.Text = code;
            fm.SelectedCode = code;
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedCode;
        }

        public static int? GetItemsCatId(string code)
        {
            var fm = new FormM_ItemsCat();
            //fm.tbCode.Text = code;
            fm.SelectedCode = code;
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedValueInt;
        }

        public void FindItemsCat(string code)
        {
            int k = bsItemsCat.Find("CODE", code);
            if (k == -1) return;
            bsItemsCat.Position = k;
        }

        private void SelectCurrent()
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var dr = bsItemsCat.CurrentDataRow as KlonsMDataSet.M_ITEMS_CATRow;
            if (!dgvRows.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            int id = dr.ID;
            SelectedCode = dr.CODE;
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }

        public string GetAccountCode(string code, EAccountType accounttypefilter = EAccountType.Nenoteikts)
        {
            return FormM_Accounts.GetAccCode(code, accounttypefilter);
        }

        private bool CanEditCurrentCell()
        {
            if (bsItemsCat.Count == 0 || bsItemsCat.Current == null) return false;
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return false;
            if (dgvRows.CurrentCell == null) return false;
            return true;
        }

        private void SetCurrentCellValue(string value)
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

        public void GetAccountCode()
        {
            if (!CanEditCurrentCell()) return;
            var dv = dgvRows.CurrentCell.FormattedValue as string;
            EAccountType accounttypefilter = EAccountType.Nenoteikts;
            int cind = dgvRows.CurrentCell.ColumnIndex;
            if (cind == dgcAcc6.Index) accounttypefilter = EAccountType.Ieņēmumi;
            else if (cind == dgcAcc7.Index) accounttypefilter = EAccountType.Izmaksas;
            var rt = GetAccountCode(dv, accounttypefilter);
            if (rt == null) return;
            SetCurrentCellValue(rt);
        }


        public void DoFilter()
        {
            string filtertext = tbFilter.Text;
            if (filtertext == FilterText) return;
            FilterText = filtertext;
            if (string.IsNullOrEmpty(filtertext))
            {
                bsItemsCat.RemoveFilter();
                return;
            }
            bsItemsCat.Filter = $"NAME LIKE '*{filtertext}*' OR CODE LIKE '*{filtertext}*'";
        }

        private int SearchText(string text, int colindex,
            int startindex = 0, bool forward = true)
        {
            string propname = dgvRows.Columns[colindex].DataPropertyName;
            if (bsItemsCat.Count == 0) return -1;
            if (startindex < 0 || startindex >= bsItemsCat.Count) return -1;
            if (string.IsNullOrEmpty(text)) return -1;
            if (startindex == 0 && !forward) return -1;
            if (startindex == bsItemsCat.Count - 1 && forward) return -1;
            var rv = bsItemsCat[startindex] as DataRowView;
            if (rv == null) return -1;
            int colnr = rv.Row.Table.Columns.IndexOf(propname);
            if (colnr == -1) return -1;
            int di = forward ? 1 : -1;
            object o;
            string val;
            text = text.ToLower();
            for (int i = startindex; i >= 0 && i < bsItemsCat.Count; i += di)
            {
                var rv1 = bsItemsCat[i] as DataRowView;
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


        private void dgvRowsGetCellValue(object sender, int colind)
        {
            Action<string> act =
                value =>
                {
                    try
                    {
                        if (value != null && dgvRows.CurrentCell != null)
                        {
                            dgvRows.BeginEdit(false);
                            dgvRows.EditingControl.Text = value;
                            dgvRows.EndEdit();
                        }

                        dgvRows.Select();
                        if (dgvRows.EditingControl != null)
                            ActiveControl = dgvRows.EditingControl;
                    }
                    finally
                    {
                        dgvRows.GoingToDialog = false;
                        //this.AutoValidate = AutoValidate.EnablePreventFocusChange;
                    }
                };
            if (colind == dgcAcc6.Index || colind == dgcAcc7.Index)
            {
                dgvRows.GoingToDialog = true;
                //this.AutoValidate = AutoValidate.Disable;
                MyMainForm.ShowFormMDialog<FormM_Accounts>(act);
                return;
            }
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
            SetSaveButton(bsItemsCat.HasChanges());
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
            var dr = dgvRows.GetDataRow(rownr) as KlonsMDataSet.M_ITEMS_CATRow;
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

        private void bsItemsCat_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvRows_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvRows.CurrentCell == null) return;
            if (e.KeyCode == Keys.F4)
            {
                int cind = dgvRows.CurrentCell.ColumnIndex;
                if (Utils.IN(cind, dgcAcc6.Index, dgcAcc7.Index))
                {
                    GetAccountCode();
                    //dgvRowsGetCellValue(sender, dgvRows.CurrentCell.ColumnIndex);
                    e.Handled = true;
                    return;
                }
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
            e.Cancel = IsRow0(bsItemsCat.Position) || !AskCanDelete();
        }

        private void dgvRows_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            if (e.ColumnIndex == dgcCode.Index)
            {
                SelectCurrent();
                return;
            }
            if (e.ColumnIndex == dgcAcc6.Index || e.ColumnIndex == dgcAcc7.Index)
            {
                GetAccountCode();
                //dgvRowsGetCellValue(sender, e.ColumnIndex);
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

    }
}
