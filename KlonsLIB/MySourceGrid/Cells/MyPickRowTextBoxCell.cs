using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevAge.ComponentModel;
using KlonsLIB.Components;
using KlonsLIB.Misc;
using SourceGrid;
using SourceGrid.Cells.Editors;
using KlonsLIB.MySourceGrid.GridRows;
using System.Windows.Forms;

namespace KlonsLIB.MySourceGrid.Cells
{
    [System.ComponentModel.ToolboxItem(false)]
    public class MyPickRowTextBoxCell : EditorControlBase
    {
        public MyPickRowTextBoxCell(Type p_Type) : base(p_Type)
        {
        }

        protected override Control CreateControl()
        {
            MyGridPickRowTextBox editor = new MyGridPickRowTextBox();
            editor.Validator = this;
            editor.SyncPosition = false;
            editor.ShowButton = true;
            return editor;
        }

        public new MyGridPickRowTextBox Control
        {
            get
            {
                return (MyGridPickRowTextBox)base.Control;
            }
        }

        public override void SetEditValue(object editValue)
        {
            Control.Value = editValue;
            if (Control.Value != null && string.IsNullOrEmpty(Control.Text))
            {
            }
            if (Control.Value == null && !string.IsNullOrEmpty(Control.Text))
            {
                Control.Text = null;
            }
            Control.SelectAll();
        }

        public override object GetEditedValue()
        {
            return Control.Value;
        }

        protected override void OnSendCharToEditor(char key)
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


            if (evalue != null)
            {
                bool rt = Control.GetDisplayTextX(evalue, out string val);
                if (rt)
                {
                    e.Value = val;
                    e.ConvertingStatus = ConvertingStatus.Completed;
                }
                else
                {
                    e.Value = evalue;
                    //e.ConvertingStatus = ConvertingStatus.Completed;
                    e.ConvertingStatus = ConvertingStatus.Error;
                }
                return;
            }

            if (ValueType.IsNullableType())
            {
                e.Value = this.NullString;
                e.ConvertingStatus = ConvertingStatus.Completed;
                return;
            }

            e.Value = "?";
            //e.ConvertingStatus = ConvertingStatus.Completed;
            e.ConvertingStatus = ConvertingStatus.Error;

        }

    }
}
