using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using KlonsA.Classes;
using KlonsA.DataSets;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsA.Forms
{
    public partial class Form_UntaxedMinimumImport : MyFormBaseA
    {
        public Form_UntaxedMinimumImport()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvRows.AutoGenerateColumns = false;
        }

        private void Form_UntaxedMinimumImport_Load(object sender, EventArgs e)
        {

        }

        NM_e_gramatinas EGramatinas = null;
        List<UntMinImportData> Changes = null;


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
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.Title = "Norādi EDS pārskata xml failu";
            if (ofd.ShowDialog(MyMainForm) != DialogResult.OK) return;
            var fnm = ofd.FileName;

            var importer = new EGrmUntMinImporter();
            var rt_msg = importer.GetUntMinResult(fnm, dt1, dt2, out var missingnames, out var changes);
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

        public void UpdateDB()
        {
            if(Changes == null || Changes.Count == 0)
            {
                MyMainForm.ShowInfo("Iegrāmatošanai nav datu.");
                return;
            }
            var table = MyData.DataSetKlons.UNTAXED_MIN;
            foreach(var change in Changes)
            {
                var dr_um = table
                    .WhereX(d => d.IDP == change.IDP && d.ONDATE == change.Dt)
                    .FirstOrDefault();
                if(dr_um == null)
                {
                    dr_um = table.NewUNTAXED_MINRow();
                    dr_um.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_UNTAXED_MIN_ID();
                    dr_um.IDP = change.IDP;
                    dr_um.ONDATE = change.Dt;
                    dr_um.UNTAXED_MIN = change.UntMin;
                    dr_um.IIN_RATE_TYPE = change.IINRateType;
                    table.Rows.Add(dr_um);
                }
                else
                {
                    dr_um.UNTAXED_MIN = change.UntMin;
                    dr_um.IIN_RATE_TYPE = change.IINRateType;
                }

                try
                {
                    MyData.UpdateTable(table);
                }
                catch(Exception ex)
                {
                    try
                    {
                        table.RejectChanges();
                    }
                    catch (Exception ) {}
                    MyMainForm.ShowWarning("Neizdevās saglabāt iegrāmatotās izmaiņas.");
                }
            }
        }

        private void RefreshUntMinForm()
        {
            var frm = MyMainForm.FindForm(typeof(Form_UntaxedMinimum)) as Form_UntaxedMinimum;
            if (frm == null) return;
            frm.DoCmFilte();
        }

        private void cmLoadFromFile_Click(object sender, EventArgs e)
        {
            DoRead();
        }

        private void cmUpdateDB_Click(object sender, EventArgs e)
        {
            UpdateDB();
            RefreshUntMinForm();
        }

        private void dgvRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == dgcIINRate.Index)
            {
                int val = (int)e.Value;
                var sval = val == 1 ? "23" : "20";
                e.Value = sval;
                e.FormattingApplied = true;
            }
        }
    }


}
