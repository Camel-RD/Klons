using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsP.DataSets;
using KlonsLIB.Misc;

namespace KlonsP.Classes
{
    public class ItemInfo : EventInfo0
    {
        protected KlonsPDataSet.ITEMSRow DR = null;

        public List<EventInfo> Events = null;
        public List<EventInfo> Events2 = null;

        public string ItemRegNr { get; set; } = null;
        public string ItemName { get; set; } = null;

        public DateTime DateStart = DateTime.MinValue;
        public DateTime DateEnd = DateTime.MaxValue;

        public DateTime DateReg { get; set; } = DateTime.MinValue;
        public DateTime DateLiq { get; set; } = DateTime.MaxValue;

        public decimal StartingValue { get; set; } = 0.0M;
        public decimal EndingValue { get; set; } = 0.0M;


        public bool InUse = false;

        public int FirstYear = 0;
        public int FirstMonth = 0;

        public string ErrorMsg = null;

        public void SetFromRow(KlonsPDataSet.ITEMSRow dr, bool forrep = false)
        {
            DR = dr;

            Events = new List<EventInfo>();
            var drs_ev = dr.GetITEMS_EVENTSRows()
                .OrderBy(d => d.DT)
                .ThenBy(d => d.EVENTSRow.ID < 0 ? int.MaxValue / 2 - d.EVENTSRow.ID : d.EVENTSRow.ID);

            IdIt = dr.ID;
            Id = IdIt;
            ItemRegNr = dr.REG_NR;
            ItemName = dr.NAME;

            int i = 1;
            foreach (var dr_ev in drs_ev)
            {
                EventInfo ev = null;
                if (forrep)
                    ev = new EventInfo();
                else
                    ev = new EventRepInfo();
                ev.SetFromRow(dr_ev);
                ev.SNR = i;
                Events.Add(ev);
                i++;
            }
        }

        public override void Reset()
        {
            base.Reset();
            ItemRegNr = null;
            ItemName = null;
            DateStart = DateTime.MinValue;
            DateEnd = DateTime.MinValue;
            DateReg = DateTime.MinValue;
            DateLiq = DateTime.MinValue;
            ErrorMsg = null;
        }

        public void ResetT()
        {
            DateStart = DateTime.MinValue;
            DateEnd = DateTime.MinValue;
            DateReg = DateTime.MinValue;
            DateLiq = DateTime.MinValue;
            Value0 = 0.0M;
            Deprec0 = 0.0M;
            Value1 = 0.0M;
            Deprec1 = 0.0M;
            ValueLeft0 = 0.0M;
            ValueLeft1 = 0.0M;
            Cat1 = 0;
            CatD = 0;
            CatT = 0;
            Department = 0;
            Place = 0;
        }

        public void UpdateRowEvents()
        {
            foreach (var ev in Events)
            {
                ev.UpdateRow();
            }
        }

        public void UpdateRowEventsA()
        {
            foreach (var ev in Events)
            {
                ev.UpdateRowFull();
            }
        }

        public void UpdateRow0()
        {
            if (DR == null)
                throw new Exception("DR is null.");
            DR.BeginEdit();
            //DR.TVALUE0 = Value0;
            //DR.TDEPREC0 = Deprec0;
            DR.CAT1 = Cat1;
            DR.CATD = CatD;
            DR.CATT = CatT;
            DR.DEPARTMENT = Department;
            DR.PLACE = Place;

            if (DateReg == DateTime.MinValue)
                DR.SetDATE1Null();
            else
                DR.DATE1 = DateReg;

            if (DateLiq == DateTime.MaxValue)
                DR.SetDATE2Null();
            else
                DR.DATE2 = DateLiq;

            DR.XState = State;
            DR.EndEditX();
        }

        public void UpdateRowT(EventInfo ev)
        {
            if (DR == null)
                throw new Exception("DR is null.");
            DR.BeginEdit();
            DR.TVALUE0 = ev.Value0;
            DR.TDEPREC0 = ev.Deprec0;
            DR.TVALUE_LEFT = ev.ValueLeft0;
            DR.TCAT1 = ev.Cat1;
            DR.TCATD = ev.CatD;
            DR.TCATT = ev.CatT;
            DR.TDEPARTMENT = ev.Department;
            DR.TPLACE = ev.Place;

            if (DateReg == DateTime.MinValue || DateReg == DateTime.MaxValue)
                DR.SetTDATE1Null();
            else
                DR.TDATE1 = DateReg;

            if (DateLiq == DateTime.MaxValue || DateLiq == DateTime.MinValue)
                DR.SetTDATE2Null();
            else
                DR.TDATE2 = DateLiq;

            DR.XTState = ev.State;
            DR.TERROR = ErrorMsg;
            //DR.EndEditX(MyData.KlonsTableAdapterManager.ITEMSTableAdapter.Adapter);
            DR.EndEditX();
        }

