using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KlonsLIB.Forms
{
    public partial class Form_Progress : MyFormBase
    {
        public Form_Progress()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public Action OnCancel = null;
        public Action RunThis = null;
        private bool CanClose = false;
        public int UpdateIntervalMS { get; set; } = 100;

        private System.Diagnostics.Stopwatch Timer = new System.Diagnostics.Stopwatch();

        private void Form_Progress_Load(object sender, EventArgs e)
        {

        }

        private T DoInvodke<T>(Func<T> func)
        {
            if (InvokeRequired) return (T)Invoke(func);
            else return func();
        }

        private void DoInvodke<T>(Action<T> act, T value)
        {
            if (InvokeRequired) Invoke(act, value);
            else act(value);
        }

        public int MaxProgress
        {
            get => progressBar1.Maximum;
            set => DoInvodke((mpr) => {progressBar1.Maximum = mpr;}, value);
        }

        long lastWatch = -1;
        public int Progress
        {
            get { return progressBar1.Value; }
            set
            {
                if (value > progressBar1.Maximum) value = progressBar1.Maximum;
                if (value == progressBar1.Value) return;
                if (!Timer.IsRunning) return;
                if (lastWatch == -1)
                    lastWatch = Timer.ElapsedMilliseconds;
                if (value < MaxProgress && Timer.ElapsedMilliseconds - lastWatch < UpdateIntervalMS) return;
                DoInvodke((pr) => { SetProgress(pr); }, value);
                lastWatch = Timer.ElapsedMilliseconds;
            }
        }

        private void SetProgress(int value)
        {
            progressBar1.Value = value;
        }

        public string Message
        {
            get => DoInvodke(() => { return label1.Text; });
            set => DoInvodke((s) => { label1.Text = s; }, value);
        }

        public new void Close()
        {
            CanClose = true;
            if(Modal)
                DialogResult = DialogResult.OK;
            else
                base.Close();
        }

        private void cmCancel_Click(object sender, EventArgs e)
        {
            if (OnCancel != null)
            {
                var onc = OnCancel;
                OnCancel = null;
                onc();
            }
        }

        private void Form_Progress_Shown(object sender, EventArgs e)
        {
            Timer.Start();
            if (RunThis != null) RunThis();
        }
        private void Form_Progress_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnCancel = null;
            RunThis = null;
            Timer.Stop();
        }
        private void Form_Progress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                e.Cancel = true;
                return;
            }
        }

    }
}
