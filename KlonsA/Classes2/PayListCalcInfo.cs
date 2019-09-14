using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsA.DataSets;
using KlonsLIB.Misc;
using KlonsLIB.Data;

namespace KlonsA.Classes
{
    public class PayListCalcInfo
    {
        public static PayListCalcInfo Static = new PayListCalcInfo(false);

        public bool PreparingReport = false;
        public List<PayCalcRow> RepRows = null;
        public int idp = -1;
        public string Name = null;
        public string PosTitle = null;
        public string Dates1 = null;
        public string Dates2 = null;

        public PayListCalcInfo() { }
        public PayListCalcInfo(bool preparingreport)
        {
            PreparingReport = preparingreport;
            if (PreparingReport)
                RepRows = new List<PayCalcRow>();
        }


        public void MakeReportB(KlonsADataSet.PAYLISTS_RRow dr)
        {
            idp = dr.IDP;
            int idam = dr.IDAM;
            Name = DataTasks.GetPersonName(idp);
            PosTitle = DataTasks.GetPositionTitle(idam);
            Dates1 = Utils.DateToString(dr.PAYLISTSRow.DT);
            Dates2 = Utils.DateToString(dr.DT1) + " - " + Utils.DateToString(dr.DT2);
            var ad = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.SP_PAY_MATCHLISTS_2XTableAdapter();
            var tab = ad.GetDataBy_SP_PAY_MATCHLISTS_21(dr.ID);
            for (int i = 0; i < tab.Count; i++)
            {
                var dri = tab[i];
                var dts = Utils.DateToString(dri.DT1) + " - " + Utils.DateToString(dri.DT2);
                var cr = new PayCalcRow(dts);
                cr.SetFrom(dri);
                RepRows.Add(cr);
            }
        }

        public string Calc(KlonsADataSet.PAYLISTS_RRow dr,
            KlonsARepDataSet.SP_PAY_MATCHLISTS_1XRow dr_x)
        {
            var sr1 = new PayCalcRow();
            var paid1 = new PayCalcRow();
            PayCalcRow rpay1 = null;
            var sr2 = new PayCalcRow();
            var paid2 = new PayCalcRow();
            PayCalcRow rpay2 = null;

            if (PreparingReport)
            {
                idp = dr.IDP;
                Name = DataTasks.GetPersonName(idp);
                PosTitle = DataTasks.GetPositionTitle(dr_x.IDAM);
            }

            if (!dr_x.IsIDSHR1Null() && dr.R1 < 1.0f)
            {
                sr1.SetFromA1(dr_x);
                paid1.SetFromA2(dr_x);
                if (PreparingReport)
                {
                    Dates1 = Utils.DateToString(sr1.DT1) + " - " + Utils.DateToString(sr1.DT2);
                    RepRows.Add(new PayCalcRow("Aprēķins 1") { IsTitle = true });
                }
                var ret = Calc2(sr1, paid1, dr_x.PAY1, out rpay1);
                if (ret != "OK")
                {
                    if (!PreparingReport)
                        PayCalcRow.Empty.WriteTo1(dr);
                    return ret;
                }
                if (!PreparingReport)
                    rpay1.WriteTo1(dr);
            }
            else
            {
                if (!PreparingReport)
                    PayCalcRow.Empty.WriteTo1(dr);
            }

            if (!dr_x.IsIDSHR2Null() && dr.R2 < 1.0f)
            {
                sr2.SetFromB1(dr_x);
                paid2.SetFromB2(dr_x);
                if (PreparingReport)
                {
                    Dates2 = Utils.DateToString(sr2.DT1) + " - " + Utils.DateToString(sr2.DT2);
                    RepRows.Add(new PayCalcRow("Aprēķins 2") { IsTitle = true });
                }
                var ret = Calc2(sr2, paid2, dr_x.PAY2, out rpay2);
                if (ret != "OK")
                {
                    if (!PreparingReport)
                        PayCalcRow.Empty.WriteTo2(dr);
                    return ret;
                }
                if (!PreparingReport)
                    rpay2.WriteTo2(dr);
            }
            else
            {
                if (!PreparingReport)
                    PayCalcRow.Empty.WriteTo2(dr);
            }

            return "OK";
        }


