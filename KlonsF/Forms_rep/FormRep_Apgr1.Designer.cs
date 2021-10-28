using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.FormsReportParams
{
    partial class FormRep_Apgr1
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
            KlonsLIB.Components.MyMcComboBox.MyItem myItem6 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem7 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem8 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem9 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem10 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRep_Apgr1));
            this.cbAC = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsAC = new KlonsLIB.Data.MyBindingSource(this.components);
            this.tbSD = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbED = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbACName = new System.Windows.Forms.Label();
            this.cmDoIt = new System.Windows.Forms.Button();
            this.cbCharCount = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.myLabel1 = new KlonsLIB.Components.MyLabel();
            this.cmTable = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbPrevMonth = new System.Windows.Forms.ToolStripButton();
            this.tsbNextMonth = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAC
            // 
            this.cbAC.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC.ColumnNames = new string[] {
        "ac",
        "name"};
            this.cbAC.ColumnWidths = "100;400";
            this.cbAC.DataSource = this.bsAC;
            this.cbAC.DisplayMember = "AC";
            this.cbAC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC.DropDownHeight = 315;
            this.cbAC.DropDownWidth = 594;
            this.cbAC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC.FormattingEnabled = true;
            this.cbAC.GridLineColor = System.Drawing.Color.LightGray;
            this.cbAC.GridLineHorizontal = false;
            this.cbAC.GridLineVertical = false;
            this.cbAC.IntegralHeight = false;
            this.cbAC.Location = new System.Drawing.Point(171, 106);
            this.cbAC.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC.MaxDropDownItems = 15;
            this.cbAC.Name = "cbAC";
            this.cbAC.Size = new System.Drawing.Size(116, 27);
            this.cbAC.TabIndex = 2;
            this.cbAC.ValueMember = "AC";
            this.cbAC.SelectedIndexChanged += new System.EventHandler(this.cbAC_SelectedIndexChanged);
            this.cbAC.TextChanged += new System.EventHandler(this.cbAC_TextChanged);
            this.cbAC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.cbAC.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbAC_MouseDoubleClick);
            // 
            // bsAC
            // 
            this.bsAC.DataMember = "AcP21";
            this.bsAC.MyDataSource = "KlonsData";
            this.bsAC.Name2 = "bsAC";
            // 
            // tbSD
            // 
            this.tbSD.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSD.IsDate = true;
            this.tbSD.Location = new System.Drawing.Point(171, 48);
            this.tbSD.Margin = new System.Windows.Forms.Padding(2);
            this.tbSD.Name = "tbSD";
            this.tbSD.Size = new System.Drawing.Size(90, 26);
            this.tbSD.TabIndex = 0;
            this.tbSD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Datums (no - līdz):";
            // 
            // tbED
            // 
            this.tbED.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbED.IsDate = true;
            this.tbED.Location = new System.Drawing.Point(268, 48);
            this.tbED.Margin = new System.Windows.Forms.Padding(2);
            this.tbED.Name = "tbED";
            this.tbED.Size = new System.Drawing.Size(90, 26);
            this.tbED.TabIndex = 1;
            this.tbED.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Konts:";
            // 
            // lbACName
            // 
            this.lbACName.Location = new System.Drawing.Point(177, 138);
            this.lbACName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbACName.Name = "lbACName";
            this.lbACName.Size = new System.Drawing.Size(374, 22);
            this.lbACName.TabIndex = 9;
            this.lbACName.Text = "Konts:";
            // 
            // cmDoIt
            // 
            this.cmDoIt.Location = new System.Drawing.Point(361, 169);
            this.cmDoIt.Margin = new System.Windows.Forms.Padding(2);
            this.cmDoIt.Name = "cmDoIt";
            this.cmDoIt.Size = new System.Drawing.Size(140, 71);
            this.cmDoIt.TabIndex = 4;
            this.cmDoIt.Text = "Atskaiti";
            this.cmDoIt.UseVisualStyleBackColor = true;
            this.cmDoIt.Click += new System.EventHandler(this.cmDoIt_Click);
            this.cmDoIt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // cbCharCount
            // 
            this.cbCharCount.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbCharCount.ColumnNames = new string[] {
        "col1"};
            this.cbCharCount.ColumnWidths = "80";
            this.cbCharCount.DisplayMember = "col1";
            this.cbCharCount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCharCount.DropDownHeight = 168;
            this.cbCharCount.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbCharCount.DropDownWidth = 121;
            this.cbCharCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCharCount.FormattingEnabled = true;
            this.cbCharCount.GridLineColor = System.Drawing.Color.LightGray;
            this.cbCharCount.GridLineHorizontal = false;
            this.cbCharCount.GridLineVertical = false;
            this.cbCharCount.IntegralHeight = false;
            myItem6.Col1 = "*";
            myItem7.Col1 = "1";
            myItem8.Col1 = "2";
            myItem9.Col1 = "3";
            myItem10.Col1 = "4";
            this.cbCharCount.Items.AddRange(new object[] {
            myItem6,
            myItem7,
            myItem8,
            myItem9,
            myItem10});
            this.cbCharCount.ItemStrings = new string[] {
        "*",
        "1",
        "2",
        "3",
        "4"};
            this.cbCharCount.Location = new System.Drawing.Point(171, 190);
            this.cbCharCount.Margin = new System.Windows.Forms.Padding(2);
            this.cbCharCount.Name = "cbCharCount";
            this.cbCharCount.Size = new System.Drawing.Size(75, 27);
            this.cbCharCount.TabIndex = 3;
            this.cbCharCount.ValueMember = "col1";
            this.cbCharCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 192);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Konta zīmju skaits:";
            // 
            // myLabel1
            // 
            this.myLabel1.AutoSize = true;
            this.myLabel1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.myLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myLabel1.Location = new System.Drawing.Point(29, 250);
            this.myLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.Padding = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.myLabel1.Size = new System.Drawing.Size(234, 60);
            this.myLabel1.TabIndex = 8;
            this.myLabel1.Text = "Lai dabūtu atskaiti par visiem \r\nkontiem, lodzinā jāieliek \'*\'";
            // 
            // cmTable
            // 
            this.cmTable.Location = new System.Drawing.Point(361, 250);
            this.cmTable.Margin = new System.Windows.Forms.Padding(2);
            this.cmTable.Name = "cmTable";
            this.cmTable.Size = new System.Drawing.Size(140, 71);
            this.cmTable.TabIndex = 4;
            this.cmTable.Text = "Tabula";
            this.cmTable.UseVisualStyleBackColor = true;
            this.cmTable.Click += new System.EventHandler(this.cmTable_Click);
            this.cmTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrevMonth,
            this.tsbNextMonth});
            this.toolStrip1.Location = new System.Drawing.Point(364, 46);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(118, 28);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbPrevMonth
            // 
            this.tsbPrevMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrevMonth.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrevMonth.Image")));
            this.tsbPrevMonth.Margin = new System.Windows.Forms.Padding(0);
            this.tsbPrevMonth.Name = "tsbPrevMonth";
            this.tsbPrevMonth.RightToLeftAutoMirrorImage = true;
            this.tsbPrevMonth.Size = new System.Drawing.Size(34, 28);
            this.tsbPrevMonth.Text = "iepriekšējais mēnesis";
            this.tsbPrevMonth.Click += new System.EventHandler(this.tsbPrevMonth_Click);
            // 
            // tsbNextMonth
            // 
            this.tsbNextMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNextMonth.Image = ((System.Drawing.Image)(resources.GetObject("tsbNextMonth.Image")));
            this.tsbNextMonth.Margin = new System.Windows.Forms.Padding(0);
            this.tsbNextMonth.Name = "tsbNextMonth";
            this.tsbNextMonth.RightToLeftAutoMirrorImage = true;
            this.tsbNextMonth.Size = new System.Drawing.Size(34, 28);
            this.tsbNextMonth.Text = "nākošais mēnesis";
            this.tsbNextMonth.ToolTipText = "Iet uz nākošo";
            this.tsbNextMonth.Click += new System.EventHandler(this.tsbNextMonth_Click);
            // 
            // FormRep_Apgr1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 345);
            this.CloseOnEscape = true;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.myLabel1);
            this.Controls.Add(this.cbCharCount);
            this.Controls.Add(this.cmTable);
            this.Controls.Add(this.cmDoIt);
            this.Controls.Add(this.lbACName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbED);
            this.Controls.Add(this.tbSD);
            this.Controls.Add(this.cbAC);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormRep_Apgr1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apgrozijumu pārskata parametri";
            this.Load += new System.EventHandler(this.FormRepApgr1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyMcFlatComboBox cbAC;
        private MyBindingSource bsAC;
        private MyTextBox tbSD;
        private System.Windows.Forms.Label label1;
        private MyTextBox tbED;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbACName;
        private System.Windows.Forms.Button cmDoIt;
        private MyMcFlatComboBox cbCharCount;
        private System.Windows.Forms.Label label3;
        private MyLabel myLabel1;
        private System.Windows.Forms.Button cmTable;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbPrevMonth;
        private System.Windows.Forms.ToolStripButton tsbNextMonth;
    }
}