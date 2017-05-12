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
                if(titleRowType == ETitleRowType.SubTitle)
                    RowType = EMyGridRowType.SubTitle;
                else
                    RowType = EMyGridRowType.Title;
            }
        } 

        public override void MakeRow(SourceGrid.GridRow gridrow)
        {
            GridRow = gridrow;
            int i = GridRow.Index;
            var grid = GridRow.Grid as MyGrid;
            if (TitleRowType == ETitleRowType.Static)
            {
                grid[i, 0] = new SourceGrid.Cells.Cell(RowTitle);
                grid[i, 0].View = grid.gridViewModel.titleModel;
                grid[i, 0].ColumnSpan = 3;
            }
            else if (TitleRowType == ETitleRowType.Collapsable)
            {
                grid[i, 0] = new SourceGrid.Cells.Button("-");
                grid[i, 0].AddController(buttonController);
                grid[i, 0].View = grid.gridViewModel.titleModel;
                grid[i, 1] = new SourceGrid.Cells.Cell(RowTitle);
                grid[i, 1].View = grid.gridViewModel.titleModel;
                grid[i, 1].ColumnSpan = 2;
            }
            else if (TitleRowType == ETitleRowType.CollapsableWithValue)
            {
                grid[i, 0] = new SourceGrid.Cells.Button("-");
                grid[i, 0].AddController(buttonController);
                grid[i, 0].View = grid.gridViewModel.titleModel;
                grid[i, 1] = new SourceGrid.Cells.Cell(RowTitle);
                grid[i, 1].View = grid.gridViewModel.titleModel;
                grid[i, 2] = new SourceGrid.Cells.Cell();
                grid[i, 2].View = grid.gridViewModel.titleDataCellModel;
            }
            else if (TitleRowType == ETitleRowType.SubTitle)
            {
                MakeFirstCell();
                grid[i, 1] = new SourceGrid.Cells.Cell(RowTitle);
                grid[i, 1].View = grid.gridViewModel.titleModel2;
                grid[i, 1].ColumnSpan = 2;
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

                int i = GridRow.Index;
                var grid = GridRow.Grid as MyGrid;
                var val = grid[i, 2].Value;
                if (val == null || val == DBNull.Value) return null;
                return val.ToString();
            }
            set
            {
                if (TitleRowType != ETitleRowType.CollapsableWithValue)
                    throw new Exception("Bad call.");

                if (ValueStr == value) return;
                int i = GridRow.Index;
                var grid = GridRow.Grid as MyGrid;
                if (value == null)
                {
                    grid[i, 2].Value = null;
                    return;
                }
                grid[i, 2].Value = value.ToString();
            }
        }

        private void GetRowNrs()
        {
            var grid = GridRow.Grid as MyGrid;
            int k1 = grid.RowList.IndexOf(this);
            if (k1 == -1) return;
            int rnr1 = GridRow.Index + 1;
            int rnr2 = grid.Rows.Count - 1;
            for (int i = k1 + 1; i < grid.RowList.Count; i++)
            {
                var row = grid.RowList[i];
                if (row.RowType == EMyGridRowType.Title)
                {
                    rnr2 = row.GridRow.Index - 1;
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
                var grid = GridRow.Grid as MyGrid;
                int rownr = GridRow.Index;
                if (rowNr1 < 0) GetRowNrs();
                if (rowNr1 < 0) return;
                expanded = value;
                for (int i = rowNr1; i <= rowNr2; i++)
                {
                    grid.Rows[i].Visible = expanded;
                }
                grid[rownr, 0].Value = expanded ? "-" : "+";
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
