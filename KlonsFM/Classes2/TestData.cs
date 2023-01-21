using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlonsFM.DataSets;
using KlonsFM.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Data;
using KlonsLIB.Misc;
using KlonsFM.UI;
using KlonsLIB.Components;

namespace KlonsFM.Classes2
{
    public class TDItem
    {
        public int Index;
        public int ID;
        public string Code;
        public string Name;
        public int Saldo;
        public decimal BuyPrice;
        public decimal BuyPriceDelta; //% +/- 20%
        public decimal SellPrice;
        public decimal SellPriceDelta; //% +/- 20%
        public int SaleRelativeProb; // 1-10
        public TDSupplier Supplier;
    }

    public class TDPartner
    {
        public int Index;
        public int ID;
        public string Code;
        public string Name;
    }

    public class TDSupplier : TDPartner
    {
        public List<TDItem> Items = new List<TDItem>();
    }

    public class TDBuyer : TDPartner
    {
    }

    public class TDInvoiceRow
    {
        public int Index;
        public int ID;
        public TDItem Item;
        public int Amount;
        public decimal Price;
        public decimal TPrice;
    }

    public class TDInvoice
    {
        public int Index;
        public int ID;
        public TDPartner Partner;
        public List<TDInvoiceRow> Rows = new List<TDInvoiceRow>();
    }

    public class TDDay
    {
        public int Index;
        public List<TDInvoice> Sales = new List<TDInvoice>();
        public List<TDInvoice> Deliveries = new List<TDInvoice>();
    }

    public class TDMain
    {
        public List<TDItem> Items = new List<TDItem>();
        public List<TDPartner> Partners = new List<TDPartner>();
        public List<TDSupplier> Suppliers = new List<TDSupplier>();
        public List<TDBuyer> Buyers = new List<TDBuyer>();
        public List<TDDay> Days = new List<TDDay>();
        public Random Rnd = new Random();

        //Config
        public int CountOfItems = 1000;
        public int CountOfSuppliers = 50;
        public int CountOfBuyers = 1000;
        public decimal PriceMin = 1M;
        public decimal PriceMax = 500M;
        public int SalesPerDay = 100;
        public int ItemsPerSaleMin = 2;
        public int ItemsPerSaleMax = 20;
        public int ItemsCountPerSaleMin = 1;
        public int ItemsCountPerSaleMax = 5;
        public int DeliveryIntervalInDays = 5;
        public int CountOfDays = 365*3;
        public int FirstSaleDay = 10;

        public int ItemsId0 = 1000;
        public int PartnersId0 = 1000;
        public int DocsId0 = 1000;
        public int RowsId0 = 1000;
        public int DocsIdCurrrent = 1000;
        public int RowsIdCurrrent = 1000;

        public string Acc21 = "2131";
        public string Acc23 = "2310";
        public string Acc53 = "5310";
        public string Acc6 = "6111";
        public string Acc7 = "7110";

        public string ItemsCat = "A-A-01";
        public int IdItemsCat = 0;

        public string OurStoreCode = "N1";
        public int IdOurStore = 0;

        public string UnitsCode = "gab.";
        public int IdUnits = 0;

        public string PVNRateCode = "A21";
        public int IdPVNRate = 0;

        public void InitIds()
        {
            IdItemsCat = KlonsData.St.DataSetKlonsM.M_ITEMS_CAT
                .Where(x => x.CODE == ItemsCat)
                .SingleOrDefault()
                .ID;
            IdOurStore = KlonsData.St.DataSetKlonsM.M_STORES
                .Where(x => x.CODE == OurStoreCode)
                .SingleOrDefault()
                .ID;
            IdUnits = KlonsData.St.DataSetKlonsM.M_UNITS
                .Where(x => x.CODE == UnitsCode)
                .SingleOrDefault()
                .ID;
            IdPVNRate = KlonsData.St.DataSetKlonsM.M_PVNRATES
                .Where(x => x.CODE == PVNRateCode)
                .SingleOrDefault()
                .ID;
        }

