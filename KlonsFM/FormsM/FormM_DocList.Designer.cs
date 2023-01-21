
namespace KlonsFM.FormsM
{
    partial class FormM_DocList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormM_DocList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bsDocs = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvDocs = new KlonsLIB.Components.MyDataGridView();
            this.dgcDocsDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsSR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsTP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsDocType = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcDocsPVNType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsState = new KlonsLIB.Components.DataGridViewColorMarkColumn();
            this.dgcDocsIdStoreOut = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.bsStoreOut = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcDocsIdStoreIn = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.bsStoreIn = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcDocsSumm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsCredDocDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsCredDocSr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsCredDocNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsIdSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOpenDoc = new System.Windows.Forms.ToolStripButton();
            this.bniNew = new System.Windows.Forms.ToolStripButton();
            this.bniSave = new System.Windows.Forms.ToolStripButton();
            this.tsbFindPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbFind = new System.Windows.Forms.ToolStripTextBox();
            this.tsbFindNext = new System.Windows.Forms.ToolStripButton();
            this.bsPVNType = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsItems = new KlonsLIB.Data.MyBindingSource(this.components);
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.bsUnits = new KlonsLIB.Data.MyBindingSource(this.components);
            this.myConfigA1 = new KlonsFM.FormsM.MyConfigA();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvFilter = new KlonsLIB.Components.MyDataGridView();
            this.dgcFilterDt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcFilterDt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcFilterDocType = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcFilterDocState = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcFilterIdStoreOut = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.dgcFilterIdStoreIn = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.dgcFilterIdStoreOutOrIn = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.bsDocFilter = new KlonsLIB.Data.MyBindingSourceToObj(this.components);
            this.docFilterData1 = new DataObjectsFM.DocFilterData();
            this.btFilter = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dokumentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izveidotKredītrēķinuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izveidotKredītrēķinusPrečuAtgriešanaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).BeginInit();
            this.bNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStoreOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStoreIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPVNType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnits)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocFilter)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.bniNew,
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
            this.bNav.Size = new System.Drawing.Size(1269, 39);
            this.bNav.TabIndex = 2;
            this.bNav.Text = "myBindingNavigator1";
            this.bNav.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bNav_ItemDeleting);
            // 
            // bsDocs
            // 
            this.bsDocs.DataMember = "M_DOCS";
            this.bsDocs.MyDataSource = "KlonsMData";
            this.bsDocs.Sort = "DT,IDSEQ";
            this.bsDocs.UseDataGridView = this.dgvDocs;
            this.bsDocs.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsDocs_ListChanged);
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.AutoSave = false;
            this.dgvDocs.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDocsDT,
            this.dgcDocsSR,
            this.dgcDocsNr,
            this.dgcDocsTP,
            this.dgcDocsPVNType,
            this.dgcDocsState,
            this.dgcDocsIdStoreOut,
            this.dgcDocsIdStoreIn,
            this.dgcDocsSumm,
            this.dgcDocsCredDocDt,
            this.dgcDocsCredDocSr,
            this.dgcDocsCredDocNr,
            this.dgcDocsId,
            this.dgcDocsIdSeq});
            this.dgvDocs.DataSource = this.bsDocs;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.Location = new System.Drawing.Point(0, 61);
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.ReadOnly = true;
            this.dgvDocs.RowHeadersWidth = 30;
            this.dgvDocs.RowTemplate.Height = 28;
            this.dgvDocs.ShowCellToolTips = false;
            this.dgvDocs.Size = new System.Drawing.Size(1269, 350);
            this.dgvDocs.TabIndex = 4;
            this.dgvDocs.MyCheckForChanges += new System.EventHandler(this.dgvDocs_MyCheckForChanges);
            this.dgvDocs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocs_CellDoubleClick);
            this.dgvDocs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocs_CellFormatting);
            this.dgvDocs.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDocs_UserDeletingRow);
            // 
            // dgcDocsDT
            // 
            this.dgcDocsDT.DataPropertyName = "DT";
            dataGridViewCellStyle1.Format = "dd.MM.yyyy";
            this.dgcDocsDT.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcDocsDT.HeaderText = "datums";
            this.dgcDocsDT.MinimumWidth = 8;
            this.dgcDocsDT.Name = "dgcDocsDT";
            this.dgcDocsDT.ReadOnly = true;
            this.dgcDocsDT.Width = 90;
            // 
            // dgcDocsSR
            // 
            this.dgcDocsSR.DataPropertyName = "SR";
            this.dgcDocsSR.HeaderText = "sr.";
            this.dgcDocsSR.MinimumWidth = 8;
            this.dgcDocsSR.Name = "dgcDocsSR";
            this.dgcDocsSR.ReadOnly = true;
            this.dgcDocsSR.Width = 55;
            // 
            // dgcDocsNr
            // 
            this.dgcDocsNr.DataPropertyName = "NR";
            this.dgcDocsNr.HeaderText = "numurs";
            this.dgcDocsNr.MinimumWidth = 8;
            this.dgcDocsNr.Name = "dgcDocsNr";
            this.dgcDocsNr.ReadOnly = true;
            this.dgcDocsNr.Width = 90;
            // 
            // dgcDocsTP
            // 
            this.dgcDocsTP.DataPropertyName = "TP";
            this.dgcDocsTP.DataSource = this.bsDocType;
            this.dgcDocsTP.DisplayMember = "CODE";
            this.dgcDocsTP.DisplayStyleForCurrentCellOnly = true;
            this.dgcDocsTP.HeaderText = "veids";
            this.dgcDocsTP.MaxDropDownItems = 15;
            this.dgcDocsTP.MinimumWidth = 8;
            this.dgcDocsTP.Name = "dgcDocsTP";
            this.dgcDocsTP.ReadOnly = true;
            this.dgcDocsTP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcDocsTP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcDocsTP.ValueMember = "ID";
            this.dgcDocsTP.Width = 110;
            // 
            // bsDocType
            // 
            this.bsDocType.DataMember = "M_DOCTYPES";
            this.bsDocType.MyDataSource = "KlonsMData";
            this.bsDocType.Sort = "ID";
            // 
            // dgcDocsPVNType
            // 
            this.dgcDocsPVNType.DataPropertyName = "PVNTYPE";
            this.dgcDocsPVNType.HeaderText = "PVN id";
            this.dgcDocsPVNType.MinimumWidth = 8;
            this.dgcDocsPVNType.Name = "dgcDocsPVNType";
            this.dgcDocsPVNType.ReadOnly = true;
            this.dgcDocsPVNType.Width = 95;
            // 
            // dgcDocsState
            // 
            this.dgcDocsState.DataPropertyName = "STATE";
            this.dgcDocsState.HeaderText = "statuss";
            this.dgcDocsState.MinimumWidth = 8;
            this.dgcDocsState.Name = "dgcDocsState";
            this.dgcDocsState.ReadOnly = true;
            this.dgcDocsState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcDocsState.Width = 110;
            // 
            // dgcDocsIdStoreOut
            // 
            this.dgcDocsIdStoreOut.DataPropertyName = "IDSTOREOUT";
            this.dgcDocsIdStoreOut.DataSource = this.bsStoreOut;
            this.dgcDocsIdStoreOut.DisplayMember = "CODE";
            this.dgcDocsIdStoreOut.HeaderText = "izsniedzējs";
            this.dgcDocsIdStoreOut.MinimumWidth = 8;
            this.dgcDocsIdStoreOut.Name = "dgcDocsIdStoreOut";
            this.dgcDocsIdStoreOut.ReadOnly = true;
            this.dgcDocsIdStoreOut.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcDocsIdStoreOut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcDocsIdStoreOut.ValueMember = "ID";
            this.dgcDocsIdStoreOut.Width = 160;
            // 
            // bsStoreOut
            // 
            this.bsStoreOut.DataMember = "M_STORES";
            this.bsStoreOut.MyDataSource = "KlonsMData";
            this.bsStoreOut.Sort = "CODE";
            // 
            // dgcDocsIdStoreIn
            // 
            this.dgcDocsIdStoreIn.DataPropertyName = "IDSTOREIN";
            this.dgcDocsIdStoreIn.DataSource = this.bsStoreIn;
            this.dgcDocsIdStoreIn.DisplayMember = "CODE";
            this.dgcDocsIdStoreIn.HeaderText = "saņēmējs";
            this.dgcDocsIdStoreIn.MinimumWidth = 8;
            this.dgcDocsIdStoreIn.Name = "dgcDocsIdStoreIn";
            this.dgcDocsIdStoreIn.ReadOnly = true;
            this.dgcDocsIdStoreIn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcDocsIdStoreIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcDocsIdStoreIn.ValueMember = "ID";
            this.dgcDocsIdStoreIn.Width = 160;
            // 
            // bsStoreIn
            // 
            this.bsStoreIn.DataMember = "M_STORES";
            this.bsStoreIn.MyDataSource = "KlonsMData";
            this.bsStoreIn.Sort = "CODE";
            // 
            // dgcDocsSumm
            // 
            this.dgcDocsSumm.DataPropertyName = "SUMM";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dgcDocsSumm.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcDocsSumm.HeaderText = "summa";
            this.dgcDocsSumm.MinimumWidth = 8;
            this.dgcDocsSumm.Name = "dgcDocsSumm";
            this.dgcDocsSumm.ReadOnly = true;
            this.dgcDocsSumm.Width = 90;
            // 
            // dgcDocsCredDocDt
            // 
            this.dgcDocsCredDocDt.DataPropertyName = "CREDDOCDT";
            dataGridViewCellStyle3.Format = "dd.MM.yyyy";
            this.dgcDocsCredDocDt.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcDocsCredDocDt.HeaderText = "kd. dat.";
            this.dgcDocsCredDocDt.MinimumWidth = 8;
            this.dgcDocsCredDocDt.Name = "dgcDocsCredDocDt";
            this.dgcDocsCredDocDt.ReadOnly = true;
            this.dgcDocsCredDocDt.Width = 95;
            // 
            // dgcDocsCredDocSr
            // 
            this.dgcDocsCredDocSr.DataPropertyName = "CREDDOCSR";
            this.dgcDocsCredDocSr.HeaderText = "kd.sr.";
            this.dgcDocsCredDocSr.MinimumWidth = 8;
            this.dgcDocsCredDocSr.Name = "dgcDocsCredDocSr";
            this.dgcDocsCredDocSr.ReadOnly = true;
            this.dgcDocsCredDocSr.Width = 55;
            // 
            // dgcDocsCredDocNr
            // 
            this.dgcDocsCredDocNr.DataPropertyName = "CREDDOCNR";
            this.dgcDocsCredDocNr.HeaderText = "kd. nr.";
            this.dgcDocsCredDocNr.MinimumWidth = 8;
            this.dgcDocsCredDocNr.Name = "dgcDocsCredDocNr";
            this.dgcDocsCredDocNr.ReadOnly = true;
            this.dgcDocsCredDocNr.Width = 90;
            // 
            // dgcDocsId
            // 
            this.dgcDocsId.DataPropertyName = "ID";
            this.dgcDocsId.HeaderText = "ID";
            this.dgcDocsId.MinimumWidth = 8;
            this.dgcDocsId.Name = "dgcDocsId";
            this.dgcDocsId.ReadOnly = true;
            this.dgcDocsId.Visible = false;
            this.dgcDocsId.Width = 50;
            // 
            // dgcDocsIdSeq
            // 
            this.dgcDocsIdSeq.DataPropertyName = "IDSEQ";
            this.dgcDocsIdSeq.HeaderText = "IDSEQ";
            this.dgcDocsIdSeq.MinimumWidth = 8;
            this.dgcDocsIdSeq.Name = "dgcDocsIdSeq";
            this.dgcDocsIdSeq.ReadOnly = true;
            this.dgcDocsIdSeq.Visible = false;
            this.dgcDocsIdSeq.Width = 80;
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
            // tsbOpenDoc
            // 
            this.tsbOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenDoc.Image")));
            this.tsbOpenDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenDoc.Name = "tsbOpenDoc";
            this.tsbOpenDoc.Size = new System.Drawing.Size(100, 34);
            this.tsbOpenDoc.Text = "Atvērt";
            this.tsbOpenDoc.Click += new System.EventHandler(this.tsbOpenDoc_Click);
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
            this.tsbFind.Click += new System.EventHandler(this.tsbFind_Enter);
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
            // bsPVNType
            // 
            this.bsPVNType.DataMember = "M_PVNTYPE";
            this.bsPVNType.MyDataSource = "KlonsMData";
            this.bsPVNType.Sort = "ID";
            // 
            // bsItems
            // 
            this.bsItems.DataMember = "M_ITEMS";
            this.bsItems.MyDataSource = "KlonsMData";
            this.bsItems.Sort = "BARCODE";
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsMData";
            this.myAdapterManager1.TableNames = new string[] {
        "M_DOCS",
        "M_ROWS",
        "M_ITEMS",
        "M_ITEMS_CAT",
        "M_STORES",
        "M_ADDRESSSES",
        "M_CONTACTS",
        "M_BANKACCOUNTS",
        null};
            // 
            // bsUnits
            // 
            this.bsUnits.DataMember = "M_UNITS";
            this.bsUnits.MyDataSource = "KlonsMData";
            this.bsUnits.Sort = "CODE";
            // 
            // myConfigA1
            // 
            this.myConfigA1.DocStatusColor1 = System.Drawing.Color.LightYellow;
            this.myConfigA1.DocStatusColor2 = System.Drawing.Color.LightBlue;
            this.myConfigA1.DocStatusColor3 = System.Drawing.Color.LightGreen;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvFilter);
            this.panel1.Controls.Add(this.btFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1269, 61);
            this.panel1.TabIndex = 3;
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
            this.dgcFilterDocType,
            this.dgcFilterDocState,
            this.dgcFilterIdStoreOut,
            this.dgcFilterIdStoreIn,
            this.dgcFilterIdStoreOutOrIn});
            this.dgvFilter.DataSource = this.bsDocFilter;
            this.dgvFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFilter.Location = new System.Drawing.Point(0, 0);
            this.dgvFilter.Name = "dgvFilter";
            this.dgvFilter.RowHeadersVisible = false;
            this.dgvFilter.RowHeadersWidth = 62;
            this.dgvFilter.RowTemplate.Height = 28;
            this.dgvFilter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvFilter.ShowCellToolTips = false;
            this.dgvFilter.Size = new System.Drawing.Size(1155, 61);
            this.dgvFilter.TabIndex = 0;
            this.dgvFilter.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFilter_CellFormatting);
            this.dgvFilter.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvFilter_CellParsing);
            // 
            // dgcFilterDt1
            // 
            this.dgcFilterDt1.DataPropertyName = "Dt1";
            dataGridViewCellStyle4.Format = "dd.MM.yyyy";
            this.dgcFilterDt1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcFilterDt1.HeaderText = "datums no";
            this.dgcFilterDt1.MinimumWidth = 8;
            this.dgcFilterDt1.Name = "dgcFilterDt1";
            this.dgcFilterDt1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcFilterDt1.Width = 95;
            // 
            // dgcFilterDt2
            // 
            this.dgcFilterDt2.DataPropertyName = "Dt2";
            dataGridViewCellStyle5.Format = "dd.MM.yyyy";
            this.dgcFilterDt2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcFilterDt2.HeaderText = "datums līdz";
            this.dgcFilterDt2.MinimumWidth = 8;
            this.dgcFilterDt2.Name = "dgcFilterDt2";
            this.dgcFilterDt2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcFilterDt2.Width = 95;
            // 
            // dgcFilterDocType
            // 
            this.dgcFilterDocType.ColumnNames = new string[] {
        "NAME"};
            this.dgcFilterDocType.ColumnWidths = "150";
            this.dgcFilterDocType.DataPropertyName = "DocType";
            this.dgcFilterDocType.DataSource = this.bsDocType;
            this.dgcFilterDocType.DisplayMember = "CODE";
            this.dgcFilterDocType.HeaderText = "veids";
            this.dgcFilterDocType.MaxDropDownItems = 15;
            this.dgcFilterDocType.MinimumWidth = 8;
            this.dgcFilterDocType.Name = "dgcFilterDocType";
            this.dgcFilterDocType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcFilterDocType.ValueMember = "ID";
            this.dgcFilterDocType.Width = 140;
            // 
            // dgcFilterDocState
            // 
            this.dgcFilterDocState.DataPropertyName = "DocState";
            this.dgcFilterDocState.DisplayMember = null;
            this.dgcFilterDocState.HeaderText = "status";
            this.dgcFilterDocState.MaxDropDownItems = 15;
            this.dgcFilterDocState.MinimumWidth = 8;
            this.dgcFilterDocState.Name = "dgcFilterDocState";
            this.dgcFilterDocState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcFilterDocState.ValueMember = null;
            this.dgcFilterDocState.Width = 140;
            // 
            // dgcFilterIdStoreOut
            // 
            this.dgcFilterIdStoreOut.DataPropertyName = "IdStoreOut";
            this.dgcFilterIdStoreOut.DataSource = this.bsStoreOut;
            this.dgcFilterIdStoreOut.DisplayMember = "CODE";
            this.dgcFilterIdStoreOut.HeaderText = "izsniedzējs";
            this.dgcFilterIdStoreOut.MinimumWidth = 8;
            this.dgcFilterIdStoreOut.Name = "dgcFilterIdStoreOut";
            this.dgcFilterIdStoreOut.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcFilterIdStoreOut.ValueMember = "ID";
            this.dgcFilterIdStoreOut.Width = 200;
            // 
            // dgcFilterIdStoreIn
            // 
            this.dgcFilterIdStoreIn.DataPropertyName = "IdStoreIn";
            this.dgcFilterIdStoreIn.DataSource = this.bsStoreIn;
            this.dgcFilterIdStoreIn.DisplayMember = "CODE";
            this.dgcFilterIdStoreIn.HeaderText = "saņēmējs";
            this.dgcFilterIdStoreIn.MinimumWidth = 8;
            this.dgcFilterIdStoreIn.Name = "dgcFilterIdStoreIn";
            this.dgcFilterIdStoreIn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcFilterIdStoreIn.ValueMember = "ID";
            this.dgcFilterIdStoreIn.Width = 200;
            // 
            // dgcFilterIdStoreOutOrIn
            // 
            this.dgcFilterIdStoreOutOrIn.DataPropertyName = "IdStoreOutOrIn";
            this.dgcFilterIdStoreOutOrIn.DataSource = this.bsStoreIn;
            this.dgcFilterIdStoreOutOrIn.DisplayMember = "CODE";
            this.dgcFilterIdStoreOutOrIn.HeaderText = "izsniedzējs / saņēmējs";
            this.dgcFilterIdStoreOutOrIn.MinimumWidth = 8;
            this.dgcFilterIdStoreOutOrIn.Name = "dgcFilterIdStoreOutOrIn";
            this.dgcFilterIdStoreOutOrIn.ValueMember = "ID";
            this.dgcFilterIdStoreOutOrIn.Width = 200;
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
            this.btFilter.Location = new System.Drawing.Point(1155, 0);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(114, 61);
            this.btFilter.TabIndex = 1;
            this.btFilter.Text = "Atlasīt dokumentus";
            this.btFilter.UseVisualStyleBackColor = true;
            this.btFilter.Click += new System.EventHandler(this.btFilter_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dokumentiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1269, 38);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // dokumentiToolStripMenuItem
            // 
            this.dokumentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izveidotKredītrēķinuToolStripMenuItem,
            this.izveidotKredītrēķinusPrečuAtgriešanaiToolStripMenuItem});
            this.dokumentiToolStripMenuItem.Name = "dokumentiToolStripMenuItem";
            this.dokumentiToolStripMenuItem.Size = new System.Drawing.Size(135, 34);
            this.dokumentiToolStripMenuItem.Text = "Dokumenti";
            // 
            // izveidotKredītrēķinuToolStripMenuItem
            // 
            this.izveidotKredītrēķinuToolStripMenuItem.Name = "izveidotKredītrēķinuToolStripMenuItem";
            this.izveidotKredītrēķinuToolStripMenuItem.Size = new System.Drawing.Size(495, 38);
            this.izveidotKredītrēķinuToolStripMenuItem.Text = "Izveidot kredītrēķinu";
            this.izveidotKredītrēķinuToolStripMenuItem.Click += new System.EventHandler(this.izveidotKredītrēķinuToolStripMenuItem_Click);
            // 
            // izveidotKredītrēķinusPrečuAtgriešanaiToolStripMenuItem
            // 
            this.izveidotKredītrēķinusPrečuAtgriešanaiToolStripMenuItem.Name = "izveidotKredītrēķinusPrečuAtgriešanaiToolStripMenuItem";
            this.izveidotKredītrēķinusPrečuAtgriešanaiToolStripMenuItem.Size = new System.Drawing.Size(495, 38);
            this.izveidotKredītrēķinusPrečuAtgriešanaiToolStripMenuItem.Text = "Izveidot kredītrēķinus preču atgriešanai";
            this.izveidotKredītrēķinusPrečuAtgriešanaiToolStripMenuItem.Click += new System.EventHandler(this.izveidotKredītrēķinusPrečuAtgriešanaiToolStripMenuItem_Click);
            // 
            // FormM_DocList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 450);
            this.Controls.Add(this.dgvDocs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bNav);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormM_DocList";
            this.Text = "Dokumenti";
            this.Load += new System.EventHandler(this.FormM_DocList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).EndInit();
            this.bNav.ResumeLayout(false);
            this.bNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStoreOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStoreIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPVNType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnits)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocFilter)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.ToolStripButton bniSave;
        private System.Windows.Forms.ToolStripButton tsbFindPrev;
        private System.Windows.Forms.ToolStripTextBox tsbFind;
        private System.Windows.Forms.ToolStripButton tsbFindNext;
        private KlonsLIB.Data.MyBindingSource bsDocs;
        private KlonsLIB.Data.MyBindingSource bsDocType;
        private KlonsLIB.Data.MyBindingSource bsPVNType;
        private KlonsLIB.Data.MyBindingSource bsStoreOut;
        private KlonsLIB.Data.MyBindingSource bsStoreIn;
        private KlonsLIB.Data.MyBindingSource bsItems;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private KlonsLIB.Data.MyBindingSource bsUnits;
        private MyConfigA myConfigA1;
        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Components.MyDataGridView dgvDocs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsSR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsNr;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcDocsTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsPVNType;
        private KlonsLIB.Components.DataGridViewColorMarkColumn dgcDocsState;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcDocsIdStoreOut;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcDocsIdStoreIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsSumm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsCredDocDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsCredDocSr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsCredDocNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsIdSeq;
        private KlonsLIB.Components.MyDataGridView dgvFilter;
        private KlonsLIB.Data.MyBindingSourceToObj bsDocFilter;
        private DataObjectsFM.DocFilterData docFilterData1;
        private System.Windows.Forms.Button btFilter;
        private System.Windows.Forms.ToolStripButton tsbOpenDoc;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dokumentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izveidotKredītrēķinuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izveidotKredītrēķinusPrečuAtgriešanaiToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFilterDt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFilterDt2;
        private KlonsLIB.Components.MyDgvMcCBColumn dgcFilterDocType;
        private KlonsLIB.Components.MyDgvMcCBColumn dgcFilterDocState;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcFilterIdStoreOut;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcFilterIdStoreIn;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcFilterIdStoreOutOrIn;
    }
}