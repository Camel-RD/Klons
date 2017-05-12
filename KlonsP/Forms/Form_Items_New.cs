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

namespace KlonsP.Forms
{
    public partial class Form_Items_New : MyFormBaseP
    {
        public Form_Items_New()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            itemsEventsData1.fDT = DateTime.Today;
            tbDate.DataBindings[0].Parse += Form_Items_New_Parse;
        }

        private void Form_Items_New_Parse(object sender, ConvertEventArgs e)
        {
            if (e.Value == null || !(e.Value is string) || (string)e.Value == "") return;
            DateTime dt;
            if (Utils.StringToDate((string)e.Value, out dt))
                e.Value = dt;
        }

        private void Form_Items_New_Load(object sender, EventArgs e)
        {
            SetNavOrder();
        }

        public bool AddEvent { get; private set; } = true;
        private void SetNavOrder()
        {
            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {tbRegNr, null},
                new Control[] {tbName, null},
                new Control[] {chAddEvent, null},
                new Control[] {tbDate, cbCat1},
                new Control[] {tbValue, cbCatD},
                new Control[] {tbDocNr, cbCatT},
                new Control[] {null, cbDep},
                new Control[] {null, cbPlace},
                new Control[] {cmOK, cmCancel}
            });
        }

        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            Control control = sender as Control;
            OnNaviKey(sender, e);
            if (e.Handled) return;
        }

        private string Check()
        {
            AddEvent = chAddEvent.Checked;
            if (string.IsNullOrEmpty(itemsEventsData1.fITEM_REG_NR))
                return "Jānorāda pamatlīdzekļa reģistrācijas numurs.";
            if (string.IsNullOrEmpty(itemsEventsData1.fITEM_NAME))
                return "Jānorāda pamatlīdzekļa nosaukums.";
            if (!AddEvent) return "OK";
            if (string.IsNullOrEmpty(itemsEventsData1.fDOCNR))
                return "Jānorāda iegādes dokuments.";
            if (itemsEventsData1.fDT.Year < 1900 || itemsEventsData1.fDT.Year > 2100)
                return "Nekorekts datums.";
            if (itemsEventsData1.fVALUE_0 <= 0.0M)
                return "Nekorekta iegādes vērtība.";
            return "OK";
        }

        private void cmOK_Click(object sender, EventArgs e)
        {
            var er = Check();
            if(er != "OK")
            {
                MyMainForm.ShowWarning(er);
                return;
            }
            DialogResult = DialogResult.OK;
        }

    }
}
