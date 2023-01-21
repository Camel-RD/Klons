using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.DataSets;
using KlonsFM.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Data;
using KlonsLIB.Misc;
using KlonsFM.UI;
using KlonsLIB.Components;

namespace KlonsFM.FormsM
{
    public partial class FormM_DocFin : MyFormBaseF
    {
        public FormM_DocFin()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvRepByPVNRate.AutoGenerateColumns = false;
            dgvAcc.AutoGenerateColumns = false;
            dgvRepByPVNRate.DisableAllColumnSorting();
            dgvAcc.DisableAllColumnSorting();
        }

        private void FormM_DocFin_Load(object sender, EventArgs e)
        {
            GetData();
            bsRepByPVNRate.DataSource = DocPVNRateRepRows;
            bsAccRows.DataSource = DocAccRepRows;
        }

        public int IdDoc;
        public List<DocPVNRateRepRow> DocPVNRateRepRows = new List<DocPVNRateRepRow>();
        public List<DocAccRepRow> DocAccRepRows = new List<DocAccRepRow>();
        public DocAccData DocFinData = null;

        public static void ShowDialog(int iddoc)
        {
            var fm = new FormM_DocFin();
            fm.IdDoc = iddoc;
            fm.ShowDialog();
        }

        public void GetData()
        {
            var dr_doc = MyData.DataSetKlonsM.M_DOCS.FindByID(IdDoc);
            if(dr_doc == null)
            {
                Close();
                return;
            }
            var pvndata = PVNCalc.GetPVNData(dr_doc);
            if (pvndata.Err.HasErrors)
            {
                FormM_ErrorList.ShowErrorList(this, pvndata.Err);
                return;
            }
            DocFinData = pvndata;
            DocPVNRateRepRows = new List<DocPVNRateRepRow>();
            DocAccRepRows = new List<DocAccRepRow>();
            var totalreprow = new DocPVNRateRepRow()
            {
                PVNRateId = "Kopā"
            };
            foreach (var x in pvndata.DocPVNTypeData)
            {
                var reprow = new DocPVNRateRepRow();
                reprow.SetFrom(x);
                DocPVNRateRepRows.Add(reprow);
                totalreprow.PVNBaze += reprow.PVNBaze;
                totalreprow.PVN += reprow.PVN;
                totalreprow.Total += reprow.Total;
                totalreprow.ReversePVN += reprow.ReversePVN;
            }
            DocPVNRateRepRows.Add(totalreprow);
            foreach(var x in pvndata.RowAccDataTotalB)
            {
                var reprow = new DocAccRepRow();
                reprow.SetFrom(x);
                DocAccRepRows.Add(reprow);
            }
        }

        public bool SaveDataF()
        {
            //if (!dgvAcc.EndEditX()) return false;

            if (!this.Validate()) return false;
            try
            {
                //DataTasks.SetNewIDs(admFinDoc);
                return admFinDoc.UpdateAll();
            }
            catch (Exception e)
            {
                Form_Error.ShowException(e, "Neizdevās saglabāt izmaiņas.");
                return false;
            }
        }

        public bool SaveDataM()
        {
            //if (!dgvAcc.EndEditX()) return false;

            if (!this.Validate()) return false;
            try
            {
                DataTasks.SetNewIDs(admStore);
                admStore.UpdateAll();
            }
            catch (Exception e)
            {
                Form_Error.ShowException(e, "Neizdevās saglabāt izmaiņas.");
                return false;
            }
            return true;
        }


        public int GetPartnerId(int iddoc)
        {
            var dr_doc = MyData.DataSetKlonsM.M_DOCS.FindByID(iddoc);
            if (SomeDataDefs.IsStorePartner(dr_doc.XStoreOutType))
                return dr_doc.IDSTOREOUT;
            else
                return dr_doc.IDSTOREIN;
        }

        public string[] GetAccFinList()
        {
            var ret = DocAccRepRows.Select(x => x.DebFin)
                .Union(DocAccRepRows.Select(x => x.CredFin))
                .ToArray();
            return ret;
        }

        public string[] GetAccPVNList()
        {
            var ret = DocAccRepRows.Select(x => x.DebPVN)
                .Union(DocAccRepRows.Select(x => x.CredPVN))
                .Where(x => !x.IsNOE())
                .ToArray();
            return ret;
        }

