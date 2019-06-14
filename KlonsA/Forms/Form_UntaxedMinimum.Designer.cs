namespace KlonsA.Forms
{
    partial class Form_UntaxedMinimum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_UntaxedMinimum));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmFilter = new System.Windows.Forms.Button();
            this.cbPerson = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsFilterPerson = new KlonsLIB.Data.MyBindingSource(this.components);
            this.tbDate2 = new KlonsLIB.Components.MyTextBox();
            this.tbDate1 = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bsRows = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcOnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIDP = new KlonsLIB.Components.MyDgvMcComboBoxColumn();
            this.bsPerson = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcUntaxedMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIINRateType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bniAdd = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bniDelete = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bniSave = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFilterPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).BeginInit();
            this.bNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmFilter);
            this.panel1.Controls.Add(this.cbPerson);
            this.panel1.Controls.Add(this.tbDate2);
            this.panel1.Controls.Add(this.tbDate1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 31);
            this.panel1.TabIndex = 0;
            // 
            // cmFilter
            // 
            this.cmFilter.Location = new System.Drawing.Point(637, 4);
            this.cmFilter.Name = "cmFilter";
            this.cmFilter.Size = new System.Drawing.Size(75, 23);
            this.cmFilter.TabIndex = 5;
            this.cmFilter.Text = "Filtrēt";
            this.cmFilter.UseVisualStyleBackColor = true;
            this.cmFilter.Click += new System.EventHandler(this.cmFilter_Click);
            // 
            // cbPerson
            // 
            this.cbPerson.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbPerson.ColumnNames = new string[] {
        "FNAME",
        "LNAME",
        "PK"};
            this.cbPerson.ColumnWidths = "100;100;100";
            this.cbPerson.DataSource = this.bsFilterPerson;
            this.cbPerson.DisplayMember = "YNAME";
            this.cbPerson.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPerson.DropDownHeight = 255;
            this.cbPerson.DropDownWidth = 324;
            this.cbPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPerson.FormattingEnabled = true;
            this.cbPerson.GridLineColor = System.Drawing.Color.LightGray;
            this.cbPerson.GridLineHorizontal = false;
            this.cbPerson.GridLineVertical = false;
            this.cbPerson.IntegralHeight = false;
            this.cbPerson.Location = new System.Drawing.Point(372, 4);
            this.cbPerson.MaxDropDownItems = 15;
            this.cbPerson.Name = "cbPerson";
            this.cbPerson.Size = new System.Drawing.Size(257, 23);
            this.cbPerson.TabIndex = 4;
            this.cbPerson.ValueMember = "ID";
            // 
            // bsFilterPerson
            // 
            this.bsFilterPerson.DataMember = "PERSONS";
            this.bsFilterPerson.MyDataSource = "KlonsData";
            this.bsFilterPerson.Sort = "YNAME";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "darbinieks:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datums:";
            // 
            // bsRows
            // 
            this.bsRows.AutoSaveOnDelete = true;
            this.bsRows.DataMember = "UNTAXED_MIN";
            this.bsRows.MyDataSource = "KlonsData";
            this.bsRows.Sort = "ONDATE";
            this.bsRows.UseDataGridView = this.dgvRows;
            this.bsRows.MyBeforeRowInsert += new KlonsLIB.Data.MyRowUpdateEventHandler(this.bsRows_MyBeforeRowInsert);
            this.bsRows.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsRows_ListChanged);
            // 
            // dgvRows
            // 
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcOnDate,
            this.dgcIDP,
            this.dgcUntaxedMin,
            this.dgcIINRateType,
            this.dgcID});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 31);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.RowHeadersWidth = 53;
            this.dgvRows.RowTemplate.Height = 24;
            this.dgvRows.Size = new System.Drawing.Size(732, 316);
            this.dgvRows.TabIndex = 1;
            this.dgvRows.MyCheckForChanges += new System.EventHandler(this.dgvRows_MyCheckForChanges);
            this.dgvRows.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvRows_CellParsing);
            this.dgvRows.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvRows_DefaultValuesNeeded);
            this.dgvRows.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvRows_UserDeletingRow);
            this.dgvRows.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRows_KeyDown);
            // 
            // dgcOnDate
            // 
            this.dgcOnDate.DataPropertyName = "ONDATE";
            dataGridViewCellStyle1.Format = "dd.MM.yyyy";
            this.dgcOnDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcOnDate.HeaderText = "datums";
            this.dgcOnDate.MinimumWidth = 7;
            this.dgcOnDate.Name = "dgcOnDate";
            this.dgcOnDate.Width = 90;
            // 
            // dgcIDP
            // 
            this.dgcIDP.ColumnNames = new string[] {
        "FNAME",
        "LNAME",
        "PK"};
            this.dgcIDP.ColumnWidths = "100;100;100";
            this.dgcIDP.DataPropertyName = "IDP";
            this.dgcIDP.DataSource = this.bsPerson;
            this.dgcIDP.DisplayMember = "YNAME";
            this.dgcIDP.DisplayStyleForCurrentCellOnly = true;
            this.dgcIDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcIDP.HeaderText = "darbinieks";
            this.dgcIDP.MaxDropDownItems = 15;
            this.dgcIDP.MinimumWidth = 7;
            this.dgcIDP.Name = "dgcIDP";
            this.dgcIDP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcIDP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcIDP.ValueMember = "ID";
            this.dgcIDP.Width = 300;
            // 
            // bsPerson
            // 
            this.bsPerson.DataMember = "PERSONS";
            this.bsPerson.Filter = "USED=1";
            this.bsPerson.MyDataSource = "KlonsData";
            this.bsPerson.Sort = "YNAME";
            // 
            // dgcUntaxedMin
            // 
            this.dgcUntaxedMin.DataPropertyName = "UNTAXED_MIN";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dgcUntaxedMin.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcUntaxedMin.HeaderText = "summa";
            this.dgcUntaxedMin.MinimumWidth = 7;
            this.dgcUntaxedMin.Name = "dgcUntaxedMin";
            this.dgcUntaxedMin.Width = 130;
            // 
            // dgcIINRateType
            // 
            this.dgcIINRateType.DataPropertyName = "IIN_RATE_TYPE";
            this.dgcIINRateType.DisplayStyleForCurrentCellOnly = true;
            this.dgcIINRateType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcIINRateType.HeaderText = "likme";
            this.dgcIINRateType.MinimumWidth = 7;
            this.dgcIINRateType.Name = "dgcIINRateType";
            this.dgcIINRateType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcIINRateType.Width = 130;
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.MinimumWidth = 7;
            this.dgcID.Name = "dgcID";
            this.dgcID.Visible = false;
            this.dgcID.Width = 50;
            // 
            // bNav
            // 
            this.bNav.AddNewItem = this.bniAdd;
            this.bNav.BindingSource = this.bsRows;
            this.bNav.CountItem = this.bindingNavigatorCountItem;
            this.bNav.CountItemFormat = " no {0}";
            this.bNav.DataGrid = this.dgvRows;
            this.bNav.DeleteItem = this.bniDelete;
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
            this.bindingNavigatorSeparator2,
            this.bniAdd,
            this.bniDelete,
            this.bniSave});
            this.bNav.Location = new System.Drawing.Point(0, 347);
            this.bNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bNav.Name = "bNav";
            this.bNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bNav.SaveItem = this.bniSave;
            this.bNav.Size = new System.Drawing.Size(732, 33);
            this.bNav.TabIndex = 2;
            this.bNav.Text = "myBindingNavigator1";
            this.bNav.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bNav_ItemDeleting);
            // 
            // bniAdd
            // 
            this.bniAdd.Image = ((System.Drawing.Image)(resources.GetObject("bniAdd.Image")));
            this.bniAdd.Name = "bniAdd";
            this.bniAdd.RightToLeftAutoMirrorImage = true;
            this.bniAdd.Size = new System.Drawing.Size(91, 29);
            this.bniAdd.Text = "Jauns";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(69, 29);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // bniDelete
            // 
            this.bniDelete.Image = ((System.Drawing.Image)(resources.GetObject("bniDelete.Image")));
            this.bniDelete.Name = "bniDelete";
            this.bniDelete.RightToLeftAutoMirrorImage = true;
            this.bniDelete.Size = new System.Drawing.Size(87, 29);
            this.bniDelete.Text = "Dzēst";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(30, 29);
            this.bindingNavigatorMoveFirstItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(30, 29);
            this.bindingNavigatorMovePreviousItem.Text = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 33);
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
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(30, 29);
            this.bindingNavigatorMoveNextItem.Text = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(30, 29);
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // bniSave
            // 
            this.bniSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bniSave.Image = ((System.Drawing.Image)(resources.GetObject("bniSave.Image")));
            this.bniSave.Name = "bniSave";
            this.bniSave.Size = new System.Drawing.Size(30, 29);
            this.bniSave.Text = "Saglabāt";
            this.bniSave.Click += new System.EventHandler(this.bniSave_Click);
            // 
            // Form_UntaxedMinimum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 380);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.bNav);
            this.Controls.Add(this.panel1);
            this.Name = "Form_UntaxedMinimum";
            this.Text = "Neapliekmais minimums";
            this.Load += new System.EventHandler(this.Form_UntaxedMinimum_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFilterPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).EndInit();
            this.bNav.ResumeLayout(false);
            this.bNav.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Components.MyTextBox tbDate1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Data.MyBindingSource bsRows;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private KlonsLIB.Data.MyBindingSource bsPerson;
        private KlonsLIB.Data.MyBindingSource bsFilterPerson;
        private System.Windows.Forms.Button cmFilter;
        private KlonsLIB.Components.MyMcFlatComboBox cbPerson;
        private KlonsLIB.Components.MyBindingNavigator bNav;
        private System.Windows.Forms.ToolStripButton bniAdd;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bniDelete;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bniSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOnDate;
        private KlonsLIB.Components.MyDgvMcComboBoxColumn dgcIDP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUntaxedMin;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcIINRateType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
        private KlonsLIB.Components.MyTextBox tbDate2;
    }
}