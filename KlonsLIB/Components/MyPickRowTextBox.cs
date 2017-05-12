using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace KlonsLIB.Components
{
    public class MyPickRowTextBox : MyTextBox
    {

        private int selectedIndex = -1;
        private object dataSource = null;
        private string dataMember = null;
        private int columnNr = 0;

        private ListChangedEventHandler listChangedHandler;
        private EventHandler positionChangedHandler;


        public MyPickRowTextBox()
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

        [DefaultValue(0)]
        [Category("Data")]
        public int ColumnNr
        {
            get { return columnNr; }
            set { columnNr = value; }
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            this.tryDataBinding();
            base.OnBindingContextChanged(e);
        }

        private bool doChangePositionOnSelectedIndex = true;
        private bool doSelectedIndexOnChangePosition = true;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (selectedIndex == value) return;
                selectedIndex = value;
                if (dataManager != null && doChangePositionOnSelectedIndex)
                {
                    int k = selectedIndex;
                    if (k == -1) k = 0;
                    doSelectedIndexOnChangePosition = false;
                    try
                    {
                        dataManager.Position = k;
                    }
                    catch (Exception)
                    {
                    }
                    doSelectedIndexOnChangePosition = true;
                }
            }
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
                    columnNr = -1;
                }

                this.dataManager = cm;

                if (this.dataManager != null)
                {
                    this.dataManager.ListChanged += listChangedHandler;
                    this.dataManager.PositionChanged += positionChangedHandler;
                }
            }
        }

        private void dataManager_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                doChangePositionOnSelectedIndex = false;
                if (doSelectedIndexOnChangePosition)
                {
                    Text = GetText(dataManager.Position);
                    if (SelectedIndex != dataManager.Position)
                        SelectedIndex = dataManager.Position;
                }
            }
            finally
            {
                doChangePositionOnSelectedIndex = true;
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

        private int FindString(string s)
        {
            if (dataManager == null || s == null) return -1;
            int k = dataManager.List.Count;
            if (string.Compare(s, GetText(k - 1), true) == 0)
                return k - 1;
            if (dataSource is BindingSource && (dataSource as BindingSource).IsSorted)
                return FindStringSorted(s);
            return FindStringSimple(s);
        }

        private int FindStringExact(string s)
        {
            if (dataManager == null || s == null) return -1;
            int k = dataManager.List.Count;
            if (string.Compare(s, GetText(k - 1), true) == 0)
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
                s1 = GetText(i);
                if (s.Length > s1.Length) continue;
                if (string.Compare(s, s1.Substring(0,s.Length), true) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private int FindStringExactSimple(string s)
        {
            if (dataManager == null) return - 1;
            for (int i = 0; i < dataManager.List.Count; i++)
            {
                if (string.Compare(s, GetText(i), true) == 0)
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
            int k3 = (k1 + k2)/2;
            int m;
            string s1;
            while (true)
            {
                s1 = GetText(k3);
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
                    k3 = (k1 + k2)/2;

                }
                if (m > 0)
                {
                    if (k1 == k3)
                    {
                        if (k1 < mk2)
                        {
                            k3++;
                            s1 = GetText(k3);
                            if (s.Length > s1.Length) return -1;
                            s1 = s1.Substring(0, s.Length);
                            if (string.Compare(s, s1, true) == 0)
                                return k3;

                        }
                        return -1;
                    }
                    k1 = k3;
                    k3 = (k1 + k2 + 1)/2;
                }
            }
        }

        private int FindStringExactSorted(string s)
        {
            if (dataManager == null) return -1;
            if (string.IsNullOrEmpty(s)) return -1;
            int k1 = 0;
            int k2 = dataManager.List.Count-1;
            int k3 = (k1 + k2)/2;
            int m;
            while (true)
            {
                m = string.Compare(s, GetText(k3), true);
                if(m == 0) return k3;
                if (m < 0)
                {
                    if (k2 == k3) return -1;
                    k2 = k3;
                    k3 = (k1 + k2)/2;

                }
                if (m > 0)
                {
                    if (k1 == k3) return -1;
                    k1 = k3;
                    k3 = (k1 + k2 + 1)/2;

                }
            }
        }

        private string GetText(int nr)
        {
            try
            {
                string s = GetTextA(nr);
                return s == null ? "" : s;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string GetTextA(int nr)
        {
            if (dataManager == null || nr == -1 || nr >= dataManager.List.Count) return null;

            int k = columnNr == -1 ? 0 : columnNr;
            DataRowView rv = dataManager.List[nr] as DataRowView;
            if (rv == null) return null;
            return rv.Row[k].ToString();
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
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
            if (e.KeyChar == (char) Keys.Return)
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
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                doOnTextChangedDelBackKey = true;

            }

            int k = 0;
            if (e.KeyCode == Keys.Up) k = -1;
            if (e.KeyCode == Keys.Down) k = 1;
            if (dataManager != null && k != 0)
            {
                dataManager.Position = dataManager.Position + k;
                e.Handled = true;
            }

            base.OnKeyDown(e);
        }
        
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                doOnTextChangedDelBackKey = false;

            }
            base.OnKeyUp(e);
        }

        private bool doOnTextChanged = true;
        private bool doOnTextChangedDelBackKey = false;
        protected override void OnTextChanged(EventArgs e)
        {
            if (doOnTextChanged)
            {
                doOnTextChanged = false;

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
                if (iFoundIndex >= 0 && Text != "")
                {
                    string sFoundText = GetText(iFoundIndex);
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

                doOnTextChanged = true;
            }
            base.OnTextChanged(e);
        }

        public event RowSelectedEventHandler RowSelectedEvent;
        protected void OnRowSelectedEvent(int rownr, string value)
        {
            if (RowSelectedEvent != null)
                RowSelectedEvent(this, new RowSelectedEventArgs(rownr, value));
        }
    }

    public delegate void RowSelectedEventHandler(object sender, RowSelectedEventArgs e);

    public class RowSelectedEventArgs : EventArgs
    {
        public int RowNr { get; private set; }
        public string Value { get; private set; }

        public RowSelectedEventArgs(int rownr, string value)
        {
            RowNr = rownr;
            Value = value;
        }
    }

}
