using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotyfyProp;

namespace DataObjectsP
{
    public class ReplacePartData : BindableComponent
    {
        public DateTime? fDATE { get; set; } = null;
        public decimal fValue { get; set; } = 0.0M;
        public string fDoc { get; set; } = null;
        public string fDescr { get; set; } = null;
        public int fMtUsed { get; set; } = 0;
        public decimal fDeprec { get; set; } = 0.0M;
        public decimal fValueLeft { get; set; } = 0.0M;
        public decimal fValueC { get; set; } = 0.0M;
        public decimal fDeprecC { get; set; } = 0.0M;
        public decimal fTaxValueC { get; set; } = 0.0M;

    }
}
