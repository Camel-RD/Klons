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
            var mc = new MyClickController();
            mc.OnLeftClick += Mc_OnLeftClick;
            mc.OnRightClick += Mc_OnRightClick;
            grid.Controller.AddController(mc);
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
                        if (daytag == ECalendarDayType.Day)
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
            if (e.KeyCode == Keys.Return) CheckYear();
        }

        SourceGrid.Position pos1 = SourceGrid.Position.Empty;
        SourceGrid.Position pos2 = SourceGrid.Position.Empty;
        DateTime DateSet1 = DateTime.MinValue;
        DateTime DateSet2 = DateTime.MinValue;

        private void Mc_OnLeftClick(object sender, EventArgs e)
        {
            var ctx = (SourceGrid.CellContext)sender;
            var pos = ctx.Position;
            pos1 = pos;
            pos2 = SourceGrid.Position.Empty;
            UpdateDatesSet();
        }

        private void Mc_OnRightClick(object sender, EventArgs e)
        {
            var ctx = (SourceGrid.CellContext)sender;
            var pos = ctx.Position;
            if(pos1 == SourceGrid.Position.Empty) return;
            pos2 = pos;
            UpdateDatesSet();
        }

        private void UpdateDatesSet()
        {
            if (pos1 == SourceGrid.Position.Empty)
                DateSet1 = DateTime.MinValue;
            else
                DateSet1 = GetDateByPos(pos1);

            if (pos2 == SourceGrid.Position.Empty)
                DateSet2 = DateTime.MinValue;
            else
                DateSet2 = GetDateByPos(pos2);
            if (DateSet1 == DateTime.MinValue && DateSet2 == DateTime.MinValue)
            {
                lbDates.Text = "[ peles kreisais klik. ] - []";
            }
            else if (DateSet1 > DateTime.MinValue && DateSet2 == DateTime.MinValue)
            {
                lbDates.Text = $"[{Utils.DateToString(DateSet1)}] - [ peles labais klik. ]";
            }
            else
            {
                lbDates.Text = $"[{Utils.DateToString(DateSet1)}] - [{Utils.DateToString(DateSet2)}]";
                ShowDateSetInfo();
            }
        }

        private void ShowDateSetInfo()
        {
            if (DateSet1 == DateTime.MinValue || DateSet2 == DateTime.MinValue) return;
            if (DateSet1 == DateSet2) return;
            if (DateSet1 > DateSet2)
            {
                var dtt = DateSet1;
                DateSet1 = DateSet2;
                DateSet2 = dtt;
            }
            var table = KlonsData.St.DataSetKlons.HOLIDAYS;
            var dts_hdays = table
                .WhereX(d => d.DT >= DateSet1 && d.DT <= DateSet2)
                .Select(d => d.DT)
                .ToList();
            int daysct = (int)(DateSet2 - DateSet1).TotalDays + 1;
            int holydaysct = dts_hdays.Count();
            int workdaysct = 0;
            int holydaysinworkdaysct = 0;
            for (var dti = DateSet1; dti <= DateSet2; dti = dti.AddDays(1))
                if (dti.DayOfWeekA() < 6) workdaysct++;
            holydaysinworkdaysct = dts_hdays.Where(d => d.DayOfWeekA() < 6).Count();
            var msg = $"Periods: {Utils.DateToString(DateSet1)} - {Utils.DateToString(DateSet2)}\n" +
                $"Dienas: {daysct}\n" +
                $"Darba dienas, neatskaitot svētku dienas: {workdaysct}\n" +
                $"Svētku dienas: {holydaysct}\n" +
                $"Svētku dienas, kas iekrīt darba dienās: {holydaysinworkdaysct}\n" +
                $"Darba dienas, atskaitot svētku dienas: {workdaysct - holydaysinworkdaysct}\n";
            MyMainForm.ShowInfo(msg, "Informācija par iezīmēto periodu");
        }

        private DateTime GetDateByPos(SourceGrid.Position pos)
        {
            if (YearUsed == -1) return DateTime.MinValue;
            for (int i = 0; i < 12; i++)
            {
                var fc = GetMTFirstCell(i);
                if (pos.Column >= fc.X && pos.Column <= fc.X + 6 &&
                    pos.Row >= fc.Y + 1 && pos.Row <= fc.Y + 6)
                {
                    return MonthData.GetByCoord(YearUsed, i, pos.Row - fc.Y - 1, pos.Column - fc.X);
                }
            }
            return DateTime.MinValue;
        }

    }

    enum ECalendarDayType { Day, Out, Hollyday };
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
            var dt1 = new DateTime(yr, mt + 1, 1);
            var dt2 = dt1.LastDayOfMonth();
            var pdt2 = dt1.AddDays(-1);
            var crd1 = GetCoords(dt1);
            var crd2 = GetCoords(dt2);

            var table = KlonsData.St.DataSetKlons.HOLIDAYS;
            var dts_hdays = table
                .WhereX(d => d.DT >= dt1 && d.DT <= dt2)
                .Select(d => d.DT)
                .ToList();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    var crd = new Point(j, i);
                    int diff1 = GetCoordDiff(crd, crd1);
                    int diff2 = GetCoordDiff(crd, crd2);
                    if (diff1 < 0)
                    {
                        Days[i][j] = pdt2.Day + diff1 + 1;
                        DayTags[i][j] = ECalendarDayType.Out;
                    }
                    else if (diff2 > 0)
                    {
                        Days[i][j] = diff2;
                        DayTags[i][j] = ECalendarDayType.Out;
                    }
                    else
                    {
                        Days[i][j] = diff1 + 1;
                        DayTags[i][j] = ECalendarDayType.Day;
                        var dtc = new DateTime(yr, mt + 1, diff1 + 1);
                        if (dts_hdays.Contains(dtc))
                            DayTags[i][j] = ECalendarDayType.Hollyday;
                    }
                }
            }
        }

        //mt: 0-11
        static public DateTime GetByCoord(int yr, int mt, int row, int col)
        {
            if (row < 0 || row > 5 || col < 0 || col > 6 || mt < 0 || mt > 11)
                throw new ArgumentOutOfRangeException();
            var dt1 = new DateTime(yr, mt + 1, 1);
            var dt2 = dt1.LastDayOfMonth();
            var pdt2 = dt1.AddDays(-1);
            var crd1 = GetCoords(dt1);
            var crd2 = GetCoords(dt2);

            var crd = new Point(col, row);
            int diff1 = GetCoordDiff(crd, crd1);
            int diff2 = GetCoordDiff(crd, crd2);

            if (diff1 < 0) return pdt2.AddDays(diff1 + 1);
            else if (diff2 > 0) return dt2.AddDays(diff2);
            else return dt1.AddDays(diff1);
        }

        static public Point GetCoords(DateTime dt)
        {
            var dt1 = dt.FirstDayOfMonth();
            int wd1 = dt1.DayOfWeekA() - 1;
            int row1 = 0;
            if (wd1 == 0) row1 = 1;
            int row = (dt.Day + wd1 - 1) / 7;
            return new Point(dt.DayOfWeekA() - 1, row + row1);
        }

        static public int GetCoordDiff(Point p1, Point p2)
        {
            return p1.Y * 7 + p1.X - p2.Y * 7 - p2.X;
        }
    }

    public class MyClickController : SourceGrid.Cells.Controllers.ControllerBase
    {
        private MouseButtons mLastButton = MouseButtons.None;

        public override void OnMouseDown(SourceGrid.CellContext sender, MouseEventArgs e)
        {
            base.OnMouseDown(sender, e);
            mLastButton = e.Button;
        }

        public event EventHandler OnLeftClick;
        public event EventHandler OnRightClick;

        public override void OnClick(SourceGrid.CellContext sender, EventArgs e)
        {
            base.OnClick(sender, e);
            if (mLastButton == MouseButtons.Left)
                OnLeftClick(sender, e);
            else if (mLastButton == MouseButtons.Right)
                OnRightClick(sender, e);
        }

    }
}