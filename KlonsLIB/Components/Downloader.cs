using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Timers;
using System.Threading.Tasks;

namespace KlonsLIB.Components
{
    public class ADownloader : Component
    {
        public enum EDownloadStatus
        {
            none, started, finished, failed, canceled, timeout
        }

        private string DataRecieved = null;
        private WebClient webClient = null;
        private System.Timers.Timer aTimer = null;
        private bool Downloading = false;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EDownloadStatus DownloadStatus { get; private set; }

        [Category("My")]
        public string URL { get; set; }

        [Category("My")]
        public event EventHandler DataReceived;

        [Category("My")]
        public event EventHandler DownloadFailed;

        public ADownloader()
        {
            DownloadStatus = EDownloadStatus.none;
            DataRecieved = null;
            URL = "";
        }

        public string GetData()
        {
            return DataRecieved;
        }

        public bool StartDownload()
        {
            //if (DownloadStatus == EDownloadStatus.started) return false;
            try
            {
                DataRecieved = null;
                DownloadStatus = EDownloadStatus.started;
                Downloading = false;
                Task.Factory.StartNew(() => StartDownloadA());
                //StartDownloadA();
            }
            catch (Exception)
            {
                DownloadStatus = EDownloadStatus.failed;
                Downloading = false;
                return false;
            }
            return true;
        }

        private void StartDownloadA()
        {
            webClient = new WebClient();
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(ReadCompleted);
            aTimer = new System.Timers.Timer(3000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = false;
            webClient.Proxy = null;
            aTimer.Enabled = true;
            webClient.OpenReadAsync(new Uri(URL));
            Downloading = true;
        }

        private void OnDownloadFailed()
        {
            if (DownloadFailed != null)
                DownloadFailed(this, null);
        }

        public void ReadCompleted(Object sender, OpenReadCompletedEventArgs e)
        {
            Downloading = false;
            aTimer.Stop();

            if (e.Cancelled)
            {
                DownloadStatus = EDownloadStatus.timeout;
                OnDownloadFailed();
                return;
            }
            if (e.Error != null)
            {
                DownloadStatus = EDownloadStatus.failed;
                OnDownloadFailed();
                return;
            }

            Stream reply = null;
            StreamReader s = null;

            try
            {
                reply = (Stream) e.Result;
                if (reply == null) return;
                s = new StreamReader(reply);
                DataRecieved = s.ReadToEnd();
                DownloadStatus = EDownloadStatus.finished;
                if (DataReceived != null)
                {
                    DataReceived(this, new EventArgs());
                }
            }
            catch(Exception)
            {
                OnDownloadFailed();
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }

                if (reply != null)
                {
                    reply.Close();
                }
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Stop();
            DownloadStatus = EDownloadStatus.failed;
        }

        private void Stop()
        {
            aTimer.Enabled = false;
            if (!Downloading) return;
            Downloading = false;
            try
            {
                webClient.CancelAsync();
            }
            catch (Exception)
            {
            }
        }

        public void Cancel()
        {
            Stop();
            DownloadStatus = EDownloadStatus.canceled;
        }

    }
}
