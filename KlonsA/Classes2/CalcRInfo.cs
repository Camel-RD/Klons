using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsLIB.Misc;
using KlonsLIB.Data;

namespace KlonsA.Classes
{
    public class CalcRInfo
    {
        public bool PreparingReport = false;
        public List<CalcRRow> ReportRows = null;
        public CalcRRow CrUntaxedMinimum = null;
        public CalcRRow CrUntaxedMinimum2 = null; // - VID noteiktais
        public CalcRRow CrDependants = null;
        public CalcRRow CrInvalidity = null;
        public CalcRRow CrRetaliation = null;
        public CalcRRow CrNationalMovement = null;
        public CalcRRow CrExpenses = null;

        public CalcRRow2 ExFull = new CalcRRow2();
        public CalcRRow2 ExForDays = new CalcRRow2();
        public CalcRRow2 ExMax2 = new CalcRRow2();
        public CalcRRow2 ExDivided = new CalcRRow2();
        public CalcRRow2 ExCorrect = new CalcRRow2();

        public int DaysInMonth = 0;
        public int CalendarDays = 0;
        public decimal RateDNSN = 0.0M;
        public decimal RateDDSN = 0.0M;
        public decimal RateIIN = 0.0M;
        public decimal RateIIN2 = 0.0M;
        public decimal IINMargin = 1667.0M;
        public decimal IINMarginA = 440.0M;
        public decimal IINMarginB = 1000.0M;
        public bool IsPensioner = false;
        public bool HasTaxDoc = false;
        public bool UseProgresiveIINRate = false;
        public EIINExempt2Kind IINEx2Tp = EIINExempt2Kind.None;

        public CalcRInfo(bool fillist = false)
        {
            PreparingReport = fillist;
            if (fillist)
            {
                ReportRows = new List<CalcRRow>();
                CrUntaxedMinimum = new CalcRRow("neapliekamais minimums");
                CrUntaxedMinimum2 = new CalcRRow("neapliekamais minimums (VID)");
                CrDependants = new CalcRRow("par apgādajamajiem");
                CrInvalidity = new CalcRRow("par invaliditāti");
                CrRetaliation = new CalcRRow("rehabilitētā persona");
                CrNationalMovement = new CalcRRow("nac.pret.kust. dalībnieks");
                CrExpenses = new CalcRRow("izmaksas");
            }
        }

        public static DateTime ProgressiveIINStartDate = new DateTime(2018, 1, 1);

