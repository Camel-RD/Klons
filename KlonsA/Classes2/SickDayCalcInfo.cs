using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsLIB.Misc;
using KlonsLIB.Data;

namespace KlonsA.Classes
{
    public class SickDayCalcInfo
    {
        public bool PreparingReport = false;
        public SickDayCalcInfo TotalSDCI = null;
        public List<SickDayCalcRow> Rows = null;
        public SickDayCalcRow TotalRow = null;

        public AvPayCalcInfo AvPayCalc = null;
        public bool IsAvPayCalcDone = false;
        public decimal AvPayRateHour = 0.0M;
        public decimal AvPayRateDay = 0.0M;
        public decimal AvPayRateCalendarDay = 0.0M;

        public SickDayCalcInfo(bool filllist)
        {
            TotalRow = new SickDayCalcRow();
            TotalRow.IsTotal = true;
            PreparingReport = filllist;
            if (PreparingReport)
            {
                Rows = new List<SickDayCalcRow>();
            }
        }

        public ErrorList CalcSickDaysT(SalaryCalcTInfo scti)
        {
            var sr = scti.SRS.TotalRow;
            sr.CheckLinkedRows(sr.Row.IDP);

            var err = new ErrorList();

            scti.TotalSI._SICKDAYS = 0;
            scti.TotalSI._SICKDAYS_PAY = 0.0M;

            if (sr.IsSingleRow())
            {
                err = CalcSickDaysB(sr, null);
                if (err.HasErrors) return err;

                scti.TotalSI._SICKDAYS = TotalRow.DaysCount;
                scti.TotalSI._SICKDAYS_PAY = TotalRow.SickDayPay;

                if (PreparingReport) scti.LinkedSCI[0].SickDayCalc = this;
                return err;
            }

            TotalSDCI = new SickDayCalcInfo(PreparingReport);
            TotalSDCI.SetAvPayFrom(this);
            err = TotalSDCI.CalcSickDaysA(sr.SalarySheetRowSet);
            if (err.HasErrors) return err;
            SetAvPayFrom(TotalSDCI);

            if (TotalSDCI.TotalRow.DaysCount == 0) new ErrorList();


            SickDayCalcInfo[] sdcs = null;
            string[] positions = null;

            var srs = sr.SalarySheetRowSet;

            sdcs = new SickDayCalcInfo[srs.LinkedRows.Length];
            positions = new string[srs.LinkedRows.Length];

            for (int i = 0; i < srs.LinkedRows.Length; i++)
            {
                var lr = srs.LinkedRows[i];
                var sci = scti.LinkedSCI[i];
                var sdc = new SickDayCalcInfo(PreparingReport);
                positions[i] = lr.GetPositionTitle();
                sdcs[i] = sdc;
                sdc.SetAvPayFrom(this);

                sci.SI._SICKDAYS = 0;
                sci.SI._SICKDAYS_PAY = 0.0M;

                err = sdc.CalcSickDaysB(lr, TotalSDCI);
                if (err.HasErrors) return err;

                sci.SI._SICKDAYS = sdc.TotalRow.DaysCount;
                sci.SI._SICKDAYS_PAY = sdc.TotalRow.SickDayPay;

                if (PreparingReport) sci.SickDayCalc = sdc;
            }
            SumTotalPay(sdcs, TotalSDCI);

            scti.TotalSI._SICKDAYS = TotalRow.DaysCount;
            scti.TotalSI._SICKDAYS_PAY = TotalRow.SickDayPay;

            if (PreparingReport) PrepareListT(sdcs, positions);

            return new ErrorList();
        }

        public ErrorList CalcSickDays(SalaryCalcInfo sci)
        {
            ErrorList err;
            if (!sci.SR.IsSingleRow())
                throw new Exception("Bad call.");
            SetAvPayFrom(sci);

            err = CalcSickDaysB(sci.SR, null);
            if (err.HasErrors) return err;

            SetAvPayTo(sci);

            sci.SI._SICKDAYS = TotalRow.DaysCount;
            sci.SI._SICKDAYS_PAY = TotalRow.SickDayPay;

            return err;
        }

