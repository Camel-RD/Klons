using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.DataSets;
using KlonsFM.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Data;
using KlonsFM.UI;
using KlonsLIB.Components;

namespace KlonsFM.FormsM
{
    public partial class FormM_PvnRates2 : MyFormBaseF, IMyDgvTextboxEditingControlEvents2
    {
        public FormM_PvnRates2()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            dgcAccBaseDebFin.DataSource = SomeDataDefs.AccTemplatesBase;
            dgcAccBaseDebFin.ValueMember = "Key";
            dgcAccBaseDebFin.DisplayMember = "Val";
            dgcAccBaseCredFin.DataSource = SomeDataDefs.AccTemplatesBase;
            dgcAccBaseCredFin.ValueMember = "Key";
            dgcAccBaseCredFin.DisplayMember = "Val";
            dgcAccPvnDebFin.DataSource = SomeDataDefs.AccTemplatesPVN;
            dgcAccPvnDebFin.ValueMember = "Key";
            dgcAccPvnDebFin.DisplayMember = "Val";
            dgcAccPvnCredFin.DataSource = SomeDataDefs.AccTemplatesPVN;
            dgcAccPvnCredFin.ValueMember = "Key";
            dgcAccPvnCredFin.DisplayMember = "Val";

            myGrid1.Visible = false;
            rādītPaslēptDatuPaneliToolStripMenuItem.Checked = false;
        }

        private void FormM_PvnRates2_Load(object sender, EventArgs e)
        {
            myGrid1.MakeGrid();
            myGrid1.LinkGrid();

            dgvRates.Select();

            grAccIdPVNText.ButtonClicked += GrAccIdPVNText_ButtonClicked;
        }

        private void FormM_PvnRates2_FormClosed(object sender, FormClosedEventArgs e)
        {
            grAccIdPVNText.ButtonClicked -= GrAccIdPVNText_ButtonClicked;
        }

        private void GrAccIdPVNText_ButtonClicked(object sender, EventArgs e)
        {
            var grow = sender as KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox;
            var idn = (int?)grow.Value;
            int id = idn == null ? -1 : idn.Value;
            int? new_id = FormM_PVNTexts.GetPVNTextId(id);
            if (!new_id.HasValue) return;
            grow.Value = new_id.Value;
        }

        private void CheckRatesGridsEnable()
        {
            dgvAcc.Enabled = 
                dgvRates.RowCount > 0 && 
                dgvRates.CurrentRow != null &&
                !dgvRates.CurrentRow.IsNewRow;
            CheckDataGridsEnable();
        }

        private void CheckDataGridsEnable()
        {
            myGrid1.Enabled =
                dgvAcc.Enabled &&
                dgvAcc.RowCount > 0 &&
                dgvAcc.CurrentRow != null &&
                !dgvAcc.CurrentRow.IsNewRow;
        }

        private KlonsMDataSet.M_PVNRATESRow GetCurrentRatesRow()
        {
            if (bsRates.Count == 0 || bsRates.Current == null ||
                dgvRates.CurrentRow.Index == dgvRates.NewRowIndex) return null;
            var dr_rates = bsRates.CurrentDataRow as KlonsMDataSet.M_PVNRATESRow;
            return dr_rates;
        }

        public int? GetPVNTextId(int idpvntext)
        {
            return FormM_PVNTexts.GetPVNTextId(idpvntext);
        }

        public void GetPVNTextId()
        {
            var o = dgvAcc.CurrentCell.Value;
            int val = o == null || o == DBNull.Value ? -1 : (int)o;
            var rt = GetPVNTextId(val);
            if (rt == null) return;
            SetCurrentRowPVNTextId(rt.Value);
        }

        private void SetCurrentRowPVNTextId(int idpvntext)
        {
            if (dgvAcc.CurrentCell == null) return;
            try
            {
                dgvAcc.BeginEdit(false);
                if (dgvAcc.EditingControl is KlonsLIB.Components.MyPickRowTextBox2 c)
                {
                    c.SelectedValue = idpvntext;
                }
                dgvAcc.EndEdit();
            }
            catch (Exception) { }
        }

        private void dgvRates_Enter(object sender, EventArgs e)
        {
            bNav.BindingSource = bsRates;
            bNav.DataGrid = dgvRates;
            lbActiveGrid.Text = "Likmes:";
        }

        private void dgvAcc_Enter(object sender, EventArgs e)
        {
            bNav.BindingSource = bsAcc;
            bNav.DataGrid = dgvAcc;
            lbActiveGrid.Text = "Kontējums:";
        }

