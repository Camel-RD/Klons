namespace KlonsA.Forms
{
    partial class Form_PersonNew
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
            this.tbFName = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLName = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBirthDate = new KlonsLIB.Components.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPK = new KlonsLIB.Components.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chMale = new System.Windows.Forms.CheckBox();
            this.chFemale = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmOK = new System.Windows.Forms.Button();
            this.cmCancel = new System.Windows.Forms.Button();
            this.tbPosition = new KlonsLIB.Components.MyTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDep = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsDep = new KlonsLIB.Data.MyBindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbProfCode = new KlonsLIB.Components.MyTextBox();
            this.tbRepCode = new KlonsLIB.Components.MyTextBox();
            this.tbDate = new KlonsLIB.Components.MyTextBox();
            this.chMakeEvents = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFName
            // 
            this.tbFName.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbFName.Location = new System.Drawing.Point(152, 22);
            this.tbFName.Name = "tbFName";
            this.tbFName.Size = new System.Drawing.Size(163, 22);
            this.tbFName.TabIndex = 0;
            this.tbFName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Vārds:";
            // 
            // tbLName
            // 
            this.tbLName.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbLName.Location = new System.Drawing.Point(152, 50);
            this.tbLName.Name = "tbLName";
            this.tbLName.Size = new System.Drawing.Size(163, 22);
            this.tbLName.TabIndex = 1;
            this.tbLName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Uzvārds";
            // 
            // tbBirthDate
            // 
            this.tbBirthDate.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbBirthDate.Location = new System.Drawing.Point(152, 78);
            this.tbBirthDate.Name = "tbBirthDate";
            this.tbBirthDate.Size = new System.Drawing.Size(163, 22);
            this.tbBirthDate.TabIndex = 2;
            this.tbBirthDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Dzimšanas datums:";
            // 
            // tbPK
            // 
            this.tbPK.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbPK.Location = new System.Drawing.Point(152, 106);
            this.tbPK.Name = "tbPK";
            this.tbPK.Size = new System.Drawing.Size(163, 22);
            this.tbPK.TabIndex = 3;
            this.tbPK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Personas kods:";
            // 
            // chMale
            // 
            this.chMale.AutoSize = true;
            this.chMale.Location = new System.Drawing.Point(152, 135);
            this.chMale.Name = "chMale";
            this.chMale.Size = new System.Drawing.Size(68, 20);
            this.chMale.TabIndex = 4;
            this.chMale.Text = "vīrietis";
            this.chMale.UseVisualStyleBackColor = true;
            this.chMale.CheckedChanged += new System.EventHandler(this.chMale_CheckedChanged);
            // 
            // chFemale
            // 
            this.chFemale.AutoSize = true;
            this.chFemale.Location = new System.Drawing.Point(226, 135);
            this.chFemale.Name = "chFemale";
            this.chFemale.Size = new System.Drawing.Size(77, 20);
            this.chFemale.TabIndex = 5;
            this.chFemale.Text = "sieviete";
            this.chFemale.UseVisualStyleBackColor = true;
            this.chFemale.CheckedChanged += new System.EventHandler(this.chFemale_CheckedChanged);
            this.chFemale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Dzimums:";
            // 
            // cmOK
            // 
            this.cmOK.Location = new System.Drawing.Point(393, 249);
            this.cmOK.Name = "cmOK";
            this.cmOK.Size = new System.Drawing.Size(83, 37);
            this.cmOK.TabIndex = 11;
            this.cmOK.Text = "Pievienot";
            this.cmOK.UseVisualStyleBackColor = true;
            this.cmOK.Click += new System.EventHandler(this.cmOK_Click);
            this.cmOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(482, 249);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(83, 37);
            this.cmCancel.TabIndex = 12;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            this.cmCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // tbPosition
            // 
            this.tbPosition.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbPosition.Location = new System.Drawing.Point(152, 176);
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(163, 22);
            this.tbPosition.TabIndex = 6;
            this.tbPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Amats:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Struktūrvienība:";
            // 
            // cbDep
            // 
            this.cbDep._AllowSelection = true;
            this.cbDep.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbDep.ColumnNames = new string[] {
        "ID",
        "DESCR"};
            this.cbDep.ColumnWidths = "80;300";
            this.cbDep.DataSource = this.bsDep;
            this.cbDep.DisplayMember = "ID";
            this.cbDep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDep.DropDownHeight = 255;
            this.cbDep.DropDownWidth = 404;
            this.cbDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDep.FormattingEnabled = true;
            this.cbDep.GridLineColor = System.Drawing.Color.LightGray;
            this.cbDep.GridLineHorizontal = false;
            this.cbDep.GridLineVertical = false;
            this.cbDep.IntegralHeight = false;
            this.cbDep.Location = new System.Drawing.Point(152, 204);
            this.cbDep.MaxDropDownItems = 15;
            this.cbDep.Name = "cbDep";
            this.cbDep.Size = new System.Drawing.Size(162, 23);
            this.cbDep.TabIndex = 7;
            this.cbDep.ValueMember = "ID";
            this.cbDep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // bsDep
            // 
            this.bsDep.DataMember = "DEPARTMENTS";
            this.bsDep.MyDataSource = "KlonsData";
            this.bsDep.Sort = "ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(336, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Profesijas kods:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(336, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "Ziņu kods:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(336, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Ieraksta datums:";
            // 
            // tbProfCode
            // 
            this.tbProfCode.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbProfCode.Location = new System.Drawing.Point(475, 130);
            this.tbProfCode.Name = "tbProfCode";
            this.tbProfCode.Size = new System.Drawing.Size(90, 22);
            this.tbProfCode.TabIndex = 10;
            this.tbProfCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // tbRepCode
            // 
            this.tbRepCode.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbRepCode.Location = new System.Drawing.Point(475, 102);
            this.tbRepCode.Name = "tbRepCode";
            this.tbRepCode.Size = new System.Drawing.Size(90, 22);
            this.tbRepCode.TabIndex = 9;
            this.tbRepCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // tbDate
            // 
            this.tbDate.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate.IsDate = true;
            this.tbDate.Location = new System.Drawing.Point(475, 24);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(90, 22);
            this.tbDate.TabIndex = 8;
            this.tbDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // chMakeEvents
            // 
            this.chMakeEvents.AutoSize = true;
            this.chMakeEvents.Location = new System.Drawing.Point(339, 76);
            this.chMakeEvents.Name = "chMakeEvents";
            this.chMakeEvents.Size = new System.Drawing.Size(139, 20);
            this.chMakeEvents.TabIndex = 21;
            this.chMakeEvents.Text = "Izveidot notikumus";
            this.chMakeEvents.UseVisualStyleBackColor = true;
            this.chMakeEvents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // Form_PersonNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 298);
            this.Controls.Add(this.chMakeEvents);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbProfCode);
            this.Controls.Add(this.tbRepCode);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.cbDep);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmOK);
            this.Controls.Add(this.chFemale);
            this.Controls.Add(this.chMale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPosition);
            this.Controls.Add(this.tbPK);
            this.Controls.Add(this.tbBirthDate);
            this.Controls.Add(this.tbLName);
            this.Controls.Add(this.tbFName);
            this.Name = "Form_PersonNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jauns darbinieks";
            this.Load += new System.EventHandler(this.Form_PersonNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Components.MyTextBox tbFName;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyTextBox tbLName;
        private System.Windows.Forms.Label label2;
        private KlonsLIB.Components.MyTextBox tbBirthDate;
        private System.Windows.Forms.Label label3;
        private KlonsLIB.Components.MyTextBox tbPK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chMale;
        private System.Windows.Forms.CheckBox chFemale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmOK;
        private System.Windows.Forms.Button cmCancel;
        private KlonsLIB.Components.MyTextBox tbPosition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private KlonsLIB.Components.MyMcFlatComboBox cbDep;
        private KlonsLIB.Data.MyBindingSource bsDep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private KlonsLIB.Components.MyTextBox tbProfCode;
        private KlonsLIB.Components.MyTextBox tbRepCode;
        private KlonsLIB.Components.MyTextBox tbDate;
        private System.Windows.Forms.CheckBox chMakeEvents;
    }
}