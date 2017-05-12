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
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using Microsoft.Reporting.WinForms;

namespace KlonsF.FormsReportParams
{
    public partial class FormRep_Apgr1 : MyFormBaseF
    {
        public FormRep_Apgr1()
        {
            try {
                InitializeComponent();
                CheckMyFontAndColors();
            }
            catch (Exception e)
            {
                Form_Error.ShowException(e);
            }
            lbACName.Text = "";
            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {tbSD, tbED},
                new Control[] {cbAC, cbAC},
                new Control[] {cbCharCount, cbCharCount},
                new Control[] {cmDoIt, cmDoIt},
                new Control[] {cmTable, cmTable }
            });
            cbCharCount.Text = "*";
        }

        private DateTime startDate = DateTime.MinValue;
        private DateTime endDate = DateTime.MinValue;
        private string ac = "";
        private string startDateStr = "";
        private string endDateStr = "";

        private void FormRepApgr1_Load(object sender, EventArgs e)
        {
            LoadParams();
        }


        private void CheckAcName()
        {
            string s = cbAC.Text;
            if (s == "" || s == "*")
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
                !Utils.StringToDate(tbED.Text, out endDate) ||
                startDate > endDate)
                return "Nekorekts datums.";

            startDateStr = Utils.DateToString(startDate);
            endDateStr = Utils.DateToString(endDate);

            ac = cbAC.Text;
            if (ac == "") ac = "%";
            ac = ac.Replace('*', '%');

            return "OK";
        }

        private void DoIt(bool doreport = true)
        {
            string rt = Check();
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }

            SaveParams();

            ROps2aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps2a") as ROps2aTableAdapter;
            if (ad == null) return;

            try
            {
                if (cbCharCount.Text == "*")
                {
                    ad.FillBy_apgr_11(MyData.DataSetKlonsRep.ROps2a, startDate, endDate, ac);
                }
                else
                {
                    ad.FillBy_apgr_21(MyData.DataSetKlonsRep.ROps2a, startDate, endDate, ac, int.Parse(cbCharCount.Text));
                }

            }
            catch (ConstraintException e)
            {
                Exception e1 = ExceptionHelper.TranslateException(e, MyData.DataSetKlonsRep.ROps2a);
                Form_Error.ShowException(MyMainForm, e1);
                return;
            }

            MyData.ReportHelper.PrepareRops2a();

            if (doreport)
            {
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
                    "RCURRENCY", ""
                    });

                MyMainForm.ShowReport(rd);
            }
            else
            {
                var fm = MyMainForm.ShowFormDialog(typeof(Form_Apgr1)) as Form_Apgr1;
                if (fm == null) return;
                fm.Show();
                fm.LoadParams();
            }
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

        private void cmDoIt_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoIt();
            });
        }

        private void cmTable_Click(object sender, EventArgs e)
        {
            DoIt(false);
        }
    }
}
