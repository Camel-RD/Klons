using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Drawing.VisualElements;
using DevAge.Drawing;

namespace KlonsLIB.MySourceGrid.Cells
{
    [Serializable]
    public class MyCheckBoxVisualElement : CheckBoxBase
    {
        public MyCheckBoxVisualElement()
        {
        }

        public MyCheckBoxVisualElement(MyCheckBoxVisualElement other)
            : base(other)
        {
            Font = other.Font;
            ForeColor = other.ForeColor;
        }

        public override object Clone()
        {
            return new MyCheckBoxVisualElement(this);
        }

        private Font mFont = Control.DefaultFont;
        public virtual Font Font
        {
            get { return mFont; }
            set { mFont = value; }
        }
        private bool ShouldSerializeFont()
        {
            return Font.ToString() != Control.DefaultFont.ToString();
        }

        private Color mForeColor = Control.DefaultForeColor;
        public virtual Color ForeColor
        {
            get { return mForeColor; }
            set { mForeColor = value; }
        }
        private bool ShouldSerializeForeColor()
        {
            return ForeColor != Control.DefaultForeColor;
        }

        protected override void OnDraw(GraphicsCache graphics, RectangleF area)
        {
            bool disabled = Style == ControlDrawStyle.Disabled;
            bool ischecked = CheckBoxState == CheckBoxState.Checked;
            Pen pen = graphics.PensCache.GetPen(ForeColor, 1f, System.Drawing.Drawing2D.DashStyle.Solid);
            Pen pen2 = graphics.PensCache.GetPen(ForeColor, 2f, System.Drawing.Drawing2D.DashStyle.Solid);

            var drawrect = Rectangle.Round(area);
            int sz = Math.Min(drawrect.Width, drawrect.Height) - 2;
            int sz2 = sz / 2;
            int x1 = drawrect.X + sz2;
            int y1 = drawrect.Y + sz2;
            int x2 = x1 - sz2;
            int y2 = y1 - sz2;

            using (var checkmarkPath = Components.MyCheckBox.CreateRoundRect(x2, y2, sz, sz, (float)sz/ 10f))
            {
                graphics.Graphics.DrawPath(pen, checkmarkPath);
            }
            if (ischecked)
            {
                var line = Components.MyCheckBox.ScaleAndMoveCheckmarkLine(sz, x2, y2);
                graphics.Graphics.DrawLines(pen2, line);
            }
        }

        protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
        {
            int sz = Font.Height;
            return new SizeF(sz, sz);
        }
    }
}
