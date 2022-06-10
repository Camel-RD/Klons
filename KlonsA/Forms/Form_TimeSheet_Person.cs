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
using KlonsA.DataSets;
using KlonsA.DataSets.KlonsADataSetTableAdapters;
using KlonsLIB.Data;
using KlonsLIB.Misc;
using KlonsLIB.Forms;
using KlonsLIB.Components.SpanCell;

namespace KlonsA.Forms
{
    public partial class Form_TimeSheet_Person : MyFormBaseA
    {
        public Form_TimeSheet_Person()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvRows.AutoGenerateColumns = false;
            myStyleDefs1.MakeStyles(dgvRows);
            DgvDisableSort(dgvRows);
        }

        void DgvDisableSort(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }


        private void Form_TimeSheet_Person_Load(object sender, EventArgs e)
        {

        }

        public List<ReportRow> MakeList(int idp)
        {
            var ret = new List<ReportRow>();

            var table_persons = MyData.DataSetKlons.PERSONS;
            var table_amati = MyData.DataSetKlons.POSITIONS;
            var table_sar = MyData.DataSetKlons.TIMESHEET_LISTS;
            var table_sar_r = MyData.DataSetKlons.TIMESHEET_LISTS_R;
            var table_darba_laiks = MyData.DataSetKlons.TIMESHEET;
            var table_plans = MyData.DataSetKlons.TIMEPLAN_LIST;

            var dr_person = table_persons.FindByID(idp);
            if (dr_person == null) return ret;

            string name = dr_person.YNAME;

            var drs_sar_r = table_sar_r
                .WhereX(x => x.IDP == idp)
                .ToList();

            if (drs_sar_r.Count == 0) return ret;

            foreach (var dr_sar_r in drs_sar_r)
            {
                var dr_sar = table_sar.FindByID(dr_sar_r.IDS);
                var drs_darba_laiks = dr_sar_r.GetTIMESHEETRows();
                var dr_pers = table_persons.FindByID(dr_sar_r.IDP);
                var dr_amats = table_amati.FindByID(dr_sar_r.IDAM);
                var s_position = dr_amats.TITLE;

                var repset = new TimeSheetItemSet()
                {
                    IDP = idp,
                    IDAM = dr_sar_r.IDAM,
                    YR = dr_sar.YR,
                    MT = dr_sar.MT,
                    YRMT = $"{dr_sar.YR}.{dr_sar.MT:00}",
                    Name = name,
                    Position = s_position
                };

                foreach (var dr_darba_laiks in drs_darba_laiks)
                {
                    repset.SetRow(dr_darba_laiks);
                }

                if (dr_sar_r.XPlanType == EPlanType.Fixed)
                {
                    var drs_darba_laiks_plans = table_darba_laiks.WhereX(dr =>
                        !dr.IsIDPNull() &&
                        dr.IsIDLNull() &&
                        dr.IDP == dr_sar_r.IDPL &&
                        dr.YR == dr_sar.YR &&
                        dr.MT == dr_sar.MT).ToArray();

                    foreach (var dr_darba_laiks in drs_darba_laiks_plans)
                    {
                        repset.SetRow(dr_darba_laiks);
                    }
                }

                var rep_rows = repset.MakeReportRows();
                if(ret.Count > 0)
                {
                    var blank_rep_row = repset.MakeBlankReportRows();
                    ret.Add(blank_rep_row);
                }
                ret.AddRange(rep_rows);
            }
            return ret;

        }

        public enum ECellKind
        {
            Plain, FreeDay, Vacation, SickLeave, Holiday, WeekEnd, 
            HeaderHoliday, HeaderWeekEnd
        }
        
        public enum EReportRowKind
        {
            Blank, First, Second, Last, Rest
        }

        public class ReportRow
        {
            public EReportRowKind ReportRowKind = EReportRowKind.Blank;
            public string Caption { get; set; } = null;
            public string Name { get; set; } = null;
            public string Position { get; set; } = null;
            public int YR { get; set; } = 0;
            public int MT { get; set; } = 0;
            public string YRMT { get; set; } = null;
            public string Kind { get; set; } = null;
            public float K1 { get; set; } = 0;
            public string[] SX { get; } = new string[31];
            public ECellKind[] CX { get; } = new ECellKind[31];

            #region  *********  arrays  *********

