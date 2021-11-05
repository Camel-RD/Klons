using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KlonsA.DataSets;
using KlonsLIB.Misc;
using KlonsLIB.Data;

namespace KlonsA.Classes
{
    public class WorkPayCalcInfo
    {
        public static KlonsData MyData => KlonsData.St;

        public bool PreparingReport = false;
        public SalaryInfo TotalRow = null;

        public List<SalaryInfo> ReportRows = null;
        public List<WorkPayCalcJoinRow> JoinRows = null;

        public string PositionTitle = null;
        public bool AvPayCalcRequired = false;

        public AvPayCalcInfo AvPayCalc = null;
        public bool IsAvPayCalcDone = false;
        public decimal AvPayRateHour = 0.0M;
        public decimal AvPayRateDay = 0.0M;
        public decimal AvPayRateCalendarDay = 0.0M;

        public WorkPayCalcInfo(bool filllist)
        {
            TotalRow = new SalaryInfo();
            PreparingReport = filllist;
            if (PreparingReport)
            {
                ReportRows = new List<SalaryInfo>();
                JoinRows = new List<WorkPayCalcJoinRow>();
            }
        }

        public void CalcWorkPay(SalarySheetRowInfo sr, SalaryInfo si = null)
        {
            if (sr.Row.XType == ESalarySheetRowType.Total)
                throw new Exception("Bad idea.");

            var dt1 = sr.SalarySheet.DT1;
            var dt2 = sr.SalarySheet.DT2;

            if (si == null) TotalRow = new SalaryInfo();
            else TotalRow = si;

            var posR = sr.PositionsR.FilterListWithDates(dt1, dt2);
            var amatirpay = new SalaryInfo[posR.LinkedPeriods.Count];

            TotalRow._CALENDAR_DAYS = sr.SalarySheet.CalendarMonth.DaysInMonth;
            TotalRow._CALENDAR_DAYS_USE = sr.CountCalendarDays();

            sr.DLRows.CountPlanMonth(TotalRow, sr.SalarySheet.MDT1, sr.SalarySheet.MDT2);
            sr.DLRows.CountPlan(TotalRow, sr.SalarySheet.MDT1, sr.SalarySheet.MDT2);

            PeriodInfo amats_hf;
            if (!sr.Events.Positions.TryGetValue(sr.Row.IDAM, out amats_hf))
                throw new Exception("Bad init.");
            amats_hf = amats_hf.FilterListWithDates(dt1, dt2);

            for (int i = 0; i < amatirpay.Length; i++)
            {
                var ari_x = posR.LinkedPeriods[i];
                var ari_l = ari_x.FilterThisWithList(amats_hf);

                if (ari_l.LinkedPeriods.Count == 0) continue;

                var wt = new SalaryInfo();
                amatirpay[i] = wt;

                for (int j = 0; j < ari_l.LinkedPeriods.Count; j++)
                {
                    var ari = ari_l.LinkedPeriods[j];
                    sr.DLRows.CountPlan(wt, ari.DateFirst, ari.DateLast);
                    sr.DLRows.CountFact(wt, ari.DateFirst, ari.DateLast);
                }

                var dr_amati_r = ari_x.Item1 as KlonsADataSet.POSITIONS_RRow;

                switch (dr_amati_r.XRateType)
                {
                    case ESalaryType.Month:
                    case ESalaryType.Day:
                        wt.GetRateDefs(dr_amati_r, TotalRow._MONTH_WORKDAYS, TotalRow._MONTH_WORKHOURS);
                        CalcPayWithDayRate(wt, dr_amati_r);
                        break;
                    case ESalaryType.Hour:
                        wt.GetRateDefs(dr_amati_r, TotalRow._MONTH_WORKDAYS, TotalRow._MONTH_WORKHOURS);
                        CalcPayWithHourRate(wt, dr_amati_r);
                        break;
                    case ESalaryType.Aggregated:
                        wt.GetRateDefs(dr_amati_r, TotalRow._MONTH_WORKDAYS, TotalRow._MONTH_WORKHOURS);
                        CalcPayWithoutAvPay(wt, dr_amati_r);
                        AvPayCalcRequired = true;
                        break;
                    case ESalaryType.Piece:
                        CalcPayWithoutAvPay(wt, dr_amati_r);
                        AvPayCalcRequired = true;
                        break;
                }

                wt._SALARY = wt.SumSalary();

                if (PreparingReport)
                {
                    ReportRows.Add(wt);
                    var dtr1 = ari_l.LinkedPeriods[0].DateFirst;
                    var dtr2 = ari_l.LinkedPeriods[ari_l.LinkedPeriods.Count - 1].DateLast;
                    var jr = new WorkPayCalcJoinRow();
                    jr.DateStart = dtr1;
                    jr.DateEnd = dtr2;
                    JoinRows.Add(jr);
                }

                TotalRow.AddWorkTime(wt);
                TotalRow.AddSalary(wt);
            }

            TotalRow._SALARY_PIECEWORK = CalcPieceWorkPay(dt1, dt2, sr.Row.IDAM);

            TotalRow.PlanedWorkPay = KlonsData.RoundA(TotalRow.PlanedWorkPay, 2);

            TotalRow._SALARY_DAY = KlonsData.RoundA(TotalRow._SALARY_DAY, 2);
            TotalRow._SALARY_NIGHT = KlonsData.RoundA(TotalRow._SALARY_NIGHT, 2);
            TotalRow._SALARY_OVERTIME = KlonsData.RoundA(TotalRow._SALARY_OVERTIME, 2);
            TotalRow._SALARY_HOLIDAYS_DAY = KlonsData.RoundA(TotalRow._SALARY_HOLIDAYS_DAY, 2);
            TotalRow._SALARY_HOLIDAYS_NIGHT = KlonsData.RoundA(TotalRow._SALARY_HOLIDAYS_NIGHT, 2);
            TotalRow._SALARY_HOLIDAYS_OVERTIME = KlonsData.RoundA(TotalRow._SALARY_HOLIDAYS_OVERTIME, 2);
            TotalRow._SALARY_AVPAY_FREE_DAYS = KlonsData.RoundA(TotalRow._SALARY_AVPAY_FREE_DAYS, 2);
            TotalRow._SALARY_AVPAY_WORK_DAYS = KlonsData.RoundA(TotalRow._SALARY_AVPAY_WORK_DAYS, 2);
            TotalRow._SALARY_AVPAY_WORK_DAYS_OVERTIME = KlonsData.RoundA(TotalRow._SALARY_AVPAY_WORK_DAYS_OVERTIME, 2);
            TotalRow._SALARY_AVPAY_HOLIDAYS = KlonsData.RoundA(TotalRow._SALARY_AVPAY_HOLIDAYS, 2);
            TotalRow._SALARY_AVPAY_HOLIDAYS_OVERTIME = KlonsData.RoundA(TotalRow._SALARY_AVPAY_HOLIDAYS_OVERTIME, 2);

            TotalRow._SALARY = TotalRow.SumSalary();
            TotalRow.SumForAvPay();

            if (PreparingReport && !AvPayCalcRequired) PrepareList(sr.GetPositionTitle());
        }

