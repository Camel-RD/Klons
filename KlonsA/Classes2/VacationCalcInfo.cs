using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsLIB.Misc;
using KlonsLIB.Data;

namespace KlonsA.Classes
{
    public class VacationCalcInfo
    {
        public bool PreparingReport = false;
        public int CalcVer = 0;
        public List<VacationCalcRow> Rows = null;
        public VacationCalcRow VcrPrev = new VacationCalcRow();
        public VacationCalcRow VcrPrevCurrent = new VacationCalcRow("A: izmaksāts iepriekš");
        public VacationCalcRow VcrCurrent = new VacationCalcRow("B: šajā periodā");
        public VacationNextCalcRow VcrNext = new VacationNextCalcRow("C: aprēķināts avansā");
        public VacationCalcRow VcrCompensation = new VacationCalcRow("D: kompensācija");

        public decimal IINReverse = 0.0M;

        public decimal AdvancePrev = 0.0M;

        public AvPayCalcInfo AvPayCalc = null;
        public bool IsAvPayCalcDone = false;
        public decimal AvPayRateHour = 0.0M;
        public decimal AvPayRateDay = 0.0M;
        public decimal AvPayRateCalendarDay = 0.0M;

        public VacationCalcInfo(bool filllist, int calcver)
        {
            PreparingReport = filllist;
            CalcVer = calcver;
            if (PreparingReport)
                Rows = new List<VacationCalcRow>();
        }

        public ErrorList CalcVacationDays(SalaryCalcInfo sci)
        {
            ErrorList err;
            if (!sci.SR.IsSingleRow())
                throw new Exception("Bad call.");

            SetAvPayFrom(sci);

            err = CalcVacationDays2(sci.SR, null, sci.SI._CALC_VER);
            if (err.HasErrors) return err;

            SetAvPayTo(sci);
            WriteTo(sci.SI);

            return err;
        }

        public ErrorList CalcVacationDaysT(SalaryCalcTInfo scti)
        {
            ErrorList err;
            var sr = scti.SRS.TotalRow;

            sr.CheckLinkedRows(sr.Row.IDP);
            SetAvPayFrom(scti);

            if (sr.IsSingleRow())
            {
                var lsci = scti.LinkedSCI[0];

                err = CalcVacationDays(lsci);
                if (err.HasErrors) return err;

                SetAvPayTo(scti);
                SetAvPayTo(lsci);
                WriteTo(lsci.SI);
                WriteTo(scti.TotalSI);
                if (PreparingReport) scti.LinkedSCI[0].VacationCalc = this;
                return err;
            }

            if (sr.Row.XType != ESalarySheetRowType.Total)
                throw new Exception("Bad call");

            GetAvPayCalc(scti.SRS.TotalRow);

            var vcs = new VacationCalcInfo[scti.LinkedSCI.Length];

            for (int i = 0; i < scti.LinkedSCI.Length; i++)
            {
                var vc = new VacationCalcInfo(PreparingReport, CalcVer);
                vcs[i] = vc;
                vc.SetAvPayFrom(this);
            }

            err = CalcVacationDays2(scti.SRS.TotalRow, vcs, scti.TotalSI._CALC_VER);
            if (err.HasErrors) return err;

            SetAvPayTo(scti);

            EnsureExactSum(vcs);

            for (int i = 0; i < scti.LinkedSCI.Length; i++)
            {
                var lsci = scti.LinkedSCI[i];
                var lr = scti.SRS.LinkedRows[i];
                var vc = vcs[i];
                lsci.VacationCalc = vc;
                vc.WriteTo(lsci.SI);
            }

            WriteTo(scti.TotalSI);

            if (PreparingReport)
            {
                var positions = new string[scti.LinkedSCI.Length];
                for (int i = 0; i < scti.LinkedSCI.Length; i++)
                {
                    var lsci = scti.LinkedSCI[i];
                    positions[i] = lsci.PositionTitle;
                }
                PrepareListT(vcs, positions, this);
            }

            return err;
        }



