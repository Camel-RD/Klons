using KlonsLIB.Components;

namespace KlonsLIB.Forms
{
    partial class Form_Error
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
            this.tbMsg = new KlonsLIB.Components.MyTextBox();
            this.tbDescr = new KlonsLIB.Components.MyTextBox();
            this.cmClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMsg
            // 
            this.tbMsg.BackColor = System.Drawing.SystemColors.Control;
            this.tbMsg.BorderColor = System.Drawing.SystemColors.Control;
            this.tbMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.tbMsg.Location = new System.Drawing.Point(60, 10);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.ReadOnly = true;
            this.tbMsg.Size = new System.Drawing.Size(348, 100);
            this.tbMsg.TabIndex = 2;
            // 
            // tbDescr
            // 
            this.tbDescr.BackColor = System.Drawing.SystemColors.Control;
            this.tbDescr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDescr.Location = new System.Drawing.Point(3, 120);
            this.tbDescr.Multiline = true;
            this.tbDescr.Name = "tbDescr";
            this.tbDescr.ReadOnly = true;
            this.tbDescr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDescr.Size = new System.Drawing.Size(507, 186);
            this.tbDescr.TabIndex = 3;
            this.tbDescr.WordWrap = false;
            // 
            // cmClose
            // 
            this.cmClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmClose.Location = new System.Drawing.Point(421, 8);
            this.cmClose.Name = "cmClose";
            this.cmClose.Size = new System.Drawing.Size(87, 35);
            this.cmClose.TabIndex = 0;
            this.cmClose.Text = "Aizvērt";
            this.cmClose.UseVisualStyleBackColor = true;
            this.cmClose.Click += new System.EventHandler(this.cmClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KlonsLIB.Properties.Resources.error3;
            this.pictureBox1.Location = new System.Drawing.Point(5, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // cmDetails
            // 
            this.cmDetails.Location = new System.Drawing.Point(421, 59);
            this.cmDetails.Name = "cmDetails";
            this.cmDetails.Size = new System.Drawing.Size(87, 35);
            this.cmDetails.TabIndex = 1;
            this.cmDetails.Text = "Detaļas";
            this.cmDetails.UseVisualStyleBackColor = true;
            this.cmDetails.Click += new System.EventHandler(this.cmDetails_Click);
            // 
            // Form_Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmClose;
            this.ClientSize = new System.Drawing.Size(514, 310);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmDetails);
            this.Controls.Add(this.cmClose);
            this.Controls.Add(this.tbDescr);
            this.Controls.Add(this.tbMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Error";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kļūda!";
            this.Load += new System.EventHandler(this.FormError_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyTextBox tbMsg;
        private MyTextBox tbDescr;
        private System.Windows.Forms.Button cmClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmDetails;
    }
}