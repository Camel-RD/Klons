using System;
using System.ComponentModel;
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
    public class Report_IINk
    {
        public static KlonsData MyData => KlonsData.St;

        public List<IINReportRow> Rows = null;

        public enum EReportType { ForYear, ForMonth}

        public void MakeReport(EReportType reporttype, DateTime dt1, DateTime dt2, DateTime dtx, bool simple)
        {
            Rows = new List<IINReportRow>();
            var rows1 = MakeReport1(reporttype, dt1, dt2, dtx, simple);
            var rows2 = MakeReport2(reporttype, dt1, dt2);
            rows1 = new List<IINReportRow>(rows1.OrderBy(r => r.Name));
            rows2 = new List<IINReportRow>(rows2.OrderBy(r => r.Name));
            rows1 = rows1.Where(x => x.HasData()).ToList();
            Rows.AddRange(rows1);
            Rows.AddRange(rows2);
        }

        public List<IINReportRow> MakeReport1(EReportType reporttype, DateTime dt1, DateTime dt2, DateTime dtx, bool simple)
        {
            var rows1 = new List<IINReportRow>();
            KlonsARepDataSet.SP_REP_IINK_01DataTable table = null;
            var ad = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.SP_REP_IINK_01TableAdapter();
            if (MyData.Params.IINSimple)
            {
                if (reporttype == EReportType.ForMonth)
                {
                    table = ad.GetDataBy_SP_REP_IINK_02(dt1, dt2, new DateTime(dt1.Year, 1, 1));
                }
                else if (reporttype == EReportType.ForYear)
                {
                    table = ad.GetDataBy_SP_REP_IINK_03(dt1, dt2);
                }
            }
            else
            {
                if (reporttype == EReportType.ForMonth)
                {
                    table = ad.GetDataBy_SP_REP_IINK_32(dt1, dt2, dtx);
                }
                else if (reporttype == EReportType.ForYear)
                {
                    table = ad.GetDataBy_SP_REP_IINK_33(dt1, dt2, dtx);
                }
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var dr = table.Rows[i] as KlonsARepDataSet.SP_REP_IINK_01Row;
                var rr = new IINReportRow();

                rr.nr = i + 1;
                rr.idp = dr.IDP;

                var drp = MyData.DataSetKlons.PERSONS.FindByID(rr.idp);
                rr.PK = PKForRep(drp.PK);
                rr.Name = drp.FNAME + " " + drp.LNAME;

                rr.Date1 = dr.DT1;
                rr.Date2 = dr.DT2;

                rr.IncomeType = "1001";
                rr.IncomeTypeS = "Darba alga";

                rr.dnsn_amount = dr.DNSN_AMOUNT;

                rr.untaxed_minimum0 = dr.UNTAXED_MINIMUM0;
                rr.iin_exempt_dependants0 = dr.IIN_EXEMPT_DEPENDANTS0;
                rr.iin_exempt_x0 = dr.IIN_EXEMPT_20;

                rr.untaxed_minimum = dr.UNTAXED_MINIMUM;
                rr.iin_exempt_dependants = dr.IIN_EXEMPT_DEPENDANTS;
                rr.iin_exempt_x = dr.IIN_EXEMPT_2;
                rr.iin_exempt_xtp = dr.IIN_EXEMPT_2TP;
                rr.iin_exempt_expenses = dr.IIN_EXEMPT_EXPENSES;

                rr.plus_pf_nottaxed = dr.PLUS_PF_NOTTAXED;
                rr.plus_li_nottaxed = dr.PLUS_LI_NOTTAXED;
                rr.plus_hi_nottaxed = dr.PLUS_HI_NOTTAXED;

                rr.income_nottaxed = dr.PLUS_NOTTAXED;

                rr.income = dr.INCOME -
                    rr.income_nottaxed +
                    rr.plus_pf_nottaxed +
                    rr.plus_li_nottaxed +
                    rr.plus_hi_nottaxed;

                rr.before_iin = rr.income -
                    rr.income_nottaxed -
                    rr.untaxed_minimum -
                    rr.dnsn_amount -
                    rr.iin_exempt_dependants -
                    rr.iin_exempt_x -
                    rr.iin_exempt_expenses -
                    rr.plus_pf_nottaxed -
                    rr.plus_li_nottaxed -
                    rr.plus_hi_nottaxed;

                rr.iin_amount = dr.IIN_AMOUNT;

                rows1.Add(rr);
            }

            return rows1;
        }

        private string PKForRep(string pk)
        {
            if (string.IsNullOrEmpty(pk)) return pk;
            return pk.Replace("-", "");
        }

        public List<IINReportRow> MakeReport2(EReportType reporttype, DateTime dt1, DateTime dt2)
        {
            var rows2 = new List<IINReportRow>();
            KlonsARepDataSet.SP_REP_IINK_21DataTable table = null;
            var ad = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.SP_REP_IINK_21TableAdapter();
            if (reporttype == EReportType.ForMonth)
            {
                table = ad.GetDataBy_SP_REP_IINK_21(dt1.Year, dt1.Month, dt1, dt2);
            }
            else if (reporttype == EReportType.ForYear)
            {
                table = ad.GetDataBy_SP_REP_IINK_22(dt1.Year, dt1, dt2);
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var dr = table.Rows[i] as KlonsARepDataSet.SP_REP_IINK_21Row;
                var rr = new IINReportRow();

                rr.nr = i + 1;
                rr.idp = dr.IDP;

                var drp = MyData.DataSetKlons.PERSONS_FIZ.FindByID(rr.idp);
                rr.PK = PKForRep(drp.PK);
                rr.Name = drp.FNAME + " " + drp.LNAME;

                rr.Date1 = dr.DATE1;
                rr.Date2 = dr.DATE2;
                rr.Month = dr.PAYMONTH;
                rr.MonthS = Utils.MonthNames[rr.Month - 1];

                rr.IncomeType = dr.INCOME_ID;
                rr.IncomeTypeS = MyData.DataSetKlons.INCOME_CODES
                    .FindByID(rr.IncomeType)?.DESCR;

                rr.income = dr.TAXED + dr.NOSAI;
                rr.income_nottaxed = dr.NOTTAXED;
                rr.authors_fee = dr.AUTHORS_FEE;

                rr.dnsn_amount = dr.SIDN;
                rr.iin_exempt_expenses = dr.IINEX;
                rr.before_iin = dr.IIN_FROM;
                rr.iin_amount = dr.IIN;

                rows2.Add(rr);
            }

            return rows2;
        }


        public string GetIncomTypeDescr(string id)
        {
            var dr = MyData.DataSetKlons.INCOME_CODES.FindByID(id);
            return dr.DESCR;
        }
    }

    public class IINReportRow : INotifyPropertyChanged
    {
        public bool Use { get; set; } = true;
        public int nr { get; set; } = 0;
        public int idp { get; set; } = 0;
        public string PK { get; set; } = "";
        public string Name { get; set; } = "";
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public string PeriodStr
        {
            get
            {
                return string.Format("{0:dd.MM.yyyy} - {1:dd.MM.yyyy}", Date1, Date2);
            }
        }

        public int Month { get; set; } = 0;
        public string MonthS { get; set; } = "";
        public string IncomeType { get; set; } = "";
        public string IncomeTypeS { get; set; } = "";
        public decimal income { get; set; } = 0.0M;
        public decimal income_nottaxed { get; set; } = 0.0M;
        public decimal authors_fee { get; set; } = 0.0M;

        public decimal dnsn_amount { get; set; } = 0.0M;

        public decimal untaxed_minimum0 { get; set; } = 0.0M;
        public decimal iin_exempt_dependants0 { get; set; } = 0.0M;
        public decimal iin_exempt_x0 { get; set; } = 0.0M;

        public decimal untaxed_minimum { get; set; } = 0.0M;
        public decimal iin_exempt_dependants { get; set; } = 0.0M;
        public decimal iin_exempt_x { get; set; } = 0.0M;
        public int iin_exempt_xtp { get; set; } = 0;
        public string iin_exempt_x_code => ex2str[iin_exempt_xtp];
        public decimal iin_exempt_invalidity { get; set; } = 0.0M;
        public decimal iin_exempt_retaliation { get; set; } = 0.0M;
        public decimal iin_exempt_national_movement { get; set; } = 0.0M;
        public decimal iin_exempt_expenses { get; set; } = 0.0M;

        public decimal plus_pf_nottaxed { get; set; } = 0.0M;
        public decimal plus_li_nottaxed { get; set; } = 0.0M;
        public decimal plus_hi_nottaxed { get; set; } = 0.0M;
        public decimal before_iin { get; set; } = 0.0M;
        public decimal iin_amount { get; set; } = 0.0M;

        private static string[] ex2str = { "", "090", "091", "092", "093", "094", "095" };


        public bool HasData()
        {
            return income != 0M || income_nottaxed != 0M || authors_fee != 0M ||
                dnsn_amount != 0M || plus_pf_nottaxed != 0M || plus_li_nottaxed != 0M ||
                plus_hi_nottaxed != 0M || before_iin != 0M || iin_amount != 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
    }
}
