using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.FormsReportParams
{
    partial class FormRep_PVNZ1
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
            this.bsAC = new KlonsLIB.Data.MyBindingSource();
            this.label1 = new System.Windows.Forms.Label();
            this.cmDoIt = new System.Windows.Forms.Button();
            this.cbYear = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMonth = new KlonsLIB.Components.MyMcFlatComboBox();
            this.tbPageNr = new KlonsLIB.Components.MyTextBox();
            this.tbRowNr = new KlonsLIB.Components.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).BeginInit();
            this.SuspendLayout();
            // 
            // bsAC
            // 
            this.bsAC.DataMember = "AcP21";
            this.bsAC.MyDataSource = "KlonsData";
            this.bsAC.Name2 = "bsAC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Gads:";
            // 
            // cmDoIt
            // 
            this.cmDoIt.Location = new System.Drawing.Point(277, 125);
            this.cmDoIt.Margin = new System.Windows.Forms.Padding(2);
            this.cmDoIt.Name = "cmDoIt";
            this.cmDoIt.Size = new System.Drawing.Size(133, 63);
            this.cmDoIt.TabIndex = 4;
            this.cmDoIt.Text = "Taisīt atskaiti";
            this.cmDoIt.UseVisualStyleBackColor = true;
            this.cmDoIt.Click += new System.EventHandler(this.cmDoIt_Click);
            this.cmDoIt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // cbYear
            // 
            this.cbYear.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbYear.ColumnNames = new string[] {
        "col1"};
            this.cbYear.ColumnWidths = "98";
            this.cbYear.DisplayMember = "col1";
            this.cbYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbYear.DropDownHeight = 136;
            this.cbYear.DropDownWidth = 122;
            this.cbYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.GridLineColor = System.Drawing.Color.LightGray;
            this.cbYear.GridLineHorizontal = false;
            this.cbYear.GridLineVertical = false;
            this.cbYear.IntegralHeight = false;
            myItem1.Col1 = "2014";
            myItem2.Col1 = "2015";
            this.cbYear.Items.AddRange(new object[] {
            myItem1,
            myItem2});
            this.cbYear.ItemStrings = new string[] {
        "2014",
        "2015"};
            this.cbYear.Location = new System.Drawing.Point(70, 36);
            this.cbYear.Margin = new System.Windows.Forms.Padding(2);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(79, 23);
            this.cbYear.TabIndex = 0;
            this.cbYear.ValueMember = "col1";
            this.cbYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "mēnesis:";
            // 
            // cbMonth
            // 
            this.cbMonth.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbMonth.ColumnNames = new string[] {
        "col1"};
            this.cbMonth.ColumnWidths = "78";
            this.cbMonth.DisplayMember = "col1";
            this.cbMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMonth.DropDownHeight = 204;
            this.cbMonth.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbMonth.DropDownWidth = 102;
            this.cbMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.GridLineColor = System.Drawing.Color.LightGray;
            this.cbMonth.GridLineHorizontal = false;
            this.cbMonth.GridLineVertical = false;
            this.cbMonth.IntegralHeight = false;
            myItem3.Col1 = "01";
            myItem4.Col1 = "02";
            myItem5.Col1 = "03";
            myItem6.Col1 = "04";
            myItem7.Col1 = "05";
            myItem8.Col1 = "06";
            myItem9.Col1 = "07";
            myItem10.Col1 = "08";
            myItem11.Col1 = "09";
            myItem12.Col1 = "10";
            myItem13.Col1 = "11";
            myItem14.Col1 = "12";
            this.cbMonth.Items.AddRange(new object[] {
            myItem3,
            myItem4,
            myItem5,
            myItem6,
            myItem7,
            myItem8,
            myItem9,
            myItem10,
            myItem11,
            myItem12,
            myItem13,
            myItem14});
            this.cbMonth.ItemStrings = new string[] {
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
        "12"};
            this.cbMonth.Location = new System.Drawing.Point(236, 36);
            this.cbMonth.Margin = new System.Windows.Forms.Padding(2);
            this.cbMonth.MaxDropDownItems = 12;
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(63, 23);
            this.cbMonth.TabIndex = 1;
            this.cbMonth.ValueMember = "col1";
            this.cbMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // tbPageNr
            // 
            this.tbPageNr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbPageNr.Location = new System.Drawing.Point(151, 81);
            this.tbPageNr.Margin = new System.Windows.Forms.Padding(2);
            this.tbPageNr.Name = "tbPageNr";
            this.tbPageNr.Size = new System.Drawing.Size(60, 22);
            this.tbPageNr.TabIndex = 2;
            this.tbPageNr.Text = "1";
            this.tbPageNr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // tbRowNr
            // 
            this.tbRowNr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRowNr.Location = new System.Drawing.Point(151, 117);
            this.tbRowNr.Margin = new System.Windows.Forms.Padding(2);
            this.tbRowNr.Name = "tbRowNr";
            this.tbRowNr.Size = new System.Drawing.Size(60, 22);
            this.tbRowNr.TabIndex = 3;
            this.tbRowNr.Text = "1";
            this.tbRowNr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pirmās lapas nr.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pirmā ieraksta nr.:";
            // 
            // FormRep_PVNZ1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 214);
            this.CloseOnEscape = true;
            this.Controls.Add(this.tbRowNr);
            this.Controls.Add(this.tbPageNr);
            this.Controls.Add(this.cbMonth);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.cmDoIt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormRep_PVNZ1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PVN žurnāls";
            this.Load += new System.EventHandler(this.FormRepApgr1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingSource bsAC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmDoIt;
        private MyMcFlatComboBox cbYear;
        private System.Windows.Forms.Label label2;
        private MyMcFlatComboBox cbMonth;
        private MyTextBox tbPageNr;
        private MyTextBox tbRowNr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}