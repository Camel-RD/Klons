using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsP.DataSets;
using KlonsP.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Components;
using KlonsLIB.Misc;
using KlonsLIB.MySourceGrid.GridRows;
using KlonsLIB.Data;

namespace KlonsP.Classes
{
    public class Report_Movement
    {
        protected static KlonsData MyData => KlonsData.St;

        public List<EventRepInfo> ReportRows = null;
        public List<EventRepInfo> ReportRowsA = null;
        public Dictionary<RepGroupKey, EventRepInfo> GroupingDict = null;

        public DateTime DT1 = DateTime.MinValue;
        public DateTime DT2 = DateTime.MaxValue;

        public bool DoFilter = false;
        public string FilterCat1 = null;
        public string FilterCatD = null;
        public string FilterCatT = null;
        public string FilterDep = null;
        public string FilterPlace = null;

        public bool AddTotals = true;

        public bool DoSortByRegnr = true;

        public bool DoGrouping = false;
        public int GroupOrderCat1 = -1;
        public int GroupOrderCatD = -1;
        public int GroupOrderCatT = -1;
        public int GroupOrderDep = -1;
        public int GroupOrderPlace = -1;

        public bool SimpleLike(string s, string filter)
        {
            if (string.IsNullOrEmpty(filter)) return true;
            if (string.IsNullOrEmpty(s)) return filter == "*";
            bool starswith = filter.EndsWith("*");
            if (starswith)
            {
                filter = filter.Substring(0, filter.Length - 1);
                return s.StartsWith(filter);
            }
            return s == filter;
        }

        public bool FilterGroupingKey(RepGroupKey gk)
        {
            if (!DoFilter) return true;
            return
                (GroupOrderCat1 == -1 || SimpleLike(gk.Fields[0], FilterCat1)) &&
                (GroupOrderCatD == -1 || SimpleLike(gk.Fields[1], FilterCatD)) &&
                (GroupOrderCatT == -1 || SimpleLike(gk.Fields[2], FilterCatT)) &&
                (GroupOrderDep == -1 || SimpleLike(gk.Fields[3], FilterDep)) &&
                (GroupOrderPlace == -1 || SimpleLike(gk.Fields[4], FilterPlace));
        }

        public bool FilterEvent(EventRepInfo ev)
        {
            if (!DoFilter) return true;
            if (FilterCat1 != null && !SimpleLike(ev.SCat1, FilterCat1)) return false;
            if (FilterCatD != null && !SimpleLike(ev.SCatD, FilterCatD)) return false;
            if (FilterCatT != null && !SimpleLike(ev.SCatT, FilterCatT)) return false;
            if (FilterDep != null && !SimpleLike(ev.SDepartment, FilterDep)) return false;
            if (FilterPlace != null && !SimpleLike(ev.SPlace, FilterPlace)) return false;
            return true;
        }

        private bool IsGroupingKeyChanged(EventInfo ev1, EventInfo ev2)
        {
            return
                !((GroupOrderCat1 == -1 || ev1.Cat1 == ev2.Cat1) &&
                (GroupOrderCatD == -1 || ev1.CatD == ev2.CatD) &&
                (GroupOrderCatT == -1 || ev1.CatT == ev2.CatT) &&
                (GroupOrderDep == -1 || ev1.Department == ev2.Department) &&
                (GroupOrderPlace == -1 || ev1.Place == ev2.Place));
        }

        public static int[] GetBackSortOrder(int[] kk)
        {
            var bkk = new int[kk.Length];
            for (int i = 0; i < kk.Length; i++)
                bkk[i] = -1;
            for (int i = 0; i < kk.Length; i++)
            {
                var k = kk[i];
                if (k < 0) continue;
                bkk[k] = i;
            }
            return bkk;
        }

