namespace KlonsA.Forms
{
    partial class Form_EventTypes2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_EventTypes2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bnavEv = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bsEv = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvEv = new KlonsLIB.Components.MyDataGridView();
            this.dgcTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.bnavEv)).BeginInit();
            this.bnavEv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bnavEv
            // 
            this.bnavEv.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavEv.BindingSource = this.bsEv;
            this.bnavEv.CountItem = this.bindingNavigatorCountItem;
            this.bnavEv.CountItemFormat = " no {0}";
            this.bnavEv.DataGrid = this.dgvEv;
            this.bnavEv.DeleteItem = null;
            this.bnavEv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavEv.ImageScalingSize = new System.Drawing.Size(23, 26);
            this.bnavEv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnavEv.Location = new System.Drawing.Point(0, 472);
            this.bnavEv.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavEv.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavEv.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavEv.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavEv.Name = "bnavEv";
            this.bnavEv.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavEv.SaveItem = null;
            this.bnavEv.Size = new System.Drawing.Size(618, 39);
            this.bnavEv.TabIndex = 0;
            this.bnavEv.Text = "myBindingNavigator1";
            this.bnavEv.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavEv_ItemDeleting);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(92, 34);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            // 
            // bsEv
            // 
            this.bsEv.DataMember = "EVENT_TYPES2";
            this.bsEv.MyDataSource = "KlonsData";
            this.bsEv.Sort = "TAG";
            this.bsEv.UseDataGridView = this.dgvEv;
            this.bsEv.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsEv_ListChanged);
            // 
            // dgvEv
            // 
            this.dgvEv.AutoGenerateColumns = false;
            this.dgvEv.AutoSave = false;
            this.dgvEv.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcTag,
            this.dgcDescr,
            this.dgcID});
            this.dgvEv.DataSource = this.bsEv;
            this.dgvEv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEv.Location = new System.Drawing.Point(0, 0);
            this.dgvEv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvEv.Name = "dgvEv";
            this.dgvEv.RowHeadersWidth = 62;
            this.dgvEv.RowTemplate.Height = 29;
            this.dgvEv.ShowCellToolTips = false;
            this.dgvEv.Size = new System.Drawing.Size(618, 472);
            this.dgvEv.TabIndex = 1;
            this.dgvEv.MyCheckForChanges += new System.EventHandler(this.dgvEv_MyCheckForChanges);
            this.dgvEv.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvEv_UserDeletingRow);
            this.dgvEv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvEv_KeyDown);
            this.dgvEv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvEv_KeyPress);
            // 
            // dgcTag
            // 
            this.dgcTag.DataPropertyName = "TAG";
            this.dgcTag.HeaderText = "kods";
            this.dgcTag.MinimumWidth = 9;
            this.dgcTag.Name = "dgcTag";
            this.dgcTag.Width = 168;
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "DESCR";
            this.dgcDescr.HeaderText = "nosaukums";
            this.dgcDescr.MinimumWidth = 9;
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.Width = 337;
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.MinimumWidth = 9;
            this.dgcID.Name = "dgcID";
            this.dgcID.Visible = false;
            this.dgcID.Width = 168;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 34);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(56, 37);
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(93, 34);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::KlonsA.Properties.Resources.Save1;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(34, 34);
            this.tsbSave.Text = "Saglabāt";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "EVENT_TYPES2",
        "EVENTS",
        null};
            // 
            // Form_EventTypes2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 511);
            this.Controls.Add(this.dgvEv);
            this.Controls.Add(this.bnavEv);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_EventTypes2";
            this.Text = "Papildus notikumi";
            this.Load += new System.EventHandler(this.Form_EventTypes2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnavEv)).EndInit();
            this.bnavEv.ResumeLayout(false);
            this.bnavEv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Components.MyBindingNavigator bnavEv;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private KlonsLIB.Data.MyBindingSource bsEv;
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
        private KlonsLIB.Components.MyDataGridView dgvEv;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
    }
}