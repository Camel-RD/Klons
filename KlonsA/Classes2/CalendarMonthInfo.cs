using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsA.DataSets.KlonsADataSetTableAdapters;
using KlonsLIB.Misc;
using KlonsLIB.Data;

namespace KlonsA.Classes
{
    public enum EHolyDay
    {
        None,
        WorkDay,
        Holiday,
        DayBeforeHoliday
    }

    public enum EDayTag
    {
        None,
        WorkDay,
        WorkDayBeforeHoliday,
        FreeDay,
        HolidayInWorkDay,
        HolidayInFreeDay
    }

    public class CalendarMonthInfo
    {
        public int Year { get; private set; } = 0;
        public int Month { get; private set; } = 0;
        public int[] WeekDays { get; private set; } = new int[31];
        public EHolyDay[] HolyDays { get; private set; } = new EHolyDay[31];
        public int DaysInMonth { get; private set; } = 0;

        public const float IdBrivdiena = 101;
        public const float IdSvetkuDiena = 102;
        public const float IdSvetkuDienaBrivdiena = 103;
        public const float IdNone = 104;

        public CalendarMonthInfo(int year, int month)
        {
            SetMonth(year, month);
        }

        public void SetMonth(int year, int month)
        {
            Year = year;
            Month = month;
            GetDays();
            GetHDays();
        }

        private void GetDays()
        {
            DateTime dt = new DateTime(Year, Month, 1);
            int i, wd1 = dt.DayOfWeekA(), wd2 = wd1;
            DaysInMonth = dt.AddMonths(1).AddDays(-1).Day;
            for (i = 0; i < 31; i++)
            {
                if (i >= DaysInMonth)
                {
                    WeekDays[i] = -1;
                }
                else
                {
                    WeekDays[i] = wd2;
                }
                wd2++;
                if (wd2 == 8) wd2 = 1;
            }
        }

        public void GetHDays()
        {
            DateTime dt1 = new DateTime(Year, Month, 1);
            DateTime dt2 = dt1.AddMonths(1).AddDays(-1);
            DateTime dt3 = dt2.AddDays(1);

            //var ad = KlonsData.St.KlonsTableAdapterManager.HOLIDAYSTableAdapter as HOLIDAYSTableAdapter;
            //var table_hloidays = ad.GetDataBy_SP_HOLIDAYS_01(dt1, dt2);

            var table_holidays = KlonsData.St.DataSetKlons.HOLIDAYS;
            if (table_holidays.Rows.Count == 0)
                throw new Exception("Nav svētku dienu datu.");

            var drs_hol = table_holidays
                .WhereX(d =>
                    d.DT >= dt1 &&
                    d.DT <= dt3)
                .OrderBy(d => d.DT)
                .ToArray();

            int i;
            int last = dt2.AddDays(-1).Day;

            for (i = 0; i < DaysInMonth; i++)
                HolyDays[i] = EHolyDay.WorkDay;

            for (i = DaysInMonth; i < 31; i++)
                HolyDays[i] = EHolyDay.None;

            foreach (var dr in drs_hol)
            {
                int day = dr.DT.Day;
                if (dr.DT == dt3)
                {
                    if (HolyDays[DaysInMonth - 1] == EHolyDay.WorkDay)
                        HolyDays[DaysInMonth - 1] = EHolyDay.DayBeforeHoliday;
                }
                else 
                {
                    HolyDays[day - 1] = EHolyDay.Holiday;
                    if (day > 1 && HolyDays[day - 2] == EHolyDay.WorkDay)
                        HolyDays[day - 2] = EHolyDay.DayBeforeHoliday;
                }
            }
        }