        private void DoAddNewRow()
        {
            if (bNav.BindingSource == bsRates)
            {
                dgvRates.MoveToNewRow();
            }
            else
            {
                dgvAcc.MoveToNewRow();
            }

            /*
            if (bNav.BindingSource == bsRates)
            {
                var dr = MyData.DataSetKlonsM.M_PVNRATES.NewM_PVNRATESRow();
                MyData.DataSetKlonsM.M_PVNRATES.Rows.Add(dr);
            }
            else
            {
                var dr_rates = GetCurrentRatesRow();
                if (dr_rates == null) return;
                var dr_acc = MyData.DataSetKlonsM.M_PVNRATES2.NewM_PVNRATES2Row();
                dr_acc.IDRATE = dr_rates.ID;
                dr_acc.XPvnType = EPVNType.Nenoteikts;
                dr_acc.XDocType = EDocType.Nenoteikts;
                dr_acc.XBaseDebFin = EAccountsForTemplates.Nav;
                dr_acc.XBaseCredFin = EAccountsForTemplates.Nav;
                dr_acc.XPvnDebFin = EAccountsForTemplates.Nav;
                dr_acc.XPvnCredFin = EAccountsForTemplates.Nav;
                MyData.DataSetKlonsM.M_PVNRATES2.Rows.Add(dr_acc);
            }*/
        }

        public void DeleteCurrent()
        {
            bNav.DeleteCurrent();
            SaveData();
        }

        public override bool SaveData()
        {
            if (!dgvRates.EndEditX()) return false;
            if (!dgvAcc.EndEditX()) return false;
            if (!this.Validate()) return false;
            try
            {
                DataTasks.SetNewIDs(myAdapterManager1);
                bool rt = myAdapterManager1.UpdateAll();
                CheckSave();
                return rt;
            }
            catch (Exception e)
            {
                CheckSave();
                Form_Error.ShowException(e, "Neizdevās saglabāt izmaiņas.");
                return false;
            }
        }

        private bool HasChanges()
        {
            return myAdapterManager1.HasChanges();
        }

        private void CheckSave()
        {
            SetSaveButton(HasChanges());
        }

        private void SetSaveButton(bool red)
        {
            bNav.SetSaveButtonRed(red);
        }

        private void bniAddNew_Click(object sender, EventArgs e)
        {
            DoAddNewRow();
        }

        private void bniDelete_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void bniSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvRates_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvAcc_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void bNav_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvRates_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvRates.CurrentCell == null) return;
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvRates.EndEdit()) return;
                DoAddNewRow();
                e.Handled = true;
                return;
            }
        }

        private void dgvAcc_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvAcc.CurrentCell == null) return;
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvAcc.EndEdit()) return;
                DoAddNewRow();
                e.Handled = true;
                return;
            }

            int colnr = dgvAcc.CurrentCell.ColumnIndex;
            if (e.KeyCode == Keys.F4)
            {
                if (colnr == dgcAccIdPVNText.Index)
                {
                    GetPVNTextId();
                    e.Handled = true;
                    return;
                }
            }
        }

        private void dgvRates_CurrentCellChanged(object sender, EventArgs e)
        {
            CheckRatesGridsEnable();
        }

        private void dgvAcc_CurrentCellChanged(object sender, EventArgs e)
        {
            CheckDataGridsEnable();
        }

        private void dgvRates_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void bsRates_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void bsAcc_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (e.ListChangedType == ListChangedType.Reset) return;
            CheckSave();
        }

        private void rādītPaslēptDatuPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myGrid1.Visible = !myGrid1.Visible;
            rādītPaslēptDatuPaneliToolStripMenuItem.Checked = myGrid1.Visible;
        }

        private void dgvAcc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value) return;
            if (e.ColumnIndex == dgcAccBaseText.Index ||
                e.ColumnIndex == dgcAccPvnText.Index)
            {
                var table = MyData.DataSetKlonsM.M_PVNTEXTS;
                int idtext = (int)e.Value;
                var dr = table.FindByID(idtext);
                if (dr == null) return;
                if (e.ColumnIndex == dgcAccBaseText.Index) 
                    e.Value = dr.TAG1;
                else 
                    e.Value = dr.TAG2;
                e.FormattingApplied = true;
            }
        }

        void IMyDgvTextboxEditingControlEvents2.OnButtonClicked(MyDgvTextboxEditingControl2 control)
        {
            if(control.DataSource == bsPvnTexts)
            {
                GetPVNTextId();
            }
        }

        private void myGrid1_ConvertingValueToDisplayString(object sender, DevAge.ComponentModel.ConvertingObjectEventArgs e)
        {
            if (e.Value == null) return;
            if (sender == grAccBaseText || sender == grAccPVNText)
            {
                var table = MyData.DataSetKlonsM.M_PVNTEXTS;
                int idtext = (int)e.Value;
                var dr = table.FindByID(idtext);
                if (dr == null) return;
                if (sender == grAccBaseText)
                    e.Value = dr.TAG1;
                else
                    e.Value = dr.TAG2;
                e.ConvertingStatus = DevAge.ComponentModel.ConvertingStatus.Completed;
            }
        }

    }
}
