using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotyfyProp;

namespace DataObjectsA
{
    public class AmatsData : BindableComponent
    {
        public int _ID { get; set; } = 0;
        public int _IDP { get; set; } = 0;
        public string _IDDEP { get; set; } = null;
        public string _TITLE { get; set; } = null;
        public string _TITLE_DATIVE { get; set; } = null;
        public string _TITLE_ACCUSATIVE { get; set; } = null;
        public Int16 _SALARY_TYPE { get; set; } = 0;
        public Int16 _SIXDAYWEEK { get; set; } = 0;
        public int _NORMAL_DAY_HOURS { get; set; } = 0;
        public int _NORMAL_WEEK_HOURS { get; set; } = 0;
        public decimal _RATE { get; set; } = 0.0M;
        public decimal _RATE_NIGHT { get; set; } = 0.0M;
        public Int16 _RATE_NIGHT_TYPE { get; set; } = 0;
        public decimal _RATE_OVERTIME { get; set; } = 0.0M;
        public Int16 _RATE_OVERTIME_TYPE { get; set; } = 0;
        public decimal _RATE_HOLIDAY { get; set; } = 0.0M;
        public Int16 _RATE_HOLIDAY_TYPE { get; set; } = 0;
        public decimal _RATE_HOLIDAY_NIGHT { get; set; } = 0.0M;
        public Int16 _RATE_HOLIDAY_NIGHT_TYPE { get; set; } = 0;
        public decimal _RATE_HOLIDAY_OVERTIME { get; set; } = 0.0M;
        public Int16 _RATE_HOLIDAY_OVERTIME_TYPE { get; set; } = 0;
        public decimal _ADVAMCE { get; set; } = 0.0M;
        public string _OCCUPATION_CODE { get; set; } = null;
        public Int16 _USED { get; set; } = 1;
        public DateTime _EDIT_DATE { get; set; } = DateTime.MinValue;
        public decimal _PAY0 { get; set; } = 0.0M;
        public decimal _IIN0 { get; set; } = 0.0M;
        public decimal _ADVANCE { get; set; } = 0.0M;

    }
}
