using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KlonsA.DataSets;
using KlonsLIB.Misc;
using KlonsLIB.Data;
using KlonsA.DataSets.KlonsADataSetTableAdapters;

namespace KlonsA.Classes
{
    public class PeriodInfo
    {
        public object Item1 = null;
        public object Item2 = null;
        public DateTime DateFirst = DateTime.MinValue;
        public DateTime DateLast = DateTime.MaxValue;
        public EPeriodId PeriodId = EPeriodId.None;
        public EEventId EEventId = EEventId.None;

        public List<PeriodInfo> LinkedPeriods = new List<PeriodInfo>();

        public PeriodInfo()
        {
        }

        public PeriodInfo(PeriodInfo pi)
        {
            Item1 = pi.Item1;
            Item2 = pi.Item2;
            DateFirst = pi.DateFirst;
            DateLast = pi.DateLast;
            PeriodId = pi.PeriodId;
            EEventId = pi.EEventId;
        }

        public object GetItemByDate(DateTime date)
        {
            foreach (var pi in LinkedPeriods)
            {
                if (pi.DateFirst <= date && pi.DateLast >= date)
                    return pi.Item1;
            }
            return null;
        }

        public PeriodInfo FilterListWithDates(DateTime dt1, DateTime dt2)
        {
            var retpi = new PeriodInfo(this);
            retpi.DateFirst = dt1;
            retpi.DateLast = dt2;

            foreach (var pi in LinkedPeriods)
            {
                if (pi.DateFirst > dt2 || pi.DateLast < dt1) continue;
                var npi = new PeriodInfo(pi);
                if (npi.DateFirst < dt1) npi.DateFirst = dt1;
                if (npi.DateLast > dt2) npi.DateLast = dt2;
                retpi.LinkedPeriods.Add(npi);
            }

            return retpi;
        }

        public PeriodInfo FilterThisWithList(PeriodInfo pif)
        {
            var retpi = new PeriodInfo(this);

            foreach (var pf in pif.LinkedPeriods)
            {
                if (DateFirst > pf.DateLast || DateLast < pf.DateFirst) continue;
                var npi = new PeriodInfo(this);
                if (npi.DateFirst < pf.DateFirst) npi.DateFirst = pf.DateFirst;
                if (npi.DateLast > pf.DateLast) npi.DateLast = pf.DateLast;
                retpi.LinkedPeriods.Add(npi);
            }

            return retpi;
        }

        public PeriodInfo FilterWithList(PeriodInfo pif)
        {
            return FilterWithList(pif.LinkedPeriods);
        }

        public PeriodInfo FilterWithList(IEnumerable<PeriodInfo> pif)
        {
            var retpi = new PeriodInfo(this);
            if (pif == null) return retpi;
            foreach (var pi in LinkedPeriods)
            {
                foreach (var pf in pif)
                {
                    if (pi.DateFirst > pf.DateLast || pi.DateLast < pf.DateFirst) continue;
                    var npi = new PeriodInfo(pi);
                    if (npi.DateFirst < pf.DateFirst) npi.DateFirst = pf.DateFirst;
                    if (npi.DateLast > pf.DateLast) npi.DateLast = pf.DateLast;
                    retpi.LinkedPeriods.Add(npi);
                }
            }

            return retpi;
        }

        public PeriodInfo FilterWithDateList(IEnumerable<DatesFromTo> el)
        {
            var retpi = new PeriodInfo(this);
            if (el == null) return retpi;
            foreach (var pi in LinkedPeriods)
            {
                foreach (var d in el)
                {
                    if (pi.DateFirst > d.DateTo || pi.DateLast < d.DateFrom) continue;
                    var npi = new PeriodInfo(pi);
                    if (npi.DateFirst < d.DateFrom) npi.DateFirst = d.DateFrom;
                    if (npi.DateLast > d.DateTo) npi.DateLast = d.DateTo;
                    retpi.LinkedPeriods.Add(npi);
                }
            }

            return retpi;
        }

        private static object _skipValue = new object();
        public static object SkipValue => _skipValue;

