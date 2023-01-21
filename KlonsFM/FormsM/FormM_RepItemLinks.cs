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
    public partial class FormM_RepItemLinks : MyFormBaseF
    {
        public FormM_RepItemLinks()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            LoadParams();
            dgvRows.AutoGenerateColumns = false;
        }

        private void FormM_RepItemLinks_Load(object sender, EventArgs e)
        {

        }

        public DateTime Date1;
        public DateTime Date2;
        public int iditem;

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
            if (tbCode.SelectedIndex == -1)
                return "Jānorāda artikuls";
            iditem = (int)tbCode.SelectedValue;
            if (!Utils.StringToDate(tbDT1.Text, out Date1) ||
                !Utils.StringToDate(tbDT2.Text, out Date2))
                return "Nekorekts datuma formāts.";
            if (Date1 > Date2)
                return "Sākuma datums lielāks par beigu datumu.";
            return "OK";
        }

        public void MakeReport()
        {
            var ad = new DataSets.KlonsMRepDataSetTableAdapters.SP_M_REP_ITEMLINKS_1TableAdapter();
            var table_rows = ad.GetData(iditem, Date1, Date2);
            dgvRows.DataSource = table_rows;
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

        private void tbCode_ButtonClicked(object sender, EventArgs e)
        {
            var iditem = FormM_Items.GetItemId(null);
            if (!iditem.HasValue) return;
            tbCode.SelectedValue = iditem.Value;
        }


        private void tbCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                tbCode.SelectedIndex = -1;
                return;
            }
        }

        private void dgvRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value) return;

            if (e.ColumnIndex == dgcAIdStoreIn.Index ||
                e.ColumnIndex == dgcAIdStoreOut.Index ||
                e.ColumnIndex == dgcBIdStoreOut.Index ||
                e.ColumnIndex == dgcBIdStoreIn.Index)
            {
                e.Value = DataTasks.GetStoreCode((int)e.Value);
                e.FormattingApplied = true;
                return;
            }
            if (e.ColumnIndex == dgcATp.Index ||
                e.ColumnIndex == dgcBTp.Index)
            {
                e.Value = MyData.DataSetKlonsM.M_DOCTYPES.FindByID((int)e.Value).CODE;
                e.FormattingApplied = true;
                return;
            }
        }


    }
}
