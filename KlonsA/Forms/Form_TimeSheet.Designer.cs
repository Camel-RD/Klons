using KlonsLIB.Components;

namespace KlonsA.Forms
{
    partial class Form_TimeSheet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TimeSheet));
            this.dgvLapa = new KlonsLIB.Components.MyDataGridView();
            this.dgcIDX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSNRX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcKind1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcK1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dgcIDL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcKind2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsLapa2 = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.dlJoinView1 = new KlonsA.Classes.DLJoinView(this.components);
            this.bsLapa = new KlonsLIB.Data.MyBindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslPeriod = new System.Windows.Forms.ToolStripLabel();
            this.bsLapuSar = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cbLapuSar = new KlonsLIB.Components.MyMcFlatComboBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.myStyleDefs1 = new KlonsA.Classes.MyStyleDefs();
            this.cmsMenuMarkDayFact = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miFactD = new System.Windows.Forms.ToolStripMenuItem();
            this.miFactB = new System.Windows.Forms.ToolStripMenuItem();
            this.miFactK = new System.Windows.Forms.ToolStripMenuItem();
            this.miFactSVVI = new System.Windows.Forms.ToolStripMenuItem();
            this.miFactVI = new System.Windows.Forms.ToolStripMenuItem();
            this.miFactN = new System.Windows.Forms.ToolStripMenuItem();
            this.miFactDS = new System.Windows.Forms.ToolStripMenuItem();
            this.miFactKS = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMenuMarkDayPlan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPlanDD = new System.Windows.Forms.ToolStripMenuItem();
            this.miPlanBD = new System.Windows.Forms.ToolStripMenuItem();
            this.miPlanSD = new System.Windows.Forms.ToolStripMenuItem();
            this.miPlanSDDD = new System.Windows.Forms.ToolStripMenuItem();
            this.miPlanDDSD = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.darbaLaikaUzskaitesLapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sarakstsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSheetCheckEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSheetFillFact = new System.Windows.Forms.ToolStripMenuItem();
            this.darbinieksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPersonCheckEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPersonFillFact = new System.Windows.Forms.ToolStripMenuItem();
            this.izdrukaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darbaLaikaLapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darbaLaikaLapaArKrāsāmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darbaLaikaKopsummasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myStyleDefsForReport = new KlonsA.Classes.MyStyleDefs();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLapa2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLapa)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLapuSar)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.cmsMenuMarkDayFact.SuspendLayout();
            this.cmsMenuMarkDayPlan.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLapa
            // 
            this.dgvLapa.AllowUserToAddRows = false;
            this.dgvLapa.AllowUserToDeleteRows = false;
            this.dgvLapa.AllowUserToResizeRows = false;
            this.dgvLapa.AutoGenerateColumns = false;
            this.dgvLapa.AutoSave = false;
            this.dgvLapa.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLapa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLapa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLapa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcIDX,
            this.dgcID,
            this.dgcSNRX,
            this.dgcTitle,
            this.dgcPosition,
            this.dgcKind1,
            this.dgcK1,
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
            this.dgcIDL,
            this.dgcKind2});
            this.dgvLapa.DataSource = this.bsLapa2;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLapa.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLapa.Location = new System.Drawing.Point(0, 29);
            this.dgvLapa.Name = "dgvLapa";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLapa.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLapa.RowHeadersWidth = 53;
            this.dgvLapa.RowTemplate.Height = 24;
            this.dgvLapa.Size = new System.Drawing.Size(681, 293);
            this.dgvLapa.TabIndex = 0;
            this.dgvLapa.UseMyContextmenu = false;
            this.dgvLapa.MyCheckForChanges += new System.EventHandler(this.dgvLapa_MyCheckForChanges);
            this.dgvLapa.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLapa_CellBeginEdit);
            this.dgvLapa.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvLapa_CellContextMenuStripNeeded);
            this.dgvLapa.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLapa_CellEndEdit);
            this.dgvLapa.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLapa_CellFormatting);
            this.dgvLapa.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView_CellPainting);
            this.dgvLapa.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvLapa_CellParsing);
            this.dgvLapa.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvLapa_EditingControlShowing);
            this.dgvLapa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLapa_KeyDown);
            // 
            // dgcIDX
            // 
            this.dgcIDX.DataPropertyName = "IDX";
            this.dgcIDX.Frozen = true;
            this.dgcIDX.HeaderText = "IDX";
            this.dgcIDX.MinimumWidth = 7;
            this.dgcIDX.Name = "dgcIDX";
            this.dgcIDX.ReadOnly = true;
            this.dgcIDX.Visible = false;
            this.dgcIDX.Width = 50;
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.Frozen = true;
            this.dgcID.HeaderText = "ID";
            this.dgcID.MinimumWidth = 7;
            this.dgcID.Name = "dgcID";
            this.dgcID.Visible = false;
            this.dgcID.Width = 40;
            // 
            // dgcSNRX
            // 
            this.dgcSNRX.DataPropertyName = "SNRX";
            this.dgcSNRX.Frozen = true;
            this.dgcSNRX.HeaderText = "npk";
            this.dgcSNRX.MinimumWidth = 7;
            this.dgcSNRX.Name = "dgcSNRX";
            this.dgcSNRX.ReadOnly = true;
            this.dgcSNRX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSNRX.Width = 32;
            // 
            // dgcTitle
            // 
            this.dgcTitle.DataPropertyName = "Name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgcTitle.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcTitle.Frozen = true;
            this.dgcTitle.HeaderText = "darbinieks";
            this.dgcTitle.MinimumWidth = 7;
            this.dgcTitle.Name = "dgcTitle";
            this.dgcTitle.ReadOnly = true;
            this.dgcTitle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcTitle.Width = 180;
            // 
            // dgcPosition
            // 
            this.dgcPosition.DataPropertyName = "Position";
            this.dgcPosition.Frozen = true;
            this.dgcPosition.HeaderText = "Amats";
            this.dgcPosition.MinimumWidth = 7;
            this.dgcPosition.Name = "dgcPosition";
            this.dgcPosition.ReadOnly = true;
            this.dgcPosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcPosition.Visible = false;
            this.dgcPosition.Width = 130;
            // 
            // dgcKind1
            // 
            this.dgcKind1.DataPropertyName = "KIND1";
            this.dgcKind1.Frozen = true;
            this.dgcKind1.HeaderText = "tips";
            this.dgcKind1.MinimumWidth = 7;
            this.dgcKind1.Name = "dgcKind1";
            this.dgcKind1.ReadOnly = true;
            this.dgcKind1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcKind1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcKind1.Width = 60;
            // 
            // dgcK1
            // 
            this.dgcK1.DataPropertyName = "K1";
            this.dgcK1.Frozen = true;
            this.dgcK1.HeaderText = "Σ";
            this.dgcK1.MinimumWidth = 7;
            this.dgcK1.Name = "dgcK1";
            this.dgcK1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcK1.Width = 32;
            // 
            // dgcV1
            // 
            this.dgcV1.DataPropertyName = "V1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcV1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcV1.HeaderText = "1";
            this.dgcV1.MinimumWidth = 7;
            this.dgcV1.Name = "dgcV1";
            this.dgcV1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV1.Width = 28;
            // 
            // dgcV2
            // 
            this.dgcV2.DataPropertyName = "V2";
            this.dgcV2.HeaderText = "2";
            this.dgcV2.MinimumWidth = 7;
            this.dgcV2.Name = "dgcV2";
            this.dgcV2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV2.Width = 28;
            // 
            // dgcV3
            // 
            this.dgcV3.DataPropertyName = "V3";
            this.dgcV3.HeaderText = "3";
            this.dgcV3.MinimumWidth = 7;
            this.dgcV3.Name = "dgcV3";
            this.dgcV3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV3.Width = 28;
            // 
            // dgcV4
            // 
            this.dgcV4.DataPropertyName = "V4";
            this.dgcV4.HeaderText = "4";
            this.dgcV4.MinimumWidth = 7;
            this.dgcV4.Name = "dgcV4";
            this.dgcV4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV4.Width = 28;
            // 
            // dgcV5
            // 
            this.dgcV5.DataPropertyName = "V5";
            this.dgcV5.HeaderText = "5";
            this.dgcV5.MinimumWidth = 7;
            this.dgcV5.Name = "dgcV5";
            this.dgcV5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV5.Width = 28;
            // 
            // dgcV6
            // 
            this.dgcV6.DataPropertyName = "V6";
            this.dgcV6.HeaderText = "6";
            this.dgcV6.MinimumWidth = 7;
            this.dgcV6.Name = "dgcV6";
            this.dgcV6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV6.Width = 28;
            // 
            // dgcV7
            // 
            this.dgcV7.DataPropertyName = "V7";
            this.dgcV7.HeaderText = "7";
            this.dgcV7.MinimumWidth = 7;
            this.dgcV7.Name = "dgcV7";
            this.dgcV7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV7.Width = 28;
            // 
            // dgcV8
            // 
            this.dgcV8.DataPropertyName = "V8";
            this.dgcV8.HeaderText = "8";
            this.dgcV8.MinimumWidth = 7;
            this.dgcV8.Name = "dgcV8";
            this.dgcV8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV8.Width = 28;
            // 
            // dgcV9
            // 
            this.dgcV9.DataPropertyName = "V9";
            this.dgcV9.HeaderText = "9";
            this.dgcV9.MinimumWidth = 7;
            this.dgcV9.Name = "dgcV9";
            this.dgcV9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV9.Width = 28;
            // 
            // dgcV10
            // 
            this.dgcV10.DataPropertyName = "V10";
            this.dgcV10.HeaderText = "10";
            this.dgcV10.MinimumWidth = 7;
            this.dgcV10.Name = "dgcV10";
            this.dgcV10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV10.Width = 28;
            // 
            // dgcV11
            // 
            this.dgcV11.DataPropertyName = "V11";
            this.dgcV11.HeaderText = "11";
            this.dgcV11.MinimumWidth = 7;
            this.dgcV11.Name = "dgcV11";
            this.dgcV11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV11.Width = 28;
            // 
            // dgcV12
            // 
            this.dgcV12.DataPropertyName = "V12";
            this.dgcV12.HeaderText = "12";
            this.dgcV12.MinimumWidth = 7;
            this.dgcV12.Name = "dgcV12";
            this.dgcV12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV12.Width = 28;
            // 
            // dgcV13
            // 
            this.dgcV13.DataPropertyName = "V13";
            this.dgcV13.HeaderText = "13";
            this.dgcV13.MinimumWidth = 7;
            this.dgcV13.Name = "dgcV13";
            this.dgcV13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV13.Width = 28;
            // 
            // dgcV14
            // 
            this.dgcV14.DataPropertyName = "V14";
            this.dgcV14.HeaderText = "14";
            this.dgcV14.MinimumWidth = 7;
            this.dgcV14.Name = "dgcV14";
            this.dgcV14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV14.Width = 28;
            // 
            // dgcV15
            // 
            this.dgcV15.DataPropertyName = "V15";
            this.dgcV15.HeaderText = "15";
            this.dgcV15.MinimumWidth = 7;
            this.dgcV15.Name = "dgcV15";
            this.dgcV15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV15.Width = 28;
            // 
            // dgcV16
            // 
            this.dgcV16.DataPropertyName = "V16";
            this.dgcV16.HeaderText = "16";
            this.dgcV16.MinimumWidth = 7;
            this.dgcV16.Name = "dgcV16";
            this.dgcV16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV16.Width = 28;
            // 
            // dgcV17
            // 
            this.dgcV17.DataPropertyName = "V17";
            this.dgcV17.HeaderText = "17";
            this.dgcV17.MinimumWidth = 7;
            this.dgcV17.Name = "dgcV17";
            this.dgcV17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV17.Width = 28;
            // 
            // dgcV18
            // 
            this.dgcV18.DataPropertyName = "V18";
            this.dgcV18.HeaderText = "18";
            this.dgcV18.MinimumWidth = 7;
            this.dgcV18.Name = "dgcV18";
            this.dgcV18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV18.Width = 28;
            // 
            // dgcV19
            // 
            this.dgcV19.DataPropertyName = "V19";
            this.dgcV19.HeaderText = "19";
            this.dgcV19.MinimumWidth = 7;
            this.dgcV19.Name = "dgcV19";
            this.dgcV19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV19.Width = 28;
            // 
            // dgcV20
            // 
            this.dgcV20.DataPropertyName = "V20";
            this.dgcV20.HeaderText = "20";
            this.dgcV20.MinimumWidth = 7;
            this.dgcV20.Name = "dgcV20";
            this.dgcV20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV20.Width = 28;
            // 
            // dgcV21
            // 
            this.dgcV21.DataPropertyName = "V21";
            this.dgcV21.HeaderText = "21";
            this.dgcV21.MinimumWidth = 7;
            this.dgcV21.Name = "dgcV21";
            this.dgcV21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV21.Width = 28;
            // 
            // dgcV22
            // 
            this.dgcV22.DataPropertyName = "V22";
            this.dgcV22.HeaderText = "22";
            this.dgcV22.MinimumWidth = 7;
            this.dgcV22.Name = "dgcV22";
            this.dgcV22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV22.Width = 28;
            // 
            // dgcV23
            // 
            this.dgcV23.DataPropertyName = "V23";
            this.dgcV23.HeaderText = "23";
            this.dgcV23.MinimumWidth = 7;
            this.dgcV23.Name = "dgcV23";
            this.dgcV23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV23.Width = 28;
            // 
            // dgcV24
            // 
            this.dgcV24.DataPropertyName = "V24";
            this.dgcV24.HeaderText = "24";
            this.dgcV24.MinimumWidth = 7;
            this.dgcV24.Name = "dgcV24";
            this.dgcV24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV24.Width = 28;
            // 
            // dgcV25
            // 
            this.dgcV25.DataPropertyName = "V25";
            this.dgcV25.HeaderText = "25";
            this.dgcV25.MinimumWidth = 7;
            this.dgcV25.Name = "dgcV25";
            this.dgcV25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV25.Width = 28;
            // 
            // dgcV26
            // 
            this.dgcV26.DataPropertyName = "V26";
            this.dgcV26.HeaderText = "26";
            this.dgcV26.MinimumWidth = 7;
            this.dgcV26.Name = "dgcV26";
            this.dgcV26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV26.Width = 28;
            // 
            // dgcV27
            // 
            this.dgcV27.DataPropertyName = "V27";
            this.dgcV27.HeaderText = "27";
            this.dgcV27.MinimumWidth = 7;
            this.dgcV27.Name = "dgcV27";
            this.dgcV27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV27.Width = 28;
            // 
            // dgcV28
            // 
            this.dgcV28.DataPropertyName = "V28";
            this.dgcV28.HeaderText = "28";
            this.dgcV28.MinimumWidth = 7;
            this.dgcV28.Name = "dgcV28";
            this.dgcV28.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV28.Width = 28;
            // 
            // dgcV29
            // 
            this.dgcV29.DataPropertyName = "V29";
            this.dgcV29.HeaderText = "29";
            this.dgcV29.MinimumWidth = 7;
            this.dgcV29.Name = "dgcV29";
            this.dgcV29.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV29.Width = 28;
            // 
            // dgcV30
            // 
            this.dgcV30.DataPropertyName = "V30";
            this.dgcV30.HeaderText = "30";
            this.dgcV30.MinimumWidth = 7;
            this.dgcV30.Name = "dgcV30";
            this.dgcV30.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV30.Width = 28;
            // 
            // dgcV31
            // 
            this.dgcV31.DataPropertyName = "V31";
            this.dgcV31.HeaderText = "31";
            this.dgcV31.MinimumWidth = 7;
            this.dgcV31.Name = "dgcV31";
            this.dgcV31.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcV31.Width = 28;
            // 
            // dgcIDL
            // 
            this.dgcIDL.DataPropertyName = "IDL";
            this.dgcIDL.HeaderText = "IDL";
            this.dgcIDL.MinimumWidth = 7;
            this.dgcIDL.Name = "dgcIDL";
            this.dgcIDL.Visible = false;
            this.dgcIDL.Width = 40;
            // 
            // dgcKind2
            // 
            this.dgcKind2.DataPropertyName = "KIND2";
            this.dgcKind2.HeaderText = "KIND2";
            this.dgcKind2.MinimumWidth = 7;
            this.dgcKind2.Name = "dgcKind2";
            this.dgcKind2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcKind2.Visible = false;
            this.dgcKind2.Width = 40;
            // 
            // bsLapa2
            // 
            this.bsLapa2.DataSource = this.dlJoinView1;
            // 
            // dlJoinView1
            // 
            this.dlJoinView1.AllowDelete = true;
            this.dlJoinView1.AllowEdit = true;
            this.dlJoinView1.AllowNew = false;
            this.dlJoinView1.AllowSort = true;
            this.dlJoinView1.FieldList = "!.*,*";
            this.dlJoinView1.Name = "dlJoinView1";
            this.dlJoinView1.Sort = "SNRX,IDX,KIND1";
            // 
            // bsLapa
            // 
            this.bsLapa.AutoSaveOnDelete = true;
            this.bsLapa.DataMember = "TIMESHEET";
            this.bsLapa.MyDataSource = "KlonsData";
            this.bsLapa.UseDataGridView = this.dgvLapa;
            this.bsLapa.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsLapa_ListChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslPeriod});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(681, 29);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslPeriod
            // 
            this.tslPeriod.Name = "tslPeriod";
            this.tslPeriod.Size = new System.Drawing.Size(84, 25);
            this.tslPeriod.Text = "Periods:";
            // 
            // bsLapuSar
            // 
            this.bsLapuSar.DataMember = "TIMESHEET_LISTS";
            this.bsLapuSar.Filter = "ISFIRSTMT = FALSE";
            this.bsLapuSar.MyDataSource = "KlonsData";
            this.bsLapuSar.Sort = "yr desc, mt desc,snr desc";
            this.bsLapuSar.CurrentChanged += new System.EventHandler(this.bsLapuSar_CurrentChanged);
            // 
            // cbLapuSar
            // 
            this.cbLapuSar._AllowSelection = true;
            this.cbLapuSar.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbLapuSar.ColumnNames = new string[] {
        "ID"};
            this.cbLapuSar.ColumnWidths = "280";
            this.cbLapuSar.DataSource = this.bsLapuSar;
            this.cbLapuSar.DisplayMember = "ID";
            this.cbLapuSar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLapuSar.DropDownHeight = 255;
            this.cbLapuSar.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbLapuSar.DropDownWidth = 304;
            this.cbLapuSar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLapuSar.FormattingEnabled = true;
            this.cbLapuSar.GridLineColor = System.Drawing.Color.LightGray;
            this.cbLapuSar.GridLineHorizontal = false;
            this.cbLapuSar.GridLineVertical = false;
            this.cbLapuSar.IntegralHeight = false;
            this.cbLapuSar.Location = new System.Drawing.Point(226, 0);
            this.cbLapuSar.MaxDropDownItems = 15;
            this.cbLapuSar.Name = "cbLapuSar";
            this.cbLapuSar.Size = new System.Drawing.Size(280, 23);
            this.cbLapuSar.TabIndex = 7;
            this.cbLapuSar.ValueMember = "ID";
            this.cbLapuSar.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbLapuSar_Format);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbEdit,
            this.tsbDelete,
            this.tsbSave});
            this.toolStrip2.Location = new System.Drawing.Point(0, 322);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(681, 33);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.RightToLeftAutoMirrorImage = true;
            this.tsbNew.Size = new System.Drawing.Size(91, 29);
            this.tsbNew.Text = "Jauns";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(89, 29);
            this.tsbEdit.Text = "Mainīt";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.RightToLeftAutoMirrorImage = true;
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
            this.tsbSave.Text = "toolStripButton1";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "TIMESHEET",
        "TIMESHEET_LISTS",
        "TIMESHEET_LISTS_R",
        null};
            // 
            // myStyleDefs1
            // 
            this.myStyleDefs1.FreeDayBack = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.myStyleDefs1.FreeDayFore = System.Drawing.Color.White;
            this.myStyleDefs1.HeaderHolyDayBack = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))));
            this.myStyleDefs1.HeaderHolyDayFore = System.Drawing.Color.White;
            this.myStyleDefs1.HeaderWeekEndBack = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(62)))), ((int)(((byte)(106)))));
            this.myStyleDefs1.HeaderWeekEndFore = System.Drawing.Color.White;
            this.myStyleDefs1.HolyDayBack = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.myStyleDefs1.HolyDayFore = System.Drawing.Color.White;
            this.myStyleDefs1.SickDayBack = System.Drawing.Color.IndianRed;
            this.myStyleDefs1.SickDayFore = System.Drawing.Color.White;
            this.myStyleDefs1.VacationBack = System.Drawing.Color.YellowGreen;
            this.myStyleDefs1.VacationFore = System.Drawing.Color.White;
            // 
            // cmsMenuMarkDayFact
            // 
            this.cmsMenuMarkDayFact.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.cmsMenuMarkDayFact.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFactD,
            this.miFactB,
            this.miFactK,
            this.miFactSVVI,
            this.miFactVI,
            this.miFactN,
            this.miFactDS,
            this.miFactKS});
            this.cmsMenuMarkDayFact.Name = "cmsMenuMarkDay";
            this.cmsMenuMarkDayFact.Size = new System.Drawing.Size(482, 244);
            this.cmsMenuMarkDayFact.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsMenuMarkDayFact_ItemClicked);
            // 
            // miFactD
            // 
            this.miFactD.Name = "miFactD";
            this.miFactD.Size = new System.Drawing.Size(481, 30);
            this.miFactD.Text = "Darba diena";
            // 
            // miFactB
            // 
            this.miFactB.Name = "miFactB";
            this.miFactB.Size = new System.Drawing.Size(481, 30);
            this.miFactB.Text = "B - Brīvdiena";
            // 
            // miFactK
            // 
            this.miFactK.Name = "miFactK";
            this.miFactK.Size = new System.Drawing.Size(481, 30);
            this.miFactK.Text = "K - Komandējums";
            // 
            // miFactSVVI
            // 
            this.miFactSVVI.Name = "miFactSVVI";
            this.miFactSVVI.Size = new System.Drawing.Size(481, 30);
            this.miFactSVVI.Text = "S - Svētku diena ar vidējo izpeļņu";
            // 
            // miFactVI
            // 
            this.miFactVI.Name = "miFactVI";
            this.miFactVI.Size = new System.Drawing.Size(481, 30);
            this.miFactVI.Text = "V - Vidējās izpeļņas diena";
            // 
            // miFactN
            // 
            this.miFactN.Name = "miFactN";
            this.miFactN.Size = new System.Drawing.Size(481, 30);
            this.miFactN.Text = "N - Neattaisnots kavējums";
            // 
            // miFactDS
            // 
            this.miFactDS.Name = "miFactDS";
            this.miFactDS.Size = new System.Drawing.Size(481, 30);
            this.miFactDS.Text = "DS - Darba diena svētku dienā ar piemaksu";
            // 
            // miFactKS
            // 
            this.miFactKS.Name = "miFactKS";
            this.miFactKS.Size = new System.Drawing.Size(481, 30);
            this.miFactKS.Text = "KS - Komandējums svētku dienā ar piemaksu";
            // 
            // cmsMenuMarkDayPlan
            // 
            this.cmsMenuMarkDayPlan.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.cmsMenuMarkDayPlan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPlanDD,
            this.miPlanBD,
            this.miPlanSD,
            this.miPlanSDDD,
            this.miPlanDDSD});
            this.cmsMenuMarkDayPlan.Name = "cmsMenuMarkDayPlan";
            this.cmsMenuMarkDayPlan.Size = new System.Drawing.Size(352, 154);
            this.cmsMenuMarkDayPlan.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsMenuMarkDayPlan_ItemClicked);
            // 
            // miPlanDD
            // 
            this.miPlanDD.Name = "miPlanDD";
            this.miPlanDD.Size = new System.Drawing.Size(351, 30);
            this.miPlanDD.Text = "Darba diena";
            // 
            // miPlanBD
            // 
            this.miPlanBD.Name = "miPlanBD";
            this.miPlanBD.Size = new System.Drawing.Size(351, 30);
            this.miPlanBD.Text = "B - Brīvdiena";
            // 
            // miPlanSD
            // 
            this.miPlanSD.Name = "miPlanSD";
            this.miPlanSD.Size = new System.Drawing.Size(351, 30);
            this.miPlanSD.Text = "S - Svētku diena";
            // 
            // miPlanSDDD
            // 
            this.miPlanSDDD.Name = "miPlanSDDD";
            this.miPlanSDDD.Size = new System.Drawing.Size(351, 30);
            this.miPlanSDDD.Text = "SD - Svētku diena darba dienā";
            // 
            // miPlanDDSD
            // 
            this.miPlanDDSD.Name = "miPlanDDSD";
            this.miPlanDDSD.Size = new System.Drawing.Size(351, 30);
            this.miPlanDDSD.Text = "DS - Darba diena svētku dienā";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darbaLaikaUzskaitesLapaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(681, 33);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // darbaLaikaUzskaitesLapaToolStripMenuItem
            // 
            this.darbaLaikaUzskaitesLapaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.sarakstsToolStripMenuItem,
            this.darbinieksToolStripMenuItem,
            this.izdrukaiToolStripMenuItem});
            this.darbaLaikaUzskaitesLapaToolStripMenuItem.MergeIndex = 2;
            this.darbaLaikaUzskaitesLapaToolStripMenuItem.Name = "darbaLaikaUzskaitesLapaToolStripMenuItem";
            this.darbaLaikaUzskaitesLapaToolStripMenuItem.Size = new System.Drawing.Size(253, 29);
            this.darbaLaikaUzskaitesLapaToolStripMenuItem.Text = "Darba laika uzskaites lapa";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // sarakstsToolStripMenuItem
            // 
            this.sarakstsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSheetCheckEvents,
            this.tsmiSheetFillFact});
            this.sarakstsToolStripMenuItem.Name = "sarakstsToolStripMenuItem";
            this.sarakstsToolStripMenuItem.Size = new System.Drawing.Size(193, 30);
            this.sarakstsToolStripMenuItem.Text = "Saraksts";
            // 
            // tsmiSheetCheckEvents
            // 
            this.tsmiSheetCheckEvents.Name = "tsmiSheetCheckEvents";
            this.tsmiSheetCheckEvents.Size = new System.Drawing.Size(429, 30);
            this.tsmiSheetCheckEvents.Text = "Pārbaudīt notikumus";
            this.tsmiSheetCheckEvents.Click += new System.EventHandler(this.tsmiSheetCheckEvents_Click);
            // 
            // tsmiSheetFillFact
            // 
            this.tsmiSheetFillFact.Name = "tsmiSheetFillFact";
            this.tsmiSheetFillFact.Size = new System.Drawing.Size(429, 30);
            this.tsmiSheetFillFact.Text = "Aizpildīt nostrādātās stundas no plāna";
            this.tsmiSheetFillFact.Click += new System.EventHandler(this.tsmiSheetFillFact_Click);
            // 
            // darbinieksToolStripMenuItem
            // 
            this.darbinieksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPersonCheckEvents,
            this.tsmiPersonFillFact});
            this.darbinieksToolStripMenuItem.Name = "darbinieksToolStripMenuItem";
            this.darbinieksToolStripMenuItem.Size = new System.Drawing.Size(193, 30);
            this.darbinieksToolStripMenuItem.Text = "Darbinieks";
            // 
            // tsmiPersonCheckEvents
            // 
            this.tsmiPersonCheckEvents.Name = "tsmiPersonCheckEvents";
            this.tsmiPersonCheckEvents.Size = new System.Drawing.Size(349, 30);
            this.tsmiPersonCheckEvents.Text = "Pārbaudīt notikumus";
            this.tsmiPersonCheckEvents.Click += new System.EventHandler(this.tsmiPersonCheckEvents_Click);
            // 
            // tsmiPersonFillFact
            // 
            this.tsmiPersonFillFact.Name = "tsmiPersonFillFact";
            this.tsmiPersonFillFact.Size = new System.Drawing.Size(349, 30);
            this.tsmiPersonFillFact.Text = "Aizpildīt nostrādātās stundas";
            this.tsmiPersonFillFact.Click += new System.EventHandler(this.tsmiPersonFillFact_Click);
            // 
            // izdrukaiToolStripMenuItem
            // 
            this.izdrukaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darbaLaikaLapaToolStripMenuItem,
            this.darbaLaikaLapaArKrāsāmToolStripMenuItem,
            this.darbaLaikaKopsummasToolStripMenuItem});
            this.izdrukaiToolStripMenuItem.Name = "izdrukaiToolStripMenuItem";
            this.izdrukaiToolStripMenuItem.Size = new System.Drawing.Size(193, 30);
            this.izdrukaiToolStripMenuItem.Text = "Izdrukai";
            // 
            // darbaLaikaLapaToolStripMenuItem
            // 
            this.darbaLaikaLapaToolStripMenuItem.Name = "darbaLaikaLapaToolStripMenuItem";
            this.darbaLaikaLapaToolStripMenuItem.Size = new System.Drawing.Size(344, 30);
            this.darbaLaikaLapaToolStripMenuItem.Text = "Darba laika lapa";
            this.darbaLaikaLapaToolStripMenuItem.Click += new System.EventHandler(this.darbaLaikaLapaToolStripMenuItem_Click);
            // 
            // darbaLaikaLapaArKrāsāmToolStripMenuItem
            // 
            this.darbaLaikaLapaArKrāsāmToolStripMenuItem.Name = "darbaLaikaLapaArKrāsāmToolStripMenuItem";
            this.darbaLaikaLapaArKrāsāmToolStripMenuItem.Size = new System.Drawing.Size(344, 30);
            this.darbaLaikaLapaArKrāsāmToolStripMenuItem.Text = "Darba laika lapa - ar krāsām";
            this.darbaLaikaLapaArKrāsāmToolStripMenuItem.Click += new System.EventHandler(this.DarbaLaikaLapaArKrāsāmToolStripMenuItem_Click);
            // 
            // darbaLaikaKopsummasToolStripMenuItem
            // 
            this.darbaLaikaKopsummasToolStripMenuItem.Name = "darbaLaikaKopsummasToolStripMenuItem";
            this.darbaLaikaKopsummasToolStripMenuItem.Size = new System.Drawing.Size(344, 30);
            this.darbaLaikaKopsummasToolStripMenuItem.Text = "Darba laika kopsummas";
            this.darbaLaikaKopsummasToolStripMenuItem.Click += new System.EventHandler(this.darbaLaikaKopsummasToolStripMenuItem_Click);
            // 
            // myStyleDefsForReport
            // 
            this.myStyleDefsForReport.FreeDayBack = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.myStyleDefsForReport.FreeDayFore = System.Drawing.Color.White;
            this.myStyleDefsForReport.HeaderHolyDayBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(208)))));
            this.myStyleDefsForReport.HeaderHolyDayFore = System.Drawing.Color.White;
            this.myStyleDefsForReport.HeaderWeekEndBack = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.myStyleDefsForReport.HeaderWeekEndFore = System.Drawing.Color.White;
            this.myStyleDefsForReport.HolyDayBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(227)))));
            this.myStyleDefsForReport.HolyDayFore = System.Drawing.Color.White;
            this.myStyleDefsForReport.SickDayBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.myStyleDefsForReport.SickDayFore = System.Drawing.Color.White;
            this.myStyleDefsForReport.VacationBack = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.myStyleDefsForReport.VacationFore = System.Drawing.Color.White;
            // 
            // Form_TimeSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 355);
            this.Controls.Add(this.cbLapuSar);
            this.Controls.Add(this.dgvLapa);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MyToolStrip = this.toolStrip1;
            this.Name = "Form_TimeSheet";
            this.Text = "Darba laika uzskaites lapa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_TimeSheet_FormClosed);
            this.Load += new System.EventHandler(this.Form_TimeSheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLapa2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLapa)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLapuSar)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.cmsMenuMarkDayFact.ResumeLayout(false);
            this.cmsMenuMarkDayPlan.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyDataGridView dgvLapa;
        private KlonsLIB.Data.MyBindingSource bsLapa;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private KlonsA.Classes.DLJoinView dlJoinView1;
        private KlonsLIB.Data.MyBindingSource2 bsLapa2;
        private System.Windows.Forms.ToolStripLabel tslPeriod;
        private KlonsLIB.Data.MyBindingSource bsLapuSar;
        private MyMcFlatComboBox cbLapuSar;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private KlonsA.Classes.MyStyleDefs myStyleDefs1;
        private System.Windows.Forms.ContextMenuStrip cmsMenuMarkDayFact;
        private System.Windows.Forms.ToolStripMenuItem miFactD;
        private System.Windows.Forms.ToolStripMenuItem miFactK;
        private System.Windows.Forms.ToolStripMenuItem miFactB;
        private System.Windows.Forms.ToolStripMenuItem miFactSVVI;
        private System.Windows.Forms.ContextMenuStrip cmsMenuMarkDayPlan;
        private System.Windows.Forms.ToolStripMenuItem miPlanDD;
        private System.Windows.Forms.ToolStripMenuItem miPlanBD;
        private System.Windows.Forms.ToolStripMenuItem miPlanSD;
        private System.Windows.Forms.ToolStripMenuItem miPlanSDDD;
        private System.Windows.Forms.ToolStripMenuItem miPlanDDSD;
        private System.Windows.Forms.ToolStripMenuItem miFactVI;
        private System.Windows.Forms.ToolStripMenuItem miFactN;
        private System.Windows.Forms.ToolStripMenuItem miFactDS;
        private System.Windows.Forms.ToolStripMenuItem miFactKS;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem darbaLaikaUzskaitesLapaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem izdrukaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sarakstsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSheetCheckEvents;
        private System.Windows.Forms.ToolStripMenuItem tsmiSheetFillFact;
        private System.Windows.Forms.ToolStripMenuItem darbinieksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPersonCheckEvents;
        private System.Windows.Forms.ToolStripMenuItem tsmiPersonFillFact;
        private System.Windows.Forms.ToolStripMenuItem darbaLaikaLapaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darbaLaikaKopsummasToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIDX;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSNRX;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcKind1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcK1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIDL;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcKind2;
        private System.Windows.Forms.ToolStripMenuItem darbaLaikaLapaArKrāsāmToolStripMenuItem;
        private Classes.MyStyleDefs myStyleDefsForReport;
    }
}