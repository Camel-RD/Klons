using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using KlonsLIB.Misc;

namespace KlonsLIB.Components
{
    public interface IMyDgvTextboxEditingControlEvents2
    {
        void OnButtonClicked(MyDgvTextboxEditingControl2 control);
    }

    [ToolboxItem(false)]
    public class MyDgvTextboxEditingControl2 : MyPickRowTextBox2, IDataGridViewEditingControl
    {
        private DataGridView dataGridView;
        private bool valueChanged = false;
        private int rowIndex;

        public bool LimitToList { get; set; }

        public MyDgvTextboxEditingControl2()
        {
            LimitToList = true;
            BorderStyle = BorderStyle.None;
            ShowButton = true;
            SyncPosition = false;
        }

        public object EditingControlFormattedValue
        {
            get
            {
                if (LimitToList && SelectedValue == null)
                    return "";
                return SelectedValue == null ? "" : SelectedValue.ToString();
                //return this.Text;
            }
            set
            {
                if (!(value is string)) return;
                try
                {
                    this.SelectedValueAsString = (string)value;
                }
                catch
                {
                    this.SelectedValue = null;
                }
                /*
                string valueStr = value as string;
                if (valueStr != null)
                {
                    this.Text = valueStr;
                    if (String.Compare(valueStr, Text, true, CultureInfo.CurrentCulture) != 0)
                    {
                        SelectedIndex = -1;
                    }
                }
                return;*/
            }
        }

        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        public int EditingControlRowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                        return true;

                case Keys.Home:
                case Keys.End:
                case Keys.Back:
                case Keys.F4:
                case Keys.Enter:
                    return true;

                case Keys.Left:
                    return this.SelectionStart + this.SelectionLength > 0;

                case Keys.Right:
                    return this.SelectionStart + this.SelectionLength < this.Text.Length;
            }
            return !dataGridViewWantsInputKey;

