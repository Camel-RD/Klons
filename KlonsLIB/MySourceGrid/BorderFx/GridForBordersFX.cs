using DevAge.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlonsLIB.MySourceGrid
{
    public class GridForBordersFX : IGridForBordersFX
    {
        MyGrid Grid;
        public GridForBordersFX(MyGrid grid)
        {
            Grid = grid;
        }

        public int ColumnsCount => Grid.ColumnsCount;
        public int RowsCount => Grid.RowsCount;

        public BCellNormal FindCell(int col, int row)
        {
            var bordercolor = Grid.gridViewModel.GridColor;
            var cell = Grid[row, col];
            if (cell == null) return null;
            var bounds = new Rectangle(col, row, cell.ColumnSpan, cell.RowSpan);
            var ret = new BCellNormal(bounds, bordercolor);
            return ret;
        }

        public BorderLine GetEmptyGridLine()
        {
            return BorderLine.NoBorder;
        }

        public Color TranslateColor(Color color)
        {
            return color;
        }


        public SourceGrid.Cells.Cell GetCellZ(int row, int col)
        {
            var cell = Grid.GetCell(row, col) as SourceGrid.Cells.Cell;
            if (cell != null) return cell;
            int lcol = 1;
            for (int i = row; i >= 1; i--)
            {
                for (int j = col; j >= lcol; j--)
                {
                    var cell2 = Grid.GetCell(i, j) as SourceGrid.Cells.Cell;
                    if (cell2 == null) continue;
                    if (cell2.ColumnSpan >= (col - j + 1) && cell2.RowSpan >= (row - i + 1))
                        return cell2;
                    lcol = cell2.Column.Index + cell2.ColumnSpan;
                    if (lcol > col) return null;
                    break;
                }
            }
            return null;
        }

        public void CheckBordersForCell(BorderInspector inspector, SourceGrid.Cells.Cell cell)
        {
            //var bounds = new Rectangle(cell.Column.Index, cell.Row.Index, cell.ColumnSpan, cell.RowSpan);
            var borders = inspector.GetViewBorders(cell.Column.Index, cell.Row.Index);
            cell.View = cell.View.Clone() as SourceGrid.Cells.Views.IView;
            cell.View.Border = borders;
        }

        public void CheckBordsersForCells(BorderInspector inspector, int col1, int col2, int row1, int row2)
        {
            var list = new List<SourceGrid.Cells.Cell>();
            for (int i = col1; i <= col2; i++)
            {
                for (int j = row1; j <= row2; j++)
                {
                    var cell = GetCellZ(j, i);
                    if (list.Contains(cell)) continue;
                    list.Add(cell);
                }
            }
            foreach (var cell in list)
            {
                if (cell == null) continue;
                CheckBordersForCell(inspector, cell);
            }
        }

        public void CheckBordersForAllCells(BorderInspector inspector)
        {
            CheckBordsersForCells(inspector, 0, ColumnsCount - 1, 0, RowsCount - 1);
        }
    }
}
