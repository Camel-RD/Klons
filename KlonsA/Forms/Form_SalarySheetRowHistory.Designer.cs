namespace KlonsA.Forms
{
    partial class Form_SalarySheetRowHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SalarySheetRowHistory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bNav = new KlonsLIB.Components.MyBindingNavigator();
            this.bsRows = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRestore = new System.Windows.Forms.ToolStripButton();
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcSarDtEdited = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarFactDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarsFactHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCsARsALARY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarAvPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarVacationCur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarSickPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarPlus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarTotalBeforeTaxes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarDnSNAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarSNAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarUntMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDarDependants = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarOtherIINEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarIIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarAdvance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarPayT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarCalcVer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).BeginInit();
            this.bNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.SuspendLayout();
            // 
            // bNav
            // 
            this.bNav.AddNewItem = null;
            this.bNav.BindingSource = this.bsRows;
            this.bNav.CountItem = this.bindingNavigatorCountItem;
            this.bNav.CountItemFormat = " no {0}";
            this.bNav.DeleteItem = null;
            this.bNav.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bNav.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.tsbRestore});
            this.bNav.Location = new System.Drawing.Point(0, 305);
            this.bNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bNav.Name = "bNav";
            this.bNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bNav.SaveItem = null;
            this.bNav.Size = new System.Drawing.Size(886, 33);
            this.bNav.TabIndex = 0;
            this.bNav.Text = "myBindingNavigator1";
            // 
            // bsRows
            // 
            this.bsRows.DataMember = "SALARY_SHEETS_R_HIST";
            this.bsRows.MyDataSource = "KlonsData";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(69, 29);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(30, 29);
            this.bindingNavigatorMoveFirstItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(30, 29);
            this.bindingNavigatorMovePreviousItem.Text = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 33);
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
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(30, 29);
            this.bindingNavigatorMoveNextItem.Text = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(30, 29);
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // tsbRestore
            // 
            this.tsbRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRestore.Image = ((System.Drawing.Image)(resources.GetObject("tsbRestore.Image")));
            this.tsbRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRestore.Name = "tsbRestore";
            this.tsbRestore.Size = new System.Drawing.Size(357, 29);
            this.tsbRestore.Text = "> Atjaunot uz norādīto ieraksta versiju <";
            this.tsbRestore.Click += new System.EventHandler(this.TsbRestore_Click);
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AutoGenerateColumns = false;
            this.dgvRows.AutoSave = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcSarDtEdited,
            this.dgcSarFactDays,
            this.dgcSarsFactHours,
            this.DGCsARsALARY,
            this.dgcSarAvPay,
            this.dgcSarVacationCur,
            this.dgcSarSickPay,
            this.dgcSarPlus,
            this.dgcSarTotalBeforeTaxes,
            this.dgcSarDnSNAmount,
            this.dgcSarSNAmount,
            this.dgcSarUntMin,
            this.dgcDarDependants,
            this.dgcSarOtherIINEx,
            this.dgcSarIIN,
            this.dgcSarPay,
            this.dgcSarAdvance,
            this.dgcSarPayT,
            this.dgcSarCalcVer});
            this.dgvRows.DataSource = this.bsRows;
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 0);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersWidth = 53;
            this.dgvRows.RowTemplate.Height = 24;
            this.dgvRows.ShowCellToolTips = false;
            this.dgvRows.Size = new System.Drawing.Size(886, 305);
            this.dgvRows.TabIndex = 2;
            this.dgvRows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvRows_CellFormatting);
            // 
            // dgcSarDtEdited
            // 
            this.dgcSarDtEdited.DataPropertyName = "DT_EDITED";
            dataGridViewCellStyle2.Format = "dd.MM.yyyy HH:mm";
            this.dgcSarDtEdited.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcSarDtEdited.Frozen = true;
            this.dgcSarDtEdited.HeaderText = "dat.laiks";
            this.dgcSarDtEdited.MinimumWidth = 7;
            this.dgcSarDtEdited.Name = "dgcSarDtEdited";
            this.dgcSarDtEdited.ReadOnly = true;
            this.dgcSarDtEdited.ToolTipText = "izmaiņu veikšanas datums un laiks";
            this.dgcSarDtEdited.Width = 130;
            // 
            // dgcSarFactDays
            // 
            this.dgcSarFactDays.DataPropertyName = "FACT_DAYS";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgcSarFactDays.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcSarFactDays.HeaderText = "dienas";
            this.dgcSarFactDays.MinimumWidth = 7;
            this.dgcSarFactDays.Name = "dgcSarFactDays";
            this.dgcSarFactDays.ReadOnly = true;
            this.dgcSarFactDays.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarFactDays.Width = 60;
            // 
            // dgcSarsFactHours
            // 
            this.dgcSarsFactHours.DataPropertyName = "FACT_HOURS";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgcSarsFactHours.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcSarsFactHours.HeaderText = "stundas";
            this.dgcSarsFactHours.MinimumWidth = 7;
            this.dgcSarsFactHours.Name = "dgcSarsFactHours";
            this.dgcSarsFactHours.ReadOnly = true;
            this.dgcSarsFactHours.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarsFactHours.Width = 60;
            // 
            // DGCsARsALARY
            // 
            this.DGCsARsALARY.DataPropertyName = "SALARY";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.DGCsARsALARY.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGCsARsALARY.HeaderText = "par darbu";
            this.DGCsARsALARY.MinimumWidth = 7;
            this.DGCsARsALARY.Name = "DGCsARsALARY";
            this.DGCsARsALARY.ReadOnly = true;
            this.DGCsARsALARY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DGCsARsALARY.Width = 80;
            // 
            // dgcSarAvPay
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcSarAvPay.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcSarAvPay.HeaderText = "par VI dienām";
            this.dgcSarAvPay.MinimumWidth = 7;
            this.dgcSarAvPay.Name = "dgcSarAvPay";
            this.dgcSarAvPay.ReadOnly = true;
            this.dgcSarAvPay.ToolTipText = "t.sk. par vidējās izpeļņas dienām";
            this.dgcSarAvPay.Width = 80;
            // 
            // dgcSarVacationCur
            // 
            this.dgcSarVacationCur.DataPropertyName = "VACATION_PAY_CURRENT";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcSarVacationCur.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcSarVacationCur.HeaderText = "atvļin.n.";
            this.dgcSarVacationCur.MinimumWidth = 7;
            this.dgcSarVacationCur.Name = "dgcSarVacationCur";
            this.dgcSarVacationCur.ReadOnly = true;
            this.dgcSarVacationCur.ToolTipText = "atvaļinājuma nauda";
            this.dgcSarVacationCur.Width = 80;
            // 
            // dgcSarSickPay
            // 
            this.dgcSarSickPay.DataPropertyName = "SICKDAYS_PAY";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcSarSickPay.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcSarSickPay.HeaderText = "slimīb.n.";
            this.dgcSarSickPay.MinimumWidth = 7;
            this.dgcSarSickPay.Name = "dgcSarSickPay";
            this.dgcSarSickPay.ReadOnly = true;
            this.dgcSarSickPay.ToolTipText = "slimības nauda";
            this.dgcSarSickPay.Width = 80;
            // 
            // dgcSarPlus
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcSarPlus.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcSarPlus.HeaderText = "piemaksas";
            this.dgcSarPlus.MinimumWidth = 7;
            this.dgcSarPlus.Name = "dgcSarPlus";
            this.dgcSarPlus.ReadOnly = true;
            this.dgcSarPlus.ToolTipText = "piemaksu kopsumma";
            this.dgcSarPlus.Width = 80;
            // 
            // dgcSarTotalBeforeTaxes
            // 
            this.dgcSarTotalBeforeTaxes.DataPropertyName = "TOTAL_BEFORE_TAXES";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.dgcSarTotalBeforeTaxes.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgcSarTotalBeforeTaxes.HeaderText = "ieņ. kopā";
            this.dgcSarTotalBeforeTaxes.MinimumWidth = 7;
            this.dgcSarTotalBeforeTaxes.Name = "dgcSarTotalBeforeTaxes";
            this.dgcSarTotalBeforeTaxes.ReadOnly = true;
            this.dgcSarTotalBeforeTaxes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarTotalBeforeTaxes.Width = 80;
            // 
            // dgcSarDnSNAmount
            // 
            this.dgcSarDnSNAmount.DataPropertyName = "DNSN_AMOUNT";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.dgcSarDnSNAmount.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgcSarDnSNAmount.HeaderText = "SI d.ņ.";
            this.dgcSarDnSNAmount.MinimumWidth = 7;
            this.dgcSarDnSNAmount.Name = "dgcSarDnSNAmount";
            this.dgcSarDnSNAmount.ReadOnly = true;
            this.dgcSarDnSNAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarDnSNAmount.ToolTipText = "darba ņēmēja VSAOI";
            this.dgcSarDnSNAmount.Width = 80;
            // 
            // dgcSarSNAmount
            // 
            this.dgcSarSNAmount.DataPropertyName = "SN_AMOUNT";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            this.dgcSarSNAmount.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgcSarSNAmount.HeaderText = "SI";
            this.dgcSarSNAmount.MinimumWidth = 7;
            this.dgcSarSNAmount.Name = "dgcSarSNAmount";
            this.dgcSarSNAmount.ReadOnly = true;
            this.dgcSarSNAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarSNAmount.ToolTipText = "kopā VSAOI";
            this.dgcSarSNAmount.Width = 80;
            // 
            // dgcSarUntMin
            // 
            this.dgcSarUntMin.DataPropertyName = "IIN_EXEMPT_UNTAXED_MINIMUM";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcSarUntMin.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgcSarUntMin.HeaderText = "neapliek. min.";
            this.dgcSarUntMin.MinimumWidth = 7;
            this.dgcSarUntMin.Name = "dgcSarUntMin";
            this.dgcSarUntMin.ReadOnly = true;
            this.dgcSarUntMin.ToolTipText = "neapliekamais minimums";
            this.dgcSarUntMin.Width = 80;
            // 
            // dgcDarDependants
            // 
            this.dgcDarDependants.DataPropertyName = "IIN_EXEMPT_DEPENDANTS";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            dataGridViewCellStyle14.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcDarDependants.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgcDarDependants.HeaderText = "par apgād.";
            this.dgcDarDependants.MinimumWidth = 7;
            this.dgcDarDependants.Name = "dgcDarDependants";
            this.dgcDarDependants.ReadOnly = true;
            this.dgcDarDependants.ToolTipText = "atvieglojumi par apgādājamajiem";
            this.dgcDarDependants.Width = 80;
            // 
            // dgcSarOtherIINEx
            // 
            this.dgcSarOtherIINEx.DataPropertyName = "IIN_EXEMPT_2";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcSarOtherIINEx.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgcSarOtherIINEx.HeaderText = "citi atv.";
            this.dgcSarOtherIINEx.MinimumWidth = 7;
            this.dgcSarOtherIINEx.Name = "dgcSarOtherIINEx";
            this.dgcSarOtherIINEx.ReadOnly = true;
            this.dgcSarOtherIINEx.ToolTipText = "citi IIN atvieglojumi";
            this.dgcSarOtherIINEx.Width = 80;
            // 
            // dgcSarIIN
            // 
            this.dgcSarIIN.DataPropertyName = "IIN_AMOUNT";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            this.dgcSarIIN.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgcSarIIN.HeaderText = "IIN";
            this.dgcSarIIN.MinimumWidth = 7;
            this.dgcSarIIN.Name = "dgcSarIIN";
            this.dgcSarIIN.ReadOnly = true;
            this.dgcSarIIN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarIIN.Width = 80;
            // 
            // dgcSarPay
            // 
            this.dgcSarPay.DataPropertyName = "PAY";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N2";
            this.dgcSarPay.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgcSarPay.HeaderText = "izmaksai";
            this.dgcSarPay.MinimumWidth = 7;
            this.dgcSarPay.Name = "dgcSarPay";
            this.dgcSarPay.ReadOnly = true;
            this.dgcSarPay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarPay.Width = 80;
            // 
            // dgcSarAdvance
            // 
            this.dgcSarAdvance.DataPropertyName = "ADVANCE";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcSarAdvance.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgcSarAdvance.HeaderText = "avansā";
            this.dgcSarAdvance.MinimumWidth = 7;
            this.dgcSarAdvance.Name = "dgcSarAdvance";
            this.dgcSarAdvance.ReadOnly = true;
            this.dgcSarAdvance.ToolTipText = "Avansā izmaksājamā summa";
            this.dgcSarAdvance.Width = 80;
            // 
            // dgcSarPayT
            // 
            this.dgcSarPayT.DataPropertyName = "PAYT";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N2";
            this.dgcSarPayT.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgcSarPayT.HeaderText = "kopā izm.";
            this.dgcSarPayT.MinimumWidth = 7;
            this.dgcSarPayT.Name = "dgcSarPayT";
            this.dgcSarPayT.ReadOnly = true;
            this.dgcSarPayT.Width = 80;
            // 
            // dgcSarCalcVer
            // 
            this.dgcSarCalcVer.DataPropertyName = "CALC_VER";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcSarCalcVer.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgcSarCalcVer.HeaderText = "apr.ver.";
            this.dgcSarCalcVer.MinimumWidth = 7;
            this.dgcSarCalcVer.Name = "dgcSarCalcVer";
            this.dgcSarCalcVer.ReadOnly = true;
            this.dgcSarCalcVer.ToolTipText = "aprēķina versija";
            this.dgcSarCalcVer.Width = 60;
            // 
            // Form_SalarySheetRowHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 338);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.bNav);
            this.Name = "Form_SalarySheetRowHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Algas aprēķina izmaiņu vēsture";
            this.Load += new System.EventHandler(this.Form_SalarySheetRowHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bNav)).EndInit();
            this.bNav.ResumeLayout(false);
            this.bNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.ToolStripButton tsbRestore;
        private KlonsLIB.Data.MyBindingSource bsRows;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarDtEdited;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarFactDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarsFactHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCsARsALARY;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarAvPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarVacationCur;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarSickPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarPlus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarTotalBeforeTaxes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarDnSNAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarSNAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarUntMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDarDependants;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarOtherIINEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarIIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarAdvance;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarPayT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarCalcVer;
    }
}