        public string TestAccFin(string[] accs)
        {
            var missingacc = new List<string>();
            foreach(var acc in accs)
            {
                var table_accplan = MyData.DataSetKlons.AcP21;
                if (table_accplan.FindByAC(acc) != null) continue;
                missingacc.Add(acc);
            }
            if (missingacc.Count == 0) return "OK";
            var ret = string.Join(", ", missingacc);
            ret = "Šie konti nav kontu plānā:\n" + ret;
            return ret;
        }

        public string TestAccPVN(string[] accs)
        {
            var missingacc = new List<string>();
            foreach (var acc in accs)
            {
                var table_accplan = MyData.DataSetKlons.Acp25;
                if (table_accplan.FindByidx(acc) != null) continue;
                missingacc.Add(acc);
            }
            if (missingacc.Count == 0) return "OK";
            var ret = string.Join(", ", missingacc);
            ret = "Šie PVN kods nav kodu sarakstā:\n" + ret;
            return ret;
        }
        
        public string GetPartnerCode(int iddoc)
        {
            int idpartner = GetPartnerId(iddoc);
            string clid = MyData.DataSetKlonsM.M_STORES.FindByID(idpartner).CODE;
            return clid;
        }

        public string TestPartnerCode(int iddoc)
        {
            string clid = GetPartnerCode(iddoc);
            if (MyData.DataSetKlons.Persons.FindByClId(clid) == null)
                return $"Personu sarakstā nav personas ar kodu {clid}";
            return "OK";
        }

        public void DoDeleteFinDocA(int iddocm)
        {
            DataTasks.DetachFinDocByIdDocM(IdDoc);
            MyData.KlonsMQueriesTableAdapter.SP_M_DEL_FINDOC(iddocm);
        }

        public string GetDocTypeCode(int iddoc)
        {
            var dr_doc = MyData.DataSetKlonsM.M_DOCS.FindByID(iddoc);
            switch (dr_doc.XDocType)
            {
                case EDocType.Nenoteikts: return null;
                case EDocType.Iepirkums:
                    return "PPRks";
                case EDocType.Realizācija:
                    return "PPRdi";
                case EDocType.Atgriezts_piegādātājam:
                case EDocType.Atgriezts_no_pircēja:
                case EDocType.No_noliktavas:
                case EDocType.Uz_noliktavu:
                    return "PPR";
                case EDocType.Kredītrēķins_no_piegādātāja:
                case EDocType.Kredītrēķins_pircējam:
                    return "Kr.rēķ.";
                case EDocType.Pārvietots:
                    return "IPP";
                case EDocType.Sākuma_atlikums:
                case EDocType.Norakstīts:
                case EDocType.Pierakstīts:
                case EDocType.Izlietots:
                case EDocType.Saražots:
                    return "Akts";
                case EDocType.Saņemti_pakalpojumi:
                case EDocType.Sniegti_pakalpojumi:
                    return "Rēķ";
            }
            return null;
        }

        public string TestDocTypeCode(int iddoc)
        {
            var code = GetDocTypeCode(iddoc);
            var table = MyData.DataSetKlons.DocTyp;
            var dr = table.FindByid(code);
            if (dr != null) return "OK";
            var ret = $"Dokumentu veidu saraksts nesatur ierakstu ar kodu {code}";
            return ret;
        }

        public string GetDocDescription(int iddoc)
        {
            var dr_doc = MyData.DataSetKlonsM.M_DOCS.FindByID(iddoc);
            var descr = dr_doc.M_TRANSACTIONTYPERow.NAME;
            if (!descr.IsNOE() && descr != "?" && descr != ".?") return descr.ToLower();
            var dr_doctype = dr_doc.M_DOCTYPESRow;
            descr = dr_doctype.NAME?.ToLower();
            return descr;
        }

