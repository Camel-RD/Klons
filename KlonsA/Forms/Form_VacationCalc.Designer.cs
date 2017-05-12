namespace KlonsA.Forms
{
    partial class Form_VacationCalc
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
            this.dgvSar = new KlonsLIB.Components.MyDataGridView();
            this.dgcCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDNS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIINEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbRateCalDay = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmReport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbRateDay = new KlonsLIB.Components.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRateHour = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSar
            // 
            this.dgvSar.AllowUserToAddRows = false;
            this.dgvSar.AllowUserToDeleteRows = false;
            this.dgvSar.AllowUserToResizeRows = false;
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
            this.dgcCaption,
            this.dgcDays,
            this.dgcHours,
            this.dgcRate,
            this.dgcPay,
            this.dgcDNS,
            this.dgcIINEx,
            this.dgcIIN,
            this.dgcCash});
            this.dgvSar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSar.Location = new System.Drawing.Point(0, 0);
            this.dgvSar.Name = "dgvSar";
            this.dgvSar.ReadOnly = true;
            this.dgvSar.RowHeadersVisible = false;
            this.dgvSar.RowTemplate.Height = 24;
            this.dgvSar.Size = new System.Drawing.Size(828, 211);
            this.dgvSar.TabIndex = 0;
            // 
            // dgcCaption
            // 
            this.dgcCaption.DataPropertyName = "Caption";
            this.dgcCaption.HeaderText = "datumi";
            this.dgcCaption.Name = "dgcCaption";
            this.dgcCaption.ReadOnly = true;
            this.dgcCaption.Width = 200;
            // 
            // dgcDays
            // 
            this.dgcDays.DataPropertyName = "Days";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "0;-0;\"\"";
            this.dgcDays.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcDays.HeaderText = "dienas";
            this.dgcDays.Name = "dgcDays";
            this.dgcDays.ReadOnly = true;
            this.dgcDays.Width = 60;
            // 
            // dgcHours
            // 
            this.dgcHours.DataPropertyName = "Hours";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "0.##;-0.##;\"\"";
            dataGridViewCellStyle3.NullValue = null;
            this.dgcHours.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcHours.HeaderText = "stundas";
            this.dgcHours.Name = "dgcHours";
            this.dgcHours.ReadOnly = true;
            this.dgcHours.Width = 60;
            // 
            // dgcRate
            // 
            this.dgcRate.DataPropertyName = "AvPayRate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "0.0000;-0.0000";
            this.dgcRate.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcRate.HeaderText = "likme";
            this.dgcRate.Name = "dgcRate";
            this.dgcRate.ReadOnly = true;
            this.dgcRate.ToolTipText = "Piemērotā vidējās izpeļņas dienas likme";
            this.dgcRate.Width = 80;
            // 
            // dgcPay
            // 
            this.dgcPay.DataPropertyName = "Pay";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "0.00;-0.00;\"\"";
            this.dgcPay.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcPay.HeaderText = "aprēķināts";
            this.dgcPay.Name = "dgcPay";
            this.dgcPay.ReadOnly = true;
            this.dgcPay.Width = 80;
            // 
            // dgcDNS
            // 
            this.dgcDNS.DataPropertyName = "DNS";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "0.00;-0.00;\"\"";
            this.dgcDNS.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcDNS.HeaderText = "DŅ SI";
            this.dgcDNS.Name = "dgcDNS";
            this.dgcDNS.ReadOnly = true;
            this.dgcDNS.Width = 80;
            // 
            // dgcIINEx
            // 
            this.dgcIINEx.DataPropertyName = "IINEX";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "0.00;-0.00;\"\"";
            this.dgcIINEx.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcIINEx.HeaderText = "IIN atv.";
            this.dgcIINEx.Name = "dgcIINEx";
            this.dgcIINEx.ReadOnly = true;
            this.dgcIINEx.Width = 80;
            // 
            // dgcIIN
            // 
            this.dgcIIN.DataPropertyName = "IIN";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "0.00;-0.00;\"\"";
            this.dgcIIN.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcIIN.HeaderText = "IIN";
            this.dgcIIN.Name = "dgcIIN";
            this.dgcIIN.ReadOnly = true;
            this.dgcIIN.Width = 80;
            // 
            // dgcCash
            // 
            this.dgcCash.DataPropertyName = "Cash";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "0.00;-0.00;\"\"";
            this.dgcCash.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcCash.HeaderText = "pēc nod.";
            this.dgcCash.Name = "dgcCash";
            this.dgcCash.ReadOnly = true;
            this.dgcCash.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbRateCalDay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmReport);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tbRateDay);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbRateHour);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 145);
            this.panel1.TabIndex = 24;
            // 
            // tbRateCalDay
            // 
            this.tbRateCalDay.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRateCalDay.Location = new System.Drawing.Point(206, 92);
            this.tbRateCalDay.Name = "tbRateCalDay";
            this.tbRateCalDay.ReadOnly = true;
            this.tbRateCalDay.Size = new System.Drawing.Size(86, 22);
            this.tbRateCalDay.TabIndex = 32;
            this.tbRateCalDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 32);
            this.label1.TabIndex = 33;
            this.label1.Text = "Aprēķinātā vidējā kalendāra \r\ndienas likme:";
            // 
            // cmReport
            // 
            this.cmReport.Location = new System.Drawing.Point(532, 42);
            this.cmReport.Name = "cmReport";
            this.cmReport.Size = new System.Drawing.Size(120, 44);
            this.cmReport.TabIndex = 26;
            this.cmReport.Text = "Izdrukai";
            this.cmReport.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(532, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 42);
            this.button1.TabIndex = 27;
            this.button1.Text = "Aizvērt";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbRateDay
            // 
            this.tbRateDay.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRateDay.Location = new System.Drawing.Point(206, 64);
            this.tbRateDay.Name = "tbRateDay";
            this.tbRateDay.ReadOnly = true;
            this.tbRateDay.Size = new System.Drawing.Size(86, 22);
            this.tbRateDay.TabIndex = 25;
            this.tbRateDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Vidējā dienas likme:";
            // 
            // tbRateHour
            // 
            this.tbRateHour.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRateHour.Location = new System.Drawing.Point(206, 36);
            this.tbRateHour.Name = "tbRateHour";
            this.tbRateHour.ReadOnly = true;
            this.tbRateHour.Size = new System.Drawing.Size(86, 22);
            this.tbRateHour.TabIndex = 24;
            this.tbRateHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Vidējā stundas likme:";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbTitle.Location = new System.Drawing.Point(10, 10);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(51, 16);
            this.lbTitle.TabIndex = 28;
            this.lbTitle.Text = "label1";
            // 
            // Form_VacationCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 356);
            this.Controls.Add(this.dgvSar);
            this.Controls.Add(this.panel1);
            this.Name = "Form_VacationCalc";
            this.Text = "Atvaļinājuma naudas aprēķins";
            this.Load += new System.EventHandler(this.Form_VacationCalc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KlonsLIB.Components.MyDataGridView dgvSar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmReport;
        private System.Windows.Forms.Button button1;
        private KlonsLIB.Components.MyTextBox tbRateDay;
        private System.Windows.Forms.Label label3;
        private KlonsLIB.Components.MyTextBox tbRateHour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTitle;
        private KlonsLIB.Components.MyTextBox tbRateCalDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDNS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIINEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCash;
    }
}