            /*    
            if (((((keyData & Keys.KeyCode) != Keys.Down) && ((keyData & Keys.KeyCode) != Keys.Up)) && (!base.DroppedDown || ((keyData & Keys.KeyCode) != Keys.Escape))) && ((keyData & Keys.KeyCode) != Keys.Enter))
            {
                return !dataGridViewWantsInputKey;
            }
            return true;
            */
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {

        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public DataGridView EditingControlDataGridView
        {
            get { return dataGridView; }
            set { dataGridView = value; }
        }

        public bool EditingControlValueChanged
        {
            get { return valueChanged; }
            set { valueChanged = value; }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        protected override void OnSelectedIndexChanged()
        {
            base.OnSelectedIndexChanged();
            if (valueChanged) return;
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnTextChanged(e);
        }

        protected override void OnButtonClicked(EventArgs e)
        {
            base.OnButtonClicked(e);
            var ievents = dataGridView?.FindForm() as IMyDgvTextboxEditingControlEvents2;
            if (ievents == null) return;
            ievents.OnButtonClicked(this);
        }
    }


    public class MyDgvTextboxCell2 : DataGridViewTextBoxCell
    {
        private static Type defaultFormattedValueType = typeof(System.String);
        private static Type defaultValueType = typeof(System.Object);

        private MyDgvTextboxEditingControl2 m_EditingControl = null;
        public MyDgvTextboxColumn2 TemplateDGVColumn = null;
        private object m_DataSource;
        private string m_DisplayMember;
        private string m_ValueMember;
        private bool m_limitToList = true;
        private PropertyDescriptor m_ValueMemberProperty = null;
        private PropertyDescriptor m_DisplayMemberProperty = null;
        private CurrencyManager m_DataManager = null;
        
        private byte flags;
        private const byte FLAG_dataSourceInitializedHookedUp = 0x01;



        public MyDgvTextboxCell2() : base()
        {
        }

        public override object Clone()
        {
            MyDgvTextboxCell2 cell = (MyDgvTextboxCell2)base.Clone();
            cell.DataSource = this.DataSource;
            cell.DisplayMember = this.DisplayMember;
            cell.ValueMember = this.ValueMember;
            cell.LimitToList = this.LimitToList;
            return cell;
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            m_EditingControl = base.DataGridView.EditingControl as MyDgvTextboxEditingControl2;
            if (m_EditingControl == null) return;
            m_EditingControl.BorderStyle = BorderStyle.None;

            m_EditingControl.DataSource = null;
            m_EditingControl.ValueMember = null;
            m_EditingControl.DisplayMember = null;

            m_EditingControl.DataSource = m_DataSource;
            m_EditingControl.DisplayMember = m_DisplayMember;
            m_EditingControl.ValueMember = m_ValueMember;
            m_EditingControl.LimitToList = LimitToList;

            //cat skip, is set in base with Text = ...
            //m_EditingControl.SelectedValue = this.Value;

        }

        public override object ParseFormattedValue(object formattedValue,
            DataGridViewCellStyle cellStyle,
            TypeConverter formattedValueTypeConverter,
            TypeConverter valueTypeConverter)
        {
            if (formattedValue == null) return null;
            return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
        }

        public override Type EditType
        {
            get { return typeof(MyDgvTextboxEditingControl2); }
        }

        public override Type ValueType
        {
            get
            {
                Type valueType = base.ValueType;
                if (valueType != null)
                {
                    return valueType;
                }
                return defaultValueType;
            }
        }

        /*
        public override Type FormattedValueType
        {
            get
            {
                // we return string for the formatted type
                return defaultFormattedValueType;
            }
        }
        */


        private bool OwnsEditingControl(int rowIndex)
        {
            return (((rowIndex != -1) && (m_EditingControl != null)) &&
                    (rowIndex == m_EditingControl.EditingControlRowIndex));
        }

        public object DataSource
        {
            get { return m_DataSource; }
            set
            {
                if (value != null && !(value is IList || value is IListSource))
                {
                    throw new ArgumentException("Bad data source");
                }

                if (this.DataSource != value)
                {
                    this.DataManager = null;
                    UnwireDataSource();

                    m_DataSource = value;
                    WireDataSource(value);

                    try
                    {
                        InitializeDisplayMemberPropertyDescriptor(this.DisplayMember);
                    }
                    catch (Exception exception)
                    {
                        Debug.Assert(this.DisplayMember != null && this.DisplayMember.Length > 0);
                        this.DisplayMemberInternal = null;
                    }

                    try
                    {
                        InitializeValueMemberPropertyDescriptor(this.ValueMember);
                    }
                    catch (Exception exception)
                    {
                        Debug.Assert(this.ValueMember != null && this.ValueMember.Length > 0);
                        this.ValueMemberInternal = null;
                    }

                    if (value == null)
                    {
                        this.DisplayMemberInternal = null;
                        this.ValueMemberInternal = null;
                    }

                    if (OwnsEditingControl(this.RowIndex))
                    {
                        this.m_EditingControl.DataSource = value;
                        InitializeComboBoxText();
                    }
                    else
                    {
                        OnCommonChange();
                    }
                }
            }
        }

        private void InitializeComboBoxText()
        {
            Debug.Assert(this.m_EditingControl != null);
            ((IDataGridViewEditingControl)this.m_EditingControl).EditingControlValueChanged = false;
            int rowIndex = ((IDataGridViewEditingControl)this.m_EditingControl).EditingControlRowIndex;
            Debug.Assert(rowIndex > -1);
            DataGridViewCellStyle dataGridViewCellStyle = GetInheritedStyle(null, rowIndex, false);
            this.m_EditingControl.Text = (string)GetFormattedValue(GetValue(rowIndex), rowIndex, ref dataGridViewCellStyle, null, null, DataGridViewDataErrorContexts.Formatting);
        }

        internal void OnCommonChange()
        {
            if (this.DataGridView != null && !this.DataGridView.IsDisposed && !this.DataGridView.Disposing)
            {
                if (this.RowIndex == -1)
                {
                    this.DataGridView.InvalidateColumn(this.ColumnIndex);
                }
                else
                {
                    this.DataGridView.InvalidateCell(this.ColumnIndex, this.RowIndex);
                }
            }
        }



        private string DisplayMemberInternal
        {
            set
            {
                InitializeDisplayMemberPropertyDescriptor(value);
                if ((value != null && value.Length > 0))
                {
                    m_DisplayMember = value;
                }
            }
        }

        private string ValueMemberInternal
        {
            set
            {
                InitializeValueMemberPropertyDescriptor(value);
                if ((value != null && value.Length > 0))
                {
                    m_ValueMember = value;
                }
            }
        }


        public string DisplayMember
        {
            get { return m_DisplayMember; }
            set
            {
                this.DisplayMemberInternal = value;
                if (this.OwnsEditingControl(base.RowIndex))
                {
                    if (m_EditingControl != null)
                    {
                        m_EditingControl.DisplayMember = value;
                    }
                }
                else
                {
                    OnCommonChange();
                }
            }
        }

        public string ValueMember
        {
            get { return m_ValueMember; }
            set
            {
                this.ValueMemberInternal = value;
                if (this.OwnsEditingControl(base.RowIndex))
                {
                    if (m_EditingControl != null)
                    {
                        m_EditingControl.ValueMember = value;
                    }
                }
                else
                {
                    OnCommonChange();
                }
            }
        }

        private PropertyDescriptor ValueMemberProperty
        {
            get
            {
                return m_ValueMemberProperty;
            }
            set
            {
                m_ValueMemberProperty = value;
            }
        }

        private PropertyDescriptor DisplayMemberProperty
        {
            get
            {
                return m_DisplayMemberProperty;
            }
            set
            {
                m_DisplayMemberProperty = value;
            }
        }

        private CurrencyManager DataManager
        {
            get
            {
                return GetDataManager(this.DataGridView);
            }
            set
            {
                m_DataManager = value;
            }
        }

        private CurrencyManager GetDataManager(DataGridView dataGridView)
        {
            CurrencyManager cm = m_DataManager;
            if (cm == null && this.DataSource != null && dataGridView != null && dataGridView.BindingContext != null && !(this.DataSource == Convert.DBNull))
            {
                ISupportInitializeNotification dsInit = this.DataSource as ISupportInitializeNotification;
                if (dsInit != null && !dsInit.IsInitialized)
                {
                    if ((this.flags & FLAG_dataSourceInitializedHookedUp) == 0x00)
                    {
                        dsInit.Initialized += new EventHandler(DataSource_Initialized);
                        this.flags |= (byte)FLAG_dataSourceInitializedHookedUp;
                    }
                }
                else
                {
                    cm = (CurrencyManager)dataGridView.BindingContext[this.DataSource];
                    this.DataManager = cm;
                    InitializeDisplayMemberPropertyDescriptor(this.DisplayMember);
                    InitializeValueMemberPropertyDescriptor(this.ValueMember);
                }
            }
            return cm;
        }
        
        private void DataSource_Initialized(object sender, EventArgs e)
        {
            Debug.Assert(sender == this.DataSource);
            Debug.Assert(this.DataSource is ISupportInitializeNotification);
            Debug.Assert((this.flags & FLAG_dataSourceInitializedHookedUp) != 0x00);

            ISupportInitializeNotification dsInit = this.DataSource as ISupportInitializeNotification;
            if (dsInit != null)
            {
                dsInit.Initialized -= new EventHandler(DataSource_Initialized);
            }
            this.flags = (byte)(this.flags & ~FLAG_dataSourceInitializedHookedUp);
            InitializeDisplayMemberPropertyDescriptor(this.DisplayMember);
            InitializeValueMemberPropertyDescriptor(this.ValueMember);
        }


        private void InitializeDisplayMemberPropertyDescriptor(string displayMember)
        {
            if (this.DataManager != null)
            {
                if (String.IsNullOrEmpty(displayMember))
                {
                    this.DisplayMemberProperty = null;
                }
                else
                {
                    BindingMemberInfo displayBindingMember = new BindingMemberInfo(displayMember);
                    this.DataManager = this.DataGridView.BindingContext[this.DataSource, displayBindingMember.BindingPath] as CurrencyManager;
                    PropertyDescriptorCollection props = this.DataManager.GetItemProperties();
                    PropertyDescriptor displayMemberProperty = props.Find(displayBindingMember.BindingField, true);
                    if (displayMemberProperty == null)
                    {
                        throw new ArgumentException($"Field [{displayMember}] not found");
                    }
                    else
                    {
                        this.DisplayMemberProperty = displayMemberProperty;
                    }
                }
            }
        }

        private void InitializeValueMemberPropertyDescriptor(string valueMember)
        {
            if (this.DataManager != null)
            {
                if (String.IsNullOrEmpty(valueMember))
                {
                    this.ValueMemberProperty = null;
                }
                else
                {
                    BindingMemberInfo valueBindingMember = new BindingMemberInfo(valueMember);
                    this.DataManager = this.DataGridView.BindingContext[this.DataSource, valueBindingMember.BindingPath] as CurrencyManager;
                    PropertyDescriptorCollection props = this.DataManager.GetItemProperties();
                    PropertyDescriptor valueMemberProperty = props.Find(valueBindingMember.BindingField, true);
                    if (valueMemberProperty == null)
                    {
                        throw new ArgumentException($"Field [{valueMember}] not found");
                    }
                    else
                    {
                        this.ValueMemberProperty = valueMemberProperty;
                    }

                    if ((this.DataManager.List is IBindingList) && ((IBindingList)this.DataManager.List).SupportsSearching
                        && ValueMemberProperty != null)
                    {
                        ((IBindingList)this.DataManager.List).AddIndex(ValueMemberProperty);
                    }
                }
            }
        }

        private void DataSource_Disposed(object sender, EventArgs e)
        {
            Debug.Assert(sender == this.DataSource, "How can we get dispose notification from anything other than our DataSource?");
            this.DataSource = null;
        }

        private void WireDataSource(object dataSource)
        {
            IComponent component = dataSource as IComponent;
            if (component != null)
            {
                component.Disposed += new EventHandler(DataSource_Disposed);
            }
        }

        private void UnwireDataSource()
        {
            IComponent component = this.DataSource as IComponent;
            if (component != null)
            {
                component.Disposed -= new EventHandler(DataSource_Disposed);
            }
            ISupportInitializeNotification dsInit = this.DataSource as ISupportInitializeNotification;
            if (dsInit != null && (this.flags & FLAG_dataSourceInitializedHookedUp) != 0x00)
            {
                dsInit.Initialized -= new EventHandler(DataSource_Initialized);
                this.flags = (byte)(this.flags & ~FLAG_dataSourceInitializedHookedUp);
            }
        }


        protected override object GetFormattedValue(
            object value,
            int rowIndex,
            ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter,
            DataGridViewDataErrorContexts context)
        {
            if (valueTypeConverter == null)
            {
                if(DataSource == null)
                {
                    return base.GetFormattedValue(null, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
                }
                if (this.ValueMemberProperty != null)
                {
                    valueTypeConverter = this.ValueMemberProperty.Converter;
                }
                else if (this.DisplayMemberProperty != null)
                {
                    valueTypeConverter = this.DisplayMemberProperty.Converter;
                }
            }

            if (value == null || ((this.ValueType != null && !this.ValueType.IsAssignableFrom(value.GetType())) && value != System.DBNull.Value))
            {
                if (value == null)
                {
                    return base.GetFormattedValue(null, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
                }
                if (this.DataGridView != null)
                {
                    DataGridViewDataErrorEventArgs dgvdee = new DataGridViewDataErrorEventArgs(
                        new FormatException("Invalid cell value"), this.ColumnIndex,
                        rowIndex, context);
                    RaiseDataError(dgvdee);
                    if (dgvdee.ThrowException)
                    {
                        throw dgvdee.Exception;
                    }
                }
                return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            }

            String strValue = value as String;
            if ((this.DataManager != null && (this.ValueMemberProperty != null || this.DisplayMemberProperty != null)) ||
                !string.IsNullOrEmpty(this.ValueMember) || !string.IsNullOrEmpty(this.DisplayMember))
            {
                object displayValue;
                if (!LookupDisplayValue(rowIndex, value, out displayValue))
                {
                    if (value == System.DBNull.Value)
                    {
                        displayValue = System.DBNull.Value;
                    }
                    else if (strValue != null && String.IsNullOrEmpty(strValue) && this.DisplayType == typeof(String))
                    {
                        displayValue = String.Empty;
                    }
                    else if (this.DataGridView != null)
                    {
                        DataGridViewDataErrorEventArgs dgvdee = new DataGridViewDataErrorEventArgs(
                            new ArgumentException("Invalid cell value"), this.ColumnIndex,
                            rowIndex, context);
                        RaiseDataError(dgvdee);
                        if (dgvdee.ThrowException)
                        {
                            throw dgvdee.Exception;
                        }

                        if (OwnsEditingControl(rowIndex))
                        {
                            ((IDataGridViewEditingControl)this.m_EditingControl).EditingControlValueChanged = true;
                            this.DataGridView.NotifyCurrentCellDirty(true);
                        }
                    }
                }
                return base.GetFormattedValue(displayValue, rowIndex, ref cellStyle, this.DisplayTypeConverter, formattedValueTypeConverter, context);
            }
            else
            {
                return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            }
        }

        private Type DisplayType
        {
            get
            {
                if (this.DisplayMemberProperty != null)
                {
                    return this.DisplayMemberProperty.PropertyType;
                }
                else if (this.ValueMemberProperty != null)
                {
                    return this.ValueMemberProperty.PropertyType;
                }
                else
                {
                    return defaultFormattedValueType;
                }
            }
        }

        private TypeConverter DisplayTypeConverter
        {
            get
            {
                return TypeDescriptor.GetConverter(this.DisplayType);
            }
        }

        private bool LookupDisplayValue(int rowIndex, object value, out object displayValue)
        {
            Debug.Assert(value != null);
            Debug.Assert(this.ValueMemberProperty != null || this.DisplayMemberProperty != null ||
                         !string.IsNullOrEmpty(this.ValueMember) || !string.IsNullOrEmpty(this.DisplayMember));

            object item = null;
            if (this.DisplayMemberProperty != null || this.ValueMemberProperty != null)
            {
                item = this.ItemFromComboBoxDataSource(this.ValueMemberProperty != null ? this.ValueMemberProperty : this.DisplayMemberProperty, value);
            }
            if (item == null)
            {
                displayValue = null;
                return false;
            }

            displayValue = GetItemDisplayValue(item);
            return true;
        }

        internal object GetItemDisplayValue(object item)
        {
            Debug.Assert(item != null);
            bool displayValueSet = false;
            object displayValue = null;
            if (this.DisplayMemberProperty != null)
            {
                displayValue = this.DisplayMemberProperty.GetValue(item);
                displayValueSet = true;
            }
            else if (this.ValueMemberProperty != null)
            {
                displayValue = this.ValueMemberProperty.GetValue(item);
                displayValueSet = true;
            }
            else if (!string.IsNullOrEmpty(this.DisplayMember))
            {
                PropertyDescriptor propDesc = TypeDescriptor.GetProperties(item).Find(this.DisplayMember, true /*caseInsensitive*/);
                if (propDesc != null)
                {
                    displayValue = propDesc.GetValue(item);
                    displayValueSet = true;
                }
            }
            else if (!string.IsNullOrEmpty(this.ValueMember))
            {
                PropertyDescriptor propDesc = TypeDescriptor.GetProperties(item).Find(this.ValueMember, true /*caseInsensitive*/);
                if (propDesc != null)
                {
                    displayValue = propDesc.GetValue(item);
                    displayValueSet = true;
                }
            }
            if (!displayValueSet)
            {
                displayValue = item;
            }
            return displayValue;
        }

        private object ItemFromComboBoxDataSource(PropertyDescriptor property, object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            Debug.Assert(property != null);
            Debug.Assert(this.DataManager != null);
            object item = null;

            if ((this.DataManager.List is IBindingList) && ((IBindingList)this.DataManager.List).SupportsSearching)
            {
                int index = ((IBindingList)this.DataManager.List).Find(property, key);
                if (index != -1)
                {
                    item = this.DataManager.List[index];
                }
            }
            else
            {
                for (int i = 0; i < this.DataManager.List.Count; i++)
                {
                    object itemTmp = this.DataManager.List[i];
                    object value = property.GetValue(itemTmp);
                    if (key.Equals(value))
                    {
                        item = itemTmp;
                        break;
                    }
                }
            }
            return item;
        }


        public bool LimitToList
        {
            get { return m_limitToList; }
            set
            {
                m_limitToList = value;
                if (this.OwnsEditingControl(base.RowIndex))
                    if (m_EditingControl != null)
                    {
                        m_EditingControl.LimitToList = value;
                    }
            }
        }

        public void ScaleColumn(SizeF factor)
        {
            if (this.OwnsEditingControl(base.RowIndex))
                if (m_EditingControl != null)
                {
                    //m_EditingControl.ScaleControlA(factor);
                }
        }



    }


    public class MyDgvTextboxColumn2 : DataGridViewColumn
    {
        public MyDgvTextboxColumn2() : base(new MyDgvTextboxCell2())
        {
            TextBoxCellTemplateA.TemplateDGVColumn = this;
        }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(MyDgvTextboxCell2)))
                {
                    throw new InvalidCastException("Must be a MyDgvTextboxCell");
                }
                base.CellTemplate = value;
            }
        }

