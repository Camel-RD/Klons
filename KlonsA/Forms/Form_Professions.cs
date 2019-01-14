using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsA.DataSets;
using KlonsLIB.Data;
using KlonsLIB.Misc;

namespace KlonsA.Forms
{
    public partial class Form_Professions : MyFormBaseA
    {
        public Form_Professions()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            var table = MyData.DataSetKlons.PROFESSIONS;
            if(table.Rows.Count == 0)
            {
                MyData.FillTable(table);
            }

            dgvProf.AutoResizeRows();
        }

        private void Form_Professions_Load(object sender, EventArgs e)
        {
            CheckSave();
            dgvProf.AutoResizeRows();
        }

        private void SelectCurrent()
        {
            if (dgvProf.CurrentRow == null || dgvProf.CurrentRow.IsNewRow) return;
            var dr = bsProf.CurrentDataRow as KlonsADataSet.PROFESSIONSRow;
            if (!dgvProf.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            string id = dr.ID;
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }

        private void dgvProf_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                SelectCurrent();
            }
        }

        private void dgvProf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }
        }

        private void dgvProf_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                CheckFilter();
            }
        }

        private void bnavProf_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvProf_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void SetSaveButton(bool red)
        {
            bnavProf.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvProf.EndEditX()) return false;
            var ret = bsProf.SaveTable();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsProf.HasChanges());
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
            CheckSave();
        }

        private void bsProf_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvProf_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void CheckFilter(bool checkcat = false)
        {
            string sf, s = tbSearch.Text;
            string cat = cbCat.SelectedValue.AsString();
            if (cat == "") cat = null;
            if (checkcat && cat == "*")
            {
                tbSearch.Text = "";
                bsProf.RemoveFilter();
                return;
            }

            if (s == "")
                sf = "";
            else
                sf = string.Format("(Descr LIKE '*{0}*')", s);

            if (checkcat && cat == "**")
            {
                if (sf == "") sf = "USED = 1";
                else sf = sf + "AND (USED = 1)";
            }
            bsProf.Filter = sf;
        }

        private void cbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cat = cbCat.SelectedValue.AsString();
            if (string.IsNullOrEmpty(cat)) return;
            if (cat == "*" || cat == "**")
            {
                CheckFilter(true);
                return;
            }
            if (!string.IsNullOrEmpty(bsProf.Filter)) return;
            for (int i =0;i<bsProf.Count;i++)
            {
                var dgv = bsProf[i] as DataRowView;
                if (dgv == null) return;
                var dr = dgv.Row as KlonsADataSet.PROFESSIONSRow;
                if (dr.ID == cat)
                {
                    bsProf.Position = i;
                }
            }
        }

    }
}
