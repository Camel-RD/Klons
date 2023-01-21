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
    public partial class FormM_PVNRates : MyFormBaseF
    {
        public FormM_PVNRates()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void FormM_PVNRates_Load(object sender, EventArgs e)
        {

        }

        public string SelectedCode = null;

        public static string GetPVNRateCode(string code)
        {
            var fm = new FormM_PVNRates();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedCode;
        }

        public static int? GetPVNRateId()
        {
            var fm = new FormM_PVNRates();
            var ret = fm.ShowMyDialogModal();
            if (ret != DialogResult.OK) return null;
            return fm.SelectedValueInt;
        }

        private void SelectCurrent()
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            var dr = bsPVNRate.CurrentDataRow as KlonsMDataSet.M_PVNRATESRow;
            if (!dgvRows.EndEdit()) return;
            if (!SaveData()) return;
            if (dr.RowState == DataRowState.Detached) return;
            int id = dr.ID;
            SelectedCode = dr.CODE;
            if (!this.IsMyDialog) return;
            SetSelectedValue(id);
        }

        private void dgvRows_MyKeyDown(object sender, KeyEventArgs e)
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

        private void dgvRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                SelectedCode = null;
                SetSelectedValue(null, true);
            }
        }

        private void dgvRows_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            if (e.ColumnIndex == dgcCode.Index)
            {
                SelectCurrent();
                return;
            }

        }
    }
}
