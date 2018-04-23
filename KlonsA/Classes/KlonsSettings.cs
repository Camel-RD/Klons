using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsA.Classes
{
    [Serializable()] 
    public class KlonsSettings: IKlonsSettings
    {
       
        private string lastUserName = "";

        private string colorThemeId = "system";
        private MyColorTheme colorTheme = null;

        private int formFontSize = 10;
        private string formFontName = "";
        private int formFontStyle = 0;
        private Font formFont = null;
        
        private string baseDBPath = "DB";
        private string baseConnStr = "FBServer";

        private string doVersionCheck = "NO";
        private string lastVersionCheckDate = "";

        private bool showPersonList = false;
        private bool showPayDataPanel = false;
        private bool showPayLists = false;
        private bool showFpPayDataPanel = false;
        private bool showFpPayLists = false;
        private bool dontShowBetaWarning = false;

        private int[] columnWidths_Docs = new int[0];

        [XmlIgnore]
        public bool HasChanged = false;

        private MasterEntry masterEntry = new MasterEntry();
        
        private int reportZoom = 100;
        private string windowPos = "normal"; // normal, max

        public static bool DesignMode
        {
            get
            {
                string dir = Utils.GetMyFolder();
                dir = new DirectoryInfo(dir).Name.ToLower();
                return dir == "debug" || dir == "release";
            }
        }

        public MasterEntry MasterEntry
        {
            get { return masterEntry; }
            set
            {
                if (value == null)
                {
                    masterEntry = new MasterEntry();
                    return;
                }
                if (masterEntry.Equals(value)) return;
                masterEntry = value;
                HasChanged = true;
            }
        }

        public string LastUserName
        {
            get { return lastUserName; }
            set
            {
                if (lastUserName == value) return;
                lastUserName = value;
                HasChanged = true;
            }
        }

        public string BaseDBPathX
        {
            get { return baseDBPath; }
            set
            {
                if (baseDBPath == value) return;
                baseDBPath = value;
                HasChanged = true;
            }
        }
        public string BaseConnStr
        {
            get { return baseConnStr; }
            set
            {
                if (baseConnStr == value) return;
                baseConnStr = value;
                HasChanged = true;
            }
        }

        public string DoVersionCheck
        {
            get { return doVersionCheck; }
            set
            {
                if (doVersionCheck == value) return;
                doVersionCheck = value;
                HasChanged = true;
            }
        }

        public string LastVersionCheckDate
        {
            get { return lastVersionCheckDate; }
            set
            {
                if (lastVersionCheckDate == value) return;
                lastVersionCheckDate = value;
                HasChanged = true;
            }
        }

        [XmlIgnore]
        public MyColorTheme ColorTheme
        {
            get
            {
                if (colorTheme == null)
                {
                    colorTheme = ColorThemeHelper.ColorTheme_System;
                }
                return colorTheme;
            }
        }

        public string ColorThemeId
        {
            get { return colorThemeId; }
            set
            {
                if (colorThemeId == value) return;
                colorThemeId = value;
                colorTheme = null;
                switch (value)
                {
                    case "system":
                        colorTheme = ColorThemeHelper.ColorTheme_System;
                        break;
                    case "dark1":
                        colorTheme = ColorThemeHelper.ColorTheme_Dark1;
                        break;
                    case "green":
                        colorTheme = ColorThemeHelper.ColorTheme_Green;
                        break;
                    case "blackonwhite":
                        colorTheme = ColorThemeHelper.ColorTheme_BlackOnWhite;
                        break;

                }
                if (colorTheme == null)
                {
                    colorTheme = ColorThemeHelper.ColorTheme_System;
                    colorThemeId = "system";

                }
                HasChanged = true;
            }
        }

        public int FormFontSize
        {
            get { return formFontSize; }
            set
            {
                if (formFontSize == value) return;
                formFontSize = value;
                CheckFont();
                HasChanged = true;
            }
        }

        public string FormFontName
        {
            get { return formFontName; }
            set
            {
                if (formFontName == value) return;
                formFontName = value;
                CheckFont();
                HasChanged = true;
            }
        }
        public int FormFontStyle
        {
            get { return formFontStyle; }
            set
            {
                if (formFontStyle == value) return;
                FormFontStyle = value;
                CheckFont();
                HasChanged = true;
            }
        }

        private void CheckFont()
        {
            if (formFont != null)
            {
                if (formFont.Name == formFontName &&
                    formFont.FontSizeX() == formFontSize &&
                    formFont.Style == (FontStyle) formFontStyle)
                    return;
            }
            string fnm = formFontName;
            if (string.IsNullOrEmpty(fnm))
            {
                fnm = SystemFonts.DefaultFont.Name;
            }
            FontStyle fs = (FontStyle) formFontStyle;
            formFont = new Font(fnm, formFontSize, fs);
        }

        [XmlIgnore]
        public Font FormFont
        {
            get
            {
                CheckFont();
                return formFont;
            }
            set
            {
                if(value == null) return;
                if (formFont != null)
                {
                    if (formFont.Name == value.Name &&
                        formFont.FontSizeX() == value.SizeInPoints &&
                        formFont.Style == value.Style)
                        return;
                }
                formFontName = value.Name;
                formFontSize = value.FontSizeX();
                formFontStyle = (int)value.Style;
                formFont = new Font(formFontName, formFontSize, (FontStyle)formFontStyle);
            }
        }

        public bool ShowPersonList
        {
            get { return showPersonList; }
            set
            {
                if (showPersonList == value) return;
                showPersonList = value;
                HasChanged = true;
            }
        }
        
        public bool ShowPayDataPanel
        {
            get { return showPayDataPanel; }
            set
            {
                if (showPayDataPanel == value) return;
                showPayDataPanel = value;
                HasChanged = true;
            }
        }

        public bool ShowPayLists
        {
            get { return showPayLists; }
            set
            {
                if (showPayLists == value) return;
                showPayLists = value;
                HasChanged = true;
            }
        }

        public bool ShowFpPayDataPanel
        {
            get { return showFpPayDataPanel; }
            set
            {
                if (showFpPayDataPanel == value) return;
                showFpPayDataPanel = value;
                HasChanged = true;
            }
        }

        public bool ShowFpPayLists
        {
            get { return showFpPayLists; }
            set
            {
                if (showFpPayLists == value) return;
                showFpPayLists = value;
                HasChanged = true;
            }
        }

        public bool DontShowBetaWarning
        {
            get { return dontShowBetaWarning; }
            set
            {
                if (dontShowBetaWarning == value) return;
                dontShowBetaWarning = value;
                HasChanged = true;
            }
        }

        public int[] ColumnWidths_Docs
        {
            get { return columnWidths_Docs; }
            set
            {
                if (columnWidths_Docs.IsTheSameArray(value)) return;
                columnWidths_Docs = new int[value.Length];
                value.CopyTo(columnWidths_Docs,0);
                HasChanged = true;
            }
        }

        public int ReportZoom
        {
            get { return reportZoom; }
            set
            {
                if (reportZoom == value) return;
                reportZoom = value;
                HasChanged = true;
            }
        }

        public string WindowPos
        {
            get { return windowPos; }
            set
            {
                if (windowPos == value) return;
                windowPos = value;
                HasChanged = true;
            }
        }

        public static KlonsSettings LoadSettings(string filename)
        {
            KlonsSettings settings = new KlonsSettings();
            if (!File.Exists(filename)) return settings;
            XmlSerializer xs = null;
            FileStream fs = null;
            try
            {
                //xs = new XmlSerializer(typeof(KlonsSettings));
                xs = Utils.CreateDefaultXmlSerializer(typeof(KlonsSettings));
                fs = new FileStream(filename, FileMode.Open);
                settings = (KlonsSettings)xs.Deserialize(fs);
                return settings;
            }
            catch (Exception)
            {
                //LogError(e.Message);
                settings = new KlonsSettings();
                return settings;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        public void SaveSettings(string filename)
        {
            //XmlSerializer xs = new XmlSerializer(typeof(KlonsSettings));
            XmlSerializer xs = Utils.CreateDefaultXmlSerializer(typeof(KlonsSettings));
            TextWriter wr = null;
            try
            {
                wr = new StreamWriter(filename);
                xs.Serialize(wr, this);
            }
            catch (Exception)
            {
                //LogError(e.Message);
            }
            finally
            {
                if (wr != null) wr.Close();
            }
        }

    }
}
