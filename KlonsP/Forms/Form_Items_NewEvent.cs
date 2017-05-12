using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsP.DataSets;
using KlonsP.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Components;
using KlonsLIB.Misc;

namespace KlonsP.Forms
{
    public partial class Form_Items_NewEvent : MyFormBaseP
    {
        public Form_Items_NewEvent()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public DateTime Date = DateTime.MinValue;
        public int EventId = -1;

        private void Form_Items_NewEvent_Load(object sender, EventArgs e)
        {
            tbDate.Text = Utils.DateToString(DateTime.Today);
        }

        private string Check()
        {
            if (string.IsNullOrEmpty(tbDate.Text))
                return "Jānorāda notikuma datums.";
            if (!Utils.StringToDate(tbDate.Text, out Date))
                return "Nekorekts datums.";
            if(cbEvent.SelectedValue == null)
                return "Jānorāda notikums.";
            EventId = (int)cbEvent.SelectedValue;
            return "OK";
        }

        private void DoIt()
        {
            var er = Check();
            if(er != "OK")
            {
                MyMainForm.ShowWarning(er);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void cmOK_Click(object sender, EventArgs e)
        {
            DoIt();
        }
    }
}
