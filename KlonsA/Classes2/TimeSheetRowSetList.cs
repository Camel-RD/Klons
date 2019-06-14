using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using DataObjectsA;

namespace KlonsA.Classes
{
    public class TimeSheetRowSetList : List<TimeSheetRowSet>
    {

        public ErrorList CheckDays(SalaryInfo wt, DateTime dt1, DateTime dt2, int idp)
        {
            var error_list = new ErrorList();
            string errstr = string.Format("{0}.{1}", dt1.Year, dt1.Month);
            int i, j;
            int i1 = dt1.Day;
            int i2 = dt2.Day;
            EDayPlanId daycodeplan = EDayPlanId.None;
            EDayFactId daycodefact = EDayFactId.None;
            EDayPlanId daycodeplan2 = EDayPlanId.None;
            EDayFactId daycodefact2 = EDayFactId.None;
            bool iscodeset;

            for (i = i1; i <= i2; i++)
            {
                iscodeset = false;
                for (j = 0; j < this.Count; j++)
                {
                    daycodeplan = this[j].Plan.DxPlan[i - 1];
                    if (!iscodeset)
                    {
                        daycodeplan2 = daycodeplan;
                        iscodeset = true;
                        continue;
                    }
                    if (daycodeplan != daycodeplan2)
                    {
                        var errs = string.Format("{0} nesakrīt darba laika plāna dati dažādiem amatiem dienai: {1}", errstr, i);
                        error_list.AddPersonError(idp, errs);
                    }
                }
                iscodeset = false;
                for (j = 0; j < this.Count; j++)
                {
                    daycodefact = this[j].Fact.DxFact[i - 1];
                    daycodeplan = this[j].Plan.DxPlan[i - 1];
                    if (daycodefact == EDayFactId.X || daycodefact == EDayFactId.None) continue;
                    if (!iscodeset)
                    {
                        daycodefact2 = daycodefact;
                        daycodeplan2 = daycodeplan;
                        iscodeset = true;

                        if (!SomeDataDefs.CanPlanHaveFact(daycodeplan, daycodefact))
                        {
                            var errs = string.Format("{0} nekorekts faktiski nostrādās dienas kods: {1}", errstr, i);
                            error_list.AddPersonError(idp, errs);
                        }

                        continue;
                    }

                    bool b1 = SomeDataDefs.IsSickDay(daycodefact) ||
                        SomeDataDefs.IsDayVacation(daycodefact) ||
                        daycodefact == EDayFactId.V;

                    bool b2 = SomeDataDefs.IsSickDay(daycodefact2) ||
                        SomeDataDefs.IsDayVacation(daycodefact2) ||
                        daycodefact2 == EDayFactId.V;

                    if (b1 != b2)
                    {
                        var errs = string.Format("{0} nesakrīt darba laika dati dažādiem amatiem dienai: {1}", errstr, i);
                        error_list.AddPersonError(idp, errs);
                    }
                }
            }

            return error_list;
        }

        public ErrorList CountTotalPlan(IWorkTimeData wt, DateTime dt1, DateTime dt2)
        {
            var error_list = new ErrorList();
            string errstr = string.Format("{0}.{1}", dt1.Year, dt1.Month);
            int i, j;
            float vp, vpn;
            int i1 = dt1.Day;
            int i2 = dt2.Day;
            EDayPlanId daycodeplan = EDayPlanId.None;
            EDayFactId daycodefact = EDayFactId.None;

            for (i = i1; i <= i2; i++)
            {
                bool plandayadded = false;
                bool planworkdayadded = false;

                for (j = 0; j < this.Count; j++)
                {
                    var dlset = this[j];

                    daycodeplan = dlset.Plan.DxPlan[i - 1];
                    daycodefact = dlset.Fact.DxFact[i - 1];

                    if (daycodeplan == EDayPlanId.None) continue;
                    if (daycodefact == EDayFactId.None || daycodefact == EDayFactId.X) continue;

                    vp = dlset.Plan.Vx[i - 1];
                    vpn = dlset.PlanNight == null ? 0.0f : dlset.PlanNight.Vx[i - 1];

                    if (vp + vpn == 0.0f) continue;

                    if (!plandayadded)
                        wt._PLAN_DAYS++;
                    wt._PLAN_HOURS += vp;
                    wt._PLAN_HOURS_NIGHT += vpn;

                    if (SomeDataDefs.IsPlanWorkday(daycodeplan) && 
                        (SomeDataDefs.IsDayForWork(daycodefact) || daycodefact == EDayFactId.B))
                    {
                        if (!planworkdayadded)
                            wt._PLAN_WORK_DAYS++;
                        wt._PLAN_WORK_HOURS += vp;
                        wt._PLAN_WORK_HOURS_NIGHT += vpn;
                        planworkdayadded = true;
                    }

                    if (daycodeplan == EDayPlanId.DDSD)
                    {
                        if (!plandayadded)
                            wt._PLAN_HOLIDAYS_DAYS++;
                        wt._PLAN_HOLIDAYS_HOURS += vp;
                        wt._PLAN_HOLIDAYS_HOURS_NIGHT += vpn;
                    }

                    plandayadded = true;

                }
            }

            return error_list;
        }

