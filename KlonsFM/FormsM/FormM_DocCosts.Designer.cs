
namespace KlonsFM.FormsM
{
    partial class FormM_DocCosts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAcc = new KlonsLIB.Components.MyDataGridView();
            this.dgcAccDebFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAccCredFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAccAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAcc
            // 
            this.dgvAcc.AllowUserToAddRows = false;
            this.dgvAcc.AllowUserToDeleteRows = false;
            this.dgvAcc.AutoSave = false;
            this.dgvAcc.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcAccDebFin,
            this.dgcAccCredFin,
            this.dgcAccAmount});
            this.dgvAcc.Location = new System.Drawing.Point(12, 12);
            this.dgvAcc.Name = "dgvAcc";
            this.dgvAcc.ReadOnly = true;
            this.dgvAcc.RowHeadersVisible = false;
            this.dgvAcc.RowHeadersWidth = 62;
            this.dgvAcc.RowTemplate.Height = 28;
            this.dgvAcc.ShowCellToolTips = false;
            this.dgvAcc.Size = new System.Drawing.Size(513, 274);
            this.dgvAcc.TabIndex = 2;
            // 
            // dgcAccDebFin
            // 
            this.dgcAccDebFin.DataPropertyName = "DebFin";
            this.dgcAccDebFin.HeaderText = "debets";
            this.dgcAccDebFin.MinimumWidth = 8;
            this.dgcAccDebFin.Name = "dgcAccDebFin";
            this.dgcAccDebFin.ReadOnly = true;
            this.dgcAccDebFin.Width = 90;
            // 
            // dgcAccCredFin
            // 
            this.dgcAccCredFin.DataPropertyName = "CredFin";
            this.dgcAccCredFin.HeaderText = "kredīts";
            this.dgcAccCredFin.MinimumWidth = 8;
            this.dgcAccCredFin.Name = "dgcAccCredFin";
            this.dgcAccCredFin.ReadOnly = true;
            this.dgcAccCredFin.Width = 90;
            // 
            // dgcAccAmount
            // 
            this.dgcAccAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dgcAccAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcAccAmount.HeaderText = "summa";
            this.dgcAccAmount.MinimumWidth = 8;
            this.dgcAccAmount.Name = "dgcAccAmount";
            this.dgcAccAmount.ReadOnly = true;
            this.dgcAccAmount.Width = 120;
            // 
            // FormM_DocCosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 298);
            this.Controls.Add(this.dgvAcc);
            this.Name = "FormM_DocCosts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Realizācijas pašizmaksas kopsvilkums";
            this.Load += new System.EventHandler(this.FormM_DocCosts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KlonsLIB.Components.MyDataGridView dgvAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccDebFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccCredFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccAmount;
    }
}