        public string Calc2(PayCalcRow sr, PayCalcRow paid, decimal pay, out PayCalcRow rpay)
        {
            sr.CASH_NOTPAID = sr.RecalcCashNotPaid();
            paid.CASH_NOTPAID = paid.RecalcCashNotPaid();

            rpay = new PayCalcRow();
            rpay.SetFrom(sr);
            rpay.SubtractThat(paid);
            rpay.CASH_REQ = pay;

            decimal paya = paid.CASH + pay;
            var paid2 = new PayCalcRow();
            paid2.SetFrom(paid);
            decimal payleft = paya - paid2.CASH;

            if (PreparingReport)
            {
                RepRows.Add(sr.AsCopy("No algas apr."));
                RepRows.Add(paid.AsCopy("Jau izmaksāts"));
                RepRows.Add(rpay.AsCopy("Atlicis"));
            }
            int ct1 = 0;
            if(PreparingReport) ct1 = RepRows.Count;


            if (rpay.CASH <= payleft)
            {
                var rpay0 = new PayCalcRow();
                rpay0.SetFrom(rpay);
                paid2.AddThat(rpay0);
                rpay.SetFrom(rpay0);

                if (PreparingReport)
                {
                    RepRows.Add(rpay0.AsCopy("Aprēķins"));
                    RepRows.Add(paid2.AsCopy("Pēc aprēķina"));
                }
                return "OK";
            }

            if (rpay.PAY_TAXED == 0.0M && rpay.PAY_NOSAI == 0.0M && rpay.PAY_NOTTAXED == 0.0M)
            {
                rpay = new PayCalcRow();
                return "OK";
            }

            //not-paid-not-taxed-PF-LI-HI
            var rpayNPNT = new PayCalcRow();
            decimal npnt = rpay.PFNT + rpay.LINT + rpay.HINT;
            decimal npnt2 = Math.Min(npnt, pay);
            if (npnt2 > 0.0M)
            {
                rpayNPNT.PAY_NOTTAXED = npnt2;
                rpayNPNT.NOTPAID_NOTTAXED = npnt2;
                rpayNPNT.PFNT = rpay.PFNT;
                rpayNPNT.LINT = rpay.LINT;
                rpayNPNT.HINT = rpay.HINT;
                if(npnt2 < npnt)
                {
                    decimal x = npnt2 / npnt;
                    rpayNPNT.PFNT *= x;
                    rpayNPNT.LINT *= x;
                    rpayNPNT.HINT *= x;
                }
                rpayNPNT.CASH = npnt2;
                rpayNPNT.CASH_NOTPAID = npnt2;

                paid2.AddThat(rpayNPNT);
                rpay.SetFrom(sr);
                rpay.SubtractThat(paid2);
                payleft = paya - paid2.CASH;

                if (PreparingReport)
                {
                    RepRows.Add(rpayNPNT.AsCopy("Neapl.iemaks.PF"));
                    RepRows.Add(paid2.AsCopy("Pēc neapl.iemaks.PF"));
                }


                if (rpay.CASH <= payleft)
                {
                    var rpay0 = new PayCalcRow();
                    rpay0.SetFrom(rpay);
                    paid2.AddThat(rpay0);
                    paid2.RecalcAndRound();
                    rpay.SetFrom(paid2);
                    rpay.SubtractThat(paid);

                    if (PreparingReport)
                    {
                        RepRows.Add(rpay0.AsCopy("Aprēķins"));
                        RepRows.Add(paid2.AsCopy("Pēc aprēķina"));
                    }
                    return "OK";
                }

                if (rpay.PAY_TAXED == 0.0M && rpay.PAY_NOSAI == 0.0M && rpay.PAY_NOTTAXED == 0.0M)
                {
                    paid2.RecalcAndRound();
                    rpay.SetFrom(paid2);
                    rpay.SubtractThat(paid);
                    return "OK";
                }
            }


            //not-paid-whats-left
            PayCalcRow rpayNP = null;
            decimal np = rpay.NOTPAID_TAXED + rpay.NOTPAID_NOSAI + rpay.NOTPAID_NOTTAXED;
            if (np > 0.0M)
            {
                var srNP = new PayCalcRow();
                srNP.SetFrom(sr);

                srNP.PAY_TAXED = rpay.NOTPAID_TAXED;
                srNP.PAY_NOSAI = rpay.NOTPAID_NOSAI;
                srNP.PAY_NOTTAXED = rpay.NOTPAID_NOTTAXED;

                srNP.NOTPAID_TAXED = rpay.NOTPAID_TAXED;
                srNP.NOTPAID_NOSAI = rpay.NOTPAID_NOSAI;
                srNP.NOTPAID_NOTTAXED = rpay.NOTPAID_NOTTAXED;

                Calc1(srNP, paid2, pay - rpayNPNT.CASH, out rpayNP);
                paid2.AddThat(rpayNP);
                rpay.SetFrom(paid2);
                rpay.SubtractThat(paid);
                payleft = paya - paid2.CASH;

                if (PreparingReport)
                {
                    RepRows.Add(rpayNP.AsCopy("Neizm."));
                    RepRows.Add(paid2.AsCopy("Pēc neizm."));
                }

                if (rpay.CASH <= payleft)
                {
                    var rpay0 = new PayCalcRow();
                    rpay0.SetFrom(rpay);
                    paid2.AddThat(rpay0);
                    paid2.RecalcAndRound();
                    rpay.SetFrom(paid2);
                    rpay.SubtractThat(paid);

                    if (PreparingReport)
                    {
                        RepRows.Add(rpay0.AsCopy("Aprēķins"));
                        RepRows.Add(paid2.AsCopy("Pēc aprēķina"));
                    }
                    return "OK";
                }

                if (rpay.PAY_TAXED == 0.0M && rpay.PAY_NOSAI == 0.0M && rpay.PAY_NOTTAXED == 0.0M)
                {
                    paid2.RecalcAndRound();
                    rpay.SetFrom(paid2);
                    rpay.SubtractThat(paid);
                    return "OK";
                }
            }

            //paid
            PayCalcRow rpayP = null;

            Calc1(sr, paid2, paya - paid2.CASH, out rpayP);
            paid2.AddThat(rpayP);

            if (PreparingReport)
            {
                RepRows.Add(rpayP.AsCopy("Aprēķins"));
                RepRows.Add(paid2.AsCopy("Pēc aprēķina"));
            }

            paid2.RecalcAndRound();
            rpay.SetFrom(paid2);
            rpay.SubtractThat(paid);

            if(PreparingReport && ct1 > RepRows.Count + 2)
            {
                RepRows.Add(rpay.AsCopy("Kopā aprēķins"));
            }


            return "OK";
        }


