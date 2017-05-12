using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using KlonsF.UI;
using KlonsF.Classes;
using KlonsF.Forms;
using KlonsF.DataSets.klonsRepDataSetTableAdapters;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using Microsoft.Reporting.WinForms;

namespace KlonsF.FormsReportParams
{
    public partial class FormRep_SkaidraNauda : MyFormBaseF
    {
        public FormRep_SkaidraNauda()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private DateTime startDate = DateTime.MinValue;
        private DateTime endDate = DateTime.MinValue;
        private decimal limit1 = 0.0M;
        private decimal limit2 = 0.0M;

        private void FormRepApgr1_Load(object sender, EventArgs e)
        {
            LoadParams();
            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {tbSD, tbED},
                new Control[] {tbLimit1, tbLimit1},
                new Control[] {tbLimit2, tbLimit2},
                new Control[] {cmDoIt, cmDoIt2}
            });
        }


        private void LoadParams()
        {
            tbSD.Text = MyData.Params.RSD;
            tbED.Text = MyData.Params.RED;
            tbLimit1.Text = MyData.Params.RSKAIDRA1;
            tbLimit2.Text = MyData.Params.RSKAIDRA2;
        }

        public override void SaveParams()
        {
            MyData.Params.RSD = tbSD.Text;
            MyData.Params.RED = tbED.Text;
            MyData.Params.RSKAIDRA1 = tbLimit1.Text;
            MyData.Params.RSKAIDRA2 = tbLimit2.Text;
        }

        private string Check()
        {
            if (tbSD.Text == "" || tbED.Text == "")
                return "Jāievada datums.";

            if (!Utils.StringToDate(tbSD.Text, out startDate) ||
                !Utils.StringToDate(tbED.Text, out endDate) ||
                startDate > endDate)
                return "Nekorekts datums.";
            
            if(!Decimal.TryParse(tbLimit1.Text, out limit1) ||
                !Decimal.TryParse(tbLimit2.Text, out limit2))
                return "Nekorekta summa.";

            return "OK";
        }

        private void DoIt(int k)
        {
            string rt = Check();
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }

            SaveParams();

            var ad = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;

            if(k == 1)
                ad.FillBy_skaidra_01(MyData.DataSetKlonsRep.ROps1a, startDate, endDate, limit1, "JP");
            else
                ad.FillBy_skaidra_02(MyData.DataSetKlonsRep.ROps1a, startDate, endDate, limit2, "FP");

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "Report_Skaidra_1";
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps1a;

            string s1 = "",s = "              ";
            int i = 13;
            if (k == 2) i = startDate.Month;
            s1 = s.Substring(0, i - 1);
            s1 += "X";
            s1 += s.Substring(0, 13 - i);

            rd.AddReportParameters(
                new string[]
                {
                    "PYEAR", startDate.Year.ToString(),
                    "PMONTH", s1,
                    "Company", MyData.Params.CompName,
                    "Addr", MyData.Params.CompAddr,
                    "AddrInd", MyData.Params.CompAddrInd,
                    "RegNr", MyData.Params.CompRegNr,
                    "Manager", MyData.Params.CompMName,
                    "Phone", MyData.Params.CompPhone
                });

            MyMainForm.ShowReport(rd);
        }

        private void cmDoIt_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoIt(1);

            });
        }
        private void cmDoIt2_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoIt(2);

            });
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            OnNaviKey(sender, e);
        }

    }
}
