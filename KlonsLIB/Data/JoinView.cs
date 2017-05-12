using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Runtime.CompilerServices;

namespace KlonsLIB.Data
{

    public class FieldInfo
    {
        public bool UseAddedObject = false;

        public string FieldName = null;
        public string RelationName = null;
        public string FieldAlias = null;
        public Type Type = null;

        public Type AddedObjectType = null;
        public PropertyDescriptor AddedObjectProperty = null;

        public bool IsReadOnly()
        {
            return UseAddedObject || !string.IsNullOrEmpty(RelationName);
        }
    }

    [ToolboxItem(false)]
    public class JoinView : Component, IDisposable, IList, ITypedList, IBindingList, IComparer, IComparer<JoinViewRow>
    {
        public DataTable _Table;
        public List<FieldInfo> FieldInfo;
        public string JoinViewName;
        public List<JoinViewRow> List;
        public JoinViewRow AddNewObject;
        public Type AddedObjectType = null;

        private bool AllowNewFlag;
        private bool AllowEditFlag;
        private bool AllowDeleteFlag;
        private bool AllowSortFlag;
        private int[] SortColumns = null;
        private ListSortDirection[] SortDirections = null;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable Table
        {
            get
            {
                return _Table;
            }
            set
            {
                if (_Table == value) return;
                LinkEvents(false);
                _Table = value;
                if (_Table == null) List.Clear();
                LinkEvents();
            }
        }

        public JoinView()
        {
            this.Table = null;
            this.AddedObjectType = null;
            this.FieldInfo = new List<FieldInfo>();
            this.AllowEditFlag = true;
            this.AllowNewFlag = false;
            this.AllowDeleteFlag = false;
            this.AllowSortFlag = true;
            this.JoinViewName = "_JoinView";
            this.List = new List<JoinViewRow>();
        }

        public JoinView(DataTable DataTable, Type addedobjecttype, string FieldList)
        {
            this.Table = DataTable;
            this.AddedObjectType = addedobjecttype;
            this.fieldList = FieldList;
            if (this.Table.DataSet == null)
                throw new InvalidOperationException("DataTable must be part of a DataSet.");
            this.ParseFieldList(FieldList);
            this.AllowEditFlag = true;
            this.AllowNewFlag = false;
            this.AllowDeleteFlag = false;
            this.AllowSortFlag = false;
            this.JoinViewName = this.Table.TableName + "_JoinView";
            this.List = new List<JoinViewRow>();
        }

        public void LinkEvents(bool link = true)
        {
            if (_Table == null) return;
            if (link)
            {
                _Table.RowDeleted += Table_RowDeleted;
                _Table.TableCleared += Table_TableCleared;
            }
            else
            {
                _Table.RowDeleted -= Table_RowDeleted;
                _Table.TableCleared -= Table_TableCleared;
            }
        }

        private void Table_TableCleared(object sender, DataTableClearEventArgs e)
        {
            ClearList();
        }

        private void Table_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            RemoveDeletedDataRow(e.Row);
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
        }

        public void RemoveDataRow(DataRow dr, bool fireevent = true)
        {
            var aa = this.List.Where(r => r.BaseRow.Row == dr).ToArray();
            foreach(var a in aa)
            {
                this.List.Remove(a);
                a.OnRemoved(false);
            }
            if (fireevent)
                this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
        }

        protected void RemoveDeletedDataRow(DataRow dr, bool fireevent = true)
        {
            var aa = this.List.Where(r => r.BaseRow.Row == dr).ToArray();
            foreach (var a in aa)
            {
                this.List.Remove(a);
                a.OnRemoved(true);
            }
            if (fireevent)
                this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
        }

        public void RemoveJoinRows(IEnumerable<JoinViewRow> drs, bool fireevent = true)
        {
            foreach (var dr in drs)
            {
                this.List.Remove(dr);
            }
            if(fireevent)
                this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
        }