        public void CalcR(SalarySheetRowInfo sr, DateTime dt1, DateTime dt2)
        {
            if (dt1 > dt2 || dt1.Month != dt2.Month)
                throw new ArgumentException("Bad call.");

            IINMargin = PayFx.GetIINMargin(dt1);
            IINMarginA = PayFx.GetIINMarginA(dt1);
            IINMarginB = PayFx.GetIINMarginB(dt1);

            var fPersonR = sr.PersonR.FilterListWithDates(dt1, dt2);
            var fHireFire = sr.Events.HireFire.FilterListWithDates(dt1, dt2);
            var sickleaveb = sr.Events.SickDays.LinkedPeriods
                .Where(d => d.EEventId == EEventId.Slimības_lapa_B)
                .ToArray();

            fPersonR = fPersonR.FilterWithList(fHireFire);
            fPersonR = fPersonR.SubtractList(sickleaveb);

            DaysInMonth = dt1.DaysInMonth();
            CalendarDays = 0;

            var dr_likmes = dt1.Month == sr.SalarySheet.MT ?
                sr.SalarySheet.DR_Likmes : 
                DataTasks.GetRates(dt1.FirstDayOfMonth());

            if (fPersonR.LinkedPeriods.Count == 0) return;

            var wt1 = new CalcRRow2();
            var pr1 = fPersonR.LinkedPeriods[0].Item1 as KlonsADataSet.PERSONS_RRow;
            IsPensioner = pr1.PENSIONER == 1;
            HasTaxDoc = !string.IsNullOrEmpty(pr1.TAXDOC_NO);
            UseProgresiveIINRate = (dt1 >= ProgressiveIINStartDate);

            GetRatesForPerson(wt1, pr1, dr_likmes, dt1);

            RateDDSN = wt1.RateDDSN;
            RateDNSN = wt1.RateDNSN;
            RateIIN = wt1.RateIIN;
            RateIIN2 = wt1.RateIIN2;
            IINMargin = wt1.IINMargin;
            HasTaxDoc = wt1.HasTaxDoc;
            UseProgresiveIINRate = wt1.UseProgresiveIINRate;

            for (int i = 0; i < fPersonR.LinkedPeriods.Count; i++)
            {
                var pri = fPersonR.LinkedPeriods[i];
                var dt1x = pri.DateFirst;
                var dt2x = pri.DateLast;
                int caldays = dt2x.Subtract(dt1x).Days + 1;
                CalendarDays += caldays;

                GetIINDeductionsForPerson(wt1, pri.Item1 as KlonsADataSet.PERSONS_RRow, dr_likmes, dt1);

                ExFull.Add(wt1);

                if (PreparingReport)
                {
                    SaveStateForMonth(wt1);
                    SaveStateDays(caldays);
                }

                decimal rt = (decimal)caldays / (decimal)DaysInMonth;

                wt1.Multiply(rt);

                ExForDays.Add(wt1);

                if (PreparingReport)
                {
                    SaveStateForDays(wt1);
                    AddToList(dt1x, dt2x);
                }

            }

            ExFull.Round();
            ExForDays.Round();
            ExMax2.SetFrom(ExForDays);

            if (!sr.IsSingleRow() && sr.TotalPositionPay.IINExempt2Kind != EIINExempt2Kind.None &&
                sr.SalarySheet.MT == dt1.Month)
            {
                SetMax(sr.TotalPositionPay.IINExempt2Kind);
            }
            else
            {
                FindMax();
            }

            ExDivided.SetFrom(ExMax2);
            ExCorrect.SetFrom(ExMax2);

            if (PreparingReport)
            {
                SaveStateForMonth(ExFull);
                SaveStateForDays(ExForDays);
                SaveStateForMax(ExMax2);
            }
        }

        public static void GetRatesForPerson(CalcRRow2 wt, KlonsADataSet.PERSONS_RRow drpr, KlonsADataSet.RATESRow drl, DateTime dt)
        {
            wt.UseProgresiveIINRate = dt >= ProgressiveIINStartDate;
            wt.HasTaxDoc = !string.IsNullOrEmpty(drpr.TAXDOC_NO);
            if (dt < ProgressiveIINStartDate)
            {
                wt.RateIIN = drl.IIN_LIKME;
                wt.RateIIN2 = drl.IIN_LIKME;
            }
            else
            {
                wt.RateIIN = drl.IIN_LIKME;
                wt.RateIIN2 = drl.IIN_LIKME_2;
                int iin_rate_type = GetIINRateType(drpr.PERSONSRow, dt.FirstDayOfMonth());
                if (iin_rate_type == 1)
                    wt.RateIIN = wt.RateIIN2;
            }
            wt.IINMargin = drl.IIN_SLIEKSNIS_1;

            if (drpr.PENSIONER == 1)
            {
                if (drpr.PRISONER == 1)
                {
                    wt.RateDNSN = drl.SIDN_IESLODZ_PENS;
                    wt.RateDDSN = drl.SIDD_IESLODZ_PENS;
                }
                else
                {
                    wt.RateDNSN = drl.SIDN_PENS;
                    wt.RateDDSN = drl.SIDD_PENS;
                }
            }
            else if(drpr.PENSIONER_SP == 1)
            {
                wt.RateDNSN = drl.SIDN_IZDPENS;
                wt.RateDDSN = drl.SIDD_IZDPENS;
            }
            else
            {
                if (drpr.PRISONER == 1)
                {
                    wt.RateDNSN = drl.SIDN_IESLODZ;
                    wt.RateDDSN = drl.SIDD_IESLODZ;
                }
                else
                {
                    wt.RateDNSN = drl.SIDN_PAMATLIKME;
                    wt.RateDDSN = drl.SIDD_PAMATLIKME;
                }
            }

        }

