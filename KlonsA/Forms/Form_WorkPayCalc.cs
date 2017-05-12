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
    public partial class Form_WorkPayCalc : MyFormBaseA
    {
        public Form_WorkPayCalc()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private WorkPayCalcTInfo WorkPayCalcInfo = null;
        private List<WorkPayCalcRow1> Rows2 = null;
        private string Person = null;
        private string Period = null;

        private void Form_WorkPayCalc_Load(object sender, EventArgs e)
        {
            lbTitle.Font = new Font(this.Font, lbTitle.Font.Style);
        }

        public static void Show(WorkPayCalcTInfo wc, string person, string period)
        {
            var fm = new Form_WorkPayCalc();
            fm.WorkPayCalcInfo = wc;
            fm.Rows2 = wc.GetRows2();
            fm.Person = person;
            fm.Period = period;
            fm.dgvSar.AutoGenerateColumns = false;
            fm.dgvSar.DataSource = fm.Rows2;
            fm.tbRateHour.Text = wc.AvPayRateHour.ToString("N4");
            fm.tbRateDay.Text = wc.AvPayRateDay.ToString("N4");
            fm.lbTitle.Text = string.Format("Darbinieks: {0}, periods: {1}", person, period);
            fm.ShowDialog(fm.MyMainForm);
        }

        private void dgvSar_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            bool b0 = e.RowIndex > 0 && Rows2[e.RowIndex - 1].IsTitle;
            bool b1 = Rows2[e.RowIndex].IsTitle;
            bool b2 = e.RowIndex < Rows2.Count - 1 && Rows2[e.RowIndex + 1].IsTitle;

            e.AdvancedBorderStyle.Bottom = b1 && b2 ?
                DataGridViewAdvancedCellBorderStyle.None :
                dgvSar.AdvancedCellBorderStyle.Bottom;

            if (e.ColumnIndex != dgcSalary.Index)
            {
                e.AdvancedBorderStyle.Right = b1 ?
                    DataGridViewAdvancedCellBorderStyle.None :
                    dgvSar.AdvancedCellBorderStyle.Right;
            }
            if (e.ColumnIndex != dgcCaption.Index)
            {
                e.AdvancedBorderStyle.Left = b1 ?
                    DataGridViewAdvancedCellBorderStyle.None :
                    dgvSar.AdvancedCellBorderStyle.Left;
            }
        }
    }
}
