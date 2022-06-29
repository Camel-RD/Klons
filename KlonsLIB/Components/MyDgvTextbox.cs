using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KlonsLIB.Misc;

namespace KlonsLIB.Components
{
    public interface IMyDgvTextboxEditingControlEvents
    {
        void OnButtonClicked(MyDgvTextboxEditingControl control);
    }

    [ToolboxItem(false)]
    public class MyDgvTextboxEditingControl : MyPickRowTextBox2, IDataGridViewEditingControl
    {
        private DataGridView dataGridView;
        private bool valueChanged = false;
        private int rowIndex;

        public bool LimitToList { get; set; }

        public MyDgvTextboxEditingControl()
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
                    return null;
                return this.SelectedValue.ToString();
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
            var ievents = dataGridView?.FindForm() as IMyDgvTextboxEditingControlEvents;
            if (ievents == null) return;
            ievents.OnButtonClicked(this);
        }
    }


    public class MyDgvTextboxCell : DataGridViewTextBoxCell
    {
        private MyDgvTextboxEditingControl m_EditingControl = null;
        public MyDgvTextboxColumn TemplateDGVColumn = null;
        private object m_DataSource;
        private string m_DisplayMember;
        private string m_ValueMember;
        private bool m_limitToList = true;

        private static Type defaultFormattedValueType = typeof(System.String);
        private static Type defaultValueType = typeof(System.Object);


        public MyDgvTextboxCell() : base()
        {
        }

        public override object Clone()
        {
            MyDgvTextboxCell cell = (MyDgvTextboxCell)base.Clone();
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

            m_EditingControl = base.DataGridView.EditingControl as MyDgvTextboxEditingControl;
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
            get { return typeof(MyDgvTextboxEditingControl); }
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
                m_DataSource = value;
                if (this.OwnsEditingControl(base.RowIndex))
                    if (m_EditingControl != null)
                    {
                        m_EditingControl.DataSource = value;
                    }
            }
        }

        public string DisplayMember
        {
            get { return m_DisplayMember; }
            set
            {
                m_DisplayMember = value;
                if (this.OwnsEditingControl(base.RowIndex))
                    if (m_EditingControl != null)
                    {
                        m_EditingControl.DisplayMember = value;
                    }
            }
        }

        public string ValueMember
        {
            get { return m_ValueMember; }
            set
            {
                m_ValueMember = value;
                if (this.OwnsEditingControl(base.RowIndex))
                    if (m_EditingControl != null)
                    {
                        m_EditingControl.ValueMember = value;
                    }
            }
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


    public class MyDgvTextboxColumn : DataGridViewColumn
    {
        public MyDgvTextboxColumn() : base(new MyDgvTextboxCell())
        {
            TextBoxCellTemplateA.TemplateDGVColumn = this;
        }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(MyDgvTextboxCell)))
                {
                    throw new InvalidCastException("Must be a MyDgvTextboxCell");
                }
                base.CellTemplate = value;
            }
        }

        private MyDgvTextboxCell TextBoxCellTemplateA
        {
            get { return (MyDgvTextboxCell)this.CellTemplate; }
        }

        private void CheckCellTemplate()
        {
            if (this.TextBoxCellTemplateA == null)
            {
                throw new InvalidOperationException("DataGridViewColumn_CellTemplateRequired");
            }
        }

        private void ApplyToCells(Action<MyDgvTextboxCell> act)
        {
            if (this.DataGridView == null) return;
            DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
            int rowCount = dataGridViewRows.Count;
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                MyDgvTextboxCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as MyDgvTextboxCell;
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
                    MyDgvTextboxCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvTextboxCell;
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
