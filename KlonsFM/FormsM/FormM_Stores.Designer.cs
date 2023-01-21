
namespace KlonsFM.FormsM
{
    partial class FormM_Stores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormM_Stores));
            this.bsStores = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTP = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.bsStoreType = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcRegNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPVNRegNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPVNTp = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.bsPVNType = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcAcc21 = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.bsAccounts21 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcAcc23 = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.bsAccounts23 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcAcc53 = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.bsAccounts53 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.tsbFindPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbFind = new System.Windows.Forms.ToolStripTextBox();
            this.tsbFindNext = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbType = new KlonsLIB.Components.MyPickRowTextBox2();
            this.bsStoreTypeFilter = new KlonsLIB.Data.MyBindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFilter = new KlonsLIB.Components.MyTextBox();
            this.tbCode = new KlonsLIB.Components.MyPickRowTextBox2();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btAtlikumi = new System.Windows.Forms.ToolStripButton();
            this.btAddresses = new System.Windows.Forms.ToolStripButton();
            this.btContacts = new System.Windows.Forms.ToolStripButton();
            this.btBankAccounts = new System.Windows.Forms.ToolStripButton();
            this.btVehicles = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bsStores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStoreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPVNType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccounts21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccounts23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccounts53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).BeginInit();
            this.bNav.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsStoreTypeFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsStores
            // 
            this.bsStores.DataMember = "M_STORES";
            this.bsStores.MyDataSource = "KlonsMData";
            this.bsStores.Sort = "CODE";
            this.bsStores.UseDataGridView = this.dgvRows;
            this.bsStores.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsStores_ListChanged);
            // 
            // dgvRows
            // 
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.AutoSave = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcCode,
            this.dgcName,
            this.dgcTP,
            this.dgcRegNr,
            this.dgcPVNRegNr,
            this.dgcAddr,
            this.dgcPVNTp,
            this.dgcAcc21,
            this.dgcAcc23,
            this.dgcAcc53,
            this.dgcID});
            this.dgvRows.DataSource = this.bsStores;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 36);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.RowHeadersWidth = 62;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(1149, 336);
            this.dgvRows.TabIndex = 1;
            this.dgvRows.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRows_MyKeyDown);
            this.dgvRows.MyCheckForChanges += new System.EventHandler(this.dgvRows_MyCheckForChanges);
            this.dgvRows.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvRows_CellBeginEdit);
            this.dgvRows.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRows_CellDoubleClick);
            this.dgvRows.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvRows_DefaultValuesNeeded);
            this.dgvRows.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvRows_UserDeletingRow);
            this.dgvRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvRows_KeyPress);
            // 
            // dgcCode
            // 
            this.dgcCode.DataPropertyName = "CODE";
            this.dgcCode.Frozen = true;
            this.dgcCode.HeaderText = "kods";
            this.dgcCode.MinimumWidth = 8;
            this.dgcCode.Name = "dgcCode";
            this.dgcCode.Width = 140;
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "NAME";
            this.dgcName.Frozen = true;
            this.dgcName.HeaderText = "nosaukums";
            this.dgcName.MinimumWidth = 8;
            this.dgcName.Name = "dgcName";
            this.dgcName.Width = 250;
            // 
            // dgcTP
            // 
            this.dgcTP.DataPropertyName = "TP";
            this.dgcTP.DataSource = this.bsStoreType;
            this.dgcTP.DisplayMember = "NAME";
            this.dgcTP.HeaderText = "veids";
            this.dgcTP.MinimumWidth = 8;
            this.dgcTP.Name = "dgcTP";
            this.dgcTP.ValueMember = "ID";
            this.dgcTP.Width = 140;
            // 
            // bsStoreType
            // 
            this.bsStoreType.DataMember = "M_STORETYPE";
            this.bsStoreType.MyDataSource = "KlonsMData";
            // 
            // dgcRegNr
            // 
            this.dgcRegNr.DataPropertyName = "REGNR";
            this.dgcRegNr.HeaderText = "reģ.nr.";
            this.dgcRegNr.MinimumWidth = 8;
            this.dgcRegNr.Name = "dgcRegNr";
            this.dgcRegNr.Width = 130;
            // 
            // dgcPVNRegNr
            // 
            this.dgcPVNRegNr.DataPropertyName = "PVNREGNR";
            this.dgcPVNRegNr.HeaderText = "PVN reģ.nr.";
            this.dgcPVNRegNr.MinimumWidth = 8;
            this.dgcPVNRegNr.Name = "dgcPVNRegNr";
            this.dgcPVNRegNr.Width = 130;
            // 
            // dgcAddr
            // 
            this.dgcAddr.DataPropertyName = "ADDR";
            this.dgcAddr.HeaderText = "adrese";
            this.dgcAddr.MinimumWidth = 8;
            this.dgcAddr.Name = "dgcAddr";
            this.dgcAddr.Width = 180;
            // 
            // dgcPVNTp
            // 
            this.dgcPVNTp.DataPropertyName = "PVNTP";
            this.dgcPVNTp.DataSource = this.bsPVNType;
            this.dgcPVNTp.DisplayMember = "CODE";
            this.dgcPVNTp.HeaderText = "PVN veids";
            this.dgcPVNTp.MinimumWidth = 8;
            this.dgcPVNTp.Name = "dgcPVNTp";
            this.dgcPVNTp.ValueMember = "ID";
            this.dgcPVNTp.Width = 120;
            // 
            // bsPVNType
            // 
            this.bsPVNType.DataMember = "M_PVNTYPE";
            this.bsPVNType.MyDataSource = "KlonsMData";
            this.bsPVNType.Sort = "ID";
            // 
            // dgcAcc21
            // 
            this.dgcAcc21.DataPropertyName = "ACC21";
            this.dgcAcc21.DataSource = this.bsAccounts21;
            this.dgcAcc21.DisplayMember = "ID";
            this.dgcAcc21.HeaderText = "konts 21";
            this.dgcAcc21.MinimumWidth = 8;
            this.dgcAcc21.Name = "dgcAcc21";
            this.dgcAcc21.ValueMember = "ID";
            this.dgcAcc21.Width = 80;
            // 
            // bsAccounts21
            // 
            this.bsAccounts21.DataMember = "M_ACCOUNTS";
            this.bsAccounts21.Filter = "TP=2 OR TP=1";
            this.bsAccounts21.MyDataSource = "KlonsMData";
            this.bsAccounts21.Sort = "ID";
            // 
            // dgcAcc23
            // 
            this.dgcAcc23.DataPropertyName = "ACC23";
            this.dgcAcc23.DataSource = this.bsAccounts23;
            this.dgcAcc23.DisplayMember = "ID";
            this.dgcAcc23.HeaderText = "konts 23";
            this.dgcAcc23.MinimumWidth = 8;
            this.dgcAcc23.Name = "dgcAcc23";
            this.dgcAcc23.ValueMember = "ID";
            this.dgcAcc23.Width = 80;
            // 
            // bsAccounts23
            // 
            this.bsAccounts23.DataMember = "M_ACCOUNTS";
            this.bsAccounts23.Filter = "TP=5 OR TP=1";
            this.bsAccounts23.MyDataSource = "KlonsMData";
            this.bsAccounts23.Sort = "ID";
            // 
            // dgcAcc53
            // 
            this.dgcAcc53.DataPropertyName = "ACC53";
            this.dgcAcc53.DataSource = this.bsAccounts53;
            this.dgcAcc53.DisplayMember = "ID";
            this.dgcAcc53.HeaderText = "konts 53";
            this.dgcAcc53.MinimumWidth = 8;
            this.dgcAcc53.Name = "dgcAcc53";
            this.dgcAcc53.ValueMember = "ID";
            this.dgcAcc53.Width = 80;
            // 
            // bsAccounts53
            // 
            this.bsAccounts53.DataMember = "M_ACCOUNTS";
            this.bsAccounts53.Filter = "TP=6 OR TP=1";
            this.bsAccounts53.MyDataSource = "KlonsMData";
            this.bsAccounts53.Sort = "ID";
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.MinimumWidth = 8;
            this.dgcID.Name = "dgcID";
            this.dgcID.Visible = false;
            this.dgcID.Width = 60;
            // 
            // bNav
            // 
            this.bNav.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bNav.BindingSource = this.bsStores;
            this.bNav.CountItem = this.bindingNavigatorCountItem;
            this.bNav.CountItemFormat = " no {0}";
            this.bNav.DataGrid = this.dgvRows;
            this.bNav.DeleteItem = this.bindingNavigatorDeleteItem;
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
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.bindingNavigatorSaveItem,
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
            this.bNav.SaveItem = this.bindingNavigatorSaveItem;
            this.bNav.Size = new System.Drawing.Size(1149, 39);
            this.bNav.TabIndex = 2;
            this.bNav.Text = "myBindingNavigator1";
            this.bNav.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bNav_ItemDeleting);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(93, 34);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 34);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(94, 34);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
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
            // bindingNavigatorSaveItem
            // 
            this.bindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorSaveItem.Image")));
            this.bindingNavigatorSaveItem.Name = "bindingNavigatorSaveItem";
            this.bindingNavigatorSaveItem.Size = new System.Drawing.Size(124, 34);
            this.bindingNavigatorSaveItem.Text = "Saglabāt";
            this.bindingNavigatorSaveItem.Click += new System.EventHandler(this.bindingNavigatorSaveItem_Click);
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
            this.panel1.Controls.Add(this.cbType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbFilter);
            this.panel1.Controls.Add(this.tbCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1149, 36);
            this.panel1.TabIndex = 0;
            // 
            // cbType
            // 
            this.cbType.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbType.DataMember = null;
            this.cbType.DataSource = this.bsStoreTypeFilter;
            this.cbType.DisplayMember = "NAME";
            this.cbType.Location = new System.Drawing.Point(231, 5);
            this.cbType.Name = "cbType";
            this.cbType.SelectedIndex = -1;
            this.cbType.ShowButton = true;
            this.cbType.Size = new System.Drawing.Size(198, 26);
            this.cbType.TabIndex = 5;
            this.cbType.ValueMember = "ID";
            this.cbType.ButtonClicked += new System.EventHandler(this.cbType_ButtonClicked);
            this.cbType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbType_KeyDown);
            // 
            // bsStoreTypeFilter
            // 
            this.bsStoreTypeFilter.DataMember = "M_STORETYPE";
            this.bsStoreTypeFilter.MyDataSource = "KlonsMData";
            this.bsStoreTypeFilter.Sort = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(456, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "atlasīt:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "veids:";
            // 
            // tbFilter
            // 
            this.tbFilter.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbFilter.Location = new System.Drawing.Point(517, 5);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(185, 26);
            this.tbFilter.TabIndex = 2;
            this.tbFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFilter_KeyDown);
            this.tbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            // 
            // tbCode
            // 
            this.tbCode.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbCode.DataMember = null;
            this.tbCode.DataSource = this.bsStores;
            this.tbCode.DisplayMember = "CODE";
            this.tbCode.Location = new System.Drawing.Point(3, 5);
            this.tbCode.Name = "tbCode";
            this.tbCode.SelectedIndex = -1;
            this.tbCode.Size = new System.Drawing.Size(146, 26);
            this.tbCode.TabIndex = 0;
            this.tbCode.ValueMember = "ID";
            this.tbCode.RowSelectedEvent += new KlonsLIB.Components.RowSelectedEventHandler(this.tbCode_RowSelectedEvent);
            this.tbCode.Enter += new System.EventHandler(this.tbCode_Enter);
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsMData";
            this.myAdapterManager1.TableNames = new string[] {
        "M_STORES",
        "M_ROWS",
        "M_DOCS",
        "M_ITEMS",
        null};
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btAtlikumi,
            this.btAddresses,
            this.btContacts,
            this.btBankAccounts,
            this.btVehicles});
            this.toolStrip1.Location = new System.Drawing.Point(0, 372);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1149, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btAtlikumi
            // 
            this.btAtlikumi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btAtlikumi.Image = ((System.Drawing.Image)(resources.GetObject("btAtlikumi.Image")));
            this.btAtlikumi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAtlikumi.Name = "btAtlikumi";
            this.btAtlikumi.Size = new System.Drawing.Size(175, 34);
            this.btAtlikumi.Text = "Aktuālie atlikumi";
            this.btAtlikumi.Click += new System.EventHandler(this.btAtlikumi_Click);
            // 
            // btAddresses
            // 
            this.btAddresses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btAddresses.Image = ((System.Drawing.Image)(resources.GetObject("btAddresses.Image")));
            this.btAddresses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAddresses.Name = "btAddresses";
            this.btAddresses.Size = new System.Drawing.Size(119, 34);
            this.btAddresses.Text = "❏ Adreses";
            this.btAddresses.Click += new System.EventHandler(this.btAddresses_Click);
            // 
            // btContacts
            // 
            this.btContacts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btContacts.Image = ((System.Drawing.Image)(resources.GetObject("btContacts.Image")));
            this.btContacts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btContacts.Name = "btContacts";
            this.btContacts.Size = new System.Drawing.Size(120, 34);
            this.btContacts.Text = "❏ Kontakti";
            this.btContacts.Click += new System.EventHandler(this.btContacts_Click);
            // 
            // btBankAccounts
            // 
            this.btBankAccounts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btBankAccounts.Image = ((System.Drawing.Image)(resources.GetObject("btBankAccounts.Image")));
            this.btBankAccounts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btBankAccounts.Name = "btBankAccounts";
            this.btBankAccounts.Size = new System.Drawing.Size(91, 34);
            this.btBankAccounts.Text = "❏ Konti";
            this.btBankAccounts.Click += new System.EventHandler(this.btBankAccounts_Click);
            // 
            // btVehicles
            // 
            this.btVehicles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btVehicles.Image = ((System.Drawing.Image)(resources.GetObject("btVehicles.Image")));
            this.btVehicles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btVehicles.Name = "btVehicles";
            this.btVehicles.Size = new System.Drawing.Size(142, 34);
            this.btVehicles.Text = "❏ Transports";
            this.btVehicles.Click += new System.EventHandler(this.btVehicles_Click);
            // 
            // FormM_Stores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 450);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.bNav);
            this.Name = "FormM_Stores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Noliktavas / partneri";
            this.Load += new System.EventHandler(this.FormM_Stores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsStores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStoreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPVNType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccounts21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccounts23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccounts53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).EndInit();
            this.bNav.ResumeLayout(false);
            this.bNav.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsStoreTypeFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsStores;
        private KlonsLIB.Data.MyBindingSource bsStoreType;
        private KlonsLIB.Components.MyBindingNavigator bNav;
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
        private System.Windows.Forms.ToolStripButton bindingNavigatorSaveItem;
        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private KlonsLIB.Data.MyBindingSource bsStoreTypeFilter;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private KlonsLIB.Data.MyBindingSource bsAccounts21;
        private KlonsLIB.Components.MyTextBox tbFilter;
        private KlonsLIB.Components.MyPickRowTextBox2 tbCode;
        private KlonsLIB.Data.MyBindingSource bsPVNType;
        private KlonsLIB.Data.MyBindingSource bsAccounts23;
        private KlonsLIB.Data.MyBindingSource bsAccounts53;
        private System.Windows.Forms.ToolStripButton tsbFindPrev;
        private System.Windows.Forms.ToolStripTextBox tsbFind;
        private System.Windows.Forms.ToolStripButton tsbFindNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btAtlikumi;
        private System.Windows.Forms.ToolStripButton btAddresses;
        private System.Windows.Forms.ToolStripButton btContacts;
        private System.Windows.Forms.ToolStripButton btBankAccounts;
        private System.Windows.Forms.ToolStripButton btVehicles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRegNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPVNRegNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAddr;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcPVNTp;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcAcc21;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcAcc23;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcAcc53;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
        private KlonsLIB.Components.MyPickRowTextBox2 cbType;
    }
}