        public static void GetIINDeductionsForPerson(CalcRRow2 wt, KlonsADataSet.PERSONS_RRow drpr, KlonsADataSet.RATESRow drl, DateTime dt)
        {
            wt.ExUntaxedMinimum = 0.0M;
            wt.ExUntaxedMinimum2 = 0.0M;
            wt.ExDependants = 0.0M;
            wt.ExInvalidity = 0.0M;
            wt.ExRetaliation = 0.0M;
            wt.ExNationalMovements = 0.0M;

            if (!string.IsNullOrEmpty(drpr.TAXDOC_NO))
            {
                wt.ExDependants = drl.APGAD * (decimal)drpr.APGAD_SK;

                if (drpr.INVALID == 1 || drpr.INVALID == 2)
                    wt.ExInvalidity = drl.INVALID_12;
                else if (drpr.INVALID == 3)
                    wt.ExInvalidity = drl.INVALID_3;

                if (drpr.PRET == 1)
                    wt.ExNationalMovements = drl.PRET;

                if (drpr.REPRES == 1)
                    wt.ExRetaliation = drl.REPR;

                if (drpr.PENSIONER == 1 || drpr.PENSIONER_SP == 1)
                    wt.ExUntaxedMinimum = 0.0M;
                else
                {
                    wt.ExUntaxedMinimum = drl.NEPLIEK_MIN;
                    if (dt < ProgressiveIINStartDate)
                    {
                        wt.ExUntaxedMinimum2 = 0.0M;
                    }
                    else
                    {
                        wt.ExUntaxedMinimum2 = GetIINUntaxedMinimum(drpr.PERSONSRow, dt);
                    }
                }
            }

        }

        public static decimal GetIINUntaxedMinimum(KlonsADataSet.PERSONSRow drpr, DateTime dt)
        {
            var dr_um = drpr.GetUNTAXED_MINRows()
                .WhereX(d => d.ONDATE <= dt)
                .OrderBy(d => d.ONDATE)
                .LastOrDefault();
            if (dr_um == null) return 0.0M;
            return dr_um.UNTAXED_MIN;
        }

        // returns -1 if no data; 0 - reduced rate; 1 - full rate
        public static int GetIINRateType(KlonsADataSet.PERSONSRow drpr, DateTime dt)
        {
            var dr_um = drpr.GetUNTAXED_MINRows()
                .WhereX(d => d.ONDATE <= dt)
                .OrderBy(d => d.ONDATE)
                .LastOrDefault();
            if (dr_um == null) return -1;
            return dr_um.IIN_RATE_TYPE;
        }


        public void ApplyRatio(decimal r, SalaryInfo si)
        {
            ExDivided.SetFrom(ExMax2);
            ExDivided.ApplyRatio(r);
            if (si != null)
            {
                ExDivided.ApplyTo(si);
            }
        }

        public void SetMax(EIINExempt2Kind tp)
        {
            IINEx2Tp = tp;
            ExMax2.Ex2Tp = IINEx2Tp;
            switch (IINEx2Tp)
            {
                case EIINExempt2Kind.Invalid:
                    ExMax2.ExRetaliation = 0.0M;
                    ExMax2.ExNationalMovements = 0.0M;
                    break;
                case EIINExempt2Kind.Retaliated:
                case EIINExempt2Kind.RetaliatedPensioner:
                    ExMax2.ExInvalidity = 0.0M;
                    ExMax2.ExNationalMovements = 0.0M;
                    break;
                case EIINExempt2Kind.NationalMovement:
                case EIINExempt2Kind.NationalMovementPensioner:
                    ExMax2.ExInvalidity = 0.0M;
                    ExMax2.ExRetaliation = 0.0M;
                    break;
            }
        }

        public void FindMax()
        {
            var max = Math.Max(ExMax2.ExInvalidity, ExMax2.ExRetaliation);
            max = Math.Max(max, ExMax2.ExNationalMovements);
            if(max == 0.0M)
            {
                IINEx2Tp = EIINExempt2Kind.None;
            }
            else if (ExMax2.ExInvalidity == max)
            {
                IINEx2Tp = EIINExempt2Kind.Invalid;
                ExMax2.ExRetaliation = 0.0M;
                ExMax2.ExNationalMovements = 0.0M;
            }
            else if (ExMax2.ExRetaliation == max)
            {
                IINEx2Tp = IsPensioner ? EIINExempt2Kind.RetaliatedPensioner : EIINExempt2Kind.Retaliated;
                ExMax2.ExInvalidity = 0.0M;
                ExMax2.ExNationalMovements = 0.0M;
            }
            else if (ExMax2.ExNationalMovements == max)
            {
                IINEx2Tp = IsPensioner ? EIINExempt2Kind.NationalMovementPensioner : EIINExempt2Kind.NationalMovement;
                ExMax2.ExInvalidity = 0.0M;
                ExMax2.ExRetaliation = 0.0M;
            }
            ExMax2.Ex2Tp = IINEx2Tp;
        }

