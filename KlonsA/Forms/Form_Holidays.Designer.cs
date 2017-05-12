using KlonsLIB.Components;

namespace KlonsA.Forms
{
    partial class Form_Holidays
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Holidays));
            this.dgvSvetki = new KlonsLIB.Components.MyDataGridView();
            this.dgcDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tAGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsSvetki = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bnavSvetki = new KlonsLIB.Components.MyBindingNavigator();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvSvetki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSvetki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavSvetki)).BeginInit();
            this.bnavSvetki.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSvetki
            // 
            this.dgvSvetki.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSvetki.AutoGenerateColumns = false;
            this.dgvSvetki.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSvetki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSvetki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSvetki.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDT,
            this.tAGDataGridViewTextBoxColumn});
            this.dgvSvetki.DataSource = this.bsSvetki;
            this.dgvSvetki.Location = new System.Drawing.Point(0, 27);
            this.dgvSvetki.Name = "dgvSvetki";
            this.dgvSvetki.Size = new System.Drawing.Size(447, 266);
            this.dgvSvetki.TabIndex = 0;
            this.dgvSvetki.MyCheckForChanges += new System.EventHandler(this.dgvSvetki_MyCheckForChanges);
            this.dgvSvetki.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvSvetki_CellParsing);
            this.dgvSvetki.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvSvetki_UserDeletingRow);
            this.dgvSvetki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSvetki_KeyDown);
            this.dgvSvetki.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvSvetki_KeyPress);
            // 
            // dgcDT
            // 
            this.dgcDT.DataPropertyName = "DT";
            dataGridViewCellStyle2.Format = "dd.MM.yyyy";
            this.dgcDT.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcDT.HeaderText = "datums";
            this.dgcDT.MinimumWidth = 4;
            this.dgcDT.Name = "dgcDT";
            this.dgcDT.Width = 88;
            // 
            // tAGDataGridViewTextBoxColumn
            // 
            this.tAGDataGridViewTextBoxColumn.DataPropertyName = "TAG";
            this.tAGDataGridViewTextBoxColumn.HeaderText = "TAG";
            this.tAGDataGridViewTextBoxColumn.MinimumWidth = 4;
            this.tAGDataGridViewTextBoxColumn.Name = "tAGDataGridViewTextBoxColumn";
            this.tAGDataGridViewTextBoxColumn.Visible = false;
            this.tAGDataGridViewTextBoxColumn.Width = 80;
            // 
            // bsSvetki
            // 
            this.bsSvetki.AutoSaveOnDelete = true;
            this.bsSvetki.DataMember = "HOLIDAYS";
            this.bsSvetki.MyDataSource = "KlonsData";
            this.bsSvetki.Name2 = null;
            this.bsSvetki.Sort = "DT";
            this.bsSvetki.UseDataGridView = this.dgvSvetki;
            this.bsSvetki.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsSvetki_ListChanged);
            // 
            // bnavSvetki
            // 
            this.bnavSvetki.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavSvetki.BindingSource = this.bsSvetki;
            this.bnavSvetki.CountItem = this.bindingNavigatorCountItem;
            this.bnavSvetki.CountItemFormat = " no {0}";
            this.bnavSvetki.DataGrid = this.dgvSvetki;
            this.bnavSvetki.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnavSvetki.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavSvetki.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavSvetki.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnavSvetki.Location = new System.Drawing.Point(0, 290);
            this.bnavSvetki.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavSvetki.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavSvetki.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavSvetki.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavSvetki.Name = "bnavSvetki";
            this.bnavSvetki.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavSvetki.Size = new System.Drawing.Size(447, 32);
            this.bnavSvetki.TabIndex = 1;
            this.bnavSvetki.Text = "myBindingNavigator1";
            this.bnavSvetki.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavSvetki_ItemDeleting);
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
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Meklēt pēc gada:";
            // 
            // tbSearch
            // 
            this.tbSearch.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSearch.Location = new System.Drawing.Point(126, 2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(73, 22);
            this.tbSearch.TabIndex = 3;
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // Form_Holidays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 322);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnavSvetki);
            this.Controls.Add(this.dgvSvetki);
            this.Name = "Form_Holidays";
            this.Text = "Teritoriju kodi";
            this.Load += new System.EventHandler(this.Form_Holidays_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSvetki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSvetki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavSvetki)).EndInit();
            this.bnavSvetki.ResumeLayout(false);
            this.bnavSvetki.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyDataGridView dgvSvetki;
        private MyBindingNavigator bnavSvetki;
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
        private KlonsLIB.Data.MyBindingSource bsSvetki;
        private System.Windows.Forms.Label label1;
        private MyTextBox tbSearch;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn tAGDataGridViewTextBoxColumn;
    }
}