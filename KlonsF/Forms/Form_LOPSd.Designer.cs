using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.Forms
{
    partial class Form_LOPSd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LOPSd));
            this.bsLOPSd = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bnavLOPSd = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSearchPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbSearch = new System.Windows.Forms.ToolStripTextBox();
            this.tsbSearchNext = new System.Windows.Forms.ToolStripButton();
            this.dgvLOPSd = new KlonsLIB.Components.MyDataGridView();
            this.dgcLOPSDidl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDZDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDdtld = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDODT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDusl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDZU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDtpl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDZNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDDocTyp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDDocSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDDocNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDClid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDDerscr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDSumm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDPVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDNrX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSDClid2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsbDocLog = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bsLOPSd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavLOPSd)).BeginInit();
            this.bnavLOPSd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLOPSd)).BeginInit();
            this.SuspendLayout();
            // 
            // bsLOPSd
            // 
            this.bsLOPSd.DataMember = "LOPSD";
            this.bsLOPSd.MyDataSource = "KlonsData";
            this.bsLOPSd.Name2 = "bsLOPSd";
            // 
            // bnavLOPSd
            // 
            this.bnavLOPSd.AddNewItem = null;
            this.bnavLOPSd.BindingSource = this.bsLOPSd;
            this.bnavLOPSd.CountItem = this.bindingNavigatorCountItem;
            this.bnavLOPSd.CountItemFormat = " no {0}";
            this.bnavLOPSd.DeleteItem = null;
            this.bnavLOPSd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavLOPSd.ImageScalingSize = new System.Drawing.Size(23, 26);
            this.bnavLOPSd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.tsbSearchPrev,
            this.tsbSearch,
            this.tsbSearchNext,
            this.tsbDocLog});
            this.bnavLOPSd.Location = new System.Drawing.Point(0, 392);
            this.bnavLOPSd.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavLOPSd.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavLOPSd.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavLOPSd.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavLOPSd.Name = "bnavLOPSd";
            this.bnavLOPSd.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavLOPSd.SaveItem = null;
            this.bnavLOPSd.Size = new System.Drawing.Size(1023, 39);
            this.bnavLOPSd.TabIndex = 0;
            this.bnavLOPSd.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(76, 34);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Skaits";
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
            this.bindingNavigatorMoveNextItem.Text = "+";
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
            // tsbSearchPrev
            // 
            this.tsbSearchPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSearchPrev.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearchPrev.Image")));
            this.tsbSearchPrev.Name = "tsbSearchPrev";
            this.tsbSearchPrev.RightToLeftAutoMirrorImage = true;
            this.tsbSearchPrev.Size = new System.Drawing.Size(34, 34);
            this.tsbSearchPrev.Text = "Iet uz iepriekšējo";
            this.tsbSearchPrev.Click += new System.EventHandler(this.tsbSearchPrev_Click);
            // 
            // tsbSearch
            // 
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(91, 39);
            this.tsbSearch.Enter += new System.EventHandler(this.tsbSearch_Enter);
            this.tsbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tsbSearch_KeyPress);
            // 
            // tsbSearchNext
            // 
            this.tsbSearchNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSearchNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearchNext.Image")));
            this.tsbSearchNext.Name = "tsbSearchNext";
            this.tsbSearchNext.RightToLeftAutoMirrorImage = true;
            this.tsbSearchNext.Size = new System.Drawing.Size(34, 34);
            this.tsbSearchNext.Text = "+";
            this.tsbSearchNext.Click += new System.EventHandler(this.tsbSearchNext_Click);
            // 
            // dgvLOPSd
            // 
            this.dgvLOPSd.AutoGenerateColumns = false;
            this.dgvLOPSd.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLOPSd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLOPSd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcLOPSDidl,
            this.dgcLOPSDid,
            this.dgcLOPSDZDt,
            this.dgcLOPSDdtld,
            this.dgcLOPSDODT,
            this.dgcLOPSDusl,
            this.dgcLOPSDZU,
            this.dgcLOPSDtpl,
            this.dgcLOPSDZNR,
            this.dgcLOPSDDate,
            this.dgcLOPSDDocTyp,
            this.dgcLOPSDDocSt,
            this.dgcLOPSDDocNr,
            this.dgcLOPSDClid,
            this.dgcLOPSDDerscr,
            this.dgcLOPSDSumm,
            this.dgcLOPSDPVN,
            this.dgcLOPSDNrX,
            this.dgcLOPSDClid2});
            this.dgvLOPSd.DataSource = this.bsLOPSd;
            this.dgvLOPSd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLOPSd.Location = new System.Drawing.Point(0, 0);
            this.dgvLOPSd.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLOPSd.Name = "dgvLOPSd";
            this.dgvLOPSd.ReadOnly = true;
            this.dgvLOPSd.RowHeadersWidth = 62;
            this.dgvLOPSd.RowTemplate.Height = 23;
            this.dgvLOPSd.ShowCellToolTips = false;
            this.dgvLOPSd.Size = new System.Drawing.Size(1023, 392);
            this.dgvLOPSd.TabIndex = 1;
            this.dgvLOPSd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLOPSd_KeyDown);
            // 
            // dgcLOPSDidl
            // 
            this.dgcLOPSDidl.DataPropertyName = "idl";
            this.dgcLOPSDidl.HeaderText = "idl";
            this.dgcLOPSDidl.MinimumWidth = 9;
            this.dgcLOPSDidl.Name = "dgcLOPSDidl";
            this.dgcLOPSDidl.ReadOnly = true;
            this.dgcLOPSDidl.Visible = false;
            this.dgcLOPSDidl.Width = 90;
            // 
            // dgcLOPSDid
            // 
            this.dgcLOPSDid.DataPropertyName = "id";
            this.dgcLOPSDid.HeaderText = "id";
            this.dgcLOPSDid.MinimumWidth = 9;
            this.dgcLOPSDid.Name = "dgcLOPSDid";
            this.dgcLOPSDid.ReadOnly = true;
            this.dgcLOPSDid.ToolTipText = "labojuma id";
            this.dgcLOPSDid.Width = 72;
            // 
            // dgcLOPSDZDt
            // 
            this.dgcLOPSDZDt.DataPropertyName = "ZDt";
            this.dgcLOPSDZDt.HeaderText = "labots.dat.";
            this.dgcLOPSDZDt.MinimumWidth = 9;
            this.dgcLOPSDZDt.Name = "dgcLOPSDZDt";
            this.dgcLOPSDZDt.ReadOnly = true;
            this.dgcLOPSDZDt.ToolTipText = "labojuma datums";
            this.dgcLOPSDZDt.Width = 144;
            // 
            // dgcLOPSDdtld
            // 
            this.dgcLOPSDdtld.DataPropertyName = "dtld";
            this.dgcLOPSDdtld.HeaderText = "dzēsts dat.";
            this.dgcLOPSDdtld.MinimumWidth = 9;
            this.dgcLOPSDdtld.Name = "dgcLOPSDdtld";
            this.dgcLOPSDdtld.ReadOnly = true;
            this.dgcLOPSDdtld.ToolTipText = "dzēšanas datums";
            this.dgcLOPSDdtld.Width = 144;
            // 
            // dgcLOPSDODT
            // 
            this.dgcLOPSDODT.DataPropertyName = "ODT";
            this.dgcLOPSDODT.HeaderText = "datums no";
            this.dgcLOPSDODT.MinimumWidth = 8;
            this.dgcLOPSDODT.Name = "dgcLOPSDODT";
            this.dgcLOPSDODT.ReadOnly = true;
            this.dgcLOPSDODT.ToolTipText = "dokumenta izveides vai iepriekšējā labojuma datums";
            this.dgcLOPSDODT.Width = 144;
            // 
            // dgcLOPSDusl
            // 
            this.dgcLOPSDusl.DataPropertyName = "usl";
            this.dgcLOPSDusl.HeaderText = "lietotājs";
            this.dgcLOPSDusl.MinimumWidth = 9;
            this.dgcLOPSDusl.Name = "dgcLOPSDusl";
            this.dgcLOPSDusl.ReadOnly = true;
            this.dgcLOPSDusl.Visible = false;
            this.dgcLOPSDusl.Width = 90;
            // 
            // dgcLOPSDZU
            // 
            this.dgcLOPSDZU.DataPropertyName = "ZU";
            this.dgcLOPSDZU.HeaderText = "lietotājs";
            this.dgcLOPSDZU.MinimumWidth = 9;
            this.dgcLOPSDZU.Name = "dgcLOPSDZU";
            this.dgcLOPSDZU.ReadOnly = true;
            this.dgcLOPSDZU.Width = 90;
            // 
            // dgcLOPSDtpl
            // 
            this.dgcLOPSDtpl.DataPropertyName = "tpl";
            this.dgcLOPSDtpl.HeaderText = "tpl";
            this.dgcLOPSDtpl.MinimumWidth = 9;
            this.dgcLOPSDtpl.Name = "dgcLOPSDtpl";
            this.dgcLOPSDtpl.ReadOnly = true;
            this.dgcLOPSDtpl.Visible = false;
            this.dgcLOPSDtpl.Width = 90;
            // 
            // dgcLOPSDZNR
            // 
            this.dgcLOPSDZNR.DataPropertyName = "ZNR";
            this.dgcLOPSDZNR.HeaderText = "nr.p.k.";
            this.dgcLOPSDZNR.MinimumWidth = 9;
            this.dgcLOPSDZNR.Name = "dgcLOPSDZNR";
            this.dgcLOPSDZNR.ReadOnly = true;
            this.dgcLOPSDZNR.Width = 72;
            // 
            // dgcLOPSDDate
            // 
            this.dgcLOPSDDate.DataPropertyName = "Dete";
            this.dgcLOPSDDate.HeaderText = "datums";
            this.dgcLOPSDDate.MinimumWidth = 9;
            this.dgcLOPSDDate.Name = "dgcLOPSDDate";
            this.dgcLOPSDDate.ReadOnly = true;
            this.dgcLOPSDDate.Width = 99;
            // 
            // dgcLOPSDDocTyp
            // 
            this.dgcLOPSDDocTyp.DataPropertyName = "DocTyp";
            this.dgcLOPSDDocTyp.HeaderText = "dok.veids";
            this.dgcLOPSDDocTyp.MinimumWidth = 9;
            this.dgcLOPSDDocTyp.Name = "dgcLOPSDDocTyp";
            this.dgcLOPSDDocTyp.ReadOnly = true;
            this.dgcLOPSDDocTyp.Width = 90;
            // 
            // dgcLOPSDDocSt
            // 
            this.dgcLOPSDDocSt.DataPropertyName = "DocSt";
            this.dgcLOPSDDocSt.HeaderText = "sērija";
            this.dgcLOPSDDocSt.MinimumWidth = 9;
            this.dgcLOPSDDocSt.Name = "dgcLOPSDDocSt";
            this.dgcLOPSDDocSt.ReadOnly = true;
            this.dgcLOPSDDocSt.Width = 54;
            // 
            // dgcLOPSDDocNr
            // 
            this.dgcLOPSDDocNr.DataPropertyName = "DocNr";
            this.dgcLOPSDDocNr.HeaderText = "dok.nr.";
            this.dgcLOPSDDocNr.MinimumWidth = 9;
            this.dgcLOPSDDocNr.Name = "dgcLOPSDDocNr";
            this.dgcLOPSDDocNr.ReadOnly = true;
            this.dgcLOPSDDocNr.Width = 90;
            // 
            // dgcLOPSDClid
            // 
            this.dgcLOPSDClid.DataPropertyName = "ClId";
            this.dgcLOPSDClid.HeaderText = "persona";
            this.dgcLOPSDClid.MinimumWidth = 9;
            this.dgcLOPSDClid.Name = "dgcLOPSDClid";
            this.dgcLOPSDClid.ReadOnly = true;
            this.dgcLOPSDClid.Width = 108;
            // 
            // dgcLOPSDDerscr
            // 
            this.dgcLOPSDDerscr.DataPropertyName = "Descr";
            this.dgcLOPSDDerscr.HeaderText = "apraksts";
            this.dgcLOPSDDerscr.MinimumWidth = 9;
            this.dgcLOPSDDerscr.Name = "dgcLOPSDDerscr";
            this.dgcLOPSDDerscr.ReadOnly = true;
            this.dgcLOPSDDerscr.Width = 135;
            // 
            // dgcLOPSDSumm
            // 
            this.dgcLOPSDSumm.DataPropertyName = "Summ";
            this.dgcLOPSDSumm.HeaderText = "summa";
            this.dgcLOPSDSumm.MinimumWidth = 9;
            this.dgcLOPSDSumm.Name = "dgcLOPSDSumm";
            this.dgcLOPSDSumm.ReadOnly = true;
            this.dgcLOPSDSumm.Width = 90;
            // 
            // dgcLOPSDPVN
            // 
            this.dgcLOPSDPVN.DataPropertyName = "PVN";
            this.dgcLOPSDPVN.HeaderText = "PVN";
            this.dgcLOPSDPVN.MinimumWidth = 9;
            this.dgcLOPSDPVN.Name = "dgcLOPSDPVN";
            this.dgcLOPSDPVN.ReadOnly = true;
            this.dgcLOPSDPVN.Width = 90;
            // 
            // dgcLOPSDNrX
            // 
            this.dgcLOPSDNrX.DataPropertyName = "NrX";
            this.dgcLOPSDNrX.HeaderText = "nr.2";
            this.dgcLOPSDNrX.MinimumWidth = 9;
            this.dgcLOPSDNrX.Name = "dgcLOPSDNrX";
            this.dgcLOPSDNrX.ReadOnly = true;
            this.dgcLOPSDNrX.Width = 72;
            // 
            // dgcLOPSDClid2
            // 
            this.dgcLOPSDClid2.DataPropertyName = "ClId2";
            this.dgcLOPSDClid2.HeaderText = "persona2";
            this.dgcLOPSDClid2.MinimumWidth = 9;
            this.dgcLOPSDClid2.Name = "dgcLOPSDClid2";
            this.dgcLOPSDClid2.ReadOnly = true;
            this.dgcLOPSDClid2.Width = 108;
            // 
            // tsbDocLog
            // 
            this.tsbDocLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDocLog.Image = ((System.Drawing.Image)(resources.GetObject("tsbDocLog.Image")));
            this.tsbDocLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDocLog.Name = "tsbDocLog";
            this.tsbDocLog.Size = new System.Drawing.Size(206, 34);
            this.tsbDocLog.Text = "Dokumenta vēsture";
            this.tsbDocLog.Click += new System.EventHandler(this.tsbDocLog_Click);
            // 
            // Form_LOPSd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 431);
            this.CloseOnEscape = true;
            this.Controls.Add(this.dgvLOPSd);
            this.Controls.Add(this.bnavLOPSd);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_LOPSd";
            this.Text = "Dokumentu datu izmaiņu reģistrs";
            this.Load += new System.EventHandler(this.FormLOPSd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsLOPSd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavLOPSd)).EndInit();
            this.bnavLOPSd.ResumeLayout(false);
            this.bnavLOPSd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLOPSd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingSource bsLOPSd;
        private MyBindingNavigator bnavLOPSd;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private MyDataGridView dgvLOPSd;
        private System.Windows.Forms.ToolStripButton tsbSearchPrev;
        private System.Windows.Forms.ToolStripTextBox tsbSearch;
        private System.Windows.Forms.ToolStripButton tsbSearchNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDidl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDZDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDdtld;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDODT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDusl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDZU;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDtpl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDZNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDDocTyp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDDocSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDDocNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDClid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDDerscr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDSumm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDPVN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDNrX;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSDClid2;
        private System.Windows.Forms.ToolStripButton tsbDocLog;
    }
}