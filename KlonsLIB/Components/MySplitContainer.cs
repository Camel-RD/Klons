using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace KlonsLIB.Components
{
    public class MySplitContainer : SplitContainer
    {
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            try
            {
                //splitContainerScaling = true;
                base.ScaleControl(factor, specified);

                float scale;
                if (Orientation == Orientation.Vertical)
                {
                    scale = factor.Width;
                }
                else
                {
                    scale = factor.Height;
                }

                Panel1MinSize = (int)Math.Round((float)Panel1MinSize * scale);
                Panel2MinSize = (int)Math.Round((float)Panel2MinSize * scale);
                SplitterDistance = (int)Math.Round((float)SplitterDistance * scale);
            }
            finally
            {
                //splitContainerScaling = false;
            }
        }
    }
}
