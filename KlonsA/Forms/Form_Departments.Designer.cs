using KlonsLIB.Components;

namespace KlonsA.Forms
{
    partial class Form_Departments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Departments));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDep = new KlonsLIB.Components.MyDataGridView();
            this.bsDep = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bnavDep = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tbSearch = new KlonsLIB.Components.MyTextBox();
            this.tbID = new KlonsLIB.Components.MyPickRowTextBox();
            this.cbActive = new KlonsLIB.Components.MyMcFlatComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.dgcDepId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDepDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDepUsed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgcDepUsedDT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDepUsedDT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDepAcc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDepAcc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavDep)).BeginInit();
            this.bnavDep.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDep
            // 
            this.dgvDep.AllowUserToDeleteRows = false;
            this.dgvDep.AutoGenerateColumns = false;
            this.dgvDep.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDep.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDepId,
            this.dgcDepDescr,
            this.dgcDepUsed,
            this.dgcDepUsedDT1,
            this.dgcDepUsedDT2,
            this.dgcDepAcc1,
            this.dgcDepAcc2});
            this.dgvDep.DataSource = this.bsDep;
            this.dgvDep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDep.Location = new System.Drawing.Point(0, 30);
            this.dgvDep.Name = "dgvDep";
            this.dgvDep.RowTemplate.Height = 24;
            this.dgvDep.Size = new System.Drawing.Size(696, 358);
            this.dgvDep.TabIndex = 0;
            this.dgvDep.MyCheckForChanges += new System.EventHandler(this.dgvDep_MyCheckForChanges);
            this.dgvDep.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDep_CellDoubleClick);
            this.dgvDep.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvDep_CellParsing);
            this.dgvDep.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDep_UserDeletingRow);
            this.dgvDep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDep_KeyDown);
            this.dgvDep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvDep_KeyPress);
            // 
            // bsDep
            // 
            this.bsDep.AutoSaveOnDelete = true;
            this.bsDep.DataMember = "DEPARTMENTS";
            this.bsDep.MyDataSource = "KlonsData";
            this.bsDep.Sort = "ID";
            this.bsDep.UseDataGridView = this.dgvDep;
            this.bsDep.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsDep_ListChanged);
            // 
            // bnavDep
            // 
            this.bnavDep.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavDep.BindingSource = this.bsDep;
            this.bnavDep.CountItem = this.bindingNavigatorCountItem;
            this.bnavDep.CountItemFormat = " no {0}";
            this.bnavDep.DataGrid = this.dgvDep;
            this.bnavDep.DeleteItem = null;
            this.bnavDep.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavDep.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavDep.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.tsbSave});
            this.bnavDep.Location = new System.Drawing.Point(0, 388);
            this.bnavDep.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavDep.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavDep.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavDep.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavDep.Name = "bnavDep";
            this.bnavDep.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavDep.SaveItem = null;
            this.bnavDep.Size = new System.Drawing.Size(696, 32);
            this.bnavDep.TabIndex = 1;
            this.bnavDep.Text = "myBindingNavigator1";
            this.bnavDep.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavDep_ItemDeleting);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(91, 29);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(69, 29);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMoveFirstItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMovePreviousItem.Text = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 32);
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
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMoveNextItem.Text = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(87, 29);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(25, 29);
            this.tsbSave.Text = "toolStripButton1";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSearch.Location = new System.Drawing.Point(277, 0);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(129, 22);
            this.tbSearch.TabIndex = 3;
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // tbID
            // 
            this.tbID.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbID.DataMember = null;
            this.tbID.DataSource = this.bsDep;
            this.tbID.Location = new System.Drawing.Point(128, 0);
            this.tbID.Margin = new System.Windows.Forms.Padding(2);
            this.tbID.Name = "tbID";
            this.tbID.SelectedIndex = -1;
            this.tbID.Size = new System.Drawing.Size(99, 22);
            this.tbID.TabIndex = 4;
            this.tbID.RowSelectedEvent += new KlonsLIB.Components.RowSelectedEventHandler(this.tbID_RowSelectedEvent);
            this.tbID.Enter += new System.EventHandler(this.tbID_Enter);
            // 
            // cbActive
            // 
            this.cbActive.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbActive.ColumnNames = new string[0];
            this.cbActive.ColumnWidths = "66";
            this.cbActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbActive.DropDownHeight = 136;
            this.cbActive.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbActive.DropDownWidth = 90;
            this.cbActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbActive.FormattingEnabled = true;
            this.cbActive.GridLineColor = System.Drawing.Color.LightGray;
            this.cbActive.GridLineHorizontal = false;
            this.cbActive.GridLineVertical = false;
            this.cbActive.IntegralHeight = false;
            this.cbActive.Items.AddRange(new object[] {
            "Aktīvie",
            "Visi"});
            this.cbActive.Location = new System.Drawing.Point(427, 0);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(90, 23);
            this.cbActive.TabIndex = 6;
            this.cbActive.SelectedIndexChanged += new System.EventHandler(this.cbActive_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.toolStrip1.Size = new System.Drawing.Size(696, 30);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(81, 25);
            this.toolStripLabel1.Text = " Meklēt:";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(27, 25);
            this.toolStripLabel2.Text = "   ";
            // 
            // dgcDepId
            // 
            this.dgcDepId.DataPropertyName = "ID";
            this.dgcDepId.HeaderText = "kods";
            this.dgcDepId.MaxInputLength = 15;
            this.dgcDepId.MinimumWidth = 4;
            this.dgcDepId.Name = "dgcDepId";
            this.dgcDepId.Width = 96;
            // 
            // dgcDepDescr
            // 
            this.dgcDepDescr.DataPropertyName = "DESCR";
            this.dgcDepDescr.HeaderText = "nosaukums";
            this.dgcDepDescr.MaxInputLength = 50;
            this.dgcDepDescr.MinimumWidth = 4;
            this.dgcDepDescr.Name = "dgcDepDescr";
            this.dgcDepDescr.Width = 300;
            // 
            // dgcDepUsed
            // 
            this.dgcDepUsed.DataPropertyName = "USED";
            this.dgcDepUsed.FalseValue = "0";
            this.dgcDepUsed.HeaderText = "aktīvs";
            this.dgcDepUsed.Name = "dgcDepUsed";
            this.dgcDepUsed.TrueValue = "1";
            this.dgcDepUsed.Width = 50;
            // 
            // dgcDepUsedDT1
            // 
            this.dgcDepUsedDT1.DataPropertyName = "USED_DT1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "dd.MM.yyyy";
            this.dgcDepUsedDT1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcDepUsedDT1.HeaderText = "aktīvs no";
            this.dgcDepUsedDT1.Name = "dgcDepUsedDT1";
            this.dgcDepUsedDT1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDepUsedDT1.Width = 85;
            // 
            // dgcDepUsedDT2
            // 
            this.dgcDepUsedDT2.DataPropertyName = "USED_DT2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "dd.MM.yyyy";
            this.dgcDepUsedDT2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcDepUsedDT2.HeaderText = "aktīvs līdz";
            this.dgcDepUsedDT2.Name = "dgcDepUsedDT2";
            this.dgcDepUsedDT2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDepUsedDT2.Width = 85;
            // 
            // dgcDepAcc1
            // 
            this.dgcDepAcc1.DataPropertyName = "ACC1";
            this.dgcDepAcc1.HeaderText = "Izm. konts";
            this.dgcDepAcc1.MinimumWidth = 4;
            this.dgcDepAcc1.Name = "dgcDepAcc1";
            this.dgcDepAcc1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDepAcc1.Visible = false;
            this.dgcDepAcc1.Width = 80;
            // 
            // dgcDepAcc2
            // 
            this.dgcDepAcc2.DataPropertyName = "ACC2";
            this.dgcDepAcc2.HeaderText = "dd si konts";
            this.dgcDepAcc2.MinimumWidth = 4;
            this.dgcDepAcc2.Name = "dgcDepAcc2";
            this.dgcDepAcc2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDepAcc2.Visible = false;
            this.dgcDepAcc2.Width = 80;
            // 
            // Form_Departments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 420);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.dgvDep);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.bnavDep);
            this.Name = "Form_Departments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Struktūrvienības";
            this.Load += new System.EventHandler(this.Form_Departments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavDep)).EndInit();
            this.bnavDep.ResumeLayout(false);
            this.bnavDep.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyDataGridView dgvDep;
        private MyBindingNavigator bnavDep;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private KlonsLIB.Data.MyBindingSource bsDep;
        private MyTextBox tbSearch;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private MyPickRowTextBox tbID;
        private MyMcFlatComboBox cbActive;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDepId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDepDescr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgcDepUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDepUsedDT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDepUsedDT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDepAcc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDepAcc2;
    }
}