﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsF.Classes;
using KlonsF.DataSets;
using KlonsF.Forms;
using KlonsF.FormsReportParams;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using KlonsF.UI;

namespace KlonsF
{
    public partial class Form_Main : MyMainFormBase
    {

        public Form_Main()
        {
            MyMainForm = this;
            InitializeComponent();
            SetupMenuRenderer();
            CheckMyFontAndColors();
            Application.ThreadException += Application_ThreadException;
        }

        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception is ArgumentException &&
                e.Exception.Message == "Parameter is not valid." &&
                e.Exception.Source == "System.Drawing" &&
                e.Exception.StackTrace.Contains("Microsoft.Reporting.WinForms.AsyncWaitMessage.OnLoad"))
                return;

            Form_Error.ShowException(e.Exception,
                "Programmas kļūda!\n" +
                "Ieteicams programmu aizvērt un palaist no jauna.\n" +
                "Ja kļūda bieži atkārtojas, ieteicams par to informēt programmas izstrādātāju.");
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KlonsData MyData { get { return KlonsData.St; } }

        public override MyColorTheme MyColorTheme
        {
            get { return MyData.Settings.ColorTheme; }
        }

        public void ChangeDB()
        {
            if (!CloseAllForms()) return;
            Form_StartUp fs = new Form_StartUp();
            if (fs.ShowDialog(this) != DialogResult.OK)
            {
                Application.Exit();
                return;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            MyData.LoadSettings();
            if (MyData.Settings.WindowPos == "max")
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            ChangeDB();
            DoVersionCheck();
        }

        private int klonsverURLNr = -1;
        private void DoVersionCheck()
        {
            if (MyData.Settings.DoVersionCheck != "YES") return;
            string ld = MyData.Settings.LastVersionCheckDate;
            DateTime dt;
            if (Utils.StringToDate(ld, out dt))
            {
                if (dt.AddDays(2) > DateTime.Today) return;
            }
            StartNextKlonsVerURL();
        }

        private void StartNextKlonsVerURL()
        {
            var urls = KlonsF.Properties.Settings.Default.KlonsVerURLS;
            klonsverURLNr++;
            if (urls == null || urls.Count <= klonsverURLNr) return;
            aDownloader1.URL = urls[klonsverURLNr];
            if (aDownloader1.StartDownload()) return;
            StartNextKlonsVerURL();
        }

        private void CheckVersionNr(string ver)
        {
            MyData.Settings.LastVersionCheckDate = Utils.DateToString(DateTime.Today);
            string v = MyData.Version;
            if (string.Compare(v, ver) < 0)
            {
                ShowInfo("Ir pieejama jauna programmas versija.\n" +
                         "To var lejuplādēt interneta lapā www.kastanis.biz.");
            }
        }

        private void aDownloader1_DataReceived(object sender, EventArgs e)
        {
            string ver = aDownloader1.GetData();
            if (ver == null || ver.Length != 3) return;
            Invoke(new Action<string>(CheckVersionNr), ver);
        }

        private void aDownloader1_DownloadFailed(object sender, EventArgs e)
        {
            StartNextKlonsVerURL();
        }


        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MyData.Dispose();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CloseAllForms())
            {
                e.Cancel = true;
                return;
            }
            try
            {
                MyData.Params.Save();
            }
            catch (Exception) { }

