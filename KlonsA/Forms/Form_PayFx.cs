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
    public partial class Form_PayFx : MyFormBaseA
    {
        public Form_PayFx()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public PayFxA PFxA = null;
        public List<PayFx2> Rows = null;

        private void Form_PayFx_Load(object sender, EventArgs e)
        {

        }

        public static void Show(PayFxA pfxa, string person, string period)
        {
            var fm = new Form_PayFx();
            fm.PFxA = pfxa;
            fm.Rows = new List<PayFx2>();
            fm.Rows.AddRange(pfxa.Rows);
            var tpfx = new PayFx2();
            tpfx.SetFrom(pfxa);
            tpfx.Caption = "KOPĀ";
            fm.Rows.Add(tpfx);
            fm.dgvRows.AutoGenerateColumns = false;
            fm.dgvRows.DataSource = fm.Rows;
            fm.lbTitle.Text = string.Format("Darbinieks: {0},\n\rperiods: {1}", person, period);
            fm.ShowDialog(fm.MyMainForm);
        }

    }
}
