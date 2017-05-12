using KlonsLIB.Components;

namespace KlonsP.Forms
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
            this.chCheckVersion = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "Programmas izskats:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 22);
            this.label3.TabIndex = 11;
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
            this.cbFontSize.DropDownHeight = 220;
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
            this.cbFontSize.Location = new System.Drawing.Point(175, 35);
            this.cbFontSize.MaxDropDownItems = 10;
            this.cbFontSize.Name = "cbFontSize";
            this.cbFontSize.Size = new System.Drawing.Size(90, 28);
            this.cbFontSize.TabIndex = 0;
            this.cbFontSize.ValueMember = "col1";
            this.cbFontSize.SelectedIndexChanged += new System.EventHandler(this.cbFontSize_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 22);
            this.label4.TabIndex = 13;
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
            this.cbColors.Location = new System.Drawing.Point(175, 110);
            this.cbColors.Name = "cbColors";
            this.cbColors.Size = new System.Drawing.Size(257, 28);
            this.cbColors.TabIndex = 3;
            this.cbColors.ValueMember = "col1";
            this.cbColors.SelectedIndexChanged += new System.EventHandler(this.cbColors_SelectedIndexChanged);
            // 
            // cmOK
            // 
            this.cmOK.Location = new System.Drawing.Point(412, 190);
            this.cmOK.Name = "cmOK";
            this.cmOK.Size = new System.Drawing.Size(112, 48);
            this.cmOK.TabIndex = 8;
            this.cmOK.Text = "OK";
            this.cmOK.UseVisualStyleBackColor = true;
            this.cmOK.Click += new System.EventHandler(this.cmOK_Click);
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(412, 254);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(112, 48);
            this.cmCancel.TabIndex = 9;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            // 
            // cmFont
            // 
            this.cmFont.AutoSize = true;
            this.cmFont.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmFont.Location = new System.Drawing.Point(175, 69);
            this.cmFont.Name = "cmFont";
            this.cmFont.Size = new System.Drawing.Size(67, 34);
            this.cmFont.TabIndex = 2;
            this.cmFont.Text = "Fonts";
            this.cmFont.UseVisualStyleBackColor = true;
            this.cmFont.Click += new System.EventHandler(this.cmFont_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 22);
            this.label5.TabIndex = 12;
            this.label5.Text = "Fonts:";
            // 
            // cmUseSysFont
            // 
            this.cmUseSysFont.AutoSize = true;
            this.cmUseSysFont.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmUseSysFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmUseSysFont.Location = new System.Drawing.Point(280, 31);
            this.cmUseSysFont.Name = "cmUseSysFont";
            this.cmUseSysFont.Size = new System.Drawing.Size(184, 34);
            this.cmUseSysFont.TabIndex = 1;
            this.cmUseSysFont.Text = "Ņemt sistēmas fontu";
            this.cmUseSysFont.UseVisualStyleBackColor = true;
            this.cmUseSysFont.Click += new System.EventHandler(this.cmUseSysFont_Click);
            // 
            // chCheckVersion
            // 
            this.chCheckVersion.AutoSize = true;
            this.chCheckVersion.Location = new System.Drawing.Point(16, 345);
            this.chCheckVersion.Name = "chCheckVersion";
            this.chCheckVersion.Size = new System.Drawing.Size(463, 26);
            this.chCheckVersion.TabIndex = 15;
            this.chCheckVersion.Text = "Pārbaudīt, vai ir pieejama jaunāka programmas versija";
            this.chCheckVersion.UseVisualStyleBackColor = true;
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 380);
            this.Controls.Add(this.chCheckVersion);
            this.Controls.Add(this.cmUseSysFont);
            this.Controls.Add(this.cmFont);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbColors);
            this.Controls.Add(this.cbFontSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.CheckBox chCheckVersion;
    }
}