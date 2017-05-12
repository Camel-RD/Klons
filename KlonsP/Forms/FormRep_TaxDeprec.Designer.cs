namespace KlonsP.Forms
{
    partial class FormRep_TaxDeprec
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmReport = new System.Windows.Forms.Button();
            this.cmGetData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbYear = new KlonsLIB.Components.FlatComboBox();
            this.bsRows = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcCatT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTaxValLeft0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTaxValChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTaxDeprecCalc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTaxValLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmReport);
            this.panel1.Controls.Add(this.cmGetData);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbYear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 36);
            this.panel1.TabIndex = 0;
            // 
            // cmReport
            // 
            this.cmReport.Location = new System.Drawing.Point(306, 3);
            this.cmReport.Name = "cmReport";
            this.cmReport.Size = new System.Drawing.Size(86, 29);
            this.cmReport.TabIndex = 9;
            this.cmReport.Text = "Atskaite";
            this.cmReport.UseVisualStyleBackColor = true;
            this.cmReport.Click += new System.EventHandler(this.cmReport_Click);
            // 
            // cmGetData
            // 
            this.cmGetData.Location = new System.Drawing.Point(214, 3);
            this.cmGetData.Name = "cmGetData";
            this.cmGetData.Size = new System.Drawing.Size(86, 29);
            this.cmGetData.TabIndex = 2;
            this.cmGetData.Text = "Atlasīt";
            this.cmGetData.UseVisualStyleBackColor = true;
            this.cmGetData.Click += new System.EventHandler(this.cmGetData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pārksata gads:";
            // 
            // cbYear
            // 
            this.cbYear.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cbYear.Location = new System.Drawing.Point(108, 6);
            this.cbYear.MaxDropDownItems = 15;
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(75, 24);
            this.cbYear.TabIndex = 0;
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.AutoSave = false;
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
            this.dgcCatT,
            this.dgcName,
            this.dgcTaxValLeft0,
            this.dgcTaxValChange,
            this.dgcTaxDeprecCalc,
            this.dgcTaxValLeft});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 36);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowTemplate.Height = 24;
            this.dgvRows.Size = new System.Drawing.Size(803, 319);
            this.dgvRows.TabIndex = 1;
            // 
            // dgcCatT
            // 
            this.dgcCatT.DataPropertyName = "SCatT";
            this.dgcCatT.HeaderText = "Kat.";
            this.dgcCatT.Name = "dgcCatT";
            this.dgcCatT.ReadOnly = true;
            this.dgcCatT.ToolTipText = "Nolietojumu kategorija";
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "Name";
            this.dgcName.HeaderText = "Nosaukums";
            this.dgcName.Name = "dgcName";
            this.dgcName.ReadOnly = true;
            this.dgcName.Width = 200;
            // 
            // dgcTaxValLeft0
            // 
            this.dgcTaxValLeft0.DataPropertyName = "TaxValLeft0";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dgcTaxValLeft0.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcTaxValLeft0.HeaderText = "Atl.v. sākumā";
            this.dgcTaxValLeft0.Name = "dgcTaxValLeft0";
            this.dgcTaxValLeft0.ReadOnly = true;
            this.dgcTaxValLeft0.ToolTipText = "Atlikusī vērtība perioda sākumā";
            this.dgcTaxValLeft0.Width = 80;
            // 
            // dgcTaxValChange
            // 
            this.dgcTaxValChange.DataPropertyName = "TaxValChange";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcTaxValChange.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcTaxValChange.HeaderText = "Izmaiņas +/-";
            this.dgcTaxValChange.Name = "dgcTaxValChange";
            this.dgcTaxValChange.ReadOnly = true;
            this.dgcTaxValChange.Width = 80;
            // 
            // dgcTaxDeprecCalc
            // 
            this.dgcTaxDeprecCalc.DataPropertyName = "TaxDeprecCalc";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.dgcTaxDeprecCalc.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcTaxDeprecCalc.HeaderText = "Apr. nol.";
            this.dgcTaxDeprecCalc.Name = "dgcTaxDeprecCalc";
            this.dgcTaxDeprecCalc.ReadOnly = true;
            this.dgcTaxDeprecCalc.ToolTipText = "Aprēķinātais nolietojums nodokļu vajadzībām";
            this.dgcTaxDeprecCalc.Width = 80;
            // 
            // dgcTaxValLeft
            // 
            this.dgcTaxValLeft.DataPropertyName = "TaxValLeft1";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dgcTaxValLeft.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcTaxValLeft.HeaderText = "Atl.v. beigās";
            this.dgcTaxValLeft.Name = "dgcTaxValLeft";
            this.dgcTaxValLeft.ReadOnly = true;
            this.dgcTaxValLeft.ToolTipText = "Atlikusī vērtība perioda beigās";
            this.dgcTaxValLeft.Width = 80;
            // 
            // FormRep_TaxDeprec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 355);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.panel1);
            this.Name = "FormRep_TaxDeprec";
            this.Text = "Nolietojums nodokļa vajadzībām";
            this.Load += new System.EventHandler(this.FormRep_TaxDeprec_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Data.MyBindingSource2 bsRows;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.Button cmGetData;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.FlatComboBox cbYear;
        private System.Windows.Forms.Button cmReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCatT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTaxValLeft0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTaxValChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTaxDeprecCalc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTaxValLeft;
    }
}