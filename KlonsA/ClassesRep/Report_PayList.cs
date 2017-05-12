using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsA.Forms;
using KlonsLIB.Misc;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using Microsoft.Reporting.WinForms;

namespace KlonsA.Classes
{
    public class Report_PayList
    {
        private KlonsData MyData => KlonsData.St;

        public List<RepRowPayList> RepPayLists = new List<RepRowPayList>();

        public void AddToReport(KlonsADataSet.PAYLISTSRow dr_list, KlonsADataSet.PAYLISTS_RRow[] drs_rows)
        {
            var rr = MakeReport(dr_list, drs_rows);
            rr.key = RepPayLists.Count;
            RepPayLists.Add(rr);
        }

        public RepRowPayList MakeReport(KlonsADataSet.PAYLISTSRow dr_list, KlonsADataSet.PAYLISTS_RRow[] drs_rows)
        {
            var rrList = new RepRowPayList();
            rrList.Year = dr_list.YR;
            rrList.Month = dr_list.MT;
            rrList.Nr = dr_list.SNR;
            rrList.PayDate = dr_list.DT;
            rrList.PayDateS = LatText.FullDateStr(rrList.PayDate);
            rrList.WriteDate = DateTime.Today;
            rrList.Period = string.Format("{0}. gada {1}",
                rrList.Year, LatText.MonthNames[rrList.Month - 1]);
            for (int i = 0; i < drs_rows.Length; i++)
            {
                var rrRow = new RepRowPayListRow();
                var dr_row = drs_rows[i];
                rrRow.Nr = i + 1;
                rrRow.idp = dr_row.IDP;
                rrRow.idam = dr_row.IDAM;
                var ss_nm = DataTasks.GetPersonNameAndPK(rrRow.idp);
                rrRow.Name = ss_nm[0] + " " + ss_nm[1];
                rrRow.PK = ss_nm[2];
                rrRow.PositionTitle = DataTasks.GetPositionTitle(rrRow.idam);
                rrRow.NameAndPos = rrRow.Name + ", " + rrRow.PositionTitle.Nz();
                rrRow.TPay = dr_row.TPAY;
                rrRow.Pay = dr_row.PAY;
                rrRow.Advance = dr_row.ADVANCE;
                rrRow.Withhold = dr_row.WITHHOLDINGS;

                rrList.Rows.Add(rrRow);
                rrList.TotalPay += rrRow.TPay;
            }
            rrList.TotalPayS = LatText.CikEiro(rrList.TotalPay);
            return rrList;
        }

        public void GroupWithoutPositions()
        {
            RepPayLists = RepPayLists.Select(d => GroupWithoutPositions(d)).ToList();
        }

        public RepRowPayList GroupWithoutPositions(RepRowPayList rr)
        {
            var new_rr = new RepRowPayList();
            new_rr.CopyFrom(rr);
            var grp = rr.Rows.GroupBy(d => d.idp);
            new_rr.Rows = grp.Select(
                gr =>
                {
                    var g = gr.Aggregate(
                        (rc, radd) =>
                        {
                            rc.Add(radd);
                            return rc;
                        });
                    g.PositionTitle = null;
                    g.NameAndPos = g.Name;
                    return g;
                })
                .OrderBy(d => d.Name)
                .ToList();
            return new_rr;
        }

        public void ShowReport1()
        {
            var rd = new ReportViewerData();
            rd.FileName = "ReportA_MaksSar_1";
            rd.Sources["DSPayLists"] = RepPayLists;
            rd.AddReportParameters(new string[]
                {
                    "CompanyName", MyData.Params.CompNameX,
                    "RDate", Utils.DateToString(DateTime.Today)
                });

            rd.OnSubreport = (e) =>
            {
                string fnm = ReportHelper.ReportNameFromPath(e.ReportPath);
                if (fnm == "ReportA_MaksSar_1a")
                {
                    int nr = int.Parse(e.Parameters["RINR"].Values[0]);
                    var r = new[] { RepPayLists[nr] };
                    var rr = RepPayLists[nr].Rows;
                    e.DataSources.Add(new ReportDataSource("DSPayList", r));
                    e.DataSources.Add(new ReportDataSource("DSRows", rr));
                }
            };

            MyData.MyMainForm.ShowReport(rd);
        }

        public void ShowReport2()
        {
            var rd = new ReportViewerData();
            rd.FileName = "ReportA_MaksSar_2";
            rd.Sources["DSPayLists"] = RepPayLists;
            rd.AddReportParameters(new string[]
                {
                    "CompanyName", MyData.Params.CompNameX,
                    "RDate", Utils.DateToString(DateTime.Today)
                });

            rd.OnSubreport = (e) =>
            {
                string fnm = ReportHelper.ReportNameFromPath(e.ReportPath);
                if (fnm == "ReportA_MaksSar_2a")
                {
                    int nr = int.Parse(e.Parameters["RINR"].Values[0]);
                    var r = new[] { RepPayLists[nr] };
                    var rr = RepPayLists[nr].Rows;
                    e.DataSources.Add(new ReportDataSource("DSPayList", r));
                    e.DataSources.Add(new ReportDataSource("DSRows", rr));
                }
            };

            MyData.MyMainForm.ShowReport(rd);
        }
    }

    public class RepRowPayList
    {
        public List<RepRowPayListRow> Rows = new List<RepRowPayListRow>();

        public int key { get; set; } = 0;
        public int Nr { get; set; } = 0;
        public int Year { get; set; } = 0;
        public int Month { get; set; } = 0;
        public string Period { get; set; } = null;
        public DateTime WriteDate { get; set; }
        public DateTime PayDate { get; set; }
        public string PayDateS { get; set; } = null;
        public decimal TotalPay { get; set; } = 0.0M;
        public string TotalPayS { get; set; } = null;

        public void CopyFrom(RepRowPayList rr)
        {
            key = rr.key;
            Nr = rr.Nr;
            Year = rr.Year;
            Month = rr.Month;
            Period = rr.Period;
            WriteDate = rr.WriteDate;
            PayDate = rr.PayDate;
            PayDateS = rr.PayDateS;
            TotalPay = rr.TotalPay;
            TotalPayS = rr.TotalPayS;
        }
    }

    public class RepRowPayListRow
    {
        public int Nr { get; set; } = 0;
        public int idp { get; set; } = 0;
        public int idam { get; set; } = 0;
        public string PK { get; set; } = "";
        public string Name { get; set; } = "";
        public string PositionTitle { get; set; } = "";
        public string NameAndPos { get; set; } = "";
        public decimal TPay { get; set; } = 0.0M;
        public decimal Pay { get; set; } = 0.0M;
        public decimal Advance { get; set; } = 0.0M;
        public decimal Withhold { get; set; } = 0.0M;

        public void CopyFrom(RepRowPayListRow rr)
        {
            Nr = rr.Nr;
            idp = rr.idp;
            idam = rr.idam;
            PK = rr.PK;
            Name = rr.Name;
            PositionTitle = rr.PositionTitle;
            NameAndPos = rr.NameAndPos;
            TPay = rr.TPay;
            Pay = rr.Pay;
            Advance = rr.Advance;
            Withhold = rr.Withhold;
        }

        public void Add(RepRowPayListRow rr)
        {
            TPay += rr.TPay;
            Pay += rr.Pay;
            Advance += rr.Advance;
            Withhold += rr.Withhold;
        }

        public RepRowPayListRow Sum(IEnumerable<IGrouping<int, RepRowPayListRow>> rrs)
        {
            return null;
        }

    }
}
