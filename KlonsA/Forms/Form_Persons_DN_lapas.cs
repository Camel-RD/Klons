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
    public partial class Form_Persons_DN_lapas : MyFormBaseA
    {
        public Form_Persons_DN_lapas()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvFull.AutoGenerateColumns = false;
            dgvChanges.AutoGenerateColumns = false;
            dgvNoMatch.AutoGenerateColumns = false;
            var dt1 = DateTime.Today.FirstDayOfMonth().AddMonths(-1);
            tbDate1.Text = Utils.DateToString(dt1);
            tbDate2.Text = Utils.DateToString(dt1.LastDayOfMonth());
            DgvDisableSort(dgvFull);
            DgvDisableSort(dgvChanges);
            DgvDisableSort(dgvNoMatch);
            cbPage.SelectedIndex = 0;
        }

        void DgvDisableSort(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void Form_Persons_DN_lapas_Load(object sender, EventArgs e)
        {

        }

        public BindingList<DNLapaImportData> DataFullList = null;
        public BindingList<DNLapaImportData> DataChanges = null;
        public BindingList<DNLapaImportData> DataNoMatch = null;
        public NM_dn_dnl DnLapas = null;
        public DateTime DT1 = DateTime.MinValue;
        public DateTime DT2 = DateTime.MinValue;


        public string CheckDates()
        {
            if (tbDate1.Text.IsNOE() || tbDate2.Text.IsNOE())
            {
                return "Nav norādīti datumi.";
            }
            if (!Utils.StringToDate(tbDate1.Text, out var dt1) ||
                !Utils.StringToDate(tbDate2.Text, out var dt2) ||
                dt2 < dt1)
            {
                return "Norādīts nekorekts datums";
            }
            DT1 = dt1;
            DT2 = dt2;
            return "OK";
        }
        
        public bool DoReadFromFile()
        {
            var rt = CheckDates();
            if (rt != "OK")
            {
                MyMainForm.ShowWarning(rt);
                return false;
            }

            var ofd = new OpenFileDialog();
            ofd.Filter = "XML faili (*.xml)|*.xml";
            //ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.Title = "Norādi EDS pārskata xml failu";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog(MyMainForm) != DialogResult.OK) return false;
            var fnm = ofd.FileName;

            var dnlapas = EdsDNLapasImporter.LoadData(fnm);
            if (dnlapas == null)
            {
                MyMainForm.ShowWarning("Neizdevās nolasīt pārskata xml failu");
                return false;
            }

            var dt3 = DateTime.Today.AddDays(-1);
            var edt1 = dnlapas.pamatdati.periods_no;
            var edt2 = dnlapas.pamatdati.periods_lidzSpecified ?
                dnlapas.pamatdati.periods_lidz :
                dt3;

            if (edt1 > DT1 || edt2 < DT2)
            {
                MyMainForm.ShowWarning("EDS pārskata periods neatbilst pieprasītajam.");
                return false;
            }

            DnLapas = dnlapas;

            return true;
        }


        public void DoReadDnLapas()
        {
            if (DnLapas == null)
            {
                MyMainForm.ShowWarning("Nav nolasīts datu fails.");
                return;
            }

            var importer = new EdsDNLapasImporter();
            var rt_msg = importer.GetResults(DnLapas, DT1, DT2, out var missingnames,
                out var fulllist, out var changes, out var nomatch);
            if (rt_msg != "OK")
            {
                MyMainForm.ShowWarning(rt_msg);
                return;
            }
            if (missingnames.Count > 0)
            {
                var msg = string.Join("\n", missingnames);
                MyMainForm.ShowError("Nav datu par šiem darbiniekiem:\n" + msg);
            }
            DataFullList = new BindingList<DNLapaImportData>(fulllist);
            DataChanges = new BindingList<DNLapaImportData>(changes);
            DataNoMatch = new BindingList<DNLapaImportData>(nomatch);
            bsFullList.DataSource = fulllist;
            bsChanges.DataSource = changes;
            bsNoMatch.DataSource = nomatch;
        }

        public string CheckChanges()
        {
            if (DataChanges == null || DataChanges.Count == 0)
                return "Nav izmaiņu datu.";
            foreach (var change in DataChanges)
            {
                if (change.DNLapaImportType != EDNLapaImportType.AddNew &&
                    change.DNLapaImportType != EDNLapaImportType.SetEndDate)
                    continue;
                if (change.EDS_Dt1 == null || change.EDS_Dt2 == null)
                    return "Nav norādīti datumi";
                if (change.EDS_Dt1.Value > change.EDS_Dt2.Value)
                    return "Nekorekti datumi";
                if (change.EDS_Veids != "A" && change.EDS_Veids != "B")
                    return "Nekorekts lapas veids";
            }
            return "OK";
        }

        public string ApplyChanges()
        {
            var rt = CheckChanges();
            if (rt != "OK") return rt;

            var table_events = MyData.DataSetKlons.EVENTS;
            foreach (var change in DataChanges)
            {
                if (change.DNLapaImportType == EDNLapaImportType.AddNew)
                {
                    var dr_new = table_events.NewEVENTSRow();
                    dr_new.BeginEdit();
                    dr_new.IDP = change.IDP;
                    dr_new.EventCode = change.EDS_Veids == "A" ?
                        EEventId.Slimības_lapa_A :
                        EEventId.Slimības_lapa_B;
                    dr_new.DATE1 = change.EDS_Dt1.Value;
                    dr_new.DATE2 = change.EDS_Dt2.Value;
                    dr_new.EndEdit();
                    table_events.Rows.Add(dr_new);
                }
                if (change.DNLapaImportType == EDNLapaImportType.SetEndDate)
                {
                    var dr = table_events.FindByID(change.IDEV);
                    if (dr == null) continue;
                    dr.BeginEdit();
                    dr.DATE2 = change.EDS_Dt2.Value;
                    dr.EndEdit();
                }
            }
            try
            {
                DataTasks.SetNewIDs("EVENTS");
                MyData.UpdateTable(table_events);
            }
            catch(Exception ex)
            {
                return "Neizdevās saglabāt izmaiņas.";
            }
            return "OK";
        }

        private void cmLoadFromFile_Click(object sender, EventArgs e)
        {
            var rt = DoReadFromFile();
            if (!rt) return;
            DoReadDnLapas();
        }

        private void cmSaveChanges_Click(object sender, EventArgs e)
        {
            var rt = ApplyChanges();
            if(rt != "OK")
            {
                MyMainForm.ShowInfo(rt);
                return;
            }
            DoReadDnLapas();
        }


        private void dgvChanges_Enter(object sender, EventArgs e)
        {
            bNav.BindingSource = bsChanges;
            bNav.DataGrid = dgvChanges;
            tslActiveGrid.Text = "Izmaiņas";
            bindingNavigatorDeleteItem.Visible = true;
        }

        private void dgvNoMatch_Enter(object sender, EventArgs e)
        {
            bNav.BindingSource = bsNoMatch;
            bNav.DataGrid = dgvNoMatch;
            tslActiveGrid.Text = "Nesakritības";
            bindingNavigatorDeleteItem.Visible = false;
        }

        private void dgvFull_Enter(object sender, EventArgs e)
        {
            bNav.BindingSource = bsFullList;
            bNav.DataGrid = dgvFull;
            tslActiveGrid.Text = "Visas lapas";
            bindingNavigatorDeleteItem.Visible = false;
        }


        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPage.SelectedIndex == 0)
                tcPages.SelectedIndex = 0;
            if (cbPage.SelectedIndex == 1)
                tcPages.SelectedIndex = 1;
            if (cbPage.SelectedIndex == 2)
                tcPages.SelectedIndex = 2;
        }

        private void dgvChanges_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcChangesEdsDt1.Index ||
                e.ColumnIndex == dgcChangesEdsDt2.Index)
            {
                if (e.Value == null) return;
                if (!Utils.DGVParseDateCell(e))
                {
                    e.Value = null;
                    e.ParsingApplied = true;
                    return;
                }
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (tcPages.SelectedIndex != 0) return;
            if (!AskCanDelete()) return;
            bNav.DeleteCurrent();
        }

        private void tsbPrevMonth_Click(object sender, EventArgs e)
        {
            int k = cbPage.SelectedIndex - 1;
            if (k < 0) k = 2;
            cbPage.SelectedIndex = k;
        }

        private void tsbNextMonth_Click(object sender, EventArgs e)
        {
            int k = cbPage.SelectedIndex + 1;
            if (k > 2) k = 0;
            cbPage.SelectedIndex = k;
        }
    }
}
