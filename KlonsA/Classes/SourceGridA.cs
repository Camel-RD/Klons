using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SourceGrid;
using ContentAlignment = DevAge.Drawing.ContentAlignment;
using DevAge.Drawing;
using KlonsLIB.Forms;

namespace KlonsA.Classes
{
    public class SourceGridA : SourceGrid.Grid
    {
        public SourceGridAViewModel gridViewModel = null;

        public SourceGridA() 
        {
            gridViewModel = new SourceGridAViewModel(this);
        }

        private SizeF scaleFactor = new SizeF(1.0f, 1.0f);
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            ScaleControlA(factor);
            scaleFactor.Width *= factor.Width;
            scaleFactor.Height *= factor.Height;
            this.DefaultHeight = (int)Math.Round((float)this.DefaultHeight * (float)factor.Height);
        }

        protected void ScaleControlA(SizeF factor)
        {
            float width = factor.Width;
            float height = factor.Height;
            if (width != 1.0f)
            {
                foreach (var c in Columns)
                {
                    var ci = c as ColumnInfo;
                    ci.Width = (int)Math.Round((double)ci.Width * (double)width);
                }
            }
            if (height != 1.0f)
            {
                /*
                foreach (var r in Rows)
                {
                    var ri = r as RowInfo;
                    ri.Height = (int)Math.Round((double)ri.Height * (double)height);
                }*/
            }

            Dictionary<Control, bool> cd = new Dictionary<Control, bool>();

            for (int i = 0; i < Rows.Count; i++)
            {
                for (int j = 0; j < Columns.Count; j++)
                {
                    var c1 = GetCell(i, j);
                    if (c1 == null) continue;
                    var ed = c1.Editor;
                    if (ed == null) continue;
                    if (ed is SourceGrid.Cells.Editors.EditorControlBase)
                    {
                        var edc = (ed as SourceGrid.Cells.Editors.EditorControlBase).Control;
                        if (edc == null) continue;
                        if (cd.ContainsKey(edc)) continue;
                        cd[edc] = true;
                        edc.Scale(factor);
                    }
                }

            }
            foreach (var lc in LinkedControls)
            {
                if (FindForm().Contains(lc.Control)) continue;
                lc.Control.Scale(factor);
            }
            ArrangeLinkedControls();
        }

        public void ApplyColorTheme(MyColorTheme mycolortheme)
        {
            this.ForeColor = mycolortheme.GetColor(this.ForeColor, mycolortheme.ControlTextColor);
            this.BackColor = mycolortheme.GetColor(this.BackColor, mycolortheme.ControlColor);
            Color wc = mycolortheme.WindowColor;
            Color gc = mycolortheme.ControlColorDark;
            gridViewModel.SetColors(this.ForeColor, this.BackColor, wc, gc);
            Refresh();
        }

    }


    public class SourceGridAViewModel
    {
        public SourceGrid.Cells.Views.Cell captionModel = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell dayCellModel = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell dayCellModelLeft = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell dayCellModelWeekend = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell dayCellModelHollyday = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell dayCellModelHollydayLeft = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell dayCellModelHollydayWeekend = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell dayCellModelOut = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell dayCellModelOutLeft = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell dayCellModelOutWeekend = new SourceGrid.Cells.Views.Cell();

        public RectangleBorder DefaultBorder;
        public RectangleBorder DefaultBorder3;
        public RectangleBorder DefaultBorderF;

        public Color ForeColor;
        public Color BackColor;
        public Color WindowColor;
        public Color GridColor;
        public Color CaptionColor;
        public Color WeekendBackColor;
        public Color HollydayBackColor;
        public Color HollydayForeColor;
        public Color OutForeColor;

        public SourceGridAViewModel(SourceGridA mygrid)
        {
            ForeColor = mygrid.ForeColor;
            BackColor = mygrid.BackColor;
            GridColor = ForeColor;
            ApplyColors();
        }

        public void ApplyColors()
        {
            GridColor = ColorThemeHelper.ColorBetween(WindowColor, ForeColor, 0.5f);
            CaptionColor = ColorThemeHelper.ColorBetween(BackColor, ForeColor, 0.3f);
            WeekendBackColor = ColorThemeHelper.ColorBetween(BackColor, ForeColor, 0.1f);
            HollydayBackColor = ColorThemeHelper.ColorBetween(BackColor, ForeColor, 0.2f);
            HollydayForeColor = ColorThemeHelper.ColorBetween(Color.FromArgb(250, 0, 0), ForeColor, 0.3f);
            OutForeColor = ColorThemeHelper.ColorBetween(BackColor, ForeColor, 0.7f);

            var ln = new BorderLine(GridColor, 1);
            DefaultBorderF = new RectangleBorder(ln, ln, ln, ln);
            DefaultBorder3 = new RectangleBorder(BorderLine.NoBorder, ln, ln, ln);
            DefaultBorder = new RectangleBorder(ln, ln);

            captionModel.ForeColor = ForeColor;
            captionModel.BackColor = CaptionColor;
            captionModel.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            captionModel.Border = DefaultBorderF;

            dayCellModel.ForeColor = ForeColor;
            dayCellModel.BackColor = BackColor;
            dayCellModel.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            dayCellModel.Border = DefaultBorder;

            dayCellModelLeft.ForeColor = ForeColor;
            dayCellModelLeft.BackColor = BackColor;
            dayCellModelLeft.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            dayCellModelLeft.Border = DefaultBorder3;

            dayCellModelWeekend.ForeColor = ForeColor;
            dayCellModelWeekend.BackColor = WeekendBackColor;
            dayCellModelWeekend.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            dayCellModelWeekend.Border = DefaultBorder;

            dayCellModelHollyday.ForeColor = HollydayForeColor;
            dayCellModelHollyday.BackColor = BackColor;
            dayCellModelHollyday.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            dayCellModelHollyday.Border = DefaultBorder;

            dayCellModelHollydayLeft.ForeColor = HollydayForeColor;
            dayCellModelHollydayLeft.BackColor = BackColor;
            dayCellModelHollydayLeft.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            dayCellModelHollydayLeft.Border = DefaultBorder3;

            dayCellModelHollydayWeekend.ForeColor = HollydayForeColor;
            dayCellModelHollydayWeekend.BackColor = WeekendBackColor;
            dayCellModelHollydayWeekend.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            dayCellModelHollydayWeekend.Border = DefaultBorder;

            dayCellModelOut.ForeColor = OutForeColor;
            dayCellModelOut.BackColor = BackColor;
            dayCellModelOut.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            dayCellModelOut.Border = DefaultBorder;

            dayCellModelOutLeft.ForeColor = OutForeColor;
            dayCellModelOutLeft.BackColor = BackColor;
            dayCellModelOutLeft.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            dayCellModelOutLeft.Border = DefaultBorder3;

            dayCellModelOutWeekend.ForeColor = OutForeColor;
            dayCellModelOutWeekend.BackColor = WeekendBackColor;
            dayCellModelOutWeekend.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            dayCellModelOutWeekend.Border = DefaultBorder;
        }

        public void SetColors(Color forecolr, Color backColor, Color windowColor, Color gridColor)
        {
            this.ForeColor = forecolr;
            this.BackColor = backColor;
            this.WindowColor = windowColor;
            ApplyColors();
        }

    }

}
