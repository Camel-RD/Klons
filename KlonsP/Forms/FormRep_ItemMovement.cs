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
    public partial class FormRep_ItemMovement : MyFormBaseP
    {
        public FormRep_ItemMovement()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvRows.AutoGenerateColumns = false;
        }

        private void FormRep_ItemsMovement_Load(object sender, EventArgs e)
        {
        }


        private ItemInfo ItemData = null;

        private void SetLabel(ItemInfo it, DateTime dt2)
        {
            lbDescr.Text =
                $"Pamatlīdzeklis: [{it.ItemRegNr.Nz()}] {it.ItemName.Nz()}\n" +
                $"Periods: līdz {Utils.DateToString(dt2)}";
        }

        public void SetItemDataYr(ItemInfo it, DateTime dt2)
        {
            SetLabel(it, dt2);
            ItemData = it;
            bsRows.DataSource = it.GetEventRepList();
        }


        /*
        public void MakeReport1()
        {

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportP_Kustiba_1";
            rd.Sources["DataSet1"] = ReportMovement.ReportRows;
            rd.AddReportParameters(
                new string[]
                {
                    "PCompany", MyData.Params.CompNameX,
                    "PDate1", Utils.DateToString(DT1),
                    "PDate2", Utils.DateToString(DT2),
                    "PFilterStr", "Atlases parametri:" + MakeFilterStr()
                });
            MyMainForm.ShowReport(rd);
        }*/



    }
}
