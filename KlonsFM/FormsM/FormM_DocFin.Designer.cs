
namespace KlonsFM.FormsM
{
    partial class FormM_DocFin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsRepByPVNRate = new System.Windows.Forms.BindingSource(this.components);
            this.dgvRepByPVNRate = new KlonsLIB.Components.MyDataGridView();
            this.dgcPVNPVNRateId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPVNRateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPVNRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPVNIsReverse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPVNBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPVNPvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPVNTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcReversePVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAccRows = new System.Windows.Forms.BindingSource(this.components);
            this.dgvAcc = new KlonsLIB.Components.MyDataGridView();
            this.dgcAccDebFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAccDebPVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAccCredFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAccCredPVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAccAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.admFinDoc = new KlonsLIB.Data.MyAdapterManager();
            this.admStore = new KlonsLIB.Data.MyAdapterManager();
            this.btMakeFinDoc = new System.Windows.Forms.Button();
            this.btDeleteFinDoc = new System.Windows.Forms.Button();
            this.btCustomFinDoc = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsRepByPVNRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepByPVNRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.admFinDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.admStore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRepByPVNRate
            // 
            this.dgvRepByPVNRate.AllowUserToAddRows = false;
            this.dgvRepByPVNRate.AllowUserToDeleteRows = false;
            this.dgvRepByPVNRate.AutoGenerateColumns = false;
            this.dgvRepByPVNRate.AutoSave = false;
            this.dgvRepByPVNRate.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRepByPVNRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepByPVNRate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcPVNPVNRateId,
            this.dgcPVNRateName,
            this.dgcPVNRate,
            this.dgcPVNIsReverse,
            this.dgcPVNBase,
            this.dgcPVNPvn,
            this.dgcPVNTotal,
            this.dgcReversePVN});
            this.dgvRepByPVNRate.DataSource = this.bsRepByPVNRate;
            this.dgvRepByPVNRate.Location = new System.Drawing.Point(1, 9);
            this.dgvRepByPVNRate.Name = "dgvRepByPVNRate";
            this.dgvRepByPVNRate.ReadOnly = true;
            this.dgvRepByPVNRate.RowHeadersVisible = false;
            this.dgvRepByPVNRate.RowHeadersWidth = 62;
            this.dgvRepByPVNRate.RowTemplate.Height = 28;
            this.dgvRepByPVNRate.ShowCellToolTips = false;
            this.dgvRepByPVNRate.Size = new System.Drawing.Size(846, 211);
            this.dgvRepByPVNRate.TabIndex = 0;
            // 
            // dgcPVNPVNRateId
            // 
            this.dgcPVNPVNRateId.DataPropertyName = "PVNRateId";
            this.dgcPVNPVNRateId.HeaderText = "likmes kods";
            this.dgcPVNPVNRateId.MinimumWidth = 8;
            this.dgcPVNPVNRateId.Name = "dgcPVNPVNRateId";
            this.dgcPVNPVNRateId.ReadOnly = true;
            this.dgcPVNPVNRateId.Width = 90;
            // 
            // dgcPVNRateName
            // 
            this.dgcPVNRateName.DataPropertyName = "PVNRateName";
            this.dgcPVNRateName.HeaderText = "nosaukums";
            this.dgcPVNRateName.MinimumWidth = 8;
            this.dgcPVNRateName.Name = "dgcPVNRateName";
            this.dgcPVNRateName.ReadOnly = true;
            this.dgcPVNRateName.Width = 160;
            // 
            // dgcPVNRate
            // 
            this.dgcPVNRate.DataPropertyName = "PVNRate";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.Format = "0;0;\"\"";
            this.dgcPVNRate.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgcPVNRate.HeaderText = "likme";
            this.dgcPVNRate.MinimumWidth = 8;
            this.dgcPVNRate.Name = "dgcPVNRate";
            this.dgcPVNRate.ReadOnly = true;
            this.dgcPVNRate.Width = 60;
            // 
            // dgcPVNIsReverse
            // 
            this.dgcPVNIsReverse.DataPropertyName = "SIsReversePVN";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcPVNIsReverse.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgcPVNIsReverse.HeaderText = "reversais";
            this.dgcPVNIsReverse.MinimumWidth = 8;
            this.dgcPVNIsReverse.Name = "dgcPVNIsReverse";
            this.dgcPVNIsReverse.ReadOnly = true;
            this.dgcPVNIsReverse.Width = 90;
            // 
            // dgcPVNBase
            // 
            this.dgcPVNBase.DataPropertyName = "PVNBaze";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.Format = "N2";
            this.dgcPVNBase.DefaultCellStyle = dataGridViewCellStyle24;
            this.dgcPVNBase.HeaderText = "bāze";
            this.dgcPVNBase.MinimumWidth = 8;
            this.dgcPVNBase.Name = "dgcPVNBase";
            this.dgcPVNBase.ReadOnly = true;
            this.dgcPVNBase.Width = 101;
            // 
            // dgcPVNPvn
            // 
            this.dgcPVNPvn.DataPropertyName = "PVN";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle25.Format = "N2";
            this.dgcPVNPvn.DefaultCellStyle = dataGridViewCellStyle25;
            this.dgcPVNPvn.HeaderText = "PVN";
            this.dgcPVNPvn.MinimumWidth = 8;
            this.dgcPVNPvn.Name = "dgcPVNPvn";
            this.dgcPVNPvn.ReadOnly = true;
            this.dgcPVNPvn.Width = 101;
            // 
            // dgcPVNTotal
            // 
            this.dgcPVNTotal.DataPropertyName = "Total";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle26.Format = "N2";
            this.dgcPVNTotal.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgcPVNTotal.HeaderText = "kopā";
            this.dgcPVNTotal.MinimumWidth = 8;
            this.dgcPVNTotal.Name = "dgcPVNTotal";
            this.dgcPVNTotal.ReadOnly = true;
            this.dgcPVNTotal.Width = 101;
            // 
            // dgcReversePVN
            // 
            this.dgcReversePVN.DataPropertyName = "ReversePVN";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle27.Format = "N2;N2;\"\"";
            this.dgcReversePVN.DefaultCellStyle = dataGridViewCellStyle27;
            this.dgcReversePVN.HeaderText = "revers PVN";
            this.dgcReversePVN.MinimumWidth = 8;
            this.dgcReversePVN.Name = "dgcReversePVN";
            this.dgcReversePVN.ReadOnly = true;
            this.dgcReversePVN.Width = 101;
            // 
            // dgvAcc
            // 
            this.dgvAcc.AllowUserToAddRows = false;
            this.dgvAcc.AllowUserToDeleteRows = false;
            this.dgvAcc.AutoGenerateColumns = false;
            this.dgvAcc.AutoSave = false;
            this.dgvAcc.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcAccDebFin,
            this.dgcAccDebPVN,
            this.dgcAccCredFin,
            this.dgcAccCredPVN,
            this.dgcAccAmount});
            this.dgvAcc.DataSource = this.bsAccRows;
            this.dgvAcc.Location = new System.Drawing.Point(1, 239);
            this.dgvAcc.Name = "dgvAcc";
            this.dgvAcc.ReadOnly = true;
            this.dgvAcc.RowHeadersVisible = false;
            this.dgvAcc.RowHeadersWidth = 62;
            this.dgvAcc.RowTemplate.Height = 28;
            this.dgvAcc.ShowCellToolTips = false;
            this.dgvAcc.Size = new System.Drawing.Size(525, 205);
            this.dgvAcc.TabIndex = 1;
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
            // dgcAccDebPVN
            // 
            this.dgcAccDebPVN.DataPropertyName = "DebPVN";
            this.dgcAccDebPVN.HeaderText = "deb. PVN";
            this.dgcAccDebPVN.MinimumWidth = 8;
            this.dgcAccDebPVN.Name = "dgcAccDebPVN";
            this.dgcAccDebPVN.ReadOnly = true;
            this.dgcAccDebPVN.Width = 90;
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
            // dgcAccCredPVN
            // 
            this.dgcAccCredPVN.DataPropertyName = "CredPVN";
            this.dgcAccCredPVN.HeaderText = "kred. PVN";
            this.dgcAccCredPVN.MinimumWidth = 8;
            this.dgcAccCredPVN.Name = "dgcAccCredPVN";
            this.dgcAccCredPVN.ReadOnly = true;
            this.dgcAccCredPVN.Width = 90;
            // 
            // dgcAccAmount
            // 
            this.dgcAccAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle28.Format = "N2";
            this.dgcAccAmount.DefaultCellStyle = dataGridViewCellStyle28;
            this.dgcAccAmount.HeaderText = "summa";
            this.dgcAccAmount.MinimumWidth = 8;
            this.dgcAccAmount.Name = "dgcAccAmount";
            this.dgcAccAmount.ReadOnly = true;
            this.dgcAccAmount.Width = 120;
            // 
            // admFinDoc
            // 
            this.admFinDoc.MyDataSource = "KlonsData";
            this.admFinDoc.TableNames = new string[] {
        "OPSd",
        "OPS",
        null};
            // 
            // admStore
            // 
            this.admStore.MyDataSource = "KlonsMData";
            this.admStore.TableNames = new string[] {
        "M_DOCS",
        "M_ROWS",
        null};
            // 
            // btMakeFinDoc
            // 
            this.btMakeFinDoc.Location = new System.Drawing.Point(543, 231);
            this.btMakeFinDoc.Name = "btMakeFinDoc";
            this.btMakeFinDoc.Size = new System.Drawing.Size(182, 45);
            this.btMakeFinDoc.TabIndex = 5;
            this.btMakeFinDoc.Text = "Izveidot kontējumu";
            this.btMakeFinDoc.UseVisualStyleBackColor = true;
            this.btMakeFinDoc.Click += new System.EventHandler(this.btMakeFinDoc_Click);
            // 
            // btDeleteFinDoc
            // 
            this.btDeleteFinDoc.Location = new System.Drawing.Point(543, 282);
            this.btDeleteFinDoc.Name = "btDeleteFinDoc";
            this.btDeleteFinDoc.Size = new System.Drawing.Size(182, 55);
            this.btDeleteFinDoc.TabIndex = 5;
            this.btDeleteFinDoc.Text = "Dzēst izveidoto kentējumu";
            this.btDeleteFinDoc.UseVisualStyleBackColor = true;
            this.btDeleteFinDoc.Click += new System.EventHandler(this.btDeleteFinDoc_Click);
            // 
            // btCustomFinDoc
            // 
            this.btCustomFinDoc.Location = new System.Drawing.Point(543, 343);
            this.btCustomFinDoc.Name = "btCustomFinDoc";
            this.btCustomFinDoc.Size = new System.Drawing.Size(182, 55);
            this.btCustomFinDoc.TabIndex = 5;
            this.btCustomFinDoc.Text = "Dokuments kontēts ar citu kontējumu";
            this.btCustomFinDoc.UseVisualStyleBackColor = true;
            this.btCustomFinDoc.Click += new System.EventHandler(this.btCustomFinDoc_Click);
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(543, 404);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(182, 45);
            this.btClose.TabIndex = 5;
            this.btClose.Text = "Aizvērt";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // FormM_DocFin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 456);
            this.Controls.Add(this.btCustomFinDoc);
            this.Controls.Add(this.btDeleteFinDoc);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btMakeFinDoc);
            this.Controls.Add(this.dgvAcc);
            this.Controls.Add(this.dgvRepByPVNRate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormM_DocFin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dokumenta kontējums";
            this.Load += new System.EventHandler(this.FormM_DocFin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsRepByPVNRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepByPVNRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.admFinDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.admStore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsRepByPVNRate;
        private KlonsLIB.Components.MyDataGridView dgvRepByPVNRate;
        private System.Windows.Forms.BindingSource bsAccRows;
        private KlonsLIB.Components.MyDataGridView dgvAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccDebFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccDebPVN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccCredFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccCredPVN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccAmount;
        private KlonsLIB.Data.MyAdapterManager admFinDoc;
        private KlonsLIB.Data.MyAdapterManager admStore;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPVNPVNRateId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPVNRateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPVNRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPVNIsReverse;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPVNBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPVNPvn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPVNTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcReversePVN;
        private System.Windows.Forms.Button btMakeFinDoc;
        private System.Windows.Forms.Button btDeleteFinDoc;
        private System.Windows.Forms.Button btCustomFinDoc;
        private System.Windows.Forms.Button btClose;
    }
}