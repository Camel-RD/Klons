using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsF.UI;
using KlonsF.Classes;
using KlonsF.Forms;
using KlonsF.DataSets.klonsRepDataSetTableAdapters;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using Microsoft.Reporting.WinForms;

namespace KlonsF.FormsReportParams
{
    public partial class FormRep_NPMT : MyFormBaseF
    {
        public FormRep_NPMT()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private DateTime startDate = DateTime.MinValue;
        private DateTime endDate = DateTime.MinValue;

        private void FormRepApgr1_Load(object sender, EventArgs e)
        {
            lbCM.SelectedIndex = 0;
            int yr = DateTime.Today.Year;
            cbYear.ItemStrings = new string[]{(yr-1).ToString(), yr.ToString()};
            LoadParams();
            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {cbYear, cbMonth},
                new Control[] {cmDoIt, cmDoIt}
            });
        }


        private void LoadParams()
        {
            string s = MyData.Params.RED;
            DateTime d1;
            if (!Utils.StringToDate(s, out d1)) return;
            startDate = new DateTime(d1.Year,d1.Month,1);
            endDate = startDate.AddMonths(1).AddDays(-1);
            cbYear.Text = startDate.Year.ToString();
            cbMonth.SelectedIndex = startDate.Month - 1;
        }

        public override void SaveParams()
        {
            MyData.Params.RED = Utils.DateToString(endDate);
        }

        private string Check()
        {
            string syear = cbYear.Text;
            string smonth = cbMonth.Text;

            if (syear == "" || smonth == "")
                return "Jāievada gads, mēnesis.";

            int year, month;

            if (!int.TryParse(syear, out year) || !int.TryParse(smonth, out month))
                return "Nekorekts gads vai mēnesis";
            
            if (year < 2000 || year >2100)
                return "Nekorekts gads.";

            startDate = new DateTime(year, 1, 1);
            endDate = new DateTime(year, month, 1);
            endDate = endDate.AddMonths(1).AddDays(-1);

            return "OK";
        }

        private void DoIt()
        {
            string rt = Check();
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }

            int selectedReport = lbCM.SelectedIndex;
            if (selectedReport == -1) return;

            TRepMTTableAdapter ad1 = MyData.GetKlonsRepAdapter("TRepMT") as TRepMTTableAdapter;
            if (ad1 == null) return;

            string speriod = string.Format("{0}. gada jan.-{1}.", 
                startDate.Year,
                Utils.MonthNames[endDate.Month - 1].LeftMax(3));
            
            SaveParams();

            ReportViewerData rd = new ReportViewerData();

            switch (selectedReport)
            {
                case 0:
                    ad1.FillBy_npmt_14(MyData.DataSetKlonsRep.TRepMT, startDate, endDate);
                    MyData.ReportHelper.PrepareTRepMTForNPMT1(endDate.Month);
                    rd.FileName = "Report_NPMT_1";
                    break;
                case 1:
                    ad1.FillBy_npmt_24(MyData.DataSetKlonsRep.TRepMT, startDate, endDate);
                    MyData.ReportHelper.PrepareTRepMTForNPMT1(endDate.Month);
                    rd.FileName = "Report_NPMT_2";
                    break;
                case 2:
                    ad1.FillBy_npmt_44(MyData.DataSetKlonsRep.TRepMT, startDate, endDate);
                    MyData.ReportHelper.PrepareTRepMTForNPMT1(endDate.Month);
                    rd.FileName = "Report_NPMT_1";
                    break;
                case 3:
                    ad1.FillBy_npmt_31(MyData.DataSetKlonsRep.TRepMT, startDate, endDate);
                    MyData.ReportHelper.PrepareTRepMTForNPMT3();
                    rd.FileName = "Report_NPMT_3";
                    break;
            }


            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.TRepMT;
            rd.AddReportParameters(
                new string[]
                {
                    "RPERIOD", speriod,
                    "CompanyName", MyData.Params.CompNameX
                });

            MyMainForm.ShowReport(rd);
        }

        private void cmDoIt_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoIt();

            });
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            OnNaviKey(sender, e);
        }

        private void lbCM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoIt();

            });
        }

    }
}
