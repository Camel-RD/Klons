using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.Forms
{
    partial class Form_AcP4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AcP4));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new KlonsLIB.Components.MyTextBox();
            this.tbIdx = new KlonsLIB.Components.MyPickRowTextBox();
            this.dgvAcP4 = new KlonsLIB.Components.MyDataGridView();
            this.dgcIdx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAcP4 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bnavAcp4 = new KlonsLIB.Components.MyBindingNavigator();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcP4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcP4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavAcp4)).BeginInit();
            this.bnavAcp4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "meklēt:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kods:";
            // 
            // tbSearch
            // 
            this.tbSearch.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSearch.Location = new System.Drawing.Point(198, 6);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(88, 22);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // tbIdx
            // 
            this.tbIdx.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbIdx.DataMember = null;
            this.tbIdx.Location = new System.Drawing.Point(54, 6);
            this.tbIdx.Margin = new System.Windows.Forms.Padding(2);
            this.tbIdx.Name = "tbIdx";
            this.tbIdx.SelectedIndex = -1;
            this.tbIdx.Size = new System.Drawing.Size(80, 22);
            this.tbIdx.TabIndex = 0;
            this.tbIdx.RowSelectedEvent += new KlonsLIB.Components.RowSelectedEventHandler(this.tbIdx_RowSelectedEvent);
            this.tbIdx.Enter += new System.EventHandler(this.tbIdx_Enter);
            // 
            // dgvAcP4
            // 
            this.dgvAcP4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAcP4.AutoGenerateColumns = false;
            this.dgvAcP4.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAcP4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcP4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcIdx,
            this.dgcName,
            this.dgcUnit,
            this.dgcPrice});
            this.dgvAcP4.DataSource = this.bsAcP4;
            this.dgvAcP4.Location = new System.Drawing.Point(0, 32);
            this.dgvAcP4.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAcP4.Name = "dgvAcP4";
            this.dgvAcP4.RowTemplate.Height = 19;
            this.dgvAcP4.Size = new System.Drawing.Size(576, 283);
            this.dgvAcP4.TabIndex = 2;
            this.dgvAcP4.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAcP4_MyKeyDown);
            this.dgvAcP4.MyCheckForChanges += new System.EventHandler(this.dgvAcP4_MyCheckForChanges);
            this.dgvAcP4.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAcP4_CellDoubleClick);
            this.dgvAcP4.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAcP4_UserDeletingRow);
            this.dgvAcP4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAcP4_KeyDown);
            this.dgvAcP4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvAcP4_KeyPress);
            // 
            // dgcIdx
            // 
            this.dgcIdx.DataPropertyName = "idx";
            this.dgcIdx.HeaderText = "kods";
            this.dgcIdx.Name = "dgcIdx";
            this.dgcIdx.Width = 64;
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "Name";
            this.dgcName.HeaderText = "nosaukums";
            this.dgcName.Name = "dgcName";
            this.dgcName.Width = 280;
            // 
            // dgcUnit
            // 
            this.dgcUnit.DataPropertyName = "UNIT";
            this.dgcUnit.HeaderText = "Mērv.";
            this.dgcUnit.Name = "dgcUnit";
            this.dgcUnit.Width = 80;
            // 
            // dgcPrice
            // 
            this.dgcPrice.DataPropertyName = "PRICE";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "F2";
            this.dgcPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcPrice.HeaderText = "Cena";
            this.dgcPrice.Name = "dgcPrice";
            this.dgcPrice.Width = 80;
            // 
            // bsAcP4
            // 
            this.bsAcP4.AutoSaveOnDelete = true;
            this.bsAcP4.DataMember = "AcP24";
            this.bsAcP4.Filter = "";
            this.bsAcP4.MyDataSource = "KlonsData";
            this.bsAcP4.Name2 = "bsAcP4";
            this.bsAcP4.Sort = "idx";
            this.bsAcP4.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsAcP4_ListChanged);
            // 
            // bnavAcp4
            // 
            this.bnavAcp4.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavAcp4.BindingSource = this.bsAcP4;
            this.bnavAcp4.CountItem = this.bindingNavigatorCountItem;
            this.bnavAcp4.CountItemFormat = " no {0}";
            this.bnavAcp4.DataGrid = this.dgvAcP4;
            this.bnavAcp4.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnavAcp4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavAcp4.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavAcp4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnavAcp4.Location = new System.Drawing.Point(0, 310);
            this.bnavAcp4.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavAcp4.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavAcp4.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavAcp4.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavAcp4.Name = "bnavAcp4";
            this.bnavAcp4.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavAcp4.Size = new System.Drawing.Size(576, 32);
            this.bnavAcp4.TabIndex = 3;
            this.bnavAcp4.Text = "bindingNavigator1";
            this.bnavAcp4.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavAcp4_ItemDeleting);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(91, 29);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            this.bindingNavigatorAddNewItem.ToolTipText = "Jauns (Shift+Insert)";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(69, 29);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Skaits";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(87, 29);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
            this.bindingNavigatorDeleteItem.ToolTipText = "Dzēst (Ctrl+Delete)";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.ToolTipText = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.ToolTipText = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 32);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(41, 30);
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
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.ToolTipText = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.ToolTipText = "Iet uz pēdējo";
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
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(25, 29);
            this.tsbSave.Text = "Sagalbāt datus";
            this.tsbSave.ToolTipText = "Saglabāt datus";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // Form_AcP4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 342);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.tbIdx);
            this.Controls.Add(this.dgvAcP4);
            this.Controls.Add(this.bnavAcp4);
            this.Name = "Form_AcP4";
            this.Text = "Nozares / produkti";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAcP4_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormAcP4_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcP4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcP4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavAcp4)).EndInit();
            this.bnavAcp4.ResumeLayout(false);
            this.bnavAcp4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingNavigator bnavAcp4;
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
        private MyDataGridView dgvAcP4;
        private MyBindingSource bsAcP4;
        private MyPickRowTextBox tbIdx;
        private MyTextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIdx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPrice;
    }
}