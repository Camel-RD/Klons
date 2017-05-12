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
using KlonsLIB.Misc;

namespace KlonsA.Forms
{
    public partial class Form_FizPersons : MyFormBaseA
    {
        public Form_FizPersons()
        {
            try
            {
                InitializeComponent();
                CheckMyFontAndColors();
                MakeGrid();
                SetupToolStrips();
                cbActive.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                Form_Error.ShowException(e);
            }
        }

        private void Form_FizPersons_Load(object sender, EventArgs e)
        {
            CheckEnableGrid();
            CheckSave();
        }

        private void MakeGrid()
        {
            sgrPersons.MakeGrid();
            sgrPersons.LinkGrid();
            sgrPersons.ArrangeLinkedControls();
        }

        private void SetupToolStrips()
        {
            InsertInToolStrip(bnavPersons, cbActive, -1);
        }

        private void SelectCurrent()
        {
            if (dgvPersons.CurrentRow == null || dgvPersons.CurrentRow.IsNewRow) return;
            var dr = bsPersons.CurrentDataRow as KlonsA.DataSets.KlonsADataSet.PERSONS_FIZRow;
            if (!dgvPersons.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            if (!this.IsMyDialog) return;
            SetSelectedValue(dr.ID);
        }


        public override bool SaveData()
        {
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
                Form_Error.ShowException(e, "Neizdevās saglabāt izmaiņas.");
                return false;
            }
            return true;
        }

        private void SetSaveButton(bool red)
        {
            bnavPersons.SetSaveButton(tsbSave, red);
        }

        private void CheckSave()
        {
            SetSaveButton(myAdapterManager1.HasChanges());
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bsPersons_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvPersons_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        public void DeleteCurrent()
        {
            if (!Validate()) return;
            bnavPersons.DeleteCurrent();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void dgvPersons_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void bnavPersons_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvPersons_KeyDown(object sender, KeyEventArgs e)
        {
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
                if (!dgvPersons.EndEditX()) return;
                AddPerson();
                e.Handled = true;
                return;
            }
        }

        private void dgvPersons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPersons.CurrentRow == null || dgvPersons.CurrentRow.IsNewRow) return;
            if (e.ColumnIndex == dgcFname.Index || e.ColumnIndex == dgcLName.Index)
            {
                SelectCurrent();
            }
        }

        private void CheckEnableGrid()
        {
            sgrPersons.Enabled = bsPersons.Count > 0 && bsPersons.Current != null &&
                dgvPersons.CurrentRow != null && !dgvPersons.CurrentRow.IsNewRow;
        }

        private void dgvPersons_CurrentCellChanged(object sender, EventArgs e)
        {
            CheckEnableGrid();
            dgvPersons.EndEditX();
        }

        private void bsPersons_CurrentChanged(object sender, EventArgs e)
        {
            CheckEnableGrid();
        }

        public void SelectPerson(int idp)
        {
            if (bsPersons.Count == 0) return;
            for (int i = 0; i < bsPersons.Count; i++)
            {
                var drp = (bsPersons[i] as DataRowView)?.Row as KlonsADataSet.PERSONS_FIZRow;
                if (drp == null) continue;
                if (drp.ID == idp)
                {
                    bsPersons.Position = i;
                    return;
                }
            }
        }

        public void AddPerson()
        {
            if (!Validate()) return;
            if (!SaveData()) return;
            var tabpe_persons_fiz = MyData.DataSetKlons.PERSONS_FIZ;
            var dr_new = tabpe_persons_fiz.NewPERSONS_FIZRow();
            dr_new.FNAME = "?";
            dr_new.LNAME = "?";
            dr_new.BIRTH_DATE = DateTime.Today;
            tabpe_persons_fiz.Rows.Add(dr_new);
            SelectPerson(dr_new.ID);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            AddPerson();
        }

        private void dgvPersons_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if(e.ColumnIndex == dgcUsedDt1.Index || e.ColumnIndex == dgcUsedDt1.Index)
            {
                Utils.DGVParseDateCell(e);
            }
        }

        private void CheckFilter()
        {
            int k = cbActive.SelectedIndex;
            string s1 = k == 0 ? "(USED = 1)" : null;
            if (s1 == null)
            {
                bsPersons.RemoveFilter();
            }
            else
            {
                bsPersons.Filter = s1;
            }
        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckFilter();
        }

    }

}
