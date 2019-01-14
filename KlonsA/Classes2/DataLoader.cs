using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KlonsA.DataSets;
using KlonsLIB.Misc;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsA.DataSets.KlonsADataSetTableAdapters;

namespace KlonsA.Classes
{
    public static class DataLoader
    {
        public static KlonsData MyData => KlonsData.St;

        public static DateTime LoadedDT0;
        public static DateTime LoadedDT1;
        public static DateTime LoadedDT2;

        public static int paminyr, paminmt, pamaxyr, pamaxmt;
        public static int pdlminyr, pdlminmt, pdlmaxyr, pdlmaxmt;

        public static bool DataLoaded = false;

        public static void RefreshMinMax()
        {
            var ad = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.QueriesTableAdapter();

            ad.SP_GET_MINMAX(out pdlminyr, out pdlminmt, out pdlmaxyr, out pdlmaxmt,
                out paminyr, out paminmt, out pamaxyr, out pamaxmt);
        }

        public static void GetMonthList(out string[] ss, out int[,] yrmt)
        {
            int ct = (LoadedDT2.Year - LoadedDT1.Year) * 12 + LoadedDT2.Month - LoadedDT1.Month + 1;
            ss = new string[ct];
            yrmt = new int[ct, 2];
            int yr = LoadedDT1.Year;
            int mt = LoadedDT1.Month;
            int i = 0;
            while (true)
            {
                ss[i] = string.Format("{0}.{1:00}", yr, mt);
                yrmt[i, 0] = yr;
                yrmt[i, 1] = mt;
                if (yr == LoadedDT2.Year && mt == LoadedDT2.Month) break;
                i++;
                mt++;
                if(mt == 13)
                {
                    mt = 1;
                    yr++;
                }
            }
        }

        public static bool IsMonthLoaded(int yr, int mt)
        {
            if(!DataLoaded) return false;
            int ct1 = (LoadedDT2.Year - LoadedDT1.Year) * 12 + LoadedDT2.Month - LoadedDT1.Month + 1;
            int ct2 = (yr - LoadedDT1.Year) * 12 + mt - LoadedDT1.Month + 1;
            return ct2 >= 0 && ct2 <= ct1;
        }

        public static bool IsPeriodLoaded(DateTime dt1, DateTime dt2)
        {
            if (!DataLoaded) return false;
            return LoadedDT1 <= dt1 && LoadedDT2 >= dt2;
        }

        public static string GetPeriodStr()
        {
            return string.Format("Periods: [{0}.{1:00} - {2}.{3:00}]",
                LoadedDT1.Year, LoadedDT1.Month, LoadedDT2.Year, LoadedDT2.Month);
        }

        public static bool CheckDataA()
        {
            if (HasDataA()) return true;
            ClearAll();
            return FillA();
        }

        public static bool HasDataA()
        {
            var ds = MyData.DataSetKlons;
            return ds.EVENT_TYPES.Count > 0;
        }

        public static void ClearAll()
        {
            var ds = MyData.DataSetKlons;
            var dsr = MyData.DataSetKlonsRep;
            ds.EnforceConstraints = false;
            dsr.EnforceConstraints = false;

            var tables = new DataTable[]
            {
                ds.UNTAXED_MIN,
                ds.SALARY_PLUSMINUS,
                ds.SALARY_SHEETS_R,
                ds.SALARY_SHEETS,
                ds.PIECEWORK,
                ds.PIECEWORK_CATALOG,
                ds.PIECEWORK_CATSTRUCT,
                ds.SALARY_SHEET_TEMPL_R,
                ds.SALARY_SHEET_TEMPL,
                ds.POSITIONS_PLUSMINUS,
                ds.POSITIONS_R,
                ds.POSITIONS,
                ds.TIMESHEET,
                ds.DEPARTMENTS,
                ds.TIMESHEET_LISTS,
                ds.TIMESHEET_LISTS_R,
                ds.TIMESHEET_TEMPL,
                ds.TIMESHEET_TEMPL_R,
                ds.TIMEPLAN_LIST,
                ds.RATES,
                ds.EVENTS,
                ds.EVENT_TYPES,
                ds.PLUSMINUS_FROM,
                ds.PLUSMINUS_TYPES,
                ds.PAYLISTS,
                ds.PAYLISTS_R,
                ds.PAYLIST_TEMPL,
                ds.PAYLIST_TEMPL_R,
                ds.PERSONS,
                ds.PERSONS_R,
                ds.PASTDATA,
                ds.PROFESSIONS,
                ds.HOLIDAYS,
                ds.TERITORIAL_CODES,
                ds.REPORT_CODES,
                ds.BANKS,
                ds.EVENT_TYPES2,
                ds.PERSONS_FIZ,
                ds.FP_PAYLISTS,
                ds.FP_PAYLISTS_R,
                ds.INCOME_CODES
            };

            foreach (var t in tables)
                t.Clear();

            ds.EnforceConstraints = true;
            dsr.EnforceConstraints = true;
        }

