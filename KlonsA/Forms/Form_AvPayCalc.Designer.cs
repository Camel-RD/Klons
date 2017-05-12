namespace KlonsA.Forms
{
    partial class Form_AvPayCalc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbRateCalDay = new KlonsLIB.Components.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmReport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbRateDay = new KlonsLIB.Components.MyTextBox();
            this.tbRateHour = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRem = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.dgcCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBruto2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCalDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDaysPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcHoursPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDaysFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcHoursFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSar
            // 
            this.dgvSar.AllowUserToAddRows = false;
            this.dgvSar.AllowUserToDeleteRows = false;
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
            this.dgcSalary,
            this.dgcBruto2,
            this.dgcPay,
            this.dgcCalDays,
            this.dgcDaysPlan,
            this.dgcHoursPlan,
            this.dgcDaysFact,
            this.dgcHoursFact});
            this.dgvSar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSar.Location = new System.Drawing.Point(0, 0);
            this.dgvSar.Name = "dgvSar";
            this.dgvSar.ReadOnly = true;
            this.dgvSar.RowTemplate.Height = 24;
            this.dgvSar.Size = new System.Drawing.Size(809, 234);
            this.dgvSar.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbRateCalDay);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmReport);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tbRateDay);
            this.panel1.Controls.Add(this.tbRateHour);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbRem);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 234);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 138);
            this.panel1.TabIndex = 1;
            // 
            // tbRateCalDay
            // 
            this.tbRateCalDay.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRateCalDay.Location = new System.Drawing.Point(232, 83);
            this.tbRateCalDay.Name = "tbRateCalDay";
            this.tbRateCalDay.ReadOnly = true;
            this.tbRateCalDay.Size = new System.Drawing.Size(111, 22);
            this.tbRateCalDay.TabIndex = 9;
            this.tbRateCalDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "Aprēķinātā vidējā kalendāra \r\ndienas likme:";
            // 
            // cmReport
            // 
            this.cmReport.Location = new System.Drawing.Point(385, 38);
            this.cmReport.Name = "cmReport";
            this.cmReport.Size = new System.Drawing.Size(116, 44);
            this.cmReport.TabIndex = 8;
            this.cmReport.Text = "Izdrukai";
            this.cmReport.UseVisualStyleBackColor = true;
            this.cmReport.Click += new System.EventHandler(this.cmReport_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(522, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "Aizvērt";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbRateDay
            // 
            this.tbRateDay.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRateDay.Location = new System.Drawing.Point(232, 55);
            this.tbRateDay.Name = "tbRateDay";
            this.tbRateDay.ReadOnly = true;
            this.tbRateDay.Size = new System.Drawing.Size(111, 22);
            this.tbRateDay.TabIndex = 1;
            this.tbRateDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbRateHour
            // 
            this.tbRateHour.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRateHour.Location = new System.Drawing.Point(232, 28);
            this.tbRateHour.Name = "tbRateHour";
            this.tbRateHour.ReadOnly = true;
            this.tbRateHour.Size = new System.Drawing.Size(111, 22);
            this.tbRateHour.TabIndex = 0;
            this.tbRateHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Aprēķinātā vidējā dienas likme:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Aprēķinātā vidējā stundas likme:";
            // 
            // lbRem
            // 
            this.lbRem.AutoSize = true;
            this.lbRem.Location = new System.Drawing.Point(229, 113);
            this.lbRem.Name = "lbRem";
            this.lbRem.Size = new System.Drawing.Size(14, 16);
            this.lbRem.TabIndex = 7;
            this.lbRem.Text = "  ";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbTitle.Location = new System.Drawing.Point(3, 3);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(51, 16);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "label1";
            // 
            // dgcCaption
            // 
            this.dgcCaption.DataPropertyName = "Caption";
            this.dgcCaption.HeaderText = "mēnesis";
            this.dgcCaption.Name = "dgcCaption";
            this.dgcCaption.ReadOnly = true;
            // 
            // dgcSalary
            // 
            this.dgcSalary.DataPropertyName = "Salary";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dgcSalary.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcSalary.HeaderText = "darba samaksa";
            this.dgcSalary.Name = "dgcSalary";
            this.dgcSalary.ReadOnly = true;
            this.dgcSalary.Width = 80;
            // 
            // dgcBruto2
            // 
            this.dgcBruto2.DataPropertyName = "Salary2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dgcBruto2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcBruto2.HeaderText = "bruto";
            this.dgcBruto2.Name = "dgcBruto2";
            this.dgcBruto2.ReadOnly = true;
            this.dgcBruto2.Width = 80;
            // 
            // dgcPay
            // 
            this.dgcPay.DataPropertyName = "Pay";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.dgcPay.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcPay.HeaderText = "izmaksāts";
            this.dgcPay.Name = "dgcPay";
            this.dgcPay.ReadOnly = true;
            this.dgcPay.Width = 80;
            // 
            // dgcCalDays
            // 
            this.dgcCalDays.DataPropertyName = "CalendarDays";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcCalDays.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcCalDays.HeaderText = "kalend. dienas";
            this.dgcCalDays.Name = "dgcCalDays";
            this.dgcCalDays.ReadOnly = true;
            this.dgcCalDays.ToolTipText = "kalendāra dienas";
            this.dgcCalDays.Width = 80;
            // 
            // dgcDaysPlan
            // 
            this.dgcDaysPlan.DataPropertyName = "DaysPlan";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcDaysPlan.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcDaysPlan.HeaderText = "dienas plāns";
            this.dgcDaysPlan.Name = "dgcDaysPlan";
            this.dgcDaysPlan.ReadOnly = true;
            this.dgcDaysPlan.Width = 80;
            // 
            // dgcHoursPlan
            // 
            this.dgcHoursPlan.DataPropertyName = "HoursPlan";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcHoursPlan.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcHoursPlan.HeaderText = "stundas plāns";
            this.dgcHoursPlan.Name = "dgcHoursPlan";
            this.dgcHoursPlan.ReadOnly = true;
            this.dgcHoursPlan.Width = 80;
            // 
            // dgcDaysFact
            // 
            this.dgcDaysFact.DataPropertyName = "DaysFact";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcDaysFact.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcDaysFact.HeaderText = "dienas fakts";
            this.dgcDaysFact.Name = "dgcDaysFact";
            this.dgcDaysFact.ReadOnly = true;
            this.dgcDaysFact.Width = 80;
            // 
            // dgcHoursFact
            // 
            this.dgcHoursFact.DataPropertyName = "HoursFact";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcHoursFact.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcHoursFact.HeaderText = "stundas fakts";
            this.dgcHoursFact.Name = "dgcHoursFact";
            this.dgcHoursFact.ReadOnly = true;
            this.dgcHoursFact.Width = 80;
            // 
            // Form_AvPayCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 372);
            this.Controls.Add(this.dgvSar);
            this.Controls.Add(this.panel1);
            this.Name = "Form_AvPayCalc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vidējās izpeļņas aprēķins";
            this.Load += new System.EventHandler(this.Form_AvPayCalc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KlonsLIB.Components.MyDataGridView dgvSar;
        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Components.MyTextBox tbRateDay;
        private KlonsLIB.Components.MyTextBox tbRateHour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRem;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmReport;
        private KlonsLIB.Components.MyTextBox tbRateCalDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBruto2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCalDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDaysPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcHoursPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDaysFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcHoursFact;
    }
}