
namespace KlonsA.Forms
{
    partial class Form_Persons_Egr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Persons_Egr));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bsRows = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmLoadFromFile = new System.Windows.Forms.Button();
            this.tbDate2 = new KlonsLIB.Components.MyTextBox();
            this.tbDate1 = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcHasIt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcApgSk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPapAtv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPensijas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcEDSHasIt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcEDSApgSk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcEDSPapAtv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcEDSPensijas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).BeginInit();
            this.bNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.SuspendLayout();
            // 
            // bNav
            // 
            this.bNav.AddNewItem = null;
            this.bNav.BindingSource = this.bsRows;
            this.bNav.CountItem = this.bindingNavigatorCountItem;
            this.bNav.CountItemFormat = " no {0}";
            this.bNav.DeleteItem = null;
            this.bNav.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bNav.ImageScalingSize = new System.Drawing.Size(23, 26);
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
            this.bNav.Location = new System.Drawing.Point(0, 413);
            this.bNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bNav.Name = "bNav";
            this.bNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bNav.SaveItem = null;
            this.bNav.Size = new System.Drawing.Size(1019, 37);
            this.bNav.TabIndex = 3;
            this.bNav.Text = "myBindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 32);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 32);
            this.bindingNavigatorMoveFirstItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 32);
            this.bindingNavigatorMovePreviousItem.Text = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 37);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(56, 37);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Pašreizējā pozīcija";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 32);
            this.bindingNavigatorMoveNextItem.Text = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 32);
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmLoadFromFile);
            this.panel1.Controls.Add(this.tbDate2);
            this.panel1.Controls.Add(this.tbDate1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1019, 39);
            this.panel1.TabIndex = 4;
            // 
            // cmLoadFromFile
            // 
            this.cmLoadFromFile.Location = new System.Drawing.Point(334, 2);
            this.cmLoadFromFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmLoadFromFile.Name = "cmLoadFromFile";
            this.cmLoadFromFile.Size = new System.Drawing.Size(145, 32);
            this.cmLoadFromFile.TabIndex = 3;
            this.cmLoadFromFile.Text = "Ielādēt no faila";
            this.cmLoadFromFile.UseVisualStyleBackColor = true;
            this.cmLoadFromFile.Click += new System.EventHandler(this.cmLoadFromFile_Click);
            // 
            // tbDate2
            // 
            this.tbDate2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate2.IsDate = true;
            this.tbDate2.Location = new System.Drawing.Point(190, 6);
            this.tbDate2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDate2.Name = "tbDate2";
            this.tbDate2.Size = new System.Drawing.Size(101, 26);
            this.tbDate2.TabIndex = 2;
            // 
            // tbDate1
            // 
            this.tbDate1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate1.IsDate = true;
            this.tbDate1.Location = new System.Drawing.Point(82, 6);
            this.tbDate1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDate1.Name = "tbDate1";
            this.tbDate1.Size = new System.Drawing.Size(101, 26);
            this.tbDate1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periods:";
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AllowUserToResizeRows = false;
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcName,
            this.dgcPK,
            this.dgcDate,
            this.dgcHasIt,
            this.dgcApgSk,
            this.dgcPapAtv,
            this.dgcPensijas,
            this.dgcEDSHasIt,
            this.dgcEDSApgSk,
            this.dgcEDSPapAtv,
            this.dgcEDSPensijas});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 39);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersWidth = 62;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(1019, 374);
            this.dgvRows.TabIndex = 5;
            this.dgvRows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRows_CellFormatting);
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "Name";
            this.dgcName.HeaderText = "darbinieks";
            this.dgcName.MinimumWidth = 8;
            this.dgcName.Name = "dgcName";
            this.dgcName.ReadOnly = true;
            this.dgcName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcName.Width = 180;
            // 
            // dgcPK
            // 
            this.dgcPK.DataPropertyName = "PersonsCode";
            this.dgcPK.HeaderText = "personas kods";
            this.dgcPK.MinimumWidth = 8;
            this.dgcPK.Name = "dgcPK";
            this.dgcPK.ReadOnly = true;
            this.dgcPK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcPK.Width = 120;
            // 
            // dgcDate
            // 
            this.dgcDate.DataPropertyName = "Dt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "dd.MM.yyyy";
            this.dgcDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcDate.HeaderText = "datums";
            this.dgcDate.MinimumWidth = 8;
            this.dgcDate.Name = "dgcDate";
            this.dgcDate.ReadOnly = true;
            this.dgcDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDate.Width = 101;
            // 
            // dgcHasIt
            // 
            this.dgcHasIt.DataPropertyName = "DB_HasIt";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcHasIt.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcHasIt.HeaderText = "Ir gr.";
            this.dgcHasIt.MinimumWidth = 8;
            this.dgcHasIt.Name = "dgcHasIt";
            this.dgcHasIt.ReadOnly = true;
            this.dgcHasIt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcHasIt.Width = 50;
            // 
            // dgcApgSk
            // 
            this.dgcApgSk.DataPropertyName = "DB_ApgadajamoSkaits";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcApgSk.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcApgSk.HeaderText = "apg. sk.";
            this.dgcApgSk.MinimumWidth = 8;
            this.dgcApgSk.Name = "dgcApgSk";
            this.dgcApgSk.ReadOnly = true;
            this.dgcApgSk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcApgSk.Width = 50;
            // 
            // dgcPapAtv
            // 
            this.dgcPapAtv.DataPropertyName = "DB_PapilduAtvieglojumaVeids";
            this.dgcPapAtv.HeaderText = "papildu atvieglojumi";
            this.dgcPapAtv.MinimumWidth = 8;
            this.dgcPapAtv.Name = "dgcPapAtv";
            this.dgcPapAtv.ReadOnly = true;
            this.dgcPapAtv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcPapAtv.Width = 200;
            // 
            // dgcPensijas
            // 
            this.dgcPensijas.DataPropertyName = "DB_PensijasVeids";
            this.dgcPensijas.HeaderText = "pensijas";
            this.dgcPensijas.MinimumWidth = 8;
            this.dgcPensijas.Name = "dgcPensijas";
            this.dgcPensijas.ReadOnly = true;
            this.dgcPensijas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcPensijas.Width = 150;
            // 
            // dgcEDSHasIt
            // 
            this.dgcEDSHasIt.DataPropertyName = "EDS_HasIt";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcEDSHasIt.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcEDSHasIt.HeaderText = "EDS ir gr.";
            this.dgcEDSHasIt.MinimumWidth = 8;
            this.dgcEDSHasIt.Name = "dgcEDSHasIt";
            this.dgcEDSHasIt.ReadOnly = true;
            this.dgcEDSHasIt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcEDSHasIt.Width = 50;
            // 
            // dgcEDSApgSk
            // 
            this.dgcEDSApgSk.DataPropertyName = "EDS_ApgadajamoSkaits";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcEDSApgSk.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcEDSApgSk.HeaderText = "EDS apg. sk.";
            this.dgcEDSApgSk.MinimumWidth = 8;
            this.dgcEDSApgSk.Name = "dgcEDSApgSk";
            this.dgcEDSApgSk.ReadOnly = true;
            this.dgcEDSApgSk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcEDSApgSk.Width = 70;
            // 
            // dgcEDSPapAtv
            // 
            this.dgcEDSPapAtv.DataPropertyName = "EDS_PapilduAtvieglojumaVeids";
            this.dgcEDSPapAtv.HeaderText = "EDS papildu atvieglojumi";
            this.dgcEDSPapAtv.MinimumWidth = 8;
            this.dgcEDSPapAtv.Name = "dgcEDSPapAtv";
            this.dgcEDSPapAtv.ReadOnly = true;
            this.dgcEDSPapAtv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcEDSPapAtv.Width = 200;
            // 
            // dgcEDSPensijas
            // 
            this.dgcEDSPensijas.DataPropertyName = "EDS_PensijasVeids";
            this.dgcEDSPensijas.HeaderText = "EDS pensijas";
            this.dgcEDSPensijas.MinimumWidth = 8;
            this.dgcEDSPensijas.Name = "dgcEDSPensijas";
            this.dgcEDSPensijas.ReadOnly = true;
            this.dgcEDSPensijas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcEDSPensijas.Width = 150;
            // 
            // Form_PersonsR_Egr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 450);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bNav);
            this.Name = "Form_PersonsR_Egr";
            this.Text = "E-grāmatiņu izmaiņas";
            this.Load += new System.EventHandler(this.Form_PersonsR_Egr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).EndInit();
            this.bNav.ResumeLayout(false);
            this.bNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Components.MyBindingNavigator bNav;
        private System.Windows.Forms.BindingSource bsRows;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmLoadFromFile;
        private KlonsLIB.Components.MyTextBox tbDate2;
        private KlonsLIB.Components.MyTextBox tbDate1;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcHasIt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcApgSk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPapAtv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPensijas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcEDSHasIt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcEDSApgSk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcEDSPapAtv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcEDSPensijas;
    }
}