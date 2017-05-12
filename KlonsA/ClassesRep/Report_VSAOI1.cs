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
    public class Report_VSAOI1
    {
        public static KlonsData MyData => KlonsData.St;

        public List<VSAOIReportRow1> Rows1 = null;
        public List<VSAOIReportRow1>[] RowsX = new List<VSAOIReportRow1>[6];
        public VSAOIReportRow1 TotalRow = null;
        public VSAOIReportRow1[] TotalRowsX = new VSAOIReportRow1[6];
        public Dictionary<int, decimal> IINInPayLists = new Dictionary<int, decimal>();
        public void MakeReport(DateTime dt1, DateTime dt2)
        {
            Rows1 = new List<VSAOIReportRow1>();
            TotalRow = new VSAOIReportRow1();

            var dr_sheet = MyData.DataSetKlons.SALARY_SHEETS.WhereX(
                d =>
                d.DT1 >= dt1 &&
                d.DT2 <= dt2 &&
                d.IS_TEMP == 0 &&
                d.XKind == ESalarySheetKind.Total
                ).FirstOrDefault();

            if (dr_sheet == null) return;
            bool iinsimple = MyData.Params.IINSimple;
            if (!iinsimple) DoMaksSar(dt1, dt2);
            var drs = dr_sheet.GetSALARY_SHEETS_RRowsByFK_SALARY_SHEETS_R_IDST();
            decimal iin;
            for (int i = 0; i < drs.Length; i++)
            {
                var dr = drs[i];
                var rr = new VSAOIReportRow1();
                rr.Nr = i + 1;
                var drp = dr.PERSONSRow;
                var drpr = GetPersonR(drp, dt2);
                if (drpr == null)
                {
                    MyData.MyMainForm.ShowWarning(string.Format("Darbineikam {0} nav datu.", drp.YNAME));
                    Rows1 = new List<VSAOIReportRow1>();
                    TotalRow = new VSAOIReportRow1();
                    return;
                }
                rr.SetSAIType(drpr);
                rr.PK = PKForRep(drp.PK);
                if (string.IsNullOrEmpty(rr.PK))
                    rr.PK = drp.BIRTH_DATE.ToString("dd.MM.yyyy");
                rr.Name = drp.FNAME + " " + drp.LNAME;
                rr.Income = dr.AMOUNT_BEFORE_SN;
                rr.SAI = dr.SN_AMOUNT;

                if (iinsimple)
                {
                    rr.IIN = dr.IIN_AMOUNT;
                }
                else
                {
                    if (IINInPayLists.TryGetValue(dr.IDP, out iin))
                        rr.IIN = iin;
                    else
                        rr.IIN = 0.0M;
                }

                rr.IncomeCorrected = dr.AMOUNT_BEFORE_SN_REVERSE;
                rr.SAICorrected = dr.DDSN_AMOUNT_REVERSE + dr.DNSN_AMOUNT_REVERSE;

                rr.Hours = dr.FACT_HOURS;
                rr.URVN = dr.URVN_AMAOUNT;
                rr.HasURVN = rr.URVN > 0.0M;
                Rows1.Add(rr);
                TotalRow.Add(rr);
            }
            Rows1 = new List<VSAOIReportRow1>(Rows1.OrderBy(d => d.Name));
            SplitRows();
        }

        private string PKForRep(string pk)
        {
            if (string.IsNullOrEmpty(pk)) return pk;
            return pk.Replace("-", "");
        }

        public void DoMaksSar(DateTime dt1, DateTime dt2)
        {
            IINInPayLists.Clear();
            var drs = MyData.DataSetKlons.PAYLISTS_R.WhereX(
                d =>
                {
                    var drl = d.PAYLISTSRow;
                    return drl.DT < dt1 || drl.DT > dt2;
                }).ToArray();

            //drs.GroupBy(d => d.IDP).Select(d => new { idp = d.Key, iin = d.Sum(d2 => d2.IIN)});
            decimal v;
            foreach(var dr in drs)
            {
                if (!IINInPayLists.TryGetValue(dr.IDP, out v)) v = 0.0M;
                IINInPayLists[dr.IDP] = v + dr.IIN;
            }
        }

        public KlonsADataSet.PERSONS_RRow GetPersonR(KlonsADataSet.PERSONSRow drp, DateTime dt)
        {
            var dr = drp.GetPERSONS_RRows().WhereX(
                d =>
                d.EDIT_DATE <= dt
                ).WithMaxOrDefault(d => d.EDIT_DATE);
            return dr;
        }

        public void SplitRows()
        {
            for (int i = 0; i < 6; i++)
            {
                RowsX[i] = new List<VSAOIReportRow1>(Rows1.Where(d => d.Tp == i + 1));
                TotalRowsX[i] = new VSAOIReportRow1();
                foreach (var r in RowsX[i])
                    TotalRowsX[i].Add(r);
            }
        }

    }


    public class VSAOIReportRow1
    {
        private static string[] CTP2s = new string[] { "?", "DN", "DI", "DP", "?", "CN", "CP" };

        public int Nr { get; set; } = 0;
        public int Tp { get; set; } = 0;
        public int Tp2 { get; set; } = 0;
        public string Tp2s => CTP2s[Tp2];
        public string PK { get; set; } = "";
        public string Name { get; set; } = "";
        public string Country { get; set; } = "";
        public decimal Income { get; set; } = 0.0M;
        public decimal SAI { get; set; } = 0.0M;
        public decimal IncomeCorrected { get; set; } = 0.0M;
        public decimal SAICorrected { get; set; } = 0.0M;
        public decimal IIN { get; set; } = 0.0M;
        public bool HasURVN { get; set; } = false;
        public decimal URVN { get; set; } = 0.0M;
        public float Hours { get; set; } = 0.0f;

        public void Add(VSAOIReportRow1 r)
        {
            Income += r.Income;
            SAI += r.SAI;
            IncomeCorrected += r.IncomeCorrected;
            SAICorrected += r.SAICorrected;
            IIN += r.IIN;
            URVN += r.URVN;
        }

        public void SetSAIType(KlonsADataSet.PERSONS_RRow drpr)
        {
            var dr = drpr;
            if (dr == null) return;
            Tp2 = 1;
            if (dr.PENSIONER == 1) Tp2 = 2;
            if (dr.PENSIONER_SP == 1) Tp2 = 3;
            if (dr.PRISONER == 1 && dr.PENSIONER == 0) Tp2 = 5;
            if (dr.PRISONER == 1 && dr.PENSIONER == 1) Tp2 = 6;

            if (dr.NOT_OSA == 1) Tp = 4;
            else Tp = Tp2;

        }

    }
}
