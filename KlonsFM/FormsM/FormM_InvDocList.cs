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
using KlonsLIB.Components;

namespace KlonsFM.FormsM
{
    public partial class FormM_InvDocList : MyFormBaseF, IMyDgvTextboxEditingControlEvents2
    {
        public FormM_InvDocList()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgvFilter.AutoGenerateColumns = false;

            dgcDocsState.ColorMarkNeeded += DgcDocsState_ColorMarkNeeded;

            dgcFilterState.DataSource = SomeDataDefs.DocStates;
            dgcFilterState.ValueMember = "Key";
            dgcFilterState.DisplayMember = "Val";
            dgcFilterState.ColumnNames = new[] { "Key", "Val" };
            dgcFilterState.ColumnWidths = "0;150";
        }

        private void FormM_InvDocList_Load(object sender, EventArgs e)
        {
            LoadParams();
            LoadDataOnOpen();
        }

        private void LoadParams()
        {
            docFilterData1.Dt1 = MyData.Params.MFILTERDOCSDT1;
            docFilterData1.Dt2 = MyData.Params.MFILTERDOCSDT2;
        }

        public override void SaveParams()
        {
            MyData.Params.MFILTERDOCSDT1 = docFilterData1.Dt1;
            MyData.Params.MFILTERDOCSDT2 = docFilterData1.Dt2;
        }

        public void LoadData()
        {
            if (!dgvFilter.EndEdit()) return;
            if (!SaveData()) return;
            DataMLoader.LoadInvDocsByFilter(
                docFilterData1.Dt1,
                docFilterData1.Dt2,
                docFilterData1.DocState,
                docFilterData1.IdStoreIn);
        }

        public void LoadDataOnOpen()
        {
            if (!HasParamsSet()) return;
            if (MyData.DataSetKlonsM.M_INV_DOCS.Rows.Count > 0) return;
            if (MyData.DataSetKlonsM.M_INV_DOCS.HasChanges()) return;
            if (MyData.DataSetKlonsM.M_INV_ROWS.HasChanges()) return;
            LoadData();
        }

        public bool HasParamsSet()
        {
            return docFilterData1.Dt1 != null || docFilterData1.Dt2 != null ||
                docFilterData1.DocState != null || docFilterData1.IdStoreIn != null;
        }

        private void DgcDocsState_ColorMarkNeeded(object sender, DataGridViewColorMarkColumnEventArgs e)
        {
            e.MarkColor = myConfigA1.DocStatusColor1;
            if (e.RowNr == dgvDocs.NewRowIndex) return;
            var dr_doc = (bsDocs[e.RowNr] as DataRowView)?.Row as KlonsMDataSet.M_INV_DOCSRow;
            if (dr_doc == null) return;
            if (dr_doc.XState == EInventoryDocState.Iegrāmatots)
                e.MarkColor = myConfigA1.DocStatusColor3;
            else if (dr_doc.XState == EInventoryDocState.Apstiprināts ||
                dr_doc.XState == EInventoryDocState.Salīdzināts)
                e.MarkColor = myConfigA1.DocStatusColor2;
        }

        private KlonsMDataSet.M_INV_DOCSRow GetCurrentDocRow()
        {
            if (bsDocs.Count == 0 || bsDocs.Current == null ||
                dgvDocs.CurrentRow.Index == dgvDocs.NewRowIndex) return null;
            var dr_doc = bsDocs.CurrentDataRow as KlonsMDataSet.M_INV_DOCSRow;
            return dr_doc;
        }

        private KlonsMDataSet.M_INV_DOCSRow GetGoodCurrentDocRow()
        {
            var dr_doc = GetCurrentDocRow();
            if (dr_doc == null) return null;
            if (!SaveData())
            {
                MyMainForm.ShowWarning("Neizdevās nesaglabāt datus.");
                return null;
            }
            if (myAdapterManager1.HasChanges())
            {
                MyMainForm.ShowWarning("Ir nesaglabāti dati.");
                return null;
            }
            return dr_doc;
        }

        public override bool SaveData()
        {
            if (!dgvDocs.EndEditX()) return false;
            if (!this.Validate()) return false;
            try
            {
                DataTasks.SetNewIDs(myAdapterManager1);
                bool rt = myAdapterManager1.UpdateAll();
                CheckSave();
                return rt;
            }
            catch (Exception e)
            {
                CheckSave();
                Form_Error.ShowException(e, "Neizdevās saglabāt izmaiņas.");
                return false;
            }
        }

        private bool HasChanges()
        {
            return myAdapterManager1.HasChanges();
        }

        private void CheckSave()
        {
            SetSaveButton(HasChanges());
        }

        private void SetSaveButton(bool red)
        {
            bNav.SetSaveButtonRed(red);
        }

        public int? GetStoreId(string code, EStoreType storefilter = EStoreType.Nenoteikts)
        {
            return FormM_Stores.GetStoreId(code, storefilter);
        }

        public string GetStoreCode(string code)
        {
            return FormM_Stores.GetStoreCode(code);
        }

        public void GetDocStoreId()
        {
            var dv = this.ActiveControl.Text;
            var rt = GetStoreId(dv);
            if (rt == null) return;
            SetCurrentDocEditorValue(rt.Value);
        }

        private void SetCurrentDocEditorValue(int value)
        {
            if (this.ActiveControl == null) return;
            try
            {
                if (this.ActiveControl is KlonsLIB.Components.MyMcComboBox)
                {
                    var c = this.ActiveControl as KlonsLIB.Components.MyMcComboBox;
                    c.SelectedValue = value;
                }
                else if (this.ActiveControl is KlonsLIB.Components.MyPickRowTextBox2)
                {
                    var c = this.ActiveControl as KlonsLIB.Components.MyPickRowTextBox2;
                    c.SelectedValue = value;
                }
            }
            catch (Exception) { }
        }

