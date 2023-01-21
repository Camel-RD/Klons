
namespace KlonsFM.FormsM
{
    partial class FormM_RepAccCostsPerDoc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmGetData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDT2 = new KlonsLIB.Components.MyTextBox();
            this.tbDT1 = new KlonsLIB.Components.MyTextBox();
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIdStoreOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIdStoreIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAcc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAcc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmGetData);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbDT2);
            this.panel1.Controls.Add(this.tbDT1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1047, 40);
            this.panel1.TabIndex = 3;
            // 
            // cmGetData
            // 
            this.cmGetData.Location = new System.Drawing.Point(361, 4);
            this.cmGetData.Name = "cmGetData";
            this.cmGetData.Size = new System.Drawing.Size(111, 31);
            this.cmGetData.TabIndex = 3;
            this.cmGetData.Text = "Atlasīt";
            this.cmGetData.UseVisualStyleBackColor = true;
            this.cmGetData.Click += new System.EventHandler(this.cmGetData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Datums no - līdz:";
            // 
            // tbDT2
            // 
            this.tbDT2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDT2.IsDate = true;
            this.tbDT2.Location = new System.Drawing.Point(236, 6);
            this.tbDT2.Name = "tbDT2";
            this.tbDT2.Size = new System.Drawing.Size(90, 26);
            this.tbDT2.TabIndex = 1;
            // 
            // tbDT1
            // 
            this.tbDT1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDT1.IsDate = true;
            this.tbDT1.Location = new System.Drawing.Point(136, 6);
            this.tbDT1.Name = "tbDT1";
            this.tbDT1.Size = new System.Drawing.Size(90, 26);
            this.tbDT1.TabIndex = 0;
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AllowUserToResizeRows = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDt,
            this.dgcSr,
            this.dgcNr,
            this.dgcTP,
            this.dgcIdStoreOut,
            this.dgcIdStoreIn,
            this.dgcAcc1,
            this.dgcAcc2,
            this.dgcCost});
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 40);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersWidth = 30;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(1047, 410);
            this.dgvRows.TabIndex = 4;
            this.dgvRows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRows_CellFormatting);
            // 
            // dgcDt
            // 
            this.dgcDt.DataPropertyName = "DT";
            this.dgcDt.HeaderText = "datums";
            this.dgcDt.MinimumWidth = 8;
            this.dgcDt.Name = "dgcDt";
            this.dgcDt.ReadOnly = true;
            this.dgcDt.Width = 90;
            // 
            // dgcSr
            // 
            this.dgcSr.DataPropertyName = "SR";
            this.dgcSr.HeaderText = "sr.";
            this.dgcSr.MinimumWidth = 8;
            this.dgcSr.Name = "dgcSr";
            this.dgcSr.ReadOnly = true;
            this.dgcSr.Width = 55;
            // 
            // dgcNr
            // 
            this.dgcNr.DataPropertyName = "NR";
            this.dgcNr.HeaderText = "numurs";
            this.dgcNr.MinimumWidth = 8;
            this.dgcNr.Name = "dgcNr";
            this.dgcNr.ReadOnly = true;
            this.dgcNr.Width = 90;
            // 
            // dgcTP
            // 
            this.dgcTP.DataPropertyName = "TP";
            this.dgcTP.HeaderText = "veids";
            this.dgcTP.MinimumWidth = 8;
            this.dgcTP.Name = "dgcTP";
            this.dgcTP.ReadOnly = true;
            this.dgcTP.Width = 120;
            // 
            // dgcIdStoreOut
            // 
            this.dgcIdStoreOut.DataPropertyName = "IDSTOREOUT";
            this.dgcIdStoreOut.HeaderText = "izsniedzējs";
            this.dgcIdStoreOut.MinimumWidth = 8;
            this.dgcIdStoreOut.Name = "dgcIdStoreOut";
            this.dgcIdStoreOut.ReadOnly = true;
            this.dgcIdStoreOut.Width = 160;
            // 
            // dgcIdStoreIn
            // 
            this.dgcIdStoreIn.DataPropertyName = "IDSTOREIN";
            this.dgcIdStoreIn.HeaderText = "saņēmējs";
            this.dgcIdStoreIn.MinimumWidth = 8;
            this.dgcIdStoreIn.Name = "dgcIdStoreIn";
            this.dgcIdStoreIn.ReadOnly = true;
            this.dgcIdStoreIn.Width = 160;
            // 
            // dgcAcc1
            // 
            this.dgcAcc1.DataPropertyName = "ACC1";
            this.dgcAcc1.HeaderText = "debets";
            this.dgcAcc1.MinimumWidth = 8;
            this.dgcAcc1.Name = "dgcAcc1";
            this.dgcAcc1.ReadOnly = true;
            this.dgcAcc1.Width = 90;
            // 
            // dgcAcc2
            // 
            this.dgcAcc2.DataPropertyName = "ACC2";
            this.dgcAcc2.HeaderText = "kredīts";
            this.dgcAcc2.MinimumWidth = 8;
            this.dgcAcc2.Name = "dgcAcc2";
            this.dgcAcc2.ReadOnly = true;
            this.dgcAcc2.Width = 90;
            // 
            // dgcCost
            // 
            this.dgcCost.DataPropertyName = "COST";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.dgcCost.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcCost.HeaderText = "summa";
            this.dgcCost.MinimumWidth = 8;
            this.dgcCost.Name = "dgcCost";
            this.dgcCost.ReadOnly = true;
            this.dgcCost.Width = 120;
            // 
            // FormM_RepAccCostsPerDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 450);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.panel1);
            this.Name = "FormM_RepAccCostsPerDoc";
            this.Text = "Realizācijas pašizmaksas kontējumu kopsavilkums pa dokumentiem";
            this.Load += new System.EventHandler(this.FormM_RepAccCosts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmGetData;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyTextBox tbDT2;
        private KlonsLIB.Components.MyTextBox tbDT1;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIdStoreOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIdStoreIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAcc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAcc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCost;
    }
}