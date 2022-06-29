using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Design;
using System.Windows.Forms;
using KlonsLIB.Misc;
using KlonsLIB.MySourceGrid.Cells;
using SourceGrid;
using System.ComponentModel;
using System.Collections;

namespace KlonsLIB.MySourceGrid.GridRows
{
    public class MyGridRowPickRowTextBox : MyGridRowPropEditorBase, ICustomConversionSupport
    {
        private MyPickRowTextBoxCell pickRowTextBoxEditor = null;
        private object listSource = null;
        private string listValueMember = null;
        private string listDisplayMember = null;
        private bool readOnlyEx = false;

        public event EventHandler ButtonClicked;

        [Category("Data")]
        [DefaultValue(false)]
        public bool CustomConversions { get; set; } = false;

        private ValueMappingB ValueMapping = null;

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
                if (pickRowTextBoxEditor != null)
                    pickRowTextBoxEditor.Control.DataSource = value;
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
                if (pickRowTextBoxEditor != null)
                    pickRowTextBoxEditor.Control.DisplayMember = value;
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
                if (pickRowTextBoxEditor != null)
                    pickRowTextBoxEditor.Control.ValueMember = value;
            }
        }

        [Category("ListData")]
        [DefaultValue(false)]
        public bool ReadOnlyEx
        {
            get
            {
                return this.readOnlyEx;
            }
            set
            {
                this.readOnlyEx = value;
                if (pickRowTextBoxEditor != null)
                    pickRowTextBoxEditor.Control.ReadOnly = value;
            }
        }

        public MyPickRowTextBoxCell MyPickRowTextBoxEditor
        {
            get { return pickRowTextBoxEditor; }
        }

        public MyGridRowPickRowTextBox(string name, string title, string propname,
            string gridpropname, EMyGridRowValueType valtyp,
            //ICollection values, 
            bool limittovaluelist,
            string displaymember, string valuemember,
            string[] columnnames)
            : base(name, title, gridpropname, EMyGridRowType.ComboBox, valtyp)
        {
            pickRowTextBoxEditor = new MyPickRowTextBoxCell(GetValueType());
            //this.listSource = values;
            this.ListValueMember = valuemember;
            this.ListDisplayMember = displaymember;
        }

        public MyGridRowPickRowTextBox()
        {
            RowType = EMyGridRowType.ComboBox;
            RowValueType = EMyGridRowValueType.String;
        }

        public override SourceGrid.Cells.Cell MakeDataCell()
        {
            SourceGrid.Cells.Cell prtbcell = null;
            MyPickRowTextBoxCell sharededitor = null;

            var sharededitor1 = GetSharedEditor();
            if (sharededitor1 != null)
            {
                sharededitor = sharededitor1 as MyPickRowTextBoxCell;
                if (sharededitor1 == null)
                {
                    throw new Exception("Wrong shared editor type.");
                }

            }

            if (sharededitor != null)
            {
                prtbcell = new SourceGrid.Cells.Cell(GetDefaultValue(), sharededitor);
                prtbcell.View = Grid.gridViewModel.dataCellModel;
                return prtbcell;
            }


            prtbcell = new SourceGrid.Cells.Cell(GetDefaultValue(), GetValueType());
            pickRowTextBoxEditor = new MyPickRowTextBoxCell(GetValueType());
            
            pickRowTextBoxEditor.Control.DataSource = listSource;
            pickRowTextBoxEditor.Control.ValueMember = listValueMember;
            pickRowTextBoxEditor.Control.DisplayMember = listDisplayMember;
            pickRowTextBoxEditor.Control.ReadOnly = readOnlyEx;
            //pickRowTextBoxEditor.Control.BorderStyle = BorderStyle.None;
            //pickRowTextBoxEditor.Control.FlatStyle = FlatStyle.Flat;

            prtbcell.Editor = pickRowTextBoxEditor;
            prtbcell.View = Grid.gridViewModel.dataCellModel;

            if (ReadOnly)
                pickRowTextBoxEditor.EditableMode = EditableMode.None;

            ValueMapping = new ValueMappingB(prtbcell.Editor, this);

            //if (RowValueType == EMyGridRowValueType.String)
            {
                prtbcell.AddController(KlonsLIB.MySourceGrid.MyToolTipText.Default);
                prtbcell.Model.AddModel(new KlonsLIB.MySourceGrid.MyToolTipModel());
            }

            pickRowTextBoxEditor.AllowNull = AllowNull;
            pickRowTextBoxEditor.Row = this;

            pickRowTextBoxEditor.Control.ButtonClicked += Control_ButtonClicked;

            return prtbcell;
        }

        public override void SetBindingContext(BindingContext bc)
        {
            var control = MyPickRowTextBoxEditor?.Control;
            if (control == null) return;
            if (control.BindingContext == bc) return;
            control.BindingContext = bc;
        }


        public void Control_ButtonClicked(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, e);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool NoData
        {
            get
            {
                if (pickRowTextBoxEditor == null) return true;

                if (pickRowTextBoxEditor.Control.DataSource == null) return false;

                var cm = pickRowTextBoxEditor.Control.DataSource as ICurrencyManagerProvider;
                if (cm != null)
                {
                    if (cm.CurrencyManager == null) return true;
                    if (cm.CurrencyManager.Count == 0) return true;
                    if (cm.CurrencyManager.Current == null) return true;
                    //if (cm.CurrencyManager.Current is DataRowView &&
                    //    (cm.CurrencyManager.Current as DataRowView).Row.RowState == DataRowState.Detached) return true;
                    return false;
                }
                var il = pickRowTextBoxEditor.Control.DataSource as IList;
                if (il != null && il.Count == 0) return true;
                return false;
            }
        }

        public override void UnLinkRow()
        {
            if (ValueMapping != null && MyEditor != null)
                ValueMapping.UnBindValidator(MyEditor);
        }

    }
}