        public void MakeSimpleReport()
        {
            ReportRows = new List<EventRepInfo>();
            var table_items = MyData.DataSetKlons.ITEMS;
            var drs_items = table_items
                .WhereNotDeleted()
                .OrderBy(d => d.REG_NR)
                .ThenBy(d => d.ID);

            int[] fieldsortorder = new[] { GroupOrderCat1, GroupOrderCatD,
                GroupOrderCatT, GroupOrderDep, GroupOrderPlace };
            int[] fieldsortorderA = new[] { 0, 1, 2, 3, 4 };

            var DT1x = DT1.FirstDayOfMonth().AddDays(-1);

            foreach (var dr_item in drs_items)
            {
                var it = new ItemInfo();
                it.SetFromRow(dr_item);
                if (it.Events.Count == 0) continue;
                if (it.Events[0].Dt > DT2) continue;
                if (it.Events.Count > 1)
                {
                    var ev = it.Events[it.Events.Count - 1];
                    if (ev.XEvent == EEvent.likvid && ev.Dt < DT1) continue;
                }

                var rt = it.CheckItem();
                if (rt != "OK") continue;
                var rev1 = new EventRepInfo()
                {
                    Dt = DT1x,
                    LastInDay = true,
                    XEvent = EEvent.apr,
                    FieldSortOrder = fieldsortorder
                };
                var rev2 = new EventRepInfo()
                {
                    Dt = DT2,
                    LastInDay = true,
                    XEvent = EEvent.apr,
                    FieldSortOrder = fieldsortorder
                };
                it.Events2 = new List<EventInfo>();
                it.Events2.Add(rev1);
                it.Events2.Add(rev2);

                rt = it.FullCalc();
                if (rt != "OK") continue;

                rev2.IdIt = dr_item.ID;
                rev2.RegNr = dr_item.REG_NR;
                rev2.Name = dr_item.NAME;

                rev2.SetSFields();
                rev2.SetRFields();

                if (DoFilter)
                    if (!FilterEvent(rev2)) continue;

                rev2.ValueC = rev2.ValueNew + rev2.ValueAdd + rev2.ValueRevalue + rev2.ValueExclude;

                rev2.DeprecC = rev2.DeprecNew + rev2.DeprecAdd + rev2.DeprecRevalue +
                    +rev2.DeprecExclude + rev2.DeprecCalc;

                rev2.TaxValC = rev2.TaxValNewCalc + rev2.TaxValAddCalc - rev2.TaxValExcludeCalc;

                rev2.Value0 = rev2.Value1 - rev2.ValueC;
                rev2.Deprec0 = rev2.Deprec1 - rev2.DeprecC;
                rev2.ValueLeft0 = rev2.Value0 - rev2.Deprec0;
                rev2.ValueNew += rev2.ValueAdd;
                rev2.ValueAdd = 0.0M;
                rev2.DeprecRevalue += rev2.DeprecNew + rev2.DeprecAdd;
                rev2.DeprecNew = 0.0M;
                rev2.DeprecAdd = 0.0M;

                rev2.TaxValLeft0 = rev2.TaxValLeft1 - rev2.TaxValC + rev2.TaxDeprecCalc;

                rev2.FieldSortOrder = fieldsortorder;
                ReportRows.Add(rev2);
            }
            if(!DoSortByRegnr)
                ReportRows.Sort();
            var sum = SumTotals(ReportRows, -1);
            ReportRows.Add(sum);
        }


