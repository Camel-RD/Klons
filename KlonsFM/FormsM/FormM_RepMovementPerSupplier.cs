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
    public partial class FormM_RepMovementPerSupplier : MyFormBaseF
    {
        public FormM_RepMovementPerSupplier()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            LoadParams();
            dgvRows.AutoGenerateColumns = false;
            dgvRows.DisableAllColumnSorting();
        }

        private void FormM_RepMovementPerItem_Load(object sender, EventArgs e)
        {

        }

        public DateTime Date1;
        public DateTime Date2;
        public int? IdCat;

        List<RepRowMovementOfAmounts> RepRows = new List<RepRowMovementOfAmounts>();

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
            if (tbCode.SelectedIndex == -1)
                IdCat = null;
            else
                IdCat = (int)tbCode.SelectedValue;
            return "OK";
        }

        public void MakeReport()
        {
            dgvRows.DataSource = new List<RepRowMovementOfAmounts>();
            var ad = new DataSets.KlonsMRepDataSetTableAdapters.SP_M_REP_ITEMSAMOUNTS_4TableAdapter();
            var table = ad.GetDataBy_SP_M_REP_ITEMSAMOUNTS_4(Date1, Date2, IdCat);
            if (table.Count == 0)
            {
                MyMainForm.ShowWarning("Pārkskats ir tukšs.", null, this);
                return;
            }

            RepRows = new List<RepRowMovementOfAmounts>();
            RepRowMovementOfAmounts reprow = null;
            foreach (var dr_rep in table)
            {
                if (reprow is null || dr_rep.IDSTORE != reprow.Id)
                {
                    reprow = new RepRowMovementOfAmounts();
                    reprow.Id = dr_rep.IDSTORE;
                    var dr_store = MyData.DataSetKlonsM.M_STORES.FindByID(reprow.Id);
                    reprow.Code = dr_store.CODE;
                    reprow.Name = dr_store.NAME;
                    RepRows.Add(reprow);
                }
                reprow.SetData(dr_rep.TP, dr_rep.AMOUNT, dr_rep.TBUYPRICE, dr_rep.TSELLPRICE);
            }
            RepRows.Sort((x1, x2) => x1.Code.CompareTo(x2.Code));
            dgvRows.DataSource = RepRows;
            ShowEmptyColumns(chShowEmptyColumns.Checked);
        }

        private void ShowEmptyColumns(bool show)
        {
            void set_visible(Func<RepRowMovementOfAmounts, decimal> func, DataGridViewColumn dgc)
                => dgc.Visible = show || RepRows.Where(x => func(x) != 0M).Any();
            
            if (RepRows.Count == 0) return;
            set_visible(x => x.AmSākumā, dgcAmSākumā);
            set_visible(x => x.AmIepirkums, dgcAmIepirkums);
            set_visible(x => x.AmRealizācija, dgcAmRealizācija);
            set_visible(x => x.AmAtgriezts_piegādātājam, dgcAmAtgriezts_piegādātājam);
            set_visible(x => x.AmAtgriezts_no_pircēja, dgcAmAtgriezts_no_pircēja);
            set_visible(x => x.AmNorakstīts, dgcAmNorakstīts);
            set_visible(x => x.AmPierakstīts, dgcAmPierakstīts);
            set_visible(x => x.AmUz_noliktavu, dgcAmUz_noliktavu);
            set_visible(x => x.AmNo_noliktavas, dgcAmNo_noliktavas);
            set_visible(x => x.AmIzlietots, dgcAmIzlietots);
            set_visible(x => x.AmSaražots, dgcAmSaražots);
            set_visible(x => x.AmBeigās, dgcAmBeigās);

            set_visible(x => x.ValSākumā, dgcValSākumā);
            set_visible(x => x.ValIepirkums, dgcValIepirkums);
            set_visible(x => x.ValRealizācija, dgcValRealizācija);
            set_visible(x => x.ValAtgriezts_piegādātājam, dgcValAtgriezts_piegādātājam);
            set_visible(x => x.ValAtgriezts_no_pircēja, dgcValAtgriezts_no_pircēja);
            set_visible(x => x.ValNorakstīts, dgcValNorakstīts);
            set_visible(x => x.ValPierakstīts, dgcValPierakstīts);
            set_visible(x => x.ValUz_noliktavu, dgcValUz_noliktavu);
            set_visible(x => x.ValNo_noliktavas, dgcValNo_noliktavas);
            set_visible(x => x.ValIzlietots, dgcValIzlietots);
            set_visible(x => x.ValSaražots, dgcValSaražots);
            set_visible(x => x.ValBeigās, dgcValBeigās);

            set_visible(x => x.Income, dgcIncome);
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
            var iditem = FormM_ItemsCat.GetItemsCatId(null);
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

        private void chShowEmptyColumns_Click(object sender, EventArgs e)
        {
            ShowEmptyColumns(chShowEmptyColumns.Checked);
        }

        private void dgvRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value) return;

            var dgc = dgvRows.Columns[e.ColumnIndex];
            if (dgc.DataPropertyName.StartsWith("Am") ||
                dgc.DataPropertyName.StartsWith("Income"))
            {
                var val = (decimal)e.Value;
                if (val == 0M)
                {
                    e.Value = null;
                    e.FormattingApplied = true;
                }
            }
        }

    }

}