        private VacationCalcRow AddRepRow(VacationCalcRow pvr, string ptype, string ppos)
        {
            var vr = new VacationCalcRow();
            vr.SetFrom(pvr);
            vr.Type = ptype;
            vr.Position = ppos;
            Rows.Add(vr);
            return vr;
        }

        public bool IsAggregatedTimeRate(SalarySheetRowInfo srs)
        {
            var sr = srs.IsSingleRow() ? srs : srs.SalarySheetRowSet.LinkedRows[0];
            var posr = sr.PositionsR.LinkedPeriods[0].Item1 as KlonsADataSet.POSITIONS_RRow;
            return posr.XRateType == ESalaryType.Aggregated;
        }

        public ErrorList CalcVacationDays2(SalarySheetRowInfo srs, VacationCalcInfo[] vcs, int calcver)
        {
            var error_list = new ErrorList();

            if (vcs != null && srs != srs?.SalarySheetRowSet?.TotalRow)
                throw new ArgumentException("Bad call.");

            var dt1 = srs.SalarySheet.DT1;
            var dt2 = srs.SalarySheet.DT2;
            var mdt1 = srs.SalarySheet.MDT1;
            var mdt2 = srs.SalarySheet.MDT2;

            var ps = srs.Events.Vacations.LinkedPeriods.Where(
                d =>
                {
                    if (!SomeDataDefs.IsEventPaidVacation(d.EEventId)) return false;

                    var dr_not = (d.Item1 as KlonsADataSet.EVENTSRow);
                    if (dr_not.IsDATE3Null()) return false;

                    return (d.DateFirst <= dt2 && d.DateLast >= dt1) ||
                        (dr_not.DATE3 >= dt1 && dr_not.DATE3 <= dt2);
                }).ToArray();


            // kompensācija atlaižot
            var fire_evs = srs.Events.HireFire.LinkedPeriods
                .Where(d => d.DateLast >= dt1 && d.DateLast <= dt2)
                .ToArray();

            if (ps.Length == 0 && fire_evs.Length == 0) return error_list;

            var ps_cur = ps.Where(
                d =>
                d.DateFirst <= dt2 && d.DateLast >= dt1
                ).ToArray();

            var ps_next = ps.Where(
                d =>
                {
                    var dr_not = (d.Item1 as KlonsADataSet.EVENTSRow);
                    if (dr_not.IsDATE3Null()) return false;
                    return (d.DateLast > dt2) &&
                        (dr_not.DATE3 >= dt1 && dr_not.DATE3 <= dt2);
                }).ToArray();

            var ps_prev = ps_cur.Where(
                d =>
                {
                    var dr_not = (d.Item1 as KlonsADataSet.EVENTSRow);
                    if (dr_not.IsDATE3Null()) return false;
                    return dr_not.DATE3 < dt1;
                }).ToArray();



            SalaryInfo prevsi = srs.GetPrevRow();
            if (prevsi != null)
            {
                VcrPrev.Pay = prevsi._VACATION_PAY_NEXT;
                VcrPrev.DNS = prevsi._VACATION_DNS_NEXT;
                VcrPrev.IIN = prevsi._VACATION_IIN_NEXT;
                AdvancePrev = prevsi._VACATION_ADVANCE_NEXT;

                if (vcs != null)
                {
                    for (int i = 0; i < vcs.Length; i++)
                    {
                        var vci = vcs[i];
                        if (vci == null) continue;
                        var sr = srs.SalarySheetRowSet.LinkedRows[i];
                        var prevsi2 = sr.GetPrevRow();
                        if (prevsi2 == null) continue;
                        vci.VcrPrev.Pay = prevsi._VACATION_PAY_NEXT;
                        vci.VcrPrev.DNS = prevsi._VACATION_DNS_NEXT;
                        vci.VcrPrev.IIN = prevsi._VACATION_IIN_NEXT;
                        vci.AdvancePrev = prevsi._VACATION_ADVANCE_NEXT;
                    }
                }
            }

            error_list += GetAvPayCalc(srs);
            if (error_list.HasErrors) return error_list;

            float caldays = 0;
            VacationCalcRow vt = new VacationCalcRow();
            VacationCalcRow v = new VacationCalcRow();
            TimeSheetRowSetList dlrowsetT = null;
            TimeSheetRowSet dlrowset = null;
            decimal r = 0.0M;

            decimal _AvPayRate = AvPayRateDay;
            if (IsAggregatedTimeRate(srs)) _AvPayRate = AvPayRateCalendarDay;
            vt.AvPayRate = _AvPayRate;

            caldays = 0;
            foreach (var pi in ps_prev)
            {
                vt.DateStart = pi.DateFirst;
                vt.DateEnd = pi.DateLast;
                if (vt.DateStart < dt1) vt.DateStart = dt1;
                if (vt.DateEnd > dt2) vt.DateEnd = dt2;

                if (dlrowsetT == null) dlrowsetT = srs.GetDLRowSetList();
                dlrowsetT.CountVacationTime(vt);
                caldays += (vt.DateEnd - vt.DateStart).Days + 1;
                VcrPrevCurrent.CalcAndAdd(srs, vt, _AvPayRate, CalcVer);

                if (PreparingReport) AddRepRow(vt, "A", "Kopā");

                if(vcs != null)
                {
                    v.DateStart = vt.DateStart;
                    v.DateEnd = vt.DateEnd;

                    int ct = vcs.Where(d => d != null).Count();

                    for (int i = 0; i < vcs.Length; i++)
                    {
                        var vci = vcs[i];
                        if (vci == null) continue;
                        var sr = srs.SalarySheetRowSet.LinkedRows[i];
                        dlrowset = dlrowsetT[i];
                        dlrowset.CountVacationTime(v);

                        if (vt.Hours == 0.0f)
                            r = 1.0M / (decimal)ct;
                        else
                            r = (decimal)(v.Hours / vt.Hours);

                        v.Pay = KlonsData.RoundA(vt.Pay * r, 2);
                        vci.VcrPrevCurrent.CalcAndAddSplit(sr, v, CalcVer);

                        if (PreparingReport) vci.AddRepRow(vt, "A", sr.GetPositionTitle());
                    }
                }
            }

            caldays = 0;
            foreach (var pi in ps_cur)
            {
                vt.DateStart = pi.DateFirst;
                vt.DateEnd = pi.DateLast;
                if (vt.DateStart < dt1) vt.DateStart = dt1;
                if (vt.DateEnd > dt2) vt.DateEnd = dt2;

                if (dlrowsetT == null) dlrowsetT = srs.GetDLRowSetList();
                dlrowsetT.CountVacationTime(vt);
                caldays += (vt.DateEnd - vt.DateStart).Days + 1;
                VcrCurrent.CalcAndAdd(srs, vt, _AvPayRate, CalcVer);

                if (PreparingReport) AddRepRow(vt, "B", "Kopā");

                if (vcs != null)
                {
                    v.DateStart = vt.DateStart;
                    v.DateEnd = vt.DateEnd;

                    int ct = vcs.Where(d => d != null).Count();

                    for (int i = 0; i < vcs.Length; i++)
                    {
                        var vci = vcs[i];
                        if (vci == null) continue;
                        var sr = srs.SalarySheetRowSet.LinkedRows[i];

                        dlrowset = dlrowsetT[i];
                        dlrowset.CountVacationTime(v);

                        if (vt.Hours == 0.0f)
                            r = 1.0M / (decimal)ct;
                        else
                            r = (decimal)(v.Hours / vt.Hours);

                        v.Pay = KlonsData.RoundA(vt.Pay * r, 2);
                    }

                    Utils.MakeExactSum(vt.Pay, vcs,
                        d => d.VcrCurrent.Pay,
                        (d, val) => d.VcrCurrent.Pay = val);

                    for (int i = 0; i < vcs.Length; i++)
                    {
                        var vci = vcs[i];
                        if (vci == null) continue;
                        var sr = srs.SalarySheetRowSet.LinkedRows[i];
                        vci.VcrCurrent.CalcAndAddSplit(sr, v, CalcVer);
                        if (PreparingReport) vci.AddRepRow(vt, "B", sr.GetPositionTitle());
                    }

                }
            }

            foreach (var pi in ps_next)
            {
                vt.DateStart = dt2.AddDays(1);
                vt.DateEnd = pi.DateLast;
                if (vt.DateStart < pi.DateFirst) vt.DateStart = pi.DateFirst;
                var dtpe = vt.DateStart.LastDayOfMonth();
                if (vt.DateEnd > dtpe) vt.DateEnd = dtpe;

                while (true)
                {
                    int addmt = Utils.MonthDiff(dt1, vt.DateStart);

                    var nextdlrowsetT = srs.GetDLRowSetList(addmt);
                    if (nextdlrowsetT.Count == 0) break;

                    nextdlrowsetT.CountVacationTime(vt);
                    caldays += (vt.DateEnd - vt.DateStart).Days + 1;
                    VcrNext.CalcAndAddNext(srs, vt, _AvPayRate);

                    if (PreparingReport) AddRepRow(vt, "C", "Kopā");


                    if (vcs != null)
                    {
                        v.DateStart = vt.DateStart;
                        v.DateEnd = vt.DateEnd;

                        int ct = vcs.Where(d => d != null).Count();

                        for (int i = 0; i < vcs.Length; i++)
                        {
                            var vci = vcs[i];
                            if (vci == null) continue;
                            var sr = srs.SalarySheetRowSet.LinkedRows[i];

                            var nextdlrowset = nextdlrowsetT[i];
                            if(nextdlrowset == null)
                            {
                                //error_list.AddPersonError(srs.DR_Person_r.ID, )
                            }
                            nextdlrowset.CountVacationTime(v);

                            if (vt.Hours == 0.0f)
                                r = 1.0M / (decimal)ct;
                            else
                                r = (decimal)(v.Hours / vt.Hours);

                            v.Pay = KlonsData.RoundA(vt.Pay * r, 2);
                        }

                        Utils.MakeExactSum(vt.Pay, vcs,
                            d => d.VcrNext.Pay,
                            (d, val) => d.VcrNext.Pay = val);

                        for (int i = 0; i < vcs.Length; i++)
                        {
                            var vci = vcs[i];
                            if (vci == null) continue;
                            var sr = srs.SalarySheetRowSet.LinkedRows[i];
                            vci.VcrNext.CalcAndAddNextA(sr, v);
                            if (PreparingReport) vci.AddRepRow(vt, "C", sr.GetPositionTitle());
                        }

                    }

                    if (vt.DateEnd == pi.DateLast) break;
                    vt.DateStart = dtpe.AddDays(1);
                    vt.DateEnd = pi.DateLast;
                    dtpe = dtpe.AddDays(1).LastDayOfMonth();
                    if (vt.DateEnd > dtpe) vt.DateEnd = dtpe;
                }

            }

            // kompensācija atlaižot
            vt.Days = 0;
            foreach (var fe in fire_evs)
            {
                var dr_ev = fe.Item2 as KlonsADataSet.EVENTSRow;
                if (dr_ev == null) continue;
                if(calcver == KlonsData.VersionRef(0))
                    vt.Days += dr_ev.DAYS;
                else
                    vt.Days += dr_ev.DAYS2;
            }
            if (vt.Days > 0)
            {
                error_list += GetAvPayCalc(srs);
                if (error_list.HasErrors) return error_list;

                vt.DateStart = srs.SalarySheet.DT1;
                vt.DateEnd = srs.SalarySheet.DT2;
                caldays = vt.Days;
                vt.Hours = 0.0f;

                VcrCompensation.CalcAndAdd(srs, vt, AvPayRateCalendarDay, CalcVer);

                if (PreparingReport) AddRepRow(vt, "D", "Kopā");

                if (vcs != null)
                {
                    v.DateStart = vt.DateStart;
                    v.DateEnd = vt.DateEnd;
                    v.Days = vt.Days;
                    v.Hours = 0.0f;

                    int ct = vcs.Where(d => d != null).Count();

                    for (int i = 0; i < vcs.Length; i++)
                    {
                        var vci = vcs[i];
                        if (vci == null) continue;
                        var sr = srs.SalarySheetRowSet.LinkedRows[i];

                        r = 1.0M / (decimal)ct;
                        v.Pay = KlonsData.RoundA(vt.Pay * r, 2);
                    }

                    Utils.MakeExactSum(vt.Pay, vcs,
                        d => d.VcrCompensation.Pay,
                        (d, val) => d.VcrCompensation.Pay = val);

                    for (int i = 0; i < vcs.Length; i++)
                    {
                        var vci = vcs[i];
                        if (vci == null) continue;
                        var sr = srs.SalarySheetRowSet.LinkedRows[i];
                        vci.VcrCompensation.CalcAndAddSplit(sr, v, CalcVer);
                        if (PreparingReport) vci.AddRepRow(vt, "D", sr.GetPositionTitle());
                    }
                }
            }

            VcrNext.CalcAll(srs, vcs, CalcVer);

            if (PreparingReport) PrepareRows();
            return error_list;
        }