        public void CalcPayWithDayRate(SalaryInfo wt, KlonsADataSet.POSITIONS_RRow dr_amati_r)
        {
            wt.PlanedWorkPay = wt.R_HR * (decimal)wt._PLAN_DAYS;
            wt._SALARY_DAY = wt.R_HR * (decimal)wt._FACT_WORK_DAYS;
            wt._SALARY_NIGHT = wt.R_HR_NIGHT * (decimal)wt._FACT_WORK_HOURS_NIGHT;
            wt._SALARY_OVERTIME = wt.R_HR_OVERTIME * (decimal)wt._FACT_WORK_HOURS_OVERTIME;

            wt._SALARY_HOLIDAYS_DAY = wt.R_HR_HOLIDAY * (decimal)wt._FACT_HOLIDAYS_DAYS;
            wt._SALARY_HOLIDAYS_NIGHT = wt.R_HR_HOLIDAY_NIGHT * (decimal)wt._FACT_HOLIDAYS_HOURS_NIGHT;
            wt._SALARY_HOLIDAYS_OVERTIME = wt.R_HR_HOLIDAY_OVERTIME * (decimal)wt._FACT_HOLIDAYS_HOURS_OVERTIME;

            wt._SALARY_AVPAY_FREE_DAYS = wt.R_HR * (decimal)wt._FACT_AVPAY_FREE_DAYS;

            wt._SALARY_AVPAY_WORK_DAYS = wt.R_HR * (decimal)wt._FACT_AVPAY_WORK_DAYS;
            wt._SALARY_AVPAY_WORK_DAYS_OVERTIME = wt.R_HR_OVERTIME * (decimal)wt._FACT_AVPAY_HOURS_OVERTIME;
            wt._SALARY_AVPAY_HOLIDAYS = wt.R_HR_HOLIDAY * (decimal)wt._FACT_AVPAY_WORKINHOLIDAYS;
            wt._SALARY_AVPAY_HOLIDAYS_OVERTIME = wt.R_HR_HOLIDAY_OVERTIME * (decimal)wt._FACT_AVPAY_HOLIDAYS_HOURS_OVERT;
        }

