using System;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using System.Reflection;

namespace KlonsLIB.Components
{
    public class MyDataGridView : DataGridView
    {
        private ContextMenuStrip myContextMenuStrip = null;
        private bool _useMyContextmenu = true;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool GoingToDialog { get; set; }

        [DefaultValue(true),
        Category("Behavior")]
        public bool TakeCtrlTabKey { get; set; }

        [DefaultValue(true)]
        [Category("Data")]
        public bool AutoSave { get; set; }

        [Category("My")]
        public event KeyEventHandler MyKeyDown;

        [Category("My")]
        public event EventHandler MyCheckForChanges;

        [Category("My")]
        [DefaultValue(true)]
        public bool UseMyContextmenu
        {
            get
            {
                return _useMyContextmenu;
            }
            set
            {
                if (value == _useMyContextmenu) return;
                _useMyContextmenu = value;
                if (value)
                {
                    this.ContextMenuStrip = myContextMenuStrip;
                }
                else
                {
                    this.ContextMenuStrip = null;
                }
            }
        }

        [Browsable(true)]
        [DefaultValue(DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText)]
        [Category("Behavior")]
        public new DataGridViewClipboardCopyMode ClipboardCopyMode
        {
            get { return base.ClipboardCopyMode; }
            set { base.ClipboardCopyMode = value; }
        }

        public MyDataGridView() : base()
        {
            GoingToDialog = false;
            TakeCtrlTabKey = true;
            DoubleBuffered = true;
            AutoSave = true;
            DataError += MyDataGridView_DataError;
            BackgroundColor = SystemColors.Control;
            ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            myContextMenuStrip = new ContextMenuStrip();
            myContextMenuStrip.Items.Add("Kopēt (Ctrl + C)", null, OnCopy);
            myContextMenuStrip.Items.Add("Kopēt bez virsrakstiem", null, OnCopyWithoutHeaders);
            ContextMenuStrip = myContextMenuStrip;

            SetMyToolTip();

            ShowCellToolTips = false;
        }

        protected void SetMyToolTip()
        {
            var fi = Utils.GetField(this.GetType(), "toolTipControl");
            var dtt = fi.GetValue(this);
            var fi2 = Utils.GetField(dtt.GetType(), "toolTip");
            var dToolTip = new MyToolTip();
            dToolTip.ShowAlways = true;
            dToolTip.InitialDelay = 0;
            dToolTip.UseFading = false;
            dToolTip.UseAnimation = false;
            dToolTip.AutoPopDelay = 0;
            fi2.SetValue(dtt, dToolTip);
        }

        private void OnCopy(object sender, EventArgs e)
        {
            Copy(true);
        }

        private void OnCopyWithoutHeaders(object sender, EventArgs e)
        {
            Copy(false);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            clickTimer.Interval = SystemInformation.DoubleClickTime + 10;
            clickTimer.Tick += new EventHandler(OnClickTimerTick);
            //clickTimer.SynchronizingObject = this.FindForm();
            if (!DesignMode)
            {
                CheckSizes(10.0f);
            }
            Form f = this.FindForm();
            if(f != null)
                f.FormClosing += My_FormClosing;
        }

        protected override void DestroyHandle()
        {
            this.GetClipboardContent();
            clickTimer.Stop();
            clickTimer.Tick -= new EventHandler(OnClickTimerTick);
            clickTimer.Dispose();
            this.FindForm().FormClosing -= My_FormClosing;
            base.DestroyHandle();
        }


        protected SizeF _ScaleFactor = new SizeF(1.0f, 1.0f);
        public SizeF ScaleFactor { get { return _ScaleFactor; } }
        
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);

            float width = factor.Width;
            float height = factor.Height;
            _ScaleFactor.Width *= width;
            _ScaleFactor.Height *= height;

            if (width != 1.0f)
            {
                foreach (DataGridViewColumn cmn in Columns)
                {
                    cmn.MinimumWidth = (int)((float)cmn.MinimumWidth * width);
                    cmn.Width = (int) ((float) cmn.Width*width);
                    if (cmn is MyDgvMcCBColumn)
                    {
                        (cmn as MyDgvMcCBColumn).ScaleColumn(factor);
                    }
                    if (cmn is MyDgvMcComboBoxColumn)
                    {
                        (cmn as MyDgvMcComboBoxColumn).ScaleColumn(factor);
                    }
                }
            }

