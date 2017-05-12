using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsLIB.Misc;
using KlonsLIB.Components;
using KlonsLIB.Forms;
using SourceGrid;
using SourceGrid.Cells.Editors;

namespace KlonsLIB.MySourceGrid.GridRows
{
    public class MyListItem
    {
        public Int16 Key { get; set; } = 0;
        public string Val { get; set; } = null;

        public MyListItem(Int16 key, string val)
        {
            Key = key;
            Val = val;
        }

        public override string ToString()
        {
            return Val;
        }
    }
    public class MyGridRowComboBoxA : MyGridRowPropEditorBase
    {
        private SourceGrid.Cells.Editors.ComboBox mComboBoxEditor = null;

        [Category("Data")]
        public string[] ListStrings { get; set; } = null;

        private ValueMappingA ValueMapping = null;

        public SourceGrid.Cells.Editors.ComboBox ComboBoxEditor
        {
            get { return mComboBoxEditor; }
        }

        public MyGridRowComboBoxA()
        {
            RowType = EMyGridRowType.ComboBox;
            RowValueType = EMyGridRowValueType.String;
        }

        public override SourceGrid.Cells.Cell MakeDataCell()
        {
            SourceGrid.Cells.Cell cbcell = null;
            SourceGrid.Cells.Editors.ComboBox sharededitor = null;

            var sharededitor1 = GetSharedEditor();
            if (sharededitor1 != null)
            {
                sharededitor = sharededitor1 as SourceGrid.Cells.Editors.ComboBox;
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

            cbcell = new SourceGrid.Cells.Cell(GetDefaultValue());

            mComboBoxEditor = new SourceGrid.Cells.Editors.ComboBox(GetValueType());
            mComboBoxEditor.Control.FlatStyle = FlatStyle.Flat;
            cbcell.Editor = mComboBoxEditor;
            cbcell.View = Grid.gridViewModel.dataCellModel;

            var list = GetListItems();
            if (list != null)
            {
                mComboBoxEditor.Control.FormattingEnabled = true;
                mComboBoxEditor.StandardValues = list;
                ValueMapping = new ValueMappingA(mComboBoxEditor, list, "Key", "Val", this);
            }

            cbcell.Editor.AllowNull = AllowNull;

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

        public override void UnLinkRow()
        {
            if (ValueMapping != null && MyEditor != null)
                ValueMapping.UnBindValidator(MyEditor);
        }

    }
}
