using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsA.DataSets.KlonsADataSetTableAdapters;
using KlonsLIB.Misc;

namespace KlonsA.Classes
{
    public enum ESalaryType
    {
        Month,
        Day,
        Hour,
        Aggregated,
        Piece
    }

    public enum EBonusRateType
    {
        Money = 0,
        Percent = 1
    }

    public enum EBonusFrom
    {
        None = 0,
        FromMonthSalary = 1,
        FromPay = 2,
        FromPayAndVacSick = 3,
        FromPayBeforeSAI = 4,
        FromPayAfterSAI = 5,
        FromPayBeforeIIN = 6,
        FromPayAfterIIN = 7
    }

    public enum EBonusType
    {
        None = 0,
        Taxed = 1,
        NoSAI = 2,
        AuthorsFees = 3,
        NotTaxed = 4,
        MinusBeforeIIN = 5,
        MinusAfterIIN = 6,
        ReverseCalc = 51,
        PfNotTaxed = 101,
        PfTaxed = 102,
        LiNotTaxed = 201,
        LiTaxed = 202,
        HiNotTaxed = 203,
        HiTaxed = 204
    }

    public enum EPlanType : short
    {
        Fixed = 0,
        Individual = 1
    }
    public enum ESalarySheetRowType : short
    {
        OnlyOne = 0,
        OneOfMany = 1,
        Total = 2
    }
    public enum ESalarySheetKind : short
    {
        Normal = 0,
        Total = 1
    }

    public enum EIINExempt2Kind : short
    {
        None = 0,
        Invalid = 1,
        RetaliatedPensioner = 2,
        Retaliated = 3,
        NationalMovementPensioner = 4,
        NationalMovement = 5
    }

    public enum EKind1 : short
    {
        PlanGroupDay = 0,
        PlanGroupaNight = 1,
        PlanIndividualDay = 2,
        PlanIndividualNight = 3,
        Fact = 4,
        FactOvertime = 5,
        FactNight = 6
    }

    public enum EEventId : int
    {
        None = 0,
        Pieņemts = 1,
        Atlaists = 2,
        Piešķirts_amats = 3,
        Atbrīvots_no_amata = 4,
        Noslēgts_uzņēmuma_līgums = 5,
        Izbeigts_uzņēmuma_līgums = 6,
        Atvaļinājums = 101,
        Bezalgas_atvaļinājums = 102,
        Apmaksāts_mācību_atvaļinājums = 103,
        Bezalgas_mācību_atvaļinājums = 104,
        Grūtniecības_un_dzemdību_atvaļinājums = 105,
        Bērna_kopšanas_atvaļinājums = 106,
        Paternitātes_atvaļinājums = 107,
        Slimības_lapa_A = 201,
        Slimības_lapa_B = 202,
        Negadījums_darba_vietā = 203,
        Neattaisnots_kavējums = 301,
        Komandējums = 302,
        Vidējās_izpeļņas_dienas = 303,
        Profesijas_maiņa = 304,
        Cits = 305
    }

    public enum EPeriodId : int
    {
        None = 100,
        Nav_pieņets = 101,
        Ir_pieņemts = 102,
        Atvaļinājums = 200,
        Slimo = 300,
        Vidējās_izpeļņas_dienas = 400,
        Komandējums = 401
    }

    public enum EDayPlanId : short
    {
        None = -1,
        DD = 0,
        BD = 1,
        SD = 2,
        DDSD = 3,
        SDDD = 4,
        Error = 99
    }

    public enum EDayFactId : short
    {
        None = -1,
        X = 0,  //nav darba attiecībās / amatā
        D = 1,  //darba diena
        B = 2,  //brīvdiena
        K = 3,  //komandējums
        S = 4,  //svētku diena ar vid.izp.
        V = 5,  //vid.izp. diena - nestrādā ar attaisnojošo iemeslu
        N = 6,  //kavējums
        DP = 7, //saīsināta pirmssvētku diena
        DS = 8, //darba diena svētku dienā ar piemaksu
        KS = 9,  //komandējums svētku dienā ar piemaksu

