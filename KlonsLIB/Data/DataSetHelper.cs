using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using FirebirdSql.Data.FirebirdClient;
using KlonsLIB.Misc;

namespace KlonsLIB.Data
{
    public class DataSetHelper
    {
        private Type _dataSetType = null;
        private Type _tableAdapterManagerType = null;
        private Type _queriesTableAdapterType = null;

        public DataSet DataSet { get; private set; }
        public Component TableAdapterManager { get; private set; }
        public Component QueriesTableAdapter { get; private set; }

        private Dictionary<string, object> dataAdapters = new Dictionary<string, object>();
        private Dictionary<string, DbDataAdapter> sqlDataAdapters = new Dictionary<string, DbDataAdapter>();

        public string ConnectionString { get; private set; }
        public string ConnectionStringName { get; private set; }

        private System.Configuration.ApplicationSettingsBase Settings = null;

        public DataSetHelper(DataSet dataset, 
            Component tableadaptermanager, 
            Component queriestableadapter, 
            string connectionstringname,
            System.Configuration.ApplicationSettingsBase settings)
        {
            if (dataset == null || tableadaptermanager == null)
                throw new ArgumentNullException();
            Settings = settings;
            ConnectionStringName = connectionstringname;
            DataSet = dataset;
            TableAdapterManager = tableadaptermanager;
            QueriesTableAdapter = queriestableadapter;
            _dataSetType = DataSet.GetType();
            _tableAdapterManagerType = TableAdapterManager.GetType();
        }

        public DataSetHelper(Type datasettype, 
            Type tableadaptermanagertype,
            Type queriestableadaptertype,
            string connectionstringname,
            System.Configuration.ApplicationSettingsBase settings)
        {
            if (datasettype == null || tableadaptermanagertype == null)
                throw new ArgumentNullException();
            Settings = settings;
            ConnectionStringName = connectionstringname;
            _dataSetType = datasettype;
            _tableAdapterManagerType = tableadaptermanagertype;
            _queriesTableAdapterType = queriestableadaptertype;
            DataSet = Activator.CreateInstance(_dataSetType) as DataSet;
            TableAdapterManager = null;
            QueriesTableAdapter = null;
            if (_tableAdapterManagerType != null)
                TableAdapterManager = Activator.CreateInstance(_tableAdapterManagerType) as Component;
            if (_queriesTableAdapterType != null)
                QueriesTableAdapter = Activator.CreateInstance(_queriesTableAdapterType) as Component;
        }

        public object GetNewTableAdapterManager()
        {
            if (_tableAdapterManagerType == null) return null;
            return Activator.CreateInstance(_tableAdapterManagerType);
        }

        public void ConnectTo(string connectionstring)
        {
            ConnectToBase(connectionstring);
            SetUpTableManager();
        }

        public void ConnectToBase(string connectionstring)
        {
            sqlDataAdapters.Clear();
            dataAdapters.Clear();

            DataSet = Activator.CreateInstance(_dataSetType) as DataSet;
            if (_tableAdapterManagerType != null)
                TableAdapterManager = Activator.CreateInstance(_tableAdapterManagerType) as Component;
            if (_queriesTableAdapterType != null)
                QueriesTableAdapter = Activator.CreateInstance(_queriesTableAdapterType) as Component;

            ConnectionString = connectionstring;
            Settings[ConnectionStringName] = connectionstring;
        }

        public void SetUpTableManager()
        {
            GetDataAdapterList();
        }

        public DataTable GetDataTable(string tablename)
        {
            if (!DataSet.Tables.Contains(tablename)) return null;
            return DataSet.Tables[tablename];
        }

        public DbDataAdapter GetSqlDataAdapter(string tablename)
        {
            DbDataAdapter ad;
            if (!sqlDataAdapters.TryGetValue(tablename, out ad)) return null;
            return ad;
        }
        public object GetDataAdapter(string tablename)
        {
            object ad;
            if (!dataAdapters.TryGetValue(tablename, out ad)) return null;
            return ad;
        }
        public T GetDataAdapter<T>()
        {
            foreach (var o in dataAdapters.Values)
            {
                if (o is T) return (T)o;
            }
            return default(T);
        }


        public void SetClearBeforeFillForAll(bool value)
        {
            foreach (var o in dataAdapters.Values)
            {
                o.GetType().GetProperty("ClearBeforeFill").SetValue(o, value, null);
            }
        }
        public void SetClearBeforeFillFor(bool value, params string[] tablenames)
        {
            if (tablenames == null || tablenames.Length == 0) return;
            object o;
            foreach (string s in tablenames)
            {
                o = dataAdapters[s];
                o.GetType().GetProperty("ClearBeforeFill").SetValue(o, value, null);
            }
        }

