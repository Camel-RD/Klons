using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace KlonsLIB.Components
{
    public partial class TabControlWithoutHeader : TabControl
    {
        public TabControlWithoutHeader()
        {
        }

        [DefaultValue(false)]
        [Category("Behavior")]
        public bool ShowTabStrip { get; set; } = false;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !DesignMode && !ShowTabStrip)
                m.Result = (IntPtr)1;
            else
                base.WndProc(ref m);
        }
    }
}
