using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsA.Forms;
using KlonsLIB.Misc;
using KlonsLIB.Data;
using KlonsLIB.Forms;

namespace KlonsA.Classes
{
    public class Report_VacDays
    {
        private KlonsData MyData => KlonsData.St;

        public List<RepRowVacDays> RepRows = new List<RepRowVacDays>();

        public ErrorList MakeReport(DateTime dt)
        {
            var er = new ErrorList();
            var table_persons = MyData.DataSetKlons.PERSONS;
            var drs_persons = table_persons.WhereNotDeleted();
            foreach (var dr in drs_persons)
            {
                var rrvd = new RepRowVacDays();
                var er1 = GetVacDaysNotUsed(dr, dt, rrvd);
                if(er1 == "OK")
                {
                    RepRows.Add(rrvd);
                }
                else
                {
                    er.AddPersonError(dr.ID, er1);
                }
            }
            return er;
        }

        public static string GetVacDaysNotUsed(KlonsADataSet.PERSONSRow dr_person, DateTime dt, RepRowVacDays rrvd)
        {
            rrvd.Clear();

            if (dr_person == null) throw new ArgumentException();
            int idp = dr_person.ID;

            rrvd.IDP = idp;
            rrvd.Name = dr_person.ZNAME;

            var drs_events = dr_person.GetEVENTSRows();

            var drsn_hirefire = drs_events
                .Where(d => 
                    (d.IDN == (int)EEventId.Pieņemts || 
                    d.IDN == (int)EEventId.Atlaists) &&
                    d.DATE1 <= dt)
                .OrderBy(d => d.DATE1).ToArray();

            if (drsn_hirefire.Length == 0)
                return "OK";

            var pi_hirefire = new PeriodInfo();

            var rt1 = pi_hirefire.ReadStartEndList(drsn_hirefire,
                isStartItem: it => it.IDN == (int)EEventId.Pieņemts,
                getItemDate: it => it.DATE1);

            switch (rt1)
            {
                case PeriodInfo.ERetReadStartEndList.BadDates:
                    return "Pieņemts/atlaists notikumiem ir nekorekti datumi.";
                case PeriodInfo.ERetReadStartEndList.BadStart:
                case PeriodInfo.ERetReadStartEndList.BadEnd:
                    return "Pieņemts/atlaists notikumiem ir nekorekta secība.";
            }

            var pi_last = pi_hirefire.LinkedPeriods[pi_hirefire.LinkedPeriods.Count - 1];

            if (pi_last.DateLast < dt)
                return "OK";

            if (pi_last.DateLast == dt)
            {
                var dr_last_ev = drsn_hirefire[drsn_hirefire.Length - 1];
                if(dr_last_ev.EventCode == EEventId.Atlaists)
                    rrvd.Compansated = dr_last_ev.DAYS;
            }

            if (pi_hirefire.LinkedPeriods.Count == 1)
                rrvd.ToUse = dr_person.VACATION_DAYS;

            var dt1 = pi_last.DateFirst;
            var dt2 = pi_last.DateLast;
            if (dt2 > dt) dt2 = dt;
            int days_in_work = (dt2 - dt1).Days + 1;
            rrvd.ToUse += (float)Math.Round((float)days_in_work * 28f / 365f, 2);

            var drsn_vac = drs_events
                .Where(d => 
                    d.IDP == idp && 
                    d.IDN == 101 &&
                    d.DATE1 <= pi_last.DateLast &&
                    d.DATE2 >= pi_last.DateFirst)
                .OrderBy(d => d.DATE1).ToArray();

            var pi_vac = new PeriodInfo();

            var rt2 = pi_vac.ReadPeriodList(drsn_vac,
                getItemDate1: it => it.DATE1,
                getItemDate2: it => it.DATE2);

            switch (rt2)
            {
                case PeriodInfo.ERetReadPeriodList.BadDates:
                    return "Atvaļinājuma notikumam beigu datums \nir mazāks par sākuma datumu.";
                case PeriodInfo.ERetReadPeriodList.PeriodsOverlap:
                    return "Atvaļinājuma notikumai pārklājas";
            }


            foreach (var dr_vac in drsn_vac)
                rrvd.Used += dr_vac.DAYS;
            rrvd.Used = (float)Math.Round(rrvd.Used, 2);

            rrvd.NotUsed = rrvd.ToUse - rrvd.Used - rrvd.Compansated;
            rrvd.NotUsed = (float)Math.Round(rrvd.NotUsed, 2);

            return "OK";
        }
    }

    public class RepRowVacDays
    {
        public int IDP { get; set; } = 0;
        public string Name { get; set; } = null;
        public float ToUse { get; set; } = 0.0f;
        public float Used { get; set; } = 0.0f;
        public float Compansated { get; set; } = 0.0f;
        public float NotUsed { get; set; } = 0.0f;

        public void Clear()
        {
            ToUse = 0.0f;
            Used = 0.0f;
            Compansated = 0.0f;
            NotUsed = 0.0f;
        }
    }
}