        public string Calc1(PayCalcRow sr, PayCalcRow paid, decimal pay, out PayCalcRow rpay)
        {
            rpay = new PayCalcRow();

            rpay.SetFrom(sr);
            rpay.SubtractThat(paid);
            rpay.CASH_REQ = pay;

            if (rpay.CASH == 0.0M) return "OK";
            if (rpay.PAY_TAXED == 0.0M && rpay.PAY_NOSAI == 0.0M && rpay.PAY_NOTTAXED == 0.0M) return "OK";

            var pfx = new PayFx();
            var pfx2 = new PayFx();
            var pfx3 = new PayFx();
            paid.SetTo(pfx, sr);
            pfx2.SetFrom(pfx);
            pfx.IncPayByIncCash(pay, rpay.PAY_TAXED, rpay.PAY_NOSAI, rpay.PAY_NOTTAXED);
            pfx3.SetFrom(pfx);
            pfx.CalcAll();
            pfx.Subtract(pfx2);
            rpay.SetFrom(pfx);

            pfx3.Pay = Math.Min(pfx3.Pay, sr.NOTPAID_TAXED);
            pfx3.PayNs = Math.Min(pfx3.PayNs, sr.NOTPAID_NOSAI);
            pfx3.PayNt = Math.Min(pfx3.PayNt, sr.NOTPAID_NOTTAXED);

            pfx3.CalcAll();
            rpay.CASH_NOTPAID = pfx3.Cash - paid.CASH_NOTPAID;

            return "OK";
        }


    }

    // PFT, LIT, HIT are included in PAY_TAXED
    // PFNT, LINT, HINT are included in PAY_NOTTAXED
    public class PayCalcRow
    {
        public static PayCalcRow Empty = new PayCalcRow();

        public bool IsTitle { get; set; } = false;
        public string Caption { get; set; } = null;
        public int? ID_P { get; set; } = null;
        public int ID_AM { get; set; } = 0;
        public int? ID_SHR { get; set; } = null;
        public DateTime DT1 { get; set; }
        public DateTime DT2 { get; set; }
        
        public decimal IIN_RATE { get; set; } = 0.0M;
        public decimal IIN_RATE2 { get; set; } = 0.0M;
        public decimal SI_RATE { get; set; } = 0.0M;

        public decimal PAY_TAXED { get; set; } = 0.0M;
        public decimal PAY_NOSAI { get; set; } = 0.0M;
        public decimal PAY_NOTTAXED { get; set; } = 0.0M;
        public decimal NOTPAID_TAXED { get; set; } = 0.0M;
        public decimal NOTPAID_NOSAI { get; set; } = 0.0M;
        public decimal NOTPAID_NOTTAXED { get; set; } = 0.0M;
        public decimal UNTAXED_MINIMUM { get; set; } = 0.0M;
        public decimal IINEX_DEPENDANTS { get; set; } = 0.0M;
        public decimal IINEX2 { get; set; } = 0.0M;
        public short IINEX2_TP { get; set; } = 0;
        public decimal DNSI { get; set; } = 0.0M;
        public decimal PFT { get; set; } = 0.0M;
        public decimal LIT { get; set; } = 0.0M;
        public decimal HIT { get; set; } = 0.0M;
        public decimal PFNT { get; set; } = 0.0M;
        public decimal LINT { get; set; } = 0.0M;
        public decimal HINT { get; set; } = 0.0M;
        public decimal PFLIHINT => PFNT + LINT + HINT;
        public decimal IINEX_EXP { get; set; } = 0.0M;
        public decimal IIN { get; set; } = 0.0M;
        public decimal CASH_REQ { get; set; } = 0.0M;
        public decimal CASH { get; set; } = 0.0M;
        public decimal CASH_NOTPAID { get; set; } = 0.0M;