        //for sequancing some value form Item1
        //func f must return value A if PI1.A != PI2.A, or SkipValue if PI1.A == PI2.A
        public PeriodInfo FilterValueListWithDates(Func<PeriodInfo, PeriodInfo, object> f)
        {
            var retpi = new PeriodInfo(this);
            retpi.DateFirst = DateFirst;
            retpi.DateLast = DateLast;
            if (LinkedPeriods.Count == 0) return retpi;

            var pi1 = LinkedPeriods[0];
            var npi = new PeriodInfo(pi1);
            retpi.LinkedPeriods.Add(npi);

            if (LinkedPeriods.Count == 1) return retpi;

            for(int i = 1; i < LinkedPeriods.Count; i++)
            {
                var pi2 = LinkedPeriods[i];
                var val = f(pi1, pi2);
                if(object.ReferenceEquals(val, SkipValue))
                {
                    npi.DateLast = pi2.DateLast;
                    continue;
                }
                pi1 = pi2;
                npi = new PeriodInfo(pi1);
                retpi.LinkedPeriods.Add(npi);
            }

            return retpi;
        }

        public PeriodInfo SubtractList(IEnumerable<PeriodInfo> pif)
        {
            var dl = new DateList(LinkedPeriods);
            var dlf = new DateList(pif);
            dlf = dl.SubtractList_ForGoodLists(dlf);
            return FilterWithDateList(dlf.List);
        }

        public int CountDates(DateTime dt1, DateTime dt2)
        {
            DateTime d1, d2;
            int ret = 0;
            foreach (var pi in LinkedPeriods)
            {
                if (pi.DateFirst > dt2 || pi.DateLast < dt1) continue;
                var npi = new PeriodInfo(pi);
                d1 = npi.DateFirst;
                d2 = npi.DateLast;
                if (d1 < dt1) d1 = dt1;
                if (d2 > dt2) d2 = dt2;
                ret += (d2 - d1).Days + 1;
            }

            return ret;
        }

