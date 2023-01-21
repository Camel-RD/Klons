using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsFM.FormsReportParams
{
    partial class FormRep_ApgrNP
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
            this.cbAC = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsAC = new KlonsLIB.Data.MyBindingSource();
            this.tbSD = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbED = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbACName = new System.Windows.Forms.Label();
            this.cmDoIt = new System.Windows.Forms.Button();
            this.cbCharCount = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.myLabel1 = new KlonsLIB.Components.MyLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAC
            // 
            this.cbAC.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC.ColumnNames = new string[] {
        "ac",
        "name"};
            this.cbAC.ColumnWidths = "80;300";
            this.cbAC.DataSource = this.bsAC;
            this.cbAC.DisplayMember = "AC";
            this.cbAC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC.DropDownHeight = 255;
            this.cbAC.DropDownWidth = 404;
            this.cbAC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC.FormattingEnabled = true;
            this.cbAC.GridLineColor = System.Drawing.Color.LightGray;
            this.cbAC.GridLineHorizontal = false;
            this.cbAC.GridLineVertical = false;
            this.cbAC.IntegralHeight = false;
            this.cbAC.Location = new System.Drawing.Point(152, 85);
            this.cbAC.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC.MaxDropDownItems = 15;
            this.cbAC.Name = "cbAC";
            this.cbAC.Size = new System.Drawing.Size(104, 23);
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
            this.tbSD.Location = new System.Drawing.Point(152, 38);
            this.tbSD.Margin = new System.Windows.Forms.Padding(2);
            this.tbSD.Name = "tbSD";
            this.tbSD.Size = new System.Drawing.Size(80, 22);
            this.tbSD.TabIndex = 0;
            this.tbSD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Datums (no - līdz):";
            // 
            // tbED
            // 
            this.tbED.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbED.IsDate = true;
            this.tbED.Location = new System.Drawing.Point(238, 38);
            this.tbED.Margin = new System.Windows.Forms.Padding(2);
            this.tbED.Name = "tbED";
            this.tbED.Size = new System.Drawing.Size(80, 22);
            this.tbED.TabIndex = 1;
            this.tbED.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Konts:";
            // 
            // lbACName
            // 
            this.lbACName.Location = new System.Drawing.Point(157, 110);
            this.lbACName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbACName.Name = "lbACName";
            this.lbACName.Size = new System.Drawing.Size(332, 18);
            this.lbACName.TabIndex = 9;
            this.lbACName.Text = "Konts:";
            // 
            // cmDoIt
            // 
            this.cmDoIt.Location = new System.Drawing.Point(314, 188);
            this.cmDoIt.Margin = new System.Windows.Forms.Padding(2);
            this.cmDoIt.Name = "cmDoIt";
            this.cmDoIt.Size = new System.Drawing.Size(133, 63);
            this.cmDoIt.TabIndex = 4;
            this.cmDoIt.Text = "Taisīt atskaiti";
            this.cmDoIt.UseVisualStyleBackColor = true;
            this.cmDoIt.Click += new System.EventHandler(this.cmDoIt_Click);
            this.cmDoIt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // cbCharCount
            // 
            this.cbCharCount.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbCharCount.ColumnNames = new string[] {
        "col1"};
            this.cbCharCount.ColumnWidths = "121";
            this.cbCharCount.DisplayMember = "col1";
            this.cbCharCount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCharCount.DropDownHeight = 136;
            this.cbCharCount.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbCharCount.DropDownWidth = 145;
            this.cbCharCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCharCount.FormattingEnabled = true;
            this.cbCharCount.GridLineColor = System.Drawing.Color.LightGray;
            this.cbCharCount.GridLineHorizontal = false;
            this.cbCharCount.GridLineVertical = false;
            this.cbCharCount.IntegralHeight = false;
            myItem1.Col1 = "*";
            myItem2.Col1 = "1";
            myItem3.Col1 = "2";
            myItem4.Col1 = "3";
            myItem5.Col1 = "4";
            this.cbCharCount.Items.AddRange(new object[] {
            myItem1,
            myItem2,
            myItem3,
            myItem4,
            myItem5});
            this.cbCharCount.ItemStrings = new string[] {
        "*",
        "1",
        "2",
        "3",
        "4"};
            this.cbCharCount.Location = new System.Drawing.Point(152, 152);
            this.cbCharCount.Margin = new System.Windows.Forms.Padding(2);
            this.cbCharCount.Name = "cbCharCount";
            this.cbCharCount.Size = new System.Drawing.Size(67, 23);
            this.cbCharCount.TabIndex = 3;
            this.cbCharCount.ValueMember = "col1";
            this.cbCharCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Konta zīmju skaits:";
            // 
            // myLabel1
            // 
            this.myLabel1.AutoSize = true;
            this.myLabel1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.myLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myLabel1.Location = new System.Drawing.Point(26, 200);
            this.myLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.Padding = new System.Windows.Forms.Padding(8);
            this.myLabel1.Size = new System.Drawing.Size(199, 48);
            this.myLabel1.TabIndex = 8;
            this.myLabel1.Text = "Lai dabūtu atskaiti par visiem \r\nkontiem, lodzinā jāieliek \'*\'";
            // 
            // FormRep_ApgrNP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 276);
            this.CloseOnEscape = true;
            this.Controls.Add(this.myLabel1);
            this.Controls.Add(this.cbCharCount);
            this.Controls.Add(this.cmDoIt);
            this.Controls.Add(this.lbACName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbED);
            this.Controls.Add(this.tbSD);
            this.Controls.Add(this.cbAC);
            this.Name = "FormRep_ApgrNP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apgrozijumu pārskats: naudas plūsma";
            this.Load += new System.EventHandler(this.FormRepApgr1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).EndInit();
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
    }
}