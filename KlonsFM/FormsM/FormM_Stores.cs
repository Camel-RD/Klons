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
using KlonsLIB.Misc;
using KlonsFM.UI;
using KlonsLIB.Components;

namespace KlonsFM.FormsM
{
    public partial class FormM_Stores : MyFormBaseF, IMyDgvTextboxEditingControlEvents2
    {
        public FormM_Stores()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void FormM_Stores_Load(object sender, EventArgs e)
        {
            tbCode.Focus();
            if (FilterStoreType == -1)
            {
                cbType.SelectedIndex = -1;
            }
            else
            {
                int k = bsStoreTypeFilter.Find("ID", FilterStoreType);
                cbType.SelectedIndex = k;
            }
        }

        public string SelectedCode = null;
        private int FilterStoreType = -1;
        private string FilterText = null;


        public static string GetStoreCode(string code, EStoreType storetypefilter = EStoreType.Nenoteikts)
        {
            var fm = new FormM_Stores();
            fm.tbCode.Text = code;
            if (storetypefilter != EStoreType.Nenoteikts)
            {
                fm.FilterStoreType = (int)storetypefilter;
                fm.DoFilterA();
            }
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedCode;
        }

        public static int? GetStoreId(string code, EStoreType storetypefilter = EStoreType.Nenoteikts)
        {
            var fm = new FormM_Stores();
            fm.tbCode.Text = code;
            if (storetypefilter != EStoreType.Nenoteikts)
            {
                fm.FilterStoreType = (int)storetypefilter;
                fm.DoFilterA();
            }
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedValueInt;
        }

        public static int? GetStoreId(int? idstore, EStoreType storetypefilter = EStoreType.Nenoteikts)
        {
            var fm = new FormM_Stores();
            if (idstore != null)
                fm.tbCode.SelectedValue = idstore.Value;
            if (storetypefilter != EStoreType.Nenoteikts)
            {
                fm.FilterStoreType = (int)storetypefilter;
                fm.DoFilterA();
            }
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedValueInt;
        }

        private void SelectCurrent()
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var dr = bsStores.CurrentDataRow as KlonsMDataSet.M_STORESRow;
            if (!dgvRows.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            int id = dr.ID;
            SelectedCode = dr.CODE;
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }

        public void DoFilter()
        {
            int filterstoretype = -1;
            if (cbType.SelectedValue != null)
                filterstoretype = (int)cbType.SelectedValue;
            string filtertext = tbFilter.Text;
            if (filterstoretype == FilterStoreType && filtertext == FilterText) return;
            FilterStoreType = filterstoretype;
            FilterText = filtertext;
            DoFilterA();
        }

        public void DoFilterA()
        {
            if (FilterStoreType == -1 && string.IsNullOrEmpty(FilterText))
            {
                bsStores.RemoveFilter();
                return;
            }
            var fb = new FilterBuilder();
            if (FilterStoreType > -1)
                fb.AddFilterPart($"TP = {FilterStoreType} OR ID = 1");
            if (!string.IsNullOrEmpty(FilterText))
                fb.AddFilterPart($"NAME LIKE '*{FilterText}*' OR ADDR LIKE '*{FilterText}*'");
            bsStores.Filter = fb.FilterString;
        }

