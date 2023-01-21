using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsFM.FormsReportParams
{
    partial class FormRep_PVNCheck
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
            this.bsAC = new KlonsLIB.Data.MyBindingSource();
            this.tbSD = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbED = new KlonsLIB.Components.MyTextBox();
            this.cmDoIt = new System.Windows.Forms.Button();
            this.tbLikme = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSlieksnis = new KlonsLIB.Components.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmDoIt2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).BeginInit();
            this.SuspendLayout();
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
            this.tbSD.Location = new System.Drawing.Point(152, 38);
            this.tbSD.Margin = new System.Windows.Forms.Padding(2);
            this.tbSD.Name = "tbSD";
            this.tbSD.Size = new System.Drawing.Size(80, 22);
            this.tbSD.TabIndex = 0;
            this.tbSD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Datums (no - līdz):";
            // 
            // tbED
            // 
            this.tbED.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbED.IsDate = true;
            this.tbED.Location = new System.Drawing.Point(238, 38);
            this.tbED.Margin = new System.Windows.Forms.Padding(2);
            this.tbED.Name = "tbED";
            this.tbED.Size = new System.Drawing.Size(80, 22);
            this.tbED.TabIndex = 1;
            this.tbED.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // cmDoIt
            // 
            this.cmDoIt.Location = new System.Drawing.Point(301, 114);
            this.cmDoIt.Margin = new System.Windows.Forms.Padding(2);
            this.cmDoIt.Name = "cmDoIt";
            this.cmDoIt.Size = new System.Drawing.Size(127, 50);
            this.cmDoIt.TabIndex = 4;
            this.cmDoIt.Text = "Pārbaudīt ieņēmumus";
            this.cmDoIt.UseVisualStyleBackColor = true;
            this.cmDoIt.Click += new System.EventHandler(this.cmDoIt_Click);
            this.cmDoIt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // tbLikme
            // 
            this.tbLikme.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbLikme.Location = new System.Drawing.Point(152, 77);
            this.tbLikme.Margin = new System.Windows.Forms.Padding(2);
            this.tbLikme.Name = "tbLikme";
            this.tbLikme.Size = new System.Drawing.Size(64, 22);
            this.tbLikme.TabIndex = 0;
            this.tbLikme.Text = "21";
            this.tbLikme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "PVN likme:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 66);
            this.label3.TabIndex = 6;
            this.label3.Text = "  Pārbaudam vai dokuemtā norādītā PVN summa atšķiras no matemātiski aprēķinātās a" +
    "r norādīto PVN likmi.";
            // 
            // tbSlieksnis
            // 
            this.tbSlieksnis.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSlieksnis.Location = new System.Drawing.Point(152, 114);
            this.tbSlieksnis.Margin = new System.Windows.Forms.Padding(2);
            this.tbSlieksnis.Name = "tbSlieksnis";
            this.tbSlieksnis.Size = new System.Drawing.Size(64, 22);
            this.tbSlieksnis.TabIndex = 0;
            this.tbSlieksnis.Text = "0.03";
            this.tbSlieksnis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Kļūdas robeža:";
            // 
            // cmDoIt2
            // 
            this.cmDoIt2.Location = new System.Drawing.Point(301, 178);
            this.cmDoIt2.Margin = new System.Windows.Forms.Padding(2);
            this.cmDoIt2.Name = "cmDoIt2";
            this.cmDoIt2.Size = new System.Drawing.Size(127, 50);
            this.cmDoIt2.TabIndex = 4;
            this.cmDoIt2.Text = "Pārbaudīt izmaksas";
            this.cmDoIt2.UseVisualStyleBackColor = true;
            this.cmDoIt2.Click += new System.EventHandler(this.cmDoIt2_Click);
            this.cmDoIt2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // FormRep_PVNCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 265);
            this.CloseOnEscape = true;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmDoIt2);
            this.Controls.Add(this.cmDoIt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbED);
            this.Controls.Add(this.tbSlieksnis);
            this.Controls.Add(this.tbLikme);
            this.Controls.Add(this.tbSD);
            this.Name = "FormRep_PVNCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PVN summu kontrole";
            this.Load += new System.EventHandler(this.FormRepApgr1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingSource bsAC;
        private MyTextBox tbSD;
        private System.Windows.Forms.Label label1;
        private MyTextBox tbED;
        private System.Windows.Forms.Button cmDoIt;
        private MyTextBox tbLikme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MyTextBox tbSlieksnis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmDoIt2;
    }
}