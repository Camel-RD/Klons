using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;

namespace MyUIEditors
{

    public class MyCollectionEditor : CollectionEditor
    {
        public MyCollectionEditor(Type type) : base(type)
        {

        }

        private object editedObject = null;

        public override Object EditValue(ITypeDescriptorContext context, IServiceProvider provider, Object value)
        {
            editedObject = value;
            return base.EditValue(context, provider, value);
        }

        protected override bool CanSelectMultipleInstances()
        {
            return false;
        }

        protected override object CreateInstance(Type itemType)
        {
            object o = base.CreateInstance(itemType);
            object owner = editedObject;
            if (o != null && owner != null)
            {
                var met = owner.GetType().GetMethod("OnNewItem");
                if (met != null)
                {
                    try
                    {
                        met.Invoke(owner, new[]{o});
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
            return o;
        }

        protected override Type[] CreateNewItemTypes()
        {
            var o = Context.Instance;
            if (o != null)
            {
                var met = o.GetType().GetMethod("GetTypesForCollectionEditor");
                var propname = Context.PropertyDescriptor.Name;
                if (met != null)
                {
                    try
                    {
                        var types = met.Invoke(o, new[] { propname}) as Type[];
                        return types;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }

            var tp = this.CollectionItemType;
            if (tp == null) return null;
            return (new[] { tp }).Concat(tp.Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(tp)))
                .ToArray();
        }
    }
}
