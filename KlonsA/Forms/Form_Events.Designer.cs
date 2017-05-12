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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Events));
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
            this.bsEvents.Name2 = null;
            this.bsEvents.Sort = "DATE1";
            // 
            // bsNV
            // 
            this.bsNV.DataMember = "EVENT_TYPES";
            this.bsNV.MyDataSource = "KlonsData";
            this.bsNV.Name2 = null;
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
            this.dgvEvents.Location = new System.Drawing.Point(0, 34);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.RowTemplate.Height = 24;
            this.dgvEvents.Size = new System.Drawing.Size(847, 384);
            this.dgvEvents.TabIndex = 0;
            this.dgvEvents.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEvents_CellFormatting);
            // 
            // dgcDate1
            // 
            this.dgcDate1.DataPropertyName = "DATE1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "dd.MM.yyyy";
            this.dgcDate1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcDate1.HeaderText = "datums no";
            this.dgcDate1.Name = "dgcDate1";
            this.dgcDate1.ReadOnly = true;
            this.dgcDate1.Width = 90;
            // 
            // dgcDate2
            // 
            this.dgcDate2.DataPropertyName = "DATE2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "dd.MM.yyyy";
            this.dgcDate2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcDate2.HeaderText = "datums līdz";
            this.dgcDate2.Name = "dgcDate2";
            this.dgcDate2.ReadOnly = true;
            this.dgcDate2.Width = 90;
            // 
            // dgcIDP
            // 
            this.dgcIDP.DataPropertyName = "YNAME";
            this.dgcIDP.HeaderText = "darbinieks";
            this.dgcIDP.Name = "dgcIDP";
            this.dgcIDP.ReadOnly = true;
            this.dgcIDP.Width = 120;
            // 
            // dgcIDA
            // 
            this.dgcIDA.DataPropertyName = "IDA";
            this.dgcIDA.HeaderText = "amats";
            this.dgcIDA.Name = "dgcIDA";
            this.dgcIDA.ReadOnly = true;
            this.dgcIDA.Width = 120;
            // 
            // dgcIDN
            // 
            this.dgcIDN.DataPropertyName = "IDN";
            this.dgcIDN.HeaderText = "notikums";
            this.dgcIDN.Name = "dgcIDN";
            this.dgcIDN.ReadOnly = true;
            this.dgcIDN.Width = 180;
            // 
            // dgcIDN2
            // 
            this.dgcIDN2.DataPropertyName = "IDN2";
            this.dgcIDN2.HeaderText = "cits notikums";
            this.dgcIDN2.Name = "dgcIDN2";
            this.dgcIDN2.ReadOnly = true;
            this.dgcIDN2.Width = 150;
            // 
            // dgcDescr
            // 
            this.dgcDescr.DataPropertyName = "DESCR";
            this.dgcDescr.HeaderText = "apraksts";
            this.dgcDescr.Name = "dgcDescr";
            this.dgcDescr.ReadOnly = true;
            this.dgcDescr.Width = 150;
            // 
            // dgcDate3
            // 
            this.dgcDate3.DataPropertyName = "DATE3";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "dd.MM.yyyy";
            this.dgcDate3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcDate3.HeaderText = "izmaksas datums";
            this.dgcDate3.Name = "dgcDate3";
            this.dgcDate3.ReadOnly = true;
            this.dgcDate3.Width = 90;
            // 
            // dgcDocNr
            // 
            this.dgcDocNr.DataPropertyName = "DOCNR";
            this.dgcDocNr.HeaderText = "dok.nr.";
            this.dgcDocNr.Name = "dgcDocNr";
            this.dgcDocNr.ReadOnly = true;
            this.dgcDocNr.Width = 60;
            // 
            // dgcSCode
            // 
            this.dgcSCode.DataPropertyName = "SCODE";
            this.dgcSCode.HeaderText = "ziņu kods";
            this.dgcSCode.Name = "dgcSCode";
            this.dgcSCode.ReadOnly = true;
            this.dgcSCode.Width = 50;
            // 
            // dgcDays
            // 
            this.dgcDays.DataPropertyName = "DAYS";
            this.dgcDays.HeaderText = "dienas";
            this.dgcDays.Name = "dgcDays";
            this.dgcDays.ReadOnly = true;
            this.dgcDays.ToolTipText = "atvaļinājums dienas";
            this.dgcDays.Width = 60;
            // 
            // dgcOccCode
            // 
            this.dgcOccCode.DataPropertyName = "OCCUPATION_CODE";
            this.dgcOccCode.HeaderText = "prof. kods";
            this.dgcOccCode.Name = "dgcOccCode";
            this.dgcOccCode.ReadOnly = true;
            this.dgcOccCode.ToolTipText = "profesijas kods";
            this.dgcOccCode.Width = 80;
            // 
            // dgcID
            // 
            this.dgcID.DataPropertyName = "ID";
            this.dgcID.HeaderText = "ID";
            this.dgcID.Name = "dgcID";
            this.dgcID.ReadOnly = true;
            this.dgcID.Visible = false;
            // 
            // cbFilterEvent
            // 
            this.cbFilterEvent.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbFilterEvent.ColumnNames = new string[] {
        "ID",
        "DESCR"};
            this.cbFilterEvent.ColumnWidths = "0;240";
            this.cbFilterEvent.DataSource = this.bsNV;
            this.cbFilterEvent.DisplayMember = "DESCR";
            this.cbFilterEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterEvent.DropDownHeight = 204;
            this.cbFilterEvent.DropDownWidth = 264;
            this.cbFilterEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilterEvent.FormattingEnabled = true;
            this.cbFilterEvent.GridLineColor = System.Drawing.Color.LightGray;
            this.cbFilterEvent.GridLineHorizontal = false;
            this.cbFilterEvent.GridLineVertical = false;
            this.cbFilterEvent.IntegralHeight = false;
            this.cbFilterEvent.Location = new System.Drawing.Point(340, 6);
            this.cbFilterEvent.MaxDropDownItems = 12;
            this.cbFilterEvent.Name = "cbFilterEvent";
            this.cbFilterEvent.Size = new System.Drawing.Size(210, 23);
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
            this.toolStrip1.Size = new System.Drawing.Size(847, 34);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(19, 29);
            this.toolStripLabel2.Text = "-";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(17, 29);
            this.toolStripLabel3.Text = " ";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(22, 29);
            this.toolStripLabel4.Text = "  ";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(69, 29);
            this.toolStripButton1.Text = "Atlasīt";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tbDT1
            // 
            this.tbDT1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDT1.IsDate = true;
            this.tbDT1.Location = new System.Drawing.Point(147, 6);
            this.tbDT1.Name = "tbDT1";
            this.tbDT1.Size = new System.Drawing.Size(80, 22);
            this.tbDT1.TabIndex = 7;
            // 
            // tbDT2
            // 
            this.tbDT2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDT2.IsDate = true;
            this.tbDT2.Location = new System.Drawing.Point(244, 6);
            this.tbDT2.Name = "tbDT2";
            this.tbDT2.Size = new System.Drawing.Size(80, 22);
            this.tbDT2.TabIndex = 7;
            // 
            // bsNV2
            // 
            this.bsNV2.DataMember = "EVENT_TYPES2";
            this.bsNV2.MyDataSource = "KlonsData";
            this.bsNV2.Name2 = null;
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
            this.cbFilterEvent2.DropDownHeight = 136;
            this.cbFilterEvent2.DropDownWidth = 424;
            this.cbFilterEvent2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilterEvent2.FormattingEnabled = true;
            this.cbFilterEvent2.GridLineColor = System.Drawing.Color.LightGray;
            this.cbFilterEvent2.GridLineHorizontal = false;
            this.cbFilterEvent2.GridLineVertical = false;
            this.cbFilterEvent2.IntegralHeight = false;
            this.cbFilterEvent2.Location = new System.Drawing.Point(556, 6);
            this.cbFilterEvent2.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.cbFilterEvent2.Name = "cbFilterEvent2";
            this.cbFilterEvent2.Size = new System.Drawing.Size(226, 23);
            this.cbFilterEvent2.TabIndex = 15;
            this.cbFilterEvent2.ValueMember = "ID";
            // 
            // Form_Events
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 418);
            this.Controls.Add(this.cbFilterEvent2);
            this.Controls.Add(this.tbDT2);
            this.Controls.Add(this.tbDT1);
            this.Controls.Add(this.cbFilterEvent);
            this.Controls.Add(this.dgvEvents);
            this.Controls.Add(this.toolStrip1);
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
        private KlonsLIB.Data.MyBindingSource bsNV2;
        private KlonsLIB.Components.MyMcFlatComboBox cbFilterEvent2;
    }
}