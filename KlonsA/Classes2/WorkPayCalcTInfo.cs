using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsLIB.Misc;
using KlonsLIB.Data;

namespace KlonsA.Classes
{
    public class WorkPayCalcTInfo
    {
        public bool PreparingReport = false;
        public SalaryInfo TotalRow = null;

        public List<SalaryInfo> ReportRows = null;
        public List<WorkPayCalcJoinRow> JoinRows = null;

        public WorkPayCalcInfo[] LinkedWorkPayCalcs = null;
        public string PositionTitle = null;
        public bool AvPayCalcRequired = false;

        public AvPayCalcInfo AvPayCalc = null;
        public bool IsAvPayCalcDone = false;
        public decimal AvPayRateHour = 0.0M;
        public decimal AvPayRateDay = 0.0M;
        public decimal AvPayRateCalendarDay = 0.0M;

        public WorkPayCalcTInfo(bool filllist)
        {
            TotalRow = new SalaryInfo();
            PreparingReport = filllist;
            if (PreparingReport)
            {
                ReportRows = new List<SalaryInfo>();
                JoinRows = new List<WorkPayCalcJoinRow>();
            }
        }

        public void CalcWorkPayT(SalaryCalcTInfo scti)
        {
            TotalRow = scti.TotalSI;
            var sr = scti.SRS;

            TotalRow._CALENDAR_DAYS = sr.SalarySheet.CalendarMonth.DaysInMonth;
            TotalRow._CALENDAR_DAYS_USE = sr.CountCalendarDays();

            var dlrowlist = sr.GetDLRowSetList();

            dlrowlist.CountPlanMonth(TotalRow, sr.SalarySheet.MDT1, sr.SalarySheet.MDT2);
            dlrowlist.CountTotalPlan(TotalRow, sr.SalarySheet.MDT1, sr.SalarySheet.MDT2);
            dlrowlist.CountTotalFact(TotalRow, sr.SalarySheet.MDT1, sr.SalarySheet.MDT2);

            LinkedWorkPayCalcs = new WorkPayCalcInfo[scti.LinkedSCI.Length];

            for (int i = 0; i < scti.LinkedSCI.Length; i++)
            {
                var lsci = scti.LinkedSCI[i];
                var wpc = new WorkPayCalcInfo(PreparingReport);
                wpc.CalcWorkPay(lsci.SR, lsci.SI);
                TotalRow.AddSalary(lsci.SI);

                if (wpc.AvPayCalcRequired) AvPayCalcRequired = true;
                lsci.WorkPayCalc = wpc;
                wpc.PositionTitle = lsci.SR.GetPositionTitle();
                LinkedWorkPayCalcs[i] = wpc;
            }

            TotalRow._SALARY = TotalRow.SumSalary();
            TotalRow.SumForAvPay();

            if (PreparingReport && !AvPayCalcRequired) PrepareListT();
        }

        public ErrorList CalcWorkPayTAvPay(SalaryCalcTInfo scti)
        {
            if (!AvPayCalcRequired) return new ErrorList();
            TotalRow = scti.TotalSI;
            //TotalRow.ClearSalaryAvPayPart();
            scti.LinkedSCI[0].WorkPayCalc.DoAvPay(scti.SRS.TotalRow, TotalRow, null);
            for (int i = 0; i < scti.LinkedSCI.Length; i++)
            {
                var lsci = scti.LinkedSCI[i];
                var wpc = LinkedWorkPayCalcs[i];
                wpc.TotalRow = lsci.SI;

                var err = wpc.CalcPayWithAvPay(lsci.SR, TotalRow);
                if (err.HasErrors) return err;

                //TotalRow.AddSalaryAvPayPart(wpc.TotalRow);
            }

            TotalRow._SALARY = TotalRow.SumSalary();
            TotalRow.AddAvPay();

            MakeAvPayExactSum();

            if (PreparingReport) PrepareListT();
            return new ErrorList();
        }

        private void MakeAvPayExactSum()
        {
            Utils.MakeExactSum(TotalRow._SALARY_AVPAY_FREE_DAYS, LinkedWorkPayCalcs,
                d => d.TotalRow._SALARY_AVPAY_FREE_DAYS,
                (d, val) => d.TotalRow._SALARY_AVPAY_FREE_DAYS = val);

            Utils.MakeExactSum(TotalRow._SALARY_AVPAY_WORK_DAYS, LinkedWorkPayCalcs,
                d => d.TotalRow._SALARY_AVPAY_WORK_DAYS,
                (d, val) => d.TotalRow._SALARY_AVPAY_WORK_DAYS = val);

            Utils.MakeExactSum(TotalRow._SALARY_AVPAY_WORK_DAYS_OVERTIME, LinkedWorkPayCalcs,
                d => d.TotalRow._SALARY_AVPAY_WORK_DAYS_OVERTIME,
                (d, val) => d.TotalRow._SALARY_AVPAY_WORK_DAYS_OVERTIME = val);

            Utils.MakeExactSum(TotalRow._SALARY_AVPAY_HOLIDAYS, LinkedWorkPayCalcs,
                d => d.TotalRow._SALARY_AVPAY_HOLIDAYS,
                (d, val) => d.TotalRow._SALARY_AVPAY_HOLIDAYS = val);

            Utils.MakeExactSum(TotalRow._SALARY_AVPAY_HOLIDAYS_OVERTIME, LinkedWorkPayCalcs,
                d => d.TotalRow._SALARY_AVPAY_HOLIDAYS_OVERTIME,
                (d, val) => d.TotalRow._SALARY_AVPAY_HOLIDAYS_OVERTIME = val);
        }

