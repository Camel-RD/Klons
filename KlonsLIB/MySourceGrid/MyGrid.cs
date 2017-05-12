using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using DevAge.Drawing;
using DevAge.ComponentModel;
using KlonsLIB.Forms;
using KlonsLIB.Components;
using KlonsLIB.Misc;
using KlonsLIB.MySourceGrid.GridRows;

namespace KlonsLIB.MySourceGrid
{
    using SourceGrid;


    [Designer("MyUIEditors.MyGridDesigner, MyUIEditors")]
    public class MyGrid : Grid, ICollectionEditorTypeListProvider
    {
        private MyGridRowList gridRowList = null;
        private MyGridRowList gridRowTemplateList = null;
        public MyGridViewModel gridViewModel = null;
        private object myData = null;

        [Category("My")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("MyUIEditors.MyCollectionEditor, MyUIEditors", typeof(UITypeEditor))]
        public MyGridRowList RowList
        {
            get { return gridRowList; }
        }

        [Category("My")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("MyUIEditors.MyCollectionEditor, MyUIEditors", typeof(UITypeEditor))]
        public MyGridRowList RowTemplateList
        {
            get { return gridRowTemplateList; }
        }

        private Dictionary<string, CellContext> linkedCells = new Dictionary<string, CellContext>();
        private MultiValueDictionary<string, MyGridRowBase> linkedRows = new MultiValueDictionary<string, MyGridRowBase>();

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, CellContext> LinkedCells {get { return linkedCells; } }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MultiValueDictionary<string, MyGridRowBase> LinkedRows { get { return linkedRows; } }

        [Category("My")]
        [DefaultValue(null)]
        [TypeConverter(typeof (ReferenceConverter))]
        public IBindableComponent MyDataBC
        {
            get { return MyData as IBindableComponent; }
            set { MyData = value;}
        }

        [Category("My")]
        public int ColumnWidth1 { get; set; } = 20;
        [Category("My")]
        public int ColumnWidth2 { get; set; } = 200;
        [Category("My")]
        public int ColumnWidth3 { get; set; } = 100;

        [DefaultValue(true)]
        [Category("My")]
        public bool AllowEdit { get; set; } = true;

        [Category("Appearance")]
        public virtual Color BackColor2 { get; set; } = SystemColors.Window;


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object MyData
        {
            get { return myData; }
            set
            {
                if (myData == value) return;
                INotifyPropertyChanged mi;
                if (myData != null)
                {
                    mi = myData as INotifyPropertyChanged;
                    if (mi != null)
                    {
                        mi.PropertyChanged -= OnMyGridPropertyChanged;
                    }
                }
                if (value != null)
                {
                    if((value as IBindableComponent) == null || (value as INotifyPropertyChanged) == null)
                        throw new ArgumentException("Bad MyData object.");
                }
                myData = value;
                mi = myData as INotifyPropertyChanged;
                if (mi != null)
                {
                    mi.PropertyChanged += OnMyGridPropertyChanged;
                }
            }
        }

        public MyGrid()
        {
            gridViewModel = new MyGridViewModel(this);
            gridRowList = new MyGridRowList(this);
            gridRowTemplateList = new MyGridRowList(this);
            SetMyToolTip();
        }

        private bool disposedValue = false; // To detect redundant calls

        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    UnLinkGrid();
                    Rows.Clear();
                    foreach (var r in RowList)
                    {
                        r.Dispose();
                    }
                    RowList.Clear();
                    MyDataBC = null;
                }

