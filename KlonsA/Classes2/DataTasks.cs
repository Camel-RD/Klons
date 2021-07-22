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
    public static class DataTasks
    {
        public static KlonsData MyData => KlonsData.St;

        public static string GetPositionTitle(int idam)
        {
            var dr_am = MyData.DataSetKlons.POSITIONS.FindByID(idam);
            if (dr_am == null) return null;
            return dr_am.TITLE;
        }

        public static string[] GetPersonNameAndPK(int idp)
        {
            var dr_p = MyData.DataSetKlons.PERSONS.FindByID(idp);
            if (dr_p == null) return null;
            return new[] { dr_p.FNAME, dr_p.LNAME, dr_p.PK };
        }

        public static string GetPersonName(int idp)
        {
            var sr = GetPersonNameAndPK(idp);
            if (sr == null) return null;
            return sr[0] + " " + sr[1];
        }

        public static string[] GetFPPersonNameAndPK(int idp)
        {
            var dr_p = MyData.DataSetKlons.PERSONS_FIZ.FindByID(idp);
            if (dr_p == null) return null;
            return new[] { dr_p.FNAME, dr_p.LNAME, dr_p.PK };
        }

        public static KlonsADataSet.RATESRow GetRates(DateTime dt1)
        {
            return MyData.DataSetKlons.RATES
                .WhereX(d => d.ONDATE <= dt1)
                .WithMaxOrDefault(d => d.ONDATE);
        }

        public static KlonsADataSet.PERSONS_RRow GetPersonsR(int idp, DateTime dt1)
        {
            var dr_p = MyData.DataSetKlons.PERSONS.FindByID(idp);
            if (dr_p == null) return null;
            return dr_p.GetPERSONS_RRows()
                .Where(d => d.EDIT_DATE <= dt1)
                .WithMaxOrDefault(d => d.EDIT_DATE);
        }

        public static bool IsPersonWorking(int idp, DateTime dt1, DateTime dt2)
        {
            var table_persons = KlonsData.St.DataSetKlons.PERSONS;
            var dr_person = table_persons.FindByID(idp);
            if (dr_person == null) return false;
            var drs_events = dr_person.GetEVENTSRows();
            var drsn_hirefire = drs_events.Where(d =>
            {
                return
                    Utils.IN(d.IDN, (int)EEventId.Pieņemts, (int)EEventId.Atlaists);
            }).OrderBy(d => d.DATE1).ToArray();

            if (drsn_hirefire.Length == 0)
                return false;

            var pi_hirefire = new PeriodInfo();

            var rt1 = pi_hirefire.ReadStartEndList(drsn_hirefire,
                isStartItem: it => it.IDN == (int)EEventId.Pieņemts,
                getItemDate: it => it.DATE1);

            if (rt1 != PeriodInfo.ERetReadStartEndList.OK) return false;

            var pi_f = pi_hirefire.FilterListWithDates(dt1, dt2);
            return pi_f.LinkedPeriods.Count > 0;
        }

        //vai ir nodokļu gr uz perioda 1. datumu vai darbā stāšanās datumu
        public static bool IsPersonWithTaxDoc(int idp, DateTime dt1, DateTime dt2)
        {
            var table_persons = KlonsData.St.DataSetKlons.PERSONS;
            var dr_person = table_persons.FindByID(idp);
            if (dr_person == null) return false;
            var drs_events = dr_person.GetEVENTSRows();
            var drsn_hirefire = drs_events.Where(d =>
            {
                return
                    Utils.IN(d.IDN, (int)EEventId.Pieņemts, (int)EEventId.Atlaists);
            }).OrderBy(d => d.DATE1).ToArray();

            if (drsn_hirefire.Length == 0)
                return false;

            var pi_hirefire = new PeriodInfo();

            var rt1 = pi_hirefire.ReadStartEndList(drsn_hirefire,
                isStartItem: it => it.IDN == (int)EEventId.Pieņemts,
                getItemDate: it => it.DATE1);

            if (rt1 != PeriodInfo.ERetReadStartEndList.OK) return false;

            var pi_f = pi_hirefire.FilterListWithDates(dt1, dt2);
            if(pi_f.LinkedPeriods.Count == 0) return false;

            var pi1 = pi_f.LinkedPeriods[0];
            var dtx = pi1.DateFirst;
            var dr_porsonR =
                dr_person.GetPERSONS_RRows()
                .Where(d => d.EDIT_DATE <= dtx)
                .WithMaxOrDefault(d => d.EDIT_DATE);
            if (dr_porsonR == null) return false;
            return !string.IsNullOrEmpty(dr_porsonR.TAXDOC_NO);
        }

        public static short GetNextSalarySheetNr(int yr)
        {
            var table_sar = MyData.DataSetKlons.SALARY_SHEETS;
            var e1 = table_sar.WhereX(d => d.YR == yr);
            if (e1.FirstOrDefault() == null) return 1;
            return (short)(e1.Max(d => d.SNR) + 1);
        }

        public static List<int> CheckSalarySheetsTemplUsed(int yr, int mt, KlonsADataSet.SALARY_SHEET_TEMPLRow[] drs_sh)
        {
            var ret = new List<int>();
            var table_sar = MyData.DataSetKlons.SALARY_SHEETS;
            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;
            var dt1 = new DateTime(yr, mt, 1);
            var dt2 = dt1.LastDayOfMonth();
            var drs_tsr = table_sar.WhereX(
                d =>
                d.XKind == ESalarySheetKind.Normal &&
                d.DT2 == dt2
                ).SelectMany(d => d.GetSALARY_SHEETS_RRowsByFK_SALARY_SHEETS_R_IDS())
                .ToArray();
            foreach (var dr_sh in drs_sh)
            {
                var drs_sh_r = dr_sh.GetSALARY_SHEET_TEMPL_RRows();
                foreach (var dr_sh_r in drs_sh_r)
                {
                    var drs_cur = drs_tsr.WhereX(
                        d =>
                        !d.IsIDPNull() &&
                        !d.IsIDAMNull() &&
                        d.IDP == dr_sh_r.IDP &&
                        d.IDAM == dr_sh_r.IDAM);
                    if (drs_cur.Any())
                        if (!ret.Contains(dr_sh_r.IDAM))
                            ret.Add(dr_sh_r.IDAM);
                }
            }
            return ret;
        }

        public static ErrorList MakeSalarySheetsFromTemplate(int yr, int mt, int idsh = int.MinValue)
        {
            var table_sar = MyData.DataSetKlons.SALARY_SHEETS;
            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;
            var table_sh = MyData.DataSetKlons.SALARY_SHEET_TEMPL;
            var table_sh_r = MyData.DataSetKlons.SALARY_SHEET_TEMPL_R;

            var error_list = new ErrorList();

            var this_error_source = string.Format("Algu apr. {0}.{1:00}", yr, mt);

            if (table_sh.Count == 0 || table_sh_r.Count == 0)
            {
                error_list.AddError(this_error_source, "Nav izveidotas lapu saraksta sagataves.");
                return error_list;
            }

            KlonsADataSet.SALARY_SHEET_TEMPLRow[] drs_sh;
            if (idsh > int.MinValue)
                drs_sh = new[] { table_sh.FindByID(idsh) };
            else
                drs_sh = table_sh.WhereX(_ => true).OrderBy(d => d.SNR).ToArray();

            if (drs_sh.Length == 0 || drs_sh[0] == null)
            {
                error_list.AddError(this_error_source, "Nav atrastas lapu saraksta sagataves.");
                return error_list;
            }

            var dt2 = (new DateTime(yr, mt, 1)).LastDayOfMonth();

            var cur_idam = CheckSalarySheetsTemplUsed(yr, mt, drs_sh);
            if (cur_idam.Count > 0)
            {
                var drp = MyData.DataSetKlons.POSITIONS.FindByID(cur_idam[0]).PERSONSRow;
                string ser = "";
                if (cur_idam.Count == 1)
                    ser = $"Algas aprēķins priekš darbinieka {drp.YNAME} ir jau izveidots.";
                else
                    ser = $"Algas aprēķins priekš darbinieka {drp.YNAME} \nun vēl {cur_idam.Count - 1} darbiniekiem ir jau izveidots.";
                error_list.AddError(this_error_source, ser);
                return error_list;
            }


            var salary_sheet_list = new List<SalarySheetInfo>();
            var m_salary_sheet = new SalarySheetInfo(yr, mt);

            var ret = m_salary_sheet.GetLikmes();

            if (ret != "OK")
            {
                error_list.AddError(this_error_source, ret);
                return error_list;
            }


            foreach (var dr_sh in drs_sh)
            {
                var salary_sheet = new SalarySheetInfo(m_salary_sheet);
                var err = salary_sheet.SetUpFromSHRow(dr_sh);

                salary_sheet_list.Add(salary_sheet);

                if (err.Count > 0)
                {
                    error_list.AddRange(err);
                    continue;
                }
            }

            if (error_list.Count > 0)
                return error_list;

            short snr0 = GetNextSalarySheetNr(yr);

            foreach (var salary_sheet in salary_sheet_list)
            {
                salary_sheet.MakeSheetFromSh(snr0);
                var err = salary_sheet.FillSheet();
                error_list.AddRange(err);
                snr0++;
            }

            return error_list;
        }

        public static ErrorList MakeSalarySheetRow(KlonsADataSet.SALARY_SHEETSRow dr_lapa, int idp, int idam, int snr)
        {
            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;

            var error_list = new ErrorList();
            var this_error_source = string.Format("Algu apr.");

            var salary_sheet = new SalarySheetInfo(dr_lapa);
            var ret = salary_sheet.GetLikmes();
            if (ret != "OK")
            {
                error_list.AddError(this_error_source, ret);
                return error_list;
            }


            var salary_sheet_row = new SalarySheetRowInfo(salary_sheet);
            var err = salary_sheet_row.SetUp(idp, idam);

            if (err.Count > 0)
            {
                error_list.AddRange(err);
                return error_list;
            }

            salary_sheet.CheckTotalListForPeriod();
            salary_sheet_row.MakeRow(idp, idam, snr);

            err = salary_sheet_row.FillRowX();

            error_list.AddRange(err);

            return error_list;
        }

        public static void DeleteSalarySheetRow(KlonsADataSet.SALARY_SHEETS_RRow dr_lapas_r)
        {
            var table_algas_ps = MyData.DataSetKlons.SALARY_PLUSMINUS;
            var salary_sheet = new SalarySheetInfo(dr_lapas_r.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS);
            salary_sheet.DeleteRow(dr_lapas_r);
        }


        public static void DeleteSalarySheet(KlonsADataSet.SALARY_SHEETSRow dr_lapa)
        {
            var salary_sheet = new SalarySheetInfo(dr_lapa);
            salary_sheet.DeleteList();
        }

        public static ErrorList CalcSalarySheetRow(int idsr)
        {
            var table_sar = MyData.DataSetKlons.SALARY_SHEETS;
            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;

            var error_list = new ErrorList();

            var dr_sar_r = table_sar_r.FindByID(idsr);
            if(dr_sar_r == null)
            {
                error_list.AddError("", "Nav algas aprēķina.");
                return error_list;
            }

            var sshr = new SalarySheetRowSetInfo();
            var err = sshr.SetUpFromRowX(dr_sar_r);

            if (err.Count > 0)
            {
                error_list += err;
                return error_list;

            }

            err = sshr.FillRow();
            if (err.Count > 0)
            {
                error_list += err;
                return error_list;

            }

            return error_list;
        }

        public static ErrorList CalcSalarySheet(int ids)
        {
            var table_sar = MyData.DataSetKlons.SALARY_SHEETS;
            var table_sar_r = MyData.DataSetKlons.SALARY_SHEETS_R;

            var error_list = new ErrorList();

            var dr_sar = table_sar.FindByID(ids);
            if (dr_sar == null)
            {
                error_list.AddError("", "Nav algas aprēķina.");
                return error_list;
            }

            var ssh = new SalarySheetInfo(dr_sar);
            var er = ssh.SetUpLightFromSarRow(dr_sar);
            if(er != "OK")
            {
                error_list.AddError("", er);
                return error_list;
            }

            var drs_sar_r = dr_sar.GetSALARY_SHEETS_RRowsByFK_SALARY_SHEETS_R_IDS();

            foreach (var dr_sar_r in drs_sar_r)
            {
                var sshr = new SalarySheetRowSetInfo();
                var err = sshr.SetUpFromRowB(ssh, dr_sar_r.IDP);
                error_list += err;
                if (err.Count > 0) continue;
                error_list += sshr.FillRow();
            }

            return error_list;
        }

        public static string CheckPlans(int yr, int mt)
        {
            var table_plans = MyData.DataSetKlons.TIMEPLAN_LIST;
            var table_darba_laiks = MyData.DataSetKlons.TIMESHEET;
            var table_sh_r = MyData.DataSetKlons.TIMESHEET_TEMPL_R;
            var row_list_pl = new List<KlonsADataSet.TIMEPLAN_LISTRow>();
            foreach (var dr in table_sh_r)
            {
                var dr_pl = table_plans.FindByID(dr.IDPL);
                if (row_list_pl.Contains(dr_pl)) continue;
                row_list_pl.Add(dr_pl);
            }
            foreach (var dr in row_list_pl)
            {
                var ret = CheckPlan(dr, yr, mt);
                if (ret != "OK")
                    return string.Format("Nav izveidots plāns [{0}]", dr.DESCR);
            }
            return "OK";
        }

        public static string CheckPlan(int idpl, int yr, int mt)
        {
            var table_plans = MyData.DataSetKlons.TIMEPLAN_LIST;
            var dr_pl = table_plans.FindByID(idpl);
            return CheckPlan(dr_pl, yr, mt);
        }

        public static string CheckPlan(KlonsADataSet.TIMEPLAN_LISTRow dr_pl,
            int yr, int mt)
        {
            var drs_dl_pl = dr_pl.GetTIMESHEETRows().WhereX(
                d=>
                d.YR == yr &&
                d.MT == mt
                ).ToArray();

            int rownr_plan_day = -1;
            int rownr_plan_night = -1;

            for (int i = 0; i < drs_dl_pl.Length; i++)
            {
                var dr_dl = drs_dl_pl[i];
                if (dr_dl.XKind1 == EKind1.PlanGroupDay)
                    rownr_plan_day = i;
                if (dr_dl.XKind1 == EKind1.PlanGroupaNight)
                    rownr_plan_night = i;
            }
            if (rownr_plan_day == -1 || (dr_pl.NIGHT == 1 && rownr_plan_night == -1))
                return string.Format("Nav izveidots plāns [{0}]", dr_pl.DESCR);

            return "OK";
        }

        public static void MakePlans(CalendarMonthInfo calmt)
        {
            var table_darba_laiks = MyData.DataSetKlons.TIMESHEET;
            var table_plans = MyData.DataSetKlons.TIMEPLAN_LIST;
            float[] hr;
            EDayTag[] daytags;
            int i, v1_colnr, d1_colnr;
            short snr = 1;

            v1_colnr = table_darba_laiks.V1Column.Ordinal;
            d1_colnr = table_darba_laiks.D1Column.Ordinal;

            var drs_pl = table_plans.WhereX(d => d.USED == 1).ToArray();

            foreach (var dr in drs_pl)
            {
                hr = calmt.MakeHours(dr, false);
                daytags = calmt.MakeDayTags(dr);

                var dr1 = table_darba_laiks.NewTIMESHEETRow();
                dr1.IDP = dr.ID;
                dr1.XKind1 = EKind1.PlanGroupDay;
                dr1.YR = calmt.Year;
                dr1.MT = calmt.Month;
                dr1.SNR = snr;
                snr++;

                for (i = 0; i < 31; i++)
                {
                    dr1[i + v1_colnr] = hr[i];
                    switch (daytags[i])
                    {
                        case EDayTag.None:
                            dr1.DxPlan[i] = EDayPlanId.None;
                            break;
                        case EDayTag.WorkDay:
                        case EDayTag.WorkDayBeforeHoliday:
                            dr1.DxPlan[i] = EDayPlanId.DD;
                            break;
                        case EDayTag.HolidayInFreeDay:
                            dr1.DxPlan[i] = EDayPlanId.SD;
                            break;
                        case EDayTag.HolidayInWorkDay:
                            dr1.DxPlan[i] = EDayPlanId.SDDD;
                            break;
                        case EDayTag.FreeDay:
                            dr1.DxPlan[i] = EDayPlanId.BD;
                            break;
                    }

                }
                dr1.K1 = dr1.SumV();

                table_darba_laiks.Rows.Add(dr1);

                if (dr.NIGHT == 1)
                {
                    var dr2 = table_darba_laiks.NewTIMESHEETRow();
                    dr2.IDP = dr.ID;
                    dr2.XKind1 = EKind1.PlanGroupaNight;
                    dr2.YR = calmt.Year;
                    dr2.MT = calmt.Month;
                    dr2.SNR = snr;

                    hr = calmt.MakeHours(dr, true);

                    dr2.SetAllVx(hr);
                    dr2.K1 = dr2.SumV();

                    snr++;
                    table_darba_laiks.Rows.Add(dr2);
                }
            }
        }

        public static void FillPlans(CalendarMonthInfo calmt, KlonsADataSet.TIMESHEETRow dr)
        {
            var table_darba_laiks = MyData.DataSetKlons.TIMESHEET;
            var table_plans = MyData.DataSetKlons.TIMEPLAN_LIST;
            float[] hr;
            EDayTag[] daytags;
            int i, v1_colnr, d1_colnr;

            v1_colnr = table_darba_laiks.V1Column.Ordinal;
            d1_colnr = table_darba_laiks.D1Column.Ordinal;

            var dr_pl = dr.TIMEPLAN_LISTRow;

            hr = calmt.MakeHours(dr_pl, false);
            daytags = calmt.MakeDayTags(dr_pl);

            if (dr.XKind1 == EKind1.PlanGroupDay || dr.XKind1 == EKind1.PlanIndividualDay)
            {
                dr.BeginEdit();

                for (i = 0; i < 31; i++)
                {
                    dr[i + v1_colnr] = hr[i];
                    switch (daytags[i])
                    {
                        case EDayTag.None:
                            dr.DxPlan[i] = EDayPlanId.None;
                            break;
                        case EDayTag.WorkDay:
                        case EDayTag.WorkDayBeforeHoliday:
                            dr.DxPlan[i] = EDayPlanId.DD;
                            break;
                        case EDayTag.HolidayInFreeDay:
                            dr.DxPlan[i] = EDayPlanId.SD;
                            break;
                        case EDayTag.HolidayInWorkDay:
                            dr.DxPlan[i] = EDayPlanId.SDDD;
                            break;
                        case EDayTag.FreeDay:
                            dr.DxPlan[i] = EDayPlanId.BD;
                            break;
                    }

                }
                dr.K1 = dr.SumV();

                dr.EndEditX();
            }

            if (dr_pl.NIGHT == 1 && (dr.XKind1 == EKind1.PlanGroupaNight || 
                dr.XKind1 == EKind1.PlanIndividualNight))
            {
                dr.BeginEdit();

                hr = calmt.MakeHours(dr_pl, fornight: true);
                dr.SetAllVx(hr);
                dr.K1 = dr.SumV();

                dr.EndEditX();
            }

        }

        public static short GetNextTimeSheetNr(int yr)
        {
            var table_sar = MyData.DataSetKlons.TIMESHEET_LISTS;
            var e1 = table_sar.WhereX(d => d.YR == yr);
            if (e1.FirstOrDefault() == null) return 1;
            return (short)(e1.Max(d => d.SNR) + 1);
        }

        public static List<int> CheckTimeSheetsTemplUsed(int yr, int mt, KlonsADataSet.TIMESHEET_TEMPLRow[] drs_sh)
        {
            var ret = new List<int>();
            var table_sar = MyData.DataSetKlons.TIMESHEET_LISTS;
            var table_sar_r = MyData.DataSetKlons.TIMESHEET_LISTS_R;
            var drs_tsr = table_sar.WhereX(
                d =>
                d.YR == yr &&
                d.MT == mt
                ).SelectMany(d => d.GetTIMESHEET_LISTS_RRows())
                .ToArray();
            foreach (var dr_sh in drs_sh)
            {
                var drs_sh_r = dr_sh.GetTIMESHEET_TEMPL_RRows();
                foreach (var dr_sh_r in drs_sh_r)
                {
                    var drs_cur = drs_tsr.WhereX(
                        d =>
                        d.IDP == dr_sh_r.IDP &&
                        d.IDAM == dr_sh_r.IDAM);
                    if (drs_cur.Any())
                        if (!ret.Contains(dr_sh_r.IDAM))
                            ret.Add(dr_sh_r.IDAM);
                }
            }
            return ret;
        }

        public static string MakeTimeSheetsFromTempl(int yr, int mt, int idsh = int.MinValue)
        {
            var table_sar = MyData.DataSetKlons.TIMESHEET_LISTS;
            var table_sar_r = MyData.DataSetKlons.TIMESHEET_LISTS_R;
            var table_darba_laiks = MyData.DataSetKlons.TIMESHEET;
            var table_sh = MyData.DataSetKlons.TIMESHEET_TEMPL;
            var table_sh_r = MyData.DataSetKlons.TIMESHEET_TEMPL_R;
            var table_plans = MyData.DataSetKlons.TIMEPLAN_LIST;

            if (table_sh.Count == 0 || table_sh_r.Count == 0)
                return "Nav izveidotas darba uzskaites lapu sagataves.";

            KlonsADataSet.TIMESHEET_TEMPLRow[] drs_sh = null;
            if (idsh == int.MinValue)
                drs_sh = table_sh.WhereNotDeleted().OrderBy(d => d.SNR).ToArray();
            else
                drs_sh = new[] { table_sh.FindByID(idsh) };

            if (drs_sh.Length == 0 || drs_sh[0] == null)
                return "Nav atrastas darba uzskaites lapu sagataves.";

            var ret = CheckPlans(yr, mt);
            if (ret != "OK")
                return ret;

            var cur_idam = CheckTimeSheetsTemplUsed(yr, mt, drs_sh);
            if (cur_idam.Count > 0)
            {
                var drp = MyData.DataSetKlons.POSITIONS.FindByID(cur_idam[0]).PERSONSRow;
                if(cur_idam.Count == 1)
                    return $"Darba laika ieraksts priekš darbinieka {drp.YNAME} ir jau izveidots.";
                else
                    return $"Darba laika ieraksts priekš darbinieka {drp.YNAME} \nun vēl {cur_idam.Count - 1} darbiniekiem ir jau izveidots.";
            }


            int v1_colnr = table_darba_laiks.V1Column.Ordinal;
            int d1_colnr = table_darba_laiks.D1Column.Ordinal;
            var snr = GetNextTimeSheetNr(yr);

            foreach (var dr_sh in drs_sh)
            {
                var new_dr_sar = table_sar.NewTIMESHEET_LISTSRow();

                new_dr_sar.DEP = dr_sh.DEP;
                new_dr_sar.DESCR = dr_sh.DESCR;
                new_dr_sar.SNR = snr;
                new_dr_sar.YR = yr;
                new_dr_sar.MT = mt;

                snr++;

                table_sar.Rows.Add(new_dr_sar);

                var drs_sh_r = dr_sh.GetTIMESHEET_TEMPL_RRows();
                foreach (var dr_sh_r in drs_sh_r)
                {
                    var new_dr_sar_r = table_sar_r.NewTIMESHEET_LISTS_RRow();

                    var dr_pl = table_plans.FindByID(dr_sh_r.IDPL);
                    var drs_pl = dr_pl.GetTIMESHEETRows().WhereX(
                        d =>
                        d.YR == yr &&
                        d.MT == mt
                        ).ToArray();

                    new_dr_sar_r.TIMESHEET_LISTSRow = new_dr_sar;
                    new_dr_sar_r.IDP = dr_sh_r.IDP;
                    new_dr_sar_r.IDAM = dr_sh_r.IDAM;
                    new_dr_sar_r.IDPL = dr_sh_r.IDPL;
                    new_dr_sar_r.SNR = dr_sh_r.SNR;
                    new_dr_sar_r.PLAN_TYPE = dr_sh_r.PLAN_TYPE;
                    new_dr_sar_r.NIGHT = dr_pl.NIGHT;

                    table_sar_r.Rows.Add(new_dr_sar_r);

                    KlonsADataSet.TIMESHEETRow dr_new_plan_r = null;


                    if (new_dr_sar_r.XPlanType == EPlanType.Individual)
                    {
                        //make ind plan
                        foreach (var dr_pl_r in drs_pl)
                        {
                            var new_dr_dl_pl = table_darba_laiks.NewTIMESHEETRow();

                            new_dr_dl_pl.TIMESHEET_LISTS_RRow = new_dr_sar_r;
                            new_dr_dl_pl.IDL = new_dr_sar_r.ID;
                            new_dr_dl_pl.YR = yr;
                            new_dr_dl_pl.MT = mt;
                            new_dr_dl_pl.SNR = dr_sh_r.SNR;
                            new_dr_dl_pl.PERID = dr_sh_r.IDP;

                            switch (dr_pl_r.XKind1)
                            {
                                case EKind1.PlanGroupDay:
                                    new_dr_dl_pl.XKind1 = EKind1.PlanIndividualDay;
                                    dr_new_plan_r = new_dr_dl_pl;
                                    break;
                                case EKind1.PlanGroupaNight:
                                    new_dr_dl_pl.XKind1 = EKind1.PlanIndividualNight;
                                    break;
                            }

                            for (int i = 0; i < 31; i++)
                            {
                                new_dr_dl_pl.Vx[i] = dr_pl_r.Vx[i];
                                new_dr_dl_pl.DxPlan[i] = dr_pl_r.DxPlan[i];
                            }
                            new_dr_dl_pl.K1 = new_dr_dl_pl.SumV();

                            table_darba_laiks.Rows.Add(new_dr_dl_pl);
                        }
                    }
                    else
                    {
                        //link group plan
                        foreach (var dr_pl_r in drs_pl)
                        {
                            switch (dr_pl_r.XKind1)
                            {
                                case EKind1.PlanGroupDay:
                                    dr_new_plan_r = dr_pl_r;
                                    break;
                                case EKind1.PlanGroupaNight:
                                    break;
                            }
                        }
                    }

                    var new_dr_dl_day = table_darba_laiks.NewTIMESHEETRow();

                    new_dr_dl_day.TIMESHEET_LISTS_RRow = new_dr_sar_r;
                    new_dr_dl_day.IDL = new_dr_sar_r.ID;
                    new_dr_dl_day.YR = yr;
                    new_dr_dl_day.MT = mt;
                    new_dr_dl_day.SNR = dr_sh_r.SNR;
                    new_dr_dl_day.PERID = dr_sh_r.IDP;
                    new_dr_dl_day.AMID = dr_sh_r.IDAM;
                    new_dr_dl_day.XKind1 = EKind1.Fact;

                    for (int i = 0; i < 31; i++)
                    {
                        EDayFactId daycode = EDayFactId.None;
                        var dayplancode = dr_new_plan_r.DxPlan[i];
                        daycode = SomeDataDefs.PlanIdToFactId(dayplancode);
                        new_dr_dl_day.DxFact[i] = daycode;
                    }

                    table_darba_laiks.Rows.Add(new_dr_dl_day);

                    if (new_dr_sar_r.NIGHT == 1)
                    {
                        var new_dr_dl_night = table_darba_laiks.NewTIMESHEETRow();

                        new_dr_dl_night.TIMESHEET_LISTS_RRow = new_dr_sar_r;
                        new_dr_dl_day.IDL = new_dr_sar_r.ID;
                        new_dr_dl_night.YR = yr;
                        new_dr_dl_night.MT = mt;
                        new_dr_dl_night.SNR = dr_sh_r.SNR;
                        new_dr_dl_night.PERID = dr_sh_r.IDP;
                        new_dr_dl_day.AMID = dr_sh_r.IDAM;
                        new_dr_dl_night.XKind1 = EKind1.FactNight;

                        table_darba_laiks.Rows.Add(new_dr_dl_night);
                    }
                }

                DataTasks.CheckDarbaLaiksEvents(new_dr_sar.ID, int.MinValue, true, false);
            }

            return "OK";
        }

        public static bool CanChangeDayCode(EDayFactId dcbase, EDayFactId dcuser)
        {
            return SomeDataDefs.CanChangeDayId(dcbase) && SomeDataDefs.CanChangeDayId(dcuser);
        }

        public static ErrorList CheckDarbaLaiksEvents(int idsar, int idsarr = int.MinValue, bool sethours = true, bool setdaycode = true)
        {
            var table_sar = MyData.DataSetKlons.TIMESHEET_LISTS;
            var table_sar_r = MyData.DataSetKlons.TIMESHEET_LISTS_R;
            var table_darba_laiks = MyData.DataSetKlons.TIMESHEET;
            var table_plans = MyData.DataSetKlons.TIMEPLAN_LIST;

            var table_persons = MyData.DataSetKlons.PERSONS;
            var table_amati = MyData.DataSetKlons.POSITIONS;

            var dr_sar = table_sar.FindByID(idsar);
            KlonsADataSet.TIMESHEET_LISTS_RRow[] drs_sar_r;
            if (idsarr != int.MinValue)
            {
                var dr = table_sar_r.FindByID(idsarr);
                if (dr == null)
                    throw new ArgumentException("Bad row id");
                drs_sar_r = new KlonsADataSet.TIMESHEET_LISTS_RRow[] { dr };
            }
            else
            {
                drs_sar_r = dr_sar.GetTIMESHEET_LISTS_RRows();
            }

            int yr = dr_sar.YR;
            int mt = dr_sar.MT;

            DateTime dt1 = new DateTime(yr, mt, 1);
            DateTime dt2 = dt1.LastDayOfMonth();
            int daycount = dt2.Subtract(dt1).Days + 1;

            var err = new ErrorList();
            var events_info = new EventsInfo();

            foreach (var dr_sar_r in drs_sar_r)
            {

                var dr_pers = table_persons.FindByID(dr_sar_r.IDP);
                var dr_amats = table_amati.FindByID(dr_sar_r.IDAM);

                var ret = events_info.ProcessData(dr_sar_r.IDP, dt1, dt2);

                if (ret != "OK")
                {
                    err.AddPersonError(dr_sar_r.IDP, ret);
                    continue;
                }

                var dlrowset = dr_sar_r.GetDLRowSet();

                var perioddayids = events_info.PositionDayIds[dr_sar_r.IDAM];
                var eventdayids = events_info.PositionDayIdsA[dr_sar_r.IDAM];

                for (int i = 0; i < daycount; i++)
                {
                    var periodid = perioddayids[i];
                    var eventid = eventdayids[i];
                    EDayFactId dayidbase = SomeDataDefs.GetDayCodeForEvent(periodid, eventid);
                    EDayFactId dayiduser = dlrowset.Fact.DxFact[i];
                    if (dayidbase == EDayFactId.Error) throw new Exception("Bad event id");

                    if (dayidbase != dayiduser && !CanChangeDayCode(dayidbase, dayiduser))
                    {
                        dlrowset.Fact.BeginEdit();

                        dlrowset.Fact.Vx[i] = 0.0f;
                        dlrowset.Fact.DxFact[i] = dayidbase;
                        dayiduser = dayidbase;

                        if (dlrowset.FactNight != null)
                        {
                            dlrowset.FactNight.BeginEdit();
                            dlrowset.FactNight.Vx[i] = 0.0f;
                        }

                        if (dlrowset.FactOvertime != null)
                        {
                            dlrowset.FactOvertime.BeginEdit();
                            dlrowset.FactOvertime.Vx[i] = 0.0f;
                        }
                    }

                    if (setdaycode)
                    {
                        if (SomeDataDefs.CanChangeDayId(dlrowset.Fact.DxFact[i]))
                        {
                            EDayFactId daycode = EDayFactId.None;
                            var dayplancode = dlrowset.Plan.DxPlan[i];
                            daycode = SomeDataDefs.PlanIdToFactId(dayplancode);
                            if (dlrowset.Fact.DxFact[i] != daycode)
                            {
                                dlrowset.Fact.DxFact[i] = daycode;
                                dlrowset.Fact.Vx[i] = dlrowset.Plan.Vx[i];
                                dayiduser = daycode;
                            }
                        }
                    }


                    if (periodid == EPeriodId.Ir_pieņemts && !SomeDataDefs.IsDayForWork(dayiduser))
                    {
                        dlrowset.Fact.BeginEdit();
                        dlrowset.Fact.Vx[i] = 0.0f;

                        if (dlrowset.FactNight != null)
                        {
                            dlrowset.FactNight.BeginEdit();
                            dlrowset.FactNight.Vx[i] = 0.0f;
                        }

                        if (dlrowset.FactOvertime != null)
                        {
                            dlrowset.FactOvertime.BeginEdit();
                            dlrowset.FactOvertime.Vx[i] = 0.0f;
                        }

                    }

                    if (sethours)
                    {
                        if (SomeDataDefs.IsDayForWork(dlrowset.Fact.DxFact[i]))
                        {
                            dlrowset.Fact.Vx[i] = dlrowset.Plan.Vx[i];
                            if(dlrowset.PlanNight != null && dlrowset.FactNight != null)
                                dlrowset.FactNight.Vx[i] = dlrowset.PlanNight.Vx[i];
                        }
                        else
                        {
                            dlrowset.Fact.Vx[i] = 0.0f;
                            if (dlrowset.FactNight != null)
                                dlrowset.FactNight.Vx[i] = 0.0f;
                            if (dlrowset.FactOvertime != null)
                                dlrowset.FactOvertime.Vx[i] = 0.0f;
                        }

                        var sum = dlrowset.Fact.SumV();
                        if (dlrowset.Fact.K1 != sum)
                            dlrowset.Fact.K1 = sum;
                    }
                }

                dlrowset.Fact.EndEditX();
                if (dlrowset.FactNight != null)
                    dlrowset.FactNight.EndEditX();

                if (dlrowset.FactOvertime != null)
                    dlrowset.FactOvertime.EndEditX();
            }

            return err;
        }

        public static void FillFactHours(CalendarMonthInfo calmt, int idsarr)
        {
            var table_dl_sar_r = MyData.DataSetKlons.TIMESHEET_LISTS_R;

            var dr_sar_r = table_dl_sar_r.FindByID(idsarr);
            if (dr_sar_r == null)
            {
                throw new ArgumentException("Bad idsarr.");
            }

            var dlrowset = dr_sar_r.GetDLRowSet();
            if (dlrowset.Plan == null || dlrowset.Fact == null)
            {
                throw new ArgumentException("Bad DL rowset.");
            }

            int i;

            for (i = 0; i < calmt.DaysInMonth; i++)
            {
                var factcode = dlrowset.Fact.DxFact[i];
                if (SomeDataDefs.IsDayForWork(factcode))
                {
                    dlrowset.Fact.Vx[i] = dlrowset.Plan.Vx[i];
                }
                else
                {
                    dlrowset.Fact.Vx[i] = 0.0f;
                }
            }
        }

        public static int GetNextPayListNr(int yr)
        {
            var table_sar = MyData.DataSetKlons.PAYLISTS;
            var e1 = table_sar.WhereX(d => d.YR == yr);
            if (e1.FirstOrDefault() == null) return 1;
            return e1.Max(d => d.SNR) + 1;
        }

        public static int GetNextFpPayListNr(int yr)
        {
            var table_sar = MyData.DataSetKlons.FP_PAYLISTS;
            var e1 = table_sar.WhereX(d => d.YR == yr);
            if (e1.FirstOrDefault() == null) return 1;
            return e1.Max(d => d.SNR) + 1;
        }

        // SaveData required before and after FillPayListA
        public static string MakePayListsFromTempl(DateTime dt, int yr, int mt, bool dofill)
        {
            var table_templ = MyData.DataSetKlons.PAYLIST_TEMPL;
            var table_templ_r = MyData.DataSetKlons.PAYLIST_TEMPL_R;
            var table_lists = MyData.DataSetKlons.PAYLISTS;
            var table_lists_r = MyData.DataSetKlons.PAYLISTS_R;

            if (table_templ.Count == 0 || table_templ_r.Count == 0)
                return "Nav izveidotas maksājumu sarakstu sagataves.";

            int snr0 = GetNextPayListNr(yr);

            var drs_t = table_templ.WhereNotDeleted().OrderBy(d => d.SNR);

            var new_lists_drs = new List<KlonsADataSet.PAYLISTSRow>();

            foreach (var dr_t in drs_t)
            {
                var new_dr_list = table_lists.NewPAYLISTSRow();

                new_dr_list.DEP = dr_t.DEP;
                new_dr_list.DESCR = dr_t.DESCR;
                new_dr_list.DT = dt;
                new_dr_list.YR = yr;
                new_dr_list.MT = mt;
                new_dr_list.SNR = snr0;

                snr0++;

                table_lists.Rows.Add(new_dr_list);
                new_lists_drs.Add(new_dr_list);

                var drs_t_r = dr_t.GetPAYLIST_TEMPL_RRows();
                foreach(var dr_t_r in drs_t_r)
                {
                    var new_dr_list_r = table_lists_r.NewPAYLISTS_RRow();

                    new_dr_list_r.IDS = new_dr_list.ID;
                    new_dr_list_r.IDP = dr_t_r.IDP;
                    new_dr_list_r.IDAM = dr_t_r.IDAM;
                    new_dr_list_r.SNR = dr_t_r.SNR;

                    table_lists_r.Rows.Add(new_dr_list_r);
                }
            }

            var er = UpdateTable(table_lists);
            if (er != "OK") return er;
            er = UpdateTable(table_lists_r);
            if (er != "OK") return er;

            if (dofill)
            {
                foreach(var drs in new_lists_drs)
                {
                    FillPayListsA(dt, drs.ID, true);

                    er = UpdateTable(table_lists_r);
                    if (er != "OK") return er;

                    FillPayListsB(dt, drs.ID);

                    er = UpdateTable(table_lists_r);
                    if (er != "OK") return er;
                }
            }

            return "OK";
        }

        public static string MakePayListFromTempl(DateTime dt, int ids, int yr, int mt, bool dofill)
        {
            var table_templ = MyData.DataSetKlons.PAYLIST_TEMPL;
            var table_templ_r = MyData.DataSetKlons.PAYLIST_TEMPL_R;
            var table_lists = MyData.DataSetKlons.PAYLISTS;
            var table_lists_r = MyData.DataSetKlons.PAYLISTS_R;

            if (table_templ.Count == 0 || table_templ_r.Count == 0)
                return "Nav izveidotas maksājumu sarakstu sagataves.";

            var dr_t = table_templ.FindByID(ids);

            if (dr_t == null)
                return "Sagatave nav atrasta.";

            var drs_t_r = dr_t.GetPAYLIST_TEMPL_RRows();

            if (drs_t_r.Length == 0)
                return "Maksājuma saraksta sagatave ir tukša.";

            var drs_cur = table_lists_r
                .WhereX(
                    d =>
                    d.PAYLISTSRow.DT == dt &&
                    drs_t_r.Where(
                        d1 =>
                        d1.IDAM == d.IDAM
                        ).FirstOrDefault() != null)
                .ToArray();

            // vajadzētu darboties arī vairākiem maksājumiem vienā datumā
            //if (drs_cur.Length > 0)
            //    return string.Format("Viens no darbiniekiem ir jau iekļauts\nmaksāumu sarakstā ar datumu {0:dd.MM.yyyy}.", dt);

            var new_dr_list = table_lists.NewPAYLISTSRow();

            new_dr_list.DEP = dr_t.DEP;
            new_dr_list.DESCR = dr_t.DESCR;
            new_dr_list.DT = dt;
            new_dr_list.SNR = GetNextPayListNr(yr);
            new_dr_list.YR = yr;
            new_dr_list.MT = mt;

            table_lists.Rows.Add(new_dr_list);

            foreach (var dr_t_r in drs_t_r)
            {
                var new_dr_list_r = table_lists_r.NewPAYLISTS_RRow();

                new_dr_list_r.IDS = new_dr_list.ID;
                new_dr_list_r.IDP = dr_t_r.IDP;
                new_dr_list_r.IDAM = dr_t_r.IDAM;
                new_dr_list_r.SNR = dr_t_r.SNR;

                table_lists_r.Rows.Add(new_dr_list_r);
            }

            var er = UpdateTable(table_lists);
            if (er != "OK") return er;
            er = UpdateTable(table_lists_r);
            if (er != "OK") return er;

            if (dofill)
            {
                FillPayListA(new_dr_list.ID, true);

                er = UpdateTable(table_lists_r);
                if (er != "OK") return er;

                FillPayListB(new_dr_list.ID);

                er = UpdateTable(table_lists_r);
                if (er != "OK") return er;
            }

            return "OK";
        }

        public static ErrorList CheckPayListIDs(int ids)
        {
            var err = new ErrorList();
            var table_lists = MyData.DataSetKlons.PAYLISTS;

            var dr_s = table_lists.FindByID(ids);
            if (dr_s == null) return err;

            var drs = dr_s.GetPAYLISTS_RRows();
            if (drs.Length == 0) return err;

            var baddrs = drs
                .GroupBy(x => (x.IDP, x.IDAM))
                .Where(x => x.Count() > 1)
                .Select(x => x.First())
                .ToList();

            string errsrc = $"Maskājumu saraksts {dr_s.SNR} {dr_s.DT:dd.MM.yyyy}";
            foreach(var dr in baddrs)
            {
                var errstr = $"Darbiniekam divi maksājumi vienā sarakstā: {dr.PERSONSRow.ZNAME}, {dr.POSITIONSRow.TITLE}";
                err.AddError(errsrc, errstr);
            }

            return err;
        }

        //FillPayListsA - updates only pay balance
        //FillPayListsB - after FillPayListsA updates list match
        public static void FillPayListsA(DateTime dt,int ids, bool fullrecalc)
        {
            var table_lists_r = MyData.DataSetKlons.PAYLISTS_R;
            var ad = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.PAY_SALDOTableAdapter();

            var drs = table_lists_r
                .WhereX(d => d.PAYLISTSRow.ID == ids)
                .ToArray();

            if (drs.Length == 0) return;

            var dt1 = dt.FirstDayOfMonth();
            if (dt == dt.LastDayOfMonth()) dt1 = dt.AddDays(1);
            var table_paysaldo = ad.GetDataBy_SP_PAY_SALDO_03(dt, dt1, ids);

            if (table_paysaldo.Count == 0) return;

            foreach(var dr in drs)
            {
                var dr_ps = table_paysaldo.FindByIDAM(dr.IDAM);
                FillPayRowA(dr, dr_ps, fullrecalc);
            }
        }

        public static void FillPayListsB(DateTime dt, int ids)
        {
            var table_lists_r = MyData.DataSetKlons.PAYLISTS_R;
            var ad = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.SP_PAY_MATCHLISTS_1XTableAdapter();

            var drs = table_lists_r
                .WhereX(d => d.PAYLISTSRow.ID == ids)
                .ToArray();

            if (drs.Length == 0) return;

            var dt1 = dt.FirstDayOfMonth();
            if (dt == dt.LastDayOfMonth()) dt1 = dt.AddDays(1);

            var table_matchlists = ad.GetDataBy_SP_PAY_MATCHLISTS_14(dt, ids);

            if (table_matchlists.Count == 0) return;

            foreach (var dr in drs)
            {
                var dr_ml = table_matchlists.FindByIDAM(dr.IDAM);
                FillPayRowC(dr, dr_ml);
            }
        }

        public static void FillPayListA(int ids, bool fullrecalc)
        {
            var table_lists = MyData.DataSetKlons.PAYLISTS;
            var ad = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.PAY_SALDOTableAdapter();

            var dr_s = table_lists.FindByID(ids);
            if (dr_s == null) return;

            var drs = dr_s.GetPAYLISTS_RRows();
            if (drs.Length == 0) return;

            var dt = dr_s.DT;
            var dt1 = dt.FirstDayOfMonth();
            if (dt == dt.LastDayOfMonth()) dt1 = dt.AddDays(1);
            var table_paysaldo = ad.GetDataBy_SP_PAY_SALDO_02(ids, dt, dt1);

            if (table_paysaldo.Count == 0) return;

            foreach (var dr in drs)
            {
                var dr_ps = table_paysaldo.FindByIDAM(dr.IDAM);
                FillPayRowA(dr, dr_ps, fullrecalc);
            }
        }

        public static void FillPayListB(int ids)
        {
            var table_lists = MyData.DataSetKlons.PAYLISTS;

            var dr_s = table_lists.FindByID(ids);
            if (dr_s == null) return;

            var drs = dr_s.GetPAYLISTS_RRows();
            if (drs.Length == 0) return;

            var dt = dr_s.DT;
            var dt1 = dt.FirstDayOfMonth();
            if (dt == dt.LastDayOfMonth()) dt1 = dt.AddDays(1);

            var ad = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.SP_PAY_MATCHLISTS_1XTableAdapter();
            var table_matchlists = ad.GetDataBy_SP_PAY_MATCHLISTS_13(ids, dt);

            if (table_matchlists.Count == 0) return;

            foreach (var dr in drs)
            {
                var dr_ml = table_matchlists.FindByIDAM(dr.IDAM);
                FillPayRowC(dr, dr_ml);
            }
        }

        public static void FillPayListRowA(int id, bool fullrecalc)
        {
            var table_lists_r = MyData.DataSetKlons.PAYLISTS_R;
            var ad = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.PAY_SALDOTableAdapter();

            var dr = table_lists_r.FindByID(id);
            if (dr == null) return;

            var dr_s = dr.PAYLISTSRow;

            var dt = dr_s.DT;
            var dt1 = dt.FirstDayOfMonth();
            if (dt == dt.LastDayOfMonth()) dt1 = dt.AddDays(1);

            var table_paysaldo = ad.GetDataBy_SP_PAY_SALDO_01(dr.IDAM, dt, dt1, dr.IDS);
            if (table_paysaldo.Count == 0) return;
            var dr_ps = table_paysaldo[0];

            FillPayRowA(dr, dr_ps, fullrecalc);
        }

        public static void FillPayListRowB(int id)
        {
            var table_lists_r = MyData.DataSetKlons.PAYLISTS_R;

            var dr = table_lists_r.FindByID(id);
            if (dr == null) return;

            var dr_s = dr.PAYLISTSRow;

            var dt = dr_s.DT;
            var dt1 = dt.FirstDayOfMonth();
            if (dt == dt.LastDayOfMonth()) dt1 = dt.AddDays(1);

            var ad = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.SP_PAY_MATCHLISTS_1XTableAdapter();
            var table_matchlists = ad.GetDataBy_SP_PAY_MATCHLISTS_12(dr.IDAM, dr.PAY, dt, dr.IDS);

            if (table_matchlists.Count == 0) return;

            var dr_ml = table_matchlists[0];

            FillPayRowC(dr, dr_ml);
        }


        public static void FillPayRowA(KlonsADataSet.PAYLISTS_RRow dr, 
            KlonsARepDataSet.PAY_SALDORow dr_ps, bool fullrecalc)
        {
            decimal PAY0 = 0.0M;
            decimal IIN0 = 0.0M;
            decimal ADVANCE0 = 0.0M;
            decimal WITHHOLDINGS0 = 0.0M;
            decimal TPAY0 = 0.0M;
            decimal PAY = 0.0M;
            decimal IIN = 0.0M;
            decimal ADVANCE = 0.0M;
            decimal WITHHOLDINGS = 0.0M;
            decimal TPAY = 0.0M;
            decimal IIN_REVERSE = 0.0M;
            decimal PAY_REVERSE = 0.0M;
            decimal AW0 = 0.0M;
            decimal AW = 0.0M;

            var act_has_changes = new Func<bool>(() =>
            {
                if (dr.PAY0 != PAY0) return true;
                if (dr.IIN0 != IIN0) return true;
                if (dr.ADVANCE0 != ADVANCE0) return true;
                if (dr.TPAY0 != TPAY0) return true;
                if (dr.PAY != PAY) return true;
                if (dr.IIN != IIN) return true;
                if (dr.ADVANCE != ADVANCE) return true;
                if (dr.TPAY != TPAY) return true;
                if (dr.IIN_REVERSE != IIN_REVERSE) return true;
                if (dr.PAY_REVERSE != PAY_REVERSE) return true;
                return false;
            });

            var act_apply_changes = new Action(() =>
            {
                dr.BeginEdit();

                if (dr.PAY0 != PAY0) dr.PAY0 = PAY0;
                if (dr.IIN0 != IIN0) dr.IIN0 = IIN0;
                if (dr.ADVANCE0 != ADVANCE0) dr.ADVANCE0 = ADVANCE0;
                if (dr.TPAY0 != TPAY0) dr.TPAY0 = TPAY0;
                if (dr.PAY != PAY) dr.PAY = PAY;
                if (dr.IIN != IIN) dr.IIN = IIN;
                if (dr.ADVANCE != ADVANCE) dr.ADVANCE = ADVANCE;
                if (dr.TPAY != TPAY) dr.TPAY = TPAY;
                if (dr.IIN_REVERSE != IIN_REVERSE) dr.IIN_REVERSE = IIN_REVERSE;
                if (dr.PAY_REVERSE != PAY_REVERSE) dr.PAY_REVERSE = PAY_REVERSE;

                dr.EndEdit();
            });

            if (dr_ps == null)
            {
                if (act_has_changes()) act_apply_changes();
                return;
            }

            PAY0 = dr_ps.PAY0;
            IIN0 = dr_ps.IIN0;
            ADVANCE0 = dr_ps.ADVANCE;
            WITHHOLDINGS0 = dr_ps.WITHHOLDINGS;
            TPAY0 = PAY0 + ADVANCE0 - WITHHOLDINGS0;
            AW0 = ADVANCE0 - WITHHOLDINGS0;

            if (fullrecalc)
                TPAY = Math.Max(0.0M, TPAY0);
            else
                TPAY = dr.TPAY;

            if (TPAY >= TPAY0 || PAY0 < 0.0M)
            {
                PAY = PAY0;
            }
            else
            {
                if (AW0 >= 0.0M)
                {
                    if (TPAY >= 0.0M)
                        PAY = Math.Min(PAY0, TPAY);
                    else
                        PAY = 0.0M;
                }
                else
                {
                    if (TPAY >= 0.0M)
                        PAY = Math.Min(PAY0, TPAY - AW0);
                    else
                        PAY = Math.Min(PAY0, - AW0);
                }
            }
            AW = TPAY - PAY;


            /*
            IIN = IIN0;
            if (PAY0 < 0.0M)
            {
                IIN_REVERSE = IIN0;
                PAY_REVERSE = PAY0;
            }
            else if (PAY0 == 0.0M)
                IIN = 0.0M;
            else
                IIN = Math.Round(PAY / PAY0 * IIN0);
            */

            if (AW > AW0 && WITHHOLDINGS > 0.0M)
            {
                WITHHOLDINGS = Math.Max(WITHHOLDINGS0 - (AW - AW0), 0.0M);
            }
            else
            {
                WITHHOLDINGS = WITHHOLDINGS0;
            }
            ADVANCE = AW + WITHHOLDINGS;

            if (act_has_changes()) act_apply_changes();
        }

        public static void FillPayRowB(KlonsADataSet.PAYLISTS_RRow dr,
            KlonsARepDataSet.SP_PAY_MATCHLISTSRow dr_m)
        {
            if (dr["DT1"] == dr_m["DT1"] &&
                dr["DT2"] != dr_m["DT2"] &&
                dr["R1"] != dr_m["R1"] &&
                dr["R2"] != dr_m["R2"] &&
                dr["S0"] != dr_m["PAY0"] &&
                dr["S1"] != dr_m["PAY1"] &&
                dr["S2"] != dr_m["PAY2"]) return;

            dr.BeginEdit();

            if (dr["DT1"] != dr_m["DT1"]) dr["DT1"] = dr_m["DT1"];
            if (dr["DT2"] != dr_m["DT2"]) dr["DT2"] = dr_m["DT2"];
            if (dr["R1"] != dr_m["R1"]) dr["R1"] = dr_m["R1"];
            if (dr["R2"] != dr_m["R2"]) dr["R2"] = dr_m["R2"];
            if (dr["S0"] != dr_m["PAY0"]) dr["S0"] = dr_m["PAY0"];
            if (dr["S1"] != dr_m["PAY1"]) dr["S1"] = dr_m["PAY1"];
            if (dr["S2"] != dr_m["PAY2"]) dr["S2"] = dr_m["PAY2"];

            dr.EndEdit();
        }

        public static void FillPayRowC(KlonsADataSet.PAYLISTS_RRow dr,
            KlonsARepDataSet.SP_PAY_MATCHLISTS_1XRow dr_x)
        {
            if (dr["DT1"] == dr_x["DT1"] &&
                dr["DT2"] != dr_x["DT2"] &&
                dr["IIN"] != dr_x["IIN"] &&
                dr["R1"] != dr_x["R1"] &&
                dr["R2"] != dr_x["R2"] &&
                dr["S0"] != dr_x["PAY0"] &&
                dr["S1"] != dr_x["PAY1"] &&
                dr["S2"] != dr_x["PAY2"]) return;

            dr.BeginEdit();

            if (dr["DT1"] != dr_x["DT1"]) dr["DT1"] = dr_x["DT1"];
            if (dr["DT2"] != dr_x["DT2"]) dr["DT2"] = dr_x["DT2"];
            if (dr["IIN"] != dr_x["IIN"]) dr["IIN"] = dr_x["IIN"];
            if (dr["R1"] != dr_x["R1"]) dr["R1"] = dr_x["R1"];
            if (dr["R2"] != dr_x["R2"]) dr["R2"] = dr_x["R2"];
            if (dr["S0"] != dr_x["PAY0"]) dr["S0"] = dr_x["PAY0"];
            if (dr["S1"] != dr_x["PAY1"]) dr["S1"] = dr_x["PAY1"];
            if (dr["S2"] != dr_x["PAY2"]) dr["S2"] = dr_x["PAY2"];

            dr.EndEdit();

            PayListCalcInfo.Static.Calc(dr, dr_x);

            decimal iin = dr.IIN + dr.IIN_1 + dr.IIN_2;
            if (dr.IIN != iin) dr.IIN = iin;
        }

        public static ErrorList CheckEventsSimple(int idp)
        {
            var err = new ErrorList();
            var table_persons = MyData.DataSetKlons.PERSONS;
            var dr_person = table_persons.FindByID(idp);
            if (dr_person == null) return err;
            var drs_events = dr_person.GetEVENTSRows();
            foreach(var dr in drs_events)
            {
                int idn = dr.IDN;
                var ev = (EEventId)idn;
                bool b = SomeDataDefs.IsFromToEvent(ev);
                bool baddates = false;
                if (b)
                {
                    if (dr.IsDATE2Null())
                    {
                        baddates = true;
                    }
                    else
                    {
                        var dt1 = dr.DATE1;
                        var dt2 = dr.DATE2;
                        if (dt1 > dt2 || dt1.Year < 1950 || dt1.Year > 2100 ||
                            dt2.Year < 1950 || dt2.Year > 2100)
                        {
                            baddates = true;
                        }
                    }
                }
                else
                {
                    //if (dr.IsDATE1Null()) baddates = true;
                }
                if (baddates)
                {
                    err.AddPersonError(idp, "Nekorekti norādīti datumi no - līdz.");
                }

                b = SomeDataDefs.EventHasPayDate(ev);
                if (b)
                {
                    if (dr.IsDATE3Null())
                    {
                        baddates = true;
                    }
                    else
                    {
                        var dt3 = dr.DATE3;
                        if (dt3.Year < 1950 || dt3.Year > 2100)
                            baddates = true;
                    }
                }
                if (baddates)
                {
                    err.AddPersonError(idp, "Nekorekti norādīts izmaksas datums.");
                }

                if (ev == EEventId.Piešķirts_amats || ev == EEventId.Atbrīvots_no_amata)
                {
                    if (dr.IsIDANull())
                    {
                        err.AddPersonError(idp, "Janorāda amats.");
                    }
                }

                if (SomeDataDefs.EventHasSCode(ev))
                {
                    if (string.IsNullOrEmpty(dr.SCODE))
                    {
                        err.AddPersonError(idp, "Janorāda ziņu kods.");
                    }
                }

                if (SomeDataDefs.EventHasOccCode(ev))
                {
                    if (string.IsNullOrEmpty(dr.OCCUPATION_CODE))
                    {
                        err.AddPersonError(idp, "Janorāda profesijas kods.");
                    }
                }

                if (ev == EEventId.Atvaļinājums && dr.DAYS == 0)
                {
                    err.AddPersonError(idp, "Janorāda atvaļinājuma dienu skaits.");
                }

            }
            return err;
        }

        public static string CheckEventsA(int idp)
        {
            var events_info = new EventsInfo();
            var table_persons = MyData.DataSetKlons.PERSONS;
            var dr_person = table_persons.FindByID(idp);
            if (dr_person == null) return "Nav darbinieka";
            var drs_events = dr_person.GetEVENTSRows();

            var ret = events_info.AnalizeDLEvents(idp);

            if (ret != "OK") return ret;

            var drs_pr = dr_person.GetPERSONS_RRows();
            if (drs_pr.Length == 0)
            {
                return "Darbinieka dati ir bojāti.";
            }
            var dr_pr_first = drs_pr.OrderBy(d => d.EDIT_DATE).First();
            var dtprfirst = dr_pr_first.EDIT_DATE;

            if(events_info.HireFire.LinkedPeriods.Count == 0 ||
                dtprfirst > events_info.HireFire.LinkedPeriods[0].DateFirst)
                return "Nav darbinieka datu uz pieņemšanas brīdi.";

            return "OK";
        }

        public static ErrorList CheckEvents(int idp)
        {
            var err = CheckEventsSimple(idp);
            if (err.HasErrors) return err;
            var es = CheckEventsA(idp);
            if(es != "OK")
            {
                err.AddPersonError(idp, es);
                return err;
            }
            return err;
        }

        public static ErrorList CheckEventsAll()
        {
            var err = new ErrorList();
            var table_persons = MyData.DataSetKlons.PERSONS;
            foreach(var dr in table_persons)
            {
                var idp = dr.ID;
                var err1 = CheckEventsSimple(idp);
                err += err1;
                var es = CheckEventsA(idp);
                if (es != "OK")
                    err.AddPersonError(idp, es);
            }
            return err;
        }

        public static bool HaveSalaryRRow(DateTime dt1, DateTime dt2, int idp, int idam)
        {
            var table_algas_r = MyData.DataSetKlons.SALARY_SHEETS_R;
            return table_algas_r.WhereX(
                d =>
                {
                    if (d.IDP != idp || d.IsIDAMNull() || d.IDAM != idam) return false;
                    var dr_algas_lapa = d.SALARY_SHEETSRowByFK_SALARY_SHEETS_R_IDS;
                    return dr_algas_lapa.DT1 != dt1 &&
                        dr_algas_lapa.DT2 == dt2;
                }).Count() > 0;
        }


        public static string UpdateTable(DataTable table)
        {
            try
            {
                SetNewIDs(table.TableName);
                MyData.UpdateTable(table);
            }
            catch(Exception )
            {
                return "Neizdevās saglabāt datu tabulu [" + table.TableName + "].";
            }
            return "OK";
        }

        public static void SetNewIDs(MyAdapterManager adaptermanager)
        {
            if (adaptermanager.TableNames == null) return;
            SetNewIDs(adaptermanager.TableNames);
        }

        public static void SetNewIDs(params string[] tablenames)
        {
            DataRow[] drs;

            foreach (var tablename in tablenames)
            {
                switch (tablename)
                {
                    case "PERSONS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.PERSONS);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.PERSONSRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_PERSONS_ID();
                        }
                        break;

                    case "PERSONS_R":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.PERSONS_R);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.PERSONS_RRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_PERSONS_R_ID();
                        }
                        break;

                    case "POSITIONS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.POSITIONS);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.POSITIONSRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_POSITIONS_ID();
                        }
                        break;

                    case "POSITIONS_R":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.POSITIONS_R);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.POSITIONS_RRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_POSITIONS_R_ID();
                        }
                        break;

                    case "POSITIONS_PLUSMINUS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.POSITIONS_PLUSMINUS);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.POSITIONS_PLUSMINUSRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_POSITIONS_PLUSMINUS_ID();
                        }
                        break;

                    case "EVENTS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.EVENTS);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.EVENTSRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_EVENTS_ID();
                        }
                        break;

                    case "TIMEPLAN_LIST":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.TIMEPLAN_LIST);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.TIMEPLAN_LISTRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_TIMEPLAN_LIST_ID();
                        }
                        break;

                    case "TIMESHEET_TEMPL":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.TIMESHEET_TEMPL);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.TIMESHEET_TEMPLRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_TIMESHEET_TEMPL_ID();
                        }
                        break;

                    case "TIMESHEET_TEMPL_R":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.TIMESHEET_TEMPL_R);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.TIMESHEET_TEMPL_RRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_TIMESHEET_TEMPL_R_ID();
                        }
                        break;

                    case "TIMESHEET_LISTS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.TIMESHEET_LISTS);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.TIMESHEET_LISTSRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_TIMESHEET_LISTS_ID();
                        }
                        break;

                    case "TIMESHEET_LISTS_R":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.TIMESHEET_LISTS_R);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.TIMESHEET_LISTS_RRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_TIMESHEET_LISTS_R_ID();
                        }
                        break;

                    case "TIMESHEET":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.TIMESHEET);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.TIMESHEETRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_TIMESHEET_ID();
                        }
                        break;

                    case "SALARY_SHEETS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.SALARY_SHEETS);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.SALARY_SHEETSRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_SALARY_SHEETS_ID();
                        }
                        break;
                    case "SALARY_SHEETS_R":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.SALARY_SHEETS_R);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.SALARY_SHEETS_RRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_SALARY_SHEETS_R_ID();
                        }
                        break;
                    case "SALARY_PLUSMINUS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.SALARY_PLUSMINUS);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.SALARY_PLUSMINUSRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_SALARY_PLUSMINUS_ID();
                        }
                        break;
                    case "SALARY_SHEET_TEMPL":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.SALARY_SHEET_TEMPL);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.SALARY_SHEET_TEMPLRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_SALARY_SHEET_TEMPL_ID();
                        }
                        break;
                    case "SALARY_SHEET_TEMPL_R":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.SALARY_SHEET_TEMPL_R);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.SALARY_SHEET_TEMPL_RRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_SALARY_SHEET_TEMPL_R_ID();
                        }
                        break;
                    case "PASTDATA":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.PASTDATA);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.PASTDATARow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_PASTDATA_ID();
                        }
                        break;
                    case "PIECEWORK":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.PIECEWORK);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.PIECEWORKRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_PIECEWORK_ID();
                        }
                        break;
                    case "PIECEWORK_CATALOG":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.PIECEWORK_CATALOG);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.PIECEWORK_CATALOGRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_PIECEWORK_CATALOG_ID();
                        }
                        break;
                    case "PIECEWORK_CATSTRUCT":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.PIECEWORK_CATSTRUCT);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.PIECEWORK_CATSTRUCTRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_PIECEWORK_CATSTRUCT_ID();
                        }
                        break;
                    case "PAYLIST_TEMPL":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.PAYLIST_TEMPL);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.PAYLIST_TEMPLRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_PAYLIST_TEMPL_ID();
                        }
                        break;
                    case "PAYLIST_TEMPL_R":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.PAYLIST_TEMPL_R);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.PAYLIST_TEMPL_RRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_PAYLIST_TEMPL_R_ID();
                        }
                        break;
                    case "PAYLISTS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.PAYLISTS);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.PAYLISTSRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_PAYLISTS_ID();
                        }
                        break;
                    case "PAYLISTS_R":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.PAYLISTS_R);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.PAYLISTS_RRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_PAYLISTS_R_ID();
                        }
                        break;
                    case "BANKS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.BANKS);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.BANKSRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_BANKS_ID();
                        }
                        break;
                    case "EVENT_TYPES2":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.EVENT_TYPES2);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.EVENT_TYPES2Row;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_EVENT_TYPES2_ID();
                        }
                        break;
                    case "PERSONS_FIZ":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.PERSONS_FIZ);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.PERSONS_FIZRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_PERSONS_FIZ_ID();
                        }
                        break;
                    case "FP_PAYLISTS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.FP_PAYLISTS);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.FP_PAYLISTSRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_FP_PAYLISTS_ID();
                        }
                        break;
                    case "FP_PAYLISTS_R":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.FP_PAYLISTS_R);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsADataSet.FP_PAYLISTS_RRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_FP_PAYLISTS_R_ID();
                        }
                        break;

                }
            }
        }

    }


    public class ErrorInfo
    {
        public string Source { get; set;} = null;
        public string Message { get; set; } = null;
    }

    public class ErrorList : List<ErrorInfo>
    {
        public bool HasErrors { get { return Count > 0; } }

        public ErrorList()
        {
        }

        public ErrorList(string source, string msg)
        {
            AddError(source, msg);
        }

        public void AddError(string source, string msg)
        {
            var ei = new ErrorInfo()
            {
                Source = source,
                Message = msg
            };
            Add(ei);
        }

        public void AddPersonError(int idp, string msg)
        {
            var ei = new ErrorInfo();
            var table_persons = KlonsData.St.DataSetKlons.PERSONS;
            if (table_persons != null)
            {
                var dr = table_persons.FindByID(idp);
                if (dr != null)
                    ei.Source = string.Format("{0}", dr.ZNAME);
            }
            ei.Message = msg;
            Add(ei);
        }

        public void SetErrorList(ErrorList newlist)
        {
            Clear();
            AddRange(newlist);
        }

        public static ErrorList operator +(ErrorList e1, ErrorList e2)
        {
            if (e1 == null || e2 == null) return e1;
            e1.AddRange(e2);
            return e1;
        }

    }




}
