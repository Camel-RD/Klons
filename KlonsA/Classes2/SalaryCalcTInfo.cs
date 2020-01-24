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

        public PayFxB PFxB = null;

        private decimal[] GetValues(Func<SalaryInfo, decimal> fval)
        {
            return LinkedSCI.Select(d => fval(d.SI)).ToArray();
        }


        public ErrorList FillRow()
        {
            IsAvPayCalcDone = false;


            var dt1 = SRS.SalarySheet.DT1;
            var dt2 = SRS.SalarySheet.DT2;

            var err_list = new ErrorList();
            ErrorList err = null;

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
                err = sci.FillRow();
                err_list.AddRange(err);
                SRS.TotalPersonPay = sci.SI;
                return err_list;
            }

            BonusCalcInfo bonus_am;

            TotalSI = new SalaryInfo();

            if (PreparingReport)
                TotalSI._CALC_VER = SRS.TotalRow.Row.CALC_VER;
            else
                TotalSI._CALC_VER = 2;

            SRS.TotalPersonPay = TotalSI;
            SRS.TotalRow.TotalPositionPay = TotalSI;

            MakeWorkTime(); // updates all rows and TotalPersonPay
            CalcRf(dt1, dt2, TotalSI._CALC_VER);

            var drs_bonust = SRS.GetAlgasAllPSRows();

            BonusCalc = new BonusCalcInfo(CalcR, drs_bonust, PreparingReport);

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var lr = SRS.LinkedRows[i];
                var lsc = LinkedSCI[i];

                bonus_am = BonusCalc.Filter(
                    d =>
                    d.IsIDANull() ||
                    (!d.IsIDANull() &&
                    d.IDA == lr.Row.IDAM));

                lsc.BonusCalc = bonus_am;

                lsc.SR.CheckAlgasPS();
                lsc.CalcRR(dt1, dt2, lsc.SI._CALC_VER);
            }
            LinkedSCI[0].BonusCalc.TakeRoundingError = true;


            PFxB = new PayFxB();

            var cret1 = BonusCalc.CalcNotProcT(this, 0);
            BonusCalc.CalcFromEndAT(this);

            var cret2 = BonusCalc.CalcProcT(this, EBonusFrom.FromMonthSalary, d=>d.PlanedWorkPay);
            var cret3 = BonusCalc.CalcProcT(this, EBonusFrom.FromPay, d=>d._SALARY);

            TotalSI._FORAVPAYCALC_BRUTO += BonusCalc.ForAvpayCalc;
            foreach(var sci in LinkedSCI) 
                sci.SI._FORAVPAYCALC_BRUTO += sci.BonusCalc.ForAvpayCalc;

            PFxB.TempCRets0.AddRange(cret1);
            PFxB.TempCRets0.AddRange(cret2);
            PFxB.TempCRets0.AddRange(cret3);

            //SummForAvPayCalcBruto(); //--allredy done

            decimal[] avpay1 = GetAvPay();
            decimal savpay1 = avpay1.Sum();

            err = FillRowVcSdc();
            if (err.HasErrors) return err_list;

            decimal[] avpay2 = GetAvPay();
            decimal savpay2 = avpay2.Sum();
            if (savpay2 > savpay1)
            {
                for (int i = 0; i < avpay1.Length; i++)
                    avpay2[i] -= avpay1[i];
                //PFxB.DoPayFxB_AvPay(savpay2 - savpay1, avpay2);
            }


            cret1 = BonusCalc.CalcProcT(this, EBonusFrom.FromPayAndVacSick, 
                d=> 
                d._SALARY + 
                d._SICKDAYS_PAY + 
                d._VACATION_PAY_CURRENT);

            cret2 = BonusCalc.CalcProcT(this, EBonusFrom.FromPayBeforeSAI,
                d =>
                d._SALARY +
                d._SICKDAYS_PAY +
                d._VACATION_PAY_CURRENT +
                d._PLUS_TAXED);

            CalcSAI();

            cret3 = BonusCalc.CalcProcT(this, EBonusFrom.FromPayAfterSAI,
                d =>
                d._AMOUNT_BEFORE_SN -
                d._DNSN_AMOUNT);

            PFxB.TempCRets1.AddRange(cret1);
            PFxB.TempCRets1.AddRange(cret2);
            PFxB.TempCRets1.AddRange(cret3);


         
            //done in BonusCalc.Calc
            //Summ1();


            decimal payAfterSAI =
                TotalSI._AMOUNT_BEFORE_SN -
                TotalSI._DNSN_AMOUNT +
                TotalSI._PLUS_NOSAI +
                TotalSI._PLUS_AUTHORS_FEES -
                TotalSI._MINUS_BEFORE_IIN;

            TotalSI._AMOUNT_BEFORE_IIN = payAfterSAI;

            decimal curbruto =
                TotalSI._AMOUNT_BEFORE_SN -
                TotalSI._PLUS_NOSAI +
                TotalSI._PLUS_AUTHORS_FEES -
                TotalSI._MINUS_BEFORE_IIN;

            decimal iinexempts1 = TotalSI.SumIINExemptsAll();

            List<BonusCalcInfo.CalcRet> rpfx = null;
            var plusfromendbruto = BonusCalc.CalcFromEndCT(
                sct: this,
                totalinex: iinexempts1,
                curbruto: curbruto,
                brutonosai: TotalSI._PLUS_NOSAI,
                brutomargin: CalcR.IINMargin,
                brutomargina: CalcR.IINMarginA,
                brutomarginb: CalcR.IINMarginB,
                useprogressiveiin: CalcR.UseProgresiveIINRate,
                hastaxdoc: CalcR.HasTaxDoc,
                iinrate1: TotalSI._RATE_IIN,
                iinrate2: TotalSI._RATE_IIN2,
                dnsrate: TotalSI._RATE_DNSN,
                divby: LinkedSCI.Length,
                rpfx: out rpfx);

            PFxB.TempCRets1.AddRange(rpfx);

            if (plusfromendbruto != 0.0M)
            {
                CalcSAI();

                payAfterSAI =
                    TotalSI._AMOUNT_BEFORE_SN -
                    TotalSI._DNSN_AMOUNT +
                    TotalSI._PLUS_NOSAI +
                    TotalSI._PLUS_AUTHORS_FEES -
                    TotalSI._MINUS_BEFORE_IIN;
            }


            CalcIIN();

            TotalSI._TOTAL_BEFORE_TAXES =
                TotalSI._AMOUNT_BEFORE_SN +
                TotalSI._PLUS_NOTTAXED +
                TotalSI._PLUS_NOSAI +
                TotalSI._PLUS_AUTHORS_FEES;

            TotalSI._PAY =
                TotalSI._TOTAL_BEFORE_TAXES -
                TotalSI._DNSN_AMOUNT -
                TotalSI._IIN_AMOUNT;


            PFxB.SetFrom(CalcR);
            PFxB.IinEx = TotalSI.SumIINExemptsAll();
            PFxB.InitParts(this);

            PFxB.DoPayFxB_Salary(TotalSI._SALARY, GetValues(d => d._SALARY));
            PFxB.DoPayFxB_Bonus(PFxB.TempCRets0);
            PFxB.DoPayFxB_SickPay(
                TotalSI._SICKDAYS_PAY,
                GetValues(d => d._SICKDAYS_PAY));
            PFxB.DoPayFxB_VacationPrev(
                TotalSI._VACATION_PAY_PREV,
                GetValues(d => d._VACATION_PAY_PREV));
            PFxB.DoPayFxB_Vacation(
                TotalSI._VACATION_PAY_CURRENT,
                GetValues(d => d._VACATION_PAY_CURRENT));

            CorrectVacCash();
            PFxB.DoPayFxB_Bonus(PFxB.TempCRets1);

            MakeExactIINExSplit();

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var lsc = LinkedSCI[i];
                lsc.FillRowFromParentA(PFxB.Parts[i].IIN);
            }


            cret1 = BonusCalc.CalcNotProcT(this, 1);
            cret2 = BonusCalc.CalcProcT(this, EBonusFrom.FromPayAfterIIN,
                d => d._PAY);


            PFxB.TempCRets2.AddRange(cret1);
            PFxB.TempCRets2.AddRange(cret2);
            PFxB.DoPayFxB_BonusSimpleAdd(PFxB.TempCRets2);
            BonusCalc.CalcCashT(this);


            //  ?????? ?????
            //Summ1();

            TotalSI._MINUS_AFTER_IIN +=
                TotalSI._PLUS_NP_TAXED +
                TotalSI._PLUS_NP_NOTTAXED +
                TotalSI._PLUS_NP_NOSAI;

            //---Negatīva izmaksājamā summa ir OK
            TotalSI._VACATION_ADVANCE_CURRENT = -TotalSI._VACATION_ADVANCE_PREV;

            TotalSI._VACATION_ADVANCE_NEXT =
                TotalSI._VACATION_ADVANCE_PREV +
                TotalSI._VACATION_ADVANCE_CURRENT +
                TotalSI._VACATION_CASH_NEXT;

            TotalSI._ADVANCE = 
                TotalSI._VACATION_CASH_NEXT + 
                TotalSI._VACATION_ADVANCE_CURRENT;

            TotalSI._PAYT =
                TotalSI._PAY +
                TotalSI._ADVANCE -
                TotalSI._MINUS_AFTER_IIN;

            TotalSI._FORAVPAYCALC_PAYOUT = TotalSI._PAY;

            TotalSI._PAY0 = CalcPay0();

            if (SRS?.SalarySheet?.DR_Likmes != null)
                TotalSI._URVN_AMAOUNT = SRS.SalarySheet.DR_Likmes.URN;


            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var lsc = LinkedSCI[i];
                lsc.FillRowFromParentB();
            }


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

        private decimal[] GetAvPay()
        {
            decimal[] ret = new decimal[LinkedSCI.Length];
            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var lscsi = LinkedSCI[i].SI;
                ret[i] =
                    lscsi._SALARY_AVPAY_FREE_DAYS +
                    lscsi._SALARY_AVPAY_WORK_DAYS +
                    lscsi._SALARY_AVPAY_WORK_DAYS_OVERTIME +
                    lscsi._SALARY_AVPAY_HOLIDAYS +
                    lscsi._SALARY_AVPAY_HOLIDAYS_OVERTIME;
            }
            return ret;
        }

        public void MakeExactIINExSplit()
        {
            var dd1 = new[]{
                TotalSI._IIN_EXEMPT_UNTAXED_MINIMUM,
                TotalSI._IIN_EXEMPT_DEPENDANTS,
                TotalSI._IIN_EXEMPT_INVALIDITY,
                TotalSI._IIN_EXEMPT_NATIONAL_MOVEMENT,
                TotalSI._IIN_EXEMPT_RETALIATION,
                TotalSI._IIN_EXEMPT_EXPENSES};

            var dd2 = PFxB.Parts.Select(d => d.UsedIinEx).ToArray();

            var dd = PayFxA.MakeExactSplit(dd1, dd2);

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var lsc = LinkedSCI[i];
                var si = lsc.SI;
                si._IIN_EXEMPT_UNTAXED_MINIMUM = dd[0, i];
                si._IIN_EXEMPT_DEPENDANTS = dd[1, i];
                si._IIN_EXEMPT_INVALIDITY = dd[2, i];
                si._IIN_EXEMPT_NATIONAL_MOVEMENT = dd[3, i];
                si._IIN_EXEMPT_RETALIATION = dd[4, i];
                si._IIN_EXEMPT_EXPENSES = dd[5, i];

                si._IIN_EXEMPT_2 =
                    si._IIN_EXEMPT_INVALIDITY +
                    si._IIN_EXEMPT_NATIONAL_MOVEMENT +
                    si._IIN_EXEMPT_RETALIATION;

                lsc.CalcR.ExDivided.SetFrom(si);
                lsc.CalcR.ExCorrect.SetFrom(lsc.CalcR.ExDivided);
                lsc.CalcR.SaveStateForFinal(CalcR.ExCorrect);
                lsc.CalcR.AddToListT();
                lsc.CalcR.PrepareList();
            }

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

        public void SummForAvPayCalcBruto()
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
            if (PFxB.PFx_vacation_prev != null)
            {
                VacationCalc.VcrPrevCurrent.IINEX = PFxB.PFx_vacation_prev.UsedIinEx;
                VacationCalc.VcrPrevCurrent.IIN = PFxB.PFx_vacation_prev.IIN;
                VacationCalc.VcrPrevCurrent.Cash = PFxB.PFx_vacation_prev.Cash;
            }
            if (PFxB.PFx_vacation != null)
            {
                VacationCalc.VcrCurrent.IINEX = PFxB.PFx_vacation.UsedIinEx;
                VacationCalc.VcrCurrent.IIN = PFxB.PFx_vacation.IIN;
                VacationCalc.VcrCurrent.Cash = PFxB.PFx_vacation.Cash;

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

        public void CalcSAI()
        {
            var SI = TotalSI;

            decimal pay1 =
                SI._SALARY +
                SI._SICKDAYS_PAY +
                SI._VACATION_PAY_CURRENT +
                SI._PLUS_TAXED;

            SI._AMOUNT_BEFORE_SN = pay1;

            SI._DNSN_AMOUNT = KlonsData.RoundA(SI._AMOUNT_BEFORE_SN * SI._RATE_DNSN / 100.0M, 2);
            SI._DDSN_AMOUNT = KlonsData.RoundA(SI._AMOUNT_BEFORE_SN * SI._RATE_DDSN / 100.0M, 2);
            SI._SN_AMOUNT = SI._DDSN_AMOUNT + SI._DNSN_AMOUNT;

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var lsc = LinkedSCI[i];
                lsc.CalcSAI();
            }

            Utils.MakeExactSum(SI._DNSN_AMOUNT, LinkedSCI, 
                d => d.SI._DNSN_AMOUNT, 
                (d, val) => d.SI._DNSN_AMOUNT = val);

            Utils.MakeExactSum(SI._DDSN_AMOUNT, LinkedSCI,
                d => d.SI._DDSN_AMOUNT,
                (d, val) => d.SI._DDSN_AMOUNT = val);

            for (int i = 0; i < LinkedSCI.Length; i++)
            {
                var lsc = LinkedSCI[i];
                lsc.SI._SN_AMOUNT = lsc.SI._DNSN_AMOUNT + lsc.SI._DDSN_AMOUNT;
            }

        }

        public void CalcIIN()
        {
            var SI = TotalSI;

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
            else if (CalcR.HasTaxDoc)
            {
                if (pay1 <= CalcR.IINMargin)
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
                    if (iin < 0.0M)
                    {
                        iin = 0.0M;
                        iinexempts = payAfterSAI + SI._DNSN_AMOUNT - SI._DNSN_AMOUNT * SI._RATE_IIN / SI._RATE_IIN2;
                        iinexempts = KlonsData.RoundA(iinexempts, 2);
                    }
                    SI._IIN_AMOUNT = KlonsData.RoundA(iin, 2);
                }
            }

            SI._AMOUNT_BEFORE_IIN = payAfterSAI - iinexempts;


            CalcR.ExDivided.ApplyTo0(TotalSI);
            CalcR.CorrectIINExempts(iinexempts);
            CalcR.ExCorrect.ApplyTo(TotalSI);
            CalcR.SaveStateForFinal(CalcR.ExCorrect);
            CalcR.AddToListT();
            CalcR.PrepareList();

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
            pay0 = Math.Min(pay0, SI._PAYT);

            return pay0;
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

        public void CalcRf(DateTime dt1, DateTime dt2, int calcver)
        {
            CalcR = new CalcRInfo(PreparingReport, calcver);
            CalcR.CalcR(SRS.TotalRow, dt1, dt2);
            CalcR.ExMax2.ApplyTo0(TotalSI);
            CalcR.ExMax2.ApplyTo(TotalSI);
            TotalSI._RATE_DDSN = CalcR.RateDDSN;
            TotalSI._RATE_DNSN = CalcR.RateDNSN;
            TotalSI._RATE_IIN = CalcR.RateIIN;
            TotalSI._RATE_IIN2 = CalcR.RateIIN2;
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
            VacationCalc = new VacationCalcInfo(PreparingReport, TotalSI._CALC_VER);
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

        public ErrorList MakeWorkTime2(out AvPayCalcInfo avpaycalc)
        {
            avpaycalc = null;
            var err = WorkPayCalc.CalcWorkPayTAvPay(this);
            if (WorkPayCalc.AvPayCalc != null && WorkPayCalc.AvPayCalc.RateCalendarDay > 0.0M)
            {
                avpaycalc = WorkPayCalc.AvPayCalc;
            }
            if (err.HasErrors) return err;
            if (!PreparingReport) WorkPayCalc = null;
            return new ErrorList();
        }

        public void CheckBeforeReport()
        {
            if (AvPayCalc == null) AvPayCalc = new AvPayCalcInfo(true);
            if (SickDayCalc == null) SickDayCalc = new SickDayCalcInfo(true);
            if (VacationCalc == null) VacationCalc = new VacationCalcInfo(true, TotalSI._CALC_VER);
            if (WorkPayCalc == null) WorkPayCalc = new WorkPayCalcTInfo(true);
            if (CalcR == null) CalcR = new CalcRInfo(true, TotalSI._CALC_VER);
            if (BonusCalc == null) BonusCalc = new BonusCalcInfo(CalcR, (KlonsADataSet.SALARY_PLUSMINUSRow[])null, true);
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
