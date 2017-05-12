using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsLIB.Misc;
using KlonsLIB.Data;

namespace KlonsA.Classes
{
    public class BonusCalcInfo
    {
        public static BonusCalcInfo EmptyBonusList = new BonusCalcInfo(new KlonsADataSet.SALARY_PLUSMINUSRow[0]);

        public KlonsADataSet.SALARY_PLUSMINUSRow[] DataRows = null;

        public bool PreparingReport = false;
        public List<BonusCalcRow> ReportRows = null;
        public decimal ForAvpayCalc = 0.0M;
        public decimal PlusFromEnd = 0.0M;

        public decimal NotPaidTaxed = 0.0M;
        public decimal NotPaidNotTaxed = 0.0M;
        public decimal NotPaidNoSAI = 0.0M;
        public decimal NotPaidFromEnd = 0.0M;
        public decimal NotPaidFromEndCash = 0.0M;

        public BonusCalcInfo(KlonsADataSet.SALARY_PLUSMINUSRow[] rows, bool fillist = false)
        {
            DataRows = rows;
            PreparingReport = fillist;
            if (PreparingReport) ReportRows = new List<BonusCalcRow>();
        }

        public BonusCalcInfo(SalarySheetRowInfo shr, bool fillist = false)
        {
            DataRows = shr.GetAlgasAllPSRows();
            PreparingReport = fillist;
            if (PreparingReport) ReportRows = new List<BonusCalcRow>();
        }

        public BonusCalcInfo Filter(Func<KlonsADataSet.SALARY_PLUSMINUSRow, bool> f)
        {
            var list = DataRows.WhereX(d => f(d)).ToArray();
            return new BonusCalcInfo(list, PreparingReport);
        }

        public void AddRow(SalaryInfo si, KlonsADataSet.SALARY_PLUSMINUSRow dr, decimal dfrom, int divby)
        {
            switch (dr.XBonusType)
            {
                case EBonusType.Taxed:
                    si._PLUS_TAXED += dr.AMOUNT;
                    break;
                case EBonusType.NoSAI:
                    si._PLUS_NOSAI += dr.AMOUNT;
                    break;
                case EBonusType.AuthorsFees:
                    si._PLUS_AUTHORS_FEES += dr.AMOUNT;
                    break;
                case EBonusType.NotTaxed:
                    si._PLUS_NOSAI += dr.AMOUNT;
                    break;
                case EBonusType.MinusBeforeIIN:
                    si._MINUS_BEFORE_IIN += dr.AMOUNT;
                    break;
                case EBonusType.MinusAfterIIN:
                    si._MINUS_AFTER_IIN += dr.AMOUNT;
                    break;
                case EBonusType.PfNotTaxed:
                    si._PLUS_PF_NOTTAXED += dr.AMOUNT;
                    si._PLUS_NOSAI += dr.AMOUNT;
                    break;
                case EBonusType.PfTaxed:
                    si._PLUS_PF_TAXED += dr.AMOUNT;
                    si._PLUS_TAXED += dr.AMOUNT;
                    break;
                case EBonusType.LiNotTaxed:
                    si._PLUS_LI_NOTTAXED += dr.AMOUNT;
                    si._PLUS_NOSAI += dr.AMOUNT;
                    break;
                case EBonusType.LiTaxed:
                    si._PLUS_LI_TAXED += dr.AMOUNT;
                    si._PLUS_TAXED += dr.AMOUNT;
                    break;
                case EBonusType.HiTaxed:
                    si._PLUS_HI_TAXED += dr.AMOUNT;
                    si._PLUS_TAXED += dr.AMOUNT;
                    break;
                case EBonusType.HiNotTaxed:
                    si._PLUS_HI_NOTTAXED += dr.AMOUNT;
                    si._PLUS_NOSAI += dr.AMOUNT;
                    break;
                case EBonusType.ReverseCalc:
                    si._PLUS_TAXED += dr.AMOUNT;
                    break;
            }

            if (dr.IS_INAVPAY == 1)
                ForAvpayCalc += dr.AMOUNT;


            switch (dr.XBonusType)
            {
                case EBonusType.PfTaxed:
                case EBonusType.LiTaxed:
                case EBonusType.HiTaxed:
                    NotPaidTaxed += dr.AMOUNT;
                    si._PLUS_NP_TAXED += dr.AMOUNT;
                    break;
                case EBonusType.PfNotTaxed:
                case EBonusType.LiNotTaxed:
                case EBonusType.HiNotTaxed:
                    NotPaidNotTaxed += dr.AMOUNT;
                    si._PLUS_NP_NOTTAXED += dr.AMOUNT;
                    break;
            }

            if (dr.IS_PAID == 0)
            {
                switch (dr.XBonusType)
                {
                    case EBonusType.Taxed:
                        NotPaidTaxed += dr.AMOUNT;
                        si._PLUS_NP_TAXED += dr.AMOUNT;
                        break;
                    case EBonusType.ReverseCalc:
                        NotPaidFromEnd += dr.AMOUNT;
                        NotPaidFromEndCash += dr.RATE / (decimal)divby;
                        si._PLUS_NP_TAXED += dr.AMOUNT;
                        break;
                    case EBonusType.NoSAI:
                    case EBonusType.AuthorsFees:
                        NotPaidNoSAI += dr.AMOUNT;
                        si._PLUS_NP_NOSAI += dr.AMOUNT;
                        break;
                    case EBonusType.NotTaxed:
                        NotPaidNotTaxed += dr.AMOUNT;
                        si._PLUS_NP_NOTTAXED += dr.AMOUNT;
                        break;
                }
            }

            if (PreparingReport)
            {
                var br = new BonusCalcRow();
                br.Caption = dr.DESCR;
                br.AddTo = SomeDataDefs.GetEBonusText(dr.XBonusType);
                br.CalcFrom = SomeDataDefs.GetEBonusFromString(dr.XBonusFrom);
                br.BonusType = dr.XBonusType;
                br.Rate = dr.RATE;
                if (divby > 1)
                    br.RateType = "1/" + divby;
                else
                    br.RateType = dr.XRateType == EBonusRateType.Money ? "€" : "%";
                br.CalcBase = dfrom;
                br.Pay = dr.AMOUNT;
                br.InAvPay = dr.IS_INAVPAY == 1;
                br.IsPaid = dr.IS_PAID == 1;
                if(br.BonusType == EBonusType.ReverseCalc)
                    br.Cash = dr.RATE / (decimal)divby;
                ReportRows.Add(br);
            }
        }

