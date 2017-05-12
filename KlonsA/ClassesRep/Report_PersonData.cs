using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using KlonsA.DataSets;
using KlonsA.Forms;
using KlonsLIB.Misc;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using Microsoft.Reporting.WinForms;

namespace KlonsA.Classes
{
    public class Report_PersonData
    {
        public static KlonsData MyData => KlonsData.St;

        public RepRowPosition[] rrs_positions = null;
        public RepRowEvent[] rrs_events = null;

        public void ShowReport(int idp, DateTime dt)
        {
            var table_persons = MyData.DataSetKlons.PERSONS;
            var table_persons_r = MyData.DataSetKlons.PERSONS_R;
            var table_positions = MyData.DataSetKlons.POSITIONS;
            var table_positions_r = MyData.DataSetKlons.POSITIONS_R;

            var dr_person = table_persons.FindByID(idp);
            var drs_person = new[] { dr_person };
            var drs_persons_r = dr_person.GetPERSONS_RRows()
                .OrderBy(d => d.EDIT_DATE)
                .ToArray();

            var drs_positions = dr_person.GetPOSITIONSRows();

            var rr_person = new RepRowPerson();
            var rrs_person = new[] { rr_person };
            rr_person.SetFromPersonsDataRow(dr_person);
            rr_person.SetFromPersonsDataRow(drs_persons_r[drs_persons_r.Length - 1]);
            rr_person.SetCurrentRates(dt);

            rrs_positions = new RepRowPosition[drs_positions.Length];

            for (int i = 0; i < drs_positions.Length; i++)
            {
                var dr_positions_r = drs_positions[i].GetPOSITIONS_RRows()
                    .WithMaxOrDefault(d => d.EDIT_DATE);

                var rrp = new RepRowPosition();
                rrs_positions[i] = rrp;
                rrp.Nr = i;
                rrp.SetFromPositionDataRow(drs_positions[i]);
                rrp.SetFromPositionDataRow(dr_positions_r);
                rrp.GetRatesHistory();
            }

            var rep_status_hist = rr_person.GetStatusChangeRep();
            var rep_rates_hist = rr_person.GetPersonRatesChangeRep(dt);

            var drs_events = dr_person.GetEVENTSRows()
                .OrderBy(d => d.DATE1)
                .ThenBy(d => d.IDN)
                .ToArray();

            rrs_events = new RepRowEvent[drs_events.Length];
            for(int i= 0; i < drs_events.Length; i++)
            {
                var rre = new RepRowEvent();
                rrs_events[i] = rre;
                rre.SetFromDataRow(drs_events[i]);
            }

            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportA_Kartite_1";
            rd.Sources["DSPerson"] = rrs_person;
            rd.Sources["DSPositions"] = rrs_positions;
            rd.Sources["DSEvents"] = rrs_events;
            rd.AddReportParameters(new string[]
                {
                    "CompanyName", MyData.Params.CompNameX,
                    "RDate", Utils.DateToString(DateTime.Today),
                    "RShowStatusRep", rep_status_hist.Length > 0 ? "yes" : "no",
                    "RShowRatesRep", rep_rates_hist.Length > 0 ? "yes" : "no"
                });
            rd.OnSubreport = (e) =>
            {
                string fnm = ReportHelper.ReportNameFromPath(e.ReportPath);
                if (fnm == "ReportA_Kartite_1a")
                {
                    e.DataSources.Add(new ReportDataSource("DataSet1", rep_status_hist));
                }
                else if (fnm == "ReportA_Kartite_1b")
                {
                    e.DataSources.Add(new ReportDataSource("DataSet1", rep_rates_hist));
                }
                else if (fnm == "ReportA_Kartite_1c")
                {
                    int nr = int.Parse(e.Parameters["RPosNr"].Values[0]);
                    var rr = rrs_positions[nr].RatesHistory;
                    e.DataSources.Add(new ReportDataSource("DSPosHist", rr));
                }
            };
            MyData.MyMainForm.ShowReport(rd);
        }

    }

    public class RepRowPersonStatusChange
    {
        public DateTime Date { get; set; }
        public string Descr { get; set; } = null;
    }

    public class RepRowPersonRatesChange
    {
        public DateTime Date { get; set; }
        public string Descr { get; set; } = null;
        public decimal R1 { get; set; } = 0.0M;
        public decimal R2 { get; set; } = 0.0M;
    }

    public class RepRowPositionChange
    {
        public DateTime Date { get; set; }
        public string Descr { get; set; } = null;
        public string R1 { get; set; } = null;
        public string R2 { get; set; } = null;
    }

