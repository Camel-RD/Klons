namespace KlonsA.Forms
{
    partial class Form_DataLoad
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
            this.cbYr1 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbMt1 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbYr2 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cbMt2 = new KlonsLIB.Components.MyMcFlatComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmOK = new System.Windows.Forms.Button();
            this.cmCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbSalaryPeriod = new System.Windows.Forms.Label();
            this.lbTimeTablePeriod = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbYr1
            // 
            this.cbYr1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbYr1.ColumnNames = new string[0];
            this.cbYr1.ColumnWidths = "45";
            this.cbYr1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbYr1.DropDownHeight = 136;
            this.cbYr1.DropDownWidth = 69;
            this.cbYr1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbYr1.FormattingEnabled = true;
            this.cbYr1.GridLineColor = System.Drawing.Color.LightGray;
            this.cbYr1.GridLineHorizontal = false;
            this.cbYr1.GridLineVertical = false;
            this.cbYr1.IntegralHeight = false;
            this.cbYr1.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cbYr1.Location = new System.Drawing.Point(75, 31);
            this.cbYr1.Name = "cbYr1";
            this.cbYr1.Size = new System.Drawing.Size(69, 23);
            this.cbYr1.TabIndex = 0;
            this.cbYr1.SelectedIndexChanged += new System.EventHandler(this.cbYr1_SelectedIndexChanged);
            // 
            // cbMt1
            // 
            this.cbMt1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbMt1.ColumnNames = new string[0];
            this.cbMt1.ColumnWidths = "35";
            this.cbMt1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMt1.DropDownHeight = 221;
            this.cbMt1.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbMt1.DropDownWidth = 57;
            this.cbMt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMt1.FormattingEnabled = true;
            this.cbMt1.GridLineColor = System.Drawing.Color.LightGray;
            this.cbMt1.GridLineHorizontal = false;
            this.cbMt1.GridLineVertical = false;
            this.cbMt1.IntegralHeight = false;
            this.cbMt1.Items.AddRange(new object[] {
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
            "12"});
            this.cbMt1.Location = new System.Drawing.Point(150, 31);
            this.cbMt1.MaxDropDownItems = 13;
            this.cbMt1.Name = "cbMt1";
            this.cbMt1.Size = new System.Drawing.Size(57, 23);
            this.cbMt1.TabIndex = 1;
            this.cbMt1.SelectedIndexChanged += new System.EventHandler(this.cbMt1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Līdz:";
            // 
            // cbYr2
            // 
            this.cbYr2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbYr2.ColumnNames = new string[0];
            this.cbYr2.ColumnWidths = "45";
            this.cbYr2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbYr2.DropDownHeight = 136;
            this.cbYr2.DropDownWidth = 69;
            this.cbYr2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbYr2.FormattingEnabled = true;
            this.cbYr2.GridLineColor = System.Drawing.Color.LightGray;
            this.cbYr2.GridLineHorizontal = false;
            this.cbYr2.GridLineVertical = false;
            this.cbYr2.IntegralHeight = false;
            this.cbYr2.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cbYr2.Location = new System.Drawing.Point(75, 61);
            this.cbYr2.Name = "cbYr2";
            this.cbYr2.Size = new System.Drawing.Size(69, 23);
            this.cbYr2.TabIndex = 2;
            // 
            // cbMt2
            // 
            this.cbMt2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbMt2.ColumnNames = new string[0];
            this.cbMt2.ColumnWidths = "35";
            this.cbMt2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMt2.DropDownHeight = 221;
            this.cbMt2.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbMt2.DropDownWidth = 57;
            this.cbMt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMt2.FormattingEnabled = true;
            this.cbMt2.GridLineColor = System.Drawing.Color.LightGray;
            this.cbMt2.GridLineHorizontal = false;
            this.cbMt2.GridLineVertical = false;
            this.cbMt2.IntegralHeight = false;
            this.cbMt2.Items.AddRange(new object[] {
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
            "12"});
            this.cbMt2.Location = new System.Drawing.Point(150, 61);
            this.cbMt2.MaxDropDownItems = 13;
            this.cbMt2.Name = "cbMt2";
            this.cbMt2.Size = new System.Drawing.Size(57, 23);
            this.cbMt2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(378, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Atlasīt datus rediģēšanai norādītajam laika periodam:";
            // 
            // cmOK
            // 
            this.cmOK.Location = new System.Drawing.Point(210, 206);
            this.cmOK.Name = "cmOK";
            this.cmOK.Size = new System.Drawing.Size(112, 44);
            this.cmOK.TabIndex = 4;
            this.cmOK.Text = "Atlasīt";
            this.cmOK.UseVisualStyleBackColor = true;
            this.cmOK.Click += new System.EventHandler(this.cmOK_Click);
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(341, 206);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(112, 44);
            this.cmCancel.TabIndex = 5;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Datu bāze satur datus par:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "algu lapas: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "darba laika lapas: ";
            // 
            // lbSalaryPeriod
            // 
            this.lbSalaryPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbSalaryPeriod.Location = new System.Drawing.Point(159, 128);
            this.lbSalaryPeriod.Name = "lbSalaryPeriod";
            this.lbSalaryPeriod.Size = new System.Drawing.Size(289, 16);
            this.lbSalaryPeriod.TabIndex = 9;
            this.lbSalaryPeriod.Text = "nav";
            // 
            // lbTimeTablePeriod
            // 
            this.lbTimeTablePeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbTimeTablePeriod.Location = new System.Drawing.Point(159, 155);
            this.lbTimeTablePeriod.Name = "lbTimeTablePeriod";
            this.lbTimeTablePeriod.Size = new System.Drawing.Size(289, 16);
            this.lbTimeTablePeriod.TabIndex = 9;
            this.lbTimeTablePeriod.Text = "nav";
            // 
            // Form_DataLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmCancel;
            this.ClientSize = new System.Drawing.Size(465, 265);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbTimeTablePeriod);
            this.Controls.Add(this.lbSalaryPeriod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMt2);
            this.Controls.Add(this.cbMt1);
            this.Controls.Add(this.cbYr2);
            this.Controls.Add(this.cbYr1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_DataLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datu atlase";
            this.Load += new System.EventHandler(this.Form_DataLoad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Components.MyMcFlatComboBox cbYr1;
        private KlonsLIB.Components.MyMcFlatComboBox cbMt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private KlonsLIB.Components.MyMcFlatComboBox cbYr2;
        private KlonsLIB.Components.MyMcFlatComboBox cbMt2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmOK;
        private System.Windows.Forms.Button cmCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbSalaryPeriod;
        private System.Windows.Forms.Label lbTimeTablePeriod;
    }
}