using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KlonsA.Forms;
using KlonsLIB.Forms;
using ICSharpCode.SharpZipLib.Zip;
using System.Globalization;

namespace KlonsA.Classes
{
    public class BackupHelper
    {
        public static bool BackupDbFile(string filename, string backupfolder)
        {
            if (!File.Exists(filename))
            {
                Form_Main.MyMainForm.ShowError($"Fails [{filename}] nav atrasts.");
                return false;
            }
            if (!Directory.Exists(backupfolder))
            {
                Form_Main.MyMainForm.ShowError($"Mape [{backupfolder}] nav atrasta.");
                return false;
            }
            if (!CanOpenFile(filename))
            {
                Form_Main.MyMainForm.ShowError($"Fails [{filename}] nav pieejams.");
                return false;
            }

            var zipfilename = NextFilenameWithTimeStamp(filename, backupfolder, "zip");

            if (zipfilename == null)
            {
                Form_Main.MyMainForm.ShowError($"Neizdevās atrast .zip faila nosaukumu.");
                return false;
            }

            var rt = ZipFile(filename, zipfilename);
            if (rt != "OK")
            {
                Form_Main.MyMainForm.ShowError($"Neizdevās izveidot .zip failu.\n\n[{rt}]");
                return false;
            }
            return true;
        }

        const string TimeStampFormat = "yyyyMMdd_HHmmss";

        public static string NextFilenameWithTimeStamp(string filename, string foldername, string newextension = null)
        {
            var p1 = foldername ?? throw new ArgumentNullException("foldername");
            var p2 = Path.GetFileNameWithoutExtension(filename);
            var p3 = newextension;
            if (p3 == null) p3 = Path.GetExtension(filename);
            if (p3 != "" && p3[0] != '.') p3 = "." + p3;
            var dt = DateTime.Now;
            var p4 = dt.ToString(TimeStampFormat);
            var p5 = $"{p4}_{{0}}_{p2}{p3}";
            var filetemplate = Path.Combine(p1, p5);
            var p6 = NextFileName(filetemplate);
            return p6;
        }

        public static (DateTime?, string) ParseFileNameWithTimeStamp(string filename)
        {
            if (filename.Length < 24) return (null, "");
            var parts = filename.Split("_".ToCharArray());
            if (parts.Length < 4) return (null, "");
            int start_pos = parts[0].Length + parts[1].Length + parts[2].Length + 3;
            var ret_fnm = filename.Substring(start_pos);
            try
            {
                var ret_dt = DateTime.ParseExact(
                    filename.Substring(0, TimeStampFormat.Length),
                    TimeStampFormat,
                    CultureInfo.InvariantCulture);
                return (ret_dt, ret_fnm);
            }
            catch (Exception)
            {
                return (null, "");
            }
        }

        public static string NextFileName(string template)
        {
            for(int i = 1; i < 10000; i++)
            {
                string s = string.Format(template, i);
                if (File.Exists(s)) continue;
                return s;
            }
            return null;
        }

        public static string ZipFile(string sourcefile, string zipfile)
        {
            try
            {
                FileInfo file = new FileInfo(sourcefile);
                using (var sw = new FileStream(zipfile, FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    using (var zipStream = new ZipOutputStream(sw))
                    {
                        var entry = new ZipEntry(file.Name);
                        entry.IsUnicodeText = true;
                        zipStream.PutNextEntry(entry);

                        using (var reader = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            byte[] buffer = new byte[4096];
                            int bytesRead;
                            while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                byte[] actual = new byte[bytesRead];
                                Buffer.BlockCopy(buffer, 0, actual, 0, bytesRead);
                                zipStream.Write(actual, 0, actual.Length);
                            }
                        }
                    }
                }
                /*
                var inFileInfo = new FileInfo(sourcefile);
                var fZip = new ICSharpCode.SharpZipLib.Zip.FastZip();
                var filefilter = $"+^{inFileInfo.Name}$";
                fZip.CreateZip(zipfile, inFileInfo.Directory.FullName, false, filefilter);
                */
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "OK";
        }

        public static bool CanOpenFile(string filePath)
        {
            try
            {
                using (File.Open(filePath, FileMode.Open, FileAccess.Write, FileShare.None)) { }
                return true;
            }
            catch (IOException e)
            {
                return false;
            }
        }

        public static bool CanOpenFile(string filePath, int testintervalinms, int testcount)
        {
            int i = 0;
            while (i < testcount)
            {
                try
                {
                    using (File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { }
                    return true;
                }
                catch (IOException e)
                {
                    i++;
                    new System.Threading.ManualResetEvent(false).WaitOne(testintervalinms);
                }
            }
            return false;
        }

        public static bool IsFileLocked(string filePath, int testintervalinms, int testcount)
        {
            bool isLocked = true;
            int i = 0;
            while (isLocked && ((i < testcount)))
            {
                try
                {
                    using (File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { }
                    return false;
                }
                catch (IOException e)
                {
                    var errorCode = System.Runtime.InteropServices.Marshal.GetHRForException(e) & ((1 << 16) - 1);
                    isLocked = errorCode == 32 || errorCode == 33;
                    if (!isLocked) return true; //more like inaccessible
                    i++;
                    new System.Threading.ManualResetEvent(false).WaitOne(testintervalinms);
                }
            }
            return isLocked;
        }

        public static bool TryFinishAction(Action act, int testintervalinms, int testcount)
        {
            int i = 0;
            while (i < testcount)
            {
                try
                {
                    act();
                    return true;
                }
                catch (IOException e)
                {
                    i++;
                    new System.Threading.ManualResetEvent(false).WaitOne(testintervalinms);
                }
            }
            return false;
        }

        public static bool TryFinishBoolFunc(Func<bool>func, int testintervalinms, int testcount)
        {
            int i = 0;
            while (i < testcount)
            {
                try
                {
                    var rb = func();
                    if (rb) return true;
                }
                catch (IOException ){}
                i++;
                new System.Threading.ManualResetEvent(false).WaitOne(testintervalinms);
            }
            return false;
        }

        public static DateTime? GetLastBackupDate(string filename, string backupfolder)
        {
            filename = filename.ToLower();
            var zipfilename = Path.GetFileNameWithoutExtension(filename) + ".zip";
            if (!Directory.Exists(backupfolder)) return null;
            var di = new DirectoryInfo(backupfolder);
            var dt_format = "yyyyMMdd_HHmmss";
            
            Func<string, (DateTime?, string)> fget_data = fnm =>
            {
                if (fnm.Length < 24) return (null, "");
                var parts = fnm.Split("_".ToCharArray());
                if(parts.Length < 4) return (null, "");
                int start_pos = parts[0].Length + parts[1].Length + parts[2].Length + 3;
                var ret_fnm = fnm.Substring(start_pos);
                try
                {
                    var ret_dt = DateTime.ParseExact(
                        fnm.Substring(0, dt_format.Length), 
                        dt_format, 
                        CultureInfo.InvariantCulture);
                    return (ret_dt, ret_fnm);
                }
                catch (Exception)
                {
                    return (null, "");
                }
            };

            var dt = di.EnumerateFiles($"*_{zipfilename}")
                .Select(x => x.Name)
                .Where(x => x.Length > 23)
                .Select(x => fget_data(x.ToLower()))
                .Where(x => x.Item2 == zipfilename)
                .Select(x => x.Item1)
                .DefaultIfEmpty()
                .Max();
            
            return dt;
        }

        public static void ShowError(Exception e)
        {
            Form_Error.ShowException(MyMainFormBase.MyInstance, e
                , "Datu bāzes rezerves kopēšana neizdevās.");
        }

    }
}
