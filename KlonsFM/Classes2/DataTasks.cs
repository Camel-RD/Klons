using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KlonsFM.DataSets;
using KlonsFM.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Data;
using KlonsLIB.Misc;
using FirebirdSql.Data.FirebirdClient;

namespace KlonsFM.Classes
{
    public static class DataTasks
    {
        public static KlonsData MyData => KlonsData.St;


        public static string GetStoreName(int id)
        {
            return MyData.DataSetKlonsM.M_STORES.FindByID(id)?.NAME;
        }

        public static string GetStoreCode(int id)
        {
            return MyData.DataSetKlonsM.M_STORES.FindByID(id)?.CODE;
        }

        public static string GetStoreCodeAndName(int id)
        {
            var dr_store = MyData.DataSetKlonsM.M_STORES.FindByID(id);
            if (dr_store == null) return null;
            return dr_store.CODE + " " + dr_store.NAME;
        }

        public static int? GetStoreIdByCode(string code)
        {
            var dr = MyData.DataSetKlonsM.M_STORES
                .WhereX(x => x.CODE == code)
                .FirstOrDefault();
            return dr == null ? (int?)null : dr.ID;
        }

        public static string GetItemCodeAndName(int id)
        {
            var dr = MyData.DataSetKlonsM.M_ITEMS.FindByID(id);
            if (dr == null) return null;
            return $"{dr.BARCODE} {dr.NAME.Nz()}";
        }

        public static int GetNextIdSeq()
        {
            return (int)MyData.KlonsMQueriesTableAdapter.SP_GEN_M_DOCSEQ();
        }

        public static ErrorList CheckDocHeader(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = new ErrorList();
            if (dr_doc.XDocType == EDocType.Nenoteikts)
            {
                ret.AddDocError(dr_doc.ID, "Jānorāda dokumenta veids");
                return ret;
            }
            if (dr_doc.IDSTOREIN == 1 || dr_doc.IDSTOREOUT == 1)
            {
                ret.AddDocError(dr_doc.ID, "Jānorāda noliktavas.");
                return ret;
            }
            if (!SomeDataDefs.IsGoodStoreOut(dr_doc.XDocType, dr_doc.XStoreOutType))
            {
                ret.AddDocError(dr_doc.ID, "Jānorāda dokumenta veidam atbilstoša izdevēja noliktava.");
                return ret;
            }
            if (!SomeDataDefs.IsGoodStoreIn(dr_doc.XDocType, dr_doc.XStoreInType))
            {
                ret.AddDocError(dr_doc.ID, "Jānorāda dokumenta veidam atbilstoša saņēmēja noliktava.");
                return ret;
            }
            if (SomeDataDefs.IsCreditDoc(dr_doc.XDocType) && dr_doc.IsIDCREDDOCNull())
            {
                ret.AddDocError(dr_doc.ID, "Kredītrēķinam nav norādīts sākotnējais rēķins.");
                return ret;
            }
            if (!SomeDataDefs.IsCreditDoc(dr_doc.XDocType) && !dr_doc.IsIDCREDDOCNull())
            {
                ret.AddDocError(dr_doc.ID, "Tikai kredītrēķinam var būt norādīts sākotnējais rēķins.");
                return ret;
            }

            if (!IsGoodAcc(dr_doc.ACCOUT) || !IsGoodAcc(dr_doc.ACCIN))
            {
                ret.AddDocError(dr_doc.ID, "Izsniedzējam vai saņēmējam nav norādīti finanšu grāmatvedības konti.");
                return ret;
            }

            if (dr_doc.XDocType == EDocType.Pārvietots && dr_doc.ACCIN != dr_doc.ACCOUT)
            {
                ret.AddDocError(dr_doc.ID, "Pārvietošanas dokumentam izsniedzējam un saņēmējam finanšu konti nedrīkst atšķirties.");
                return ret;
            }
            return ret;
        }

        static bool IsGoodAcc(string acc) => !acc.IsNOE() && acc != "?";

        public static void UpdateDocAcc(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            bool is_storeout_ours = SomeDataDefs.IsStoreOurs(dr_doc.XStoreOutType);
            bool is_storein_ours = SomeDataDefs.IsStoreOurs(dr_doc.XStoreInType);
            if (is_storeout_ours)
                dr_doc.ACCOUT = dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREOUT1.ACC21;
            if (is_storein_ours)
                dr_doc.ACCIN = dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREIN1.ACC21;
            if (is_storeout_ours && is_storein_ours) return;
            bool is_storeout_partner = SomeDataDefs.IsStorePartner(dr_doc.XStoreOutType);
            bool is_storein_partner = SomeDataDefs.IsStorePartner(dr_doc.XStoreInType);
            if (SomeDataDefs.IsDoc231(dr_doc.XDocType))
            {
                if (is_storeout_partner)
                    dr_doc.ACCOUT = dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREOUT1.ACC23;
                if (is_storein_partner)
                    dr_doc.ACCIN = dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREIN1.ACC23;
            }
            else if (SomeDataDefs.IsDoc531(dr_doc.XDocType))
            {
                if (is_storeout_partner)
                    dr_doc.ACCOUT = dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREOUT1.ACC53;
                if (is_storein_partner)
                    dr_doc.ACCIN = dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREIN1.ACC53;
            }
        }

        public static ErrorList CheckRowsForBadAcc(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = new ErrorList();
            var drs_rows = dr_doc.GetM_ROWSRows();
            foreach (var dr_row in drs_rows)
            {
                if (!IsGoodAcc(dr_row.ACC6) || !IsGoodAcc(dr_row.ACC7))
                    ret.AddItemError(dr_row.IDITEM, "Artikulam nav norādīti finanšu grāmatvedības konti.");
            }
            return ret;
        }

        public static ErrorList CheckDocForIncomminGoods(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = new ErrorList();
            var drs_rows = dr_doc.GetM_ROWSRows().ToList();
            if (drs_rows.Count == 0)
            {
                ret.AddError("dokuments", "Dokuments nesatur rindas.");
                return ret;
            }

            var err = CheckDocHeader(dr_doc);
            if (err.HasErrors) return err;

            ret += CheckRowsForBadAcc(dr_doc);

            foreach (var dr_rows in drs_rows)
            {
                err = CheckRowForIncommingGoods(dr_rows);
                if (err.HasErrors) ret += err;
            }
            return ret;
        }

        public static ErrorList CheckRowForIncommingGoods(KlonsMDataSet.M_ROWSRow dr_row)
        {
            var ret = new ErrorList();
            var dr_doc = dr_row.M_DOCSRow;
            var dr_item = dr_row.M_ITEMSRow;
            int id_item = dr_item.ID;

            if (dr_row.AMOUNT <= 0)
            {
                ret.AddItemError(id_item, "Nekorekts daudzums.");
            }

            if (dr_item.XIsServices) return ret;

            /*if (!dr_item.IsLASTBUYDATENull() && dr_item.LASTBUYDATE > dr_doc.DT)
            {
                ret.AddItemError(id_item, "Dokumenta datums vecāks par pēdējo iegādes dekumentu.");
            }*/

            return ret;
        }

        public static ErrorList CheckDocForRealizacija(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = new ErrorList();
            var drs_rows = dr_doc.GetM_ROWSRows().ToList();
            if (drs_rows.Count == 0)
            {
                ret.AddError("dokuments", "Dokuments nesatur rindas.");
                return ret;
            }

            var err = CheckDocHeader(dr_doc);
            if (err.HasErrors) return err;

            ret += CheckRowsForBadAcc(dr_doc);

            var ids_items_morethanone = drs_rows
                .GroupBy(x => x.IDITEM)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)
                .ToList();

            if (ids_items_morethanone.Count > 0)
            {
                foreach (int id_items_morethanone in ids_items_morethanone)
                {
                    ret.AddItemError(id_items_morethanone, "Artikuls ievadīts vairāk kā vienu reizi.");
                }
                return ret;
            }

            var items_withallamount = drs_rows
                .GroupBy(x => x.IDITEM)
                .Select(x => (key: x.Key, amount: x.Sum(y => y.AMOUNT)));

            var drs_rows_withallamount = drs_rows
                .Join(items_withallamount, x => x.IDITEM, x => x.key, (dr, y) => (dr, y.amount));

            foreach (var dr_row_withallamount in drs_rows_withallamount)
            {
                err = CheckRowForRealizacija(dr_row_withallamount.dr, dr_row_withallamount.amount);
                ret += err;
            }
            if (ret.HasErrors) return ret;

            var ad = new DataSets.KlonsMRepDataSetTableAdapters.SP_M_MAKELINKS_02BTableAdapter();
            var table_checkrows = ad.GetDataBy_SP_M_MAKELINKS_02B(dr_doc.ID);