        public void CorrectIINExempts(decimal amounbeforeiinex)
        {
            ExCorrect.SetFrom(ExDivided);
            ExCorrect.CorrectIINExempts(amounbeforeiinex);
        }


        public void SaveStateDays(int days)
        {
            if (!PreparingReport) return;
            CrUntaxedMinimum.Days = days;
            CrUntaxedMinimum2.Days = days;
            CrDependants.Days = days;
            CrInvalidity.Days = days;
            CrRetaliation.Days = days;
            CrNationalMovement.Days = days;
            CrExpenses.Days = days;
        }

        public void SaveStateForMonth(CalcRRow2 cr)
        {
            if (!PreparingReport) return;
            CrUntaxedMinimum.RateForMonth = cr.ExUntaxedMinimum;
            CrUntaxedMinimum2.RateForMonth = cr.ExUntaxedMinimum2;
            CrDependants.RateForMonth = cr.ExDependants;
            CrInvalidity.RateForMonth = cr.ExInvalidity;
            CrRetaliation.RateForMonth = cr.ExRetaliation;
            CrNationalMovement.RateForMonth = cr.ExNationalMovements;
            CrExpenses.RateForMonth = cr.ExExpenses;
        }

        public void SaveStateForDays(CalcRRow2 cr)
        {
            if (!PreparingReport) return;
            CrUntaxedMinimum.RateForDays = cr.ExUntaxedMinimum;
            CrUntaxedMinimum2.RateForDays = cr.ExUntaxedMinimum2;
            CrDependants.RateForDays = cr.ExDependants;
            CrInvalidity.RateForDays = cr.ExInvalidity;
            CrRetaliation.RateForDays = cr.ExRetaliation;
            CrNationalMovement.RateForDays = cr.ExNationalMovements;
            CrExpenses.RateForDays = cr.ExExpenses;
        }

        public void SaveStateForMax(CalcRRow2 cr)
        {
            if (!PreparingReport) return;
            CrInvalidity.RateMax = cr.ExInvalidity;
            CrRetaliation.RateMax = cr.ExRetaliation;
            CrNationalMovement.RateMax = cr.ExNationalMovements;
        }

        public void SaveStateForDivided(CalcRRow2 cr)
        {
            if (!PreparingReport) return;
            CrUntaxedMinimum.RateDivided = cr.ExUntaxedMinimum;
            CrDependants.RateDivided = cr.ExDependants;
            CrInvalidity.RateDivided = cr.ExInvalidity;
            CrRetaliation.RateDivided = cr.ExRetaliation;
            CrNationalMovement.RateDivided = cr.ExNationalMovements;
            CrExpenses.RateDivided = cr.ExExpenses;
        }

        public void SaveStateForFinal(CalcRRow2 cr)
        {
            if (!PreparingReport) return;
            CrUntaxedMinimum.Rate = cr.ExUntaxedMinimum;
            CrDependants.Rate = cr.ExDependants;
            CrInvalidity.Rate = cr.ExInvalidity;
            CrRetaliation.Rate = cr.ExRetaliation;
            CrNationalMovement.Rate = cr.ExNationalMovements;
            CrExpenses.Rate = cr.ExExpenses;
        }

        public void AddToList(DateTime dt1, DateTime dt2)
        {
            if (!PreparingReport) return;
            if (CrUntaxedMinimum.HasData()) AddToList(CrUntaxedMinimum, dt1, dt2);
            if (CrUntaxedMinimum2.HasData()) AddToList(CrUntaxedMinimum2, dt1, dt2);
            if (CrDependants.HasData()) AddToList(CrDependants, dt1, dt2);
            if (CrInvalidity.HasData()) AddToList(CrInvalidity, dt1, dt2);
            if (CrRetaliation.HasData()) AddToList(CrRetaliation, dt1, dt2);
            if (CrNationalMovement.HasData()) AddToList(CrNationalMovement, dt1, dt2);
        }