        public void CreateAdapterForTable(string tablename)
        {
            if (String.IsNullOrEmpty(tablename))
                throw new ArgumentException();

            string send = "TableAdapter";
            string mend = "TableAdapterManager";
            string mstart = _tableAdapterManagerType.FullName;
            mstart = mstart.Substring(0, mstart.Length - mend.Length);
            string adaptertypename = mstart + tablename + send;

            Type tp = _tableAdapterManagerType.Assembly.GetType(adaptertypename, false, true);
            Object o = Activator.CreateInstance(tp);

            Type mtp = TableAdapterManager.GetType();
            PropertyInfo pri = mtp.GetProperty(tablename + send);
            if (pri != null)
                pri.SetValue(TableAdapterManager, o, null);

            dataAdapters[tablename] = o;
            sqlDataAdapters[tablename] = GetHiddenProperty(o, "Adapter") as DbDataAdapter;
        }

        public void FillTables(params string[] tablenames)
        {
            if (tablenames == null || tablenames.Length == 0) return;
            foreach (string s in tablenames)
            {
                FillTable(s);
            }
        }
        public int FillTable(string tablename)
        {
            if(String.IsNullOrEmpty(tablename))
                throw new ArgumentException();
            
            DataTable dt = DataSet.Tables[tablename];
            
            if(dt == null)
                throw new Exception("Table [" + tablename + "] not found.");

            Object adapter = dataAdapters[tablename];

            if (adapter == null)
                throw new Exception("Adapter for [" + tablename + "] not found.");

            MethodInfo mi = adapter.GetType().GetMethod("Fill", new Type[] {dt.GetType()});

            try
            {
                return (int) mi.Invoke(adapter, new object[] {dt});
            }
            catch (TargetInvocationException ex)
            {
                if (ex.InnerException == null) 
                    throw ex;

                if (ex.InnerException is ConstraintException)
                    throw new DetailedConstraintException("Error filling table", dt, ex.InnerException);
            }
            return -1;
        }
        public int FillTable2(string tablename, bool clearbefore)
        {
            if (String.IsNullOrEmpty(tablename))
                throw new ArgumentException();

            DataTable dt = DataSet.Tables[tablename];

            if (dt == null)
                throw new Exception("Table [" + tablename + "] not found.");

            Object adapter = dataAdapters[tablename];

            if (adapter == null)
                throw new Exception("Adapter for [" + tablename + "] not found.");

            MethodInfo mi = adapter.GetType().GetMethod("Fill", new Type[] { dt.GetType() });
            bool cb = false;
            try
            {
                cb = (bool)Utils.GetProperty(adapter, "ClearBeforeFill");
                Utils.SetProperty(adapter, "ClearBeforeFill", clearbefore);
                return (int)mi.Invoke(adapter, new object[] { dt });
            }
            catch (TargetInvocationException ex)
            {
                if (ex.InnerException == null)
                    throw ex;

                if (ex.InnerException is ConstraintException)
                    throw new DetailedConstraintException("Error filling table", dt, ex.InnerException);
            }
            finally
            {
                Utils.SetProperty(adapter, "ClearBeforeFill", cb);
            }

            return -1;
        }

        public string[] GetTableList()
        {
            string[] ss = new string[DataSet.Tables.Count];
            for (int i = 0; i < ss.Length; i++)
            {
                ss[i] = DataSet.Tables[i].TableName;
            }
            Array.Sort(ss);
            return ss;
        }

        private object GetHiddenProperty(object o, string propname)
        {
            PropertyInfo pri = o.GetType().GetProperty(propname,
                BindingFlags.NonPublic | BindingFlags.Public |
                BindingFlags.Instance | BindingFlags.Static);

            return pri.GetValue(o, null);
        }

        private const string adapterClassSuffix = "TableAdapter";
        private const string adapterManagerClassSuffix = "TableAdapterManager";
        private void GetDataAdapterList()
        {
            string mstart = _tableAdapterManagerType.FullName;
            mstart = mstart.Substring(0, mstart.Length - adapterManagerClassSuffix.Length);
            Type tp;
            string s;
            Object o;
            PropertyInfo pri;
            Type mtp = TableAdapterManager.GetType();

            sqlDataAdapters.Clear();
            dataAdapters.Clear();

            foreach (DataTable dt in DataSet.Tables)
            {
                s = mstart + dt.TableName + adapterClassSuffix;
                tp = dt.GetType().Assembly.GetType(s, false, true);
                if (tp == null) continue;
                o = Activator.CreateInstance(tp);
                dataAdapters[dt.TableName] = o;

                sqlDataAdapters[dt.TableName] = GetHiddenProperty(o, "Adapter") as DbDataAdapter;

                pri = mtp.GetProperty(dt.TableName + adapterClassSuffix);
                if (pri != null)
                    pri.SetValue(TableAdapterManager, o, null);
            }
        }

        public static FbConnection GetFbConnection(object adapter)
        {
            return Utils.GetProperty(adapter, "Connection") as FbConnection;
        }


        public static void GetStats(DataTable table, out int added, out int modified, out int deleted)
        {
            added = 0;
            modified = 0;
            deleted = 0;
            if (table == null) return;

            DataRow[] rows = table.Select(null, null, DataViewRowState.ModifiedCurrent);
            modified = rows == null ? 0 : rows.Length;

            rows = table.Select(null, null, DataViewRowState.Added);
            added = rows == null ? 0 : rows.Length;

            rows = table.Select(null, null, DataViewRowState.Deleted);
            deleted = rows == null ? 0 : rows.Length;
        }

