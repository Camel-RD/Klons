namespace KlonsA.Forms
{
    partial class Form_PayCalc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbColList = new KlonsLIB.Components.MyMcFlatComboBox();
            this.lbPos = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDates2 = new System.Windows.Forms.Label();
            this.lbDates1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bsRows = new System.Windows.Forms.BindingSource(this.components);
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPayTaxed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNoSai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNoTaxed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNotpaidTaxed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNotpidNoSAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNotpaidNotTaxed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDNS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUntMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDepend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcEx2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPFLIHINT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPayReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCashNotPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbColList);
            this.panel1.Controls.Add(this.lbPos);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.lbDates2);
            this.panel1.Controls.Add(this.lbDates1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 81);
            this.panel1.TabIndex = 0;
            // 
            // cbColList
            // 
            this.cbColList.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbColList.ColumnNames = new string[0];
            this.cbColList.ColumnWidths = "121";
            this.cbColList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColList.DropDownHeight = 136;
            this.cbColList.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbColList.DropDownWidth = 145;
            this.cbColList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbColList.FormattingEnabled = true;
            this.cbColList.GridLineColor = System.Drawing.Color.LightGray;
            this.cbColList.GridLineHorizontal = false;
            this.cbColList.GridLineVertical = false;
            this.cbColList.IntegralHeight = false;
            this.cbColList.Items.AddRange(new object[] {
            "Izvērsta tabula",
            "Saīsināta tabula"});
            this.cbColList.Location = new System.Drawing.Point(458, 6);
            this.cbColList.Name = "cbColList";
            this.cbColList.Size = new System.Drawing.Size(141, 23);
            this.cbColList.TabIndex = 3;
            this.cbColList.SelectedIndexChanged += new System.EventHandler(this.cbColList_SelectedIndexChanged);
            // 
            // lbPos
            // 
            this.lbPos.AutoSize = true;
            this.lbPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbPos.Location = new System.Drawing.Point(106, 23);
            this.lbPos.Name = "lbPos";
            this.lbPos.Size = new System.Drawing.Size(51, 16);
            this.lbPos.TabIndex = 2;
            this.lbPos.Text = "label3";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbName.Location = new System.Drawing.Point(106, 7);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(51, 16);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "label3";
            // 
            // lbDates2
            // 
            this.lbDates2.AutoSize = true;
            this.lbDates2.Location = new System.Drawing.Point(12, 57);
            this.lbDates2.Name = "lbDates2";
            this.lbDates2.Size = new System.Drawing.Size(277, 16);
            this.lbDates2.TabIndex = 1;
            this.lbDates2.Text = "Otrā daļēji apmaksātā algu aprēķina datumi:  ";
            // 
            // lbDates1
            // 
            this.lbDates1.AutoSize = true;
            this.lbDates1.Location = new System.Drawing.Point(12, 41);
            this.lbDates1.Name = "lbDates1";
            this.lbDates1.Size = new System.Drawing.Size(287, 16);
            this.lbDates1.TabIndex = 1;
            this.lbDates1.Text = "Pirmā daļēji apmaksātā algu aprēķina datumi:  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amats:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Darbinieks:";
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
            this.dgcCaption,
            this.dgcPayTaxed,
            this.dgcNoSai,
            this.dgcNoTaxed,
            this.dgcNotpaidTaxed,
            this.dgcNotpidNoSAI,
            this.dgcNotpaidNotTaxed,
            this.dgcDNS,
            this.dgcUntMin,
            this.dgcDepend,
            this.dgcEx2,
            this.dgcPFLIHINT,
            this.dgcIIN,
            this.dgcPay,
            this.dgcPayReq,
            this.dgcCashNotPaid});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 81);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowTemplate.Height = 24;
            this.dgvRows.Size = new System.Drawing.Size(919, 353);
            this.dgvRows.TabIndex = 1;
            // 
            // dgcCaption
            // 
            this.dgcCaption.DataPropertyName = "Caption";
            this.dgcCaption.Frozen = true;
            this.dgcCaption.HeaderText = "apraksts";
            this.dgcCaption.Name = "dgcCaption";
            this.dgcCaption.ReadOnly = true;
            this.dgcCaption.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcCaption.Width = 180;
            // 
            // dgcPayTaxed
            // 
            this.dgcPayTaxed.DataPropertyName = "PAY_TAXED";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "0.00;-0.00;\"\"";
            this.dgcPayTaxed.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcPayTaxed.HeaderText = "apliek";
            this.dgcPayTaxed.Name = "dgcPayTaxed";
            this.dgcPayTaxed.ReadOnly = true;
            this.dgcPayTaxed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcPayTaxed.ToolTipText = "apliekamie ienākumi";
            this.dgcPayTaxed.Width = 80;
            // 
            // dgcNoSai
            // 
            this.dgcNoSai.DataPropertyName = "PAY_NOSAI";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "0.00;-0.00;\"\"";
            this.dgcNoSai.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcNoSai.HeaderText = "neapl. ar SAI";
            this.dgcNoSai.Name = "dgcNoSai";
            this.dgcNoSai.ReadOnly = true;
            this.dgcNoSai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcNoSai.ToolTipText = "ar SAI neapliekaie ienākumi";
            this.dgcNoSai.Width = 80;
            // 
            // dgcNoTaxed
            // 
            this.dgcNoTaxed.DataPropertyName = "PAY_NOTTAXED";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "0.00;-0.00;\"\"";
            this.dgcNoTaxed.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcNoTaxed.HeaderText = "neapliek";
            this.dgcNoTaxed.Name = "dgcNoTaxed";
            this.dgcNoTaxed.ReadOnly = true;
            this.dgcNoTaxed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcNoTaxed.ToolTipText = "neapliekamie ienākumi";
            this.dgcNoTaxed.Width = 80;
            // 
            // dgcNotpaidTaxed
            // 
            this.dgcNotpaidTaxed.DataPropertyName = "NOTPAID_TAXED";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "0.00;-0.00;\"\"";
            this.dgcNotpaidTaxed.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcNotpaidTaxed.HeaderText = "neizm. apliek";
            this.dgcNotpaidTaxed.Name = "dgcNotpaidTaxed";
            this.dgcNotpaidTaxed.ReadOnly = true;
            this.dgcNotpaidTaxed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcNotpaidTaxed.ToolTipText = "neizmaksājami apliekamie ienākumi";
            this.dgcNotpaidTaxed.Width = 80;
            // 
            // dgcNotpidNoSAI
            // 
            this.dgcNotpidNoSAI.DataPropertyName = "NOTPAID_NOSAI";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "0.00;-0.00;\"\"";
            this.dgcNotpidNoSAI.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcNotpidNoSAI.HeaderText = "neizm. nav SAI";
            this.dgcNotpidNoSAI.Name = "dgcNotpidNoSAI";
            this.dgcNotpidNoSAI.ReadOnly = true;
            this.dgcNotpidNoSAI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcNotpidNoSAI.ToolTipText = "neizmaksājami ar SAI neapliekaie ienākumi";
            this.dgcNotpidNoSAI.Width = 80;
            // 
            // dgcNotpaidNotTaxed
            // 
            this.dgcNotpaidNotTaxed.DataPropertyName = "NOTPAID_NOTTAXED";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "0.00;-0.00;\"\"";
            this.dgcNotpaidNotTaxed.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcNotpaidNotTaxed.HeaderText = "neizm. neapliek.";
            this.dgcNotpaidNotTaxed.Name = "dgcNotpaidNotTaxed";
            this.dgcNotpaidNotTaxed.ReadOnly = true;
            this.dgcNotpaidNotTaxed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcNotpaidNotTaxed.ToolTipText = "neizmaksājami neapliekamie ienākumi";
            this.dgcNotpaidNotTaxed.Width = 80;
            // 
            // dgcDNS
            // 
            this.dgcDNS.DataPropertyName = "DNSI";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "0.00;-0.00;\"\"";
            this.dgcDNS.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcDNS.HeaderText = "d.ņ. SI";
            this.dgcDNS.Name = "dgcDNS";
            this.dgcDNS.ReadOnly = true;
            this.dgcDNS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDNS.ToolTipText = "darba ņēmēja SAI";
            this.dgcDNS.Width = 80;
            // 
            // dgcUntMin
            // 
            this.dgcUntMin.DataPropertyName = "UNTAXED_MINIMUM";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "0.00;-0.00;\"\"";
            this.dgcUntMin.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcUntMin.HeaderText = "neapliek. min.";
            this.dgcUntMin.Name = "dgcUntMin";
            this.dgcUntMin.ReadOnly = true;
            this.dgcUntMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcUntMin.ToolTipText = "neapliekamais ienākums";
            this.dgcUntMin.Width = 80;
            // 
            // dgcDepend
            // 
            this.dgcDepend.DataPropertyName = "IINEX_DEPENDANTS";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "0.00;-0.00;\"\"";
            this.dgcDepend.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgcDepend.HeaderText = "par apgād.";
            this.dgcDepend.Name = "dgcDepend";
            this.dgcDepend.ReadOnly = true;
            this.dgcDepend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDepend.ToolTipText = "par apgādājamajiem";
            this.dgcDepend.Width = 80;
            // 
            // dgcEx2
            // 
            this.dgcEx2.DataPropertyName = "IINEX2";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "0.00;-0.00;\"\"";
            this.dgcEx2.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgcEx2.HeaderText = "pap. atv.";
            this.dgcEx2.Name = "dgcEx2";
            this.dgcEx2.ReadOnly = true;
            this.dgcEx2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcEx2.ToolTipText = "papildus atvieglojumi";
            this.dgcEx2.Width = 80;
            // 
            // dgcPFLIHINT
            // 
            this.dgcPFLIHINT.DataPropertyName = "PFLIHINT";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "0.00;-0.00;\"\"";
            this.dgcPFLIHINT.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgcPFLIHINT.HeaderText = "pens. fondi, ...";
            this.dgcPFLIHINT.Name = "dgcPFLIHINT";
            this.dgcPFLIHINT.ReadOnly = true;
            this.dgcPFLIHINT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcPFLIHINT.ToolTipText = "neapliekamās iemakas pensiju fondos, dzīvības un veselības apdrošināšana";
            this.dgcPFLIHINT.Width = 80;
            // 
            // dgcIIN
            // 
            this.dgcIIN.DataPropertyName = "IIN";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "0.00;-0.00;\"\"";
            this.dgcIIN.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgcIIN.HeaderText = "IIN";
            this.dgcIIN.Name = "dgcIIN";
            this.dgcIIN.ReadOnly = true;
            this.dgcIIN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcIIN.Width = 80;
            // 
            // dgcPay
            // 
            this.dgcPay.DataPropertyName = "CASH";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "0.00;-0.00;\"\"";
            this.dgcPay.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgcPay.HeaderText = "izmaksa";
            this.dgcPay.Name = "dgcPay";
            this.dgcPay.ReadOnly = true;
            this.dgcPay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcPay.Width = 80;
            // 
            // dgcPayReq
            // 
            this.dgcPayReq.DataPropertyName = "CASH_REQ";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "0.00;-0.00;\"\"";
            this.dgcPayReq.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgcPayReq.HeaderText = "pl. izm.";
            this.dgcPayReq.Name = "dgcPayReq";
            this.dgcPayReq.ReadOnly = true;
            this.dgcPayReq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcPayReq.ToolTipText = "aprēķina izmaksas mērķis";
            this.dgcPayReq.Width = 80;
            // 
            // dgcCashNotPaid
            // 
            this.dgcCashNotPaid.DataPropertyName = "CASH_NOTPAID";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "0.00;-0.00;\"\"";
            this.dgcCashNotPaid.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgcCashNotPaid.HeaderText = "neizmaks.";
            this.dgcCashNotPaid.Name = "dgcCashNotPaid";
            this.dgcCashNotPaid.ReadOnly = true;
            this.dgcCashNotPaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcCashNotPaid.Width = 80;
            // 
            // Form_PayCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 434);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.panel1);
            this.Name = "Form_PayCalc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Daļēji izmaksātie algas aprēķini";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_PayCalc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bsRows;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.Label lbPos;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDates2;
        private System.Windows.Forms.Label lbDates1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyMcFlatComboBox cbColList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPayTaxed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNoSai;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNoTaxed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNotpaidTaxed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNotpidNoSAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNotpaidNotTaxed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDNS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUntMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDepend;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcEx2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPFLIHINT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPayReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCashNotPaid;
    }
}