using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using KlonsLIB.Misc;

namespace KlonsLIB.Components
{
    public class MyDropDownPropertyEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            ListBox lb = new ListBox();
            lb.SelectionMode = SelectionMode.One;
            lb.SelectedValueChanged += OnListBoxSelectedValueChanged;
            
            var listprov = context.Instance as IMyPropertyValueListProvider;
            if (listprov == null || context.PropertyDescriptor == null) return value;
            var list = listprov.GetPropertyValueList(context.PropertyDescriptor.Name);
            if (list == null) return value;
            foreach (string s in list)
            {
                int index = lb.Items.Add(s);
                if (s.Equals(value))
                {
                    lb.SelectedIndex = index;
                }
            }

            int k = lb.Items.Count + 1;
            if (k > 15) k = 12;
            lb.Height = k * 30;
            lb.Width = 300;

            _editorService.DropDownControl(lb);
            if (lb.SelectedItem == null) return value;

            return lb.SelectedItem;
        }

        private void OnListBoxSelectedValueChanged(object sender, EventArgs e)
        {
            _editorService.CloseDropDown();
        }
    }

    public interface IMyPropertyValueListProvider
    {
        string[] GetPropertyValueList(string propname);
    }

}
