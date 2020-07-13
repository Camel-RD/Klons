namespace KlonsA.Forms
{
    partial class Form_UntaxedMinimumImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_UntaxedMinimumImport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsRows = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmUpdateDB = new System.Windows.Forms.Button();
            this.cmLoadFromFile = new System.Windows.Forms.Button();
            this.tbDate2 = new KlonsLIB.Components.MyTextBox();
            this.tbDate1 = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUntMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIINRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).BeginInit();
            this.bNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmUpdateDB);
            this.panel1.Controls.Add(this.cmLoadFromFile);
            this.panel1.Controls.Add(this.tbDate2);
            this.panel1.Controls.Add(this.tbDate1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 31);
            this.panel1.TabIndex = 0;
            // 
            // cmUpdateDB
            // 
            this.cmUpdateDB.Location = new System.Drawing.Point(448, 1);
            this.cmUpdateDB.Name = "cmUpdateDB";
            this.cmUpdateDB.Size = new System.Drawing.Size(113, 26);
            this.cmUpdateDB.TabIndex = 4;
            this.cmUpdateDB.Text = "Iegrāmatot";
            this.cmUpdateDB.UseVisualStyleBackColor = true;
            this.cmUpdateDB.Click += new System.EventHandler(this.cmUpdateDB_Click);
            // 
            // cmLoadFromFile
            // 
            this.cmLoadFromFile.Location = new System.Drawing.Point(297, 2);
            this.cmLoadFromFile.Name = "cmLoadFromFile";
            this.cmLoadFromFile.Size = new System.Drawing.Size(129, 26);
            this.cmLoadFromFile.TabIndex = 3;
            this.cmLoadFromFile.Text = "Ielādēt no faila";
            this.cmLoadFromFile.UseVisualStyleBackColor = true;
            this.cmLoadFromFile.Click += new System.EventHandler(this.cmLoadFromFile_Click);
            // 
            // tbDate2
            // 
            this.tbDate2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate2.IsDate = true;
            this.tbDate2.Location = new System.Drawing.Point(169, 5);
            this.tbDate2.Name = "tbDate2";
            this.tbDate2.Size = new System.Drawing.Size(90, 22);
            this.tbDate2.TabIndex = 2;
            // 
            // tbDate1
            // 
            this.tbDate1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate1.IsDate = true;
            this.tbDate1.Location = new System.Drawing.Point(73, 5);
            this.tbDate1.Name = "tbDate1";
            this.tbDate1.Size = new System.Drawing.Size(90, 22);
            this.tbDate1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periods:";
            // 
            // bNav
            // 
            this.bNav.AddNewItem = null;
            this.bNav.BindingSource = this.bsRows;
            this.bNav.CountItem = this.bindingNavigatorCountItem;
            this.bNav.CountItemFormat = " no {0}";
            this.bNav.DeleteItem = null;
            this.bNav.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bNav.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bNav.Location = new System.Drawing.Point(0, 420);
            this.bNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bNav.Name = "bNav";
            this.bNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bNav.SaveItem = null;
            this.bNav.Size = new System.Drawing.Size(718, 30);
            this.bNav.TabIndex = 2;
            this.bNav.Text = "myBindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(69, 26);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(30, 26);
            this.bindingNavigatorMoveFirstItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(30, 26);
            this.bindingNavigatorMovePreviousItem.Text = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 30);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Pašreizējā pozīcija";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(30, 26);
            this.bindingNavigatorMoveNextItem.Text = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(30, 26);
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcName,
            this.dgcCode,
            this.dgcDate,
            this.dgcUntMin,
            this.dgcIINRate});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 31);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersWidth = 53;
            this.dgvRows.RowTemplate.Height = 24;
            this.dgvRows.Size = new System.Drawing.Size(718, 389);
            this.dgvRows.TabIndex = 1;
            this.dgvRows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRows_CellFormatting);
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "Name";
            this.dgcName.HeaderText = "darbinieks";
            this.dgcName.MinimumWidth = 7;
            this.dgcName.Name = "dgcName";
            this.dgcName.ReadOnly = true;
            this.dgcName.Width = 180;
            // 
            // dgcCode
            // 
            this.dgcCode.DataPropertyName = "PersonsCode";
            this.dgcCode.HeaderText = "pers. kods";
            this.dgcCode.MinimumWidth = 7;
            this.dgcCode.Name = "dgcCode";
            this.dgcCode.ReadOnly = true;
            this.dgcCode.ToolTipText = "Personas kods";
            this.dgcCode.Width = 130;
            // 
            // dgcDate
            // 
            this.dgcDate.DataPropertyName = "Dt";
            dataGridViewCellStyle1.Format = "dd.MM.yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.dgcDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcDate.HeaderText = "datums";
            this.dgcDate.MinimumWidth = 7;
            this.dgcDate.Name = "dgcDate";
            this.dgcDate.ReadOnly = true;
            // 
            // dgcUntMin
            // 
            this.dgcUntMin.DataPropertyName = "UntMin";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dgcUntMin.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcUntMin.HeaderText = "neapl. min.";
            this.dgcUntMin.MinimumWidth = 7;
            this.dgcUntMin.Name = "dgcUntMin";
            this.dgcUntMin.ReadOnly = true;
            this.dgcUntMin.ToolTipText = "Neapliekamais minimums";
            this.dgcUntMin.Width = 110;
            // 
            // dgcIINRate
            // 
            this.dgcIINRate.DataPropertyName = "IINRateType";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcIINRate.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcIINRate.HeaderText = "IIN lime";
            this.dgcIINRate.MinimumWidth = 7;
            this.dgcIINRate.Name = "dgcIINRate";
            this.dgcIINRate.ReadOnly = true;
            this.dgcIINRate.Width = 90;
            // 
            // Form_UntaxedMinimumImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 450);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.bNav);
            this.Controls.Add(this.panel1);
            this.Name = "Form_UntaxedMinimumImport";
            this.Text = "Datu imports";
            this.Load += new System.EventHandler(this.Form_UntaxedMinimumImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).EndInit();
            this.bNav.ResumeLayout(false);
            this.bNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsRows;
        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Components.MyTextBox tbDate2;
        private KlonsLIB.Components.MyTextBox tbDate1;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyBindingNavigator bNav;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.Button cmLoadFromFile;
        private System.Windows.Forms.Button cmUpdateDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUntMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIINRate;
    }
}