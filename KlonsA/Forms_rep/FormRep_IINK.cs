using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsA.DataSets;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using Microsoft.Reporting.WinForms;

namespace KlonsA.Forms
{
    public partial class FormRep_IINK : MyFormBaseA
    {
        public FormRep_IINK()
        {
            InitializeComponent();
            toolStrip1.Renderer = MyMainForm.MainMenuStrip.Renderer;
            CheckMyFontAndColors();
            toolStrip1.Font = Font;
            dgvRep.AutoGenerateColumns = false;
            LoadParams();
        }

        private int Year = 0;
        private int Month = 0;
        private Report_IINk.EReportType ReportTP = Report_IINk.EReportType.ForMonth;
        private DateTime Date1 = DateTime.MinValue;
        private DateTime Date2 = DateTime.MinValue;
        private DateTime DateX = DateTime.MinValue;
        private Report_IINk ReportData = null;
        private List<IINReportRow> ReportRows = null;

        private void FormRep_IINK_Load(object sender, EventArgs e)
        {
            int yr = DateTime.Today.Year;
            int mt = DateTime.Today.Month;
            Utils.AddMonths(ref yr, ref mt, -1);
            cbYear.Text = yr.ToString();
            cbMonth.SelectedIndex = mt - 1;
            WindowState = FormWindowState.Maximized;
        }

        public void LoadParams()
        {
            var sdt = MyData.Params.RSD;
            if (!Utils.StringToDate(sdt, out Date1))
                Date1 = DateTime.Today.FirstDayOfMonth().AddMonths(-1);
            cbYear.Text = Date1.Year.ToString();
            cbMonth.Text = Date1.Month.ToString();

            tbName.Text = MyData.Params.RVARDS;
            tbPosition.Text = MyData.Params.RAMATS;
            tbPhoneNr.Text = MyData.Params.RTELEFONS;
            tbDate.Text = Utils.DateToString(DateTime.Today);
        }

        public override void SaveParams()
        {
            MyData.Params.RSD = Utils.DateToString(Date1);
            MyData.Params.RVARDS = tbName.Text;
            MyData.Params.RAMATS = tbPosition.Text;
            MyData.Params.RTELEFONS = tbPhoneNr.Text;
            MyData.Params.REPDT = tbDate.Text;
        }

        private bool CheckParams()
        {
            var rt = CheckParamsA();
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return false;
            }
            return true;
        }

