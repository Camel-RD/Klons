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
    public partial class Form_PersonsR : MyFormBaseA
    {
        public Form_PersonsR()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                Form_Error.ShowException(e);
            }
            CheckMyFontAndColors();

            ShowOnlyUsed = MyData.Params.PersDataOnlyUsed;
        }

        private ToolStripControlHost dateSelectorItem = null;
        private bool InSwitchingTabs = false;

        public enum ESelectedTab
        {
            pamatdati,
            piemaksas,
            atvilkumi,
            pieņemts_atlaists,
            atvaļinājumi,
            slimības,
            citi,
            visi_notikumi
        }

        public ESelectedTab SelectedTab = ESelectedTab.pamatdati;

        private void Form_PersonsR_Load(object sender, EventArgs e)
        {
            if (bsPersons.Count == 0)
            {
                MyMainForm.ShowInfo("Darbinieku saraksts it tukšs.");
                this.Close();
                return;
            }

            SetupToolStrips();

            try
            {
                MakeGrid();
            }
            catch (Exception ex)
            {
                Form_Error.ShowException(ex);
            }

            cbSelectTab.SelectedIndex = 0;

            dgcPSRateType.DataSource = SomeDataDefs.ProcOrEuro;
            dgcPSRateType.DisplayMember = "Val";
            dgcPSRateType.ValueMember = "Key";

            sgrPersR.Select();

            MyData.DataSetKlons.POSITIONS_PLUSMINUS.ColumnChanged += POSITIONS_PLUSMINUS_ColumnChanged;

            LoadSettings();

            CheckEventsForAll();

            this.bsPersonsR.CurrentChanged += new System.EventHandler(this.bsPersonsR_CurrentChanged);
        }

        public void LoadSettings()
        {
            ShowPersonsList(MyData.Settings.ShowPersonList);
        }

        public void SaveSettings()
        {
            MyData.Settings.ShowPersonList = !mySplitContainer1.Panel1Collapsed;
        }

        private void Form_PersonsR_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlons.POSITIONS_PLUSMINUS.ColumnChanged -= POSITIONS_PLUSMINUS_ColumnChanged;
        }

        private void POSITIONS_PLUSMINUS_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column == MyData.DataSetKlons.POSITIONS_PLUSMINUS.IDSVColumn)
            {
                var dr = e.Row as KlonsADataSet.POSITIONS_PLUSMINUSRow;
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
            var k = bnavNav.Items.IndexOf(this.bnavNavPosItem);
            dateSelectorItem = InsertInToolStrip(bnavNav, cbDates, k);

            InsertInToolStrip(toolStrip1, cbPersons, 0);
            InsertInToolStrip(toolStrip1, cbAmati, 2);
            InsertInToolStrip(toolStrip1, cbSelectTab, 4);
        }

        private void MakeGrid()
        {
            sgrPersR.MakeGrid();
            sgrAmati.MakeGrid();

            sgrPersR.LinkGrid();
            sgrPersR.ArrangeLinkedControls();

            sgrAmati.LinkGrid();
            sgrAmati.ArrangeLinkedControls();
        }

        public override bool SaveData()
        {
            if (!this.Validate()) return false;
            try
            {
                DataTasks.SetNewIDs(MyAdapterManager1);
                MyAdapterManager1.UpdateAll();
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

        private void SetSaveButton(bool red)
        {
            bnavNav.SetSaveButton(tsbSave, red);
        }

        private void CheckSave()
        {
            SetSaveButton(MyAdapterManager1.HasChanges());
        }


        private void SetNavPosItemType()
        {
            var b1 = bnavNav.BindingSource == bsPersonsR || bnavNav.BindingSource == bsAmatiR;
            bnavNavPosItem.Visible = !b1;
            bnavNavCountItem.Visible = !b1;
            dateSelectorItem.Visible = b1;
            if (bnavNav.BindingSource == bsPersonsR)
            {
                int k = bsPersonsR.Position;
                cbDates.DataSource = bsPersonsR;
                cbDates.DisplayMember = "EDIT_DATE";
                cbDates.ValueMember = "EDIT_DATE";
                //bsPersonsR.Position = k;
                cbDates.SelectedIndex = k;
            }
            else if (bnavNav.BindingSource == bsAmatiR)
            {
                int k = bsAmatiR.Position;
                cbDates.DataSource = bsAmatiR;
                cbDates.DisplayMember = "EDIT_DATE";
                cbDates.ValueMember = "EDIT_DATE";
                //bsAmatiR.Position = k;
                cbDates.SelectedIndex = k;
            }
        }

        private void sgrPersR_Enter(object sender, EventArgs e)
        {
            bnavNav.BindingSource = bsPersonsR;
            tslLabel.Text = "Darbinieks:";
            SetNavPosItemType();
        }

        private void sgrAmati_Enter(object sender, EventArgs e)
        {
            bnavNav.BindingSource = bsAmatiR;
            tslLabel.Text = "Amats:";
            SetNavPosItemType();
        }
        private void dgvPapildSummas_Enter(object sender, EventArgs e)
        {
            bnavNav.BindingSource = bsPapildSummas;
            tslLabel.Text = "Summas:";
            SetNavPosItemType();
        }
        private void dgvNotikumi_Enter(object sender, EventArgs e)
        {
            bnavNav.BindingSource = bsNotikumi;
            tslLabel.Text = "Notikumi:";
            SetNavPosItemType();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bsPersonsR_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (e.ListChangedType == ListChangedType.Reset) return;
            CheckSave();
        }

        private void bsAmatiR_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (e.ListChangedType == ListChangedType.Reset) return;
            CheckSave();
        }

        private void bsNotikumi_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (e.ListChangedType == ListChangedType.Reset) return;
            CheckSave();
        }

        private void bsPapildSummas_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (e.ListChangedType == ListChangedType.Reset) return;
            CheckSave();
        }

        private void bsPersons_CurrentChanged(object sender, EventArgs e)
        {
            if (bsPersonsR.Count > 0)
                bsPersonsR.Position = 0;
        }
        private void bsAmati_CurrentChanged(object sender, EventArgs e)
        {
            if (bsAmatiR.Count > 0)
                bsAmatiR.Position = 0;
        }

        private void AddPersonsRRow()
        {
            var drv_cur_p = bsPersons.Current as DataRowView;
            if (drv_cur_p == null) return;
            var row_cur_p = drv_cur_p.Row as KlonsADataSet.PERSONSRow;
            if (row_cur_p == null) return;

            if (bsPersonsR.Count == 0) return;

            var drv_last_pr = bsPersonsR[bsPersonsR.Count - 1] as DataRowView;
            var row_last_pr = drv_last_pr.Row as KlonsADataSet.PERSONS_RRow;

            var lastdt = row_last_pr.EDIT_DATE;
            if (lastdt == DateTime.Today)
            {
                MyMainForm.ShowWarning("Jaunu labojumu nevar izveidot, jo\n" +
                                       "labojums ar šodienas dautunu jau ir izveidots.");
                return;
            }

            var table_pr = MyData.DataSetKlons.PERSONS_R;
            var row_new_pr = DataSetHelper.CopyRow(row_last_pr, null, -1) as KlonsADataSet.PERSONS_RRow;

            row_new_pr.EDIT_DATE = DateTime.Today;
            if (!string.IsNullOrEmpty(row_cur_p.FNAME)) row_new_pr.FNAME = row_cur_p.FNAME;
            if (!string.IsNullOrEmpty(row_cur_p.LNAME)) row_new_pr.LNAME = row_cur_p.LNAME;
            if (!string.IsNullOrEmpty(row_cur_p.PK)) row_new_pr.PERSON_CODE = row_cur_p.PK;
            table_pr.AddPERSONS_RRow(row_new_pr);

            bsPersonsR.Position = 0;
        }

        private void AddAmatiRRow()
        {
            var drv_cur_am = bsAmati.Current as DataRowView;
            if (drv_cur_am == null) return;
            var row_cur_am = drv_cur_am.Row as KlonsADataSet.POSITIONSRow;
            if (row_cur_am == null) return;

            if (bsAmatiR.Count == 0) return;

            var drv_last_amr = bsAmatiR[bsAmatiR.Count - 1] as DataRowView;
            var row_last_amr = drv_last_amr.Row as KlonsADataSet.POSITIONS_RRow;

            var lastdt = row_last_amr.EDIT_DATE;
            if (lastdt == DateTime.Today)
            {
                MyMainForm.ShowWarning("Jaunu labojumu nevar izveidot, jo\n" +
                                       "labojums ar šodienas dautunu jau ir izveidots.");
                return;
            }

            var table_amr = MyData.DataSetKlons.POSITIONS_R;
            var row_new_amr = DataSetHelper.CopyRow(row_last_amr, null, -1) as KlonsADataSet.POSITIONS_RRow;

            row_new_amr.EDIT_DATE = DateTime.Today;
            if (!string.IsNullOrEmpty(row_cur_am.TITLE)) row_new_amr.TITLE = row_cur_am.TITLE;
            if (!string.IsNullOrEmpty(row_cur_am.IDDEP)) row_new_amr.IDDEP = row_cur_am.IDDEP;
            table_amr.AddPOSITIONS_RRow(row_new_amr);

            bsAmatiR.Position = 0;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            if (bnavNav.BindingSource == bsPersonsR)
            {
                AddPersonsRRow();
            }
            if (bnavNav.BindingSource == bsAmatiR)
            {
                AddAmatiRRow();
            }
            if (bnavNav.BindingSource == bsPapildSummas)
            {
                dgvPapildSummas.MoveToNewRow();
            }
            if (bnavNav.BindingSource == bsNotikumi)
            {
                dgvNotikumi.MoveToNewRow();
            }
        }

        public void DeleteCurrent()
        {
            if (!Validate()) return;
            if (bnavNav.BindingSource.Current == null) return;
            if (!AskCanDelete()) return;
            if (bnavNav.BindingSource == bsPersonsR || bnavNav.BindingSource == bsAmatiR)
            {
                if (bnavNav.BindingSource.Count == 1)
                {
                    MyMainForm.ShowWarning("Nedrīkst dzēs vienīgo datu redakcijas ierakstu.");
                    return;
                }
            }
            if (bnavNav.BindingSource == bsPapildSummas)
            {
                if (dgvPapildSummas.CurrentRow == null || dgvPapildSummas.CurrentRow.IsNewRow)
                    return;
            }
            if (bnavNav.BindingSource == bsNotikumi)
            {
                if (dgvNotikumi.CurrentRow == null || dgvNotikumi.CurrentRow.IsNewRow)
                    return;
            }


            bnavNav.BindingSource.RemoveCurrent();
            SaveData();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void dgvPapildSummas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvPapildSummas.EndEdit()) return;
                dgvPapildSummas.MoveToNewRow();
                e.Handled = true;
                return;
            }
        }

        private void dgvNotikumi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvNotikumi.EndEdit()) return;
                dgvNotikumi.MoveToNewRow();
                e.Handled = true;
                return;
            }
        }


        private void cbDates_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.Value == null || !(e.Value is DateTime)) return;
            e.Value = Utils.DateToString((DateTime)e.Value);
        }

        private int GetPapildSummasTP1(int id)
        {
            var dr = MyData.DataSetKlons.PLUSMINUS_TYPES.FindByID(id);
            if (dr == null) return -1;
            return dr.TP1;
        }
        private int GetNotikumaVeidsTP1(int id)
        {
            var dr = MyData.DataSetKlons.EVENT_TYPES.FindByID(id);
            if (dr == null) return -1;
            return dr.TP1;
        }


        private void cbSelectTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int k = cbSelectTab.SelectedIndex;
            int tp1;
            if (k == 0)
            {
                InSwitchingTabs = true;
                tabControl1.SelectedIndex = 0;
                SelectedTab = ESelectedTab.pamatdati;
                InSwitchingTabs = false;
                return;
            }

            if (bsPersons.Current == null) return;

            if (k == 1 || k == 2)
            {

                tp1 = k == 1 ? 1 : 0;
                bsPapildSummasVeids.RemoveFilter();
                bsPapildSummas.Filter = "Parent(FK_POSITIONS_PLUSMINUS_IDSV).TP1 = " + tp1;
                bsPapildSummasVeids.Filter = "TP3 = 1 AND TP1 = " + tp1;
                SelectedTab = k == 1 ? ESelectedTab.piemaksas : ESelectedTab.atvilkumi;
                InSwitchingTabs = true;
                tabControl1.SelectedIndex = 1;
                InSwitchingTabs = false;
                return;
            }
            if (k >= 3 && k <= 7)
            {
                switch (k)
                {
                    case 3:
                        tp1 = 0;
                        SelectedTab = ESelectedTab.pieņemts_atlaists;
                        break;
                    case 4:
                        tp1 = 1;
                        SelectedTab = ESelectedTab.atvaļinājumi;
                        break;
                    case 5:
                        tp1 = 2;
                        SelectedTab = ESelectedTab.slimības;
                        break;
                    case 6:
                        tp1 = 3;
                        SelectedTab = ESelectedTab.citi;
                        break;
                    case 7:
                        tp1 = -1;
                        SelectedTab = ESelectedTab.visi_notikumi;
                        break;
                    default:
                        tp1 = -1;
                        break;
                }

                if (tp1 == -1)
                {
                    bsNotikumuVeidi.RemoveFilter();
                    bsNotikumi.RemoveFilter();
                }
                else
                {
                    bsNotikumuVeidi.RemoveFilter();
                    bsNotikumi.Filter = "Parent(FK_EVENTS_IDN).TP1 = " + tp1;
                    bsNotikumuVeidi.Filter = "TP1 = " + tp1;
                }

                InSwitchingTabs = true;
                tabControl1.SelectedIndex = 2;
                InSwitchingTabs = false;

                dgcNotIDA.Visible = SelectedTab != ESelectedTab.atvaļinājumi &&
                    SelectedTab != ESelectedTab.slimības;
                dgcNotIDN2.Visible = SelectedTab == ESelectedTab.citi ||
                    SelectedTab == ESelectedTab.visi_notikumi;
                dgcNotDate2.Visible = SelectedTab != ESelectedTab.pieņemts_atlaists;
                dgcNotDT3.Visible = SelectedTab == ESelectedTab.atvaļinājumi;
                dgcNotDays.Visible = SelectedTab == ESelectedTab.atvaļinājumi ||
                    SelectedTab == ESelectedTab.pieņemts_atlaists;
                dgcNotOcc.Visible = SelectedTab == ESelectedTab.pieņemts_atlaists;
                return;
            }
        }
    

        private void dgvPapildSummas_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcPSDate1.Index || e.ColumnIndex == dgcPSDate2.Index)
            {
                Utils.DGVParseDateCell(e);
            }
        }

        private void dgvNotikumi_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcNotDate1.Index ||
                e.ColumnIndex == dgcNotDate2.Index ||
                e.ColumnIndex == dgcNotDT3.Index)
            {
                Utils.DGVParseDateCell(e);
            }
        }

        private void dgvPapildSummas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void dgvNotikumi_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void dgvNotikumi_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (bsPersons.Current == null) return;
            var idp = (int)(bsPersons.Current as DataRowView)[0];
            e.Row.Cells[dgcNotIDP.Index].Value = idp;
        }

        private void CheckdgvNotikumiColumns()
        {
            if (dgvNotikumi.CurrentRow == null || dgvNotikumi.CurrentRow.IsNewRow)
            {
                dgcNotDT3.Visible = false;
                return;
            }
            object oidn = dgvNotikumi.CurrentRow.Cells[dgcNotIDN.Index].Value;
            bool b = oidn != null && SomeDataDefs.EventHasPayDate((EEventId)oidn);
            dgcNotDT3.Visible = b;
            b = oidn != null && SomeDataDefs.IsFromToEvent((EEventId)oidn);
            dgcNotDate2.Visible = b;
            b = oidn != null && ((EEventId)oidn) == EEventId.Atvaļinājums;
            dgcNotDays.Visible = b;
        }

        private void bsNotikumi_CurrentChanged(object sender, EventArgs e)
        {
            //CheckdgvNotikumiColumns();
        }

        private void dgvNotikumi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgcNotDate1.Index)
            {
                object oidn = dgvNotikumi.CurrentRow.Cells[dgcNotIDN.Index].Value;
                if (oidn != null && oidn != DBNull.Value && SomeDataDefs.EventHasPayDate((EEventId)oidn))
                {
                    var dt = dgvNotikumi[e.ColumnIndex, e.RowIndex].Value;
                    if (dt == null || dt != DBNull.Value) dt = DBNull.Value;
                    else dt = ((DateTime)dt).AddDays(-1);
                    dgvNotikumi[dgcNotDT3.Index, e.RowIndex].Value = dt;
                }
                return;
            }
            if (e.ColumnIndex == dgcNotIDN.Index)
            {
                object oidn = dgvNotikumi.CurrentRow.Cells[dgcNotIDN.Index].Value;
                if (oidn == null || oidn == DBNull.Value || !SomeDataDefs.IsFromToEvent((EEventId)oidn))
                {
                    dgvNotikumi[dgcNotDate2.Index, e.RowIndex].Value = DBNull.Value;
                    dgvNotikumi[dgcNotDT3.Index, e.RowIndex].Value = DBNull.Value;
                    dgvNotikumi[dgcNotDays.Index, e.RowIndex].Value = 0;
                }

                return;
            }
        }

        private void dgvNotikumi_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (IsLoading || InSwitchingTabs || ActiveControl != mySplitContainer1 || !dgvNotikumi.Focused) return;
            if (e.RowIndex == -1 || dgvNotikumi.NewRowIndex == e.RowIndex) return;
            object oidn = dgvNotikumi.CurrentRow.Cells[dgcNotIDN.Index].Value;
            if (oidn == null || oidn == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            var ev = (EEventId)oidn;
            bool b = SomeDataDefs.IsFromToEvent(ev);
            object odt1 = dgvNotikumi[dgcNotDate1.Index, e.RowIndex].Value;
            object odt2 = dgvNotikumi[dgcNotDate2.Index, e.RowIndex].Value;
            if (odt1 == DBNull.Value) odt1 = null;
            if (odt2 == DBNull.Value) odt2 = null;
            bool baddates = false;
            if (b)
            {
                if (odt1 == null || odt2 == null)
                {
                    baddates = true;
                }
                else
                {
                    var dt1 = (DateTime)odt1;
                    var dt2 = (DateTime)odt2;
                    if (dt1 > dt2 || dt1.Year < 1950 || dt1.Year > 2100 ||
                        dt2.Year < 1950 || dt2.Year > 2100)
                    {
                        baddates = true;
                    }
                }
            }
            else
            {
                if (odt1 == null) baddates = true;
            }
            if (baddates)
            {
                MyMainForm.ShowWarning("Nekorekti norādīti datumi no - līdz.");
                e.Cancel = true;
                return;
            }

            b = SomeDataDefs.EventHasPayDate(ev);
            if (b)
            {
                object odt3 = dgvNotikumi[dgcNotDT3.Index, e.RowIndex].Value;
                if (odt3 == DBNull.Value) odt3 = null;
                if (odt3 == null)
                {
                    baddates = true;
                }
                else
                {
                    var dt3 = (DateTime)odt3;
                    if (dt3.Year < 1950 || dt3.Year > 2100 ||
                        (odt1 != null && (DateTime)odt1 <= dt3))
                        baddates = true;
                }
            }
            if (baddates)
            {
                MyMainForm.ShowWarning("Nekorekti norādīts izmaksas datums.");
                e.Cancel = true;
                return;
            }

            if (ev == EEventId.Piešķirts_amats || ev == EEventId.Atbrīvots_no_amata)
            {
                object oida = dgvNotikumi[dgcNotIDA.Index, e.RowIndex].Value;
                if (oida == null || oida == DBNull.Value)
                {
                    MyMainForm.ShowWarning("Janorāda amats.");
                    e.Cancel = true;
                    return;
                }
            }

            if (SomeDataDefs.EventHasSCode(ev))
            {
                string scode = dgvNotikumi[dgcNotSCode.Index, e.RowIndex].Value.AsString();
                if (string.IsNullOrEmpty(scode))
                {
                    MyMainForm.ShowWarning("Janorāda ziņu kods.");
                    e.Cancel = true;
                    return;
                }
            }

            if (SomeDataDefs.EventHasOccCode(ev))
            {
                string occcode = dgvNotikumi[dgcNotOcc.Index, e.RowIndex].Value.AsString();
                if (string.IsNullOrEmpty(occcode))
                {
                    MyMainForm.ShowWarning("Janorāda profesijas kods.");
                    e.Cancel = true;
                    return;
                }
            }

        }

        private void dgvPapildSummas_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            /*
            if (bsPersons.Current == null) return;
            var ida = (int)(bsAmati.Current as DataRowView)[0];
            e.Row.Cells[dgcPSIDA.Index].Value = ida;
            */
        }

        private void dgvPapildSummas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == dgcPSIDNO.Index)
            {
                if (e.RowIndex == dgvPapildSummas.NewRowIndex)
                {
                    e.Cancel = true;
                    return;
                }
                var cell = dgvPapildSummas[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                var drv = dgvPapildSummas.Rows[e.RowIndex].DataBoundItem as DataRowView;
                var dr = drv.Row as KlonsADataSet.POSITIONS_PLUSMINUSRow;

                if (dr.IsIDSVNull())
                {
                    e.Cancel = true;
                    return;
                }
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

        private void dgvPapildSummas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgcPSIDNO.Index)
            {
                var cell = dgvPapildSummas[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                cell.DataSource = bsPapildSummaNo;
                cell.DisplayMember = "DESCR";
                cell.ValueMember = "ID";
            }
        }

        public void ShowPersonsList(bool b)
        {
            rādītPaslēptDarbiniekuKartiņasToolStripMenuItem.Checked = b;
            mySplitContainer1.Panel1Collapsed = !b;
            cbPersons.Visible = !b;
            lbArrow1.Visible = !b;
        }

        public bool CheckEventsForCurrent()
        {
            if (bsPersons.Count == 0 || bsPersons.Current == null) return true;
            var drv = bsPersons.Current as DataRowView;
            var dr = drv.Row as KlonsADataSet.PERSONSRow;
            var err = DataTasks.CheckEvents(dr.ID);
            if (err.HasErrors)
            {
                Form_ErrorList.ShowErrorList(MyMainForm, err);
                return false;
            }
            return true;
        }

        public bool CheckEventsForAll()
        {
            if (bsPersons.Count == 0) return true;
            var err = DataTasks.CheckEventsAll();
            if (err.HasErrors)
            {
                Form_ErrorList.ShowErrorList(MyMainForm, err);
                return false;
            }
            return true;
        }

        public void SelectPerson(int idp)
        {
            if (bsPersons.Count == 0) return;
            for (int i = 0; i < bsPersons.Count; i++)
            {
                var drp = (bsPersons[i] as DataRowView)?.Row as KlonsADataSet.PERSONSRow;
                if (drp == null) continue;
                if (drp.ID == idp)
                {
                    bsPersons.Position = i;
                    return;
                }
            }
        }

        public void SelectPosition(int idam)
        {
            if (bsPersons.Count == 0 || bsPersons.Current == null ||
                bsAmati.Count == 0) return;
            for (int i = 0; i < bsAmati.Count; i++)
            {
                var dram = (bsAmati[i] as DataRowView)?.Row as KlonsADataSet.POSITIONSRow;
                if (dram == null) continue;
                if (dram.ID == idam)
                {
                    bsAmati.Position = i;
                    return;
                }
            }
        }

        public void DoAddPerson()
        {
            if (!SaveData()) return;
            var fp = MyMainForm.FindForm(typeof(Form_Persons));
            if (fp != null)
            {
                MyMainForm.ShowWarning("Darbinieku saraksta forma ir atvērta.");
                return;
            }
            var fpn = new Form_PersonNew();
            var rt = fpn.ShowDialog(MyMainForm);
            if (rt != DialogResult.OK) return;
            SelectPerson(fpn.IDP);
            SaveData();
        }


        public void DoAddPosition()
        {
            if (!SaveData()) return;
            var fp = MyMainForm.FindForm(typeof(Form_Persons));
            if (fp != null)
            {
                MyMainForm.ShowWarning("Darbinieku saraksta forma ir atvērta.");
                return;
            }
            if (bsPersons.Count == 0 || bsPersons.Current == null) return;
            var drp = (bsPersons.Current as DataRowView)?.Row as KlonsADataSet.PERSONSRow;
            if (drp == null) return;

            var fpn = new Form_PersonNewPos();
            fpn.PersonName = drp.FNAME + " " + drp.LNAME;
            var rt = fpn.ShowDialog(MyMainForm);
            if (rt != DialogResult.OK) return;

            var tableAmati = MyData.DataSetKlons.POSITIONS;
            var tableAmatiR = MyData.DataSetKlons.POSITIONS_R;

            var dr_am = tableAmati.NewPOSITIONSRow();

            dr_am.IDP = drp.ID;
            dr_am.PERSONSRow = drp;
            dr_am.TITLE = fpn.PositionTitle;
            dr_am.IDDEP = fpn.iddep;
            tableAmati.AddPOSITIONSRow(dr_am);

            var dr_amr = tableAmatiR.NewPOSITIONS_RRow();

            dr_amr.IDA = dr_am.ID;
            dr_amr.POSITIONSRow = dr_am;
            dr_amr.EDIT_DATE = DateTime.Today;
            dr_amr.TITLE = dr_am.TITLE;
            dr_amr.IDDEP = dr_am.IDDEP;
            tableAmatiR.AddPOSITIONS_RRow(dr_amr);

            SelectPosition(dr_am.ID);

            SaveData();
        }

        private void rādītDarbiniekuSarakstuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool b = mySplitContainer1.Panel1Collapsed;
            ShowPersonsList(b);
        }

        private void pārbaudītNotikumusDarbiniekamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckEventsForCurrent();
        }

        private void pārbaudītNotikumusVisiemDarbiniekiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckEventsForAll();
        }

        private void Form_PersonsR_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            CheckEventsForAll();
        }

        private void miAddPerson_Click(object sender, EventArgs e)
        {
            DoAddPerson();
        }

        private void miAddPosition_Click(object sender, EventArgs e)
        {
            DoAddPosition();
        }

        private void darbiniekaKartīteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsPersons.Count == 0 || bsPersons.Current == null) return;
            var drv = bsPersons.Current as DataRowView;
            var dr = drv.Row as KlonsADataSet.PERSONSRow;

            var rep = new Report_PersonData();
            rep.ShowReport(dr.ID, DateTime.Today);
        }

        public bool ShowOnlyUsed
        {
            get { return MyData.Params.PersDataOnlyUsed; }
            set
            {
                if (value)
                {
                    var fs = "USED = 1";
                    if (bsPersons.Filter != fs) bsPersons.Filter = fs;
                    if (bsAmati.Filter != fs) bsPersons.Filter = fs;
                }
                else
                {
                    bsPersons.RemoveFilter();
                    bsAmati.RemoveFilter();
                }
                MyData.Params.PersDataOnlyUsed = value;
                miShowOnlyUsed.Checked = value;
            }
        }

        private void miShowOnlyUsed_Click(object sender, EventArgs e)
        {
            ShowOnlyUsed = !ShowOnlyUsed;
        }

        public void CheckPersonRedRows()
        {
            var dr = bsPersonsR.CurrentDataRow as KlonsADataSet.PERSONS_RRow;
            if (dr == null) return;
            if (bsPersonsR.Position == bsPersonsR.Count - 1)
            {
                sgrPersR.ClearRed();
            }
            else
            {
                var dr_prev = (bsPersonsR[bsPersonsR.Position + 1] as DataRowView)?.Row as KlonsADataSet.PERSONS_RRow;
                if (dr_prev == null) return;
                if (dr_prev.EDIT_DATE > dr.EDIT_DATE) return;
                sgrPersR.CheckRedRows(new[] { dr_prev }, new[] { dr }, new[] { bsPersonsR });
            }
        }

        public void CheckPersonRowRed(KlonsLIB.MySourceGrid.GridRows.MyGridRowPropEditorBase row)
        {
            if (row == null) return;
            var dr = bsPersonsR.CurrentDataRow as KlonsADataSet.PERSONS_RRow;
            if (dr == null) return;
            if (bsPersonsR.Position == bsPersonsR.Count - 1) return;
            var dr_prev = (bsPersonsR[bsPersonsR.Position + 1] as DataRowView)?.Row as KlonsADataSet.PERSONS_RRow;
            if (dr_prev == null) return;
            if (dr_prev.EDIT_DATE > dr.EDIT_DATE) return;
            row.CheckRedRow(new[] { dr_prev }, new[] { dr }, new[] { bsPersonsR });
        }

        public void CheckPositionRedRows()
        {
            var dr = bsAmatiR.CurrentDataRow as KlonsADataSet.POSITIONS_RRow;
            if (dr == null) return;
            if (bsAmatiR.Position == bsAmatiR.Count - 1)
            {
                sgrAmati.ClearRed();
            }
            else
            {
                var dr_prev = (bsAmatiR[bsAmatiR.Position + 1] as DataRowView)?.Row as KlonsADataSet.POSITIONS_RRow;
                if (dr_prev == null) return;
                if (dr_prev.EDIT_DATE > dr.EDIT_DATE) return;
                sgrAmati.CheckRedRows(new[] { dr_prev }, new[] { dr }, new[] { bsAmatiR });
            }
        }

        public void CheckPositionRowRed(KlonsLIB.MySourceGrid.GridRows.MyGridRowPropEditorBase row)
        {
            if (row == null) return;
            var dr = bsAmatiR.CurrentDataRow as KlonsADataSet.POSITIONS_RRow;
            if (dr == null) return;
            if (bsAmatiR.Position == bsAmatiR.Count - 1) return;
            var dr_prev = (bsAmatiR[bsAmatiR.Position + 1] as DataRowView)?.Row as KlonsADataSet.POSITIONS_RRow;
            if (dr_prev == null) return;
            if (dr_prev.EDIT_DATE > dr.EDIT_DATE) return;
            row.CheckRedRow(new[] { dr_prev }, new[] { dr }, new[] { bsAmatiR });
        }

        private void bsPersonsR_CurrentChanged(object sender, EventArgs e)
        {
            CheckPersonRedRows();
        }

        private void sgrPersR_EditEnded(object sender, EventArgs e)
        {
            var row = sender as KlonsLIB.MySourceGrid.GridRows.MyGridRowPropEditorBase;
            CheckPersonRowRed(row);
        }

        private void bsAmatiR_CurrentChanged(object sender, EventArgs e)
        {
            CheckPositionRedRows();
        }

        private void sgrAmati_EditEnded(object sender, EventArgs e)
        {
            var row = sender as KlonsLIB.MySourceGrid.GridRows.MyGridRowPropEditorBase;
            CheckPositionRowRed(row);
        }

        private string GetTerrCode()
        {
            var fm = new Form_TeritorialCodes();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedValue;
        }

        private string GetDepCode()
        {
            var fm = new Form_Departments();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedValue;
        }

        private void sgrPersR_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var pos = sgrPersR.Selection.ActivePosition;
            if (pos.Column != 2) return;

            if (e.KeyCode == Keys.F5)
            {
                if (pos.Row == rwTerCode.GridRow.Index)
                {
                    var new_code = GetTerrCode();
                    if (new_code == null) return;
                    rwTerCode.Value = new_code;
                }
            }
        }

        private void sgrPersR_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var pos = sgrPersR.Selection.ActivePosition;
            if (pos.Column != 2) return;

            if (pos.Row == rwTerCode.GridRow.Index)
            {
                var new_code = GetTerrCode();
                if (new_code == null) return;
                rwTerCode.Value = new_code;
            }
        }

        private void sgrAmati_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var pos = sgrAmati.Selection.ActivePosition;
            if (pos.Column != 2) return;

            if (e.KeyCode == Keys.F5)
            {
                if (pos.Row == rwAmatiDep.GridRow.Index)
                {
                    var new_code = GetDepCode();
                    if (new_code == null) return;
                    rwAmatiDep.Value = new_code;
                }
            }
        }

        private void sgrAmati_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var pos = sgrAmati.Selection.ActivePosition;
            if (pos.Column != 2) return;

            if (pos.Row == rwAmatiDep.GridRow.Index)
            {
                var new_code = GetDepCode();
                if (new_code == null) return;
                rwAmatiDep.Value = new_code;
            }
        }

    }
}
