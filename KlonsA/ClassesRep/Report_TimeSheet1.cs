using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsA.Forms;
using KlonsLIB.Misc;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using System.Drawing;

namespace KlonsA.Classes
{
    public class ReportTimeSheet1
    {
        public static KlonsData MyData => KlonsData.St;

        public List<TimeReportRow1> ReportRows = null;
        public string[] Headers = new string[31];
        public string[] HeaderColors = new string[31];

        public Color HeaderHolyDay = Color.FromArgb(181, 113, 0);
        public Color HeaderWeekEndDay = Color.FromArgb(2, 62, 106);
        public Color HeaderEmptyColor = ColorTranslator.FromHtml("#eaeaea");

        public Color VacationDay = Color.YellowGreen;
        public Color SickDay = Color.IndianRed;
        public Color FreeDay = Color.FromArgb(56, 116, 197);
        public Color HolyDay = Color.FromArgb(220, 140, 0);


        public enum ERoportType
        {
            Simple,
            WithColors
        }

        public void MakeReport(DLJoinView jview, CalendarMonthInfo calmt, string title, 
            ERoportType roporttype, MyStyleDefs mystyldDefs)
        {
            HeaderHolyDay = mystyldDefs.HeaderHolyDayBack;
            HeaderWeekEndDay = mystyldDefs.HeaderWeekEndBack;
            VacationDay = mystyldDefs.VacationBack;
            SickDay = mystyldDefs.SickDayBack;
            FreeDay = mystyldDefs.FreeDayBack;
            HolyDay = mystyldDefs.HolyDayBack;

            MakeReportA(jview, calmt);
            if (ReportRows.Count == 0) return;

            var period = string.Format("{0}. gada {1}",
                calmt.Year, Utils.MonthNames[calmt.Month - 1]);

            ReportViewerData rd = new ReportViewerData();
            if(roporttype == ERoportType.Simple)
                rd.FileName = "ReportA_DarbaLaiks_1";
            else
                rd.FileName = "ReportA_DarbaLaiks_1k";
            rd.Sources["DataSet1"] = ReportRows;
            rd.AddReportParameters(new string[]
                {
                    "CompanyName", MyData.Params.CompNameX,
                    "RPerson", "",
                    "RPeriod", period,
                    "RLastVisibleDay", calmt.DaysInMonth.ToString(),
                    "RTitle", title,
                    "RRemark", ""
                });
            rd.AddReportParameter("RHeaders", Headers);
            if (roporttype == ERoportType.WithColors)
                rd.AddReportParameter("RHeaderColors", HeaderColors);
            MyData.MyMainForm.ShowReport(rd);
        }

        public void MakeReportA(DLJoinView jview, CalendarMonthInfo calmt)
        {
            ReportRows = new List<TimeReportRow1>();
            int nringroup = 0, idxprev = int.MinValue, idxcur;

            MakeColumnHeadersA(calmt);

            for (int i = 0; i < jview.Count; i++)
            {
                var jr = jview.List[i];
                var dr = jr.BaseRow.Row as KlonsADataSet.TIMESHEETRow;
                var jo = jr.AddedObject as AddToDLJoinViewRow;
                var tr = new TimeReportRow1();
                idxcur = jo.IDX;
                if(idxcur == idxprev)
                {
                    nringroup++;
                }
                else
                {
                    nringroup = 0;
                    idxprev = idxcur;
                }

                if (nringroup == 0) tr.Caption = jo.Name;
                else if(nringroup == 1) tr.Caption = "  " + jo.Position;

                if (nringroup == 0)
                {
                    tr.BottomBorderVisible = false;
                    if (ReportRows.Count > 2)
                        ReportRows[ReportRows.Count - 1].BottomBorderVisible = true;
                }
                else
                {
                    tr.BottomBorderVisible = false;
                    tr.TopBorderVisible = false;
                }
                if(i == jview.Count - 1) tr.BottomBorderVisible = true;

                tr.Type = SomeDataDefs.DarbaLaiksK1[dr.KIND1].Val;

                int dk = MyData.DataSetKlons.TIMESHEET.D1Column.Ordinal;
                for (int j = 0; j < 31; j++)
                {
                    short daycode = (short)dr[dk + j];
                    float v = dr.Vx[j];
                    tr.DX[j] = FormatCell(v, daycode, dr.XKind1);
                    var col = ColorCell(v, daycode, dr.XKind1);
                    tr.CX[j] = ColorTranslator.ToHtml(col);
                }

                tr.K1 = dr.K1.ToString();
                ReportRows.Add(tr);
            }
        }

        public string FormatCell(float v, short daycode, EKind1 kind1)
        {
            string ret = v.ToString();

            if (SomeDataDefs.IsKindPlan(kind1))
            {
                var daycodeplan = (EDayPlanId)daycode;
                if (daycodeplan == EDayPlanId.DD) return ret;
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
                if (daycodefact == EDayFactId.D) return ret;
                string daystr = SomeDataDefs.GetFactIdStr(daycodefact);
                if (v == 0.0f) ret = daystr;
                else ret = string.Format("{0} {1}", daystr, v);
                return ret;
            }

            if (v == 0.0f) return "";
            return ret;
        }