        public void MakeItems()
        {
            for (int i = 0; i < CountOfItems; i++)
            {
                var newitem = new TDItem()
                {
                    ID = ItemsId0 + i,
                    Index = i,
                    Code = $"{i + 1:000000}",
                    Name = $"Prece {i + 1}",
                    BuyPrice = (decimal)Rnd.NextDouble() * (PriceMax - PriceMin) + PriceMax,
                    SaleRelativeProb = Rnd.Next(1, 11)
                };
                newitem.BuyPriceDelta = newitem.BuyPrice * 0.3M * (decimal)Rnd.NextDouble();
                newitem.SellPrice = newitem.BuyPrice * 1.3M;
                newitem.SellPriceDelta = newitem.SellPrice * 0.2M * (decimal)Rnd.NextDouble();
                Items.Add(newitem);
            }
        }

        public void MakePartners()
        {
            int id = PartnersId0;
            for (int i = 0; i < CountOfSuppliers; i++)
            {
                var newsupplier = new TDSupplier()
                {
                    Index = i,
                    ID = id,
                    Code = $"tpieg {i + 1}",
                    Name = $"Piegādātājs {i + 1}"
                };
                id++;
                Suppliers.Add(newsupplier);
                Partners.Add(newsupplier);
            }
            for (int i = 0; i < CountOfBuyers; i++)
            {
                var newbuyer = new TDBuyer()
                {
                    Index = i,
                    ID = id,
                    Code = $"tpirc {i + 1}",
                    Name = $"Pircējs {i + 1}"
                };
                id++;
                Buyers.Add(newbuyer);
                Partners.Add(newbuyer);
            }
        }

        public void AssignItemsToSuppliers()
        {
            for(int i = 0; i < Items.Count; i++)
            {
                int k = Rnd.Next(Suppliers.Count);
                var item = Items[i];
                var supplier = Suppliers[k];
                item.Supplier = supplier;
                supplier.Items.Add(item);
            }
        }

        public void MakeSale(TDInvoice invoice)
        {
            int itemscount = Rnd.Next(ItemsPerSaleMin, ItemsPerSaleMax + 1);
            while (invoice.Rows.Count < itemscount)
            {
                int itemindex = Rnd.Next(Items.Count);
                if (invoice.Rows.Where(x => x.Item.Index == itemindex).Any()) continue;
                var item = Items[itemindex];
                int count = Rnd.Next(ItemsCountPerSaleMin, ItemsCountPerSaleMax);
                var row = new TDInvoiceRow()
                {
                    ID = RowsIdCurrrent++,
                    Item = item,
                    Amount = count,
                    Price = item.SellPrice + item.SellPriceDelta * (decimal)Rnd.NextDouble()
                };
                row.Price = Math.Round(row.Price, 2);
                row.TPrice = Math.Round(row.Price * row.Amount, 2);
                invoice.Rows.Add(row);
            }
        }

        public void MakeAllDays()
        {
            for (int i = 0; i < CountOfDays; i++)
            {
                var day = new TDDay()
                {
                    Index = i
                };
                Days.Add(day);
            }
        }

        public void MakeDaySales(TDDay day)
        {
            int salescount = SalesPerDay;
            while (day.Sales.Count < salescount)
            {
                int buyerindex = Rnd.Next(Buyers.Count);
                if (day.Sales.Where(x => x.Partner.Index == buyerindex).Any()) continue;
                var buyer = Buyers[buyerindex];
                var invoice = new TDInvoice()
                {
                    Partner = buyer
                };
                MakeSale(invoice);
                day.Sales.Add(invoice);
            }
        }

        public void MakeSalesForAllDays()
        {
            for (int i = FirstSaleDay; i < CountOfDays; i++)
            {
                var day = Days[i];
                MakeDaySales(day);
            }
        }

        public IEnumerable<TDDay> GetDays(int ind1, int ind2)
        {
            for (int i = ind1; i <= ind2; i++)
            {
                yield return Days[i];
            }
        }

