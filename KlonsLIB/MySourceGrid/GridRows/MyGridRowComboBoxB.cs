using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;
using KlonsLIB.Misc;
using KlonsLIB.MySourceGrid.Cells;
using SourceGrid;

namespace KlonsLIB.MySourceGrid.GridRows
{
    public class MyGridRowComboBoxB : MyGridRowPropEditorBase
    {
        private MyComboBoxCell comboBoxEditor = null;
        private object listSource = null;
        private string listValueMember = null;
        private string listDisplayMember = null;
        private string[] columnNames = null;
        private string columnWidths = "100";
        private int maxDropDownRows = 15;

        [Category("ListData")]
        [DefaultValue(null)]
        public string[] ListStrings { get; set; } = null;

        [DefaultValue(null)]
        [Category("ListData")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(IListSource))]
        public object ListSource
        {
            get
            {
                return this.listSource;
            }
            set
            {
                this.listSource = value;
                if (comboBoxEditor != null)
                    comboBoxEditor.Control.DataSource = value;
            }
        }

        [Category("ListData")]
        [DefaultValue("")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, " + AssemblyRef1.SystemDesign)]
        [Editor("MyUIEditors.MyDataMemberFieldEditor, MyUIEditors", typeof(UITypeEditor))]
        [RelatedDataSource("ListSource")]
        public string ListDisplayMember
        {
            get
            {
                return this.listDisplayMember;
            }
            set
            {
                if (value == null) value = string.Empty;
                this.listDisplayMember = value;
                if (comboBoxEditor != null)
                    comboBoxEditor.Control.DisplayMember = value;
            }
        }

        [Category("ListData")]
        [DefaultValue("")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, " + AssemblyRef1.SystemDesign)]
        [Editor("MyUIEditors.MyDataMemberFieldEditor, MyUIEditors", typeof(UITypeEditor))]
        [RelatedDataSource("ListSource")]
        public string ListValueMember
        {
            get
            {
                return this.listValueMember;
            }
            set
            {
                if (value == null) value = string.Empty;
                this.listValueMember = value;
                if (comboBoxEditor != null)
                    comboBoxEditor.Control.ValueMember = value;
            }
        }

        [Category("ListData")]
        [DefaultValue(null)]
        public string[] ColumnNames
        {
            get
            {
                return this.columnNames;
            }
            set
            {
                this.columnNames = value;
                if (comboBoxEditor != null)
                    comboBoxEditor.Control.ColumnNames = value;
            }
        }

        [Category("ListData")]
        [DefaultValue("100")]
        public string ColumnWidths
        {
            get
            {
                return this.columnWidths;
            }
            set
            {
                this.columnWidths = value;
                if (comboBoxEditor != null)
                    comboBoxEditor.Control.ColumnWidths = value;
            }
        }

        [Category("ListData")]
        [DefaultValue(15)]
        public int MaxDropDownRows
        {
            get
            {
                return this.maxDropDownRows;
            }
            set
            {
                this.maxDropDownRows = value;
                if (comboBoxEditor != null)
                    comboBoxEditor.Control.MaxDropDownItems = value;
            }
        }

        public MyComboBoxCell ComboBoxEditor
        {
            get { return comboBoxEditor; }
        }

        public MyGridRowComboBoxB(string name, string title, string propname,
            string gridpropname, EMyGridRowValueType valtyp,
            ICollection values, bool limittovaluelist,
            string displaymember, string valuemember, 
            string[] columnnames)
            : base(name, title, gridpropname, EMyGridRowType.ComboBox, valtyp)
        {
            comboBoxEditor = new MyComboBoxCell(GetValueType());
            this.listSource = values;
            this.ListValueMember = valuemember;
            this.ListDisplayMember = displaymember;
            this.ColumnNames = columnnames;
        }

        public MyGridRowComboBoxB()
        {
            RowType = EMyGridRowType.ComboBox;
            RowValueType = EMyGridRowValueType.String;
        }

        public override SourceGrid.Cells.Cell MakeDataCell()
        {
            SourceGrid.Cells.Cell cbcell = null;
            MyComboBoxCell sharededitor = null;

            var sharededitor1 = GetSharedEditor();
            if (sharededitor1 != null)
            {
                sharededitor = sharededitor1 as MyComboBoxCell;
                if (sharededitor1 == null)
                {
                    throw new Exception("Wrong shared editor type.");
                }

            }

            if (sharededitor != null)
            {
                cbcell = new SourceGrid.Cells.Cell(GetDefaultValue(), sharededitor);
                cbcell.View = Grid.gridViewModel.dataCellModel;
                return cbcell;
            }


            cbcell = new SourceGrid.Cells.Cell(GetDefaultValue(), GetValueType());
            comboBoxEditor = new MyComboBoxCell(GetValueType());

            var list = GetListItems();
            if (list != null)
            {
                this.ListSource = list;
                this.ListValueMember = "Value";
                this.ListDisplayMember = "Key";
                this.ColumnNames = new[] { "Key", "Value" };
            }

            comboBoxEditor.Control.DataSource = listSource;
            comboBoxEditor.Control.ValueMember = listValueMember;
            comboBoxEditor.Control.DisplayMember = listDisplayMember;
            comboBoxEditor.Control.ColumnNames = columnNames;
            comboBoxEditor.Control.ColumnWidths = columnWidths;
            comboBoxEditor.Control.MaxDropDownItems = maxDropDownRows;
            comboBoxEditor.Control.FlatStyle = FlatStyle.Flat;

            cbcell.Editor = comboBoxEditor;
            cbcell.View = Grid.gridViewModel.dataCellModel;

            if (ReadOnly)
                comboBoxEditor.EditableMode = EditableMode.None;

            comboBoxEditor.AllowNull = AllowNull;
            comboBoxEditor.Row = this;

            return cbcell;
        }

        private List<MyListItem> GetListItems()
        {
            if (ListStrings == null || ListStrings.Length == 0) return null;
            var list = new List<MyListItem>();
            foreach (string s in ListStrings)
            {
                var ss = s.Split(";".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                Int16 k;
                if (ss == null || ss.Length != 2 || 
                    string.IsNullOrEmpty(ss[0]) || 
                    string.IsNullOrEmpty(ss[1]) ||
                    !Int16.TryParse(ss[0], out k))
                {
                    throw new Exception("Bad ListStrings.");
                }
                list.Add(new MyListItem(k, ss[1]));
            }
            if (list.Count == 0)
                list = null;
            return list;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool NoData
        {
            get
            {
                if (comboBoxEditor == null) return true;
                if (comboBoxEditor.Control.Items != null &&
                    comboBoxEditor.Control.Items.Count > 0) return false;

                if (comboBoxEditor.Control.DataSource == null) return false;

                var cm = comboBoxEditor.Control.DataSource as ICurrencyManagerProvider;
                if (cm != null)
                {
                    if (cm.CurrencyManager == null) return true;
                    if (cm.CurrencyManager.Count == 0) return true;
                    if (cm.CurrencyManager.Current == null) return true;
                    //if (cm.CurrencyManager.Current is DataRowView &&
                    //    (cm.CurrencyManager.Current as DataRowView).Row.RowState == DataRowState.Detached) return true;
                    return false;
                }
                var il = comboBoxEditor.Control.DataSource as IList;
                if (il != null && il.Count == 0) return true;
                return false;
            }
        }
    }
}
