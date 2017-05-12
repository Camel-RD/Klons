using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace KlonsP.Classes
{
    public class MyStyleDefs : Component
    {
        public Color MarkedCellFore { get; set; } = Color.White;
        public Color MarkedCellBack { get; set; } = Color.Brown;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCellStyle MarkedCell = null;

        public void MakeStyles(DataGridView dgv)
        {
            MarkedCell = new DataGridViewCellStyle(dgv.DefaultCellStyle);
            MarkedCell.ForeColor = MarkedCellFore;
            MarkedCell.BackColor = MarkedCellBack;
        }

    }
}
