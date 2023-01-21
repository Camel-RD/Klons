
namespace KlonsFM.FormsM
{
    partial class FormM_Doc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormM_Doc));
            this.mySplitContainer1 = new KlonsLIB.Components.MySplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dokumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kopētDokumentuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dzēstDokumentuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.iegrāmatotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iegrāmatotVeidotPilnuPārrēķinuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.atvērtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atvērtRediģēšanaiVeicotPilnuPārrēķinuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.izveidotKredītrēķinuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prečuAtgriešanaCenasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prečuAtgriešanaIzveidotKredītrēķinusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.kontējumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izdrukaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pavadzīmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sgrDocA = new KlonsLIB.MySourceGrid.MyGrid();
            this.docData1 = new DataObjectsFM.DocData();
            this.grDocTitleDokuments = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grDocDT = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.bsDocs = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grDocSR = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDocNR = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDocTP = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.bsDocType = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grDocTransType = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.bsTransType = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grDocState = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDocTitleKrajumi = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grDocStoreOut = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.bsStoreOut = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grDocStoreIn = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.bsStoreIn = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grDocCMCol2 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowCommand();
            this.grDocTitleCredDoc = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.gdDocCdDT = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDocCdSr = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDocCdNr = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDocTitleTransoirt = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grDocAddressOut = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.bsAddress = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grDocAddressIn = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.grDocCarrier = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.bsCarrier = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grDocDriver = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.bsDriver = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grDocVehicle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.bsVehicle = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grDocCMCol3 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowCommand();
            this.grDocTitlePay = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grDocPayType = new KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB();
            this.bsPayType = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grDocDueDate = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDocTitleFinances = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grDocPVNType = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.bsPVNType = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grDocAccIn = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.bsAccounts = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grDocAccOut = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.grDocManualFinOps = new KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox();
            this.grDocIncludeInCostCalc = new KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox();
            this.grDocSum = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcRowsIdItem = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.bsItems = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcRowsItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsPrice0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsTPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsIdPVNRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowTBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsIdDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowsIdSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsRows = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.bsUnits = new KlonsLIB.Data.MyBindingSource(this.components);
            this.myConfigA1 = new KlonsFM.FormsM.MyConfigA();
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
            ((System.ComponentModel.ISupportInitialize)(this.mySplitContainer1)).BeginInit();
            this.mySplitContainer1.Panel1.SuspendLayout();
            this.mySplitContainer1.Panel2.SuspendLayout();
            this.mySplitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStoreOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStoreIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCarrier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPayType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPVNType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).BeginInit();
            this.bNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // mySplitContainer1
            // 
            this.mySplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mySplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.mySplitContainer1.Name = "mySplitContainer1";
            this.mySplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mySplitContainer1.Panel1
            // 
            this.mySplitContainer1.Panel1.Controls.Add(this.menuStrip1);
            this.mySplitContainer1.Panel1.Controls.Add(this.sgrDocA);
            // 
            // mySplitContainer1.Panel2
            // 
            this.mySplitContainer1.Panel2.Controls.Add(this.dgvRows);
            this.mySplitContainer1.Size = new System.Drawing.Size(1078, 475);
            this.mySplitContainer1.SplitterDistance = 269;
            this.mySplitContainer1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dokumentsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(35, 38);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(147, 38);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // dokumentsToolStripMenuItem
            // 
            this.dokumentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kopētDokumentuToolStripMenuItem,
            this.dzēstDokumentuToolStripMenuItem,
            this.toolStripSeparator1,
            this.iegrāmatotToolStripMenuItem,
            this.iegrāmatotVeidotPilnuPārrēķinuToolStripMenuItem,
            this.toolStripSeparator2,
            this.atvērtToolStripMenuItem,
            this.atvērtRediģēšanaiVeicotPilnuPārrēķinuToolStripMenuItem,
            this.toolStripSeparator3,
            this.izveidotKredītrēķinuToolStripMenuItem,
            this.prečuAtgriešanaCenasToolStripMenuItem,
            this.prečuAtgriešanaIzveidotKredītrēķinusToolStripMenuItem,
            this.toolStripSeparator4,
            this.kontējumsToolStripMenuItem,
            this.izdrukaiToolStripMenuItem});
            this.dokumentsToolStripMenuItem.Name = "dokumentsToolStripMenuItem";
            this.dokumentsToolStripMenuItem.Size = new System.Drawing.Size(139, 34);
            this.dokumentsToolStripMenuItem.Text = "Dokuments";
            // 
            // kopētDokumentuToolStripMenuItem
            // 
            this.kopētDokumentuToolStripMenuItem.Name = "kopētDokumentuToolStripMenuItem";
            this.kopētDokumentuToolStripMenuItem.Size = new System.Drawing.Size(507, 38);
            this.kopētDokumentuToolStripMenuItem.Text = "Kopēt dokumentu";
            this.kopētDokumentuToolStripMenuItem.Click += new System.EventHandler(this.kopētDokumentuToolStripMenuItem_Click);
            // 
            // dzēstDokumentuToolStripMenuItem
            // 
            this.dzēstDokumentuToolStripMenuItem.Name = "dzēstDokumentuToolStripMenuItem";
            this.dzēstDokumentuToolStripMenuItem.Size = new System.Drawing.Size(507, 38);
            this.dzēstDokumentuToolStripMenuItem.Text = "Dzēst dokumentu";
            this.dzēstDokumentuToolStripMenuItem.Click += new System.EventHandler(this.dzēstDokumentuToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(504, 6);
            // 
            // iegrāmatotToolStripMenuItem
            // 
            this.iegrāmatotToolStripMenuItem.Name = "iegrāmatotToolStripMenuItem";
            this.iegrāmatotToolStripMenuItem.Size = new System.Drawing.Size(507, 38);
            this.iegrāmatotToolStripMenuItem.Text = "Iegrāmatot";
            this.iegrāmatotToolStripMenuItem.Click += new System.EventHandler(this.iegrāmatotToolStripMenuItem_Click);
            // 
            // iegrāmatotVeidotPilnuPārrēķinuToolStripMenuItem
            // 
            this.iegrāmatotVeidotPilnuPārrēķinuToolStripMenuItem.Name = "iegrāmatotVeidotPilnuPārrēķinuToolStripMenuItem";
            this.iegrāmatotVeidotPilnuPārrēķinuToolStripMenuItem.Size = new System.Drawing.Size(507, 38);
            this.iegrāmatotVeidotPilnuPārrēķinuToolStripMenuItem.Text = "Iegrāmatot veicot pilnu pārrēķinu";
            this.iegrāmatotVeidotPilnuPārrēķinuToolStripMenuItem.Click += new System.EventHandler(this.iegrāmatotVeicotPilnuPārrēķinuToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(504, 6);
            // 
            // atvērtToolStripMenuItem
            // 
            this.atvērtToolStripMenuItem.Name = "atvērtToolStripMenuItem";
            this.atvērtToolStripMenuItem.Size = new System.Drawing.Size(507, 38);
            this.atvērtToolStripMenuItem.Text = "Atvērt rediģēšanai";
            this.atvērtToolStripMenuItem.Click += new System.EventHandler(this.atvērtToolStripMenuItem_Click);
            // 
            // atvērtRediģēšanaiVeicotPilnuPārrēķinuToolStripMenuItem
            // 
            this.atvērtRediģēšanaiVeicotPilnuPārrēķinuToolStripMenuItem.Name = "atvērtRediģēšanaiVeicotPilnuPārrēķinuToolStripMenuItem";
            this.atvērtRediģēšanaiVeicotPilnuPārrēķinuToolStripMenuItem.Size = new System.Drawing.Size(507, 38);
            this.atvērtRediģēšanaiVeicotPilnuPārrēķinuToolStripMenuItem.Text = "Atvērt rediģēšanai veicot pilnu pārrēķinu";
            this.atvērtRediģēšanaiVeicotPilnuPārrēķinuToolStripMenuItem.Click += new System.EventHandler(this.atvērtRediģēšanaiVeicotPilnuPārrēķinuToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(504, 6);
            // 
            // izveidotKredītrēķinuToolStripMenuItem
            // 
            this.izveidotKredītrēķinuToolStripMenuItem.Name = "izveidotKredītrēķinuToolStripMenuItem";
            this.izveidotKredītrēķinuToolStripMenuItem.Size = new System.Drawing.Size(507, 38);
            this.izveidotKredītrēķinuToolStripMenuItem.Text = "Izveidot kredītrēķinu";
            this.izveidotKredītrēķinuToolStripMenuItem.Click += new System.EventHandler(this.izveidotKredītrēķinuToolStripMenuItem_Click);
            // 
            // prečuAtgriešanaCenasToolStripMenuItem
            // 
            this.prečuAtgriešanaCenasToolStripMenuItem.Name = "prečuAtgriešanaCenasToolStripMenuItem";
            this.prečuAtgriešanaCenasToolStripMenuItem.Size = new System.Drawing.Size(507, 38);
            this.prečuAtgriešanaCenasToolStripMenuItem.Text = "Preču atgriešana -  cenas aprēķins";
            this.prečuAtgriešanaCenasToolStripMenuItem.Click += new System.EventHandler(this.prečuAtgriešanaCenasAprēķinsToolStripMenuItem_Click);
            // 
            // prečuAtgriešanaIzveidotKredītrēķinusToolStripMenuItem
            // 
            this.prečuAtgriešanaIzveidotKredītrēķinusToolStripMenuItem.Name = "prečuAtgriešanaIzveidotKredītrēķinusToolStripMenuItem";
            this.prečuAtgriešanaIzveidotKredītrēķinusToolStripMenuItem.Size = new System.Drawing.Size(507, 38);
            this.prečuAtgriešanaIzveidotKredītrēķinusToolStripMenuItem.Text = "Preču atgriešana - izveidot kredītrēķinus";
            this.prečuAtgriešanaIzveidotKredītrēķinusToolStripMenuItem.Click += new System.EventHandler(this.prečuAtgriešanaIzveidotKredītrēķinusToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(504, 6);
            // 
            // kontējumsToolStripMenuItem
            // 
            this.kontējumsToolStripMenuItem.Name = "kontējumsToolStripMenuItem";
            this.kontējumsToolStripMenuItem.Size = new System.Drawing.Size(507, 38);
            this.kontējumsToolStripMenuItem.Text = "Kontējums";
            this.kontējumsToolStripMenuItem.Click += new System.EventHandler(this.kontējumsToolStripMenuItem_Click);
            // 
            // izdrukaiToolStripMenuItem
            // 
            this.izdrukaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pavadzīmeToolStripMenuItem});
            this.izdrukaiToolStripMenuItem.Name = "izdrukaiToolStripMenuItem";
            this.izdrukaiToolStripMenuItem.Size = new System.Drawing.Size(507, 38);
            this.izdrukaiToolStripMenuItem.Text = "Izdrukai";
            // 
            // pavadzīmeToolStripMenuItem
            // 
            this.pavadzīmeToolStripMenuItem.Name = "pavadzīmeToolStripMenuItem";
            this.pavadzīmeToolStripMenuItem.Size = new System.Drawing.Size(219, 38);
            this.pavadzīmeToolStripMenuItem.Text = "Pavadzīme";
            this.pavadzīmeToolStripMenuItem.Click += new System.EventHandler(this.pavadzīmeToolStripMenuItem_Click);
            // 
            // sgrDocA
            // 
            this.sgrDocA.BackColor2 = System.Drawing.SystemColors.Window;
            this.sgrDocA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sgrDocA.ColumnWidth1 = 5;
            this.sgrDocA.ColumnWidth2 = 120;
            this.sgrDocA.ColumnWidth3 = 180;
            this.sgrDocA.DefaultHeight = 25;
            this.sgrDocA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgrDocA.EnableSort = true;
            this.sgrDocA.Location = new System.Drawing.Point(0, 0);
            this.sgrDocA.MyDataBC = this.docData1;
            this.sgrDocA.Name = "sgrDocA";
            this.sgrDocA.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.sgrDocA.RowList.Add(this.grDocTitleDokuments);
            this.sgrDocA.RowList.Add(this.grDocDT);
            this.sgrDocA.RowList.Add(this.grDocSR);
            this.sgrDocA.RowList.Add(this.grDocNR);
            this.sgrDocA.RowList.Add(this.grDocTP);
            this.sgrDocA.RowList.Add(this.grDocTransType);
            this.sgrDocA.RowList.Add(this.grDocState);
            this.sgrDocA.RowList.Add(this.grDocTitleKrajumi);
            this.sgrDocA.RowList.Add(this.grDocStoreOut);
            this.sgrDocA.RowList.Add(this.grDocStoreIn);
            this.sgrDocA.RowList.Add(this.grDocCMCol2);
            this.sgrDocA.RowList.Add(this.grDocTitleCredDoc);
            this.sgrDocA.RowList.Add(this.gdDocCdDT);
            this.sgrDocA.RowList.Add(this.grDocCdSr);
            this.sgrDocA.RowList.Add(this.grDocCdNr);
            this.sgrDocA.RowList.Add(this.grDocTitleTransoirt);
            this.sgrDocA.RowList.Add(this.grDocAddressOut);
            this.sgrDocA.RowList.Add(this.grDocAddressIn);
            this.sgrDocA.RowList.Add(this.grDocCarrier);
            this.sgrDocA.RowList.Add(this.grDocDriver);
            this.sgrDocA.RowList.Add(this.grDocVehicle);
            this.sgrDocA.RowList.Add(this.grDocCMCol3);
            this.sgrDocA.RowList.Add(this.grDocTitlePay);
            this.sgrDocA.RowList.Add(this.grDocPayType);
            this.sgrDocA.RowList.Add(this.grDocDueDate);
            this.sgrDocA.RowList.Add(this.grDocTitleFinances);
            this.sgrDocA.RowList.Add(this.grDocPVNType);
            this.sgrDocA.RowList.Add(this.grDocAccIn);
            this.sgrDocA.RowList.Add(this.grDocAccOut);
            this.sgrDocA.RowList.Add(this.grDocManualFinOps);
            this.sgrDocA.RowList.Add(this.grDocIncludeInCostCalc);
            this.sgrDocA.RowList.Add(this.grDocSum);
            this.sgrDocA.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.sgrDocA.Size = new System.Drawing.Size(1078, 269);
            this.sgrDocA.TabIndex = 0;
            this.sgrDocA.TabStop = true;
            this.sgrDocA.ToolTipText = "";
            this.sgrDocA.EditStarting += new System.ComponentModel.CancelEventHandler(this.sgrDocA_EditStarting);
            this.sgrDocA.ConvertingValueToDisplayString += new DevAge.ComponentModel.ConvertingObjectEventHandler(this.sgrDocA_ConvertingValueToDisplayString);
            // 
            // docData1
            // 
            this.docData1._ACCIN = null;
            this.docData1._ACCOUNTINGTP = ((short)(0));
            this.docData1._ACCOUT = null;
            this.docData1._ACCTP1 = ((short)(0));
            this.docData1._ACCTP2 = ((short)(0));
            this.docData1._CREDDOCDT = null;
            this.docData1._CREDDOCNR = null;
            this.docData1._CREDDOCSR = null;
            this.docData1._DT = new System.DateTime(((long)(0)));
            this.docData1._DUEDATE = null;
            this.docData1._ID = 0;
            this.docData1._IDADDRESSIN = 0;
            this.docData1._IDADDRESSOUT = 0;
            this.docData1._IDCARRIER = 0;
            this.docData1._IDCREDDOC = null;
            this.docData1._IDDRIVER = 0;
            this.docData1._IDPAYMENTTYPE = 0;
            this.docData1._IDSTOREIN = 0;
            this.docData1._IDSTOREOUT = 0;
            this.docData1._IDTRANSACTIONTYPE = 0;
            this.docData1._IDVEHICLE = 0;
            this.docData1._NR = null;
            this.docData1._PVNTYPE = 0;
            this.docData1._SR = null;
            this.docData1._STATE = 0;
            this.docData1._SUMM = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.docData1._TP = 0;
            // 
            // grDocTitleDokuments
            // 
            this.grDocTitleDokuments.Name = "grDocTitleDokuments";
            this.grDocTitleDokuments.RowTitle = "Dokuments";
            this.grDocTitleDokuments.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // grDocDT
            // 
            this.grDocDT.DataMember = "DT";
            this.grDocDT.DataSource = this.bsDocs;
            this.grDocDT.GridPropertyName = "_DT";
            this.grDocDT.Name = "grDocDT";
            this.grDocDT.RowTitle = "Datums";
            this.grDocDT.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Date;
            // 
            // bsDocs
            // 
            this.bsDocs.DataMember = "M_DOCS";
            this.bsDocs.MyDataSource = "KlonsMData";
            this.bsDocs.Sort = "";
            this.bsDocs.CurrentChanged += new System.EventHandler(this.bsDocs_CurrentChanged);
            this.bsDocs.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsDocs_ListChanged);
            // 
            // grDocSR
            // 
            this.grDocSR.DataMember = "SR";
            this.grDocSR.DataSource = this.bsDocs;
            this.grDocSR.GridPropertyName = "_SR";
            this.grDocSR.Name = "grDocSR";
            this.grDocSR.RowTitle = "Sērija";
            this.grDocSR.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grDocNR
            // 
            this.grDocNR.DataMember = "NR";
            this.grDocNR.DataSource = this.bsDocs;
            this.grDocNR.GridPropertyName = "_NR";
            this.grDocNR.Name = "grDocNR";
            this.grDocNR.RowTitle = "Numurs";
            this.grDocNR.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grDocTP
            // 
            this.grDocTP.DataMember = "TP";
            this.grDocTP.DataSource = this.bsDocs;
            this.grDocTP.GridPropertyName = "_TP";
            this.grDocTP.ListDisplayMember = "CODE";
            this.grDocTP.ListSource = this.bsDocType;
            this.grDocTP.ListValueMember = "ID";
            this.grDocTP.Name = "grDocTP";
            this.grDocTP.RowTitle = "Veids";
            this.grDocTP.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // bsDocType
            // 
            this.bsDocType.DataMember = "M_DOCTYPES";
            this.bsDocType.MyDataSource = "KlonsMData";
            this.bsDocType.Sort = "ID";
            // 
            // grDocTransType
            // 
            this.grDocTransType.DataMember = "IDTRANSACTIONTYPE";
            this.grDocTransType.DataSource = this.bsDocs;
            this.grDocTransType.GridPropertyName = "_IDTRANSACTIONTYPE";
            this.grDocTransType.ListDisplayMember = "NAME";
            this.grDocTransType.ListSource = this.bsTransType;
            this.grDocTransType.ListValueMember = "ID";
            this.grDocTransType.Name = "grDocTransType";
            this.grDocTransType.RowTitle = "Darijuma veids";
            this.grDocTransType.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // bsTransType
            // 
            this.bsTransType.DataMember = "M_TRANSACTIONTYPE";
            this.bsTransType.MyDataSource = "KlonsMData";
            this.bsTransType.Sort = "ID";
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
            // grDocTitleKrajumi
            // 
            this.grDocTitleKrajumi.Name = "grDocTitleKrajumi";
            this.grDocTitleKrajumi.RowTitle = "Krājumu kustība";
            this.grDocTitleKrajumi.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // grDocStoreOut
            // 
            this.grDocStoreOut.CustomConversions = true;
            this.grDocStoreOut.DataMember = "IDSTOREOUT";
            this.grDocStoreOut.DataSource = this.bsDocs;
            this.grDocStoreOut.GridPropertyName = "_IDSTOREOUT";
            this.grDocStoreOut.ListDisplayMember = "CODE";
            this.grDocStoreOut.ListSource = this.bsStoreOut;
            this.grDocStoreOut.ListValueMember = "ID";
            this.grDocStoreOut.Name = "grDocStoreOut";
            this.grDocStoreOut.RowTitle = "Izsniedzējs";
            this.grDocStoreOut.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // bsStoreOut
            // 
            this.bsStoreOut.DataMember = "M_STORES";
            this.bsStoreOut.MyDataSource = "KlonsMData";
            this.bsStoreOut.Sort = "CODE";
            // 
            // grDocStoreIn
            // 
            this.grDocStoreIn.CustomConversions = true;
            this.grDocStoreIn.DataMember = "IDSTOREIN";
            this.grDocStoreIn.DataSource = this.bsDocs;
            this.grDocStoreIn.GridPropertyName = "_IDSTOREIN";
            this.grDocStoreIn.ListDisplayMember = "CODE";
            this.grDocStoreIn.ListSource = this.bsStoreIn;
            this.grDocStoreIn.ListValueMember = "ID";
            this.grDocStoreIn.Name = "grDocStoreIn";
            this.grDocStoreIn.RowTitle = "Saņēmējs";
            this.grDocStoreIn.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // bsStoreIn
            // 
            this.bsStoreIn.DataMember = "M_STORES";
            this.bsStoreIn.MyDataSource = "KlonsMData";
            this.bsStoreIn.Sort = "CODE";
            // 
            // grDocCMCol2
            // 
            this.grDocCMCol2.CaptionColumnWidth = 150;
            this.grDocCMCol2.Command = KlonsLIB.MySourceGrid.GridRows.EMyGridRowCommands.StartNewColumn;
            this.grDocCMCol2.Name = "grDocCMCol2";
            this.grDocCMCol2.RowTitle = null;
            this.grDocCMCol2.SetColumnWidth = true;
            // 
            // grDocTitleCredDoc
            // 
            this.grDocTitleCredDoc.Name = "grDocTitleCredDoc";
            this.grDocTitleCredDoc.RowTitle = "Kredītrēķins";
            this.grDocTitleCredDoc.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // gdDocCdDT
            // 
            this.gdDocCdDT.DataMember = "CREDDOCDT";
            this.gdDocCdDT.DataSource = this.bsDocs;
            this.gdDocCdDT.GridPropertyName = "_CREDDOCDT";
            this.gdDocCdDT.Name = "gdDocCdDT";
            this.gdDocCdDT.ReadOnly = true;
            this.gdDocCdDT.RowTitle = "Datums";
            this.gdDocCdDT.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.DateN;
            // 
            // grDocCdSr
            // 
            this.grDocCdSr.DataMember = "CREDDOCSR";
            this.grDocCdSr.DataSource = this.bsDocs;
            this.grDocCdSr.GridPropertyName = "_CREDDOCSR";
            this.grDocCdSr.Name = "grDocCdSr";
            this.grDocCdSr.ReadOnly = true;
            this.grDocCdSr.RowTitle = "Sērija";
            this.grDocCdSr.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grDocCdNr
            // 
            this.grDocCdNr.DataMember = "CREDDOCNR";
            this.grDocCdNr.DataSource = this.bsDocs;
            this.grDocCdNr.GridPropertyName = "_CREDDOCNR";
            this.grDocCdNr.Name = "grDocCdNr";
            this.grDocCdNr.ReadOnly = true;
            this.grDocCdNr.RowTitle = "Numurs";
            this.grDocCdNr.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grDocTitleTransoirt
            // 
            this.grDocTitleTransoirt.Name = "grDocTitleTransoirt";
            this.grDocTitleTransoirt.RowTitle = "Transports";
            this.grDocTitleTransoirt.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // grDocAddressOut
            // 
            this.grDocAddressOut.AllowNull = true;
            this.grDocAddressOut.DataMember = "IDADDRESSOUT";
            this.grDocAddressOut.DataSource = this.bsDocs;
            this.grDocAddressOut.GridPropertyName = "_IDADDRESSOUT";
            this.grDocAddressOut.ListDisplayMember = "ADDRESS";
            this.grDocAddressOut.ListSource = this.bsAddress;
            this.grDocAddressOut.ListValueMember = "ID";
            this.grDocAddressOut.Name = "grDocAddressOut";
            this.grDocAddressOut.ReadOnlyEx = true;
            this.grDocAddressOut.RowTitle = "Izsniegšanas adr.";
            this.grDocAddressOut.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.IntegerN;
            // 
            // bsAddress
            // 
            this.bsAddress.DataMember = "M_ADDRESSSES";
            this.bsAddress.MyDataSource = "KlonsMData";
            // 
            // grDocAddressIn
            // 
            this.grDocAddressIn.AllowNull = true;
            this.grDocAddressIn.DataMember = "IDADDRESSIN";
            this.grDocAddressIn.DataSource = this.bsDocs;
            this.grDocAddressIn.GridPropertyName = "_IDADDRESSIN";
            this.grDocAddressIn.ListDisplayMember = "ADDRESS";
            this.grDocAddressIn.ListSource = this.bsAddress;
            this.grDocAddressIn.ListValueMember = "ID";
            this.grDocAddressIn.Name = "grDocAddressIn";
            this.grDocAddressIn.ReadOnlyEx = true;
            this.grDocAddressIn.RowTitle = "Saņemšanas adr.";
            this.grDocAddressIn.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.IntegerN;
            // 
            // grDocCarrier
            // 
            this.grDocCarrier.AllowNull = true;
            this.grDocCarrier.DataMember = "IDCARRIER";
            this.grDocCarrier.DataSource = this.bsDocs;
            this.grDocCarrier.GridPropertyName = "_IDCARRIER";
            this.grDocCarrier.ListDisplayMember = "CODE";
            this.grDocCarrier.ListSource = this.bsCarrier;
            this.grDocCarrier.ListValueMember = "ID";
            this.grDocCarrier.Name = "grDocCarrier";
            this.grDocCarrier.RowTitle = "Pārvadātājs";
            this.grDocCarrier.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.IntegerN;
            // 
            // bsCarrier
            // 
            this.bsCarrier.DataMember = "M_STORES";
            this.bsCarrier.MyDataSource = "KlonsMData";
            this.bsCarrier.Sort = "CODE";
            // 
            // grDocDriver
            // 
            this.grDocDriver.AllowNull = true;
            this.grDocDriver.DataMember = "IDDRIVER";
            this.grDocDriver.DataSource = this.bsDocs;
            this.grDocDriver.GridPropertyName = "_IDDRIVER";
            this.grDocDriver.ListDisplayMember = "NAME";
            this.grDocDriver.ListSource = this.bsDriver;
            this.grDocDriver.ListValueMember = "ID";
            this.grDocDriver.Name = "grDocDriver";
            this.grDocDriver.ReadOnlyEx = true;
            this.grDocDriver.RowTitle = "Vadītājs";
            this.grDocDriver.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.IntegerN;
            // 
            // bsDriver
            // 
            this.bsDriver.DataMember = "M_CONTACTS";
            this.bsDriver.MyDataSource = "KlonsMData";
            this.bsDriver.Sort = "NAME";
            // 
            // grDocVehicle
            // 
            this.grDocVehicle.AllowNull = true;
            this.grDocVehicle.DataMember = "IDVEHICLE";
            this.grDocVehicle.DataSource = this.bsDocs;
            this.grDocVehicle.GridPropertyName = "_IDVEHICLE";
            this.grDocVehicle.ListDisplayMember = "NAME";
            this.grDocVehicle.ListSource = this.bsVehicle;
            this.grDocVehicle.ListValueMember = "ID";
            this.grDocVehicle.Name = "grDocVehicle";
            this.grDocVehicle.ReadOnlyEx = true;
            this.grDocVehicle.RowTitle = "TL reģ.nr.";
            this.grDocVehicle.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.IntegerN;
            // 
            // bsVehicle
            // 
            this.bsVehicle.DataMember = "M_VEHICLES";
            this.bsVehicle.MyDataSource = "KlonsMData";
            // 
            // grDocCMCol3
            // 
            this.grDocCMCol3.CaptionColumnWidth = 160;
            this.grDocCMCol3.Command = KlonsLIB.MySourceGrid.GridRows.EMyGridRowCommands.StartNewColumn;
            this.grDocCMCol3.DataColumnWidth = 220;
            this.grDocCMCol3.Name = "grDocCMCol3";
            this.grDocCMCol3.RowTitle = null;
            this.grDocCMCol3.SetColumnWidth = true;
            // 
            // grDocTitlePay
            // 
            this.grDocTitlePay.Name = "grDocTitlePay";
            this.grDocTitlePay.RowTitle = "Norēķini";
            this.grDocTitlePay.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // grDocPayType
            // 
            this.grDocPayType.AllowNull = true;
            this.grDocPayType.ColumnNames = new string[] {
        "NAME"};
            this.grDocPayType.ColumnWidths = "200";
            this.grDocPayType.DataMember = "IDPAYMENTTYPE";
            this.grDocPayType.DataSource = this.bsDocs;
            this.grDocPayType.GridPropertyName = "_IDPAYMENTTYPE";
            this.grDocPayType.ListDisplayMember = "NAME";
            this.grDocPayType.ListSource = this.bsPayType;
            this.grDocPayType.ListValueMember = "ID";
            this.grDocPayType.Name = "grDocPayType";
            this.grDocPayType.RowTitle = "Veids";
            this.grDocPayType.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.IntegerN;
            // 
            // bsPayType
            // 
            this.bsPayType.DataMember = "M_PAYMENTTYPE";
            this.bsPayType.MyDataSource = "KlonsMData";
            this.bsPayType.Sort = "ID";
            // 
            // grDocDueDate
            // 
            this.grDocDueDate.AllowNull = true;
            this.grDocDueDate.DataMember = "DUEDATE";
            this.grDocDueDate.DataSource = this.bsDocs;
            this.grDocDueDate.GridPropertyName = "_DUEDATE";
            this.grDocDueDate.Name = "grDocDueDate";
            this.grDocDueDate.RowTitle = "Apmaksāt līdz";
            this.grDocDueDate.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.DateN;
            // 
            // grDocTitleFinances
            // 
            this.grDocTitleFinances.Name = "grDocTitleFinances";
            this.grDocTitleFinances.RowTitle = "Kontēšana";
            this.grDocTitleFinances.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // grDocPVNType
            // 
            this.grDocPVNType.DataMember = "PVNTYPE";
            this.grDocPVNType.DataSource = this.bsDocs;
            this.grDocPVNType.GridPropertyName = "_PVNTYPE";
            this.grDocPVNType.ListDisplayMember = "NAME";
            this.grDocPVNType.ListSource = this.bsPVNType;
            this.grDocPVNType.ListValueMember = "ID";
            this.grDocPVNType.Name = "grDocPVNType";
            this.grDocPVNType.RowTitle = "PVN režīms";
            this.grDocPVNType.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // bsPVNType
            // 
            this.bsPVNType.DataMember = "M_PVNTYPE";
            this.bsPVNType.MyDataSource = "KlonsMData";
            this.bsPVNType.Sort = "ID";
            // 
            // grDocAccIn
            // 
            this.grDocAccIn.DataMember = "ACCIN";
            this.grDocAccIn.DataSource = this.bsDocs;
            this.grDocAccIn.GridPropertyName = "_ACCIN";
            this.grDocAccIn.ListDisplayMember = "ID";
            this.grDocAccIn.ListSource = this.bsAccounts;
            this.grDocAccIn.ListValueMember = "ID";
            this.grDocAccIn.Name = "grDocAccIn";
            this.grDocAccIn.RowTitle = "debets";
            this.grDocAccIn.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // bsAccounts
            // 
            this.bsAccounts.DataMember = "M_ACCOUNTS";
            this.bsAccounts.MyDataSource = "KlonsMData";
            this.bsAccounts.Sort = "ID";
            // 
            // grDocAccOut
            // 
            this.grDocAccOut.DataMember = "ACCOUT";
            this.grDocAccOut.DataSource = this.bsDocs;
            this.grDocAccOut.GridPropertyName = "_ACCOUT";
            this.grDocAccOut.ListDisplayMember = "ID";
            this.grDocAccOut.ListSource = this.bsAccounts;
            this.grDocAccOut.ListValueMember = "ID";
            this.grDocAccOut.Name = "grDocAccOut";
            this.grDocAccOut.RowTitle = "kredīts";
            this.grDocAccOut.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grDocManualFinOps
            // 
            this.grDocManualFinOps.DataMember = "ACCTP1";
            this.grDocManualFinOps.DataSource = this.bsDocs;
            this.grDocManualFinOps.FalseValue = "1";
            this.grDocManualFinOps.GridPropertyName = "_ACCTP1";
            this.grDocManualFinOps.Name = "grDocManualFinOps";
            this.grDocManualFinOps.ReadOnly = true;
            this.grDocManualFinOps.RowTitle = "Manuāls kontējums";
            this.grDocManualFinOps.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.ShortInt;
            this.grDocManualFinOps.TrueValue = "0";
            // 
            // grDocIncludeInCostCalc
            // 
            this.grDocIncludeInCostCalc.DataMember = "ACCTP2";
            this.grDocIncludeInCostCalc.DataSource = this.bsDocs;
            this.grDocIncludeInCostCalc.FalseValue = "0";
            this.grDocIncludeInCostCalc.GridPropertyName = "_ACCTP2";
            this.grDocIncludeInCostCalc.Name = "grDocIncludeInCostCalc";
            this.grDocIncludeInCostCalc.RowTitle = "Ir izmaksu aprēķinā";
            this.grDocIncludeInCostCalc.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.ShortInt;
            this.grDocIncludeInCostCalc.TrueValue = "1";
            // 
            // grDocSum
            // 
            this.grDocSum.DataMember = "SUMM";
            this.grDocSum.DataSource = this.bsDocs;
            this.grDocSum.GridPropertyName = "_SUMM";
            this.grDocSum.Name = "grDocSum";
            this.grDocSum.RowTitle = "Summa";
            this.grDocSum.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // dgvRows
            // 
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.AutoSave = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcRowsIdItem,
            this.dgcRowsItemName,
            this.dgcRowsUnits,
            this.dgcRowsAmount,
            this.dgcRowsPrice0,
            this.dgcRowsDiscount,
            this.dgcRowsPrice,
            this.dgcRowsTPrice,
            this.dgcRowsIdPVNRate,
            this.dgcRowsBuyPrice,
            this.dgcRowTBuyPrice,
            this.dgcRowsId,
            this.dgcRowsIdDoc,
            this.dgcRowsIdSeq});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 0);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.RowHeadersWidth = 30;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(1078, 202);
            this.dgvRows.TabIndex = 0;
            this.dgvRows.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRows_MyKeyDown);
            this.dgvRows.MyCheckForChanges += new System.EventHandler(this.dgvRows_MyCheckForChanges);
            this.dgvRows.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvRows_CellBeginEdit);
            this.dgvRows.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRows_CellDoubleClick);
            this.dgvRows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRows_CellFormatting);
            this.dgvRows.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvRows_DefaultValuesNeeded);
            this.dgvRows.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvRows_UserDeletingRow);
            // 
            // dgcRowsIdItem
            // 
            this.dgcRowsIdItem.DataPropertyName = "IDITEM";
            this.dgcRowsIdItem.DataSource = this.bsItems;
            this.dgcRowsIdItem.DisplayMember = "BARCODE";
            this.dgcRowsIdItem.Frozen = true;
            this.dgcRowsIdItem.HeaderText = "artikuls";
            this.dgcRowsIdItem.MinimumWidth = 8;
            this.dgcRowsIdItem.Name = "dgcRowsIdItem";
            this.dgcRowsIdItem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcRowsIdItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcRowsIdItem.ValueMember = "ID";
            this.dgcRowsIdItem.Width = 150;
            // 
            // bsItems
            // 
            this.bsItems.DataMember = "M_ITEMS";
            this.bsItems.MyDataSource = "KlonsMData";
            this.bsItems.Sort = "BARCODE";
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
            // dgcRowsUnits
            // 
            this.dgcRowsUnits.DataPropertyName = "UNITS";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcRowsUnits.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcRowsUnits.HeaderText = "mērv.";
            this.dgcRowsUnits.MinimumWidth = 8;
            this.dgcRowsUnits.Name = "dgcRowsUnits";
            this.dgcRowsUnits.ReadOnly = true;
            this.dgcRowsUnits.Width = 60;
            // 
            // dgcRowsAmount
            // 
            this.dgcRowsAmount.DataPropertyName = "AMOUNT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcRowsAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcRowsAmount.HeaderText = "skaits";
            this.dgcRowsAmount.MinimumWidth = 8;
            this.dgcRowsAmount.Name = "dgcRowsAmount";
            this.dgcRowsAmount.Width = 60;
            // 
            // dgcRowsPrice0
            // 
            this.dgcRowsPrice0.DataPropertyName = "PRICE0";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            this.dgcRowsPrice0.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcRowsPrice0.HeaderText = "cena";
            this.dgcRowsPrice0.MinimumWidth = 8;
            this.dgcRowsPrice0.Name = "dgcRowsPrice0";
            this.dgcRowsPrice0.Width = 90;
            // 
            // dgcRowsDiscount
            // 
            this.dgcRowsDiscount.DataPropertyName = "DISCOUNT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcRowsDiscount.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcRowsDiscount.HeaderText = "atlaide";
            this.dgcRowsDiscount.MinimumWidth = 8;
            this.dgcRowsDiscount.Name = "dgcRowsDiscount";
            this.dgcRowsDiscount.Width = 60;
            // 
            // dgcRowsPrice
            // 
            this.dgcRowsPrice.DataPropertyName = "PRICE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N4";
            this.dgcRowsPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcRowsPrice.HeaderText = "cena ar atl.";
            this.dgcRowsPrice.MinimumWidth = 8;
            this.dgcRowsPrice.Name = "dgcRowsPrice";
            this.dgcRowsPrice.ReadOnly = true;
            this.dgcRowsPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcRowsPrice.Width = 95;
            // 
            // dgcRowsTPrice
            // 
            this.dgcRowsTPrice.DataPropertyName = "TPRICE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.dgcRowsTPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcRowsTPrice.HeaderText = "summa";
            this.dgcRowsTPrice.MinimumWidth = 8;
            this.dgcRowsTPrice.Name = "dgcRowsTPrice";
            this.dgcRowsTPrice.ReadOnly = true;
            this.dgcRowsTPrice.Width = 90;
            // 
            // dgcRowsIdPVNRate
            // 
            this.dgcRowsIdPVNRate.DataPropertyName = "IDPVNRATE";
            this.dgcRowsIdPVNRate.HeaderText = "PVN likne";
            this.dgcRowsIdPVNRate.MinimumWidth = 8;
            this.dgcRowsIdPVNRate.Name = "dgcRowsIdPVNRate";
            this.dgcRowsIdPVNRate.ReadOnly = true;
            this.dgcRowsIdPVNRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcRowsIdPVNRate.Width = 90;
            // 
            // dgcRowsBuyPrice
            // 
            this.dgcRowsBuyPrice.DataPropertyName = "BUYPRICE";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N4";
            this.dgcRowsBuyPrice.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcRowsBuyPrice.HeaderText = "izmaksas";
            this.dgcRowsBuyPrice.MinimumWidth = 8;
            this.dgcRowsBuyPrice.Name = "dgcRowsBuyPrice";
            this.dgcRowsBuyPrice.ReadOnly = true;
            this.dgcRowsBuyPrice.Width = 110;
            // 
            // dgcRowTBuyPrice
            // 
            this.dgcRowTBuyPrice.DataPropertyName = "TBUYPRICE";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.dgcRowTBuyPrice.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcRowTBuyPrice.HeaderText = "summa";
            this.dgcRowTBuyPrice.MinimumWidth = 8;
            this.dgcRowTBuyPrice.Name = "dgcRowTBuyPrice";
            this.dgcRowTBuyPrice.ReadOnly = true;
            this.dgcRowTBuyPrice.Width = 90;
            // 
            // dgcRowsId
            // 
            this.dgcRowsId.DataPropertyName = "ID";
            this.dgcRowsId.HeaderText = "ID";
            this.dgcRowsId.MinimumWidth = 8;
            this.dgcRowsId.Name = "dgcRowsId";
            this.dgcRowsId.Width = 60;
            // 
            // dgcRowsIdDoc
            // 
            this.dgcRowsIdDoc.DataPropertyName = "IDDOC";
            this.dgcRowsIdDoc.HeaderText = "IDDOC";
            this.dgcRowsIdDoc.MinimumWidth = 8;
            this.dgcRowsIdDoc.Name = "dgcRowsIdDoc";
            this.dgcRowsIdDoc.Width = 60;
            // 
            // dgcRowsIdSeq
            // 
            this.dgcRowsIdSeq.DataPropertyName = "IDSEQ";
            this.dgcRowsIdSeq.HeaderText = "IDSEQ";
            this.dgcRowsIdSeq.MinimumWidth = 8;
            this.dgcRowsIdSeq.Name = "dgcRowsIdSeq";
            this.dgcRowsIdSeq.Visible = false;
            this.dgcRowsIdSeq.Width = 80;
            // 
            // bsRows
            // 
            this.bsRows.DataMember = "FK_M_ROWS_IDDOC";
            this.bsRows.DataSource = this.bsDocs;
            this.bsRows.Sort = "IDSEQ";
            this.bsRows.UseDataGridView = this.dgvRows;
            this.bsRows.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsRows_ListChanged);
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
        "M_ITEMS_PER_STORE",
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
            // bNav
            // 
            this.bNav.AddNewItem = null;
            this.bNav.BindingSource = this.bsRows;
            this.bNav.CountItem = this.bindingNavigatorCountItem;
            this.bNav.CountItemFormat = " no {0}";
            this.bNav.DataGrid = this.dgvRows;
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
            this.bNav.Location = new System.Drawing.Point(0, 475);
            this.bNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bNav.Name = "bNav";
            this.bNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bNav.SaveItem = this.bniSave;
            this.bNav.Size = new System.Drawing.Size(1078, 39);
            this.bNav.TabIndex = 3;
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
            // FormM_Doc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 514);
            this.Controls.Add(this.mySplitContainer1);
            this.Controls.Add(this.bNav);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormM_Doc";
            this.Text = "Dokumenti";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormM_Doc_FormClosed);
            this.Load += new System.EventHandler(this.FormM_Doc_Load);
            this.mySplitContainer1.Panel1.ResumeLayout(false);
            this.mySplitContainer1.Panel1.PerformLayout();
            this.mySplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mySplitContainer1)).EndInit();
            this.mySplitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStoreOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStoreIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCarrier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPayType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPVNType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).EndInit();
            this.bNav.ResumeLayout(false);
            this.bNav.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private KlonsLIB.Components.MySplitContainer mySplitContainer1;
        private KlonsLIB.Data.MyBindingSource bsDocs;
        private KlonsLIB.Data.MyBindingSource2 bsRows;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private KlonsLIB.Data.MyBindingSource bsDocType;
        private KlonsLIB.Data.MyBindingSource bsPVNType;
        private KlonsLIB.Data.MyBindingSource bsStoreOut;
        private KlonsLIB.Data.MyBindingSource bsStoreIn;
        private KlonsLIB.Data.MyBindingSource bsItems;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private KlonsLIB.Data.MyBindingSource bsUnits;
        private MyConfigA myConfigA1;
        private KlonsLIB.MySourceGrid.MyGrid sgrDocA;
        private DataObjectsFM.DocData docData1;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDocDT;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDocSR;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDocNR;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocStoreOut;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocStoreIn;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDocState;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grDocTitleDokuments;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grDocTitleKrajumi;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowCommand grDocCMCol2;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grDocTitleCredDoc;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA gdDocCdDT;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDocCdSr;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDocCdNr;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grDocTitleTransoirt;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocAddressOut;
        private KlonsLIB.Data.MyBindingSource bsCarrier;
        private KlonsLIB.Data.MyBindingSource bsAddress;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocAddressIn;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocCarrier;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocDriver;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocVehicle;
        private KlonsLIB.Data.MyBindingSource bsTransType;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowCommand grDocCMCol3;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB grDocPayType;
        private KlonsLIB.Data.MyBindingSource bsPayType;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grDocTitlePay;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDocDueDate;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grDocTitleFinances;
        private KlonsLIB.Data.MyBindingSource bsAccounts;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocPVNType;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocAccIn;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocAccOut;
        private KlonsLIB.Data.MyBindingSource bsDriver;
        private KlonsLIB.Data.MyBindingSource bsVehicle;
        private KlonsLIB.Components.MyBindingNavigator bNav;
        private System.Windows.Forms.ToolStripButton bniNew;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bniDelete;
        private System.Windows.Forms.ToolStripButton bniSave;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDocSum;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dokumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dzēstDokumentuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem iegrāmatotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atvērtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iegrāmatotVeidotPilnuPārrēķinuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izveidotKredītrēķinuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prečuAtgriešanaCenasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prečuAtgriešanaIzveidotKredītrēķinusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kontējumsToolStripMenuItem;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcRowsIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsPrice0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsTPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsIdPVNRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowTBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsIdDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowsIdSeq;
        private System.Windows.Forms.ToolStripMenuItem izdrukaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pavadzīmeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbFindPrev;
        private System.Windows.Forms.ToolStripTextBox tsbFind;
        private System.Windows.Forms.ToolStripButton tsbFindNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem atvērtRediģēšanaiVeicotPilnuPārrēķinuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocTP;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox grDocManualFinOps;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox grDocIncludeInCostCalc;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grDocTransType;
        private System.Windows.Forms.ToolStripMenuItem kopētDokumentuToolStripMenuItem;
    }
}