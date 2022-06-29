using KlonsLIB.Components;

namespace KlonsF.Forms
{
    partial class Form_Export
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
            this.bsCount = new System.Windows.Forms.BindingSource(this.components);
            this.dgvCount = new KlonsLIB.Components.MyDataGridView();
            this.dgcCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chOnlyUsed = new MyCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).BeginInit();
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
            this.dgcCount});
            this.dgvCount.DataSource = this.bsCount;
            this.dgvCount.Location = new System.Drawing.Point(5, 8);
            this.dgvCount.Name = "dgvCount";
            this.dgvCount.ReadOnly = true;
            this.dgvCount.RowHeadersVisible = false;
            this.dgvCount.RowTemplate.Height = 24;
            this.dgvCount.Size = new System.Drawing.Size(267, 238);
            this.dgvCount.TabIndex = 0;
            // 
            // dgcCaption
            // 
            this.dgcCaption.DataPropertyName = "Caption";
            this.dgcCaption.HeaderText = "Ieraksta veids";
            this.dgcCaption.Name = "dgcCaption";
            this.dgcCaption.ReadOnly = true;
            this.dgcCaption.Width = 200;
            // 
            // dgcCount
            // 
            this.dgcCount.DataPropertyName = "Count";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcCount.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcCount.HeaderText = "Skaits";
            this.dgcCount.Name = "dgcCount";
            this.dgcCount.ReadOnly = true;
            this.dgcCount.Width = 50;
            // 
            // cmExport
            // 
            this.cmExport.Location = new System.Drawing.Point(330, 62);
            this.cmExport.Name = "cmExport";
            this.cmExport.Size = new System.Drawing.Size(116, 35);
            this.cmExport.TabIndex = 1;
            this.cmExport.Text = "Eksportēt";
            this.cmExport.UseVisualStyleBackColor = true;
            this.cmExport.Click += new System.EventHandler(this.cmExport_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(280, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tiks eksportēti dokumentu sarakstā atlasītie dokumenti";
            // 
            // chOnlyUsed
            // 
            this.chOnlyUsed.AutoSize = true;
            this.chOnlyUsed.Checked = true;
            this.chOnlyUsed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chOnlyUsed.Location = new System.Drawing.Point(283, 26);
            this.chOnlyUsed.Name = "chOnlyUsed";
            this.chOnlyUsed.Size = new System.Drawing.Size(163, 20);
            this.chOnlyUsed.TabIndex = 3;
            this.chOnlyUsed.Text = "Tikai izmantotos datus";
            this.chOnlyUsed.UseVisualStyleBackColor = true;
            this.chOnlyUsed.CheckedChanged += new System.EventHandler(this.chOnlyUsed_CheckedChanged);
            // 
            // Form_Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 254);
            this.Controls.Add(this.chOnlyUsed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmExport);
            this.Controls.Add(this.dgvCount);
            this.Name = "Form_Export";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datu eksports";
            this.Load += new System.EventHandler(this.Form_Export_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsCount;
        private KlonsLIB.Components.MyDataGridView dgvCount;
        private System.Windows.Forms.Button cmExport;
        private System.Windows.Forms.Label label1;
        private MyCheckBox chOnlyUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCount;
    }
}