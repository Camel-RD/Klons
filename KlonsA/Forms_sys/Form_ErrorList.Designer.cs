namespace KlonsA.Forms
{
    partial class Form_ErrorList
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
            this.bsErr = new System.Windows.Forms.BindingSource(this.components);
            this.dgvErrorList = new KlonsLIB.Components.MyDataGridView();
            this.dgcSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvErrorList
            // 
            this.dgvErrorList.AllowUserToAddRows = false;
            this.dgvErrorList.AllowUserToDeleteRows = false;
            this.dgvErrorList.AllowUserToOrderColumns = true;
            this.dgvErrorList.AutoGenerateColumns = false;
            this.dgvErrorList.AutoSave = false;
            this.dgvErrorList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvErrorList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvErrorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcSource,
            this.dgcMessage});
            this.dgvErrorList.DataSource = this.bsErr;
            this.dgvErrorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErrorList.Location = new System.Drawing.Point(0, 0);
            this.dgvErrorList.Name = "dgvErrorList";
            this.dgvErrorList.ReadOnly = true;
            this.dgvErrorList.RowTemplate.Height = 24;
            this.dgvErrorList.Size = new System.Drawing.Size(635, 297);
            this.dgvErrorList.TabIndex = 0;
            // 
            // dgcSource
            // 
            this.dgcSource.DataPropertyName = "Source";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcSource.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcSource.HeaderText = "kļūdas avots";
            this.dgcSource.MinimumWidth = 100;
            this.dgcSource.Name = "dgcSource";
            this.dgcSource.ReadOnly = true;
            this.dgcSource.Width = 150;
            // 
            // dgcMessage
            // 
            this.dgcMessage.DataPropertyName = "Message";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcMessage.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcMessage.HeaderText = "kļūdas paziņojums";
            this.dgcMessage.MinimumWidth = 200;
            this.dgcMessage.Name = "dgcMessage";
            this.dgcMessage.ReadOnly = true;
            this.dgcMessage.Width = 300;
            // 
            // Form_ErrorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 297);
            this.Controls.Add(this.dgvErrorList);
            this.Name = "Form_ErrorList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kļūdas paziņojumi";
            ((System.ComponentModel.ISupportInitialize)(this.bsErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsErr;
        private KlonsLIB.Components.MyDataGridView dgvErrorList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcMessage;
    }
}