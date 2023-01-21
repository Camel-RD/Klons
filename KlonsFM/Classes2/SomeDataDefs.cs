using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlonsLIB.Misc;

namespace KlonsFM.Classes
{
    public enum EStoreCalcMethod
    {
        FIFO, AveragePrice
    }

    public enum EAccountType
    {
        Nenoteikts = 1,
        Noliktava = 2,
        Izmaksas = 3,
        Ieņēmumi = 4,
        Debitori = 5,
        Kreditori = 6
    }

    public enum EAccountingType
    {
        MakeNone = 0,
        MakeAll = 1,
        MakeForWares = 2,
        MakeForSale = 3
    }

    public enum EStoreType
    {
        Nenoteikts = 1,
        Noliktava = 2,
        Darbinieks = 3,
        Partneris = 4,
        Partneris_turētājs = 5,
        Pakalpojumi = 6,
        Citi = 7,
        Noliktava_ārpus = 8,
        Ražošana = 9

    }

    public enum EPVNType
    {
        Nenoteikts = 1,
        Iekšzemē_apliekama_persona = 2,
        Iekšzemē_neapliekama_persona = 3,
        Eiropas_kopienā_apliekama_persona = 4,
        Eiropas_kopienā_neapliekama_persona = 5,
        Trešās_valstis = 6,
        Nav_PVN = 7
    }

    public enum EDocType
    {
        Nenoteikts = 1,
        Iepirkums = 2,
        Realizācija = 3,
        Atgriezts_piegādātājam = 4,
        Atgriezts_no_pircēja = 5,
        Kredītrēķins_no_piegādātāja = 6,
        Kredītrēķins_pircējam = 7,
        Pārvietots = 8,
        Sākuma_atlikums = 9,
        Norakstīts = 10,
        Pierakstīts = 11,
        Uz_noliktavu = 12,
        No_noliktavas = 13,
        Izlietots = 14,
        Saražots = 15,
        Saņemti_pakalpojumi = 16,
        Sniegti_pakalpojumi = 17
    }
    
    public enum EDocType2
    {
        Nenoteikts,
        Iekšējs,
        Saņemts_no_partnera,
        Izdots_partnerim
    }

    public enum EDocState
    {
        Melnraksts = 0,
        Apstiprināts = 1,
        Iegrāmatots = 2,
        Iekontēts = 3,
        Atvērts = 4
    }

    public enum EAccountsForTemplates
    {
        Nav = 0,
        PVN = 1,
        Krājumi = 2,
        Debitori = 3,
        Kreditori = 4,
        Ieņēmumi = 5,
        Izmaksas = 6
    }


    public class SomeDataDefs
    {
        public static List<MyListItemInt> StoreCalcMethods { private set; get; } = null;
        public static List<MyListItemInt16> AccountinType { private set; get; } = null;
        public static List<MyListItemInt> DocStates { private set; get; } = null;
        public static List<MyListItemInt> AccTemplatesBase { private set; get; } = null;
        public static List<MyListItemInt> AccTemplatesPVN { private set; get; } = null;

        static SomeDataDefs()
        {
            StoreCalcMethods = MakeListB(
                "0", "FIFO",
                "1", "VS");
            AccountinType = MakeListA(
                "0", "Nekontēt",
                "1", "Visu",
                "2", "Krājumus",
                "3", "Realizāciju"
                );
            DocStates = MakeListB(
                "0", "Melnraksts",
                "1", "Apstiprināts",
                "2", "Iegrāmatots",
                "1", "Iekontēts",
                "1", "Atvērts"
                );

            AccTemplatesBase = MakeListB(
                "0", "Nav",
                "2", "21--",
                "3", "231-",
                "4", "531-",
                "5", "6---",
                "6", "7---");
            AccTemplatesPVN = MakeListB(
                "0", "Nav",
                "1", "5731",
                "3", "231-",
                "4", "531-");
            /*
            AccTemplatesBase = MakeListB(
                "0", "Nav",
                "2", "Krājumi",
                "3", "Debitori",
                "4", "Kreditori",
                "5", "Ieņēmumi",
                "6", "Izmaksas");
            AccTemplatesPVN = MakeListB(
                "0", "Nav",
                "1", "PVN",
                "3", "Debitori",
                "4", "Kreditori");
            */
        }