        public static bool HasChanges(DataTable table)
        {
            if (table == null) return false;
            var rows = table.Select(null, null, DataViewRowState.ModifiedCurrent |
                DataViewRowState.Added | DataViewRowState.Deleted);
            return rows != null && rows.Length > 0;
        }

        public static bool HasChanges(DataTable[] tables)
        {
            if (tables == null) return false;
            foreach (var table in tables)
                if (HasChanges(table)) return true;
            return false;
        }

        public void CopyFromTo(DataRowView drvfrom, DataRowView drvto)
        {
            if (drvfrom == null || drvto == null) return;
            if (!drvfrom.Row.GetType().Equals(drvto.Row.GetType())) return;

            DataRow row_from = drvfrom.Row;
            DataRow row_to = drvto.Row;
            DataTable table = row_from.Table;

            drvto.BeginEdit();
            for (int i = 0; i < drvto.Row.ItemArray.Length; i++)
            {
                if (table.Columns[i].ReadOnly) continue;
                if (table.Columns[i].AutoIncrement) continue;
                drvto[i] = row_to[i];
            }
            drvto.EndEdit();
        }

        public static DataRow CopyRow(DataRow row_original, DataRow row_parent = null, object newid = null)
        {

            DataRelation relation = null;
            if (row_parent != null)
            {
                foreach (DataRelation rel in row_original.Table.ParentRelations)
                {
                    if (rel.ParentTable == row_parent.Table)
                    {
                        relation = rel;
                        break;
                    }
                }
            }

            DataTable table = row_original.Table;
            DataRow row_new = table.NewRow();

            int childrelfieldindex;
            int parentrelfieldindex;
            int i;

            object[] ita = row_original.ItemArray;

            for (i = 0; i < ita.Length; i++)
            {
                if (table.Columns[i].Unique &&
                    !table.Columns[i].AutoIncrement)
                {
                    ita[i] = newid;
                }
                else if (table.Columns[i].AutoIncrement ||
                         table.Columns[i].ReadOnly)
                {
                    ita[i] = null;
                }
            }

            if (relation != null)
            {
                for (i = 0; i < relation.ParentColumns.Length; i++)
                {
                    childrelfieldindex = relation.ChildColumns[i].Ordinal;
                    parentrelfieldindex = relation.ParentColumns[i].Ordinal;
                    ita[childrelfieldindex] = row_parent[parentrelfieldindex];
                }
            }

            row_new.ItemArray = ita;
            return row_new;
        }

        public static DataRow CopyRowWithChildRows(DataRow row_original, DataRow row_parent = null, string newid = null)
        {

            DataRelation relation = null;
            if (row_parent != null)
            {
                foreach (DataRelation rel in row_original.Table.ParentRelations)
                {
                    if (rel.ParentTable == row_parent.Table)
                    {
                        relation = rel;
                        break;
                    }
                }
            }

            DataTable table = row_original.Table;
            int childrelfieldindex;
            int parentrelfieldindex;
            int i;

            object[] ita = row_original.ItemArray;

            for (i = 0; i < ita.Length; i++)
            {
                if (table.Columns[i].Unique &&
                    !table.Columns[i].AutoIncrement)
                {
                    ita[i] = newid;
                }
                else if (table.Columns[i].AutoIncrement ||
                         table.Columns[i].ReadOnly)
                {
                    ita[i] = null;
                }
            }

            if (relation != null)
            {
                for (i = 0; i < relation.ParentColumns.Length; i++)
                {
                    childrelfieldindex = relation.ChildColumns[i].Ordinal;
                    parentrelfieldindex = relation.ParentColumns[i].Ordinal;
                    ita[childrelfieldindex] = row_parent[parentrelfieldindex];
                }
            }

            DataRow row_new = table.LoadDataRow(ita, false);

            if (table.ChildRelations.Count != 1)
            {
                return row_new;
            }

            DataRelation child_relation = row_original.Table.ChildRelations[0];
            DataRow[] childrows_original = row_original.GetChildRows(child_relation);

            foreach (var row_original_child in childrows_original)
                CopyRowWithChildRows(row_original_child, row_new);

            return row_new;
        }

        public static bool RowHasNewParent(DataRow dr)
        {
            if (dr == null || dr.RowState == DataRowState.Deleted) return false;
            if (dr.Table.ParentRelations.Count == 0) return false;
            DataRow drp;
            foreach (DataRelation rel in dr.Table.ParentRelations)
            {
                drp = dr.GetParentRow(rel);
                if (drp != null && drp.RowState == DataRowState.Added)
                {
                    return true;
                }
            }
            return false;
        }

        public static DataRow[] GetNewRows(DataTable table)
        {
            if (table == null) return new DataRow[0];

            DataViewRowState st = DataViewRowState.Added;

            DataRow[] rows = table.Select(null, null, st);
            return rows
                .Where(r => r.RowState != DataRowState.Detached)
                .ToArray();
        }
    }

}