        public ErrorList CalcSickDays(SalarySheetRowInfo sr)
        {
            var err = sr.CheckLinkedRows(sr.Row.IDP);
            if (err.HasErrors) return err;

            if (sr.IsSingleRow())
            {
                err = CalcSickDaysB(sr, null);
                return err;
            }

            TotalSDCI = new SickDayCalcInfo(PreparingReport);
            err = TotalSDCI.CalcSickDaysA(sr.SalarySheetRowSet);
            if (err.HasErrors) return err;

            if (TotalSDCI.TotalRow.DaysCount == 0) new ErrorList();

            SetAvPayFrom(TotalSDCI);

            SickDayCalcInfo[] sdcs = null;
            string[] positions = null;

            if (sr.Row.XType == ESalarySheetRowType.Total)
            {
                var srs = sr.SalarySheetRowSet;

                sdcs = new SickDayCalcInfo[srs.LinkedRows.Length];
                positions = new string[srs.LinkedRows.Length];

                for (int i = 0; i < srs.LinkedRows.Length; i++)
                {
                    var lr = srs.LinkedRows[i];
                    var sdc = new SickDayCalcInfo(PreparingReport);
                    positions[i] = lr.GetPositionTitle();
                    sdcs[i] = sdc;
                    sdc.SetAvPayFrom(this);

                    err = sdc.CalcSickDaysB(lr, TotalSDCI);
                    if (err.HasErrors) return err;
                }
                SumTotalPay(sdcs, TotalSDCI);
                if (PreparingReport) PrepareListT(sdcs, positions);
            }
            else
            {
                if (PreparingReport) PrepareListA(sr.GetPositionTitle());
                err = CalcSickDaysB(sr, TotalSDCI);
                if (err.HasErrors) return err;
            }

            return new ErrorList();
        }

        public bool IsSummedTimeRate(SalarySheetRowInfo sr)
        {
            var posr = sr.PositionsR.LinkedPeriods[0].Item1 as KlonsADataSet.POSITIONS_RRow;
            return posr.XRateType == ESalaryType.Hour;
        }


        public ErrorList CalcSickDaysA(SalarySheetRowSetInfo srs)
        {
            var dt1 = srs.SalarySheet.DT1;
            var dt2 = srs.SalarySheet.DT2;
            var mdt1 = srs.SalarySheet.MDT1;
            var mdt2 = srs.SalarySheet.MDT2;
            var mdt3 = srs.SalarySheet.MDT1.AddMonths(-1);

            var ps = srs.Events.SickDays.LinkedPeriods.Where(
                d =>
                d.EEventId == EEventId.Slimības_lapa_A &&
                d.DateLast >= dt1 &&
                d.DateLast <= dt2
                ).ToArray();

            if (ps.Length == 0) return new ErrorList();

            int d1;

            SickDayCalcRow sdi = TotalRow;

            foreach (var pi in ps)
            {
                var dtp1 = pi.DateFirst;
                if (dtp1 < mdt3) continue;

                d1 = 0;

                if (PreparingReport)
                {
                    sdi = new SickDayCalcRow();
                    sdi.DateStart = pi.DateFirst;
                    sdi.DateEnd = pi.DateLast;
                    Rows.Add(sdi);
                }

                if (dtp1 < mdt1)
                {
                    var prevdlrowset = srs.GetDLRowSetList(-1);
                    if (prevdlrowset != null)
                    {
                        var dtp2 = dtp1.LastDayOfMonth();
                        prevdlrowset.CountSickDays(sdi, dtp1, dtp2, 0);

                        d1 = (dtp2 - dtp1).Days + 1;
                        if (d1 <= 10)
                        {
                            var dlrowset = srs.GetDLRowSetList();
                            dlrowset.CountSickDays(sdi, mdt1, pi.DateLast, d1);
                        }
                    }
                }
                else
                {
                    var dlrowset = srs.GetDLRowSetList();
                    dlrowset.CountSickDays(sdi, pi.DateFirst, pi.DateLast, d1);
                }

                if (PreparingReport)
                    TotalRow.AddB(sdi);
            }

            if (PreparingReport)
            {
                Rows.Add(TotalRow);
                PrepareListA();
            }

            if (TotalRow.DaysCount == 0) return new ErrorList();

            var err = GatAvPay(srs.TotalRow);
            if (err.HasErrors) return err;

            decimal _AvPayRate = AvPayRateDay;
            if (IsSummedTimeRate(srs.LinkedRows[0])) _AvPayRate = AvPayRateCalendarDay;
            TotalRow.AvPayRate = _AvPayRate;

            TotalRow.SickDayPay75 = KlonsData.RoundA(_AvPayRate * TotalRow.DaysCount75 * 0.75M, 2);
            TotalRow.SickDayPay80 = KlonsData.RoundA(_AvPayRate * TotalRow.DaysCount80 * 0.8M, 2);
            TotalRow.SickDayPay = TotalRow.SickDayPay75 + TotalRow.SickDayPay80;

            return new ErrorList();
        }

