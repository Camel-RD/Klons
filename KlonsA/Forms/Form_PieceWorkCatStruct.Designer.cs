namespace KlonsA.Forms
{
    partial class Form_PieceWorkCatStruct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PieceWorkCatStruct));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.dgvSar = new KlonsLIB.Components.MyDataGridView();
            this.dgcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUsed = new KlonsLIB.Components.MyDgvCheckBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsSar = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bnavSar = new KlonsLIB.Components.MyBindingNavigator();
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
            this.tbFilter = new KlonsLIB.Components.MyTextBox();
            this.tbCode = new KlonsLIB.Components.MyPickRowTextBox();
            this.cbActive = new KlonsLIB.Components.MyMcFlatComboBox();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavSar)).BeginInit();
            this.bnavSar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(570, 30);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(90, 25);
            this.toolStripLabel1.Text = "  meklēt: ";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(22, 25);
            this.toolStripLabel2.Text = "  ";
            // 
            // dgvSar
            // 
            this.dgvSar.AllowUserToDeleteRows = false;
            this.dgvSar.AutoGenerateColumns = false;
            this.dgvSar.AutoSave = false;
            this.dgvSar.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcCode,
            this.dgcDescr,
            this.dgcUsed,
            this.iDDataGridViewTextBoxColumn});
            this.dgvSar.DataSource = this.bsSar;
            this.dgvSar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSar.Location = new System.Drawing.Point(0, 30);
            this.dgvSar.Name = "dgvSar";
            this.dgvSar.RowTemplate.Height = 24;
            this.dgvSar.Size = new System.Drawing.Size(570, 409);
            this.dgvSar.TabIndex = 4;
            this.dgvSar.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSar_MyKeyDown);
            this.dgvSar.MyCheckForChanges += new System.EventHandler(this.dgvSar_MyCheckForChanges);
            this.dgvSar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSar_CellDoubleClick);
            this.dgvSar.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvSar_UserDeletingRow);
            this.dgvSar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSar_KeyDown);
            this.dgvSar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvSar_KeyPress);
            // 
            // dgcCode
            // 
            this.dgcCode.DataPropertyName = "CODE";
            this.dgcCode.HeaderText = "kods";
            this.dgcCode.Name = "dgcCode";
            this.dgcCode.Width = 120;
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "DESCR";
            this.dgcDescr.HeaderText = "apraksts";
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.Width = 300;
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
            this.dgcUsed.Width = 60;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // bsSar
            // 
            this.bsSar.DataMember = "PIECEWORK_CATSTRUCT";
            this.bsSar.MyDataSource = "KlonsData";
            this.bsSar.Name2 = null;
            this.bsSar.Sort = "Code";
            this.bsSar.UseDataGridView = this.dgvSar;
            this.bsSar.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsSar_ListChanged);
            // 
            // bnavSar
            // 
            this.bnavSar.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavSar.BindingSource = this.bsSar;
            this.bnavSar.CountItem = this.bindingNavigatorCountItem;
            this.bnavSar.CountItemFormat = " no {0}";
            this.bnavSar.DataGrid = this.dgvSar;
            this.bnavSar.DeleteItem = null;
            this.bnavSar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavSar.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavSar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnavSar.Location = new System.Drawing.Point(0, 439);
            this.bnavSar.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavSar.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavSar.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavSar.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavSar.Name = "bnavSar";
            this.bnavSar.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavSar.Size = new System.Drawing.Size(570, 32);
            this.bnavSar.TabIndex = 5;
            this.bnavSar.Text = "myBindingNavigator1";
            this.bnavSar.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavSar_ItemDeleting);
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
            this.tsbSave.Text = "Saglabāt";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tbFilter
            // 
            this.tbFilter.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbFilter.Location = new System.Drawing.Point(305, 0);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(154, 22);
            this.tbFilter.TabIndex = 1;
            this.tbFilter.Enter += new System.EventHandler(this.tbFilter_Enter);
            this.tbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            this.tbFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbFilter_MouseDown);
            // 
            // tbCode
            // 
            this.tbCode.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbCode.ColumnNr = 1;
            this.tbCode.DataMember = null;
            this.tbCode.DataSource = this.bsSar;
            this.tbCode.Location = new System.Drawing.Point(174, 0);
            this.tbCode.Name = "tbCode";
            this.tbCode.SelectedIndex = -1;
            this.tbCode.Size = new System.Drawing.Size(104, 22);
            this.tbCode.TabIndex = 0;
            this.tbCode.RowSelectedEvent += new KlonsLIB.Components.RowSelectedEventHandler(this.tbCode_RowSelectedEvent);
            this.tbCode.Enter += new System.EventHandler(this.tbCode_Enter);
            this.tbCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbCode_MouseDown);
            // 
            // cbActive
            // 
            this.cbActive.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbActive.ColumnNames = new string[0];
            this.cbActive.ColumnWidths = "121";
            this.cbActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbActive.DropDownHeight = 136;
            this.cbActive.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbActive.DropDownWidth = 145;
            this.cbActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbActive.FormattingEnabled = true;
            this.cbActive.GridLineColor = System.Drawing.Color.LightGray;
            this.cbActive.GridLineHorizontal = false;
            this.cbActive.GridLineVertical = false;
            this.cbActive.IntegralHeight = false;
            this.cbActive.Items.AddRange(new object[] {
            "Aktīvie",
            "Visi"});
            this.cbActive.Location = new System.Drawing.Point(480, 0);
            this.cbActive.Margin = new System.Windows.Forms.Padding(2);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(90, 23);
            this.cbActive.TabIndex = 3;
            this.cbActive.SelectedIndexChanged += new System.EventHandler(this.cbActive_SelectedIndexChanged);
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "PIECEWORK",
        "PIECEWORK_CATALOG",
        "PIECEWORK_CATSTRUCT",
        null};
            // 
            // Form_PieceWorkCatStruct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 471);
            this.CloseOnEscape = true;
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.dgvSar);
            this.Controls.Add(this.bnavSar);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_PieceWorkCatStruct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gabaldarbu kataloga struktūra";
            this.Load += new System.EventHandler(this.Form_PieceWorkCatStruct_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavSar)).EndInit();
            this.bnavSar.ResumeLayout(false);
            this.bnavSar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private KlonsLIB.Components.MyDataGridView dgvSar;
        private KlonsLIB.Data.MyBindingSource bsSar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescr;
        private KlonsLIB.Components.MyDgvCheckBoxColumn dgcUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private KlonsLIB.Components.MyBindingNavigator bnavSar;
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
        private System.Windows.Forms.ToolStripButton tsbSave;
        private KlonsLIB.Components.MyTextBox tbFilter;
        private KlonsLIB.Components.MyPickRowTextBox tbCode;
        private KlonsLIB.Components.MyMcFlatComboBox cbActive;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
    }
}