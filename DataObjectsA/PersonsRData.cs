using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotyfyProp;

namespace DataObjectsA
{
    public class PersonsRData : BindableComponent
    {
        public int _ID { get; set; } = 0;
        public int _IDP { get; set; } = 0;
        public DateTime _EDIT_DATE { get; set; } = DateTime.MinValue;
        public string _FNAME { get; set; } = null;
        public string _LNAME { get; set; } = null;
        public string _NAME_DATIVE { get; set; } = null;
        public string _NAME_ACCUSATIVE { get; set; } = null;
        public Int16 _GENDER { get; set; } = 0;
        public string _PERSON_CODE { get; set; } = null;
        public DateTime _BIRTH_DATE { get; set; } = DateTime.MinValue;
        public string _ADDRESS { get; set; } = null;
        public string _CITY { get; set; } = null;
        public string _STATE { get; set; } = null;
        public string _COUNTRY { get; set; } = null;
        public string _POSTAL_CODE { get; set; } = null;
        public string _TERRITORIAL_CODE { get; set; } = null;
        public string _PHONE { get; set; } = null;
        public string _EMAIL { get; set; } = null;
        public string _COMMENTS { get; set; } = null;
        public int? _BANK_ID { get; set; } = null;
        public string _BANK_ACC { get; set; } = null;
        public string _PASSPORT_NO { get; set; } = null;
        public string _PASSPORT_ISSUER { get; set; } = null;
        public DateTime? _PASSPORT_DATE { get; set; } = null;
        public string _TAXDOC_SERIAL { get; set; } = null;
        public string _TAXDOC_NO { get; set; } = null;
        public string _TAXDOC_ISSUER { get; set; } = null;
        public string _TAXREG_NO { get; set; } = null;
        public Int16 _INVALID { get; set; } = 0;
        public Int16 _PENSIONER { get; set; } = 0;
        public Int16 _PRISONER { get; set; } = 0;
        public Int16 _REPRES { get; set; } = 0;
        public Int16 _PRET { get; set; } = 0;
        public Int16 _APGAD_SK { get; set; } = 0;
        public Int16 _PRISONER_SP { get; set; } = 0;
        public Int16 _NOT_OSA { get; set; } = 0;
        public decimal _PAY0 { get; set; } = 0.0M;
        public decimal _IIN0 { get; set; } = 0.0M;
        public decimal _ADVANCE { get; set; } = 0.0M;
        public float _VACATION_DAYS { get; set; } = 0.0f;

    }
}
