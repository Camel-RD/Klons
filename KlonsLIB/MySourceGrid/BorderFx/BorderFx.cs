using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlonsLIB.MySourceGrid
{
    public class BorderLineA
    {
        public float Width = 0f;
        public Color Color = Color.Empty;
        public float Padding = 0f;

        public static BorderLineA Empty => new BorderLineA(0.0f, Color.Empty, 0.0f);

        public BorderLineA(float w, Color c, float p = 0.0f)
        {
            Width = w;
            Color = c;
            Padding = p;
        }

        public bool IsUsable => Padding == 0.0f;
        public bool IsEmptyAndUsable => Width == 0.0f && IsUsable;

        public bool IsMatchingAndUsable(BorderLineA bl)
        {
            return (IsEmptyAndUsable && bl.IsEmptyAndUsable) || 
                Width == bl.Width && Color == bl.Color &&
                IsUsable && bl.IsUsable;
        }

        public BorderLineA Clone(BorderLineA bl)
        {
            return new BorderLineA(bl.Width, bl.Color, bl.Padding);
        }

        public override bool Equals(object obj)
        {
            var borderline = obj as BorderLineA;
            if (borderline is null) return false;
            return 
                borderline.Width == Width && 
                borderline.Color == Color &&
                borderline.Padding == Padding;
        }

        public static bool operator == (BorderLineA lhs, BorderLineA rhs)
        {
            if (lhs is null && rhs is null) return true;
            if (lhs is null || rhs is null) return false;
            return 
                lhs.Width == rhs.Width && 
                lhs.Color == rhs.Color &&
                lhs.Padding == rhs.Padding;
        }

        public static bool operator != (BorderLineA lhs, BorderLineA rhs) => !(lhs == rhs);
  
    }

    public class CellBorderLines
    {
        public BorderLineA TopBorder { get; set; } = BorderLineA.Empty;
        public BorderLineA LeftBorder { get; set; } = BorderLineA.Empty;
        public BorderLineA RightBorder { get; set; } = BorderLineA.Empty;
        public BorderLineA BottomBorder { get; set; } = BorderLineA.Empty;
    }


    public class BCell
    {
        public BCell(Rectangle bounds)
        {
            Bounds = bounds;
        }

        public virtual bool IsEmptyCell => true;
        public virtual bool NoPadding => true;
        public virtual bool HasEmptyBorders => true;
        public virtual Rectangle Bounds { get; protected set; } = Rectangle.Empty;
        public virtual BorderLineA TopBorder => null;
        public virtual BorderLineA LeftBorder => null;
        public virtual BorderLineA RightBorder => null;
        public virtual BorderLineA BottomBorder => null;
    }

    public class BCellNormal : BCell
    {
        public BCellNormal(Rectangle bounds, Color bordercolor) : base(bounds)
        {
            _TopBorder = new BorderLineA(1, bordercolor);
            _LeftBorder = new BorderLineA(1, bordercolor);
            _RightBorder = new BorderLineA(1, bordercolor);
            _BottomBorder = new BorderLineA(1, bordercolor);
        }

        protected BorderLineA _TopBorder = null;
        protected BorderLineA _LeftBorder = null;
        protected BorderLineA _RightBorder = null;
        protected BorderLineA _BottomBorder = null;

        public override bool IsEmptyCell => false;
        public override bool NoPadding => _TopBorder.Padding == 0f &&
            _LeftBorder.Padding == 0f && _RightBorder.Padding == 0f &&
            _BottomBorder.Padding == 0f;
        public override bool HasEmptyBorders => _TopBorder.Width == 0f &&
            _LeftBorder.Width == 0f && _RightBorder.Width == 0f &&
            _BottomBorder.Width == 0f;

        public override BorderLineA TopBorder => _TopBorder;
        public override BorderLineA LeftBorder => _LeftBorder;
        public override BorderLineA RightBorder => _RightBorder;
        public override BorderLineA BottomBorder => _BottomBorder;
    }

    public interface IGridForBordersFX
    {
        int ColumnsCount { get; }
        int RowsCount { get; }
        BCellNormal FindCell(int col, int row);
        Color TranslateColor(Color color);
        DevAge.Drawing.BorderLine GetEmptyGridLine();
    }

    public class BorderInspectorBase
    {
        public IGridForBordersFX Grid = null;
        public bool ShowGrid = true;
        public bool DesignHeaders = true;
        public bool UseEmptyCells = true;
        public bool TestCellsUseability = false;

        public BorderInspectorBase(IGridForBordersFX grid)
        {
            Grid = grid;
        }

        public BCell GetCell(int x, int y)
        {
            var cd = Grid.FindCell(x, y);
            if (cd == null)
                return new BCell(new Rectangle(x, y, 1, 1));
            else
                return cd;
        }

        public List<BCell> GetCells(int x1, int x2, int y1, int y2)
        {
            var ret = new List<BCell>();
            int h = DesignHeaders ? 1 : 0;
            if (x1 < h) x1 = h;
            if (y1 < h) y1 = h;
            if (x2 >= Grid.ColumnsCount) x2 = Grid.ColumnsCount - 1;
            if (y2 >= Grid.RowsCount) y2 = Grid.RowsCount - 1;
            if (x1 > x2 || y1 > y2) return ret;
            for (int x = x1; x <= x2; x++)
            {
                for (int y = y1; y <= y2; y++)
                {
                    var cd = Grid.FindCell(x, y);
                    if (cd == null)
                    {
                        var bc = new BCell(new Rectangle(x, y, 1, 1));
                        ret.Add(bc);
                    }
                    else
                    {
                        if (ret.Where(d => d.Bounds == cd.Bounds).Any()) continue;
                        ret.Add(cd);
                    }
                }
            }
            return ret;
        }

        public List<BCell> GetTopCells(BCell cell)
        {
            var b = cell.Bounds;
            return GetCells(b.X, b.Right - 1, b.Y - 1, b.Y - 1);
        }

        public List<BCell> GetLeftCells(BCell cell)
        {
            var b = cell.Bounds;
            return GetCells(b.X - 1, b.X - 1, b.Y, b.Bottom - 1);
        }

        public List<BCell> GetRightCells(BCell cell)
        {
            var b = cell.Bounds;
            return GetCells(b.Right, b.Right, b.Y, b.Bottom - 1);
        }

        public List<BCell> GetBottomCells(BCell cell)
        {
            var b = cell.Bounds;
            return GetCells(b.X, b.Right - 1, b.Bottom, b.Bottom);
        }

        public bool ListHasCell(List<BCell> list, BCell cell)
        {
            return list
                .Where(x => x.Bounds == cell.Bounds)
                .Any();
        }

        public virtual bool TestTop(BCell cell, List<BCell> testedcells, ref BorderLineA bline)
        {
            throw new NotImplementedException();
        }

        public virtual bool TestLeft(BCell cell, List<BCell> testedcells, ref BorderLineA bline)
        {
            throw new NotImplementedException();
        }

        public virtual bool TestRight(BCell cell, List<BCell> testedcells, ref BorderLineA bline)
        {
            throw new NotImplementedException();
        }

        public virtual bool TestBottom(BCell cell, List<BCell> testedcells, ref BorderLineA bline)
        {
            throw new NotImplementedException();
        }

        public virtual BorderLineA GetTop(BCell cell)
        {
            throw new NotImplementedException();
        }

        public virtual BorderLineA GetLeft(BCell cell)
        {
            throw new NotImplementedException();
        }

        public virtual BorderLineA GetRight(BCell cell)
        {
            throw new NotImplementedException();
        }

        public virtual BorderLineA GetBottom(BCell cell)
        {
            throw new NotImplementedException();
        }

        public CellBorderLines GetCellBorderLines(BCell cell)
        {
            var ret = new CellBorderLines();
            ret.TopBorder = GetTop(cell);
            ret.LeftBorder = GetLeft(cell);
            ret.RightBorder = GetRight(cell);
            ret.BottomBorder = GetBottom(cell);
            return ret;
        }

        public CellBorderLines GetCellBorderLines(int x, int y)
        {
            var cell = GetCell(x, y);
            return GetCellBorderLines(cell);
        }

        public DevAge.Drawing.BorderLine ToLine(BorderLineA bl, float padding = 0f)
        {
            return new DevAge.Drawing.BorderLine()
            {
                Width = bl.Width,
                Color = Grid.TranslateColor(bl.Color),
                Padding = padding
            };
        }

        public DevAge.Drawing.RectangleBorder GetViewBorders(int x, int y)
        {
            var cell = GetCell(x, y);
            var borderlines = GetCellBorderLines(cell);
            var ret = new DevAge.Drawing.RectangleBorder();
            if (cell.IsEmptyCell)
            {
                ret.Top = ToLine(borderlines.TopBorder);
                ret.Left = ToLine(borderlines.LeftBorder);
                ret.Bottom = ToLine(borderlines.BottomBorder);
                ret.Right = ToLine(borderlines.RightBorder);
            }
            else
            {
                /*
                var cd = (cell as BCellNormal).CellData;
                ret.Top = ToLine(borderlines.TopBorder, cd.TopBorderPadding);
                ret.Left = ToLine(borderlines.LeftBorder, cd.LeftBorderPadding);
                ret.Bottom = ToLine(borderlines.BottomBorder, cd.BottomBorderPadding);
                ret.Right = ToLine(borderlines.RightBorder, cd.RightBorderPadding);
                */
                ret.Top = ToLine(borderlines.TopBorder, borderlines.TopBorder.Padding);
                ret.Left = ToLine(borderlines.LeftBorder, borderlines.LeftBorder.Padding);
                ret.Bottom = ToLine(borderlines.BottomBorder, borderlines.BottomBorder.Padding);
                ret.Right = ToLine(borderlines.RightBorder, borderlines.RightBorder.Padding);
            }
            return ret;
        }

    }


    public class BorderInspector : BorderInspectorBase
    {
        public BorderInspector(IGridForBordersFX grid) : base(grid)
        {
        }

        //true - if UseEmptyCells and border matches borders of adjacent cells or empty cells
        //true - if !UseEmptyCells and border matches borders of adjacent cells and not empty cells
        //IF true for Top and Left cells and cell border is not empty THAN it can be set empty
        //IF true for Bottom and Right cells and cell border is empty THAN it can be set to bline
        public override bool TestTop(BCell cell, List<BCell> testedcells, ref BorderLineA bline)
        {
            if (cell.IsEmptyCell)
            {
                testedcells.Add(cell);
                return true;
            }
            if (TestCellsUseability && !cell.NoPadding) return false;

            var border = cell.TopBorder;
            if (bline is null && !cell.IsEmptyCell)
                if (border.Width > 0f && border.Padding == 0f)
                    bline = border;

            var totest = GetTopCells(cell);
            if (totest.Count == 0) return false;

            testedcells.Add(cell);

            if (border.Width == 0f) return true;
            if (border.Padding > 0f) return false;

            if (bline != null)
            {
                if (border.Width > 0f && border != bline) return false;
                border = bline;
            }

            totest = totest
                .Where(x => !ListHasCell(testedcells, x))
                .ToList();
            if (totest.Count == 0) return true;

            var b1 = cell.Bounds;
            foreach (var testcell in totest)
            {
                if (ListHasCell(testedcells, testcell)) continue;
                if (testcell.IsEmptyCell)
                {
                    testedcells.Add(testcell);
                    if (UseEmptyCells) continue;
                    else return false;
                }
                if (TestCellsUseability && !testcell.NoPadding)
                {
                    testedcells.Add(testcell);
                    return false;
                }
                if (testcell.BottomBorder.Padding > 0f)
                {
                    testedcells.Add(testcell);
                    return false;
                }
                if (testcell.BottomBorder.Width > 0f && testcell.BottomBorder != border)
                {
                    testedcells.Add(testcell);
                    return false;
                }
                var b2 = testcell.Bounds;
                if (b2.Left >= b1.Left && b2.Right <= b1.Right)
                {
                    testedcells.Add(testcell);
                    continue;
                }
                if (!TestBottom(testcell, testedcells, ref bline))
                    return false;
            }
            return true;
        }

        public override bool TestLeft(BCell cell, List<BCell> testedcells, ref BorderLineA bline)
        {
            if (cell.IsEmptyCell)
            {
                testedcells.Add(cell);
                return true;
            }
            if (TestCellsUseability && !cell.NoPadding) return false;

            var border = cell.LeftBorder;
            if (bline is null && !cell.IsEmptyCell)
                if (border.Width > 0f && border.Padding == 0f)
                    bline = border;

            var totest = GetLeftCells(cell);
            if (totest.Count == 0) return false;

            testedcells.Add(cell);

            if (border.Width == 0f) return true;
            if (border.Padding > 0f) return false;

            if (bline != null)
            {
                if (border.Width > 0f && border != bline) return false;
                border = bline;
            }

            totest = totest
                .Where(x => !ListHasCell(testedcells, x))
                .ToList();
            if (totest.Count == 0) return true;

            var b1 = cell.Bounds;
            foreach (var testcell in totest)
            {
                if (ListHasCell(testedcells, testcell)) continue;
                if (testcell.IsEmptyCell)
                {
                    testedcells.Add(testcell);
                    if (UseEmptyCells) continue;
                    else return false;
                }
                if (TestCellsUseability && !testcell.NoPadding)
                {
                    testedcells.Add(testcell);
                    return false;
                }
                if (testcell.RightBorder.Padding > 0f)
                {
                    testedcells.Add(testcell);
                    return false;
                }
                if (testcell.RightBorder.Width > 0f && testcell.RightBorder != border)
                {
                    testedcells.Add(testcell);
                    return false;
                }
                var b2 = testcell.Bounds;
                if (b2.Top >= b1.Top && b2.Bottom <= b1.Bottom)
                {
                    testedcells.Add(testcell);
                    continue;
                }
                if (!TestRight(testcell, testedcells, ref bline))
                    return false;
            }
            return true;
        }

        public override bool TestRight(BCell cell, List<BCell> testedcells, ref BorderLineA bline)
        {
            if (!UseEmptyCells && cell.IsEmptyCell) return true;
            if (TestCellsUseability && !cell.IsEmptyCell && !cell.NoPadding) return false;

            var border = cell.RightBorder;
            if (bline is null && !cell.IsEmptyCell)
                if (border.Width > 0f && border.Padding == 0f)
                    bline = border;

            var totest = GetRightCells(cell);
            if (totest.Count == 0) return true;
            totest = totest
                .Where(x => !ListHasCell(testedcells, x))
                .ToList();
            if (totest.Count == 0) return true;
            testedcells.Add(cell);

            if (cell.IsEmptyCell)
            {
                var cell2 = totest[0];
                if (cell2.IsEmptyCell) return true;
                return TestLeft(cell2, testedcells, ref bline);
            }

            if (border.Padding > 0f) return false;

            if (bline != null)
            {
                if (border.Width > 0f && border != bline) return false;
                border = bline;
            }

            var b1 = cell.Bounds;
            foreach (var testcell in totest)
            {
                if (ListHasCell(testedcells, testcell)) continue;
                if (testcell.IsEmptyCell)
                {
                    testedcells.Add(testcell);
                    continue;
                }
                if (TestCellsUseability && !testcell.NoPadding && !testcell.HasEmptyBorders)
                {
                    testedcells.Add(testcell);
                    return false;
                }
                if (testcell.LeftBorder.Width == 0f)
                {
                    testedcells.Add(testcell);
                    continue;
                }
                // testcell.LeftBorder.Width > 0f
                if (testcell.LeftBorder.Padding > 0f)
                {
                    testedcells.Add(testcell);
                    return false;
                }
                if (bline == null)
                {
                    bline = testcell.RightBorder;
                }
                if (testcell.LeftBorder != bline)
                {
                    testedcells.Add(testcell);
                    return false;
                }

                var b2 = testcell.Bounds;
                if (b2.Top >= b1.Top && b2.Bottom <= b1.Bottom)
                {
                    testedcells.Add(testcell);
                    continue;
                }
                if (!TestLeft(testcell, testedcells, ref bline))
                    return false;
            }
            return true;
        }

        public override bool TestBottom(BCell cell, List<BCell> testedcells, ref BorderLineA bline)
        {
            if (!UseEmptyCells && cell.IsEmptyCell) return true;
            if (TestCellsUseability && !cell.IsEmptyCell && !cell.NoPadding) return false;

            var border = cell.BottomBorder;
            if (bline is null && !cell.IsEmptyCell)
                if (border.Width > 0f && border.Padding == 0f)
                    bline = border;

            var totest = GetBottomCells(cell);
            if (totest.Count == 0) return true;
            totest = totest
                .Where(x => !ListHasCell(testedcells, x))
                .ToList();
            if (totest.Count == 0) return true;
            testedcells.Add(cell);

            if (cell.IsEmptyCell)
            {
                var cell2 = totest[0];
                if (cell2.IsEmptyCell) return true;
                return TestTop(cell2, testedcells, ref bline);
            }

            if (border.Padding > 0f) return false;

            if (bline != null)
            {
                if (border.Width > 0f && border != bline) return false;
                border = bline;
            }

            var b1 = cell.Bounds;
            foreach (var testcell in totest)
            {
                if (ListHasCell(testedcells, testcell)) continue;
                if (testcell.IsEmptyCell)
                {
                    testedcells.Add(testcell);
                    continue;
                }
                if (TestCellsUseability && !testcell.NoPadding && !testcell.HasEmptyBorders)
                {
                    testedcells.Add(testcell);
                    return false;
                }
                if (testcell.TopBorder.Width == 0f)
                {
                    testedcells.Add(testcell);
                    continue;
                }
                // testcell.TopBorder.Width > 0f
                if (testcell.TopBorder.Padding > 0f)
                {
                    testedcells.Add(testcell);
                    return false;
                }
                if (bline == null)
                {
                    bline = testcell.TopBorder;
                }
                else if (testcell.TopBorder != bline)
                {
                    testedcells.Add(testcell);
                    return false;
                }

                var b2 = testcell.Bounds;
                if (b2.Left >= b1.Left && b2.Right <= b1.Right)
                {
                    testedcells.Add(testcell);
                    continue;
                }
                if (!TestTop(testcell, testedcells, ref bline))
                    return false;
            }
            return true;
        }

        public override BorderLineA GetTop(BCell cell)
        {
            if (cell.IsEmptyCell) return BorderLineA.Empty;
            var b = cell.TopBorder;
            if (!cell.NoPadding || b.IsEmptyAndUsable) return b;
            BorderLineA bline = null;
            if (TestTop(cell, new List<BCell>(), ref bline)) return BorderLineA.Empty;
            return b;
        }

        public override BorderLineA GetLeft(BCell cell)
        {
            if (cell.IsEmptyCell) return BorderLineA.Empty;
            var border = cell.LeftBorder;
            if (!cell.NoPadding || border.IsEmptyAndUsable) return border;
            BorderLineA bline = null;
            if (TestLeft(cell, new List<BCell>(), ref bline)) return BorderLineA.Empty;
            return border;
        }

        public override BorderLineA GetRight(BCell cell)
        {
            if (cell.IsEmptyCell)
            {
                if (UseEmptyCells)
                {
                    var adj = GetRightCells(cell);
                    if (adj.Count != 1 || adj[0].IsEmptyCell) return BorderLineA.Empty;
                    BorderLineA bline = null;
                    if (TestRight(cell, new List<BCell>(), ref bline))
                    {
                        if (bline == null) return BorderLineA.Empty;
                        return bline;
                    }
                    return BorderLineA.Empty;

                }
                else
                {
                    return BorderLineA.Empty;
                }
            }
            else
            {
                var border = cell.LeftBorder;
                if (border.Width > 0f || border.Padding > 0f)
                {
                    return border;
                }
                BorderLineA bline = null;
                if (TestRight(cell, new List<BCell>(), ref bline))
                {
                    if (bline == null) return BorderLineA.Empty;
                    return bline;
                }
                return BorderLineA.Empty;
            }
        }

        public override BorderLineA GetBottom(BCell cell)
        {
            if (cell.IsEmptyCell)
            {
                if (UseEmptyCells)
                {
                    var adj = GetBottomCells(cell);
                    if (adj.Count != 1 || adj[0].IsEmptyCell) return BorderLineA.Empty;
                    BorderLineA bline = null;
                    if (TestBottom(cell, new List<BCell>(), ref bline))
                    {
                        if (bline == null) return BorderLineA.Empty;
                        return bline;
                    }
                    return BorderLineA.Empty;
                }
                else
                {
                    return BorderLineA.Empty;
                }
            }
            else
            {
                var border = cell.BottomBorder;
                if (border.Width > 0f || border.Padding > 0f)
                {
                    return border;
                }
                BorderLineA bline = null;
                if (TestBottom(cell, new List<BCell>(), ref bline))
                {
                    if (bline == null) return BorderLineA.Empty;
                    return bline;
                }
                return BorderLineA.Empty;
            }
        }

    }

    public class BorderInspectorWithGrid : BorderInspector
    {
        public BorderInspectorWithGrid(IGridForBordersFX grid) : base(grid)
        {
        }

        public BorderLineA EmptyGridLine
        {
            get
            {
                if (!ShowGrid)
                    return BorderLineA.Empty;
                var gl = Grid.GetEmptyGridLine();
                return new BorderLineA(gl.Width, gl.Color);
            }
        }


        public override BorderLineA GetTop(BCell cell)
        {
            var bl = base.GetTop(cell);
            if (!ShowGrid) return bl;
            if (bl.Width > 0f || bl.Padding > 0f) return bl;
            if (cell.NoPadding && !DesignHeaders && cell.Bounds.Y == 0)
                return EmptyGridLine;
            if (cell.IsEmptyCell)
            {
                if (bl.Padding > 0f)
                    return EmptyGridLine;
                var adj = GetTopCells(cell);
                if (adj.Any() && !adj[0].NoPadding)
                    return EmptyGridLine;
            }
            return BorderLineA.Empty;
        }

        public override BorderLineA GetLeft(BCell cell)
        {
            var bl = base.GetLeft(cell);
            if (!ShowGrid) return bl;
            if (bl.Width > 0f || bl.Padding > 0f) return bl;
            if (cell.NoPadding && !DesignHeaders && cell.Bounds.X == 0)
                return EmptyGridLine;
            if (cell.IsEmptyCell)
            {
                if (bl.Padding > 0f)
                    return EmptyGridLine;
                var adj = GetLeftCells(cell);
                if (adj.Any() && !adj[0].NoPadding)
                    return EmptyGridLine;
            }
            return BorderLineA.Empty;
        }

        public override BorderLineA GetRight(BCell cell)
        {
            var bl = base.GetRight(cell);
            if (!ShowGrid) return bl;
            if (bl.Width > 0f || bl.Padding > 0f) return bl;
            if (cell.NoPadding && !DesignHeaders && cell.Bounds.Right - 1 == Grid.ColumnsCount - 1)
                return EmptyGridLine;
            return EmptyGridLine;
        }

        public override BorderLineA GetBottom(BCell cell)
        {
            var bl = base.GetBottom(cell);
            if (!ShowGrid) return bl;
            if (bl.Width > 0f || bl.Padding > 0f) return bl;
            if (cell.NoPadding && !DesignHeaders && cell.Bounds.Bottom - 1 == Grid.RowsCount - 1)
                return EmptyGridLine;
            return EmptyGridLine;
        }
    }

   

}
