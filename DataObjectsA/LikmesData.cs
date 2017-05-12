using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotyfyProp;

namespace DataObjectsA
{
    public class LikmesData : BindableComponent
    {
        public DateTime _ONDATE { get; set; } = DateTime.Today;
        public decimal _IIN_LIKME { get; set; } = 0.0M;
        public decimal _SIDD_PAMATLIKME{get; set; } = 0.0M;
        public decimal _SIDN_PAMATLIKME{get; set; } = 0.0M;
        public decimal _SIDD_PENS{get; set; } = 0.0M;
        public decimal _SIDN_PENS{get; set; } = 0.0M;
        public decimal _SIDD_IZDPENS{get; set; } = 0.0M;
        public decimal _SIDN_IZDPENS{get; set; } = 0.0M;
        public decimal _SIDD_IESLODZ{get; set; } = 0.0M;
        public decimal _SIDN_IESLODZ{get; set; } = 0.0M;
        public decimal _SIDD_IESLODZ_PENS{get; set; } = 0.0M;
        public decimal _SIDN_IESLODZ_PENS{get; set; } = 0.0M;
        public decimal _NEPLIEK_MIN{get; set; } = 0.0M;
        public decimal _APGAD{get; set; } = 0.0M;
        public decimal _INVALID_12{get; set; } = 0.0M;
        public decimal _INVALID_3{get; set; } = 0.0M;
        public decimal _REPR{get; set; } = 0.0M;
        public decimal _PRET{get; set; } = 0.0M;
        public decimal _URN{get; set; } = 0.0M;
        public decimal _MIN_PAY_MONTH { get; set; } = 0.0M;
        public decimal _MIN_PAY_HOUR { get; set; } = 0.0M;
        public string _STR { get; set; } = null;
    }
}
