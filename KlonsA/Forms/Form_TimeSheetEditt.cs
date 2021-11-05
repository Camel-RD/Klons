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
using KlonsA.DataSets.KlonsADataSetTableAdapters;
using KlonsLIB.Data;
using KlonsLIB.Misc;

namespace KlonsA.Forms
{
    public partial class Form_TimeSheetEdit : MyFormBaseA
    {
        public Form_TimeSheetEdit()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void Form_TimeSheetEdit_Load(object sender, EventArgs e)
        {
            if (DoNew)
                PrepareForNew(Id_sar);
            else
                PrepareForEdit(Id_sar_r);
        }

        private int Id_sar_r = -1;
        private int Id_sar = -1;
        private bool DoNew = false;


        public bool Execute(bool donew, int id, out int snr, out int idp, out int idam, out int idpl, out bool plind, out bool night, out bool overtime)
        {
            Id_sar_r = id;
            Id_sar = id;
            DoNew = donew;

            var ret = this.ShowDialog(KlonsData.St.MyMainForm);
            if(ret != DialogResult.OK)
            {
                idp = -1;
                idam = -1;
                idpl = -1;
                snr = -1;
                plind = false;
                night = false;
                overtime = false;
                return false;
            }

            if (!int.TryParse(tbSnr.Text, out snr))
                snr = 1;
            idp = (int)cbPerson.SelectedValue;
            idam = (int)cbPosition.SelectedValue;
            idpl = (int)cbPlan.SelectedValue;
            plind = chPlanIndividual.Checked;
            night = chNight.Checked;
            overtime = chOvertime.Checked;

            return true;
        }

        public void PrepareForNew(int id_sar)
        {
            this.Text = "Jauns darba laika lapas ieraksts";
            cmDoIt.Text = "Pievienot";
            int snr = 1;
            var dr_sar = MyData.DataSetKlons.TIMESHEET_LISTS.FindByID(id_sar);
            if(dr_sar != null)
            {
                snr = dr_sar.GetTIMESHEET_LISTS_RRows().Count() + 1;
            }
            tbSnr.Text = snr.ToString();
        }

        public void PrepareForEdit(int id_sar_r)
        {
            this.Text = "Rediģēt darba laika lapas ierakstu";
            cmDoIt.Text = "Saglabāt";

            var table_sar_r = MyData.DataSetKlons.TIMESHEET_LISTS_R;
            var dr_sar_r = table_sar_r.FindByID(id_sar_r);

            tbSnr.Text = dr_sar_r.SNR.ToString();

            int nr_pers = FindPerson(dr_sar_r.IDP);
            bsPersons.Position = nr_pers;

            int nr_amats = FindAmats(dr_sar_r.IDAM);
            bsAmati.Position = nr_amats;

            int nr_plan = FindPlan(dr_sar_r.IDPL);
            bsPlan.Position = nr_plan;

            chPlanIndividual.Checked = dr_sar_r.XPlanType == EPlanType.Individual;
            chNight.Checked = dr_sar_r.NIGHT == 1;
            chOvertime.Checked = dr_sar_r.OVERTIME == 1;
        }

        private int FindPerson(int id)
        {
            for (int i = 0; i < bsPersons.Count; i++)
            {
                var dr = (bsPersons[i] as DataRowView).Row as KlonsADataSet.PERSONSRow;
                if (dr.ID == id) return i;
            }
            return -1;
        }

        private int FindAmats(int id)
        {
            for (int i = 0; i < bsAmati.Count; i++)
            {
                var dr = (bsAmati[i] as DataRowView).Row as KlonsADataSet.POSITIONSRow;
                if (dr.ID == id) return i;
            }
            return -1;
        }
        private int FindPlan(int id)
        {
            for (int i = 0; i < bsPlan.Count; i++)
            {
                var dr = (bsPlan[i] as DataRowView).Row as KlonsADataSet.TIMEPLAN_LISTRow;
                if (dr.ID == id) return i;
            }
            return -1;
        }

        private void cmDoIt_Click(object sender, EventArgs e)
        {
            if (cbPerson.SelectedValue == null || (int)cbPerson.SelectedValue == -1 ||
                cbPosition.SelectedValue == null || (int)cbPosition.SelectedValue == -1 ||
                cbPlan.SelectedValue == null || (int)cbPlan.SelectedValue == -1)
            {
                KlonsData.St.MyMainForm.ShowWarning("Datu lauki nav aizpildīti.");
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void cmCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void GetIDPFromDialog()
        {
            var fm = new Form_Persons();
            fm.WhatToSelect = Form_Persons.EWhatToSelect.Both;
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            cbPerson.SelectedValue = fm.SelectedIDP;
            cbPosition.SelectedValue = fm.SelectedIDAM;
        }

        private void cmGetPerson_Click(object sender, EventArgs e)
        {
            GetIDPFromDialog();
        }
    }
}