        // used only for making report
        public void CalcWorkPay(SalarySheetRowSetInfo sr, SalaryInfo si = null)
        {
            var dt1 = sr.SalarySheet.DT1;
            var dt2 = sr.SalarySheet.DT2;

            if (si == null) TotalRow = new SalaryInfo();
            else TotalRow = si;

            TotalRow._CALENDAR_DAYS = sr.SalarySheet.CalendarMonth.DaysInMonth;
            TotalRow._CALENDAR_DAYS_USE = sr.CountCalendarDays();

            var dlrowlist = sr.GetDLRowSetList();

            dlrowlist.CountPlanMonth(TotalRow, sr.SalarySheet.MDT1, sr.SalarySheet.MDT2);
            dlrowlist.CountTotalPlan(TotalRow, sr.SalarySheet.MDT1, sr.SalarySheet.MDT2);
            dlrowlist.CountTotalFact(TotalRow, sr.SalarySheet.MDT1, sr.SalarySheet.MDT2);

            LinkedWorkPayCalcs = new WorkPayCalcInfo[sr.LinkedRows.Length];

            for (int i = 0; i < sr.LinkedRows.Length; i++)
            {
                var lr = sr.LinkedRows[i];

                var si2 = new SalaryInfo();
                var wpc = new WorkPayCalcInfo(PreparingReport);

                wpc.CalcWorkPay(lr, si2);
                TotalRow.AddSalary(si2);

                if (wpc.AvPayCalcRequired) AvPayCalcRequired = true;

                wpc.PositionTitle = lr.GetPositionTitle();
                LinkedWorkPayCalcs[i] = wpc;
            }

            TotalRow._SALARY = TotalRow.SumSalary();
            TotalRow.SumForAvPay();

            if (PreparingReport && !AvPayCalcRequired) PrepareListT();

            if (AvPayCalcRequired)
                CalcWorkPayAvPay(sr, TotalRow);
        }

        private void CalcWorkPayAvPay(SalarySheetRowSetInfo sr, SalaryInfo si)
        {
            TotalRow = si;
            for (int i = 0; i < sr.LinkedRows.Length; i++)
            {
                var lr = sr.LinkedRows[i];
                var wpc = LinkedWorkPayCalcs[i];
                wpc.CalcPayWithAvPay(lr, TotalRow);
                TotalRow.AddSalaryAvPayPart(wpc.TotalRow);
            }

            TotalRow._SALARY = TotalRow.SumSalary();
            TotalRow.AddAvPay();

            if (PreparingReport && !AvPayCalcRequired) PrepareListT();
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

        public void PrepareListT()
        {
            if(LinkedWorkPayCalcs.Length == 1)
            {
                var w0 = LinkedWorkPayCalcs[0];
                w0.PrepareList(w0.PositionTitle);
                ReportRows = w0.ReportRows;
                JoinRows = w0.JoinRows;
                return;
            }

            ReportRows.Add(TotalRow);
            var tjr = new WorkPayCalcJoinRow();
            tjr.Caption = "Kopā amati";
            JoinRows.Add(tjr);

            var emptyrow = new SalaryInfo();
            var emptyjoinrow = new WorkPayCalcJoinRow() { IsTitle = true };

            for (int i = 0; i < LinkedWorkPayCalcs.Length; i++)
            {
                ReportRows.Add(emptyrow);
                JoinRows.Add(emptyjoinrow);

                var wpc = LinkedWorkPayCalcs[i];
                var pos = wpc.PositionTitle;

                ReportRows.Add(emptyrow);
                var jr = new WorkPayCalcJoinRow();
                jr.Caption = pos;
                jr.IsTitle = true;
                JoinRows.Add(jr);

                ReportRows.AddRange(wpc.ReportRows);
                JoinRows.AddRange(wpc.JoinRows);
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
                ret.Add(new WorkPayCalcRow1(jr.Caption) { IsTitle = true });
                if (!jr.IsTitle)
                    wr.AddToList(ret);
            }
            return ret;
        }

    }

}