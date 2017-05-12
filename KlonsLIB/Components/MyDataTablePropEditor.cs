using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace KlonsLIB.Components
{
    public class MyDataTablePropEditor : UITypeEditor
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

            IMyDataTableListProvider items = context.Instance as IMyDataTableListProvider;

            if (items == null) return value;

            foreach (string s in items.AllDataTables)
            {
                int index = lb.Items.Add(s);
                if (s.Equals(value))
                {
                    lb.SelectedIndex = index;
                }
            }

            _editorService.DropDownControl(lb);
            if (lb.SelectedItem == null) return value;

            return lb.SelectedItem;
        }

        private void OnListBoxSelectedValueChanged(object sender, EventArgs e)
        {
            _editorService.CloseDropDown();
        }
    }

    public interface IMyDataTableListProvider
    {
        string[] AllDataTables { get; }
    }

}
