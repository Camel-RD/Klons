using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotyfyProp;

namespace DataObjectsP
{
    public class ItemsEventsData : BindableComponent
    {
        public int fID { get; set; } = 0;
        public int fIDIT { get; set; } = 0;

        public string fITEM_REG_NR { get; set; } = null;
        public string fITEM_NAME { get; set; } = null;
        public DateTime? fITEM_DATE1 { get; set; } = null;
        public DateTime? fITEM_DATE2 { get; set; } = null;

        public int fSNR { get; set; } = 0;
        public int fEVENT { get; set; } = 0;
        public DateTime fDT { get; set; } = DateTime.MinValue;
        public DateTime fDTREG { get; set; } = DateTime.MinValue;
        public string fDESCR { get; set; } = "";
        public string fDOCNR { get; set; } = "";
        public int fCAT1 { get; set; } = 0;
        public int fCATD { get; set; } = 0;
        public int fCATT { get; set; } = 0;
        public int fPLACE { get; set; } = 0;
        public int fDEPARTMENT { get; set; } = 0;
        public decimal fVALUE_0 { get; set; } = 0.0M;
        public decimal fDEPREC_0 { get; set; } = 0.0M;
        public decimal fVALUE_LEFT { get; set; } = 0.0M;
        public decimal fVALUE_C { get; set; } = 0.0M;
        public decimal fDEPREC_C { get; set; } = 0.0M;
        public decimal fSELL_VALUE { get; set; } = 0.0M;
        public float fRATE_D { get; set; } = 0.0f;
        public decimal fRATE_D_MT { get; set; } = 0.0M;
        public int fMT_TOTAL { get; set; } = 0;
        public int fMT_USED { get; set; } = 0;
        public decimal fTAX_VAL { get; set; } = 0.0M;
        public decimal fTAX_VAL_LEFT { get; set; } = 0.0M;
        public decimal fTAX_VAL_C { get; set; } = 0.0M;
        public float fTAX_RATE { get; set; } = 0.0f;
        public int fTAX_EACH { get; set; } = 0;
        public string fZDT { get; set; } = null;
        public string fZU { get; set; } = null;

    }
}
