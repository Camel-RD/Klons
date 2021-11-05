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
using KlonsLIB.Components;
using KlonsLIB.Misc;
using KlonsLIB.Forms;

namespace KlonsA.Forms
{
    public partial class Form_PieceWork : MyFormBaseA
    {
        public Form_PieceWork()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            SetupToolStrips();

          
            var timeunits = SomeDataDefs.MakeListB("0", "st", "1", "min", "2", "sec");
            dgcTimeUnit.DataSource = timeunits;
            dgcTimeUnit.DisplayMember = "Val";
            dgcTimeUnit.ValueMember = "Key";

            cbAmats.SelectedIndex = -1;
           
        }

        private void Form_PieceWork_Load(object sender, EventArgs e)
        {
            MyData.DataSetKlons.PIECEWORK.ColumnChanged += PIECEWORK_ColumnChanged;
            CheckSave();
        }

        private void Form_PieceWork_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlons.PIECEWORK.ColumnChanged -= PIECEWORK_ColumnChanged;
        }

        private void PIECEWORK_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            var dr = e.Row as KlonsADataSet.PIECEWORKRow;
            if (dr == null) return;

            if(e.Column == MyData.DataSetKlons.PIECEWORK.IDKColumn)
            {
                var drk = MyData.DataSetKlons.PIECEWORK_CATALOG.FindByID(dr.IDK);
                if (drk == null) return;
                //dr.DESCR = drk.DESCR;
                dr.UNIT = drk.UNIT;
                dr.RATE = drk.RATE;
                dr.TIMEUNIT = drk.TIMEUNIT;
                dr.TIMEUSE = drk.TIMEUSE;

                if(dr.QUANTITY != 0.0M)
                    dr.QUANTITY = 0.0M;
                return;
            }

            if (e.Column == MyData.DataSetKlons.PIECEWORK.IDAColumn)
            {
                var dra = MyData.DataSetKlons.POSITIONS.FindByID(dr.IDA);
                if (dra == null) return;
                dr.IDP = dra.IDP;
                return;
            }

            if (e.Column == MyData.DataSetKlons.PIECEWORK.QUANTITYColumn ||
                e.Column == MyData.DataSetKlons.PIECEWORK.RATEColumn ||
                e.Column == MyData.DataSetKlons.PIECEWORK.BONUSColumn)
            {
                var pay = Math.Round(dr.QUANTITY * dr.RATE * (1.0M + (decimal)dr.BONUS / 100.0M), 4);
                if (dr.PAY != pay) dr.PAY = pay;
            }

            if (e.Column == MyData.DataSetKlons.PIECEWORK.QUANTITYColumn ||
                e.Column == MyData.DataSetKlons.PIECEWORK.TIMEUNITColumn ||
                e.Column == MyData.DataSetKlons.PIECEWORK.TIMEUSEColumn)
            {
                float tm = dr.TIMEUSE;
                if (dr.TIMEUNIT == 1) tm /= 60.0f;
                else if (dr.TIMEUNIT == 2) tm /= 3600.0f;
                tm = (float)Math.Round(dr.QUANTITY * (decimal)tm, 3);
                if (dr.TIMEUSEINHOURS != tm) dr.TIMEUSEINHOURS = tm;
            }
        }

        private void SetupToolStrips()
        {
            InsertInToolStrip(toolStrip1, tbDT1, 1);
            InsertInToolStrip(toolStrip1, tbDT2, 3);
            InsertInToolStrip(toolStrip1, cbAmats, 5);
        }

        private bool Filtered = false;
        private DateTime FilterDt1 = DateTime.MinValue;
        private DateTime FilterDt2 = DateTime.MaxValue;
        private int FilterIDA = int.MinValue;

        private string DoFilter()
        {
            string sdt1 = tbDT1.Text.Zn();
            string sdt2 = tbDT1.Text.Zn();
            bool isidamset = false;
            FilterIDA = int.MinValue;

            Filtered = false;
            FilterDt1 = DateTime.MinValue;
            FilterDt2 = DateTime.MaxValue;

            if (cbAmats.SelectedIndex >= 0 && cbAmats.SelectedValue != null)
            {
                isidamset = true;
                FilterIDA = (int)cbAmats.SelectedValue;
            }

            if ((sdt1 != null && !Utils.StringToDate(sdt1, out FilterDt1)) ||
                (sdt2 != null && !Utils.StringToDate(sdt2, out FilterDt2)))
                return "Nekorekti datumi";


            string s1, fs = "";

            if (sdt1 != null)
                fs = string.Format("(DT >= #{0:MM/dd/yyyy}#)", FilterDt1);

            if (sdt2 != null)
            {
                s1 = string.Format("(DT <= #{0:MM/dd/yyyy}#)", FilterDt2);
                if (fs == "") fs = s1;
                else fs += " AND " + s1;
            }

            if (isidamset)
            {
                s1 = string.Format("(IDA = {0})", FilterIDA);
                if (fs == "") fs = s1;
                else fs += " AND " + s1;
            }

            if (fs == "")
            {
                bsSar.RemoveFilter();
            }
            else
            {
                Filtered = true;
                bsSar.Filter = fs;
            }

            return "OK";
        }

        private void bnavSar_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvSar_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void SetSaveButton(bool red)
        {
            bnavSar.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvSar.EndEditX()) return false;
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
            SetSaveButton(bsSar.HasChanges());
        }

        private void dgvSar_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bsSar_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void cmFilter_Click(object sender, EventArgs e)
        {
            var er = DoFilter();
            if (er != "OK")
                MyMainForm.ShowWarning(er);
        }

        public void GetIDKFromDialog()
        {
            if (bsSar.Count == 0 || bsSar.Current == null) return;
            if (dgvSar.CurrentRow == null || dgvSar.CurrentRow.IsNewRow) return;
            var fm = new Form_PieceWorkCatalog();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            var dr = (dgvSar.CurrentRow.DataBoundItem as DataRowView).Row as KlonsADataSet.PIECEWORKRow;
            if (dgvSar.CurrentCell != null)
            {
                try
                {
                    int idk = fm.SelectedValueInt;
                    
                    dgvSar.BeginEdit(false);
                    var c = dgvSar.EditingControl as MyDgvMcComboBox;
                    c.SelectedValue = idk;
                    
                    dgvSar.EndEdit();
                }
                catch (Exception) { }
            }
        }

        public void GetIDAFromDialog()
        {
            if (bsSar.Count == 0 || bsSar.Current == null) return;
            if (dgvSar.CurrentRow == null || dgvSar.CurrentRow.IsNewRow) return;
            var fm = new Form_Persons();
            fm.WhatToSelect = Form_Persons.EWhatToSelect.Position;
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            var dr = (dgvSar.CurrentRow.DataBoundItem as DataRowView).Row as KlonsADataSet.PIECEWORKRow;
            if (dgvSar.CurrentCell != null)
            {
                try
                {
                    dgvSar.BeginEdit(false);
                    var c = dgvSar.EditingControl as DataGridViewComboBoxEditingControl;
                    c.SelectedValue = fm.SelectedValueInt;
                    dgvSar.EndEdit();
                }
                catch (Exception ) { }
            }
        }

        private void CopyRow()
        {
            if (dgvSar.CurrentCell == null || dgvSar.CurrentRow == null) return;
            if (dgvSar.CurrentRow.IsNewRow || dgvSar.IsCurrentCellDirty) return;
            if (!dgvSar.EndEditX()) return;

            bsSar.CopyCurrent();
        }

        private void dgvSar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSar.CurrentCell == null) return;
            if (e.RowIndex == -1 || e.RowIndex == dgvSar.NewRowIndex) return;
            if(e.ColumnIndex == dgcIDK.Index)
            {
                GetIDKFromDialog();
                return;
            }
            if (e.ColumnIndex == dgcIDA.Index)
            {
                GetIDAFromDialog();
                return;
            }
        }

        public void DeleteCurrent()
        {
            bnavSar.DeleteCurrent();
            SaveData();
        }

        private void dgvSar_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvSar.CurrentCell == null) return;
            if (e.KeyCode == Keys.F5)
            {
                if(dgvSar.CurrentCell.ColumnIndex == dgcIDK.Index)
                {
                    GetIDKFromDialog();
                    e.Handled = true;
                    return;
                }
                if (dgvSar.CurrentCell.ColumnIndex == dgcIDA.Index)
                {
                    GetIDAFromDialog();
                    e.Handled = true;
                    return;
                }
            }
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvSar.EndEdit()) return;
                dgvSar.MoveToNewRow();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Control)
            {
                CopyRow();
                e.Handled = true;
                return;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CopyRow();
        }

        private void dgvSar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int ci = e.ColumnIndex;
            int ri = e.RowIndex;
            if (ri == -1 || ci == -1) return;
            dgvSar.InvalidateRow(ri);
        }

        private DateTime lastDate = DateTime.MinValue;

        private void dgvSar_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcDT.Index)
            {
                if (e.Value == null || e.Value == DBNull.Value) return;
                if (!(e.Value is string)) return;
                string s = (string)e.Value;
                if (string.IsNullOrEmpty(s)) return;
                DateTime dt;
                if (Utils.StringToDate(s, out dt))
                {
                    e.Value = dt;
                    lastDate = dt;
                    e.ParsingApplied = true;
                    return;
                }

                if (lastDate == DateTime.MinValue) return;

                string[] ss = s.Split('.');
                if (ss.Length > 2) return;

                int dd, mm = -1;

                if (!int.TryParse(ss[0], out dd)) return;
                if (ss.Length == 1)
                {
                    try
                    {
                        dt = new DateTime(lastDate.Year, lastDate.Month, dd);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    e.Value = dt;
                    lastDate = dt;
                    e.ParsingApplied = true;
                    return;
                }

                if (!int.TryParse(ss[1], out mm)) return;
                try
                {
                    dt = new DateTime(lastDate.Year, mm, dd);
                }
                catch (Exception)
                {
                    return;
                }
                e.Value = dt;
                lastDate = dt;
                e.ParsingApplied = true;
                return;
            }
        }

        private void dgvSar_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (lastDate == DateTime.MinValue)
                lastDate = DateTime.Today;

            e.Row.Cells[dgcDT.Index].Value = lastDate;
            if (Filtered)
            {
                if(FilterIDA != int.MinValue)
                    e.Row.Cells[dgcIDA.Index].Value = FilterIDA;
            }

        }

        private void dgvSar_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!Filtered || e.RowIndex == -1 || e.RowIndex == dgvSar.NewRowIndex) return;

            var dt = (DateTime)dgvSar[dgcDT.Index, e.RowIndex].Value;
            if(dt < FilterDt1 || dt > FilterDt2)
            {
                MyMainForm.ShowWarning("Datums ārpus filtra.");
                e.Cancel = true;
                return;
            }

            if (FilterIDA != int.MinValue)
            {
                var ida = (int)dgvSar[dgcIDA.Index, e.RowIndex].Value;
                if (ida != FilterIDA)
                {
                    MyMainForm.ShowWarning("Darbinieks, amats nesakrīt ar filtrā norādīto.");
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

    }


}
