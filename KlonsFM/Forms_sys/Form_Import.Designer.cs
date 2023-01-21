namespace KlonsFM.Forms
{
    partial class Form_Import
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsCount = new System.Windows.Forms.BindingSource(this.components);
            this.dgvCount = new KlonsLIB.Components.MyDataGridView();
            this.dgcCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCountNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCountExisting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCountChanging = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCountBad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTask = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmImport = new System.Windows.Forms.Button();
            this.chSkipDocs = new System.Windows.Forms.CheckBox();
            this.tbFileName = new KlonsLIB.Components.MyTextBox();
            this.btGetFile = new System.Windows.Forms.Button();
            this.cmShowErrors = new System.Windows.Forms.Button();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.bsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCount
            // 
            this.dgvCount.AllowUserToAddRows = false;
            this.dgvCount.AllowUserToDeleteRows = false;
            this.dgvCount.AllowUserToResizeRows = false;
            this.dgvCount.AutoGenerateColumns = false;
            this.dgvCount.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcCaption,
            this.dgcCount,
            this.dgcCountNew,
            this.dgcCountExisting,
            this.dgcCountChanging,
            this.dgcCountBad,
            this.dgcTask});
            this.dgvCount.DataSource = this.bsCount;
            this.dgvCount.Location = new System.Drawing.Point(1, 31);
            this.dgvCount.Name = "dgvCount";
            this.dgvCount.RowHeadersVisible = false;
            this.dgvCount.RowTemplate.Height = 24;
            this.dgvCount.Size = new System.Drawing.Size(620, 251);
            this.dgvCount.TabIndex = 0;
            this.dgvCount.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCount_CellBeginEdit);
            // 
            // dgcCaption
            // 
            this.dgcCaption.DataPropertyName = "SheetName";
            this.dgcCaption.HeaderText = "Ieraksta veids";
            this.dgcCaption.Name = "dgcCaption";
            this.dgcCaption.ReadOnly = true;
            this.dgcCaption.Width = 200;
            // 
            // dgcCount
            // 
            this.dgcCount.DataPropertyName = "RowCount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcCount.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcCount.HeaderText = "Skaits";
            this.dgcCount.Name = "dgcCount";
            this.dgcCount.ReadOnly = true;
            this.dgcCount.Width = 50;
            // 
            // dgcCountNew
            // 
            this.dgcCountNew.DataPropertyName = "RowCountNew";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcCountNew.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcCountNew.HeaderText = "Jauni";
            this.dgcCountNew.Name = "dgcCountNew";
            this.dgcCountNew.ReadOnly = true;
            this.dgcCountNew.Width = 50;
            // 
            // dgcCountExisting
            // 
            this.dgcCountExisting.DataPropertyName = "RowCountExisting";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcCountExisting.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcCountExisting.HeaderText = "Esoši";
            this.dgcCountExisting.Name = "dgcCountExisting";
            this.dgcCountExisting.ReadOnly = true;
            this.dgcCountExisting.Width = 50;
            // 
            // dgcCountChanging
            // 
            this.dgcCountChanging.DataPropertyName = "RowCountChanging";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcCountChanging.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcCountChanging.HeaderText = "Maināmi";
            this.dgcCountChanging.Name = "dgcCountChanging";
            this.dgcCountChanging.ReadOnly = true;
            this.dgcCountChanging.Width = 70;
            // 
            // dgcCountBad
            // 
            this.dgcCountBad.DataPropertyName = "RowCountBad";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcCountBad.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcCountBad.HeaderText = "Kļūdaini";
            this.dgcCountBad.Name = "dgcCountBad";
            this.dgcCountBad.ReadOnly = true;
            this.dgcCountBad.Width = 70;
            // 
            // dgcTask
            // 
            this.dgcTask.DataPropertyName = "Task";
            this.dgcTask.DisplayStyleForCurrentCellOnly = true;
            this.dgcTask.HeaderText = "Importēt";
            this.dgcTask.Name = "dgcTask";
            this.dgcTask.Width = 80;
            // 
            // cmImport
            // 
            this.cmImport.Location = new System.Drawing.Point(505, 288);
            this.cmImport.Name = "cmImport";
            this.cmImport.Size = new System.Drawing.Size(116, 35);
            this.cmImport.TabIndex = 1;
            this.cmImport.Text = "Importēt";
            this.cmImport.UseVisualStyleBackColor = true;
            this.cmImport.Click += new System.EventHandler(this.cmImport_Click);
            // 
            // chSkipDocs
            // 
            this.chSkipDocs.AutoSize = true;
            this.chSkipDocs.Location = new System.Drawing.Point(5, 296);
            this.chSkipDocs.Name = "chSkipDocs";
            this.chSkipDocs.Size = new System.Drawing.Size(172, 20);
            this.chSkipDocs.TabIndex = 3;
            this.chSkipDocs.Text = "Neimportēt dokumentus";
            this.chSkipDocs.UseVisualStyleBackColor = true;
            this.chSkipDocs.CheckedChanged += new System.EventHandler(this.chSkipDocs_CheckedChanged);
            // 
            // tbFileName
            // 
            this.tbFileName.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbFileName.Location = new System.Drawing.Point(1, 3);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(518, 22);
            this.tbFileName.TabIndex = 4;
            // 
            // btGetFile
            // 
            this.btGetFile.Location = new System.Drawing.Point(525, 0);
            this.btGetFile.Name = "btGetFile";
            this.btGetFile.Size = new System.Drawing.Size(96, 27);
            this.btGetFile.TabIndex = 5;
            this.btGetFile.Text = "Norādīt failu";
            this.btGetFile.UseVisualStyleBackColor = true;
            this.btGetFile.Click += new System.EventHandler(this.btGetFile_Click);
            // 
            // cmShowErrors
            // 
            this.cmShowErrors.Location = new System.Drawing.Point(366, 288);
            this.cmShowErrors.Name = "cmShowErrors";
            this.cmShowErrors.Size = new System.Drawing.Size(116, 35);
            this.cmShowErrors.TabIndex = 1;
            this.cmShowErrors.Text = "Rādīt kļūdas";
            this.cmShowErrors.UseVisualStyleBackColor = true;
            this.cmShowErrors.Click += new System.EventHandler(this.cmShowErrors_Click);
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "AcP21",
        "Acp23",
        "AcP24",
        "Acp25",
        "Currency",
        "DocTyp",
        "OPS",
        "OPSd",
        "Persons",
        null};
            // 
            // Form_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 327);
            this.Controls.Add(this.btGetFile);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.chSkipDocs);
            this.Controls.Add(this.cmShowErrors);
            this.Controls.Add(this.cmImport);
            this.Controls.Add(this.dgvCount);
            this.Name = "Form_Import";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datu imports";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Import_FormClosed);
            this.Load += new System.EventHandler(this.Form_Import_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsCount;
        private KlonsLIB.Components.MyDataGridView dgvCount;
        private System.Windows.Forms.Button cmImport;
        private System.Windows.Forms.CheckBox chSkipDocs;
        private KlonsLIB.Components.MyTextBox tbFileName;
        private System.Windows.Forms.Button btGetFile;
        private System.Windows.Forms.Button cmShowErrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCountNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCountExisting;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCountChanging;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCountBad;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcTask;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
    }
}