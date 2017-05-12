namespace KlonsP.Forms
{
    partial class Form_TaxDeprecYR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TaxDeprecYR));
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
            this.bsRows = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.cbYear = new KlonsLIB.Components.MyMcFlatComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbFirst = new System.Windows.Forms.ToolStripButton();
            this.tsbPrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbRecalc = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbReport = new System.Windows.Forms.ToolStripButton();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.dgcYR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCatTCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XCATT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcKind = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgcCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcValue0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcValueNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcValueAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcValueRem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcValueExcl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcValueD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDeprec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcValue1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bsRows
            // 
            this.bsRows.DataMember = "TAXDEPRECYEAR";
            this.bsRows.MyDataSource = "KlonsData";
            this.bsRows.Sort = "YR,XCATT_CODE";
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcYR,
            this.dgcCatTCode,
            this.XCATT_NAME,
            this.dgcRate,
            this.dgcKind,
            this.dgcCount,
            this.dgcValue0,
            this.dgcValueNew,
            this.dgcValueAdd,
            this.dgcValueRem,
            this.dgcValueExcl,
            this.Column1,
            this.dgcValueD,
            this.dgcDeprec,
            this.dgcValue1,
            this.dgcID});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 0);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowTemplate.Height = 24;
            this.dgvRows.Size = new System.Drawing.Size(926, 335);
            this.dgvRows.TabIndex = 1;
            // 
            // cbYear
            // 
            this.cbYear.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbYear.ColumnNames = new string[0];
            this.cbYear.ColumnWidths = "41";
            this.cbYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbYear.DropDownHeight = 204;
            this.cbYear.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbYear.DropDownWidth = 65;
            this.cbYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.GridLineColor = System.Drawing.Color.LightGray;
            this.cbYear.GridLineHorizontal = false;
            this.cbYear.GridLineVertical = false;
            this.cbYear.IntegralHeight = false;
            this.cbYear.Location = new System.Drawing.Point(695, 328);
            this.cbYear.MaxDropDownItems = 12;
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(65, 23);
            this.cbYear.TabIndex = 2;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFirst,
            this.tsbPrev,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.tsbNext,
            this.tsbLast,
            this.toolStripSeparator3,
            this.tsbNew,
            this.tsbDelete,
            this.tsbRecalc,
            this.tsbSave,
            this.tsbReport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 335);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(926, 32);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbFirst
            // 
            this.tsbFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFirst.Image = ((System.Drawing.Image)(resources.GetObject("tsbFirst.Image")));
            this.tsbFirst.Name = "tsbFirst";
            this.tsbFirst.RightToLeftAutoMirrorImage = true;
            this.tsbFirst.Size = new System.Drawing.Size(25, 29);
            this.tsbFirst.Text = "Iet uz pirmo";
            this.tsbFirst.Click += new System.EventHandler(this.tsbFirst_Click);
            // 
            // tsbPrev
            // 
            this.tsbPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrev.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrev.Image")));
            this.tsbPrev.Name = "tsbPrev";
            this.tsbPrev.RightToLeftAutoMirrorImage = true;
            this.tsbPrev.Size = new System.Drawing.Size(25, 29);
            this.tsbPrev.Text = "Iet uz iepriekšējo";
            this.tsbPrev.Click += new System.EventHandler(this.tsbPrev_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbNext
            // 
            this.tsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.RightToLeftAutoMirrorImage = true;
            this.tsbNext.Size = new System.Drawing.Size(25, 29);
            this.tsbNext.Text = "Iet uz nākošo";
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // tsbLast
            // 
            this.tsbLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLast.Image = ((System.Drawing.Image)(resources.GetObject("tsbLast.Image")));
            this.tsbLast.Name = "tsbLast";
            this.tsbLast.RightToLeftAutoMirrorImage = true;
            this.tsbLast.Size = new System.Drawing.Size(25, 29);
            this.tsbLast.Text = "Iet uz pēdējo";
            this.tsbLast.Click += new System.EventHandler(this.tsbLast_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.RightToLeftAutoMirrorImage = true;
            this.tsbNew.Size = new System.Drawing.Size(166, 29);
            this.tsbNew.Text = "Pievienot gadu";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.RightToLeftAutoMirrorImage = true;
            this.tsbDelete.Size = new System.Drawing.Size(136, 29);
            this.tsbDelete.Text = "Dzēst gadu";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbRecalc
            // 
            this.tsbRecalc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRecalc.Image = ((System.Drawing.Image)(resources.GetObject("tsbRecalc.Image")));
            this.tsbRecalc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRecalc.Name = "tsbRecalc";
            this.tsbRecalc.Size = new System.Drawing.Size(104, 29);
            this.tsbRecalc.Text = "Pārrēķināt";
            this.tsbRecalc.Click += new System.EventHandler(this.tsbRecalc_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(25, 29);
            this.tsbSave.Text = "Saglabāt";
            // 
            // tsbReport
            // 
            this.tsbReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbReport.Image = ((System.Drawing.Image)(resources.GetObject("tsbReport.Image")));
            this.tsbReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReport.Name = "tsbReport";
            this.tsbReport.Size = new System.Drawing.Size(84, 29);
            this.tsbReport.Text = "Izdrukai";
            this.tsbReport.Click += new System.EventHandler(this.tsbReport_Click);
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "CATT",
        "TAXDEPRECYEAR",
        null};
            // 
            // dgcYR
            // 
            this.dgcYR.DataPropertyName = "YR";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcYR.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcYR.HeaderText = "gads";
            this.dgcYR.Name = "dgcYR";
            this.dgcYR.ReadOnly = true;
            this.dgcYR.Width = 50;
            // 
            // dgcCatTCode
            // 
            this.dgcCatTCode.DataPropertyName = "XCATT_CODE";
            this.dgcCatTCode.HeaderText = "kat.kods";
            this.dgcCatTCode.Name = "dgcCatTCode";
            this.dgcCatTCode.ReadOnly = true;
            this.dgcCatTCode.ToolTipText = "Kategorijas kods";
            // 
            // XCATT_NAME
            // 
            this.XCATT_NAME.DataPropertyName = "XCATT_NAME";
            this.XCATT_NAME.HeaderText = "kat.nosaukums";
            this.XCATT_NAME.Name = "XCATT_NAME";
            this.XCATT_NAME.ReadOnly = true;
            this.XCATT_NAME.ToolTipText = "Kategorijas nosaukums";
            this.XCATT_NAME.Width = 200;
            // 
            // dgcRate
            // 
            this.dgcRate.DataPropertyName = "RATE";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcRate.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcRate.HeaderText = "likme";
            this.dgcRate.Name = "dgcRate";
            this.dgcRate.ReadOnly = true;
            this.dgcRate.ToolTipText = "Nolietojuma likme";
            this.dgcRate.Width = 50;
            // 
            // dgcKind
            // 
            this.dgcKind.DataPropertyName = "KIND";
            this.dgcKind.FalseValue = "0";
            this.dgcKind.HeaderText = "katram";
            this.dgcKind.Name = "dgcKind";
            this.dgcKind.ReadOnly = true;
            this.dgcKind.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcKind.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcKind.ToolTipText = "Nolietojumu rēķina katram pamatlīdzeklim atsevišķi";
            this.dgcKind.TrueValue = "1";
            this.dgcKind.Width = 50;
            // 
            // dgcCount
            // 
            this.dgcCount.DataPropertyName = "COUNT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcCount.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcCount.HeaderText = "skaits";
            this.dgcCount.Name = "dgcCount";
            this.dgcCount.ReadOnly = true;
            this.dgcCount.Width = 50;
            // 
            // dgcValue0
            // 
            this.dgcValue0.DataPropertyName = "VALUE0";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dgcValue0.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcValue0.HeaderText = "sākuma atlikums";
            this.dgcValue0.Name = "dgcValue0";
            this.dgcValue0.ReadOnly = true;
            this.dgcValue0.ToolTipText = "Kategorijas atlikums uz gada sākumu";
            // 
            // dgcValueNew
            // 
            this.dgcValueNew.DataPropertyName = "VALUE_NEW";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcValueNew.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcValueNew.HeaderText = "sāk.vērt.";
            this.dgcValueNew.Name = "dgcValueNew";
            this.dgcValueNew.ReadOnly = true;
            this.dgcValueNew.ToolTipText = "Kategorijas sākotnējā vērtība";
            // 
            // dgcValueAdd
            // 
            this.dgcValueAdd.DataPropertyName = "VALUE_ADD";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcValueAdd.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcValueAdd.HeaderText = "palielin.";
            this.dgcValueAdd.Name = "dgcValueAdd";
            this.dgcValueAdd.ReadOnly = true;
            this.dgcValueAdd.ToolTipText = "Vērtības palielinājums";
            // 
            // dgcValueRem
            // 
            this.dgcValueRem.DataPropertyName = "VALUE_REM";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcValueRem.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcValueRem.HeaderText = "samazin.";
            this.dgcValueRem.Name = "dgcValueRem";
            this.dgcValueRem.ReadOnly = true;
            this.dgcValueRem.ToolTipText = "Vērtības samazinājums";
            // 
            // dgcValueExcl
            // 
            this.dgcValueExcl.DataPropertyName = "VALUE_EXCL";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcValueExcl.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcValueExcl.HeaderText = "izslēgts";
            this.dgcValueExcl.Name = "dgcValueExcl";
            this.dgcValueExcl.ReadOnly = true;
            this.dgcValueExcl.ToolTipText = "Izslēgtā vērtība";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "VALUE_COR";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column1.HeaderText = "koriģ. vērtība";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.ToolTipText = "Koriģētā vērtība";
            // 
            // dgcValueD
            // 
            this.dgcValueD.DataPropertyName = "VALUED";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.dgcValueD.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgcValueD.HeaderText = "noliet. bāze";
            this.dgcValueD.Name = "dgcValueD";
            this.dgcValueD.ReadOnly = true;
            this.dgcValueD.ToolTipText = "Vērtība, no kuras aprēķina taksācijas perioda nolietojumu";
            // 
            // dgcDeprec
            // 
            this.dgcDeprec.DataPropertyName = "DEPREC";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            this.dgcDeprec.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgcDeprec.HeaderText = "nolietojums";
            this.dgcDeprec.Name = "dgcDeprec";
            this.dgcDeprec.ReadOnly = true;
            this.dgcDeprec.ToolTipText = "Taksācijas pereioda nolietojums";
            // 
            // dgcValue1
            // 
            this.dgcValue1.DataPropertyName = "VALUE1";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            this.dgcValue1.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgcValue1.HeaderText = "beigu atlikums";
            this.dgcValue1.Name = "dgcValue1";
            this.dgcValue1.ReadOnly = true;
            this.dgcValue1.ToolTipText = "Atlikusī bategorijas vērtība";
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.Name = "dgcID";
            this.dgcID.ReadOnly = true;
            this.dgcID.Visible = false;
            this.dgcID.Width = 50;
            // 
            // Form_TaxDeprecYR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 367);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_TaxDeprecYR";
            this.Text = "Nolietojums nodokļa vajadzībām";
            this.Load += new System.EventHandler(this.Form_TaxDeprecYR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsRows;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcValueA;
        private KlonsLIB.Components.MyMcFlatComboBox cbYear;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbFirst;
        private System.Windows.Forms.ToolStripButton tsbPrev;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbRecalc;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private System.Windows.Forms.ToolStripButton tsbReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcYR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCatTCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn XCATT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgcKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcValue0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcValueNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcValueAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcValueRem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcValueExcl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcValueD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDeprec;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcValue1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
    }
}