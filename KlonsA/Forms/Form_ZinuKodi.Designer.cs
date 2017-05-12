namespace KlonsA.Forms
{
    partial class Form_ReportCodes
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
            KlonsLIB.Components.MyMcComboBox.MyItem myItem1 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem2 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ReportCodes));
            this.dgvZinuKodi = new KlonsLIB.Components.MyDataGridView();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUsed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgcTP1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTP2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsZinuKodi = new KlonsLIB.Data.MyBindingSource(this.components);
            this.tbCode = new KlonsLIB.Components.MyPickRowTextBox();
            this.cbUsed = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bnNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZinuKodi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsZinuKodi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnNav)).BeginInit();
            this.bnNav.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvZinuKodi
            // 
            this.dgvZinuKodi.AutoGenerateColumns = false;
            this.dgvZinuKodi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvZinuKodi.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvZinuKodi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvZinuKodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZinuKodi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcID,
            this.dgcCode,
            this.dgcDescr,
            this.dgcUsed,
            this.dgcTP1,
            this.dgcTP2});
            this.dgvZinuKodi.DataSource = this.bsZinuKodi;
            this.dgvZinuKodi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvZinuKodi.Location = new System.Drawing.Point(0, 28);
            this.dgvZinuKodi.Name = "dgvZinuKodi";
            this.dgvZinuKodi.RowTemplate.Height = 24;
            this.dgvZinuKodi.Size = new System.Drawing.Size(674, 286);
            this.dgvZinuKodi.TabIndex = 3;
            this.dgvZinuKodi.MyCheckForChanges += new System.EventHandler(this.dgvZinuKodi_MyCheckForChanges);
            this.dgvZinuKodi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvZinuKodi_CellDoubleClick);
            this.dgvZinuKodi.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvZinuKodi_UserDeletingRow);
            this.dgvZinuKodi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvZinuKodi_KeyDown);
            this.dgvZinuKodi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvZinuKodi_KeyPress);
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.Name = "dgcID";
            this.dgcID.Visible = false;
            // 
            // dgcCode
            // 
            this.dgcCode.DataPropertyName = "CODE";
            this.dgcCode.HeaderText = "kods";
            this.dgcCode.Name = "dgcCode";
            this.dgcCode.Width = 50;
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "DESCR";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcDescr.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcDescr.HeaderText = "apraksts";
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.Width = 500;
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
            // dgcTP1
            // 
            this.dgcTP1.DataPropertyName = "TP1";
            this.dgcTP1.HeaderText = "TP1";
            this.dgcTP1.Name = "dgcTP1";
            this.dgcTP1.Visible = false;
            // 
            // dgcTP2
            // 
            this.dgcTP2.DataPropertyName = "TP2";
            this.dgcTP2.HeaderText = "TP2";
            this.dgcTP2.Name = "dgcTP2";
            this.dgcTP2.Visible = false;
            // 
            // bsZinuKodi
            // 
            this.bsZinuKodi.AutoSaveOnDelete = true;
            this.bsZinuKodi.DataMember = "REPORT_CODES";
            this.bsZinuKodi.MyDataSource = "KlonsData";
            this.bsZinuKodi.Name2 = null;
            this.bsZinuKodi.Sort = "CODE";
            this.bsZinuKodi.UseDataGridView = this.dgvZinuKodi;
            this.bsZinuKodi.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsZinuKodi_ListChanged);
            // 
            // tbCode
            // 
            this.tbCode.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbCode.ColumnNr = 1;
            this.tbCode.DataMember = null;
            this.tbCode.DataSource = this.bsZinuKodi;
            this.tbCode.Location = new System.Drawing.Point(85, 3);
            this.tbCode.Name = "tbCode";
            this.tbCode.SelectedIndex = -1;
            this.tbCode.Size = new System.Drawing.Size(63, 22);
            this.tbCode.TabIndex = 0;
            this.tbCode.RowSelectedEvent += new KlonsLIB.Components.RowSelectedEventHandler(this.tbCode_RowSelectedEvent);
            this.tbCode.Enter += new System.EventHandler(this.tbCode_Enter);
            // 
            // cbUsed
            // 
            this.cbUsed.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbUsed.ColumnNames = new string[] {
        "col1"};
            this.cbUsed.ColumnWidths = "81";
            this.cbUsed.DisplayMember = "col1";
            this.cbUsed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbUsed.DropDownHeight = 136;
            this.cbUsed.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbUsed.DropDownWidth = 105;
            this.cbUsed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbUsed.FormattingEnabled = true;
            this.cbUsed.GridLineColor = System.Drawing.Color.LightGray;
            this.cbUsed.GridLineHorizontal = false;
            this.cbUsed.GridLineVertical = false;
            this.cbUsed.IntegralHeight = false;
            myItem1.Col1 = "visi";
            myItem2.Col1 = "aktīvie";
            this.cbUsed.Items.AddRange(new object[] {
            myItem1,
            myItem2});
            this.cbUsed.ItemStrings = new string[] {
        "visi",
        "aktīvie"};
            this.cbUsed.Location = new System.Drawing.Point(168, 3);
            this.cbUsed.Name = "cbUsed";
            this.cbUsed.Size = new System.Drawing.Size(105, 23);
            this.cbUsed.TabIndex = 1;
            this.cbUsed.ValueMember = "col1";
            this.cbUsed.SelectedIndexChanged += new System.EventHandler(this.cbUsed_SelectedIndexChanged);
            // 
            // bnNav
            // 
            this.bnNav.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnNav.BindingSource = this.bsZinuKodi;
            this.bnNav.CountItem = this.bindingNavigatorCountItem;
            this.bnNav.CountItemFormat = " no {0}";
            this.bnNav.DataGrid = this.dgvZinuKodi;
            this.bnNav.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnNav.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnNav.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnNav.Location = new System.Drawing.Point(0, 314);
            this.bnNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnNav.Name = "bnNav";
            this.bnNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bnNav.Size = new System.Drawing.Size(674, 32);
            this.bnNav.TabIndex = 4;
            this.bnNav.Text = "myBindingNavigator1";
            this.bnNav.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnNav_ItemDeleting);
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(87, 29);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
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
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::KlonsA.Properties.Resources.Save1;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(25, 29);
            this.tsbSave.Text = "Saglabāt";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(674, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(17, 25);
            this.toolStripLabel1.Text = " ";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(17, 25);
            this.toolStripLabel2.Text = " ";
            // 
            // Form_ReportCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 346);
            this.Controls.Add(this.dgvZinuKodi);
            this.Controls.Add(this.bnNav);
            this.Controls.Add(this.cbUsed);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_ReportCodes";
            this.Text = "Ziņu kodi";
            this.Load += new System.EventHandler(this.Form_ReportCodes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZinuKodi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsZinuKodi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnNav)).EndInit();
            this.bnNav.ResumeLayout(false);
            this.bnNav.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Components.MyDataGridView dgvZinuKodi;
        private KlonsLIB.Components.MyPickRowTextBox tbCode;
        private KlonsLIB.Components.MyMcFlatComboBox cbUsed;
        private KlonsLIB.Components.MyBindingNavigator bnNav;
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private KlonsLIB.Data.MyBindingSource bsZinuKodi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgcUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTP1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTP2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    }
}