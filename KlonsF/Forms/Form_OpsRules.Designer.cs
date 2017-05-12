using KlonsLIB.Components;

namespace KlonsF.Forms
{
    partial class Form_OpsRules
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
            this.cmClose = new System.Windows.Forms.Button();
            this.myLabel1 = new KlonsLIB.Components.MyLabel();
            this.cbPVN5 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbPVNkred = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbPVNdeb = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbPVNizd = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbPVNien = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbIINien = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbIINizd = new KlonsLIB.Components.MyMcFlatComboBox();
            this.chbPVNreqPvn = new System.Windows.Forms.CheckBox();
            this.chbPVNreqIen = new System.Windows.Forms.CheckBox();
            this.chbPVNizd = new System.Windows.Forms.CheckBox();
            this.chbPVNien = new System.Windows.Forms.CheckBox();
            this.chbIINien = new System.Windows.Forms.CheckBox();
            this.chbIINizd = new System.Windows.Forms.CheckBox();
            this.chbPVN5 = new System.Windows.Forms.CheckBox();
            this.chbPVNkred = new System.Windows.Forms.CheckBox();
            this.chbPVNdeb = new System.Windows.Forms.CheckBox();
            this.chbPVN = new System.Windows.Forms.CheckBox();
            this.chbIIN = new System.Windows.Forms.CheckBox();
            this.chbNP = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmClose
            // 
            this.cmClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmClose.Location = new System.Drawing.Point(517, 323);
            this.cmClose.Name = "cmClose";
            this.cmClose.Size = new System.Drawing.Size(133, 59);
            this.cmClose.TabIndex = 19;
            this.cmClose.Text = "Aizvērt";
            this.cmClose.UseVisualStyleBackColor = true;
            this.cmClose.Click += new System.EventHandler(this.cmClose_Click);
            // 
            // myLabel1
            // 
            this.myLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.myLabel1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.myLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myLabel1.Location = new System.Drawing.Point(14, 324);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.Padding = new System.Windows.Forms.Padding(2);
            this.myLabel1.Size = new System.Drawing.Size(491, 60);
            this.myLabel1.TabIndex = 20;
            this.myLabel1.Text = " Šie parametri tiek izmantoti, kontrolējot kontējumu ievadi. Ja kāds no punktiem " +
    "nav jākontrolē, ķeksīti noņemam.";
            // 
            // cbPVN5
            // 
            this.cbPVN5.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbPVN5.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbPVN5.ColumnWidths = "100;400";
            this.cbPVN5.DisplayMember = "idx";
            this.cbPVN5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPVN5.DropDownHeight = 176;
            this.cbPVN5.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownList;
            this.cbPVN5.DropDownWidth = 524;
            this.cbPVN5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPVN5.FormattingEnabled = true;
            this.cbPVN5.GridLineColor = System.Drawing.Color.LightGray;
            this.cbPVN5.GridLineHorizontal = false;
            this.cbPVN5.GridLineVertical = false;
            this.cbPVN5.IntegralHeight = false;
            this.cbPVN5.Location = new System.Drawing.Point(0, 308);
            this.cbPVN5.Name = "cbPVN5";
            this.cbPVN5.Size = new System.Drawing.Size(107, 28);
            this.cbPVN5.TabIndex = 16;
            this.cbPVN5.ValueMember = "idx";
            this.cbPVN5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbPVN5.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbPVN_MouseDoubleClick);
            // 
            // cbPVNkred
            // 
            this.cbPVNkred.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbPVNkred.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbPVNkred.ColumnWidths = "100;400";
            this.cbPVNkred.DisplayMember = "idx";
            this.cbPVNkred.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPVNkred.DropDownHeight = 176;
            this.cbPVNkred.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownList;
            this.cbPVNkred.DropDownWidth = 524;
            this.cbPVNkred.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPVNkred.FormattingEnabled = true;
            this.cbPVNkred.GridLineColor = System.Drawing.Color.LightGray;
            this.cbPVNkred.GridLineHorizontal = false;
            this.cbPVNkred.GridLineVertical = false;
            this.cbPVNkred.IntegralHeight = false;
            this.cbPVNkred.Location = new System.Drawing.Point(0, 276);
            this.cbPVNkred.Name = "cbPVNkred";
            this.cbPVNkred.Size = new System.Drawing.Size(107, 28);
            this.cbPVNkred.TabIndex = 14;
            this.cbPVNkred.ValueMember = "idx";
            this.cbPVNkred.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbPVNkred.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbPVN_MouseDoubleClick);
            // 
            // cbPVNdeb
            // 
            this.cbPVNdeb.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbPVNdeb.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbPVNdeb.ColumnWidths = "100;400";
            this.cbPVNdeb.DisplayMember = "idx";
            this.cbPVNdeb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPVNdeb.DropDownHeight = 176;
            this.cbPVNdeb.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownList;
            this.cbPVNdeb.DropDownWidth = 524;
            this.cbPVNdeb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPVNdeb.FormattingEnabled = true;
            this.cbPVNdeb.GridLineColor = System.Drawing.Color.LightGray;
            this.cbPVNdeb.GridLineHorizontal = false;
            this.cbPVNdeb.GridLineVertical = false;
            this.cbPVNdeb.IntegralHeight = false;
            this.cbPVNdeb.Location = new System.Drawing.Point(0, 244);
            this.cbPVNdeb.Name = "cbPVNdeb";
            this.cbPVNdeb.Size = new System.Drawing.Size(107, 28);
            this.cbPVNdeb.TabIndex = 12;
            this.cbPVNdeb.ValueMember = "idx";
            this.cbPVNdeb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbPVNdeb.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbPVN_MouseDoubleClick);
            // 
            // cbPVNizd
            // 
            this.cbPVNizd.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbPVNizd.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbPVNizd.ColumnWidths = "100;400";
            this.cbPVNizd.DisplayMember = "idx";
            this.cbPVNizd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPVNizd.DropDownHeight = 176;
            this.cbPVNizd.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownList;
            this.cbPVNizd.DropDownWidth = 524;
            this.cbPVNizd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPVNizd.FormattingEnabled = true;
            this.cbPVNizd.GridLineColor = System.Drawing.Color.LightGray;
            this.cbPVNizd.GridLineHorizontal = false;
            this.cbPVNizd.GridLineVertical = false;
            this.cbPVNizd.IntegralHeight = false;
            this.cbPVNizd.Location = new System.Drawing.Point(0, 212);
            this.cbPVNizd.Name = "cbPVNizd";
            this.cbPVNizd.Size = new System.Drawing.Size(107, 28);
            this.cbPVNizd.TabIndex = 10;
            this.cbPVNizd.ValueMember = "idx";
            this.cbPVNizd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbPVNizd.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbPVN_MouseDoubleClick);
            // 
            // cbPVNien
            // 
            this.cbPVNien.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbPVNien.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbPVNien.ColumnWidths = "100;400";
            this.cbPVNien.DisplayMember = "idx";
            this.cbPVNien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPVNien.DropDownHeight = 176;
            this.cbPVNien.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownList;
            this.cbPVNien.DropDownWidth = 524;
            this.cbPVNien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPVNien.FormattingEnabled = true;
            this.cbPVNien.GridLineColor = System.Drawing.Color.LightGray;
            this.cbPVNien.GridLineHorizontal = false;
            this.cbPVNien.GridLineVertical = false;
            this.cbPVNien.IntegralHeight = false;
            this.cbPVNien.Location = new System.Drawing.Point(0, 180);
            this.cbPVNien.Name = "cbPVNien";
            this.cbPVNien.Size = new System.Drawing.Size(107, 28);
            this.cbPVNien.TabIndex = 8;
            this.cbPVNien.ValueMember = "idx";
            this.cbPVNien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbPVNien.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbPVN_MouseDoubleClick);
            // 
            // cbIINien
            // 
            this.cbIINien.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbIINien.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbIINien.ColumnWidths = "100;400";
            this.cbIINien.DisplayMember = "idx";
            this.cbIINien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIINien.DropDownHeight = 176;
            this.cbIINien.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownList;
            this.cbIINien.DropDownWidth = 524;
            this.cbIINien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbIINien.FormattingEnabled = true;
            this.cbIINien.GridLineColor = System.Drawing.Color.LightGray;
            this.cbIINien.GridLineHorizontal = false;
            this.cbIINien.GridLineVertical = false;
            this.cbIINien.IntegralHeight = false;
            this.cbIINien.Location = new System.Drawing.Point(0, 106);
            this.cbIINien.Name = "cbIINien";
            this.cbIINien.Size = new System.Drawing.Size(107, 28);
            this.cbIINien.TabIndex = 5;
            this.cbIINien.ValueMember = "idx";
            this.cbIINien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbIINien.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbIIN_MouseDoubleClick);
            // 
            // cbIINizd
            // 
            this.cbIINizd.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbIINizd.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbIINizd.ColumnWidths = "100;400";
            this.cbIINizd.DisplayMember = "idx";
            this.cbIINizd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIINizd.DropDownHeight = 176;
            this.cbIINizd.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownList;
            this.cbIINizd.DropDownWidth = 524;
            this.cbIINizd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbIINizd.FormattingEnabled = true;
            this.cbIINizd.GridLineColor = System.Drawing.Color.LightGray;
            this.cbIINizd.GridLineHorizontal = false;
            this.cbIINizd.GridLineVertical = false;
            this.cbIINizd.IntegralHeight = false;
            this.cbIINizd.Location = new System.Drawing.Point(0, 72);
            this.cbIINizd.Name = "cbIINizd";
            this.cbIINizd.Size = new System.Drawing.Size(107, 28);
            this.cbIINizd.TabIndex = 3;
            this.cbIINizd.ValueMember = "idx";
            this.cbIINizd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.cbIINizd.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbIIN_MouseDoubleClick);
            // 
            // chbPVNreqPvn
            // 
            this.chbPVNreqPvn.Location = new System.Drawing.Point(115, 342);
            this.chbPVNreqPvn.Name = "chbPVNreqPvn";
            this.chbPVNreqPvn.Size = new System.Drawing.Size(603, 55);
            this.chbPVNreqPvn.TabIndex = 17;
            this.chbPVNreqPvn.Text = "Ja bilances konts ir PVN konts (\'5731\'), PVN kods (5. pazīme) nedrīkst norādīt uz" +
    " ieņēmeumiem";
            this.chbPVNreqPvn.UseVisualStyleBackColor = true;
            // 
            // chbPVNreqIen
            // 
            this.chbPVNreqIen.Location = new System.Drawing.Point(115, 403);
            this.chbPVNreqIen.Name = "chbPVNreqIen";
            this.chbPVNreqIen.Size = new System.Drawing.Size(553, 65);
            this.chbPVNreqIen.TabIndex = 18;
            this.chbPVNreqIen.Text = "Ja bilances kontā ir ieņēmumi (\'6*\'), PVN kodā jābūt ieņēmumiem (piem: \'101\')";
            this.chbPVNreqIen.UseVisualStyleBackColor = true;
            // 
            // chbPVNizd
            // 
            this.chbPVNizd.AutoSize = true;
            this.chbPVNizd.Location = new System.Drawing.Point(115, 214);
            this.chbPVNizd.Name = "chbPVNizd";
            this.chbPVNizd.Size = new System.Drawing.Size(479, 26);
            this.chbPVNizd.TabIndex = 9;
            this.chbPVNizd.Text = "PVN kods izdevumiem, ja bilances kontā ir izdevumi (7x)";
            this.chbPVNizd.UseVisualStyleBackColor = true;
            // 
            // chbPVNien
            // 
            this.chbPVNien.AutoSize = true;
            this.chbPVNien.Location = new System.Drawing.Point(115, 182);
            this.chbPVNien.Name = "chbPVNien";
            this.chbPVNien.Size = new System.Drawing.Size(439, 26);
            this.chbPVNien.TabIndex = 7;
            this.chbPVNien.Text = "PVN ieņēmumu kods, ja bilances kontā ir ieņēmumi";
            this.chbPVNien.UseVisualStyleBackColor = true;
            // 
            // chbIINien
            // 
            this.chbIINien.AutoSize = true;
            this.chbIINien.Location = new System.Drawing.Point(115, 106);
            this.chbIINien.Name = "chbIINien";
            this.chbIINien.Size = new System.Drawing.Size(498, 26);
            this.chbIINien.TabIndex = 4;
            this.chbIINien.Text = "IIN darijuma kods (\'LIE,\'NIE\'), ja bilances kontā ir ieņēmumi";
            this.chbIINien.UseVisualStyleBackColor = true;
            // 
            // chbIINizd
            // 
            this.chbIINizd.AutoSize = true;
            this.chbIINizd.Location = new System.Drawing.Point(115, 74);
            this.chbIINizd.Name = "chbIINizd";
            this.chbIINizd.Size = new System.Drawing.Size(441, 26);
            this.chbIINizd.TabIndex = 2;
            this.chbIINizd.Text = "IIN darijumu izdevumu kods (3. pazīme \'LIZ\', \'NIZ\',..)";
            this.chbIINizd.UseVisualStyleBackColor = true;
            // 
            // chbPVN5
            // 
            this.chbPVN5.AutoSize = true;
            this.chbPVN5.Location = new System.Drawing.Point(115, 310);
            this.chbPVN5.Name = "chbPVN5";
            this.chbPVN5.Size = new System.Drawing.Size(217, 26);
            this.chbPVN5.TabIndex = 15;
            this.chbPVN5.Text = "Izmantot PVN kodu 5xx";
            this.chbPVN5.UseVisualStyleBackColor = true;
            // 
            // chbPVNkred
            // 
            this.chbPVNkred.AutoSize = true;
            this.chbPVNkred.Location = new System.Drawing.Point(115, 278);
            this.chbPVNkred.Name = "chbPVNkred";
            this.chbPVNkred.Size = new System.Drawing.Size(551, 26);
            this.chbPVNkred.TabIndex = 13;
            this.chbPVNkred.Text = "Kredīta PVN kods (\'2xx\'), ja bilances kredīta konts ir PVN (\'5731\')";
            this.chbPVNkred.UseVisualStyleBackColor = true;
            // 
            // chbPVNdeb
            // 
            this.chbPVNdeb.AutoSize = true;
            this.chbPVNdeb.Location = new System.Drawing.Point(115, 246);
            this.chbPVNdeb.Name = "chbPVNdeb";
            this.chbPVNdeb.Size = new System.Drawing.Size(553, 26);
            this.chbPVNdeb.TabIndex = 11;
            this.chbPVNdeb.Text = "Debeta PVN kods (\'3xx\'), ja bilances debeta konts ir PVN (\'5731\')";
            this.chbPVNdeb.UseVisualStyleBackColor = true;
            // 
            // chbPVN
            // 
            this.chbPVN.AutoSize = true;
            this.chbPVN.Location = new System.Drawing.Point(88, 150);
            this.chbPVN.Name = "chbPVN";
            this.chbPVN.Size = new System.Drawing.Size(282, 26);
            this.chbPVN.TabIndex = 6;
            this.chbPVN.Text = "Izmantot kontējuma PVN pazīmi";
            this.chbPVN.UseVisualStyleBackColor = true;
            this.chbPVN.CheckedChanged += new System.EventHandler(this.chbPVN_CheckedChanged);
            // 
            // chbIIN
            // 
            this.chbIIN.AutoSize = true;
            this.chbIIN.Location = new System.Drawing.Point(88, 42);
            this.chbIIN.Name = "chbIIN";
            this.chbIIN.Size = new System.Drawing.Size(339, 26);
            this.chbIIN.TabIndex = 1;
            this.chbIIN.Text = "Izmantot kontējuma IIN darijuma pazīmi";
            this.chbIIN.UseVisualStyleBackColor = true;
            this.chbIIN.CheckedChanged += new System.EventHandler(this.chbIIN_CheckedChanged);
            // 
            // chbNP
            // 
            this.chbNP.AutoSize = true;
            this.chbNP.Location = new System.Drawing.Point(88, 0);
            this.chbNP.Name = "chbNP";
            this.chbNP.Size = new System.Drawing.Size(375, 26);
            this.chbNP.TabIndex = 0;
            this.chbNP.Text = "Izmantot kontējuma naudas plūsmas pazīmi";
            this.chbNP.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.cbPVN5);
            this.panel1.Controls.Add(this.cbPVNkred);
            this.panel1.Controls.Add(this.cbPVNdeb);
            this.panel1.Controls.Add(this.cbPVNizd);
            this.panel1.Controls.Add(this.cbPVNien);
            this.panel1.Controls.Add(this.cbIINien);
            this.panel1.Controls.Add(this.cbIINizd);
            this.panel1.Controls.Add(this.chbPVNreqPvn);
            this.panel1.Controls.Add(this.chbPVNreqIen);
            this.panel1.Controls.Add(this.chbPVNizd);
            this.panel1.Controls.Add(this.chbPVNien);
            this.panel1.Controls.Add(this.chbIINien);
            this.panel1.Controls.Add(this.chbIINizd);
            this.panel1.Controls.Add(this.chbPVN5);
            this.panel1.Controls.Add(this.chbPVNkred);
            this.panel1.Controls.Add(this.chbPVNdeb);
            this.panel1.Controls.Add(this.chbPVN);
            this.panel1.Controls.Add(this.chbIIN);
            this.panel1.Controls.Add(this.chbNP);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(770, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 310);
            this.panel1.TabIndex = 21;
            // 
            // Form_OpsRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(774, 404);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.myLabel1);
            this.Controls.Add(this.cmClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(8, 440);
            this.Name = "Form_OpsRules";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Kontējumu kontrole";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormOpsRules_FormClosed);
            this.Load += new System.EventHandler(this.FormOpsRules_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmClose;
        private MyLabel myLabel1;
        private MyMcFlatComboBox cbPVN5;
        private MyMcFlatComboBox cbPVNkred;
        private MyMcFlatComboBox cbPVNdeb;
        private MyMcFlatComboBox cbPVNizd;
        private MyMcFlatComboBox cbPVNien;
        private MyMcFlatComboBox cbIINien;
        private MyMcFlatComboBox cbIINizd;
        private System.Windows.Forms.CheckBox chbPVNreqPvn;
        private System.Windows.Forms.CheckBox chbPVNreqIen;
        private System.Windows.Forms.CheckBox chbPVNizd;
        private System.Windows.Forms.CheckBox chbPVNien;
        private System.Windows.Forms.CheckBox chbIINien;
        private System.Windows.Forms.CheckBox chbIINizd;
        private System.Windows.Forms.CheckBox chbPVN5;
        private System.Windows.Forms.CheckBox chbPVNkred;
        private System.Windows.Forms.CheckBox chbPVNdeb;
        private System.Windows.Forms.CheckBox chbPVN;
        private System.Windows.Forms.CheckBox chbIIN;
        private System.Windows.Forms.CheckBox chbNP;
        private System.Windows.Forms.Panel panel1;
    }
}