        SA = 20,  //slimības lapa A
        SB = 21,  //slimības lapa B
        SN = 22,  //negadijums darba vietā
        A = 23,   //atvaļinājums
        AM = 24, //apmaksāts mācību atvaļinājums
        AC = 25, //neapmaksāts mācību atvaļinājums
        AN = 26, //neapmaksāts atvaļinājums
        AD = 27, //dzemdību atvaļinājums
        AP = 28, //paternitātes atvaļinājums
        AB = 29, //bērnu kopšanas atvaļinājums

        Error = 99
    }


    public class MyListItemInt16
    {
        public Int16 Key { get; set; } = 0;
        public string Val { get; set; } = null;

        public MyListItemInt16(Int16 key, string val)
        {
            Key = key;
            Val = val;
        }
    }

    public class MyListItemInt
    {
        public int Key { get; set; } = 0;
        public string Val { get; set; } = null;

        public MyListItemInt(int key, string val)
        {
            Key = key;
            Val = val;
        }
    }

    public class MyListItemIntN
    {
        public int? Key { get; set; } = 0;
        public string Val { get; set; } = null;

        public MyListItemIntN(int? key, string val)
        {
            Key = key;
            Val = val;
        }
    }

    public class SomeDataDefs
    {
        public static KlonsData MyData { get { return KlonsData.St; } }

        static SomeDataDefs()
        {
            LaikaPlanuSarK1 = MakeListA("0", "grupas", "1", "individuāls");
            LaikaPlanuSarK2 = MakeListA("0", "5d.ned.", "1", "6d.ned.");

            /*
            DarbaLaiksK1 = MakeListA(
                "0", "grupas plāns",
                "1", "grupas plāns naktij",
                "2", "ind. plāns",
                "3", "ind. plāns naktij",
                "4", "nostrādāts",
                "5", "nostrādāts virst.",
                "6", "nostrādāts naktī");
            */


            DarbaLaiksK1 = MakeListA(
                "0", "plāns",
                "1", "plāns n.",
                "2", "plāns",
                "3", "plāns n.",
                "4", "nostr.",
                "5", "virst.",
                "6", "nostr.n.");

            DarbaLaiksK2 = MakeListA(
                "0", "diena",
                "1", "nakts",
                "2", "diena",
                "3", "nakts",
                "4", "diena",
                "5", "virst",
                "6", "nakts");

            DarbaLaiksK2a = MakeListA(
                "0", "diena",
                "1", "nakts");

            ProcOrEuro = MakeListA(
                "0", "%",
                "1", "€");

            PlanaVeids = MakeListA(
                "0", "kopplāns",
                "1", "individuāls");

            FPMaksNodVeids = MakeListA(
                "0", "Apliek ar nod.",
                "1", "Neapliek ar SAI",
                "2", "neapliek ar nod.",
                "3", "Autoratlīdzība");

            FPMaksSILikmesVeids = MakeListA(
                "0", "pamatlikme",
                "1", "pensionārs",
                "2", "izd.pens.saņ.vai inv. -VSP saņ.",
                "3", "ieslodzītais",
                "4", "ieslodzītais pensionārs");

            IINLikmesVeids = MakeListB(
                "0", "20",
                "1", "23");
        }

        public const string IdBrivdienaStr = "br";
        public const string IdSvetkuDienaStr = "sv";
        public const string IdSvetkuDienaBrivdienaStr = "sb";

        public const int Id5DienuNedela = 0;
        public const int Id6DienuNedela = 1;

        public static string GetPlanIdStr(EDayPlanId daycode)
        {
            switch (daycode)
            {
                case EDayPlanId.None: return "";
                case EDayPlanId.BD: return "B";
                case EDayPlanId.DD: return "D";
                case EDayPlanId.DDSD: return "DS";
                case EDayPlanId.SDDD: return "SD";
                case EDayPlanId.SD: return "S";
            }
            return null;
        }
        public static EDayPlanId GetPlanStrId(string daycode)
        {
            switch (daycode)
            {
                case "": return EDayPlanId.None;
                case "B": return EDayPlanId.BD;
                case "D": return EDayPlanId.DD;
                case "DS": return EDayPlanId.DDSD;
                case "SD": return EDayPlanId.SDDD;
                case "S": return EDayPlanId.SD;
            }
            return EDayPlanId.Error;
        }