        public PayCalcRow() { }

        public PayCalcRow(string cap)
        {
            Caption = cap;
        }

        public PayCalcRow AsCopy(string cap = null)
        {
            var cr = new PayCalcRow(cap);
            cr.SetFrom(this);
            return cr;
        }

        public void SetFrom(PayCalcRow cr)
        {
            ID_P = cr.ID_P;
            ID_AM = cr.ID_AM;
            ID_SHR = cr.ID_SHR;

            DT1 = cr.DT1;
            DT2 = cr.DT2;

            IIN_RATE = cr.IIN_RATE;
            IIN_RATE2 = cr.IIN_RATE2;
            SI_RATE = cr.SI_RATE;

            PAY_TAXED = cr.PAY_TAXED;
            PAY_NOSAI = cr.PAY_NOSAI;
            PAY_NOTTAXED = cr.PAY_NOTTAXED;
            NOTPAID_TAXED = cr.NOTPAID_TAXED;
            NOTPAID_NOSAI = cr.NOTPAID_NOSAI;
            NOTPAID_NOTTAXED = cr.NOTPAID_NOTTAXED;

            UNTAXED_MINIMUM = cr.UNTAXED_MINIMUM;
            IINEX_DEPENDANTS = cr.IINEX_DEPENDANTS;
            IINEX2 = cr.IINEX2;
            IINEX2_TP = cr.IINEX2_TP;
            DNSI = cr.DNSI;

            PFT = cr.PFT;
            LIT = cr.LIT;
            HIT = cr.HIT;
            PFNT = cr.PFNT;
            LINT = cr.LINT;
            HINT = cr.HINT;

            IINEX_EXP = cr.IINEX_EXP;
            IIN = cr.IIN;
            CASH = cr.CASH;
            CASH_NOTPAID = cr.CASH_NOTPAID;
        }

        public void SubtractThat(PayCalcRow cr)
        {
            PAY_TAXED -= cr.PAY_TAXED;
            PAY_NOSAI -= cr.PAY_NOSAI;
            PAY_NOTTAXED -= cr.PAY_NOTTAXED;
            NOTPAID_TAXED -= cr.NOTPAID_TAXED;
            NOTPAID_NOSAI -= cr.NOTPAID_NOSAI;
            NOTPAID_NOTTAXED -= cr.NOTPAID_NOTTAXED;

            UNTAXED_MINIMUM -= cr.UNTAXED_MINIMUM;
            IINEX_DEPENDANTS -= cr.IINEX_DEPENDANTS;
            IINEX2 -= cr.IINEX2;
            DNSI -= cr.DNSI;

            PFT -= cr.PFT;
            LIT -= cr.LIT;
            HIT -= cr.HIT;
            PFNT -= cr.PFNT;
            LINT -= cr.LINT;
            HINT -= cr.HINT;

            IINEX_EXP -= cr.IINEX_EXP;
            IIN -= cr.IIN;
            CASH -= cr.CASH;
            CASH_NOTPAID -= cr.CASH_NOTPAID;
        }

        public void AddThat(PayCalcRow cr)
        {
            PAY_TAXED += cr.PAY_TAXED;
            PAY_NOSAI += cr.PAY_NOSAI;
            PAY_NOTTAXED += cr.PAY_NOTTAXED;
            NOTPAID_TAXED += cr.NOTPAID_TAXED;
            NOTPAID_NOSAI += cr.NOTPAID_NOSAI;
            NOTPAID_NOTTAXED += cr.NOTPAID_NOTTAXED;

            UNTAXED_MINIMUM += cr.UNTAXED_MINIMUM;
            IINEX_DEPENDANTS += cr.IINEX_DEPENDANTS;
            IINEX2 += cr.IINEX2;
            DNSI += cr.DNSI;

            PFT += cr.PFT;
            LIT += cr.LIT;
            HIT += cr.HIT;
            PFNT += cr.PFNT;
            LINT += cr.LINT;
            HINT += cr.HINT;

            IINEX_EXP += cr.IINEX_EXP;
            IIN += cr.IIN;
            CASH += cr.CASH;
            CASH_NOTPAID += cr.CASH_NOTPAID;
        }

