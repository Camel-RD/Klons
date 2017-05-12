using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsP.Classes;
using KlonsP.Forms;

namespace KlonsP.Forms
{
    public partial class Form_CompanyData : MyFormBaseP
    {
        public Form_CompanyData()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            companyData1.LoadData();

            myGrid1.MakeGrid();
            myGrid1.LinkGrid();

        }

        private void FormCompanyData_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void FormCompanyData_FormClosing(object sender, FormClosingEventArgs e)
        {
            companyData1.SaveData();
            MyData.UpdateTable(MyData.DataSetKlons.PARAMS);
        }
    }
}
