namespace KlonsP.Forms
{
    partial class Form_Cat1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Cat1));
            this.bsCat1 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvCat1 = new KlonsLIB.Components.MyDataGridView();
            this.dgcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIDCD = new KlonsLIB.Components.MyDgvMcComboBoxColumn();
            this.bsCatD = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcIDCT = new KlonsLIB.Components.MyDgvMcComboBoxColumn();
            this.bsCatT = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgcGroup = new KlonsLIB.Components.MyDgvCheckBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnCat1 = new KlonsLIB.Components.MyBindingNavigator();
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
            ((System.ComponentModel.ISupportInitialize)(this.bsCat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCatD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCatT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnCat1)).BeginInit();
            this.bnCat1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bsCat1
            // 
            this.bsCat1.DataMember = "CAT1";
            this.bsCat1.MyDataSource = "KlonsData";
            this.bsCat1.Sort = "CODE";
            this.bsCat1.UseDataGridView = this.dgvCat1;
            this.bsCat1.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsCat1_ListChanged);
            // 
            // dgvCat1
            // 
            this.dgvCat1.AutoGenerateColumns = false;
            this.dgvCat1.AutoSave = false;
            this.dgvCat1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCat1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCat1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCat1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcCode,
            this.dgcDescr,
            this.dgcIDCD,
            this.dgcIDCT,
            this.dgcGroup,
            this.dgcID});
            this.dgvCat1.DataSource = this.bsCat1;
            this.dgvCat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCat1.Location = new System.Drawing.Point(0, 0);
            this.dgvCat1.Name = "dgvCat1";
            this.dgvCat1.RowTemplate.Height = 24;
            this.dgvCat1.Size = new System.Drawing.Size(829, 296);
            this.dgvCat1.TabIndex = 0;
            this.dgvCat1.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCat1_MyKeyDown);
            this.dgvCat1.MyCheckForChanges += new System.EventHandler(this.dgvCat1_MyCheckForChanges);
            this.dgvCat1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCat1_CellBeginEdit);
            this.dgvCat1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCat1_CellDoubleClick);
            this.dgvCat1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvCat1_UserDeletingRow);
            this.dgvCat1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvCat1_KeyPress);
            // 
            // dgcCode
            // 
            this.dgcCode.DataPropertyName = "CODE";
            this.dgcCode.HeaderText = "kods";
            this.dgcCode.Name = "dgcCode";
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "DESCR";
            this.dgcDescr.HeaderText = "nosaukums";
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.Width = 400;
            // 
            // dgcIDCD
            // 
            this.dgcIDCD.ColumnNames = new string[] {
        "CODE",
        "DESCR"};
            this.dgcIDCD.ColumnWidths = "60;300";
            this.dgcIDCD.DataPropertyName = "IDCD";
            this.dgcIDCD.DataSource = this.bsCatD;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcIDCD.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcIDCD.DisplayMember = "CODE";
            this.dgcIDCD.DisplayStyleForCurrentCellOnly = true;
            this.dgcIDCD.HeaderText = "nol.kat.";
            this.dgcIDCD.MaxDropDownItems = 15;
            this.dgcIDCD.Name = "dgcIDCD";
            this.dgcIDCD.ToolTipText = "nolietojuma kategorija";
            this.dgcIDCD.ValueMember = "ID";
            // 
            // bsCatD
            // 
            this.bsCatD.DataMember = "CATD";
            this.bsCatD.MyDataSource = "KlonsData";
            this.bsCatD.Sort = "CODE";
            // 
            // dgcIDCT
            // 
            this.dgcIDCT.ColumnNames = new string[] {
        "CODE",
        "DESCR"};
            this.dgcIDCT.ColumnWidths = "60;300";
            this.dgcIDCT.DataPropertyName = "IDCT";
            this.dgcIDCT.DataSource = this.bsCatT;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcIDCT.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcIDCT.DisplayMember = "CODE";
            this.dgcIDCT.DisplayStyleForCurrentCellOnly = true;
            this.dgcIDCT.HeaderText = "nod.kat.";
            this.dgcIDCT.MaxDropDownItems = 15;
            this.dgcIDCT.Name = "dgcIDCT";
            this.dgcIDCT.ToolTipText = "nolietojuma kategorija nodokļu vajadzībām";
            this.dgcIDCT.ValueMember = "ID";
            // 
            // bsCatT
            // 
            this.bsCatT.DataMember = "CATT";
            this.bsCatT.MyDataSource = "KlonsData";
            this.bsCatT.Sort = "CODE";
            // 
            // dgcGroup
            // 
            this.dgcGroup.DataPropertyName = "GROUP";
            this.dgcGroup.FalseValue = "0";
            this.dgcGroup.HeaderText = "kopā";
            this.dgcGroup.Name = "dgcGroup";
            this.dgcGroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcGroup.ToolTipText = "kategosrija apakškategoriju summēšanai";
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
            // bnCat1
            // 
            this.bnCat1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnCat1.BindingSource = this.bsCat1;
            this.bnCat1.CountItem = this.bindingNavigatorCountItem;
            this.bnCat1.CountItemFormat = " no {0}";
            this.bnCat1.DataGrid = this.dgvCat1;
            this.bnCat1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnCat1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnCat1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnCat1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnCat1.Location = new System.Drawing.Point(0, 296);
            this.bnCat1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnCat1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnCat1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnCat1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnCat1.Name = "bnCat1";
            this.bnCat1.PositionItem = this.bindingNavigatorPositionItem;
            this.bnCat1.SaveItem = this.bindingNavigatorSaveItem;
            this.bnCat1.Size = new System.Drawing.Size(829, 32);
            this.bnCat1.TabIndex = 1;
            this.bnCat1.Text = "myBindingNavigator1";
            this.bnCat1.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnCat1_ItemDeleting);
            this.bnCat1.SaveClicked += new System.EventHandler(this.bnCat1_SaveClicked);
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
        "CAT1",
        null};
            // 
            // Form_Cat1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 328);
            this.Controls.Add(this.dgvCat1);
            this.Controls.Add(this.bnCat1);
            this.Name = "Form_Cat1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pamatlīdzekļu kategorijas";
            this.Load += new System.EventHandler(this.Form_Cat1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsCat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCatD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCatT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnCat1)).EndInit();
            this.bnCat1.ResumeLayout(false);
            this.bnCat1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsCat1;
        private KlonsLIB.Components.MyDataGridView dgvCat1;
        private KlonsLIB.Components.MyBindingNavigator bnCat1;
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
        private KlonsLIB.Data.MyBindingSource bsCatD;
        private KlonsLIB.Data.MyBindingSource bsCatT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescr;
        private KlonsLIB.Components.MyDgvMcComboBoxColumn dgcIDCD;
        private KlonsLIB.Components.MyDgvMcComboBoxColumn dgcIDCT;
        private KlonsLIB.Components.MyDgvCheckBoxColumn dgcGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
    }
}