    public class RepRowPerson
    {
        public static KlonsData MyData => KlonsData.St;

        public int ID { get; set; } = 0;
        public int IDP { get; set; } = 0;
        public DateTime EDIT_DATE { get; set; } = DateTime.MinValue;
        public string FNAME { get; set; } = null;
        public string LNAME { get; set; } = null;
        public Int16 GENDER { get; set; } = 0;
        public string PERSON_CODE { get; set; } = null;
        public DateTime BIRTH_DATE { get; set; } = DateTime.MinValue;
        public string ADDRESS { get; set; } = null;
        public string CITY { get; set; } = null;
        public string STATE { get; set; } = null;
        public string COUNTRY { get; set; } = null;
        public string POSTAL_CODE { get; set; } = null;
        public string TERRITORIAL_CODE { get; set; } = null;
        public string PHONE { get; set; } = null;
        public string EMAIL { get; set; } = null;
        public string COMMENTS { get; set; } = null;
        public int? BANK_ID { get; set; } = null;
        public string BANK_SID { get; set; } = null;
        public string BANK_NAME { get; set; } = null;
        public string BANK_ACC { get; set; } = null;
        public string PASSPORT_NO { get; set; } = null;
        public string PASSPORT_ISSUER { get; set; } = null;
        public DateTime? PASSPORT_DATE { get; set; } = null;
        public string TAXDOC_SERIAL { get; set; } = null;
        public string TAXDOC_NO { get; set; } = null;
        public string TAXDOC_ISSUER { get; set; } = null;
        public string TAXREG_NO { get; set; } = null;
        public Int16 INVALID { get; set; } = 0;
        public Int16 PENSIONER { get; set; } = 0;
        public Int16 PRISONER { get; set; } = 0;
        public Int16 REPRES { get; set; } = 0;
        public Int16 PRET { get; set; } = 0;
        public Int16 APGAD_SK { get; set; } = 0;
        public Int16 PRISONER_SP { get; set; } = 0;
        public Int16 NOT_OSA { get; set; } = 0;

        public string STATUS
        {
            get
            {
                var s = "";
                if (INVALID > 0) s = "invaliditāte " + INVALID + ". grupa";
                if(PENSIONER == 1)
                {
                    if (s != "") s += ", ";
                    s += "pensionārs";
                }
                if (REPRES == 1)
                {
                    if (s != "") s += ", ";
                    s += "represētā persona";
                }
                if (PRET == 1)
                {
                    if (s != "") s += ", ";
                    s += "pretošanās kustības dalībnieks";
                }
                if (PRISONER == 1)
                {
                    if (s != "") s += ", ";
                    s += "cietumnieks";
                }
                return s;
            }
        }


        public decimal ExUntaxedMinimum { get; set; } = 0.0M;
        public decimal ExDependants { get; set; } = 0.0M;
        public decimal ExRetaliation { get; set; } = 0.0M;
        public decimal ExInvalidity { get; set; } = 0.0M;
        public decimal ExNationalMovements { get; set; } = 0.0M;
        public decimal RateDNSN { get; set; } = 0.0M;
        public decimal RateDDSN { get; set; } = 0.0M;
        public decimal RateIIN { get; set; } = 0.0M;


        public decimal PAY0 { get; set; } = 0.0M;
        public decimal IIN0 { get; set; } = 0.0M;
        public decimal ADVANCE { get; set; } = 0.0M;
        public Single VACATION_DAYS { get; set; } = 0;

        public void SetFromPersonsDataRow(KlonsADataSet.PERSONSRow dr)
        {
            ID = dr.ID;
            FNAME = dr.FNAME;
            LNAME = dr.LNAME;
            GENDER = dr.GENDER;
            BIRTH_DATE = dr.BIRTH_DATE;
            //PERSON_CODE = dr.PK;
            ADDRESS = dr.ADDRESS;
            CITY = dr.CITY;
            STATE = dr.STATE;
            COUNTRY = dr.COUNTRY;
            POSTAL_CODE = dr.POSTAL_CODE;
            TERRITORIAL_CODE = dr.TERRITORIAL_CODE;
            PASSPORT_NO = dr.PASSPORT_NO;
            PASSPORT_ISSUER = dr.PASSPORT_ISSUER;
            PASSPORT_DATE = dr.IsPASSPORT_DATENull() ? (DateTime?)null : dr.PASSPORT_DATE;
            PHONE = dr.PHONE;
            EMAIL = dr.EMAIL;
            BANK_ID = dr.IsBANK_IDNull() ? (int?)null : dr.BANK_ID;
            if (BANK_ID != null) SetBank(BANK_ID.Value);
            BANK_ACC = dr.BANK_ACC;
            COMMENTS = dr.COMMENTS;
            PAY0 = dr.PAY0;
            IIN0 = dr.IIN0;
            ADVANCE = dr.ADVANCE;
            VACATION_DAYS = dr.VACATION_DAYS;
        }

