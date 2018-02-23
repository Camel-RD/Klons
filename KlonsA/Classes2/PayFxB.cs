using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlonsA.Classes
{
    public class PayFxB : PayFxA
    {
        public List<PayFxA> Parts = new List<PayFxA>();

        public List<BonusCalcInfo.CalcRet> TempCRets = new List<BonusCalcInfo.CalcRet>();
        public List<BonusCalcInfo.CalcRet> TempCRets2 = new List<BonusCalcInfo.CalcRet>();

        public PayFxB(bool hasProgressiveIIN = true) : base(hasProgressiveIIN)
        {
            Position = "KOPĀ";
        }

        public PayFxB(CalcRInfo cri):base(cri)
        {
            Position = "KOPĀ";
        }

        public void InitParts(SalaryCalcTInfo pcti)
        {
            for (int i = 0; i < pcti.LinkedSCI.Length; i++)
            {
                var lsc = pcti.LinkedSCI[i];
                var partpfx = new PayFxA();
                partpfx.SetFrom(this);
                lsc.PFxA = partpfx;
                partpfx.Position = lsc.PositionTitle;
                Parts.Add(partpfx);
            }
        }

        public void DoPayFxB_Salary(decimal valt, decimal[] vals)
        {
            if (valt == 0.0M) return;
            var PFx_salary = new PayFx2();
            PFx_salary.SetFrom(this);
            PFx_salary.Caption = "Darba samaksa";
            PFx_salary.Pay = valt;

            var partpfxs = new PayFx2[Parts.Count];
            for (int i = 0; i < Parts.Count; i++)
            {
                var partpfx = Parts[i];
                var pfx_salary = new PayFx2();
                pfx_salary.SetFrom(partpfx);
                pfx_salary.Caption = "Darba samaksa";
                pfx_salary.Pay = vals[i];
                partpfxs[i] = pfx_salary;
            }
            //AddEqallyAndRound(partpfxs, Parts);
            AddIncrementallySplitAndRound(PFx_salary, partpfxs);
        }

        public void DoPayFxB_AvPay(decimal valt, decimal[] vals)
        {
            if (valt == 0.0M) return;
            var PFx_avpay = new PayFx2();
            PFx_avpay.SetFrom(this);
            PFx_avpay.Caption = "Vidējās izpeļņas dienas";
            PFx_avpay.Pay = valt;

            var partpfxs = new PayFx2[Parts.Count];
            for (int i = 0; i < Parts.Count; i++)
            {
                var partpfx = Parts[i];
                var pfx_avpay = new PayFx2();
                pfx_avpay.SetFrom(partpfx);
                pfx_avpay.Caption = "Vidējās izpeļņas dienas";
                pfx_avpay.Pay = vals[i];
                partpfxs[i] = pfx_avpay;
            }
            //AddEqallyAndRound(partpfxs, Parts);
            AddIncrementallySplitAndRound(PFx_avpay, partpfxs);
        }

        public void DoPayFxB_SickPay(decimal valt, decimal[] vals)
        {
            if (valt == 0.0M) return;
            PFx_sickpay = new PayFx2();
            PFx_sickpay.SetFrom(this);
            PFx_sickpay.Caption = "Slimības nauda";
            PFx_sickpay.Pay = valt;

            var partpfxs = new PayFx2[Parts.Count];
            for (int i = 0; i < Parts.Count; i++)
            {
                var partpfx = Parts[i];
                var PFxA_sickpay = new PayFx2();
                PFxA_sickpay.SetFrom(partpfx);
                partpfx.PFx_sickpay = PFxA_sickpay;
                PFxA_sickpay.Caption = "Slimības nauda";
                PFxA_sickpay.Pay = vals[i];
                partpfxs[i] = PFxA_sickpay;
            }
            //PFxB.AddEqallyAndRound(partpfxs, PFxB.Parts);
            AddIncrementallySplitAndRound(PFx_sickpay, partpfxs);
        }

        public void DoPayFxB_Vacation(decimal valt, decimal[] vals)
        {
            if (valt == 0.0M) return;
            PFx_vacation = new PayFx2();
            PFx_vacation.SetFrom(this);
            PFx_vacation.Caption = "Atvaļinājuma nauda";
            PFx_vacation.Pay = valt;

            var partpfxs = new PayFx2[Parts.Count];
            for (int i = 0; i < Parts.Count; i++)
            {
                var partpfx = Parts[i];
                var PFxA_vacation = new PayFx2();
                PFxA_vacation.SetFrom(partpfx);
                partpfx.PFx_vacation = PFxA_vacation;
                PFxA_vacation.Caption = "Atvaļinājuma nauda";
                PFxA_vacation.Pay = vals[i];
                partpfxs[i] = PFxA_vacation;
            }
            //PFxB.AddEqallyAndRound(partpfxs, PFxB.Parts);
            AddIncrementallySplitAndRound(PFx_vacation, partpfxs);
        }

        public void DoPayFxB_VacationPrev(decimal valt, decimal[] vals)
        {
            if (valt == 0.0M) return;
            PFx_vacation_prev = new PayFx2();
            PFx_vacation_prev.SetFrom(this);
            PFx_vacation_prev.Caption = "Iepriekš izmaksātā atv.n.";
            PFx_vacation_prev.Pay += valt;
            PFx_vacation_prev.CalcAllabAndRound();
            PFx_vacation_prev.Subtract(this);

            var partpfxs = new PayFx2[Parts.Count];
            for (int i = 0; i < Parts.Count; i++)
            {
                var partpfx = Parts[i];
                var PFxA_vacation_prev = new PayFx2();
                PFxA_vacation_prev.SetFrom(partpfx);
                partpfx.PFx_vacation = PFxA_vacation_prev;
                PFxA_vacation_prev.Caption = "Atvaļinājuma nauda";
                PFxA_vacation_prev.Pay = vals[i];
                partpfxs[i] = PFxA_vacation_prev;
            }
            SplitAndRound(PFx_vacation, partpfxs);
        }

        public void DoPayFxB_Bonus(List<BonusCalcInfo.CalcRet> crets)
        {
            foreach (var cret in crets)
            {
                cret.PfxT.IinEx = IinEx;
                AddIncrementallySplitAndRound(cret.PfxT, cret.Pfxs);
            }
        }

        public void DoPayFxB_BonusSimpleAdd(List<BonusCalcInfo.CalcRet> crets)
        {
            foreach (var cret in crets)
            {
                Add(cret.PfxT);
                Rows.Add(cret.PfxT);
                for (int i = 0; i < cret.Pfxs.Length; i++)
                {
                    var pfx = cret.Pfxs[i];
                    if (pfx == null) continue;
                    Parts[i].Add(cret.PfxT);
                    Parts[i].Rows.Add(cret.PfxT);
                }
            }
        }

        public void AddEqally(PayFx2[] rows, PayFxA topart)
        {
            base.AddEqally(rows);
            foreach(var pr in rows)
                topart.Add(pr);
            topart.Rows.AddRange(rows);
        }

        public void AddEqallyAndRound(PayFx2[] rows, PayFxA topart)
        {
            base.AddEqallyAndRound(rows);
            foreach (var pr in rows)
                topart.Add(pr);
            topart.Rows.AddRange(rows);
        }

        public void AddEqally(PayFx2[] rows, List<PayFxA> topart)
        {
            if (rows.Length != topart.Count) throw new ArgumentException();
            base.AddEqally(rows);
            for(int i = 0; i < rows.Length; i++)
            {
                var part = topart[i];
                var row = rows[i];
                part.Add(row);
                part.Rows.Add(row);
            }
        }

        public void AddEqallyAndRound(PayFx2[] rows, List<PayFxA> topart)
        {
            if (rows.Length != topart.Count) throw new ArgumentException();
            base.AddEqallyAndRound(rows);
            for (int i = 0; i < rows.Length; i++)
            {
                var part = topart[i];
                var row = rows[i];
                part.Add(row);
                part.Rows.Add(row);
            }
        }

        public void AddIncrementally(PayFx2[] rows, PayFxA topart)
        {
            base.AddIncrementally(rows);
            foreach (var pr in rows)
                topart.Add(pr);
            topart.Rows.AddRange(rows);
        }

        public void AddIncrementallyAndRound(PayFx2[] rows, PayFxA topart)
        {
            base.AddIncrementallyAndRound(rows);
            foreach (var pr in rows)
                topart.Add(pr);
            topart.Rows.AddRange(rows);
        }

        public new void AddIncrementallySplitAndRound(PayFx2 rowt, PayFx2[] rows)
        {
            if (rows.Length != Parts.Count) throw new ArgumentException();
            base.AddIncrementallySplitAndRound(rowt, rows);
            for (int i = 0; i < rows.Length; i++)
            {
                var pfx = rows[i];
                if (pfx == null) continue;
                var part = Parts[i];
                part.Add(pfx);
                part.Rows.Add(pfx);
            }
        }

    }
}