        public static string GetFactIdStr(EDayFactId daycode)
        {
            switch (daycode)
            {
                case EDayFactId.None: return "";
                case EDayFactId.X: return "-";
                case EDayFactId.D: return "D";
                case EDayFactId.DP: return "DP";
                case EDayFactId.DS: return "DS";
                case EDayFactId.K: return "K";
                case EDayFactId.KS: return "KS";
                case EDayFactId.B: return "B";
                case EDayFactId.S: return "S";
                case EDayFactId.V: return "V";
                case EDayFactId.N: return "N";
                case EDayFactId.SA: return "SA";
                case EDayFactId.SB: return "SB";
                case EDayFactId.SN: return "SN";
                case EDayFactId.A: return "A";
                case EDayFactId.AM: return "AM";
                case EDayFactId.AC: return "AC";
                case EDayFactId.AN: return "AN";
                case EDayFactId.AD: return "AD";
                case EDayFactId.AP: return "AP";
                case EDayFactId.AB: return "AB";
                case EDayFactId.Error: return "ER";
            }
            return null;
        }

        public static EDayFactId GetFactStrId(string daycode)
        {
            if (daycode == null)
                throw new ArgumentNullException();
            switch (daycode.ToUpper())
            {
                case "": return EDayFactId.None;
                case "-": return EDayFactId.X;
                case "D": return EDayFactId.D;
                case "DP": return EDayFactId.DP;
                case "DS": return EDayFactId.DS;
                case "K": return EDayFactId.K;
                case "KS": return EDayFactId.KS;
                case "B": return EDayFactId.B;
                case "S": return EDayFactId.S;
                case "V": return EDayFactId.V;
                case "N": return EDayFactId.N;
                case "SA": return EDayFactId.SA;
                case "SB": return EDayFactId.SB;
                case "SN": return EDayFactId.SN;
                case "A": return EDayFactId.A;
                case "AM": return EDayFactId.AM;
                case "AC": return EDayFactId.AC;
                case "AN": return EDayFactId.AN;
                case "AD": return EDayFactId.AD;
                case "AP": return EDayFactId.AP;
                case "AB": return EDayFactId.AB;
                case "ER": return EDayFactId.Error;
            }
            return EDayFactId.Error;
        }

        public static List<MyListItemInt16> LaikaPlanuSarK1 { private set; get; } = null;
        public static List<MyListItemInt16> LaikaPlanuSarK2 { private set; get; } = null;
        public static List<MyListItemInt16> DarbaLaiksK1 { private set; get; } = null;
        public static List<MyListItemInt16> DarbaLaiksK2 { private set; get; } = null;
        public static List<MyListItemInt16> DarbaLaiksK2a { private set; get; } = null;
        public static List<MyListItemInt16> ProcOrEuro { private set; get; } = null;
        public static List<MyListItemInt16> PlanaVeids { private set; get; } = null;
        public static List<MyListItemInt16> FPMaksNodVeids { private set; get; } = null;
        public static List<MyListItemInt16> FPMaksSILikmesVeids { private set; get; } = null;
        public static List<MyListItemInt> IINLikmesVeids { private set; get; } = null;


        public static List<MyListItemInt16> MakeListA(params string[] data)
        {
            return MakeListA1(data);
        }

        public static List<MyListItemInt16> MakeListA1(string[] data)
        {
            var list = new List<MyListItemInt16>();
            if (data == null || data.Length == 0 || data.Length%2 == 1) return list;
            for (int i = 0; i < data.Length; i += 2)
            {
                Int16 k = Int16.Parse(data[i]);
                list.Add(new MyListItemInt16(k, data[i+1]));
            }
            return list;
        }

        public static List<MyListItemInt> MakeListB(params string[] data)
        {
            return MakeListB1(data);
        }

        public static List<MyListItemInt> MakeListB1(string[] data)
        {
            var list = new List<MyListItemInt>();
            if (data == null || data.Length == 0 || data.Length % 2 == 1) return list;
            for (int i = 0; i < data.Length; i += 2)
            {
                int k = int.Parse(data[i]);
                list.Add(new MyListItemInt(k, data[i + 1]));
            }
            return list;
        }

