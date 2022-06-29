using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SourceGrid;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Models;
using KlonsLIB.MySourceGrid.GridRows;
using System.Windows.Forms;

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

        public override void OnKeyDown(CellContext sender, KeyEventArgs e)
        {
            base.OnKeyDown(sender, e);
            if (m_MyGridRow == null || m_MyGridRow.Grid == null) return;
            if (sender.IsEditing()) return;
            if (sender.Cell != m_MyGridRow.DataCell) return;
            if(e.KeyCode == Keys.F4)
            {
                if (m_MyGridRow is MyGridRowPickRowTextBox grpick)
                {
                    e.Handled = true;
                    grpick.Control_ButtonClicked(grpick, EventArgs.Empty);
                    return;
                }
                if (m_MyGridRow is MyGridRowComboBoxA grcba)
                {
                    sender.StartEdit();
                    if (sender.IsEditing())
                    {
                        e.Handled = true;
                        grcba.ComboBoxEditor.Control.DroppedDown = true;
                        return;
                    }
                }
                if (m_MyGridRow is MyGridRowComboBoxB grcbb)
                {
                    sender.StartEdit();
                    if (sender.IsEditing())
                    {
                        e.Handled = true;
                        grcbb.ComboBoxEditor.Control.DroppedDown = true;
                        return;
                    }
                }
                if (m_MyGridRow is MyGridRowComboBoxB2 grcbb2)
                {
                    sender.StartEdit();
                    if (sender.IsEditing())
                    {
                        e.Handled = true;
                        grcbb2.ComboBoxEditor.Control.DroppedDown = true;
                        return;
                    }
                }
            }

            m_MyGridRow.Grid.OnKeyDownCell(m_MyGridRow, e);
        }
    }
}
