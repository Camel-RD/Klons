using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KlonsLIB.Forms
{
    public class MyMainFormBase : MyFormBase
    {
        private bool _checkOnChildrenEvents = true;
        private List<MyFormBase> _myChildren = new List<MyFormBase>();
        private ToolStrip _myChildToolStrip = null;
        private static MyMainFormBase myInstance = null;
        private ToolStripMenuItem _windowListToolStripMenuItem = null;
        private ToolStrip _windowListToolStrip = null;

        public static MyMainFormBase MyInstance
        {
            get { return myInstance; }
        }

        public MyMainFormBase()
        {
            myInstance = this;
            MyMainForm = this;
        }

        public virtual void WireEvents()
        {
            if (_windowListToolStripMenuItem != null)
            {
                _windowListToolStripMenuItem.DropDownOpening += new EventHandler(this.logiToolStripMenuItem_DropDownOpening);
                _windowListToolStripMenuItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.logiToolStripMenuItem_DropDownItemClicked);
            }
            if (_windowListToolStrip != null)
            {
                _windowListToolStrip.ItemClicked += _windowListToolStrip_ItemClicked;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            WireEvents();
            base.OnLoad(e);
        }

        public virtual MyColorTheme MyColorTheme
        {
            get { return null; }
        }

        public void SetupMenuRenderer()
        {
            if (this.MainMenuStrip != null)
            {
                MainMenuStrip.ForeColor = Color.White;
                MainMenuStrip.Renderer = new MyToolStripRenderer(MyColorTheme);
                if (MyToolStrip != null)
                    MyToolStrip.Renderer = MainMenuStrip.Renderer;
                if (MyWindowListToolStrip != null)
                    MyWindowListToolStrip.Renderer = MainMenuStrip.Renderer;
            }
        }

        public void CheckMenuColorTheme()
        {
            if (this.MainMenuStrip != null)
            {
                var rend = MainMenuStrip.Renderer as MyToolStripRenderer;
                if (rend == null) return;
                rend.SetColorTheme(MyColorTheme);
                MainMenuStrip.Refresh();
            }
        }

        public void ChangeBackColor(Color bc)
        {
            MdiClient ctlMDI;
            foreach (Control ctl in this.Controls)
            {
                ctlMDI = ctl as MdiClient;
                if (ctlMDI != null)
                    ctlMDI.BackColor = bc;
            }
        }

        [DefaultValue(null)]
        [TypeConverter(typeof(ReferenceConverter))]
        public virtual ToolStripMenuItem MyWindowList
        {
            get { return _windowListToolStripMenuItem; }
            set
            {
                if (value == _windowListToolStripMenuItem) return;
                _windowListToolStripMenuItem = value;
            }
        }

        [DefaultValue(null)]
        [TypeConverter(typeof(ReferenceConverter))]
        public virtual ToolStrip MyWindowListToolStrip
        {
            get { return _windowListToolStrip; }
            set
            {
                if (value == _windowListToolStrip) return;
                _windowListToolStrip = value;
            }
        }


        public bool CloseAllForms()
        {
            try
            {
                var forms = _myChildren.ToArray();
                for (int i = forms.Length - 1; i >= 0; i--)
                {
                    if (!forms[i].SaveData()) return false;
                }
                for (int i = forms.Length - 1; i >= 0; i--)
                {
                    forms[i].Close();
                }
                return _myChildren.Count == 0;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public MyFormBase FindForm(Type formtype)
        {
            foreach (MyFormBase f1 in _myChildren)
            {
                if (formtype.Equals(f1.GetType())) return f1;
            }
            return null;
        }

        public MyFormBase ShowForm(Type formtype, object param = null)
        {
            if (!formtype.IsSubclassOf(typeof(MyFormBase)))
                throw new Exception("_MyFormBase expected.");

            for (int i = _myChildren.Count - 1; i >= 0; i--)
            {
                var f1 = _myChildren[i];
                if (formtype.Equals(f1.GetType()))
                {
                    if (f1.Enabled && !f1.IsMyDialog)
                    {
                        f1.Select();
                        return f1;
                    }
                    else
                        return null;
                }
                else
                {
                    if (f1.IsMyDialog) return null;
                }

            }

            MyFormBase f;
            if (param == null)
                f = Activator.CreateInstance(formtype) as MyFormBase;
            else
                f = Activator.CreateInstance(formtype, param) as MyFormBase;
            _myChildren.Add(f);
            f.MdiParent = this;
            f.Show();
            return f;
        }

        public MyFormBase ShowFormDialog(Type formtype, object param = null, object param2 = null)
        {
            if (!formtype.IsSubclassOf(typeof(MyFormBase)))
                throw new Exception("_MyFormBase expected.");

            MyFormBase f;

            if (param == null && param2 == null)
                f = Activator.CreateInstance(formtype) as MyFormBase;
            else if (param2 == null)
                f = Activator.CreateInstance(formtype, param) as MyFormBase;
            else
                f = Activator.CreateInstance(formtype, param, param2) as MyFormBase;

            _myChildren.Add(f);
            f.Tag = "modal";
            f.MdiParent = this;
            f.ShowMyDialog();
            return f;
        }

        public virtual void ShowReport(ReportViewerData rd)
        {
            try
            {
                Form_ReportViewer f = new Form_ReportViewer(rd);
                f.Show(this);
            }
            catch (Exception e)
            {
                MyException me = new MyException("Neizdevās atvērt atskaiti", e);
                Form_Error.ShowException(MyMainForm, me);
            }
        }

        protected override void OnMdiChildActivate(EventArgs e)
        {
            base.OnMdiChildActivate(e);
            FormMainBase_MdiChildActivate(this, e);
            OnMyChildrenChanged();
        }

        private void FormMainBase_MdiChildActivate(object sender, EventArgs e)
        {
            if (_myChildToolStrip != null && this.MyToolStrip != null)
            {
                ToolStripManager.RevertMerge(this.MyToolStrip, _myChildToolStrip);
                _myChildToolStrip = null;
            }
            if (ActiveMdiChild is MyFormBase)
            {
                MyFormBase f = ActiveMdiChild as MyFormBase;
                _myChildren.Remove(f);
                _myChildren.Add(f);

                if (f.IsMyDialog)
                {
                    for (int i = _myChildren.Count - 2; i >= 0; i--)
                    {
                        if (!_myChildren[i].Enabled) break;
                        //_myChildren[i].ActiveControl = null;
                        _myChildren[i].Enabled = false;
                        //_myChildren[i].Visible = false;
                    }
                }

                if (f.MyToolStrip != null && this.MyToolStrip != null)
                    ToolStripManager.Merge(f.MyToolStrip, this.MyToolStrip);
                _myChildToolStrip = f.MyToolStrip;

            }
            if(MyToolStrip != null)
                this.MyToolStrip.Visible = this.MyToolStrip.Items.Count > 0;
        }

        private void SelectLastForm()
        {
            if (_myChildren.Count == 0) return;
            _myChildren[_myChildren.Count - 1].Select();
        }

        public void OnMyCloseForm(MyFormBase form)
        {
            if (!_checkOnChildrenEvents) return;
            if (!_myChildren.Contains(form)) return;
            int k = _myChildren.IndexOf(form);
            _myChildren.RemoveAt(k);

            if (!form.IsMyDialog)
            {
                SelectLastForm();
                OnMyChildrenChanged();
                return;
            }

            for (int i = k - 1; i >= 0; i--)
            {
                _myChildren[i].Enabled = true;
                //_myChildren[i].Visible = true;
                if (_myChildren[i].IsMyDialog) break;
            }
            SelectLastForm();
            OnMyChildrenChanged();
            return;
        }

        protected void UpdateWindowListToolStrip()
        {
            if (_windowListToolStrip == null) return;
            ToolStripItem mi;
            Form f;
            string s;
            if (_windowListToolStrip.Items.Count > _myChildren.Count)
            {
                for (int i = 0; i < _windowListToolStrip.Items.Count - _myChildren.Count; i++)
                    _windowListToolStrip.Items.RemoveAt(_windowListToolStrip.Items.Count - 1);
            }
            if (_windowListToolStrip.Items.Count < _myChildren.Count)
            {
                for (int i = 0; i < _myChildren.Count - _windowListToolStrip.Items.Count; i++)
                {
                    mi = _windowListToolStrip.Items.Add("");
                    mi.DisplayStyle = ToolStripItemDisplayStyle.Text;
                }
            }
            for (int i = 0; i < _myChildren.Count; i++)
            {
                f = _myChildren[i];
                //⬜ ❏
                //s = string.Format("{0}: {1}", i, f.Text);
                s = string.Format("❏ {0}", f.Text);
                mi = _windowListToolStrip.Items[i];
                if (mi.Text != s) mi.Text = s;
                mi.Tag = i;
                if (f == ActiveMdiChild)
                    mi.Font = new Font(_windowListToolStrip.Font, FontStyle.Underline);
                else
                    mi.Font = _windowListToolStrip.Font;
            }
            ColorThemeHelper.ApplyToControlA(_windowListToolStrip, MyColorTheme);

        }

        protected void UpdateWindowListMenu()
        {
            if (_windowListToolStripMenuItem == null) return;
            _windowListToolStripMenuItem.DropDownItems.Clear();
            ToolStripMenuItem mi;
            Form f;
            string s;
            for (int i = 0; i < _myChildren.Count; i++)
            {
                f = _myChildren[i];
                s = string.Format("{0}: {1}", i, f.Text);
                mi = new ToolStripMenuItem(s);
                if (f == ActiveMdiChild)
                    mi.Checked = true;
                mi.Tag = i;
                _windowListToolStripMenuItem.DropDownItems.Add(mi);
            }
            ColorThemeHelper.ApplyToControlA(_windowListToolStripMenuItem, MyColorTheme);
        }

        protected virtual void OnMyChildrenChanged()
        {
            UpdateWindowListToolStrip();
        }

        private void logiToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            UpdateWindowListMenu();
        }

        private void logiToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int k = (int)e.ClickedItem.Tag;
            Form f = _myChildren[k];
            if (!f.Enabled) return;
            f.Activate();
        }

        private void _windowListToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int k = (int)e.ClickedItem.Tag;
            if (k >= _myChildren.Count) return;
            Form f = _myChildren[k];
            if (!f.Enabled) return;
            f.Activate();
        }

        public virtual void ShowInfo(string msg, string title = "Info", Form owner = null)
        {
            MyMessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information, null, owner);
        }
        public virtual void ShowWarning(string msg, string title = "Brīdinājums!", Form owner = null)
        {
            MyMessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning, null, owner);
        }
        public virtual void ShowError(string msg, string title = "Kļūda!", Form owner = null)
        {
            MyMessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error, null, owner);
        }
        public virtual bool AskSomething(string askwhat, Form owner = null)
        {
            if (owner == null) owner = MyMainForm;
            DialogResult response = MyMessageBox.Show(askwhat,
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2,
                owner);

            return response == DialogResult.Yes;
        }

    }
}
