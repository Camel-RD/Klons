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
    public partial class FormM_ItemCurrentStock : MyFormBaseF
    {
        public FormM_ItemCurrentStock()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvRows.AutoGenerateColumns = false;
        }

        private void FormM_ItemCurrentStock_Load(object sender, EventArgs e)
        {
        }

        public void MakeReport(int iditem)
        {
            lbItemName.Text = DataTasks.GetItemCodeAndName(iditem);
            var ad = new DataSets.KlonsMDataSetTableAdapters.M_ITEMS_PER_STORETableAdapter();
            var table_rows = ad.GetDataBy_SP_M_CURRENTSTOCK_01(iditem);
            var table_stores = MyData.DataSetKlonsM.M_STORES;
            if (table_rows.Count == 0) return;
            var rep_rows = table_rows.Select(x =>
            new ItemCurrentStockRow()
            {
                StoreCode = table_stores.FindByID(x.IDSTORE).CODE,
                StoreName = table_stores.FindByID(x.IDSTORE).NAME,
                Amount = x.AMOUNT
            })
            .OrderBy(x => x.StoreCode)
            .ToList();
            rep_rows.Add(new ItemCurrentStockRow()
            {
                StoreCode = "KOPĀ",
                Amount = rep_rows.Sum(x => x.Amount)
            });
            dgvRows.DataSource = rep_rows;
        }

        public class ItemCurrentStockRow
        {
            public string StoreCode { get; set; }
            public string StoreName { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
