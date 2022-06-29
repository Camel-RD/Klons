using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceGrid;

namespace KlonsLIB.MySourceGrid.GridRows
{
    public enum ECellTextAllign
    {
        NotSet, Left, Right
    }

    public interface ICustomConversionSupport
    {
        bool CustomConversions { get; set; }
    }

    public class MyGridRowTextBoxA : MyGridRowPropEditorBase, ICustomConversionSupport
    {
        public MyGridRowTextBoxA(string name, string title, string propname, string gridpropname, EMyGridRowValueType valtyp)
            : base(name, title, gridpropname, EMyGridRowType.TextBox, valtyp)
        {

        }

        public MyGridRowTextBoxA()
        {
            RowType = EMyGridRowType.TextBox;
            RowValueType = EMyGridRowValueType.String;

        }

        
        [Category("Editor")]
        [DefaultValue(ECellTextAllign.NotSet)]
        public ECellTextAllign TextAllign { get; set; } = ECellTextAllign.NotSet;

        [Category("Data")]
        [DefaultValue(false)]
        public bool CustomConversions { get; set; } = false;

        [DefaultValue(true)]
        public bool RowTitleVisible { get; set; } = true;

        public override int CaptionColumnNr => RowTitleVisible ? base.CaptionColumnNr : -1;
        public override int DataColumnNr => RowTitleVisible ? base.DataColumnNr : base.CaptionColumnNr;


        private ValueMappingB ValueMapping = null;


        public override void MakeRow(SourceGrid.GridRow gridrow, int colnr)
        {
            if (RowTitleVisible)
            {
                base.MakeRow(gridrow, colnr);
                return;
            }

            Grid = gridrow.Grid as MyGrid;
            RowNr = gridrow.Index;
            ColNr = colnr;
            int i = RowNr;

            if (Grid.RowHeadersUsed)
                MakeFirstCell();
            var datacell = MakeDataCell();
            Grid[i, DataColumnNr] = datacell;
            datacell.ColumnSpan = 2;
            MyEditor = datacell.Editor;

            if (RowSpan > 1)
            {
                if (Grid.RowHeadersUsed)
                    Grid[i, RowHeaderColumnNr].SetSpan(RowSpan, 1);
                Grid[i, DataColumnNr].SetSpan(RowSpan, 2);
            }
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
                textcell = new SourceGrid.Cells.Cell(GetDefaultValue(), sharededitor);
            }
            else
            {
                var valuetype = GetValueType();
                textcell = new SourceGrid.Cells.Cell(GetDefaultValue(), valuetype);
                var tc = GetMyTypeConverter();
                if (tc != null)
                    textcell.Editor.TypeConverter = tc;
                textcell.Editor.AllowNull = AllowNull;
                if (ReadOnly)
                    textcell.Editor.EditableMode = EditableMode.None;

                //if (CustomConversions)
                    ValueMapping = new ValueMappingB(textcell.Editor, this);
                
                /*
                var dted = textcell.Editor as SourceGrid.Cells.Editors.DateTimePicker;
                if (dted != null)
                {
                    dted.Control.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                    dted.Control.CustomFormat = string.IsNullOrEmpty(FormatString) ? "dd.MM.yyyy" : FormatString;
                }*/
            }

            if(RowValueType == EMyGridRowValueType.String)
            {
                textcell.AddController(KlonsLIB.MySourceGrid.MyToolTipText.Default);
                textcell.Model.AddModel(new KlonsLIB.MySourceGrid.MyToolTipModel());
            }

            if(rowSpan > 1 && RowValueType == EMyGridRowValueType.String)
            {
                textcell.View = Grid.gridViewModel.dataCellMultiLineModel;
            }
            else if(TextAllign == ECellTextAllign.NotSet)
            {
                switch (RowValueType)
                {
                    case EMyGridRowValueType.Single:
                    case EMyGridRowValueType.Double:
                    case EMyGridRowValueType.ShortInt:
                    case EMyGridRowValueType.Integer:
                    case EMyGridRowValueType.Decimal:
                        textcell.View = Grid.gridViewModel.dataCellModelAllignRight;
                        break;
                    default:
                        textcell.View = Grid.gridViewModel.dataCellModel;
                        break;
                }
            }
            else if(TextAllign == ECellTextAllign.Left)
            {
                textcell.View = Grid.gridViewModel.dataCellModel;
            }
            else
            {
                textcell.View = Grid.gridViewModel.dataCellModelAllignRight;
            }

            return textcell;
        }

        public override void UnLinkRow()
        {
            if (ValueMapping != null && MyEditor != null)
                ValueMapping.UnBindValidator(MyEditor);
        }

    }
}
