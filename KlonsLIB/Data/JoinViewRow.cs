using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;

namespace KlonsLIB.Data
{
    public class JoinViewRow : ICustomTypeDescriptor, IEditableObject
    {
        public JoinView View = null;

        public DataRowView BaseRow {get; internal set;}
        public object AddedObject {get; protected set;}

        public JoinViewRow(JoinView JoinView, DataRowView Record, object AddedObject = null)
        {
            if (JoinView == null) throw new ArgumentNullException("View is null.");
            this.View = JoinView;
            this.BaseRow = Record;
            this.AddedObject = AddedObject;
        }

        public object get_Item(int columnIndex)
        {
            FieldInfo fieldInfo = this.View.FieldInfo[columnIndex];
            if(this.BaseRow.Row.RowState == DataRowState.Detached ||
                this.BaseRow.Row.RowState == DataRowState.Deleted)
            {
                return null;
            }

            if (fieldInfo.UseAddedObject)
            {
                if (AddedObject == null) return null;
                try
                {
                    if(fieldInfo.AddedObjectProperty != null)
                        return fieldInfo.AddedObjectProperty.GetValue(AddedObject);

                    var drv = AddedObject as DataRowView;
                    if (drv != null)
                        return drv[fieldInfo.FieldName];

                    var dr = AddedObject as DataRow;
                    if (dr != null)
                        return dr[fieldInfo.FieldName];

                    return TypeDescriptor.GetProperties(AddedObject)[fieldInfo.FieldName];
                }
                catch (Exception)
                {
                    return null;
                }
            }

            if (!string.IsNullOrEmpty(fieldInfo.RelationName))
            {
                try
                {
                    return this.BaseRow.Row.GetParentRow(fieldInfo.RelationName)[fieldInfo.FieldName];
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                return this.BaseRow[fieldInfo.FieldName];
            }
        }

        public void set_Item(int columnIndex, object Value)
        {
            FieldInfo fieldInfo = this.View.FieldInfo[columnIndex];
            if (fieldInfo.IsReadOnly())
                throw new InvalidOperationException("Cannot assign a value to read-only column '" + fieldInfo.FieldAlias + "'.");
            this.BaseRow[fieldInfo.FieldName] = Value;
            this.View.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, this.View.List.IndexOf(this)));
        }

        public object get_Item(string columnName)
        {
            var ind = this.View.GetColumnIndex(columnName);
            if (ind == -1)
                throw new ArgumentException("Column [" + columnName + "] not found.");
            return get_Item(ind);
        }

        public void set_Item(string columnName, object Value)
        {
            var ind = this.View.GetColumnIndex(columnName);
            if (ind == -1)
                throw new ArgumentException("Column [" + columnName + "] not found.");
            set_Item(ind, Value);
        }

        public void Delete()
        {
            this.View.Remove(this);
        }

        public void RemoveFromView()
        {
            this.View.RemoveSimple(this);
        }

        public virtual void OnRemoved(bool deleted)
        {

        }

        public AttributeCollection GetAttributes()
        {
            return new AttributeCollection((Attribute[]) null);
        }

        public string GetClassName()
        {
            return this.View.JoinViewName;
        }

        public string GetComponentName()
        {
            return (string) null;
        }

        public TypeConverter GetConverter()
        {
            return (TypeConverter) null;
        }

        public EventDescriptor GetDefaultEvent()
        {
            return (EventDescriptor) null;
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return (PropertyDescriptor) null;
        }

        public object GetEditor(Type editorBaseType)
        {
            return (object) null;
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return new EventDescriptorCollection((EventDescriptor[]) null);
        }

        public EventDescriptorCollection GetEvents()
        {
            return new EventDescriptorCollection((EventDescriptor[]) null);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return this.GetProperties();
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return (this.View as ITypedList).GetItemProperties(null);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return (object) this;
        }

        public void BeginEdit()
        {
            this.BaseRow.BeginEdit();
        }

        public void CancelEdit()
        {
            this.BaseRow.CancelEdit();
        }

        public void EndEdit()
        {
            this.BaseRow.EndEdit();
        }
    }
}