        public void SetFromPersonsDataRow(KlonsADataSet.PERSONS_RRow dr)
        {
            ID = dr.ID;
            IDP = dr.IDP;
            EDIT_DATE = dr.EDIT_DATE;
            FNAME = dr.FNAME;
            LNAME = dr.LNAME;
            PERSON_CODE = dr.PERSON_CODE;
            TERRITORIAL_CODE = dr.TERRITORIAL_CODE;
            TAXDOC_SERIAL = dr.TAXDOC_SERIAL;
            TAXDOC_NO = dr.TAXDOC_NO;
            TAXDOC_ISSUER = dr.TAXDOC_ISSUER;
            TAXREG_NO = dr.TAXREG_NO;
            INVALID = dr.INVALID;
            PENSIONER = dr.PENSIONER;
            PRISONER = dr.PRISONER;
            REPRES = dr.REPRES;
            PRET = dr.PRET;
            APGAD_SK = dr.APGAD_SK;
            //PENSIONER_SP = dr.PENSIONER_SP;
            NOT_OSA = dr.NOT_OSA;
        }

        private void SetBank(int id)
        {
            var dr = KlonsData.St.DataSetKlons.BANKS.FindByID(id);
            if (dr == null) return;
            BANK_SID = dr.SID;
            BANK_NAME = dr.NAME;
        }

        public void SetCurrentRates(DateTime dt)
        {
            var dr_persons_r = DataTasks.GetPersonsR(IDP, dt);
            var dr_rates = DataTasks.GetRates(dt);
            if (dr_persons_r == null || dr_rates == null) return;
            var cr = new CalcRRow2();
            CalcRInfo.GetRatesForPerson(cr, dr_persons_r, dr_rates);
            CalcRInfo.GetIINDeductionsForPerson(cr, dr_persons_r, dr_rates);
            ExDependants = cr.ExDependants;
            ExInvalidity = cr.ExInvalidity;
            ExNationalMovements = cr.ExNationalMovements;
            ExRetaliation = cr.ExRetaliation;
            ExUntaxedMinimum = cr.ExUntaxedMinimum;
            //Ex2Tp = cr.Ex2Tp;
            RateDDSN = cr.RateDDSN;
            RateDNSN = cr.RateDNSN;
            RateIIN = cr.RateIIN;
        }

        public RepRowPersonStatusChange[] GetStatusChangeRep()
        {
            var rt = new List<RepRowPersonStatusChange>();
            var table_persons = MyData.DataSetKlons.PERSONS;
            var table_persons_r = MyData.DataSetKlons.PERSONS_R;

            var dr_person = table_persons.FindByID(IDP);
            var drs_persons_r = dr_person.GetPERSONS_RRows()
                .OrderBy(d => d.EDIT_DATE)
                .ToArray();
            if (drs_persons_r.Length < 2) return new RepRowPersonStatusChange[] { };
            for(int i = 1; i < drs_persons_r.Length; i++)
            {
                var dr_cur = drs_persons_r[i];
                var dr_prev = drs_persons_r[i - 1];
                string s = "";
                if (dr_cur.TAXDOC_NO != dr_prev.TAXDOC_NO)
                {
                    if (s != "") s += "\n";
                    if (string.IsNullOrEmpty(dr_cur.TAXDOC_NO))
                        s += "izņemta nodokļu grāmatiņa";
                    else
                        s += "iesniegta nodokļu grāmatiņa";
                }
                if (dr_cur.APGAD_SK != dr_prev.APGAD_SK)
                {
                    if (s != "") s += "\n";
                    s += string.Format("apgādājamo skaita izmaiņa no {0} uz {1}",
                        dr_prev.APGAD_SK, dr_cur.APGAD_SK);
                }
                if (dr_cur.PENSIONER != dr_prev.PENSIONER)
                {
                    if (s != "") s += "\n";
                    s += "iegūts pensionāra status";
                }
                if (dr_cur.INVALID != dr_prev.INVALID)
                {
                    if (s != "") s += "\n";
                    if(dr_cur.INVALID == 0)
                        s += "zaudēta invaliditāte";
                    else
                        s += string.Format("piešķirta invaliditātes {0}. grupa", dr_cur.INVALID);
                }
                if (dr_cur.REPRES != dr_prev.REPRES)
                {
                    if (s != "") s += "\n";
                    if (dr_cur.REPRES == 0)
                        s += "zaudēta represētas personas statuss";
                    else
                        s += "piešķirts represētas personas statuss";
                }
                if (dr_cur.PRET != dr_prev.PRET)
                {
                    if (s != "") s += "\n";
                    if (dr_cur.PRET == 0)
                        s += "zaudēta nacionālās pretošanās kustības dalībnieka statuss";
                    else
                        s += "piešķirts nacionālās pretošanās kustības dalībnieka statuss";
                }
                if (dr_cur.PRISONER != dr_prev.PRISONER)
                {
                    if (s != "") s += "\n";
                    if (dr_cur.PRISONER == 0)
                        s += "zaudēta cietumnieka statuss";
                    else
                        s += "piešķirts cietumnieka statuss";
                }
                if(s != "")
                {
                    var chr = new RepRowPersonStatusChange();
                    chr.Date = dr_cur.EDIT_DATE;
                    chr.Descr = s;
                    rt.Add(chr);
                }
            }
            return rt.ToArray();
        }