        public ErrorList CanDoAccounting(int iddoc)
        {
            var ret = new ErrorList();
            var dr_doc = MyData.DataSetKlonsM.M_DOCS.FindByID(iddoc);

            if (dr_doc.XState == EDocState.Iekontēts)
            {
                ret.AddError("", "Dokuments jau ir iekontēts.");
                return ret;
            }

            if (dr_doc.XState != EDocState.Iegrāmatots)
            {
                ret.AddError("", "Dokuments nav iegrāmatots.");
                return ret;
            }

            if (!SomeDataDefs.AutoMakeFinOps(dr_doc.XDocType))
            {
                ret.AddError("", "Šim dokumenta veidam netiek veidots automātisks kontējums.\n"+
                    "Kontēšana jāveic par mēneša kopsavilkumam.");
                return ret;
            }

            var table_fdocs = MyData.DataSetKlons.OPSd;
            var table_frows = MyData.DataSetKlons.OPS;
            if (table_fdocs.HasChanges() || table_frows.HasChanges())
                ret.AddError("", "Ir nesaglabātas izmaiņas finanšu grāmatvedības dokumentos.");

            var err = TestPartnerCode(iddoc);
            if (err != "OK") ret.AddError("", err);

            var accfin = GetAccFinList();
            err = TestAccFin(accfin);
            if (err != "OK") ret.AddError("", err);

            var accpvn = GetAccPVNList();
            err = TestAccPVN(accpvn);
            if (err != "OK") ret.AddError("", err);

            err = TestDocTypeCode(iddoc);
            if (err != "OK") ret.AddError("", err);

            return ret;
        }

        public void SetDocIekontēts(int iddoc, bool hasautofinops)
        {
            var dr_doc = MyData.DataSetKlonsM.M_DOCS.FindByID(iddoc);
            dr_doc.XState = EDocState.Iekontēts;
            dr_doc.XDoAutoFinOps = hasautofinops;
        }

        public void ClearDocIekontēts(int iddoc)
        {
            var dr_doc = MyData.DataSetKlonsM.M_DOCS.FindByID(iddoc);
            dr_doc.XState = EDocState.Iegrāmatots;
            dr_doc.XDoAutoFinOps = false;
        }

        public void DoAccountingA(int iddoc)
        {
            if (DocAccRepRows.Count == 0)
            {
                MyMainForm.ShowWarning("Nav kontējuma ierakstu.");
                return;
            }

            var dr_doc = MyData.DataSetKlonsM.M_DOCS.FindByID(iddoc);

            var table_fdocs = MyData.DataSetKlons.OPSd;
            var table_frows = MyData.DataSetKlons.OPS;

            var dr_fdoc = table_fdocs.NewOPSdRow();
            dr_fdoc.id = (int)MyData.KlonsQueriesTableAdapter.SP_OPSD_ID();
            dr_fdoc.Dete = dr_doc.DT;
            dr_fdoc.ZNR = (int)MyData.KlonsQueriesTableAdapter.SP_OPSD_GETNEXTNRFORYEARA(dr_fdoc.Dete.Year);
            dr_fdoc.ZU = MyData.CurrentUserName;
            dr_fdoc.ZDt = DateTime.Now;
            dr_fdoc.DocTyp = GetDocTypeCode(iddoc);
            dr_fdoc.DocSt = dr_doc.SR;
            dr_fdoc.DocNr = dr_doc.NR;
            dr_fdoc.ClId = GetPartnerCode(iddoc);
            dr_fdoc.Descr = GetDocDescription(iddoc);
            dr_fdoc.Summ = DocFinData.PVNBase + DocFinData.PVN;
            dr_fdoc.PVN = DocFinData.SumPVNRows();
            table_fdocs.Rows.Add(dr_fdoc);
            foreach(var accdata in DocAccRepRows)
            {
                var dr_frow = table_frows.NewOPSRow();
                dr_frow.id = (int)MyData.KlonsQueriesTableAdapter.SP_OPS_ID();
                dr_frow.DocId = dr_fdoc.id;
                dr_frow.ZDt = DateTime.Now;
                dr_frow.AC11 = accdata.DebFin;
                dr_frow.AC15 = accdata.DebPVN;
                dr_frow.AC21 = accdata.CredFin;
                dr_frow.AC25 = accdata.CredPVN;
                dr_frow.Summ = accdata.Amount;
                dr_frow.SummC = accdata.Amount;
                dr_frow.Cur = "EUR";
                table_frows.Rows.Add(dr_frow);
            }

        }

        public bool DoAccounting()
        {
            var err = CanDoAccounting(IdDoc);
            if (err.HasErrors)
            {
                FormM_ErrorList.ShowErrorList(this, err);
                return false;
            }
            DoDeleteFinDocA(IdDoc);
            DoAccountingA(IdDoc);
            bool rt = SaveDataF();
            if (!rt)
            {
                DoDeleteFinDocA(IdDoc);
                return false;
            }
            SetDocIekontēts(IdDoc, true);
            SaveDataM();
            return true;
        }