        public bool IsGoodEventDate(DateTime dt)
        {
            if (Events.Count == 0) return true;
            var dateStart = Events[0].Dt;
            var dateEnd = DateTime.MaxValue;
            if (Events.Count > 1 && Events[Events.Count - 1].XEvent == EEvent.likvid)
                dateEnd = Events[Events.Count - 1].Dt;
            return dt >= dateStart && dt <= dateEnd;
        }

        public string UpdateItemToDate(DateTime dt)
        {
            Events2 = new List<EventInfo>();
            var ev = new EventInfo();
            Events2.Add(ev);
            ev.Dt = dt;
            ev.XEvent = EEvent.apr;
            ev.LastInDay = true;
            ErrorMsg = null;

            var rt = CheckItem();
            if (rt != "OK")
            {
                ResetT();
                State = EState.Error;
                ErrorMsg = rt;
                ev.State = EState.Error;
                UpdateRowT(ev);
                return rt;
            }

            rt = FullCalc();

            if (rt != "OK")
            {
                ResetT();
                State = EState.Error;
                ErrorMsg = rt;
                ev.State = EState.Error;
                UpdateRowT(ev);
                return rt;
            }

            UpdateRowEventsA();
            UpdateRowT(ev);

            return rt;
        }

        public string MakeReport_MT(DateTime dt1, DateTime dt2)
        {
            if (dt1 > dt2)
                throw new ArgumentException();

            Events2 = new List<EventInfo>();

            ErrorMsg = null;
            var rt = CheckItem();
            if (rt != "OK")
            {
                ResetT();
                State = EState.Error;
                ErrorMsg = rt;
                return rt;
            }

            var dateStart = Events[0].Dt.LastDayOfMonth();
            var dateEnd = DateTime.MaxValue;
            if (Events.Count > 1 && Events[Events.Count - 1].XEvent == EEvent.likvid)
                dateEnd = Events[Events.Count - 1].Dt.LastDayOfMonth();

            if (dt1 < dateStart) dt1 = dateStart;
            if (dt2 > dateEnd) dt2 = dateEnd;

            dt2 = dt2.AddMonths(1).FirstDayOfMonth();

            var dtx = dt1.FirstDayOfMonth();
            while (dtx <= dt2)
            {
                var ev = new EventInfo();
                Events2.Add(ev);
                ev.Dt = dtx.LastDayOfMonth();
                ev.XEvent = EEvent.apr;
                ev.LastInDay = true;
                dtx = dtx.AddMonths(1);
            }

            rt = FullCalc();
            if (rt != "OK")
            {
                ResetT();
                State = EState.Error;
                ErrorMsg = rt;
                return rt;
            }

            MakeDataRelative();
            return rt;
        }

        public List<EventRepInfo> GetEventRepList()
        {
            var list = new List<EventRepInfo>();
            foreach (var ev in Events2)
                list.Add(ev as EventRepInfo);
            return list;
        }

        public string MakeReport_YR(DateTime dt1, DateTime dt2)
        {
            if (dt1 > dt2)
                throw new ArgumentException();

            Events2 = new List<EventInfo>();

            ErrorMsg = null;
            var rt = CheckItem();
            if (rt != "OK")
            {
                ResetT();
                State = EState.Error;
                ErrorMsg = rt;
                return rt;
            }

            var dateStart = new DateTime(Events[0].Dt.Year, 12, 31);
            var dateEnd = DateTime.MaxValue;
            if (Events.Count > 1 && Events[Events.Count - 1].XEvent == EEvent.likvid)
                dateEnd = new DateTime(Events[Events.Count - 1].Dt.Year, 12, 31);

            if (dt1 < dateStart) dt1 = dateStart;
            if (dt2 > dateEnd) dt2 = dateEnd;

            dt2 = dt2.AddMonths(1).FirstDayOfMonth();

            var dtx = dt1; 
            while (dtx <= dt2)
            {
                var ev = new EventRepInfo();
                Events2.Add(ev);
                ev.Dt = dtx;
                ev.XEvent = EEvent.apr;
                ev.LastInDay = true;
                dtx = dtx.AddYears(1);
            }

            rt = FullCalc();
            if (rt != "OK")
            {
                ResetT();
                State = EState.Error;
                ErrorMsg = rt;
                return rt;
            }

            MakeDataRelative();
            return rt;
        }

