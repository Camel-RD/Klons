using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KlonsLIB.MySourceGrid.GridRows
{
    public class MyGridRowWithControl : MyGridRowBase
    {

        private Control cellControl = null;

        [Category("Editor")]
        [DefaultValue(null)]
        [TypeConverter(typeof(ReferenceConverter))]
        public Control CellControl
        {
            get { return cellControl; }
            set { cellControl = value; }
        }

        public MyGridRowWithControl(string name, string title, Control cellcontrol)
            : base(name, title)
        {
            RowType = EMyGridRowType.Control;
            cellControl = cellcontrol;
        }

        public MyGridRowWithControl()
        {

        }

        public override void MakeRow(SourceGrid.GridRow gridrow, int colnr)
        {
            Grid = gridrow.Grid as MyGrid;
            int i = RowNr = gridrow.Index;

            int h = cellControl.Height + 6;
            int k = (int)Math.Ceiling((float)h / (float)gridrow.Height) - 1;

            cellControl.Location = new Point(0, 0);

            //gridrow.Height = mCellControl.Height + 6;
            if (Grid.RowHeadersUsed)
            {
                Grid[i, RowHeaderColumnNr] = new SourceGrid.Cells.Cell("control cell");
                Grid[i, RowHeaderColumnNr].SetSpan(k + 1, 3);
                Grid.LinkedControls.Add(new SourceGrid.LinkedControlValue(cellControl, new SourceGrid.Position(i, RowHeaderColumnNr)));
            }
            else
            {
                Grid[i, CaptionColumnNr] = new SourceGrid.Cells.Cell("control cell");
                Grid[i, CaptionColumnNr].SetSpan(k + 1, 2);
                Grid.LinkedControls.Add(new SourceGrid.LinkedControlValue(cellControl, new SourceGrid.Position(i, CaptionColumnNr)));
            }
        }

    }

}