        private string CheckParamsA()
        {
            if (string.IsNullOrEmpty(cbYear.Text) || string.IsNullOrEmpty(cbMonth.Text))
                return "Nav norādīts gads un mēnesis.";
            if (!int.TryParse(cbYear.Text, out Year) || Year < 1900 || Year > 2100)
                return "Norādīts nekorekts gads.";

            if (cbMonth.SelectedIndex == 12)
            {
                ReportTP = Report_IINk.EReportType.ForYear;
                Month = 12;
                Date1 = new DateTime(Year, 1, 1);
                Date2 = new DateTime(Year, 12, 31);
            }
            else
            {
                Month = cbMonth.SelectedIndex + 1;
                if (Month < 1 || Month > 12)
                    return "Norādōts nekorekts mēnesis.";
                Date1 = new DateTime(Year, Month, 1);
                Date2 = Date1.LastDayOfMonth();
            }

            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbPosition.Text) ||
                string.IsNullOrEmpty(tbPhoneNr.Text) || string.IsNullOrEmpty(tbDate.Text))
                return "Jānorāda atskaites aizpildīšanas dati.";
            if(!Utils.StringToDate(tbDate.Text, out DateX))
                return "Nekorekts atskaites aizpildīšanas datums.";
            tbDate.Text = Utils.DateToString(DateX);
            if (!DataLoader.IsMonthLoaded(Year, Month))
                return "Norādītajam gada mēnesim dati nav ielādēti.";
            return "OK";
        }

        public void MakeReport1()
        {
            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportA_IIN_11";
            rd.Sources["DataSet1"] = ReportRows.Where(d => d.Use);
            rd.AddReportParameters(new string[]
                {
                    "CompanyName", MyData.Params.CompNameX,
                    "RegNr", MyData.Params.CompRegNrPVNa,
                    "RNAME", MyData.Params.RVARDS,
                    "RPOSITION", MyData.Params.RAMATS,
                    "RPHONE", MyData.Params.RTELEFONS,
                    "RDATE", tbDate.Text,
                    "RYear", cbYear.Text
                });
            MyData.MyMainForm.ShowReport(rd);
        }

        public void MakeReport2()
        {
            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportA_IINK2";
            rd.Sources["DataSet1"] = ReportRows.Where(d => d.Use);
            rd.AddReportParameters(new string[]
                {
                    "CompanyName", MyData.Params.CompNameX,
                    "RegNr", MyData.Params.CompRegNrPVNa,
                    "RNAME", MyData.Params.RVARDS,
                    "RPOSITION", MyData.Params.RAMATS,
                    "RPHONE", MyData.Params.RTELEFONS,
                    "RDATE", tbDate.Text,
                    "RYear", cbYear.Text
                });
            MyData.MyMainForm.ShowReport(rd);
        }

        public void GetRows()
        {
            ReportRows = null;
            bsRep.DataSource = null;
            ReportData = new Report_IINk();
            ReportData.MakeReport(ReportTP, Date1, Date2, DateX, chSimple.Checked);
            ReportRows = ReportData.Rows;
            bsRep.DataSource = ReportRows;
        }

        private MyXmlDoc MakeXML()
        {
            var xdoc = new MyXmlDoc();

            XmlElement DokPFPISKv2 = xdoc.CreateElement("DokPFPISKv2");
            DokPFPISKv2.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema"); ;
            DokPFPISKv2.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xdoc.AppendChild(DokPFPISKv2);

            var smt = ReportTP == Report_IINk.EReportType.ForMonth ?
                string.Format("{0:00}", Month) : "00";

            xdoc.XE(DokPFPISKv2, "ParskGads", Year);
            xdoc.XE(DokPFPISKv2, "ParskMen", smt);

            var s = MyData.Params.CompRegNrPVNx;
            if (s.Length != 11)
            {
                MyMainForm.ShowError("Nekorekts PVN reģ.nr.");
                return null;
            }

            xdoc.XE(DokPFPISKv2, "NmrKods", s);
            xdoc.XE(DokPFPISKv2, "IesniegsanasVeids", 1);

            //xdoc.XE(DokPFPISKv2, "Epasts", "");
            xdoc.XENZ(DokPFPISKv2, "Talrunis", tbPhoneNr.Text);
            xdoc.XENZ(DokPFPISKv2, "Sagatavotajs", tbName.Text);

            if (ReportData.Rows.Count == 0) return xdoc;

            var rows = ReportData.Rows;
            var tab = xdoc.CreateElement("Tab");
            DokPFPISKv2.AppendChild(tab);

            foreach (var row in rows)
            {
                var r = xdoc.CreateElement("R");
                tab.AppendChild(r);
                xdoc.XE(r, "PersonasKods", row.PK);
                xdoc.XE(r, "VardsUzvards", row.Name);

                xdoc.XE(r, "IenakumaVeids", row.IncomeType);

                xdoc.XE(r, "IenakumuPeriodsNo", row.Date1);
                xdoc.XE(r, "IenakumuPeriodsLidz", row.Date2);

                //xdoc.XE(r, "IzmaksasDatums", row.Date2);
                if(row.IncomeType != "1001")
                {
                    xdoc.XE(r, "IzmaksasMenesis", row.Date2.Month.ToString("00"));
                }

                xdoc.XE(r, "Ienemumi", row.income);
                xdoc.XENZ(r, "NeapliekamieIenakumi", row.income_nottaxed);
                xdoc.XENZ(r, "NeapliekamaisMinimums", row.untaxed_minimum);
                xdoc.XENZ(r, "AtvieglojumiParApgadajamiem", row.iin_exempt_dependants);
                xdoc.XEIF(row.iin_exempt_x0 > 0.0M, r, "AtvieglojumaKods", row.iin_exempt_x_code);
                xdoc.XENZ(r, "AtvieglojumaSumma", row.iin_exempt_x);

                xdoc.XENZ(r, "VSAObligatasIemaksa", row.dnsn_amount);
                xdoc.XENZ(r, "IemaksasPPF", row.plus_pf_nottaxed);
                xdoc.XENZ(r, "ApdrosinasanasSummaArUzkrasanu", row.plus_li_nottaxed);
                xdoc.XENZ(r, "ApdrosinasanasSummaBezUzkrasanas", row.plus_hi_nottaxed);
                xdoc.XENZ(r, "Izdevumi", row.iin_exempt_expenses);
                xdoc.XENZ(r, "Nodoklis", row.iin_amount);
            }

            return xdoc;
        }

        public void Renum()
        {
            if (ReportRows == null) return;
            int nr = 1;
            foreach (var r in ReportRows)
            {
                if (!r.Use) continue;
                r.nr = nr;
                nr++;
                r.OnPropertyChanged("Nr");
            }
        }

        private void DoXML()
        {
            if (!Validate()) return;
            var xdoc = MakeXML();
            if (xdoc == null) return;
            xdoc.Save();
        }

        private void tsbGetRows_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            if (!CheckParams()) return;
            GetRows();
        }

        private void tsbXML_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            if (!CheckParams()) return;
            if (ReportRows == null)
            {
                MyMainForm.ShowWarning("Nav atlasīti dati.");
                return;
            }
            DoXML();
        }

        public void MarkAll(bool b)
        {
            if (ReportRows == null) return;
            foreach (var r in ReportRows)
            {
                r.Use = b;
                r.OnPropertyChanged("Use");
            }
            dgvRep.InvalidateColumn(dgcUse.Index);
        }

        private void tsbMarkAll_Click(object sender, EventArgs e)
        {
            MarkAll(true);
        }

        private void tsbMarkNone_Click(object sender, EventArgs e)
        {
            MarkAll(false);
        }

        private void tsbReport1_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            if (!CheckParams()) return;
            if (ReportRows == null)
            {
                MyMainForm.ShowWarning("Nav atlasīti dati.");
                return;
            }
            MakeReport1();
        }

        private void tsbReport2_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            if (!CheckParams()) return;
            if (ReportRows == null)
            {
                MyMainForm.ShowWarning("Nav atlasīti dati.");
                return;
            }
            MakeReport2();
        }

        private void bnRows_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }
    }
}
