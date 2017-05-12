using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SourceGrid;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Models;
using KlonsLIB.MySourceGrid.GridRows;

namespace KlonsLIB.MySourceGrid
{
    public class DataCellController : ControllerBase
    {
        public DataCellController(MyGridRowPropEditorBase gridrow)
        {
            BindValueAtProperty(gridrow);
        }

        public override void OnValueChanged(CellContext sender, EventArgs e)
        {
            base.OnValueChanged(sender, e);
            if (m_MyGridRow == null) return;
            m_MyGridRow.UpdateDataSource();
            m_MyGridRow.Grid.OnValueChanged(m_MyGridRow, e);
        }

        private MyGridRowPropEditorBase m_MyGridRow = null;

        protected virtual void BindValueAtProperty(MyGridRowPropEditorBase gridrowt)
        {
            m_MyGridRow = gridrowt;
        }

        protected virtual void UnBindValueAtProperty()
        {
            m_MyGridRow = null;
        }

        public override void OnEditStarting(CellContext sender, System.ComponentModel.CancelEventArgs e)
        {
            var grid = m_MyGridRow?.Grid;
            if (grid != null && !grid.AllowEdit) e.Cancel = true;
            base.OnEditStarting(sender, e);
            if (grid == null) return;
            m_MyGridRow.Grid.OnEditStarting(m_MyGridRow, e);
        }

        public override void OnEditStarted(CellContext sender, System.EventArgs e)
        {
            base.OnEditStarted(sender, e);
            if (m_MyGridRow == null || m_MyGridRow.Grid == null) return;
            m_MyGridRow.Grid.OnEditStarted(m_MyGridRow, e);
        }

        public override void OnEditEnded(CellContext sender, System.EventArgs e)
        {
            base.OnEditEnded(sender, e);
            if (m_MyGridRow == null || m_MyGridRow.Grid == null) return;
            m_MyGridRow.Grid.OnEditEnded(m_MyGridRow, e);
        }
    }
}