        public bool SelectDoc(int id)
        {
            for (int i = 0; i < bsDocs.Count; i++)
            {
                var dr = (bsDocs[i] as DataRowView).Row as KlonsMDataSet.M_INV_DOCSRow;
                if (dr == null) continue;
                if (dr.ID != id) continue;
                bsDocs.Position = i;
                return true;
            }
            return false;
        }

        private int SearchDocText(string text, int colindex,
            int startindex = 0, bool forward = true)
        {
            string propname = dgvDocs.Columns[colindex].DataPropertyName;
            if (bsDocs.Count == 0) return -1;
            if (startindex < 0 || startindex >= bsDocs.Count) return -1;
            if (string.IsNullOrEmpty(text)) return -1;
            if (startindex == 0 && !forward) return -1;
            if (startindex == bsDocs.Count - 1 && forward) return -1;
            var rv = bsDocs[startindex] as DataRowView;
            if (rv == null) return -1;
            int colnr = rv.Row.Table.Columns.IndexOf(propname);
            if (colnr == -1) return -1;
            int di = forward ? 1 : -1;
            string val;
            text = text.ToLower();
            for (int i = startindex; i >= 0 && i < bsDocs.Count; i += di)
            {
                var dr = (bsDocs[i] as DataRowView).Row as KlonsMDataSet.M_INV_DOCSRow;
                if (dr == null) continue;
                string columnname = dr.Table.Columns[colnr].ColumnName;
                val = null;
                switch (columnname)
                {
                    case "DT":
                        val = dr.DT.ToString("dd.MM.yyyy");
                        break;
                    case "NR":
                        val = dr.NR;
                        break;
                    case "IDSTORE":
                        val = MyData.DataSetKlonsM.M_STORES.FindByID(dr.IDSTORE)?.CODE;
                        break;
                }
                if (val == null) continue;
                if (val.ToLower().Contains(text))
                {
                    return i;
                }
            }
            return -1;
        }

        private void SearchDocText(bool fromfirst = true, bool forward = true)
        {
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;
            if (!dgvDocs.EndEditX()) return;

            int startindex = dgvDocs.CurrentRow.Index;
            startindex = fromfirst ? 0 : (forward ? startindex + 1 : startindex - 1);
            string text = tsbFind.Text;
            if (text == "") return;
            int newindex = SearchDocText(text, dgvDocs.CurrentCell.ColumnIndex, startindex, forward);
            if (newindex == -1)
            {
                MyMainForm.ShowInfo("Tekts [" + text + "] netika atrasts.");
                return;
            }
            dgvDocs.CurrentCell = dgvDocs[dgvDocs.CurrentCell.ColumnIndex, newindex];
        }

        private void dgvDocs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value) return;

            if (e.ColumnIndex == dgcDocsState.Index)
            {
                var xstate = (EInventoryDocState)((int)e.Value);
                e.Value = SomeDataDefs.GetInventoryDocStateText(xstate);
                e.FormattingApplied = true;
            }

        }

        private void bniSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void dgvDocs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void bNav_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void dgvDocs_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            SaveData();
        }

        private void bsDocs_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void tsbFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SearchDocText();
                dgvDocs.Focus();
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                dgvDocs.Focus();
                e.Handled = true;
                return;
            }
        }

        private void tsbFind_Enter(object sender, EventArgs e)
        {
            tsbFind.Text = "";
        }

        private void tsbFindPrev_Click(object sender, EventArgs e)
        {
            SearchDocText(false, false);
            dgvDocs.Focus();
        }

        private void tsbFindNext_Click(object sender, EventArgs e)
        {
            SearchDocText(false, true);
            dgvDocs.Focus();
        }

        private void dgvFilter_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value) return;

            if (e.ColumnIndex == dgcFilterState.Index)
            {
                var xstate = (EInventoryDocState)((int)e.Value);
                e.Value = SomeDataDefs.GetInventoryDocStateText(xstate);
                e.FormattingApplied = true;
            }
        }

        private void dgvFilter_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcFilterDt1.Index ||
                e.ColumnIndex == dgcFilterDt2.Index)
            {
                Utils.DGVParseDateCell(e);
                return;
            }
        }

        void IMyDgvTextboxEditingControlEvents2.OnButtonClicked(MyDgvTextboxEditingControl2 control)
        {
            if (control.DataSource == bsStore)
            {
                GetDocStoreId();
                return;
            }
        }


        public void DoNewDoc()
        {
            var table_docs = MyData.DataSetKlonsM.M_INV_DOCS;
            var dr = table_docs.NewM_INV_DOCSRow();
            dr.DT = DateTime.Today;
            dr.XState = EInventoryDocState.Melnraksts;
            table_docs.Rows.Add(dr);
            var form = MyMainForm.ShowFormMDialog<FormM_InvDoc>((Action<int>)null);
            bool rt = form.FindDoc(dr.ID);
            if (!rt)
            {
                form.Close();
                MyMainForm.ShowError("Neizdevās atvērt dokumentu.");
                return;
            }
        }

        public void DoOpenDoc()
        {
            if (!SaveData()) return;
            var dr = GetCurrentDocRow();
            if (dr == null) return;
            DataMLoader.LoadInvRowsByFilter(dr.ID, true);
            FormM_InvDoc.ShowDocMyDialog(dr.ID);
        }

        private void dgvDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgcDocsDT.Index ||
               e.ColumnIndex == dgcDocsNr.Index)
            {
                DoOpenDoc();
            }
        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void bniAdd_Click(object sender, EventArgs e)
        {
            DoNewDoc();
        }

        private void tsbOpenDoc_Click(object sender, EventArgs e)
        {
            DoOpenDoc();
        }
    }
}
