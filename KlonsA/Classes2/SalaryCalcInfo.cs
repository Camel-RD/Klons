using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsLIB.Misc;
using KlonsLIB.Data;

namespace KlonsA.Classes
{
    public class SalaryCalcInfo
    {
        public static KlonsData MyData => KlonsData.St;

        public bool PreparingReport = false;
        public SalarySheetRowInfo SR = null;
        public SalaryInfo SI = null;
        public string PositionTitle = null;

        public AvPayCalcInfo AvPayCalc = null;
        public SickDayCalcInfo SickDayCalc = null;
        public VacationCalcInfo VacationCalc = null;
        public WorkPayCalcInfo WorkPayCalc = null;
        public BonusCalcInfo BonusCalc = null;
        public CalcRInfo CalcR = null;

        public bool IsAvPayCalcDone = false;
        public decimal AvPayRateHour = 0.0M;
        public decimal AvPayRateDay = 0.0M;
        public decimal AvPayRateCalendarDay = 0.0M;

        public SalaryCalcInfo(SalarySheetRowInfo sr, SalaryInfo si, bool filllist)
        {
            SR = sr;
            SI = si;
            PositionTitle = sr.GetPositionTitle();
            PreparingReport = filllist;
            if (PreparingReport)
            {

            }
        }

        public ErrorList FillRowX()
        {
            var err = SR.CheckLinkedRows(SR.Row.IDP);
            if (err.HasErrors) return err;
            err = SR.SalarySheetRowSet.FillRow();
            return err;
        }

        public ErrorList FillRow()
        {
            if (SR.Row.XType == ESalarySheetRowType.Total)
                return SR.FillRowX();

            var dt1 = SR.SalarySheet.DT1;
            var dt2 = SR.SalarySheet.DT2;

            var err_list = new ErrorList();

            SR.CheckAlgasPS();

            MakeWorkTime();

            if (SR.IsSingleRow())
                BonusCalc = new BonusCalcInfo(SR.GetAlgasAllPSRows(), PreparingReport);
            else
                BonusCalc = new BonusCalcInfo(SR.GetAlgasPSRowsX(SR.Row.IDAM), PreparingReport);

            CalcRR(dt1, dt2);
            FillRow1();
            FillRowVcSdc();
            FillRowA();
            FillRowB();
            return err_list;
        }

        public void WriteData()
        {
            SR.TotalPositionPay = SI;
            SI.WriteToRow(SR.Row);
        }

        public void FillRow1()
        {
            BonusCalc.CalcNotProc(SR.TotalPositionPay, SR.GetLinkedRowsCount());
            BonusCalc.CalcFromEndA(SR.GetLinkedRowsCount());

            decimal pay1 = SI._SALARY;

            if (SI._R_TYPE == (int)ESalaryType.Month)
            {
                BonusCalc.CalcProc(SI, EBonusFrom.FromMonthSalary, SI._R_MT);
            }
            BonusCalc.CalcProc(SI, EBonusFrom.FromPay, pay1);

            SI._FORAVPAYCALC_BRUTO += BonusCalc.ForAvpayCalc;
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

            decimal pay1 = SI._SALARY;

            decimal pay2 = pay1 +
                SI._SICKDAYS_PAY +
                SI._VACATION_PAY_CURRENT;

            BonusCalc.CalcProc(SI, EBonusFrom.FromPayAndVacSick, pay2);

            decimal payBeforeSAI = pay2 +
                SI._PLUS_TAXED;

            SI._AMOUNT_BEFORE_SN = payBeforeSAI;

            BonusCalc.CalcProc(SI, EBonusFrom.FromPayBeforeSAI, payBeforeSAI);

            SI._DNSN_AMOUNT = KlonsData.RoundA(SI._AMOUNT_BEFORE_SN * SI._RATE_DNSN / 100.0M, 2);
            SI._DDSN_AMOUNT = KlonsData.RoundA(SI._AMOUNT_BEFORE_SN * SI._RATE_DDSN / 100.0M, 2);
            SI._SN_AMOUNT = SI._DDSN_AMOUNT + SI._DNSN_AMOUNT;

            decimal payAfterSAI = payBeforeSAI - SI._DNSN_AMOUNT;

            BonusCalc.CalcProc(SI, EBonusFrom.FromPayAfterSAI, payAfterSAI);

            decimal payAfterSAI2 = payAfterSAI +
                 SI._PLUS_NOSAI +
                 SI._PLUS_AUTHORS_FEES -
                 SI._MINUS_BEFORE_IIN;

            SI._AMOUNT_BEFORE_IIN = payAfterSAI2; // pay before iin exempts

            return err_list;
        }


