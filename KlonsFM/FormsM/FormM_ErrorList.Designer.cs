
namespace KlonsFM.FormsM
{
    partial class FormM_ErrorList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormM_ErrorList));
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.bsRows = new System.Windows.Forms.BindingSource(this.components);
            this.dgcSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.AutoSave = false;
            this.dgvRows.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcSource,
            this.dgcMessage});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 0);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersVisible = false;
            this.dgvRows.RowHeadersWidth = 62;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(837, 365);
            this.dgvRows.TabIndex = 0;
            // 
            // dgcSource
            // 
            this.dgcSource.DataPropertyName = "Source";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcSource.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcSource.HeaderText = "kļūdas avots";
            this.dgcSource.MinimumWidth = 8;
            this.dgcSource.Name = "dgcSource";
            this.dgcSource.ReadOnly = true;
            this.dgcSource.Width = 300;
            // 
            // dgcMessage
            // 
            this.dgcMessage.DataPropertyName = "Message";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcMessage.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcMessage.HeaderText = "paziņojums";
            this.dgcMessage.MinimumWidth = 8;
            this.dgcMessage.Name = "dgcMessage";
            this.dgcMessage.ReadOnly = true;
            this.dgcMessage.Width = 500;
            // 
            // FormM_ErrorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 365);
            this.Controls.Add(this.dgvRows);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormM_ErrorList";
            this.ShowIcon = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kļūdas paziņojumi";
            this.Load += new System.EventHandler(this.FormM_ErrorList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.BindingSource bsRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcMessage;
    }
}