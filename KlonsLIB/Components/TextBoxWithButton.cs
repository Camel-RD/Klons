using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KlonsLIB.Misc;

namespace KlonsLIB.Components
{
    public class TextBoxWithButton : MyTextBox
    {
        private bool m_ShowButton = false;

        [Category("Appearance")]
        [DefaultValue(false)]
        public bool ShowButton
        {
            get { return m_ShowButton; }
            set
            {
                m_ShowButton = value;
                Invalidate();
            }
        }

        protected Rectangle GetButtonRect()
        {
            int bw = 2;
            if (BorderStyle == BorderStyle.None) bw = 0;
            else if (BorderStyle == BorderStyle.FixedSingle) bw = 1;
            var mrect = new Rectangle(ClientRectangle.Right, bw,
                Width - ClientSize.Width - bw, Height - 2 * bw);
            return mrect;
        }

        private void AdjustClientRect(ref NM.RECT rcClient)
        {
            int h = rcClient.Bottom - rcClient.Top;
            int w = (int)((double)h * 0.7d);
            rcClient.Right -= w;
        }

        public event EventHandler ButtonClicked;

        protected virtual void OnButtonClicked(EventArgs e)
        {
            ButtonClicked?.Invoke(this, e);
        }

        private Color Light(Color color, float r)
        {
            var c = HslColor.Lighter(color, r);
            return c;
        }

        protected override void WndProc(ref Message m)
        {
            Rectangle mrect;
            switch (m.Msg)
            {
                case NM.WM_NCPAINT:
                    base.WndProc(ref m);
                    if (!m_ShowButton) break;

                    mrect = GetButtonRect();
                    var mrect2 = mrect;
                    int dw = (int)((double)mrect2.Width * 0.3d);
                    int dh = (int)((double)mrect2.Height * 0.4d);
                    mrect2.Inflate(-dw, -dh);
                    int x1 = mrect2.Left;
                    int x2 = (mrect2.Left + mrect2.Right) / 2;
                    int x3 = mrect2.Right;
                    int y1 = mrect2.Top;
                    int y2 = mrect2.Bottom;

                    IntPtr hWnd = this.Handle;
                    IntPtr hRgn = IntPtr.Zero;
                    IntPtr hdc = NM.GetDCEx(hWnd, hRgn, 1027);
                    Color bc = Light(BackColor, 0.1f);
                    using (var gdc = Graphics.FromHdc(hdc))
                    {
                            using (var sb = new SolidBrush(bc))
                            {
                                gdc.FillRectangle(sb, mrect);
                            }
                        using (var pen = new Pen(ForeColor, 1))
                        {
                            gdc.DrawLine(pen, x1, y1, x2, y2);
                            gdc.DrawLine(pen, x2, y2, x3, y1);
                        }
                        bool fp = !DrawBorder && BorderStyle != BorderStyle.None;
                        PaintFlatControlBorder(gdc, fp);
                    }

                    NM.ReleaseDC(hWnd, hdc);
                    break;

                case NM.WM_PAINT:
                    base.WndProc(ref m);
                    if (!m_ShowButton) break;
                    if (!DrawBorder) break;
                    if (BorderStyle != BorderStyle.FixedSingle) break;
                    int x = ClientRectangle.Right - 1;
                    using (var gdc = Graphics.FromHwnd(Handle))
                    {
                        using (var pen = new Pen(BackColor, 1))
                        {
                            gdc.DrawLine(pen, x, 0, x, Height);
                        }
                    }
                    break;

                case NM.WM_NCCALCSIZE:
                    base.WndProc(ref m);
                    if (!m_ShowButton) break;

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

                case NM.WM_NCLBUTTONDOWN:
                    base.WndProc(ref m);
                    if (!m_ShowButton) break;

                    if (Enabled && m.LParam != IntPtr.Zero)
                    {
                        int px = NM.SignedLOWORD(m.LParam);
                        int py = NM.SignedHIWORD(m.LParam);
                        mrect = GetButtonRect();
                        var mrectd = RectangleToScreen(mrect);
                        if (mrectd.Contains(px, py))
                        {
                            OnButtonClicked(EventArgs.Empty);
                        }
                    }
                    break;

                case NM.WM_NCHITTEST:
                    base.WndProc(ref m);
                    if (!m_ShowButton) break;

                    int ret = m.Result.ToInt32();
                    if (ret == 0 || ret == 1)
                    {
                        if (m.LParam != IntPtr.Zero)
                        {
                            int px = NM.SignedLOWORD(m.LParam);
                            int py = NM.SignedHIWORD(m.LParam);
                            mrect = GetButtonRect();
                            var mrectd = RectangleToScreen(mrect);
                            if (mrectd.Contains(px, py))
                            {
                                m.Result = (IntPtr)18;
                            }
                        }

                    }
                    break;


                default:
                    base.WndProc(ref m);
                    break;
            }


        }
    }
}