        public void AddToListT()
        {
            if (!PreparingReport) return;
            if (CrUntaxedMinimum.HasData()) AddToListT(CrUntaxedMinimum);
            if (CrUntaxedMinimum2.HasData()) AddToListT(CrUntaxedMinimum2);
            if (CrDependants.HasData()) AddToListT(CrDependants);
            if (CrInvalidity.HasData()) AddToListT(CrInvalidity);
            if (CrRetaliation.HasData()) AddToListT(CrRetaliation);
            if (CrNationalMovement.HasData()) AddToListT(CrNationalMovement);
            if (CrExpenses.HasData()) AddToListT(CrExpenses);
        }

        public void AddToList(CalcRRow cr, DateTime dt1, DateTime dt2)
        {
            var cr1 = new CalcRRow();
            cr1.SetFrom(cr);
            cr1.Date1 = dt1;
            cr1.Date2 = dt2;
            ReportRows.Add(cr1);
        }

        public void AddToListT(CalcRRow cr)
        {
            var cr1 = new CalcRRow();
            cr1.SetFrom(cr);
            cr1.IsTotals = true;
            ReportRows.Add(cr1);
        }

        public void PrepareList()
        {
            if (!PreparingReport) return;
            var list = new List<CalcRRow>();
            DateTime dt1 = DateTime.MinValue;
            bool totalsdone = false;
            foreach (var r in ReportRows)
            {
                if (r.Date1 != dt1 && !r.IsTotals)
                {
                    var c1 = new CalcRRow();
                    c1.IsTitle = true;
                    c1.Caption = string.Format("{0:dd.MM.yyyy}-{1:dd.MM.yyyy}", r.Date1, r.Date2);
                    list.Add(c1);
                    dt1 = r.Date1;
                }
                if (!totalsdone && r.IsTotals)
                {
                    var c1 = new CalcRRow() { IsTitle = true, Caption = "kopsumma" };
                    list.Add(c1);
                    totalsdone = true;
                }
                list.Add(r);
            }
            ReportRows = list;
        }

        public void PrepareReportT(SalaryCalcTInfo sct)
        {
            if (!PreparingReport) return;
            var list = new List<CalcRRow>();
            var c1 = new CalcRRow() { IsTitle = true, Caption = "Kopā amati" };
            list.Add(c1);
            list.AddRange(ReportRows);
            var ce = new CalcRRow() { IsTitle = true };
            foreach (var sc in sct.LinkedSCI)
            {
                list.Add(ce);
                c1 = new CalcRRow() { IsTitle = true, Caption = sc.SR.GetPositionTitle() };
                list.Add(c1);
                list.AddRange(sc.CalcR.ReportRows);
            }
            ReportRows = list;
        }
    }


    public class CalcRRow
    {
        public bool IsTitle { get; set; } = false;
        public bool IsTotals { get; set; } = false;
        public DateTime Date1 { get; set; } = DateTime.MinValue;
        public DateTime Date2 { get; set; } = DateTime.MinValue;
        public string Caption { get; set; } = "";
        public int Days { get; set; } = 0;
        public decimal RateForMonth { get; set; } = 0.0M;
        public decimal RateForDays { get; set; } = 0.0M;
        public decimal RateMax { get; set; } = 0.0M;
        public decimal RateDivided { get; set; } = 0.0M;
        public decimal Rate { get; set; } = 0.0M;

        public CalcRRow(string caption = "")
        {
            Caption = caption;
        }

        public void Clear()
        {
            Rate = 0.0M;
            RateForMonth = 0.0M;
            RateForDays = 0.0M;
            RateMax = 0.0M;
            RateDivided = 0.0M;
            Days = 0;
        }

        public void SetFrom(CalcRRow cr)
        {
            Caption = cr.Caption;
            Rate = cr.Rate;
            RateForDays = cr.RateForDays;
            RateForMonth = cr.RateForMonth;
            RateMax = cr.RateMax;
            RateDivided = cr.RateDivided;
            Days = cr.Days;
        }

        public bool HasData()
        {
            return RateForMonth > 0.0M || RateForDays > 0.0M || Rate > 0.0M;
        }
    }

