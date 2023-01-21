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
    public partial class FormM_StoreTypes : MyFormBaseF
    {
        public FormM_StoreTypes()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void FormM_StoreTypes_Load(object sender, EventArgs e)
        {

        }

        public string SelectedCode = null;

        public static int? GetStoreTypeId(string code)
        {
            var fm = new FormM_StoreTypes();
            if (code != null)
                fm.FindStoreType(code);
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedValueInt;
        }

        public static int? GetStoreTypeId(int? id)
        {
            var fm = new FormM_StoreTypes();
            if (id != null)
                fm.FindStoreType(id.Value);
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedValueInt;
        }

        public void FindStoreType(string code)
        {
            for (int i = 0; i < bsRows.Count; i++)
            {
                var dr = (bsRows[i] as DataRowView).Row as KlonsMDataSet.M_STORETYPERow;
                if (dr.NAME == code)
                {
                    bsRows.Position = i;
                    return;
                }
            }
        }

        public void FindStoreType(int id)
        {
            for (int i = 0; i < bsRows.Count; i++)
            {
                var dr = (bsRows[i] as DataRowView).Row as KlonsMDataSet.M_STORETYPERow;
                if (dr.ID == id)
                {
                    bsRows.Position = i;
                    return;
                }
            }
        }

        void SelectCurrent()
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var dr = bsRows.CurrentDataRow as KlonsMDataSet.M_STORETYPERow;
            if (!dgvRows.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            int id = dr.ID;
            SelectedCode = dr.NAME;
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }

        void dgvRows_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvRows.CurrentCell == null) return;
            if (e.Control && e.KeyCode == Keys.Return)
            {
                SelectCurrent();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                SelectedCode = null;
                SetSelectedValue(null, true);
                e.Handled = true;
            }
        }

        void dgvRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SelectedCode = null;
                SetSelectedValue(null, true);
            }
        }

        void dgvRows_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            if (e.ColumnIndex == dgcName.Index)
            {
                SelectCurrent();
                return;
            }
        }

    }
}
