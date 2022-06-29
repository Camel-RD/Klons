using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace KlonsLIB.Components
{
    public class DataGridViewColorMarkColumn : DataGridViewTextBoxColumn
    {
        public event DataGridViewColorMarkColumnEvent ColorMarkNeeded;

        public DataGridViewColorMarkColumn()
        {
            CellTemplate = new DataGridViewColorMarkCell();
        }

        public bool GetColorMark(int row, out Color c)
        {
            c = Color.White;
            if (ColorMarkNeeded == null) return false;
            var ea = new DataGridViewColorMarkColumnEventArgs(c, row);
            ColorMarkNeeded(this, ea);
            c = ea.MarkColor;
            return true;
        }
    }

    public class DataGridViewColorMarkColumnEventArgs : EventArgs
    {
        public Color MarkColor = Color.White;
        public int RowNr = -1;
        public DataGridViewColorMarkColumnEventArgs(Color c, int rnr)
        {
            MarkColor = c;
            RowNr = rnr;
        }
    }

    public delegate void DataGridViewColorMarkColumnEvent(object sender, DataGridViewColorMarkColumnEventArgs e);


    public class DataGridViewColorMarkCell : DataGridViewTextBoxCell
    {
        public DataGridViewColorMarkCell()
        {
        }

        protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                var col = this.OwningColumn as DataGridViewColorMarkColumn;
                Color markcolor = cellStyle.ForeColor;
                bool hasmark = col.GetColorMark(rowIndex, out markcolor);
                Brush markColorBrush = new SolidBrush(markcolor);

                int rsz = this.DataGridView.RowTemplate.Height - 8;
                rsz = (int)((double)rsz * 0.8d);
                int dy = (cellBounds.Height - rsz) / 2 - 1;
                int dx = dy;

                cellStyle.Padding = new Padding(cellStyle.Padding.Left + rsz + dx,
                    cellStyle.Padding.Top, cellStyle.Padding.Right, cellStyle.Padding.Bottom);

                base.Paint(g, clipBounds, cellBounds,
                    rowIndex, cellState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, paintParts);

                g.FillEllipse(markColorBrush, cellBounds.X + dx, cellBounds.Y + dy, rsz, rsz);
            }
            catch (Exception e) { }

        }

    }

}
