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
            this.label1 = new System.Windows.Forms.Label();
            this.chC1 = new System.Windows.Forms.CheckBox();
            this.chC2 = new System.Windows.Forms.CheckBox();
            this.chC3 = new System.Windows.Forms.CheckBox();
            this.chC4 = new System.Windows.Forms.CheckBox();
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
            this.chUseCurrency = new System.Windows.Forms.CheckBox();
            this.chCheckVersion = new System.Windows.Forms.CheckBox();
            this.chInWine = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Izvēlamies kādas kolonnas tiks izmantotas:";
            // 
            // chC1
            // 
            this.chC1.AutoSize = true;
            this.chC1.Location = new System.Drawing.Point(36, 144);
            this.chC1.Margin = new System.Windows.Forms.Padding(2);
            this.chC1.Name = "chC1";
            this.chC1.Size = new System.Drawing.Size(165, 20);
            this.chC1.TabIndex = 5;
            this.chC1.Text = "Naudas plūsmas kods";
            this.chC1.UseVisualStyleBackColor = true;
            // 
            // chC2
            // 
            this.chC2.AutoSize = true;
            this.chC2.Location = new System.Drawing.Point(36, 170);
            this.chC2.Margin = new System.Windows.Forms.Padding(2);
            this.chC2.Name = "chC2";
            this.chC2.Size = new System.Drawing.Size(207, 20);
            this.chC2.TabIndex = 6;
            this.chC2.Text = "IIN ieņēmumu, izdevumu kods";
            this.chC2.UseVisualStyleBackColor = true;
            // 
            // chC3
            // 
            this.chC3.AutoSize = true;
            this.chC3.Location = new System.Drawing.Point(36, 195);
            this.chC3.Margin = new System.Windows.Forms.Padding(2);
            this.chC3.Name = "chC3";
            this.chC3.Size = new System.Drawing.Size(171, 20);
            this.chC3.TabIndex = 7;
            this.chC3.Text = "Produkta, nozares kods";
            this.chC3.UseVisualStyleBackColor = true;
            // 
            // chC4
            // 
            this.chC4.AutoSize = true;
            this.chC4.Location = new System.Drawing.Point(36, 221);
            this.chC4.Margin = new System.Windows.Forms.Padding(2);
            this.chC4.Name = "chC4";
            this.chC4.Size = new System.Drawing.Size(91, 20);
            this.chC4.TabIndex = 8;
            this.chC4.Text = "PVN kods";
            this.chC4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Programmas izskats:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 15;
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
            this.cbFontSize.DropDownHeight = 170;
            this.cbFontSize.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbFontSize.DropDownWidth = 90;
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
            this.cbFontSize.Location = new System.Drawing.Point(140, 28);
            this.cbFontSize.Margin = new System.Windows.Forms.Padding(2);
            this.cbFontSize.MaxDropDownItems = 10;
            this.cbFontSize.Name = "cbFontSize";
            this.cbFontSize.Size = new System.Drawing.Size(73, 23);
            this.cbFontSize.TabIndex = 0;
            this.cbFontSize.ValueMember = "col1";
            this.cbFontSize.SelectedIndexChanged += new System.EventHandler(this.cbFontSize_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 17;
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
            this.cbColors.DropDownHeight = 136;
            this.cbColors.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbColors.DropDownWidth = 224;
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
            this.cbColors.Location = new System.Drawing.Point(140, 88);
            this.cbColors.Margin = new System.Windows.Forms.Padding(2);
            this.cbColors.Name = "cbColors";
            this.cbColors.Size = new System.Drawing.Size(206, 23);
            this.cbColors.TabIndex = 3;
            this.cbColors.ValueMember = "col1";
            this.cbColors.SelectedIndexChanged += new System.EventHandler(this.cbColors_SelectedIndexChanged);
            // 
            // cmOK
            // 
            this.cmOK.Location = new System.Drawing.Point(318, 152);
            this.cmOK.Margin = new System.Windows.Forms.Padding(2);
            this.cmOK.Name = "cmOK";
            this.cmOK.Size = new System.Drawing.Size(90, 38);
            this.cmOK.TabIndex = 12;
            this.cmOK.Text = "OK";
            this.cmOK.UseVisualStyleBackColor = true;
            this.cmOK.Click += new System.EventHandler(this.cmOK_Click);
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(318, 203);
            this.cmCancel.Margin = new System.Windows.Forms.Padding(2);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(90, 38);
            this.cmCancel.TabIndex = 13;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            // 
            // cmFont
            // 
            this.cmFont.AutoSize = true;
            this.cmFont.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmFont.Location = new System.Drawing.Point(140, 55);
            this.cmFont.Margin = new System.Windows.Forms.Padding(2);
            this.cmFont.Name = "cmFont";
            this.cmFont.Size = new System.Drawing.Size(53, 28);
            this.cmFont.TabIndex = 2;
            this.cmFont.Text = "Fonts";
            this.cmFont.UseVisualStyleBackColor = true;
            this.cmFont.Click += new System.EventHandler(this.cmFont_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Fonts:";
            // 
            // cmUseSysFont
            // 
            this.cmUseSysFont.AutoSize = true;
            this.cmUseSysFont.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmUseSysFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmUseSysFont.Location = new System.Drawing.Point(224, 25);
            this.cmUseSysFont.Margin = new System.Windows.Forms.Padding(2);
            this.cmUseSysFont.Name = "cmUseSysFont";
            this.cmUseSysFont.Size = new System.Drawing.Size(140, 28);
            this.cmUseSysFont.TabIndex = 1;
            this.cmUseSysFont.Text = "Ņemt sistēmas fontu";
            this.cmUseSysFont.UseVisualStyleBackColor = true;
            this.cmUseSysFont.Click += new System.EventHandler(this.cmUseSysFont_Click);
            // 
            // chUseCurrency
            // 
            this.chUseCurrency.AutoSize = true;
            this.chUseCurrency.Location = new System.Drawing.Point(36, 246);
            this.chUseCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.chUseCurrency.Name = "chUseCurrency";
            this.chUseCurrency.Size = new System.Drawing.Size(158, 20);
            this.chUseCurrency.TabIndex = 9;
            this.chUseCurrency.Text = "Rādīt valūtas kolonnu";
            this.chUseCurrency.UseVisualStyleBackColor = true;
            // 
            // chCheckVersion
            // 
            this.chCheckVersion.AutoSize = true;
            this.chCheckVersion.Location = new System.Drawing.Point(13, 276);
            this.chCheckVersion.Margin = new System.Windows.Forms.Padding(2);
            this.chCheckVersion.Name = "chCheckVersion";
            this.chCheckVersion.Size = new System.Drawing.Size(356, 20);
            this.chCheckVersion.TabIndex = 10;
            this.chCheckVersion.Text = "Pārbaudīt, vai ir pieejama jaunāka programmas versija";
            this.chCheckVersion.UseVisualStyleBackColor = true;
            // 
            // chInWine
            // 
            this.chInWine.AutoSize = true;
            this.chInWine.Location = new System.Drawing.Point(13, 301);
            this.chInWine.Margin = new System.Windows.Forms.Padding(2);
            this.chInWine.Name = "chInWine";
            this.chInWine.Size = new System.Drawing.Size(123, 20);
            this.chInWine.TabIndex = 11;
            this.chInWine.Text = "Linux Wine vide";
            this.chInWine.UseVisualStyleBackColor = true;
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 326);
            this.Controls.Add(this.chCheckVersion);
            this.Controls.Add(this.chInWine);
            this.Controls.Add(this.chUseCurrency);
            this.Controls.Add(this.cmUseSysFont);
            this.Controls.Add(this.cmFont);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmOK);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.CheckBox chC1;
        private System.Windows.Forms.CheckBox chC2;
        private System.Windows.Forms.CheckBox chC3;
        private System.Windows.Forms.CheckBox chC4;
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
        private System.Windows.Forms.CheckBox chUseCurrency;
        private System.Windows.Forms.CheckBox chCheckVersion;
        private System.Windows.Forms.CheckBox chInWine;
    }
}