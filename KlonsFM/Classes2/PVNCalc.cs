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

namespace KlonsFM.Classes
{
    public static class PVNCalc
    {
        public static DocAccData GetPVNData(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var ret = new DocAccData();
            ret.ReadRowData(dr_doc, true);
            if (ret.Err.HasErrors) return ret;
            ret.GetPVNData(dr_doc);
            ret.GetAccData(dr_doc);
            return ret;
        }

    }

    public class RowPVNAndAccData
    {
        public int IdRow = 0;
        public decimal PVNBase = 0M;
        public bool IsReversePVN = false;
        public string PVNRateCode = null;
        public string PVNRateName = null;
        public decimal PVNRate = 0M;

        public readonly AccDebCred AccBase = new AccDebCred();
        public readonly AccDebCred AccPVN = new AccDebCred();

        public EPVNType PVNType = EPVNType.Nenoteikts;
        public bool IsCreditDocInTheSameMonth = false;
        public bool ChangeSign = false;

        public string ReadFrom(KlonsMDataSet.M_ROWSRow dr_row, bool readacc)
        {
            var dr_doc = dr_row.M_DOCSRow;
            var dr_pvnrate = dr_row.M_PVNRATESRow;
            IdRow = dr_row.ID;
            PVNBase = dr_row.TPRICE;
            PVNRateCode = dr_pvnrate.CODE;
            PVNRateName = dr_pvnrate.NAME;
            PVNRate = dr_pvnrate.RATE;
            IsReversePVN = dr_pvnrate.ISREVERSE == 1;
            PVNType = dr_doc.XPVNType;
            IsCreditDocInTheSameMonth = false;

            ClearAcc();
            if (!readacc) return "OK";

            if (dr_doc.XDocType == EDocType.Sākuma_atlikums)
            {

            }
            if (dr_doc.XDocType == EDocType.Pārvietots)
            {
                AccBase.DebFin = dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREIN1.ACC21;
                AccBase.CredFin = dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREOUT1.ACC21;
            }
            else if (dr_doc.XDocType == EDocType.Norakstīts ||
                dr_doc.XDocType == EDocType.Pierakstīts)
            {
                AccBase.DebFin = dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREIN1.ACC21;
                AccBase.CredFin = dr_doc.M_STORESRowByFK_M_DOCS_IDSTOREOUT1.ACC21;
            }
            else
            {
                var table_pvnrates2 = KlonsData.St.DataSetKlonsM.M_PVNRATES2;
                var doctp = dr_row.M_DOCSRow.XDocType;
                IsCreditDocInTheSameMonth = SomeDataDefs.IsCreditDocInTheSameMonth(dr_doc);

                var dr_pvnrate2 = table_pvnrates2
                    .WhereX(x =>
                        x.IDRATE == dr_row.IDPVNRATE &&
                        x.XPvnType == PVNType &&
                        x.XDocType == doctp &&
                        !x.XInCurrentMonth)
                    .FirstOrDefault();

                if (IsCreditDocInTheSameMonth)
                {
                    var dr_pvnrate2a = table_pvnrates2
                        .WhereX(x =>
                            x.IDRATE == dr_row.IDPVNRATE &&
                            x.XPvnType == PVNType &&
                            x.XDocType == doctp &&
                            x.XInCurrentMonth)
                        .FirstOrDefault();
                    if (dr_pvnrate2a != null)
                        dr_pvnrate2 = dr_pvnrate2a;
                }

                if (dr_pvnrate2 == null)
                {
                    var pvntypecode = KlonsData.St.DataSetKlonsM.M_PVNTYPE.FindByID(dr_row.M_DOCSRow.PVNTYPE).CODE;
                    var ret = $"Nav izveidots kontējuma shēma priekš:\n";
                    ret += $"Likme: {PVNRateCode}\n";
                    ret += $"PVN režīms: {pvntypecode}\n";
                    ret += $"Darijuma veids: {dr_row.M_DOCSRow.M_DOCTYPESRow.CODE}";
                    return ret;
                }

                ChangeSign = dr_pvnrate2.XChangeSign;

                bool are_we_vat_payer = !KlonsData.St.Params.CompRegNrPVN.IsNOE();

                AccBase.DebFin = SomeDataDefs.GetAccT(dr_row, dr_pvnrate2.XBaseDebFin);
                AccBase.CredFin = SomeDataDefs.GetAccT(dr_row, dr_pvnrate2.XBaseCredFin);

                if (are_we_vat_payer)
                {
                    AccBase.DebPVN = dr_pvnrate2.BASE_DEB_PVN;
                    AccBase.CredPVN = dr_pvnrate2.BASE_CRED_PVN;
                    AccBase.Text = GetBaseText(dr_pvnrate2);

                    AccPVN.DebFin = SomeDataDefs.GetAccT(dr_row, dr_pvnrate2.XPvnDebFin);
                    AccPVN.DebPVN = dr_pvnrate2.PVN_DEB_PVN;
                    AccPVN.CredFin = SomeDataDefs.GetAccT(dr_row, dr_pvnrate2.XPvnCredFin);
                    AccPVN.CredPVN = dr_pvnrate2.PVN_CRED_PVN;
                    AccPVN.Text = GetPVNText(dr_pvnrate2);
                }
            }

            if (!AccBase.IsGood() || !AccPVN.IsGood())
            {
                var ret = "Noliktavai vai artikulu kategorijai ir nenoteikts kontējuma konts:\n";
                ret += $"Artikulu kategorija: {dr_row.M_ITEMSRow.M_ITEMS_CATRow.CODE}";
                return ret;
            }

            return "OK";
        }