                disposedValue = true;
            }
            base.Dispose(disposing);
        }

        public new void Dispose()
        {
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }


        protected void SetMyToolTip()
        {
            var fi = Utils.GetField(this.GetType(), "toolTip");
            var dToolTip = new MyToolTip();
            dToolTip.ShowAlways = true;
            dToolTip.InitialDelay = 0;
            dToolTip.UseFading = false;
            dToolTip.UseAnimation = false;
            dToolTip.AutoPopDelay = 0;
            fi.SetValue(this, dToolTip);
        }

        public Type[] GetTypesForCollectionEditor(string propname)
        {
            if (propname == "RowList")
            {
                return new Type[]
                {
                    typeof (MyGridRowTitle),
                    typeof (MyGridRowTextBoxA),
                    typeof (MyGridRowCheckBox),
                    typeof (MyGridRowComboBoxA),
                    typeof (MyGridRowComboBoxB),
                    typeof (MyGridRowComboBoxB2),
                    typeof (MyGridRowMultiLineTextBox),
                    typeof (MyGridRowMyEditor),
                    typeof (MyGridRowWithControl)
                };
            }
            else if (propname == "RowTemplateList")
            {
                return new Type[]
                {
                    typeof (MyGridRowTextBoxA),
                    typeof (MyGridRowComboBoxA),
                    typeof (MyGridRowComboBoxB)
                };
            }
            return null;
        }

        public void OnMyGridPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            OnPropertyChanged(args.PropertyName);
        }

        public void OnPropertyChanged(string propname = null)
        {
            if (propname == null) return;

            IReadOnlyCollection<MyGridRowBase> gridrows;
            if (LinkedRows.TryGetValue(propname, out gridrows))
            {
                object val = Utils.GetProperty(MyData, propname);
                foreach(var gr in gridrows)
                    gr.Value = val;
                return;
            }

            CellContext cc;
            if (LinkedCells.TryGetValue(propname, out cc))
            {
                object val = Utils.GetProperty(MyData, propname);
                cc.Cell.Model.ValueModel.SetValue(cc, val);
            }
        }

        public void UpdateDataCells()
        {
            foreach (var row in gridRowList)
            {
                if (row is MyGridRowPropEditorBase)
                    (row as MyGridRowPropEditorBase).UpdateDataCell();
            }
        }

        public void AddRows(int count)
        {
            Redim(Rows.Count + count, 3);
        }

        private bool makeGridCompleted = false;
        public void MakeGrid()
        {
            LinkedCells.Clear();
            LinkedRows.Clear();

            this.ColumnsCount = 3;
            this.Columns[0].Width = ColumnWidth1;
            this.Columns[1].Width = ColumnWidth2;
            this.Columns[2].Width = ColumnWidth3;

            for (int i = 0; i < gridRowTemplateList.Count; i++)
            {
                var rowdef = gridRowTemplateList[i];
                rowdef.MakeTemplateRow(this);
            }

            int rowscount = 0;

            for (int i = 0; i < gridRowList.Count; i++)
                rowscount += gridRowList[i].GetRowCount();

            this.RowsCount = rowscount;

            int rownr = 0;
            for (int i = 0; i < gridRowList.Count; i++)
            {
                var rowdef = gridRowList[i];
                rowdef.MakeRow(Rows[rownr]);
                rownr += rowdef.GetRowCount();
            }
            ScaleControlA(scaleFactor);
            
            this.Controller.AddController(MarkCurrentRowController.Default);

            makeGridCompleted = true;
        }

        public void LinkGrid()
        {
            if(!makeGridCompleted)
                throw new Exception("MakeGrid not completed");

            LinkedCells.Clear();
            LinkedRows.Clear();

            if (MyDataBC == null)
                throw new Exception("Bad MyData");

            for (int i = 0; i < gridRowList.Count; i++)
            {
                var rowdef = gridRowList[i];
                try
                {
                    rowdef.LinkRow();
                    rowdef.UpdateDataCell();
                }
                catch (Exception ex)
                {
                    throw new Exception("LinkRow failed: " + rowdef.Name, ex);
                }
            }

        }

        public void UnLinkGrid()
        {
            if (MyDataBC == null) return;
            var mi = myData as INotifyPropertyChanged;
            if (mi != null)
                mi.PropertyChanged -= OnMyGridPropertyChanged;
            var mbc = MyData as IBindableComponent;
            if (mbc != null)
                mbc.DataBindings.Clear();
            for (int i = 0; i < gridRowList.Count; i++)
            {
                var rowdef = gridRowList[i];
                try
                {
                    rowdef.UnLinkRow();
                }
                catch (Exception ex)
                {
                    throw new Exception("UnLinkRow failed: " + rowdef.Name, ex);
                }
            }
            linkedRows.Clear();
            LinkedCells.Clear();
        }

        public MyGridRowBase FindGridRow(int realrownr)
        {
            for (int i = 0; i < this.RowList.Count; i++)
            {
                var k = RowList[i].GridRow.Index;
                if (k == realrownr)
                    return RowList[i];
                if (k > realrownr)
                {
                    if (i == 0) return null;
                    return RowList[i-1];
                }
            }
            return null;
        }

        private int currentRowNr = -1;

        public void MarkRow(int nr)
        {
            MarkRowA(currentRowNr, "");
            MarkRowA(nr, "▶");
            currentRowNr = nr;
        }

        public void MarkRowA(int nr, string mark)
        {
            if (nr < 0 || nr > this.Rows.Count) return;
            var gridrow = FindGridRow(nr);
            if (gridrow == null || !gridrow.CanBeMarked) return;

            var cell = this[nr, 0];
            if (cell == null) return;
            var controller = cell.FindController<RowMarkCellController>();
            if (controller == null) return;
            cell.Value = mark;
        }

        public bool MarkRowRed(int nr, bool red)
        {
            if (nr < 0 || nr > this.Rows.Count) return false;
            SourceGrid.Cells.Views.Cell vw;

            var cell = this[nr, 0];
            if (cell == null) return false;
            var controller = cell.FindController<RowMarkCellController>();
            if (controller == null) return false;

            if (red) vw = this.gridViewModel.rowHeaderModelRed;
            else vw = this.gridViewModel.rowHeaderModel;

            bool ret = cell.View != vw;
            if (!ret) return false;
            cell.View = vw;
            InvalidateCell(cell);
            return ret;
        }

        public bool IsRowMarkedRed(int nr)
        {
            if (nr < 0 || nr > this.Rows.Count) return false;

            var cell = this[nr, 0];
            if (cell == null) return false;
            var controller = cell.FindController<RowMarkCellController>();
            if (controller == null) return false;

            return cell.View == this.gridViewModel.rowHeaderModelRed;
        }

        public void ClearRed()
        {
            if (!makeGridCompleted) return;
            foreach (var r1 in RowList)
            {
                var r2 = r1 as MyGridRowPropEditorBase;
                if (r2 == null) continue;
                int rownr = r2.GridRow.Index;
                MarkRowRed(rownr, false);
            }
        }

        public bool CheckRedRows(object comparewith)
        {
            if (!makeGridCompleted) return false;

            bool red = false, haschanges = false;
            foreach (var r1 in RowList)
            {
                var r2 = r1 as MyGridRowPropEditorBase;
                if (r2 == null) continue;
                int rownr = r2.GridRow.Index;
                red = r2.IsRed(comparewith);
                if (MarkRowRed(rownr, red))
                    haschanges = true;
            }
            return haschanges;
        }

        public bool CheckRedRows(object[] dataprev, object[] datacur, object[] datasource
            , Func<MyGridRowPropEditorBase, bool> fisred = null)
        {
            if (!makeGridCompleted) return false;

            bool red = false, haschanges = false;
            foreach (var r1 in RowList)
            {
                var r2 = r1 as MyGridRowPropEditorBase;
                if (r2 == null || !r2.CheckRed) continue;
                int rownr = r2.GridRow.Index;
                if (fisred == null)
                    red = r2.IsRed(dataprev, datacur, datasource);
                else
                    red = fisred(r2);
                if (MarkRowRed(rownr, red))
                    haschanges = true;
            }
            return haschanges;
        }

        private SizeF scaleFactor = new SizeF(1.0f, 1.0f);
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            ScaleControlA(factor);
            scaleFactor.Width *= factor.Width;
            scaleFactor.Height *= factor.Height;
            this.DefaultHeight = (int)Math.Round((float)this.DefaultHeight * (float)factor.Height);
        }

        protected void ScaleControlA(SizeF factor)
        {
            float width = factor.Width;
            float height = factor.Height;
            if (width != 1.0f)
            {
                foreach (var c in Columns)
                {
                    var ci = c as ColumnInfo;
                    ci.Width = (int)Math.Round((double)ci.Width * (double)width);
                }
            }
            if (height != 1.0f)
            {
                /*
                foreach (var r in Rows)
                {
                    var ri = r as RowInfo;
                    ri.Height = (int)Math.Round((double)ri.Height * (double)height);
                }*/
            }

            Dictionary<Control, bool> cd = new Dictionary<Control, bool>();

            for (int i = 0; i < Rows.Count; i++)
            {
                for (int j = 0; j < Columns.Count; j++)
                {
                    var c1 = GetCell(i, j);
                    if (c1 == null) continue;
                    var ed = c1.Editor;
                    if (ed == null) continue;
                    if (ed is SourceGrid.Cells.Editors.EditorControlBase)
                    {
                        var edc = (ed as SourceGrid.Cells.Editors.EditorControlBase).Control;
                        if (edc == null) continue;
                        if (cd.ContainsKey(edc)) continue;
                        cd[edc] = true;
                        edc.Scale(factor);
                    }
                }

            }
            foreach (var lc in LinkedControls)
            {
                if (FindForm().Contains(lc.Control)) continue;
                lc.Control.Scale(factor);
            }
            ArrangeLinkedControls();
        }

        public virtual bool EndEdit(bool cancel = false)
        {
            if (this.Selection.ActivePosition.IsEmpty()) return true;
            CellContext focusCell = new CellContext(this, this.Selection.ActivePosition);
            if (focusCell.Cell == null || !focusCell.IsEditing()) return true;
            return focusCell.EndEdit(cancel);
        }

        protected override SourceGrid.Selection.SelectionBase CreateSelectionObject()
        {
            var sel = base.CreateSelectionObject();
            sel.Border = new RectangleBorder(new BorderLine(Color.OrangeRed));
            return sel;
        }

        public void ApplyColorTheme(MyColorTheme mycolortheme)
        {
            this.ForeColor = mycolortheme.GetColor(this.ForeColor, mycolortheme.ForeColor);
            this.BackColor = mycolortheme.GetColor(this.BackColor, mycolortheme.ControlColor);
            Color wc = mycolortheme.WindowColor;
            Color gc = mycolortheme.ControlColorDark;

            gridViewModel.SetColors(this.ForeColor, this.BackColor, wc, gc);
            foreach (var lc in LinkedControls)
            {
                if (FindForm().Contains(lc.Control)) continue;
                ColorThemeHelper.ApplyToControl(lc, mycolortheme);
            }
            Refresh();
        }

        public event MyGridDataErrorEventHandler DataError;

        [Category("DataCell")]
        public event CancelEventHandler EditStarting;

        [Category("DataCell")]
        public event EventHandler EditStarted;

        [Category("DataCell")]
        public event EventHandler EditEnded;

        [Category("DataCell")]
        public event EventHandler ValueChanged;

        [Category("DataCell")]
        public event ConvertingObjectEventHandler ConvertingValueToDisplayString;

        [Category("DataCell")]
        public event ConvertingObjectEventHandler ConvertingObjectToValue;

        [Category("DataCell")]
        public event ConvertingObjectEventHandler ConvertingValueToObject;

        public virtual void OnValueChanged(MyGridRowPropEditorBase sender, EventArgs e)
        {
            if (ValueChanged == null) return;
            ValueChanged(sender, e);
        }
        public virtual void OnEditStarting(MyGridRowPropEditorBase sender, CancelEventArgs e)
        {
            if (EditStarting == null) return;
            EditStarting(sender, e);
        }
        public virtual void OnEditStarted(MyGridRowPropEditorBase sender, EventArgs e)
        {
            if (EditStarted == null) return;
            EditStarted(sender, e);
        }
        public virtual void OnEditEnded(MyGridRowPropEditorBase sender, EventArgs e)
        {
            if (EditEnded == null) return;
            EditEnded(sender, e);
        }

        public virtual void OnConvertingValueToDisplayString(MyGridRowPropEditorBase sender, ConvertingObjectEventArgs e)
        {
            if (ConvertingValueToDisplayString == null) return;
            ConvertingValueToDisplayString(sender, e);
        }

        public virtual void OnConvertingObjectToValue(MyGridRowPropEditorBase sender, ConvertingObjectEventArgs e)
        {
            if (ConvertingObjectToValue == null) return;
            ConvertingObjectToValue(sender, e);
        }

        public virtual void OnConvertingValueToObject(MyGridRowPropEditorBase sender, ConvertingObjectEventArgs e)
        {
            if (ConvertingValueToObject == null) return;
            ConvertingValueToObject(sender, e);
            
        }

        public virtual void OnDataError(Exception e)
        {
            this.Selection.ResetSelection(true);

            Form_Error.ShowException(e);

            if (DataError != null)
                DataError(this, new MyGridDataErrorEventArgs(e));
        }

    }

    public class MyGridDataErrorEventArgs : EventArgs
    {
        public Exception Exception { get; private set; } = null;

        public MyGridDataErrorEventArgs(Exception e)
        {
            Exception = e;
        }
    }

    public delegate void MyGridDataErrorEventHandler(object sender, MyGridDataErrorEventArgs e);

}