        public ErrorList CalcSickDaysB(SalarySheetRowInfo sr, SickDayCalcInfo totalsdci)
        {
            var dt1 = sr.SalarySheet.DT1;
            var dt2 = sr.SalarySheet.DT2;
            var mdt1 = sr.SalarySheet.MDT1;
            var mdt2 = sr.SalarySheet.MDT2;
            var mdt3 = sr.SalarySheet.MDT1.AddMonths(-1);

            var ps = sr.Events.SickDays.LinkedPeriods.Where(
                d =>
                d.EEventId == EEventId.Slimības_lapa_A &&
                d.DateLast >= dt1 &&
                d.DateLast <= dt2
                ).ToArray();

            if (ps.Length == 0) return new ErrorList();

            int d1;

            SickDayCalcRow sdi = TotalRow;

            foreach (var pi in ps)
            {
                var dtp1 = pi.DateFirst;
                if (dtp1 < mdt3) continue;

                d1 = 0;

                if (PreparingReport)
                {
                    sdi = new SickDayCalcRow();
                    sdi.DateStart = pi.DateFirst;
                    sdi.DateEnd = pi.DateLast;
                    Rows.Add(sdi);
                }


                if (dtp1 < mdt1)
                {
                    var prevdlrowset = sr.GetDLRowSet(-1, sr.Row.IDAM);
                    if (prevdlrowset != null)
                    {
                        var dtp2 = dtp1.LastDayOfMonth();
                        prevdlrowset.CountSickDays(sdi, dtp1, dtp2, 0);

                        d1 = (dtp2 - dtp1).Days + 1;
                        if (d1 <= 10)
                        {
                            sr.DLRows.CountSickDays(sdi, mdt1, pi.DateLast, d1);
                        }
                    }
                }
                else
                {
                    sr.DLRows.CountSickDays(sdi, pi.DateFirst, pi.DateLast, d1);
                }

                if (PreparingReport)
                    TotalRow.AddB(sdi);
            }

            if (PreparingReport)
            {
                Rows.Add(TotalRow);
                PrepareListA();
            }

            if (TotalRow.DaysCount == 0) return new ErrorList();

            var err = GatAvPay(sr);
            if (err.HasErrors) return err;

            decimal _AvPayRate = AvPayRateDay;
            if (IsSummedTimeRate(sr)) _AvPayRate = AvPayRateCalendarDay;
            TotalRow.AvPayRate = _AvPayRate;

            if (totalsdci == null)
            {
                TotalRow.SickDayPay75 = KlonsData.RoundA(_AvPayRate * TotalRow.DaysCount75 * 0.75M, 2);
                TotalRow.SickDayPay80 = KlonsData.RoundA(_AvPayRate * TotalRow.DaysCount80 * 0.8M, 2);
            }
            else
            {
                TotalRow.SickDayPay75 = (decimal)TotalRow.HoursCount75 / (decimal)totalsdci.TotalRow.HoursCount75;
                TotalRow.SickDayPay80 = (decimal)TotalRow.HoursCount80 / (decimal)totalsdci.TotalRow.HoursCount80;
                TotalRow.SickDayPay75 = KlonsData.RoundA(TotalRow.SickDayPay75 * totalsdci.TotalRow.SickDayPay75, 2);
                TotalRow.SickDayPay80 = KlonsData.RoundA(TotalRow.SickDayPay80 * totalsdci.TotalRow.SickDayPay80, 2);
            }
            TotalRow.SickDayPay = TotalRow.SickDayPay75 + TotalRow.SickDayPay80;

            return new ErrorList();
        }

