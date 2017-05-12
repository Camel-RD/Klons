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
using Microsoft.Reporting.WinForms;

namespace KlonsA.Forms
{
    public partial class Form_SickDaysCalc : MyFormBaseA
    {
        public Form_SickDaysCalc()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private SickDayCalcInfo SickDayCalcInfo = null;
        private string Person = null;
        private string Period = null;

        private void Form_SickDaysCalc_Load(object sender, EventArgs e)
        {
            lbTitle.Font = new Font(this.Font, lbTitle.Font.Style);
        }

        public static void Show(SickDayCalcInfo sdc, string person, string period)
        {
            var fm = new Form_SickDaysCalc();
            fm.SickDayCalcInfo = sdc;
            fm.Person = person;
            fm.Period = period;
            fm.dgvSar.AutoGenerateColumns = false;
            fm.dgvSar.DataSource = sdc.Rows;
            fm.tbRateHour.Text = sdc.AvPayRateHour.ToString("N4");
            fm.tbRateDay.Text = sdc.AvPayRateDay.ToString("N4");
            fm.tbPay.Text = sdc.TotalRow.SickDayPay.ToString("N2");
            fm.tbPay75.Text = sdc.TotalRow.SickDayPay75.ToString("N2");
            fm.tbPay80.Text = sdc.TotalRow.SickDayPay80.ToString("N2");
            fm.lbTitle.Text = string.Format("Darbinieks: {0}, periods: {1}", person, period);
            fm.ShowDialog(fm.MyMainForm);
        }

        private void DoIt()
        {
            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportA_SlimibasNauda_1";
            rd.Sources["DataSet1"] = SickDayCalcInfo.Rows;
            rd.AddReportParameters(
                new string[]
                {
                    "CompanyName", MyData.Params.CompNameX,
                    "RPerson", Person,
                    "RPeriod", Period,
                    "RPay", SickDayCalcInfo.TotalRow.SickDayPay.ToString("N2"),
                    "RPay75", SickDayCalcInfo.TotalRow.SickDayPay75.ToString("N2"),
                    "RPay80", SickDayCalcInfo.TotalRow.SickDayPay80.ToString("N2"),
                    "RRateHour", SickDayCalcInfo.AvPayRateHour.ToString("N4"),
                    "RRateDay", SickDayCalcInfo.AvPayRateDay.ToString("N4"),
                    "RRateCalDay", SickDayCalcInfo.AvPayRateCalendarDay.ToString("N4"),
                    "RRemark", ""
                });

            MyMainForm.ShowReport(rd);
        }
        private void cmReport_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoIt();
            });
        }

        private void dgvSar_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var rows = SickDayCalcInfo.Rows;
            bool b0 = e.RowIndex > 0 && rows[e.RowIndex - 1].IsTitle;
            bool b1 = rows[e.RowIndex].IsTitle;
            bool b2 = e.RowIndex < rows.Count - 1 && rows[e.RowIndex + 1].IsTitle;

            e.AdvancedBorderStyle.Bottom = b1 && b2 ?
                DataGridViewAdvancedCellBorderStyle.None :
                dgvSar.AdvancedCellBorderStyle.Bottom;

            if (e.ColumnIndex != dgcSickDayPay80.Index)
            {
                e.AdvancedBorderStyle.Right = b1 ?
                    DataGridViewAdvancedCellBorderStyle.None :
                    dgvSar.AdvancedCellBorderStyle.Right;
            }
            if (e.ColumnIndex != dgcCaption.Index)
            {
                e.AdvancedBorderStyle.Left = b1 ?
                    DataGridViewAdvancedCellBorderStyle.None :
                    dgvSar.AdvancedCellBorderStyle.Left;
            }
        }
    }
}
