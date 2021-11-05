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
using KlonsLIB.Forms;

namespace KlonsA.Forms
{
    public partial class Form_Plan : MyFormBaseA
    {
        public Form_Plan()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            myStyleDefs1.MakeStyles(dgvPlans);

            tslPeriod.Text = DataLoader.GetPeriodStr();

            //bsK1.DataSource = SomeDataDefs.DarbaLaiksK2a;
            //dgcKind1.ValueMember = "Key";
            //dgcKind1.DisplayMember = "Val";

            cbYR.Items.Clear();
            for (int i = DataLoader.LoadedDT1.Year; i <= DataLoader.LoadedDT2.Year; i++)
                cbYR.Items.Add(i);

            bsPlans.AllowNew = false;
            dgvPlans.AllowUserToAddRows = false;

            cbYR.SelectedIndex = cbYR.Items.Count - 1;
            cbMT.SelectedIndex = 0;
        }

        public int PYear = 0;
        public int PMonth = 0;
        public CalendarMonthInfo CalendarMonth = null;

        private void Form_Plan_Load(object sender, EventArgs e)
        {
            MyData.DataSetKlons.TIMESHEET.ColumnChanged += TIMESHEET_ColumnChanged;
            CheckSave();
        }

        private void Form_Plans_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlons.TIMESHEET.ColumnChanged -= TIMESHEET_ColumnChanged;
        }

        private void TIMESHEET_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column == MyData.DataSetKlons.TIMESHEET.K1Column) return;
            var dr = e.Row as KlonsADataSet.TIMESHEETRow;
            var k1 = MyData.DataSetKlons.TIMESHEET.V1Column.Ordinal;
            var k2 = MyData.DataSetKlons.TIMESHEET.V31Column.Ordinal;
            if (e.Column.Ordinal >= k1 && e.Column.Ordinal <= k2)
            {
                float sum = 0.0f;
                for (int i = k1; i <= k2; i++)
                {
                    float v = (float)(dr[i]);
                    if (v < 0.0f || v >= 24.0f) continue;
                    sum += v;
                }
                if (dr.K1 != sum)
                {
                    dr.K1 = sum;
                    RefreshCell(dr, dgcK1.Index);
                }
            }
        }

        public int FindRow(DataRow dr)
        {
            if (dr == null) return -1;
            try
            {
                for (int i = 0; i < bsPlans.Count; i++)
                    if ((bsPlans[i] as DataRowView)?.Row == dr) return i;
            }
            catch (Exception)
            {
            }
            return -1;
        }

        public void RefreshCell(DataRow dr, int colnr)
        {
            int rownr = FindRow(dr);
            if (rownr == -1) return;
            dgvPlans.InvalidateCell(colnr, rownr);
        }

        private bool CanDelete(KlonsADataSet.TIMESHEETRow dr)
        {
            var table_tr = MyData.DataSetKlons.TIMESHEET_LISTS_R;

            if ((dr.XKind1 == EKind1.PlanGroupaNight ||
                dr.XKind1 == EKind1.PlanIndividualNight) &&
                dr.TIMEPLAN_LISTRow.NIGHT == 0)
            {
                return true;
            }

            int ct1 = table_tr.WhereX(
                d =>
                d.IDPL == dr.IDP &&
                d.TIMESHEET_LISTSRow.YR == dr.YR &&
                d.TIMESHEET_LISTSRow.MT == dr.MT
                ).Count();

            return ct1 == 0;
        }

        public void DeleteCurrent()
        {
            if (bsPlans.Current == null) return;
            var dr = bsPlans.CurrentDataRow as KlonsADataSet.TIMESHEETRow;
            if (!CanDelete(dr))
            {
                MyMainForm.ShowWarning("Ierakstu nevar dzēst,\njo tas ir izmantots citur.");
                return;
            }
            bnavPlans.DeleteCurrent();
            SaveData();
        }

        private void bnavPlans_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvPlans_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void SetSaveButton(bool red)
        {
            bnavPlans.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvPlans.EndEditX()) return false;

            if (!this.Validate()) return false;
            try
            {
                DataTasks.SetNewIDs(myAdapterManager1);
                myAdapterManager1.UpdateAll();
                CheckSave();
            }
            catch (Exception e)
            {
                CheckSave();
                Form_Error.ShowException(e, "Neizdevās saglabāt izmaiņas.");
                return false;
            }
            return true;
        }

        private void CheckSave()
        {
            SetSaveButton(bsPlans.HasChanges());
        }

        private void dgvPlans_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bsPlans_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        public void DoOpenList()
        {
            bsPlans.Filter = string.Format("(kind1=0 or kind1=1) and YR={0} and MT={1}", PYear, PMonth);

            bsPlans.AllowNew = true;
            dgvPlans.AllowUserToAddRows = true;

            CalendarMonth = new CalendarMonthInfo(PYear, PMonth);

            MakeColumnHeaders(CalendarMonth);
            dgvPlans.AutoResizeColumns();
        }

        public void MakePlans()
        {
            if (bsPlans.Count > 0)
            {
                MyMainForm.ShowWarning("Norādītajam laika periodam jau ir izveidoti plāna ieraksti.");
                return;
            }
            if(!DataLoader.IsMonthLoaded(PYear, PMonth))
            {
                MyMainForm.ShowWarning("Norādītajam laika periodam nav ielādēti dati.");
                return;
            }
            DataTasks.MakePlans(CalendarMonth);
            SaveData();
            dgvPlans.AutoResizeColumns();
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
                dgvPlans.Enabled = true;
                bnavPlans.Enabled = true;
                DoOpenList();
            }
            else
            {
                MyMainForm.ShowWarning("Šim mēnesim dati nav ielādēdi.");
                dgvPlans.Enabled = false;
                bnavPlans.Enabled = false;
            }
        }

        private void cbYRMT_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckPeriod();
        }

        public void MakeColumnHeaders(CalendarMonthInfo calmt)
        {
            string[] daystr = SomeDataDefs.GetDaysStr(calmt.WeekDays);
            int nr1 = dgcV1.Index, d1;
            string s;

            for (int i = nr1; i < nr1 + 31; i++)
            {
                var col = dgvPlans.Columns[i];
                s = daystr[i - nr1] + "\n" + (i - nr1 + 1);
                d1 = calmt.WeekDays[i - nr1];
                if (d1 == -1)
                    s = "";
                col.Visible = d1 != -1;
                col.HeaderText = s;
                if (calmt.HolyDays[i - nr1] == EHolyDay.Holiday)
                {
                    col.HeaderCell.Style = myStyleDefs1.HeaderHolyDay;

                }
                else if (Utils.IN(d1, 6, 7))
                {
                    col.HeaderCell.Style = myStyleDefs1.HeaderWeekEnd;
                }
                else
                {
                    col.HeaderCell.Style = dgvPlans.RowHeadersDefaultCellStyle;
                }

            }
        }

        private void dgvPlans_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgcKind1.Index)
            {
                if (e.Value == null || e.Value == DBNull.Value) return;
                if (!(e.Value is short)) return;
                EKind1 k = (EKind1)e.Value;
                string s;
                if (k == EKind1.PlanGroupDay || k == EKind1.PlanIndividualDay) s = "diena";
                else s = "nakts";
                e.Value = s;
                e.FormattingApplied = true;
                return;
            }
            if (e.ColumnIndex >= dgcV1.Index && e.ColumnIndex <= dgcV31.Index)
            {
                if (dgvPlans.Rows[e.RowIndex].IsNewRow) return;
                if (e.Value == null || e.Value == DBNull.Value) return;
                float v = (float)e.Value;

                int daynr = e.ColumnIndex - dgcV1.Index + 1;

                var dr = (dgvPlans.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as KlonsADataSet.TIMESHEETRow;
                int dk = MyData.DataSetKlons.TIMESHEET.D1Column.Ordinal;

                if (dr.XKind1 == EKind1.PlanGroupaNight)
                {
                    if (v == 0.0f)
                    {
                        e.Value = "";
                        e.FormattingApplied = true;
                    }
                    return;
                }

                EDayPlanId daycode = dr.DxPlan[daynr - 1];

                if (daycode == EDayPlanId.DD)
                {
                    return;
                }

                string daystr = SomeDataDefs.GetPlanIdStr(daycode);

                if (daycode == EDayPlanId.BD || daycode == EDayPlanId.SD)
                {
                    if (v == 0.0f)
                        e.Value = string.Format("{0}", daystr);
                    else
                        e.Value = string.Format("{0} {1}", daystr, v);

                    e.FormattingApplied = true;
                    return;
                }

                e.Value = string.Format("{0} {1}", daystr, v);

                e.FormattingApplied = true;
            }
        }

        private void dgvPlans_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex >= dgcV1.Index && e.ColumnIndex <= dgcV31.Index)
            {
                if (e.Value == null || e.Value == DBNull.Value) return;

                if (e.Value is string)
                {
                    EDayPlanId daycode;
                    float hours;

                    if (!SomeDataDefs.ParsePlanDayStr(e.Value as string, out daycode, out hours))
                    {
                        e.Value = 0.0f;
                        e.ParsingApplied = true;
                        return;
                    }

                    int daynr = e.ColumnIndex - dgcV1.Index + 1;

                    var dr = (dgvPlans.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as KlonsADataSet.TIMESHEETRow;

                    EDayPlanId curdaycode = dr.DxPlan[daynr - 1];

                    if (daycode == EDayPlanId.None)
                        daycode = curdaycode;
                    if (daycode == EDayPlanId.BD || daycode == EDayPlanId.SD)
                        hours = 0.0f;

                    e.Value = hours;
                    e.ParsingApplied = true;

                    if (daycode != curdaycode)
                        dr.DxPlan[daynr - 1] = daycode;

                }
            }
        }

        private void dgvPlans_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[dgcYR.Index].Value = PYear;
            e.Row.Cells[dgcMT.Index].Value = PMonth;
        }

        private void cmsMenuMarkDay_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (bsPlans.Current == null || dgvPlans.CurrentCell == null || dgvPlans.CurrentRow.IsNewRow) return;
            var menuitems = new[] { miDD, miBD, miSD, miSDDD, miDDSD };
            var daycodes = new[] {EDayPlanId.DD, EDayPlanId.BD,
                EDayPlanId.SD, EDayPlanId.DDSD, EDayPlanId.SDDD };

            int i, k = -1;
            for (i = 0; i < menuitems.Length; i++)
            {
                if (menuitems[i] == e.ClickedItem)
                {
                    k = i;
                    break;
                }
            }
            if (k == -1) return;
            var dr = (bsPlans.Current as DataRowView).Row as KlonsADataSet.TIMESHEETRow;

            EDayPlanId newdaycode = daycodes[k];
            int colnr = dgvPlans.CurrentCell.ColumnIndex;
            int daynr = colnr - dgcV1.Index + 1;
            if (dr.DxPlan[daynr - 1] != newdaycode)
            {
                dr.BeginEdit();
                dr.DxPlan[daynr - 1] = newdaycode;
                dr.EndEdit();
                RefreshCell(dr, colnr);
                dgvPlans.AutoResizeColumn(colnr);
            }

        }

        private void dgvPlans_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1 || bsPlans.Current == null) return;
            if (dgvPlans.CurrentCell != null && dgvPlans.CurrentCell.IsInEditMode) return;

            var cell = dgvPlans[e.ColumnIndex, e.RowIndex];
            dgvPlans.CurrentCell = cell;
            if (dgvPlans.CurrentCell != null && dgvPlans.CurrentRow.IsNewRow) return;

            if (e.ColumnIndex >= dgcV1.Index && e.ColumnIndex <= dgcV31.Index)
            {
                var dr = (bsPlans.Current as DataRowView).Row as KlonsADataSet.TIMESHEETRow;
                if (dr.XKind1 != EKind1.PlanGroupDay) return;

                var bounds = dgvPlans.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                e.ContextMenuStrip = cmsMenuMarkDay;
            }
        }


        private void dgvPlans_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int curcol = dgvPlans.CurrentCell.ColumnIndex;
            if (curcol >= dgcV1.Index && curcol <= dgcV31.Index)
            {
                EDayPlanId daycode;
                float hours;
                if (!SomeDataDefs.ParsePlanDayStr(e.Control.Text, out daycode, out hours)) return;
                e.Control.Text = hours.ToString();
            }
        }

        private void dgvPlans_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= dgcV1.Index && e.ColumnIndex <= dgcV31.Index)
            {
                dgvPlans.AutoResizeColumn(e.ColumnIndex);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFontChanged(e);
            if (e.Cancel) return;
            dgvPlans.DataSource = null;
        }

        private void izveidotPlānaIerakstusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakePlans();
        }

        private void dgvPlans_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == dgcK1.Index)
                e.Cancel = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        public void GetIDPFromDialog()
        {
            if (bsPlans.Count == 0 || bsPlans.Current == null) return;
            if (dgvPlans.CurrentRow == null || dgvPlans.CurrentRow.IsNewRow) return;
            var fm = new Form_PlanList();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            var dr = (dgvPlans.CurrentRow.DataBoundItem as DataRowView).Row as KlonsADataSet.PIECEWORK_CATALOGRow;
            if (dgvPlans.CurrentCell != null)
            {
                try
                {
                    int ids = fm.SelectedValueInt;

                    dgvPlans.BeginEdit(false);
                    var c = dgvPlans.EditingControl as ComboBox;
                    c.SelectedValue = ids;

                    dgvPlans.EndEdit();
                }
                catch (Exception) { }
            }
        }
        private void dgvPlans_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgcIDP.Index)
            {
                GetIDPFromDialog();
            }
        }

        private void dgvPlans_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvPlans.CurrentCell == null) return;
            if (e.KeyCode == Keys.F5)
            {
                if (dgvPlans.CurrentCell.ColumnIndex == dgcIDP.Index)
                {
                    GetIDPFromDialog();
                    e.Handled = true;
                    return;
                }
            }
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                DeleteCurrent();
                e.Handled = true;
            }
        }

        private void miFillRow_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            if (CalendarMonth == null || bsPlans.Current == null) return;
            var dr = bsPlans.CurrentDataRow as KlonsADataSet.TIMESHEETRow;
            DataTasks.FillPlans(CalendarMonth, dr);
            SaveData();
        }

        private void miFillList_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            if (CalendarMonth == null || bsPlans.Count == 0) return;
            foreach(var drv in bsPlans)
            {
                var dr = (drv as DataRowView)?.Row as KlonsADataSet.TIMESHEETRow;
                if (dr == null) continue;
                DataTasks.FillPlans(CalendarMonth, dr);
            }
            SaveData();
        }
    }
}
