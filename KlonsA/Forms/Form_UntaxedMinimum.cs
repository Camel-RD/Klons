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
    public partial class Form_UntaxedMinimum : MyFormBaseA
    {
        public Form_UntaxedMinimum()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        DateTime FilterDate = DateTime.MinValue;
        DateTime LastDate = DateTime.MinValue;

        private void Form_UntaxedMinimum_Load(object sender, EventArgs e)
        {

        }

        public void DoFilter()
        {
            DateTime dt = DateTime.MinValue;
            if (!string.IsNullOrEmpty(tbDate.Text))
                dt = Utils.StringToDate(tbDate.Text).Value;
            int idp = -1;
            if (cbPerson.SelectedIndex > -1 && cbPerson.SelectedValue != null)
                idp = (int)cbPerson.SelectedValue;
            if (dt == DateTime.MinValue && idp == -1)
            {
                bsRows.RemoveFilter();
                FilterDate = DateTime.MinValue;
                return;
            }
            string fs = "";
            if (dt != DateTime.MinValue)
            {
                fs = string.Format("ONDATE == #{0:M/d/yyyy}#", dt);
                FilterDate = dt;
                LastDate = dt;
            }
            if (idp > -1)
            {
                string fs1 = "IDP = " + idp;
                if (fs == "") fs = fs1;
                else fs = $"({fs}) and ({fs1})";
            }
            bsRows.Filter = fs;
        }

        private void dgvRows_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if(e.ColumnIndex == dgcOnDate.Index)
            {
                Utils.DGVParseDateCell(e);
                if (e.Value != null && e.Value != DBNull.Value && e.Value is DateTime)
                    LastDate = (DateTime)e.Value;
                return;
            }
        }

        public void DeleteCurrent()
        {
            bNav.DeleteCurrent();
            SaveData();
            CheckSave();
        }

        private void SetSaveButton(bool red)
        {
            bNav.SetSaveButton(bniSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvRows.EndEditX()) return false;
            var ret = bsRows.SaveTableA();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsRows.HasChanges());
        }

        private void bniSave_Click(object sender, EventArgs e)
        {
            SaveData();
            CheckSave();
        }

        private void bsRows_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void bNav_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvRows_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
            {
                e.Cancel = true;
            }
        }

        private void dgvRows_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvRows_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                DeleteCurrent();
                e.Handled = true;
            }
        }

        private void bsRows_MyBeforeRowInsert(MyRowUpdateEventArgs e)
        {
            var dr = e.DataRow as KlonsA.DataSets.KlonsADataSet.UNTAXED_MINRow;
            dr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_UNTAXED_MIN_ID();
        }

        private void cmFilter_Click(object sender, EventArgs e)
        {
            DoFilter();
        }

        private void dgvRows_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DateTime dt = DateTime.MinValue;
            if (LastDate != DateTime.MinValue) dt = LastDate;
            else if (FilterDate != DateTime.MinValue) dt = FilterDate;
            else dt = DateTime.Today;
            e.Row.Cells[dgcOnDate.Index].Value = dt;
        }
    }
}
