using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SourceGrid.Cells;

namespace KlonsLIB.MySourceGrid.GridRows
{
    public enum EMyGridRowCommands
    {
        None, StartNewColumn
    }

    public class MyGridRowCommand : MyGridRowBase
    {
        public MyGridRowCommand(string name, string title) : base(name, title)
        {
            RowType = EMyGridRowType.Command;
        }
        public MyGridRowCommand()
        {
            RowType = EMyGridRowType.Command;
            RowValueType = EMyGridRowValueType.None;
        }

        public EMyGridRowCommands Command { get; set; } = EMyGridRowCommands.None;

        [DefaultValue(false)]
        [Category("ColumnWidths")]
        public bool SetColumnWidth { get; set; } = false;

        [DefaultValue(-1)]
        [Category("ColumnWidths")]
        public int CaptionColumnWidth { get; set; } = -1;

        [DefaultValue(-1)]
        [Category("ColumnWidths")]
        public int DataColumnWidth { get; set; } = -1;

        public override int GetRowCount() => 0;

        public override void MakeRow(SourceGrid.GridRow gridrow, int colnr)
        {
            Grid = gridrow.Grid as MyGrid;
            RowNr = gridrow.Index;
            ColNr = colnr;
        }

    }
}
