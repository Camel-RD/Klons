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
using KlonsFM.UI;
using KlonsFM.Classes;
using KlonsFM.Forms;
using KlonsFM.DataSets.klonsRepDataSetTableAdapters;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using Microsoft.Reporting.WinForms;

namespace KlonsFM.FormsReportParams
{
    public partial class FormRep_ApgrFull : MyFormBaseF
    {
        public FormRep_ApgrFull()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private DateTime startDate = DateTime.MinValue;
        private DateTime endDate = DateTime.MinValue;
        private string ac1 = "";
        private string ac2 = "";
        private string ac3 = "";
        private string ac4 = "";
        private string ac5 = "";
        private string cl = "";

        private string param = "";
        
        private int xac1 = 1;
        private int xac2 = 1;
        private int xac3 = 1;
        private int xac4 = 1;
        private int xac5 = 1;
        private int xcl = 1;

        private void FormRepApgr1_Load(object sender, EventArgs e)
        {
            LoadParams();
            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {tbSD, tbED},
                new Control[] {cbAC1, cbAC1},
                new Control[] {cbAC2, cbAC2},
                new Control[] {cbAC3, cbAC3},
                new Control[] {cbAC4, cbAC4},
                new Control[] {cbAC5, cbAC5},
                new Control[] {cbClid, cbClid},
                new Control[] {cmDoIt, cmDoIt}
            });
        }


        private void LoadParams()
        {
            tbSD.Text = MyData.Params.RSD;
            tbED.Text = MyData.Params.RED;
            cbAC1.Text = MyData.Params.RAP1;
            cbAC2.Text = MyData.Params.RAP2;
            cbAC3.Text = MyData.Params.RAP3;
            cbAC4.Text = MyData.Params.RAP4;
            cbAC5.Text = MyData.Params.RAP5;
            cbClid.Text = MyData.Params.RAP6;
        }

        public override void SaveParams()
        {
            MyData.Params.RSD = tbSD.Text;
            MyData.Params.RED = tbED.Text;
            MyData.Params.RAP1 = cbAC1.Text;
            MyData.Params.RAP2 = cbAC2.Text;
            MyData.Params.RAP3 = cbAC3.Text;
            MyData.Params.RAP4 = cbAC4.Text;
            MyData.Params.RAP5 = cbAC5.Text;
            MyData.Params.RAP6 = cbClid.Text;
        }

        private string Check()
        {
            if (tbSD.Text == "" || tbED.Text == "")
                return "Jāievada datums.";

            if (!Utils.StringToDate(tbSD.Text, out startDate) ||
                !Utils.StringToDate(tbED.Text, out endDate))
                return "Nekorekts datums.";

            ac1 = cbAC1.Text;
            ac2 = cbAC2.Text;
            ac3 = cbAC3.Text;
            ac4 = cbAC4.Text;
            ac5 = cbAC5.Text;
            cl = cbClid.Text;
            param = string.Format("[{0}],[{1}],[{2}],[{3}],[{4}],[{5}]",
                ac1, ac2, ac3, ac4, ac5, cl);
            ac1 = ac1.Replace('*', '%');
            ac2 = ac2.Replace('*', '%');
            ac3 = ac3.Replace('*', '%');
            ac4 = ac4.Replace('*', '%');
            ac5 = ac5.Replace('*', '%');
            cl = cl.Replace('*', '%');
            if (ac1 == "" || ac1 == "%") ac1 = null;
            if (ac2 == "" || ac2 == "%") ac2 = null;
            if (ac3 == "" || ac3 == "%") ac3 = null;
            if (ac4 == "" || ac4 == "%") ac4 = null;
            if (ac5 == "" || ac5 == "%") ac5 = null;
            if (cl == "" || cl == "%") cl = null;

            xac1 = chAC1.Checked ? 1 : 0;
            xac2 = chAC2.Checked ? 1 : 0;
            xac3 = chAC3.Checked ? 1 : 0;
            xac4 = chAC4.Checked ? 1 : 0;
            xac5 = chAC5.Checked ? 1 : 0;
            xcl = chCl.Checked ? 1 : 0;

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
            TRepApAnTableAdapter ad = MyData.GetKlonsRepAdapter("TRepApAn") as TRepApAnTableAdapter;
            if (ad == null) return;

            ad.FillBy_apgr_full_11(MyData.DataSetKlonsRep.TRepApAn, startDate, endDate,
                ac1, ac2, ac3, ac4, ac5, cl,
                xac1, xac2, xac3, xac4, xac5, xcl);

            SaveParams();

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "Report_Apgr_Full_11";
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.TRepApAn;
            rd.AddReportParameters(
                new string[]
                {
                    "RSD", MyData.Params.RSD,
                    "RED", MyData.Params.RED,
                    "RACX", "",
                    "RACNM", param,
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

        private bool DoOnF5(ComboBox sender)
        {
            Action<string> act =
                value =>
                {
                    if (value != null)
                        sender.Text = value;
                };
            if (sender == cbAC1 || sender == cbAC2)
            {
                MyMainForm.ShowFormAcplanDialog(act);
                return true;
            }
            if (sender == cbAC3)
            {
                MyMainForm.ShowFormAcp3Dialog(act);
                return true;
            }
            if (sender == cbAC4)
            {
                MyMainForm.ShowFormAcp4Dialog(act);
                return true;
            }
            if (sender == cbAC5)
            {
                MyMainForm.ShowFormAcp5Dialog(act);
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

        private void cbAC_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoOnF5(sender as ComboBox);
        }

    }
}
