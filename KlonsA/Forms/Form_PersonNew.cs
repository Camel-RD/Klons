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
using KlonsLIB.Misc;

namespace KlonsA.Forms
{
    public partial class Form_PersonNew : MyFormBaseA
    {
        public Form_PersonNew()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        public string FName = null;
        public string LName = null;
        public DateTime BirthDate = DateTime.MinValue;
        public string PK = null;
        public bool Male = true;
        public int IDP = 0;

        public string PositionTitle = null;
        public string iddep = null;

        public DateTime EventDate = DateTime.Today;
        public bool MakeEvents = true;
        public string RepCode = "11";
        public string ProfCode = "?";

        private void Form_PersonNew_Load(object sender, EventArgs e)
        {
            this.SetControlsUpDownOrder(
                new Control[][] {
                    new Control[] { tbFName },
                    new Control[] { tbLName },
                    new Control[] { tbBirthDate },
                    new Control[] { tbPK },
                    new Control[] { chMale },
                    new Control[] { chFemale },
                    new Control[] { tbPosition },
                    new Control[] { cbDep },
                    new Control[] { tbDate },
                    new Control[] { chMakeEvents },
                    new Control[] { tbRepCode },
                    new Control[] { tbProfCode },
                    new Control[] { cmOK },
                    new Control[] { cmCancel }
                });

            tbDate.Text = Utils.DateToString(DateTime.Today);
            tbRepCode.Text = "11";
            tbProfCode.Text = "?";
        }

        public string Check()
        {
            FName = tbFName.Text;
            LName = tbLName.Text;
            PK = tbPK.Text;
            PositionTitle = tbPosition.Text;

            if (string.IsNullOrEmpty(FName) || string.IsNullOrEmpty(LName))
                return "Jānorāda vārds, uzvārds.";
            if (FName.Length > 20 || LName.Length > 20)
                return "Vārds un uzvārds nevar būt garāks par 20 burtiem.";
            if (string.IsNullOrEmpty(tbBirthDate.Text) ||
                !Utils.StringToDate(tbBirthDate.Text, out BirthDate))
                return "Jānorāda dzimšanas datums.";
            if (PK.Length > 20)
                return "Personas kods nevar būt garāks par 20 simboliem.";
            Male = chMale.Checked;

            if (string.IsNullOrEmpty(PositionTitle))
                return "Jānorāda amata nosaukums.";
            if (PositionTitle.Length > 50)
                return "Amata nosaukums par garu.";

            if (cbDep.SelectedIndex == -1 || cbDep.SelectedValue == null)
                return "Nav norādīts departaments.";

            iddep = (string)cbDep.SelectedValue;

            if (!string.IsNullOrEmpty(PK))
            {
                var tablePersons = MyData.DataSetKlons.PERSONS;
                var drp = tablePersons.WhereX(
                    d =>
                    d.PK == PK).ToArray();
                if (drp.Length > 0)
                    return "Darbinieks ar šādu personas kodu jau ir uzskaitē.";
            }

            MakeEvents = chMakeEvents.Checked;
            Utils.StringToDate(tbDate.Text, out EventDate);
            RepCode = tbRepCode.Text;
            ProfCode = tbProfCode.Text;
            if (MakeEvents)
            {
                if (string.IsNullOrEmpty(ProfCode) || ProfCode == "?")
                    return "Jānorāda profesijas kods.";
                if (string.IsNullOrEmpty(RepCode))
                    return "Jānorāda ziņu kods.";
                if (RepCode.Length > 5)
                    return "Ziņu kods par garu";
                if (ProfCode.Length > 7)
                    return "Profesijas kods par garu";
            }
            return "OK";
        }

        public void DoAdd()
        {
            var tablePersons = MyData.DataSetKlons.PERSONS;
            var tablePersonsR = MyData.DataSetKlons.PERSONS_R;
            var tableAmati = MyData.DataSetKlons.POSITIONS;
            var tableAmatiR = MyData.DataSetKlons.POSITIONS_R;
            var tableEvents = MyData.DataSetKlons.EVENTS;

            var dr_p = tablePersons.NewPERSONSRow();
            dr_p.FNAME = FName;
            dr_p.LNAME = LName;
            dr_p.BIRTH_DATE = BirthDate;
            dr_p.PK = PK;
            dr_p.GENDER = (short)(Male ? 0 : 1);
            tablePersons.AddPERSONSRow(dr_p);

            IDP = dr_p.ID;

            var dr_pr = tablePersonsR.NewPERSONS_RRow();

            dr_pr.IDP = IDP;
            dr_pr.PERSONSRow = dr_p;
            dr_pr.EDIT_DATE = EventDate;
            dr_pr.FNAME = FName;
            dr_pr.LNAME = LName;
            if (!string.IsNullOrEmpty(dr_p.PK)) dr_pr.PERSON_CODE = dr_p.PK;
            tablePersonsR.AddPERSONS_RRow(dr_pr);

            var dr_am = tableAmati.NewPOSITIONSRow();

            dr_am.IDP = IDP;
            dr_am.PERSONSRow = dr_p;
            dr_am.TITLE = PositionTitle;
            dr_am.IDDEP = iddep;
            tableAmati.AddPOSITIONSRow(dr_am);

            var dr_amr = tableAmatiR.NewPOSITIONS_RRow();

            dr_amr.IDA = dr_am.ID;
            dr_amr.POSITIONSRow = dr_am;
            dr_amr.EDIT_DATE = EventDate;
            if (!string.IsNullOrEmpty(dr_am.TITLE)) dr_amr.TITLE = dr_am.TITLE;
            if (!string.IsNullOrEmpty(dr_am.IDDEP)) dr_amr.IDDEP = dr_am.IDDEP;
            tableAmatiR.AddPOSITIONS_RRow(dr_amr);

            var dr_evHire = tableEvents.NewEVENTSRow();

            dr_evHire.EventCode = EEventId.Pieņemts;
            dr_evHire.IDP = IDP;
            dr_evHire.PERSONSRow = dr_p;
            dr_evHire.DATE1 = EventDate;
            dr_evHire.SCODE = RepCode;
            dr_evHire.OCCUPATION_CODE = ProfCode;
            tableEvents.AddEVENTSRow(dr_evHire);

            var dr_evAssign = tableEvents.NewEVENTSRow();

            dr_evAssign.EventCode = EEventId.Piešķirts_amats;
            dr_evAssign.IDP = IDP;
            dr_evAssign.PERSONSRow = dr_p;
            dr_evAssign.IDA = dr_am.ID;
            dr_evAssign.POSITIONSRow = dr_am;
            dr_evAssign.DATE1 = EventDate;
            tableEvents.AddEVENTSRow(dr_evAssign);
        }

        private void chMale_CheckedChanged(object sender, EventArgs e)
        {
            chFemale.Checked = !chMale.Checked;
        }

        private void chFemale_CheckedChanged(object sender, EventArgs e)
        {
            chMale.Checked = !chFemale.Checked;
        }

        private void cmOK_Click(object sender, EventArgs e)
        {
            var er = Check();
            if(er != "OK")
            {
                MyMainForm.ShowWarning(er);
                return;
            }
            DoAdd();
            DialogResult = DialogResult.OK;
        }

        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            OnNaviKey(sender, e);
        }
    }
}
