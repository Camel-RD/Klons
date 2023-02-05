using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotyfyProp;

namespace DataObjectsFM
{
    public class InventoryDocData : BindableComponent
    {
        public int _ID { get; set; }
        public DateTime _DT { get; set; }
        public string _NR { get; set; }
        public int _STATE { get; set; }
        public int _IDSTORE { get; set; }
        public string _PERSONS { get; set; }
        public int _IDSTORE_NOR { get; set; } = 1;
        public int _IDSTORE_PIER { get; set; } = 1;
        public string _NR_NOR { get; set; }
        public string _NR_PIER { get; set; }
    }
}