        public void SetFromA1(KlonsARepDataSet.SP_PAY_MATCHLISTS_1XRow dr_x)
        {
            ID_P = dr_x.IsIDPNull() ? (int?)null : dr_x.IDP;
            ID_AM = dr_x.IDAM;
            ID_SHR = dr_x.IDSHR1;

            DT1 = dr_x.VA_SHEET_DT1;
            DT2 = dr_x.VA_SHEET_DT2;

            IIN_RATE = dr_x.VA_IIN_RATE;
            IIN_RATE2 = dr_x.VA_IIN_RATE2;
            SI_RATE = dr_x.VA_SI_RATE;

            PAY_TAXED = dr_x.VA1_PAY_TAXED;
            PAY_NOSAI = dr_x.VA1_PAY_NOSAI;
            PAY_NOTTAXED = dr_x.VA1_PAY_NOTTAXED;
            NOTPAID_TAXED = dr_x.VA1_NOTPAID_TAXED;
            NOTPAID_NOSAI = dr_x.VA1_NOTPAID_NOSAI;
            NOTPAID_NOTTAXED = dr_x.VA1_NOTPAID_NOTTAXED;

            UNTAXED_MINIMUM = dr_x.VA1_UNTAXED_MINIMUM;
            IINEX_DEPENDANTS = dr_x.VA1_IINEX_DEPENDANTS;
            IINEX2 = dr_x.VA1_IINEX2;
            IINEX2_TP = dr_x.VA1_IINEX2_TP;
            DNSI = dr_x.VA1_DNSI;

            PFT = dr_x.VA1_PF_T;
            LIT = dr_x.VA1_LI_T;
            HIT = dr_x.VA1_HI_T;
            PFNT = dr_x.VA1_PF_NT;
            LINT = dr_x.VA1_LI_NT;
            HINT = dr_x.VA1_HI_NT;

            IINEX_EXP = dr_x.VA1_IINEX_EXP;
            IIN = dr_x.VA1_IIN;
            CASH = dr_x.VA1_PAY;

        }

        public void SetFromA2(KlonsARepDataSet.SP_PAY_MATCHLISTS_1XRow dr_x)
        {
            ID_P = dr_x.IsIDPNull() ? (int?)null : dr_x.IDP;
            ID_AM = dr_x.IDAM;
            ID_SHR = dr_x.IDSHR1;

            DT1 = dr_x.VA_SHEET_DT1;
            DT2 = dr_x.VA_SHEET_DT2;

            IIN_RATE = dr_x.VA_IIN_RATE;
            IIN_RATE2 = dr_x.VA_IIN_RATE2;
            SI_RATE = dr_x.VA_SI_RATE;

            PAY_TAXED = dr_x.VA2_PAY_TAXED;
            PAY_NOSAI = dr_x.VA2_PAY_NOSAI;
            PAY_NOTTAXED = dr_x.VA2_PAY_NOTTAXED;

            UNTAXED_MINIMUM = dr_x.VA2_UNTAXED_MINIMUM;
            IINEX_DEPENDANTS = dr_x.VA2_IINEX_DEPENDANTS;
            IINEX2 = dr_x.VA2_IINEX2;
            IINEX2_TP = dr_x.VA1_IINEX2_TP;
            DNSI = dr_x.VA2_DNSI;

            PFNT = dr_x.VA2_PF_NT;
            LINT = dr_x.VA2_LI_NT;
            HINT = dr_x.VA2_HI_NT;

            IINEX_EXP = dr_x.VA2_IINEX_EXP;
            IIN = dr_x.VA2_IIN;
            CASH = dr_x.VA2_PAY;

        }
        public void SetFromB1(KlonsARepDataSet.SP_PAY_MATCHLISTS_1XRow dr_x)
        {
            ID_P = dr_x.IsIDPNull() ? (int?)null : dr_x.IDP;
            ID_AM = dr_x.IDAM;
            ID_SHR = dr_x.IDSHR2;

            DT1 = dr_x.VB_SHEET_DT1;
            DT2 = dr_x.VB_SHEET_DT2;

            IIN_RATE = dr_x.VB_IIN_RATE;
            IIN_RATE2 = dr_x.VB_IIN_RATE2;
            SI_RATE = dr_x.VB_SI_RATE;

            PAY_TAXED = dr_x.VB1_PAY_TAXED;
            PAY_NOSAI = dr_x.VB1_PAY_NOSAI;
            PAY_NOTTAXED = dr_x.VB1_PAY_NOTTAXED;
            NOTPAID_TAXED = dr_x.VB1_NOTPAID_TAXED;
            NOTPAID_NOSAI = dr_x.VB1_NOTPAID_NOSAI;
            NOTPAID_NOTTAXED = dr_x.VB1_NOTPAID_NOTTAXED;

            UNTAXED_MINIMUM = dr_x.VB1_UNTAXED_MINIMUM;
            IINEX_DEPENDANTS = dr_x.VB1_IINEX_DEPENDANTS;
            IINEX2 = dr_x.VB1_IINEX2;
            IINEX2_TP = dr_x.VB1_IINEX2_TP;
            DNSI = dr_x.VB1_DNSI;

            PFT = dr_x.VB1_PF_T;
            LIT = dr_x.VB1_LI_T;
            HIT = dr_x.VB1_HI_T;
            PFNT = dr_x.VB1_PF_NT;
            LINT = dr_x.VB1_LI_NT;
            HINT = dr_x.VB1_HI_NT;

            IINEX_EXP = dr_x.VB1_IINEX_EXP;
            IIN = dr_x.VB1_IIN;
            CASH = dr_x.VB1_PAY;
        }

