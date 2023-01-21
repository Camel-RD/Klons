using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.DataSets;
using KlonsFM.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Data;
using KlonsLIB.Misc;
using KlonsFM.UI;
using KlonsLIB.Components;

namespace KlonsFM.FormsM
{
    public partial class FormM_ErrorList : MyFormBaseF
    {
        public FormM_ErrorList()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvRows.AutoGenerateColumns = false;
            SourceColumnWidth = dgcSource.Width;
            MessageColumnWidth = dgcMessage.Width;
        }

        private int SourceColumnWidth = 0;
        private int MessageColumnWidth = 0;

        private void FormM_ErrorList_Load(object sender, EventArgs e)
        {

        }

        public void SetErrorList(ErrorList errorlist)
        {
            if (errorlist == null) return;
            bsRows.DataSource = errorlist;
            dgvRows.AutoResizeRows();
            dgcSource.Visible = errorlist.HasSourceData;
            if (!dgcSource.Visible)
                dgcMessage.Width = MessageColumnWidth;
            else
                dgcMessage.Width = MessageColumnWidth + SourceColumnWidth;
        }

        public void SetMyDataErrorList()
        {
            if (MyData.ErrorInfoList == null) return;
            SetErrorList(MyData.ErrorInfoList);
        }

        public static void ShowErrorList(Form owner, ErrorList errorlist)
        {
            if (errorlist == null) return;
            var fe = new FormM_ErrorList();
            KlonsData.St.ErrorInfoList.SetErrorList(errorlist);
            fe.SetErrorList(errorlist);
            fe.ShowDialog(owner);
        }

    }
}
