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
    public partial class FormRep_Currency : MyFormBaseF
    {
        public FormRep_Currency()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private DateTime startDate = DateTime.MinValue;
        private DateTime endDate = DateTime.MinValue;
        private string ac = "";
        private string clid = "";
        private string startDateStr = "";
        private string endDateStr = "";
        private string currency = "";
        private decimal currrate = 1.0M;
        private void FormRepKoresp1_Load(object sender, EventArgs e)
        {
            lbACName.Text = "";
            lbClName.Text = "";
            lbCm.SelectedIndex = 0;
            LoadParams();
            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {tbSD, tbED},
                new Control[] {cbAC, cbAC},
                new Control[] {cbClid, cbClid},
                new Control[] {tbCurrency, tbCurrency},
                new Control[] {cmDoIt, cmDoIt}
            });
        }


        private void CheckAcName()
        {
            string s = cbAC.Text;
            if (s == "")
            {
                lbACName.Text = "";
                return;
            }
            lbACName.Text = MyData.GetAcName(s);
        }
        private void CheckClName()
        {
            string s = cbClid.Text;
            if (s == "")
            {
                lbClName.Text = "";
                return;
            }
            lbClName.Text = MyData.GetClName(s);
        }

        private void cbAC_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cbAC_TextChanged(object sender, EventArgs e)
        {
            CheckAcName();
        }
        private void cbClid_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cbClid_TextChanged(object sender, EventArgs e)
        {
            CheckClName();
        }
        private bool DoOnF5(ComboBox sender)
        {
            Action<string> act =
                value =>
                {
                    if (value != null)
                        sender.Text = value;
                };
            if (sender == cbAC)
            {
                MyMainForm.ShowFormAcplanDialog(act);
                return true;
            }

            if (sender == cbClid)
            {
                MyMainForm.ShowFormPersonsDialog(act);
                return true;
            }
            return false;
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            OnNaviKey(sender, e);
            switch (e.KeyCode)
            {
                case Keys.F5:
                    if (sender is ComboBox)
                        if (DoOnF5(sender as ComboBox))
                        {
                            e.Handled = true;
                        }
                    break;
            }
        }

        private void cbClid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoOnF5(sender as ComboBox);
        }
        private void lbCm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoIt();

            });
        }

        private void LoadParams()
        {
            tbSD.Text = MyData.Params.RSD;
            tbED.Text = MyData.Params.RED;
            cbAC.Text = MyData.Params.RAC;
            cbClid.Text = MyData.Params.RPER;
            tbCurrency.Text = MyData.Params.RCURR;
            CheckAcName();
            CheckClName();
        }

        public override void SaveParams()
        {
            MyData.Params.RSD = startDateStr;
            MyData.Params.RED = endDateStr;
            MyData.Params.RAC = cbAC.Text;
            MyData.Params.RACNM = lbACName.Text;
            MyData.Params.RPER = cbClid.Text;
            MyData.Params.RCURR = tbCurrency.Text;
        }

        private string Check()
        {
            if (tbSD.Text == "" || tbED.Text == "")
                return "Jāievada datums.";

            if (!Utils.StringToDate(tbSD.Text, out startDate) ||
                !Utils.StringToDate(tbED.Text, out endDate) ||
                startDate > endDate)
                return "Nekorekts datums.";

            if (tbCurrency.Text == "" || tbCurrency.Text.ToUpper() == "EUR" ||
                tbCurrency.Text.Length > 3)
                return "Nekorekts valūtas kods.";


            startDateStr = Utils.DateToString(startDate);
            endDateStr = Utils.DateToString(endDate);

            currency = tbCurrency.Text;
            
            int selectedreport = lbCm.SelectedIndex;
            if (selectedreport == 0)
            {
                var dr = MyData.DataSetKlons.Currency.FindByidDete(currency, endDate);
                if(dr == null)
                {
                    return "Norādītajam beigu datumam un valūtai nav ievadīts konvertēšanas kurss.";
                }
                currrate = dr.rate;
            }

            ac = cbAC.Text;
            if (ac == "") ac = "%";
            ac = ac.Replace('*', '%');

            clid = cbClid.Text;
            if (clid == "") clid = null;

            return "OK";
        }

        private void cmDoIt_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoIt();

            });
        }


        private void DoCurrDiff()
        {
            var ad = MyData.GetKlonsRepAdapter("ROps2a") as ROps2aTableAdapter;
            if (ad == null) return;
            ad.FillBy_currdiff_01(MyData.DataSetKlonsRep.ROps2a, startDate, endDate, ac, null, currency);
            
            if (MyData.DataSetKlonsRep.ROps2a.Count == 0)
            {
                MyMainForm.ShowWarning("Ar dotajiem parametriem dati netika atrasti");
                return;
            }

            var dr = MyData.DataSetKlonsRep.ROps2a[0];
            decimal d1, d2, d3, d4;
            d1 = dr.ADb - dr.ACr;
            d2 = dr.BDb - dr.BCr;
            string s = ac.Substring(0, 1);
            if (s != "1" && s != "2")
            {
                d1 = -d1;
                d2 = -d2;
            }
            d3 = Math.Round(d1*currrate, 2);
            d4 = d3 - d2;
            dr.ADb = d1;
            dr.ACr = d3;
            dr.TDb = d2;
            dr.TCr = d4;
            MyData.DataSetKlonsRep.ROps2a.AcceptChanges();

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "Report_CurrDiff";
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps2a;

            s = string.Format(
                "Valūta: {0}\nKonts: {1} {2}\nPersona: {3} {4}",
                currency, cbAC.Text, lbACName.Text,
                cbClid.Text, lbClName.Text);

            rd.AddReportParameters(
                new string[]
                {
                    "RSD", startDateStr,
                    "RED", endDateStr,
                    "RACX", cbAC.Text,
                    "RACNM", s,
                    "CompanyName", MyData.Params.CompNameX,
                    "RCURRENCY", currency
                });

            MyMainForm.ShowReport(rd);
        }

        private void DoApgr1()
        {
            var ad = MyData.GetKlonsRepAdapter("ROps2a") as ROps2aTableAdapter;
            if (ad == null) return;
            ad.FillBy_apgr_cur_01_clid(MyData.DataSetKlonsRep.ROps2a, startDate, endDate, ac, null, currency);
            MyData.ReportHelper.PrepareRops2a();

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "Report_Apgr_Bil";
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps2a;

            rd.AddReportParameters(
                new string[]
                {
                    "RSD", startDateStr,
                    "RED", endDateStr,
                    "RACX", cbAC.Text,
                    "RACNM", lbACName.Text,
                    "CompanyName", MyData.Params.CompNameX,
                    "RCURRENCY", currency
                });

            MyMainForm.ShowReport(rd);
        }

        private void DoApgrPers1()
        {
            var ad = MyData.GetKlonsRepAdapter("ROps2a") as ROps2aTableAdapter;
            if (ad == null) return;
            ad.FillBy_apgr_cur_01_clid(MyData.DataSetKlonsRep.ROps2a, startDate, endDate, ac, clid, currency);
            MyData.ReportHelper.PrepareRops2a();

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "Report_Pers_1";
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps2a;

            string s = string.Format("{1} Konts: [{0}]", cbAC.Text, currency);
            if (!string.IsNullOrEmpty(lbACName.Text))
                s = string.Format("{0} {1}", s, lbACName.Text);
            if (!string.IsNullOrEmpty(cbClid.Text))
                s = string.Format("{0}\nPersona: [{1}]", s, cbClid.Text);
            if (!string.IsNullOrEmpty(lbClName.Text))
                s = string.Format("{0} {1}", s, lbClName.Text);

            rd.AddReportParameters(
                new string[]
                {
                    "RSD", startDateStr,
                    "RED", endDateStr,
                    "RACX", cbAC.Text,
                    "RACNM", s,
                    "CompanyName", MyData.Params.CompNameX
                });

            MyMainForm.ShowReport(rd);
        }

        private void DoKoresp1()
        {
            var ad1a = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            var ad2a = MyData.GetKlonsRepAdapter("ROps2a") as ROps2aTableAdapter;
            var ad3a = MyData.GetKlonsRepAdapter("ROps3a") as ROps3aTableAdapter;

            ReportViewerData rd = new ReportViewerData();
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps1a;
            rd.Sources["DataSet_2a"] = MyData.DataSetKlonsRep.ROps2a;
            rd.Sources["DataSet_3a"] = MyData.DataSetKlonsRep.ROps3a;

            ad1a.FillBy_koresp_11_cur(MyData.DataSetKlonsRep.ROps1a, startDate, endDate, ac, clid, currency);
            ad2a.FillBy_apgr_cur_01_clid(MyData.DataSetKlonsRep.ROps2a, startDate, endDate, ac, clid, currency);
            ad3a.FillBy_koresp_01_cur(MyData.DataSetKlonsRep.ROps3a, startDate, endDate, ac, clid, currency);

            MyData.ReportHelper.PrepareRops1a();
            MyData.ReportHelper.PrepareRops2a();
            MyData.ReportHelper.PrepareRops2aRAC(cbAC.Text, lbACName.Text, cbClid.Text, lbClName.Text);

            rd.AddReportParameters(
                new string[]
                {
                    "RSD", startDateStr,
                    "RED", endDateStr,
                    "RAC", cbAC.Text,
                    "RACNM", lbACName.Text,
                    "CompanyName", MyData.Params.CompNameX,
                    "RPER", MyData.Params.RPER,
                    "RPERNM", lbClName.Text,
                    "PAC", null,
                    "PCLID", null,
                    "RCURRENCY", currency
                });

            rd.FileName = "Report_Koresp_1";

            MyMainForm.ShowReport(rd);
        }

        private void DoCurrCheck()
        {
            var adap = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            
            adap.FillBy_curcheck_01(MyData.DataSetKlonsRep.ROps1a, 
                startDate, endDate, ac, null, currency);

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "Report_DokSar_1";
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps1a;

            string paramstr = string.Format(
                "Dokumenti ar valūtas konvertācijas kļūdām \nDatums:[{0}-{1}], konts: [{2}]",
                startDateStr, endDateStr, cbAC.Text);
            
            rd.AddReportParameters(
                new string[]
                {
                    "RSD", startDateStr,
                    "RED", endDateStr,
                    "RACX", "",
                    "RACNM", paramstr,
                    "CompanyName", MyData.Params.CompNameX
                });

            MyMainForm.ShowReport(rd);
        }

        private void DoIt()
        {
            string rt = Check();
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }
            SaveParams();

            int selectedreport = lbCm.SelectedIndex;
            switch (selectedreport)
            {
                case 0:
                    DoCurrDiff();
                    break;
                case 1:
                    DoApgr1();
                    break;
                case 2:
                    DoApgrPers1();
                    break;
                case 3:
                    DoKoresp1();
                    break;
                case 4:
                    DoCurrCheck();
                    break;
            }
        }

    }
}
