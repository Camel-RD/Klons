namespace KlonsA.Forms
{
    partial class Form_SickDaysCalc
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
            this.dgvSar = new KlonsLIB.Components.MyDataGridView();
            this.dgcCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDays0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDays75 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDays80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcHours75 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcHours80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSickDayPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSickDayPay75 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSickDayPay80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmReport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbRateDay = new KlonsLIB.Components.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRateHour = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPay80 = new KlonsLIB.Components.MyTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPay75 = new KlonsLIB.Components.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPay = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRem = new System.Windows.Forms.Label();
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
            this.dgcDays0,
            this.dgcDays75,
            this.dgcDays80,
            this.dgcHours75,
            this.dgcHours80,
            this.dgcRate,
            this.dgcSickDayPay,
            this.dgcSickDayPay75,
            this.dgcSickDayPay80});
            this.dgvSar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSar.Location = new System.Drawing.Point(0, 0);
            this.dgvSar.Name = "dgvSar";
            this.dgvSar.ReadOnly = true;
            this.dgvSar.RowHeadersVisible = false;
            this.dgvSar.RowTemplate.Height = 24;
            this.dgvSar.Size = new System.Drawing.Size(859, 233);
            this.dgvSar.TabIndex = 0;
            this.dgvSar.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSar_CellPainting);
            // 
            // dgcCaption
            // 
            this.dgcCaption.DataPropertyName = "Caption";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcCaption.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcCaption.HeaderText = "";
            this.dgcCaption.Name = "dgcCaption";
            this.dgcCaption.ReadOnly = true;
            this.dgcCaption.Width = 180;
            // 
            // dgcDays
            // 
            this.dgcDays.DataPropertyName = "DaysCount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "0;-0;\"\"";
            this.dgcDays.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcDays.HeaderText = "dienas";
            this.dgcDays.Name = "dgcDays";
            this.dgcDays.ReadOnly = true;
            this.dgcDays.Width = 50;
            // 
            // dgcDays0
            // 
            this.dgcDays0.DataPropertyName = "DaysCount0";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "0;-0;\"\"";
            this.dgcDays0.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcDays0.HeaderText = "dienas 0%";
            this.dgcDays0.Name = "dgcDays0";
            this.dgcDays0.ReadOnly = true;
            this.dgcDays0.Width = 50;
            // 
            // dgcDays75
            // 
            this.dgcDays75.DataPropertyName = "DaysCount75";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "0;-0;\"\"";
            this.dgcDays75.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcDays75.HeaderText = "dienas 75%";
            this.dgcDays75.Name = "dgcDays75";
            this.dgcDays75.ReadOnly = true;
            this.dgcDays75.Width = 50;
            // 
            // dgcDays80
            // 
            this.dgcDays80.DataPropertyName = "DaysCount80";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "0;-0;\"\"";
            this.dgcDays80.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcDays80.HeaderText = "dienas 80%";
            this.dgcDays80.Name = "dgcDays80";
            this.dgcDays80.ReadOnly = true;
            this.dgcDays80.Width = 50;
            // 
            // dgcHours75
            // 
            this.dgcHours75.DataPropertyName = "HoursCount75";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "0.###;-0.###;\"\"";
            this.dgcHours75.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcHours75.HeaderText = "stundas 75%";
            this.dgcHours75.Name = "dgcHours75";
            this.dgcHours75.ReadOnly = true;
            this.dgcHours75.Width = 65;
            // 
            // dgcHours80
            // 
            this.dgcHours80.DataPropertyName = "HoursCount80";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "0.###;-0.###;\"\"";
            this.dgcHours80.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcHours80.HeaderText = "stundas 80%";
            this.dgcHours80.Name = "dgcHours80";
            this.dgcHours80.ReadOnly = true;
            this.dgcHours80.Width = 65;
            // 
            // dgcRate
            // 
            this.dgcRate.DataPropertyName = "AvPayRate";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "0.0000;-0.0000;\"\"";
            this.dgcRate.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcRate.HeaderText = "likme";
            this.dgcRate.Name = "dgcRate";
            this.dgcRate.ReadOnly = true;
            this.dgcRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcRate.Width = 80;
            // 
            // dgcSickDayPay
            // 
            this.dgcSickDayPay.DataPropertyName = "SickDayPay";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "0.00;-0.00;\"\"";
            this.dgcSickDayPay.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgcSickDayPay.HeaderText = "apmaksa";
            this.dgcSickDayPay.Name = "dgcSickDayPay";
            this.dgcSickDayPay.ReadOnly = true;
            this.dgcSickDayPay.Width = 80;
            // 
            // dgcSickDayPay75
            // 
            this.dgcSickDayPay75.DataPropertyName = "SickDayPay75";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "0.00;-0.00;\"\"";
            this.dgcSickDayPay75.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgcSickDayPay75.HeaderText = "apmaksa ar 75%";
            this.dgcSickDayPay75.Name = "dgcSickDayPay75";
            this.dgcSickDayPay75.ReadOnly = true;
            this.dgcSickDayPay75.Width = 80;
            // 
            // dgcSickDayPay80
            // 
            this.dgcSickDayPay80.DataPropertyName = "SickDayPay80";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "0.00;-0.00;\"\"";
            this.dgcSickDayPay80.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgcSickDayPay80.HeaderText = "apmaksa ar 80%";
            this.dgcSickDayPay80.Name = "dgcSickDayPay80";
            this.dgcSickDayPay80.ReadOnly = true;
            this.dgcSickDayPay80.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmReport);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tbRateDay);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbRateHour);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbPay80);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbPay75);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbPay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbRem);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 233);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 146);
            this.panel1.TabIndex = 1;
            // 
            // cmReport
            // 
            this.cmReport.Location = new System.Drawing.Point(525, 35);
            this.cmReport.Name = "cmReport";
            this.cmReport.Size = new System.Drawing.Size(120, 44);
            this.cmReport.TabIndex = 5;
            this.cmReport.Text = "Izdrukai";
            this.cmReport.UseVisualStyleBackColor = true;
            this.cmReport.Click += new System.EventHandler(this.cmReport_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(525, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Aizvērt";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbRateDay
            // 
            this.tbRateDay.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRateDay.Location = new System.Drawing.Point(199, 57);
            this.tbRateDay.Name = "tbRateDay";
            this.tbRateDay.ReadOnly = true;
            this.tbRateDay.Size = new System.Drawing.Size(86, 22);
            this.tbRateDay.TabIndex = 1;
            this.tbRateDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Vidējā dienas likme:";
            // 
            // tbRateHour
            // 
            this.tbRateHour.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRateHour.Location = new System.Drawing.Point(199, 29);
            this.tbRateHour.Name = "tbRateHour";
            this.tbRateHour.ReadOnly = true;
            this.tbRateHour.Size = new System.Drawing.Size(86, 22);
            this.tbRateHour.TabIndex = 0;
            this.tbRateHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Vidējā stundas likme:";
            // 
            // tbPay80
            // 
            this.tbPay80.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbPay80.Location = new System.Drawing.Point(357, 57);
            this.tbPay80.Name = "tbPay80";
            this.tbPay80.ReadOnly = true;
            this.tbPay80.Size = new System.Drawing.Size(86, 22);
            this.tbPay80.TabIndex = 4;
            this.tbPay80.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "80%";
            // 
            // tbPay75
            // 
            this.tbPay75.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbPay75.Location = new System.Drawing.Point(357, 29);
            this.tbPay75.Name = "tbPay75";
            this.tbPay75.ReadOnly = true;
            this.tbPay75.Size = new System.Drawing.Size(86, 22);
            this.tbPay75.TabIndex = 3;
            this.tbPay75.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "75%";
            // 
            // tbPay
            // 
            this.tbPay.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbPay.Location = new System.Drawing.Point(199, 85);
            this.tbPay.Name = "tbPay";
            this.tbPay.ReadOnly = true;
            this.tbPay.Size = new System.Drawing.Size(86, 22);
            this.tbPay.TabIndex = 2;
            this.tbPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Aprēķinātā slimības nauda:";
            // 
            // lbRem
            // 
            this.lbRem.AutoSize = true;
            this.lbRem.Location = new System.Drawing.Point(8, 116);
            this.lbRem.Name = "lbRem";
            this.lbRem.Size = new System.Drawing.Size(14, 16);
            this.lbRem.TabIndex = 11;
            this.lbRem.Text = "  ";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbTitle.Location = new System.Drawing.Point(3, 3);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(51, 16);
            this.lbTitle.TabIndex = 7;
            this.lbTitle.Text = "label1";
            // 
            // Form_SickDaysCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 379);
            this.Controls.Add(this.dgvSar);
            this.Controls.Add(this.panel1);
            this.Name = "Form_SickDaysCalc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Slimības naudas aprēķins";
            this.Load += new System.EventHandler(this.Form_SickDaysCalc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KlonsLIB.Components.MyDataGridView dgvSar;
        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Components.MyTextBox tbPay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRem;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmReport;
        private KlonsLIB.Components.MyTextBox tbRateDay;
        private System.Windows.Forms.Label label3;
        private KlonsLIB.Components.MyTextBox tbRateHour;
        private System.Windows.Forms.Label label2;
        private KlonsLIB.Components.MyTextBox tbPay80;
        private System.Windows.Forms.Label label5;
        private KlonsLIB.Components.MyTextBox tbPay75;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDays0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDays75;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDays80;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcHours75;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcHours80;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSickDayPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSickDayPay75;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSickDayPay80;
    }
}