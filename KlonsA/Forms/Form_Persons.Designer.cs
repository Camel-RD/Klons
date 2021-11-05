using KlonsLIB.Components;

namespace KlonsA.Forms
{
    partial class Form_Persons
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Persons));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsPersons = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvPersons = new KlonsLIB.Components.MyDataGridView();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcFName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUsed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgcUsedDt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUsedDt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnavNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.tslLabel = new System.Windows.Forms.ToolStripLabel();
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
            this.tbSearch = new KlonsLIB.Components.MyTextBox();
            this.tbID = new KlonsLIB.Components.MyPickRowTextBox();
            this.cbActive = new KlonsLIB.Components.MyMcFlatComboBox();
            this.MyAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvAmati = new KlonsLIB.Components.MyDataGridView();
            this.dgcAmatiID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAmatiTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAmatiDep = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsDep = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcAmatiUsed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgcAmatiUsedDt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAmatiUsedDt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAmati = new KlonsLIB.Data.MyBindingSource2(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavNav)).BeginInit();
            this.bnavNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyAdapterManager1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).BeginInit();
            this.SuspendLayout();
            // 
            // bsPersons
            // 
            this.bsPersons.DataMember = "PERSONS";
            this.bsPersons.MyDataSource = "KlonsData";
            this.bsPersons.Sort = "LNAME, FNAME";
            this.bsPersons.UseDataGridView = this.dgvPersons;
            this.bsPersons.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsPersons_ListChanged);
            // 
            // dgvPersons
            // 
            this.dgvPersons.AllowUserToDeleteRows = false;
            this.dgvPersons.AllowUserToResizeRows = false;
            this.dgvPersons.AutoGenerateColumns = false;
            this.dgvPersons.AutoSave = false;
            this.dgvPersons.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersons.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcID,
            this.dgcFName,
            this.dgcLName,
            this.dgcBirthDate,
            this.dgcPK,
            this.dgcUsed,
            this.dgcUsedDt1,
            this.dgcUsedDt2});
            this.dgvPersons.DataSource = this.bsPersons;
            this.dgvPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersons.Location = new System.Drawing.Point(0, 0);
            this.dgvPersons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPersons.Name = "dgvPersons";
            this.dgvPersons.RowHeadersWidth = 62;
            this.dgvPersons.RowTemplate.Height = 29;
            this.dgvPersons.Size = new System.Drawing.Size(786, 326);
            this.dgvPersons.TabIndex = 3;
            this.dgvPersons.MyCheckForChanges += new System.EventHandler(this.dgvPersons_MyCheckForChanges);
            this.dgvPersons.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersons_CellDoubleClick);
            this.dgvPersons.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvPersons_CellParsing);
            this.dgvPersons.CurrentCellChanged += new System.EventHandler(this.dgvPersons_CurrentCellChanged);
            this.dgvPersons.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPersons_UserDeletingRow);
            this.dgvPersons.Enter += new System.EventHandler(this.dgvPersons_Enter);
            this.dgvPersons.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPersons_KeyDown);
            this.dgvPersons.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvPersons_KeyPress);
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.MinimumWidth = 9;
            this.dgcID.Name = "dgcID";
            this.dgcID.Visible = false;
            this.dgcID.Width = 90;
            // 
            // dgcFName
            // 
            this.dgcFName.DataPropertyName = "FNAME";
            this.dgcFName.HeaderText = "vārds";
            this.dgcFName.MinimumWidth = 9;
            this.dgcFName.Name = "dgcFName";
            this.dgcFName.Width = 108;
            // 
            // dgcLName
            // 
            this.dgcLName.DataPropertyName = "LNAME";
            this.dgcLName.HeaderText = "uzvārds";
            this.dgcLName.MinimumWidth = 9;
            this.dgcLName.Name = "dgcLName";
            this.dgcLName.Width = 108;
            // 
            // dgcBirthDate
            // 
            this.dgcBirthDate.DataPropertyName = "BIRTH_DATE";
            dataGridViewCellStyle2.Format = "dd.MM.yyyy";
            this.dgcBirthDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcBirthDate.HeaderText = "dzimš. dat.";
            this.dgcBirthDate.MinimumWidth = 9;
            this.dgcBirthDate.Name = "dgcBirthDate";
            this.dgcBirthDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcBirthDate.ToolTipText = "dzimšanas datums";
            this.dgcBirthDate.Width = 95;
            // 
            // dgcPK
            // 
            this.dgcPK.DataPropertyName = "PK";
            this.dgcPK.HeaderText = "pers.kods";
            this.dgcPK.MinimumWidth = 9;
            this.dgcPK.Name = "dgcPK";
            this.dgcPK.Width = 126;
            // 
            // dgcUsed
            // 
            this.dgcUsed.DataPropertyName = "USED";
            this.dgcUsed.FalseValue = "0";
            this.dgcUsed.HeaderText = "aktīvs";
            this.dgcUsed.MinimumWidth = 9;
            this.dgcUsed.Name = "dgcUsed";
            this.dgcUsed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcUsed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcUsed.TrueValue = "1";
            this.dgcUsed.Width = 54;
            // 
            // dgcUsedDt1
            // 
            this.dgcUsedDt1.DataPropertyName = "USED_DT1";
            dataGridViewCellStyle3.Format = "dd.MM.yyyy";
            this.dgcUsedDt1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcUsedDt1.HeaderText = "akrīvs no";
            this.dgcUsedDt1.MinimumWidth = 9;
            this.dgcUsedDt1.Name = "dgcUsedDt1";
            this.dgcUsedDt1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcUsedDt1.Width = 95;
            // 
            // dgcUsedDt2
            // 
            this.dgcUsedDt2.DataPropertyName = "USED_DT2";
            dataGridViewCellStyle4.Format = "dd.MM.yyyy";
            this.dgcUsedDt2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcUsedDt2.HeaderText = "aktīvs līdz";
            this.dgcUsedDt2.MinimumWidth = 9;
            this.dgcUsedDt2.Name = "dgcUsedDt2";
            this.dgcUsedDt2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcUsedDt2.Width = 95;
            // 
            // bnavNav
            // 
            this.bnavNav.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavNav.BindingSource = this.bsPersons;
            this.bnavNav.CountItem = this.bindingNavigatorCountItem;
            this.bnavNav.CountItemFormat = " no {0}";
            this.bnavNav.DeleteItem = null;
            this.bnavNav.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavNav.ImageScalingSize = new System.Drawing.Size(23, 26);
            this.bnavNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslLabel,
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
            this.bnavNav.Location = new System.Drawing.Point(0, 495);
            this.bnavNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavNav.Name = "bnavNav";
            this.bnavNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavNav.SaveItem = null;
            this.bnavNav.Size = new System.Drawing.Size(786, 39);
            this.bnavNav.TabIndex = 3;
            this.bnavNav.Text = "myBindingNavigator1";
            this.bnavNav.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavNav_ItemDeleting);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(92, 34);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 34);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // tslLabel
            // 
            this.tslLabel.Name = "tslLabel";
            this.tslLabel.Size = new System.Drawing.Size(115, 34);
            this.tslLabel.Text = "Darbinieki:";
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
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(34, 34);
            this.tsbSave.Text = "toolStripButton1";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSearch.Location = new System.Drawing.Point(278, 0);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(134, 26);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // tbID
            // 
            this.tbID.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbID.ColumnNr = 2;
            this.tbID.DataMember = null;
            this.tbID.DataSource = this.bsPersons;
            this.tbID.Location = new System.Drawing.Point(168, 0);
            this.tbID.Margin = new System.Windows.Forms.Padding(2);
            this.tbID.Name = "tbID";
            this.tbID.SelectedIndex = -1;
            this.tbID.Size = new System.Drawing.Size(100, 26);
            this.tbID.TabIndex = 0;
            this.tbID.RowSelectedEvent += new KlonsLIB.Components.RowSelectedEventHandler(this.tbID_RowSelectedEvent);
            this.tbID.Enter += new System.EventHandler(this.tbID_Enter);
            // 
            // cbActive
            // 
            this.cbActive.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbActive.ColumnNames = new string[0];
            this.cbActive.ColumnWidths = "66";
            this.cbActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbActive.DropDownHeight = 168;
            this.cbActive.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbActive.DropDownWidth = 105;
            this.cbActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbActive.FormattingEnabled = true;
            this.cbActive.GridLineColor = System.Drawing.Color.LightGray;
            this.cbActive.GridLineHorizontal = false;
            this.cbActive.GridLineVertical = false;
            this.cbActive.IntegralHeight = false;
            this.cbActive.Items.AddRange(new object[] {
            "Aktīvie",
            "Visi"});
            this.cbActive.Location = new System.Drawing.Point(422, 0);
            this.cbActive.Margin = new System.Windows.Forms.Padding(2);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(101, 27);
            this.cbActive.TabIndex = 2;
            this.cbActive.SelectedIndexChanged += new System.EventHandler(this.cbActive_SelectedIndexChanged);
            // 
            // MyAdapterManager1
            // 
            this.MyAdapterManager1.MyDataSource = "KlonsData";
            this.MyAdapterManager1.TableNames = new string[] {
        "PERSONS",
        "PERSONS_R",
        "POSITIONS",
        "POSITIONS_R",
        "EVENTS",
        "POSITIONS_PLUSMINUS",
        null};
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(23, 26);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.toolStrip1.Size = new System.Drawing.Size(786, 37);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(91, 30);
            this.toolStripLabel1.Text = " Meklēt:";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(31, 30);
            this.toolStripLabel2.Text = "   ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 37);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvPersons);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvAmati);
            this.splitContainer1.Size = new System.Drawing.Size(786, 458);
            this.splitContainer1.SplitterDistance = 326;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvAmati
            // 
            this.dgvAmati.AllowUserToDeleteRows = false;
            this.dgvAmati.AutoGenerateColumns = false;
            this.dgvAmati.AutoSave = false;
            this.dgvAmati.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAmati.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAmati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAmati.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcAmatiID,
            this.dgcAmatiTitle,
            this.dgcAmatiDep,
            this.dgcAmatiUsed,
            this.dgcAmatiUsedDt1,
            this.dgcAmatiUsedDt2});
            this.dgvAmati.DataSource = this.bsAmati;
            this.dgvAmati.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAmati.Location = new System.Drawing.Point(0, 0);
            this.dgvAmati.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvAmati.Name = "dgvAmati";
            this.dgvAmati.RowHeadersWidth = 62;
            this.dgvAmati.RowTemplate.Height = 29;
            this.dgvAmati.Size = new System.Drawing.Size(786, 127);
            this.dgvAmati.TabIndex = 4;
            this.dgvAmati.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAmati_MyKeyDown);
            this.dgvAmati.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAmati_CellDoubleClick);
            this.dgvAmati.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvAmati_CellParsing);
            this.dgvAmati.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvAmati_CellValidating);
            this.dgvAmati.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAmati_UserDeletingRow);
            this.dgvAmati.Enter += new System.EventHandler(this.dgvAmati_Enter);
            this.dgvAmati.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAmati_KeyDown);
            this.dgvAmati.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvAmati_KeyPress);
            // 
            // dgcAmatiID
            // 
            this.dgcAmatiID.DataPropertyName = "ID";
            this.dgcAmatiID.HeaderText = "ID";
            this.dgcAmatiID.MinimumWidth = 9;
            this.dgcAmatiID.Name = "dgcAmatiID";
            this.dgcAmatiID.Visible = false;
            this.dgcAmatiID.Width = 168;
            // 
            // dgcAmatiTitle
            // 
            this.dgcAmatiTitle.DataPropertyName = "TITLE";
            this.dgcAmatiTitle.HeaderText = "amata nosaukums";
            this.dgcAmatiTitle.MinimumWidth = 9;
            this.dgcAmatiTitle.Name = "dgcAmatiTitle";
            this.dgcAmatiTitle.Width = 225;
            // 
            // dgcAmatiDep
            // 
            this.dgcAmatiDep.DataPropertyName = "IDDEP";
            this.dgcAmatiDep.DataSource = this.bsDep;
            this.dgcAmatiDep.DisplayMember = "ID";
            this.dgcAmatiDep.DisplayStyleForCurrentCellOnly = true;
            this.dgcAmatiDep.HeaderText = "struktūrv.";
            this.dgcAmatiDep.MinimumWidth = 9;
            this.dgcAmatiDep.Name = "dgcAmatiDep";
            this.dgcAmatiDep.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcAmatiDep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcAmatiDep.ValueMember = "ID";
            this.dgcAmatiDep.Width = 225;
            // 
            // bsDep
            // 
            this.bsDep.DataMember = "DEPARTMENTS";
            this.bsDep.MyDataSource = "KlonsData";
            this.bsDep.Name2 = "bsDep";
            // 
            // dgcAmatiUsed
            // 
            this.dgcAmatiUsed.DataPropertyName = "USED";
            this.dgcAmatiUsed.FalseValue = "0";
            this.dgcAmatiUsed.HeaderText = "aktīvs";
            this.dgcAmatiUsed.MinimumWidth = 9;
            this.dgcAmatiUsed.Name = "dgcAmatiUsed";
            this.dgcAmatiUsed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcAmatiUsed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcAmatiUsed.TrueValue = "1";
            this.dgcAmatiUsed.Width = 67;
            // 
            // dgcAmatiUsedDt1
            // 
            this.dgcAmatiUsedDt1.DataPropertyName = "USED_DT1";
            dataGridViewCellStyle6.Format = "dd.MM.yyyy";
            this.dgcAmatiUsedDt1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcAmatiUsedDt1.HeaderText = "aktīvs no";
            this.dgcAmatiUsedDt1.MinimumWidth = 9;
            this.dgcAmatiUsedDt1.Name = "dgcAmatiUsedDt1";
            this.dgcAmatiUsedDt1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcAmatiUsedDt1.Width = 95;
            // 
            // dgcAmatiUsedDt2
            // 
            this.dgcAmatiUsedDt2.DataPropertyName = "USED_DT2";
            dataGridViewCellStyle7.Format = "dd.MM.yyyy";
            this.dgcAmatiUsedDt2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcAmatiUsedDt2.HeaderText = "aktīvs līdz";
            this.dgcAmatiUsedDt2.MinimumWidth = 9;
            this.dgcAmatiUsedDt2.Name = "dgcAmatiUsedDt2";
            this.dgcAmatiUsedDt2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcAmatiUsedDt2.Width = 95;
            // 
            // bsAmati
            // 
            this.bsAmati.DataMember = "FK_POSITIONS_IDP";
            this.bsAmati.DataSource = this.bsPersons;
            this.bsAmati.UseDataGridView = this.dgvAmati;
            this.bsAmati.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsAmati_ListChanged);
            // 
            // Form_Persons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 534);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.bnavNav);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_Persons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Darbinieku saraksts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Persons_FormClosed);
            this.Load += new System.EventHandler(this.Form_Persons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavNav)).EndInit();
            this.bnavNav.ResumeLayout(false);
            this.bnavNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyAdapterManager1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MyBindingNavigator bnavNav;
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
        private KlonsLIB.Data.MyBindingSource bsPersons;
        private MyTextBox tbSearch;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private MyPickRowTextBox tbID;
        private MyMcFlatComboBox cbActive;
        private KlonsLIB.Data.MyAdapterManager MyAdapterManager1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MyDataGridView dgvPersons;
        private MyDataGridView dgvAmati;
        private KlonsLIB.Data.MyBindingSource2 bsAmati;
        private System.Windows.Forms.ToolStripLabel tslLabel;
        private KlonsLIB.Data.MyBindingSource bsDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgcUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUsedDt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUsedDt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAmatiID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAmatiTitle;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcAmatiDep;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgcAmatiUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAmatiUsedDt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAmatiUsedDt2;
    }
}