        public RepRowPersonRatesChange[] GetPersonRatesChangeRep(DateTime dte)
        {
            var cr = GetDatesAndRates(dte);
            if (cr == null || cr.Count < 2) return new RepRowPersonRatesChange[0];
            var list_cr = new List<RepRowPersonRatesChange>();
            for (int i = 1; i < cr.Count; i++)
            {
                var cr_prev = cr[i - 1];
                var cr_cur = cr[i];
                if (cr_prev.Value.RateIIN != cr_cur.Value.RateIIN)
                {
                    var rr = new RepRowPersonRatesChange()
                    {
                        Date = cr_cur.Key,
                        Descr = "IIN likme",
                        R1 = cr_prev.Value.RateIIN,
                        R2 = cr_cur.Value.RateIIN
                    };
                    list_cr.Add(rr);
                }
                if (cr_prev.Value.RateDDSN != cr_cur.Value.RateDDSN)
                {
                    var rr = new RepRowPersonRatesChange()
                    {
                        Date = cr_cur.Key,
                        Descr = "SAI d.d. likme",
                        R1 = cr_prev.Value.RateDDSN,
                        R2 = cr_cur.Value.RateDDSN
                    };
                    list_cr.Add(rr);
                }
                if (cr_prev.Value.RateDNSN != cr_cur.Value.RateDNSN)
                {
                    var rr = new RepRowPersonRatesChange()
                    {
                        Date = cr_cur.Key,
                        Descr = "SAI d.ņ. likme",
                        R1 = cr_prev.Value.RateDNSN,
                        R2 = cr_cur.Value.RateDNSN
                    };
                    list_cr.Add(rr);
                }
                if (cr_prev.Value.ExUntaxedMinimum != cr_cur.Value.ExUntaxedMinimum)
                {
                    var rr = new RepRowPersonRatesChange()
                    {
                        Date = cr_cur.Key,
                        Descr = "Neapliekamais min.",
                        R1 = cr_prev.Value.ExUntaxedMinimum,
                        R2 = cr_cur.Value.ExUntaxedMinimum
                    };
                    list_cr.Add(rr);
                }
                if (cr_prev.Value.ExDependants != cr_cur.Value.ExDependants)
                {
                    var rr = new RepRowPersonRatesChange()
                    {
                        Date = cr_cur.Key,
                        Descr = "Atviegl. par apgādājamajiem",
                        R1 = cr_prev.Value.ExDependants,
                        R2 = cr_cur.Value.ExDependants
                    };
                    list_cr.Add(rr);
                }
                if (cr_prev.Value.ExInvalidity != cr_cur.Value.ExInvalidity)
                {
                    var rr = new RepRowPersonRatesChange()
                    {
                        Date = cr_cur.Key,
                        Descr = "Atviegl. par invaliditāti",
                        R1 = cr_prev.Value.ExInvalidity,
                        R2 = cr_cur.Value.ExInvalidity
                    };
                    list_cr.Add(rr);
                }
                if (cr_prev.Value.ExRetaliation != cr_cur.Value.ExRetaliation)
                {
                    var rr = new RepRowPersonRatesChange()
                    {
                        Date = cr_cur.Key,
                        Descr = "Atviegl. rahabilitētajai personai",
                        R1 = cr_prev.Value.ExRetaliation,
                        R2 = cr_cur.Value.ExRetaliation
                    };
                    list_cr.Add(rr);
                }
                if (cr_prev.Value.ExNationalMovements != cr_cur.Value.ExNationalMovements)
                {
                    var rr = new RepRowPersonRatesChange()
                    {
                        Date = cr_cur.Key,
                        Descr = "Atviegl. nacionālās pretošanās kustības dalībniekam",
                        R1 = cr_prev.Value.ExNationalMovements,
                        R2 = cr_cur.Value.ExNationalMovements
                    };
                    list_cr.Add(rr);
                }
            }

            return list_cr.ToArray();
        }

