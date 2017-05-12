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
using KlonsLIB.Data;
using KlonsLIB.Misc;

namespace KlonsP.Forms
{
    public partial class Form_TaxDeprecYR : MyFormBaseP
    {
        public Form_TaxDeprecYR()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            InsertInToolStrip(toolStrip1, cbYear, 3);
            SetYears();
        }

        private void Form_TaxDeprecYR_Load(object sender, EventArgs e)
        {

        }

        private int Year1 = 0;
        private int Year2 = 0;
        private int YearCurrent = 0;
        private bool IgnoreYearSelectEvents = false;


        public override bool SaveData()
        {
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
            SetSaveButton(myAdapterManager1.HasChanges());
        }

        private void SetSaveButton(bool red)
        {
            tsbSave.Image = red ? Properties.Resources.Save2 : Properties.Resources.Save1;
        }

        public bool GetYears(out int yr1, out int yr2)
        {
            yr1 = yr2 = 0;
            var table = MyData.DataSetKlons.TAXDEPRECYEAR;
            var drs = table.WhereNotDeleted();
            if (drs.Count() == 0) return false;
            yr1 = drs.Min(d => d.YR);
            yr2 = drs.Max(d => d.YR);
            return true;
        }
            
        public void SetYears(int setyr = 0)
        {
            int yr1 = 0, yr2 = 0;
            GetYears(out yr1, out yr2);
            if (yr1 == Year1 && yr2 == Year2) return;
            Year1 = yr1;
            Year2 = yr2;

            IgnoreYearSelectEvents = true;

            cbYear.Items.Clear();
            if (Year1 == 0)
            {
                SetCurrentYear(0);
            }
            else
            {
                for (int i = Year1; i <= Year2; i++)
                    cbYear.Items.Add(i.ToString());

                if (setyr != 0 && setyr != YearCurrent && 
                    setyr >= Year1 && setyr <= Year2)
                {
                    SetCurrentYear(setyr);
                }
                else if (YearCurrent < Year1 || YearCurrent > Year2)
                {
                    SetCurrentYear(Year2);
                }
            }

            IgnoreYearSelectEvents = false;
        }

        public void SetCurrentYear(int yr)
        {
            if (YearCurrent == yr) return;
            YearCurrent = yr;
            if (yr == 0) return;
            bsRows.Filter = "YR=" + yr;
            bool b = IgnoreYearSelectEvents;
            IgnoreYearSelectEvents = false;
            if (cbYear.SelectedIndex != yr - Year1)
                cbYear.SelectedIndex = yr - Year1;
            IgnoreYearSelectEvents = b;
        }

        public int GetYearToAdd()
        {
            int yr = 0;
            if (MyData.DataSetKlons.ITEMS.WhereNotDeleted().Count() == 0)
            {
                MyMainForm.ShowWarning("Pamatlīdzekļu saraksts ir tukšs.");
                return 0;
            }

            if (Year2 > 0)
            {
                yr = Year2 + 1;
            }
            else
            {
                yr = DateTime.Today.Year;
            }

            var fm = new Form_InputBox(
                "Pievoenot nolietojuma aprēķina gadu",
                "Gads",
                yr.ToString());
            if (fm.ShowDialog(MyMainForm) != DialogResult.OK) return 0;
            if (string.IsNullOrEmpty(fm.SelectedValue))
            {
                MyMainForm.ShowWarning("Netika norādīts gads.");
                return 0;
            }
            if (!int.TryParse(fm.SelectedValue, out yr) || yr < 1900 || yr > 2100)
            {
                MyMainForm.ShowWarning("Norādīts nekorekts gads.");
                return 0;
            }

            if (MyData.DataSetKlons.TAXDEPRECYEAR.WhereX(d => d.YR == yr).Count() > 0)
            {
                MyMainForm.ShowWarning("Norādītajam gadam jau ir izveidoti dati.");
                return 0;
            }
            return yr;
        }