        public static string GetBaseText(KlonsMDataSet.M_PVNRATES2Row dr_pvnrates2)
        {
            if (dr_pvnrates2.IsIDPVNTEXTNull()) return null;
            int id = dr_pvnrates2.IDPVNTEXT;
            return KlonsData.St.DataSetKlonsM.M_PVNTEXTS.FindByID(id)?.TAG1;
        }

        public static string GetPVNText(KlonsMDataSet.M_PVNRATES2Row dr_pvnrates2)
        {
            if (dr_pvnrates2.IsIDPVNTEXTNull()) return null;
            int id = dr_pvnrates2.IDPVNTEXT;
            return KlonsData.St.DataSetKlonsM.M_PVNTEXTS.FindByID(id)?.TAG2;
        }

        public void ClearAcc()
        {
            AccBase.Clear();
            AccPVN.Clear();
        }

    }

    public class AccDebCred
    {
        public string DebFin = null;
        public string DebPVN = null;
        public string CredFin = null;
        public string CredPVN = null;
        public string Text = null;

        public void Clear()
        {
            DebFin = null;
            DebPVN = null;
            CredFin = null;
            CredPVN = null;
            Text = null;
        }

        public bool IsGood()
        {
            if(DebFin == "?" || DebFin == ".?" ||
                CredFin == "?" || CredFin == ".?")
                return false;
            if (DebFin == null && CredFin != null) return false;
            if (DebFin != null && CredFin == null) return false;
            return true;
        }

