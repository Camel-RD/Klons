using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotyfyProp;

namespace DataObjectsA
{
    [NotyfyProp.NotifyPropertyChanged(Filter = "_", Serialize = false, Browsable = true)]
    public class SalaryData : BindableComponent, IWorkTimeData
    {
        public int _ID { get; set; } = 0;
        public int? _IDS { get; set; } = null;
        public int? _IDSX { get; set; } = null;
        public int? _IDST { get; set; } = null;
        public Int16 _IS_TEMP { get; set; } = 0;
        public int _IDP { get; set; } = 0;
        public int? _IDAM { get; set; } = null;
        public int _SNR { get; set; } = 0;
        public string _FNAME { get; set; } = null;
        public string _LNAME { get; set; } = null;
        public string _POSITION_TITLE { get; set; } = null;
        public string _TERRITORIAL_CODE { get; set; } = null;

        public Int16 _R_TYPE { get; set; } = 0;
        public decimal _R_MT { get; set; } = 0.0M;
        public decimal _R_MT_NIGHT { get; set; } = 0.0M;
        public Int16 _R_MT_NIGHT_TYPE { get; set; } = 0;
        public decimal _R_MT_OVERTIME { get; set; } = 0.0M;
        public Int16 _R_MT_OVERTIME_TYPE { get; set; } = 0;
        public decimal _R_MT_HOLIDAY { get; set; } = 0.0M;
        public Int16 _R_MT_HOLIDAY_TYPE { get; set; } = 0;
        public decimal _R_MT_HOLIDAY_NIGHT { get; set; } = 0.0M;
        public Int16 _R_MT_HOLIDAY_NIGHT_TYPE { get; set; } = 0;
        public decimal _R_MT_HOLIDAY_OVERTIME { get; set; } = 0.0M;
        public Int16 _R_MT_HOLIDAY_OVERTIME_TYPE { get; set; } = 0;
        public Int16 _R_HR_TYPE { get; set; } = 0;
        public decimal _R_HR { get; set; } = 0.0M;
        public decimal _R_HR_NIGHT { get; set; } = 0.0M;
        public decimal _R_HR_OVERTIME { get; set; } = 0.0M;
        public decimal _R_HR_HOLIDAY { get; set; } = 0.0M;
        public decimal _R_HR_HOLIDAY_NIGHT { get; set; } = 0.0M;
        public decimal _R_HR_HOLIDAY_OVERTIME { get; set; } = 0.0M;

        public int _CALENDAR_DAYS { get; set; } = 0;
        public int _CALENDAR_DAYS_USE { get; set; } = 0;
        public int _MONTH_WORKDAYS { get; set; } = 0;
        public float _MONTH_WORKHOURS { get; set; } = 0.0f;

        public int _PLAN_DAYS { get; set; } = 0;
        public float _PLAN_HOURS { get; set; } = 0.0f;
        public float _PLAN_HOURS_NIGHT { get; set; } = 0.0f;
        public float _PLAN_HOURS_OVERTIME { get; set; } = 0.0f;

        public int _FACT_DAYS { get; set; } = 0;
        public float _FACT_HOURS { get; set; } = 0.0f;
        public float _FACT_HOURS_NIGHT { get; set; } = 0.0f;
        public float _FACT_HOURS_OVERTIME { get; set; } = 0.0f;

        public int _PLAN_WORK_DAYS { get; set; } = 0;
        public float _PLAN_WORK_HOURS { get; set; } = 0.0f;
        public float _PLAN_WORK_HOURS_NIGHT { get; set; } = 0.0f;
        public float _PLAN_WORK_HOURS_OVERTIME { get; set; } = 0.0f;

        public int _FACT_WORK_DAYS { get; set; } = 0;
        public float _FACT_WORK_HOURS { get; set; } = 0.0f;
        public float _FACT_WORK_HOURS_NIGHT { get; set; } = 0.0f;
        public float _FACT_WORK_HOURS_OVERTIME { get; set; } = 0.0f;

        public int _PLAN_HOLIDAYS_DAYS { get; set; } = 0;
        public float _PLAN_HOLIDAYS_HOURS { get; set; } = 0.0f;
        public float _PLAN_HOLIDAYS_HOURS_NIGHT { get; set; } = 0.0f;
        public float _PLAN_HOLIDAYS_HOURS_OVERTIME { get; set; } = 0.0f;

        public int _FACT_HOLIDAYS_DAYS { get; set; } = 0;
        public float _FACT_HOLIDAYS_HOURS { get; set; } = 0.0f;
        public float _FACT_HOLIDAYS_HOURS_NIGHT { get; set; } = 0.0f;
        public float _FACT_HOLIDAYS_HOURS_OVERTIME { get; set; } = 0.0f;

