using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlonsA.Classes
{
    public class PayFx2 : PayFx
    {
        public string Position { get; set; } = null;
        public string Caption { get; set; } = null;

        public PayFx2(bool hasProgressiveIIN = true) : base(hasProgressiveIIN)
        {
        }

        public PayFx2(CalcRInfo cri):base(cri)
        {
        }

        public virtual void SetFrom(PayFx2 from)
        {
            base.SetFrom(from);
            Caption = from.Caption;
            Position = from.Position;
        }

        public virtual void SetFrom(PayFxA from)
        {
            base.SetFrom(from);
            Position = from.Position;
        }

    }

    public class PayFxA : PayFx
    {
        public string Position { get; set; } = null;
        public List<PayFx2> Rows = new List<PayFx2>();

        public PayFx2 PFx_sickpay = null;
        public PayFx2 PFx_vacation = null;
        public PayFx2 PFx_vacation_prev = null;

        public List<PayFx2> TempRows = new List<PayFx2>();
        public List<PayFx2> TempRows2 = new List<PayFx2>();

        public PayFxA(bool hasProgressiveIIN = true) : base(hasProgressiveIIN)
        {
        }

        public PayFxA(CalcRInfo cri):base(cri)
        {
        }


        public void DoPayFxA_Salary(decimal val)
        {
            if (val == 0.0M) return;
            var px_salary = new PayFx2();
            px_salary.SetFrom(this);
            px_salary.Caption = "Darba samaksa";
            px_salary.Pay = val;
            AddIncrementallyAndRound(px_salary);
        }

        public void DoPayFxA_AvPay(decimal val)
        {
            if (val == 0.0M) return;
            var px_avpay = new PayFx2();
            px_avpay.SetFrom(this);
            px_avpay.Caption = "Vidējās izpeļņas dienas";
            px_avpay.Pay = val;
            AddIncrementallyAndRound(px_avpay);
        }

        public void DoPayFxA_SickPay(decimal val)
        {
            if (val == 0.0M) return;
            PFx_sickpay = new PayFx2();
            PFx_sickpay.SetFrom(this);
            PFx_sickpay.Caption = "Slimības nauda";
            PFx_sickpay.Pay = val;
            AddIncrementallyAndRound(PFx_sickpay);
        }

        public void DoPayFxA_Vacation(decimal val, decimal val_prev)
        {
            if (val_prev > 0.0M)
            {
                PFx_vacation_prev = new PayFx2();
                PFx_vacation_prev.SetFrom(this);
                PFx_vacation_prev.Caption = "Iepriekš izmaksātā atv.n.";
                PFx_vacation_prev.Pay += val_prev;
                PFx_vacation_prev.CalcAllabAndRound();
                PFx_vacation_prev.Subtract(this);
            }
            if (val > 0.0M)
            {
                PFx_vacation = new PayFx2();
                PFx_vacation.SetFrom(this);
                PFx_vacation.Caption = "Atvaļinājuma nauda";
                PFx_vacation.Pay = val;
                AddIncrementallyAndRound(PFx_vacation);
            }
        }

        public void DoPayFxA_Bonus(IEnumerable<PayFx2> pfxs)
        {
            foreach (var pfx in pfxs)
            {
                pfx.IinEx = this.IinEx;
                AddIncrementallyAndRound(pfx);
            }
        }

        public void DoPayFxA_BonusSimpleAdd(IEnumerable<PayFx2> pfxs)
        {
            foreach (var pfx in pfxs)
            {
                Add(pfx);
            }
            Rows.AddRange(pfxs);
        }

        public void AddEqally(PayFx2[] rows)
        {
            var p1 = new PayFx();
            p1.SetFrom(this);
            decimal fulliinbase = 0.0M;
            foreach (var pr in rows)
            {
                AddPay(pr);
                pr.DNS = pr.Pay * pr.Sr;
                fulliinbase += pr.Pay + pr.PayNs - pr.DNS;
            }
            CalcAllab();
            var p2 = new PayFx();
            p2.SetFrom(this);
            p2.Subtract(p1);
            foreach (var pr in rows)
            {
                decimal iinbase = pr.Pay + pr.PayNs - pr.DNS;
                pr.UsedIinEx = p2.UsedIinEx * iinbase / fulliinbase;
                pr.IIN = p2.IIN * iinbase / fulliinbase;
                pr.Cash = iinbase + pr.PayNt - pr.IIN;
            }
            Rows.AddRange(rows);
        }

        public void AddEqallyAndRound(PayFx2[] rows)
        {
            var p1 = new PayFx();
            p1.SetFrom(this);
            foreach (var pr in rows)
            {
                AddPayRound(pr);
                pr.DNS = RoundA(pr.Pay * pr.Sr);
            }
            CalcAllabAndRound();
            var p2 = new PayFx();
            p2.SetFrom(this);
            p2.Subtract(p1);

            MakeExactSum(p2.DNS, rows, d => d.DNS, (d, dval) => d.DNS = dval);
            decimal fulliinbase = rows.Sum(pr => pr.Pay + pr.PayNs - pr.DNS);

            foreach (var pr in rows)
            {
                decimal iinbase = pr.Pay + pr.PayNs - pr.DNS;
                pr.UsedIinEx = RoundA(p2.UsedIinEx * iinbase / fulliinbase);
                pr.IIN = RoundA(p2.IIN * iinbase / fulliinbase);
                pr.Cash = iinbase + pr.PayNt - pr.IIN;
            }
            MakeExactSum(p2.Cash, rows, d => d.Cash, (d, dval) => d.Cash = dval);
            MakeExactSum(p2.UsedIinEx, rows, d => d.UsedIinEx, (d, dval) => d.UsedIinEx = dval);
            foreach (var pr in rows)
            {
                pr.IIN  = pr.Pay + pr.PayNs + pr.PayNt - pr.DNS - pr.Cash;
            }
            Rows.AddRange(rows);
        }


        public static decimal MakeExactSum(decimal sum, decimal[] list)
        {
            decimal cursum = list.Sum(d => d);
            if (cursum == sum) return cursum;
            decimal addsumd = cursum < sum ? 0.01M : -0.01M;
            if (cursum == 0.0M)
            {
                while (true)
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        list[i] += addsumd;
                        cursum += addsumd;
                        if (cursum == sum) return cursum;
                    }
                }
            }
            while (true)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] == 0.0M) continue;
                    list[i] += addsumd;
                    cursum += addsumd;
                    if (cursum == sum) return cursum;
                }
            }
        }

        public static decimal[,] MakeExactSplit(decimal[] dd1, decimal[] dd2)
        {
            decimal sdd1 = dd1.Sum();
            decimal sdd2 = dd2.Sum();
            if (sdd1 != sdd2) throw new ArgumentException();
            int ct1 = dd1.Length, ct2 = dd2.Length;
            var ret = new decimal[ct1, ct2];
            if (sdd1 == 0.0M) return ret;
            if (ct1 == 1 && ct2 == 1)
            {
                ret[0, 0] = dd1[0];
                return ret;
            }
            if (ct1 == 1)
            {
                for (int i = 0; i < dd2.Length; i++)
                        ret[0, i] = dd2[i];
                return ret;
            }
            if (ct2 == 1)
            {
                for (int i = 0; i < dd1.Length; i++)
                    ret[i, 0] = dd1[i];
                return ret;
            }

            decimal[] m1 = new decimal[ct1];
            decimal[] m2 = new decimal[ct2];

            for (int i = 0; i < dd1.Length; i++)
            {
                for (int j = 0; j < dd2.Length; j++)
                {
                    decimal v = Math.Truncate(dd1[i] * dd2[j] / sdd2 * 100.0M) / 100.0M;
                    ret[i, j] = v;
                    m1[i] += v;
                    m2[j] += v;
                }
            }

            decimal mm = m1.Sum();
            if (mm == sdd1) return ret;


            bool b = false;
            bool checknotzero = false;
            do
            {
                b = false;
                for (int i = 0; i < dd1.Length; i++)
                {
                    for (int j = 0; j < dd2.Length; j++)
                    {
                        decimal v = ret[i, j];
                        if ((!checknotzero || v > 0.0M) && m1[i] < dd1[i] && m2[j] < dd2[j])
                        {
                            ret[i, j] += 0.01M;
                            m1[i] += 0.01M;
                            m2[j] += 0.01M;
                            mm -= 0.01M;
                            if (mm == 0.0M) return ret;
                            b = true;
                        }
                    }
                }
                if (!b && checknotzero)
                {
                    checknotzero = false;
                    b = true;
                }
            } while (b);


            return ret;
        }


        public void AddIncrementally(PayFx2 row)
        {
            var p1 = new PayFx();
            p1.SetFrom(this);
            AddPay(row);
            CalcAllab();
            var p2 = new PayFx();
            p2.SetFrom(this);
            p2.Subtract(p1);

            row.DNS = p2.DNS;
            row.UsedIinEx = p2.UsedIinEx;
            row.IIN = p2.IIN;
            row.Cash = p2.Cash;

            Rows.Add(row);
        }

        public void AddIncrementallyAndRound(PayFx2 row)
        {
            var p1 = new PayFx();
            p1.SetFrom(this);
            AddPayRound(row);
            CalcAllabAndRound();
            row.SetFrom(this);
            row.Subtract(p1);
            Rows.Add(row);
        }

        public void AddIncrementally(PayFx2[] rows)
        {
            foreach (var pr in rows)
                AddIncrementally(pr);
        }

        public void AddIncrementallyAndRound(PayFx2[] rows)
        {
            foreach (var pr in rows)
                AddIncrementallyAndRound(pr);
        }

        public void AddIncrementallySplitAndRound(PayFx2 rowt, PayFx2[] rows)
        {
            var p1 = new PayFx();
            p1.SetFrom(this);
            AddPayRound(rowt);
            CalcAllabAndRound();
            rowt.SetFrom(this);
            rowt.Subtract(p1);

            SplitAndRound(rowt, rows);

            Rows.Add(rowt);
        }


    }
}