        public void CalcPayWithHourRate(SalaryInfo wt, KlonsADataSet.POSITIONS_RRow dr_amati_r)
        {
            wt.PlanedWorkPay = wt.R_HR * (decimal)wt._PLAN_HOURS;
            wt._SALARY_DAY = wt.R_HR * (decimal)wt._FACT_WORK_HOURS;
            wt._SALARY_NIGHT = wt.R_HR_NIGHT * (decimal)wt._FACT_WORK_HOURS_NIGHT;
            wt._SALARY_OVERTIME = wt.R_HR_OVERTIME * (decimal)wt._FACT_WORK_HOURS_OVERTIME;

            wt._SALARY_HOLIDAYS_DAY = wt.R_HR_HOLIDAY * (decimal)wt._FACT_HOLIDAYS_HOURS;
            wt._SALARY_HOLIDAYS_NIGHT = wt.R_HR_HOLIDAY_NIGHT * (decimal)wt._FACT_HOLIDAYS_HOURS_NIGHT;
            wt._SALARY_HOLIDAYS_OVERTIME = wt.R_HR_HOLIDAY_OVERTIME * (decimal)wt._FACT_HOLIDAYS_HOURS_OVERTIME;

            wt._SALARY_AVPAY_FREE_DAYS = wt.R_HR * (decimal)wt._FACT_AVPAY_FREE_HOURS;
            wt._SALARY_AVPAY_WORK_DAYS = wt.R_HR * (decimal)wt._FACT_AVPAY_HOURS;
            wt._SALARY_AVPAY_WORK_DAYS_OVERTIME = wt.R_HR_OVERTIME * (decimal)wt._FACT_AVPAY_HOURS_OVERTIME;
            wt._SALARY_AVPAY_HOLIDAYS = wt.R_HR_HOLIDAY * (decimal)wt._FACT_AVPAY_HOLIDAYS_HOURS;
            wt._SALARY_AVPAY_HOLIDAYS_OVERTIME = wt.R_HR_HOLIDAY_OVERTIME * (decimal)wt._FACT_AVPAY_HOLIDAYS_HOURS_OVERT;
        }

        //calc done through DoAvPay
        //wt._R_HR not set?
        public void CalcPayWithoutAvPay(SalaryInfo wt, KlonsADataSet.POSITIONS_RRow dr_amati_r)
        {
            wt.PlanedWorkPay = wt.R_HR * (decimal)wt._PLAN_HOURS;
            wt._SALARY_DAY = wt.R_HR * (decimal)wt._FACT_WORK_HOURS;
            wt._SALARY_NIGHT = wt.R_HR_NIGHT * (decimal)wt._FACT_WORK_HOURS_NIGHT;
            wt._SALARY_OVERTIME = wt.R_HR_OVERTIME * (decimal)wt._FACT_WORK_HOURS_OVERTIME;

            wt._SALARY_HOLIDAYS_DAY = wt.R_HR_HOLIDAY * (decimal)wt._FACT_HOLIDAYS_HOURS;
            wt._SALARY_HOLIDAYS_NIGHT = wt.R_HR_HOLIDAY_NIGHT * (decimal)wt._FACT_HOLIDAYS_HOURS_NIGHT;
            wt._SALARY_HOLIDAYS_OVERTIME = wt.R_HR_HOLIDAY_OVERTIME * (decimal)wt._FACT_HOLIDAYS_HOURS_OVERTIME;

            wt.FACT_AVPAY_FREE_DAYS_2 = wt._FACT_AVPAY_FREE_DAYS;
            wt.FACT_AVPAY_FREE_HOURS_2 = wt._FACT_AVPAY_FREE_HOURS;
            wt.FACT_AVPAY_WORK_DAYS_2 = wt._FACT_AVPAY_WORK_DAYS;
            wt.FACT_AVPAY_WORKINHOLIDAYS_2 = wt._FACT_AVPAY_WORKINHOLIDAYS;
            wt.FACT_AVPAY_HOURS_2 = wt._FACT_AVPAY_HOURS;
            wt.FACT_AVPAY_HOURS_OVERTIME_2 = wt._FACT_AVPAY_HOURS_OVERTIME;
            wt.FACT_AVPAY_HOLIDAYS_HOURS_2 = wt._FACT_AVPAY_HOLIDAYS_HOURS;
            wt.FACT_AVPAY_HOLIDAYS_HOURS_OVERT_2 = wt._FACT_AVPAY_HOLIDAYS_HOURS_OVERT;
        }

