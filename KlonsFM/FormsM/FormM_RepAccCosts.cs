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
    public partial class FormM_RepAccCosts : MyFormBaseF
    {
        public FormM_RepAccCosts()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            LoadParams();
            dgvRows.AutoGenerateColumns = false;
            dgvRows.DisableAllColumnSorting();
        }

        private void FormM_RepAccCosts_Load(object sender, EventArgs e)
        {

        }

        public DateTime Date1;
        public DateTime Date2;

        private void LoadParams()
        {
            tbDT1.Text = MyData.Params.RSD;
            tbDT2.Text = MyData.Params.RED;
        }

        public override void SaveParams()
        {
            MyData.Params.RSD = tbDT1.Text;
            MyData.Params.RED = tbDT2.Text;
        }

        public string CheckParams()
        {
            if (tbDT1.Text.IsNOE() || tbDT2.Text.IsNOE())
                return "Jānorāda sākuma un beigu datums.";
            if (!Utils.StringToDate(tbDT1.Text, out Date1) ||
                !Utils.StringToDate(tbDT2.Text, out Date2))
                return "Nekorekts datuma formāts.";
            if (Date1 > Date2)
                return "Sākuma datums lielāks par beigu datumu.";
            return "OK";
        }

        public void MakeReport()
        {
            dgvRows.DataSource = null;
            var ad = new DataSets.KlonsMRepDataSetTableAdapters.SP_M_REP_COSTACCTableAdapter();
            var table = ad.GetDataBy_SP_M_REP_COSTACC_1(Date1, Date2);
            if (table.Count == 0)
            {
                MyMainForm.ShowWarning("Pārkskats ir tukšs.", null, this);
                return;
            }
            dgvRows.DataSource = table;
        }

        private void cmGetData_Click(object sender, EventArgs e)
        {
            var rt = CheckParams();
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }
            MakeReport();

        }

        private void dgvRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value) return;

            if (e.ColumnIndex == dgcTP.Index)
            {
                int idtp = (int)e.Value;
                var dr_tp = MyData.DataSetKlonsM.M_DOCTYPES.FindByID(idtp);
                if (dr_tp == null) return;
                e.Value = dr_tp.NAME;
                e.FormattingApplied = true;
                return;
            }
        }
    }
}
