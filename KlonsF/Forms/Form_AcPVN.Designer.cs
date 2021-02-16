using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.Forms
{
    partial class Form_AcPVN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AcPVN));
            this.label1 = new System.Windows.Forms.Label();
            this.tbIdx = new KlonsLIB.Components.MyPickRowTextBox();
            this.bsAcP5 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvAcPVN = new KlonsLIB.Components.MyDataGridView();
            this.dgcIdx = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.bsAcPVN = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnavAcp5 = new KlonsLIB.Components.MyBindingNavigator();
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
            ((System.ComponentModel.ISupportInitialize)(this.bsAcP5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcPVN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcPVN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavAcp5)).BeginInit();
            this.bnavAcp5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kods:";
            // 
            // tbIdx
            // 
            this.tbIdx.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbIdx.DataMember = null;
            this.tbIdx.DataSource = this.bsAcP5;
            this.tbIdx.Location = new System.Drawing.Point(61, 8);
            this.tbIdx.Margin = new System.Windows.Forms.Padding(2);
            this.tbIdx.Name = "tbIdx";
            this.tbIdx.SelectedIndex = -1;
            this.tbIdx.Size = new System.Drawing.Size(90, 26);
            this.tbIdx.TabIndex = 0;
            this.tbIdx.RowSelectedEvent += new KlonsLIB.Components.RowSelectedEventHandler(this.tbIdx_RowSelectedEvent);
            this.tbIdx.Enter += new System.EventHandler(this.tbIdx_Enter);
            // 
            // bsAcP5
            // 
            this.bsAcP5.AutoSaveOnDelete = true;
            this.bsAcP5.DataMember = "Acp25";
            this.bsAcP5.Filter = "";
            this.bsAcP5.MyDataSource = "KlonsData";
            this.bsAcP5.Name2 = "bsAcP5";
            this.bsAcP5.Sort = "idx";
            this.bsAcP5.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsAcP5_ListChanged);
            // 
            // dgvAcPVN
            // 
            this.dgvAcPVN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAcPVN.AutoGenerateColumns = false;
            this.dgvAcPVN.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAcPVN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcPVN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcIdx,
            this.dgcName});
            this.dgvAcPVN.DataSource = this.bsAcP5;
            this.dgvAcPVN.Location = new System.Drawing.Point(0, 40);
            this.dgvAcPVN.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAcPVN.Name = "dgvAcPVN";
            this.dgvAcPVN.RowHeadersWidth = 62;
            this.dgvAcPVN.RowTemplate.Height = 28;
            this.dgvAcPVN.Size = new System.Drawing.Size(523, 354);
            this.dgvAcPVN.TabIndex = 2;
            this.dgvAcPVN.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAcPVN_MyKeyDown);
            this.dgvAcPVN.MyCheckForChanges += new System.EventHandler(this.dgvAcPVN_MyCheckForChanges);
            this.dgvAcPVN.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAcPVN_CellDoubleClick);
            this.dgvAcPVN.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAcPVN_CellValueChanged);
            this.dgvAcPVN.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAcPVN_UserDeletingRow);
            this.dgvAcPVN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAcPVN_KeyDown);
            // 
            // dgcIdx
            // 
            this.dgcIdx.ColumnNames = new string[] {
        "id",
        "NM"};
            this.dgcIdx.ColumnWidths = "50;600";
            this.dgcIdx.DataPropertyName = "idx";
            this.dgcIdx.DataSource = this.bsAcPVN;
            this.dgcIdx.DisplayMember = "id";
            this.dgcIdx.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownList;
            this.dgcIdx.HeaderText = "kods";
            this.dgcIdx.MaxDropDownItems = 15;
            this.dgcIdx.MinimumWidth = 9;
            this.dgcIdx.Name = "dgcIdx";
            this.dgcIdx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcIdx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcIdx.ValueMember = "id";
            this.dgcIdx.Width = 72;
            // 
            // bsAcPVN
            // 
            this.bsAcPVN.DataMember = "AcPVN";
            this.bsAcPVN.MyDataSource = "KlonsData";
            this.bsAcPVN.Name2 = "bsAcPVN";
            this.bsAcPVN.Sort = "ID";
            // 
            // dgcName
            // 
            this.dgcName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgcName.DataPropertyName = "Name";
            this.dgcName.HeaderText = "nosaukums";
            this.dgcName.MinimumWidth = 9;
            this.dgcName.Name = "dgcName";
            this.dgcName.Width = 127;
            // 
            // bnavAcp5
            // 
            this.bnavAcp5.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavAcp5.BindingSource = this.bsAcP5;
            this.bnavAcp5.CountItem = this.bindingNavigatorCountItem;
            this.bnavAcp5.CountItemFormat = " no {0}";
            this.bnavAcp5.DataGrid = this.dgvAcPVN;
            this.bnavAcp5.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnavAcp5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavAcp5.ImageScalingSize = new System.Drawing.Size(23, 26);
            this.bnavAcp5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnavAcp5.Location = new System.Drawing.Point(0, 389);
            this.bnavAcp5.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavAcp5.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavAcp5.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavAcp5.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavAcp5.Name = "bnavAcp5";
            this.bnavAcp5.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavAcp5.SaveItem = null;
            this.bnavAcp5.Size = new System.Drawing.Size(523, 39);
            this.bnavAcp5.TabIndex = 3;
            this.bnavAcp5.Text = "bindingNavigator1";
            this.bnavAcp5.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavAcp5_ItemDeleting);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(92, 34);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            this.bindingNavigatorAddNewItem.ToolTipText = "Jauns (Shift+Insert)";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 34);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Skaits";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(93, 34);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
            this.bindingNavigatorDeleteItem.ToolTipText = "Dzēst (Ctrl+Delete)";
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
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(46, 37);
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
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(34, 34);
            this.tsbSave.Text = "Saglabāt datus";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // Form_AcPVN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 428);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbIdx);
            this.Controls.Add(this.dgvAcPVN);
            this.Controls.Add(this.bnavAcp5);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_AcPVN";
            this.Text = "Kontējuma PVN pazīmes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_AcPVN_FormClosed);
            this.Load += new System.EventHandler(this.FormAcPVN_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormAcPVN_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bsAcP5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcPVN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcPVN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavAcp5)).EndInit();
            this.bnavAcp5.ResumeLayout(false);
            this.bnavAcp5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingNavigator bnavAcp5;
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
        private MyDataGridView dgvAcPVN;
        private MyBindingSource bsAcP5;
        private MyPickRowTextBox tbIdx;
        private System.Windows.Forms.Label label1;
        private MyBindingSource bsAcPVN;
        private MyDgvMcCBColumn dgcIdx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
    }
}