        public void MakeGroupReport()
        {
            ReportRows = new List<EventRepInfo>();
            var table_items = MyData.DataSetKlons.ITEMS;
            var drs_items = table_items.WhereNotDeleted();

            GroupingDict = new Dictionary<RepGroupKey, EventRepInfo>();
            int[] groupingorder = new[] { GroupOrderCat1, GroupOrderCatD, GroupOrderCatT,
                GroupOrderDep, GroupOrderPlace};
            int[] groupingorderA = GetBackSortOrder(groupingorder);
            bool ShowDescr = groupingorderA[1] == -1;

            var DT1x = DT1.FirstDayOfMonth().AddDays(-1);

            foreach (var dr_item in drs_items)
            {
                var it = new ItemInfo();
                it.SetFromRow(dr_item);
                if (it.Events.Count == 0) continue;
                if (it.Events[0].Dt > DT2) continue;
                if (it.Events.Count > 1)
                {
                    var ev = it.Events[it.Events.Count - 1];
                    if (ev.XEvent == EEvent.likvid && ev.Dt < DT1) continue;
                }

                var rt = it.CheckItem();
                if (rt != "OK") continue;
                var rev1 = new EventRepInfo()
                {
                    Dt = DT1x,
                    LastInDay = true,
                    XEvent = EEvent.apr
                };
                var rev2 = new EventRepInfo()
                {
                    Dt = DT2,
                    LastInDay = true,
                    XEvent = EEvent.apr
                };
                it.Events2 = new List<EventInfo>();
                it.Events2.Add(rev1);

                for (int i = 1; i < it.Events.Count; i++)
                {
                    var ev = it.Events[i];
                    if (ev.XEvent != EEvent.rekat) continue;
                    var ev_pr = it.Events[i - 1];
                    if (ev.Dt < DT1 || ev.Dt > DT2) continue;
                    if (!IsGroupingKeyChanged(ev_pr, ev)) continue;

                    var ev_new = new EventRepInfo();
                    ev_new.Dt = ev.Dt;
                    ev_new.LastInDay = false;
                    it.Events2.Add(ev_new);
                }

                it.Events2.Add(rev2);
                rt = it.FullCalc();
                if (rt != "OK") continue;

                if (it.Events2.Count > 2)
                {
                    for (int i = 1; i < it.Events2.Count - 1; i++)
                    {
                        var evr = it.Events2[i] as EventRepInfo;
                        var evrn = it.Events2[i + 1] as EventRepInfo;

                        evr.ValueRecat = -evr.Value1;
                        evr.DeprecRecat = -evr.Deprec1;
                        evr.TaxValRecatCalc = -evr.TaxValLeft0;

                        evrn.ValueRecat = evr.Value1;
                        evrn.DeprecRecat = evr.Deprec1;
                        evrn.TaxValRecatCalc = evr.TaxValLeft0;

                        evr.Value0 = 0.0M;
                        evr.Value1 = 0.0M;
                        evr.Deprec0 = 0.0M;
                        evr.Deprec1 = 0.0M;
                        evr.ValueLeft0 = 0.0M;
                        evr.ValueLeft1 = 0.0M;

                        evr.TaxVal = 0.0M;
                        evr.TaxValLeft1 = 0.0M;
                        evr.TaxValLeft0 = 0.0M;
                        evr.TaxDeprec = 0.0M;
                    }
                }

                for (int i = 0; i < it.Events2.Count; i++)
                {
                    var evr = it.Events2[i] as EventRepInfo;
                    evr.TaxValC = evr.TaxValNewCalc + evr.TaxValAddCalc 
                        + evr.TaxValRecatCalc - evr.TaxValExcludeCalc;
                }


                rev1.Value1 = 0.0M;
                rev1.Deprec1 = 0.0M;
                rev1.ValueLeft1 = 0.0M;
                rev1.ValueC = 0.0M;
                rev1.DeprecC = 0.0M;
                rev1.TaxVal = 0.0M;
                rev1.TaxValC = 0.0M;
                rev1.TaxValLeft1 = 0.0M;
                rev1.TaxDeprec = 0.0M;

                rev1.ValueNew = 0.0M;
                rev1.ValueAdd = 0.0M;
                rev1.ValueRevalue = 0.0M;
                rev1.ValueExclude = 0.0M;
                rev1.DeprecNew = 0.0M;
                rev1.DeprecAdd = 0.0M;
                rev1.DeprecRevalue = 0.0M;
                rev1.DeprecExclude = 0.0M;
                rev1.DeprecCalc = 0.0M;
                rev1.TaxValNewCalc = 0.0M;
                rev1.TaxValAddCalc = 0.0M;
                rev1.TaxValExcludeCalc = 0.0M;
                rev1.TaxDeprecCalc = 0.0M;
                rev1.TaxValLeftAtEndCalc = 0.0M;

                rev2.Value0 = 0.0M;
                rev2.Deprec0 = 0.0M;
                rev2.ValueLeft0 = 0.0M;
                rev2.TaxVal = 0.0M;
                rev2.TaxValLeft0 = 0.0M;
                rev2.TaxDeprec = 0.0M;

                rev2.ValueNew += rev2.ValueAdd;
                rev2.ValueAdd = 0.0M;
                rev2.DeprecRevalue += rev2.DeprecNew + rev2.DeprecAdd;
                rev2.DeprecNew = 0.0M;
                rev2.DeprecAdd = 0.0M;

                if (rev2.State == EState.OK || rev2.State == EState.NotUsed)
                    rev2.CountAtEnd = 1;

                foreach (var ev in it.Events2)
                {
                    if (ev.Cat1 == 0 && ev.CatD == 0 && ev.CatT == 0 && 
                        ev.Department == 0 && ev.Place == 0) continue;

                    var evr = ev as EventRepInfo;
                    evr.FieldSortOrder = groupingorder;

                    evr.SetSFields();
                    if (DoFilter && !FilterEvent(evr)) continue;
                    evr.SetSFieldsIgnore();
                    evr.SetRFields();

                    var gk = new RepGroupKey()
                    {
                        GroupingOrder = groupingorder,
                        Fields = new[] {evr.SCat1, evr.SCatD, evr.SCatT, evr.SDepartment,
                            evr.SPlace}
                    };

                    EventRepInfo evr_dic = null;
                    if (!GroupingDict.TryGetValue(gk, out evr_dic))
                    {
                        evr_dic = new EventRepInfo()
                        {
                            Cat1 = evr.Cat1,
                            CatD = evr.CatD,
                            CatT = evr.CatT,
                            Department = evr.Department,
                            Place = evr.Place,

                            SCat1 = evr.SCat1,
                            SCatD = evr.SCatD,
                            SCatT = evr.SCatT,
                            SDepartment = evr.SDepartment,
                            SPlace = evr.SPlace,

                            RCat1 = evr.RCat1,
                            RCat2 = evr.RCat2,
                            RCat3 = evr.RCat3,
                            RCat4 = evr.RCat4,
                            RCat5 = evr.RCat5,

                            FieldSortOrder = groupingorder
                        };

                        if (ShowDescr)
                            evr_dic.SetName1(groupingorderA[0]);

                        GroupingDict[gk] = evr_dic;
                    }
                    evr_dic.Add(evr);

                }

            }

            var evs = GroupingDict
                .Where(d => FilterGroupingKey(d.Key))
                .OrderBy(d => d.Key)
                .Select(d => d.Value);
            
            ReportRows.AddRange(evs);

            if (!AddTotals) return;

            int firstGroupField = groupingorderA[0];
            var sum = SumTotals(ReportRows, firstGroupField);

            if (ReportRows.Count > 0 && (GroupOrderCat1 == 0 || 
                    GroupOrderDep == 0 || GroupOrderDep == 0))
            {
                List<string> keys = null;
                List<int> ids = null;
                GetTotalsKeys(firstGroupField, out keys, out ids);
                if (keys.Count > 0)
                {
                    var dic_totals = SumGroupTotals(firstGroupField, ReportRows, keys, ids);
                    foreach (var kv in dic_totals)
                    {
                        kv.Key.GroupingOrder = groupingorder;
                        GroupingDict[kv.Key] = kv.Value;
                    }

                    var evs2 = GroupingDict
                        .Where(d => FilterGroupingKey(d.Key))
                        .OrderBy(d => d.Key)
                        .Select(d => d.Value)
                        .ToArray();

                    ReportRows.Clear();
                    ReportRows.AddRange(evs);
                }
            }
            ReportRows.Add(sum);
        }

