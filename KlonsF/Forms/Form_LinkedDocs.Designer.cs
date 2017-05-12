using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.Forms
{
    partial class Form_LinkedDocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LinkedDocs));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsDocs = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsOPS = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbSumm = new System.Windows.Forms.ToolStripTextBox();
            this.tbPVN = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cmOK = new System.Windows.Forms.ToolStripButton();
            this.cmCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cikGadusAtpakaļSkatītiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSetYears = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvOPSd = new KlonsLIB.Components.MyDataGridView();
            this.dgcDocsDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsDocTyp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsDocSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsDocNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsSumm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsPVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOPS = new KlonsLIB.Components.MyDataGridView();
            this.dgcOPSAC11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOPSAC12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOPSAC13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOPSAC14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOPSAC15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOPSAC21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOPSAC22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOPSAC23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOPSAC24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOPSAC25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOPSSummC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOPSCur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOPSSumm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOPSDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aC11DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aC12DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aC13DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aC14DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aC15DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aC21DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aC22DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aC23DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aC24DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aC25DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOPS)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOPSd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOPS)).BeginInit();
            this.SuspendLayout();
            // 
            // bsDocs
            // 
            this.bsDocs.DataMember = "TRepOPSd";
            this.bsDocs.MyDataSource = "KlonsRep";
            this.bsDocs.Name2 = "bsOPS";
            // 
            // bsOPS
            // 
            this.bsOPS.DataMember = "TRepOPSd_TRepOPS";
            this.bsOPS.DataSource = this.bsDocs;
            this.bsOPS.Name2 = "bsOPS";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tbSumm,
            this.tbPVN,
            this.toolStripLabel2,
            this.cmOK,
            this.cmCancel,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(688, 32);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(101, 29);
            this.toolStripLabel1.Text = "Summas: ";
            // 
            // tbSumm
            // 
            this.tbSumm.Name = "tbSumm";
            this.tbSumm.Size = new System.Drawing.Size(81, 32);
            this.tbSumm.Text = "0.00";
            this.tbSumm.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbPVN
            // 
            this.tbPVN.Name = "tbPVN";
            this.tbPVN.Size = new System.Drawing.Size(81, 32);
            this.tbPVN.Text = "0.00";
            this.tbPVN.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(42, 29);
            this.toolStripLabel2.Text = "      ";
            // 
            // cmOK
            // 
            this.cmOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmOK.Image = ((System.Drawing.Image)(resources.GetObject("cmOK.Image")));
            this.cmOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmOK.Name = "cmOK";
            this.cmOK.Size = new System.Drawing.Size(169, 29);
            this.cmOK.Text = "Izm&antot summas";
            this.cmOK.Click += new System.EventHandler(this.cmOK_Click);
            // 
            // cmCancel
            // 
            this.cmCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmCancel.Image")));
            this.cmCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(65, 29);
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.Click += new System.EventHandler(this.cmCancel_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cikGadusAtpakaļSkatītiesToolStripMenuItem,
            this.tbSetYears});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(51, 29);
            this.toolStripButton1.Text = "*!*";
            // 
            // cikGadusAtpakaļSkatītiesToolStripMenuItem
            // 
            this.cikGadusAtpakaļSkatītiesToolStripMenuItem.Name = "cikGadusAtpakaļSkatītiesToolStripMenuItem";
            this.cikGadusAtpakaļSkatītiesToolStripMenuItem.Size = new System.Drawing.Size(329, 30);
            this.cikGadusAtpakaļSkatītiesToolStripMenuItem.Text = "Cik gadus atpakaļ skatīties:";
            // 
            // tbSetYears
            // 
            this.tbSetYears.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.tbSetYears.Name = "tbSetYears";
            this.tbSetYears.Size = new System.Drawing.Size(121, 33);
            this.tbSetYears.TextChanged += new System.EventHandler(this.tbSetYears_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvOPSd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvOPS);
            this.splitContainer1.Size = new System.Drawing.Size(688, 249);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 4;
            // 
            // dgvOPSd
            // 
            this.dgvOPSd.AllowUserToAddRows = false;
            this.dgvOPSd.AllowUserToDeleteRows = false;
            this.dgvOPSd.AllowUserToResizeRows = false;
            this.dgvOPSd.AutoGenerateColumns = false;
            this.dgvOPSd.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvOPSd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOPSd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDocsDate,
            this.dgcDocsDocTyp,
            this.dgcDocsDocSt,
            this.dgcDocsDocNr,
            this.dgcDescr,
            this.dgcDocsSumm,
            this.dgcDocsPVN});
            this.dgvOPSd.DataSource = this.bsDocs;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOPSd.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOPSd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOPSd.Location = new System.Drawing.Point(0, 0);
            this.dgvOPSd.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOPSd.Name = "dgvOPSd";
            this.dgvOPSd.ReadOnly = true;
            this.dgvOPSd.RowHeadersVisible = false;
            this.dgvOPSd.RowTemplate.Height = 20;
            this.dgvOPSd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOPSd.Size = new System.Drawing.Size(688, 138);
            this.dgvOPSd.TabIndex = 2;
            this.dgvOPSd.SelectionChanged += new System.EventHandler(this.dgvOPSd_SelectionChanged);
            // 
            // dgcDocsDate
            // 
            this.dgcDocsDate.DataPropertyName = "Dete";
            dataGridViewCellStyle1.Format = "dd.MM.yyyy";
            this.dgcDocsDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcDocsDate.HeaderText = "datums";
            this.dgcDocsDate.Name = "dgcDocsDate";
            this.dgcDocsDate.ReadOnly = true;
            this.dgcDocsDate.Width = 88;
            // 
            // dgcDocsDocTyp
            // 
            this.dgcDocsDocTyp.DataPropertyName = "DocTyp";
            this.dgcDocsDocTyp.HeaderText = "veids";
            this.dgcDocsDocTyp.Name = "dgcDocsDocTyp";
            this.dgcDocsDocTyp.ReadOnly = true;
            this.dgcDocsDocTyp.ToolTipText = "dokumenta veids";
            this.dgcDocsDocTyp.Width = 64;
            // 
            // dgcDocsDocSt
            // 
            this.dgcDocsDocSt.DataPropertyName = "DocSt";
            this.dgcDocsDocSt.HeaderText = "sērija";
            this.dgcDocsDocSt.Name = "dgcDocsDocSt";
            this.dgcDocsDocSt.ReadOnly = true;
            this.dgcDocsDocSt.Width = 48;
            // 
            // dgcDocsDocNr
            // 
            this.dgcDocsDocNr.DataPropertyName = "DocNr";
            this.dgcDocsDocNr.HeaderText = "numurs";
            this.dgcDocsDocNr.Name = "dgcDocsDocNr";
            this.dgcDocsDocNr.ReadOnly = true;
            this.dgcDocsDocNr.Width = 88;
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "Descr";
            this.dgcDescr.HeaderText = "apraksts";
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.ReadOnly = true;
            this.dgcDescr.Width = 120;
            // 
            // dgcDocsSumm
            // 
            this.dgcDocsSumm.DataPropertyName = "Summ";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dgcDocsSumm.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcDocsSumm.HeaderText = "summa";
            this.dgcDocsSumm.Name = "dgcDocsSumm";
            this.dgcDocsSumm.ReadOnly = true;
            this.dgcDocsSumm.Width = 80;
            // 
            // dgcDocsPVN
            // 
            this.dgcDocsPVN.DataPropertyName = "PVN";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dgcDocsPVN.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcDocsPVN.HeaderText = "PVN";
            this.dgcDocsPVN.Name = "dgcDocsPVN";
            this.dgcDocsPVN.ReadOnly = true;
            this.dgcDocsPVN.Width = 80;
            // 
            // dgvOPS
            // 
            this.dgvOPS.AllowUserToAddRows = false;
            this.dgvOPS.AllowUserToDeleteRows = false;
            this.dgvOPS.AutoGenerateColumns = false;
            this.dgvOPS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvOPS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOPS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcOPSAC11,
            this.dgcOPSAC12,
            this.dgcOPSAC13,
            this.dgcOPSAC14,
            this.dgcOPSAC15,
            this.dgcOPSAC21,
            this.dgcOPSAC22,
            this.dgcOPSAC23,
            this.dgcOPSAC24,
            this.dgcOPSAC25,
            this.dgcOPSSummC,
            this.dgcOPSCur,
            this.dgcOPSSumm,
            this.dgcOPSDescr,
            this.idDataGridViewTextBoxColumn,
            this.docIdDataGridViewTextBoxColumn,
            this.descrDataGridViewTextBoxColumn,
            this.aC11DataGridViewTextBoxColumn,
            this.aC12DataGridViewTextBoxColumn,
            this.aC13DataGridViewTextBoxColumn,
            this.aC14DataGridViewTextBoxColumn,
            this.aC15DataGridViewTextBoxColumn,
            this.aC21DataGridViewTextBoxColumn,
            this.aC22DataGridViewTextBoxColumn,
            this.aC23DataGridViewTextBoxColumn,
            this.aC24DataGridViewTextBoxColumn,
            this.aC25DataGridViewTextBoxColumn,
            this.summCDataGridViewTextBoxColumn,
            this.curDataGridViewTextBoxColumn,
            this.summDataGridViewTextBoxColumn,
            this.qVDataGridViewTextBoxColumn,
            this.nLDataGridViewTextBoxColumn,
            this.zDtDataGridViewTextBoxColumn});
            this.dgvOPS.DataSource = this.bsOPS;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOPS.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOPS.Location = new System.Drawing.Point(0, 0);
            this.dgvOPS.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOPS.Name = "dgvOPS";
            this.dgvOPS.ReadOnly = true;
            this.dgvOPS.RowHeadersVisible = false;
            this.dgvOPS.RowTemplate.Height = 20;
            this.dgvOPS.Size = new System.Drawing.Size(688, 108);
            this.dgvOPS.TabIndex = 3;
            // 
            // dgcOPSAC11
            // 
            this.dgcOPSAC11.DataPropertyName = "AC11";
            this.dgcOPSAC11.HeaderText = "debets";
            this.dgcOPSAC11.Name = "dgcOPSAC11";
            this.dgcOPSAC11.ReadOnly = true;
            this.dgcOPSAC11.Width = 64;
            // 
            // dgcOPSAC12
            // 
            this.dgcOPSAC12.DataPropertyName = "AC12";
            this.dgcOPSAC12.HeaderText = "n.p.";
            this.dgcOPSAC12.Name = "dgcOPSAC12";
            this.dgcOPSAC12.ReadOnly = true;
            this.dgcOPSAC12.ToolTipText = "Debets: naudas plūsmas konts";
            this.dgcOPSAC12.Width = 64;
            // 
            // dgcOPSAC13
            // 
            this.dgcOPSAC13.DataPropertyName = "AC13";
            this.dgcOPSAC13.HeaderText = "IIN";
            this.dgcOPSAC13.Name = "dgcOPSAC13";
            this.dgcOPSAC13.ReadOnly = true;
            this.dgcOPSAC13.ToolTipText = "Debets: IIN darijuma kods";
            this.dgcOPSAC13.Width = 40;
            // 
            // dgcOPSAC14
            // 
            this.dgcOPSAC14.DataPropertyName = "AC14";
            this.dgcOPSAC14.HeaderText = "nozare";
            this.dgcOPSAC14.Name = "dgcOPSAC14";
            this.dgcOPSAC14.ReadOnly = true;
            this.dgcOPSAC14.ToolTipText = "Debets: nozare / produkts";
            this.dgcOPSAC14.Width = 64;
            // 
            // dgcOPSAC15
            // 
            this.dgcOPSAC15.DataPropertyName = "AC15";
            this.dgcOPSAC15.HeaderText = "PVN";
            this.dgcOPSAC15.Name = "dgcOPSAC15";
            this.dgcOPSAC15.ReadOnly = true;
            this.dgcOPSAC15.ToolTipText = "Debets: PVN";
            this.dgcOPSAC15.Width = 48;
            // 
            // dgcOPSAC21
            // 
            this.dgcOPSAC21.DataPropertyName = "AC21";
            this.dgcOPSAC21.HeaderText = "kredīts";
            this.dgcOPSAC21.Name = "dgcOPSAC21";
            this.dgcOPSAC21.ReadOnly = true;
            this.dgcOPSAC21.Width = 64;
            // 
            // dgcOPSAC22
            // 
            this.dgcOPSAC22.DataPropertyName = "AC22";
            this.dgcOPSAC22.HeaderText = "n.p.";
            this.dgcOPSAC22.Name = "dgcOPSAC22";
            this.dgcOPSAC22.ReadOnly = true;
            this.dgcOPSAC22.ToolTipText = "Kredīts: naudas plūsmas konts";
            this.dgcOPSAC22.Width = 64;
            // 
            // dgcOPSAC23
            // 
            this.dgcOPSAC23.DataPropertyName = "AC23";
            this.dgcOPSAC23.HeaderText = "IIN";
            this.dgcOPSAC23.Name = "dgcOPSAC23";
            this.dgcOPSAC23.ReadOnly = true;
            this.dgcOPSAC23.ToolTipText = "Kredīts: IIN darijuma kods";
            this.dgcOPSAC23.Width = 40;
            // 
            // dgcOPSAC24
            // 
            this.dgcOPSAC24.DataPropertyName = "AC24";
            this.dgcOPSAC24.HeaderText = "nozare";
            this.dgcOPSAC24.Name = "dgcOPSAC24";
            this.dgcOPSAC24.ReadOnly = true;
            this.dgcOPSAC24.ToolTipText = "Kredīts: nozare / produkts";
            this.dgcOPSAC24.Width = 64;
            // 
            // dgcOPSAC25
            // 
            this.dgcOPSAC25.DataPropertyName = "AC25";
            this.dgcOPSAC25.HeaderText = "PVN";
            this.dgcOPSAC25.Name = "dgcOPSAC25";
            this.dgcOPSAC25.ReadOnly = true;
            this.dgcOPSAC25.ToolTipText = "Kredīts: PVN";
            this.dgcOPSAC25.Width = 48;
            // 
            // dgcOPSSummC
            // 
            this.dgcOPSSummC.DataPropertyName = "SummC";
            this.dgcOPSSummC.HeaderText = "summa";
            this.dgcOPSSummC.Name = "dgcOPSSummC";
            this.dgcOPSSummC.ReadOnly = true;
            this.dgcOPSSummC.ToolTipText = "Summa norādītajā valūtā";
            this.dgcOPSSummC.Width = 80;
            // 
            // dgcOPSCur
            // 
            this.dgcOPSCur.DataPropertyName = "Cur";
            this.dgcOPSCur.HeaderText = "valūta";
            this.dgcOPSCur.Name = "dgcOPSCur";
            this.dgcOPSCur.ReadOnly = true;
            this.dgcOPSCur.ToolTipText = "valūtas kods";
            this.dgcOPSCur.Width = 56;
            // 
            // dgcOPSSumm
            // 
            this.dgcOPSSumm.DataPropertyName = "Summ";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dgcOPSSumm.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcOPSSumm.HeaderText = "summa";
            this.dgcOPSSumm.Name = "dgcOPSSumm";
            this.dgcOPSSumm.ReadOnly = true;
            this.dgcOPSSumm.ToolTipText = "Summa EUR";
            this.dgcOPSSumm.Width = 80;
            // 
            // dgcOPSDescr
            // 
            this.dgcOPSDescr.DataPropertyName = "Descr";
            this.dgcOPSDescr.HeaderText = "apraksts";
            this.dgcOPSDescr.Name = "dgcOPSDescr";
            this.dgcOPSDescr.ReadOnly = true;
            this.dgcOPSDescr.Width = 80;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 80;
            // 
            // docIdDataGridViewTextBoxColumn
            // 
            this.docIdDataGridViewTextBoxColumn.DataPropertyName = "DocId";
            this.docIdDataGridViewTextBoxColumn.HeaderText = "DocId";
            this.docIdDataGridViewTextBoxColumn.Name = "docIdDataGridViewTextBoxColumn";
            this.docIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIdDataGridViewTextBoxColumn.Width = 80;
            // 
            // descrDataGridViewTextBoxColumn
            // 
            this.descrDataGridViewTextBoxColumn.DataPropertyName = "Descr";
            this.descrDataGridViewTextBoxColumn.HeaderText = "Descr";
            this.descrDataGridViewTextBoxColumn.Name = "descrDataGridViewTextBoxColumn";
            this.descrDataGridViewTextBoxColumn.ReadOnly = true;
            this.descrDataGridViewTextBoxColumn.Width = 80;
            // 
            // aC11DataGridViewTextBoxColumn
            // 
            this.aC11DataGridViewTextBoxColumn.DataPropertyName = "AC11";
            this.aC11DataGridViewTextBoxColumn.HeaderText = "AC11";
            this.aC11DataGridViewTextBoxColumn.Name = "aC11DataGridViewTextBoxColumn";
            this.aC11DataGridViewTextBoxColumn.ReadOnly = true;
            this.aC11DataGridViewTextBoxColumn.Width = 80;
            // 
            // aC12DataGridViewTextBoxColumn
            // 
            this.aC12DataGridViewTextBoxColumn.DataPropertyName = "AC12";
            this.aC12DataGridViewTextBoxColumn.HeaderText = "AC12";
            this.aC12DataGridViewTextBoxColumn.Name = "aC12DataGridViewTextBoxColumn";
            this.aC12DataGridViewTextBoxColumn.ReadOnly = true;
            this.aC12DataGridViewTextBoxColumn.Width = 80;
            // 
            // aC13DataGridViewTextBoxColumn
            // 
            this.aC13DataGridViewTextBoxColumn.DataPropertyName = "AC13";
            this.aC13DataGridViewTextBoxColumn.HeaderText = "AC13";
            this.aC13DataGridViewTextBoxColumn.Name = "aC13DataGridViewTextBoxColumn";
            this.aC13DataGridViewTextBoxColumn.ReadOnly = true;
            this.aC13DataGridViewTextBoxColumn.Width = 80;
            // 
            // aC14DataGridViewTextBoxColumn
            // 
            this.aC14DataGridViewTextBoxColumn.DataPropertyName = "AC14";
            this.aC14DataGridViewTextBoxColumn.HeaderText = "AC14";
            this.aC14DataGridViewTextBoxColumn.Name = "aC14DataGridViewTextBoxColumn";
            this.aC14DataGridViewTextBoxColumn.ReadOnly = true;
            this.aC14DataGridViewTextBoxColumn.Width = 80;
            // 
            // aC15DataGridViewTextBoxColumn
            // 
            this.aC15DataGridViewTextBoxColumn.DataPropertyName = "AC15";
            this.aC15DataGridViewTextBoxColumn.HeaderText = "AC15";
            this.aC15DataGridViewTextBoxColumn.Name = "aC15DataGridViewTextBoxColumn";
            this.aC15DataGridViewTextBoxColumn.ReadOnly = true;
            this.aC15DataGridViewTextBoxColumn.Width = 80;
            // 
            // aC21DataGridViewTextBoxColumn
            // 
            this.aC21DataGridViewTextBoxColumn.DataPropertyName = "AC21";
            this.aC21DataGridViewTextBoxColumn.HeaderText = "AC21";
            this.aC21DataGridViewTextBoxColumn.Name = "aC21DataGridViewTextBoxColumn";
            this.aC21DataGridViewTextBoxColumn.ReadOnly = true;
            this.aC21DataGridViewTextBoxColumn.Width = 80;
            // 
            // aC22DataGridViewTextBoxColumn
            // 
            this.aC22DataGridViewTextBoxColumn.DataPropertyName = "AC22";
            this.aC22DataGridViewTextBoxColumn.HeaderText = "AC22";
            this.aC22DataGridViewTextBoxColumn.Name = "aC22DataGridViewTextBoxColumn";
            this.aC22DataGridViewTextBoxColumn.ReadOnly = true;
            this.aC22DataGridViewTextBoxColumn.Width = 80;
            // 
            // aC23DataGridViewTextBoxColumn
            // 
            this.aC23DataGridViewTextBoxColumn.DataPropertyName = "AC23";
            this.aC23DataGridViewTextBoxColumn.HeaderText = "AC23";
            this.aC23DataGridViewTextBoxColumn.Name = "aC23DataGridViewTextBoxColumn";
            this.aC23DataGridViewTextBoxColumn.ReadOnly = true;
            this.aC23DataGridViewTextBoxColumn.Width = 80;
            // 
            // aC24DataGridViewTextBoxColumn
            // 
            this.aC24DataGridViewTextBoxColumn.DataPropertyName = "AC24";
            this.aC24DataGridViewTextBoxColumn.HeaderText = "AC24";
            this.aC24DataGridViewTextBoxColumn.Name = "aC24DataGridViewTextBoxColumn";
            this.aC24DataGridViewTextBoxColumn.ReadOnly = true;
            this.aC24DataGridViewTextBoxColumn.Width = 80;
            // 
            // aC25DataGridViewTextBoxColumn
            // 
            this.aC25DataGridViewTextBoxColumn.DataPropertyName = "AC25";
            this.aC25DataGridViewTextBoxColumn.HeaderText = "AC25";
            this.aC25DataGridViewTextBoxColumn.Name = "aC25DataGridViewTextBoxColumn";
            this.aC25DataGridViewTextBoxColumn.ReadOnly = true;
            this.aC25DataGridViewTextBoxColumn.Width = 80;
            // 
            // summCDataGridViewTextBoxColumn
            // 
            this.summCDataGridViewTextBoxColumn.DataPropertyName = "SummC";
            this.summCDataGridViewTextBoxColumn.HeaderText = "SummC";
            this.summCDataGridViewTextBoxColumn.Name = "summCDataGridViewTextBoxColumn";
            this.summCDataGridViewTextBoxColumn.ReadOnly = true;
            this.summCDataGridViewTextBoxColumn.Width = 80;
            // 
            // curDataGridViewTextBoxColumn
            // 
            this.curDataGridViewTextBoxColumn.DataPropertyName = "Cur";
            this.curDataGridViewTextBoxColumn.HeaderText = "Cur";
            this.curDataGridViewTextBoxColumn.Name = "curDataGridViewTextBoxColumn";
            this.curDataGridViewTextBoxColumn.ReadOnly = true;
            this.curDataGridViewTextBoxColumn.Width = 80;
            // 
            // summDataGridViewTextBoxColumn
            // 
            this.summDataGridViewTextBoxColumn.DataPropertyName = "Summ";
            this.summDataGridViewTextBoxColumn.HeaderText = "Summ";
            this.summDataGridViewTextBoxColumn.Name = "summDataGridViewTextBoxColumn";
            this.summDataGridViewTextBoxColumn.ReadOnly = true;
            this.summDataGridViewTextBoxColumn.Width = 80;
            // 
            // qVDataGridViewTextBoxColumn
            // 
            this.qVDataGridViewTextBoxColumn.DataPropertyName = "QV";
            this.qVDataGridViewTextBoxColumn.HeaderText = "QV";
            this.qVDataGridViewTextBoxColumn.Name = "qVDataGridViewTextBoxColumn";
            this.qVDataGridViewTextBoxColumn.ReadOnly = true;
            this.qVDataGridViewTextBoxColumn.Width = 80;
            // 
            // nLDataGridViewTextBoxColumn
            // 
            this.nLDataGridViewTextBoxColumn.DataPropertyName = "NL";
            this.nLDataGridViewTextBoxColumn.HeaderText = "NL";
            this.nLDataGridViewTextBoxColumn.Name = "nLDataGridViewTextBoxColumn";
            this.nLDataGridViewTextBoxColumn.ReadOnly = true;
            this.nLDataGridViewTextBoxColumn.Width = 80;
            // 
            // zDtDataGridViewTextBoxColumn
            // 
            this.zDtDataGridViewTextBoxColumn.DataPropertyName = "ZDt";
            this.zDtDataGridViewTextBoxColumn.HeaderText = "ZDt";
            this.zDtDataGridViewTextBoxColumn.Name = "zDtDataGridViewTextBoxColumn";
            this.zDtDataGridViewTextBoxColumn.ReadOnly = true;
            this.zDtDataGridViewTextBoxColumn.Width = 80;
            // 
            // Form_LinkedDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 281);
            this.CloseOnEscape = true;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_LinkedDocs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Saistītie dokumenti";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_LinkedDocs_FormClosing);
            this.Load += new System.EventHandler(this.Form_LinkedDocs_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form_LinkedDocs_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOPS)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOPSd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOPS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingSource2 bsOPS;
        private MyBindingSource bsDocs;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbSumm;
        private System.Windows.Forms.ToolStripTextBox tbPVN;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton cmOK;
        private System.Windows.Forms.ToolStripButton cmCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MyDataGridView dgvOPSd;
        private MyDataGridView dgvOPS;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem cikGadusAtpakaļSkatītiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tbSetYears;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSAC11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSAC12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSAC13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSAC14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSAC15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSAC21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSAC22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSAC23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSAC24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSAC25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSSummC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSCur;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSSumm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOPSDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aC11DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aC12DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aC13DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aC14DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aC15DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aC21DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aC22DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aC23DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aC24DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aC25DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsDocTyp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsDocSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsDocNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsSumm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsPVN;
    }
}