    public class CalcRRow2
    {
        public int CalendarDays = 0;
        public decimal ExUntaxedMinimum = 0.0M;
        public decimal ExUntaxedMinimum2 = 0.0M;
        public decimal ExDependants = 0.0M;
        public decimal ExRetaliation = 0.0M;
        public decimal ExInvalidity = 0.0M;
        public decimal ExNationalMovements = 0.0M;
        public decimal ExExpenses = 0.0M;
        public decimal RateDNSN = 0.0M;
        public decimal RateDDSN = 0.0M;
        public decimal RateIIN = 0.0M;
        public decimal RateIIN2 = 0.0M;
        public decimal IINMargin = 0.0M;
        public bool HasTaxDoc = false;
        public bool UseProgresiveIINRate = false;
        public EIINExempt2Kind Ex2Tp = EIINExempt2Kind.None;

        public void Clear()
        {
            ExDependants = 0.0M;
            ExInvalidity = 0.0M;
            ExNationalMovements = 0.0M;
            ExRetaliation = 0.0M;
            ExUntaxedMinimum = 0.0M;
            ExUntaxedMinimum2 = 0.0M;
            Ex2Tp = EIINExempt2Kind.None;
            ExExpenses = 0.0M;
            RateDDSN = 0.0M;
            RateDNSN = 0.0M;
            RateIIN = 0.0M;
            RateIIN2 = 0.0M;
            IINMargin = 0.0M;
            HasTaxDoc = false;
            UseProgresiveIINRate = false;
        }

        public bool Equals(CalcRRow2 cr)
        {
            if (ExDependants != cr.ExDependants) return false;
            if (ExInvalidity != cr.ExInvalidity) return false;
            if (ExNationalMovements != cr.ExNationalMovements) return false;
            if (ExRetaliation != cr.ExRetaliation) return false;
            if (ExUntaxedMinimum != cr.ExUntaxedMinimum) return false;
            if (ExUntaxedMinimum2 != cr.ExUntaxedMinimum2) return false;
            if (Ex2Tp != cr.Ex2Tp) return false;
            if (ExExpenses != cr.ExExpenses) return false;
            if (RateDDSN != cr.RateDDSN) return false;
            if (RateDNSN != cr.RateDNSN) return false;
            if (RateIIN != cr.RateIIN) return false;
            if (RateIIN2 != cr.RateIIN2) return false;
            if (IINMargin != cr.IINMargin) return false;
            if (HasTaxDoc != cr.HasTaxDoc) return false;
            return true;
        }

        public void SetFrom(CalcRRow2 cr)
        {
            ExDependants = cr.ExDependants;
            ExInvalidity = cr.ExInvalidity;
            ExNationalMovements = cr.ExNationalMovements;
            ExRetaliation = cr.ExRetaliation;
            ExUntaxedMinimum = cr.ExUntaxedMinimum;
            ExUntaxedMinimum2 = cr.ExUntaxedMinimum2;
            Ex2Tp = cr.Ex2Tp;
            ExExpenses = cr.ExExpenses;
            RateDDSN = cr.RateDDSN;
            RateDNSN = cr.RateDNSN;
            RateIIN = cr.RateIIN;
            RateIIN2 = cr.RateIIN2;
            IINMargin = cr.IINMargin;
            HasTaxDoc = cr.HasTaxDoc;
            UseProgresiveIINRate = cr.UseProgresiveIINRate;
        }

        public void Multiply(decimal r)
        {
            ExDependants *= r;
            ExInvalidity *= r;
            ExNationalMovements *= r;
            ExRetaliation *= r;
            ExUntaxedMinimum *= r;
            ExUntaxedMinimum2 *= r;
        }

        public void Add(CalcRRow2 cr)
        {
            ExDependants += cr.ExDependants;
            ExInvalidity += cr.ExInvalidity;
            ExNationalMovements += cr.ExNationalMovements;
            ExRetaliation += cr.ExRetaliation;
            ExUntaxedMinimum += cr.ExUntaxedMinimum;
            ExUntaxedMinimum2 += cr.ExUntaxedMinimum2;
        }

        public void Round()
        {
            ExDependants = KlonsData.RoundA(ExDependants, 2);
            ExInvalidity = KlonsData.RoundA(ExInvalidity, 2);
            ExNationalMovements = KlonsData.RoundA(ExNationalMovements, 2);
            ExRetaliation = KlonsData.RoundA(ExRetaliation, 2);
            ExUntaxedMinimum = KlonsData.RoundA(ExUntaxedMinimum, 2);
            ExUntaxedMinimum2 = KlonsData.RoundA(ExUntaxedMinimum2, 2);
        }