        public decimal CalcPieceWorkPay(DateTime dt1, DateTime dt2, int idam)
        {
            var table_gbd = MyData.DataSetKlons.PIECEWORK;
            var d = table_gbd.WhereX(
                r =>
                r.IDA == idam &&
                r.DT >= dt1 &&
                r.DT <= dt2
            ).Sum(r => r.PAY);
            return d;
        }

        public ErrorList CalcPayWithAvPay(SalarySheetRowInfo sr, SalaryInfo totalwt = null)
        {
            var err = DoAvPay(sr, TotalRow, totalwt);
            if (err.HasErrors) return err;

            if (PreparingReport)
            {
                foreach(var rr in ReportRows)
                    DoAvPay(sr, rr, totalwt);
            }

            TotalRow._SALARY = TotalRow.SumSalary();
            TotalRow.AddAvPay();

            if (PreparingReport) PrepareList(sr.GetPositionTitle());

            return err;
        }

        public bool IsAggregatedTimeRate(SalarySheetRowInfo sr)
        {
            var posr = sr.PositionsR.LinkedPeriods[0].Item1 as KlonsADataSet.POSITIONS_RRow;
            return posr.XRateType == ESalaryType.Aggregated;
        }

        public ErrorList DoAvPay(SalarySheetRowInfo sr, SalaryInfo wt, SalaryInfo totalwt = null)
        {
            var err = GatAvPay(sr);
            if (err.HasErrors) return err;

            decimal _AvPayRate = AvPayRateDay;
            if (IsAggregatedTimeRate(sr)) _AvPayRate = AvPayRateCalendarDay;

            if (totalwt == null)
            {
                decimal rateo = wt.R_MT_OVERTIME / 100.0M;
                decimal rateh = wt.R_MT_HOLIDAY / 100.0M;
                decimal rateho = wt.R_MT_HOLIDAY_OVERTIME / 100.0M;

                wt._SALARY_AVPAY_FREE_DAYS += _AvPayRate * (decimal)wt.FACT_AVPAY_FREE_DAYS_2;

                wt._SALARY_AVPAY_WORK_DAYS += _AvPayRate * (decimal)wt.FACT_AVPAY_WORK_DAYS_2;
                wt._SALARY_AVPAY_WORK_DAYS_OVERTIME += _AvPayRate * rateo * (decimal)wt.FACT_AVPAY_HOURS_OVERTIME_2;
                wt._SALARY_AVPAY_HOLIDAYS += _AvPayRate * rateh * (decimal)wt.FACT_AVPAY_WORKINHOLIDAYS_2;
                wt._SALARY_AVPAY_HOLIDAYS_OVERTIME += _AvPayRate * rateho * (decimal)wt.FACT_AVPAY_HOLIDAYS_HOURS_OVERT_2;
            }
            else
            {
                if (wt.FACT_AVPAY_FREE_HOURS_2 > 0.0f)
                    wt._SALARY_AVPAY_FREE_DAYS += 
                        (decimal)wt.FACT_AVPAY_FREE_HOURS_2 / 
                        (decimal)totalwt.FACT_AVPAY_FREE_HOURS_2 * 
                        totalwt._SALARY_AVPAY_FREE_DAYS;

                if (wt.FACT_AVPAY_HOURS_2 > 0.0f)
                    wt._SALARY_AVPAY_WORK_DAYS += 
                        (decimal)wt.FACT_AVPAY_HOURS_2 / 
                        (decimal)totalwt.FACT_AVPAY_HOURS_2 * 
                        totalwt._SALARY_AVPAY_WORK_DAYS;

                if (wt.FACT_AVPAY_HOURS_OVERTIME_2 > 0.0f)
                    wt._SALARY_AVPAY_WORK_DAYS_OVERTIME += 
                        (decimal)wt.FACT_AVPAY_HOURS_OVERTIME_2 /
                        (decimal)totalwt.FACT_AVPAY_HOURS_OVERTIME_2 * 
                        totalwt._SALARY_AVPAY_WORK_DAYS_OVERTIME;

                if (wt.FACT_AVPAY_HOLIDAYS_HOURS_2 > 0.0f)
                    wt._SALARY_AVPAY_HOLIDAYS += 
                        (decimal)wt.FACT_AVPAY_HOLIDAYS_HOURS_2 / 
                        (decimal)totalwt.FACT_AVPAY_HOLIDAYS_HOURS_2 * 
                        totalwt._SALARY_AVPAY_HOLIDAYS;

                if (wt.FACT_AVPAY_HOLIDAYS_HOURS_OVERT_2 > 0.0f)
                    wt._SALARY_AVPAY_HOLIDAYS_OVERTIME += 
                        (decimal)wt.FACT_AVPAY_HOLIDAYS_HOURS_OVERT_2 / 
                        (decimal)totalwt.FACT_AVPAY_HOLIDAYS_HOURS_OVERT_2 * 
                        totalwt._SALARY_AVPAY_HOLIDAYS_OVERTIME;
            }

            wt._SALARY_AVPAY_FREE_DAYS = KlonsData.RoundA(wt._SALARY_AVPAY_FREE_DAYS, 2);
            wt._SALARY_AVPAY_WORK_DAYS = KlonsData.RoundA(wt._SALARY_AVPAY_WORK_DAYS, 2);
            wt._SALARY_AVPAY_WORK_DAYS_OVERTIME = KlonsData.RoundA(wt._SALARY_AVPAY_WORK_DAYS_OVERTIME, 2);
            wt._SALARY_AVPAY_HOLIDAYS = KlonsData.RoundA(wt._SALARY_AVPAY_HOLIDAYS, 2);
            wt._SALARY_AVPAY_HOLIDAYS_OVERTIME = KlonsData.RoundA(wt._SALARY_AVPAY_HOLIDAYS_OVERTIME, 2);

            wt._SALARY = wt.SumSalary();
            return err;
        }


