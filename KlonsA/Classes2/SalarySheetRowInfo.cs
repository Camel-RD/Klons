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
    // initialization has to be done as required by called functions

    public class SalarySheetRowInfo
    {
        public static KlonsData MyData => KlonsData.St;

        public SalarySheetRowSetInfo SalarySheetRowSet = null;

        public SalarySheetInfo SalarySheet = null;

        public KlonsADataSet.SALARY_SHEET_TEMPL_RRow DR_salary_sheet_r_templ = null;
        public KlonsADataSet.PERSONS_RRow DR_Person_r = null;

        public KlonsADataSet.SALARY_SHEETS_RRow Row = null;

        public PeriodInfo PersonR = new PeriodInfo();
        public PeriodInfo PositionsR = new PeriodInfo();

        public SalaryInfo TotalPositionPay = null;

        public TimeSheetRowSet DLRows = null;

        public EventsInfo Events = null;

        public SalarySheetRowInfo()
        {
        }

        public SalarySheetRowInfo(SalarySheetInfo salarySheet)
        {
            SalarySheet = salarySheet;
        }

        public SalarySheetRowInfo(SalarySheetInfo salarySheet, KlonsADataSet.SALARY_SHEETS_RRow dr_r)
        {
            SalarySheet = salarySheet;
            Row = dr_r;
        }

        public ErrorList SetUpFromRow(KlonsADataSet.SALARY_SHEETS_RRow dr_r)
        {
            Row = dr_r;
            return SetUp(dr_r.IDP, dr_r.IDAM);
        }

        public ErrorList SetUpFromRowX(KlonsADataSet.SALARY_SHEETS_RRow dr_r)
        {
            Row = dr_r;
            var dr_sar = dr_r.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS;
            var ssh = new SalarySheetInfo(dr_sar);
            SalarySheet = ssh;
            var er = ssh.SetUpLightFromSarRow(dr_sar);
            if (er != "OK")
                return new ErrorList("", er);

            if(dr_r.XType == ESalarySheetRowType.Total)
                return SetUpT(dr_r.IDP);

            if (dr_r.IsIDAMNull())
                throw new Exception("Bad row.");

            return SetUp(dr_r.IDP, dr_r.IDAM);
        }

        public ErrorList SetUpFromSHRow(KlonsADataSet.SALARY_SHEET_TEMPL_RRow dr_sh_r)
        {
            DR_salary_sheet_r_templ = dr_sh_r;
            return SetUp(dr_sh_r.IDP, dr_sh_r.IDAM);
        }

        public void GetPersonRow(int idp)
        {
            var table_persons = MyData.DataSetKlons.PERSONS;
            var dt1 = SalarySheet.MDT1;
            var dt2 = SalarySheet.MDT2;

            var dr_person = table_persons.FindByID(idp);
            var drs_persons_r = dr_person.GetPERSONS_RRows().OrderBy(d => d.EDIT_DATE).ToArray();

            DR_Person_r = PeriodInfo.FindNearestBefore(drs_persons_r,
                dt2, d => d.EDIT_DATE);
        }

        public ErrorList SetUp(int idp, int idam)
        {
            if (SalarySheet == null)
                throw new Exception("Bad init.");

            var table_sar = MyData.DataSetKlons.SALARY_SHEETS;
            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;
            var table_darba_laiks = MyData.DataSetKlons.TIMESHEET;
            var table_sh = MyData.DataSetKlons.SALARY_SHEET_TEMPL;
            var table_sh_r = MyData.DataSetKlons.SALARY_SHEET_TEMPL_R;
            var table_persons = MyData.DataSetKlons.PERSONS;
            var table_amati = MyData.DataSetKlons.POSITIONS;
            var table_dl_sar_r = MyData.DataSetKlons.TIMESHEET_LISTS_R;
            

            var error_list = new ErrorList();
            string error_source;

            int yr = SalarySheet.YR;
            int mt = SalarySheet.MT;
            var dt1 = SalarySheet.MDT1;
            var dt2 = SalarySheet.MDT2;

            //var dv_dl_sar_r = new DataView(table_dl_sar_r);
            //dv_dl_sar_r.RowFilter = string.Format("Parent(FK_TIMESHEET_LISTS_R_IDS).YR = {0} AND Parent(FK_TIMESHEET_LISTS_R_IDS).MT = {1}", yr, mt);

            var dr_person = table_persons.FindByID(idp);
            var dr_amats = table_amati.FindByID(idam);

            if (dr_person == null)
            {
                error_list.AddError("Algas lapa", "Nav darbinieka");
                return error_list;
            }

            if (dr_amats == null)
            {
                error_list.AddError("Algas lapa", "Nav amata");
                return error_list;
            }

            if (DR_salary_sheet_r_templ == null)
            {
                error_source = string.Format("Darbinieks :{0} {1} ({2})",
                    dr_person.FNAME,
                    dr_person.LNAME,
                    dr_amats.TITLE);
            }
            else
            {
                error_source = string.Format("Lapa:{0} rinda:{1}",
                    DR_salary_sheet_r_templ.SALARY_SHEET_TEMPLRow.SNR,
                    DR_salary_sheet_r_templ.SNR);
            }

            var drs_persons_r = dr_person.GetPERSONS_RRows().OrderBy(d => d.EDIT_DATE).ToArray();


            DR_Person_r = PeriodInfo.FindNearestBefore(drs_persons_r,
                dt2, d => d.EDIT_DATE);

            if (DR_Person_r == null)
            {
                error_list.AddError(error_source, "Norādītajam periodam nav ievadīti darbinieka dati.");
                return error_list;
            }

            PersonR.DateFirst = dt1;
            PersonR.DateLast = dt2;

            var drs_person_r = dr_person.GetPERSONS_RRows().OrderBy(d => d.EDIT_DATE).ToArray();

            //var rete = PersonR.ReadDateListFilter(drs_person_r, d => d.EDIT_DATE);
            var rete = PersonR.ReadDateListAll(drs_person_r, d => d.EDIT_DATE);
            if (rete != PeriodInfo.ERetReadStartEndList.OK || PersonR.LinkedPeriods[0].DateFirst > dt2)
            {
                error_list.AddError(error_source, "Norādītajam periodam nav ievadīti darbinieka dati.");
                return error_list;
            }


            PositionsR.DateFirst = dt1;
            PositionsR.DateLast = dt2;

            var drs_amats_r = dr_amats.GetPOSITIONS_RRows().OrderBy(d => d.EDIT_DATE).ToArray();

            rete = PositionsR.ReadDateListFilter(drs_amats_r, d => d.EDIT_DATE);
            if (rete != PeriodInfo.ERetReadStartEndList.OK)
            {
                error_list.AddError(error_source, "Norādītajam periodam nav ievadīti amata dati.");
                return error_list;
            }

            var drs_dl_sar_r = dr_person.GetTIMESHEET_LISTS_RRows()
                .WhereX(
                    d =>
                    d.TIMESHEET_LISTSRow.YR == yr &&
                    d.TIMESHEET_LISTSRow.MT == mt &&
                    d.IDAM == dr_amats.ID)
                 .ToArray();

            if (drs_dl_sar_r.Length == 0)
            {
                error_list.AddError(error_source, "Norādītajam periodam nav darba laika uzskaites datu.");
                return error_list;
            }

            if (drs_dl_sar_r.Length > 1)
            {
                error_list.AddError(error_source, "Darba laika uzskaites datu rindu skaits > 1.");
                return error_list;
            }

            var dr_dl_sar_r = drs_dl_sar_r[0];

            var dlrowset = dr_dl_sar_r.GetDLRowSet();
            DLRows = dlrowset;
            SetDLRows(dlrowset);

            if (DLRows == null || DLRows.Plan == null || DLRows.Fact == null ||
                (dr_dl_sar_r.NIGHT == 1 && (DLRows.PlanNight == null || DLRows.FactNight == null)) ||
                (dr_dl_sar_r.OVERTIME == 1 && DLRows.FactOvertime == null))
            {
                error_list.AddError(error_source, "Nekorekti darba laika uzskaites dati.");
                return error_list;
            }

            if(Events == null)
            {
                if (!GetEventList(error_list, idp))
                {
                    return error_list;
                }
            }

            if(IsRateTypeChangedDuringVacation(drs_amats_r))
            {
                error_list.AddError(error_source, "Atvaļinājuma laikā nevar mainīt algas likmes veidu.");
            }

            var err1 = CheckVacationTimePlan(idam);
            if(err1 != "OK")
            {
                error_list.AddError(error_source, err1);
                return error_list;
            }

            if(Row != null)
            {
                TotalPositionPay = new SalaryInfo();
                TotalPositionPay.SetFromRow(Row);
            }

            return error_list;
        }

        public ErrorList SetUpT(int idp)
        {
            if (SalarySheet == null)
                throw new Exception("Bad init.");

            var table_sar = MyData.DataSetKlons.SALARY_SHEETS;
            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;
            var table_persons = MyData.DataSetKlons.PERSONS;

            var error_list = new ErrorList();
            string error_source;

            int yr = SalarySheet.YR;
            int mt = SalarySheet.MT;
            var dt1 = SalarySheet.MDT1;
            var dt2 = SalarySheet.MDT2;

            var dr_person = table_persons.FindByID(idp);

            if (dr_person == null)
            {
                error_list.AddError("Algas lapa", "Nav darbinieka");
                return error_list;
            }

            error_source = string.Format("Darbinieks :{0} {1})",
                dr_person.FNAME,
                dr_person.LNAME);

            var drs_persons_r = dr_person.GetPERSONS_RRows().OrderBy(d => d.EDIT_DATE).ToArray();


            DR_Person_r = PeriodInfo.FindNearestBefore(drs_persons_r,
                dt2, d => d.EDIT_DATE);

            if (DR_Person_r == null)
            {
                error_list.AddError(error_source, "Norādītajam periodam nav ievadīti darbinieka dati.");
                return error_list;
            }

            PersonR.DateFirst = dt1;
            PersonR.DateLast = dt2;

            var drs_person_r = dr_person.GetPERSONS_RRows().OrderBy(d => d.EDIT_DATE).ToArray();

            //var rete = PersonR.ReadDateListFilter(drs_person_r, d => d.EDIT_DATE);
            var rete = PersonR.ReadDateListAll(drs_person_r, d => d.EDIT_DATE);
            if (rete != PeriodInfo.ERetReadStartEndList.OK || PersonR.LinkedPeriods[0].DateFirst > dt2)
            {
                error_list.AddError(error_source, "Norādītajam periodam nav ievadīti darbinieka dati.");
                return error_list;
            }

            if (Events == null)
            {
                if (!GetEventList(error_list, idp))
                {
                    return error_list;
                }
            }

            if (Row != null)
            {
                TotalPositionPay = new SalaryInfo();
                TotalPositionPay.SetFromRow(Row);
            }

            return error_list;
        }

        //summētais <= => akordalga
        public IEnumerable<DateTime> GetPositionRateTypeChangeList(KlonsADataSet.POSITIONS_RRow[] drs_amats_r)
        {
            /*
            var table_amati = MyData.DataSetKlons.POSITIONS;
            int idam = Row.IDAM;
            var dr_amats = table_amati.FindByID(idam);
            var drs_amats_r = dr_amats.GetPOSITIONS_RRows().OrderBy(d => d.EDIT_DATE).ToArray();
            */
            if (drs_amats_r.Length <= 1) yield break;
            var tp1 = drs_amats_r[0].XRateType;
            bool b1 = tp1 == ESalaryType.Aggregated;
            for (int i = 1; i < drs_amats_r.Length; i++)
            {
                var tp2 = drs_amats_r[i].XRateType;
                bool b2 = tp2 == ESalaryType.Aggregated;
                if (b1 == b2) continue;
                var dt = drs_amats_r[i].EDIT_DATE;
                yield return dt;
                tp1 = tp2;
                b1 = b2;
            }
        }

        public bool IsRateTypeChangedDuringVacation(KlonsADataSet.POSITIONS_RRow[] drs_amats_r)
        {
            if (Events.Vacations.LinkedPeriods.Count == 0) return false;
            var dts = GetPositionRateTypeChangeList(drs_amats_r);
            foreach (var dt in dts)
                foreach (var lp in Events.Vacations.LinkedPeriods)
                    if (lp.ContainsDate(dt)) return true;
            return false;
        }

        public bool GetLastHireDate(DateTime dt, out DateTime hdt)
        {
            hdt = DateTime.MinValue;
            if (Events == null)
                throw new Exception("Bad call");
            var pi = Events.HireFire.LinkedPeriods.Where(p => p.ContainsDate(dt)).FirstOrDefault();
            if (pi == null) return false;
            hdt = pi.DateFirst;
            return true;
        }

        public TimeSheetRowSet GetDLRowSet(int addmt, int idam)
        {
            if (addmt == 0) return DLRows;
            int yr = SalarySheet.YR;
            int mt = SalarySheet.MT;
            Utils.AddMonths(ref yr, ref mt, addmt);
            return GetDLRowSet(yr, mt, idam);
        }

        public TimeSheetRowSetList GetDLRowSetList(int addmt = 0)
        {
            if (IsSingleRow())
            {
                var ret = new TimeSheetRowSetList();
                if (addmt == 0)
                {
                    ret.Add(DLRows);
                }
                else
                {
                    int yr = SalarySheet.YR;
                    int mt = SalarySheet.MT;
                    Utils.AddMonths(ref yr, ref mt, addmt);
                    int idam = Row.IDAM;
                    ret.Add(GetDLRowSet(yr, mt, idam));
                }
                return ret;
            }
            else
            {
                return SalarySheetRowSet?.GetDLRowSetList(addmt);
            }
        }

        public TimeSheetRowSet GetDLRowSet(int yr, int mt, int idam)
        {
            var drs_dl_sar_r = DR_Person_r.PERSONSRow.GetTIMESHEET_LISTS_RRows()
                .WhereX(
                    d =>
                    d.TIMESHEET_LISTSRow.YR == yr &&
                    d.TIMESHEET_LISTSRow.MT == mt &&
                    d.IDAM == idam)
                 .ToArray();
            if (drs_dl_sar_r.Length == 0) return null;
            return drs_dl_sar_r[0].GetDLRowSet();
        }


        public SalaryInfo GetPrevRow()
        {
            if (Row.XType != ESalarySheetRowType.Total) return GetPrevRowA();

            var dt1 = SalarySheet.DT1;
            var dt2 = SalarySheet.DT2;
            var idp = Row.IDP;
            var id = Row.ID;
            var dtp1 = dt2.FirstDayOfMonth().AddMonths(-1);
            var dtp2 = dtp1.LastDayOfMonth();
            var table_lapas_r = MyData.DataSetKlons.SALARY_SHEETS_R;

            var dr_lapas_r = table_lapas_r.WhereX(
                d =>
                d.ID != id &&
                d.IDP == idp &&
                d.IsIDAMNull() &&
                d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.DT2 >= dtp1 &&
                d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.DT2 <= dtp2 &&
                d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.IS_TEMP == 0 &&
                d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.XKind == ESalarySheetKind.Total
            ).WithMaxOrDefault(d => d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.DT2);

            if (dr_lapas_r == null) return null;

            var ret = new SalaryInfo();
            ret.SetFromRow(dr_lapas_r);
            return ret;
        }

        private SalaryInfo GetPrevRowA()
        {
            var dt1 = SalarySheet.DT1;
            var dt2 = SalarySheet.DT2;
            var idp = Row.IDP;
            var idam = Row["IDAM"];
            var id = Row.ID;
            var dtp1 = dt2.FirstDayOfMonth().AddMonths(-1);
            var dtp2 = dtp1.LastDayOfMonth();
            var table_lapas_r = MyData.DataSetKlons.SALARY_SHEETS_R;

            var dr_lapas_r = table_lapas_r.WhereX(
                d =>
                d.ID != id &&
                d.IDP == idp &&
                object.Equals(d["IDAM"], idam) &&
                d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.DT2.IsBetween(dtp1, dtp2) &&
                d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.IS_TEMP == 0 &&
                d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.XKind != ESalarySheetKind.Total
            ).WithMaxOrDefault(d => d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.DT2);

            if (dr_lapas_r == null) return null;

            var dtm = dr_lapas_r.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS.DT2;

            var ret = new SalaryInfo();
            ret.SetFromRow(dr_lapas_r);
            return ret;
        }

        public bool GetRow(int addmt, out SalarySheetRowInfo row)
        {
            row = null;
            var table_sar = MyData.DataSetKlons.SALARY_SHEETS;
            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;

            int yr = SalarySheet.YR;
            int mt = SalarySheet.MT;

            Utils.AddMonths(ref yr, ref mt, addmt);

            int idp = Row.IDP;
            int idam = Row.IDAM;

            var drs = table_sar_r.WhereX(
                d =>
                {
                    var dr_sar = d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS;
                    return
                        d.IDP == idp &&
                        d.IDAM == idam &&
                        dr_sar.YR == yr &&
                        dr_sar.MT == mt;
                }).ToArray();

            if (drs.Length == 0) return true;
            var dr = drs[0];

            var shr = new SalarySheetRowInfo();
            var err = shr.SetUpFromRowX(dr);
            if (err != null && err.Count > 0)
            {
                return false;
            }

            row = shr;

            return true;
        }

        public ErrorList CheckLinkedRows(int idp, bool force = false)
        {
            if (SalarySheetRowSet != null && !force) return new ErrorList();
            SalarySheetRowSet = new SalarySheetRowSetInfo();
            return SalarySheetRowSet.SetUpFromRowA(this);
        }

        public void MakeRowFromSH()
        {
            if (DR_salary_sheet_r_templ == null)
                throw new Exception("Shablon row not set.");
            MakeRow(DR_salary_sheet_r_templ.IDP, DR_salary_sheet_r_templ.IDAM, DR_salary_sheet_r_templ.SNR);
        }

        public string GetPositionTitle(int idam)
        {
            var dr_amats = MyData.DataSetKlons.POSITIONS.FindByID(idam);
            if (dr_amats == null) return null;
            return dr_amats.TITLE;
        }

        public string GetPositionTitle()
        {
            if (Row == null) return null;
            if (Row.XType == ESalarySheetRowType.Total) return "KOPĀ";
            if (Row.IsIDAMNull()) return null;
            var dr_amats = MyData.DataSetKlons.POSITIONS.FindByID(Row.IDAM);
            if (dr_amats == null) return null;
            return dr_amats.TITLE;
        }

        public void MakeRow(int idp, int idam, int snr)
        {
            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;
            var new_dr_sar_r = table_sar_r.NewSALARY_SHEETS_RRow();

            new_dr_sar_r.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_SALARY_SHEETS_R_ID();
            new_dr_sar_r.IDSX = new_dr_sar_r.ID;
            new_dr_sar_r.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS = SalarySheet.DR_algas_lapa;
            new_dr_sar_r.IDP = idp;
            new_dr_sar_r.IDAM = idam;
            new_dr_sar_r.SNR = (short)snr;
            new_dr_sar_r.FNAME = DR_Person_r.FNAME;
            new_dr_sar_r.LNAME = DR_Person_r.LNAME;
            new_dr_sar_r.IS_TEMP = SalarySheet.DR_algas_lapa.IS_TEMP;

            var s1 = GetPositionTitle(idam);
            if (s1 != null)
                new_dr_sar_r.POSITION_TITLE = s1;


            table_sar_r.Rows.Add(new_dr_sar_r);

            Row = new_dr_sar_r;

            CheckLinkedRows(Row.IDP);
            CheckAlgasPS();

        }


        private void SetIntValue(ref int rec, int src)
        {
            if (rec != src) rec = src;
        }


        public KlonsADataSet.POSITIONS_PLUSMINUSRow[] GetRelevantPersonPSRows()
        {
            var dt1 = SalarySheet.MDT1;
            var dt2 = SalarySheet.MDT2;

            var drs_amps = DR_Person_r.PERSONSRow.GetPOSITIONS_PLUSMINUSRows().WhereX(
                d =>
                d.DATE1 <= dt2 &&
                d.DATE2 >= dt1
                ).ToArray();

            return drs_amps;
        }

        public KlonsADataSet.SALARY_SHEETS_RRow GetTotalRow()
        {
            if (Row.IsIDSXNull()) return null;
            if (IsSingleRow()) return Row;
            return MyData.DataSetKlons.SALARY_SHEETS_R.FindByID(Row.IDSX);
        }

        public KlonsADataSet.SALARY_PLUSMINUSRow[] GetAlgasAllPSRows()
        {
            var totalrow = GetTotalRow();
            if (totalrow != null)
            {
                var drs = totalrow.GetSALARY_PLUSMINUSRows()
                    .WhereX(_d => true)
                    .OrderBy(_d => _d.ID)
                    .ToArray();
                return drs;
            }

            var drs2 = Row.GetSALARY_PLUSMINUSRows()
                .WhereX(_d => true)
                .OrderBy(_d => _d.ID)
                .ToArray();
            return drs2;
        }

        public KlonsADataSet.SALARY_PLUSMINUSRow[] GetAlgasPSRowsT()
        {
            return GetAlgasAllPSRows().Where(
                d => d.IsIDANull()
                ).ToArray();
        }

        public KlonsADataSet.SALARY_PLUSMINUSRow[] GetAlgasPSRows(int ida)
        {
            return GetAlgasAllPSRows().Where(
                d => 
                !d.IsIDANull() &&
                d.IDA == ida
                ).ToArray();
        }

        public KlonsADataSet.SALARY_PLUSMINUSRow[] GetAlgasPSRowsX(int ida)
        {
            return GetAlgasAllPSRows().Where(
                d =>
                d.IsIDANull() ||
                (!d.IsIDANull() &&
                d.IDA == ida)
                ).ToArray();
        }

        public void CheckAlgasPS()
        {
            var table_algas_papildsummas = MyData.DataSetKlons.SALARY_PLUSMINUS;
            var dt1 = SalarySheet.MDT1;
            var dt2 = SalarySheet.MDT2;

            var drs_amps = GetRelevantPersonPSRows();
            var drs_algasps = GetAlgasAllPSRows();

            List<DataRow> del_rows = new List<DataRow>();

            // delete rows without template
            foreach(var dr in drs_algasps)
            {
                if (dr.IsIDAPNull()) continue;
                var dr2 = drs_amps.WhereX(
                    d =>
                    d.ID == dr.IDAP
                    ).FirstOrDefault();
                if(dr2 == null)
                    del_rows.Add(dr);
            }
            foreach (var dr in del_rows)
                dr.Delete();

            // add rows from template
            // and update rows
            foreach (var dr in drs_amps)
            {
                var dr2 = drs_algasps.WhereX(
                    d =>
                    !d.IsIDAPNull() &&
                    d.IDAP == dr.ID
                    ).FirstOrDefault();
                if (dr2 == null)
                {
                    dr2 = table_algas_papildsummas.NewSALARY_PLUSMINUSRow();
                    dr2.IDAP = dr.ID;
                    dr2.IDSX = Row.IDSX;
                    dr2.IDP = Row.IDP;
                }

                if (dr2["IDA"] != dr["IDA"]) dr2["IDA"] = dr["IDA"];
                if (dr2.IDSV != dr.IDSV) dr2.IDSV = dr.IDSV;
                if (dr2.IDNO != dr.IDNO) dr2.IDNO = dr.IDNO;
                if (dr2.DESCR != dr.DESCR) dr2.DESCR = dr.DESCR;
                if (dr2.RATE != dr.RATE) dr2.RATE = dr.RATE;
                if (dr2.RATE_TYPE != dr.RATE_TYPE) dr2.RATE_TYPE = dr.RATE_TYPE;
                if (dr2.IS_PAID != dr.IS_PAID) dr2.IS_PAID = dr.IS_PAID;
                if (dr2.IS_INAVPAY != dr.IS_INAVPAY) dr2.IS_INAVPAY = dr.IS_INAVPAY;
            }
        }

        public void ChangeIDSXForAlgasPSRows(int new_idsx)
        {
            var drs_ps = Row.GetSALARY_PLUSMINUSRows();
            foreach(var dr in drs_ps)
            {
                dr.IDSX = new_idsx;
            }
        }

        public void DeleteAlgasPSRows()
        {
            var drs_ps = Row.GetSALARY_PLUSMINUSRows();
            foreach (var dr in drs_ps)
            {
                dr.Delete();
            }
        }

        public void SetDLRows(TimeSheetRowSet dlrowset)
        {
            DLRows = dlrowset;
        }

        public bool GetEventList(ErrorList errorlist, int idp)
        {
            Events = new EventsInfo();
            string ret = Events.ProcessData(idp, SalarySheet.DT1, SalarySheet.DT2);
            if (ret == "OK") return true;
            errorlist.AddPersonError(idp, ret);
            return false;
        }

        public int GetLinkedRowsCount()
        {
            if (SalarySheetRowSet == null || SalarySheetRowSet.DrLinkedRows == null)
                return 1;
            return SalarySheetRowSet.DrLinkedRows.Length;
        }

        public bool IsSingleRow()
        {
            return GetLinkedRowsCount() == 1;
        }

        public ErrorList FillRowX()
        {
            var err = CheckLinkedRows(Row.IDP);
            if (err.HasErrors) return err;
            err = SalarySheetRowSet.FillRow();
            return err;
        }

        public int CountCalendarDays()
        {
            return this.Events.HireFire.CountDates(SalarySheet.DT1, SalarySheet.DT2);
        }

        public string CheckVacationTimePlan(int idam)
        {
            var dt1 = SalarySheet.DT1;
            var dt2 = SalarySheet.DT2;
            var mdt1 = SalarySheet.MDT1;
            var mdt2 = SalarySheet.MDT2;

            var ps = Events.Vacations.LinkedPeriods.Where(
                d =>
                {
                    if (!SomeDataDefs.IsEventPaidVacation(d.EEventId)) return false;

                    var dr_not = (d.Item1 as KlonsADataSet.EVENTSRow);
                    if (dr_not.IsDATE3Null()) return false;

                    return (d.DateFirst <= dt2 && d.DateLast >= dt1) ||
                        (dr_not.DATE3 >= dt1 && dr_not.DATE3 <= dt2);
                }).ToArray();


            if (ps.Length == 0) return "OK";

            var ps_next = ps.Where(
                d =>
                {
                    var dr_not = (d.Item1 as KlonsADataSet.EVENTSRow);
                    if (dr_not.IsDATE3Null()) return false;
                    return (d.DateLast > dt2) &&
                        (dr_not.DATE3 >= dt1 && dr_not.DATE3 <= dt2);
                }).ToArray();


            foreach (var pi in ps_next)
            {
                var dtp1 = dt2.AddDays(1);
                var dtp2 = pi.DateLast;
                if (dtp1 < pi.DateFirst) dtp1 = pi.DateFirst;
                var dtpe = dtp1.LastDayOfMonth();
                if (dtp2 > dtpe) dtp2 = dtpe;

                while (true)
                {
                    int addmt = Utils.MonthDiff(dt1, dtp1);

                    var nextdlrowset = GetDLRowSet(addmt, idam);
                    if (nextdlrowset == null || nextdlrowset.Plan == null)
                        return "Atvaļinājumam nav izveidots darba laika plāns.";

                    if (dtp2 == pi.DateLast) break;

                    dtp1 = dtpe.AddDays(1);
                    dtp2 = pi.DateLast;
                    dtpe = dtp1.LastDayOfMonth();
                    if (dtp2 > dtpe) dtp2 = dtpe;
                }

            }

            return "OK";
        }


        public TimeSheetRowSet[] GetAllDLRowSet()
        {
            if (SalarySheet == null || Row == null)
                throw new Exception("Bad initialization.");
            return Row.PERSONSRow.GetTIMESHEET_LISTS_RRows().WhereX(d =>
            {
                var dr_sar = d.TIMESHEET_LISTSRow;
                return dr_sar.YR == SalarySheet.YR &&
                    dr_sar.MT == SalarySheet.MT;
            }).Select(d => d.GetDLRowSet())
            .ToArray();
        }

    }

}
