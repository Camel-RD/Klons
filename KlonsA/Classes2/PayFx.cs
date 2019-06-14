using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlonsA.Classes
{
    public class PayFx
    {
        public decimal Ir { get; set; } = 0.2M;
        public decimal Ir2 { get; set; } = 0.23M;
        public decimal Sr { get; set; } = 0.11M;

        public decimal Pay { get; set; } = 0.0M;
        public decimal PayNs { get; set; } = 0.0M;
        public decimal PayNt { get; set; } = 0.0M;
        public decimal IinEx { get; set; } = 0.0M; 
        public decimal UsedIinEx { get; set; } = 0.0M;

        public decimal DNS { get; set; } = 0.0M;
        public decimal IIN { get; set; } = 0.0M;
        public decimal Cash { get; set; } = 0.0M;

        public bool HasProgressiveIIN { get; set; } = false;
        public bool HasTaxDoc { get; set; } = false;

        public decimal IM = 1667.0M;
        public decimal IMa = -1.0M; //440.0M
        public decimal IMb = -1.0M; //1000.0M
        public static readonly DateTime ProgressiveIINStartDate = new DateTime(2018, 1, 1);

        public PayFx(bool hasProgressiveIIN = true)
        {
            HasProgressiveIIN = hasProgressiveIIN;
        }

        public PayFx(CalcRInfo cri)
        {
            SetFrom(cri);
        }

        public void SetPay(decimal pay, decimal payns, decimal paynt)
        {
            Pay = pay;
            PayNs = payns;
            PayNt = paynt;
        }

        public virtual void SetFrom(PayFx from)
        {
            Pay = from.Pay;
            PayNs = from.PayNs;
            PayNt = from.PayNt;
            IinEx = from.IinEx;
            UsedIinEx = from.UsedIinEx;
            DNS = from.DNS;
            IIN = from.IIN;
            Cash = from.Cash;

            Ir = from.Ir;
            Ir2 = from.Ir2;
            Sr = from.Sr;
            IM = from.IM;
            IMa = from.IMa;
            IMb = from.IMb;
            HasTaxDoc = from.HasTaxDoc;
            HasProgressiveIIN = from.HasProgressiveIIN;
        }

        public virtual void SetFrom(CalcRInfo from)
        {
            Ir = from.RateIIN / 100.0M;
            Ir2 = from.RateIIN2 / 100.0M;
            Sr = from.RateDNSN / 100.0M;
            IM = from.IINMargin;
            IMa = from.IINMarginA;
            IMb = from.IINMarginB;
            HasTaxDoc = from.HasTaxDoc;
            HasProgressiveIIN = from.UseProgresiveIINRate;
            IinEx = from.ExDivided.SumIINExemptsAll();
        }

        public void Add(PayFx from)
        {
            if (from == null) return;
            Pay += from.Pay;
            PayNs += from.PayNs;
            PayNt += from.PayNt;
            //IinEx += from.IinEx;
            UsedIinEx += from.UsedIinEx;
            DNS += from.DNS;
            IIN += from.IIN;
            Cash += from.Cash;
        }

        public void Subtract(PayFx from)
        {
            Pay -= from.Pay;
            PayNs -= from.PayNs;
            PayNt -= from.PayNt;
            UsedIinEx -= from.UsedIinEx;
            DNS -= from.DNS;
            IIN -= from.IIN;
            Cash -= from.Cash;
        }

        public static decimal RoundA(decimal d)
        {
            return KlonsData.RoundA(d, 2);
        }

        public decimal CalcIIN()
        {
            DNS = Pay * Sr;
            if (!HasProgressiveIIN)
            {
                UsedIinEx = Math.Min(Pay + PayNs - DNS, IinEx);
                IIN = (Pay + PayNs - DNS - UsedIinEx) * Ir;
                return IIN;
            }

            if(IMa == -1.0M || IMb == -1.0M)
                throw new Exception("Nav norādīti IIN neapliekamā minimuma sliekšņi.");

            if (HasTaxDoc)
            {
                if (Pay + PayNs <= IM)
                {
                    UsedIinEx = Math.Min(Pay + PayNs - DNS, IinEx);
                    IIN = (Pay + PayNs - DNS - UsedIinEx) * Ir;
                    return IIN;
                }
                else
                {
                    UsedIinEx = IinEx;
                    decimal iin1 = (IM - Pay * Sr - IinEx) * Ir;
                    decimal iin2 = (Pay + PayNs - IM) * Ir2;
                    IIN = iin1 + iin2;
                    if (IIN < 0.0M)
                    {
                        UsedIinEx += IIN / Ir;
                        IIN = 0.0M;
                    }
                    return IIN;
                }
            }
            else
            {
                UsedIinEx = 0.0M;
                IIN = (Pay + PayNs - UsedIinEx) * Ir2 - DNS * Ir;
                return IIN;
            }
        }

        public decimal CalcIINAndRound()
        {
            Pay = RoundA(Pay);
            PayNs = RoundA(PayNs);
            PayNt = RoundA(PayNt);
            IinEx = RoundA(IinEx);
            DNS = RoundA(Pay * Sr);

            if (!HasProgressiveIIN)
            {
                UsedIinEx = Math.Min(Pay + PayNs - DNS, IinEx);
                IIN = (Pay + PayNs - DNS - UsedIinEx) * Ir;
                IIN = RoundA(IIN);
                return IIN;
            }

            if (IMa == -1.0M || IMb == -1.0M)
                throw new Exception("Nav norādīti IIN neapliekamā minimuma sliekšņi.");

            if (HasTaxDoc)
            {
                if (Pay + PayNs <= IM)
                {
                    UsedIinEx = Math.Min(Pay + PayNs - DNS, IinEx);
                    IIN = (Pay + PayNs - DNS - UsedIinEx) * Ir;
                    IIN = RoundA(IIN);
                    return IIN;
                }
                else
                {
                    UsedIinEx = IinEx;
                    decimal iin1 = (IM - DNS - IinEx) * Ir;
                    decimal iin2 = (Pay + PayNs - IM) * Ir2;
                    IIN = RoundA(iin1 + iin2);
                    if (IIN < 0.0M)
                    {
                        UsedIinEx += RoundA(IIN / Ir);
                        IIN = 0.0M;
                    }
                    return IIN;
                }
            }
            else
            {
                UsedIinEx = 0.0M;
                IIN = RoundA((Pay + PayNs - UsedIinEx) * Ir2 - DNS * Ir);
                return IIN;
            }
        }


        public decimal CalcAll()
        {
            DNS = Pay * Sr;
            decimal iin = CalcIIN();
            Cash = Pay + PayNs + PayNt - DNS - iin;
            return Cash;
        }

        public decimal CalcAllAndRound()
        {
            CalcIINAndRound();
            Cash = Pay + PayNs + PayNt - DNS - IIN;
            return Cash;
        }


        public void AddPay(PayFx pfrom)
        {
            Pay += pfrom.Pay;
            PayNs += pfrom.PayNs;
            PayNt += pfrom.PayNt;
        }

        public void AddPayRound(PayFx pfrom)
        {
            pfrom.Pay = RoundA(pfrom.Pay);
            pfrom.PayNs = RoundA(pfrom.PayNs);
            pfrom.PayNt = RoundA(pfrom.PayNt);
            Pay += pfrom.Pay;
            PayNs += pfrom.PayNs;
            PayNt += pfrom.PayNt;
        }

        public decimal GetPayByIncCash(decimal dcash)
        {
            if (!HasProgressiveIIN) return GetPayByIncCashA(dcash);
            if (HasTaxDoc) return GetPayByIncCashB(dcash);
            return GetPayByIncCashC(dcash);
        }

        public decimal GetPayByIncCashA(decimal dcash)
        {
            if (dcash <= 0.0M) return 0.0M;

            decimal calcpay = Pay;
            decimal dcashleft = dcash;

            decimal px1 = (IinEx - PayNs) / (1.0M - Sr);

            decimal dpay1 = px1 - calcpay;
            if (dpay1 > 0.0M)
            {
                decimal dcash1 = dpay1 * (1 - Sr);
                dcash1 = Math.Min(dcash1, dcashleft);
                dpay1 = dcash1 / (1 - Sr);
                calcpay += dpay1;
                dcashleft -= dcash1;
            }

            decimal dpay2 = 0.0M;
            if (dcashleft > 0.0M)
            {
                decimal dcash2 = dcashleft;
                dpay2 = dcash2 / (1 - Sr) / (1 - Ir);
                calcpay += dpay2;
                dcashleft -= dcash2;
            }

            return calcpay;
        }

        public decimal GetPayByIncCashB(decimal dcash)
        {
            if (dcash <= 0.0M) return 0.0M;

            decimal calcpay = Pay;
            decimal payleft1 = Math.Max(IM - Pay - PayNs, 0.0M);
            decimal dcashleft = dcash;

            decimal px1 = (IinEx - PayNs) / (1.0M - Sr);
            decimal px2 = IM - PayNs;
            decimal px3 = (IinEx * Ir - PayNs * Ir2 + IM * (Ir2 - Ir)) / (Ir2 - Sr * Ir);
            px1 = Math.Min(px1, px2);
            px3 = Math.Max(px2, px3);

            decimal dpay1 = px1 - calcpay;
            if (dpay1 > 0.0M)
            {
                decimal dcash1 = dpay1 * (1 - Sr);
                dcash1 = Math.Min(dcash1, dcashleft);
                dpay1 = dcash1 / (1 - Sr);
                calcpay += dpay1;
                dcashleft -= dcash1;
            }

            decimal dpay2 = px2 - calcpay;
            if (dpay2 > 0.0M && dcashleft > 0.0M)
            {
                decimal dcash2 = dpay2 * (1 - Sr) * (1 - Ir);
                dcash2 = Math.Min(dcash2, dcashleft);
                dpay2 = dcash2 / (1 - Sr) / (1 - Ir);
                calcpay += dpay2;
                dcashleft -= dcash2;
            }

            decimal dpay3 = px3 - calcpay;
            if (dpay3 > 0.0M && dcashleft > 0.0M)
            {
                decimal dcash3 = dpay3 * (1 - Sr);
                dcash3 = Math.Min(dcash3, dcashleft);
                dpay3 = dcash3 / (1 - Sr);
                calcpay += dpay3;
                dcashleft -= dcash3;
            }

            decimal dpay4 = 0.0M;
            if (dcashleft > 0.0M)
            {
                decimal dcash4 = dcashleft;
                dpay4 = dcash4 / (1 - Sr - Ir2 + Ir * Sr);
                calcpay += dpay4;
                dcashleft -= dcash4;
            }

            return calcpay;
        }

        public decimal GetPayByIncCashC(decimal dcash)
        {
            if (dcash <= 0.0M) return 0.0M;

            decimal calcpay = Pay;
            decimal dcashleft = dcash;

            decimal dpay1 = 0.0M;
            if (dcashleft > 0.0M)
            {
                decimal dcash1 = dcashleft;
                dpay1 = dcash1 / (1 - Sr - Ir2 + Sr * Ir);
                calcpay += dpay1;
                dcashleft -= dcash1;
            }

            return calcpay;
        }

        public decimal IncPayByIncCash(decimal dcash, decimal apay, decimal apayns, decimal apaynt)
        {
            if (!HasProgressiveIIN) return IncPayByIncCashA(dcash, apay, apayns, apaynt);
            if(HasTaxDoc) return IncPayByIncCashB(dcash, apay, apayns, apaynt);
            return IncPayByIncCashC(dcash, apay, apayns, apaynt);
        }


        public decimal IncPayByIncCashA(decimal dcash, decimal apay, decimal apayns, decimal apaynt)
        {
            if (dcash <= 0.0M) return 0.0M;

            decimal calcpay = Pay + PayNs + PayNt;
            decimal dcashleft = dcash;

            decimal xx1 = (IinEx - Pay * (1 - Sr) - PayNs) / (apay * (1 - Sr) + apayns);
            decimal px1 = Pay + PayNs + PayNt;
            decimal px2 = px1;
            px1 += (apay + apayns + apaynt) * xx1;
            px2 += apay + apayns + apaynt;

            px1 = Math.Min(px1, px2);

            decimal xs = 0.0M;
            decimal x1 = 0M, x2 = 0M;
            decimal dcash1 = 0M, dcash2 = 0M;

            decimal dpay1 = px1 - calcpay;
            if (dpay1 > 0.0M)
            {
                dcash1 = (apay * (1 - Sr) + apayns + apaynt) * xx1;
                dcash1 = Math.Min(dcash1, dcashleft);
                x1 = dcash1 / (apay * (1 - Sr) + apayns + apaynt);
                x1 = Math.Min(1.0M, x1);
                xs = x1;
                dpay1 = (apay + apayns + apaynt) * x1;
                Pay += apay * x1;
                PayNs += apayns * x1;
                PayNt += apaynt * x1;
                calcpay += dpay1;
                dcashleft -= dcash1;
            }

            decimal dpay2 = px2 - calcpay;
            if (dpay2 > 0.0M && dcashleft > 0.0M)
            {
                dcash2 = dcashleft;
                x2 = dcash2 / (apay * (1 - Sr) * (1 - Ir) + apayns * (1 - Ir) + apaynt);
                x2 = Math.Min(1.0M - xs, x2);
                xs += x2;
                dpay2 = (apay + apayns + apaynt) * x2;
                Pay += apay * x2;
                PayNs += apayns * x2;
                PayNt += apaynt * x2;
                calcpay += dpay2;
                dcashleft -= dcash2;
            }

            return dcash - dcashleft;

        }


        public decimal IncPayByIncCashB(decimal dcash, decimal apay, decimal apayns, decimal apaynt)
        {
            if (dcash <= 0.0M) return 0.0M;

            decimal calcpay = Pay + PayNs + PayNt;
            decimal dcashleft = dcash;

            decimal xx1 = (IinEx - Pay * (1 - Sr) - PayNs) / (apay * (1 - Sr) + apayns);
            decimal xx2 = (IM - Pay - PayNs) / (apay + apayns);
            decimal xx3 = -(Pay * (Ir2 - Sr * Ir) + PayNs * Ir2 - IM * (Ir2 - Ir) - IinEx * Ir);
            xx3 /= (apay * (Ir2 - Sr * Ir) + apayns * Ir2);

            xx1 = Math.Min(xx1, xx2);
            xx3 = Math.Max(xx3, xx2);

            decimal px1 = Pay + PayNs + PayNt;
            decimal px2 = IM + PayNt;
            decimal px3 = px1;
            px1 += (apay + apayns + apaynt) * xx1;
            px3 += (apay + apayns + apaynt) * xx3;

            px1 = Math.Min(px1, px2);
            px3 = Math.Max(px2, px3);

            decimal xs = 0.0M;
            decimal x1 = 0M, x2 = 0M, x3 = 0M, x4 = 0M;
            decimal dcash1 = 0M, dcash2 = 0M, dcash3 = 0M, dcash4 = 0M;

            decimal dpay1 = px1 - calcpay;
            if (dpay1 > 0.0M)
            {
                dcash1 = (apay * (1 - Sr) + apayns + apaynt) * xx1;
                dcash1 = Math.Min(dcash1, dcashleft);
                x1 = dcash1 / (apay * (1 - Sr) + apayns + apaynt);
                x1 = Math.Min(1.0M, x1);
                xs = x1;
                dpay1 = (apay + apayns + apaynt) * x1;
                Pay += apay * x1;
                PayNs += apayns * x1;
                PayNt += apaynt * x1;
                calcpay += dpay1;
                dcashleft -= dcash1;
            }

            decimal dpay2 = px2 - calcpay;
            if (dpay2 > 0.0M && dcashleft > 0.0M)
            {
                dcash2 = (apay * (1 - Sr) * (1 - Ir) + apayns * (1 - Ir) + apaynt) * (xx2 - xx1);
                dcash2 = Math.Min(dcash2, dcashleft);
                x2 = dcash2 / (apay * (1 - Sr) * (1 - Ir) + apayns * (1 - Ir) + apaynt);
                x2 = Math.Min(1.0M - xs, x2);
                xs += x2;
                dpay2 = (apay + apayns + apaynt) * x2;
                Pay += apay * x2;
                PayNs += apayns * x2;
                PayNt += apaynt * x2;
                calcpay += dpay2;
                dcashleft -= dcash2;
            }

            decimal dpay3 = px3 - calcpay;
            if (dpay3 > 0.0M && dcashleft > 0.0M)
            {
                dcash3 = (apay * (1 - Sr) + apayns + apaynt) * (xx3-xs);
                dcash3 = Math.Min(dcash3, dcashleft);
                x3 = dcash3 / (apay * (1 - Sr) + apayns + apaynt);
                x3 = Math.Min(1.0M - xs, x3);
                xs += x3;
                dpay3 = (apay + apayns + apaynt) * x3;
                Pay += apay * x3;
                PayNs += apayns * x3;
                PayNt += apaynt * x3;
                calcpay += dpay3;
                dcashleft -= dcash3;
            }

            decimal dpay4 = 0.0M;
            if (dcashleft > 0.0M)
            {
                dcash4 = dcashleft;
                x4 = dcash4 / (apay * (1 - Sr - Ir2 + Ir * Sr) + apayns * (1 - Ir2) + apaynt);
                x4 = Math.Min(1.0M - xs, x4);
                xs += x4;
                dpay4 = (apay + apayns + apaynt) * x4;
                Pay += apay * x4;
                PayNs += apayns * x4;
                PayNt += apaynt * x4;
                calcpay += dpay4;
                dcashleft -= dcash4;
            }

            return dcash - dcashleft;

        }

        public decimal IncPayByIncCashC(decimal dcash, decimal apay, decimal apayns, decimal apaynt)
        {
            if (dcash <= 0.0M) return 0.0M;

            decimal calcpay = Pay + PayNs + PayNt;
            decimal dcashleft = dcash;

            decimal px1 = Pay + PayNs + PayNt;
            px1 += apay + apayns + apaynt;

            decimal x1 = 0M;
            decimal dcash1 = 0M;

            decimal dpay1 = px1 - calcpay;
            if (dpay1 > 0.0M && dcashleft > 0.0M)
            {
                dcash1 = dcashleft;
                x1 = dcash1 / (apay * (1 - Sr - Ir2 + Sr * Ir) + apayns * (1 - Ir2) + apaynt);
                x1 = Math.Min(1.0M, x1);
                dpay1 = (apay + apayns + apaynt) * x1;
                Pay += apay * x1;
                PayNs += apayns * x1;
                PayNt += apaynt * x1;
                calcpay += dpay1;
                dcashleft -= dcash1;
            }

            return dcash - dcashleft;
        }

        public static decimal MakeExactSum(decimal sum, IEnumerable<PayFx> list,
            Func<PayFx, decimal> fgetval, Action<PayFx, decimal> fsetval)
        {
            decimal cursum = 0.0M;
            foreach (var pfx in list)
            {
                if (pfx == null) continue;
                cursum += fgetval(pfx);
            }
            if (cursum == sum) return cursum;
            decimal addsumd = cursum < sum ? 0.01M : -0.01M;
            if (cursum == 0.0M)
            {
                while (true)
                {
                    foreach (var pfx in list)
                    {
                        if (pfx == null) continue;
                        decimal curval = fgetval(pfx);
                        fsetval(pfx, curval + addsumd);
                        cursum += addsumd;
                        if (cursum == sum) return cursum;
                    }
                }
            }
            while (true)
            {
                foreach (var pfx in list)
                {
                    if (pfx == null) continue;
                    decimal curval = fgetval(pfx);
                    if (curval == 0.0M) continue;
                    fsetval(pfx, curval + addsumd);
                    cursum += addsumd;
                    if (cursum == sum) return cursum;
                }
            }
        }

        public static void SplitAndRound(PayFx rowt, PayFx[] rows)
        {
            var erows = rows.Where(d => d != null);

            decimal dnsbase = erows.Sum(pr => pr.Pay);
            if(dnsbase == 0.0M)
            {
                int ct = erows.Count();
                foreach (var pr in erows)
                    pr.DNS = RoundA(rowt.DNS / ct);
            }
            else
            {
                foreach (var pr in erows)
                {
                    pr.DNS = RoundA(rowt.DNS * pr.Pay / dnsbase);
                }
            }

            MakeExactSum(rowt.DNS, rows, d => d.DNS, (d, dval) => d.DNS = dval);

            decimal fulliinbase = erows
                .Sum(pr => pr.Pay + pr.PayNs - pr.DNS);


            if (fulliinbase == 0.0M)
            {
                int ct = erows.Count();
                foreach (var pr in erows)
                {
                    pr.UsedIinEx = RoundA(rowt.UsedIinEx / ct);
                    pr.IIN = RoundA(rowt.IIN / ct);
                    pr.Cash = RoundA(rowt.Cash / ct);
                }
            }
            else
            {
                foreach (var pr in erows)
                {
                    decimal iinbase = pr.Pay + pr.PayNs - pr.DNS;
                    pr.UsedIinEx = RoundA(rowt.UsedIinEx * iinbase / fulliinbase);
                    pr.IIN = RoundA(rowt.IIN * iinbase / fulliinbase);
                    pr.Cash = iinbase + pr.PayNt - pr.IIN;
                }
            }

            MakeExactSum(rowt.Cash, rows, d => d.Cash, (d, dval) => d.Cash = dval);
            MakeExactSum(rowt.UsedIinEx, rows, d => d.UsedIinEx, (d, dval) => d.UsedIinEx = dval);
            foreach (var pr in erows)
            {
                pr.IIN = pr.Pay + pr.PayNs + pr.PayNt - pr.DNS - pr.Cash;
            }

        }

        public static decimal GetIINMargin(DateTime dt)
        {
            if (dt < ProgressiveIINStartDate) return 0.0M;
            else return 1667.0M;
        }

        public static decimal GetIINMarginA(DateTime dt)
        {
            if (dt < ProgressiveIINStartDate) return 0.0M;
            else return 440.0M;
        }

        public static decimal GetIINMarginB(DateTime dt)
        {
            if (dt.Year <= 2017) return 0.0M;
            if (dt.Year == 2018) return 1000.0M;
            if (dt.Year == 2019) return 1100.0M;
            if (dt.Year == 2020) return 1200.0M;
            else return 1200.0M;
        }

    }
}
