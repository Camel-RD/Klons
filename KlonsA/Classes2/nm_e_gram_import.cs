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

        public nm_e_gramatinas EGramatinas = null;
        public List<UntMinImportData> UntMinChanges = null;

        private T DeserializeA<T>(string serializedResults)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(serializedResults))
                return (T)serializer.Deserialize(stringReader);
        }

        public nm_e_gramatinas Deserialize(string xmltext)
        {
            try
            {
                return DeserializeA<nm_e_gramatinas>(xmltext);
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

        public void MatchPersonLists(nm_e_gramatinas egrm,
            out Dictionary<nm_e_gramatinasGigv, KlonsADataSet.PERSONSRow> dict,
            out List<string> missingnames)
        {
            dict = new Dictionary<nm_e_gramatinasGigv, KlonsADataSet.PERSONSRow>();
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

        private List<UntMinData> GetUntMinFromDB(KlonsADataSet.PERSONSRow drpr, DateTime dt1, DateTime dt2)
        {
            var ret = new List<UntMinData>();
            var um0 = new UntMinData()
            {
                Dt1 = dt1,
                Dt2 = dt2
            };
            ret.Add(um0);

            var pi = new PeriodInfo();
            pi.DateFirst = dt1;
            pi.DateLast = dt2;
            var drs = drpr.GetUNTAXED_MINRows()
                .OrderBy(x => x.ONDATE)
                .ToArray();
            if (drs.Length == 0) return ret;
            var rt = pi.ReadDateListFilter(drs, x => x.ONDATE);
            if (rt != PeriodInfo.ERetReadStartEndList.OK ||
                pi.LinkedPeriods.Count == 0) return ret;

            ret.Clear();
            foreach (var pi2 in pi.LinkedPeriods)
            {
                var dr_untmin = (pi2.Item1 as KlonsADataSet.UNTAXED_MINRow);
                var um1 = new UntMinData()
                {
                    Dt1 = pi2.DateFirst,
                    Dt2 = pi2.DateLast,
                    UntMin = dr_untmin.UNTAXED_MIN,
                    IINRateType = dr_untmin.IIN_RATE_TYPE
                };
                ret.Add(um1);
            }
            return ret;
        }

        private List<EgrData> GetEgrDataFromDB(KlonsADataSet.PERSONSRow drpr, DateTime dt1, DateTime dt2)
        {
            var ret = new List<EgrData>();
            var data0 = new EgrData()
            {
                Dt1 = dt1,
                Dt2 = dt2
            };
            ret.Add(data0);

            var pi = new PeriodInfo()
            {
                DateFirst = dt1,
                DateLast = dt2
            };
            var drs = drpr.GetPERSONS_RRows()
                .OrderBy(x => x.EDIT_DATE)
                .ToArray();
            if (drs.Length == 0) return ret;
            var rt = pi.ReadDateListFilter(drs, x => x.EDIT_DATE);
            if (rt != PeriodInfo.ERetReadStartEndList.OK ||
                pi.LinkedPeriods.Count == 0) return ret;

            ret.Clear();
            foreach (var pi2 in pi.LinkedPeriods)
            {
                var dr_data = (pi2.Item1 as KlonsADataSet.PERSONS_RRow);
                var data1 = new EgrData()
                {
                    Dt1 = pi2.DateFirst,
                    Dt2 = pi2.DateLast,
                    HasIt = !dr_data.TAXDOC_NO.IsNOE(),
                    ApgadajamoSkaits = dr_data.APGAD_SK
                };

                if (dr_data.INVALID == 1 || dr_data.INVALID == 2)
                    data1.PapilduAtvieglojumaVeids = $"{dr_data.INVALID}. grupas invalīds";
                else if (dr_data.REPRES > 0)
                    data1.PapilduAtvieglojumaVeids = "Represēta persona";
                else if (dr_data.PRET > 0)
                    data1.PapilduAtvieglojumaVeids = "Pretošanās kustības dalībnieks";
                if (dr_data.INVALID == 3)
                    data1.PapilduAtvieglojumaVeids = $"{dr_data.INVALID}. grupas invalīds";

                if (dr_data.PENSIONER == 1)
                    data1.PensijasVeids = "Vecuma pensija";
                else if (dr_data.PENSIONER_SP == 1)
                    data1.PensijasVeids = "Izdienas pensija";

                ret.Add(data1);
            }
            return ret;
        }

        private List<UntMinData> GetUntMinFromEgrm(nm_e_gramatinasGigv egrm, DateTime dt1, DateTime dt2)
        {
            var ret = new List<UntMinData>();
            var um0 = new UntMinData()
            {
                Dt1 = dt1,
                Dt2 = dt2
            };
            ret.Add(um0);

            if (egrm.prognozetie_mnm == null || egrm.prognozetie_mnm.Length == 0) return ret;

            var ums1 = egrm.prognozetie_mnm
                .OrderBy(x => x.datums_no)
                .Where(x => x.datums_no <= dt2)
                .Select(x =>
                {
                    var rt = new UntMinData()
                    {
                        Dt1 = x.datums_no,
                        Dt2 = x.datums_lidzSpecified && x.datums_lidz != null ? x.datums_lidz.Value : dt2,
                        UntMin = (decimal)x.summa
                    };
                    if (rt.Dt1 < dt1) rt.Dt1 = dt1;
                    if (rt.Dt2 > dt2) rt.Dt2 = dt2;
                    return rt;
                })
                .Where(x => x.Dt2 >= x.Dt1 && x.Dt2 >= dt1)
                .ToList();

            if (ums1.Count == 0) return ret;
            return ums1;
        }

        private List<UntMinData> GetIINRateFromEgrm(nm_e_gramatinasGigv egrm, DateTime dt1, DateTime dt2)
        {
            var ret = new List<UntMinData>();
            var um0 = new UntMinData()
            {
                Dt1 = dt1,
                Dt2 = dt2
            };
            ret.Add(um0);

            var egrm_iinlikme = egrm?.pazime_progr_iin_likmes?.pazime_progr_iin_likme;
            if (egrm_iinlikme == null) return ret;
            var um1 = new UntMinData()
            {
                Dt1 = egrm_iinlikme.datums_no,
                Dt2 = egrm_iinlikme.datums_lidzSpecified && egrm_iinlikme.datums_lidz != null ? egrm_iinlikme.datums_lidz.Value : dt2,
                IINRateType = 1
            };
            if (um1.Dt1 < dt1) um1.Dt1 = dt1;
            if (um1.Dt2 > dt2) um1.Dt2 = dt2;
            if (um1.Dt1 > dt2 || um1.Dt2 < dt1 || um1.Dt2 < um1.Dt1) return ret;
            ret = new List<UntMinData>() { um1 };
            return ret;
        }

        private List<EgrData> GetHasItFromEgrm(nm_e_gramatinasGigv[] egrms, DateTime dt1, DateTime dt2)
        {
            var ret = new List<EgrData>();
            var data0 = new EgrData()
            {
                Dt1 = dt1,
                Dt2 = dt2
            };
            ret.Add(data0);

            if (egrms == null || egrms.Length == 0) return ret;

            var data1 = egrms
                .OrderBy(x => x.datums_no)
                .Where(x => x.datums_no <= dt2)
                .Select(x =>
                {
                    var rt = new EgrData()
                    {
                        Dt1 = x.datums_no,
                        Dt2 = x.datums_lidzSpecified && x.datums_lidz != null ? x.datums_lidz.Value : dt2,
                        HasIt = true
                    };
                    if (rt.Dt1 < dt1) rt.Dt1 = dt1;
                    if (rt.Dt2 > dt2) rt.Dt2 = dt2;
                    return rt;
                })
                .Where(x => x.Dt2 >= x.Dt1 && x.Dt2 >= dt1)
                .ToList();

            return data1;
        }

        private List<EgrData> GetApgSkFromEgrm(nm_e_gramatinasGigv[] egrms, DateTime dt1, DateTime dt2)
        {
            var ret = new List<EgrData>();
            var data0 = new EgrData()
            {
                Dt1 = dt1,
                Dt2 = dt2
            };
            ret.Add(data0);

            if (egrms == null || egrms.Length == 0) return ret;

            var data1 = egrms
                .Where(x => x.datums_no <= dt2 && x.apgadajamie != null)
                .SelectMany(x => x.apgadajamie)
                .OrderBy(x => x.datums_no)
                .Select(x =>
                {
                    var rt = new EgrData()
                    {
                        Dt1 = x.datums_no,
                        Dt2 = x.datums_lidzSpecified && x.datums_lidz != null ? x.datums_lidz.Value : dt2
                    };
                    if (rt.Dt1 < dt1) rt.Dt1 = dt1;
                    if (rt.Dt2 > dt2) rt.Dt2 = dt2;
                    return rt;
                })
                .Where(x => x.Dt2 >= x.Dt1 && x.Dt2 >= dt1)
                .ToList();

            if (data1.Count == 0) return ret;

            var merged_date_list = new List<DateTime>();
            merged_date_list.Add(dt1);
            merged_date_list.Add(dt2);
            var dts1 = data1.Select(x => x.Dt1);
            var dts2 = data1.Select(x => x.Dt2.AddDays(1));
            var dts = dts1
                .Union(dts2)
                .OrderBy(x => x)
                .ToList();

            if (dts.Count < 2) return ret;

            ret.Clear();

            for (int i = 0; i <= dts.Count - 2; i++)
            {
                var adt1 = dts[i];
                var adt2 = dts[i + 1].AddDays(-1);

                var ct1 = data1
                    .Where(x => x.Dt1 <= adt2 && x.Dt2 >= adt1)
                    .Count();

                if (ct1 == 0) continue;

                var data2 = new EgrData()
                {
                    Dt1 = adt1,
                    Dt2 = adt2,
                    ApgadajamoSkaits = ct1
                };

                ret.Add(data2);
            }

            return ret;
        }

        private List<EgrData> GetPapAtvFromEgrm(nm_e_gramatinasGigv[] egrms, DateTime dt1, DateTime dt2)
        {
            var ret = new List<EgrData>();
            var data0 = new EgrData()
            {
                Dt1 = dt1,
                Dt2 = dt2
            };
            ret.Add(data0);

            if (egrms == null || egrms.Length == 0) return ret;

            var data1 = egrms
                .Where(x => x.datums_no <= dt2 && x.papildu_atvieglojumi != null)
                .SelectMany(x => x.papildu_atvieglojumi)
                .OrderBy(x => x.datums_no)
                .Select(x =>
                {
                    var rt = new EgrData()
                    {
                        Dt1 = x.datums_no,
                        Dt2 = x.datums_lidzSpecified && x.datums_lidz != null ? x.datums_lidz.Value : dt2,
                        PapilduAtvieglojumaVeids = x.veids
                    };
                    if (rt.Dt1 < dt1) rt.Dt1 = dt1;
                    if (rt.Dt2 > dt2) rt.Dt2 = dt2;
                    return rt;
                })
                .Where(x => x.Dt2 >= x.Dt1 && x.Dt2 >= dt1)
                .ToList();

            if (data1.Count == 0) return ret;
            return data1;
        }

        private List<EgrData> GetPensijasVeidsFromEgrm(nm_e_gramatinasGigv[] egrms, DateTime dt1, DateTime dt2)
        {
            var ret = new List<EgrData>();
            var data0 = new EgrData()
            {
                Dt1 = dt1,
                Dt2 = dt2
            };
            ret.Add(data0);

            if (egrms == null || egrms.Length == 0) return ret;

            var data1 = egrms
                .Select(x => x.pensijas?.pensija)
                .Where(x => x != null && x.datums_no <= dt2)
                .OrderBy(x => x.datums_no)
                .Select(x =>
                {
                    var rt = new EgrData()
                    {
                        Dt1 = x.datums_no,
                        Dt2 = x.datums_lidzSpecified && x.datums_lidz != null ? x.datums_lidz.Value : dt2,
                        PensijasVeids = x.veids
                    };
                    if (rt.Dt1 < dt1) rt.Dt1 = dt1;
                    if (rt.Dt2 > dt2) rt.Dt2 = dt2;
                    return rt;
                })
                .Where(x => x.Dt2 >= x.Dt1 && x.Dt2 >= dt1)
                .ToList();

            if (data1.Count == 0) return ret;
            return data1;
        }

        private List<EgrData> MergeEgrData(List<EgrData> hasit, List<EgrData> apgsk,
            List<EgrData> papatv, List<EgrData> pensijas, DateTime dt1, DateTime dt2)
        {
            var ret = new List<EgrData>();
            var data0 = new EgrData()
            {
                Dt1 = dt1,
                Dt2 = dt2
            };
            ret.Add(data0);

            var datelists = new[] { ret, hasit, apgsk, papatv, pensijas };
            var dts1 = datelists.SelectMany(x => x.Select(y => y.Dt1));
            var dts2 = datelists.SelectMany(x => x.Select(y => y.Dt2.AddDays(1)));
            var dates1 = dts1
                .Union(dts2)
                .OrderBy(x => x)
                .ToList();
            
            ret.Clear();

            void ActOnFirst(List<EgrData> list, DateTime pdt1, DateTime pdt2, Action<EgrData> act)
            {
                var egr = list
                    .Where(x => x.Dt1 <= pdt2 && x.Dt2 >= pdt1)
                    .FirstOrDefault();
                if (egr == null) return;
                act(egr);
            }

            for (int i = 0; i <= dates1.Count - 2; i++)
            {
                var adt1 = dates1[i];
                var adt2 = dates1[i + 1].AddDays(-1);

                var data1 = new EgrData()
                {
                    Dt1 = adt1,
                    Dt2 = adt2
                };

                ActOnFirst(hasit, adt1, adt2, x => data1.HasIt = x.HasIt);
                ActOnFirst(apgsk, adt1, adt2, x => data1.ApgadajamoSkaits = x.ApgadajamoSkaits);
                ActOnFirst(papatv, adt1, adt2, x => data1.PapilduAtvieglojumaVeids = x.PapilduAtvieglojumaVeids);
                ActOnFirst(pensijas, adt1, adt2, x => data1.PensijasVeids = x.PensijasVeids);

                ret.Add(data1);
            }

            return ret;
        }

        private List<UntMinData> MergeUntMinAndIINRateData(List<UntMinData> pi_untmin, 
            List<UntMinData> pi_iinrate, DateTime dt1, DateTime dt2)
        {
            var ret = new List<UntMinData>();
            var um0 = new UntMinData()
            {
                Dt1 = dt1,
                Dt2 = dt2
            };
            ret.Add(um0);

            var dts1 = pi_untmin.Select(x => x.Dt1);
            var dts2 = pi_untmin.Select(x => x.Dt2.AddDays(1));
            var dts3 = pi_iinrate.Select(x => x.Dt1);
            var dts4 = pi_iinrate.Select(x => x.Dt2.AddDays(1));
            var dts = dts1
                .Union(dts2)
                .Union(dts3)
                .Union(dts4)
                .OrderBy(x => x)
                .ToList();

            if (dts.Count < 2) return ret;

            ret.Clear();

            void ActOnFirst(List<UntMinData> list, DateTime pdt1, DateTime pdt2, Action<UntMinData> act)
            {
                var egr = list
                    .Where(x => x.Dt1 <= pdt2 && x.Dt2 >= pdt1)
                    .FirstOrDefault();
                if (egr == null) return;
                act(egr);
            }

            for (int i = 0; i <= dts.Count - 2; i++)
            {
                var adt1 = dts[i];
                var adt2 = dts[i + 1].AddDays(-1);

                var um1 = new UntMinData()
                {
                    Dt1 = adt1,
                    Dt2 = adt2
                };
                ActOnFirst(pi_untmin, adt1, adt2, x => um1.UntMin = x.UntMin);
                ActOnFirst(pi_iinrate, adt1, adt2, x => um1.IINRateType = x.IINRateType);

                ret.Add(um1);
            }

            return ret;
        }

        private List<UntMinData> FillGaps(List<UntMinData> data_um, UntMinData um0)
        {
            var ret = new List<UntMinData>();
            foreach(var um1 in data_um)
            {
                var um_prev = ret.LastOrDefault();
                if (um_prev != null && um1.Dt1 > um_prev.Dt2.AddDays(1))
                {
                    var um2 = um0.Copy();
                    um2.Dt1 = um_prev.Dt2.AddDays(1);
                    um2.Dt2 = um1.Dt1.AddDays(-1);
                    ret.Add(um2);
                }
                ret.Add(um1);
            }
            return ret;
        }

        private List<UntMinData> FillGaps2(List<UntMinData> data_um,
            UntMinData um0, DateTime dt1, DateTime dt2)
        {
            var ret = new List<UntMinData>();
            if (data_um.Count == 0)
            {
                var um1 = um0.Copy();
                um1.Dt1 = dt1;
                um1.Dt2 = dt2;
                ret.Add(um1);
                return ret;
            }
            foreach (var um1 in data_um)
            {
                var um_prev = ret.LastOrDefault();
                if (um_prev == null && um1.Dt1 > dt1)
                {
                    var um2 = um0.Copy();
                    um2.Dt1 = dt1;
                    um2.Dt2 = um1.Dt1.AddDays(-1);
                    ret.Add(um2);
                }
                if (um_prev != null && um1.Dt1 > um_prev.Dt2.AddDays(1))
                {
                    var um2 = um0.Copy();
                    um2.Dt1 = um_prev.Dt2.AddDays(1);
                    um2.Dt2 = um1.Dt1.AddDays(-1);
                    ret.Add(um2);
                }
                ret.Add(um1);
            }
            var um_last = ret.LastOrDefault();
            if (um_last != null && um_last.Dt2 < dt2)
            {
                var um1 = um0.Copy();
                um1.Dt1 = um_last.Dt2.AddDays(1);
                um1.Dt2 = dt2;
                ret.Add(um1);
            }
            return ret;
        }

        private List<UntMinData2> MergeUntMinData(List<UntMinData> data_db,
            List<UntMinData> data_eds, DateTime dt1, DateTime dt2)
        {
            var ret = new List<UntMinData2>();
            var um0 = new UntMinData2(dt1, dt2);
            ret.Add(um0);

            var dts1 = data_db.Select(x => x.Dt1);
            var dts2 = data_db.Select(x => x.Dt2.AddDays(1));
            var dts3 = data_eds.Select(x => x.Dt1);
            var dts4 = data_eds.Select(x => x.Dt2.AddDays(1));
            var dts = dts1
                .Union(dts2)
                .Union(dts3)
                .Union(dts4)
                .OrderBy(d => d)
                .ToList();

            if (dts.Count < 2) return ret;

            ret.Clear();

            UntMinData FindFirst(List<UntMinData> list, DateTime pdt1, DateTime pdt2)
            {
                return list
                    .Where(x => x.Dt1 <= pdt2 && x.Dt2 >= pdt1)
                    .FirstOrDefault();
            }


            for (int i = 0; i <= dts.Count - 2; i++)
            {
                var adt1 = dts[i];
                var adt2 = dts[i + 1].AddDays(-1);
                var data_out = new UntMinData2(adt1, adt2);
                var f_db = FindFirst(data_db, adt1, adt2);
                var f_eds = FindFirst(data_eds, adt1, adt2);

                if (f_db != null)
                {
                    data_out.DbData.UntMin = f_db.UntMin;
                    data_out.DbData.IINRateType = f_db.IINRateType;
                }
                if (f_eds != null)
                {
                    data_out.EdsData.UntMin = f_eds.UntMin;
                    data_out.EdsData.IINRateType = f_eds.IINRateType;
                }

                ret.Add(data_out);
            }

            return ret;
        }

        private List<EgrData2> MergeEgrData(List<EgrData> data_db, 
            List<EgrData> data_eds, DateTime dt1, DateTime dt2)
        {
            var ret = new List<EgrData2>();
            var data0 = new EgrData2(dt1, dt2);
            ret.Add(data0);

            var dts1 = data_db.Select(x => x.Dt1);
            var dts2 = data_db.Select(x => x.Dt2.AddDays(1));
            var dts3 = data_eds.Select(x => x.Dt1);
            var dts4 = data_eds.Select(x => x.Dt2.AddDays(1));
            var dts = dts1
                .Union(dts2)
                .Union(dts3)
                .Union(dts4)
                .OrderBy(d => d)
                .ToList();

            if (dts.Count < 2) return ret;

            ret.Clear();

            EgrData FindFirst(List<EgrData> list, DateTime pdt1, DateTime pdt2)
            {
                return list
                    .Where(x => x.Dt1 <= pdt2 && x.Dt2 >= pdt1)
                    .FirstOrDefault();
            }

            for (int i = 0; i <= dts.Count - 2; i++)
            {
                var adt1 = dts[i];
                var adt2 = dts[i + 1].AddDays(-1);
                var data_out = new EgrData2(adt1, adt2);
                var f_db = FindFirst(data_db, adt1, adt2);
                var f_eds = FindFirst(data_eds, adt1, adt2);


                if (f_db != null)
                {
                    data_out.DbData.HasIt = f_db.HasIt;
                    data_out.DbData.ApgadajamoSkaits = f_db.ApgadajamoSkaits;
                    data_out.DbData.PapilduAtvieglojumaVeids = f_db.PapilduAtvieglojumaVeids;
                    data_out.DbData.PensijasVeids = f_db.PensijasVeids;
                }
                if (f_eds != null)
                {
                    data_out.EdsData.HasIt = f_eds.HasIt;
                    data_out.EdsData.ApgadajamoSkaits = f_eds.ApgadajamoSkaits;
                    data_out.EdsData.PapilduAtvieglojumaVeids = f_eds.PapilduAtvieglojumaVeids;
                    data_out.EdsData.PensijasVeids = f_eds.PensijasVeids;
                }

                ret.Add(data_out);
            }

            return ret;
        }

        private List<UntMinData> GetUntMinChanges(List<UntMinData2> data_merged,
            List<UntMinData> data_db)
        {
            var ret = new List<UntMinData>();
            var list_merged_var = data_merged
                .Select(x => x.DbData.Copy())
                .ToList();
            
            void add_update(UntMinData update)
            {
                var f_db = data_db
                    .Where(x => x.Dt1 <= update.Dt1 && x.Dt2 >= update.Dt1)
                    .FirstOrDefault();
                if (f_db == null) return;
                list_merged_var
                    .Where(x => 
                        x.Dt1 > update.Dt2 && 
                        x.Dt1 >= f_db.Dt1 && 
                        x.Dt2 <= f_db.Dt2)
                    .ForEach(x =>
                    {
                        x.UntMin = update.UntMin;
                        x.IINRateType = update.IINRateType;
                    });
            };

            for (int i = 0; i < data_merged.Count; i++)
            {
                var data2 = data_merged[i];
                var um_dbvar = list_merged_var[i];
                var um_db = data2.DbData;
                var um_egrm = data2.EdsData;
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

        private List<EgrData2> GetEgrChanges(List<EgrData2> data_merged, List<EgrData> data_db)
        {
            var ret = new List<EgrData2>();
            var list_merged_var = data_merged
                .Select(x => x.DbData.Copy())
                .ToList();

            void add_update(EgrData update)
            {
                var f_db = data_db
                    .Where(x => x.Dt1 <= update.Dt1 && x.Dt2 >= update.Dt1)
                    .FirstOrDefault();
                if (f_db == null) return;
                list_merged_var
                    .Where(x =>
                        x.Dt1 > update.Dt2 &&
                        x.Dt1 >= f_db.Dt1 &&
                        x.Dt2 <= f_db.Dt2)
                    .ForEach(x =>
                    {
                        x.SetDataFrom(update);
                    });
            };

            for (int i = 0; i < data_merged.Count; i++)
            {
                var egr2 = data_merged[i];
                var data_dbvar = list_merged_var[i];
                var egr_db = egr2.DbData;
                var egr_eds = egr2.EdsData;
                if (egr_db.SameData(egr_eds)) continue;
                var update = new EgrData()
                {
                    Dt1 = egr_db.Dt1,
                    Dt2 = egr_db.Dt2
                };
                update.SetDataFrom(egr_eds);
                var egr_change = egr2.Copy();
                egr_change.Dt1 = egr_db.Dt1;
                egr_change.Dt2 = egr_db.Dt1;

                ret.Add(egr_change);
                add_update(update);
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
                var data_db = GetUntMinFromDB(drpr, dt1, dt2);
                var data_egrm_untmin = GetUntMinFromEgrm(egrm, dt1, dt2);
                var data_egrm_iinrate = GetIINRateFromEgrm(egrm, dt1, dt2);
                var data_merged_iinrate = MergeUntMinAndIINRateData(data_egrm_untmin, data_egrm_iinrate, dt1, dt2);
                var data_merged_untmin = MergeUntMinData(data_db, data_merged_iinrate, dt1, dt2);
                var changes_pr = GetUntMinChanges(data_merged_untmin, data_db);
                var changes_pr2 = changes_pr
                    .Select(x => new UntMinImportData()
                    {
                        IDP = drpr.ID,
                        Name = drpr.YNAME,
                        PersonsCode = drpr.PK,
                        Dt = x.Dt1,
                        UntMin = x.UntMin,
                        IINRateType = x.IINRateType
                    });
                changes.AddRange(changes_pr2);
            }
            return "OK";
        }

        public string GetEgrResult(string filename,
            DateTime dt1,
            DateTime dt2,
            out List<string> missingnames,
            out List<EgrImportData> changes)
        {
            missingnames = new List<string>();
            changes = new List<EgrImportData>();
            string xml = File.ReadAllText(filename);
            var egrms = Deserialize(xml);
            EGramatinas = egrms;
            if (egrms == null) return "Neizdevās nolasīt pārskata xml failu";
            var edt1 = Utils.StringToDate(egrms.pamatdati.periods_no);
            var edt2 = Utils.StringToDate(egrms.pamatdati.periods_lidz);
            if (edt1 > dt1 || edt2 < dt2) return "EDS pārskata periods neatbilst pieprasītajam.";
            MatchPersonLists(egrms, out var dict_pr, out missingnames);
            var gr_egr = dict_pr
                .GroupBy(x => x.Value);
            foreach (var person_egrm in gr_egr)
            {
                var drpr = person_egrm.Key;
                if (drpr == null) continue;
                var arr_egrm = person_egrm
                    .Select(x => x.Key)
                    .OrderBy(x => x.datums_no)
                    .ToArray();
                var data_db = GetEgrDataFromDB(drpr, dt1, dt2);
                var data_egrm_hasit = GetHasItFromEgrm(arr_egrm, dt1, dt2);
                var data_egrm_apgsk = GetApgSkFromEgrm(arr_egrm, dt1, dt2);
                var data_egrm_papatv = GetPapAtvFromEgrm(arr_egrm, dt1, dt2);
                var data_egrm_pensijas = GetPensijasVeidsFromEgrm(arr_egrm, dt1, dt2);
                var data_merged_eds = MergeEgrData(data_egrm_hasit, data_egrm_apgsk, 
                    data_egrm_papatv, data_egrm_pensijas, dt1, dt2);
                var data_merged = MergeEgrData(data_db, data_merged_eds, dt1, dt2);
                var changes_pr = GetEgrChanges(data_merged, data_db);
                var changes_pr2 = changes_pr
                    .Select(x => new EgrImportData()
                    {
                        IDP = drpr.ID,
                        Name = drpr.YNAME,
                        PersonsCode = drpr.PK,
                        Dt = x.Dt1,
                        DB_HasIt = x.DbData.HasIt,
                        DB_ApgadajamoSkaits = x.DbData.ApgadajamoSkaits,
                        DB_PapilduAtvieglojumaVeids = x.DbData.PapilduAtvieglojumaVeids,
                        DB_PensijasVeids = x.DbData.PensijasVeids,
                        EDS_HasIt = x.EdsData.HasIt,
                        EDS_ApgadajamoSkaits = x.EdsData.ApgadajamoSkaits,
                        EDS_PapilduAtvieglojumaVeids = x.EdsData.PapilduAtvieglojumaVeids,
                        EDS_PensijasVeids = x.EdsData.PensijasVeids
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

    public class UntMinData2
    {
        public DateTime Dt1 { get; set; } = DateTime.MinValue;
        public DateTime Dt2 { get; set; } = DateTime.MinValue;
        public UntMinData DbData { get; set; } = new UntMinData();
        public UntMinData EdsData { get; set; } = new UntMinData();

        public UntMinData2() { }
        public UntMinData2(DateTime dt1, DateTime dt2)
        {
            Dt1 = dt1;
            Dt2 = dt2;
            DbData.Dt1 = dt1;
            DbData.Dt2 = dt2;
            EdsData.Dt1 = dt1;
            EdsData.Dt2 = dt2;
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

    public class EgrData
    {
        public DateTime Dt1 { get; set; } = DateTime.MinValue;
        public DateTime Dt2 { get; set; } = DateTime.MinValue;
        public bool HasIt { get; set; } = false;
        public int ApgadajamoSkaits { get; set; } = 0;
        public string PapilduAtvieglojumaVeids { get; set; } = null;
        public string PensijasVeids { get; set; } = null;

        public EgrData Copy()
        {
            return new EgrData()
            {
                Dt1 = this.Dt1,
                Dt2 = this.Dt2,
                ApgadajamoSkaits = this.ApgadajamoSkaits,
                HasIt = this.HasIt,
                PapilduAtvieglojumaVeids = this.PapilduAtvieglojumaVeids,
                PensijasVeids = this.PensijasVeids
            };
        }

        public bool SameData(EgrData egr)
        {
            var pensijasveids = egr.PensijasVeids;
            if (pensijasveids == "Invaliditātes pensija")
                pensijasveids = null;
            return HasIt == egr.HasIt &&
                ApgadajamoSkaits == egr.ApgadajamoSkaits &&
                PapilduAtvieglojumaVeids == egr.PapilduAtvieglojumaVeids &&
                PensijasVeids == pensijasveids;
        }

        public void SetDataFrom(EgrData egr)
        {
            HasIt = egr.HasIt;
            ApgadajamoSkaits = egr.ApgadajamoSkaits;
            PapilduAtvieglojumaVeids = egr.PapilduAtvieglojumaVeids;
            PensijasVeids = egr.PensijasVeids;
        }
    }

    public class EgrData2
    {
        public DateTime Dt1 { get; set; } = DateTime.MinValue;
        public DateTime Dt2 { get; set; } = DateTime.MinValue;
        public EgrData DbData { get; set; } = new EgrData();
        public EgrData EdsData { get; set; } = new EgrData();

        public EgrData2() { }
        public EgrData2(DateTime dt1, DateTime dt2) 
        {
            Dt1 = dt1;
            Dt2 = dt2;
            DbData.Dt1 = dt1;
            DbData.Dt2 = dt2;
            EdsData.Dt1 = dt1;
            EdsData.Dt2 = dt2;
        }

        public EgrData2 Copy()
        {
            return new EgrData2()
            {
                Dt1 = Dt1,
                Dt2 = Dt2,
                DbData = DbData.Copy(),
                EdsData = EdsData.Copy()
            };
        }
    }

    public class EgrImportData
    {
        public int IDP { get; set; } = -1;
        public string Name { get; set; } = null;
        public string PersonsCode { get; set; } = null;
        public DateTime Dt { get; set; } = DateTime.MinValue;
        public bool DB_HasIt { get; set; } = false;
        public int DB_ApgadajamoSkaits { get; set; } = 0;
        public string DB_PapilduAtvieglojumaVeids { get; set; } = null;
        public string DB_PensijasVeids { get; set; } = null;
        public bool EDS_HasIt { get; set; } = false;
        public int EDS_ApgadajamoSkaits { get; set; } = 0;
        public string EDS_PapilduAtvieglojumaVeids { get; set; } = null;
        public string EDS_PensijasVeids { get; set; } = null;
    }

}

