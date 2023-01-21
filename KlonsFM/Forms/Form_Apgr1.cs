using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsFM.Classes;
using KlonsFM.UI;

namespace KlonsFM.Forms
{
    public partial class Form_Apgr1 : MyFormBaseF
    {
        public Form_Apgr1()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private void Form_Apgr1_Load(object sender, EventArgs e)
        {
            LoadParams();
        }

        public void LoadParams()
        {
            var rsd = MyData.Params.RSD;
            var red = MyData.Params.RED;
            var rac = MyData.Params.RACX;
            tslParams.Text = $"Konts: {rac}, periods: {rsd} - {red}";
        }

    }
}
