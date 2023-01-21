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
using KlonsLIB.Misc;
using KlonsFM.UI;

namespace KlonsFM.FormsM
{
    public partial class FormM_Params : MyFormBaseF
    {
        public FormM_Params()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            LoadParams();

            myGrid1.MakeGrid2();
            myGrid1.LinkGrid();
            myGrid1.Refresh();

            grMainStore.ButtonClicked += GrMainStore_ButtonClicked;
        }

        private void FormM_Params_Load(object sender, EventArgs e)
        {

        }

        public void LoadParams()
        {
            paramsMData1._MainnStoreCode = MyData.Params.MAINSTORE;
        }

        public void SaveParamsA()
        {
            MyData.Params.MAINSTORE = paramsMData1._MainnStoreCode;
            MyData.Params.Save();
        }

        private void GrMainStore_ButtonClicked(object sender, EventArgs e)
        {
            var code = (string)grMainStore.Value;
            code = FormM_Stores.GetStoreCode(code);
            if (code.IsNOE()) return;
            grMainStore.Value = code;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            SaveParamsA();
            DialogResult = DialogResult.OK;
        }
    }
}
