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
    public partial class FormRep_ApgrMT : MyFormBaseF
    {
        public FormRep_ApgrMT()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private DateTime startDate = DateTime.MinValue;
        private DateTime endDate = DateTime.MinValue;
        private string ac = "";

        private void FormRepApgrMT_Load(object sender, EventArgs e)
        {
            lbACName.Text = "";
            LoadParams();
            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {tbSD, tbED},
                new Control[] {cbAC, cbAC},
                new Control[] {lbCM, lbCM},
                new Control[] {cmDoIt, cmDoIt}
            });
            lbCM.SelectedIndex = 0;
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

        private void cbAC_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cbAC_TextChanged(object sender, EventArgs e)
        {
            CheckAcName();
        }

        private void LoadParams()
        {
            tbSD.Text = MyData.Params.RSD;
            tbED.Text = MyData.Params.RED;
            cbAC.Text = MyData.Params.RACX;
            CheckAcName();
        }

        public override void SaveParams()
        {
            MyData.Params.RSD = tbSD.Text;
            MyData.Params.RED = tbED.Text;
            MyData.Params.RACX = cbAC.Text;
            MyData.Params.RACNM = lbACName.Text;
        }

        private string Check()
        {
            if (tbSD.Text == "" || tbED.Text == "")
                return "Jāievada datums.";

            if (!Utils.StringToDate(tbSD.Text, out startDate) ||
                !Utils.StringToDate(tbED.Text, out endDate))
                return "Nekorekts datums.";

            if (startDate.Year != endDate.Year)
                return "Datumiem jābūt viena gada robežās.";

            ac = cbAC.Text;
            if (ac == "") ac = "%";
            ac = ac.Replace('*', '%');

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

            int cmid = lbCM.SelectedIndex;
            if (cmid == -1) return;

            SaveParams();

            TRepMTTableAdapter ad = MyData.GetKlonsRepAdapter("TRepMT") as TRepMTTableAdapter;
            if (ad == null) return;

            ReportViewerData rd = new ReportViewerData();

            switch (cmid)
            {
                case 0:
                    ad.FillBy_apgr_mt_11(MyData.DataSetKlonsRep.TRepMT, startDate, endDate, ac);
                    break;
                case 1:
                case 2:
                    ad.FillBy_apgr_mt_12(MyData.DataSetKlonsRep.TRepMT, startDate, endDate, ac);
                    break;
                case 3:
                    ad.FillBy_apgr_mt_21(MyData.DataSetKlonsRep.TRepMT, startDate, endDate, ac);
                    break;
                case 4:
                    ad.FillBy_apgr_mt_22(MyData.DataSetKlonsRep.TRepMT, startDate, endDate, ac);
                    break;
            }

            MyData.ReportHelper.PrepareTRepMT();

            switch (cmid)
            {
                case 0:
                    rd.FileName = "Report_Apgr_MT_11";
                    break;
                case 1:
                    rd.FileName = "Report_Apgr_MT_12";
                    break;
                case 2:
                    rd.FileName = "Report_Apgr_MT_13";
                    break;
                case 3:
                case 4:
                    rd.FileName = "Report_Apgr_MT_21";
                    break;
            }

            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.TRepMT;
            rd.AddReportParameters(
                new string[]
                {
                    "RSD", MyData.Params.RSD,
                    "RED", MyData.Params.RED,
                    "RACX", MyData.Params.RACX,
                    "RACNM", MyData.Params.RACNM,
                    "CompanyName", MyData.Params.CompNameX
                });

            switch (cmid)
            {
                case 3:
                    rd.AddReportParameter("RTITLE", "Apgrozijuma pārskats debetam ar summām un daudzumiem");
                    break;
                case 4:
                    rd.AddReportParameter("RTITLE", "Apgrozijuma pārskats kredītam ar summām un daudzumiem");
                    break;
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

        private void cbAC_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoOnF5(sender as ComboBox);
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
