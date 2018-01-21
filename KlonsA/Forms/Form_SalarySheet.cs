using System;
using System.Diagnostics;
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
using KlonsLIB.MySourceGrid.GridRows;

namespace KlonsA.Forms
{
    public partial class Form_SalarySheet : MyFormBaseA
    {
        public Form_SalarySheet()
        {
            //var sw = new Stopwatch();
            //sw.Start();

            try
            {
                InitializeComponent();
                if (MyData.Params.HideTotalSheets)
                    bsLapas.Filter = "KIND = 0 AND ISFIRSTMT = FALSE";
            }
            catch (Exception e)
            {
                Form_Error.ShowException(e);
            }
            CheckMyFontAndColors();

            tslPeriod.Text = DataLoader.GetPeriodStr();
            SetupToolStrips();

            dgcPsRateType.DataSource = SomeDataDefs.ProcOrEuro;
            dgcPsRateType.DisplayMember = "Val";
            dgcPsRateType.ValueMember = "Key";

            try
            {
                MakeGrid();
            }
            catch (Exception ex)
            {
                Form_Error.ShowException(ex);
            }

            tabControl1.SelectedIndex = 0;

            ShowBonusList(!MyData.Params.HideBonusList);
            ShowPositionTitleColumn(MyData.Params.SalarySheetShowPositionTitle);
            

            //sw.Stop();
            //MessageBox.Show("" + sw.ElapsedMilliseconds);
        }

        public int ActiveList = 0;

        private void Form_SalarySheet_Load(object sender, EventArgs e)
        {
            MyData.DataSetKlons.SALARY_PLUSMINUS.ColumnChanged += SALARY_PLUSMINUS_ColumnChanged;

            WindowState = FormWindowState.Maximized;
            splitContainer2.SplitterDistance = splitContainer2.Height
                - (int)((float)80 * ScaleFactor.Height);
            //splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;

            IsLoading = false;
            OnSheetsCurrentChanged();
            OnSheetRowCurrentChanged();
            dgvLapa.Select();
        }


        private void Form_SalarySheet_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlons.SALARY_PLUSMINUS.ColumnChanged -= SALARY_PLUSMINUS_ColumnChanged;
        }


