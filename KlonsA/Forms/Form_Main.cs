using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataObjectsA;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using KlonsA.Classes;
using KlonsA.Forms;

namespace KlonsA
{
    public partial class Form_Main : MyMainFormBase
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KlonsData MyData => KlonsData.St;

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

        public override MyColorTheme MyColorTheme
        {
            get { return MyData.Settings.ColorTheme; }
        }


        public void ChangeDB()
        {
            if (!CloseAllForms()) return;

            try
            {
                MyData.Params.Save();
            }
            catch (Exception) { }

            Form_StartUp fs = new Form_StartUp();
            if (fs.ShowDialog(this) != DialogResult.OK)
            {
                Application.Exit();
                return;
            }
            DataLoader.LoadSomeData();
            if (!MyData.Settings.DontShowBetaWarning)
            {
                ShowInfo("Darbs pie programmas vēl nav pabeigts,\n" +
                    "Šī versija ir paredzēta testēšanai,\n" +
                    "Ja tev ir ieteikumi uzlabojumiem, raksti uz e-pastu.");
            }
        }

        public void LoadData()
        {
            if (!CloseAllForms()) return;
            var fs = new Form_DataLoad();
            fs.ShowDialog(this);
        }

        public bool CheckData()
        {
            if (DataLoader.DataLoaded) return true;
            LoadData();
            return DataLoader.DataLoaded;
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            MyData.LoadSettings();
            if (MyData.Settings.WindowPos == "max")
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void Form_Main_Shown(object sender, EventArgs e)
        {
            ChangeDB();
            DoVersionCheck();
        }

        #region **********  Version check ******************

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
            var urls = KlonsA.Properties.Settings.Default.KlonsVerURLS;
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

        #endregion **********  Version check ******************


        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.Dispose();
        }

        public void ShowFormSettings()
        {
            var fs = new Form_Settings();
            fs.ShowDialog(this);
        }
		
        public Form_Users ShowFormUsersDialog()
        {
            return ShowFormDialog(typeof(Form_Users)) as Form_Users;
        }


        #region **********  Menu clicks ******************

        private void kāStrādāsimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CloseAllForms()) return;
            ShowFormSettings();
        }
        private void miRepStats_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_Stats));
        }
        private void papildusNotikumuKodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_EventTypes2));
        }
        private void likmesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_Rates));
        }
        private void ienākumuVeidiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_IncomeCodes));
        }
        private void teritoriālieKodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_TeritorialCodes));
        }

        private void profesijuKlasifikatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_Professions));
        }

        private void struktūrvienībasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_Departments));
        }

        private void svētkuDienasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_Holidays));
        }

        private void bankasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_Banks));
        }

        private void darbaLaikaPlānuSarakstsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_PlanList));
        }

        private void darbaLaikaPlānsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_Plan));
        }

        private void darbaLaikaUzskaitesLapusagatavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_TimeSheetTempl));
        }

        private void darbaLaikaUzskaitesLapasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_TimeSheets));
        }
        private void darbaLaikaUzskaitesLapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_TimeSheet));
        }

        private void darbiniekiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_Persons));
        }

        private void darbiniekuDatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            if(MyData.DataSetKlons.PERSONS.Count == 0)
            {
                ShowWarning("Darbinieku sarksts ir tukšs.");
                return;
            }
            ShowForm(typeof(Form_PersonsR));
        }
        private void miNeapliekamaisMinimums_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_UntaxedMinimum));
        }

        private void notikumuIzklāstsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_Events));
        }

        private void neizmantotāsAtvaļinājumaDienasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(FormRep_VacDays));
        }

        private void personuSarakstsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_FizPersons));
        }
        private void maksājumiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_FpPayLists));
        }
        private void datiParPerioduPirmsUzskaitesSākšanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_PastData));
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Form1()).Show();
        }

        private void ziņuKodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_ReportCodes));
        }

        private void algasAprēķinaLapusagatavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_SalarySheetTempl));
        }

        private void algasAprēķinaLapuSarakstsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_SalarySheets));
        }

        private void algasAprēķinaLapasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_SalarySheet));
        }

        private void darbaUzskaiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_PieceWork));
        }

        private void katalogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_PieceWorkCatalog));
        }

        private void katalogaStruktūraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_PieceWorkCatStruct));
        }

        private void sarakstusagatavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_PayListsTempl));
        }

        private void mkasājumuSarakstiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            ShowForm(typeof(Form_PayLists));
        }


        private void atlasītDatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void nomainītSaimniecībuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDB();
        }

        private void rādītPēdējāsKļūdasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = ShowForm(typeof(Form_ErrorList)) as Form_ErrorList;
            f.SetMyDataErrorList();
        }

        private void ziņasParUzņēmumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_CompanyData));
        }

        private void aizvērtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CloseAllForms()) return;
            Application.Exit();
        }

        private void ziņasParDarbaŅēmējiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.WarnIfHasChanges();
            ShowForm(typeof(FormRep_Zinas));
        }

        private void ziņojumsParVSAOIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.WarnIfHasChanges();
            ShowForm(typeof(FormRep_VSAOI));
        }

        private void paziņojumsParFiziskajāmPersonāmIzmaksātajāmSummāmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.WarnIfHasChanges();
            ShowForm(typeof(FormRep_IINK));
        }

        private void kopsavilkumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyData.ReportHelper.WarnIfHasChanges();
            ShowForm(typeof(FormRep_Aggregate));
        }

        private void parProgrammuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new Form_About();
            fm.ShowDialog(this);
        }

        private void aprakstsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = KlonsData.GetBasePath() + "\\Klons-A.chm";
            Help.ShowHelp(null, s);
        }

        private void svarīgākieTaustiņiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = KlonsData.GetBasePath() + "\\Klons-A.chm";
            Help.ShowHelp(null, s, "\\Klons-A.chm::/Svarigakie_taustioi.htm");
        }

        #endregion **********  Menu clicks

    }


}
