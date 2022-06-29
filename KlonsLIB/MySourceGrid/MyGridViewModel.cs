using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DevAge.Drawing;
using KlonsLIB.Forms;
using ContentAlignment = DevAge.Drawing.ContentAlignment;

namespace KlonsLIB.MySourceGrid
{
    public class MyGridViewModel
    {
        public SourceGrid.Cells.Views.Cell titleModel = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell titleModel2 = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell titleDataCellModel = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell rowHeaderModel = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell captionModel = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell dataCellModel = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell dataCellMultiLineModel = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell dataCellModelAllignRight = new SourceGrid.Cells.Views.Cell();
        public SourceGrid.Cells.Views.Cell dataCellCheckBox = new SourceGrid.Cells.Views.CheckBox();
        public Cells.MyCheckBoxView dataCellCheckBox2 = new Cells.MyCheckBoxView();
        public SourceGrid.Cells.Views.Cell rowHeaderModelRed = new SourceGrid.Cells.Views.Cell();

        public RectangleBorder DefaultBorder;
        public RectangleBorder DefaultBorder3;
        public RectangleBorder DefaultBorderF;

        public Color ForeColor;
        public Color BackColor;
        public Color WindowColor;
        public Color GridColor;

        public MyGridViewModel(MyGrid mygrid)
        {
            ForeColor = mygrid.ForeColor;
            BackColor = mygrid.BackColor;
            WindowColor = mygrid.BackColor2;
            GridColor = ForeColor;

            ApplyColors();
        }

        public void ApplyColors()
        {
            GridColor = ColorThemeHelper.ColorBetween(WindowColor, ForeColor, 0.5f);
            var ln = new BorderLine(GridColor, 1);
            DefaultBorderF = new RectangleBorder(ln, ln, ln, ln);
            DefaultBorder3 = new RectangleBorder(BorderLine.NoBorder, ln, ln, ln);
            DefaultBorder = new RectangleBorder(ln, ln);

            titleModel.ForeColor = ForeColor;
            titleModel.BackColor = ColorThemeHelper.ColorBetween(BackColor, ForeColor, 0.1f);
            titleModel.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            titleModel.Border = DefaultBorderF;

            titleModel2.ForeColor = ForeColor;
            titleModel2.BackColor = BackColor;
            titleModel2.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            titleModel2.Border = DefaultBorder;

            titleDataCellModel.ForeColor = ForeColor;
            titleDataCellModel.BackColor = titleModel.BackColor;
            titleDataCellModel.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            titleDataCellModel.Border = DefaultBorderF;

            rowHeaderModel.ForeColor = ForeColor;
            rowHeaderModel.BackColor = BackColor;
            rowHeaderModel.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            rowHeaderModel.Border = DefaultBorder3;

            rowHeaderModelRed.ForeColor = Color.White;
            rowHeaderModelRed.BackColor = Color.IndianRed;
            rowHeaderModelRed.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            rowHeaderModelRed.Border = DefaultBorder3;

            captionModel.ForeColor = ForeColor;
            captionModel.BackColor = BackColor;
            captionModel.Border = DefaultBorder;

            dataCellModel.ForeColor = ForeColor;
            dataCellModel.BackColor = WindowColor;
            dataCellModel.Border = DefaultBorder;

            dataCellMultiLineModel.ForeColor = ForeColor;
            dataCellMultiLineModel.BackColor = WindowColor;
            dataCellMultiLineModel.Border = DefaultBorder;
            dataCellMultiLineModel.TextAlignment = ContentAlignment.TopLeft;
            dataCellMultiLineModel.WordWrap = true;

            dataCellModelAllignRight.ForeColor = ForeColor;
            dataCellModelAllignRight.BackColor = WindowColor;
            dataCellModelAllignRight.TextAlignment = ContentAlignment.MiddleRight;
            dataCellModelAllignRight.Border = DefaultBorder;

            dataCellCheckBox.ForeColor = ForeColor;
            dataCellCheckBox.BackColor = WindowColor;
            dataCellCheckBox.Border = DefaultBorder;

            dataCellCheckBox2.ForeColor = ForeColor;
            dataCellCheckBox2.BackColor = WindowColor;
            dataCellCheckBox2.Border = DefaultBorder;
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