        public void MakeDelivery(TDInvoice invoice, int dayindex)
        {
            var supplier = invoice.Partner;
            int dx1 = dayindex;
            int dx2 = dayindex + DeliveryIntervalInDays - 1;
            if (dx2 > Days.Count - 1) dx2 = Days.Count - 1;
            var sold = GetDays(dx1, dx2)
                .SelectMany(x => x.Sales)
                .SelectMany(x => x.Rows)
                .Where(x => x.Item.Supplier == supplier)
                .GroupBy(x => x.Item)
                .Select(x => (x.Key, x.Sum(y => y.Amount)))
                .ToList();
            foreach (var solditem in sold)
            {
                var item = solditem.Key;
                var row = new TDInvoiceRow()
                {
                    ID = RowsIdCurrrent++,
                    Item = item,
                    Amount = solditem.Item2,
                    Price = item.BuyPrice + item.BuyPriceDelta * (decimal)Rnd.NextDouble()
                };
                row.Price = Math.Round(row.Price, 2);
                row.TPrice = Math.Round(row.Price * row.Amount, 2);
                invoice.Rows.Add(row);
            }
        }


        public void MakeDayDeliveries(TDDay day, int supplieridx1, int supplieridx2)
        {
            for (int i = supplieridx1; i <= supplieridx2; i++)
            {
                var supplier = Suppliers[i];
                var invoice = new TDInvoice()
                {
                    Partner = supplier
                };
                MakeDelivery(invoice, day.Index);
                if (invoice.Rows.Count == 0) continue;
                day.Deliveries.Add(invoice);
            }
        }

        public void MakeAllDeliveries()
        {
            int deliveriesperday = Suppliers.Count / DeliveryIntervalInDays;
            int dayind = 0;
            while (dayind < Days.Count)
            {
                int supplierind1 = 0;
                while(supplierind1 < Suppliers.Count && dayind <= Days.Count)
                {
                    var day = Days[dayind];
                    int supplierind2 = Math.Min(supplierind1 + deliveriesperday-1, Suppliers.Count);
                    MakeDayDeliveries(day, supplierind1, supplierind2);
                    supplierind1 = supplierind2 + 1;
                    dayind++;
                }
            }
        }

        public (int doccount, int rowcount) GetCounts()
        {
            int doccount =
                Days.SelectMany(x => x.Deliveries).Count() +
                Days.SelectMany(x => x.Sales).Count();
            int rowscount =
                Days.SelectMany(x => x.Deliveries).SelectMany(x => x.Rows).Count() +
                Days.SelectMany(x => x.Sales).SelectMany(x => x.Rows).Count();
            return (doccount, rowscount);
        }

        public void SetDocRowIds()
        {
            int docid = DocsId0;
            int rowid = DocsId0;
            foreach (var day in Days)
            {
                foreach (var delivery in day.Deliveries)
                {
                    delivery.ID = docid;
                    docid++;
                    foreach (var item in delivery.Rows)
                    {
                        item.ID = rowid;
                        rowid++;
                    }
                }
                foreach (var sale in day.Sales)
                {
                    sale.ID = docid;
                    docid++;
                    foreach (var item in sale.Rows)
                    {
                        item.ID = rowid;
                        rowid++;
                    }
                }
            }
        }

        public int TestAllItems()
        {
            int badsaldocount = 0;
            foreach (var item in Items)
                item.Saldo = 0;
            foreach (var day in Days)
            {
                foreach (var delivery in day.Deliveries)
                {
                    foreach (var item in delivery.Rows)
                    {
                        item.Item.Saldo += item.Amount;
                    }
                }
                foreach (var sale in day.Sales)
                {
                    foreach (var item in sale.Rows)
                    {
                        item.Item.Saldo -= item.Amount;
                        if (item.Item.Saldo < 0)
                            badsaldocount++;
                    }
                }
            }
            return badsaldocount;
        }

