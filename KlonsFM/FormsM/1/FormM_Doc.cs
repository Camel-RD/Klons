using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsF.DataSets;
using KlonsF.Classes;
using KlonsLIB.Forms;
using KlonsLIB.Data;
using KlonsLIB.Misc;
using KlonsF.UI;
using KlonsLIB.Components;

namespace KlonsF.FormsM
{
    public partial class FormM_Doc : MyFormBaseF, 
        IMyDgvTextboxEditingControlEvents2, IMyDgvTextboxEditingControlEvents
    {
        public FormM_Doc()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            dgcDocsState.ColorMarkNeeded += DgcDocsState_ColorMarkNeeded;
        }

        private void LoadParams()
        {

        }

        public override void SaveParams()
        {


        }

        private void FormM_Doc_Load(object sender, EventArgs e)
        {
            CheckEnableRows();
            CheckSave();
            dgvDocs.Focus();
            MyData.DataSetKlonsM.M_DOCS.ColumnChanged += M_DOCS_ColumnChanged;
            MyData.DataSetKlonsM.M_ROWS.ColumnChanged += M_ROWS_ColumnChanged;

            MyData.DataSetKlonsM.M_ROWS.M_ROWSRowDeleted += M_ROWS_M_ROWSRowDeleted;
            MyData.DataSetKlonsM.M_ROWS.M_ROWSRowDeleting += M_ROWS_M_ROWSRowDeleting;
            MyData.DataSetKlonsM.M_ROWS.M_ROWSRowChanged += M_ROWS_M_ROWSRowChanged;
            //MyData.DataSetKlonsM.M_DOCS.TableNewRow += M_DOCS_TableNewRow;
        }

        private void FormM_Doc_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlonsM.M_DOCS.ColumnChanged -= M_DOCS_ColumnChanged;
            MyData.DataSetKlonsM.M_ROWS.ColumnChanged -= M_ROWS_ColumnChanged;

