using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using DataObjectsA;
using KlonsLIB.Misc;

namespace KlonsA.Classes
{
    public class SalaryInfo : SalaryData
    {
        public decimal PlanedWorkPay = 0.0M;
        public int FACT_AVPAY_FREE_DAYS_2  = 0;
        public float FACT_AVPAY_FREE_HOURS_2 = 0.0f;
        public int FACT_AVPAY_WORK_DAYS_2 = 0;
        public int FACT_AVPAY_WORKINHOLIDAYS_2 = 0;
        public float FACT_AVPAY_HOURS_2 = 0.0f;
        public float FACT_AVPAY_HOURS_OVERTIME_2 = 0.0f;
        public float FACT_AVPAY_HOLIDAYS_HOURS_2 = 0.0f;
        public float FACT_AVPAY_HOLIDAYS_HOURS_OVERT_2 = 0.0f;

        public EIINExempt2Kind IINExempt2Kind
        {
            get { return (EIINExempt2Kind)_IIN_EXEMPT_2TP; }
            set { _IIN_EXEMPT_2TP = (short)value; }
        }

        public void SetFromRow(KlonsADataSet.SALARY_SHEETS_RRow dr)
        {
            var props = TypeDescriptor.GetProperties(this);
            for(int i = 0; i < props.Count; i++)
            {
                var prop = props[i];
                if (!prop.Name.StartsWith("_")) continue;
                var fieldname = prop.Name.Substring(1);
                object val = dr[fieldname];
                if (val == null || val == DBNull.Value)
                    val = prop.PropertyType.GetDefaultValue();
                prop.SetValue(this, val);
            }
        }

        private static string[] DontUpdateThese = 
            new[] { "_ID", "_IDS", "_IDSX", "_IDST", "_IS_TEMP", "_IDP", "_IDAM", "_FNAME", "_LNAME",
            "_SNR", "_POSITION_TITLE", "_TERRITORIAL_CODE", "_COMMENTS", "_PAY_DATE"};

        public void WriteToRow(KlonsADataSet.SALARY_SHEETS_RRow dr)
        {
            var props = TypeDescriptor.GetProperties(this);
            bool has_changes = false;
            dr.BeginEdit();
            for (int i = 0; i < props.Count; i++)
            {
                var prop = props[i];
                if (!prop.Name.StartsWith("_")) continue;
                if (DontUpdateThese.Contains(prop.Name)) continue;
                var fieldname = prop.Name.Substring(1);
                var val1 = prop.GetValue(this);
                if (val1 == null) val1 = DBNull.Value;
                var val2 = dr[fieldname];
                if (object.Equals(val1, val2)) continue;
                dr[fieldname] = val1;
                has_changes = true;
            }
            if (has_changes)
            {
                dr.DT_EDITED = DateTime.Now;
            }
            dr.EndEditX();
        }

        public void ClearAll()
        {
            var props = TypeDescriptor.GetProperties(this);
            for (int i = 0; i < props.Count; i++)
            {
                var prop = props[i];
                if (!prop.Name.StartsWith("_")) continue;
                if (DontUpdateThese.Contains(prop.Name)) continue;
                var fieldname = prop.Name.Substring(1);
                prop.SetValue(this, prop.PropertyType.GetDefaultValue());
            }
        }

        public void ClearTime()
        {
            _PLAN_DAYS = 0;
            _PLAN_HOLIDAYS_DAYS = 0;
            _PLAN_HOLIDAYS_HOURS = 0.0f;
            _PLAN_HOLIDAYS_HOURS_NIGHT = 0.0f;
            _PLAN_HOLIDAYS_HOURS_OVERTIME = 0.0f;
            _PLAN_HOURS = 0.0f;
            _PLAN_HOURS_NIGHT = 0.0f;
            _PLAN_HOURS_OVERTIME = 0.0f;
            _PLAN_WORK_DAYS = 0;
            _PLAN_WORK_HOURS = 0.0f;
            _PLAN_WORK_HOURS_NIGHT = 0.0f;
            _PLAN_WORK_HOURS_OVERTIME = 0.0f;

            _FACT_AVPAY_FREE_DAYS = 0;
            _FACT_AVPAY_FREE_HOURS = 0.0f;
            _FACT_AVPAY_HOLIDAYS_HOURS = 0.0f;
            _FACT_AVPAY_HOLIDAYS_HOURS_OVERT = 0.0f;
            _FACT_AVPAY_HOURS = 0.0f;
            _FACT_AVPAY_HOURS_OVERTIME = 0.0f;
            _FACT_AVPAY_WORKINHOLIDAYS = 0;
            _FACT_AVPAY_WORK_DAYS = 0;
            _FACT_DAYS = 0;
            _FACT_HOLIDAYS_DAYS = 0;
            _FACT_HOLIDAYS_HOURS = 0.0f;
            _FACT_HOLIDAYS_HOURS_NIGHT = 0.0f;
            _FACT_HOLIDAYS_HOURS_OVERTIME = 0.0f;
            _FACT_HOURS = 0.0f;
            _FACT_HOURS_NIGHT = 0.0f;
            _FACT_HOURS_OVERTIME = 0.0f;
            _FACT_WORK_DAYS = 0;
            _FACT_WORK_HOURS = 0.0f;
            _FACT_WORK_HOURS_NIGHT = 0.0f;
            _FACT_WORK_HOURS_OVERTIME = 0.0f;

        }

