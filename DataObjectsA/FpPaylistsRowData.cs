using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotyfyProp;

namespace DataObjectsA
{
    [NotyfyProp.NotifyPropertyChanged(Filter = "_", Serialize = false, Browsable = true)]
    public class FpPaylistsRowData : BindableComponent
    {
        public int _ID { get; set; } = 0;
        public int _IDS { get; set; } = 0;
        public int _IDP { get; set; } = 0;
        public int _SNR { get; set; } = 0;
        public DateTime _DATE1 { get; set; } = DateTime.MinValue;
        public DateTime _DATE2 { get; set; } = DateTime.MinValue;
        public DateTime _PAYDATE { get; set; } = DateTime.MinValue;
        public Int16 _TAX_TP { get; set; } = 0;
        public string _INCOME_ID { get; set; } = null;
        public string _DESCR { get; set; } = null;
        public decimal _PAY0 { get; set; } = 0.0M;
        public decimal _TAXED { get; set; } = 0.0M;
        public decimal _NOSAI { get; set; } = 0.0M;
        public decimal _NOTTAXED { get; set; } = 0.0M;
        public decimal _AUTHORS_FEE { get; set; } = 0.0M;
        public Int16 _SIRATETP { get; set; } = 0;
        public decimal _SIRATEDD { get; set; } = 0.0M;
        public decimal _SIRATEDN { get; set; } = 0.0M;
        public decimal _SIDD { get; set; } = 0.0M;
        public decimal _SIDN { get; set; } = 0.0M;
        public decimal _IINEX_PERC { get; set; } = 0.0M;
        public decimal _IINEX { get; set; } = 0.0M;
        public decimal _IIN_FROM { get; set; } = 0.0M;
        public decimal _IIN_RATE { get; set; } = 0.0M;
        public decimal _IIN { get; set; } = 0.0M;
        public decimal _CASH { get; set; } = 0.0M;

    }
}
