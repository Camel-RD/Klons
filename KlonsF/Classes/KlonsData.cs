using System;
using System.Data;
using System.Data.Common;
using System.IO;
using KlonsF.DataSets;
using KlonsAdapters = KlonsF.DataSets.klonsDataSetTableAdapters;
using KlonsRepAdapters = KlonsF.DataSets.klonsRepDataSetTableAdapters;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsF.Classes
{
    public class KlonsData: KlonsDataModule, IDisposable
    {
        private static KlonsData _KlonsData = null;

        private DataSetHelper _klonsDataSetHelper = null;
        private DataSetHelper _klonsRepDataSetHelper = null;

        public string Version = "078";
        
        public string SettingsFileName = GetBasePath() + "\\Config\\Settings.xml";
        public string MasterListFileName = GetBasePath() + "\\Config\\MasterList.xml";
        public string FolderForXMLReports = GetBasePath() + "\\XMLReports";
        
        public KlonsSettings Settings = new KlonsSettings();
        public MasterList MasterList { get; private set; }
        public MasterEntry CurrentDBTag { get; private set;}

        private KlonsParams _Params = null;
        public ReportHelperF ReportHelper { get; private set; }

        private string _currentUserName = "";
        public Form_Main MyMainForm { get { return Form_Main.MyInstance as Form_Main; } }

        private KlonsData()
        {
            _KlonsData = this;
            CurrentDBTag = null;

            LoadSettings();
            LoadMasterList();

            if (Settings.MasterEntry.Name != "")
            {
                var me = MasterList.GetMasterEntryByName(Settings.MasterEntry.Name);
                if (me != null)
                {
                    Settings.MasterEntry.CopyFrom(me);
                }
            }

            _Params = new KlonsParams();
            
            ReportHelper = new ReportHelperF();

            _klonsDataSetHelper = new DataSetHelper(
                typeof(klonsDataSet) , 
                typeof(KlonsAdapters.TableAdapterManager) ,
                typeof(KlonsAdapters.QueriesTableAdapter),
                "ConnectionString1",
                KlonsF.Properties.Settings.Default);

            _dataSetHelpers["KlonsData"] = _klonsDataSetHelper;

            _klonsRepDataSetHelper = new DataSetHelper(
                typeof(klonsRepDataSet), 
                typeof(KlonsRepAdapters.TableAdapterManager),
                null,
                "ConnectionString1",
                KlonsF.Properties.Settings.Default);

            _dataSetHelpers["KlonsRep"] = _klonsRepDataSetHelper;
        }

        public bool ConnectTo(MasterEntry me, string username, string userpsw)
        {
            string filename;
            if (string.IsNullOrEmpty(me.Path))
            {
                filename = GetBaseDBPath();
            }
            else
            {
                filename = me.Path;
                filename = filename.Replace("@", GetBaseDBPath());
            }
            filename += "\\" + me.FileName;
            if (!File.Exists(filename))
            {
                throw new Exception("Nav faila: " + filename);
            }

            if (CurrentDBTag != null)
            {
                Params.Save();
            }

            _klonsDataSetHelper = new DataSetHelper(
                typeof(klonsDataSet), 
                typeof(KlonsAdapters.TableAdapterManager),
                typeof(KlonsAdapters.QueriesTableAdapter),
                "ConnectionString1",
                KlonsF.Properties.Settings.Default);

            _dataSetHelpers["KlonsData"] = _klonsDataSetHelper;
            
            _klonsRepDataSetHelper = new DataSetHelper(
                typeof(klonsRepDataSet), 
                typeof(KlonsRepAdapters.TableAdapterManager),
                null,
                "ConnectionString1",
                KlonsF.Properties.Settings.Default);
            
            _dataSetHelpers["KlonsRep"] = _klonsRepDataSetHelper;

            string s = MasterList.GetTemplateByName(me.ConnStr);
            if (string.IsNullOrEmpty(s))
            {
                /*
                s = @"Data Source=(LocalDB)\v11.0; " +
                    "AttachDbFilename={0}; " +
                    "Integrated Security=True; " +
                    "Connect Timeout=30; " +
                    "Workstation ID={1}";
                 */
                s = "character set=UTF8;" +
                    "data source=localhost;" +
                    @"initial catalog={0};" +
                    "user id=aivars;" +
                    "password=parole";
            }

            s = string.Format(s, filename, username);
            
            _currentUserName = username;

            _klonsDataSetHelper.ConnectTo(s);
            _klonsRepDataSetHelper.ConnectTo(s);

            KlonsTableAdapterManager.TUsersTableAdapter.Connection.StateChange += Connection_StateChange;
            KlonsTableAdapterManager.TUsersTableAdapter.Connection.Open();

            CurrentDBTag = new MasterEntry(me);
            return true;
        }

        private void Connection_StateChange(object sender, StateChangeEventArgs e)
        {
            //Debug.Print("Connection_StateChange to:" + e.CurrentState);
            if (e.CurrentState == ConnectionState.Open)
            {
                if (KlonsQueriesTableAdapter != null)
                    KlonsQueriesTableAdapter.SP_SET_USERNAME(CurrentUserName);
            }
        }

        public new static KlonsData St
        {
            get
            {
                if (_KlonsData == null)
                {
                    _KlonsData = new KlonsData();
                    _KlonsDataModule = _KlonsData;
                }
                return _KlonsData;
            }
        }


        public klonsDataSet DataSetKlons
        {
            get { return _klonsDataSetHelper.DataSet as klonsDataSet; }
        }
        public klonsRepDataSet DataSetKlonsRep
        {
            get { return _klonsRepDataSetHelper.DataSet as klonsRepDataSet; }
        }

        public KlonsAdapters.TableAdapterManager KlonsTableAdapterManager
        {
            get { return _klonsDataSetHelper.TableAdapterManager as KlonsAdapters.TableAdapterManager; }
        }
        public KlonsAdapters.QueriesTableAdapter KlonsQueriesTableAdapter
        {
            get { return _klonsDataSetHelper.QueriesTableAdapter as KlonsAdapters.QueriesTableAdapter; }
        }
        public KlonsRepAdapters.TableAdapterManager KlonsRepTableAdapterManager
        {
            get { return _klonsRepDataSetHelper.TableAdapterManager as KlonsRepAdapters.TableAdapterManager; }
        }

        public string CurrentUserName
        {
            get { return _currentUserName; }
        }

        public void SetCurrentUserName(string username)
        {
            _currentUserName = username;
        }

        public bool TestUserPassword(string username, string password)
        {
            klonsDataSet.TUsersRow r = DataSetKlons.TUsers.FindBynm(username);
            if (r == null) return false;
            if (string.IsNullOrEmpty(r.psw)) return true;
            if (password == null) return false;
            return r.psw == password;
        }
        public bool ChangeUserPassword(string username, string password)
        {
            klonsDataSet.TUsersRow r = DataSetKlons.TUsers.FindBynm(username);
            if (r == null) return false;
            r.psw = password;
            KlonsTableAdapterManager.TUsersTableAdapter.Update(r);
            return true;
        }
        public string GetUserGroup(string username)
        {
            klonsDataSet.TUsersRow r = DataSetKlons.TUsers.FindBynm(username);
            if (r == null) return null;
            if (string.IsNullOrEmpty(r.tp)) return null;
            return r.tp;
        }

        public KlonsParams Params
        {
            get { return _Params; }
        }

        public DbDataAdapter GetKlonsSqlDataAdapter(string tablename)
        {
            return _klonsDataSetHelper.GetSqlDataAdapter(tablename);
        }

        public object GetKlonsAdapter(string tablename)
        {
            return _klonsDataSetHelper.GetDataAdapter(tablename);
        }

        public object GetKlonsRepAdapter(string tablename)
        {
            return _klonsRepDataSetHelper.GetDataAdapter(tablename);
        }

        public void SetUpTableManagerForUsersTable()
        {
            _klonsDataSetHelper.CreateAdapterForTable("TUsers");
            KlonsTableAdapterManager.TUsersTableAdapter.Fill(DataSetKlons.TUsers);
        }

        public void SetUpTableManager()
        {
            _klonsDataSetHelper.SetUpTableManager();
            _klonsDataSetHelper.SetClearBeforeFillForAll(false);
            _klonsRepDataSetHelper.SetClearBeforeFillForAll(true);
            /*
            SetClearBeforeFillFor(true, "ROps1a", "ROps2a", "ROps3a",
                "TRepA1", "TRepApAn", "TRepDarz1", "TRepDarz2", "TRepDocs1",
                "TRepDocs2", "TRepDocSS", "TRepMT", "TRepPVNz1");
            */
            //_KlonsTableAdapterManager.OPSTableAdapter.ClearBeforeFill = true;
            //_KlonsTableAdapterManager.OPSdTableAdapter.ClearBeforeFill = true;
        }

        public void FillParamsForUser(string username)
        {
            Params.FillForUser(username);
        }

        public void FillBaseTables()
        {
            _klonsDataSetHelper.FillTables("AcP21", "Acp23", "AcP24",
                "Acp25", "AcPVN", "Banks", "Currency", "DocTyp", "DocTypA", 
                "DocTypB", "Persons", "PersonTyp");
        }

        public int FillKlonsTable(string tablename)
        {
            return _klonsDataSetHelper.FillTable(tablename);
        }

        public static string GetBasePath()
        {
            string s = Utils.GetMyFolder();
            if (KlonsSettings.DesignMode)
            {
                DirectoryInfo dir1 = new DirectoryInfo(s);
                s = dir1.Parent.Parent.FullName;
            }
            return s;
        }

        public string GetBaseDBPath()
        {
            return GetBasePath() + "\\" + Settings.BaseDBPathX;
        }

        public void CreateNewDB(string name, string descr)
        {
            MasterEntry me = new MasterEntry();
            me.Name = name;
            me.Descr = descr;
            me.ConnStr = Settings.BaseConnStr;
            string path = GetBaseDBPath();
            me.FileName = Utils.GetNextFile(path, "klons_", "fdb");
            me.FileName = Utils.GetFileNameFromURL(me.FileName);
            CreateNewDB(me);
        }
        public void CreateNewDB(MasterEntry me)
        {
            MasterList.ConnectionList.Add(me);
            string path = GetBaseDBPath();
            string fnmbase = path + "\\base\\klons00.fdb";
            string fnmnew = path + "\\" + me.FileName;
            if (!File.Exists(fnmbase))
            {
                throw new Exception("Fails [" + fnmbase + "] netika atrasts.");
            }
            File.Copy(fnmbase, fnmnew);
            return;
        }

        public string GetAcName(string ac)
        {
            var dr = DataSetKlons.AcP21.FindByAC(ac);
            if (dr == null) return null;
            return dr.Name;
        }
        public string GetAc3Name(string ac)
        {
            var dr = DataSetKlons.Acp23.FindByidx(ac);
            if (dr == null) return null;
            return dr.Name;
        }
        public string GetAc4Name(string ac)
        {
            var dr = DataSetKlons.AcP24.FindByidx(ac);
            if (dr == null) return null;
            return dr.Name;
        }
        public string GetAc5Name(string ac)
        {
            var dr = DataSetKlons.Acp25.FindByidx(ac);
            if (dr == null) return null;
            return dr.Name;
        }
        public string GetClName(string cl)
        {
            var dr = DataSetKlons.Persons.FindByClId(cl);
            if (dr == null) return null;
            return dr.Name;
        }
        public string GetDocTypName(string dt)
        {
            var dr = DataSetKlons.DocTyp.FindByid(dt);
            if (dr == null) return null;
            return dr.Name;
        }
        public string GetBankName(string bankid)
        {
            var dr = DataSetKlons.Banks.FindById(bankid);
            if (dr == null) return null;
            return dr.Name;
        }

        public klonsDataSet.AcP24Row GetAcP24Row(string ac4)
        {
            if (string.IsNullOrEmpty(ac4)) return null;
            return DataSetKlons.AcP24.FindByidx(ac4);
        }

        public string RemoveUnitFromDescr(string descr)
        {
            if (string.IsNullOrEmpty(descr))
                return descr;
            int k = descr.IndexOf('~');
            if (k == -1) return descr;
            if (k == descr.Length - 1) return null;
            return descr.Substring(k + 1);
        }
        public string SetUnitInDescr(string descr, string unit)
        {
            descr = RemoveUnitFromDescr(descr);
            if (string.IsNullOrEmpty(unit)) return descr;
            if (string.IsNullOrEmpty(descr))
            {
                return unit + "~";
            }
            return unit + "~" + descr;
        }

        #region **************  PVN ****************

        public klonsDataSet.AcPVNRow GetPVNrow(string ac5)
        {
            if (string.IsNullOrEmpty(ac5)) return null;
            return DataSetKlons.AcPVN.FindByid(ac5);
        }

        public int AcPVNPz3(string id)
        {
            klonsDataSet.AcPVNRow dr = DataSetKlons.AcPVN.FindByid(id);
            if (dr == null) return -1;
            return dr.pz3;
        }

        public int GetPVNTyp(string ac5)
        {
            klonsDataSet.AcPVNRow dr = GetPVNrow(ac5);
            if (dr == null) return -1;
            if (dr.Ispz5Null()) return 0;
            return dr.pz5;
        }

        public int GetPVNRate(string ac5)
        {
            klonsDataSet.AcPVNRow dr = GetPVNrow(ac5);
            if (dr == null) return -1;
            if (dr.Ispz5Null()) return 0;
            return (int)dr.t;
        }

        public bool IsPVN(string ac5)
        {
            int k = GetPVNTyp(ac5);
            return k > 0;
        }

        public bool IsGoodPVN(string ac5)
        {
            int k = GetPVNTyp(ac5);
            return k == 1 || k == 3;
        }

        public bool IsIenemumiA(int ac5paz3)
        {
            return ac5paz3 == 1 || ac5paz3 == 71 ||
                   ac5paz3 == 72 || ac5paz3 == 8;
        }

        public bool IsIenemumi(string ac5)
        {
            int k = AcPVNPz3(ac5);
            return IsIenemumiA(k);
        }
        public int GetPVNRateA(string ac5, DateTime date)
        {
            klonsDataSet.AcPVNRow dr = GetPVNrow(ac5);
            if (dr == null) return 0;
            int k = dr.Ispz5Null() ? -1 : dr.pz5;
            if (k < 1) return 0;
            if (k > 3 || k == 1) return dr.IstNull() ? 0 : (int)dr.t;
            if (k == 2 || k == 3)
            {
                if (date < new DateTime(2011, 1, 1))
                {
                    return 21;
                }
                else if (date < new DateTime(2012, 8, 1))
                {
                    return 22;
                }
                else
                {
                    return 21;
                }
            }
            return 0;
        }
        #endregion

        public bool AddDocsRowToTRepOPSd(int docid)
        {
            var row = DataSetKlons.OPSd.FindByid(docid);
            if (row == null) return false;
            var row2 = DataSetKlonsRep.TRepOPSd.NewTRepOPSdRow();
            row2.id = row.id;
            row2.ZNR = row.ZNR;
            row2.NrX = row.NrX;
            row2.Dete = row.Dete;
            row2.DocTyp = row.DocTyp;
            row2.DocSt = row.DocSt;
            row2.DocNr = row.DocNr;
            row2.ClId = row.ClId;
            row2.ClId2 = row.ClId2;
            row2.Descr = row.Descr;
            row2.Summ = row.Summ;
            row2.PVN = row.PVN;
            row2["DT2"] = row["DT2"];
            DataSetKlonsRep.TRepOPSd.Rows.Add(row2);
            return true;
        }

        public void LoadSettings()
        {
            Settings = KlonsSettings.LoadSettings(SettingsFileName);
            KlonsLIB.MyData.Settings = Settings;
            ColorThemeHelper.MyToolStripRenderer.SetColorTheme(Settings.ColorTheme);
        }

        public void SaveSettings()
        {
            Settings.SaveSettings(SettingsFileName);
        }

        public void LoadMasterList()
        {
            MasterList = Classes.MasterList.LoadList(MasterListFileName);
        }

        public void SaveMasterList()
        {
            MasterList.SaveList(MasterListFileName);
        }

        public void Dispose()
        {
            _KlonsData = null;
        }
    }

}
