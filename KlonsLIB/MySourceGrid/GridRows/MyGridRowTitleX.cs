using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceGrid;

namespace KlonsLIB.MySourceGrid.GridRows
{
    public enum ETitleRowType
    {
        Static, Collapsable, CollapsableWithValue, SubTitle
    }

    public class MyGridRowTitle : MyGridRowBase
    {
        private int rowNr1 = -1;
        private int rowNr2 = -1;
        private bool expanded = true;

        public MyGridRowTitle(string name, string title) : base(name, title)
        {
            RowType = EMyGridRowType.Title;
        }
        public MyGridRowTitle()
        {
            RowType = EMyGridRowType.Title;
            RowValueType = EMyGridRowValueType.None;
        }

        private ETitleRowType titleRowType = ETitleRowType.Collapsable;

        [DefaultValue(ETitleRowType.Collapsable)]
        public ETitleRowType TitleRowType
        {
            get { return titleRowType; }
            set
            {
                if (titleRowType == value) return;
                titleRowType = value;
                if (titleRowType == ETitleRowType.SubTitle)
                    RowType = EMyGridRowType.SubTitle;
                else
                    RowType = EMyGridRowType.Title;
            }
        }

        public override void MakeRow(SourceGrid.GridRow gridrow, int colnr)
        {
            var grid = Grid = gridrow.Grid as MyGrid;
            RowNr = gridrow.Index;
            ColNr = colnr;

            int i = RowNr;
            if (grid.RowHeadersUsed)
            {
                if (TitleRowType == ETitleRowType.Static)
                {
                    grid[i, RowHeaderColumnNr] = new SourceGrid.Cells.Cell(RowTitle);
                    grid[i, RowHeaderColumnNr].View = grid.gridViewModel.titleModel;
                    grid[i, RowHeaderColumnNr].ColumnSpan = 3;
                }
                else if (TitleRowType == ETitleRowType.Collapsable)
                {
                    grid[i, RowHeaderColumnNr] = new SourceGrid.Cells.Button("-");
                    grid[i, RowHeaderColumnNr].AddController(buttonController);
                    grid[i, RowHeaderColumnNr].View = grid.gridViewModel.titleModel;
                }
                else if (TitleRowType == ETitleRowType.CollapsableWithValue)
                {
                    grid[i, RowHeaderColumnNr] = new SourceGrid.Cells.Button("-");
                    grid[i, RowHeaderColumnNr].AddController(buttonController);
                    grid[i, RowHeaderColumnNr].View = grid.gridViewModel.titleModel;
                }
                else if (TitleRowType == ETitleRowType.SubTitle)
                {
                    MakeFirstCell();
                }
            }
            else
            {
                if (TitleRowType == ETitleRowType.Static)
                {
                    grid[i, CaptionColumnNr] = new SourceGrid.Cells.Cell(RowTitle);
                    grid[i, CaptionColumnNr].View = grid.gridViewModel.titleModel;
                    grid[i, CaptionColumnNr].ColumnSpan = 2;
                }
            }
            if (TitleRowType == ETitleRowType.Collapsable)
            {
                grid[i, CaptionColumnNr] = new SourceGrid.Cells.Cell(RowTitle);
                grid[i, CaptionColumnNr].View = grid.gridViewModel.titleModel;
                grid[i, CaptionColumnNr].ColumnSpan = 2;
            }
            else if (TitleRowType == ETitleRowType.CollapsableWithValue)
            {
                grid[i, CaptionColumnNr] = new SourceGrid.Cells.Cell(RowTitle);
                grid[i, CaptionColumnNr].View = grid.gridViewModel.titleModel;
                grid[i, DataColumnNr] = new SourceGrid.Cells.Cell();
                grid[i, DataColumnNr].View = grid.gridViewModel.titleDataCellModel;
            }
            else if (TitleRowType == ETitleRowType.SubTitle)
            {
                grid[i, CaptionColumnNr] = new SourceGrid.Cells.Cell(RowTitle);
                grid[i, CaptionColumnNr].View = grid.gridViewModel.titleModel2;
                grid[i, CaptionColumnNr].ColumnSpan = 2;
            }
        }

    
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool CanBeMarked
        {
            get { return TitleRowType == ETitleRowType.SubTitle; }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ValueStr
        {
            get
            {
                if (TitleRowType != ETitleRowType.CollapsableWithValue)
                    throw new Exception("Bad call.");

                int i = RowNr;
                var grid = Grid;
                var val = grid[i, DataColumnNr].Value;
                if (val == null || val == DBNull.Value) return null;
                return val.ToString();
            }
            set
            {
                if (TitleRowType != ETitleRowType.CollapsableWithValue)
                    throw new Exception("Bad call.");

                if (ValueStr == value) return;
                int i = RowNr;
                var grid = Grid;
                if (value == null)
                {
                    grid[i, DataColumnNr].Value = null;
                    return;
                }
                grid[i, DataColumnNr].Value = value.ToString();
            }
        }

        private void GetRowNrs()
        {
            var grid = Grid;
            int k1 = grid.RowList.IndexOf(this);
            if (k1 == -1) return;
            int rnr1 = RowNr + 1;
            int rnr2 = grid.Rows.Count - 1;
            for (int i = k1 + 1; i < grid.RowList.Count; i++)
            {
                var row = grid.RowList[i];
                if (row.RowType == EMyGridRowType.Title)
                {
                    rnr2 = row.RowNr - 1;
                    break;
                }
            }
            if (rnr1 >= rnr2) return;
            rowNr1 = rnr1;
            rowNr2 = rnr2;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Expanded
        {
            get
            {
                if (TitleRowType != ETitleRowType.Collapsable &&
                    TitleRowType != ETitleRowType.CollapsableWithValue)
                    throw new Exception("Bad call.");

                return expanded;
            }
            set
            {
                if (TitleRowType != ETitleRowType.Collapsable &&
                    TitleRowType != ETitleRowType.CollapsableWithValue)
                    throw new Exception("Bad call.");

                if (expanded == value) return;
                var grid = Grid;
                if (rowNr1 < 0) GetRowNrs();
                if (rowNr1 < 0) return;
                expanded = value;
                for (int i = rowNr1; i <= rowNr2; i++)
                {
                    grid.Rows[i].Visible = expanded;
                }
                grid[RowNr, RowHeaderColumnNr].Value = expanded ? "-" : "+";
            }
        }

        public void OnButton(CellContext sender, EventArgs e)
        {
            Expanded = !Expanded;
        }

        static MyGridRowTitle()
        {
            buttonController = new SourceGrid.Cells.Controllers.Button();
            buttonController.Executed += OnButton;
        }

        protected static SourceGrid.Cells.Controllers.Button buttonController;

        public static void OnButton(object sender, EventArgs e)
        {
            var con = (CellContext)sender;
            int rownr = con.CellRange.Start.Row;
            var grid = con.Grid as MyGrid;
            var row = grid.RowList.FindRow(rownr) as MyGridRowTitle;
            if (row == null) return;
            row.OnButton(con, e);
        }
    }

}
