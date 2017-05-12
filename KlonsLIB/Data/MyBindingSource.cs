using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using KlonsLIB.Components;
using System;

namespace KlonsLIB.Data
{
    public class MyBindingSource : MyBindingSource2, IMyPropertyValueListProvider
    {
        private string _myDataSource = "";


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                if (!string.IsNullOrEmpty(_myDataSource)) return;
                base.DataSource = value;
            }
        }

        [DefaultValue("")]
        [Category("Data")]
        [Editor(typeof(MyDropDownPropertyEditor), typeof(UITypeEditor))]
        public string MyDataSource
        {
            get { return _myDataSource; }
            set
            {
                if (value == _myDataSource) return;
                if (string.IsNullOrEmpty(value))
                {
                    _myDataSource = "";
                    base.DataSource = null;
                    return;
                }
                DataSet ds = KlonsDataModule.St.GetDataSet(value);
                if (ds == null)
                {
                    _myDataSource = "";
                    base.DataSource = null;
                    return;
                }
                _myDataSource = value;
                base.DataSource = ds;
            }
        }

        string[] IMyPropertyValueListProvider.GetPropertyValueList(string propname)
        {
            if (propname == "MyDataSource")
                return KlonsDataModule.GetAllDataSetNames();
            else
                return null;
        }

        public MyBindingSource() : base()
        {
        }


        public MyBindingSource(System.ComponentModel.IContainer container) : this() {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            container.Add(this);
        }

        public MyBindingSource(object dataSource, string dataMember) : base(dataSource, dataMember) 
        {

        }

    }


}
