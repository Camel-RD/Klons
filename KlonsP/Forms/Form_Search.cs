using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsP.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Components;
using KlonsLIB.Misc;

namespace KlonsP.Forms
{
    public partial class Form_Search : MyFormBaseP
    {
        public Form_Search()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public enum ESerchDirection
        {
            FromTop,
            Up,
            Down
        }

        private static Form_Search Instance = null;

        private Form _onForm = null;

        public Action<string, ESerchDirection> OnSearch = null;

        public static Form_Search Show(Action<string, ESerchDirection> onsearch , Form onform)
        {
            if (onsearch == null || onform == null)
                throw new ArgumentNullException();
            bool setpos = false;
            if (Instance == null)
            {
                Instance = new Form_Search();
                setpos = true;
            }
            Instance.OnSearch = onsearch;
            Instance.OnForm = onform;
            Instance.Owner = onform;
            Instance.Show();
            if (setpos && !onform.IsDisposed && onform.Visible)
            {
                var r = onform.RectangleToScreen(onform.ClientRectangle);
                int x = r.Left + r.Width / 2 - Instance.Width / 2;
                int y = r.Top + r.Height / 2 - Instance.Height / 2;
                Instance.Left = x;
                Instance.Top = y;
            }
            Instance.tbText.Select();
            return Instance;
        }

        public Form OnForm
        {
            get { return _onForm; }
            set
            {
                if (value == _onForm) return;
                if (_onForm != null)
                    _onForm.FormClosed -= OnForm_FormClosed;
                _onForm = value;
                if (_onForm == null) return;
                _onForm.FormClosed += OnForm_FormClosed;
            }
        }

        private void OnForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onForm = null;
        }

        private void Form_Search_Load(object sender, EventArgs e)
        {

        }

        private void Form_Search_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onForm = null;
            OnSearch = null;
            Instance = null;
        }

        private void DoSearch(ESerchDirection dir)
        {
            if (string.IsNullOrEmpty(tbText.Text)) return;
            if (OnSearch == null) return;
            OnSearch(tbText.Text, dir);
        }

        private void cmUp_Click(object sender, EventArgs e)
        {
            DoSearch(ESerchDirection.Up);
        }

        private void cmDown_Click(object sender, EventArgs e)
        {
            DoSearch(ESerchDirection.Down);
        }

        private void tbText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
                DoSearch(ESerchDirection.FromTop);
        }

        private void tbText_Enter(object sender, EventArgs e)
        {
            tbText.Text = "";
        }
    }
}
