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

            dgcIINRateType.DataSource = SomeDataDefs.IINLikmesVeids;
            dgcIINRateType.DisplayMember = "Val";
            dgcIINRateType.ValueMember = "Key";

        }

        DateTime FilterDate1 = DateTime.MinValue;
        DateTime FilterDate2 = DateTime.MaxValue;
        DateTime LastDate = DateTime.MinValue;

        private void Form_UntaxedMinimum_Load(object sender, EventArgs e)
        {
            cbPerson.Text = null;
        }


        public void MarkRowsForFilter(DateTime dt1, DateTime dt2)
        {
            var table = MyData.DataSetKlons.UNTAXED_MIN;
            foreach(var dr in table.WhereX(d => d.ONDATE > dt2))
            {
                dr.BeginEdit();
                dr.FilterTag = 0;
                dr.EndEditX();
            }
            foreach (var dr in table.WhereX(d => d.ONDATE > dt1 && d.ONDATE <= dt1))
            {
                dr.BeginEdit();
                dr.FilterTag = 1;
                dr.EndEditX();
            }

            var drs_gr = table
                .WhereX(d => d.ONDATE <= dt1)
                .GroupBy(d => d.IDP);
            
            foreach(var gr in drs_gr)
            {
                int idp = gr.Key;
                if (!DataTasks.IsPersonWorking(idp, dt1, dt2))
                {                     
                    foreach (var gr2 in gr)
                    {
                        gr2.BeginEdit();
                        gr2.FilterTag = 0;
                        gr2.EndEditX();
                    }
                    continue;
                }
                var gr1 = gr.OrderByDescending(d => d.ONDATE);
                var gr1_first = gr1.First();
                gr1_first.BeginEdit();
                gr1_first.FilterTag = 1;
                gr1_first.EndEditX();
                var gr1_rest = gr1.Skip(1);
                foreach (var gr2 in gr1_rest)
                {
                    gr2.BeginEdit();
                    gr2.FilterTag = 0;
                    gr2.EndEditX();
                }
            }

        }

        public void DoFilter()
        {
            DateTime dt1 = DateTime.MinValue;
            DateTime dt2 = DateTime.MaxValue;
            if (!string.IsNullOrEmpty(tbDate1.Text))
                dt1 = Utils.StringToDate(tbDate1.Text).Value;
            if (!string.IsNullOrEmpty(tbDate2.Text))
                dt2 = Utils.StringToDate(tbDate2.Text).Value;
            int idp = -1;
            if (cbPerson.SelectedIndex > -1 && cbPerson.SelectedValue != null)
                idp = (int)cbPerson.SelectedValue;
            if (dt1 == DateTime.MinValue && dt2 == DateTime.MaxValue && idp == -1)
            {
                bsRows.RemoveFilter();
                FilterDate1 = DateTime.MinValue;
                FilterDate2 = DateTime.MaxValue;
                return;
            }
            string fs = "";
            if (idp > -1)
            {
                string fs1 = "IDP = " + idp;
                if (fs == "") fs = fs1;
                else fs = $"({fs}) and ({fs1})";
            }
            if (dt1 != DateTime.MinValue || dt2 != DateTime.MaxValue)
            {
                MarkRowsForFilter(dt1, dt2);
                string fs1 = "FilterTag = 1";
                if (fs == "") fs = fs1;
                else fs = $"({fs}) and ({fs1})";
                FilterDate1 = dt1;
                FilterDate2 = dt2;
                LastDate = dt1;
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

        public void DoCmFilte()
        {
            if (!SaveData()) return;
            DoFilter();
            CheckSave();
        }

        private void cmFilter_Click(object sender, EventArgs e)
        {
            DoCmFilte();
        }

        private void dgvRows_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DateTime dt = DateTime.MinValue;
            if (LastDate != DateTime.MinValue) dt = LastDate;
            else if (FilterDate1 != DateTime.MinValue) dt = FilterDate1;
            else dt = DateTime.Today;
            e.Row.Cells[dgcOnDate.Index].Value = dt;
        }

        private void bniXMLImport_Click(object sender, EventArgs e)
        {
            if (!SaveData()) return;
            var form = MyMainForm.ShowFormDialog(typeof(Form_UntaxedMinimumImport)) as Form_UntaxedMinimumImport;
        }
    }
}