            foreach (var dr_checkrows in table_checkrows)
            {
                if (dr_checkrows.RESULT == "OK") continue;
                err = GetErrorListFromMessage(dr_checkrows.RESULT);
                if (err.HasErrors) ret += err;
            }

            return ret;
        }

        public static ErrorList CheckRowForRealizacija(KlonsMDataSet.M_ROWSRow dr_row, decimal allamount)
        {
            var ret = new ErrorList();
            var dr_doc = dr_row.M_DOCSRow;
            var dr_item = dr_row.M_ITEMSRow;
            int id_storeout = dr_doc.IDSTOREOUT;
            int id_item = dr_item.ID;
            var table_itemsperstore = MyData.DataSetKlonsM.M_ITEMS_PER_STORE;
            var dr_amount = table_itemsperstore.FindByIDITEMIDSTORE(id_item, id_storeout);

            if (dr_row.AMOUNT <= 0)
            {
                ret.AddItemError(id_item, "Nekorekts daudzums.");
                return ret;
            }
            
            if (dr_item.XIsServices) return ret;

            /*if (!dr_item.IsLASTSALEDATENull() && dr_doc.DT < dr_item.LASTSALEDATE)
            {
                ret.AddItemError(id_item, "Dokumenta datums vecāks par pēdējo reģistrēto.");
                return ret;
            }*/
            if (dr_amount == null || dr_amount.AMOUNT < dr_row.AMOUNT || allamount < dr_row.AMOUNT)
            {
                ret.AddItemError(id_item, "Nepietiekams atlikums.");
                return ret;
            }

            return ret;
        }


        public static ErrorList CheckDocForRealizacijasKreditrekins(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = new ErrorList();
            var drs_rows = dr_doc.GetM_ROWSRows().ToList();
            if (drs_rows.Count == 0)
            {
                ret.AddError("dokuments", "Dokuments nesatur rindas.");
                return ret;
            }

            var err = CheckDocHeader(dr_doc);
            if (err.HasErrors) return err;

            ret += CheckRowsForBadAcc(dr_doc);

            var ids_items_morethanone = drs_rows
                .GroupBy(x => x.IDITEM)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)
                .ToList();

            if (ids_items_morethanone.Count > 0)
            {
                foreach (int id_items_morethanone in ids_items_morethanone)
                {
                    ret.AddItemError(id_items_morethanone, "Artikuls ievadīts vairāk kā vienu reizi.");
                }
                return ret;
            }

            var items_withallamount = drs_rows
                .GroupBy(x => x.IDITEM)
                .Select(x => (key: x.Key, amount: x.Sum(y => y.AMOUNT)));

            var drs_rows_withallamount = drs_rows
                .Join(items_withallamount, x => x.IDITEM, x => x.key, (dr, y) => (dr, y.amount));

            foreach (var dr_row_withallamount in drs_rows_withallamount)
            {
                err = CheckRowForRealizacijasKreditrekins(dr_row_withallamount.dr, dr_row_withallamount.amount);
                if (err.HasErrors) ret += err;
            }

            var ad = new DataSets.KlonsMRepDataSetTableAdapters.MAKELINKS_CHECK_1TableAdapter();
            var table_checkrows = ad.GetDataBy_SP_M_MAKELINKS_52(dr_doc.ID);

            foreach(var dr_checkrows in table_checkrows)
            {
                if (dr_checkrows.RESULT == "OK") continue;
                err = GetErrorListFromMessage(dr_checkrows.RESULT);
                if (err.HasErrors) ret += err;
            }

