using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using KlonsLIB.Misc;

namespace KlonsLIB.Data
{
    public class KlonsDataModule
    {
        protected static KlonsDataModule _KlonsDataModule = null;

        protected Dictionary<string, DataSetHelper> _dataSetHelpers = new Dictionary<string, DataSetHelper>();

        public static KlonsDataModule St
        {
            get
            {
                if (_KlonsDataModule == null) 
                {
                    //_KlonsDataModule = new KlonsDataModule();
                    Debug.Print("KlonsDataModule not created");
                    throw new Exception("KlonsDataModule not created");
                }
                return _KlonsDataModule;
            }
        }

        public KlonsDataModule()
        {
            _KlonsDataModule = this;
        }

        public static string[] GetAllDataSetNames()
        {
            return _KlonsDataModule._dataSetHelpers.Keys.ToArray();
        }

        public DataSet GetDataSet(string name)
        {
            DataSetHelper dsh;
            if (!_dataSetHelpers.TryGetValue(name, out dsh)) return null;
            return dsh.DataSet;
        }

        public string GetDataSetName(DataSet ds)
        {
            foreach (var v in _dataSetHelpers)
            {
                if (v.Value.DataSet == ds)
                    return v.Key;
            }
            return null;
        }
        public DataSetHelper GetDataSetHelper(DataSet ds)
        {
            if (ds == null) return null;
            foreach (var v in _dataSetHelpers)
            {
                if (v.Value.DataSet == ds)
                    return v.Value;
            }
            return null;
        }

        public DataTable GetDataTable(string datasetname, string tablename)
        {
            DataSet ds = GetDataSet(datasetname);
            if (ds == null) return null;
            if (!ds.Tables.Contains(tablename)) return null;
            return ds.Tables[tablename];
        }

        public string[] GetTableNames(string datasetname)
        {
            DataSetHelper dsh;
            if (!_dataSetHelpers.TryGetValue(datasetname, out dsh)) return null;
            var tl = dsh.GetTableList();
            if (tl != null)
                tl = tl.OrderBy(t => t).ToArray();
            return tl;
        }

        public void UpdateTable(DataTable table)
        {
            var ad = GetSqlDataAdapter(table);
            ad.Update(table);
        }

        public DbDataAdapter GetSqlDataAdapter(string datasetname, string datatablename)
        {
            DataSetHelper dsh;
            if (!_dataSetHelpers.TryGetValue(datasetname, out dsh)) return null;
            return dsh.GetSqlDataAdapter(datatablename);
        }

        public DbDataAdapter GetSqlDataAdapter(DataSet dataset, string datatablename)
        {
            DataSetHelper dsh = GetDataSetHelper(dataset);
            if (dsh == null) return null;
            return dsh.GetSqlDataAdapter(datatablename);
        }

        public DbDataAdapter GetSqlDataAdapter(DataTable datatable)
        {
            return GetSqlDataAdapter(datatable.DataSet, datatable.TableName);
        }

        public int FillTable(string datasetname, string tablename)
        {
            DataSetHelper dsh;
            if (!_dataSetHelpers.TryGetValue(datasetname, out dsh))
                throw new Exception("Wrong datasetname");
            return dsh.FillTable(tablename);
        }

        public int FillTable(DataTable dt)
        {
            DataSetHelper dsh = GetDataSetHelper(dt.DataSet);
            if (dsh == null)
                throw new Exception("Table not supported");
            return dsh.FillTable(dt.TableName);
        }
    }
}
