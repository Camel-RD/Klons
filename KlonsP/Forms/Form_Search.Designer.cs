namespace KlonsP.Forms
{
    partial class Form_Search
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
            this.tbText = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmUp = new System.Windows.Forms.Button();
            this.cmDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbText
            // 
            this.tbText.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbText.Location = new System.Drawing.Point(7, 24);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(161, 22);
            this.tbText.TabIndex = 0;
            this.tbText.Enter += new System.EventHandler(this.tbText_Enter);
            this.tbText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbText_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Meklējamais teksts:";
            // 
            // cmUp
            // 
            this.cmUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmUp.Location = new System.Drawing.Point(177, 8);
            this.cmUp.Name = "cmUp";
            this.cmUp.Size = new System.Drawing.Size(37, 38);
            this.cmUp.TabIndex = 1;
            this.cmUp.Text = "↑";
            this.cmUp.UseVisualStyleBackColor = true;
            this.cmUp.Click += new System.EventHandler(this.cmUp_Click);
            // 
            // cmDown
            // 
            this.cmDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmDown.Location = new System.Drawing.Point(220, 8);
            this.cmDown.Name = "cmDown";
            this.cmDown.Size = new System.Drawing.Size(37, 38);
            this.cmDown.TabIndex = 2;
            this.cmDown.Text = "↓";
            this.cmDown.UseVisualStyleBackColor = true;
            this.cmDown.Click += new System.EventHandler(this.cmDown_Click);
            // 
            // Form_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 52);
            this.CloseOnEscape = true;
            this.Controls.Add(this.cmDown);
            this.Controls.Add(this.cmUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Meklēt";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Search_FormClosed);
            this.Load += new System.EventHandler(this.Form_Search_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Components.MyTextBox tbText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmUp;
        private System.Windows.Forms.Button cmDown;
    }
}