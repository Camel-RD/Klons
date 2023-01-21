using KlonsLIB.Components;
using KlonsLIB.Data;
using KlonsFM.UI;

namespace KlonsFM.Forms
{
    partial class Form_AcPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AcPlan));
            this.bnavAcp21 = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bsAcPlan = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.dgvAcp21 = new KlonsLIB.Components.MyDataGridView();
            this.dgcAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcId1 = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcId2 = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonInfo = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tbAcc = new KlonsLIB.Components.MyPickRowTextBox();
            this.tbSearch = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bnavAcp21)).BeginInit();
            this.bnavAcp21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcp21)).BeginInit();
            this.SuspendLayout();
            // 
            // bnavAcp21
            // 
            this.bnavAcp21.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavAcp21.BindingSource = this.bsAcPlan;
            this.bnavAcp21.CountItem = this.bindingNavigatorCountItem;
            this.bnavAcp21.CountItemFormat = " no {0}";
            this.bnavAcp21.DataGrid = this.dgvAcp21;
            this.bnavAcp21.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnavAcp21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavAcp21.ImageScalingSize = new System.Drawing.Size(23, 26);
            this.bnavAcp21.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.toolStripButtonInfo,
            this.tsbSave});
            this.bnavAcp21.Location = new System.Drawing.Point(0, 452);
            this.bnavAcp21.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavAcp21.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavAcp21.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavAcp21.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavAcp21.Name = "bnavAcp21";
            this.bnavAcp21.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavAcp21.SaveItem = null;
            this.bnavAcp21.Size = new System.Drawing.Size(929, 39);
            this.bnavAcp21.TabIndex = 0;
            this.bnavAcp21.Text = "bindingNavigator1";
            this.bnavAcp21.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.acP21BindingNavigator_ItemDeleting);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(92, 34);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            this.bindingNavigatorAddNewItem.ToolTipText = "Jauns (Ctrl+Insert)";
            // 
            // bsAcPlan
            // 
            this.bsAcPlan.AutoSaveOnDelete = true;
            this.bsAcPlan.DataMember = "AcP21";
            this.bsAcPlan.MyDataSource = "KlonsData";
            this.bsAcPlan.Name2 = "AcPlan";
            this.bsAcPlan.Sort = "Ac";
            this.bsAcPlan.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsAcPlan_ListChanged);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 34);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Skaits";
            // 
            // dgvAcp21
            // 
            this.dgvAcp21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAcp21.AutoGenerateColumns = false;
            this.dgvAcp21.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAcp21.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcp21.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcAc,
            this.dgcName,
            this.dgcId1,
            this.dgcId2});
            this.dgvAcp21.DataSource = this.bsAcPlan;
            this.dgvAcp21.Location = new System.Drawing.Point(0, 40);
            this.dgvAcp21.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAcp21.Name = "dgvAcp21";
            this.dgvAcp21.RowHeadersWidth = 53;
            this.dgvAcp21.RowTemplate.Height = 28;
            this.dgvAcp21.Size = new System.Drawing.Size(929, 418);
            this.dgvAcp21.TabIndex = 2;
            this.dgvAcp21.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.acP21DataGridView_MyKeyDown);
            this.dgvAcp21.MyCheckForChanges += new System.EventHandler(this.dgvAcp21_MyCheckForChanges);
            this.dgvAcp21.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.acP21DataGridView_CellDoubleClick);
            this.dgvAcp21.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.acP21DataGridView_UserDeletingRow);
            this.dgvAcp21.KeyDown += new System.Windows.Forms.KeyEventHandler(this.acP21DataGridView_KeyDown);
            this.dgvAcp21.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.acP21DataGridView_KeyPress);
            // 
            // dgcAc
            // 
            this.dgcAc.DataPropertyName = "AC";
            this.dgcAc.HeaderText = "kods";
            this.dgcAc.MinimumWidth = 7;
            this.dgcAc.Name = "dgcAc";
            this.dgcAc.Width = 72;
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "Name";
            this.dgcName.HeaderText = "nosaukums";
            this.dgcName.MinimumWidth = 7;
            this.dgcName.Name = "dgcName";
            this.dgcName.Width = 562;
            // 
            // dgcId1
            // 
            this.dgcId1.ColumnWidths = "50;100";
            this.dgcId1.DataPropertyName = "id1";
            this.dgcId1.DisplayMember = "col1";
            this.dgcId1.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownList;
            this.dgcId1.HeaderText = "paz.np.";
            this.dgcId1.ItemStrings = new string[] {
        "BA;banka",
        "CN;cita nauda",
        "KA;kase"};
            this.dgcId1.MaxDropDownItems = 15;
            this.dgcId1.MinimumWidth = 7;
            this.dgcId1.Name = "dgcId1";
            this.dgcId1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcId1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcId1.ToolTipText = "pazīme naudas plūsmai";
            this.dgcId1.ValueMember = "col1";
            this.dgcId1.Width = 90;
            // 
            // dgcId2
            // 
            this.dgcId2.ColumnWidths = "50;100";
            this.dgcId2.DataPropertyName = "id2";
            this.dgcId2.DisplayMember = "col1";
            this.dgcId2.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownList;
            this.dgcId2.HeaderText = "paz.2";
            this.dgcId2.ItemStrings = new string[] {
        "DB;debitoriem",
        "KR;kreditoriem"};
            this.dgcId2.MaxDropDownItems = 15;
            this.dgcId2.MinimumWidth = 7;
            this.dgcId2.Name = "dgcId2";
            this.dgcId2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcId2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcId2.ValueMember = "col1";
            this.dgcId2.Width = 90;
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
            // toolStripButtonInfo
            // 
            this.toolStripButtonInfo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonInfo.Image")));
            this.toolStripButtonInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInfo.Name = "toolStripButtonInfo";
            this.toolStripButtonInfo.Size = new System.Drawing.Size(78, 34);
            this.toolStripButtonInfo.Text = "Info";
            this.toolStripButtonInfo.Click += new System.EventHandler(this.toolStripButtonInfo_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(34, 34);
            this.tsbSave.Text = "Sagalbāt datus";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tbAcc
            // 
            this.tbAcc.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbAcc.DataMember = null;
            this.tbAcc.DataSource = this.bsAcPlan;
            this.tbAcc.Location = new System.Drawing.Point(62, 8);
            this.tbAcc.Margin = new System.Windows.Forms.Padding(2);
            this.tbAcc.Name = "tbAcc";
            this.tbAcc.SelectedIndex = -1;
            this.tbAcc.Size = new System.Drawing.Size(92, 26);
            this.tbAcc.TabIndex = 0;
            this.tbAcc.RowSelectedEvent += new KlonsLIB.Components.RowSelectedEventHandler(this.tbAcc_RowSelectedEvent);
            this.tbAcc.Enter += new System.EventHandler(this.tbAcc_Enter);
            // 
            // tbSearch
            // 
            this.tbSearch.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSearch.Location = new System.Drawing.Point(230, 8);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(132, 26);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kods:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "meklēt:";
            // 
            // Form_AcPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 491);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.tbAcc);
            this.Controls.Add(this.dgvAcp21);
            this.Controls.Add(this.bnavAcp21);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_AcPlan";
            this.Text = "Kontu plāns";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAcPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnavAcp21)).EndInit();
            this.bnavAcp21.ResumeLayout(false);
            this.bnavAcp21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcp21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingNavigator bnavAcp21;
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
        private MyBindingSource bsAcPlan;
        private MyDataGridView dgvAcp21;
        private MyPickRowTextBox tbAcc;
        private MyTextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton toolStripButtonInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private MyDgvMcCBColumn dgcId1;
        private MyDgvMcCBColumn dgcId2;
    }
}