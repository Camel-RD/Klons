using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReportLib
{
    public class ReportFuncs
    {
        public static string[] Cik_Nums = new string[]
        {
            "nulle","viens","divi","trīs","četri","pieci",
            "seši","septiņa","astoņi","deviņi","desmit"
        };
        public static string[] Cik_Nums1 = new string[]
        {
            "nulle","vien","div","trī","četr","piec",
            "seš","septiņ","astoņ","deviņ","desmit"
        };

        private static string Cik_GetD(decimal d)
        {
            int k = (int)((d - Math.Truncate(d)) * 100.0M);
            if (k == 0) return "00";
            if (k < 10) return "0" + k;
            return k.ToString();
        }

        private static string Cik_GetV(decimal d)
        {
            int k = (int)Math.Truncate(d);
            int n1 = k % 100;
            if (n1 == 0) return "";
            if (n1 >= 1 && n1 <= 10) return Cik_Nums[n1];
            if (n1 >= 11 && n1 <= 19) return Cik_Nums1[n1 - 10] + "padsmit";
            //if (n1 >= 20 && n1 <= 99)
            int n2 = n1 / 10;
            int n3 = n1 % 10;
            if (n3 == 0) return Cik_Nums1[n2] + "desmit";
            return Cik_Nums1[n2] + "desmit " + Cik_Nums[n3];
        }
        private static string Cik_GetS(decimal d)
        {
            int k = (int)Math.Truncate(d);
            int n1 = (k % 1000) / 100;
            string simti = "";
            if (n1 > 0)
            {
                if (n1 == 1) simti = Cik_Nums[n1] + " simts";
                else simti = Cik_Nums[n1] + " simti";
            }
            string vieni = Cik_GetV(d);

            if (simti != "" && vieni != "") return simti + " " + vieni;
            return simti + vieni;
        }
        private static string Cik_GetT(decimal d)
        {
            int k = (int)Math.Truncate(d);
            int n1 = (k % 1000000) / 1000;
            string simtitukst = "";
            if (n1 > 0)
            {
                simtitukst = Cik_GetS(n1);
                if (n1 % 10 == 1) simtitukst += " tukstotis";
                else simtitukst += " tukstoši";
            }
            string simti = Cik_GetS(d);

            if (simtitukst != "" && simti != "") return simtitukst + " " + simti;
            return simtitukst + simti;
        }

        public static string CikEiro(decimal d)
        {
            string tukst = Cik_GetT(d);
            string centi = Cik_GetD(d);
            if (tukst == "") tukst = "Nulle";
            tukst += " eiro";
            string summa = tukst + " " + centi + " centi";
            summa = summa.Substring(0, 1).ToUpper() + summa.Substring(1);
            return summa;
        }

        public static string[] MonthNames = new string[]
        {
            "janvāris", "februāris", "marts", "aprīlis", "maijs", "jūnijs",
            "jūlijs", "augusts", "septembris", "oktobris", "novembris", "decembris"
        };

        public static string FullDateStr(object o)
        {
            if (o == null || o == DBNull.Value || !(o is DateTime)) return "";
            DateTime dt = (DateTime) o;
            return string.Format("{0}. gada {1}. {2}", dt.Year, dt.Day, MonthNames[dt.Month - 1]);
        }
    }
}
