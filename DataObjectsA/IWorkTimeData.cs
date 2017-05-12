using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjectsA
{
    public interface IWorkTimeData
    {
        int _CALENDAR_DAYS { get; set; }
        int _CALENDAR_DAYS_USE { get; set; }
        int _MONTH_WORKDAYS { get; set; }
        float _MONTH_WORKHOURS { get; set; }

        int _PLAN_DAYS { get; set; }
        float _PLAN_HOURS { get; set; }
        float _PLAN_HOURS_NIGHT { get; set; }
        float _PLAN_HOURS_OVERTIME { get; set; }

        int _FACT_DAYS { get; set; }
        float _FACT_HOURS { get; set; }
        float _FACT_HOURS_NIGHT { get; set; }
        float _FACT_HOURS_OVERTIME { get; set; }

        int _PLAN_WORK_DAYS { get; set; }
        float _PLAN_WORK_HOURS { get; set; }
        float _PLAN_WORK_HOURS_NIGHT { get; set; }
        float _PLAN_WORK_HOURS_OVERTIME { get; set; }

        int _FACT_WORK_DAYS { get; set; }
        float _FACT_WORK_HOURS { get; set; }
        float _FACT_WORK_HOURS_NIGHT { get; set; }
        float _FACT_WORK_HOURS_OVERTIME { get; set; }

        int _PLAN_HOLIDAYS_DAYS { get; set; }
        float _PLAN_HOLIDAYS_HOURS { get; set; }
        float _PLAN_HOLIDAYS_HOURS_NIGHT { get; set; }
        float _PLAN_HOLIDAYS_HOURS_OVERTIME { get; set; }

        int _FACT_HOLIDAYS_DAYS { get; set; }
        float _FACT_HOLIDAYS_HOURS { get; set; }
        float _FACT_HOLIDAYS_HOURS_NIGHT { get; set; }
        float _FACT_HOLIDAYS_HOURS_OVERTIME { get; set; }

        int _SICKDAYS { get; set; }
        int _ACCIDENT_DAYS { get; set; }
        int _AVERAGE_INCOME_DAYS { get; set; }


        int _FACT_AVPAY_FREE_DAYS { get; set; }
        float _FACT_AVPAY_FREE_HOURS { get; set; }
        int _FACT_AVPAY_WORK_DAYS { get; set; }
        int _FACT_AVPAY_WORKINHOLIDAYS { get; set; }

        float _FACT_AVPAY_HOURS { get; set; }
        float _FACT_AVPAY_HOURS_OVERTIME { get; set; }
        float _FACT_AVPAY_HOLIDAYS_HOURS { get; set; }
        float _FACT_AVPAY_HOLIDAYS_HOURS_OVERT { get; set; }

        int _BUSINESS_TRIP_DAYS { get; set; }

        float _VACATION_DAYS_CURRENT { get; set; }
        float _VACATION_DAYS_NEXT { get; set; }
        float _VACATION_HOURS_CURRENT { get; set; }
        float _VACATION_HOURS_NEXT { get; set; }

    }
}
