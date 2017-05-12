using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsLIB.Forms;

namespace KlonsA.Forms
{
    public partial class Form_Files : MyFormBaseA
    {
        public Form_Files()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void FormFiles_Load(object sender, EventArgs e)
        {
            bsFiles.DataSource = MyData.MasterList.ConnectionList;
        }

        private bool DoIt()
        {
            if (dgvFiles.CurrentRow == null) return false;
            int k = dgvFiles.CurrentRow.Index;
            if (k == -1 || k == dgvFiles.NewRowIndex) return false;
            MasterEntry me = dgvFiles.CurrentRow.DataBoundItem as MasterEntry;

            MyData.Settings.MasterEntry = me;
            return true;
        }

        private void DeleteSelected()
        {
            if (dgvFiles.CurrentRow == null) return;
            int k = dgvFiles.CurrentRow.Index;
            if (k == -1 || k == dgvFiles.NewRowIndex) return;
            MasterEntry me = dgvFiles.CurrentRow.DataBoundItem as MasterEntry;
            if (MessageBox.Show("Dzēsīsim datubāzes ierakstu [" + me.Name + "]",
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (MyData.Settings.MasterEntry.Name == me.Name)
            {
                MyData.Settings.MasterEntry = null;
            }
            bsFiles.RemoveCurrent();
            MyData.SaveMasterList();
            return;
        }

        private void cmSelect_Click(object sender, EventArgs e)
        {
            if (DoIt())
                DialogResult = DialogResult.OK;
        }

        private void cmEditList_Click(object sender, EventArgs e)
        {
            Form_FilesList f = new Form_FilesList();
            f.ShowDialog(this);
        }

        private void cmNew_Click(object sender, EventArgs e)
        {
            Form_FilesNew f = new Form_FilesNew();
            f.ShowDialog(this);
        }

        private void dgvFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DoIt())
                DialogResult = DialogResult.OK;
        }

        private void cmDelete_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }
    }
}
