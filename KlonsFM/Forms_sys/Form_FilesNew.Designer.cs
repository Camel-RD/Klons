using KlonsLIB.Components;

namespace KlonsFM.Forms
{
    partial class Form_FilesNew
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
            this.tbName = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmOK = new System.Windows.Forms.Button();
            this.tbDescr = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbName.Location = new System.Drawing.Point(36, 38);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(148, 22);
            this.tbName.TabIndex = 0;
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nosaukums (kods):";
            // 
            // cmOK
            // 
            this.cmOK.Location = new System.Drawing.Point(36, 130);
            this.cmOK.Margin = new System.Windows.Forms.Padding(2);
            this.cmOK.Name = "cmOK";
            this.cmOK.Size = new System.Drawing.Size(90, 45);
            this.cmOK.TabIndex = 2;
            this.cmOK.Text = "Izveidot";
            this.cmOK.UseVisualStyleBackColor = true;
            this.cmOK.Click += new System.EventHandler(this.cmOK_Click);
            this.cmOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // tbDescr
            // 
            this.tbDescr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDescr.Location = new System.Drawing.Point(36, 91);
            this.tbDescr.Margin = new System.Windows.Forms.Padding(2);
            this.tbDescr.Name = "tbDescr";
            this.tbDescr.Size = new System.Drawing.Size(259, 22);
            this.tbDescr.TabIndex = 1;
            this.tbDescr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Apraksts:";
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(149, 130);
            this.cmCancel.Margin = new System.Windows.Forms.Padding(2);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(90, 45);
            this.cmCancel.TabIndex = 3;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            this.cmCancel.Click += new System.EventHandler(this.cmCancel_Click);
            this.cmCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // Form_FilesNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 195);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDescr);
            this.Controls.Add(this.tbName);
            this.Name = "Form_FilesNew";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jauna datu bāze";
            this.Load += new System.EventHandler(this.Form_FilesNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyTextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmOK;
        private MyTextBox tbDescr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmCancel;
    }
}