            if (height != 1.0f)
            {
                foreach (var row in Rows)
                {
                    var r = row as DataGridViewRow;
                    if (r != null)
                        r.Height = (int) ((float) (r.Height - 0)*height) + 0;
                }
                this.RowTemplate.Height = (int) ((float)(RowTemplate.Height - 2) * height) + 2;
            }
        }

        public void CheckSizes(float basefontaize)
        {
            // ---- no need for this
            /*
            float f1 = 1.0f;
            if (MyFormBase.DPIFactor != -1.0f) 
                f1 = MyFormBase.DPIFactor;
            if (f1 == 1.0f) return;
            _ScaleFactor.Width *= f1;
            _ScaleFactor.Height *= f1;
            float w;
            foreach (DataGridViewColumn cmn in Columns)
            {
                w = (float)cmn.Width * f1;
                cmn.Width = (int)Math.Round(w, 0);
            }
            w = (float)this.RowTemplate.Height;
            w = w * f1;
            this.RowTemplate.Height = (int)Math.Round(w, 0);
            */
        }

        public int[] GetColumnWidths(float basefontaize)
        {
            float f1 = 1.0f;
            if (MyFormBase.DPIFactor != -1.0f)
                f1 = MyFormBase.DPIFactor;
            float w, fs = DefaultCellStyle.Font.SizeInPoints;
            int[] cw = new int[Columns.Count];
            for (int i = 0; i < Columns.Count; i++)
            {
                w = (float) Columns[i].Width/ScaleFactor.Width;
                cw[i] = (int) Math.Round(w, 0);
            }
            return cw;
        }
        
        public void SetColumnWidths(int[] widths)
        {
            if (widths.Length != Columns.Count) return;
            for (int i = 0; i < Columns.Count; i++)
            {
                Columns[i].Width = (int)Math.Round((float)widths[i] * ScaleFactor.Width, 0);
            }
        }
        

        private int FirstVisibleColumn()
        {
            for (int i = 0; i < this.ColumnCount; i++)
            {
                if (this.Columns[i].Visible) return i;
            }
            return -1;
        }

        public void MoveToNewRow(int columnindex = -1)
        {
            if (!this.AllowUserToAddRows || this.ReadOnly) return;
            if (columnindex == -1)
            {
                columnindex = FirstVisibleColumn();
                if (columnindex == -1) return;
            }
            this.CurrentCell = this[columnindex, this.NewRowIndex];
        }

        public DataRow GetCurrentDataRow()
        {
            if (this.CurrentRow == null || 
                this.CurrentRow.IsNewRow) return null;
            try
            {
                object o = this.CurrentRow.DataBoundItem;
                if (o == null) return null;
                var drv = o as DataRowView;
                if (drv == null) return null;
                return drv.Row;
            }
            catch (Exception){}
            return null;
        }

        public DataRow GetDataRow(int k)
        {
            object o = GetDataItem(k);
            if (o == null) return null;
            var drv = o as DataRowView;
            if (drv == null) return null;
            return drv.Row;
        }

        public object GetCurrentDataItem()
        {
            if (this.CurrentRow == null || this.CurrentRow.Index == -1 ||
                this.CurrentRow.IsNewRow) return null;
            try
            {
                CurrencyManager cm = (CurrencyManager)this.BindingContext[this.DataSource, this.DataMember];
                if (cm == null || this.CurrentRow.Index >= cm.Count) return null;
                return this.CurrentRow.DataBoundItem;
            }
            catch (Exception){}
            return null;
        }

        [System.Diagnostics.DebuggerHidden()]
        public object GetDataItem(int k)
        {
            try
            {
                if (k < 0 || k >= this.Rows.Count ||
                    k == this.NewRowIndex) return null;
                return this.Rows[k].DataBoundItem;
            }
            catch (Exception) { }
            return null;
        }

        private void My_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.EndEdit();
        }


        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Tab:
                    if (e.Control && TakeCtrlTabKey)
                    {
                        e.IsInputKey = true;
                        return;
                    }
                    break;
            }
            base.OnPreviewKeyDown(e);
        }

        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    if (e.Control)
                    {
                        OnMyKeyDown(e);
                        return true;
                    }
                    break;
                case Keys.Enter:
                    if (!e.Control)
                    {
                        return ProcessRightKey(e.KeyData & ~(Keys.Control | Keys.Shift));
                        //return ProcessTabKey(e.KeyData & ~(Keys.Control | Keys.Shift));
                    }
                    break;
                case Keys.End:
                    if (!e.Control)
                    {
                        var ret = ProcessEndKey(e.KeyData);
                        if(ret) FirstDisplayedScrollingColumnIndex = CurrentCell.ColumnIndex;
                        return ret;
                    }
                    break;
                case Keys.Delete:
                    if (e.Control)
                    {
                        OnMyKeyDown(e);
                        return true;
                    }
                    break;
                case Keys.Insert:
                    if (e.Control || e.Shift)
                    {
                        OnMyKeyDown(e);
                        return true;
                    }
                    break;
            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                return Copy(true);
            }

            return base.ProcessDataGridViewKey(e);
        }

        private object lastCurrentRow = null;
        private static DateTime lastCheckCurrentRowTime = DateTime.MinValue;

        protected void CheckCurrentRowChanged()
        {
            var o = GetCurrentDataItem();
            if (o == lastCurrentRow) return;
            if (lastCurrentRow == null)
            {
                lastCurrentRow = o;
                return;
            }
            lastCurrentRow = o;
            var bs = this.DataSource as MyBindingSource2;
            if (AutoSave && bs != null && this.CurrentRow != null && 
                !this.IsCurrentRowDirty && !CurrentRow.IsNewRow &&
                (DateTime.Now - lastCheckCurrentRowTime).Seconds > 2)
            {
                bs.SaveTable();
                lastCheckCurrentRowTime = DateTime.Now;
            }
            if (o != null && MyCheckForChanges != null)
                MyCheckForChanges(this, new EventArgs());
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            CheckCurrentRowChanged();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            CheckCurrentRowChanged();
        }

        /*
        private bool AllowUserToAddRowsA = true;
        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex != this.NewRowIndex)
            {
                AllowUserToAddRowsA = this.AllowUserToAddRows;
                this.AllowUserToAddRows = false;
            }
            base.OnCellBeginEdit(e);
        }

        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            this.AllowUserToAddRows = AllowUserToAddRowsA;
            base.OnCellEndEdit(e);
        }
        */

        public bool Copy(bool withheaders)
        {
            try
            {
                //DataFormats.UnicodeText - has tab separeted values
                var ccm = ClipboardCopyMode;
                if(withheaders)
                    ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                else
                    ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                string csv = (string) this.GetClipboardContent().GetData(DataFormats.UnicodeText);
                ClipboardCopyMode = ccm;
                /*
                var dataObject = new DataObject();
                var bytes = System.Text.Encoding.UTF8.GetBytes(csv);
                var stream = new System.IO.MemoryStream(bytes);
                dataObject.SetData(DataFormats.CommaSeparatedValue, stream);
                Clipboard.SetDataObject(dataObject, true);
                 */
                if (csv == null) return true;
                csv = csv.Replace(" ", "");
                if (string.IsNullOrEmpty(csv)) return true;
                var lines = csv.Split(new[] { "\r\n" }, StringSplitOptions.None);
                var checklines = lines.Where(d => d.Length == 0 || d[0] != '\t');
                if (!checklines.Any())
                {
                    var sb = new StringBuilder();
                    foreach (var line in lines)
                    {
                        sb.Append(line.Substring(1));
                        sb.Append("\r\n");
                    }
                    csv = sb.ToString();
                }
                Clipboard.SetText(csv);
            }
            catch (Exception)
            {
                
            }
            return true;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            Keys key = (keyData & Keys.KeyCode);
            switch (key)
            {
                case Keys.F3:
                case Keys.F4:
                case Keys.F5:
                    var kev = new KeyEventArgs(keyData);
                    OnMyKeyDown(kev);
                    if (kev.Handled)
                        return true;
                    break;
                case Keys.Enter:
                    /*
                    if (ProcessNextKey(keyData & ~(Keys.Control | Keys.Shift)))
                    {
                        return true;
                    }*/
                    if ((keyData & Keys.Control) == 0)
                    {
                        if (ProcessRightKey(keyData & ~(Keys.Control | Keys.Shift)))
                        {
                            return true;
                        }
                    }
                    break;
            }

            var ret = base.ProcessDialogKey(keyData);
            CheckCurrentRowChanged();
            return ret;
        }

        public void RefreshCurrent()
        {
            if (CurrentRow == null || CurrentRow.IsNewRow) return;
            this.InvalidateRow(CurrentRow.Index);
        }

        private bool IsInPainting = false;
        protected override void OnPaint(PaintEventArgs pevent)
        {
            IsInPainting = true;
            try
            {
                base.OnPaint(pevent);
                var pen = new Pen(this.ForeColor, 1);
                pevent.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
            finally
            {
                IsInPainting = false;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (!AllowUserToAddRows) return;
            if (Rows.Count == 0 || CurrentCell == null) return;
            Rows[NewRowIndex].Selected = false;
            if (SelectedRows.Count > 0) return;
            if (SelectedCells.Count == 0) return;
            if (SelectedCells.Count == 1 && SelectedCells[0] == CurrentCell) return;
            ClearSelection();
        }

        public bool EndEditX()
        {
            if (!EndEdit()) return false;
            var bs = DataSource as BindingSource;
            if (bs == null || CurrentRow == null ||
                CurrentRow.IsNewRow ||
                bs.Current == null) return true;

            var drv = bs.Current as DataRowView;
            if (drv == null) return true;
            if (drv.Row.RowState == DataRowState.Detached) return true;

            try
            {
                bs.EndEdit();
                this.InvalidateRow(CurrentRow.Index);
                return true;
            }
            catch (Exception e)
            {
                Form_Error.ShowException(e, this);
                return false;
            }
        }




        private const int WM_CHAR = 0x0102;

        protected override void OnValidating(CancelEventArgs e)
        {
            if (GoingToDialog) return;
            base.OnValidating(e);
        }
        protected override void OnRowValidating(DataGridViewCellCancelEventArgs e)
        {
            //if grid is bad state - not synced with datasource
            //and OnPaint gets called (like when called MessageBox.ShowDialog)
            //we get some stupid errors
            if (e.RowIndex == NewRowIndex) return;
            if (GetDataItem(e.RowIndex) == null) return;
            base.OnRowValidating(e);
        }
        public void OnMyKeyDown(KeyEventArgs e)
        {
            if (MyKeyDown != null)
                MyKeyDown(this, e);
        }

        private void MyDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (IsInPainting)
            {
                e.Cancel = true;
                return;
            }
            if (e.Exception != null)
            {
                MyException mex = ExceptionHelper.TranslateException(e.Exception, this);
                Form_Error.ShowException(mex);
            }
            e.Cancel = true;
        }

        private Timer clickTimer = new Timer();
        private DataGridViewCellEventArgs cellClickEventArgs = null;
        
        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            //base.OnCellClick(e);
            //return;

            if (clickTimer.Enabled)
            {
                clickTimer.Stop();
                if (e.ColumnIndex == cellClickEventArgs.ColumnIndex
                    && e.RowIndex == cellClickEventArgs.RowIndex)
                {
                    OnCellDoubleClick(e);
                    return;
                }
            }
            cellClickEventArgs = new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex);
            clickTimer.Start();
        }

        protected override void OnCellDoubleClick(DataGridViewCellEventArgs e)
        {
            clickTimer.Stop();
            base.OnCellDoubleClick(e);
        }
        
        private void OnClickTimerTick(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated) return;
            if (this.RowCount == 0) return;
            clickTimer.Stop();
            if (CurrentCell == null) return;
            if (cellClickEventArgs.RowIndex < 0) return;
            if (cellClickEventArgs.RowIndex >= Rows.Count) return;
            base.OnCellClick(cellClickEventArgs);
        }


        public void DisableAllColumnSorting()
        {
            foreach (DataGridViewColumn column in Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

    }


}