        public void CalcProc(SalaryInfo si, EBonusFrom efrom, decimal dfrom)
        {
            foreach (var dr in DataRows)
            {
                if (dr.XRateType != EBonusRateType.Percent) continue;
                if (dr.XBonusFrom != efrom) continue;
                decimal v = KlonsData.RoundA(dfrom * dr.RATE / 100.0M, 2);
                if(dr.AMOUNT != v)
                    dr.AMOUNT = v;
            }
            foreach (var dr in DataRows)
            {
                if (dr.XRateType != EBonusRateType.Percent) continue;
                if (dr.XBonusFrom != efrom) continue;
                AddRow(si, dr, dfrom, 1);
            }
        }

        public void CalcNotProc(SalaryInfo si, int divby = 1)
        {
            foreach (var dr in DataRows)
            {
                if (dr.XRateType != EBonusRateType.Money) continue;
                if (dr.IsIDANull())
                {
                    decimal v = KlonsData.RoundA(dr.RATE / (decimal)divby, 2);
                    if(dr.AMOUNT != v) dr.AMOUNT = v;
                }
                else
                {
                    decimal v = dr.RATE;
                    if (dr.AMOUNT != v) dr.AMOUNT = v;
                }
                AddRow(si, dr, dr.RATE, divby);
            }
        }

        public void CalcFromEndA(int divby)
        {
            foreach (var dr in DataRows)
            {
                if (dr.XRateType != EBonusRateType.Money || 
                    dr.XBonusType != EBonusType.ReverseCalc) continue;
                decimal v = dr.RATE;
                if (dr.IsIDANull()) v = v / (decimal)divby;
                if (dr.AMOUNT != v) dr.AMOUNT = v;
                PlusFromEnd += v;
            }
        }

