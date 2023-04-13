
namespace KlonsFM.FormsM
{
    partial class FormM_Items
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormM_Items));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bsItems = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.bsItemsCat = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsStore = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsPVNRate = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsUnits = new KlonsLIB.Data.MyBindingSource(this.components);
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
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.aktuālieArtikulaAtlikumiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbItemsCatFilter = new KlonsLIB.Components.MyPickRowTextBox2();
            this.bsItemsCatFilter = new KlonsLIB.Data.MyBindingSource(this.components);
            this.tbFilter = new KlonsLIB.Components.MyTextBox();
            this.tbCode = new KlonsLIB.Components.MyPickRowTextBox2();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCat = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.dgcStore1 = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.dgcPVNRate = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.dgcIsService = new KlonsLIB.Components.MyDgvCheckBoxColumn();
            this.dgcIsProduced = new KlonsLIB.Components.MyDgvCheckBoxColumn();
            this.dgcUints = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.dgcSellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAmountInStore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLastBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcProdCosts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLastSaleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).BeginInit();
            this.bNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItemsCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPVNRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnits)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItemsCatFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bNav
            // 
            this.bNav.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bNav.BindingSource = this.bsItems;
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
            this.tsbFindNext,
            this.toolStripDropDownButton1});
            this.bNav.Location = new System.Drawing.Point(0, 411);
            this.bNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bNav.Name = "bNav";
            this.bNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bNav.SaveItem = this.bindingNavigatorSaveItem;
            this.bNav.Size = new System.Drawing.Size(1199, 39);
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
            // bsItems
            // 
            this.bsItems.DataMember = "M_ITEMS";
            this.bsItems.MyDataSource = "KlonsMData";
            this.bsItems.Sort = "BARCODE";
            this.bsItems.UseDataGridView = this.dgvRows;
            this.bsItems.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsItems_ListChanged);
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToResizeRows = false;
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.AutoSave = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcID,
            this.dgcCode,
            this.dgcName,
            this.dgcCat,
            this.dgcStore1,
            this.dgcPVNRate,
            this.dgcIsService,
            this.dgcIsProduced,
            this.dgcUints,
            this.dgcSellPrice,
            this.dgcAmountInStore,
            this.dgcBBuyPrice,
            this.dgcLastBuyPrice,
            this.dgcProdCosts,
            this.dgcLastSaleDate});
            this.dgvRows.DataSource = this.bsItems;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 36);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.RowHeadersWidth = 62;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(1199, 375);
            this.dgvRows.TabIndex = 1;
            this.dgvRows.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRows_MyKeyDown);
            this.dgvRows.MyCheckForChanges += new System.EventHandler(this.dgvRows_MyCheckForChanges);
            this.dgvRows.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvRows_CellBeginEdit);
            this.dgvRows.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRows_CellDoubleClick);
            this.dgvRows.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvRows_UserDeletingRow);
            this.dgvRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvRows_KeyPress);
            // 
            // bsItemsCat
            // 
            this.bsItemsCat.DataMember = "M_ITEMS_CAT";
            this.bsItemsCat.MyDataSource = "KlonsMData";
            this.bsItemsCat.Sort = "CODE";
            // 
            // bsStore
            // 
            this.bsStore.DataMember = "M_STORES";
            this.bsStore.Filter = "TP=2 OR ID=1";
            this.bsStore.MyDataSource = "KlonsMData";
            this.bsStore.Sort = "CODE";
            // 
            // bsPVNRate
            // 
            this.bsPVNRate.DataMember = "M_PVNRATES";
            this.bsPVNRate.MyDataSource = "KlonsMData";
            this.bsPVNRate.Sort = "CODE";
            // 
            // bsUnits
            // 
            this.bsUnits.DataMember = "M_UNITS";
            this.bsUnits.MyDataSource = "KlonsMData";
            this.bsUnits.Sort = "ID";
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
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aktuālieArtikulaAtlikumiToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(116, 34);
            this.toolStripDropDownButton1.Text = "Darbības";
            // 
            // aktuālieArtikulaAtlikumiToolStripMenuItem
            // 
            this.aktuālieArtikulaAtlikumiToolStripMenuItem.Name = "aktuālieArtikulaAtlikumiToolStripMenuItem";
            this.aktuālieArtikulaAtlikumiToolStripMenuItem.Size = new System.Drawing.Size(350, 38);
            this.aktuālieArtikulaAtlikumiToolStripMenuItem.Text = "Aktuālie artikula atlikumi";
            this.aktuālieArtikulaAtlikumiToolStripMenuItem.Click += new System.EventHandler(this.aktuālieArtikulaAtlikumiToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbItemsCatFilter);
            this.panel1.Controls.Add(this.tbFilter);
            this.panel1.Controls.Add(this.tbCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1199, 36);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(479, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "atlasīt:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "kategorija:";
            // 
            // tbItemsCatFilter
            // 
            this.tbItemsCatFilter.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbItemsCatFilter.DataMember = null;
            this.tbItemsCatFilter.DataSource = this.bsItemsCatFilter;
            this.tbItemsCatFilter.DisplayMember = "CODE";
            this.tbItemsCatFilter.Location = new System.Drawing.Point(272, 5);
            this.tbItemsCatFilter.Name = "tbItemsCatFilter";
            this.tbItemsCatFilter.SelectedIndex = -1;
            this.tbItemsCatFilter.ShowButton = true;
            this.tbItemsCatFilter.Size = new System.Drawing.Size(191, 26);
            this.tbItemsCatFilter.SyncPosition = false;
            this.tbItemsCatFilter.TabIndex = 1;
            this.tbItemsCatFilter.ValueMember = "ID";
            this.tbItemsCatFilter.SelectedIndexChanged += new System.EventHandler(this.tbItemsCatFilter_SelectedIndexChanged);
            this.tbItemsCatFilter.ButtonClicked += new System.EventHandler(this.tbItemsCatFilter_ButtonClicked);
            this.tbItemsCatFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbItemsCatFilter_KeyDown);
            // 
            // bsItemsCatFilter
            // 
            this.bsItemsCatFilter.DataMember = "M_ITEMS_CAT";
            this.bsItemsCatFilter.MyDataSource = "KlonsMData";
            this.bsItemsCatFilter.Sort = "CODE";
            // 
            // tbFilter
            // 
            this.tbFilter.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbFilter.Location = new System.Drawing.Point(540, 5);
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
            this.tbCode.DataSource = this.bsItems;
            this.tbCode.DisplayMember = "BARCODE";
            this.tbCode.Location = new System.Drawing.Point(3, 5);
            this.tbCode.Name = "tbCode";
            this.tbCode.SelectedIndex = -1;
            this.tbCode.Size = new System.Drawing.Size(158, 26);
            this.tbCode.TabIndex = 0;
            this.tbCode.ValueMember = "ID";
            this.tbCode.RowSelectedEvent += new KlonsLIB.Components.RowSelectedEventHandler(this.tbCode_RowSelectedEvent);
            this.tbCode.Enter += new System.EventHandler(this.tbCode_Enter);
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsMData";
            this.myAdapterManager1.TableNames = new string[] {
        "M_ITEMS",
        "M_ITEMS_CAT",
        null};
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
            // dgcCode
            // 
            this.dgcCode.DataPropertyName = "BARCODE";
            this.dgcCode.HeaderText = "kods";
            this.dgcCode.MinimumWidth = 8;
            this.dgcCode.Name = "dgcCode";
            this.dgcCode.Width = 160;
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "NAME";
            this.dgcName.HeaderText = "nosaukums";
            this.dgcName.MinimumWidth = 8;
            this.dgcName.Name = "dgcName";
            this.dgcName.Width = 300;
            // 
            // dgcCat
            // 
            this.dgcCat.DataPropertyName = "CAT";
            this.dgcCat.DataSource = this.bsItemsCat;
            this.dgcCat.DisplayMember = "CODE";
            this.dgcCat.HeaderText = "kategorija";
            this.dgcCat.MinimumWidth = 8;
            this.dgcCat.Name = "dgcCat";
            this.dgcCat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcCat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcCat.ValueMember = "ID";
            this.dgcCat.Width = 140;
            // 
            // dgcStore1
            // 
            this.dgcStore1.DataPropertyName = "STORE1";
            this.dgcStore1.DataSource = this.bsStore;
            this.dgcStore1.DisplayMember = "CODE";
            this.dgcStore1.HeaderText = "pamatnoliktava";
            this.dgcStore1.MinimumWidth = 8;
            this.dgcStore1.Name = "dgcStore1";
            this.dgcStore1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcStore1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcStore1.ValueMember = "ID";
            this.dgcStore1.Width = 160;
            // 
            // dgcPVNRate
            // 
            this.dgcPVNRate.DataPropertyName = "PVNRATE";
            this.dgcPVNRate.DataSource = this.bsPVNRate;
            this.dgcPVNRate.DisplayMember = "CODE";
            this.dgcPVNRate.HeaderText = "PVN likme";
            this.dgcPVNRate.MinimumWidth = 8;
            this.dgcPVNRate.Name = "dgcPVNRate";
            this.dgcPVNRate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcPVNRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcPVNRate.ValueMember = "ID";
            this.dgcPVNRate.Width = 120;
            // 
            // dgcIsService
            // 
            this.dgcIsService.DataPropertyName = "ISSERVICE";
            this.dgcIsService.FalseValue = "0";
            this.dgcIsService.HeaderText = "pakalp.";
            this.dgcIsService.MinimumWidth = 8;
            this.dgcIsService.Name = "dgcIsService";
            this.dgcIsService.ReadOnly = true;
            this.dgcIsService.TrueValue = "1";
            this.dgcIsService.Width = 70;
            // 
            // dgcIsProduced
            // 
            this.dgcIsProduced.DataPropertyName = "ISPRODUCED";
            this.dgcIsProduced.FalseValue = "0";
            this.dgcIsProduced.HeaderText = "ražots";
            this.dgcIsProduced.MinimumWidth = 8;
            this.dgcIsProduced.Name = "dgcIsProduced";
            this.dgcIsProduced.ReadOnly = true;
            this.dgcIsProduced.TrueValue = "1";
            this.dgcIsProduced.Width = 60;
            // 
            // dgcUints
            // 
            this.dgcUints.DataPropertyName = "UNITS";
            this.dgcUints.DataSource = this.bsUnits;
            this.dgcUints.DisplayMember = "CODE";
            this.dgcUints.HeaderText = "mērv.";
            this.dgcUints.MinimumWidth = 8;
            this.dgcUints.Name = "dgcUints";
            this.dgcUints.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcUints.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcUints.ValueMember = "ID";
            this.dgcUints.Width = 80;
            // 
            // dgcSellPrice
            // 
            this.dgcSellPrice.DataPropertyName = "SELLPRICE";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N4";
            this.dgcSellPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcSellPrice.HeaderText = "cena";
            this.dgcSellPrice.MinimumWidth = 8;
            this.dgcSellPrice.Name = "dgcSellPrice";
            this.dgcSellPrice.Width = 90;
            // 
            // dgcAmountInStore
            // 
            this.dgcAmountInStore.DataPropertyName = "AMOUNTINSTORE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgcAmountInStore.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcAmountInStore.HeaderText = "daudzums";
            this.dgcAmountInStore.MinimumWidth = 8;
            this.dgcAmountInStore.Name = "dgcAmountInStore";
            this.dgcAmountInStore.Width = 90;
            // 
            // dgcBBuyPrice
            // 
            this.dgcBBuyPrice.DataPropertyName = "BUYPRICE";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            this.dgcBBuyPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcBBuyPrice.HeaderText = "iep. cena";
            this.dgcBBuyPrice.MinimumWidth = 8;
            this.dgcBBuyPrice.Name = "dgcBBuyPrice";
            this.dgcBBuyPrice.Width = 90;
            // 
            // dgcLastBuyPrice
            // 
            this.dgcLastBuyPrice.DataPropertyName = "LASTBUYPRICE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N4";
            this.dgcLastBuyPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcLastBuyPrice.HeaderText = "pēdējā iep. cena";
            this.dgcLastBuyPrice.MinimumWidth = 8;
            this.dgcLastBuyPrice.Name = "dgcLastBuyPrice";
            this.dgcLastBuyPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcLastBuyPrice.Width = 90;
            // 
            // dgcProdCosts
            // 
            this.dgcProdCosts.DataPropertyName = "PRODCOST";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N4";
            this.dgcProdCosts.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcProdCosts.HeaderText = "raž. izm.";
            this.dgcProdCosts.MinimumWidth = 8;
            this.dgcProdCosts.Name = "dgcProdCosts";
            this.dgcProdCosts.Width = 90;
            // 
            // dgcLastSaleDate
            // 
            this.dgcLastSaleDate.DataPropertyName = "LASTSALEDATE";
            dataGridViewCellStyle6.Format = "dd.MM.yyyy";
            this.dgcLastSaleDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcLastSaleDate.HeaderText = "datums2";
            this.dgcLastSaleDate.MinimumWidth = 8;
            this.dgcLastSaleDate.Name = "dgcLastSaleDate";
            this.dgcLastSaleDate.Width = 110;
            // 
            // FormM_Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 450);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bNav);
            this.Name = "FormM_Items";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artikuli";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormM_Items_FormClosed);
            this.Load += new System.EventHandler(this.FormM_Items_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).EndInit();
            this.bNav.ResumeLayout(false);
            this.bNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItemsCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPVNRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUnits)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItemsCatFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.ToolStripButton tsbFindPrev;
        private System.Windows.Forms.ToolStripTextBox tsbFind;
        private System.Windows.Forms.ToolStripButton tsbFindNext;
        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Components.MyTextBox tbFilter;
        private KlonsLIB.Components.MyPickRowTextBox2 tbCode;
        private KlonsLIB.Data.MyBindingSource bsItems;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private KlonsLIB.Data.MyBindingSource bsItemsCat;
        private KlonsLIB.Data.MyBindingSource bsStore;
        private KlonsLIB.Data.MyBindingSource bsPVNRate;
        private KlonsLIB.Data.MyBindingSource bsItemsCatFilter;
        private KlonsLIB.Components.MyPickRowTextBox2 tbItemsCatFilter;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private KlonsLIB.Data.MyBindingSource bsUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLastInID;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem aktuālieArtikulaAtlikumiToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLastInLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcCat;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcStore1;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcPVNRate;
        private KlonsLIB.Components.MyDgvCheckBoxColumn dgcIsService;
        private KlonsLIB.Components.MyDgvCheckBoxColumn dgcIsProduced;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcUints;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAmountInStore;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLastBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcProdCosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLastSaleDate;
    }
}