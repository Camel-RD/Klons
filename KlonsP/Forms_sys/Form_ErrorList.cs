using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsP.Classes;
using KlonsLIB.Misc;
using KlonsLIB.Forms;

namespace KlonsP.Forms
{
    public partial class Form_ErrorList : MyFormBaseP
    {
        public Form_ErrorList()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public void SetMyDataErrorList()
        {
            if (MyData.ErrorInfoList == null) return;
            dgvErrorList.AutoGenerateColumns = false;
            bsErr.DataSource = MyData.ErrorInfoList;
            dgcSource.DataPropertyName = "Source";
            dgcMessage.DataPropertyName = "Message";
        }

        public static void ShowErrorList(Form owner, ErrorList errorlist)
        {
            if (errorlist == null) return;
            var fe = new Form_ErrorList();
            fe.dgvErrorList.AutoGenerateColumns = false;
            KlonsData.St.ErrorInfoList.SetErrorList(errorlist);
            fe.bsErr.DataSource = KlonsData.St.ErrorInfoList;
            fe.dgcSource.DataPropertyName = "Source";
            fe.dgcMessage.DataPropertyName = "Message";
            fe.ShowDialog(owner);
        }


    }
}
