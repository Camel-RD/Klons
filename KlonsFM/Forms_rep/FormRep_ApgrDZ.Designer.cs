using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsFM.FormsReportParams
{
    partial class FormRep_ApgrDZ
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
            this.cmDoIt.Location = new System.Drawing.Point(293, 91);
            this.cmDoIt.Margin = new System.Windows.Forms.Padding(2);
            this.cmDoIt.Name = "cmDoIt";
            this.cmDoIt.Size = new System.Drawing.Size(133, 63);
            this.cmDoIt.TabIndex = 4;
            this.cmDoIt.Text = "Taisīt atskaiti";
            this.cmDoIt.UseVisualStyleBackColor = true;
            this.cmDoIt.Click += new System.EventHandler(this.cmDoIt_Click);
            this.cmDoIt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // FormRep_ApgrDZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 276);
            this.CloseOnEscape = true;
            this.Controls.Add(this.cmDoIt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbED);
            this.Controls.Add(this.tbSD);
            this.Name = "FormRep_ApgrDZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apgrozijumu pārskats: darijumu žurnāls";
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
    }
}