        public List<KeyValuePair<DateTime, CalcRRow2>> GetDatesAndRates(DateTime dte)
        {
            var table_persons = MyData.DataSetKlons.PERSONS;
            var table_persons_r = MyData.DataSetKlons.PERSONS_R;
            var table_events = MyData.DataSetKlons.EVENTS;
            var table_rates = MyData.DataSetKlons.RATES;

            var dr_person = table_persons.FindByID(IDP);
            var drs_persons_r = dr_person.GetPERSONS_RRows()
                .OrderBy(d => d.EDIT_DATE)
                .ToArray();

            var drs_events = dr_person.GetEVENTSRows();
            
            var drsn_hirefire = drs_events
                .Where(d =>
                    Utils.IN(d.IDN, (int)EEventId.Pieņemts, (int)EEventId.Atlaists))
                .OrderBy(d => d.DATE1)
                .ToArray();

            if (drsn_hirefire.Length == 0)
            {
                return null;
            }

            DateTime dt1, dt2;

            var dd = new DateList();
            for (int i = 0; i < drsn_hirefire.Length; i += 2)
            {
                dt1 = drsn_hirefire[i].DATE1;
                dt2 = i + 1 == drsn_hirefire.Length ?
                    dte :
                    drsn_hirefire[i].DATE1;
                dd.List.Add(new DatesFromTo(dt1, dt2));
            }

            dt1 = dd.List[0].DateFrom;
            dt2 = dd.List[dd.List.Count - 1].DateTo;

            var drsn_hire = drsn_hirefire
                .Where(d=>
                    d.IDN == (int)EEventId.Pieņemts)
                .OrderBy(d => d.DATE1)
                .ToArray();

            var drs_rates_ordered = table_rates
                .WhereX(d =>
                    d.ONDATE <= dte)
                .OrderBy(d => d.ONDATE)
                .ToArray();

            var drs_rates = drs_rates_ordered
                .Where(d =>
                    dd.HasDate(d.ONDATE))
                .ToArray();

            var l_dates = new List<DateTime>();
            l_dates.AddRange(drsn_hire.Select(d => d.DATE1));
            l_dates.AddRange(drs_persons_r.Select(d => d.EDIT_DATE));
            l_dates.AddRange(drs_rates.Select(d => d.ONDATE));
            l_dates.Sort();
            var a_dates = l_dates.DistinctForOrdered().ToArray();

            var list_ret = new List<KeyValuePair<DateTime, CalcRRow2>>();

            foreach (var dti in a_dates)
            {
                var dr_pr = drs_persons_r
                    .Where(d => d.EDIT_DATE <= dti)
                    .LastOrDefault();
                var dr_rt = drs_rates_ordered
                    .Where(d => d.ONDATE <= dti)
                    .LastOrDefault();
                if (dr_pr == null || dr_rt == null) continue;
                var cr = new CalcRRow2();
                CalcRInfo.GetRatesForPerson(cr, dr_pr, dr_rt);
                CalcRInfo.GetIINDeductionsForPerson(cr, dr_pr, dr_rt);
                if (list_ret.Count > 0 && list_ret[list_ret.Count - 1].Value.Equals(cr)) continue;
                list_ret.Add(new KeyValuePair<DateTime, CalcRRow2>(dti, cr));
            }

            return list_ret;
        }

    }


    public class RepRowPosition
    {
        public static KlonsData MyData => KlonsData.St;

        public int Nr { get; set; } = 0;
        public bool HasHist { get; set; } = false;

