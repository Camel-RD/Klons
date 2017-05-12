using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsA.DataSets;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsA.Forms
{
    public partial class Form_PersonNewPos : MyFormBaseA
    {
        public Form_PersonNewPos()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public string PersonName = null;
        public string PositionTitle = null;
        public string iddep = null;

        private void Form_PersonsNewPos_Load(object sender, EventArgs e)
        {
            this.SetControlsUpDownOrder(
                new Control[][] {
                    new Control[] { tbPosition },
                    new Control[] { cbDep },
                    new Control[] { cmOK },
                    new Control[] { cmCancel }});
            tbName.Text = PersonName;
        }

        public string Check()
        {
            PositionTitle = tbPosition.Text;

            if (string.IsNullOrEmpty(PositionTitle))
                return "Jānorāda amata nosaukums.";
            if (PositionTitle.Length > 50)
                return "Amata nosaukums par garu.";

            if (cbDep.SelectedIndex == -1 || cbDep.SelectedValue == null)
                return "Nav norādīts departaments.";

            iddep = (string)cbDep.SelectedValue;

            return "OK";
        }

        private void cmOK_Click(object sender, EventArgs e)
        {
            var er = Check();
            if (er != "OK")
            {
                MyMainForm.ShowWarning(er);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            OnNaviKey(sender, e);
        }
    }
}
