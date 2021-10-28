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
    public partial class FormRep_Movement : MyFormBaseP
    {
        public FormRep_Movement()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            LoadParams();
            dgvRows.AutoGenerateColumns = false;

            cbCat1.Text = null;
            cbCatD.Text = null;
            cbCatT.Text = null;
            cbDep.Text = null;
            cbPlace.Text = null;

            GroupListBoxDragDropHelper = new ListBoxDragDropHelper(chlbGroupItems, 
                chlbGroupItems, OnLBDrop, typeof(CheckedListBox));

            InitGroupList();
        }

        private ListBoxDragDropHelper GroupListBoxDragDropHelper = null;

        private void FormRep_ItemsMovement_Load(object sender, EventArgs e)
        {
        }


        private void LoadParams()
        {
            tbDate1.Text = MyData.Params.RSD;
            tbDate2.Text = MyData.Params.RED;
        }

        public override void SaveParams()
        {
            MyData.Params.RSD = tbDate1.Text;
            MyData.Params.RED = tbDate2.Text;
        }

        private void OnLBDrop(ListBoxDragDropHelper sender, int dragitemindex, int dropitemindex)
        {
            GroupListBoxDragDropHelper.MoveItem(chlbGroupItems, dragitemindex, dropitemindex);
        }

        private void dgvRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var evr = dgvRows.GetDataItem(e.RowIndex) as EventRepInfo;
            if (evr == null) return;
            if (evr.IsTotal)
            {
                e.CellStyle.BackColor = ColorThemeHelper.ColorBetween(e.CellStyle.BackColor, e.CellStyle.ForeColor, 0.05f);
                //e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
        }


        public Report_Movement ReportMovement = null;

        public DateTime DT1 = DateTime.MinValue;
        public DateTime DT2 = DateTime.MinValue;
        private string[] GroupFieldsInit = {null, null, null, null, null };
        private int[] GroupFieldsOrder = { -1, -1, -1, -1, -1 };
        private int[] GroupFieldsOrderA = { -1, -1, -1, -1, -1 };
        private int[] FieldsOrder = { -1, -1, -1, -1, -1 };
        private int[] FieldsOrderA = { -1, -1, -1, -1, -1 };
        private bool DoGrouping = false;
        private bool DoFilter = false;
        private string[] Filter = { null, null, null, null, null };

        private void InitGroupList()
        {
            for (int i = 0; i < 5; i++)
                GroupFieldsInit[i] = chlbGroupItems.Items[i] as string;
        }

        private void CheckGroupList()
        {
            int ord = 0;
            int nk = -1;
            DoGrouping = chlbGroupItems.CheckedIndices.Count > 0;
            if (DoGrouping)
            {
                int firstnotchecked = -1;
                for (int i = 0; i < 5; i++)
                    if (!chlbGroupItems.GetItemChecked(i))
                    {
                        firstnotchecked = i;
                        break;
                    }
                if (firstnotchecked > -1)
                    for (int i = firstnotchecked + 1; i < 5; i++)
                        if (chlbGroupItems.GetItemChecked(i))
                        {
                            GroupListBoxDragDropHelper.MoveItem(chlbGroupItems, i, firstnotchecked);
                            firstnotchecked++;
                        }
            }
            for (int i = 0; i < 5; i++)
            {
                var s = chlbGroupItems.Items[i] as string;
                int k = GroupFieldsInit.IndexOf(s);
                FieldsOrder[k] = i;
                if (DoGrouping)
                {
                    if (chlbGroupItems.GetItemChecked(i))
                        nk = ord++;
                    else
                        nk = -1;
                }
                else
                    nk = i;
                GroupFieldsOrder[k] = nk;
            }
            FieldsOrderA = Report_Movement.GetBackSortOrder(FieldsOrder);
            GroupFieldsOrderA = Report_Movement.GetBackSortOrder(GroupFieldsOrder);
        }

        public void CheckFilter()
        {
            Filter[0] = cbCat1.Text.Zn();
            Filter[1] = cbCatD.Text.Zn();
            Filter[2] = cbCatT.Text.Zn();
            Filter[3] = cbDep.Text.Zn();
            Filter[4] = cbPlace.Text.Zn();
            DoFilter = Filter.Where(s => s != null).FirstOrDefault() != null;
            if(DoFilter && DoGrouping)
            {
                for (int i = 0; i < 5; i++)
                    if (GroupFieldsOrder[i] == -1) Filter[i] = null;
            }
        }

        public void CheckTable()
        {
            DataGridViewColumn[] columns = new[] { dgcName, dgcCat1, dgcCatD,
                dgcCatT, dgcDep, dgcPlace};
            var colsordered = new int[6];  //0 - dgcName, 1 - dgcCat1, ...
            int disp_ind = dgcRegNr.DisplayIndex + 1;

            if (DoGrouping)
            {
                dgcRegNr.Visible = false;
                dgcName.Visible = GroupFieldsOrderA[1] == -1;
                for(int i = 0; i < 5; i++)
                    columns[i + 1].Visible = GroupFieldsOrder[i] > -1;

                if (dgcName.Visible)
                {
                    var firstfieldnr = GroupFieldsOrderA[0];
                    if (firstfieldnr == 0 || firstfieldnr == 3 || firstfieldnr == 1)
                        colsordered[0] = firstfieldnr + 1;
                    colsordered[1] = 0;
                }
                else
                {
                    colsordered[0] = 0;
                    colsordered[1] = FieldsOrderA[0] + 1;
                }
                for (int i = 1; i < 5; i++)
                    colsordered[i + 1] = FieldsOrderA[i] + 1;

            }
            else
            {
                dgcRegNr.Visible = true;
                for (int i = 0; i < 6; i++)
                    columns[i].Visible = true;

                colsordered[0] = 0;
                for (int i = 0; i < 5; i++)
                    colsordered[i + 1] = FieldsOrderA[i] + 1;
            }

            for (int i = 5; i >= 0; i--)
                columns[i].Frozen = false;

            for (int i = 0; i < 6; i++)
                columns[colsordered[i]].DisplayIndex = disp_ind + i;

            int lastFrozenCol = -1;

            if (DoGrouping)
                lastFrozenCol = dgcName.Visible ? 1 : 5;
            else
                lastFrozenCol = 0;

            columns[colsordered[lastFrozenCol]].Frozen = true;
            /*
            for (int i = 5; i >= 0; i--)
            {
                bool colfrozen = i <= lastFrozenCol;
                columns[colsordered[i]].Frozen = colfrozen;
                if (colfrozen) break;
            }
            */
        }

        public string CheckParams()
        {
            if (string.IsNullOrEmpty(tbDate1.Text) ||
                string.IsNullOrEmpty(tbDate2.Text))
                return "Jānorāda perioda sākuma un beigu datums.";
            DT1 = Utils.StringToDate(tbDate1.Text).Value;
            DT2 = Utils.StringToDate(tbDate2.Text).Value;
            if (DT1 > DT2)
                return "Norādīti nekorekti datumi.";

            return "OK";
        }

        public void FilterData()
        {
            ReportMovement = new Report_Movement();
            ReportMovement.DoFilter = false;
            ReportMovement.DT1 = DT1;
            ReportMovement.DT2 = DT2;

            ReportMovement.DoFilter = DoFilter;
            ReportMovement.FilterCat1 = Filter[0];
            ReportMovement.FilterCatD = Filter[1];
            ReportMovement.FilterCatT = Filter[2];
            ReportMovement.FilterDep = Filter[3];
            ReportMovement.FilterPlace = Filter[4];

            ReportMovement.DoGrouping = DoGrouping;
            ReportMovement.DoSortByRegnr = chOrderByRegNr.Checked;
            ReportMovement.GroupOrderCat1 = GroupFieldsOrder[0];
            ReportMovement.GroupOrderCatD = GroupFieldsOrder[1];
            ReportMovement.GroupOrderCatT = GroupFieldsOrder[2];
            ReportMovement.GroupOrderDep = GroupFieldsOrder[3];
            ReportMovement.GroupOrderPlace = GroupFieldsOrder[4];

            if (DoGrouping)
                ReportMovement.MakeGroupReport();
            else
                ReportMovement.MakeSimpleReport();

            CheckTable();
            bsRows.DataSource = ReportMovement.ReportRows;
        }

        private void cmFilter_Click(object sender, EventArgs e)
        {
            var er = CheckParams();
            if(er != "OK")
            {
                MyMainForm.ShowWarning(er);
                return;
            }
            CheckGroupList();
            CheckFilter();
            FilterData();
        }

        private string MakeFilterStr()
        {
            string rt = "";
            var fieldnames = new[] { "Kat.", "Nol.kat.", "Nod.nol.kat.", "Strv.", "Atrodas" };
            if (DoFilter)
            {
                for(int i = 0; i < fieldnames.Length; i++)
                {
                    if (string.IsNullOrEmpty(Filter[i])) continue;
                    var s = $"{fieldnames[i]}:[{Filter[i]}]";
                    if (rt == "")
                        rt = s;
                    else
                        rt += ", " + s;
                }
            }
            return rt;
        }

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
        }

        public void MakeReport2()
        {

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportP_Kustiba_2";
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
        }
        public void MakeReport3()
        {
            //var cnm = new[] { "Kat.", "Nol.kat.", "Nod.nol. kat.", "Strv.", "Atrodas" };
            var cnm = new[] {
                "Kategorija",
                "Nolietojuma kategorija",
                "Nolietojuma kategorija nodokļa aprēķinam",
                "Struktīr-vienība",
                "Atrošanās vieta" };
            var cnm2 = new string[5];
            for (int i = 0; i < 5; i++)
                cnm2[i] = GroupFieldsOrderA[i] == -1 ? "" : cnm[GroupFieldsOrderA[i]];

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportP_Kustiba_3";
            rd.Sources["DataSet1"] = ReportMovement.ReportRows;
            rd.AddReportParameters(
                new string[]
                {
                    "PCompany", MyData.Params.CompNameX,
                    "PDate1", Utils.DateToString(DT1),
                    "PDate2", Utils.DateToString(DT2),
                    "PFilterStr", "Atlases parametri:" + MakeFilterStr(),
                    "PCNM1", cnm2[0],
                    "PCNM2", cnm2[1],
                    "PCNM3", cnm2[2],
                    "PCNM4", cnm2[3]
                });
            MyMainForm.ShowReport(rd);
        }

        private void cmReport_Click(object sender, EventArgs e)
        {
            if(bsRows.DataSource == null || bsRows.Count == 0)
            {
                MyMainForm.ShowInfo("Pārskatam nav datu.");
                return;
            }

            MyData.ReportHelper.CheckForErrors(() =>
            {
                if (DoGrouping)
                    if (GroupFieldsOrderA[1] == -1)
                        MakeReport2();
                    else if (GroupFieldsOrderA[3] == -1)
                        MakeReport3();
                    else
                        MyMainForm.ShowWarning("Atlasītajiem datiem programma atskaiti nevar izveidot.");
                else
                    MakeReport1();
            });
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int k = chlbGroupItems.SelectedIndex;
            if (k < 1) return;
            GroupListBoxDragDropHelper.MoveItem(chlbGroupItems, k, k - 1);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int k = chlbGroupItems.SelectedIndex;
            if (k == -1 || k >= chlbGroupItems.Items.Count - 1) return;
            GroupListBoxDragDropHelper.MoveItem(chlbGroupItems, k, k + 1);
        }

        private void tbDate1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbDate1.Text)) return;
            if (!Utils.StringToDate(tbDate1.Text, out DateTime dt))
            {
                e.Cancel = true;
                return;
            }
            dt = dt.FirstDayOfMonth();
            var tx = Utils.DateToString(dt);
            if (tbDate1.Text != tx)
                tbDate1.Text = tx;
        }

        private void tbDate2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbDate2.Text)) return;
            if (!Utils.StringToDate(tbDate2.Text, out DateTime dt))
            {
                e.Cancel = true;
                return;
            }
            dt = dt.LastDayOfMonth();
            var tx = Utils.DateToString(dt);
            if (tbDate2.Text != tx)
                tbDate2.Text = tx;
        }

        private void tsbPrevMonth_Click(object sender, EventArgs e)
        {
            var er = CheckParams();
            if (er != "OK") return;
            var dt2 = DT1.FirstDayOfMonth().AddDays(-1);
            var dt1 = dt2.FirstDayOfMonth();
            tbDate1.Text = Utils.DateToString(dt1);
            tbDate2.Text = Utils.DateToString(dt2);

        }

        private void tsbNextMonth_Click(object sender, EventArgs e)
        {
            var er = CheckParams();
            if (er != "OK") return;
            var dt1 = DT1.LastDayOfMonth().AddDays(1);
            var dt2 = dt1.LastDayOfMonth();
            tbDate1.Text = Utils.DateToString(dt1);
            tbDate2.Text = Utils.DateToString(dt2);
        }
    }
}