        public void CrossWith(PeriodInfo pic, out PeriodInfo pi1, out PeriodInfo pi2)
        {
            if (LinkedPeriods.Count == 0 || pic.LinkedPeriods.Count == 0 ||
                LinkedPeriods[0].DateFirst != pic.LinkedPeriods[0].DateFirst ||
                LinkedPeriods[LinkedPeriods.Count-1].DateLast != pic.LinkedPeriods[pic.LinkedPeriods.Count-1].DateLast)
                throw new ArgumentException("Bad lists.");

            pi1 = new PeriodInfo(this);
            pi2 = new PeriodInfo(pic);
            int k1 = -1, k2 = -1;
            PeriodInfo kpi1 = null;
            PeriodInfo kpi2 = null;

            kpi1 = pi1.LinkedPeriods[0];
            kpi2 = pi1.LinkedPeriods[0];
            var kdt11 = kpi1.DateFirst;
            var kdt21 = kpi2.DateFirst;

            DateTime kdt12, kdt22;
            PeriodInfo npi1, npi2;

            bool eo1 = false, eo2 = false;

            if(kdt11 < kdt21)
            {
                while (true)
                {
                    kdt12 = kpi1.DateLast;
                    if (kdt12 < kdt21)
                    {
                        npi1 = new PeriodInfo(kpi1);
                        pi1.LinkedPeriods.Add(npi1);
                        pi2.LinkedPeriods.Add(null);
                        k1++;
                        eo1 = k1 == LinkedPeriods.Count;
                        if (eo1) break;
                        kpi1 = LinkedPeriods[k1];
                    }
                    else
                    {
                        npi1 = new PeriodInfo(kpi1);
                        npi1.DateLast = kdt21.AddDays(-1);
                        pi1.LinkedPeriods.Add(npi1);
                        pi2.LinkedPeriods.Add(null);
                        kdt12 = kdt21;
                        break;
                    }
                }
            }
            else if (kdt21 < kdt11)
            {
                while (true)
                {
                    kdt22 = kpi2.DateLast;
                    if (kdt22 < kdt11)
                    {
                        npi2 = new PeriodInfo(kpi2);
                        pi1.LinkedPeriods.Add(null);
                        pi2.LinkedPeriods.Add(npi2);
                        k2++;
                        eo2 = k2 == pic.LinkedPeriods.Count;
                        if (eo2) break;
                        kpi2 = pic.LinkedPeriods[k2];
                    }
                    else
                    {
                        npi2 = new PeriodInfo(kpi2);
                        npi2.DateLast = kdt11.AddDays(-1);
                        pi1.LinkedPeriods.Add(null);
                        pi2.LinkedPeriods.Add(npi2);
                        kdt22 = kdt11;
                        break;
                    }
                }
            }

            while (true)
            {
                kdt12 = kpi1.DateLast;
                kdt22 = kpi2.DateLast;

                if (kdt12 < kdt22)
                {
                    npi1 = new PeriodInfo(kpi1)
                    {
                        DateFirst = kdt11,
                        DateLast = kdt12
                    };
                    npi2 = new PeriodInfo(kpi2)
                    {
                        DateFirst = kdt21,
                        DateLast = kdt12
                    };
                    pi1.LinkedPeriods.Add(npi1);
                    pi2.LinkedPeriods.Add(npi2);
                    kdt21 = kdt12.AddDays(1);
                    k1++;
                    eo1 = k1 == LinkedPeriods.Count;
                    if (eo1) break;
                    kpi1 = LinkedPeriods[k1];
                    kdt11 = kpi1.DateFirst;
                    continue;
                }

                if (kdt12 > kdt22)
                {
                    npi1 = new PeriodInfo(kpi1)
                    {
                        DateFirst = kdt11,
                        DateLast = kdt22
                    };
                    npi2 = new PeriodInfo(kpi2)
                    {
                        DateFirst = kdt21,
                        DateLast = kdt22
                    };
                    pi1.LinkedPeriods.Add(npi1);
                    pi2.LinkedPeriods.Add(npi2);
                    kdt11 = kdt22.AddDays(1);
                    k2++;
                    eo2 = k2 == pic.LinkedPeriods.Count;
                    if (eo2) break;
                    kpi2 = pic.LinkedPeriods[k2];
                    kdt21 = kpi2.DateFirst;
                    continue;
                }

                if (kdt12 == kdt22)
                {
                    npi1 = new PeriodInfo(kpi1)
                    {
                        DateFirst = kdt11,
                        DateLast = kdt12
                    };
                    npi2 = new PeriodInfo(kpi2)
                    {
                        DateFirst = kdt21,
                        DateLast = kdt22
                    };
                    pi1.LinkedPeriods.Add(npi1);
                    pi2.LinkedPeriods.Add(npi2);
                    kdt11 = kdt22.AddDays(1);
                    kdt21 = kdt11;
                    k1++;
                    k2++;
                    eo1 = k1 == LinkedPeriods.Count;
                    eo2 = k2 == pic.LinkedPeriods.Count;
                    if (eo1 || eo2) break;
                    kpi1 = LinkedPeriods[k1];
                    kpi2 = pic.LinkedPeriods[k2];
                    kdt11 = kpi1.DateFirst;
                    kdt21 = kpi2.DateFirst;
                    continue;
                }

            }

            if (eo1 && eo2) return;

            if (eo1)
            {
                while (true)
                {
                    npi2 = new PeriodInfo(kpi2)
                    {
                        DateFirst = kdt21
                    };
                    pi1.LinkedPeriods.Add(null);
                    pi2.LinkedPeriods.Add(npi2);
                    k2++;
                    eo2 = k2 == pic.LinkedPeriods.Count;
                    if (eo2) return;

                    kpi2 = pic.LinkedPeriods[k2];
                    kdt21 = kpi2.DateFirst;
                }
            }

            if (eo2)
            {
                while (true)
                {
                    npi1 = new PeriodInfo(kpi1)
                    {
                        DateFirst = kdt11
                    };
                    pi1.LinkedPeriods.Add(npi1);
                    pi2.LinkedPeriods.Add(null);
                    k1++;
                    eo1 = k1 == LinkedPeriods.Count;
                    if (eo1) return;
                    kpi1 = LinkedPeriods[k1];
                    kdt11 = kpi1.DateFirst;
                }
            }
        }


        public void MarkDates<T>(T[] days, DateTime dt1, DateTime dt2, T mark)
        {
            if (dt1 > dt2)
                throw new ArgumentException("Bad dates.");
            var days_count = dt2.Subtract(dt1).Days + 1;
            if (days == null || days.Length < days_count)
                throw new ArgumentException("Bad target.");
            if (LinkedPeriods.Count == 0) return;
            DateTime dtx1, dtx2;
            foreach (var pxi in LinkedPeriods)
            {
                dtx1 = pxi.DateFirst;
                dtx2 = pxi.DateLast;
                if (dtx1 > dt2 || dtx2 < dt1) continue;
                if (dtx1 < dt1) dtx1 = dt1;
                if (dtx2 > dt2) dtx2 = dt2;
                int k1 = dtx1.Subtract(dt1).Days;
                int k2 = dtx2.Subtract(dt1).Days;
                for (int i = k1; i <= k2; i++)
                {
                    days[i] = mark;
                }
            }
        }

