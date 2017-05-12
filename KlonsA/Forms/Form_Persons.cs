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
using KlonsLIB.Misc;
using KlonsLIB.Forms;

namespace KlonsA.Forms
{
    public partial class Form_Persons : MyFormBaseA
    {
        public Form_Persons()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            ShowOnlyActive = MyData.Params.PersListOnlyUsed;

            InsertInToolStrip(toolStrip1, tbID, 0);
            InsertInToolStrip(toolStrip1, tbSearch, 2);
            InsertInToolStrip(toolStrip1, cbActive, 4);
        }

        public enum EWhatToSelect { Person, Position, Both}

        public EWhatToSelect WhatToSelect = EWhatToSelect.Person;

        public int SelectedIDP = int.MinValue;
        public int SelectedIDAM = int.MinValue;

        private void Form_Persons_Load(object sender, EventArgs e)
        {
            MyData.DataSetKlons.PERSONS.PERSONSRowChanged += PersonsOnPersonsRowChanged;
            MyData.DataSetKlons.POSITIONS.POSITIONSRowChanged += AmatiOnAmatiRowChanged;
            if (IsMdiChild) WindowState = FormWindowState.Minimized;

            splitContainer1.SplitterDistance = splitContainer1.Height
                - (int)((float)100 * ScaleFactor.Height);

            if (Modal || IsMyDialog)
                tbID.Select();

            CheckSave();
        }


