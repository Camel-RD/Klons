using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KlonsA.DataSets;
using KlonsLIB.Misc;
using KlonsLIB.Data;
using KlonsA.DataSets.KlonsADataSetTableAdapters;

namespace KlonsA.Classes
{
    public class SalarySheetInfo
    {
        public static KlonsData MyData => KlonsData.St;

        public int YR;
        public int MT;
        public DateTime MDT1;
        public DateTime MDT2;
        public DateTime DT1;
        public DateTime DT2;

        public CalendarMonthInfo CalendarMonth = null;
        public KlonsADataSet.RATESRow DR_Likmes = null;

        public KlonsADataSet.SALARY_SHEET_TEMPLRow DR_algas_lapu_sh = null;
        public KlonsADataSet.SALARY_SHEETSRow DR_algas_lapa = null;
        public List<SalarySheetRowInfo> Rows = new List<SalarySheetRowInfo>();

        public KlonsADataSet.SALARY_SHEETSRow TotalsList = null;

        public SalarySheetInfo(int yr, int mt)
        {
            YR = yr;
            MT = mt;
            MDT1 = new DateTime(YR, MT, 1);
            MDT2 = MDT1.AddMonths(1).AddDays(-1);
            DT1 = MDT1;
            DT2 = MDT2;
            CalendarMonth = new CalendarMonthInfo(YR, MT);
        }

        public SalarySheetInfo(SalarySheetInfo si)
        {
            YR = si.YR;
            MT = si.MT;
            MDT1 = si.MDT1;
            MDT2 = si.MDT2;
            DT1 = MDT1;
            DT2 = MDT2;
            CalendarMonth = si.CalendarMonth;
        }

        public SalarySheetInfo(KlonsADataSet.SALARY_SHEETSRow dr_lapa) :this(dr_lapa.YR, dr_lapa.MT)
        {
            DR_algas_lapa = dr_lapa;
            DT1 = dr_lapa.DT1;
            DT2 = dr_lapa.DT2;
        }


        public void MakeSheetFromSh(short snr0)
        {
            var table_sar = MyData.DataSetKlons.SALARY_SHEETS;
            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;

            var dr_sh = DR_algas_lapu_sh;

            CheckTotalListForPeriod();

            var new_dr_sar = table_sar.NewSALARY_SHEETSRow();

            new_dr_sar.YR = YR;
            new_dr_sar.MT = MT;
            new_dr_sar.SNR = snr0;
            new_dr_sar.DEP = dr_sh.DEP;
            new_dr_sar.DESCR = dr_sh.DESCR;
            new_dr_sar.DT1 = MDT1;
            new_dr_sar.DT2 = MDT2;
            
            table_sar.Rows.Add(new_dr_sar);

            DR_algas_lapa = new_dr_sar;

            foreach (var salary_sheet_row in Rows)
            {
                salary_sheet_row.MakeRowFromSH();
            }
        }


        public KlonsADataSet.SALARY_SHEETSRow MakeTotalsSheet()
        {
            var table_sar = MyData.DataSetKlons.SALARY_SHEETS;
            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;

            var new_dr_sar = table_sar.NewSALARY_SHEETSRow();

            new_dr_sar.YR = YR;
            new_dr_sar.MT = MT;
            new_dr_sar.SNR = 0;
            new_dr_sar.DESCR = "KOPĀ";
            new_dr_sar.DT1 = DT1;
            new_dr_sar.DT2 = DT2;
            new_dr_sar.KIND = 1;

            table_sar.Rows.Add(new_dr_sar);

            return new_dr_sar;
        }

        public ErrorList SetUpFromSHRow(KlonsADataSet.SALARY_SHEET_TEMPLRow dr_sh)
        {
            DR_algas_lapu_sh = dr_sh;

            var error_list = new ErrorList();
            var this_error_source = string.Format("Lapa:{0}", dr_sh.SNR);

            var er = GetLikmes();
            if (er != "OK")
            {
                error_list.AddError(this_error_source, er);
                return error_list;
            }

            var drs_sh_r = dr_sh.GetSALARY_SHEET_TEMPL_RRows().OrderBy(d => d.SNR);

            foreach (var dr_sh_r in drs_sh_r)
            {

                var salary_sheet_row = new SalarySheetRowInfo(this);
                var err = salary_sheet_row.SetUpFromSHRow(dr_sh_r);

                if (err.Count > 0)
                {
                    error_list.AddRange(err);
                    continue;
                }

                Rows.Add(salary_sheet_row);
            }

            return error_list;
        }

        public ErrorList SetUpFromSarRow(KlonsADataSet.SALARY_SHEETSRow dr_lapa)
        {
            var error_list = new ErrorList();

            var er = SetUpLightFromSarRow(dr_lapa);
            if (er != "OK") return new ErrorList("", er);

            var drs_r = dr_lapa.KIND == 1 ?
                dr_lapa.GetSALARY_SHEETS_RRowsByFK_SALARY_SHEETS_R_IDST().OrderBy(d => d.SNR) :
                dr_lapa.GetSALARY_SHEETS_RRowsByFK_SALARY_SHEETS_R_IDS().OrderBy(d => d.SNR);

            foreach (var dr_r in drs_r)
            {
                var salary_sheet_row = new SalarySheetRowInfo(this);
                var err = salary_sheet_row.SetUpFromRowX(dr_r);
                if (err.HasErrors) return err;
                Rows.Add(salary_sheet_row);
            }

            return error_list;
        }

        public string SetUpLightFromSarRow(KlonsADataSet.SALARY_SHEETSRow dr_lapa)
        {
            DR_algas_lapa = dr_lapa;
            DT1 = dr_lapa.DT1;
            DT2 = dr_lapa.DT2;
            var er = GetLikmes();
            if (er != "OK") return er;
            CheckTotalListForPeriod();
            return "OK";
        }


