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
using KlonsLIB.Data;
using KlonsLIB.Misc;

namespace KlonsP.Forms
{
    public partial class Form_TaxDeprecCat : MyFormBaseP
    {
        public Form_TaxDeprecCat()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvRows.AutoGenerateColumns = false;
            InsertInToolStrip(toolStrip1, cbCat, 1);
        }

        private void Form_TaxDeprecCat_Load(object sender, EventArgs e)
        {
            IsLoading = false;
            SetCurrentCat();
        }

        public void SetCatT(int id, bool empty = false)
        {
            if (empty)
            {
                dgvRows.DataSource = null;
                return;
            }
            if(dgvRows.DataSource == null)
                dgvRows.DataSource = bsRows;
            bsRows.Filter = "CATT=" + id;
        }

        public void SetCurrentCat()
        {
            if(bsCatT.Count == 0 || bsCatT.Current == null)
            {
                SetCatT(0, true);
                return;
            }
            var dr = bsCatT.CurrentDataRow as KlonsPDataSet.CATTRow;
            SetCatT(dr.ID);
        }

        private bool IgnoreCurrentChanged = false;
        private void bsCatT_CurrentChanged(object sender, EventArgs e)
        {
            if (IsLoading || IgnoreCurrentChanged) return;
            SetCurrentCat();
        }

        private void MakeReport()
        {
            var dr = bsCatT.CurrentDataRow as KlonsPDataSet.CATTRow;

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportP_NodNolKat_1";
            rd.Sources["dsRows"] = bsRows;
            rd.AddReportParameters(
                new string[]
                {
                    "PCompany", MyData.Params.CompNameX,
                    "PCatStr", $"[{dr.CODE}] {dr.DESCR}",
                    "PCatRate", $"{dr.RATE}%"
                });
            MyMainForm.ShowReport(rd);

        }

        private void tsbReport_Click(object sender, EventArgs e)
        {
            if (bsRows.Count == 0 || bsCatT.Current == null)
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
