using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using KlonsLIB.Data;
using KlonsLIB.Misc;

namespace KlonsLIB.Components
{
    public class MyPickRowTextBox2 : TextBoxWithButton
    {

        private int selectedIndex = -1;
        private object dataSource = null;
        private string dataMember = null;
        private string valueMember = "";
        private string displayMember = "";
        private bool syncPosition = true;
        private int valueColumnNr = -1;
        private int displayColumnNr = -1;

        private ListChangedEventHandler listChangedHandler;
        private EventHandler positionChangedHandler;


        public MyPickRowTextBox2()
        {
            listChangedHandler = new ListChangedEventHandler(dataManager_ListChanged);
            positionChangedHandler = new EventHandler(dataManager_PositionChanged);
        }

        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
        [Category("Data")]
        [DefaultValue(null)]
        public object DataSource
        {
            get
            {
                return this.dataSource;
            }
            set
            {
                if (this.dataSource != value)
                {
                    this.dataSource = value;
                    tryDataBinding();
                }
            }
        }


        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        [DefaultValue("")]
        public string DataMember
        {
            get { return this.dataMember; }
            set
            {
                if (this.dataMember != value)
                {
                    this.dataMember = value;
                    tryDataBinding();
                }
            }
        }

        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        [Category("Data")]
        public string ValueMember
        {
            get { return valueMember; }
            set
            {
                valueMember = value;
                valueColumnNr = -1;
            }
        }

        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        [Category("Data")]
        public string DisplayMember 
        { 
            get { return displayMember; }
            set
            {
                displayMember = value;
                displayColumnNr = -1;
            }
        }

        [DefaultValue(true)]
        [Category("Data")]
        public bool SyncPosition
        {
            get { return syncPosition; }
            set { syncPosition = value; }
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            this.tryDataBinding();
            base.OnBindingContextChanged(e);
        }

        private bool IsInPositionChanged = false;
        private bool isInSetSelectedIndex = false;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (selectedIndex == value) return;
                selectedIndex = value;

                if (selectedIndex < 0) selectedIndex = -1;
                if (selectedIndex >= dataManager.Count)
                    selectedIndex = dataManager.Count - 1;

                if (dataManager == null || isInSetSelectedIndex || IsInPositionChanged) return;

                isInSetSelectedIndex = true;

                if (SyncPosition)
                {
                    int k = selectedIndex;
                    if (k == -1) k = 0;
                    try
                    {
                        dataManager.Position = k;
                    }
                    catch (Exception)
                    {
                    }
                }

                if (selectedIndex == -1 && Text != null)
                {
                    Text = null;
                }
                if (selectedIndex > -1)
                {
                    var s = GetDisplayText(selectedIndex);
                    if (Text != s) Text = s;
                }

                isInSetSelectedIndex = false;

