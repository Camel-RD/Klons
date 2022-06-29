using KlonsLIB.Components;

namespace KlonsA.Forms
{
    partial class Form_Professions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Professions));
            this.dgvProf = new KlonsLIB.Components.MyDataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uSEDDataGridViewTextBoxColumn = new MyDgvCheckBoxColumn();
            this.bsProf = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bnavProf = new KlonsLIB.Components.MyBindingNavigator();
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new KlonsLIB.Components.MyTextBox();
            this.cbCat = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsProfCat = new KlonsLIB.Data.MyBindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavProf)).BeginInit();
            this.bnavProf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProfCat)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProf
            // 
            this.dgvProf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProf.AutoGenerateColumns = false;
            this.dgvProf.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvProf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.dESCRDataGridViewTextBoxColumn,
            this.uSEDDataGridViewTextBoxColumn});
            this.dgvProf.DataSource = this.bsProf;
            this.dgvProf.Location = new System.Drawing.Point(0, 25);
            this.dgvProf.Name = "dgvProf";
            this.dgvProf.RowTemplate.Height = 24;
            this.dgvProf.Size = new System.Drawing.Size(662, 294);
            this.dgvProf.TabIndex = 3;
            this.dgvProf.MyCheckForChanges += new System.EventHandler(this.dgvProf_MyCheckForChanges);
            this.dgvProf.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProf_CellDoubleClick);
            this.dgvProf.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvProf_UserDeletingRow);
            this.dgvProf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProf_KeyDown);
            this.dgvProf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvProf_KeyPress);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "Kods";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 4;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 64;
            // 
            // dESCRDataGridViewTextBoxColumn
            // 
            this.dESCRDataGridViewTextBoxColumn.DataPropertyName = "DESCR";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dESCRDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dESCRDataGridViewTextBoxColumn.HeaderText = "Apraksts";
            this.dESCRDataGridViewTextBoxColumn.MinimumWidth = 4;
            this.dESCRDataGridViewTextBoxColumn.Name = "dESCRDataGridViewTextBoxColumn";
            this.dESCRDataGridViewTextBoxColumn.Width = 480;
            // 
            // uSEDDataGridViewTextBoxColumn
            // 
            this.uSEDDataGridViewTextBoxColumn.DataPropertyName = "USED";
            this.uSEDDataGridViewTextBoxColumn.FalseValue = "0";
            this.uSEDDataGridViewTextBoxColumn.HeaderText = "Atzīmēt";
            this.uSEDDataGridViewTextBoxColumn.MinimumWidth = 4;
            this.uSEDDataGridViewTextBoxColumn.Name = "uSEDDataGridViewTextBoxColumn";
            this.uSEDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.uSEDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.uSEDDataGridViewTextBoxColumn.TrueValue = "1";
            this.uSEDDataGridViewTextBoxColumn.Width = 56;
            // 
            // bsProf
            // 
            this.bsProf.AutoSaveOnDelete = true;
            this.bsProf.DataMember = "PROFESSIONS";
            this.bsProf.MyDataSource = "KlonsData";
            this.bsProf.UseDataGridView = this.dgvProf;
            this.bsProf.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsProf_ListChanged);
            // 
            // bnavProf
            // 
            this.bnavProf.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavProf.BindingSource = this.bsProf;
            this.bnavProf.CountItem = this.bindingNavigatorCountItem;
            this.bnavProf.CountItemFormat = " no {0}";
            this.bnavProf.DataGrid = this.dgvProf;
            this.bnavProf.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnavProf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavProf.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavProf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnavProf.Location = new System.Drawing.Point(0, 315);
            this.bnavProf.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavProf.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavProf.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavProf.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavProf.Name = "bnavProf";
            this.bnavProf.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavProf.SaveItem = null;
            this.bnavProf.Size = new System.Drawing.Size(662, 32);
            this.bnavProf.TabIndex = 4;
            this.bnavProf.Text = "myBindingNavigator1";
            this.bnavProf.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavProf_ItemDeleting);
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
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(25, 29);
            this.tsbSave.Text = "toolStripButton1";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Meklēt:";
            // 
            // tbSearch
            // 
            this.tbSearch.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSearch.Location = new System.Drawing.Point(143, 2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(119, 22);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // cbCat
            // 
            this.cbCat.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbCat.ColumnNames = new string[] {
        "id",
        "descr"};
            this.cbCat.ColumnWidths = "80;450";
            this.cbCat.DataSource = this.bsProfCat;
            this.cbCat.DisplayMember = "ID";
            this.cbCat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCat.DropDownHeight = 255;
            this.cbCat.DropDownWidth = 443;
            this.cbCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCat.FormattingEnabled = true;
            this.cbCat.GridLineColor = System.Drawing.Color.LightGray;
            this.cbCat.GridLineHorizontal = false;
            this.cbCat.GridLineVertical = false;
            this.cbCat.IntegralHeight = false;
            this.cbCat.Location = new System.Drawing.Point(2, 2);
            this.cbCat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbCat.MaxDropDownItems = 15;
            this.cbCat.Name = "cbCat";
            this.cbCat.Size = new System.Drawing.Size(79, 23);
            this.cbCat.TabIndex = 0;
            this.cbCat.ValueMember = "ID";
            this.cbCat.SelectedIndexChanged += new System.EventHandler(this.cbCat_SelectedIndexChanged);
            // 
            // bsProfCat
            // 
            this.bsProfCat.AutoSaveOnDelete = true;
            this.bsProfCat.DataMember = "PROFESSIONS";
            this.bsProfCat.Filter = "Cat=1";
            this.bsProfCat.MyDataSource = "KlonsData";
            this.bsProfCat.UseDataGridView = this.dgvProf;
            // 
            // Form_Professions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 347);
            this.Controls.Add(this.cbCat);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnavProf);
            this.Controls.Add(this.dgvProf);
            this.Name = "Form_Professions";
            this.Text = "Teritoriju kodi";
            this.Load += new System.EventHandler(this.Form_Professions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavProf)).EndInit();
            this.bnavProf.ResumeLayout(false);
            this.bnavProf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProfCat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyDataGridView dgvProf;
        private MyBindingNavigator bnavProf;
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
        private KlonsLIB.Data.MyBindingSource bsProf;
        private System.Windows.Forms.Label label1;
        private MyTextBox tbSearch;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private MyMcFlatComboBox cbCat;
        private KlonsLIB.Data.MyBindingSource bsProfCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRDataGridViewTextBoxColumn;
        private MyDgvCheckBoxColumn uSEDDataGridViewTextBoxColumn;
    }
}