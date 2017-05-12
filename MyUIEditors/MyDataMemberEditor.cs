using System.Reflection;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms.Design;

namespace MyUIEditors
{
    public class RelatedDataSourceAttribute : Attribute
    {
        public string DataSourcePorpertyName { get; set;} = null;

        public RelatedDataSourceAttribute(string dataSourcePorpName)
        {
            DataSourcePorpertyName = dataSourcePorpName;
        }
    }

    public class MyDataMemberFieldEditor : UITypeEditor
    {
        private object designBindingPicker;

        public override bool IsDropDownResizable
        {
            get
            {
                return true;
            }
        }

        public bool GetPublicPropertyValue(object obj, string propname, out object value)
        {
            value = null;
            if (obj == null || string.IsNullOrEmpty(propname)) return false;
            var prop = obj.GetType().GetProperty(propname);
            if (prop == null) return false;
            try
            {
                value = prop.GetValue(obj, null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null && context.Instance != null)
            {
                object obj1 = null;
                string dataSourcePropertyName = null;
                for (int i = 0; i < context.PropertyDescriptor.Attributes.Count; i++)
                {
                    var attr = context.PropertyDescriptor.Attributes[i];
                    if (attr.GetType().Name == "RelatedDataSourceAttribute")
                    {
                        if (GetPublicPropertyValue(attr, "DataSourcePorpertyName", out obj1))
                        {
                            dataSourcePropertyName = (string) obj1;
                            break;
                        }
                    }
                }
                if (dataSourcePropertyName == null) return value;

                object dataSource;
                if (!GetPublicPropertyValue(context.Instance, (string) dataSourcePropertyName, out dataSource))
                    return value;

                var asm = Assembly.GetAssembly(typeof (AnchorEditor));
                if (designBindingPicker == null)
                {

                    var tp = asm.GetType("System.Windows.Forms.Design.DesignBindingPicker");
                    designBindingPicker = Activator.CreateInstance(tp);
                }

                var tpdb = asm.GetType("System.Windows.Forms.Design.DesignBinding");
                object oldSelection = Activator.CreateInstance(tpdb, (object)dataSource, (string)value);
                //DesignBinding oldSelection = new DesignBinding(dataSource, (string)value);
                var mPick = designBindingPicker.GetType().GetMethod("Pick");
                object newSelection = mPick.Invoke(designBindingPicker, new object[]
                {
                    context, provider, false, true, false,
                    dataSource, String.Empty, oldSelection
                });

                //object newSelection = designBindingPicker.Pick(
                //    context, provider, false, true, false, dataSource, String.Empty, oldSelection);

                if (dataSource != null && newSelection != null)
                {
                    var pDataMember = tpdb.GetProperty("DataMember");
                    value = pDataMember.GetValue(newSelection, null);
                }

            }
            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }
}