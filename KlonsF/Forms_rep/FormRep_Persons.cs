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
    public partial class FormRep_Persons : MyFormBaseF
    {
        public FormRep_Persons()
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
            cbAC.Text = MyData.Params.RACX;
            cbClid.Text = MyData.Params.RPER;
            CheckAcName();
            CheckClName();
        }

        public override void SaveParams()
        {
            MyData.Params.RSD = tbSD.Text;
            MyData.Params.RED= tbED.Text;
            MyData.Params.RACX = cbAC.Text;
            MyData.Params.RPER = cbClid.Text;
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

            ac = cbAC.Text.Replace('*','%');
            clid = cbClid.Text;

            if (ac == "") ac = "%";

            if (clid == "" || clid == "*")
                clid = null;

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

            ROps2aTableAdapter ad2a = MyData.GetKlonsRepAdapter("ROps2a") as ROps2aTableAdapter;
            TRepA1TableAdapter ada1 = MyData.GetKlonsRepAdapter("TRepA1") as TRepA1TableAdapter;

            ReportViewerData rd = new ReportViewerData();

            int selectedreport = lbCm.SelectedIndex;

            string s = string.Format("Konts: [{0}]", cbAC.Text);
            if (!string.IsNullOrEmpty(lbACName.Text))
                s = string.Format("{0} {1}", s, lbACName.Text);
            if (!string.IsNullOrEmpty(cbClid.Text))
                s = string.Format("{0}\nPersona: [{1}]", s, cbClid.Text);
            if (!string.IsNullOrEmpty(lbClName.Text))
                s = string.Format("{0} {1}", s, lbClName.Text);

            
            string rtitle = "";

            switch (selectedreport)
            {
                case 0:
                    ad2a.FillBy_pers_12(MyData.DataSetKlonsRep.ROps2a, startDate, endDate, ac, clid);
                    rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps2a;
                    MyData.ReportHelper.PrepareRops2a();
                    rd.FileName = "Report_Pers_1";
                    break;
                case 1:
                    ad2a.FillBy_pers_11(MyData.DataSetKlonsRep.ROps2a, startDate, endDate, ac, clid);
                    rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps2a;
                    MyData.ReportHelper.PrepareRops2a();
                    rd.FileName = "Report_Pers_2";
                    break;
                case 2:
                    ada1.FillBy_pers_14(MyData.DataSetKlonsRep.TRepA1, startDate, endDate, ac, clid);
                    rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.TRepA1;
                    rd.FileName = "Report_Pers_4";
                    rtitle = "Rēķinu saraksts";
                    break;
                case 3:
                    ada1.FillBy_pers_15(MyData.DataSetKlonsRep.TRepA1, startDate, endDate, ac, clid);
                    rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.TRepA1;
                    rd.FileName = "Report_Pers_4";
                    rtitle = "Rēķinu saraksts";
                    break;
                case 4:
                    ada1.FillBy_pers_13(MyData.DataSetKlonsRep.TRepA1, startDate, endDate, ac, clid);
                    rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.TRepA1;
                    rd.FileName = "Report_Pers_4";
                    rtitle = "Neapmaksātie rēķini";
                    break;
            }


            switch (selectedreport)
            {
                case 0:
                case 1:
                    rd.AddReportParameters(
                        new string[]
                        {
                            "RSD", startDateStr,
                            "RED", endDateStr,
                            "RACX", cbAC.Text,
                            "RACNM", s,
                            "CompanyName", MyData.Params.CompNameX
                        });
                    break;
                case 2:
                case 3:
                case 4:
                    rd.AddReportParameters(
                        new string[]
                        {
                            "RSD", startDateStr,
                            "RED", endDateStr,
                            "RTITLE", rtitle,
                            "RACNM", s,
                            "CompanyName", MyData.Params.CompNameX
                        });
                    break;
            }
            MyMainForm.ShowReport(rd);
        }

    }
}
