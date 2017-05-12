using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsP.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsP.Forms
{
    public partial class Form_Settings : MyFormBaseP
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

        }

        private bool SaveMyData()
        {
            MyData.Settings.DoVersionCheck = chCheckVersion.Checked ? "YES" : "NO";
            MyData.Settings.FormFont = this.Font;
            MyData.Settings.ColorThemeId = colorThemeId;
            ColorThemeHelper.MyToolStripRenderer.SetColorTheme(Settings.ColorTheme);

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
    }
}
