using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KlonsA.DataSets;
using KlonsA.Forms;
using KlonsLIB.Misc;
using KlonsLIB.Data;
using KlonsLIB.Forms;

namespace KlonsA.Classes
{
    public class Report_Events
    {
        public static KlonsData MyData => KlonsData.St;

        public static List<EventsReportRow> MakeReport(DateTime dt1, DateTime dt2)
        {
            var ret = new List<EventsReportRow>();

            var drs = MyData.DataSetKlons.EVENTS.WhereX(
                d =>
                d.DATE1 >= dt1 &&
                d.DATE1 <= dt2 &&
                !string.IsNullOrEmpty(d.SCODE)
                ).OrderBy(d => d.DATE1)
                .ToArray();

            for (int i = 0; i < drs.Length; i++)
            {
                var dr = drs[i];
                var er = new EventsReportRow();
                er.Nr = i + 1;
                var drp = dr.PERSONSRow;
                er.PK = PKForRep(drp.PK);
                if(string.IsNullOrEmpty(er.PK))
                    er.PK = drp.BIRTH_DATE.ToString("dd.MM.yyyy");
                er.Name = drp.FNAME + " " + drp.LNAME;
                er.Date = dr.DATE1.ToString("dd.MM.yyyy");
                er.RDate = dr.DATE1;
                er.Code = dr.SCODE;
                er.ProfessionCode = dr.OCCUPATION_CODE;
                ret.Add(er);
            }
            return ret;
        }

        private static string PKForRep(string pk)
        {
            if (string.IsNullOrEmpty(pk)) return pk;
            return pk.Replace("-", "");
        }

    }

    public class EventsReportRow
    {
        public int Nr { get; set; } = 0;
        public string PK { get; set; } = "";
        public string Name { get; set; } = "";
        public string Date { get; set; } = "";
        public DateTime RDate { get; set; } = DateTime.MinValue;
        public string Code { get; set; } = "";
        public string Country { get; set; } = "";
        public string ProfessionCode { get; set; } = "";
    }

}
