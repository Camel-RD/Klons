using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.UI;

namespace KlonsFM.Forms
{
    public partial class Form_UserPSW : MyFormBaseF
    {
        public Form_UserPSW()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public override string SelectedValue
        {
            get
            {
                return base.SelectedValue;
            }
            set
            {
                base.SelectedValue = value;
                myTextBox1.Text = value;
            }
        }

        private void myTextBox1_Leave(object sender, EventArgs e)
        {
            SelectedValue = myTextBox1.Text;
        }

        private void cmOK_Click(object sender, EventArgs e)
        {

        }

    }
}
