using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsA.DataSets;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsA.Forms
{
    public partial class FormRep_Aggregate : MyFormBaseA
    {
        public FormRep_Aggregate()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvRows.AutoGenerateColumns = false;
            lbGroupBy.SelectedIndex = 0;
            LoadParams();
        }

        private void FormRep_ForPerson_Load(object sender, EventArgs e)
        {
            cbPerson.SelectedValue = null;
            cbPosition.SelectedValue = null;
            cbDepartment.SelectedValue = null;
        }

        private DateTime Date1 = DateTime.MinValue;
        private DateTime Date2 = DateTime.MinValue;
        private int? IDP = null;
        private int? IDAM = null;
        private string IDDEP = null;
        private string RPeriod = null;
        private string RFilter = null;
        private string RCaption = null;
        private Report_Salary2.EGroupBy GroupBy = Report_Salary2.EGroupBy.None;
        private List<SalaryRepRow2> ReportRows = new List<SalaryRepRow2>();

        public void LoadParams()
        {
            tbDate1.Text = MyData.Params.RSD;
            tbDate2.Text = MyData.Params.RED;
        }

        public override void SaveParams()
        {
            MyData.Params.RSD = tbDate1.Text;
            MyData.Params.RED = tbDate2.Text;
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
            if (string.IsNullOrEmpty(tbDate1.Text) ||
                string.IsNullOrEmpty(tbDate2.Text))
                return "Nav norādīti datumi.";

            if (!Utils.StringToDate(tbDate1.Text, out Date1) ||
                !Utils.StringToDate(tbDate2.Text, out Date2) ||
                Date1 > Date2)
                return "Ievadīti nekorekti datumi.";

            if (Date1.FirstDayOfMonth() != Date1 ||
                Date2.LastDayOfMonth() != Date2)
                return "Datumus jānorāda sākot ar mēneša pirmo dienu un beidzot ar mēneša pēdējo dienu.";

            if (cbPerson.SelectedIndex == -1 || cbPerson.SelectedValue == null)
                IDP = null;
            else
                IDP = (int)cbPerson.SelectedValue;

            if (cbPosition.SelectedIndex == -1 || cbPosition.SelectedValue == null)
                IDAM = null;
            else
                IDAM = (int)cbPosition.SelectedValue;

            if (IDP == null && IDAM != null)
            {
                cbPosition.SelectedValue = null;
                IDAM = null;
            }

            if (cbDepartment.SelectedIndex == -1 || cbDepartment.SelectedValue == null)
                IDDEP = null;
            else
                IDDEP = (string)cbDepartment.SelectedValue;

            if (IDDEP != null && IDP != null)
                return "Vienlaikus nevar filtrēt pēc darbinieka un struktūrvienības.";

            RPeriod = $"{tbDate1.Text} - {tbDate2.Text}";
            RFilter = "*";

            switch (lbGroupBy.SelectedIndex)
            {
                case 0:
                    GroupBy = Report_Salary2.EGroupBy.YearAndMonth;
                    RCaption = "periods";
                    break;
                case 1:
                    GroupBy = Report_Salary2.EGroupBy.Person;
                    RCaption = "vārds uzvārds";
                    break;
                case 2:
                    GroupBy = Report_Salary2.EGroupBy.PersonAndPosition;
                    RCaption = "vārds uzvārds, amats";
                    break;
                case 3:
                    GroupBy = Report_Salary2.EGroupBy.Department;
                    RCaption = "struktūrvienība";
                    break;
            }

            if (IDDEP != null || lbGroupBy.SelectedIndex == 3)
                RFilter = "Struktūrvienība: " + (IDDEP == null ? "*" : cbDepartment.Text);
            else if (IDAM != null)
                RFilter = "Darbinieks, amats: " + $"{cbPerson.Text}, {cbPosition.Text}";
            else if (IDP != null)
                RFilter = "Darbinieks: " + $"{cbPerson.Text}";
            else
                RFilter = "Darbinieks: *";

            return "OK";
        }

        public void MakeReport()
        {
            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportA_Kopsavilkums_1";
            rd.Sources["dsSalaryReport"] = ReportRows;
            rd.AddReportParameters(new string[]
                {
                    "CompanyName", MyData.Params.CompName,
                    "RFilter", RFilter,
                    "RPeriod", RPeriod,
                    "RRemark", "",
                    "RCaption", RCaption
                });
            MyData.MyMainForm.ShowReport(rd);
        }

        public void GetRows()
        {
            ReportRows = null;
            bsRows.DataSource = null;
            ReportRows = Report_Salary2.MakeAggregatedReport(Date1, Date2, IDP, IDAM, IDDEP, GroupBy);
            bsRows.DataSource = ReportRows;
        }

        private void cmTable_Click(object sender, EventArgs e)
        {
            if (!CheckParams()) return;
            dgcCaption.HeaderText = RCaption;
            GetRows();
        }

        private void cmReport_Click(object sender, EventArgs e)
        {
            if (!CheckParams()) return;
            MakeReport();
        }
    }
}