        private MyDgvTextboxCell2 TextBoxCellTemplateA
        {
            get { return (MyDgvTextboxCell2)this.CellTemplate; }
        }

        private void CheckCellTemplate()
        {
            if (this.TextBoxCellTemplateA == null)
            {
                throw new InvalidOperationException("DataGridViewColumn_CellTemplateRequired");
            }
        }

        private void ApplyToCells(Action<MyDgvTextboxCell2> act)
        {
            if (this.DataGridView == null) return;
            DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
            int rowCount = dataGridViewRows.Count;
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                MyDgvTextboxCell2 dataGridViewCell = dataGridViewRow.Cells[this.Index] as MyDgvTextboxCell2;
                if (dataGridViewCell != null)
                {
                    act(dataGridViewCell);
                }
            }
        }


        [
            DefaultValue(null),
            Category("Data"),
            RefreshProperties(RefreshProperties.Repaint),
            AttributeProvider(typeof(IListSource)),
        ]
        public object DataSource
        {
            get
            {
                CheckCellTemplate();
                return this.TextBoxCellTemplateA.DataSource;
            }
            set
            {
                CheckCellTemplate();
                this.TextBoxCellTemplateA.DataSource = value;
                ApplyToCells(cell => cell.DataSource = value);
            }
        }

        [
            DefaultValue(""),
            Category("Data"),
            TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, " + AssemblyRef1.SystemDesign),
            Editor("System.Windows.Forms.Design.DataMemberFieldEditor, " + AssemblyRef1.SystemDesign,
                typeof(System.Drawing.Design.UITypeEditor))
        ]
        public string DisplayMember
        {
            get
            {
                CheckCellTemplate();
                return this.TextBoxCellTemplateA.DisplayMember;
            }
            set
            {
                CheckCellTemplate();
                this.TextBoxCellTemplateA.DisplayMember = value;
                ApplyToCells(cell => cell.DisplayMember = value);
            }
        }

        [
            DefaultValue(""),
            Category("Data"),
            TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, " + AssemblyRef1.SystemDesign),
            Editor("System.Windows.Forms.Design.DataMemberFieldEditor, " + AssemblyRef1.SystemDesign,
                typeof(System.Drawing.Design.UITypeEditor))
        ]
        public string ValueMember
        {
            get
            {
                CheckCellTemplate();
                return this.TextBoxCellTemplateA.ValueMember;
            }
            set
            {
                CheckCellTemplate();
                this.TextBoxCellTemplateA.ValueMember = value;
                ApplyToCells(cell => cell.ValueMember = value);
            }
        }

        [DefaultValue(true),
         Category("Behavior")]
        public bool LimitToList
        {
            get
            {
                CheckCellTemplate();
                return this.TextBoxCellTemplateA.LimitToList;
            }
            set
            {
                CheckCellTemplate();
                if (LimitToList != value)
                {
                    this.TextBoxCellTemplateA.LimitToList = value;
                    ApplyToCells(cell => cell.LimitToList = value);
                }
            }
        }

        public void ScaleColumn(SizeF factor)
        {
            this.TextBoxCellTemplateA.ScaleColumn(factor);
            if (base.DataGridView != null)
            {
                DataGridViewRowCollection rows = base.DataGridView.Rows;
                int count = rows.Count;
                for (int i = 0; i < count; i++)
                {
                    MyDgvTextboxCell2 cell = rows.SharedRow(i).Cells[base.Index] as MyDgvTextboxCell2;
                    if (cell != null)
                    {
                        cell.ScaleColumn(factor);
                    }
                }
            }
        }

        public event EventHandler ButtonClicked;
    }
}
