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
    public partial class FormRep_VSAOI : MyFormBaseA
    {
        public FormRep_VSAOI()
        {
            InitializeComponent();
            menuStrip1.Renderer = MyMainForm.MainMenuStrip.Renderer;
            CheckMyFontAndColors();
            menuStrip1.Font = this.Font;
            dgvRep.AutoGenerateColumns = false;
            LoadParams();
        }

        private int Year = 0;
        private int Month = 0;
        private int PayDay = 15;
        private int ReportTP = 1;
        private DateTime Date1 = DateTime.MinValue;
        private DateTime Date2 = DateTime.MinValue;
        private Report_VSAOI1 ReportData = null;
        private List<VSAOIReportRow1> ReportRows = null;

        private void FormRep_VSAOI_Load(object sender, EventArgs e)
        {
            int yr = DateTime.Today.Year;
            cbYear.Items.Clear();
            for (int i = yr - 2; i <= yr + 1; i++)
                cbYear.Items.Add(i.ToString());
            cbYear.Text = yr.ToString();
            cbTp.SelectedIndex = 0;
            WindowState = FormWindowState.Maximized;
        }

        public void LoadParams()
        {
            var sdt = MyData.Params.RSD;
            if (!Utils.StringToDate(sdt, out Date1))
                Date1 = DateTime.Today.FirstDayOfMonth().AddMonths(-1);
            cbYear.Text = Date1.Year.ToString();
            cbMonth.SelectedIndex = Date1.Month - 1;

            tbName.Text = MyData.Params.RVARDS;
            tbPosition.Text = MyData.Params.RAMATS;
            tbPhoneNr.Text = MyData.Params.RTELEFONS;
            tbDate.Text = Utils.DateToString(DateTime.Today);

            tbPayDate.Text = MyData.Params.RPAYDAY;
        }

        public override void SaveParams()
        {
            MyData.Params.RSD = Utils.DateToString(Date1);
            MyData.Params.RVARDS = tbName.Text;
            MyData.Params.RAMATS = tbPosition.Text;
            MyData.Params.RTELEFONS = tbPhoneNr.Text;
            MyData.Params.REPDT = tbDate.Text;
            MyData.Params.RPAYDAY = PayDay.ToString();
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
            if (!int.TryParse(cbYear.Text, out Year) || !int.TryParse(cbMonth.Text, out Month) ||
                Year < 1900 || Year > 2100 || Month < 1 || Month > 12)
                return "Norādīts nekorekts gads un mēnesis.";
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbPosition.Text) ||
                string.IsNullOrEmpty(tbPhoneNr.Text) || string.IsNullOrEmpty(tbDate.Text))
                return "Jānorāda atskaites aizpildīšanas dati.";
            Date1 = new DateTime(Year, Month, 1);
            Date2 = Date1.LastDayOfMonth();
            if (!DataLoader.IsMonthLoaded(Year, Month))
                return "Norādītajam gada mēnesim dati nav ielādēti.";
            if (string.IsNullOrEmpty(tbPayDate.Text))
                return "Jānorāda darba algas izmaksas datums (diena).";
            if (!int.TryParse(tbPayDate.Text, out PayDay) || PayDay < 1 || PayDay > 31)
                return "Nekorekts darba algas izmaksas datums (diena).";
            ReportTP = cbTp.SelectedIndex + 1;
            if (ReportTP == 0) ReportTP = 1;
            return "OK";
        }

        public void MakeReport()
        {
            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportA_VSAOI_1";
            rd.Sources["DataSet1"] = ReportRows;
            rd.AddReportParameters(new string[]
                {
                    "CompanyName", MyData.Params.CompName,
                    "RREGNR", MyData.Params.CompRegNr,
                    "RVARDS", MyData.Params.RVARDS,
                    "RAMATS", MyData.Params.RAMATS,
                    "RTELEFONS", MyData.Params.RTELEFONS,
                    "RDATUMS", tbDate.Text,
                    "RGADS", cbYear.Text,
                    "RMENESIS", Utils.MonthNames[Month - 1],
                    "RMAKSDAT", PayDay.ToString(),
                    "RTP", ReportTP.ToString()
                });
            MyData.MyMainForm.ShowReport(rd);
        }

        public void GetRows()
        {
            ReportData = new Report_VSAOI1();
            ReportData.MakeReport(Date1, Date2);
            FilterRows();
        }

        public void FilterRows()
        {
            int k = cbTp.SelectedIndex;
            if (ReportData?.Rows1 == null || k == -1)
            {
                ReportRows = null;
                bsRep.DataSource = null;
                return;
            }
            ReportRows = ReportData.RowsX[k];
            bsRep.DataSource = ReportRows;
        }

        private MyXmlDoc MakeXML()
        {
            var xdoc = new MyXmlDoc();

            XmlElement DokDDZv1 = xdoc.CreateElement("DokDDZv1");
            DokDDZv1.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema"); ;
            DokDDZv1.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xdoc.AppendChild(DokDDZv1);

            xdoc.XE(DokDDZv1, "TaksGads", Year);
            xdoc.XE(DokDDZv1, "TaksMenesis", Month);

            var s = MyData.Params.CompRegNrPVNx;
            if (s.Length != 11)
            {
                MyMainForm.ShowError("Nekorekts PVN reģ.nr.");
                return null;
            }

            xdoc.XE(DokDDZv1, "NmrKods", s);

            s = MyData.Params.CompAccName;
            xdoc.XE(DokDDZv1, "NmNosaukums", s);

            xdoc.XE(DokDDZv1, "IzmaksasDatums", PayDay);

            xdoc.XE(DokDDZv1, "AtbildPers", tbName.Text);
            DateTime dt;
            if (!string.IsNullOrEmpty(tbDate.Text) && DateTime.TryParse(tbDate.Text, out dt))
                xdoc.XE(DokDDZv1, "DatumsAizp", dt);
            xdoc.XENZ(DokDDZv1, "Talrunis", tbPhoneNr.Text);

            if (ReportData.Rows1.Count == 0) return xdoc;

            xdoc.XE(DokDDZv1, "Ienakumi", ReportData.TotalRow.Income);
            xdoc.XE(DokDDZv1, "Iemaksas", ReportData.TotalRow.SAI);
            xdoc.XE(DokDDZv1, "PrecizetieIenakumi", ReportData.TotalRow.IncomeCorrected);
            xdoc.XE(DokDDZv1, "PrecizetasIemaksas", ReportData.TotalRow.SAICorrected);
            xdoc.XE(DokDDZv1, "IetIedzNodoklis", ReportData.TotalRow.IIN);
            xdoc.XE(DokDDZv1, "RiskaNod", ReportData.TotalRow.URVN);

            for(int i = 0; i < 6; i++)
            {
                var rows = ReportData.RowsX[i];
                if (rows.Count == 0) continue;
                var tab = xdoc.CreateElement("Tab" + (i + 1));
                DokDDZv1.AppendChild(tab);
                var rs = xdoc.CreateElement("Rs");
                tab.AppendChild(rs);

                foreach (var row in rows)
                {
                    var r = xdoc.CreateElement("R");
                    rs.AppendChild(r);
                    xdoc.XE(r, "Npk", row.Nr);
                    xdoc.XE(r, "PersonasKods", row.PK);
                    xdoc.XE(r, "VardsUzvards", row.Name);
                    xdoc.XE(r, "SamStat", row.Tp2s);
                    if(row.Tp != 4)
                    {
                        xdoc.XE(r, "Ienakumi", row.Income);
                        xdoc.XE(r, "Iemaksas", row.SAI);
                        xdoc.XENZ(r, "PrecizetieIenakumi", row.IncomeCorrected);
                        xdoc.XENZ(r, "PrecizetasIemaksas", row.SAICorrected);

                    }
                    xdoc.XENZ(r, "IetIedzNodoklis", row.IIN);
                    xdoc.XE(r, "DarbaVeids", "1");
                    xdoc.XE(r, "RiskaNodPazime", row.HasURVN ? "1" : "0");
                    xdoc.XEIF(row.HasURVN, r, "RiskaNod", row.URVN);
                    xdoc.XE(r, "Stundas", (int)row.Hours);
                }

                var trow = ReportData.TotalRowsX[i];

                xdoc.XE(tab, "Ienakumi", trow.Income);
                xdoc.XE(tab, "Iemaksas", trow.SAI);
                xdoc.XENZ(tab, "PrecizetieIenakumi", trow.IncomeCorrected);
                xdoc.XENZ(tab, "PrecizetasIemaksas", trow.SAICorrected);
                xdoc.XENZ(tab, "IetIedzNodoklis", trow.IIN);
                xdoc.XENZ(tab, "RiskaNod", trow.URVN);

            }

            return xdoc;
        }

        private MyXmlDoc MakeXMLV2()
        {
            var xdoc = new MyXmlDoc();

            XmlElement DokDDZv2 = xdoc.CreateElement("DokDDZv3");
            DokDDZv2.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema"); ;
            DokDDZv2.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xdoc.AppendChild(DokDDZv2);

            xdoc.XE(DokDDZv2, "Precizejums", "false");
            xdoc.XE(DokDDZv2, "ParskGads", Year);
            xdoc.XE(DokDDZv2, "ParskMen", Month);

            var s = MyData.Params.CompRegNrPVNx;
            if (s.Length != 11)
            {
                MyMainForm.ShowError("Nekorekts PVN reģ.nr.");
                return null;
            }

            xdoc.XE(DokDDZv2, "NmrKods", s);

            xdoc.XE(DokDDZv2, "IzmaksasDatums", PayDay);

            xdoc.XE(DokDDZv2, "Sagatavotajs", tbName.Text);
            xdoc.XENZ(DokDDZv2, "Talrunis", tbPhoneNr.Text);

            if (ReportData == null || ReportData.Rows1.Count == 0) return xdoc;

            xdoc.XE(DokDDZv2, "Ienakumi", ReportData.TotalRow.Income);
            xdoc.XE(DokDDZv2, "Iemaksas", ReportData.TotalRow.SAI);
            xdoc.XE(DokDDZv2, "PrecizetieIenakumi", ReportData.TotalRow.IncomeCorrected);
            xdoc.XE(DokDDZv2, "PrecizetasIemaksas", ReportData.TotalRow.SAICorrected);
            xdoc.XE(DokDDZv2, "IeturetaisNodoklis", ReportData.TotalRow.IIN);
            xdoc.XE(DokDDZv2, "RiskaNodeva", ReportData.TotalRow.URVN);

            for (int i = 0; i < 6; i++)
            {
                var rows = ReportData.RowsX[i];
                if (rows.Count == 0) continue;
                var tab = xdoc.CreateElement("Tab" + (i + 1));
                DokDDZv2.AppendChild(tab);

                foreach (var row in rows)
                {
                    var r = xdoc.CreateElement("R");
                    tab.AppendChild(r);
                    xdoc.XE(r, "PersonasKods", row.PK);
                    xdoc.XE(r, "VardsUzvards", row.Name);
                    xdoc.XE(r, "Statuss", row.Tp2s);
                    if (row.Tp != 4)
                    {
                        xdoc.XE(r, "Ienakumi", row.Income);
                        xdoc.XE(r, "Iemaksas", row.SAI);
                        xdoc.XENZ(r, "PrecizetieIenakumi", row.IncomeCorrected);
                        xdoc.XENZ(r, "PrecizetasIemaksas", row.SAICorrected);

                    }
                    xdoc.XENZ(r, "IeturetaisNodoklis", row.IIN);
                    xdoc.XE(r, "DarbaVeids", "1");
                    xdoc.XE(r, "RiskaNodevasPazime", row.HasURVN ? "1" : "0");
                    xdoc.XEIF(row.HasURVN, r, "RiskaNodeva", row.URVN);
                    xdoc.XE(r, "Stundas", (int)row.Hours);
                }
            }

            return xdoc;
        }

        private void DoXML()
        {
            if (!CheckParams()) return;
            SaveParams();

            if (ReportRows == null)
                ReportRows = new List<VSAOIReportRow1>();

            var xdoc = Year < 2017 ? MakeXML() : MakeXMLV2();
            if (xdoc == null) return;
            xdoc.Save();
        }

        private void cmTable_Click(object sender, EventArgs e)
        {
            if (!CheckParams()) return;
            GetRows();
        }

        private void cmReport_Click(object sender, EventArgs e)
        {
            if (!CheckParams()) return;
            SaveParams();

            if (ReportRows == null)
                ReportRows = new List<VSAOIReportRow1>();
            bsRep.DataSource = ReportRows;
            MakeReport();
        }

        private void cbTp_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterRows();
        }

        private void miDoXML_Click(object sender, EventArgs e)
        {
            DoXML();
        }

        private void bnRows_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

    }
}
