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
    public class SalarySheetRowSetInfo
    {
        public static KlonsData MyData => KlonsData.St;

        public SalarySheetInfo SalarySheet = null;

        public int IDP;
        public KlonsADataSet.PERSONS_RRow DR_Person_r = null;

        public SalarySheetRowInfo TotalRow = null;
        public SalaryInfo TotalPersonPay = null;

        public SalarySheetRowInfo[] LinkedRows = null;

        public KlonsADataSet.SALARY_SHEETS_RRow DrTotalRow = null;
        public KlonsADataSet.SALARY_SHEETS_RRow[] DrLinkedRows = null;

        public EventsInfo Events = null;

        public SalarySheetRowSetInfo()
        {
        }

        public bool GetPersonRow(ErrorList err, int idp, SalarySheetInfo sh)
        {
            var table_persons = MyData.DataSetKlons.PERSONS;
            IDP = idp;
            var dr_person = table_persons.FindByID(idp);
            if (dr_person == null)
            {
                var es = string.Format("{0} ({1}-{2})",
                    IDP,
                    sh.CalendarMonth.Year,
                    sh.CalendarMonth.Month);
                err.AddError(es, "Nav darbinieka");
                return false;
            }

            var drs_persons_r = dr_person.GetPERSONS_RRows().OrderBy(d => d.EDIT_DATE).ToArray();

            var dt2 = sh.MDT2;

            DR_Person_r = PeriodInfo.FindNearestBefore(drs_persons_r,
                dt2, d => d.EDIT_DATE);

            if (DR_Person_r == null)
            {
                var es = string.Format("{0} {1} ({2}-{3})",
                    dr_person.FNAME,
                    dr_person.LNAME,
                    sh.CalendarMonth.Year,
                    sh.CalendarMonth.Month);
                err.AddError(es, "Norādītajam periodam nav ievadīti darbinieka dati.");
                return false;
            }
            return true;
        }

        public ErrorList SetUpFromRowA(SalarySheetRowInfo sr)
        {
            if (sr?.Row == null)
                throw new Exception("Bad init.");

            var error_list = new ErrorList();

            IDP = sr.Row.IDP;
            DR_Person_r = sr.DR_Person_r;
            SalarySheet = sr.SalarySheet;
            error_list += SetUpFromRowZ();

            return error_list;
        }

        public ErrorList SetUpFromRowB(SalarySheetInfo sh, int idp)
        {
            var error_list = new ErrorList();
            SalarySheet = sh;

            if (!GetPersonRow(error_list, idp, SalarySheet))
                return error_list;

            error_list += SetUpFromRowZ();
            
            return error_list;
        }

        private ErrorList SetUpFromRowZ(SalarySheetRowInfo sr = null)
        {
            if ((sr != null && sr.Row == null) || DR_Person_r == null || SalarySheet == null)
                throw new Exception("Bad init.");

            var error_list = new ErrorList();
            ErrorList err;

            TotalRow = null;
            LinkedRows = new SalarySheetRowInfo[0];

            CheckLinkedRows(IDP);

            if (DrTotalRow == null || DrLinkedRows.Length == 0)
                return error_list;

            LinkedRows = new SalarySheetRowInfo[DrLinkedRows.Length];

            var error_source = string.Format("{0} {1} ({2}-{3})",
                DR_Person_r.FNAME,
                DR_Person_r.LNAME,
                SalarySheet.CalendarMonth.Year,
                SalarySheet.CalendarMonth.Month);

            GetEventList(error_list, IDP);

            if (error_list.Count > 0)
            {
                return error_list;
            }

            for (int i = 0; i < DrLinkedRows.Length; i++)
            {
                var dr = DrLinkedRows[i];
                if (dr == sr?.Row)
                {
                    LinkedRows[i] = sr;
                    sr.SalarySheetRowSet = this;
                    sr.Events = Events;
                    continue;
                }
                var lr = new SalarySheetRowInfo(SalarySheet, dr);
                LinkedRows[i] = lr;
                lr.SalarySheetRowSet = this;
                lr.Events = Events;
                err = lr.SetUpFromRow(dr);
                error_list += err;
            }

            if (IsSingleRow())
            {
                TotalRow = LinkedRows[0];
            }
            else
            {
                if(DrTotalRow == sr?.Row)
                {
                    TotalRow = sr;
                    TotalRow.SalarySheetRowSet = this;
                }
                else
                {
                    TotalRow = new SalarySheetRowInfo(SalarySheet, DrTotalRow);
                    TotalRow.SalarySheetRowSet = this;
                    TotalRow.Events = Events;
                    error_list += TotalRow.SetUpT(IDP);
                }
            }

            if (error_list.HasErrors) return error_list;

            if (TotalRow?.TotalPositionPay != null)
                TotalPersonPay = TotalRow.TotalPositionPay;

            if (error_list.HasErrors)
            {
                LinkedRows = null;
                return error_list;
            }

            return error_list;
        }


        public ErrorList SetUpFromRowX(KlonsADataSet.SALARY_SHEETS_RRow dr_r)
        {
            var dr_sar1 = dr_r.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS;
            var ssh = new SalarySheetInfo(dr_sar1);
            var er = ssh.SetUpLightFromSarRow(dr_sar1);
            if (er != "OK")
                return new ErrorList("", er);
            return SetUpFromRowB(ssh, dr_r.IDP);
        }

        public bool GetRow(int addmonth, out SalarySheetRowSetInfo row)
        {
            row = null;
            var table_sar = MyData.DataSetKlons.SALARY_SHEETS;
            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;

            int yr = SalarySheet.YR;
            int mt = SalarySheet.MT;
            Utils.AddMonths(ref yr, ref mt, addmonth);

            int idp = IDP;

            var drs = table_sar_r.WhereX(
                d =>
                {
                    var dr_sar = d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS;
                    return
                        d.IDP == idp &&
                        d.IsIDAMNull() &&
                        dr_sar.YR == yr &&
                        dr_sar.MT == mt;
                }).ToArray();

            if (drs.Length == 0) return true;
            var dr = drs[0];

            var shr = new SalarySheetRowSetInfo();
            var err = shr.SetUpFromRowX(dr);
            if (err != null && err.Count > 0)
            {
                return false;
            }

            row = shr;

            return true;
        }

        public void MakeTotalsRow(int idp)
        {
            if (SalarySheet == null || SalarySheet.TotalsList == null)
                throw new Exception("Bad init.");

            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;

            var new_dr_sar_r = table_sar_r.NewSALARY_SHEETS_RRow();

            new_dr_sar_r.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_SALARY_SHEETS_R_ID();
            new_dr_sar_r.IDS = SalarySheet.TotalsList.ID;
            new_dr_sar_r.IDSX = new_dr_sar_r.ID;
            new_dr_sar_r.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDST = SalarySheet.TotalsList;
            new_dr_sar_r.IDST = SalarySheet.TotalsList.ID;
            new_dr_sar_r.IDP = idp;
            new_dr_sar_r["IDAM"] = DBNull.Value;
            new_dr_sar_r.XType = ESalarySheetRowType.Total;
            new_dr_sar_r.FNAME = DR_Person_r.FNAME;
            new_dr_sar_r.LNAME = DR_Person_r.LNAME;
            new_dr_sar_r.POSITION_TITLE = "KOPĀ";
            new_dr_sar_r.IS_TEMP = SalarySheet.TotalsList.IS_TEMP;

            table_sar_r.Rows.Add(new_dr_sar_r);

            DrTotalRow = new_dr_sar_r;
        }


        private void SetIntValue(ref int rec, int src)
        {
            if (rec != src) rec = src;
        }

        // seperate totalrow is used only when there are more than one linked rows
        public void CheckLinkedRows(int idp)
        {
            if (SalarySheet == null || SalarySheet.TotalsList == null)
                throw new Exception("No totals sheet.");

            var table_lapas_r = MyData.DataSetKlons.SALARY_SHEETS_R;

            var dt1 = SalarySheet.DT1;
            var dt2 = SalarySheet.DT2;

            var drs_lapas_r = table_lapas_r.WhereX(
                d =>
                d.IDP == IDP &&
                d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.DT1 == dt1 &&
                d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.DT2 == dt2
            ).ToArray();

            var drs_total_r = drs_lapas_r.Where(
                d =>
                d.XType == ESalarySheetRowType.Total
            ).ToArray();

            var drs_linked_r = drs_lapas_r.Where(
                d =>
                d.XType != ESalarySheetRowType.Total
            ).ToArray();

            if (drs_linked_r.Length == 0)
            {
                foreach (var dr in drs_total_r)
                    dr.Delete();
                this.DrTotalRow = null;
                this.DrLinkedRows = new KlonsADataSet.SALARY_SHEETS_RRow[0];
            }
            else if (drs_linked_r.Length == 1)
            {
                foreach (var dr in drs_total_r)
                    dr.Delete();

                var dr0 = drs_linked_r[0];

                this.DrTotalRow = dr0;

                if (dr0.IsIDSTNull() || dr0.IDST != SalarySheet.TotalsList.ID)
                    dr0["IDST"] = SalarySheet.TotalsList.ID;
                if (dr0.IDSX != dr0.ID)
                    dr0.IDSX = dr0.ID;
                if (dr0.XType != ESalarySheetRowType.OnlyOne)
                    dr0.XType = ESalarySheetRowType.OnlyOne;

                this.DrLinkedRows = new KlonsADataSet.SALARY_SHEETS_RRow[1];
                this.DrLinkedRows[0] = this.DrTotalRow;
            }
            else
            {
                for (int i = 1; i < drs_total_r.Length; i++)
                    drs_total_r[i].Delete();

                if (drs_total_r.Length == 0)
                {
                    MakeTotalsRow(idp);
                }
                else
                {
                    DrTotalRow = drs_total_r[0];
                }

                ChangeIDSXForAlgasPSRows(DrTotalRow.ID);

                foreach (var dr in drs_linked_r)
                {
                    if (dr.IDSX != DrTotalRow.ID)
                        dr.IDSX = DrTotalRow.ID;
                    if (dr["IDST"] != DBNull.Value)
                        dr["IDST"] = DBNull.Value;
                    if (dr.XType != ESalarySheetRowType.OneOfMany)
                        dr.XType = ESalarySheetRowType.OneOfMany;
                }

                DrLinkedRows = drs_linked_r;
            }
        }


        public KlonsADataSet.POSITIONS_PLUSMINUSRow[] GetRelevantPersonPSRows()
        {
            var dt1 = SalarySheet.MDT1;
            var dt2 = SalarySheet.MDT2;

            var drs_amps = DR_Person_r.PERSONSRow.GetPOSITIONS_PLUSMINUSRows().Where(
                d =>
                d.RowState != DataRowState.Deleted &&
                d.DATE1 <= dt2 &&
                d.DATE2 >= dt1
                ).ToArray();

            return drs_amps;
        }

        public KlonsADataSet.SALARY_PLUSMINUSRow[] GetAlgasAllPSRows()
        {
            if (DrTotalRow == null)
                throw new Exception("Bad init.");
            var drst = DrTotalRow.GetSALARY_PLUSMINUSRows();
            var drsl = DrLinkedRows.SelectMany(d => d.GetSALARY_PLUSMINUSRows());
            var drsz = drst.Concat(drsl);
            return drsz.ToArray();
        }

        public KlonsADataSet.SALARY_PLUSMINUSRow[] GetAlgasPSRowsT()
        {
            if (DrTotalRow == null)
                throw new Exception("Bad init.");
            var drst = DrTotalRow.GetSALARY_PLUSMINUSRows();
            return drst.ToArray();
        }

        public KlonsADataSet.SALARY_PLUSMINUSRow[] GetAlgasPSRows(int ida)
        {
            return GetAlgasAllPSRows().Where(
                d =>
                !d.IsIDANull() &&
                d.IDA == ida
                ).ToArray();
        }

        public void CheckAlgasPS()
        {
            var table_algas_papildsummas = MyData.DataSetKlons.SALARY_PLUSMINUS;
            var dt1 = SalarySheet.MDT1;
            var dt2 = SalarySheet.MDT2;

            var drs_amps = GetRelevantPersonPSRows();
            var drs_algasps = GetAlgasAllPSRows();

            // delete rows without template
            foreach (var dr in drs_algasps)
            {
                if (dr.IsIDAPNull()) continue;
                var dr2 = drs_amps.Where(
                    d =>
                    d.RowState != DataRowState.Deleted &&
                    d.ID == dr.IDAP
                    ).FirstOrDefault();
                if (dr2 == null)
                {
                    dr.Delete();
                }
            }

            // add rows from template
            // and update rows
            foreach (var dr in drs_amps)
            {
                var dr2 = drs_algasps.Where(
                    d =>
                    d.RowState != DataRowState.Deleted &&
                    !d.IsIDAPNull() &&
                    d.IDAP == dr.ID
                    ).FirstOrDefault();
                if (dr2 == null)
                {
                    dr2 = table_algas_papildsummas.NewSALARY_PLUSMINUSRow();
                    dr2.IDAP = dr.ID;
                    dr2.IDSX = DrTotalRow.IDSX;
                    dr2.IDP = DrTotalRow.IDP;
                }

                if (dr2["IDA"] != dr["IDA"]) dr2["IDA"] = dr["IDA"];
                if (dr2.IDSV != dr.IDSV) dr2.IDSV = dr.IDSV;
                if (dr2.IDNO != dr.IDNO) dr2.IDNO = dr.IDNO;
                if (dr2.DESCR != dr.DESCR) dr2.DESCR = dr.DESCR;
                if (dr2.RATE != dr.RATE) dr2.RATE = dr.RATE;
                if (dr2.RATE_TYPE != dr.RATE_TYPE) dr2.RATE_TYPE = dr.RATE_TYPE;
            }
        }

        public void ChangeIDSXForAlgasPSRows(int new_idsx)
        {
            if (DrTotalRow == null) return;
            var drs_ps = DrTotalRow.GetSALARY_PLUSMINUSRows();
            foreach (var dr in drs_ps)
            {
                if(dr.IDSX != new_idsx)
                    dr.IDSX = new_idsx;
            }
        }

        public void DeleteAlgasPSRows()
        {
            if (DrTotalRow == null)
                throw new Exception("Bad init.");
            var drs_ps = DrTotalRow.GetSALARY_PLUSMINUSRows();
            foreach (var dr in drs_ps)
            {
                dr.Delete();
            }
        }

        public bool GetEventList(ErrorList errorlist, int idp)
        {
            Events = new EventsInfo();
            string ret = Events.ProcessData(idp, SalarySheet.DT1, SalarySheet.DT2);
            if (ret == "OK") return true;
            errorlist.AddPersonError(idp, ret);
            return false;
        }

        public bool IsSingleRow()
        {
            return LinkedRows.Length == 1;
        }

        public ErrorList FillRow()
        {
            var dt1 = SalarySheet.DT1;
            var dt2 = SalarySheet.DT2;

            TotalPersonPay = new SalaryInfo();
            var sci = new SalaryCalcTInfo(this, TotalPersonPay, false);

            var err_list = sci.FillRow();
            if (err_list.HasErrors) return err_list;

            sci.WriteData();
            return err_list;
        }

        public int CountCalendarDays()
        {
            return this.Events.HireFire.CountDates(SalarySheet.DT1, SalarySheet.DT2);
        }

        public TimeSheetRowSetList GetDLRowSetList(int addmt = 0)
        {
            var ret = new TimeSheetRowSetList();
            foreach (var lr in LinkedRows)
                ret.Add(lr.GetDLRowSet(addmt, lr.Row.IDAM));
            return ret;
        }
    }

}