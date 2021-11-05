namespace KlonsA.Forms
{
    partial class Form_PieceWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PieceWork));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.cmFilter = new System.Windows.Forms.ToolStripButton();
            this.bnavSar = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bsSar = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvSar = new KlonsLIB.Components.MyDataGridView();
            this.bsAmati2 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsKat = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.bsAmati = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cbAmats = new KlonsLIB.Components.MyMcFlatComboBox();
            this.tbDT2 = new KlonsLIB.Components.MyTextBox();
            this.tbDT1 = new KlonsLIB.Components.MyTextBox();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.dgcDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIDA = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcIDK = new KlonsLIB.Components.MyDgvMcComboBoxColumn();
            this.dgcIDKa = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTimeUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcTimeUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTimeHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnavSar)).BeginInit();
            this.bnavSar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.cmFilter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.toolStrip1.Size = new System.Drawing.Size(782, 34);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(85, 29);
            this.toolStripLabel1.Text = "Datums:";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(19, 29);
            this.toolStripLabel2.Text = "-";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(17, 29);
            this.toolStripLabel3.Text = " ";
            // 
            // cmFilter
            // 
            this.cmFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmFilter.Image = ((System.Drawing.Image)(resources.GetObject("cmFilter.Image")));
            this.cmFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmFilter.Name = "cmFilter";
            this.cmFilter.Size = new System.Drawing.Size(79, 29);
            this.cmFilter.Text = " Atlasīt ";
            this.cmFilter.Click += new System.EventHandler(this.cmFilter_Click);
            // 
            // bnavSar
            // 
            this.bnavSar.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavSar.BindingSource = this.bsSar;
            this.bnavSar.CountItem = this.bindingNavigatorCountItem;
            this.bnavSar.CountItemFormat = " no {0}";
            this.bnavSar.DataGrid = this.dgvSar;
            this.bnavSar.DeleteItem = null;
            this.bnavSar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavSar.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavSar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.toolStripButton1,
            this.bindingNavigatorDeleteItem,
            this.tsbSave});
            this.bnavSar.Location = new System.Drawing.Point(0, 370);
            this.bnavSar.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavSar.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavSar.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavSar.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavSar.Name = "bnavSar";
            this.bnavSar.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavSar.SaveItem = null;
            this.bnavSar.Size = new System.Drawing.Size(782, 32);
            this.bnavSar.TabIndex = 1;
            this.bnavSar.Text = "myBindingNavigator1";
            this.bnavSar.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavSar_ItemDeleting);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(91, 29);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            // 
            // bsSar
            // 
            this.bsSar.DataMember = "PIECEWORK";
            this.bsSar.MyDataSource = "KlonsData";
            this.bsSar.Sort = "DT,ID";
            this.bsSar.UseDataGridView = this.dgvSar;
            this.bsSar.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsSar_ListChanged);
            // 
            // dgvSar
            // 
            this.dgvSar.AllowUserToDeleteRows = false;
            this.dgvSar.AutoGenerateColumns = false;
            this.dgvSar.AutoSave = false;
            this.dgvSar.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDT,
            this.dgcIDA,
            this.dgcIDK,
            this.dgcIDKa,
            this.dgcUnit,
            this.dgcQuantity,
            this.dgcRate,
            this.dgcBonus,
            this.dgcPay,
            this.dgcTimeUnit,
            this.dgcTimeUse,
            this.dgcTimeHour,
            this.dgcID});
            this.dgvSar.DataSource = this.bsSar;
            this.dgvSar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSar.Location = new System.Drawing.Point(0, 34);
            this.dgvSar.Name = "dgvSar";
            this.dgvSar.RowTemplate.Height = 24;
            this.dgvSar.Size = new System.Drawing.Size(782, 336);
            this.dgvSar.TabIndex = 2;
            this.dgvSar.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSar_MyKeyDown);
            this.dgvSar.MyCheckForChanges += new System.EventHandler(this.dgvSar_MyCheckForChanges);
            this.dgvSar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSar_CellDoubleClick);
            this.dgvSar.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSar_CellEndEdit);
            this.dgvSar.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvSar_CellParsing);
            this.dgvSar.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvSar_DefaultValuesNeeded);
            this.dgvSar.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSar_RowValidating);
            this.dgvSar.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvSar_UserDeletingRow);
            // 
            // bsAmati2
            // 
            this.bsAmati2.DataMember = "POSITIONS";
            this.bsAmati2.MyDataSource = "KlonsData";
            this.bsAmati2.Sort = "YNAME";
            // 
            // bsKat
            // 
            this.bsKat.DataMember = "PIECEWORK_CATALOG";
            this.bsKat.MyDataSource = "KlonsData";
            this.bsKat.Sort = "KATCODE,ID";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(69, 29);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
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
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 30);
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
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(89, 29);
            this.toolStripButton1.Text = "Kopēt";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(87, 29);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(25, 29);
            this.tsbSave.Text = "Saglabāt";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // bsAmati
            // 
            this.bsAmati.DataMember = "POSITIONS";
            this.bsAmati.Filter = "USED = 1";
            this.bsAmati.MyDataSource = "KlonsData";
            this.bsAmati.Sort = "YNAME";
            // 
            // cbAmats
            // 
            this.cbAmats.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAmats.ColumnNames = new string[] {
        "ID",
        "YNAME"};
            this.cbAmats.ColumnWidths = "0;250";
            this.cbAmats.DataSource = this.bsAmati;
            this.cbAmats.DisplayMember = "YNAME";
            this.cbAmats.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAmats.DropDownHeight = 136;
            this.cbAmats.DropDownWidth = 274;
            this.cbAmats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAmats.FormattingEnabled = true;
            this.cbAmats.GridLineColor = System.Drawing.Color.LightGray;
            this.cbAmats.GridLineHorizontal = false;
            this.cbAmats.GridLineVertical = false;
            this.cbAmats.IntegralHeight = false;
            this.cbAmats.Location = new System.Drawing.Point(458, 0);
            this.cbAmats.Name = "cbAmats";
            this.cbAmats.Size = new System.Drawing.Size(250, 23);
            this.cbAmats.TabIndex = 3;
            this.cbAmats.ValueMember = "ID";
            // 
            // tbDT2
            // 
            this.tbDT2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDT2.IsDate = true;
            this.tbDT2.Location = new System.Drawing.Point(357, 1);
            this.tbDT2.Name = "tbDT2";
            this.tbDT2.Size = new System.Drawing.Size(80, 22);
            this.tbDT2.TabIndex = 8;
            // 
            // tbDT1
            // 
            this.tbDT1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDT1.IsDate = true;
            this.tbDT1.Location = new System.Drawing.Point(260, 1);
            this.tbDT1.Name = "tbDT1";
            this.tbDT1.Size = new System.Drawing.Size(80, 22);
            this.tbDT1.TabIndex = 9;
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "PIECEWORK",
        "PIECEWORK_CATALOG",
        "PIECEWORK_CATSTRUCT",
        null};
            // 
            // dgcDT
            // 
            this.dgcDT.DataPropertyName = "DT";
            dataGridViewCellStyle2.Format = "dd.MM.yyyy";
            this.dgcDT.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcDT.HeaderText = "datums";
            this.dgcDT.Name = "dgcDT";
            this.dgcDT.Width = 85;
            // 
            // dgcIDA
            // 
            this.dgcIDA.DataPropertyName = "IDA";
            this.dgcIDA.DataSource = this.bsAmati2;
            this.dgcIDA.DisplayMember = "YNAME";
            this.dgcIDA.DisplayStyleForCurrentCellOnly = true;
            this.dgcIDA.DropDownWidth = 250;
            this.dgcIDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcIDA.HeaderText = "darbinieks, amats";
            this.dgcIDA.MaxDropDownItems = 15;
            this.dgcIDA.Name = "dgcIDA";
            this.dgcIDA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcIDA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcIDA.ValueMember = "ID";
            this.dgcIDA.Width = 200;
            // 
            // dgcIDK
            // 
            this.dgcIDK.ColumnNames = new string[] {
        "CODE",
        "DESCR"};
            this.dgcIDK.ColumnWidths = "80;200";
            this.dgcIDK.DataPropertyName = "IDK";
            this.dgcIDK.DataSource = this.bsKat;
            this.dgcIDK.DisplayMember = "CODE";
            this.dgcIDK.DisplayStyleForCurrentCellOnly = true;
            this.dgcIDK.HeaderText = "kods";
            this.dgcIDK.MaxDropDownItems = 15;
            this.dgcIDK.Name = "dgcIDK";
            this.dgcIDK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcIDK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcIDK.ToolTipText = "kataloga kods";
            this.dgcIDK.ValueMember = "ID";
            this.dgcIDK.Width = 80;
            // 
            // dgcIDKa
            // 
            this.dgcIDKa.DataPropertyName = "IDK";
            this.dgcIDKa.DataSource = this.bsKat;
            this.dgcIDKa.DisplayMember = "DESCR";
            this.dgcIDKa.DisplayStyleForCurrentCellOnly = true;
            this.dgcIDKa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcIDKa.HeaderText = "nosaukums";
            this.dgcIDKa.Name = "dgcIDKa";
            this.dgcIDKa.ReadOnly = true;
            this.dgcIDKa.ValueMember = "ID";
            this.dgcIDKa.Width = 200;
            // 
            // dgcUnit
            // 
            this.dgcUnit.DataPropertyName = "UNIT";
            this.dgcUnit.HeaderText = "mērv.";
            this.dgcUnit.Name = "dgcUnit";
            this.dgcUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcUnit.ToolTipText = "uzskaites mērvienība";
            this.dgcUnit.Width = 50;
            // 
            // dgcQuantity
            // 
            this.dgcQuantity.DataPropertyName = "QUANTITY";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcQuantity.HeaderText = "skaits";
            this.dgcQuantity.Name = "dgcQuantity";
            this.dgcQuantity.Width = 60;
            // 
            // dgcRate
            // 
            this.dgcRate.DataPropertyName = "RATE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N4";
            this.dgcRate.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcRate.HeaderText = "likme";
            this.dgcRate.Name = "dgcRate";
            this.dgcRate.ToolTipText = "samaksa par vienu vienību";
            this.dgcRate.Width = 80;
            // 
            // dgcBonus
            // 
            this.dgcBonus.DataPropertyName = "BONUS";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcBonus.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcBonus.HeaderText = "piem. %";
            this.dgcBonus.Name = "dgcBonus";
            this.dgcBonus.ToolTipText = "Pimemaksa % (parvirsstundām, nakts darbu)";
            this.dgcBonus.Width = 50;
            // 
            // dgcPay
            // 
            this.dgcPay.DataPropertyName = "PAY";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N4";
            this.dgcPay.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcPay.HeaderText = "samaksa";
            this.dgcPay.Name = "dgcPay";
            this.dgcPay.ReadOnly = true;
            this.dgcPay.ToolTipText = "aprēķinātā samaksa";
            this.dgcPay.Width = 80;
            // 
            // dgcTimeUnit
            // 
            this.dgcTimeUnit.DataPropertyName = "TIMEUNIT";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcTimeUnit.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcTimeUnit.DisplayStyleForCurrentCellOnly = true;
            this.dgcTimeUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcTimeUnit.HeaderText = "laika vien.";
            this.dgcTimeUnit.Name = "dgcTimeUnit";
            this.dgcTimeUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcTimeUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcTimeUnit.Width = 50;
            // 
            // dgcTimeUse
            // 
            this.dgcTimeUse.DataPropertyName = "TIMEUSE";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcTimeUse.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcTimeUse.HeaderText = "laiks";
            this.dgcTimeUse.Name = "dgcTimeUse";
            this.dgcTimeUse.ToolTipText = "laika patēriņš uz vienību";
            this.dgcTimeUse.Width = 60;
            // 
            // dgcTimeHour
            // 
            this.dgcTimeHour.DataPropertyName = "TIMEUSEINHOURS";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.dgcTimeHour.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcTimeHour.HeaderText = "stundas";
            this.dgcTimeHour.Name = "dgcTimeHour";
            this.dgcTimeHour.ReadOnly = true;
            this.dgcTimeHour.ToolTipText = "kopā laika patēriņš stundās";
            this.dgcTimeHour.Width = 60;
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.Name = "dgcID";
            this.dgcID.Visible = false;
            // 
            // Form_PieceWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 402);
            this.Controls.Add(this.tbDT2);
            this.Controls.Add(this.tbDT1);
            this.Controls.Add(this.cbAmats);
            this.Controls.Add(this.dgvSar);
            this.Controls.Add(this.bnavSar);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_PieceWork";
            this.Text = "Gabaldarba uzskaite";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_PieceWork_FormClosed);
            this.Load += new System.EventHandler(this.Form_PieceWork_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnavSar)).EndInit();
            this.bnavSar.ResumeLayout(false);
            this.bnavSar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private KlonsLIB.Components.MyBindingNavigator bnavSar;
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
        private KlonsLIB.Components.MyDataGridView dgvSar;
        private KlonsLIB.Data.MyBindingSource bsAmati;
        private KlonsLIB.Components.MyMcFlatComboBox cbAmats;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton cmFilter;
        private KlonsLIB.Components.MyTextBox tbDT2;
        private KlonsLIB.Components.MyTextBox tbDT1;
        private KlonsLIB.Data.MyBindingSource bsSar;
        private KlonsLIB.Data.MyBindingSource bsKat;
        private KlonsLIB.Data.MyBindingSource bsAmati2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDT;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcIDA;
        private KlonsLIB.Components.MyDgvMcComboBoxColumn dgcIDK;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcIDKa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPay;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcTimeUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTimeUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTimeHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
    }
}