        public List<TaxDeprecCalcInfo> CalcYear(int yr, bool addstartvalues)
        {
            var ReportMovement = new Report_Movement();
            ReportMovement.DoFilter = false;
            ReportMovement.DT1 = new DateTime(yr, 1, 1);
            ReportMovement.DT2 = new DateTime(yr, 12, 31);

            ReportMovement.DoFilter = false;
            ReportMovement.AddTotals = false;

            ReportMovement.DoGrouping = true;
            ReportMovement.GroupOrderCat1 = -1;
            ReportMovement.GroupOrderCatD = -1;
            ReportMovement.GroupOrderCatT = 0;
            ReportMovement.GroupOrderDep = -1;
            ReportMovement.GroupOrderPlace = -1;

            ReportMovement.MakeGroupReport();

            var table_deprec = MyData.DataSetKlons.TAXDEPRECYEAR;
            var table_catt = MyData.DataSetKlons.CATT;

            var drs_new = new List<TaxDeprecCalcInfo>();
            var drs_prev = table_deprec.WhereX(d => d.YR == yr - 1).ToList();

            foreach (var evr in ReportMovement.ReportRows)
            {
                var dr_new = new TaxDeprecCalcInfo();
                var dr_catt = table_catt.FindByID(evr.CatT);
                var dr_prev = drs_prev.Where(d => d.CATT == evr.CatT).FirstOrDefault();

                drs_new.Add(dr_new);

                dr_new.YR = yr;
                dr_new.CatID = evr.CatT;
                dr_new.CountAtEnd = evr.CountAtEnd;
                dr_new.Rate = dr_catt.RATE / 100.0f;
                dr_new.Kind = dr_catt.KIND;

                dr_new.ValueC = evr.TaxValNewCalc + evr.TaxValAddCalc 
                    + evr.TaxValRecatCalc - evr.TaxValExcludeCalc;
                dr_new.ValueNew = evr.TaxValNewCalc;
                dr_new.ValueAdd = Math.Max(evr.TaxValAddCalc, 0.0M);
                dr_new.ValueRem = -Math.Min(evr.TaxValAddCalc, 0.0M);
                dr_new.ValueAdd += Math.Max(evr.TaxValRecatCalc, 0.0M);
                dr_new.ValueRem += -Math.Min(evr.TaxValRecatCalc, 0.0M);
                dr_new.ValueExclude = evr.TaxValExcludeCalc;

                if (dr_new.Kind == 0)
                {
                    if (addstartvalues)
                    {
                        dr_new.Value0 = dr_catt.VALUE0;
                    }
                    else if (dr_prev != null)
                    {
                        dr_new.Value0 = dr_prev.VALUE1;
                    }
                    if (dr_prev != null)
                    {
                        dr_new.ValueCor = dr_prev.VALUE_COR;
                    }

                    dr_new.ValueCor += dr_new.ValueC;
                    dr_new.ValueD = dr_new.Value0 + dr_new.ValueC;
                }
                else
                {
                    dr_new.Value0 = evr.TaxValLeft0;
                    dr_new.Deprec = evr.TaxDeprecCalc;
                    dr_new.Value1 = evr.TaxValLeft1;
                    dr_new.ValueCor = evr.TaxVal;
                    dr_new.ValueD = dr_new.Value0 + dr_new.ValueC;
                }

            }

            var drs_prev2 = drs_prev
                .Where(d =>
                    d.VALUE1 != 0.0M &&
                    drs_new
                        .Where(d2 => d2.CatID == d.CATT)
                        .FirstOrDefault() == null)
                .ToList();

            foreach (var dr_prev in drs_prev2)
            {
                var dr_new = new TaxDeprecCalcInfo();
                var dr_catt = table_catt.FindByID(dr_prev.ID);
                drs_new.Add(dr_new);

                dr_new.YR = yr;
                dr_new.CatID = dr_prev.ID;
                dr_new.Rate = dr_catt.RATE / 100.0f;
                dr_new.Kind = dr_catt.KIND;
                dr_new.Value0 = dr_prev.VALUE1;
                dr_new.ValueCor = dr_prev.VALUE_COR;
                dr_new.ValueD = dr_new.Value0;
            }

            if (addstartvalues)
            {
                var drs_catt_toadd = table_catt
                    .WhereX(d =>
                        d.VALUE0 != 0.0M &&
                        drs_new
                            .Where(d2 => d2.CatID == d.ID)
                            .FirstOrDefault() == null);

                foreach(var dr_catt in drs_catt_toadd)
                {
                    var dr_new = new TaxDeprecCalcInfo();
                    drs_new.Add(dr_new);

                    dr_new.YR = yr;
                    dr_new.CountAtEnd = 0;
                    dr_new.CatID = dr_catt.ID;
                    dr_new.Rate = dr_catt.RATE / 100.0f;
                    dr_new.Kind = dr_catt.KIND;
                    dr_new.Value0 = dr_catt.VALUE0;
                    dr_new.ValueCor = dr_new.Value0;
                    dr_new.ValueD = dr_new.Value0;
                }
            }

            foreach(var dr_new in drs_new)
            {
                var va = dr_new.Value0 + dr_new.ValueC;
                if (dr_new.Kind == 0)
                {
                    if(va < 71.14M || dr_new.CountAtEnd == 0)
                    {
                        dr_new.Deprec = va;
                    }
                    else
                    {
                        dr_new.Deprec = Math.Round(va * (decimal)dr_new.Rate, 2, MidpointRounding.AwayFromZero);
                    }
                }
                dr_new.Value1 = va - dr_new.Deprec;
            }

            return drs_new;
        }

