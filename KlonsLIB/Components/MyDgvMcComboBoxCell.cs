using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace KlonsLIB.Components
{
    public class MyDgvMcComboBoxCell : DataGridViewComboBoxCell
    {

        public MyDgvMcComboBoxColumn TemplateDGVComboColumn = null;
        private MyDgvMcComboBox m_EditingComboBox = null;
        private string[] m_ColumnNames;
        private string m_ColumnWidths = "100";
        private string[] m_ItemStrings = null;
        private MyDgvMcComboBox.CustomDropDownStyle m_DropDownStyle;
        private bool m_limitToList = true;
        private bool m_NullToDBNull = false;

        public override Type EditType
        {
            get
            {
                return typeof(MyDgvMcComboBox);
            }
        }
        public override Type ValueType
        {
            get
            {
                if (ItemStrings != null)
                {
                    return typeof(MyMcComboBox.MyItem);
                }
                return base.ValueType;
            }
        }

        public override object Clone()
        {
            MyDgvMcComboBoxCell cell = base.Clone() as MyDgvMcComboBoxCell;
            cell.ColumnNames = ColumnNames;
            cell.ColumnWidths = ColumnWidths;
            cell.DropDownStyle = this.DropDownStyle;
            cell.ItemStrings = this.ItemStrings;
            cell.LimitToList = this.LimitToList;
            cell.NullToDBNull = this.NullToDBNull;
            return cell;
        }


        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue,
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            m_EditingComboBox = base.DataGridView.EditingControl as MyDgvMcComboBox;
            if (m_EditingComboBox == null) return;

            (m_EditingComboBox as ComboBox).DropDownStyle = ComboBoxStyle.DropDown;
            m_EditingComboBox.AutoCompleteMode = AutoCompleteMode.None;
            m_EditingComboBox.FormattingEnabled = true;
            m_EditingComboBox.FlatStyle = FlatStyle.Flat;
            m_EditingComboBox.DropDownStyle = DropDownStyle;
            m_EditingComboBox.ColumnNames = ColumnNames;
            m_EditingComboBox.ColumnWidths = ColumnWidths;
            m_EditingComboBox.ItemStrings = null;
            m_EditingComboBox.LimitToList = LimitToList;

            if (this.DataGridView is MyDataGridView)
                m_EditingComboBox.ScaleControlA((this.DataGridView as MyDataGridView).ScaleFactor);

            if (m_EditingComboBox.DropDownWidth != this.DropDownWidth)
                this.DropDownWidth = m_EditingComboBox.DropDownWidth;

            m_EditingComboBox.SelectedValue = this.Value;
        }

        private bool OwnsEditingComboBox(int rowIndex)
        {
            return (((rowIndex != -1) && (m_EditingComboBox != null)) && (rowIndex == m_EditingComboBox.EditingControlRowIndex));
        }

        public void ScaleColumn(SizeF factor)
        {
            if (this.OwnsEditingComboBox(base.RowIndex))
                if (m_EditingComboBox != null)
                {
                    m_EditingComboBox.ScaleControlA(factor);
                }
        }

        public string[] ColumnNames{
            get
            {
                return m_ColumnNames;
            }
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
            get
            {
                return m_ColumnWidths;
            }
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

        public MyDgvMcComboBox.CustomDropDownStyle DropDownStyle
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

        public bool NullToDBNull
        {
            get { return m_NullToDBNull; }
            set { m_NullToDBNull = value; }
        }

        public override object ParseFormattedValue(object formattedValue,
                                                   DataGridViewCellStyle cellStyle,
                                                   TypeConverter formattedValueTypeConverter,
                                                   TypeConverter valueTypeConverter)
        {
            var v = base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
            if (v == null && m_NullToDBNull) return DBNull.Value;
            return v;
        }


    }
}
