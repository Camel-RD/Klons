using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevAge.ComponentModel;
using DevAge.ComponentModel.Converter;
using KlonsLIB.Components;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using SourceGrid;
using SourceGrid.Cells.Editors;

namespace KlonsLIB.MySourceGrid.GridRows
{
    //[ComplexBindingProperties("DataSource", "DataMember")]
    public class MyGridRowPropEditorBase : MyGridRowBase, IMyPropertyValueListProvider
    {
        protected object dataSource = null;
        protected string dataMember = null;
        protected string editorTemplateName = null;
        protected int rowSpan = 1;

        [DefaultValue(null)]
        [Category("Data")]
        [Editor(typeof(MyDropDownPropertyEditor), typeof(UITypeEditor))]
        public string GridPropertyName { get; set; } = null;


        [DefaultValue(null)]
        [Category("Data")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get
            {
                return this.dataSource;
            }
            set
            {
                if (this.dataSource == value)
                    return;
                this.dataSource = value;
            }
        }


        [Category("Data")]
        [DefaultValue("")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, " + AssemblyRef1.SystemDesign)]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, " + AssemblyRef1.SystemDesign,
                typeof(System.Drawing.Design.UITypeEditor))]
        public string DataMember
        {
            get
            {
                return this.dataMember;
            }
            set
            {
                if (value == null)
                    value = string.Empty;
                if (object.Equals(this.dataMember, value))
                    return;
                this.dataMember = value;
            }
        }

        [DefaultValue(null)]
        [Category("Editor")]
        [Editor(typeof(MyDropDownPropertyEditor), typeof(UITypeEditor))]
        public string EditorTemplateName
        {
            get { return this.editorTemplateName; }
            set
            {
                if (value == editorTemplateName) return;
                editorTemplateName = value;
            }
        }

        [DefaultValue(false)]
        [Category("Data")]
        public bool AllowNull { get; set; } = false;

        [DefaultValue(false)]
        [Category("Data")]
        public bool ReadOnly { get; set; } = false;

        [DefaultValue(true)]
        public bool CheckRed { get; set; } = true;

