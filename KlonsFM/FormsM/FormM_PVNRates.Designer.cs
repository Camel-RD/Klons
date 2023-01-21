
namespace KlonsFM.FormsM
{
    partial class FormM_PVNRates
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
            this.bsPVNRate = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIsReverse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsPVNRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.SuspendLayout();
            // 
            // bsPVNRate
            // 
            this.bsPVNRate.DataMember = "M_PVNRATES";
            this.bsPVNRate.MyDataSource = "KlonsMData";
            this.bsPVNRate.Sort = "ID";
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.AutoSave = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcCode,
            this.dgcName,
            this.dgcRate,
            this.dgcIsReverse,
            this.dgcId});
            this.dgvRows.DataSource = this.bsPVNRate;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 0);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersWidth = 62;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(581, 365);
            this.dgvRows.TabIndex = 0;
            this.dgvRows.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRows_MyKeyDown);
            this.dgvRows.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRows_CellDoubleClick);
            this.dgvRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvRows_KeyPress);
            // 
            // dgcCode
            // 
            this.dgcCode.DataPropertyName = "CODE";
            this.dgcCode.HeaderText = "kods";
            this.dgcCode.MinimumWidth = 8;
            this.dgcCode.Name = "dgcCode";
            this.dgcCode.ReadOnly = true;
            this.dgcCode.Width = 90;
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "NAME";
            this.dgcName.HeaderText = "nosaukums";
            this.dgcName.MinimumWidth = 8;
            this.dgcName.Name = "dgcName";
            this.dgcName.ReadOnly = true;
            this.dgcName.Width = 200;
            // 
            // dgcRate
            // 
            this.dgcRate.DataPropertyName = "RATE";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcRate.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcRate.HeaderText = "likme";
            this.dgcRate.MinimumWidth = 8;
            this.dgcRate.Name = "dgcRate";
            this.dgcRate.ReadOnly = true;
            this.dgcRate.Width = 90;
            // 
            // dgcIsReverse
            // 
            this.dgcIsReverse.DataPropertyName = "ISREVERSE";
            this.dgcIsReverse.FalseValue = "0";
            this.dgcIsReverse.HeaderText = "reversais";
            this.dgcIsReverse.MinimumWidth = 8;
            this.dgcIsReverse.Name = "dgcIsReverse";
            this.dgcIsReverse.ReadOnly = true;
            this.dgcIsReverse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcIsReverse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcIsReverse.TrueValue = "1";
            this.dgcIsReverse.Width = 80;
            // 
            // dgcId
            // 
            this.dgcId.DataPropertyName = "ID";
            this.dgcId.HeaderText = "ID";
            this.dgcId.MinimumWidth = 8;
            this.dgcId.Name = "dgcId";
            this.dgcId.ReadOnly = true;
            this.dgcId.Visible = false;
            this.dgcId.Width = 60;
            // 
            // FormM_PVNRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 365);
            this.Controls.Add(this.dgvRows);
            this.Name = "FormM_PVNRates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PVN likmes";
            this.Load += new System.EventHandler(this.FormM_PVNRates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPVNRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsPVNRate;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgcIsReverse;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcId;
    }
}