
namespace KlonsFM.FormsM
{
    partial class FormM_DocTypes
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
            this.bsRows = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.SuspendLayout();
            // 
            // bsRows
            // 
            this.bsRows.DataMember = "M_DOCTYPES";
            this.bsRows.MyDataSource = "KlonsMData";
            this.bsRows.Sort = "ID";
            this.bsRows.UseDataGridView = this.dgvRows;
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToResizeRows = false;
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.AutoSave = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcCode,
            this.dgcName,
            this.dgcID});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 0);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersVisible = false;
            this.dgvRows.RowHeadersWidth = 62;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(453, 395);
            this.dgvRows.TabIndex = 2;
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
            this.dgcCode.Width = 120;
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "NAME";
            this.dgcName.HeaderText = "nosaukums";
            this.dgcName.MinimumWidth = 8;
            this.dgcName.Name = "dgcName";
            this.dgcName.ReadOnly = true;
            this.dgcName.Width = 300;
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.MinimumWidth = 8;
            this.dgcID.Name = "dgcID";
            this.dgcID.ReadOnly = true;
            this.dgcID.Visible = false;
            this.dgcID.Width = 60;
            // 
            // FormM_DocTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 395);
            this.Controls.Add(this.dgvRows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormM_DocTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dokumentu veidi";
            this.Load += new System.EventHandler(this.FormM_DocTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsRows;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
    }
}