        public void DBMakeItems()
        {
            var table = KlonsData.St.DataSetKlonsM.M_ITEMS;
            foreach(var item in Items)
            {
                var dr = table.NewM_ITEMSRow();
                dr.ID = item.ID;
                dr.BARCODE = item.Code;
                dr.NAME = item.Name;
                dr.CAT = IdItemsCat;
                table.Rows.Add(dr);
            }
            KlonsData.St.UpdateTable(table);
        }
        
        public void DBMakePartners()
        {
            var table = KlonsData.St.DataSetKlonsM.M_STORES;
            foreach (var partner in Partners)
            {
                var dr = table.NewM_STORESRow();
                dr.ID = partner.ID;
                dr.CODE = partner.Code;
                dr.NAME = partner.Name;
                dr.XStoreType = EStoreType.Partneris;
                dr.XStorePVNType = EPVNType.Iekšzemē_apliekama_persona;
                dr.ACC21 = Acc21;
                dr.ACC23 = Acc23;
                dr.ACC53 = Acc53;
                table.Rows.Add(dr);
            }
            KlonsData.St.UpdateTable(table);
        }

        public void DBMakeDoks()
        {
            var table_docs = KlonsData.St.DataSetKlonsM.M_DOCS;
            var table_rows = KlonsData.St.DataSetKlonsM.M_ROWS;
            DateTime firstdate = new DateTime(2021, 1, 1);
            int ourstoreid = 2;
            foreach (var day in Days)
            {
                var docs = day.Deliveries.Union(day.Sales).ToList();
                foreach (var doc in docs)
                {
                    var dr_doc = table_docs.NewM_DOCSRow();
                    dr_doc.ID = doc.ID;
                    dr_doc.DT = firstdate.AddDays(day.Index);
                    dr_doc.XState = EDocState.Iegrāmatots;
                    dr_doc.XPVNType = EPVNType.Iekšzemē_apliekama_persona;
                    if (doc.Partner is TDSupplier)
                    {
                        dr_doc.XDocType = EDocType.Iepirkums;
                        dr_doc.IDSTOREIN = ourstoreid;
                        dr_doc.IDSTOREOUT = doc.Partner.ID;
                        dr_doc.ACCIN = Acc21;
                        dr_doc.ACCOUT = Acc53;
                    }
                    else
                    {
                        dr_doc.XDocType = EDocType.Realizācija;
                        dr_doc.IDSTOREOUT = ourstoreid;
                        dr_doc.IDSTOREIN = doc.Partner.ID;
                        dr_doc.ACCIN = Acc23;
                        dr_doc.ACCOUT = Acc6;
                    }
                    table_docs.Rows.Add(dr_doc);
                    foreach (var row in doc.Rows)
                    {
                        var dr_row = table_rows.NewM_ROWSRow();
                        dr_row.ID = row.ID;
                        dr_row.IDDOC = dr_doc.ID;
                        dr_row.M_DOCSRow = dr_doc;
                        dr_row.IDITEM = row.Item.ID;
                        dr_row.IDPVNRATE = IdPVNRate;
                        dr_row.UNITS = IdUnits;
                        dr_row.AMOUNT = row.Amount;
                        dr_row.PRICE0 = row.Price;
                        dr_row.PRICE = row.Price;
                        dr_row.BUYPRICE = row.Price;
                        dr_row.TPRICE = row.TPrice;
                        dr_row.TBUYPRICE = row.TPrice;
                        dr_row.ACC6 = Acc6;
                        dr_row.ACC7 = Acc7;
                        table_rows.Rows.Add(dr_row);
                    }
                    KlonsData.St.UpdateTable(table_docs);
                    KlonsData.St.UpdateTable(table_rows);
                    table_rows.Clear();
                    table_docs.Clear();
                }
            }
        }

        public void MakeAllA()
        {
            InitIds();
            MakeItems();
            MakePartners();
            AssignItemsToSuppliers();
            MakeAllDays();
            MakeSalesForAllDays();
            MakeAllDeliveries();
            SetDocRowIds();
        }
    }

}