        public void SetAvPayFrom(SickDayCalcInfo sc)
        {
            if (sc.AvPayCalc != null) AvPayCalc = sc.AvPayCalc;
            if (IsAvPayCalcDone) return;
            IsAvPayCalcDone = sc.IsAvPayCalcDone;
            AvPayRateHour = sc.AvPayRateHour;
            AvPayRateDay = sc.AvPayRateDay;
        }

        public void SetAvPayFrom(SalaryCalcInfo sc)
        {
            if (sc.AvPayCalc != null) AvPayCalc = sc.AvPayCalc;
            if (IsAvPayCalcDone) return;
            IsAvPayCalcDone = sc.IsAvPayCalcDone;
            AvPayRateHour = sc.AvPayRateHour;
            AvPayRateDay = sc.AvPayRateDay;
        }

        public void SetAvPayTo(SalaryCalcInfo sc)
        {
            if (!IsAvPayCalcDone) return;
            sc.SetAvPayFrom(AvPayCalc, AvPayRateHour, AvPayRateDay, AvPayRateCalendarDay);
        }

        public void SetAvPayFrom(SalaryCalcTInfo sc)
        {
            if (sc.AvPayCalc != null) AvPayCalc = sc.AvPayCalc;
            if (IsAvPayCalcDone) return;
            IsAvPayCalcDone = sc.IsAvPayCalcDone;
            AvPayRateHour = sc.AvPayRateHour;
            AvPayRateDay = sc.AvPayRateDay;
            AvPayRateCalendarDay = sc.AvPayRateCalendarDay;
        }

        public void SetAvPayTo(SalaryCalcTInfo sc)
        {
            if (!IsAvPayCalcDone) return;
            sc.SetAvPayFrom(AvPayCalc, AvPayRateHour, AvPayRateDay, AvPayRateCalendarDay);
        }

        public ErrorList GatAvPay(SalarySheetRowInfo sr)
        {
            if (IsAvPayCalcDone) return new ErrorList();
            AvPayCalc = new AvPayCalcInfo(PreparingReport);
            var err = AvPayCalc.CalcList(sr);
            if (err.HasErrors) return err;
            IsAvPayCalcDone = true;
            AvPayRateHour = AvPayCalc.RateHour;
            AvPayRateDay = AvPayCalc.RateDay;
            AvPayRateCalendarDay = AvPayCalc.RateCalendarDay;
            return new ErrorList();
        }

        public void SumTotalPay(SickDayCalcInfo[] sdcs, SickDayCalcInfo totalsdc)
        {
            TotalRow = new SickDayCalcRow();
            for (int i = 0; i < sdcs.Length; i++)
            {
                var sr = sdcs[i].TotalRow;
                TotalRow.AddA(sr);
            }
            TotalRow.DaysCount = totalsdc.TotalRow.DaysCount;
            TotalRow.DaysCount0 = totalsdc.TotalRow.DaysCount0;
            TotalRow.DaysCount75 = totalsdc.TotalRow.DaysCount75;
            TotalRow.DaysCount80 = totalsdc.TotalRow.DaysCount80;
        }

