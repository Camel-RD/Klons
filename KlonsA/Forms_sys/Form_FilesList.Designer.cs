using KlonsLIB.Components;

namespace KlonsA.Forms
{
    partial class Form_FilesList
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
            this.dgvFiles = new KlonsLIB.Components.MyDataGridView();
            this.dgcFilesDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcFilesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcFilesConnStr = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcFilesFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFiles = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFiles
            // 
            this.dgvFiles.AutoGenerateColumns = false;
            this.dgvFiles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcFilesDescr,
            this.dgcFilesName,
            this.dgcFilesConnStr,
            this.dgcFilesFileName,
            this.dgcFilePath});
            this.dgvFiles.DataSource = this.bsFiles;
            this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiles.Location = new System.Drawing.Point(0, 0);
            this.dgvFiles.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.Size = new System.Drawing.Size(823, 293);
            this.dgvFiles.TabIndex = 0;
            this.dgvFiles.MyCheckForChanges += new System.EventHandler(this.dgvFiles_MyCheckForChanges);
            this.dgvFiles.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvFiles_RowValidating);
            // 
            // dgcFilesDescr
            // 
            this.dgcFilesDescr.DataPropertyName = "name";
            this.dgcFilesDescr.HeaderText = "kods";
            this.dgcFilesDescr.Name = "dgcFilesDescr";
            this.dgcFilesDescr.ToolTipText = "datubāzes  kods";
            this.dgcFilesDescr.Width = 120;
            // 
            // dgcFilesName
            // 
            this.dgcFilesName.DataPropertyName = "descr";
            this.dgcFilesName.HeaderText = "apraksts";
            this.dgcFilesName.Name = "dgcFilesName";
            this.dgcFilesName.ToolTipText = "datubāzes apraksts";
            this.dgcFilesName.Width = 240;
            // 
            // dgcFilesConnStr
            // 
            this.dgcFilesConnStr.ColumnNames = new string[] {
        "col1"};
            this.dgcFilesConnStr.DataPropertyName = "ConnStr";
            this.dgcFilesConnStr.DisplayMember = "col1";
            this.dgcFilesConnStr.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.dgcFilesConnStr.HeaderText = "pieslēgums";
            this.dgcFilesConnStr.ItemStrings = new string[] {
        "FBEmbeded",
        "FBServer"};
            this.dgcFilesConnStr.MaxDropDownItems = 15;
            this.dgcFilesConnStr.Name = "dgcFilesConnStr";
            this.dgcFilesConnStr.ValueMember = "col1";
            this.dgcFilesConnStr.Width = 96;
            // 
            // dgcFilesFileName
            // 
            this.dgcFilesFileName.DataPropertyName = "FileName";
            this.dgcFilesFileName.HeaderText = "fails";
            this.dgcFilesFileName.Name = "dgcFilesFileName";
            this.dgcFilesFileName.Width = 120;
            // 
            // dgcFilePath
            // 
            this.dgcFilePath.DataPropertyName = "Path";
            this.dgcFilePath.HeaderText = "mape";
            this.dgcFilePath.Name = "dgcFilePath";
            this.dgcFilePath.Width = 160;
            // 
            // bsFiles
            // 
            this.bsFiles.Sort = "name";
            // 
            // Form_FilesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 293);
            this.Controls.Add(this.dgvFiles);
            this.Name = "Form_FilesList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Saraksts ar datu bāzēm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFiles2_FormClosed);
            this.Load += new System.EventHandler(this.FormFiles2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyDataGridView dgvFiles;
        private System.Windows.Forms.BindingSource bsFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFilesDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFilesName;
        private MyDgvMcCBColumn dgcFilesConnStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFilesFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFilePath;
    }
}