        public decimal SumIINExempts()
        {
            return _IIN_EXEMPT_DEPENDANTS +
                _IIN_EXEMPT_INVALIDITY +
                _IIN_EXEMPT_NATIONAL_MOVEMENT +
                _IIN_EXEMPT_RETALIATION +
                _IIN_EXEMPT_UNTAXED_MINIMUM;
        }

        public decimal SumIINExemptsAll()
        {
            return SumIINExempts() +
                _IIN_EXEMPT_EXPENSES;
        }

        public decimal SumSalary()
        {
            return _SALARY_DAY +
                _SALARY_NIGHT +
                _SALARY_OVERTIME +
                _SALARY_HOLIDAYS_DAY +
                _SALARY_HOLIDAYS_NIGHT +
                _SALARY_HOLIDAYS_OVERTIME +
                _SALARY_AVPAY_FREE_DAYS +
                _SALARY_AVPAY_WORK_DAYS +
                _SALARY_AVPAY_WORK_DAYS_OVERTIME +
                _SALARY_AVPAY_HOLIDAYS +
                _SALARY_AVPAY_HOLIDAYS_OVERTIME +
                _SALARY_PIECEWORK;
        }

        public void SumForAvPay()
        {
            _FORAVPAYCALC_BRUTO = SumSalary() - _SALARY_AVPAY_FREE_DAYS;
            _FORAVPAYCALC_DAYS = _FACT_WORK_DAYS;
            _FORAVPAYCALC_HOURS = _FACT_WORK_HOURS;
        }

        public void GetRateDefs(KlonsADataSet.POSITIONS_RRow dr_amati_r, int calcdays, float calchours)
        {
            var rt = dr_amati_r.XRateType;

            R_TYPE = dr_amati_r.SALARY_TYPE;
            R_MT = dr_amati_r.RATE;
            R_MT_NIGHT = dr_amati_r.RATE_NIGHT;
            R_MT_NIGHT_TYPE = dr_amati_r.RATE_NIGHT_TYPE;
            R_MT_OVERTIME = dr_amati_r.RATE_OVERTIME;
            R_MT_OVERTIME_TYPE = dr_amati_r.RATE_OVERTIME_TYPE;
            R_MT_HOLIDAY = dr_amati_r.RATE_HOLIDAY;
            R_MT_HOLIDAY_TYPE = dr_amati_r.RATE_HOLIDAY_TYPE;
            R_MT_HOLIDAY_NIGHT = dr_amati_r.RATE_HOLIDAY_NIGHT;
            R_MT_HOLIDAY_NIGHT_TYPE = dr_amati_r.RATE_HOLIDAY_NIGHT_TYPE;
            R_MT_HOLIDAY_OVERTIME = dr_amati_r.RATE_HOLIDAY_OVERTIME;
            R_MT_HOLIDAY_OVERTIME_TYPE = dr_amati_r.RATE_HOLIDAY_OVERTIME_TYPE;

            R_HR = R_MT;
            R_HR_NIGHT = GetRate(R_HR, R_MT_NIGHT_TYPE, R_MT_NIGHT);
            R_HR_OVERTIME = GetRate(R_HR, R_MT_OVERTIME_TYPE, R_MT_OVERTIME);
            R_HR_HOLIDAY = GetRate(R_HR, R_MT_HOLIDAY_TYPE, R_MT_HOLIDAY);
            R_HR_HOLIDAY_NIGHT = GetRate(R_HR, R_MT_HOLIDAY_NIGHT_TYPE, R_MT_HOLIDAY_NIGHT);
            R_HR_HOLIDAY_OVERTIME = GetRate(R_HR, R_MT_HOLIDAY_OVERTIME_TYPE, dr_amati_r.RATE_HOLIDAY_OVERTIME);

            decimal d;
            //mēneša likmes tiek pārrēķinātas dienas likmēs
            if (rt == ESalaryType.Month)
            {
                if(calcdays > 0)
                {
                    d = (decimal)calcdays;
                    R_HR /= d;
                    R_HR_NIGHT /= d;
                    R_HR_HOLIDAY /= d;
                }
                if(calchours > 0.0f)
                {
                    d = (decimal)calchours;
                    R_HR_NIGHT /= d;
                    R_HR_OVERTIME /= d;
                    R_HR_HOLIDAY_NIGHT /= d;
                    R_HR_HOLIDAY_OVERTIME /= d;
                }
            }
            if (rt == ESalaryType.Day && calchours > 0.0f)
            {
                d = (decimal)dr_amati_r.NORMAL_DAY_HOURS;
                R_HR_NIGHT /= d;
                R_HR_OVERTIME /= d;
                R_HR_HOLIDAY_NIGHT /= d;
                R_HR_HOLIDAY_OVERTIME /= d;
            }

            R_HR = KlonsData.RoundA(R_HR, 6);
            R_HR_NIGHT = KlonsData.RoundA(R_HR_NIGHT, 6);
            R_HR_OVERTIME = KlonsData.RoundA(R_HR_OVERTIME, 6);
            R_HR_HOLIDAY = KlonsData.RoundA(R_HR_HOLIDAY, 6);
            R_HR_HOLIDAY_NIGHT = KlonsData.RoundA(R_HR_HOLIDAY_NIGHT, 6);
            R_HR_HOLIDAY_OVERTIME = KlonsData.RoundA(R_HR_HOLIDAY_OVERTIME, 6);
        }