        public EventRepInfo SumTotals(IEnumerable<EventRepInfo> evrs, int k)
        {
            var ret = new EventRepInfo()
            {
                RegNr = "KOPĀ",
                RCat1 = "KOPĀ",
                Name = "Kopsumma",
                IsTotal = true
            };
            if (k >= 0)
            {
                ret.SetSField(k, "KOPĀ");
                ret.SetRField(k, "KOPĀ");
            }
            foreach (var evr in evrs)
                ret.Add(evr);
            return ret;
        }

        public void GetTotalsKeys(int k, out List<string> keys, out List<int> ids)
        {
            switch (k)
            {
                case 0:
                    GetTotalsKeys_Cat1(out keys, out ids);
                    break;
                case 3:
                    GetTotalsKeys_Dep(out keys, out ids);
                    break;
                case 4:
                    GetTotalsKeys_Place(out keys, out ids);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void GetTotalsKeys_Cat1(out List<string> keys, out List<int> ids)
        {
            keys = new List<string>();
            ids = new List<int>();
            var table_cat1 = MyData.DataSetKlons.CAT1;
            var drs = table_cat1
                .WhereX(d => d.GROUP == 1)
                .OrderBy(d => d.CODE);
            foreach (var dr in drs)
            {
                keys.Add(dr.CODE);
                ids.Add(dr.ID);
            }
        }

        public void GetTotalsKeys_Dep(out List<string> keys, out List<int> ids)
        {
            keys = new List<string>();
            ids = new List<int>();
            var table_dep = MyData.DataSetKlons.DEPARTMENTS;
            var drs = table_dep
                .WhereX(d => d.GROUP == 1)
                .OrderBy(d => d.CODE);
            foreach (var dr in drs)
            {
                keys.Add(dr.CODE);
                ids.Add(dr.ID);
            }
        }

        public void GetTotalsKeys_Place(out List<string> keys, out List<int> ids)
        {
            keys = new List<string>();
            ids = new List<int>();
            var table_place = MyData.DataSetKlons.PLACES;
            var drs = table_place
                .WhereX(d => d.GROUP == 1)
                .OrderBy(d => d.CODE);
            foreach (var dr in drs)
            {
                keys.Add(dr.CODE);
                ids.Add(dr.ID);
            }
        }

        public Dictionary<RepGroupKey, EventRepInfo> SumGroupTotals(int k,
            List<EventRepInfo> list, List<string> keys, List<int> ids)
        {
            var ret = new Dictionary<RepGroupKey, EventRepInfo>();
            string list_cur = null, key_cur = null;
            for(int i = 0; i < list.Count; i++)
            {
                var ev_cur = list[i];
                list_cur = ev_cur.GetSField(k);
                int pos = keys.BinarySearch(list_cur);
                if (pos >= 0 && pos < keys.Count) pos += 1;
                if (pos < 0) pos = ~pos;
                pos--;
                if (pos == -1) continue;
                EventRepInfo ev_dic = null;
                while (pos >= 0)
                {
                    key_cur = keys[pos];
                    if (!list_cur.StartsWith(key_cur)) break;
                    var gk = new RepGroupKey(5);
                    gk.Fields[0] = key_cur;
                    if (!ret.TryGetValue(gk, out ev_dic))
                    {
                        ev_dic = new EventRepInfo();
                        ev_dic.FieldSortOrder = ev_cur.FieldSortOrder;
                        ev_dic.SetFieldId(k, ids[pos]);
                        ev_dic.SetSField(k, key_cur);
                        ev_dic.RCat1 = key_cur;
                        ev_dic.SetName1(k);
                        ev_dic.IsTotal = true;
                        ret[gk] = ev_dic;
                    }
                    ev_dic.Add(ev_cur);

                    pos--;
                }
            }
            return ret;
        }


    }


    public class RepGroupKey : IComparable<RepGroupKey>, IComparable
    {
        public int[] GroupingOrder = null;
        public string[] Fields = null;

        public RepGroupKey()
        {
        }
        public RepGroupKey(int keysz)
        {
            Fields = new string[keysz];
        }

        public RepGroupKey Copy()
        {
            var gk = new RepGroupKey(Fields.Length);
            for (int i = 0; i < Fields.Length; i++)
                gk.Fields[i] = Fields[i];
            gk.GroupingOrder = GroupingOrder;
            return gk;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is RepGroupKey)) return false;
            RepGroupKey gk = (RepGroupKey)obj;
            return Equals(gk);
        }

