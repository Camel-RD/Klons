using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.FormsReportParams
{
    partial class FormRep_RekinsPZ1
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
            this.cmDoIt = new System.Windows.Forms.Button();
            this.tbSigner = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbClName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbClid = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsClid = new KlonsLIB.Data.MyBindingSource();
            this.cbDarVeids = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbApmaksa = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTermins = new KlonsLIB.Components.MyMcFlatComboBox();
            this.tbTLNumurs = new KlonsLIB.Components.MyTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTLVaditajs = new KlonsLIB.Components.MyTextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsClid)).BeginInit();
            this.SuspendLayout();
            // 
            // cmDoIt
            // 
            this.cmDoIt.Location = new System.Drawing.Point(313, 174);
            this.cmDoIt.Margin = new System.Windows.Forms.Padding(2);
            this.cmDoIt.Name = "cmDoIt";
            this.cmDoIt.Size = new System.Drawing.Size(102, 52);
            this.cmDoIt.TabIndex = 2;
            this.cmDoIt.Text = "Sagatavot pavadzīmi";
            this.cmDoIt.UseVisualStyleBackColor = true;
            this.cmDoIt.Click += new System.EventHandler(this.cmDoIt_Click);
            this.cmDoIt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // tbSigner
            // 
            this.tbSigner.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSigner.Location = new System.Drawing.Point(98, 190);
            this.tbSigner.Margin = new System.Windows.Forms.Padding(2);
            this.tbSigner.Name = "tbSigner";
            this.tbSigner.Size = new System.Drawing.Size(183, 22);
            this.tbSigner.TabIndex = 1;
            this.tbSigner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 191);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Izrakstītāks:";
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(431, 174);
            this.cmCancel.Margin = new System.Windows.Forms.Padding(2);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(102, 52);
            this.cmCancel.TabIndex = 2;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            this.cmCancel.Click += new System.EventHandler(this.cmCancel_Click);
            this.cmCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 234);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 63);
            this.label1.TabIndex = 5;
            this.label1.Text = "  Lai rēķinā pie daudzumiem parādītos mērvienības, kontējuma parakstam jāsākas ar" +
    " atbilstošās mērvienības apzīmējumu un simbolu ~.\r\n  Piemēram: kg~Kartupeļi";
            // 
            // lbClName
            // 
            this.lbClName.Location = new System.Drawing.Point(230, 18);
            this.lbClName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbClName.Name = "lbClName";
            this.lbClName.Size = new System.Drawing.Size(304, 18);
            this.lbClName.TabIndex = 14;
            this.lbClName.Text = "Konts:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Pārvadātājs:";
            // 
            // cbClid
            // 
            this.cbClid.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbClid.ColumnNames = new string[] {
        "clid",
        "name"};
            this.cbClid.ColumnWidths = "120;300";
            this.cbClid.DataSource = this.bsClid;
            this.cbClid.DisplayMember = "clid";
            this.cbClid.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbClid.DropDownHeight = 255;
            this.cbClid.DropDownWidth = 444;
            this.cbClid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbClid.FormattingEnabled = true;
            this.cbClid.GridLineColor = System.Drawing.Color.LightGray;
            this.cbClid.GridLineHorizontal = false;
            this.cbClid.GridLineVertical = false;
            this.cbClid.IntegralHeight = false;
            this.cbClid.Location = new System.Drawing.Point(99, 16);
            this.cbClid.Margin = new System.Windows.Forms.Padding(2);
            this.cbClid.MaxDropDownItems = 15;
            this.cbClid.Name = "cbClid";
            this.cbClid.Size = new System.Drawing.Size(126, 23);
            this.cbClid.TabIndex = 12;
            this.cbClid.ValueMember = "clid";
            this.cbClid.TextChanged += new System.EventHandler(this.cbClid_TextChanged);
            this.cbClid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.cbClid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbClid_MouseDoubleClick);
            // 
            // bsClid
            // 
            this.bsClid.DataMember = "Persons";
            this.bsClid.MyDataSource = "KlonsData";
            this.bsClid.Name2 = null;
            // 
            // cbDarVeids
            // 
            this.cbDarVeids.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbDarVeids.ColumnNames = new string[] {
        "col1"};
            this.cbDarVeids.ColumnWidths = "400";
            this.cbDarVeids.DisplayMember = "col1";
            this.cbDarVeids.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDarVeids.DropDownHeight = 255;
            this.cbDarVeids.DropDownWidth = 424;
            this.cbDarVeids.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDarVeids.FormattingEnabled = true;
            this.cbDarVeids.GridLineColor = System.Drawing.Color.LightGray;
            this.cbDarVeids.GridLineHorizontal = false;
            this.cbDarVeids.GridLineVertical = false;
            this.cbDarVeids.IntegralHeight = false;
            myItem1.Col1 = "preču piegāde";
            myItem2.Col1 = "izsniegšana citam nodokļu maksātājam";
            myItem3.Col1 = "preču piegāde saskaņā ar PVN likuma 141 pantu";
            this.cbDarVeids.Items.AddRange(new object[] {
            myItem1,
            myItem2,
            myItem3});
            this.cbDarVeids.ItemStrings = new string[] {
        "preču piegāde",
        "izsniegšana citam nodokļu maksātājam",
        "preču piegāde saskaņā ar PVN likuma 141 pantu"};
            this.cbDarVeids.Location = new System.Drawing.Point(123, 102);
            this.cbDarVeids.Margin = new System.Windows.Forms.Padding(2);
            this.cbDarVeids.MaxDropDownItems = 15;
            this.cbDarVeids.Name = "cbDarVeids";
            this.cbDarVeids.Size = new System.Drawing.Size(291, 23);
            this.cbDarVeids.TabIndex = 12;
            this.cbDarVeids.ValueMember = "col1";
            this.cbDarVeids.TextChanged += new System.EventHandler(this.cbClid_TextChanged);
            this.cbDarVeids.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.cbDarVeids.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbClid_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Darijuma veids:";
            // 
            // cbApmaksa
            // 
            this.cbApmaksa.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbApmaksa.ColumnNames = new string[] {
        "col1"};
            this.cbApmaksa.ColumnWidths = "400";
            this.cbApmaksa.DisplayMember = "col1";
            this.cbApmaksa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbApmaksa.DropDownHeight = 255;
            this.cbApmaksa.DropDownWidth = 424;
            this.cbApmaksa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbApmaksa.FormattingEnabled = true;
            this.cbApmaksa.GridLineColor = System.Drawing.Color.LightGray;
            this.cbApmaksa.GridLineHorizontal = false;
            this.cbApmaksa.GridLineVertical = false;
            this.cbApmaksa.IntegralHeight = false;
            myItem4.Col1 = "ar pārskaitijumu";
            myItem5.Col1 = "tulītēja apmaksa";
            this.cbApmaksa.Items.AddRange(new object[] {
            myItem4,
            myItem5});
            this.cbApmaksa.ItemStrings = new string[] {
        "ar pārskaitijumu",
        "tulītēja apmaksa"};
            this.cbApmaksa.Location = new System.Drawing.Point(130, 131);
            this.cbApmaksa.Margin = new System.Windows.Forms.Padding(2);
            this.cbApmaksa.MaxDropDownItems = 15;
            this.cbApmaksa.Name = "cbApmaksa";
            this.cbApmaksa.Size = new System.Drawing.Size(234, 23);
            this.cbApmaksa.TabIndex = 12;
            this.cbApmaksa.ValueMember = "col1";
            this.cbApmaksa.TextChanged += new System.EventHandler(this.cbClid_TextChanged);
            this.cbApmaksa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.cbApmaksa.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbClid_MouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Apmaksas veids:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 162);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Apmaksas termiņš:";
            // 
            // cbTermins
            // 
            this.cbTermins.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbTermins.ColumnNames = new string[] {
        "col1"};
            this.cbTermins.ColumnWidths = "120;300";
            this.cbTermins.DisplayMember = "col1";
            this.cbTermins.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTermins.DropDownHeight = 255;
            this.cbTermins.DropDownWidth = 144;
            this.cbTermins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTermins.FormattingEnabled = true;
            this.cbTermins.GridLineColor = System.Drawing.Color.LightGray;
            this.cbTermins.GridLineHorizontal = false;
            this.cbTermins.GridLineVertical = false;
            this.cbTermins.IntegralHeight = false;
            myItem6.Col1 = "10 dienas";
            myItem7.Col1 = "15 dienas";
            myItem8.Col1 = "20 dienas";
            myItem9.Col1 = "30 dienas";
            myItem10.Col1 = "45 dienas";
            myItem11.Col1 = "60 dienas";
            this.cbTermins.Items.AddRange(new object[] {
            myItem6,
            myItem7,
            myItem8,
            myItem9,
            myItem10,
            myItem11});
            this.cbTermins.ItemStrings = new string[] {
        "10 dienas",
        "15 dienas",
        "20 dienas",
        "30 dienas",
        "45 dienas",
        "60 dienas"};
            this.cbTermins.Location = new System.Drawing.Point(142, 160);
            this.cbTermins.Margin = new System.Windows.Forms.Padding(2);
            this.cbTermins.MaxDropDownItems = 15;
            this.cbTermins.Name = "cbTermins";
            this.cbTermins.Size = new System.Drawing.Size(139, 23);
            this.cbTermins.TabIndex = 12;
            this.cbTermins.ValueMember = "col1";
            this.cbTermins.TextChanged += new System.EventHandler(this.cbClid_TextChanged);
            this.cbTermins.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            this.cbTermins.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cbClid_MouseDoubleClick);
            // 
            // tbTLNumurs
            // 
            this.tbTLNumurs.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbTLNumurs.Location = new System.Drawing.Point(186, 46);
            this.tbTLNumurs.Margin = new System.Windows.Forms.Padding(2);
            this.tbTLNumurs.Name = "tbTLNumurs";
            this.tbTLNumurs.Size = new System.Drawing.Size(152, 22);
            this.tbTLNumurs.TabIndex = 1;
            this.tbTLNumurs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Transportlīdzekļa numurs:";
            // 
            // tbTLVaditajs
            // 
            this.tbTLVaditajs.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbTLVaditajs.Location = new System.Drawing.Point(286, 74);
            this.tbTLVaditajs.Margin = new System.Windows.Forms.Padding(2);
            this.tbTLVaditajs.Name = "tbTLVaditajs";
            this.tbTLVaditajs.Size = new System.Drawing.Size(152, 22);
            this.tbTLVaditajs.TabIndex = 1;
            this.tbTLVaditajs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 76);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(256, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Transportlīdzekļa vadītāja vārds, uzvārds:";
            // 
            // FormRep_RekinsPZ1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 302);
            this.CloseOnEscape = true;
            this.Controls.Add(this.lbClName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTermins);
            this.Controls.Add(this.cbApmaksa);
            this.Controls.Add(this.cbDarVeids);
            this.Controls.Add(this.cbClid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbTLVaditajs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTLNumurs);
            this.Controls.Add(this.tbSigner);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmDoIt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRep_RekinsPZ1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Izrakstam pavadzīmi";
            this.Load += new System.EventHandler(this.FormRep_RekinsPZ1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsClid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmDoIt;
        private MyTextBox tbSigner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbClName;
        private System.Windows.Forms.Label label3;
        private MyMcFlatComboBox cbClid;
        private MyMcFlatComboBox cbDarVeids;
        private System.Windows.Forms.Label label4;
        private MyMcFlatComboBox cbApmaksa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private MyMcFlatComboBox cbTermins;
        private MyTextBox tbTLNumurs;
        private System.Windows.Forms.Label label7;
        private MyTextBox tbTLVaditajs;
        private System.Windows.Forms.Label label8;
        private MyBindingSource bsClid;
    }
}