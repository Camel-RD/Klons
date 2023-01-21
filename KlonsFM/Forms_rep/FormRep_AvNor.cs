using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.UI;
using KlonsFM.Classes;
using KlonsFM.Forms;
using KlonsFM.DataSets.klonsRepDataSetTableAdapters;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using Microsoft.Reporting.WinForms;

namespace KlonsFM.FormsReportParams
{
    public partial class FormRep_AvNor : MyFormBaseF
    {
        public FormRep_AvNor()
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
                new Control[] {tbNr, tbNr},
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
            tbSD.Text = MyData.Params.AVNorSD;
            tbED.Text = MyData.Params.AVNorED;
            cbAC.Text = MyData.Params.AVRAC;
            cbClid.Text = MyData.Params.NorPers;
            tbNr.Text = MyData.Params.AVNorNR;
            CheckAcName();
            CheckClName();
        }

        public override void SaveParams()
        {
            MyData.Params.AVNorSD = startDateStr;
            MyData.Params.AVNorED = endDateStr;
            MyData.Params.AVRAC = cbAC.Text;
            MyData.Params.NorPers = cbClid.Text;
            MyData.Params.AVNorNR = tbNr.Text;
        }

        private string Check()
        {
            if (tbSD.Text == "" || tbED.Text == "")
                return "Jāievada datums.";

            if (!Utils.StringToDate(tbSD.Text, out startDate) ||
                !Utils.StringToDate(tbED.Text, out endDate) ||
                startDate > endDate)
                return "Nekorekts datums.";

            startDateStr = Utils.DateToString(startDate);
            endDateStr = Utils.DateToString(endDate);

            ac = cbAC.Text;
            clid = cbClid.Text;

            if (ac == "" || lbACName.Text == "")
                return "Nekorekts konts.";

            if (clid == "" || lbClName.Text == "")
                return "Nekorekta persona.";

            return "OK";
        }

        private void cmDoIt_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoIt();

            });
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

            ROps1aTableAdapter ad1a = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            ROps2aTableAdapter ad2a = MyData.GetKlonsRepAdapter("ROps2a") as ROps2aTableAdapter;
            ROps3aTableAdapter ad3a = MyData.GetKlonsRepAdapter("ROps3a") as ROps3aTableAdapter;

            ReportViewerData rd = new ReportViewerData();
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps1a;
            rd.Sources["DataSet_2a"] = MyData.DataSetKlonsRep.ROps2a;
            rd.Sources["DataSet_3a"] = MyData.DataSetKlonsRep.ROps3a;

            ad1a.FillBy_koresp_11_clid2(MyData.DataSetKlonsRep.ROps1a, startDate, endDate, ac, clid);
            ad2a.FillBy_apgr_01_clid2(MyData.DataSetKlonsRep.ROps2a, startDate, endDate, ac, clid);
            ad3a.FillBy_koresp_01_clid2(MyData.DataSetKlonsRep.ROps3a, startDate, endDate, ac, clid);

            MyData.ReportHelper.PrepareRops1a();
            MyData.ReportHelper.PrepareRops2a();
            MyData.ReportHelper.PrepareRops2aRAC();

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
                    "AVNR", tbNr.Text,
                    "PAC", null,
                    "PCLID", null
                });

            rd.FileName = "Report_AvNor_1";
            MyMainForm.ShowReport(rd);
        }

        private void tsbPrevMonth_Click(object sender, EventArgs e)
        {
            if (Check() != "OK") return;
            var dt2 = startDate.FirstDayOfMonth().AddDays(-1);
            var dt1 = dt2.FirstDayOfMonth();
            tbSD.Text = Utils.DateToString(dt1);
            tbED.Text = Utils.DateToString(dt2);
        }

        private void tsbNextMonth_Click(object sender, EventArgs e)
        {
            if (Check() != "OK") return;
            var dt1 = startDate.LastDayOfMonth().AddDays(1);
            var dt2 = dt1.LastDayOfMonth();
            tbSD.Text = Utils.DateToString(dt1);
            tbED.Text = Utils.DateToString(dt2);
        }
    }
}