        private void Form_Persons_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlons.PERSONS.PERSONSRowChanged -= PersonsOnPersonsRowChanged;
            MyData.DataSetKlons.POSITIONS.POSITIONSRowChanged -= AmatiOnAmatiRowChanged;
        }

        private void PersonsOnPersonsRowChanged(object sender, KlonsADataSet.PERSONSRowChangeEvent e)
        {
            if (e.Action == DataRowAction.Add)
            {
                var tablePersonsR = MyData.DataSetKlons.PERSONS_R;
                var rwpr = tablePersonsR.NewPERSONS_RRow();
                rwpr.IDP = e.Row.ID;
                rwpr.EDIT_DATE = DateTime.Today;
                if (!string.IsNullOrEmpty(e.Row.FNAME)) rwpr.FNAME = e.Row.FNAME;
                if (!string.IsNullOrEmpty(e.Row.LNAME)) rwpr.LNAME = e.Row.LNAME;
                if (!string.IsNullOrEmpty(e.Row.PK)) rwpr.PERSON_CODE = e.Row.PK;
                tablePersonsR.AddPERSONS_RRow(rwpr);

                var tableAmati = MyData.DataSetKlons.POSITIONS;
                var rwam = tableAmati.NewPOSITIONSRow();

                rwam.IDP = e.Row.ID;
                rwam.TITLE = "?";
                tableAmati.AddPOSITIONSRow(rwam);
            }
        }

        private void AmatiOnAmatiRowChanged(object sender, KlonsADataSet.POSITIONSRowChangeEvent e)
        {
            if (e.Action == DataRowAction.Add)
            {
                var tableAmatR = MyData.DataSetKlons.POSITIONS_R;
                var rwamr = tableAmatR.NewPOSITIONS_RRow();

                rwamr.IDA = e.Row.ID;
                rwamr.EDIT_DATE = DateTime.Today;
                if (!string.IsNullOrEmpty(e.Row.TITLE)) rwamr.TITLE= e.Row.TITLE;
                if (!string.IsNullOrEmpty(e.Row.IDDEP)) rwamr.IDDEP = e.Row.IDDEP;
                tableAmatR.AddPOSITIONS_RRow(rwamr);
            }
        }

        private void SelectCurrent()
        {
            if (dgvPersons.CurrentRow == null || dgvPersons.CurrentRow.IsNewRow) return;
            if (dgvAmati.CurrentRow == null || dgvAmati.CurrentRow.IsNewRow) return;
            var drp = bsPersons.CurrentDataRow as KlonsADataSet.PERSONSRow;
            if (drp == null) return;
            var dram = bsAmati.CurrentDataRow as KlonsADataSet.POSITIONSRow;
            if (dram == null) return;
            if (!dgvPersons.EndEdit()) return;
            if (!dgvAmati.EndEdit()) return;
            if (!SaveData()) return;
            if (drp.RowState == DataRowState.Detached) return;
            if (dram.RowState == DataRowState.Detached) return;

            if (!this.IsMyDialog) return;

            SelectedIDP = drp.ID;
            SelectedIDAM = dram.ID;

            if (WhatToSelect == 0)
            {
                int id = drp.ID;
                SetSelectedValue(id);
            }
            else
            {
                int id = dram.ID;
                SetSelectedValue(id);
            }
        }

        public void GetIDDepFromDialog()
        {
            if (bsAmati.Count == 0 || bsAmati.Current == null) return;
            if (dgvAmati.CurrentRow == null || dgvAmati.CurrentRow.IsNewRow) return;
            var fm = new Form_Departments();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            var dr = (dgvAmati.CurrentRow.DataBoundItem as DataRowView).Row as KlonsADataSet.PERSONS_RRow;
            if (dgvAmati.CurrentCell != null)
            {
                try
                {
                    dgvAmati.BeginEdit(false);
                    var c = dgvAmati.EditingControl as DataGridViewComboBoxEditingControl;
                    c.SelectedValue = fm.SelectedValue;
                    dgvAmati.EndEdit();
                }
                catch (Exception) { }
            }
        }

        private void dgvPersons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (WhatToSelect != EWhatToSelect.Person) return;
            if (e.ColumnIndex == dgcFName.Index || e.ColumnIndex == dgcLName.Index)
                SelectCurrent();
        }

        private void dgvAmati_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAmati.CurrentRow == null || dgvAmati.CurrentRow.IsNewRow ||
                dgvAmati.CurrentCell == null) return;
            int colnr = dgvAmati.CurrentCell.ColumnIndex;
            if (colnr != e.ColumnIndex) return;

            if (colnr == dgcAmatiTitle.Index)
            {
                if (WhatToSelect == EWhatToSelect.Person) return;
                SelectCurrent();
            }
            else if (colnr == dgcAmatiDep.Index)
            {
                GetIDDepFromDialog();
            }
        }

        private void tbID_RowSelectedEvent(object sender, KlonsLIB.Components.RowSelectedEventArgs e)
        {
            if(e.RowNr == -1)
            {
                SetSelectedValue(-1, true);
                return;
            }
            if (bsPersons.Current == null) return;
            SelectCurrent();
        }

        private void dgvPersons_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvAmati_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Return && 
                WhatToSelect != EWhatToSelect.Person)
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

        private void dgvAmati_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvAmati.CurrentRow == null || dgvAmati.CurrentRow.IsNewRow ||
                dgvAmati.CurrentCell == null) return;
            int colnr = dgvAmati.CurrentCell.ColumnIndex;

            if (e.KeyCode == Keys.F5)
            {
                if (colnr != dgcAmatiDep.Index) return;
                GetIDDepFromDialog();
                e.Handled = true;
                return;
            }
        }


        private void dgvPersons_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                SetSelectedValue(-1, true);
        }

        private void dgvAmati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                SetSelectedValue(-1, true);
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.SelectAll();
        }

        private void tbID_Enter(object sender, EventArgs e)
        {
            tbID.SelectAll();
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                CheckFilter();
            }
        }

        public bool ShowOnlyActive
        {
            get { return MyData.Params.PersListOnlyUsed; }
            set
            {
                if (MyData.Params.PersListOnlyUsed != value)
                {
                    MyData.Params.PersListOnlyUsed = value;
                    CheckFilter();
                }
                int k = value ? 0 : 1;
                if (cbActive.SelectedIndex != k)
                    cbActive.SelectedIndex = k;
            }
        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowOnlyActive = cbActive.SelectedIndex == 0;
        }

        private void CheckFilter()
        {
            string s1 = tbSearch.Text;
            string s2 = ShowOnlyActive ? "(USED = 1)" : null;
            if (s1 != "")
            {
                s1 = string.Format("(ZNAME LIKE '*{0}*')", s1);
            }
            if (s2 != null)
            {
                if (s1 == "")
                    s1 = s2;
                else
                    s1 = s1 + " AND " + s2;
            }
            if (s1 == "")
                bsPersons.RemoveFilter();
            else
                if(bsPersons.Filter != s1)
                    bsPersons.Filter = s1;

            if (s2 == "")
                bsAmati.RemoveFilter();
            else
                if(bsAmati.Filter != s2)
                    bsAmati.Filter = s2;
        }

        public void DeleteCurrent()
        {
            if (bnavNav.BindingSource == bsAmati)
            {
                if (bsAmati.Count == 1)
                {
                    MyMainForm.ShowWarning("Nevar dzēst darbinieka vienīgo amatu.");
                    return;
                }
            }
            bnavNav.DeleteCurrent();
            SaveData();
        }

        public bool CanDelete()
        {
            if (MyMainForm.FindForm(typeof(Form_PersonsR)) != null)
            {
                MyMainForm.ShowWarning("Vispirms jāaizver forma [Darbinieku dati].");
                return false; ;
            }
            return true;
        }

        private void bnavNav_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !CanDelete() || !AskCanDelete();
        }

        private void dgvPersons_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!CanDelete() || e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvAmati_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!CanDelete() || e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void SetSaveButton(bool red)
        {
            bnavNav.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if(!this.Validate()) return false;
            if (!dgvAmati.EndEditX()) return false;
            if (!dgvPersons.EndEditX()) return false;
            try
            {
                DataTasks.SetNewIDs(MyAdapterManager1);
                MyAdapterManager1.UpdateAll();
                CheckSave();
            }
            catch (Exception e)
            {
                CheckSave();
                Form_Error.ShowException(e, "Neizdevās saglabāt izmaiņas.");
                return false;
            }
            return true;
        }

        private void CheckSave()
        {
            SetSaveButton(bsPersons.HasChanges() || bsAmati.HasChanges());
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvPersons_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void bsPersons_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void bsAmati_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvPersons_CurrentCellChanged(object sender, EventArgs e)
        {
            dgvAmati.Enabled = !(dgvPersons.CurrentRow == null || dgvPersons.RowCount == 1 ||
                               dgvPersons.CurrentRow.IsNewRow);

        }

        private void dgvPersons_Enter(object sender, EventArgs e)
        {
            bnavNav.BindingSource = bsPersons;
            bnavNav.DataGrid = dgvPersons;
            tslLabel.Text = "Darbinieki:";
        }

        private void dgvAmati_Enter(object sender, EventArgs e)
        {
            bnavNav.BindingSource = bsAmati;
            bnavNav.DataGrid = dgvAmati;
            tslLabel.Text = "Amati:";
        }

        private void dgvPersons_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if(e.ColumnIndex == dgcUsedDt1.Index || e.ColumnIndex == dgcUsedDt2.Index ||
                e.ColumnIndex == dgcBirthDate.Index)
            {
                if (e.Value == null) return;
                if (!Utils.DGVParseDateCell(e))
                {
                    e.Value = null;
                    e.ParsingApplied = true;
                    return;
                }
            }
        }

        private void dgvAmati_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcAmatiUsedDt1.Index || e.ColumnIndex == dgcAmatiUsedDt2.Index)
            {
                if (e.Value == null) return;
                if (!Utils.DGVParseDateCell(e))
                {
                    e.Value = null;
                    e.ParsingApplied = true;
                    return;
                }
            }
        }


        private bool IsLastUsedRow(KlonsADataSet.POSITIONSRow dr)
        {
            foreach(var drv in bsAmati)
            {
                var dr2 = (drv as DataRowView)?.Row as KlonsADataSet.POSITIONSRow;
                if (dr2 == null || dr2 == dr) continue;
                if (dr2.USED == 1) return false;
            }
            return true;
        }

        private void dgvAmati_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex == dgvAmati.NewRowIndex) return;
            if (e.ColumnIndex == dgcAmatiUsed.Index)
            {
                bool val = (bool)e.FormattedValue;
                if (val) return;
                var dr = dgvAmati.GetDataRow(e.RowIndex) as KlonsADataSet.POSITIONSRow;
                if (dr == null) return;
                if (IsLastUsedRow(dr))
                {
                    MyMainForm.ShowWarning("Jābūt vismaz vienam aktīvam amatam.");
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void MyAdapterManager1_MyUpdateAll(object sender, EventArgs e)
        {
            var am = MyAdapterManager1.GetAdapterManager() as KlonsA.DataSets.KlonsADataSetTableAdapters.TableAdapterManager;
            am.UpdateAll(MyData.DataSetKlons);
        }
    }
}
