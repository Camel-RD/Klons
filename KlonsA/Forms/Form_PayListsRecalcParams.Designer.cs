namespace KlonsA.Forms
{
    partial class Form_PayListsRecalcParams
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
            this.bsPersons = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cbPerson = new KlonsLIB.Components.MyMcFlatComboBox();
            this.tbDate1 = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmRecalc = new System.Windows.Forms.Button();
            this.cmCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).BeginInit();
            this.SuspendLayout();
            // 
            // bsPersons
            // 
            this.bsPersons.DataMember = "PERSONS";
            this.bsPersons.Filter = "USED=1";
            this.bsPersons.MyDataSource = "KlonsData";
            this.bsPersons.Sort = "YNAME";
            // 
            // cbPerson
            // 
            this.cbPerson.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbPerson.ColumnNames = new string[] {
        "FNAME",
        "LNAME",
        "PK"};
            this.cbPerson.ColumnWidths = "100;100;100";
            this.cbPerson.DataSource = this.bsPersons;
            this.cbPerson.DisplayMember = "YNAME";
            this.cbPerson.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPerson.DropDownHeight = 255;
            this.cbPerson.DropDownWidth = 324;
            this.cbPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPerson.FormattingEnabled = true;
            this.cbPerson.GridLineColor = System.Drawing.Color.LightGray;
            this.cbPerson.GridLineHorizontal = false;
            this.cbPerson.GridLineVertical = false;
            this.cbPerson.IntegralHeight = false;
            this.cbPerson.Location = new System.Drawing.Point(26, 122);
            this.cbPerson.MaxDropDownItems = 15;
            this.cbPerson.Name = "cbPerson";
            this.cbPerson.Size = new System.Drawing.Size(257, 23);
            this.cbPerson.TabIndex = 5;
            this.cbPerson.ValueMember = "ID";
            // 
            // tbDate1
            // 
            this.tbDate1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate1.IsDate = true;
            this.tbDate1.Location = new System.Drawing.Point(26, 37);
            this.tbDate1.Name = "tbDate1";
            this.tbDate1.Size = new System.Drawing.Size(90, 22);
            this.tbDate1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pārrēķināt sākot ar datumu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Darbinieks:\r\n(tukšs, lai pārrēķinātu visiem)";
            // 
            // cmRecalc
            // 
            this.cmRecalc.Location = new System.Drawing.Point(136, 181);
            this.cmRecalc.Name = "cmRecalc";
            this.cmRecalc.Size = new System.Drawing.Size(137, 37);
            this.cmRecalc.TabIndex = 9;
            this.cmRecalc.Text = "Pārrēķināt";
            this.cmRecalc.UseVisualStyleBackColor = true;
            this.cmRecalc.Click += new System.EventHandler(this.cmRecalc_Click);
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(299, 181);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(114, 37);
            this.cmCancel.TabIndex = 10;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            // 
            // Form_PayListsRecalcParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmCancel;
            this.ClientSize = new System.Drawing.Size(445, 250);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmRecalc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDate1);
            this.Controls.Add(this.cbPerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_PayListsRecalcParams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Maksājuma sarakstu pārrēķina parametri";
            this.Load += new System.EventHandler(this.Form_PayListsRecalcParams_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPersons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsPersons;
        private KlonsLIB.Components.MyMcFlatComboBox cbPerson;
        private KlonsLIB.Components.MyTextBox tbDate1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmRecalc;
        private System.Windows.Forms.Button cmCancel;
    }
}