        public void CountPlanMonth(IWorkTimeData wt, DateTime dt1, DateTime dt2)
        {
            int i, j;
            int i1 = dt1.Day;
            int i2 = dt2.Day;
            float vp;
            EDayPlanId daycodeplan;

            for (i = i1; i <= i2; i++)
            {
                bool plandayadded = false;

                for (j = 0; j < this.Count; j++)
                {
                    var dlset = this[j];

                    daycodeplan = dlset.Plan.DxPlan[i - 1];

                    if (daycodeplan == EDayPlanId.None) continue;

                    vp = dlset.Plan.Vx[i - 1];

                    if (vp == 0.0f) continue;

                    if (!plandayadded)
                        wt._MONTH_WORKDAYS++;
                    wt._MONTH_WORKHOURS += vp;

                    plandayadded = true;
                }
            }
        }

        public ErrorList CountTotalFact(IWorkTimeData wt, DateTime dt1, DateTime dt2)
        {
            var error_list = new ErrorList();
            string errstr = string.Format("{0}.{1}", dt1.Year, dt1.Month);
            int i, j;
            float v, vn, vo, vp;
            int i1 = dt1.Day;
            int i2 = dt2.Day;
            EDayPlanId daycodeplan = EDayPlanId.None;
            EDayFactId daycodefact = EDayFactId.None;

            for (i = i1; i <= i2; i++)
            {
                bool factdayadded = false;

                for (j = 0; j < this.Count; j++)
                {
                    var dlset = this[j];

                    daycodeplan = dlset.Plan.DxPlan[i - 1];
                    daycodefact = dlset.Fact.DxFact[i - 1];

                    if (daycodeplan == EDayPlanId.None) continue;
                    if (daycodefact == EDayFactId.X || daycodefact == EDayFactId.None) continue;

                    bool isFactHolidayWithBonus = daycodefact == EDayFactId.DS ||
                        daycodefact == EDayFactId.KS;
                    bool isAvPayFreeDay = daycodefact == EDayFactId.S ||
                        daycodefact == EDayFactId.V || daycodefact == EDayFactId.AM;
                    //bool isAvPayWorkDay = daycodefact == EDayFactId.K;
                    bool isAvPayWorkDay = false;
                    bool IsFactWorkDay = SomeDataDefs.IsDayForWork(daycodefact);


                    v = dlset.Fact.Vx[i - 1];
                    vn = dlset.FactNight == null ? 0.0f : dlset.FactNight.Vx[i - 1];
                    vo = dlset.FactOvertime == null ? 0.0f : dlset.FactOvertime.Vx[i - 1];
                    vp = dlset.Plan.Vx[i - 1];

                    if (v + vp == 0) continue;

                    if (isAvPayFreeDay)
                    {
                        if (vp == 0.0f) continue;
                        if (!factdayadded)
                            wt._FACT_AVPAY_FREE_DAYS++;
                        wt._FACT_AVPAY_FREE_HOURS += vp;
                        wt._FACT_HOURS += vp;

                        if (!factdayadded)
                            wt._FACT_DAYS++;

                        factdayadded = true;
                        continue;
                    }

                    if (!IsFactWorkDay) continue;
                    if (v == 0) continue;

                    wt._FACT_HOURS += v;
                    wt._FACT_HOURS_NIGHT += vn;
                    wt._FACT_HOURS_OVERTIME += vo;

                    if (isAvPayWorkDay)
                    {
                        if (!factdayadded)
                            wt._FACT_AVPAY_WORK_DAYS++;
                        wt._FACT_AVPAY_HOURS += v;
                        wt._FACT_AVPAY_HOURS_OVERTIME += vo;

                        if (isFactHolidayWithBonus)
                        {
                            if (!factdayadded)
                                wt._FACT_AVPAY_WORKINHOLIDAYS++;
                            wt._FACT_AVPAY_HOLIDAYS_HOURS += v;
                            wt._FACT_AVPAY_HOLIDAYS_HOURS_OVERT += vo;
                        }

                        if (!factdayadded)
                            wt._FACT_DAYS++;
                        factdayadded = true;
                        continue;
                    }

                    if (!factdayadded)
                        wt._FACT_WORK_DAYS++;
                    wt._FACT_WORK_HOURS += v;
                    wt._FACT_WORK_HOURS_NIGHT += vn;
                    wt._FACT_WORK_HOURS_OVERTIME += vo;

                    if (isFactHolidayWithBonus)
                    {
                        if (!factdayadded)
                            wt._FACT_HOLIDAYS_DAYS++;
                        wt._FACT_HOLIDAYS_HOURS += v;
                        wt._FACT_HOLIDAYS_HOURS_NIGHT += vn;
                        wt._FACT_HOLIDAYS_HOURS_OVERTIME += vo;
                    }

                    if (!factdayadded)
                        wt._FACT_DAYS++;
                    factdayadded = true;

                }

            }

            return error_list;
        }

