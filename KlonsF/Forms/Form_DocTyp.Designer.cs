using KlonsLIB.Components;
using KlonsLIB.Data;
using KlonsF.UI;

namespace KlonsF.Forms
{
    partial class Form_DocTyp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DocTyp));
            this.bnavDocTyp = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bsDocTyp = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbInfo = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tbSearch = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbId = new KlonsLIB.Components.MyPickRowTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvDocTyp = new KlonsLIB.Components.MyDataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvDocTypA = new KlonsLIB.Components.MyDataGridView();
            this.dgcDocTypAId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocTypAName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDocTypA = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsDocTypB = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.dgvDocTypB = new KlonsLIB.Components.MyDataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDocTyp2 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.dgcDocTypId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocTypId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocTypPvnpaz = new KlonsLIB.Components.MyDgvMcCBColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bnavDocTyp)).BeginInit();
            this.bnavDocTyp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocTypA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTypA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTypB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocTypB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTyp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bnavDocTyp
            // 
            this.bnavDocTyp.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavDocTyp.BindingSource = this.bsDocTyp;
            this.bnavDocTyp.CountItem = this.bindingNavigatorCountItem;
            this.bnavDocTyp.CountItemFormat = " no {0}";
            this.bnavDocTyp.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnavDocTyp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavDocTyp.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavDocTyp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
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
            this.tsbInfo,
            this.tsbSave});
            this.bnavDocTyp.Location = new System.Drawing.Point(0, 465);
            this.bnavDocTyp.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavDocTyp.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavDocTyp.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavDocTyp.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavDocTyp.Name = "bnavDocTyp";
            this.bnavDocTyp.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavDocTyp.SaveItem = null;
            this.bnavDocTyp.Size = new System.Drawing.Size(721, 39);
            this.bnavDocTyp.TabIndex = 0;
            this.bnavDocTyp.Text = "bindingNavigator1";
            this.bnavDocTyp.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavDocTyp_ItemDeleting);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(90, 34);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            this.bindingNavigatorAddNewItem.ToolTipText = "Jauns (Shift+Insert)";
            // 
            // bsDocTyp
            // 
            this.bsDocTyp.AutoSaveOnDelete = true;
            this.bsDocTyp.DataMember = "DocTyp";
            this.bsDocTyp.MyDataSource = "KlonsData";
            this.bsDocTyp.Name2 = "bsDocTyp";
            this.bsDocTyp.Sort = "";
            this.bsDocTyp.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsDocTyp_ListChanged);
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
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(91, 34);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
            this.bindingNavigatorDeleteItem.ToolTipText = "Dzēst (Ctrl+Delete)";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(187, 34);
            this.toolStripLabel1.Text = "Dokumentu veids:";
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
            // tsbInfo
            // 
            this.tsbInfo.Image = global::KlonsF.Properties.Resources.information1;
            this.tsbInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInfo.Name = "tsbInfo";
            this.tsbInfo.Size = new System.Drawing.Size(76, 34);
            this.tsbInfo.Text = "Info";
            this.tsbInfo.Click += new System.EventHandler(this.tsbInfo_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(34, 25);
            this.tsbSave.Text = "Saglabāt datus";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSearch.Location = new System.Drawing.Point(251, 6);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(157, 26);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "kods:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "meklēt:";
            // 
            // tbId
            // 
            this.tbId.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbId.DataMember = null;
            this.tbId.DataSource = this.bsDocTyp;
            this.tbId.Location = new System.Drawing.Point(61, 6);
            this.tbId.Margin = new System.Windows.Forms.Padding(2);
            this.tbId.Name = "tbId";
            this.tbId.SelectedIndex = -1;
            this.tbId.Size = new System.Drawing.Size(120, 26);
            this.tbId.TabIndex = 0;
            this.tbId.RowSelectedEvent += new KlonsLIB.Components.RowSelectedEventHandler(this.tbId_RowSelectedEvent);
            this.tbId.Enter += new System.EventHandler(this.tbId_Enter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvDocTyp);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(721, 432);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 8;
            // 
            // dgvDocTyp
            // 
            this.dgvDocTyp.AutoGenerateColumns = false;
            this.dgvDocTyp.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDocTyp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocTyp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDocTypId,
            this.dgcName,
            this.dgcDocTypId2,
            this.dgcDocTypPvnpaz});
            this.dgvDocTyp.DataSource = this.bsDocTyp;
            this.dgvDocTyp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocTyp.Location = new System.Drawing.Point(0, 0);
            this.dgvDocTyp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDocTyp.Name = "dgvDocTyp";
            this.dgvDocTyp.RowHeadersWidth = 62;
            this.dgvDocTyp.RowTemplate.Height = 23;
            this.dgvDocTyp.Size = new System.Drawing.Size(721, 265);
            this.dgvDocTyp.TabIndex = 4;
            this.dgvDocTyp.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDocTyp_MyKeyDown);
            this.dgvDocTyp.MyCheckForChanges += new System.EventHandler(this.dgvDocTyp_MyCheckForChanges);
            this.dgvDocTyp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocTyp_CellDoubleClick);
            this.dgvDocTyp.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDocTyp_UserDeletingRow);
            this.dgvDocTyp.Enter += new System.EventHandler(this.dgvDocTyp_Enter);
            this.dgvDocTyp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDocTyp_KeyDown);
            this.dgvDocTyp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvDocTyp_KeyPress);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvDocTypA);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvDocTypB);
            this.splitContainer2.Size = new System.Drawing.Size(721, 163);
            this.splitContainer2.SplitterDistance = 491;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvDocTypA
            // 
            this.dgvDocTypA.AutoGenerateColumns = false;
            this.dgvDocTypA.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDocTypA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocTypA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDocTypAId,
            this.dgcDocTypAName});
            this.dgvDocTypA.DataSource = this.bsDocTypA;
            this.dgvDocTypA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocTypA.Location = new System.Drawing.Point(0, 0);
            this.dgvDocTypA.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDocTypA.Name = "dgvDocTypA";
            this.dgvDocTypA.RowHeadersWidth = 62;
            this.dgvDocTypA.RowTemplate.Height = 23;
            this.dgvDocTypA.Size = new System.Drawing.Size(491, 163);
            this.dgvDocTypA.TabIndex = 7;
            this.dgvDocTypA.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDocTypA_MyKeyDown);
            this.dgvDocTypA.MyCheckForChanges += new System.EventHandler(this.dgvDocTyp_MyCheckForChanges);
            this.dgvDocTypA.CurrentCellChanged += new System.EventHandler(this.dgvDocTypA_CurrentCellChanged);
            this.dgvDocTypA.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDocTypA_RowValidating);
            this.dgvDocTypA.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDocTypA_UserDeletingRow);
            this.dgvDocTypA.Enter += new System.EventHandler(this.dgvDocTypA_Enter);
            // 
            // dgcDocTypAId
            // 
            this.dgcDocTypAId.DataPropertyName = "id";
            this.dgcDocTypAId.HeaderText = "kods";
            this.dgcDocTypAId.MinimumWidth = 9;
            this.dgcDocTypAId.Name = "dgcDocTypAId";
            this.dgcDocTypAId.ToolTipText = "dokumentu grupas kods";
            this.dgcDocTypAId.Width = 90;
            // 
            // dgcDocTypAName
            // 
            this.dgcDocTypAName.DataPropertyName = "Name";
            this.dgcDocTypAName.HeaderText = "nosaukums";
            this.dgcDocTypAName.MinimumWidth = 9;
            this.dgcDocTypAName.Name = "dgcDocTypAName";
            this.dgcDocTypAName.ToolTipText = "dokumentu grupas nosaukums";
            this.dgcDocTypAName.Width = 270;
            // 
            // bsDocTypA
            // 
            this.bsDocTypA.AutoSaveChildrenDelete = true;
            this.bsDocTypA.AutoSaveOnDelete = true;
            this.bsDocTypA.ChildBS = this.bsDocTypB;
            this.bsDocTypA.DataMember = "DocTypA";
            this.bsDocTypA.MyDataSource = "KlonsData";
            this.bsDocTypA.Name2 = "bsDocTypA";
            this.bsDocTypA.Sort = "id";
            this.bsDocTypA.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsDocTyp_ListChanged);
            // 
            // bsDocTypB
            // 
            this.bsDocTypB.AutoSaveOnDelete = true;
            this.bsDocTypB.DataMember = "FK_DOCTYPB_IDA_DOCTYPA_ID";
            this.bsDocTypB.DataSource = this.bsDocTypA;
            this.bsDocTypB.Name2 = "bsDocTypB";
            this.bsDocTypB.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsDocTyp_ListChanged);
            // 
            // dgvDocTypB
            // 
            this.dgvDocTypB.AutoGenerateColumns = false;
            this.dgvDocTypB.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDocTypB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocTypB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn});
            this.dgvDocTypB.DataSource = this.bsDocTypB;
            this.dgvDocTypB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocTypB.Location = new System.Drawing.Point(0, 0);
            this.dgvDocTypB.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDocTypB.Name = "dgvDocTypB";
            this.dgvDocTypB.RowHeadersWidth = 62;
            this.dgvDocTypB.Size = new System.Drawing.Size(227, 163);
            this.dgvDocTypB.TabIndex = 8;
            this.dgvDocTypB.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDocTypB_MyKeyDown);
            this.dgvDocTypB.MyCheckForChanges += new System.EventHandler(this.dgvDocTyp_MyCheckForChanges);
            this.dgvDocTypB.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDocTypB_UserDeletingRow);
            this.dgvDocTypB.Enter += new System.EventHandler(this.dgvDocTypB_Enter);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 90;
            // 
            // bsDocTyp2
            // 
            this.bsDocTyp2.AutoSaveOnDelete = true;
            this.bsDocTyp2.DataMember = "DocTyp";
            this.bsDocTyp2.MyDataSource = "KlonsData";
            this.bsDocTyp2.Name2 = "bsDocTyp2";
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "DocTyp",
        "DocTypA",
        "DocTypB",
        null};
            // 
            // dgcDocTypId
            // 
            this.dgcDocTypId.DataPropertyName = "id";
            this.dgcDocTypId.HeaderText = "kods";
            this.dgcDocTypId.MinimumWidth = 9;
            this.dgcDocTypId.Name = "dgcDocTypId";
            this.dgcDocTypId.Width = 90;
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "Name";
            this.dgcName.HeaderText = "nosaukums";
            this.dgcName.MinimumWidth = 9;
            this.dgcName.Name = "dgcName";
            this.dgcName.Width = 320;
            // 
            // dgcDocTypId2
            // 
            this.dgcDocTypId2.DataPropertyName = "id1";
            this.dgcDocTypId2.HeaderText = "kods2";
            this.dgcDocTypId2.MinimumWidth = 9;
            this.dgcDocTypId2.Name = "dgcDocTypId2";
            this.dgcDocTypId2.Width = 90;
            // 
            // dgcDocTypPvnpaz
            // 
            this.dgcDocTypPvnpaz.ColumnNames = new string[] {
        "col1",
        "col2"};
            this.dgcDocTypPvnpaz.ColumnWidths = "20;200";
            this.dgcDocTypPvnpaz.DataPropertyName = "pvnpaz";
            this.dgcDocTypPvnpaz.DisplayMember = "col1";
            this.dgcDocTypPvnpaz.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownList;
            this.dgcDocTypPvnpaz.HeaderText = "pvn.paz.";
            this.dgcDocTypPvnpaz.ItemStrings = new string[] {
        "1;nodokļa rēķins",
        "2;kases čeks vai kvīts",
        "3;bezskaidras naudas maksājuma dokuments",
        "4;kredītrēķins",
        "5;cits",
        "6;muitas deklarācija"};
            this.dgcDocTypPvnpaz.MaxDropDownItems = 15;
            this.dgcDocTypPvnpaz.MinimumWidth = 9;
            this.dgcDocTypPvnpaz.Name = "dgcDocTypPvnpaz";
            this.dgcDocTypPvnpaz.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcDocTypPvnpaz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcDocTypPvnpaz.ToolTipText = "PVN dokumenta pazīme";
            this.dgcDocTypPvnpaz.ValueMember = "col1";
            this.dgcDocTypPvnpaz.Width = 90;
            // 
            // Form_DocTyp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 504);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.bnavDocTyp);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_DocTyp";
            this.Text = "Dokumentu veidi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormDocTyp_Load);
            this.Shown += new System.EventHandler(this.FormDocTyp_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bnavDocTyp)).EndInit();
            this.bnavDocTyp.ResumeLayout(false);
            this.bnavDocTyp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTyp)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocTyp)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocTypA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTypA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTypB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocTypB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTyp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingNavigator bnavDocTyp;
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
        private MyBindingSource bsDocTyp;
        private MyTextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MyPickRowTextBox tbId;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MyDataGridView dgvDocTyp;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private MyDataGridView dgvDocTypA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocTypAId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocTypAName;
        private MyBindingSource bsDocTypA;
        private MyDataGridView dgvDocTypB;
        private MyBindingSource bsDocTyp2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsbInfo;
        private MyAdapterManager myAdapterManager1;
        private MyBindingSource2 bsDocTypB;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocTypId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocTypId2;
        private MyDgvMcCBColumn dgcDocTypPvnpaz;
    }
}