        public void SumTotals(VacationCalcInfo[] vcs, VacationCalcInfo totalvc)
        {
            VcrPrevCurrent = new VacationCalcRow("A: izmaksāts iepriekš");
            VcrCurrent = new VacationCalcRow("B: šajā periodā");
            VcrNext = new VacationNextCalcRow("C: aprēķināts avansā");
            VcrCompensation = new VacationCalcRow("D: kompensācija");

            foreach (var vc in vcs)
            {
                VcrPrevCurrent.Add(vc.VcrPrevCurrent);
                VcrCurrent.Add(vc.VcrCurrent);
                VcrCompensation.Add(vc.VcrCompensation);
                VcrNext.Add(vc.VcrNext);
            }

            VcrPrevCurrent.Days = totalvc.VcrPrevCurrent.Days;
            VcrCurrent.Days = totalvc.VcrCurrent.Days;
            VcrCompensation.Days = totalvc.VcrCompensation.Days;
            VcrNext.Days = totalvc.VcrNext.Days;
        }

        private void EnsureExactSum(VacationCalcInfo[] vx)
        {
            EnsureExactSum(vx, d => d.VcrPrev);
            EnsureExactSum(vx, d => d.VcrCurrent);
            EnsureExactSum(vx, d => d.VcrNext);
            EnsureExactSum(vx, d => d.VcrCompensation);
        }

