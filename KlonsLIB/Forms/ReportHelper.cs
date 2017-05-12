using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using KlonsLIB.Misc;
using KlonsLIB.Data;
using Microsoft.Reporting.WinForms;

namespace KlonsLIB.Forms
{
    public class SubreportLink
    {
        public string SourceName = null;
        public string[] ParameterNames = null;
        public string[] FieldNamesToFilter = null;

        public SubreportLink(string sourcename, string parametername , string fieldname )
        {
            SourceName = sourcename;
            ParameterNames = new string[] {parametername};
            FieldNamesToFilter = new string[] {fieldname};
        }

        public SubreportLink(string sourcename, string parametername1 ,
            string fieldname1 , string parametername2 , string fieldname2 )
        {
            SourceName = sourcename;
            ParameterNames = new string[] {parametername1, parametername2};
            FieldNamesToFilter = new string[] {fieldname1, fieldname2};
        }
        public string GetFilterString(SubreportProcessingEventArgs e)
        {
            string filter = "", s, s1;
            for (int i = 0; i < ParameterNames.Length; i++)
            {
                s = e.Parameters[ParameterNames[i]].Values[0];
                if (string.IsNullOrEmpty(s)) continue;
                s1 = string.Format("{0} = '{1}'", FieldNamesToFilter[i], s);
                if (filter != "") filter += " AND ";
                filter += s1;
            }
            return filter;
        }
    }

    public class ReportViewerData
    {

        public string FileName = "";
        public Dictionary<string, object> Sources = new Dictionary<string, object>();
        public List<ReportParameter> ReportParameters = new List<ReportParameter>();
        public Dictionary<string, ReportViewerData> SubReports = new Dictionary<string, ReportViewerData>();
        public Dictionary<string, SubreportLink> SubreportLinks = new Dictionary<string, SubreportLink>();
        public Action<SubreportProcessingEventArgs> OnSubreport = null;
        public void AddReportParameter(string key, string data)
        {
            ReportParameters.Add(new ReportParameter(key,  data));
        }
        public void AddReportParameter(string key, string[] data)
        {
            ReportParameters.Add(new ReportParameter(key, data));
        }

        public void AddReportParameters(string[] data)
        {
            ReportParameters.AddRange(ReportHelper.MakeReportParameters(data));
        }

        public void AddSubreportLink(string sourcename, string parametername , string fieldname )
        {
            if(!Sources.Keys.Contains(sourcename))
                throw new ArgumentException();
            if(SubreportLinks.Keys.Contains(sourcename))
                throw new Exception("Link already set");
            SubreportLinks[sourcename] = 
                new SubreportLink(sourcename, parametername, fieldname);
        }
        public void AddSubreportLink(string sourcename, string parametername1 ,
            string fieldname1 , string parametername2 , string fieldname2 )
        {
            if(!Sources.Keys.Contains(sourcename))
                throw new ArgumentException();
            if(SubreportLinks.Keys.Contains(sourcename))
                throw new Exception("Link already set");
            SubreportLinks[sourcename] = 
                new SubreportLink(sourcename, parametername1, fieldname1, parametername2, fieldname2);
        }

        public void SubreportProcessing(SubreportProcessingEventArgs e)
        {
            if(OnSubreport != null)
            {
                OnSubreport(e);
                return;
            }
            string fnm = ReportHelper.ReportNameFromPath(e.ReportPath);
            ReportViewerData rvd = SubReports[fnm];
            foreach (var link in rvd.SubreportLinks.Values)
            {
                DataTable dt = rvd.Sources[link.SourceName] as DataTable;
                DataView dv;
                if (dt == null)
                {
                    dv = rvd.Sources[link.SourceName] as DataView;
                    if (dv == null)
                    {
                        throw new Exception("Not supported DataSource");
                    }
                    dt = dv.Table;
                }
                string filter = link.GetFilterString(e);
                dv = new DataView(dt, filter, null, DataViewRowState.CurrentRows);
                
                e.DataSources.Add(
                    new ReportDataSource(link.SourceName, dv.ToTable()));
            }
        }


    }


    public class ReportHelper
    {
        public static ReportViewerMessages ReportViewerMessages = new ReportViewerMessages();

        public static string ReportNameFromPath(string reportpath)
        {
            return Path.GetFileNameWithoutExtension(reportpath);
        }

        public static ReportParameter[] MakeReportParameters(string[] data)
        {
            if (data == null || data.Length == 0 || data.Length % 2 == 1)
                throw new ArgumentException("MakeReportParameters bad data");
            ReportParameter[] rps = new ReportParameter[data.Length/2];
            for (int i = 0; i < rps.Length; i++)
            {
                rps[i] = new ReportParameter(data[i*2], data[i*2+1]);
            }
            return rps;
        }

        public virtual bool CheckForErrors(Action act)
        {
            return false;
        }

    }
}