            public string S1 => SX[0];
            public string S2 => SX[1];
            public string S3 => SX[2];
            public string S4 => SX[3];
            public string S5 => SX[4];
            public string S6 => SX[5];
            public string S7 => SX[6];
            public string S8 => SX[7];
            public string S9 => SX[8];
            public string S10 => SX[9];
            public string S11 => SX[10];
            public string S12 => SX[11];
            public string S13 => SX[12];
            public string S14 => SX[13];
            public string S15 => SX[14];
            public string S16 => SX[15];
            public string S17 => SX[16];
            public string S18 => SX[17];
            public string S19 => SX[18];
            public string S20 => SX[19];
            public string S21 => SX[20];
            public string S22 => SX[21];
            public string S23 => SX[22];
            public string S24 => SX[23];
            public string S25 => SX[24];
            public string S26 => SX[25];
            public string S27 => SX[26];
            public string S28 => SX[27];
            public string S29 => SX[28];
            public string S30 => SX[29];
            public string S31 => SX[30];
            
            public ECellKind C1 => CX[0];
            public ECellKind C2 => CX[1];
            public ECellKind C3 => CX[2];
            public ECellKind C4 => CX[3];
            public ECellKind C5 => CX[4];
            public ECellKind C6 => CX[5];
            public ECellKind C7 => CX[6];
            public ECellKind C8 => CX[7];
            public ECellKind C9 => CX[8];
            public ECellKind C10 => CX[9];
            public ECellKind C11 => CX[10];
            public ECellKind C12 => CX[11];
            public ECellKind C13 => CX[12];
            public ECellKind C14 => CX[13];
            public ECellKind C15 => CX[14];
            public ECellKind C16 => CX[15];
            public ECellKind C17 => CX[16];
            public ECellKind C18 => CX[17];
            public ECellKind C19 => CX[18];
            public ECellKind C20 => CX[19];
            public ECellKind C21 => CX[20];
            public ECellKind C22 => CX[21];
            public ECellKind C23 => CX[22];
            public ECellKind C24 => CX[23];
            public ECellKind C25 => CX[24];
            public ECellKind C26 => CX[25];
            public ECellKind C27 => CX[26];
            public ECellKind C28 => CX[27];
            public ECellKind C29 => CX[28];
            public ECellKind C30 => CX[29];
            public ECellKind C31 => CX[30];


            #endregion
        }

        public class TimeSheetItemSet
        {
            public string Name { get; set; } = null;
            public string Position { get; set; } = null;
            public int YR = 0;
            public int MT = 0;
            public int IDP = 0;
            public int IDAM = 0;
            public string YRMT { get; set; } = null;
            public KlonsADataSet.TIMESHEETRow Plan = null;
            public KlonsADataSet.TIMESHEETRow PlanNight = null;
            public KlonsADataSet.TIMESHEETRow Fact = null;
            public KlonsADataSet.TIMESHEETRow FactNight = null;
            public KlonsADataSet.TIMESHEETRow FactOvertime = null;

            public void Clear()
            {
                Plan = null;
                PlanNight = null;
                Fact = null;
                FactNight = null;
                FactOvertime = null;
            }

            public void SetRow(KlonsADataSet.TIMESHEETRow row)
            {
                switch (row.XKind1)
                {
                    case EKind1.PlanGroupDay:
                    case EKind1.PlanIndividualDay:
                        Plan = row;
                        break;
                    case EKind1.PlanGroupaNight:
                    case EKind1.PlanIndividualNight:
                        PlanNight = row;
                        break;
                    case EKind1.Fact:
                        Fact = row;
                        break;
                    case EKind1.FactNight:
                        FactNight = row;
                        break;
                    case EKind1.FactOvertime:
                        FactOvertime = row;
                        break;
                }
            }

            public string FormatCell(float v, short daycode, EKind1 kind1)
            {
                string ret = v.ToString();

                if (kind1 == EKind1.PlanIndividualDay || kind1 == EKind1.PlanGroupDay)
                {
                    var daycodeplan = (EDayPlanId)daycode;
                    if (daycodeplan == EDayPlanId.Error || daycodeplan == EDayPlanId.None)
                        return "";
                    if (daycodeplan == EDayPlanId.DD)
                    {
                        if (v == 0.0F) return "";
                        return ret;
                    }
                    string daystr = SomeDataDefs.GetPlanIdStr(daycodeplan);
                    if (daycodeplan == EDayPlanId.BD || daycodeplan == EDayPlanId.SD)
                    {
                        if (v == 0.0f) ret = string.Format("{0}", daystr);
                        else ret = string.Format("{0} {1}", daystr, v);
                        return ret;
                    }
                    ret = string.Format("{0} {1}", daystr, v);
                    return ret;
                }

                if (kind1 == EKind1.Fact)
                {
                    var daycodefact = (EDayFactId)daycode;
                    if (daycodefact == EDayFactId.Error || daycodefact == EDayFactId.None)
                        return "";
                    if (daycodefact == EDayFactId.D)
                    {
                        if (v == 0.0F) return "";
                        return ret;
                    }
                    string daystr = SomeDataDefs.GetFactIdStr(daycodefact);
                    if (v == 0.0f) ret = daystr;
                    else ret = string.Format("{0} {1}", daystr, v);
                    return ret;
                }

                if (v == 0.0f) return "";
                return ret;
            }

