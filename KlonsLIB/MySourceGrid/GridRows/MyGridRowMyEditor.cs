using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlonsLIB.MySourceGrid.GridRows
{
    public class MyGridRowMyEditor : MyGridRowPropEditorBase
    {

        private SourceGrid.Cells.Editors.EditorControlBase mCellEditor = null;

        public SourceGrid.Cells.Editors.EditorControlBase CellEditor
        {
            get { return mCellEditor; }
        }

        public MyGridRowMyEditor(string name, string title, string propname,
            string gridpropname, EMyGridRowValueType valtyp,
            SourceGrid.Cells.Editors.EditorControlBase celleditor)
            : base(name, title, gridpropname, EMyGridRowType.ComboBox, valtyp)
        {
            mCellEditor = celleditor;
        }

        public MyGridRowMyEditor()
        {
            RowType = EMyGridRowType.Control;
            RowValueType = EMyGridRowValueType.None;
        }


        public override void MakeRow(SourceGrid.GridRow gridrow, int colnr)
        {
            var grid = Grid = gridrow.Grid as MyGrid;
            RowNr = gridrow.Index;
            ColNr = colnr;
            int i = RowNr;

            SourceGrid.Cells.Cell cbcell = null;

            switch (RowValueType)
            {
                case EMyGridRowValueType.String:
                    cbcell = new SourceGrid.Cells.Cell(null, typeof(string));
                    break;
                case EMyGridRowValueType.Double:
                    cbcell = new SourceGrid.Cells.Cell(0.0d, typeof(double));
                    break;
                case EMyGridRowValueType.Integer:
                    cbcell = new SourceGrid.Cells.Cell(0, typeof(int));
                    break;
            }

            MakeFirstCell();
            grid[i, CaptionColumnNr] = new SourceGrid.Cells.Cell(RowTitle);
            grid[i, CaptionColumnNr].View = grid.gridViewModel.captionModel;
            grid[i, DataColumnNr] = cbcell;
            cbcell.Editor = mCellEditor;
            cbcell.View = grid.gridViewModel.dataCellModel;
        }

    }

}
