using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsLIB.Data;

namespace KlonsA.Forms
{
    public partial class Form_TeritorialCodes : MyFormBaseA
    {
        public Form_TeritorialCodes()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void Form_TeritorialCodes_Load(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void SelectCurrent()
        {
            if (dgvTerKodi.CurrentRow == null || dgvTerKodi.CurrentRow.IsNewRow) return;
            var dr = bsTerKodi.CurrentDataRow as KlonsA.DataSets.KlonsADataSet.TERITORIAL_CODESRow;
            if (!dgvTerKodi.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            if (!this.IsMyDialog) return;
            SetSelectedValue(dr.ID);
        }

        private void dgvTerKodi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgcID.Index)
            {
                SelectCurrent();
            }
        }

        private void dgvTerKodi_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }
        }

        private void dgvTerKodi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SetSelectedValue(null, true);
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.SelectAll();
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                string s = tbSearch.Text;
                if (s == "")
                {
                    bsTerKodi.RemoveFilter();
                }
                else
                {
                    bsTerKodi.Filter = string.Format("Descr LIKE '*{0}*'", s);
                }
            }
        }

        private void bnavTerKodi_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvTerKodi_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete())
                e.Cancel = true;
        }

        private void SetSaveButton(bool red)
        {
            bnavTerKodi.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            if (!dgvTerKodi.EndEditX()) return false;
            var ret = bsTerKodi.SaveTable();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsTerKodi.HasChanges());
        }

        private void dgvTerKodi_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bsTerKodi_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

    }
}