            public ReportRow MakeReportRow(KlonsADataSet.TIMESHEETRow row)
            {
                var ret = new ReportRow();
                ret.Kind = SomeDataDefs.DarbaLaiksK1[(int)row.KIND1].Val;
                ret.K1 = row.K1;
                int dk = MyData.DataSetKlons.TIMESHEET.D1Column.Ordinal;
                for (int i = 0; i < 31; i++)
                {
                    short daycode = (short)row[dk + i];
                    ECellKind ck = ECellKind.Plain;
                    if (row.XKind1 == EKind1.Fact)
                    {
                        var daycodefact = row.DxFact[i];
                        if (SomeDataDefs.IsDayVacation(daycodefact))
                            ck = ECellKind.Vacation;
                        else if (SomeDataDefs.IsSickDay(daycodefact))
                            ck = ECellKind.SickLeave;
                        else if (daycodefact == EDayFactId.B)
                            ck = ECellKind.FreeDay;
                        else if (daycodefact == EDayFactId.S)
                            ck = ECellKind.Holiday;
                        else
                            ck = ECellKind.Plain;
                    }
                    else if (row.XKind1 == EKind1.PlanIndividualDay || row.XKind1 == EKind1.PlanGroupDay)
                    {
                        var daycodeplan = row.DxPlan[i];
                        if (daycodeplan == EDayPlanId.BD)
                            ck = ECellKind.FreeDay;
                        else if (daycodeplan == EDayPlanId.SD || daycodeplan == EDayPlanId.DDSD || daycodeplan == EDayPlanId.SDDD)
                            ck = ECellKind.Holiday;
                        else
                            ck = ECellKind.Plain;
                    }
                    else if (row.XKind1 == EKind1.FactNight || row.XKind1 == EKind1.FactOvertime)
                    {
                        var daycodefact = Fact == null ? 0 : Fact.DxFact[i];
                        daycode = (short)daycodefact;
                    }
                    else if (row.XKind1 == EKind1.PlanIndividualNight || row.XKind1 == EKind1.PlanGroupaNight)
                    {
                        var daycodeplan = Plan == null ? 0 : Plan.DxPlan[i];
                        daycode = (short)daycodeplan;
                        if (daycodeplan == EDayPlanId.BD)
                            ck = ECellKind.FreeDay;
                    }
                    ret.CX[i] = ck;
                    ret.SX[i] = FormatCell(row.Vx[i], daycode, row.XKind1);
                }

                return ret;
            }

            public ReportRow MakeColumnHeaders(CalendarMonthInfo calmt)
            {
                var ret = new ReportRow();
                ret.Kind = "";
                int d1;
                string s;

                string[] daystr = SomeDataDefs.GetDaysStr(calmt.WeekDays);

                for (int i = 0; i < 31; i++)
                {
                    //s = daystr[i] + "\n" + (i+1);
                    s = daystr[i];
                    d1 = calmt.WeekDays[i];
                    if (d1 == -1) s = "";
                    ret.SX[i] = s;
                    ECellKind ck = ECellKind.Plain;
                    if (calmt.HolyDays[i] == EHolyDay.Holiday)
                    {
                        ck = ECellKind.HeaderHoliday;
                    }
                    else if (d1 == 6 || d1 == 7)
                    {
                        ck = ECellKind.HeaderWeekEnd;
                    }
                    ret.CX[i] = ck;
                }
                return ret;
            }
            public ReportRow MakeBlankReportRows()
            {
                var ret = new ReportRow()
                {
                    ReportRowKind = EReportRowKind.Blank
                };
                return ret;
            }

