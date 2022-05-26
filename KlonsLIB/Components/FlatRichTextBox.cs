using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KlonsLIB.Misc;

namespace KlonsLIB.Components
{

    /// <summary>
    /// RichTextBox with 1px border line when borderstyle is None
    /// and with working doublebuffered
    /// </summary>
    [ToolboxBitmap(typeof(System.Windows.Forms.RichTextBox))]
    public class FlatRichTextBox : RichTextBox
    {

        private Color m_BorderColor = SystemColors.ControlDarkDark;
        private const int WM_PAINT = 0xF;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_NCCALCSIZE = 0x0083;

        public new bool DoubleBuffered
        {
            get { return base.DoubleBuffered; }
            set { base.DoubleBuffered = value; }
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

        public FlatRichTextBox()
        {
            //SetStyle(ControlStyles.DoubleBuffer, true);
        }

        private void AdjustClientRect(ref RECT rcClient)
        {
            rcClient.Left += 1;
            rcClient.Top += 1;
            rcClient.Right -= 1;
            rcClient.Bottom -= 1;
        }

        struct RECT { public int Left, Top, Right, Bottom; }
        struct NCCALCSIZE_PARAMS
        {
            public RECT rcNewWindow;
            public RECT rcOldWindow;
            public RECT rcClient;
            IntPtr lppos;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    base.WndProc(ref m);
                    if (BorderStyle == BorderStyle.None)
                    {
                        using (var gdc = Graphics.FromHwnd(Handle))
                        {
                            PaintFlatControlBorder(this, gdc);
                        }
                    }
                    break;
                case WM_NCCALCSIZE:
                    base.WndProc(ref m);
                    if (m.WParam != IntPtr.Zero)
                    {
                        NCCALCSIZE_PARAMS rcsize = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));
                        AdjustClientRect(ref rcsize.rcNewWindow);
                        Marshal.StructureToPtr(rcsize, m.LParam, false);
                    }
                    else
                    {
                        RECT rcsize = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                        AdjustClientRect(ref rcsize);
                        Marshal.StructureToPtr(rcsize, m.LParam, false);
                    }
                    m.Result = new IntPtr(0x0300);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        public static Color Dark(Color baseColor)
        {
            return new HLSColor(baseColor).Darker(0.5f);
        }

        private void PaintFlatControlBorder(Control ctrl, Graphics g)
        {
            Rectangle rect = new Rectangle(-1, -1, ctrl.Width, ctrl.Height);
            if (ctrl.Enabled)
                ControlPaint.DrawBorder(g, rect, m_BorderColor, ButtonBorderStyle.Solid);
            else
                ControlPaint.DrawBorder(g, rect, Dark(m_BorderColor), ButtonBorderStyle.Solid);
        }

    }
}