        public bool Equals(RepGroupKey gk)
        {
            if (gk == null) return false;
            if (object.ReferenceEquals(this, gk)) return true;

            if (GroupingOrder == null)
            {
                for (int i = 0; i < Fields.Length; i++)
                    if(gk.Fields[i] != Fields[i]) return false;
                return true;
            }

            for (int i = 0; i < Fields.Length; i++)
                if (GroupingOrder[i] != -1 && gk.Fields[i] != Fields[i]) return false;
            return true;
        }

        private int GetHashCode(int[] ar)
        {
            int hc = ar.Length;
            for (int i = 0; i < ar.Length; ++i)
                //hc = unchecked(hc * 314159 + ar[i]);
                hc = unchecked(hc * 31 + ar[i]);
            return hc;
        }

        public override int GetHashCode()
        {
            string s = "";
            if (GroupingOrder == null)
            {
                for (int i = 0; i < Fields.Length; i++)
                    s += Fields[i].Nz() + "◯";
            }
            else
            {
                for (int i = 0; i < Fields.Length; i++)
                    s += GroupingOrder[i] != -1 ? "◯" : Fields[i].Nz() + "◯";
            }
            return s.GetHashCode();
        }

        int IComparable<RepGroupKey>.CompareTo(RepGroupKey other)
        {
            if (other == null)
                throw new ArgumentNullException();

            for (int i = 0; i < Fields.Length; i++)
            {
                for (int j = 0; j < Fields.Length; j++)
                {
                    if (GroupingOrder[j] == i)
                    {
                        int k = string.Compare(Fields[j], other.Fields[j]);
                        if (k != 0) return k;
                    }
                }
            }
            return 0;
        }

        int IComparable.CompareTo(object obj)
        {
            var cp = this as IComparable<RepGroupKey>;
            return cp.CompareTo(obj as RepGroupKey);
        }


    }

}
