using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KlonsLIB.Misc;

namespace KlonsLIB.Components
{
    public class MyTextBox : TextBox
    {
        private ContextMenu m_ContextMenu;

        private bool m_DrawBorder = true;
        private Color m_BorderColor = SystemColors.ControlDarkDark;

        public MyTextBox()
        {
            //SetStyle(ControlStyles.DoubleBuffer, true);
            base.BorderStyle = BorderStyle.FixedSingle;

            m_ContextMenu = new ContextMenu();
            m_ContextMenu.Popup += ContextMenu_PopUp;
            var miUndo = new MenuItem("Undo", Undo_Click);
            var miCut = new MenuItem("Cut", Cut_Click);
            var miCopy = new MenuItem("Copy", Copy_Click);
            var miPaste = new MenuItem("Paste", Paste_Click);
            var miSelectAll = new MenuItem("Select All", SelectAll_Click);
            miUndo.Name = "Undo";
            miCut.Name = "Cut";
            miCopy.Name = "Copy";
            miPaste.Name = "Paste";
            miSelectAll.Name = "SelectAll";
            m_ContextMenu.MenuItems.Add(miUndo);
            m_ContextMenu.MenuItems.Add("-");
            m_ContextMenu.MenuItems.Add(miCut);
            m_ContextMenu.MenuItems.Add(miCopy);
            m_ContextMenu.MenuItems.Add(miPaste);
            m_ContextMenu.MenuItems.Add("-");
            m_ContextMenu.MenuItems.Add(miSelectAll);
            this.ContextMenu = m_ContextMenu;
        }

        private void ContextMenu_PopUp(object sender, EventArgs e)
        {
            m_ContextMenu.MenuItems["Undo"].Enabled = this.CanUndo;

            bool b = this.SelectedText.Length > 0;
            m_ContextMenu.MenuItems["Cut"].Enabled = b;
            m_ContextMenu.MenuItems["Copy"].Enabled = b;

            m_ContextMenu.MenuItems["Paste"].Enabled = Clipboard.ContainsText();

            m_ContextMenu.MenuItems["SelectAll"].Enabled = this.Text.Length > 0;
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            this.Undo();
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            this.SelectAll();
        }


        [Category("Behavior")]
        [DefaultValue(false)]
        public bool IsDate { get; set; } = false;


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

        [Category("Appearance")]
        [DefaultValue(BorderStyle.FixedSingle)]
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set 
            {
                if (value == BorderStyle.Fixed3D)
                    value = BorderStyle.FixedSingle;
                base.BorderStyle = value; 
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NM.WM_PAINT:
                    base.WndProc(ref m);
                    if (!DrawBorder) break;
                    if (BorderStyle != BorderStyle.FixedSingle) break;
                    using (var gdc = Graphics.FromHwnd(Handle))
                    {
                        PaintFlatControlBorder(gdc);
                    }
                    break;
                /*
                case NM.WM_NCPAINT:
                    base.WndProc(ref m);
                    if (!DrawBorder) break;
                    IntPtr hWnd = this.Handle;
                    IntPtr hRgn = IntPtr.Zero;
                    IntPtr hdc = NM.GetDCEx(hWnd, hRgn, 1027);
                    using (var gdc = Graphics.FromHdc(hdc))
                    {
                        PaintFlatControlBorder(this, gdc);
                    }
                    NM.ReleaseDC(hWnd, hdc);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
                */
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        public static Color Dark(Color baseColor)
        {
            return ControlPaint.Dark(baseColor, 0.5f);
        }

        protected void PaintFlatControlBorder(Graphics g, bool forcepaint = false)
        {
            if (!forcepaint)
            {
                if (!DrawBorder) return;
                if (BorderStyle != BorderStyle.FixedSingle) return;
            }

            Rectangle rect;

            rect = new Rectangle(0, 0, Width, Height);
            //rect = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);

            if (Enabled)
                ControlPaint.DrawBorder(g, rect, m_BorderColor, ButtonBorderStyle.Solid);
            else
                ControlPaint.DrawBorder(g, rect, Dark(m_BorderColor), ButtonBorderStyle.Solid);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("\t");
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.SelectAll();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
            if (e.Cancel) return;
            if (IsDate)
            {
                DateTime dt;
                if (string.IsNullOrEmpty(this.Text)) return;
                if (!Utils.StringToDate(this.Text, out dt))
                {
                    e.Cancel = true;
                }
                else
                {
                    var tx = Utils.DateToString(dt);
                    if (this.Text != tx)
                        this.Text = tx;
                }
            }
            
        }


    }
}