                OnSelectedIndexChanged();
            }
        }

        private void dataManager_PositionChanged(object sender, EventArgs e)
        {
            if (!SyncPosition) return;
            if (IsInPositionChanged || isInSetSelectedIndex) return;
            IsInPositionChanged = true;
            try
            {
                Text = GetDisplayText(dataManager.Position);
                if (SelectedIndex != dataManager.Position)
                    SelectedIndex = dataManager.Position;
            }
            finally
            {
                IsInPositionChanged = false;
            }
        }

        public event EventHandler SelectedIndexChanged;

        protected virtual void OnSelectedIndexChanged()
        {
            SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private CurrencyManager dataManager;

        private void tryDataBinding()
        {
            if (this.DataSource == null ||
                base.BindingContext == null)
                return;
            
            CurrencyManager cm;
            try
            {
                cm = (CurrencyManager)
                      base.BindingContext[this.DataSource,
                                          this.DataMember];
            }
            catch (System.ArgumentException)
            {
                // If no CurrencyManager was found
                return;
            }

            if (this.dataManager != cm)
            {
                if (this.dataManager != null)
                {
                    this.dataManager.ListChanged -= listChangedHandler;
                    this.dataManager.PositionChanged -= positionChangedHandler;
                    valueColumnNr = -1;
                    displayColumnNr = -1;
                }

                this.dataManager = cm;

                if (this.dataManager != null)
                {
                    this.dataManager.ListChanged += listChangedHandler;
                    this.dataManager.PositionChanged += positionChangedHandler;
                }
            }
        }


        private void dataManager_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.Reset)
            {
                Text = "";
                selectedIndex = -1;
            }
        }

        protected virtual bool IsDataSourceSortedByDisplayMember()
        {
            if (!((dataSource is BindingSource bs) && bs.IsSorted)) return false;
            if (bs.SortDescriptions.Count == 0) return false;
            if (bs.SortDescriptions[0].PropertyDescriptor.Name != displayMember) return false;
            if (bs.SortDescriptions[0].SortDirection != ListSortDirection.Ascending) return false;
            return true;
        }

        private int FindString(string s)
        {
            if (dataManager == null || s == null) return -1;
            int k = dataManager.List.Count;
            if (string.Compare(s, GetDisplayText(k - 1), true) == 0)
                return k - 1;
            if (IsDataSourceSortedByDisplayMember())
                return FindStringSorted(s);
            return FindStringSimple(s);
        }

        private int FindStringExact(string s)
        {
            if (dataManager == null || string.IsNullOrEmpty(s)) return -1;
            int k = dataManager.List.Count;
            if (string.Compare(s, GetDisplayText(k - 1), true) == 0)
                return k - 1;
            if (dataSource is BindingSource && (dataSource as BindingSource).IsSorted)
                return FindStringExactSorted(s);
            return FindStringExactSimple(s);
        }

        private int FindStringSimple(string s)
        {

            if (dataManager == null) return -1;
            string s1;
            for (int i = 0; i < dataManager.List.Count; i++)
            {
                s1 = GetDisplayText(i);
                if (s.Length > s1.Length) continue;
                if (string.Compare(s, s1.Substring(0, s.Length), true) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private int FindStringExactSimple(string s)
        {
            if (dataManager == null) return -1;
            for (int i = 0; i < dataManager.List.Count; i++)
            {
                if (string.Compare(s, GetDisplayText(i), true) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private int FindStringSorted(string s)
        {
            if (dataManager == null) return -1;
            if (string.IsNullOrEmpty(s)) return -1;
            int k1 = 0;
            int k2 = dataManager.List.Count - 1;
            int mk2 = k2;
            int k3 = (k1 + k2) / 2;
            int m;
            string s1;
            while (true)
            {
                s1 = GetDisplayText(k3);
                m = string.Compare(s, s1, true);
                if (m == 0) return k3;
                if (m < 0)
                {
                    if (k2 == k3)
                    {
                        if (s.Length > s1.Length) return -1;
                        s1 = s1.Substring(0, s.Length);
                        if (string.Compare(s, s1, true) == 0)
                            return k3;
                        return -1;
                    }
                    k2 = k3;
                    k3 = (k1 + k2) / 2;

                }
                if (m > 0)
                {
                    if (k1 == k3)
                    {
                        if (k1 < mk2)
                        {
                            k3++;
                            s1 = GetDisplayText(k3);
                            if (s.Length > s1.Length) return -1;
                            s1 = s1.Substring(0, s.Length);
                            if (string.Compare(s, s1, true) == 0)
                                return k3;

                        }
                        return -1;
                    }
                    k1 = k3;
                    k3 = (k1 + k2 + 1) / 2;
                }
            }
        }

        private int FindStringExactSorted(string s)
        {
            if (dataManager == null) return -1;
            if (string.IsNullOrEmpty(s)) return -1;
            int k1 = 0;
            int k2 = dataManager.List.Count - 1;
            int k3 = (k1 + k2) / 2;
            int m;
            while (true)
            {
                m = string.Compare(s, GetDisplayText(k3), true);
                if (m == 0) return k3;
                if (m < 0)
                {
                    if (k2 == k3) return -1;
                    k2 = k3;
                    k3 = (k1 + k2) / 2;

                }
                if (m > 0)
                {
                    if (k1 == k3) return -1;
                    k1 = k3;
                    k3 = (k1 + k2 + 1) / 2;

                }
            }
        }

        public int FindValueSimple(object value)
        {
            if (dataManager == null) return -1;
            for (int i = 0; i < dataManager.List.Count; i++)
            {
                if (object.Equals(value, GetValue(i)))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool GetDisplayTextX(object value, out string displaytext)
        {
            displaytext = null;
            var rt = GetDisplayValueXa(value, out object displayvalue);
            if (rt == EFindDisplayValueXaResult.NoMatch) return false;
            if (rt == EFindDisplayValueXaResult.OK)
            {
                if (displayvalue == DBNull.Value || displayvalue == null)
                    return true;
                displaytext = displayvalue.ToString();
                return true;
            }
            if (rt == EFindDisplayValueXaResult.NotTable)
            {
                int k = FindValueSimple(value);
                if (k == -1) return false;
                displaytext = GetDisplayText(k);
            }
            return true;
        }

        public enum EFindDisplayValueXaResult { NotTable, NoMatch, OK}
        public EFindDisplayValueXaResult GetDisplayValueXa(object value, out object displayvalue)
        {
            displayvalue = null;
            if (DataSource == null || ValueMember.IsNOE() || displayMember.IsNOE()) 
                return EFindDisplayValueXaResult.NotTable;
            if (!(DataSource is BindingSource bs)) return EFindDisplayValueXaResult.NotTable;
            DataTable table = null;
            if ((bs.DataSource is DataTable dt)) table = dt;
            else if (bs is MyBindingSource2 bs2) table = bs2.GetTable();
            else if (bs.DataSource is DataView dv) table = dv.Table;
            if (table == null) return EFindDisplayValueXaResult.NotTable;
            if (table.PrimaryKey.Length != 1) return EFindDisplayValueXaResult.NotTable;
            if (table.PrimaryKey[0].ColumnName != ValueMember) return EFindDisplayValueXaResult.NotTable;
            if (!table.Columns.Contains(DisplayMember)) return EFindDisplayValueXaResult.NotTable;
            var dr = table.Rows.Find(value);
            if (dr == null) return EFindDisplayValueXaResult.NoMatch;
            displayvalue = dr[displayMember];
            return EFindDisplayValueXaResult.OK;
        }

        private int FindValueAsString(string value)
        {
            if (string.IsNullOrEmpty(value)) return -1;
            if (dataManager == null) return -1;
            for (int i = 0; i < dataManager.List.Count; i++)
            {
                object o = GetValue(i);
                if (o == null) continue;
                if (value == o.ToString())
                    return i;
            }
            return -1;
        }

        public string GetDisplayText(int nr)
        {
            try
            {
                string s = GetDisplayTextA(nr);
                return s == null ? "" : s;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string GetDisplayTextA(int nr)
        {
            if (dataManager == null || nr == -1 || nr >= dataManager.List.Count) return null;
            DataRowView rv = dataManager.List[nr] as DataRowView;
            if (rv == null) return null;
            if (displayColumnNr == -1)
                displayColumnNr = rv.Row.Table.Columns.IndexOf(DisplayMember);
            if(displayColumnNr == -1) displayColumnNr = 0;
            return rv.Row[displayColumnNr].ToString();
        }

        private object GetValue(int nr)
        {
            if (dataManager == null || nr == -1 || nr >= dataManager.List.Count) return null;
            try
            {
                DataRowView rv = dataManager.List[nr] as DataRowView;
                if (rv == null) return null;
                if (valueColumnNr == -1)
                    valueColumnNr = rv.Row.Table.Columns.IndexOf(ValueMember);
                if (valueColumnNr == -1) valueColumnNr = 0;
                return rv.Row[valueColumnNr];
            }
            catch (Exception)
            {
                return null;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get
            {
                if (dataManager == null || SelectedIndex == -1 || SelectedIndex >= dataManager.List.Count) return null;
                var rv = dataManager.List[SelectedIndex];
                return rv;
            }
        }

        [
            DefaultValue(null),
            Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
            Bindable(true),
            Category("Data")
        ]
        public object SelectedValue
        {
            get
            {
                if (SelectedIndex == -1) return null;
                var o = GetValue(SelectedIndex);
                if (o == null) return null;
                return o;
            }
            set
            {
                if (value == null)
                {
                    SelectedIndex = -1;
                    if(Text != null) 
                        Text = null;
                    return;
                }
                int k = FindValueSimple(value);
                SelectedIndex = k;
            }
        }

        [
            DefaultValue(null),
            Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
            Bindable(true),
            Category("Data")
        ]
        public object SelectedValueAsString
        {
            get
            {
                if (SelectedIndex == -1) return null;
                var o = GetValue(SelectedIndex);
                if (o == null) return null;
                return o.ToString();
            }
            set
            {
                if (value == null)
                {
                    SelectedIndex = -1;
                    return;
                }
                int k = FindValueAsString(value as string);
                selectedIndex = k;
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (ReadOnly)
            {
                base.OnPreviewKeyDown(e);
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                Text = "";
                OnRowSelectedEvent(-1, null);
                return;
            }
            base.OnPreviewKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int k = FindStringExact(Text);
                if (k > -1)
                {
                    OnRowSelectedEvent(k, Text);
                    e.Handled = true;
                    return;
                }
            }
            base.OnKeyPress(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                OnButtonClicked(EventArgs.Empty);
                e.Handled = true;
            }

            if (ReadOnly)
            {
                base.OnKeyDown(e);
                return;
            }

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                doOnTextChangedDelBackKey = true;
            }

            int k = 0;
            if (e.KeyCode == Keys.Up) k = -1;
            if (e.KeyCode == Keys.Down) k = 1;
            if (dataManager != null && k != 0)
            {
                if (SyncPosition)
                    dataManager.Position = dataManager.Position + k;
                else
                    SelectedIndex = SelectedIndex + k;
                e.Handled = true;
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (ReadOnly)
            {
                base.OnKeyUp(e);
                return;
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                doOnTextChangedDelBackKey = false;

            }
            base.OnKeyUp(e);
        }

        private bool isInOnTextChanged = false;
        private bool doOnTextChangedDelBackKey = false;

        protected override void OnTextChanged(EventArgs e)
        {
            if (IsInPositionChanged || isInSetSelectedIndex || isInOnTextChanged)
            {
                base.OnTextChanged(e);
                return;
            }

            isInOnTextChanged = true;

            string sTypedText = Text;
            int iFoundIndex;

            if (doOnTextChangedDelBackKey)
            {
                doOnTextChangedDelBackKey = false;
                iFoundIndex = FindStringExact(sTypedText);
            }
            else
            {
                iFoundIndex = FindString(sTypedText);
            }
            if (iFoundIndex >= 0 && !Text.IsNOE())
            {
                string sFoundText = GetDisplayText(iFoundIndex);
                string sAppendText = sFoundText.Substring(sTypedText.Length);
                AppendText(sAppendText);
                SelectedIndex = iFoundIndex;
                SelectionStart = sTypedText.Length;
                SelectionLength = sAppendText.Length;
            }
            else
            {
                SelectedIndex = -1;
            }

            isInOnTextChanged = false;
         
            base.OnTextChanged(e);
        }

        public event RowSelectedEventHandler RowSelectedEvent;
        protected void OnRowSelectedEvent(int rownr, string value)
        {
            if (RowSelectedEvent != null)
                RowSelectedEvent(this, new RowSelectedEventArgs(rownr, value));
        }
    }


}
