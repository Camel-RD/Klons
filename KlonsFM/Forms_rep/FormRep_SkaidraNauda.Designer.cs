using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsFM.FormsReportParams
{
    partial class FormRep_SkaidraNauda
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLimit1 = new KlonsLIB.Components.MyTextBox();
            this.tbLimit2 = new KlonsLIB.Components.MyTextBox();
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
            this.cmDoIt.Location = new System.Drawing.Point(99, 203);
            this.cmDoIt.Margin = new System.Windows.Forms.Padding(2);
            this.cmDoIt.Name = "cmDoIt";
            this.cmDoIt.Size = new System.Drawing.Size(133, 63);
            this.cmDoIt.TabIndex = 4;
            this.cmDoIt.Text = "Atskaite par mēnesi (jur. pers.)";
            this.cmDoIt.UseVisualStyleBackColor = true;
            this.cmDoIt.Click += new System.EventHandler(this.cmDoIt_Click);
            this.cmDoIt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(18, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 42);
            this.label2.TabIndex = 6;
            this.label2.Text = "Maksājumu summas robeža juridiskām personām (1500)";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 42);
            this.label3.TabIndex = 6;
            this.label3.Text = "Darijuma summas robeža fiziskai personām (3000)";
            // 
            // tbLimit1
            // 
            this.tbLimit1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbLimit1.Location = new System.Drawing.Point(281, 82);
            this.tbLimit1.Margin = new System.Windows.Forms.Padding(2);
            this.tbLimit1.Name = "tbLimit1";
            this.tbLimit1.Size = new System.Drawing.Size(80, 22);
            this.tbLimit1.TabIndex = 0;
            this.tbLimit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // tbLimit2
            // 
            this.tbLimit2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbLimit2.Location = new System.Drawing.Point(281, 136);
            this.tbLimit2.Margin = new System.Windows.Forms.Padding(2);
            this.tbLimit2.Name = "tbLimit2";
            this.tbLimit2.Size = new System.Drawing.Size(80, 22);
            this.tbLimit2.TabIndex = 0;
            this.tbLimit2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // cmDoIt2
            // 
            this.cmDoIt2.Location = new System.Drawing.Point(238, 203);
            this.cmDoIt2.Margin = new System.Windows.Forms.Padding(2);
            this.cmDoIt2.Name = "cmDoIt2";
            this.cmDoIt2.Size = new System.Drawing.Size(133, 63);
            this.cmDoIt2.TabIndex = 4;
            this.cmDoIt2.Text = "Atskaite par gadu (fiz. pers.)";
            this.cmDoIt2.UseVisualStyleBackColor = true;
            this.cmDoIt2.Click += new System.EventHandler(this.cmDoIt2_Click);
            this.cmDoIt2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // FormRep_SkaidraNauda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 280);
            this.CloseOnEscape = true;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmDoIt2);
            this.Controls.Add(this.cmDoIt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbED);
            this.Controls.Add(this.tbLimit2);
            this.Controls.Add(this.tbLimit1);
            this.Controls.Add(this.tbSD);
            this.Name = "FormRep_SkaidraNauda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Skaidras naudas darijumi";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MyTextBox tbLimit1;
        private MyTextBox tbLimit2;
        private System.Windows.Forms.Button cmDoIt2;
    }
}