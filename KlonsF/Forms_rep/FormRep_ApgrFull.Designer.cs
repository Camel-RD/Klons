using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.FormsReportParams
{
    partial class FormRep_ApgrFull
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
            this.cbAC1 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsAC1 = new KlonsLIB.Data.MyBindingSource();
            this.tbSD = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbED = new KlonsLIB.Components.MyTextBox();
            this.cmDoIt = new System.Windows.Forms.Button();
            this.cbAC2 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsAC2 = new KlonsLIB.Data.MyBindingSource();
            this.cbAC3 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsAC3 = new KlonsLIB.Data.MyBindingSource();
            this.cbAC4 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsAC4 = new KlonsLIB.Data.MyBindingSource();
            this.cbAC5 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsAC5 = new KlonsLIB.Data.MyBindingSource();
            this.cbClid = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsClid = new KlonsLIB.Data.MyBindingSource();
            this.myLabel1 = new KlonsLIB.Components.MyLabel();
            this.chAC1 = new System.Windows.Forms.CheckBox();
            this.chAC2 = new System.Windows.Forms.CheckBox();
            this.chAC3 = new System.Windows.Forms.CheckBox();
            this.chAC4 = new System.Windows.Forms.CheckBox();
            this.chAC5 = new System.Windows.Forms.CheckBox();
            this.chCl = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClid)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAC1
            // 
            this.cbAC1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC1.ColumnNames = new string[] {
        "ac",
        "name"};
            this.cbAC1.ColumnWidths = "80;300";
            this.cbAC1.DataSource = this.bsAC1;
            this.cbAC1.DisplayMember = "AC";
            this.cbAC1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC1.DropDownHeight = 255;
            this.cbAC1.DropDownWidth = 404;
            this.cbAC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC1.FormattingEnabled = true;
            this.cbAC1.GridLineColor = System.Drawing.Color.LightGray;
            this.cbAC1.GridLineHorizontal = false;
            this.cbAC1.GridLineVertical = false;
            this.cbAC1.IntegralHeight = false;
            this.cbAC1.Location = new System.Drawing.Point(43, 63);
            this.cbAC1.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC1.MaxDropDownItems = 15;
            this.cbAC1.Name = "cbAC1";
            this.cbAC1.Size = new System.Drawing.Size(104, 23);
            this.cbAC1.TabIndex = 2;
            this.cbAC1.ValueMember = "AC";
            this.cbAC1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.cbAC1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbAC_MouseDoubleClick);
            // 
            // bsAC1
            // 
            this.bsAC1.DataMember = "AcP21";
            this.bsAC1.MyDataSource = "KlonsData";
            this.bsAC1.Name2 = "bsAC1";
            // 
            // tbSD
            // 
            this.tbSD.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSD.IsDate = true;
            this.tbSD.Location = new System.Drawing.Point(156, 20);
            this.tbSD.Margin = new System.Windows.Forms.Padding(2);
            this.tbSD.Name = "tbSD";
            this.tbSD.Size = new System.Drawing.Size(80, 22);
            this.tbSD.TabIndex = 0;
            this.tbSD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Datums (no - līdz):";
            // 
            // tbED
            // 
            this.tbED.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbED.IsDate = true;
            this.tbED.Location = new System.Drawing.Point(242, 20);
            this.tbED.Margin = new System.Windows.Forms.Padding(2);
            this.tbED.Name = "tbED";
            this.tbED.Size = new System.Drawing.Size(80, 22);
            this.tbED.TabIndex = 1;
            this.tbED.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // cmDoIt
            // 
            this.cmDoIt.Location = new System.Drawing.Point(339, 240);
            this.cmDoIt.Margin = new System.Windows.Forms.Padding(2);
            this.cmDoIt.Name = "cmDoIt";
            this.cmDoIt.Size = new System.Drawing.Size(133, 63);
            this.cmDoIt.TabIndex = 14;
            this.cmDoIt.Text = "Taisīt atskaiti";
            this.cmDoIt.UseVisualStyleBackColor = true;
            this.cmDoIt.Click += new System.EventHandler(this.cmDoIt_Click);
            this.cmDoIt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // cbAC2
            // 
            this.cbAC2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC2.ColumnNames = new string[] {
        "ac",
        "name"};
            this.cbAC2.ColumnWidths = "80;300";
            this.cbAC2.DataSource = this.bsAC2;
            this.cbAC2.DisplayMember = "AC";
            this.cbAC2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC2.DropDownHeight = 255;
            this.cbAC2.DropDownWidth = 404;
            this.cbAC2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC2.FormattingEnabled = true;
            this.cbAC2.GridLineColor = System.Drawing.Color.LightGray;
            this.cbAC2.GridLineHorizontal = false;
            this.cbAC2.GridLineVertical = false;
            this.cbAC2.IntegralHeight = false;
            this.cbAC2.Location = new System.Drawing.Point(43, 90);
            this.cbAC2.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC2.MaxDropDownItems = 15;
            this.cbAC2.Name = "cbAC2";
            this.cbAC2.Size = new System.Drawing.Size(104, 23);
            this.cbAC2.TabIndex = 4;
            this.cbAC2.ValueMember = "AC";
            this.cbAC2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.cbAC2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbAC_MouseDoubleClick);
            // 
            // bsAC2
            // 
            this.bsAC2.DataMember = "AcP21";
            this.bsAC2.MyDataSource = "KlonsData";
            this.bsAC2.Name2 = "bsAC2";
            // 
            // cbAC3
            // 
            this.cbAC3.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC3.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbAC3.ColumnWidths = "80;300";
            this.cbAC3.DataSource = this.bsAC3;
            this.cbAC3.DisplayMember = "idx";
            this.cbAC3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC3.DropDownHeight = 255;
            this.cbAC3.DropDownWidth = 404;
            this.cbAC3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC3.FormattingEnabled = true;
            this.cbAC3.GridLineColor = System.Drawing.Color.LightGray;
            this.cbAC3.GridLineHorizontal = false;
            this.cbAC3.GridLineVertical = false;
            this.cbAC3.IntegralHeight = false;
            this.cbAC3.Location = new System.Drawing.Point(43, 118);
            this.cbAC3.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC3.MaxDropDownItems = 15;
            this.cbAC3.Name = "cbAC3";
            this.cbAC3.Size = new System.Drawing.Size(104, 23);
            this.cbAC3.TabIndex = 6;
            this.cbAC3.ValueMember = "idx";
            this.cbAC3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.cbAC3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbAC_MouseDoubleClick);
            // 
            // bsAC3
            // 
            this.bsAC3.DataMember = "Acp23";
            this.bsAC3.MyDataSource = "KlonsData";
            this.bsAC3.Name2 = "bsAC3";
            // 
            // cbAC4
            // 
            this.cbAC4.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC4.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbAC4.ColumnWidths = "80;300";
            this.cbAC4.DataSource = this.bsAC4;
            this.cbAC4.DisplayMember = "idx";
            this.cbAC4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC4.DropDownHeight = 255;
            this.cbAC4.DropDownWidth = 404;
            this.cbAC4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC4.FormattingEnabled = true;
            this.cbAC4.GridLineColor = System.Drawing.Color.LightGray;
            this.cbAC4.GridLineHorizontal = false;
            this.cbAC4.GridLineVertical = false;
            this.cbAC4.IntegralHeight = false;
            this.cbAC4.Location = new System.Drawing.Point(43, 145);
            this.cbAC4.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC4.MaxDropDownItems = 15;
            this.cbAC4.Name = "cbAC4";
            this.cbAC4.Size = new System.Drawing.Size(104, 23);
            this.cbAC4.TabIndex = 8;
            this.cbAC4.ValueMember = "idx";
            this.cbAC4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.cbAC4.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbAC_MouseDoubleClick);
            // 
            // bsAC4
            // 
            this.bsAC4.DataMember = "AcP24";
            this.bsAC4.MyDataSource = "KlonsData";
            this.bsAC4.Name2 = "bsAC4";
            // 
            // cbAC5
            // 
            this.cbAC5.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAC5.ColumnNames = new string[] {
        "idx",
        "name"};
            this.cbAC5.ColumnWidths = "80;300";
            this.cbAC5.DataSource = this.bsAC5;
            this.cbAC5.DisplayMember = "idx";
            this.cbAC5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAC5.DropDownHeight = 255;
            this.cbAC5.DropDownWidth = 404;
            this.cbAC5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAC5.FormattingEnabled = true;
            this.cbAC5.GridLineColor = System.Drawing.Color.LightGray;
            this.cbAC5.GridLineHorizontal = false;
            this.cbAC5.GridLineVertical = false;
            this.cbAC5.IntegralHeight = false;
            this.cbAC5.Location = new System.Drawing.Point(43, 172);
            this.cbAC5.Margin = new System.Windows.Forms.Padding(2);
            this.cbAC5.MaxDropDownItems = 15;
            this.cbAC5.Name = "cbAC5";
            this.cbAC5.Size = new System.Drawing.Size(104, 23);
            this.cbAC5.TabIndex = 10;
            this.cbAC5.ValueMember = "idx";
            this.cbAC5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.cbAC5.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbAC_MouseDoubleClick);
            // 
            // bsAC5
            // 
            this.bsAC5.DataMember = "Acp25";
            this.bsAC5.MyDataSource = "KlonsData";
            this.bsAC5.Name2 = "bsAC5";
            // 
            // cbClid
            // 
            this.cbClid.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbClid.ColumnNames = new string[] {
        "clid",
        "name"};
            this.cbClid.ColumnWidths = "120;300";
            this.cbClid.DataSource = this.bsClid;
            this.cbClid.DisplayMember = "ClId";
            this.cbClid.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbClid.DropDownHeight = 255;
            this.cbClid.DropDownWidth = 444;
            this.cbClid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbClid.FormattingEnabled = true;
            this.cbClid.GridLineColor = System.Drawing.Color.LightGray;
            this.cbClid.GridLineHorizontal = false;
            this.cbClid.GridLineVertical = false;
            this.cbClid.IntegralHeight = false;
            this.cbClid.Location = new System.Drawing.Point(43, 199);
            this.cbClid.Margin = new System.Windows.Forms.Padding(2);
            this.cbClid.MaxDropDownItems = 15;
            this.cbClid.Name = "cbClid";
            this.cbClid.Size = new System.Drawing.Size(104, 23);
            this.cbClid.TabIndex = 12;
            this.cbClid.ValueMember = "ClId";
            this.cbClid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.cbClid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbAC_MouseDoubleClick);
            // 
            // bsClid
            // 
            this.bsClid.DataMember = "Persons";
            this.bsClid.MyDataSource = "KlonsData";
            this.bsClid.Name2 = "bsClid";
            // 
            // myLabel1
            // 
            this.myLabel1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.myLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myLabel1.Location = new System.Drawing.Point(9, 240);
            this.myLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.Padding = new System.Windows.Forms.Padding(2);
            this.myLabel1.Size = new System.Drawing.Size(308, 70);
            this.myLabel1.TabIndex = 16;
            this.myLabel1.Text = "Kontējuma pazīmju filtrēšanai var izmantot *.\r\nPazīmes ignorēšanai ievades lauku " +
    "atstājam tukšu.";
            // 
            // chAC1
            // 
            this.chAC1.AutoSize = true;
            this.chAC1.Checked = true;
            this.chAC1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chAC1.Location = new System.Drawing.Point(156, 64);
            this.chAC1.Margin = new System.Windows.Forms.Padding(2);
            this.chAC1.Name = "chAC1";
            this.chAC1.Size = new System.Drawing.Size(117, 20);
            this.chAC1.TabIndex = 3;
            this.chAC1.Text = "Bilances konts";
            this.chAC1.UseVisualStyleBackColor = true;
            // 
            // chAC2
            // 
            this.chAC2.AutoSize = true;
            this.chAC2.Location = new System.Drawing.Point(156, 91);
            this.chAC2.Margin = new System.Windows.Forms.Padding(2);
            this.chAC2.Name = "chAC2";
            this.chAC2.Size = new System.Drawing.Size(167, 20);
            this.chAC2.TabIndex = 5;
            this.chAC2.Text = "Naudas plūsmas konts";
            this.chAC2.UseVisualStyleBackColor = true;
            // 
            // chAC3
            // 
            this.chAC3.AutoSize = true;
            this.chAC3.Location = new System.Drawing.Point(156, 118);
            this.chAC3.Margin = new System.Windows.Forms.Padding(2);
            this.chAC3.Name = "chAC3";
            this.chAC3.Size = new System.Drawing.Size(211, 20);
            this.chAC3.TabIndex = 7;
            this.chAC3.Text = "IIN ieņēmumu / izdevumu kods";
            this.chAC3.UseVisualStyleBackColor = true;
            // 
            // chAC4
            // 
            this.chAC4.AutoSize = true;
            this.chAC4.Location = new System.Drawing.Point(156, 146);
            this.chAC4.Margin = new System.Windows.Forms.Padding(2);
            this.chAC4.Name = "chAC4";
            this.chAC4.Size = new System.Drawing.Size(136, 20);
            this.chAC4.TabIndex = 9;
            this.chAC4.Text = "Nozare / produkts";
            this.chAC4.UseVisualStyleBackColor = true;
            // 
            // chAC5
            // 
            this.chAC5.AutoSize = true;
            this.chAC5.Checked = true;
            this.chAC5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chAC5.Location = new System.Drawing.Point(156, 173);
            this.chAC5.Margin = new System.Windows.Forms.Padding(2);
            this.chAC5.Name = "chAC5";
            this.chAC5.Size = new System.Drawing.Size(91, 20);
            this.chAC5.TabIndex = 11;
            this.chAC5.Text = "PVN kods";
            this.chAC5.UseVisualStyleBackColor = true;
            // 
            // chCl
            // 
            this.chCl.AutoSize = true;
            this.chCl.Location = new System.Drawing.Point(157, 200);
            this.chCl.Margin = new System.Windows.Forms.Padding(2);
            this.chCl.Name = "chCl";
            this.chCl.Size = new System.Drawing.Size(81, 20);
            this.chCl.TabIndex = 13;
            this.chCl.Text = "Persona";
            this.chCl.UseVisualStyleBackColor = true;
            // 
            // FormRep_ApgrFull
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 316);
            this.CloseOnEscape = true;
            this.Controls.Add(this.chCl);
            this.Controls.Add(this.chAC5);
            this.Controls.Add(this.chAC4);
            this.Controls.Add(this.chAC3);
            this.Controls.Add(this.chAC2);
            this.Controls.Add(this.chAC1);
            this.Controls.Add(this.myLabel1);
            this.Controls.Add(this.cmDoIt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbED);
            this.Controls.Add(this.tbSD);
            this.Controls.Add(this.cbClid);
            this.Controls.Add(this.cbAC5);
            this.Controls.Add(this.cbAC4);
            this.Controls.Add(this.cbAC3);
            this.Controls.Add(this.cbAC2);
            this.Controls.Add(this.cbAC1);
            this.Name = "FormRep_ApgrFull";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apgrozijumu pārskata parametri";
            this.Load += new System.EventHandler(this.FormRepApgr1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsAC1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyMcFlatComboBox cbAC1;
        private MyBindingSource bsAC1;
        private MyTextBox tbSD;
        private System.Windows.Forms.Label label1;
        private MyTextBox tbED;
        private System.Windows.Forms.Button cmDoIt;
        private MyMcFlatComboBox cbAC2;
        private MyMcFlatComboBox cbAC3;
        private MyMcFlatComboBox cbAC4;
        private MyMcFlatComboBox cbAC5;
        private MyMcFlatComboBox cbClid;
        private MyBindingSource bsAC2;
        private MyBindingSource bsAC3;
        private MyBindingSource bsAC4;
        private MyBindingSource bsAC5;
        private MyBindingSource bsClid;
        private MyLabel myLabel1;
        private System.Windows.Forms.CheckBox chAC1;
        private System.Windows.Forms.CheckBox chAC2;
        private System.Windows.Forms.CheckBox chAC3;
        private System.Windows.Forms.CheckBox chAC4;
        private System.Windows.Forms.CheckBox chAC5;
        private System.Windows.Forms.CheckBox chCl;
    }
}