        public string MakeReport_YR2(DateTime dt1, DateTime dt2)
        {
            if (dt1 > dt2)
                throw new ArgumentException();

            Events2 = new List<EventInfo>();

            ErrorMsg = null;
            var rt = CheckItem();
            if (rt != "OK")
            {
                ResetT();
                State = EState.Error;
                ErrorMsg = rt;
                return rt;
            }

            var dateStart = new DateTime(Events[0].Dt.Year, 12, 31);
            var dateEnd = DateTime.MaxValue;
            if (Events.Count > 1 && Events[Events.Count - 1].XEvent == EEvent.likvid)
                dateEnd = new DateTime(Events[Events.Count - 1].Dt.Year, 12, 31);

            if (dt1 < dateStart) dt1 = dateStart;
            if (dt2 > dateEnd) dt2 = dateEnd;

            dt2 = dt2.AddMonths(1).FirstDayOfMonth();

            int idx = Events.Max(d => d.Id) + 1;

            var dtx = dt1;
            while (dtx <= dt2)
            {
                var ev = new EventRepInfo();
                ev.Dt = dtx;
                ev.Descr = "nolietojums";
                ev.XEvent = EEvent.noliet;
                ev.LastInDay = true;
                Events2.Add(ev);

                ev = new EventRepInfo();
                ev.Dt = dtx;
                ev.Descr = $"kopā par {ev.Dt.Year}. gadu";
                ev.XEvent = EEvent.apr;
                ev.LastInDay = true;
                Events2.Add(ev);
                dtx = dtx.AddYears(1);
            }

            rt = FullCalc();
            if (rt != "OK")
            {
                ResetT();
                State = EState.Error;
                ErrorMsg = rt;
                return rt;
            }

            MakeDataRelative2();

            var new_list = new List<EventInfo>();

            for (int i = 0; i < Events2.Count; i += 2)
            {
                var ev_nol = Events2[i];
                var ev_apr = Events2[i + 1];
                ev_apr.DeprecCalcThisMt = ev_apr.DeprecCalc;
                if (ev_nol.DeprecCalcThisMt != ev_apr.DeprecCalc)
                    new_list.Add(ev_nol);
                new_list.Add(ev_apr);
            }

            Events2 = new_list;
            return rt;
        }

        public string MakeReportYrMerged(DateTime dt1, DateTime dt2)
        {
            var er = MakeReport_YR2(dt1, dt2);
            if (er != "OK") return er;
            Events2.AddRange(Events);
            var ord = Events2.OrderBy(d => d.Dt)
                .ThenBy(d =>
                    d.XEvent == EEvent.noliet ? 1001 :
                    d.XEvent == EEvent.apr ? 1002 : d.SNR)
                .ThenBy(d =>
                    (d.XEvent == EEvent.apr || 
                    d.XEvent == EEvent.noliet) ? int.MaxValue : d.Id);
            Events2 = new List<EventInfo>(ord);
            int snr = 1;
            foreach (var ev in Events2)
            {
                var evr = ev as EventRepInfo;
                evr.SetSFields();
                evr.SNR = snr++;
                if (string.IsNullOrEmpty(evr.Descr))
                {
                    evr.Descr = evr.XEvent.ToMyStringFull();
                }
            }
            return "OK";
        }

        public void MakeDataRelative()
        {
            if (Events2 == null || Events2.Count == 0) return;
            for (int i = Events2.Count - 1; i > 0; i--)
            {
                var ev1 = Events2[i - 1];
                var ev2 = Events2[i];
                MakeDataRelative(ev1, ev2);
            }
            var ev0 = Events2[0];
            MakeDataRelative(EventInfo.Zero, ev0);
        }

        public void MakeDataRelative2()
        {
            if (Events2 == null || Events2.Count == 0) return;
            for (int i = Events2.Count - 1; i > 1; i -= 2)
            {
                var ev1 = Events2[i - 2];
                var ev2 = Events2[i];
                MakeDataRelative(ev1, ev2);
            }
            var ev0 = Events2[1];
            MakeDataRelative(EventInfo.Zero, ev0);
        }