        private void EnsureExactSum(VacationCalcInfo[] vx,
            Func<VacationCalcInfo, VacationCalcRow> fget)
        {
            foreach (var vi in vx)
            {
                EnsureExactSum(fget(this), vx, fget, d => d.Pay, (d, s) => d.Pay = s);
                EnsureExactSum(fget(this), vx, fget, d => d.DNS, (d, s) => d.DNS = s);
                EnsureExactSum(fget(this), vx, fget, d => d.BeforeIINEX, (d, s) => d.BeforeIINEX = s);
                EnsureExactSum(fget(this), vx, fget, d => d.IINEX, (d, s) => d.IINEX = s);
                EnsureExactSum(fget(this), vx, fget, d => d.Cash, (d, s) => d.Cash = s);
            }
        }

        private void EnsureExactSum(VacationCalcRow v, VacationCalcInfo[] vx,
            Func<VacationCalcInfo, VacationCalcRow> fgetx,
            Func<VacationCalcRow, decimal> fget, Action<VacationCalcRow, decimal> fset)
        {
            VacationCalcRow v0 = null;
            decimal s = fget(v);
            foreach (var vi in vx)
            {
                var vj = fgetx(vi);
                decimal d = fget(vj);
                s -= d;
                if (v0 == null && d != 0.0M) v0 = vj;
            }
            if (v0 != null) fset(v0, fget(v0) + s);
        }

