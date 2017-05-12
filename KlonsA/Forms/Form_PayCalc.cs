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

namespace KlonsA.Forms
{
    public partial class Form_PayCalc : MyFormBaseA
    {
        public Form_PayCalc()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            lbName.Font = new Font(this.Font, lbName.Font.Style);
            lbPos.Font = new Font(this.Font, lbPos.Font.Style);
            lbDates1.Font = new Font(this.Font, lbDates1.Font.Style);
            lbDates2.Font = new Font(this.Font, lbDates2.Font.Style);
        }

        private void Form_PayCalc_Load(object sender, EventArgs e)
        {
            ShortTable = MyData.Params.ShortPayCalcRep;
            dgvRows.Select();
        }

        public enum EReportType { Splitpay, SalarySheetList}

        public static void Show(PayListCalcInfo ci, EReportType type)
        {
            var fm = new Form_PayCalc();
            if (type == EReportType.SalarySheetList)
            {
                fm.Text = "Izmaksātie algas aprēķini";
                fm.lbDates1.Text = "Maksājumu saraksta datums:  ";
                fm.lbDates2.Text = "Apmaksāto algas aprēķinu datumi:  ";
                fm.dgcCaption.Width += 20;
            }
            fm.lbName.Text = ci.Name;
            fm.lbPos.Text = ci.PosTitle;
            fm.lbDates1.Text += ci.Dates1;
            fm.lbDates2.Text += ci.Dates2;
            fm.dgvRows.AutoGenerateColumns = false;
            fm.bsRows.DataSource = ci.RepRows;
            fm.ShowDialog(fm.MyMainForm);
        }

        public bool ShortTable
        {
            get { return !dgcNoSai.Visible; }
            set
            {
                int si = value ? 1 : 0;
                if (cbColList.SelectedIndex != si) cbColList.SelectedIndex = si;
                if (ShortTable == value) return;
                dgcNoSai.Visible = !value;
                dgcNotpaidTaxed.Visible = !value;
                dgcNotpidNoSAI.Visible = !value;
                dgcNotpaidNotTaxed.Visible = !value;
                dgcPFLIHINT.Visible = !value;
                MyData.Params.ShortPayCalcRep = value;
            }
        }

        private void cbColList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShortTable = cbColList.SelectedIndex == 1;
        }
    }
}