        public decimal GetRate(decimal baserate, short ratetype, decimal aplyrate)
        {
            if (ratetype == 1) return aplyrate;
            return baserate * aplyrate / 100.0M;
        }

        public void AddWorkTime(SalaryInfo wi)
        {
            /*
            _CALENDAR_DAYS += wi._CALENDAR_DAYS;
            _CALENDAR_DAYS_USE += wi._CALENDAR_DAYS_USE;
            _MONTH_WORKDAYS += wi._MONTH_WORKDAYS;
            _MONTH_WORKHOURS += wi._MONTH_WORKHOURS;

            _PLAN_DAYS += wi._PLAN_DAYS;
            _PLAN_HOURS += wi._PLAN_HOURS;
            _PLAN_HOURS_NIGHT += wi._PLAN_HOURS_NIGHT;
            _PLAN_HOURS_OVERTIME += wi._PLAN_HOURS_OVERTIME;

            _PLAN_WORK_DAYS += wi._PLAN_WORK_DAYS;
            _PLAN_WORK_HOURS += wi._PLAN_WORK_HOURS;
            _PLAN_WORK_HOURS_NIGHT += wi._PLAN_WORK_HOURS_NIGHT;
            _PLAN_WORK_HOURS_OVERTIME += wi._PLAN_WORK_HOURS_OVERTIME;
            
            _PLAN_HOLIDAYS_DAYS += wi._PLAN_HOLIDAYS_DAYS;
            _PLAN_HOLIDAYS_HOURS += wi._PLAN_HOLIDAYS_HOURS;
            _PLAN_HOLIDAYS_HOURS_NIGHT += wi._PLAN_HOLIDAYS_HOURS_NIGHT;
            _PLAN_HOLIDAYS_HOURS_OVERTIME += wi._PLAN_HOLIDAYS_HOURS_OVERTIME;
             */

            _FACT_DAYS += wi._FACT_DAYS;
            _FACT_HOURS += wi._FACT_HOURS;
            _FACT_HOURS_NIGHT += wi._FACT_HOURS_NIGHT;
            _FACT_HOURS_OVERTIME += wi._FACT_HOURS_OVERTIME;

            _FACT_WORK_DAYS += wi._FACT_WORK_DAYS;
            _FACT_WORK_HOURS += wi._FACT_WORK_HOURS;
            _FACT_WORK_HOURS_NIGHT += wi._FACT_WORK_HOURS_NIGHT;
            _FACT_WORK_HOURS_OVERTIME += wi._FACT_WORK_HOURS_OVERTIME;

            _FACT_HOLIDAYS_DAYS += wi._FACT_HOLIDAYS_DAYS;
            _FACT_HOLIDAYS_HOURS += wi._FACT_HOLIDAYS_HOURS;
            _FACT_HOLIDAYS_HOURS_NIGHT += wi._FACT_HOLIDAYS_HOURS_NIGHT;
            _FACT_HOLIDAYS_HOURS_OVERTIME += wi._FACT_HOLIDAYS_HOURS_OVERTIME;

            // ..............

            _FACT_AVPAY_FREE_DAYS += wi._FACT_AVPAY_FREE_DAYS;
            _FACT_AVPAY_FREE_HOURS += wi._FACT_AVPAY_FREE_HOURS;
            _FACT_AVPAY_WORK_DAYS += wi._FACT_AVPAY_WORK_DAYS;
            _FACT_AVPAY_WORKINHOLIDAYS += wi._FACT_AVPAY_WORKINHOLIDAYS;
            _FACT_AVPAY_HOURS += wi._FACT_AVPAY_HOURS;
            _FACT_AVPAY_HOURS_OVERTIME += wi._FACT_AVPAY_HOURS_OVERTIME;
            _FACT_AVPAY_HOLIDAYS_HOURS += wi._FACT_AVPAY_HOLIDAYS_HOURS;
            _FACT_AVPAY_HOLIDAYS_HOURS_OVERT += wi._FACT_AVPAY_HOLIDAYS_HOURS_OVERT;

            // ..............
            FACT_AVPAY_FREE_DAYS_2 += wi.FACT_AVPAY_FREE_DAYS_2;
            FACT_AVPAY_FREE_HOURS_2 += wi.FACT_AVPAY_FREE_HOURS_2;
            FACT_AVPAY_WORK_DAYS_2 += wi.FACT_AVPAY_WORK_DAYS_2;
            FACT_AVPAY_WORKINHOLIDAYS_2 += wi.FACT_AVPAY_WORKINHOLIDAYS_2;
            FACT_AVPAY_HOURS_2 += wi.FACT_AVPAY_HOURS_2;
            FACT_AVPAY_HOURS_OVERTIME_2 += wi.FACT_AVPAY_HOURS_OVERTIME_2;
            FACT_AVPAY_HOLIDAYS_HOURS_2 += wi.FACT_AVPAY_HOLIDAYS_HOURS_2;
            FACT_AVPAY_HOLIDAYS_HOURS_OVERT_2 += wi.FACT_AVPAY_HOLIDAYS_HOURS_OVERT_2;

        }

