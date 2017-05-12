using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace KlonsLIB.Data
{
    public class MyBindingSourceToObj : BindingSource
    {
        private BindingList<object> DataObjectList = new BindingList<object>();

        public MyBindingSourceToObj() : base()
        {
            DataObjectList.Add(null);
        }

        public MyBindingSourceToObj(System.ComponentModel.IContainer container) : this() {
            if (container == null)
                throw new ArgumentNullException("container");
            container.Add(this);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                //base.DataSource = value;
            }
        }

        [Category("Data")]
        [DefaultValue(null)]
        [TypeConverter(typeof(ReferenceConverter))]
        public object MyDataSource
        {
            get { return DataObjectList[0]; }
            set
            {
                if (value == DataObjectList[0]) return;
                if (value == null)
                {
                    DataObjectList[0] = null;
                    base.DataSource = null;
                    return;
                }
                DataObjectList[0] = value;
                base.DataSource = DataObjectList;
            }
        }
    }
}