        public void CheckTotalListForPeriod()
        {
            if (TotalsList != null) return;
            var dr_total_sar = FindTotalListForPeriod();
            if(dr_total_sar != null)
            {
                TotalsList = dr_total_sar;
                return;
            }
            TotalsList = MakeTotalsSheet();
        }

        public ErrorList FillSheet()
        {
            if (DR_algas_lapa == null)
                throw new Exception("Bad init.");

            var error_list = new ErrorList();

            var drs = DR_algas_lapa.GetSALARY_SHEETS_RRowsByFK_SALARY_SHEETS_R_IDS();
            foreach (var dr in drs)
            {
                var salary_sheet_row = new SalarySheetRowSetInfo();
                var err = salary_sheet_row.SetUpFromRowB(this, dr.IDP);
                error_list.AddRange(err);
                if (err.Count > 0) continue;
                err = salary_sheet_row.FillRow();
                error_list.AddRange(err);
            }

            return error_list;
        }

        public void DeleteRow(KlonsADataSet.SALARY_SHEETS_RRow dr_lapas_r)
        {
            var table_algas_ps = MyData.DataSetKlons.SALARY_PLUSMINUS;
            CheckTotalListForPeriod();
            int idp = dr_lapas_r.IDP;
            int idam = dr_lapas_r.IDAM;
            var drs_ps = table_algas_ps.WhereX(
                d =>
                d.IDSX == dr_lapas_r.IDSX &&
                !d.IsIDANull() &&
                d.IDA == idam
                ).ToArray();
            foreach (var dr in drs_ps)
                dr.Delete();
            dr_lapas_r.Delete();
            var salary_sheet_row = new SalarySheetRowSetInfo();
            var err = salary_sheet_row.SetUpFromRowB(this, idp);
            if (err.Count > 0) return;
            if (salary_sheet_row.DrLinkedRows.Length == 0 && 
                salary_sheet_row.DrTotalRow == null) return;
            salary_sheet_row.FillRow();
        }


        public void DeleteListRows()
        {
            if (DR_algas_lapa == null)
                throw new Exception("Bad init.");

            var drs = DR_algas_lapa.GetSALARY_SHEETS_RRowsByFK_SALARY_SHEETS_R_IDS();
            foreach (var dr in drs)
            {
                DeleteRow(dr);
            }
        }

        public void DeleteList()
        {
            if (DR_algas_lapa == null)
                throw new Exception("Bad init.");
            DeleteListRows();
            DR_algas_lapa.Delete();
            var drt = FindTotalListForPeriod();
            if (drt != null && !HasSalarySheetsForPeriod())
                drt.Delete();
        }

        public bool HasSalarySheetsForPeriod()
        {
            var table = MyData.DataSetKlons.SALARY_SHEETS;
            var drf = table.WhereX(
                d =>
                d.XKind == ESalarySheetKind.Normal &&
                d.YR == YR &&
                d.MT == MT &&
                d.DT1 == DT1 &&
                d.DT2 == DT2
                ).FirstOrDefault();
            return drf != null;
        }

        public void ChangeIDSXForAlgasPSRows(int new_idsx, KlonsADataSet.SALARY_SHEETS_RRow dr_totalrow)
        {
            var drs_ps = dr_totalrow.GetSALARY_PLUSMINUSRows();
            foreach (var dr in drs_ps)
            {
                if (dr.IDSX != new_idsx)
                    dr.IDSX = new_idsx;
            }
        }

        public KlonsADataSet.SALARY_SHEETS_RRow MakeTotalsRow(int idp)
        {
            if (TotalsList == null)
                throw new Exception("Bad init.");

            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;

            var new_dr_sar_r = table_sar_r.NewSALARY_SHEETS_RRow();

            new_dr_sar_r.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_SALARY_SHEETS_R_ID();
            new_dr_sar_r.IDS = TotalsList.ID;
            new_dr_sar_r.IDSX = new_dr_sar_r.ID;
            new_dr_sar_r.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDST = TotalsList;
            new_dr_sar_r.IDST = TotalsList.ID;
            new_dr_sar_r.IDP = idp;
            new_dr_sar_r["IDAM"] = DBNull.Value;
            new_dr_sar_r.XType = ESalarySheetRowType.Total;
            //new_dr_sar_r.FNAME = DR_Person_r.FNAME;
            //new_dr_sar_r.LNAME = DR_Person_r.LNAME;
            new_dr_sar_r.POSITION_TITLE = "KOPĀ";
            new_dr_sar_r.IS_TEMP = TotalsList.IS_TEMP;

            table_sar_r.Rows.Add(new_dr_sar_r);

            return new_dr_sar_r;
        }


        public KlonsADataSet.SALARY_SHEETSRow FindTotalListForPeriod()
        {
            var table_sar = MyData.DataSetKlons.SALARY_SHEETS;
            var drs_sar = table_sar.WhereX(d =>
                d.KIND == 1 &&
                d.YR == this.YR &&
                d.MT == this.MT &&
                d.DT1 == this.DT1 &&
                d.DT2 == this.DT2
            ).ToArray();
            if (drs_sar.Length > 1)
                throw new Exception("More than 1 totals list.");
            if (drs_sar.Length == 0) return null;
            return drs_sar[0];
        }


        public string GetLikmes()
        {
            var drs_likmes = MyData.DataSetKlons.RATES.OrderBy(d => d.ONDATE).ToArray();

            DR_Likmes = PeriodInfo.FindNearestBefore(drs_likmes,
                MDT1, d => d.ONDATE);

            if (DR_Likmes == null)
            {
                return "Likmes nav definētas.";
            }

            return "OK";
        }

    }
}
