﻿namespace KlonsA.Forms
{
    partial class Form_TimeSheets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TimeSheets));
            this.bnavSar = new KlonsLIB.Components.MyBindingNavigator();
            this.bsSar = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsSarR = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.dgvSar = new KlonsLIB.Components.MyDataGridView();
            this.dgcSarId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarYr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarMt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarSNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarDep = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsDep = new KlonsLIB.Data.MyBindingSource(this.components);
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
            this.bsSH = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsPers = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsPlan = new KlonsLIB.Data.MyBindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslPeriod = new System.Windows.Forms.ToolStripLabel();
            this.bsPlanaVeids = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.bsAmati = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsAmatiF = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsDarbaLaiks = new KlonsLIB.Data.MyBindingSource(this.components);
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.bnavSar)).BeginInit();
            this.bnavSar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSarR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlan)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanaVeids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmatiF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDarbaLaiks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
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
            this.bnavSar.Location = new System.Drawing.Point(0, 407);
            this.bnavSar.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavSar.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavSar.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavSar.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavSar.Name = "bnavSar";
            this.bnavSar.Padding = new System.Windows.Forms.Padding(0, 0, 1, 2);
            this.bnavSar.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavSar.Size = new System.Drawing.Size(710, 34);
            this.bnavSar.TabIndex = 0;
            this.bnavSar.Text = "myBindingNavigator1";
            this.bnavSar.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavSar_ItemDeleting);
            // 
            // bsSar
            // 
            this.bsSar.ChildBS = this.bsSarR;
            this.bsSar.DataMember = "TIMESHEET_LISTS";
            this.bsSar.Filter = "ISFIRSTMT = FALSE";
            this.bsSar.MyDataSource = "KlonsData";
            this.bsSar.Name2 = "bsSar";
            this.bsSar.Sort = "YR,MT,SNR";
            this.bsSar.UseDataGridView = this.dgvSar;
            this.bsSar.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsSar_ListChanged);
            // 
            // bsSarR
            // 
            this.bsSarR.DataMember = "FK_TIMESHEET_LISTS_R_IDS";
            this.bsSarR.DataSource = this.bsSar;
            this.bsSarR.Name2 = "bsSarR";
            this.bsSarR.Sort = "SNR";
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
            this.dgcSarId,
            this.dgcSarYr,
            this.dgcSarMt,
            this.dgcSarSNR,
            this.dgcSarDescr,
            this.dgcSarDep});
            this.dgvSar.DataSource = this.bsSar;
            this.dgvSar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSar.Location = new System.Drawing.Point(0, 28);
            this.dgvSar.Name = "dgvSar";
            this.dgvSar.RowTemplate.Height = 24;
            this.dgvSar.Size = new System.Drawing.Size(710, 379);
            this.dgvSar.TabIndex = 0;
            this.dgvSar.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSar_MyKeyDown);
            this.dgvSar.MyCheckForChanges += new System.EventHandler(this.dgvSar_MyCheckForChanges);
            this.dgvSar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSar_CellDoubleClick);
            this.dgvSar.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvSar_UserDeletingRow);
            // 
            // dgcSarId
            // 
            this.dgcSarId.DataPropertyName = "ID";
            this.dgcSarId.HeaderText = "ID";
            this.dgcSarId.Name = "dgcSarId";
            this.dgcSarId.Visible = false;
            // 
            // dgcSarYr
            // 
            this.dgcSarYr.DataPropertyName = "YR";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcSarYr.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcSarYr.HeaderText = "gads";
            this.dgcSarYr.Name = "dgcSarYr";
            this.dgcSarYr.ReadOnly = true;
            this.dgcSarYr.Width = 50;
            // 
            // dgcSarMt
            // 
            this.dgcSarMt.DataPropertyName = "MT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcSarMt.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcSarMt.HeaderText = "mēn";
            this.dgcSarMt.Name = "dgcSarMt";
            this.dgcSarMt.ReadOnly = true;
            this.dgcSarMt.Width = 40;
            // 
            // dgcSarSNR
            // 
            this.dgcSarSNR.DataPropertyName = "SNR";
            this.dgcSarSNR.HeaderText = "npk";
            this.dgcSarSNR.Name = "dgcSarSNR";
            this.dgcSarSNR.Width = 40;
            // 
            // dgcSarDescr
            // 
            this.dgcSarDescr.DataPropertyName = "DESCR";
            this.dgcSarDescr.HeaderText = "apraksts";
            this.dgcSarDescr.Name = "dgcSarDescr";
            this.dgcSarDescr.Width = 300;
            // 
            // dgcSarDep
            // 
            this.dgcSarDep.DataPropertyName = "DEP";
            this.dgcSarDep.DataSource = this.bsDep;
            this.dgcSarDep.DisplayMember = "DESCR";
            this.dgcSarDep.DisplayStyleForCurrentCellOnly = true;
            this.dgcSarDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcSarDep.HeaderText = "struktūrv.";
            this.dgcSarDep.Name = "dgcSarDep";
            this.dgcSarDep.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcSarDep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcSarDep.ValueMember = "ID";
            this.dgcSarDep.Width = 200;
            // 
            // bsDep
            // 
            this.bsDep.DataMember = "DEPARTMENTS";
            this.bsDep.Filter = "";
            this.bsDep.MyDataSource = "KlonsData";
            this.bsDep.Name2 = "bsDep";
            this.bsDep.Sort = "id";
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
            this.tsbSave.Size = new System.Drawing.Size(25, 29);
            this.tsbSave.Text = "Saglabāt";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // bsSH
            // 
            this.bsSH.DataMember = "TIMESHEET_TEMPL";
            this.bsSH.MyDataSource = "KlonsData";
            this.bsSH.Name2 = "bsSH";
            this.bsSH.Sort = "SNR";
            // 
            // bsPers
            // 
            this.bsPers.DataMember = "PERSONS";
            this.bsPers.MyDataSource = "KlonsData";
            this.bsPers.Name2 = "bsPers";
            this.bsPers.Sort = "ZNAME";
            // 
            // bsPlan
            // 
            this.bsPlan.DataMember = "TIMEPLAN_LIST";
            this.bsPlan.MyDataSource = "KlonsData";
            this.bsPlan.Name2 = "bsPlan";
            this.bsPlan.Sort = "SNR";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslPeriod});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(710, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslPeriod
            // 
            this.tslPeriod.Name = "tslPeriod";
            this.tslPeriod.Size = new System.Drawing.Size(84, 25);
            this.tslPeriod.Text = "Periods:";
            // 
            // bsPlanaVeids
            // 
            this.bsPlanaVeids.Name2 = null;
            // 
            // bsAmati
            // 
            this.bsAmati.DataMember = "POSITIONS";
            this.bsAmati.Filter = "used=1";
            this.bsAmati.MyDataSource = "KlonsData";
            this.bsAmati.Name2 = null;
            this.bsAmati.Sort = "id";
            // 
            // bsAmatiF
            // 
            this.bsAmatiF.DataMember = "POSITIONS";
            this.bsAmatiF.Filter = "used=1";
            this.bsAmatiF.MyDataSource = "KlonsData";
            this.bsAmatiF.Name2 = null;
            this.bsAmatiF.Sort = "id";
            // 
            // bsDarbaLaiks
            // 
            this.bsDarbaLaiks.DataMember = "TIMESHEET";
            this.bsDarbaLaiks.MyDataSource = "KlonsData";
            this.bsDarbaLaiks.Name2 = null;
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "TIMESHEET_LISTS",
        "TIMESHEET_LISTS_R",
        "TIMESHEET",
        null};
            // 
            // Form_TimeSheets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 441);
            this.Controls.Add(this.dgvSar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.bnavSar);
            this.MyToolStrip = this.toolStrip1;
            this.Name = "Form_TimeSheets";
            this.Text = "Darba laika uzskaites lapas";
            this.Load += new System.EventHandler(this.Form_TimeSheets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnavSar)).EndInit();
            this.bnavSar.ResumeLayout(false);
            this.bnavSar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSarR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlan)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanaVeids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmatiF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDarbaLaiks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private KlonsLIB.Components.MyDataGridView dgvSar;
        private KlonsLIB.Data.MyBindingSource bsSar;
        private KlonsLIB.Data.MyBindingSource2 bsSarR;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private KlonsLIB.Data.MyBindingSource bsSH;
        private KlonsLIB.Data.MyBindingSource bsDep;
        private KlonsLIB.Data.MyBindingSource bsPers;
        private KlonsLIB.Data.MyBindingSource bsPlan;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private KlonsLIB.Data.MyBindingSource2 bsPlanaVeids;
        private KlonsLIB.Data.MyBindingSource bsAmati;
        private KlonsLIB.Data.MyBindingSource bsAmatiF;
        private KlonsLIB.Data.MyBindingSource bsDarbaLaiks;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private System.Windows.Forms.ToolStripLabel tslPeriod;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarYr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarMt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarSNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarDescr;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcSarDep;
    }
}