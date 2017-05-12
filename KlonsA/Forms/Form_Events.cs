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
    public partial class Form_Events : MyFormBaseA
    {
        public Form_Events()
        {
            InitializeComponent();
            SetupToolStrips();
            CheckMyFontAndColors();
        }

        private void Form_Events_Load(object sender, EventArgs e)
        {
            cbFilterEvent2.SelectedValue = null;
        }

        private void SetupToolStrips()
        {
            InsertInToolStrip(toolStrip1, tbDT1, 0);
            InsertInToolStrip(toolStrip1, tbDT2, 2);
            InsertInToolStrip(toolStrip1, cbFilterEvent, 4);
            InsertInToolStrip(toolStrip1, cbFilterEvent2, 5);
        }

        private void dgvEvents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dr = (dgvEvents.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as KlonsADataSet.EVENTSRow;
            /*
            if (e.ColumnIndex == dgcIDP.Index)
            {
                var drp = MyData.DataSetKlons.PERSONS.FindByID(dr.IDP);
                if (drp == null) return;
                e.Value = string.Format("{0} {1}", drp.FNAME, drp.LNAME);
                e.FormattingApplied = true;
                return;
            }*/
            if (e.ColumnIndex == dgcIDA.Index)
            {
                if (dr.IsIDANull()) return;
                var dra = MyData.DataSetKlons.POSITIONS.FindByID(dr.IDA);
                if (dra == null) return;
                e.Value = dra.TITLE;
                e.FormattingApplied = true;
                return;
            }
            if (e.ColumnIndex == dgcIDN.Index)
            {
                var drn = MyData.DataSetKlons.EVENT_TYPES.FindByID(dr.IDN);
                if (drn == null) return;
                e.Value = drn.DESCR;
                e.FormattingApplied = true;
                return;
            }
        }

        private DateTime date1, date2;
        private bool filterEventCodes = false;
        private bool filterEventCodes2 = false;
        private int eventid1, eventid2;

        private string CheckFilterParams()
        {
            DateTime dt1 = DateTime.MinValue, dt2 = DateTime.MaxValue;
            if ((!string.IsNullOrEmpty(tbDT1.Text) && !Utils.StringToDate(tbDT1.Text, out dt1)) ||
                (!string.IsNullOrEmpty(tbDT2.Text) && !Utils.StringToDate(tbDT2.Text, out dt2)) ||
                dt1 > dt2)
                return "Nekorekti norādīti datuni.";
            if (cbFilterEvent.SelectedValue == null)
            {
                filterEventCodes = false;
            }
            else
            {
                eventid1 = (int)cbFilterEvent.SelectedValue;
                filterEventCodes = true;
            }
            if (cbFilterEvent2.SelectedValue == null)
            {
                filterEventCodes2 = false;
            }
            else
            {
                eventid2 = (int)cbFilterEvent2.SelectedValue;
                filterEventCodes2 = true;
            }

            date1 = dt1;
            date2 = dt2;

            return "OK";
        }

        private void DoFilter()
        {
            var ret = CheckFilterParams();
            if (ret != "OK")
            {
                MyMainForm.ShowWarning(ret);
                return;
            }
            var fs = string.Format("DATE1 >= #{0:M/d/yyyy}# and DATE1 <= #{1:M/d/yyyy}#", date1, date2);
            if (filterEventCodes)
            {
                if (string.IsNullOrEmpty(fs))
                    fs = string.Format("(IDN = {0})", eventid1);
                else
                    fs = string.Format("({0}) and (IDN = {1})", fs, eventid1);
            }
            if (filterEventCodes2)
            {
                if (string.IsNullOrEmpty(fs))
                    fs = string.Format("(IDN2 = {0})", eventid2);
                else
                    fs = string.Format("({0}) and (IDN2 = {1})", fs, eventid2);
            }
            bsEvents.Filter = fs;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DoFilter();
        }

    }
}
