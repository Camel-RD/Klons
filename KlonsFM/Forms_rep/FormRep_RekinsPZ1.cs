using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.Classes;
using KlonsFM.DataSets;
using KlonsFM.UI;
using KlonsFM.DataSets.klonsDataSetTableAdapters;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsFM.FormsReportParams
{
    public partial class FormRep_RekinsPZ1 : MyFormBaseF
    {
        public FormRep_RekinsPZ1()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public FormRep_RekinsPZ1(int docid, int repid = 0)
        {
            InitializeComponent();
            CheckMyFontAndColors();
            this.docid = docid;
            this.repid = repid;
        }

        private int docid = -1;
        private int repid = -1;
        private string clid = null;
        private string parv = null;
        private string parvregnr = null;
        private string parvpvnregnr = null;
        private string parvjuradrese = null;

        private void FormRep_RekinsPZ1_Load(object sender, EventArgs e)
        {
            lbClName.Text = "";
            cbDarVeids.SelectedIndex = 0;
            cbApmaksa.SelectedIndex = 0;
            cbTermins.SelectedIndex = 0;
            LoadParams();
            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {cbClid},
                new Control[] {tbTLNumurs},
                new Control[] {tbTLVaditajs},
                new Control[] {cbDarVeids},
                new Control[] {cbApmaksa},
                new Control[] {cbTermins},
                new Control[] {tbSigner},
                new Control[] {cmDoIt}
            });
            MyData.DataSetKlonsRep.TRepOPSd.Clear();
            if (docid == -1) return;
            MyData.AddDocsRowToTRepOPSd(docid);
            if (MyData.DataSetKlonsRep.TRepOPSd.Count == 0) return;
        }

        private void LoadParams()
        {
            tbSigner.Text = MyData.Params.RekinaIzr;
            cbClid.Text = MyData.Params.PZPARV;
            CheckClName();
        }

        public override void SaveParams()
        {
            MyData.Params.RekinaIzr = tbSigner.Text;
            MyData.Params.PZPARV = cbClid.Text;
        }

        private void CheckClName()
        {
            string s = cbClid.Text;
            if (s == "")
            {
                lbClName.Text = "";
                return;
            }
            lbClName.Text = MyData.GetClName(s);
        }

        private void cbClid_TextChanged(object sender, EventArgs e)
        {
            CheckClName();
        }
        private bool DoOnF5(ComboBox sender)
        {
            Action<string> act =
                value =>
                {
                    if (value != null)
                        sender.Text = value;
                };
            if (sender == cbClid)
            {
                MyMainForm.ShowFormPersonsDialog(act);
                return true;
            }
            return false;
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            OnNaviKey(sender, e);
            switch (e.KeyCode)
            {
                case Keys.F5:
                    if (sender is ComboBox)
                        if (DoOnF5(sender as ComboBox))
                        {
                            e.Handled = true;
                        }
                    break;
            }
        }
        private void cmDoIt_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.CheckForErrors(() =>
            {
                DoIt();

            });
        }

        private void cmCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbClid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoOnF5(sender as ComboBox);
        }

        private string Check()
        {
            clid = MyData.DataSetKlonsRep.TRepOPSd[0].ClId;
            if (string.IsNullOrEmpty(clid))
                return "Dokumentam nav norādīta persona.";

            parvregnr = null;
            parvpvnregnr = null;
            parvjuradrese = null;

            parv = cbClid.Text;
            if (!string.IsNullOrEmpty(parv))
            {
                var dr = MyData.DataSetKlons.Persons.FindByClId(parv);
                if (dr != null)
                {
                    parv = dr.Name;
                    parvregnr = dr.RegNr;
                    parvpvnregnr = dr.PVNRegNr;
                    parvjuradrese = dr.Addr;
                }
            }

            return "OK";
        }

        private void DoIt()
        {
            string rt = Check();
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }

            SaveParams();

            DataView rv = new DataView(MyData.DataSetKlons.Persons,
                "clid = '" + clid + "'", null, DataViewRowState.CurrentRows);

            var ad = MyData.KlonsRepTableAdapterManager.TRepOPSTableAdapter;
            ad.FillBy_rekins_11(MyData.DataSetKlonsRep.TRepOPS, docid);

            bool haspvn = false;
            decimal pvn = 0.00M;
            decimal total = 0.00M;
            List<klonsRepDataSet.TRepOPSRow> PVNRows = new List<klonsRepDataSet.TRepOPSRow>();

            foreach (var dr in MyData.DataSetKlonsRep.TRepOPS)
            {
                total += dr.Summ;
                if (MyData.IsPVN(dr.AC15.Nz()) || MyData.IsPVN(dr.AC25.Nz()))
                {
                    haspvn = true;
                    pvn += dr.Summ;
                    PVNRows.Add(dr);
                    break;
                }
            }

            foreach (var dr in PVNRows)
            {
                MyData.DataSetKlonsRep.TRepOPS.RemoveTRepOPSRow(dr);
            }

            ReportViewerData rd = new ReportViewerData();

            switch (repid)
            {
                case 1:
                    rd.FileName = "Report_Rekins_PZ_1";
                    break;
                default:
                    return;
            }

            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.TRepOPSd;
            rd.Sources["DataSet2"] = rv;
            rd.Sources["DataSet3"] = MyData.DataSetKlonsRep.TRepOPS;
            rd.AddReportParameters(
                new string[]
                {
                    "RCOMPNAME", MyData.Params.CompName,
                    "RREGNR", MyData.Params.CompRegNr,
                    "RPVNREGNR", MyData.Params.CompRegNrPVN,
                    "RADRESE", MyData.Params.CompAddr,
                    "RBANKASKODS", MyData.Params.BankId,
                    "RBANKA", MyData.Params.BankName,
                    "RKONTS", MyData.Params.BankAcc,
                    "RDESCR", "",
                    "RPVN", haspvn? pvn.ToString("F2") : "-",
                    "RAPMAKSAI", total.ToString("F2"),
                    "RSIGNER", tbSigner.Text,
                    "RPARVNOSAUKUMS", parv,
                    "RPARVREGNR", parvregnr,
                    "RPARVPVNREGNR", parvpvnregnr,
                    "RPARVJURADRESE", parvjuradrese,
                    "RPARVTR", tbTLNumurs.Text,
                    "RPARVVARDS", tbTLVaditajs.Text,
                    "RDARIJUMS", cbDarVeids.Text,
                    "RAPMAKSA", cbApmaksa.Text,
                    "RTERMINS", cbTermins.Text
                });
            MyMainForm.ShowReport(rd);

        }

    }
}
