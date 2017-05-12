using KlonsLIB.Components;

namespace KlonsA.Forms
{
    partial class Form_Plan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Plan));
            this.bsPlanuSar = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsPlans = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvPlans = new KlonsLIB.Components.MyDataGridView();
            this.dgcNPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIDP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcKind1 = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcV1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcV31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcK1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcYR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsK1 = new System.Windows.Forms.BindingSource(this.components);
            this.bnavPlans = new KlonsLIB.Components.MyBindingNavigator();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslPeriod = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cbYR = new System.Windows.Forms.ToolStripComboBox();
            this.cbMT = new System.Windows.Forms.ToolStripComboBox();
            this.myStyleDefs1 = new KlonsA.Classes.MyStyleDefs();
            this.cmsMenuMarkDay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miDD = new System.Windows.Forms.ToolStripMenuItem();
            this.miBD = new System.Windows.Forms.ToolStripMenuItem();
            this.miSD = new System.Windows.Forms.ToolStripMenuItem();
            this.miDDSD = new System.Windows.Forms.ToolStripMenuItem();
            this.miSDDD = new System.Windows.Forms.ToolStripMenuItem();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.darbaLaikaKopplānsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izveidotPlānaIerakstusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miFillRow = new System.Windows.Forms.ToolStripMenuItem();
            this.miFillList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanuSar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsK1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavPlans)).BeginInit();
            this.bnavPlans.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.cmsMenuMarkDay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsPlanuSar
            // 
            this.bsPlanuSar.DataMember = "TIMEPLAN_LIST";
            this.bsPlanuSar.MyDataSource = "KlonsData";
            this.bsPlanuSar.Name2 = null;
            // 
            // bsPlans
            // 
            this.bsPlans.DataMember = "TIMESHEET";
            this.bsPlans.Filter = "kind1=0 or kind1=1";
            this.bsPlans.MyDataSource = "KlonsData";
            this.bsPlans.Name2 = null;
            this.bsPlans.UseDataGridView = this.dgvPlans;
            this.bsPlans.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsPlans_ListChanged);
            // 
            // dgvPlans
            // 
            this.dgvPlans.AllowUserToDeleteRows = false;
            this.dgvPlans.AutoGenerateColumns = false;
            this.dgvPlans.AutoSave = false;
            this.dgvPlans.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPlans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcNPK,
            this.dgcIDP,
            this.dgcKind1,
            this.dgcV1,
            this.dgcV2,
            this.dgcV3,
            this.dgcV4,
            this.dgcV5,
            this.dgcV6,
            this.dgcV7,
            this.dgcV8,
            this.dgcV9,
            this.dgcV10,
            this.dgcV11,
            this.dgcV12,
            this.dgcV13,
            this.dgcV14,
            this.dgcV15,
            this.dgcV16,
            this.dgcV17,
            this.dgcV18,
            this.dgcV19,
            this.dgcV20,
            this.dgcV21,
            this.dgcV22,
            this.dgcV23,
            this.dgcV24,
            this.dgcV25,
            this.dgcV26,
            this.dgcV27,
            this.dgcV28,
            this.dgcV29,
            this.dgcV30,
            this.dgcV31,
            this.dgcK1,
            this.dgcID,
            this.dgcYR,
            this.dgcMT});
            this.dgvPlans.DataSource = this.bsPlans;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlans.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPlans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlans.Location = new System.Drawing.Point(0, 72);
            this.dgvPlans.Name = "dgvPlans";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlans.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPlans.RowTemplate.Height = 24;
            this.dgvPlans.Size = new System.Drawing.Size(816, 262);
            this.dgvPlans.TabIndex = 7;
            this.dgvPlans.UseMyContextmenu = false;
            this.dgvPlans.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPlans_MyKeyDown);
            this.dgvPlans.MyCheckForChanges += new System.EventHandler(this.dgvPlans_MyCheckForChanges);
            this.dgvPlans.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPlans_CellBeginEdit);
            this.dgvPlans.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvPlans_CellContextMenuStripNeeded);
            this.dgvPlans.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlans_CellDoubleClick);
            this.dgvPlans.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlans_CellEndEdit);
            this.dgvPlans.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPlans_CellFormatting);
            this.dgvPlans.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvPlans_CellParsing);
            this.dgvPlans.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvPlans_DefaultValuesNeeded);
            this.dgvPlans.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPlans_EditingControlShowing);
            this.dgvPlans.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPlans_UserDeletingRow);
            // 
            // dgcNPK
            // 
            this.dgcNPK.DataPropertyName = "SNR";
            this.dgcNPK.Frozen = true;
            this.dgcNPK.HeaderText = "npk.";
            this.dgcNPK.Name = "dgcNPK";
            this.dgcNPK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgcNPK.Width = 40;
            // 
            // dgcIDP
            // 
            this.dgcIDP.DataPropertyName = "IDP";
            this.dgcIDP.DataSource = this.bsPlanuSar;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgcIDP.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcIDP.DisplayMember = "DESCR";
            this.dgcIDP.DisplayStyleForCurrentCellOnly = true;
            this.dgcIDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcIDP.Frozen = true;
            this.dgcIDP.HeaderText = "plāns";
            this.dgcIDP.Name = "dgcIDP";
            this.dgcIDP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcIDP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgcIDP.ValueMember = "ID";
            this.dgcIDP.Width = 140;
            // 
            // dgcKind1
            // 
            this.dgcKind1.ColumnNames = new string[] {
        "col1",
        "col2"};
            this.dgcKind1.ColumnWidths = "0;80";
            this.dgcKind1.DataPropertyName = "KIND1";
            this.dgcKind1.DisplayMember = "col2";
            this.dgcKind1.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.dgcKind1.Frozen = true;
            this.dgcKind1.HeaderText = "veids";
            this.dgcKind1.ItemStrings = new string[] {
        "0;diena",
        "1;nakts"};
            this.dgcKind1.MaxDropDownItems = 15;
            this.dgcKind1.Name = "dgcKind1";
            this.dgcKind1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcKind1.ValueMember = "col1";
            this.dgcKind1.Width = 80;
            // 
            // dgcV1
            // 
            this.dgcV1.DataPropertyName = "V1";
            this.dgcV1.HeaderText = "1";
            this.dgcV1.Name = "dgcV1";
            this.dgcV1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV1.Width = 40;
            // 
            // dgcV2
            // 
            this.dgcV2.DataPropertyName = "V2";
            this.dgcV2.HeaderText = "2";
            this.dgcV2.Name = "dgcV2";
            this.dgcV2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV2.Width = 40;
            // 
            // dgcV3
            // 
            this.dgcV3.DataPropertyName = "V3";
            this.dgcV3.HeaderText = "3";
            this.dgcV3.Name = "dgcV3";
            this.dgcV3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV3.Width = 40;
            // 
            // dgcV4
            // 
            this.dgcV4.DataPropertyName = "V4";
            this.dgcV4.HeaderText = "4";
            this.dgcV4.Name = "dgcV4";
            this.dgcV4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV4.Width = 40;
            // 
            // dgcV5
            // 
            this.dgcV5.DataPropertyName = "V5";
            this.dgcV5.HeaderText = "5";
            this.dgcV5.Name = "dgcV5";
            this.dgcV5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV5.Width = 40;
            // 
            // dgcV6
            // 
            this.dgcV6.DataPropertyName = "V6";
            this.dgcV6.HeaderText = "6";
            this.dgcV6.Name = "dgcV6";
            this.dgcV6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV6.Width = 40;
            // 
            // dgcV7
            // 
            this.dgcV7.DataPropertyName = "V7";
            this.dgcV7.HeaderText = "7";
            this.dgcV7.Name = "dgcV7";
            this.dgcV7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV7.Width = 40;
            // 
            // dgcV8
            // 
            this.dgcV8.DataPropertyName = "V8";
            this.dgcV8.HeaderText = "8";
            this.dgcV8.Name = "dgcV8";
            this.dgcV8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV8.Width = 40;
            // 
            // dgcV9
            // 
            this.dgcV9.DataPropertyName = "V9";
            this.dgcV9.HeaderText = "9";
            this.dgcV9.Name = "dgcV9";
            this.dgcV9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV9.Width = 40;
            // 
            // dgcV10
            // 
            this.dgcV10.DataPropertyName = "V10";
            this.dgcV10.HeaderText = "10";
            this.dgcV10.Name = "dgcV10";
            this.dgcV10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV10.Width = 40;
            // 
            // dgcV11
            // 
            this.dgcV11.DataPropertyName = "V11";
            this.dgcV11.HeaderText = "11";
            this.dgcV11.Name = "dgcV11";
            this.dgcV11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV11.Width = 40;
            // 
            // dgcV12
            // 
            this.dgcV12.DataPropertyName = "V12";
            this.dgcV12.HeaderText = "12";
            this.dgcV12.Name = "dgcV12";
            this.dgcV12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV12.Width = 40;
            // 
            // dgcV13
            // 
            this.dgcV13.DataPropertyName = "V13";
            this.dgcV13.HeaderText = "13";
            this.dgcV13.Name = "dgcV13";
            this.dgcV13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV13.Width = 40;
            // 
            // dgcV14
            // 
            this.dgcV14.DataPropertyName = "V14";
            this.dgcV14.HeaderText = "14";
            this.dgcV14.Name = "dgcV14";
            this.dgcV14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV14.Width = 40;
            // 
            // dgcV15
            // 
            this.dgcV15.DataPropertyName = "V15";
            this.dgcV15.HeaderText = "15";
            this.dgcV15.Name = "dgcV15";
            this.dgcV15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV15.Width = 40;
            // 
            // dgcV16
            // 
            this.dgcV16.DataPropertyName = "V16";
            this.dgcV16.HeaderText = "16";
            this.dgcV16.Name = "dgcV16";
            this.dgcV16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV16.Width = 40;
            // 
            // dgcV17
            // 
            this.dgcV17.DataPropertyName = "V17";
            this.dgcV17.HeaderText = "17";
            this.dgcV17.Name = "dgcV17";
            this.dgcV17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV17.Width = 40;
            // 
            // dgcV18
            // 
            this.dgcV18.DataPropertyName = "V18";
            this.dgcV18.HeaderText = "18";
            this.dgcV18.Name = "dgcV18";
            this.dgcV18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV18.Width = 40;
            // 
            // dgcV19
            // 
            this.dgcV19.DataPropertyName = "V19";
            this.dgcV19.HeaderText = "19";
            this.dgcV19.Name = "dgcV19";
            this.dgcV19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV19.Width = 40;
            // 
            // dgcV20
            // 
            this.dgcV20.DataPropertyName = "V20";
            this.dgcV20.HeaderText = "20";
            this.dgcV20.Name = "dgcV20";
            this.dgcV20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV20.Width = 40;
            // 
            // dgcV21
            // 
            this.dgcV21.DataPropertyName = "V21";
            this.dgcV21.HeaderText = "21";
            this.dgcV21.Name = "dgcV21";
            this.dgcV21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV21.Width = 40;
            // 
            // dgcV22
            // 
            this.dgcV22.DataPropertyName = "V22";
            this.dgcV22.HeaderText = "22";
            this.dgcV22.Name = "dgcV22";
            this.dgcV22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV22.Width = 40;
            // 
            // dgcV23
            // 
            this.dgcV23.DataPropertyName = "V23";
            this.dgcV23.HeaderText = "23";
            this.dgcV23.Name = "dgcV23";
            this.dgcV23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV23.Width = 40;
            // 
            // dgcV24
            // 
            this.dgcV24.DataPropertyName = "V24";
            this.dgcV24.HeaderText = "24";
            this.dgcV24.Name = "dgcV24";
            this.dgcV24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV24.Width = 40;
            // 
            // dgcV25
            // 
            this.dgcV25.DataPropertyName = "V25";
            this.dgcV25.HeaderText = "25";
            this.dgcV25.Name = "dgcV25";
            this.dgcV25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV25.Width = 40;
            // 
            // dgcV26
            // 
            this.dgcV26.DataPropertyName = "V26";
            this.dgcV26.HeaderText = "26";
            this.dgcV26.Name = "dgcV26";
            this.dgcV26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV26.Width = 40;
            // 
            // dgcV27
            // 
            this.dgcV27.DataPropertyName = "V27";
            this.dgcV27.HeaderText = "27";
            this.dgcV27.Name = "dgcV27";
            this.dgcV27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV27.Width = 40;
            // 
            // dgcV28
            // 
            this.dgcV28.DataPropertyName = "V28";
            this.dgcV28.HeaderText = "28";
            this.dgcV28.Name = "dgcV28";
            this.dgcV28.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV28.Width = 40;
            // 
            // dgcV29
            // 
            this.dgcV29.DataPropertyName = "V29";
            this.dgcV29.HeaderText = "29";
            this.dgcV29.Name = "dgcV29";
            this.dgcV29.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV29.Width = 40;
            // 
            // dgcV30
            // 
            this.dgcV30.DataPropertyName = "V30";
            this.dgcV30.HeaderText = "30";
            this.dgcV30.Name = "dgcV30";
            this.dgcV30.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV30.Width = 40;
            // 
            // dgcV31
            // 
            this.dgcV31.DataPropertyName = "V31";
            this.dgcV31.HeaderText = "31";
            this.dgcV31.Name = "dgcV31";
            this.dgcV31.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV31.Width = 40;
            // 
            // dgcK1
            // 
            this.dgcK1.DataPropertyName = "K1";
            this.dgcK1.HeaderText = "Σ";
            this.dgcK1.Name = "dgcK1";
            this.dgcK1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcK1.Width = 60;
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.Name = "dgcID";
            this.dgcID.Visible = false;
            this.dgcID.Width = 40;
            // 
            // dgcYR
            // 
            this.dgcYR.DataPropertyName = "YR";
            this.dgcYR.HeaderText = "YR";
            this.dgcYR.Name = "dgcYR";
            this.dgcYR.Visible = false;
            this.dgcYR.Width = 50;
            // 
            // dgcMT
            // 
            this.dgcMT.DataPropertyName = "MT";
            this.dgcMT.HeaderText = "MT";
            this.dgcMT.Name = "dgcMT";
            this.dgcMT.Visible = false;
            this.dgcMT.Width = 40;
            // 
            // bnavPlans
            // 
            this.bnavPlans.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavPlans.BindingSource = this.bsPlans;
            this.bnavPlans.CountItem = this.bindingNavigatorCountItem;
            this.bnavPlans.CountItemFormat = " no {0}";
            this.bnavPlans.DataGrid = this.dgvPlans;
            this.bnavPlans.DeleteItem = null;
            this.bnavPlans.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavPlans.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavPlans.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnavPlans.Location = new System.Drawing.Point(0, 334);
            this.bnavPlans.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavPlans.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavPlans.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavPlans.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavPlans.Name = "bnavPlans";
            this.bnavPlans.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavPlans.Size = new System.Drawing.Size(816, 32);
            this.bnavPlans.TabIndex = 1;
            this.bnavPlans.Text = "myBindingNavigator1";
            this.bnavPlans.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavPlans_ItemDeleting);
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
            this.tsbSave.Text = "toolStripButton1";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslPeriod,
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.cbYR,
            this.cbMT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 33);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(816, 39);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslPeriod
            // 
            this.tslPeriod.Name = "tslPeriod";
            this.tslPeriod.Size = new System.Drawing.Size(84, 36);
            this.tslPeriod.Text = "Periods:";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(22, 36);
            this.toolStripLabel1.Text = "  ";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(144, 36);
            this.toolStripLabel2.Text = "  atvērt mēnesi:";
            // 
            // cbYR
            // 
            this.cbYR.AutoSize = false;
            this.cbYR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYR.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cbYR.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.cbYR.MaxLength = 4;
            this.cbYR.Name = "cbYR";
            this.cbYR.Size = new System.Drawing.Size(60, 33);
            this.cbYR.ToolTipText = "gads";
            this.cbYR.SelectedIndexChanged += new System.EventHandler(this.cbYRMT_SelectedIndexChanged);
            // 
            // cbMT
            // 
            this.cbMT.AutoSize = false;
            this.cbMT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMT.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbMT.MaxDropDownItems = 12;
            this.cbMT.Name = "cbMT";
            this.cbMT.Size = new System.Drawing.Size(50, 33);
            this.cbMT.ToolTipText = "mēnesis";
            this.cbMT.SelectedIndexChanged += new System.EventHandler(this.cbYRMT_SelectedIndexChanged);
            // 
            // myStyleDefs1
            // 
            this.myStyleDefs1.HeaderHolyDayBack = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))));
            this.myStyleDefs1.HeaderHolyDayFore = System.Drawing.Color.White;
            this.myStyleDefs1.HeaderWeekEndBack = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(62)))), ((int)(((byte)(106)))));
            this.myStyleDefs1.HeaderWeekEndFore = System.Drawing.Color.White;
            this.myStyleDefs1.SickDayBack = System.Drawing.Color.IndianRed;
            this.myStyleDefs1.SickDayFore = System.Drawing.Color.White;
            this.myStyleDefs1.VacationBack = System.Drawing.Color.YellowGreen;
            this.myStyleDefs1.VacationFore = System.Drawing.Color.White;
            // 
            // cmsMenuMarkDay
            // 
            this.cmsMenuMarkDay.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.cmsMenuMarkDay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDD,
            this.miBD,
            this.miSD,
            this.miDDSD,
            this.miSDDD});
            this.cmsMenuMarkDay.Name = "cmsDayCodes";
            this.cmsMenuMarkDay.Size = new System.Drawing.Size(360, 154);
            this.cmsMenuMarkDay.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsMenuMarkDay_ItemClicked);
            // 
            // miDD
            // 
            this.miDD.Name = "miDD";
            this.miDD.Size = new System.Drawing.Size(359, 30);
            this.miDD.Text = "Darba diena";
            // 
            // miBD
            // 
            this.miBD.Name = "miBD";
            this.miBD.Size = new System.Drawing.Size(359, 30);
            this.miBD.Text = "B - Brīvdiena";
            // 
            // miSD
            // 
            this.miSD.Name = "miSD";
            this.miSD.Size = new System.Drawing.Size(359, 30);
            this.miSD.Text = "S - Svētku diena";
            // 
            // miDDSD
            // 
            this.miDDSD.Name = "miDDSD";
            this.miDDSD.Size = new System.Drawing.Size(359, 30);
            this.miDDSD.Text = "DS - Darba diena svētku dienā";
            // 
            // miSDDD
            // 
            this.miSDDD.Name = "miSDDD";
            this.miSDDD.Size = new System.Drawing.Size(359, 30);
            this.miSDDD.Text = "SD - Svētku diena darba dienā";
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
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darbaLaikaKopplānsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(816, 33);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // darbaLaikaKopplānsToolStripMenuItem
            // 
            this.darbaLaikaKopplānsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izveidotPlānaIerakstusToolStripMenuItem,
            this.toolStripSeparator1,
            this.miFillRow,
            this.miFillList});
            this.darbaLaikaKopplānsToolStripMenuItem.Name = "darbaLaikaKopplānsToolStripMenuItem";
            this.darbaLaikaKopplānsToolStripMenuItem.Size = new System.Drawing.Size(206, 29);
            this.darbaLaikaKopplānsToolStripMenuItem.Text = "Darba laika kopplāns";
            // 
            // izveidotPlānaIerakstusToolStripMenuItem
            // 
            this.izveidotPlānaIerakstusToolStripMenuItem.Name = "izveidotPlānaIerakstusToolStripMenuItem";
            this.izveidotPlānaIerakstusToolStripMenuItem.Size = new System.Drawing.Size(347, 30);
            this.izveidotPlānaIerakstusToolStripMenuItem.Text = "Izveidot plāna ierakstus";
            this.izveidotPlānaIerakstusToolStripMenuItem.Click += new System.EventHandler(this.izveidotPlānaIerakstusToolStripMenuItem_Click);
            // 
            // miFillRow
            // 
            this.miFillRow.Name = "miFillRow";
            this.miFillRow.Size = new System.Drawing.Size(347, 30);
            this.miFillRow.Text = "Aizpildīt no jauna rindu";
            this.miFillRow.Click += new System.EventHandler(this.miFillRow_Click);
            // 
            // miFillList
            // 
            this.miFillList.Name = "miFillList";
            this.miFillList.Size = new System.Drawing.Size(347, 30);
            this.miFillList.Text = "Aizpildīt no jauna visas rindas";
            this.miFillList.Click += new System.EventHandler(this.miFillList_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(344, 6);
            // 
            // Form_Plan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 366);
            this.Controls.Add(this.dgvPlans);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.bnavPlans);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MyToolStrip = this.toolStrip1;
            this.Name = "Form_Plan";
            this.Text = "Darba laika kopplāns";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Plans_FormClosed);
            this.Load += new System.EventHandler(this.Form_Plan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanuSar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsK1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavPlans)).EndInit();
            this.bnavPlans.ResumeLayout(false);
            this.bnavPlans.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmsMenuMarkDay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MyBindingNavigator bnavPlans;
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
        private KlonsLIB.Data.MyBindingSource bsPlans;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private KlonsLIB.Data.MyBindingSource bsPlanuSar;
        private System.Windows.Forms.BindingSource bsK1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslPeriod;
        private System.Windows.Forms.ToolStripComboBox cbYR;
        private Classes.MyStyleDefs myStyleDefs1;
        private System.Windows.Forms.ContextMenuStrip cmsMenuMarkDay;
        private System.Windows.Forms.ToolStripMenuItem miDD;
        private System.Windows.Forms.ToolStripMenuItem miBD;
        private System.Windows.Forms.ToolStripMenuItem miSD;
        private System.Windows.Forms.ToolStripMenuItem miDDSD;
        private System.Windows.Forms.ToolStripMenuItem miSDDD;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private MyDataGridView dgvPlans;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private System.Windows.Forms.ToolStripComboBox cbMT;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem darbaLaikaKopplānsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izveidotPlānaIerakstusToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNPK;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcIDP;
        private MyDgvMcCBColumn dgcKind1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcV31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcK1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcYR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcMT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miFillRow;
        private System.Windows.Forms.ToolStripMenuItem miFillList;
    }
}