
namespace KlonsFM.FormsM
{
    partial class FormM_ItemMovement
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmGetData = new System.Windows.Forms.Button();
            this.tbCode = new KlonsLIB.Components.MyPickRowTextBox2();
            this.bsItems = new KlonsLIB.Data.MyBindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDT2 = new KlonsLIB.Components.MyTextBox();
            this.tbDT1 = new KlonsLIB.Components.MyTextBox();
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcSGtp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCodeStoreOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCodeStoreIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSaldo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSaldo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmGetData);
            this.panel1.Controls.Add(this.tbCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbDT2);
            this.panel1.Controls.Add(this.tbDT1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 40);
            this.panel1.TabIndex = 0;
            // 
            // cmGetData
            // 
            this.cmGetData.Location = new System.Drawing.Point(590, 4);
            this.cmGetData.Name = "cmGetData";
            this.cmGetData.Size = new System.Drawing.Size(111, 31);
            this.cmGetData.TabIndex = 3;
            this.cmGetData.Text = "Atlasīt";
            this.cmGetData.UseVisualStyleBackColor = true;
            this.cmGetData.Click += new System.EventHandler(this.cmGetData_Click);
            // 
            // tbCode
            // 
            this.tbCode.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbCode.DataMember = null;
            this.tbCode.DataSource = this.bsItems;
            this.tbCode.DisplayMember = "BARCODE";
            this.tbCode.Location = new System.Drawing.Point(417, 6);
            this.tbCode.Name = "tbCode";
            this.tbCode.SelectedIndex = -1;
            this.tbCode.ShowButton = true;
            this.tbCode.Size = new System.Drawing.Size(158, 26);
            this.tbCode.SyncPosition = false;
            this.tbCode.TabIndex = 2;
            this.tbCode.ValueMember = "ID";
            this.tbCode.ButtonClicked += new System.EventHandler(this.tbCode_ButtonClicked);
            this.tbCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCode_KeyDown);
            // 
            // bsItems
            // 
            this.bsItems.DataMember = "M_ITEMS";
            this.bsItems.MyDataSource = "KlonsMData";
            this.bsItems.Sort = "BARCODE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "artikuls:";
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
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcSGtp,
            this.dgcDt,
            this.dgcSr,
            this.dgcNr,
            this.dgcCodeStoreOut,
            this.dgcCodeStoreIn,
            this.dgcAmount,
            this.dgcSaldo1,
            this.dgcSaldo2});
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 40);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersWidth = 30;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(985, 410);
            this.dgvRows.TabIndex = 1;
            this.dgvRows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRows_CellFormatting);
            // 
            // dgcSGtp
            // 
            this.dgcSGtp.DataPropertyName = "SGtp";
            this.dgcSGtp.HeaderText = "veids";
            this.dgcSGtp.MinimumWidth = 8;
            this.dgcSGtp.Name = "dgcSGtp";
            this.dgcSGtp.ReadOnly = true;
            this.dgcSGtp.Width = 90;
            // 
            // dgcDt
            // 
            this.dgcDt.DataPropertyName = "Dt";
            dataGridViewCellStyle1.Format = "dd.MM.yyyy";
            this.dgcDt.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcDt.HeaderText = "datums";
            this.dgcDt.MinimumWidth = 8;
            this.dgcDt.Name = "dgcDt";
            this.dgcDt.ReadOnly = true;
            this.dgcDt.Width = 90;
            // 
            // dgcSr
            // 
            this.dgcSr.DataPropertyName = "Sr";
            this.dgcSr.HeaderText = "sr.";
            this.dgcSr.MinimumWidth = 8;
            this.dgcSr.Name = "dgcSr";
            this.dgcSr.ReadOnly = true;
            this.dgcSr.Width = 50;
            // 
            // dgcNr
            // 
            this.dgcNr.DataPropertyName = "Nr";
            this.dgcNr.HeaderText = "numurs";
            this.dgcNr.MinimumWidth = 8;
            this.dgcNr.Name = "dgcNr";
            this.dgcNr.ReadOnly = true;
            this.dgcNr.Width = 95;
            // 
            // dgcCodeStoreOut
            // 
            this.dgcCodeStoreOut.DataPropertyName = "CodeStoreOut";
            this.dgcCodeStoreOut.HeaderText = "izsniedzējs";
            this.dgcCodeStoreOut.MinimumWidth = 8;
            this.dgcCodeStoreOut.Name = "dgcCodeStoreOut";
            this.dgcCodeStoreOut.ReadOnly = true;
            this.dgcCodeStoreOut.Width = 160;
            // 
            // dgcCodeStoreIn
            // 
            this.dgcCodeStoreIn.DataPropertyName = "CodeStoreIn";
            this.dgcCodeStoreIn.HeaderText = "saņēmējs";
            this.dgcCodeStoreIn.MinimumWidth = 8;
            this.dgcCodeStoreIn.Name = "dgcCodeStoreIn";
            this.dgcCodeStoreIn.ReadOnly = true;
            this.dgcCodeStoreIn.Width = 160;
            // 
            // dgcAmount
            // 
            this.dgcAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcAmount.HeaderText = "daudzums";
            this.dgcAmount.MinimumWidth = 8;
            this.dgcAmount.Name = "dgcAmount";
            this.dgcAmount.ReadOnly = true;
            this.dgcAmount.Width = 90;
            // 
            // dgcSaldo1
            // 
            this.dgcSaldo1.DataPropertyName = "Saldo1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcSaldo1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcSaldo1.HeaderText = "izsniedzēja atlikums";
            this.dgcSaldo1.MinimumWidth = 8;
            this.dgcSaldo1.Name = "dgcSaldo1";
            this.dgcSaldo1.ReadOnly = true;
            this.dgcSaldo1.Width = 90;
            // 
            // dgcSaldo2
            // 
            this.dgcSaldo2.DataPropertyName = "Saldo2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcSaldo2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcSaldo2.HeaderText = "saņēmēja atlikums";
            this.dgcSaldo2.MinimumWidth = 8;
            this.dgcSaldo2.Name = "dgcSaldo2";
            this.dgcSaldo2.ReadOnly = true;
            this.dgcSaldo2.Width = 90;
            // 
            // FormM_ItemMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 450);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.panel1);
            this.Name = "FormM_ItemMovement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artikula kustības pārskats";
            this.Load += new System.EventHandler(this.FormM_ItemMovement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyTextBox tbDT2;
        private KlonsLIB.Components.MyTextBox tbDT1;
        private KlonsLIB.Data.MyBindingSource bsItems;
        private System.Windows.Forms.Button cmGetData;
        private KlonsLIB.Components.MyPickRowTextBox2 tbCode;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSGtp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCodeStoreOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCodeStoreIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSaldo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSaldo2;
    }
}