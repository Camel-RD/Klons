namespace KlonsA.Forms
{
    partial class Form_SalarySheets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SalarySheets));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslPeriod = new System.Windows.Forms.ToolStripLabel();
            this.bnavSar = new KlonsLIB.Components.MyBindingNavigator();
            this.bsSar = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvSar = new KlonsLIB.Components.MyDataGridView();
            this.dgcYR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDEP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsDep = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcIsTemp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.bsPersons = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsAmati = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsAmatiF = new KlonsLIB.Data.MyBindingSource(this.components);
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnavSar)).BeginInit();
            this.bnavSar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmatiF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslPeriod});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(866, 29);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslPeriod
            // 
            this.tslPeriod.Name = "tslPeriod";
            this.tslPeriod.Size = new System.Drawing.Size(84, 25);
            this.tslPeriod.Text = "Periods:";
            // 
            // bnavSar
            // 
            this.bnavSar.AddNewItem = null;
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
            this.tsbOpen,
            this.tsbNew,
            this.tsbDelete,
            this.tsbSave});
            this.bnavSar.Location = new System.Drawing.Point(0, 404);
            this.bnavSar.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavSar.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavSar.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavSar.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavSar.Name = "bnavSar";
            this.bnavSar.Padding = new System.Windows.Forms.Padding(0, 0, 1, 2);
            this.bnavSar.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavSar.SaveItem = null;
            this.bnavSar.Size = new System.Drawing.Size(866, 35);
            this.bnavSar.TabIndex = 4;
            this.bnavSar.Text = "myBindingNavigator1";
            this.bnavSar.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavSar_ItemDeleting);
            // 
            // bsSar
            // 
            this.bsSar.DataMember = "SALARY_SHEETS";
            this.bsSar.Filter = "KIND = 0 AND ISFIRSTMT = FALSE";
            this.bsSar.MyDataSource = "KlonsData";
            this.bsSar.Sort = "YR,MT,SNR";
            this.bsSar.UseDataGridView = this.dgvSar;
            this.bsSar.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsSar_ListChanged);
            // 
            // dgvSar
            // 
            this.dgvSar.AllowUserToAddRows = false;
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
            this.dgcYR,
            this.dgcMT,
            this.dgcSNR,
            this.dgcDT1,
            this.dgcDT2,
            this.dgcDescr,
            this.dgcDEP,
            this.dgcIsTemp,
            this.dgcID});
            this.dgvSar.DataSource = this.bsSar;
            this.dgvSar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSar.Location = new System.Drawing.Point(0, 29);
            this.dgvSar.Name = "dgvSar";
            this.dgvSar.RowHeadersWidth = 53;
            this.dgvSar.RowTemplate.Height = 24;
            this.dgvSar.Size = new System.Drawing.Size(866, 375);
            this.dgvSar.TabIndex = 6;
            this.dgvSar.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSar_MyKeyDown);
            this.dgvSar.MyCheckForChanges += new System.EventHandler(this.dgvSar_MyCheckForChanges);
            this.dgvSar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSar_CellDoubleClick);
            this.dgvSar.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvSar_CellParsing);
            this.dgvSar.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSar_CellValidating);
            this.dgvSar.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSar_RowValidating_1);
            this.dgvSar.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvSar_UserDeletingRow);
            this.dgvSar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSar_KeyDown);
            // 
            // dgcYR
            // 
            this.dgcYR.DataPropertyName = "YR";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcYR.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcYR.HeaderText = "gads";
            this.dgcYR.MinimumWidth = 7;
            this.dgcYR.Name = "dgcYR";
            this.dgcYR.ReadOnly = true;
            this.dgcYR.Width = 60;
            // 
            // dgcMT
            // 
            this.dgcMT.DataPropertyName = "MT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcMT.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcMT.HeaderText = "mēn.";
            this.dgcMT.MinimumWidth = 7;
            this.dgcMT.Name = "dgcMT";
            this.dgcMT.ReadOnly = true;
            this.dgcMT.ToolTipText = "mēnesis";
            this.dgcMT.Width = 40;
            // 
            // dgcSNR
            // 
            this.dgcSNR.DataPropertyName = "SNR";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcSNR.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcSNR.HeaderText = "npk.";
            this.dgcSNR.MinimumWidth = 7;
            this.dgcSNR.Name = "dgcSNR";
            this.dgcSNR.ToolTipText = "numurs pēc kārtas";
            this.dgcSNR.Width = 50;
            // 
            // dgcDT1
            // 
            this.dgcDT1.DataPropertyName = "DT1";
            dataGridViewCellStyle5.Format = "dd.MM.yyyy";
            this.dgcDT1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcDT1.HeaderText = "datums no";
            this.dgcDT1.MinimumWidth = 7;
            this.dgcDT1.Name = "dgcDT1";
            this.dgcDT1.ReadOnly = true;
            this.dgcDT1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDT1.Width = 85;
            // 
            // dgcDT2
            // 
            this.dgcDT2.DataPropertyName = "DT2";
            dataGridViewCellStyle6.Format = "dd.MM.yyyy";
            this.dgcDT2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcDT2.HeaderText = "datums līdz";
            this.dgcDT2.MinimumWidth = 7;
            this.dgcDT2.Name = "dgcDT2";
            this.dgcDT2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDT2.Width = 85;
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "DESCR";
            this.dgcDescr.HeaderText = "apraksts";
            this.dgcDescr.MinimumWidth = 7;
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.Width = 200;
            // 
            // dgcDEP
            // 
            this.dgcDEP.DataPropertyName = "DEP";
            this.dgcDEP.DataSource = this.bsDep;
            this.dgcDEP.DisplayMember = "DESCR";
            this.dgcDEP.DisplayStyleForCurrentCellOnly = true;
            this.dgcDEP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcDEP.HeaderText = "struktūrv.";
            this.dgcDEP.MinimumWidth = 7;
            this.dgcDEP.Name = "dgcDEP";
            this.dgcDEP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcDEP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcDEP.ToolTipText = "struktūrvienība";
            this.dgcDEP.ValueMember = "ID";
            this.dgcDEP.Width = 200;
            // 
            // bsDep
            // 
            this.bsDep.DataMember = "DEPARTMENTS";
            this.bsDep.MyDataSource = "KlonsData";
            // 
            // dgcIsTemp
            // 
            this.dgcIsTemp.DataPropertyName = "IS_TEMP";
            this.dgcIsTemp.FalseValue = "0";
            this.dgcIsTemp.HeaderText = "starpapr.";
            this.dgcIsTemp.MinimumWidth = 7;
            this.dgcIsTemp.Name = "dgcIsTemp";
            this.dgcIsTemp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcIsTemp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcIsTemp.ToolTipText = "palīgaprēķiniem";
            this.dgcIsTemp.TrueValue = "1";
            this.dgcIsTemp.Width = 70;
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.MinimumWidth = 7;
            this.dgcID.Name = "dgcID";
            this.dgcID.Visible = false;
            this.dgcID.Width = 130;
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
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(30, 29);
            this.bindingNavigatorMoveFirstItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(30, 29);
            this.bindingNavigatorMovePreviousItem.Text = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 33);
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
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(30, 29);
            this.bindingNavigatorMoveNextItem.Text = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(30, 29);
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = global::KlonsA.Properties.Resources.open;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(88, 29);
            this.tsbOpen.Text = "Atvērt";
            this.tsbOpen.ToolTipText = "Atvērt aprēķina lapu";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::KlonsA.Properties.Resources._new;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(91, 29);
            this.tsbNew.Text = "Jauns";
            this.tsbNew.ToolTipText = "Jauna algas aprēķina lapa";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::KlonsA.Properties.Resources.delete;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(87, 29);
            this.tsbDelete.Text = "Dzēst";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(30, 29);
            this.tsbSave.Text = "Saglabāt";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // bsPersons
            // 
            this.bsPersons.DataMember = "PERSONS";
            this.bsPersons.Filter = "USED = 1";
            this.bsPersons.MyDataSource = "KlonsData";
            this.bsPersons.Sort = "LNAME,FNAME";
            // 
            // bsAmati
            // 
            this.bsAmati.DataMember = "POSITIONS";
            this.bsAmati.Filter = "USED =1";
            this.bsAmati.MyDataSource = "KlonsData";
            // 
            // bsAmatiF
            // 
            this.bsAmatiF.DataMember = "POSITIONS";
            this.bsAmatiF.Filter = "USED =1";
            this.bsAmatiF.MyDataSource = "KlonsData";
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "SALARY_SHEETS",
        "SALARY_SHEETS_R",
        "SALARY_PLUSMINUS",
        null};
            // 
            // Form_SalarySheets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 439);
            this.Controls.Add(this.dgvSar);
            this.Controls.Add(this.bnavSar);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_SalarySheets";
            this.Text = "Algas aprēķinu lapas";
            this.Load += new System.EventHandler(this.Form_SalarySheets_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnavSar)).EndInit();
            this.bnavSar.ResumeLayout(false);
            this.bnavSar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmatiF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslPeriod;
        private KlonsLIB.Components.MyBindingNavigator bnavSar;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private KlonsLIB.Data.MyBindingSource bsSar;
        private KlonsLIB.Data.MyBindingSource bsPersons;
        private KlonsLIB.Data.MyBindingSource bsAmati;
        private KlonsLIB.Data.MyBindingSource bsAmatiF;
        private KlonsLIB.Components.MyDataGridView dgvSar;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private KlonsLIB.Data.MyBindingSource bsDep;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcYR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescr;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcDEP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgcIsTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
    }
}