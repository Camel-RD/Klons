using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using KlonsA.DataSets;


namespace KlonsA.Forms
{
    public partial class Form_Calendar : MyFormBaseA
    {
        public Form_Calendar()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            grid.ApplyColorTheme(KlonsData.St.Settings.ColorTheme);
            SetUpGrid();
            cbYR.DropDownWidth = cbYR.Width;
            int yr = DateTime.Today.Year;
            var yrs = new List<MyListItemInt>();
            for (int i = yr - 6; i <= yr + 1; i++)
            {
                var it = new MyListItemInt(i, i.ToString());
                yrs.Add(it);
            }
            cbYR.DataSource = yrs;
            cbYR.DisplayMember = "Val";
            cbYR.ValueMember = "Key";
            cbYR.SelectedIndex = 6;

            MakeYear(yr);
            Initalized = true;
        }

        public int YearUsed = -1;
        private bool Initalized = false;

        public void SetUpGrid()
        {
            grid.Redim(24, 32);
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                grid.Columns[i].Width = (int)((float)grid.DefaultHeight * 1.2f);
            }
            for (int i = 0; i < 12; i++)
            {
                InitMonthCells(i);
            }

        }

        string[] MonthNames = new[] { "Janvāris", "Februāris", "Marts", "Aprīlis", "Maijs",
            "Jūnijs", "Jūlijs", "Augusts", "Septembris", "Oktobris", "Novembris", "Decembris" };

        public void InitMonthCells(int mt)
        {
            var pos = GetMTFirstCell(mt);
            SourceGrid.Cells.Editors.TextBox editor = null;
            grid[pos.Y, pos.X] = new SourceGrid.Cells.Cell("", editor);
            var cell = grid[pos.Y, pos.X];
            cell.ColumnSpan = 7;
            cell.View = grid.gridViewModel.captionModel;
            cell.Value = MonthNames[mt];
            for (int i = 1; i <= 6; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    cell = new SourceGrid.Cells.Cell("", editor);
                    grid[pos.Y + i, pos.X + j] = cell;
                    SourceGrid.Cells.Views.Cell vm = null;
                    if (j == 0) vm = grid.gridViewModel.dayCellModelLeft;
                    else if (j > 4) vm = grid.gridViewModel.dayCellModelWeekend;
                    else vm = grid.gridViewModel.dayCellModel;
                    cell.View = vm;
                }
            }
        }
        
        public void MakeYear(int yr)
        {
            for (int i = 0; i < 12; i++)
                MakeMonth(yr, i);
            YearUsed = yr;
        }

        private void MakeMonth(int yr, int mt)
        {
            var pos = GetMTFirstCell(mt);
            var mtd = new MonthData(yr, mt);
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    var cell = grid[pos.Y + i + 1, pos.X + j];
                    SourceGrid.Cells.Views.Cell vm = null;
                    cell.Value = mtd.Days[i][j].ToString();
                    var daytag = mtd.DayTags[i][j];
                    if (j == 0)
                    {
                        if(daytag == ECalendarDayType.Day)
                            vm = grid.gridViewModel.dayCellModelLeft;
                        else if (daytag == ECalendarDayType.Out)
                            vm = grid.gridViewModel.dayCellModelOutLeft;
                        else vm = grid.gridViewModel.dayCellModelHollydayLeft;
                    }
                    else if (j > 4)
                    {
                        if (daytag == ECalendarDayType.Day)
                            vm = grid.gridViewModel.dayCellModelWeekend;
                        else if (daytag == ECalendarDayType.Out)
                            vm = grid.gridViewModel.dayCellModelOutWeekend;
                        else vm = grid.gridViewModel.dayCellModelHollydayWeekend;
                    }
                    else
                    {
                        if (daytag == ECalendarDayType.Day)
                            vm = grid.gridViewModel.dayCellModel;
                        else if (daytag == ECalendarDayType.Out)
                            vm = grid.gridViewModel.dayCellModelOut;
                        else vm = grid.gridViewModel.dayCellModelHollyday;
                    }
                    cell.View = vm;
                }
            }
        }

        private Point GetMTFirstCell(int mt)
        {
            int row = (mt / 4) * 8;
            int col = (mt % 4) * 8;
            return new Point(col, row);
        }

        private void CheckYear()
        {
            if (!Initalized) return;
            if (string.IsNullOrEmpty(cbYR.Text)) return;
            if (!int.TryParse(cbYR.Text, out int yr)) return;
            if (yr < 1900 || yr > 2100) return;
            if (yr == YearUsed) return;
            MakeYear(yr);
        }

        private void cbYR_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckYear();
        }

        private void cbYR_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return) CheckYear();
        }
    }

    enum ECalendarDayType {Day, Out, Hollyday};
    class MonthData
    {
        public int[][] Days { get; private set; } = null;
        public ECalendarDayType[][] DayTags { get; private set; } = null;

        public MonthData(int yr, int mt)
        {
            Days = new int[6][];
            DayTags = new ECalendarDayType[6][];
            for (int i = 0; i < 6; i++)
            {
                Days[i] = new int[7];
                DayTags[i] = new ECalendarDayType[7];
            }
            var dt1 = new DateTime(yr, mt+1, 1);
            var dt2 = dt1.LastDayOfMonth();
            var pdt2 = dt1.AddDays(-1);
            var crd1 = GetCoords(dt1);
            var crd2 = GetCoords(dt2);

            var table = KlonsData.St.DataSetKlons.HOLIDAYS;
            var dts_hdays = table
                .WhereX(d => d.DT >= dt1 && d.DT <= dt2)
                .Select(d => d.DT)
                .ToList();

            for(int i = 0; i< 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    var crd = new Point(j, i);
                    int diff1 = GetCoordDiff(crd, crd1);
                    int diff2 = GetCoordDiff(crd, crd2);
                    if (diff1 < 0)
                    {
                        Days[i][j] = pdt2.Day - diff1 + 1;
                        DayTags[i][j] = ECalendarDayType.Out;
                    }
                    else if(diff2 > 0)
                    {
                        Days[i][j] = diff2;
                        DayTags[i][j] = ECalendarDayType.Out;
                    }
                    else
                    {
                        Days[i][j] = diff1 + 1;
                        DayTags[i][j] = ECalendarDayType.Day;
                        var dtc = new DateTime(yr, mt+1, diff1 + 1);
                        if (dts_hdays.Contains(dtc))
                            DayTags[i][j] = ECalendarDayType.Hollyday;
                    }
                }
            }
        }

        public Point GetCoords(DateTime dt)
        {
            var dt1 = dt.FirstDayOfMonth();
            int wd1 = dt1.DayOfWeekA() - 1;
            int row1 = 0;
            if (wd1 == 0) row1 = 1;
            int row = (dt.Day + wd1 - 1) / 7;
            return new Point(dt.DayOfWeekA() - 1, row + row1);
        }

        public int GetCoordDiff(Point p1, Point p2)
        {
            return p1.Y * 7 + p1.X - p2.Y * 7 - p2.X;
        }
    }
}