        public int ID { get; set; } = 0;
        public int IDR { get; set; } = 0;
        public int IDP { get; set; } = 0;
        public string IDDEP { get; set; } = null;
        public string DEP { get; set; } = null;
        public string TITLE { get; set; } = null;
        public string TITLE_DATIVE { get; set; } = null;
        public string TITLE_ACCUSATIVE { get; set; } = null;
        public Int16 SALARY_TYPE { get; set; } = 0;
        public string SALARY_TYPE_S => GetSalaryTypeStr(SALARY_TYPE);
        
        public Int16 SIXDAYWEEK { get; set; } = 0;
        public int NORMAL_DAY_HOURS { get; set; } = 0;
        public int NORMAL_WEEK_HOURS { get; set; } = 0;
        public decimal RATE { get; set; } = 0.0M;
        public decimal RATE_NIGHT { get; set; } = 0.0M;
        public Int16 RATE_NIGHT_TYPE { get; set; } = 0;
        public decimal RATE_OVERTIME { get; set; } = 0.0M;
        public Int16 RATE_OVERTIME_TYPE { get; set; } = 0;
        public decimal RATE_HOLIDAY { get; set; } = 0.0M;
        public Int16 RATE_HOLIDAY_TYPE { get; set; } = 0;
        public decimal RATE_HOLIDAY_NIGHT { get; set; } = 0.0M;
        public Int16 RATE_HOLIDAY_NIGHT_TYPE { get; set; } = 0;
        public decimal RATE_HOLIDAY_OVERTIME { get; set; } = 0.0M;
        public Int16 RATE_HOLIDAY_OVERTIME_TYPE { get; set; } = 0;

        public string RATE_NIGHT_S => GetBonusStr(RATE_NIGHT, RATE_NIGHT_TYPE);
        public string RATE_OVERTIME_S => GetBonusStr(RATE_OVERTIME, RATE_OVERTIME_TYPE);
        public string RATE_HOLIDAY_S => GetBonusStr(RATE_HOLIDAY, RATE_HOLIDAY_TYPE);
        public string RATE_HOLIDAY_NIGHT_S => GetBonusStr(RATE_HOLIDAY_NIGHT, RATE_HOLIDAY_NIGHT_TYPE);
        public string RATE_HOLIDAY_OVERTIME_S => GetBonusStr(RATE_HOLIDAY_OVERTIME, RATE_HOLIDAY_OVERTIME_TYPE);

        public decimal ADVAMCE { get; set; } = 0.0M;
        public string OCCUPATION_CODE { get; set; } = null;
        public string OCCUPATION_CODE_S { get; set; } = null;
        public Int16 USED { get; set; } = 1;
        public DateTime EDIT_DATE { get; set; } = DateTime.MinValue;
        public decimal PAY0 { get; set; } = 0.0M;
        public decimal IIN0 { get; set; } = 0.0M;
        public decimal ADVANCE { get; set; } = 0.0M;
        
        public List<RepRowPositionChange> RatesHistory = null;

        public string GetSalaryTypeStr(Int16 st)
        {
            switch (st)
            {
                case 0: return "mēneša";
                case 1: return "stundas";
                case 2: return "dienas";
                case 3: return "gamaldarba";
            }
            return "?";
        }

        public string GetBonusStr(decimal d, Int16 tp)
        {
            return d.ToString("N2") + (tp == 0 ? "%" : "€");
        }

        public void SetFromPositionDataRow(KlonsADataSet.POSITIONSRow dr)
        {
            ID = dr.ID;
            IDP = dr.IDP;
            IDDEP = dr.IDDEP;
            TITLE = dr.TITLE;
            PAY0 = dr.PAY0;
            IIN0 = dr.IIN0;
            ADVANCE = dr.ADVANCE;
            USED = dr.USED;
        }