        public void ApplyTo0(SalaryInfo si)
        {
            si._IIN_EXEMPT_UNTAXED_MINIMUM0 = ExUntaxedMinimum;
            si._IIN_EXEMPT_DEPENDANTS0 = ExDependants;
            si._IIN_EXEMPT_INVALIDITY0 = ExInvalidity;
            si._IIN_EXEMPT_RETALIATION0 = ExRetaliation;
            si._IIN_EXEMPT_NATIONAL_MOVEMENT0 = ExNationalMovements;
            si._IIN_EXEMPT_20 = ExInvalidity + ExRetaliation + ExNationalMovements;
        }

        public void ApplyTo(SalaryInfo si)
        {
            si._IIN_EXEMPT_UNTAXED_MINIMUM = ExUntaxedMinimum;
            si._IIN_EXEMPT_DEPENDANTS = ExDependants;
            si._IIN_EXEMPT_INVALIDITY = ExInvalidity;
            si._IIN_EXEMPT_RETALIATION = ExRetaliation;
            si._IIN_EXEMPT_NATIONAL_MOVEMENT = ExNationalMovements;
            si._IIN_EXEMPT_EXPENSES = ExExpenses;
            si._IIN_EXEMPT_2 = ExInvalidity + ExRetaliation + ExNationalMovements;
            si.IINExempt2Kind = Ex2Tp;
        }

        public void SetFrom(SalaryInfo si)
        {
            ExUntaxedMinimum = si._IIN_EXEMPT_UNTAXED_MINIMUM;
            ExDependants = si._IIN_EXEMPT_DEPENDANTS;
            ExInvalidity = si._IIN_EXEMPT_INVALIDITY;
            ExRetaliation = si._IIN_EXEMPT_RETALIATION;
            ExNationalMovements = si._IIN_EXEMPT_NATIONAL_MOVEMENT;
            ExExpenses = si._IIN_EXEMPT_EXPENSES;
            Ex2Tp = si.IINExempt2Kind;
        }


        public decimal SumIINExempts()
        {
            return ExDependants +
                ExInvalidity +
                ExNationalMovements +
                ExRetaliation +
                ExUntaxedMinimum;
        }

        public decimal SumIINExemptsAll()
        {
            return SumIINExempts() + ExExpenses;
        }

        private void MinusIINExempts(decimal d)
        {
            decimal d1;

            d1 = Math.Min(d, ExUntaxedMinimum);
            ExUntaxedMinimum -= d1;
            d -= d1;
            if (d == 0.0M) return;

            d1 = Math.Min(d, ExDependants);
            ExDependants -= d1;
            d -= d1;
            if (d == 0.0M) return;

            d1 = Math.Min(d, ExInvalidity);
            ExInvalidity -= d1;
            d -= d1;
            if (d == 0.0M) return;

            d1 = Math.Min(d, ExNationalMovements);
            ExNationalMovements -= d1;
            d -= d1;
            if (d == 0.0M) return;

            d1 = Math.Min(d, ExRetaliation);
            ExRetaliation -= d1;
            d -= d1;
            if (d == 0.0M) return;

            d1 = Math.Min(d, ExExpenses);
            ExExpenses -= d1;
            d -= d1;
            if (d == 0.0M) return;
        }

        public void CorrectIINExempts(decimal amounbeforeiinex)
        {
            var d = SumIINExemptsAll();
            if (d > amounbeforeiinex)
                MinusIINExempts(d - amounbeforeiinex);
            if (ExInvalidity + ExNationalMovements + ExRetaliation == 0.0M)
                Ex2Tp = EIINExempt2Kind.None;
        }

        public void ApplyRatio(decimal r)
        {
            ExDependants = KlonsData.RoundA(r * ExDependants, 2);
            ExInvalidity = KlonsData.RoundA(r * ExInvalidity, 2);
            ExNationalMovements = KlonsData.RoundA(r * ExNationalMovements, 2);
            ExRetaliation = KlonsData.RoundA(r * ExRetaliation, 2);
            ExUntaxedMinimum = KlonsData.RoundA(r * ExUntaxedMinimum, 2);
            ExUntaxedMinimum2 = KlonsData.RoundA(r * ExUntaxedMinimum2, 2);
        }

    }
}
