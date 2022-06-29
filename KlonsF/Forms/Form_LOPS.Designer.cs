using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.Forms
{
    partial class Form_LOPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LOPS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsLOPS = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bnavLOPS = new KlonsLIB.Components.MyBindingNavigator();
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
            this.dgvLOPS = new KlonsLIB.Components.MyDataGridView();
            this.dgcLOPSidl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPStl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPStld = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSODT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSusl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPStpl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSocId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSAC11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSAC12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSAC13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSAC14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSAC15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSAC21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSAC22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSAC23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSAC24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSAC25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSSumm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLOPSQV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsbDocLog = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bsLOPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavLOPS)).BeginInit();
            this.bnavLOPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLOPS)).BeginInit();
            this.SuspendLayout();
            // 
            // bsLOPS
            // 
            this.bsLOPS.DataMember = "LOPS";
            this.bsLOPS.MyDataSource = "KlonsData";
            this.bsLOPS.Name2 = "bsLOPS";
            // 
            // bnavLOPS
            // 
            this.bnavLOPS.AddNewItem = null;
            this.bnavLOPS.BindingSource = this.bsLOPS;
            this.bnavLOPS.CountItem = this.bindingNavigatorCountItem;
            this.bnavLOPS.CountItemFormat = " no {0}";
            this.bnavLOPS.DeleteItem = null;
            this.bnavLOPS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavLOPS.ImageScalingSize = new System.Drawing.Size(23, 26);
            this.bnavLOPS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bnavLOPS.Location = new System.Drawing.Point(0, 389);
            this.bnavLOPS.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavLOPS.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavLOPS.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavLOPS.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavLOPS.Name = "bnavLOPS";
            this.bnavLOPS.PositionItem = this.bindingNavigatorPositionItem;
            this.bnavLOPS.SaveItem = null;
            this.bnavLOPS.Size = new System.Drawing.Size(1032, 39);
            this.bnavLOPS.TabIndex = 0;
            this.bnavLOPS.Text = "bindingNavigator1";
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
            this.bindingNavigatorMoveNextItem.ToolTipText = "Iet uz nākošo";
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
            this.tsbSearchPrev.ToolTipText = "Meklēt iepriekšējo";
            this.tsbSearchPrev.Click += new System.EventHandler(this.tsbSearchPrev_Click);
            // 
            // tsbSearch
            // 
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(91, 39);
            this.tsbSearch.ToolTipText = "Meklēt";
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
            this.tsbSearchNext.ToolTipText = "Meklēt nākošo";
            this.tsbSearchNext.Click += new System.EventHandler(this.tsbSearchNext_Click);
            // 
            // dgvLOPS
            // 
            this.dgvLOPS.AutoGenerateColumns = false;
            this.dgvLOPS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLOPS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLOPS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcLOPSidl,
            this.dgcLOPSid,
            this.dgcLOPStl,
            this.dgcLOPStld,
            this.dgcLOPSODT,
            this.dgcLOPSusl,
            this.dgcLOPStpl,
            this.dgcLOPSocId,
            this.dgcLOPSAC11,
            this.dgcLOPSAC12,
            this.dgcLOPSAC13,
            this.dgcLOPSAC14,
            this.dgcLOPSAC15,
            this.dgcLOPSAC21,
            this.dgcLOPSAC22,
            this.dgcLOPSAC23,
            this.dgcLOPSAC24,
            this.dgcLOPSAC25,
            this.dgcLOPSSumm,
            this.dgcLOPSQV});
            this.dgvLOPS.DataSource = this.bsLOPS;
            this.dgvLOPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLOPS.Location = new System.Drawing.Point(0, 0);
            this.dgvLOPS.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLOPS.Name = "dgvLOPS";
            this.dgvLOPS.ReadOnly = true;
            this.dgvLOPS.RowHeadersWidth = 62;
            this.dgvLOPS.RowTemplate.Height = 23;
            this.dgvLOPS.ShowCellToolTips = false;
            this.dgvLOPS.Size = new System.Drawing.Size(1032, 389);
            this.dgvLOPS.TabIndex = 1;
            this.dgvLOPS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLOPS_KeyDown);
            // 
            // dgcLOPSidl
            // 
            this.dgcLOPSidl.DataPropertyName = "idl";
            this.dgcLOPSidl.HeaderText = "idl";
            this.dgcLOPSidl.MinimumWidth = 9;
            this.dgcLOPSidl.Name = "dgcLOPSidl";
            this.dgcLOPSidl.ReadOnly = true;
            this.dgcLOPSidl.Visible = false;
            this.dgcLOPSidl.Width = 72;
            // 
            // dgcLOPSid
            // 
            this.dgcLOPSid.DataPropertyName = "id";
            this.dgcLOPSid.HeaderText = "id";
            this.dgcLOPSid.MinimumWidth = 9;
            this.dgcLOPSid.Name = "dgcLOPSid";
            this.dgcLOPSid.ReadOnly = true;
            this.dgcLOPSid.ToolTipText = "ieraksta numurs";
            this.dgcLOPSid.Width = 72;
            // 
            // dgcLOPStl
            // 
            this.dgcLOPStl.DataPropertyName = "dtl";
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.dgcLOPStl.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcLOPStl.HeaderText = "labots dat.";
            this.dgcLOPStl.MinimumWidth = 9;
            this.dgcLOPStl.Name = "dgcLOPStl";
            this.dgcLOPStl.ReadOnly = true;
            this.dgcLOPStl.ToolTipText = "lobojuma datums";
            this.dgcLOPStl.Width = 144;
            // 
            // dgcLOPStld
            // 
            this.dgcLOPStld.DataPropertyName = "dtld";
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.NullValue = null;
            this.dgcLOPStld.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcLOPStld.HeaderText = "dzēsts dat.";
            this.dgcLOPStld.MinimumWidth = 9;
            this.dgcLOPStld.Name = "dgcLOPStld";
            this.dgcLOPStld.ReadOnly = true;
            this.dgcLOPStld.ToolTipText = "dzēšanas datuma";
            this.dgcLOPStld.Width = 144;
            // 
            // dgcLOPSODT
            // 
            this.dgcLOPSODT.DataPropertyName = "ODT";
            this.dgcLOPSODT.HeaderText = "datums no";
            this.dgcLOPSODT.MinimumWidth = 8;
            this.dgcLOPSODT.Name = "dgcLOPSODT";
            this.dgcLOPSODT.ReadOnly = true;
            this.dgcLOPSODT.ToolTipText = "rindas izveides vai iepriekšēj`labojuma datums";
            this.dgcLOPSODT.Width = 144;
            // 
            // dgcLOPSusl
            // 
            this.dgcLOPSusl.DataPropertyName = "usl";
            this.dgcLOPSusl.HeaderText = "lietotājs";
            this.dgcLOPSusl.MinimumWidth = 9;
            this.dgcLOPSusl.Name = "dgcLOPSusl";
            this.dgcLOPSusl.ReadOnly = true;
            this.dgcLOPSusl.ToolTipText = "lietotājs, kas veicis izmaiņas";
            this.dgcLOPSusl.Width = 90;
            // 
            // dgcLOPStpl
            // 
            this.dgcLOPStpl.DataPropertyName = "tpl";
            this.dgcLOPStpl.HeaderText = "tpl";
            this.dgcLOPStpl.MinimumWidth = 9;
            this.dgcLOPStpl.Name = "dgcLOPStpl";
            this.dgcLOPStpl.ReadOnly = true;
            this.dgcLOPStpl.Visible = false;
            this.dgcLOPStpl.Width = 90;
            // 
            // dgcLOPSocId
            // 
            this.dgcLOPSocId.DataPropertyName = "DocId";
            this.dgcLOPSocId.HeaderText = "dok.id.";
            this.dgcLOPSocId.MinimumWidth = 9;
            this.dgcLOPSocId.Name = "dgcLOPSocId";
            this.dgcLOPSocId.ReadOnly = true;
            this.dgcLOPSocId.ToolTipText = "dokumeta id";
            this.dgcLOPSocId.Width = 72;
            // 
            // dgcLOPSAC11
            // 
            this.dgcLOPSAC11.DataPropertyName = "AC11";
            this.dgcLOPSAC11.HeaderText = "debets";
            this.dgcLOPSAC11.MinimumWidth = 9;
            this.dgcLOPSAC11.Name = "dgcLOPSAC11";
            this.dgcLOPSAC11.ReadOnly = true;
            this.dgcLOPSAC11.Width = 72;
            // 
            // dgcLOPSAC12
            // 
            this.dgcLOPSAC12.DataPropertyName = "AC12";
            this.dgcLOPSAC12.HeaderText = "D2";
            this.dgcLOPSAC12.MinimumWidth = 9;
            this.dgcLOPSAC12.Name = "dgcLOPSAC12";
            this.dgcLOPSAC12.ReadOnly = true;
            this.dgcLOPSAC12.ToolTipText = "debets: naudas plūsma";
            this.dgcLOPSAC12.Width = 72;
            // 
            // dgcLOPSAC13
            // 
            this.dgcLOPSAC13.DataPropertyName = "AC13";
            this.dgcLOPSAC13.HeaderText = "D3";
            this.dgcLOPSAC13.MinimumWidth = 9;
            this.dgcLOPSAC13.Name = "dgcLOPSAC13";
            this.dgcLOPSAC13.ReadOnly = true;
            this.dgcLOPSAC13.ToolTipText = "debets: IIN darijuma kods";
            this.dgcLOPSAC13.Width = 45;
            // 
            // dgcLOPSAC14
            // 
            this.dgcLOPSAC14.DataPropertyName = "AC14";
            this.dgcLOPSAC14.HeaderText = "D4";
            this.dgcLOPSAC14.MinimumWidth = 9;
            this.dgcLOPSAC14.Name = "dgcLOPSAC14";
            this.dgcLOPSAC14.ReadOnly = true;
            this.dgcLOPSAC14.ToolTipText = "debets: kontējuma pzīme";
            this.dgcLOPSAC14.Width = 72;
            // 
            // dgcLOPSAC15
            // 
            this.dgcLOPSAC15.DataPropertyName = "AC15";
            this.dgcLOPSAC15.HeaderText = "D5";
            this.dgcLOPSAC15.MinimumWidth = 9;
            this.dgcLOPSAC15.Name = "dgcLOPSAC15";
            this.dgcLOPSAC15.ReadOnly = true;
            this.dgcLOPSAC15.ToolTipText = "debets: PVN";
            this.dgcLOPSAC15.Width = 54;
            // 
            // dgcLOPSAC21
            // 
            this.dgcLOPSAC21.DataPropertyName = "AC21";
            this.dgcLOPSAC21.HeaderText = "kredīts";
            this.dgcLOPSAC21.MinimumWidth = 9;
            this.dgcLOPSAC21.Name = "dgcLOPSAC21";
            this.dgcLOPSAC21.ReadOnly = true;
            this.dgcLOPSAC21.Width = 72;
            // 
            // dgcLOPSAC22
            // 
            this.dgcLOPSAC22.DataPropertyName = "AC22";
            this.dgcLOPSAC22.HeaderText = "K2";
            this.dgcLOPSAC22.MinimumWidth = 9;
            this.dgcLOPSAC22.Name = "dgcLOPSAC22";
            this.dgcLOPSAC22.ReadOnly = true;
            this.dgcLOPSAC22.ToolTipText = "kredīts: naudas plūsma";
            this.dgcLOPSAC22.Width = 72;
            // 
            // dgcLOPSAC23
            // 
            this.dgcLOPSAC23.DataPropertyName = "AC23";
            this.dgcLOPSAC23.HeaderText = "K3";
            this.dgcLOPSAC23.MinimumWidth = 9;
            this.dgcLOPSAC23.Name = "dgcLOPSAC23";
            this.dgcLOPSAC23.ReadOnly = true;
            this.dgcLOPSAC23.ToolTipText = "kredīts: IIN darijuma kods";
            this.dgcLOPSAC23.Width = 45;
            // 
            // dgcLOPSAC24
            // 
            this.dgcLOPSAC24.DataPropertyName = "AC24";
            this.dgcLOPSAC24.HeaderText = "K4";
            this.dgcLOPSAC24.MinimumWidth = 9;
            this.dgcLOPSAC24.Name = "dgcLOPSAC24";
            this.dgcLOPSAC24.ReadOnly = true;
            this.dgcLOPSAC24.ToolTipText = "kredīts: kontējuma pazīme";
            this.dgcLOPSAC24.Width = 72;
            // 
            // dgcLOPSAC25
            // 
            this.dgcLOPSAC25.DataPropertyName = "AC25";
            this.dgcLOPSAC25.HeaderText = "K5";
            this.dgcLOPSAC25.MinimumWidth = 9;
            this.dgcLOPSAC25.Name = "dgcLOPSAC25";
            this.dgcLOPSAC25.ReadOnly = true;
            this.dgcLOPSAC25.ToolTipText = "kredīts: PVN";
            this.dgcLOPSAC25.Width = 54;
            // 
            // dgcLOPSSumm
            // 
            this.dgcLOPSSumm.DataPropertyName = "Summ";
            this.dgcLOPSSumm.HeaderText = "summa";
            this.dgcLOPSSumm.MinimumWidth = 9;
            this.dgcLOPSSumm.Name = "dgcLOPSSumm";
            this.dgcLOPSSumm.ReadOnly = true;
            this.dgcLOPSSumm.Width = 90;
            // 
            // dgcLOPSQV
            // 
            this.dgcLOPSQV.DataPropertyName = "QV";
            this.dgcLOPSQV.HeaderText = "daudzums";
            this.dgcLOPSQV.MinimumWidth = 9;
            this.dgcLOPSQV.Name = "dgcLOPSQV";
            this.dgcLOPSQV.ReadOnly = true;
            this.dgcLOPSQV.Width = 90;
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
            // Form_LOPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 428);
            this.CloseOnEscape = true;
            this.Controls.Add(this.dgvLOPS);
            this.Controls.Add(this.bnavLOPS);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_LOPS";
            this.Text = "Kontējuma datu izmaiņu reģistrs";
            this.Load += new System.EventHandler(this.FormLOPS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsLOPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavLOPS)).EndInit();
            this.bnavLOPS.ResumeLayout(false);
            this.bnavLOPS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLOPS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingSource bsLOPS;
        private MyBindingNavigator bnavLOPS;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private MyDataGridView dgvLOPS;
        private System.Windows.Forms.ToolStripButton tsbSearchPrev;
        private System.Windows.Forms.ToolStripTextBox tsbSearch;
        private System.Windows.Forms.ToolStripButton tsbSearchNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSidl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPStl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPStld;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSODT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSusl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPStpl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSocId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSAC11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSAC12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSAC13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSAC14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSAC15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSAC21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSAC22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSAC23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSAC24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSAC25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSSumm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLOPSQV;
        private System.Windows.Forms.ToolStripButton tsbDocLog;
    }
}