        public void PrepareListA()
        {
            if (Rows == null || TotalRow == null) return;
            foreach (var r in Rows)
            {
                if (r.IsTotal || r.IsTitle) continue;
                r.Caption = string.Format("{0:dd.MM.yyyy} - {1:dd.MM.yyyy}", r.DateStart, r.DateEnd);
            }
            TotalRow.Caption = "Kopā";
        }

        public void PrepareListA(string position)
        {
            var emptyrow = new SickDayCalcRow() { IsTitle = true };
            var r1 = new SickDayCalcRow() { Caption = "Kopā amati", IsTitle = true };
            Rows.Add(r1);
            Rows.AddRange(TotalSDCI.Rows);
            //Rows.Add(emptyrow);
            r1 = new SickDayCalcRow() { Caption = position, IsTitle = true };
            Rows.Add(r1);
        }

        public void PrepareListT(SickDayCalcInfo[] sdcs, string[] positions)
        {
            var emptyrow = new SickDayCalcRow() { IsTitle = true };

            var r1 = new SickDayCalcRow() { Caption = "Kopā amati", IsTitle = true };
            Rows.Add(r1);
            Rows.AddRange(TotalSDCI.Rows);

            for (int i = 0; i < sdcs.Length; i++)
            {
                //Rows.Add(emptyrow);
                r1 = new SickDayCalcRow() { Caption = positions[i], IsTitle = true };
                Rows.Add(r1);
                Rows.AddRange(sdcs[i].Rows);
            }
        }

    }

    public class SickDayCalcRow
    {
        public bool IsTotal { get; set; } = false;
        public bool IsTitle { get; set; } = false;
        public string Caption { get; set; } = "";
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int DaysCount { get; set; } = 0;
        public int DaysCount0 { get; set; } = 0;
        public int DaysCount75 { get; set; } = 0;
        public int DaysCount80 { get; set; } = 0;
        public float HoursCount { get; set; } = 0.0f;
        public float HoursCount75 { get; set; } = 0.0f;
        public float HoursCount80 { get; set; } = 0.0f;
        public decimal AvPayRate { get; set; } = 0.0M;
        public decimal SickDayPay { get; set; } = 0.0M;
        public decimal SickDayPay75 { get; set; } = 0.0M;
        public decimal SickDayPay80 { get; set; } = 0.0M;

        public void Clear()
        {
            DaysCount = 0;
            DaysCount0 = 0;
            DaysCount75 = 0;
            DaysCount80 = 0;
            HoursCount = 0.0f;
            HoursCount75 = 0.0f;
            HoursCount80 = 0.0f;
            AvPayRate = 0.0M;
            SickDayPay = 0.0M;
            SickDayPay75 = 0.0M;
            SickDayPay80 = 0.0M;
        }

        public void AddA(SickDayCalcRow sdc)
        {
            HoursCount += sdc.HoursCount;
            HoursCount75 += sdc.HoursCount75;
            HoursCount80 += sdc.HoursCount80;
            SickDayPay += sdc.SickDayPay;
            SickDayPay75 += sdc.SickDayPay75;
            SickDayPay80 += sdc.SickDayPay80;
        }

        public void AddB(SickDayCalcRow sdc)
        {
            DaysCount += sdc.DaysCount;
            DaysCount0 += sdc.DaysCount0;
            DaysCount75 += sdc.DaysCount75;
            DaysCount80 += sdc.DaysCount80;
            HoursCount += sdc.HoursCount;
            HoursCount75 += sdc.HoursCount75;
            HoursCount80 += sdc.HoursCount80;
        }

    }

}
