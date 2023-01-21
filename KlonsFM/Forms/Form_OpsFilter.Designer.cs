using KlonsLIB.Components;
using KlonsLIB.Data;
using KlonsFM.UI;

namespace KlonsFM.Forms
{
    partial class Form_OpsFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_OpsFilter));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.myToolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbFilter = new System.Windows.Forms.ToolStripButton();
            this.tsbFilterDocs = new System.Windows.Forms.ToolStripButton();
            this.tsbFindInDocs = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.dokumentuSarakstsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ierakstuIzrakstsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDocs = new System.Windows.Forms.ToolStripButton();
            this.cmAndOr = new System.Windows.Forms.Button();
            this.dgvOPS = new KlonsLIB.Components.MyDataGridView();
            this.bs_vwOPS = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cbAC25 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbAC24 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbAC23 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbAC22 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbAC21 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbAC15 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbAC14 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbAC13 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbAC12 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbAC11 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.tbText = new KlonsLIB.Components.MyTextBox();
            this.cbClid = new KlonsLIB.Components.MyMcFlatComboBox();
            this.tbDate2 = new KlonsLIB.Components.MyTextBox();
            this.tbDate1 = new KlonsLIB.Components.MyTextBox();
            this.tbSum = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDocGr = new KlonsLIB.Components.MyMcFlatComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ierakstuŽurnālsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rādītPilnuPersonasNosaukumuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rādītPersonasReģistrācijasNumuruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgcZNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocTyp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcClid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRegNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPVNRegNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAC11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAC21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgcSumm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAC12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAC13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAC14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAC15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAC22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAC23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAC24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAC25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcQV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rādītPersonasPVNReģistrācijasNumuruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_vwOPS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "-";
            // 
            // myToolStrip
            // 
            this.myToolStrip.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.myToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFilter,
            this.tsbFilterDocs,
            this.tsbFindInDocs,
            this.toolStripButton1,
            this.tsbDocs});
            this.myToolStrip.Location = new System.Drawing.Point(0, 0);
            this.myToolStrip.Name = "myToolStrip";
            this.myToolStrip.Size = new System.Drawing.Size(943, 39);
            this.myToolStrip.TabIndex = 17;
            this.myToolStrip.Text = "toolStrip1";
            this.myToolStrip.Visible = false;
            // 
            // tsbFilter
            // 
            this.tsbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbFilter.Image")));
            this.tsbFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFilter.Name = "tsbFilter";
            this.tsbFilter.Size = new System.Drawing.Size(72, 34);
            this.tsbFilter.Text = "&Filtrēt";
            this.tsbFilter.Click += new System.EventHandler(this.tsbFilter_Click);
            // 
            // tsbFilterDocs
            // 
            this.tsbFilterDocs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFilterDocs.Image = ((System.Drawing.Image)(resources.GetObject("tsbFilterDocs.Image")));
            this.tsbFilterDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFilterDocs.Name = "tsbFilterDocs";
            this.tsbFilterDocs.Size = new System.Drawing.Size(201, 34);
            this.tsbFilterDocs.Text = "&Atlasīt dokumentus";
            this.tsbFilterDocs.Click += new System.EventHandler(this.tsbFilterDocs_Click);
            // 
            // tsbFindInDocs
            // 
            this.tsbFindInDocs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFindInDocs.Image = ((System.Drawing.Image)(resources.GetObject("tsbFindInDocs.Image")));
            this.tsbFindInDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFindInDocs.Name = "tsbFindInDocs";
            this.tsbFindInDocs.Size = new System.Drawing.Size(200, 34);
            this.tsbFindInDocs.Text = "Atrast dokumentos";
            this.tsbFindInDocs.Click += new System.EventHandler(this.tsbFindInDocs_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dokumentuSarakstsToolStripMenuItem,
            this.ierakstuIzrakstsToolStripMenuItem});
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(107, 34);
            this.toolStripButton1.Text = "Izdrukai";
            // 
            // dokumentuSarakstsToolStripMenuItem
            // 
            this.dokumentuSarakstsToolStripMenuItem.Name = "dokumentuSarakstsToolStripMenuItem";
            this.dokumentuSarakstsToolStripMenuItem.Size = new System.Drawing.Size(310, 38);
            this.dokumentuSarakstsToolStripMenuItem.Text = "Dokumentu saraksts";
            this.dokumentuSarakstsToolStripMenuItem.Click += new System.EventHandler(this.dokumentuSarakstsToolStripMenuItem_Click);
            // 
            // ierakstuIzrakstsToolStripMenuItem
            // 
            this.ierakstuIzrakstsToolStripMenuItem.Name = "ierakstuIzrakstsToolStripMenuItem";
            this.ierakstuIzrakstsToolStripMenuItem.Size = new System.Drawing.Size(310, 38);
            this.ierakstuIzrakstsToolStripMenuItem.Text = "Ierakstu izraksts";
            this.ierakstuIzrakstsToolStripMenuItem.Click += new System.EventHandler(this.ierakstuIzrakstsToolStripMenuItem_Click);
            // 
            // tsbDocs
            // 
            this.tsbDocs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDocs.Image = ((System.Drawing.Image)(resources.GetObject("tsbDocs.Image")));
            this.tsbDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDocs.Name = "tsbDocs";
            this.tsbDocs.Size = new System.Drawing.Size(123, 34);
            this.tsbDocs.Text = "&Dokumenti";
            this.tsbDocs.Click += new System.EventHandler(this.tsbDocs_Click);
            // 
            // cmAndOr
            // 
            this.cmAndOr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmAndOr.Location = new System.Drawing.Point(7, 45);
            this.cmAndOr.Margin = new System.Windows.Forms.Padding(2);
            this.cmAndOr.Name = "cmAndOr";
            this.cmAndOr.Size = new System.Drawing.Size(47, 36);
            this.cmAndOr.TabIndex = 10;
            this.cmAndOr.Text = "vai";
            this.cmAndOr.UseVisualStyleBackColor = true;
            this.cmAndOr.Click += new System.EventHandler(this.cmAndOr_Click);
            // 
            // dgvOPS
            // 
            this.dgvOPS.AllowUserToAddRows = false;
            this.dgvOPS.AllowUserToDeleteRows = false;
            this.dgvOPS.AllowUserToResizeRows = false;
            this.dgvOPS.AutoGenerateColumns = false;
            this.dgvOPS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvOPS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOPS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcZNR,
            this.dgcDate,
            this.dgcDocTyp,
            this.dgcDocSt,
            this.dgcDocNr,
            this.dgcClid,
            this.dgcRegNr,
            this.dgcPVNRegNr,
            this.dgcDescr,
            this.dgcAC11,
            this.dgcAC21,
            this.sgcSumm,
            this.dgcAC12,
            this.dgcAC13,
            this.dgcAC14,
            this.dgcAC15,
            this.dgcAC22,
            this.dgcAC23,
            this.dgcAC24,
            this.dgcAC25,
            this.dgcQV,
            this.dgcDescr2});
            this.dgvOPS.DataSource = this.bs_vwOPS;
            this.dgvOPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOPS.Location = new System.Drawing.Point(0, 97);
            this.dgvOPS.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOPS.Name = "dgvOPS";
            this.dgvOPS.ReadOnly = true;
            this.dgvOPS.RowHeadersWidth = 62;
            this.dgvOPS.RowTemplate.Height = 28;
            this.dgvOPS.ShowCellToolTips = false;
            this.dgvOPS.Size = new System.Drawing.Size(943, 377);
            this.dgvOPS.TabIndex = 18;
            this.dgvOPS.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dgvOPS_CellToolTipTextNeeded);
            // 
            // bs_vwOPS
            // 
            this.bs_vwOPS.AllowNew = false;
            this.bs_vwOPS.DataMember = "vw_OPS";
            this.bs_vwOPS.MyDataSource = "KlonsData";
            this.bs_vwOPS.Name2 = "vwOPS";
            // 
            // cbAC25
            // 
            this.cbAC25.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC25.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbAC25.ColumnWidths = "100;400";
            this.cbAC25.DisplayMember = "idx";
            this.cbAC25.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC25.DropDownHeight = 315;
            this.cbAC25.DropDownWidth = 528;
            this.cbAC25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC25.FormattingEnabled = true;
            this.cbAC25.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.cbAC25.GridLineHorizontal = false;
            this.cbAC25.GridLineVertical = true;
            this.cbAC25.IntegralHeight = false;
            this.cbAC25.Location = new System.Drawing.Point(401, 65);
            this.cbAC25.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC25.MaxDropDownItems = 15;
            this.cbAC25.Name = "cbAC25";
            this.cbAC25.Size = new System.Drawing.Size(79, 27);
            this.cbAC25.TabIndex = 15;
            this.cbAC25.ValueMember = "idx";
            this.cbAC25.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbAC25.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbACp5_MouseDoubleClick);
            // 
            // cbAC24
            // 
            this.cbAC24.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC24.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbAC24.ColumnWidths = "100;400";
            this.cbAC24.DisplayMember = "idx";
            this.cbAC24.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC24.DropDownHeight = 315;
            this.cbAC24.DropDownWidth = 528;
            this.cbAC24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC24.FormattingEnabled = true;
            this.cbAC24.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.cbAC24.GridLineHorizontal = false;
            this.cbAC24.GridLineVertical = true;
            this.cbAC24.IntegralHeight = false;
            this.cbAC24.Location = new System.Drawing.Point(317, 65);
            this.cbAC24.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC24.MaxDropDownItems = 15;
            this.cbAC24.Name = "cbAC24";
            this.cbAC24.Size = new System.Drawing.Size(79, 27);
            this.cbAC24.TabIndex = 14;
            this.cbAC24.ValueMember = "idx";
            this.cbAC24.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbAC24.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbACp4_MouseDoubleClick);
            // 
            // cbAC23
            // 
            this.cbAC23.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC23.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbAC23.ColumnWidths = "100;400";
            this.cbAC23.DisplayMember = "idx";
            this.cbAC23.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC23.DropDownHeight = 315;
            this.cbAC23.DropDownWidth = 528;
            this.cbAC23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC23.FormattingEnabled = true;
            this.cbAC23.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.cbAC23.GridLineHorizontal = false;
            this.cbAC23.GridLineVertical = true;
            this.cbAC23.IntegralHeight = false;
            this.cbAC23.Location = new System.Drawing.Point(232, 65);
            this.cbAC23.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC23.MaxDropDownItems = 15;
            this.cbAC23.Name = "cbAC23";
            this.cbAC23.Size = new System.Drawing.Size(79, 27);
            this.cbAC23.TabIndex = 13;
            this.cbAC23.ValueMember = "idx";
            this.cbAC23.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbAC23.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbACp3_MouseDoubleClick);
            // 
            // cbAC22
            // 
            this.cbAC22.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC22.ColumnNames = new string[] {
        "ac",
        "name"};
            this.cbAC22.ColumnWidths = "100;400";
            this.cbAC22.DisplayMember = "AC";
            this.cbAC22.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC22.DropDownHeight = 315;
            this.cbAC22.DropDownWidth = 528;
            this.cbAC22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC22.FormattingEnabled = true;
            this.cbAC22.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.cbAC22.GridLineHorizontal = false;
            this.cbAC22.GridLineVertical = true;
            this.cbAC22.IntegralHeight = false;
            this.cbAC22.Location = new System.Drawing.Point(147, 65);
            this.cbAC22.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC22.MaxDropDownItems = 15;
            this.cbAC22.Name = "cbAC22";
            this.cbAC22.Size = new System.Drawing.Size(79, 27);
            this.cbAC22.TabIndex = 12;
            this.cbAC22.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbAC22.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbAC_MouseDoubleClick);
            // 
            // cbAC21
            // 
            this.cbAC21.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC21.ColumnNames = new string[] {
        "ac",
        "name"};
            this.cbAC21.ColumnWidths = "100;400";
            this.cbAC21.DisplayMember = "AC";
            this.cbAC21.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC21.DropDownHeight = 315;
            this.cbAC21.DropDownWidth = 528;
            this.cbAC21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC21.FormattingEnabled = true;
            this.cbAC21.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.cbAC21.GridLineHorizontal = false;
            this.cbAC21.GridLineVertical = true;
            this.cbAC21.IntegralHeight = false;
            this.cbAC21.Location = new System.Drawing.Point(62, 65);
            this.cbAC21.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC21.MaxDropDownItems = 15;
            this.cbAC21.Name = "cbAC21";
            this.cbAC21.Size = new System.Drawing.Size(79, 27);
            this.cbAC21.TabIndex = 11;
            this.cbAC21.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbAC21.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbAC_MouseDoubleClick);
            // 
            // cbAC15
            // 
            this.cbAC15.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC15.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbAC15.ColumnWidths = "100;400";
            this.cbAC15.DisplayMember = "idx";
            this.cbAC15.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC15.DropDownHeight = 315;
            this.cbAC15.DropDownWidth = 528;
            this.cbAC15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC15.FormattingEnabled = true;
            this.cbAC15.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.cbAC15.GridLineHorizontal = false;
            this.cbAC15.GridLineVertical = true;
            this.cbAC15.IntegralHeight = false;
            this.cbAC15.Location = new System.Drawing.Point(401, 35);
            this.cbAC15.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC15.MaxDropDownItems = 15;
            this.cbAC15.Name = "cbAC15";
            this.cbAC15.Size = new System.Drawing.Size(79, 27);
            this.cbAC15.TabIndex = 9;
            this.cbAC15.ValueMember = "idx";
            this.cbAC15.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbAC15.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbACp5_MouseDoubleClick);
            // 
            // cbAC14
            // 
            this.cbAC14.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC14.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbAC14.ColumnWidths = "100;400";
            this.cbAC14.DisplayMember = "idx";
            this.cbAC14.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC14.DropDownHeight = 315;
            this.cbAC14.DropDownWidth = 528;
            this.cbAC14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC14.FormattingEnabled = true;
            this.cbAC14.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.cbAC14.GridLineHorizontal = false;
            this.cbAC14.GridLineVertical = true;
            this.cbAC14.IntegralHeight = false;
            this.cbAC14.Location = new System.Drawing.Point(317, 35);
            this.cbAC14.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC14.MaxDropDownItems = 15;
            this.cbAC14.Name = "cbAC14";
            this.cbAC14.Size = new System.Drawing.Size(79, 27);
            this.cbAC14.TabIndex = 8;
            this.cbAC14.ValueMember = "idx";
            this.cbAC14.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbAC14.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbACp4_MouseDoubleClick);
            // 
            // cbAC13
            // 
            this.cbAC13.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC13.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbAC13.ColumnWidths = "100;400";
            this.cbAC13.DisplayMember = "idx";
            this.cbAC13.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC13.DropDownHeight = 315;
            this.cbAC13.DropDownWidth = 528;
            this.cbAC13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC13.FormattingEnabled = true;
            this.cbAC13.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.cbAC13.GridLineHorizontal = false;
            this.cbAC13.GridLineVertical = true;
            this.cbAC13.IntegralHeight = false;
            this.cbAC13.Location = new System.Drawing.Point(232, 35);
            this.cbAC13.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC13.MaxDropDownItems = 15;
            this.cbAC13.Name = "cbAC13";
            this.cbAC13.Size = new System.Drawing.Size(79, 27);
            this.cbAC13.TabIndex = 7;
            this.cbAC13.ValueMember = "idx";
            this.cbAC13.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbAC13.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbACp3_MouseDoubleClick);
            // 
            // cbAC12
            // 
            this.cbAC12.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC12.ColumnNames = new string[] {
        "ac",
        "name"};
            this.cbAC12.ColumnWidths = "100;400";
            this.cbAC12.DisplayMember = "AC";
            this.cbAC12.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC12.DropDownHeight = 315;
            this.cbAC12.DropDownWidth = 528;
            this.cbAC12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC12.FormattingEnabled = true;
            this.cbAC12.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.cbAC12.GridLineHorizontal = false;
            this.cbAC12.GridLineVertical = true;
            this.cbAC12.IntegralHeight = false;
            this.cbAC12.Location = new System.Drawing.Point(147, 35);
            this.cbAC12.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC12.MaxDropDownItems = 15;
            this.cbAC12.Name = "cbAC12";
            this.cbAC12.Size = new System.Drawing.Size(79, 27);
            this.cbAC12.TabIndex = 6;
            this.cbAC12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbAC12.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbAC_MouseDoubleClick);
            // 
            // cbAC11
            // 
            this.cbAC11.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC11.ColumnNames = new string[] {
        "ac",
        "name"};
            this.cbAC11.ColumnWidths = "100;400";
            this.cbAC11.DisplayMember = "AC";
            this.cbAC11.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC11.DropDownHeight = 315;
            this.cbAC11.DropDownWidth = 528;
            this.cbAC11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC11.FormattingEnabled = true;
            this.cbAC11.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.cbAC11.GridLineHorizontal = false;
            this.cbAC11.GridLineVertical = true;
            this.cbAC11.IntegralHeight = false;
            this.cbAC11.Location = new System.Drawing.Point(62, 35);
            this.cbAC11.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC11.MaxDropDownItems = 15;
            this.cbAC11.Name = "cbAC11";
            this.cbAC11.Size = new System.Drawing.Size(79, 27);
            this.cbAC11.TabIndex = 5;
            this.cbAC11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbAC11.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbAC_MouseDoubleClick);
            // 
            // tbText
            // 
            this.tbText.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbText.Location = new System.Drawing.Point(356, 5);
            this.tbText.Margin = new System.Windows.Forms.Padding(2);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(94, 26);
            this.tbText.TabIndex = 3;
            this.tbText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // cbClid
            // 
            this.cbClid.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbClid.ColumnNames = new string[] {
        "clid",
        "name"};
            this.cbClid.ColumnWidths = "120;400";
            this.cbClid.DisplayMember = "clid";
            this.cbClid.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbClid.DropDownHeight = 315;
            this.cbClid.DropDownWidth = 548;
            this.cbClid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbClid.FormattingEnabled = true;
            this.cbClid.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.cbClid.GridLineHorizontal = false;
            this.cbClid.GridLineVertical = true;
            this.cbClid.IntegralHeight = false;
            this.cbClid.Location = new System.Drawing.Point(236, 5);
            this.cbClid.Margin = new System.Windows.Forms.Padding(2);
            this.cbClid.MaxDropDownItems = 15;
            this.cbClid.Name = "cbClid";
            this.cbClid.Size = new System.Drawing.Size(115, 27);
            this.cbClid.TabIndex = 2;
            this.cbClid.ValueMember = "clid";
            this.cbClid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbClid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbClid_MouseDoubleClick);
            // 
            // tbDate2
            // 
            this.tbDate2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate2.Location = new System.Drawing.Point(120, 5);
            this.tbDate2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDate2.Name = "tbDate2";
            this.tbDate2.Size = new System.Drawing.Size(90, 26);
            this.tbDate2.TabIndex = 1;
            this.tbDate2.Text = "01.01.2014";
            this.tbDate2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.tbDate2.Leave += new System.EventHandler(this.tbDate1_Leave);
            // 
            // tbDate1
            // 
            this.tbDate1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate1.Location = new System.Drawing.Point(7, 5);
            this.tbDate1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDate1.Name = "tbDate1";
            this.tbDate1.Size = new System.Drawing.Size(90, 26);
            this.tbDate1.TabIndex = 0;
            this.tbDate1.Text = "01.01.2014";
            this.tbDate1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.tbDate1.Leave += new System.EventHandler(this.tbDate1_Leave);
            // 
            // tbSum
            // 
            this.tbSum.BackColor = System.Drawing.SystemColors.Control;
            this.tbSum.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSum.Location = new System.Drawing.Point(563, 65);
            this.tbSum.Margin = new System.Windows.Forms.Padding(2);
            this.tbSum.Name = "tbSum";
            this.tbSum.ReadOnly = true;
            this.tbSum.Size = new System.Drawing.Size(107, 26);
            this.tbSum.TabIndex = 17;
            this.tbSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(488, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Summa:";
            // 
            // cbDocGr
            // 
            this.cbDocGr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbDocGr.ColumnNames = new string[] {
        "id",
        "name"};
            this.cbDocGr.ColumnWidths = "100;400";
            this.cbDocGr.DisplayMember = "id";
            this.cbDocGr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDocGr.DropDownHeight = 315;
            this.cbDocGr.DropDownWidth = 528;
            this.cbDocGr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDocGr.FormattingEnabled = true;
            this.cbDocGr.GridLineColor = System.Drawing.SystemColors.WindowText;
            this.cbDocGr.GridLineHorizontal = false;
            this.cbDocGr.GridLineVertical = true;
            this.cbDocGr.IntegralHeight = false;
            this.cbDocGr.Location = new System.Drawing.Point(455, 5);
            this.cbDocGr.Margin = new System.Windows.Forms.Padding(2);
            this.cbDocGr.MaxDropDownItems = 15;
            this.cbDocGr.Name = "cbDocGr";
            this.cbDocGr.Size = new System.Drawing.Size(123, 27);
            this.cbDocGr.TabIndex = 4;
            this.cbDocGr.ValueMember = "id";
            this.cbDocGr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbDocGr.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbACp5_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ierakstuŽurnālsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 436);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(943, 38);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // ierakstuŽurnālsToolStripMenuItem
            // 
            this.ierakstuŽurnālsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rādītPilnuPersonasNosaukumuToolStripMenuItem,
            this.rādītPersonasReģistrācijasNumuruToolStripMenuItem,
            this.rādītPersonasPVNReģistrācijasNumuruToolStripMenuItem});
            this.ierakstuŽurnālsToolStripMenuItem.Name = "ierakstuŽurnālsToolStripMenuItem";
            this.ierakstuŽurnālsToolStripMenuItem.Size = new System.Drawing.Size(178, 34);
            this.ierakstuŽurnālsToolStripMenuItem.Text = "Ierakstu žurnāls";
            // 
            // rādītPilnuPersonasNosaukumuToolStripMenuItem
            // 
            this.rādītPilnuPersonasNosaukumuToolStripMenuItem.Name = "rādītPilnuPersonasNosaukumuToolStripMenuItem";
            this.rādītPilnuPersonasNosaukumuToolStripMenuItem.Size = new System.Drawing.Size(458, 38);
            this.rādītPilnuPersonasNosaukumuToolStripMenuItem.Text = "Rādīt pilnu personas nosaukumu";
            this.rādītPilnuPersonasNosaukumuToolStripMenuItem.Click += new System.EventHandler(this.rādītPilnuPersonasNosaukumuToolStripMenuItem_Click);
            // 
            // rādītPersonasReģistrācijasNumuruToolStripMenuItem
            // 
            this.rādītPersonasReģistrācijasNumuruToolStripMenuItem.Name = "rādītPersonasReģistrācijasNumuruToolStripMenuItem";
            this.rādītPersonasReģistrācijasNumuruToolStripMenuItem.Size = new System.Drawing.Size(458, 38);
            this.rādītPersonasReģistrācijasNumuruToolStripMenuItem.Text = "Rādīt personas reģistrācijas numuru";
            this.rādītPersonasReģistrācijasNumuruToolStripMenuItem.Click += new System.EventHandler(this.rādītPersonasReģistrācijasNumuruToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbAC21);
            this.panel1.Controls.Add(this.tbDate1);
            this.panel1.Controls.Add(this.tbDate2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmAndOr);
            this.panel1.Controls.Add(this.cbClid);
            this.panel1.Controls.Add(this.cbAC25);
            this.panel1.Controls.Add(this.tbText);
            this.panel1.Controls.Add(this.cbAC24);
            this.panel1.Controls.Add(this.tbSum);
            this.panel1.Controls.Add(this.cbAC23);
            this.panel1.Controls.Add(this.cbAC11);
            this.panel1.Controls.Add(this.cbAC22);
            this.panel1.Controls.Add(this.cbAC12);
            this.panel1.Controls.Add(this.cbAC13);
            this.panel1.Controls.Add(this.cbDocGr);
            this.panel1.Controls.Add(this.cbAC14);
            this.panel1.Controls.Add(this.cbAC15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 97);
            this.panel1.TabIndex = 21;
            // 
            // dgcZNR
            // 
            this.dgcZNR.DataPropertyName = "ZNR";
            this.dgcZNR.HeaderText = "N.p.k.";
            this.dgcZNR.MinimumWidth = 9;
            this.dgcZNR.Name = "dgcZNR";
            this.dgcZNR.ReadOnly = true;
            this.dgcZNR.Width = 63;
            // 
            // dgcDate
            // 
            this.dgcDate.DataPropertyName = "Dete";
            dataGridViewCellStyle5.Format = "dd.MM.yyyy";
            this.dgcDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcDate.HeaderText = "Datums";
            this.dgcDate.MinimumWidth = 9;
            this.dgcDate.Name = "dgcDate";
            this.dgcDate.ReadOnly = true;
            this.dgcDate.Width = 99;
            // 
            // dgcDocTyp
            // 
            this.dgcDocTyp.DataPropertyName = "DocTyp";
            this.dgcDocTyp.HeaderText = "Dok.veids";
            this.dgcDocTyp.MinimumWidth = 9;
            this.dgcDocTyp.Name = "dgcDocTyp";
            this.dgcDocTyp.ReadOnly = true;
            this.dgcDocTyp.Width = 72;
            // 
            // dgcDocSt
            // 
            this.dgcDocSt.DataPropertyName = "DocSt";
            this.dgcDocSt.HeaderText = "Sērija";
            this.dgcDocSt.MinimumWidth = 9;
            this.dgcDocSt.Name = "dgcDocSt";
            this.dgcDocSt.ReadOnly = true;
            this.dgcDocSt.Width = 45;
            // 
            // dgcDocNr
            // 
            this.dgcDocNr.DataPropertyName = "DocNr";
            this.dgcDocNr.HeaderText = "Dok.nr.";
            this.dgcDocNr.MinimumWidth = 9;
            this.dgcDocNr.Name = "dgcDocNr";
            this.dgcDocNr.ReadOnly = true;
            this.dgcDocNr.Width = 90;
            // 
            // dgcClid
            // 
            this.dgcClid.DataPropertyName = "ClId";
            this.dgcClid.HeaderText = "Persona";
            this.dgcClid.MinimumWidth = 9;
            this.dgcClid.Name = "dgcClid";
            this.dgcClid.ReadOnly = true;
            this.dgcClid.Width = 108;
            // 
            // dgcRegNr
            // 
            this.dgcRegNr.DataPropertyName = "RegNr";
            this.dgcRegNr.HeaderText = "Reģ.nr.";
            this.dgcRegNr.MinimumWidth = 8;
            this.dgcRegNr.Name = "dgcRegNr";
            this.dgcRegNr.ReadOnly = true;
            this.dgcRegNr.ToolTipText = "Personas reģistrācijas numurs";
            this.dgcRegNr.Width = 120;
            // 
            // dgcPVNRegNr
            // 
            this.dgcPVNRegNr.DataPropertyName = "PVNRegNr";
            this.dgcPVNRegNr.HeaderText = "PVN Reģ.nr.";
            this.dgcPVNRegNr.MinimumWidth = 8;
            this.dgcPVNRegNr.Name = "dgcPVNRegNr";
            this.dgcPVNRegNr.ReadOnly = true;
            this.dgcPVNRegNr.Width = 130;
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "Descr";
            this.dgcDescr.HeaderText = "Apraksts";
            this.dgcDescr.MinimumWidth = 9;
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.ReadOnly = true;
            this.dgcDescr.Width = 144;
            // 
            // dgcAC11
            // 
            this.dgcAC11.DataPropertyName = "AC11";
            this.dgcAC11.HeaderText = "Debets";
            this.dgcAC11.MinimumWidth = 9;
            this.dgcAC11.Name = "dgcAC11";
            this.dgcAC11.ReadOnly = true;
            this.dgcAC11.Width = 72;
            // 
            // dgcAC21
            // 
            this.dgcAC21.DataPropertyName = "AC21";
            this.dgcAC21.HeaderText = "Kredīts";
            this.dgcAC21.MinimumWidth = 9;
            this.dgcAC21.Name = "dgcAC21";
            this.dgcAC21.ReadOnly = true;
            this.dgcAC21.Width = 72;
            // 
            // sgcSumm
            // 
            this.sgcSumm.DataPropertyName = "Summ";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.sgcSumm.DefaultCellStyle = dataGridViewCellStyle6;
            this.sgcSumm.HeaderText = "Summa";
            this.sgcSumm.MinimumWidth = 9;
            this.sgcSumm.Name = "sgcSumm";
            this.sgcSumm.ReadOnly = true;
            this.sgcSumm.Width = 90;
            // 
            // dgcAC12
            // 
            this.dgcAC12.DataPropertyName = "AC12";
            this.dgcAC12.HeaderText = "D2";
            this.dgcAC12.MinimumWidth = 9;
            this.dgcAC12.Name = "dgcAC12";
            this.dgcAC12.ReadOnly = true;
            this.dgcAC12.Width = 72;
            // 
            // dgcAC13
            // 
            this.dgcAC13.DataPropertyName = "AC13";
            this.dgcAC13.HeaderText = "D3";
            this.dgcAC13.MinimumWidth = 9;
            this.dgcAC13.Name = "dgcAC13";
            this.dgcAC13.ReadOnly = true;
            this.dgcAC13.Width = 45;
            // 
            // dgcAC14
            // 
            this.dgcAC14.DataPropertyName = "AC14";
            this.dgcAC14.HeaderText = "D4";
            this.dgcAC14.MinimumWidth = 9;
            this.dgcAC14.Name = "dgcAC14";
            this.dgcAC14.ReadOnly = true;
            this.dgcAC14.Width = 72;
            // 
            // dgcAC15
            // 
            this.dgcAC15.DataPropertyName = "AC15";
            this.dgcAC15.HeaderText = "D5";
            this.dgcAC15.MinimumWidth = 9;
            this.dgcAC15.Name = "dgcAC15";
            this.dgcAC15.ReadOnly = true;
            this.dgcAC15.Width = 54;
            // 
            // dgcAC22
            // 
            this.dgcAC22.DataPropertyName = "AC22";
            this.dgcAC22.HeaderText = "K2";
            this.dgcAC22.MinimumWidth = 9;
            this.dgcAC22.Name = "dgcAC22";
            this.dgcAC22.ReadOnly = true;
            this.dgcAC22.Width = 72;
            // 
            // dgcAC23
            // 
            this.dgcAC23.DataPropertyName = "AC23";
            this.dgcAC23.HeaderText = "K3";
            this.dgcAC23.MinimumWidth = 9;
            this.dgcAC23.Name = "dgcAC23";
            this.dgcAC23.ReadOnly = true;
            this.dgcAC23.Width = 45;
            // 
            // dgcAC24
            // 
            this.dgcAC24.DataPropertyName = "AC24";
            this.dgcAC24.HeaderText = "K4";
            this.dgcAC24.MinimumWidth = 9;
            this.dgcAC24.Name = "dgcAC24";
            this.dgcAC24.ReadOnly = true;
            this.dgcAC24.Width = 72;
            // 
            // dgcAC25
            // 
            this.dgcAC25.DataPropertyName = "AC25";
            this.dgcAC25.HeaderText = "K5";
            this.dgcAC25.MinimumWidth = 9;
            this.dgcAC25.Name = "dgcAC25";
            this.dgcAC25.ReadOnly = true;
            this.dgcAC25.Width = 54;
            // 
            // dgcQV
            // 
            this.dgcQV.DataPropertyName = "QV";
            this.dgcQV.HeaderText = "Daudzums";
            this.dgcQV.MinimumWidth = 9;
            this.dgcQV.Name = "dgcQV";
            this.dgcQV.ReadOnly = true;
            this.dgcQV.Width = 90;
            // 
            // dgcDescr2
            // 
            this.dgcDescr2.DataPropertyName = "Descr2";
            this.dgcDescr2.HeaderText = "Apraksts";
            this.dgcDescr2.MinimumWidth = 8;
            this.dgcDescr2.Name = "dgcDescr2";
            this.dgcDescr2.ReadOnly = true;
            this.dgcDescr2.Width = 144;
            // 
            // rādītPersonasPVNReģistrācijasNumuruToolStripMenuItem
            // 
            this.rādītPersonasPVNReģistrācijasNumuruToolStripMenuItem.Name = "rādītPersonasPVNReģistrācijasNumuruToolStripMenuItem";
            this.rādītPersonasPVNReģistrācijasNumuruToolStripMenuItem.Size = new System.Drawing.Size(506, 38);
            this.rādītPersonasPVNReģistrācijasNumuruToolStripMenuItem.Text = "Rādīt personas PVN reģistrācijas numuru";
            this.rādītPersonasPVNReģistrācijasNumuruToolStripMenuItem.Click += new System.EventHandler(this.rādītPersonasPVNReģistrācijasNumuruToolStripMenuItem_Click);
            // 
            // Form_OpsFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 474);
            this.Controls.Add(this.dgvOPS);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.myToolStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MyToolStrip = this.myToolStrip;
            this.Name = "Form_OpsFilter";
            this.Text = "Ierakstu žurnāls";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_OpsFilter_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormOpsFilter_FormClosed);
            this.Load += new System.EventHandler(this.FormOpsFilter_Load);
            this.myToolStrip.ResumeLayout(false);
            this.myToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_vwOPS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyTextBox tbDate1;
        private MyTextBox tbDate2;
        private System.Windows.Forms.Label label1;
        private MyMcFlatComboBox cbClid;
        private MyTextBox tbText;
        private MyMcFlatComboBox cbAC11;
        private MyMcFlatComboBox cbAC21;
        private MyMcFlatComboBox cbAC12;
        private MyMcFlatComboBox cbAC22;
        private MyMcFlatComboBox cbAC13;
        private MyMcFlatComboBox cbAC23;
        private MyMcFlatComboBox cbAC14;
        private MyMcFlatComboBox cbAC24;
        private MyMcFlatComboBox cbAC15;
        private MyMcFlatComboBox cbAC25;
        private MyDataGridView dgvOPS;
        private MyBindingSource bs_vwOPS;
        private System.Windows.Forms.ToolStripButton tsbFilter;
        private System.Windows.Forms.ToolStripButton tsbFilterDocs;
        private System.Windows.Forms.Button cmAndOr;
        public System.Windows.Forms.ToolStrip myToolStrip;
        private MyTextBox tbSum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton tsbDocs;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem dokumentuSarakstsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbFindInDocs;
        private System.Windows.Forms.ToolStripMenuItem ierakstuIzrakstsToolStripMenuItem;
        private MyMcFlatComboBox cbDocGr;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ierakstuŽurnālsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rādītPilnuPersonasNosaukumuToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem rādītPersonasReģistrācijasNumuruToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcZNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocTyp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcClid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRegNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPVNRegNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAC11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAC21;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgcSumm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAC12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAC13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAC14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAC15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAC22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAC23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAC24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAC25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcQV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescr2;
        private System.Windows.Forms.ToolStripMenuItem rādītPersonasPVNReģistrācijasNumuruToolStripMenuItem;
    }
}