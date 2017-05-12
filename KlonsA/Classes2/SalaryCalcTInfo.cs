using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsLIB.Misc;
using KlonsLIB.Data;

namespace KlonsA.Classes
{
    public class SalaryCalcTInfo
    {
        public bool PreparingReport = false;
        public SalarySheetRowSetInfo SRS = null;
        public SalaryInfo TotalSI = null;
        public SalaryCalcInfo[] LinkedSCI = null;

        public AvPayCalcInfo AvPayCalc = null;
        public SickDayCalcInfo SickDayCalc = null;
        public VacationCalcInfo VacationCalc = null;
        public WorkPayCalcTInfo WorkPayCalc = null;
        public BonusCalcInfo BonusCalc = null;
        public CalcRInfo CalcR = null;

        public bool IsAvPayCalcDone = false;
        public decimal AvPayRateHour = 0.0M;
        public decimal AvPayRateDay = 0.0M;
        public decimal AvPayRateCalendarDay = 0.0M;

        public SalaryCalcTInfo(SalarySheetRowSetInfo srs, SalaryInfo si, bool filllist)
        {
            if (srs?.TotalRow == null || srs.LinkedRows == null || srs.LinkedRows.Length == 0)
                throw new Exception("Bad init.");
            PreparingReport = filllist;
            SRS = srs;
            TotalSI = si;
            if (PreparingReport)
            {

            }
        }

        public ErrorList FillRow()
        {
            IsAvPayCalcDone = false;

            var dt1 = SRS.SalarySheet.DT1;
            var dt2 = SRS.SalarySheet.DT2;

            var err_list = new ErrorList();

            // -- should be done in initialization
            //CheckLinkedRows(DrTotalRow.IDP);

            SRS.CheckAlgasPS();

            LinkedSCI = new SalaryCalcInfo[SRS.LinkedRows.Length];
            for (int i = 0; i < SRS.LinkedRows.Length; i++)
            {
                LinkedSCI[i] = new SalaryCalcInfo(SRS.LinkedRows[i], new SalaryInfo(), PreparingReport);
                SRS.LinkedRows[i].TotalPositionPay = LinkedSCI[i].SI;
            }

            if (SRS.IsSingleRow())
            {
                var sci = LinkedSCI[0];
                TotalSI = sci.SI;
                SRS.TotalPersonPay = TotalSI;
                var err = sci.FillRow();
                err_list.AddRange(err);
                SRS.TotalPersonPay = sci.SI;
                return err_list;
            }

            BonusCalcInfo bonus, bonus_am;

            TotalSI = new SalaryInfo();
            SRS.TotalPersonPay = TotalSI;
            SRS.TotalRow.TotalPositionPay = TotalSI;

            MakeWorkTime(); // updates all rows and TotalPersonPay
            CalcRf(dt1, dt2);

            bonus = new BonusCalcInfo(SRS.GetAlgasAllPSRows(), PreparingReport);

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var lr = SRS.LinkedRows[i];
                var lsc = LinkedSCI[i];

                bonus_am = bonus.Filter(
                    d =>
                    d.IsIDANull() ||
                    (!d.IsIDANull() &&
                    d.IDA == lr.Row.IDAM));

                lsc.BonusCalc = bonus_am;

                lsc.SR.CheckAlgasPS();
                lsc.CalcRR(dt1, dt2);
                lsc.FillRow1();
            }

            Summ2();
            FillRowVcSdc();

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var lsc = LinkedSCI[i];
                lsc.FillRowA();
            }

            FillRowA();

            decimal plusfromendbruto, plusfromendcash;

            CheckPlusFromEnd(out plusfromendbruto, out plusfromendcash);

            decimal tb = TotalSI._AMOUNT_BEFORE_IIN + plusfromendbruto;
            decimal r = 1.0M / (decimal)LinkedSCI.Length;

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var lsc = LinkedSCI[i];
                decimal lb = plusfromendcash == 0.0M ? 0.0M : 
                    lsc.BonusCalc.PlusFromEnd / plusfromendcash * plusfromendbruto;
                if (tb > 0.0M)
                    r = (lsc.SI._AMOUNT_BEFORE_IIN + lb) / tb;

