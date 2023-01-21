using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.UI;
using KlonsFM.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsFM.Forms
{
    public partial class Form_FilesNew : MyFormBaseF
    {
        public Form_FilesNew()
        {
            InitializeComponent();
            CheckMyFontAndColors();
        }

        private string name = null;
        private string descr = null;

        private void Form_FilesNew_Load(object sender, EventArgs e)
        {
            SetControlsUpDownOrder(new Control[][]
            {
                new Control[] {tbName, tbDescr},
                new Control[] {tbDescr, tbDescr},
                new Control[] {cmOK, cmCancel}
            });
        }

        private string Check()
        {
            name = tbName.Text.LeftMax(100);
            descr = tbDescr.Text.LeftMax(500);
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(descr))
            {
                return "Jāaizpilda lauki.";
            }
            if (MyData.MasterList.GetMasterEntryByName(name) != null)
            {
                return "Datu bāze ar šādu nosaukumu jau ir sarakstā.";
            }

            return "OK";
        }

        private void DoIt()
        {
            string rt = Check();
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return;
            }

            try
            {
                MyData.CreateNewDB(name, descr);
            }
            catch (Exception ex)
            {
                Form_Error.ShowException(this,
                    new Exception("Neizdevās izveidot jaunu datubāzi.", ex));
                return;
            }
            MyData.SaveMasterList();
            MyMainForm.ShowInfo
                (
                    "Pēc jaunas datubāzes izveidošanas neaizmirstam idarīt sekojošo:\n" +
                    "1. Rediģēt lietotāju sarakstu\n" +
                    "2. Aizpildīt formu 'Ziņas par uzņēmumu'\n" +
                    "3. Formā 'Kā strādādim?' atzīmēt nepieciešamās kontējuma pazīmes\n" +
                    "4. Rediģēt kontu plānu\n" +
                    "5. Aizpildīt formu 'Kontējumu korekcijas'"
                );
            DialogResult = DialogResult.OK;
        }

        private void cmOK_Click(object sender, EventArgs e)
        {
            DoIt();
        }

        private void cmCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            OnNaviKey(sender, e);
        }
    }
}
