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
    public partial class FormM_RepMovementPerItem : MyFormBaseF
    {
        public FormM_RepMovementPerItem()
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
            var ad = new DataSets.KlonsMRepDataSetTableAdapters.SP_M_REP_ITEMSAMOUNTS_3TableAdapter();
            var table = ad.GetDataBy_SP_M_REP_ITEMSAMOUNTS_3(Date1, Date2, IdCat);
            if (table.Count == 0)
            {
                MyMainForm.ShowWarning("Pārkskats ir tukšs.", null, this);
                return;
            }

            RepRows = new List<RepRowMovementOfAmounts>();
            RepRowMovementOfAmounts reprow = null;
            foreach (var dr_rep in table)
            {
                if (reprow is null || dr_rep.IDITEM != reprow.Id)
                {
                    reprow = new RepRowMovementOfAmounts();
                    reprow.Id = dr_rep.IDITEM;
                    var dr_item = MyData.DataSetKlonsM.M_ITEMS.FindByID(reprow.Id);
                    reprow.Code = dr_item.BARCODE;
                    reprow.Name = dr_item.NAME;
                    reprow.ItemUnits = dr_item.M_UNITSRow.CODE;
                    reprow.ItemPrice = dr_item.SELLPRICE;
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

    public class RepRowMovementOfAmounts
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string ItemUnits { get; set; }
        public decimal ItemPrice { get; set; }
        public bool IsGrouped { get; set; }

        public decimal AmSākumā { get; set; }
        public decimal AmIepirkums { get; set; }
        public decimal AmRealizācija { get; set; }
        public decimal AmAtgriezts_piegādātājam { get; set; }
        public decimal AmAtgriezts_no_pircēja { get; set; }
        public decimal AmSākuma_atlikums { get; set; }
        public decimal AmNorakstīts { get; set; }
        public decimal AmPierakstīts { get; set; }
        public decimal AmUz_noliktavu { get; set; }
        public decimal AmNo_noliktavas { get; set; }
        public decimal AmIzlietots { get; set; }
        public decimal AmSaražots { get; set; }
        public decimal AmBeigās { get; set; }

        public decimal ValSākumā { get; set; }
        public decimal ValIepirkums { get; set; }
        public decimal ValRealizācija { get; set; }
        public decimal ValAtgriezts_piegādātājam { get; set; }
        public decimal ValAtgriezts_no_pircēja { get; set; }
        public decimal ValSākuma_atlikums { get; set; }
        public decimal ValNorakstīts { get; set; }
        public decimal ValPierakstīts { get; set; }
        public decimal ValUz_noliktavu { get; set; }
        public decimal ValNo_noliktavas { get; set; }
        public decimal ValIzlietots { get; set; }
        public decimal ValSaražots { get; set; }
        public decimal ValBeigās { get; set; }

        public decimal Income { get; set; }

        public void SetData(int tp, decimal am, decimal val, decimal sellprice)
        {
            if (tp == -1)
            {
                AmSākumā += am;
                ValSākumā += val;
                return;
            }
            if (tp == 100)
            {
                AmBeigās += am;
                ValBeigās += val;
                return;
            }
            EDocType doctype = (EDocType)tp;
            switch (doctype)
            {
                case EDocType.Iepirkums:
                    AmIepirkums += am;
                    ValIepirkums += val;
                    break;
                case EDocType.Realizācija:
                    AmRealizācija += am;
                    ValRealizācija += val;
                    Income += -sellprice;
                    break;
                case EDocType.Atgriezts_piegādātājam:
                case EDocType.Kredītrēķins_no_piegādātāja:
                    AmAtgriezts_piegādātājam += am;
                    ValAtgriezts_piegādātājam += val;
                    break;
                case EDocType.Atgriezts_no_pircēja:
                case EDocType.Kredītrēķins_pircējam:
                    AmAtgriezts_no_pircēja += am;
                    ValAtgriezts_no_pircēja += val;
                    Income += -sellprice;
                    break;
                case EDocType.Sākuma_atlikums:
                    AmSākuma_atlikums += am;
                    ValSākuma_atlikums += val;
                    break;
                case EDocType.Norakstīts:
                    AmNorakstīts += am;
                    ValNorakstīts += val;
                    break;
                case EDocType.Pierakstīts:
                    AmPierakstīts += am;
                    ValPierakstīts += val;
                    break;
                case EDocType.Uz_noliktavu:
                    AmUz_noliktavu += am;
                    ValUz_noliktavu += val;
                    break;
                case EDocType.No_noliktavas:
                    AmNo_noliktavas += am;
                    ValNo_noliktavas += val;
                    break;
                case EDocType.Izlietots:
                    AmIzlietots += am;
                    ValIzlietots += val;
                    break;
                case EDocType.Saražots:
                    AmSaražots += am;
                    ValSaražots += val;
                    break;
            }

        }
        public void AddFrom(RepRowMovementOfAmounts row)
        {
            AmSākumā += row.AmSākumā;
            AmIepirkums += row.AmIepirkums;
            AmRealizācija += row.AmRealizācija;
            AmAtgriezts_piegādātājam += row.AmAtgriezts_piegādātājam;
            AmAtgriezts_no_pircēja += row.AmAtgriezts_no_pircēja;
            AmSākuma_atlikums += row.AmSākuma_atlikums;
            AmNorakstīts += row.AmNorakstīts;
            AmPierakstīts += row.AmPierakstīts;
            AmUz_noliktavu += row.AmUz_noliktavu;
            AmNo_noliktavas += row.AmNo_noliktavas;
            AmIzlietots += row.AmIzlietots;
            AmSaražots += row.AmSaražots;
            AmBeigās += row.AmBeigās;
 
            ValSākumā += row.ValSākumā;
            ValIepirkums += row.ValIepirkums;
            ValRealizācija += row.ValRealizācija;
            ValAtgriezts_piegādātājam += row.ValAtgriezts_piegādātājam;
            ValAtgriezts_no_pircēja += row.ValAtgriezts_no_pircēja;
            ValSākuma_atlikums += row.ValSākuma_atlikums;
            ValNorakstīts += row.ValNorakstīts;
            ValPierakstīts += row.ValPierakstīts;
            ValUz_noliktavu += row.ValUz_noliktavu;
            ValNo_noliktavas += row.ValNo_noliktavas;
            ValIzlietots += row.ValIzlietots;
            ValSaražots += row.ValSaražots;
            ValBeigās += row.ValBeigās;
 
            Income += row.Income;
        }

    }

}
