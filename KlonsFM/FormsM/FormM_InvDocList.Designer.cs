
namespace KlonsFM.FormsM
{
    partial class FormM_InvDocList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormM_InvDocList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsDocs = new KlonsLIB.Data.MyBindingSource(this.components);
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.bNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.dgvDocs = new KlonsLIB.Components.MyDataGridView();
            this.dgcDocsDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsIdStore = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.bsStore = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcDocsState = new KlonsLIB.Components.DataGridViewColorMarkColumn();
            this.dgcDocsPersons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOpenDoc = new System.Windows.Forms.ToolStripButton();
            this.bniAdd = new System.Windows.Forms.ToolStripButton();
            this.bniDelete = new System.Windows.Forms.ToolStripButton();
            this.bniSave = new System.Windows.Forms.ToolStripButton();
            this.tsbFindPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbFind = new System.Windows.Forms.ToolStripTextBox();
            this.tsbFindNext = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvFilter = new KlonsLIB.Components.MyDataGridView();
            this.bsDocFilter = new KlonsLIB.Data.MyBindingSourceToObj(this.components);
            this.docFilterData1 = new DataObjectsFM.DocFilterData();
            this.btFilter = new System.Windows.Forms.Button();
            this.myConfigA1 = new KlonsFM.FormsM.MyConfigA();
            this.bsItems = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcFilterDt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcFilterDt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcFilterState = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcFilterIdStore = new KlonsLIB.Components.MyDgvTextboxColumn2();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).BeginInit();
            this.bNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStore)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).BeginInit();
            this.SuspendLayout();
            // 
            // bsDocs
            // 
            this.bsDocs.DataMember = "M_INV_DOCS";
            this.bsDocs.MyDataSource = "KlonsMData";
            this.bsDocs.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsDocs_ListChanged);
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsMData";
            this.myAdapterManager1.TableNames = new string[] {
        "M_INV_DOCS",
        "M_INV_ROWS",
        null};
            // 
            // bNav
            // 
            this.bNav.AddNewItem = null;
            this.bNav.BindingSource = this.bsDocs;
            this.bNav.CountItem = this.bindingNavigatorCountItem;
            this.bNav.CountItemFormat = " no {0}";
            this.bNav.DataGrid = this.dgvDocs;
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
            this.tsbOpenDoc,
            this.bniAdd,
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
            this.bNav.SaveItem = null;
            this.bNav.Size = new System.Drawing.Size(1020, 39);
            this.bNav.TabIndex = 1;
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
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.AutoSave = false;
            this.dgvDocs.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDocsDT,
            this.dgcDocsNr,
            this.dgcDocsIdStore,
            this.dgcDocsState,
            this.dgcDocsPersons,
            this.dgcDocsID});
            this.dgvDocs.DataSource = this.bsDocs;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.Location = new System.Drawing.Point(0, 61);
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.ReadOnly = true;
            this.dgvDocs.RowHeadersWidth = 62;
            this.dgvDocs.RowTemplate.Height = 28;
            this.dgvDocs.ShowCellToolTips = false;
            this.dgvDocs.Size = new System.Drawing.Size(1020, 350);
            this.dgvDocs.TabIndex = 0;
            this.dgvDocs.MyCheckForChanges += new System.EventHandler(this.dgvDocs_MyCheckForChanges);
            this.dgvDocs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocs_CellDoubleClick);
            this.dgvDocs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocs_CellFormatting);
            this.dgvDocs.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDocs_UserDeletingRow);
            // 
            // dgcDocsDT
            // 
            this.dgcDocsDT.DataPropertyName = "DT";
            dataGridViewCellStyle4.Format = "dd.MM.yyyy";
            this.dgcDocsDT.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcDocsDT.HeaderText = "datums";
            this.dgcDocsDT.MinimumWidth = 8;
            this.dgcDocsDT.Name = "dgcDocsDT";
            this.dgcDocsDT.ReadOnly = true;
            this.dgcDocsDT.Width = 90;
            // 
            // dgcDocsNr
            // 
            this.dgcDocsNr.DataPropertyName = "NR";
            this.dgcDocsNr.HeaderText = "mumurs";
            this.dgcDocsNr.MinimumWidth = 8;
            this.dgcDocsNr.Name = "dgcDocsNr";
            this.dgcDocsNr.ReadOnly = true;
            this.dgcDocsNr.Width = 90;
            // 
            // dgcDocsIdStore
            // 
            this.dgcDocsIdStore.DataPropertyName = "IDSTORE";
            this.dgcDocsIdStore.DataSource = this.bsStore;
            this.dgcDocsIdStore.DisplayMember = "CODE";
            this.dgcDocsIdStore.HeaderText = "noliktava";
            this.dgcDocsIdStore.MinimumWidth = 8;
            this.dgcDocsIdStore.Name = "dgcDocsIdStore";
            this.dgcDocsIdStore.ReadOnly = true;
            this.dgcDocsIdStore.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcDocsIdStore.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcDocsIdStore.ValueMember = "ID";
            this.dgcDocsIdStore.Width = 180;
            // 
            // bsStore
            // 
            this.bsStore.DataMember = "M_STORES";
            this.bsStore.MyDataSource = "KlonsMData";
            this.bsStore.Sort = "CODE";
            // 
            // dgcDocsState
            // 
            this.dgcDocsState.DataPropertyName = "STATE";
            this.dgcDocsState.HeaderText = "statuss";
            this.dgcDocsState.MinimumWidth = 8;
            this.dgcDocsState.Name = "dgcDocsState";
            this.dgcDocsState.ReadOnly = true;
            this.dgcDocsState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcDocsState.Width = 160;
            // 
            // dgcDocsPersons
            // 
            this.dgcDocsPersons.DataPropertyName = "PERSONS";
            this.dgcDocsPersons.HeaderText = "darbinieki";
            this.dgcDocsPersons.MinimumWidth = 8;
            this.dgcDocsPersons.Name = "dgcDocsPersons";
            this.dgcDocsPersons.ReadOnly = true;
            this.dgcDocsPersons.Width = 300;
            // 
            // dgcDocsID
            // 
            this.dgcDocsID.DataPropertyName = "ID";
            this.dgcDocsID.HeaderText = "ID";
            this.dgcDocsID.MinimumWidth = 8;
            this.dgcDocsID.Name = "dgcDocsID";
            this.dgcDocsID.ReadOnly = true;
            this.dgcDocsID.Visible = false;
            this.dgcDocsID.Width = 150;
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
            // tsbOpenDoc
            // 
            this.tsbOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenDoc.Image")));
            this.tsbOpenDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenDoc.Name = "tsbOpenDoc";
            this.tsbOpenDoc.Size = new System.Drawing.Size(100, 34);
            this.tsbOpenDoc.Text = "Atvērt";
            this.tsbOpenDoc.Click += new System.EventHandler(this.tsbOpenDoc_Click);
            // 
            // bniAdd
            // 
            this.bniAdd.Image = ((System.Drawing.Image)(resources.GetObject("bniAdd.Image")));
            this.bniAdd.Name = "bniAdd";
            this.bniAdd.RightToLeftAutoMirrorImage = true;
            this.bniAdd.Size = new System.Drawing.Size(93, 34);
            this.bniAdd.Text = "Jauns";
            this.bniAdd.Click += new System.EventHandler(this.bniAdd_Click);
            // 
            // bniDelete
            // 
            this.bniDelete.Image = ((System.Drawing.Image)(resources.GetObject("bniDelete.Image")));
            this.bniDelete.Name = "bniDelete";
            this.bniDelete.RightToLeftAutoMirrorImage = true;
            this.bniDelete.Size = new System.Drawing.Size(94, 34);
            this.bniDelete.Text = "Dzēst";
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
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvFilter);
            this.panel1.Controls.Add(this.btFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 61);
            this.panel1.TabIndex = 4;
            // 
            // dgvFilter
            // 
            this.dgvFilter.AllowUserToAddRows = false;
            this.dgvFilter.AllowUserToDeleteRows = false;
            this.dgvFilter.AllowUserToResizeRows = false;
            this.dgvFilter.AutoGenerateColumns = false;
            this.dgvFilter.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcFilterDt1,
            this.dgcFilterDt2,
            this.dgcFilterState,
            this.dgcFilterIdStore});
            this.dgvFilter.DataSource = this.bsDocFilter;
            this.dgvFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFilter.Location = new System.Drawing.Point(0, 0);
            this.dgvFilter.Name = "dgvFilter";
            this.dgvFilter.RowHeadersVisible = false;
            this.dgvFilter.RowHeadersWidth = 62;
            this.dgvFilter.RowTemplate.Height = 28;
            this.dgvFilter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvFilter.ShowCellToolTips = false;
            this.dgvFilter.Size = new System.Drawing.Size(906, 61);
            this.dgvFilter.TabIndex = 0;
            this.dgvFilter.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFilter_CellFormatting);
            this.dgvFilter.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvFilter_CellParsing);
            // 
            // bsDocFilter
            // 
            this.bsDocFilter.MyDataSource = this.docFilterData1;
            this.bsDocFilter.Position = 0;
            // 
            // docFilterData1
            // 
            this.docFilterData1.DocState = null;
            this.docFilterData1.DocType = null;
            this.docFilterData1.Dt1 = null;
            this.docFilterData1.Dt2 = null;
            this.docFilterData1.IdStoreIn = null;
            this.docFilterData1.IdStoreOut = null;
            this.docFilterData1.IdStoreOutOrIn = null;
            // 
            // btFilter
            // 
            this.btFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.btFilter.Location = new System.Drawing.Point(906, 0);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(114, 61);
            this.btFilter.TabIndex = 1;
            this.btFilter.Text = "Atlasīt dokumentus";
            this.btFilter.UseVisualStyleBackColor = true;
            this.btFilter.Click += new System.EventHandler(this.btFilter_Click);
            // 
            // myConfigA1
            // 
            this.myConfigA1.DocStatusColor1 = System.Drawing.Color.LightYellow;
            this.myConfigA1.DocStatusColor2 = System.Drawing.Color.LightBlue;
            this.myConfigA1.DocStatusColor3 = System.Drawing.Color.LightGreen;
            // 
            // bsItems
            // 
            this.bsItems.DataMember = "M_ITEMS";
            this.bsItems.MyDataSource = "KlonsMData";
            this.bsItems.Sort = "BARCODE";
            // 
            // dgcFilterDt1
            // 
            this.dgcFilterDt1.DataPropertyName = "Dt1";
            dataGridViewCellStyle5.Format = "dd.MM.yyyy";
            this.dgcFilterDt1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcFilterDt1.HeaderText = "datums no";
            this.dgcFilterDt1.MinimumWidth = 8;
            this.dgcFilterDt1.Name = "dgcFilterDt1";
            this.dgcFilterDt1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcFilterDt1.Width = 95;
            // 
            // dgcFilterDt2
            // 
            this.dgcFilterDt2.DataPropertyName = "Dt2";
            dataGridViewCellStyle6.Format = "dd.MM.yyyy";
            this.dgcFilterDt2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcFilterDt2.HeaderText = "datums līdz";
            this.dgcFilterDt2.MinimumWidth = 8;
            this.dgcFilterDt2.Name = "dgcFilterDt2";
            this.dgcFilterDt2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcFilterDt2.Width = 95;
            // 
            // dgcFilterState
            // 
            this.dgcFilterState.DataPropertyName = "DocState";
            this.dgcFilterState.DisplayMember = null;
            this.dgcFilterState.HeaderText = "statuss";
            this.dgcFilterState.MaxDropDownItems = 15;
            this.dgcFilterState.MinimumWidth = 8;
            this.dgcFilterState.Name = "dgcFilterState";
            this.dgcFilterState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcFilterState.ValueMember = null;
            this.dgcFilterState.Width = 160;
            // 
            // dgcFilterIdStore
            // 
            this.dgcFilterIdStore.DataPropertyName = "IdStoreIn";
            this.dgcFilterIdStore.DataSource = this.bsStore;
            this.dgcFilterIdStore.DisplayMember = "CODE";
            this.dgcFilterIdStore.HeaderText = "noliktava";
            this.dgcFilterIdStore.MinimumWidth = 8;
            this.dgcFilterIdStore.Name = "dgcFilterIdStore";
            this.dgcFilterIdStore.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcFilterIdStore.ValueMember = "ID";
            this.dgcFilterIdStore.Width = 180;
            // 
            // FormM_InvDocList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 450);
            this.Controls.Add(this.dgvDocs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bNav);
            this.Name = "FormM_InvDocList";
            this.Text = "Invemtarizācijas dokumentu saraksts";
            this.Load += new System.EventHandler(this.FormM_InvDocList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).EndInit();
            this.bNav.ResumeLayout(false);
            this.bNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStore)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsDocs;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private KlonsLIB.Components.MyBindingNavigator bNav;
        private System.Windows.Forms.ToolStripButton bniAdd;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bniDelete;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bniSave;
        private KlonsLIB.Components.MyDataGridView dgvDocs;
        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Components.MyDataGridView dgvFilter;
        private System.Windows.Forms.Button btFilter;
        private DataObjectsFM.DocFilterData docFilterData1;
        private MyConfigA myConfigA1;
        private System.Windows.Forms.ToolStripButton tsbFindPrev;
        private System.Windows.Forms.ToolStripTextBox tsbFind;
        private System.Windows.Forms.ToolStripButton tsbFindNext;
        private KlonsLIB.Data.MyBindingSource bsStore;
        private KlonsLIB.Data.MyBindingSource bsItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsNr;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcDocsIdStore;
        private KlonsLIB.Components.DataGridViewColorMarkColumn dgcDocsState;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsPersons;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsID;
        private System.Windows.Forms.ToolStripButton tsbOpenDoc;
        private KlonsLIB.Data.MyBindingSourceToObj bsDocFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFilterDt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFilterDt2;
        private KlonsLIB.Components.MyDgvMcCBColumn dgcFilterState;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcFilterIdStore;
    }
}