        public static string[] WeekDayStr = new[] { "pr", "ot", "tr", "ce", "pk", "se", "sv" };
        public static string[] GetDaysStr(int[] days)
        {
            string[] wds = new string[31];
            for (int i = 0; i < 31; i++)
            {
                if (days[i] == -1)
                {
                    wds[i] = "";
                }
                else
                {
                    wds[i] = WeekDayStr[days[i] - 1];
                }
            }
            return wds;
        }

        public static bool IsKindNight(EKind1 k)
        {
            return k == EKind1.PlanIndividualNight ||
                k == EKind1.PlanGroupaNight ||
                k == EKind1.FactNight;
        }
        public static bool IsKindPlan(EKind1 k)
        {
            return
                k == EKind1.PlanGroupDay ||
                k == EKind1.PlanGroupaNight ||
                k == EKind1.PlanIndividualDay ||
                k == EKind1.PlanIndividualNight;
        }

        public static bool IsDayFactIdIN(EDayFactId val, params EDayFactId[] list)
        {
            if (list == null || list.Length == 0) return false;
            foreach (var v in list)
                if (v == val) return true;
            return false;
        }

        public static bool IsPlanHoliday(EDayPlanId vv)
        {
            return vv == EDayPlanId.DDSD || vv == EDayPlanId.SD ||
                vv == EDayPlanId.SDDD;
        }

        public static bool IsPlanWorkday(EDayPlanId vv)
        {
            return vv == EDayPlanId.DDSD || vv == EDayPlanId.DD;
        }

        public static bool IsDayForWork(EDayFactId vv)
        {
            return IsDayFactIdIN(vv, EDayFactId.D, EDayFactId.DS, EDayFactId.DP, 
                EDayFactId.K, EDayFactId.KS);
        }

        public static bool IsDayVacation(EDayFactId vv)
        {
            return IsDayFactIdIN(vv, EDayFactId.A, EDayFactId.AB, EDayFactId.AC,
                EDayFactId.AD, EDayFactId.AM, EDayFactId.AN, EDayFactId.AP);
        }

        public static bool IsDayPaidVacation(EDayFactId vv)
        {
            return IsDayFactIdIN(vv, EDayFactId.A);
        }

        public static bool IsEventPaidVacation(EEventId vv)
        {
            return vv == EEventId.Atvaļinājums;
        }

        public static bool IsSickDay(EDayFactId vv)
        {
            return IsDayFactIdIN(vv, EDayFactId.SA, EDayFactId.SB, EDayFactId.SN);
        }

        public static bool CanChangeDayId(EDayFactId vv)
        {
            return IsDayFactIdIN(vv, EDayFactId.D, EDayFactId.DP, EDayFactId.DS, 
                EDayFactId.B, EDayFactId.K, EDayFactId.KS, EDayFactId.N, EDayFactId.V, EDayFactId.S);
        }

        public static bool CanEditFact(EDayFactId vv)
        {
            return CanChangeDayId(vv);
        }

        public static bool CanPlanHaveHours(EDayPlanId vv)
        {
            return vv == EDayPlanId.DD || vv == EDayPlanId.DDSD ||
                vv == EDayPlanId.SDDD;
        }

        public static bool CanFactHaveHours(EDayFactId vv)
        {
            return IsDayFactIdIN(vv, EDayFactId.D, EDayFactId.DP, EDayFactId.DS, 
                EDayFactId.K, EDayFactId.KS);
        }

        public static bool CanEditHours(EDayFactId vv)
        {
            return IsDayFactIdIN(vv, EDayFactId.D, EDayFactId.DP, EDayFactId.DS,
                EDayFactId.K, EDayFactId.KS);
        }

        public static bool CanPlanHaveFact(EDayPlanId dp, EDayFactId df)
        {
            switch (dp)
            {
                case EDayPlanId.SD:
                case EDayPlanId.DDSD:
                    if (IsDayFactIdIN(df, EDayFactId.N, EDayFactId.V, EDayFactId.S))
                        return false;
                    break;

                case EDayPlanId.BD:
                    if (IsDayFactIdIN(df, EDayFactId.N, EDayFactId.V, EDayFactId.S, 
                        EDayFactId.DS, EDayFactId.KS))
                        return false;
                    break;

                case EDayPlanId.SDDD:
                    if(IsDayFactIdIN(df, EDayFactId.N, EDayFactId.B))
                        return false;
                    break;
            }

            return true;
        }

