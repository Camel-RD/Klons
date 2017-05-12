using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceGrid;
using SourceGrid.Cells.Controllers;

namespace KlonsLIB.MySourceGrid
{
    public class MarkCurrentRowController : ControllerBase
    {
        public readonly static MarkCurrentRowController Default = new MarkCurrentRowController();
        public MarkCurrentRowController() { }
        public override void OnFocusEntering(CellContext sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnFocusEntering(sender, e);
            var grid = sender.Grid as MyGrid;
            if (grid == null) return;
            grid.MarkRow(sender.Position.Row);
        }
    }
}