        public float[] MakeHours(KlonsADataSet.TIMEPLAN_LISTRow dr, bool fornight)
        {
            if (dr == null) return null;

            float[] hr = new float[31];
            int i, d1;

            for (i = 0; i < 31; i++)
                hr[i] = 0.0f;

            float dhr = fornight ? dr.HOURS_NIGHT : dr.HOURS;

            for (i = 0; i < 31; i++)
            {
                d1 = WeekDays[i];
                if (d1 == -1)
                {
                    hr[i] = 0.0f;
                    continue;
                }

                if (d1 == 7 || (dr.KIND1 == SomeDataDefs.Id5DienuNedela && d1 == 6))
                {
                    hr[i] = 0.0f;
                }
                else if (d1 == 6 && dr.KIND1 == SomeDataDefs.Id6DienuNedela)
                {
                    if (fornight) hr[i] = dhr;
                    else if (dhr == 7.0f) hr[i] = 5.0f;
                    else hr[i] = dhr;
                }
                else
                {
                    hr[i] = dhr;
                }

            }
            return hr;
        }

        /*
        public float[] MakeHoursV2(KlonsADataSet.TIMEPLAN_LISTRow dr, bool fornight)
        {
            if (dr == null) return null;

            float[] hr = new float[31];
            int i, d1;

            for (i = 0; i < 31; i++)
                hr[i] = 0.0f;

            float dhr = fornight ? dr.HOURS_NIGHT : dr.HOURS;

            for (i = 0; i < 31; i++)
            {
                d1 = WeekDays[i];
                if (d1 == -1)
                {
                    hr[i] = 0.0f;
                    continue;
                }

                if (HolyDays[i] == EHolyDay.Holiday)
                {
                    hr[i] = 0.0f;
                }
                else if (d1 == 7 || (dr.KIND1 == SomeDataDefs.Id5DienuNedela && d1 == 6))
                {
                    hr[i] = 0.0f;
                }
                else if (d1 == 6 && dr.KIND1 == SomeDataDefs.Id6DienuNedela)
                {
                    if (fornight) hr[i] = dhr;
                    else if (dhr == 7.0f) hr[i] = 4.0f;
                    else hr[i] = dhr;
                }
                else
                {
                    hr[i] = dhr;
                }

                if (!fornight && HolyDays[i] == EHolyDay.DayBeforeHoliday && hr[i] == dhr)
                {
                    hr[i] = dhr - 1;
                }
            }
            return hr;
        }
        */

        public EDayTag[] MakeDayTags(KlonsADataSet.TIMEPLAN_LISTRow dr)
        {
            if (dr == null) return null;

            EDayTag[] hr = new EDayTag[31];
            int i, d1;

            for (i = 0; i < DaysInMonth; i++)
            {
                d1 = WeekDays[i];
                if (d1 == -1) break;


                if (d1 == 7 || (dr.KIND1 == SomeDataDefs.Id5DienuNedela && d1 == 6))
                {
                    if (HolyDays[i] == EHolyDay.Holiday)
                    {
                        hr[i] = EDayTag.HolidayInFreeDay;
                    }
                    else
                    {
                        hr[i] = EDayTag.FreeDay;
                    }
                }
                else
                {
                    if (HolyDays[i] == EHolyDay.Holiday)
                    {
                        hr[i] = EDayTag.HolidayInWorkDay;
                    }
                    else if(HolyDays[i] == EHolyDay.DayBeforeHoliday)
                    {
                        hr[i] = EDayTag.WorkDayBeforeHoliday;
                    }
                    else
                    {
                        hr[i] = EDayTag.WorkDay;
                    }
                }
            }

            for (i = DaysInMonth; i < 31; i++)
            {
                hr[i] = EDayTag.None;
            }

            return hr;
        }


        public void CountDays(bool sixdayweek, out int wdays, out int hdays, int day1 = 1, int day2 = 31)
        {
            int i, d1;
            wdays = 0;
            hdays = 0;
            day1--;
            day2--;
            for (i = day1; i < day2; i++)
            {
                d1 = WeekDays[i];
                if (d1 == -1) return;

                if (HolyDays[i] == EHolyDay.Holiday)
                {
                    hdays++;
                    continue;
                }
                if (d1 == 7 || (!sixdayweek && d1 == 6))
                {
                }
                else
                {
                    wdays++;
                }
            }
        }
    }
}
