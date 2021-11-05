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
    public partial class Form_SalarySheetNewRow : MyFormBaseA
    {
        public Form_SalarySheetNewRow()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void Form_SalarySheetNewRow_Load(object sender, EventArgs e)
        {
            PrepareForNew(Id_sar);
        }

        private int Id_sar = -1;
        private int _snr = 1;

        public bool Execute(int ids, ref int snr, out int idp, out int idam)
        {
            Id_sar = ids;
            _snr = snr;
            var ret = this.ShowDialog(KlonsData.St.MyMainForm);
            if(ret != DialogResult.OK)
            {
                idp = -1;
                idam = -1;
                snr = -1;
                return false;
            }

            if (!int.TryParse(tbSnr.Text, out snr))
                snr = 1;
            idp = (int)cbPerson.SelectedValue;
            idam = (int)cbPosition.SelectedValue;

            return true;
        }

        public void PrepareForNew(int id_sar)
        {
            /*
            int snr = 1;
            var dr_sar = MyData.DataSetKlons.SALARY_SHEETS.FindByID(id_sar);
            if(dr_sar != null)
            {
                snr = dr_sar.GetSALARY_SHEETS_RRowsByFK_SALARY_SHEETS_R_IDS().Count() + 1;
            }
            */
            tbSnr.Text = _snr.ToString();
        }

        private void cmDoIt_Click(object sender, EventArgs e)
        {
            if (cbPerson.SelectedValue == null || (int)cbPerson.SelectedValue == -1 ||
                cbPosition.SelectedValue == null || (int)cbPosition.SelectedValue == -1)
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
