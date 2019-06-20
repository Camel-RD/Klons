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
using System.Globalization;

namespace KlonsA.Forms
{
    public partial class FormRep_Zinas : MyFormBaseA
    {
        public FormRep_Zinas()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvRep.AutoGenerateColumns = false;
            LoadParams();
        }

        private DateTime Date1 = DateTime.MinValue;
        private DateTime Date2 = DateTime.MinValue;
        private DateTime RepDate = DateTime.MinValue;
        private List<EventsReportRow> ReportRows = null;

        private void FormRep_Zinas_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        public void LoadParams()
        {
            tbDate1.Text = MyData.Params.RSD;
            tbDate2.Text = MyData.Params.RED;
            tbName.Text = MyData.Params.RVARDS;
            tbPosition.Text = MyData.Params.RAMATS;
            tbPhoneNr.Text = MyData.Params.RTELEFONS;
            RepDate = DateTime.Now;
            tbDate.Text = Utils.DateToString(DateTime.Today);
        }

        public override void SaveParams()
        {
            MyData.Params.RSD = tbDate1.Text;
            MyData.Params.RED = tbDate2.Text;
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
            if (string.IsNullOrEmpty(tbDate1.Text) || string.IsNullOrEmpty(tbDate2.Text))
                return "Nav norādīti datumi.";
            if (!Utils.StringToDate(tbDate1.Text, out Date1) || !Utils.StringToDate(tbDate2.Text, out Date2) ||
                Date1 > Date2)
                return "Ievadīti nekorekti datumi.";
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbPosition.Text) ||
                string.IsNullOrEmpty(tbPhoneNr.Text) || string.IsNullOrEmpty(tbDate.Text))
                return "Jānorāda atskaites aizpildīšanas dati.";
            if (!DataLoader.IsPeriodLoaded(Date1, Date2))
                return "Norādītajam gada mēnesim dati nav ielādēti.";
            if (string.IsNullOrEmpty(tbDate.Text))
                return "Nav norādīts atskaites aizpildīšanas datums.";
            if (!Utils.StringToDate(tbDate.Text, out RepDate))
                return "Norādīts nekorekts atskaites aizpildīšanas datums.";

            return "OK";
        }

        public void MakeReport()
        {
            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportA_Zinas";
            rd.Sources["DataSet1"] = ReportRows;
            rd.AddReportParameters(new string[]
                {
                    "CompanyName", MyData.Params.CompName,
                    "RREGNR", MyData.Params.CompRegNr,
                    "RVARDS", MyData.Params.RVARDS,
                    "RAMATS", MyData.Params.RAMATS,
                    "RTELEFONS", MyData.Params.RTELEFONS,
                    "RDATUMS", tbDate.Text
                });
            MyData.MyMainForm.ShowReport(rd);
        }

        public void GetRows()
        {
            ReportRows = Report_Events.MakeReport(Date1, Date2);
            bsRep.DataSource = ReportRows;
        }

        private MyXmlDoc MakeXMLv1()
        {
            var xdoc = new MyXmlDoc();

            XmlElement DokZDNv1 = xdoc.CreateElement("DokZDNv1");
            DokZDNv1.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema"); ;
            DokZDNv1.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xdoc.AppendChild(DokZDNv1);

            var s = MyData.Params.CompRegNrPVNx;
            if (s.Length != 11)
            {
                MyMainForm.ShowError("Nekorekts PVN reģ.nr.");
                return null;
            }

            xdoc.XE(DokZDNv1, "NmrKods", s);
            s = MyData.Params.CompAccName;
            xdoc.XE(DokZDNv1, "NmNosaukums", s);
            xdoc.XE(DokZDNv1, "Vaditajs", tbName.Text);
            xdoc.XE(DokZDNv1, "Talrunis", tbPhoneNr.Text);
            xdoc.XE(DokZDNv1, "DatumsAizp", RepDate, true);

            var tab = xdoc.CreateElement("Tab");
            DokZDNv1.AppendChild(tab);
            var rs = xdoc.CreateElement("Rs");
            tab.AppendChild(rs);

            foreach(var row in ReportRows)
            {
                var r = xdoc.CreateElement("R");
                rs.AppendChild(r);
                xdoc.XE(r, "Npk", row.Nr);
                xdoc.XE(r, "PersonasKods", row.PK);
                xdoc.XE(r, "VardsUzvards", row.Name);
                xdoc.XE(r, "IzmDatums", row.RDate, true);
                xdoc.XE(r, "ZinuKods", row.Code);
                xdoc.XENZ(r, "ProfKods", row.ProfessionCode);
            }

            return xdoc;
        }

        private MyXmlDoc MakeXMLv2()
        {
            var xdoc = new MyXmlDoc();

            XmlElement DokZDNv2 = xdoc.CreateElement("DokZDNv2");
            DokZDNv2.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema"); ;
            DokZDNv2.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xdoc.AppendChild(DokZDNv2);

            var s = MyData.Params.CompRegNrPVNx;
            if (s.Length != 11)
            {
                MyMainForm.ShowError("Nekorekts PVN reģ.nr.");
                return null;
            }

            xdoc.XE(DokZDNv2, "NmrKods", s);
            xdoc.XE(DokZDNv2, "Izpilditajs", tbName.Text);
            xdoc.XE(DokZDNv2, "Talrunis", tbPhoneNr.Text);

            var tab = xdoc.CreateElement("Tab");
            DokZDNv2.AppendChild(tab);

            foreach (var row in ReportRows)
            {
                var r = xdoc.CreateElement("R");
                tab.AppendChild(r);
                xdoc.XE(r, "PersonasKods", row.PK);
                xdoc.XE(r, "VardsUzvards", row.Name);
                xdoc.XE(r, "IzmDatums", row.RDate, true);
                xdoc.XE(r, "ZinuKods", row.Code);
                xdoc.XENZ(r, "ProfKods", row.ProfessionCode);
            }

            return xdoc;
        }

        private void DoXML()
        {
            if (!CheckParams()) return;
            SaveParams();
            if(ReportRows == null || ReportRows.Count == 0)
                GetRows();
            MyXmlDoc xdoc;
            if(Date1 < (new DateTime(2019, 05, 01)))
            {
                xdoc = MakeXMLv1();
            }
            else
            {
                xdoc = MakeXMLv2();
            }
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
            if (ReportRows == null || ReportRows.Count == 0)
                GetRows();
            MakeReport();
        }

        private void cmXML_Click(object sender, EventArgs e)
        {
            DoXML();
        }

        private void bnRows_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }
    }
}
