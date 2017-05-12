using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
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

namespace KlonsF.Forms
{
    public partial class Form_Export : MyFormBaseF
    {
        public Form_Export()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public RowsData RowsData = new RowsData();
        public WorkBookConfig WorkBookConfig = null;

        private void Form_Export_Load(object sender, EventArgs e)
        {
            dgvCount.AutoGenerateColumns = false;
            GetRows();
        }

        public void GetRows()
        {
            RowsData.GetRows();
            var counts = RowsData.GetCounts();
            RowsData.GetTotalRowCount();
            bsCount.DataSource = counts;
        }

        public void GetRowsFull()
        {
            RowsData.GetRowsFull();
            var counts = RowsData.GetCounts();
            RowsData.GetTotalRowCount();
            bsCount.DataSource = counts;
        }

        public void Export()
        {
            var fd = new OpenFileDialog();
            fd.CheckFileExists = false;
            fd.Title = "Eksportēt uz XLS failu";
            fd.Filter = "Excel files (*.xls)|*.xls";
            var rt = fd.ShowDialog(MyMainForm);
            if (rt != DialogResult.OK) return;
            var filename = fd.FileName;
            if (File.Exists(filename))
            {
                try
                {
                    File.Delete(filename);
                }
                catch(Exception )
                {
                    MyMainForm.ShowWarning("Neizdevās izdzēst failu:\n" + filename);
                    return;
                }

            }

            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.CreateNew);
            }
            catch (Exception)
            {
                MyMainForm.ShowWarning("Neizdevās izveidot failu:\n" + filename);
                return;
            }

            void InvokeAction(Action act)
            {
                if (InvokeRequired)
                    Invoke(act);
                else
                    act();
            }

            WorkBookConfig = new WorkBookConfig();
            WorkBookConfig.InitCellStyles();

            var fmpr = new Form_Progress();
            fmpr.Message = "Notiek datu eksports ...";
            fmpr.MaxProgress = RowsData.TotalRowCount;

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
                    RowsData.ExportToXLS(WorkBookConfig);
                    if (WorkBookConfig.Cancel) return;
                    WorkBookConfig.WB.Write(fs);

                }).ContinueWith((t)=> {

                    WorkBookConfig.WB.Close();
                    fs.Close();
                    fmpr.Close();

                    if (WorkBookConfig.Cancel)
                    {
                        MyMainForm.ShowInfo("Datu eksports pātraukts.");
                    }
                    else if (t.IsFaulted)
                    {
                        var me = new MyException("Datu eksports neizdevās.", t.Exception);
                        Form_Error.ShowException(me);
                    }
                    else
                    {
                        MyMainForm.ShowInfo("Darīts!");
                    }

                }, TaskScheduler.FromCurrentSynchronizationContext());
            };

            fmpr.ShowDialog(MyMainForm);
        }


        private void cmExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void chOnlyUsed_CheckedChanged(object sender, EventArgs e)
        {
            if (IsLoading) return;
            if (chOnlyUsed.Checked)
                GetRows();
            else
                GetRowsFull();
        }
    }


}