        public decimal _SALARY { get; set; } = 0.0M;
        public decimal _SALARY_DAY { get; set; } = 0.0M;
        public decimal _SALARY_NIGHT { get; set; } = 0.0M;
        public decimal _SALARY_OVERTIME { get; set; } = 0.0M;
        public decimal _SALARY_HOLIDAYS_DAY { get; set; } = 0.0M;
        public decimal _SALARY_HOLIDAYS_NIGHT { get; set; } = 0.0M;
        public decimal _SALARY_HOLIDAYS_OVERTIME { get; set; } = 0.0M;
        public decimal _SALARY_PAID_HOLIDAYS_DAY { get; set; } = 0.0M;
        public decimal _SALARY_PAID_HOLIDAYS_NIGHT { get; set; } = 0.0M;
        public decimal _SALARY_PIECEWORK { get; set; } = 0.0M;
        public int _SICKDAYS { get; set; } = 0;
        public decimal _SICKDAYS_PAY { get; set; } = 0.0M;
        public int _ACCIDENT_DAYS { get; set; } = 0;
        public decimal _ACCIDENT_PAY { get; set; } = 0.0M;
        public int _AVERAGE_INCOME_DAYS { get; set; } = 0;
        public decimal _AVERAGE_INCOME_PAY { get; set; } = 0.0M;

        public int _FACT_AVPAY_FREE_DAYS { get; set; } = 0;
        public float _FACT_AVPAY_FREE_HOURS { get; set; } = 0.0f;
        public int _FACT_AVPAY_WORK_DAYS { get; set; } = 0;
        public int _FACT_AVPAY_WORKINHOLIDAYS { get; set; } = 0;

        public float _FACT_AVPAY_HOURS { get; set; } = 0.0f;
        public float _FACT_AVPAY_HOURS_OVERTIME { get; set; } = 0.0f;
        public float _FACT_AVPAY_HOLIDAYS_HOURS { get; set; } = 0.0f;
        public float _FACT_AVPAY_HOLIDAYS_HOURS_OVERT { get; set; } = 0.0f;

        public decimal _SALARY_AVPAY_FREE_DAYS { get; set; } = 0.0M;
        public decimal _SALARY_AVPAY_WORK_DAYS { get; set; } = 0.0M;
        public decimal _SALARY_AVPAY_WORK_DAYS_OVERTIME { get; set; } = 0.0M;
        public decimal _SALARY_AVPAY_HOLIDAYS { get; set; } = 0.0M;
        public decimal _SALARY_AVPAY_HOLIDAYS_OVERTIME { get; set; } = 0.0M;

        public int _BUSINESS_TRIP_DAYS { get; set; } = 0;
        public decimal _BUSINESS_TRIP_PAY { get; set; } = 0.0M;

        public int _PAID_HOLIDAYS { get; set; } = 0;
        public decimal _PAID_HOLIDAYS_PAY { get; set; } = 0.0M;
        public float _VACATION_DAYS_CURRENT { get; set; } = 0.0f;
        public float _VACATION_DAYS_NEXT { get; set; } = 0.0f;
        public float _VACATION_HOURS_CURRENT { get; set; } = 0.0F;
        public float _VACATION_HOURS_NEXT { get; set; } = 0.0F;
        public decimal _VACATION_PAY_CURRENT { get; set; } = 0.0M;
        public decimal _VACATION_PAY_NEXT { get; set; } = 0.0M;
        public decimal _VACATION_DNS_NEXT { get; set; } = 0.0M;
        public decimal _VACATION_DDS_NEXT { get; set; } = 0.0M;
        public decimal _VACATION_IIN_NEXT { get; set; } = 0.0M;
        public decimal _VACATION_IIN_REDUCE_NEXT { get; set; } = 0.0M;
        public decimal _VACATION_CASH_NEXT { get; set; } = 0.0M;
        public decimal _VACATION_PAY_PREV { get; set; } = 0.0M;
        public decimal _VACATION_DNS_PREV { get; set; } = 0.0M;
        public decimal _VACATION_DDS_PREV { get; set; } = 0.0M;
        public decimal _VACATION_IIN_PREV { get; set; } = 0.0M;

        public decimal _PLUS_TAXED { get; set; } = 0.0M;
        public decimal _PLUS_NOTTAXED { get; set; } = 0.0M;
        public decimal _PLUS_NOSAI { get; set; } = 0.0M;
        public decimal _PLUS_AUTHORS_FEES { get; set; } = 0.0M;
        public decimal _MINUS_BEFORE_IIN { get; set; } = 0.0M;
        public decimal _MINUS_AFTER_IIN { get; set; } = 0.0M;
        public decimal _PLUS_PF_NOTTAXED { get; set; } = 0.0M;
        public decimal _PLUS_PF_TAXED { get; set; } = 0.0M;
        public decimal _PLUS_LI_NOTTAXED { get; set; } = 0.0M;
        public decimal _PLUS_LI_TAXED { get; set; } = 0.0M;
        public decimal _PLUS_HI_NOTTAXED { get; set; } = 0.0M;
        public decimal _PLUS_HI_TAXED { get; set; } = 0.0M;
        public decimal _PLUS_NP_TAXED { get; set; } = 0.0M;
        public decimal _PLUS_NP_NOTTAXED { get; set; } = 0.0M;
        public decimal _PLUS_NP_NOSAI { get; set; } = 0.0M;


