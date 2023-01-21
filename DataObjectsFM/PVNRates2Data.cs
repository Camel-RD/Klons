using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotyfyProp;

namespace DataObjectsFM
{
    public class PVNRates2Data : BindableComponent
    {
        public int _RATES_ID { get; set; }
        public string _RATES_CODE { get; set; }
        public string _RATES_NAME { get; set; }
        public decimal _RATES_RATE { get; set; }
        public int _RATES_ISREVERSE { get; set; }
        public int _ID { get; set; }
        public int _IDRATE { get; set; }
        public int _IDTP { get; set; }
        public int _IDTRTP { get; set; }
        public int _IN_CURRENT_MTONTH { get; set; }
        public int _CHANGE_SIGN { get; set; }
        public int _BASE_DEB_FIN { get; set; }
        public string _BASE_DEB_PVN { get; set; }
        public int _BASE_CRED_FIN { get; set; }
        public string _BASE_CRED_PVN { get; set; }
        public int _PVN_DEB_FIN { get; set; }
        public string _PVN_DEB_PVN { get; set; }
        public int _PVN_CRED_FIN { get; set; }
        public string _PVN_CRED_PVN { get; set; }
        public string _BASE_TEXT { get; set; }
        public string _PVN_TEXT { get; set; }
        public int? _ID_PVNTEXT { get; set; }
    }
}