        public bool UpdateYear(int yr, bool addstartvalues)
        {
            var drs_calc = CalcYear(yr, addstartvalues);

            var table_deprec = MyData.DataSetKlons.TAXDEPRECYEAR;
            var table_catt = MyData.DataSetKlons.CATT;

            var drs_prev = table_deprec
                .WhereX(d => d.YR == yr)
                .ToList();

            var drs_delete = drs_prev
                .Where(d =>
                    drs_calc
                        .Where(d2 => d2.CatID == d.CATT)
                        .FirstOrDefault() == null)
                .ToList();

            foreach (var dr_calc in drs_calc)
            {
                var dr_prev = drs_prev
                    .Where(d => d.CATT == dr_calc.CatID)
                    .FirstOrDefault();

                if (dr_prev == null)
                {
                    dr_prev = table_deprec.NewTAXDEPRECYEARRow();
                    dr_prev.CATT = dr_calc.CatID;
                    dr_prev.YR = yr;
                    table_deprec.AddTAXDEPRECYEARRow(dr_prev);
                }

                dr_prev.BeginEdit();

                dr_prev.RATE = dr_calc.Rate;
                dr_prev.KIND = dr_calc.Kind;
                dr_prev.COUNT = dr_calc.CountAtEnd;
                dr_prev.VALUE0 = dr_calc.Value0;
                dr_prev.VALUEC = dr_calc.ValueC;
                dr_prev.DEPREC = dr_calc.Deprec;
                dr_prev.VALUE1 = dr_calc.Value1;
                dr_prev.VALUE_NEW = dr_calc.ValueNew;
                dr_prev.VALUE_ADD = dr_calc.ValueAdd;
                dr_prev.VALUE_REM = dr_calc.ValueRem;
                dr_prev.VALUE_EXCL = dr_calc.ValueExclude;
                dr_prev.VALUE_COR = dr_calc.ValueCor;
                dr_prev.VALUED = dr_calc.ValueD;

                dr_prev.EndEditX();
            }

            foreach (var dr_delete in drs_delete)
                dr_delete.Delete();

            return true;
        }

        public bool AddYear(int yr, bool addstartvalues)
        {
            return UpdateYear(yr, addstartvalues);
        }

