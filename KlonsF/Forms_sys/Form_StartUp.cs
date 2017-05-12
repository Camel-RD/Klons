using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsF.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using KlonsF.UI;

namespace KlonsF.Forms
{
    public partial class Form_StartUp : MyFormBaseF
    {
        public Form_StartUp()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void FormStartUp_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        void ShowData()
        {
            lbNane.Text = MyData.Settings.MasterEntry.Name;
            lbDescr.Text = MyData.Settings.MasterEntry.Descr;
            lbFile.Text = MyData.Settings.MasterEntry.FileName;
            tbUser.Text = MyData.Settings.LastUserName;
        }

        private void cmExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool CheckUser()
        {
            if (MyData.Settings.MasterEntry.Name == "")
            {
                MyMainForm.ShowWarning("Jāizvēlas pieslēdzamā datubāze!", "");
                return false;
            }
            if (tbUser.Text == "")
            {
                MyMainForm.ShowWarning("Jāievada lietotāja vārds!", "");
                return false;
            }
            if (MyData.CurrentDBTag == null || 
                !MyData.CurrentDBTag.Equals(MyData.Settings.MasterEntry))
            {
                if (!MyData.ConnectTo(MyData.Settings.MasterEntry, tbUser.Text, null))
                {
                    return false;
                }
                MyData.SetUpTableManagerForUsersTable();
            }

            if (!MyData.TestUserPassword(tbUser.Text, tbPSW.Text))
            {
                MyMainForm.ShowWarning("Nepareizs lietotāja vārds vai parole", "");
                return false;
            }
            return true;
        }

        private void cmConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckUser()) return;

                MyData.SetCurrentUserName(tbUser.Text);
                MyData.SetUpTableManager();
                MyData.FillParamsForUser(tbUser.Text);

                var v = MyData.Params.Version;

                if (!UpgradeHelper.CanUseVeriom(v, MyData.Version))
                {
                    MyMainForm.ShowError("Programmas versija nav savietojama ar datu bāzes versiju.");
                    return;
                }

                if (UpgradeHelper.HasUpgrade(v, MyData.Version))
                {
                    var ret = MyMessageBox.Show(
                        "Nepieciešams veikt datu bāzes versijas aktualizāciju.\n" +
                        "Pirms to darīt, ieteicams aizvērt programmu un\n" +
                        "izveidot datu rezerves kopiju.\n\n" +
                        "Vai sākt datu bāzes aktualizāciju?"
                        , "Jauna versija!", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2,
                        MyMainForm);
                    
                    if(ret == DialogResult.No) return;

                    if (!UpgradeHelper.UpgradeThis(v, MyData.Version))
                    {
                        DialogResult = DialogResult.Cancel;
                    }
                }


                MyData.FillBaseTables();
                MyData.Settings.LastUserName = tbUser.Text;
                
                MyMainForm.Text = "Klons.Net: " + MyData.Settings.MasterEntry.Descr.Nz();

                DialogResult = DialogResult.OK;
                return;

            }
            catch (Exception ex)
            {
                MyException e1 = new MyException("Neizdevās pieslēgt datubāzi.", ex);
                Form_Error.ShowException(this, e1);
                DialogResult = DialogResult.Abort;
                return;
            }
        }

        private void cmChange_Click(object sender, EventArgs e)
        {
            Form_Files ff = new Form_Files();
            if (ff.ShowDialog() != DialogResult.OK) return;
            ShowData();
        }

        private void cmUsers_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckUser()) return;
                string tp = MyData.GetUserGroup(tbUser.Text);
                if (string.IsNullOrEmpty(tp)) return;
                if (tp == "A")
                {
                    MyMainForm.ShowFormUsersDialog();
                }
                else if (tp == "B")
                {
                    Form_UserPSW f1 = new Form_UserPSW();
                    f1.SelectedValue = tbPSW.Text;
                    if (f1.ShowDialog(this) == DialogResult.OK)
                    {
                        MyData.ChangeUserPassword(tbUser.Text, f1.SelectedValue);
                    }
                }
            }
            catch (Exception ex)
            {
                MyException e1 = new MyException("Neizdevās pieslēgt datubāzi.", ex);
                Form_Error.ShowException(this, e1);
                return;
            }

        }
    }
}
