namespace KlonsA.Forms
{
    partial class Form_PaymentsByPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PaymentsByPerson));
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
            this.bsPersons = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsRows = new System.Windows.Forms.BindingSource(this.components);
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmFilter = new System.Windows.Forms.Button();
            this.cbPerson = new KlonsLIB.Components.MyMcFlatComboBox();
            this.tbDate2 = new KlonsLIB.Components.MyTextBox();
            this.tbDate1 = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miMaksājumuPārskats = new System.Windows.Forms.ToolStripMenuItem();
            this.miAvansaMaksājumaProcentsNoPēdējāsAlgas = new System.Windows.Forms.ToolStripMenuItem();
            this.miKasesMaksājumuSarēķins = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaglabātSarēķinātosKasesMaksājumus = new System.Windows.Forms.ToolStripMenuItem();
            this.sgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcListDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPosTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCalc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCalcAdvance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCalcWithhold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCalcT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNotPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNotPaidAdvance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNotPaidWithhold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNotPaidT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPayT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCalcIIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTakeIIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCalcVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).BeginInit();
            this.bNav.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sgvRows)).BeginInit();
            this.SuspendLayout();
            // 
            // bsPersons
            // 
            this.bsPersons.DataMember = "PERSONS";
            this.bsPersons.Filter = "USED=1";
            this.bsPersons.MyDataSource = "KlonsData";
            this.bsPersons.Sort = "YNAME";
            // 
            // bNav
            // 
            this.bNav.AddNewItem = null;
            this.bNav.BindingSource = this.bsRows;
            this.bNav.CountItem = this.bindingNavigatorCountItem;
            this.bNav.CountItemFormat = " no {0}";
            this.bNav.DeleteItem = null;
            this.bNav.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bNav.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bNav.Location = new System.Drawing.Point(0, 525);
            this.bNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bNav.Name = "bNav";
            this.bNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bNav.SaveItem = null;
            this.bNav.Size = new System.Drawing.Size(1271, 37);
            this.bNav.TabIndex = 0;
            this.bNav.Text = "myBindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 32);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 32);
            this.bindingNavigatorMoveFirstItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 32);
            this.bindingNavigatorMovePreviousItem.Text = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 37);
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
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 32);
            this.bindingNavigatorMoveNextItem.Text = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 32);
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmFilter);
            this.panel1.Controls.Add(this.cbPerson);
            this.panel1.Controls.Add(this.tbDate2);
            this.panel1.Controls.Add(this.tbDate1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1271, 39);
            this.panel1.TabIndex = 1;
            // 
            // cmFilter
            // 
            this.cmFilter.Location = new System.Drawing.Point(717, 5);
            this.cmFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmFilter.Name = "cmFilter";
            this.cmFilter.Size = new System.Drawing.Size(84, 29);
            this.cmFilter.TabIndex = 5;
            this.cmFilter.Text = "Atlasīt";
            this.cmFilter.UseVisualStyleBackColor = true;
            this.cmFilter.Click += new System.EventHandler(this.CmFilter_Click);
            // 
            // cbPerson
            // 
            this.cbPerson.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbPerson.ColumnNames = new string[] {
        "FNAME",
        "LNAME",
        "PK"};
            this.cbPerson.ColumnWidths = "100;100;100";
            this.cbPerson.DataSource = this.bsPersons;
            this.cbPerson.DisplayMember = "YNAME";
            this.cbPerson.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPerson.DropDownHeight = 315;
            this.cbPerson.DropDownWidth = 328;
            this.cbPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPerson.FormattingEnabled = true;
            this.cbPerson.GridLineColor = System.Drawing.Color.LightGray;
            this.cbPerson.GridLineHorizontal = false;
            this.cbPerson.GridLineVertical = false;
            this.cbPerson.IntegralHeight = false;
            this.cbPerson.Location = new System.Drawing.Point(418, 5);
            this.cbPerson.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbPerson.MaxDropDownItems = 15;
            this.cbPerson.Name = "cbPerson";
            this.cbPerson.Size = new System.Drawing.Size(289, 27);
            this.cbPerson.TabIndex = 4;
            this.cbPerson.ValueMember = "ID";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "darbinieks:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datums:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMaksājumuPārskats});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1271, 38);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miMaksājumuPārskats
            // 
            this.miMaksājumuPārskats.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAvansaMaksājumaProcentsNoPēdējāsAlgas,
            this.miKasesMaksājumuSarēķins,
            this.miSaglabātSarēķinātosKasesMaksājumus});
            this.miMaksājumuPārskats.Name = "miMaksājumuPārskats";
            this.miMaksājumuPārskats.Size = new System.Drawing.Size(224, 34);
            this.miMaksājumuPārskats.Text = "Maksājumu pārskats";
            this.miMaksājumuPārskats.DropDownOpening += new System.EventHandler(this.miMaksājumuPārskats_DropDownOpening);
            // 
            // miAvansaMaksājumaProcentsNoPēdējāsAlgas
            // 
            this.miAvansaMaksājumaProcentsNoPēdējāsAlgas.Name = "miAvansaMaksājumaProcentsNoPēdējāsAlgas";
            this.miAvansaMaksājumaProcentsNoPēdējāsAlgas.Size = new System.Drawing.Size(555, 38);
            this.miAvansaMaksājumaProcentsNoPēdējāsAlgas.Text = "Avansa maksājuma procents no pēdējās algas";
            this.miAvansaMaksājumaProcentsNoPēdējāsAlgas.Click += new System.EventHandler(this.miAvansaMaksājumaProcentsNoPēdējāsAlgas_Click);
            // 
            // miKasesMaksājumuSarēķins
            // 
            this.miKasesMaksājumuSarēķins.Name = "miKasesMaksājumuSarēķins";
            this.miKasesMaksājumuSarēķins.Size = new System.Drawing.Size(555, 38);
            this.miKasesMaksājumuSarēķins.Text = "Kases maksājumu sarēķins";
            this.miKasesMaksājumuSarēķins.Click += new System.EventHandler(this.miKasesMaksājumuSarēķins_Click);
            // 
            // miSaglabātSarēķinātosKasesMaksājumus
            // 
            this.miSaglabātSarēķinātosKasesMaksājumus.Name = "miSaglabātSarēķinātosKasesMaksājumus";
            this.miSaglabātSarēķinātosKasesMaksājumus.Size = new System.Drawing.Size(555, 38);
            this.miSaglabātSarēķinātosKasesMaksājumus.Text = "Saglabāt sarēķinātos kases maksājumus";
            this.miSaglabātSarēķinātosKasesMaksājumus.Click += new System.EventHandler(this.miSaglabātSarēķinātosKasesMaksājumus_Click);
            // 
            // sgvRows
            // 
            this.sgvRows.AllowUserToAddRows = false;
            this.sgvRows.AllowUserToDeleteRows = false;
            this.sgvRows.AllowUserToResizeRows = false;
            this.sgvRows.AutoGenerateColumns = false;
            this.sgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sgvRows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDate,
            this.dgcListDescr,
            this.dgcPosTitle,
            this.dgcCalc,
            this.dgcCalcAdvance,
            this.dgcCalcWithhold,
            this.dgcCalcT,
            this.dgcNotPaid,
            this.dgcNotPaidAdvance,
            this.dgcNotPaidWithhold,
            this.dgcNotPaidT,
            this.dgcPayT,
            this.dgcDiff,
            this.dgcCalcIIN,
            this.dgcTakeIIN,
            this.dgcCalcVal});
            this.sgvRows.DataSource = this.bsRows;
            this.sgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgvRows.Location = new System.Drawing.Point(0, 39);
            this.sgvRows.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sgvRows.Name = "sgvRows";
            this.sgvRows.ReadOnly = true;
            this.sgvRows.RowHeadersWidth = 53;
            this.sgvRows.RowTemplate.Height = 29;
            this.sgvRows.ShowCellToolTips = false;
            this.sgvRows.Size = new System.Drawing.Size(1271, 486);
            this.sgvRows.TabIndex = 2;
            // 
            // dgcDate
            // 
            this.dgcDate.DataPropertyName = "Date";
            dataGridViewCellStyle2.Format = "dd.MM.yyyy";
            this.dgcDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcDate.Frozen = true;
            this.dgcDate.HeaderText = "datums";
            this.dgcDate.MinimumWidth = 7;
            this.dgcDate.Name = "dgcDate";
            this.dgcDate.ReadOnly = true;
            this.dgcDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDate.ToolTipText = "Aprēķina vai maksājuma datums";
            this.dgcDate.Width = 95;
            // 
            // dgcListDescr
            // 
            this.dgcListDescr.DataPropertyName = "ListDescription";
            this.dgcListDescr.Frozen = true;
            this.dgcListDescr.HeaderText = "apraksts";
            this.dgcListDescr.MinimumWidth = 7;
            this.dgcListDescr.Name = "dgcListDescr";
            this.dgcListDescr.ReadOnly = true;
            this.dgcListDescr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcListDescr.Width = 225;
            // 
            // dgcPosTitle
            // 
            this.dgcPosTitle.DataPropertyName = "PositionTitle";
            this.dgcPosTitle.HeaderText = "amats";
            this.dgcPosTitle.MinimumWidth = 7;
            this.dgcPosTitle.Name = "dgcPosTitle";
            this.dgcPosTitle.ReadOnly = true;
            this.dgcPosTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcPosTitle.Width = 225;
            // 
            // dgcCalc
            // 
            this.dgcCalc.DataPropertyName = "Calc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "0.00;-0.00;\"\"";
            this.dgcCalc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcCalc.HeaderText = "aprēķ. alga";
            this.dgcCalc.MinimumWidth = 7;
            this.dgcCalc.Name = "dgcCalc";
            this.dgcCalc.ReadOnly = true;
            this.dgcCalc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcCalc.ToolTipText = "Aprēķinātā alga";
            this.dgcCalc.Width = 90;
            // 
            // dgcCalcAdvance
            // 
            this.dgcCalcAdvance.DataPropertyName = "CalcAdvance";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "0.00;-0.00;\"\"";
            this.dgcCalcAdvance.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcCalcAdvance.HeaderText = "avanss";
            this.dgcCalcAdvance.MinimumWidth = 7;
            this.dgcCalcAdvance.Name = "dgcCalcAdvance";
            this.dgcCalcAdvance.ReadOnly = true;
            this.dgcCalcAdvance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcCalcAdvance.ToolTipText = "Aprēķināta avansā izmaksājamā summa";
            this.dgcCalcAdvance.Width = 90;
            // 
            // dgcCalcWithhold
            // 
            this.dgcCalcWithhold.DataPropertyName = "CalcWithhold";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "0.00;-0.00;\"\"";
            this.dgcCalcWithhold.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcCalcWithhold.HeaderText = "ieturēt";
            this.dgcCalcWithhold.MinimumWidth = 7;
            this.dgcCalcWithhold.Name = "dgcCalcWithhold";
            this.dgcCalcWithhold.ReadOnly = true;
            this.dgcCalcWithhold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcCalcWithhold.ToolTipText = "Aprēķināti ieturējumi";
            this.dgcCalcWithhold.Width = 90;
            // 
            // dgcCalcT
            // 
            this.dgcCalcT.DataPropertyName = "CalcT";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "0.00;-0.00;\"\"";
            this.dgcCalcT.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcCalcT.HeaderText = "aprēķ. kopā";
            this.dgcCalcT.MinimumWidth = 7;
            this.dgcCalcT.Name = "dgcCalcT";
            this.dgcCalcT.ReadOnly = true;
            this.dgcCalcT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcCalcT.ToolTipText = "Aprēķins kopā";
            this.dgcCalcT.Width = 90;
            // 
            // dgcNotPaid
            // 
            this.dgcNotPaid.DataPropertyName = "NotPaid";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "0.00;-0.00;\"\"";
            this.dgcNotPaid.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcNotPaid.HeaderText = "neizmaks.";
            this.dgcNotPaid.MinimumWidth = 7;
            this.dgcNotPaid.Name = "dgcNotPaid";
            this.dgcNotPaid.ReadOnly = true;
            this.dgcNotPaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcNotPaid.ToolTipText = "Neizmaksātā alga";
            this.dgcNotPaid.Width = 90;
            // 
            // dgcNotPaidAdvance
            // 
            this.dgcNotPaidAdvance.DataPropertyName = "NotPaidAdvance";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "0.00;-0.00;\"\"";
            this.dgcNotPaidAdvance.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcNotPaidAdvance.HeaderText = "avanss";
            this.dgcNotPaidAdvance.MinimumWidth = 7;
            this.dgcNotPaidAdvance.Name = "dgcNotPaidAdvance";
            this.dgcNotPaidAdvance.ReadOnly = true;
            this.dgcNotPaidAdvance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcNotPaidAdvance.ToolTipText = "Neizmaksātā vai avansā izmaksātā summa";
            this.dgcNotPaidAdvance.Width = 90;
            // 
            // dgcNotPaidWithhold
            // 
            this.dgcNotPaidWithhold.DataPropertyName = "NotPaidWithhold";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "0.00;-0.00;\"\"";
            this.dgcNotPaidWithhold.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcNotPaidWithhold.HeaderText = "ieturēt";
            this.dgcNotPaidWithhold.MinimumWidth = 7;
            this.dgcNotPaidWithhold.Name = "dgcNotPaidWithhold";
            this.dgcNotPaidWithhold.ReadOnly = true;
            this.dgcNotPaidWithhold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcNotPaidWithhold.ToolTipText = "Ieturējumi";
            this.dgcNotPaidWithhold.Width = 90;
            // 
            // dgcNotPaidT
            // 
            this.dgcNotPaidT.DataPropertyName = "NotPaidT";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "0.00;-0.00;\"\"";
            this.dgcNotPaidT.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgcNotPaidT.HeaderText = "neizm. kopā";
            this.dgcNotPaidT.MinimumWidth = 7;
            this.dgcNotPaidT.Name = "dgcNotPaidT";
            this.dgcNotPaidT.ReadOnly = true;
            this.dgcNotPaidT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcNotPaidT.ToolTipText = "Neizmaksātā summa kopā";
            this.dgcNotPaidT.Width = 90;
            // 
            // dgcPayT
            // 
            this.dgcPayT.DataPropertyName = "PayT";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "0.00;-0.00;\"\"";
            this.dgcPayT.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgcPayT.HeaderText = "maksāts";
            this.dgcPayT.MinimumWidth = 7;
            this.dgcPayT.Name = "dgcPayT";
            this.dgcPayT.ReadOnly = true;
            this.dgcPayT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcPayT.ToolTipText = "Izmaksātā summa";
            this.dgcPayT.Width = 90;
            // 
            // dgcDiff
            // 
            this.dgcDiff.DataPropertyName = "Diff";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "0.00;-0.00;\"\"";
            this.dgcDiff.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgcDiff.HeaderText = "atlikums";
            this.dgcDiff.MinimumWidth = 7;
            this.dgcDiff.Name = "dgcDiff";
            this.dgcDiff.ReadOnly = true;
            this.dgcDiff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDiff.ToolTipText = "Nesamaksāts vai pārmaksāts";
            this.dgcDiff.Width = 90;
            // 
            // dgcCalcIIN
            // 
            this.dgcCalcIIN.DataPropertyName = "CalcIIN";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "0.00;-0.00;\"\"";
            this.dgcCalcIIN.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgcCalcIIN.HeaderText = "iin apr.";
            this.dgcCalcIIN.MinimumWidth = 7;
            this.dgcCalcIIN.Name = "dgcCalcIIN";
            this.dgcCalcIIN.ReadOnly = true;
            this.dgcCalcIIN.Width = 90;
            // 
            // dgcTakeIIN
            // 
            this.dgcTakeIIN.DataPropertyName = "TakeIIN";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "0.00;-0.00;\"\"";
            this.dgcTakeIIN.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgcTakeIIN.HeaderText = "iin iet.";
            this.dgcTakeIIN.MinimumWidth = 7;
            this.dgcTakeIIN.Name = "dgcTakeIIN";
            this.dgcTakeIIN.ReadOnly = true;
            this.dgcTakeIIN.Width = 90;
            // 
            // dgcCalcVal
            // 
            this.dgcCalcVal.DataPropertyName = "CalcVal";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "0.00;-0.00;\"\"";
            this.dgcCalcVal.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgcCalcVal.HeaderText = "sarēķins";
            this.dgcCalcVal.MinimumWidth = 8;
            this.dgcCalcVal.Name = "dgcCalcVal";
            this.dgcCalcVal.ReadOnly = true;
            this.dgcCalcVal.Width = 90;
            // 
            // Form_PaymentsByPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 562);
            this.Controls.Add(this.sgvRows);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bNav);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_PaymentsByPerson";
            this.Text = "Maksājumu pārskats";
            this.Load += new System.EventHandler(this.Form_PaymentsByPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).EndInit();
            this.bNav.ResumeLayout(false);
            this.bNav.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sgvRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsPersons;
        private System.Windows.Forms.BindingSource bsRows;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmFilter;
        private KlonsLIB.Components.MyMcFlatComboBox cbPerson;
        private KlonsLIB.Components.MyTextBox tbDate2;
        private KlonsLIB.Components.MyTextBox tbDate1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyDataGridView sgvRows;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miMaksājumuPārskats;
        private System.Windows.Forms.ToolStripMenuItem miKasesMaksājumuSarēķins;
        private System.Windows.Forms.ToolStripMenuItem miAvansaMaksājumaProcentsNoPēdējāsAlgas;
        private System.Windows.Forms.ToolStripMenuItem miSaglabātSarēķinātosKasesMaksājumus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcListDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPosTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCalc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCalcAdvance;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCalcWithhold;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCalcT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNotPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNotPaidAdvance;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNotPaidWithhold;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNotPaidT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPayT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCalcIIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTakeIIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCalcVal;
    }
}