        public void SetFromPositionDataRow(KlonsADataSet.POSITIONS_RRow dr)
        {
            IDR = dr.ID;
            IDDEP = dr.IDDEP;
            if (IDDEP != null)
                DEP = MyData.DataSetKlons.DEPARTMENTS.FindByID(IDDEP)?.DESCR;
            TITLE = dr.TITLE;
            TITLE_DATIVE = dr.TITLE_DATIVE;
            TITLE_ACCUSATIVE = dr.TITLE_ACCUSATIVE;
            SALARY_TYPE = dr.SALARY_TYPE;
            SIXDAYWEEK = dr.SIXDAYWEEK;
            NORMAL_DAY_HOURS = dr.NORMAL_DAY_HOURS;
            NORMAL_WEEK_HOURS = dr.NORMAL_WEEK_HOURS;
            RATE = dr.RATE;
            RATE_NIGHT = dr.RATE_NIGHT;
            RATE_NIGHT_TYPE = dr.RATE_NIGHT_TYPE;
            RATE_OVERTIME = dr.RATE_OVERTIME;
            RATE_OVERTIME_TYPE = dr.RATE_OVERTIME_TYPE;
            RATE_HOLIDAY = dr.RATE_HOLIDAY;
            RATE_HOLIDAY_TYPE = dr.RATE_HOLIDAY_TYPE;
            RATE_HOLIDAY_NIGHT = dr.RATE_HOLIDAY_NIGHT;
            RATE_HOLIDAY_NIGHT_TYPE = dr.RATE_HOLIDAY_NIGHT_TYPE;
            RATE_HOLIDAY_OVERTIME = dr.RATE_HOLIDAY_OVERTIME;
            RATE_HOLIDAY_OVERTIME_TYPE = dr.RATE_HOLIDAY_OVERTIME_TYPE;
            ADVAMCE = dr.ADVAMCE;
            OCCUPATION_CODE = dr.OCCUPATION_CODE;
            if (OCCUPATION_CODE != null)
                OCCUPATION_CODE_S = MyData.DataSetKlons.PROFESSIONS.FindByID(OCCUPATION_CODE)?.DESCR;
            USED = dr.USED;
            EDIT_DATE = dr.EDIT_DATE;
            
        }

        public void GetRatesHistory()
        {
            RatesHistory = new List<RepRowPositionChange>();
            var dr_pos = MyData.DataSetKlons.POSITIONS.FindByID(ID);
            if (dr_pos == null) return;
            var drs_pos_r = dr_pos.GetPOSITIONS_RRows()
                .OrderBy(d => d.EDIT_DATE)
                .ToArray();
            if (drs_pos_r.Length < 2) return;
            for(int i = 1; i < drs_pos_r.Length; i++)
            {
                var dr_cur = drs_pos_r[i];
                var dr_prev = drs_pos_r[i - 1];
                if(dr_prev.SALARY_TYPE != dr_cur.SALARY_TYPE)
                {
                    var rc = new RepRowPositionChange()
                    {
                        Date = dr_cur.EDIT_DATE,
                        Descr = "likmes veids",
                        R1 = GetSalaryTypeStr(dr_prev.SALARY_TYPE),
                        R2 = GetSalaryTypeStr(dr_cur.SALARY_TYPE)
                    };
                    RatesHistory.Add(rc);
                }
                if (dr_prev.NORMAL_DAY_HOURS != dr_cur.NORMAL_DAY_HOURS)
                {
                    var rc = new RepRowPositionChange()
                    {
                        Date = dr_cur.EDIT_DATE,
                        Descr = "stundas dienā",
                        R1 = dr_prev.NORMAL_DAY_HOURS.ToString(),
                        R2 = dr_cur.NORMAL_DAY_HOURS.ToString()
                    };
                    RatesHistory.Add(rc);
                }
                if (dr_prev.NORMAL_WEEK_HOURS != dr_cur.NORMAL_WEEK_HOURS)
                {
                    var rc = new RepRowPositionChange()
                    {
                        Date = dr_cur.EDIT_DATE,
                        Descr = "stundas nedēļā",
                        R1 = dr_prev.NORMAL_WEEK_HOURS.ToString(),
                        R2 = dr_cur.NORMAL_WEEK_HOURS.ToString()
                    };
                    RatesHistory.Add(rc);
                }
                if (dr_prev.RATE != dr_cur.RATE)
                {
                    var rc = new RepRowPositionChange()
                    {
                        Date = dr_cur.EDIT_DATE,
                        Descr = "pamatlikme",
                        R1 = dr_prev.RATE.ToString("N2"),
                        R2 = dr_cur.RATE.ToString("N2")
                    };
                    RatesHistory.Add(rc);
                }
                if (dr_prev.RATE_NIGHT != dr_cur.RATE_NIGHT)
                {
                    var rc = new RepRowPositionChange()
                    {
                        Date = dr_cur.EDIT_DATE,
                        Descr = "piem. par nakts darbu",
                        R1 = GetBonusStr(dr_prev.RATE_NIGHT, dr_prev.RATE_NIGHT_TYPE),
                        R2 = GetBonusStr(dr_cur.RATE_NIGHT, dr_cur.RATE_NIGHT_TYPE)
                    };
                    RatesHistory.Add(rc);
                }
                if (dr_prev.RATE_OVERTIME != dr_cur.RATE_OVERTIME)
                {
                    var rc = new RepRowPositionChange()
                    {
                        Date = dr_cur.EDIT_DATE,
                        Descr = "piem. par virsstundām",
                        R1 = GetBonusStr(dr_prev.RATE_OVERTIME, dr_prev.RATE_OVERTIME_TYPE),
                        R2 = GetBonusStr(dr_cur.RATE_OVERTIME, dr_cur.RATE_OVERTIME_TYPE)
                    };
                    RatesHistory.Add(rc);
                }
                if (dr_prev.RATE_HOLIDAY != dr_cur.RATE_HOLIDAY)
                {
                    var rc = new RepRowPositionChange()
                    {
                        Date = dr_cur.EDIT_DATE,
                        Descr = "piem. par darbu svētku d.",
                        R1 = GetBonusStr(dr_prev.RATE_HOLIDAY, dr_prev.RATE_HOLIDAY_TYPE),
                        R2 = GetBonusStr(dr_cur.RATE_HOLIDAY, dr_cur.RATE_HOLIDAY_TYPE)
                    };
                    RatesHistory.Add(rc);
                }
                if (dr_prev.RATE_HOLIDAY_NIGHT != dr_cur.RATE_HOLIDAY_NIGHT)
                {
                    var rc = new RepRowPositionChange()
                    {
                        Date = dr_cur.EDIT_DATE,
                        Descr = "piem. par darbu naktī svētku d.",
                        R1 = GetBonusStr(dr_prev.RATE_HOLIDAY_NIGHT, dr_prev.RATE_HOLIDAY_NIGHT_TYPE),
                        R2 = GetBonusStr(dr_cur.RATE_HOLIDAY_NIGHT, dr_cur.RATE_HOLIDAY_NIGHT_TYPE)
                    };
                    RatesHistory.Add(rc);
                }
                if (dr_prev.RATE_HOLIDAY_OVERTIME != dr_cur.RATE_HOLIDAY_OVERTIME)
                {
                    var rc = new RepRowPositionChange()
                    {
                        Date = dr_cur.EDIT_DATE,
                        Descr = "piem. par virsst. svētku d.",
                        R1 = GetBonusStr(dr_prev.RATE_HOLIDAY_OVERTIME, dr_prev.RATE_HOLIDAY_OVERTIME_TYPE),
                        R2 = GetBonusStr(dr_cur.RATE_HOLIDAY_OVERTIME, dr_cur.RATE_HOLIDAY_OVERTIME_TYPE)
                    };
                    RatesHistory.Add(rc);
                }
                HasHist = RatesHistory.Count > 0;
            }
        }

    }

