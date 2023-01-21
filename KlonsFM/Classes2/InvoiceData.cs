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
using System.Globalization;

namespace KlonsFM.Classes
{
    public class InvoiceData
    {
        public InvoiceMainData MainData = new InvoiceMainData();
        public List<InvoiceMainData> MainData2 = new List<InvoiceMainData>();
        public List<InvoiceRowData> RowData = new List<InvoiceRowData>();
        public List<InvoiceTotalsRowData> TotalsData = new List<InvoiceTotalsRowData>();

        public ErrorList ReadFrom(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = new ErrorList();
            MainData.ReadFrom(dr_doc);
            MainData2.Clear();
            MainData2.Add(MainData);
            var drs_rows = dr_doc.GetM_ROWSRows();
            int k = 0;
            foreach(var dr_row in drs_rows)
            {
                k++;
                var rowdata = new InvoiceRowData();
                rowdata.Snr = k;
                rowdata.ReadFrom(dr_row);
                RowData.Add(rowdata);
            }

            var docacc = PVNCalc.GetPVNData(dr_doc);
            if (docacc.Err.HasErrors)
            {
                ret += docacc.Err;
                return ret;
            }
            foreach(var tdr in docacc.TotalPVNData)
            {
                var totalsrowdata = new InvoiceTotalsRowData()
                {
                    Caption = tdr.Text,
                    Amount = tdr.Amount,
                    Tp = tdr.Tp
                };
                TotalsData.Add(totalsrowdata);
            }
            MainData.DocTotal = docacc.PVNBase + docacc.PVN;
            MainData.SummaVardiem = LatText.CikEiro(MainData.DocTotal);

            var nfi = CultureInfo.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalSeparator = ",";
            FormatNumStrings(4, nfi);

            return ret;
        }

        public void FormatNumStrings(int maxdec, NumberFormatInfo nfi)
        {
            int getdec(decimal d)
            {
                d = Math.Abs(d);
                d -= Math.Truncate(d);
                int k = (int)(d * (decimal)Math.Pow(10, maxdec));
                for (int i = maxdec, t = 10; i >= 3; i--, t *= 10)
                    if (k % t != 0) return i;
                return 2;
            }
            foreach (var row in RowData)
            {
                row.Price0 = Math.Round(row.Price0, maxdec);
                row.Price = Math.Round(row.Price, maxdec);
            }
            int dec1 = RowData.Max(x => getdec(x.Price0));
            int dec2 = RowData.Max(x => getdec(x.Price));
            foreach (var row in RowData)
            {
                nfi.NumberDecimalDigits = dec1;
                row.SPrice0 = row.Price0.ToString("N", nfi);
                nfi.NumberDecimalDigits = dec2;
                row.SPrice = row.Price.ToString("N", nfi);
                nfi.NumberDecimalDigits = 2;
                row.STPrice = row.TPrice.ToString("N", nfi);
            }
            foreach(var td in TotalsData)
            {
                td.FormatAmountString(nfi);
            }
        }

    }

