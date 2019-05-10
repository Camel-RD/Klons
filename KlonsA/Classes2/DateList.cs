using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlonsA.Classes
{
    public class DateList
    {
        public List<DatesFromTo> List = new List<DatesFromTo>();

        public DateList() { }

        public DateList(IEnumerable<PeriodInfo> ie)
        {
            List.Clear();
            foreach (var pi in ie)
                List.Add(new DatesFromTo(pi));
        }

        public DateList(DateList dl)
        {
            List.Clear();
            foreach (var d in dl.List)
                List.Add(new DatesFromTo(d));
        }

        public void Add(DateTime dt1, DateTime dt2)
        {
            List.Add(new DatesFromTo(dt1, dt2));
        }

        public bool IsEmpty { get { return List.Count == 0; } }

        public bool HasDate(DateTime dt)
        {
            foreach (var d in List)
            {
                if (dt >= d.DateFrom && dt <= d.DateTo) return true;
            }
            return false;
        }

        public DateList FilterWithDates(DateTime dt1, DateTime dt2)
        {
            var ret = new DateList();
            foreach (var d in List)
            {
                if (d.DateFrom > dt2 || d.DateTo < dt1) continue;
                var nd = new DatesFromTo(d);
                if (nd.DateFrom < dt1) nd.DateFrom = dt1;
                if (nd.DateTo > dt2) nd.DateTo = dt2;
                ret.List.Add(nd);
            }
            return ret;
        }

        public DateList FilterWithList(DateList dl)
        {
            var ret = new DateList();
            foreach (var d in List)
            {
                foreach (var df in dl.List)
                {
                    if (d.DateFrom > df.DateTo || d.DateTo < df.DateFrom) continue;
                    var nd = new DatesFromTo(d);
                    if (nd.DateFrom < df.DateFrom) nd.DateFrom = df.DateFrom;
                    if (nd.DateTo > df.DateTo) nd.DateTo = df.DateTo;
                    ret.List.Add(nd);
                }
            }
            return ret;
        }

        public DateList SubtractDates(DateTime dt1, DateTime dt2)
        {
            var ret = new DateList();

            foreach (var d in List)
            {
                if (d.DateFrom > dt2 || d.DateTo < dt1) continue;
                var nd = new DatesFromTo(d);
                ret.List.Add(nd);
                if (d.DateFrom >= dt1 && d.DateTo <= dt2) continue;
                if (d.DateFrom < dt1 && d.DateTo > dt2)
                {
                    nd.DateTo = dt1.AddDays(-1);
                    nd = new DatesFromTo(d);
                    nd.DateFrom = dt2.AddDays(1);
                    ret.List.Add(nd);
                    continue;
                }
                if (d.DateFrom >= dt1)
                {
                    nd.DateFrom = dt2.AddDays(1);
                    continue;
                }
                if (d.DateTo <= dt2)
                {
                    nd.DateTo = dt1.AddDays(-1);
                    continue;
                }
            }
            return ret;
        }

        public bool IsGoodList()
        {
            if (List.Count < 2) return true;
            var d1 = List[0];
            var d2 = d1;
            for(int i = 1; i < List.Count; i++)
            {
                d2 = List[i];
                if (d2.DateFrom <= d1.DateTo) return false;
                d1 = d2;
            }
            return true;
        }

        public DateList InvertList()
        {
            return SubtractFromDates(DateTime.MinValue, DateTime.MaxValue);
        }

        public DateList InvertGoodList()
        {
            return SubtractFromDatesGoodList(DateTime.MinValue, DateTime.MaxValue);
        }

        public DateList SubtractFromDates(DateTime dt1, DateTime dt2)
        {
            if (IsGoodList()) return SubtractFromDatesGoodList(dt1, dt2);
            return SubtractFromDatesSimple(dt1, dt2);
        }

        public DateList SubtractFromDatesSimple(DateTime dt1, DateTime dt2)
        {
            var ret = new DateList();
            ret.List.Add(new DatesFromTo(dt1, dt2));
            var f = FilterWithDates(dt1, dt2);

            foreach (var d in f.List)
                ret = ret.SubtractDates(d.DateFrom, d.DateTo);

            return ret;
        }

        public DateList SubtractFromDatesGoodList(DateTime dt1, DateTime dt2)
        {
            var ret = new DateList();
            ret.List.Add(new DatesFromTo(dt1, dt2));

            foreach (var d in List)
            {
                if (d.DateFrom > dt2 || d.DateTo < dt1) continue;
                if (ret.List.Count == 0) break;
                var cd = ret.List[ret.List.Count - 1];
                if (cd.DateFrom >= d.DateFrom && cd.DateTo <= d.DateTo)
                {
                    ret.List.RemoveAt(ret.List.Count - 1);
                    break;
                }
                if (cd.DateFrom < d.DateFrom && cd.DateTo > d.DateTo)
                {
                    var nd = new DatesFromTo(cd);
                    ret.List.Add(nd);
                    cd.DateTo = d.DateFrom.AddDays(-1);
                    nd.DateFrom = d.DateTo.AddDays(1);
                    break;
                }
                if (cd.DateFrom < d.DateFrom)
                {
                    cd.DateTo = d.DateFrom.AddDays(-1);
                    break;
                }
                else
                {
                    cd.DateFrom = d.DateTo.AddDays(1);
                }

            }

            return ret;
        }

        public DateList SubtractList_Simple(DateList dl)
        {
            var ret = this;
            foreach (var d in dl.List)
                ret = ret.SubtractDates(d.DateFrom, d.DateTo);
            return ret;
        }


        public DateList SubtractList_ForGoodLists(DateList dl)
        {
            if (dl.List.Count == 0 || List.Count == 0)
                return new DateList(this);

            var ret = new DateList();

            int ti = 0;
            int si = 0;
            var td1 = new DatesFromTo(List[0]);
            var sd1 = dl.List[0];

            DatesFromTo cd = null;

            while (true)
            {
                if (sd1 != null && td1.DateFrom > sd1.DateTo)
                {
                    if (si == dl.List.Count - 1)
                    {
                        sd1 = null;
                        continue;
                    }
                    si++;
                    sd1 = dl.List[si];
                    continue;
                }
                if (sd1 == null || td1.DateTo < sd1.DateFrom)
                {
                    ret.List.Add(td1);
                    if (ti == List.Count - 1) break;
                    ti++;
                    td1 = new DatesFromTo(List[ti]);
                    continue;
                }
                if (td1.DateFrom >= sd1.DateFrom && td1.DateTo <= sd1.DateTo)
                {
                    if (ti == List.Count - 1) break;
                    ti++;
                    td1.SetFrom(List[ti]);
                    continue;
                }
                if (td1.DateFrom >= sd1.DateFrom && td1.DateTo > sd1.DateTo)
                {
                    td1.DateFrom = sd1.DateTo.AddDays(1);
                    continue;
                }
                if (td1.DateFrom < sd1.DateFrom && td1.DateTo <= sd1.DateTo)
                {
                    td1.DateTo = sd1.DateFrom.AddDays(-1);
                    ret.List.Add(td1);
                    if (ti == List.Count - 1) break;
                    ti++;
                    td1 = new DatesFromTo(List[ti]);
                    continue;
                }
                if (td1.DateFrom < sd1.DateFrom && td1.DateTo > sd1.DateTo)
                {
                    cd = new DatesFromTo(td1);
                    cd.DateTo = sd1.DateFrom.AddDays(-1);
                    ret.List.Add(cd);
                    td1.DateFrom = sd1.DateTo.AddDays(1);
                    continue;
                }
            }

            return ret;
        }

        public DateList AddMerge_ForGoodLists(DateList dl)
        {
            var ret = SubtractFromDatesGoodList(DateTime.MinValue, DateTime.MaxValue);
            ret = ret.SubtractList_ForGoodLists(dl);
            ret = ret.InvertGoodList();
            return ret;
        }

    }

    public class DatesFromTo
    {
        public DateTime DateFrom;
        public DateTime DateTo;

        public DatesFromTo() { }

        public DatesFromTo(DateTime dt1, DateTime dt2)
        {
            DateFrom = dt1;
            DateTo = dt2;
        }

        public DatesFromTo(DatesFromTo d)
        {
            DateFrom = d.DateFrom;
            DateTo = d.DateTo;
        }

        public DatesFromTo(PeriodInfo pi)
        {
            DateFrom = pi.DateFirst;
            DateTo = pi.DateLast;
        }

        public void SetFrom(DatesFromTo d)
        {
            DateFrom = d.DateFrom;
            DateTo = d.DateTo;
        }
    }
}