        public void SetFromB2(KlonsARepDataSet.SP_PAY_MATCHLISTS_1XRow dr_x)
        {
            ID_P = dr_x.IsIDPNull() ? (int?)null : dr_x.IDP;
            ID_AM = dr_x.IDAM;
            ID_SHR = dr_x.IDSHR2;

            DT1 = dr_x.VB_SHEET_DT1;
            DT2 = dr_x.VB_SHEET_DT2;

            IIN_RATE = dr_x.VB_IIN_RATE;
            IIN_RATE2 = dr_x.VB_IIN_RATE2;
            SI_RATE = dr_x.VB_SI_RATE;

            PAY_TAXED = dr_x.VB2_PAY_TAXED;
            PAY_NOSAI = dr_x.VB2_PAY_NOSAI;
            PAY_NOTTAXED = dr_x.VB2_PAY_NOTTAXED;
            UNTAXED_MINIMUM = dr_x.VB2_UNTAXED_MINIMUM;
            IINEX_DEPENDANTS = dr_x.VB2_IINEX_DEPENDANTS;
            IINEX2 = dr_x.VB2_IINEX2;
            IINEX2_TP = dr_x.VB1_IINEX2_TP;
            DNSI = dr_x.VB2_DNSI;

            PFNT = dr_x.VB2_PF_NT;
            LINT = dr_x.VB2_LI_NT;
            HINT = dr_x.VB2_HI_NT;

            IINEX_EXP = dr_x.VB2_IINEX_EXP;
            IIN = dr_x.VB2_IIN;
            CASH = dr_x.VB2_PAY;
        }

        public void SetFrom(KlonsARepDataSet.SP_PAY_MATCHLISTS_2XRow dr_x)
        {
            ID_SHR = dr_x.ID_SHR;

            DT1 = dr_x.DT1;
            DT2 = dr_x.DT2;

            IIN_RATE = dr_x.IIN_RATE;
            IIN_RATE2 = dr_x.IIN_RATE2;
            SI_RATE = dr_x.SI_RATE;

            PAY_TAXED = dr_x.PAY_TAXED;
            PAY_NOSAI = dr_x.PAY_NOSAI;
            PAY_NOTTAXED = dr_x.PAY_NOTTAXED;
            NOTPAID_TAXED = dr_x.NOTPAID_TAXED;
            NOTPAID_NOSAI = dr_x.NOTPAID_NOSAI;
            NOTPAID_NOTTAXED = dr_x.NOTPAID_NOTTAXED;

            UNTAXED_MINIMUM = dr_x.UNTAXED_MINIMUM;
            IINEX_DEPENDANTS = dr_x.IINEX_DEPENDANTS;
            IINEX2 = dr_x.IINEX2;
            IINEX2_TP = dr_x.IINEX2_TP;
            DNSI = dr_x.DNSI;

            PFT = dr_x.PF_T;
            LIT = dr_x.LI_T;
            HIT = dr_x.HI_T;
            PFNT = dr_x.PF_NT;
            LINT = dr_x.LI_NT;
            HINT = dr_x.HI_NT;

            IINEX_EXP = dr_x.IINEX_EXP;
            IIN = dr_x.IIN;
            CASH = dr_x.PAY;
        }

        public void WriteTo1(KlonsADataSet.PAYLISTS_RRow dr)
        {
            if ((dr.IsID_SHR_1Null() ? (int?)null : dr.ID_SHR_1) == ID_SHR &&
                dr.PAY_TAXED_1 == PAY_TAXED &&
                dr.PAY_NOSAI_1 == PAY_NOSAI &&
                dr.PAY_NOTTAXED_1 == PAY_NOTTAXED &&
                dr.UNTAXED_MINIMUM_1 == UNTAXED_MINIMUM &&
                dr.IINEX_DEPENDANTS_1 == IINEX_DEPENDANTS &&
                dr.IINEX2_1 == IINEX2 &&
                dr.IINEX2_TP_1 == IINEX2_TP &&
                dr.DNSI_1 == DNSI &&
                dr.PFNT_1 == PFNT &&
                dr.LINT_1 == LINT &&
                dr.HINT_1 == HINT &&
                dr.IINEX_EXP_1 == IINEX_EXP &&
                dr.IIN_1 == IIN) return;

            dr.BeginEdit();

            if(ID_SHR == null)
                dr.SetID_SHR_1Null();
            else
                dr.ID_SHR_1 = ID_SHR.Value;
            dr.PAY_TAXED_1 = PAY_TAXED;
            dr.PAY_NOSAI_1 = PAY_NOSAI;
            dr.PAY_NOTTAXED_1 = PAY_NOTTAXED;
            dr.UNTAXED_MINIMUM_1 = UNTAXED_MINIMUM;
            dr.IINEX_DEPENDANTS_1 = IINEX_DEPENDANTS;
            dr.IINEX2_1 = IINEX2;
            dr.IINEX2_TP_1 = IINEX2_TP;
            dr.DNSI_1 = DNSI;
            dr.PFNT_1 = PFNT;
            dr.LINT_1 = LINT;
            dr.HINT_1 = HINT;
            dr.IINEX_EXP_1 = IINEX_EXP;
            dr.IIN_1 = IIN;

            dr.EndEdit();
        }

