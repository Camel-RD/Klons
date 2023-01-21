using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.DataSets;
using KlonsFM.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Data;
using KlonsFM.UI;
using FirebirdSql.Data.FirebirdClient;
using System.Threading;
using System.Diagnostics;
using KlonsLIB.Misc;

namespace KlonsFM.FormsM
{
    public partial class FormM_SPRunner : MyFormBaseF
    {
        public FormM_SPRunner()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            progressBar1.Visible = false;

            int lbmw = Width - 2 * lbTaskText.Left;
            int lbmh = lbTaskText.MaximumSize.Height;
            lbTaskText.MaximumSize = new Size(lbmw, lbmh);

            _syncContext = SynchronizationContext.Current;
            sw.Start();
        }

        private void FormM_SPRunner_Load(object sender, EventArgs e)
        {
            Init();
        }

        public void Init()
        {
            if (HasProgressEvents)
            {
                progressBar1.Maximum = MaxProgressValue;
            }
            lbTaskText.Text = TaskText;
            lbWait.Text = null;
        }

        enum ETaskState { WaitingToStart, Starting, Started, Canceled, Finished }

        public Func<object> TaskFunc = null;
        public FbCommand SPCommand = null;
        public string TaskText = null;
        public string TextDoneText = null;
        public bool HasProgressEvents = false;
        public int MaxProgressValue = 0;
        public int ProgressEventStep = 0;
        public bool CanCancel = false;

        public object TaskResult = null;

        ETaskState TaskState = ETaskState.WaitingToStart;

        int ProgressCurrentStep = 0;

        SynchronizationContext _syncContext = null;

        FbConnection FbCon = null;
        FbRemoteEvent FbEvents = null;
        int SessionId = 0;

        Stopwatch sw = new Stopwatch();
        TimeSpan LastProgresUpdate = TimeSpan.Zero;
        TimeSpan TaskStartTsp = TimeSpan.Zero;

        private void RunInGUIContext(Action<object> act, object state = null)
        {
            _syncContext.Post(new SendOrPostCallback(act), state);
        }

        public async Task<bool> DoConnect()
        {
            var (ret1, ret2) = await RunSp(DoConnectA);
            return ret1;
        }

        public async Task<bool> DoConnectA()
        {
            var ds_helper = MyData.GetDataSetHelper(MyData.DataSetKlonsM);
            var sfc = ds_helper.ConnectionString;
            FbCon = new FbConnection(sfc);
            await FbCon.OpenAsync();

            var fcm = new FbCommand("select current_connection from rdb$database;", FbCon);
            SessionId = (int)await fcm.ExecuteScalarAsync();

            FbEvents = new FbRemoteEvent(sfc);
            await FbEvents.OpenAsync();
            var eventnames = new []{ "Progress_" + SessionId };
            await FbEvents.QueueEventsAsync(eventnames);
            FbEvents.RemoteEventCounts += FbEvents_RemoteEventCounts;

            return true;
        }

        void UpdateProgress()
        {
            var ts = sw.Elapsed;
            if ((ts - LastProgresUpdate).TotalSeconds < 1) return;
            LastProgresUpdate = ts;
            RunInGUIContext((o) => UpdateProgressA(), null);
        }

        void UpdateProgressA()
        {
            int k = Math.Min(ProgressCurrentStep * ProgressEventStep, progressBar1.Maximum);
            progressBar1.Value = k;
        }

        private void FbEvents_RemoteEventCounts(object sender, FbRemoteEventCountsEventArgs e)
        {
            ProgressCurrentStep += e.Counts;
            UpdateProgress();
        }