        private void PrepareRows()
        {
            foreach (var r in Rows)
            {
                r.Caption = string.Format("{0}: {1:dd.MM.yyyy} - {2:dd.MM.yyyy}",
                    r.Type, r.DateStart, r.DateEnd);
            }

            Rows.Add(new VacationCalcRow());
            Rows.Add(VcrPrevCurrent);
            Rows.Add(VcrCurrent);
            Rows.Add(VcrNext);
            Rows.Add(VcrCompensation);
        }

        private void PrepareListB(SalarySheetRowInfo sr, VacationCalcInfo totalvc)
        {
            if (totalvc.Rows.Count == 0) return;
            var rows2 = new List<VacationCalcRow>();
            var r1 = new VacationCalcRow();
            r1.Caption = "Kopā";
            rows2.Add(r1);
            rows2.AddRange(totalvc.Rows);

            rows2.Add(new VacationCalcRow());

            r1 = new VacationCalcRow();
            r1.Caption = sr.GetPositionTitle();
            rows2.Add(r1);
            rows2.AddRange(Rows);
            Rows = rows2;
        }

        private void PrepareListT(VacationCalcInfo[] vcs, string[] positions, VacationCalcInfo totalvc)
        {
            if (totalvc.Rows.Count == 0) return;

            var Rows2 = new List<VacationCalcRow>();

            Rows2.Add(new VacationCalcRow() { Caption = "Kopsummas" });
            Rows2.AddRange(totalvc.Rows);

            var emptyrow = new VacationCalcRow() { };
            for (int i = 0; i < vcs.Length; i++)
            {
                Rows2.Add(emptyrow);
                Rows2.Add(new VacationCalcRow() { Caption = positions[i] });
                Rows2.AddRange(vcs[i].Rows);
            }
            Rows = Rows2;
        }

