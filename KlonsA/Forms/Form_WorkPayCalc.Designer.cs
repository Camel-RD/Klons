namespace KlonsA.Forms
{
    partial class Form_WorkPayCalc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSar = new KlonsLIB.Components.MyDataGridView();
            this.dgcCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRateType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.dgcRMT,
            this.dgcRateType,
            this.dgcRHR,
            this.dgcSalary});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.Format = "0.####;-0.####;\"\"";
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSar.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSar.Location = new System.Drawing.Point(0, 0);
            this.dgvSar.Name = "dgvSar";
            this.dgvSar.ReadOnly = true;
            this.dgvSar.RowHeadersVisible = false;
            this.dgvSar.RowTemplate.Height = 24;
            this.dgvSar.Size = new System.Drawing.Size(742, 236);
            this.dgvSar.TabIndex = 0;
            this.dgvSar.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSar_CellPainting);
            // 
            // dgcCaption
            // 
            this.dgcCaption.DataPropertyName = "Caption";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgcCaption.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcCaption.Frozen = true;
            this.dgcCaption.HeaderText = "";
            this.dgcCaption.Name = "dgcCaption";
            this.dgcCaption.ReadOnly = true;
            this.dgcCaption.Width = 180;
            // 
            // dgcDays
            // 
            this.dgcDays.DataPropertyName = "Days";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "0;-0;\"\"";
            this.dgcDays.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcDays.HeaderText = "dienas";
            this.dgcDays.Name = "dgcDays";
            this.dgcDays.ReadOnly = true;
            this.dgcDays.Width = 60;
            // 
            // dgcHours
            // 
            this.dgcHours.DataPropertyName = "Hours";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "0.##;-0.##;\"\"";
            this.dgcHours.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcHours.HeaderText = "stundas";
            this.dgcHours.Name = "dgcHours";
            this.dgcHours.ReadOnly = true;
            this.dgcHours.Width = 60;
            // 
            // dgcRMT
            // 
            this.dgcRMT.DataPropertyName = "RateDef";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "### ##0.####;-### ##0.####;\"\"";
            this.dgcRMT.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcRMT.HeaderText = "likme";
            this.dgcRMT.Name = "dgcRMT";
            this.dgcRMT.ReadOnly = true;
            this.dgcRMT.Width = 80;
            // 
            // dgcRateType
            // 
            this.dgcRateType.DataPropertyName = "RateType";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcRateType.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcRateType.HeaderText = "likmes veids";
            this.dgcRateType.Name = "dgcRateType";
            this.dgcRateType.ReadOnly = true;
            this.dgcRateType.Width = 60;
            // 
            // dgcRHR
            // 
            this.dgcRHR.DataPropertyName = "Rate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "0.####;-0.####;\"\"";
            this.dgcRHR.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcRHR.HeaderText = "apr. likme";
            this.dgcRHR.Name = "dgcRHR";
            this.dgcRHR.ReadOnly = true;
            // 
            // dgcSalary
            // 
            this.dgcSalary.DataPropertyName = "Salary";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "### ##0.00;-### ##0.00;\"\"";
            this.dgcSalary.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcSalary.HeaderText = "samaksa";
            this.dgcSalary.Name = "dgcSalary";
            this.dgcSalary.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmReport);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tbRateDay);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbRateHour);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 236);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 129);
            this.panel1.TabIndex = 1;
            // 
            // cmReport
            // 
            this.cmReport.Location = new System.Drawing.Point(378, 39);
            this.cmReport.Name = "cmReport";
            this.cmReport.Size = new System.Drawing.Size(120, 44);
            this.cmReport.TabIndex = 33;
            this.cmReport.Text = "Izdrukai";
            this.cmReport.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(513, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 42);
            this.button1.TabIndex = 34;
            this.button1.Text = "Aizvērt";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbRateDay
            // 
            this.tbRateDay.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRateDay.Location = new System.Drawing.Point(202, 61);
            this.tbRateDay.Name = "tbRateDay";
            this.tbRateDay.ReadOnly = true;
            this.tbRateDay.Size = new System.Drawing.Size(86, 22);
            this.tbRateDay.TabIndex = 32;
            this.tbRateDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "Vidējā dienas likme:";
            // 
            // tbRateHour
            // 
            this.tbRateHour.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRateHour.Location = new System.Drawing.Point(202, 33);
            this.tbRateHour.Name = "tbRateHour";
            this.tbRateHour.ReadOnly = true;
            this.tbRateHour.Size = new System.Drawing.Size(86, 22);
            this.tbRateHour.TabIndex = 31;
            this.tbRateHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "Vidējā stundas likme:";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbTitle.Location = new System.Drawing.Point(6, 7);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(51, 16);
            this.lbTitle.TabIndex = 35;
            this.lbTitle.Text = "label1";
            // 
            // Form_WorkPayCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 365);
            this.Controls.Add(this.dgvSar);
            this.Controls.Add(this.panel1);
            this.Name = "Form_WorkPayCalc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Darba samaksas aprēķins";
            this.Load += new System.EventHandler(this.Form_WorkPayCalc_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRateType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSalary;
    }
}