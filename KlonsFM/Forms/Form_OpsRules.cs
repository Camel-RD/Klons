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
using KlonsFM.Classes;
using KlonsFM.DataSets;

namespace KlonsFM.Forms
{
    public partial class Form_OpsRules : MyFormBaseF
    {
        public Form_OpsRules()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void LoadParams()
        {
            chbNP.Checked = MyData.Params.UPRNP;

            chbIIN.Checked = MyData.Params.UPRIIN;
            chbIINien.Checked = MyData.Params.UPRIINIEN;
            chbIINizd.Checked = MyData.Params.UPRIINIZD;

            chbPVN.Checked = MyData.Params.UPRPVN;
            chbPVNien.Checked = MyData.Params.UPRPVNIEN;
            chbPVNizd.Checked = MyData.Params.UPRPVNIZD;
            chbPVNdeb.Checked = MyData.Params.UPRPVNDEB;
            chbPVNkred.Checked = MyData.Params.UPRPVNKRED;

            chbPVNreqPvn.Checked = MyData.Params.UPRPVNREQPVN;
            chbPVNreqIen.Checked = MyData.Params.UPRPVNREQIEN;
            
            chbPVN5.Checked = MyData.Params.UPRPVN5;

            cbIINien.Text = MyData.Params.UPRIINIENV;
            cbIINizd.Text = MyData.Params.UPRIINIZDV;
            cbPVNien.Text = MyData.Params.UPRPVNIENV;
            cbPVNizd.Text = MyData.Params.UPRPVNIZDV;
            cbPVNdeb.Text = MyData.Params.UPRPVNDEBV;
            cbPVNkred.Text = MyData.Params.UPRPVNKREDV;
            cbPVN5.Text = MyData.Params.UPRPVN5V;
        }
        public override void SaveParams()
        {
            MyData.Params.UPRNP = chbNP.Checked;

            MyData.Params.UPRIIN = chbIIN.Checked;
            MyData.Params.UPRIINIEN = chbIINien.Checked;
            MyData.Params.UPRIINIZD = chbIINizd.Checked;

            MyData.Params.UPRIINIENV = cbIINien.Text;
            MyData.Params.UPRIINIZDV = cbIINizd.Text;

            MyData.Params.UPRPVN = chbPVN.Checked;
            MyData.Params.UPRPVNIEN = chbPVNien.Checked;
            MyData.Params.UPRPVNIZD = chbPVNizd.Checked;

            MyData.Params.UPRPVNIENV = cbPVNien.Text;
            MyData.Params.UPRPVNIZDV = cbPVNizd.Text;

            MyData.Params.UPRPVNDEB = chbPVNdeb.Checked;
            MyData.Params.UPRPVNKRED = chbPVNkred.Checked;

            MyData.Params.UPRPVN5 = chbPVN5.Checked;

            MyData.Params.UPRPVNDEBV = cbPVNdeb.Text;
            MyData.Params.UPRPVNKREDV = cbPVNkred.Text;

            MyData.Params.UPRPVNREQPVN = chbPVNreqPvn.Checked;
            MyData.Params.UPRPVNREQIEN = chbPVNreqIen.Checked;
            
            MyData.Params.UPRPVN5 = chbPVN5.Checked;
            MyData.Params.UPRPVN5V = cbPVN5.Text;
            
        }

        private bool DoOnF5(ComboBox sender)
        {
            Action<string> act =
                value =>
                {
                    if (value != null)
                        sender.Text = value;
                };
            if (sender == cbIINien || sender == cbIINizd)
            {
                MyMainForm.ShowFormAcp3Dialog(act);
                return true;
            }

            if (sender == cbPVNien || sender == cbPVNizd ||
                sender == cbPVNdeb || sender == cbPVNkred)
            {
                MyMainForm.ShowFormAcp5Dialog(act);
                return true;
            }
            return false;
        }

        private void CheckEnabledIIN()
        {
            bool b = chbIIN.Checked;
            chbIINien.Enabled = b;
            chbIINizd.Enabled = b;
            cbIINien.Enabled = b;
            cbIINizd.Enabled = b;
        }

        private void CheckEnabledPVN()
        {
            bool b = chbPVN.Checked;
            chbPVNien.Enabled = b;
            chbPVNizd.Enabled = b;
            chbPVNdeb.Enabled = b;
            chbPVNkred.Enabled = b;
            chbPVNreqPvn.Enabled = b;
            chbPVNreqIen.Enabled = b;
            chbPVN5.Enabled = b;

            cbPVNien.Enabled = b;
            cbPVNizd.Enabled = b;
            cbPVNdeb.Enabled = b;
            cbPVNkred.Enabled = b;
        }

        private void chbIIN_CheckedChanged(object sender, EventArgs e)
        {
            bool b = chbIIN.Checked;
            chbIINien.Checked = b;
            chbIINizd.Checked = b;
            CheckEnabledIIN();
        }

        private void chbPVN_CheckedChanged(object sender, EventArgs e)
        {
            bool b = chbPVN.Checked;
            chbPVNien.Checked = b;
            chbPVNizd.Checked = b;
            chbPVNdeb.Checked = b;
            chbPVNkred.Checked = b;
            chbPVNreqPvn.Checked = b;
            chbPVNreqIen.Checked = b;
            chbPVN5.Checked = b;
            CheckEnabledPVN();
        }

        private void FormOpsRules_Load(object sender, EventArgs e)
        {
            klonsDataSet ds = MyData.DataSetKlons;
            cbIINien.DataSource = new BindingSource(ds, ds.Acp23.TableName);
            cbIINizd.DataSource = new BindingSource(ds, ds.Acp23.TableName);
            cbPVNien.DataSource = new BindingSource(ds, ds.Acp25.TableName);
            cbPVNizd.DataSource = new BindingSource(ds, ds.Acp25.TableName);
            cbPVNdeb.DataSource = new BindingSource(ds, ds.Acp25.TableName);
            cbPVNkred.DataSource = new BindingSource(ds, ds.Acp25.TableName);
            cbPVN5.DataSource = new BindingSource(ds, ds.Acp25.TableName);
            
            LoadParams();

            CheckEnabledIIN();
            CheckEnabledPVN();

            Control[][] cc = new Control[][]
            {
                new Control[] {cbIINizd},
                new Control[] {cbIINien},
                new Control[] {cbPVNien},
                new Control[] {cbPVNizd},
                new Control[] {cbPVNdeb},
                new Control[] {cbPVNkred},
                new Control[] {cbPVN5}
            };

            SetControlsUpDownOrder(cc);
            WindowState = FormWindowState.Maximized;
        }

        private void FormOpsRules_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveParams();
        }
        private void cbIIN_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MyMainForm.ShowFormAcp3Dialog(
                value =>
                {
                    if (value != null)
                        (sender as ComboBox).Text = value;
                });
        }
        private void cbPVN_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MyMainForm.ShowFormAcp5Dialog(
                value =>
                {
                    if (value != null)
                        (sender as ComboBox).Text = value;
                });
        }

        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            if (OnNaviKey(sender, e)) return;

            switch (e.KeyCode)
            {
                case Keys.F5:
                    if (sender is ComboBox)
                        if (DoOnF5(sender as ComboBox))
                        {
                            e.Handled = false;
                        }
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }

        private void cmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