        private int SearchText(string text, int colindex,
            int startindex = 0, bool forward = true)
        {
            string propname = dgvRows.Columns[colindex].DataPropertyName;
            if (bsStores.Count == 0) return -1;
            if (startindex < 0 || startindex >= bsStores.Count) return -1;
            if (string.IsNullOrEmpty(text)) return -1;
            if (startindex == 0 && !forward) return -1;
            if (startindex == bsStores.Count - 1 && forward) return -1;
            var rv = bsStores[startindex] as DataRowView;
            if (rv == null) return -1;
            int colnr = rv.Row.Table.Columns.IndexOf(propname);
            if (colnr == -1) return -1;
            int di = forward ? 1 : -1;
            object o;
            string val;
            text = text.ToLower();
            for (int i = startindex; i >= 0 && i < bsStores.Count; i += di)
            {
                var rv1 = bsStores[i] as DataRowView;
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
            if (colind == dgcAcc21.Index || colind == dgcAcc23.Index || colind == dgcAcc53.Index)
            {
                dgvRows.GoingToDialog = true;
                //this.AutoValidate = AutoValidate.Disable;
                MyMainForm.ShowFormMDialog<FormM_Accounts>(act);
                return;
            }

        }

        public string GetAccountCode(string code, EAccountType accounttypefilter = EAccountType.Nenoteikts)
        {
            return FormM_Accounts.GetAccCode(code, accounttypefilter);
        }

        public int? GetStoreTypeId(string code)
        {
            return FormM_StoreTypes.GetStoreTypeId(code);
        }

        public int? GetPVNTypeId(string code)
        {
            return FormM_PVNTypes.GetPVNTypeId(code);
        }
        private bool CanEditCurrentCell()
        {
            if (bsStores.Count == 0 || bsStores.Current == null) return false;
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

        public void GetAccountCode()
        {
            if (!CanEditCurrentCell()) return;
            var dv = dgvRows.CurrentCell.FormattedValue as string;
            EAccountType accounttypefilter = EAccountType.Nenoteikts;
            int cind = dgvRows.CurrentCell.ColumnIndex;
            if (cind == dgcAcc21.Index) accounttypefilter = EAccountType.Noliktava;
            else if (cind == dgcAcc23.Index) accounttypefilter = EAccountType.Debitori;
            else if (cind == dgcAcc53.Index) accounttypefilter = EAccountType.Kreditori;
            var rt = GetAccountCode(dv, accounttypefilter);
            if (rt == null) return;
            SetCurrentCellValue(rt);
        }

        public void GetStoreTypeId()
        {
            if (!CanEditCurrentCell()) return;
            var dv = dgvRows.CurrentCell.FormattedValue as string;
            var rt = GetStoreTypeId(dv);
            if (!rt.HasValue) return;
            SetCurrentCellValue(rt.Value);
        }

        public void GetPVNTypeId()
        {
            if (!CanEditCurrentCell()) return;
            var dv = dgvRows.CurrentCell.FormattedValue as string;
            var rt = GetPVNTypeId(dv);
            if (!rt.HasValue) return;
            SetCurrentCellValue(rt.Value);
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
            SetSaveButton(bsStores.HasChanges());
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
            var dr = dgvRows.GetDataRow(rownr) as KlonsMDataSet.M_STORESRow;
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

        private void bsStores_ListChanged(object sender, ListChangedEventArgs e)
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
                if (Utils.IN(cind, dgcAcc21.Index, dgcAcc23.Index, dgcAcc53.Index))
                {
                    GetAccountCode();
                    e.Handled = true;
                    return;
                }
                if (cind == dgcTP.Index)
                {
                    GetStoreTypeId();
                    e.Handled = true;
                    return;
                }
                if (cind == dgcPVNTp.Index)
                {
                    GetPVNTypeId();
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
            e.Cancel = IsRow0(bsStores.Position) || !AskCanDelete();
        }

        private void dgvRows_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            if (e.ColumnIndex == dgcCode.Index)
            {
                SelectCurrent();
                return;
            }
            if (e.ColumnIndex == dgcAcc21.Index || e.ColumnIndex == dgcAcc23.Index ||
                e.ColumnIndex == dgcAcc53.Index)
            {
                GetAccountCode();
                //dgvRowsGetCellValue(sender, e.ColumnIndex);
                return;
            }
            if (e.ColumnIndex == dgcTP.Index)
            {
                GetStoreTypeId();
                return;
            }
            if (e.ColumnIndex == dgcPVNTp.Index)
            {
                GetPVNTypeId();
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

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoFilter();
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

        private void dgvRows_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (FilterStoreType > -1)
            {
                e.Row.Cells[dgcTP.Index].Value = FilterStoreType;
            }
        }

        public void ShowAktuālieAtlikumi()
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var dr_store = bsStores.CurrentDataRow as KlonsMDataSet.M_STORESRow;
            var frm = MyMainForm.ShowForm(typeof(FormM_StoreCurrentStock)) as FormM_StoreCurrentStock;
            frm.MakeReport(dr_store.ID);
        }

        public void ShowAddresses()
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var dr_store = bsStores.CurrentDataRow as KlonsMDataSet.M_STORESRow;
            FormM_Addresses.GetAddresstId(dr_store.ID);
        }

        public void ShowContacts()
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var dr_store = bsStores.CurrentDataRow as KlonsMDataSet.M_STORESRow;
            FormM_Contacts.GetContactId(dr_store.ID);
        }

        public void ShowBankAccounts()
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var dr_store = bsStores.CurrentDataRow as KlonsMDataSet.M_STORESRow;
            FormM_BankAccounts.GetBankAccount(dr_store.ID);
        }

        public void ShowVehicles()
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var dr_store = bsStores.CurrentDataRow as KlonsMDataSet.M_STORESRow;
            FormM_Vehicles.GetVehicleId(dr_store.ID);
        }

        private void btAtlikumi_Click(object sender, EventArgs e)
        {
            ShowAktuālieAtlikumi();
        }

        private void btAddresses_Click(object sender, EventArgs e)
        {
            ShowAddresses();
        }

        private void btContacts_Click(object sender, EventArgs e)
        {
            ShowContacts();
        }

        private void btBankAccounts_Click(object sender, EventArgs e)
        {
            ShowBankAccounts();
        }

        private void btVehicles_Click(object sender, EventArgs e)
        {
            ShowVehicles();
        }

        void IMyDgvTextboxEditingControlEvents2.OnButtonClicked(MyDgvTextboxEditingControl2 control)
        {
            if (control.DataSource == bsStoreType)
            {
                GetStoreTypeId();
                return;
            }
            if (control.DataSource == bsPVNType)
            {
                GetPVNTypeId();
                return;
            }
            if (control.DataSource == bsAccounts21 ||
                control.DataSource == bsAccounts23 ||
                control.DataSource == bsAccounts53)
            {
                GetAccountCode();
                return;
            }
        }

        private void cbType_ButtonClicked(object sender, EventArgs e)
        {
            object oid = cbType.SelectedValue;
            int? id = oid == null ? null : (int?)oid;
            id = FormM_StoreTypes.GetStoreTypeId(id);
            if (id == null) return;
            cbType.SelectedValue = id.Value;
            DoFilter();
        }

        private void cbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete)
            {
                cbType.Text = null;
                DoFilter();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                DoFilter();
            }
        }

    }
}
