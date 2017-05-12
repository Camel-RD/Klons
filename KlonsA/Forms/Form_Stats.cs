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
    public partial class Form_Stats : MyFormBaseA
    {
        public Form_Stats()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            dgvStats.AutoGenerateColumns = false;
            dgvList.AutoGenerateColumns = false;

            cbYR.Items.Clear();
            for (int i = DataLoader.LoadedDT1.Year; i <= DataLoader.LoadedDT2.Year; i++)
                cbYR.Items.Add(i);

            cbYR.SelectedIndex = cbYR.Items.Count - 1;
            cbMT.SelectedIndex = 0;

        }

        public int PYear = 0;
        public int PMonth = 0;
        public List<RepRowStats> StatsRows = null;
        public KlonsARepDataSet.SP_STATS_02DataTable Stats2Table = null;

        private void Form_Stats_Load(object sender, EventArgs e)
        {
        }

        private void CheckPeriod()
        {
            int kyr = cbYR.SelectedIndex;
            int kmt = cbMT.SelectedIndex;
            if (kyr == -1 || kmt == -1) return;
            PYear = int.Parse(cbYR.Text);
            PMonth = int.Parse(cbMT.Text);
            if (DataLoader.IsMonthLoaded(PYear, PMonth))
            {
                dgvStats.Enabled = true;
                DoGetStats();
            }
            else
            {
                dgvStats.Enabled = false;
            }
        }

        public void DoGetStats()
        {
            var ad = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.SP_STATS_01TableAdapter();
            var ad2 = new KlonsA.DataSets.KlonsARepDataSetTableAdapters.SP_STATS_02TableAdapter();
            DateTime dt1 = new DateTime(PYear, PMonth, 1);
            DateTime dt2 = dt1.LastDayOfMonth();
            var table = ad.GetDataBy_SP_STATS_01(dt1, dt2);
            Stats2Table = ad2.GetDataBy_PS_STATS_02(dt1, dt2);

            var dr = table[0];
            StatsRows = new List<RepRowStats>();
            AddStatsRow(1, dr.HIRED, "Pieņemti darbinieki");
            AddStatsRow(2, dr.FIRED, "Atlaisti darbinieki");
            AddStatsRow(3, dr.WORKING, "Strādājuši darbinieki");
            AddStatsRow(4, dr.POS_ADDED, "Piešķirti amati");
            AddStatsRow(5, dr.POS_REMOVED, "Atņemti amati");
            AddStatsRow(6, dr.POS_NO_TIME_TEMPL, "Amati, kas nav darba laika uzskaites lapu sagatavēs");
            AddStatsRow(7, dr.POS_NO_TIME, "Amati, kas nav darba laika uzskaites lapās");
            AddStatsRow(8, dr.POS_NO_SALARY_TEMPL, "Amati, kas nav algas lapu sagatavēs");
            AddStatsRow(9, dr.POS_NO_SALARY, "Amati, kas nav algas lapās");
            AddStatsRow(10, dr.POS_NO_PAY_TEMPL, "Amati, kas nav maksājumu lapu sagatavēs");
            AddStatsRow(11, dr.POS_NO_PAY, "Amati, kas nav maksājumu lapās");
            AddStatsRowDec(12, dr.SALARY_PAY, "Izmaksājamā alga");
            AddStatsRowDec(13, dr.PAID, "Mēnesī izmaksātā alga");
            AddStatsRowDec(14, dr.SALARY_PAY_PAID, "Par mēnesi izmaksātā alga");
            bsStats.DataSource = StatsRows;
            dgvStats.AutoResizeRows();
        }

        public void AddStatsRow(int tag, int ct, string tx)
        {
            StatsRows.Add(new RepRowStats()
            {
                Tag = tag,
                Value = ct,
                TagStr = tx
            });
        }

        public void AddStatsRowDec(int tag, decimal val, string tx)
        {
            StatsRows.Add(new RepRowStats()
            {
                Tag = tag,
                Value = val,
                TagStr = tx,
                ValueType = RepRowStats.EValueType.Decimal
            });
        }

        private void cbYR_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckPeriod();
        }

        private void cbMT_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckPeriod();
        }

        private void bsStats_CurrentChanged(object sender, EventArgs e)
        {
            if(bsStats.Current == null)
            {
                dgvList.Visible = false;
                return;
            }
            var dr = bsStats.Current as RepRowStats;
            if (dr.Value == 0.0M || dr.ValueType == RepRowStats.EValueType.Decimal)
            {
                dgvList.Visible = false;
                return;
            }
            var drs = Stats2Table.Where(d => d.TAG == dr.Tag).ToArray();
            if (drs.Length == 0) return;
            bsList.DataSource = drs;
            dgvList.Visible = true;
        }

        private void dgvStats_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex != dgcValue.Index) return;
            if (e.RowIndex < 0) return;
            var dr = bsStats[e.RowIndex] as RepRowStats;
            if (dr.Tag > 11)
            {
                e.CellStyle.Format = "N2";
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                return;
            }

            if (dr.Tag < 6 || dr.Tag > 11 || dr.Value == 0.0M) return;

            e.CellStyle.BackColor = Color.IndianRed;
            e.CellStyle.ForeColor = Color.White;

        }
    }


    public class RepRowStats
    {
        public enum EValueType { Count, Decimal}

        public int Tag { get; set; } = -1;
        public string TagStr { get; set; } = null;
        public decimal Value { get; set; } = 0.0M;
        public EValueType ValueType = EValueType.Count;
    }

}