            try
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    MyData.Settings.WindowPos = "max";
                }
                else
                {
                    MyData.Settings.WindowPos = "normal";
                }
                MyData.SaveSettings();
            }
            catch (Exception) { }
        }


        #region ============== ShowForm___ ==============

        public void ShowFormSettings()
        {
            var fs = new Form_Settings();
            fs.ShowDialog(this);
        }
        public Form_OpsFilter ShowFormOPSFilter()
        {
            return ShowForm(typeof(Form_OpsFilter)) as Form_OpsFilter;
        }
        public Form_Docs ShowFormDocs()
        {
            return ShowForm(typeof(Form_Docs)) as Form_Docs;
        }
        public Form_Docs FindFormDocs()
        {
            return FindForm(typeof(Form_Docs)) as Form_Docs;
        }
        public void ShowFormPersons()
        {
            var f = ShowForm(typeof(Form_Persons)) as Form_Persons;
        }
        public void ShowFormPersonsDialog(Action<string> onselectedvalue)
        {
            var f = ShowFormDialog(typeof(Form_Persons)) as Form_Persons;
            if (f == null) return;
            f.OnSelectedValue = onselectedvalue;
        }
        public void ShowFormAcplan()
        {
            var f = ShowForm(typeof(Form_AcPlan)) as Form_AcPlan;
        }
        public void ShowFormAcplanDialog(Action<string> onselectedvalue)
        {
            var f = ShowFormDialog(typeof(Form_AcPlan)) as Form_AcPlan;
            if (f == null) return;
            f.OnSelectedValue = onselectedvalue;
        }
        public void ShowFormAcp3()
        {
            var f = ShowForm(typeof(Form_AcP3)) as Form_AcP3;
        }
        public void ShowFormAcp3Dialog(Action<string> onselectedvalue)
        {
            var f = ShowFormDialog(typeof(Form_AcP3)) as Form_AcP3;
            if (f == null) return;
            f.OnSelectedValue = onselectedvalue;
        }
        public void ShowFormAcp4()
        {
            var f = ShowForm(typeof(Form_AcP4)) as Form_AcP4;
        }
        public void ShowFormAcp4Dialog(Action<string> onselectedvalue)
        {
            var f = ShowFormDialog(typeof(Form_AcP4)) as Form_AcP4;
            if (f == null) return;
            f.OnSelectedValue = onselectedvalue;
        }
        public void ShowFormAcp5()
        {
            var f = ShowForm(typeof(Form_AcPVN)) as Form_AcPVN;
        }
        public void ShowFormAcp5Dialog(Action<string> onselectedvalue)
        {
            var f = ShowFormDialog(typeof(Form_AcPVN)) as Form_AcPVN;
            if (f == null) return;
            f.OnSelectedValue = onselectedvalue;
        }
        public void ShowFormDocTyp()
        {
            var f = ShowForm(typeof(Form_DocTyp)) as Form_DocTyp;
        }
        public void ShowFormDocTypDialog(Action<string> onselectedvalue)
        {
            var f = ShowFormDialog(typeof(Form_DocTyp)) as Form_DocTyp;
            if (f == null) return;
            f.OnSelectedValue = onselectedvalue;
        }
        public void ShowFormAcPVN()
        {
            var f = ShowForm(typeof(Form_AcPVN)) as Form_AcPVN;
        }
        public void ShowFormOpsRules()
        {
            var f = ShowForm(typeof(Form_OpsRules)) as Form_OpsRules;
        }
        public void ShowFormOpsRulesDialog(Action<string> onselectedvalue)
        {
            var f = ShowFormDialog(typeof(Form_OpsRules)) as Form_OpsRules;
            if (f == null) return;
            f.OnSelectedValue = onselectedvalue;
        }
        public void ShowFormBal0()
        {
            var f = ShowForm(typeof(Form_Bal0)) as Form_Bal0;
        }
        public void ShowFormDocs0()
        {
            var f = ShowForm(typeof(Form_Docs0)) as Form_Docs0;
        }
        public void ShowFormUsersDialog()
        {
            var f = new Form_Users();
            f.ShowDialog(this);
        }

        #endregion



        #region ============ Menu Clicks ==============

        private void nomainītSaimniecībuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDB();
        }
        private void dokumentuLabojumiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_LOPSd));
        }
        private void kontējumuLabojumiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_LOPS));
        }
        private void datuEksportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CloseAllForms()) return;
            ShowFormDialog(typeof(Form_Export));
        }
        private void datuImportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CloseAllForms()) return;
            ShowFormDialog(typeof(Form_Import));
        }
        private void aizvērtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CloseAllForms()) return;
            Application.Exit();
        }

        private void ierakstiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormOPSFilter();
        }
        private void dokumentiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormDocs();
        }
        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormPersons();
        }
        private void kontuPlānsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormAcplan();
        }
        private void pVNPazīmesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormAcPVN();
        }
        private void kontējumuKontroleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormOpsRulesDialog(null);
        }
        private void sākumaAtlikumiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormBal0();
        }
        private void neapmaksātieRēķiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormDocs0();
        }
        private void kontējumaPazīmesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormAcp4();
        }

        private void ziņasParUzņemumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_CompanyData));
        }
        private void bilanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof (FormRep_Apgr1));
        }
        private void kontuKorespondenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_Koresp));
        }
        private void avansaNorēķinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_AvNor));
        }
        private void paMēnešiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_ApgrMT));
        }
        private void naudasPlūsmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_ApgrNP));
        }
        private void darijumuŽurnālsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_ApgrDZ));
        }
        private void pilnaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_ApgrFull));
        }
        private void valūtasKontuAtskaitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_Currency));
        }
        private void darijumuŽurnālsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_Darz1));
        }
        private void naudasPlūsmaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_NPMT));
        }
        private void kasesGrāmataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_KasesGr));
        }
        private void personuPārskatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_Persons));
        }
        private void atskaiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_Bilance));
        }
        private void skaidrasNaudasDarijumiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_SkaidraNauda));
        }
        private void formulasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_BilancesFormula));
        }
        private void deklarācijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_PVNDekl));
        }
        private void žurnālsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_PVNZ1));
        }
        private void kopsavilkumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_PVNKops));
        }
        private void summuKontroleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(FormRep_PVNCheck));
        }
        private void bankuSarakstsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_Bankas));
        }
        private void dokumentuVeidiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormDocTyp();
        }
        private void valūtuKursiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_Currency));
        }
        private void kāStrādāsimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CloseAllForms()) return;
            ShowFormSettings();
        }
        private void parProgrammuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form_About().ShowDialog(MyMainForm);
        }
        private void aprakstsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = KlonsData.GetBasePath() + "\\KLONS-F.chm";
            Help.ShowHelp(null, s);
        }
        private void svarīgākieTaustiņiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = KlonsData.GetBasePath() + "\\KLONS-F.chm";
            Help.ShowHelp(null, s, "apraksts.chm::/svarigakietaustini.htm");
        }

        #endregion

    }
}