        public void WriteTo2(KlonsADataSet.PAYLISTS_RRow dr)
        {
            if ((dr.IsID_SHR_2Null()? (int?)null : dr.ID_SHR_2) == ID_SHR &&
                dr.PAY_TAXED_2 == PAY_TAXED &&
                dr.PAY_NOSAI_2 == PAY_NOSAI &&
                dr.PAY_NOTTAXED_2 == PAY_NOTTAXED &&
                dr.UNTAXED_MINIMUM_2 == UNTAXED_MINIMUM &&
                dr.IINEX_DEPENDANTS_2 == IINEX_DEPENDANTS &&
                dr.IINEX2_2 == IINEX2 &&
                dr.IINEX2_TP_2 == IINEX2_TP &&
                dr.DNSI_2 == DNSI &&
                dr.PFNT_2 == PFNT &&
                dr.LINT_2 == LINT &&
                dr.HINT_2 == HINT &&
                dr.IINEX_EXP_2 == IINEX_EXP &&
                dr.IIN_2 == IIN) return;

            dr.BeginEdit();

            if (ID_SHR == null)
                dr.SetID_SHR_2Null();
            else
                dr.ID_SHR_2 = ID_SHR.Value;
            dr.PAY_TAXED_2 = PAY_TAXED;
            dr.PAY_NOSAI_2 = PAY_NOSAI;
            dr.PAY_NOTTAXED_2 = PAY_NOTTAXED;
            dr.UNTAXED_MINIMUM_2 = UNTAXED_MINIMUM;
            dr.IINEX_DEPENDANTS_2 = IINEX_DEPENDANTS;
            dr.IINEX2_2 = IINEX2;
            dr.IINEX2_TP_2 = IINEX2_TP;
            dr.DNSI_2 = DNSI;
            dr.PFNT_2 = PFNT;
            dr.LINT_2 = LINT;
            dr.HINT_2 = HINT;
            dr.IINEX_EXP_2 = IINEX_EXP;
            dr.IIN_2 = IIN;

            dr.EndEdit();
        }

        public void SetTo(PayFx pfx, PayCalcRow fromsr)
        {
            pfx.Ir = IIN_RATE / 100.0M;
            pfx.Ir2 = IIN_RATE2 / 100.0M;
            pfx.Sr = SI_RATE / 100.0M;
            pfx.IM = PayFx.GetIINMargin(DT1);
            pfx.IMa = PayFx.GetIINMarginA(DT1);
            pfx.IMb = PayFx.GetIINMarginB(DT1);

            pfx.IinEx = 
                fromsr.UNTAXED_MINIMUM + 
                fromsr.IINEX_DEPENDANTS + 
                fromsr.IINEX2 + 
                fromsr.IINEX_EXP;

            pfx.UsedIinEx =
                UNTAXED_MINIMUM +
                IINEX_DEPENDANTS +
                IINEX2 +
                IINEX_EXP;

            pfx.HasProgressiveIIN = DT1 >= PayFx.ProgressiveIINStartDate;
            pfx.HasTaxDoc = fromsr.UNTAXED_MINIMUM > 0.0M;

            pfx.Pay = PAY_TAXED;
            pfx.PayNs = PAY_NOSAI;
            pfx.PayNt = PAY_NOTTAXED;

            pfx.DNS = DNSI;

            pfx.IIN = IIN;
            pfx.Cash = CASH;
        }

        public void SetTo(PayFx pfx)
        {
            pfx.Ir = IIN_RATE / 100.0M;
            pfx.Ir2 = IIN_RATE2 / 100.0M;
            pfx.Sr = SI_RATE / 100.0M;
            pfx.IM = PayFx.GetIINMargin(DT1);
            pfx.IMa = PayFx.GetIINMarginA(DT1);
            pfx.IMb = PayFx.GetIINMarginB(DT1);

            pfx.IinEx =
                UNTAXED_MINIMUM +
                IINEX_DEPENDANTS +
                IINEX2 +
                IINEX_EXP;

            pfx.UsedIinEx = pfx.IinEx;

            pfx.HasProgressiveIIN = DT1 >= PayFx.ProgressiveIINStartDate;
            pfx.HasTaxDoc = UNTAXED_MINIMUM > 0.0M;

            pfx.Pay = PAY_TAXED;
            pfx.PayNs = PAY_NOSAI;
            pfx.PayNt = PAY_NOTTAXED;

            pfx.DNS = DNSI;

            pfx.IIN = IIN;
            pfx.Cash = CASH;
        }

