
namespace KlonsA.Forms
{
    partial class Form_PayListImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PayListImport));
            this.bsRows = new System.Windows.Forms.BindingSource(this.components);
            this.bnavRows = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIDP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsPersons = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcIDAM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsAmati = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbReadText = new System.Windows.Forms.ToolStripButton();
            this.tbMakeLists = new System.Windows.Forms.ToolStripButton();
            this.mySplitContainer1 = new KlonsLIB.Components.MySplitContainer();
            this.tbText = new KlonsLIB.Components.MyTextBox();
            this.bsAmatiF = new KlonsLIB.Data.MyBindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavRows)).BeginInit();
            this.bnavRows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mySplitContainer1)).BeginInit();
            this.mySplitContainer1.Panel1.SuspendLayout();
            this.mySplitContainer1.Panel2.SuspendLayout();
            this.mySplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmatiF)).BeginInit();
            this.SuspendLayout();
            // 
            // bnavRows
            // 
            this.bnavRows.AddNewItem = null;
            this.bnavRows.BindingSource = this.bsRows;
            this.bnavRows.CountItem = this.bindingNavigatorCountItem;
            this.bnavRows.CountItemFormat = " no {0}";
            this.bnavRows.DataGrid = this.dgvRows;
            this.bnavRows.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnavRows.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavRows.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bnavRows.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorDeleteItem,
            this.tbReadText,
            this.tbMakeLists});
            this.bnavRows.Location = new System.Drawing.Point(0, 513);
            this.bnavRows.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavRows.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavRows.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavRows.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavRows.Name = "bnavRows";
            this.bnavRows.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavRows.SaveItem = null;
            this.bnavRows.Size = new System.Drawing.Size(805, 39);
            this.bnavRows.TabIndex = 0;
            this.bnavRows.Text = "myBindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 34);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // dgvRows
            // 
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.AutoSave = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDate,
            this.dgcIDP,
            this.dgcIDAM,
            this.dgcAmount});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(10, 5);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.RowHeadersWidth = 62;
            this.dgvRows.RowTemplate.Height = 28;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(785, 283);
            this.dgvRows.TabIndex = 0;
            this.dgvRows.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvRows_CellBeginEdit);
            this.dgvRows.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRows_CellDoubleClick);
            this.dgvRows.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRows_CellEndEdit);
            this.dgvRows.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvRows_CellParsing);
            // 
            // dgcDate
            // 
            this.dgcDate.DataPropertyName = "Date";
            dataGridViewCellStyle1.Format = "dd.MM.yyyy";
            this.dgcDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcDate.HeaderText = "datums";
            this.dgcDate.MinimumWidth = 8;
            this.dgcDate.Name = "dgcDate";
            this.dgcDate.Width = 90;
            // 
            // dgcIDP
            // 
            this.dgcIDP.DataPropertyName = "IDP";
            this.dgcIDP.DataSource = this.bsPersons;
            this.dgcIDP.DisplayMember = "YNAME";
            this.dgcIDP.DisplayStyleForCurrentCellOnly = true;
            this.dgcIDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcIDP.HeaderText = "darbinieks";
            this.dgcIDP.MaxDropDownItems = 12;
            this.dgcIDP.MinimumWidth = 8;
            this.dgcIDP.Name = "dgcIDP";
            this.dgcIDP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcIDP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcIDP.ValueMember = "ID";
            this.dgcIDP.Width = 180;
            // 
            // bsPersons
            // 
            this.bsPersons.DataMember = "PERSONS";
            this.bsPersons.MyDataSource = "KlonsData";
            this.bsPersons.Sort = "ZNAME";
            // 
            // dgcIDAM
            // 
            this.dgcIDAM.DataPropertyName = "IDAM";
            this.dgcIDAM.DataSource = this.bsAmati;
            this.dgcIDAM.DisplayMember = "TITLE";
            this.dgcIDAM.DisplayStyleForCurrentCellOnly = true;
            this.dgcIDAM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcIDAM.HeaderText = "amats";
            this.dgcIDAM.MinimumWidth = 8;
            this.dgcIDAM.Name = "dgcIDAM";
            this.dgcIDAM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcIDAM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcIDAM.ValueMember = "ID";
            this.dgcIDAM.Width = 180;
            // 
            // bsAmati
            // 
            this.bsAmati.DataMember = "POSITIONS";
            this.bsAmati.MyDataSource = "KlonsData";
            // 
            // dgcAmount
            // 
            this.dgcAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dgcAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcAmount.HeaderText = "summa";
            this.dgcAmount.MinimumWidth = 8;
            this.dgcAmount.Name = "dgcAmount";
            this.dgcAmount.Width = 150;
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(94, 34);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 34);
            this.bindingNavigatorMoveFirstItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 34);
            this.bindingNavigatorMovePreviousItem.Text = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 37);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Pašreizējā pozīcija";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 34);
            this.bindingNavigatorMoveNextItem.Text = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 34);
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tbReadText
            // 
            this.tbReadText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbReadText.Image = ((System.Drawing.Image)(resources.GetObject("tbReadText.Image")));
            this.tbReadText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbReadText.Name = "tbReadText";
            this.tbReadText.Size = new System.Drawing.Size(177, 34);
            this.tbReadText.Text = "Nolasīt no teksta";
            this.tbReadText.Click += new System.EventHandler(this.tbReadText_Click);
            // 
            // tbMakeLists
            // 
            this.tbMakeLists.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbMakeLists.Image = ((System.Drawing.Image)(resources.GetObject("tbMakeLists.Image")));
            this.tbMakeLists.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbMakeLists.Name = "tbMakeLists";
            this.tbMakeLists.Size = new System.Drawing.Size(187, 34);
            this.tbMakeLists.Text = "Izveidot sarakstus";
            this.tbMakeLists.Click += new System.EventHandler(this.tbMakeLists_Click);
            // 
            // mySplitContainer1
            // 
            this.mySplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.mySplitContainer1.Name = "mySplitContainer1";
            this.mySplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mySplitContainer1.Panel1
            // 
            this.mySplitContainer1.Panel1.Controls.Add(this.tbText);
            this.mySplitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            // 
            // mySplitContainer1.Panel2
            // 
            this.mySplitContainer1.Panel2.Controls.Add(this.dgvRows);
            this.mySplitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.mySplitContainer1.Size = new System.Drawing.Size(805, 513);
            this.mySplitContainer1.SplitterDistance = 211;
            this.mySplitContainer1.TabIndex = 1;
            // 
            // tbText
            // 
            this.tbText.BorderColor = System.Drawing.SystemColors.ControlText;
            this.tbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbText.Location = new System.Drawing.Point(10, 10);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbText.Size = new System.Drawing.Size(785, 196);
            this.tbText.TabIndex = 0;
            this.tbText.WordWrap = false;
            // 
            // bsAmatiF
            // 
            this.bsAmatiF.DataMember = "POSITIONS";
            this.bsAmatiF.MyDataSource = "KlonsData";
            // 
            // Form_PayListImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 552);
            this.Controls.Add(this.mySplitContainer1);
            this.Controls.Add(this.bnavRows);
            this.Name = "Form_PayListImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Maksājumu sarakstu imports";
            this.Load += new System.EventHandler(this.Form_PayListImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavRows)).EndInit();
            this.bnavRows.ResumeLayout(false);
            this.bnavRows.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).EndInit();
            this.mySplitContainer1.Panel1.ResumeLayout(false);
            this.mySplitContainer1.Panel1.PerformLayout();
            this.mySplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mySplitContainer1)).EndInit();
            this.mySplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsAmatiF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsRows;
        private KlonsLIB.Components.MyBindingNavigator bnavRows;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tbMakeLists;
        private KlonsLIB.Components.MySplitContainer mySplitContainer1;
        private KlonsLIB.Components.MyTextBox tbText;
        private KlonsLIB.Data.MyBindingSource bsPersons;
        private KlonsLIB.Data.MyBindingSource bsAmati;
        private KlonsLIB.Data.MyBindingSource bsAmatiF;
        private System.Windows.Forms.ToolStripButton tbReadText;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcIDP;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcIDAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAmount;
    }
}