using KlonsLIB.Components;

namespace KlonsF.Forms
{
    partial class Form_Settings
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
            KlonsLIB.Components.MyMcComboBox.MyItem myItem1 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem2 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem3 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem4 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem5 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem6 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem7 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem8 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem9 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem10 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem11 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem12 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem13 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem14 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem15 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem16 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem17 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            this.label1 = new System.Windows.Forms.Label();
            this.chC1 = new MyCheckBox();
            this.chC2 = new MyCheckBox();
            this.chC3 = new MyCheckBox();
            this.chC4 = new MyCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFontSize = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbColors = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cmOK = new System.Windows.Forms.Button();
            this.cmCancel = new System.Windows.Forms.Button();
            this.cmFont = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmUseSysFont = new System.Windows.Forms.Button();
            this.chUseCurrency = new MyCheckBox();
            this.chCheckVersion = new MyCheckBox();
            this.chInWine = new MyCheckBox();
            this.cbBackUpPlan = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbBackUpFolder = new KlonsLIB.Components.MyTextBox();
            this.cmBrowseForBackUpFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Izvēlamies kādas kolonnas tiks izmantotas:";
            // 
            // chC1
            // 
            this.chC1.AutoSize = true;
            this.chC1.Location = new System.Drawing.Point(40, 180);
            this.chC1.Margin = new System.Windows.Forms.Padding(2);
            this.chC1.Name = "chC1";
            this.chC1.Size = new System.Drawing.Size(191, 24);
            this.chC1.TabIndex = 4;
            this.chC1.Text = "Naudas plūsmas kods";
            this.chC1.UseVisualStyleBackColor = true;
            // 
            // chC2
            // 
            this.chC2.AutoSize = true;
            this.chC2.Location = new System.Drawing.Point(40, 212);
            this.chC2.Margin = new System.Windows.Forms.Padding(2);
            this.chC2.Name = "chC2";
            this.chC2.Size = new System.Drawing.Size(247, 24);
            this.chC2.TabIndex = 5;
            this.chC2.Text = "IIN ieņēmumu, izdevumu kods";
            this.chC2.UseVisualStyleBackColor = true;
            // 
            // chC3
            // 
            this.chC3.AutoSize = true;
            this.chC3.Location = new System.Drawing.Point(40, 244);
            this.chC3.Margin = new System.Windows.Forms.Padding(2);
            this.chC3.Name = "chC3";
            this.chC3.Size = new System.Drawing.Size(202, 24);
            this.chC3.TabIndex = 6;
            this.chC3.Text = "Produkta, nozares kods";
            this.chC3.UseVisualStyleBackColor = true;
            // 
            // chC4
            // 
            this.chC4.AutoSize = true;
            this.chC4.Location = new System.Drawing.Point(40, 276);
            this.chC4.Margin = new System.Windows.Forms.Padding(2);
            this.chC4.Name = "chC4";
            this.chC4.Size = new System.Drawing.Size(105, 24);
            this.chC4.TabIndex = 7;
            this.chC4.Text = "PVN kods";
            this.chC4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Programmas izskats:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Fonta izmērs:";
            // 
            // cbFontSize
            // 
            this.cbFontSize.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbFontSize.ColumnNames = new string[] {
        "col1"};
            this.cbFontSize.ColumnWidths = "66";
            this.cbFontSize.DisplayMember = "col1";
            this.cbFontSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFontSize.DropDownHeight = 210;
            this.cbFontSize.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbFontSize.DropDownWidth = 94;
            this.cbFontSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFontSize.FormattingEnabled = true;
            this.cbFontSize.GridLineColor = System.Drawing.Color.LightGray;
            this.cbFontSize.GridLineHorizontal = false;
            this.cbFontSize.GridLineVertical = false;
            this.cbFontSize.IntegralHeight = false;
            myItem1.Col1 = "08";
            myItem2.Col1 = "09";
            myItem3.Col1 = "10";
            myItem4.Col1 = "11";
            myItem5.Col1 = "12";
            myItem6.Col1 = "13";
            myItem7.Col1 = "14";
            myItem8.Col1 = "15";
            myItem9.Col1 = "16";
            this.cbFontSize.Items.AddRange(new object[] {
            myItem1,
            myItem2,
            myItem3,
            myItem4,
            myItem5,
            myItem6,
            myItem7,
            myItem8,
            myItem9});
            this.cbFontSize.ItemStrings = new string[] {
        "08",
        "09",
        "10",
        "11",
        "12",
        "13",
        "14",
        "15",
        "16"};
            this.cbFontSize.Location = new System.Drawing.Point(158, 35);
            this.cbFontSize.Margin = new System.Windows.Forms.Padding(2);
            this.cbFontSize.MaxDropDownItems = 10;
            this.cbFontSize.Name = "cbFontSize";
            this.cbFontSize.Size = new System.Drawing.Size(82, 27);
            this.cbFontSize.TabIndex = 0;
            this.cbFontSize.ValueMember = "col1";
            this.cbFontSize.SelectedIndexChanged += new System.EventHandler(this.cbFontSize_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Krāsu palete:";
            // 
            // cbColors
            // 
            this.cbColors.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbColors.ColumnNames = new string[] {
        "col1"};
            this.cbColors.ColumnWidths = "200";
            this.cbColors.DisplayMember = "col1";
            this.cbColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColors.DropDownHeight = 168;
            this.cbColors.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbColors.DropDownWidth = 228;
            this.cbColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbColors.FormattingEnabled = true;
            this.cbColors.GridLineColor = System.Drawing.Color.LightGray;
            this.cbColors.GridLineHorizontal = false;
            this.cbColors.GridLineVertical = false;
            this.cbColors.IntegralHeight = false;
            myItem10.Col1 = "Sistēmas krāsas";
            myItem11.Col1 = "Tumšā tēma 1";
            myItem12.Col1 = "Zaļš uz melna";
            myItem13.Col1 = "Melns uz balta";
            this.cbColors.Items.AddRange(new object[] {
            myItem10,
            myItem11,
            myItem12,
            myItem13});
            this.cbColors.ItemStrings = new string[] {
        "Sistēmas krāsas",
        "Tumšā tēma 1",
        "Zaļš uz melna",
        "Melns uz balta"};
            this.cbColors.Location = new System.Drawing.Point(158, 110);
            this.cbColors.Margin = new System.Windows.Forms.Padding(2);
            this.cbColors.Name = "cbColors";
            this.cbColors.Size = new System.Drawing.Size(231, 27);
            this.cbColors.TabIndex = 3;
            this.cbColors.ValueMember = "col1";
            this.cbColors.SelectedIndexChanged += new System.EventHandler(this.cbColors_SelectedIndexChanged);
            // 
            // cmOK
            // 
            this.cmOK.Location = new System.Drawing.Point(556, 352);
            this.cmOK.Margin = new System.Windows.Forms.Padding(2);
            this.cmOK.Name = "cmOK";
            this.cmOK.Size = new System.Drawing.Size(101, 48);
            this.cmOK.TabIndex = 14;
            this.cmOK.Text = "OK";
            this.cmOK.UseVisualStyleBackColor = true;
            this.cmOK.Click += new System.EventHandler(this.cmOK_Click);
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(669, 352);
            this.cmCancel.Margin = new System.Windows.Forms.Padding(2);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(101, 48);
            this.cmCancel.TabIndex = 15;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            // 
            // cmFont
            // 
            this.cmFont.AutoSize = true;
            this.cmFont.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmFont.Location = new System.Drawing.Point(158, 69);
            this.cmFont.Margin = new System.Windows.Forms.Padding(2);
            this.cmFont.Name = "cmFont";
            this.cmFont.Size = new System.Drawing.Size(62, 32);
            this.cmFont.TabIndex = 2;
            this.cmFont.Text = "Fonts";
            this.cmFont.UseVisualStyleBackColor = true;
            this.cmFont.Click += new System.EventHandler(this.cmFont_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Fonts:";
            // 
            // cmUseSysFont
            // 
            this.cmUseSysFont.AutoSize = true;
            this.cmUseSysFont.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmUseSysFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmUseSysFont.Location = new System.Drawing.Point(252, 31);
            this.cmUseSysFont.Margin = new System.Windows.Forms.Padding(2);
            this.cmUseSysFont.Name = "cmUseSysFont";
            this.cmUseSysFont.Size = new System.Drawing.Size(167, 32);
            this.cmUseSysFont.TabIndex = 1;
            this.cmUseSysFont.Text = "Ņemt sistēmas fontu";
            this.cmUseSysFont.UseVisualStyleBackColor = true;
            this.cmUseSysFont.Click += new System.EventHandler(this.cmUseSysFont_Click);
            // 
            // chUseCurrency
            // 
            this.chUseCurrency.AutoSize = true;
            this.chUseCurrency.Location = new System.Drawing.Point(40, 308);
            this.chUseCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.chUseCurrency.Name = "chUseCurrency";
            this.chUseCurrency.Size = new System.Drawing.Size(187, 24);
            this.chUseCurrency.TabIndex = 8;
            this.chUseCurrency.Text = "Rādīt valūtas kolonnu";
            this.chUseCurrency.UseVisualStyleBackColor = true;
            // 
            // chCheckVersion
            // 
            this.chCheckVersion.AutoSize = true;
            this.chCheckVersion.Location = new System.Drawing.Point(15, 345);
            this.chCheckVersion.Margin = new System.Windows.Forms.Padding(2);
            this.chCheckVersion.Name = "chCheckVersion";
            this.chCheckVersion.Size = new System.Drawing.Size(411, 24);
            this.chCheckVersion.TabIndex = 9;
            this.chCheckVersion.Text = "Pārbaudīt, vai ir pieejama jaunāka programmas versija";
            this.chCheckVersion.UseVisualStyleBackColor = true;
            // 
            // chInWine
            // 
            this.chInWine.AutoSize = true;
            this.chInWine.Location = new System.Drawing.Point(15, 376);
            this.chInWine.Margin = new System.Windows.Forms.Padding(2);
            this.chInWine.Name = "chInWine";
            this.chInWine.Size = new System.Drawing.Size(144, 24);
            this.chInWine.TabIndex = 10;
            this.chInWine.Text = "Linux Wine vide";
            this.chInWine.UseVisualStyleBackColor = true;
            // 
            // cbBackUpPlan
            // 
            this.cbBackUpPlan.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbBackUpPlan.ColumnNames = new string[] {
        "col1"};
            this.cbBackUpPlan.ColumnWidths = "190";
            this.cbBackUpPlan.DisplayMember = "col1";
            this.cbBackUpPlan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBackUpPlan.DropDownHeight = 168;
            this.cbBackUpPlan.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbBackUpPlan.DropDownWidth = 218;
            this.cbBackUpPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBackUpPlan.FormattingEnabled = true;
            this.cbBackUpPlan.GridLineColor = System.Drawing.Color.LightGray;
            this.cbBackUpPlan.GridLineHorizontal = false;
            this.cbBackUpPlan.GridLineVertical = false;
            this.cbBackUpPlan.IntegralHeight = false;
            myItem14.Col1 = "Nekad";
            myItem15.Col1 = "Pirms aktualizēšanas";
            myItem16.Col1 = "Vienreiz dienā";
            myItem17.Col1 = "Pirms katras atvēršanas";
            this.cbBackUpPlan.Items.AddRange(new object[] {
            myItem14,
            myItem15,
            myItem16,
            myItem17});
            this.cbBackUpPlan.ItemStrings = new string[] {
        "Nekad",
        "Pirms aktualizēšanas",
        "Vienreiz dienā",
        "Pirms katras atvēršanas"};
            this.cbBackUpPlan.Location = new System.Drawing.Point(439, 59);
            this.cbBackUpPlan.Margin = new System.Windows.Forms.Padding(2);
            this.cbBackUpPlan.Name = "cbBackUpPlan";
            this.cbBackUpPlan.Size = new System.Drawing.Size(218, 27);
            this.cbBackUpPlan.TabIndex = 11;
            this.cbBackUpPlan.ValueMember = "col1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Rezerves kopēšanas plāns:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(435, 112);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Rezerves kopiju mape:";
            // 
            // tbBackUpFolder
            // 
            this.tbBackUpFolder.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbBackUpFolder.Location = new System.Drawing.Point(439, 135);
            this.tbBackUpFolder.Name = "tbBackUpFolder";
            this.tbBackUpFolder.Size = new System.Drawing.Size(331, 26);
            this.tbBackUpFolder.TabIndex = 12;
            this.tbBackUpFolder.WordWrap = false;
            // 
            // cmBrowseForBackUpFolder
            // 
            this.cmBrowseForBackUpFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmBrowseForBackUpFolder.Location = new System.Drawing.Point(439, 167);
            this.cmBrowseForBackUpFolder.Name = "cmBrowseForBackUpFolder";
            this.cmBrowseForBackUpFolder.Size = new System.Drawing.Size(105, 31);
            this.cmBrowseForBackUpFolder.TabIndex = 13;
            this.cmBrowseForBackUpFolder.Text = "Noradīt";
            this.cmBrowseForBackUpFolder.UseVisualStyleBackColor = true;
            this.cmBrowseForBackUpFolder.Click += new System.EventHandler(this.cmBrowseForBackUpFolder_Click);
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 406);
            this.Controls.Add(this.cmBrowseForBackUpFolder);
            this.Controls.Add(this.tbBackUpFolder);
            this.Controls.Add(this.chCheckVersion);
            this.Controls.Add(this.chInWine);
            this.Controls.Add(this.chUseCurrency);
            this.Controls.Add(this.cmUseSysFont);
            this.Controls.Add(this.cmFont);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmOK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbBackUpPlan);
            this.Controls.Add(this.cbColors);
            this.Controls.Add(this.cbFontSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chC4);
            this.Controls.Add(this.chC3);
            this.Controls.Add(this.chC2);
            this.Controls.Add(this.chC1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kā strādāsim?";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private MyCheckBox chC1;
        private MyCheckBox chC2;
        private MyCheckBox chC3;
        private MyCheckBox chC4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MyMcFlatComboBox cbFontSize;
        private System.Windows.Forms.Label label4;
        private MyMcFlatComboBox cbColors;
        private System.Windows.Forms.Button cmOK;
        private System.Windows.Forms.Button cmCancel;
        private System.Windows.Forms.Button cmFont;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmUseSysFont;
        private MyCheckBox chUseCurrency;
        private MyCheckBox chCheckVersion;
        private MyCheckBox chInWine;
        private MyMcFlatComboBox cbBackUpPlan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private MyTextBox tbBackUpFolder;
        private System.Windows.Forms.Button cmBrowseForBackUpFolder;
    }
}