        public decimal CalcFromEndB(SalaryInfo si, decimal usableiinex, decimal iinrate, decimal dnsrate, int divby)
        {
            decimal ret = 0.0M;
            usableiinex = Math.Min(usableiinex, PlusFromEnd);
            foreach (var dr in DataRows)
            {
                if (dr.XRateType != EBonusRateType.Money || 
                    dr.XBonusType != EBonusType.ReverseCalc) continue;
                decimal v = dr.AMOUNT;
                decimal v1 = usableiinex * v / PlusFromEnd / (1.0M - dnsrate);
                decimal v2 = (v - v1) / (1.0M - iinrate) / (1.0M - dnsrate);
                v = KlonsData.RoundA(v1 + v2, 2);
                if (dr.AMOUNT != v) dr.AMOUNT = v;
                var db = dr.IsIDANull() ? divby : 1;
                AddRow(si, dr, dr.AMOUNT, db);
                ret += v;
            }
            return ret;
        }

        public decimal CalcCashNotPaid(SalaryInfo si, decimal iinrate, decimal dnsrate)
        {
            decimal sai = NotPaidTaxed * dnsrate;
            decimal aftersai = NotPaidTaxed - sai;
            decimal beforeIIN = aftersai + NotPaidNoSAI;

            decimal totalbeforeiin =
                si._AMOUNT_BEFORE_SN +
                si._PLUS_NOSAI +
                si._PLUS_AUTHORS_FEES -
                si._DNSN_AMOUNT;

            decimal iin = 0.0M;
            if(totalbeforeiin != 0.0M)
                iin = si._IIN_AMOUNT * beforeIIN / totalbeforeiin;

            decimal notPaiTotal = NotPaidNotTaxed + NotPaidTaxed + NotPaidNoSAI + 
                NotPaidFromEndCash - sai - iin;
            notPaiTotal = KlonsData.RoundA(notPaiTotal, 2);

            return notPaiTotal;
        }

        public void CalcCash(SalaryInfo si, decimal iinrate, decimal dnsrate)
        {
            decimal sai = 0.0M;
            decimal aftersai = 0.0M;
            decimal iin = 0.0M;

            decimal totalbeforeiin =
                si._AMOUNT_BEFORE_SN +
                si._PLUS_NOSAI +
                si._PLUS_AUTHORS_FEES -
                si._DNSN_AMOUNT;

            if (!PreparingReport) return;

            foreach (var br in ReportRows)
            {
                switch (br.BonusType)
                {
                    case EBonusType.Taxed:
                    case EBonusType.PfTaxed:
                    case EBonusType.LiTaxed:
                    case EBonusType.HiTaxed:
                        sai = br.Pay * dnsrate;
                        aftersai = br.Pay - sai;
                        iin = si._IIN_AMOUNT * aftersai / totalbeforeiin;
                        br.Cash = br.Pay - sai - iin;
                        break;
                    case EBonusType.ReverseCalc:
                        //
                        break;
                    case EBonusType.NoSAI:
                    case EBonusType.AuthorsFees:
                        aftersai = br.Pay;
                        iin = si._IIN_AMOUNT * aftersai / totalbeforeiin;
                        br.Cash = br.Pay - iin;
                        break;
                    case EBonusType.NotTaxed:
                    case EBonusType.PfNotTaxed:
                    case EBonusType.LiNotTaxed:
                    case EBonusType.HiNotTaxed:
                        br.Cash = br.Pay;
                        break;
                }
            }

        }

    }

    public class BonusCalcRow
    {
        public bool IsTotal = false;
        public string Caption { get; set; } = "";
        public string AddTo { get; set; } = "";
        public EBonusType BonusType { get; set; } = EBonusType.None;
        public string CalcFrom { get; set; } = "";
        public decimal Rate { get; set; } = 0.0M;
        public string RateType { get; set; } = "";
        public decimal CalcBase { get; set; } = 0.0M;
        public decimal Pay { get; set; } = 0.0M;
        public decimal Cash { get; set; } = 0.0M;
        public decimal CashNotPaid { get; set; } = 0.0M;
        public bool InAvPay { get; set; } = true;
        public bool IsPaid { get; set; } = true;
    }
}
