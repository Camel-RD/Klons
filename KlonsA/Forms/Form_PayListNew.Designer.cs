namespace KlonsA.Forms
{
    partial class Form_PayListsNew
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
            this.bsPayListSH = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cbSh = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDate = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bsDep = new KlonsLIB.Data.MyBindingSource(this.components);
            this.tbDescr = new KlonsLIB.Components.MyTextBox();
            this.cbDep = new KlonsLIB.Components.MyMcFlatComboBox();
            this.lbCM = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmOK = new System.Windows.Forms.Button();
            this.tbYR = new KlonsLIB.Components.MyTextBox();
            this.tbMT = new KlonsLIB.Components.MyTextBox();
            this.cmCancel = new System.Windows.Forms.Button();
            this.cmGetTempl = new System.Windows.Forms.Button();
            this.cmGetDep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsPayListSH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).BeginInit();
            this.SuspendLayout();
            // 
            // bsPayListSH
            // 
            this.bsPayListSH.DataMember = "PAYLIST_TEMPL";
            this.bsPayListSH.MyDataSource = "KlonsData";
            this.bsPayListSH.Name2 = null;
            // 
            // cbSh
            // 
            this.cbSh.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbSh.ColumnNames = new string[] {
        "ID",
        "DESCR",
        "DEP"};
            this.cbSh.ColumnWidths = "0;250;150";
            this.cbSh.DataSource = this.bsPayListSH;
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
            this.cbSh.Location = new System.Drawing.Point(13, 85);
            this.cbSh.MaxDropDownItems = 15;
            this.cbSh.Name = "cbSh";
            this.cbSh.Size = new System.Drawing.Size(300, 23);
            this.cbSh.TabIndex = 1;
            this.cbSh.ValueMember = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Maksajumu saraksta sagatave:";
            // 
            // tbDate
            // 
            this.tbDate.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate.Location = new System.Drawing.Point(13, 29);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(112, 22);
            this.tbDate.TabIndex = 0;
            this.tbDate.Leave += new System.EventHandler(this.tbDate_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Izmaksas datums:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Par gadu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "mēnesi:";
            // 
            // bsDep
            // 
            this.bsDep.DataMember = "DEPARTMENTS";
            this.bsDep.MyDataSource = "KlonsData";
            this.bsDep.Name2 = null;
            this.bsDep.Sort = "ID";
            // 
            // tbDescr
            // 
            this.tbDescr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDescr.Location = new System.Drawing.Point(13, 199);
            this.tbDescr.Name = "tbDescr";
            this.tbDescr.Size = new System.Drawing.Size(300, 22);
            this.tbDescr.TabIndex = 3;
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
            this.cbDep.Location = new System.Drawing.Point(13, 143);
            this.cbDep.MaxDropDownItems = 15;
            this.cbDep.Name = "cbDep";
            this.cbDep.Size = new System.Drawing.Size(300, 23);
            this.cbDep.TabIndex = 2;
            this.cbDep.ValueMember = "ID";
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
            this.lbCM.Location = new System.Drawing.Point(13, 241);
            this.lbCM.Name = "lbCM";
            this.lbCM.Size = new System.Drawing.Size(157, 68);
            this.lbCM.TabIndex = 4;
            this.lbCM.DoubleClick += new System.EventHandler(this.lbCM_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Apraksts:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Struktūrvienība:";
            // 
            // cmOK
            // 
            this.cmOK.Location = new System.Drawing.Point(187, 257);
            this.cmOK.Name = "cmOK";
            this.cmOK.Size = new System.Drawing.Size(84, 50);
            this.cmOK.TabIndex = 5;
            this.cmOK.Text = "Izveidot";
            this.cmOK.UseVisualStyleBackColor = true;
            this.cmOK.Click += new System.EventHandler(this.cmOK_Click);
            // 
            // tbYR
            // 
            this.tbYR.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbYR.Location = new System.Drawing.Point(144, 29);
            this.tbYR.Name = "tbYR";
            this.tbYR.ReadOnly = true;
            this.tbYR.Size = new System.Drawing.Size(51, 22);
            this.tbYR.TabIndex = 6;
            // 
            // tbMT
            // 
            this.tbMT.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbMT.Location = new System.Drawing.Point(223, 30);
            this.tbMT.Name = "tbMT";
            this.tbMT.ReadOnly = true;
            this.tbMT.Size = new System.Drawing.Size(41, 22);
            this.tbMT.TabIndex = 7;
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(281, 256);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(84, 50);
            this.cmCancel.TabIndex = 5;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            this.cmCancel.Click += new System.EventHandler(this.cmCancel_Click);
            // 
            // cmGetTempl
            // 
            this.cmGetTempl.Location = new System.Drawing.Point(319, 85);
            this.cmGetTempl.Name = "cmGetTempl";
            this.cmGetTempl.Size = new System.Drawing.Size(38, 23);
            this.cmGetTempl.TabIndex = 14;
            this.cmGetTempl.Text = "?";
            this.cmGetTempl.UseVisualStyleBackColor = true;
            this.cmGetTempl.Click += new System.EventHandler(this.cmGetTempl_Click);
            // 
            // cmGetDep
            // 
            this.cmGetDep.Location = new System.Drawing.Point(319, 143);
            this.cmGetDep.Name = "cmGetDep";
            this.cmGetDep.Size = new System.Drawing.Size(38, 23);
            this.cmGetDep.TabIndex = 14;
            this.cmGetDep.Text = "?";
            this.cmGetDep.UseVisualStyleBackColor = true;
            this.cmGetDep.Click += new System.EventHandler(this.cmGetDep_Click);
            // 
            // Form_PayListsNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmCancel;
            this.ClientSize = new System.Drawing.Size(394, 320);
            this.Controls.Add(this.cmGetDep);
            this.Controls.Add(this.cmGetTempl);
            this.Controls.Add(this.tbMT);
            this.Controls.Add(this.tbYR);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmOK);
            this.Controls.Add(this.tbDescr);
            this.Controls.Add(this.cbDep);
            this.Controls.Add(this.lbCM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSh);
            this.Name = "Form_PayListsNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jauns maksājumu saraksts";
            this.Load += new System.EventHandler(this.Form_PayListsNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPayListSH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsPayListSH;
        private KlonsLIB.Components.MyMcFlatComboBox cbSh;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyTextBox tbDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private KlonsLIB.Data.MyBindingSource bsDep;
        private KlonsLIB.Components.MyTextBox tbDescr;
        private KlonsLIB.Components.MyMcFlatComboBox cbDep;
        private System.Windows.Forms.ListBox lbCM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmOK;
        private KlonsLIB.Components.MyTextBox tbYR;
        private KlonsLIB.Components.MyTextBox tbMT;
        private System.Windows.Forms.Button cmCancel;
        private System.Windows.Forms.Button cmGetTempl;
        private System.Windows.Forms.Button cmGetDep;
    }
}