        private void FormM_SPRunner_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FbEvents != null)
            {
                FbEvents.Dispose();
            }
            if (FbCon != null)
            {
                if (FbCon.State == ConnectionState.Open)
                    FbCon.Close();
                FbCon.Dispose();
            }
        }

        void OnTaskStarted()
        {
            lbWait.Text = "Uzgaidi...";
            progressBar1.Visible = HasProgressEvents;
            btDoIt.Visible = CanCancel;
            btDoIt.Text = "Atcelt";
        }

        void OnTaskCancelled()
        {
            lbWait.Text = "Darbība pārtraukta.";
            btDoIt.Text = "Aizvērt";
            btDoIt.Visible = true;
            //MyMainForm.ShowWarning("Darbība pārtraukta.", "", this);
            //DialogResult = DialogResult.Abort;
        }

        void OnTaskCompleted()
        {
            lbWait.Text = "Darbība pabeigta.";
            var tsp = sw.Elapsed - TaskStartTsp;
            var msg = $"{tsp.Hours:00}:{tsp.Minutes:00}:{tsp.Seconds:00}";
            msg = string.Format(TextDoneText, msg);
            lbWait.Text = msg;
            btDoIt.Text = "Aizvērt";
            btDoIt.Visible = true;
            //MyMainForm.ShowInfo(msg, "", this);
            //DialogResult = DialogResult.OK;
        }

        private void ShowException(Exception ex, out bool iscanceled)
        {
            iscanceled = false;
            if (ex == null) return;
            
            Exception ex1 = null;

            if (ex is OperationCanceledException ex3)
            {
                if (ex3.Message.ToLower().Contains("cancel"))
                {
                    iscanceled = true;
                    return;
                }
                ex1 = ex3;
            }
            ex1 = ex.InnerException == null ? ex : ex.InnerException;

            string msg = DataTasks.GetErrorInfoFromMessage(ex1.Message);
            if (msg == ex1.Message)
            {
                RunInGUIContext(_ =>
                    Form_Error.ShowException(ex1, "Neizdevās pabeigt uzsākto darbību."));
            }
            else
            {
                RunInGUIContext(_ =>
                    Form_Error.ShowException(new MyException(msg)));
            }
        }

        public async Task<(bool, TRet)> RunSp<TRet>(Func<Task<TRet>> functask)
        {
            Exception ex0 = null;
            try
            {
                TRet ret = await functask();
                return (true, ret);
            }
            catch (Exception ex)
            {
                ex0 = ex;
            }

            ShowException(ex0, out bool iscanceled);
            return (false, default(TRet));
        }

        public async Task<(bool, TRet)> RunSp2<TRet>(Func<TRet> functask)
        {
            Exception ex0 = null;
            TRet ret = default;

            try
            {
                ret = await Task.Run(() =>
                {
                    try
                    {
                        return functask();
                    }
                    catch (Exception ex)
                    {
                        ex0 = ex;
                    }
                    return default(TRet);
                });
                return (true, ret);
            }
            catch (Exception ex)
            {
                ex0 = ex;
            }

            ShowException(ex0, out bool iscanceled);
            return (false, default(TRet));
        }

        private async Task<bool> DoTask()
        {
            TaskState = ETaskState.Starting;
            if (CanCancel)
            {
                bool rt = await DoConnect().ConfigureAwait(true);
                CanCancel = rt;
                HasProgressEvents = rt;
                progressBar1.Visible = rt;
            }
            TaskState = ETaskState.Started;
            OnTaskStarted();
            TaskStartTsp = sw.Elapsed;

            bool bret;
            object oret;

            if (SPCommand == null)
            {
                (bret, oret) = await RunSp2(TaskFunc).ConfigureAwait(true);
            }
            else
            {
                SPCommand.Connection = FbCon;
                (bret, oret) = await RunSp(SPCommand.ExecuteScalarAsync).ConfigureAwait(true);
            }

            TaskResult = oret;
            if (bret)
            {
                TaskState = ETaskState.Finished;
                OnTaskCompleted();
            }
            else
            {
                TaskState = ETaskState.Canceled;
                OnTaskCancelled();
            }
            return true;
        }

        async Task DoCancelTask()
        {
            try
            {
                await FbCon.CancelCommandAsync();
            }
            catch(Exception ex)
            {

            }
        }

        private async void btDoIt_Click(object sender, EventArgs e)
        {
            if(TaskState == ETaskState.WaitingToStart)
            {
                await DoTask();
                return;
            }
            if (TaskState == ETaskState.Started && CanCancel &&
                FbCon != null && FbCon.State == ConnectionState.Open)
            {
                await DoCancelTask();
                return;
            }
            if (TaskState == ETaskState.WaitingToStart)
            {
                await DoTask();
                return;
            }
            if (TaskState == ETaskState.Finished)
            {
                DialogResult = DialogResult.OK;
                return;
            }
            if (TaskState == ETaskState.Canceled)
            {
                DialogResult = DialogResult.Abort;
                return;
            }
        }

        private void FormM_SPRunner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TaskState == ETaskState.Started)
            {
                e.Cancel = true;
            }
        }
    }
}