        public static EDayFactId GetDayCodeForEvent(EPeriodId p, EEventId ev)
        {
            if (p == EPeriodId.None) return EDayFactId.None;
            if (p == EPeriodId.Nav_pieņets) return EDayFactId.X;
            switch (ev)
            {
                case EEventId.Neattaisnots_kavējums: return EDayFactId.N;
                case EEventId.Komandējums: return EDayFactId.K;
                case EEventId.Vidējās_izpeļņas_dienas: return EDayFactId.V;
                case EEventId.Slimības_lapa_A: return EDayFactId.SA;
                case EEventId.Slimības_lapa_B: return EDayFactId.SB;
                case EEventId.Negadījums_darba_vietā: return EDayFactId.SN;
                case EEventId.Atvaļinājums: return EDayFactId.A;
                case EEventId.Bezalgas_atvaļinājums: return EDayFactId.AN;
                case EEventId.Apmaksāts_mācību_atvaļinājums: return EDayFactId.AM;
                case EEventId.Bezalgas_mācību_atvaļinājums: return EDayFactId.AC;
                case EEventId.Grūtniecības_un_dzemdību_atvaļinājums: return EDayFactId.AD;
                case EEventId.Bērna_kopšanas_atvaļinājums: return EDayFactId.AB;
                case EEventId.Paternitātes_atvaļinājums: return EDayFactId.AP;
            }
            if (p == EPeriodId.Ir_pieņemts) return EDayFactId.D;
            return EDayFactId.Error;
        }

        public static bool IsFromToEvent(EEventId ev)
        {
            switch (ev)
            {
                case EEventId.Atvaļinājums:
                case EEventId.Bezalgas_atvaļinājums:
                case EEventId.Apmaksāts_mācību_atvaļinājums:
                case EEventId.Bezalgas_mācību_atvaļinājums:
                case EEventId.Grūtniecības_un_dzemdību_atvaļinājums:
                case EEventId.Bērna_kopšanas_atvaļinājums:
                case EEventId.Paternitātes_atvaļinājums:
                case EEventId.Slimības_lapa_A:
                case EEventId.Slimības_lapa_B:
                case EEventId.Negadījums_darba_vietā:
                case EEventId.Neattaisnots_kavējums:
                case EEventId.Komandējums:
                case EEventId.Vidējās_izpeļņas_dienas:
                    return true;
            }
            return false;
        }

        public static bool EventHasPayDate(EEventId ev)
        {
            switch (ev)
            {
                case EEventId.Atvaļinājums:
                case EEventId.Apmaksāts_mācību_atvaļinājums:
                    return true;
            }
            return false;
        }

        public static bool EventHasSCode(EEventId ev)
        {
            switch (ev)
            {
                case EEventId.Pieņemts:
                case EEventId.Atlaists:
                case EEventId.Noslēgts_uzņēmuma_līgums:
                case EEventId.Izbeigts_uzņēmuma_līgums:
                case EEventId.Profesijas_maiņa:
                case EEventId.Grūtniecības_un_dzemdību_atvaļinājums:
                case EEventId.Bērna_kopšanas_atvaļinājums:
                case EEventId.Paternitātes_atvaļinājums:
                case EEventId.Bezalgas_atvaļinājums:
                    return true;
            }
            return false;
        }

        public static bool EventHasOccCode(EEventId ev)
        {
            switch (ev)
            {
                case EEventId.Pieņemts:
                case EEventId.Noslēgts_uzņēmuma_līgums:
                case EEventId.Profesijas_maiņa:
                    return true;
            }
            return false;
        }

