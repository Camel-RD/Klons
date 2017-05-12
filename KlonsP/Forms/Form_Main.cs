using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataObjectsP;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using KlonsP.Classes;
using KlonsP.Forms;

namespace KlonsP.Forms
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
            var urls = KlonsP.Properties.Settings.Default.KlonsVerURLS;
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

        private void nomainītSaimniecībuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDB();
        }
        private void aizvērtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CloseAllForms()) return;
            Application.Exit();
        }

        private void pamatlīdzekļiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_Items));
        }
        private void notikumiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_Events));
        }
        private void miTaxDeprecYR_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_TaxDeprecYR));
        }
        private void pamatlīdzekļuKategorijasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_Cat1));
        }

        private void nolietojumaKategorijasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_CatD));
        }

        private void nolietojumaKategorijasNodokļuVajadzībāmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_CatT));
        }

        private void struktūrvienībasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_Departments));
        }

        private void atrašanāsVietasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_Places));
        }

        private void ziņasParUzņēmumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(Form_CompanyData));
        }

        private void kustībasPārskatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormDialog(typeof(FormRep_Movement));
        }

        private void nolietojumsNodokļaAprēķinamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormDialog(typeof(FormRep_TaxDeprec));
        }
        private void nolietojumsNodokļuVajadzībāmPaKategorijāmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormDialog(typeof(Form_TaxDeprecCat));
        }

        private void aprakstsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = KlonsData.GetBasePath() + "\\Klons-P.chm";
            Help.ShowHelp(null, s);
        }

        private void svarīgākieTaustiņiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = KlonsData.GetBasePath() + "\\Klons-P.chm";
            Help.ShowHelp(null, s, "\\Klons-P.chm::/Svarigakie_taustioi.htm");
        }

        private void parProgrammuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new Form_About();
            fm.ShowDialog(this);
        }
        #endregion **********  Menu clicks **********

    }
}