        private string fieldList { get; set; } = null;
        public string FieldList
        {
            get
            {
                return fieldList;
            }
            set
            {
                if (object.Equals(value, fieldList)) return;
                fieldList = value;
                ParseFieldList(fieldList);
            }
        }

        public int SortColumn
        {
            get
            {
                if (SortColumns == null || SortColumns.Length != 1) return -1;
                return SortColumns[0];
            }
        }
        public ListSortDirection SortDir
        {
            get
            {
                if (SortColumns == null || SortColumns.Length != 1) return ListSortDirection.Ascending;
                return SortDirections[0];
            }
        }

        public bool AllowDelete
        {
            get { return this.AllowDeleteFlag; }
            set { this.AllowDeleteFlag = value; }
        }

        public bool AllowEdit
        {
            get { return this.AllowEditFlag; }
            set { this.AllowEditFlag = value; }
        }

        public bool AllowNew
        {
            get { return this.AllowNewFlag; }
            set { this.AllowNewFlag = value; }
        }

        public bool AllowSort
        {
            get { return this.AllowSortFlag; }
            set { this.AllowSortFlag = value; }
        }

        public string Sort
        {
            get
            {
                if (SortColumns == null || SortColumns.Length == 0) return "";
                string s = "";
                for(int i = 0; i< SortColumns.Length; i++)
                {
                    var s1 = FieldInfo[SortColumns[i]].FieldAlias;
                    if(SortDirections[i] == ListSortDirection.Descending)
                    {
                        s1 += " DESC";
                    }
                    if (s == "") s = s1;
                    else s += "," + s1;
                }
                return s;
            }
            set
            {
                if (!this.AllowSort) return;
                this.SortColumns = null;
                this.SortDirections = null;
                if (value == "") return;
                var ss = value.Split(',');
                var sortcolumns = new int[ss.Length];
                var sortdirections = new ListSortDirection[ss.Length];

                for(int i = 0; i < ss.Length; i++)
                {
                    var s = ss[i].Trim();
                    var s1 = s.ToUpper();
                    sortdirections[i] = ListSortDirection.Ascending;
                    if (s1.EndsWith(" ASC"))
                    {
                        s = s.Substring(0, s.Length - 4).Trim();
                    }
                    else if (s1.EndsWith(" DESC"))
                    {
                        sortdirections[i] = ListSortDirection.Descending;
                        s = s.Substring(0, s.Length - 5).Trim();
                    }
                    int k = this.GetColumnIndex(s);
                    if (k == -1)
                        throw new ArgumentException("Column '" + s1 + "' does not exist in the JoinView.");
                    sortcolumns[i] = k;
                }
                this.SortColumns = sortcolumns;
                this.SortDirections = sortdirections;
                DoSort();
            }
        }

