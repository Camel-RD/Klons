
namespace KlonsFM.FormsM
{
    partial class FormM_StoreCurrentStock
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbItemsCatFilter = new KlonsLIB.Components.MyPickRowTextBox2();
            this.bsItemsCatFilter = new KlonsLIB.Data.MyBindingSource(this.components);
            this.tbFilter = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcItemKat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lbStoreName = new System.Windows.Forms.ToolStripLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItemsCatFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbItemsCatFilter);
            this.panel1.Controls.Add(this.tbFilter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 38);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "kategorija:";
            // 
            // tbItemsCatFilter
            // 
            this.tbItemsCatFilter.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbItemsCatFilter.DataMember = null;
            this.tbItemsCatFilter.DataSource = this.bsItemsCatFilter;
            this.tbItemsCatFilter.DisplayMember = "CODE";
            this.tbItemsCatFilter.Location = new System.Drawing.Point(100, 6);
            this.tbItemsCatFilter.Name = "tbItemsCatFilter";
            this.tbItemsCatFilter.SelectedIndex = -1;
            this.tbItemsCatFilter.ShowButton = true;
            this.tbItemsCatFilter.Size = new System.Drawing.Size(191, 26);
            this.tbItemsCatFilter.SyncPosition = false;
            this.tbItemsCatFilter.TabIndex = 5;
            this.tbItemsCatFilter.ValueMember = "ID";
            this.tbItemsCatFilter.SelectedIndexChanged += new System.EventHandler(this.tbItemsCatFilter_SelectedIndexChanged);
            this.tbItemsCatFilter.ButtonClicked += new System.EventHandler(this.tbItemsCatFilter_ButtonClicked);
            this.tbItemsCatFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbItemsCatFilter_KeyDown);
            // 
            // bsItemsCatFilter
            // 
            this.bsItemsCatFilter.DataMember = "M_ITEMS_CAT";
            this.bsItemsCatFilter.MyDataSource = "KlonsMData";
            this.bsItemsCatFilter.Sort = "CODE";
            // 
            // tbFilter
            // 
            this.tbFilter.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbFilter.Location = new System.Drawing.Point(376, 6);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(140, 26);
            this.tbFilter.TabIndex = 2;
            this.tbFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFilter_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(315, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "atlasīt:";
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AllowUserToResizeRows = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcItemCode,
            this.dgcItemName,
            this.dgcItemKat,
            this.dgcAmount});
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 38);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersVisible = false;
            this.dgvRows.RowHeadersWidth = 62;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(921, 377);
            this.dgvRows.TabIndex = 1;
            // 
            // dgcItemCode
            // 
            this.dgcItemCode.DataPropertyName = "ItemCode";
            this.dgcItemCode.HeaderText = "kods";
            this.dgcItemCode.MinimumWidth = 8;
            this.dgcItemCode.Name = "dgcItemCode";
            this.dgcItemCode.ReadOnly = true;
            this.dgcItemCode.Width = 160;
            // 
            // dgcItemName
            // 
            this.dgcItemName.DataPropertyName = "ItemName";
            this.dgcItemName.HeaderText = "nosaukums";
            this.dgcItemName.MinimumWidth = 8;
            this.dgcItemName.Name = "dgcItemName";
            this.dgcItemName.ReadOnly = true;
            this.dgcItemName.Width = 300;
            // 
            // dgcItemKat
            // 
            this.dgcItemKat.DataPropertyName = "ItemCategory";
            this.dgcItemKat.HeaderText = "kategorija";
            this.dgcItemKat.MinimumWidth = 8;
            this.dgcItemKat.Name = "dgcItemKat";
            this.dgcItemKat.ReadOnly = true;
            this.dgcItemKat.Width = 140;
            // 
            // dgcAmount
            // 
            this.dgcAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcAmount.HeaderText = "daudzums";
            this.dgcAmount.MinimumWidth = 8;
            this.dgcAmount.Name = "dgcAmount";
            this.dgcAmount.ReadOnly = true;
            this.dgcAmount.Width = 90;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStoreName});
            this.toolStrip1.Location = new System.Drawing.Point(0, 415);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(921, 35);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lbStoreName
            // 
            this.lbStoreName.Name = "lbStoreName";
            this.lbStoreName.Size = new System.Drawing.Size(28, 30);
            this.lbStoreName.Text = "...";
            // 
            // FormM_StoreCurrentStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 450);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormM_StoreCurrentStock";
            this.Text = "Aktuālais noliktavas atlikums";
            this.Load += new System.EventHandler(this.FormM_StoreCurrentStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItemsCatFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private KlonsLIB.Components.MyTextBox tbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcItemKat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAmount;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lbStoreName;
        private KlonsLIB.Data.MyBindingSource bsItemsCatFilter;
        private System.Windows.Forms.Label label2;
        private KlonsLIB.Components.MyPickRowTextBox2 tbItemsCatFilter;
    }
}