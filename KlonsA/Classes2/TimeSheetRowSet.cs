using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsLIB.Data;
using DataObjectsA;

namespace KlonsA.Classes
{
    public class TimeSheetRowSet
    {
        public KlonsADataSet.TIMESHEETRow Plan = null;
        public KlonsADataSet.TIMESHEETRow PlanNight = null;
        public KlonsADataSet.TIMESHEETRow Fact = null;
        public KlonsADataSet.TIMESHEETRow FactNight = null;
        public KlonsADataSet.TIMESHEETRow FactOvertime = null;

        public void CountPlan(IWorkTimeData wt, DateTime dt1, DateTime dt2)
        {
            var list = new TimeSheetRowSetList() { this };
            list.CountTotalPlan(wt, dt1, dt2);
        }

        public void CountPlanMonth(IWorkTimeData wt, DateTime dt1, DateTime dt2)
        {
            var list = new TimeSheetRowSetList() { this };
            list.CountPlanMonth(wt, dt1, dt2);
        }

        public void CountFact(IWorkTimeData wt, DateTime dt1, DateTime dt2)
        {
            var list = new TimeSheetRowSetList() { this };
            list.CountTotalFact(wt, dt1, dt2);
        }

        public void CountSickDays(SickDayCalcRow sdci, DateTime dt1, DateTime dt2, int skipdays)
        {
            var list = new TimeSheetRowSetList() { this };
            list.CountSickDays(sdci, dt1, dt2, skipdays);
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
            var list = new TimeSheetRowSetList() { this };
            list.CountVacationTime(dt1, dt2, out days, out hours);
        }


    }

    public static class TimeSheetRowSetExt
    {
        public static TimeSheetRowSet GetDLRowSet(KlonsADataSet.TIMESHEETRow[] rows)
        {
            var rowset = new TimeSheetRowSet();
            foreach (var dr in rows)
            {
                switch (dr.XKind1)
                {
                    case EKind1.PlanIndividualDay:
                        rowset.Plan = dr;
                        break;
                    case EKind1.PlanIndividualNight:
                        rowset.PlanNight = dr;
                        break;
                    case EKind1.Fact:
                        rowset.Fact = dr;
                        break;
                    case EKind1.FactNight:
                        rowset.FactNight = dr;
                        break;
                    case EKind1.FactOvertime:
                        rowset.FactOvertime = dr;
                        break;
                }
            }
            return rowset;
        }

        public static TimeSheetRowSet GetDLRowSet(this KlonsADataSet.TIMESHEET_LISTS_RRow row)
        {
            var rowset = new TimeSheetRowSet();
            var drs = row.GetTIMESHEETRows();
            foreach (var dr in drs)
            {
                switch (dr.XKind1)
                {
                    case EKind1.PlanIndividualDay:
                        rowset.Plan = dr;
                        break;
                    case EKind1.PlanIndividualNight:
                        rowset.PlanNight = dr;
                        break;
                    case EKind1.Fact:
                        rowset.Fact = dr;
                        break;
                    case EKind1.FactNight:
                        rowset.FactNight = dr;
                        break;
                    case EKind1.FactOvertime:
                        rowset.FactOvertime = dr;
                        break;
                }
            }

            if (row.XPlanType == EPlanType.Fixed && !row.IsIDPLNull())
            {
                var table_darba_laiks = (row.Table.DataSet as KlonsADataSet).TIMESHEET;
                int yr = row.TIMESHEET_LISTSRow.YR;
                int mt = row.TIMESHEET_LISTSRow.MT;

                var drs_plan = table_darba_laiks.WhereX(
                    d =>
                    !d.IsIDPNull() &&
                    d.IDP == row.IDPL &&
                    d.YR == yr &&
                    d.MT == mt &&
                    (d.XKind1 == EKind1.PlanGroupDay ||
                    d.XKind1 == EKind1.PlanGroupaNight)
                );
                foreach (var dr in drs_plan)
                {
                    switch (dr.XKind1)
                    {
                        case EKind1.PlanGroupDay:
                            rowset.Plan = dr;
                            break;
                        case EKind1.PlanGroupaNight:
                            rowset.PlanNight = dr;
                            break;
                    }
                }
            }
            return rowset;
        }
    }
}