        public void DoSort()
        {
            this.List.Sort(this);
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SyncRoot
        {
            get { return (object) this; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object this[int index]
        {
            get { return this.List[index]; }
            set { throw new InvalidOperationException("The Item property is read-only."); }
        }

        public int Count
        {
            get { return this.List.Count; }
        }

        public bool IsFixedSize
        {
            get { return !(this.AllowNew | this.AllowDelete); }
        }

        public bool IsReadOnly
        {
            get { return !(this.AllowNew | this.AllowEdit | this.AllowDelete); }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        bool IBindingList.AllowEdit
        {
            get { return this.AllowEdit; }
        }

        bool IBindingList.AllowNew
        {
            get { return this.AllowNew; }
        }

        bool IBindingList.AllowRemove
        {
            get { return this.AllowDelete; }
        }

        bool IBindingList.IsSorted
        {
            get { return this.SortColumn > -1; }
        }

        ListSortDirection IBindingList.SortDirection
        {
            get { return this.SortDir; }
        }

        PropertyDescriptor IBindingList.SortProperty
        {
            get
            {
                if (this.SortColumn == -1)
                    return (PropertyDescriptor) null;
                FieldInfo fieldInfo = this.FieldInfo[this.SortColumn];
                return
                    (PropertyDescriptor)
                        new JoinViewRowPropertyDescriptor(fieldInfo.FieldAlias, this.SortColumn,
                            fieldInfo.Type, fieldInfo.IsReadOnly());
            }
        }

        bool IBindingList.SupportsChangeNotification
        {
            get { return true; }
        }

        bool IBindingList.SupportsSearching
        {
            get { return true; }
        }

        bool IBindingList.SupportsSorting
        {
            get { return true; }
        }

        public event ListChangedEventHandler ListChanged;

        public virtual void OnListChanged(ListChangedEventArgs e)
        {
            if (ListChanged == null) return;
            ListChanged((object) this, e);
        }

        public int GetColumnIndex(string ColumnName)
        {
            ColumnName = ColumnName.ToUpper();
            for(int i=0; i< this.FieldInfo.Count; i++)
            {
                if (this.FieldInfo[i].FieldAlias.ToUpper() == ColumnName)
                    return i;
            }
            return -1;
        }

        public int Find(string ColumnName, object Key)
        {
            int columnIndex = this.GetColumnIndex(ColumnName);
            if (columnIndex == -1)
                throw new ArgumentException("Column '" + ColumnName + "' does not exist in the JoinView.");
            if (columnIndex == this.SortColumn)
                return this.List.BinarySearch((JoinViewRow)Key, this);
            for(int i = 0; i < this.List.Count; i++)
            {
                if (object.Equals(this.List[i].get_Item(columnIndex), Key))
                    return i;
            }
            return -1;
        }

        public void ParseFieldList(string FieldList)
        {
            this.FieldInfo = new List<FieldInfo>();
            if (this.Table == null) return;
            string[] ss1 = FieldList.Split(',');
            for (int i = 0; i < ss1.Length; i++)
            {
                FieldInfo fieldInfo;

                if (ss1[i] == "*")
                {
                    for (int j = 0; j < this.Table.Columns.Count; j++)
                    {
                        fieldInfo = new FieldInfo();
                        var col = this.Table.Columns[j];
                        fieldInfo.FieldName = col.ColumnName;
                        fieldInfo.FieldAlias = col.ColumnName;
                        fieldInfo.Type = col.DataType;
                        AddField(fieldInfo);
                    }
                    continue;
                }

                if (ss1[i] == "!.*")
                {
                    if (AddedObjectType == null)
                        throw new ArgumentException("AddedObjectType not set.");

                    if (AddedObjectType.Equals(typeof(DataRowView)) ||
                        AddedObjectType.Equals(typeof(DataRow)))
                        throw new ArgumentException("AddedObjectType does not support _*.");

                    var props = TypeDescriptor.GetProperties(AddedObjectType);

                    for (int j = 0; j < props.Count; j++)
                    {
                        fieldInfo = new FieldInfo();
                        fieldInfo.UseAddedObject = true;
                        fieldInfo.AddedObjectType = AddedObjectType;
                        fieldInfo.AddedObjectProperty = props[j];
                        fieldInfo.FieldName = props[j].Name;
                        fieldInfo.FieldAlias = props[j].Name;
                        fieldInfo.Type = props[j].PropertyType;
                        AddField(fieldInfo);
                    }
                    continue;
                }

                fieldInfo = new FieldInfo();
                string[] ss2 = ss1[i].Trim().Split(' ');
                if (ss2.Length > 2)
                {
                    throw new ArgumentException("Too many spaces in field definition: '" + ss1[i] + "'.");
                }

                if (ss2.Length == 2)
                {
                    fieldInfo.FieldAlias = ss2[1];
                }

                string[] ss3 = ss2[0].Split('.');
                if (ss3.Length > 2)
                {
                    throw new ArgumentException("Invalid field definition: '" + ss1[i] + "'.");
                }

                if (ss3.Length == 1)
                {
                    fieldInfo.FieldName = ss3[0];
                    fieldInfo.Type = this.Table.Columns[fieldInfo.FieldName].DataType;
                    AddField(fieldInfo);
                    continue;
                }

                var fs1 = ss3[0].Trim();
                if (fs1 == "!")
                {
                    fieldInfo.UseAddedObject = true;
                    fieldInfo.AddedObjectType = AddedObjectType;
                    fieldInfo.FieldName = ss3[1];

                    if(AddedObjectType != null)
                    {
                        fieldInfo.AddedObjectProperty = TypeDescriptor.GetProperties(AddedObjectType)[fieldInfo.FieldName];
                    }
                    if(fieldInfo.AddedObjectProperty != null)
                    {
                        fieldInfo.Type = fieldInfo.AddedObjectProperty.PropertyType;
                    }
                    AddField(fieldInfo);
                    continue;
                }


                if (this.Table.ParentRelations.IndexOf(fs1) == -1)
                    throw new ArgumentException("Invalid field definition: '" + ss1[i] + "'.");

                fieldInfo.RelationName = fs1;
                fieldInfo.FieldName = ss3[1].Trim();

                fieldInfo.Type =
                    this.Table.ParentRelations[fieldInfo.RelationName]
                    .ParentTable.Columns[fieldInfo.FieldName].DataType;

                AddField(fieldInfo);
            }
        }

        public void AddField(FieldInfo fi)
        {
            if (string.IsNullOrEmpty(fi.FieldName))
                throw new ArgumentException("Field name not set.");
            if (string.IsNullOrEmpty(fi.FieldAlias))
                fi.FieldAlias = fi.FieldName;
            if (GetColumnIndex(fi.FieldAlias) > -1)
                throw new ArgumentException("Field name alredy used " + fi.FieldAlias);
            this.FieldInfo.Add(fi);
        }

        public int Add(object value)
        {
            throw new InvalidOperationException("The list is read-only. You must use the AddNew method instead.");
        }

        public bool Contains(object value)
        {
            bool flag = false;
            if (value is JoinViewRow)
                flag = ((JoinViewRow) value).View == this;
            return flag;
        }

        public IEnumerator GetEnumerator()
        {
            return this.List.GetEnumerator();
        }

        public int IndexOf(object value)
        {
            if (value is JoinViewRow && ((JoinViewRow) value).View == this)
                return this.List.IndexOf((JoinViewRow)value);
            return -1;
        }

        public void Clear()
        {
            while (this.List.Count > 0)
            {
                JoinViewRow joinViewRow = (JoinViewRow) this.List[0];
                if (joinViewRow != this.AddNewObject)
                    joinViewRow.BaseRow.Delete();
                joinViewRow.BaseRow = (DataRowView) null;
                this.List.RemoveAt(0);
            }
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
        }

        public void ClearList()
        {
            this.List.Clear();
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
        }

        public void CopyTo(Array array, int index)
        {
            this.List.CopyTo(array as JoinViewRow[], index);
        }

        public void Insert(int index, object value)
        {
            throw new InvalidOperationException("The list is read-only. Use the AddNew method.");
        }

        public void AddFrom(IEnumerable<JoinViewRow> list)
        {
            List.AddRange(list);
            this.List.Sort(this);
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
        }

        public virtual void Remove(object value)
        {
            this.RemoveAt(this.List.IndexOf((JoinViewRow)value));
        }

        public virtual void RemoveSimple(object value)
        {
            this.RemoveSimpleAt(this.List.IndexOf((JoinViewRow)value));
        }

        public void RemoveAt(int index)
        {
            if (!this.AllowDelete)
                throw new InvalidOperationException("Rows cannot be deleted.");
            JoinViewRow joinViewRow = (JoinViewRow) this.List[index];
            if (joinViewRow == this.AddNewObject)
                this.AddNewObject = (JoinViewRow) null;
            else
                joinViewRow.BaseRow.Delete();
            joinViewRow.BaseRow = (DataRowView) null;
            joinViewRow.View = (JoinView) null;
            this.List.RemoveAt(index);
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
        }

        public void RemoveSimpleAt(int index)
        {
            if (!this.AllowDelete)
                throw new InvalidOperationException("Rows cannot be deleted.");
            JoinViewRow joinViewRow = (JoinViewRow)this.List[index];
            if (joinViewRow == this.AddNewObject)
                this.AddNewObject = (JoinViewRow)null;
            joinViewRow.BaseRow = (DataRowView)null;
            joinViewRow.View = (JoinView)null;
            this.List.RemoveAt(index);
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
        }

        public object AddNew()
        {
            if (!this.AllowNew)
                throw new InvalidOperationException("AddNew is not allowed.");
            this.AddNewObject = new JoinViewRow(this, this.Table.DefaultView.AddNew());
            this.List.Add((JoinViewRow) this.AddNewObject);
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, checked (this.List.Count - 1)));
            return (object) this.AddNewObject;
        }

        int IBindingList.Find(PropertyDescriptor property, object key)
        {
            return this.Find(property.DisplayName, RuntimeHelpers.GetObjectValue(key));
        }

        void IBindingList.AddIndex(PropertyDescriptor property)
        {
        }

        void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            if (direction == ListSortDirection.Ascending)
                this.Sort = property.DisplayName;
            else
                this.Sort = property.DisplayName + " DESC";
        }

        void IBindingList.RemoveIndex(PropertyDescriptor property)
        {
        }

        void IBindingList.RemoveSort()
        {
            this.Sort = "";
        }

        PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listaccessors)
        {
            var props = new JoinViewRowPropertyDescriptor[this.FieldInfo.Count];

            for(int i = 0; i < this.FieldInfo.Count; i++)
            {
                var fi =  this.FieldInfo[i];
                props[i] = new JoinViewRowPropertyDescriptor(fi.FieldAlias, 
                    i, fi.Type, fi.IsReadOnly());
            }
            return new PropertyDescriptorCollection(props);
        }

