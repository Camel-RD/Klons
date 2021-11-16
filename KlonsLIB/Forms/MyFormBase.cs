using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KlonsLIB.Data;
using KlonsLIB.Misc;

namespace KlonsLIB.Forms
{
    public class MyFormBase : Form
    {
        private Control[][] controlsUpDownOrder = null;
        private ToolStrip myToolStrip = null;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool DialogCanceled { get; set; } = false;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string SelectedValue { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedValueInt { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action<string> OnSelectedValue;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action<int> OnSelectedValueInt;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual IKlonsSettings Settings
        {
            get
            {
                if (MyData.Settings == null)
                    throw new Exception("Setting not set.");
                return MyData.Settings;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static MyMainFormBase MyMainForm { protected set; get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMyDialog
        {
            get { return isMyDialog; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsFormClosing { get; private set; }

        public MyFormBase()
        {
            IsFormClosing = false;
            CloseOnEscape = false;
        }
        static MyFormBase()
        {
            MyMainForm = null;
        }

        private bool isMyDialog = false;

        private bool OnSelectedValueCalled = false;

        protected void SetSelectedValue(string value, bool cancel = false)
        {
            if (!this.Validate()) return;

            DialogCanceled = cancel;
            SelectedValue = value;
            if (Modal || IsMyDialog)
            {
                if (OnSelectedValue != null) OnSelectedValue(value);
                OnSelectedValueCalled = true;
            }
            if (Modal)
            {
                DialogResult = value == null ? DialogResult.Cancel : DialogResult.OK;
            }
            else if (IsMyDialog)
            {
                Close();
            }
        }

        protected void SetSelectedValue(int value, bool cancel = false)
        {
            if (!this.Validate()) return;

            DialogCanceled = cancel;
            SelectedValueInt = value;
            SelectedValue = value.ToString();

            if (Modal || IsMyDialog)
            {
                if (OnSelectedValueInt != null) OnSelectedValueInt(SelectedValueInt);
                if (OnSelectedValue != null) OnSelectedValue(SelectedValue);
                OnSelectedValueCalled = true;
            }
            if (Modal)
            {
                DialogResult = cancel ? DialogResult.Cancel : DialogResult.OK;
            }
            else if (IsMyDialog)
            {
                Close();
            }
        }

        public void ShowMyDialog()
        {
            isMyDialog = true;
            this.Show();
        }

        public DialogResult ShowMyDialogModal()
        {
            isMyDialog = true;
            return this.ShowDialog(MyMainForm);
        }

        public void SetControlsUpDownOrder(Control[][] cs)
        {
            controlsUpDownOrder = cs;
        }

        [DefaultValue(null)]
        [TypeConverter(typeof(ReferenceConverter))]
        public virtual ToolStrip MyToolStrip
        {
            get { return myToolStrip; }
            set
            {
                if (value == myToolStrip) return;
                myToolStrip = value;
                if (myToolStrip != null && MyMainForm != null &&
                    MyMainForm.MainMenuStrip != null)
                {
                    myToolStrip.Renderer = MyMainForm.MainMenuStrip.Renderer;
                }
            }
        }

        public virtual void SaveParams()
        {

        }
        public virtual bool SaveData()
        {
            return true;
        }

        public void CheckMyFontAndColors()
        {
            this.Font = Settings.FormFont;
            foreach (Control c in this.Controls)
            {
                if (c is ToolStrip || c is MenuStrip)
                {
                    c.Font = this.Font;
                    foreach (var ti in (c as ToolStrip).Items)
                    {
                        if (ti is ToolStripComboBox)
                            (ti as ToolStripComboBox).Font = this.Font;
                    }
                }
                else
                {
                    if (!c.Font.Equals(this.Font))
                    {
                        c.Font = new Font(
                            this.Font.FontFamily,
                            this.Font.SizeInPoints,
                            c.Font.Style);
                    }
                }
            }
            MyColorTheme cth = Settings.ColorTheme;
            ColorThemeHelper.ApplyToForm(this, cth);
        }

        protected virtual void CheckMyFontSize()
        {
            if (this.Font.Size != Settings.FormFontSize)
                this.Font = new Font(this.Font.Name, Settings.FormFontSize, this.Font.Style);
        }
        protected void SetFontSize(int sz)
        {
            if (this.Font.Size != sz)
                this.Font = new Font(this.Font.Name, sz, this.Font.Style);
        }

        protected void SetColorTheme(MyColorTheme theme)
        {
            ColorThemeHelper.ApplyToForm(this, theme);
        }

        protected override void OnActivated(EventArgs e)
        {
            this.SetDGVShowCellToolTips(true);
            if (this.IsMdiContainer && this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.SetDGVShowCellToolTips(true);
                /*
                foreach (var f in MdiChildren)
                {
                    f.SetDGVShowCellToolTips(true);
                }*/
            }
            base.OnActivated(e);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            this.SetDGVShowCellToolTips(false);
            if (this.IsMdiContainer && this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.SetDGVShowCellToolTips(false);
                /*
                foreach (var f in MdiChildren)
                {
                    f.SetDGVShowCellToolTips(false);
                }*/
            }
            base.OnDeactivate(e);
        }

        protected bool GetPosInMoveSeq(Control control, out int r, out int c)
        {
            r = -1;
            c = -1;

            if (controlsUpDownOrder == null) return false;

            for (int i = 0; i < controlsUpDownOrder.Length; i++)
            {
                for (int j = 0; j < controlsUpDownOrder[i].Length; j++)
                {
                    if (controlsUpDownOrder[i][j] == control)
                    {
                        r = i;
                        c = j;
                        return true;
                    }
                }
            }
            return false;
        }

        protected Control GetControlInRow(int row, int col)
        {
            Control c = controlsUpDownOrder[row][col];
            if (c != null) return c;
            int c1 = col, c2 = col;
            do
            {
                if (c1 < 0 && c2 >= controlsUpDownOrder[row].Length)
                    return null;
                if (c1 >= 0 && controlsUpDownOrder[row][c1] != null)
                    return controlsUpDownOrder[row][c1];
                if (c2 < controlsUpDownOrder[row].Length &&
                    controlsUpDownOrder[row][c2] != null)
                    return controlsUpDownOrder[row][c2];
                c1--;
                c2++;
            } while (true);
        }

        protected Control GetUpControl(Control control)
        {
            int r, c;
            if (!GetPosInMoveSeq(control, out r, out c)) return null;
            if (r == 0) return GetNextControl(control, false);
            return GetControlInRow(r - 1, c);
        }

        protected Control GetDownControl(Control control)
        {
            int r, c;
            if (!GetPosInMoveSeq(control, out r, out c)) return null;
            if (r == controlsUpDownOrder.Length - 1) return GetNextControl(control, true);
            return GetControlInRow(r + 1, c);
        }

        protected bool CanGoRight(Control c)
        {
            if (c == null) return false;
            TextBox tb = c as TextBox;
            if (tb != null)
            {
                return tb.SelectionStart + tb.SelectionLength == tb.TextLength;
            }
            ComboBox cb = c as ComboBox;
            if (cb != null)
            {
                return cb.SelectionStart + cb.SelectionLength == cb.Text.Length;
            }
            return true;
        }
        protected bool CanGoLeft(Control c)
        {
            if (c == null) return false;
            TextBox tb = c as TextBox;
            if (tb != null)
            {
                return tb.SelectionStart + tb.SelectionLength == 0;
            }
            ComboBox cb = c as ComboBox;
            if (cb != null)
            {
                return cb.SelectionStart + cb.SelectionLength == 0;
            }
            return true;
        }
        protected bool CanGoUpOrDown(Control c)
        {
            if (c == null) return false;
            TextBox tb = c as TextBox;
            if (tb != null) return true;
            ComboBox cb = c as ComboBox;
            if (cb != null)
            {
                return !cb.DroppedDown;
            }
            return true;
        }

        protected bool GoLeft(Control control)
        {
            if (control == null) return false;
            if (!CanGoLeft(control)) return false;
            SelectNextControl(control, false, true, true, true);
            return true;
        }

        protected bool GoRight(Control control)
        {
            if (control == null) return false;
            if (!CanGoRight(control)) return false;
            SelectNextControl(control, true, true, true, true);
            return true;
        }
        protected bool GoUp(Control control)
        {
            if (control == null) return false;
            if (!CanGoUpOrDown(control)) return false;
            Control c = GetUpControl(control);
            if (c == null) return false;
            c.Select();
            return true;
        }
        protected bool GoDown(Control control)
        {
            if (control == null) return false;
            if (!CanGoUpOrDown(control)) return false;
            Control c = GetDownControl(control);
            if (c == null) return false;
            c.Select();
            return true;
        }

        protected bool OnNaviKey(object sender, KeyEventArgs e)
        {
            Control control = sender as Control;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    e.Handled = GoLeft(control);
                    break;
                case Keys.Right:
                    e.Handled = GoRight(control);
                    break;
                case Keys.Up:
                    e.Handled = GoUp(control);
                    break;
                case Keys.Down:
                    e.Handled = GoDown(control);
                    break;
            }
            return e.Handled;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            IsFormClosing = true;
            try
            {
                SaveParams();
            }
            catch (Exception) { }

            try
            {
                base.OnFormClosing(e);
                if (e.Cancel)
                {
                    IsFormClosing = false;
                    return;
                }
                if (!SaveData())
                {
                    var s = String.Format("Logs [{0}] tiks aizvērt, bet\niespējams, ka datos bija kļūda.", this.Text);
                    MyMainForm.ShowWarning(s);
                    return;
                }

                if (Modal || IsMyDialog)
                {
                    if (OnSelectedValue != null && !OnSelectedValueCalled) OnSelectedValue(null);
                    //if (OnSelectedValueInt != null && !OnSelectedValueCalled) OnSelectedValueInt(null);
                    OnSelectedValueCalled = true;
                }
            }
            finally
            {
                if (e.Cancel == true)
                    IsFormClosing = false;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (this.IsMdiChild && this.MdiParent != null)
            {
                var fm = MdiParent as MyMainFormBase;
                if (fm != null) fm.OnMyCloseForm(this);
            }
        }

        [Category("Behavior")]
        [DefaultValue(false)]
        public bool CloseOnEscape { get; set; }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Tab)) return true;
            if (keyData == (Keys.Control | Keys.F6)) return true;
            if (keyData == (Keys.Control | Keys.Shift | Keys.F6)) return true;
            if (keyData == Keys.Escape && CloseOnEscape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public static float DPIFactor { private set; get; } = -1.0f;
        private SizeF scaleFactor = new SizeF(1.0f, 1.0f);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SizeF ScaleFactor => scaleFactor;
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            scaleFactor = factor;
            if (DPIFactor == -1.0f)
            {
                Graphics g = CreateGraphics();
                DPIFactor = g.DpiX / 125f;
            }
            base.ScaleControl(factor, specified);
            ScaleControlA(this.Controls.Cast<Control>());
        }
        
        protected void ScaleControlA(IEnumerable<Control> cs)
        {
            foreach (Control c in cs)
            {
                if (c is ToolStrip && !(c is MenuStrip))
                {
                    ScaleToolStrip(c as ToolStrip);
                }
                else
                {
                    ScaleControlA(c.Controls.Cast<Control>());
                }
            }
        }

        protected void ScaleToolStrip(ToolStrip tsp)
        {
            if (DPIFactor != -1.0f)
            {
                var imgsz = tsp.ImageScalingSize;
                imgsz.Width = (int)((float)imgsz.Width * ScaleFactor.Width);
                imgsz.Height = (int)((float)imgsz.Height * ScaleFactor.Height);
                tsp.ImageScalingSize = imgsz;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MyFormBase
            // 
            this.ClientSize = new System.Drawing.Size(292, 264);
            this.Name = "MyFormBase";
            this.ShowIcon = false;
            this.ResumeLayout(false);

        }
    }
}
