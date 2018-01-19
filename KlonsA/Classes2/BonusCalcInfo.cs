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
        public KlonsADataSet.SALARY_PLUSMINUSRow[] DataRows = null;
        public List<KlonsADataSet.SALARY_PLUSMINUSRow> OrderedDataRows = new List<KlonsADataSet.SALARY_PLUSMINUSRow>();

        public PayFx2[] BonusPfx = null;

        private CalcRInfo CalcR = null;

        public bool PreparingReport = false;
        public List<BonusCalcRow> ReportRows = null;
        public decimal ForAvpayCalc = 0.0M;
        public decimal PlusFromEnd = 0.0M;

        public decimal NotPaidTaxed = 0.0M;
        public decimal NotPaidNotTaxed = 0.0M;
        public decimal NotPaidNoSAI = 0.0M;
        public decimal NotPaidFromEnd = 0.0M;
        public decimal NotPaidFromEndCash = 0.0M;

        public bool TakeRoundingError = false;

        public BonusCalcInfo(CalcRInfo cri, KlonsADataSet.SALARY_PLUSMINUSRow[] rows, bool fillist = false)
        {
            CalcR = cri;
            DataRows = rows;
            MakePfx();
            PreparingReport = fillist;
            if (PreparingReport) ReportRows = new List<BonusCalcRow>();
        }

        public BonusCalcInfo(SalarySheetRowInfo shr, bool fillist = false)
        {
            DataRows = shr.GetAlgasAllPSRows();
            PreparingReport = fillist;
            if (PreparingReport) ReportRows = new List<BonusCalcRow>();
        }

        private decimal GetRoundingError(decimal amount, int divby)
        {
            if (!TakeRoundingError) return 0.0M;
            return GetRoundingErrorA(amount, divby);
        }

        private decimal GetRoundingErrorA(decimal amount, int divby)
        {
            if (divby == 1) return 0.0M;
            amount = KlonsData.RoundA(amount, 2);
            return amount - KlonsData.RoundA(amount / (decimal)divby, 2) * (decimal)divby;
        }

        private void MakePfx()
        {
            BonusPfx = new PayFx2[DataRows.Length];
            for (int i = 0; i < DataRows.Length; i++)
            {
                var p1 = new PayFx2(CalcR);
                p1.IinEx = CalcR.ExMax2.SumIINExemptsAll();
                p1.Caption = DataRows[i].DESCR;
                if (string.IsNullOrEmpty(p1.Caption)) p1.Caption = "Piemaksa";
                BonusPfx[i] = p1;
            }
        }

        public BonusCalcInfo Filter(Func<KlonsADataSet.SALARY_PLUSMINUSRow, bool> f)
        {
            var list = DataRows.WhereX(d => f(d)).ToArray();
            return new BonusCalcInfo(CalcR, list, PreparingReport);
        }

        public PayFx2 AddRow(SalaryInfo si, KlonsADataSet.SALARY_PLUSMINUSRow dr, 
            decimal dfrom, decimal addamount, int divby)
        {
            OrderedDataRows.Add(dr);
            int ind_dr = DataRows.IndexOf(dr);
            var pfx = BonusPfx[ind_dr];

            switch (dr.XBonusType)
            {
                case EBonusType.NoSAI:
                case EBonusType.AuthorsFees:
                case EBonusType.MinusBeforeIIN:
                    //if(dr.AMOUNT != 0.0M) dr.AMOUNT = 0.0M;
                    pfx.IinEx = 0.0M;
                    pfx.UsedIinEx = 0.0M;
                    return pfx;
            }

            switch (dr.XBonusType)
            {
                case EBonusType.Taxed:
                    si._PLUS_TAXED += addamount;
                    pfx.Pay += addamount;
                    break;
                case EBonusType.NoSAI:
                    si._PLUS_NOSAI += addamount;
                    pfx.PayNs += addamount;
                    break;
                case EBonusType.AuthorsFees:
                    si._PLUS_AUTHORS_FEES += addamount;
                    pfx.PayNs += addamount;
                    break;
                case EBonusType.NotTaxed:
                    si._PLUS_NOTTAXED += addamount;
                    pfx.PayNt += addamount;
                    break;
                case EBonusType.MinusBeforeIIN:
                    si._MINUS_BEFORE_IIN += addamount;
                    break;
                case EBonusType.MinusAfterIIN:
                    si._MINUS_AFTER_IIN += addamount;
                    pfx.Cash -= addamount;
                    break;
                case EBonusType.PfNotTaxed:
                    si._PLUS_PF_NOTTAXED += addamount;
                    si._PLUS_NOTTAXED += addamount;
                    pfx.PayNt += addamount;
                    break;
                case EBonusType.PfTaxed:
                    si._PLUS_PF_TAXED += addamount;
                    si._PLUS_TAXED += addamount;
                    pfx.Pay += addamount;
                    break;
                case EBonusType.LiNotTaxed:
                    si._PLUS_LI_NOTTAXED += addamount;
                    si._PLUS_NOTTAXED += addamount;
                    pfx.PayNt += addamount;
                    break;
                case EBonusType.LiTaxed:
                    si._PLUS_LI_TAXED += addamount;
                    si._PLUS_TAXED += addamount;
                    pfx.Pay += addamount;
                    break;
                case EBonusType.HiNotTaxed:
                    si._PLUS_HI_NOTTAXED += addamount;
                    si._PLUS_NOTTAXED += addamount;
                    pfx.PayNt += addamount;
                    break;
                case EBonusType.HiTaxed:
                    si._PLUS_HI_TAXED += addamount;
                    si._PLUS_TAXED += addamount;
                    pfx.Pay += addamount;
                    break;
                case EBonusType.ReverseCalc:
                    si._PLUS_TAXED += addamount;
                    pfx.Pay += addamount;
                    break;
            }

            if (dr.IS_INAVPAY == 1 && dr.XBonusType != EBonusType.MinusAfterIIN)
                ForAvpayCalc += addamount;


            switch (dr.XBonusType)
            {
                case EBonusType.PfTaxed:
                case EBonusType.LiTaxed:
                case EBonusType.HiTaxed:
                    NotPaidTaxed += addamount;
                    si._PLUS_NP_TAXED += addamount;
                    break;
                case EBonusType.PfNotTaxed:
                case EBonusType.LiNotTaxed:
                case EBonusType.HiNotTaxed:
                    NotPaidNotTaxed += addamount;
                    si._PLUS_NP_NOTTAXED += addamount;
                    break;
            }

            if (dr.IS_PAID == 0)
            {
                switch (dr.XBonusType)
                {
                    case EBonusType.Taxed:
                        NotPaidTaxed += addamount;
                        si._PLUS_NP_TAXED += addamount;
                        break;
                    case EBonusType.ReverseCalc:
                        NotPaidFromEnd += addamount;
                        NotPaidFromEndCash += dr.RATE / (decimal)divby + GetRoundingError(dr.RATE, divby);
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
                    br.Cash = dr.RATE / (decimal)divby + GetRoundingError(dr.RATE, divby);
                ReportRows.Add(br);
            }

            return pfx;
        }

        public List<PayFx2> CalcProc(SalaryInfo si, EBonusFrom efrom, decimal dfrom)
        {
            var ret = new List<PayFx2>();
            foreach (var dr in DataRows)
            {
                if (dr.XRateType != EBonusRateType.Percent ||
                    dr.XBonusType == EBonusType.ReverseCalc) continue;
                if (dr.XBonusFrom != efrom) continue;

                decimal v = KlonsData.RoundA(dfrom * dr.RATE / 100.0M, 2);
                if(dr.AMOUNT != v) dr.AMOUNT = v;
                var pfx = AddRow(si, dr, dfrom, dr.AMOUNT, 1);
                ret.Add(pfx);
            }
            return ret;
        }

        //part = 0 - skip MinusAfterIIN
        //part = 1 - only MinusAfterIIN
        public List<PayFx2> CalcNotProc(SalaryInfo si, int part, int divby = 1)
        {
            var ret = new List<PayFx2>();
            foreach (var dr in DataRows)
            {
                if (dr.XRateType != EBonusRateType.Money ||
                    dr.XBonusType == EBonusType.ReverseCalc) continue;

                if (part == 0 && dr.XBonusType == EBonusType.MinusAfterIIN) continue;
                if (part == 1 && dr.XBonusType != EBonusType.MinusAfterIIN) continue;

                decimal v = 0.0M;
                if (dr.IsIDANull())
                {
                    v = KlonsData.RoundA(dr.RATE / (decimal)divby, 2);
                    if(dr.AMOUNT != v) dr.AMOUNT = v;
                    v += GetRoundingError(dr.RATE, divby);
                }
                else
                {
                    v = dr.RATE;
                    if (dr.AMOUNT != v) dr.AMOUNT = v;
                }
                var pfx = AddRow(si, dr, dr.RATE, v, divby);
                ret.Add(pfx);
            }
            return ret;
        }


        public class CalcRet
        {
            public PayFx2 PfxT = null;
            public PayFx2[] Pfxs = null;
            public CalcRet(int ct)
            {
                Pfxs = new PayFx2[ct];
            }
        }

        private int FindAM(SalaryCalcTInfo scti, int idam)
        {
            for (int i = 0; i < scti.LinkedSCI.Length; i++)
                if (scti.LinkedSCI[i].SR.Row.IDAM == idam) return i;
            return -1;
        }

        public List<CalcRet> CalcProcT(SalaryCalcTInfo scti, EBonusFrom efrom, 
            Func<SalaryInfo, decimal> fdfrom)
        {
            var ret = new List<CalcRet>();
            int divby = scti.LinkedSCI.Length;

            foreach (var dr in DataRows)
            {
                if (dr.XRateType != EBonusRateType.Percent ||
                    dr.XBonusType == EBonusType.ReverseCalc) continue;
                if (dr.XBonusFrom != efrom) continue;

                var ret1 = new CalcRet(divby);

                if (dr.IsIDANull())
                {
                    decimal dfrom = fdfrom(scti.TotalSI);
                    decimal v = KlonsData.RoundA(dfrom * dr.RATE / 100.0M, 2);
                    decimal vs = v;
                    if (dr.AMOUNT != v) dr.AMOUNT = v;
                    var pfx = AddRow(scti.TotalSI, dr, dfrom, v, 1);
                    ret1.PfxT = pfx;

                    for (int i = 0; i < divby; i++)
                    {
                        var sci = scti.LinkedSCI[i];
                        dfrom = fdfrom(sci.SI);
                        v = KlonsData.RoundA(dfrom * dr.RATE / 100.0M, 2);
                        vs -= v;
                        if (i == divby - 1) v += vs;
                        ret1.Pfxs[i] = sci.BonusCalc.AddRow(sci.SI, dr, dfrom, v, divby);
                    }
                }
                else
                {
                    int i = FindAM(scti, dr.IDA);
                    var sci = scti.LinkedSCI[i];
                    decimal dfrom = fdfrom(sci.SI);
                    decimal v = KlonsData.RoundA(dfrom * dr.RATE / 100.0M, 2);
                    if (dr.AMOUNT != v) dr.AMOUNT = v;
                    var pfx = AddRow(scti.TotalSI, dr, dfrom, v, 1);
                    ret1.PfxT = pfx;
                    ret1.Pfxs[i] = sci.BonusCalc.AddRow(sci.SI, dr, dfrom, v, 1);
                }
                ret.Add(ret1);
            }
            return ret;
        }

        public List<CalcRet> CalcNotProcT(SalaryCalcTInfo scti, int part)
        {
            var ret = new List<CalcRet>();
            int divby = scti.LinkedSCI.Length;

            foreach (var dr in DataRows)
            {
                if (dr.XRateType != EBonusRateType.Money ||
                    dr.XBonusType == EBonusType.ReverseCalc) continue;

                if (part == 0 && dr.XBonusType == EBonusType.MinusAfterIIN) continue;
                if (part == 1 && dr.XBonusType != EBonusType.MinusAfterIIN) continue;

                var ret1 = new CalcRet(divby);

                decimal v = dr.RATE;
                if (dr.AMOUNT != v) dr.AMOUNT = v;
                var pfx = AddRow(scti.TotalSI, dr, dr.RATE, v, 1);
                ret1.PfxT = pfx;

                if (dr.IsIDANull())
                {
                    v = KlonsData.RoundA(v / (decimal)divby, 2);
                    for(int i = 0; i < divby; i++)
                    {
                        var sci = scti.LinkedSCI[i];
                        decimal v1 = v;
                        if(i == 0) v1 += GetRoundingErrorA(dr.RATE, divby);
                        ret1.Pfxs[i] = sci.BonusCalc.AddRow(sci.SI, dr, dr.RATE, v1, divby);
                    }
                }
                else
                {
                    int i = FindAM(scti, dr.IDA);
                    var sci = scti.LinkedSCI[i];
                    ret1.Pfxs[i] = sci.BonusCalc.AddRow(sci.SI, dr, dr.RATE, v, 1);
                }
                ret.Add(ret1);
            }
            return ret;
        }

        public void CalcFromEndA(int divby)
        {
            for (int i = 0; i < DataRows.Length; i++)
            {
                var dr = DataRows[i];
                if (dr.XRateType != EBonusRateType.Money ||
                    dr.XBonusType != EBonusType.ReverseCalc) continue;

                decimal v = dr.RATE;
                //if (dr.AMOUNT != v) dr.AMOUNT = v;
                if (dr.IsIDANull())
                {
                    v = v / (decimal)divby;
                    v += GetRoundingError(dr.RATE, divby);
                }
                PlusFromEnd += v;
            }
        }

        public void CalcFromEndAT(SalaryCalcTInfo scti)
        {
            int divby = scti.LinkedSCI.Length;
            CalcFromEndA(1);
            for (int i = 0; i < divby; i++)
            {
                var sci = scti.LinkedSCI[i];
                sci.BonusCalc.CalcFromEndA(divby);
            }
        }


        public List<PayFx2> GetForReverseCalc()
        {
            var ret = new List<PayFx2>();
            for (int i = 0; i < DataRows.Length; i++)
            {
                var dr = DataRows[i];
                if (dr.XRateType != EBonusRateType.Money ||
                    dr.XBonusType != EBonusType.ReverseCalc) continue;
                ret.Add(BonusPfx[i]);
            }
            return ret;
        }


        public decimal CalcFromEndC(SalaryInfo si,
            decimal totalinex, decimal totalinexa, decimal totalinexb,
            decimal curbruto, decimal brutonosai, 
            decimal brutomargin, decimal brutomargina, decimal brutomarginb,
            bool useprogressiveiin, bool hastaxdoc,
            decimal iinrate1, decimal iinrate2, decimal dnsrate, int divby, 
            out List<PayFx2> rpfx)
        {
            rpfx = new List<PayFx2>();
            decimal ret = 0.0M;
            if (PlusFromEnd <= 0.0M) return ret;

            decimal calcbruto = curbruto;

            var p1 = new PayFx(useprogressiveiin);
            p1.Ir = iinrate1 / 100.0M;
            p1.Ir2 = iinrate2 / 100.0M;
            p1.Sr = dnsrate / 100.0M;
            p1.IM = brutomargin;
            p1.IMa = brutomargina;
            p1.IMb = brutomarginb;
            p1.HasTaxDoc = hastaxdoc;
            p1.Pay = curbruto;
            p1.PayNs = brutonosai;
            p1.IinEx = totalinex;
            p1.IinExA = totalinexa;
            p1.IinExB = totalinexb;

            for (int i = 0; i < DataRows.Length; i++)
            {
                var dr = DataRows[i];
                if (dr.XRateType != EBonusRateType.Money ||
                    dr.XBonusType != EBonusType.ReverseCalc) continue;

                decimal v = dr.RATE;

                calcbruto = p1.GetPayByIncCashAB(v);
                calcbruto = KlonsData.RoundA(calcbruto, 2);
                v = calcbruto - curbruto;
                p1.Pay = calcbruto;
                curbruto = calcbruto;
                if (dr.AMOUNT != v) dr.AMOUNT = v;
                var rpfx1 = AddRow(si, dr, dr.RATE, v, 1);
                rpfx.Add(rpfx1);
                ret += v;
            }

            return ret;
        }


        public decimal CalcFromEndCT(SalaryCalcTInfo sct,
            decimal totalinex, decimal totalinexa, decimal totalinexb,
            decimal curbruto, decimal brutonosai, 
            decimal brutomargin, decimal brutomargina, decimal brutomarginb,
            bool useprogressiveiin, bool hastaxdoc,
            decimal iinrate1, decimal iinrate2, decimal dnsrate, int divby,
            out List<CalcRet> rpfx)
        {

            rpfx = new List<CalcRet>();
            decimal ret = 0.0M;
            if (PlusFromEnd <= 0.0M) return ret;

            List<PayFx2> rpfxt = null;

            decimal calcbruto = CalcFromEndC(sct.TotalSI, 
                totalinex, totalinexa, totalinexb,
                curbruto, brutonosai, 
                brutomargin, brutomargina, brutomarginb,
                useprogressiveiin, hastaxdoc,
                iinrate1, iinrate2, dnsrate, divby, out rpfxt);

            for (int i = 0; i < DataRows.Length; i++)
            {
                var dr = DataRows[i];
                if (dr.XRateType != EBonusRateType.Money ||
                    dr.XBonusType != EBonusType.ReverseCalc) continue;

                var pfx = BonusPfx[i];
                var ret1 = new CalcRet(divby);
                ret1.PfxT = pfx;
                decimal v = dr.AMOUNT;

                if (dr.IsIDANull())
                {
                    v = KlonsData.RoundA(v / (decimal)divby, 2);
                    for (int j = 0; j < divby; j++)
                    {
                        var sci = sct.LinkedSCI[j];
                        decimal v1 = v;
                        if (j == 0) v1 += GetRoundingErrorA(dr.AMOUNT, divby);
                        ret1.Pfxs[j] = sci.BonusCalc.AddRow(sci.SI, dr, dr.RATE, v1, divby);
                    }
                }
                else
                {
                    int ind = FindAM(sct, dr.IDA);
                    var sci = sct.LinkedSCI[ind];
                    ret1.Pfxs[i] = sci.BonusCalc.AddRow(sci.SI, dr, dr.RATE, v, 1);
                }

                rpfx.Add(ret1);
                ret += pfx.Pay;
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

        public void CalcCash()
        {
            if (!PreparingReport) return;
            for (int i = 0; i < DataRows.Length; i++)
            {
                var br = ReportRows[i];
                var pfx = BonusPfx[i];
                br.Cash = pfx.Cash;
            }
        }

        public void CalcCashT(SalaryCalcTInfo scti)
        {
            if (!PreparingReport) return;
            CalcCash();
            for (int i = 0; i < scti.LinkedSCI.Length; i++)
            {
                var sci = scti.LinkedSCI[i];
                sci.BonusCalc.CalcCash();
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