        public static bool ParsePlanDayStr(string fs, out EDayPlanId daycode, out float hours)
        {
            daycode = EDayPlanId.None;
            hours = 0.0f;
            int v, k = -1;

            for (int i = 0; i < fs.Length; i++)
            {
                var c = fs.Substring(i, 1);
                if (int.TryParse(c, out v))
                {
                    k = i;
                    break;
                }
            }

            if (k == -1)
            {
                hours = 0.0f;
                daycode = SomeDataDefs.GetPlanStrId(fs.Trim().ToUpper());
                return daycode != EDayPlanId.None && daycode != EDayPlanId.Error;
            }

            if (k > 0)
            {
                var daystr = fs.Substring(0, k).Trim().ToUpper();
                daycode = SomeDataDefs.GetPlanStrId(daystr);
                if (daycode == EDayPlanId.None || daycode == EDayPlanId.Error) return false;
            }
            else
            {
                daycode = EDayPlanId.None;
            }
            var hoursstr = fs.Substring(k).Trim();

            return float.TryParse(hoursstr, out hours);
        }

        public static bool ParseFactDayStr(string fs, out EDayFactId daycode, out float hours)
        {
            daycode = EDayFactId.None;
            hours = 0.0f;
            int v, k = -1;

            for (int i = 0; i < fs.Length; i++)
            {
                var c = fs.Substring(i, 1);
                if (int.TryParse(c, out v))
                {
                    k = i;
                    break;
                }
            }

            if (k == -1)
            {
                hours = 0.0f;
                daycode = SomeDataDefs.GetFactStrId(fs.Trim().ToUpper());
                if(daycode == EDayFactId.Error) return false;
                return true;
            }

            if (k > 0)
            {
                var daystr = fs.Substring(0, k).Trim().ToUpper();
                daycode = SomeDataDefs.GetFactStrId(daystr);
                if (daycode == EDayFactId.Error) return false;
            }
            else
            {
                daycode = EDayFactId.None;
            }
            var hoursstr = fs.Substring(k).Trim();

            return float.TryParse(hoursstr, out hours);
        }

        public static EDayFactId PlanIdToFactId(EDayPlanId planid)
        {
            switch (planid)
            {
                case EDayPlanId.DD: return EDayFactId.D;
                case EDayPlanId.BD: return EDayFactId.B;
                case EDayPlanId.SD: return EDayFactId.B;
                case EDayPlanId.DDSD: return EDayFactId.DS;
                case EDayPlanId.SDDD: return EDayFactId.S;
            }
            return EDayFactId.Error;
        }

        public static bool HasSAI(EBonusType e)
        {
            return e == EBonusType.Taxed ||
                e == EBonusType.PfTaxed ||
                e == EBonusType.LiTaxed || 
                e == EBonusType.HiTaxed;
        }
        public static bool HasIIN(EBonusType e)
        {
            return e == EBonusType.Taxed ||
                e == EBonusType.PfTaxed ||
                e == EBonusType.LiTaxed ||
                e == EBonusType.HiTaxed ||
                e == EBonusType.NoSAI;
        }


        public static EBonusFrom[] AllowedEBonusFrom0 = new EBonusFrom[] { };

        public static EBonusFrom[] AllowedEBonusFrom1 = 
            new[] { EBonusFrom.FromMonthSalary, EBonusFrom.FromPay,
                EBonusFrom.FromPayAndVacSick };

        public static EBonusFrom[] AllowedEBonusFrom2 = 
            new[] { EBonusFrom.FromMonthSalary, EBonusFrom.FromPay,
                EBonusFrom.FromPayAndVacSick,
                EBonusFrom.FromPayBeforeSAI, EBonusFrom.FromPayAfterSAI };

        public static EBonusFrom[] AllowedEBonusFrom3 = 
            new[] { EBonusFrom.FromMonthSalary, EBonusFrom.FromPay,
                EBonusFrom.FromPayAndVacSick,
                EBonusFrom.FromPayBeforeSAI, EBonusFrom.FromPayAfterSAI,
                EBonusFrom.FromPayBeforeIIN, EBonusFrom.FromPayAfterIIN };

        public static EBonusFrom[] AllowedEBonusFromP =
            new[] { EBonusFrom.FromMonthSalary, EBonusFrom.FromPay,
                EBonusFrom.FromPayAndVacSick,
                EBonusFrom.FromPayBeforeSAI};

