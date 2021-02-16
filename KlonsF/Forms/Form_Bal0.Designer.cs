using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.Forms
{
    partial class Form_Bal0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Bal0));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsBal0 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bnavB0 = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.dgvBal0 = new KlonsLIB.Components.MyDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBal0AC11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBal0AC24 = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.bsAc24 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcBal0Clid = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.bsClisd = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcSummDC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSummCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCurRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSummD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSummC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAcc = new KlonsLIB.Components.MyPickRowTextBox();
            this.bsAc21 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.lbSumDeb = new KlonsLIB.Components.MyLabel();
            this.lbSumKred = new KlonsLIB.Components.MyLabel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsBal0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavB0)).BeginInit();
            this.bnavB0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBal0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAc24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClisd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAc21)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBal0
            // 
            this.bsBal0.AutoSaveOnDelete = true;
            this.bsBal0.DataMember = "Bal0";
            this.bsBal0.MyDataSource = "KlonsData";
            this.bsBal0.Name2 = "Bal0";
            this.bsBal0.Sort = "AC11";
            this.bsBal0.MyBeforeRowInsert += new KlonsLIB.Data.MyRowUpdateEventHandler(this.bsBal0_MyBeforeRowInsert);
            this.bsBal0.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsBal0_ListChanged);
            // 
            // bnavB0
            // 
            this.bnavB0.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavB0.BindingSource = this.bsBal0;
            this.bnavB0.CountItem = this.bindingNavigatorCountItem;
            this.bnavB0.CountItemFormat = " no {0}";
            this.bnavB0.DataGrid = this.dgvBal0;
            this.bnavB0.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnavB0.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavB0.ImageScalingSize = new System.Drawing.Size(23, 26);
            this.bnavB0.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnavB0.Location = new System.Drawing.Point(0, 459);
            this.bnavB0.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavB0.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavB0.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavB0.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavB0.Name = "bnavB0";
            this.bnavB0.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavB0.SaveItem = null;
            this.bnavB0.Size = new System.Drawing.Size(907, 39);
            this.bnavB0.TabIndex = 6;
            this.bnavB0.Text = "bindingNavigator1";
            this.bnavB0.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavB0_ItemDeleting);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(92, 34);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 34);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Skaits";
            // 
            // dgvBal0
            // 
            this.dgvBal0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBal0.AutoGenerateColumns = false;
            this.dgvBal0.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBal0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBal0.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dgcBal0AC11,
            this.dgcBal0AC24,
            this.dgcBal0Clid,
            this.dgcSummDC,
            this.dgcSummCC,
            this.dgcCur,
            this.dgcCurRate,
            this.dgcSummD,
            this.dgcSummC});
            this.dgvBal0.DataSource = this.bsBal0;
            this.dgvBal0.Location = new System.Drawing.Point(0, 40);
            this.dgvBal0.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBal0.Name = "dgvBal0";
            this.dgvBal0.RowHeadersWidth = 62;
            this.dgvBal0.RowTemplate.Height = 28;
            this.dgvBal0.Size = new System.Drawing.Size(907, 415);
            this.dgvBal0.TabIndex = 1;
            this.dgvBal0.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBal0_MyKeyDown);
            this.dgvBal0.MyCheckForChanges += new System.EventHandler(this.dgvBal0_MyCheckForChanges);
            this.dgvBal0.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBal0_CellDoubleClick);
            this.dgvBal0.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBal0_CellEndEdit);
            this.dgvBal0.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dgvBal0_CellToolTipTextNeeded);
            this.dgvBal0.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvBal0_UserDeletingRow);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 9;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dgcBal0AC11
            // 
            this.dgcBal0AC11.DataPropertyName = "AC11";
            this.dgcBal0AC11.HeaderText = "konts";
            this.dgcBal0AC11.MinimumWidth = 9;
            this.dgcBal0AC11.Name = "dgcBal0AC11";
            this.dgcBal0AC11.ToolTipText = "Bilances konts";
            this.dgcBal0AC11.Width = 72;
            // 
            // dgcBal0AC24
            // 
            this.dgcBal0AC24.ColumnNames = new string[] {
        "idx",
        "name"};
            this.dgcBal0AC24.ColumnWidths = "100;300";
            this.dgcBal0AC24.DataPropertyName = "AC24";
            this.dgcBal0AC24.DataSource = this.bsAc24;
            this.dgcBal0AC24.DisplayMember = "idx";
            this.dgcBal0AC24.HeaderText = "paz.4";
            this.dgcBal0AC24.MaxDropDownItems = 15;
            this.dgcBal0AC24.MinimumWidth = 9;
            this.dgcBal0AC24.Name = "dgcBal0AC24";
            this.dgcBal0AC24.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcBal0AC24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcBal0AC24.ToolTipText = "Kontējuma 4. pazīme";
            this.dgcBal0AC24.ValueMember = "idx";
            this.dgcBal0AC24.Width = 72;
            // 
            // bsAc24
            // 
            this.bsAc24.DataMember = "AcP24";
            this.bsAc24.MyDataSource = "KlonsData";
            this.bsAc24.Name2 = "bsAc24";
            // 
            // dgcBal0Clid
            // 
            this.dgcBal0Clid.ColumnNames = new string[] {
        "clid",
        "name"};
            this.dgcBal0Clid.ColumnWidths = "150;400";
            this.dgcBal0Clid.DataPropertyName = "ClId";
            this.dgcBal0Clid.DataSource = this.bsClisd;
            this.dgcBal0Clid.DisplayMember = "clid";
            this.dgcBal0Clid.HeaderText = "perosna";
            this.dgcBal0Clid.MaxDropDownItems = 15;
            this.dgcBal0Clid.MinimumWidth = 9;
            this.dgcBal0Clid.Name = "dgcBal0Clid";
            this.dgcBal0Clid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcBal0Clid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcBal0Clid.ValueMember = "clid";
            this.dgcBal0Clid.Width = 117;
            // 
            // bsClisd
            // 
            this.bsClisd.DataMember = "Persons";
            this.bsClisd.MyDataSource = "KlonsData";
            this.bsClisd.Name2 = "bsClisd";
            // 
            // dgcSummDC
            // 
            this.dgcSummDC.DataPropertyName = "SummDC";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.dgcSummDC.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcSummDC.HeaderText = "debetā";
            this.dgcSummDC.MinimumWidth = 9;
            this.dgcSummDC.Name = "dgcSummDC";
            this.dgcSummDC.ToolTipText = "summa debetā, norādītajā valūtā";
            this.dgcSummDC.Width = 108;
            // 
            // dgcSummCC
            // 
            this.dgcSummCC.DataPropertyName = "SummCC";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dgcSummCC.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcSummCC.HeaderText = "kredītā";
            this.dgcSummCC.MinimumWidth = 9;
            this.dgcSummCC.Name = "dgcSummCC";
            this.dgcSummCC.ToolTipText = "summa kredītā, norādītajā valūtā";
            this.dgcSummCC.Width = 108;
            // 
            // dgcCur
            // 
            this.dgcCur.DataPropertyName = "Cur";
            this.dgcCur.HeaderText = "valūta";
            this.dgcCur.MaxInputLength = 3;
            this.dgcCur.MinimumWidth = 9;
            this.dgcCur.Name = "dgcCur";
            this.dgcCur.ToolTipText = "valūta (EUR, USD, RUR, ...)";
            this.dgcCur.Width = 54;
            // 
            // dgcCurRate
            // 
            this.dgcCurRate.DataPropertyName = "CurRate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgcCurRate.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcCurRate.HeaderText = "kurss";
            this.dgcCurRate.MinimumWidth = 9;
            this.dgcCurRate.Name = "dgcCurRate";
            this.dgcCurRate.ToolTipText = "valūtas kurss";
            this.dgcCurRate.Width = 72;
            // 
            // dgcSummD
            // 
            this.dgcSummD.DataPropertyName = "SummD";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.dgcSummD.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcSummD.HeaderText = "debetā";
            this.dgcSummD.MinimumWidth = 9;
            this.dgcSummD.Name = "dgcSummD";
            this.dgcSummD.ReadOnly = true;
            this.dgcSummD.ToolTipText = "summa debetā EUR";
            this.dgcSummD.Width = 108;
            // 
            // dgcSummC
            // 
            this.dgcSummC.DataPropertyName = "SummC";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.dgcSummC.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcSummC.HeaderText = "kredītā";
            this.dgcSummC.MinimumWidth = 9;
            this.dgcSummC.Name = "dgcSummC";
            this.dgcSummC.ReadOnly = true;
            this.dgcSummC.ToolTipText = "summa kredītā EUR";
            this.dgcSummC.Width = 108;
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(93, 34);
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
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(46, 37);
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
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(34, 34);
            this.tsbSave.Text = "Saglabāt datus";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kods:";
            // 
            // tbAcc
            // 
            this.tbAcc.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbAcc.ColumnNr = 1;
            this.tbAcc.DataMember = null;
            this.tbAcc.DataSource = this.bsAc21;
            this.tbAcc.Location = new System.Drawing.Point(62, 8);
            this.tbAcc.Margin = new System.Windows.Forms.Padding(2);
            this.tbAcc.Name = "tbAcc";
            this.tbAcc.SelectedIndex = -1;
            this.tbAcc.Size = new System.Drawing.Size(92, 26);
            this.tbAcc.TabIndex = 0;
            // 
            // bsAc21
            // 
            this.bsAc21.DataMember = "AcP21";
            this.bsAc21.MyDataSource = "KlonsData";
            this.bsAc21.Name2 = "bsAc21";
            // 
            // lbSumDeb
            // 
            this.lbSumDeb.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbSumDeb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbSumDeb.Location = new System.Drawing.Point(267, 8);
            this.lbSumDeb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSumDeb.Name = "lbSumDeb";
            this.lbSumDeb.Padding = new System.Windows.Forms.Padding(2);
            this.lbSumDeb.Size = new System.Drawing.Size(119, 26);
            this.lbSumDeb.TabIndex = 4;
            this.lbSumDeb.Text = "0.00";
            this.lbSumDeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSumKred
            // 
            this.lbSumKred.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbSumKred.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbSumKred.Location = new System.Drawing.Point(390, 8);
            this.lbSumKred.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSumKred.Name = "lbSumKred";
            this.lbSumKred.Padding = new System.Windows.Forms.Padding(2);
            this.lbSumKred.Size = new System.Drawing.Size(119, 26);
            this.lbSumKred.TabIndex = 5;
            this.lbSumKred.Text = "0.00";
            this.lbSumKred.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kopsummas:";
            // 
            // Form_Bal0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(907, 498);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbSumKred);
            this.Controls.Add(this.lbSumDeb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAcc);
            this.Controls.Add(this.dgvBal0);
            this.Controls.Add(this.bnavB0);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_Bal0";
            this.Text = "Sākuma atlikumi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormBal0_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBal0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavB0)).EndInit();
            this.bnavB0.ResumeLayout(false);
            this.bnavB0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBal0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAc24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClisd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAc21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingSource bsBal0;
        private MyBindingNavigator bnavB0;
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
        private MyDataGridView dgvBal0;
        private System.Windows.Forms.Label label1;
        private MyPickRowTextBox tbAcc;
        private MyBindingSource bsAc21;
        private MyBindingSource bsAc24;
        private MyBindingSource bsClisd;
        private MyLabel lbSumDeb;
        private MyLabel lbSumKred;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBal0AC11;
        private MyDgvMcCBColumn dgcBal0AC24;
        private MyDgvMcCBColumn dgcBal0Clid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSummDC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSummCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCur;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCurRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSummD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSummC;
    }
}