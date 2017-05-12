using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Afterthought;

namespace NotyfyProp
{
    // After build
    //$(SolutionDir)Afterthought.Amender/Afterthought.Amender.exe "$(TargetPath)" $(TargetDir)NotyfyProp.dll"
    //$(SolutionDir)Afterthought.Amender/Afterthought.Amender.exe "$(ProjectDir)obj\$(ConfigurationName)\$(TargetFileName)" $(TargetDir)NotyfyProp.dll"

    public class NotifyPropertyChangedAttribute : Attribute
    {
        public string Filter;
        public bool Serialize;
        public bool Browsable;

        public NotifyPropertyChangedAttribute()
        {
            Filter = null;
            Serialize = false;
            Browsable = true;
        }
    }

    public interface INotifyPropertyChangedAmendment : INotifyPropertyChanged
    {
        void OnPropertyChanged(PropertyChangedEventArgs args);
    }

    public static class NotificationAmender<T>
    {
        public static void OnPropertyChanged<P>(INotifyPropertyChangedAmendment instance, string property, P oldValue, P value, P newValue)
        {
            // Only raise property changed if the value of the property actually changed
            if ((oldValue == null ^ newValue == null) || (oldValue != null && !oldValue.Equals(newValue)))
                instance.OnPropertyChanged(new PropertyChangedEventArgs(property));
        }
    }

    public class NotificationAmendment<T> : Afterthought.Amendment<T, INotifyPropertyChangedAmendment>
    {
        public NotificationAmendment()
        {
            string filter = null;
            bool serialize = false;
            bool browsable = true;

            var atr1 = this.Type.GetCustomAttributes(true).OfType<NotifyPropertyChangedAttribute>().ToArray();
            if (atr1.Length > 0)
            {
                filter = atr1[0].Filter;
                serialize = atr1[0].Serialize;
                browsable = atr1[0].Browsable;
            }

            var props = Properties
                .Where(p =>
                    p.PropertyInfo.CanRead &&
                    p.PropertyInfo.CanWrite &&
                    p.PropertyInfo.GetSetMethod().IsPublic &&
                    (filter == null || p.PropertyInfo.Name.Substring(0, filter.Length) == filter));

            props.AfterSet(NotificationAmender<T>.OnPropertyChanged);

            if (!browsable)
            {
                var props2 = props.Where(p =>
                    p.Attributes.OfType<BrowsableAttribute>().Count() == 0);
                
                props2.AddAttribute<BrowsableAttribute, bool>(false);

            }
            if (!serialize)
            {
                var props3 = props.Where(p =>
                    p.Attributes.OfType<DesignerSerializationVisibility>().Count() == 0);

                props3.AddAttribute<DesignerSerializationVisibilityAttribute, DesignerSerializationVisibility>(
                        DesignerSerializationVisibility.Hidden);
            }

        }
    }

    public class NotificationAmenderAttribute : Attribute, IAmendmentAttribute
    {

        private string[] TypeNames = null;

        public NotificationAmenderAttribute(params string[] typenames)
        {
            TypeNames = typenames;
        }

        IEnumerable<ITypeAmendment> IAmendmentAttribute.GetAmendments(Type target)
        {
            var inf = target.GetInterface("NotyfyProp.INotifyPropertyChangedAmendment");
            if (inf != null)
                yield return (ITypeAmendment)typeof(NotificationAmendment<>).MakeGenericType(target).GetConstructor(Type.EmptyTypes).Invoke(new object[0]);

        }
    }

}
