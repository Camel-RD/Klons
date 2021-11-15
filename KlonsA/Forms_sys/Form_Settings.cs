using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsA.Forms
{
    public partial class Form_Settings : MyFormBaseA
    {
        public Form_Settings()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private string colorThemeId = "";

        private void LoadData()
        {
            chCheckVersion.Checked = MyData.Settings.DoVersionCheck == "YES";

            string s = MyData.Settings.FormFontSize.ToString();
            if (s.Length == 1) s = "0" + s;
            cbFontSize.Text = s;
            cmFont.Text = MyData.Settings.FormFont.Name;
            colorThemeId = MyData.Settings.ColorThemeId;
            int k = colorThemeIds.IndexOf(colorThemeId);
            if (k > -1)
                cbColors.SelectedIndex = k;

            tbMt.Text = MyData.Params.LoadMonths.ToString();
            chHideTotalSheet.Checked = MyData.Params.HideTotalSheets;
            chIIN.Checked = MyData.Params.IINSimple;

            cbBackUpPlan.SelectedIndex = (int)MyData.Settings.BackUpPlanX;
            var backupfolder = MyData.Settings.BackUpFolder.Nz();
            if (backupfolder == "") backupfolder = "DB-backup";
            tbBackUpFolder.Text = backupfolder;
        }

        private bool SaveMyData()
        {
            MyData.Settings.DoVersionCheck = chCheckVersion.Checked ? "YES" : "NO";
            MyData.Settings.FormFont = this.Font;
            MyData.Settings.ColorThemeId = colorThemeId;
            ColorThemeHelper.MyToolStripRenderer.SetColorTheme(Settings.ColorTheme);

            int mtct;
            if (!string.IsNullOrEmpty(tbMt.Text) && 
                int.TryParse(tbMt.Text, out mtct) &&
                mtct > 0 && mtct < 100)
            {
                MyData.Params.LoadMonths = mtct;
            }
            MyData.Params.HideTotalSheets = chHideTotalSheet.Checked;
            MyData.Params.IINSimple = chIIN.Checked;

            MyData.Settings.BackUpPlan = cbBackUpPlan.SelectedIndex;
            var backupfolder = tbBackUpFolder.Text.Nz();
            if (backupfolder == "DB-backup") backupfolder = "";
            MyData.Settings.BackUpFolder = backupfolder;

            return true;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ApplyColorTheme(string themeid)
        {
            MyColorTheme th = null;
            colorThemeId = themeid;
            switch (themeid)
            {
                case "system":
                    th = ColorThemeHelper.ColorTheme_System;
                    break;
                case "dark1":
                    th = ColorThemeHelper.ColorTheme_Dark1;
                    break;
                case "green":
                    th = ColorThemeHelper.ColorTheme_Green;
                    break;
                case "blackonwhite":
                    th = ColorThemeHelper.ColorTheme_BlackOnWhite;
                    break;
            }
            this.SetColorTheme(th);
            this.Refresh();
        }

        private void ApplyFont(Font font)
        {
            FontStyle fs = font.Style & (FontStyle.Bold | FontStyle.Regular | FontStyle.Italic);
            cmFont.Text = font.Name;
            int sz = font.FontSizeX();
            if (sz < 8) sz = 8;
            if (sz > 16) sz = 16;
            string s = sz.ToString();
            if (sz < 10) s = "0" + s;
            cbFontSize.Text = s;

            this.Font = new Font(font.FontFamily, sz, fs);
        }

        private void cmFont_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = this.Font;
            fd.ShowColor = false;
            fd.MinSize = 8;
            fd.MaxSize = 16;
            fd.AllowScriptChange = false;

            if (fd.ShowDialog(this) != DialogResult.OK) return;
            ApplyFont(fd.Font);
        }
        private void cmUseSysFont_Click(object sender, EventArgs e)
        {
            ApplyFont(SystemFonts.DefaultFont);
        }

        private void cbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sz = int.Parse(cbFontSize.Text);
            if(sz != this.Font.SizeInPoints)
                SetFontSize(sz);
        }

        private void cmOK_Click(object sender, EventArgs e)
        {
            SaveMyData();
            MyMainForm.CheckMyFontAndColors();
            MyMainForm.CheckMenuColorTheme();
            this.Close();
        }

        private static string[] colorThemeIds =
            new string[] { "system", "dark1", "green", "blackonwhite" };
        private void cbColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            int k = cbColors.SelectedIndex;
            if (k < 0 || k > 3) return;
            ApplyColorTheme(colorThemeIds[k]);
        }

        private void cmBrowseForBackUpFolder_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog()
            {
                Description = "Norādi mapi rezerves failu kopēšanai:"
            };
            var rt = fbd.ShowDialog(MyMainForm);
            if (rt != DialogResult.OK) return;
            tbBackUpFolder.Text = fbd.SelectedPath;
        }
    }
}
