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
using KlonsF.Forms;
using KlonsF.UI;

namespace KlonsF.Forms
{
    public partial class Form_CompanyData : MyFormBaseF
    {
        public Form_CompanyData()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private CompanyData CompanyData = null;

        private void SelectFirstGridItem()
        {
            GridItem gi = this.pgData.SelectedGridItem;
            if (gi == null) return;
            GridItem pgi = gi.Parent.Parent;
            if (pgi == null) pgi = gi;

            List<GridItem> sortedCats = new List<GridItem>(pgi.GridItems.Cast<GridItem>());
            sortedCats.Sort(delegate(GridItem gi1, GridItem gi2) { return gi1.Label.CompareTo(gi2.Label); });

            for (int i = 0; i < pgi.GridItems.Count; i++)
            {
                if (pgi.GridItems[i] == gi) break;
                if (pgi.GridItems[i].Label == sortedCats[0].Label)
                {
                    pgi.GridItems[i].Select();
                    break;
                }
            }            
        }

        private void FormCompanyData_Load(object sender, EventArgs e)
        {
            CompanyData = new CompanyData();
            CompanyData.LoadData();
            pgData.SelectedObject = CompanyData;
            pgData.Refresh();
            SelectFirstGridItem();
        }

        private void FormCompanyData_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompanyData.SaveData();
            MyData.UpdateTable(MyData.DataSetKlons.Params);
        }
    }
}
