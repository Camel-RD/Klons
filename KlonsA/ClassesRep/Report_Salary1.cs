using System;
using System.IO;
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
    public class Report_SalaryCalc1
    {
        public static KlonsData MyData => KlonsData.St;

        public string[] Titles = new string[5];
        public List<SalaryCalcRow> Rows = new List<SalaryCalcRow>();

        public bool DoFullList = false;
        public int ValueNr = 0;
        public int Cursor = 0;
        
        public static void MakeReport1(KlonsADataSet.SALARY_SHEETS_RRow dr_lapas_r)
        {
            var rd = MakeReportData(dr_lapas_r);
            if (rd == null) return;
            MyData.MyMainForm.ShowReport(rd);
        }

        public static bool SaveReportToPdf(KlonsADataSet.SALARY_SHEETS_RRow dr_lapas_r, string filename)
        {
            var rd = MakeReportData(dr_lapas_r);
            if (rd == null) return false;
            return ReportHelper.RenderToPdf(rd, filename);
        }

        public static ReportViewerData MakeReportData(KlonsADataSet.SALARY_SHEETS_RRow dr_lapas_r)
        {
            var sr = new SalarySheetRowInfo();
            var err = sr.SetUpFromRowX(dr_lapas_r);
            if (err.HasErrors)
            {
                Form_ErrorList.ShowErrorList(MyData.MyMainForm, err);
                return null;
            }
            sr.CheckLinkedRows(dr_lapas_r.IDP);

            var sc = new SalaryCalcTInfo(sr.SalarySheetRowSet, new SalaryInfo(), true);
            err = sc.FillRow();
            if (err.HasErrors)
            {
                Form_ErrorList.ShowErrorList(MyData.MyMainForm, err);
                return null;
            }

            var person = string.Format("{0} {1}, {2}", sr.DR_Person_r.FNAME,
                sr.DR_Person_r.LNAME, sr.GetPositionTitle().Nz().ToLower());
            var period = string.Format("{0:dd.MM.yyyy} - {1:dd.MM.yyyy}",
                sr.SalarySheet.DT1, sr.SalarySheet.DT2);

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportA_AprIzklasts_1";
            if (sr.IsSingleRow())
            {
                var sc0 = sc.LinkedSCI[0];
                sc0.CheckBeforeReport();

                sc0.AvPayCalc.SetCurMonthPay(sr.SalarySheet.YR, sr.SalarySheet.MT, sc.TotalSI._TOTAL_BEFORE_TAXES, sc.TotalSI._PAY);

                rd.Sources["dsSickPay"] = sc0.SickDayCalc?.Rows;
                rd.Sources["dsAvPay"] = sc0.AvPayCalc.ReportRows;
                rd.Sources["dsWorkPay"] = sc0.WorkPayCalc.GetRows2();
                rd.Sources["dsVacationPay"] = sc0.VacationCalc.Rows;
                rd.Sources["dsCalcR"] = sc0.CalcR.ReportRows;
                rd.Sources["dsBonus"] = sc0.BonusCalc.ReportRows;
                rd.Sources["dsSalary"] = sc0.MakeReport1();
                rd.AddReportParameters(new string[]
                    {
                    "CompanyName", MyData.Params.CompNameX,
                    "RPerson", person,
                    "RPeriod", period,
                    "RSickPay", sc0.SickDayCalc.TotalRow.SickDayPay.ToString("N2"),
                    "RSickPay75", sc0.SickDayCalc.TotalRow.SickDayPay75.ToString("N2"),
                    "RSickPay80", sc0.SickDayCalc.TotalRow.SickDayPay80.ToString("N2"),
                    "RAvPayHour", sc0.AvPayCalc.RateHour.ToString("N4"),
                    "RAvPayDay", sc0.AvPayCalc.RateDay.ToString("N4"),
                    "RAvPayCalDay", sc0.AvPayCalc.RateCalendarDay.ToString("N4"),
                    "RAvPayRemark", sc0.AvPayCalc.UsingMinRate?"Izmantotas minimālās likmes.": "",
                    "RPosTitle0", sc0.SR.GetPositionTitle(),
                    "RPosTitle1", null,
                    "RPosTitle2", null,
                    "RPosTitle3", null,
                    "RPosTitle4", null,
                    "RIsAvPayUsed", sc0.SI.IsAvPayUsed().ToString()
                    });
            }
            else
            {
                var rep = sc.MakeReport1();
                sc.CheckBeforeReport();

                sc.AvPayCalc.SetCurMonthPay(sr.SalarySheet.YR, sr.SalarySheet.MT, sc.TotalSI._TOTAL_BEFORE_TAXES, sc.TotalSI._PAY);

                rd.Sources["dsSickPay"] = sc.SickDayCalc.Rows;
                rd.Sources["dsAvPay"] = sc.AvPayCalc.ReportRows;
                rd.Sources["dsWorkPay"] = sc.WorkPayCalc.GetRows2();
                rd.Sources["dsVacationPay"] = sc.VacationCalc.Rows;
                rd.Sources["dsCalcR"] = sc.CalcR.ReportRows;
                rd.Sources["dsBonus"] = sc.BonusCalc.ReportRows;
                rd.Sources["dsSalary"] = rep.GetGoodRows();
                rd.AddReportParameters(new string[]
                    {
                    "CompanyName", MyData.Params.CompNameX,
                    "RPerson", person,
                    "RPeriod", period,
                    "RSickPay", sc.SickDayCalc.TotalRow.SickDayPay.ToString("N2"),
                    "RSickPay75", sc.SickDayCalc.TotalRow.SickDayPay75.ToString("N2"),
                    "RSickPay80", sc.SickDayCalc.TotalRow.SickDayPay80.ToString("N2"),
                    "RAvPayHour", sc.AvPayCalc.RateHour.ToString("N4"),
                    "RAvPayDay", sc.AvPayCalc.RateDay.ToString("N4"),
                    "RAvPayCalDay", sc.AvPayCalc.RateCalendarDay.ToString("N4"),
                    "RAvPayRemark", sc.AvPayCalc.UsingMinRate?"Izmantotas minimālās likmes.": "",
                    "RPosTitle0", rep.Titles[0],
                    "RPosTitle1", rep.Titles[1],
                    "RPosTitle2", rep.Titles[2],
                    "RPosTitle3", rep.Titles[3],
                    "RPosTitle4", rep.Titles[4],
                    "RIsAvPayUsed", sc.TotalSI.IsAvPayUsed().ToString()
                    });
            }
            return rd;
        }

        public SalaryCalcRow addr(string pc, decimal pv)
        {
            SalaryCalcRow ns = null;
            if (ValueNr > 0)
            {
                ns = Rows[Cursor];
                ns[ValueNr] = pv;
            }
            else
            {
                ns = new SalaryCalcRow() { Caption = pc, Value = pv };
                Rows.Add(ns);
            }
            Cursor++;
            return ns;
        }

        public SalaryCalcRow addrt(string pc, decimal pv)
        {
            SalaryCalcRow ns = null;
            if (ValueNr > 0)
            {
                ns = Rows[Cursor];
                ns[ValueNr] = pv;
            }
            else
            {
                ns = new SalaryCalcRow() { Caption = pc, Value = pv, IsTotals = true };
                Rows.Add(ns);
            }
            Cursor++;
            return ns;
        }

        public SalaryCalcRow addc(string pc)
        {
            SalaryCalcRow ns = null;
            if (ValueNr > 0)
            {
                ns = Rows[Cursor];
            }
            else
            {
                ns = new SalaryCalcRow() { Caption = pc, IsTitle = true };
                Rows.Add(ns);
            }
            Cursor++;
            return ns;
        }

        public SalaryCalcRow addrx(string pc, int pv)
        {
            if (DoFullList || pv != 0) return addr(pc, pv);
            else return null;
        }

        public SalaryCalcRow addrx(string pc, decimal pv)
        {
            if (DoFullList || pv != 0.0M) return addr(pc, pv);
            else return null;
        }

        public SalaryCalcRow addrx(string pc, float pv)
        {
            if (DoFullList || pv != 0.0f) return addr(pc, (decimal)pv);
            else return null;
        }

        public SalaryCalcRow addrxt(string pc, decimal pv)
        {
            if (DoFullList || pv != 0.0M) return addrt(pc, pv);
            else return null;
        }

        public List<SalaryCalcRow> GetGoodRows()
        {
            return new List<SalaryCalcRow>(Rows.Where(r => r.HasData || r.IsTitle));
        }

        public void MakeReport1(SalaryInfo SI)
        {
            decimal d1;
            addrt("Kalendāra dienas", SI._CALENDAR_DAYS_USE);
            addrt("Plānotas darba dienas", SI._PLAN_DAYS);
            addrt("Plānotas darba stundas", (decimal)SI._PLAN_HOURS);
            addrt("Nostrādātas dienas", SI._FACT_DAYS);
            addrx(" - darba dienas", SI._FACT_WORK_DAYS);
            addrx(" - svētku dienas", SI._FACT_HOLIDAYS_DAYS);
            addrx(" - darba dienas ar VI", SI._FACT_AVPAY_WORK_DAYS);
            addrx(" - - svētku dienas", SI._FACT_AVPAY_WORKINHOLIDAYS);
            addrx(" - brīvās dienas ar VI", SI._FACT_AVPAY_FREE_DAYS);
            addrt("Nostrādātas stundas", (decimal)SI._FACT_HOURS);
            addrx(" - stunda", (decimal)SI._FACT_WORK_HOURS);
            addrx(" - virsstundas", (decimal)SI._FACT_HOURS_OVERTIME);
            addrx(" - nakts darbs", (decimal)SI._FACT_HOURS_NIGHT);
            addrx(" - svētku dienas", (decimal)SI._FACT_HOLIDAYS_HOURS);
            addrx(" - - virsstundas", (decimal)SI._FACT_HOLIDAYS_HOURS_OVERTIME);
            addrx(" - - nakts darbs", (decimal)SI._FACT_HOLIDAYS_HOURS_NIGHT);
            addrx(" - stundas ar VI", (decimal)SI._FACT_AVPAY_HOURS);
            addrx(" - - virsstundas", (decimal)SI._FACT_AVPAY_HOURS_OVERTIME);
            addrx(" - - svētku dienas", (decimal)SI._FACT_AVPAY_HOLIDAYS_HOURS);
            addrx(" - - - virsstundas", (decimal)SI._FACT_AVPAY_HOLIDAYS_HOURS_OVERT);
            addrt("Darba samaksa", SI._SALARY);
            addrx("Darba samaksa ar pamatlikmi", SI._SALARY_DAY);
            addrx("Gabaldarba samaksa", SI._SALARY_PIECEWORK);
            d1 = SI._SALARY_NIGHT +
                SI._SALARY_OVERTIME +
                SI._SALARY_HOLIDAYS_DAY +
                SI._SALARY_HOLIDAYS_NIGHT +
                SI._SALARY_HOLIDAYS_OVERTIME;
            addrxt(" - piemaksas", d1);
            addrx(" - - par virstundām", SI._SALARY_OVERTIME);
            addrx(" - - par nakts darbu", SI._SALARY_NIGHT);
            addrx(" - - par darbu svētku dienās", SI._SALARY_HOLIDAYS_DAY);
            addrx(" - - - par virstundām", SI._SALARY_HOLIDAYS_OVERTIME);
            addrx(" - - - nakts darbu", SI._SALARY_HOLIDAYS_NIGHT);
            addrx(" - par darbu ar VI", SI._SALARY_AVPAY_WORK_DAYS);
            addrx(" - - par virstundām", SI._SALARY_AVPAY_WORK_DAYS_OVERTIME);
            addrx(" - - par darbu svētku dienās", SI._SALARY_AVPAY_HOLIDAYS);
            addrx(" - - - par virstundām", SI._SALARY_AVPAY_HOLIDAYS_OVERTIME);
            addrx(" - par brīvajām dienām ar VI", SI._SALARY_AVPAY_FREE_DAYS);
            addrxt("Atvaļinājuma nauda", SI._VACATION_PAY_CURRENT + SI._VACATION_PAY_NEXT);
            addrx(" - dienas šajā periodā", SI._VACATION_DAYS_CURRENT);
            addrx(" - dienas avansā", SI._VACATION_DAYS_NEXT);
            addrx(" - aprēķins šajā periodā", SI._VACATION_PAY_CURRENT);
            addrx(" - aprēķins avansā", SI._VACATION_PAY_NEXT);
            addrxt("Slimības nauda", SI._SICKDAYS_PAY);
            addrx("Slimības dienas", SI._SICKDAYS);
            addrx("Piemaksas", SI._PLUS_TAXED);
            addrx("Piemaksas: neapliek ar nod.", SI._PLUS_NOTTAXED);
            addrx("Piemaksas: neapliek ar SI", SI._PLUS_NOSAI);
            addrx("Piemaksas: autoratlīdzība", SI._PLUS_AUTHORS_FEES);
            addrx("Piemaksas: pensijas fondos nepliekamā daļa", SI._PLUS_PF_NOTTAXED);
            addrx("Piemaksas: pensijas fondos pliekamā daļa", SI._PLUS_PF_TAXED);
            addrx("Piemaksas: dzīvības apdroš. nepliekamā daļa", SI._PLUS_LI_NOTTAXED);
            addrx("Piemaksas: dzīvības apdroš. pliekamā daļa", SI._PLUS_LI_TAXED);
            addrx("Piemaksas: veselības apdroš. nepliekamā daļa", SI._PLUS_HI_NOTTAXED);
            addrx("Piemaksas: veselības apdroš. pliekamā daļa", SI._PLUS_HI_TAXED);

            addrxt("Ieņēmumi kopā pirms nodokļiem", SI._TOTAL_BEFORE_TAXES);
            addrxt("Ieņēmumi pirm SI", SI._AMOUNT_BEFORE_SN);

            addrxt("SI summa kopā", SI._SN_AMOUNT);
            addrx("Darba ņēmēja SI likme", SI._RATE_DNSN);
            addrx("Darba devēja SI likme", SI._RATE_DDSN);
            addrx("Darba ņēmēja SI summa", SI._DNSN_AMOUNT);
            addrx("Darba ņēmēja SI summa", SI._DDSN_AMOUNT);

            addrxt("IIN atvieglojumi", SI.SumIINExemptsAll());
            addrx(" - neapliekamais minimums", SI._IIN_EXEMPT_UNTAXED_MINIMUM);
            addrx(" - par apgādājamajiem", SI._IIN_EXEMPT_DEPENDANTS);
            addrx(" - par invaliditāti", SI._IIN_EXEMPT_INVALIDITY);
            addrx(" - rehabilitētajām personām", SI._IIN_EXEMPT_RETALIATION);
            addrx(" - nacionālās pretošanās dalībniekiem", SI._IIN_EXEMPT_NATIONAL_MOVEMENT);
            addrx(" - atskaitāmās izmaksas", SI._IIN_EXEMPT_EXPENSES);

            addrxt("Ar IIN apliekamā summa", SI._AMOUNT_BEFORE_IIN);
            addrx("IIN likme", SI._RATE_IIN);
            addrx("IIN likme 2", SI._RATE_IIN2);
            addrxt("IIN summa", SI._IIN_AMOUNT);

            addrx("Atvilkumi pirms IIN", SI._MINUS_BEFORE_IIN);
            addrx("Atvilkumi pēc IIN", SI._MINUS_AFTER_IIN);

            addrxt("Izmaksai", SI._PAY);
            addrxt("Avansā, iesk. atvaļinājuma naudu", SI._ADVANCE);
            addrxt("Kopā izmaksai", SI._PAYT);
        }
    }

    public class SalaryCalcRow
    {
        public bool IsTitle { get; set; } = false;
        public bool IsTotals { get; set; } = false;
        public string Caption { get; set; } = "";
        public decimal Value { get; set; } = 0.0M;
        public decimal Value1 { get; set; } = 0.0M;
        public decimal Value2 { get; set; } = 0.0M;
        public decimal Value3 { get; set; } = 0.0M;
        public decimal Value4 { get; set; } = 0.0M;

        public bool HasData => Value != 0.0M || Value1 != 0.0M ||
            Value2 != 0.0M || Value3 != 0.0M;

        public decimal this[int n]
        {
            get
            {
                switch (n)
                {
                    case 0: return Value;
                    case 1: return Value1;
                    case 2: return Value2;
                    case 3: return Value3;
                    case 4: return Value4;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                switch (n)
                {
                    case 0: Value = value; break;
                    case 1: Value1 = value; break;
                    case 2: Value2 = value; break;
                    case 3: Value3 = value; break;
                    case 4: Value4 = value; break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

}