        string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
        {
            return this.JoinViewName;
        }

        int IComparer.Compare(object x, object y)
        {
            if (SortColumns == null) return 0;
            var rx = x as JoinViewRow;
            var ry = y as JoinViewRow;
            if (rx == null && ry == null) return 0;
            if (rx == null) return -1;
            if (ry == null) return 1;

            return (this as IComparer<JoinViewRow>).Compare(rx, ry);
        }

        int IComparer<JoinViewRow>.Compare(JoinViewRow rx, JoinViewRow ry)
        {
            if (SortColumns == null) return 0;
            if (rx == null && ry == null) return 0;
            if (rx == null) return -1;
            if (ry == null) return 1;

            for (int i = 0; i < SortColumns.Length; i++)
            {
                var vx = rx.get_Item(SortColumns[i]);
                var vy = ry.get_Item(SortColumns[i]);
                var ic = vx as IComparable;
                if (ic == null) return 0;
                int r = ic.CompareTo(vy);
                if (r == 0) continue;
                if (SortDirections[i] == ListSortDirection.Descending)
                    r = -r;
                return r;
            }
            return 0;
        }

        public JoinView(System.ComponentModel.IContainer container) : this() {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
           
            container.Add(this);
        }


        #region IComponent
        private string name = null;

        [Browsable(false)]
        public string Name
        {
            get
            {
                if (this.Site != null && !string.IsNullOrEmpty(this.Site.Name))
                    this.name = this.Site.Name;
                return this.name;
            }
            set
            {
                string b = this.name;
                this.name = !string.IsNullOrEmpty(value) ? value : string.Empty;
            }
        }

        private ISite site = null;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ISite Site
        {
            get { return site; }
            set { site = value; }
        }

        //public event EventHandler Disposed;

        private bool disposedValue = false; // To detect redundant calls

        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    List.Clear();
                    Table = null;
                }

                disposedValue = true;
            }
            base.Dispose(disposing);
        }

        public new void Dispose()
        {
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
