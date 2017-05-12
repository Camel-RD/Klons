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
using KlonsLIB.Misc;

namespace KlonsP.Forms
{
    public partial class Form_ReplacePart : MyFormBaseP
    {
        public Form_ReplacePart()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {tbDate, tbValue, cmCalc},
                new Control[] {tbDoc, tbDoc, cmAddEvent},
                new Control[] {tbDescr, tbDescr, cmClose}
            });


            tbDate.DataBindings[0].Parse += tbDate_Parse;
            replacePartData1.fDATE = DateTime.Today;
        }

        private void Form_ReplacePart_Load(object sender, EventArgs e)
        {

        }

        public int IdIt = int.MinValue;
        public bool StateOK = false;

        public void InitData(int idit)
        {
            IdIt = idit;
        }

        private void tbDate_Parse(object sender, ConvertEventArgs e)
        {
            if (e.Value == null || !(e.Value is string)) return;
            var sv = e.Value as string;
            if (sv == "")
            {
                e.Value = null;
                return;
            }
            DateTime dt;
            if (!Utils.StringToDate(sv, out dt)) return;
            e.Value = dt;
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            OnNaviKey(sender, e);
        }

        public string DoCalc()
        {
            StateOK = false;
            KlonsPDataSet.ITEMSRow dr = null;

            if (IdIt == int.MinValue || 
                (dr = MyData.DataSetKlons.ITEMS.FindByID(IdIt)) == null)
                return "Nav atrasts pamatlīdzeklis.";

            if (!replacePartData1.fDATE.HasValue)
                return "Nav norādīts datums.";

            var dt = replacePartData1.fDATE.Value;

            var it = new ItemInfo();
            it.SetFromRow(dr);

            if (!it.IsGoodEventDate(dt))
                return "Nekorekts datums.";

            var rt = it.CheckItem();
            if (rt != "OK")
                return rt;

            it.Events2 = new List<EventInfo>();
            var ev = new EventInfo();
            it.Events2.Add(ev);
            ev.Dt = dt;
            ev.XEvent = EEvent.apr;

            rt = it.FullCalc();
            if (rt != "OK")
                return rt;

            replacePartData1.fMtUsed = ev.MtUsed;
            replacePartData1.fDeprec = DataTasks.Round(replacePartData1.fValue *
                (decimal)ev.RateD * (decimal)ev.MtUsed / 12.0M, 2);
            replacePartData1.fValueLeft = replacePartData1.fValue - replacePartData1.fDeprec;
            replacePartData1.fValueC = 0.0M;
            replacePartData1.fDeprecC = -replacePartData1.fDeprec;
            replacePartData1.fTaxValueC = replacePartData1.fDeprec;

            var sdoc = replacePartData1.fDoc.Nz();
            replacePartData1.fDescr =
                $"detaļas vērtība {replacePartData1.fValue:N2}, nolietojuma periods {replacePartData1.fMtUsed} mēn., " +
                $"izslēgtais nolietojums {replacePartData1.fDeprec:N2}, amortizētās izmaksas {replacePartData1.fValueLeft:N2}";
            replacePartData1.fDescr = replacePartData1.fDescr.LeftMax(200);

            StateOK = true;
            return "OK";
        }

        private void cmCalc_Click(object sender, EventArgs e)
        {
            var rt = DoCalc();
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }
        }

        private void cmAddEvent_Click(object sender, EventArgs e)
        {
            if (!StateOK)
            {
                MyMainForm.ShowWarning("Vispirms jāveic aprēķins.");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void cmClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
