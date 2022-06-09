using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsA.Classes;
using KlonsA.DataSets;
using KlonsA.DataSets.KlonsADataSetTableAdapters;
using KlonsLIB.Data;
using KlonsLIB.Misc;
using KlonsLIB.Forms;
using KlonsLIB.Components.SpanCell;

namespace KlonsA.Forms
{
    public partial class Form_TimeSheet_Person : MyFormBaseA
    {
        public Form_TimeSheet_Person()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            //dgvLapa.AutoGenerateColumns = false;

        }

        private void Form_TimeSheet_Person_Load(object sender, EventArgs e)
        {

        }
    }
}
