using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.Classes;
using KlonsLIB.Components;
using KlonsLIB.Forms;

namespace KlonsFM.UI
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
            if (IsMdiChild)
                WindowState = FormWindowState.Maximized;
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

        public ToolStripControlHost InsertInToolStrip(ToolStrip ts, Control c, int pos)
        {
            c.MinimumSize = new Size(c.Width, c.MinimumSize.Height);
            var it = new ToolStripControlHost(c);
            it.Margin = c.Margin;
            if (pos < 0 || pos >= ts.Items.Count)
                ts.Items.Add(it);
            else
                ts.Items.Insert(pos, it);
            return it;
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

        public bool SaveBeforeProceed()
        {
            var ret = SaveData();
            if (!ret)
            {
                MyMainForm.ShowWarning("Pirms turpināt darbu, datiem jābūt saglabātiemn.");
                return false;
            }
            return true;
        }


    }

}
