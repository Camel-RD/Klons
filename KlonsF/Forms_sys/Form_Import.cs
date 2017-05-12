using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsF.DataSets;
using KlonsF.Classes;
using KlonsF.UI;
using KlonsLIB.Forms;
using KlonsLIB.Data;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using FirebirdSql.Data.FirebirdClient;

namespace KlonsF.Forms
{
    public partial class Form_Import : MyFormBaseF
    {
        public Form_Import()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            var kv = new[] {
                new { key = 0, val = "neko" },
                new { key = 1, val = "jaunos" },
                new { key = 2, val = "visus" }
            };
            dgcTask.DataSource = kv;
            dgcTask.ValueMember = "key";
            dgcTask.DisplayMember = "val";
        }

        public List<CellError> ErrorList = null;
        public WorkBookConfig WorkBookConfig = null;
        public string FileName = null;

        private void Form_Import_Load(object sender, EventArgs e)
        {
            dgvCount.AutoGenerateColumns = false;
        }

        public void GetCounts()
        {
            WorkBookConfig.GetCount();
            bsCount.DataSource = WorkBookConfig.SheetsConfig;
        }

        public void DoTestRun()
        {

            FileStream fs = null;
            try
            {
                fs = new FileStream(FileName, FileMode.Open);
            }
            catch (Exception)
            {
                MyMainForm.ShowWarning("Neizdevās atvērt failu:\n" + FileName);
                return;
            }


            if (WorkBookConfig != null)
            {
                bsCount.DataSource = null;
                WorkBookConfig.WB.Close();
                WorkBookConfig.Stream.Close();
            }

            WorkBookConfig = new WorkBookConfig(fs);
            int rowscount = WorkBookConfig.GetFirstCount();
            ErrorList = null;

            var fmpr = new Form_Progress();
            fmpr.Message = "Pārbaudam XLS failu ...";
            fmpr.MaxProgress = rowscount;


            WorkBookConfig.ProgressChanged += (sender, arg) =>
            {
                fmpr.Progress = WorkBookConfig.RowsDone;
            };

            fmpr.OnCancel = () =>
            {
                WorkBookConfig.Cancel = true;
            };

            fmpr.RunThis = () =>
            {
                Task.Factory.StartNew(() =>
                {
                    ErrorList = WorkBookConfig.TestXLS();

                }).ContinueWith((t) => {

                    fmpr.Close();

                    GetCounts();
                    SetSkipDocs(false);

                    if (WorkBookConfig.Cancel)
                    {
                        MyMainForm.ShowInfo("XLS faila pārbaude pātraukts.");
                    }
                    else if (t.IsFaulted)
                    {
                        var me = new MyException("XLS faila pārbaude neizdevās.", t.Exception);
                        Form_Error.ShowException(me);
                    }
                    else
                    {
                        MyMainForm.ShowInfo("XLS faila pārbaude pabeigta.");
                    }

                }, TaskScheduler.FromCurrentSynchronizationContext());
            };

            fmpr.ShowDialog(MyMainForm);
        }

        public void DoImport()
        {
            var fmpr = new Form_Progress();
            fmpr.Message = "Importējam datus ...";
            fmpr.MaxProgress = WorkBookConfig.RowCount;

            WorkBookConfig.ProgressChanged += (sender, arg) =>
            {
                fmpr.Progress = WorkBookConfig.RowsDone;
            };

            fmpr.OnCancel = () =>
            {
                WorkBookConfig.Cancel = true;
            };

            ActOnRowUpdated = () =>
            {
                WorkBookConfig.RowsDone++;
                fmpr.Progress = WorkBookConfig.RowsDone;
            };

            string er = null;

            fmpr.RunThis = () =>
            {
                Task.Factory.StartNew(() =>
                {
                    er = WorkBookConfig.ImportXLS();
                    if (er != "OK") return;

                    fmpr.Message = "Numurējam ierakstus ...";
                    SetNewIDs(myAdapterManager1);

                    fmpr.Message = "Saglabājam izmaiņas ...";
                    WorkBookConfig.RowsDone = 0;
                    fmpr.Progress = 0;
                    fmpr.MaxProgress = WorkBookConfig.GetUpdateCount();
                    WireAdapterEvents();
                    myAdapterManager1.UpdateAll(true);

                }).ContinueWith((t) => {

                    UnWireAdapterEvents();
                    ActOnRowUpdated = null;

                    fmpr.Close();

                    if (WorkBookConfig.Cancel)
                    {
                        MyMainForm.ShowInfo("Datu imports pātraukts.");
                        RejectChanges();
                    }
                    else if (t.IsFaulted)
                    {
                        var me = new MyException("Datu imports neizdevās.", t.Exception);
                        Form_Error.ShowException(me);
                        RejectChanges();
                    }
                    else if(er != "OK")
                    {
                        var me = new MyException("Datu imports neizdevās.", new Exception(er));
                        Form_Error.ShowException(me);
                        RejectChanges();
                    }
                    else
                    {
                        MyMainForm.ShowInfo("Datu imports pabeigts.");
                        WorkBookConfig.ImportDone = true;
                    }

                }, TaskScheduler.FromCurrentSynchronizationContext());
            };

            fmpr.ShowDialog(MyMainForm);
        }