        public static string GetDocStateText(EDocState state)
        {
            switch (state)
            {
                case EDocState.Melnraksts: return "Melnraksts";
                case EDocState.Atvērts: return "Atvēts";
                case EDocState.Iegrāmatots: return "Iegrāmatots";
                case EDocState.Apstiprināts: return "Apstiprināts";
                case EDocState.Iekontēts: return "Iekontēts";
            }
            return "?";
        }

        public static EDocType2 GetDocType2(EDocType doctype)
        {
            switch (doctype)
            {
                case EDocType.Nenoteikts: 
                    return EDocType2.Nenoteikts;
                case EDocType.Pārvietots:
                case EDocType.Pierakstīts:
                case EDocType.Norakstīts:
                case EDocType.Sākuma_atlikums:
                case EDocType.Uz_noliktavu:
                case EDocType.No_noliktavas:
                case EDocType.Izlietots:
                case EDocType.Saražots:
                    return EDocType2.Iekšējs;
                case EDocType.Iepirkums:
                case EDocType.Saņemti_pakalpojumi:
                    return EDocType2.Saņemts_no_partnera;
                case EDocType.Realizācija:
                case EDocType.Atgriezts_piegādātājam:
                case EDocType.Kredītrēķins_no_piegādātāja:
                case EDocType.Sniegti_pakalpojumi:
                case EDocType.Atgriezts_no_pircēja:
                case EDocType.Kredītrēķins_pircējam:
                    return EDocType2.Izdots_partnerim;
            }
            throw new Exception("DocType list incomplete");
        }

        public static EPVNType GetPVNType(EDocType doctype, EStoreType storeintype,
            EStoreType storeouttype, EPVNType storeinpvntype, EPVNType storeoutpvntype)
        {
            var doctype2 = GetDocType2(doctype);
            if (doctype2 == EDocType2.Nenoteikts) return EPVNType.Nenoteikts;
            if (doctype2 == EDocType2.Iekšējs) return EPVNType.Nav_PVN;
            if (doctype2 == EDocType2.Izdots_partnerim)
            {
                if (!IsStorePartner(storeintype)) return EPVNType.Nenoteikts;
                return storeinpvntype;
            }
            if (doctype2 == EDocType2.Saņemts_no_partnera)
            {
                if (!IsStorePartner(storeouttype)) return EPVNType.Nenoteikts;
                return storeoutpvntype;
            }
            return EPVNType.Nenoteikts;
        }

        public static bool IsStorePartner(EStoreType storetype)
        {
            return storetype == EStoreType.Partneris;
        }

        public static bool IsStoreOurs(EStoreType storetype)
        {
            switch (storetype)
            {
                case EStoreType.Noliktava:
                case EStoreType.Darbinieks:
                case EStoreType.Partneris_turētājs:
                case EStoreType.Pakalpojumi:
                case EStoreType.Citi:
                case EStoreType.Noliktava_ārpus:
                case EStoreType.Ražošana:
                    return true;
            }
            return false;
    }

