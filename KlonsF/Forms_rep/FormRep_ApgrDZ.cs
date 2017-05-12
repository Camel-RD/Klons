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
    public partial class FormRep_ApgrDZ : MyFormBaseF
    {
        public FormRep_ApgrDZ()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private DateTime startDate = DateTime.MinValue;
        private DateTime endDate = DateTime.MinValue;

        private void FormRepApgr1_Load(object sender, EventArgs e)
        {
            LoadParams();
            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {tbSD, tbED},
                new Control[] {cmDoIt, cmDoIt}
            });
        }


        private void LoadParams()
        {
            tbSD.Text = MyData.Params.RSD;
            tbED.Text = MyData.Params.RED;
        }

        public override void SaveParams()
        {
            MyData.Params.RSD = tbSD.Text;
            MyData.Params.RED = tbED.Text;
        }

        private string Check()
        {
            if (tbSD.Text == "" || tbED.Text == "")
                return "Jāievada datums.";

            if (!Utils.StringToDate(tbSD.Text, out startDate) ||
                !Utils.StringToDate(tbED.Text, out endDate))
                return "Nekorekts datums.";

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
            ROps2aTableAdapter ad2a = MyData.GetKlonsRepAdapter("ROps2a") as ROps2aTableAdapter;
            ROps3aTableAdapter ad3a = MyData.GetKlonsRepAdapter("ROps3a") as ROps3aTableAdapter;
            if (ad2a == null) return;
            if (ad3a == null) return;

            ad2a.FillBy_apgr_dz_12(MyData.DataSetKlonsRep.ROps2a, startDate, endDate);
            ad3a.FillBy_apgr_dz_11(MyData.DataSetKlonsRep.ROps3a, startDate, endDate);

            SaveParams();

            MyData.ReportHelper.PrepareRops2a();

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "Report_Apgr_DZ_1";
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps2a;
            rd.Sources["DataSet2"] = MyData.DataSetKlonsRep.ROps3a;
            rd.AddReportParameters(
                new string[]
                {
                    "RSD", MyData.Params.RSD,
                    "RED", MyData.Params.RED,
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

    }
}