        public void SetAvPayFrom(VacationCalcInfo vc)
        {
            if(vc.AvPayCalc != null) AvPayCalc = vc.AvPayCalc;
            if (IsAvPayCalcDone) return;
            IsAvPayCalcDone = vc.IsAvPayCalcDone;
            AvPayRateHour = vc.AvPayRateHour;
            AvPayRateDay = vc.AvPayRateDay;
            AvPayRateCalendarDay = vc.AvPayRateCalendarDay;
        }

        public void SetAvPayFrom(SalaryCalcInfo sc)
        {
            if (sc.AvPayCalc != null) AvPayCalc = sc.AvPayCalc;
            if (IsAvPayCalcDone) return;
            IsAvPayCalcDone = sc.IsAvPayCalcDone;
            AvPayRateHour = sc.AvPayRateHour;
            AvPayRateDay = sc.AvPayRateDay;
            AvPayRateCalendarDay = sc.AvPayRateCalendarDay;
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

        public ErrorList GetAvPayCalc(SalarySheetRowInfo sr)
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

        public void WriteTo(SalaryInfo si)
        {
            si._VACATION_ADVANCE_PREV = AdvancePrev;
            si._VACATION_CASH_NEXT = VcrNext.Cash;
            si._VACATION_ADVANCE_CURRENT = 0.0M;
            si._VACATION_ADVANCE_NEXT = 0.0M;

            si._VACATION_PAY_PREV = VcrPrevCurrent.Pay;
            si._VACATION_DNS_PREV = VcrPrevCurrent.DNS;
            //si._VACATION_DDS_PREV = VcrPrevCurrent.DDS;
            si._VACATION_IIN_PREV = VcrPrevCurrent.IIN;

            si._VACATION_DAYS_CURRENT = VcrCurrent.Days + VcrCompensation.Days;
            si._VACATION_HOURS_CURRENT = VcrCurrent.Hours;
            si._VACATION_PAY_CURRENT = VcrCurrent.Pay + VcrCompensation.Pay;

            si._VACATION_DAYS_NEXT = VcrNext.Days;
            si._VACATION_HOURS_NEXT = VcrNext.Hours;
            si._VACATION_PAY_NEXT = VcrNext.Pay;
            si._VACATION_DNS_NEXT = VcrNext.DNS;
            //si._VACATION_DDS_NEXT = VcrNext.DDS;
            si._VACATION_IIN_NEXT = VcrNext.IIN;
            si._VACATION_IIN_REDUCE_NEXT = IINReverse;

            si._VACATION_DAYS_COMP = VcrCompensation.Days;
            si._VACATION_PAY_COMP = VcrCompensation.Pay;
        }

    }