        public decimal _TOTAL_BEFORE_TAXES { get; set; } = 0.0M;
        public decimal _ADJUSTED_AMOUNT { get; set; } = 0.0M;
        public decimal _AMOUNT_BEFORE_SN { get; set; } = 0.0M;
        public decimal _AMOUNT_BEFORE_SN_REVERSE { get; set; } = 0.0M;

        public decimal _RATE_DNSN { get; set; } = 0.0M;
        public decimal _RATE_DDSN { get; set; } = 0.0M;

        public decimal _DNSN_AMOUNT { get; set; } = 0.0M;
        public decimal _DDSN_AMOUNT { get; set; } = 0.0M;
        public decimal _SN_AMOUNT { get; set; } = 0.0M;
        public decimal _DNSN_AMOUNT_REVERSE { get; set; } = 0.0M;
        public decimal _DDSN_AMOUNT_REVERSE { get; set; } = 0.0M;
        public decimal _SN_MAX_AMOUNT { get; set; } = 0.0M;

        public decimal _IIN_EXEMPT_UNTAXED_MINIMUM0 { get; set; } = 0.0M;
        public decimal _IIN_EXEMPT_DEPENDANTS0 { get; set; } = 0.0M;
        public decimal _IIN_EXEMPT_RETALIATION0 { get; set; } = 0.0M;
        public decimal _IIN_EXEMPT_INVALIDITY0 { get; set; } = 0.0M;
        public decimal _IIN_EXEMPT_NATIONAL_MOVEMENT0 { get; set; } = 0.0M;

        public decimal _IIN_EXEMPT_UNTAXED_MINIMUM { get; set; } = 0.0M;
        public decimal _IIN_EXEMPT_DEPENDANTS { get; set; } = 0.0M;
        public decimal _IIN_EXEMPT_RETALIATION { get; set; } = 0.0M;
        public decimal _IIN_EXEMPT_INVALIDITY { get; set; } = 0.0M;
        public decimal _IIN_EXEMPT_NATIONAL_MOVEMENT { get; set; } = 0.0M;
        public decimal _IIN_EXEMPT_EXPENSES { get; set; } = 0.0M;
        public Int16 _IIN_EXEMPT_2TP { get; set; } = 0;
        public decimal _IIN_EXEMPT_20 { get; set; } = 0.0M;
        public decimal _IIN_EXEMPT_2 { get; set; } = 0.0M;

        public decimal _AMOUNT_BEFORE_IIN { get; set; } = 0.0M;
        public decimal _AMOUNT_BEFORE_IIN_REVERSE { get; set; } = 0.0M;

        public decimal _RATE_IIN { get; set; } = 0.0M;
        public decimal _IIN_AMOUNT { get; set; } = 0.0M;

        public decimal _IIN_AMOUNT_REVERSE { get; set; } = 0.0M;
        public decimal _URVN_AMAOUNT { get; set; } = 0.0M;

        public decimal _PLUS_NOT_PAID { get; set; } = 0.0M;
        public decimal _VACATION_ADVANCE_CURRENT { get; set; } = 0.0M;
        public decimal _VACATION_ADVANCE_NEXT { get; set; } = 0.0M;
        public decimal _VACATION_ADVANCE_PREV { get; set; } = 0.0M;
        public decimal _ADVANCE { get; set; } = 0.0M;
        public decimal _PAY0 { get; set; } = 0.0M;
        public decimal _PAY { get; set; } = 0.0M;
        public decimal _PAYT { get; set; } = 0.0M;
        public DateTime _PAY_DATE { get; set; }
        public string _COMMENTS { get; set; } = null;
        public decimal _WITHHOLD_FROM_PAY { get; set; } = 0.0M;

        public decimal _FORAVPAYCALC_BRUTO { get; set; } = 0.0M;
        public decimal _FORAVPAYCALC_PAYOUT { get; set; } = 0.0M;
        public int _FORAVPAYCALC_DAYS { get; set; } = 0;
        public float _FORAVPAYCALC_HOURS { get; set; } = 0.0F;
        public decimal _AVPAYCALC_DAY { get; set; } = 0.0M;
        public decimal _AVPAYCALC_CALDAY { get; set; } = 0.0M;
        public decimal _AVPAYCALC_HOUR { get; set; } = 0.0M;

    }

}