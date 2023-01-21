
namespace KlonsFM.FormsM
{
    partial class FormM_ItemCurrentStock
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
            this.lbItemName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcStoreCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcStoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.SuspendLayout();
            // 
            // lbItemName
            // 
            this.lbItemName.AutoSize = true;
            this.lbItemName.Location = new System.Drawing.Point(12, 9);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(21, 20);
            this.lbItemName.TabIndex = 0;
            this.lbItemName.Text = "...";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbItemName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 37);
            this.panel1.TabIndex = 1;
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AllowUserToResizeRows = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcStoreCode,
            this.dgcStoreName,
            this.dgcAmount});
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 37);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersVisible = false;
            this.dgvRows.RowHeadersWidth = 62;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(570, 287);
            this.dgvRows.TabIndex = 2;
            // 
            // dgcStoreCode
            // 
            this.dgcStoreCode.DataPropertyName = "StoreCode";
            this.dgcStoreCode.HeaderText = "kods";
            this.dgcStoreCode.MinimumWidth = 8;
            this.dgcStoreCode.Name = "dgcStoreCode";
            this.dgcStoreCode.ReadOnly = true;
            this.dgcStoreCode.Width = 140;
            // 
            // dgcStoreName
            // 
            this.dgcStoreName.DataPropertyName = "StoreName";
            this.dgcStoreName.HeaderText = "noliktavas nosaukums";
            this.dgcStoreName.MinimumWidth = 8;
            this.dgcStoreName.Name = "dgcStoreName";
            this.dgcStoreName.ReadOnly = true;
            this.dgcStoreName.Width = 300;
            // 
            // dgcAmount
            // 
            this.dgcAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcAmount.HeaderText = "daudzums";
            this.dgcAmount.MinimumWidth = 8;
            this.dgcAmount.Name = "dgcAmount";
            this.dgcAmount.ReadOnly = true;
            this.dgcAmount.Width = 90;
            // 
            // FormM_ItemCurrentStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 324);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.panel1);
            this.Name = "FormM_ItemCurrentStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artikula atlikumi noliktavās";
            this.Load += new System.EventHandler(this.FormM_ItemCurrentStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcStoreCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcStoreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAmount;
    }
}