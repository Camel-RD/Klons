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

        public enum EGroupBy
        {
            None,
            YearAndMonth,
            Person,
            PersonAndPosition,
            Department
        }

        public static List<SalaryRepRow2> MakeAggregatedReport(DateTime dt1, DateTime dt2,
            int? idp, int? idam, string iddep, EGroupBy groupby)
        {
            var ret = new List<SalaryRepRow2>();

            int retyrmt = 0;
            int retidp = 0;
            int retidam = 0;
            int retiddep = 0;

            switch (groupby)
            {
                case EGroupBy.YearAndMonth:
                    retyrmt = 1;
                    break;
                case EGroupBy.Person:
                    retidp = 1;
                    break;
                case EGroupBy.PersonAndPosition:
                    retidp = 1;
                    retidam = 1;
                    break;
                case EGroupBy.Department:
                    retiddep = 1;
                    break;
            }

            KlonsARepDataSet.SP_REP_AGGREGATEDataTable table = null;
            var ad = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.SP_REP_AGGREGATETableAdapter();
            if (retiddep == 1 || iddep != null)
                table = ad.GetDataBy_SP_REP_AGGREGATE_02(dt1, dt2, iddep, retyrmt, retidp, retidam, retiddep);
            else
                table = ad.GetDataBy_SP_REP_AGGREGATE_01(dt1, dt2, idp, idam, retyrmt, retidp, retidam);

            var drs = table.Rows;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var dr = table[i];
                var reprow = new SalaryRepRow2();
                reprow.SetFrom(dr);
                reprow.SNR = i + 1;

                switch (groupby)
                {
                    case EGroupBy.YearAndMonth:
                        reprow.Caption = $"{dr.YR} - {dr.MT:00}";
                        break;
                    case EGroupBy.Person:
                        var dr_person = MyData.DataSetKlons.PERSONS.FindByID(dr.IDP);
                        reprow.Caption = dr_person.YNAME;
                        break;
                    case EGroupBy.PersonAndPosition:
                        dr_person = MyData.DataSetKlons.PERSONS.FindByID(dr.IDP);
                        var dr_position = MyData.DataSetKlons.POSITIONS.FindByID(dr.IDAM);
                        reprow.Caption = $"{dr_person.YNAME}, {dr_position.TITLE}";
                        break;
                    case EGroupBy.Department:
                        var dr_dep = MyData.DataSetKlons.DEPARTMENTS.FindByID(dr.IDDEP);
                        reprow.Caption = dr_dep.DESCR;
                        break;
                }

                ret.Add(reprow);
            }

            ret = ret.OrderBy(d => d.Caption).ToList();
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
        public decimal Ex2 => ExExpenses + ExNatMovement + ExRetaliation + ExInvalidity;
        public decimal IIN { get; set; } = 0.0M;
        public decimal MinusBeforeIIN { get; set; } = 0.0M;
        public decimal MinusAfterIIN { get; set; } = 0.0M;
        public decimal AdvanceOrDebt { get; set; } = 0.0M;
        public decimal Pay { get; set; } = 0.0M;
        public decimal PayT { get; set; } = 0.0M;

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

        public void SetFrom(KlonsARepDataSet.SP_REP_AGGREGATERow dr)
        {
            WorkDays = dr.WORKDAYS;
            WorkHours = dr.WORKHOURS;
            WorkPay = dr.WORKPAY;
            SickPay = dr.SICKPAY;
            VacationPay = dr.VACATIONPAY;
            PlusTaxed = dr.PLUS_TAXED;
            PlusNotTaxed = dr.PLUS_NOTTAXED;
            PlusNoSAI = dr.PLUS_NOSAI;
            PlusAuthorsFees = dr.PLUS_AUTHORS_FEES;
            TotalPay = dr.TOTALPAY;
            ForSAI = dr.FORSAI;
            DDSAI = dr.DDSN_AMOUNT;
            DNSAI = dr.DNSN_AMOUNT;
            SAI = DDSAI + DNSAI;
            UntaxedMinimum = dr.UNTAXED_MINIMUM;
            ExDependants = dr.IIN_EXEMPT_DEPENDANTS;
            ExInvalidity = dr.IIN_EXEMPT_INVALIDITY;
            ExRetaliation = dr.IIN_EXEMPT_RETALIATION;
            ExNatMovement = dr.IIN_EXEMPT_NATIONAL_MOVEMENT;
            ExExpenses = dr.IIN_EXEMPT_EXPENSES;
            IIN = dr.IIN_AMOUNT;
            MinusBeforeIIN = dr.MINUS_BEFORE_IIN;
            MinusAfterIIN = dr.MINUS_AFTER_IIN;
            Pay = dr.PAY;
            AdvanceOrDebt = dr.ADVANCE;
            PayT = dr.PAYT;
        }

    }


}
