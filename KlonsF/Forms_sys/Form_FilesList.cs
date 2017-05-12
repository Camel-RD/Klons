using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsF.UI;
using KlonsF.Classes;

namespace KlonsF.Forms
{
    public partial class Form_FilesList : MyFormBaseF
    {
        public Form_FilesList()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void FormFiles2_Load(object sender, EventArgs e)
        {
            dgcFilesConnStr.ItemStrings = MyData.MasterList.GetTemplateNames();
            bsFiles.DataSource = MyData.MasterList.ConnectionList;
        }

        private void dgvFiles_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvFiles.DataSource == null ||
                dgvFiles.NewRowIndex == e.RowIndex ||
                !dgvFiles.IsCurrentRowDirty)
            {
                return;
            }

            MasterEntry me = dgvFiles.GetDataItem(e.RowIndex) as MasterEntry;
            if (me == null) return;

            string s = me.Name;
            if (string.IsNullOrEmpty(s))
            {
                dgvFiles.Rows[e.RowIndex].ErrorText = "Nepareizs kods";
                e.Cancel = true;
                return;
            }
            for (int i = 0; i < dgvFiles.Rows.Count - 1; i++)
            {
                if (i == e.RowIndex) continue;
                if ((dgvFiles.Rows[i].DataBoundItem as MasterEntry).Name == s)
                {
                    dgvFiles.Rows[e.RowIndex].ErrorText = "Nepareizs kods";
                    e.Cancel = true;
                    return;
                }
            }
            if (string.IsNullOrEmpty(me.ConnStr) ||
                string.IsNullOrEmpty(me.FileName))
            {
                dgvFiles.Rows[e.RowIndex].ErrorText = "Jāaizpilda lauki pieslēgums un fails.";
                e.Cancel = true;
                return;
            }
            dgvFiles.Rows[e.RowIndex].ErrorText = null;
        }

        private void FormFiles2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.SaveMasterList();
        }

        private void dgvFiles_MyCheckForChanges(object sender, EventArgs e)
        {

        }
    }
}
