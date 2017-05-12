namespace KlonsF.Forms
{
    partial class Form_Docs0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Docs0));
            this.dgvDocs0 = new KlonsLIB.Components.MyDataGridView();
            this.dgcAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcClid = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.bsClid = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocTp = new KlonsLIB.Components.MyDgvMcCBColumn();
            this.bsDocTyp = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcDocSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDocs0 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bnavDocs0 = new KlonsLIB.Components.MyBindingNavigator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tspRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbSearchPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbSearch = new System.Windows.Forms.ToolStripTextBox();
            this.tsbSearchNext = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocs0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavDocs0)).BeginInit();
            this.bnavDocs0.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDocs0
            // 
            this.dgvDocs0.AutoGenerateColumns = false;
            this.dgvDocs0.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDocs0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs0.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcAC,
            this.dgcClid,
            this.dgcDate,
            this.dgcDocTp,
            this.dgcDocSt,
            this.dgcDocNr,
            this.dgcSum,
            this.dgcPVN,
            this.dgcDescr,
            this.iDDataGridViewTextBoxColumn});
            this.dgvDocs0.DataSource = this.bsDocs0;
            this.dgvDocs0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs0.Location = new System.Drawing.Point(0, 0);
            this.dgvDocs0.Name = "dgvDocs0";
            this.dgvDocs0.RowTemplate.Height = 24;
            this.dgvDocs0.Size = new System.Drawing.Size(754, 306);
            this.dgvDocs0.TabIndex = 0;
            this.dgvDocs0.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDocs0_MyKeyDown);
            this.dgvDocs0.MyCheckForChanges += new System.EventHandler(this.dgvDocs0_MyCheckForChanges);
            this.dgvDocs0.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocs0_CellDoubleClick);
            this.dgvDocs0.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvDocs0_CellParsing);
            this.dgvDocs0.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dgvDocs0_CellToolTipTextNeeded);
            this.dgvDocs0.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDocs0_UserDeletingRow);
            this.dgvDocs0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDocs0_KeyDown);
            // 
            // dgcAC
            // 
            this.dgcAC.DataPropertyName = "AC";
            this.dgcAC.HeaderText = "Konts";
            this.dgcAC.Name = "dgcAC";
            this.dgcAC.Width = 64;
            // 
            // dgcClid
            // 
            this.dgcClid.ColumnNames = new string[] {
        "clid",
        "name"};
            this.dgcClid.ColumnWidths = "120;400";
            this.dgcClid.DataPropertyName = "CLID";
            this.dgcClid.DataSource = this.bsClid;
            this.dgcClid.DisplayMember = "ClId";
            this.dgcClid.HeaderText = "Persona";
            this.dgcClid.MaxDropDownItems = 15;
            this.dgcClid.Name = "dgcClid";
            this.dgcClid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcClid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcClid.ValueMember = "ClId";
            this.dgcClid.Width = 96;
            // 
            // bsClid
            // 
            this.bsClid.DataMember = "Persons";
            this.bsClid.MyDataSource = "KlonsData";
            this.bsClid.Name2 = null;
            this.bsClid.Sort = "clid";
            // 
            // dgcDate
            // 
            this.dgcDate.DataPropertyName = "DETE";
            dataGridViewCellStyle1.Format = "dd.MM.yyyy";
            this.dgcDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcDate.HeaderText = "Datums";
            this.dgcDate.Name = "dgcDate";
            this.dgcDate.Width = 88;
            // 
            // dgcDocTp
            // 
            this.dgcDocTp.ColumnNames = new string[] {
        "id",
        "name"};
            this.dgcDocTp.ColumnWidths = "100;200";
            this.dgcDocTp.DataPropertyName = "DOCTYP";
            this.dgcDocTp.DataSource = this.bsDocTyp;
            this.dgcDocTp.DisplayMember = "id";
            this.dgcDocTp.HeaderText = "Dok.veids";
            this.dgcDocTp.MaxDropDownItems = 15;
            this.dgcDocTp.Name = "dgcDocTp";
            this.dgcDocTp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcDocTp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcDocTp.ToolTipText = "dokumeta veids";
            this.dgcDocTp.ValueMember = "id";
            this.dgcDocTp.Width = 64;
            // 
            // bsDocTyp
            // 
            this.bsDocTyp.DataMember = "DocTyp";
            this.bsDocTyp.MyDataSource = "KlonsData";
            this.bsDocTyp.Name2 = null;
            this.bsDocTyp.Sort = "id";
            // 
            // dgcDocSt
            // 
            this.dgcDocSt.DataPropertyName = "DOCST";
            this.dgcDocSt.HeaderText = "sērija";
            this.dgcDocSt.Name = "dgcDocSt";
            this.dgcDocSt.Width = 48;
            // 
            // dgcDocNr
            // 
            this.dgcDocNr.DataPropertyName = "DOCNR";
            this.dgcDocNr.HeaderText = "numurs";
            this.dgcDocNr.Name = "dgcDocNr";
            this.dgcDocNr.Width = 88;
            // 
            // dgcSum
            // 
            this.dgcSum.DataPropertyName = "SUMM";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dgcSum.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcSum.HeaderText = "Summa";
            this.dgcSum.Name = "dgcSum";
            this.dgcSum.Width = 80;
            // 
            // dgcPVN
            // 
            this.dgcPVN.DataPropertyName = "PVN";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dgcPVN.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcPVN.HeaderText = "PVN";
            this.dgcPVN.Name = "dgcPVN";
            this.dgcPVN.Width = 80;
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "DESCR";
            this.dgcDescr.HeaderText = "Apraksts";
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.Width = 130;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // bsDocs0
            // 
            this.bsDocs0.AutoSaveOnDelete = true;
            this.bsDocs0.DataMember = "DOCS0";
            this.bsDocs0.MyDataSource = "KlonsData";
            this.bsDocs0.Name2 = null;
            this.bsDocs0.UseDataGridView = this.dgvDocs0;
            this.bsDocs0.MyBeforeRowInsert += new KlonsLIB.Data.MyRowUpdateEventHandler(this.bsDocs0_MyBeforeRowInsert);
            this.bsDocs0.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsDocs0_ListChanged);
            // 
            // bnavDocs0
            // 
            this.bnavDocs0.AddNewItem = this.tsbNew;
            this.bnavDocs0.BindingSource = this.bsDocs0;
            this.bnavDocs0.CountItem = this.bindingNavigatorCountItem;
            this.bnavDocs0.CountItemFormat = " no {0}";
            this.bnavDocs0.DataGrid = this.dgvDocs0;
            this.bnavDocs0.DeleteItem = this.tsbDelete;
            this.bnavDocs0.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavDocs0.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavDocs0.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.tspRefresh,
            this.tsbNew,
            this.tsbDelete,
            this.tsbSave,
            this.tsbSearchPrev,
            this.tsbSearch,
            this.tsbSearchNext});
            this.bnavDocs0.Location = new System.Drawing.Point(0, 306);
            this.bnavDocs0.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavDocs0.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavDocs0.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavDocs0.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavDocs0.Name = "bnavDocs0";
            this.bnavDocs0.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavDocs0.Size = new System.Drawing.Size(754, 32);
            this.bnavDocs0.TabIndex = 1;
            this.bnavDocs0.Text = "myBindingNavigator1";
            this.bnavDocs0.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavDocs0_ItemDeleting);
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.RightToLeftAutoMirrorImage = true;
            this.tsbNew.Size = new System.Drawing.Size(91, 29);
            this.tsbNew.Text = "Jauns";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(69, 29);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.RightToLeftAutoMirrorImage = true;
            this.tsbDelete.Size = new System.Drawing.Size(87, 29);
            this.tsbDelete.Text = "Dzēst";
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
            // tspRefresh
            // 
            this.tspRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tspRefresh.Image")));
            this.tspRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspRefresh.Name = "tspRefresh";
            this.tspRefresh.Size = new System.Drawing.Size(80, 29);
            this.tspRefresh.Text = "Pārlasīt";
            this.tspRefresh.Click += new System.EventHandler(this.tspRefresh_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::KlonsF.Properties.Resources.Save1;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(25, 29);
            this.tsbSave.Text = "toolStripButton1";
            this.tsbSave.ToolTipText = "Saglabāt izmaiņas";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
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
            // Form_Docs0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(754, 338);
            this.Controls.Add(this.dgvDocs0);
            this.Controls.Add(this.bnavDocs0);
            this.Name = "Form_Docs0";
            this.Text = "Neapmaksātie rēķini";
            this.Load += new System.EventHandler(this.Form_Docs0_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocs0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavDocs0)).EndInit();
            this.bnavDocs0.ResumeLayout(false);
            this.bnavDocs0.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Components.MyDataGridView dgvDocs0;
        private KlonsLIB.Components.MyBindingNavigator bnavDocs0;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private KlonsLIB.Data.MyBindingSource bsDocs0;
        private KlonsLIB.Data.MyBindingSource bsClid;
        private KlonsLIB.Data.MyBindingSource bsDocTyp;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tspRefresh;
        private System.Windows.Forms.ToolStripButton tsbSearchNext;
        private System.Windows.Forms.ToolStripTextBox tsbSearch;
        private System.Windows.Forms.ToolStripButton tsbSearchPrev;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAC;
        private KlonsLIB.Components.MyDgvMcCBColumn dgcClid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDate;
        private KlonsLIB.Components.MyDgvMcCBColumn dgcDocTp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPVN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    }
}