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
    public partial class FormRep_Darz1 : MyFormBaseF
    {
        public FormRep_Darz1()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private DateTime startDate = DateTime.MinValue;
        private DateTime endDate = DateTime.MinValue;
        private string filterAc1 = null;
        private string filterAc3 = null;
        private string kaname = "";
        private string baname = "";
        private string cnname = "";

        private void FormRepApgr1_Load(object sender, EventArgs e)
        {
            lbCM.SelectedIndex = 0;
            int yr = DateTime.Today.Year;
            cbYear.ItemStrings = new string[]{(yr-1).ToString(), yr.ToString()};

            var table_acp = MyData.DataSetKlons.AcP21;
            var list_ac = table_acp
                .Where(x => x.id1 == "KA" || x.id1 == "BA" || x.id1 == "CN")
                .Select(x => x.AC);
            var list_ac1 = new[] { "*", "KA", "BA", "CN" };
            list_ac1 = list_ac1.Concat(list_ac).ToArray();
            cbFilter.ItemStrings = list_ac1;
            cbFilter.SelectedIndex = 0;

            LoadParams();
            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {cbYear, cbMonth},
                new Control[] {cbFilter, cmDoIt}
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

            if (!int.TryParse(syear, out year))
                return "Nekorekts gads";

            if (!int.TryParse(smonth, out month) && smonth != "Gads")
                return "Nekorekts mēnesis";

            if (year < 2000 || year >2100)
                return "Nekorekts gads.";

            if (smonth == "Gads")
            {
                startDate = new DateTime(year, 1, 1);
                endDate = new DateTime(year, 12, 31);
            }
            else
            {
                startDate = new DateTime(year, month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);
            }

            var filter = cbFilter.Text;
            filterAc1 = null;
            filterAc3 = null;
            kaname = "";
            baname = "";
            cnname = "";

            if (filter == "KA" || filter == "BA" || filter == "CN")
            {
                filterAc3 = filter;
                if (filter == "KA") kaname = "KA";
                if (filter == "BA") baname = "BA";
                if (filter == "CN") cnname = "CN";
            }
            else if (filter != "*")
            {
                filterAc1 = filter;
                var dr_ac = MyData.DataSetKlons.AcP21.FindByAC(filter);
                if(dr_ac != null)
                {
                    var ac3 = dr_ac.id1;
                    var ac = dr_ac.AC;
                    if (ac3 == "KA") kaname = ac;
                    if (ac3 == "BA") baname = ac;
                    if (ac3 == "CN") cnname = ac;
                }
            }
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

            TRepDarz1TableAdapter ad1 = MyData.GetKlonsRepAdapter("TRepDarz1") as TRepDarz1TableAdapter;
            TRepDarz2TableAdapter ad2 = MyData.GetKlonsRepAdapter("TRepDarz2") as TRepDarz2TableAdapter;
            if (ad1 == null) return;
            if (ad2 == null) return;

            DateTime startDateOfYear = new DateTime(startDate.Year, 1, 1);
            DateTime endDateOfYear = new DateTime(startDate.Year, 12, 31);
            string speriod = "";
            if(startDate == startDateOfYear && endDateOfYear == endDate)
            {
                speriod = $"{startDate.Year}. gads";
            }
            else
            {
                speriod = $"{startDate.Year}. gada {Utils.MonthNames[startDate.Month - 1]}";
            }

            SaveParams();

            ReportViewerData rd = new ReportViewerData();

            switch (selectedReport)
            {
                case 0:
                    ad1.FillBy_darz_1(MyData.DataSetKlonsRep.TRepDarz1, startDate, endDate, filterAc1, filterAc3);
                    ad2.FillBy_darz_2(MyData.DataSetKlonsRep.TRepDarz2, startDateOfYear, startDate.AddDays(-1), filterAc1, filterAc3);
                    rd.FileName = "Report_Darz_1";
                    break;
                case 1:
                    ad1.FillBy_darz_1(MyData.DataSetKlonsRep.TRepDarz1, startDate, endDate, filterAc1, filterAc3);
                    ad2.FillBy_darz_2(MyData.DataSetKlonsRep.TRepDarz2, startDateOfYear, startDate.AddDays(-1), filterAc1, filterAc3);
                    rd.FileName = "Report_Darz_3";
                    break;
                case 2:
                    ad1.FillBy_darz_3(MyData.DataSetKlonsRep.TRepDarz1, startDate, endDate);
                    ad2.FillBy_darz_4(MyData.DataSetKlonsRep.TRepDarz2, startDateOfYear, startDate.AddDays(-1));
                    rd.FileName = "Report_Darz_2";
                    break;
            }

            kaname = kaname.Nz();
            baname = baname.Nz();
            cnname = cnname.Nz();
            if (kaname != "") kaname = " - " + kaname;
            if (baname != "") baname = " - " + baname;
            if (cnname != "") cnname = " - " + cnname;

            MyData.ReportHelper.PrepareTRepDarz1();

            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.TRepDarz1;
            rd.Sources["DataSet2"] = MyData.DataSetKlonsRep.TRepDarz2;
            rd.AddReportParameters(
                new string[]
                {
                        "RPERIOD", speriod,
                        "CompanyName", MyData.Params.CompNameX
                });
            if (rd.FileName == "Report_Darz_1")
            {
                rd.AddReportParameters(
                    new string[]
                    {
                        "KAName", kaname,
                        "BAName", baname,
                        "CNName", cnname
                    });
            }
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