            MyData.DataSetKlonsM.M_ROWS.M_ROWSRowDeleted -= M_ROWS_M_ROWSRowDeleted;
            MyData.DataSetKlonsM.M_ROWS.M_ROWSRowDeleting -= M_ROWS_M_ROWSRowDeleting;
            MyData.DataSetKlonsM.M_ROWS.M_ROWSRowChanged -= M_ROWS_M_ROWSRowChanged;
        }


        private KlonsMDataSet.M_DOCSRow last_doc_RowDeleting_parent = null;
        private void M_ROWS_M_ROWSRowDeleting(object sender, KlonsMDataSet.M_ROWSRowChangeEvent e)
        {
            last_doc_RowDeleting_parent = e.Row.M_DOCSRow;
        }

        private void M_ROWS_M_ROWSRowDeleted(object sender, KlonsMDataSet.M_ROWSRowChangeEvent e)
        {

        }

        private void M_ROWS_M_ROWSRowChanged(object sender, KlonsMDataSet.M_ROWSRowChangeEvent e)
        {
            KlonsMDataSet.M_DOCSRow dr = null;

            if(e.Row.RowState == DataRowState.Deleted ||
                e.Row.RowState == DataRowState.Detached)
            {
                if (e.Row.HasVersion(DataRowVersion.Original))
                {
                    int iddoc = (int)e.Row["IDDOC", DataRowVersion.Original];
                    dr = MyData.DataSetKlonsM.M_DOCS.FindByID(iddoc);
                }
                else
                {
                    if (e.Action == DataRowAction.Delete)
                        dr = last_doc_RowDeleting_parent;
                }
            }
            else
            {
                dr = e.Row.M_DOCSRow;
            }
            if (dr == null) return;
            UpdateDocSums(dr);
        }

        private void M_DOCS_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            var dr = e.Row as KlonsMDataSet.M_DOCSRow;
            var table_docs = MyData.DataSetKlonsM.M_DOCS;
            var sq = table_docs.Max(x => x.IDSEQ) + 1;
            dr.IDSEQ = sq;
        }

        private bool ignoreColumnChangeEvent = false;
        private bool InDocs_ColumnChanged = false;
        private bool InRows_ColumnChanged = false;

        private void M_DOCS_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (ignoreColumnChangeEvent) return;
            if (InDocs_ColumnChanged) return;
            InDocs_ColumnChanged = true;
            M_DOCS_ColumnChangedA(e);
            InDocs_ColumnChanged = false;
        }

        private void M_ROWS_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (ignoreColumnChangeEvent) return;
            if (InRows_ColumnChanged) return;
            InRows_ColumnChanged = true;
            M_ROWS_ColumnChangedA(e);
            InRows_ColumnChanged = false;
        }


        private void M_DOCS_ColumnChangedA(DataColumnChangeEventArgs e)
        {
            var table = MyData.DataSetKlonsM.M_DOCS;
            if (e.Column == table.TPColumn ||
                e.Column == table.IDSTOREINColumn ||
                e.Column == table.IDSTOREOUTColumn)
            {
                var dr = e.Row as KlonsMDataSet.M_DOCSRow;
                var doctype = dr.XDocType;
                var storeintype = dr.XStoreInType;
                var storeouttype = dr.XStoreOutType;
                var storeinpvntype = dr.XStoreInPVNType;
                var storeoutpvntype = dr.XStoreOutPVNType;
                var pvntype = SomeDataDefs.GetPVNType(doctype, storeintype, storeouttype,
                    storeinpvntype, storeoutpvntype);
                dr.XPVNType = pvntype;
                dgvDocs.RefreshCurrent();
                return;
            }
        }

        private void M_ROWS_ColumnChangedA(DataColumnChangeEventArgs e)
        {
            var table = MyData.DataSetKlonsM.M_ROWS;
            var table_items = MyData.DataSetKlonsM.M_ITEMS;
            if (e.Column == table.IDITEMColumn)
            {
                var dr = e.Row as KlonsMDataSet.M_ROWSRow;
                int iditem = dr.IDITEM;
                var dr_item = table_items.FindByID(iditem);
                if (dr_item == null) return;
                dr.BeginEdit();
                if(dr.M_DOCSRow.XDocType == EDocType.Realizācija)
                {
                    dr.PRICE0 = dr_item.SELLPRICE;
                    dr.PRICE = dr_item.SELLPRICE;
                    dr.DISCOUNT = 0f;
                }
                else
                {
                    dr.DISCOUNT = 0f;
                    dr.PRICE0 = 0M;
                    dr.PRICE = 0M;
                }
                dr.UNITS = dr_item.UNITS;
                dr.IDPVNRATE = dr_item.PVNRATE;
                dr.EndEdit();
                dgvRows.RefreshCurrent();
            }

            if (e.Column == table.IDITEMColumn ||
                e.Column == table.PRICE0Column ||
                e.Column == table.DISCOUNTColumn ||
                e.Column == table.AMOUNTColumn)
            {
                var dr = e.Row as KlonsMDataSet.M_ROWSRow;
                var price = Math.Round((((decimal)dr.DISCOUNT) / 100M + 1M) * dr.PRICE0, 2);
                var tprice = Math.Round(dr.AMOUNT * price, 2);
                if (dr.PRICE != price) dr.PRICE = price;
                if (dr.TPRICE != tprice) dr.TPRICE = tprice;
                UpdateDocSums(dr.M_DOCSRow);
                dgvRows.RefreshCurrent();
                dgvDocs.RefreshCurrent();
            }

        }

        private void UpdateDocSums(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var drs_rows = dr_doc.GetM_ROWSRows().ToList();
            if (drs_rows.Count == 0)
            {
                if(dr_doc.SUMM != 0M) dr_doc.SUMM = 0M;
                return;
            }
            var docpvndata = DataTasks.GetPVNData(dr_doc);
            decimal summ = docpvndata.PVNBaze + docpvndata.PVN;
            if (dr_doc.SUMM != summ)
                dr_doc.SUMM = summ;
            return;
        }


        private void DgcDocsState_ColorMarkNeeded(object sender, DataGridViewColorMarkColumnEventArgs e)
        {
            e.MarkColor = myConfigA1.DocStatusColor1;
            if (e.RowNr == dgvDocs.NewRowIndex) return;
            var dr_doc = (bsDocs[e.RowNr] as DataRowView)?.Row as KlonsMDataSet.M_DOCSRow;
            if (dr_doc == null) return;
            if (dr_doc.XState == EDocState.Iegrāmatots)
                e.MarkColor = myConfigA1.DocStatusColor2;
            else if (dr_doc.XState == EDocState.Iekontēts)
                e.MarkColor = myConfigA1.DocStatusColor3;
        }


        private KlonsMDataSet.M_DOCSRow GetCurrentDocRow()
        {
            if (bsDocs.Count == 0 || bsDocs.Current == null ||
                dgvDocs.CurrentRow.Index == dgvDocs.NewRowIndex) return null;
            var dr_doc = bsDocs.CurrentDataRow as KlonsMDataSet.M_DOCSRow;
            return dr_doc;
        }

        private KlonsMDataSet.M_DOCSRow GetGoodCurrentDocRow()
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


        private void CheckEnableRows()
        {
            dgvRows.Enabled = dgvDocs.RowCount > 0 && dgvDocs.CurrentRow != null &&
                dgvDocs.CurrentRow != null && !dgvDocs.CurrentRow.IsNewRow;
        }

        public override bool SaveData()
        {
            if (!dgvDocs.EndEditX()) return false;
            if (!dgvRows.EndEditX()) return false;
            if (!this.Validate()) return false;
            try
            {
                DataTasks.SetNewIDs(myAdapterManager1);
                myAdapterManager1.UpdateAll();
                CheckSave();
            }
            catch (Exception e)
            {
                CheckSave();
                Form_Error.ShowException(e, "Neizdevās saglabāt izmaiņas.");
                return false;
            }
            return true;
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

        public void DeleteCurrent()
        {
            if (!CanEditCurrentDoc()) return;
            bNav.DeleteCurrent();
            SaveData();
        }

        public bool CanEditDoc(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            if (dr_doc == null) return false;
            return dr_doc.IsOpenForChanges;
        }

        public bool CanEditCurrentDoc()
        {
            if (dgvDocs.CurrentRow.Index == dgvDocs.NewRowIndex) return true;
            if (bsDocs.Count == 0 || bsDocs.Current == null) return false;
            var dr_doc = bsDocs.CurrentDataRow as KlonsMDataSet.M_DOCSRow;
            if (dr_doc == null) return false;
            return dr_doc.IsOpenForChanges;
        }

        public int? GetStoreId(string code, EStoreType storefilter = EStoreType.Nenoteikts)
        {
            return FormM_Stores.GetStoreId(code, storefilter);
        }

        public string GetStoreCode(string code)
        {
            return FormM_Stores.GetStoreCode(code);
        }

        public int? GetItemId(string code)
        {
            return FormM_Items.GetItemId(code);
        }

        public string GetItemCode(string code)
        {
            return FormM_Items.GetItemCode(code);
        }

        private bool CanEditDocsCurrentCell()
        {
            if (bsDocs.Count == 0 || bsDocs.Current == null) return false;
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return false;
            if (dgvDocs.CurrentCell == null) return false;
            return true;
        }

        private bool CanEditRowsCurrentCell()
        {
            if (bsRows.Count == 0 || bsRows.Current == null) return false;
            if (dgvRows.CurrentRow == null) return false;
            //if (dgvRows.CurrentRow.IsNewRow) return false;
            if (dgvRows.CurrentCell == null) return false;
            return true;
        }

        private void SetCurrentDocsCellValue(int value)
        {
            if (dgvDocs.CurrentCell == null) return;
            try
            {
                dgvDocs.BeginEdit(false);
                if (dgvDocs.EditingControl is KlonsLIB.Components.MyMcComboBox)
                {
                    var c = dgvDocs.EditingControl as KlonsLIB.Components.MyMcComboBox;
                    c.SelectedValue = value;
                }
                else if (dgvDocs.EditingControl is KlonsLIB.Components.MyPickRowTextBox2)
                {
                    var c = dgvDocs.EditingControl as KlonsLIB.Components.MyPickRowTextBox2;
                    c.SelectedValue = value;
                }
                dgvDocs.EndEdit();
            }
            catch (Exception) { }
        }

        private void SetCurrentRowsItemId(int itemid)
        {
            if (dgvRows.CurrentCell == null) return;
            try
            {
                var dr_item = MyData.DataSetKlonsM.M_ITEMS.FindByID(itemid);
                if (dr_item == null) return;
                dgvRows.BeginEdit(false);
                var s = dgvRows.EditingControl.GetType().Name;
                if (dgvRows.EditingControl is KlonsLIB.Components.MyMcComboBox)
                {
                    var c = dgvRows.EditingControl as KlonsLIB.Components.MyMcComboBox;
                    c.SelectedValue = itemid;
                }
                else if (dgvRows.EditingControl is KlonsLIB.Components.MyPickRowTextBox2)
                {
                    var c = dgvRows.EditingControl as KlonsLIB.Components.MyPickRowTextBox2;
                    c.Text = dr_item.BARCODE;
                }
                dgvRows.EndEdit();
            }
            catch (Exception) { }
        }


        public void GetDocStoreId()
        {
            if (!CanEditDocsCurrentCell()) return;
            var dv = dgvDocs.CurrentCell.FormattedValue as string;
            var rt = GetStoreId(dv);
            if (rt == null) return;
            SetCurrentDocsCellValue(rt.Value);
        }

        public void GetRowItemID()
        {
            if (!CanEditRowsCurrentCell()) return;
            var cv = dgvRows.CurrentCell.FormattedValue as string;
            var ret = GetItemId(cv);
            if (ret == null) return;
            //var dr = (dgvRows.CurrentRow.DataBoundItem as DataRowView).Row as KlonsMDataSet.M_ROWSRow;
            SetCurrentRowsItemId(ret.Value);
        }

        public void SelectDoc(int id)
        {
            for (int i = 0; i < bsDocs.Count; i++)
            {
                var dr = (bsDocs[i] as DataRowView).Row as KlonsMDataSet.M_DOCSRow;
                if (dr == null) return;
                if (dr.ID == id)
                {
                    bsDocs.Position = i;
                    return;
                }
            }
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
            object o;
            string val;
            text = text.ToLower();
            for (int i = startindex; i >= 0 && i < bsDocs.Count; i += di)
            {
                var dr = (bsDocs[i] as DataRowView).Row as KlonsMDataSet.M_DOCSRow;
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
                    case "IDSTOREOUT":
                        val = dr.M_STORESRowByFK_M_DOCS_IDSTOREOUT1.CODE;
                        break;
                    case "IDSTOREIN":
                        val = dr.M_STORESRowByFK_M_DOCS_IDSTOREIN1.CODE;
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

            if (e.ColumnIndex == dgcDocsPVNType.Index)
            {
                int id = (int)e.Value;
                var table_pvntype = MyData.DataSetKlonsM.M_PVNTYPE;
                var dr = table_pvntype.FindByID(id);
                if (dr == null) return;
                e.Value = dr.CODE;
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == dgcDocsState.Index)
            {
                var xstate = (EDocState)((int)e.Value);
                e.Value = SomeDataDefs.GetDocStateText(xstate);
                e.FormattingApplied = true;
            }
        }

        private void dgvRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value) return;

            if (e.ColumnIndex == dgcRowsItemName.Index)
            {
                int id = (int)e.Value;
                var table_items = MyData.DataSetKlonsM.M_ITEMS;
                var dr = table_items.FindByID(id);
                if (dr == null) return;
                e.Value = dr.NAME;
                e.FormattingApplied = true;
            }
            if (e.ColumnIndex == dgcRowsUnits.Index)
            {
                int id = (int)e.Value;
                var table_units = MyData.DataSetKlonsM.M_UNITS;
                var dr = table_units.FindByID(id);
                if (dr == null) return;
                e.Value = dr.CODE;
                e.FormattingApplied = true;
            }
            if (e.ColumnIndex == dgcRowsIdPVNRate.Index)
            {
                int id = (int)e.Value;
                var table_units = MyData.DataSetKlonsM.M_PVNRATES;
                var dr = table_units.FindByID(id);
                if (dr == null) return;
                e.Value = dr.CODE;
                e.FormattingApplied = true;
            }

        }

        private void bniSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bniDelete_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void bniNew_Click(object sender, EventArgs e)
        {
            if (bNav.BindingSource == bsRows)
            {
                dgvRows.MoveToNewRow();
            }
            else
            {
                dgvDocs.MoveToNewRow();
            }
        }

        private void dgvDocs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!CanEditCurrentDoc()) return;
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void dgvRows_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!CanEditCurrentDoc()) return;
            if (e.Row.IsNewRow || !AskCanDelete()) e.Cancel = true;
        }

        private void bNav_ItemDeleting(object sender, CancelEventArgs e)
        {
            if (!CanEditCurrentDoc()) return;
            e.Cancel = !AskCanDelete();
        }

        private void dgvDocs_Enter(object sender, EventArgs e)
        {
            bNav.BindingSource = bsDocs;
            bNav.DataGrid = dgvDocs;
            tslActiveGrid.Text = "Dokumenti:";
        }

        private void dgvRows_Enter(object sender, EventArgs e)
        {
            bNav.BindingSource = bsRows;
            bNav.DataGrid = dgvRows;
            tslActiveGrid.Text = "Rindas:";
        }

        private void dgvDocs_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDocs.CurrentCell == null) return;
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvDocs.EndEdit()) return;
                dgvDocs.MoveToNewRow();
                e.Handled = true;
                return;
            }

            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow ||
                dgvDocs.CurrentCell == null) return;
            int colnr = dgvDocs.CurrentCell.ColumnIndex;

            if (e.KeyCode == Keys.F4)
            {
                if (!CanEditCurrentDoc()) return;
                if (colnr == dgcDocsIdStoreIn.Index || colnr == dgcDocsIdStoreOut.Index)
                {
                    GetDocStoreId();
                    e.Handled = true;
                    return;
                }
            }
        }

        private void dgvRows_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvRows.CurrentCell == null) return;
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                DeleteCurrent();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvRows.EndEdit()) return;
                dgvRows.MoveToNewRow();
                e.Handled = true;
                return;
            }

            if (dgvRows.CurrentRow == null || 
                //dgvRows.CurrentRow.IsNewRow ||
                dgvRows.CurrentCell == null) return;
            int colnr = dgvRows.CurrentCell.ColumnIndex;

            if (e.KeyCode == Keys.F4)
            {
                if (!CanEditCurrentDoc()) return;
                if (colnr == dgcRowsIdItem.Index)
                {
                    GetRowItemID();
                    e.Handled = true;
                    return;
                }
            }
        }

        private void dgvDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocs.CurrentRow == null || 
                dgvDocs.CurrentRow.IsNewRow ||
                dgvDocs.CurrentCell == null) return;
            if (!CanEditCurrentDoc()) return;
            int colnr = dgvDocs.CurrentCell.ColumnIndex;
            if (colnr != e.ColumnIndex) return;

            if (colnr == dgcDocsIdStoreIn.Index || colnr == dgcDocsIdStoreOut.Index)
            {
                GetDocStoreId();
            }
        }

        private void dgvRows_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRows.CurrentRow == null || 
                //dgvRows.CurrentRow.IsNewRow ||
                dgvRows.CurrentCell == null) return;
            if (!CanEditCurrentDoc()) return;
            int colnr = dgvRows.CurrentCell.ColumnIndex;

            if (colnr == dgcRowsIdItem.Index)
            {
                GetRowItemID();
                return;
            }
        }

        private void dgvDocs_CurrentCellChanged(object sender, EventArgs e)
        {
            CheckEnableRows();
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

        private void bsRows_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (e.ListChangedType == ListChangedType.Reset) return;
            CheckSave();
        }

        private void dgvDocs_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgcDocsDT.Index)
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

        private void dgvDocs_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            var table_docs = MyData.DataSetKlonsM.M_DOCS;
            var sq = table_docs.Any() ? table_docs.Max(x => x.IDSEQ) + 1 : 1;
            e.Row.Cells[dgcDocsDT.Index].Value = DateTime.Today;
            e.Row.Cells[dgcDocsIdSeq.Index].Value = sq;
        }
        
        private void dgvRows_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            var table_rows = MyData.DataSetKlonsM.M_ROWS;
            var sq = table_rows.Any() ? table_rows.Max(x => x.IDSEQ) + 1 : 1;
            e.Row.Cells[dgcRowsIdSeq.Index].Value = sq;
        }

        void IMyDgvTextboxEditingControlEvents2.OnButtonClicked(MyDgvTextboxEditingControl2 control)
        {
            if (control.DataSource == bsStoreIn || control.DataSource == bsStoreOut)
            {
                GetDocStoreId();
                return;
            }
            if (control.DataSource == bsItems)
            {
                GetRowItemID();
                return;
            }
        }

        void IMyDgvTextboxEditingControlEvents.OnButtonClicked(MyDgvTextboxEditingControl control)
        {
            if (control.DataSource == bsStoreIn || control.DataSource == bsStoreOut)
            {
                GetDocStoreId();
                return;
            }
            if (control.DataSource == bsItems)
            {
                GetRowItemID();
                return;
            }
        }
        
        private void dgvDocs_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dgvDocs.NewRowIndex) return;
            var dr_doc = (bsDocs[e.RowIndex] as DataRowView).Row as KlonsMDataSet.M_DOCSRow;
            if (dr_doc == null) return;
            if (!CanEditDoc(dr_doc))
                e.Cancel = true;
        }

        private void dgvRows_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var dr_row = (bsRows[e.RowIndex] as DataRowView).Row as KlonsMDataSet.M_ROWSRow;
            if (dr_row == null) return;
            var dr_doc = GetCurrentDocRow();
            if (!CanEditDoc(dr_doc))
                e.Cancel = true;
        }

        public void DoIegrāmatot()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return;
            if (!dr_doc.IsOpenForChanges)
            {
                MyMainForm.ShowWarning("Dokuments jau ir iegrāmatots.");
                return;
            }
            if (!SaveData())
            {
                MyMainForm.ShowError("Neizdevās saglabāt izmaiņas.");
                return;
            }
            var err = DataTasks.ProcessDoc(dr_doc);
            CheckSave();
            if (err.HasErrors)
            {
                FormM_ErrorList.ShowErrorList(this, err);
                return;
            }
        }

        public void DoAtvērt()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return;
            if (dr_doc.IsOpenForChanges)
            {
                MyMainForm.ShowWarning("Dokuments jau ir atvērts.");
                return;
            }
            if (!SaveData())
            {
                MyMainForm.ShowError("Neizdevās saglabāt izmaiņas.");
                return;
            }
            var err = DataTasks.OpenDoc(dr_doc);
            CheckSave();
            if (err.HasErrors)
            {
                FormM_ErrorList.ShowErrorList(this, err);
                return;
            }
        }

        public void DoIegrānatotVeicotPilnuAprēķinu()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return;
            if (!dr_doc.IsOpenForChanges)
            {
                MyMainForm.ShowWarning("Dokuments nav atvērts.");
                return;
            }
            if (!SaveData())
            {
                MyMainForm.ShowError("Neizdevās saglabāt izmaiņas.");
                return;
            }
            var err = DataTasks.RecalcDoc(dr_doc);
            CheckSave();
            if (err.HasErrors)
            {
                FormM_ErrorList.ShowErrorList(this, err);
                return;
            }
        }

        public void DoIzveidotKredītrēķinu()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return;
            if (!SaveData())
            {
                MyMainForm.ShowError("Neizdevās saglabāt izmaiņas.");
                return;
            }
            var err = DataTasks.MakeCreditDoc(dr_doc, out var new_dr_doc);
            CheckSave();
            if (err != "OK")
            {
                MyMainForm.ShowWarning(err);
                return;
            }
            SelectDoc(new_dr_doc.ID);
        }

        public void DoPrečuAtgriešanaCenasAprēķins()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return;
            if (!SaveData())
            {
                MyMainForm.ShowError("Neizdevās saglabāt izmaiņas.");
                return;
            }
            if (!dr_doc.IsOpenForChanges)
            {
                MyMainForm.ShowWarning("Dokuments nav atvērts rediģēšnai.");
                return;
            }
            ErrorList err;
            if (dr_doc.XDocType == EDocType.Atgriezts_piegādātājam)
            {
                err = DataTasks.CheckDocForAtgrieztsPiegadatajam(dr_doc, true);
            }
            else if (dr_doc.XDocType == EDocType.Atgriezts_no_pircēja)
            {
                err = DataTasks.CheckDocForAtgrieztsNoPircēja(dr_doc, true);
            }
            else
            {
                MyMainForm.ShowWarning("Dokumenta vaidam jābūt Atgriezts piegādātājam vai Atgriezts no pircēja.");
                return;
            }
            CheckSave();
            if (err.HasErrors)
                FormM_ErrorList.ShowErrorList(this, err);
        }

        public void DoPrečuAtgriešanaIzveidotKredītrēķinus()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return;
            if (!SaveData())
            {
                MyMainForm.ShowError("Neizdevās saglabāt izmaiņas.");
                return;
            }
            if (!dr_doc.IsOpenForChanges)
            {
                MyMainForm.ShowWarning("Dokuments nav atvērts rediģēšnai.");
                return;
            }
            ErrorList err;
            if (dr_doc.XDocType == EDocType.Atgriezts_piegādātājam)
            {
                err = DataTasks.CheckDocForAtgrieztsPiegadatajam(dr_doc, true);
                if (!err.HasErrors)
                    err = DataTasks.MakeCreditDocsFromAtgrieztsPiegadatajam(dr_doc);
            }
            else if (dr_doc.XDocType == EDocType.Atgriezts_no_pircēja)
            {
                err = DataTasks.CheckDocForAtgrieztsNoPircēja(dr_doc, true);
                if (!err.HasErrors)
                    err = DataTasks.MakeCreditDocsFromAtgrieztsNoPirceja(dr_doc);
            }
            else
            {
                MyMainForm.ShowWarning("Dokumenta vaidam jābūt Atgriezts piegādātājam vai Atgriezts no pircēja.");
                return;
            }
            CheckSave();
            if (err.HasErrors)
                FormM_ErrorList.ShowErrorList(this, err);
        }

        private void tsbIegramatot_Click(object sender, EventArgs e)
        {
            DoIegrāmatot();
        }

        private void atvērtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoAtvērt();
        }

        private void iegrāmatotVeicotPilnuPārrēķinuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoIegrānatotVeicotPilnuAprēķinu();
        }

        private void izveidotKredītrēķinuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoIzveidotKredītrēķinu();
        }

        private void prečuAtgriešanaCenasAprēķinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoPrečuAtgriešanaCenasAprēķins();
        }

        private void prečuAtgriešanaIzveidotKredītrēķinusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoPrečuAtgriešanaIzveidotKredītrēķinus();
        }
    }

    public class MyConfigA : Component
    {
        public Color DocStatusColor1 { get; set; } = Color.LightYellow;
        public Color DocStatusColor2 { get; set; } = Color.LightBlue;
        public Color DocStatusColor3 { get; set; } = Color.LightGreen;
    }
}
