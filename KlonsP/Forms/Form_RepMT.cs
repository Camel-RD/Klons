using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsP.DataSets;
using KlonsP.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Components;
using KlonsLIB.Misc;
using KlonsLIB.MySourceGrid.GridRows;
using KlonsLIB.Data;

namespace KlonsP.Forms
{
    public partial class Form_RepMT : MyFormBaseP
    {
        public Form_RepMT()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvRows.AutoGenerateColumns = false;
        }

        private void Form_RepMT_Load(object sender, EventArgs e)
        {

        }

        private ItemInfo ItemData = null;

        private void SetLabel(ItemInfo it, DateTime dt2)
        {
            label1.Text = 
                $"Pamatlīdzeklis: [{it.ItemRegNr.Nz()}] {it.ItemName.Nz()}\n" + 
                $"Periods: līdz {Utils.DateToString(dt2)}";
        }

        public void SetItemDataMt(ItemInfo it, DateTime dt2)
        {
            Text = "Aprēķina izklāsts pa mēnešiem";
            SetLabel(it, dt2);
            ItemData = it;
            bsRows.DataSource = it.Events2;
            dgcMonth.Visible = true;
        }

        public void SetItemDataYr(ItemInfo it, DateTime dt2)
        {
            Text = "Aprēķina izklāsts pa gadiem";
            SetLabel(it, dt2);
            ItemData = it;
            bsRows.DataSource = it.Events2;
            dgcMonth.Visible = false;
        }
    }
}
