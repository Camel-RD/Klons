namespace KlonsP.Forms
{
    partial class Form_Items_New
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbRegNr = new KlonsLIB.Components.MyTextBox();
            this.bsItem = new KlonsLIB.Data.MyBindingSourceToObj(this.components);
            this.itemsEventsData1 = new DataObjectsP.ItemsEventsData();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new KlonsLIB.Components.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDate = new KlonsLIB.Components.MyTextBox();
            this.chAddEvent = new System.Windows.Forms.CheckBox();
            this.cbCat1 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsCat1 = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cbCatD = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsCatD = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cbCatT = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsCatT = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cbDep = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsDep = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cbPlace = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsPlace = new KlonsLIB.Data.MyBindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbValue = new KlonsLIB.Components.MyTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbDocNr = new KlonsLIB.Components.MyTextBox();
            this.cmOK = new System.Windows.Forms.Button();
            this.cmCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCatD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCatT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlace)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Reģ.nr.:";
            // 
            // tbRegNr
            // 
            this.tbRegNr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRegNr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItem, "fITEM_REG_NR", true));
            this.tbRegNr.Location = new System.Drawing.Point(135, 7);
            this.tbRegNr.MaxLength = 20;
            this.tbRegNr.Name = "tbRegNr";
            this.tbRegNr.Size = new System.Drawing.Size(80, 22);
            this.tbRegNr.TabIndex = 0;
            this.tbRegNr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // bsItem
            // 
            this.bsItem.MyDataSource = this.itemsEventsData1;
            this.bsItem.Position = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nosaukums:";
            // 
            // tbName
            // 
            this.tbName.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItem, "fITEM_NAME", true));
            this.tbName.Location = new System.Drawing.Point(135, 37);
            this.tbName.MaxLength = 150;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(248, 22);
            this.tbName.TabIndex = 1;
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Iegādes datums:";
            // 
            // tbDate
            // 
            this.tbDate.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItem, "fDT", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "dd.MM.yyyy"));
            this.tbDate.IsDate = true;
            this.tbDate.Location = new System.Drawing.Point(135, 101);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(80, 22);
            this.tbDate.TabIndex = 3;
            this.tbDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // chAddEvent
            // 
            this.chAddEvent.AutoSize = true;
            this.chAddEvent.Checked = true;
            this.chAddEvent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chAddEvent.Location = new System.Drawing.Point(12, 75);
            this.chAddEvent.Name = "chAddEvent";
            this.chAddEvent.Size = new System.Drawing.Size(356, 20);
            this.chAddEvent.TabIndex = 2;
            this.chAddEvent.Text = "Izveidot iegādes un nodošanas ekspluatācijā notikumu";
            this.chAddEvent.UseVisualStyleBackColor = true;
            this.chAddEvent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // cbCat1
            // 
            this.cbCat1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbCat1.ColumnNames = new string[] {
        "CODE",
        "DESCR"};
            this.cbCat1.ColumnWidths = "100;300";
            this.cbCat1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsItem, "fCAT1", true));
            this.cbCat1.DataSource = this.bsCat1;
            this.cbCat1.DisplayMember = "CODE";
            this.cbCat1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCat1.DropDownHeight = 255;
            this.cbCat1.DropDownWidth = 424;
            this.cbCat1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCat1.FormattingEnabled = true;
            this.cbCat1.GridLineColor = System.Drawing.Color.LightGray;
            this.cbCat1.GridLineHorizontal = false;
            this.cbCat1.GridLineVertical = false;
            this.cbCat1.IntegralHeight = false;
            this.cbCat1.Location = new System.Drawing.Point(458, 104);
            this.cbCat1.MaxDropDownItems = 15;
            this.cbCat1.Name = "cbCat1";
            this.cbCat1.Size = new System.Drawing.Size(121, 23);
            this.cbCat1.TabIndex = 4;
            this.cbCat1.ValueMember = "ID";
            this.cbCat1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // bsCat1
            // 
            this.bsCat1.DataMember = "CAT1";
            this.bsCat1.MyDataSource = "KlonsData";
            this.bsCat1.Name2 = null;
            this.bsCat1.Sort = "CODE";
            // 
            // cbCatD
            // 
            this.cbCatD.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbCatD.ColumnNames = new string[] {
        "CODE",
        "DESCR"};
            this.cbCatD.ColumnWidths = "100;300";
            this.cbCatD.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsItem, "fCATD", true));
            this.cbCatD.DataSource = this.bsCatD;
            this.cbCatD.DisplayMember = "CODE";
            this.cbCatD.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCatD.DropDownHeight = 255;
            this.cbCatD.DropDownWidth = 424;
            this.cbCatD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCatD.FormattingEnabled = true;
            this.cbCatD.GridLineColor = System.Drawing.Color.LightGray;
            this.cbCatD.GridLineHorizontal = false;
            this.cbCatD.GridLineVertical = false;
            this.cbCatD.IntegralHeight = false;
            this.cbCatD.Location = new System.Drawing.Point(458, 134);
            this.cbCatD.MaxDropDownItems = 15;
            this.cbCatD.Name = "cbCatD";
            this.cbCatD.Size = new System.Drawing.Size(121, 23);
            this.cbCatD.TabIndex = 6;
            this.cbCatD.ValueMember = "ID";
            this.cbCatD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // bsCatD
            // 
            this.bsCatD.DataMember = "CATD";
            this.bsCatD.MyDataSource = "KlonsData";
            this.bsCatD.Name2 = null;
            this.bsCatD.Sort = "CODE";
            // 
            // cbCatT
            // 
            this.cbCatT.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbCatT.ColumnNames = new string[] {
        "CODE",
        "DESCR"};
            this.cbCatT.ColumnWidths = "100;300";
            this.cbCatT.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsItem, "fCATT", true));
            this.cbCatT.DataSource = this.bsCatT;
            this.cbCatT.DisplayMember = "CODE";
            this.cbCatT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCatT.DropDownHeight = 255;
            this.cbCatT.DropDownWidth = 424;
            this.cbCatT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCatT.FormattingEnabled = true;
            this.cbCatT.GridLineColor = System.Drawing.Color.LightGray;
            this.cbCatT.GridLineHorizontal = false;
            this.cbCatT.GridLineVertical = false;
            this.cbCatT.IntegralHeight = false;
            this.cbCatT.Location = new System.Drawing.Point(458, 164);
            this.cbCatT.MaxDropDownItems = 15;
            this.cbCatT.Name = "cbCatT";
            this.cbCatT.Size = new System.Drawing.Size(121, 23);
            this.cbCatT.TabIndex = 8;
            this.cbCatT.ValueMember = "ID";
            this.cbCatT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // bsCatT
            // 
            this.bsCatT.DataMember = "CATT";
            this.bsCatT.MyDataSource = "KlonsData";
            this.bsCatT.Name2 = null;
            this.bsCatT.Sort = "CODE";
            // 
            // cbDep
            // 
            this.cbDep.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbDep.ColumnNames = new string[] {
        "CODE",
        "DESCR"};
            this.cbDep.ColumnWidths = "100;300";
            this.cbDep.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsItem, "fDEPARTMENT", true));
            this.cbDep.DataSource = this.bsDep;
            this.cbDep.DisplayMember = "CODE";
            this.cbDep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDep.DropDownHeight = 255;
            this.cbDep.DropDownWidth = 424;
            this.cbDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDep.FormattingEnabled = true;
            this.cbDep.GridLineColor = System.Drawing.Color.LightGray;
            this.cbDep.GridLineHorizontal = false;
            this.cbDep.GridLineVertical = false;
            this.cbDep.IntegralHeight = false;
            this.cbDep.Location = new System.Drawing.Point(458, 194);
            this.cbDep.MaxDropDownItems = 15;
            this.cbDep.Name = "cbDep";
            this.cbDep.Size = new System.Drawing.Size(121, 23);
            this.cbDep.TabIndex = 9;
            this.cbDep.ValueMember = "ID";
            this.cbDep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // bsDep
            // 
            this.bsDep.DataMember = "DEPARTMENTS";
            this.bsDep.MyDataSource = "KlonsData";
            this.bsDep.Name2 = null;
            this.bsDep.Sort = "CODE";
            // 
            // cbPlace
            // 
            this.cbPlace.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbPlace.ColumnNames = new string[] {
        "CODE",
        "DESCR"};
            this.cbPlace.ColumnWidths = "100;300";
            this.cbPlace.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsItem, "fPLACE", true));
            this.cbPlace.DataSource = this.bsPlace;
            this.cbPlace.DisplayMember = "CODE";
            this.cbPlace.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPlace.DropDownHeight = 255;
            this.cbPlace.DropDownWidth = 424;
            this.cbPlace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPlace.FormattingEnabled = true;
            this.cbPlace.GridLineColor = System.Drawing.Color.LightGray;
            this.cbPlace.GridLineHorizontal = false;
            this.cbPlace.GridLineVertical = false;
            this.cbPlace.IntegralHeight = false;
            this.cbPlace.Location = new System.Drawing.Point(458, 224);
            this.cbPlace.MaxDropDownItems = 15;
            this.cbPlace.Name = "cbPlace";
            this.cbPlace.Size = new System.Drawing.Size(121, 23);
            this.cbPlace.TabIndex = 10;
            this.cbPlace.ValueMember = "ID";
            this.cbPlace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // bsPlace
            // 
            this.bsPlace.DataMember = "PLACES";
            this.bsPlace.MyDataSource = "KlonsData";
            this.bsPlace.Name2 = null;
            this.bsPlace.Sort = "CODE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Kategorija:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(311, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Nolietojuma kat.:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(311, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Noliet. kat. nod. vaj.:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Struktūrvienība";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(311, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Atrašanās vieta:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Vērtība:";
            // 
            // tbValue
            // 
            this.tbValue.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItem, "fVALUE_0", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.tbValue.Location = new System.Drawing.Point(135, 130);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(80, 22);
            this.tbValue.TabIndex = 5;
            this.tbValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Dokumenta nr.:";
            // 
            // tbDocNr
            // 
            this.tbDocNr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDocNr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItem, "fDOCNR", true));
            this.tbDocNr.Location = new System.Drawing.Point(135, 159);
            this.tbDocNr.MaxLength = 50;
            this.tbDocNr.Name = "tbDocNr";
            this.tbDocNr.Size = new System.Drawing.Size(156, 22);
            this.tbDocNr.TabIndex = 7;
            this.tbDocNr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // cmOK
            // 
            this.cmOK.Location = new System.Drawing.Point(19, 251);
            this.cmOK.Name = "cmOK";
            this.cmOK.Size = new System.Drawing.Size(90, 33);
            this.cmOK.TabIndex = 11;
            this.cmOK.Text = "OK";
            this.cmOK.UseVisualStyleBackColor = true;
            this.cmOK.Click += new System.EventHandler(this.cmOK_Click);
            this.cmOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(125, 251);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(90, 33);
            this.cmCancel.TabIndex = 12;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            this.cmCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // Form_Items_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmCancel;
            this.ClientSize = new System.Drawing.Size(590, 294);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmOK);
            this.Controls.Add(this.cbPlace);
            this.Controls.Add(this.cbDep);
            this.Controls.Add(this.cbCatT);
            this.Controls.Add(this.cbCatD);
            this.Controls.Add(this.cbCat1);
            this.Controls.Add(this.chAddEvent);
            this.Controls.Add(this.tbDocNr);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbRegNr);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Items_New";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jauns pamatlīdzeklis";
            this.Load += new System.EventHandler(this.Form_Items_New_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCatD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCatT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyTextBox tbRegNr;
        private System.Windows.Forms.Label label2;
        private KlonsLIB.Components.MyTextBox tbName;
        private System.Windows.Forms.Label label3;
        private KlonsLIB.Components.MyTextBox tbDate;
        private System.Windows.Forms.CheckBox chAddEvent;
        private KlonsLIB.Components.MyMcFlatComboBox cbCat1;
        private KlonsLIB.Components.MyMcFlatComboBox cbCatD;
        private KlonsLIB.Components.MyMcFlatComboBox cbCatT;
        private KlonsLIB.Components.MyMcFlatComboBox cbDep;
        private KlonsLIB.Components.MyMcFlatComboBox cbPlace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private KlonsLIB.Components.MyTextBox tbValue;
        private System.Windows.Forms.Label label10;
        private KlonsLIB.Components.MyTextBox tbDocNr;
        private System.Windows.Forms.Button cmOK;
        private System.Windows.Forms.Button cmCancel;
        private KlonsLIB.Data.MyBindingSource bsCat1;
        private KlonsLIB.Data.MyBindingSource bsCatD;
        private KlonsLIB.Data.MyBindingSource bsCatT;
        private KlonsLIB.Data.MyBindingSource bsDep;
        private KlonsLIB.Data.MyBindingSource bsPlace;
        private KlonsLIB.Data.MyBindingSourceToObj bsItem;
        public DataObjectsP.ItemsEventsData itemsEventsData1;
    }
}