using KlonsLIB.Components;

namespace KlonsA.Forms
{
    partial class Form_SalarySheetsNew
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
            KlonsLIB.Components.MyMcComboBox.MyItem myItem17 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem18 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem19 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem20 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem21 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem22 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem23 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem24 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem25 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem26 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem27 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem28 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem29 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem30 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem31 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            KlonsLIB.Components.MyMcComboBox.MyItem myItem32 = new KlonsLIB.Components.MyMcComboBox.MyItem();
            this.bsSalarySheetSH = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cbSh = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDate = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbYr = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMt = new KlonsLIB.Components.MyMcFlatComboBox();
            this.chFull = new MyCheckBox();
            this.chTemp = new MyCheckBox();
            this.lbCM = new System.Windows.Forms.ListBox();
            this.cmOK = new System.Windows.Forms.Button();
            this.cmCancel = new System.Windows.Forms.Button();
            this.bsDep = new KlonsLIB.Data.MyBindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cbDep = new KlonsLIB.Components.MyMcFlatComboBox();
            this.tbDescr = new KlonsLIB.Components.MyTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmGetTempl = new System.Windows.Forms.Button();
            this.cmGetDep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsSalarySheetSH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).BeginInit();
            this.SuspendLayout();
            // 
            // bsSalarySheetSH
            // 
            this.bsSalarySheetSH.DataMember = "SALARY_SHEET_TEMPL";
            this.bsSalarySheetSH.MyDataSource = "KlonsData";
            this.bsSalarySheetSH.Name2 = null;
            this.bsSalarySheetSH.Sort = "SNR";
            // 
            // cbSh
            // 
            this.cbSh.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbSh.ColumnNames = new string[] {
        "ID",
        "DESCR",
        "DEP"};
            this.cbSh.ColumnWidths = "0;250;150";
            this.cbSh.DataSource = this.bsSalarySheetSH;
            this.cbSh.DisplayMember = "DESCR";
            this.cbSh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSh.DropDownHeight = 255;
            this.cbSh.DropDownWidth = 424;
            this.cbSh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSh.FormattingEnabled = true;
            this.cbSh.GridLineColor = System.Drawing.Color.LightGray;
            this.cbSh.GridLineHorizontal = false;
            this.cbSh.GridLineVertical = false;
            this.cbSh.IntegralHeight = false;
            this.cbSh.Location = new System.Drawing.Point(12, 116);
            this.cbSh.MaxDropDownItems = 15;
            this.cbSh.Name = "cbSh";
            this.cbSh.Size = new System.Drawing.Size(300, 23);
            this.cbSh.TabIndex = 3;
            this.cbSh.ValueMember = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Algas aprēķinu lapas sagatave:";
            // 
            // tbDate
            // 
            this.tbDate.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate.Location = new System.Drawing.Point(163, 60);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(45, 22);
            this.tbDate.TabIndex = 2;
            this.tbDate.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "diena (1-31)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Par gadu:";
            // 
            // cbYr
            // 
            this.cbYr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbYr.ColumnNames = new string[] {
        "col1"};
            this.cbYr.ColumnWidths = "39";
            this.cbYr.DisplayMember = "col1";
            this.cbYr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbYr.DropDownHeight = 136;
            this.cbYr.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbYr.DropDownWidth = 63;
            this.cbYr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbYr.FormattingEnabled = true;
            this.cbYr.GridLineColor = System.Drawing.Color.LightGray;
            this.cbYr.GridLineHorizontal = false;
            this.cbYr.GridLineVertical = false;
            this.cbYr.IntegralHeight = false;
            myItem17.Col1 = "2014";
            myItem18.Col1 = "2015";
            myItem19.Col1 = "2016";
            myItem20.Col1 = "2017";
            this.cbYr.Items.AddRange(new object[] {
            myItem17,
            myItem18,
            myItem19,
            myItem20});
            this.cbYr.ItemStrings = new string[] {
        "2014",
        "2015",
        "2016",
        "2017"};
            this.cbYr.Location = new System.Drawing.Point(12, 59);
            this.cbYr.Name = "cbYr";
            this.cbYr.Size = new System.Drawing.Size(63, 23);
            this.cbYr.TabIndex = 0;
            this.cbYr.ValueMember = "col1";
            this.cbYr.SelectedIndexChanged += new System.EventHandler(this.cbYr_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "mēnesi:";
            // 
            // cbMt
            // 
            this.cbMt.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbMt.ColumnNames = new string[] {
        "col1"};
            this.cbMt.ColumnWidths = "39";
            this.cbMt.DisplayMember = "col1";
            this.cbMt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMt.DropDownHeight = 221;
            this.cbMt.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbMt.DropDownWidth = 63;
            this.cbMt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMt.FormattingEnabled = true;
            this.cbMt.GridLineColor = System.Drawing.Color.LightGray;
            this.cbMt.GridLineHorizontal = false;
            this.cbMt.GridLineVertical = false;
            this.cbMt.IntegralHeight = false;
            myItem21.Col1 = "1";
            myItem22.Col1 = "2";
            myItem23.Col1 = "3";
            myItem24.Col1 = "4";
            myItem25.Col1 = "5";
            myItem26.Col1 = "6";
            myItem27.Col1 = "7";
            myItem28.Col1 = "8";
            myItem29.Col1 = "9";
            myItem30.Col1 = "10";
            myItem31.Col1 = "11";
            myItem32.Col1 = "12";
            this.cbMt.Items.AddRange(new object[] {
            myItem21,
            myItem22,
            myItem23,
            myItem24,
            myItem25,
            myItem26,
            myItem27,
            myItem28,
            myItem29,
            myItem30,
            myItem31,
            myItem32});
            this.cbMt.ItemStrings = new string[] {
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "10",
        "11",
        "12"};
            this.cbMt.Location = new System.Drawing.Point(88, 59);
            this.cbMt.MaxDropDownItems = 13;
            this.cbMt.Name = "cbMt";
            this.cbMt.Size = new System.Drawing.Size(63, 23);
            this.cbMt.TabIndex = 1;
            this.cbMt.ValueMember = "col1";
            this.cbMt.SelectedIndexChanged += new System.EventHandler(this.cbMt_SelectedIndexChanged);
            // 
            // chFull
            // 
            this.chFull.AutoSize = true;
            this.chFull.Location = new System.Drawing.Point(12, 9);
            this.chFull.Name = "chFull";
            this.chFull.Size = new System.Drawing.Size(134, 20);
            this.chFull.TabIndex = 9;
            this.chFull.Text = "mēneša aprēķins";
            this.chFull.UseVisualStyleBackColor = true;
            this.chFull.CheckedChanged += new System.EventHandler(this.chFull_CheckedChanged);
            // 
            // chTemp
            // 
            this.chTemp.AutoSize = true;
            this.chTemp.Location = new System.Drawing.Point(159, 9);
            this.chTemp.Name = "chTemp";
            this.chTemp.Size = new System.Drawing.Size(112, 20);
            this.chTemp.TabIndex = 10;
            this.chTemp.Text = "starpaprēķins";
            this.chTemp.UseVisualStyleBackColor = true;
            this.chTemp.CheckedChanged += new System.EventHandler(this.chTemp_CheckedChanged);
            // 
            // lbCM
            // 
            this.lbCM.BackColor = System.Drawing.SystemColors.Control;
            this.lbCM.FormattingEnabled = true;
            this.lbCM.ItemHeight = 16;
            this.lbCM.Items.AddRange(new object[] {
            "Visām sagatavēm",
            "Norādītajai sagatavei",
            "Tukšu sarakstu"});
            this.lbCM.Location = new System.Drawing.Point(12, 271);
            this.lbCM.Name = "lbCM";
            this.lbCM.Size = new System.Drawing.Size(156, 68);
            this.lbCM.TabIndex = 6;
            this.lbCM.DoubleClick += new System.EventHandler(this.lbCM_DoubleClick);
            // 
            // cmOK
            // 
            this.cmOK.Location = new System.Drawing.Point(183, 287);
            this.cmOK.Name = "cmOK";
            this.cmOK.Size = new System.Drawing.Size(88, 52);
            this.cmOK.TabIndex = 7;
            this.cmOK.Text = "Izveidot";
            this.cmOK.UseVisualStyleBackColor = true;
            this.cmOK.Click += new System.EventHandler(this.cmOK_Click);
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(288, 287);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(88, 52);
            this.cmCancel.TabIndex = 8;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            // 
            // bsDep
            // 
            this.bsDep.DataMember = "DEPARTMENTS";
            this.bsDep.MyDataSource = "KlonsData";
            this.bsDep.Name2 = null;
            this.bsDep.Sort = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Struktūrvienība:";
            // 
            // cbDep
            // 
            this.cbDep.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbDep.ColumnNames = new string[] {
        "ID",
        "DESCR"};
            this.cbDep.ColumnWidths = "100;300";
            this.cbDep.DataSource = this.bsDep;
            this.cbDep.DisplayMember = "DESCR";
            this.cbDep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDep.DropDownHeight = 255;
            this.cbDep.DropDownWidth = 424;
            this.cbDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDep.FormattingEnabled = true;
            this.cbDep.GridLineColor = System.Drawing.Color.LightGray;
            this.cbDep.GridLineHorizontal = false;
            this.cbDep.GridLineVertical = false;
            this.cbDep.IntegralHeight = false;
            this.cbDep.Location = new System.Drawing.Point(12, 173);
            this.cbDep.MaxDropDownItems = 15;
            this.cbDep.Name = "cbDep";
            this.cbDep.Size = new System.Drawing.Size(300, 23);
            this.cbDep.TabIndex = 4;
            this.cbDep.ValueMember = "ID";
            // 
            // tbDescr
            // 
            this.tbDescr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDescr.Location = new System.Drawing.Point(12, 229);
            this.tbDescr.Name = "tbDescr";
            this.tbDescr.Size = new System.Drawing.Size(300, 22);
            this.tbDescr.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Apraksts:";
            // 
            // cmGetTempl
            // 
            this.cmGetTempl.Location = new System.Drawing.Point(318, 116);
            this.cmGetTempl.Name = "cmGetTempl";
            this.cmGetTempl.Size = new System.Drawing.Size(38, 23);
            this.cmGetTempl.TabIndex = 17;
            this.cmGetTempl.Text = "?";
            this.cmGetTempl.UseVisualStyleBackColor = true;
            this.cmGetTempl.Click += new System.EventHandler(this.cmGetTempl_Click);
            // 
            // cmGetDep
            // 
            this.cmGetDep.Location = new System.Drawing.Point(318, 173);
            this.cmGetDep.Name = "cmGetDep";
            this.cmGetDep.Size = new System.Drawing.Size(38, 23);
            this.cmGetDep.TabIndex = 17;
            this.cmGetDep.Text = "?";
            this.cmGetDep.UseVisualStyleBackColor = true;
            this.cmGetDep.Click += new System.EventHandler(this.cmGetDep_Click);
            // 
            // Form_SalarySheetsNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmCancel;
            this.ClientSize = new System.Drawing.Size(388, 349);
            this.Controls.Add(this.cmGetDep);
            this.Controls.Add(this.cmGetTempl);
            this.Controls.Add(this.tbDescr);
            this.Controls.Add(this.cbDep);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmOK);
            this.Controls.Add(this.lbCM);
            this.Controls.Add(this.chTemp);
            this.Controls.Add(this.chFull);
            this.Controls.Add(this.cbMt);
            this.Controls.Add(this.cbYr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSh);
            this.Name = "Form_SalarySheetsNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jauna algas parēķinu lapa";
            this.Load += new System.EventHandler(this.Form_SalarySheetsNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsSalarySheetSH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsSalarySheetSH;
        private KlonsLIB.Components.MyMcFlatComboBox cbSh;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyTextBox tbDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private KlonsLIB.Components.MyMcFlatComboBox cbYr;
        private System.Windows.Forms.Label label4;
        private KlonsLIB.Components.MyMcFlatComboBox cbMt;
        private MyCheckBox chFull;
        private MyCheckBox chTemp;
        private System.Windows.Forms.ListBox lbCM;
        private System.Windows.Forms.Button cmOK;
        private System.Windows.Forms.Button cmCancel;
        private KlonsLIB.Data.MyBindingSource bsDep;
        private System.Windows.Forms.Label label5;
        private KlonsLIB.Components.MyMcFlatComboBox cbDep;
        private KlonsLIB.Components.MyTextBox tbDescr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmGetTempl;
        private System.Windows.Forms.Button cmGetDep;
    }
}