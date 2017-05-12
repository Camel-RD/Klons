using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsF.Classes;
using KlonsLIB.Components;
using KlonsLIB.Forms;

namespace KlonsF.UI
{
    public class MyFormBaseF : MyFormBase
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KlonsData MyData { get { return KlonsData.St; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Form_Main MyMainForm { get { return Form_Main.MyInstance as Form_Main; } }

        [Browsable(false)]
        protected bool IsLoading = false;

        static MyFormBaseF()
        {
            var st = KlonsData.St;
        }

        public MyFormBaseF()
        {
            IsLoading = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            Icon = Properties.Resources.Icon1;
            //if (this.DesignMode) KlonsData.ResetInstance();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            IsLoading = false;
            if (MyData.Settings.InWine != "YES") return;
            foreach(var c in Controls)
            {
                if(c is MyMcComboBox)
                {
                    var cb = (c as MyMcComboBox);
                    cb.DropDownWidth = cb.DropDownWidth + 1;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                SaveData();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected virtual bool AskCanDelete()
        {
            DialogResult response = MyMessageBox.Show("Vai dzēst ierakstu?",
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2,
                MyMainForm);

            return response == DialogResult.Yes;
        }

    }

}
