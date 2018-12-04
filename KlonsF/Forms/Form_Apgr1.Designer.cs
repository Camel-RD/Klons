namespace KlonsF.Forms
{
    partial class Form_Apgr1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslParams = new System.Windows.Forms.ToolStripLabel();
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.acDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDbDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDbDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tCrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bDbDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bCrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsRows = new KlonsLIB.Data.MyBindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslParams});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(939, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslParams
            // 
            this.tslParams.Name = "tslParams";
            this.tslParams.Size = new System.Drawing.Size(142, 25);
            this.tslParams.Text = "toolStripLabel1";
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.AutoSave = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.acDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.aDbDataGridViewTextBoxColumn,
            this.aCrDataGridViewTextBoxColumn,
            this.tDbDataGridViewTextBoxColumn,
            this.tCrDataGridViewTextBoxColumn,
            this.bDbDataGridViewTextBoxColumn,
            this.bCrDataGridViewTextBoxColumn});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 28);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowTemplate.Height = 24;
            this.dgvRows.Size = new System.Drawing.Size(939, 366);
            this.dgvRows.TabIndex = 1;
            // 
            // acDataGridViewTextBoxColumn
            // 
            this.acDataGridViewTextBoxColumn.DataPropertyName = "Ac";
            this.acDataGridViewTextBoxColumn.Frozen = true;
            this.acDataGridViewTextBoxColumn.HeaderText = "Konts";
            this.acDataGridViewTextBoxColumn.Name = "acDataGridViewTextBoxColumn";
            this.acDataGridViewTextBoxColumn.ReadOnly = true;
            this.acDataGridViewTextBoxColumn.Width = 60;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Nosaukums";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // aDbDataGridViewTextBoxColumn
            // 
            this.aDbDataGridViewTextBoxColumn.DataPropertyName = "ADb";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.aDbDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.aDbDataGridViewTextBoxColumn.HeaderText = "Debets sākumā";
            this.aDbDataGridViewTextBoxColumn.Name = "aDbDataGridViewTextBoxColumn";
            this.aDbDataGridViewTextBoxColumn.ReadOnly = true;
            this.aDbDataGridViewTextBoxColumn.ToolTipText = "Debeta atlikums perioda sākumā";
            // 
            // aCrDataGridViewTextBoxColumn
            // 
            this.aCrDataGridViewTextBoxColumn.DataPropertyName = "ACr";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.aCrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.aCrDataGridViewTextBoxColumn.HeaderText = "kredīts sākumā";
            this.aCrDataGridViewTextBoxColumn.Name = "aCrDataGridViewTextBoxColumn";
            this.aCrDataGridViewTextBoxColumn.ReadOnly = true;
            this.aCrDataGridViewTextBoxColumn.ToolTipText = "Kredīta atlikums perioda sākumā";
            // 
            // tDbDataGridViewTextBoxColumn
            // 
            this.tDbDataGridViewTextBoxColumn.DataPropertyName = "TDb";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.tDbDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.tDbDataGridViewTextBoxColumn.HeaderText = "Debets +";
            this.tDbDataGridViewTextBoxColumn.Name = "tDbDataGridViewTextBoxColumn";
            this.tDbDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tCrDataGridViewTextBoxColumn
            // 
            this.tCrDataGridViewTextBoxColumn.DataPropertyName = "TCr";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            this.tCrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.tCrDataGridViewTextBoxColumn.HeaderText = "Kredīts +";
            this.tCrDataGridViewTextBoxColumn.Name = "tCrDataGridViewTextBoxColumn";
            this.tCrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bDbDataGridViewTextBoxColumn
            // 
            this.bDbDataGridViewTextBoxColumn.DataPropertyName = "BDb";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            this.bDbDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.bDbDataGridViewTextBoxColumn.HeaderText = "Debets beigās";
            this.bDbDataGridViewTextBoxColumn.Name = "bDbDataGridViewTextBoxColumn";
            this.bDbDataGridViewTextBoxColumn.ReadOnly = true;
            this.bDbDataGridViewTextBoxColumn.ToolTipText = "Debeta atlikums perioda beigās";
            // 
            // bCrDataGridViewTextBoxColumn
            // 
            this.bCrDataGridViewTextBoxColumn.DataPropertyName = "BCr";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            this.bCrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.bCrDataGridViewTextBoxColumn.HeaderText = "Kredīts beigās";
            this.bCrDataGridViewTextBoxColumn.Name = "bCrDataGridViewTextBoxColumn";
            this.bCrDataGridViewTextBoxColumn.ReadOnly = true;
            this.bCrDataGridViewTextBoxColumn.ToolTipText = "Kredīta atlikums perioda beigās";
            // 
            // bsRows
            // 
            this.bsRows.DataMember = "ROps2a";
            this.bsRows.MyDataSource = "KlonsRep";
            // 
            // Form_Apgr1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(939, 394);
            this.CloseOnEscape = true;
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_Apgr1";
            this.Text = "Apgrozijuma pārskats";
            this.Load += new System.EventHandler(this.Form_Apgr1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslParams;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private KlonsLIB.Data.MyBindingSource bsRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn acDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDbDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aCrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDbDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tCrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bDbDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bCrDataGridViewTextBoxColumn;
    }
}