        public void SetFrom(PayFx pfx)
        {
            PAY_TAXED = pfx.Pay;
            PAY_NOSAI = pfx.PayNs;
            PAY_NOTTAXED = pfx.PayNt;

            DNSI = pfx.DNS;

            decimal d1 =
                UNTAXED_MINIMUM +
                IINEX_DEPENDANTS +
                IINEX2 +
                IINEX_EXP;

            if (pfx.IinEx > 0.0M && d1 > 0.0M)
            {
                decimal r = pfx.UsedIinEx / d1;
                UNTAXED_MINIMUM *= r;
                IINEX_DEPENDANTS *= r;
                IINEX2 *= r;
                IINEX_EXP *= r;
            }

            IIN = pfx.IIN;
            CASH = pfx.Cash;
        }

        public decimal RecalcCashNotPaid()
        {
            CASH_NOTPAID = 0.0M;
            if (NOTPAID_TAXED == 0.0M && NOTPAID_NOSAI == 0.0M && NOTPAID_NOTTAXED == 0.0M) return 0.0M;
            var pfx = new PayFx();
            SetTo(pfx);
            pfx.Pay = Math.Min(PAY_TAXED, NOTPAID_TAXED);
            pfx.PayNs = Math.Min(PAY_NOSAI, NOTPAID_NOSAI);
            pfx.PayNt = Math.Min(PAY_NOTTAXED, NOTPAID_NOTTAXED);
            pfx.CalcAll();
            CASH_NOTPAID = pfx.Cash;
            return CASH_NOTPAID;
        }

        public void RecalcA()
        {
            var pfx = new PayFx();
            SetTo(pfx);
            pfx.CalcAll();
            SetFrom(pfx);

            CASH_NOTPAID = 0.0M;
            if (NOTPAID_TAXED == 0.0M && NOTPAID_NOSAI == 0.0M && NOTPAID_NOTTAXED == 0.0M) return;

            pfx.Pay = Math.Min(PAY_TAXED, NOTPAID_TAXED);
            pfx.PayNs = Math.Min(PAY_NOSAI, NOTPAID_NOSAI);
            pfx.PayNt = Math.Min(PAY_NOTTAXED, NOTPAID_NOTTAXED);
            pfx.CalcAll();
            CASH_NOTPAID = pfx.Cash;
        }

        public void RecalcAndRound()
        {
            PAY_TAXED = KlonsData.RoundA(PAY_TAXED, 2);
            PAY_NOSAI = KlonsData.RoundA(PAY_NOSAI, 2);
            PAY_NOTTAXED = KlonsData.RoundA(PAY_NOTTAXED, 2);
            NOTPAID_TAXED = KlonsData.RoundA(NOTPAID_TAXED, 2);
            NOTPAID_NOSAI = KlonsData.RoundA(NOTPAID_NOSAI, 2);
            NOTPAID_NOTTAXED = KlonsData.RoundA(NOTPAID_NOTTAXED, 2);
            PFNT = KlonsData.RoundA(PFNT, 2);
            LIT = KlonsData.RoundA(LIT, 2);
            HIT = KlonsData.RoundA(HIT, 2);
            PFT = KlonsData.RoundA(PFT, 2);
            LINT = KlonsData.RoundA(LINT, 2);
            HINT = KlonsData.RoundA(HINT, 2);

            var pfx = new PayFx();
            SetTo(pfx);
            pfx.CalcAllAndRound();
            SetFrom(pfx);

            if (pfx.IinEx > 0.0M)
            {
                UNTAXED_MINIMUM = KlonsData.RoundA(UNTAXED_MINIMUM, 2);
                IINEX_DEPENDANTS = KlonsData.RoundA(IINEX_DEPENDANTS, 2);
                IINEX2 = KlonsData.RoundA(IINEX2, 2);
                IINEX_EXP = KlonsData.RoundA(IINEX_EXP, 2);
                var dd = new decimal[] { UNTAXED_MINIMUM, IINEX_DEPENDANTS, IINEX2, IINEX_EXP };
                PayFxA.MakeExactSum(pfx.UsedIinEx, dd);
                UNTAXED_MINIMUM = dd[0];
                IINEX_DEPENDANTS = dd[1];
                IINEX2 = dd[2];
                IINEX_EXP = dd[3];
            }

            CASH_NOTPAID = 0.0M;
            if (NOTPAID_TAXED == 0.0M && NOTPAID_NOSAI == 0.0M && NOTPAID_NOTTAXED == 0.0M) return;

            pfx.Pay = Math.Min(PAY_TAXED, NOTPAID_TAXED);
            pfx.PayNs = Math.Min(PAY_NOSAI, NOTPAID_NOSAI);
            pfx.PayNt = Math.Min(PAY_NOTTAXED, NOTPAID_NOTTAXED);
            pfx.CalcAllAndRound();
            CASH_NOTPAID = pfx.Cash;
        }

    }

}