        public void DoUseManualAccounting()
        {
            var dr_doc = MyData.DataSetKlonsM.M_DOCS.FindByID(IdDoc);

            if (dr_doc.XState == EDocState.Iekontēts)
            {
                MyMainForm.ShowWarning("Dokuments jau ir iekontēts.");
                return;
            }

            if (dr_doc.XState != EDocState.Iegrāmatots)
            {
                MyMainForm.ShowWarning("Dokuments nav iegrāmatots.");
                return;
            }

            if (DocAccRepRows.Count == 0)
            {
                MyMainForm.ShowWarning("Nav kontējuma ierakstu.");
                return;
            }

            if (!SomeDataDefs.AutoMakeFinOps(dr_doc.XDocType))
            {
                MyMainForm.ShowWarning("Šim dokumenta veidam netiek veidots automātisks kontējums.\n" +
                    "Kontēšana jāveic par mēneša kopsavilkumam.");
                return;
            }

            SetDocIekontēts(IdDoc, false);
            SaveDataM();
        }

        public void DoClearAccounting()
        {
            var dr_doc = MyData.DataSetKlonsM.M_DOCS.FindByID(IdDoc);

            if (dr_doc.XState != EDocState.Iekontēts)
            {
                MyMainForm.ShowWarning("Dokuments nav kontēts.");
                return;
            }

            if (!SomeDataDefs.AutoMakeFinOps(dr_doc.XDocType))
            {
                MyMainForm.ShowWarning("Šim dokumenta veidam netiek veidots kontējums.\n" +
                    "Kontēšana jāveic par mēneša kopsavilkumam.");
                return;
            }

            if (!dr_doc.XDoAutoFinOps)
            {
                MyMainForm.ShowWarning("Dokumentā ir norādīts, ka tas izmanto manuālu kontējumu.\n"+
                    "Dokuments tiks atzīmēts kā neiekontēts\n"+
                    "bet grāmatvedim pašam ir jādzēs veiktie kontējumi.");
            }
            
            DoDeleteFinDocA(IdDoc);
            var rt = SaveDataF();
            if (!rt) return;
            ClearDocIekontēts(IdDoc);
            SaveDataM();
        }

        private void btMakeFinDoc_Click(object sender, EventArgs e)
        {
            DoAccounting();
            DialogResult = DialogResult.OK;
        }

        private void btDeleteFinDoc_Click(object sender, EventArgs e)
        {
            DoClearAccounting();
            DialogResult = DialogResult.OK;
        }

        private void btCustomFinDoc_Click(object sender, EventArgs e)
        {
            DoUseManualAccounting();
            DialogResult = DialogResult.OK;
        }
    }

    public class DocPVNRateRepRow
    {
        public string PVNRateId { get; set; } = null;
        public string PVNRateName { get; set; } = null;
        public bool IsReversePVN { get; set; } = false;
        public string SIsReversePVN  => IsReversePVN ? "✕" : "";
        public decimal PVNBaze { get; set; } = 0M;
        public decimal PVNRate { get; set; } = 0M;
        public decimal PVN { get; set; } = 0M;
        public decimal ReversePVN { get; set; } = 0M;
        public decimal Total { get; set; } = 0M;

        public void SetFrom(DocPVNRateData data)
        {
            PVNRateId = data.PVNRateCode;
            PVNRateName = data.PVNRateName;
            IsReversePVN = data.IsReversePVN;
            PVNBaze = data.PVNBase;
            PVNRate = data.PVNRate;
            PVN = data.PVN;
            ReversePVN = data.ReversePVN;
            Total = data.PVNBase + data.PVN;
        }
    }

    public class DocAccRepRow
    {
        public string DebFin { get; set; } = null;
        public string DebPVN { get; set; } = null;
        public string CredFin { get; set; } = null;
        public string CredPVN { get; set; } = null;
        public decimal Amount { get; set; } = 0M;

        public void SetFrom(RowAccDataTotalB data)
        {
            DebFin = data.Acc.DebFin;
            DebPVN = data.Acc.DebPVN;
            CredFin = data.Acc.CredFin;
            CredPVN = data.Acc.CredPVN;
            Amount = data.Amount;
        }
    }
}
