using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SourceGrid;

namespace KlonsLIB.MySourceGrid.GridRows
{
    public class MyGridRowCheckBox : MyGridRowPropEditorBase
    {
        [Category("Editor")]
        [DefaultValue(null)]
        public string TrueValue { get; set; } = null;

        [Category("Editor")]
        [DefaultValue(null)]
        public string FalseValue { get; set; } = null;

        public MyGridRowCheckBox(string name, string title, string propname, string gridpropname, EMyGridRowValueType valtyp)
            : base(name, title, gridpropname, EMyGridRowType.CheckBox, valtyp)
        {

        }
        public MyGridRowCheckBox()
        {
            RowType = EMyGridRowType.CheckBox;
            RowValueType = EMyGridRowValueType.ShortInt;
        }

        private object ConvertValue(string val)
        {
            if (val == null) return null;
            int intval;
            if (int.TryParse(val, out intval))
            {
                switch (RowValueType)
                {
                    case EMyGridRowValueType.Integer:
                        return intval;
                    case EMyGridRowValueType.ShortInt:
                        return (Int16)intval;
                }
                return null;
            }

            return val;
        }

        public override object Value
        {
            get
            {
                var cell = DataCell as SourceGrid.Cells.CheckBox;
                var val = (bool?) cell.Value;
                if (!val.HasValue) return null;
                if (val.Value)
                    return ConvertValue(TrueValue);
                else
                    return ConvertValue(FalseValue);
            }
            set
            {
                var cell = DataCell as SourceGrid.Cells.CheckBox;
                if (value == null)
                    cell.Value = (bool?) null;
                else if (object.Equals(value, ConvertValue(TrueValue)))
                    cell.Value = (bool?) true;
                else if (object.Equals(value, ConvertValue(FalseValue)))
                    cell.Value = (bool?) false;
                else
                    cell.Value = (bool?) null;

            }
        }

        public override SourceGrid.Cells.Cell MakeDataCell()
        {
            var checkcell = new SourceGrid.Cells.CheckBox();
            if (ReadOnly)
                checkcell.Editor.EditableMode = EditableMode.None;
            checkcell.View = Grid.gridViewModel.dataCellCheckBox;
            return checkcell;
        }
    }
}