        public void RejectChanges()
        {
            var ds = MyData.DataSetKlons;
            ds.OPS.RejectChanges();
            ds.OPSd.RejectChanges();
            ds.AcP21.RejectChanges();
            ds.AcP24.RejectChanges();
            ds.Acp25.RejectChanges();
            ds.Persons.RejectChanges();
            ds.DocTyp.RejectChanges();
            ds.Currency.RejectChanges();
        }

        public FbDataAdapter[] GetAdapters()
        {
            var ds = MyData.DataSetKlons;
            return new FbDataAdapter[] { 
                MyData.GetSqlDataAdapter(ds.OPS) as FbDataAdapter,
                MyData.GetSqlDataAdapter(ds.OPSd) as FbDataAdapter,
                MyData.GetSqlDataAdapter(ds.AcP21) as FbDataAdapter,
                MyData.GetSqlDataAdapter(ds.AcP24) as FbDataAdapter,
                MyData.GetSqlDataAdapter(ds.Acp25) as FbDataAdapter,
                MyData.GetSqlDataAdapter(ds.Persons) as FbDataAdapter,
                MyData.GetSqlDataAdapter(ds.DocTyp) as FbDataAdapter,
                MyData.GetSqlDataAdapter(ds.Currency) as FbDataAdapter
            };
        }

        public void WireAdapterEvents()
        {
            var adrs = GetAdapters();
            foreach(var ad in adrs)
            {
                ad.RowUpdated += Adapter_RowUpdated;
            }
        }

        public void UnWireAdapterEvents()
        {
            var adrs = GetAdapters();
            foreach (var ad in adrs)
            {
                ad.RowUpdated -= Adapter_RowUpdated;
            }
        }

        private Action ActOnRowUpdated = null;

        private void Adapter_RowUpdated(object sender, FbRowUpdatedEventArgs e)
        {
            if (ActOnRowUpdated == null) return;
            ActOnRowUpdated();
        }

        public void SetNewIDs(MyAdapterManager adaptermanager)
        {
            if (adaptermanager.TableNames == null) return;
            SetNewIDs(adaptermanager.TableNames);
        }