        public void MakeDataRelative(EventInfo ev1, EventInfo ev2)
        {
            //ev2.ValueC = ev2.Value1 - ev1.Value0;
            //ev2.DeprecC = ev2.Deprec1 - ev1.Deprec0 - ev2.DeprecCalc;
            ev2.ValueC = ev2.ValueNew + ev2.ValueAdd + ev2.ValueRevalue + ev2.ValueExclude;
            ev2.DeprecC = ev2.DeprecNew + ev2.DeprecAdd + ev2.DeprecRevalue + ev2.DeprecExclude;
            ev2.Value0 = ev2.Value1 - ev2.ValueC;
            ev2.Deprec0 = ev2.Deprec1 - ev2.DeprecC - ev2.DeprecCalc;
            ev2.ValueLeft0 = ev2.Value0 - ev2.Deprec0;

            ev2.TaxValC = ev2.TaxVal - ev1.TaxVal;
            ev2.TaxValLeft0 = ev2.TaxValLeft0 - ev2.TaxValC + ev2.TaxDeprecCalc;
        }


        public void SetEventToInit(KlonsPDataSet.ITEMS_EVENTSRow drtoinit)
        {
            if (drtoinit == null) return;
            var ev = Events.Where(d => d.DR == drtoinit);
            ev.ForEach(d => d.InitFields = true);
        }

        public string CheckItem()
        {
            if (Events.Count == 0) return "OK";

            decimal value = 0.0M;
            decimal deprec = 0.0M;
            decimal TaxVal = 0.0M;

            DateTime dateStart = Events[0].Dt.FirstDayOfMonth();
            DateTime dateEnd = Events[Events.Count - 1].Dt.LastDayOfMonth();

            EEvent curState = EEvent.nenoteikts;
            EEvent nextState = EEvent.nenoteikts;
            EEvent curEvent = EEvent.nenoteikts;

            for(int i = 0; i < Events.Count; i++)
            {
                var curEventInfo = Events[i];
                curEvent = curEventInfo.XEvent;
                nextState = curEvent;

                value += curEventInfo.ValueC;
                deprec += curEventInfo.DeprecC;
                TaxVal += curEventInfo.TaxVal;

                var evstr = curState.ToMyString();
                var badeverrstr = "Nekorekts notikums [" + evstr + "]";

                if (curEvent == EEvent.noliet || curEvent == EEvent.apr)
                {
                    if(curState == EEvent.nenoteikts)
                        return badeverrstr;
                    continue;
                }

                switch (curState)
                {
                    case EEvent.nenoteikts:
                        if (curEvent.IsIn(EEvent.iegeks, EEvent.pienuzsk))
                            nextState = EEvent.eks;
                        else if (!curEvent.IsIn(EEvent.ieg, EEvent.izv))
                            return badeverrstr;
                        break;

                    case EEvent.ieg:
                        if (!curEvent.IsIn(EEvent.eks, EEvent.izv))
                            return badeverrstr;
                        break;

                    case EEvent.izv:
                        if (!curEvent.IsIn(EEvent.eks, EEvent.izv))
                            return badeverrstr;
                        break;

                    case EEvent.eks:
                        if (curEvent.IsIn(EEvent.kapit, EEvent.rekat, EEvent.parvert, EEvent.vieta))
                            nextState = EEvent.eks;
                        else if (!curEvent.IsIn(EEvent.nelieto, EEvent.likvid))
                            return badeverrstr;
                        break;

                    case EEvent.nelieto:
                        if (curEvent == EEvent.lieto)
                            nextState = EEvent.eks; 
                        else if (curEvent.IsIn(EEvent.kapit, EEvent.rekat, EEvent.parvert, EEvent.vieta))
                            nextState = EEvent.nelieto;
                        else if (!curEvent.IsIn(EEvent.likvid))
                            return badeverrstr;
                        break;

                    case EEvent.likvid:
                        return "Nekorekts notikums pēc pamatlīdzekļa likvidācijas.";

                }

                curState = nextState;

                switch (curState)
                {
                    case EEvent.pienuzsk:
                    case EEvent.ieg:
                    case EEvent.izv:
                    case EEvent.nelieto:
                    case EEvent.eks:
                        if (value < 0.0M)
                            return "Pamatlīdzeklim ir negatīva vērtība.";
                        if (deprec < 0.0M)
                            return "Pamatlīdzekļa uzkrātais nolietojums ir negatīvs.";
                        if (value < deprec)
                            return "Pamatlīdzekļa nolietojums ir lielāks par vērtību.";
                        break;
                }


            }

            return "OK";
        }