        public bool IsEmpty()
        {
            return (DebFin.IsNOE() || CredFin.IsNOE());
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is AccDebCred oacc)) return false;
            return DebFin == oacc.DebFin && DebPVN == oacc.DebPVN &&
                CredFin == oacc.CredFin && CredPVN == oacc.CredPVN &&
                Text == oacc.Text;
        }

        public override int GetHashCode()
        {
            return (DebFin, DebPVN, CredFin, CredPVN, Text).GetHashCode();
        }

        public AccDebCred Clone()
        {
            var ret = new AccDebCred()
            {
                DebFin = this.DebFin,
                DebPVN = this.DebPVN,
                CredFin = this.CredFin,
                CredPVN = this.CredPVN,
                Text = this.Text
            };
            return ret;
        }
    }

    public class DocPVNRateData
    {
        public string PVNRateCode = null;
        public string PVNRateName = null;
        public decimal PVNBase = 0M;
        public bool IsReversePVN = false;
        public decimal PVNRate = 0M;
        public decimal PVN = 0M;
        public decimal ReversePVN = 0M;
        public string PVNBazeText = null;
        public string PVNText = null;
    }

    public class RowAccDataTotalA
    {
        public AccDebCred AccBase = null;
        public AccDebCred AccPVN = null;
        public decimal PVNBase = 0M;
        public decimal PVN = 0M;
        public decimal ReversePVN = 0M;
        public decimal PVNRate = 0M;
        public bool IsReverse = false;
        public bool ChangeSign = false;

        public bool EqualsA(RowAccDataTotalA racc)
        {
            if (PVNRate != racc.PVNRate) return false;
            if (IsReverse != racc.IsReverse) return false;
            if (AccBase != racc.AccBase) return false;
            if (AccPVN != racc.AccPVN) return false;
            if (ChangeSign != racc.ChangeSign) return false;
            return true;
        }

        public RowAccDataTotalA CloneA()
        {
            var ret = new RowAccDataTotalA()
            {
                AccBase = this.AccBase.Clone(),
                AccPVN = this.AccPVN.Clone(),
                PVNRate = this.PVNRate,
                IsReverse = this.IsReverse,
                ChangeSign = this.ChangeSign
            };
            return ret;
        }

        public RowAccDataTotalB[] Split(bool changesign)
        {
            var acc1 = new RowAccDataTotalB()
            {
                Acc = AccBase,
                Amount = changesign ? -PVNBase : PVNBase,
                Tp = 0
            };
            var acc2 = new RowAccDataTotalB()
            {
                Acc = AccPVN,
                Amount = changesign ? -PVN : PVN,
                Tp = 1
            };
            return new[] { acc1, acc2 };
        }
    }


    public class RowAccDataTotalB
    {
        public AccDebCred Acc = null;
        public decimal Amount = 0M;
        public int Tp = 0;

        public bool EqualsA(RowAccDataTotalB racc)
        {
            if (Acc != racc.Acc) return false;
            return true;
        }

        public RowAccDataTotalB CloneA()
        {
            var ret = new RowAccDataTotalB()
            {
                Acc = this.Acc.Clone()
            };
            return ret;
        }
    }

    public class TotalPVNData
    {
        public string Text = null;
        public decimal Amount = 0M;
        public int Tp = 0;

        public bool EqualsA(TotalPVNData tpd)
        {
            if (Text != tpd.Text) return false;
            return true;
        }

        public TotalPVNData CloneA()
        {
            var ret = new TotalPVNData()
            {
                Text = this.Text,
                Amount = this.Amount,
                Tp = this.Tp
            };
            return ret;
        }
    }

    public class DocAccData
    {
        public readonly ErrorList Err = new ErrorList();
        public List<RowPVNAndAccData> RowPVNData;
        public List<RowAccDataTotalA> RowAccDataTotalA;
        public List<RowAccDataTotalB> RowAccDataTotalB;
        public List<DocPVNRateData> DocPVNTypeData;
        public List<TotalPVNData> TotalPVNData;
        public decimal PVNBase = 0M;
        public decimal PVN = 0M;
        public decimal ReversePVN = 0M;
        public EPVNType PVNType = EPVNType.Nenoteikts;
        public bool IsCreditDocInTheSameMonth = false;

        public decimal SumPVNRows()
        {
            if (RowAccDataTotalB == null || RowAccDataTotalB.Count == 0) return 0M;
            var pvn = RowAccDataTotalB
                .Where(x => x.Tp == 1)
                .Sum(x => x.Amount);
            return pvn;
        }

        public bool ReadRowData(KlonsMDataSet.M_DOCSRow dr_doc, bool readacc)
        {
            Err.Clear();
            RowPVNData = new List<RowPVNAndAccData>();
            DocPVNTypeData = new List<DocPVNRateData>();
            RowAccDataTotalA = new List<RowAccDataTotalA>();
            RowAccDataTotalB = new List<RowAccDataTotalB>();
            var pvntype = dr_doc.XPVNType;
            PVNType = pvntype;
            IsCreditDocInTheSameMonth = SomeDataDefs.IsCreditDocInTheSameMonth(dr_doc);

            var drs_rows = dr_doc.GetM_ROWSRows().ToList();
            if (drs_rows.Count == 0)
            {
                Err.AddError("", "Dokumentam nav ierakstu.");
                return false;
            }
            foreach (var dr_row in drs_rows)
            {
                var pvndata = new RowPVNAndAccData();
                var rt = pvndata.ReadFrom(dr_row, readacc);
                if (rt != "OK")
                    Err.AddError("", rt);
                else
                    RowPVNData.Add(pvndata);
            }
            return true;
        }

        public void GetPVNData(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            PVNBase = 0M;
            PVN = 0M;
            ReversePVN = 0M;
            DocPVNTypeData = new List<DocPVNRateData>();

            if (RowPVNData == null || RowPVNData.Count == 0)
            {
                //throw new Exception("No row data.");
                return;
            }
                
            if (PVNType == EPVNType.Nenoteikts) return;

            var grps_rateid = RowPVNData
                .GroupBy(x => x.PVNRateCode)
                .ToList();
            foreach (var grp_rateid in grps_rateid)
            {
                var row_first = grp_rateid.First();
                var docpvndata = new DocPVNRateData()
                {
                    PVNRateCode = row_first.PVNRateCode,
                    PVNRateName = row_first.PVNRateName,
                    IsReversePVN = row_first.IsReversePVN,
                    PVNRate = row_first.PVNRate,
                    PVNBase = grp_rateid.Sum(x => x.PVNBase)
                };

                decimal pvn = Math.Round(docpvndata.PVNBase * docpvndata.PVNRate / 100M, 4);

                if (docpvndata.IsReversePVN)
                    docpvndata.ReversePVN = pvn;
                else
                    docpvndata.PVN = pvn;

                PVNBase += docpvndata.PVNBase;
                PVN += docpvndata.PVN;
                ReversePVN += docpvndata.ReversePVN;

                DocPVNTypeData.Add(docpvndata);
            }

        }

        public void GetAccData(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            PVNBase = 0M;
            PVN = 0M;
            //ReversePVN = 0M; - not changin this
            RowAccDataTotalA = new List<RowAccDataTotalA>();
            RowAccDataTotalB = new List<RowAccDataTotalB>();
            TotalPVNData = new List<TotalPVNData>();

            if (RowPVNData == null || RowPVNData.Count == 0)
            {
                //throw new Exception("No row data.");
                return;
            }

            if (PVNType == EPVNType.Nenoteikts) return;

            var grps_acc = RowPVNData
                .GroupBy(x => (x.PVNRate, x.IsReversePVN, x.AccBase, x.AccPVN, x.ChangeSign))
                .ToList();
            foreach (var grp_acc in grps_acc)
            {
                var accdata = new RowAccDataTotalA()
                {
                    IsReverse = grp_acc.Key.IsReversePVN,
                    PVNRate = grp_acc.Key.PVNRate,
                    AccBase = grp_acc.Key.AccBase.Clone(),
                    AccPVN = grp_acc.Key.AccPVN.Clone(),
                    PVNBase = grp_acc.Sum(x => x.PVNBase),
                    ChangeSign = grp_acc.Key.ChangeSign
                };

                decimal pvn = accdata.PVNBase * accdata.PVNRate / 100M;

                if (accdata.IsReverse)
                    accdata.ReversePVN = pvn;
                else
                    accdata.PVN = pvn;

                PVNBase += accdata.PVNBase;

                RowAccDataTotalA.Add(accdata);
            }

            RowAccDataTotalB = RowAccDataTotalA
                .SelectMany(x => x.Split(x.ChangeSign))
                .Where(x => !x.Acc.IsEmpty() && x.Amount != 0M)
                .GroupBy(x => x.Acc)
                .Select(x => new RowAccDataTotalB()
                {
                    Acc = x.Key,
                    Amount = Math.Round(x.Sum(y => y.Amount), 2),
                    Tp = x.First().Tp
                })
                .OrderBy(x => x.Tp)
                .ToList();


            TotalPVNData = RowAccDataTotalA
                .SelectMany(x => x.Split(false))
                .Where(x => !x.Acc.IsEmpty() && x.Amount != 0M)
                .GroupBy(x => x.Acc)
                .Select(x => new RowAccDataTotalB()
                {
                    Acc = x.Key,
                    Amount = Math.Round(x.Sum(y => y.Amount), 2),
                    Tp = x.First().Tp
                })
                .GroupBy(x => x.Acc.Text)
                .Select(x => new TotalPVNData()
                {
                    Text = x.Key,
                    Amount = x.Sum(y => y.Amount),
                    Tp = x.First().Tp
                })
                .OrderBy(x => x.Tp)
                .ToList();

            PVN = TotalPVNData
                .Where(x => x.Tp == 1)
                .Sum(x => x.Amount);

            TotalPVNData.Add(new TotalPVNData()
            {
                Text = "KOPĀ",
                Amount = PVNBase + PVN,
                Tp = 3
            });
        }
    }
}