    public class RepRowEvent
    {
        public KlonsData MyData => KlonsData.St;

        public int ID { get; set; } = 0;
        public int IDP { get; set; } = 0;
        public int? IDA { get; set; } = null;
        public int IDN { get; set; } = 0;
        public int? IDN2 { get; set; } = null;
        public string PosTitle { get; set; } = null;
        public string EventName { get; set; } = null;
        public string Event2Name { get; set; } = null;
        public DateTime DATE1 { get; set; }
        public DateTime? DATE2 { get; set; } = null;
        public DateTime? DATE3 { get; set; } = null;
        public string DESCR { get; set; } = null;
        public string DOCNR { get; set; } = null;
        public string SCODE { get; set; } = null;


        public void SetFromDataRow(KlonsADataSet.EVENTSRow dr)
        {
            ID = dr.ID;
            IDP = dr.IDP;
            IDA = dr.IsIDANull() ? (int?)null : dr.IDA;
            IDN = dr.IDN;
            IDN2 = dr.IsIDN2Null() ? (int?)null : dr.IDN2;
            DATE1 = dr.DATE1;
            DATE2 = dr.IsDATE2Null() ? (DateTime?)null : dr.DATE2;
            DATE3 = dr.IsDATE3Null() ? (DateTime?)null : dr.DATE3;
            DESCR = dr.DESCR;
            DOCNR = dr.DOCNR;
            SCODE = dr.SCODE;

            if (IDA != null)
                PosTitle = DataTasks.GetPositionTitle(IDA.Value);
            EventName = MyData.DataSetKlons.EVENT_TYPES.FindByID(IDN)?.DESCR;
            if (IDN2 != null)
                Event2Name = MyData.DataSetKlons.EVENT_TYPES.FindByID(IDN2.Value)?.DESCR;
        }

    }

}



