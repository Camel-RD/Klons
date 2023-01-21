using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotyfyProp;

namespace DataObjectsFM
{
    public class DocFilterData : BindableComponent
    {
        public DateTime? Dt1 { get; set; }
        public DateTime? Dt2 { get; set; }
        public int? DocType { get; set; }
        public int? DocState { get; set; }
        public int? IdStoreOut { get; set; }
        public int? IdStoreIn { get; set; }
        public int? IdStoreOutOrIn { get; set; }
    }
}
