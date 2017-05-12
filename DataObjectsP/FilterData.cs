using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotyfyProp;

namespace DataObjectsP
{
    [NotyfyProp.NotifyPropertyChanged(Filter = "f", Serialize = false, Browsable = true)]
    public class FilterData : BindableComponent
    {
        public DateTime? fDATE1 { get; set; } = null;
        public DateTime? fDATE2 { get; set; } = null;
        public int? fEVENT { get; set; } = null;
        public int? fCAT1 { get; set; } = null;
        public int? fCATD { get; set; } = null;
        public int? fCATT { get; set; } = null;
        public int? fPLACE { get; set; } = null;
        public int? fDEPARTMENT { get; set; } = null;
        public int? fSTATE { get; set; } = null;
    }
}
