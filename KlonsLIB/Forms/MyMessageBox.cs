using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsLIB.Data;
using KlonsLIB.Misc;

namespace KlonsLIB.Forms
{
    public partial class MyMessageBox : MyFormBase
    {
        public MyMessageBox()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            //Font = new Font(SystemFonts.MessageBoxFont.FontFamily, 12, SystemFonts.MessageBoxFont.Style);
            //BackColor = Color.DarkGray;
            //ForeColor = Color.White;
        }

        public string Message
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public static DialogResult Show(string message, string title = "",
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.None, 
            MessageBoxDefaultButton? defaultbutton = null,
            Form owner = null)
        {
            var fmb = new MyMessageBox();
            fmb.Message = message;
            fmb.Text = title;
            fmb.MbButtons = buttons;
            fmb.MbIcon = icon;
            if(defaultbutton != null)
            {
                fmb.DefaultButton = defaultbutton.Value;
            }
            var ret = fmb.ShowDialog(owner);
            return ret;
        }

        /*
        public static DialogResult Show(string message, string title = "", 
            MessageBoxButtons buttons = MessageBoxButtons.OK, 
            MessageBoxIcon icon = MessageBoxIcon.None, Form owner = null)
        {
            return Show(message, title, buttons, icon, null, owner);
        }*/

        private MessageBoxIcon mbIcon = MessageBoxIcon.None;
        private MessageBoxButtons mbButtons = MessageBoxButtons.OK;

        public MessageBoxIcon MbIcon
        {
            get { return mbIcon; }
            set
            {
                mbIcon = value;
                var ic = GetIcon(mbIcon);
                if (ic == null)
                {
                    pbIcon.Visible = false;
                    return;
                }
                pbIcon.Image = ic.ToBitmap();
            }
        }

        public MessageBoxButtons MbButtons
        {
            get { return mbButtons; }
            set { InitButtons(value); }
        }

        public MessageBoxDefaultButton DefaultButton
        {
            set
            {
                switch (value)
                {
                    case MessageBoxDefaultButton.Button1:
                        button1.Select();
                        break;
                    case MessageBoxDefaultButton.Button2:
                        button2.Select();
                        break;
                    case MessageBoxDefaultButton.Button3:
                        button3.Select();
                        break;
                }
            }
        }

        private Icon GetIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.None:
                    return null;
                case MessageBoxIcon.Asterisk:
                    return SystemIcons.Asterisk;
                case MessageBoxIcon.Exclamation:
                    return SystemIcons.Exclamation;
                case MessageBoxIcon.Error:
                    return SystemIcons.Error;
                case MessageBoxIcon.Question:
                    return SystemIcons.Question;
            }
            return null;
        }

        private void InitButtons(MessageBoxButtons bt)
        {
            mbButtons = bt;
            switch (bt)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    SetButtonsDialogResult(DialogResult.Cancel, DialogResult.Retry, DialogResult.Ignore);
                    SetButtons("Atcelt", "Mēģināt vēlreiz", "Igneorēt");
                    break;
                case MessageBoxButtons.OK:
                    SetButtonsDialogResult(DialogResult.OK);
                    SetButtons("OK");
                    break;
                case MessageBoxButtons.OKCancel:
                    SetButtonsDialogResult(DialogResult.OK, DialogResult.Cancel);
                    SetButtons("OK", "Atcelt");
                    break;
                case MessageBoxButtons.RetryCancel:
                    SetButtonsDialogResult(DialogResult.Retry, DialogResult.Cancel);
                    SetButtons("Mēģināt vēlreiz", "Atcelt");
                    break;
                case MessageBoxButtons.YesNo:
                    SetButtonsDialogResult(DialogResult.Yes, DialogResult.No);
                    SetButtons("Jā", "Nē");
                    break;
                case MessageBoxButtons.YesNoCancel:
                    SetButtonsDialogResult(DialogResult.Yes, DialogResult.No, DialogResult.Cancel);
                    SetButtons("Jā", "Nē", "Atcelt");
                    break;
            }

        }

        public void SetButtonsDialogResult(DialogResult dr1, DialogResult dr2 = DialogResult.None, DialogResult dr3 = DialogResult.None)
        {
            button1.DialogResult = dr1;
            button2.DialogResult = dr2;
            button3.DialogResult = dr3;
            if (dr1 == DialogResult.Cancel) this.CancelButton = button1;
            if (dr2 == DialogResult.Cancel) this.CancelButton = button2;
            if (dr3 == DialogResult.Cancel) this.CancelButton = button3;
            if (this.CancelButton == null)
            {
                if (dr1 == DialogResult.No) this.CancelButton = button1;
                if (dr2 == DialogResult.No) this.CancelButton = button2;
                if (dr3 == DialogResult.No) this.CancelButton = button3;
            }
            if (this.CancelButton == null)
            {
                if (dr1 == DialogResult.OK &&
                    dr2 == DialogResult.None &&
                    dr3 == DialogResult.None) this.CancelButton = button1;
            }

        }

        public void SetButtons(string s1, string s2 = null, string s3 = null)
        {
            button1.Text = s1;

            if (string.IsNullOrEmpty(s2)) button2.Visible = false;
            else button2.Text = s2;

            if (string.IsNullOrEmpty(s3)) button3.Visible = false;
            else button3.Text = s3;
        }


    }
}