        public ErrorList FillRowB()
        {
            if (SR.Row.XType == ESalarySheetRowType.Total)
                throw new Exception("Bad idea.");

            var err_list = new ErrorList();


            decimal payAfterSAI = 
                SI._AMOUNT_BEFORE_SN - 
                SI._DNSN_AMOUNT +
                SI._PLUS_NOSAI +
                SI._PLUS_AUTHORS_FEES -
                SI._MINUS_BEFORE_IIN;

            decimal iinexempts1 = SI.SumIINExemptsAll();
            decimal iinexemptleft = Math.Max(iinexempts1 - payAfterSAI, 0.0M);

            var plusfromendbruto = BonusCalc.CalcFromEndB(SI, 
                iinexemptleft, SI._RATE_IIN, SI._RATE_DNSN, SR.GetLinkedRowsCount());

            if (plusfromendbruto != 0.0M)
            {
                decimal pay1 = 
                    SI._SALARY +
                    SI._SICKDAYS_PAY +
                    SI._VACATION_PAY_CURRENT +
                    SI._PLUS_TAXED;

                SI._AMOUNT_BEFORE_SN = pay1;

                SI._DNSN_AMOUNT = KlonsData.RoundA(SI._AMOUNT_BEFORE_SN * SI._RATE_DNSN / 100.0M, 2);
                SI._DDSN_AMOUNT = KlonsData.RoundA(SI._AMOUNT_BEFORE_SN * SI._RATE_DDSN / 100.0M, 2);
                SI._SN_AMOUNT = SI._DDSN_AMOUNT + SI._DNSN_AMOUNT;

                payAfterSAI =
                    SI._AMOUNT_BEFORE_SN - 
                    SI._DNSN_AMOUNT +
                    SI._PLUS_NOSAI +
                    SI._PLUS_AUTHORS_FEES -
                    SI._MINUS_BEFORE_IIN;
            }

            CalcR.ExDivided.ApplyTo0(SI);
            CalcR.CorrectIINExempts(payAfterSAI);
            CalcR.ExCorrect.ApplyTo(SI);
            CalcR.SaveStateForFinal(CalcR.ExCorrect);
            CalcR.AddToListT();
            CalcR.PrepareList();

            decimal iinexempts2 = SI.SumIINExemptsAll();
            decimal payBeforeIIN = payAfterSAI - iinexempts2;

            SI._AMOUNT_BEFORE_IIN = payBeforeIIN;

            //-- useless
            //BonusCalc.CalcProc(SI, EBonusFrom.FromPayBeforeIIN, payBeforeIIN); 

            SI._IIN_AMOUNT = KlonsData.RoundA(SI._AMOUNT_BEFORE_IIN * SI._RATE_IIN / 100.0M, 2);

            decimal PpayAfterIIN = payAfterSAI - SI._IIN_AMOUNT;

            SI._TOTAL_BEFORE_TAXES =
                SI._AMOUNT_BEFORE_SN +
                SI._PLUS_NOTTAXED +
                SI._PLUS_NOSAI +
                SI._PLUS_AUTHORS_FEES;

            SI._PAY = 
                SI._TOTAL_BEFORE_TAXES -
                SI._DNSN_AMOUNT -
                SI._IIN_AMOUNT;

            BonusCalc.CalcProc(SI, EBonusFrom.FromPayAfterIIN, SI._PAY);

            var cashNotPaid = BonusCalc.CalcCashNotPaid(SI, SI._RATE_IIN, SI._RATE_DNSN);
            BonusCalc.CalcCash(SI, SI._RATE_IIN, SI._RATE_DNSN);

            VacationCalc.CorrectCash(SI);

            //viens no diviem variantiem
            //SI._MINUS_AFTER_IIN += cashNotPaid;
            SI._MINUS_AFTER_IIN += 
                SI._PLUS_NP_TAXED + 
                SI._PLUS_NP_NOTTAXED + 
                SI._PLUS_NP_NOSAI;

            //---Negatîva izmaksâjamâ summa ir OK
            SI._VACATION_ADVANCE_CURRENT = -SI._VACATION_ADVANCE_PREV;

            SI._VACATION_ADVANCE_NEXT =
                SI._VACATION_ADVANCE_PREV +
                SI._VACATION_ADVANCE_CURRENT +
                SI._VACATION_CASH_NEXT;

            SI._ADVANCE = SI._VACATION_CASH_NEXT + SI._VACATION_ADVANCE_CURRENT;

            SI._PAYT = 
                SI._PAY +
                SI._ADVANCE -
                SI._MINUS_AFTER_IIN;

            SI._FORAVPAYCALC_PAYOUT = SI._PAY;

            SI._PAY0 = CalcPay0();

            SI._URVN_AMAOUNT = CalcURVN();

            return err_list;
        }

