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

        public void WriteData()
        {
            SR.TotalPositionPay = SI;
            SI.WriteToRow(SR.Row);
        }

        public PayFxA PFxA = null;

        public ErrorList FillRow()
        {
            if (SR.Row.XType == ESalarySheetRowType.Total)
                return SR.FillRowX();

            if (PreparingReport)
                SI._CALC_VER = SR.Row.CALC_VER;
            else
                SI._CALC_VER = 2;

            var dt1 = SR.SalarySheet.DT1;
            var dt2 = SR.SalarySheet.DT2;

            var err_list = new ErrorList();

            SR.CheckAlgasPS();

            MakeWorkTime();
            CalcRR(dt1, dt2, SI._CALC_VER);

            if (SR.IsSingleRow())
                BonusCalc = new BonusCalcInfo(CalcR, SR.GetAlgasAllPSRows(), PreparingReport);
            else
                BonusCalc = new BonusCalcInfo(CalcR, SR.GetAlgasPSRowsX(SR.Row.IDAM), PreparingReport);

            PFxA = new PayFxA();
            PFxA.Position = PositionTitle;
            PFxA.SetFrom(CalcR);

            var pfxs1 = BonusCalc.CalcNotProc(SI, 0, 1);
            BonusCalc.CalcFromEndA(1);

            var pfxs2 = BonusCalc.CalcProc(SI, EBonusFrom.FromMonthSalary, SI.PlanedWorkPay);
            var pfxs3 = BonusCalc.CalcProc(SI, EBonusFrom.FromPay, SI._SALARY);

            SI._FORAVPAYCALC_BRUTO += BonusCalc.ForAvpayCalc;

            PFxA.TempRows0.AddRange(pfxs1);
            PFxA.TempRows0.AddRange(pfxs2);
            PFxA.TempRows0.AddRange(pfxs3);

            decimal avpay1 =
                SI._SALARY_AVPAY_FREE_DAYS +
                SI._SALARY_AVPAY_WORK_DAYS +
                SI._SALARY_AVPAY_WORK_DAYS_OVERTIME +
                SI._SALARY_AVPAY_HOLIDAYS +
                SI._SALARY_AVPAY_HOLIDAYS_OVERTIME;

            //vid.izpeïòas dienas, slimîbas, atvaïinâjuma nauda
            var err = FillRowVcSdc();
            if (err.HasErrors) return err_list;

            decimal avpay2 = 
                SI._SALARY_AVPAY_FREE_DAYS +
                SI._SALARY_AVPAY_WORK_DAYS +
                SI._SALARY_AVPAY_WORK_DAYS_OVERTIME +
                SI._SALARY_AVPAY_HOLIDAYS +
                SI._SALARY_AVPAY_HOLIDAYS_OVERTIME;

            //PFxA.DoPayFxA_AvPay(avpay2 - avpay1);

            decimal pay1 = 
                SI._SALARY +
                SI._SALARY_AVPAY_FREE_DAYS +
                SI._SICKDAYS_PAY +
                SI._VACATION_PAY_CURRENT;

            pfxs1 = BonusCalc.CalcProc(SI, EBonusFrom.FromPayAndVacSick, pay1);

            decimal payBeforeSAI = 
                pay1 +
                SI._PLUS_TAXED;

            SI._AMOUNT_BEFORE_SN = payBeforeSAI;

            pfxs2 = BonusCalc.CalcProc(SI, EBonusFrom.FromPayBeforeSAI, payBeforeSAI);

            PFxA.TempRows1.AddRange(pfxs1);
            PFxA.TempRows1.AddRange(pfxs2);

            CalcSAI();

            decimal payAfterSAI = 
                SI._AMOUNT_BEFORE_SN - 
                SI._DNSN_AMOUNT;

            pfxs3 = BonusCalc.CalcProc(SI, EBonusFrom.FromPayAfterSAI, payAfterSAI);
            PFxA.TempRows1.AddRange(pfxs3);

            payAfterSAI = 
                payAfterSAI +
                SI._PLUS_NOSAI +
                SI._PLUS_AUTHORS_FEES -
                SI._MINUS_BEFORE_IIN;

            SI._AMOUNT_BEFORE_IIN = payAfterSAI; // pay before iin exempts


            //neto bonus -> bruto
            decimal curbruto =
                SI._AMOUNT_BEFORE_SN -
                SI._PLUS_NOSAI +
                SI._PLUS_AUTHORS_FEES -
                SI._MINUS_BEFORE_IIN;

            decimal iinexempts1 = SI.SumIINExemptsAll();
            decimal payBeforeIIN = payAfterSAI - iinexempts1;

            SI._AMOUNT_BEFORE_IIN = payBeforeIIN;

            //-- useless
            //BonusCalc.CalcProc(SI, EBonusFrom.FromPayBeforeIIN, payBeforeIIN); 

            decimal iinexempts1a = iinexempts1;

            decimal iinexempts1b = iinexempts1;

            List<PayFx2> rpfx = null;
            var plusfromendbruto = BonusCalc.CalcFromEndC(si: SI,
                totalinex: iinexempts1,
                curbruto: curbruto,
                brutonosai: SI._PLUS_NOSAI,
                brutomargin: CalcR.IINMargin,
                useprogressiveiin: CalcR.UseProgresiveIINRate,
                hastaxdoc: CalcR.HasTaxDoc,
                iinrate1: SI._RATE_IIN,
                iinrate2: SI._RATE_IIN2,
                dnsrate: SI._RATE_DNSN,
                divby: SR.GetLinkedRowsCount(),
                rpfx: out rpfx);

            PFxA.TempRows1.AddRange(rpfx);

            if (plusfromendbruto != 0.0M)
            {
                CalcSAI();

                payAfterSAI =
                    SI._AMOUNT_BEFORE_SN -
                    SI._DNSN_AMOUNT +
                    SI._PLUS_NOSAI +
                    SI._PLUS_AUTHORS_FEES -
                    SI._MINUS_BEFORE_IIN;
            }

            CalcIIN();

            SI._TOTAL_BEFORE_TAXES =
                SI._AMOUNT_BEFORE_SN +
                SI._PLUS_NOTTAXED +
                SI._PLUS_NOSAI +
                SI._PLUS_AUTHORS_FEES;

            SI._PAY =
                SI._TOTAL_BEFORE_TAXES -
                SI._DNSN_AMOUNT -
                SI._IIN_AMOUNT;

            pfxs1 = BonusCalc.CalcNotProc(SI, 1, 1);
            pfxs2 = BonusCalc.CalcProc(SI, EBonusFrom.FromPayAfterIIN, SI._PAY);

            PFxA.TempRows2.AddRange(pfxs1);
            PFxA.TempRows2.AddRange(pfxs2);


            PFxA.IinEx = SI.SumIINExemptsAll();

            PFxA.DoPayFxA_Salary(SI._SALARY);
            PFxA.DoPayFxA_Bonus(PFxA.TempRows0);
            PFxA.DoPayFxA_AvPay(SI._SALARY_AVPAY_FREE_DAYS);
            PFxA.DoPayFxA_SickPay(SI._SICKDAYS_PAY);
            PFxA.DoPayFxA_Vacation(SI._VACATION_PAY_CURRENT, SI._VACATION_PAY_PREV);
            CorrectVacCash();
            PFxA.DoPayFxA_Bonus(PFxA.TempRows1);
            PFxA.DoPayFxA_BonusSimpleAdd(PFxA.TempRows2);

            var cashNotPaid = BonusCalc.CalcCashNotPaid(SI, SI._RATE_IIN, SI._RATE_DNSN);
            BonusCalc.CalcCash();


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


        public ErrorList FillRowVcSdc()
        {
            var err_list = new ErrorList();

            err_list = MakeWorkTime2(out AvPayCalcInfo avpaycalc);
            if (err_list.HasErrors) return err_list;

            err_list = CalcSickDays();
            if (err_list.HasErrors) return err_list;

            err_list = CalcVacationDays();
            if (err_list.HasErrors) return err_list;

            if ((AvPayCalc == null || AvPayCalc.RateCalendarDay == 0.0M) &&
                avpaycalc != null &&
                avpaycalc.RateCalendarDay > 0.0M)
            {
                avpaycalc.SetAvPayTo(this);
            }

            return err_list;
        }

        public void CorrectVacCash()
        {
            if (PFxA.PFx_vacation_prev != null)
            {
                VacationCalc.VcrPrevCurrent.IINEX = PFxA.PFx_vacation_prev.UsedIinEx;
                VacationCalc.VcrPrevCurrent.IIN = PFxA.PFx_vacation_prev.IIN;
                VacationCalc.VcrPrevCurrent.Cash = PFxA.PFx_vacation_prev.Cash;
            }
            if (PFxA.PFx_vacation != null)
            {
                VacationCalc.VcrCurrent.IINEX = PFxA.PFx_vacation.UsedIinEx;
                VacationCalc.VcrCurrent.IIN = PFxA.PFx_vacation.IIN;
                VacationCalc.VcrCurrent.Cash = PFxA.PFx_vacation.Cash;

                if (VacationCalc.VcrCompensation.Pay > 0.0M && VacationCalc.VcrCurrent.Pay > 0.0M)
                {
                    decimal r =
                        VacationCalc.VcrCompensation.Pay /
                        VacationCalc.VcrCurrent.Pay;

                    VacationCalc.VcrCompensation.IINEX = VacationCalc.VcrCurrent.IINEX * r;
                    VacationCalc.VcrCompensation.IIN = VacationCalc.VcrCurrent.IIN * r;

                    VacationCalc.VcrCompensation.IINEX = KlonsData.RoundA(VacationCalc.VcrCompensation.IINEX, 2);
                    VacationCalc.VcrCompensation.IIN = KlonsData.RoundA(VacationCalc.VcrCompensation.IIN, 2);

                    VacationCalc.VcrCompensation.Cash =
                        VacationCalc.VcrCompensation.Pay -
                        VacationCalc.VcrCompensation.DNS -
                        VacationCalc.VcrCompensation.IIN;
                }
            }
        }

        public void FillRowFromParentA(decimal iin)
        {
            decimal payAfterSAI =
                SI._AMOUNT_BEFORE_SN -
                SI._DNSN_AMOUNT +
                SI._PLUS_NOSAI +
                SI._PLUS_AUTHORS_FEES -
                SI._MINUS_BEFORE_IIN;

            decimal iinexempts = SI.SumIINExemptsAll();
            decimal payBeforeIIN = payAfterSAI - Math.Min(iinexempts, payAfterSAI);

            SI._AMOUNT_BEFORE_IIN = payBeforeIIN;

            SI._IIN_AMOUNT = iin;

            SI._TOTAL_BEFORE_TAXES =
                SI._AMOUNT_BEFORE_SN +
                SI._PLUS_NOTTAXED +
                SI._PLUS_NOSAI +
                SI._PLUS_AUTHORS_FEES;

            SI._PAY =
                SI._TOTAL_BEFORE_TAXES -
                SI._DNSN_AMOUNT -
                SI._IIN_AMOUNT;
        }

        public void FillRowFromParentB()
        {
            SI._MINUS_AFTER_IIN +=
                SI._PLUS_NP_TAXED +
                SI._PLUS_NP_NOTTAXED +
                SI._PLUS_NP_NOSAI;

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

        }

        public void CalcSAI()
        {
            decimal pay1 =
                SI._SALARY +
                SI._SALARY_AVPAY_FREE_DAYS +
                SI._SICKDAYS_PAY +
                SI._VACATION_PAY_CURRENT +
                SI._PLUS_TAXED;

            SI._AMOUNT_BEFORE_SN = pay1;

            SI._DNSN_AMOUNT = KlonsData.RoundA(SI._AMOUNT_BEFORE_SN * SI._RATE_DNSN / 100.0M, 2);
            SI._DDSN_AMOUNT = KlonsData.RoundA(SI._AMOUNT_BEFORE_SN * SI._RATE_DDSN / 100.0M, 2);
            SI._SN_AMOUNT = SI._DDSN_AMOUNT + SI._DNSN_AMOUNT;
        }

        public void CalcIIN()
        {
            decimal pay1 =
                SI._AMOUNT_BEFORE_SN -
                SI._PLUS_NOSAI +
                SI._PLUS_AUTHORS_FEES;

            decimal payAfterSAI =
                SI._AMOUNT_BEFORE_SN -
                SI._DNSN_AMOUNT +
                SI._PLUS_NOSAI +
                SI._PLUS_AUTHORS_FEES -
                SI._MINUS_BEFORE_IIN;

            decimal iinexempts = SI.SumIINExemptsAll();

            if (!CalcR.UseProgresiveIINRate)
            {
                iinexempts = Math.Min(iinexempts, payAfterSAI);
                SI._AMOUNT_BEFORE_IIN = payAfterSAI - iinexempts;
                SI._IIN_AMOUNT = KlonsData.RoundA(SI._AMOUNT_BEFORE_IIN * SI._RATE_IIN / 100.0M, 2);
            }
            else if(CalcR.HasTaxDoc)
            {
                if(pay1 <= CalcR.IINMargin)
                {
                    iinexempts = Math.Min(iinexempts, payAfterSAI);
                    SI._AMOUNT_BEFORE_IIN = payAfterSAI - iinexempts;
                    SI._IIN_AMOUNT = KlonsData.RoundA(SI._AMOUNT_BEFORE_IIN * SI._RATE_IIN / 100.0M, 2);
                }
                else
                {
                    decimal amountbeforeiin =
                        CalcR.IINMargin -
                        SI._DNSN_AMOUNT -
                        SI._MINUS_BEFORE_IIN -
                        iinexempts;

                    decimal iin = amountbeforeiin * SI._RATE_IIN / 100.0M;

                    decimal amountbeforeiin2 =
                        pay1 -
                        CalcR.IINMargin;

                    iin += amountbeforeiin2 * SI._RATE_IIN2 / 100.0M;

                    if (iin < 0.0M)
                    {
                        iinexempts += KlonsData.RoundA(iin / (SI._RATE_IIN / 100.0M), 2);
                        iin = 0.0M;
                    }

                    SI._IIN_AMOUNT = KlonsData.RoundA(iin, 2);
                }
            }
            else
            {
                if (SI._CALC_VER < KlonsData.VersionRef(2))
                {
                    iinexempts = 0.0M;
                    SI._AMOUNT_BEFORE_IIN = payAfterSAI - iinexempts;
                    decimal iin =
                        (SI._AMOUNT_BEFORE_IIN + SI._DNSN_AMOUNT) * SI._RATE_IIN2 / 100.0M -
                        SI._DNSN_AMOUNT * SI._RATE_IIN / 100.0M;
                    SI._IIN_AMOUNT = KlonsData.RoundA(iin, 2);
                }
                else
                {
                    SI._AMOUNT_BEFORE_IIN = payAfterSAI - iinexempts;
                    decimal iin =
                        (SI._AMOUNT_BEFORE_IIN + SI._DNSN_AMOUNT) * SI._RATE_IIN2 / 100.0M -
                        SI._DNSN_AMOUNT * SI._RATE_IIN / 100.0M;
                    if(iin < 0.0M)
                    {
                        iin = 0.0M;
                        iinexempts = payAfterSAI + SI._DNSN_AMOUNT - SI._DNSN_AMOUNT * SI._RATE_IIN / SI._RATE_IIN2;
                        iinexempts = KlonsData.RoundA(iinexempts, 2);
                    }
                    SI._IIN_AMOUNT = KlonsData.RoundA(iin, 2);
                }
            }

            SI._AMOUNT_BEFORE_IIN = payAfterSAI - iinexempts;

            CalcR.ExDivided.ApplyTo0(SI);
            CalcR.CorrectIINExempts(iinexempts);
            CalcR.ExCorrect.ApplyTo(SI);
            CalcR.SaveStateForFinal(CalcR.ExCorrect);
            CalcR.AddToListT();
            CalcR.PrepareList();

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
            decimal iin = 0.0M;
            if (CalcR.UseProgresiveIINRate)
            {
                iin = (Math.Min(SI._PLUS_NP_TAXED + SI._PLUS_NP_NOSAI, CalcR.IINMargin) - sai - iinex) * SI._RATE_IIN / 100.0M;
                iin += Math.Max(SI._PLUS_NP_TAXED + SI._PLUS_NP_NOSAI - CalcR.IINMargin, 0.0M) * SI._RATE_IIN2 / 100.0M;
                iin = KlonsData.RoundA(Math.Max(iin, 0.0M), 2);
            }
            else
                iin = KlonsData.RoundA((beforeiinex - iinex) * SI._RATE_IIN / 100.0M, 2);

            decimal pay0 = totalpay1 - sai - iin + SI._MINUS_AFTER_IIN;
            if (SI._ADVANCE < 0.0M)
                pay0 += -SI._ADVANCE;
            pay0 = Math.Min(pay0, SI._PAY);

            return pay0;
        }

        public void CalcRR(DateTime dt1, DateTime dt2, int calcver)
        {
            CalcR = new CalcRInfo(PreparingReport, calcver);
            CalcR.CalcR(SR, dt1, dt2);
            CalcR.ExMax2.ApplyTo0(SI);
            CalcR.ExMax2.ApplyTo(SI);
            SI._RATE_DDSN = CalcR.RateDDSN;
            SI._RATE_DNSN = CalcR.RateDNSN;
            SI._RATE_IIN = CalcR.RateIIN;
            SI._RATE_IIN2 = CalcR.RateIIN2;
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
            VacationCalc = new VacationCalcInfo(PreparingReport, SI._CALC_VER);

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

        public ErrorList MakeWorkTime2(out AvPayCalcInfo avpaycalc)
        {
            avpaycalc = null;
            var err = WorkPayCalc.CalcPayWithAvPay(SR, null);
            if (err.HasErrors) return err;
            if (WorkPayCalc.AvPayCalc != null && WorkPayCalc.AvPayCalc.RateCalendarDay > 0.0M)
            {
                avpaycalc = WorkPayCalc.AvPayCalc;
            }
            if (!PreparingReport) WorkPayCalc = null;
            return new ErrorList();
        }

        public void CheckBeforeReport()
        {
            if (AvPayCalc == null) AvPayCalc = new AvPayCalcInfo(true);
            if (SickDayCalc == null) SickDayCalc = new SickDayCalcInfo(true);
            if (VacationCalc == null) VacationCalc = new VacationCalcInfo(true, SI._CALC_VER);
            if (WorkPayCalc == null) WorkPayCalc = new WorkPayCalcInfo(true);
            if (CalcR == null) CalcR = new CalcRInfo(true, SI._CALC_VER);
            if (BonusCalc == null) BonusCalc = new BonusCalcInfo(CalcR, (KlonsADataSet.SALARY_PLUSMINUSRow[])null, true);
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
