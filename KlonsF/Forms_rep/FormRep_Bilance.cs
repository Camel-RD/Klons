using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsF.Classes;
using KlonsF.DataSets.klonsDataSetTableAdapters;
using KlonsF.DataSets.klonsRepDataSetTableAdapters;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using KlonsF.UI;

namespace KlonsF.Forms
{
    public partial class FormRep_Bilance : MyFormBaseF
    {
        public FormRep_Bilance()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }
        
        private DateTime startDate = DateTime.MinValue;
        private DateTime endDate = DateTime.MinValue;
        private string balid = "";
        private string rtitle = "";
        private string raktivs = "";
        private string rpasivs = "";


        private void Form_Bilance_Load(object sender, EventArgs e)
        {
            bsBalA1.Fill();
            lbCM.SelectedIndex = 0;
            LoadParams();
            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {tbSD, tbED},
                new Control[] {cmReport, cmReport}
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

            if(bsBalA1.Count == 0)
                return "Sarakstā nav atskaišu.";

            if(dgvBalA1.CurrentRow == null)
                return "Jāizvēlas atskaite.";

            balid = dgvBalA1.CurrentRow.Cells[dgcBalA1balid.Index].Value.AsString();
            rtitle = dgvBalA1.CurrentRow.Cells[dgcBalA1Descr.Index].Value.AsString().Nz();
            raktivs = dgvBalA1.CurrentRow.Cells[dgcBalA1TA.Index].Value.AsString().Nz();
            rpasivs = dgvBalA1.CurrentRow.Cells[dgcBalA1TP.Index].Value.AsString().Nz();

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
            
            int selectedreport = lbCM.SelectedIndex;
            if (selectedreport == -1) return;

            SaveParams();

            if (selectedreport == 2)
            {
                DoIt2();
                return;
            }

            var ad = MyData.GetKlonsAdapter("BalA21") as BalA21TableAdapter;
            var ad2 = MyData.GetKlonsAdapter("BalA22") as BalA22TableAdapter;
            if (ad == null) return;

            try
            {
                MyData.DataSetKlons.BalA21.Clear();
                MyData.DataSetKlons.BalA22.Clear();
                ad2.Fill(MyData.DataSetKlons.BalA22);
                ad.FillBy_bal_12(MyData.DataSetKlons.BalA21, startDate, endDate, balid);
            }
            catch (Exception)
            {
                MyMainForm.ShowWarning("Neizdevās sagatavot atskaiti.");
                return;
            }
            MyData.ReportHelper.FillBalA2FromBalA21(balid);


            ReportViewerData rd = new ReportViewerData();

            switch (selectedreport)
            {
                case 0:
                    rd.FileName = "Report_Bilance_1";
                    break;
                case 1:
                    rd.FileName = "Report_Bilance_2";
                    break;
            }

            DataView dv = new DataView(
                MyData.DataSetKlons.BalA22,
                "balid = '" + balid + "'",
                "dc, nr",
                DataViewRowState.CurrentRows);
            rd.Sources["DataSet1"] = dv;
            rd.AddReportParameters(
                new string[]
                {
                    "RSD", MyData.Params.RSD,
                    "RED", MyData.Params.RED,
                    "CompanyName", MyData.Params.CompNameX,
                    "RTITLE", rtitle,
                    "RAKTIVS", raktivs,
                    "RPASIVS", rpasivs
                });
            MyMainForm.ShowReport(rd);
        }

        private bool WCompare(string s, string pattern)
        {
            if (s == pattern) return true;
            if (pattern == "*") return true;
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(pattern)) return true;
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(pattern)) return false;
            if (pattern.EndsWith("*"))
            {
                pattern = pattern.Substring(0, pattern.Length - 1);
                return s.StartsWith(pattern);
            }
            return false;
        }

        private void DoIt2()
        {
            if(MyData.DataSetKlons.BalA3.Count == 0)
            {
                MyData.DataSetKlons.BalA3.Clear();
                MyData.DataSetKlons.BalA2.Clear();
                MyData.FillTable(MyData.DataSetKlons.BalA2);
                MyData.FillTable(MyData.DataSetKlons.BalA3);
            }

            var table = MyData.DataSetKlonsRep.ROps2a1;
            table.Clear();
            var ad = MyData.GetKlonsRepAdapter("ROps2a1") as ROps2a1TableAdapter;
            ad.FillBy(table, startDate, endDate, "%");

            var b1 = MyData.DataSetKlons.BalA1.FindBybalid(balid);
            if (b1 == null) return;
            var bs2 = b1.GetBalA2Rows().ToArray();
            bs2 = bs2.Where(d => d.tp == "S").ToArray();
            foreach (var drb2 in bs2)
            {
                string snr = drb2.nr;
                var bs3 = drb2.GetBalA3Rows();
                foreach(var drb3 in bs3)
                {
                    string ac = drb3.ac;
                    string s;

                    var drs = table.Where(
                        d => WCompare(d.Ac, drb3.ac)
                    ).ToArray();

                    foreach(var dr in drs)
                    {
                        if (drb3.tp == "Db")
                        {
                            s = dr.DStr;
                            if (string.IsNullOrEmpty(s))
                                dr.DStr = snr;
                            else
                                dr.DStr = s + ", " + snr;
                        }
                        else
                        {
                            s = dr.CStr;
                            if (string.IsNullOrEmpty(s))
                                dr.CStr = snr;
                            else
                                dr.CStr = s + ", " + snr;
                        }
                    }
                }
            }

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "Report_Apgr_BilFormula";
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps2a1;
            rd.AddReportParameters(
                new string[]
                {
                    "RSD", MyData.Params.RSD,
                    "RED", MyData.Params.RED,
                    "CompanyName", MyData.Params.CompNameX,
                    "PForReport", b1.Descr
                });
            MyMainForm.ShowReport(rd);
        }


        private void cmReport_Click(object sender, EventArgs e)
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

        private void lbCM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoIt();

            });
        }

        private void cmEdit_Click(object sender, EventArgs e)
        {
            MyMainForm.ShowForm(typeof (Form_BilancesFormula));
        }

    }
}
