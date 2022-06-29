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

        private void AdjustClientRect(ref NM.RECT rcClient)
        {
            rcClient.Left += 1;
            rcClient.Top += 1;
            rcClient.Right -= 1;
            rcClient.Bottom -= 1;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NM.WM_NCPAINT:
                    base.WndProc(ref m);
                    if (BorderStyle == BorderStyle.None)
                    {
                        using (var gdc = Graphics.FromHwnd(Handle))
                        {
                            PaintFlatControlBorder(this, gdc);
                        }
                    }
                    break;

                case NM.WM_NCCALCSIZE:
                    base.WndProc(ref m);
                    if (m.WParam != IntPtr.Zero)
                    {
                        NM.NCCALCSIZE_PARAMS rcsize = (NM.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NM.NCCALCSIZE_PARAMS));
                        AdjustClientRect(ref rcsize.rcNewWindow);
                        Marshal.StructureToPtr(rcsize, m.LParam, false);
                    }
                    else
                    {
                        NM.RECT rcsize = (NM.RECT)Marshal.PtrToStructure(m.LParam, typeof(NM.RECT));
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
            return ControlPaint.Dark(baseColor, 0.5f);
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
