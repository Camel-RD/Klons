using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.Classes;
using KlonsLIB.Forms;
using Microsoft.Reporting.WinForms;
using KlonsFM.UI;

namespace KlonsFM.Forms
{
    public partial class Form_ReportViewer : MyFormBaseF
    {
        public Form_ReportViewer()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private ReportViewerData reportViewerData;

        public Form_ReportViewer(ReportViewerData reportViewerData)
        {
            InitializeComponent();
            CheckMyFontAndColors();
            reportViewer1.Messages = ReportHelper.ReportViewerMessages;

            this.reportViewerData = reportViewerData;

            foreach (var source in reportViewerData.Sources)
            {
                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource(source.Key, source.Value));
            }

            //reportViewer1.LocalReport.ReportEmbeddedResource = "KlonsF.Reports.Report1.rdlc";
            reportViewer1.LocalReport.ReportPath = KlonsData.GetBasePath() + "\\Reports\\" + reportViewerData.FileName + ".rdlc";
            if (reportViewerData.ReportParameters != null)
                reportViewer1.LocalReport.SetParameters(reportViewerData.ReportParameters);
            reportViewer1.LocalReport.SubreportProcessing += reportViewer1_SubreportProcessing;
            
        }

        private void reportViewer1_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            reportViewerData.SubreportProcessing(e);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int zoom = MyData.Settings.ReportZoom;
            if (zoom < 10 || zoom > 500) zoom = 100;
            try
            {
                reportViewer1.ZoomPercent = zoom;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.Close();
                Form_Error.ShowException(MyMainForm, new MyException("Neizdevās atvērt atskaiti", ex));
            }
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            //reportViewer1.ZoomMode = ZoomMode.PageWidth;
            //reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void Form_ReportViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyData.Settings.ReportZoom = reportViewer1.ZoomPercent;
        }
    }
}