        public decimal GetRate(decimal baserate, short ratetype, decimal aplyrate)
        {
            if (ratetype == 0) return aplyrate;
            return baserate * aplyrate / 100.0M;
        }

        public void SetAvPayFrom(SalaryCalcInfo sc)
        {
            if (sc.AvPayCalc != null) AvPayCalc = sc.AvPayCalc;
            if (IsAvPayCalcDone) return;
            IsAvPayCalcDone = sc.IsAvPayCalcDone;
            AvPayRateHour = sc.AvPayRateHour;
            AvPayRateDay = sc.AvPayRateDay;
            AvPayRateCalendarDay = sc.AvPayRateCalendarDay;
        }

        public void SetAvPayTo(SalaryCalcInfo sc)
        {
            if (!IsAvPayCalcDone) return;
            sc.SetAvPayFrom(AvPayCalc, AvPayRateHour, AvPayRateDay, AvPayRateCalendarDay);
        }

        public void SetAvPayFrom(SalaryCalcTInfo sc)
        {
            if (sc.AvPayCalc != null) AvPayCalc = sc.AvPayCalc;
            if (IsAvPayCalcDone) return;
            IsAvPayCalcDone = sc.IsAvPayCalcDone;
            AvPayRateHour = sc.AvPayRateHour;
            AvPayRateDay = sc.AvPayRateDay;
            AvPayRateCalendarDay = sc.AvPayRateCalendarDay;
        }