        public void MarkDatesA<T>(T[] days, DateTime dt1, DateTime dt2, Func<PeriodInfo, T> getmarkfunc)
        {
            if (dt1 > dt2)
                throw new ArgumentException("Bad dates.");
            var days_count = dt2.Subtract(dt1).Days + 1;
            if (days == null || days.Length < days_count)
                throw new ArgumentException("Bad target.");
            if (LinkedPeriods.Count == 0) return;
            DateTime dtx1, dtx2;
            foreach (var pxi in LinkedPeriods)
            {
                dtx1 = pxi.DateFirst;
                dtx2 = pxi.DateLast;
                if (dtx1 > dt2 || dtx2 < dt1) continue;
                if (dtx1 < dt1) dtx1 = dt1;
                if (dtx2 > dt2) dtx2 = dt2;
                int k1 = dtx1.Subtract(dt1).Days;
                int k2 = dtx2.Subtract(dt1).Days;
                for (int i = k1; i <= k2; i++)
                {
                    days[i] = getmarkfunc(pxi);
                }
            }
        }

        public bool ContainsDate(DateTime dt)
        {
            return DateFirst <= dt && DateLast >= dt;
        }

        public bool ContainsThis(PeriodInfo pi)
        {
            return !(DateFirst > pi.DateLast || DateLast < pi.DateFirst);
        }

        public bool ContainsList(PeriodInfo pi)
        {
            if (pi.LinkedPeriods.Count == 0) return true;
            foreach (var p in pi.LinkedPeriods)
                if (!ContainsThis(p)) return false;
            return true;
        }
        public bool ListContainsThis(PeriodInfo pi)
        {
            if (LinkedPeriods.Count == 0) return false;
            foreach (var p in LinkedPeriods)
                if (p.ContainsThis(pi)) return true;
            return false;
        }

        public bool ListContainsList(PeriodInfo pi)
        {
            if (pi.LinkedPeriods.Count == 0) return true;
            if (LinkedPeriods.Count == 0) return false;
            foreach (var p in pi.LinkedPeriods)
                if (!ListContainsThis(p)) return false;
            return true;
        }

        public enum ERetReadStartEndList
        {
            OK, BadStart, BadEnd, BadDates, EmptyList
        }

        public static TItem FindNearestBefore<TItem>(TItem[] items,
            DateTime date, Func<TItem, DateTime> getItemDate)
        {
            if (items.Length == 0) return default(TItem);
            TItem it1;
            DateTime dt1, dt2;
            dt1 = DateTime.MaxValue;
            for (int i = items.Length - 1; i >= 0; i--)
            {
                it1 = items[i];
                dt2 = getItemDate(it1);
                if (dt2 > dt1)
                {
                    throw new ArgumentException("List not sorted");
                    //return default(TItem);
                }
                dt1 = dt2;
                if (dt2 <= date)
                {
                    return it1;
                }
            }
            return default(TItem);
        }

        // filtered with DateFirst, DateLast
        public ERetReadStartEndList ReadDateListFilter<TItem>(TItem[] items,
            Func<TItem, DateTime> getItemDate)
        {
            LinkedPeriods.Clear();

            if (items.Length == 0) return ERetReadStartEndList.EmptyList;
            DateTime dt1, dt2;
            dt1 = DateTime.MinValue;
            TItem itd = default(TItem);
            TItem it0 = itd;
            PeriodInfo new_per;

            for (int i = 0; i < items.Length; i++)
            {
                TItem it1 = items[i];

                dt2 = getItemDate(it1);
                if (dt1 >= dt2)
                {
                    return ERetReadStartEndList.BadDates;
                }

                if (dt2 <= this.DateFirst)
                {
                    it0 = it1;
                    dt1 = dt2;
                    continue;
                }

                if (dt2 > this.DateFirst && dt1 < this.DateFirst &&
                    !object.ReferenceEquals(it0, itd))
                {
                    new_per = new PeriodInfo()
                    {
                        Item1 = it0,
                        DateFirst = this.DateFirst
                    };
                    LinkedPeriods.Add(new_per);
                }

                if (dt2 > this.DateLast)
                {
                    break;
                }

                new_per = new PeriodInfo()
                {
                    Item1 = it1,
                    DateFirst = dt2
                };
                LinkedPeriods.Add(new_per);

                dt1 = dt2;
            }


            if (LinkedPeriods.Count == 0)
            {
                if (!object.ReferenceEquals(it0, itd))
                {
                    new_per = new PeriodInfo()
                    {
                        Item1 = it0,
                        DateFirst = this.DateFirst,
                        DateLast = this.DateLast
                    };
                    LinkedPeriods.Add(new_per);
                }
                else
                    return ERetReadStartEndList.BadDates;
            }

            for (int i = 0; i < LinkedPeriods.Count - 1; i++)
            {
                LinkedPeriods[i].DateLast = LinkedPeriods[i + 1].DateFirst.AddDays(-1);
            }

            LinkedPeriods[LinkedPeriods.Count - 1].DateLast = this.DateLast;

            return ERetReadStartEndList.OK;
        }


