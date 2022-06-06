
namespace KlonsA.Forms
{
    partial class Form_Persons_DN_lapas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Persons_DN_lapas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbPrevMonth = new System.Windows.Forms.ToolStripButton();
            this.tsbNextMonth = new System.Windows.Forms.ToolStripButton();
            this.cbPage = new KlonsLIB.Components.FlatComboBox();
            this.cmSaveChanges = new System.Windows.Forms.Button();
            this.cmLoadFromFile = new System.Windows.Forms.Button();
            this.tbDate2 = new KlonsLIB.Components.MyTextBox();
            this.tbDate1 = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bsChanges = new System.Windows.Forms.BindingSource(this.components);
            this.bNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.tslActiveGrid = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tcPages = new KlonsLIB.Components.TabControlWithoutHeader();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvChanges = new KlonsLIB.Components.MyDataGridView();
            this.dgcChangesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcChangesPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcChangesDt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcChangesDbDT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcChangesDBVeids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcChangesEdsDt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcChangesEdsDt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcChangesVeids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcChangesAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvNoMatch = new KlonsLIB.Components.MyDataGridView();
            this.dgcBadName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBadPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBadDbDt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBadDbDt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBadDbVeids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBadEdsDt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBadEdsDt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBadEdsVeids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsNoMatch = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvFull = new KlonsLIB.Components.MyDataGridView();
            this.dgcFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcFullPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcFullDt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcFullDt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcFullVeids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcFullStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFullList = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsChanges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).BeginInit();
            this.bNav.SuspendLayout();
            this.tcPages.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanges)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNoMatch)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFullList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.cbPage);
            this.panel1.Controls.Add(this.cmSaveChanges);
            this.panel1.Controls.Add(this.cmLoadFromFile);
            this.panel1.Controls.Add(this.tbDate2);
            this.panel1.Controls.Add(this.tbDate1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 39);
            this.panel1.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrevMonth,
            this.tsbNextMonth});
            this.toolStrip1.Location = new System.Drawing.Point(599, 4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(72, 28);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbPrevMonth
            // 
            this.tsbPrevMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrevMonth.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrevMonth.Image")));
            this.tsbPrevMonth.Margin = new System.Windows.Forms.Padding(0);
            this.tsbPrevMonth.Name = "tsbPrevMonth";
            this.tsbPrevMonth.RightToLeftAutoMirrorImage = true;
            this.tsbPrevMonth.Size = new System.Drawing.Size(34, 28);
            this.tsbPrevMonth.Text = "iepriekšējais mēnesis";
            this.tsbPrevMonth.Click += new System.EventHandler(this.tsbPrevMonth_Click);
            // 
            // tsbNextMonth
            // 
            this.tsbNextMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNextMonth.Image = ((System.Drawing.Image)(resources.GetObject("tsbNextMonth.Image")));
            this.tsbNextMonth.Margin = new System.Windows.Forms.Padding(0);
            this.tsbNextMonth.Name = "tsbNextMonth";
            this.tsbNextMonth.RightToLeftAutoMirrorImage = true;
            this.tsbNextMonth.Size = new System.Drawing.Size(34, 28);
            this.tsbNextMonth.Text = "nākošais mēnesis";
            this.tsbNextMonth.ToolTipText = "Iet uz nākošo";
            this.tsbNextMonth.Click += new System.EventHandler(this.tsbNextMonth_Click);
            // 
            // cbPage
            // 
            this.cbPage.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPage.FormattingEnabled = true;
            this.cbPage.Items.AddRange(new object[] {
            "Izmaiņas",
            "Nesakritības",
            "Visas lapas"});
            this.cbPage.Location = new System.Drawing.Point(464, 5);
            this.cbPage.Name = "cbPage";
            this.cbPage.Size = new System.Drawing.Size(129, 28);
            this.cbPage.TabIndex = 4;
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.cbPage_SelectedIndexChanged);
            // 
            // cmSaveChanges
            // 
            this.cmSaveChanges.Location = new System.Drawing.Point(688, 2);
            this.cmSaveChanges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmSaveChanges.Name = "cmSaveChanges";
            this.cmSaveChanges.Size = new System.Drawing.Size(124, 32);
            this.cmSaveChanges.TabIndex = 3;
            this.cmSaveChanges.Text = "Iegrāmatot";
            this.cmSaveChanges.UseVisualStyleBackColor = true;
            this.cmSaveChanges.Click += new System.EventHandler(this.cmSaveChanges_Click);
            // 
            // cmLoadFromFile
            // 
            this.cmLoadFromFile.Location = new System.Drawing.Point(310, 2);
            this.cmLoadFromFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmLoadFromFile.Name = "cmLoadFromFile";
            this.cmLoadFromFile.Size = new System.Drawing.Size(134, 32);
            this.cmLoadFromFile.TabIndex = 3;
            this.cmLoadFromFile.Text = "Ielādēt no faila";
            this.cmLoadFromFile.UseVisualStyleBackColor = true;
            this.cmLoadFromFile.Click += new System.EventHandler(this.cmLoadFromFile_Click);
            // 
            // tbDate2
            // 
            this.tbDate2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate2.IsDate = true;
            this.tbDate2.Location = new System.Drawing.Point(190, 6);
            this.tbDate2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDate2.Name = "tbDate2";
            this.tbDate2.Size = new System.Drawing.Size(101, 26);
            this.tbDate2.TabIndex = 2;
            // 
            // tbDate1
            // 
            this.tbDate1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate1.IsDate = true;
            this.tbDate1.Location = new System.Drawing.Point(82, 6);
            this.tbDate1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDate1.Name = "tbDate1";
            this.tbDate1.Size = new System.Drawing.Size(101, 26);
            this.tbDate1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periods:";
            // 
            // bsChanges
            // 
            this.bsChanges.AllowNew = false;
            // 
            // bNav
            // 
            this.bNav.AddNewItem = null;
            this.bNav.BindingSource = this.bsChanges;
            this.bNav.CountItem = this.bindingNavigatorCountItem;
            this.bNav.CountItemFormat = " no {0}";
            this.bNav.DeleteItem = null;
            this.bNav.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bNav.ImageScalingSize = new System.Drawing.Size(23, 26);
            this.bNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslActiveGrid,
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorDeleteItem});
            this.bNav.Location = new System.Drawing.Point(0, 411);
            this.bNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bNav.Name = "bNav";
            this.bNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bNav.SaveItem = null;
            this.bNav.Size = new System.Drawing.Size(1157, 39);
            this.bNav.TabIndex = 6;
            this.bNav.Text = "myBindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 34);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // tslActiveGrid
            // 
            this.tslActiveGrid.Name = "tslActiveGrid";
            this.tslActiveGrid.Size = new System.Drawing.Size(23, 34);
            this.tslActiveGrid.Text = "..";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(56, 37);
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(93, 34);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // tcPages
            // 
            this.tcPages.Controls.Add(this.tabPage1);
            this.tcPages.Controls.Add(this.tabPage2);
            this.tcPages.Controls.Add(this.tabPage3);
            this.tcPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPages.Location = new System.Drawing.Point(0, 39);
            this.tcPages.Name = "tcPages";
            this.tcPages.SelectedIndex = 0;
            this.tcPages.Size = new System.Drawing.Size(1157, 372);
            this.tcPages.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvChanges);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1149, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Izmaiņas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvChanges
            // 
            this.dgvChanges.AllowUserToAddRows = false;
            this.dgvChanges.AutoGenerateColumns = false;
            this.dgvChanges.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChanges.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChanges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcChangesName,
            this.dgcChangesPK,
            this.dgcChangesDt1,
            this.dgcChangesDbDT2,
            this.dgcChangesDBVeids,
            this.dgcChangesEdsDt1,
            this.dgcChangesEdsDt2,
            this.dgcChangesVeids,
            this.dgcChangesAction});
            this.dgvChanges.DataSource = this.bsChanges;
            this.dgvChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChanges.Location = new System.Drawing.Point(3, 3);
            this.dgvChanges.Name = "dgvChanges";
            this.dgvChanges.RowHeadersWidth = 62;
            this.dgvChanges.RowTemplate.Height = 28;
            this.dgvChanges.ShowCellToolTips = false;
            this.dgvChanges.Size = new System.Drawing.Size(1143, 333);
            this.dgvChanges.TabIndex = 0;
            this.dgvChanges.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvChanges_CellParsing);
            this.dgvChanges.Enter += new System.EventHandler(this.dgvChanges_Enter);
            // 
            // dgcChangesName
            // 
            this.dgcChangesName.DataPropertyName = "Name";
            this.dgcChangesName.HeaderText = "darbinieks";
            this.dgcChangesName.MinimumWidth = 8;
            this.dgcChangesName.Name = "dgcChangesName";
            this.dgcChangesName.Width = 160;
            // 
            // dgcChangesPK
            // 
            this.dgcChangesPK.DataPropertyName = "PersonsCode";
            this.dgcChangesPK.HeaderText = "personas kods";
            this.dgcChangesPK.MinimumWidth = 8;
            this.dgcChangesPK.Name = "dgcChangesPK";
            this.dgcChangesPK.Width = 120;
            // 
            // dgcChangesDt1
            // 
            this.dgcChangesDt1.DataPropertyName = "DB_Dt1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "dd.MM.yyyy";
            this.dgcChangesDt1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcChangesDt1.HeaderText = "datums no";
            this.dgcChangesDt1.MinimumWidth = 8;
            this.dgcChangesDt1.Name = "dgcChangesDt1";
            this.dgcChangesDt1.Width = 90;
            // 
            // dgcChangesDbDT2
            // 
            this.dgcChangesDbDT2.DataPropertyName = "DB_Dt2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "dd.MM.yyyy";
            this.dgcChangesDbDT2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcChangesDbDT2.HeaderText = "datums līdz";
            this.dgcChangesDbDT2.MinimumWidth = 8;
            this.dgcChangesDbDT2.Name = "dgcChangesDbDT2";
            this.dgcChangesDbDT2.Width = 90;
            // 
            // dgcChangesDBVeids
            // 
            this.dgcChangesDBVeids.DataPropertyName = "DB_Veids";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcChangesDBVeids.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcChangesDBVeids.HeaderText = "veids";
            this.dgcChangesDBVeids.MinimumWidth = 8;
            this.dgcChangesDBVeids.Name = "dgcChangesDBVeids";
            this.dgcChangesDBVeids.Width = 60;
            // 
            // dgcChangesEdsDt1
            // 
            this.dgcChangesEdsDt1.DataPropertyName = "EDS_Dt1";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "dd.MM.yyyy";
            this.dgcChangesEdsDt1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcChangesEdsDt1.HeaderText = "EDS datums no";
            this.dgcChangesEdsDt1.MinimumWidth = 8;
            this.dgcChangesEdsDt1.Name = "dgcChangesEdsDt1";
            this.dgcChangesEdsDt1.Width = 90;
            // 
            // dgcChangesEdsDt2
            // 
            this.dgcChangesEdsDt2.DataPropertyName = "EDS_Dt2";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "dd.MM.yyyy";
            this.dgcChangesEdsDt2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcChangesEdsDt2.HeaderText = "EDS datums līdz";
            this.dgcChangesEdsDt2.MinimumWidth = 8;
            this.dgcChangesEdsDt2.Name = "dgcChangesEdsDt2";
            this.dgcChangesEdsDt2.Width = 95;
            // 
            // dgcChangesVeids
            // 
            this.dgcChangesVeids.DataPropertyName = "EDS_veids";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcChangesVeids.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcChangesVeids.HeaderText = "EDS veids";
            this.dgcChangesVeids.MinimumWidth = 8;
            this.dgcChangesVeids.Name = "dgcChangesVeids";
            this.dgcChangesVeids.Width = 60;
            // 
            // dgcChangesAction
            // 
            this.dgcChangesAction.DataPropertyName = "DNLapaImportTypeText";
            this.dgcChangesAction.HeaderText = "darbība";
            this.dgcChangesAction.MinimumWidth = 8;
            this.dgcChangesAction.Name = "dgcChangesAction";
            this.dgcChangesAction.Width = 160;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvNoMatch);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1149, 339);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nesakritības";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvNoMatch
            // 
            this.dgvNoMatch.AllowUserToAddRows = false;
            this.dgvNoMatch.AllowUserToDeleteRows = false;
            this.dgvNoMatch.AutoGenerateColumns = false;
            this.dgvNoMatch.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNoMatch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvNoMatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNoMatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcBadName,
            this.dgcBadPK,
            this.dgcBadDbDt1,
            this.dgcBadDbDt2,
            this.dgcBadDbVeids,
            this.dgcBadEdsDt1,
            this.dgcBadEdsDt2,
            this.dgcBadEdsVeids});
            this.dgvNoMatch.DataSource = this.bsNoMatch;
            this.dgvNoMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNoMatch.Location = new System.Drawing.Point(3, 3);
            this.dgvNoMatch.Name = "dgvNoMatch";
            this.dgvNoMatch.ReadOnly = true;
            this.dgvNoMatch.RowHeadersWidth = 62;
            this.dgvNoMatch.RowTemplate.Height = 28;
            this.dgvNoMatch.ShowCellToolTips = false;
            this.dgvNoMatch.Size = new System.Drawing.Size(1143, 333);
            this.dgvNoMatch.TabIndex = 0;
            this.dgvNoMatch.Enter += new System.EventHandler(this.dgvNoMatch_Enter);
            // 
            // dgcBadName
            // 
            this.dgcBadName.DataPropertyName = "Name";
            this.dgcBadName.HeaderText = "darbinieks";
            this.dgcBadName.MinimumWidth = 8;
            this.dgcBadName.Name = "dgcBadName";
            this.dgcBadName.ReadOnly = true;
            this.dgcBadName.Width = 160;
            // 
            // dgcBadPK
            // 
            this.dgcBadPK.DataPropertyName = "PersonsCode";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcBadPK.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcBadPK.HeaderText = "personas kods";
            this.dgcBadPK.MinimumWidth = 8;
            this.dgcBadPK.Name = "dgcBadPK";
            this.dgcBadPK.ReadOnly = true;
            this.dgcBadPK.Width = 120;
            // 
            // dgcBadDbDt1
            // 
            this.dgcBadDbDt1.DataPropertyName = "DB_Dt1";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "dd.MM.yyyy";
            this.dgcBadDbDt1.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgcBadDbDt1.HeaderText = "datums no";
            this.dgcBadDbDt1.MinimumWidth = 8;
            this.dgcBadDbDt1.Name = "dgcBadDbDt1";
            this.dgcBadDbDt1.ReadOnly = true;
            this.dgcBadDbDt1.Width = 90;
            // 
            // dgcBadDbDt2
            // 
            this.dgcBadDbDt2.DataPropertyName = "DB_Dt2";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "dd.MM.yyyy";
            this.dgcBadDbDt2.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgcBadDbDt2.HeaderText = "datums līdz";
            this.dgcBadDbDt2.MinimumWidth = 8;
            this.dgcBadDbDt2.Name = "dgcBadDbDt2";
            this.dgcBadDbDt2.ReadOnly = true;
            this.dgcBadDbDt2.Width = 90;
            // 
            // dgcBadDbVeids
            // 
            this.dgcBadDbVeids.DataPropertyName = "DB_Veids";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcBadDbVeids.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgcBadDbVeids.HeaderText = "veids";
            this.dgcBadDbVeids.MinimumWidth = 8;
            this.dgcBadDbVeids.Name = "dgcBadDbVeids";
            this.dgcBadDbVeids.ReadOnly = true;
            this.dgcBadDbVeids.Width = 60;
            // 
            // dgcBadEdsDt1
            // 
            this.dgcBadEdsDt1.DataPropertyName = "EDS_Dt1";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Format = "dd.MM.yyyy";
            this.dgcBadEdsDt1.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgcBadEdsDt1.HeaderText = "EDS datums līdz";
            this.dgcBadEdsDt1.MinimumWidth = 8;
            this.dgcBadEdsDt1.Name = "dgcBadEdsDt1";
            this.dgcBadEdsDt1.ReadOnly = true;
            this.dgcBadEdsDt1.Width = 95;
            // 
            // dgcBadEdsDt2
            // 
            this.dgcBadEdsDt2.DataPropertyName = "EDS_Dt2";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Format = "dd.MM.yyyy";
            this.dgcBadEdsDt2.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgcBadEdsDt2.HeaderText = "EDS datums līdz";
            this.dgcBadEdsDt2.MinimumWidth = 8;
            this.dgcBadEdsDt2.Name = "dgcBadEdsDt2";
            this.dgcBadEdsDt2.ReadOnly = true;
            this.dgcBadEdsDt2.Width = 95;
            // 
            // dgcBadEdsVeids
            // 
            this.dgcBadEdsVeids.DataPropertyName = "EDS_Veids";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcBadEdsVeids.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgcBadEdsVeids.HeaderText = "EDS veids";
            this.dgcBadEdsVeids.MinimumWidth = 8;
            this.dgcBadEdsVeids.Name = "dgcBadEdsVeids";
            this.dgcBadEdsVeids.ReadOnly = true;
            this.dgcBadEdsVeids.Width = 60;
            // 
            // bsNoMatch
            // 
            this.bsNoMatch.AllowNew = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvFull);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1149, 339);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Lapas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvFull
            // 
            this.dgvFull.AllowUserToAddRows = false;
            this.dgvFull.AllowUserToDeleteRows = false;
            this.dgvFull.AutoGenerateColumns = false;
            this.dgvFull.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFull.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvFull.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFull.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcFullName,
            this.dgcFullPK,
            this.dgcFullDt1,
            this.dgcFullDt2,
            this.dgcFullVeids,
            this.dgcFullStatus});
            this.dgvFull.DataSource = this.bsFullList;
            this.dgvFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFull.Location = new System.Drawing.Point(3, 3);
            this.dgvFull.Name = "dgvFull";
            this.dgvFull.ReadOnly = true;
            this.dgvFull.RowHeadersWidth = 62;
            this.dgvFull.RowTemplate.Height = 28;
            this.dgvFull.ShowCellToolTips = false;
            this.dgvFull.Size = new System.Drawing.Size(1143, 333);
            this.dgvFull.TabIndex = 0;
            this.dgvFull.Enter += new System.EventHandler(this.dgvFull_Enter);
            // 
            // dgcFullName
            // 
            this.dgcFullName.DataPropertyName = "Name";
            this.dgcFullName.HeaderText = "darbinieks";
            this.dgcFullName.MinimumWidth = 8;
            this.dgcFullName.Name = "dgcFullName";
            this.dgcFullName.ReadOnly = true;
            this.dgcFullName.Width = 160;
            // 
            // dgcFullPK
            // 
            this.dgcFullPK.DataPropertyName = "PersonsCode";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcFullPK.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgcFullPK.HeaderText = "personas kods";
            this.dgcFullPK.MinimumWidth = 8;
            this.dgcFullPK.Name = "dgcFullPK";
            this.dgcFullPK.ReadOnly = true;
            this.dgcFullPK.Width = 120;
            // 
            // dgcFullDt1
            // 
            this.dgcFullDt1.DataPropertyName = "EDS_Dt1";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.Format = "dd.MM.yyyy";
            this.dgcFullDt1.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgcFullDt1.HeaderText = "datums no";
            this.dgcFullDt1.MinimumWidth = 8;
            this.dgcFullDt1.Name = "dgcFullDt1";
            this.dgcFullDt1.ReadOnly = true;
            this.dgcFullDt1.Width = 90;
            // 
            // dgcFullDt2
            // 
            this.dgcFullDt2.DataPropertyName = "EDS_Dt2";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Format = "dd.MM.yyyy";
            this.dgcFullDt2.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgcFullDt2.HeaderText = "datums līdz";
            this.dgcFullDt2.MinimumWidth = 8;
            this.dgcFullDt2.Name = "dgcFullDt2";
            this.dgcFullDt2.ReadOnly = true;
            this.dgcFullDt2.Width = 90;
            // 
            // dgcFullVeids
            // 
            this.dgcFullVeids.DataPropertyName = "EDS_Veids";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcFullVeids.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgcFullVeids.HeaderText = "veids";
            this.dgcFullVeids.MinimumWidth = 8;
            this.dgcFullVeids.Name = "dgcFullVeids";
            this.dgcFullVeids.ReadOnly = true;
            this.dgcFullVeids.Width = 60;
            // 
            // dgcFullStatus
            // 
            this.dgcFullStatus.DataPropertyName = "EDS_Status";
            this.dgcFullStatus.HeaderText = "status";
            this.dgcFullStatus.MinimumWidth = 8;
            this.dgcFullStatus.Name = "dgcFullStatus";
            this.dgcFullStatus.ReadOnly = true;
            this.dgcFullStatus.Width = 80;
            // 
            // Form_Persons_DN_lapas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 450);
            this.Controls.Add(this.tcPages);
            this.Controls.Add(this.bNav);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Persons_DN_lapas";
            this.Text = "Darba nespējas lapas";
            this.Load += new System.EventHandler(this.Form_Persons_DN_lapas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsChanges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).EndInit();
            this.bNav.ResumeLayout(false);
            this.bNav.PerformLayout();
            this.tcPages.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanges)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNoMatch)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFullList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmLoadFromFile;
        private KlonsLIB.Components.MyTextBox tbDate2;
        private KlonsLIB.Components.MyTextBox tbDate1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsChanges;
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
        private KlonsLIB.Components.TabControlWithoutHeader tcPages;
        private System.Windows.Forms.TabPage tabPage1;
        private KlonsLIB.Components.MyDataGridView dgvChanges;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.BindingSource bsNoMatch;
        private KlonsLIB.Components.MyDataGridView dgvNoMatch;
        private System.Windows.Forms.ToolStripLabel tslActiveGrid;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private KlonsLIB.Components.FlatComboBox cbPage;
        private System.Windows.Forms.TabPage tabPage3;
        private KlonsLIB.Components.MyDataGridView dgvFull;
        private System.Windows.Forms.BindingSource bsFullList;
        private System.Windows.Forms.Button cmSaveChanges;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcChangesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcChangesPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcChangesDt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcChangesDbDT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcChangesDBVeids;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcChangesEdsDt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcChangesEdsDt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcChangesVeids;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcChangesAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBadName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBadPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBadDbDt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBadDbDt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBadDbVeids;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBadEdsDt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBadEdsDt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBadEdsVeids;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFullPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFullDt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFullDt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFullVeids;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFullStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbPrevMonth;
        private System.Windows.Forms.ToolStripButton tsbNextMonth;
    }
}