        public void DoAddNewYear()
        {
            int yr = GetYearToAdd();
            if (yr == 0) return;
            var table_deprec = MyData.DataSetKlons.TAXDEPRECYEAR;
            var table_catt = MyData.DataSetKlons.CATT;
            bool addStartValue = false;
            if (table_deprec.WhereNotDeleted().Count() == 0 &&
                table_catt.WhereX(d => d.VALUE0 != 0.0M).Count() > 0)
            {
                var rt = MyMessageBox.Show("Vai izmantot sākuma atlikumus no kategoriju saraksta?",
                    "Nolietojums nodokļu vajadzībām", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (rt == DialogResult.Cancel) return;
                addStartValue = rt == DialogResult.Yes;
            }
            AddYear(yr, addStartValue);
            SaveData();
            SetYears(yr);
        }

        public void DoRecalc()
        {
            int yr = YearCurrent;
            if (yr == 0) return;
            for(int i = yr; i <= Year2; i++)
            {
                bool addStartValue = i == Year1;
                UpdateYear(i, addStartValue);
            }
            SaveData();
        }

        public void DeleteYear(int yr)
        {
            var table_deprec = MyData.DataSetKlons.TAXDEPRECYEAR;
            var drs_delete = table_deprec
                .WhereX(d => d.YR == yr)
                .ToList();
            drs_delete.ForEach(d => d.Delete());
            SetYears();
        }

        public void DeleteLastYear()
        {
            if (YearCurrent == 0) return;
            if (YearCurrent != Year2)
            {
                MyMainForm.ShowWarning("Dzēst var tikai pēdējo gadu.");
                return;
            }
            DeleteYear(Year2);
            SaveData();
        }

        private void MakeReport()
        {
            ReportViewerData rd = new ReportViewerData();
            rd.FileName = "ReportP_NodNolGads_1";
            rd.Sources["dsRows"] = bsRows;
            rd.AddReportParameters(
                new string[]
                {
                    "PCompany", MyData.Params.CompNameX,
                    "PYear", YearCurrent.ToString()
                });
            MyMainForm.ShowReport(rd);

        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IgnoreYearSelectEvents) return;
            if (Year1 == 0) return;
            int k = cbYear.SelectedIndex;
            if (k == -1)
                SetCurrentYear(0);
            else
                SetCurrentYear(Year1 + k);
        }

        private void tsbFirst_Click(object sender, EventArgs e)
        {
            if (Year1 == 0) return;
            IgnoreYearSelectEvents = true;
            SetCurrentYear(Year1);
            IgnoreYearSelectEvents = false;
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            if (Year1 == 0 || Year1 == YearCurrent) return;
            IgnoreYearSelectEvents = true;
            SetCurrentYear(YearCurrent - 1);
            IgnoreYearSelectEvents = false;
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (Year1 == 0 || Year2 == YearCurrent) return;
            IgnoreYearSelectEvents = true;
            SetCurrentYear(YearCurrent + 1);
            IgnoreYearSelectEvents = false;
        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            if (Year1 == 0) return;
            IgnoreYearSelectEvents = true;
            SetCurrentYear(Year2);
            IgnoreYearSelectEvents = false;
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            DoAddNewYear();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteLastYear();
        }

        private void tsbRecalc_Click(object sender, EventArgs e)
        {
            DoRecalc();
        }

        private void tsbReport_Click(object sender, EventArgs e)
        {
            if (bsRows.Count == 0 || YearCurrent == 0 || Year1 == 0)
            {
                MyMainForm.ShowInfo("Pārskatam nav datu.");
                return;
            }
            MyData.ReportHelper.CheckForErrors(() =>
            {
                MakeReport();
            });
        }
    }

    public class TaxDeprecCalcInfo
    {
        public int CatID = 0;
        public int YR = 0;
        public int CountAtEnd = 0;
        public int Kind = 0;
        public float Rate = 0.0f;
        public decimal Value0 = 0.0M;
        public decimal Value1 = 0.0M;
        public decimal ValueC = 0.0M;
        public decimal Deprec = 0.0M;
        public decimal ValueNew = 0.0M;
        public decimal ValueAdd = 0.0M;
        public decimal ValueRem = 0.0M;
        public decimal ValueExclude = 0.0M;
        public decimal ValueCor = 0.0M;
        public decimal ValueD = 0.0M;
    }
}
