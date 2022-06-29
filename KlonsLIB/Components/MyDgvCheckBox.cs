using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using KlonsLIB.Misc;

namespace KlonsLIB.Components
{
    public class MyDgvCheckBoxColumn : DataGridViewCheckBoxColumn
    {
        public MyDgvCheckBoxColumn() : base(false)
        {
            CellTemplate = new MyDgvCheckBoxCell();
        }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value != null && !(value is MyDgvCheckBoxCell))
                {
                    throw new InvalidCastException("Must be a MyDgvCheckBoxCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class MyDgvCheckBoxCell : DataGridViewCheckBoxCell
    {
        private static bool PaintBorder(DataGridViewPaintParts paintParts)
        {
            return (paintParts & DataGridViewPaintParts.Border) != 0;
        }
        
        private static bool PaintSelectionBackground(DataGridViewPaintParts paintParts)
        {
            return (paintParts & DataGridViewPaintParts.SelectionBackground) != 0;
        }

        private static bool PaintBackground(DataGridViewPaintParts paintParts)
        {
            return (paintParts & DataGridViewPaintParts.Background) != 0;
        }

        internal static bool PaintFocus(DataGridViewPaintParts paintParts)
        {
            return (paintParts & DataGridViewPaintParts.Focus) != 0;
        }

        private SolidBrush GetCachedBrush(Color color)
        {
            var br = Utils.CallMethod(this.DataGridView, "GetCachedBrush", color) as SolidBrush;
            return br;
        }


        protected override void Paint(
            Graphics g, 
            Rectangle clipBounds, 
            Rectangle cellBounds, 
            int rowIndex, 
            DataGridViewElementStates elementState, 
            object value, 
            object formattedValue, 
            string errorText, 
            DataGridViewCellStyle cellStyle, 
            DataGridViewAdvancedBorderStyle advancedBorderStyle, 
            DataGridViewPaintParts paintParts)
        {
            //base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            Rectangle valBounds = cellBounds;
            Rectangle borderWidths = BorderWidths(advancedBorderStyle);
            valBounds.Offset(borderWidths.X, borderWidths.Y);
            valBounds.Width -= borderWidths.Right;
            valBounds.Height -= borderWidths.Bottom;

            Point ptCurrentCell = this.DataGridView.CurrentCellAddress;

            CheckState checkState;
            bool ischecked;

            if (formattedValue != null && formattedValue is CheckState)
            {
                checkState = (CheckState)formattedValue;
                ischecked = checkState == CheckState.Checked;
            }
            else if (formattedValue != null && formattedValue is bool)
            {
                if ((bool)formattedValue)
                {
                    checkState = CheckState.Checked;
                    ischecked = true;
                }
                else
                {
                    checkState = CheckState.Unchecked;
                    ischecked = false;
                }
            }
            else
            {
                //wrong state
                checkState = CheckState.Unchecked;
                ischecked = false;
            }

            bool cellSelected = (elementState & DataGridViewElementStates.Selected) != 0;

            var backcolor =
                PaintSelectionBackground(paintParts) && cellSelected ?
                cellStyle.SelectionBackColor :
                cellStyle.BackColor;
            var forecolor =
                cellSelected ?
                cellStyle.SelectionForeColor:
                cellStyle.ForeColor;

            if (PaintBorder(paintParts))
            {
                PaintBorder(g, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            }

            SolidBrush br = GetCachedBrush(backcolor);

            if (PaintBackground(paintParts))
            {
                g.FillRectangle(br, valBounds);
            }

            if (PaintFocus(paintParts) &&
                //this.DataGridView.ShowFocusCues &&
                this.DataGridView.Focused &&
                ptCurrentCell.X == this.ColumnIndex &&
                ptCurrentCell.Y == rowIndex)
            {
                ControlPaint.DrawFocusRectangle(g, valBounds, Color.Empty, br.Color);
            }

            int checkboxsize = cellStyle.Font.Height - 2;
            int x1 = valBounds.X + valBounds.Width / 2;
            int y1 = valBounds.Y + valBounds.Height / 2;
            int x2 = x1 - checkboxsize / 2;
            int y2 = y1 - checkboxsize / 2;

            //var checkMarkLineFill = new Rectangle(x2, y2, checkboxsize, checkboxsize);
            using (var checkmarkPath = MyCheckBox.CreateRoundRect(x2, y2, checkboxsize, checkboxsize, (float)checkboxsize / 10f))
            {
                using(var pen = new Pen(forecolor))
                {
                    g.DrawPath(pen, checkmarkPath);
                }
            }
            if (ischecked)
            {
                var line = MyCheckBox.ScaleAndMoveCheckmarkLine(checkboxsize, x2, y2);
                using (var pen2 = new Pen(forecolor, 2))
                {
                    g.DrawLines(pen2, line);
                }
            }

        }
    }
}
