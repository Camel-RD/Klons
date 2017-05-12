using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsP.DataSets;
using KlonsP.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Components;
using KlonsLIB.Misc;
using KlonsLIB.MySourceGrid.GridRows;
using KlonsLIB.Data;

namespace KlonsP.Forms
{
    public partial class FormRep_TaxDeprec : MyFormBaseP
    {
        public FormRep_TaxDeprec()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            LoadParams();

        }

        private void FormRep_TaxDeprec_Load(object sender, EventArgs e)
        {

        }

        private void LoadParams()
        {
            cbYear.Text = MyData.Params.RYR;
        }

        public override void SaveParams()
        {
            MyData.Params.RYR = cbYear.Text;
        }

        public Report_Movement ReportMovement = null;
        public int YR = 0;

        public string CheckParams()
        {
            if (string.IsNullOrEmpty(cbYear.Text))
                return "Jānorāda pārskata gads.";
            if (!int.TryParse(cbYear.Text, out YR) || YR < 1900 || YR > 2100)
                return "Norādēits nekorekts pārskata gads.";
            return "OK";
        }


        public void FilterData()
        {
            ReportMovement = new Report_Movement();
            ReportMovement.DoFilter = false;
            ReportMovement.DT1 = new DateTime(YR, 1, 1);
            ReportMovement.DT2 = new DateTime(YR, 12, 31);

            ReportMovement.DoFilter = false;

            ReportMovement.DoGrouping = true;
            ReportMovement.GroupOrderCat1 = -1;
            ReportMovement.GroupOrderCatD = -1;
            ReportMovement.GroupOrderCatT = 0;
            ReportMovement.GroupOrderDep = -1;
            ReportMovement.GroupOrderPlace = -1;

            ReportMovement.MakeGroupReport();
            bsRows.DataSource = ReportMovement.ReportRows;
        }

        public void MakeReport()
        {

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportP_NodNol_1";
            rd.Sources["DataSet1"] = ReportMovement.ReportRows;
            rd.AddReportParameters(
                new string[]
                {
                    "PCompany", MyData.Params.CompNameX,
                    "PYR", YR.ToString(),
                    "PDate1", "01.01.\n" + YR,
                    "PDate2", "31.12.\n" + YR
                });
            MyMainForm.ShowReport(rd);
        }

        private void cmGetData_Click(object sender, EventArgs e)
        {
            var er = CheckParams();
            if (er != "OK")
            {
                MyMainForm.ShowWarning(er);
                return;
            }
            FilterData();
        }

        private void cmReport_Click(object sender, EventArgs e)
        {
            if (bsRows.DataSource == null || bsRows.Count == 0)
            {
                MyMainForm.ShowInfo("Pārskatam nav datu.");
                return;
            }

            MyData.ReportHelper.CheckForErrors(() =>
            {
                MakeReport();
            });
        }
    }
}
