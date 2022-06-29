using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using KlonsLIB.Components;
using System.ComponentModel;

namespace KlonsLIB.MySourceGrid.Cells
{
    [ToolboxItem(false)]
    public class MyGridPickRowTextBox : MyPickRowTextBox2
    {
        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            object val;
            if (IsValidValue(out val) == false)
            {
                e.Cancel = true;
            }
            else
            {
                if (FormatValue && Validator != null)
                {
                    Text = Validator.ValueToDisplayString(val);
                }
            }
        }

        private bool mFormatValue = false;

        [DefaultValue(false)]
        public bool FormatValue
        {
            get { return mFormatValue; }
            set { mFormatValue = value; }
        }

        private DevAge.ComponentModel.Validator.IValidator mValidator = null;

        [DefaultValue(null)]
        public DevAge.ComponentModel.Validator.IValidator Validator
        {
            get { return mValidator; }
            set
            {
                if (mValidator != value)
                {
                    if (mValidator != null)
                        mValidator.Changed -= mValidator_Changed;

                    mValidator = value;
                    mValidator.Changed += mValidator_Changed;
                    ApplyValidatorRules();
                }
            }
        }

        void mValidator_Changed(object sender, EventArgs e)
        {
            ApplyValidatorRules();
        }

        public bool IsValidValue(out object convertedValue)
        {
            object valToCheck;
            valToCheck = this.SelectedValue;

            if (Validator != null)
            {
                if (Validator.IsValidObject(valToCheck, out convertedValue))
                    return true;
                else
                    return false;
            }
            else
            {
                convertedValue = valToCheck;
                return true;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Value
        {
            get
            {
                object val;
                if (IsValidValue(out val))
                    return val;
                else
                    throw new ArgumentOutOfRangeException("Text");
            }
            set
            {
                //--- just to be sure
                //if (SelectedValue == value) return;
                SelectedValue = value;
            }
        }

        protected virtual void ApplyValidatorRules()
        {
            /*
            Items.Clear();
            if (Validator != null && Validator.StandardValues != null)
            {
                foreach (object val in Validator.StandardValues)
                    Items.Add(val);

                if (Validator.IsStringConversionSupported())
                    DropDownStyle = CustomDropDownStyle.DropDown; //ComboBoxStyle.DropDown;
                else
                    DropDownStyle = CustomDropDownStyle.DropDownList; //ComboBoxStyle.DropDownList;
            }
            */
        }

        protected void OnFormat(ListControlConvertEventArgs e)
        {
            // The method converts only to string type. 
            if (e.DesiredType != typeof(string) || Validator == null)
                return;

            e.Value = Validator.ValueToDisplayString(e.ListItem);
        }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                BorderColor = value;
            }
        }

    }

    public interface IMyDgvTextboxEditingControlEvents2
    {
        void OnButtonClicked(MyDgvTextboxEditingControl2 control);
    }

}
