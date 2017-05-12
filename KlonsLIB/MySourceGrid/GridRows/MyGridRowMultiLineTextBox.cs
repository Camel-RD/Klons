using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceGrid;
using System.ComponentModel;

namespace KlonsLIB.MySourceGrid.GridRows
{
    public class MyGridRowMultiLineTextBox : MyGridRowPropEditorBase, ICustomConversionSupport
    {
        public MyGridRowMultiLineTextBox(string name, string title, string propname, string gridpropname, EMyGridRowValueType valtyp)
            : base(name, title, gridpropname, EMyGridRowType.TextBox, valtyp)
        {
            rowSpan = 3;
        }
        public MyGridRowMultiLineTextBox()
        {
            RowType = EMyGridRowType.TextBox;
            RowValueType = EMyGridRowValueType.String;
            rowSpan = 3;
        }

        [DefaultValue(EMyGridRowValueType.String)]
        public override EMyGridRowValueType RowValueType
        {
            get
            {
                return EMyGridRowValueType.String;
            }
            set
            { }
        }

        [DefaultValue(3)]
        public override int RowSpan
        {
            get
            {
                return rowSpan;
            }
            set
            {
                if (value < 1) value = 1;
                if (value == rowSpan) return;
                rowSpan = value;
            }
        }

        [Category("Data")]
        [DefaultValue(false)]
        public bool CustomConversions { get; set; } = false;
        private ValueMappingB ValueMapping = null;

        public override void MakeRow(SourceGrid.GridRow gridrow)
        {
            GridRow = gridrow;
            Grid = GridRow.Grid as MyGrid;
            int i = GridRow.Index;

            var datacell = MakeDataCell();
            Grid[i, 0] = datacell;
            datacell.SetSpan(RowSpan, 3);
            MyEditor = datacell.Editor;
        }

        public override SourceGrid.Cells.Cell MakeDataCell()
        {
            SourceGrid.Cells.Cell textcell = null;
            SourceGrid.Cells.Editors.TextBox sharededitor = null;

            var sharededitor1 = GetSharedEditor();
            if (sharededitor1 != null)
            {
                sharededitor = sharededitor1 as SourceGrid.Cells.Editors.TextBox;
                if (sharededitor1 == null)
                {
                    throw new Exception("Wrong shared editor type.");
                }

            }

            if (sharededitor != null)
            {
                textcell = new SourceGrid.Cells.Cell(GetDefaultValue());
                textcell.Editor = sharededitor;
            }
            else
            {
                textcell = new SourceGrid.Cells.Cell(GetDefaultValue(), GetValueType());
                var editor = new SourceGrid.Cells.Editors.TextBox(GetValueType());
                textcell.Editor = editor;
                editor.Control.Multiline = true;
                editor.Control.WordWrap = true;
                editor.Control.AcceptsReturn = true;
                editor.Control.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

                var tc = GetMyTypeConverter();
                if (tc != null)
                    textcell.Editor.TypeConverter = tc;

                //if (CustomConversions)
                    ValueMapping = new ValueMappingB(textcell.Editor, this);

            }

            textcell.RowSpan = RowSpan;
            textcell.View = Grid.gridViewModel.dataCellMultiLineModel;


            return textcell;
        }

        public override void UnLinkRow()
        {
            if (ValueMapping != null && MyEditor != null)
                ValueMapping.UnBindValidator(MyEditor);
        }

    }
}
