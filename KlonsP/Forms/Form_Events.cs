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
    public partial class Form_Events : MyFormBaseP
    {
        public Form_Events()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvEvents.AutoGenerateColumns = false;

            dgvFilterBaseHeight = dgvFilter.Height;
            var hScrollbar = dgvFilter.Controls.OfType<HScrollBar>().First();
            hScrollbar.VisibleChanged += HScrollbar_VisibleChanged;
        }

        private int dgvFilterBaseHeight = 0;

        private void Form_Events_Load(object sender, EventArgs e)
        {
        }

        private void Form_Events_Shown(object sender, EventArgs e)
        {
            dgvFilter.PerformLayout();
        }

        private void CheckDGVFilterHeight()
        {
            var hScrollbar = dgvFilter.Controls.OfType<HScrollBar>().First();
            if (hScrollbar.Visible)
                dgvFilter.Height = dgvFilterBaseHeight + System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight;
            else
                dgvFilter.Height = dgvFilterBaseHeight;
        }

        private void HScrollbar_VisibleChanged(object sender, EventArgs e)
        {
            CheckDGVFilterHeight();
        }

        private void dgvFilter_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if(e.ColumnIndex == dgcFilterDate1.Index || e.ColumnIndex == dgcFilterDate2.Index)
            {
                Utils.DGVParseDateCell(e);
                return;
            }
        }

        private void dgvEvents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var o = dgvEvents.GetCurrentDataItem();
            if (o == null) return;
            var dr = o as KlonsPDataSet.ITEMS_EVENTSRow;
            if(dr == null)
                dr = (o as DataRowView)?.Row as KlonsPDataSet.ITEMS_EVENTSRow;
            if (dr == null) return;
            if (e.ColumnIndex == dgcEventsEvent.Index)
            {
                e.Value = dr.EVENTSRow.CODE;
                e.FormattingApplied = true;
            }
            else if (e.ColumnIndex == dgcEventsCat1.Index)
            {
                e.Value = dr.CAT1Row.CODE;
                e.FormattingApplied = true;
            }
            else if (e.ColumnIndex == dgcEventsCatD.Index)
            {
                e.Value = dr.CATDRow.CODE;
                e.FormattingApplied = true;
            }
            else if (e.ColumnIndex == dgcEventsCatT.Index)
            {
                e.Value = dr.CATTRow.CODE;
                e.FormattingApplied = true;
            }
            else if (e.ColumnIndex == dgcEventsDepartment.Index)
            {
                e.Value = dr.DEPARTMENTSRow.CODE;
                e.FormattingApplied = true;
            }
            else if (e.ColumnIndex == dgcEventsPlace.Index)
            {
                e.Value = dr.PLACESRow.CODE;
                e.FormattingApplied = true;
            }

        }

        private void DoFilter2()
        {
            var table_events = MyData.DataSetKlons.ITEMS_EVENTS;
            var drs = table_events
                .WhereX(
                    d =>
                    (filterData1.fDATE1 == null || d.DT >= filterData1.fDATE1) &&
                    (filterData1.fDATE2 == null || d.DT <= filterData1.fDATE2) &&
                    (filterData1.fEVENT == null || d.EVENT == filterData1.fEVENT) &&
                    (filterData1.fCAT1 == null || d.CAT1 == filterData1.fCAT1) &&
                    (filterData1.fCATD == null || d.CATD == filterData1.fCATD) &&
                    (filterData1.fCATT == null || d.CATT == filterData1.fCATT) &&
                    (filterData1.fDEPARTMENT == null || d.DEPARTMENT == filterData1.fDEPARTMENT) &&
                    (filterData1.fPLACE == null || d.PLACE == filterData1.fPLACE))
                .ToList();
            var bl = new BindingList<KlonsPDataSet.ITEMS_EVENTSRow>(drs);
            bsRows2.DataSource = bl;
        }

        private string DateTosExprStr(DateTime dt)
        {
            return string.Format("#{0:d}#",dt);
        }

        public void DoFilter()
        {
            string fs = "";
            if (filterData1.fEVENT != null)
            {
                fs = "EVENT=" + filterData1.fEVENT.Value;
            }
            if (filterData1.fDATE1 != null)
            {
                var fs1 = "DT>=" + DateTosExprStr(filterData1.fDATE1.Value);
                fs = fs == "" ? fs1 : fs + " AND (" + fs1 + ")";
            }
            if (filterData1.fDATE2 != null)
            {
                var fs1 = "DT<=" + DateTosExprStr(filterData1.fDATE2.Value);
                fs = fs == "" ? fs1 : fs + " AND (" + fs1 + ")";
            }
            if (filterData1.fCAT1 != null)
            {
                var fs1 = "CAT1=" + filterData1.fCAT1.Value;
                fs = fs == "" ? fs1 : fs + " AND (" + fs1 + ")";
            }
            if (filterData1.fCATD != null)
            {
                var fs1 = "CATD=" + filterData1.fCATD.Value;
                fs = fs == "" ? fs1 : fs + " AND (" + fs1 + ")";
            }
            if (filterData1.fCATT != null)
            {
                var fs1 = "CATT=" + filterData1.fCATT.Value;
                fs = fs == "" ? fs1 : fs + " AND (" + fs1 + ")";
            }
            if (filterData1.fDEPARTMENT != null)
            {
                var fs1 = "DEPARTMENT=" + filterData1.fDEPARTMENT.Value;
                fs = fs == "" ? fs1 : fs + " AND (" + fs1 + ")";
            }
            if (filterData1.fPLACE != null)
            {
                var fs1 = "PLACE=" + filterData1.fPLACE.Value;
                fs = fs == "" ? fs1 : fs + " AND (" + fs1 + ")";
            }

            if (fs == "")
                bsRows.RemoveFilter();
            else if (bsRows.Filter != fs)
                bsRows.Filter = fs;
        }

        private void dgvFilter_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //DoFilter();
        }

        private void dgvFilter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgcEventsCM.Index)
            {
                DoFilter();
            }
        }

        private void Form_Events_Resize(object sender, EventArgs e)
        {
            var hScrollbar = dgvFilter.Controls.OfType<HScrollBar>().First();
            if (hScrollbar.Visible)
            {
                if(Math.Abs(dgvFilter.Bottom - hScrollbar.Bottom) > 3)
                {
                    dgvFilter.PerformLayout();
                    return;
                }
            }
        }

        private void tsbOpenItem_Click(object sender, EventArgs e)
        {
            if (bsRows.DataSource == null || bsRows.Current == null) return;
            var dr = bsRows.CurrentDataRow as KlonsPDataSet.ITEMS_EVENTSRow;
            var fm = MyMainForm.ShowForm(typeof(Form_Items)) as Form_Items;
            if (fm == null) return;
            fm.SelectItem(dr.ID);
        }

    }
}