    public class InvoiceRowData
    {
        public int Snr { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Amount { get; set; }
        public decimal Price0 { get; set; }
        public string SPrice0 { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public string SPrice { get; set; }
        public decimal TPrice { get; set; }
        public string STPrice { get; set; }
        public string PVNTag { get; set; }

        public void ReadFrom(KlonsMDataSet.M_ROWSRow dr_row)
        {
            Code = dr_row.M_ITEMSRow.BARCODE;
            Name = dr_row.M_ITEMSRow.NAME;
            Unit = dr_row.M_UNITSRow.CODE;
            PVNTag = dr_row.M_PVNRATESRow.CODE;
            Amount = dr_row.AMOUNT;
            Price0 = dr_row.PRICE0;
            Discount = (decimal)dr_row.DISCOUNT;
            Price = dr_row.PRICE;
            TPrice = dr_row.TPRICE;
            SPrice = Price.ToString();
        }
    }

    public class InvoiceTotalsRowData
    {
        public string Caption { get; set; }
        public decimal Amount { get; set; }
        public string SAmount { get; set; }
        public int Tp { get; set; }

        public void FormatAmountString(NumberFormatInfo nfi)
        {
            nfi.NumberDecimalDigits = 2;
            SAmount = Amount.ToString("N", nfi);
        }
    }

    public class InvoiceMainData
    {
        public string DocDate { get; set; }
        public string DocSr { get; set; }
        public string DocNr { get; set; }
        public string DocNrX { get; set; }
        public string DocTitle { get; set; } = "PREČU PAVADZĪME-RĒĶINS";

        public string AName { get; set; }
        public string ARegNr { get; set; }
        public string APVNRegNr { get; set; }
        public string AAddress { get; set; }
        public string AAddress2 { get; set; }
        public string ABankName { get; set; }
        public string ABankCode { get; set; }
        public string ABankAccount { get; set; }

        public string BName { get; set; }
        public string BRegNr { get; set; }
        public string BPVNRegNr { get; set; }
        public string BAddress { get; set; }
        public string BAddress2 { get; set; }
        public string BBankName { get; set; }
        public string BBankCode { get; set; }
        public string BBankAccount { get; set; }

        public string CName { get; set; }
        public string CRegNr { get; set; }
        public string CDriverName { get; set; }
        public string CTLVNR { get; set; }

        public string TransactionDescr { get; set; }
        public string PaymentType { get; set; }
        public string PaymentDue { get; set; }

        public decimal DocTotal { get; set; }
        public string SummaVardiem { get; set; }
        public string Signer { get; set; }
        public string SigningDate { get; set; }

        public bool ShowDiscountColumn { get; set; }
        public bool ShowPVNIdColumn { get; set; }
        public bool ShowCarrier { get; set; }

        private DocAccData DocAccData = null;

        public enum ESetFrom { StoreIn, StoreOut }
        public void SetAFrom(KlonsMDataSet.M_DOCSRow dr_doc, ESetFrom datasource)
        {
            if (datasource == ESetFrom.StoreOut)
            {
                var dr_store = dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREOUT1;
                AName = dr_store.NAME;
                ARegNr = dr_store.REGNR;
                APVNRegNr = dr_store.PVNREGNR;
                AAddress = dr_store.ADDR;
                var dr_bank = dr_store.GetM_BANKACCOUNTSRows().FirstOrDefault();
                KlonsMDataSet.M_BANKSRow dr_bank2 = null;
                if (dr_bank != null)
                {
                    dr_bank2 = KlonsData.St.DataSetKlonsM.M_BANKS.FindByID(dr_bank.IDBANK);
                    ABankName = dr_bank2?.NAME;
                    ABankCode = dr_bank2?.CODE;
                    ABankAccount = dr_bank?.ACCOUNT;
                }
                if (!dr_doc.IsIDADDRESSOUTNull())
                {
                    var dr_addr = KlonsData.St.DataSetKlonsM.M_ADDRESSSES.FindByID(dr_doc.IDADDRESSOUT);
                    AAddress2 = dr_addr?.ADDRESS;
                }
            }
            else
            {
                var dr_store = dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREIN1;
                BName = dr_store.NAME;
                BRegNr = dr_store.REGNR;
                BPVNRegNr = dr_store.PVNREGNR;
                BAddress = dr_store.ADDR;
                var dr_bank = dr_store.GetM_BANKACCOUNTSRows().FirstOrDefault();
                if (dr_bank != null)
                {
                    var dr_bank2 = KlonsData.St.DataSetKlonsM.M_BANKS.FindByID(dr_bank.IDBANK);
                    BBankName = dr_bank2?.NAME;
                    BBankCode = dr_bank2?.CODE;
                    BBankAccount = dr_bank?.ACCOUNT;
                }
                if (!dr_doc.IsIDADDRESSINNull())
                {
                    var dr_addr = KlonsData.St.DataSetKlonsM.M_ADDRESSSES.FindByID(dr_doc.IDADDRESSIN);
                    BAddress2 = dr_addr?.ADDRESS;
                }
            }
        }

        public void SetFromCompData(KlonsMDataSet.M_DOCSRow dr_doc, ESetFrom datasource)
        {
            if (datasource == ESetFrom.StoreOut)
            {
                AName = KlonsData.St.Params.CompName;
                ARegNr = KlonsData.St.Params.CompRegNr;
                APVNRegNr = KlonsData.St.Params.CompRegNrPVN;
                AAddress = KlonsData.St.Params.CompAddr;
                ABankName = KlonsData.St.Params.BankName;
                ABankCode = KlonsData.St.Params.BankId;
                ABankAccount = KlonsData.St.Params.BankAcc;
                if (!dr_doc.IsIDADDRESSOUTNull())
                {
                    var dr_addr = KlonsData.St.DataSetKlonsM.M_ADDRESSSES.FindByID(dr_doc.IDADDRESSOUT);
                    AAddress2 = dr_addr?.ADDRESS;
                }
            }
            else
            {
                BName = KlonsData.St.Params.CompName;
                BRegNr = KlonsData.St.Params.CompRegNr;
                BPVNRegNr = KlonsData.St.Params.CompRegNrPVN;
                BAddress = KlonsData.St.Params.CompAddr;
                BBankName = KlonsData.St.Params.BankName;
                BBankCode = KlonsData.St.Params.BankId;
                BBankAccount = KlonsData.St.Params.BankAcc;
                if (!dr_doc.IsIDADDRESSINNull())
                {
                    var dr_addr = KlonsData.St.DataSetKlonsM.M_ADDRESSSES.FindByID(dr_doc.IDADDRESSIN);
                    BAddress2 = dr_addr?.ADDRESS;
                }
            }
        }

        public void SetCFrom(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            DocDate = Utils.DateToLongString(dr_doc.DT);
            DocSr = dr_doc.SR;
            DocNr = dr_doc.NR;
            DocNrX = (DocSr.Nz() + " " + DocNr.Nz()).Trim();

            TransactionDescr = dr_doc.M_TRANSACTIONTYPERow.NAME;
            if (!dr_doc.IsIDPAYMENTTYPENull())
                PaymentType = dr_doc.M_PAYMENTTYPERow.NAME;
            if (!dr_doc.IsDUEDATENull())
                PaymentDue = Utils.DateToString(dr_doc.DUEDATE);

            if (!dr_doc.IsIDCARRIERNull())
            {
                var dr_store = dr_doc.M_STORESRowByFK_M_DOCS_IDCARRIER;
                CName = dr_store.NAME;
                CRegNr = dr_store.REGNR;
            }
            if (!dr_doc.IsIDDRIVERNull())
            {
                var dr_driver = KlonsData.St.DataSetKlonsM.M_CONTACTS.FindByID(dr_doc.IDDRIVER);
                if(dr_driver != null)
                {
                    CDriverName = dr_driver.NAME;
                }
            }
            if (!dr_doc.IsIDVEHICLENull())
            {
                var dr_vehicle = KlonsData.St.DataSetKlonsM.M_VEHICLES.FindByID(dr_doc.IDVEHICLE);
                if (dr_vehicle != null)
                {
                    CTLVNR = dr_vehicle.REGNR;
                }
            }
        }

        public void ReadFrom(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            bool isinnerdoc = !SomeDataDefs.IsStorePartner(dr_doc.XStoreOutType) &&
                !SomeDataDefs.IsStorePartner(dr_doc.XStoreInType);
            if (isinnerdoc)
            {
                SetFromCompData(dr_doc, ESetFrom.StoreOut);
                SetFromCompData(dr_doc, ESetFrom.StoreIn);
            }
            else
            {
                if (SomeDataDefs.IsStorePartner(dr_doc.XStoreOutType))
                {
                    SetAFrom(dr_doc, ESetFrom.StoreOut);
                    SetFromCompData(dr_doc, ESetFrom.StoreIn);
                }
                else
                {
                    SetFromCompData(dr_doc, ESetFrom.StoreOut);
                    SetAFrom(dr_doc, ESetFrom.StoreIn);
                }

            }
            SetCFrom(dr_doc);
        }

    }
}
