namespace KlonsF.Forms
{
    partial class Form_PVN_Dekl
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
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcText,
            this.dgcNr,
            this.dgcValue});
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 0);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersWidth = 53;
            this.dgvRows.RowTemplate.Height = 24;
            this.dgvRows.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRows.Size = new System.Drawing.Size(864, 450);
            this.dgvRows.TabIndex = 0;
            this.dgvRows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRows_CellFormatting);
            // 
            // dgcText
            // 
            this.dgcText.DataPropertyName = "Text";
            this.dgcText.HeaderText = "Deklarācijas rinda";
            this.dgcText.MinimumWidth = 7;
            this.dgcText.Name = "dgcText";
            this.dgcText.ReadOnly = true;
            this.dgcText.Width = 600;
            // 
            // dgcNr
            // 
            this.dgcNr.DataPropertyName = "TextNr";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcNr.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcNr.HeaderText = "Nr.";
            this.dgcNr.MinimumWidth = 7;
            this.dgcNr.Name = "dgcNr";
            this.dgcNr.ReadOnly = true;
            this.dgcNr.Width = 60;
            // 
            // dgcValue
            // 
            this.dgcValue.DataPropertyName = "Value";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcValue.HeaderText = "Summa";
            this.dgcValue.MinimumWidth = 7;
            this.dgcValue.Name = "dgcValue";
            this.dgcValue.ReadOnly = true;
            // 
            // Form_PVN_Dekl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 450);
            this.Controls.Add(this.dgvRows);
            this.Name = "Form_PVN_Dekl";
            this.Text = "PVN deklarācija";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcText;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcValue;
    }
}