        public static EBonusFrom[] GetAllowedEBonusFrom(EBonusType bt)
        {
            switch (bt)
            {
                case EBonusType.Taxed:
                    return AllowedEBonusFrom1;

                case EBonusType.NoSAI:
                case EBonusType.AuthorsFees:
                case EBonusType.MinusBeforeIIN:
                    return AllowedEBonusFrom2;

                case EBonusType.NotTaxed:
                case EBonusType.MinusAfterIIN:
                    return AllowedEBonusFrom3;

                case EBonusType.PfTaxed:
                case EBonusType.PfNotTaxed:
                case EBonusType.LiTaxed:
                case EBonusType.LiNotTaxed:
                case EBonusType.HiTaxed:
                case EBonusType.HiNotTaxed:
                    return AllowedEBonusFromP;

                default:
                    return AllowedEBonusFrom0;
            }
        }
        public static string GetEBonusText(EBonusType bt)
        {
            switch (bt)
            {
                case EBonusType.Taxed: return "apliek ar nod.";
                case EBonusType.NoSAI: return "nav SI";
                case EBonusType.AuthorsFees: return "autoraltlīdzība";
                case EBonusType.MinusBeforeIIN: return "atv. pirms IIN";
                case EBonusType.MinusAfterIIN: return "atv. pēc IIN";
                case EBonusType.NotTaxed: return "naeapliek ar nod.";
                case EBonusType.PfTaxed: return "PF apliek. daļa";
                case EBonusType.PfNotTaxed: return "PF neapliek. daļa";
                case EBonusType.LiTaxed: return "Dz.apdr. apliek. daļa";
                case EBonusType.LiNotTaxed: return "Dz.apdr. neapliek. daļa";
                case EBonusType.HiTaxed: return "Dz.apdr. bez līdz uzrk. apliek. daļa";
                case EBonusType.HiNotTaxed: return "Dz.apdr. bez līdz uzrk. neapliek. daļa";
                case EBonusType.ReverseCalc: return "Aprēķins no izmaksas.";

                default:
                    return "";
            }
        }

        public static string GetEBonusFromString(EBonusFrom bf)
        {
            switch (bf)
            {
                case EBonusFrom.None: return "";
                case EBonusFrom.FromMonthSalary: return "no pamatalgas";
                case EBonusFrom.FromPay: return "no aprēķinātās algas";
                case EBonusFrom.FromPayAndVacSick: return "no aprēķ. algas + atvaļ. + slim.n.";
                case EBonusFrom.FromPayBeforeSAI: return "no summas SI aprēķinam";
                case EBonusFrom.FromPayAfterSAI: return "no summas pēc SI";
                case EBonusFrom.FromPayBeforeIIN: return "no summas IIN aprēķinam";
                case EBonusFrom.FromPayAfterIIN: return "no summas pēc IIN";

                default: return "";
            }
        }
    

        public static MyListItemInt[] GetBonusFromItems(EBonusFrom[] bfs)
        {
            if(bfs == null || bfs.Length == 0)
                return new MyListItemInt[0];

            var ret = new List<MyListItemInt>();
            var drs = MyData.DataSetKlons.PLUSMINUS_FROM.OrderBy(d => d.ID).ToArray();
            for (int i = 0; i < bfs.Length; i++)
            {
                var dr = drs.Where(d => d.ID == (int)bfs[i]).FirstOrDefault();
                if (dr == null) continue;
                ret.Add(new MyListItemInt(dr.ID, dr.DESCR));
            }
            return ret.ToArray();
        }

        public static MyListItemIntN[] GetBonusFromItemsN(EBonusFrom[] bfs)
        {
            if (bfs == null || bfs.Length == 0)
                return new MyListItemIntN[0];

            var ret = new List<MyListItemIntN>();
            var drs = MyData.DataSetKlons.PLUSMINUS_FROM.OrderBy(d => d.ID).ToArray();
            for (int i = 0; i < bfs.Length; i++)
            {
                var dr = drs.Where(d => d.ID == (int)bfs[i]).FirstOrDefault();
                if (dr == null) continue;
                ret.Add(new MyListItemIntN(dr.ID, dr.DESCR));
            }
            return ret.ToArray();
        }

    }

}
