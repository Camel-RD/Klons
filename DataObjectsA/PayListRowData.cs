using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotyfyProp;

namespace DataObjectsA
{
    [NotyfyProp.NotifyPropertyChanged(Filter = "_", Serialize = false, Browsable = true)]
    public class PayListRowData : BindableComponent
    {
        public int _ID { get; set; } = 0;
        public int _IDS { get; set; } = 0;
        public int _IDP { get; set; } = 0;
        public int _IDAM { get; set; } = 0;
        public int _SNR { get; set; } = 0;
        public decimal _PAY0 { get; set; } = 0.0M;
        public decimal _IIN0 { get; set; } = 0.0M;
        public decimal _ADVANCE0 { get; set; } = 0.0M;
        public decimal _WITHHOLDINGS0 { get; set; } = 0.0M;
        public decimal _TPAY0 { get; set; } = 0.0M;
        public decimal _PAY { get; set; } = 0.0M;
        public decimal _IIN { get; set; } = 0.0M;
        public decimal _ADVANCE { get; set; } = 0.0M;
        public decimal _WITHHOLDINGS { get; set; } = 0.0M;
        public decimal _TPAY { get; set; } = 0.0M;
        public decimal _PAY_REVERSE { get; set; } = 0.0M;
        public decimal _IIN_REVERSE { get; set; } = 0.0M;
        public DateTime? _DT1 { get; set; } = null;
        public DateTime? _DT2 { get; set; } = null;
        public Single _R1 { get; set; } = 0.0f;
        public Single _R2 { get; set; } = 0.0f;
        public decimal _S0 { get; set; } = 0.0M;
        public decimal _S1 { get; set; } = 0.0M;
        public decimal _S2 { get; set; } = 0.0M;
    }
}
