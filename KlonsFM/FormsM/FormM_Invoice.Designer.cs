
namespace KlonsFM.FormsM
{
    partial class FormM_Invoice
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
            this.label1 = new System.Windows.Forms.Label();
            this.btDoIt = new System.Windows.Forms.Button();
            this.tbDate = new KlonsLIB.Components.MyTextBox();
            this.lbInvoiceForm = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSigner = new KlonsLIB.Components.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTitle = new KlonsLIB.Components.FlatComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.chShowCarrier = new KlonsLIB.Components.MyCheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Parakstīšanas datums:";
            // 
            // btDoIt
            // 
            this.btDoIt.Location = new System.Drawing.Point(437, 180);
            this.btDoIt.Name = "btDoIt";
            this.btDoIt.Size = new System.Drawing.Size(112, 62);
            this.btDoIt.TabIndex = 5;
            this.btDoIt.Text = "Sagatavot izdruku";
            this.btDoIt.UseVisualStyleBackColor = true;
            this.btDoIt.Click += new System.EventHandler(this.btDoIt_Click);
            // 
            // tbDate
            // 
            this.tbDate.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate.IsDate = true;
            this.tbDate.Location = new System.Drawing.Point(188, 16);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(100, 26);
            this.tbDate.TabIndex = 0;
            // 
            // lbInvoiceForm
            // 
            this.lbInvoiceForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInvoiceForm.FormattingEnabled = true;
            this.lbInvoiceForm.ItemHeight = 20;
            this.lbInvoiceForm.Items.AddRange(new object[] {
            "Veidlapa 1 - ar atlaidi un PVN kodu",
            "Veidlapa 1 - bez atlaides un PVN koda",
            "Veidlapa 2 - vienkāršāks rēķins"});
            this.lbInvoiceForm.Location = new System.Drawing.Point(12, 198);
            this.lbInvoiceForm.Name = "lbInvoiceForm";
            this.lbInvoiceForm.Size = new System.Drawing.Size(397, 102);
            this.lbInvoiceForm.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Parakstītājs:";
            // 
            // tbSigner
            // 
            this.tbSigner.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSigner.Location = new System.Drawing.Point(188, 56);
            this.tbSigner.Name = "tbSigner";
            this.tbSigner.Size = new System.Drawing.Size(175, 26);
            this.tbSigner.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Virsraksts:";
            // 
            // cbTitle
            // 
            this.cbTitle.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTitle.FormattingEnabled = true;
            this.cbTitle.Items.AddRange(new object[] {
            "PREČU PAVADZĪME RĒĶINS",
            "PAVADZĪME",
            "RĒĶINS",
            "PRIEKŠAPMAKSAS RĒĶINS",
            "KREDĪTRĒĶINS"});
            this.cbTitle.Location = new System.Drawing.Point(188, 95);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Size = new System.Drawing.Size(359, 28);
            this.cbTitle.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Izdrukas veids:";
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(437, 256);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(112, 40);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "Atcelt";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // chShowCarrier
            // 
            this.chShowCarrier.AutoSize = true;
            this.chShowCarrier.Checked = true;
            this.chShowCarrier.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chShowCarrier.Location = new System.Drawing.Point(16, 139);
            this.chShowCarrier.Name = "chShowCarrier";
            this.chShowCarrier.Size = new System.Drawing.Size(201, 21);
            this.chShowCarrier.TabIndex = 3;
            this.chShowCarrier.Text = "Rādīt pārvadātāja datus";
            this.chShowCarrier.UseVisualStyleBackColor = false;
            // 
            // FormM_Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 337);
            this.Controls.Add(this.chShowCarrier);
            this.Controls.Add(this.cbTitle);
            this.Controls.Add(this.lbInvoiceForm);
            this.Controls.Add(this.tbSigner);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btDoIt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormM_Invoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dokumenta izdruka";
            this.Load += new System.EventHandler(this.FormM_Invoice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDoIt;
        private KlonsLIB.Components.MyTextBox tbDate;
        private System.Windows.Forms.ListBox lbInvoiceForm;
        private System.Windows.Forms.Label label2;
        private KlonsLIB.Components.MyTextBox tbSigner;
        private System.Windows.Forms.Label label3;
        private KlonsLIB.Components.FlatComboBox cbTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btCancel;
        private KlonsLIB.Components.MyCheckBox chShowCarrier;
    }
}