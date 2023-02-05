
namespace KlonsFM.FormsM
{
    partial class FormM_InvDoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormM_InvDoc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsDocs = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsItems = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsRows = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.bsUnits = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bniNew = new System.Windows.Forms.ToolStripButton();
            this.bniDelete = new System.Windows.Forms.ToolStripButton();
            this.bniSave = new System.Windows.Forms.ToolStripButton();
            this.tsbFindPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbFind = new System.Windows.Forms.ToolStripTextBox();
            this.tsbFindNext = new System.Windows.Forms.ToolStripButton();
            this.bsStore = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dokumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCompareWithDB = new System.Windows.Forms.ToolStripMenuItem();
            this.miCloseDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.miMakeStoreDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.sgrDoc = new KlonsLIB.MySourceGrid.MyGrid();
            this.inventoryDocData1 = new DataObjectsFM.InventoryDocData();
            this.grDocTitle1 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grDocDt = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDocNr = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDocStore = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.grDocState = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDocCM1 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowCommand();
            this.grDocTitle2 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grDocPersons = new KlonsLIB.MySourceGrid.GridRows.MyGridRowMultiLineTextBox();
            this.grDocCM2 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowCommand();
            this.grTitle3 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grDocNrNor = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDocNrPier = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDocIdStoreNor = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.grDocIdStorePier = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.miFilterRows = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dgcRowsIdItem = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.dgcRowsAmCounted1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsIdUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsAmCalc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsAmCounted2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsAmDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsIdDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).BeginInit();
            this.bNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsDocs
            // 
            this.bsDocs.DataMember = "M_INV_DOCS";
            this.bsDocs.MyDataSource = "KlonsMData";
            this.bsDocs.Sort = "";
            this.bsDocs.CurrentChanged += new System.EventHandler(this.bsDocs_CurrentChanged);
            this.bsDocs.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsDocs_ListChanged);
            // 
            // bsItems
            // 
            this.bsItems.DataMember = "M_ITEMS";
            this.bsItems.MyDataSource = "KlonsMData";
            this.bsItems.Sort = "BARCODE";
            // 
            // bsRows
            // 
            this.bsRows.DataMember = "FK_M_INV_ROWS_IDDOC";
            this.bsRows.DataSource = this.bsDocs;
            this.bsRows.Sort = "ID";
            this.bsRows.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsRows_ListChanged);
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsMData";
            this.myAdapterManager1.TableNames = new string[] {
        "M_INV_DOCS",
        "M_INV_ROWS",
        "M_ITEMS",
        "M_DOCS",
        "M_ROWS",
        null};
            // 
            // bsUnits
            // 
            this.bsUnits.DataMember = "M_UNITS";
            this.bsUnits.MyDataSource = "KlonsMData";
            this.bsUnits.Sort = "CODE";
            // 
            // bNav
            // 
            this.bNav.AddNewItem = null;
            this.bNav.BindingSource = this.bsRows;
            this.bNav.CountItem = this.bindingNavigatorCountItem;
            this.bNav.CountItemFormat = " no {0}";
            this.bNav.DeleteItem = null;
            this.bNav.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bNav.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bniNew,
            this.bniDelete,
            this.bniSave,
            this.tsbFindPrev,
            this.tsbFind,
            this.tsbFindNext});
            this.bNav.Location = new System.Drawing.Point(0, 411);
            this.bNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bNav.Name = "bNav";
            this.bNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bNav.SaveItem = this.bniSave;
            this.bNav.Size = new System.Drawing.Size(959, 39);
            this.bNav.TabIndex = 4;
            this.bNav.Text = "myBindingNavigator1";
            this.bNav.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bNav_ItemDeleting);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 34);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 34);
            this.bindingNavigatorMoveFirstItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 34);
            this.bindingNavigatorMovePreviousItem.Text = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 37);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Pašreizējā pozīcija";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 34);
            this.bindingNavigatorMoveNextItem.Text = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 34);
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // bniNew
            // 
            this.bniNew.Image = ((System.Drawing.Image)(resources.GetObject("bniNew.Image")));
            this.bniNew.Name = "bniNew";
            this.bniNew.RightToLeftAutoMirrorImage = true;
            this.bniNew.Size = new System.Drawing.Size(93, 34);
            this.bniNew.Text = "Jauns";
            this.bniNew.Click += new System.EventHandler(this.bniNew_Click);
            // 
            // bniDelete
            // 
            this.bniDelete.Image = ((System.Drawing.Image)(resources.GetObject("bniDelete.Image")));
            this.bniDelete.Name = "bniDelete";
            this.bniDelete.RightToLeftAutoMirrorImage = true;
            this.bniDelete.Size = new System.Drawing.Size(94, 34);
            this.bniDelete.Text = "Dzēst";
            this.bniDelete.Click += new System.EventHandler(this.bniDelete_Click);
            // 
            // bniSave
            // 
            this.bniSave.Image = ((System.Drawing.Image)(resources.GetObject("bniSave.Image")));
            this.bniSave.Name = "bniSave";
            this.bniSave.Size = new System.Drawing.Size(124, 34);
            this.bniSave.Text = "Saglabāt";
            this.bniSave.Click += new System.EventHandler(this.bniSave_Click);
            // 
            // tsbFindPrev
            // 
            this.tsbFindPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFindPrev.Image = ((System.Drawing.Image)(resources.GetObject("tsbFindPrev.Image")));
            this.tsbFindPrev.Name = "tsbFindPrev";
            this.tsbFindPrev.RightToLeftAutoMirrorImage = true;
            this.tsbFindPrev.Size = new System.Drawing.Size(34, 34);
            this.tsbFindPrev.Text = "Iet uz iepriekšējo";
            this.tsbFindPrev.Click += new System.EventHandler(this.tsbFindPrev_Click);
            // 
            // tsbFind
            // 
            this.tsbFind.Name = "tsbFind";
            this.tsbFind.Size = new System.Drawing.Size(100, 39);
            this.tsbFind.ToolTipText = "meklēt tekstu kolonnā";
            this.tsbFind.Enter += new System.EventHandler(this.tsbFind_Enter);
            this.tsbFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tsbFind_KeyPress);
            // 
            // tsbFindNext
            // 
            this.tsbFindNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFindNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbFindNext.Image")));
            this.tsbFindNext.Name = "tsbFindNext";
            this.tsbFindNext.RightToLeftAutoMirrorImage = true;
            this.tsbFindNext.Size = new System.Drawing.Size(34, 34);
            this.tsbFindNext.Text = "Iet uz nākošo";
            this.tsbFindNext.Click += new System.EventHandler(this.tsbFindNext_Click);
            // 
            // bsStore
            // 
            this.bsStore.DataMember = "M_STORES";
            this.bsStore.MyDataSource = "KlonsMData";
            this.bsStore.Sort = "CODE";
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.AutoSave = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcRowsIdItem,
            this.dgcRowsAmCounted1,
            this.dgcRowsItemName,
            this.dgcRowsIdUnits,
            this.dgcRowsAmCalc,
            this.dgcRowsAmCounted2,
            this.dgcRowsAmDiff,
            this.dgcRowsId,
            this.dgcRowsIdDoc});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 145);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.RowHeadersWidth = 62;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(959, 266);
            this.dgvRows.TabIndex = 6;
            this.dgvRows.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRows_MyKeyDown);
            this.dgvRows.MyCheckForChanges += new System.EventHandler(this.dgvRows_MyCheckForChanges);
            this.dgvRows.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvRows_CellBeginEdit);
            this.dgvRows.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRows_CellDoubleClick);
            this.dgvRows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRows_CellFormatting);
            this.dgvRows.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvRows_DefaultValuesNeeded);
            this.dgvRows.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvRows_UserDeletingRow);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dokumentsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(41, 18);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(202, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // dokumentsToolStripMenuItem
            // 
            this.dokumentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCompareWithDB,
            this.miCloseDoc,
            this.miMakeStoreDoc,
            this.toolStripSeparator1,
            this.miFilterRows});
            this.dokumentsToolStripMenuItem.Name = "dokumentsToolStripMenuItem";
            this.dokumentsToolStripMenuItem.Size = new System.Drawing.Size(139, 34);
            this.dokumentsToolStripMenuItem.Text = "Dokuments";
            this.dokumentsToolStripMenuItem.Visible = false;
            // 
            // miCompareWithDB
            // 
            this.miCompareWithDB.Name = "miCompareWithDB";
            this.miCompareWithDB.Size = new System.Drawing.Size(607, 38);
            this.miCompareWithDB.Text = "Veikt salīdzināšanu ar uzskaites datiem";
            this.miCompareWithDB.Click += new System.EventHandler(this.miCompareWithDB_Click);
            // 
            // miCloseDoc
            // 
            this.miCloseDoc.Name = "miCloseDoc";
            this.miCloseDoc.Size = new System.Drawing.Size(607, 38);
            this.miCloseDoc.Text = "Apstiprināt (slēgt) aizpildīto dokumentu";
            this.miCloseDoc.Click += new System.EventHandler(this.miCloseDoc_Click);
            // 
            // miMakeStoreDoc
            // 
            this.miMakeStoreDoc.Name = "miMakeStoreDoc";
            this.miMakeStoreDoc.Size = new System.Drawing.Size(607, 38);
            this.miMakeStoreDoc.Text = "Izveidot norakstīšanas / pierakstīšanas dokumentus";
            this.miMakeStoreDoc.Click += new System.EventHandler(this.miMakeStoreDoc_Click);
            // 
            // sgrDoc
            // 
            this.sgrDoc.BackColor2 = System.Drawing.SystemColors.Window;
            this.sgrDoc.ColumnWidth1 = 20;
            this.sgrDoc.ColumnWidth2 = 90;
            this.sgrDoc.ColumnWidth3 = 180;
            this.sgrDoc.DefaultHeight = 25;
            this.sgrDoc.DefaultWidth = 20;
            this.sgrDoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.sgrDoc.EnableSort = true;
            this.sgrDoc.Location = new System.Drawing.Point(0, 0);
            this.sgrDoc.MyDataBC = this.inventoryDocData1;
            this.sgrDoc.Name = "sgrDoc";
            this.sgrDoc.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.sgrDoc.RowHeadersUsed = false;
            this.sgrDoc.RowList.Add(this.grDocTitle1);
            this.sgrDoc.RowList.Add(this.grDocDt);
            this.sgrDoc.RowList.Add(this.grDocNr);
            this.sgrDoc.RowList.Add(this.grDocStore);
            this.sgrDoc.RowList.Add(this.grDocState);
            this.sgrDoc.RowList.Add(this.grDocCM1);
            this.sgrDoc.RowList.Add(this.grDocTitle2);
            this.sgrDoc.RowList.Add(this.grDocPersons);
            this.sgrDoc.RowList.Add(this.grDocCM2);
            this.sgrDoc.RowList.Add(this.grTitle3);
            this.sgrDoc.RowList.Add(this.grDocNrNor);
            this.sgrDoc.RowList.Add(this.grDocNrPier);
            this.sgrDoc.RowList.Add(this.grDocIdStoreNor);
            this.sgrDoc.RowList.Add(this.grDocIdStorePier);
            this.sgrDoc.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.sgrDoc.Size = new System.Drawing.Size(959, 145);
            this.sgrDoc.TabIndex = 5;
            this.sgrDoc.TabStop = true;
            this.sgrDoc.ToolTipText = "";
            this.sgrDoc.EditStarting += new System.ComponentModel.CancelEventHandler(this.sgrDoc_EditStarting);
            this.sgrDoc.ConvertingValueToDisplayString += new DevAge.ComponentModel.ConvertingObjectEventHandler(this.sgrDoc_ConvertingValueToDisplayString);
            // 
            // inventoryDocData1
            // 
            this.inventoryDocData1._DT = new System.DateTime(((long)(0)));
            this.inventoryDocData1._ID = 0;
            this.inventoryDocData1._IDSTORE = 0;
            this.inventoryDocData1._IDSTORE_NOR = 1;
            this.inventoryDocData1._IDSTORE_PIER = 1;
            this.inventoryDocData1._NR = null;
            this.inventoryDocData1._NR_NOR = null;
            this.inventoryDocData1._NR_PIER = null;
            this.inventoryDocData1._PERSONS = null;
            this.inventoryDocData1._STATE = 0;
            // 
            // grDocTitle1
            // 
            this.grDocTitle1.Name = "grDocTitle1";
            this.grDocTitle1.RowTitle = "Dokumenta dati";
            this.grDocTitle1.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // grDocDt
            // 
            this.grDocDt.DataMember = "DT";
            this.grDocDt.DataSource = this.bsDocs;
            this.grDocDt.GridPropertyName = "_DT";
            this.grDocDt.Name = "grDocDt";
            this.grDocDt.RowTitle = "Datums";
            this.grDocDt.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Date;
            // 
            // grDocNr
            // 
            this.grDocNr.DataMember = "NR";
            this.grDocNr.DataSource = this.bsDocs;
            this.grDocNr.GridPropertyName = "_NR";
            this.grDocNr.Name = "grDocNr";
            this.grDocNr.RowTitle = "Nr.";
            this.grDocNr.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grDocStore
            // 
            this.grDocStore.DataMember = "IDSTORE";
            this.grDocStore.DataSource = this.bsDocs;
            this.grDocStore.GridPropertyName = "_IDSTORE";
            this.grDocStore.ListDisplayMember = "CODE";
            this.grDocStore.ListSource = this.bsStore;
            this.grDocStore.ListValueMember = "ID";
            this.grDocStore.Name = "grDocStore";
            this.grDocStore.RowTitle = "Noliktava";
            this.grDocStore.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grDocState
            // 
            this.grDocState.CustomConversions = true;
            this.grDocState.DataMember = "STATE";
            this.grDocState.DataSource = this.bsDocs;
            this.grDocState.GridPropertyName = "_STATE";
            this.grDocState.Name = "grDocState";
            this.grDocState.ReadOnly = true;
            this.grDocState.RowTitle = "Status";
            this.grDocState.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            this.grDocState.TextAllign = KlonsLIB.MySourceGrid.GridRows.ECellTextAllign.Left;
            // 
            // grDocCM1
            // 
            this.grDocCM1.Command = KlonsLIB.MySourceGrid.GridRows.EMyGridRowCommands.StartNewColumn;
            this.grDocCM1.Name = "grDocCM1";
            this.grDocCM1.RowTitle = null;
            // 
            // grDocTitle2
            // 
            this.grDocTitle2.Name = "grDocTitle2";
            this.grDocTitle2.RowTitle = "Inventarizāciju veica";
            this.grDocTitle2.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // grDocPersons
            // 
            this.grDocPersons.AllowNull = true;
            this.grDocPersons.DataMember = "PERSONS";
            this.grDocPersons.DataSource = this.bsDocs;
            this.grDocPersons.GridPropertyName = "_PERSONS";
            this.grDocPersons.Name = "grDocPersons";
            this.grDocPersons.RowSpan = 4;
            this.grDocPersons.RowTitle = null;
            // 
            // grDocCM2
            // 
            this.grDocCM2.CaptionColumnWidth = 180;
            this.grDocCM2.Command = KlonsLIB.MySourceGrid.GridRows.EMyGridRowCommands.StartNewColumn;
            this.grDocCM2.Name = "grDocCM2";
            this.grDocCM2.RowTitle = null;
            this.grDocCM2.SetColumnWidth = true;
            // 
            // grTitle3
            // 
            this.grTitle3.Name = "grTitle3";
            this.grTitle3.RowTitle = "Norakstīšanas / pierakstīšanas dokumenti";
            this.grTitle3.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // grDocNrNor
            // 
            this.grDocNrNor.GridPropertyName = "_NR_NOR";
            this.grDocNrNor.Name = "grDocNrNor";
            this.grDocNrNor.RowTitle = "Norakstīšanas dok. nr.";
            this.grDocNrNor.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grDocNrPier
            // 
            this.grDocNrPier.GridPropertyName = "_NR_PIER";
            this.grDocNrPier.Name = "grDocNrPier";
            this.grDocNrPier.RowTitle = "Pierakstīšanas dok.nr.";
            this.grDocNrPier.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grDocIdStoreNor
            // 
            this.grDocIdStoreNor.GridPropertyName = "_IDSTORE_NOR";
            this.grDocIdStoreNor.ListDisplayMember = "CODE";
            this.grDocIdStoreNor.ListSource = this.bsStore;
            this.grDocIdStoreNor.ListValueMember = "ID";
            this.grDocIdStoreNor.Name = "grDocIdStoreNor";
            this.grDocIdStoreNor.RowTitle = "Norakstīt uz ...";
            this.grDocIdStoreNor.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grDocIdStorePier
            // 
            this.grDocIdStorePier.GridPropertyName = "_IDSTORE_PIER";
            this.grDocIdStorePier.ListDisplayMember = "CODE";
            this.grDocIdStorePier.ListSource = this.bsStore;
            this.grDocIdStorePier.ListValueMember = "ID";
            this.grDocIdStorePier.Name = "grDocIdStorePier";
            this.grDocIdStorePier.RowTitle = "Pierkastīt no ...";
            this.grDocIdStorePier.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // miFilterRows
            // 
            this.miFilterRows.Name = "miFilterRows";
            this.miFilterRows.Size = new System.Drawing.Size(607, 38);
            this.miFilterRows.Text = "Rādīt tikai rindas, kurās dati nesakrīt";
            this.miFilterRows.Click += new System.EventHandler(this.miFilterRows_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(604, 6);
            // 
            // dgcRowsIdItem
            // 
            this.dgcRowsIdItem.DataPropertyName = "IDITEM";
            this.dgcRowsIdItem.DataSource = this.bsItems;
            this.dgcRowsIdItem.DisplayMember = "BARCODE";
            this.dgcRowsIdItem.HeaderText = "artikuls";
            this.dgcRowsIdItem.MinimumWidth = 8;
            this.dgcRowsIdItem.Name = "dgcRowsIdItem";
            this.dgcRowsIdItem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcRowsIdItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcRowsIdItem.ValueMember = "ID";
            this.dgcRowsIdItem.Width = 160;
            // 
            // dgcRowsAmCounted1
            // 
            this.dgcRowsAmCounted1.DataPropertyName = "AM_COUNTED_1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcRowsAmCounted1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcRowsAmCounted1.HeaderText = "skaits";
            this.dgcRowsAmCounted1.MinimumWidth = 8;
            this.dgcRowsAmCounted1.Name = "dgcRowsAmCounted1";
            this.dgcRowsAmCounted1.Width = 65;
            // 
            // dgcRowsItemName
            // 
            this.dgcRowsItemName.DataPropertyName = "IDITEM";
            this.dgcRowsItemName.HeaderText = "nosaukums";
            this.dgcRowsItemName.MinimumWidth = 8;
            this.dgcRowsItemName.Name = "dgcRowsItemName";
            this.dgcRowsItemName.ReadOnly = true;
            this.dgcRowsItemName.Width = 200;
            // 
            // dgcRowsIdUnits
            // 
            this.dgcRowsIdUnits.DataPropertyName = "IDUNITS";
            this.dgcRowsIdUnits.HeaderText = "mērv.";
            this.dgcRowsIdUnits.MinimumWidth = 8;
            this.dgcRowsIdUnits.Name = "dgcRowsIdUnits";
            this.dgcRowsIdUnits.ReadOnly = true;
            this.dgcRowsIdUnits.Width = 60;
            // 
            // dgcRowsAmCalc
            // 
            this.dgcRowsAmCalc.DataPropertyName = "AM_CALC";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcRowsAmCalc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcRowsAmCalc.HeaderText = "uzskaitē";
            this.dgcRowsAmCalc.MinimumWidth = 8;
            this.dgcRowsAmCalc.Name = "dgcRowsAmCalc";
            this.dgcRowsAmCalc.ReadOnly = true;
            this.dgcRowsAmCalc.Width = 70;
            // 
            // dgcRowsAmCounted2
            // 
            this.dgcRowsAmCounted2.DataPropertyName = "AM_COUNTED_2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcRowsAmCounted2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcRowsAmCounted2.HeaderText = "skaits labots";
            this.dgcRowsAmCounted2.MinimumWidth = 8;
            this.dgcRowsAmCounted2.Name = "dgcRowsAmCounted2";
            this.dgcRowsAmCounted2.Width = 60;
            // 
            // dgcRowsAmDiff
            // 
            this.dgcRowsAmDiff.DataPropertyName = "AM_DIFF";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcRowsAmDiff.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcRowsAmDiff.HeaderText = "starpība";
            this.dgcRowsAmDiff.MinimumWidth = 8;
            this.dgcRowsAmDiff.Name = "dgcRowsAmDiff";
            this.dgcRowsAmDiff.ReadOnly = true;
            this.dgcRowsAmDiff.Width = 70;
            // 
            // dgcRowsId
            // 
            this.dgcRowsId.DataPropertyName = "ID";
            this.dgcRowsId.HeaderText = "ID";
            this.dgcRowsId.MinimumWidth = 8;
            this.dgcRowsId.Name = "dgcRowsId";
            this.dgcRowsId.ReadOnly = true;
            this.dgcRowsId.Visible = false;
            this.dgcRowsId.Width = 60;
            // 
            // dgcRowsIdDoc
            // 
            this.dgcRowsIdDoc.DataPropertyName = "IDDOC";
            this.dgcRowsIdDoc.HeaderText = "IDDOC";
            this.dgcRowsIdDoc.MinimumWidth = 8;
            this.dgcRowsIdDoc.Name = "dgcRowsIdDoc";
            this.dgcRowsIdDoc.ReadOnly = true;
            this.dgcRowsIdDoc.Visible = false;
            this.dgcRowsIdDoc.Width = 60;
            // 
            // FormM_InvDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.sgrDoc);
            this.Controls.Add(this.bNav);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormM_InvDoc";
            this.Text = "Inventarizācijas dokuments";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormM_InvDoc_FormClosed);
            this.Load += new System.EventHandler(this.FormM_InvDoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).EndInit();
            this.bNav.ResumeLayout(false);
            this.bNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsDocs;
        private KlonsLIB.Data.MyBindingSource bsItems;
        private KlonsLIB.Data.MyBindingSource2 bsRows;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private KlonsLIB.Data.MyBindingSource bsUnits;
        private KlonsLIB.Components.MyBindingNavigator bNav;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bniNew;
        private System.Windows.Forms.ToolStripButton bniDelete;
        private System.Windows.Forms.ToolStripButton bniSave;
        private System.Windows.Forms.ToolStripButton tsbFindPrev;
        private System.Windows.Forms.ToolStripTextBox tsbFind;
        private System.Windows.Forms.ToolStripButton tsbFindNext;
        private DataObjectsFM.InventoryDocData inventoryDocData1;
        private KlonsLIB.MySourceGrid.MyGrid sgrDoc;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grDocTitle1;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDocDt;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocStore;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDocState;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowCommand grDocCM1;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grDocTitle2;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowMultiLineTextBox grDocPersons;
        private KlonsLIB.Data.MyBindingSource bsStore;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDocNr;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dokumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miCompareWithDB;
        private System.Windows.Forms.ToolStripMenuItem miCloseDoc;
        private System.Windows.Forms.ToolStripMenuItem miMakeStoreDoc;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowCommand grDocCM2;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grTitle3;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDocNrNor;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDocNrPier;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocIdStoreNor;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocIdStorePier;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miFilterRows;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcRowsIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsAmCounted1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsIdUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsAmCalc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsAmCounted2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsAmDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsIdDoc;
    }
}