                lsc.CalcR.ApplyRatio(r, lsc.SI);
                //FillLinkedRow(lsc.SI);
            }

            EnsureExactSum0();
            EnsureExactSum();

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var lsc = LinkedSCI[i];
                lsc.CalcR.SaveStateForDivided(lsc.CalcR.ExDivided);
                lsc.FillRowB();
            }

            FillRowB();
            FillRowC();

            return err_list;
        }

        public void EnsureExactSum()
        {
            decimal d1 = 0.0M, d2 = 0.0M, d3 = 0.0M, d4 = 0.0M, d5 = 0.0M;
            //decimal d6 = 0.0M, d7 = 0.0M, d8 = 0.0M, d9 = 0.0M, d10 = 0.0M, d11 = 0.0M;
            SalaryInfo si, sx = null;

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                si = LinkedSCI[i].SI;
                d1 += si._IIN_EXEMPT_UNTAXED_MINIMUM;
                d2 += si._IIN_EXEMPT_DEPENDANTS;
                d3 += si._IIN_EXEMPT_INVALIDITY;
                d4 += si._IIN_EXEMPT_NATIONAL_MOVEMENT;
                d5 += si._IIN_EXEMPT_RETALIATION;
                /*d6 += si._PLUS_PF_NOTTAXED;
                d7 += si._PLUS_PF_TAXED;
                d8 += si._PLUS_LI_NOTTAXED;
                d9 += si._PLUS_LI_TAXED;
                d10 += si._PLUS_HI_NOTTAXED;
                d11 += si._PLUS_HI_TAXED;
                */
                if (si._AMOUNT_BEFORE_SN > 0.0M)
                    sx = si;
            }
            if (sx == null) return;
            si = sx;
            si._IIN_EXEMPT_UNTAXED_MINIMUM -= d1 - TotalSI._IIN_EXEMPT_UNTAXED_MINIMUM;
            si._IIN_EXEMPT_DEPENDANTS -= d2 - TotalSI._IIN_EXEMPT_DEPENDANTS;
            si._IIN_EXEMPT_INVALIDITY -= d3 - TotalSI._IIN_EXEMPT_INVALIDITY;
            si._IIN_EXEMPT_NATIONAL_MOVEMENT -= d4 - TotalSI._IIN_EXEMPT_NATIONAL_MOVEMENT;
            si._IIN_EXEMPT_RETALIATION -= d5 - TotalSI._IIN_EXEMPT_RETALIATION;
            /*si._PLUS_PF_NOTTAXED -= d6 - TotalSI._PLUS_PF_NOTTAXED;
            si._PLUS_PF_TAXED -= d7 - TotalSI._PLUS_PF_TAXED;
            si._PLUS_LI_NOTTAXED -= d8 - TotalSI._PLUS_LI_NOTTAXED;
            si._PLUS_LI_TAXED -= d9 - TotalSI._PLUS_LI_TAXED;
            si._PLUS_HI_NOTTAXED -= d10 - TotalSI._PLUS_HI_NOTTAXED;
            si._PLUS_HI_TAXED -= d11 - TotalSI._PLUS_HI_TAXED;
            */
        }

        public void EnsureExactSum0()
        {
            decimal d1 = 0.0M, d2 = 0.0M, d3 = 0.0M, d4 = 0.0M, d5 = 0.0M;
            //decimal d6 = 0.0M, d7 = 0.0M, d8 = 0.0M, d9 = 0.0M, d10 = 0.0M, d11 = 0.0M;
            SalaryInfo si, sx = null;

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                si = LinkedSCI[i].SI;
                d1 += si._IIN_EXEMPT_UNTAXED_MINIMUM0;
                d2 += si._IIN_EXEMPT_DEPENDANTS0;
                d3 += si._IIN_EXEMPT_INVALIDITY0;
                d4 += si._IIN_EXEMPT_NATIONAL_MOVEMENT0;
                d5 += si._IIN_EXEMPT_RETALIATION0;
                if (si._AMOUNT_BEFORE_SN > 0.0M)
                    sx = si;
            }
            if (sx == null) return;
            si = sx;
            si._IIN_EXEMPT_UNTAXED_MINIMUM0 -= d1 - TotalSI._IIN_EXEMPT_UNTAXED_MINIMUM0;
            si._IIN_EXEMPT_DEPENDANTS0 -= d2 - TotalSI._IIN_EXEMPT_DEPENDANTS0;
            si._IIN_EXEMPT_INVALIDITY0 -= d3 - TotalSI._IIN_EXEMPT_INVALIDITY0;
            si._IIN_EXEMPT_NATIONAL_MOVEMENT0 -= d4 - TotalSI._IIN_EXEMPT_NATIONAL_MOVEMENT0;
            si._IIN_EXEMPT_RETALIATION0 -= d5 - TotalSI._IIN_EXEMPT_RETALIATION0;
        }

        public void Summ1()
        {
            TotalSI._PLUS_TAXED = 0.0M;
            TotalSI._PLUS_NOTTAXED = 0.0M;
            TotalSI._PLUS_NOSAI = 0.0M;
            TotalSI._PLUS_AUTHORS_FEES = 0.0M;
            TotalSI._MINUS_BEFORE_IIN = 0.0M;
            TotalSI._MINUS_AFTER_IIN = 0.0M;

            TotalSI._PLUS_PF_NOTTAXED = 0.0M;
            TotalSI._PLUS_PF_TAXED = 0.0M;
            TotalSI._PLUS_LI_NOTTAXED = 0.0M;
            TotalSI._PLUS_LI_TAXED = 0.0M;
            TotalSI._PLUS_HI_NOTTAXED = 0.0M;
            TotalSI._PLUS_HI_TAXED = 0.0M;

            TotalSI._ADVANCE = 0.0M;

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var si = LinkedSCI[i].SI;

                TotalSI._PLUS_TAXED += si._PLUS_TAXED;
                TotalSI._PLUS_NOTTAXED += si._PLUS_NOTTAXED;
                TotalSI._PLUS_NOSAI += si._PLUS_NOSAI;
                TotalSI._PLUS_AUTHORS_FEES += si._PLUS_AUTHORS_FEES;
                TotalSI._MINUS_BEFORE_IIN += si._MINUS_BEFORE_IIN;
                TotalSI._MINUS_AFTER_IIN += si._MINUS_AFTER_IIN;

                TotalSI._PLUS_PF_NOTTAXED += si._PLUS_PF_NOTTAXED;
                TotalSI._PLUS_PF_TAXED += si._PLUS_PF_TAXED;
                TotalSI._PLUS_LI_NOTTAXED += si._PLUS_LI_NOTTAXED;
                TotalSI._PLUS_LI_TAXED += si._PLUS_LI_TAXED;
                TotalSI._PLUS_HI_NOTTAXED += si._PLUS_HI_NOTTAXED;
                TotalSI._PLUS_HI_TAXED += si._PLUS_HI_TAXED;

                TotalSI._ADVANCE += si._ADVANCE;
            }
        }

        public void Summ2()
        {
            TotalSI._FORAVPAYCALC_BRUTO = 0.0M;

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var si = LinkedSCI[i].SI;
                TotalSI._FORAVPAYCALC_BRUTO += si._FORAVPAYCALC_BRUTO;
            }
        }

        public void CheckPlusFromEnd(out decimal bruto, out decimal pay)
        {
            decimal d = 0.0M;
            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var sc = LinkedSCI[i];
                d += sc.BonusCalc.PlusFromEnd;
            }

            decimal extotal = CalcR.ExMax2.SumIINExemptsAll();
            decimal exused = CalcR.ExCorrect.SumIINExemptsAll();
            decimal exusable = extotal - exused;

            decimal v = Math.Min(d, exusable);
            decimal v1 = v / (1.0M - CalcR.RateDNSN);
            decimal v2 = (d - v1) / (1.0M - CalcR.RateIIN) / (1.0M - CalcR.RateDNSN);
            v = KlonsData.RoundA(v1 + v2, 2);

            bruto = v;
            pay = d;
        }

        public ErrorList FillRowVcSdc()
        {
            var err_list = new ErrorList();

            err_list = MakeWorkTime2();
            if (err_list.HasErrors) return err_list;

            err_list = CalcSickDays();
            if (err_list.HasErrors) return err_list;

            err_list = CalcVacationDays();
            if (err_list.HasErrors) return err_list;

            return err_list;
        }

        public ErrorList FillRowA()
        {
            var err_list = new ErrorList();
            var si = TotalSI;

            Summ1();

            decimal pay1 = si._SALARY;

            decimal pay2 = pay1 +
                si._VACATION_PAY_CURRENT +
                si._SICKDAYS_PAY;

            decimal payBeforeSAI = pay2 +
                si._PLUS_TAXED;

            si._AMOUNT_BEFORE_SN = payBeforeSAI;

            si._DNSN_AMOUNT = KlonsData.RoundA(si._AMOUNT_BEFORE_SN * si._RATE_DNSN / 100.0M, 2);
            si._DDSN_AMOUNT = KlonsData.RoundA(si._AMOUNT_BEFORE_SN * si._RATE_DDSN / 100.0M, 2);
            si._SN_AMOUNT = si._DDSN_AMOUNT + si._DNSN_AMOUNT;

            decimal payAfterSAI = si._AMOUNT_BEFORE_SN - si._DNSN_AMOUNT;

            decimal payAfterSAI2 = payAfterSAI +
                 si._PLUS_NOSAI +
                 si._PLUS_AUTHORS_FEES -
                 si._MINUS_BEFORE_IIN;

            si._AMOUNT_BEFORE_IIN = payAfterSAI2;

            return err_list;
        }


        public ErrorList FillRowB()
        {
            var err_list = new ErrorList();
            var si = TotalSI;

            Summ1();

            decimal payAfterSAI = si._AMOUNT_BEFORE_SN - si._DNSN_AMOUNT;

            decimal payAfterSAI2 = payAfterSAI +
                 si._PLUS_NOSAI +
                 si._PLUS_AUTHORS_FEES -
                 si._MINUS_BEFORE_IIN;

            decimal iinexempts1 = si.SumIINExempts();

            CalcR.ExDivided.ApplyTo(si);
            CalcR.CorrectIINExempts(payAfterSAI2);
            CalcR.ExCorrect.ApplyTo(si);
            CalcR.AddToListT();
            CalcR.PrepareList();
            CalcR.PrepareReportT(this);

            decimal iinexempts2 = si.SumIINExemptsAll();
            decimal payBeforeIIN = payAfterSAI2 - iinexempts2;

            si._AMOUNT_BEFORE_IIN = payBeforeIIN;

            si._IIN_AMOUNT = KlonsData.RoundA(si._AMOUNT_BEFORE_IIN * si._RATE_IIN / 100.0M, 2);

            decimal PpayAfterIIN = payAfterSAI2 - si._IIN_AMOUNT;

            si._TOTAL_BEFORE_TAXES =
                si._AMOUNT_BEFORE_SN +
                si._PLUS_NOTTAXED +
                si._PLUS_NOSAI +
                si._PLUS_AUTHORS_FEES;

            VacationCalc.CorrectCash(si);

            si._PAY =
                si._TOTAL_BEFORE_TAXES -
                si._DNSN_AMOUNT -
                si._IIN_AMOUNT;

            si._MINUS_AFTER_IIN +=
                si._PLUS_NP_TAXED +
                si._PLUS_NP_NOTTAXED +
                si._PLUS_NP_NOSAI;

            //---Negatīva izmaksājamā summa ir OK
            si._VACATION_ADVANCE_CURRENT = -si._VACATION_ADVANCE_PREV;

            si._VACATION_ADVANCE_NEXT =
                si._VACATION_ADVANCE_PREV +
                si._VACATION_ADVANCE_CURRENT +
                si._VACATION_CASH_NEXT;

            si._ADVANCE = si._VACATION_CASH_NEXT + si._VACATION_ADVANCE_CURRENT;

            si._PAYT =
                si._PAY +
                si._ADVANCE -
                si._MINUS_AFTER_IIN;

            si._FORAVPAYCALC_PAYOUT = si._PAY;

            si._PAY0 = CalcPay0();

            if (SRS?.SalarySheet?.DR_Likmes != null)
                si._URVN_AMAOUNT = SRS.SalarySheet.DR_Likmes.URN;

            return err_list;
        }

        public decimal CalcPay0()
        {
            var SI = TotalSI;

            decimal totalpay1 =
                SI._PLUS_NP_NOTTAXED +
                SI._PLUS_NP_NOSAI +
                SI._PLUS_NP_TAXED;

            decimal sai = KlonsData.RoundA(SI._PLUS_NP_TAXED * SI._RATE_DNSN / 100.0M, 2);
            decimal beforeiinex =
                SI._PLUS_NP_NOSAI +
                SI._PLUS_NP_TAXED -
                sai;

            decimal totaliinex = SI.SumIINExemptsAll();
            decimal iinex = Math.Min(totaliinex, beforeiinex);

            decimal iin = KlonsData.RoundA((beforeiinex - iinex) * SI._RATE_IIN / 100.0M, 2);

            decimal pay0 = totalpay1 - sai - iin + SI._MINUS_AFTER_IIN;
            pay0 = Math.Min(pay0, SI._PAYT);

            return pay0;
        }


        public ErrorList FillRowC()
        {
            var err_list = new ErrorList();

            TotalSI._FORAVPAYCALC_BRUTO = 0.0M;
            TotalSI._FORAVPAYCALC_PAYOUT = 0.0M;

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var si = LinkedSCI[i].SI;
                TotalSI._FORAVPAYCALC_BRUTO += si._FORAVPAYCALC_BRUTO;
                TotalSI._FORAVPAYCALC_PAYOUT += si._FORAVPAYCALC_PAYOUT;
            }

            return err_list;
        }

        public void WriteData()
        {
            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var lsci = LinkedSCI[i];
                lsci.WriteData();
            }
            if (LinkedSCI.Length < 2) return;
            SRS.TotalPersonPay = TotalSI;
            SRS.TotalRow.TotalPositionPay = TotalSI;
            TotalSI.WriteToRow(SRS.DrTotalRow);
        }

        public void FillLinkedRow(SalaryInfo target)
        {
            decimal ratio = target._AMOUNT_BEFORE_IIN / TotalSI._AMOUNT_BEFORE_IIN;

            target._IIN_EXEMPT_UNTAXED_MINIMUM = KlonsData.RoundA(TotalSI._IIN_EXEMPT_UNTAXED_MINIMUM * ratio, 2);
            target._IIN_EXEMPT_DEPENDANTS = KlonsData.RoundA(TotalSI._IIN_EXEMPT_DEPENDANTS * ratio, 2);
            target._IIN_EXEMPT_INVALIDITY = KlonsData.RoundA(TotalSI._IIN_EXEMPT_INVALIDITY * ratio, 2);
            target._IIN_EXEMPT_NATIONAL_MOVEMENT = KlonsData.RoundA(TotalSI._IIN_EXEMPT_NATIONAL_MOVEMENT * ratio, 2);
            target._IIN_EXEMPT_RETALIATION = KlonsData.RoundA(TotalSI._IIN_EXEMPT_RETALIATION * ratio, 2);
            /*
            target._PLUS_PF_NOTTAXED = Math.Round(total._PLUS_PF_NOTTAXED * ratio, 2);
            target._PLUS_PF_TAXED = Math.Round(total._PLUS_PF_TAXED * ratio, 2);
            target._PLUS_LI_NOTTAXED = Math.Round(total._PLUS_PF_NOTTAXED * ratio, 2);
            target._PLUS_LI_TAXED = Math.Round(total._PLUS_PF_TAXED * ratio, 2);
            target._PLUS_HI_NOTTAXED = Math.Round(total._PLUS_PF_NOTTAXED * ratio, 2);
            target._PLUS_HI_TAXED = Math.Round(total._PLUS_PF_TAXED * ratio, 2);
            */
        }

        public void CalcRf(DateTime dt1, DateTime dt2)
        {
            CalcR = new CalcRInfo(PreparingReport);
            CalcR.CalcR(SRS.TotalRow, dt1, dt2);
            CalcR.ExMax2.ApplyTo0(TotalSI);
            CalcR.ExMax2.ApplyTo(TotalSI);
            TotalSI._RATE_DDSN = CalcR.RateDDSN;
            TotalSI._RATE_DNSN = CalcR.RateDNSN;
            TotalSI._RATE_IIN = CalcR.RateIIN;
        }

        public void SetAvPayTo(SalaryCalcInfo sc)
        {
            sc.SetAvPayFrom(AvPayCalc, AvPayRateHour, AvPayRateDay, AvPayRateCalendarDay);
        }

        public void SetAvPayFrom(SalaryCalcInfo sc)
        {
            SetAvPayFrom(sc.AvPayCalc, sc.AvPayRateHour, sc.AvPayRateDay, sc.AvPayRateCalendarDay);
        }

        public void SetAvPayFrom(AvPayCalcInfo ap, decimal aphour, decimal apday, decimal apcalday)
        {
            if (IsAvPayCalcDone) return;
            AvPayCalc = ap;
            AvPayRateHour = aphour;
            AvPayRateDay = apday;
            AvPayRateCalendarDay = apcalday;
            IsAvPayCalcDone = true;
            TotalSI._AVPAYCALC_HOUR = AvPayRateHour;
            TotalSI._AVPAYCALC_DAY = AvPayRateDay;
            TotalSI._AVPAYCALC_CALDAY = AvPayRateCalendarDay;
            foreach (var lsc in LinkedSCI)
                SetAvPayFrom(ap, aphour, apday, apcalday);
        }


        public ErrorList CalcAvPay()
        {
            if (IsAvPayCalcDone) new ErrorList();
            AvPayCalc = new AvPayCalcInfo(PreparingReport);
            var err = AvPayCalc.CalcAvPay(SRS, TotalSI);
            if (err.HasErrors) return err;
            AvPayCalc.SetAvPayTo(this);
            return new ErrorList();
        }

        public ErrorList CalcSickDays()
        {
            TotalSI._SICKDAYS = 0;
            TotalSI._SICKDAYS_PAY = 0.0M;

            var sc = new SickDayCalcInfo(PreparingReport);

            sc.SetAvPayFrom(this);

            var err = sc.CalcSickDaysT(this);
            if (err.HasErrors) return err;

            sc.SetAvPayTo(this);

            if (sc.TotalRow.DaysCount == 0) return err;

            TotalSI._SICKDAYS = sc.TotalRow.DaysCount;
            TotalSI._SICKDAYS_PAY = sc.TotalRow.SickDayPay;

            if (PreparingReport) SickDayCalc = sc;

            return new ErrorList();
        }

        public ErrorList CalcVacationDays()
        {
            VacationCalc = new VacationCalcInfo(PreparingReport);
            VacationCalc.SetAvPayFrom(this);
            var err = VacationCalc.CalcVacationDaysT(this);
            if (err.HasErrors) return err;
            VacationCalc.SetAvPayTo(this);
            VacationCalc.WriteTo(SRS.TotalPersonPay);
            return new ErrorList();
        }

        public void MakeWorkTime()
        {
            WorkPayCalc = new WorkPayCalcTInfo(PreparingReport);
            WorkPayCalc.CalcWorkPayT(this);
        }

        public ErrorList MakeWorkTime2()
        {
            var err = WorkPayCalc.CalcWorkPayTAvPay(this);
            if (err.HasErrors) return err;
            if (!PreparingReport) WorkPayCalc = null;
            return new ErrorList();
        }

        public void CheckBeforeReport()
        {
            if (AvPayCalc == null) AvPayCalc = new AvPayCalcInfo(true);
            if (SickDayCalc == null) SickDayCalc = new SickDayCalcInfo(true);
            if (VacationCalc == null) VacationCalc = new VacationCalcInfo(true);
            if (WorkPayCalc == null) WorkPayCalc = new WorkPayCalcTInfo(true);
            if (BonusCalc == null) BonusCalc = new BonusCalcInfo((KlonsADataSet.SALARY_PLUSMINUSRow[])null, true);
            if (CalcR == null) CalcR = new CalcRInfo(true);
        }

        public Report_SalaryCalc1 MakeReport1()
        {
            var rep = new Report_SalaryCalc1();
            if (SRS.IsSingleRow())
            {
                var lsc = LinkedSCI[0];
                rep.MakeReport1(lsc.SI);
                rep.Titles[0] = lsc.SR.GetPositionTitle();
                return rep;
            }

            var ct = LinkedSCI.Length;
            if (ct > 4)
            {
                rep.Titles[0] = "";
                rep.addc("Kopā amati");
                rep.MakeReport1(TotalSI);
                for (int i = 0; i < ct; i++)
                {
                    var lsc = LinkedSCI[i];
                    rep.addc("");
                    var c = lsc.SR.GetPositionTitle();
                    rep.addc(c);
                    rep.MakeReport1(lsc.SI);
                }
                return rep;
            }

            rep.DoFullList = true;
            rep.MakeReport1(TotalSI);
            rep.Titles[0] = "Kopā";
            for (int i = 0; i < ct; i++)
            {
                var lsc = LinkedSCI[i];
                rep.Cursor = 0;
                rep.ValueNr = i + 1;
                rep.Titles[i + 1] = lsc.SR.GetPositionTitle();
                rep.MakeReport1(lsc.SI);
            }
            return rep;
        }

    }
}