        public static bool IsGoodStoreOut(EDocType doctype, EStoreType storeouttype)
        {
            if (storeouttype == EStoreType.Nenoteikts) return false;
            switch (doctype)
            {
                case EDocType.Nenoteikts:
                    return false;

                case EDocType.Iepirkums:
                case EDocType.Saņemti_pakalpojumi:
                    return storeouttype == EStoreType.Partneris;

                case EDocType.Realizācija:
                case EDocType.Atgriezts_piegādātājam:
                case EDocType.Kredītrēķins_no_piegādātāja:
                case EDocType.Atgriezts_no_pircēja:
                case EDocType.Kredītrēķins_pircējam:
                case EDocType.Pārvietots:
                case EDocType.Norakstīts:
                case EDocType.Izlietots:
                case EDocType.Uz_noliktavu:
                    return storeouttype == EStoreType.Noliktava;

                case EDocType.Sākuma_atlikums:
                case EDocType.Pierakstīts:
                    return storeouttype == EStoreType.Citi;

                case EDocType.No_noliktavas:
                    return storeouttype == EStoreType.Noliktava_ārpus;

                case EDocType.Saražots:
                    return storeouttype == EStoreType.Ražošana;

                case EDocType.Sniegti_pakalpojumi:
                    return storeouttype == EStoreType.Pakalpojumi;
            }
            return false;
        }

        public static bool IsGoodStoreIn(EDocType doctype, EStoreType storeintype)
        {
            if (storeintype == EStoreType.Nenoteikts) return false;
            switch (doctype)
            {
                case EDocType.Nenoteikts:
                    return false;

                case EDocType.Iepirkums:
                case EDocType.Pārvietots:
                case EDocType.Pierakstīts:
                case EDocType.No_noliktavas:
                case EDocType.Sākuma_atlikums:
                case EDocType.Saražots:
                    return storeintype == EStoreType.Noliktava;

                case EDocType.Saņemti_pakalpojumi:
                    return storeintype == EStoreType.Pakalpojumi;

                case EDocType.Realizācija:
                case EDocType.Atgriezts_piegādātājam:
                case EDocType.Kredītrēķins_no_piegādātāja:
                case EDocType.Atgriezts_no_pircēja:
                case EDocType.Kredītrēķins_pircējam:
                case EDocType.Sniegti_pakalpojumi:
                    return storeintype == EStoreType.Partneris;

                case EDocType.Norakstīts:
                    return storeintype == EStoreType.Citi;

                case EDocType.Uz_noliktavu:
                    return storeintype == EStoreType.Noliktava_ārpus;

                case EDocType.Izlietots:
                    return storeintype == EStoreType.Ražošana;
            }
            return false;
        }

        public static bool IsCreditDoc(EDocType doctype)
        {
            return doctype == EDocType.Kredītrēķins_no_piegādātāja ||
                doctype == EDocType.Kredītrēķins_pircējam;
        }

        public static bool IsDoc231(EDocType doctype)
        {
            switch (doctype)
            {
                case EDocType.Realizācija:
                case EDocType.Atgriezts_no_pircēja:
                case EDocType.Kredītrēķins_pircējam:
                case EDocType.Sniegti_pakalpojumi:
                    return true;
            }
            return false;
        }

        public static bool IsDoc531(EDocType doctype)
        {
            switch (doctype)
            {
                case EDocType.Iepirkums:
                case EDocType.Atgriezts_piegādātājam:
                case EDocType.Kredītrēķins_no_piegādātāja:
                case EDocType.Saņemti_pakalpojumi:
                    return true;
            }
            return false;
        }

        public static string GetAcc21(DataSets.KlonsMDataSet.M_DOCSRow dr_doc)
        {
            if (IsStoreOurs(dr_doc.XStoreInType))
                return dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREIN1.ACC21;
            if (IsStoreOurs(dr_doc.XStoreOutType))
                return dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREOUT1.ACC21;
            return null;
        }

        public static string GetAcc231(DataSets.KlonsMDataSet.M_DOCSRow dr_doc)
        {
            if (IsStorePartner(dr_doc.XStoreInType))
                return dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREIN1.ACC23;
            if (IsStorePartner(dr_doc.XStoreOutType))
                return dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREOUT1.ACC23;
            return null;
        }

