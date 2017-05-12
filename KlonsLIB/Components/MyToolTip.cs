using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlonsLIB.Components
{
    public class MyToolTip : ToolTip
    {
        private static int TOOLTIP_XOFFSET = 0;
        private static int TOOLTIP_YOFFSET = 0;

        public MyToolTip()
        {
            this.OwnerDraw = true;
            this.Popup += new PopupEventHandler(this.OnPopup);
            this.Draw += new DrawToolTipEventHandler(this.OnDraw);
        }

        private void OnPopup(object sender, PopupEventArgs e) 
        {
            var text = this.GetToolTip(e.AssociatedControl);
            var fontsize = e.AssociatedControl.FindForm().Font.Size;
            var font = new Font(SystemFonts.DefaultFont.FontFamily, fontsize);
            e.ToolTipSize = TextRenderer.MeasureText(text, font);
            e.ToolTipSize = new Size(e.ToolTipSize.Width + TOOLTIP_XOFFSET, e.ToolTipSize.Height + TOOLTIP_YOFFSET);
            font.Dispose();
        }

        private void OnDraw(object sender, DrawToolTipEventArgs e) 
        {
            Rectangle bounds = e.Bounds;
            bounds.Offset(TOOLTIP_XOFFSET, TOOLTIP_YOFFSET);
            var br = new SolidBrush(this.ForeColor);
            var fontsize = e.AssociatedControl.FindForm().Font.Size;
            var font = new Font(SystemFonts.DefaultFont.FontFamily, fontsize);

            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, font, br, TOOLTIP_XOFFSET, TOOLTIP_YOFFSET);

            br.Dispose();
            font.Dispose();
        }
    }
}
