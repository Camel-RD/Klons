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
    public partial class FormM_Doc : MyFormBaseF, 
        IMyDgvTextboxEditingControlEvents2, IMyDgvTextboxEditingControlEvents
    {
        public FormM_Doc()
        {
            InitializeComponent();
            CheckMyFontAndColors();

            DecimalsInPrices = MyData.Params.DECIMALSINPRICES;
            string price_format = "N" + DecimalsInPrices;
            dgcRowsPrice0.DefaultCellStyle.Format = price_format;
            dgcRowsPrice.DefaultCellStyle.Format = price_format;
            dgcRowsBuyPrice.DefaultCellStyle.Format = price_format;

            miSplitPVN.Visible = !AreWeVATPayer;

            MakeGrid();
        }

        private void MakeGrid()
        {
            sgrDocA.MakeGrid2();
            sgrDocA.LinkGrid();
            //grDocPVNType.DataCell.View.WordWrap = true;
        }

        public bool FindDoc(int iddoc)
        {
            if (bsDocs.Count == 0) return false;
            for(int i = 0; i < bsDocs.Count; i++)
            {
                var dr = (bsDocs[i] as DataRowView).Row as KlonsMDataSet.M_DOCSRow;
                if (dr.ID != iddoc) continue;
                bsDocs.Position = i;
                ActiveDocId = iddoc;
                return true;
            }
            return false;
        }

        public static bool ShowDocMyDialog(int iddoc)
        {
            var form = KlonsData.St.MyMainForm.ShowFormMDialog<FormM_Doc>((Action<int>)null);
            bool rt = form.FindDoc(iddoc);
            if (!rt)
            {
                form.Close();
                KlonsData.St.MyMainForm.ShowError("Neizdevās atvērt dokumentu.");
                return false;
            }
            return true;
        }

        public int? ActiveDocId = null;
        private int DecimalsInPrices = 2;

        private void FormM_Doc_Load(object sender, EventArgs e)
        {
            CheckSave();
            CheckEnableRows();
            CheckEnableDocsCheckBoxes();

            MyData.DataSetKlonsM.M_DOCS.ColumnChanged += M_DOCS_ColumnChanged;
            MyData.DataSetKlonsM.M_ROWS.ColumnChanged += M_ROWS_ColumnChanged;

            MyData.DataSetKlonsM.M_ROWS.M_ROWSRowDeleted += M_ROWS_M_ROWSRowDeleted;
            MyData.DataSetKlonsM.M_ROWS.M_ROWSRowDeleting += M_ROWS_M_ROWSRowDeleting;
            MyData.DataSetKlonsM.M_ROWS.M_ROWSRowChanged += M_ROWS_M_ROWSRowChanged;
            //MyData.DataSetKlonsM.M_DOCS.TableNewRow += M_DOCS_TableNewRow;

            grDocTP.ButtonClicked += GrDocTP_ButtonClicked;
            grDocTransType.ButtonClicked += GrDocTransType_ButtonClicked;
            grDocStoreOut.ButtonClicked += GrDocStore_ButtonClicked;
            grDocStoreIn.ButtonClicked += GrDocStore_ButtonClicked;
            grDocCarrier.ButtonClicked += GrDocStore_ButtonClicked;
            grDocAddressOut.ButtonClicked += GrDocAddressInOut_ButtonClicked;
            grDocAddressIn.ButtonClicked += GrDocAddressInOut_ButtonClicked;
            grDocDriver.ButtonClicked += GrDocDriver_ButtonClicked;
            grDocVehicle.ButtonClicked += GrDocVehicle_ButtonClicked;
        }


        private void FormM_Doc_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlonsM.M_DOCS.ColumnChanged -= M_DOCS_ColumnChanged;
            MyData.DataSetKlonsM.M_ROWS.ColumnChanged -= M_ROWS_ColumnChanged;

            MyData.DataSetKlonsM.M_ROWS.M_ROWSRowDeleted -= M_ROWS_M_ROWSRowDeleted;
            MyData.DataSetKlonsM.M_ROWS.M_ROWSRowDeleting -= M_ROWS_M_ROWSRowDeleting;
            MyData.DataSetKlonsM.M_ROWS.M_ROWSRowChanged -= M_ROWS_M_ROWSRowChanged;

            grDocTP.ButtonClicked -= GrDocTP_ButtonClicked;
            grDocTransType.ButtonClicked -= GrDocTransType_ButtonClicked;
            grDocStoreOut.ButtonClicked -= GrDocStore_ButtonClicked;
            grDocStoreIn.ButtonClicked -= GrDocStore_ButtonClicked;
            grDocCarrier.ButtonClicked -= GrDocStore_ButtonClicked;
            grDocAddressOut.ButtonClicked -= GrDocAddressInOut_ButtonClicked;
            grDocAddressIn.ButtonClicked -= GrDocAddressInOut_ButtonClicked;
            grDocDriver.ButtonClicked -= GrDocDriver_ButtonClicked;
            grDocVehicle.ButtonClicked -= GrDocVehicle_ButtonClicked;
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
            if (e.Action == DataRowAction.Commit) return;

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
            var dr = e.Row as KlonsMDataSet.M_DOCSRow;
            if (e.Column == table.TPColumn ||
                e.Column == table.IDSTOREINColumn ||
                e.Column == table.IDSTOREOUTColumn)
            {
                var doctype = dr.XDocType;
                var storeintype = dr.XStoreInType;
                var storeouttype = dr.XStoreOutType;
                var storeinpvntype = dr.XStoreInPVNType;
                var storeoutpvntype = dr.XStoreOutPVNType;
                var pvntype = SomeDataDefs.GetPVNType(doctype, storeintype, storeouttype,
                    storeinpvntype, storeoutpvntype);
                dr.XPVNType = pvntype;
                DataTasks.UpdateDocAcc(dr);
            }
            if (e.Column == table.IDSTOREINColumn)
            {
                dr.SetIDADDRESSINNull();
            }
            if (e.Column == table.IDSTOREOUTColumn)
            {
                dr.SetIDADDRESSOUTNull();
            }
            if (e.Column == table.IDCARRIERColumn)
            {
                dr.SetIDDRIVERNull();
                dr.SetIDVEHICLENull();
            }
            if (e.Column == table.TPColumn)
            {
                if(dr.XDocType != EDocType.Kredītrēķins_no_piegādātāja &&
                    dr.XDocType != EDocType.Kredītrēķins_pircējam &&
                    !dr.IsCREDDOCDTNull())
                {
                    dr.SetIDCREDDOCNull();
                    dr.SetCREDDOCDTNull();
                    dr.CREDDOCSR = null;
                    dr.CREDDOCNR = null;
                }
            }
        }

        private decimal RoundPrice(decimal price)
        {
            return Math.Round(price, DecimalsInPrices);
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
                if(dr.M_DOCSRow.XDocType == EDocType.Realizācija ||
                    dr.M_DOCSRow.XDocType == EDocType.Sniegti_pakalpojumi ||
                    dr.M_DOCSRow.XDocType == EDocType.Pārvietots)
                {
                    dr.PRICE0 = RoundPrice(dr_item.SELLPRICE);
                    dr.PRICE = RoundPrice(dr_item.SELLPRICE);
                    dr.DISCOUNT = 0f;
                }
                else if (dr.M_DOCSRow.XDocType == EDocType.Saražots)
                {
                    dr.PRICE0 = RoundPrice(dr_item.PRODCOST);
                    dr.PRICE = RoundPrice(dr_item.PRODCOST);
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
                dr.ACC6 = dr_item.M_ITEMS_CATRow.ACC6;
                dr.ACC7 = dr_item.M_ITEMS_CATRow.ACC7;
                dr.EndEdit();
                dgvRows.RefreshCurrent();
            }

            if (e.Column == table.IDITEMColumn ||
                e.Column == table.PRICE0Column ||
                e.Column == table.DISCOUNTColumn ||
                e.Column == table.AMOUNTColumn)
            {
                var dr = e.Row as KlonsMDataSet.M_ROWSRow;
                var price = RoundPrice(dr.PRICE0 + (decimal)dr.DISCOUNT / 100M * dr.PRICE0);
                var tprice = Math.Round(dr.AMOUNT * price, 2);
                if (dr.PRICE != price) dr.PRICE = price;
                if (dr.TPRICE != tprice) dr.TPRICE = tprice;
                if (SomeDataDefs.PriceIsBuyPrice(dr.M_DOCSRow.XDocType))
                {
                    if (dr.PRICE != dr.BUYPRICE) dr.BUYPRICE = dr.PRICE;
                    if (dr.TPRICE != dr.TBUYPRICE) dr.TBUYPRICE = dr.TPRICE;
                }
                UpdateDocSums(dr.M_DOCSRow);
                dgvRows.RefreshCurrent();
                //TODO -- dgvDocs.RefreshCurrent();
            }

        }

        private bool UpdateDocSums(KlonsMDataSet.M_DOCSRow dr_doc)
        {
            var drs_rows = dr_doc.GetM_ROWSRows().ToList();
            var err = DataTasks.CheckDocHeader(dr_doc);
            if (err.HasErrors)
            {
                if (dr_doc.SUMM != 0M) dr_doc.SUMM = 0M;
                FormM_ErrorList.ShowErrorList(this, err);
                return false;
            }
            if (drs_rows.Count == 0)
            {
                if (dr_doc.SUMM != 0M) dr_doc.SUMM = 0M;
                return true;
            }
            var docpvndata = PVNCalc.GetPVNData(dr_doc);
            if (docpvndata.Err.HasErrors)
            {
                if (dr_doc.SUMM != 0M) dr_doc.SUMM = 0M;
                FormM_ErrorList.ShowErrorList(this, docpvndata.Err);
                return false;
            }
            decimal summ = docpvndata.PVNBase + docpvndata.PVN;
            if (dr_doc.SUMM != summ)
                dr_doc.SUMM = summ;
            return true;
        }


        private void GetDocTpCellValue(KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grow)
        {
            var id = (int)grow.Value;
            int? new_id = FormM_DocTypes.GetDocTypeId(id);
            if (!new_id.HasValue) return;
            grow.Value = new_id.Value;
        }

        private void GetDocTransTypeCellValue(KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grow)
        {
            var id = (int)grow.Value;
            int? new_id = FormM_TransactionType.GetTransactionTypeId(id);
            if (!new_id.HasValue) return;
            grow.Value = new_id.Value;
        }

        private void GetDocStoreCellValue(KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grow)
        {
            var id = (int?)grow.Value;
            string code = null;
            if (id != null)
                code = DataTasks.GetStoreCode(id.Value);
            int? new_id = FormM_Stores.GetStoreId(code);
            if (!new_id.HasValue) return;
            grow.Value = new_id.Value;
        }

        private void GrDocTP_ButtonClicked(object sender, EventArgs e)
        {
            var grow = sender as KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox;
            GetDocTpCellValue(grow);
        }

        private void GrDocTransType_ButtonClicked(object sender, EventArgs e)
        {
            var grow = sender as KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox;
            GetDocTransTypeCellValue(grow);
        }

        private void GrDocStore_ButtonClicked(object sender, EventArgs e)
        {
            var grow = sender as KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox;
            GetDocStoreCellValue(grow);
        }

        private void GrDocAddressInOut_ButtonClicked(object sender, EventArgs e)
        {
            var grow = sender as KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox;
            if (grow != grDocAddressOut && grow != grDocAddressIn) return;
            var id_store = grow == grDocAddressOut ? docData1._IDSTOREOUT : docData1._IDSTOREIN;
            var mainstore = MyData.Params.MAINSTORE;
            var store_type = MyData.DataSetKlonsM.M_STORES.FindByID(id_store).XStoreType;
            if (!mainstore.IsNOE() && store_type == EStoreType.Noliktava)
            {
                var id2 = DataTasks.GetStoreIdByCode(mainstore);
                if (id2.HasValue) 
                    id_store = id2.Value;
            }
            int? new_id = FormM_Addresses.GetAddresstId(id_store);
            if (!new_id.HasValue) return;
            grow.Value = new_id.Value;
        }

        private void GrDocDriver_ButtonClicked(object sender, EventArgs e)
        {
            var grow = sender as KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox;
            if (grow != grDocDriver) return;
            var id_store = docData1._IDCARRIER;
            if (id_store == null) return;
            var mainstore = MyData.Params.MAINSTORE;
            var store_type = MyData.DataSetKlonsM.M_STORES.FindByID(id_store.Value).XStoreType;
            if (!mainstore.IsNOE() && store_type == EStoreType.Noliktava)
            {
                var id2 = DataTasks.GetStoreIdByCode(mainstore);
                if (id2.HasValue)
                    id_store = id2.Value;
            }
            int? new_id = FormM_Contacts.GetContactId(id_store.Value);
            if (new_id == null) return;
            grow.Value = new_id.Value;
        }

        private void GrDocVehicle_ButtonClicked(object sender, EventArgs e)
        {
            var grow = sender as KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox;
            if (grow != grDocVehicle) return;
            var id_store = docData1._IDCARRIER;
            if (id_store == null) return;
            var mainstore = MyData.Params.MAINSTORE;
            var store_type = MyData.DataSetKlonsM.M_STORES.FindByID(id_store.Value).XStoreType;
            if (!mainstore.IsNOE() && store_type == EStoreType.Noliktava)
            {
                var id2 = DataTasks.GetStoreIdByCode(mainstore);
                if (id2.HasValue)
                    id_store = id2.Value;
            }
            int? new_id = FormM_Vehicles.GetVehicleId(id_store.Value);
            if (new_id == null) return;
            grow.Value = new_id.Value;
        }


        private KlonsMDataSet.M_DOCSRow GetCurrentDocRow()
        {
            if (bsDocs.Count == 0 || bsDocs.Current == null) return null;
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
            sgrDocA.Visible = bsDocs.Count > 0 && bsDocs.Current != null;
            dgvRows.Enabled = bsDocs.Count > 0 && bsDocs.Current != null;
        }

        private void CheckEnableDocsCheckBoxes()
        {
            var b = CanEditCurrentDoc();
            grDocWeVATPayer.ReadOnly = !b;
        }

        public override bool SaveData()
        {
            if (!dgvRows.EndEditX()) return false;
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
            var dv = this.ActiveControl.Text;
            var rt = GetStoreId(dv);
            if (rt == null) return;
            SetCurrentDocEditorValue(rt.Value);
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

        private int SearchRowText(string text, int colindex,
            int startindex = 0, bool forward = true)
        {
            string propname = dgvRows.Columns[colindex].DataPropertyName;
            if (bsRows.Count == 0) return -1;
            if (startindex < 0 || startindex >= bsRows.Count) return -1;
            if (string.IsNullOrEmpty(text)) return -1;
            if (startindex == 0 && !forward) return -1;
            if (startindex == bsRows.Count - 1 && forward) return -1;
            var rv = bsRows[startindex] as DataRowView;
            if (rv == null) return -1;
            int colnr = rv.Row.Table.Columns.IndexOf(propname);
            if (colnr == -1) return -1;
            string columnname = rv.Row.Table.Columns[colnr].ColumnName;
            int di = forward ? 1 : -1;
            string val;
            text = text.ToLower();
            for (int i = startindex; i >= 0 && i < bsRows.Count; i += di)
            {
                var dr = (bsRows[i] as DataRowView).Row as KlonsMDataSet.M_ROWSRow;
                if (dr == null) continue;
                val = null;
                if (colindex == dgcRowsItemName.Index)
                    val = dr.M_ITEMSRow.NAME;
                else if (colindex == dgcRowsIdItem.Index)
                    val = dr.M_ITEMSRow.BARCODE;
                else if (colindex == dgcRowsIdPVNRate.Index)
                    val = dr.M_PVNRATESRow.CODE;
                if (val == null) continue;
                if (val.ToLower().Contains(text))
                {
                    return i;
                }
            }
            return -1;
        }

        private void SearchRowText(bool fromfirst = true, bool forward = true)
        {
            if (dgvRows.CurrentRow == null || dgvRows.CurrentRow.IsNewRow) return;
            if (!dgvRows.EndEditX()) return;

            int startindex = dgvRows.CurrentRow.Index;
            startindex = fromfirst ? 0 : (forward ? startindex + 1 : startindex - 1);
            string text = tsbFind.Text;
            if (text == "") return;
            int newindex = SearchRowText(text, dgvRows.CurrentCell.ColumnIndex, startindex, forward);
            if (newindex == -1)
            {
                MyMainForm.ShowInfo("Tekts [" + text + "] netika atrasts.");
                return;
            }
            dgvRows.CurrentCell = dgvRows[dgvRows.CurrentCell.ColumnIndex, newindex];
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

        private void dgvRows_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value) return;
            if (e.ColumnIndex == dgcRowsPrice0.Index)
            {
                decimal price;
                if (e.Value is string sval)
                {
                    if (!decimal.TryParse(sval, out price)) return;
                }
                else if (e.Value is decimal)
                {
                    price = (decimal)e.Value;
                }
                else
                    return;
                decimal rprice = RoundPrice(price);
                if (price == rprice) return;
                e.Value = rprice;
                e.ParsingApplied = true;
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
            dgvRows.MoveToNewRow();
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

        private void dgvRows_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }


        private void bsDocs_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            CheckEnableRows();
            CheckEnableDocsCheckBoxes();
            CheckSave();
        }

        private void bsDocs_CurrentChanged(object sender, EventArgs e)
        {
            CheckEnableRows();
            CheckEnableDocsCheckBoxes();
        }

        private void bsRows_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (e.ListChangedType == ListChangedType.Reset) return;
            CheckSave();
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
        
        private void dgvRows_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var dr_row = (bsRows[e.RowIndex] as DataRowView).Row as KlonsMDataSet.M_ROWSRow;
            if (dr_row == null) return;
            var dr_doc = GetCurrentDocRow();
            if (!CanEditDoc(dr_doc))
                e.Cancel = true;
        }

        private void sgrDocA_ConvertingValueToDisplayString(object sender, DevAge.ComponentModel.ConvertingObjectEventArgs e)
        {
            if (sender == grDocState)
            {
                var state = (EDocState)e.Value;
                var val = SomeDataDefs.GetDocStateText(state);
                e.Value = val;
                e.ConvertingStatus = DevAge.ComponentModel.ConvertingStatus.Completed;
            }
        }

        private void tsbFindPrev_Click(object sender, EventArgs e)
        {
            SearchRowText(false, false);
            dgvRows.Focus();
        }

        private void tsbFindNext_Click(object sender, EventArgs e)
        {
            SearchRowText(false, true);
            dgvRows.Focus();
        }

        private void tsbFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SearchRowText();
                dgvRows.Focus();
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                dgvRows.Focus();
                e.Handled = true;
                return;
            }
        }

        private void tsbFind_Enter(object sender, EventArgs e)
        {
            tsbFind.Text = "";
        }

        public bool DoIegrāmatot()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return false;
            if (!dr_doc.IsOpenForChanges)
            {
                MyMainForm.ShowWarning("Dokuments jau ir iegrāmatots.");
                return false;
            }
            if (!UpdateDocSums(dr_doc)) return false;
            if (!SaveData())
            {
                MyMainForm.ShowError("Neizdevās saglabāt izmaiņas.");
                return false;
            }
            var err = DataTasks.ProcessDoc(dr_doc);
            CheckSave();
            if (err.HasErrors)
            {
                FormM_ErrorList.ShowErrorList(this, err);
                return false;
            }
            return true;
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
            DataTasks.DetachFinDocByIdDocM(dr_doc.ID);
        }

        public bool DoIegrānatotVeicotPilnuAprēķinu()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return false;
            if (!dr_doc.IsOpenForChanges)
            {
                MyMainForm.ShowWarning("Dokuments nav atvērts.");
                return false;
            }
            if (!UpdateDocSums(dr_doc)) return false;
            if (!SaveData())
            {
                MyMainForm.ShowError("Neizdevās saglabāt izmaiņas.");
                return false;
            }
            var err = DataTasks.RecalcDoc(dr_doc, EDocState.Iegrāmatots);
            CheckSave();
            if (err.HasErrors)
            {
                FormM_ErrorList.ShowErrorList(this, err);
                return false;
            }
            return true;
        }

        public bool DoAtvērtVeicotPilnuAprēķinu()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return false;
            if (dr_doc.IsOpenForChanges)
            {
                MyMainForm.ShowWarning("Dokuments jau ir atvērts.");
                return false;
            }
            if (!UpdateDocSums(dr_doc)) return false;
            if (!SaveData())
            {
                MyMainForm.ShowError("Neizdevās saglabāt izmaiņas.");
                return false;
            }
            var err = DataTasks.RecalcDoc(dr_doc, EDocState.Atvērts);
            CheckSave();
            if (err.HasErrors)
            {
                FormM_ErrorList.ShowErrorList(this, err);
                return false;
            }
            return true;
        }

        public bool DoIzveidotKredītrēķinu()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return false;
            if (!UpdateDocSums(dr_doc)) return false;
            if (!SaveData())
            {
                MyMainForm.ShowError("Neizdevās saglabāt izmaiņas.");
                return false;
            }
            var err = DataTasks.MakeCreditDoc(dr_doc, out var new_dr_doc);
            CheckSave();
            if (err != "OK")
            {
                MyMainForm.ShowWarning(err);
                return false;
            }
            SelectDoc(new_dr_doc.ID);
            return true;
        }

        public bool DoPrečuAtgriešanaCenasAprēķins()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return false;
            if (!UpdateDocSums(dr_doc)) return false;
            if (!SaveData())
            {
                MyMainForm.ShowError("Neizdevās saglabāt izmaiņas.");
                return false;
            }
            if (!dr_doc.IsOpenForChanges)
            {
                MyMainForm.ShowWarning("Dokuments nav atvērts rediģēšnai.");
                return false;
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
                return false;
            }
            CheckSave();
            if (err.HasErrors)
            {
                FormM_ErrorList.ShowErrorList(this, err);
                return false;
            }
            return true;
        }

        public bool DoPrečuAtgriešanaIzveidotKredītrēķinus()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return false;
            if (!UpdateDocSums(dr_doc)) return false;
            if (!SaveData())
            {
                MyMainForm.ShowError("Neizdevās saglabāt izmaiņas.");
                return false;
            }
            if (!dr_doc.IsOpenForChanges)
            {
                MyMainForm.ShowWarning("Dokuments nav atvērts rediģēšnai.");
                return false;
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
                return false;
            }
            CheckSave();
            if (err.HasErrors)
            {
                FormM_ErrorList.ShowErrorList(this, err);
                return false;
            }
            return true;
        }

        public bool CanDoAccounting()
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return false;
            if (dr_doc.XState != EDocState.Iegrāmatots &&
                dr_doc.XState != EDocState.Iekontēts)
            {
                MyMainForm.ShowWarning("Dokuments nav iegrāmatots.");
                return false;
            }
            return true;
        }

        public void DoAccounting(bool after_iegramatots)
        {
            var dr_doc = GetGoodCurrentDocRow();
            if (dr_doc == null) return;
            if (!SomeDataDefs.AutoMakeFinOps(dr_doc.XDocType))
            {
                if (after_iegramatots)
                {
                    dr_doc.BeginEdit();
                    dr_doc.XState = EDocState.Iegrāmatots;
                    dr_doc.XDoAutoFinOps = false;
                    dr_doc.EndEdit();
                    SaveData();
                }
                else
                {
                    MyMainForm.ShowWarning("Šis dokuments veids netiek kontēts.\n" +
                        "Kontēts tiek mēneša kopsavilkums.");
                }
                return;
            }
            FormM_DocFin.ShowDialog(dr_doc.ID);
            CheckSave();
        }

        public void DoCopyDoc()
        {
            var dr = GetCurrentDocRow();
            if (dr == null) return;
            if (!SaveData()) return;
            if (!MyMainForm.AskSomething("Vai kopēt dokumentu?", this)) return;
            DataTasks.CopyDoc(dr, out var dr_new);
            FindDoc(dr_new.ID);
        }

        public void DoDeleteDoc()
        {
            var dr = GetCurrentDocRow();
            if (dr == null) return;
            if (!dr.IsOpenForChanges)
            {
                MyMainForm.ShowWarning("Dokuments nav atvērts rediģēšanai.");
                return;
            }
            if (!AskCanDelete()) return;
            bsDocs.RemoveCurrent();
            if (!SaveData()) return;
            Close();
        }

        public void DoPrint()
        {
            var dr_doc = GetCurrentDocRow();
            if (dr_doc == null) return;
            MyMainForm.ShowFormDialog(typeof(FormM_Invoice), dr_doc.ID, 0);
        }

        public void DoCostRep()
        {
            var dr_doc = GetCurrentDocRow();
            if (dr_doc == null) return;
            FormM_DocCosts.ShowRep(dr_doc);
        }

        public bool AreWeVATPayer => !MyData.Params.CompRegNrPVN.IsNOE();

        public void DoSplitPVN()
        {
            var dr_doc = GetCurrentDocRow();
            if (dr_doc == null) return;
            if (!dr_doc.IsOpenForChanges)
            {
                MyMainForm.ShowWarning("Dokuments nav atvērts rediģēšnai.");
                return;
            }
            if (dr_doc.XWeVATPayer)
            {
                MyMainForm.ShowWarning("Dokumenta ir atzīme, ka esam PVN maksātājs.\n" +
                    "Cenas pārrēķins pieskaitot PVN nav jāveic.");
                return;
            }
            if(dr_doc.XDocType != EDocType.Iepirkums)
            {
                MyMainForm.ShowWarning("Cenas pārrēķins pieskaitot PVN būtu jāveic tikai iepirkuma reķīniem.");
                return;
            }
            FormM_DocSplitPVN.ShowRep(dr_doc);
        }

        private void sgrDocA_EditStarting(object sender, CancelEventArgs e)
        {
            if (!CanEditCurrentDoc())
            {
                e.Cancel = true;
            }
        }

        private void kopētDokumentuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoCopyDoc();
        }
        private void dzēstDokumentuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoDeleteDoc();
        }
        private void iegrāmatotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool rt = DoIegrāmatot();
            if (!rt) return;
            DoAccounting(true);
        }
        private void atvērtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoAtvērt();
        }
        private void atvērtRediģēšanaiVeicotPilnuPārrēķinuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoAtvērtVeicotPilnuAprēķinu();
        }
        private void iegrāmatotVeicotPilnuPārrēķinuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool rt = DoIegrānatotVeicotPilnuAprēķinu();
            if (!rt) return;
            DoAccounting(true);
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
        private void kontējumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoAccounting(false);
        }
        private void miIzmaksuKopsavilkums_Click(object sender, EventArgs e)
        {
            DoCostRep();
        }
        private void pavadzīmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoPrint();
        }
        private void miSplitPVN_Click(object sender, EventArgs e)
        {
            DoSplitPVN();
        }

    }
}