        [DefaultValue(1)]
        public virtual int RowSpan
        {
            get
            {
                return rowSpan;
            }
            set
            {
                if (value == rowSpan) return;
                rowSpan = value;
                if (rowSpan < 1) rowSpan = 1;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual EditorBase MyEditor {get; protected set;}
        

        public MyGridRowPropEditorBase(string name, string title, string gridpropname,
            EMyGridRowType rowtype, EMyGridRowValueType valtyp)
        {
            Name = name;
            RowTitle = title;
            GridPropertyName = gridpropname;
            RowType = rowtype;
            RowValueType = valtyp;
        }

        public MyGridRowPropEditorBase()
        {
            RowType = EMyGridRowType.TextBox;
            RowValueType = EMyGridRowValueType.String;

        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual SourceGrid.Cells.ICell DataCell
        {
            get
            {
                return Grid[RowNr, DataColumnNr];
            }
        }

        public override object Value
        {
            get
            {
                return DataCell.Value;
            }
            set
            {
                var grid = Grid;
                var datacell = DataCell;
                var thisCell = new CellContext(grid, new Position(datacell.Row.Index, datacell.Column.Index));

                if (!grid.Selection.ActivePosition.IsEmpty())
                {
                    var focusCell = new CellContext(grid, grid.Selection.ActivePosition);
                    if (focusCell.Cell != null && focusCell.Equals(thisCell) && focusCell.IsEditing())
                    {
                        thisCell.EndEdit(true);
                    }
                }

                thisCell.Value = value;
            }
        }

        public bool DataObjectValue(out object val)
        {
            val = null;
            if (Grid == null || Grid.MyData == null ||
                string.IsNullOrEmpty(GridPropertyName))
                return false;
            return Utils.GetPublicPropertyValue(Grid.MyData, GridPropertyName, out val);
        }

        public override bool CanBeMarked
        {
            get { return true; }
        }

        public override int GetRowCount()
        {
            return RowSpan;
        }

        public override void MakeRow(SourceGrid.GridRow gridrow, int colnr)
        {
            base.MakeRow(gridrow, colnr);
            int i = RowNr;

            if (Grid.RowHeadersUsed) 
                MakeFirstCell();
            MakeCaptionCell();
            var datacell = MakeDataCell();
            Grid[i, DataColumnNr] = datacell;
            this.MyEditor = datacell.Editor;

            if (RowSpan > 1)
            {
                if (Grid.RowHeadersUsed)
                    Grid[i, RowHeaderColumnNr].SetSpan(RowSpan, 1);
                Grid[i, CaptionColumnNr].SetSpan(RowSpan, 1);
                Grid[i, CaptionColumnNr].View.WordWrap = true;
                Grid[i, DataColumnNr].SetSpan(RowSpan, 1);
            }
        }

        public override void MakeTemplateRow(MyGrid grid)
        {
            this.Grid = grid;
            var cell = MakeDataCell();
            if (!ReadOnly)
            {
                cell.Editor.EditableMode = EditableMode.AnyKey | EditableMode.DoubleClick |
                    EditableMode.F2Key | EditableMode.SingleClick;
            }
            this.MyEditor = cell.Editor;
        }

        public override void LinkRow()
        {
            LinkCell();
        }

        public override void UnLinkRow()
        {
            UnLinkCell();
        }

        public void LinkCell()
        {
            if (string.IsNullOrEmpty(GridPropertyName)) return;

            //grid.LinkedCells[GridPropertyName] = new CellContext(grid, new Position(i, cellnr), grid[i, cellnr]);
            Grid.LinkedRows.Add(GridPropertyName, this);

            var bp = new DataCellController(this);
            DataCell.AddController(bp);

            if (string.IsNullOrEmpty(EditorTemplateName) && !ReadOnly && DataCell.Editor.EditableMode != EditableMode.None)
            {
                DataCell.Editor.EditableMode = EditableMode.AnyKey | EditableMode.DoubleClick |
                    EditableMode.F2Key | EditableMode.SingleClick;
            }

            if (DataSource != null && DataMember != null)
            {
                var bd = new Binding(GridPropertyName, DataSource, DataMember, true, DataSourceUpdateMode.OnPropertyChanged);

                (Grid.MyData as IBindableComponent).DataBindings.Add(bd);
            }
        }

        public void UnLinkCell()
        {
            if (Grid == null) return;
            int i = RowNr;
            var grid = Grid;
            // todo
        }

        public virtual void SetBindingContext(BindingContext bc)
        {
            
        }


        public virtual EditorBase GetSharedEditor()
        {
            if (Owner == null || Owner.Grid == null || editorTemplateName == null)
                return null;
            var row = Owner.Grid.RowTemplateList.FindByName(editorTemplateName) as MyGridRowPropEditorBase;
            if (row == null) return null;
            return row.MyEditor;
        }

        public virtual void UpdateDataSource()
        {
            if (string.IsNullOrEmpty(GridPropertyName) || Grid == null || Grid.MyData == null) return;
            var mydata = Grid.MyData;
            PropertyInfo prop = Utils.GetProp(mydata.GetType(), GridPropertyName);
            if (prop == null)
            {
                throw new Exception("Property not found");
            }
            object value = this.Value;
            object oldvalue = prop.GetValue((mydata), null);
            if (object.Equals(value, oldvalue)) return;

            var bs = dataSource as BindingSource;
            DataRowView drv = null;
            if (bs != null)
                drv = bs.Current as DataRowView;

            try
            {
                prop.SetValue(mydata, value, null);
                if (drv != null)
                    drv.EndEdit();
            }
            catch (Exception ex)
            {
                var ex1 = new MyException("Ievadīta nnekorekta lauka vērtība.", ex);
                Grid.OnDataError(ex1);
            }

            var db = Grid.MyDataBC.DataBindings[GridPropertyName];
            if (db != null)
            {
                db.ReadValue();
            }

            object value2 = prop.GetValue((mydata), null);
            if (!object.Equals(value, value2))
            {
                this.Value = value2;
            }
        }

        public override void UpdateDataCell()
        {
            var grid = Grid;
            if (string.IsNullOrEmpty(GridPropertyName) || grid == null || grid.MyData == null) return;
            var mydata = grid.MyData;
            PropertyInfo prop = Utils.GetProp(mydata.GetType(), GridPropertyName);

            if (prop == null)
                throw new Exception("Property not found");

            object cellvalue = this.Value;
            object datavalue;

            var bs = dataSource as BindingSource;
            DataRowView drv = null;
            if (bs != null)
                drv = bs.Current as DataRowView;

            try
            {
                if (drv != null) drv.EndEdit();
                
                //var db = grid.MyDataBC.DataBindings[GridPropertyName];
                //if (db != null) db.ReadValue();

                datavalue = prop.GetValue(mydata, null);
            }
            catch (Exception ex)
            {
                var ex1 = new MyException("Ievadīta nnekorekta lauka vērtība.", ex);
                grid.OnDataError(ex1);
                return;
            }

            if (object.Equals(cellvalue, datavalue)) return;

            this.Value = datavalue;
        }

        /*
        private void OnBindingComplete(object sender, BindingCompleteEventArgs e)
        {
            var bs = dataSource as BindingSource;
            if (bs == null) return;
            var drv = bs.Current as DataRowView;
            var grid = this.GridRow.Grid as MyGrid;

            if (e.BindingCompleteState != BindingCompleteState.Success)
            {
                if (grid != null)
                {
                    var ex1 = new MyException("Ievadīta nnekorekta lauka vērtība.", e.Exception);
                    grid.OnDataError(ex1);
                }
                return;
            }
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            {
                if (drv != null)
                {
                    drv.EndEdit();
                }
            }
        }
        */

        public string[] GetPropertyValueList(string propname)
        {
            if (propname == "GridPropertyName")
            {
                if (Owner == null || Owner.Grid == null ||
                    Owner.Grid.MyData == null)
                    return null;
                var o = Owner.Grid.MyData;
                var ar = o.GetType().GetCustomAttributesData()
                    .Where(a => a.Constructor.DeclaringType.Name == "NotifyPropertyChangedAttribute")
                    .SelectMany(a => a.NamedArguments)
                    .Where(a => a.MemberInfo.Name == "Filter")
                    .FirstOrDefault();
                string filter = "_";
                if (ar != null && ar.TypedValue.Value != null)
                    filter = ar.TypedValue.Value as string;
                var list = o.GetType().GetProperties()
                    .Where(p => (p.Name.StartsWith(filter) && p.CanWrite))
                    .Select(p => p.Name)
                    .ToArray();
                return list;
            }
            else if (propname == "EditorTemplateName")
            {
                if (Owner == null || Owner.Grid == null)
                    return null;
                return Owner.Grid.RowTemplateList.GetNameList();
            }
            return null;
        }

        [DefaultValue(null)]
        public string FormatString { get; set; } = null;

        protected static NumberTypeConverter moneyTypeConverter = new NumberTypeConverter(typeof(decimal), "N2");
        protected static DateTimeTypeConverter dateTypeConverter = new DateTimeTypeConverter("dd.MM.yyyy", new[] { "dd.MM.yyyy" });


        public const string NoDataStringValue = "{}?>SA!@|09yū";

        public virtual object GetNoDataValue()
        {
            switch (RowValueType)
            {
                case EMyGridRowValueType.String:
                    return NoDataStringValue;
                case EMyGridRowValueType.Integer:
                    return Int32.MinValue;
                case EMyGridRowValueType.IntegerN:
                    return null;
                case EMyGridRowValueType.ShortInt:
                    return Int16.MinValue;
                case EMyGridRowValueType.Date:
                    return DateTime.MinValue;
                case EMyGridRowValueType.DateN:
                    return null;
                case EMyGridRowValueType.Single:
                    return Single.MinValue;
                case EMyGridRowValueType.Double:
                    return Double.MinValue;
                case EMyGridRowValueType.Decimal:
                    return decimal.MinValue;
                case EMyGridRowValueType.DecimalN:
                    return null;
            }
            return null;
        }

        protected TypeConverter GetMyTypeConverter()
        {
            TypeConverter tc = null;
            if (!string.IsNullOrEmpty(FormatString))
            {
                switch (RowValueType)
                {
                    case EMyGridRowValueType.Date:
                    case EMyGridRowValueType.DateN:
                        tc = new DateTimeTypeConverter(FormatString, new[] { FormatString });
                        break;
                    case EMyGridRowValueType.Single:
                        tc = new NumberTypeConverter(typeof(Single), FormatString);
                        break;
                    case EMyGridRowValueType.Double:
                        tc = new NumberTypeConverter(typeof(double), FormatString);
                        break;
                    case EMyGridRowValueType.Decimal:
                    case EMyGridRowValueType.DecimalN:
                        tc = new NumberTypeConverter(typeof(decimal), FormatString);
                        break;
                }
            }
            else
            {
                switch (RowValueType)
                {
                    case EMyGridRowValueType.Date:
                    case EMyGridRowValueType.DateN:
                        tc = dateTypeConverter;
                        break;
                    case EMyGridRowValueType.Decimal:
                    case EMyGridRowValueType.DecimalN:
                        tc = moneyTypeConverter;
                        break;
                }
            }
            return tc;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool NoData
        {
            get
            {
                if (DataSource == null) return false;
                var cm = DataSource as ICurrencyManagerProvider;
                if (cm != null)
                {
                    if (cm.CurrencyManager == null) return true;
                    if (cm.CurrencyManager.Count == 0) return true;
                    if (cm.CurrencyManager.Position == -1) return true;
                    //if (cm.CurrencyManager.Current is DataRowView &&
                    //    (cm.CurrencyManager.Current as DataRowView).Row.RowState == DataRowState.Detached) return true;
                    return false;
                }
                var il = DataSource as IList;
                if (il != null && il.Count == 0) return true;
                return false;
            }
        }

        public virtual bool IsRed(object comparewith)
        {
            if (string.IsNullOrEmpty(DataMember)) return false;
            object val;
            if (!Utils.GetPublicPropertyValue(comparewith, DataMember, out val)) return false;
            return !object.Equals(this.Value, val);
        }

        public virtual bool IsRed(object[] dataprev, object[] datacur, 
            object[] datasource)
        {
            if (string.IsNullOrEmpty(DataMember)) return false;
            if (dataprev == null || datacur == null || datasource == null) return false;
            if (dataprev.Length != datasource.Length || datacur.Length != datasource.Length)
                throw new ArgumentException("Size differs.");

            int k = datasource.IndexOf(this.dataSource);
            if (k == -1) return false;

            object data_prev = dataprev[k];
            object data_cur = datacur[k];
            object val_prev, val_cur;

            if (!Utils.GetPublicPropertyValue(data_prev, DataMember, out val_prev)) return false;
            if (!Utils.GetPublicPropertyValue(data_cur, DataMember, out val_cur)) return false;
            if (val_prev == DBNull.Value || object.Equals(val_prev, string.Empty)) val_prev = null;
            if (val_cur == DBNull.Value || object.Equals(val_cur, string.Empty)) val_cur = null;
            return !object.Equals(val_prev, val_cur);
        }

        public bool MarkRowRed(bool red)
        {
            SourceGrid.Cells.Views.Cell vw;

            var cell = this.Grid[RowNr, RowHeaderColumnNr];
            if (cell == null) return false;
            var controller = cell.FindController<RowMarkCellController>();
            if (controller == null) return false;

            if (red) vw = this.Grid.gridViewModel.rowHeaderModelRed;
            else vw = this.Grid.gridViewModel.rowHeaderModel;

            bool ret = cell.View != vw;
            if (!ret) return false;
            cell.View = vw;
            Grid.InvalidateCell(cell);
            return ret;
        }

        public bool CheckRedRow(object[] dataprev, object[] datacur, object[] datasource, bool clearreds = false)
        {
            bool red, haschanges;

            if (clearreds)
                red = false;
            else
                red = IsRed(dataprev, datacur, datasource);

            haschanges = MarkRowRed(red);
            return haschanges;
        }

        protected virtual void ConvertingObjectToValue(ConvertingObjectEventArgs e)
        {
            if (e.Value is string)
            {
                double val;
                if (double.TryParse((string)e.Value, out val))
                {
                    e.Value = val;
                    e.ConvertingStatus = DevAge.ComponentModel.ConvertingStatus.Completed;
                }
            }
        }

    }

}
