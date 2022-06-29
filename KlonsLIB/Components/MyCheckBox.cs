using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace KlonsLIB.Components
{
    public class MyCheckBox : CheckBox
    {
        private int CheckBoxSize => Font.Height;
        private int CheckBoxSizeHalf => CheckBoxSize / 2;
        private int CheckBoxInnerBoxSize => CheckBoxSize - 4;
        private int TextOffset => CheckBoxSize + 4;

        private int _boxOffset;
        private Rectangle _boxRectangle;

        [DefaultValue(true)]
        [Category("Appearance")]
        public bool DrawFocusRectangle { get; set; } = true;

        [DefaultValue(typeof(Color), "Window")]
        [Category("Appearance")]
        public override Color BackColor
        { 
            get => base.BackColor; 
            set => base.BackColor = value; 
        }

        public MyCheckBox()
        {
            BackColor = SystemColors.Window;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            _boxOffset = Height / 2 - CheckBoxSizeHalf;
            _boxRectangle = new Rectangle(_boxOffset, _boxOffset, CheckBoxSize - 1, CheckBoxSize - 1);
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var w = _boxOffset + CheckBoxSize + 2;
            if (!string.IsNullOrEmpty(Text))
            {
                using(var gr = CreateGraphics())
                {
                    w += (int)gr.MeasureString(Text, Font).Width;
                }
            }
            return new Size(w, Font.Height + 2);
        }

        private Color GetDisabledColor()
        {
            return BlendColor(BackColor, ForeColor, 0.5d);
        }

        public static GraphicsPath CreateRoundRect(float x, float y, float width, float height, float radius)
        {
            var gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2));
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height);
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(x, y + height - (radius * 2), x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            return gp;
        }

        public static Color BlendColor(Color backgroundColor, Color frontColor, double ratio)
        {
            var invRatio = 1d - ratio;
            var r = (int)((backgroundColor.R * invRatio) + (frontColor.R * ratio));
            var g = (int)((backgroundColor.G * invRatio) + (frontColor.G * ratio));
            var b = (int)((backgroundColor.B * invRatio) + (frontColor.B * ratio));
            return Color.FromArgb(r, g, b);
        }

        public static readonly Point[] CheckmarkLine = { new Point(3, 8), new Point(7, 12), new Point(14, 5) };

        public static Point[] ScaleAndMoveCheckmarkLine(int sz, int x0, int y0)
        {
            var ret = new Point[CheckmarkLine.Length];
            float f = (float)sz / 18f;
            for (int i = 0; i < CheckmarkLine.Length; i++)
            {
                var p = CheckmarkLine[i];
                int x = (int)((float)p.X * f) + x0;
                int y = (int)((float)p.Y * f) + y0;
                ret[i] = new Point(x, y);
            }
            return ret;
        }

        public static void DrawCheckBox(Graphics g, int x, int y, int sz,
            bool ischecked, SolidBrush backbrush, Pen forepen, Pen forepen2)
        {
            int sz1 = sz - 1;
            var checkMarkLineFill = new Rectangle(x, y, sz1, sz1);
            using (var checkmarkPath = CreateRoundRect(x, y, sz1, sz1, (float)sz / 10f))
            {
                //g.FillPath(brush, checkmarkPath);
                g.FillRectangle(backbrush, checkMarkLineFill);
                g.DrawPath(forepen, checkmarkPath);
            }
            if (ischecked)
            {
                //g.DrawImageUnscaledAndClipped(DrawCheckMarkBitmap(), checkMarkLineFill);
                var line = ScaleAndMoveCheckmarkLine(sz, x, y);
                g.DrawLines(forepen2, line);
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            var g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.Clear(Parent.BackColor);

            var forecolor = Enabled ? ForeColor : GetDisabledColor();
            //var backcolor = Enabled ? BackColor : GetDisabledColor(BackColor);
            var backcolor = BackColor;
            var bordercolor = BlendColor(BackColor, ForeColor, 0.3d);

            var pen = new Pen(forecolor);
            var pen2 = new Pen(forecolor, 2);
            var brush = new SolidBrush(backcolor);
            var textbrush = new SolidBrush(forecolor);

            try
            {
                DrawCheckBox(g, _boxOffset, _boxOffset, CheckBoxSize, Checked, brush, pen, pen2);

                SizeF stringSize = g.MeasureString(Text, Font);
                g.DrawString(
                    Text,
                    Font,
                    textbrush,
                    _boxOffset + TextOffset, Height / 2 - stringSize.Height / 2 + 3);

                if (DrawFocusRectangle && Focused)
                {
                    var borderrect = new Rectangle(0, 0, Width - 1, Height - 1);
                    var borderpen = new Pen(bordercolor);
                    g.DrawRectangle(borderpen, borderrect);
                    borderpen.Dispose();
                }
            }
            finally
            {
                pen.Dispose();
                pen2.Dispose();
                brush.Dispose();
                textbrush.Dispose();

            }
        }

        private Bitmap DrawCheckMarkBitmap()
        {
            var checkMark = new Bitmap(CheckBoxSize, CheckBoxSize);
            var g = Graphics.FromImage(checkMark);
            g.Clear(Color.Transparent);
            var line = ScaleAndMoveCheckmarkLine(CheckBoxSize, 0, 0);
            var forecolor = Enabled ? ForeColor : GetDisabledColor();
            using (var pen = new Pen(forecolor, 2))
            {
                g.DrawLines(pen, line);
            }
            return checkMark;
        }

        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set
            {
                base.AutoSize = value;
                if (value)
                {
                    int sz = Font.Height + 2;
                    Size = new Size(sz, sz);
                }
            }
        }

        private bool IsInCheckArea(Point location)
        {
            return _boxRectangle.Contains(location);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (DesignMode) return;

            MouseMove += (sender, args) =>
            {
                var mouselocation = args.Location;
                Cursor = IsInCheckArea(mouselocation) ? Cursors.Hand : Cursors.Default;
            };
        }

    }
}
