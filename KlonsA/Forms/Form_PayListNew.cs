using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsA.DataSets;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsA.Forms
{
    public partial class Form_PayListsNew : MyFormBaseA
    {
        public Form_PayListsNew()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public bool MakeAll = false;
        public bool MakeEmpty = false;
        public int IdSh = 0;
        public DateTime PayDate;
        public int Year = 2014;
        public int Month = 1;
        public string IdDepartment = null;
        public string Descr = null;

        private void Form_PayListsNew_Load(object sender, EventArgs e)
        {
            tbDate.Text = Utils.DateToString(DateTime.Today);
            var dt1 = DateTime.Today.AddMonths(-1);
            tbYR.Text = dt1.Year.ToString();
            tbMT.Text = dt1.Month.ToString();
            lbCM.SelectedIndex = 0;
        }

        public string Check(bool idsneeded)
        {
            if (string.IsNullOrEmpty(tbDate.Text))
                return "Nav norādīts datums.";

            if (!Utils.StringToDate(tbDate.Text, out PayDate))
                return "Nekorekts datums";

            if (PayDate < DataLoader.LoadedDT1 || PayDate > DataLoader.LoadedDT2)
                return "Norādītajam datumam nav ielādēti dati.";

            if (string.IsNullOrEmpty(tbYR.Text) || !int.TryParse(tbYR.Text, out Year)
                || Year < 2000 || Year > 2100)
                return "Jānorāda korekts gads.";

            if (string.IsNullOrEmpty(tbMT.Text) || !int.TryParse(tbMT.Text, out Month)
                || Month < 1 || Month > 12)
                return "Jānorāda korekts mēmesis.";

            if (idsneeded)
            {
                if (cbSh.SelectedValue == null)
                    return "Jānorāda sarksta sagatave";
                IdSh = (int)cbSh.SelectedValue;
            }

            IdDepartment = cbDep.SelectedValue.AsString();
            Descr = tbDescr.Text.Zn();

            return "OK";
        }

        private void DoIt()
        {
            if (lbCM.SelectedIndex == -1) return;
            string er = "OK";
            if (lbCM.SelectedIndex == 0)
            {
                MakeAll = true;
                MakeEmpty = false;
                er = Check(false);
            }
            else if (lbCM.SelectedIndex == 1)
            {
                MakeAll = false;
                MakeEmpty = false;
                er = Check(true);
            }
            else if (lbCM.SelectedIndex == 2)
            {
                MakeAll = false;
                MakeEmpty = true;
                er = Check(false);
            }
            if (er != "OK")
            {
                MyMainForm.ShowWarning(er);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void lbCM_DoubleClick(object sender, EventArgs e)
        {
            DoIt();
        }

        private void cmOK_Click(object sender, EventArgs e)
        {
            DoIt();
        }
        private void cmCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void tbDate_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDate.Text)) return;
            DateTime dt;
            if (!Utils.StringToDate(tbDate.Text, out dt)) return;
            //if (!DataLoader.IsMonthLoaded(dt.Year, dt.Month)) return;
            tbYR.Text = dt.Year.ToString();
            tbMT.Text = dt.Month.ToString();
        }

        public void GetTemplIDFromDialog()
        {
            var fm = new Form_PayListsTempl();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            cbSh.SelectedValue = fm.SelectedValueInt;
        }

        public void GetIDDepFromDialog()
        {
            var fm = new Form_Departments();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            cbDep.SelectedValue = fm.SelectedValue;
        }

        private void cmGetTempl_Click(object sender, EventArgs e)
        {
            GetTemplIDFromDialog();
        }

        private void cmGetDep_Click(object sender, EventArgs e)
        {
            GetIDDepFromDialog();
        }
    }
}
