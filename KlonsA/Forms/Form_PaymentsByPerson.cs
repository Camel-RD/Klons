using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsA.DataSets;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsA.Forms
{
    public partial class Form_PaymentsByPerson : MyFormBaseA
    {
        public Form_PaymentsByPerson()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public List<PersonPayRow> PersonPayRows = new List<PersonPayRow>();

        private void Form_PaymentsByPerson_Load(object sender, EventArgs e)
        {
            cbPerson.Text = null;
        }

        public void DoFilter()
        {
            PersonPayRows = new List<PersonPayRow>();
            DateTime dt1 = DataLoader.LoadedDT1;
            DateTime dt2 = DataLoader.LoadedDT2;
            if (!string.IsNullOrEmpty(tbDate1.Text))
                dt1 = Utils.StringToDate(tbDate1.Text).Value;
            if (!string.IsNullOrEmpty(tbDate2.Text))
                dt2 = Utils.StringToDate(tbDate2.Text).Value;
            int idp = -1;
            if (cbPerson.SelectedIndex > -1 && cbPerson.SelectedValue != null)
                idp = (int)cbPerson.SelectedValue;
            if (dt1 < DataLoader.LoadedDT1) dt1 = DataLoader.LoadedDT1;
            if (dt2 > DataLoader.LoadedDT2) dt2 = DataLoader.LoadedDT2;

            string sdt1 = Utils.DateToString(dt1);
            string sdt2 = Utils.DateToString(dt2);

            if (sdt1 != tbDate1.Text) tbDate1.Text = sdt1;
            if (sdt2 != tbDate2.Text) tbDate2.Text = sdt2;

            /*
            if (idp == -1)
            {
                bsRows.DataSource = PersonPayRows;
                return;
            }
            */

            var table_payrows = MyData.DataSetKlons.PAYLISTS_R;
            var drs_pay = table_payrows
                .WhereX(d =>
                    (idp == -1 || d.IDP == idp) &&
                    d.PAYLISTSRow.DT >= dt1 &&
                    d.PAYLISTSRow.DT <= dt2)
                .OrderBy(d => d.PAYLISTSRow.DT)
                .ToList();

            foreach(var dr_pay in drs_pay)
            {
                var pprow = new PersonPayRow()
                {
                    PersonPayRowType = EPersonPayRowType.Pay,
                    Date = dr_pay.PAYLISTSRow.DT,
                    ListDescription = dr_pay.PAYLISTSRow.DESCR,
                    PositionTitle = dr_pay.POSITIONSRow.TITLE,
                    NotPaid = dr_pay.PAY0,
                    NotPaidAdvance = dr_pay.ADVANCE0,
                    NotPaidWithhold = dr_pay.WITHHOLDINGS0,
                    NotPaidT = dr_pay.TPAY0,
                    PayT = dr_pay.TPAY,
                    Diff = dr_pay.TPAY0 - dr_pay.TPAY,
                    CalcIIN = dr_pay.IIN0,
                    TakeIIN = dr_pay.IIN,
                };
                PersonPayRows.Add(pprow);
            }
            if (idp == -1)
            {
                bsRows.DataSource = PersonPayRows;
                return;
            }

            var table_salary_r = MyData.DataSetKlons.SALARY_SHEETS_R;
            var drs_salary_r = table_salary_r
                .WhereX(d =>
                    d.IDP == idp &&
                    d.XType != ESalarySheetRowType.Total &&
                    d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.DT2.IsBetween(dt1, dt2))
                .OrderBy(d => d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.DT2)
                .ToList();

            foreach (var dr_salary_r in drs_salary_r)
            {
                var pprow = new PersonPayRow()
                {
                    PersonPayRowType = EPersonPayRowType.Calc,
                    Date = dr_salary_r.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.DT2,
                    ListDescription = dr_salary_r.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.DESCR,
                    PositionTitle = dr_salary_r.POSITIONSRow.TITLE,
                    Calc = dr_salary_r.PAY,
                    CalcAdvance = dr_salary_r.ADVANCE,
                    CalcWithhold = dr_salary_r.MINUS_AFTER_IIN,
                    CalcT = dr_salary_r.PAYT,
                    CalcIIN = dr_salary_r.IIN_AMOUNT
                };
                PersonPayRows.Add(pprow);
            }

            PersonPayRows = PersonPayRows
                .OrderBy(d => d.Date)
                .ThenBy(d => d.PersonPayRowType)
                .ToList();

            bsRows.DataSource = PersonPayRows;
        }

        private void CmFilter_Click(object sender, EventArgs e)
        {
            DoFilter();
        }
    }

    public enum EPersonPayRowType
    {
        Calc = 0,
        Pay = 1
    }

    public class PersonPayRow
    {
        public EPersonPayRowType PersonPayRowType { get; set; }
        public DateTime Date { get; set; }
        public string ListDescription { get; set; } = null;
        public string PositionTitle { get; set; } = null;
        public decimal Calc { get; set; } = 0.0M;
        public decimal CalcAdvance { get; set; } = 0.0M;
        public decimal CalcWithhold { get; set; } = 0.0M;
        public decimal CalcT { get; set; } = 0.0M;
        public decimal NotPaid { get; set; } = 0.0M;
        public decimal NotPaidAdvance { get; set; } = 0.0M;
        public decimal NotPaidWithhold { get; set; } = 0.0M;
        public decimal NotPaidT { get; set; } = 0.0M;
        public decimal PayT { get; set; } = 0.0M;
        public decimal Diff { get; set; } = 0.0M;
        public decimal CalcIIN { get; set; } = 0.0M;
        public decimal TakeIIN { get; set; } = 0.0M;
    }
}
