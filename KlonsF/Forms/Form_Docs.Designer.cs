using KlonsF.UI;
using KlonsF.DataSets;
using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.Forms
{
    partial class Form_Docs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Docs));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new KlonsLIB.Components.MySplitContainer();
            this.dgvDocs = new KlonsLIB.Components.MyDataGridView();
            this.bsDocTyp = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsClid = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsClid2 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsOPSd = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsOPS = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.dgvOps = new KlonsLIB.Components.MyDataGridView();
            this.dgcOpsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsDocId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsAC11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsAC12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsAC13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsAC14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsAC15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsAC21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsAC22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsAC23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsAC24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsAC25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsSummC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsCur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsSumm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsQV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOpsNL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnavNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
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
            this.ToolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInfo = new System.Windows.Forms.ToolStripButton();
            this.oPSdBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.tsbSearchPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbSearch = new System.Windows.Forms.ToolStripTextBox();
            this.tsbSearchNext = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbsRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.kaseiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasesIeņēmumuOrderisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kasesIzdevumuOrderisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.kasesIeņēmumuOrderaKvītsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasesIzdevumuOrderaKvītsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rēķiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vienkārssRēķinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rēkins2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rēķinsArDaudzumiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pavadzīmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbIeraksti = new System.Windows.Forms.ToolStripButton();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dgcDocsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsZNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsDocTyp = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcDocsDocSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsDocNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsClid = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcDocsDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsSumm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsPVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsClid2 = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.dgcDocsNrx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsDT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsZU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsZDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocsNL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOPSd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavNav)).BeginInit();
            this.bnavNav.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvDocs);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvOps);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(880, 322);
            this.splitContainer1.SplitterDistance = 158;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // dgvDocs
            // 
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDocsId,
            this.dgcDocsZNR,
            this.dgcDocsDate,
            this.dgcDocsDocTyp,
            this.dgcDocsDocSt,
            this.dgcDocsDocNr,
            this.dgcDocsClid,
            this.dgcDocsDescr,
            this.dgcDocsSumm,
            this.dgcDocsPVN,
            this.dgcDocsClid2,
            this.dgcDocsNrx,
            this.dgcDocsDT2,
            this.dgcDocsZU,
            this.dgcDocsZDt,
            this.dgcDocsNL});
            this.dgvDocs.DataSource = this.bsOPSd;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.Location = new System.Drawing.Point(0, 0);
            this.dgvDocs.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.RowTemplate.Height = 23;
            this.dgvDocs.Size = new System.Drawing.Size(880, 158);
            this.dgvDocs.TabIndex = 2;
            this.dgvDocs.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDocs_MyKeyDown);
            this.dgvDocs.MyCheckForChanges += new System.EventHandler(this.dgvDocs_MyCheckForChanges);
            this.dgvDocs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocs_CellDoubleClick);
            this.dgvDocs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocs_CellEndEdit);
            this.dgvDocs.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvDocs_CellParsing);
            this.dgvDocs.CurrentCellChanged += new System.EventHandler(this.dgvDocs_CurrentCellChanged);
            this.dgvDocs.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDocs_DataError);
            this.dgvDocs.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvDocs_DefaultValuesNeeded);
            this.dgvDocs.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocs_RowValidated);
            this.dgvDocs.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDocs_UserDeletingRow);
            this.dgvDocs.Enter += new System.EventHandler(this.dgvDocs_Enter);
            this.dgvDocs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDocs_KeyDown);
            this.dgvDocs.Leave += new System.EventHandler(this.dgvDocs_Leave);
            // 
            // bsDocTyp
            // 
            this.bsDocTyp.DataMember = "DocTyp";
            this.bsDocTyp.MyDataSource = "KlonsData";
            this.bsDocTyp.Sort = "id";
            // 
            // bsClid
            // 
            this.bsClid.DataMember = "Persons";
            this.bsClid.MyDataSource = "KlonsData";
            this.bsClid.Sort = "clid";
            // 
            // bsClid2
            // 
            this.bsClid2.DataMember = "Persons";
            this.bsClid2.MyDataSource = "KlonsData";
            this.bsClid2.Sort = "clid";
            // 
            // bsOPSd
            // 
            this.bsOPSd.AutoSaveChildrenDelete = true;
            this.bsOPSd.AutoSaveOnDelete = true;
            this.bsOPSd.ChildBS = this.bsOPS;
            this.bsOPSd.DataMember = "OPSd";
            this.bsOPSd.MyDataSource = "KlonsData";
            this.bsOPSd.Name2 = "Docs";
            this.bsOPSd.MyBeforeRowInsert += new KlonsLIB.Data.MyRowUpdateEventHandler(this.bsOPSd_MyBeforeRowInsert);
            this.bsOPSd.MyBeforeRowSave += new KlonsLIB.Data.MyRowUpdateEventHandler(this.bsOPSd_MyBeforeRowUpdate);
            this.bsOPSd.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.bsOPSd_AddingNew);
            this.bsOPSd.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsOPSd_ListChanged);
            // 
            // bsOPS
            // 
            this.bsOPS.AllowNew = true;
            this.bsOPS.AutoSaveOnDelete = true;
            this.bsOPS.DataMember = "FK_OPS_DOCID_OPSD_ID";
            this.bsOPS.DataSource = this.bsOPSd;
            this.bsOPS.Name2 = "Ops";
            this.bsOPS.Sort = "";
            this.bsOPS.MyBeforeRowInsert += new KlonsLIB.Data.MyRowUpdateEventHandler(this.bsOPS_MyBeforeRowInsert);
            this.bsOPS.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsOPS_ListChanged);
            // 
            // dgvOps
            // 
            this.dgvOps.AutoGenerateColumns = false;
            this.dgvOps.AutoSave = false;
            this.dgvOps.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvOps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcOpsId,
            this.dgcOpsDocId,
            this.dgcOpsAC11,
            this.dgcOpsAC12,
            this.dgcOpsAC13,
            this.dgcOpsAC14,
            this.dgcOpsAC15,
            this.dgcOpsAC21,
            this.dgcOpsAC22,
            this.dgcOpsAC23,
            this.dgcOpsAC24,
            this.dgcOpsAC25,
            this.dgcOpsSummC,
            this.dgcOpsCur,
            this.dgcOpsSumm,
            this.dgcOpsQV,
            this.dgcOpsDescr,
            this.dgcOpsNL});
            this.dgvOps.DataSource = this.bsOPS;
            this.dgvOps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOps.Location = new System.Drawing.Point(0, 0);
            this.dgvOps.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOps.Name = "dgvOps";
            this.dgvOps.Size = new System.Drawing.Size(880, 159);
            this.dgvOps.TabIndex = 3;
            this.dgvOps.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOps_MyKeyDown);
            this.dgvOps.MyCheckForChanges += new System.EventHandler(this.dgvOps_MyCheckForChanges);
            this.dgvOps.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOps_CellDoubleClick);
            this.dgvOps.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOps_CellEndEdit);
            this.dgvOps.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dgvOps_CellToolTipTextNeeded);
            this.dgvOps.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOps_CellValueChanged);
            this.dgvOps.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvOps_DataError);
            this.dgvOps.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOps_RowValidated);
            this.dgvOps.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvOps_RowValidating);
            this.dgvOps.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvOps_UserDeletingRow);
            this.dgvOps.Enter += new System.EventHandler(this.dgvOps_Enter);
            // 
            // dgcOpsId
            // 
            this.dgcOpsId.DataPropertyName = "id";
            this.dgcOpsId.HeaderText = "id";
            this.dgcOpsId.Name = "dgcOpsId";
            this.dgcOpsId.ReadOnly = true;
            this.dgcOpsId.Visible = false;
            this.dgcOpsId.Width = 40;
            // 
            // dgcOpsDocId
            // 
            this.dgcOpsDocId.DataPropertyName = "DocId";
            this.dgcOpsDocId.HeaderText = "DocId";
            this.dgcOpsDocId.Name = "dgcOpsDocId";
            this.dgcOpsDocId.Visible = false;
            this.dgcOpsDocId.Width = 48;
            // 
            // dgcOpsAC11
            // 
            this.dgcOpsAC11.DataPropertyName = "AC11";
            this.dgcOpsAC11.HeaderText = "Debets";
            this.dgcOpsAC11.Name = "dgcOpsAC11";
            this.dgcOpsAC11.Width = 64;
            // 
            // dgcOpsAC12
            // 
            this.dgcOpsAC12.DataPropertyName = "AC12";
            this.dgcOpsAC12.HeaderText = "D.n.p.";
            this.dgcOpsAC12.Name = "dgcOpsAC12";
            this.dgcOpsAC12.ToolTipText = "debets: naudas plūsma";
            this.dgcOpsAC12.Width = 64;
            // 
            // dgcOpsAC13
            // 
            this.dgcOpsAC13.DataPropertyName = "AC13";
            this.dgcOpsAC13.HeaderText = "D.iin";
            this.dgcOpsAC13.Name = "dgcOpsAC13";
            this.dgcOpsAC13.ToolTipText = "debets: darijumu žurnāls IIN";
            this.dgcOpsAC13.Width = 40;
            // 
            // dgcOpsAC14
            // 
            this.dgcOpsAC14.DataPropertyName = "AC14";
            this.dgcOpsAC14.HeaderText = "D.kat.";
            this.dgcOpsAC14.Name = "dgcOpsAC14";
            this.dgcOpsAC14.ToolTipText = "debets: kategorija";
            this.dgcOpsAC14.Width = 64;
            // 
            // dgcOpsAC15
            // 
            this.dgcOpsAC15.DataPropertyName = "AC15";
            this.dgcOpsAC15.HeaderText = "D.pvn";
            this.dgcOpsAC15.Name = "dgcOpsAC15";
            this.dgcOpsAC15.ToolTipText = "debets: PVN";
            this.dgcOpsAC15.Width = 48;
            // 
            // dgcOpsAC21
            // 
            this.dgcOpsAC21.DataPropertyName = "AC21";
            this.dgcOpsAC21.HeaderText = "Kredīts";
            this.dgcOpsAC21.Name = "dgcOpsAC21";
            this.dgcOpsAC21.Width = 64;
            // 
            // dgcOpsAC22
            // 
            this.dgcOpsAC22.DataPropertyName = "AC22";
            this.dgcOpsAC22.HeaderText = "K.n.p.";
            this.dgcOpsAC22.Name = "dgcOpsAC22";
            this.dgcOpsAC22.ToolTipText = "kredīts: naudas plūsma";
            this.dgcOpsAC22.Width = 64;
            // 
            // dgcOpsAC23
            // 
            this.dgcOpsAC23.DataPropertyName = "AC23";
            this.dgcOpsAC23.HeaderText = "K.iin";
            this.dgcOpsAC23.Name = "dgcOpsAC23";
            this.dgcOpsAC23.ToolTipText = "kredīts: darijumu žurnāls IIN";
            this.dgcOpsAC23.Width = 40;
            // 
            // dgcOpsAC24
            // 
            this.dgcOpsAC24.DataPropertyName = "AC24";
            this.dgcOpsAC24.HeaderText = "K.kat.";
            this.dgcOpsAC24.Name = "dgcOpsAC24";
            this.dgcOpsAC24.ToolTipText = "kredīts: kategorija";
            this.dgcOpsAC24.Width = 64;
            // 
            // dgcOpsAC25
            // 
            this.dgcOpsAC25.DataPropertyName = "AC25";
            this.dgcOpsAC25.HeaderText = "K.pvn";
            this.dgcOpsAC25.Name = "dgcOpsAC25";
            this.dgcOpsAC25.ToolTipText = "kredīts: PVN";
            this.dgcOpsAC25.Width = 48;
            // 
            // dgcOpsSummC
            // 
            this.dgcOpsSummC.DataPropertyName = "SummC";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dgcOpsSummC.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcOpsSummC.HeaderText = "summa";
            this.dgcOpsSummC.Name = "dgcOpsSummC";
            this.dgcOpsSummC.ToolTipText = "Summa";
            this.dgcOpsSummC.Width = 80;
            // 
            // dgcOpsCur
            // 
            this.dgcOpsCur.DataPropertyName = "Cur";
            this.dgcOpsCur.HeaderText = "valūta";
            this.dgcOpsCur.MaxInputLength = 3;
            this.dgcOpsCur.Name = "dgcOpsCur";
            this.dgcOpsCur.Width = 64;
            // 
            // dgcOpsSumm
            // 
            this.dgcOpsSumm.DataPropertyName = "Summ";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.dgcOpsSumm.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcOpsSumm.HeaderText = "EUR";
            this.dgcOpsSumm.Name = "dgcOpsSumm";
            this.dgcOpsSumm.ReadOnly = true;
            this.dgcOpsSumm.ToolTipText = "summa pārrēķināta uz eiro";
            this.dgcOpsSumm.Width = 80;
            // 
            // dgcOpsQV
            // 
            this.dgcOpsQV.DataPropertyName = "QV";
            this.dgcOpsQV.HeaderText = "Daudzums";
            this.dgcOpsQV.Name = "dgcOpsQV";
            this.dgcOpsQV.Width = 80;
            // 
            // dgcOpsDescr
            // 
            this.dgcOpsDescr.DataPropertyName = "Descr";
            this.dgcOpsDescr.HeaderText = "Apraksts";
            this.dgcOpsDescr.Name = "dgcOpsDescr";
            this.dgcOpsDescr.Width = 96;
            // 
            // dgcOpsNL
            // 
            this.dgcOpsNL.DataPropertyName = "NL";
            this.dgcOpsNL.HeaderText = "NL";
            this.dgcOpsNL.Name = "dgcOpsNL";
            this.dgcOpsNL.Visible = false;
            this.dgcOpsNL.Width = 60;
            // 
            // bnavNav
            // 
            this.bnavNav.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnavNav.BindingSource = this.bsOPSd;
            this.bnavNav.CountItem = this.bindingNavigatorCountItem;
            this.bnavNav.CountItemFormat = " no {0}";
            this.bnavNav.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnavNav.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavNav.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.ToolStripButtonCopy,
            this.bindingNavigatorDeleteItem,
            this.toolStripButtonInfo,
            this.oPSdBindingNavigatorSaveItem,
            this.tsbSearchPrev,
            this.tsbSearch,
            this.tsbSearchNext});
            this.bnavNav.Location = new System.Drawing.Point(0, 322);
            this.bnavNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavNav.Name = "bnavNav";
            this.bnavNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavNav.SaveItem = null;
            this.bnavNav.Size = new System.Drawing.Size(880, 32);
            this.bnavNav.TabIndex = 0;
            this.bnavNav.Text = "bindingNavigator1";
            this.bnavNav.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavNav_ItemDeleting);
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(87, 29);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
            this.bindingNavigatorDeleteItem.ToolTipText = "Dzēst (Ctrl+Delete)";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(111, 29);
            this.toolStripLabel1.Text = "Dokumenti:";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.ToolTipText = "Iet uz sākumu";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.ToolTipText = "Iet uz iepriekšējo";
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
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
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.ToolTipText = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.ToolTipText = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // ToolStripButtonCopy
            // 
            this.ToolStripButtonCopy.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonCopy.Image")));
            this.ToolStripButtonCopy.Name = "ToolStripButtonCopy";
            this.ToolStripButtonCopy.Size = new System.Drawing.Size(89, 29);
            this.ToolStripButtonCopy.Text = "Kopēt";
            this.ToolStripButtonCopy.ToolTipText = "Kopēt (Ctrl+Insert)";
            this.ToolStripButtonCopy.Click += new System.EventHandler(this.ToolStripButtonCopy_Click);
            // 
            // toolStripButtonInfo
            // 
            this.toolStripButtonInfo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonInfo.Image")));
            this.toolStripButtonInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInfo.Name = "toolStripButtonInfo";
            this.toolStripButtonInfo.Size = new System.Drawing.Size(69, 29);
            this.toolStripButtonInfo.Text = "Info";
            this.toolStripButtonInfo.Click += new System.EventHandler(this.toolStripButtonInfo_Click);
            // 
            // oPSdBindingNavigatorSaveItem
            // 
            this.oPSdBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.oPSdBindingNavigatorSaveItem.Name = "oPSdBindingNavigatorSaveItem";
            this.oPSdBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 29);
            this.oPSdBindingNavigatorSaveItem.Text = "Save Data";
            this.oPSdBindingNavigatorSaveItem.ToolTipText = "Saglabāt datus (Ctrl + S)";
            this.oPSdBindingNavigatorSaveItem.Click += new System.EventHandler(this.oPSdBindingNavigatorSaveItem_Click);
            // 
            // tsbSearchPrev
            // 
            this.tsbSearchPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSearchPrev.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearchPrev.Image")));
            this.tsbSearchPrev.Name = "tsbSearchPrev";
            this.tsbSearchPrev.RightToLeftAutoMirrorImage = true;
            this.tsbSearchPrev.Size = new System.Drawing.Size(25, 29);
            this.tsbSearchPrev.Text = "Move previous";
            this.tsbSearchPrev.ToolTipText = "Iet uz iepriekšējo";
            this.tsbSearchPrev.Click += new System.EventHandler(this.tsbSearchPrev_Click);
            // 
            // tsbSearch
            // 
            this.tsbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(65, 32);
            this.tsbSearch.ToolTipText = "Meklēt tekstu";
            this.tsbSearch.Enter += new System.EventHandler(this.tsbSearch_Enter);
            this.tsbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tsbSearch_KeyPress);
            // 
            // tsbSearchNext
            // 
            this.tsbSearchNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSearchNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearchNext.Image")));
            this.tsbSearchNext.Name = "tsbSearchNext";
            this.tsbSearchNext.RightToLeftAutoMirrorImage = true;
            this.tsbSearchNext.Size = new System.Drawing.Size(25, 29);
            this.tsbSearchNext.Text = "Move next";
            this.tsbSearchNext.ToolTipText = "Iet uz nākošo";
            this.tsbSearchNext.Click += new System.EventHandler(this.tsbSearchNext_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbsRefresh,
            this.toolStripButton1,
            this.toolStripDropDownButton1,
            this.tsbIeraksti});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(777, 26);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // tbsRefresh
            // 
            this.tbsRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tbsRefresh.Image")));
            this.tbsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsRefresh.Name = "tbsRefresh";
            this.tbsRefresh.Size = new System.Drawing.Size(80, 23);
            this.tbsRefresh.Text = "Pārlasīt";
            this.tbsRefresh.Click += new System.EventHandler(this.tbsRefresh_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(179, 23);
            this.toolStripButton1.Text = "S&aistītie dokumenti";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaseiToolStripMenuItem,
            this.rēķiniToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(97, 23);
            this.toolStripDropDownButton1.Text = "Izdrukai";
            // 
            // kaseiToolStripMenuItem
            // 
            this.kaseiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kasesIeņēmumuOrderisToolStripMenuItem1,
            this.kasesIzdevumuOrderisToolStripMenuItem,
            this.toolStripSeparator1,
            this.kasesIeņēmumuOrderaKvītsToolStripMenuItem,
            this.kasesIzdevumuOrderaKvītsToolStripMenuItem});
            this.kaseiToolStripMenuItem.Name = "kaseiToolStripMenuItem";
            this.kaseiToolStripMenuItem.Size = new System.Drawing.Size(145, 30);
            this.kaseiToolStripMenuItem.Text = "Kase";
            // 
            // kasesIeņēmumuOrderisToolStripMenuItem1
            // 
            this.kasesIeņēmumuOrderisToolStripMenuItem1.Name = "kasesIeņēmumuOrderisToolStripMenuItem1";
            this.kasesIeņēmumuOrderisToolStripMenuItem1.Size = new System.Drawing.Size(349, 30);
            this.kasesIeņēmumuOrderisToolStripMenuItem1.Text = "Kases ieņēmumu orderis";
            this.kasesIeņēmumuOrderisToolStripMenuItem1.Click += new System.EventHandler(this.kasesIeņēmumuOrderisToolStripMenuItem1_Click);
            // 
            // kasesIzdevumuOrderisToolStripMenuItem
            // 
            this.kasesIzdevumuOrderisToolStripMenuItem.Name = "kasesIzdevumuOrderisToolStripMenuItem";
            this.kasesIzdevumuOrderisToolStripMenuItem.Size = new System.Drawing.Size(349, 30);
            this.kasesIzdevumuOrderisToolStripMenuItem.Text = "Kases izdevumu orderis";
            this.kasesIzdevumuOrderisToolStripMenuItem.Click += new System.EventHandler(this.kasesIzdevumuOrderisToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(346, 6);
            // 
            // kasesIeņēmumuOrderaKvītsToolStripMenuItem
            // 
            this.kasesIeņēmumuOrderaKvītsToolStripMenuItem.Name = "kasesIeņēmumuOrderaKvītsToolStripMenuItem";
            this.kasesIeņēmumuOrderaKvītsToolStripMenuItem.Size = new System.Drawing.Size(349, 30);
            this.kasesIeņēmumuOrderaKvītsToolStripMenuItem.Text = "Kases ieņēmumu ordera kvīts";
            this.kasesIeņēmumuOrderaKvītsToolStripMenuItem.Click += new System.EventHandler(this.kasesIeņēmumuOrderaKvītsToolStripMenuItem_Click);
            // 
            // kasesIzdevumuOrderaKvītsToolStripMenuItem
            // 
            this.kasesIzdevumuOrderaKvītsToolStripMenuItem.Name = "kasesIzdevumuOrderaKvītsToolStripMenuItem";
            this.kasesIzdevumuOrderaKvītsToolStripMenuItem.Size = new System.Drawing.Size(349, 30);
            this.kasesIzdevumuOrderaKvītsToolStripMenuItem.Text = "Kases izdevumu ordera kvīts";
            this.kasesIzdevumuOrderaKvītsToolStripMenuItem.Click += new System.EventHandler(this.kasesIzdevumuOrderaKvītsToolStripMenuItem_Click);
            // 
            // rēķiniToolStripMenuItem
            // 
            this.rēķiniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vienkārssRēķinsToolStripMenuItem,
            this.rēkins2ToolStripMenuItem,
            this.rēķinsArDaudzumiemToolStripMenuItem,
            this.toolStripSeparator2,
            this.pavadzīmeToolStripMenuItem});
            this.rēķiniToolStripMenuItem.Name = "rēķiniToolStripMenuItem";
            this.rēķiniToolStripMenuItem.Size = new System.Drawing.Size(145, 30);
            this.rēķiniToolStripMenuItem.Text = "Rēķini";
            // 
            // vienkārssRēķinsToolStripMenuItem
            // 
            this.vienkārssRēķinsToolStripMenuItem.Name = "vienkārssRēķinsToolStripMenuItem";
            this.vienkārssRēķinsToolStripMenuItem.Size = new System.Drawing.Size(298, 30);
            this.vienkārssRēķinsToolStripMenuItem.Text = "vienkāršs rēķins";
            this.vienkārssRēķinsToolStripMenuItem.Click += new System.EventHandler(this.vienkārssRēķinsToolStripMenuItem_Click);
            // 
            // rēkins2ToolStripMenuItem
            // 
            this.rēkins2ToolStripMenuItem.Name = "rēkins2ToolStripMenuItem";
            this.rēkins2ToolStripMenuItem.Size = new System.Drawing.Size(298, 30);
            this.rēkins2ToolStripMenuItem.Text = "rēkins bez daudzumiem";
            this.rēkins2ToolStripMenuItem.Click += new System.EventHandler(this.rēkins2ToolStripMenuItem_Click);
            // 
            // rēķinsArDaudzumiemToolStripMenuItem
            // 
            this.rēķinsArDaudzumiemToolStripMenuItem.Name = "rēķinsArDaudzumiemToolStripMenuItem";
            this.rēķinsArDaudzumiemToolStripMenuItem.Size = new System.Drawing.Size(298, 30);
            this.rēķinsArDaudzumiemToolStripMenuItem.Text = "rēķins ar daudzumiem";
            this.rēķinsArDaudzumiemToolStripMenuItem.Click += new System.EventHandler(this.rēķinsArDaudzumiemToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(295, 6);
            // 
            // pavadzīmeToolStripMenuItem
            // 
            this.pavadzīmeToolStripMenuItem.Name = "pavadzīmeToolStripMenuItem";
            this.pavadzīmeToolStripMenuItem.Size = new System.Drawing.Size(298, 30);
            this.pavadzīmeToolStripMenuItem.Text = "pavadzīme";
            this.pavadzīmeToolStripMenuItem.Click += new System.EventHandler(this.pavadzīmeToolStripMenuItem_Click);
            // 
            // tsbIeraksti
            // 
            this.tsbIeraksti.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbIeraksti.Image = ((System.Drawing.Image)(resources.GetObject("tsbIeraksti.Image")));
            this.tsbIeraksti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIeraksti.Name = "tsbIeraksti";
            this.tsbIeraksti.Size = new System.Drawing.Size(153, 23);
            this.tsbIeraksti.Text = "Ierakstu žurnāls";
            this.tsbIeraksti.Click += new System.EventHandler(this.tsbIeraksti_Click);
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "OPSd",
        "OPS",
        null};
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Save1.png");
            this.imageList1.Images.SetKeyName(1, "Save2.png");
            // 
            // dgcDocsId
            // 
            this.dgcDocsId.DataPropertyName = "id";
            this.dgcDocsId.HeaderText = "id";
            this.dgcDocsId.Name = "dgcDocsId";
            this.dgcDocsId.ReadOnly = true;
            this.dgcDocsId.Visible = false;
            this.dgcDocsId.Width = 56;
            // 
            // dgcDocsZNR
            // 
            this.dgcDocsZNR.DataPropertyName = "ZNR";
            this.dgcDocsZNR.HeaderText = "Nr.";
            this.dgcDocsZNR.Name = "dgcDocsZNR";
            this.dgcDocsZNR.ReadOnly = true;
            this.dgcDocsZNR.Width = 56;
            // 
            // dgcDocsDate
            // 
            this.dgcDocsDate.DataPropertyName = "Dete";
            dataGridViewCellStyle1.Format = "dd.MM.yyyy";
            this.dgcDocsDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcDocsDate.HeaderText = "Datums";
            this.dgcDocsDate.Name = "dgcDocsDate";
            this.dgcDocsDate.Width = 88;
            // 
            // dgcDocsDocTyp
            // 
            this.dgcDocsDocTyp.ColumnNames = new string[] {
        "id",
        "name"};
            this.dgcDocsDocTyp.ColumnWidths = "100;200";
            this.dgcDocsDocTyp.DataPropertyName = "DocTyp";
            this.dgcDocsDocTyp.DataSource = this.bsDocTyp;
            this.dgcDocsDocTyp.DisplayMember = "id";
            this.dgcDocsDocTyp.HeaderText = "Dok.veids";
            this.dgcDocsDocTyp.MaxDropDownItems = 15;
            this.dgcDocsDocTyp.Name = "dgcDocsDocTyp";
            this.dgcDocsDocTyp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcDocsDocTyp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcDocsDocTyp.ValueMember = "id";
            this.dgcDocsDocTyp.Width = 64;
            // 
            // dgcDocsDocSt
            // 
            this.dgcDocsDocSt.DataPropertyName = "DocSt";
            this.dgcDocsDocSt.HeaderText = "Sērija";
            this.dgcDocsDocSt.Name = "dgcDocsDocSt";
            this.dgcDocsDocSt.Width = 48;
            // 
            // dgcDocsDocNr
            // 
            this.dgcDocsDocNr.DataPropertyName = "DocNr";
            this.dgcDocsDocNr.HeaderText = "Dok.nr.";
            this.dgcDocsDocNr.Name = "dgcDocsDocNr";
            this.dgcDocsDocNr.Width = 88;
            // 
            // dgcDocsClid
            // 
            this.dgcDocsClid.ColumnNames = new string[] {
        "clid",
        "name"};
            this.dgcDocsClid.ColumnWidths = "120;400";
            this.dgcDocsClid.DataPropertyName = "ClId";
            this.dgcDocsClid.DataSource = this.bsClid;
            this.dgcDocsClid.DisplayMember = "ClId";
            this.dgcDocsClid.HeaderText = "Persona";
            this.dgcDocsClid.MaxDropDownItems = 15;
            this.dgcDocsClid.Name = "dgcDocsClid";
            this.dgcDocsClid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcDocsClid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcDocsClid.ValueMember = "ClId";
            this.dgcDocsClid.Width = 96;
            // 
            // dgcDocsDescr
            // 
            this.dgcDocsDescr.DataPropertyName = "Descr";
            this.dgcDocsDescr.HeaderText = "Apraksts";
            this.dgcDocsDescr.Name = "dgcDocsDescr";
            this.dgcDocsDescr.Width = 128;
            // 
            // dgcDocsSumm
            // 
            this.dgcDocsSumm.DataPropertyName = "Summ";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dgcDocsSumm.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcDocsSumm.HeaderText = "Summa";
            this.dgcDocsSumm.Name = "dgcDocsSumm";
            this.dgcDocsSumm.Width = 80;
            // 
            // dgcDocsPVN
            // 
            this.dgcDocsPVN.DataPropertyName = "PVN";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dgcDocsPVN.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcDocsPVN.HeaderText = "PVN";
            this.dgcDocsPVN.Name = "dgcDocsPVN";
            this.dgcDocsPVN.Width = 80;
            // 
            // dgcDocsClid2
            // 
            this.dgcDocsClid2.ColumnNames = new string[] {
        "clid",
        "name"};
            this.dgcDocsClid2.ColumnWidths = "120;400";
            this.dgcDocsClid2.DataPropertyName = "ClId2";
            this.dgcDocsClid2.DataSource = this.bsClid2;
            this.dgcDocsClid2.DisplayMember = "ClId";
            this.dgcDocsClid2.HeaderText = "Nor.pers.";
            this.dgcDocsClid2.MaxDropDownItems = 15;
            this.dgcDocsClid2.Name = "dgcDocsClid2";
            this.dgcDocsClid2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcDocsClid2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcDocsClid2.ToolTipText = "Norēķinu persona (av.nor., kases orderi)";
            this.dgcDocsClid2.ValueMember = "ClId";
            this.dgcDocsClid2.Width = 96;
            // 
            // dgcDocsNrx
            // 
            this.dgcDocsNrx.DataPropertyName = "NrX";
            this.dgcDocsNrx.HeaderText = "Nr.2";
            this.dgcDocsNrx.Name = "dgcDocsNrx";
            this.dgcDocsNrx.Width = 40;
            // 
            // dgcDocsDT2
            // 
            this.dgcDocsDT2.DataPropertyName = "DT2";
            dataGridViewCellStyle4.Format = "dd.MM.yyyy";
            this.dgcDocsDT2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcDocsDT2.HeaderText = "Datums2";
            this.dgcDocsDT2.Name = "dgcDocsDT2";
            this.dgcDocsDT2.Width = 88;
            // 
            // dgcDocsZU
            // 
            this.dgcDocsZU.DataPropertyName = "ZU";
            this.dgcDocsZU.HeaderText = "Lietotajs";
            this.dgcDocsZU.Name = "dgcDocsZU";
            this.dgcDocsZU.ReadOnly = true;
            this.dgcDocsZU.Width = 80;
            // 
            // dgcDocsZDt
            // 
            this.dgcDocsZDt.DataPropertyName = "ZDt";
            this.dgcDocsZDt.HeaderText = "Labojuma laiks";
            this.dgcDocsZDt.Name = "dgcDocsZDt";
            this.dgcDocsZDt.ReadOnly = true;
            this.dgcDocsZDt.Width = 128;
            // 
            // dgcDocsNL
            // 
            this.dgcDocsNL.DataPropertyName = "NL";
            this.dgcDocsNL.HeaderText = "NL";
            this.dgcDocsNL.Name = "dgcDocsNL";
            this.dgcDocsNL.Visible = false;
            this.dgcDocsNL.Width = 60;
            // 
            // Form_Docs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(880, 354);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bnavNav);
            this.MyToolStrip = this.toolStrip1;
            this.Name = "Form_Docs";
            this.Text = "Dokumentu reģistrs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDocs_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDocs_FormClosed);
            this.Load += new System.EventHandler(this.FormDocs_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOPSd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavNav)).EndInit();
            this.bnavNav.ResumeLayout(false);
            this.bnavNav.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingSource bsOPSd;
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
        private System.Windows.Forms.ToolStripButton oPSdBindingNavigatorSaveItem;
        private MyBindingSource2 bsOPS;
        private KlonsLIB.Components.MySplitContainer splitContainer1;
        private MyDataGridView dgvDocs;
        private MyDataGridView dgvOps;
        private MyBindingSource bsClid;
        private MyBindingSource bsClid2;
        private MyBindingSource bsDocTyp;
        private System.Windows.Forms.ToolStripButton toolStripButtonInfo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonCopy;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbIeraksti;
        private System.Windows.Forms.ToolStripButton tbsRefresh;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem kaseiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kasesIeņēmumuOrderisToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kasesIzdevumuOrderisToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem kasesIeņēmumuOrderaKvītsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kasesIzdevumuOrderaKvītsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem rēķiniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vienkārssRēķinsToolStripMenuItem;
        private MyAdapterManager myAdapterManager1;
        private System.Windows.Forms.ToolStripButton tsbSearchPrev;
        private System.Windows.Forms.ToolStripTextBox tsbSearch;
        private System.Windows.Forms.ToolStripButton tsbSearchNext;
        private System.Windows.Forms.ToolStripMenuItem rēkins2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rēķinsArDaudzumiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem pavadzīmeToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsDocId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsAC11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsAC12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsAC13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsAC14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsAC15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsAC21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsAC22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsAC23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsAC24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsAC25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsSummC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsCur;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsSumm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsQV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOpsNL;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsZNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsDate;
        private MyDgvMcCBColumn dgcDocsDocTyp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsDocSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsDocNr;
        private MyDgvMcCBColumn dgcDocsClid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsSumm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsPVN;
        private MyDgvMcCBColumn dgcDocsClid2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsNrx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsDT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsZU;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsZDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocsNL;
    }
}