        public void SetAvPayTo(SalaryCalcTInfo sc)
        {
            if (!IsAvPayCalcDone) return;
            sc.SetAvPayFrom(AvPayCalc, AvPayRateHour, AvPayRateDay, AvPayRateCalendarDay);
        }

        public ErrorList GatAvPay(SalarySheetRowInfo sr)
        {
            if (IsAvPayCalcDone) return new ErrorList();
            AvPayCalc = new AvPayCalcInfo(PreparingReport);
            var err = AvPayCalc.CalcList(sr);
            if (err.HasErrors) return err;
            IsAvPayCalcDone = true;
            AvPayRateHour = AvPayCalc.RateHour;
            AvPayRateDay = AvPayCalc.RateDay;
            AvPayRateCalendarDay = AvPayCalc.RateCalendarDay;
            return new ErrorList();
        }

        public void PrepareList(string postitle)
        {
            for (int i = 0; i < ReportRows.Count; i++)
            {
                var r = ReportRows[i];
                var jr = JoinRows[i];
                jr.Caption = string.Format("{0:dd.MM.yyyy} - {1:dd.MM.yyyy}", jr.DateStart, jr.DateEnd);
            }
            if (ReportRows.Count > 1)
            {
                ReportRows.Add(TotalRow);
                var tjr = new WorkPayCalcJoinRow();
                tjr.Caption = "Kopā";
                tjr.IsTotal = true;
                JoinRows.Add(tjr);
            }
        }

        public List<WorkPayCalcRow1> GetRows2()
        {
            var ret = new List<WorkPayCalcRow1>();
            for (int i = 0; i < ReportRows.Count; i++)
            {
                var r = ReportRows[i];
                var jr = JoinRows[i];
                var wr = new WorkPayCalcRow2();
                wr.SetFrom(r);
                ret.Add(new WorkPayCalcRow1(jr.Caption) {IsTitle = true});
                if (!jr.IsTitle)
                    wr.AddToList(ret);
            }
            return ret;
        }

    }

    public class WorkPayCalcJoinRow
    {
        public bool IsTotal = false;
        public bool IsTitle = false;
        public string Caption { get; set; } = "";
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }

    public class WorkPayCalcRow1
    {
        public static WorkPayCalcRow1 Empty = new WorkPayCalcRow1();

        public bool IsTotal { get; set; } = false;
        public bool IsTitle { get; set; } = false;
        public string Caption { get; set; } = "";
        public decimal RateDef { get; set; } = 0.0M;
        public string RateType { get; set; } = "";
        public decimal Rate { get; set; } = 0.0M;
        public int Days { get; set; } = 0;
        public float Hours { get; set; } = 0.0f;
        public decimal Salary { get; set; } = 0.0M;

        public WorkPayCalcRow1()
        {

        }
        public WorkPayCalcRow1(string caption)
        {
            Caption = caption;
        }

        public bool HasData()
        {
            return Days != 0 || Hours != 0.0f;
        }
    }

    public class WorkPayCalcRow2
    {
        public WorkPayCalcRow1 SALARY = new WorkPayCalcRow1("Kopā");
        public WorkPayCalcRow1 SALARY_DAY = new WorkPayCalcRow1("Ar pamatlikmi");
        public WorkPayCalcRow1 SALARY_NIGHT = new WorkPayCalcRow1(" + nakts darbs");
        public WorkPayCalcRow1 SALARY_OVERTIME = new WorkPayCalcRow1(" + virsstundas");
        public WorkPayCalcRow1 SALARY_HOLIDAYS_DAY = new WorkPayCalcRow1(" + svētku dienas");
        public WorkPayCalcRow1 SALARY_HOLIDAYS_NIGHT = new WorkPayCalcRow1("  + nakts darbs");
        public WorkPayCalcRow1 SALARY_HOLIDAYS_OVERTIME = new WorkPayCalcRow1("  + virsstundas");