        public static string GetAcc531(DataSets.KlonsMDataSet.M_DOCSRow dr_doc)
        {
            if (IsStorePartner(dr_doc.XStoreInType))
                return dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREIN1.ACC53;
            if (IsStorePartner(dr_doc.XStoreOutType))
                return dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREOUT1.ACC53;
            return null;
        }

        public static bool IsCreditDocInTheSameMonth(DataSets.KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var doctp = dr_doc.XDocType;
            if (!IsCreditDoc(doctp)) return false;
            if (dr_doc.IsCREDDOCDTNull()) return false;
            bool rt = dr_doc.DT.FirstDayOfMonth() == dr_doc.CREDDOCDT.FirstDayOfMonth();
            return rt;
        }

        public static bool IsInnerDoc(EDocType doctype)
        {
            switch (doctype)
            {
                case EDocType.Pārvietots:
                case EDocType.Pierakstīts:
                case EDocType.No_noliktavas:
                case EDocType.Sākuma_atlikums:
                case EDocType.Saražots:
                case EDocType.Norakstīts:
                case EDocType.Uz_noliktavu:
                case EDocType.Izlietots:
                    return true;
            }
            return false;
        }

        public static bool PriceIsBuyPrice(EDocType doctype)
        {
            switch (doctype)
            {
                case EDocType.Iepirkums:
                case EDocType.Pārvietots:
                case EDocType.Saražots:
                case EDocType.Pierakstīts:
                case EDocType.Saņemti_pakalpojumi:
                case EDocType.No_noliktavas:
                case EDocType.Uz_noliktavu:
                case EDocType.Sākuma_atlikums:
                    return true;
            }
            return false;
        }


        public static string GetAccT(DataSets.KlonsMDataSet.M_ROWSRow dr_row,
            EAccountsForTemplates tacc)
        {
            if (IsInnerDoc(dr_row.M_DOCSRow.XDocType))
                throw new Exception("Bad call.");
            switch (tacc)
            {
                case EAccountsForTemplates.Nav: return null;
                case EAccountsForTemplates.PVN: return "5731";
                case EAccountsForTemplates.Krājumi: return GetAcc21(dr_row.M_DOCSRow);
                case EAccountsForTemplates.Debitori: return GetAcc231(dr_row.M_DOCSRow);
                case EAccountsForTemplates.Kreditori: return GetAcc531(dr_row.M_DOCSRow);
                case EAccountsForTemplates.Ieņēmumi: return dr_row.M_ITEMSRow.M_ITEMS_CATRow.ACC6;
                case EAccountsForTemplates.Izmaksas: return dr_row.M_ITEMSRow.M_ITEMS_CATRow.ACC7;
            }
            return null;
        }

        public static bool AutoMakeFinOps(EDocType doctp)
        {
            switch (doctp)
            {
                case EDocType.Iepirkums:
                case EDocType.Realizācija:
                case EDocType.Atgriezts_piegādātājam:
                case EDocType.Atgriezts_no_pircēja:
                case EDocType.Kredītrēķins_no_piegādātāja:
                case EDocType.Kredītrēķins_pircējam:
                case EDocType.Saņemti_pakalpojumi:
                case EDocType.Sniegti_pakalpojumi:
                case EDocType.Norakstīts:
                case EDocType.Pierakstīts:
                    return true;
            }
            return false;
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
                short k = short.Parse(data[i]);
                list.Add(new MyListItemInt16(k, data[i + 1]));
            }
            return list;
        }
    }

    public class MyListItemInt
    {
        public int Key { get; set; } = 0;
        public Int16 Key16 
        { 
            get => (Int16)Key; 
            set => Key = value; 
        }
        public string Val { get; set; } = null;

        public MyListItemInt(int key, string val)
        {
            Key = key;
            Val = val;
        }
    }

    public class MyListItemInt16
    {
        public short Key { get; set; } = 0;
        public string Val { get; set; } = null;

        public MyListItemInt16(short key, string val)
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

}
