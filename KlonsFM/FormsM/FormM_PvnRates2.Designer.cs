
namespace KlonsFM.FormsM
{
    partial class FormM_PvnRates2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormM_PvnRates2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsRates = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvRates = new KlonsLIB.Components.MyDataGridView();
            this.bsAcc = new System.Windows.Forms.BindingSource(this.components);
            this.bNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.lbActiveGrid = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bniNew = new System.Windows.Forms.ToolStripButton();
            this.bniDelete = new System.Windows.Forms.ToolStripButton();
            this.bniSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.rādītPaslēptDatuPaneliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myGrid1 = new KlonsLIB.MySourceGrid.MyGrid();
            this.pvnRates2Data1 = new DataObjectsFM.PVNRates2Data();
            this.grTitleRate = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grRateCode = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grRateName = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grRateRate = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grRatesIsReverse = new KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox();
            this.grAccTitleAcc = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grAccPvnType = new KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB();
            this.bsPVNType = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grAccTrTp = new KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB();
            this.bsDocType = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grAccInCurMt = new KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox();
            this.grTitleBase = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grAccBaseDebFin = new KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxA();
            this.grAccBaseDebPvn = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grAccBaseCredFin = new KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxA();
            this.grAccBaseCredPvn = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grTitlePVN = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grAccPVNDebFin = new KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxA();
            this.grAccPVNDebPvn = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grAccPVNCredBFin = new KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxA();
            this.grAccPVNCredPvn = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grAccChangeSign = new KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox();
            this.grAccTitleTexts = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grAccIdPVNText = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.bsPvnTexts = new KlonsLIB.Data.MyBindingSource(this.components);
            this.grAccBaseText = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grAccPVNText = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.mySplitContainer1 = new KlonsLIB.Components.MySplitContainer();
            this.dgvAcc = new KlonsLIB.Components.MyDataGridView();
            this.dgcAccIdTp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcAccTrTp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcAccInCurMt = new KlonsLIB.Components.MyDgvCheckBoxColumn();
            this.dgcAccBaseDebFin = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcAccBaseDebPvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAccBaseCredFin = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcAccBaseCredPvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAccPvnDebFin = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcAccPvnDebPvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAccPvnCredFin = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcAccPvnCredPvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcChangeSign = new KlonsLIB.Components.MyDgvCheckBoxColumn();
            this.dgcAccIdPVNText = new KlonsLIB.Components.MyDgvTextboxColumn2();
            this.dgcAccBaseText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAccPvnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAccId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAccIdRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.dgcRatesCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRatesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcRatesRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRateIsReverse = new KlonsLIB.Components.MyDgvCheckBoxColumn();
            this.dgcRateId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsRates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).BeginInit();
            this.bNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPVNType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPvnTexts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mySplitContainer1)).BeginInit();
            this.mySplitContainer1.Panel1.SuspendLayout();
            this.mySplitContainer1.Panel2.SuspendLayout();
            this.mySplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bsRates
            // 
            this.bsRates.DataMember = "M_PVNRATES";
            this.bsRates.MyDataSource = "KlonsMData";
            this.bsRates.Sort = "ID";
            this.bsRates.UseDataGridView = this.dgvRates;
            this.bsRates.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsRates_ListChanged);
            // 
            // dgvRates
            // 
            this.dgvRates.AllowUserToResizeRows = false;
            this.dgvRates.AutoGenerateColumns = false;
            this.dgvRates.AutoSave = false;
            this.dgvRates.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcRatesCode,
            this.dgcRatesName,
            this.dcRatesRate,
            this.dgcRateIsReverse,
            this.dgcRateId});
            this.dgvRates.DataSource = this.bsRates;
            this.dgvRates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRates.Location = new System.Drawing.Point(0, 0);
            this.dgvRates.Name = "dgvRates";
            this.dgvRates.RowHeadersWidth = 30;
            this.dgvRates.RowTemplate.Height = 28;
            this.dgvRates.ShowCellToolTips = false;
            this.dgvRates.Size = new System.Drawing.Size(548, 235);
            this.dgvRates.TabIndex = 0;
            this.dgvRates.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRates_MyKeyDown);
            this.dgvRates.MyCheckForChanges += new System.EventHandler(this.dgvRates_MyCheckForChanges);
            this.dgvRates.CurrentCellChanged += new System.EventHandler(this.dgvRates_CurrentCellChanged);
            this.dgvRates.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvRates_UserDeletingRow);
            this.dgvRates.Enter += new System.EventHandler(this.dgvRates_Enter);
            // 
            // bsAcc
            // 
            this.bsAcc.DataMember = "FK_M_PVNRATES2_IDRATE";
            this.bsAcc.DataSource = this.bsRates;
            this.bsAcc.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsAcc_ListChanged);
            // 
            // bNav
            // 
            this.bNav.AddNewItem = null;
            this.bNav.CountItem = this.bindingNavigatorCountItem;
            this.bNav.CountItemFormat = " no {0}";
            this.bNav.DeleteItem = null;
            this.bNav.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bNav.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbActiveGrid,
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bniNew,
            this.bniDelete,
            this.bniSave,
            this.toolStripDropDownButton1});
            this.bNav.Location = new System.Drawing.Point(0, 496);
            this.bNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bNav.Name = "bNav";
            this.bNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bNav.SaveItem = this.bniSave;
            this.bNav.Size = new System.Drawing.Size(1008, 39);
            this.bNav.TabIndex = 0;
            this.bNav.Text = "myBindingNavigator1";
            this.bNav.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bNav_ItemDeleting);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 34);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // lbActiveGrid
            // 
            this.lbActiveGrid.Name = "lbActiveGrid";
            this.lbActiveGrid.Size = new System.Drawing.Size(28, 34);
            this.lbActiveGrid.Text = "...";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 37);
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
            // bniNew
            // 
            this.bniNew.Image = ((System.Drawing.Image)(resources.GetObject("bniNew.Image")));
            this.bniNew.Name = "bniNew";
            this.bniNew.RightToLeftAutoMirrorImage = true;
            this.bniNew.Size = new System.Drawing.Size(93, 34);
            this.bniNew.Text = "Jauns";
            this.bniNew.Click += new System.EventHandler(this.bniAddNew_Click);
            // 
            // bniDelete
            // 
            this.bniDelete.Image = ((System.Drawing.Image)(resources.GetObject("bniDelete.Image")));
            this.bniDelete.Name = "bniDelete";
            this.bniDelete.RightToLeftAutoMirrorImage = true;
            this.bniDelete.Size = new System.Drawing.Size(94, 34);
            this.bniDelete.Text = "Dzēst";
            this.bniDelete.Click += new System.EventHandler(this.bniDelete_Click);
            // 
            // bniSave
            // 
            this.bniSave.Image = ((System.Drawing.Image)(resources.GetObject("bniSave.Image")));
            this.bniSave.Name = "bniSave";
            this.bniSave.Size = new System.Drawing.Size(124, 34);
            this.bniSave.Text = "Saglabāt";
            this.bniSave.Click += new System.EventHandler(this.bniSave_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rādītPaslēptDatuPaneliToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(65, 34);
            this.toolStripDropDownButton1.Text = "Rīki";
            // 
            // rādītPaslēptDatuPaneliToolStripMenuItem
            // 
            this.rādītPaslēptDatuPaneliToolStripMenuItem.Name = "rādītPaslēptDatuPaneliToolStripMenuItem";
            this.rādītPaslēptDatuPaneliToolStripMenuItem.Size = new System.Drawing.Size(369, 38);
            this.rādītPaslēptDatuPaneliToolStripMenuItem.Text = "Rādīt / paslēpt datu paneli";
            this.rādītPaslēptDatuPaneliToolStripMenuItem.Click += new System.EventHandler(this.rādītPaslēptDatuPaneliToolStripMenuItem_Click);
            // 
            // myGrid1
            // 
            this.myGrid1.BackColor2 = System.Drawing.SystemColors.Window;
            this.myGrid1.ColumnWidth1 = 20;
            this.myGrid1.ColumnWidth2 = 180;
            this.myGrid1.ColumnWidth3 = 260;
            this.myGrid1.DefaultHeight = 25;
            this.myGrid1.Dock = System.Windows.Forms.DockStyle.Right;
            this.myGrid1.EnableSort = true;
            this.myGrid1.Location = new System.Drawing.Point(548, 0);
            this.myGrid1.MyDataBC = this.pvnRates2Data1;
            this.myGrid1.Name = "myGrid1";
            this.myGrid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.myGrid1.RowList.Add(this.grTitleRate);
            this.myGrid1.RowList.Add(this.grRateCode);
            this.myGrid1.RowList.Add(this.grRateName);
            this.myGrid1.RowList.Add(this.grRateRate);
            this.myGrid1.RowList.Add(this.grRatesIsReverse);
            this.myGrid1.RowList.Add(this.grAccTitleAcc);
            this.myGrid1.RowList.Add(this.grAccPvnType);
            this.myGrid1.RowList.Add(this.grAccTrTp);
            this.myGrid1.RowList.Add(this.grAccInCurMt);
            this.myGrid1.RowList.Add(this.grTitleBase);
            this.myGrid1.RowList.Add(this.grAccBaseDebFin);
            this.myGrid1.RowList.Add(this.grAccBaseDebPvn);
            this.myGrid1.RowList.Add(this.grAccBaseCredFin);
            this.myGrid1.RowList.Add(this.grAccBaseCredPvn);
            this.myGrid1.RowList.Add(this.grTitlePVN);
            this.myGrid1.RowList.Add(this.grAccPVNDebFin);
            this.myGrid1.RowList.Add(this.grAccPVNDebPvn);
            this.myGrid1.RowList.Add(this.grAccPVNCredBFin);
            this.myGrid1.RowList.Add(this.grAccPVNCredPvn);
            this.myGrid1.RowList.Add(this.grAccChangeSign);
            this.myGrid1.RowList.Add(this.grAccTitleTexts);
            this.myGrid1.RowList.Add(this.grAccIdPVNText);
            this.myGrid1.RowList.Add(this.grAccBaseText);
            this.myGrid1.RowList.Add(this.grAccPVNText);
            this.myGrid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.myGrid1.Size = new System.Drawing.Size(460, 496);
            this.myGrid1.TabIndex = 1;
            this.myGrid1.TabStop = true;
            this.myGrid1.ToolTipText = "";
            this.myGrid1.ConvertingValueToDisplayString += new DevAge.ComponentModel.ConvertingObjectEventHandler(this.myGrid1_ConvertingValueToDisplayString);
            // 
            // pvnRates2Data1
            // 
            this.pvnRates2Data1._BASE_CRED_FIN = 0;
            this.pvnRates2Data1._BASE_CRED_PVN = null;
            this.pvnRates2Data1._BASE_DEB_FIN = 0;
            this.pvnRates2Data1._BASE_DEB_PVN = null;
            this.pvnRates2Data1._BASE_TEXT = null;
            this.pvnRates2Data1._CHANGE_SIGN = 0;
            this.pvnRates2Data1._ID = 0;
            this.pvnRates2Data1._ID_PVNTEXT = null;
            this.pvnRates2Data1._IDRATE = 0;
            this.pvnRates2Data1._IDTP = 0;
            this.pvnRates2Data1._IDTRTP = 0;
            this.pvnRates2Data1._IN_CURRENT_MTONTH = 0;
            this.pvnRates2Data1._PVN_CRED_FIN = 0;
            this.pvnRates2Data1._PVN_CRED_PVN = null;
            this.pvnRates2Data1._PVN_DEB_FIN = 0;
            this.pvnRates2Data1._PVN_DEB_PVN = null;
            this.pvnRates2Data1._PVN_TEXT = null;
            this.pvnRates2Data1._RATES_CODE = null;
            this.pvnRates2Data1._RATES_ID = 0;
            this.pvnRates2Data1._RATES_ISREVERSE = 0;
            this.pvnRates2Data1._RATES_NAME = null;
            this.pvnRates2Data1._RATES_RATE = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // grTitleRate
            // 
            this.grTitleRate.Name = "grTitleRate";
            this.grTitleRate.RowTitle = "PVN likme";
            this.grTitleRate.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // grRateCode
            // 
            this.grRateCode.DataMember = "CODE";
            this.grRateCode.DataSource = this.bsRates;
            this.grRateCode.GridPropertyName = "_RATES_CODE";
            this.grRateCode.Name = "grRateCode";
            this.grRateCode.RowTitle = "Kods";
            this.grRateCode.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grRateName
            // 
            this.grRateName.DataMember = "NAME";
            this.grRateName.DataSource = this.bsRates;
            this.grRateName.GridPropertyName = "_RATES_NAME";
            this.grRateName.Name = "grRateName";
            this.grRateName.RowTitle = "Nosaukums";
            this.grRateName.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grRateRate
            // 
            this.grRateRate.DataMember = "RATE";
            this.grRateRate.DataSource = this.bsRates;
            this.grRateRate.GridPropertyName = "_RATES_RATE";
            this.grRateRate.Name = "grRateRate";
            this.grRateRate.RowTitle = "Likme";
            this.grRateRate.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            this.grRateRate.TextAllign = KlonsLIB.MySourceGrid.GridRows.ECellTextAllign.Left;
            // 
            // grRatesIsReverse
            // 
            this.grRatesIsReverse.DataMember = "ISREVERSE";
            this.grRatesIsReverse.DataSource = this.bsRates;
            this.grRatesIsReverse.FalseValue = "0";
            this.grRatesIsReverse.GridPropertyName = "_RATES_ISREVERSE";
            this.grRatesIsReverse.Name = "grRatesIsReverse";
            this.grRatesIsReverse.RowTitle = "Reversais";
            this.grRatesIsReverse.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            this.grRatesIsReverse.TrueValue = "1";
            // 
            // grAccTitleAcc
            // 
            this.grAccTitleAcc.Name = "grAccTitleAcc";
            this.grAccTitleAcc.RowTitle = "Kontējums";
            this.grAccTitleAcc.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // grAccPvnType
            // 
            this.grAccPvnType.ColumnNames = new string[] {
        "ID",
        "NAME"};
            this.grAccPvnType.ColumnWidths = "0;200";
            this.grAccPvnType.DataMember = "IDTP";
            this.grAccPvnType.DataSource = this.bsAcc;
            this.grAccPvnType.GridPropertyName = "_IDTP";
            this.grAccPvnType.ListDisplayMember = "NAME";
            this.grAccPvnType.ListSource = this.bsPVNType;
            this.grAccPvnType.ListValueMember = "ID";
            this.grAccPvnType.Name = "grAccPvnType";
            this.grAccPvnType.RowTitle = "PVN režīms";
            this.grAccPvnType.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // bsPVNType
            // 
            this.bsPVNType.DataMember = "M_PVNTYPE";
            this.bsPVNType.MyDataSource = "KlonsMData";
            this.bsPVNType.Sort = "ID";
            // 
            // grAccTrTp
            // 
            this.grAccTrTp.ColumnNames = new string[] {
        "NAME"};
            this.grAccTrTp.ColumnWidths = "200";
            this.grAccTrTp.DataMember = "IDTRTP";
            this.grAccTrTp.DataSource = this.bsAcc;
            this.grAccTrTp.GridPropertyName = "_IDTRTP";
            this.grAccTrTp.ListDisplayMember = "NAME";
            this.grAccTrTp.ListSource = this.bsDocType;
            this.grAccTrTp.ListValueMember = "ID";
            this.grAccTrTp.Name = "grAccTrTp";
            this.grAccTrTp.RowTitle = "Darijuma veids";
            this.grAccTrTp.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // bsDocType
            // 
            this.bsDocType.DataMember = "M_DOCTYPES";
            this.bsDocType.MyDataSource = "KlonsMData";
            this.bsDocType.Sort = "ID";
            // 
            // grAccInCurMt
            // 
            this.grAccInCurMt.DataMember = "INCURMT";
            this.grAccInCurMt.DataSource = this.bsAcc;
            this.grAccInCurMt.FalseValue = "0";
            this.grAccInCurMt.GridPropertyName = "_IN_CURRENT_MTONTH";
            this.grAccInCurMt.Name = "grAccInCurMt";
            this.grAccInCurMt.RowTitle = "Tekošajā mēnesī";
            this.grAccInCurMt.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            this.grAccInCurMt.TrueValue = "1";
            // 
            // grTitleBase
            // 
            this.grTitleBase.Name = "grTitleBase";
            this.grTitleBase.RowTitle = "pamatsumma";
            this.grTitleBase.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.SubTitle;
            // 
            // grAccBaseDebFin
            // 
            this.grAccBaseDebFin.DataMember = "BASE_DEB_FIN";
            this.grAccBaseDebFin.DataSource = this.bsAcc;
            this.grAccBaseDebFin.GridPropertyName = "_BASE_DEB_FIN";
            this.grAccBaseDebFin.ListStrings = new string[] {
        "0;Nav",
        "2;21--",
        "3;231-",
        "4;531-",
        "5;6---",
        "6;7---"};
            this.grAccBaseDebFin.Name = "grAccBaseDebFin";
            this.grAccBaseDebFin.RowTitle = "debets finanses";
            this.grAccBaseDebFin.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grAccBaseDebPvn
            // 
            this.grAccBaseDebPvn.DataMember = "BASE_DEB_PVN";
            this.grAccBaseDebPvn.DataSource = this.bsAcc;
            this.grAccBaseDebPvn.GridPropertyName = "_BASE_DEB_PVN";
            this.grAccBaseDebPvn.Name = "grAccBaseDebPvn";
            this.grAccBaseDebPvn.RowTitle = "debets PVN";
            this.grAccBaseDebPvn.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grAccBaseCredFin
            // 
            this.grAccBaseCredFin.DataMember = "BASE_CRED_FIN";
            this.grAccBaseCredFin.DataSource = this.bsAcc;
            this.grAccBaseCredFin.GridPropertyName = "_BASE_CRED_FIN";
            this.grAccBaseCredFin.ListStrings = new string[] {
        "0;Nav",
        "2;21--",
        "3;231-",
        "4;531-",
        "5;6---",
        "6;7---"};
            this.grAccBaseCredFin.Name = "grAccBaseCredFin";
            this.grAccBaseCredFin.RowTitle = "kredīts finanses";
            this.grAccBaseCredFin.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grAccBaseCredPvn
            // 
            this.grAccBaseCredPvn.DataMember = "BASE_CRED_PVN";
            this.grAccBaseCredPvn.DataSource = this.bsAcc;
            this.grAccBaseCredPvn.GridPropertyName = "_BASE_CRED_PVN";
            this.grAccBaseCredPvn.Name = "grAccBaseCredPvn";
            this.grAccBaseCredPvn.RowTitle = "kredīts PVN";
            this.grAccBaseCredPvn.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grTitlePVN
            // 
            this.grTitlePVN.Name = "grTitlePVN";
            this.grTitlePVN.RowTitle = "PVN";
            this.grTitlePVN.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.SubTitle;
            // 
            // grAccPVNDebFin
            // 
            this.grAccPVNDebFin.DataMember = "PVN_DEB_FIN";
            this.grAccPVNDebFin.DataSource = this.bsAcc;
            this.grAccPVNDebFin.GridPropertyName = "_PVN_DEB_FIN";
            this.grAccPVNDebFin.ListStrings = new string[] {
        "0;Nav",
        "1;5731",
        "3;231-",
        "4;531"};
            this.grAccPVNDebFin.Name = "grAccPVNDebFin";
            this.grAccPVNDebFin.RowTitle = "debets finanses";
            this.grAccPVNDebFin.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grAccPVNDebPvn
            // 
            this.grAccPVNDebPvn.DataMember = "PVN_DEB_PVN";
            this.grAccPVNDebPvn.DataSource = this.bsAcc;
            this.grAccPVNDebPvn.GridPropertyName = "_PVN_DEB_PVN";
            this.grAccPVNDebPvn.Name = "grAccPVNDebPvn";
            this.grAccPVNDebPvn.RowTitle = "debets PVN";
            this.grAccPVNDebPvn.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grAccPVNCredBFin
            // 
            this.grAccPVNCredBFin.DataMember = "PVN_CRED_FIN";
            this.grAccPVNCredBFin.DataSource = this.bsAcc;
            this.grAccPVNCredBFin.GridPropertyName = "_PVN_CRED_FIN";
            this.grAccPVNCredBFin.ListStrings = new string[] {
        "0;Nav",
        "1;5731",
        "3;231-",
        "4;531-"};
            this.grAccPVNCredBFin.Name = "grAccPVNCredBFin";
            this.grAccPVNCredBFin.RowTitle = "kredīts finanses";
            this.grAccPVNCredBFin.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grAccPVNCredPvn
            // 
            this.grAccPVNCredPvn.DataMember = "PVN_CRED_PVN";
            this.grAccPVNCredPvn.DataSource = this.bsAcc;
            this.grAccPVNCredPvn.GridPropertyName = "_PVN_CRED_PVN";
            this.grAccPVNCredPvn.Name = "grAccPVNCredPvn";
            this.grAccPVNCredPvn.RowTitle = "kredīts PVN";
            this.grAccPVNCredPvn.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grAccChangeSign
            // 
            this.grAccChangeSign.DataMember = "CHANGESIGN";
            this.grAccChangeSign.DataSource = this.bsAcc;
            this.grAccChangeSign.FalseValue = "0";
            this.grAccChangeSign.GridPropertyName = "_CHANGE_SIGN";
            this.grAccChangeSign.Name = "grAccChangeSign";
            this.grAccChangeSign.RowTitle = "Nomainīt summas zīmi";
            this.grAccChangeSign.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            this.grAccChangeSign.TrueValue = "1";
            // 
            // grAccTitleTexts
            // 
            this.grAccTitleTexts.Name = "grAccTitleTexts";
            this.grAccTitleTexts.RowTitle = "Ieraksta teksts rēķinā";
            this.grAccTitleTexts.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // grAccIdPVNText
            // 
            this.grAccIdPVNText.AllowNull = true;
            this.grAccIdPVNText.DataMember = "IDPVNTEXT";
            this.grAccIdPVNText.DataSource = this.bsAcc;
            this.grAccIdPVNText.GridPropertyName = "_ID_PVNTEXT";
            this.grAccIdPVNText.ListDisplayMember = "CODE";
            this.grAccIdPVNText.ListSource = this.bsPvnTexts;
            this.grAccIdPVNText.ListValueMember = "ID";
            this.grAccIdPVNText.Name = "grAccIdPVNText";
            this.grAccIdPVNText.RowTitle = "PVN atsauce";
            this.grAccIdPVNText.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.IntegerN;
            // 
            // bsPvnTexts
            // 
            this.bsPvnTexts.DataMember = "M_PVNTEXTS";
            this.bsPvnTexts.MyDataSource = "KlonsMData";
            this.bsPvnTexts.Sort = "CODE";
            // 
            // grAccBaseText
            // 
            this.grAccBaseText.AllowNull = true;
            this.grAccBaseText.CustomConversions = true;
            this.grAccBaseText.DataMember = null;
            this.grAccBaseText.GridPropertyName = "_ID_PVNTEXT";
            this.grAccBaseText.Name = "grAccBaseText";
            this.grAccBaseText.ReadOnly = true;
            this.grAccBaseText.RowTitle = "pamatsummai";
            this.grAccBaseText.RowTitleVisible = false;
            this.grAccBaseText.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.IntegerN;
            // 
            // grAccPVNText
            // 
            this.grAccPVNText.AllowNull = true;
            this.grAccPVNText.CustomConversions = true;
            this.grAccPVNText.DataMember = null;
            this.grAccPVNText.GridPropertyName = "_ID_PVNTEXT";
            this.grAccPVNText.Name = "grAccPVNText";
            this.grAccPVNText.ReadOnly = true;
            this.grAccPVNText.RowTitle = "PVN";
            this.grAccPVNText.RowTitleVisible = false;
            this.grAccPVNText.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.IntegerN;
            // 
            // mySplitContainer1
            // 
            this.mySplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.mySplitContainer1.Name = "mySplitContainer1";
            this.mySplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mySplitContainer1.Panel1
            // 
            this.mySplitContainer1.Panel1.Controls.Add(this.dgvRates);
            // 
            // mySplitContainer1.Panel2
            // 
            this.mySplitContainer1.Panel2.Controls.Add(this.dgvAcc);
            this.mySplitContainer1.Size = new System.Drawing.Size(548, 496);
            this.mySplitContainer1.SplitterDistance = 235;
            this.mySplitContainer1.TabIndex = 2;
            // 
            // dgvAcc
            // 
            this.dgvAcc.AutoGenerateColumns = false;
            this.dgvAcc.AutoSave = false;
            this.dgvAcc.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcAccIdTp,
            this.dgcAccTrTp,
            this.dgcAccInCurMt,
            this.dgcAccBaseDebFin,
            this.dgcAccBaseDebPvn,
            this.dgcAccBaseCredFin,
            this.dgcAccBaseCredPvn,
            this.dgcAccPvnDebFin,
            this.dgcAccPvnDebPvn,
            this.dgcAccPvnCredFin,
            this.dgcAccPvnCredPvn,
            this.dgcChangeSign,
            this.dgcAccIdPVNText,
            this.dgcAccBaseText,
            this.dgcAccPvnText,
            this.dgcAccId,
            this.dgcAccIdRate});
            this.dgvAcc.DataSource = this.bsAcc;
            this.dgvAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAcc.Location = new System.Drawing.Point(0, 0);
            this.dgvAcc.Name = "dgvAcc";
            this.dgvAcc.RowHeadersWidth = 30;
            this.dgvAcc.RowTemplate.Height = 28;
            this.dgvAcc.ShowCellToolTips = false;
            this.dgvAcc.Size = new System.Drawing.Size(548, 257);
            this.dgvAcc.TabIndex = 0;
            this.dgvAcc.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAcc_MyKeyDown);
            this.dgvAcc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAcc_CellFormatting);
            this.dgvAcc.CurrentCellChanged += new System.EventHandler(this.dgvAcc_CurrentCellChanged);
            this.dgvAcc.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAcc_UserDeletingRow);
            this.dgvAcc.Enter += new System.EventHandler(this.dgvAcc_Enter);
            // 
            // dgcAccIdTp
            // 
            this.dgcAccIdTp.DataPropertyName = "IDTP";
            this.dgcAccIdTp.DataSource = this.bsPVNType;
            this.dgcAccIdTp.DisplayMember = "NAME";
            this.dgcAccIdTp.DisplayStyleForCurrentCellOnly = true;
            this.dgcAccIdTp.Frozen = true;
            this.dgcAccIdTp.HeaderText = "režīms";
            this.dgcAccIdTp.MaxDropDownItems = 15;
            this.dgcAccIdTp.MinimumWidth = 8;
            this.dgcAccIdTp.Name = "dgcAccIdTp";
            this.dgcAccIdTp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcAccIdTp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcAccIdTp.ValueMember = "ID";
            this.dgcAccIdTp.Width = 160;
            // 
            // dgcAccTrTp
            // 
            this.dgcAccTrTp.DataPropertyName = "IDTRTP";
            this.dgcAccTrTp.DataSource = this.bsDocType;
            this.dgcAccTrTp.DisplayMember = "NAME";
            this.dgcAccTrTp.DisplayStyleForCurrentCellOnly = true;
            this.dgcAccTrTp.Frozen = true;
            this.dgcAccTrTp.HeaderText = "darijuma veids";
            this.dgcAccTrTp.MinimumWidth = 8;
            this.dgcAccTrTp.Name = "dgcAccTrTp";
            this.dgcAccTrTp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcAccTrTp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcAccTrTp.ValueMember = "ID";
            this.dgcAccTrTp.Width = 200;
            // 
            // dgcAccInCurMt
            // 
            this.dgcAccInCurMt.DataPropertyName = "INCURMT";
            this.dgcAccInCurMt.FalseValue = "0";
            this.dgcAccInCurMt.HeaderText = "tekošajā mēnesī";
            this.dgcAccInCurMt.MinimumWidth = 8;
            this.dgcAccInCurMt.Name = "dgcAccInCurMt";
            this.dgcAccInCurMt.TrueValue = "1";
            this.dgcAccInCurMt.Width = 60;
            // 
            // dgcAccBaseDebFin
            // 
            this.dgcAccBaseDebFin.DataPropertyName = "BASE_DEB_FIN";
            this.dgcAccBaseDebFin.DisplayStyleForCurrentCellOnly = true;
            this.dgcAccBaseDebFin.HeaderText = "bāze deb.fin.";
            this.dgcAccBaseDebFin.MinimumWidth = 8;
            this.dgcAccBaseDebFin.Name = "dgcAccBaseDebFin";
            this.dgcAccBaseDebFin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcAccBaseDebFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcAccBaseDebFin.Width = 80;
            // 
            // dgcAccBaseDebPvn
            // 
            this.dgcAccBaseDebPvn.DataPropertyName = "BASE_DEB_PVN";
            this.dgcAccBaseDebPvn.HeaderText = "bāze deb.pvn";
            this.dgcAccBaseDebPvn.MinimumWidth = 8;
            this.dgcAccBaseDebPvn.Name = "dgcAccBaseDebPvn";
            this.dgcAccBaseDebPvn.Width = 80;
            // 
            // dgcAccBaseCredFin
            // 
            this.dgcAccBaseCredFin.DataPropertyName = "BASE_CRED_FIN";
            this.dgcAccBaseCredFin.DisplayStyleForCurrentCellOnly = true;
            this.dgcAccBaseCredFin.HeaderText = "bāze kred.fin.";
            this.dgcAccBaseCredFin.MinimumWidth = 8;
            this.dgcAccBaseCredFin.Name = "dgcAccBaseCredFin";
            this.dgcAccBaseCredFin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcAccBaseCredFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcAccBaseCredFin.Width = 80;
            // 
            // dgcAccBaseCredPvn
            // 
            this.dgcAccBaseCredPvn.DataPropertyName = "BASE_CRED_PVN";
            this.dgcAccBaseCredPvn.HeaderText = "bāze kred.pvn";
            this.dgcAccBaseCredPvn.MinimumWidth = 8;
            this.dgcAccBaseCredPvn.Name = "dgcAccBaseCredPvn";
            this.dgcAccBaseCredPvn.Width = 80;
            // 
            // dgcAccPvnDebFin
            // 
            this.dgcAccPvnDebFin.DataPropertyName = "PVN_DEB_FIN";
            this.dgcAccPvnDebFin.DisplayStyleForCurrentCellOnly = true;
            this.dgcAccPvnDebFin.HeaderText = "PVN deb.fin.";
            this.dgcAccPvnDebFin.MinimumWidth = 8;
            this.dgcAccPvnDebFin.Name = "dgcAccPvnDebFin";
            this.dgcAccPvnDebFin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcAccPvnDebFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcAccPvnDebFin.Width = 80;
            // 
            // dgcAccPvnDebPvn
            // 
            this.dgcAccPvnDebPvn.DataPropertyName = "PVN_DEB_PVN";
            this.dgcAccPvnDebPvn.HeaderText = "PVN deb.pvn";
            this.dgcAccPvnDebPvn.MinimumWidth = 8;
            this.dgcAccPvnDebPvn.Name = "dgcAccPvnDebPvn";
            this.dgcAccPvnDebPvn.Width = 80;
            // 
            // dgcAccPvnCredFin
            // 
            this.dgcAccPvnCredFin.DataPropertyName = "PVN_CRED_FIN";
            this.dgcAccPvnCredFin.DisplayStyleForCurrentCellOnly = true;
            this.dgcAccPvnCredFin.HeaderText = "PVN kred.fin.";
            this.dgcAccPvnCredFin.MinimumWidth = 8;
            this.dgcAccPvnCredFin.Name = "dgcAccPvnCredFin";
            this.dgcAccPvnCredFin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcAccPvnCredFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcAccPvnCredFin.Width = 80;
            // 
            // dgcAccPvnCredPvn
            // 
            this.dgcAccPvnCredPvn.DataPropertyName = "PVN_CRED_PVN";
            this.dgcAccPvnCredPvn.HeaderText = "PVN kred.pvn";
            this.dgcAccPvnCredPvn.MinimumWidth = 8;
            this.dgcAccPvnCredPvn.Name = "dgcAccPvnCredPvn";
            this.dgcAccPvnCredPvn.Width = 80;
            // 
            // dgcChangeSign
            // 
            this.dgcChangeSign.DataPropertyName = "CHANGESIGN";
            this.dgcChangeSign.FalseValue = "0";
            this.dgcChangeSign.HeaderText = "*(-1)";
            this.dgcChangeSign.MinimumWidth = 8;
            this.dgcChangeSign.Name = "dgcChangeSign";
            this.dgcChangeSign.TrueValue = "1";
            this.dgcChangeSign.Width = 40;
            // 
            // dgcAccIdPVNText
            // 
            this.dgcAccIdPVNText.DataPropertyName = "IDPVNTEXT";
            this.dgcAccIdPVNText.DataSource = this.bsPvnTexts;
            this.dgcAccIdPVNText.DisplayMember = "CODE";
            this.dgcAccIdPVNText.HeaderText = "PVN norāde";
            this.dgcAccIdPVNText.MinimumWidth = 8;
            this.dgcAccIdPVNText.Name = "dgcAccIdPVNText";
            this.dgcAccIdPVNText.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcAccIdPVNText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcAccIdPVNText.ValueMember = "ID";
            this.dgcAccIdPVNText.Width = 120;
            // 
            // dgcAccBaseText
            // 
            this.dgcAccBaseText.DataPropertyName = "IDPVNTEXT";
            this.dgcAccBaseText.HeaderText = "pamatsummas teksts";
            this.dgcAccBaseText.MinimumWidth = 8;
            this.dgcAccBaseText.Name = "dgcAccBaseText";
            this.dgcAccBaseText.ReadOnly = true;
            this.dgcAccBaseText.Width = 300;
            // 
            // dgcAccPvnText
            // 
            this.dgcAccPvnText.DataPropertyName = "IDPVNTEXT";
            this.dgcAccPvnText.HeaderText = "PVN teksts";
            this.dgcAccPvnText.MinimumWidth = 8;
            this.dgcAccPvnText.Name = "dgcAccPvnText";
            this.dgcAccPvnText.ReadOnly = true;
            this.dgcAccPvnText.Width = 300;
            // 
            // dgcAccId
            // 
            this.dgcAccId.DataPropertyName = "ID";
            this.dgcAccId.HeaderText = "ID";
            this.dgcAccId.MinimumWidth = 8;
            this.dgcAccId.Name = "dgcAccId";
            this.dgcAccId.Visible = false;
            this.dgcAccId.Width = 60;
            // 
            // dgcAccIdRate
            // 
            this.dgcAccIdRate.DataPropertyName = "IDRATE";
            this.dgcAccIdRate.HeaderText = "IDRATE";
            this.dgcAccIdRate.MinimumWidth = 8;
            this.dgcAccIdRate.Name = "dgcAccIdRate";
            this.dgcAccIdRate.Visible = false;
            this.dgcAccIdRate.Width = 60;
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsMData";
            this.myAdapterManager1.TableNames = new string[] {
        "M_PVNRATES",
        "M_PVNRATES2",
        null};
            // 
            // dgcRatesCode
            // 
            this.dgcRatesCode.DataPropertyName = "CODE";
            this.dgcRatesCode.HeaderText = "kods";
            this.dgcRatesCode.MinimumWidth = 8;
            this.dgcRatesCode.Name = "dgcRatesCode";
            this.dgcRatesCode.Width = 90;
            // 
            // dgcRatesName
            // 
            this.dgcRatesName.DataPropertyName = "NAME";
            this.dgcRatesName.HeaderText = "nosaukums";
            this.dgcRatesName.MinimumWidth = 8;
            this.dgcRatesName.Name = "dgcRatesName";
            this.dgcRatesName.Width = 400;
            // 
            // dcRatesRate
            // 
            this.dcRatesRate.DataPropertyName = "RATE";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dcRatesRate.DefaultCellStyle = dataGridViewCellStyle1;
            this.dcRatesRate.HeaderText = "likme";
            this.dcRatesRate.MinimumWidth = 8;
            this.dcRatesRate.Name = "dcRatesRate";
            this.dcRatesRate.Width = 60;
            // 
            // dgcRateIsReverse
            // 
            this.dgcRateIsReverse.DataPropertyName = "ISREVERSE";
            this.dgcRateIsReverse.FalseValue = "0";
            this.dgcRateIsReverse.HeaderText = "reversais";
            this.dgcRateIsReverse.MinimumWidth = 8;
            this.dgcRateIsReverse.Name = "dgcRateIsReverse";
            this.dgcRateIsReverse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcRateIsReverse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcRateIsReverse.TrueValue = "1";
            this.dgcRateIsReverse.Width = 80;
            // 
            // dgcRateId
            // 
            this.dgcRateId.DataPropertyName = "ID";
            this.dgcRateId.HeaderText = "ID";
            this.dgcRateId.MinimumWidth = 8;
            this.dgcRateId.Name = "dgcRateId";
            this.dgcRateId.Visible = false;
            this.dgcRateId.Width = 60;
            // 
            // FormM_PvnRates2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 535);
            this.Controls.Add(this.mySplitContainer1);
            this.Controls.Add(this.myGrid1);
            this.Controls.Add(this.bNav);
            this.Name = "FormM_PvnRates2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kontējumi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormM_PvnRates2_FormClosed);
            this.Load += new System.EventHandler(this.FormM_PvnRates2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsRates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).EndInit();
            this.bNav.ResumeLayout(false);
            this.bNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPVNType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPvnTexts)).EndInit();
            this.mySplitContainer1.Panel1.ResumeLayout(false);
            this.mySplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mySplitContainer1)).EndInit();
            this.mySplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsRates;
        private System.Windows.Forms.BindingSource bsAcc;
        private KlonsLIB.Components.MyDataGridView dgvRates;
        private KlonsLIB.Components.MyBindingNavigator bNav;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bniNew;
        private System.Windows.Forms.ToolStripButton bniDelete;
        private System.Windows.Forms.ToolStripButton bniSave;
        private KlonsLIB.MySourceGrid.MyGrid myGrid1;
        private KlonsLIB.Components.MySplitContainer mySplitContainer1;
        private KlonsLIB.Components.MyDataGridView dgvAcc;
        private DataObjectsFM.PVNRates2Data pvnRates2Data1;
        private KlonsLIB.Data.MyBindingSource bsPVNType;
        private KlonsLIB.Data.MyBindingSource bsDocType;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grRateName;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grRateCode;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grTitleRate;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grRateRate;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox grRatesIsReverse;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grAccTitleAcc;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB grAccPvnType;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB grAccTrTp;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxA grAccBaseDebFin;
        private System.Windows.Forms.ToolStripLabel lbActiveGrid;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grTitleBase;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grAccBaseDebPvn;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxA grAccBaseCredFin;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grAccBaseCredPvn;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grTitlePVN;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxA grAccPVNDebFin;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grAccPVNDebPvn;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxA grAccPVNCredBFin;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grAccPVNCredPvn;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grAccTitleTexts;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grAccBaseText;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grAccPVNText;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem rādītPaslēptDatuPaneliToolStripMenuItem;
        private KlonsLIB.Data.MyBindingSource bsPvnTexts;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grAccIdPVNText;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcAccIdTp;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcAccTrTp;
        private KlonsLIB.Components.MyDgvCheckBoxColumn dgcAccInCurMt;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcAccBaseDebFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccBaseDebPvn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcAccBaseCredFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccBaseCredPvn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcAccPvnDebFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccPvnDebPvn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcAccPvnCredFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccPvnCredPvn;
        private KlonsLIB.Components.MyDgvCheckBoxColumn dgcChangeSign;
        private KlonsLIB.Components.MyDgvTextboxColumn2 dgcAccIdPVNText;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccBaseText;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccPvnText;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAccIdRate;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox grAccInCurMt;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox grAccChangeSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRatesCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRatesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcRatesRate;
        private KlonsLIB.Components.MyDgvCheckBoxColumn dgcRateIsReverse;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRateId;
    }
}