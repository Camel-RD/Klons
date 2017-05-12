using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.Forms
{
    partial class Form_Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Users));
            this.bsUsers = new KlonsLIB.Data.MyBindingSource();
            this.bnavUsers = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.dgvUsers = new KlonsLIB.Components.MyDataGridView();
            this.dgcUsersName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUsersPSW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUsersTp = new KlonsLIB.Components.MyDgvMcCBColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.bsUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavUsers)).BeginInit();
            this.bnavUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // bsUsers
            // 
            this.bsUsers.AutoSaveOnDelete = true;
            this.bsUsers.DataMember = "TUsers";
            this.bsUsers.Filter = "nm <> \'SYSTEM\'";
            this.bsUsers.MyDataSource = "KlonsData";
            this.bsUsers.Name2 = "bsUsers";
            this.bsUsers.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsUsers_ListChanged);
            // 
            // bnavUsers
            // 
            this.bnavUsers.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavUsers.BindingSource = this.bsUsers;
            this.bnavUsers.CountItem = this.bindingNavigatorCountItem;
            this.bnavUsers.CountItemFormat = " no {0}";
            this.bnavUsers.DataGrid = this.dgvUsers;
            this.bnavUsers.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnavUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavUsers.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnavUsers.Location = new System.Drawing.Point(0, 280);
            this.bnavUsers.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavUsers.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavUsers.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavUsers.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavUsers.Name = "bnavUsers";
            this.bnavUsers.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavUsers.Size = new System.Drawing.Size(400, 32);
            this.bnavUsers.TabIndex = 0;
            this.bnavUsers.Text = "bindingNavigator1";
            this.bnavUsers.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavUsers_ItemDeleting);
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
            // dgvUsers
            // 
            this.dgvUsers.AutoGenerateColumns = false;
            this.dgvUsers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcUsersName,
            this.dgcUsersPSW,
            this.dgcUsersTp});
            this.dgvUsers.DataSource = this.bsUsers;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 0);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(2);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowTemplate.Height = 19;
            this.dgvUsers.Size = new System.Drawing.Size(400, 280);
            this.dgvUsers.TabIndex = 1;
            this.dgvUsers.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUsers_MyKeyDown);
            this.dgvUsers.MyCheckForChanges += new System.EventHandler(this.dgvUsers_MyCheckForChanges);
            this.dgvUsers.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvUsers_RowValidating);
            this.dgvUsers.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvUsers_UserDeletingRow);
            // 
            // dgcUsersName
            // 
            this.dgcUsersName.DataPropertyName = "nm";
            this.dgcUsersName.HeaderText = "vārds";
            this.dgcUsersName.Name = "dgcUsersName";
            this.dgcUsersName.ToolTipText = "lietotāja vārds (kods)";
            this.dgcUsersName.Width = 80;
            // 
            // dgcUsersPSW
            // 
            this.dgcUsersPSW.DataPropertyName = "psw";
            this.dgcUsersPSW.HeaderText = "parole";
            this.dgcUsersPSW.Name = "dgcUsersPSW";
            this.dgcUsersPSW.ToolTipText = "lietotāja parole vai tukšs";
            this.dgcUsersPSW.Width = 80;
            // 
            // dgcUsersTp
            // 
            this.dgcUsersTp.ColumnNames = new string[] {
        "col1",
        "col2"};
            this.dgcUsersTp.ColumnWidths = "20;100";
            this.dgcUsersTp.DataPropertyName = "tp";
            this.dgcUsersTp.DisplayMember = "col1";
            this.dgcUsersTp.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownList;
            this.dgcUsersTp.HeaderText = "grupa";
            this.dgcUsersTp.ItemStrings = new string[] {
        "A;administrators",
        "B;pārējie"};
            this.dgcUsersTp.MaxDropDownItems = 15;
            this.dgcUsersTp.Name = "dgcUsersTp";
            this.dgcUsersTp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcUsersTp.ToolTipText = "Lietotāju grupa (administrators / pārējie)";
            this.dgcUsersTp.ValueMember = "col1";
            this.dgcUsersTp.Width = 80;
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
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(25, 25);
            this.tsbSave.Text = "Saglabāt datus";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // Form_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 312);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.bnavUsers);
            this.Name = "Form_Users";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lietotāji";
            this.Load += new System.EventHandler(this.FormUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavUsers)).EndInit();
            this.bnavUsers.ResumeLayout(false);
            this.bnavUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingSource bsUsers;
        private MyBindingNavigator bnavUsers;
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
        private MyDataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUsersName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUsersPSW;
        private MyDgvMcCBColumn dgcUsersTp;
    }
}