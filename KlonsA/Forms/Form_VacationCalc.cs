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
using Microsoft.Reporting.WinForms;

namespace KlonsA.Forms
{
    public partial class Form_VacationCalc : MyFormBaseA
    {
        public Form_VacationCalc()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private VacationCalcInfo VacationCalcInfo = null;
        private string Person = null;
        private string Period = null;

        private void Form_VacationCalc_Load(object sender, EventArgs e)
        {
            lbTitle.Font = new Font(this.Font, lbTitle.Font.Style);
        }

        public static void Show(VacationCalcInfo vc, string person, string period)
        {
            var fm = new Form_VacationCalc();
            fm.VacationCalcInfo = vc;
            fm.Person = person;
            fm.Period = period;
            fm.dgvSar.AutoGenerateColumns = false;
            fm.dgvSar.DataSource = vc.Rows;
            fm.tbRateHour.Text = vc.AvPayRateHour.ToString("N4");
            fm.tbRateDay.Text = vc.AvPayRateDay.ToString("N4");
            fm.tbRateCalDay.Text = vc.AvPayRateCalendarDay.ToString("N4");
            fm.lbTitle.Text = string.Format("Darbinieks: {0}, periods: {1}", person, period);
            fm.ShowDialog(fm.MyMainForm);
        }

    }
}
