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
    public partial class Form_SalarySheets : MyFormBaseA
    {
        public Form_SalarySheets()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            tslPeriod.Text = DataLoader.GetPeriodStr();
        }

        private void Form_SalarySheets_Load(object sender, EventArgs e)
        {
            CheckSave();
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

        private void SetSaveButton(bool red)
        {
            bnavSar.SetSaveButton(tsbSave, red);
        }

        private bool HasChanges()
        {
            return myAdapterManager1.HasChanges();
        }

        private void CheckSave()
        {
            SetSaveButton(HasChanges());
        }

        private void dgvSar_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            if (HasChanges())
                SaveData();
        }

        private void bsSar_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void AddNew(int yr, int mt, DateTime dt2, bool istemp, string iddep, string descr)
        {
            var table_algu_lapas = MyData.DataSetKlons.SALARY_SHEETS;
            var new_dr = table_algu_lapas.NewSALARY_SHEETSRow();
            new_dr.YR = yr;
            new_dr.MT = mt;
            new_dr.SNR = DataTasks.GetNextSalarySheetNr(yr);
            new_dr.DT1 = dt2.FirstDayOfMonth();
            new_dr.DT2 = dt2;
            new_dr.IS_TEMP = (short)(istemp ? 1 : 0);
            new_dr.DEP = iddep;
            new_dr.DESCR = descr;
            table_algu_lapas.Rows.Add(new_dr);
        }

        private void MakeListFromSH(int yr, int mt, int idsh = int.MinValue)
        {
            var err = DataTasks.MakeSalarySheetsFromTemplate(yr, mt, idsh);
            if (err != null && err.Count > 0)
            {
                Form_ErrorList.ShowErrorList(MyMainForm, err);
            }
            SaveData();
        }

        public void MakeList()
        {
            if (!SaveBeforeProceed()) return;
            var fm = new Form_SalarySheetsNew();
            var ret = fm.ShowDialog(MyMainForm);
            if (ret != DialogResult.OK) return;
            if (fm.MakeEmpty)
            {
                AddNew(fm.Year, fm.Month, fm.DT2, fm.IsTemp, fm.IdDepartment, fm.Descr);
            }
            else if (fm.MakeAll)
            {
                MakeListFromSH(fm.Year, fm.Month);
            }
            else
            {
                MakeListFromSH(fm.Year, fm.Month, fm.IdSh);
            }
            SaveData();
        }

        public void OpenCurrent()
        {
            if (bsSar.Current == null) return;
            if (!SaveBeforeProceed()) return;
            var dr = (bsSar.Current as DataRowView).Row as KlonsADataSet.SALARY_SHEETSRow;
            var f = MyMainForm.FindForm(typeof(Form_SalarySheet)) as Form_SalarySheet;
            if (f == null)
                f = MyMainForm.ShowForm(typeof(Form_SalarySheet)) as Form_SalarySheet;
            f.Activate();
            f.SelectSheet(dr.ID);
        }

        public void DeleteCurrent()
        {
            if (bsSar.Current == null || !IsSheetFormClosed()) return;
            if (!SaveBeforeProceed()) return;
            if (!AskCanDelete()) return;
            var dr = (bsSar.Current as DataRowView).Row as KlonsADataSet.SALARY_SHEETSRow;
            DataTasks.DeleteSalarySheet(dr);
            SaveData();
        }

        private void dgvSar_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcDT1.Index || e.ColumnIndex == dgcDT2.Index)
            {
                Utils.DGVParseDateCell(e);
            }
        }

        private void dgvSar_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (IsLoading) return;
            if (e.RowIndex == -1 || e.RowIndex == dgvSar.NewRowIndex) return;
            object odt1 = dgvSar.CurrentRow.Cells[dgcDT1.Index].Value;
            object odt2 = dgvSar.CurrentRow.Cells[dgcDT2.Index].Value;
            if (odt1 == null || odt2 == null || !(odt1 is DateTime) || !(odt2 is DateTime))
            {
                MyMainForm.ShowWarning("Jānorāda datumi.");
                e.Cancel = true;
                return;
            }
            bool istemp = (Int16)dgvSar.CurrentRow.Cells[dgcIsTemp.Index].Value == 1;
            var dt1 = (DateTime)odt1;
            var dt2 = (DateTime)odt2;
            int yr = (int)dgvSar.CurrentRow.Cells[dgcYR.Index].Value;
            int mt = (int)dgvSar.CurrentRow.Cells[dgcMT.Index].Value;
            var cdt1 = new DateTime(yr, mt, 1);
            var cdt2 = cdt1.LastDayOfMonth();
            if (dt1 > dt2 || dt1 != cdt1 || dt1 > cdt2 || dt2 < cdt1 || dt2 > cdt2)
            {
                MyMainForm.ShowWarning("Nekorekti datumi.");
                e.Cancel = true;
                return;
            }
            if(istemp && dt2 == cdt2 || !istemp && dt2 != cdt2)
            {
                MyMainForm.ShowWarning("Nekorekti datumi priekš starpaprēķina.");
                e.Cancel = true;
                return;
            }
        }

        public bool IsSheetFormClosed()
        {
            if (MyMainForm.FindForm(typeof(Form_SalarySheet)) != null)
            {
                MyMainForm.ShowWarning("Vispirms jāaizver forma [Algas aprēķina lapa].");
                return false; ;
            }
            return true;
        }

        private void dgvSar_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!IsSheetFormClosed() || e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void bnavSar_ItemDeleting(object sender, CancelEventArgs e)
        {
            if (!IsSheetFormClosed() || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvSar_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvSar.CurrentCell == null) return;
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                MakeList();
                e.Handled = true;
                return;
            }
        }

        private void dgvSar_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvSar.CurrentRow == null || dgvSar.CurrentRow.IsNewRow ||
                dgvSar.CurrentCell == null) return;
            int colnr = dgvSar.CurrentCell.ColumnIndex;

            if (e.KeyCode == Keys.F5)
            {
                if (colnr != dgcDEP.Index) return;
                GetIDDepFromDialog();
                e.Handled = true;
                return;
            }
        }

        private void dgvSar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSar.CurrentRow == null || dgvSar.CurrentRow.IsNewRow ||
                dgvSar.CurrentCell == null) return;
            int colnr = dgvSar.CurrentCell.ColumnIndex;
            if (colnr != e.ColumnIndex) return;

            if (colnr == dgcDEP.Index)
            {
                GetIDDepFromDialog();
            }
        }

        public void GetIDDepFromDialog()
        {
            if (bsSar.Count == 0 || bsSar.Current == null) return;
            if (dgvSar.CurrentRow == null || dgvSar.CurrentRow.IsNewRow) return;
            var fm = new Form_Departments();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return;
            var dr = (dgvSar.CurrentRow.DataBoundItem as DataRowView).Row as KlonsADataSet.SALARY_SHEETSRow;
            if (dgvSar.CurrentCell != null)
            {
                try
                {
                    dgvSar.BeginEdit(false);
                    var c = dgvSar.EditingControl as DataGridViewComboBoxEditingControl;
                    c.SelectedValue = fm.SelectedValue;
                    dgvSar.EndEdit();
                }
                catch (Exception) { }
            }
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            OpenCurrent();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            MakeList();
        }

        private void dgvSar_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvSar.NewRowIndex) return;
            if (!Utils.IN(e.ColumnIndex, dgcDT1.Index, dgcDT2.Index, dgcIsTemp.Index)) return;

            int yr = (int)dgvSar[dgcYR.Index, e.RowIndex].Value;
            int mt = (int)dgvSar[dgcMT.Index, e.RowIndex].Value;
            DateTime dt1 = DateTime.MinValue;
            DateTime dt2 = DateTime.MinValue;

            if (e.ColumnIndex == dgcDT1.Index)
            {
                if (e.FormattedValue as string == null ||
                    !Utils.StringToDate(e.FormattedValue as string, out dt1))
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
                dt1 = (DateTime)dgvSar[dgcDT1.Index, e.RowIndex].Value;


            if (e.ColumnIndex == dgcDT2.Index)
            {
                if (e.FormattedValue as string == null ||
                    !Utils.StringToDate(e.FormattedValue as string, out dt2))
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
                dt2 = (DateTime)dgvSar[dgcDT2.Index, e.RowIndex].Value;


            if (dt1 > dt2 || dt1.Year != yr || dt1.Month != mt || 
                dt2.Year != yr || dt2.Month != mt)
            {
                e.Cancel = true;
                return;
            }

        }

        private void dgvSar_RowValidating_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvSar.NewRowIndex) return;

            int yr = (int)dgvSar[dgcYR.Index, e.RowIndex].Value;
            int mt = (int)dgvSar[dgcMT.Index, e.RowIndex].Value;
            var dte = (new DateTime(yr, mt, 1)).LastDayOfMonth();
            var dt1 = (DateTime)dgvSar[dgcDT1.Index, e.RowIndex].Value;
            var dt2 = (DateTime)dgvSar[dgcDT2.Index, e.RowIndex].Value;
            var b = ((short)dgvSar[dgcIsTemp.Index, e.RowIndex].Value) == 1;

            if (dt1 > dt2 || dt1.Year != yr || dt1.Month != mt ||
                dt2.Year != yr || dt2.Month != mt ||
                b && dt2 == dte ||
                !b && dt2 < dte)
            {
                e.Cancel = true;
                return;
            }

        }
    }
}
