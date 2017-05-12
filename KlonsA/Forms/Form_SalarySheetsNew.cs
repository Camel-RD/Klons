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
    public partial class Form_SalarySheetsNew : MyFormBaseA
    {
        public Form_SalarySheetsNew()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public bool MakeAll = false;
        public bool MakeEmpty = false;
        public bool IsTemp = false;
        public int IdSh = 0;
        public DateTime DT2;
        public int Year = 2014;
        public int Month = 1;
        public string IdDepartment = null;
        public string Descr = null;

        private void Form_SalarySheetsNew_Load(object sender, EventArgs e)
        {
            var dt1 = DateTime.Today.AddMonths(-1);

            string[] syr = new string[DataLoader.LoadedDT2.Year - DataLoader.LoadedDT1.Year + 1];

            for (int i = 0; i < syr.Length; i++)
                syr[i] = (DataLoader.LoadedDT1.Year + i).ToString();

            cbYr.ItemStrings = syr;

            if (DataLoader.LoadedDT1.Year <= dt1.Year && DataLoader.LoadedDT2.Year >= dt1.Year)
                cbYr.Text = dt1.Year.ToString();
            else
                cbYr.Text = DataLoader.LoadedDT2.Year.ToString();

            cbMt.SelectedIndex = dt1.Month - 1;
            lbCM.SelectedIndex = 0;

            chFull.Checked = true;
        }

        public string Check(bool idsneeded)
        {
            if (string.IsNullOrEmpty(tbDate.Text))
                return "Nav norādīts datums.";

            if (string.IsNullOrEmpty(cbYr.Text) || !int.TryParse(cbYr.Text, out Year)
                || Year < 2000 || Year > 2100)
                return "Jānorāda korekts gads.";

            if (string.IsNullOrEmpty(cbMt.Text) || !int.TryParse(cbMt.Text, out Month)
                || Month < 1 || Month > 12)
                return "Jānorāda korekts mēmesis.";

            if (!DataLoader.IsMonthLoaded(Year, Month))
                return "Norādītajam gadam un mēnesim nav atlasīti dati.";

            int day = 1;
            if (!int.TryParse(tbDate.Text, out day) || day < 1 || day > 31)
                return "Nekorekts datums";

            DT2 = new DateTime(Year, Month, day);

            if (DT2 < DataLoader.LoadedDT1 || DT2 > DataLoader.LoadedDT2)
                return "Norādītajam datumam nav ielādēti dati.";

            IsTemp = chTemp.Checked;

            if (!IsTemp && day != DT2.LastDayOfMonth().Day)
                return "Nekorekts datums mēneša aprēķinam.";

            if (IsTemp && day == DT2.LastDayOfMonth().Day)
                return "Nekorekts datums starpaprēķinam.";

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

        private void CheckDay()
        {
            int yr = 0;
            int mt = 0;
            if (string.IsNullOrEmpty(cbYr.Text) || !int.TryParse(cbYr.Text, out yr)
                || yr < 2000 || yr > 2100 ||
                string.IsNullOrEmpty(cbMt.Text) || !int.TryParse(cbMt.Text, out mt)
                || mt < 1 || mt > 12)
            {
                tbDate.Text = "1";
                return;
            }
            tbDate.Text = (new DateTime(yr, mt, 1)).LastDayOfMonth().Day.ToString();
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

        private void chFull_CheckedChanged(object sender, EventArgs e)
        {
            chTemp.Checked = !chFull.Checked;
        }

        private void chTemp_CheckedChanged(object sender, EventArgs e)
        {
            chFull.Checked = !chTemp.Checked;
        }

        private void cbYr_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDay();
        }

        private void cbMt_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDay();
        }

        private void lbCM_DoubleClick(object sender, EventArgs e)
        {
            DoIt();
        }

        private void cmOK_Click(object sender, EventArgs e)
        {
            DoIt();
        }

        public void GetTemplIDFromDialog()
        {
            var fm = new Form_SalarySheetTempl();
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
