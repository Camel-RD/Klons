using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using KlonsF.DataSets;
using KlonsF.UI;
using KlonsF.Classes;
using KlonsF.Forms;
using KlonsF.DataSets.klonsRepDataSetTableAdapters;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using Microsoft.Reporting.WinForms;

namespace KlonsF.FormsReportParams
{
    public partial class FormRep_PVNDekl : MyFormBaseF
    {
        public FormRep_PVNDekl()
        {
            InitializeComponent();
            toolStrip1.Renderer = new MyToolStripRenderer(MyData.Settings.ColorTheme);
            CheckMyFontAndColors();
        }

        private DateTime startDate = DateTime.MinValue;
        private DateTime endDate = DateTime.MinValue;
        private DateTime datenow = DateTime.MinValue;
        private int imenesis = -1;
        private int iceturksnis = -1;
        private int ipusgads = -1;
        private string sgads = "";
        private string smenesis = "";
        private string speriods = "";
        private decimal xsumma = 0.00M;

        private decimal[] ax = new decimal[100];

        XmlDocument xdoc = null;

        private void FormRepApgr1_Load(object sender, EventArgs e)
        {
            LoadParams();
            tbDateNow.Text = Utils.DateToString(DateTime.Today);

            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {tbSD, tbED},
                new Control[] {tbDateNow, null},
                new Control[] {tbAmats, null},
                new Control[] {tbVards, null},
                new Control[] {tbUzvards, null},
                new Control[] {tbXSumma, null}
            });
        }


        private void LoadParams()
        {
            tbSD.Text = MyData.Params.RSD;
            tbED.Text = MyData.Params.RED;
            tbAmats.Text = MyData.Params.RpvAmats;
            tbVards.Text = MyData.Params.RpvVards;
            tbUzvards.Text = MyData.Params.RpvUzvards;
            tbXSumma.Text = MyData.Params.RpvnRG1;
        }

        public override void SaveParams()
        {
            MyData.Params.RSD = tbSD.Text;
            MyData.Params.RED = tbED.Text;
            MyData.Params.RpvAmats = tbAmats.Text;
            MyData.Params.RpvVards = tbVards.Text;
            MyData.Params.RpvUzvards = tbUzvards.Text;
            MyData.Params.RpvnRG1 = tbXSumma.Text;
        }

        private string Check()
        {
            if (tbSD.Text == "" || tbED.Text == "")
                return "Jāievada datums.";

            if (!Utils.StringToDate(tbSD.Text, out startDate) ||
                !Utils.StringToDate(tbED.Text, out endDate) ||
                startDate > endDate ||
                startDate.Year != endDate.Year ||
                startDate.Year < 2000 || startDate.Year > 3000 ||
                startDate.Day != 1 ||
                endDate.AddDays(1).Day != 1)
            {
                return "Nekorekts datums.";
            }
            if (!Utils.StringToDate(tbDateNow.Text, out datenow) ||
                datenow.Year < 2000 || datenow.Year > 3000)
            {
                return "Nekorekts izrakstīšanas datums.";
            }
            
            if (!decimal.TryParse(tbXSumma.Text, out xsumma))
                return "Nekorekts summas lauka vērtība.";

            imenesis = -1;
            iceturksnis = -1;
            ipusgads = -1;
            sgads = startDate.Year.ToString();
            smenesis = "  ";
            speriods = "       ";
            int k = -1;
            if (startDate.Month == endDate.Month)
            {
                imenesis = startDate.Month;
                if (startDate.Month < 10)
                    smenesis = "0" + startDate.Month;
                else
                    smenesis = startDate.Month.ToString();
            }
            else
            {
                if (startDate.Month == 1 && endDate.Month == 6)
                {
                    ipusgads = 1;
                    k = 4;
                }
                else if (startDate.Month == 7 && endDate.Month == 12)
                {
                    ipusgads = 2;
                    k = 5;
                }
                else if (startDate.Month % 3 == 1 && endDate.Month == startDate.Month + 2)
                {
                    k = (startDate.Month - 1) / 3;
                    iceturksnis = k + 1;
                }
                else if (startDate.Month == 1 && endDate.Month == 12)
                {
                    k = -1;
                }
                else
                {
                    return "Nekorekts datums.";
                }
            }
            if (k > -1)
            {
                if(k > 0)
                    speriods = "        ".Substring(0, k);
                speriods += "X";
                speriods += "        ".Substring(0, 6 - k);
            }
            return "OK";
        }

        private Dictionary<string, decimal> sdeb = new Dictionary<string, decimal>();
        private Dictionary<string, decimal> skred = new Dictionary<string, decimal>();
        private string[] rdata = null;
        private decimal sd(string id)
        {
            decimal d;
            if (!sdeb.TryGetValue(id, out d)) return 0.00M;
            return d;
        }

        private decimal sc(string id)
        {
            decimal d;
            if (!skred.TryGetValue(id, out d)) return 0.00M;
            return d;
        }

        private void ClearA()
        {
            for (int i = 0; i < ax.Length; i++)
            {
                ax[i] = 0.00M;
            }
        }

        private decimal MRound(decimal value)
        {
            return Math.Round(value, 2);
        }

        private void DoCalc()
        {
            sdeb.Clear();
            skred.Clear();
            ClearA();

            foreach (var dr in MyData.DataSetKlonsRep.ROps2a)
            {
                sdeb[dr.Ac] = dr.TDb;
                skred[dr.Ac] = dr.TCr;
            }

            ax[41] = sc("101") + sc("104") + sc("107") +
                sc("K042") + sc("K043") + sc("K042") + sc("K052");

            ax[42] = sc("102") + sc("105") + sc("108");
            //rinda 411
            ax[73] = sc("K041") + sc("K051") + sc("B01") + sc("D01") + sc("M01");
            ax[44] = sc("111");
            ax[45] = sc("112") + sc("K044") + sc("K053");
            ax[46] = sc("113");
            ax[47] = sc("114");
            ax[48] = sc("115");
            //rinda 481 482
            ax[71] = sc("117") + sc("K046") + sc("K055");
            ax[72] = sc("118");
            ax[43] = ax[44] + ax[45] + ax[46] + ax[47] + ax[48] + ax[71];

            ax[49] = sc("121");
            ax[50] = sc("131") + sc("133") + sc("135") + sc("136") + sc("137");
            ax[51] = sc("132") + sc("134");
            
            ax[40] = ax[41] + ax[42] + ax[73] + ax[43] +
                     ax[49] + ax[50] + ax[51] + ax[72];

            ax[52] = MRound(ax[41]*0.21M);
            ax[53] = MRound(ax[42]*0.12M);

            decimal axt1, axt2;

            axt1 = sc("201") + sc("202") + sc("204") +
                   sc("205") + sc("206") + sc("207") +
                   sc("K102") + sc("K103") + sc("K106") + sc("K111");

            axt2 = Math.Abs(axt1 - ax[52] - ax[53]);
            if (axt2 > 0)
            {
                string ms = string.Format(
                    "No ieņēmumiem aprēķinātais PVN ir: {0:N2}\n" +
                    "No ieņēmumiem iegrāmatotais PVN ir: {1:N2}\n\n" +
                    "Starpība ir: {2:N2}\n\n" +
                    "Ja vēlaties izmantot aprēķināto PVN spiežiet 'Jā'!\n" +
                    "Ja vēlaties izmantot iegrāmatoto PVN spiežiet 'Nē'!",
                    ax[52] + ax[53],
                    axt1, axt2);
                if (MyMessageBox.Show(ms, "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    ax[52] = sc("201") + sc("204") + sc("206");
                    ax[53] = sc("202") + sc("205") + sc("207");
                }
            }
            ax[52] = ax[52] + sd("K101") + sd("K105") + sd("B12") + sd("D12") + sd("M12");
            ax[53] = ax[53];

            ax[54] = sc("211");
            ax[55] = sc("231") + sc("233") + sc("235") + sc("236") + sc("238");
            ax[56] = sc("232") + sc("234") + sc("237");

            //korekcijas
            ax[57] = sc("301") + sc("302") + sc("303") +
                     sc("304") + sc("305") + sc("306") + sc("307") + sc("308");
            
            ax[57] = ax[57] + sc("K101") + sc("K105") + sc("B12") + sc("D12") + sd("M12");

            //ax[58] = sc("251")

            ax[61] = sd("311");
            
            ax[62] = sd("301") + sd("302") + sd("303") +
                     sd("305") + sd("306") + sd("307") + sd("308");

            ax[62] = ax[62] + sd("K101") + sd("K105") + sd("B12") + sd("D12") + sd("M12");
            ax[63] = sd("321");
            ax[64] = sd("331") + sd("332");
            ax[65] = sd("304");
            ax[66] = -sd("341");
            ax[67] = sd("201") + sd("202") + sd("203") +
                     sd("204") + sd("205") + sd("206") + sd("207") + sd("211");

            //ax[68] = sd("351")
            ax[60] = ax[61] + ax[62] + ax[63] + ax[64] + ax[65];

            ax[59] = ax[52] + ax[53] + ax[54] + ax[55] + 
                ax[56] + ax[57] + ax[58];

            ax[69] = ax[60] + ax[66] + ax[67] + ax[68];

            if (ax[59] > ax[69])
                ax[80] = ax[59] - ax[69];
            else
                ax[70] = ax[69] - ax[59];

            rdata = new string[41];

            for (int i = 0; i < rdata.Length; i++)
                rdata[i] = ax[i + 40].ToString();
        }

        private void DoCalc2018()
        {
            sdeb.Clear();
            skred.Clear();
            ClearA();

            foreach (var dr in MyData.DataSetKlonsRep.ROps2a)
            {
                sdeb[dr.Ac] = dr.TDb;
                skred[dr.Ac] = dr.TCr;
            }

            ax[41] = sc("101") + sc("104") + sc("107") +
                sc("K042") + sc("K043") + sc("K042") + sc("K052");

            ax[42] = sc("105") + sc("108");
            //rinda 421
            ax[74] = sc("102");
            //rinda 411
            ax[73] = sc("K041") + sc("K051") + sc("B01") + sc("D01") + sc("B03") + sc("D03") + sc("M01");
            ax[44] = sc("111");
            ax[45] = sc("112") + sc("K044") + sc("K053");
            //rinda 451
            ax[75] = sc("1121");
            ax[46] = sc("113");
            ax[47] = sc("114");
            ax[48] = sc("115");
            //rinda 481 482
            ax[71] = sc("117") + sc("K046") + sc("K055");
            ax[72] = sc("118");
            ax[43] = ax[44] + ax[45] + ax[75] + ax[46] + ax[47] + ax[48] + ax[71];

            ax[49] = sc("121");
            ax[50] = sc("131") + sc("133") + sc("135") + sc("136") + sc("137");
            ax[51] = sc("134") + sc("138");
            //rinda 511
            ax[76] = sc("132");

            ax[40] = ax[41] + ax[42] + ax[73] + ax[74] + ax[43] +
                     ax[49] + ax[50] + ax[51] + ax[76] + ax[72];

            ax[52] = MRound(ax[41] * 0.21M);
            ax[53] = MRound(ax[42] * 0.12M);
            //rinda 531
            ax[77] = MRound(ax[74] * 0.05M);

            decimal axt1, axt2;

            axt1 = sc("201") + sc("202") + sc("204") +
                   sc("205") + sc("206") + sc("207") +
                   sc("K102") + sc("K103") + sc("K106") + sc("K111");

            axt2 = Math.Abs(axt1 - ax[52] - ax[53] - ax[77]);
            if (axt2 > 0)
            {
                string ms = string.Format(
                    "No ieņēmumiem aprēķinātais PVN ir: {0:N2}\n" +
                    "No ieņēmumiem iegrāmatotais PVN ir: {1:N2}\n\n" +
                    "Starpība ir: {2:N2}\n\n" +
                    "Ja vēlaties izmantot aprēķināto PVN spiežiet 'Jā'!\n" +
                    "Ja vēlaties izmantot iegrāmatoto PVN spiežiet 'Nē'!",
                    ax[52] + ax[53] + ax[77],
                    axt1, axt2);
                if (MyMessageBox.Show(ms, "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    ax[52] = sc("201") + sc("204") + sc("206");
                    ax[53] = sc("205") + sc("207");
                    ax[77] = sc("202");
                }
            }
            ax[52] = ax[52] + sd("K101") + sd("K105") + sd("B12") + sd("D12") + sd("M12");
            ax[53] = ax[53];

            ax[54] = sc("211");
            ax[55] = sc("231") + sc("233") + sc("235") + sc("236") + sc("238");
            ax[56] = sc("234") + sc("237");
            //rinda 561
            ax[78] = sc("232");

            //korekcijas
            ax[57] = sc("301") + sc("302") + sc("303") +
                     sc("304") + sc("305") + sc("306") + sc("307") + sc("308");

            ax[57] = ax[57] + sc("K101") + sc("K105") + sc("B12") + sc("D12") + sc("B14") + sc("D14") + sc("M12");

            //ax[58] = sc("251")

            ax[61] = sd("311");

            ax[62] = sd("301") + sd("302") + sd("303") +
                     sd("305") + sd("306") + sd("307") + sd("308");

            ax[62] = ax[62] + sd("K101") + sd("K105") + sd("B12") + sd("D12") + sd("M12");
            ax[63] = sd("321");
            ax[64] = sd("331") + sd("332");
            ax[65] = sd("304");
            ax[66] = -sd("341");
            ax[67] = sd("201") + sd("202") + sd("203") +
                     sd("204") + sd("205") + sd("206") + sd("207") + sd("211");

            //ax[68] = sd("351")
            ax[60] = ax[61] + ax[62] + ax[63] + ax[64] + ax[65];

            ax[59] = ax[52] + ax[53] + ax[77] + ax[54] + ax[55] +
                ax[56] + ax[78] + ax[57] + ax[58];

            ax[69] = ax[60] + ax[66] + ax[67] + ax[68];

            if (ax[59] > ax[69])
                ax[80] = ax[59] - ax[69];
            else
                ax[70] = ax[69] - ax[59];

            rdata = new string[41];

            for (int i = 0; i < rdata.Length; i++)
                rdata[i] = ax[i + 40].ToString();
        }


        private void DoPVNDekl()
        {
            ROps2aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps2a") as ROps2aTableAdapter;
            if (ad == null) return;

            ad.FillBy_pvn_10(MyData.DataSetKlonsRep.ROps2a, startDate, endDate);

            DoCalc();

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "Report_PVN_dekl_1";
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps2a;

            string regnr = MyData.Params.CompRegNrPVNx;
            if (regnr.Length < 11)
                regnr += "           ".Substring(regnr.Length);

            rd.AddReportParameters(
                new string[]
                {
                    "RREGNR", regnr,
                    "RGADS", "" + startDate.Year,
                    "RMENESIS", smenesis,
                    "RPERIODSX", speriods,
                    "RAMATS", tbAmats.Text,
                    "RVARDS", tbVards.Text,
                    "RUZVARDS", tbUzvards.Text,
                    "RTEL", MyData.Params.CompPhone,
                    "RDATENOW", Utils.DateToString(datenow),
                    "CompanyName", MyData.Params.CompName
                });
            rd.AddReportParameter("RDATA", rdata);
            MyMainForm.ShowReport(rd);
        }

        private void DoPVNDekl2018()
        {
            ROps2aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps2a") as ROps2aTableAdapter;
            if (ad == null) return;

            ad.FillBy_pvn_10(MyData.DataSetKlonsRep.ROps2a, startDate, endDate);

            DoCalc2018();

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "Report_PVN_dekl_2";
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps2a;

            string regnr = MyData.Params.CompRegNrPVNx;
            if (regnr.Length < 11)
                regnr += "           ".Substring(regnr.Length);

            rd.AddReportParameters(
                new string[]
                {
                    "RREGNR", regnr,
                    "RGADS", "" + startDate.Year,
                    "RMENESIS", smenesis,
                    "RPERIODSX", speriods,
                    "RAMATS", tbAmats.Text,
                    "RVARDS", tbVards.Text,
                    "RUZVARDS", tbUzvards.Text,
                    "RTEL", MyData.Params.CompPhone,
                    "RDATENOW", Utils.DateToString(datenow),
                    "CompanyName", MyData.Params.CompName
                });
            rd.AddReportParameter("RDATA", rdata);
            MyMainForm.ShowReport(rd);
        }

        private void DoPVNPiel11T()
        {
            ROps1aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            if (ad == null) return;

            ad.FillBy_pvn_22(MyData.DataSetKlonsRep.ROps1a,
                startDate, endDate, xsumma, xsumma);

            MyMainForm.ShowForm(typeof (Form_PVN_Piel));
        }

        private void DoPVNPiel11()
        {
            ROps1aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            if (ad == null) return;

            ReportViewerData rd = new ReportViewerData();
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps1a;

            ad.FillBy_pvn_22(MyData.DataSetKlonsRep.ROps1a,
                startDate, endDate, xsumma, xsumma);
            rd.FileName = "Report_PVN_piel1_1";

            string regnr = MyData.Params.CompRegNrPVNx;
            if (regnr.Length < 11)
                regnr += "           ".Substring(regnr.Length);

            rd.AddReportParameters(
                new string[]
                {
                    "RREGNR", regnr,
                    "RGADS", "" + startDate.Year,
                    "RMENESIS", smenesis,
                    "RPERIODSX", speriods,
                    "RDATENOW", Utils.DateToString(datenow),
                    "CompanyName", MyData.Params.CompName
                });
            MyMainForm.ShowReport(rd);
        }

        private void DoPVNPiel11_2018()
        {
            ROps1aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            if (ad == null) return;

            ReportViewerData rd = new ReportViewerData();
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps1a;

            ad.FillBy_pvn_22(MyData.DataSetKlonsRep.ROps1a,
                startDate, endDate, xsumma, xsumma);
            rd.FileName = "Report_PVN_piel1_2";

            string regnr = MyData.Params.CompRegNrPVNx;
            if (regnr.Length < 11)
                regnr += "           ".Substring(regnr.Length);

            rd.AddReportParameters(
                new string[]
                {
                    "RREGNR", regnr,
                    "RGADS", "" + startDate.Year,
                    "RMENESIS", smenesis,
                    "RPERIODSX", speriods,
                    "RDATENOW", Utils.DateToString(datenow),
                    "CompanyName", MyData.Params.CompName
                });
            MyMainForm.ShowReport(rd);
        }

        private void DoPVNPiel12T()
        {
            ROps1aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            if (ad == null) return;

            ad.FillBy_pvn_52(MyData.DataSetKlonsRep.ROps1a,
                startDate, endDate, xsumma, xsumma);

            MyMainForm.ShowForm(typeof(Form_PVN_Piel));
        }

        private void DoPVNPiel12()
        {
            ROps1aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            if (ad == null) return;

            ReportViewerData rd = new ReportViewerData();
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps1a;

            ad.FillBy_pvn_52(MyData.DataSetKlonsRep.ROps1a,
                startDate, endDate, xsumma, xsumma);
            rd.FileName = "Report_PVN_piel2_1";

            string regnr = MyData.Params.CompRegNrPVNx;
            if (regnr.Length < 11)
                regnr += "           ".Substring(regnr.Length);

            rd.AddReportParameters(
                new string[]
                {
                    "RREGNR", regnr,
                    "RGADS", "" + startDate.Year,
                    "RMENESIS", smenesis,
                    "RPERIODSX", speriods,
                    "RDATENOW", Utils.DateToString(datenow),
                    "CompanyName", MyData.Params.CompName
                });
            MyMainForm.ShowReport(rd);
        }

        private void DoPVNPiel12_2018()
        {
            ROps1aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            if (ad == null) return;

            ReportViewerData rd = new ReportViewerData();
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps1a;

            ad.FillBy_pvn_52(MyData.DataSetKlonsRep.ROps1a,
                startDate, endDate, xsumma, xsumma);
            rd.FileName = "Report_PVN_piel2_2";

            string regnr = MyData.Params.CompRegNrPVNx;
            if (regnr.Length < 11)
                regnr += "           ".Substring(regnr.Length);

            rd.AddReportParameters(
                new string[]
                {
                    "RREGNR", regnr,
                    "RGADS", "" + startDate.Year,
                    "RMENESIS", smenesis,
                    "RPERIODSX", speriods,
                    "RDATENOW", Utils.DateToString(datenow),
                    "CompanyName", MyData.Params.CompName
                });
            MyMainForm.ShowReport(rd);
        }

        private void DoPVNPiel13T()
        {
            ROps1aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            if (ad == null) return;

            ad.FillBy_pvn_32(MyData.DataSetKlonsRep.ROps1a,
                startDate, endDate, xsumma, xsumma);

            MyMainForm.ShowForm(typeof (Form_PVN_Piel));
        }

        private void DoPVNPiel13()
        {
            ROps1aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            if (ad == null) return;

            ReportViewerData rd = new ReportViewerData();
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps1a;

            ad.FillBy_pvn_32(MyData.DataSetKlonsRep.ROps1a,
                startDate, endDate, xsumma, xsumma);
            rd.FileName = "Report_PVN_piel3_1";

            string regnr = MyData.Params.CompRegNrPVNx;
            if (regnr.Length < 11)
                regnr += "           ".Substring(regnr.Length);

            rd.AddReportParameters(
                new string[]
                {
                    "RREGNR", regnr,
                    "RGADS", "" + startDate.Year,
                    "RMENESIS", smenesis,
                    "RPERIODSX", speriods,
                    "RDATENOW", Utils.DateToString(datenow),
                    "CompanyName", MyData.Params.CompName
                });
            MyMainForm.ShowReport(rd);
        }

        private void DoPVNPiel13_2018()
        {
            ROps1aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            if (ad == null) return;

            ReportViewerData rd = new ReportViewerData();
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps1a;

            ad.FillBy_pvn_32(MyData.DataSetKlonsRep.ROps1a,
                startDate, endDate, xsumma, xsumma);
            rd.FileName = "Report_PVN_piel3_2";

            string regnr = MyData.Params.CompRegNrPVNx;
            if (regnr.Length < 11)
                regnr += "           ".Substring(regnr.Length);

            rd.AddReportParameters(
                new string[]
                {
                    "RREGNR", regnr,
                    "RGADS", "" + startDate.Year,
                    "RMENESIS", smenesis,
                    "RPERIODSX", speriods,
                    "RDATENOW", Utils.DateToString(datenow),
                    "CompanyName", MyData.Params.CompName
                });
            MyMainForm.ShowReport(rd);
        }

        private void DoPVNPiel2T()
        {
            ROps1aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            if (ad == null) return;

            ad.FillBy_pvn_42(MyData.DataSetKlonsRep.ROps1a,
                startDate, endDate, xsumma, xsumma);

            MyMainForm.ShowForm(typeof (Form_PVN_Piel));
        }

        private void DoPVNPiel2Ta()
        {
            ROps1aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            if (ad == null) return;

            ad.FillBy_pvn_41(MyData.DataSetKlonsRep.ROps1a,
                startDate, endDate, xsumma, xsumma);

            MyMainForm.ShowForm(typeof(Form_PVN_Piel));
        }


        #region ========== XE functions ==========

        private XmlElement XE(string name, string text)
        {
            XmlElement el = xdoc.CreateElement(name);
            XmlText tx = xdoc.CreateTextNode(text);
            el.AppendChild(tx);
            return el;
        }
        private XmlElement XE(string name, decimal value)
        {
            string text = value.ToString("0.00");
            return XE(name, text);
        }
        private XmlElement XE(string name, int value)
        {
            return XE(name, value.ToString());
        }
        private XmlElement XE(string name, DateTime value)
        {
            return XE(name, value.ToString("yyyy-MM-dd"));
        }

        private XmlElement XE(XmlNode parent, string name, string text)
        {
            XmlElement el = XE(name, text);
            parent.AppendChild(el);
            return el;
        }
        private XmlElement XE(XmlNode parent, string name, decimal value)
        {
            XmlElement el = XE(name, value);
            parent.AppendChild(el);
            return el;
        }
        private XmlElement XE(XmlNode parent, string name, int value)
        {
            return XE(parent, name, value.ToString());
        }
        private XmlElement XE(XmlNode parent, string name, DateTime value)
        {
            XmlElement el = XE(name, value);
            parent.AppendChild(el);
            return el;
        }

        private XmlElement XEB(bool condition, XmlNode parent, string name, string text)
        {
            if (!condition) return null;
            return XE(parent, name, text);
        }
        private XmlElement XEB(bool condition, XmlNode parent, string name, decimal value)
        {
            if (!condition) return null;
            return XE(parent, name, value);
        }
        private XmlElement XEB(bool condition, XmlNode parent, string name, int value)
        {
            if (!condition) return null;
            return XE(parent, name, value);
        }
        private XmlElement XEB(bool condition, XmlNode parent, string name, DateTime value)
        {
            if (!condition) return null;
            return XE(parent, name, value);
        }

        private XmlElement XER(XmlNode parent, string name, string text)
        {
            if (string.IsNullOrEmpty(text)) return null;
            return XE(parent, name, text);
        }
        private XmlElement XER(XmlNode parent, string name, decimal value)
        {
            if (value == 0.00M) return null;
            return XE(parent, name, value);
        }
        private XmlElement XER(XmlNode parent, string name, int value)
        {
            if (value == 0) return null;
            return XE(parent, name, value);
        }
        #endregion

        private bool DoXML(bool pvn2 = true)
        {
            string s,s1;

            ROps2aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps2a") as ROps2aTableAdapter;
            if (ad == null) return false;

            ad.FillBy_pvn_10(MyData.DataSetKlonsRep.ROps2a, startDate, endDate);

            DoCalc();

            ROps1aTableAdapter ad2 = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            if (ad2 == null) return false;

            var table_piel11 = ad2.GetDataBy_pvn_22(startDate, endDate, xsumma, xsumma);
            var table_piel12 = ad2.GetDataBy_pvn_52(startDate, endDate, xsumma, xsumma);
            var table_piel13 = ad2.GetDataBy_pvn_32(startDate, endDate, xsumma, xsumma);
            var table_piel2 = ad2.GetDataBy_pvn_42(startDate, endDate, xsumma, xsumma);


            xdoc = new XmlDocument();
            
            XmlDeclaration xmldecl = xdoc.CreateXmlDeclaration("1.0", null, null);
            xdoc.AppendChild(xmldecl);
            
            XmlElement DokPVNv4 = xdoc.CreateElement("DokPVNv4");
            DokPVNv4.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema"); ;
            DokPVNv4.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xdoc.AppendChild(DokPVNv4);

            XE(DokPVNv4, "ParskGads", startDate.Year);

            XEB(imenesis > 0, DokPVNv4, "ParskMen", imenesis);
            XEB(iceturksnis > 0, DokPVNv4, "ParskCeturksnis", iceturksnis);
            XEB(ipusgads > 0, DokPVNv4, "TaksPusgads", ipusgads);

            s = MyData.Params.CompRegNrPVNx;
            if (s.Length != 11)
            {
                MyMainForm.ShowError("Nekorekts PVN reģ.nr.");
                return false;
            }
            XE(DokPVNv4, "NmrKods", s);
            

            /*
            XE(DokPVNv4, "SummaParm", s);
            XE(DokPVNv4, "ParmaksUzKontu", s);
            XE(DokPVNv4, "ParmaksUzKontuSumma", s);
            XE(DokPVNv4, "IbanNumurs", s);
            */
            s = MyData.Params.CompPhone;
            XEB(!string.IsNullOrEmpty(s), DokPVNv4, "Talrunis", s);

            //DokPVNv4.AppendChild(XEL("Epasts", s));



            XmlElement PVN = xdoc.CreateElement("PVN");
            DokPVNv4.AppendChild(PVN);

            XER(PVN, "R41", ax[41]);
            XER(PVN, "R411", ax[73]);
            XER(PVN, "R42", ax[42]);
            XER(PVN, "R43", ax[43]);
            XER(PVN, "R45", ax[45]);
            XER(PVN, "R46", ax[46]);
            XER(PVN, "R47", ax[47]);
            XER(PVN, "R48", ax[48]);
            XER(PVN, "R481", ax[71]);
            XER(PVN, "R482", ax[72]);
            XER(PVN, "R49", ax[49]);
            XER(PVN, "R50", ax[50]);
            XER(PVN, "R51", ax[51]);
            XER(PVN, "R52", ax[52]);
            XER(PVN, "R53", ax[53]);
            XER(PVN, "R54", ax[54]);
            XER(PVN, "R55", ax[55]);
            XER(PVN, "R56", ax[56]);

            XER(PVN, "R61", ax[61]);
            XER(PVN, "R62", ax[62]);
            XER(PVN, "R63", ax[63]);
            XER(PVN, "R64", ax[64]);
            XER(PVN, "R65", ax[65]);
            XER(PVN, "R66", ax[66]);
            XER(PVN, "R67", ax[67]);

            XER(PVN, "R57", ax[57]);


            XmlElement R = null;

            if (table_piel11.Count > 0)
            {
                XmlElement PVN1I = xdoc.CreateElement("PVN1I");
                DokPVNv4.AppendChild(PVN1I);


                foreach (var row in table_piel11)
                {
                    R = xdoc.CreateElement("R");
                    PVN1I.AppendChild(R);

                    s = row.RegNr;
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s.Length > 1)
                        {
                            s1 = s.Substring(0, 2);
                            XE(R, "DpValsts", s1);
                            s1 = s.Substring(2);
                            XE(R, "DpNumurs", s1);
                        }
                    }

                    XER(R, "DpNosaukums", row.Name);
                    XE(R, "DarVeids", row.DocTyp2);
                    XE(R, "VertibaBezPvn", row.Summ);
                    XE(R, "PvnVertiba", row.PVN);
                    XER(R, "DokVeids", row.DocTyp1);
                    s = row.DocSt.Nz() + " " + row.DocNr.Nz();
                    s = s.Trim();
                    XER(R, "DokNumurs", s);
                    if (!row.IsDeteNull())
                        XE(R, "DokDatums", row.Dete);
                }
            }

            if (table_piel12.Count > 0)
            {
                XmlElement PVN1II = xdoc.CreateElement("PVN1II");
                DokPVNv4.AppendChild(PVN1II);

                foreach (var row in table_piel12)
                {
                    R = xdoc.CreateElement("R");
                    PVN1II.AppendChild(R);

                    s = row.RegNr;
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s.Length > 1)
                        {
                            s1 = s.Substring(0, 2);
                            XE(R, "DpValsts", s1);
                            s1 = s.Substring(2);
                            XE(R, "DpNumurs", s1);
                        }
                    }

                    XE(R, "DpNosaukums", row.Name);
                    XE(R, "DarVeids", row.DocTyp2);
                    XE(R, "VertibaBezPvn", row.Summ);
                    XE(R, "PvnVertiba", row.PVN);
                    XER(R, "ValVertiba", row.SummC);
                    XER(R, "ValKods", row.Cur);
                    s = row.DocSt.Nz() + " " + row.DocNr.Nz();
                    s = s.Trim();
                    XER(R, "DokNumurs", s);
                    if (!row.IsDeteNull())
                        XE(R, "DokDatums", row.Dete);
                }
            }

            if (table_piel13.Count > 0)
            {
                XmlElement PVN1III = xdoc.CreateElement("PVN1III");
                DokPVNv4.AppendChild(PVN1III);

                foreach (var row in table_piel13)
                {
                    R = xdoc.CreateElement("R");
                    PVN1III.AppendChild(R);

                    s = row.RegNr;
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s.Length > 1)
                        {
                            s1 = s.Substring(0, 2);
                            XE(R, "DpValsts", s1);
                            s1 = s.Substring(2);
                            XE(R, "DpNumurs", s1);
                        }
                    }

                    XER(R, "DpNosaukums", row.Name);

                    s = row.DocTyp2;
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s == "411") s = "41.1";
                        if (s == "482") s = "48.2";
                    }
                    
                    if (row.DocTyp1 != "T")
                        XE(R, "DarVeids", s);

                    XE(R, "VertibaBezPvn", row.Summ);

                    if (row.DocTyp2 == null || (row.DocTyp2 != "411" && row.DocTyp2 != "41.1"))
                        XE(R, "PvnVertiba", row.PVN);

                    XER(R, "DokVeids", row.DocTyp1);
                    s = row.DocSt.Nz() + " " + row.DocNr.Nz();
                    s = s.Trim();
                    XER(R, "DokNumurs", s);
                    if (!row.IsDeteNull())
                        XE(R, "DokDatums", row.Dete);
                }
            }

            if (pvn2 && table_piel2.Count > 0)
            {
                XmlElement PVN2 = xdoc.CreateElement("PVN2");
                DokPVNv4.AppendChild(PVN2);

                foreach (var row in table_piel2)
                {
                    R = xdoc.CreateElement("R");
                    PVN2.AppendChild(R);

                    s = row.RegNr;
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s.Length > 1)
                        {
                            s1 = s.Substring(0, 2);
                            XE(R, "Valsts", s1);
                            s1 = s.Substring(2);
                            XE(R, "PVNNumurs", s1);
                        }
                    }

                    XE(R, "Summa", row.Summ);
                    XE(R, "Pazime", row.DocTyp2);
                }
            }
            return true;
        }

        private bool DoXML_2018(bool pvn2 = true)
        {
            string s, s1;

            ROps2aTableAdapter ad = MyData.GetKlonsRepAdapter("ROps2a") as ROps2aTableAdapter;
            if (ad == null) return false;

            ad.FillBy_pvn_10(MyData.DataSetKlonsRep.ROps2a, startDate, endDate);

            DoCalc2018();

            ROps1aTableAdapter ad2 = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            if (ad2 == null) return false;

            var table_piel11 = ad2.GetDataBy_pvn_22(startDate, endDate, xsumma, xsumma);
            var table_piel12 = ad2.GetDataBy_pvn_52(startDate, endDate, xsumma, xsumma);
            var table_piel13 = ad2.GetDataBy_pvn_32(startDate, endDate, xsumma, xsumma);
            var table_piel2 = ad2.GetDataBy_pvn_42(startDate, endDate, xsumma, xsumma);


            xdoc = new XmlDocument();

            XmlDeclaration xmldecl = xdoc.CreateXmlDeclaration("1.0", null, null);
            xdoc.AppendChild(xmldecl);

            XmlElement DokPVNv4 = xdoc.CreateElement("DokPVNv5");
            DokPVNv4.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema"); ;
            DokPVNv4.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xdoc.AppendChild(DokPVNv4);

            XE(DokPVNv4, "ParskGads", startDate.Year);

            XEB(imenesis > 0, DokPVNv4, "ParskMen", imenesis);
            XEB(iceturksnis > 0, DokPVNv4, "ParskCeturksnis", iceturksnis);
            XEB(ipusgads > 0, DokPVNv4, "TaksPusgads", ipusgads);

            s = MyData.Params.CompRegNrPVNx;
            if (s.Length != 11)
            {
                MyMainForm.ShowError("Nekorekts PVN reģ.nr.");
                return false;
            }
            XE(DokPVNv4, "NmrKods", s);


            /*
            XE(DokPVNv4, "SummaParm", s);
            XE(DokPVNv4, "ParmaksUzKontu", s);
            XE(DokPVNv4, "ParmaksUzKontuSumma", s);
            XE(DokPVNv4, "IbanNumurs", s);
            */
            s = MyData.Params.CompPhone;
            XEB(!string.IsNullOrEmpty(s), DokPVNv4, "Talrunis", s);

            //DokPVNv4.AppendChild(XEL("Epasts", s));



            XmlElement PVN = xdoc.CreateElement("PVN");
            DokPVNv4.AppendChild(PVN);

            XER(PVN, "R41", ax[41]);
            XER(PVN, "R411", ax[73]);
            XER(PVN, "R42", ax[42]);
            XER(PVN, "R421", ax[74]);
            XER(PVN, "R43", ax[43]);
            XER(PVN, "R44", ax[44]);
            XER(PVN, "R45", ax[45]);
            XER(PVN, "R451", ax[75]);
            XER(PVN, "R46", ax[46]);
            XER(PVN, "R47", ax[47]);
            XER(PVN, "R48", ax[48]);
            XER(PVN, "R481", ax[71]);
            XER(PVN, "R482", ax[72]);
            XER(PVN, "R49", ax[49]);
            XER(PVN, "R50", ax[50]);
            XER(PVN, "R51", ax[51]);
            XER(PVN, "R511", ax[76]);
            XER(PVN, "R52", ax[52]);
            XER(PVN, "R53", ax[53]);
            XER(PVN, "R531", ax[77]);
            XER(PVN, "R54", ax[54]);
            XER(PVN, "R55", ax[55]);
            XER(PVN, "R56", ax[56]);
            XER(PVN, "R561", ax[78]);

            XER(PVN, "R61", ax[61]);
            XER(PVN, "R62", ax[62]);
            XER(PVN, "R63", ax[63]);
            XER(PVN, "R64", ax[64]);
            XER(PVN, "R65", ax[65]);
            XER(PVN, "R66", ax[66]);
            XER(PVN, "R67", ax[67]);

            XER(PVN, "R57", ax[57]);


            XmlElement R = null;

            if (table_piel11.Count > 0)
            {
                XmlElement PVN1I = xdoc.CreateElement("PVN1I");
                DokPVNv4.AppendChild(PVN1I);


                foreach (var row in table_piel11)
                {
                    R = xdoc.CreateElement("R");
                    PVN1I.AppendChild(R);

                    s = row.RegNr;
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s.Length > 1)
                        {
                            s1 = s.Substring(0, 2);
                            XE(R, "DpValsts", s1);
                            s1 = s.Substring(2);
                            XE(R, "DpNumurs", s1);
                        }
                    }

                    XER(R, "DpNosaukums", row.Name);
                    XE(R, "DarVeids", row.DocTyp2);
                    XE(R, "VertibaBezPvn", row.Summ);
                    XE(R, "PvnVertiba", row.PVN);
                    XER(R, "DokVeids", row.DocTyp1);
                    s = row.DocSt.Nz() + " " + row.DocNr.Nz();
                    s = s.Trim();
                    XER(R, "DokNumurs", s);
                    if (!row.IsDeteNull())
                        XE(R, "DokDatums", row.Dete);
                }
            }

            if (table_piel12.Count > 0)
            {
                XmlElement PVN1II = xdoc.CreateElement("PVN1II");
                DokPVNv4.AppendChild(PVN1II);

                foreach (var row in table_piel12)
                {
                    R = xdoc.CreateElement("R");
                    PVN1II.AppendChild(R);

                    s = row.RegNr;
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s.Length > 1)
                        {
                            s1 = s.Substring(0, 2);
                            XE(R, "DpValsts", s1);
                            s1 = s.Substring(2);
                            XE(R, "DpNumurs", s1);
                        }
                    }

                    XE(R, "DpNosaukums", row.Name);
                    XE(R, "DarVeids", row.DocTyp2);
                    XE(R, "VertibaBezPvn", row.Summ);
                    XE(R, "PvnVertiba", row.PVN);
                    XER(R, "ValVertiba", row.SummC);
                    XER(R, "ValKods", row.Cur);
                    s = row.DocSt.Nz() + " " + row.DocNr.Nz();
                    s = s.Trim();
                    XER(R, "DokNumurs", s);
                    if (!row.IsDeteNull())
                        XE(R, "DokDatums", row.Dete);
                }
            }

            if (table_piel13.Count > 0)
            {
                XmlElement PVN1III = xdoc.CreateElement("PVN1III");
                DokPVNv4.AppendChild(PVN1III);

                foreach (var row in table_piel13)
                {
                    R = xdoc.CreateElement("R");
                    PVN1III.AppendChild(R);

                    s = row.RegNr;
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s.Length > 1)
                        {
                            s1 = s.Substring(0, 2);
                            XE(R, "DpValsts", s1);
                            s1 = s.Substring(2);
                            XE(R, "DpNumurs", s1);
                        }
                    }

                    XER(R, "DpNosaukums", row.Name);

                    s = row.DocTyp2;
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s == "411") s = "41.1";
                        if (s == "482") s = "48.2";
                    }

                    if (row.DocTyp1 != "T")
                        XE(R, "DarVeids", s);

                    XE(R, "VertibaBezPvn", row.Summ);

                    if (row.DocTyp2 == null || (row.DocTyp2 != "411" && row.DocTyp2 != "41.1"))
                        XE(R, "PvnVertiba", row.PVN);

                    XER(R, "DokVeids", row.DocTyp1);
                    s = row.DocSt.Nz() + " " + row.DocNr.Nz();
                    s = s.Trim();
                    XER(R, "DokNumurs", s);
                    if (!row.IsDeteNull())
                        XE(R, "DokDatums", row.Dete);
                }
            }

            if (pvn2 && table_piel2.Count > 0)
            {
                XmlElement PVN2 = xdoc.CreateElement("PVN2");
                DokPVNv4.AppendChild(PVN2);

                foreach (var row in table_piel2)
                {
                    R = xdoc.CreateElement("R");
                    PVN2.AppendChild(R);

                    s = row.RegNr;
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s.Length > 1)
                        {
                            s1 = s.Substring(0, 2);
                            XE(R, "Valsts", s1);
                            s1 = s.Substring(2);
                            XE(R, "PVNNumurs", s1);
                        }
                    }

                    XE(R, "Summa", row.Summ);
                    XE(R, "Pazime", row.DocTyp2);
                }
            }
            return true;
        }


        private void DoIt(int selectedreport)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoIta(selectedreport);
            });
        }

        private void DoIta(int selectedreport)
        {
            string rt = Check();
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }
            
            SaveParams();

            if(startDate.Year < 2018)
            {
                switch (selectedreport)
                {
                    case 0:
                        DoPVNDekl();
                        break;
                    case 1:
                        DoPVNPiel11();
                        break;
                    case 2:
                        DoPVNPiel12();
                        break;
                    case 3:
                        DoPVNPiel13();
                        break;
                    case 4:
                        DoPVNPiel11T();
                        break;
                    case 5:
                        DoPVNPiel12T();
                        break;
                    case 6:
                        DoPVNPiel13T();
                        break;
                    case 7:
                        DoPVNPiel2T();
                        break;
                    case 8:
                        DoPVNPiel2Ta();
                        break;
                }
            }
            else
            {
                switch (selectedreport)
                {
                    case 0:
                        DoPVNDekl2018();
                        break;
                    case 1:
                        DoPVNPiel11_2018();
                        break;
                    case 2:
                        DoPVNPiel12_2018();
                        break;
                    case 3:
                        DoPVNPiel13_2018();
                        break;
                    case 4:
                        DoPVNPiel11T();
                        break;
                    case 5:
                        DoPVNPiel12T();
                        break;
                    case 6:
                        DoPVNPiel13T();
                        break;
                    case 7:
                        DoPVNPiel2T();
                        break;
                    case 8:
                        DoPVNPiel2Ta();
                        break;
                }
            }


        }

        private void DoItXML(bool pvn2 = true)
        {
            string rt = Check();
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }

            SaveParams();

            if (startDate.Year < 2018)
            {
                if (!DoXML(pvn2)) return;

            }
            else
            {
                if (!DoXML_2018(pvn2)) return;
            }

            FileDialog fd = new SaveFileDialog();
            fd.InitialDirectory = MyData.FolderForXMLReports;
            fd.DefaultExt = "xml";
            fd.Filter = "XML faili (*.xml)|*.xml";
            if (fd.ShowDialog(MyMainForm) != DialogResult.OK) return;
            try
            {
                xdoc.Save(fd.FileName);
            }
            catch (Exception e)
            {
                MyException e1 = new MyException("Neizdevās saglabāt atskaiti.", e);
                Form_Error.ShowException(MyMainForm, e1);
            }
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            OnNaviKey(sender, e);
        }

        private void FormRep_PVNDekl_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveParams();
        }

        private void pVNDeklarācijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoIt(0);
        }
        private void piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoIt(1);
        }
        private void piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoIt(2);
        }
        private void piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoIt(3);
        }
        private void piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DoIt(4);
        }
        private void piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DoIt(5);
        }
        private void piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DoIt(6);
        }
        private void pVN2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoIt(7);
        }
        private void piel2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemPaDokumentiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoIt(8);
        }

        private void xMLAtskaiteBezPVN2PielikumaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoItXML(false);

            });
        }

        private void xMLAtskaiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoItXML();

            });
        }


    }
}