        public WorkPayCalcRow1 SALARY_AVPAY_FREE_DAYS = new WorkPayCalcRow1("Attaisnots kavējums");
        public WorkPayCalcRow1 SALARY_AVPAY_WORK_DAYS = new WorkPayCalcRow1("Darba d. ar VI");
        public WorkPayCalcRow1 SALARY_AVPAY_WORK_DAYS_OVERTIME = new WorkPayCalcRow1(" + virsstundas");
        public WorkPayCalcRow1 SALARY_AVPAY_HOLIDAYS = new WorkPayCalcRow1(" + svētku dienas");
        public WorkPayCalcRow1 SALARY_AVPAY_HOLIDAYS_OVERTIME = new WorkPayCalcRow1("  + virsstundas");


        private string RateType(Int16 tp)
        {
            return tp == 0 ? "%": "€";
        }

        public void AddToList(List<WorkPayCalcRow1> list)
        {
            if (SALARY.HasData()) list.Add(SALARY);
            if (SALARY_DAY.HasData()) list.Add(SALARY_DAY);
            if (SALARY_NIGHT.HasData()) list.Add(SALARY_NIGHT);
            if (SALARY_OVERTIME.HasData()) list.Add(SALARY_OVERTIME);
            if (SALARY_HOLIDAYS_DAY.HasData()) list.Add(SALARY_HOLIDAYS_DAY);
            if (SALARY_HOLIDAYS_NIGHT.HasData()) list.Add(SALARY_HOLIDAYS_NIGHT);
            if (SALARY_HOLIDAYS_OVERTIME.HasData()) list.Add(SALARY_HOLIDAYS_OVERTIME);

            if (SALARY_AVPAY_FREE_DAYS.HasData()) list.Add(SALARY_AVPAY_FREE_DAYS);
            if (SALARY_AVPAY_WORK_DAYS.HasData()) list.Add(SALARY_AVPAY_WORK_DAYS);
            if (SALARY_AVPAY_WORK_DAYS_OVERTIME.HasData()) list.Add(SALARY_AVPAY_WORK_DAYS_OVERTIME);
            if (SALARY_AVPAY_HOLIDAYS.HasData()) list.Add(SALARY_AVPAY_HOLIDAYS);
            if (SALARY_AVPAY_HOLIDAYS_OVERTIME.HasData()) list.Add(SALARY_AVPAY_HOLIDAYS_OVERTIME);
        }

