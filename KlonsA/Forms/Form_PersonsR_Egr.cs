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
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsA.Forms
{
    public partial class Form_PersonsR_Egr : MyFormBaseA
    {
        public Form_PersonsR_Egr()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvRows.AutoGenerateColumns = false;
            var dt1 = DateTime.Today.FirstDayOfMonth().AddMonths(-1);
            tbDate1.Text = Utils.DateToString(dt1);
            tbDate2.Text = Utils.DateToString(dt1.LastDayOfMonth());
        }

        List<EgrImportData> Changes = null;

        private void Form_PersonsR_Egr_Load(object sender, EventArgs e)
        {

        }

        public void DoRead()
        {
            if (tbDate1.Text.IsNOE() || tbDate2.Text.IsNOE())
            {
                MyMainForm.ShowWarning("Nav norādīti datumi.");
                return;
            }

            if (!Utils.StringToDate(tbDate1.Text, out var dt1) ||
                !Utils.StringToDate(tbDate2.Text, out var dt2) ||
                dt2 < dt1)
            {
                MyMainForm.ShowWarning("Norādīts nekorekts datums");
                return;
            }

            var ofd = new OpenFileDialog();
            ofd.Filter = "XML faili (*.xml)|*.xml";
            //ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.Title = "Norādi EDS pārskata xml failu";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog(MyMainForm) != DialogResult.OK) return;
            var fnm = ofd.FileName;

            var importer = new EGrmUntMinImporter();
            var rt_msg = importer.GetEgrResult(fnm, dt1, dt2, out var missingnames, out var changes);
            Changes = changes;
            bsRows.DataSource = changes;
            if (rt_msg != "OK")
            {
                MyMainForm.ShowWarning(rt_msg);
                return;
            }
            if (missingnames.Count > 0)
            {
                var msg = string.Join("\n", missingnames);
                MyMainForm.ShowInfo("Nav datu par šiem darbiniekiem:\n" + msg);
            }
            if (changes.Count == 0)
            {
                MyMainForm.ShowInfo("Pārskats nesatur jaunus datus.");
            }
        }

        private void cmLoadFromFile_Click(object sender, EventArgs e)
        {
            DoRead();
        }

        private void dgvRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgcHasIt.Index || e.ColumnIndex == dgcEDSHasIt.Index)
            {
                bool val = (bool)e.Value;
                var sval = val? "X" : "";
                e.Value = sval;
                e.FormattingApplied = true;
            }
        }
    }
}
