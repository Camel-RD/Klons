using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using KlonsLIB.Misc;
using KlonsLIB.Data;

namespace KlonsLIB
{
    public static class MyData
    {
        public static IKlonsSettings Settings { get; set; } = null;

        public static bool DesignMode
        {
            get
            {
                string dir = new DirectoryInfo(Utils.GetMyFolder()).Name.ToLower();
                return dir == "debug" || dir == "release";
            }
        }

        public static string GetBasePath()
        {
            return Utils.GetMyFolderX();
        }
    }
}
