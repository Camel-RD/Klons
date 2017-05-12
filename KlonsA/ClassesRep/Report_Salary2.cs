using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsA.Forms;
using KlonsLIB.Misc;
using KlonsLIB.Data;
using KlonsLIB.Forms;

namespace KlonsA.Classes
{
    public class Report_Salary2
    {
        public static KlonsData MyData => KlonsData.St;

        public enum ERepType
        {
            WithPosNoSign,
            NoPosWithSign
        }

        public static void MakeReport(KlonsADataSet.SALARY_SHEETSRow dr_algas_lapa, ERepType tp)
        {
            var sh = new SalarySheetInfo(dr_algas_lapa);
            var er = sh.SetUpLightFromSarRow(dr_algas_lapa);
            if (er != "OK")
            {
                MyData.MyMainForm.ShowWarning(er);
                return;
            }
            var rep = Report_Salary2.MakeReport2(sh);
            if (rep.Count == 0) return;

            var period = MakePeriodString(sh.DT1, sh.DT2);

            ReportViewerData rd = new ReportViewerData();
            if(tp == ERepType.WithPosNoSign)
                rd.FileName = "ReportA_AlgasLapa_1";
            else
                rd.FileName = "ReportA_AlgasLapa_2";
            rd.Sources["dsSalaryReport"] = rep;
            rd.AddReportParameters(new string[]
                {
                    "CompanyName", MyData.Params.CompNameX,
                    "RNr", dr_algas_lapa.SNR.ToString(),
                    "RPerson", "",
                    "RPeriod", period,
                    "RRemark", "",
                });
            MyData.MyMainForm.ShowReport(rd);
        }

        private static string MakePeriodString(DateTime dt1, DateTime dt2)
        {
            if (dt1.Day == 1 && dt1.LastDayOfMonth() == dt2)
                return string.Format("{0}. gada {1}", dt1.Year, Utils.MonthNamesAcc[dt1.Month - 1]);
            else
                return string.Format("{0:dd.MM.yyyy} - {1:dd.MM.yyyy}", dt1, dt2);
        }

        public static List<SalaryRepRow2> MakeReport2(SalarySheetInfo sh)
        {
            var ret = new List<SalaryRepRow2>();
            var drs = sh.DR_algas_lapa.KIND == 1 ?
                sh.DR_algas_lapa.GetSALARY_SHEETS_RRowsByFK_SALARY_SHEETS_R_IDST().OrderBy(d => d.SNR) :
                sh.DR_algas_lapa.GetSALARY_SHEETS_RRowsByFK_SALARY_SHEETS_R_IDS().OrderBy(d => d.SNR);
            var drsa = drs.ToArray();
            for (int i = 0; i < drsa.Length; i++)
            {
                var dr = drsa[i];
                var si = new SalaryInfo();
                si.SetFromRow(dr);
                var reprow = new SalaryRepRow2();
                reprow.SetFrom(si);
                reprow.SNR = i + 1;
                ret.Add(reprow);
            }
            return ret;
        }
    }

    public class SalaryRepRow2
    {
        public int SNR { get; set; } = 0;
        public string Caption { get; set; } = "";
        public string Caption2 { get; set; } = "";
        public int WorkDays { get; set; } = 0;
        public float WorkHours { get; set; } = 0.0f;
        public decimal WorkPay { get; set; } = 0.0M;
        public decimal SickPay { get; set; } = 0.0M;
        public decimal VacationPay { get; set; } = 0.0M;
        public decimal PlusTaxed { get; set; } = 0.0M;
        public decimal PlusNotTaxed { get; set; } = 0.0M;
        public decimal PlusAuthorsFees { get; set; } = 0.0M;
        public decimal PlusNoSAI { get; set; } = 0.0M;
        public decimal TotalPay { get; set; } = 0.0M;
        public decimal ForSAI { get; set; } = 0.0M;
        public decimal DNSAI { get; set; } = 0.0M;
        public decimal DDSAI { get; set; } = 0.0M;
        public decimal SAI { get; set; } = 0.0M;
        public decimal UntaxedMinimum { get; set; } = 0.0M;
        public decimal ExDependants { get; set; } = 0.0M;
        public decimal ExInvalidity { get; set; } = 0.0M;
        public decimal ExRetaliation { get; set; } = 0.0M;
        public decimal ExNatMovement { get; set; } = 0.0M;
        public decimal ExExpenses { get; set; } = 0.0M;
        public decimal IIN { get; set; } = 0.0M;
        public decimal MinusBeforeIIN { get; set; } = 0.0M;
        public decimal MinusAfterIIN { get; set; } = 0.0M;
        public decimal AdvanceOrDebt { get; set; } = 0.0M;
        public decimal Pay { get; set; } = 0.0M;

        public void SetFrom(SalaryInfo si)
        {
            SNR = si._SNR;
            Caption = string.Format("{0} {1}, {2}", si._FNAME, si._LNAME, si._POSITION_TITLE.ToLower());
            Caption2 = string.Format("{0} {1}", si._FNAME, si._LNAME);
            WorkDays = si._FACT_DAYS;
            WorkHours = si._FACT_HOURS;
            WorkPay = si._SALARY;
            SickPay = si._SICKDAYS_PAY;
            VacationPay = si._VACATION_PAY_CURRENT;
            PlusTaxed = si._PLUS_TAXED + si._PLUS_PF_TAXED + si._PLUS_LI_TAXED + si._PLUS_HI_TAXED;
            PlusNotTaxed = si._PLUS_NOTTAXED + si._PLUS_PF_NOTTAXED + si._PLUS_LI_NOTTAXED + si._PLUS_HI_NOTTAXED;
            PlusNoSAI = si._PLUS_NOSAI;
            PlusAuthorsFees = si._PLUS_AUTHORS_FEES;
            TotalPay = si._TOTAL_BEFORE_TAXES;
            ForSAI = si._AMOUNT_BEFORE_SN;
            DDSAI = si._DDSN_AMOUNT;
            DNSAI = si._DNSN_AMOUNT;
            SAI = si._SN_AMOUNT;
            UntaxedMinimum = si._IIN_EXEMPT_UNTAXED_MINIMUM;
            ExDependants = si._IIN_EXEMPT_DEPENDANTS;
            ExInvalidity = si._IIN_EXEMPT_INVALIDITY;
            ExRetaliation = si._IIN_EXEMPT_RETALIATION;
            ExNatMovement = si._IIN_EXEMPT_NATIONAL_MOVEMENT;
            ExExpenses = si._IIN_EXEMPT_EXPENSES;
            IIN = si._IIN_AMOUNT;
            MinusBeforeIIN = si._MINUS_BEFORE_IIN;
            MinusAfterIIN = si._MINUS_AFTER_IIN;
            AdvanceOrDebt = si._ADVANCE;
            Pay = si._PAYT;
        }

    }


}
