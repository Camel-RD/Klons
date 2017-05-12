using KlonsLIB.Components;

namespace KlonsP.Forms
{
    partial class Form_UserPSW
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
            this.myTextBox1 = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmOK = new System.Windows.Forms.Button();
            this.cmCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // myTextBox1
            // 
            this.myTextBox1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.myTextBox1.Location = new System.Drawing.Point(42, 34);
            this.myTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.Size = new System.Drawing.Size(144, 22);
            this.myTextBox1.TabIndex = 0;
            this.myTextBox1.Leave += new System.EventHandler(this.myTextBox1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Jaunā parole:";
            // 
            // cmOK
            // 
            this.cmOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmOK.Location = new System.Drawing.Point(216, 14);
            this.cmOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmOK.Name = "cmOK";
            this.cmOK.Size = new System.Drawing.Size(78, 27);
            this.cmOK.TabIndex = 1;
            this.cmOK.Text = "OK";
            this.cmOK.UseVisualStyleBackColor = true;
            this.cmOK.Click += new System.EventHandler(this.cmOK_Click);
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(216, 54);
            this.cmCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(78, 27);
            this.cmCancel.TabIndex = 2;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            // 
            // Form_UserPSW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 90);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_UserPSW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nomainīt paroli";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyTextBox myTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmOK;
        private System.Windows.Forms.Button cmCancel;
    }
}