        public static void ClearB()
        {
            var ds = MyData.DataSetKlons;
            ds.EnforceConstraints = false;

            var tables = new DataTable[]
            {
                ds.PIECEWORK,
                ds.SALARY_PLUSMINUS,
                ds.SALARY_SHEETS_R,
                ds.SALARY_SHEETS,
                ds.TIMESHEET,
                ds.TIMESHEET_LISTS,
                ds.TIMESHEET_LISTS_R,
                ds.PAYLISTS,
                ds.PAYLISTS_R,
                ds.FP_PAYLISTS,
                ds.FP_PAYLISTS_R
            };

            foreach (var t in tables)
                t.Clear();

            ds.EnforceConstraints = true;
        }

        public static bool FillA()
        {
            var ds = MyData.DataSetKlons;
            var dsr = MyData.DataSetKlonsRep;
            ds.EnforceConstraints = false;
            dsr.EnforceConstraints = false;

            var tables = new DataTable[]
            {
                ds.SALARY_SHEET_TEMPL,
                ds.SALARY_SHEET_TEMPL_R,
                ds.POSITIONS,
                ds.POSITIONS_PLUSMINUS,
                ds.POSITIONS_R,
                ds.DEPARTMENTS,
                ds.TIMESHEET_TEMPL,
                ds.TIMESHEET_TEMPL_R,
                ds.PIECEWORK_CATALOG,
                ds.PIECEWORK_CATSTRUCT,
                ds.TIMEPLAN_LIST,
                ds.RATES,
                ds.EVENTS,
                ds.EVENT_TYPES,
                ds.PLUSMINUS_FROM,
                ds.PLUSMINUS_TYPES,
                ds.PAYLIST_TEMPL,
                ds.PAYLIST_TEMPL_R,
                ds.PERSONS,
                ds.PERSONS_R,
                ds.PASTDATA,
                //ds.PROFESSIONS, -- loaded in form
                ds.HOLIDAYS,
                ds.TERITORIAL_CODES,
                ds.REPORT_CODES,
                ds.BANKS,
                ds.EVENT_TYPES2,
                ds.PERSONS_FIZ,
                ds.INCOME_CODES,
                ds.UNTAXED_MIN
            };

            foreach (var t in tables)
                MyData.FillTable(t);

            ds.EnforceConstraints = true;
            dsr.EnforceConstraints = true;

            return true;
        }