        public decimal CalcURVN()
        {
            decimal r = 0.0M;
            if (SR?.SalarySheet?.DR_Likmes != null)
                r = SR.SalarySheet.DR_Likmes.URN /
                    (decimal)SR.GetLinkedRowsCount();
            r = KlonsData.RoundA(r, 2);
            return r;
        }

        public decimal CalcPay0()
        {
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
            if (SI._ADVANCE < 0.0M)
                pay0 += -SI._ADVANCE;
            pay0 = Math.Min(pay0, SI._PAY);

            return pay0;
        }

        public void CalcRR(DateTime dt1, DateTime dt2)
        {
            CalcR = new CalcRInfo(PreparingReport);
            CalcR.CalcR(SR, dt1, dt2);
            CalcR.ExMax2.ApplyTo0(SI);
            CalcR.ExMax2.ApplyTo(SI);
            SI._RATE_DDSN = CalcR.RateDDSN;
            SI._RATE_DNSN = CalcR.RateDNSN;
            SI._RATE_IIN = CalcR.RateIIN;
        }

        public ErrorList CalcAvPay()
        {
            if (SR.SalarySheetRowSet == null)
                throw new Exception("Bad Init.");

            var err_list = new ErrorList();
            if (IsAvPayCalcDone) return err_list;

            AvPayCalc = new AvPayCalcInfo(PreparingReport);
            err_list = AvPayCalc.CalcAvPay(SR.SalarySheetRowSet, SI);
            if (err_list.HasErrors) return err_list;
            AvPayCalc.SetAvPayTo(this);
            return err_list;
        }

        public void SetAvPayFrom(AvPayCalcInfo ap, decimal aphour, decimal apday, decimal apcalday)
        {
            if (IsAvPayCalcDone) return;
            AvPayCalc = ap;
            AvPayRateHour = aphour;
            AvPayRateDay = apday;
            AvPayRateCalendarDay = apcalday;
            IsAvPayCalcDone = true;
            SI._AVPAYCALC_HOUR = AvPayRateHour;
            SI._AVPAYCALC_DAY = AvPayRateDay;
            SI._AVPAYCALC_CALDAY = AvPayRateCalendarDay;
        }

        public ErrorList CalcSickDays()
        {
            var sc = new SickDayCalcInfo(PreparingReport);

            var err = sc.CalcSickDays(this);
            if (err.HasErrors) return err;

            if (PreparingReport) SickDayCalc = sc;
            return err;
        }

        public ErrorList CalcVacationDays()
        {
            VacationCalc = new VacationCalcInfo(PreparingReport);

            var err = VacationCalc.CalcVacationDays(this);
            if (err.HasErrors) return err;

            return new ErrorList();
        }

        public void MakeWorkTime()
        {
            if (SR.Row.XType == ESalarySheetRowType.Total)
                throw new Exception("Bad idea.");

            WorkPayCalc = new WorkPayCalcInfo(PreparingReport);
            WorkPayCalc.CalcWorkPay(SR, SI);
        }

        public ErrorList MakeWorkTime2()
        {
            var err = WorkPayCalc.CalcPayWithAvPay(SR, null);
            if (err.HasErrors) return err;
            if (!PreparingReport) WorkPayCalc = null;
            return new ErrorList();
        }

        public void CheckBeforeReport()
        {
            if (AvPayCalc == null) AvPayCalc = new AvPayCalcInfo(true);
            if (SickDayCalc == null) SickDayCalc = new SickDayCalcInfo(true);
            if (VacationCalc == null) VacationCalc = new VacationCalcInfo(true);
            if (WorkPayCalc == null) WorkPayCalc = new WorkPayCalcInfo(true);
            if (BonusCalc == null) BonusCalc = new BonusCalcInfo((KlonsADataSet.SALARY_PLUSMINUSRow[])null, true);
            if (CalcR == null) CalcR = new CalcRInfo(true);
        }

        public List<SalaryCalcRow> MakeReport1()
        {
            var rep = new Report_SalaryCalc1();
            rep.Titles[0] = SR.GetPositionTitle();
            rep.MakeReport1(SI);
            return rep.Rows;
        }

    }



}