        private void SALARY_PLUSMINUS_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column == MyData.DataSetKlons.SALARY_PLUSMINUS.IDSVColumn)
            {
                var dr = e.Row as KlonsADataSet.SALARY_PLUSMINUSRow;
                if (e.ProposedValue == null || e.ProposedValue == DBNull.Value)
                {
                    if (dr.IsIDNONull()) return;
                    dr["IDNO"] = DBNull.Value;
                    dr.EndEdit();
                    return;
                }
                var bonustype = (EBonusType)e.ProposedValue;
                var allowed = SomeDataDefs.GetAllowedEBonusFrom(bonustype);
                var list = SomeDataDefs.GetBonusFromItems(allowed);
                if (list == null || list.Length == 0)
                {
                    dr["IDNO"] = DBNull.Value;
                    dr.EndEdit();
                    return;
                }
                if (dr.XBonusFrom == EBonusFrom.None || !allowed.Contains(dr.XBonusFrom))
                {
                    dr.XBonusFrom = allowed[0];
                    dr.EndEdit();
                    return;
                }
            }
        }

        private void SetupToolStrips()
        {
            InsertInToolStrip(toolStrip1, cbLapas, 1);
            InsertInToolStrip(toolStrip2, cbAmati, -1);
        }

        private void MakeGrid()
        {
            sgrAprekins.MakeGrid();
            sgrAprekins.LinkGrid();

            sgrBonus.MakeGrid();
            grbIDSV.DataCell.Editor.DefaultValue = (int)1;
            sgrBonus.LinkGrid();

            ColapseGrid();
            //sgrAprekins.ArrangeLinkedControls();
        }

        private void ColapseGrid()
        {
            grPlanTitle.Expanded = false;
            grFactTitle.Expanded = false;
            grAvPayTimeTitle.Expanded = false;
            grSalaryTitle.Expanded = false;
            grSalaryAvPayTitle.Expanded = false;
            grVacationTitle.Expanded = false;
            grSickDaysTitle.Expanded = false;
            grVSAOITitle.Expanded = false;
            grPlusMinusTitle.Expanded = false;
            grIINExemptsTitle.Expanded = false;
            grReverseTitle.Expanded = false;
            grIINTitle.Expanded = false;
        }

        public void SelectSheet(int id)
        {
            for(int i = 0; i < bsLapas.Count; i++)
            {
                var dr = (bsLapas[i] as DataRowView).Row as KlonsADataSet.SALARY_SHEETSRow;
                if(dr.ID == id)
                {
                    bsLapas.Position = i;
                    return;
                }
            }
        }

        private void OnSheetsCurrentChanged()
        {
            if (bsLapas.Current == null) return;
            var dr = (bsLapas.Current as DataRowView).Row as KlonsADataSet.SALARY_SHEETSRow;
            if (dr.KIND == 0)
            {
                bsSarR.DataMember = "FK_SALARY_SHEETS_R_IDS";
                dgcSarSnr.Visible = true;
            }
            else
            {
                bsSarR.DataMember = "FK_SALARY_SHEETS_R_IDST";
                dgcSarSnr.Visible = false;
            }
        }

        private void OnSheetRowCurrentChanged()
        {
            DataView drv;
            if (bsSarR.Current == null)
            {
                drv = new DataView(MyData.DataSetKlons.SALARY_SHEETS_R, null, null, DataViewRowState.None);
                bsSarR2.DataSource = drv;
                sgrAprekins.Visible = false;
                return;
            }
            sgrAprekins.Visible = true;
            var dr = (bsSarR.Current as DataRowView).Row as KlonsADataSet.SALARY_SHEETS_RRow;
            var filter = string.Format("IDSX = {0}", dr.IDSX);
            var dv = new DataView(MyData.DataSetKlons.SALARY_SHEETS_R, filter, null, DataViewRowState.CurrentRows);
            bsSarR2.DataSource = dv;

            if (bsSarR2.Count > 1)
            {
                tslAmati.Visible = true;
                cbAmati.Visible = true;
                for (int i = 0; i < bsSarR2.Count; i++)
                {
                    var dr2 = (bsSarR2[i] as DataRowView).Row as KlonsADataSet.SALARY_SHEETS_RRow;
                    if (dr2.ID == dr.ID)
                    {
                        bsSarR2.Position = i;
                        break;
                    }
                }
            }
            else
            {
                tslAmati.Visible = false;
                cbAmati.Visible = false;
            }

            var drvs_pers = MyData.DataSetKlons.PERSONS.DefaultView.FindRows(dr.PERSONSRow.ID);
            if (drvs_pers.Length == 0) return;

            var drv_pers = drvs_pers[0];
            var dv_am = drv_pers.CreateChildView("FK_POSITIONS_IDP");
            bsAmati.DataSource = dv_am;
            
            //dgcPsIDA.DataSource = dv_am;
            //dgcPsIDA.ValueMember = "ID";
            //dgcPsIDA.DisplayMember = "TITLE";

            if (grbIDA.ComboBoxEditor != null)
            {
                grbIDA.ComboBoxEditor.Control.SetListBinding(dv_am, "TITLE", "ID", grbIDA.ComboBoxEditor.Control.ColumnNames);
            }
        }

        private void bsLapas_CurrentChanged(object sender, EventArgs e)
        {
            if (IsLoading) return;
            OnSheetsCurrentChanged();
        }

        private void bsSarR_CurrentChanged(object sender, EventArgs e)
        {
            if (IsLoading) return;
            OnSheetRowCurrentChanged();
        }

        private void bsAlgasPapildsummas_CurrentChanged(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckEnableSGR();
        }

        private void CheckEnableSGR()
        {
            bool b1 = bsSarR.Count > 0 && bsSarR.Current != null;
            bool b2 = b1 && bsAlgasPapildsummas.Current != null;
            sgrAprekins.Enabled = b1;
            sgrBonus.Enabled = b2;
        }

        private void cbLapas_Format(object sender, ListControlConvertEventArgs e)
        {
            var drv = e.ListItem as DataRowView;
            if (drv == null) return;
            var dr = drv.Row as KlonsADataSet.SALARY_SHEETSRow;
            if (dr == null) return;
            if (dr.RowState == DataRowState.Deleted || dr.RowState == DataRowState.Detached)
                e.Value = "?";
            else
                e.Value = string.Format("{0}.{1:00} {2}. {3}", dr.YR, dr.MT, dr.SNR, dr.DESCR.Nz());
        }

        private void dgvLapa_Enter(object sender, EventArgs e)
        {
            ActiveList = 0;
            tslLabel.Text = "Aprēķins:";
            if (tabControl1.SelectedIndex != 0)
                tabControl1.SelectedIndex = 0;

            if (!IsLoading && CheckSave()) SaveData();
        }

        private void dgvPapildsummas_Enter(object sender, EventArgs e)
        {
            ActiveList = 1;
            tslLabel.Text = "Papildsummas:";
            if (tabControl1.SelectedIndex != 1)
                tabControl1.SelectedIndex = 1;
            CheckEnableSGR();
        }

        private void sgrAprekins_Enter(object sender, EventArgs e)
        {
            ActiveList = 0;
            tslLabel.Text = "Aprēķins:";
        }

        private void splitContainer2_Panel1_Enter(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex != 0)
                tabControl1.SelectedIndex = 0;
        }

        private void splitContainer2_Panel2_Enter(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 1)
                tabControl1.SelectedIndex = 1;
        }

        private int IsSaveButtonRed = -1;
        private void SetSaveButton(bool red)
        {
            int isred = red ? 1 : 0;
            if (isred == IsSaveButtonRed) return;
            IsSaveButtonRed = isred;
            Image im = null;
            if (red)
                im = global::KlonsA.Properties.Resources.Save2;
            else
                im = global::KlonsA.Properties.Resources.Save1;
            tsbSave.Image = im;
        }

        public override bool SaveData()
        {
            if (!dgvLapa.EndEditX()) return false;
            if (!dgvPapildsummas.EndEditX()) return false;

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

        private bool CheckSave()
        {
            bool ret = myAdapterManager1.HasChanges();
            SetSaveButton(ret);
            return ret;
        }

        private void dgvLapa_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            // its done in dgvLapa_Enter
            //if (CheckSave()) SaveData();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (CheckSave()) SaveData();
            CheckSave();
        }

        private void bsSarR_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (e.ListChangedType == ListChangedType.Reset) return;
            CheckSave();
        }

        private void bsAlgasPapildsummas_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (e.ListChangedType == ListChangedType.Reset) return;
            CheckSave();
        }

        public void AddNew()
        {
            if (bsLapas.Current == null) return;
            var dr_lapa = (bsLapas.Current as DataRowView).Row as KlonsADataSet.SALARY_SHEETSRow;
            int ids = dr_lapa.ID;
            int snr = bsSarR.Count + 1;
            int idp, idam;

            if(dr_lapa.XKind == ESalarySheetKind.Total)
            {
                MyMainForm.ShowWarning("Koplapa nav rediģējama.");
                return;
            }

            var f = new Form_SalarySheetNewRow();
            var ret = f.Execute(ids, ref snr, out idp, out idam);
            if (!ret) return;

            if (DataTasks.HaveSalaryRRow(dr_lapa.DT1, dr_lapa.DT2, idp, idam))
            {
                MyMainForm.ShowWarning("Šim darbiniekam-amatam algas aprēķins jau ir izveidots.");
                return;
            }

            var err = DataTasks.MakeSalarySheetRow(dr_lapa, idp, idam, snr);
            if (err != null && err.Count > 0)
            {
                Form_ErrorList.ShowErrorList(MyMainForm, err);
            }

            SaveData();
        }

        public void DeleteAlgasR()
        {
            if (bsSarR.Current == null) return;
            var dr_lapas_r = (bsSarR.Current as DataRowView).Row as KlonsADataSet.SALARY_SHEETS_RRow;
            DataTasks.DeleteSalarySheetRow(dr_lapas_r);
            SaveData();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            if (bsLapas.Current == null) return;
            var dr_lapa = (bsLapas.Current as DataRowView).Row as KlonsADataSet.SALARY_SHEETSRow;
            if (dr_lapa.XKind == ESalarySheetKind.Total)
            {
                MyMainForm.ShowWarning("Koplapa nav rediģējama.");
                return;
            }

            if (ActiveList == 0)
            {
                AddNew();
                return;
            }
            if (ActiveList == 1)
            {
                AddNewBonusRow();
                return;
            }
        }

        public void AddNewBonusRow()
        {
            var drv = bsSarR.Current as DataRowView;
            if (drv == null) return;
            var dr = drv.Row as KlonsADataSet.SALARY_SHEETS_RRow;
            var table_ps = MyData.DataSetKlons.SALARY_PLUSMINUS;
            var new_dr = table_ps.NewSALARY_PLUSMINUSRow();
            new_dr.IDP = dr.IDP;
            new_dr.IDSX = dr.ID;
            if (!dr.IsIDAMNull())
                new_dr.IDA = dr.IDAM;
            table_ps.Rows.Add(new_dr);
            bsAlgasPapildsummas.Position = bsAlgasPapildsummas.Count - 1;
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            if (bsLapas.Current == null) return;
            var dr_lapa = (bsLapas.Current as DataRowView).Row as KlonsADataSet.SALARY_SHEETSRow;
            if (dr_lapa.XKind == ESalarySheetKind.Total)
            {
                MyMainForm.ShowWarning("Koplapa nav rediģējama.");
                return;
            }
            if (ActiveList == 1)
            {
                bsAlgasPapildsummas.RemoveCurrent();
                return;
            }
            DeleteAlgasR();
        }

        private void dgvPapildsummas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == dgcPsIDNO.Index)
            {
                if (e.RowIndex == dgvPapildsummas.NewRowIndex)
                {
                    e.Cancel = true;
                    return;
                }
                var cell = dgvPapildsummas[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                var drv = dgvPapildsummas.Rows[e.RowIndex].DataBoundItem as DataRowView;
                var dr = drv.Row as KlonsADataSet.SALARY_PLUSMINUSRow;

                var allowed = SomeDataDefs.GetAllowedEBonusFrom(dr.XBonusType);
                if (allowed.Length == 0)
                {
                    e.Cancel = true;
                    return;
                }
                var list = SomeDataDefs.GetBonusFromItems(allowed);
                cell.DataSource = list;
                cell.DisplayMember = "Val";
                cell.ValueMember = "Key";
            }
        }

        private void dgvPapildsummas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgcPsIDNO.Index)
            {
                var cell = dgvPapildsummas[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                cell.DataSource = bsPapildsummaNo;
                cell.DisplayMember = "DESCR";
                cell.ValueMember = "ID";
            }
        }

        private void sgrBonus_EditStarting(object sender, CancelEventArgs e)
        {
            var gridrow = sender as MyGridRowComboBoxB;
            if (gridrow != grbIDNO || bsAlgasPapildsummas.Count == 0 || bsAlgasPapildsummas.Current == null) return;

            var drv = bsAlgasPapildsummas.Current as DataRowView;
            var dr = drv.Row as KlonsADataSet.SALARY_PLUSMINUSRow;

            var allowed = SomeDataDefs.GetAllowedEBonusFrom(dr.XBonusType);
            if (allowed.Length == 0)
            {
                e.Cancel = true;
                return;
            }
            var list = SomeDataDefs.GetBonusFromItems(allowed);
            var c = gridrow.ComboBoxEditor.Control;
            c.SetListBinding(list, "Val", "Key", new[] { "Key", "Val" });
        }

        private void sgrBonus_EditEnded(object sender, EventArgs e)
        {
            var gridrow = sender as MyGridRowComboBoxB;
            if (gridrow != grbIDNO) return;
            var c = gridrow.ComboBoxEditor.Control;
            c.SetListBinding(bsPapildsummaNo, "DESCR", "ID", new[] { "ID", "DESCR" });
        }

        private void dgvPapildsummas_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            var drv = bsSarR.Current as DataRowView;
            if (drv == null) return;
            var dr = drv.Row as KlonsADataSet.SALARY_SHEETS_RRow;
            e.Row.Cells[dgcPsIDP.Index].Value = dr.IDP;
        }

        private int titlePlanDays = int.MinValue;
        private float titlePlanHours = float.MinValue;
        private int titleFactDays = int.MinValue;
        private float titleFactHours = float.MinValue;
        private int titleAvPayDays = int.MinValue;
        private float titleAvPayHours = float.MinValue;
        private decimal titleSalary = decimal.MinValue;
        private decimal titleSalaryAvPay = decimal.MinValue;
        private decimal titleVacation = decimal.MinValue;
        private decimal titleSickDays = decimal.MinValue;
        private decimal titleVSAOI = decimal.MinValue;
        private decimal titlePlusMinus = decimal.MinValue;
        private decimal titleIINExempts = decimal.MinValue;
        private decimal titleReverseSN = decimal.MinValue;
        private decimal titleReverseIIN = decimal.MinValue;
        private decimal titleIIN = decimal.MinValue;

        private void UpdateTitleData()
        {
            if (titlePlanDays != salaryData1._PLAN_DAYS ||
                titlePlanHours != salaryData1._PLAN_HOURS)
            {
                titlePlanDays = salaryData1._PLAN_DAYS;
                titlePlanHours = salaryData1._PLAN_HOURS;
                grPlanTitle.ValueStr = string.Format("{0}; {1}", titlePlanDays, titlePlanHours);
            }

            if (titleFactDays != salaryData1._FACT_DAYS ||
                titleFactHours != salaryData1._FACT_HOURS)
            {
                titleFactDays = salaryData1._FACT_DAYS;
                titleFactHours = salaryData1._FACT_HOURS;
                grFactTitle.ValueStr = string.Format("{0}; {1}", titleFactDays, titleFactHours);
            }

            int newtitleAvPayDays = salaryData1._FACT_AVPAY_FREE_DAYS + salaryData1._FACT_AVPAY_WORK_DAYS;
            float newtitleAvPayHours = salaryData1._FACT_AVPAY_FREE_HOURS + salaryData1._FACT_AVPAY_HOURS;
            if (titleAvPayDays != newtitleAvPayDays ||
                titleAvPayHours != newtitleAvPayHours)
            {
                titleAvPayDays = newtitleAvPayDays;
                titleAvPayHours = newtitleAvPayHours;
                grAvPayTimeTitle.ValueStr = string.Format("{0}; {1}", titleAvPayDays, titleAvPayHours);
            }

            if (titleSalary != salaryData1._SALARY)
            {
                titleSalary = salaryData1._SALARY;
                grSalaryTitle.ValueStr = string.Format("{0:N2}", titleSalary);
            }

            var newtitleSalaryAvPay = salaryData1._SALARY_AVPAY_FREE_DAYS +
                salaryData1._SALARY_AVPAY_WORK_DAYS;
            if (titleSalaryAvPay != newtitleSalaryAvPay)
            {
                titleSalaryAvPay = newtitleSalaryAvPay;
                grSalaryAvPayTitle.ValueStr = string.Format("{0:N2}", titleSalaryAvPay);
            }
            
            if (titleVacation != salaryData1._VACATION_PAY_CURRENT)
            {
                titleVacation = salaryData1._VACATION_PAY_CURRENT;
                grVacationTitle.ValueStr = titleVacation.ToString("N2");
            }
            
            if (titleSickDays != salaryData1._SICKDAYS_PAY)
            {
                titleSickDays = salaryData1._SICKDAYS_PAY;
                grSickDaysTitle.ValueStr = titleSickDays.ToString("N2");
            }
            
            if (titleVSAOI != salaryData1._DNSN_AMOUNT)
            {
                titleVSAOI = salaryData1._DNSN_AMOUNT;
                grVSAOITitle.ValueStr = titleVSAOI.ToString("N2");
            }

            var newtitleIINExempts = salaryData1._IIN_EXEMPT_DEPENDANTS +
                salaryData1._IIN_EXEMPT_EXPENSES +
                salaryData1._IIN_EXEMPT_INVALIDITY +
                salaryData1._IIN_EXEMPT_NATIONAL_MOVEMENT +
                salaryData1._IIN_EXEMPT_RETALIATION +
                salaryData1._IIN_EXEMPT_UNTAXED_MINIMUM;
            if (titleIINExempts != newtitleIINExempts)
            {
                titleIINExempts = newtitleIINExempts;
                grIINExemptsTitle.ValueStr = titleIINExempts.ToString("N2");
            }

            if (titleIIN != salaryData1._IIN_AMOUNT)
            {
                titleIIN = salaryData1._IIN_AMOUNT;
                grIINTitle.ValueStr = titleIIN.ToString("N2");
            }

            if(titleReverseSN != (salaryData1._DNSN_AMOUNT_REVERSE + salaryData1._DDSN_AMOUNT_REVERSE) || 
                titleReverseIIN != salaryData1._IIN_AMOUNT_REVERSE)
            {
                titleReverseSN = salaryData1._DNSN_AMOUNT_REVERSE + salaryData1._DDSN_AMOUNT_REVERSE;
                titleReverseIIN = salaryData1._IIN_AMOUNT_REVERSE;
                grReverseTitle.ValueStr = string.Format("{0:N0}; {1:N0}", titleReverseSN, titleReverseIIN);
            }

            var newtitlePlusMinus = salaryData1._PLUS_AUTHORS_FEES +
                salaryData1._PLUS_HI_NOTTAXED +
                salaryData1._PLUS_HI_TAXED +
                salaryData1._PLUS_LI_NOTTAXED +
                salaryData1._PLUS_LI_TAXED +
                salaryData1._PLUS_NOSAI +
                salaryData1._PLUS_NOTTAXED +
                salaryData1._PLUS_NOT_PAID +
                salaryData1._PLUS_PF_NOTTAXED +
                salaryData1._PLUS_PF_TAXED +
                salaryData1._PLUS_TAXED -
                salaryData1._MINUS_BEFORE_IIN;

            if (titlePlusMinus != newtitlePlusMinus)
            {
                titlePlusMinus = newtitlePlusMinus;
                grPlusMinusTitle.ValueStr = titlePlusMinus.ToString("N2");
            }
        }

        private void sgrAprekins_ValueChanged(object sender, EventArgs e)
        {
            UpdateTitleData();
        }

        private void dgvLapa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void pārrēķinātDarbiniekamToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (bsSarR.Current == null) return;
            var dr_lapas_r = (bsSarR.Current as DataRowView)?.Row as KlonsADataSet.SALARY_SHEETS_RRow;
            if (dr_lapas_r == null) return;
            var err = DataTasks.CalcSalarySheetRow(dr_lapas_r.ID);
            if(err.HasErrors)
                Form_ErrorList.ShowErrorList(MyMainForm, err);
            SaveData();
        }

        private void pārrēķinātVisiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsSarR.Current == null) return;
            var dr_lapas_r = (bsSarR.Current as DataRowView)?.Row as KlonsADataSet.SALARY_SHEETS_RRow;
            if (dr_lapas_r == null) return;
            var err = DataTasks.CalcSalarySheet(dr_lapas_r.IDS);
            if (err.HasErrors)
                Form_ErrorList.ShowErrorList(MyMainForm, err);
            SaveData();
        }

        private void vidējāsIzpeļņasAprēķinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsSarR.Current == null) return;
            var dr_lapas_r = (bsSarR.Current as DataRowView)?.Row as KlonsADataSet.SALARY_SHEETS_RRow;
            if (dr_lapas_r == null) return;

            var ap = new AvPayCalcInfo(true);
            var err = ap.CalcList(dr_lapas_r);
            if (err.HasErrors)
            {
                Form_ErrorList.ShowErrorList(MyMainForm, err);
                return;
            }
            Form_AvPayCalc.Show(ap);
        }

        private void slimībasNaudasAprēķinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsSarR.Current == null) return;
            var dr_lapas_r = (bsSarR.Current as DataRowView)?.Row as KlonsADataSet.SALARY_SHEETS_RRow;
            if (dr_lapas_r == null) return;

            var sr = new SalarySheetRowInfo();
            var err = sr.SetUpFromRowX(dr_lapas_r);
            if (err.HasErrors)
            {
                Form_ErrorList.ShowErrorList(MyMainForm, err);
                return;
            }
            sr.CheckLinkedRows(dr_lapas_r.IDP);

            var sc = new SalaryCalcTInfo(sr.SalarySheetRowSet, new SalaryInfo(), true);
            err = sc.FillRow();
            if (err.HasErrors)
            {
                Form_ErrorList.ShowErrorList(MyData.MyMainForm, err);
                return;
            }

            SickDayCalcInfo sdc = null;

            if (dr_lapas_r.XType == ESalarySheetRowType.OnlyOne) sdc = sc.LinkedSCI[0].SickDayCalc;
            else if (dr_lapas_r.XType == ESalarySheetRowType.Total) sdc = sc.SickDayCalc;
            else sdc = sc.LinkedSCI.Where(d => d.SR.Row == dr_lapas_r).FirstOrDefault()?.SickDayCalc;

            if (sdc == null) return;

            var person = string.Format("{0} {1}, {2}", sr.DR_Person_r.FNAME, 
                sr.DR_Person_r.LNAME, sr.GetPositionTitle().Nz().ToLower());
            var period = string.Format("{0:dd.MM.yyyy} - {1:dd.MM.yyyy}", 
                sr.SalarySheet.DT1, sr.SalarySheet.DT2);
            Form_SickDaysCalc.Show(sdc, person, period);
        }

        private void atvaļinājumaNaudasAprēķinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsSarR.Current == null) return;
            var dr_lapas_r = (bsSarR.Current as DataRowView)?.Row as KlonsADataSet.SALARY_SHEETS_RRow;
            if (dr_lapas_r == null) return;

            var sr = new SalarySheetRowInfo();
            var err = sr.SetUpFromRowX(dr_lapas_r);
            if (err.HasErrors)
            {
                Form_ErrorList.ShowErrorList(MyData.MyMainForm, err);
                return;
            }
            sr.CheckLinkedRows(dr_lapas_r.IDP);

            var sc = new SalaryCalcTInfo(sr.SalarySheetRowSet, new SalaryInfo(), true);
            err = sc.FillRow();
            if (err.HasErrors)
            {
                Form_ErrorList.ShowErrorList(MyData.MyMainForm, err);
                return;
            }

            VacationCalcInfo vc = null;

            if (dr_lapas_r.XType == ESalarySheetRowType.OnlyOne) vc = sc.LinkedSCI[0].VacationCalc;
            else if (dr_lapas_r.XType == ESalarySheetRowType.Total) vc = sc.VacationCalc;
            else vc = sc.LinkedSCI.Where(d => d.SR.Row == dr_lapas_r).FirstOrDefault()?.VacationCalc;

            if (vc == null) return;


            var person = string.Format("{0} {1}, {2}", sr.DR_Person_r.FNAME,
                sr.DR_Person_r.LNAME, sr.GetPositionTitle().Nz().ToLower());
            var period = string.Format("{0:dd.MM.yyyy} - {1:dd.MM.yyyy}",
                sr.SalarySheet.DT1, sr.SalarySheet.DT2);
            Form_VacationCalc.Show(vc, person, period);
        }

        private void darbaSamaksasAprēķinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsSarR.Current == null) return;
            var dr_lapas_r = (bsSarR.Current as DataRowView)?.Row as KlonsADataSet.SALARY_SHEETS_RRow;
            if (dr_lapas_r == null) return;

            var sr = new SalarySheetRowInfo();
            var err = sr.SetUpFromRowX(dr_lapas_r);
            if (err.HasErrors)
            {
                Form_ErrorList.ShowErrorList(MyMainForm, err);
                return;
            }
            sr.CheckLinkedRows(dr_lapas_r.IDP);

            var wc = new WorkPayCalcTInfo(true);

            sr.SalarySheetRowSet.TotalPersonPay = new SalaryInfo();
            sr.SalarySheetRowSet.TotalRow.TotalPositionPay = sr.SalarySheetRowSet.TotalPersonPay;
            wc.CalcWorkPay(sr.SalarySheetRowSet, sr.SalarySheetRowSet.TotalPersonPay);

            if (err.HasErrors)
            {
                Form_ErrorList.ShowErrorList(MyMainForm, err);
                return;
            }

            var person = string.Format("{0} {1}, {2}", sr.DR_Person_r.FNAME,
                sr.DR_Person_r.LNAME, sr.GetPositionTitle().Nz().ToLower());
            var period = string.Format("{0:dd.MM.yyyy} - {1:dd.MM.yyyy}",
                sr.SalarySheet.DT1, sr.SalarySheet.DT2);
            Form_WorkPayCalc.Show(wc, person, period);
        }

        private void miAprekinaSeciba_Click(object sender, EventArgs e)
        {
            if (bsSarR.Current == null) return;
            var dr_lapas_r = (bsSarR.Current as DataRowView)?.Row as KlonsADataSet.SALARY_SHEETS_RRow;
            if (dr_lapas_r == null) return;


            var sr = new SalarySheetRowInfo();
            var err = sr.SetUpFromRowX(dr_lapas_r);
            if (err.HasErrors)
            {
                Form_ErrorList.ShowErrorList(MyData.MyMainForm, err);
                return;
            }
            sr.CheckLinkedRows(dr_lapas_r.IDP);

            var sc = new SalaryCalcTInfo(sr.SalarySheetRowSet, new SalaryInfo(), true);
            err = sc.FillRow();
            if (err.HasErrors)
            {
                Form_ErrorList.ShowErrorList(MyData.MyMainForm, err);
                return;
            }

            PayFxA pfxa = null;
            if (dr_lapas_r.XType == ESalarySheetRowType.OnlyOne) pfxa = sc.LinkedSCI[0].PFxA;
            else if (dr_lapas_r.XType == ESalarySheetRowType.Total) pfxa = sc.PFxB;
            else pfxa = sc.LinkedSCI.Where(d => d.SR.Row == dr_lapas_r).FirstOrDefault()?.PFxA;

            if (pfxa == null) return;

            var person = string.Format("{0} {1}, {2}", sr.DR_Person_r.FNAME,
                sr.DR_Person_r.LNAME, sr.GetPositionTitle().Nz().ToLower());
            var period = string.Format("{0:dd.MM.yyyy} - {1:dd.MM.yyyy}",
                sr.SalarySheet.DT1, sr.SalarySheet.DT2);
            Form_PayFx.Show(pfxa, person, period);
        }


        private void aprēķinaIzklāstsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsSarR.Current == null) return;
            var dr_lapas_r = (bsSarR.Current as DataRowView)?.Row as KlonsADataSet.SALARY_SHEETS_RRow;
            if (dr_lapas_r == null) return;

            Report_SalaryCalc1.MakeReport1(dr_lapas_r);
        }

        public void ShowBonusList(bool b)
        {
            splitContainer2.Panel2Collapsed = !b;
            miShoeBonusList.Checked = b;
            MyData.Params.HideBonusList = !b;
        }

        public void ShowPositionTitleColumn(bool b)
        {
            dgcSarPositionTitle.Visible = b;
            miRādītDarbiniekuAmatus.Checked = b;
            MyData.Params.SalarySheetShowPositionTitle = b;
        }

        private void miShoeBonusList_Click(object sender, EventArgs e)
        {
            ShowBonusList(splitContainer2.Panel2Collapsed);
        }

        private void miRādītDarbiniekuAmatus_Click(object sender, EventArgs e)
        {
            ShowPositionTitleColumn(!dgcSarPositionTitle.Visible);
        }


        private void arAmatiemBezParakstiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsLapas.Count == 0 || bsLapas.Current == null) return;
            var dr = (bsLapas.Current as DataRowView).Row as KlonsADataSet.SALARY_SHEETSRow;
            Report_Salary2.MakeReport(dr, Report_Salary2.ERepType.WithPosNoSign);
        }

        private void bezAmatiemArParakstiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsLapas.Count == 0 || bsLapas.Current == null) return;
            var dr = (bsLapas.Current as DataRowView).Row as KlonsADataSet.SALARY_SHEETSRow;
            Report_Salary2.MakeReport(dr, Report_Salary2.ERepType.NoPosWithSign);
        }

    }


}
