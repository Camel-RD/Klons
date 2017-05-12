namespace KlonsA.Forms
{
    partial class Form_Stats
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cbYR = new System.Windows.Forms.ToolStripComboBox();
            this.cbMT = new System.Windows.Forms.ToolStripComboBox();
            this.bsStats = new System.Windows.Forms.BindingSource(this.components);
            this.bsList = new System.Windows.Forms.BindingSource(this.components);
            this.dgvStats = new KlonsLIB.Components.MyDataGridView();
            this.dgcTagStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvList = new KlonsLIB.Components.MyDataGridView();
            this.dgcListZName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcListPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.cbYR,
            this.cbMT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(797, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(156, 36);
            this.toolStripLabel2.Text = "Apskatīt mēnesi:";
            // 
            // cbYR
            // 
            this.cbYR.AutoSize = false;
            this.cbYR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYR.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cbYR.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.cbYR.MaxLength = 4;
            this.cbYR.Name = "cbYR";
            this.cbYR.Size = new System.Drawing.Size(60, 33);
            this.cbYR.ToolTipText = "gads";
            this.cbYR.SelectedIndexChanged += new System.EventHandler(this.cbYR_SelectedIndexChanged);
            // 
            // cbMT
            // 
            this.cbMT.AutoSize = false;
            this.cbMT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMT.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbMT.MaxDropDownItems = 12;
            this.cbMT.Name = "cbMT";
            this.cbMT.Size = new System.Drawing.Size(50, 33);
            this.cbMT.ToolTipText = "mēnesis";
            this.cbMT.SelectedIndexChanged += new System.EventHandler(this.cbMT_SelectedIndexChanged);
            // 
            // bsStats
            // 
            this.bsStats.CurrentChanged += new System.EventHandler(this.bsStats_CurrentChanged);
            // 
            // dgvStats
            // 
            this.dgvStats.AllowUserToAddRows = false;
            this.dgvStats.AllowUserToDeleteRows = false;
            this.dgvStats.AllowUserToResizeRows = false;
            this.dgvStats.AutoGenerateColumns = false;
            this.dgvStats.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvStats.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcTagStr,
            this.dgcValue});
            this.dgvStats.DataSource = this.bsStats;
            this.dgvStats.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvStats.Location = new System.Drawing.Point(0, 39);
            this.dgvStats.Name = "dgvStats";
            this.dgvStats.ReadOnly = true;
            this.dgvStats.RowHeadersVisible = false;
            this.dgvStats.RowTemplate.Height = 24;
            this.dgvStats.Size = new System.Drawing.Size(412, 399);
            this.dgvStats.TabIndex = 3;
            this.dgvStats.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvStats_CellPainting);
            // 
            // dgcTagStr
            // 
            this.dgcTagStr.DataPropertyName = "TagStr";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcTagStr.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcTagStr.HeaderText = "rādītājs";
            this.dgcTagStr.Name = "dgcTagStr";
            this.dgcTagStr.ReadOnly = true;
            this.dgcTagStr.Width = 300;
            // 
            // dgcValue
            // 
            this.dgcValue.DataPropertyName = "Value";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcValue.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcValue.HeaderText = "rādītājs";
            this.dgcValue.Name = "dgcValue";
            this.dgcValue.ReadOnly = true;
            this.dgcValue.ToolTipText = "skaits vai summa";
            this.dgcValue.Width = 80;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AutoGenerateColumns = false;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcListZName,
            this.dgcListPos});
            this.dgvList.DataSource = this.bsList;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(417, 39);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 24;
            this.dgvList.Size = new System.Drawing.Size(380, 399);
            this.dgvList.TabIndex = 4;
            // 
            // dgcListZName
            // 
            this.dgcListZName.DataPropertyName = "ZNAME";
            this.dgcListZName.HeaderText = "darbinieks";
            this.dgcListZName.Name = "dgcListZName";
            this.dgcListZName.ReadOnly = true;
            this.dgcListZName.Width = 150;
            // 
            // dgcListPos
            // 
            this.dgcListPos.DataPropertyName = "POSTITLE";
            this.dgcListPos.HeaderText = "amats";
            this.dgcListPos.Name = "dgcListPos";
            this.dgcListPos.ReadOnly = true;
            this.dgcListPos.Width = 200;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(412, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 399);
            this.panel1.TabIndex = 5;
            // 
            // Form_Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 438);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvStats);
            this.Controls.Add(this.toolStrip1);
            this.MinimumSize = new System.Drawing.Size(800, 0);
            this.Name = "Form_Stats";
            this.Text = "Dažāda informācija par uzskaites mēnesi";
            this.Load += new System.EventHandler(this.Form_Stats_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cbYR;
        private System.Windows.Forms.ToolStripComboBox cbMT;
        private System.Windows.Forms.BindingSource bsStats;
        private System.Windows.Forms.BindingSource bsList;
        private KlonsLIB.Components.MyDataGridView dgvStats;
        private KlonsLIB.Components.MyDataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcListZName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcListPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcTagStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcValue;
        private System.Windows.Forms.Panel panel1;
    }
}