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
using KlonsA.Forms;

namespace KlonsA.Forms
{
    public partial class Form_CompanyData : MyFormBaseA
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
