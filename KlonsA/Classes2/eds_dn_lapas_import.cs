using System;
using System.Collections.Generic;
using System.Data;
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
    public class EdsDNLapasImporter
    {
        KlonsData MyData => KlonsData.St;
        public NM_dn_dnl EdsDNLapas = null;

        private static T DeserializeA<T>(string serializedResults)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(serializedResults))
                return (T)serializer.Deserialize(stringReader);
        }

        public static NM_dn_dnl Deserialize(string xmltext)
        {
            try
            {
                return DeserializeA<NM_dn_dnl>(xmltext);
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

        public string Ucase(string val)
        {
            var s1 = val.ToLower();
            return s1[0].ToString().ToUpper() + s1.Substring(1);
        }

        public string GetName(SRSCertificateDataType dnlapa)
        {
            return Ucase(dnlapa.PersonData.FirstName) + " " +
                Ucase(dnlapa.PersonData.LastName);
        }

        public string GetPK(SRSCertificateDataType dnlapa)
        {
            var pk = dnlapa.PersonData.PersonID.Trim();
            if (pk.Length == 10) pk = "0" + pk;
            if (pk.Length == 11) pk = pk.Insert(6, "-");
            return pk;
        }

        public void MatchPersonLists(NM_dn_dnl dnlapas,
            out Dictionary<SRSCertificateDataType, KlonsADataSet.PERSONSRow> dict,
            out List<string> missingnames)
        {
            dict = new Dictionary<SRSCertificateDataType, KlonsADataSet.PERSONSRow>();
            missingnames = new List<string>();
            foreach (var dnlapa in dnlapas.dati)
            {
                var name = GetName(dnlapa);
                var pk = GetPK(dnlapa);
                var drpr = FindPerson(name, pk);
                if (drpr == null)
                {
                    if(!missingnames.Contains(name))
                        missingnames.Add(name);
                    dict[dnlapa] = drpr;
                }
                else
                {
                    dict[dnlapa] = drpr;
                }
            }
        }

        private List<DNLapaDati> GetDNLFromDB(KlonsADataSet.PERSONSRow drpr, DateTime dt1, DateTime dt2)
        {
            var ret = new List<DNLapaDati>();
            var dnl0 = new DNLapaDati()
            {
                Dt1 = dt1,
                Dt2 = dt2
            };
            ret.Add(dnl0);

            var drs = drpr.GetEVENTSRows()
                .Where(x => x.EventCode == EEventId.Slimības_lapa_A ||
                    x.EventCode == EEventId.Slimības_lapa_B)
                .Where(x => x.DATE1 <= dt2 && x.DATE2 >= dt1.AddDays(-1))
                .OrderBy(x => x.DATE1)
                .ToList();

            ret.Clear();
            foreach (var dr in drs)
            {
                var dnl1 = new DNLapaDati()
                {
                    IDEV = dr.ID,
                    Dt1 = dr.DATE1,
                    Dt2 = dr.DATE2,
                    Veids = dr.EventCode == EEventId.Slimības_lapa_A ? "A" : "B"
                };
                ret.Add(dnl1);
            }
            return ret;
        }

        private List<DNLapaDati> GetDNLFromEds(SRSCertificateDataType[] lapas, 
            DateTime dt1, DateTime dt2, DateTime dt3)
        {
            var ret = GetDNLFromEdsA(lapas, dt1, dt2, dt3);
            if (ret.Count > 0) return ret;
            var data0 = new DNLapaDati()
            {
                Dt1 = dt1,
                Dt2 = dt2
            };
            ret.Add(data0);
            return ret;
        }

        private List<DNLapaDati> GetDNLFromEdsA(SRSCertificateDataType[] lapas,
            DateTime dt1, DateTime dt2, DateTime dt3)
        {
            var ret = new List<DNLapaDati>();

            if (lapas == null || lapas.Length == 0) return ret;

            var data1 = lapas
                .Where(x => x.PeriodDates.StartDate <= dt2)
                .Select(x =>
                {
                    var rt = new DNLapaDati()
                    {
                        Dt1 = x.PeriodDates.StartDate,
                        Dt2 = x.PeriodDates.EndDateSpecified ? x.PeriodDates.EndDate : dt3,
                        Veids = x.CertificateType,
                        Status = x.CertificateStatus.StatusText
                    };
                    return rt;
                })
                .Where(x => x.Dt2 >= x.Dt1 && x.Dt2 >= dt1)
                .OrderBy(x => x.Dt1)
                .ToList();

            return data1;
        }

        public List<DNLapaImportData> MergeData(List<DNLapaDati> data_db,
            List<DNLapaDati> data_eds, DateTime dt1, DateTime dt2)
        {
            var ret = new List<DNLapaImportData>();
            var dts1 = data_db.Select(x => x.Dt1);
            var dts2 = data_db.Select(x => x.Dt2.AddDays(1));
            var dts3 = data_eds.Select(x => x.Dt1);
            var dts4 = data_eds.Select(x => x.Dt2.AddDays(1));
            var dates1 = new[] { dt1, dt2.AddDays(1) }
                .Union(dts1)
                .Union(dts2)
                .Union(dts3)
                .Union(dts4)
                .Where(x => x >= dt1 && x <= dt2.AddDays(1))
                .OrderBy(x => x)
                .ToList();

            DNLapaDati FindFirst(List<DNLapaDati> list, DateTime pdt1, DateTime pdt2)
            {
                var data = list
                    .Where(x => x.Dt1 <= pdt2 && x.Dt2 >= pdt1)
                    .FirstOrDefault();
                return data;
            }
            
            List<DNLapaDati> FindAll(List<DNLapaDati> list, DateTime pdt1, DateTime pdt2)
            {
                return list
                    .Where(x => x.Dt1 <= pdt2 && x.Dt2 >= pdt1)
                    .ToList();
            }

            for (int i = 0; i <= dates1.Count - 2; i++)
            {
                var adt1 = dates1[i];
                var adt2 = dates1[i + 1].AddDays(-1);
                var f_db = FindFirst(data_db, adt1, adt2);
                var f_eds = FindFirst(data_eds, adt1, adt2);
                if (f_db == null && f_eds == null) continue;
                if (f_db != null && f_eds != null && f_db.Veids == f_eds.Veids) continue;
                var list_data = new List<DNLapaImportData>();
                if(f_db != null)
                {
                    var fs_eds = FindAll(data_eds, f_db.Dt1, f_db.Dt2);
                    if(fs_eds.Count > 0)
                    {
                        foreach (var v_eds in fs_eds)
                        {
                            var data1 = new DNLapaImportData()
                            {
                                DB_Dt1 = f_db.Dt1,
                                DB_Dt2 = f_db.Dt2,
                                DB_Veids = f_db.Veids,
                                EDS_Dt1 = v_eds.Dt1,
                                EDS_Dt2 = v_eds.Dt2,
                                EDS_Veids = v_eds.Veids
                            };
                            list_data.Add(data1);
                        }
                    }
                    else
                    {
                        var data1 = new DNLapaImportData()
                        {
                            DB_Dt1 = f_db.Dt1,
                            DB_Dt2 = f_db.Dt2,
                            DB_Veids = f_db.Veids
                        };
                        list_data.Add(data1);
                    }
                }
                if (f_eds != null)
                {
                    var fs_db = FindAll(data_db, f_eds.Dt1, f_eds.Dt2);
                    if (fs_db.Count > 0)
                    {
                        foreach (var v_db in fs_db)
                        {
                            var data1 = new DNLapaImportData()
                            {
                                DB_Dt1 = v_db.Dt1,
                                DB_Dt2 = v_db.Dt2,
                                DB_Veids = v_db.Veids,
                                EDS_Dt1 = f_eds.Dt1,
                                EDS_Dt2 = f_eds.Dt2,
                                EDS_Veids = f_eds.Veids
                            };
                            list_data.Add(data1);
                        }
                    }
                    else
                    {
                        var data1 = new DNLapaImportData()
                        {
                            EDS_Dt1 = f_eds.Dt1,
                            EDS_Dt2 = f_eds.Dt2,
                            EDS_Veids = f_eds.Veids
                        };
                        list_data.Add(data1);
                    }
                }
                foreach (var data1 in list_data)
                {
                    var f_m = ret
                        .Where(x => x.EqualsA(data1))
                        .FirstOrDefault();
                    if (f_m == null)
                        ret.Add(data1);
                }
            }
            return ret;
        }

        public List<DNLapaImportData> GetChanges(List<DNLapaDati> data_db, 
            List<DNLapaDati> data_eds)
        {
            var ret = new List<DNLapaImportData>();
            foreach (var lapa_eds in data_eds)
            {
                if (lapa_eds.Veids.IsNOE()) continue;
                var ret1 = new DNLapaImportData()
                {
                    EDS_Dt1 = lapa_eds.Dt1,
                    EDS_Dt2 = lapa_eds.Dt2,
                    EDS_Veids = lapa_eds.Veids
                };
                var lapas_db = data_db
                    .Where(x => x.Dt1 <= lapa_eds.Dt2 && x.Dt2 >= lapa_eds.Dt1)
                    .ToList();
                if (lapas_db.Count == 0)
                {
                    var lapa_db1 = data_db
                        .Where(x => x.Dt2.AddDays(1) == lapa_eds.Dt1 &&
                            x.Veids == lapa_eds.Veids)
                        .FirstOrDefault();
                    if (lapa_db1 == null)
                    {
                        ret1.DNLapaImportType = EDNLapaImportType.AddNew;
                        ret.Add(ret1);
                        continue;
                    }
                    ret1.IDEV = lapa_db1.IDEV;
                    ret1.DB_Dt1 = lapa_db1.Dt1;
                    ret1.DB_Dt2 = lapa_db1.Dt2;
                    ret1.DB_Veids = lapa_db1.Veids;
                    ret1.DNLapaImportType = EDNLapaImportType.SetEndDate;
                    ret.Add(ret1);
                    continue;
                }
                var lapa_last = lapas_db.Last();
                if(lapa_last.Dt2 < lapa_eds.Dt2 && 
                    lapa_last.Veids == lapa_eds.Veids)
                {
                    ret1.IDEV = lapa_last.IDEV;
                    ret1.DB_Dt1 = lapa_last.Dt1;
                    ret1.DB_Dt2 = lapa_last.Dt2;
                    ret1.DB_Veids = lapa_last.Veids;
                    ret1.DNLapaImportType = EDNLapaImportType.SetEndDate;
                    ret.Add(ret1);
                }
            }
            return ret;
        }


        public static NM_dn_dnl LoadData(string filename)
        {
            string xml = File.ReadAllText(filename);
            return Deserialize(xml);
        }

        public string GetResults(NM_dn_dnl dnlapas, 
            DateTime dt1, DateTime dt2,
            out List<string> missingnames,
            out List<DNLapaImportData> fulllist,
            out List<DNLapaImportData> changes,
            out List<DNLapaImportData> nomatch)
        {
            missingnames = new List<string>();
            fulllist = new List<DNLapaImportData>();
            changes = new List<DNLapaImportData>();
            nomatch = new List<DNLapaImportData>();
            EdsDNLapas = dnlapas;
            if (dnlapas == null) return "Neizdevās nolasīt pārskata xml failu";
            var dt3 = DateTime.Today.AddDays(-1);
            var edt1 = dnlapas.pamatdati.periods_no;
            var edt2 = dnlapas.pamatdati.periods_lidzSpecified ?
                dnlapas.pamatdati.periods_lidz :
                dt3;
            if (edt1 > dt1 || edt2 < dt2) return "EDS pārskata periods neatbilst pieprasītajam.";
            
            MatchPersonLists(dnlapas, out var dict_pr, out missingnames);
            var gr_lapas = dict_pr
                .Where(x => x.Key.CertificateStatus.StatusText == "Atvērta" ||
                    x.Key.CertificateStatus.StatusText == "Slēgta")
                .GroupBy(x => x.Value);

            foreach (var person_lapas in gr_lapas)
            {
                var drpr = person_lapas.Key;
                var arr_lapas = person_lapas
                    .Select(x => x.Key)
                    .OrderBy(x => x.PeriodDates.StartDate)
                    .ToArray();
                var data_eds = GetDNLFromEds(arr_lapas, dt1, dt2, dt3);
                var data_edsA = GetDNLFromEdsA(arr_lapas, dt1, dt2, dt3);

                foreach (var val in data_edsA)
                {
                    var rval = new DNLapaImportData()
                    {
                        EDS_Dt1 = val.Dt1,
                        EDS_Dt2 = val.Dt2,
                        EDS_Veids = val.Veids,
                        EDS_Status = val.Status
                    };
                    if (drpr != null)
                    {
                        rval.IDP = drpr.ID;
                        rval.Name = drpr.YNAME;
                        rval.PersonsCode = drpr.PK;
                    }
                    else
                    {
                        var f_lapa = arr_lapas.First();
                        var name = GetName(f_lapa);
                        var pk = GetPK(f_lapa);
                        rval.Name = name;
                        rval.PersonsCode = pk;
                    }
                    fulllist.Add(rval);
                }
                
                if (drpr == null) continue;

                var data_db = GetDNLFromDB(drpr, dt1, dt2);
                var data_changes = GetChanges(data_db, data_eds);
                var data_nomatch = MergeData(data_db, data_eds, dt1, dt2);
                foreach (var val in data_changes)
                {
                    val.IDP = drpr.ID;
                    val.Name = drpr.YNAME;
                    val.PersonsCode = drpr.PK;
                }
                foreach (var val in data_nomatch)
                {
                    val.IDP = drpr.ID;
                    val.Name = drpr.YNAME;
                    val.PersonsCode = drpr.PK;
                }
                changes.AddRange(data_changes);
                nomatch.AddRange(data_nomatch);
            }
            return "OK";
        }
    }

    public class DNLapaDati
    {
        public DateTime Dt1 { get; set; } = DateTime.MinValue;
        public DateTime Dt2 { get; set; } = DateTime.MinValue;
        public int IDEV { get; set; } = -1;
        public string Veids { get; set; } = null; // A vai B
        public string Status { get; set; } = null;
    }

    public enum EDNLapaImportType { Ok, AddNew, SetEndDate, Warn}

    public class DNLapaImportData
    {
        public int IDP { get; set; } = -1;
        public string Name { get; set; } = null;
        public string PersonsCode { get; set; } = null;
        public int IDEV { get; set; } = -1;
        public DateTime? DB_Dt1 { get; set; } = null;
        public DateTime? DB_Dt2 { get; set; } = null;
        public DateTime? EDS_Dt1 { get; set; } = null;
        public DateTime? EDS_Dt2 { get; set; } = null;
        public string DB_Veids { get; set; } = null;
        public string EDS_Veids { get; set; } = null;
        public string EDS_Status { get; set; } = null;

        public EDNLapaImportType DNLapaImportType { get; set; } = EDNLapaImportType.Ok;
        public string DNLapaImportTypeText => TypeTexts[(int)DNLapaImportType];

        static string[] TypeTexts = { null, "izveidot jaunu", "mainīt beigu datumu", "?" };

        public bool EqualsA(DNLapaImportData data)
        {
            if (DB_Dt1 != data.DB_Dt1) return false;
            if (DB_Dt2 != data.DB_Dt2) return false;
            if (DB_Veids != data.DB_Veids) return false;
            if (EDS_Dt1 != data.EDS_Dt1) return false;
            if (EDS_Dt2 != data.EDS_Dt2) return false;
            if (EDS_Veids != data.EDS_Veids) return false;
            return true;
        }
    }
}
