using System;
using System.Windows.Forms;

namespace KlonsLIB.Forms
{
    public partial class Form_InputBox : MyFormBase
    {
        public Form_InputBox()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public Form_InputBox(string title, string text, string value)
        {
            InitializeComponent();
            CheckMyFontAndColors();
            this.Text = title;
            label1.Text = text;
            tbInput.Text = value;
        }

        private void OnOK()
        {
            SelectedValue = tbInput.Text;
            DialogResult = DialogResult.OK;
        }

        private void cmOK_Click(object sender, EventArgs e)
        {
            OnOK();
        }

        private void Form_InputBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }

        private void Form_InputBox_Load(object sender, EventArgs e)
        {
            tbInput.Top = label1.Bottom + 5;
            cmOK.Top = tbInput.Bottom + 10;
            cmCancel.Top = cmOK.Top;
            var s = this.ClientSize;
            s.Height = cmOK.Bottom + 10;
            this.ClientSize = s;
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                OnOK();
        }
    }
}