        public Color ColorCell(float v, short daycode, EKind1 kind1)
        {
            if (SomeDataDefs.IsKindPlan(kind1))
            {
                var daycodeplan = (EDayPlanId)daycode;

                switch (daycodeplan)
                {
                    case EDayPlanId.BD:
                        return FreeDay;
                    case EDayPlanId.SD:
                    case EDayPlanId.SDDD:
                    case EDayPlanId.DDSD:
                        return HolyDay;
                    default:
                        return Color.Empty;
                }

            }
            else
            {
                var daycodefact = (EDayFactId)daycode;
                if (SomeDataDefs.IsDayVacation(daycodefact))
                    return VacationDay;
                if (SomeDataDefs.IsSickDay(daycodefact))
                    return SickDay;
                if (daycodefact == EDayFactId.B)
                    return FreeDay;
                if (daycodefact == EDayFactId.S || daycodefact == EDayFactId.DS || 
                    daycodefact == EDayFactId.KS || daycodefact == EDayFactId.V)
                    return HolyDay;

                return Color.Empty;
            }
        }

        public void MakeColumnHeaders(CalendarMonthInfo calmt, TimeReportRow1 row)
        {
            string[] daystr = SomeDataDefs.GetDaysStr(calmt.WeekDays);
            for (int i = 0; i < 31; i++)
            {
                var s = daystr[i] + "\n" + (i + 1);
                var d1 = calmt.WeekDays[i];
                if (d1 == -1) s = "";
                row.DX[i] = s;
            }
            row.RowType = 1;
            row.K1 = "Σ";
        }

        public void MakeColumnHeadersA(CalendarMonthInfo calmt)
        {
            string[] daystr = SomeDataDefs.GetDaysStr(calmt.WeekDays);
            for (int i = 0; i < 31; i++)
            {
                var s = daystr[i] + "\n" + (i + 1);
                var d1 = calmt.WeekDays[i];
                if (d1 == -1) s = "";
                Headers[i] = s;

                var hd = calmt.HolyDays[i];
                var col = HeaderEmptyColor;
                if (hd == EHolyDay.Holiday)
                    col = HeaderHolyDay;
                else if (d1 == 6 || d1 == 7)
                    col = HeaderWeekEndDay;
                HeaderColors[i] = ColorTranslator.ToHtml(col);
            }
        }
    }

    public class TimeReportRow1
    {
        public string[] DX = new string[31];
        public string[] CX = new string[31]; //colors
        public int RowType { get; set; } = 0;
        public string Caption { get; set; } = "";
        public string Type { get; set; } = "";
        public bool TopBorderVisible { get; set; } = true;
        public bool BottomBorderVisible { get; set; } = true;
        public string D1 { get { return DX[0]; } set { DX[0] = value; } }
        public string D2 { get { return DX[1]; } set { DX[1] = value; } }
        public string D3 { get { return DX[2]; } set { DX[2] = value; } }
        public string D4 { get { return DX[3]; } set { DX[3] = value; } }
        public string D5 { get { return DX[4]; } set { DX[4] = value; } }
        public string D6 { get { return DX[5]; } set { DX[5] = value; } }
        public string D7 { get { return DX[6]; } set { DX[6] = value; } }
        public string D8 { get { return DX[7]; } set { DX[7] = value; } }
        public string D9 { get { return DX[8]; } set { DX[8] = value; } }
        public string D10 { get { return DX[9]; } set { DX[9] = value; } }
        public string D11 { get { return DX[10]; } set { DX[10] = value; } }
        public string D12 { get { return DX[11]; } set { DX[11] = value; } }
        public string D13 { get { return DX[12]; } set { DX[12] = value; } }
        public string D14 { get { return DX[13]; } set { DX[13] = value; } }
        public string D15 { get { return DX[14]; } set { DX[14] = value; } }
        public string D16 { get { return DX[15]; } set { DX[15] = value; } }
        public string D17 { get { return DX[16]; } set { DX[16] = value; } }
        public string D18 { get { return DX[17]; } set { DX[17] = value; } }
        public string D19 { get { return DX[18]; } set { DX[18] = value; } }
        public string D20 { get { return DX[19]; } set { DX[19] = value; } }
        public string D21 { get { return DX[20]; } set { DX[20] = value; } }
        public string D22 { get { return DX[21]; } set { DX[21] = value; } }
        public string D23 { get { return DX[22]; } set { DX[22] = value; } }
        public string D24 { get { return DX[23]; } set { DX[23] = value; } }
        public string D25 { get { return DX[24]; } set { DX[24] = value; } }
        public string D26 { get { return DX[25]; } set { DX[25] = value; } }
        public string D27 { get { return DX[26]; } set { DX[26] = value; } }
        public string D28 { get { return DX[27]; } set { DX[27] = value; } }
        public string D29 { get { return DX[28]; } set { DX[28] = value; } }
        public string D30 { get { return DX[29]; } set { DX[29] = value; } }
        public string D31 { get { return DX[30]; } set { DX[30] = value; } }
        public string K1 { get; set; } = "";

        public string C1 => CX[0];
        public string C2 => CX[1];
        public string C3 => CX[2];
        public string C4 => CX[3];
        public string C5 => CX[4];
        public string C6 => CX[5];
        public string C7 => CX[6];
        public string C8 => CX[7];
        public string C9 => CX[8];
        public string C10 => CX[9];
        public string C11 => CX[10];
        public string C12 => CX[11];
        public string C13 => CX[12];
        public string C14 => CX[13];
        public string C15 => CX[14];
        public string C16 => CX[15];
        public string C17 => CX[16];
        public string C18 => CX[17];
        public string C19 => CX[18];
        public string C20 => CX[19];
        public string C21 => CX[20];
        public string C22 => CX[21];
        public string C23 => CX[22];
        public string C24 => CX[23];
        public string C25 => CX[24];
        public string C26 => CX[25];
        public string C27 => CX[26];
        public string C28 => CX[27];
        public string C29 => CX[28];
        public string C30 => CX[29];
        public string C31 => CX[30];

    }


}
