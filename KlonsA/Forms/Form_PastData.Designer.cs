namespace KlonsA.Forms
{
    partial class Form_PastData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PastData));
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
            this.dgvPrevMonths = new KlonsLIB.Components.MyDataGridView();
            this.bsPersons = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsPrevMonths = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bnavPrevMonths = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tbFilter = new KlonsLIB.Components.MyTextBox();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dgcIDP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcYR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBruto2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCalDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDaysMt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcHoursMt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPlanDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPlanHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevMonths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPrevMonths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavPrevMonths)).BeginInit();
            this.bnavPrevMonths.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPrevMonths
            // 
            this.dgvPrevMonths.AutoGenerateColumns = false;
            this.dgvPrevMonths.AutoSave = false;
            this.dgvPrevMonths.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrevMonths.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPrevMonths.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrevMonths.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcIDP,
            this.dgcYR,
            this.dgcMT,
            this.dgcBruto,
            this.dgcBruto2,
            this.dgcPay,
            this.dgcCalDays,
            this.dgcDaysMt,
            this.dgcHoursMt,
            this.dgcPlanDays,
            this.dgcPlanHours,
            this.dgcDays,
            this.dgcHours,
            this.dgcID});
            this.dgvPrevMonths.DataSource = this.bsPrevMonths;
            this.dgvPrevMonths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrevMonths.Location = new System.Drawing.Point(0, 28);
            this.dgvPrevMonths.Name = "dgvPrevMonths";
            this.dgvPrevMonths.RowTemplate.Height = 24;
            this.dgvPrevMonths.Size = new System.Drawing.Size(934, 316);
            this.dgvPrevMonths.TabIndex = 0;
            this.dgvPrevMonths.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPrevMonths_MyKeyDown);
            this.dgvPrevMonths.MyCheckForChanges += new System.EventHandler(this.dgvPrevMonths_MyCheckForChanges);
            this.dgvPrevMonths.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrevMonths_CellDoubleClick);
            this.dgvPrevMonths.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvPrevMonths_DefaultValuesNeeded);
            this.dgvPrevMonths.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPrevMonths_RowValidating);
            this.dgvPrevMonths.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPrevMonths_UserDeletingRow);
            // 
            // bsPersons
            // 
            this.bsPersons.DataMember = "PERSONS";
            this.bsPersons.MyDataSource = "KlonsData";
            // 
            // bsPrevMonths
            // 
            this.bsPrevMonths.DataMember = "PASTDATA";
            this.bsPrevMonths.MyDataSource = "KlonsData";
            this.bsPrevMonths.Sort = "YNAME, YR, MT";
            this.bsPrevMonths.UseDataGridView = this.dgvPrevMonths;
            this.bsPrevMonths.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsPrevMonths_ListChanged);
            // 
            // bnavPrevMonths
            // 
            this.bnavPrevMonths.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavPrevMonths.BindingSource = this.bsPrevMonths;
            this.bnavPrevMonths.CountItem = this.bindingNavigatorCountItem;
            this.bnavPrevMonths.CountItemFormat = " no {0}";
            this.bnavPrevMonths.DataGrid = this.dgvPrevMonths;
            this.bnavPrevMonths.DeleteItem = null;
            this.bnavPrevMonths.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavPrevMonths.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavPrevMonths.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.tsbSave});
            this.bnavPrevMonths.Location = new System.Drawing.Point(0, 344);
            this.bnavPrevMonths.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavPrevMonths.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavPrevMonths.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavPrevMonths.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavPrevMonths.Name = "bnavPrevMonths";
            this.bnavPrevMonths.Padding = new System.Windows.Forms.Padding(0, 0, 1, 2);
            this.bnavPrevMonths.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavPrevMonths.SaveItem = null;
            this.bnavPrevMonths.Size = new System.Drawing.Size(934, 34);
            this.bnavPrevMonths.TabIndex = 1;
            this.bnavPrevMonths.Text = "myBindingNavigator1";
            this.bnavPrevMonths.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavPrevMonths_ItemDeleting);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(91, 29);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
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
            // tbFilter
            // 
            this.tbFilter.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbFilter.Location = new System.Drawing.Point(185, 0);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(141, 22);
            this.tbFilter.TabIndex = 2;
            this.tbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "PASTDATA",
        "PERSONS",
        null};
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(934, 28);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(59, 25);
            this.toolStripLabel1.Text = "Filtrēt";
            // 
            // dgcIDP
            // 
            this.dgcIDP.DataPropertyName = "IDP";
            this.dgcIDP.DataSource = this.bsPersons;
            this.dgcIDP.DisplayMember = "ZNAME";
            this.dgcIDP.DisplayStyleForCurrentCellOnly = true;
            this.dgcIDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcIDP.Frozen = true;
            this.dgcIDP.HeaderText = "darbinieks";
            this.dgcIDP.Name = "dgcIDP";
            this.dgcIDP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcIDP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcIDP.ValueMember = "ID";
            this.dgcIDP.Width = 200;
            // 
            // dgcYR
            // 
            this.dgcYR.DataPropertyName = "YR";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcYR.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcYR.HeaderText = "gads";
            this.dgcYR.Name = "dgcYR";
            this.dgcYR.Width = 60;
            // 
            // dgcMT
            // 
            this.dgcMT.DataPropertyName = "MT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcMT.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcMT.HeaderText = "mēnesis";
            this.dgcMT.Name = "dgcMT";
            this.dgcMT.Width = 60;
            // 
            // dgcBruto
            // 
            this.dgcBruto.DataPropertyName = "BRUTO";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.dgcBruto.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcBruto.HeaderText = "darba samaksa";
            this.dgcBruto.Name = "dgcBruto";
            this.dgcBruto.Width = 80;
            // 
            // dgcBruto2
            // 
            this.dgcBruto2.DataPropertyName = "BRUTO2";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dgcBruto2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcBruto2.HeaderText = "bruto alga";
            this.dgcBruto2.Name = "dgcBruto2";
            this.dgcBruto2.Width = 80;
            // 
            // dgcPay
            // 
            this.dgcPay.DataPropertyName = "PAY";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.dgcPay.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcPay.HeaderText = "izmaksāts";
            this.dgcPay.Name = "dgcPay";
            this.dgcPay.Width = 80;
            // 
            // dgcCalDays
            // 
            this.dgcCalDays.DataPropertyName = "CALDAYS";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcCalDays.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcCalDays.HeaderText = "kalend. dienas";
            this.dgcCalDays.Name = "dgcCalDays";
            this.dgcCalDays.ToolTipText = "kalendāra dienas";
            // 
            // dgcDaysMt
            // 
            this.dgcDaysMt.DataPropertyName = "DAYSMT";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcDaysMt.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcDaysMt.HeaderText = "d.dienas mēn.";
            this.dgcDaysMt.Name = "dgcDaysMt";
            this.dgcDaysMt.ToolTipText = "darba dienas mēnesī";
            this.dgcDaysMt.Width = 80;
            // 
            // dgcHoursMt
            // 
            this.dgcHoursMt.DataPropertyName = "HOURSMT";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcHoursMt.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcHoursMt.HeaderText = "d.stundas mēn.";
            this.dgcHoursMt.Name = "dgcHoursMt";
            this.dgcHoursMt.ToolTipText = "darba stundas mēnesī";
            this.dgcHoursMt.Width = 80;
            // 
            // dgcPlanDays
            // 
            this.dgcPlanDays.DataPropertyName = "PLANDAYS";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcPlanDays.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgcPlanDays.HeaderText = "plāna dienas";
            this.dgcPlanDays.Name = "dgcPlanDays";
            this.dgcPlanDays.Width = 80;
            // 
            // dgcPlanHours
            // 
            this.dgcPlanHours.DataPropertyName = "PLANHOURS";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcPlanHours.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgcPlanHours.HeaderText = "plāna stundas";
            this.dgcPlanHours.Name = "dgcPlanHours";
            this.dgcPlanHours.Width = 80;
            // 
            // dgcDays
            // 
            this.dgcDays.DataPropertyName = "DAYS";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcDays.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgcDays.HeaderText = "nostr. dienas";
            this.dgcDays.Name = "dgcDays";
            this.dgcDays.ToolTipText = "nostrādātās dienas";
            this.dgcDays.Width = 80;
            // 
            // dgcHours
            // 
            this.dgcHours.DataPropertyName = "HOURS";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcHours.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgcHours.HeaderText = "nostr. stundas";
            this.dgcHours.Name = "dgcHours";
            this.dgcHours.ToolTipText = "nostrādātās stundas";
            this.dgcHours.Width = 80;
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.Name = "dgcID";
            this.dgcID.Visible = false;
            // 
            // Form_PastData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 378);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.dgvPrevMonths);
            this.Controls.Add(this.bnavPrevMonths);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_PastData";
            this.Text = "Dati pirms uzskaites sākuma";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_PastData_FormClosed);
            this.Load += new System.EventHandler(this.Form_PastData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrevMonths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPrevMonths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavPrevMonths)).EndInit();
            this.bnavPrevMonths.ResumeLayout(false);
            this.bnavPrevMonths.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Components.MyDataGridView dgvPrevMonths;
        private KlonsLIB.Components.MyBindingNavigator bnavPrevMonths;
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
        private KlonsLIB.Data.MyBindingSource bsPrevMonths;
        private KlonsLIB.Data.MyBindingSource bsPersons;
        private KlonsLIB.Components.MyTextBox tbFilter;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcIDP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcYR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBruto2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCalDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDaysMt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcHoursMt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPlanDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPlanHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
    }
}