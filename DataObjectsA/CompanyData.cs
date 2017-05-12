using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotyfyProp;

namespace DataObjectsA
{
    [NotyfyProp.NotifyPropertyChanged(Filter = "_", Serialize = false, Browsable = true)]
    public class CompanyData : BindableComponent
    {
        public string _CompName { get; set; } = null;
        public string _CompRegNr { get; set; } = null;
        public string _CompRegNrPVN { get; set; } = null;
        public string _CompVID { get; set; } = null;
        public string _CompAddr { get; set; } = null;
        public string _CompAddrInd { get; set; } = null;
        public string _CompAddr1 { get; set; } = null;
        public string _CompAddr2 { get; set; } = null;
        public string _CompAddr3 { get; set; } = null;
        public string _CompAddr4 { get; set; } = null;
        public string _CompAddrG { get; set; } = null;
        public string _CompMName { get; set; } = null;
        public string _CompMpk { get; set; } = null;
        public string _CompPhone { get; set; } = null;
        public string _CompAccName { get; set; } = null;
        public string _CompAccPh { get; set; } = null;
        public string _BankId { get; set; } = null;
        public string _BankName { get; set; } = null;
        public string _BankAcc { get; set; } = null;
    }
}
