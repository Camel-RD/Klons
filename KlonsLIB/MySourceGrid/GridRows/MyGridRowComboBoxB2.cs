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
                var grid = this.GridRow.Grid as MyGrid;
                return grid[this.GridRow.Index + 1, 1];
            }
        }

        public override void MakeRow(SourceGrid.GridRow gridrow)
        {
            this.GridRow = gridrow;
            if (gridrow != null)
                this.Grid = gridrow.Grid as MyGrid;
            int i = GridRow.Index;

            MakeFirstCell();
            var caption = MakeCaptionCell();
            caption.SetSpan(1, 2);

            MakeFirstCell(1);
            var datacell = MakeDataCell();
            Grid[i + 1, 1] = datacell;
            datacell.SetSpan(1, 2);
            MyEditor = datacell.Editor;
        }

    }
}
