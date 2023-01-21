
namespace KlonsFM.FormsM
{
    partial class FormM_RepItemLinks
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmGetData = new System.Windows.Forms.Button();
            this.tbCode = new KlonsLIB.Components.MyPickRowTextBox2();
            this.bsItems = new KlonsLIB.Data.MyBindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDT2 = new KlonsLIB.Components.MyTextBox();
            this.tbDT1 = new KlonsLIB.Components.MyTextBox();
            this.bsRows = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcADT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcASr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcANr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcATp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAIdStoreOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAIdStoreIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcABouPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBSr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBTp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBIdStoreOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBIdStoreIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAmountLinked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAIDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBIDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1221, 40);
            this.panel1.TabIndex = 1;
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
            // bsRows
            // 
            this.bsRows.DataMember = "SP_M_REP_ITEMLINKS_1";
            this.bsRows.MyDataSource = "KlonsMRep";
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.AutoSave = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcADT,
            this.dgcASr,
            this.dgcANr,
            this.dgcATp,
            this.dgcAIdStoreOut,
            this.dgcAIdStoreIn,
            this.dgcAAmount,
            this.dgcABouPrice,
            this.dgcBDt,
            this.dgcBSr,
            this.dgcBNr,
            this.dgcBTp,
            this.dgcBIdStoreOut,
            this.dgcBIdStoreIn,
            this.dgcBAmount,
            this.dgcBBuyPrice,
            this.dgcAmountLinked,
            this.dgcAIDD,
            this.dgcAIDR,
            this.dgcBIDD,
            this.dgcBIDR});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 40);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersWidth = 30;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(1221, 410);
            this.dgvRows.TabIndex = 2;
            this.dgvRows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRows_CellFormatting);
            // 
            // dgcADT
            // 
            this.dgcADT.DataPropertyName = "ADT";
            dataGridViewCellStyle1.Format = "dd.MM.yyyy";
            this.dgcADT.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcADT.HeaderText = "datums";
            this.dgcADT.MinimumWidth = 8;
            this.dgcADT.Name = "dgcADT";
            this.dgcADT.ReadOnly = true;
            this.dgcADT.Width = 90;
            // 
            // dgcASr
            // 
            this.dgcASr.DataPropertyName = "ASR";
            this.dgcASr.HeaderText = "sr";
            this.dgcASr.MinimumWidth = 8;
            this.dgcASr.Name = "dgcASr";
            this.dgcASr.ReadOnly = true;
            this.dgcASr.Width = 50;
            // 
            // dgcANr
            // 
            this.dgcANr.DataPropertyName = "ANR";
            this.dgcANr.HeaderText = "numurs";
            this.dgcANr.MinimumWidth = 8;
            this.dgcANr.Name = "dgcANr";
            this.dgcANr.ReadOnly = true;
            this.dgcANr.Width = 95;
            // 
            // dgcATp
            // 
            this.dgcATp.DataPropertyName = "ATP";
            this.dgcATp.HeaderText = "veids";
            this.dgcATp.MinimumWidth = 8;
            this.dgcATp.Name = "dgcATp";
            this.dgcATp.ReadOnly = true;
            this.dgcATp.Width = 120;
            // 
            // dgcAIdStoreOut
            // 
            this.dgcAIdStoreOut.DataPropertyName = "AIDSTOREOUT";
            this.dgcAIdStoreOut.HeaderText = "izsniedzējs";
            this.dgcAIdStoreOut.MinimumWidth = 8;
            this.dgcAIdStoreOut.Name = "dgcAIdStoreOut";
            this.dgcAIdStoreOut.ReadOnly = true;
            this.dgcAIdStoreOut.Width = 160;
            // 
            // dgcAIdStoreIn
            // 
            this.dgcAIdStoreIn.DataPropertyName = "AIDSTOREIN";
            this.dgcAIdStoreIn.HeaderText = "saņēmējs";
            this.dgcAIdStoreIn.MinimumWidth = 8;
            this.dgcAIdStoreIn.Name = "dgcAIdStoreIn";
            this.dgcAIdStoreIn.ReadOnly = true;
            this.dgcAIdStoreIn.Width = 160;
            // 
            // dgcAAmount
            // 
            this.dgcAAmount.DataPropertyName = "AAMOUNT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcAAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcAAmount.HeaderText = "daudzums";
            this.dgcAAmount.MinimumWidth = 8;
            this.dgcAAmount.Name = "dgcAAmount";
            this.dgcAAmount.ReadOnly = true;
            this.dgcAAmount.Width = 90;
            // 
            // dgcABouPrice
            // 
            this.dgcABouPrice.DataPropertyName = "ABUYPRICE";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcABouPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcABouPrice.HeaderText = "cena";
            this.dgcABouPrice.MinimumWidth = 8;
            this.dgcABouPrice.Name = "dgcABouPrice";
            this.dgcABouPrice.ReadOnly = true;
            this.dgcABouPrice.Width = 150;
            // 
            // dgcBDt
            // 
            this.dgcBDt.DataPropertyName = "BDT";
            dataGridViewCellStyle4.Format = "dd.MM.yyyy";
            this.dgcBDt.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcBDt.HeaderText = "datums";
            this.dgcBDt.MinimumWidth = 8;
            this.dgcBDt.Name = "dgcBDt";
            this.dgcBDt.ReadOnly = true;
            this.dgcBDt.Width = 90;
            // 
            // dgcBSr
            // 
            this.dgcBSr.DataPropertyName = "BSR";
            this.dgcBSr.HeaderText = "sr";
            this.dgcBSr.MinimumWidth = 8;
            this.dgcBSr.Name = "dgcBSr";
            this.dgcBSr.ReadOnly = true;
            this.dgcBSr.Width = 50;
            // 
            // dgcBNr
            // 
            this.dgcBNr.DataPropertyName = "BNR";
            this.dgcBNr.HeaderText = "numurs";
            this.dgcBNr.MinimumWidth = 8;
            this.dgcBNr.Name = "dgcBNr";
            this.dgcBNr.ReadOnly = true;
            this.dgcBNr.Width = 90;
            // 
            // dgcBTp
            // 
            this.dgcBTp.DataPropertyName = "BTP";
            this.dgcBTp.HeaderText = "veids";
            this.dgcBTp.MinimumWidth = 8;
            this.dgcBTp.Name = "dgcBTp";
            this.dgcBTp.ReadOnly = true;
            this.dgcBTp.Width = 120;
            // 
            // dgcBIdStoreOut
            // 
            this.dgcBIdStoreOut.DataPropertyName = "BIDSTOREOUT";
            this.dgcBIdStoreOut.HeaderText = "izsniedzējs";
            this.dgcBIdStoreOut.MinimumWidth = 8;
            this.dgcBIdStoreOut.Name = "dgcBIdStoreOut";
            this.dgcBIdStoreOut.ReadOnly = true;
            this.dgcBIdStoreOut.Width = 160;
            // 
            // dgcBIdStoreIn
            // 
            this.dgcBIdStoreIn.DataPropertyName = "BIDSTOREIN";
            this.dgcBIdStoreIn.HeaderText = "saņēmējs";
            this.dgcBIdStoreIn.MinimumWidth = 8;
            this.dgcBIdStoreIn.Name = "dgcBIdStoreIn";
            this.dgcBIdStoreIn.ReadOnly = true;
            this.dgcBIdStoreIn.Width = 160;
            // 
            // dgcBAmount
            // 
            this.dgcBAmount.DataPropertyName = "BAMOUNT";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcBAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcBAmount.HeaderText = "daudzums";
            this.dgcBAmount.MinimumWidth = 8;
            this.dgcBAmount.Name = "dgcBAmount";
            this.dgcBAmount.ReadOnly = true;
            this.dgcBAmount.Width = 90;
            // 
            // dgcBBuyPrice
            // 
            this.dgcBBuyPrice.DataPropertyName = "BBUYPRICE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcBBuyPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcBBuyPrice.HeaderText = "cena";
            this.dgcBBuyPrice.MinimumWidth = 8;
            this.dgcBBuyPrice.Name = "dgcBBuyPrice";
            this.dgcBBuyPrice.ReadOnly = true;
            this.dgcBBuyPrice.Width = 90;
            // 
            // dgcAmountLinked
            // 
            this.dgcAmountLinked.DataPropertyName = "AMOUNTLINKED";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcAmountLinked.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcAmountLinked.HeaderText = "izmantots";
            this.dgcAmountLinked.MinimumWidth = 8;
            this.dgcAmountLinked.Name = "dgcAmountLinked";
            this.dgcAmountLinked.ReadOnly = true;
            this.dgcAmountLinked.Width = 95;
            // 
            // dgcAIDD
            // 
            this.dgcAIDD.DataPropertyName = "AIDD";
            this.dgcAIDD.HeaderText = "AIDD";
            this.dgcAIDD.MinimumWidth = 8;
            this.dgcAIDD.Name = "dgcAIDD";
            this.dgcAIDD.ReadOnly = true;
            this.dgcAIDD.Visible = false;
            this.dgcAIDD.Width = 150;
            // 
            // dgcAIDR
            // 
            this.dgcAIDR.DataPropertyName = "AIDR";
            this.dgcAIDR.HeaderText = "AIDR";
            this.dgcAIDR.MinimumWidth = 8;
            this.dgcAIDR.Name = "dgcAIDR";
            this.dgcAIDR.ReadOnly = true;
            this.dgcAIDR.Visible = false;
            this.dgcAIDR.Width = 150;
            // 
            // dgcBIDD
            // 
            this.dgcBIDD.DataPropertyName = "BIDD";
            this.dgcBIDD.HeaderText = "BIDD";
            this.dgcBIDD.MinimumWidth = 8;
            this.dgcBIDD.Name = "dgcBIDD";
            this.dgcBIDD.ReadOnly = true;
            this.dgcBIDD.Visible = false;
            this.dgcBIDD.Width = 150;
            // 
            // dgcBIDR
            // 
            this.dgcBIDR.DataPropertyName = "BIDR";
            this.dgcBIDR.HeaderText = "BIDR";
            this.dgcBIDR.MinimumWidth = 8;
            this.dgcBIDR.Name = "dgcBIDR";
            this.dgcBIDR.ReadOnly = true;
            this.dgcBIDR.Visible = false;
            this.dgcBIDR.Width = 150;
            // 
            // FormM_RepItemLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 450);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.panel1);
            this.Name = "FormM_RepItemLinks";
            this.Text = "Izmantojuma pārskats";
            this.Load += new System.EventHandler(this.FormM_RepItemLinks_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmGetData;
        private KlonsLIB.Components.MyPickRowTextBox2 tbCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyTextBox tbDT2;
        private KlonsLIB.Components.MyTextBox tbDT1;
        private KlonsLIB.Data.MyBindingSource bsRows;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private KlonsLIB.Data.MyBindingSource bsItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcADT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcASr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcANr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcATp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAIdStoreOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAIdStoreIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcABouPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBSr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBTp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBIdStoreOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBIdStoreIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAmountLinked;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAIDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBIDR;
    }
}