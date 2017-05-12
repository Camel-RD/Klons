using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsF.Classes;
using KlonsF.UI;
using KlonsF.DataSets.klonsRepDataSetTableAdapters;
using KlonsLIB.Misc;

namespace KlonsF.Forms
{
    public partial class Form_LinkedDocs : MyFormBaseF
    {
        public Form_LinkedDocs()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            CheckColumns();
        }
        public Form_LinkedDocs(string clid, string docnr)
        {
            InitializeComponent();
            CheckMyFontAndColors();
            CheckColumns();
            this.clid = clid;
            this.docnr = docnr;
        }

        public decimal Summ = 0.00M;
        public decimal PVN = 0.00M;
        public string descr = null;
        public string ac1 = null;
        public string docnr_out = null;
        public string docsr_out = null;

        private string clid = null;
        private string docnr = null;
        private int linkdocsforyears = 1;

        private void Form_LinkedDocs_Load(object sender, EventArgs e)
        {
            LoadParams();
            if (clid == null) return;

            var ad1 = MyData.GetKlonsRepAdapter("TRepOPS") as TRepOPSTableAdapter;
            var ad2 = MyData.GetKlonsRepAdapter("TRepOPSd") as TRepOPSdTableAdapter;

            DateTime dateEnd = DateTime.Today;
            DateTime dateStart = dateEnd.AddYears(-linkdocsforyears);

            ad1.FillBy_linkeddocs_2(MyData.DataSetKlonsRep.TRepOPS,
                dateStart, dateEnd, clid, docnr);
            ad2.FillBy_linkeddocs_1(MyData.DataSetKlonsRep.TRepOPSd,
                dateStart, dateEnd, clid, docnr);

        }
        private void CheckColumns()
        {
            string CHCOL = MyData.Params.CHCOL;
            bool b1 = CHCOL[0] == '1';
            bool b2 = CHCOL[1] == '1';
            bool b3 = CHCOL[2] == '1';
            bool b4 = CHCOL[3] == '1';
            dgcOPSAC12.Visible = b1;
            dgcOPSAC22.Visible = b1;
            dgcOPSAC13.Visible = b2;
            dgcOPSAC23.Visible = b2;
            dgcOPSAC14.Visible = b3;
            dgcOPSAC24.Visible = b3;
            dgcOPSAC15.Visible = b4;
            dgcOPSAC25.Visible = b4;
            b1 = MyData.Params.CHCOLCURR;
            dgcOPSCur.Visible = b1;
            dgcOPSSumm.Visible = b1;
        }

        private void LoadParams()
        {
            string yr = MyData.Params.LinkDocsYR;
            if (!int.TryParse(yr, out linkdocsforyears))
            {
                linkdocsforyears = 1;
            }
            tbSetYears.SelectedIndex = linkdocsforyears - 1;
        }

        public override void SaveParams()
        {
            if (!int.TryParse(tbSetYears.Text, out linkdocsforyears))
            {
                linkdocsforyears = 1;
            }
            MyData.Params.LinkDocsYR = linkdocsforyears.ToString();
        }

        private void cmCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void tbSetYears_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(tbSetYears.Text, out linkdocsforyears))
            {
                linkdocsforyears = 1;
            }
        }

        private void Form_LinkedDocs_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }

        private void CheckSums()
        {
            Summ = 0.00M;
            PVN = 0.00M;
            ac1 = null;
            descr = null;
            docnr_out = null;
            docsr_out = null;

            if (dgvOPSd.SelectedRows.Count == 0)
            {
                tbSumm.Text = "0.00";
                tbPVN.Text = "0.00";
                return;
            }
            decimal r;
            foreach (DataGridViewRow row in dgvOPSd.SelectedRows)
            {
                r = (decimal)(row.Cells[dgcDocsSumm.Index].Value);
                Summ += r;
                PVN += (decimal)(row.Cells[dgcDocsPVN.Index].Value);
                if (r > 0)
                {
                    descr = row.Cells[dgcDescr.Index].Value.AsString();
                    docnr_out = row.Cells[dgcDocsDocNr.Index].Value.AsString();
                    docsr_out = row.Cells[dgcDocsDocSt.Index].Value.AsString();
                }
            }

            /*
            if (dgvOPSd.SelectedRows.Count > 0)
            {
                docnr_out = dgvOPSd.SelectedRows[0].Cells[dgcDocsDocNr.Index].Value.AsString();
                docsr_out = dgvOPSd.SelectedRows[0].Cells[dgcDocsDocSt.Index].Value.AsString();
            }
            */

            if (dgvOPSd.SelectedRows.Count == 1)
            {
                if (dgvOPS.Rows.Count > 0)
                {
                    var sd = dgvOPS[dgcOPSAC11.Index, 0].Value.AsString();
                    var sk = dgvOPS[dgcOPSAC21.Index, 0].Value.AsString();
                    if (sd.LeftMax(3) == "231" && sk[0] == '6')
                    {
                        ac1 = sk;
                    }
                    else if (sd[0] == '7' && sk.LeftMax(3) == "531")
                    {
                        ac1 = sd;
                    }
                }
            }
            tbSumm.Text = Summ.ToString("N2");
            tbPVN.Text = PVN.ToString("N2");
        }

        private void DoIt()
        {
            if (!decimal.TryParse(tbSumm.Text, out Summ) ||
                !decimal.TryParse(tbPVN.Text, out PVN))
            {
                MyMainForm.ShowInfo("Ievadīta nekorekta summa.");
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void dgvOPSd_SelectionChanged(object sender, EventArgs e)
        {
            CheckSums();
        }


        private void cmOK_Click(object sender, EventArgs e)
        {
            DoIt();
        }

        private void Form_LinkedDocs_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveParams();
        }
    }
}