        public static bool LoadPeriod(int yr1, int mt1, int yr2, int mt2)
        {
            CheckDataA();
            DataLoaded = false;

            var adDlSar = MyData.KlonsTableAdapterManager.TIMESHEET_LISTSTableAdapter;
            var adDlSarR = MyData.KlonsTableAdapterManager.TIMESHEET_LISTS_RTableAdapter;
            var adDarbaLaiks = MyData.KlonsTableAdapterManager.TIMESHEETTableAdapter;
            var adAlgasLapas = MyData.KlonsTableAdapterManager.SALARY_SHEETSTableAdapter;
            var adAlgasLapasR = MyData.KlonsTableAdapterManager.SALARY_SHEETS_RTableAdapter;
            var adAlgasPapildsummas = MyData.KlonsTableAdapterManager.SALARY_PLUSMINUSTableAdapter;
            var adGabd = MyData.KlonsTableAdapterManager.PIECEWORKTableAdapter;
            var adPayLists = MyData.KlonsTableAdapterManager.PAYLISTSTableAdapter;
            var adPayListsR = MyData.KlonsTableAdapterManager.PAYLISTS_RTableAdapter;
            var adFpPayLists = MyData.KlonsTableAdapterManager.FP_PAYLISTSTableAdapter;
            var adFpPayListsR = MyData.KlonsTableAdapterManager.FP_PAYLISTS_RTableAdapter;

            var tableSar = MyData.DataSetKlons.TIMESHEET_LISTS;
            var tableSarR = MyData.DataSetKlons.TIMESHEET_LISTS_R;
            var tableDarbaLaiks = MyData.DataSetKlons.TIMESHEET;
            var tableAlgasLapas = MyData.DataSetKlons.SALARY_SHEETS;
            var tableAlgasLapasR = MyData.DataSetKlons.SALARY_SHEETS_R;
            var tableAlgasPapildsummas = MyData.DataSetKlons.SALARY_PLUSMINUS;
            var tableGabd = MyData.DataSetKlons.PIECEWORK;
            var tablePayLists = MyData.DataSetKlons.PAYLISTS;
            var tablePayListsR = MyData.DataSetKlons.PAYLISTS_R;
            var tableFpPayLists = MyData.DataSetKlons.FP_PAYLISTS;
            var tableFpPayListsR = MyData.DataSetKlons.FP_PAYLISTS_R;

            MyData.DataSetKlons.EnforceConstraints = false;

            ClearB();

            int yr0 = yr1;
            int mt0 = mt1 - 1;
            if(mt0 == 0)
            {
                mt0 = 12;
                yr0--;
            }

            var dt0 = new DateTime(yr0, mt0, 1);
            var dt2 = new DateTime(yr2, mt2, 1).LastDayOfMonth();

            adDlSar.FillBy_timesheet_lists_01(tableSar, yr0, mt0, yr2, mt2);
            adDlSarR.FillBy_timesheet_lists_r(tableSarR, yr0, mt0, yr2, mt2);
            adDarbaLaiks.FillBy_timesheet_per_01(tableDarbaLaiks, yr0, mt0, yr2, mt2);
            adAlgasLapas.FillBy_SALARY_SHEETS_PER_01(tableAlgasLapas, yr0, mt0, yr2, mt2);
            adAlgasLapasR.FillBy_SALARY_SHEETS_R_PER_01(tableAlgasLapasR, yr0, mt0, yr2, mt2);
            adAlgasPapildsummas.FillBy_sp_salary_plusminus_per_01(tableAlgasPapildsummas, yr0, mt0, yr2, mt2);
            adGabd.FillBy_SP_PIECEWORK_PER_01(tableGabd, dt0, dt2);
            adPayLists.FillBy_sp_paylists_per_01(tablePayLists, dt0, dt2);
            adPayListsR.FillBy_sp_paylists_r_per_01(tablePayListsR, dt0, dt2);
            adFpPayLists.FillBy_SP_FP_PAYLISTS_PER_01(tableFpPayLists, yr0, mt0, yr2, mt2);
            adFpPayListsR.FillBy_SP_FP_PAYLISTS_R_PER_01(tableFpPayListsR, yr0, mt0, yr2, mt2);


            MyData.DataSetKlons.EnforceConstraints = true;

            LoadedDT0 = new DateTime(yr0, mt0, 1);
            LoadedDT1 = new DateTime(yr1, mt1, 1);
            LoadedDT2 = new DateTime(yr2, mt2, 1).LastDayOfMonth();

            MarkFirstMonth();

            MyData.DataSetKlons.PERSONS.DefaultView.Sort = "ID";

            DataLoaded = true;

            return true;
        }

        public static void MarkFirstMonth()
        {
            var tableSar = MyData.DataSetKlons.TIMESHEET_LISTS;
            var tableAlgasLapas = MyData.DataSetKlons.SALARY_SHEETS;

            foreach (var dr in tableSar)
                dr.ISFIRSTMT = dr.YR == LoadedDT0.Year && dr.MT == LoadedDT0.Month;
            tableSar.AcceptChanges();

            foreach (var dr in tableAlgasLapas)
                dr.ISFIRSTMT = dr.YR == LoadedDT0.Year && dr.MT == LoadedDT0.Month;
            tableAlgasLapas.AcceptChanges();
        }

        public static bool LoadSomeData()
        {
            int mtct = MyData.Params.LoadMonths;
            var dt1 = DateTime.Today.AddMonths(1);
            var dt2 = dt1.AddMonths(-mtct);
            try
            {
                return LoadPeriod(dt2.Year, dt2.Month, dt1.Year, dt1.Month);
            }
            catch(Exception e)
            {
                var de = new DetailedConstraintException2(e.Message, MyData.DataSetKlons);
                Form_Error.ShowException(de);
                return false;
            }
        }
    }
}
