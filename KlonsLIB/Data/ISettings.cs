using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsLIB.Data
{
    public interface IKlonsSettings
    {
        MyColorTheme ColorTheme { get; }
        string ColorThemeId { get; set; }
        int FormFontSize { get; set; }
        string FormFontName { get; set; }
        int FormFontStyle { get; set; }
        Font FormFont { get; set; }
        int ReportZoom { get; set; }
        string WindowPos { get; set; }
    }
}
