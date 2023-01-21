using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsFM.Forms
{
    partial class Form_BilancesFormula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BilancesFormula));
            KlonsLIB.Components.MyMcComboBox.MyItem myItem3 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem4 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            this.bsBalA1 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsBalA2 = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.bsBalA3 = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.bnavBalsA1 = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tslbActiveTable = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.kopētAtskaitesFormuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainītAtskaitesKoduToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pārbaudītFormulasBilanceiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pārbaudītFormulasPZAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvBalA1 = new KlonsLIB.Components.MyDataGridView();
            this.dgcBalA1balid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA1TA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA1TP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBalA2 = new KlonsLIB.Components.MyDataGridView();
            this.dgcBalA2id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA2nr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA2balid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA2dc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA2tp = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcBalA2Descr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA2nr1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA2nr2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA2S1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA2S2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBalA3 = new KlonsLIB.Components.MyDataGridView();
            this.dgcBalA3tp = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcBalA3ac = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.bsAC = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcBalA3id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA3id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.cbReportPart = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRowTo = new KlonsLIB.Components.MyTextBox();
            this.tbRowFrom = new KlonsLIB.Components.MyTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tbKNr = new KlonsLIB.Components.MyTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsBalA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBalA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBalA3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavBalsA1)).BeginInit();
            this.bnavBalsA1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalA3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsBalA1
            // 
            this.bsBalA1.AutoSaveChildrenDelete = true;
            this.bsBalA1.AutoSaveOnDelete = true;
            this.bsBalA1.ChildBS = this.bsBalA2;
            this.bsBalA1.DataMember = "BalA1";
            this.bsBalA1.MyDataSource = "KlonsData";
            this.bsBalA1.Name2 = "bsBalA1";
            this.bsBalA1.Sort = "balid";
            this.bsBalA1.MyItemRemoved += new KlonsLIB.Data.ItemRmoveEventHandler(this.bsBalA1_MyItemRemoved);
            this.bsBalA1.CurrentChanged += new System.EventHandler(this.bsBalA1_CurrentChanged);
            this.bsBalA1.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsBalA1_ListChanged);
            // 
            // bsBalA2
            // 
            this.bsBalA2.AutoSaveChildrenDelete = true;
            this.bsBalA2.AutoSaveOnDelete = true;
            this.bsBalA2.ChildBS = this.bsBalA3;
            this.bsBalA2.DataMember = "FK_BALA2_BALID_BALA1_BALID";
            this.bsBalA2.DataSource = this.bsBalA1;
            this.bsBalA2.Name2 = "bsBalA2";
            this.bsBalA2.Sort = "nr";
            this.bsBalA2.MyBeforeRowInsert += new KlonsLIB.Data.MyRowUpdateEventHandler(this.bsBalA2_MyBeforeRowInsert);
            this.bsBalA2.CurrentChanged += new System.EventHandler(this.bsBalA2_CurrentChanged);
            this.bsBalA2.CurrentItemChanged += new System.EventHandler(this.bsBalA2_CurrentItemChanged);
            this.bsBalA2.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsBalA2_ListChanged);
            // 
            // bsBalA3
            // 
            this.bsBalA3.DataMember = "FK_BALA3_ID2_BALA2_ID";
            this.bsBalA3.DataSource = this.bsBalA2;
            this.bsBalA3.Name2 = "bsBalA3";
            this.bsBalA3.Sort = "ac";
            this.bsBalA3.MyBeforeRowInsert += new KlonsLIB.Data.MyRowUpdateEventHandler(this.bsBalA3_MyBeforeRowInsert);
            this.bsBalA3.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsBalA3_ListChanged);
            // 
            // bnavBalsA1
            // 
            this.bnavBalsA1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavBalsA1.BindingSource = this.bsBalA1;
            this.bnavBalsA1.CountItem = this.bindingNavigatorCountItem;
            this.bnavBalsA1.CountItemFormat = " no {0}";
            this.bnavBalsA1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnavBalsA1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavBalsA1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavBalsA1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbActiveTable,
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.tsbSave,
            this.toolStripButton1,
            this.toolStripDropDownButton1});
            this.bnavBalsA1.Location = new System.Drawing.Point(0, 368);
            this.bnavBalsA1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavBalsA1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavBalsA1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavBalsA1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavBalsA1.Name = "bnavBalsA1";
            this.bnavBalsA1.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavBalsA1.Size = new System.Drawing.Size(606, 32);
            this.bnavBalsA1.TabIndex = 11;
            this.bnavBalsA1.Text = "bindingNavigator1";
            this.bnavBalsA1.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavBalsA1_ItemDeleting);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(91, 29);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            this.bindingNavigatorAddNewItem.ToolTipText = "Pievienot ierakstu";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(69, 29);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(87, 29);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
            // 
            // tslbActiveTable
            // 
            this.tslbActiveTable.Name = "tslbActiveTable";
            this.tslbActiveTable.Size = new System.Drawing.Size(98, 29);
            this.tslbActiveTable.Text = "Atskaites:";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMoveFirstItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMovePreviousItem.Text = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 32);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(41, 30);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Pašreizējā pozīcija";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMoveNextItem.Text = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(25, 29);
            this.tsbSave.Text = "Saglabāt";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::KlonsFM.Properties.Resources.information1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(25, 29);
            this.toolStripButton1.Text = "Info";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kopētAtskaitesFormuToolStripMenuItem,
            this.mainītAtskaitesKoduToolStripMenuItem,
            this.pārbaudītFormulasBilanceiToolStripMenuItem,
            this.pārbaudītFormulasPZAToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(102, 29);
            this.toolStripDropDownButton1.Text = "Ko darīt!";
            // 
            // kopētAtskaitesFormuToolStripMenuItem
            // 
            this.kopētAtskaitesFormuToolStripMenuItem.Name = "kopētAtskaitesFormuToolStripMenuItem";
            this.kopētAtskaitesFormuToolStripMenuItem.Size = new System.Drawing.Size(325, 30);
            this.kopētAtskaitesFormuToolStripMenuItem.Text = "Kopēt atskaites formu";
            this.kopētAtskaitesFormuToolStripMenuItem.Click += new System.EventHandler(this.kopētAtskaitesFormuToolStripMenuItem_Click);
            // 
            // mainītAtskaitesKoduToolStripMenuItem
            // 
            this.mainītAtskaitesKoduToolStripMenuItem.Name = "mainītAtskaitesKoduToolStripMenuItem";
            this.mainītAtskaitesKoduToolStripMenuItem.Size = new System.Drawing.Size(325, 30);
            this.mainītAtskaitesKoduToolStripMenuItem.Text = "Mainīt atskaites kodu";
            this.mainītAtskaitesKoduToolStripMenuItem.Click += new System.EventHandler(this.mainītAtskaitesKoduToolStripMenuItem_Click);
            // 
            // pārbaudītFormulasBilanceiToolStripMenuItem
            // 
            this.pārbaudītFormulasBilanceiToolStripMenuItem.Name = "pārbaudītFormulasBilanceiToolStripMenuItem";
            this.pārbaudītFormulasBilanceiToolStripMenuItem.Size = new System.Drawing.Size(325, 30);
            this.pārbaudītFormulasBilanceiToolStripMenuItem.Text = "Pārbaudīt formulas bilancei";
            this.pārbaudītFormulasBilanceiToolStripMenuItem.Click += new System.EventHandler(this.pārbaudītFormulasBilanceiToolStripMenuItem_Click);
            // 
            // pārbaudītFormulasPZAToolStripMenuItem
            // 
            this.pārbaudītFormulasPZAToolStripMenuItem.Name = "pārbaudītFormulasPZAToolStripMenuItem";
            this.pārbaudītFormulasPZAToolStripMenuItem.Size = new System.Drawing.Size(325, 30);
            this.pārbaudītFormulasPZAToolStripMenuItem.Text = "Pārbaudīt formulas PZA";
            this.pārbaudītFormulasPZAToolStripMenuItem.Click += new System.EventHandler(this.pārbaudītFormulasPZAToolStripMenuItem_Click);
            // 
            // dgvBalA1
            // 
            this.dgvBalA1.AutoGenerateColumns = false;
            this.dgvBalA1.AutoSave = false;
            this.dgvBalA1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBalA1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBalA1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcBalA1balid,
            this.dataGridViewTextBoxColumn2,
            this.dgcBalA1TA,
            this.dgcBalA1TP});
            this.dgvBalA1.DataSource = this.bsBalA1;
            this.dgvBalA1.Location = new System.Drawing.Point(0, 0);
            this.dgvBalA1.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBalA1.Name = "dgvBalA1";
            this.dgvBalA1.RowTemplate.Height = 19;
            this.dgvBalA1.Size = new System.Drawing.Size(601, 140);
            this.dgvBalA1.TabIndex = 0;
            this.dgvBalA1.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBalA1_MyKeyDown);
            this.dgvBalA1.CurrentCellChanged += new System.EventHandler(this.dgvBalA1_CurrentCellChanged);
            this.dgvBalA1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvBalA1_UserDeletingRow);
            this.dgvBalA1.Enter += new System.EventHandler(this.dgvBalA1_Enter);
            this.dgvBalA1.Leave += new System.EventHandler(this.dgvBalA1_Leave);
            // 
            // dgcBalA1balid
            // 
            this.dgcBalA1balid.DataPropertyName = "balid";
            this.dgcBalA1balid.HeaderText = "kods";
            this.dgcBalA1balid.Name = "dgcBalA1balid";
            this.dgcBalA1balid.ToolTipText = "Atskaites kods (B1, PZA1, utml.)";
            this.dgcBalA1balid.Width = 64;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Descr";
            this.dataGridViewTextBoxColumn2.HeaderText = "apraksts";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ToolTipText = "Apraksts";
            this.dataGridViewTextBoxColumn2.Width = 240;
            // 
            // dgcBalA1TA
            // 
            this.dgcBalA1TA.DataPropertyName = "TA";
            this.dgcBalA1TA.HeaderText = "nosaukums1";
            this.dgcBalA1TA.Name = "dgcBalA1TA";
            this.dgcBalA1TA.ToolTipText = "Nosaukums atskaites aktīva pusei";
            this.dgcBalA1TA.Width = 112;
            // 
            // dgcBalA1TP
            // 
            this.dgcBalA1TP.DataPropertyName = "TP";
            this.dgcBalA1TP.HeaderText = "nosaukums2";
            this.dgcBalA1TP.Name = "dgcBalA1TP";
            this.dgcBalA1TP.ToolTipText = "Nosaukums atskaites pasīva pusei";
            this.dgcBalA1TP.Width = 112;
            // 
            // dgvBalA2
            // 
            this.dgvBalA2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBalA2.AutoGenerateColumns = false;
            this.dgvBalA2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBalA2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBalA2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcBalA2id,
            this.dgcBalA2nr,
            this.dgcBalA2balid,
            this.dgcBalA2dc,
            this.dgcBalA2tp,
            this.dgcBalA2Descr,
            this.dgcBalA2nr1,
            this.dgcBalA2nr2,
            this.dgcBalA2S1,
            this.dgcBalA2S2});
            this.dgvBalA2.DataSource = this.bsBalA2;
            this.dgvBalA2.Location = new System.Drawing.Point(0, 170);
            this.dgvBalA2.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBalA2.Name = "dgvBalA2";
            this.dgvBalA2.RowTemplate.Height = 19;
            this.dgvBalA2.Size = new System.Drawing.Size(420, 203);
            this.dgvBalA2.TabIndex = 1;
            this.dgvBalA2.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBalA1_MyKeyDown);
            this.dgvBalA2.CurrentCellChanged += new System.EventHandler(this.dgvBalA2_CurrentCellChanged);
            this.dgvBalA2.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvBalA2_DefaultValuesNeeded);
            this.dgvBalA2.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvBalA1_UserDeletingRow);
            this.dgvBalA2.Enter += new System.EventHandler(this.dgvBalA2_Enter);
            this.dgvBalA2.Leave += new System.EventHandler(this.dgvBalA2_Leave);
            // 
            // dgcBalA2id
            // 
            this.dgcBalA2id.DataPropertyName = "id";
            this.dgcBalA2id.HeaderText = "id";
            this.dgcBalA2id.Name = "dgcBalA2id";
            this.dgcBalA2id.ReadOnly = true;
            this.dgcBalA2id.Visible = false;
            this.dgcBalA2id.Width = 40;
            // 
            // dgcBalA2nr
            // 
            this.dgcBalA2nr.DataPropertyName = "nr";
            this.dgcBalA2nr.HeaderText = "nr.";
            this.dgcBalA2nr.Name = "dgcBalA2nr";
            this.dgcBalA2nr.ToolTipText = "Rindas numurs";
            this.dgcBalA2nr.Width = 48;
            // 
            // dgcBalA2balid
            // 
            this.dgcBalA2balid.DataPropertyName = "balid";
            this.dgcBalA2balid.HeaderText = "balid";
            this.dgcBalA2balid.Name = "dgcBalA2balid";
            this.dgcBalA2balid.Visible = false;
            this.dgcBalA2balid.Width = 64;
            // 
            // dgcBalA2dc
            // 
            this.dgcBalA2dc.DataPropertyName = "dc";
            this.dgcBalA2dc.HeaderText = "dc";
            this.dgcBalA2dc.Name = "dgcBalA2dc";
            this.dgcBalA2dc.Visible = false;
            this.dgcBalA2dc.Width = 64;
            // 
            // dgcBalA2tp
            // 
            this.dgcBalA2tp.ColumnNames = new string[] {
        "col1",
        "col2"};
            this.dgcBalA2tp.ColumnWidths = "50;100";
            this.dgcBalA2tp.DataPropertyName = "tp";
            this.dgcBalA2tp.DisplayMember = "col1";
            this.dgcBalA2tp.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.dgcBalA2tp.HeaderText = "veids";
            this.dgcBalA2tp.ItemStrings = new string[] {
        "V;Virsraksts",
        "S;Kontu summējums",
        "K;Rindu summa"};
            this.dgcBalA2tp.MaxDropDownItems = 15;
            this.dgcBalA2tp.Name = "dgcBalA2tp";
            this.dgcBalA2tp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcBalA2tp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcBalA2tp.ToolTipText = "Rindas veids";
            this.dgcBalA2tp.ValueMember = "col1";
            this.dgcBalA2tp.Width = 48;
            // 
            // dgcBalA2Descr
            // 
            this.dgcBalA2Descr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgcBalA2Descr.DataPropertyName = "Descr";
            this.dgcBalA2Descr.HeaderText = "apraksts";
            this.dgcBalA2Descr.Name = "dgcBalA2Descr";
            this.dgcBalA2Descr.Width = 92;
            // 
            // dgcBalA2nr1
            // 
            this.dgcBalA2nr1.DataPropertyName = "nr1";
            this.dgcBalA2nr1.HeaderText = "nr1";
            this.dgcBalA2nr1.Name = "dgcBalA2nr1";
            this.dgcBalA2nr1.Visible = false;
            this.dgcBalA2nr1.Width = 40;
            // 
            // dgcBalA2nr2
            // 
            this.dgcBalA2nr2.DataPropertyName = "nr2";
            this.dgcBalA2nr2.HeaderText = "nr2";
            this.dgcBalA2nr2.Name = "dgcBalA2nr2";
            this.dgcBalA2nr2.Visible = false;
            this.dgcBalA2nr2.Width = 40;
            // 
            // dgcBalA2S1
            // 
            this.dgcBalA2S1.DataPropertyName = "S1";
            this.dgcBalA2S1.HeaderText = "S1";
            this.dgcBalA2S1.Name = "dgcBalA2S1";
            this.dgcBalA2S1.Visible = false;
            this.dgcBalA2S1.Width = 80;
            // 
            // dgcBalA2S2
            // 
            this.dgcBalA2S2.DataPropertyName = "S2";
            this.dgcBalA2S2.HeaderText = "S2";
            this.dgcBalA2S2.Name = "dgcBalA2S2";
            this.dgcBalA2S2.Visible = false;
            this.dgcBalA2S2.Width = 80;
            // 
            // dgvBalA3
            // 
            this.dgvBalA3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBalA3.AutoGenerateColumns = false;
            this.dgvBalA3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBalA3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBalA3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcBalA3tp,
            this.dgcBalA3ac,
            this.dgcBalA3id,
            this.dgcBalA3id2});
            this.dgvBalA3.DataSource = this.bsBalA3;
            this.dgvBalA3.Location = new System.Drawing.Point(425, 170);
            this.dgvBalA3.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBalA3.Name = "dgvBalA3";
            this.dgvBalA3.RowTemplate.Height = 19;
            this.dgvBalA3.Size = new System.Drawing.Size(176, 202);
            this.dgvBalA3.TabIndex = 2;
            this.dgvBalA3.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBalA1_MyKeyDown);
            this.dgvBalA3.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvBalA3_DefaultValuesNeeded);
            this.dgvBalA3.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvBalA1_UserDeletingRow);
            this.dgvBalA3.Enter += new System.EventHandler(this.dgvBalA3_Enter);
            // 
            // dgcBalA3tp
            // 
            this.dgcBalA3tp.ColumnNames = new string[] {
        "col1",
        "col2"};
            this.dgcBalA3tp.ColumnWidths = "50;100";
            this.dgcBalA3tp.DataPropertyName = "tp";
            this.dgcBalA3tp.DisplayMember = "col1";
            this.dgcBalA3tp.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.dgcBalA3tp.HeaderText = "veids";
            this.dgcBalA3tp.ItemStrings = new string[] {
        "Db;Debetā",
        "Kr;Kredītā"};
            this.dgcBalA3tp.MaxDropDownItems = 15;
            this.dgcBalA3tp.Name = "dgcBalA3tp";
            this.dgcBalA3tp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcBalA3tp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcBalA3tp.ValueMember = "col1";
            this.dgcBalA3tp.Width = 48;
            // 
            // dgcBalA3ac
            // 
            this.dgcBalA3ac.ColumnNames = new string[] {
        "ac",
        "name"};
            this.dgcBalA3ac.ColumnWidths = "80;200";
            this.dgcBalA3ac.DataPropertyName = "ac";
            this.dgcBalA3ac.DataSource = this.bsAC;
            this.dgcBalA3ac.DisplayMember = "AC";
            this.dgcBalA3ac.HeaderText = "konts";
            this.dgcBalA3ac.LimitToList = false;
            this.dgcBalA3ac.MaxDropDownItems = 15;
            this.dgcBalA3ac.Name = "dgcBalA3ac";
            this.dgcBalA3ac.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcBalA3ac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcBalA3ac.ValueMember = "AC";
            this.dgcBalA3ac.Width = 64;
            // 
            // bsAC
            // 
            this.bsAC.DataMember = "AcP21";
            this.bsAC.MyDataSource = "KlonsData";
            this.bsAC.Name2 = null;
            this.bsAC.Sort = "AC";
            // 
            // dgcBalA3id
            // 
            this.dgcBalA3id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgcBalA3id.DataPropertyName = "id";
            this.dgcBalA3id.HeaderText = "id";
            this.dgcBalA3id.Name = "dgcBalA3id";
            this.dgcBalA3id.ReadOnly = true;
            this.dgcBalA3id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgcBalA3id.Visible = false;
            this.dgcBalA3id.Width = 40;
            // 
            // dgcBalA3id2
            // 
            this.dgcBalA3id2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgcBalA3id2.DataPropertyName = "id2";
            this.dgcBalA3id2.HeaderText = "id2";
            this.dgcBalA3id2.Name = "dgcBalA3id2";
            this.dgcBalA3id2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgcBalA3id2.Visible = false;
            this.dgcBalA3id2.Width = 40;
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "BalA1",
        "BalA2",
        "BalA3",
        null};
            // 
            // cbReportPart
            // 
            this.cbReportPart.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbReportPart.ColumnNames = new string[] {
        "col1"};
            this.cbReportPart.ColumnWidths = "150";
            this.cbReportPart.DisplayMember = "col1";
            this.cbReportPart.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbReportPart.DropDownHeight = 136;
            this.cbReportPart.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbReportPart.DropDownWidth = 174;
            this.cbReportPart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbReportPart.FormattingEnabled = true;
            this.cbReportPart.GridLineColor = System.Drawing.Color.LightGray;
            this.cbReportPart.GridLineHorizontal = false;
            this.cbReportPart.GridLineVertical = false;
            this.cbReportPart.IntegralHeight = false;
            myItem3.Col1 = "Aktīvs";
            myItem4.Col1 = "Pasīvs";
            this.cbReportPart.Items.AddRange(new object[] {
            myItem3,
            myItem4});
            this.cbReportPart.ItemStrings = new string[] {
        "Aktīvs",
        "Pasīvs"};
            this.cbReportPart.Location = new System.Drawing.Point(118, 145);
            this.cbReportPart.Margin = new System.Windows.Forms.Padding(2);
            this.cbReportPart.Name = "cbReportPart";
            this.cbReportPart.Size = new System.Drawing.Size(121, 23);
            this.cbReportPart.TabIndex = 7;
            this.cbReportPart.ValueMember = "col1";
            this.cbReportPart.SelectedIndexChanged += new System.EventHandler(this.cbReportPart_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 147);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Atskaites sadaļa:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbRowTo);
            this.panel1.Controls.Add(this.tbRowFrom);
            this.panel1.Location = new System.Drawing.Point(433, 198);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 82);
            this.panel1.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "līdz:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "no:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Summēt rindas:";
            // 
            // tbRowTo
            // 
            this.tbRowTo.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRowTo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBalA2, "nr2", true));
            this.tbRowTo.Location = new System.Drawing.Point(44, 56);
            this.tbRowTo.Margin = new System.Windows.Forms.Padding(2);
            this.tbRowTo.Name = "tbRowTo";
            this.tbRowTo.Size = new System.Drawing.Size(67, 22);
            this.tbRowTo.TabIndex = 4;
            // 
            // tbRowFrom
            // 
            this.tbRowFrom.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRowFrom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBalA2, "nr1", true));
            this.tbRowFrom.Location = new System.Drawing.Point(44, 27);
            this.tbRowFrom.Margin = new System.Windows.Forms.Padding(2);
            this.tbRowFrom.Name = "tbRowFrom";
            this.tbRowFrom.Size = new System.Drawing.Size(67, 22);
            this.tbRowFrom.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tbKNr);
            this.panel2.Location = new System.Drawing.Point(425, 58);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 94);
            this.panel2.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 54);
            this.label7.TabIndex = 0;
            this.label7.Text = "Kopsummas rinda, kas saistīta ar virsrakstu:";
            // 
            // tbKNr
            // 
            this.tbKNr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbKNr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBalA2, "nr1", true));
            this.tbKNr.Location = new System.Drawing.Point(78, 64);
            this.tbKNr.Margin = new System.Windows.Forms.Padding(2);
            this.tbKNr.Name = "tbKNr";
            this.tbKNr.Size = new System.Drawing.Size(67, 22);
            this.tbKNr.TabIndex = 4;
            // 
            // Form_BilancesFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(606, 400);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbReportPart);
            this.Controls.Add(this.dgvBalA3);
            this.Controls.Add(this.dgvBalA2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvBalA1);
            this.Controls.Add(this.bnavBalsA1);
            this.MinimumSize = new System.Drawing.Size(8, 416);
            this.Name = "Form_BilancesFormula";
            this.Text = "Bilances atskaišu formulas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Bilance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBalA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBalA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBalA3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavBalsA1)).EndInit();
            this.bnavBalsA1.ResumeLayout(false);
            this.bnavBalsA1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalA3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingSource bsBalA1;
        private MyBindingNavigator bnavBalsA1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private MyDataGridView dgvBalA1;
        private MyDataGridView dgvBalA2;
        private MyBindingSource2 bsBalA2;
        private MyBindingSource2 bsBalA3;
        private MyDataGridView dgvBalA3;
        private MyAdapterManager myAdapterManager1;
        private MyMcFlatComboBox cbReportPart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel tslbActiveTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private MyTextBox tbRowTo;
        private MyTextBox tbRowFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA1balid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA1TA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA1TP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private MyBindingSource bsAC;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem mainītAtskaitesKoduToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pārbaudītFormulasPZAToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private MyTextBox tbKNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA2id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA2nr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA2balid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA2dc;
        private MyDgvMcCBColumn dgcBalA2tp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA2Descr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA2nr1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA2nr2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA2S1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA2S2;
        private System.Windows.Forms.ToolStripMenuItem kopētAtskaitesFormuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pārbaudītFormulasBilanceiToolStripMenuItem;
        private MyDgvMcCBColumn dgcBalA3tp;
        private MyDgvMcCBColumn dgcBalA3ac;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA3id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA3id2;
    }
}