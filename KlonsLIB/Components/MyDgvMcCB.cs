using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KlonsLIB.Misc;

namespace KlonsLIB.Components
{

    public class MyDgvMcCBColumn : DataGridViewColumn
    {
        public MyDgvMcCBColumn()
            : base(new MyDgvMcCBCell())
        {
            ComboBoxCellTemplateA.TemplateDGVCBColumn = this;
        }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof (MyDgvMcCBCell)))
                {
                    throw new InvalidCastException("Must be a MyDgvMcCBCell");
                }
                base.CellTemplate = value;
            }
        }

        private MyDgvMcCBCell ComboBoxCellTemplateA
        {
            get { return (MyDgvMcCBCell) this.CellTemplate; }
        }

        private bool StringArraysMatch(string[] sa1, string[] sa2)
        {
            if (sa1 == null && sa2 == null) return true;
            if (sa1 == null || sa2 == null) return false;
            if (sa1.Length != sa2.Length) return false;
            for (int i = 0; i < sa1.Length; i++)
            {
                if (string.Compare(sa1[i], sa2[i], true) != 0) return false;

            }
            return true;
        }

        [
            DefaultValue(null),
            Category("Data"),
            RefreshProperties(RefreshProperties.Repaint),
            AttributeProvider(typeof (IListSource)),
        ]
        public object DataSource
        {
            get
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("DataGridViewColumn_CellTemplateRequired");
                }
                return this.ComboBoxCellTemplateA.DataSource;
            }
            set
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("DataGridViewColumn_CellTemplateRequired");
                }
                this.ComboBoxCellTemplateA.DataSource = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        MyDgvMcCBCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as MyDgvMcCBCell;
                        if (dataGridViewCell != null)
                        {
                            dataGridViewCell.DataSource = value;
                        }
                    }
                }
            }
        }

        /// <include file='doc\DataGridViewComboBoxColumn.uex' path='docs/doc[@for="DataGridViewComboBoxColumn.DisplayMember"]/*' />
        [
            DefaultValue(""),
            Category("Data"),
            TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, " + AssemblyRef1.SystemDesign),
            Editor("System.Windows.Forms.Design.DataMemberFieldEditor, " + AssemblyRef1.SystemDesign,
                typeof (System.Drawing.Design.UITypeEditor))
        ]
        public string DisplayMember
        {
            get
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("DataGridViewColumn_CellTemplateRequired");
                }
                return this.ComboBoxCellTemplateA.DisplayMember;
            }
            set
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("DataGridViewColumn_CellTemplateRequired");
                }
                this.ComboBoxCellTemplateA.DisplayMember = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        MyDgvMcCBCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as MyDgvMcCBCell;
                        if (dataGridViewCell != null)
                        {
                            dataGridViewCell.DisplayMember = value;
                        }
                    }
                }
            }
        }

        [
            DefaultValue(""),
            Category("Data"),
            TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, " + AssemblyRef1.SystemDesign),
            Editor("System.Windows.Forms.Design.DataMemberFieldEditor, " + AssemblyRef1.SystemDesign,
                typeof (System.Drawing.Design.UITypeEditor))
        ]
        public string ValueMember
        {
            get
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("DataGridViewColumn_CellTemplateRequired");
                }
                return this.ComboBoxCellTemplateA.ValueMember;
            }
            set
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("DataGridViewColumn_CellTemplateRequired");
                }
                this.ComboBoxCellTemplateA.ValueMember = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        MyDgvMcCBCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as MyDgvMcCBCell;
                        if (dataGridViewCell != null)
                        {
                            dataGridViewCell.ValueMember = value;
                        }
                    }
                }
            }
        }


        [DefaultValue(null),
         Category("Data")]
        public string[] ColumnNames
        {
            get
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("MyDgvMcCBColumn_CellTemplateRequired");
                }
                return this.ComboBoxCellTemplateA.ColumnNames;
            }
            set
            {
                if (StringArraysMatch(this.ColumnNames, value)) return;

                this.ComboBoxCellTemplateA.ColumnNames = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDgvMcCBCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcCBCell;
                        if (cell != null)
                        {
                            cell.ColumnNames = value;
                        }
                    }
                }

            }
        }

        [Description("String items with columns seperated by ';'")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(null)]
        [Category("Data")]
        public string[] ItemStrings
        {
            get
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("MyDgvMcCBColumn_CellTemplateRequired");
                }
                return this.ComboBoxCellTemplateA.ItemStrings;
            }
            set
            {
                if (StringArraysMatch(this.ItemStrings, value)) return;

                this.ComboBoxCellTemplateA.ItemStrings = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDgvMcCBCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcCBCell;
                        if (cell != null)
                        {
                            cell.ItemStrings = value;
                        }
                    }
                }

            }
        }


        [DefaultValue("100"),
         Description("Column width seperated with ';'"),
         Category("Behavior")]
        public string ColumnWidths
        {
            get
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("MyDgvMcCBColumn_CellTemplateRequired");
                }
                return this.ComboBoxCellTemplateA.ColumnWidths;
            }
            set
            {
                if (ColumnWidths == value) return;

                this.ComboBoxCellTemplateA.ColumnWidths = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDgvMcCBCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcCBCell;
                        if (cell != null)
                        {
                            cell.ColumnWidths = value;
                        }
                    }
                }

            }
        }

        /*
        public void ResizeColumns(float basefontsize)
        {
            this.ComboBoxCellTemplateA.ResizeColumns(basefontsize);
            if (base.DataGridView != null)
            {
                DataGridViewRowCollection rows = base.DataGridView.Rows;
                int count = rows.Count;
                for (int i = 0; i < count; i++)
                {
                    MyDgvMcCBCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcCBCell;
                    if (cell != null)
                    {
                        cell.ResizeColumns(basefontsize);
                    }
                }
            }
        }
        */

        public void ScaleColumn(SizeF factor)
        {
            this.ComboBoxCellTemplateA.ScaleColumn(factor);
            if (base.DataGridView != null)
            {
                DataGridViewRowCollection rows = base.DataGridView.Rows;
                int count = rows.Count;
                for (int i = 0; i < count; i++)
                {
                    MyDgvMcCBCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcCBCell;
                    if (cell != null)
                    {
                        cell.ScaleColumn(factor);
                    }
                }
            }
        }


        [DefaultValue("15"),
         Category("Behavior")]
        public int MaxDropDownItems
        {
            get
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("MyDgvMcCBColumn_CellTemplateRequired");
                }
                return this.ComboBoxCellTemplateA.MaxDropDownItems;
            }
            set
            {
                if (MaxDropDownItems != value)
                {
                    this.ComboBoxCellTemplateA.MaxDropDownItems = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection rows = base.DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            MyDgvMcCBCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcCBCell;
                            if (cell != null)
                            {
                                cell.MaxDropDownItems = value;
                            }
                        }
                    }
                }
            }
        }

        [DefaultValue(MyMcComboBox.CustomDropDownStyle.DropDown),
         Category("Behavior")]
        public MyMcComboBox.CustomDropDownStyle DropDownStyle
        {
            get
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("MyDgvMcCBColumn_CellTemplateRequired");
                }
                return this.ComboBoxCellTemplateA.DropDownStyle;
            }
            set
            {
                if (DropDownStyle != value)
                {
                    this.ComboBoxCellTemplateA.DropDownStyle = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection rows = base.DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            MyDgvMcCBCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcCBCell;
                            if (cell != null)
                            {
                                cell.DropDownStyle = value;
                            }
                        }
                    }
                }
            }
        }

        [DefaultValue(true),
         Category("Behavior")]
        public bool LimitToList
        {
            get
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("MyDgvMcCBColumn_CellTemplateRequired");
                }
                return this.ComboBoxCellTemplateA.LimitToList;
            }
            set
            {
                if (LimitToList != value)
                {
                    this.ComboBoxCellTemplateA.LimitToList = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection rows = base.DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            MyDgvMcCBCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcCBCell;
                            if (cell != null)
                            {
                                cell.LimitToList = value;
                            }
                        }
                    }
                }
            }
        }

    }


    public class MyDgvMcCBCell : DataGridViewTextBoxCell
    {
        private MyDgvMcCBEditingControl m_EditingComboBox = null;
        public MyDgvMcCBColumn TemplateDGVCBColumn = null;
        private string[] m_ColumnNames;
        private string m_ColumnWidths = "100";
        private int m_DropDownWidth = 100;
        private object m_DataSource;
        private string m_DisplayMember;
        private string m_ValueMember;
        private int m_MaxDropDownItems = 15;
        private string[] m_ItemStrings = null;
        private MyMcComboBox.CustomDropDownStyle m_DropDownStyle;
        private bool m_limitToList = true;


        public MyDgvMcCBCell()
            : base()
        {
        }

        public override object Clone()
        {
            MyDgvMcCBCell cell = (MyDgvMcCBCell) base.Clone();
            cell.ColumnNames = this.ColumnNames;
            cell.ColumnWidths = this.ColumnWidths;
            cell.DropDownWidth = this.DropDownWidth;
            //cell.ResizeColumns(10.0f);
            cell.MaxDropDownItems = this.MaxDropDownItems;
            cell.DropDownStyle = this.DropDownStyle;
            cell.DataSource = this.DataSource;
            cell.ItemStrings = this.ItemStrings;
            cell.DisplayMember = this.DisplayMember;
            cell.ValueMember = this.ValueMember;
            cell.LimitToList = this.LimitToList;
            return cell;
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            m_EditingComboBox = base.DataGridView.EditingControl as MyDgvMcCBEditingControl;
            if (m_EditingComboBox == null) return;
            m_EditingComboBox.DropDownStyle = DropDownStyle;
            m_EditingComboBox.FlatStyle = FlatStyle.Flat;
            m_EditingComboBox.FormattingEnabled = true;
            m_EditingComboBox.MaxDropDownItems = MaxDropDownItems;

            m_EditingComboBox.DataSource = null;
            m_EditingComboBox.ValueMember = null;
            m_EditingComboBox.DisplayMember = null;
            m_EditingComboBox.Items.Clear();
            m_EditingComboBox.ItemStrings = null;

            m_EditingComboBox.DataSource = m_DataSource;
            m_EditingComboBox.ItemStrings = m_ItemStrings;
            m_EditingComboBox.DisplayMember = m_DisplayMember;
            m_EditingComboBox.ValueMember = m_ValueMember;
            m_EditingComboBox.ColumnNames = ColumnNames;
            m_EditingComboBox.ColumnWidths = ColumnWidths;
            m_EditingComboBox.LimitToList = LimitToList;

            //m_EditingComboBox.ResizeColumns(10.0f);
            if (this.DataGridView is MyDataGridView)
                m_EditingComboBox.ScaleControlA((this.DataGridView as MyDataGridView).ScaleFactor);

            if (m_EditingComboBox.DropDownWidth != this.DropDownWidth)
                this.DropDownWidth = m_EditingComboBox.DropDownWidth;

            m_EditingComboBox.SelectedValue = this.Value;

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
            get { return typeof (MyDgvMcCBEditingControl); }
        }

        public override Type ValueType
        {
            get
            {
                if (ItemStrings != null)
                {
                    return typeof (MyMcComboBox.MyItem);
                }
                return typeof (string);
            }
        }

        private bool OwnsEditingComboBox(int rowIndex)
        {
            return (((rowIndex != -1) && (m_EditingComboBox != null)) &&
                    (rowIndex == m_EditingComboBox.EditingControlRowIndex));
        }

        public object DataSource
        {
            get { return m_DataSource; }
            set
            {
                m_DataSource = value;
                if (this.OwnsEditingComboBox(base.RowIndex))
                    if (m_EditingComboBox != null)
                    {
                        m_EditingComboBox.DataSource = value;
                    }
            }
        }

        public string DisplayMember
        {
            get { return m_DisplayMember; }
            set
            {
                m_DisplayMember = value;
                if (this.OwnsEditingComboBox(base.RowIndex))
                    if (m_EditingComboBox != null)
                    {
                        m_EditingComboBox.DisplayMember = value;
                    }
            }
        }

        public string ValueMember
        {
            get { return m_ValueMember; }
            set
            {
                m_ValueMember = value;
                if (this.OwnsEditingComboBox(base.RowIndex))
                    if (m_EditingComboBox != null)
                    {
                        m_EditingComboBox.ValueMember = value;
                    }
            }
        }

        public string[] ItemStrings
        {
            get { return m_ItemStrings; }
            set
            {
                m_ItemStrings = value;
                if (this.OwnsEditingComboBox(base.RowIndex))
                    if (m_EditingComboBox != null)
                    {
                        m_EditingComboBox.ItemStrings = value;
                    }

            }
        }

        public int DropDownWidth
        {
            get { return m_DropDownWidth; }
            set
            {
                m_DropDownWidth = value;
                if (this.OwnsEditingComboBox(base.RowIndex))
                    if (m_EditingComboBox != null)
                    {
                        m_EditingComboBox.DropDownWidth = value;
                    }
            }
        }

        public int MaxDropDownItems
        {
            get { return m_MaxDropDownItems; }
            set
            {
                m_MaxDropDownItems = value;
                if (this.OwnsEditingComboBox(base.RowIndex))
                    if (m_EditingComboBox != null)
                    {
                        m_EditingComboBox.MaxDropDownItems = value;
                    }
            }
        }

        public string[] ColumnNames
        {
            get { return m_ColumnNames; }
            set
            {
                m_ColumnNames = value;
                if (this.OwnsEditingComboBox(base.RowIndex))
                    if (m_EditingComboBox != null)
                    {
                        m_EditingComboBox.ColumnNames = value;
                    }
            }
        }

        public string ColumnWidths
        {
            get { return m_ColumnWidths; }
            set
            {
                m_ColumnWidths = value;
                if (this.OwnsEditingComboBox(base.RowIndex))
                    if (m_EditingComboBox != null)
                    {
                        m_EditingComboBox.ColumnWidths = value;
                    }
            }
        }

        public bool LimitToList
        {
            get { return m_limitToList; }
            set
            {
                m_limitToList = value;
                if (this.OwnsEditingComboBox(base.RowIndex))
                    if (m_EditingComboBox != null)
                    {
                        m_EditingComboBox.LimitToList = value;
                    }
            }
        }

        public void ScaleColumn(SizeF factor)
        {
            if (this.OwnsEditingComboBox(base.RowIndex))
                if (m_EditingComboBox != null)
                {
                    m_EditingComboBox.ScaleControlA(factor);
                }
        }

        /*
        public void ResizeColumns(float basefontsize)
        {
            if (this.OwnsEditingComboBox(base.RowIndex))
                if (m_EditingComboBox != null)
                {
                    m_EditingComboBox.ResizeColumns(basefontsize);
                }
        }
        */

        public MyMcComboBox.CustomDropDownStyle DropDownStyle
        {
            get { return m_DropDownStyle; }
            set
            {
                if (m_DropDownStyle == value) return;
                m_DropDownStyle = value;
                if (this.OwnsEditingComboBox(base.RowIndex))
                    if (m_EditingComboBox != null)
                    {
                        m_EditingComboBox.DropDownStyle = value;
                    }

            }
        }

    }

    [ToolboxItem(false)]
    public class MyDgvMcCBEditingControl : MyMcComboBox, IDataGridViewEditingControl
    {
        private DataGridView dataGridView;
        private bool valueChanged = false;
        private int rowIndex;

        public bool LimitToList { get; set; }

        public MyDgvMcCBEditingControl()
        {
            LimitToList = true;
        }

        public object EditingControlFormattedValue
        {
            get
            {
                if (LimitToList)
                {
                    if (this.SelectedValue == null)
                        return null;
                    return this.SelectedValue.ToString();
                }
                return this.Text;

            }
            set
            {
                if (!(value is string)) return;
                if (LimitToList)
                {
                    try
                    {
                        this.SelectedValue = (string) value;
                    }
                    catch
                    {
                        this.SelectedValue = null;
                    }
                }
                else
                {
                    this.Text = (string) value;
                }
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
            if (DroppedDown) return true;

            switch (keyData & Keys.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                    if (this.DroppedDown)
                        return true;
                    else
                        return !dataGridViewWantsInputKey;

                case Keys.Home:
                case Keys.End:
                case Keys.Back:
                case Keys.F4:
                case Keys.Enter:
                    return true;

                case Keys.Escape:
                    return this.DroppedDown;

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

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
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

    }
}