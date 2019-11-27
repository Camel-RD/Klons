using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotyfyProp;

namespace DataObjectsA
{
    public class BonusData : BindableComponent
    {
        public int _ID { get; set; } = 0;
        public int _IDP { get; set; } = 0;
        public int? _IDA { get; set; } = null;
        public int? _IDAP { get; set; } = null;
        public int _IDSX { get; set; } = 0;
        public int _IDSV { get; set; } = 1;
        public int? _IDNO { get; set; } = null;
        public int? _IDIE { get; set; } = null;
        public string _DESCR { get; set; } = null;
        public decimal _RATE { get; set; } = 0.0M;
        public Int16 _RATE_TYPE { get; set; } = 0;
        public decimal _AMOUNT { get; set; } = 0.0M;
        public Int16 _IS_INAVPAY { get; set; } = 0;
        public Int16 _IS_PAID { get; set; } = 0;

    }
}
