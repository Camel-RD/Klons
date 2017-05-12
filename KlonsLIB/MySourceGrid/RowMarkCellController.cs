using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceGrid;
using SourceGrid.Cells.Controllers;

namespace KlonsLIB.MySourceGrid
{
    public class RowMarkCellController : ControllerBase
    {
        public readonly static RowMarkCellController Default = new RowMarkCellController();
        public RowMarkCellController() { }
    }
}