        public void AddSalary(SalaryInfo wi)
        {
            _SALARY += wi._SALARY;
            _SALARY_DAY += wi._SALARY_DAY;
            _SALARY_NIGHT += wi._SALARY_NIGHT;
            _SALARY_OVERTIME += wi._SALARY_OVERTIME;
            _SALARY_HOLIDAYS_DAY += wi._SALARY_HOLIDAYS_DAY;
            _SALARY_HOLIDAYS_NIGHT += wi._SALARY_HOLIDAYS_NIGHT;
            _SALARY_HOLIDAYS_OVERTIME += wi._SALARY_HOLIDAYS_OVERTIME;
            _SALARY_PAID_HOLIDAYS_DAY += wi._SALARY_PAID_HOLIDAYS_DAY;
            _SALARY_PAID_HOLIDAYS_NIGHT += wi._SALARY_PAID_HOLIDAYS_NIGHT;

            _SALARY_PIECEWORK += wi._SALARY_PIECEWORK;

            PlanedWorkPay += wi.PlanedWorkPay;

            AddSalaryAvPayPart(wi);
        }

        public void ClearSalaryAvPayPart()
        {
            _SALARY_AVPAY_FREE_DAYS = 0.0M;
            _SALARY_AVPAY_WORK_DAYS = 0.0M;
            _SALARY_AVPAY_WORK_DAYS_OVERTIME = 0.0M;
            _SALARY_AVPAY_HOLIDAYS = 0.0M;
            _SALARY_AVPAY_HOLIDAYS_OVERTIME = 0.0M;
        }

        public void AddSalaryAvPayPart(SalaryInfo wi)
        {
            _SALARY_AVPAY_FREE_DAYS += wi._SALARY_AVPAY_FREE_DAYS;
            _SALARY_AVPAY_WORK_DAYS += wi._SALARY_AVPAY_WORK_DAYS;
            _SALARY_AVPAY_WORK_DAYS_OVERTIME += wi._SALARY_AVPAY_WORK_DAYS_OVERTIME;
            _SALARY_AVPAY_HOLIDAYS += wi._SALARY_AVPAY_HOLIDAYS;
            _SALARY_AVPAY_HOLIDAYS_OVERTIME += wi._SALARY_AVPAY_HOLIDAYS_OVERTIME;
        }


    }


}
