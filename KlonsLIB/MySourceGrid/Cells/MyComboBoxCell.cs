using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevAge.ComponentModel;
using KlonsLIB.Components;
using KlonsLIB.Misc;
using SourceGrid;
using SourceGrid.Cells.Editors;
using KlonsLIB.MySourceGrid.GridRows;

namespace KlonsLIB.MySourceGrid.Cells
{
    [System.ComponentModel.ToolboxItem(false)]
    public class MyComboBoxCell : EditorControlBase
    {
        public MyComboBoxCell(Type p_Type) : base(p_Type)
        {
        }

        protected override Control CreateControl()
        {
            MyGridComboBox editor = new MyGridComboBox();
            editor.FlatStyle = FlatStyle.Flat;
            editor.Validator = this;

            return editor;
        }

        public new MyGridComboBox Control
        {
            get
            {
                return (MyGridComboBox)base.Control;
            }
        }

        public override void SetEditValue(object editValue)
        {
            Control.Value = editValue;
            if(Control.Value != null && string.IsNullOrEmpty(Control.Text))
            {

            }
            Control.SelectAll();
        }

        public override object GetEditedValue()
        {
            return Control.Value;
        }

        protected override void OnSendCharToEditor(char key)
        {
            if (Control.DropDownStyle != MyMcComboBox.CustomDropDownStyle.DropDownListSimple)
            {
                if (Control.Focused)
                {
                    SendKeys.Send(key.ToString());
                }
                else
                {
                    Control.Text = key.ToString();
                    if (Control.Text != null)
                        Control.SelectionStart = Control.Text.Length;
                }
            }
        }

        public MyGridRowPropEditorBase Row { get; set; } = null;

        protected override void OnConvertingValueToDisplayString(ConvertingObjectEventArgs e)
        {
            object evalue = e.Value;
            if (evalue == DBNull.Value)
                evalue = null;


            if (Row != null && Row.NoData ||
                string.IsNullOrEmpty(Control.DisplayMember) ||
                string.IsNullOrEmpty(Control.ValueMember))
            {
                //if(Control.IsInUpdateX)
                /*
                if (evalue == null)
                    //e.Value = this.NullDisplayString;
                    e.Value = Control.Text;
                else
                {
                    e.Value = Control.Text;
                }*/
                e.Value = "";
                e.ConvertingStatus = ConvertingStatus.Completed;
                return;
            }


            object item = null;
            object val;
            int k = -1;

            if(evalue != null)
                k = Control.Items.IndexOf(e.Value);

            if (k < 0)
            {
                k = Utils.FindValue(Control.Items, Control.ValueMember, e.Value);
            }

            if (k >= 0)
            {
                item = Control.Items[k];
            }
            else if (Control.DataSource as IList != null)
            {
                k = Utils.FindValue(Control.DataSource as IList, Control.ValueMember, e.Value);
                if(k >= 0)
                    item = (Control.DataSource as IList)[k];
            }
        
            if (item != null)
            {
                if (Utils.GetPublicPropertyValue(item, Control.DisplayMember, out val))
                {
                    if (val == null)
                        e.Value = null;
                    else
                        e.Value = val.ToString();
                    e.ConvertingStatus = ConvertingStatus.Completed;
                    return;
                }
                else
                {
                    e.ConvertingStatus = ConvertingStatus.Error;
                }
            }
            else
            {
                if(evalue == null || (evalue is string && (string)evalue == ""))
                {
                    e.Value = this.NullString;
                    e.ConvertingStatus = ConvertingStatus.Completed;
                    return;
                }

                e.Value = "?";
                e.ConvertingStatus = ConvertingStatus.Completed;

                //e.ConvertingStatus = ConvertingStatus.Error;
            }

        }
    }
}