        public void SetNewIDs(params string[] tablenames)
        {
            DataRow[] drs;
            int ct = 0, nr = 0, znr = 0;
            foreach (var tablename in tablenames)
            {
                switch (tablename)
                {
                    case "OPS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.OPS);
                        ct = drs.Where(d => ((klonsDataSet.OPSRow)d).id < 0).Count();
                        if (ct == 0) break;
                        nr = (int)MyData.KlonsQueriesTableAdapter.SP_OPS_IDK(ct) - ct + 1;
                        for (int i = 0; i < ct; i++)
                        {
                            var dr = drs[i];
                            var pdr = dr as klonsDataSet.OPSRow;
                            if (pdr.id >= 0) continue;
                            pdr.id = nr + i;
                        }
                        break;

                    case "OPSd":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.OPSd);
                        ct = drs.Where(d => ((klonsDataSet.OPSdRow)d).id < 0).Count();
                        if (ct == 0) break;
                        nr = (int)MyData.KlonsQueriesTableAdapter.SP_OPSD_IDK(ct) - ct + 1;

                        var dic_yrs = new Dictionary<int, int>();
                        foreach(var dr in drs)
                        {
                            var pdr = dr as klonsDataSet.OPSdRow;
                            int yr = pdr.Dete.Year;
                            if (!dic_yrs.TryGetValue(yr, out int k)) dic_yrs[yr] = 1;
                            else dic_yrs[yr] = k + 1;
                        }
                        var dic_yrs2 = new Dictionary<int, int>();
                        foreach (var kv in dic_yrs)
                        {
                            znr = (int)MyData.KlonsQueriesTableAdapter.SP_OPSD_GETNEXTNRFORYEARA_K(kv.Key, kv.Value);
                            znr = znr - kv.Value + 1;
                            dic_yrs2[kv.Key] = znr;
                        }
                        dic_yrs = dic_yrs2;

                        for (int i = 0; i < ct; i++)
                        {
                            var dr = drs[i];
                            var pdr = dr as klonsDataSet.OPSdRow;
                            if (pdr.id >= 0) continue;
                            pdr.id = nr + i;
                            var yr = pdr.Dete.Year;
                            znr = dic_yrs[yr];
                            pdr.ZNR = znr;
                            dic_yrs[yr] = znr + 1;
                        }
                        break;
                }
            }
        }


        public bool SaveAllData()
        {
            try
            {
                SetNewIDs(myAdapterManager1);
                myAdapterManager1.UpdateAll();
            }
            catch (Exception e)
            {
                Form_Error.ShowException(e, "Neizdevās saglabāt izmaiņas.");
                return false;
            }
            return true;
        }


        private void cmImport_Click(object sender, EventArgs e)
        {
            if(WorkBookConfig == null)
            {
                MyMainForm.ShowInfo("Nav norādīts importējamais XLS fails.");
                return;
            }
            if (WorkBookConfig.ImportDone)
            {
                MyMainForm.ShowInfo("Dati tika jau importēti.");
                return;
            }
            WorkBookConfig.GetCount();
            if (WorkBookConfig.RowCountBad > 0)
            {
                MyMainForm.ShowInfo("Norādītajā XLS failā tika atrastas kļūdas.");
                return;
            }
            DoImport();
        }

        public void SetSkipDocs(bool skip)
        {
            for (int i = 1; i < WorkBookConfig.SheetsConfig.Count; i++)
            {
                WorkBookConfig.SheetsConfig[i].Task = ESheetTask.AddNew;
            }
            if (skip)
            {
                WorkBookConfig.SheetsConfig[0].Task = ESheetTask.Ignore;
                var kv = new[]{
                    new { key = ESheetTask.Ignore, val = "neko" },
                    new { key = ESheetTask.AddNew, val = "jaunos" },
                    new { key = ESheetTask.DoAll, val = "visus" }
                };
                dgcTask.DataSource = kv;
                dgcTask.ValueMember = "key";
                dgcTask.DisplayMember = "val";

            }
            else
            {
                WorkBookConfig.SheetsConfig[0].Task = ESheetTask.AddNew;
                var kv = new[] {
                    new { key = ESheetTask.AddNew, val = "jaunos" },
                    new { key = ESheetTask.DoAll, val = "visus" }
                };
                dgcTask.DataSource = kv;
                dgcTask.ValueMember = "key";
                dgcTask.DisplayMember = "val";
            }

            IgnoreSkipDocsEvent = true;
            if(chSkipDocs.Checked != skip) chSkipDocs.Checked = skip;
            IgnoreSkipDocsEvent = false;
        }

        private bool IgnoreSkipDocsEvent = false;
        private void chSkipDocs_CheckedChanged(object sender, EventArgs e)
        {
            if (IsLoading || IgnoreSkipDocsEvent || WorkBookConfig == null) return;
            SetSkipDocs(chSkipDocs.Checked);
        }

        private void btGetFile_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.Title = "Norādi importējamo XLS failu";
            fd.CheckFileExists = false;
            fd.Filter = "Excel files (*.xls)|*.xls";
            var rt = fd.ShowDialog(MyMainForm);
            if (rt != DialogResult.OK) return;
            FileName = fd.FileName;
            tbFileName.Text = fd.FileName;
            if (!File.Exists(FileName))
            {
                MyMainForm.ShowWarning("Fails nav atrasts.");
                return;
            }
            DoTestRun();
        }

        private void cmShowErrors_Click(object sender, EventArgs e)
        {
            if(ErrorList == null || ErrorList.Count == 0)
            {
                MyMainForm.ShowInfo("Kļūdu saraksts ir tukšs.");
                return;
            }
            var fm = MyMainForm.ShowFormDialog(typeof(Form_ImportErrors)) as Form_ImportErrors;
            if (fm == null) return;
            fm.SetErrorList(ErrorList);
        }

        private void dgvCount_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(e.RowIndex == 0)
            {
                e.Cancel = true;
            }
        }

        private void Form_Import_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WorkBookConfig != null)
            {
                bsCount.DataSource = null;
                WorkBookConfig.WB.Close();
                WorkBookConfig.Stream.Close();
            }
        }
    }


}