using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Windows.Forms;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsLIB.Data
{
    public class MyBindingSource2 : BindingSource
    {
        private MyBindingSource2 childBS = null;
        private DataGridView useDataGridView = null;

        [DefaultValue(null)]
        [Category("Misc")]
        public string Name2 { get; set; }

        [DefaultValue(null)]
        [Category("Misc")]
        public DataGridView UseDataGridView {
            get { return useDataGridView; }
            set { useDataGridView = value; }
        }

        [DefaultValue(false)]
        [Category("Data")]
        public bool AutoSaveOnDelete { get; set; }

        [DefaultValue(false)]
        [Category("Data")]
        public bool AutoSaveChildrenDelete { get; set; }

        [DefaultValue(null)]
        [Category("Data")]
        public MyBindingSource2 ChildBS
        {
            get { return childBS; }
            set { childBS = value; }
        }


        [Browsable(false)]
        public DataRow CurrentDataRow => (Current as DataRowView)?.Row;


        private bool saveEnabled = true;
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SaveEnabled
        {
            get { return saveEnabled; }
            set { saveEnabled = value; } 
        }


        [Category("My")]
        public event ItemRmoveEventHandler MyItemRemoved;

        [Category("My")]
        public event MyRowUpdateEventHandler MyBeforeRowInsert;

        [Category("My")]
        public event MyRowUpdateEventHandler MyBeforeRowSave;

        [Category("My")]
        public event MyRowSavedEventHandler MyRowSaved;

        [Category("My")]
        public event EventHandler MyUpForChecks;

        public MyBindingSource2() : base()
        {
        }

        public MyBindingSource2(System.ComponentModel.IContainer container) : this() {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            container.Add(this);
        }

        public MyBindingSource2(object dataSource, string dataMember) : base(dataSource, dataMember) 
        {

        }


        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (!this.RaiseListChangedEvents || !(this as ISupportInitializeNotification).IsInitialized)
            {
                return;
            }
            
            //Debug.Print("MyBindingSource2.OnListChanged {0}: {1} {2}", this.Name2, e.NewIndex, e.ListChangedType);

            base.OnListChanged(e);

        }

        protected override void OnPositionChanged(EventArgs e)
        {
            //Debug.Print("MyBindingSource2.OnPositionChanged {0}: {1}" , this.Name2, Position);
            base.OnPositionChanged(e);
            OnMyUpForChecks();
        }

        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            // wtf
            /*
            if (UseDataGridView != null && UseDataGridView.AllowUserToAddRows &&
                UseDataGridView.Rows.Count == this.Count)
            {
                base.RemoveAt(this.Count - 1);
                return;
            }*/
            base.OnAddingNew(e);
        }

        public bool IsRowChanged(DataRow row)
        {
            if (!row.HasVersion(DataRowVersion.Original)) return true;
            for (int i = 0; i < row.ItemArray.Length; i++)
            {
                var vcur = row[i];
                var vori = row[i, DataRowVersion.Original];
                if (!vcur.Equals(vori))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyCurrentA(int relationindex = -1)
        {
            try
            {
                CopyCurrent(relationindex);
            }
            catch (Exception e)
            {
                Form_Error.ShowException(new MyException("Neizdevās saglabāt ierakstu", e));
            }
        }

        public DataRow CopyCurrent(int relationindex = -1)
        {
            if (Current == null) return null;
            DataRowView rowvie_old = Current as DataRowView;
            if (rowvie_old == null)
            {
                throw new Exception("CopyCurrent: object type not supported");
            }
            return CopyThis(rowvie_old, relationindex);
        }

        public DataRow CopyThis(DataRowView rowvie_old, int relationindex = -1)
        {
            if (rowvie_old == null)
            {
                throw new Exception("CopyCurrent: object type not supported");
            }
            AddNew();
            DataRowView rowview_new = Current as DataRowView;
            DataTable table = rowview_new.Row.Table;
            DataRow new_row = rowview_new.Row;
            int i;

            rowview_new.BeginEdit();
            for (i = 0; i < rowview_new.Row.ItemArray.Length; i++)
            {
                if (table.Columns[i].ReadOnly) continue;
                if (table.Columns[i].AutoIncrement) continue;
                rowview_new[i] = rowvie_old[i];
            }
            rowview_new.EndEdit();

            if (relationindex == -1) return new_row;
            if (table.ChildRelations.Count <= relationindex)
            {
                throw new ArgumentOutOfRangeException("relnr");
            }

            DataRelation relation = table.ChildRelations[relationindex];
            DataRow[] rowsold = rowvie_old.Row.GetChildRows(relation);
            if (rowsold.Length == 0) return new_row;

            DataRow[] rowsnew = new DataRow[rowsold.Length];

            DataTable child_table = relation.ChildTable;

            int childrelfieldindex;
            int parentrelfieldindex;
            int j;
            DataRow dr1;

            for (i = 0; i < rowsold.Length; i++)
            {
                dr1 = rowsold[i];
                object[] ita = dr1.ItemArray;

                for (j = 0; j < ita.Length; j++)
                {
                    if (child_table.Columns[j].AutoIncrement)
                    {
                        ita[j] = null;
                    }
                }
                for (j = 0; j < relation.ParentColumns.Length; j++)
                {
                    childrelfieldindex = relation.ChildColumns[j].Ordinal;
                    parentrelfieldindex = relation.ParentColumns[j].Ordinal;
                    ita[childrelfieldindex] = rowview_new[parentrelfieldindex];
                }
                rowsnew[i] = child_table.LoadDataRow(ita, false);
                OnMyBeforeRowUpdate(rowsnew[i]);
            }

            rowview_new.Row.BeginEdit();
            rowview_new.Row.EndEdit();
            return new_row;
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

        protected void RaiseCurrentItemChanged()
        {
            var field = Utils.GetField(CurrencyManager.GetType(), "onCurrentItemChangedHandler");
            EventHandler evh = field.GetValue(CurrencyManager) as EventHandler;
            if (evh != null)
                evh(CurrencyManager, new EventArgs());
        }

        public virtual EBsSaveResult SaveItem(object row)
        {
            DataRowView rowview = row as DataRowView;
            if (rowview == null)
            {
                throw new Exception("Not supported item type.");
            }

            return SaveDataRow(rowview.Row);
        }

        public virtual EBsSaveResult SaveCurrentItem()
        {
            if(this.Current == null) return EBsSaveResult.SaveSkipped;
            DataRowView rowview = this.Current as DataRowView;
            if (rowview == null)
            {
                throw new Exception("Not supported item type.");
            }

            return SaveDataRow(rowview.Row);
        }

        private DataRow processingrow = null;



        public virtual EBsSaveResult SaveDataRow(DataRow row)
        {
            if (!SaveEnabled) return EBsSaveResult.SaveSkipped;
            return SaveDataRow_(row);
        }

        public virtual EBsSaveResult SaveDataRowOnlyDeleted(DataRow row)
        {
            if (!SaveEnabled) return EBsSaveResult.SaveSkipped;
            return SaveDataRowOnlyDeleted_(row);
        }

        protected virtual EBsSaveResult SaveDataRow_(DataRow row)
        {
            if (!AutoSaveChildrenDelete)
                return SaveDataRowA_(row);

            EBsSaveResult ret1 = EBsSaveResult.Saved;
            EBsSaveResult ret2 = EBsSaveResult.Saved;

            if (childBS != null)
                ret1 = SaveDeletedChildren(row);

            ret2 = SaveDataRowA_(row);

            if (ret2 == EBsSaveResult.Error)
                ret1 = ret2;

            if (childBS != null)
                ret2 = SaveChildren(row);

            if (ret2 == EBsSaveResult.Error)
                ret1 = ret2;

            return ret1;
        }

        protected virtual EBsSaveResult SaveDataRowOnlyDeleted_(DataRow row)
        {
            if (!AutoSaveChildrenDelete)
                return SaveDataRowA_(row, true);

            EBsSaveResult ret1 = EBsSaveResult.Saved;
            EBsSaveResult ret2 = EBsSaveResult.Saved;

            if (childBS != null)
                ret1 = SaveDeletedChildren(row);

            ret2 = SaveDataRowA_(row, true);

            if (ret2 == EBsSaveResult.Error)
                ret1 = ret2;

            return ret1;
        }

        public virtual EBsSaveResult SaveDataRowA(DataRow row, bool onlydeleted = false)
        {
            if (!SaveEnabled) return EBsSaveResult.SaveSkipped;
            return SaveDataRowA_(row, onlydeleted);
        }

        protected virtual EBsSaveResult SaveDataRowA_(DataRow row, bool onlydeleted = false)
        {
            if (processingrow == row) return EBsSaveResult.SaveSkipped;
            if (DataSource == null)
                throw new Exception("DataSource not set.");

            if(row == null)
            {
                throw new Exception("row = null.");
            }

            if (row.RowState == DataRowState.Detached)
            {
                return EBsSaveResult.SaveSkipped;
            }

            bool b;
            if (onlydeleted)
                b = row.RowState == DataRowState.Deleted;
            else
                b = row.RowState == DataRowState.Added ||
                    row.RowState == DataRowState.Deleted ||
                    row.RowState == DataRowState.Modified;

            if (!b) return EBsSaveResult.SaveSkipped;

            if (row.RowState == DataRowState.Modified &&
                !IsRowChanged(row))
            {
                row.AcceptChanges();
                return EBsSaveResult.Saved;
            }

            if (HasNewParent(row)) return EBsSaveResult.SaveSkipped;

            var sqlad = KlonsDataModule.St.GetSqlDataAdapter(row.Table);
            if (sqlad == null)
                throw new Exception("SaveCurrentRow failed");

            try
            {
                OnMyBeforeRowUpdateA(row);

                sqlad.Update(new DataRow[] { row });
                if(row.HasErrors)
                    row.ClearErrors();
                OnMyRowSaved(row);
                //Debug.Print("MyBindingSource {0}  row saved", Name2);
                return EBsSaveResult.Saved;
            }
            catch (Exception ex)
            {
                MyException ex2 = ExceptionHelper.TranslateException(ex, row.Table);
                if (ex2.Message == ex.Message)
                {
                    ex2 = new MyException("Neizdevās saglabāt izmaiņas.", ex);
                }
                row.RejectChanges();
                //row.RowError = ex2.Message;
                Form_Error.ShowException(ex2);
                return EBsSaveResult.Error;
            }
        }

        public virtual EBsSaveResult SaveList()
        {
            if (!SaveEnabled) return EBsSaveResult.SaveSkipped;
            return SaveList_();
        }

        protected virtual EBsSaveResult SaveList_()
        {
            if (!SaveEnabled) return EBsSaveResult.SaveSkipped;
            if (Count == 0) return EBsSaveResult.SaveSkipped;

            DataRow[] rows = new DataRow[Count];
            for (int i = 0; i < Count; i++)
            {
                rows[i] = (List[i] as DataRowView).Row;
            }
            
            EBsSaveResult ret = EBsSaveResult.Saved;

            foreach (var dr in rows)
            {
                var ret1 = SaveDataRow(dr);
                if (ret1 == EBsSaveResult.Error)
                    ret = ret1;
            }

            return ret;
        }

        public bool HasNewParent(DataRow dr)
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


        public void DoBeforeInsertAll()
        {
            DataTable table = GetTable();

            DataRow[] rows = table.Select(null, null, DataViewRowState.Added);

            OnMyBeforeRowUpdateA(rows);
        }

        public static void ClearAllErrors(DataRow[] rows)
        {
            if (rows == null) return;
            foreach (var dr in rows)
            {
                if(dr.HasErrors)
                    dr.ClearErrors();
            }
        }
        public static void ClearAllErrors(DataTable table)
        {
            if (table == null) return;
            if (table.HasErrors)
            {
                var rows = table.GetErrors();
                foreach (var r in rows)
                {
                    r.ClearErrors();
                }
            }
        }

        public virtual EBsSaveResult SaveTable()
        {
            if (!SaveEnabled) return EBsSaveResult.SaveSkipped;
            return SaveTable_();
        }

        public virtual EBsSaveResult SaveTableOnlyDeleted()
        {
            if (!SaveEnabled) return EBsSaveResult.SaveSkipped;
            return SaveTableOnlyDeleted_();
        }

        protected virtual EBsSaveResult SaveTable_()
        {
            if (!AutoSaveChildrenDelete) 
                return SaveTableA_();

            EBsSaveResult ret1 = EBsSaveResult.Saved;
            EBsSaveResult ret2 = EBsSaveResult.Saved;

            if (childBS != null)
                ret1 = childBS.SaveTableOnlyDeleted();
            
            ret2 = SaveTableA_();
            
            if (ret2 == EBsSaveResult.Error)
                ret1 = ret2;

            if (childBS != null) 
                ret2 = childBS.SaveTable();

            if (ret2 == EBsSaveResult.Error)
                ret1 = ret2;

            return ret1;
        }

        protected virtual EBsSaveResult SaveTableOnlyDeleted_()
        {
            if (!AutoSaveChildrenDelete)
                return SaveTableA_(true);

            EBsSaveResult ret1 = EBsSaveResult.Saved;
            EBsSaveResult ret2 = EBsSaveResult.Saved;

            if (childBS != null)
                ret1 = childBS.SaveTableOnlyDeleted();

            ret2 = SaveTableA_(true);

            if (ret2 == EBsSaveResult.Error)
                ret1 = ret2;

            return ret1;
        }

        public virtual EBsSaveResult SaveTableA(bool onlydeleted = false)
        {
            if (!SaveEnabled) return EBsSaveResult.SaveSkipped;
            return SaveTableA_(onlydeleted);
        }

        protected virtual EBsSaveResult SaveTableA_(bool onlydeleted = false)
        {
            DataTable table = GetTable();
            if(table == null) return EBsSaveResult.SaveSkipped;
            var sqlad = KlonsDataModule.St.GetSqlDataAdapter(table);
            if (sqlad == null)
                throw new Exception("SaveTable failed");

            DataViewRowState st;
            
            if(onlydeleted) st = DataViewRowState.Deleted;
            else st = DataViewRowState.Added | DataViewRowState.ModifiedCurrent;

            DataRow[] rows = table.Select(null, null, st);
            List<DataRow> rows2 = new List<DataRow>();
            foreach (var dr1 in rows)
            {
                if (dr1.RowState != DataRowState.Detached && !HasNewParent(dr1))
                {
                    rows2.Add(dr1);
                }
            }
            rows = rows2.ToArray();

            OnMyBeforeRowUpdateA(rows);
            
            try
            {
                sqlad.Update(rows);
                ClearAllErrors(rows);
                //Debug.Print("MyBindingSource2.SaveTableA {1} onlydeleted:{0}", onlydeleted, Name2);
            }
            catch (Exception ex)
            {
                MyException ex2 = ExceptionHelper.TranslateException(ex, table);
                ex2 = new MyException("Neizdevās saglabāt izmaiņas.", ex2);
                Form_Error.ShowException(ex2);
                return EBsSaveResult.Error;
            }
            return EBsSaveResult.Saved;
        }

        public virtual void DoRowEvents()
        {
            DataTable table = GetTable();
            if (table == null) return;

            DataViewRowState st = DataViewRowState.Added | 
                DataViewRowState.ModifiedCurrent | DataViewRowState.Deleted;

            DataRow[] rows = table.Select(null, null, st);
            List<DataRow> rows2 = new List<DataRow>();
            foreach (var dr1 in rows)
            {
                if (dr1.RowState != DataRowState.Detached && !HasNewParent(dr1))
                {
                    rows2.Add(dr1);
                }
            }
            rows = rows2.ToArray();

            OnMyBeforeRowUpdateA(rows);

        }
        public int Fill()
        {
            DataTable table = GetTable();
            if (table == null)
                throw new Exception("DataSource not set");

            try
            {
                int k = KlonsDataModule.St.FillTable(table);
                return k;
            }
            catch (Exception ex)
            {
                Exception ex2 = new Exception("Neizdevās nolasīt datus.", ex);
                Form_Error.ShowException(ex2);
                return -1;
            }
        }

        public DbDataAdapter GetSqlDataAdapter()
        {
            DataTable dt = GetTable();
            if (dt == null) return null;

            return KlonsDataModule.St.GetSqlDataAdapter(dt);
        }

        public virtual DataTable GetTable()
        {
            if (DataSource == null) return null;
            
            if (DataSource is DataView)
            {
                var dv = DataSource as DataView;
                return dv.Table;
            }
            if (DataSource is JoinView)
            {
                var jv = DataSource as JoinView;
                return jv.Table;
            }

            if (DataSource == null || string.IsNullOrEmpty(DataMember)) 
                return null;

            string tablename = null;
            DataTable table = null;
            
            DataSet dataset = DataSource as DataSet;

            if (dataset != null)
            {
                tablename = DataMember;
            }
            else
            {
                if (DataSource is MyBindingSource2)
                {
                    table = (DataSource as MyBindingSource2).GetTable();
                    dataset = table.DataSet;
                    if (table == null) return null;
                    var relation = table.ChildRelations[DataMember];
                    if (relation == null) return null;
                    tablename = relation.ChildTable.TableName;
                }
                else if (DataSource is BindingSource)
                {
                    dataset = (DataSource as BindingSource).DataSource as DataSet;
                    if (dataset == null) return null;
                    tablename = (DataSource as BindingSource).DataMember;
                    table = dataset.Tables[tablename];
                    var relation = table.ChildRelations[DataMember];
                    if (relation == null) return null;
                    tablename = relation.ChildTable.TableName;
                }
                else
                {
                    return null;
                }
            }

            string datasetname = KlonsDataModule.St.GetDataSetName(dataset);
            if (datasetname == null)
                return null;

            return KlonsDataModule.St.GetDataTable(datasetname, tablename);
        }

        public bool HasChanges()
        {
            int k1, k2, k3;
            GetStats(out k1, out k2, out k3);
            return (k1 + k2 + k3) > 0;
        }

        public string GetStats()
        {
            DataTable table = GetTable();
            if (table == null) return null;

            int kmod, kadd, kdel;
            GetStats(out kadd, out kmod, out kdel);
            
            return string.Format(
                "mainīti - {0},  jauni - {1},  dzēsti - {2}"
                , kmod, kadd, kdel);
        }

        public void GetStats(out int added, out int modified, out int deleted)
        {
            DataTable table = GetTable();
            DataSetHelper.GetStats(GetTable(), out added, out modified, out deleted);
        }

        public void ShowStats()
        {
            string s = GetStats();
            if (s == null) return;
            MessageBox.Show("Nesaglabātie ieraksti\n  " + s, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void Remove(object value)
        {
            int index = ((IList)this).IndexOf(value);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }
        public override void RemoveAt(int index)
        {
            object item = ((IList)this)[index];
            base.RemoveAt(index);
            OnMyItemRemoved(new MyItemRemovedEventArgs(item));
            OnMyUpForChecks();
        }

        protected EBsSaveResult SaveDeletedChildren(DataRow dr)
        {
            EBsSaveResult ret = EBsSaveResult.Saved;
            if (dr == null || dr.RowState != DataRowState.Deleted) return EBsSaveResult.SaveSkipped;
            if (childBS == null) return EBsSaveResult.SaveSkipped;
            var childtable = childBS.GetTable();
            if (childtable == null) return EBsSaveResult.Error;
            foreach (DataRelation rel in dr.Table.ChildRelations)
            {
                if (rel.ChildTable != childtable) continue;
                DataRow[] drs = dr.GetChildRows(rel, DataRowVersion.Original);
                if (drs == null || drs.Length == 0) continue;
                foreach (var dr1 in drs)
                {
                    if (dr1.RowState == DataRowState.Deleted)
                    {
                        var ret1 = childBS.SaveDataRow(dr1);
                        if(ret1 == EBsSaveResult.Error)
                            ret = EBsSaveResult.Error;
                    }
                }
            }
            return ret;
        }

        protected EBsSaveResult SaveChildren(DataRow dr)
        {
            EBsSaveResult ret = EBsSaveResult.Saved;
            if (dr == null || dr.RowState == DataRowState.Deleted ||
                dr.RowState == DataRowState.Detached) return EBsSaveResult.SaveSkipped;
            if (childBS == null) return EBsSaveResult.SaveSkipped;
            var childtable = childBS.GetTable();
            if (childtable == null) return EBsSaveResult.Error;
            foreach (DataRelation rel in dr.Table.ChildRelations)
            {
                if (rel.ChildTable != childtable) continue;
                DataRow[] drs = dr.GetChildRows(rel);
                if (drs == null || drs.Length == 0) continue;
                foreach (var dr1 in drs)
                {
                    var ret1 = childBS.SaveDataRow(dr1);
                    if (ret1 == EBsSaveResult.Error)
                        ret = EBsSaveResult.Error;
                }
            }
            return ret;
        }

        protected void OnMyItemRemoved(MyItemRemovedEventArgs e)
        {
            if (AutoSaveOnDelete)
            {
                SaveItem(e.Item);
            }
            if (MyItemRemoved != null)
            {
                MyItemRemoved(this, e);
            }
        }

        protected void OnMyBeforeRowUpdateA(DataRow datarow)
        {
            if (datarow.RowState == DataRowState.Added)
            {
                OnMyBeforeRowInsert(datarow);
            }
            if (datarow.RowState == DataRowState.Modified)
            {
                OnMyBeforeRowUpdate(datarow);
            }
        }
        protected void OnMyBeforeRowUpdateA(DataRow[] datarow)
        {
            if (datarow == null) return;
            if (MyBeforeRowInsert == null && MyBeforeRowSave == null) return;
            
            foreach (var dr in datarow)
            {
                OnMyBeforeRowUpdateA(dr);
            }
        }

        protected void OnMyBeforeRowInsert(DataRow datarow)
        {
            processingrow = datarow;
            try
            {
                if (MyBeforeRowInsert == null) return;
                MyBeforeRowInsert(new MyRowUpdateEventArgs(datarow));
            }
            finally
            {
                processingrow = null;
            }
        }
        protected void OnMyRowSaved(DataRow datarow)
        {
            try
            {
                if (MyRowSaved == null) return;
                MyRowSaved(new MyRowSavedEventArgs(datarow));
            }
            catch (Exception) { }
        }

        protected void OnMyBeforeRowUpdate(DataRow datarow)
        {
            processingrow = datarow;
            try
            {
                if (MyBeforeRowSave == null) return;
                MyBeforeRowSave(new MyRowUpdateEventArgs(datarow));
            }
            finally
            {
                processingrow = null;
            }
        }

        protected void OnMyUpForChecks()
        {
            if (MyUpForChecks != null) 
                MyUpForChecks(this, null);
        }

    }


    public class MyItemRemovedEventArgs : EventArgs
    {
        public Object Item { get; private set; }

        public MyItemRemovedEventArgs(Object item)
        {
            this.Item = item;
        }
    }
    public delegate void ItemRmoveEventHandler(Object sender, MyItemRemovedEventArgs e);

    public enum EBsSaveResult
    {
        Saved, SaveSkipped, Error
    }

    public delegate void MyRowUpdateEventHandler(MyRowUpdateEventArgs e);
    public delegate void MyRowSavedEventHandler(MyRowSavedEventArgs e);

    public class MyRowUpdateEventArgs : EventArgs
    {
        public DataRow DataRow { get; private set; }

        public MyRowUpdateEventArgs(DataRow datarow)
        {
            DataRow = datarow;
        }
    }
    public class MyRowSavedEventArgs : EventArgs
    {
        public DataRow DataRow { get; private set; }

        public MyRowSavedEventArgs(DataRow datarow)
        {
            DataRow = datarow;
        }
    }

}
