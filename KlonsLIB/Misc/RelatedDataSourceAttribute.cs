using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlonsLIB.Misc
{
    public class RelatedDataSourceAttribute : Attribute
    {
        public string DataSourcePorpertyName { get; set; } = null;

        public RelatedDataSourceAttribute(string dataSourcePorpName)
        {
            DataSourcePorpertyName = dataSourcePorpName;
        }
    }

}