            return ret;
        }

        public static ErrorList CheckRowForRealizacijasKreditrekins(KlonsMDataSet.M_ROWSRow dr_row, decimal allamount)
        {
            var ret = new ErrorList();
            var dr_doc = dr_row.M_DOCSRow;
            var dr_item = dr_row.M_ITEMSRow;
            int id_storeout = dr_doc.IDSTOREOUT;
            int id_item = dr_item.ID;
            var table_itemsperstore = MyData.DataSetKlonsM.M_ITEMS_PER_STORE;
            var dr_amount = table_itemsperstore.FindByIDITEMIDSTORE(id_item, id_storeout);

            if (dr_row.AMOUNT >= 0)
            {
                ret.AddItemError(id_item, "Realizācijas kredītrēķinā uzrāda negatīvu daudzumu.");
                return ret;
            }

            if (dr_item.XIsServices) return ret;

            /*if (!dr_item.IsLASTSALEDATENull() && dr_doc.DT < dr_item.LASTSALEDATE)
            {
                ret.AddItemError(id_item, "Dokumenta datums vecāks par pēdējo reģistrēto.");
                return ret;
            }*/


            return ret;
        }


        public static ErrorList CheckDocForPiegadatajaKreditrekins(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = new ErrorList();
            var drs_rows = dr_doc.GetM_ROWSRows().ToList();
            if (drs_rows.Count == 0)
            {
                ret.AddError("dokuments", "Dokuments nesatur rindas.");
                return ret;
            }

            var err = CheckDocHeader(dr_doc);
            if (err.HasErrors) return err;

            ret += CheckRowsForBadAcc(dr_doc);

            var ids_items_morethanone = drs_rows
                .GroupBy(x => x.IDITEM)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)
                .ToList();

            if (ids_items_morethanone.Count > 0)
            {
                foreach (int id_items_morethanone in ids_items_morethanone)
                {
                    ret.AddItemError(id_items_morethanone, "Artikuls ievadīts vairāk kā vienu reizi.");
                }
                return ret;
            }

            var items_withallamount = drs_rows
                .GroupBy(x => x.IDITEM)
                .Select(x => (key: x.Key, amount: x.Sum(y => y.AMOUNT)));

            var drs_rows_withallamount = drs_rows
                .Join(items_withallamount, x => x.IDITEM, x => x.key, (dr, y) => (dr, y.amount));

            foreach (var dr_row_withallamount in drs_rows_withallamount)
            {
                err = CheckRowForPiegadatajaKreditrekins(dr_row_withallamount.dr, dr_row_withallamount.amount);
                if (err.HasErrors) ret += err;
            }

            var ad = new DataSets.KlonsMRepDataSetTableAdapters.MAKELINKS_CHECK_1TableAdapter();
            var table_checkrows = ad.GetDataBy_SP_M_MAKELINKS_62(dr_doc.ID);

            foreach (var dr_checkrows in table_checkrows)
            {
                if (dr_checkrows.RESULT == "OK") continue;
                err = GetErrorListFromMessage(dr_checkrows.RESULT);
                if (err.HasErrors) ret += err;
            }

            return ret;
        }


        public static ErrorList CheckRowForPiegadatajaKreditrekins(KlonsMDataSet.M_ROWSRow dr_row, decimal allamount)
        {
            var ret = new ErrorList();
            var dr_doc = dr_row.M_DOCSRow;
            var dr_item = dr_row.M_ITEMSRow;
            int id_storeout = dr_doc.IDSTOREOUT;
            int id_item = dr_item.ID;
            var table_itemsperstore = MyData.DataSetKlonsM.M_ITEMS_PER_STORE;
            var dr_amount = table_itemsperstore.FindByIDITEMIDSTORE(id_item, id_storeout);

            if (dr_row.AMOUNT <= 0)
            {
                ret.AddItemError(id_item, "Nekorekts daudzums.");
                return ret;
            }

            if (dr_item.XIsServices) return ret;

            /*if (!dr_item.IsLASTSALEDATENull() && dr_doc.DT < dr_item.LASTSALEDATE)
            {
                ret.AddItemError(id_item, "Dokumenta datums vecāks par pēdējo reģistrēto.");
                return ret;
            }*/
            if (dr_amount == null || dr_amount.AMOUNT < dr_row.AMOUNT || allamount < dr_row.AMOUNT)
            {
                ret.AddItemError(id_item, "Nepietiekams atlikums.");
                return ret;
            }


            return ret;
        }


        public static ErrorList CheckDocForAtgrieztsPiegadatajam(
            KlonsMDataSet.M_DOCSRow dr_doc, bool setprice)
        {
            var ret = new ErrorList();
            var drs_rows = dr_doc.GetM_ROWSRows().ToList();
            if (drs_rows.Count == 0)
            {
                ret.AddError("dokuments", "Dokuments nesatur rindas.");
                return ret;
            }

            var err = CheckDocHeader(dr_doc);
            if (err.HasErrors) return err;

            ret += CheckRowsForBadAcc(dr_doc);

            var ids_items_morethanone = drs_rows
                .GroupBy(x => x.IDITEM)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)
                .ToList();

            if (ids_items_morethanone.Count > 0)
            {
                foreach (int id_items_morethanone in ids_items_morethanone)
                {
                    ret.AddItemError(id_items_morethanone, "Artikuls ievadīts vairāk kā vienu reizi.");
                }
                return ret;
            }

            var items_withallamount = drs_rows
                .GroupBy(x => x.IDITEM)
                .Select(x => (key: x.Key, amount: x.Sum(y => y.AMOUNT)));

            var drs_rows_withallamount = drs_rows
                .Join(items_withallamount, x => x.IDITEM, x => x.key, (dr, y) => (dr, y.amount));


            foreach (var dr_row_withallamount in drs_rows_withallamount)
            {
                err = CheckRowForAtgrieztsPiegadatajam(dr_row_withallamount.dr, dr_row_withallamount.amount);
                if (err.HasErrors) ret += err;
            }

            var ad = new DataSets.KlonsMRepDataSetTableAdapters.SP_M_MAKELINKS_02BTableAdapter();
            var table_rowchecks = ad.GetDataBy_SP_M_MAKELINKS_22B(dr_doc.ID);

            if (table_rowchecks.Rows.Count == 0)
            {
                ret.AddError("", "Nav atlikuma atgiešanai.");
                return ret;
            }

            foreach (var row_checks in table_rowchecks)
            {
                if (row_checks.RESULT == "OK") continue;
                ret += GetErrorListFromMessage(row_checks.RESULT);
            }

            if (ret.HasErrors) return ret;

            if (!setprice) return ret;
            
            foreach (var dr_row in drs_rows)
            {
                if (dr_row.XIsServices) continue;
                var dr_checks = table_rowchecks.Where(x => x.IDROW == dr_row.ID).Single();
                dr_row.PRICE0 = dr_checks.BUYPRICE;
                dr_row.DISCOUNT = 0f;
                dr_row.PRICE = dr_checks.BUYPRICE;
                dr_row.TPRICE = dr_checks.TBUYPRICE;
            }

            return ret;
        }

        public static ErrorList CheckRowForAtgrieztsPiegadatajam(KlonsMDataSet.M_ROWSRow dr_row, decimal allamount)
        {
            var ret = new ErrorList();
            var dr_doc = dr_row.M_DOCSRow;
            var dr_item = dr_row.M_ITEMSRow;
            int id_storeout = dr_doc.IDSTOREOUT;
            int id_item = dr_item.ID;
            var table_itemsperstore = MyData.DataSetKlonsM.M_ITEMS_PER_STORE;
            var dr_amount = table_itemsperstore.FindByIDITEMIDSTORE(id_item, id_storeout);

            if (dr_row.AMOUNT <= 0)
            {
                ret.AddItemError(id_item, "Nekorekts daudzums.");
                return ret;
            }

            if (dr_item.XIsServices) return ret;

            /*if (!dr_item.IsLASTSALEDATENull() && dr_doc.DT < dr_item.LASTSALEDATE)
            {
                ret.AddItemError(id_item, "Dokumenta datums vecāks par pēdējo reģistrēto.");
                return ret;
            }*/
            if (dr_amount == null || dr_amount.AMOUNT < dr_row.AMOUNT || allamount < dr_row.AMOUNT)
            {
                ret.AddItemError(id_item, "Nepietiekams atlikums.");
                return ret;
            }


            return ret;
        }


        public static ErrorList CheckDocForAtgrieztsNoPircēja(
            KlonsMDataSet.M_DOCSRow dr_doc, bool setprice)
        {
            var ret = new ErrorList();
            var drs_rows = dr_doc.GetM_ROWSRows().ToList();
            if (drs_rows.Count == 0)
            {
                ret.AddError("dokuments", "Dokuments nesatur rindas.");
                return ret;
            }

            var err = CheckDocHeader(dr_doc);
            if (err.HasErrors) return err;

            ret += CheckRowsForBadAcc(dr_doc);

            var ids_items_morethanone = drs_rows
                .GroupBy(x => x.IDITEM)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)
                .ToList();

            if (ids_items_morethanone.Count > 0)
            {
                foreach (int id_items_morethanone in ids_items_morethanone)
                {
                    ret.AddItemError(id_items_morethanone, "Artikuls ievadīts vairāk kā vienu reizi.");
                }
                return ret;
            }

            var items_withallamount = drs_rows
                .GroupBy(x => x.IDITEM)
                .Select(x => (key: x.Key, amount: x.Sum(y => y.AMOUNT)));

            var drs_rows_withallamount = drs_rows
                .Join(items_withallamount, x => x.IDITEM, x => x.key, (dr, y) => (dr, y.amount));


            foreach (var dr_row_withallamount in drs_rows_withallamount)
            {
                err = CheckRowForAtgrieztsNoPircēja(dr_row_withallamount.dr, dr_row_withallamount.amount);
                ret += err;
            }

            var ad = new DataSets.KlonsMRepDataSetTableAdapters.SP_M_MAKELINKS_33BTableAdapter();
            var table_rowchecks = ad.GetDataBy_SP_M_MAKELINKS_33B(dr_doc.ID);

            if (table_rowchecks.Rows.Count == 0)
            {
                ret.AddError("", "Nav atlikuma atgiešanai.");
                return ret;
            }

            foreach (var row_checks in table_rowchecks)
            {
                if (row_checks.RESULT == "OK") continue;
                err = GetErrorListFromMessage(row_checks.RESULT);
                ret += err;
            }

            if (ret.HasErrors) return ret;

            if (!setprice) return ret;

            foreach (var dr_row in drs_rows)
            {
                if (dr_row.XIsServices) continue;
                var dr_checks = table_rowchecks.Where(x => x.IDROW == dr_row.ID).Single();
                dr_row.PRICE0 = -dr_checks.SELLPRICE;
                dr_row.DISCOUNT = 0f;
                dr_row.PRICE = -dr_checks.SELLPRICE;
                dr_row.TPRICE = -dr_checks.SELLTOTALPRICE;
                dr_row.OLDPRICE = dr_checks.SELLPRICE;
                dr_row.TOLDPRICE = dr_checks.SELLTOTALPRICE;
                dr_row.BUYPRICE = dr_checks.BUYPRICE;
                dr_row.TBUYPRICE = dr_checks.BUYTOTALPRICE;
            }

            return ret;
        }

        public static ErrorList CheckRowForAtgrieztsNoPircēja(KlonsMDataSet.M_ROWSRow dr_row, decimal allamount)
        {
            var ret = new ErrorList();
            var dr_doc = dr_row.M_DOCSRow;
            var dr_item = dr_row.M_ITEMSRow;
            int id_item = dr_item.ID;

            if (dr_row.AMOUNT >= 0)
            {
                ret.AddItemError(id_item, "Atgriežot preci pircējam dokumentā uzrāda negatīvus daudzumus.");
                return ret;
            }

            if (dr_item.XIsServices) return ret;

            /*if (!dr_item.IsLASTSALEDATENull() && dr_doc.DT < dr_item.LASTSALEDATE)
            {
                ret.AddItemError(id_item, "Dokumenta datums vecāks par pēdējo reģistrēto.");
                return ret;
            }*/

            return ret;
        }

        public static ErrorList ProcessDocXXX(KlonsMDataSet.M_DOCSRow dr_doc,
            Action act)
        {
            var ret = new ErrorList();
            try
            {
                act();
                DataMLoader.LoadDocAndRowsByFilter(dr_doc.ID, false);
                DataMLoader.LoadLatestAmountsByDoc(dr_doc.ID);
                return ret;
            }
            catch (Exception ex)
            {
                ret += GetErrorListFromMessage(ex.Message);
                return ret;
            }
        }

        static int docstate_iegrāmatots = (int)EDocState.Iegrāmatots;
        public static ErrorList ProcessDocIepirkums(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = ProcessDocXXX(dr_doc, 
                () => MyData.KlonsMQueriesTableAdapter.SP_M_MAKELINKS_11(dr_doc.ID, docstate_iegrāmatots));
            return ret;
        }

        public static ErrorList ProcessDocRealizacija(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = ProcessDocXXX(dr_doc,
                () => MyData.KlonsMQueriesTableAdapter.SP_M_MAKELINKS_01B(dr_doc.ID, docstate_iegrāmatots));
            return ret;
        }

        public static ErrorList ProcessDocRealizacijasKreditrekins(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = ProcessDocXXX(dr_doc,
                () => MyData.KlonsMQueriesTableAdapter.SP_M_MAKELINKS_51B(dr_doc.ID, docstate_iegrāmatots));
            return ret;
        }

        public static ErrorList ProcessDocPiegadatajaKreditrekins(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = ProcessDocXXX(dr_doc,
                () => MyData.KlonsMQueriesTableAdapter.SP_M_MAKELINKS_61B(dr_doc.ID, docstate_iegrāmatots));
            return ret;
        }

        public static ErrorList ProcessDocAtgrieztsPiegadatajam(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = ProcessDocXXX(dr_doc,
                () => MyData.KlonsMQueriesTableAdapter.SP_M_MAKELINKS_21B(dr_doc.ID, docstate_iegrāmatots));
            return ret;
        }
        
        public static ErrorList ProcessDocAtgrieztsNoPirceja(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = ProcessDocXXX(dr_doc,
                () => MyData.KlonsMQueriesTableAdapter.SP_M_MAKELINKS_31B(dr_doc.ID, docstate_iegrāmatots));
            return ret;
        }

        public static ErrorList ProcessDocPārvietots(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = ProcessDocXXX(dr_doc,
                () => MyData.KlonsMQueriesTableAdapter.SP_M_MAKELINKS_41(dr_doc.ID, docstate_iegrāmatots));
            return ret;
        }

        public static int? GetIdFromErrorMessage(string msg, string idname)
        {
            if (msg.IsNOE()) return null;
            var s1 = $"{idname}:[";
            int k1 = msg.IndexOf(s1);
            if (k1 == -1) return null;
            k1 += s1.Length;
            int k2 = msg.IndexOf(']', k1);
            if (k2 == -1) return null;
            var s2 = msg.Substring(k1, k2 - k1);
            if (!int.TryParse(s2, out int ret)) return null;
            return ret;
        }

        public static string GetErrorInfoFromMessage(string msg)
        {
            var ret = msg;
            var s1 = msg;
            var ss = msg.Split("\r\n".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            if (ss.Length > 1 && msg.StartsWith("EX_FAILURE"))
                s1 = ss[1];
            
            if (s1.StartsWith("Amount cant be < 0"))
                return "Daudzums nedrīkst būt negatīvs.";

            bool TestErrorA(string startswith, string msgformat)
            {
                if (!s1.StartsWith(startswith)) return false;
                int? iditem = GetIdFromErrorMessage(msg, "item");
                int? idstore = GetIdFromErrorMessage(msg, "store");
                if (iditem.HasValue && idstore.HasValue)
                {
                    var itemdata = GetItemCodeAndName(iditem.Value);
                    var storecode = GetStoreCode(idstore.Value);
                    ret = $"{msgformat}\nNoliktava: {storecode}\nArtikuls: {itemdata}";
                }
                else if (iditem.HasValue)
                {
                    var itemdata = GetItemCodeAndName(iditem.Value);
                    ret = $"{msgformat}\nArtikuls: {itemdata}";
                }
                else
                {
                    ret = msgformat;
                }
                return true;
            }

            if (TestErrorA("Not enough amount in stock", 
                "Nepietiekams atlikums noliktavā."))
                return ret;

            if (TestErrorA("Not enough amount recieved from supplier to return",
                "Nepietiekams daudzums saņemts no piegādātāja lai atgrieztu."))
                return ret;

            if (TestErrorA("Not enough amount sent to buyer to return",
                "Nepietiekams atlikums nosūtīts pircējam lai atgrieztu."))
                return ret;

            if (TestErrorA("Credited amount greater than sale",
                "Kredītrēķinā daudzums lielāks kā sākotnējā rēķinā."))
                return ret;

            if (TestErrorA("Used amount greater than sale",
                "Kredītrēķinos norādītais daudzums lielāks kā sākotnējā rēķinā."))
                return ret;

            if (TestErrorA("Credited amount greater than reveived",
                "Kredītrēķinā daudzums lielāks kā sākotnējā rēķinā."))
                return ret;

            if (TestErrorA("Used amount greater than received",
                "Kredītrēķinos un izejošajos rēķinos norādītais daudzums lielāks kā sākotnējā rēķinā."))
                return ret;
            
            if (TestErrorA("Items in row used in other doc",
                "Prece izmantota citā dokumentā."))
                return ret;
            
            if (TestErrorA("Creditdoc date older than original doc",
                "Kredītrēķina datums vecāks kā originālā dokumenta datums."))
                return ret;
            
            if (TestErrorA("Amount must be negative",
                "Realizācijas kredītrēķinā norādītajiem daudzumiem jābūt negatīviem."))
                return ret;
            return ret;
        }

        public static ErrorList GetErrorListFromMessage(string msg)
        {
            var ret = new ErrorList();
            var s1 = msg;
            var ss = msg.Split("\r\n".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            if (ss.Length > 1 && msg.StartsWith("EX_FAILURE"))
                s1 = ss[1];

            if (s1.StartsWith("Amount cant be < 0"))
            {
                ret.AddError("", $"Daudzums nedrīkst būt negatīvs.");
                return ret;
            }

            bool TestErrorA(string startswith, string msgformat, string msgformat2)
            {
                if (!s1.StartsWith(startswith)) return false;
                int? iditem = GetIdFromErrorMessage(msg, "item");
                int? idstore = GetIdFromErrorMessage(msg, "store");
                if (iditem.HasValue && idstore.HasValue)
                {
                    var storecode = GetStoreCode(idstore.Value);
                    var fmsg = msgformat + string.Format(msgformat2, storecode);
                    ret.AddItemError(iditem.Value, fmsg);
                }
                else if (iditem.HasValue)
                {
                    ret.AddItemError(iditem.Value, msgformat);
                }
                else
                {
                    ret.AddError("", msgformat);
                }
                return true;
            }

            if (TestErrorA("Not enough amount in stock", 
                "Nepietiekams atlikums noliktavā.", "\nNoliktava: {0}"))
                return ret;

            if (TestErrorA("Not enough amount recieved from supplier to return",
                "Nepietiekams daudzums saņemts no piegādātāja lai atgrieztu.", 
                "\nNoliktava: {0}"))
                return ret;

            if (TestErrorA("Not enough amount sent to buyer to return",
                "Nepietiekams atlikums nosūtīts pircējam lai atgrieztu.", "\nNoliktava: {0}"))
                return ret;

            if (TestErrorA("Credited amount greater than sale",
                "Kredītrēķinā daudzums lielāks kā sākotnējā rēķinā.",
                "\nNoliktava: {0}"))
                return ret;

            if (TestErrorA("Used amount greater than sale",
                "Kredītrēķinos norādītais daudzums lielāks kā sākotnējā rēķinā.", 
                "\nNoliktava: {0}"))
                return ret;

            if (TestErrorA("Credited amount greater than reveived",
                "Kredītrēķinā daudzums lielāks kā sākotnējā rēķinā.", 
                "\nNoliktava: {0}"))
                return ret;

            if (TestErrorA("Used amount greater than received",
                "Kredītrēķinos un izejošajos rēķinos norādītais daudzums lielāks kā sākotnējā rēķinā.", 
                "\nNoliktava: {0}"))
                return ret;
            
            if (TestErrorA("Items in row used in other doc",
                "Prece izmantota citā dokumentā.", ""))
                return ret;
            
            if (TestErrorA("Creditdoc date older than original doc",
                "Kredītrēķina datums vecāks kā originālā dokumenta datums.", ""))
                return ret;
            
            if (TestErrorA("Amount must be negative",
                "Realizācijas kredītrēķinā norādītajiem daudzumiem jābūt negatīviem.", ""))
                return ret;

            ret.AddError("", msg);
            return ret;
        }

        public static ErrorList ProcessDoc(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var err = CheckDocHeader(dr_doc);
            if (err.HasErrors) return err;
            if (!dr_doc.IsOpenForChanges)
            {
                err.AddDocError(dr_doc.ID, "Dokuments jau iegrāmatots.");
                return err;
            }
            if (dr_doc.XDocType == EDocType.Iepirkums ||
                dr_doc.XDocType == EDocType.Sākuma_atlikums ||
                dr_doc.XDocType == EDocType.Pierakstīts ||
                dr_doc.XDocType == EDocType.Saražots ||
                dr_doc.XDocType == EDocType.No_noliktavas)
            {
                err = CheckDocForIncomminGoods(dr_doc);
                if (err.HasErrors) return err;
                err += ProcessDocIepirkums(dr_doc);
                return err;
            }
            if (dr_doc.XDocType == EDocType.Realizācija ||
                dr_doc.XDocType == EDocType.Norakstīts ||
                dr_doc.XDocType == EDocType.Uz_noliktavu ||
                dr_doc.XDocType == EDocType.Izlietots)
            {
                err = CheckDocForRealizacija(dr_doc);
                if (err.HasErrors) return err;
                err += ProcessDocRealizacija(dr_doc);
                return err;
            }
            if (dr_doc.XDocType == EDocType.Kredītrēķins_pircējam)
            {
                err = CheckDocForRealizacijasKreditrekins(dr_doc);
                if (err.HasErrors) return err;
                err += ProcessDocRealizacijasKreditrekins(dr_doc);
                return err;
            }
            if (dr_doc.XDocType == EDocType.Kredītrēķins_no_piegādātāja)
            {
                err = CheckDocForPiegadatajaKreditrekins(dr_doc);
                if (err.HasErrors) return err;
                err += ProcessDocPiegadatajaKreditrekins(dr_doc);
                return err;
            }
            if (dr_doc.XDocType == EDocType.Atgriezts_piegādātājam)
            {
                err = CheckDocForAtgrieztsPiegadatajam(dr_doc, false);
                if (err.HasErrors) return err;
                err += ProcessDocAtgrieztsPiegadatajam(dr_doc);
                return err;
            }
            if (dr_doc.XDocType == EDocType.Atgriezts_no_pircēja)
            {
                err = CheckDocForAtgrieztsNoPircēja(dr_doc, false);
                if (err.HasErrors) return err;
                err += ProcessDocAtgrieztsNoPirceja(dr_doc);
                return err;
            }
            if (dr_doc.XDocType == EDocType.Pārvietots)
            {
                err = ProcessDocAtgrieztsNoPirceja(dr_doc);
                return err;
            }


            return err;
        }

        public static ErrorList OpenDoc(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = new ErrorList();
            if (dr_doc.IsOpenForChanges)
                return ret;
            var newstate = (int)EDocState.Atvērts;
            try
            {
                MyData.KlonsMQueriesTableAdapter.SP_M_REMOVELINKS_01(dr_doc.ID, newstate);
                DataMLoader.LoadDocAndRowsByFilter(dr_doc.ID, false);
                DataMLoader.LoadLatestAmountsByDoc(dr_doc.ID);
                return ret;
            }
            catch (Exception ex)
            {
                ret += GetErrorListFromMessage(ex.Message);
            }
            return ret;
        }

        public static ErrorList RecalcDoc(KlonsMDataSet.M_DOCSRow dr_doc, EDocState newstate) 
        {
            var ret = new ErrorList();
            try
            {
                //MyData.KlonsMQueriesTableAdapter.SP_M_RECALCITEM_01C(dr_doc.ID, (int)newstate, 0);
                var rt = FullRecalcDocA(dr_doc.ID, newstate);
                if (rt != "OK") return ret;
                DataMLoader.LoadDocAndRowsByFilter(dr_doc.ID, false);
                DataMLoader.LoadLatestAmountsByDoc(dr_doc.ID);
                return ret;
            }
            catch (Exception ex)
            {
                ret += GetErrorListFromMessage(ex.Message);
            }
            return ret;
        }

        public static string CopyDoc(KlonsMDataSet.M_DOCSRow dr_doc,
            out KlonsMDataSet.M_DOCSRow new_dr_doc)
        {
            new_dr_doc = null;

            var table_docs = MyData.DataSetKlonsM.M_DOCS;
            var table_rows = MyData.DataSetKlonsM.M_ROWS;
            var drs_rows = dr_doc.GetM_ROWSRows()
                .OrderBy(x => x.IDSEQ)
                .ToList();

            new_dr_doc = table_docs.NewM_DOCSRow();
            new_dr_doc.BeginEdit();
            new_dr_doc.DT = DateTime.Today;
            new_dr_doc.XDocType = dr_doc.XDocType;
            new_dr_doc.XDocType2 = dr_doc.XDocType2;
            new_dr_doc.XState = EDocState.Melnraksts;
            new_dr_doc.SR = dr_doc.SR;
            new_dr_doc.NR = dr_doc.NR;
            new_dr_doc.IDSTOREIN = dr_doc.IDSTOREIN;
            new_dr_doc.IDSTOREOUT = dr_doc.IDSTOREOUT;

            new_dr_doc["IDCARRIER"] = dr_doc["IDCARRIER"];
            new_dr_doc["IDADDRESSOUT"] = dr_doc["IDADDRESSOUT"];
            new_dr_doc["IDADDRESSIN"] = dr_doc["IDADDRESSIN"];
            new_dr_doc["IDPAYMENTTYPE"] = dr_doc["IDPAYMENTTYPE"];
            new_dr_doc["IDDRIVER"] = dr_doc["IDDRIVER"];
            new_dr_doc["DUEDATE"] = dr_doc["DUEDATE"];

            new_dr_doc.PVNTYPE = dr_doc.PVNTYPE;
            new_dr_doc.SUMM = dr_doc.SUMM;
            new_dr_doc.ACCIN = dr_doc.ACCOUT;
            new_dr_doc.ACCOUT = dr_doc.ACCIN;
            new_dr_doc.IDSEQ = GetNextIdSeq();
            //new_dr_doc["IDCREDDOC"] = dr_doc["IDCREDDOC"];
            //new_dr_doc["CREDDOCDT"] = dr_doc["CREDDOCDT"];
            //new_dr_doc.CREDDOCSR = dr_doc.SR;
            //new_dr_doc.CREDDOCNR = dr_doc.NR;
            new_dr_doc.EndEdit();
            table_docs.AddM_DOCSRow(new_dr_doc);

            foreach (var dr_row in drs_rows)
            {
                var new_dr_row = table_rows.NewM_ROWSRow();
                new_dr_row.BeginEdit();
                new_dr_row.IDDOC = new_dr_doc.ID;
                new_dr_row.M_DOCSRow = new_dr_doc;
                //new_dr_row.IDCREDROW = dr_row.IDCREDROW;
                new_dr_row.IDITEM = dr_row.IDITEM;
                new_dr_row.IDPVNRATE = dr_row.IDPVNRATE;
                new_dr_row.UNITS = dr_row.UNITS;
                new_dr_row.IDSEQ = dr_row.IDSEQ;
                new_dr_row.AMOUNT = dr_row.AMOUNT;
                new_dr_row.DISCOUNT = dr_row.DISCOUNT;
                new_dr_row.PRICE0 = dr_row.PRICE;
                new_dr_row.PRICE = dr_row.PRICE;
                new_dr_row.TPRICE = dr_row.TPRICE;
                new_dr_row.BUYPRICE = dr_row.BUYPRICE;
                new_dr_row.TBUYPRICE = dr_row.TBUYPRICE;
                new_dr_row.ACC6 = dr_row.ACC6;
                new_dr_row.ACC7 = dr_row.ACC7;
                new_dr_row.EndEdit();
                table_rows.AddM_ROWSRow(new_dr_row);
            }

            return "OK";
        }

        public static string MakeCreditDoc(KlonsMDataSet.M_DOCSRow dr_doc,
            out KlonsMDataSet.M_DOCSRow new_dr_doc)
        {
            new_dr_doc = null;
            if (dr_doc.XState == EDocState.Melnraksts || dr_doc.XState == EDocState.Atvērts)
                return "Dokuments nav iegrāmatots.";
            if (dr_doc.XDocType != EDocType.Iepirkums && dr_doc.XDocType != EDocType.Realizācija)
                return "Kredītrēķinu var veidot tikai iepirkuma vai realizācijas dokumentam.";
            
            EDocType new_doctype = EDocType.Kredītrēķins_pircējam;
            if (dr_doc.XDocType == EDocType.Iepirkums)
                new_doctype = EDocType.Kredītrēķins_no_piegādātāja;
            
            var table_docs = MyData.DataSetKlonsM.M_DOCS;
            var table_rows = MyData.DataSetKlonsM.M_ROWS;
            var drs_rows = dr_doc.GetM_ROWSRows()
                .OrderBy(x => x.IDSEQ)
                .ToList();

            new_dr_doc = table_docs.NewM_DOCSRow();
            new_dr_doc.BeginEdit();
            new_dr_doc.IDCREDDOC = dr_doc.ID;
            new_dr_doc.DT = DateTime.Today;
            new_dr_doc.XDocType = new_doctype;
            new_dr_doc.XDocType2 = dr_doc.XDocType2;
            new_dr_doc.XState = EDocState.Melnraksts;
            new_dr_doc.SR = dr_doc.SR;
            new_dr_doc.NR = dr_doc.NR;
            if (new_doctype == EDocType.Kredītrēķins_pircējam)
            {
                new_dr_doc.IDSTOREIN = dr_doc.IDSTOREIN;
                new_dr_doc.IDSTOREOUT = dr_doc.IDSTOREOUT;
                new_dr_doc.ACCIN = dr_doc.ACCIN;
                new_dr_doc.ACCOUT = dr_doc.ACCOUT;
            }
            else
            {
                new_dr_doc.IDSTOREIN = dr_doc.IDSTOREOUT;
                new_dr_doc.IDSTOREOUT = dr_doc.IDSTOREIN;
                new_dr_doc.ACCIN = dr_doc.ACCOUT;
                new_dr_doc.ACCOUT = dr_doc.ACCIN;
            }
            new_dr_doc.PVNTYPE = dr_doc.PVNTYPE;
            new_dr_doc.IDSEQ = GetNextIdSeq();
            new_dr_doc.CREDDOCDT = dr_doc.DT;
            new_dr_doc.CREDDOCSR = dr_doc.SR;
            new_dr_doc.CREDDOCNR = dr_doc.NR;
            new_dr_doc.EndEdit();
            table_docs.AddM_DOCSRow(new_dr_doc);

            foreach(var dr_row in drs_rows)
            {
                var new_dr_row = table_rows.NewM_ROWSRow();
                new_dr_row.BeginEdit();
                new_dr_row.IDDOC = new_dr_doc.ID;
                new_dr_row.M_DOCSRow = new_dr_doc;
                new_dr_row.IDCREDROW = dr_row.ID;
                new_dr_row.IDITEM = dr_row.IDITEM;
                new_dr_row.IDPVNRATE = dr_row.IDPVNRATE;
                new_dr_row.UNITS = dr_row.UNITS;
                new_dr_row.IDSEQ = dr_row.IDSEQ;
                new_dr_row.PRICE0 = dr_row.PRICE;
                new_dr_row.PRICE = dr_row.PRICE;
                if (new_doctype == EDocType.Kredītrēķins_pircējam)
                {
                    new_dr_row.AMOUNT = -dr_row.AMOUNT;
                    new_dr_row.TPRICE = -dr_row.TPRICE;
                }
                else
                {
                    new_dr_row.AMOUNT = dr_row.AMOUNT;
                    new_dr_row.TPRICE = dr_row.TPRICE;
                }
                if (new_doctype == EDocType.Kredītrēķins_pircējam)
                {
                    new_dr_row.OLDPRICE = dr_row.PRICE;
                    new_dr_row.TOLDPRICE = dr_row.TPRICE;
                }
                new_dr_row.BUYPRICE = dr_row.BUYPRICE;
                new_dr_row.TBUYPRICE = dr_row.TBUYPRICE;
                new_dr_row.ACC6 = dr_row.ACC6;
                new_dr_row.ACC7 = dr_row.ACC7;
                new_dr_row.EndEdit();
                table_rows.AddM_ROWSRow(new_dr_row);
            }

            return "OK";
        }


        public static ErrorList MakeCreditDocsFromAtgrieztsPiegadatajam(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = new ErrorList();
            if (!dr_doc.IsOpenForChanges)
            {
                ret.AddError("", "Dokuments nevar būt iegrāmatots.");
                return ret;
            }
            if (dr_doc.XDocType != EDocType.Atgriezts_piegādātājam)
            {
                ret.AddError("", "Dokumenta veidam jābūt Atgriezts piegādātājam.");
                return ret;
            }

            var new_doctype = EDocType.Kredītrēķins_no_piegādātāja;

            var table_docs = MyData.DataSetKlonsM.M_DOCS;
            var table_rows = MyData.DataSetKlonsM.M_ROWS;
            var drs_rows = dr_doc.GetM_ROWSRows()
                .OrderBy(x => x.IDSEQ)
                .ToList();

            if(drs_rows.Count == 0)
            {
                ret.AddError("", "Dokumentam nav izveidotas rindas.");
                return ret;
            }

            var ad = new DataSets.KlonsMRepDataSetTableAdapters.SP_M_MAKELINKS_23BTableAdapter();
            var table_usedrows = ad.GetDataBy_SP_M_MAKELINKS_23B(dr_doc.ID);

            if (table_usedrows.Rows.Count == 0)
            {
                ret.AddError("", "Nav atlikumu atgiešanai.");
                return ret;
            }

            foreach (var dr_row in drs_rows)
            {
                var drs_usage = table_usedrows.Where(x => x.IDROW == dr_row.ID).ToList();
                var tamount = drs_usage.Count > 0 ? drs_usage.Sum(x => x.AMOUNT) : 0M;
                if (tamount != dr_row.AMOUNT)
                {
                    ret.AddItemError(dr_row.IDITEM, "Nav atlikuma atgiešanai.");
                }
            }

            if (ret.HasErrors) return ret;

            var grps_cred = table_usedrows
                .GroupBy(x => x.CREDDOCID)
                .ToList();

            foreach(var grp_cred in grps_cred)
            {
                var new_dr_doc = table_docs.NewM_DOCSRow();
                var grp_cred_r1 = grp_cred.First();
                new_dr_doc.BeginEdit();
                new_dr_doc.DT = DateTime.Today;
                new_dr_doc.XDocType = new_doctype;
                new_dr_doc.XDocType2 = dr_doc.XDocType2;
                new_dr_doc.XState = EDocState.Melnraksts;
                new_dr_doc.SR = "?";
                new_dr_doc.NR = "?";
                new_dr_doc.IDSTOREIN = dr_doc.IDSTOREIN;
                new_dr_doc.IDSTOREOUT = dr_doc.IDSTOREOUT;
                new_dr_doc.PVNTYPE = dr_doc.PVNTYPE;
                new_dr_doc.ACCIN = dr_doc.ACCIN;
                new_dr_doc.ACCOUT = dr_doc.ACCOUT;
                new_dr_doc.IDSEQ = GetNextIdSeq();
                new_dr_doc.IDCREDDOC = grp_cred_r1.CREDDOCID;
                new_dr_doc.CREDDOCDT = grp_cred_r1.CREDDOCDT;
                new_dr_doc.CREDDOCSR = grp_cred_r1.CREDDOCSR;
                new_dr_doc.CREDDOCNR = grp_cred_r1.CREDDOCNR;
                new_dr_doc.EndEdit();
                table_docs.AddM_DOCSRow(new_dr_doc);

                foreach (var cred_row in grp_cred)
                {
                    var cdr_row = drs_rows.Where(x => x.ID == cred_row.IDROW).First();
                    var new_dr_row = table_rows.NewM_ROWSRow();
                    new_dr_row.BeginEdit();
                    new_dr_row.IDDOC = new_dr_doc.ID;
                    new_dr_row.M_DOCSRow = new_dr_doc;
                    new_dr_row.IDCREDROW = cred_row.CREDROWID;
                    new_dr_row.IDITEM = cdr_row.IDITEM;
                    new_dr_row.IDPVNRATE = cdr_row.IDPVNRATE;
                    new_dr_row.UNITS = cdr_row.UNITS;
                    new_dr_row.IDSEQ = cdr_row.IDSEQ;
                    new_dr_row.AMOUNT = cred_row.AMOUNT;
                    new_dr_row.PRICE0 = cred_row.BUYPRICE;
                    new_dr_row.PRICE = cred_row.BUYPRICE;
                    new_dr_row.TPRICE = cred_row.TBUYPRICE;
                    new_dr_row.BUYPRICE = cred_row.BUYPRICE;
                    new_dr_row.TBUYPRICE = cred_row.TBUYPRICE;
                    new_dr_row.ACC6 = cdr_row.ACC6;
                    new_dr_row.ACC7 = cdr_row.ACC7;
                    new_dr_row.EndEdit();
                    table_rows.AddM_ROWSRow(new_dr_row);
                }
            }

            return ret;
        }

        public static ErrorList MakeCreditDocsFromAtgrieztsNoPirceja(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = new ErrorList();
            if (!dr_doc.IsOpenForChanges)
            {
                ret.AddError("", "Dokuments nevar būt iegrāmatots.");
                return ret;
            }
            if (dr_doc.XDocType != EDocType.Atgriezts_no_pircēja)
            {
                ret.AddError("", "Dokumenta veidam jābūt Atgriezts no pircēja.");
                return ret;
            }

            var new_doctype = EDocType.Kredītrēķins_pircējam;

            var table_docs = MyData.DataSetKlonsM.M_DOCS;
            var table_rows = MyData.DataSetKlonsM.M_ROWS;
            var drs_rows = dr_doc.GetM_ROWSRows()
                .OrderBy(x => x.IDSEQ)
                .ToList();

            if (drs_rows.Count == 0)
            {
                ret.AddError("", "Dokumentam nav izveidotas rindas.");
                return ret;
            }

            var ad = new DataSets.KlonsMRepDataSetTableAdapters.SP_M_MAKELINKS_32BTableAdapter();
            var table_usedrows = ad.GetDataBy_SP_M_MAKELINKS_32B(dr_doc.ID);

            if (table_usedrows.Rows.Count == 0)
            {
                ret.AddError("", "Nav atlikumu atgiešanai.");
                return ret;
            }

            foreach (var dr_row in drs_rows)
            {
                var drs_usage = table_usedrows.Where(x => x.IDROW == dr_row.ID).ToList();
                var tamount = drs_usage.Count > 0 ? drs_usage.Sum(x => x.AMOUNT) : 0M;
                if (tamount != -dr_row.AMOUNT)
                {
                    ret.AddItemError(dr_row.IDITEM, "Nav atlikuma atgiešanai.");
                }
            }

            if (ret.HasErrors) return ret;

            var grps_cred = table_usedrows
                .GroupBy(x => x.CREDDOCID)
                .ToList();

            foreach (var grp_cred in grps_cred)
            {
                var new_dr_doc = table_docs.NewM_DOCSRow();
                var grp_cred_r1 = grp_cred.First();
                new_dr_doc.BeginEdit();
                new_dr_doc.DT = DateTime.Today;
                new_dr_doc.XDocType = new_doctype;
                new_dr_doc.XDocType2 = dr_doc.XDocType2;
                new_dr_doc.XState = EDocState.Melnraksts;
                new_dr_doc.SR = "?";
                new_dr_doc.NR = "?";
                new_dr_doc.IDSTOREIN = dr_doc.IDSTOREIN;
                new_dr_doc.IDSTOREOUT = dr_doc.IDSTOREOUT;
                new_dr_doc.PVNTYPE = dr_doc.PVNTYPE;
                new_dr_doc.ACCIN = dr_doc.ACCIN;
                new_dr_doc.ACCOUT = dr_doc.ACCOUT;
                new_dr_doc.IDSEQ = GetNextIdSeq();
                new_dr_doc.IDCREDDOC = grp_cred_r1.CREDDOCID;
                new_dr_doc.CREDDOCDT = grp_cred_r1.CREDDOCDT;
                new_dr_doc.CREDDOCSR = grp_cred_r1.CREDDOCSR;
                new_dr_doc.CREDDOCNR = grp_cred_r1.CREDDOCNR;
                new_dr_doc.EndEdit();
                table_docs.AddM_DOCSRow(new_dr_doc);

                foreach (var cred_row in grp_cred)
                {
                    var cdr_row = drs_rows.Where(x => x.ID == cred_row.IDROW).First();
                    var new_dr_row = table_rows.NewM_ROWSRow();
                    new_dr_row.BeginEdit();
                    new_dr_row.IDDOC = new_dr_doc.ID;
                    new_dr_row.M_DOCSRow = new_dr_doc;
                    new_dr_row.IDCREDROW = cred_row.CREDROWID;
                    new_dr_row.IDITEM = cdr_row.IDITEM;
                    new_dr_row.IDPVNRATE = cdr_row.IDPVNRATE;
                    new_dr_row.UNITS = cdr_row.UNITS;
                    new_dr_row.IDSEQ = cdr_row.IDSEQ;
                    new_dr_row.AMOUNT = -cred_row.AMOUNT;
                    new_dr_row.PRICE0 = cred_row.PRICE;
                    new_dr_row.PRICE = cred_row.PRICE;
                    new_dr_row.TPRICE = -cred_row.TPRICE;
                    new_dr_row.BUYPRICE = cred_row.PRICE;
                    new_dr_row.TBUYPRICE = cred_row.TPRICE;
                    new_dr_row.ACC6 = cdr_row.ACC6;
                    new_dr_row.ACC7 = cdr_row.ACC7;
                    new_dr_row.EndEdit();
                    table_rows.AddM_ROWSRow(new_dr_row);
                }
            }

            return ret;
        }
        
        public static void DeleteLocalFinDocByIdDocM(int iddocm)
        {
            var table_fdocs = MyData.DataSetKlons.OPSd;
            var drs_doc = table_fdocs
                .WhereX(x => x.IDDOCM == iddocm)
                .ToList();
            if (drs_doc.Count == 0) return;
            foreach (var dr_doc in drs_doc)
            {
                dr_doc.Delete();
            }
        }

        public static void DetachFinDocByIdDocM(int iddocm)
        {
            var table_fdocs = MyData.DataSetKlons.OPSd;
            var table_frows = MyData.DataSetKlons.OPS;
            var drs_doc = table_fdocs
                .WhereX(x => !x.IsIDDOCMNull() && x.IDDOCM == iddocm)
                .ToList();
            if (drs_doc.Count == 0) return;
            foreach (var dr_doc in drs_doc)
            {
                var drs_row = dr_doc.GetOPSRows();
                foreach (var dr_row in drs_row)
                {
                    table_frows.RemoveOPSRow(dr_row);
                }
                table_fdocs.RemoveOPSdRow(dr_doc);
            }
        }


        public static int RowCountForFullRecalcEvents = -1;

        public static string FullRecalc()
        {
            try
            {
                return FullRecalcA();
            }
            catch (Exception ex)
            {
                return GetErrorInfoFromMessage(ex.Message);
            }
        }

        public static string RecalcAmounts()
        {
            try
            {
                return RecalcAmountsA();
            }
            catch (Exception ex)
            {
                return GetErrorInfoFromMessage(ex.Message);
            }
        }

        public static string RecalcIsGone()
        {
            try
            {
                return RecalcIsGoneA();
            }
            catch (Exception ex)
            {
                return GetErrorInfoFromMessage(ex.Message);
            }
        }

        static FbCommand Create_CM_SP_M_RECALCITEM_01A()
        {
            var cm = new FbCommand();
            cm.CommandText = "\"SP_M_RECALCITEM_01A\"";
            cm.CommandType = CommandType.StoredProcedure;
            var param = new FbParameter();
            param.ParameterName = "PSTARTDATE";
            param.DbType = DbType.DateTime;
            param.Size = 4;
            param.IsNullable = true;
            cm.Parameters.Add(param);
            param = new FbParameter();
            param.ParameterName = "PPROGRESSTEP";
            param.DbType = DbType.Int32;
            param.Size = 4;
            param.IsNullable = true;
            cm.Parameters.Add(param);
            return cm;
        }

        static FbCommand Create_CM_SP_M_RECALCITEM_01C()
        {
            var cm = new FbCommand();
            cm.CommandText = "\"SP_M_RECALCITEM_01C\"";
            cm.CommandType = CommandType.StoredProcedure;
            var param = new FbParameter();
            param.ParameterName = "PIDDOC";
            param.DbType = DbType.Int32;
            param.Size = 4;
            param.IsNullable = true;
            cm.Parameters.Add(param);
            param = new FbParameter();
            param.ParameterName = "PNEWDOCSTATE";
            param.DbType = DbType.Int32;
            param.Size = 4;
            param.IsNullable = true;
            cm.Parameters.Add(param);
            param.ParameterName = "PPROGRESSTEP";
            param.DbType = DbType.Int32;
            param.Size = 4;
            param.IsNullable = true;
            cm.Parameters.Add(param);
            return cm;
        }

        public static string FullRecalcA()
        {
            int progressstep = 0;
            if (RowCountForFullRecalcEvents == -1)
                RowCountForFullRecalcEvents = (int)MyData.KlonsMRepQueriesTableAdapter.SP_M_GETCOUNTSFOREVENTS(1, 0);
            bool hasevents = RowCountForFullRecalcEvents > 50000;
            if (hasevents)
                progressstep = 15000;

            //Func<object> func = () => MyData.KlonsMQueriesTableAdapter.SP_M_RECALCITEM_01A(null, progressstep);

            var cm = Create_CM_SP_M_RECALCITEM_01A();
            cm.Parameters[0].Value = DBNull.Value;
            cm.Parameters[1].Value = progressstep;

            var frm = new FormsM.FormM_SPRunner();
            frm.SPCommand = cm;
            //frm.TaskFunc = func;
            frm.TaskText = "Pilns pārrēķins.";
            frm.TextDoneText = "Pārrēķins pabeigts.  (izpildes laiks: {0})";
            frm.CanCancel = true;
            frm.HasProgressEvents = hasevents;
            frm.MaxProgressValue = RowCountForFullRecalcEvents;
            frm.ProgressEventStep = 15000;
            
            var rt = frm.ShowDialog(MyData.MyMainForm);

            if (rt == System.Windows.Forms.DialogResult.Abort)
                return "Aborted";
            if (rt == System.Windows.Forms.DialogResult.Cancel)
                return "Canceled";
            DataMLoader.LoadLatestAmounts();
            return "OK";
        }

        public static string FullRecalcDocA(int iddoc, EDocState newstate)
        {
            int progressstep = 0;
            if (RowCountForFullRecalcEvents == -1)
                RowCountForFullRecalcEvents = (int)MyData.KlonsMRepQueriesTableAdapter.SP_M_GETCOUNTSFOREVENTS(1, 0);
            bool hasevents = RowCountForFullRecalcEvents > 50000;
            if (hasevents)
            {
                progressstep = 15000;
                int maxcount = (int)MyData.KlonsMRepQueriesTableAdapter.SP_M_GETCOUNTSFOREVENTS(2, iddoc);
                hasevents = maxcount > 50000;
            }

            //Func<object> func = () => MyData.KlonsMQueriesTableAdapter.SP_M_RECALCITEM_01C(iddoc, (int)newstate, progressstep);

            var cm = Create_CM_SP_M_RECALCITEM_01C();
            cm.Parameters[0].Value = iddoc;
            cm.Parameters[2].Value = (int)newstate;
            cm.Parameters[3].Value = progressstep;

            var frm = new FormsM.FormM_SPRunner();
            frm.SPCommand = cm;
            //frm.TaskFunc = func;
            frm.TaskText = "Pilns dokumenta pārrēķins.";
            frm.TextDoneText = "Pārrēķins pabeigts.  (zpildes laiks: {0})";
            frm.CanCancel = true;
            frm.HasProgressEvents = hasevents;
            frm.MaxProgressValue = RowCountForFullRecalcEvents;
            frm.ProgressEventStep = 15000;

            var rt = frm.ShowDialog(MyData.MyMainForm);

            if (rt == System.Windows.Forms.DialogResult.Abort)
                return "Aborted";
            if (rt == System.Windows.Forms.DialogResult.Cancel)
                return "Canceled";
            DataMLoader.LoadLatestAmounts();
            return "OK";
        }

        public static string RecalcAmountsA()
        {
            Func<object> func = () => MyData.KlonsMRepQueriesTableAdapter.SP_M_RECALCAMOUNTS_1();
            var frm = new FormsM.FormM_SPRunner();
            frm.TaskText = "Atlikumu pārrēķins.";
            frm.TextDoneText = "Atlikumu pārrēķins pabeigts.";
            frm.CanCancel = false;
            frm.TaskFunc = func;
            frm.HasProgressEvents = false;
            var rt = frm.ShowDialog(MyData.MyMainForm);
            if (rt == System.Windows.Forms.DialogResult.Abort)
                return "Aborted";
            if (rt == System.Windows.Forms.DialogResult.Cancel)
                return "Canceled";
            DataMLoader.LoadLatestAmounts();
            return "OK";
        }

        public static string RecalcIsGoneA()
        {
            Func<object> func = () => MyData.KlonsMRepQueriesTableAdapter.SP_M_RECALC_ROWSISGONE_1();
            var frm = new FormsM.FormM_SPRunner();
            frm.TaskText = "Izlietojuma pazīmes pārrēķins.";
            frm.TextDoneText = "Pārrēķins pabeigts.";
            frm.CanCancel = false;
            frm.TaskFunc = func;
            frm.HasProgressEvents = false;
            var rt = frm.ShowDialog(MyData.MyMainForm);
            if (rt == System.Windows.Forms.DialogResult.Abort)
                return "Aborted";
            if (rt == System.Windows.Forms.DialogResult.Cancel)
                return "Canceled";
            return "OK";
        }

        public static void SetNewIDs(MyAdapterManager adaptermanager)
        {
            if (adaptermanager.TableNames == null) return;
            SetNewIDs(adaptermanager.TableNames);
        }

        public static void SetNewIDs(params string[] tablenames)
        {
            foreach (var tablename in tablenames)
            {
                switch (tablename)
                {
                    case "M_DOCS":
                        SetNewIDs(x => x.M_DOCS, x => x.SP_GEN_M_DOCS_ID);
                        break;
                    case "M_ROWS":
                        SetNewIDs(x => x.M_ROWS, x => x.SP_GEN_M_ROWS_ID);
                        break;
                    case "M_ITEMS":
                        SetNewIDs(x => x.M_ITEMS, x => x.SP_GEN_M_ITEMS_ID);
                        break;
                    case "M_ITEMS_CAT":
                        SetNewIDs(x => x.M_ITEMS_CAT, x => x.SP_GEN_M_ITEMS_CAT_ID);
                        break;
                    case "M_STORES":
                        SetNewIDs(x => x.M_STORES, x => x.SP_GEN_M_STORES_ID);
                        break;
                    case "M_CONTACTS":
                        SetNewIDs(x => x.M_CONTACTS, x => x.SP_GEN_M_CONTACTS_ID);
                        break;
                    case "M_ADDRESSSES":
                        SetNewIDs(x => x.M_ADDRESSSES, x => x.SP_GEN_M_ADDRESSSES_ID);
                        break;
                    case "M_VEHICLES":
                        SetNewIDs(x => x.M_VEHICLES, x => x.SP_GEN_M_VEHICLES_ID);
                        break;
                    case "M_BANKACCOUNTS":
                        SetNewIDs(x => x.M_BANKACCOUNTS, x => x.SP_GEN_M_BANKACCOUNTS_ID);
                        break;
                    case "M_BANKS":
                        SetNewIDs(x => x.M_BANKS, x => x.SP_GEN_M_BANKS_ID);
                        break;
                    case "M_COUNTRIES":
                        SetNewIDs(x => x.M_COUNTRIES, x => x.SP_GEN_M_COUNTRIES_ID);
                        break;
                    case "M_STORETYPE":
                        SetNewIDs(x => x.M_STORETYPE, x => x.SP_GEN_M_STORETYPE_ID);
                        break;
                    case "M_DOCTYPES":
                        SetNewIDs(x => x.M_DOCTYPES, x => x.SP_GEN_M_DOCTYPES_ID);
                        break;
                    case "M_UNITS":
                        SetNewIDs(x => x.M_UNITS, x => x.SP_GEN_M_UNITS_ID);
                        break;
                    case "M_PAYMENTTYPE":
                        SetNewIDs(x => x.M_PAYMENTTYPE, x => x.SP_GEN_M_PAYMENTTYPE_ID);
                        break;
                    case "M_TRANSACTIONTYPE":
                        SetNewIDs(x => x.M_TRANSACTIONTYPE, x => x.SP_GEN_M_TRANSACTIONTYPE_ID);
                        break;
                    case "M_PVNRATES":
                        SetNewIDs(x => x.M_PVNRATES, x => x.SP_GEN_M_PVNRATES_ID);
                        break;
                    case "M_PVNRATES2":
                        SetNewIDs(x => x.M_PVNRATES2, x => x.SP_GEN_M_PVNRATES2_ID);
                        break;
                    case "M_PVNTEXTS":
                        SetNewIDs(x => x.M_PVNTEXTS, x => x.SP_GEN_M_PVNTEXTS_ID);
                        break;
                }

            }

        }

        private static void SetNewIDs(
            DataTable table, 
            Func<int> func_getid,
            string idcolumnname = "ID")
        {
            var drs = DataSetHelper.GetNewRows(MyData.DataSetKlonsM.M_UNITS);
            foreach (var dr in drs)
            {
                if ((int)dr[idcolumnname] >= 0) continue;
                int new_id = func_getid();
                dr[idcolumnname] = new_id;
            }
        }

        private static void SetNewIDs(
            Func<KlonsMDataSet, DataTable> func_gettable,
            Func<DataSets.KlonsMDataSetTableAdapters.QueriesTableAdapter, Func<object>> func_getidfunc,
            string idcolumnname = "ID")
        {
            var table = func_gettable(MyData.DataSetKlonsM);
            var drs = DataSetHelper.GetNewRows(table);
            var adapter = func_getidfunc(MyData.KlonsMQueriesTableAdapter);
            foreach (var dr in drs)
            {
                if ((int)dr[idcolumnname] >= 0) continue;
                int new_id = (int)adapter();
                dr[idcolumnname] = new_id;
            }
        }
    }

    public class ErrorInfo
    {
        public string Source { get; set; } = null;
        public string Message { get; set; } = null;

        public void SetItemError(int iditem, string msg)
        {
            var table_items = KlonsData.St.DataSetKlonsM.M_ITEMS;
            if (table_items != null)
            {
                var dr = table_items.FindByID(iditem);
                if (dr != null)
                    Source = $"artikuls: {dr.BARCODE} {dr.NAME}";
            }
            Message = msg;
        }

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

        public void AddItemError(int iditem, string msg)
        {
            var ei = new ErrorInfo();
            ei.SetItemError(iditem, msg);
            Add(ei);
        }

        public void AddDocError(int iddoc, string msg)
        {
            var ei = new ErrorInfo();
            var table_docs = KlonsData.St.DataSetKlonsM.M_DOCS;
            if (table_docs != null)
            {
                var dr = table_docs.FindByID(iddoc);
                if (dr != null)
                    ei.Source = $"dokuments: {Utils.DateToString(dr.DT)} {dr.DocSrNr}";
            }
            ei.Message = msg;
            Add(ei);
        }

        public void SetErrorList(ErrorList newlist)
        {
            Clear();
            AddRange(newlist);
        }

        public bool HasSourceData => this.Where(x => !x.Source.IsNOE()).Any();

        public static ErrorList operator +(ErrorList e1, ErrorList e2)
        {
            if (e1 == null || e2 == null) return e1;
            e1.AddRange(e2);
            return e1;
        }

    }

}
