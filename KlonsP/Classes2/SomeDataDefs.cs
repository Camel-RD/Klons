using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlonsP.Classes
{
    public enum EEvent
    {
        error = -1,
        nenoteikts = 0,
        pienuzsk = 1,
        iegeks = 2,
        ieg = 3,
        izv = 4,
        eks = 5,
        vieta = 10,
        parvert = 20,
        rekat = 21,
        kapit = 22,
        nelieto = 30,
        lieto = 31,
        likvid = 40,
        noliet = 50,
        apr = 100
    }

    public enum EState
    {
        OK = 0,
        Liquidated = 1,
        NotUsed = 2,
        OldDate = 3,
        Error = 4
    }

    public enum EChColInd
    {
        none = 0,
        cat1 = 1,
        catd = 2,
        catt = 1 << 2,
        place = 1 << 3,
        department = 1 << 4,
        value0 = 1 << 5,
        deprec0 = 1 << 6,
        valuec = 1 << 7,
        deprecc = 1 << 8,
        sellvalue = 1 << 9,
        taxvalue = 1 << 10,
        taxvaluec = 1 << 11,
        taxvalueleft = 1 << 12,
        mttotal = 1 << 13,
        mtused = 1 << 14
    }


    public enum EFilterState
    {
        all = 0,
        active = 1,
        error = 2
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
    public static class SomeDataDefs
    {
        public const EChColInd ChColIndAll = (EChColInd)((1 << 15) - 1);

        public static List<MyListItemInt> FilterList = MakeListB("0", "Visi", "1", "Aktīvie", "2", "Kļūdas");

        public static string ToMyString(this EEvent ev)
        {
            switch (ev)
            {
                case EEvent.error: return "kļūda";
                case EEvent.nenoteikts: return "nenoteikts";
                case EEvent.pienuzsk: return "pieņ.uzsk";
                case EEvent.iegeks: return "iegeks";
                case EEvent.ieg: return "ieg";
                case EEvent.izv: return "izv";
                case EEvent.eks: return "eks";
                case EEvent.vieta: return "vieta";
                case EEvent.parvert: return "parvert";
                case EEvent.rekat: return "rekat";
                case EEvent.kapit: return "kapit";
                case EEvent.nelieto: return "nelieto";
                case EEvent.lieto: return "lieto";
                case EEvent.likvid: return "likvid";
                case EEvent.noliet: return "noliet";
                case EEvent.apr: return "apr";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string ToMyStringFull(this EEvent ev)
        {
            switch (ev)
            {
                case EEvent.error: return "kļūda";
                case EEvent.nenoteikts: return "?";
                case EEvent.pienuzsk: return "pieņemts uzskaitē";
                case EEvent.iegeks: return "iegāde";
                case EEvent.ieg: return "iegāde";
                case EEvent.izv: return "izveide";
                case EEvent.eks: return "nodots ekspluatācijā";
                case EEvent.vieta: return "pārvietots";
                case EEvent.parvert: return "pārvērtēšana";
                case EEvent.rekat: return "kategorijas maiņa";
                case EEvent.kapit: return "kapitālremonts";
                case EEvent.nelieto: return "pārtrauc lietošanu";
                case EEvent.lieto: return "atsāk lietošanau";
                case EEvent.likvid: return "likvidēts";
                case EEvent.noliet: return "nolietojums";
                case EEvent.apr: return "aprēķins";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string ToMyString(this EState est)
        {
            switch (est)
            {
                case EState.Error: return "Kļūda";
                case EState.OK: return "OK";
                case EState.OldDate: return "Pirms dat.";
                case EState.Liquidated: return "Izslēgts";
                case EState.NotUsed: return "Nelieto";
            }
            throw new Exception("Bad case.");
        }

        public static bool IsIn(this EEvent ev, params EEvent[] evs)
        {
            if (evs == null)
                throw new ArgumentNullException();
            return evs.Contains(ev);
        }

        public static EChColInd GetEditableFields(EEvent ev)
        {
            switch (ev)
            {
                case EEvent.error: return EChColInd.none;
                case EEvent.nenoteikts: return EChColInd.none;

                case EEvent.pienuzsk:
                    return
                        EChColInd.cat1 |
                        EChColInd.catd |
                        EChColInd.catt |
                        EChColInd.place |
                        EChColInd.department |
                        EChColInd.value0 |
                        EChColInd.deprec0 |
                        EChColInd.sellvalue |
                        EChColInd.taxvalue | 
                        EChColInd.taxvalueleft |
                        EChColInd.mtused;

                case EEvent.iegeks:
                    return
                        EChColInd.cat1 |
                        EChColInd.catd |
                        EChColInd.catt |
                        EChColInd.place |
                        EChColInd.department |
                        EChColInd.valuec |
                        EChColInd.deprecc |
                        EChColInd.sellvalue;

                case EEvent.ieg:
                case EEvent.izv:
                    return
                        EChColInd.cat1 |
                        EChColInd.catd |
                        EChColInd.catt |
                        EChColInd.valuec;

                case EEvent.eks:
                    return
                        EChColInd.cat1 |
                        EChColInd.catd |
                        EChColInd.catt |
                        EChColInd.place |
                        EChColInd.department;

                case EEvent.vieta:
                    return
                        EChColInd.place |
                        EChColInd.department;

                case EEvent.parvert:
                case EEvent.kapit:
                    return
                        EChColInd.valuec |
                        EChColInd.deprecc |
                        EChColInd.sellvalue;

                case EEvent.rekat:
                    return
                        EChColInd.cat1 |
                        EChColInd.catd |
                        EChColInd.catt;

                case EEvent.nelieto:
                case EEvent.lieto:
                case EEvent.noliet:
                case EEvent.apr:
                    return EChColInd.none;

                case EEvent.likvid:
                    return
                        EChColInd.valuec |
                        EChColInd.deprecc |
                        EChColInd.sellvalue;

                default:
                    throw new ArgumentOutOfRangeException();
            }

        }


        public static List<MyListItemInt16> MakeListA(params string[] data)
        {
            return MakeListA1(data);
        }

        public static List<MyListItemInt16> MakeListA1(string[] data)
        {
            var list = new List<MyListItemInt16>();
            if (data == null || data.Length == 0 || data.Length % 2 == 1) return list;
            for (int i = 0; i < data.Length; i += 2)
            {
                Int16 k = Int16.Parse(data[i]);
                list.Add(new MyListItemInt16(k, data[i + 1]));
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

    }


}
