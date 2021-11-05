namespace KlonsA.Forms
{
    partial class Form_Events
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Events));
            KlonsLIB.Components.MyMcComboBox.MyItem myItem5 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem6 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            this.bsEvents = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsNV = new KlonsLIB.Data.MyBindingSource(this.components);
            this.dgvEvents = new KlonsLIB.Components.MyDataGridView();
            this.dgcDate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIDP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIDN2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDate3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOccCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbFilterEvent = new KlonsLIB.Components.MyMcFlatComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tbDT1 = new KlonsLIB.Components.MyTextBox();
            this.tbDT2 = new KlonsLIB.Components.MyTextBox();
            this.bsNV2 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cbFilterEvent2 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbFilterMode = new KlonsLIB.Components.MyMcFlatComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsNV2)).BeginInit();
            this.SuspendLayout();
            // 
            // bsEvents
            // 
            this.bsEvents.DataMember = "EVENTS";
            this.bsEvents.MyDataSource = "KlonsData";
            this.bsEvents.Sort = "DATE1";
            // 
            // bsNV
            // 
            this.bsNV.DataMember = "EVENT_TYPES";
            this.bsNV.MyDataSource = "KlonsData";
            this.bsNV.Sort = "ID";
            // 
            // dgvEvents
            // 
            this.dgvEvents.AllowUserToAddRows = false;
            this.dgvEvents.AllowUserToDeleteRows = false;
            this.dgvEvents.AutoGenerateColumns = false;
            this.dgvEvents.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDate1,
            this.dgcDate2,
            this.dgcIDP,
            this.dgcIDA,
            this.dgcIDN,
            this.dgcIDN2,
            this.dgcDescr,
            this.dgcDate3,
            this.dgcDocNr,
            this.dgcSCode,
            this.dgcDays,
            this.dgcOccCode,
            this.dgcID});
            this.dgvEvents.DataSource = this.bsEvents;
            this.dgvEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvents.Location = new System.Drawing.Point(0, 41);
            this.dgvEvents.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.RowHeadersWidth = 62;
            this.dgvEvents.RowTemplate.Height = 29;
            this.dgvEvents.Size = new System.Drawing.Size(1188, 481);
            this.dgvEvents.TabIndex = 0;
            this.dgvEvents.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEvents_CellFormatting);
            // 
            // dgcDate1
            // 
            this.dgcDate1.DataPropertyName = "DATE1";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "dd.MM.yyyy";
            this.dgcDate1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcDate1.HeaderText = "datums no";
            this.dgcDate1.MinimumWidth = 9;
            this.dgcDate1.Name = "dgcDate1";
            this.dgcDate1.ReadOnly = true;
            this.dgcDate1.Width = 101;
            // 
            // dgcDate2
            // 
            this.dgcDate2.DataPropertyName = "DATE2";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "dd.MM.yyyy";
            this.dgcDate2.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgcDate2.HeaderText = "datums līdz";
            this.dgcDate2.MinimumWidth = 9;
            this.dgcDate2.Name = "dgcDate2";
            this.dgcDate2.ReadOnly = true;
            this.dgcDate2.Width = 101;
            // 
            // dgcIDP
            // 
            this.dgcIDP.DataPropertyName = "YNAME";
            this.dgcIDP.HeaderText = "darbinieks";
            this.dgcIDP.MinimumWidth = 9;
            this.dgcIDP.Name = "dgcIDP";
            this.dgcIDP.ReadOnly = true;
            this.dgcIDP.Width = 180;
            // 
            // dgcIDA
            // 
            this.dgcIDA.DataPropertyName = "IDA";
            this.dgcIDA.HeaderText = "amats";
            this.dgcIDA.MinimumWidth = 9;
            this.dgcIDA.Name = "dgcIDA";
            this.dgcIDA.ReadOnly = true;
            this.dgcIDA.Width = 135;
            // 
            // dgcIDN
            // 
            this.dgcIDN.DataPropertyName = "IDN";
            this.dgcIDN.HeaderText = "notikums";
            this.dgcIDN.MinimumWidth = 9;
            this.dgcIDN.Name = "dgcIDN";
            this.dgcIDN.ReadOnly = true;
            this.dgcIDN.Width = 202;
            // 
            // dgcIDN2
            // 
            this.dgcIDN2.DataPropertyName = "IDN2";
            this.dgcIDN2.HeaderText = "cits notikums";
            this.dgcIDN2.MinimumWidth = 9;
            this.dgcIDN2.Name = "dgcIDN2";
            this.dgcIDN2.ReadOnly = true;
            this.dgcIDN2.Width = 168;
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "DESCR";
            this.dgcDescr.HeaderText = "apraksts";
            this.dgcDescr.MinimumWidth = 9;
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.ReadOnly = true;
            this.dgcDescr.Width = 168;
            // 
            // dgcDate3
            // 
            this.dgcDate3.DataPropertyName = "DATE3";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "dd.MM.yyyy";
            this.dgcDate3.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgcDate3.HeaderText = "izmaksas datums";
            this.dgcDate3.MinimumWidth = 9;
            this.dgcDate3.Name = "dgcDate3";
            this.dgcDate3.ReadOnly = true;
            this.dgcDate3.Width = 101;
            // 
            // dgcDocNr
            // 
            this.dgcDocNr.DataPropertyName = "DOCNR";
            this.dgcDocNr.HeaderText = "dok.nr.";
            this.dgcDocNr.MinimumWidth = 9;
            this.dgcDocNr.Name = "dgcDocNr";
            this.dgcDocNr.ReadOnly = true;
            this.dgcDocNr.Width = 67;
            // 
            // dgcSCode
            // 
            this.dgcSCode.DataPropertyName = "SCODE";
            this.dgcSCode.HeaderText = "ziņu kods";
            this.dgcSCode.MinimumWidth = 9;
            this.dgcSCode.Name = "dgcSCode";
            this.dgcSCode.ReadOnly = true;
            this.dgcSCode.Width = 56;
            // 
            // dgcDays
            // 
            this.dgcDays.DataPropertyName = "DAYS";
            this.dgcDays.HeaderText = "dienas";
            this.dgcDays.MinimumWidth = 9;
            this.dgcDays.Name = "dgcDays";
            this.dgcDays.ReadOnly = true;
            this.dgcDays.ToolTipText = "atvaļinājums dienas";
            this.dgcDays.Width = 67;
            // 
            // dgcOccCode
            // 
            this.dgcOccCode.DataPropertyName = "OCCUPATION_CODE";
            this.dgcOccCode.HeaderText = "prof. kods";
            this.dgcOccCode.MinimumWidth = 9;
            this.dgcOccCode.Name = "dgcOccCode";
            this.dgcOccCode.ReadOnly = true;
            this.dgcOccCode.ToolTipText = "profesijas kods";
            this.dgcOccCode.Width = 90;
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.MinimumWidth = 9;
            this.dgcID.Name = "dgcID";
            this.dgcID.ReadOnly = true;
            this.dgcID.Visible = false;
            this.dgcID.Width = 168;
            // 
            // cbFilterEvent
            // 
            this.cbFilterEvent.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbFilterEvent.ColumnNames = new string[] {
        "ID",
        "DESCR"};
            this.cbFilterEvent.ColumnWidths = "0;350";
            this.cbFilterEvent.DataSource = this.bsNV;
            this.cbFilterEvent.DisplayMember = "DESCR";
            this.cbFilterEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterEvent.DropDownHeight = 252;
            this.cbFilterEvent.DropDownWidth = 378;
            this.cbFilterEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilterEvent.FormattingEnabled = true;
            this.cbFilterEvent.GridLineColor = System.Drawing.Color.LightGray;
            this.cbFilterEvent.GridLineHorizontal = false;
            this.cbFilterEvent.GridLineVertical = false;
            this.cbFilterEvent.IntegralHeight = false;
            this.cbFilterEvent.Location = new System.Drawing.Point(363, 8);
            this.cbFilterEvent.Margin = new System.Windows.Forms.Padding(1, 4, 3, 4);
            this.cbFilterEvent.MaxDropDownItems = 12;
            this.cbFilterEvent.Name = "cbFilterEvent";
            this.cbFilterEvent.Size = new System.Drawing.Size(236, 27);
            this.cbFilterEvent.TabIndex = 4;
            this.cbFilterEvent.ValueMember = "ID";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.toolStripLabel4,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.toolStrip1.Size = new System.Drawing.Size(1188, 41);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(22, 34);
            this.toolStripLabel2.Text = "-";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(19, 34);
            this.toolStripLabel3.Text = " ";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(25, 34);
            this.toolStripLabel4.Text = "  ";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(75, 34);
            this.toolStripButton1.Text = "Atlasīt";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tbDT1
            // 
            this.tbDT1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDT1.IsDate = true;
            this.tbDT1.Location = new System.Drawing.Point(165, 8);
            this.tbDT1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDT1.Name = "tbDT1";
            this.tbDT1.Size = new System.Drawing.Size(90, 26);
            this.tbDT1.TabIndex = 7;
            // 
            // tbDT2
            // 
            this.tbDT2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDT2.IsDate = true;
            this.tbDT2.Location = new System.Drawing.Point(262, 8);
            this.tbDT2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDT2.Name = "tbDT2";
            this.tbDT2.Size = new System.Drawing.Size(90, 26);
            this.tbDT2.TabIndex = 7;
            // 
            // bsNV2
            // 
            this.bsNV2.DataMember = "EVENT_TYPES2";
            this.bsNV2.MyDataSource = "KlonsData";
            this.bsNV2.Sort = "TAG";
            // 
            // cbFilterEvent2
            // 
            this.cbFilterEvent2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbFilterEvent2.ColumnNames = new string[] {
        "TAG",
        "DESCR"};
            this.cbFilterEvent2.ColumnWidths = "100;300";
            this.cbFilterEvent2.DataSource = this.bsNV2;
            this.cbFilterEvent2.DisplayMember = "DESCR";
            this.cbFilterEvent2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterEvent2.DropDownHeight = 168;
            this.cbFilterEvent2.DropDownWidth = 428;
            this.cbFilterEvent2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilterEvent2.FormattingEnabled = true;
            this.cbFilterEvent2.GridLineColor = System.Drawing.Color.LightGray;
            this.cbFilterEvent2.GridLineHorizontal = false;
            this.cbFilterEvent2.GridLineVertical = false;
            this.cbFilterEvent2.IntegralHeight = false;
            this.cbFilterEvent2.Location = new System.Drawing.Point(610, 8);
            this.cbFilterEvent2.Margin = new System.Windows.Forms.Padding(7, 4, 3, 4);
            this.cbFilterEvent2.Name = "cbFilterEvent2";
            this.cbFilterEvent2.Size = new System.Drawing.Size(254, 27);
            this.cbFilterEvent2.TabIndex = 15;
            this.cbFilterEvent2.ValueMember = "ID";
            // 
            // cbFilterMode
            // 
            this.cbFilterMode.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbFilterMode.ColumnNames = new string[] {
        "col1",
        "col2"};
            this.cbFilterMode.ColumnWidths = "0;152";
            this.cbFilterMode.DisplayMember = "col2";
            this.cbFilterMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterMode.DropDownHeight = 168;
            this.cbFilterMode.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbFilterMode.DropDownWidth = 180;
            this.cbFilterMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilterMode.FormattingEnabled = true;
            this.cbFilterMode.GridLineColor = System.Drawing.Color.LightGray;
            this.cbFilterMode.GridLineHorizontal = false;
            this.cbFilterMode.GridLineVertical = false;
            this.cbFilterMode.IntegralHeight = false;
            myItem5.Col1 = "0";
            myItem5.Col2 = "pēc sākuma datuma";
            myItem6.Col1 = "1";
            myItem6.Col2 = "pēc statusa";
            this.cbFilterMode.Items.AddRange(new object[] {
            myItem5,
            myItem6});
            this.cbFilterMode.ItemStrings = new string[] {
        "0;pēc sākuma datuma",
        "1;pēc statusa"};
            this.cbFilterMode.Location = new System.Drawing.Point(870, 8);
            this.cbFilterMode.Margin = new System.Windows.Forms.Padding(7, 4, 3, 4);
            this.cbFilterMode.Name = "cbFilterMode";
            this.cbFilterMode.Size = new System.Drawing.Size(180, 27);
            this.cbFilterMode.TabIndex = 16;
            this.cbFilterMode.ValueMember = "col1";
            // 
            // Form_Events
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 522);
            this.Controls.Add(this.cbFilterMode);
            this.Controls.Add(this.cbFilterEvent2);
            this.Controls.Add(this.tbDT2);
            this.Controls.Add(this.tbDT1);
            this.Controls.Add(this.cbFilterEvent);
            this.Controls.Add(this.dgvEvents);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_Events";
            this.Text = "Notikumu izklāsts";
            this.Load += new System.EventHandler(this.Form_Events_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsNV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsEvents;
        private KlonsLIB.Data.MyBindingSource bsNV;
        private KlonsLIB.Components.MyDataGridView dgvEvents;
        private KlonsLIB.Components.MyMcFlatComboBox cbFilterEvent;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private KlonsLIB.Components.MyTextBox tbDT1;
        private KlonsLIB.Components.MyTextBox tbDT2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private KlonsLIB.Data.MyBindingSource bsNV2;
        private KlonsLIB.Components.MyMcFlatComboBox cbFilterEvent2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIDP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIDN2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDate3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOccCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcID;
        private KlonsLIB.Components.MyMcFlatComboBox cbFilterMode;
    }
}