using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KlonsLIB.Components
{
    public class MyMcComboBox : ComboBox
    {

        public enum CustomDropDownStyle
        {
            DropDown,
            DropDownList,
            DropDownListSimple
        }

        private CustomDropDownStyle m_DropDownStyle;
        private bool PressedKey;
        private int[] wcols;
        private int[] wcols2;
        private int[] m_ColumnIndexInDataTable;
        private int m_ColumnCount;
        private string m_ColumnWidth;
        private bool m_GridLineVertical;
        private bool m_GridLineHorizontal;
        private Color m_GridLineColor;
        private string[] m_ColumnNames;
        private string[] m_ColumnNamesAll;
        private string[] m_ItemStrings = null;

        public MyMcComboBox()
        {
            PressedKey = false;
            m_ColumnCount = 1;
            m_ColumnIndexInDataTable = null;
            m_ColumnCount = 1;
            m_ColumnWidth = Width.ToString();
            m_GridLineVertical = false;
            m_GridLineHorizontal = false;
            m_GridLineColor = Color.LightGray;
            base.DropDownStyle = ComboBoxStyle.DropDown;
            DrawMode = DrawMode.OwnerDrawFixed;
            //base.DropDownHeight = MaxDropDownItems * ItemHeight;
            base.FormattingEnabled = true;
            IntegralHeight = true;
        }

        protected new bool FormattingEnabled
        {
            get { return base.FormattingEnabled; }
            set { base.FormattingEnabled = true; }
        }

        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                if (DataSource == value) return;
                base.DataSource = value;
                SelectedIndex = -1;
                TryDataBinding();
            }
        }

        public void SetListBinding(object datasource, string displaymember, string valuemember, string[] columnnames)
        {
            BeginUpdateX();
            this.ColumnNames = columnnames;
            this.DataSource = datasource;
            this.DisplayMember = displaymember;
            this.ValueMember = valuemember;
            EndUpdateX();
        }

        public class MyItem
        {
            private string[] _cols = new string[] {null, null, null, null};

            [DefaultValue(null)]
            public string Col1
            {
                get { return _cols[0]; }
                set { _cols[0] = value; }
            }

            [DefaultValue(null)]
            public string Col2
            {
                get { return _cols[1]; }
                set { _cols[1] = value; }
            }

            [DefaultValue(null)]
            public string Col3
            {
                get { return _cols[2]; }
                set { _cols[2] = value; }
            }

            [DefaultValue(null)]
            public string Col4
            {
                get { return _cols[3]; }
                set { _cols[3] = value; }
            }

            public MyItem()
            {
                Col1 = null;
                Col2 = null;
                Col3 = null;
                Col4 = null;
            }

            public MyItem(string val)
            {
                SetFronString(val);
            }

            public override string ToString()
            {
                return Col1;
            }

            public string GetValue(int n)
            {
                return _cols[n];
            }

            public void SetFronString(string val)
            {
                if (val == null) return;
                string[] ss = val.Split(';');
                int k = ss.Length;
                if (k == 0) return;
                if (k > 4) k = 4;
                for (int i = 0; i < k; i++)
                    _cols[i] = ss[i];
            }

            public static List<MyItem> GetList(string[] strings)
            {
                if (strings == null) return null;
                List<MyItem> list = new List<MyItem>();
                for (int i = 0; i < strings.Length; i++)
                    list.Add(new MyItem(strings[i]));
                return list;
            }
        }

        [Description("String items with columns seperated by ';'")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(null)]
        [Category("Data")]
        public string[] ItemStrings
        {
            get { return m_ItemStrings; }
            set
            {
                m_ItemStrings = value;
                if (value == null) return;
                List<MyItem> itemlist = MyItem.GetList(value);
                Items.Clear();
                Items.AddRange(itemlist.ToArray());
            }
        }


        [Browsable(false)]
        public int ColumnCount
        {
            get { return m_ColumnCount; }
        }

        [Description("Size of columns in pixel, seperated by ;")]
        [Category("Behavior")]
        public string ColumnWidths
        {
            get { return m_ColumnWidth; }
            set
            {
                m_ColumnWidth = value;
                if (m_ColumnWidth == null || m_ColumnWidth == "") m_ColumnWidth = "100";

                string[] ws = m_ColumnWidth.Split(";".ToArray());

                if (ws.Length == 0)
                {
                    m_ColumnWidth = "100";
                    ws = new[] { "100" };
                }

                int i, w1;
                int[] ww = new int[ws.Length];

                for (i = 0; i < ws.Length; i++)
                {
                    if (!int.TryParse(ws[i], out w1))
                    {
                        ColumnWidths = "";
                        return;
                    }
                    if (w1 < 0 || w1 > 1600)
                    {
                        ColumnWidths = "";
                        return;
                    }
                    ww[i] = w1;
                }
                wcols = ww;

                CheckColumns();
            }
        }
        /*
        [Category("CatBehavior")]
        [Description("ComboBoxDropDownWidthDescr")]
        public new int DropDownWidth
        {
            get
            {
                return base.DropDownWidth;
            }

            set
            {
                base.DropDownWidth = value;
                CheckColumns();
            }
        }
        */

        /*
        public void ResizeColumns(float basefontsize)
        {
            if (wcols == null || Font == null) return;
            int i;
            for (i = 0; i < wcols.Length; i++)
            {
                wcols[i] = (int) Math.Round((float) wcols[i]*Font.SizeInPoints/basefontsize, 0);
            }
            CheckColumns();
        }
        */

        public void ScaleControlA(SizeF factor)
        {
            float width = factor.Width;
            if (width == 1.0f) return;
            for (int i = 0; i < wcols.Length; i++)
            {
                wcols[i] = (int) ((float) wcols[i]*width);
            }
            for (int i = 0; i < wcols2.Length; i++)
            {
                wcols2[i] = (int) ((float) wcols2[i]*width);
            }
            base.DropDownWidth = (int) ((float) DropDownWidth*width);
            //DropDownHeight = (int) ((float) DropDownHeight*factor.Height);
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            ScaleControlA(factor);
        }

        private void CheckColumns()
        {
            int i, w1, totalwidth;
            m_ColumnCount = 1;
            if (m_ColumnNames != null && m_ColumnNames.Length > 0)
            {
                m_ColumnCount = m_ColumnNames.Length;
            }
            else
            {
                if (m_ColumnNamesAll != null && m_ColumnNamesAll.Length > 0)
                {
                    m_ColumnCount = m_ColumnNamesAll.Length;
                }
            }

            wcols2 = new int[m_ColumnCount];

            if (wcols == null) wcols = new int[0];

            totalwidth = 0;
            for (i = 0; i < wcols2.Length; i++)
            {
                if (i >= wcols.Length)
                    wcols2[i] = 100;
                else
                    wcols2[i] = wcols[i];
                totalwidth += wcols2[i];
            }
            w1 = totalwidth + SystemInformation.VerticalScrollBarWidth + 2;
            if (w1 != DropDownWidth) base.DropDownWidth = w1;

        }

        private void CheckColumnIndexes()
        {
            if (!this.DesignMode)
                if (IsHandleCreated && !Focused && SelectionLength > 0)
                    Select(0, 0);
                    //SelectionLength = 0;

            if (m_ColumnNames == null || m_ColumnNames.Length == 0)
            {
                m_ColumnIndexInDataTable = new int[m_ColumnCount];
                for (int i = 0; i < m_ColumnIndexInDataTable.Count(); i++)
                    m_ColumnIndexInDataTable[i] = i;
                return;
            }

            m_ColumnIndexInDataTable = new int[m_ColumnCount];
            for (int i = 0; i < m_ColumnIndexInDataTable.Count(); i++)
                m_ColumnIndexInDataTable[i] = -1;

            if (m_ColumnNamesAll == null || m_ColumnNamesAll.Length == 0) return;

            for (int i = 0; i < m_ColumnNames.Count(); i++)
            {
                string columnName = m_ColumnNames[i].ToLower();
                if (m_ColumnNamesAll.Contains(columnName))
                {
                    m_ColumnIndexInDataTable[i] = Array.IndexOf(m_ColumnNamesAll, columnName);
                }
            }
        }

        [Description("ColumnNames of the Datatable passed through SourceDataTable Property to show in the Dropdownlist")
        ]
        [Category("Data")]
        public string[] ColumnNames
        {
            get { return m_ColumnNames; }
            set
            {
                m_ColumnNames = value;
                if (m_ColumnNames == null) m_ColumnNames = new string[] {};

                CheckColumns();
                CheckColumnIndexes();
            }
        }


        public void TryDataBinding()
        {
            int i;
            PropertyDescriptorCollection pc = null;
            if (this.DataSource != null)
            {
                pc = ListBindingHelper.GetListItemProperties(this.DataSource);
            }
            if (pc == null)
            {
                CurrencyManager cm = this.DataManager;
                if (cm != null)
                {
                    pc = cm.GetItemProperties();

                }
            }
            if (pc == null)
            {
                pc = ListBindingHelper.GetListItemProperties(this.Items);
            }
            if (pc != null)
            {
                m_ColumnNamesAll = new string[pc.Count];
                for (i = 0; i < m_ColumnNamesAll.Length; i++)
                {
                    m_ColumnNamesAll[i] = pc[i].Name.ToLower();
                }
            }
            CheckColumns();
            CheckColumnIndexes();
        }


        protected override void OnBindingContextChanged(EventArgs e)
        {
            base.OnBindingContextChanged(e);
            this.TryDataBinding();
        }

        protected override void OnDataSourceChanged(EventArgs e)
        {
            this.TryDataBinding();
            base.OnDataSourceChanged(e);
        }

        [Description("Set to true if you want the vertical line to divide every column in the Dropdownlist")]
        [Category("Appearance")]
        public bool GridLineVertical
        {
            get { return m_GridLineVertical; }
            set { m_GridLineVertical = value; }
        }

        [DefaultValue(CustomDropDownStyle.DropDown)]
        [Description("When DropDownList, you can only select items in the combo")]
        [Category("Appearance")]
        public new CustomDropDownStyle DropDownStyle
        {
            get { return m_DropDownStyle; }
            set
            {
                m_DropDownStyle = value;
                if (value == CustomDropDownStyle.DropDownListSimple)
                {
                    base.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else
                {
                    base.DropDownStyle = ComboBoxStyle.DropDown;
                }
                TypeDescriptor.Refresh(this);
            }
        }

        [Description("Set to true if you want the horizontal line to divide every column in the Dropdownlist")]
        [Category("Appearance")]
        public bool GridLineHorizontal
        {
            get { return m_GridLineHorizontal; }
            set { m_GridLineHorizontal = value; }
        }

        [Description("Color of the gridlines in the Dropdownlist")]
        [Category("Appearance")]
        public Color GridLineColor
        {
            get { return m_GridLineColor; }
            set { m_GridLineColor = value; }
        }

        [Description("Max. count of items in drop down list")]
        [Category("Behavior")]
        public new int MaxDropDownItems
        {
            get { return base.MaxDropDownItems; }
            set
            {
                base.MaxDropDownItems = value;
                DropDownHeight = MaxDropDownItems*ItemHeight;
            }
        }


        [
            DefaultValue(null),
            Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
            Bindable(true),
            Category("Data")
        ]
        public new object SelectedValue
        {
            get
            {
                if (SelectedIndex == -1) return null;
                if (ItemStrings != null)
                {
                    var o = FilterItemOnProperty(Items[SelectedIndex], ValueMember);

                    if (o == null) return null;
                    return o.ToString();
                }
                return base.SelectedValue;
            }
            set
            {
                if (value == null)
                {
                    SelectedIndex = -1;
                    return;
                }

                if (ItemStrings != null)
                {
                    if (!(value is string)) return;
                    SelectedIndex = FindMyItemByValue(value.ToString());
                    return;
                }
                base.SelectedValue = value;

                UpdateTextA();
            }
        }

        public void UpdateTextA()
        {
            string s = null;
            if (SelectedIndex != -1)
            {
                object item = Items[SelectedIndex];
                if (item != null)
                {
                    s = GetItemText(item);
                }
            }
            Text = s;
        }

        //for datasource changes
        private int updateCountA = 0;
        private object selectedValueBeforeUpdate = null;

        public void BeginUpdateX()
        {
            if (updateCountA == 0)
            {
                selectedValueBeforeUpdate = SelectedValue;
            }
            updateCountA++;
            BeginUpdate();
        }

        public void EndUpdateX()
        {
            updateCountA--;
            EndUpdate();
            if (updateCountA == 0)
            {
                SelectedValue = selectedValueBeforeUpdate;
                UpdateTextA();
            }
        }

        public bool IsInUpdateX { get { return updateCountA > 0; } }

        private static List<string> m_MyItemFieldList = new List<string>() {"col1", "col2", "col3", "col4"};

        private int FindMyItemByValue(string value)
        {
            if (ItemStrings == null) return -1;
            Object o;
            MyItem it;
            string s;

            int fk = m_MyItemFieldList.IndexOf(ValueMember.ToLower());
            if (fk == -1) return -1;

            for (int i = 0; i < Items.Count; i++)
            {
                o = Items[i];
                if (o == null) continue;
                it = o as MyItem;
                if (it == null) continue;
                s = it.GetValue(fk);
                if (s == null) continue;
                if (string.Compare(value, s, true) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                base.Dispose(true);
            }
            GC.SuppressFinalize(this);
        }

        private string ItemString2(int row)
        {
            object o;
            if (Items[row] is DataRowView)
            {
                if (m_ColumnIndexInDataTable != null)
                {
                    o = (Items[row] as DataRowView).Row[DisplayMember];

                    if (ColumnCount == 1 && FormattingEnabled)
                    {
                        var args = new ListControlConvertEventArgs(o, typeof(string), Items[row]);
                        this.OnFormat(args);
                        o = args.Value;
                    }
                    if (o == null) return "";
                    return o.ToString();
                }

                return "";
            }

            if (m_ColumnNames != null && DisplayMember != null)
            {
                o = FilterItemOnProperty(Items[row], DisplayMember);
                if (o == null) return "";
                return o.ToString();
            }

            return Items[row].ToString();
        }

        private string ItemString(int row, int col)
        {
            object o;
            if (Items[row] is DataRowView)
            {
                if (m_ColumnIndexInDataTable != null
                    && m_ColumnIndexInDataTable.Length > col)
                {
                    int k = m_ColumnIndexInDataTable[col];
                    if (k == -1) return "";
                    o = (Items[row] as DataRowView).Row[k];
                    if (ColumnCount == 1 && FormattingEnabled)
                    {
                        var args = new ListControlConvertEventArgs(o, typeof(string), Items[row]);
                        this.OnFormat(args);
                        o = args.Value;
                    }
                    if (o == null) return "";
                    return o.ToString();
                }

                return "";
            }

            if (m_ColumnNames != null && m_ColumnNames.Length > col)
            {
                o = FilterItemOnProperty(Items[row], m_ColumnNames[col]);
                if (o == null) return "";
                return o.ToString();
            }

            return Items[row].ToString();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= Items.Count) return;

            Rectangle r = e.Bounds;
            Rectangle r1 = r;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;

            int i;
            string celltext = "";

            Color backColor = this.BackColor;
            Color textcolor = ForeColor;
            Color gridLineColor = GridLineColor;

            if ((e.State & DrawItemState.Selected) != 0)
            {
                backColor = SystemColors.Highlight;
                textcolor = SystemColors.HighlightText;
                gridLineColor = SystemColors.HighlightText;
            }

            e.Graphics.FillRectangle(new SolidBrush(backColor), r);

            SolidBrush textbrush = new SolidBrush(textcolor);
            Pen gridpen = new Pen(gridLineColor, 1f);


            if (!DroppedDown && DropDownStyle == CustomDropDownStyle.DropDownListSimple)
            {
                celltext = this.ItemString2(e.Index);
                r1.Width = r.Width;
                e.Graphics.DrawString(celltext, Font
                    , textbrush, r1, sf);
                e.DrawFocusRectangle();
                return;
            }

            for (i = 0; i < ColumnCount; i++)
            {
                r1.Width = wcols2[i];
                if (r1.Width > 0)
                {
                    celltext = ItemString(e.Index, i);

                    if (!string.IsNullOrEmpty(celltext))
                    {
                        e.Graphics.DrawString(celltext, Font
                            , textbrush, r1, sf);
                    }

                    if (i > 0 && m_GridLineVertical)
                    {
                        e.Graphics.DrawLine(gridpen,
                            r1.X, r1.Y, r1.X, r1.Bottom);
                    }
                }
                r1.X += wcols2[i];
            }

            if (m_GridLineHorizontal)
            {
                e.Graphics.DrawLine(gridpen,
                    r.X, r.Bottom - 1, r.Right, r.Bottom - 1);
            }

            e.DrawFocusRectangle();

        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //Debug.WriteLine("OnKeyPress " + Text);
            if (e.KeyChar == (char) Keys.Escape)
            {
                if (DroppedDown)
                {
                    DroppedDown = false;
                    e.Handled = true;
                    base.OnKeyPress(e);
                    return;
                }
            }

            if (DropDownStyle == CustomDropDownStyle.DropDownListSimple)
            {
                base.OnKeyPress(e);
                return;
            }

            if (DropDownStyle == CustomDropDownStyle.DropDown)
            {
                PressedKey = true;
                if (e.KeyChar == (char) Keys.Back)
                {
                    if (SelectedText == Text)
                    {
                        SelectedIndex = -1;
                    }
                }
                base.OnKeyPress(e);
                return;
            }

            if (e.KeyChar == (char) Keys.Back)
            {
                if (SelectedText == Text)
                {
                    PressedKey = true;
                    SelectedIndex = -1;
                    base.OnKeyPress(e);
                    return;
                }
            }

            string sTypedText = "";

            if (SelectionLength > 0)
            {
                if (Text == null)
                {
                    Text = e.KeyChar.ToString();
                }
                else
                {
                    int start = SelectionStart;
                    int selLength = SelectionLength;
                    string currentText = AccessibilityObject.Value;
                    int position = Text.IndexOf("&");
                    string testingString;
                    if (position > 0L)
                    {
                        testingString = Text.Remove(position, 1);
                    }
                    else
                    {
                        testingString = Text;
                    }
                    if (string.Compare(testingString, AccessibilityObject.Value, true) == 0)
                    {
                        currentText = Text;
                    }
                    currentText = currentText.Remove(start, selLength);
                    currentText = currentText.Insert(start, e.KeyChar.ToString());
                    sTypedText = currentText;
                }
            }
            else
            {
                int start = SelectionStart;
                if (Text == null)
                    sTypedText = e.KeyChar.ToString();
                else
                    sTypedText = Text.Insert(start, e.KeyChar.ToString());
            }
            int iFoundIndex = FindString(sTypedText);
            if (iFoundIndex >= 0)
            {
                PressedKey = true;
            }
            else
            {
                e.Handled = true;
            }

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //Debug.WriteLine("OnKeyDown " + Text);

            if (e.KeyCode == Keys.Return)
            {
                int iFoundIndex;
                iFoundIndex = FindStringExact(Text);
                SelectedIndex = iFoundIndex;
                if (DroppedDown) DroppedDown = false;
                e.Handled = true;
                base.OnKeyUp(e);
                return;
            }

            if (DropDownStyle == CustomDropDownStyle.DropDownListSimple)
            {
                base.OnKeyDown(e);
                return;
            }
            if (DropDownStyle == CustomDropDownStyle.DropDownList && e.KeyCode == Keys.Delete)
            {
                if (Text != SelectedText)
                {
                    e.Handled = true;
                }
                else
                {
                    SelectedIndex = -1;
                }
            }
            if (DropDownStyle == CustomDropDownStyle.DropDown && e.KeyCode == Keys.Delete)
            {
                if (Text == SelectedText)
                {
                    if (SelectedIndex != -1)
                    {
                        SelectedIndex = -1;
                        e.Handled = true;
                    }
                }

            }
            base.OnKeyDown(e);
            if (SelectedIndex == -1)
                OnSelectedIndexChanged(new EventArgs());
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            //Debug.WriteLine("OnKeyUp " + Text);
            if (DropDownStyle == CustomDropDownStyle.DropDownListSimple)
            {
                base.OnKeyUp(e);
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.End:
                case Keys.Home:
                case Keys.Left:
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                case Keys.Delete:
                    base.OnKeyUp(e);
                    return;
            }

            if (!PressedKey) return;

            int iFoundIndex;
            string sTypedText = Text;
            if (e.KeyCode != Keys.Back)
            {
                iFoundIndex = FindString(sTypedText);
            }
            else
            {
                iFoundIndex = FindStringExact(sTypedText);
            }
            if (iFoundIndex >= 0 && Text != "")
            {
                object oFoundItem = Items[iFoundIndex];
                string sFoundText = GetItemText(oFoundItem);
                string sAppendText = sFoundText.Substring(sTypedText.Length);
                Text = sTypedText + sAppendText;
                SelectionStart = sTypedText.Length;
                SelectionLength = sAppendText.Length;
            }
            else
            {
                SelectedIndex = -1;
                SelectedItem = null;
            }

            if (SelectedIndex == -1)
                OnSelectedIndexChanged(new EventArgs());

            PressedKey = false;
        }

        [Category("Data")]
        [DefaultValue(false)]
        public bool _AllowSelection { get; set; } = false;

        protected override bool AllowSelection
        {
            get { return _AllowSelection; }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (IsInUpdateX) return;
            base.OnSelectedIndexChanged(e);
            if (this.IsDisposed || !this.IsHandleCreated) return;
            if (!Focused && SelectionLength > 0)
                SelectionLength = 0;
        }

        protected override void OnSelectedValueChanged(EventArgs e)
        {
            if (IsInUpdateX) return;
            base.OnSelectedValueChanged(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            SelectAll();
        }

        protected override void OnLeave(EventArgs e)
        {
            string currentText = AccessibilityObject.Value;
            int position = Text.IndexOf("&");
            string testingString;
            if (position > 0L)
            {
                testingString = Text.Remove(position, 1);
            }
            else
            {
                testingString = Text;
            }
            if (string.Compare(testingString, AccessibilityObject.Value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                currentText = Text;
            }
            int iFoundIndex = FindStringExact(currentText);
            if (SelectedIndex != iFoundIndex)
            {
                //throw new Exception("SelectedIndex != iFoundIndex");
            }
            /*
            SelectedIndex = iFoundIndex;
            if (iFoundIndex == -1)
            {
                SelectedItem = null;
            }
             */
            base.OnLeave(e);
        }

        protected override void OnCreateControl()
        {
            //DisplayMember = "Text";
            //DrawMode = DrawMode.OwnerDrawFixed;
            //Invalidate();
            base.DropDownHeight = MaxDropDownItems*ItemHeight;
            //ResizeColumns(10.0f);
        }


        private DateTime lastMouseClick = DateTime.Now;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (DateTime.Now.AddMilliseconds(-500) < lastMouseClick)
            {
                lastMouseClick = DateTime.Now;
                OnMouseDoubleClick(e);
                return;
            }
            lastMouseClick = DateTime.Now;
            base.OnMouseClick(e);

        }

        protected override void SetItemsCore(IList value)
        {
            string sv = Text;
            base.SetItemsCore(value);
            TryDataBinding();
            if(!_AllowSelection) 
                Text = sv;
            if (Focused) SelectAll();
        }


        protected override void RefreshItems()
        {
            string sv = Text;
            base.RefreshItems();
            Text = sv;
            if (Focused) SelectAll();
        }


        #region dropdown reposition 
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int
            X, int Y, int cx, int cy, uint uFlags);

        private const int SWP_NOSIZE = 0x1;
        private const UInt32 WM_CTLCOLORLISTBOX = 0x0134;

        
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CTLCOLORLISTBOX)
            {
                int left = this.PointToScreen(new Point(0, 0)).X;

                if (this.DropDownWidth > Screen.PrimaryScreen.WorkingArea.Width - left)
                {
                    Rectangle comboRect = this.RectangleToScreen(this.ClientRectangle);

                    int dropHeight = 0;
                    int topOfDropDown = 0;
                    int leftOfDropDown = 0;

                    for (int i = 0; (i < this.Items.Count && i < this.MaxDropDownItems); i++)
                    {
                        dropHeight += this.ItemHeight;
                    }

                    if (dropHeight > Screen.PrimaryScreen.WorkingArea.Height -
                       this.PointToScreen(new Point(0, 0)).Y)
                    {
                        topOfDropDown = comboRect.Top - dropHeight - 2;
                    }
                    else
                    {
                        topOfDropDown = comboRect.Bottom;
                    }

                    leftOfDropDown = comboRect.Left - (this.DropDownWidth -
                       (Screen.PrimaryScreen.WorkingArea.Width - left));

                    SetWindowPos(m.LParam,
                       IntPtr.Zero,
                       leftOfDropDown,
                       topOfDropDown,
                       0,
                       0,
                       SWP_NOSIZE);
                }
            }

            base.WndProc(ref m);
        }
        #endregion
    }
}
