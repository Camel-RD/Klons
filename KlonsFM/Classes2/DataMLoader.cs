using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlonsLIB.Forms;

namespace KlonsFM.Classes
{
    public static class DataMLoader
    {
        public static KlonsData MyData => KlonsData.St;

        public static void ClearAll()
        {
            var ds = MyData.DataSetKlonsM;
            ds.EnforceConstraints = false;

            var tables = new DataTable[]
            {
                ds.M_ACCOUNTS,
                ds.M_ACCOUNTTYPE,
                ds.M_DOCS,
                ds.M_DOCTYPES,
                ds.M_ITEMS,
                ds.M_ITEMS_CAT,
                ds.M_ITEMS_PER_STORE,
                ds.M_PVNRATES,
                ds.M_PVNRATES2,
                ds.M_PVNTEXTS,
                ds.M_PVNTYPE,
                ds.M_ROWS,
                ds.M_STORES,
                ds.M_BANKS,
                ds.M_BANKACCOUNTS,
                ds.M_COUNTRIES,
                ds.M_CONTACTS,
                ds.M_ADDRESSSES,
                ds.M_VEHICLES,
                ds.M_STORETYPE,
                ds.M_UNITS,
                ds.M_PAYMENTTYPE,
                ds.M_TRANSACTIONTYPE
            };

            foreach (var t in tables)
                t.Clear();

            ds.EnforceConstraints = true;
        }
        
        public static bool FillAll()
        {
            return DoLoadCheckErrors(() =>
            {
                FillAllA();
            });
        }

        public static bool FillAllA()
        {
            var ds = MyData.DataSetKlonsM;
            ds.EnforceConstraints = false;

            var tables = new DataTable[]
            {
                ds.M_ACCOUNTS,
                ds.M_ACCOUNTTYPE,
                ds.M_DOCTYPES,
                ds.M_ITEMS,
                ds.M_ITEMS_CAT,
                ds.M_ITEMS_PER_STORE,
                ds.M_PVNRATES,
                ds.M_PVNRATES2,
                ds.M_PVNTEXTS,
                ds.M_PVNTYPE,
                ds.M_STORES,
                ds.M_BANKS,
                ds.M_BANKACCOUNTS,
                ds.M_COUNTRIES,
                ds.M_CONTACTS,
                ds.M_ADDRESSSES,
                ds.M_VEHICLES,
                ds.M_STORETYPE,
                ds.M_UNITS,
                ds.M_PAYMENTTYPE,
                ds.M_TRANSACTIONTYPE
            };

            foreach (var t in tables)
                MyData.FillTable(t);

            ds.EnforceConstraints = true;

            return true;
        }

        public static bool RefillAfterLinking()
        {
            return DoLoadCheckErrors(() =>
            {
                RefillAfterLinkingA();
            });
        }

        public static bool RefillAfterLinkingA()
        {
            var ds = MyData.DataSetKlonsM;
            ds.EnforceConstraints = false;

            var tables = new DataTable[]
            {
                ds.M_DOCS,
                ds.M_ROWS,
                ds.M_ITEMS,
                ds.M_ITEMS_PER_STORE
            };

            foreach (var t in tables)
                MyData.FillTable2(t, false);

            ds.EnforceConstraints = true;

            return true;
        }

        private static bool DoLoadCheckErrors(Action act)
        {
            try
            {
                act();
                return true;
            }
            catch (Exception ex)
            {
                Form_Error.ShowException(ex, "Neizdevās ielādēt datus no datu bāzes.");
                return false;
            }
        }

        public static void CheckLoad()
        {
            if (MyData.DataSetKlonsM.M_STORETYPE.Count > 0) return;
            FillAll();
        }

        public static bool LoadDocsByFilter(DateTime? dt1, DateTime? dt2, int? tp,
            int? state, int? idstoreout, int? idstorein, int? idstoreoutorin)
        {
            return DoLoadCheckErrors(() => 
            {
                LoadDocsByFilterA(dt1, dt2, tp, state, idstoreout, idstorein, idstoreoutorin);
            });
        }

        public static void LoadDocsByFilterA(DateTime? dt1, DateTime? dt2, int? tp,
            int? state, int? idstoreout, int? idstorein, int? idstoreoutorin)
        {
            var table_docs = MyData.DataSetKlonsM.M_DOCS;
            var table_rows = MyData.DataSetKlonsM.M_ROWS;
            table_rows.Clear();
            table_docs.Clear();
            var ad = new DataSets.KlonsMDataSetTableAdapters.M_DOCSTableAdapter();
            ad.FillBy_sp_m_filterdocs_01(table_docs, dt1, dt2, tp, state, 
                idstoreout, idstorein, idstoreoutorin);
        }

