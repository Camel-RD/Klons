namespace KlonsP.Forms
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
            this.bsDepartments = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvDepartments = new KlonsLIB.Components.MyDataGridView();
            this.dgcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcGroup = new KlonsLIB.Components.MyDgvCheckBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnDepartments = new KlonsLIB.Components.MyBindingNavigator();
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
            ((System.ComponentModel.ISupportInitialize)(this.bsDepartments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnDepartments)).BeginInit();
            this.bnDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bsDepartments
            // 
            this.bsDepartments.DataMember = "DEPARTMENTS";
            this.bsDepartments.MyDataSource = "KlonsData";
            this.bsDepartments.Sort = "CODE";
            this.bsDepartments.UseDataGridView = this.dgvDepartments;
            this.bsDepartments.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsDepartments_ListChanged);
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.AutoGenerateColumns = false;
            this.dgvDepartments.AutoSave = false;
            this.dgvDepartments.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepartments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcCode,
            this.dgcDescr,
            this.dgcGroup,
            this.dgcID});
            this.dgvDepartments.DataSource = this.bsDepartments;
            this.dgvDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartments.Location = new System.Drawing.Point(0, 0);
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.RowTemplate.Height = 24;
            this.dgvDepartments.Size = new System.Drawing.Size(675, 296);
            this.dgvDepartments.TabIndex = 0;
            this.dgvDepartments.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDepartments_MyKeyDown);
            this.dgvDepartments.MyCheckForChanges += new System.EventHandler(this.dgvDepartments_MyCheckForChanges);
            this.dgvDepartments.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDepartments_CellBeginEdit);
            this.dgvDepartments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartments_CellDoubleClick);
            this.dgvDepartments.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDepartments_UserDeletingRow);
            this.dgvDepartments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvDepartments_KeyPress);
            // 
            // dgcCode
            // 
            this.dgcCode.DataPropertyName = "CODE";
            this.dgcCode.HeaderText = "kods";
            this.dgcCode.Name = "dgcCode";
            this.dgcCode.ToolTipText = "apakšstruktūrvienību summēšanai";
            this.dgcCode.Width = 150;
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "DESCR";
            this.dgcDescr.HeaderText = "nosaukums";
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.Width = 400;
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
            // bnDepartments
            // 
            this.bnDepartments.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnDepartments.BindingSource = this.bsDepartments;
            this.bnDepartments.CountItem = this.bindingNavigatorCountItem;
            this.bnDepartments.CountItemFormat = " no {0}";
            this.bnDepartments.DataGrid = this.dgvDepartments;
            this.bnDepartments.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnDepartments.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnDepartments.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnDepartments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnDepartments.Location = new System.Drawing.Point(0, 296);
            this.bnDepartments.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnDepartments.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnDepartments.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnDepartments.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnDepartments.Name = "bnDepartments";
            this.bnDepartments.PositionItem = this.bindingNavigatorPositionItem;
            this.bnDepartments.SaveItem = this.bindingNavigatorSaveItem;
            this.bnDepartments.Size = new System.Drawing.Size(675, 32);
            this.bnDepartments.TabIndex = 1;
            this.bnDepartments.Text = "myBindingNavigator1";
            this.bnDepartments.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnDepartments_ItemDeleting);
            this.bnDepartments.SaveClicked += new System.EventHandler(this.bnDepartments_SaveClicked);
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
        "DEPARTMENTS",
        null};
            // 
            // Form_Departments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 328);
            this.Controls.Add(this.dgvDepartments);
            this.Controls.Add(this.bnDepartments);
            this.Name = "Form_Departments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Struktūrvienības";
            this.Load += new System.EventHandler(this.Form_Departments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsDepartments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnDepartments)).EndInit();
            this.bnDepartments.ResumeLayout(false);
            this.bnDepartments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsDepartments;
        private KlonsLIB.Components.MyDataGridView dgvDepartments;
        private KlonsLIB.Components.MyBindingNavigator bnDepartments;
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
        private KlonsLIB.Components.MyDgvCheckBoxColumn dgcGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
    }
}