using KlonsLIB.Components;
using KlonsLIB.Data;
using KlonsF.UI;

namespace KlonsF.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Persons));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem1 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem2 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            this.bnavPersons = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bsPersons = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvPersons = new KlonsLIB.Components.MyDataGridView();
            this.bsBanks = new KlonsLIB.Data.MyBindingSource(this.components);
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
            this.tbSearch = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbClid = new KlonsLIB.Components.MyPickRowTextBox();
            this.cbAct = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgcClid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRegNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPVNRegNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTP = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcTP2 = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcTP3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgcAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAddr2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcATK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBankId = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcBankAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAct = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bnavPersons)).BeginInit();
            this.bnavPersons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBanks)).BeginInit();
            this.SuspendLayout();
            // 
            // bnavPersons
            // 
            this.bnavPersons.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavPersons.BindingSource = this.bsPersons;
            this.bnavPersons.CountItem = this.bindingNavigatorCountItem;
            this.bnavPersons.CountItemFormat = " no {0}";
            this.bnavPersons.DataGrid = this.dgvPersons;
            this.bnavPersons.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnavPersons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavPersons.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavPersons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnavPersons.Location = new System.Drawing.Point(0, 403);
            this.bnavPersons.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavPersons.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavPersons.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavPersons.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavPersons.Name = "bnavPersons";
            this.bnavPersons.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavPersons.SaveItem = null;
            this.bnavPersons.Size = new System.Drawing.Size(801, 32);
            this.bnavPersons.TabIndex = 0;
            this.bnavPersons.Text = "bindingNavigator1";
            this.bnavPersons.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavPersons_ItemDeleting);
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
            // bsPersons
            // 
            this.bsPersons.AutoSaveOnDelete = true;
            this.bsPersons.DataMember = "Persons";
            this.bsPersons.MyDataSource = "KlonsData";
            this.bsPersons.Sort = "";
            this.bsPersons.UseDataGridView = this.dgvPersons;
            this.bsPersons.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsPersons_ListChanged);
            // 
            // dgvPersons
            // 
            this.dgvPersons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPersons.AutoGenerateColumns = false;
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
            this.dgcClid,
            this.dgcName,
            this.dgcRegNr,
            this.dgcPVNRegNr,
            this.dgcTP,
            this.dgcTP2,
            this.dgcTP3,
            this.dgcAddr,
            this.dgcAddr2,
            this.dgcATK,
            this.dgcBankId,
            this.dgcBank,
            this.dgcBankAcc,
            this.dgcPhone,
            this.dgcAct});
            this.dgvPersons.DataSource = this.bsPersons;
            this.dgvPersons.Location = new System.Drawing.Point(0, 28);
            this.dgvPersons.Name = "dgvPersons";
            this.dgvPersons.Size = new System.Drawing.Size(801, 380);
            this.dgvPersons.TabIndex = 3;
            this.dgvPersons.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPersons_MyKeyDown);
            this.dgvPersons.MyCheckForChanges += new System.EventHandler(this.dgvPersons_MyCheckForChanges);
            this.dgvPersons.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersons_CellDoubleClick);
            this.dgvPersons.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersons_CellEndEdit);
            this.dgvPersons.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPersons_UserDeletingRow);
            this.dgvPersons.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPersons_KeyDown);
            this.dgvPersons.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvPersons_KeyPress);
            // 
            // bsBanks
            // 
            this.bsBanks.DataMember = "Banks";
            this.bsBanks.MyDataSource = "KlonsData";
            this.bsBanks.Name2 = "bsBanks";
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
            this.bindingNavigatorMoveNextItem.ToolTipText = "Iet uz nākošo";
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
            this.tsbSave.Size = new System.Drawing.Size(25, 29);
            this.tsbSave.Text = "Saglabāt datus";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSearch.Location = new System.Drawing.Point(223, 5);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(140, 22);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "kods:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "meklēt:";
            // 
            // tbClid
            // 
            this.tbClid.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbClid.DataMember = null;
            this.tbClid.DataSource = this.bsPersons;
            this.tbClid.Location = new System.Drawing.Point(54, 5);
            this.tbClid.Margin = new System.Windows.Forms.Padding(2);
            this.tbClid.Name = "tbClid";
            this.tbClid.SelectedIndex = -1;
            this.tbClid.Size = new System.Drawing.Size(107, 22);
            this.tbClid.TabIndex = 0;
            this.tbClid.RowSelectedEvent += new KlonsLIB.Components.RowSelectedEventHandler(this.tbClid_RowSelectedEvent);
            this.tbClid.Enter += new System.EventHandler(this.tbClid_Enter);
            // 
            // cbAct
            // 
            this.cbAct.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAct.ColumnNames = new string[] {
        "col1"};
            this.cbAct.ColumnWidths = "121";
            this.cbAct.DisplayMember = "col1";
            this.cbAct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAct.DropDownHeight = 136;
            this.cbAct.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbAct.DropDownWidth = 145;
            this.cbAct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAct.FormattingEnabled = true;
            this.cbAct.GridLineColor = System.Drawing.Color.LightGray;
            this.cbAct.GridLineHorizontal = false;
            this.cbAct.GridLineVertical = false;
            this.cbAct.IntegralHeight = false;
            myItem1.Col1 = "Visus";
            myItem2.Col1 = "Aktīvos";
            this.cbAct.Items.AddRange(new object[] {
            myItem1,
            myItem2});
            this.cbAct.ItemStrings = new string[] {
        "Visus",
        "Aktīvos"};
            this.cbAct.Location = new System.Drawing.Point(412, 5);
            this.cbAct.Margin = new System.Windows.Forms.Padding(2);
            this.cbAct.Name = "cbAct";
            this.cbAct.Size = new System.Drawing.Size(82, 23);
            this.cbAct.TabIndex = 5;
            this.cbAct.ValueMember = "col1";
            this.cbAct.SelectedIndexChanged += new System.EventHandler(this.cbAct_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "rādīt:";
            // 
            // dgcClid
            // 
            this.dgcClid.DataPropertyName = "ClId";
            this.dgcClid.HeaderText = "kods";
            this.dgcClid.Name = "dgcClid";
            this.dgcClid.Width = 96;
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "Name";
            this.dgcName.HeaderText = "nosaukums";
            this.dgcName.Name = "dgcName";
            this.dgcName.Width = 250;
            // 
            // dgcRegNr
            // 
            this.dgcRegNr.DataPropertyName = "RegNr";
            this.dgcRegNr.HeaderText = "reģ.nr.";
            this.dgcRegNr.Name = "dgcRegNr";
            this.dgcRegNr.ToolTipText = "Uzņēmuma reģistrācijas numurs, vai personas kods";
            this.dgcRegNr.Width = 112;
            // 
            // dgcPVNRegNr
            // 
            this.dgcPVNRegNr.DataPropertyName = "PVNRegNr";
            this.dgcPVNRegNr.HeaderText = "PVN reģ.nr.";
            this.dgcPVNRegNr.Name = "dgcPVNRegNr";
            this.dgcPVNRegNr.Width = 128;
            // 
            // dgcTP
            // 
            this.dgcTP.ColumnNames = new string[] {
        "col1",
        "col2"};
            this.dgcTP.ColumnWidths = "50;150";
            this.dgcTP.DataPropertyName = "TP";
            this.dgcTP.DisplayMember = "col1";
            this.dgcTP.HeaderText = "veids";
            this.dgcTP.ItemStrings = new string[] {
        "DB;debitors",
        "KR;kreditors"};
            this.dgcTP.MaxDropDownItems = 15;
            this.dgcTP.Name = "dgcTP";
            this.dgcTP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcTP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcTP.ValueMember = "col1";
            this.dgcTP.Width = 48;
            // 
            // dgcTP2
            // 
            this.dgcTP2.ColumnNames = new string[] {
        "col1",
        "col2"};
            this.dgcTP2.DataPropertyName = "TP2";
            this.dgcTP2.DisplayMember = "col1";
            this.dgcTP2.HeaderText = "fp/jp";
            this.dgcTP2.ItemStrings = new string[] {
        "FP;fiziska persona",
        "JP;juridiska persona",
        "DA;darbinieks"};
            this.dgcTP2.MaxDropDownItems = 15;
            this.dgcTP2.Name = "dgcTP2";
            this.dgcTP2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcTP2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcTP2.ValueMember = "col1";
            this.dgcTP2.Width = 40;
            // 
            // dgcTP3
            // 
            this.dgcTP3.DataPropertyName = "TP3";
            this.dgcTP3.FalseValue = "Nav";
            this.dgcTP3.HeaderText = "pvn";
            this.dgcTP3.Name = "dgcTP3";
            this.dgcTP3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcTP3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcTP3.ToolTipText = "vai ir pvn maksātajs";
            this.dgcTP3.TrueValue = "Ir";
            this.dgcTP3.Width = 40;
            // 
            // dgcAddr
            // 
            this.dgcAddr.DataPropertyName = "Addr";
            this.dgcAddr.HeaderText = "jur. adrese";
            this.dgcAddr.Name = "dgcAddr";
            this.dgcAddr.ToolTipText = "Juridiskā adrese";
            this.dgcAddr.Width = 160;
            // 
            // dgcAddr2
            // 
            this.dgcAddr2.DataPropertyName = "Addr2";
            this.dgcAddr2.HeaderText = "fiz. adrese";
            this.dgcAddr2.Name = "dgcAddr2";
            this.dgcAddr2.ToolTipText = "Struktūrvienības adrese (pavadzīmēm)";
            this.dgcAddr2.Width = 160;
            // 
            // dgcATK
            // 
            this.dgcATK.DataPropertyName = "ATK";
            this.dgcATK.HeaderText = "ATK";
            this.dgcATK.Name = "dgcATK";
            this.dgcATK.Width = 80;
            // 
            // dgcBankId
            // 
            this.dgcBankId.ColumnNames = new string[] {
        "id",
        "name"};
            this.dgcBankId.ColumnWidths = "100;200";
            this.dgcBankId.DataPropertyName = "BankId";
            this.dgcBankId.DataSource = this.bsBanks;
            this.dgcBankId.DisplayMember = "Id";
            this.dgcBankId.HeaderText = "bankas kods";
            this.dgcBankId.MaxDropDownItems = 15;
            this.dgcBankId.Name = "dgcBankId";
            this.dgcBankId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcBankId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcBankId.ToolTipText = "Bankas BIC kods";
            this.dgcBankId.ValueMember = "Id";
            this.dgcBankId.Width = 112;
            // 
            // dgcBank
            // 
            this.dgcBank.DataPropertyName = "Bank";
            this.dgcBank.HeaderText = "bankas nosaukums";
            this.dgcBank.MaxInputLength = 50;
            this.dgcBank.Name = "dgcBank";
            this.dgcBank.Width = 160;
            // 
            // dgcBankAcc
            // 
            this.dgcBankAcc.DataPropertyName = "BankAcc";
            this.dgcBankAcc.HeaderText = "bankas konts";
            this.dgcBankAcc.Name = "dgcBankAcc";
            this.dgcBankAcc.Width = 120;
            // 
            // dgcPhone
            // 
            this.dgcPhone.DataPropertyName = "Phone";
            this.dgcPhone.HeaderText = "telefona";
            this.dgcPhone.Name = "dgcPhone";
            this.dgcPhone.Width = 80;
            // 
            // dgcAct
            // 
            this.dgcAct.DataPropertyName = "Act";
            this.dgcAct.FalseValue = "0";
            this.dgcAct.HeaderText = "aktīvs";
            this.dgcAct.Name = "dgcAct";
            this.dgcAct.TrueValue = "1";
            this.dgcAct.Width = 48;
            // 
            // Form_Persons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 435);
            this.Controls.Add(this.cbAct);
            this.Controls.Add(this.tbClid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.dgvPersons);
            this.Controls.Add(this.bnavPersons);
            this.Name = "Form_Persons";
            this.Text = "Personas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPersons_Load);
            this.Shown += new System.EventHandler(this.FormPersons_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bnavPersons)).EndInit();
            this.bnavPersons.ResumeLayout(false);
            this.bnavPersons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBanks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingNavigator bnavPersons;
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
        private MyDataGridView dgvPersons;
        private MyBindingSource bsPersons;
        private MyTextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MyPickRowTextBox tbClid;
        private MyMcFlatComboBox cbAct;
        private System.Windows.Forms.Label label3;
        private MyBindingSource bsBanks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcClid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRegNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPVNRegNr;
        private MyDgvMcCBColumn dgcTP;
        private MyDgvMcCBColumn dgcTP2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgcTP3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAddr2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcATK;
        private MyDgvMcCBColumn dgcBankId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcBankAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPhone;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgcAct;
    }
}