        public void SetFrom(SalaryInfo si)
        {
            SALARY.Days = si._FACT_DAYS;
            SALARY.Hours = si._FACT_HOURS;
            SALARY.Salary = si._SALARY;

            SALARY_DAY.Days = si._FACT_WORK_DAYS;
            SALARY_DAY.Hours = si._FACT_WORK_HOURS;
            SALARY_DAY.RateDef = si.R_MT;
            SALARY_DAY.Rate = si.R_HR;
            SALARY_DAY.Salary = si._SALARY_DAY;

            SALARY_NIGHT.Hours = si._FACT_WORK_HOURS_NIGHT;
            SALARY_NIGHT.RateDef = si.R_MT_NIGHT;
            SALARY_NIGHT.RateType = RateType(si.R_MT_NIGHT_TYPE);
            SALARY_NIGHT.Rate = si.R_HR_NIGHT;
            SALARY_NIGHT.Salary = si._SALARY_NIGHT;

            SALARY_OVERTIME.Hours = si._FACT_WORK_HOURS_OVERTIME;
            SALARY_OVERTIME.RateDef = si.R_MT_OVERTIME;
            SALARY_OVERTIME.RateType = RateType(si.R_MT_OVERTIME_TYPE);
            SALARY_OVERTIME.Rate = si.R_HR_OVERTIME;
            SALARY_OVERTIME.Salary = si._SALARY_OVERTIME;

            SALARY_HOLIDAYS_DAY.Days = si._FACT_HOLIDAYS_DAYS;
            SALARY_HOLIDAYS_DAY.Hours = si._FACT_HOLIDAYS_HOURS;
            SALARY_HOLIDAYS_DAY.RateDef = si.R_MT_HOLIDAY;
            SALARY_HOLIDAYS_DAY.RateType = RateType(si.R_MT_HOLIDAY_TYPE);
            SALARY_HOLIDAYS_DAY.Rate = si.R_HR_HOLIDAY;
            SALARY_HOLIDAYS_DAY.Salary = si._SALARY_HOLIDAYS_DAY;

            SALARY_HOLIDAYS_NIGHT.Hours = si._FACT_HOLIDAYS_HOURS_NIGHT;
            SALARY_HOLIDAYS_NIGHT.RateDef = si.R_MT_HOLIDAY_NIGHT;
            SALARY_HOLIDAYS_NIGHT.RateType = RateType(si.R_MT_HOLIDAY_NIGHT_TYPE);
            SALARY_HOLIDAYS_NIGHT.Rate = si.R_HR_HOLIDAY_NIGHT;
            SALARY_HOLIDAYS_NIGHT.Salary = si._SALARY_HOLIDAYS_NIGHT;

            SALARY_HOLIDAYS_OVERTIME.Hours = si._FACT_HOLIDAYS_HOURS_OVERTIME;
            SALARY_HOLIDAYS_OVERTIME.RateDef = si.R_MT_HOLIDAY_OVERTIME;
            SALARY_HOLIDAYS_OVERTIME.RateType = RateType(si.R_MT_HOLIDAY_OVERTIME_TYPE);
            SALARY_HOLIDAYS_OVERTIME.Rate = si.R_HR_HOLIDAY_OVERTIME;
            SALARY_HOLIDAYS_OVERTIME.Salary = si._SALARY_HOLIDAYS_OVERTIME;


            SALARY_AVPAY_FREE_DAYS.Days = si._FACT_AVPAY_FREE_DAYS;
            SALARY_AVPAY_FREE_DAYS.Hours = si._FACT_AVPAY_FREE_HOURS;
            SALARY_AVPAY_FREE_DAYS.RateDef = si.R_MT;
            SALARY_AVPAY_FREE_DAYS.Rate = si.R_HR;
            SALARY_AVPAY_FREE_DAYS.Salary = si._SALARY_AVPAY_FREE_DAYS;

            SALARY_AVPAY_WORK_DAYS.Days = si._FACT_AVPAY_WORK_DAYS;
            SALARY_AVPAY_WORK_DAYS.Hours = si._FACT_AVPAY_HOURS;
            SALARY_AVPAY_WORK_DAYS.RateDef = si.R_MT;
            SALARY_AVPAY_WORK_DAYS.Rate = si.R_HR;
            SALARY_AVPAY_WORK_DAYS.Salary = si._SALARY_AVPAY_WORK_DAYS;

            SALARY_AVPAY_WORK_DAYS_OVERTIME.Hours = si._FACT_AVPAY_HOURS_OVERTIME;
            SALARY_AVPAY_WORK_DAYS_OVERTIME.RateDef = si.R_MT_OVERTIME;
            SALARY_AVPAY_WORK_DAYS_OVERTIME.RateType = RateType(si.R_MT_OVERTIME_TYPE);
            SALARY_AVPAY_WORK_DAYS_OVERTIME.Rate = si.R_HR;
            SALARY_AVPAY_WORK_DAYS_OVERTIME.Salary = si._SALARY_AVPAY_WORK_DAYS_OVERTIME;

            SALARY_AVPAY_HOLIDAYS.Days = si._FACT_AVPAY_WORKINHOLIDAYS;
            SALARY_AVPAY_HOLIDAYS.Hours = si._FACT_AVPAY_HOLIDAYS_HOURS;
            SALARY_AVPAY_HOLIDAYS.RateDef = si.R_MT;
            SALARY_AVPAY_HOLIDAYS.RateType = RateType(si.R_MT_HOLIDAY_TYPE);
            SALARY_AVPAY_HOLIDAYS.Rate = si.R_HR;
            SALARY_AVPAY_HOLIDAYS.Salary = si._SALARY_AVPAY_HOLIDAYS;

            SALARY_AVPAY_HOLIDAYS_OVERTIME.Hours = si._FACT_AVPAY_HOLIDAYS_HOURS_OVERT;
            SALARY_AVPAY_HOLIDAYS_OVERTIME.RateDef = si.R_MT_HOLIDAY_OVERTIME;
            SALARY_AVPAY_HOLIDAYS_OVERTIME.RateType = RateType(si.R_MT_HOLIDAY_OVERTIME_TYPE);
            SALARY_AVPAY_HOLIDAYS_OVERTIME.Rate = si.R_HR;
            SALARY_AVPAY_HOLIDAYS_OVERTIME.Salary = si._SALARY_AVPAY_HOLIDAYS_OVERTIME;
        }
    }
}