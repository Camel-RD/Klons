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
using KlonsLIB.MySourceGrid.GridRows;

namespace KlonsA.Forms
{
    public partial class Form_SalarySheetRowHistory : MyFormBaseA
    {
        public Form_SalarySheetRowHistory()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvRows.AutoGenerateColumns = false;
        }

        public int SelectedID = -1;

        private void Form_SalarySheetRowHistory_Load(object sender, EventArgs e)
        {

        }

        public static int Show(KlonsADataSet.SALARY_SHEETS_R_HISTDataTable table)
        {
            var form_hist = new Form_SalarySheetRowHistory();
            form_hist.bsRows.MyDataSource = null;
            form_hist.bsRows.DataSource = table;
            var rt = form_hist.ShowDialog(form_hist.MyMainForm);
            if (rt != DialogResult.OK) return -1;
            return form_hist.SelectedID;
        }

        private void TsbRestore_Click(object sender, EventArgs e)
        {
            if (bsRows.Current == null) return;
            var dr = (bsRows.Current as DataRowView)?.Row as KlonsADataSet.SALARY_SHEETS_R_HISTRow;
            if (dr == null) return;
            SelectedID = dr.IDH;
            DialogResult = DialogResult.OK;
        }

        private void DgvRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > bsRows.Count) return;
            if (e.ColumnIndex == dgcSarAvPay.Index)
            {
                var dr = (bsRows[e.RowIndex] as DataRowView).Row as KlonsADataSet.SALARY_SHEETS_RRow;
                if (dr == null) return;
                decimal val =
                    dr.SALARY_AVPAY_FREE_DAYS +
                    dr.SALARY_AVPAY_WORK_DAYS +
                    dr.SALARY_AVPAY_WORK_DAYS_OVERTIME +
                    dr.SALARY_AVPAY_HOLIDAYS +
                    dr.SALARY_AVPAY_HOLIDAYS_OVERTIME;
                e.Value = val.ToString("# ##0.00;-# ##0.00;\"\"");
                e.FormattingApplied = true;
                return;
            }
            if (e.ColumnIndex == dgcSarPlus.Index)
            {
                var dr = (bsRows[e.RowIndex] as DataRowView).Row as KlonsADataSet.SALARY_SHEETS_RRow;
                if (dr == null) return;
                decimal val =
                    dr.PLUS_AUTHORS_FEES +
                    dr.PLUS_TAXED +
                    dr.PLUS_NOSAI +
                    dr.PLUS_NOTTAXED +
                    dr.PLUS_HI_NOTTAXED +
                    dr.PLUS_HI_TAXED +
                    dr.PLUS_LI_NOTTAXED +
                    dr.PLUS_LI_TAXED +
                    dr.PLUS_PF_NOTTAXED +
                    dr.PLUS_PF_TAXED;
                e.Value = val.ToString("# ##0.00;-# ##0.00;\"\"");
                e.FormattingApplied = true;
                return;
            }
        }
    }
}
