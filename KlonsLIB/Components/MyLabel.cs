using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KlonsLIB.Misc;

namespace KlonsLIB.Components
{
    public class MyLabel : Label
    {
        private bool m_DrawBorder = true;
        private Color m_BorderColor = SystemColors.ControlDarkDark;

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool DrawBorder
        {
            get { return m_DrawBorder; }
            set
            {
                m_DrawBorder = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get { return m_BorderColor; }
            set
            {
                m_BorderColor = value;
                Invalidate();
            }
        }

        public new FlatStyle FlatStyle
        {
            get { return base.FlatStyle; }
            set { ; }
        }


        public MyLabel()
        {
            //SetStyle(ControlStyles.DoubleBuffer, true);
            base.FlatStyle = FlatStyle.Flat;
            Padding = new Padding(2);
        }

        protected override void WndProc(ref Message m)
        {
            IntPtr hDC = IntPtr.Zero;
            Graphics gdc = null;
            switch (m.Msg)
            {
                case NM.WM_PAINT:
                    base.WndProc(ref m);
                    if (FlatStyle != FlatStyle.Flat || !DrawBorder) break;
                    // flatten the border area again
                    //hDC = GetWindowDC(this.Handle);
                    //gdc = Graphics.FromHdc(hDC);
                    using (gdc = Graphics.FromHwnd(Handle))
                    {
                        //Pen p = new Pen((this.Enabled ? BackColor : SystemColors.Control), 2);
                        //gdc.DrawRectangle(p, new Rectangle(2, 2, this.Width - 3, this.Height - 3));
                        PaintFlatControlBorder(this, gdc);
                        //ReleaseDC(m.HWnd, hDC);
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        public static Color Dark(Color baseColor)
        {
            return ControlPaint.Dark(baseColor, 0.5f);
        }

        private void PaintFlatControlBorder(Control ctrl, Graphics g)
        {
            if (!DrawBorder) return;
            if (BorderStyle == BorderStyle.Fixed3D) return;

            Rectangle rect;
            
            if(BorderStyle == BorderStyle.None)
                rect = new Rectangle(0, 0, ctrl.Width, ctrl.Height);
            else
                rect = new Rectangle(-1, -1, ctrl.Width + 1, ctrl.Height + 1);

            if (ctrl.Enabled)
                ControlPaint.DrawBorder(g, rect, m_BorderColor, ButtonBorderStyle.Solid);
            else
                ControlPaint.DrawBorder(g, rect, Dark(m_BorderColor), ButtonBorderStyle.Solid);
        }


    }
}