        public ERetReadStartEndList ReadDateListAll<TItem>(TItem[] items,
            Func<TItem, DateTime> getItemDate)
        {
            LinkedPeriods.Clear();

            if (items.Length == 0) return ERetReadStartEndList.EmptyList;
            DateTime dt1, dt2;
            PeriodInfo new_per;

            dt1 = DateTime.MinValue;

            for (int i = 0; i < items.Length; i++)
            {
                TItem it1 = items[i];

                dt2 = getItemDate(it1);
                if (dt1 >= dt2)
                {
                    return ERetReadStartEndList.BadDates;
                }

                new_per = new PeriodInfo()
                {
                    Item1 = it1,
                    DateFirst = dt2
                };
                LinkedPeriods.Add(new_per);

                dt1 = dt2;
            }

            if (LinkedPeriods.Count == 0)
            {
                return ERetReadStartEndList.BadDates;
            }

            for (int i = 0; i < LinkedPeriods.Count - 1; i++)
            {
                LinkedPeriods[i].DateLast = LinkedPeriods[i + 1].DateFirst.AddDays(-1);
            }

            return ERetReadStartEndList.OK;
        }


        //not filtered
        public ERetReadStartEndList ReadStartEndList<TItem>(TItem[] items,
            Func<TItem, bool> isStartItem, Func<TItem, DateTime> getItemDate)
        {
            if (items.Length == 0) return ERetReadStartEndList.OK;
            int k = 0;
            DateTime dt1, dt2;
            dt1 = DateTime.MinValue;
            while (k < items.Length)
            {
                TItem it1 = items[k];
                TItem it2 = default(TItem);
                PeriodInfo new_per;

                if (!isStartItem(it1))
                {
                    return ERetReadStartEndList.BadStart;
                }
                dt2 = getItemDate(it1);
                if (dt1 > dt2)
                {
                    return ERetReadStartEndList.BadDates;
                }
                dt1 = dt2;
                if (k == items.Length - 1)
                {
                    new_per = new PeriodInfo()
                    {
                        Item1 = it1,
                        DateFirst = dt1
                    };
                    LinkedPeriods.Add(new_per);
                    return ERetReadStartEndList.OK;
                }

                it2 = items[k + 1];
                if (isStartItem(it2))
                {
                    return ERetReadStartEndList.BadEnd;
                }
                dt2 = getItemDate(it2);
                if (dt1 > dt2)
                {
                    return ERetReadStartEndList.BadDates;
                }

                new_per = new PeriodInfo()
                {
                    Item1 = it1,
                    Item2 = it2,
                    DateFirst = dt1,
                    DateLast = dt2
                };
                dt1 = dt2;
                LinkedPeriods.Add(new_per);

                k += 2;
            }
            return ERetReadStartEndList.OK;
        }
        public enum ERetReadPeriodList
        {
            OK, BadDates, PeriodsOverlap
        }
        public ERetReadPeriodList ReadPeriodList<TItem>(TItem[] items,
            Func<TItem, DateTime> getItemDate1, Func<TItem, DateTime> getItemDate2)
        {
            if (items.Length == 0) return ERetReadPeriodList.OK;
            DateTime dt1, dt2;
            PeriodInfo pi = null;
            foreach (var it in items)
            {
                dt1 = getItemDate1(it);
                dt2 = getItemDate2(it);

                if (dt1 > dt2)
                    return ERetReadPeriodList.BadDates;

                if (pi != null && dt1 <= pi.DateLast)
                    return ERetReadPeriodList.PeriodsOverlap;

                pi = new PeriodInfo()
                {
                    Item1 = it,
                    DateFirst = dt1,
                    DateLast = dt2
                };
                LinkedPeriods.Add(pi);
            }
            return ERetReadPeriodList.OK;
        }
    }

}