        public static bool LoadDocAndRowsByFilter(int iddoc, bool clearrowsbefore)
        {
            return DoLoadCheckErrors(() =>
            {
                LoadDocAndRowsByFilterA(iddoc, clearrowsbefore);
            });
        }

        public static void LoadDocAndRowsByFilterA(int iddoc, bool clearrowsbefore)
        {
            var table_docs = MyData.DataSetKlonsM.M_DOCS;
            var ad = new DataSets.KlonsMDataSetTableAdapters.M_DOCSTableAdapter();
            ad.ClearBeforeFill = false;
            ad.FillBy_sp_m_filterdoc_02(table_docs, iddoc);
            LoadRowsByFilter(iddoc, clearrowsbefore);
        }

        public static bool LoadRowsByFilter(int iddoc, bool clearbefore)
        {
            return DoLoadCheckErrors(() =>
            {
                LoadRowsByFilterA(iddoc, clearbefore);
            });
        }

        public static void LoadRowsByFilterA(int iddoc, bool clearbefore)
        {
            var table_rows = MyData.DataSetKlonsM.M_ROWS;
            var ad = new DataSets.KlonsMDataSetTableAdapters.M_ROWSTableAdapter();
            ad.ClearBeforeFill = clearbefore;
            ad.FillBy_sp_mfilter_row_01(table_rows, iddoc);
        }

        public static bool LoadInvDocsByFilter(DateTime? dt1, DateTime? dt2, 
            int? state, int? idstore)
        {
            return DoLoadCheckErrors(() =>
            {
                LoadInvDocsByFilterA(dt1, dt2, state, idstore);
            });
        }

        public static void LoadInvDocsByFilterA(DateTime? dt1, DateTime? dt2,
            int? state, int? idstore)
        {
            var table_invdocs = MyData.DataSetKlonsM.M_INV_DOCS;
            var table_invrows = MyData.DataSetKlonsM.M_INV_ROWS;
            table_invrows.Clear();
            table_invdocs.Clear();
            var ad = new DataSets.KlonsMDataSetTableAdapters.M_INV_DOCSTableAdapter();
            ad.FillBy_SP_M_INVDOCS_1(table_invdocs, dt1, dt2, state, idstore);
        }

        public static bool LoadInvRowsByFilter(int iddoc, bool clearbefore)
        {
            return DoLoadCheckErrors(() =>
            {
                LoadInvRowsByFilterA(iddoc, clearbefore);
            });
        }

        public static void LoadInvRowsByFilterA(int iddoc, bool clearbefore)
        {
            var table_invrows = MyData.DataSetKlonsM.M_INV_ROWS;
            var ad = new DataSets.KlonsMDataSetTableAdapters.M_INV_ROWSTableAdapter();
            ad.ClearBeforeFill = clearbefore;
            ad.FillBy_SP_M_INVROWS_1(table_invrows, iddoc);
        }


        public static bool LoadLatestAmountsByDoc(int iddoc)
        {
            return DoLoadCheckErrors(() =>
            {
                LoadLatestAmountsByDocA(iddoc);
            });
        }

        public static void LoadLatestAmountsByDocA(int iddoc)
        {
            var table_items = MyData.DataSetKlonsM.M_ITEMS;
            var table_itemsperstore = MyData.DataSetKlonsM.M_ITEMS_PER_STORE;
            var ad1 = new DataSets.KlonsMDataSetTableAdapters.M_ITEMSTableAdapter();
            var ad2 = new DataSets.KlonsMDataSetTableAdapters.M_ITEMS_PER_STORETableAdapter();
            ad1.ClearBeforeFill = false;
            ad2.ClearBeforeFill = false;
            ad1.FillBy_sp_m_filter_items_01(table_items, iddoc);
            ad2.FillBy_sp_m_filter_itemsperstore_01(table_itemsperstore, iddoc);
        }

        public static bool LoadLatestAmounts()
        {
            return DoLoadCheckErrors(() =>
            {
                LoadLatestAmountsA();
            });
        }

        public static void LoadLatestAmountsA()
        {
            var table_items = MyData.DataSetKlonsM.M_ITEMS;
            var table_itemsperstore = MyData.DataSetKlonsM.M_ITEMS_PER_STORE;
            var ad1 = new DataSets.KlonsMDataSetTableAdapters.M_ITEMSTableAdapter();
            var ad2 = new DataSets.KlonsMDataSetTableAdapters.M_ITEMS_PER_STORETableAdapter();
            ad1.ClearBeforeFill = false;
            ad2.ClearBeforeFill = false;
            ad1.Fill(table_items);
            ad2.Fill(table_itemsperstore);
        }
    }
}
