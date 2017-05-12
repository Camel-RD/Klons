namespace KlonsA.Forms
{
    partial class FormRep_VacDays
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRep_VacDays));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbGetRows = new System.Windows.Forms.ToolStripButton();
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcToUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCompensated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNotUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsRows = new System.Windows.Forms.BindingSource(this.components);
            this.tbDate = new KlonsLIB.Components.MyTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsbGetRows});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(746, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(85, 29);
            this.toolStripLabel1.Text = "Datums:";
            // 
            // tsbGetRows
            // 
            this.tsbGetRows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbGetRows.Image = ((System.Drawing.Image)(resources.GetObject("tsbGetRows.Image")));
            this.tsbGetRows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGetRows.Name = "tsbGetRows";
            this.tsbGetRows.Size = new System.Drawing.Size(69, 29);
            this.tsbGetRows.Text = "Atlasīt";
            this.tsbGetRows.Click += new System.EventHandler(this.tsbGetRows_Click);
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
            this.dgcName,
            this.dgcToUse,
            this.dgcUsed,
            this.dgcCompensated,
            this.dgcNotUsed});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 32);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowTemplate.Height = 24;
            this.dgvRows.Size = new System.Drawing.Size(746, 319);
            this.dgvRows.TabIndex = 1;
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "Name";
            this.dgcName.HeaderText = "vārds, uzvārds";
            this.dgcName.Name = "dgcName";
            this.dgcName.ReadOnly = true;
            this.dgcName.Width = 250;
            // 
            // dgcToUse
            // 
            this.dgcToUse.DataPropertyName = "ToUse";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.dgcToUse.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcToUse.HeaderText = "pienākas d.";
            this.dgcToUse.Name = "dgcToUse";
            this.dgcToUse.ReadOnly = true;
            this.dgcToUse.ToolTipText = "atvaļinājuma dienas, kas pienākas par nostrādāto laiku";
            this.dgcToUse.Width = 110;
            // 
            // dgcUsed
            // 
            this.dgcUsed.DataPropertyName = "Used";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcUsed.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcUsed.HeaderText = "izmantots";
            this.dgcUsed.Name = "dgcUsed";
            this.dgcUsed.ReadOnly = true;
            this.dgcUsed.ToolTipText = "izmantotās atvaļinājuma dienas";
            // 
            // dgcCompensated
            // 
            this.dgcCompensated.DataPropertyName = "Compansated";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcCompensated.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcCompensated.HeaderText = "kompensēts";
            this.dgcCompensated.Name = "dgcCompensated";
            this.dgcCompensated.ReadOnly = true;
            this.dgcCompensated.ToolTipText = "kompensētās atvaļinājuma dienas";
            // 
            // dgcNotUsed
            // 
            this.dgcNotUsed.DataPropertyName = "NotUsed";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcNotUsed.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcNotUsed.HeaderText = "neizmantots";
            this.dgcNotUsed.Name = "dgcNotUsed";
            this.dgcNotUsed.ReadOnly = true;
            this.dgcNotUsed.ToolTipText = "neizmantotās atvaļinājuma dienas";
            // 
            // tbDate
            // 
            this.tbDate.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate.IsDate = true;
            this.tbDate.Location = new System.Drawing.Point(273, 4);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(90, 22);
            this.tbDate.TabIndex = 2;
            this.tbDate.Enter += new System.EventHandler(this.tbDate_Enter);
            // 
            // FormRep_VacDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 351);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormRep_VacDays";
            this.Text = "Neizmantotās atvaļinājuma dienas";
            this.Load += new System.EventHandler(this.FormRep_VacDays_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsbGetRows;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.BindingSource bsRows;
        private KlonsLIB.Components.MyTextBox tbDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcToUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCompensated;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNotUsed;
    }
}