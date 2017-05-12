using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.Forms
{
    partial class Form_AcP3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AcP3));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new KlonsLIB.Components.MyTextBox();
            this.tbIdx = new KlonsLIB.Components.MyPickRowTextBox();
            this.dgvAcP3 = new KlonsLIB.Components.MyDataGridView();
            this.dgcIdx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAcP3 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bnavAcp3 = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavAcp3)).BeginInit();
            this.bnavAcp3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "meklēt:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kods:";
            // 
            // tbSearch
            // 
            this.tbSearch.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSearch.Location = new System.Drawing.Point(198, 6);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(88, 22);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // tbIdx
            // 
            this.tbIdx.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbIdx.DataMember = null;
            this.tbIdx.Location = new System.Drawing.Point(54, 6);
            this.tbIdx.Margin = new System.Windows.Forms.Padding(2);
            this.tbIdx.Name = "tbIdx";
            this.tbIdx.SelectedIndex = -1;
            this.tbIdx.Size = new System.Drawing.Size(80, 22);
            this.tbIdx.TabIndex = 0;
            this.tbIdx.RowSelectedEvent += new KlonsLIB.Components.RowSelectedEventHandler(this.tbIdx_RowSelectedEvent);
            this.tbIdx.Enter += new System.EventHandler(this.tbIdx_Enter);
            // 
            // dgvAcP3
            // 
            this.dgvAcP3.AllowUserToAddRows = false;
            this.dgvAcP3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAcP3.AutoGenerateColumns = false;
            this.dgvAcP3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAcP3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcP3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcIdx,
            this.dgcName});
            this.dgvAcP3.DataSource = this.bsAcP3;
            this.dgvAcP3.Location = new System.Drawing.Point(0, 32);
            this.dgvAcP3.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAcP3.Name = "dgvAcP3";
            this.dgvAcP3.ReadOnly = true;
            this.dgvAcP3.RowTemplate.Height = 19;
            this.dgvAcP3.Size = new System.Drawing.Size(462, 283);
            this.dgvAcP3.TabIndex = 2;
            this.dgvAcP3.MyKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAcP3_MyKeyDown);
            this.dgvAcP3.MyCheckForChanges += new System.EventHandler(this.dgvAcP3_MyCheckForChanges);
            this.dgvAcP3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAcP3_CellDoubleClick);
            this.dgvAcP3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAcP3_KeyDown);
            this.dgvAcP3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvAcP3_KeyPress);
            // 
            // dgcIdx
            // 
            this.dgcIdx.DataPropertyName = "idx";
            this.dgcIdx.HeaderText = "kods";
            this.dgcIdx.Name = "dgcIdx";
            this.dgcIdx.ReadOnly = true;
            this.dgcIdx.Width = 64;
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "Name";
            this.dgcName.HeaderText = "nosaukums";
            this.dgcName.Name = "dgcName";
            this.dgcName.ReadOnly = true;
            this.dgcName.Width = 320;
            // 
            // bsAcP3
            // 
            this.bsAcP3.AutoSaveOnDelete = true;
            this.bsAcP3.DataMember = "Acp23";
            this.bsAcP3.Filter = "";
            this.bsAcP3.MyDataSource = "KlonsData";
            this.bsAcP3.Name2 = "bsAcP3";
            this.bsAcP3.Sort = "idx";
            this.bsAcP3.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsAcP3_ListChanged);
            // 
            // bnavAcp3
            // 
            this.bnavAcp3.AddNewItem = null;
            this.bnavAcp3.BindingSource = this.bsAcP3;
            this.bnavAcp3.CountItem = this.bindingNavigatorCountItem;
            this.bnavAcp3.CountItemFormat = " no {0}";
            this.bnavAcp3.DataGrid = this.dgvAcP3;
            this.bnavAcp3.DeleteItem = null;
            this.bnavAcp3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavAcp3.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavAcp3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.tsbSave});
            this.bnavAcp3.Location = new System.Drawing.Point(0, 312);
            this.bnavAcp3.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavAcp3.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavAcp3.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavAcp3.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavAcp3.Name = "bnavAcp3";
            this.bnavAcp3.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavAcp3.Size = new System.Drawing.Size(462, 30);
            this.bnavAcp3.TabIndex = 3;
            this.bnavAcp3.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(69, 27);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Skaits";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(25, 27);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.ToolTipText = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(25, 27);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.ToolTipText = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 30);
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
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(25, 27);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.ToolTipText = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(25, 27);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.ToolTipText = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(25, 27);
            this.tsbSave.Text = "toolStripButton1";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // Form_AcP3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 342);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.tbIdx);
            this.Controls.Add(this.dgvAcP3);
            this.Controls.Add(this.bnavAcp3);
            this.Name = "Form_AcP3";
            this.Text = "Pazīme IIN darijuma žurnālam";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAcP3_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormAcP3_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavAcp3)).EndInit();
            this.bnavAcp3.ResumeLayout(false);
            this.bnavAcp3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingNavigator bnavAcp3;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private MyDataGridView dgvAcP3;
        private MyBindingSource bsAcP3;
        private MyPickRowTextBox tbIdx;
        private MyTextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIdx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.ToolStripButton tsbSave;
    }
}