using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsF.Classes;
using KlonsF.FormsReportParams;
using KlonsF.UI;

namespace KlonsF.Forms
{
    public partial class Form_PVN_Dekl : MyFormBaseF
    {
        public Form_PVN_Dekl()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvRows.AutoGenerateColumns = false;
        }

        List<PVNRepRow> DataRows = new List<PVNRepRow>();
        public void SetData(List<PVNRepRow> rows)
        {
            DataRows = rows;
            dgvRows.DataSource = rows;
        }

        private void dgvRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DataRows == null || DataRows.Count == 0) return;
            var row = DataRows[e.RowIndex];
            if (e.ColumnIndex == 0 && row.LeftPadded)
                e.CellStyle.Padding = new Padding(20, 0, 0, 0);
            if (row.Bold)
                e.CellStyle.Font = new Font(Font, FontStyle.Bold);
        }
    }
}