        public void CountSickDays(SickDayCalcRow sdi, DateTime dt1, DateTime dt2, int skipdays)
        {
            int i1 = dt1.Day;
            int i2 = dt2.Day;
            float vp;
            EDayPlanId daycodeplan = EDayPlanId.None;
            EDayFactId daycodefact = EDayFactId.None;
            bool isPlanWorkDay;


            for (int i = i1; i <= i2; i++)
            {
                bool dayadded = false;

                for (int j = 0; j < this.Count; j++)
                {
                    var dlset = this[j];

                    daycodeplan = dlset.Plan.DxPlan[i - 1];
                    daycodefact = dlset.Fact.DxFact[i - 1];

                    if (daycodeplan == EDayPlanId.None) continue;
                    if (daycodefact == EDayFactId.X || daycodefact == EDayFactId.None) continue;

                    isPlanWorkDay = daycodeplan == EDayPlanId.DD || daycodeplan == EDayPlanId.DDSD ||
                        daycodeplan == EDayPlanId.SDDD;

                    vp = dlset.Plan.Vx[i - 1];

                    if (!isPlanWorkDay) continue;
                    if (vp == 0.0f) continue;

                    if (!dayadded)
                    {
                        skipdays++;
                        sdi.DaysCount++;
                    }
                    sdi.HoursCount += vp;

                    if (skipdays == 1)
                    {
                        if (!dayadded) sdi.DaysCount0++;
                    }
                    else if (skipdays == 2 || skipdays == 3)
                    {
                        if (!dayadded) sdi.DaysCount75++;
                        sdi.HoursCount75 += vp;
                    }
                    else if (skipdays >= 4 && skipdays <= 10)
                    {
                        if (!dayadded) sdi.DaysCount80++;
                        sdi.HoursCount80 += vp;
                    }
                    dayadded = true;

                }
            }

        }


        public int CountVacationDays(DateTime dt1, DateTime dt2)
        {
            int i1 = dt1.Day;
            int i2 = dt2.Day;
            int ret = 0;

            for (int i = i1; i <= i2; i++)
            {
                bool factdayadded = false;

                for (int j = 0; j < this.Count; j++)
                {
                    var dlset = this[j];

                    var daycodeplan = dlset.Plan.DxPlan[i - 1];
                    var daycodefact = dlset.Fact.DxFact[i - 1];

                    if (daycodeplan == EDayPlanId.None) continue;
                    if (daycodefact == EDayFactId.X || daycodefact == EDayFactId.None) continue;

                    var isPlanWorkDay = daycodeplan == EDayPlanId.DD || daycodeplan == EDayPlanId.DDSD;

                    var isFactPaidVacation = SomeDataDefs.IsDayPaidVacation(daycodefact);

                    if (!isPlanWorkDay) continue;

                    if (!factdayadded && isFactPaidVacation)
                    {
                        ret += 1;
                        factdayadded = true;
                    }

                }
            }
            return ret;
        }

        public void CountVacationTime(VacationCalcRow vcr)
        {
            int days = 0;
            float hours = 0.0f;
            CountVacationTime(vcr.DateStart, vcr.DateEnd, out days, out hours);
            vcr.Days = days;
            vcr.Hours = hours;
        }

        public void CountVacationTime(DateTime dt1, DateTime dt2, out int days, out float hours)
        {
            int i1 = dt1.Day;
            int i2 = dt2.Day;
            float vp;
            days = 0;
            hours = 0.0f;

            for (int i = i1; i <= i2; i++)
            {
                bool factdayadded = false;

                for (int j = 0; j < this.Count; j++)
                {
                    var dlset = this[j];

                    var daycodeplan = dlset.Plan.DxPlan[i - 1];
                    var daycodefact = dlset.Fact.DxFact[i - 1];

                    if (daycodeplan == EDayPlanId.None) continue;
                    if (daycodefact == EDayFactId.X || daycodefact == EDayFactId.None) continue;

                    var isPlanWorkDay = daycodeplan == EDayPlanId.DD || daycodeplan == EDayPlanId.DDSD;
                    var isFactPaidVacation = SomeDataDefs.IsDayPaidVacation(daycodefact);

                    if (!isPlanWorkDay || !isFactPaidVacation) continue;

                    vp = dlset.Plan.Vx[i - 1];

                    hours += vp;

                    if (!factdayadded)
                    {
                        days += 1;
                        factdayadded = true;
                    }

                }
            }

        }

        public EDayFactId GetFactDayCodeForAllAmati(int day)
        {
            EDayFactId ret = EDayFactId.None;
            for (int i = 1; i < this.Count; i++)
            {
                ret = this[i].Fact.DxFact[day - 1];
                if (ret != EDayFactId.X && ret != EDayFactId.None) break;
            }
            return ret;
        }


    }
}
