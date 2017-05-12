namespace KlonsP.Forms
{
    partial class Form_RepMT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.bsRows = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.dgcYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcValue0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDeprec0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDeprecCalc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcValueC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDeprecC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSellValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcMtTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcMtUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRateD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRateDMt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTaxValLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTaxValC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTaxDeprecCalc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTaxVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTaxDeprec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTaxRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 43);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1001, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
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
            this.dgcYear,
            this.dgcMonth,
            this.dgcValue0,
            this.dgcDeprec0,
            this.dgcDeprecCalc,
            this.dgcValueC,
            this.dgcDeprecC,
            this.dgcSellValue,
            this.dgcMtTotal,
            this.dgcMtUsed,
            this.dgcRateD,
            this.dgcRateDMt,
            this.dgcTaxValLeft,
            this.dgcTaxValC,
            this.dgcTaxDeprecCalc,
            this.dgcTaxVal,
            this.dgcTaxDeprec,
            this.dgcTaxRate});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 43);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowTemplate.Height = 24;
            this.dgvRows.ShowCellErrors = false;
            this.dgvRows.ShowEditingIcon = false;
            this.dgvRows.ShowRowErrors = false;
            this.dgvRows.Size = new System.Drawing.Size(1001, 318);
            this.dgvRows.TabIndex = 1;
            // 
            // dgcYear
            // 
            this.dgcYear.DataPropertyName = "Year";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcYear.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcYear.Frozen = true;
            this.dgcYear.HeaderText = "Gads";
            this.dgcYear.Name = "dgcYear";
            this.dgcYear.ReadOnly = true;
            this.dgcYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcYear.Width = 40;
            // 
            // dgcMonth
            // 
            this.dgcMonth.DataPropertyName = "Month";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcMonth.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcMonth.Frozen = true;
            this.dgcMonth.HeaderText = "Mēn.";
            this.dgcMonth.Name = "dgcMonth";
            this.dgcMonth.ReadOnly = true;
            this.dgcMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcMonth.ToolTipText = "Mēnesis";
            this.dgcMonth.Width = 40;
            // 
            // dgcValue0
            // 
            this.dgcValue0.DataPropertyName = "Value0";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.dgcValue0.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcValue0.HeaderText = "Ieg.v.";
            this.dgcValue0.Name = "dgcValue0";
            this.dgcValue0.ReadOnly = true;
            this.dgcValue0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcValue0.ToolTipText = "Iegādes vērtība uz mēneša sākumu";
            this.dgcValue0.Width = 80;
            // 
            // dgcDeprec0
            // 
            this.dgcDeprec0.DataPropertyName = "Deprec0";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dgcDeprec0.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcDeprec0.HeaderText = "Uzrkr. noliet.";
            this.dgcDeprec0.Name = "dgcDeprec0";
            this.dgcDeprec0.ReadOnly = true;
            this.dgcDeprec0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDeprec0.ToolTipText = "Uzkrātais nolietojums";
            this.dgcDeprec0.Width = 80;
            // 
            // dgcDeprecCalc
            // 
            this.dgcDeprecCalc.DataPropertyName = "DeprecCalc";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.dgcDeprecCalc.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcDeprecCalc.HeaderText = "Apr.nol.";
            this.dgcDeprecCalc.Name = "dgcDeprecCalc";
            this.dgcDeprecCalc.ReadOnly = true;
            this.dgcDeprecCalc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDeprecCalc.Width = 80;
            // 
            // dgcValueC
            // 
            this.dgcValueC.DataPropertyName = "ValueC";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcValueC.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcValueC.HeaderText = "ieg.v. +/-";
            this.dgcValueC.Name = "dgcValueC";
            this.dgcValueC.ReadOnly = true;
            this.dgcValueC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcValueC.Width = 80;
            // 
            // dgcDeprecC
            // 
            this.dgcDeprecC.DataPropertyName = "DeprecC";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcDeprecC.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcDeprecC.HeaderText = "Uzkr.nol. +/-";
            this.dgcDeprecC.Name = "dgcDeprecC";
            this.dgcDeprecC.ReadOnly = true;
            this.dgcDeprecC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDeprecC.Width = 80;
            // 
            // dgcSellValue
            // 
            this.dgcSellValue.DataPropertyName = "SellValue";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcSellValue.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcSellValue.HeaderText = "Pārd.v.";
            this.dgcSellValue.Name = "dgcSellValue";
            this.dgcSellValue.ReadOnly = true;
            this.dgcSellValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSellValue.ToolTipText = "Pārdošanas vērtība";
            this.dgcSellValue.Width = 80;
            // 
            // dgcMtTotal
            // 
            this.dgcMtTotal.DataPropertyName = "MtTotal";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcMtTotal.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgcMtTotal.HeaderText = "Mēn.";
            this.dgcMtTotal.Name = "dgcMtTotal";
            this.dgcMtTotal.ReadOnly = true;
            this.dgcMtTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcMtTotal.ToolTipText = "Nolietojuma periods mēnešos";
            this.dgcMtTotal.Width = 40;
            // 
            // dgcMtUsed
            // 
            this.dgcMtUsed.DataPropertyName = "MtUsed";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcMtUsed.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgcMtUsed.HeaderText = "Mēn. izm.";
            this.dgcMtUsed.Name = "dgcMtUsed";
            this.dgcMtUsed.ReadOnly = true;
            this.dgcMtUsed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcMtUsed.ToolTipText = "Izmantotais nolietojuma periods mēnešos";
            this.dgcMtUsed.Width = 40;
            // 
            // dgcRateD
            // 
            this.dgcRateD.DataPropertyName = "RateD";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcRateD.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgcRateD.HeaderText = "Nol. likme";
            this.dgcRateD.Name = "dgcRateD";
            this.dgcRateD.ReadOnly = true;
            this.dgcRateD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcRateD.ToolTipText = "Nolietojuma likme";
            this.dgcRateD.Width = 40;
            // 
            // dgcRateDMt
            // 
            this.dgcRateDMt.DataPropertyName = "RateDMt";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            this.dgcRateDMt.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgcRateDMt.HeaderText = "Nol.likme mēnesī";
            this.dgcRateDMt.Name = "dgcRateDMt";
            this.dgcRateDMt.ReadOnly = true;
            this.dgcRateDMt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcRateDMt.ToolTipText = "Nolietojama likme mēnesī";
            this.dgcRateDMt.Width = 80;
            // 
            // dgcTaxValLeft
            // 
            this.dgcTaxValLeft.DataPropertyName = "TaxValLeft0";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            this.dgcTaxValLeft.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgcTaxValLeft.HeaderText = "Nod.nol. atl.v.";
            this.dgcTaxValLeft.Name = "dgcTaxValLeft";
            this.dgcTaxValLeft.ReadOnly = true;
            this.dgcTaxValLeft.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcTaxValLeft.ToolTipText = "Atlikusī nolietojuma vērtība nodokļa vajadzībām";
            this.dgcTaxValLeft.Width = 80;
            // 
            // dgcTaxValC
            // 
            this.dgcTaxValC.DataPropertyName = "TaxValC";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcTaxValC.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgcTaxValC.HeaderText = "Nod.nol. +/-";
            this.dgcTaxValC.Name = "dgcTaxValC";
            this.dgcTaxValC.ReadOnly = true;
            this.dgcTaxValC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcTaxValC.ToolTipText = "Nolietojuma vērtības izmaiņas nodokļa vajadzībām";
            this.dgcTaxValC.Width = 80;
            // 
            // dgcTaxDeprecCalc
            // 
            this.dgcTaxDeprecCalc.DataPropertyName = "TaxDeprecCalc";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcTaxDeprecCalc.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgcTaxDeprecCalc.HeaderText = "Nod.nol. apr.";
            this.dgcTaxDeprecCalc.Name = "dgcTaxDeprecCalc";
            this.dgcTaxDeprecCalc.ReadOnly = true;
            this.dgcTaxDeprecCalc.ToolTipText = "Aprēķinātais nolietojums nodokļu vajadzībām";
            this.dgcTaxDeprecCalc.Width = 80;
            // 
            // dgcTaxVal
            // 
            this.dgcTaxVal.DataPropertyName = "TaxVal";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N2";
            this.dgcTaxVal.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgcTaxVal.HeaderText = "Nod.nol. v.";
            this.dgcTaxVal.Name = "dgcTaxVal";
            this.dgcTaxVal.ReadOnly = true;
            this.dgcTaxVal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcTaxVal.ToolTipText = "Nolietojuma vērtība nodokļa vajadzībām";
            this.dgcTaxVal.Width = 80;
            // 
            // dgcTaxDeprec
            // 
            this.dgcTaxDeprec.DataPropertyName = "TaxDeprec";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N2";
            this.dgcTaxDeprec.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgcTaxDeprec.HeaderText = "Nod.nol. uzkr.";
            this.dgcTaxDeprec.Name = "dgcTaxDeprec";
            this.dgcTaxDeprec.ReadOnly = true;
            this.dgcTaxDeprec.ToolTipText = "Norakstītais nolietojums nodokļu vajadzībām";
            // 
            // dgcTaxRate
            // 
            this.dgcTaxRate.DataPropertyName = "TaxRate";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcTaxRate.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgcTaxRate.HeaderText = "Nod.nol. likme";
            this.dgcTaxRate.Name = "dgcTaxRate";
            this.dgcTaxRate.ReadOnly = true;
            this.dgcTaxRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcTaxRate.ToolTipText = "Nolietojuma likme nodokļu vajadzībām";
            this.dgcTaxRate.Width = 60;
            // 
            // Form_RepMT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 361);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.panel1);
            this.Name = "Form_RepMT";
            this.Text = "Aprēķina izklāsts pa mēnešiem";
            this.Load += new System.EventHandler(this.Form_RepMT_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private KlonsLIB.Data.MyBindingSource2 bsRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcValue0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDeprec0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDeprecCalc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcValueC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDeprecC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSellValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcMtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcMtUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRateD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRateDMt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTaxValLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTaxValC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTaxDeprecCalc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTaxVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTaxDeprec;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTaxRate;
    }
}