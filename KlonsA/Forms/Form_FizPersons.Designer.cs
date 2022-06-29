using KlonsLIB.Components;

namespace KlonsA.Forms
{
    partial class Form_FizPersons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_FizPersons));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bnavPersons = new KlonsLIB.Components.MyBindingNavigator();
            this.bsPersons = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.dgvPersons = new KlonsLIB.Components.MyDataGridView();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.sgrPersons = new KlonsLIB.MySourceGrid.MyGrid();
            this.personsRData1 = new DataObjectsA.PersonsRData();
            this.rwPamatdatiTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.rwFName = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwLName = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwNameDative = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwNameAccusative = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwGender = new KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxA();
            this.rwPK = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwBirthDate = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwTaxesTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.rwTaxRegNo = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwAddressTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.rwAddress = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwCity = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwState = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwCountry = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwPostalCode = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwTerritorialCode = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwContactInfoTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.rwPhone = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwEMail = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwPassportTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.rwPassportNo = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwPassportIssuer = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwPassportDate = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwBankTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.rwBankId = new KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB();
            this.bsBanks = new KlonsLIB.Data.MyBindingSource(this.components);
            this.rwBankAcc = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwCommentsTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.rwComments = new KlonsLIB.MySourceGrid.GridRows.MyGridRowMultiLineTextBox();
            this.rwtDecimal = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.rwtString = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.cbActive = new KlonsLIB.Components.MyMcFlatComboBox();
            this.dgcFname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcTaxRegNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUsed = new MyDgvCheckBoxColumn();
            this.dgcUsedDt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUsedDt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bnavPersons)).BeginInit();
            this.bnavPersons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBanks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bnavPersons
            // 
            this.bnavPersons.AddNewItem = null;
            this.bnavPersons.BindingSource = this.bsPersons;
            this.bnavPersons.CountItem = this.bindingNavigatorCountItem;
            this.bnavPersons.CountItemFormat = " no {0}";
            this.bnavPersons.DataGrid = this.dgvPersons;
            this.bnavPersons.DeleteItem = null;
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
            this.bnavPersons.Location = new System.Drawing.Point(0, 339);
            this.bnavPersons.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavPersons.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavPersons.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavPersons.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavPersons.Name = "bnavPersons";
            this.bnavPersons.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavPersons.SaveItem = null;
            this.bnavPersons.Size = new System.Drawing.Size(851, 36);
            this.bnavPersons.TabIndex = 0;
            this.bnavPersons.Text = "myBindingNavigator1";
            this.bnavPersons.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavPersons_ItemDeleting);
            // 
            // bsPersons
            // 
            this.bsPersons.DataMember = "PERSONS_FIZ";
            this.bsPersons.MyDataSource = "KlonsData";
            this.bsPersons.Name2 = null;
            this.bsPersons.Sort = "ZNAME";
            this.bsPersons.CurrentChanged += new System.EventHandler(this.bsPersons_CurrentChanged);
            this.bsPersons.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsPersons_ListChanged);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(69, 33);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // dgvPersons
            // 
            this.dgvPersons.AllowUserToAddRows = false;
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
            this.dgcFname,
            this.dgcLName,
            this.dgcPK,
            this.dgcTaxRegNo,
            this.dgcUsed,
            this.dgcUsedDt1,
            this.dgcUsedDt2,
            this.dgcID});
            this.dgvPersons.DataSource = this.bsPersons;
            this.dgvPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersons.Location = new System.Drawing.Point(0, 0);
            this.dgvPersons.Name = "dgvPersons";
            this.dgvPersons.RowTemplate.Height = 24;
            this.dgvPersons.Size = new System.Drawing.Size(516, 339);
            this.dgvPersons.TabIndex = 1;
            this.dgvPersons.MyCheckForChanges += new System.EventHandler(this.dgvPersons_MyCheckForChanges);
            this.dgvPersons.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersons_CellDoubleClick);
            this.dgvPersons.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvPersons_CellParsing);
            this.dgvPersons.CurrentCellChanged += new System.EventHandler(this.dgvPersons_CurrentCellChanged);
            this.dgvPersons.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPersons_UserDeletingRow);
            this.dgvPersons.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPersons_KeyDown);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(25, 33);
            this.bindingNavigatorMoveFirstItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(25, 33);
            this.bindingNavigatorMovePreviousItem.Text = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 36);
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
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(25, 33);
            this.bindingNavigatorMoveNextItem.Text = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(25, 33);
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 36);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(91, 33);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(87, 29);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::KlonsA.Properties.Resources.Save1;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(25, 33);
            this.tsbSave.Text = "Saglabāt";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // sgrPersons
            // 
            this.sgrPersons.BackColor2 = System.Drawing.SystemColors.Window;
            this.sgrPersons.ColumnWidth1 = 15;
            this.sgrPersons.ColumnWidth2 = 150;
            this.sgrPersons.ColumnWidth3 = 150;
            this.sgrPersons.Dock = System.Windows.Forms.DockStyle.Right;
            this.sgrPersons.EnableSort = true;
            this.sgrPersons.Location = new System.Drawing.Point(516, 0);
            this.sgrPersons.MyDataBC = this.personsRData1;
            this.sgrPersons.Name = "sgrPersons";
            this.sgrPersons.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.sgrPersons.RowList.Add(this.rwPamatdatiTitle);
            this.sgrPersons.RowList.Add(this.rwFName);
            this.sgrPersons.RowList.Add(this.rwLName);
            this.sgrPersons.RowList.Add(this.rwNameDative);
            this.sgrPersons.RowList.Add(this.rwNameAccusative);
            this.sgrPersons.RowList.Add(this.rwGender);
            this.sgrPersons.RowList.Add(this.rwPK);
            this.sgrPersons.RowList.Add(this.rwBirthDate);
            this.sgrPersons.RowList.Add(this.rwTaxesTitle);
            this.sgrPersons.RowList.Add(this.rwTaxRegNo);
            this.sgrPersons.RowList.Add(this.rwAddressTitle);
            this.sgrPersons.RowList.Add(this.rwAddress);
            this.sgrPersons.RowList.Add(this.rwCity);
            this.sgrPersons.RowList.Add(this.rwState);
            this.sgrPersons.RowList.Add(this.rwCountry);
            this.sgrPersons.RowList.Add(this.rwPostalCode);
            this.sgrPersons.RowList.Add(this.rwTerritorialCode);
            this.sgrPersons.RowList.Add(this.rwContactInfoTitle);
            this.sgrPersons.RowList.Add(this.rwPhone);
            this.sgrPersons.RowList.Add(this.rwEMail);
            this.sgrPersons.RowList.Add(this.rwPassportTitle);
            this.sgrPersons.RowList.Add(this.rwPassportNo);
            this.sgrPersons.RowList.Add(this.rwPassportIssuer);
            this.sgrPersons.RowList.Add(this.rwPassportDate);
            this.sgrPersons.RowList.Add(this.rwBankTitle);
            this.sgrPersons.RowList.Add(this.rwBankId);
            this.sgrPersons.RowList.Add(this.rwBankAcc);
            this.sgrPersons.RowList.Add(this.rwCommentsTitle);
            this.sgrPersons.RowList.Add(this.rwComments);
            this.sgrPersons.RowTemplateList.Add(this.rwtDecimal);
            this.sgrPersons.RowTemplateList.Add(this.rwtString);
            this.sgrPersons.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.sgrPersons.Size = new System.Drawing.Size(335, 339);
            this.sgrPersons.TabIndex = 2;
            this.sgrPersons.TabStop = true;
            this.sgrPersons.ToolTipText = "";
            // 
            // rwPamatdatiTitle
            // 
            this.rwPamatdatiTitle.Name = "rwPamatdatiTitle";
            this.rwPamatdatiTitle.RowTitle = "Pamatdati";
            this.rwPamatdatiTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // rwFName
            // 
            this.rwFName.DataMember = "FNAME";
            this.rwFName.DataSource = this.bsPersons;
            this.rwFName.EditorTemplateName = "rwtString";
            this.rwFName.GridPropertyName = "_FNAME";
            this.rwFName.Name = "rwFName";
            this.rwFName.RowTitle = "Vārds";
            this.rwFName.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwLName
            // 
            this.rwLName.DataMember = "LNAME";
            this.rwLName.DataSource = this.bsPersons;
            this.rwLName.EditorTemplateName = "rwtString";
            this.rwLName.GridPropertyName = "_LNAME";
            this.rwLName.Name = "rwLName";
            this.rwLName.RowTitle = "Uzvārds";
            this.rwLName.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwNameDative
            // 
            this.rwNameDative.AllowNull = true;
            this.rwNameDative.DataMember = "NAME_DATIVE";
            this.rwNameDative.DataSource = this.bsPersons;
            this.rwNameDative.EditorTemplateName = "rwtString";
            this.rwNameDative.GridPropertyName = "_NAME_DATIVE";
            this.rwNameDative.Name = "rwNameDative";
            this.rwNameDative.RowTitle = "Vārds datīvā";
            this.rwNameDative.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwNameAccusative
            // 
            this.rwNameAccusative.AllowNull = true;
            this.rwNameAccusative.DataMember = "NAME_ACCUSATIVE";
            this.rwNameAccusative.DataSource = this.bsPersons;
            this.rwNameAccusative.EditorTemplateName = "rwtString";
            this.rwNameAccusative.GridPropertyName = "_NAME_ACCUSATIVE";
            this.rwNameAccusative.Name = "rwNameAccusative";
            this.rwNameAccusative.RowTitle = "Vārds akuzatīvā";
            this.rwNameAccusative.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwGender
            // 
            this.rwGender.DataMember = "GENDER";
            this.rwGender.DataSource = this.bsPersons;
            this.rwGender.GridPropertyName = "_GENDER";
            this.rwGender.ListStrings = new string[] {
        "0;vīrietis",
        "1;sieviete"};
            this.rwGender.Name = "rwGender";
            this.rwGender.RowTitle = "Dzimums";
            this.rwGender.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.ShortInt;
            // 
            // rwPK
            // 
            this.rwPK.AllowNull = true;
            this.rwPK.DataMember = "PK";
            this.rwPK.DataSource = this.bsPersons;
            this.rwPK.EditorTemplateName = "rwtString";
            this.rwPK.GridPropertyName = "_PERSON_CODE";
            this.rwPK.Name = "rwPK";
            this.rwPK.RowTitle = "Personas kods";
            this.rwPK.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwBirthDate
            // 
            this.rwBirthDate.DataMember = "BIRTH_DATE";
            this.rwBirthDate.DataSource = this.bsPersons;
            this.rwBirthDate.GridPropertyName = "_BIRTH_DATE";
            this.rwBirthDate.Name = "rwBirthDate";
            this.rwBirthDate.RowTitle = "Dzimšanas datums";
            this.rwBirthDate.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Date;
            // 
            // rwTaxesTitle
            // 
            this.rwTaxesTitle.Name = "rwTaxesTitle";
            this.rwTaxesTitle.RowTitle = "Nodokļi";
            this.rwTaxesTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // rwTaxRegNo
            // 
            this.rwTaxRegNo.AllowNull = true;
            this.rwTaxRegNo.DataMember = "TAXREG_NO";
            this.rwTaxRegNo.DataSource = this.bsPersons;
            this.rwTaxRegNo.EditorTemplateName = "rwtString";
            this.rwTaxRegNo.GridPropertyName = "_TAXREG_NO";
            this.rwTaxRegNo.Name = "rwTaxRegNo";
            this.rwTaxRegNo.RowTitle = "Nod. maks. reģ. nr.";
            this.rwTaxRegNo.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwAddressTitle
            // 
            this.rwAddressTitle.Name = "rwAddressTitle";
            this.rwAddressTitle.RowTitle = "Adrese";
            this.rwAddressTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // rwAddress
            // 
            this.rwAddress.AllowNull = true;
            this.rwAddress.DataMember = "ADDRESS";
            this.rwAddress.DataSource = this.bsPersons;
            this.rwAddress.EditorTemplateName = "rwtString";
            this.rwAddress.GridPropertyName = "_ADDRESS";
            this.rwAddress.Name = "rwAddress";
            this.rwAddress.RowTitle = "Adrese";
            this.rwAddress.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwCity
            // 
            this.rwCity.AllowNull = true;
            this.rwCity.DataMember = "CITY";
            this.rwCity.DataSource = this.bsPersons;
            this.rwCity.EditorTemplateName = "rwtString";
            this.rwCity.GridPropertyName = "_CITY";
            this.rwCity.Name = "rwCity";
            this.rwCity.RowTitle = "Pilsēta";
            this.rwCity.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwState
            // 
            this.rwState.AllowNull = true;
            this.rwState.DataMember = "STATE";
            this.rwState.DataSource = this.bsPersons;
            this.rwState.EditorTemplateName = "rwtString";
            this.rwState.GridPropertyName = "_STATE";
            this.rwState.Name = "rwState";
            this.rwState.RowTitle = "Novads";
            this.rwState.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwCountry
            // 
            this.rwCountry.AllowNull = true;
            this.rwCountry.DataMember = "COUNTRY";
            this.rwCountry.DataSource = this.bsPersons;
            this.rwCountry.EditorTemplateName = "rwtString";
            this.rwCountry.GridPropertyName = "_COUNTRY";
            this.rwCountry.Name = "rwCountry";
            this.rwCountry.RowTitle = "Valsts";
            this.rwCountry.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwPostalCode
            // 
            this.rwPostalCode.AllowNull = true;
            this.rwPostalCode.DataMember = "POSTAL_CODE";
            this.rwPostalCode.DataSource = this.bsPersons;
            this.rwPostalCode.EditorTemplateName = "rwtString";
            this.rwPostalCode.GridPropertyName = "_POSTAL_CODE";
            this.rwPostalCode.Name = "rwPostalCode";
            this.rwPostalCode.RowTitle = "Pasta indekss";
            this.rwPostalCode.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwTerritorialCode
            // 
            this.rwTerritorialCode.AllowNull = true;
            this.rwTerritorialCode.DataMember = "TERRITORIAL_CODE";
            this.rwTerritorialCode.DataSource = this.bsPersons;
            this.rwTerritorialCode.EditorTemplateName = "rwtString";
            this.rwTerritorialCode.GridPropertyName = "_TERRITORIAL_CODE";
            this.rwTerritorialCode.Name = "rwTerritorialCode";
            this.rwTerritorialCode.RowTitle = "Teritoriālais kods";
            this.rwTerritorialCode.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwContactInfoTitle
            // 
            this.rwContactInfoTitle.Name = "rwContactInfoTitle";
            this.rwContactInfoTitle.RowTitle = "Kontaktinformācija";
            this.rwContactInfoTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // rwPhone
            // 
            this.rwPhone.AllowNull = true;
            this.rwPhone.DataMember = "PHONE";
            this.rwPhone.DataSource = this.bsPersons;
            this.rwPhone.EditorTemplateName = "rwtString";
            this.rwPhone.GridPropertyName = "_PHONE";
            this.rwPhone.Name = "rwPhone";
            this.rwPhone.RowTitle = "Telefona nr.";
            this.rwPhone.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwEMail
            // 
            this.rwEMail.AllowNull = true;
            this.rwEMail.DataMember = "EMAIL";
            this.rwEMail.DataSource = this.bsPersons;
            this.rwEMail.EditorTemplateName = "rwtString";
            this.rwEMail.GridPropertyName = "_EMAIL";
            this.rwEMail.Name = "rwEMail";
            this.rwEMail.RowTitle = "E-pasts";
            this.rwEMail.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwPassportTitle
            // 
            this.rwPassportTitle.Name = "rwPassportTitle";
            this.rwPassportTitle.RowTitle = "Pases dati";
            this.rwPassportTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // rwPassportNo
            // 
            this.rwPassportNo.AllowNull = true;
            this.rwPassportNo.DataMember = "PASSPORT_NO";
            this.rwPassportNo.DataSource = this.bsPersons;
            this.rwPassportNo.EditorTemplateName = "rwtString";
            this.rwPassportNo.GridPropertyName = "_PASSPORT_NO";
            this.rwPassportNo.Name = "rwPassportNo";
            this.rwPassportNo.RowTitle = "Numurs";
            this.rwPassportNo.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwPassportIssuer
            // 
            this.rwPassportIssuer.AllowNull = true;
            this.rwPassportIssuer.DataMember = "PASSPORT_ISSUER";
            this.rwPassportIssuer.DataSource = this.bsPersons;
            this.rwPassportIssuer.EditorTemplateName = "rwtString";
            this.rwPassportIssuer.GridPropertyName = "_PASSPORT_ISSUER";
            this.rwPassportIssuer.Name = "rwPassportIssuer";
            this.rwPassportIssuer.RowTitle = "Izdevējiestāde";
            this.rwPassportIssuer.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwPassportDate
            // 
            this.rwPassportDate.AllowNull = true;
            this.rwPassportDate.DataMember = "PASSPORT_DATE";
            this.rwPassportDate.DataSource = this.bsPersons;
            this.rwPassportDate.GridPropertyName = "_PASSPORT_DATE";
            this.rwPassportDate.Name = "rwPassportDate";
            this.rwPassportDate.RowTitle = "Izdošanas datums";
            this.rwPassportDate.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.DateN;
            // 
            // rwBankTitle
            // 
            this.rwBankTitle.Name = "rwBankTitle";
            this.rwBankTitle.RowTitle = "Bankas konts";
            this.rwBankTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // rwBankId
            // 
            this.rwBankId.AllowNull = true;
            this.rwBankId.ColumnNames = new string[] {
        "NAME"};
            this.rwBankId.ColumnWidths = "300";
            this.rwBankId.DataMember = "BANK_ID";
            this.rwBankId.DataSource = this.bsPersons;
            this.rwBankId.GridPropertyName = "_BANK_ID";
            this.rwBankId.ListDisplayMember = "NAME";
            this.rwBankId.ListSource = this.bsBanks;
            this.rwBankId.ListStrings = null;
            this.rwBankId.ListValueMember = "ID";
            this.rwBankId.Name = "rwBankId";
            this.rwBankId.RowTitle = "Banka";
            this.rwBankId.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.IntegerN;
            // 
            // bsBanks
            // 
            this.bsBanks.DataMember = "BANKS";
            this.bsBanks.MyDataSource = "KlonsData";
            this.bsBanks.Name2 = null;
            this.bsBanks.Sort = "NAME";
            // 
            // rwBankAcc
            // 
            this.rwBankAcc.AllowNull = true;
            this.rwBankAcc.DataMember = "BANK_ACC";
            this.rwBankAcc.DataSource = this.bsPersons;
            this.rwBankAcc.EditorTemplateName = "rwtString";
            this.rwBankAcc.GridPropertyName = "_BANK_ACC";
            this.rwBankAcc.Name = "rwBankAcc";
            this.rwBankAcc.RowTitle = "Konts";
            this.rwBankAcc.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // rwCommentsTitle
            // 
            this.rwCommentsTitle.Name = "rwCommentsTitle";
            this.rwCommentsTitle.RowTitle = "Piezimes";
            this.rwCommentsTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // rwComments
            // 
            this.rwComments.AllowNull = true;
            this.rwComments.DataMember = "COMMENTS";
            this.rwComments.DataSource = this.bsPersons;
            this.rwComments.GridPropertyName = "_COMMENTS";
            this.rwComments.Name = "rwComments";
            this.rwComments.RowSpan = 8;
            this.rwComments.RowTitle = null;
            // 
            // rwtDecimal
            // 
            this.rwtDecimal.Name = "rwtDecimal";
            this.rwtDecimal.RowTitle = null;
            this.rwtDecimal.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // rwtString
            // 
            this.rwtString.DataMember = null;
            this.rwtString.Name = "rwtString";
            this.rwtString.RowTitle = null;
            this.rwtString.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "PERSONS_FIZ",
        null};
            // 
            // cbActive
            // 
            this.cbActive.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbActive.ColumnNames = new string[0];
            this.cbActive.ColumnWidths = "66";
            this.cbActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbActive.DropDownHeight = 136;
            this.cbActive.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbActive.DropDownWidth = 90;
            this.cbActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbActive.FormattingEnabled = true;
            this.cbActive.GridLineColor = System.Drawing.Color.LightGray;
            this.cbActive.GridLineHorizontal = false;
            this.cbActive.GridLineVertical = false;
            this.cbActive.IntegralHeight = false;
            this.cbActive.Items.AddRange(new object[] {
            "Aktīvie",
            "Visi"});
            this.cbActive.Location = new System.Drawing.Point(497, 339);
            this.cbActive.Margin = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(90, 23);
            this.cbActive.TabIndex = 7;
            this.cbActive.SelectedIndexChanged += new System.EventHandler(this.cbActive_SelectedIndexChanged);
            // 
            // dgcFname
            // 
            this.dgcFname.DataPropertyName = "FNAME";
            this.dgcFname.HeaderText = "vārds";
            this.dgcFname.Name = "dgcFname";
            // 
            // dgcLName
            // 
            this.dgcLName.DataPropertyName = "LNAME";
            this.dgcLName.HeaderText = "uzvārds";
            this.dgcLName.Name = "dgcLName";
            // 
            // dgcPK
            // 
            this.dgcPK.DataPropertyName = "PK";
            this.dgcPK.HeaderText = "pers. kods";
            this.dgcPK.Name = "dgcPK";
            this.dgcPK.ToolTipText = "personas kods";
            this.dgcPK.Width = 120;
            // 
            // dgcTaxRegNo
            // 
            this.dgcTaxRegNo.DataPropertyName = "TAXREG_NO";
            this.dgcTaxRegNo.HeaderText = "reģ. nr.";
            this.dgcTaxRegNo.Name = "dgcTaxRegNo";
            this.dgcTaxRegNo.ToolTipText = "nodokļu maksātāja reģistrācijas numurs";
            this.dgcTaxRegNo.Width = 120;
            // 
            // dgcUsed
            // 
            this.dgcUsed.DataPropertyName = "USED";
            this.dgcUsed.FalseValue = "0";
            this.dgcUsed.HeaderText = "aktīvs";
            this.dgcUsed.Name = "dgcUsed";
            this.dgcUsed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcUsed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcUsed.TrueValue = "1";
            this.dgcUsed.Width = 50;
            // 
            // dgcUsedDt1
            // 
            this.dgcUsedDt1.DataPropertyName = "USED_DT1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "dd.MM.yyyy";
            this.dgcUsedDt1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcUsedDt1.HeaderText = "aktīvs no";
            this.dgcUsedDt1.Name = "dgcUsedDt1";
            this.dgcUsedDt1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcUsedDt1.Width = 80;
            // 
            // dgcUsedDt2
            // 
            this.dgcUsedDt2.DataPropertyName = "USED_DT2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "dd.MM.yyyy";
            this.dgcUsedDt2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcUsedDt2.HeaderText = "aktīvs līdz";
            this.dgcUsedDt2.Name = "dgcUsedDt2";
            this.dgcUsedDt2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcUsedDt2.Width = 80;
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.Name = "dgcID";
            this.dgcID.Visible = false;
            // 
            // Form_FizPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 375);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.dgvPersons);
            this.Controls.Add(this.sgrPersons);
            this.Controls.Add(this.bnavPersons);
            this.Name = "Form_FizPersons";
            this.Text = "Fiziskas personas";
            this.Load += new System.EventHandler(this.Form_FizPersons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnavPersons)).EndInit();
            this.bnavPersons.ResumeLayout(false);
            this.bnavPersons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBanks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Components.MyBindingNavigator bnavPersons;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private KlonsLIB.Data.MyBindingSource bsPersons;
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
        private KlonsLIB.Components.MyDataGridView dgvPersons;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private KlonsLIB.MySourceGrid.MyGrid sgrPersons;
        private DataObjectsA.PersonsRData personsRData1;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwtDecimal;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle rwPamatdatiTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwFName;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwtString;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwLName;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwNameDative;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwNameAccusative;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwPK;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwBirthDate;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle rwTaxesTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwTaxRegNo;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle rwAddressTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwAddress;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwCity;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwState;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwCountry;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwPostalCode;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwTerritorialCode;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle rwContactInfoTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwPhone;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwEMail;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle rwPassportTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwPassportNo;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwPassportIssuer;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwPassportDate;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle rwBankTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB rwBankId;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA rwBankAcc;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle rwCommentsTitle;
        private KlonsLIB.Data.MyBindingSource bsBanks;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxA rwGender;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowMultiLineTextBox rwComments;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private KlonsLIB.Components.MyMcFlatComboBox cbActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcFname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTaxRegNo;
        private MyDgvCheckBoxColumn dgcUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUsedDt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUsedDt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
    }
}