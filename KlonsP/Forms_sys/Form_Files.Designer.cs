using KlonsLIB.Components;

namespace KlonsP.Forms
{
    partial class Form_Files
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
            this.cmSelect = new System.Windows.Forms.Button();
            this.cmEditList = new System.Windows.Forms.Button();
            this.cmCancel = new System.Windows.Forms.Button();
            this.dgvFiles = new KlonsLIB.Components.MyDataGridView();
            this.bsFiles = new System.Windows.Forms.BindingSource(this.components);
            this.cmNew = new System.Windows.Forms.Button();
            this.cmDelete = new System.Windows.Forms.Button();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // cmSelect
            // 
            this.cmSelect.Location = new System.Drawing.Point(493, 5);
            this.cmSelect.Name = "cmSelect";
            this.cmSelect.Size = new System.Drawing.Size(94, 31);
            this.cmSelect.TabIndex = 1;
            this.cmSelect.Text = "Pieslēgties";
            this.cmSelect.UseVisualStyleBackColor = true;
            this.cmSelect.Click += new System.EventHandler(this.cmSelect_Click);
            // 
            // cmEditList
            // 
            this.cmEditList.Location = new System.Drawing.Point(493, 128);
            this.cmEditList.Name = "cmEditList";
            this.cmEditList.Size = new System.Drawing.Size(94, 47);
            this.cmEditList.TabIndex = 4;
            this.cmEditList.Text = "Rediģēt sarakstu";
            this.cmEditList.UseVisualStyleBackColor = true;
            this.cmEditList.Click += new System.EventHandler(this.cmEditList_Click);
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(493, 192);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(94, 31);
            this.cmCancel.TabIndex = 5;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFiles.AutoGenerateColumns = false;
            this.dgvFiles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFiles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcName,
            this.dgcDescr});
            this.dgvFiles.DataSource = this.bsFiles;
            this.dgvFiles.Location = new System.Drawing.Point(2, 2);
            this.dgvFiles.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFiles.MultiSelect = false;
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.RowTemplate.ReadOnly = true;
            this.dgvFiles.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(486, 230);
            this.dgvFiles.TabIndex = 0;
            this.dgvFiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellDoubleClick);
            // 
            // bsFiles
            // 
            this.bsFiles.AllowNew = false;
            this.bsFiles.Sort = "Name";
            // 
            // cmNew
            // 
            this.cmNew.Location = new System.Drawing.Point(493, 42);
            this.cmNew.Name = "cmNew";
            this.cmNew.Size = new System.Drawing.Size(94, 47);
            this.cmNew.TabIndex = 2;
            this.cmNew.Text = "Izveidot jaunu";
            this.cmNew.UseVisualStyleBackColor = true;
            this.cmNew.Click += new System.EventHandler(this.cmNew_Click);
            // 
            // cmDelete
            // 
            this.cmDelete.Location = new System.Drawing.Point(493, 95);
            this.cmDelete.Name = "cmDelete";
            this.cmDelete.Size = new System.Drawing.Size(94, 27);
            this.cmDelete.TabIndex = 3;
            this.cmDelete.Text = "Dzēst";
            this.cmDelete.UseVisualStyleBackColor = true;
            this.cmDelete.Click += new System.EventHandler(this.cmDelete_Click);
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "name";
            this.dgcName.HeaderText = "kods";
            this.dgcName.Name = "dgcName";
            this.dgcName.ReadOnly = true;
            this.dgcName.Width = 130;
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "descr";
            this.dgcDescr.HeaderText = "apraksts";
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.ReadOnly = true;
            this.dgcDescr.Width = 320;
            // 
            // Form_Files
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(592, 238);
            this.CloseOnEscape = true;
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.cmDelete);
            this.Controls.Add(this.cmNew);
            this.Controls.Add(this.cmEditList);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmSelect);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Files";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nomainīt datubāzi";
            this.Load += new System.EventHandler(this.FormFiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmSelect;
        private System.Windows.Forms.Button cmEditList;
        private System.Windows.Forms.Button cmCancel;
        private MyDataGridView dgvFiles;
        private System.Windows.Forms.BindingSource bsFiles;
        private System.Windows.Forms.Button cmNew;
        private System.Windows.Forms.Button cmDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescr;
    }
}