namespace KlonsFM.Forms
{
    partial class Form_ImportErrors
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
            this.bsRows = new System.Windows.Forms.BindingSource(this.components);
            this.dgcSheetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRowNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcColNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AllowUserToResizeRows = false;
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.AutoSave = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcSheetName,
            this.dgcRowNr,
            this.dgcColNr,
            this.dgcError});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 0);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersVisible = false;
            this.dgvRows.RowTemplate.Height = 24;
            this.dgvRows.Size = new System.Drawing.Size(584, 354);
            this.dgvRows.TabIndex = 0;
            // 
            // dgcSheetName
            // 
            this.dgcSheetName.DataPropertyName = "SheetName";
            this.dgcSheetName.HeaderText = "Lapa";
            this.dgcSheetName.Name = "dgcSheetName";
            this.dgcSheetName.ReadOnly = true;
            this.dgcSheetName.Width = 120;
            // 
            // dgcRowNr
            // 
            this.dgcRowNr.DataPropertyName = "RowNr";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcRowNr.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcRowNr.HeaderText = "Rinda";
            this.dgcRowNr.Name = "dgcRowNr";
            this.dgcRowNr.ReadOnly = true;
            this.dgcRowNr.Width = 60;
            // 
            // dgcColNr
            // 
            this.dgcColNr.DataPropertyName = "ColNr";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcColNr.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcColNr.HeaderText = "Kolonna";
            this.dgcColNr.Name = "dgcColNr";
            this.dgcColNr.ReadOnly = true;
            this.dgcColNr.Width = 60;
            // 
            // dgcError
            // 
            this.dgcError.DataPropertyName = "Error";
            this.dgcError.HeaderText = "Kļūda";
            this.dgcError.Name = "dgcError";
            this.dgcError.ReadOnly = true;
            this.dgcError.Width = 300;
            // 
            // Form_ImportErrors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 354);
            this.Controls.Add(this.dgvRows);
            this.Name = "Form_ImportErrors";
            this.Text = "Kļūdas";
            this.Load += new System.EventHandler(this.Form_ImportErrors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.BindingSource bsRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSheetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRowNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcColNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcError;
    }
}