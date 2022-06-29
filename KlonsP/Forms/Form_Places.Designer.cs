namespace KlonsP.Forms
{
    partial class Form_Places
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Places));
            this.bsPlaces = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvPlaces = new KlonsLIB.Components.MyDataGridView();
            this.dgcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcGroup = new KlonsLIB.Components.MyDgvCheckBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnPlaces = new KlonsLIB.Components.MyBindingNavigator();
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
            this.bindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnPlaces)).BeginInit();
            this.bnPlaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bsPlaces
            // 
            this.bsPlaces.DataMember = "PLACES";
            this.bsPlaces.MyDataSource = "KlonsData";
            this.bsPlaces.Sort = "CODE";
            this.bsPlaces.UseDataGridView = this.dgvPlaces;
            this.bsPlaces.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsPlaces_ListChanged);
            // 
            // dgvPlaces
            // 
            this.dgvPlaces.AutoGenerateColumns = false;
            this.dgvPlaces.AutoSave = false;
            this.dgvPlaces.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlaces.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlaces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcCode,
            this.dgcDescr,
            this.dgcAddr,
            this.dgcGroup,
            this.dgcID});
            this.dgvPlaces.DataSource = this.bsPlaces;
            this.dgvPlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlaces.Location = new System.Drawing.Point(0, 0);
            this.dgvPlaces.Name = "dgvPlaces";
            this.dgvPlaces.RowTemplate.Height = 24;
            this.dgvPlaces.Size = new System.Drawing.Size(929, 296);
            this.dgvPlaces.TabIndex = 0;
            this.dgvPlaces.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPlaces_MyKeyDown);
            this.dgvPlaces.MyCheckForChanges += new System.EventHandler(this.dgvPlaces_MyCheckForChanges);
            this.dgvPlaces.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPlaces_CellBeginEdit);
            this.dgvPlaces.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlaces_CellDoubleClick);
            this.dgvPlaces.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPlaces_UserDeletingRow);
            this.dgvPlaces.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvPlaces_KeyPress);
            // 
            // dgcCode
            // 
            this.dgcCode.DataPropertyName = "CODE";
            this.dgcCode.HeaderText = "kods";
            this.dgcCode.Name = "dgcCode";
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "DESCR";
            this.dgcDescr.HeaderText = "nosaukums";
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.Width = 400;
            // 
            // dgcAddr
            // 
            this.dgcAddr.DataPropertyName = "ADDR";
            this.dgcAddr.HeaderText = "adrese";
            this.dgcAddr.Name = "dgcAddr";
            this.dgcAddr.Width = 300;
            // 
            // dgcGroup
            // 
            this.dgcGroup.DataPropertyName = "GROUP";
            this.dgcGroup.FalseValue = "0";
            this.dgcGroup.HeaderText = "kopā";
            this.dgcGroup.Name = "dgcGroup";
            this.dgcGroup.TrueValue = "1";
            this.dgcGroup.Width = 50;
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.Name = "dgcID";
            this.dgcID.Visible = false;
            // 
            // bnPlaces
            // 
            this.bnPlaces.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnPlaces.BindingSource = this.bsPlaces;
            this.bnPlaces.CountItem = this.bindingNavigatorCountItem;
            this.bnPlaces.CountItemFormat = " no {0}";
            this.bnPlaces.DataGrid = this.dgvPlaces;
            this.bnPlaces.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnPlaces.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnPlaces.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnPlaces.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorSaveItem});
            this.bnPlaces.Location = new System.Drawing.Point(0, 296);
            this.bnPlaces.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnPlaces.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnPlaces.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnPlaces.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnPlaces.Name = "bnPlaces";
            this.bnPlaces.PositionItem = this.bindingNavigatorPositionItem;
            this.bnPlaces.SaveItem = this.bindingNavigatorSaveItem;
            this.bnPlaces.Size = new System.Drawing.Size(929, 32);
            this.bnPlaces.TabIndex = 1;
            this.bnPlaces.Text = "myBindingNavigator1";
            this.bnPlaces.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnPlaces_ItemDeleting);
            this.bnPlaces.SaveClicked += new System.EventHandler(this.bnPlaces_SaveClicked);
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
            // bindingNavigatorSaveItem
            // 
            this.bindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorSaveItem.Image")));
            this.bindingNavigatorSaveItem.Name = "bindingNavigatorSaveItem";
            this.bindingNavigatorSaveItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorSaveItem.Text = "Saglabāt";
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "PLACES",
        null};
            // 
            // Form_Places
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 328);
            this.Controls.Add(this.dgvPlaces);
            this.Controls.Add(this.bnPlaces);
            this.Name = "Form_Places";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Atrašanās vietas";
            this.Load += new System.EventHandler(this.Form_Places_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPlaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnPlaces)).EndInit();
            this.bnPlaces.ResumeLayout(false);
            this.bnPlaces.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsPlaces;
        private KlonsLIB.Components.MyDataGridView dgvPlaces;
        private KlonsLIB.Components.MyBindingNavigator bnPlaces;
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
        private System.Windows.Forms.ToolStripButton bindingNavigatorSaveItem;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAddr;
        private KlonsLIB.Components.MyDgvCheckBoxColumn dgcGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
    }
}