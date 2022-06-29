using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsLIB.Misc;
using KlonsLIB.Components;
using KlonsLIB.Forms;
using KlonsLIB.MySourceGrid.Cells;
using SourceGrid;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Controllers;

namespace KlonsLIB.MySourceGrid.GridRows
{
    public class MyGridRowComboBoxB2 : MyGridRowComboBoxB
    {
        public MyGridRowComboBoxB2(string name, string title, string propname,
            string gridpropname, EMyGridRowValueType valtyp,
            ICollection values, bool limittovaluelist,
            string displaymember, string valuemember,
            string[] columnnames)
            : base(name, title, propname, gridpropname, valtyp, values, limittovaluelist,
                  displaymember, valuemember, columnnames)
        {
            rowSpan = 2;
        }

        public MyGridRowComboBoxB2() : base()
        {
            rowSpan = 2;
        }

        [DefaultValue(2)]
        public override int RowSpan
        {
            get
            {
                return rowSpan;
            }
            set
            {
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override SourceGrid.Cells.ICell DataCell
        {
            get
            {
                var grid = Grid;
                return grid[RowNr + 1, CaptionColumnNr];
            }
        }

        public override void MakeRow(SourceGrid.GridRow gridrow, int colnr)
        {
            Grid = gridrow.Grid as MyGrid;
            RowNr = gridrow.Index;
            ColNr = colnr;
            int i = RowNr;

            if (Grid.RowHeadersUsed)
            {
                MakeFirstCell();
                MakeFirstCell(1);
            }
            var caption = MakeCaptionCell();
            caption.SetSpan(1, 2);

            var datacell = MakeDataCell();
            Grid[i + 1, CaptionColumnNr] = datacell;
            datacell.SetSpan(1, 2);
            MyEditor = datacell.Editor;
        }

    }
}
