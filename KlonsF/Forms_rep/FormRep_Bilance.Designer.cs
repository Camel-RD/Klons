using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.Forms
{
    partial class FormRep_Bilance
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
            this.bsBalA1 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvBalA1 = new KlonsLIB.Components.MyDataGridView();
            this.tbSD = new KlonsLIB.Components.MyTextBox();
            this.tbED = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmReport = new System.Windows.Forms.Button();
            this.cmEdit = new System.Windows.Forms.Button();
            this.lbCM = new System.Windows.Forms.ListBox();
            this.dgcBalA1balid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA1Descr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA1TA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBalA1TP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBalA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalA1)).BeginInit();
            this.SuspendLayout();
            // 
            // bsBalA1
            // 
            this.bsBalA1.DataMember = "BalA1";
            this.bsBalA1.MyDataSource = "KlonsData";
            this.bsBalA1.Name2 = "bsBalA1";
            // 
            // dgvBalA1
            // 
            this.dgvBalA1.AllowUserToAddRows = false;
            this.dgvBalA1.AllowUserToDeleteRows = false;
            this.dgvBalA1.AllowUserToResizeRows = false;
            this.dgvBalA1.AutoGenerateColumns = false;
            this.dgvBalA1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBalA1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBalA1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcBalA1balid,
            this.dgcBalA1Descr,
            this.dgcBalA1TA,
            this.dgcBalA1TP});
            this.dgvBalA1.DataSource = this.bsBalA1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBalA1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBalA1.Location = new System.Drawing.Point(6, 6);
            this.dgvBalA1.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBalA1.Name = "dgvBalA1";
            this.dgvBalA1.ReadOnly = true;
            this.dgvBalA1.RowHeadersVisible = false;
            this.dgvBalA1.RowTemplate.Height = 19;
            this.dgvBalA1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBalA1.Size = new System.Drawing.Size(453, 121);
            this.dgvBalA1.TabIndex = 0;
            // 
            // tbSD
            // 
            this.tbSD.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSD.IsDate = true;
            this.tbSD.Location = new System.Drawing.Point(138, 146);
            this.tbSD.Margin = new System.Windows.Forms.Padding(2);
            this.tbSD.Name = "tbSD";
            this.tbSD.Size = new System.Drawing.Size(88, 22);
            this.tbSD.TabIndex = 1;
            this.tbSD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // tbED
            // 
            this.tbED.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbED.IsDate = true;
            this.tbED.Location = new System.Drawing.Point(231, 146);
            this.tbED.Margin = new System.Windows.Forms.Padding(2);
            this.tbED.Name = "tbED";
            this.tbED.Size = new System.Drawing.Size(88, 22);
            this.tbED.TabIndex = 2;
            this.tbED.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Datums (no - līdz):";
            // 
            // cmReport
            // 
            this.cmReport.Location = new System.Drawing.Point(333, 146);
            this.cmReport.Margin = new System.Windows.Forms.Padding(2);
            this.cmReport.Name = "cmReport";
            this.cmReport.Size = new System.Drawing.Size(110, 54);
            this.cmReport.TabIndex = 3;
            this.cmReport.Text = "Atskaite";
            this.cmReport.UseVisualStyleBackColor = true;
            this.cmReport.Click += new System.EventHandler(this.cmReport_Click);
            this.cmReport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // cmEdit
            // 
            this.cmEdit.Location = new System.Drawing.Point(333, 221);
            this.cmEdit.Margin = new System.Windows.Forms.Padding(2);
            this.cmEdit.Name = "cmEdit";
            this.cmEdit.Size = new System.Drawing.Size(110, 54);
            this.cmEdit.TabIndex = 4;
            this.cmEdit.Text = "Rediģēt formulas";
            this.cmEdit.UseVisualStyleBackColor = true;
            this.cmEdit.Click += new System.EventHandler(this.cmEdit_Click);
            // 
            // lbCM
            // 
            this.lbCM.BackColor = System.Drawing.SystemColors.Control;
            this.lbCM.FormattingEnabled = true;
            this.lbCM.ItemHeight = 16;
            this.lbCM.Items.AddRange(new object[] {
            "Tikai rindas, kas nav tukšas",
            "Pilna atskaite",
            "Pa mēnešiem - apgrozijums",
            "Pa mēnešiem - atlikums",
            "Summu izklāsts pa atskaites rindu numuriem"});
            this.lbCM.Location = new System.Drawing.Point(13, 190);
            this.lbCM.Margin = new System.Windows.Forms.Padding(2);
            this.lbCM.Name = "lbCM";
            this.lbCM.Size = new System.Drawing.Size(307, 100);
            this.lbCM.TabIndex = 6;
            this.lbCM.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCM_MouseDoubleClick);
            // 
            // dgcBalA1balid
            // 
            this.dgcBalA1balid.DataPropertyName = "balid";
            this.dgcBalA1balid.HeaderText = "Kods";
            this.dgcBalA1balid.Name = "dgcBalA1balid";
            this.dgcBalA1balid.ReadOnly = true;
            this.dgcBalA1balid.ToolTipText = "Atskaites kods (B1, PZA1, utml.)";
            this.dgcBalA1balid.Width = 80;
            // 
            // dgcBalA1Descr
            // 
            this.dgcBalA1Descr.DataPropertyName = "Descr";
            this.dgcBalA1Descr.HeaderText = "Apraksts";
            this.dgcBalA1Descr.Name = "dgcBalA1Descr";
            this.dgcBalA1Descr.ReadOnly = true;
            this.dgcBalA1Descr.ToolTipText = "Apraksts";
            this.dgcBalA1Descr.Width = 350;
            // 
            // dgcBalA1TA
            // 
            this.dgcBalA1TA.DataPropertyName = "TA";
            this.dgcBalA1TA.HeaderText = "Nosaukums1";
            this.dgcBalA1TA.Name = "dgcBalA1TA";
            this.dgcBalA1TA.ReadOnly = true;
            this.dgcBalA1TA.ToolTipText = "Nosaukums atskaites aktīva pusei";
            this.dgcBalA1TA.Visible = false;
            this.dgcBalA1TA.Width = 112;
            // 
            // dgcBalA1TP
            // 
            this.dgcBalA1TP.DataPropertyName = "TP";
            this.dgcBalA1TP.HeaderText = "Nosaukums2";
            this.dgcBalA1TP.Name = "dgcBalA1TP";
            this.dgcBalA1TP.ReadOnly = true;
            this.dgcBalA1TP.ToolTipText = "Nosaukums atskaites pasīva pusei";
            this.dgcBalA1TP.Visible = false;
            this.dgcBalA1TP.Width = 112;
            // 
            // FormRep_Bilance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 303);
            this.CloseOnEscape = true;
            this.Controls.Add(this.lbCM);
            this.Controls.Add(this.cmEdit);
            this.Controls.Add(this.cmReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbED);
            this.Controls.Add(this.tbSD);
            this.Controls.Add(this.dgvBalA1);
            this.Name = "FormRep_Bilance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bilance";
            this.Load += new System.EventHandler(this.Form_Bilance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsBalA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalA1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingSource bsBalA1;
        private MyDataGridView dgvBalA1;
        private MyTextBox tbSD;
        private MyTextBox tbED;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmReport;
        private System.Windows.Forms.Button cmEdit;
        private System.Windows.Forms.ListBox lbCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA1balid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA1Descr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA1TA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBalA1TP;
    }
}