using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace KlonsLIB.Components
{
    public class MyDgvMcComboBoxColumn : DataGridViewComboBoxColumn
    {
        public MyDgvMcComboBoxColumn()
        {
            this.CellTemplate = new MyDgvMcComboBoxCell();
            ComboBoxCellTemplateA.TemplateDGVComboColumn = this;
        }

        private MyDgvMcComboBoxCell ComboBoxCellTemplateA
        {
            get
            {
                return (MyDgvMcComboBoxCell)this.CellTemplate;
            }
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


        public void ScaleColumn(SizeF factor)
        {
            this.ComboBoxCellTemplateA.ScaleColumn(factor);
            if (base.DataGridView != null)
            {
                DataGridViewRowCollection rows = base.DataGridView.Rows;
                int count = rows.Count;
                for (int i = 0; i < count; i++)
                {
                    MyDgvMcComboBoxCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcComboBoxCell;
                    if (cell != null)
                    {
                        cell.ScaleColumn(factor);
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
                    throw new InvalidOperationException("MyDgvMcComboBoxColumn_CellTemplateRequired");
                }
                return this.ComboBoxCellTemplateA.ColumnNames;
            }
            set
            {
                if (!StringArraysMatch(this.ColumnNames, value))
                {
                    this.ComboBoxCellTemplateA.ColumnNames = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection rows = base.DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            MyDgvMcComboBoxCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcComboBoxCell;
                            if (cell != null)
                            {
                                cell.ColumnNames = value;
                            }
                        }
                    }
                }
            }
        }

        [DefaultValue("100"),
        Category("Behavior")]
        public string ColumnWidths
        {
            get
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("MyDgvMcComboBoxColumn_CellTemplateRequired");
                }
                return this.ComboBoxCellTemplateA.ColumnWidths;
            }
            set
            {
                if (ColumnWidths != value)
                {
                    this.ComboBoxCellTemplateA.ColumnWidths = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection rows = base.DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            MyDgvMcComboBoxCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcComboBoxCell;
                            if (cell != null)
                            {
                                cell.ColumnWidths = value;
                            }
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
                    throw new InvalidOperationException("MyDgvMcComboBoxColumn.CellTemplateRequired");
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
                        MyDgvMcComboBoxCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcComboBoxCell;
                        if (cell != null)
                        {
                            cell.ItemStrings = value;
                        }
                    }
                }

            }
        }

        [DefaultValue(MyDgvMcComboBox.CustomDropDownStyle.DropDown),
        Category("Behavior")]
        public MyDgvMcComboBox.CustomDropDownStyle DropDownStyle
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
                            MyDgvMcComboBoxCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcComboBoxCell;
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
                            MyDgvMcComboBoxCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcComboBoxCell;
                            if (cell != null)
                            {
                                cell.LimitToList = value;
                            }
                        }
                    }
                }
            }
        }

        [DefaultValue(false),
         Category("Behavior")]
        public bool NullToDBNull
        {
            get
            {
                if (this.ComboBoxCellTemplateA == null)
                {
                    throw new InvalidOperationException("MyDgvMcCBColumn_CellTemplateRequired");
                }
                return this.ComboBoxCellTemplateA.NullToDBNull;
            }
            set
            {
                if (NullToDBNull != value)
                {
                    this.ComboBoxCellTemplateA.NullToDBNull = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection rows = base.DataGridView.Rows;
                        int count = rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            MyDgvMcComboBoxCell cell = rows.SharedRow(i).Cells[base.Index] as MyDgvMcComboBoxCell;
                            if (cell != null)
                            {
                                cell.NullToDBNull = value;
                            }
                        }
                    }
                }
            }
        }



    }
}
