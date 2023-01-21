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

namespace KlonsFM.FormsM
{
    public partial class FormM_Accounts : MyFormBaseF
    {
        public FormM_Accounts()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void FormM_Accounts_Load(object sender, EventArgs e)
        {

        }

        private int FilterAccountType = -1;

        public static string GetAccCode(string code, EAccountType accounttypefilter = EAccountType.Nenoteikts)
        {
            var fm = new FormM_Accounts();
            if (accounttypefilter != EAccountType.Nenoteikts)
            {
                fm.FilterAccountType = (int)accounttypefilter;
                fm.DoFilterA();
            }
            if (!string.IsNullOrEmpty(code))
                fm.FindAcc(code);
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedValue;
        }

        public void FindAcc(string code)
        {
            for (int i = 0; i < bsAccounts.Count; i++)
            {
                var dr = (bsAccounts[i] as DataRowView).Row as KlonsMDataSet.M_ACCOUNTSRow;
                if (dr.ID == code)
                {
                    bsAccounts.Position = i;
                    return;
                }
            }
        }

        private void SelectCurrent()
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var dr = bsAccounts.CurrentDataRow;
            if (!dgvRows.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            string id = dr["ID"] as string;
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }

        public void DoFilterA()
        {
            if (FilterAccountType == -1)
            {
                bsAccounts.RemoveFilter();
                return;
            }
            bsAccounts.Filter = $"TP = {FilterAccountType} OR TP = 1";
        }


        public override bool SaveData()
        {
            if (!dgvRows.EndEditX()) return false;

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

        private void CheckSave()
        {
            SetSaveButton(bsAccounts.HasChanges());
        }

        private void SetSaveButton(bool red)
        {
            bNav.SetSaveButtonRed(red);
        }

        public void DeleteCurrent()
        {
            bNav.DeleteCurrent();
            SaveData();
        }

        private bool IsRow0(int rownr)
        {
            if (rownr == dgvRows.NewRowIndex) return false;
            var dr = dgvRows.GetDataRow(rownr) as KlonsMDataSet.M_ACCOUNTSRow;
            if (dr == null) return false;
            return dr.ID == "?";
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void bsAccounts_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvRows_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvRows_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvRows.EndEdit()) return;
                dgvRows.MoveToNewRow();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                SetSelectedValue(null, true);
                e.Handled = true;
            }
        }

        private void dgvRows_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = e.Row.IsNewRow || IsRow0(e.Row.Index) || !AskCanDelete();
        }

        private void bNav_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = IsRow0(bsAccounts.Position) || !AskCanDelete();
        }

        private void dgvRows_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            if (e.ColumnIndex == dgcID.Index)
            {
                SelectCurrent();
                return;
            }
        }

        private void dgvRows_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dgvRows.NewRowIndex) return;
            if (IsRow0(e.RowIndex))
                e.Cancel = true;
        }

        private void dgvRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null, true);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var table = MyData.DataSetKlonsM.M_ACCOUNTS;
            var ad = new DataSets.KlonsMDataSetTableAdapters.M_ACCOUNTSTableAdapter();
            //ad.ClearBeforeFill = false;
            //ad.Fill(table);
            var cm = new FirebirdSql.Data.FirebirdClient.FbCommand();
            cm.CommandText = "select * from m_accounts where id = '2110'";
            cm.Connection = ad.Connection;
            var ad1 = new FirebirdSql.Data.FirebirdClient.FbDataAdapter(cm);
            ad1.Fill(table);
        }
    }
}
