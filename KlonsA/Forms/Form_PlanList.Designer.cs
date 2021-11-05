using KlonsLIB.Components;

namespace KlonsA.Forms
{
    partial class Form_PlanList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PlanList));
            this.dgvPlanuSar = new KlonsLIB.Components.MyDataGridView();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcKind1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcKind2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcNight = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgcHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcHoursNight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUsed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsPlanuSar = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bnavPlanuSar = new KlonsLIB.Components.MyBindingNavigator();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbActive = new KlonsLIB.Components.MyMcFlatComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanuSar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanuSar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavPlanuSar)).BeginInit();
            this.bnavPlanuSar.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPlanuSar
            // 
            this.dgvPlanuSar.AllowUserToDeleteRows = false;
            this.dgvPlanuSar.AutoGenerateColumns = false;
            this.dgvPlanuSar.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlanuSar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlanuSar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanuSar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcID,
            this.dgcSnr,
            this.dgcCode,
            this.dgcDescr,
            this.dgcKind1,
            this.dgcKind2,
            this.dgcNight,
            this.dgcHours,
            this.dgcHoursNight,
            this.dgcUsed});
            this.dgvPlanuSar.DataSource = this.bsPlanuSar;
            this.dgvPlanuSar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanuSar.Location = new System.Drawing.Point(0, 28);
            this.dgvPlanuSar.Name = "dgvPlanuSar";
            this.dgvPlanuSar.Size = new System.Drawing.Size(604, 313);
            this.dgvPlanuSar.TabIndex = 0;
            this.dgvPlanuSar.MyCheckForChanges += new System.EventHandler(this.dgvPlanuSar_MyCheckForChanges);
            this.dgvPlanuSar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanuSar_CellDoubleClick);
            this.dgvPlanuSar.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvPlanuSar_DefaultValuesNeeded);
            this.dgvPlanuSar.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPlanuSar_UserDeletingRow);
            this.dgvPlanuSar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPlanuSar_KeyDown);
            this.dgvPlanuSar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvPlanuSar_KeyPress);
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.Name = "dgcID";
            this.dgcID.ReadOnly = true;
            this.dgcID.Visible = false;
            this.dgcID.Width = 80;
            // 
            // dgcSnr
            // 
            this.dgcSnr.DataPropertyName = "SNR";
            this.dgcSnr.HeaderText = "npk.";
            this.dgcSnr.Name = "dgcSnr";
            this.dgcSnr.Width = 40;
            // 
            // dgcCode
            // 
            this.dgcCode.DataPropertyName = "CODE";
            this.dgcCode.HeaderText = "CODE";
            this.dgcCode.Name = "dgcCode";
            this.dgcCode.Visible = false;
            this.dgcCode.Width = 120;
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "DESCR";
            this.dgcDescr.HeaderText = "apraksts";
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.Width = 200;
            // 
            // dgcKind1
            // 
            this.dgcKind1.DataPropertyName = "KIND1";
            this.dgcKind1.HeaderText = "KIND1";
            this.dgcKind1.Name = "dgcKind1";
            this.dgcKind1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcKind1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcKind1.Visible = false;
            this.dgcKind1.Width = 80;
            // 
            // dgcKind2
            // 
            this.dgcKind2.DataPropertyName = "KIND2";
            this.dgcKind2.DisplayStyleForCurrentCellOnly = true;
            this.dgcKind2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcKind2.HeaderText = "veids";
            this.dgcKind2.Name = "dgcKind2";
            this.dgcKind2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcKind2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcKind2.Width = 90;
            // 
            // dgcNight
            // 
            this.dgcNight.DataPropertyName = "NIGHT";
            this.dgcNight.FalseValue = "0";
            this.dgcNight.HeaderText = "nakts";
            this.dgcNight.Name = "dgcNight";
            this.dgcNight.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcNight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcNight.TrueValue = "1";
            this.dgcNight.Width = 48;
            // 
            // dgcHours
            // 
            this.dgcHours.DataPropertyName = "HOURS";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcHours.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcHours.HeaderText = "st.d.";
            this.dgcHours.Name = "dgcHours";
            this.dgcHours.Width = 40;
            // 
            // dgcHoursNight
            // 
            this.dgcHoursNight.DataPropertyName = "HOURS_NIGHT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcHoursNight.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcHoursNight.HeaderText = "st.n.";
            this.dgcHoursNight.Name = "dgcHoursNight";
            this.dgcHoursNight.Width = 40;
            // 
            // dgcUsed
            // 
            this.dgcUsed.DataPropertyName = "USED";
            this.dgcUsed.FalseValue = "0";
            this.dgcUsed.HeaderText = "aktīvs";
            this.dgcUsed.Name = "dgcUsed";
            this.dgcUsed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcUsed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcUsed.TrueValue = "1";
            this.dgcUsed.Width = 50;
            // 
            // bsPlanuSar
            // 
            this.bsPlanuSar.AutoSaveOnDelete = true;
            this.bsPlanuSar.DataMember = "TIMEPLAN_LIST";
            this.bsPlanuSar.MyDataSource = "KlonsData";
            this.bsPlanuSar.Name2 = null;
            this.bsPlanuSar.UseDataGridView = this.dgvPlanuSar;
            this.bsPlanuSar.MyBeforeRowInsert += new KlonsLIB.Data.MyRowUpdateEventHandler(this.bsPlanuSar_MyBeforeRowInsert);
            this.bsPlanuSar.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsPlanuSar_ListChanged);
            // 
            // bnavPlanuSar
            // 
            this.bnavPlanuSar.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavPlanuSar.BindingSource = this.bsPlanuSar;
            this.bnavPlanuSar.CountItem = this.bindingNavigatorCountItem;
            this.bnavPlanuSar.CountItemFormat = " no {0}";
            this.bnavPlanuSar.DataGrid = this.dgvPlanuSar;
            this.bnavPlanuSar.DeleteItem = null;
            this.bnavPlanuSar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavPlanuSar.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavPlanuSar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnavPlanuSar.Location = new System.Drawing.Point(0, 341);
            this.bnavPlanuSar.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavPlanuSar.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavPlanuSar.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavPlanuSar.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavPlanuSar.Name = "bnavPlanuSar";
            this.bnavPlanuSar.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavPlanuSar.Size = new System.Drawing.Size(604, 32);
            this.bnavPlanuSar.TabIndex = 1;
            this.bnavPlanuSar.Text = "myBindingNavigator1";
            this.bnavPlanuSar.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavPlanuSar_ItemDeleting);
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(51, 30);
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
            this.tbSearch.Location = new System.Drawing.Point(130, 0);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(119, 22);
            this.tbSearch.TabIndex = 3;
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(604, 28);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(70, 25);
            this.toolStripLabel1.Text = "Meklēt";
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
            this.cbActive.Location = new System.Drawing.Point(269, 0);
            this.cbActive.Margin = new System.Windows.Forms.Padding(10, 1, 1, 1);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(90, 23);
            this.cbActive.TabIndex = 7;
            this.cbActive.SelectedIndexChanged += new System.EventHandler(this.cbActive_SelectedIndexChanged);
            // 
            // Form_PlanList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 373);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.dgvPlanuSar);
            this.Controls.Add(this.bnavPlanuSar);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_PlanList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Darba laika kopplānu saraksts";
            this.Load += new System.EventHandler(this.Form_PlanList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanuSar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlanuSar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavPlanuSar)).EndInit();
            this.bnavPlanuSar.ResumeLayout(false);
            this.bnavPlanuSar.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyDataGridView dgvPlanuSar;
        private MyBindingNavigator bnavPlanuSar;
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
        private KlonsLIB.Data.MyBindingSource bsPlanuSar;
        private MyTextBox tbSearch;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private MyMcFlatComboBox cbActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescr;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcKind1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcKind2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgcNight;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcHoursNight;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgcUsed;
    }
}