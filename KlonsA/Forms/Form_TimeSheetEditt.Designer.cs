using KlonsLIB.Components;

namespace KlonsA.Forms
{
    partial class Form_TimeSheetEdit
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
            this.cbPerson = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsPersons = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cbPosition = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsAmati = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.cbPlan = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsPlan = new KlonsLIB.Data.MyBindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chPlanIndividual = new MyCheckBox();
            this.chNight = new MyCheckBox();
            this.cmDoIt = new System.Windows.Forms.Button();
            this.cmCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSnr = new KlonsLIB.Components.MyTextBox();
            this.chOvertime = new MyCheckBox();
            this.cmGetPerson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPerson
            // 
            this.cbPerson._AllowSelection = true;
            this.cbPerson.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbPerson.ColumnNames = new string[] {
        "FNAME",
        "LNAME",
        "PK"};
            this.cbPerson.ColumnWidths = "100;100;100";
            this.cbPerson.DataSource = this.bsPersons;
            this.cbPerson.DisplayMember = "ZNAME";
            this.cbPerson.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPerson.DropDownHeight = 204;
            this.cbPerson.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbPerson.DropDownWidth = 324;
            this.cbPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPerson.FormattingEnabled = true;
            this.cbPerson.GridLineColor = System.Drawing.Color.LightGray;
            this.cbPerson.GridLineHorizontal = false;
            this.cbPerson.GridLineVertical = false;
            this.cbPerson.IntegralHeight = false;
            this.cbPerson.Location = new System.Drawing.Point(97, 25);
            this.cbPerson.MaxDropDownItems = 12;
            this.cbPerson.Name = "cbPerson";
            this.cbPerson.Size = new System.Drawing.Size(304, 23);
            this.cbPerson.TabIndex = 0;
            this.cbPerson.ValueMember = "ID";
            // 
            // bsPersons
            // 
            this.bsPersons.DataMember = "PERSONS";
            this.bsPersons.Filter = "USED=1";
            this.bsPersons.MyDataSource = "KlonsData";
            this.bsPersons.Name2 = null;
            this.bsPersons.Sort = "LNAME,FNAME";
            // 
            // cbPosition
            // 
            this.cbPosition._AllowSelection = true;
            this.cbPosition.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbPosition.ColumnNames = new string[] {
        "TITLE"};
            this.cbPosition.ColumnWidths = "250";
            this.cbPosition.DataSource = this.bsAmati;
            this.cbPosition.DisplayMember = "TITLE";
            this.cbPosition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPosition.DropDownHeight = 136;
            this.cbPosition.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbPosition.DropDownWidth = 274;
            this.cbPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPosition.FormattingEnabled = true;
            this.cbPosition.GridLineColor = System.Drawing.Color.LightGray;
            this.cbPosition.GridLineHorizontal = false;
            this.cbPosition.GridLineVertical = false;
            this.cbPosition.IntegralHeight = false;
            this.cbPosition.Location = new System.Drawing.Point(97, 60);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(304, 23);
            this.cbPosition.TabIndex = 1;
            this.cbPosition.ValueMember = "ID";
            // 
            // bsAmati
            // 
            this.bsAmati.DataMember = "FK_POSITIONS_IDP";
            this.bsAmati.DataSource = this.bsPersons;
            this.bsAmati.Filter = "USED=1";
            this.bsAmati.Name2 = null;
            // 
            // cbPlan
            // 
            this.cbPlan._AllowSelection = true;
            this.cbPlan.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbPlan.ColumnNames = new string[] {
        "DESCR"};
            this.cbPlan.ColumnWidths = "250";
            this.cbPlan.DataSource = this.bsPlan;
            this.cbPlan.DisplayMember = "DESCR";
            this.cbPlan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPlan.DropDownHeight = 136;
            this.cbPlan.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbPlan.DropDownWidth = 274;
            this.cbPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPlan.FormattingEnabled = true;
            this.cbPlan.GridLineColor = System.Drawing.Color.LightGray;
            this.cbPlan.GridLineHorizontal = false;
            this.cbPlan.GridLineVertical = false;
            this.cbPlan.IntegralHeight = false;
            this.cbPlan.Location = new System.Drawing.Point(97, 95);
            this.cbPlan.Name = "cbPlan";
            this.cbPlan.Size = new System.Drawing.Size(304, 23);
            this.cbPlan.TabIndex = 2;
            this.cbPlan.ValueMember = "ID";
            // 
            // bsPlan
            // 
            this.bsPlan.DataMember = "TIMEPLAN_LIST";
            this.bsPlan.Filter = "USED=1";
            this.bsPlan.MyDataSource = "KlonsData";
            this.bsPlan.Name2 = null;
            this.bsPlan.Sort = "SNR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Darbinieks:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Amats:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Plāns:";
            // 
            // chPlanIndividual
            // 
            this.chPlanIndividual.AutoSize = true;
            this.chPlanIndividual.Location = new System.Drawing.Point(61, 164);
            this.chPlanIndividual.Name = "chPlanIndividual";
            this.chPlanIndividual.Size = new System.Drawing.Size(130, 20);
            this.chPlanIndividual.TabIndex = 4;
            this.chPlanIndividual.Text = "Individuāls plāns";
            this.chPlanIndividual.UseVisualStyleBackColor = true;
            // 
            // chNight
            // 
            this.chNight.AutoSize = true;
            this.chNight.Location = new System.Drawing.Point(61, 192);
            this.chNight.Name = "chNight";
            this.chNight.Size = new System.Drawing.Size(98, 20);
            this.chNight.TabIndex = 5;
            this.chNight.Text = "Darbs naktī";
            this.chNight.UseVisualStyleBackColor = true;
            // 
            // cmDoIt
            // 
            this.cmDoIt.Location = new System.Drawing.Point(351, 152);
            this.cmDoIt.Name = "cmDoIt";
            this.cmDoIt.Size = new System.Drawing.Size(99, 43);
            this.cmDoIt.TabIndex = 7;
            this.cmDoIt.Text = "Saglabāt";
            this.cmDoIt.UseVisualStyleBackColor = true;
            this.cmDoIt.Click += new System.EventHandler(this.cmDoIt_Click);
            // 
            // cmCancel
            // 
            this.cmCancel.Location = new System.Drawing.Point(351, 207);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(99, 43);
            this.cmCancel.TabIndex = 8;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            this.cmCancel.Click += new System.EventHandler(this.cmCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "N.p.k.:";
            // 
            // tbSnr
            // 
            this.tbSnr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSnr.Location = new System.Drawing.Point(98, 130);
            this.tbSnr.Name = "tbSnr";
            this.tbSnr.Size = new System.Drawing.Size(92, 22);
            this.tbSnr.TabIndex = 3;
            // 
            // chOvertime
            // 
            this.chOvertime.AutoSize = true;
            this.chOvertime.Location = new System.Drawing.Point(61, 221);
            this.chOvertime.Name = "chOvertime";
            this.chOvertime.Size = new System.Drawing.Size(100, 20);
            this.chOvertime.TabIndex = 6;
            this.chOvertime.Text = "Virsstundas";
            this.chOvertime.UseVisualStyleBackColor = true;
            // 
            // cmGetPerson
            // 
            this.cmGetPerson.Location = new System.Drawing.Point(407, 25);
            this.cmGetPerson.Name = "cmGetPerson";
            this.cmGetPerson.Size = new System.Drawing.Size(38, 23);
            this.cmGetPerson.TabIndex = 14;
            this.cmGetPerson.Text = "?";
            this.cmGetPerson.UseVisualStyleBackColor = true;
            this.cmGetPerson.Click += new System.EventHandler(this.cmGetPerson_Click);
            // 
            // Form_TimeSheetEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 266);
            this.Controls.Add(this.cmGetPerson);
            this.Controls.Add(this.chOvertime);
            this.Controls.Add(this.tbSnr);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmDoIt);
            this.Controls.Add(this.chNight);
            this.Controls.Add(this.chPlanIndividual);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPlan);
            this.Controls.Add(this.cbPosition);
            this.Controls.Add(this.cbPerson);
            this.Name = "Form_TimeSheetEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jauns darba laika lapas ieraksts";
            this.Load += new System.EventHandler(this.Form_TimeSheetEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Components.MyMcFlatComboBox cbPerson;
        private KlonsLIB.Components.MyMcFlatComboBox cbPosition;
        private KlonsLIB.Components.MyMcFlatComboBox cbPlan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MyCheckBox chPlanIndividual;
        private MyCheckBox chNight;
        private System.Windows.Forms.Button cmDoIt;
        private System.Windows.Forms.Button cmCancel;
        private KlonsLIB.Data.MyBindingSource bsPersons;
        private KlonsLIB.Data.MyBindingSource bsPlan;
        private KlonsLIB.Data.MyBindingSource2 bsAmati;
        private System.Windows.Forms.Label label4;
        private KlonsLIB.Components.MyTextBox tbSnr;
        private MyCheckBox chOvertime;
        private System.Windows.Forms.Button cmGetPerson;
    }
}