            public List<ReportRow> MakeReportRows()
            {
                var ret = new List<ReportRow>();
                var calm = new CalendarMonthInfo(YR, MT);
                var row_cal = MakeColumnHeaders(calm);
                ret.Add(row_cal);
                var list = new[] { Plan, PlanNight, Fact, FactNight, FactOvertime };
                foreach(var row in list)
                {
                    if (row == null) continue;
                    var reprow = MakeReportRow(row);
                    ret.Add(reprow);
                }
                for(int i = 0; i < ret.Count; i++)
                {
                    var row = ret[i];
                    row.Name = Name;
                    row.Position = Position;
                    row.YR = YR;
                    row.MT = MT;
                    row.YRMT = YRMT;
                    if (i == 0) row.ReportRowKind = EReportRowKind.First;
                    else if(i == 1) row.ReportRowKind = EReportRowKind.Second;
                    else if (i == ret.Count - 1) row.ReportRowKind = EReportRowKind.Last;
                    else row.ReportRowKind = EReportRowKind.Rest;

                    string pos1 = Position;
                    string pos2 = null;
                    int posbreaklen = 25;
                    if (!Position.IsNOE() && Position.Length > posbreaklen)
                    {
                        pos1 = Position.LeftMax(posbreaklen);
                        pos2 = Position.Substring(posbreaklen);
                    }

                    if (i == 0) row.Caption = row.YRMT;
                    else if (i == 1) row.Caption = pos1;
                    else if (i == 2) row.Caption = pos2;
                }
                return ret;
            }

        }

        public void DoMakeReport()
        {
            if (cbPerson.SelectedIndex == -1 || cbPerson.SelectedValue == null)
                return;
            int idp = (int)cbPerson.SelectedValue;
            var reprows = MakeList(idp);
            bsRows.DataSource = reprows;
            dgvRows.AutoResizeColumns();
        }

        private void dgvRows_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var row = dgvRows.Rows[e.RowIndex].DataBoundItem as ReportRow;
            if (row == null) return;

            bool dodrawvert = row.ReportRowKind != EReportRowKind.Blank;
            if (dodrawvert)
            {
                if(e.AdvancedBorderStyle.Left != DataGridViewAdvancedCellBorderStyle.None)
                    e.AdvancedBorderStyle.Left = dgvRows.AdvancedCellBorderStyle.Left;
                if (e.AdvancedBorderStyle.Right != DataGridViewAdvancedCellBorderStyle.None)
                    e.AdvancedBorderStyle.Right = dgvRows.AdvancedCellBorderStyle.Right;
            }
            else
            {
                e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            }

            if (e.ColumnIndex == dgcCaption.Index)
            {
                bool dodrawbottom = row.ReportRowKind == EReportRowKind.Last ||
                    row.ReportRowKind == EReportRowKind.Blank;
                if (dodrawbottom)
                    e.AdvancedBorderStyle.Bottom = dgvRows.AdvancedCellBorderStyle.Bottom;
                else
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            }
        }

        private void dgvRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= dgcD1.Index && e.ColumnIndex <= dgcD31.Index)
            {
                var cell = dgvRows[e.ColumnIndex, e.RowIndex];
                int daynr = e.ColumnIndex - dgcD1.Index + 1;
                var row = dgvRows.Rows[e.RowIndex].DataBoundItem as ReportRow;
                if (row == null) return;
                if (row.ReportRowKind == EReportRowKind.Blank) return;
                ECellKind ck = row.CX[daynr - 1];
                switch (ck)
                {
                    case ECellKind.Plain: 
                        cell.Style = dgvRows.DefaultCellStyle;
                        break;
                    case ECellKind.FreeDay:
                        cell.Style = myStyleDefs1.FreeDay;
                        break;
                    case ECellKind.Vacation:
                        cell.Style = myStyleDefs1.Vacation;
                        break;
                    case ECellKind.SickLeave:
                        cell.Style = myStyleDefs1.SickDay;
                        break;
                    case ECellKind.Holiday:
                        cell.Style = myStyleDefs1.HolyDay;
                        break;
                    case ECellKind.HeaderHoliday:
                        cell.Style = myStyleDefs1.HeaderHolyDay;
                        break;
                    case ECellKind.HeaderWeekEnd:
                        cell.Style = myStyleDefs1.HeaderWeekEnd;
                        break;
                }
                e.FormattingApplied = true;
                return;

            }
        }

        private void cmFilter_Click(object sender, EventArgs e)
        {
            DoMakeReport();
        }

    }

}
