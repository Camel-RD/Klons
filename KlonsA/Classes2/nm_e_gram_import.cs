using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using KlonsA.Classes;
using KlonsA.DataSets;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsA.Classes
{
    public class EGrmUntMinImporter
    {
        KlonsData MyData => KlonsData.St;

        public NM_e_gramatinas EGramatinas = null;
        public List<UntMinImportData> UntMinChanges = null;

        private T DeserializeA<T>(string serializedResults)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(serializedResults))
                return (T)serializer.Deserialize(stringReader);
        }

        public NM_e_gramatinas Deserialize(string xmltext)
        {
            try
            {
                return DeserializeA<NM_e_gramatinas>(xmltext);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public KlonsADataSet.PERSONSRow FindPerson(string name, string personscode)
        {
            name = name.ToLower();
            var table = MyData.DataSetKlons.PERSONS;
            var drs = table
                .WhereX(x =>
                    x.PK == personscode ||
                    (string.IsNullOrEmpty(x.PK) && (x.YNAME.ToLower() == name)))
                .ToList();
            if (drs.Count != 1) return null;
            return drs[0];
        }

        public void MatchPersonLists(NM_e_gramatinas egrm,
            out Dictionary<NM_e_gramatinasGigv, KlonsADataSet.PERSONSRow> dict,
            out List<string> missingnames)
        {
            dict = new Dictionary<NM_e_gramatinasGigv, KlonsADataSet.PERSONSRow>();
            missingnames = new List<string>();
            foreach (var grm in egrm.gigv)
            {
                var pk = grm.pers_kods.ToString();
                if (pk.Length == 10) pk = "0" + pk;
                if (pk.Length == 11) pk = pk.Insert(6, "-");
                var drpr = FindPerson(grm.vards_uzvards, pk);
                if (drpr == null)
                {
                    missingnames.Add(grm.vards_uzvards);
                }
                else
                {
                    dict[grm] = drpr;
                }
            }
        }

        private PeriodInfo GetUntMinFromDB(KlonsADataSet.PERSONSRow drpr, DateTime dt1, DateTime dt2)
        {
            var um0 = new UntMinData();
            um0.Dt1 = dt1;
            um0.Dt2 = dt2;
            var ret = new PeriodInfo();
            ret.DateFirst = dt1;
            ret.DateLast = dt2;
            var ret2 = new PeriodInfo();
            ret2.DateFirst = dt1;
            ret2.DateLast = dt2;
            ret2.Item1 = um0;
            ret.LinkedPeriods.Add(ret2);

            var pi = new PeriodInfo();
            pi.DateFirst = dt1;
            pi.DateLast = dt2;
            var drs = drpr.GetUNTAXED_MINRows()
                .OrderBy(d => d.ONDATE)
                .ToArray();
            if (drs.Length == 0) return ret;
            var rt = pi.ReadDateListFilter(drs, d => d.ONDATE);
            if (rt != PeriodInfo.ERetReadStartEndList.OK ||
                pi.LinkedPeriods.Count == 0) return ret;

            ret.LinkedPeriods.Clear();
            foreach (var pi2 in pi.LinkedPeriods)
            {
                var dr_untmin = (pi2.Item1 as KlonsADataSet.UNTAXED_MINRow);
                var um1 = new UntMinData();
                um1.Dt1 = pi2.DateFirst;
                um1.Dt2 = pi2.DateLast;
                um1.UntMin = dr_untmin.UNTAXED_MIN;
                um1.IINRateType = dr_untmin.IIN_RATE_TYPE;
                var pi_out = new PeriodInfo();
                pi_out.DateFirst = um1.Dt1;
                pi_out.DateLast = um1.Dt2;
                pi_out.Item1 = um1;
                ret.LinkedPeriods.Add(pi_out);
            }
            return ret;
        }

        private PeriodInfo GetUntMinFromEgrm(NM_e_gramatinasGigv egrm, DateTime dt1, DateTime dt2)
        {
            var um0 = new UntMinData();
            um0.Dt1 = dt1;
            um0.Dt2 = dt2;
            var ret = new PeriodInfo();
            ret.DateFirst = dt1;
            ret.DateLast = dt2;
            var ret2 = new PeriodInfo();
            ret2.DateFirst = dt1;
            ret2.DateLast = dt2;
            ret2.Item1 = um0;
            ret.LinkedPeriods.Add(ret2);

            if (egrm.prognozetie_mnm == null || egrm.prognozetie_mnm.Length == 0) return ret;

            var pi = new PeriodInfo();
            pi.DateFirst = dt1;
            pi.DateLast = dt2;
            var ums1 = egrm.prognozetie_mnm
                .OrderBy(d => d.datums_no)
                .Where(d => d.datums_no <= dt2)
                .Select(d =>
                {
                    var rt = new UntMinData()
                    {
                        Dt1 = d.datums_no,
                        Dt2 = d.datums_lidzSpecified ? d.datums_lidz : dt2,
                        UntMin = (decimal)d.summa
                    };
                    if (rt.Dt1 < dt1) rt.Dt1 = dt1;
                    if (rt.Dt2 > dt2) rt.Dt2 = dt2;
                    return rt;
                })
                .Where(d => d.Dt2 >= d.Dt1 && d.Dt2 >= dt1)
                .ToList();

            if (ums1.Count == 0) return ret;

            var ums2 = ums1
                .Select(d => new PeriodInfo()
                {
                    DateFirst = d.Dt1,
                    DateLast = d.Dt2,
                    Item1 = d
                })
                .ToList();

            ret.LinkedPeriods.Clear();
            ret.LinkedPeriods.AddRange(ums2);

            return ret;
        }

        private PeriodInfo GetIINRateFromEgrm(NM_e_gramatinasGigv egrm, DateTime dt1, DateTime dt2)
        {
            var um0 = new UntMinData();
            um0.Dt1 = dt1;
            um0.Dt2 = dt2;
            var ret = new PeriodInfo();
            ret.DateFirst = dt1;
            ret.DateLast = dt2;
            var ret2 = new PeriodInfo();
            ret2.DateFirst = dt1;
            ret2.DateLast = dt2;
            ret2.Item1 = um0;
            ret.LinkedPeriods.Add(ret2);

            var egrm_iinlikme = egrm?.pazime_progr_iin_likmes?.pazime_progr_iin_likme;
            if (egrm_iinlikme == null) return ret;
            var ret3 = new UntMinData()
            {
                Dt1 = egrm_iinlikme.datums_no,
                Dt2 = egrm_iinlikme.datums_lidzSpecified ? egrm_iinlikme.datums_lidz : dt2,
                IINRateType = 1
            };
            if (ret3.Dt1 < dt1) ret3.Dt1 = dt1;
            if (ret3.Dt2 > dt2) ret3.Dt2 = dt2;
            if (ret3.Dt1 > dt2 || ret3.Dt2 < dt1 || ret3.Dt2 < ret3.Dt1) return ret;
            ret2.DateFirst = ret3.Dt1;
            ret2.DateLast = ret3.Dt2;
            ret2.Item1 = ret3;
            return ret;
        }

        private PeriodInfo MergeUntMinAndIINRateData(PeriodInfo pi_untmin, PeriodInfo pi_iinrate)
        {
            var um0 = new UntMinData();
            um0.Dt1 = pi_untmin.DateFirst;
            um0.Dt2 = pi_untmin.DateLast;
            var ret = new PeriodInfo();
            ret.DateFirst = pi_untmin.DateFirst;
            ret.DateLast = pi_untmin.DateLast;
            var ret2 = new PeriodInfo();
            ret2.DateFirst = pi_untmin.DateFirst;
            ret2.DateLast = pi_untmin.DateLast;
            ret2.Item1 = um0;
            ret.LinkedPeriods.Add(ret2);

            var dts1 = pi_untmin.LinkedPeriods.Select(d => d.DateFirst);
            var dts2 = pi_untmin.LinkedPeriods.Select(d => d.DateLast.AddDays(1));
            var dts3 = pi_iinrate.LinkedPeriods.Select(d => d.DateFirst);
            var dts4 = pi_iinrate.LinkedPeriods.Select(d => d.DateLast.AddDays(1));
            var dts = dts1
                .Union(dts2)
                .Union(dts3)
                .Union(dts4)
                .OrderBy(d => d)
                .ToList();

            if (dts.Count < 2) return ret;

            ret.LinkedPeriods.Clear();

            for (int i = 0; i <= dts.Count - 2; i++)
            {
                var adt1 = dts[i];
                var adt2 = dts[i + 1].AddDays(-1);
                var pi_out = new PeriodInfo();
                pi_out.DateFirst = adt1;
                pi_out.DateLast = adt2;
                var fpi_untmin = pi_untmin.FilterListWithDates(adt1, adt2);
                var fpi_iinrate = pi_iinrate.FilterListWithDates(adt1, adt2);
                if (fpi_untmin.LinkedPeriods.Count == 0) continue;

                var umout1 = new UntMinData();
                umout1.Dt1 = adt1;
                umout1.Dt2 = adt2;
                umout1.UntMin = (fpi_untmin.LinkedPeriods[0].Item1 as UntMinData).UntMin;
                if (fpi_iinrate.LinkedPeriods.Count == 1)
                    umout1.IINRateType = (fpi_iinrate.LinkedPeriods[0].Item1 as UntMinData).IINRateType;
                pi_out.Item1 = umout1;

                ret.LinkedPeriods.Add(pi_out);
            }

            return ret;
        }

        private PeriodInfo FillGaps(PeriodInfo pi, UntMinData um0)
        {
            var ret = new PeriodInfo();
            ret.DateFirst = pi.DateFirst;
            ret.DateLast = pi.DateLast;
            foreach(var pic in pi.LinkedPeriods)
            {
                var pi_prev = ret.LinkedPeriods.LastOrDefault();
                if (pi_prev != null && pic.DateFirst > pi_prev.DateLast.AddDays(1))
                {
                    var um1 = um0.Copy();
                    um1.Dt1 = pi_prev.DateLast.AddDays(1);
                    um1.Dt2 = pic.DateFirst.AddDays(-1);
                    var pi2 = new PeriodInfo();
                    pi2.DateFirst = um1.Dt1;
                    pi2.DateLast = um1.Dt2;
                    pi2.Item1 = um1;
                    ret.LinkedPeriods.Add(pi2);
                }
                ret.LinkedPeriods.Add(pic);
            }
            return ret;
        }

        private PeriodInfo FillGaps2(PeriodInfo pi, UntMinData um0)
        {
            var ret = new PeriodInfo();
            ret.DateFirst = pi.DateFirst;
            ret.DateLast = pi.DateLast;
            if (pi.LinkedPeriods.Count == 0)
            {
                var um1 = um0.Copy();
                um1.Dt1 = pi.DateFirst;
                um1.Dt2 = pi.DateLast;
                var pi2 = new PeriodInfo();
                pi2.DateFirst = pi.DateFirst;
                pi2.DateLast = pi.DateLast;
                pi2.Item1 = um1;
                pi.LinkedPeriods.Add(pi2);
                return ret;
            }
            foreach (var pic in pi.LinkedPeriods)
            {
                var pi_prev = ret.LinkedPeriods.LastOrDefault();
                if (pi_prev == null && pic.DateFirst > pi.DateFirst)
                {
                    var um1 = um0.Copy();
                    um1.Dt1 = pi.DateFirst;
                    um1.Dt2 = pic.DateFirst.AddDays(-1);
                    var pi2 = new PeriodInfo();
                    pi2.DateFirst = um1.Dt1;
                    pi2.DateLast = um1.Dt2;
                    pi2.Item1 = um1;
                    ret.LinkedPeriods.Add(pi2);
                }
                if (pi_prev != null && pic.DateFirst > pi_prev.DateLast.AddDays(1))
                {
                    var um1 = um0.Copy();
                    um1.Dt1 = pi_prev.DateLast.AddDays(1);
                    um1.Dt2 = pic.DateFirst.AddDays(-1);
                    var pi2 = new PeriodInfo();
                    pi2.DateFirst = um1.Dt1;
                    pi2.DateLast = um1.Dt2;
                    pi2.Item1 = um1;
                    ret.LinkedPeriods.Add(pi2);
                }
                ret.LinkedPeriods.Add(pic);
            }
            var pi_last = ret.LinkedPeriods.LastOrDefault();
            if (pi_last != null && pi_last.DateLast < pi.DateLast)
            {
                var um1 = um0.Copy();
                um1.Dt1 = pi_last.DateLast.AddDays(1);
                um1.Dt2 = pi.DateLast;
                var pi2 = new PeriodInfo();
                pi2.DateFirst = um1.Dt1;
                pi2.DateLast = um1.Dt2;
                pi2.Item1 = um1;
                ret.LinkedPeriods.Add(pi2);
            }
            return ret;
        }

        private PeriodInfo MergeUntMinData(PeriodInfo pi_db, PeriodInfo pi_egrm)
        {
            var um0 = new UntMinData();
            um0.Dt1 = pi_db.DateFirst;
            um0.Dt2 = pi_db.DateLast;
            var ret = new PeriodInfo();
            ret.DateFirst = pi_db.DateFirst;
            ret.DateLast = pi_db.DateLast;
            var ret2 = new PeriodInfo();
            ret2.DateFirst = pi_db.DateFirst;
            ret2.DateLast = pi_db.DateLast;
            ret2.Item1 = um0;
            ret2.Item2 = um0;
            ret.LinkedPeriods.Add(ret2);

            var dts1 = pi_db.LinkedPeriods.Select(d => d.DateFirst);
            var dts2 = pi_db.LinkedPeriods.Select(d => d.DateLast.AddDays(1));
            var dts3 = pi_egrm.LinkedPeriods.Select(d => d.DateFirst);
            var dts4 = pi_egrm.LinkedPeriods.Select(d => d.DateLast.AddDays(1));
            var dts = dts1
                .Union(dts2)
                .Union(dts3)
                .Union(dts4)
                .OrderBy(d => d)
                .ToList();

            if (dts.Count < 2) return ret;

            ret.LinkedPeriods.Clear();

            for (int i = 0; i <= dts.Count - 2; i++)
            {
                var adt1 = dts[i];
                var adt2 = dts[i + 1].AddDays(-1);
                var pi_out = new PeriodInfo();
                pi_out.DateFirst = adt1;
                pi_out.DateLast = adt2;
                var fpi_db = pi_db.FilterListWithDates(adt1, adt2);
                var fpi_egrm = pi_egrm.FilterListWithDates(adt1, adt2);

                var umout1 = new UntMinData();
                umout1.Dt1 = adt1;
                umout1.Dt2 = adt2;
                var umout2 = new UntMinData();
                umout2.Dt1 = adt1;
                umout2.Dt2 = adt2;
                pi_out.Item1 = umout1;
                pi_out.Item2 = umout2;

                if (fpi_db.LinkedPeriods.Count == 1)
                {
                    umout1.UntMin = (fpi_db.LinkedPeriods[0].Item1 as UntMinData).UntMin;
                    umout1.IINRateType = (fpi_db.LinkedPeriods[0].Item1 as UntMinData).IINRateType;
                }
                if (fpi_egrm.LinkedPeriods.Count == 1)
                {
                    umout2.UntMin = (fpi_egrm.LinkedPeriods[0].Item1 as UntMinData).UntMin;
                    umout2.IINRateType = (fpi_egrm.LinkedPeriods[0].Item1 as UntMinData).IINRateType;
                }

                ret.LinkedPeriods.Add(pi_out);
            }

            return ret;
        }

        private List<UntMinData> GetUntMinChanges(PeriodInfo pi_merged, PeriodInfo pi_db)
        {
            var ret = new List<UntMinData>();
            var merged_db_copy = pi_merged.LinkedPeriods
                .Select(x => x.Item1 as UntMinData)
                .Select(x => x.Copy());
            var list_merged_var = new List<UntMinData>(merged_db_copy);
            
            var add_update = new Action<UntMinData>((UntMinData update) =>
            {
                var fpi_db = pi_db.LinkedPeriods
                    .Where(x => x.DateFirst <= update.Dt1 && x.DateLast >= update.Dt1)
                    .FirstOrDefault()
                    ?.Item1 as UntMinData;
                if (fpi_db == null) return;
                list_merged_var
                    .Where(x => 
                        x.Dt1 > update.Dt2 && 
                        x.Dt1 >= fpi_db.Dt1 && 
                        x.Dt2 <= fpi_db.Dt2)
                    .ForEach(x =>
                    {
                        x.UntMin = update.UntMin;
                        x.IINRateType = update.IINRateType;
                    });
            });

            for (int i = 0; i < pi_merged.LinkedPeriods.Count; i++)
            {
                var pi2 = pi_merged.LinkedPeriods[i];
                var um_dbvar = list_merged_var[i];
                var um_db = pi2.Item1 as UntMinData;
                var um_egrm = pi2.Item2 as UntMinData;
                //if (um1.UntMin == um2.UntMin && um1.IINRateType == um2.IINRateType) continue;
                if (um_dbvar.UntMin == um_egrm.UntMin && 
                    um_dbvar.IINRateType == um_egrm.IINRateType) continue;
                var umrt = new UntMinData()
                {
                    Dt1 = um_db.Dt1,
                    Dt2 = um_db.Dt2,
                    UntMin = um_egrm.UntMin,
                    IINRateType = um_egrm.IINRateType
                };
                ret.Add(umrt);
                add_update(umrt);
            }
            return ret;
        }

        public string GetUntMinResult(string filename,
            DateTime dt1,
            DateTime dt2,
            out List<string> missingnames,
            out List<UntMinImportData> changes)
        {
            missingnames = new List<string>();
            changes = new List<UntMinImportData>();
            string xml = File.ReadAllText(filename);
            var egrms = Deserialize(xml);
            EGramatinas = egrms;
            UntMinChanges = changes;
            if (egrms == null) return "Neizdevās nolasīt pārskata xml failu";
            var edt1 = Utils.StringToDate(egrms.pamatdati.periods_no);
            var edt2 = Utils.StringToDate(egrms.pamatdati.periods_lidz);
            if (edt1 > dt1 || edt2 < dt2) return "EDS pārskata periods neatbilst pieprasītajam.";
            MatchPersonLists(egrms, out var dict_pr, out missingnames);
            foreach (var egrm in egrms.gigv)
            {
                if (!dict_pr.TryGetValue(egrm, out var drpr)) continue;
                var pi_db = GetUntMinFromDB(drpr, dt1, dt2);
                var pi_egrm_untmin = GetUntMinFromEgrm(egrm, dt1, dt2);
                var pi_egrm_iinrate = GetIINRateFromEgrm(egrm, dt1, dt2);
                var pi_merged_iinrate = MergeUntMinAndIINRateData(pi_egrm_untmin, pi_egrm_iinrate);
                var pi_merged_untmin = MergeUntMinData(pi_db, pi_merged_iinrate);
                var changes_pr = GetUntMinChanges(pi_merged_untmin, pi_db);
                var changes_pr2 = changes_pr
                    .Select(d => new UntMinImportData()
                    {
                        IDP = drpr.ID,
                        Name = drpr.YNAME,
                        PersonsCode = drpr.PK,
                        Dt = d.Dt1,
                        UntMin = d.UntMin,
                        IINRateType = d.IINRateType
                    });
                changes.AddRange(changes_pr2);
            }
            return "OK";
        }

    }

    public class UntMinData
    {
        public DateTime Dt1 { get; set; } = DateTime.MinValue;
        public DateTime Dt2 { get; set; } = DateTime.MinValue;
        public decimal UntMin { get; set; } = 0.00M;
        public int IINRateType { get; set; } = 0;

        public UntMinData Copy()
        {
            return new UntMinData()
            {
                Dt1 = this.Dt1,
                Dt2 = this.Dt2,
                UntMin = this.UntMin,
                IINRateType = this.IINRateType
            };
        }
    }

    public class UntMinImportData
    {
        public int IDP { get; set; } = -1;
        public string Name { get; set; } = null;
        public string PersonsCode { get; set; } = null;
        public DateTime Dt { get; set; } = DateTime.MinValue;
        public decimal UntMin { get; set; } = 0.00M;
        public int IINRateType { get; set; } = 0;
    }

}

