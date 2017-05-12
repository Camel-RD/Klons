using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.FormsReportParams
{
    partial class FormRep_KasesGr
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
            this.cbAC = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsAC = new KlonsLIB.Data.MyBindingSource();
            this.tbSD = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbED = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbACName = new System.Windows.Forms.Label();
            this.cmDoIt = new System.Windows.Forms.Button();
            this.bsClid = new KlonsLIB.Data.MyBindingSource();
            this.lbCm = new System.Windows.Forms.ListBox();
            this.tbNr = new KlonsLIB.Components.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmNrKIEO = new System.Windows.Forms.Button();
            this.cmNrKIZO = new System.Windows.Forms.Button();
            this.tbNr2 = new KlonsLIB.Components.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClid)).BeginInit();
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
            this.cbAC.Location = new System.Drawing.Point(143, 53);
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
            this.tbSD.Location = new System.Drawing.Point(143, 19);
            this.tbSD.Margin = new System.Windows.Forms.Padding(2);
            this.tbSD.Name = "tbSD";
            this.tbSD.Size = new System.Drawing.Size(80, 22);
            this.tbSD.TabIndex = 0;
            this.tbSD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Datums (no - līdz):";
            // 
            // tbED
            // 
            this.tbED.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbED.IsDate = true;
            this.tbED.Location = new System.Drawing.Point(228, 19);
            this.tbED.Margin = new System.Windows.Forms.Padding(2);
            this.tbED.Name = "tbED";
            this.tbED.Size = new System.Drawing.Size(80, 22);
            this.tbED.TabIndex = 1;
            this.tbED.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Konts:";
            // 
            // lbACName
            // 
            this.lbACName.Location = new System.Drawing.Point(251, 55);
            this.lbACName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbACName.Name = "lbACName";
            this.lbACName.Size = new System.Drawing.Size(334, 18);
            this.lbACName.TabIndex = 11;
            this.lbACName.Text = "Konts:";
            // 
            // cmDoIt
            // 
            this.cmDoIt.Location = new System.Drawing.Point(305, 146);
            this.cmDoIt.Margin = new System.Windows.Forms.Padding(2);
            this.cmDoIt.Name = "cmDoIt";
            this.cmDoIt.Size = new System.Drawing.Size(133, 63);
            this.cmDoIt.TabIndex = 4;
            this.cmDoIt.Text = "Taisīt atskaiti";
            this.cmDoIt.UseVisualStyleBackColor = true;
            this.cmDoIt.Click += new System.EventHandler(this.cmDoIt_Click);
            this.cmDoIt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // bsClid
            // 
            this.bsClid.DataMember = "Persons";
            this.bsClid.MyDataSource = "KlonsData";
            this.bsClid.Name2 = "bsClid";
            // 
            // lbCm
            // 
            this.lbCm.BackColor = System.Drawing.SystemColors.Control;
            this.lbCm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCm.FormattingEnabled = true;
            this.lbCm.ItemHeight = 16;
            this.lbCm.Items.AddRange(new object[] {
            "Kases grāmata",
            "Kases grāmata, visas dienas kopā",
            "Ieņēmumu orderi",
            "Izdevumu orderi"});
            this.lbCm.Location = new System.Drawing.Point(13, 128);
            this.lbCm.Margin = new System.Windows.Forms.Padding(2);
            this.lbCm.Name = "lbCm";
            this.lbCm.Size = new System.Drawing.Size(257, 82);
            this.lbCm.TabIndex = 3;
            this.lbCm.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCm_MouseDoubleClick);
            // 
            // tbNr
            // 
            this.tbNr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbNr.Location = new System.Drawing.Point(266, 91);
            this.tbNr.Margin = new System.Windows.Forms.Padding(2);
            this.tbNr.Name = "tbNr";
            this.tbNr.Size = new System.Drawing.Size(72, 22);
            this.tbNr.TabIndex = 5;
            this.tbNr.Text = "1";
            this.tbNr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Kases grāmatas pirmās lapas numurs:";
            // 
            // cmNrKIEO
            // 
            this.cmNrKIEO.Location = new System.Drawing.Point(13, 255);
            this.cmNrKIEO.Margin = new System.Windows.Forms.Padding(2);
            this.cmNrKIEO.Name = "cmNrKIEO";
            this.cmNrKIEO.Size = new System.Drawing.Size(133, 63);
            this.cmNrKIEO.TabIndex = 7;
            this.cmNrKIEO.Text = "Pārnumuret kases ieņēmumu orderus";
            this.cmNrKIEO.UseVisualStyleBackColor = true;
            this.cmNrKIEO.Click += new System.EventHandler(this.cmNrKIEO_Click);
            this.cmNrKIEO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // cmNrKIZO
            // 
            this.cmNrKIZO.Location = new System.Drawing.Point(158, 255);
            this.cmNrKIZO.Margin = new System.Windows.Forms.Padding(2);
            this.cmNrKIZO.Name = "cmNrKIZO";
            this.cmNrKIZO.Size = new System.Drawing.Size(133, 63);
            this.cmNrKIZO.TabIndex = 8;
            this.cmNrKIZO.Text = "Pārnumurēt kases izdevumu orderus";
            this.cmNrKIZO.UseVisualStyleBackColor = true;
            this.cmNrKIZO.Click += new System.EventHandler(this.cmNrKIZO_Click);
            this.cmNrKIZO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // tbNr2
            // 
            this.tbNr2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbNr2.Location = new System.Drawing.Point(150, 225);
            this.tbNr2.Margin = new System.Windows.Forms.Padding(2);
            this.tbNr2.Name = "tbNr2";
            this.tbNr2.Size = new System.Drawing.Size(72, 22);
            this.tbNr2.TabIndex = 6;
            this.tbNr2.Text = "1";
            this.tbNr2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 226);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Numerāciju sākt ar:";
            // 
            // FormRep_KasesGr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 330);
            this.CloseOnEscape = true;
            this.Controls.Add(this.lbCm);
            this.Controls.Add(this.cmNrKIZO);
            this.Controls.Add(this.cmNrKIEO);
            this.Controls.Add(this.cmDoIt);
            this.Controls.Add(this.lbACName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbED);
            this.Controls.Add(this.tbNr2);
            this.Controls.Add(this.tbNr);
            this.Controls.Add(this.tbSD);
            this.Controls.Add(this.cbAC);
            this.Name = "FormRep_KasesGr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kases grāmata";
            this.Load += new System.EventHandler(this.FormRepKoresp1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClid)).EndInit();
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
        private MyBindingSource bsClid;
        private System.Windows.Forms.ListBox lbCm;
        private MyTextBox tbNr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmNrKIEO;
        private System.Windows.Forms.Button cmNrKIZO;
        private MyTextBox tbNr2;
        private System.Windows.Forms.Label label3;
    }
}