        public int DateDiffInMonths(DateTime smaller, DateTime bigger)
        {
            int yrs = smaller.Year;
            int yrb = bigger.Year;
            int mts = smaller.Month;
            int mtb = bigger.Month;
            return yrb * 12 + mtb - 1 - (yrs * 12 + mts - 1);
        }

        public EventInfo GetPrevEvent(EventInfo ev)
        {
            if (ev.SNR < 1) return null;
            return Events[ev.SNR - 1];
        }
            
        // nolietojums konkrētam mēnesiem tiek rēķināts pirmajam mēneša notikumam
        // -- pirms šajā mēnesī tiek mainīta PL vērtība
        // => nolietojumu rēķina sākot ar nākamā mēneša pirmo datumu
        public string FullCalc()
        {
            if (Events.Count == 0) return "OK";

            int lastMt = 0, curMt = 0;
            int lastTaxDeprecYr = 0, curTaxDeprecYr = 0;
            decimal deprecMt, deprecPeriod;

            EEvent curState = EEvent.nenoteikts;
            EEvent nextState = EEvent.nenoteikts;
            EEvent curEvent = EEvent.nenoteikts;

            EventInfo curEventInfo = Events[0];
            EventInfo curEventInfo2 = null;
            DateReg = curEventInfo.Dt;
            DateStart = curEventInfo.Dt.FirstDayOfMonth();
            DateEnd = DateTime.MaxValue;

            if (Events.Count > 1 && Events[Events.Count - 1].XEvent == EEvent.likvid)
            {
                DateLiq = Events[Events.Count - 1].Dt;
                DateEnd = DateLiq.LastDayOfMonth();
            }

            FirstYear = DateStart.Year;
            FirstMonth = DateStart.Month;

            int i1 = 0, i2 = 0, k;

            for(i2 = 0; i2 < Events2.Count; i2++)
            {
                k = DateDiffInMonths(curEventInfo.Dt, Events2[i2].Dt);
                if (k >= 0) break;
                Events2[i2].State = EState.OldDate;
            }

            InUse = false;
            State = EState.OK;

            while (i1 < Events.Count || i2 < Events2.Count)
            {
                if (i1 < Events.Count)
                {
                    if (i2 >= Events2.Count)
                    {
                        curEventInfo = Events[i1];
                        i1++;
                    }
                    else
                    {
                        curEventInfo = Events[i1];
                        curEventInfo2 = Events2[i2];
                        if (curEventInfo2.LastInDay)
                        {
                            if (curEventInfo2.Dt < curEventInfo.Dt)
                            {
                                curEventInfo = curEventInfo2;
                                i2++;
                            }
                            else
                            {
                                i1++;
                            }
                        }
                        else
                        {
                            if (curEventInfo2.Dt <= curEventInfo.Dt)
                            {
                                curEventInfo = curEventInfo2;
                                i2++;
                            }
                            else
                            {
                                i1++;
                            }
                        }
                    }

                }
                else
                {
                    curEventInfo = Events2[i2];
                    i2++;
                }



                curEvent = curEventInfo.XEvent;
                nextState = curEvent;
                curMt = DateDiffInMonths(DateStart, curEventInfo.Dt);
                curTaxDeprecYr = curEventInfo.Dt.Year;

                if (lastTaxDeprecYr == 0)
                {
                    lastTaxDeprecYr = curTaxDeprecYr;
                    if (curEventInfo.XEvent == EEvent.pienuzsk && curEventInfo.Dt.IsLastOfYear())
                        lastTaxDeprecYr++;
                }

                if ((curEventInfo.XEvent == EEvent.apr || curEventInfo.XEvent == EEvent.noliet) &&
                    curEventInfo.LastInDay && 
                    curEventInfo.Dt.IsLastOfYear())
                {
                    curTaxDeprecYr++;
                }

                Value0 = Value1;
                Deprec0 = Deprec1;
                ValueLeft0 = ValueLeft1;
                TaxValLeft0 = TaxValLeft1;

                // finanšu nolietojums
                if (curMt > lastMt)
                {
                    if (InUse)
                        deprecMt = RateDMt;
                    else
                        deprecMt = 0.0M;

                    if (deprecMt > 0.0M)
                        MtUsed += curMt - lastMt;

                    deprecPeriod = (curMt - lastMt) * deprecMt;
                    if (deprecPeriod > (Value0 - Deprec0))
                        deprecPeriod = Value0 - Deprec0;

                    DeprecCalcThisMt = deprecPeriod;

                    Deprec1 += deprecPeriod;
                    ValueLeft1 -= deprecPeriod;
                    DeprecCalc += deprecPeriod;

                    Deprec0 = Deprec1;
                    ValueLeft0 = ValueLeft1;

                    lastMt = curMt;
                }
                else
                {
                    DeprecCalcThisMt = 0;
                }


                // nolietojums nodokļiem
                if (curTaxDeprecYr > lastTaxDeprecYr && TaxRate != 0.0f)
                {
                    var r = (decimal)Math.Pow((1.0f - TaxRate), curTaxDeprecYr - lastTaxDeprecYr);
                    var taxDeprec = TaxValLeft1 * (1.0M - r);
                    taxDeprec = Math.Round(taxDeprec, 2);
                    TaxDeprecCalc += taxDeprec;
                    TaxDeprec += taxDeprec;
                    TaxValLeft1 -= taxDeprec;
                    lastTaxDeprecYr = curTaxDeprecYr;

                    if (TaxEach == 1 && TaxValLeft1 <= 71.14M)
                    {
                        TaxDeprecCalc += TaxValLeft1;
                        TaxDeprec += TaxValLeft1;
                        TaxValLeft1 = 0.0M;
                    }
                }


                if (curEventInfo.XEvent == EEvent.noliet || 
                    curEventInfo.XEvent == EEvent.apr)
                {
                    curEventInfo.State = State;
                    curEventInfo.Cat1 = Cat1;
                    curEventInfo.CatD = CatD;
                    curEventInfo.CatT = CatT;
                    curEventInfo.Place = Place;
                    curEventInfo.Department = Department;

                    curEventInfo.Value0 = Value0;
                    curEventInfo.Value1 = Value1;
                    curEventInfo.Deprec0 = Deprec0;
                    curEventInfo.Deprec1 = Deprec1;
                    curEventInfo.ValueLeft0 = Value0 - Deprec0;
                    curEventInfo.ValueLeft1 = Value1 - Deprec1;
                    curEventInfo.SellValue = SellValue;
                    curEventInfo.RateD = RateD;
                    curEventInfo.RateDMt = RateDMt;
                    curEventInfo.DeprecCalc = DeprecCalc;
                    curEventInfo.ValueLeft0 = Value0 - Deprec0;
                    curEventInfo.DeprecCalcThisMt = DeprecCalcThisMt;
                    curEventInfo.MtTotal = MtTotal;
                    curEventInfo.MtUsed = MtUsed;

                    curEventInfo.TaxVal = TaxVal;
                    curEventInfo.TaxValLeft0 = TaxValLeft0;
                    curEventInfo.TaxValLeft1 = TaxValLeft1;
                    curEventInfo.TaxDeprec = TaxDeprec;
                    curEventInfo.TaxDeprecCalc = TaxDeprecCalc;
                    curEventInfo.TaxRate = TaxRate;
                    curEventInfo.TaxEach = TaxEach;
                    curEventInfo.TaxValLeftAtEnd = TaxValLeftAtEnd;

                    if (curEventInfo.XEvent == EEvent.apr)
                    {
                        curEventInfo.ValueNew = ValueNew;
                        curEventInfo.DeprecNew = DeprecNew;
                        curEventInfo.ValueAdd = ValueAdd;
                        curEventInfo.DeprecAdd = DeprecAdd;
                        curEventInfo.ValueRevalue = ValueRevalue;
                        curEventInfo.DeprecRevalue = DeprecRevalue;
                        curEventInfo.ValueRecat = ValueRecat;
                        curEventInfo.DeprecRecat = DeprecRecat;
                        curEventInfo.ValueExclude = ValueExclude;
                        curEventInfo.DeprecExclude = DeprecExclude;
                        curEventInfo.TaxValNewCalc = TaxValNewCalc;
                        curEventInfo.TaxValAddCalc = TaxValAddCalc;
                        curEventInfo.TaxValRecatCalc = TaxValRecatCalc;
                        curEventInfo.TaxValExcludeCalc = TaxValExcludeCalc;
                        curEventInfo.TaxValLeftAtEndCalc = TaxValLeftAtEndCalc;

                        ValueNew = 0.0M;
                        ValueAdd = 0.0M;
                        ValueRevalue = 0.0M;
                        ValueRecat = 0.0M;
                        ValueExclude = 0.0M;

                        DeprecNew = 0.0M;
                        DeprecAdd = 0.0M;
                        DeprecRevalue = 0.0M;
                        DeprecRecat = 0.0M;
                        DeprecExclude = 0.0M;

                        DeprecCalc = 0.0M;
                        TaxValNewCalc = 0.0M;
                        TaxValAddCalc = 0.0M;
                        TaxValRecatCalc = 0.0M;
                        TaxValExcludeCalc = 0.0M;
                        TaxDeprecCalc = 0.0M;
                        TaxValLeftAtEndCalc = 0.0M;
                    }

                }
                else
                {
                    // izmētājam ValueC, DeprecC
                    if (curEventInfo.XEvent.IsIn(EEvent.ieg, EEvent.eks, EEvent.izv, EEvent.iegeks,
                        EEvent.kapit))
                    {
                        curEventInfo.TaxValC = curEventInfo.ValueC - curEventInfo.DeprecC;
                    }
                    else if (curEventInfo.XEvent == EEvent.likvid)
                    {
                        curEventInfo.TaxValC = curEventInfo.ValueC - curEventInfo.DeprecC;
                    }
                    else if (curEventInfo.XEvent != EEvent.pienuzsk)
                    {
                        curEventInfo.TaxValC = 0.0M;
                    }

                    if (curEventInfo.XEvent.IsIn(EEvent.ieg, EEvent.eks, EEvent.izv, EEvent.iegeks))
                    {
                        curEventInfo.ValueNew = curEventInfo.ValueC;
                        curEventInfo.DeprecNew = curEventInfo.DeprecC;
                        ValueNew += curEventInfo.ValueC;
                        DeprecNew += curEventInfo.DeprecC;
                        StartingValue += curEventInfo.ValueC - curEventInfo.DeprecC;
                        curEventInfo.TaxValNewCalc = curEventInfo.TaxValC;
                        TaxValNewCalc += curEventInfo.TaxValC;
                    }
                    else if (curEventInfo.XEvent == EEvent.kapit)
                    {
                        curEventInfo.ValueAdd = curEventInfo.ValueC;
                        curEventInfo.DeprecAdd = curEventInfo.DeprecC;
                        ValueAdd += curEventInfo.ValueC;
                        DeprecAdd += curEventInfo.DeprecC;
                        curEventInfo.TaxValAddCalc = curEventInfo.TaxValC;
                        TaxValAddCalc += curEventInfo.TaxValC;
                    }
                    else if (curEventInfo.XEvent == EEvent.parvert)
                    {
                        curEventInfo.ValueRevalue = curEventInfo.ValueC;
                        curEventInfo.DeprecRevalue = curEventInfo.DeprecC;
                        ValueRevalue += curEventInfo.ValueC;
                        DeprecRevalue += curEventInfo.DeprecC;
                    }
                    else if (curEventInfo.XEvent == EEvent.likvid)
                    {
                        curEventInfo.ValueExclude = curEventInfo.ValueC;
                        curEventInfo.DeprecExclude = curEventInfo.DeprecC;
                        ValueExclude += curEventInfo.ValueC;
                        DeprecExclude += curEventInfo.DeprecC;
                        curEventInfo.TaxValExcludeCalc = -curEventInfo.TaxValC;
                        TaxValExcludeCalc -= curEventInfo.TaxValC;
                    }

                    Value1 += curEventInfo.ValueC;
                    Deprec1 += curEventInfo.DeprecC;
                    TaxVal += curEventInfo.TaxValC;
                    TaxValLeft1 += curEventInfo.TaxValC;

                    // nolietojums nodokļiem
                    if (curEventInfo.XEvent == EEvent.likvid)
                    {
                        //TaxValLeft1 ir jau koriģēts ar TaxValC
                        TaxValLeftAtEnd = TaxValLeft1;
                        TaxValLeftAtEndCalc = TaxValLeft1;
                        if (TaxEach == 1)
                        {
                            TaxDeprecCalc += TaxValLeft1;
                            TaxDeprec += TaxValLeft1;
                            TaxValLeft1 = 0.0M;
                            lastTaxDeprecYr = curTaxDeprecYr + 1;
                        }

                    }

                    // ItemInfo => EventInfo
                    if (curEventInfo.XEvent != EEvent.pienuzsk || curEventInfo.InitFields)
                    {
                        curEventInfo.Value0 = Value0;
                        curEventInfo.Deprec0 = Deprec0;
                        curEventInfo.Value1 = Value1;
                        curEventInfo.Deprec1 = Deprec1;
                        curEventInfo.TaxVal = TaxVal;
                        curEventInfo.TaxValLeft0 = TaxValLeft0;
                        curEventInfo.TaxValLeft1 = TaxValLeft1;
                    }

                    curEventInfo.DeprecCalc = DeprecCalc;
                    curEventInfo.ValueLeft0 = Value0 - Deprec0;
                    curEventInfo.ValueLeft1 = Value1 - Deprec1;
                    curEventInfo.DeprecCalcThisMt = DeprecCalcThisMt;
                    curEventInfo.MtUsed = MtUsed;
                    curEventInfo.TaxDeprec = TaxVal - TaxValLeft1;
                    curEventInfo.TaxDeprecCalc = TaxDeprecCalc;

                    if (Events.Count > 0 && Events[0] != curEventInfo)
                    {
                        curEventInfo.State = State;

                        if (curEventInfo.InitFields)
                        {
                            curEventInfo.Cat1 = Cat1;
                            curEventInfo.CatD = CatD;
                            curEventInfo.CatT = CatT;
                            curEventInfo.Place = Place;
                            curEventInfo.Department = Department;
                            curEventInfo.SellValue = SellValue;
                            curEventInfo.MtTotal = MtTotal;
                        }
                        else
                        {
                            var editablefields = SomeDataDefs.GetEditableFields(curEventInfo.XEvent);
                            if (!editablefields.HasFlag(EChColInd.cat1)) curEventInfo.Cat1 = Cat1;
                            if (!editablefields.HasFlag(EChColInd.cat1)) curEventInfo.Cat1 = Cat1;
                            if (!editablefields.HasFlag(EChColInd.catd)) curEventInfo.CatD = CatD;
                            if (!editablefields.HasFlag(EChColInd.catt)) curEventInfo.CatT = CatT;
                            if (!editablefields.HasFlag(EChColInd.place)) curEventInfo.Place = Place;
                            if (!editablefields.HasFlag(EChColInd.department)) curEventInfo.Department = Department;
                            if (!editablefields.HasFlag(EChColInd.sellvalue)) curEventInfo.SellValue = SellValue;
                            if (!editablefields.HasFlag(EChColInd.mttotal)) curEventInfo.MtTotal = MtTotal;
                        }
                    }

                    curEventInfo.RecalcA();

                    // EventInfo => ItemInfo
                    Cat1 = curEventInfo.Cat1;
                    CatD = curEventInfo.CatD;
                    CatT = curEventInfo.CatT;
                    Place = curEventInfo.Place;

                    ValueLeft0 = Value0 - Deprec0;
                    ValueLeft1 = Value1 - Deprec1;
                    SellValue = curEventInfo.SellValue;

                    MtTotal = curEventInfo.MtTotal;

                    RateD = curEventInfo.RateD;
                    TaxRate = curEventInfo.TaxRate;
                    RateDMt = curEventInfo.RateDMt;

                    TaxEach = curEventInfo.TaxEach;

                    curState = curEventInfo.XEvent;



                    if (curState.IsIn(EEvent.ieg, EEvent.izv))
                    {
                        InUse = false;
                        State = EState.NotUsed;
                    }
                    else if (curState.IsIn(EEvent.eks, EEvent.iegeks))
                    {
                        InUse = true;
                        State = EState.OK;
                    }
                    else if (curState == EEvent.rekat)
                    {

                    }
                    else if (curState == EEvent.kapit)
                    {

                    }
                    else if (curState == EEvent.parvert)
                    {

                    }
                    else if (curState == EEvent.nelieto)
                    {
                        InUse = false;
                        State = EState.NotUsed;
                    }
                    else if (curState == EEvent.lieto)
                    {
                        InUse = true;
                        State = EState.OK;
                    }
                    else if (curState == EEvent.likvid)
                    {
                        InUse = false;
                        DateLiq = curEventInfo.Dt;
                        State = EState.Liquidated;
                        EndingValue = Value0 - Deprec0;
                    }

                }

            }
            return "OK";
        }

    }
}