    public class VacationNextCalcRow : VacationCalcRow
    {
        public Dictionary<int, VacationCalcRow> PerMonth = new Dictionary<int, VacationCalcRow>();

        public VacationNextCalcRow(string caption = "")
        {
            Caption = caption;
        }

        public void CalcAndAddNext(SalarySheetRowInfo sr, VacationCalcRow v,
            decimal AvPayRateDay)
        {
            v.AvPayRate = AvPayRateDay;
            v.Pay = KlonsData.RoundA(AvPayRateDay * (decimal)v.Days, 2);
            Add(v);
            VacationCalcRow vcmt = null;
            int yrmt = v.DateStart.Year * 12 + v.DateStart.Month - 1;
            if(!PerMonth.TryGetValue(yrmt, out vcmt))
            {
                vcmt = new VacationCalcRow();
                vcmt.DateStart = v.DateStart;
                vcmt.DateEnd = v.DateEnd;
                //vcmt.DateStart = new DateTime(v.DateStart.Year, v.DateStart.Month, 1);
                //vcmt.DateEnd = vcmt.DateStart.LastDayOfMonth();
                PerMonth[yrmt] = vcmt;
            }
            vcmt.Add(v);
        }

        public void CalcAndAddNextA(SalarySheetRowInfo sr, VacationCalcRow v)
        {
            Add(v);
            VacationCalcRow vcmt = null;
            int yrmt = v.DateStart.Year * 12 + v.DateStart.Month - 1;
            if (!PerMonth.TryGetValue(yrmt, out vcmt))
            {
                vcmt = new VacationCalcRow();
                vcmt.DateStart = v.DateStart;
                vcmt.DateEnd = v.DateEnd;
                //vcmt.DateStart = new DateTime(v.DateStart.Year, v.DateStart.Month, 1);
                //vcmt.DateEnd = vcmt.DateStart.LastDayOfMonth();
                PerMonth[yrmt] = vcmt;
            }
            vcmt.Add(v);
        }

        public void CalcAll(SalarySheetRowInfo sr, VacationCalcInfo[] vcs, int calcver)
        {
            Days = 0.0f;
            Hours = 0.0f;
            Pay = 0.0M;
            DNS = 0.0M;
            IINEX = 0.0M;
            IIN = 0.0M;
            Cash = 0.0M;

            foreach (var v in PerMonth)
            {
                CalcAll(sr, v.Value, calcver);
                Add(v.Value);
            }

            if (vcs == null) return;


            var pfx = new PayFx();
            pfx.Pay = Pay;
            pfx.DNS = DNS;
            pfx.UsedIinEx = IINEX;
            pfx.IIN = IIN;
            pfx.Cash = Cash;

            var vcrms = new VacationCalcRow[vcs.Length];
            var pfxs = new PayFx[vcs.Length];
            for (int i = 0; i < vcs.Length; i++)
            {
                var vci = vcs[i];
                if (vci == null) continue;
                var vcri = vci.VcrCompensation;
                vcrms[i] = vcri;
                var pfx1 = new PayFx();
                pfx1.Pay = vcri.Pay;
                pfxs[i] = pfx1;
            }

            PayFx.SplitAndRound(pfx, pfxs);

            for (int i = 0; i < vcs.Length; i++)
            {
                var vci = vcs[i];
                if (vci == null) continue;
                var vcrm = vcrms[i];
                var pfx1 = pfxs[i];
                vcrm.DNS = pfx1.DNS;
                vcrm.IINEX = pfx1.UsedIinEx;
                vcrm.IIN = pfx1.IIN;
                vcrm.Cash = pfx1.Cash;
            }

        }

