using System.ComponentModel;
using System.Windows.Forms;
using KlonsLIB.Forms;
using System.Drawing;
using System;

namespace KlonsA.Classes
{
    public class MyFormBaseA : MyFormBase
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static KlonsData MyData => KlonsData.St;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Form_Main MyMainForm { get { return Form_Main.MyInstance as Form_Main; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool IsLoading = false;

        static MyFormBaseA()
        {
            var st = KlonsData.St;
        }
        
        public MyFormBaseA()
        {
            IsLoading = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            //if (this.DesignMode) KlonsData.ResetInstance();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if(IsMdiChild)
                WindowState = FormWindowState.Maximized;
            IsLoading = false;

            MyData.CollectedRefs.Add(new WeakReference(this));
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