        public PayFx CalcAll(SalarySheetRowInfo sr, VacationCalcRow v, int calcver)
        {
            var cri = new CalcRInfo(false, calcver);
            cri.CalcR(sr, v.DateStart, v.DateEnd);
            var pfx = new PayFx(cri);
            if (cri.UseProgresiveIINRate)
            {
                pfx.IinEx = 0.0M;
            }
            else
            {
                pfx.IinEx = cri.ExMax2.SumIINExempts();
            }
            pfx.Pay = v.Pay;
            pfx.CalcAllAndRound();
            v.DNS = pfx.DNS;
            v.IINEX = pfx.UsedIinEx;
            v.IIN = pfx.IIN;
            v.Cash = pfx.Cash;
            return pfx;
        }

    }


    public class VacationCalcRow
    {
        public bool IsTotal = false;
        public string Position { get; set; } = "";
        public string Type { get; set; } = "";
        public string Caption { get; set; } = "";
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public float Days { get; set; } = 0.0f;
        public float Hours { get; set; } = 0.0f;
        public decimal AvPayRate { get; set; } = 0.0M;
        public decimal Pay { get; set; } = 0.0M;
        public decimal DNS { get; set; } = 0.0M;
        public decimal BeforeIINEX { get; set; } = 0.0M;
        public decimal IINEX { get; set; } = 0.0M;
        public decimal IIN { get; set; } = 0.0M;
        public decimal Cash { get; set; } = 0.0M;

        public VacationCalcRow(string caption = "")
        {
            Caption = caption;
        }

        public void SetFrom(VacationCalcRow vr)
        {
            IsTotal = vr.IsTotal;
            Position = vr.Position;
            this.Type = vr.Type;
            Caption = vr.Caption;
            DateStart = vr.DateStart;
            DateEnd = vr.DateEnd;
            Days = vr.Days;
            Hours = vr.Hours;
            AvPayRate = vr.AvPayRate;
            Pay = vr.Pay;
            DNS = vr.DNS;
            BeforeIINEX = vr.BeforeIINEX;
            IINEX = vr.IINEX;
            IIN = vr.IIN;
            Cash = vr.Cash;
        }

        public void Add(VacationCalcRow vr)
        {
            Days += vr.Days;
            Hours += vr.Hours;
            Pay += vr.Pay;
            DNS += vr.DNS;
            BeforeIINEX += vr.BeforeIINEX;
            IINEX += vr.IINEX;
            IIN += vr.IIN;
            Cash += vr.Cash;
        }


        public void CalcAndAdd(SalarySheetRowInfo sr, VacationCalcRow v,
            decimal AvPayRateDay, int calcver)
        {
            v.AvPayRate = AvPayRateDay;
            v.Pay = KlonsData.RoundA(AvPayRateDay * (decimal)v.Days, 2);
            var pcri = new CalcRInfo(false, calcver);
            pcri.CalcR(sr, v.DateStart, v.DateEnd);
            v.DNS = KlonsData.RoundA(pcri.RateDNSN * v.Pay / 100.0M, 2);
            v.Cash = v.Pay - v.DNS;
            Add(v);
        }

        public void CalcAndAddSplit(SalarySheetRowInfo sr, VacationCalcRow v, int calcver)
        {
            var pcri = new CalcRInfo(false, calcver);
            pcri.CalcR(sr, v.DateStart, v.DateEnd);
            v.DNS = KlonsData.RoundA(pcri.RateDNSN * v.Pay / 100.0M, 2);
            v.Cash = v.Pay - v.DNS;
            Add(v);
        }

    }

}
