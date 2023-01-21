
namespace KlonsFM.FormsM
{
    partial class FormM_SPRunner
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbTaskText = new System.Windows.Forms.Label();
            this.lbWait = new System.Windows.Forms.Label();
            this.btDoIt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(34, 95);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(337, 22);
            this.progressBar1.TabIndex = 0;
            // 
            // lbTaskText
            // 
            this.lbTaskText.AutoSize = true;
            this.lbTaskText.Location = new System.Drawing.Point(12, 9);
            this.lbTaskText.MaximumSize = new System.Drawing.Size(390, 100);
            this.lbTaskText.Name = "lbTaskText";
            this.lbTaskText.Size = new System.Drawing.Size(226, 40);
            this.lbTaskText.TabIndex = 1;
            this.lbTaskText.Text = "fdsfdsafsd dsfa s\r\ndsfsaf sfsaf dsfs fs afsafs fsa f";
            // 
            // lbWait
            // 
            this.lbWait.AutoSize = true;
            this.lbWait.Location = new System.Drawing.Point(29, 63);
            this.lbWait.Name = "lbWait";
            this.lbWait.Size = new System.Drawing.Size(21, 20);
            this.lbWait.TabIndex = 2;
            this.lbWait.Text = "...";
            // 
            // btDoIt
            // 
            this.btDoIt.Location = new System.Drawing.Point(137, 129);
            this.btDoIt.Name = "btDoIt";
            this.btDoIt.Size = new System.Drawing.Size(116, 44);
            this.btDoIt.TabIndex = 3;
            this.btDoIt.Text = "Sākt";
            this.btDoIt.UseVisualStyleBackColor = true;
            this.btDoIt.Click += new System.EventHandler(this.btDoIt_Click);
            // 
            // FormM_SPRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 182);
            this.Controls.Add(this.btDoIt);
            this.Controls.Add(this.lbWait);
            this.Controls.Add(this.lbTaskText);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormM_SPRunner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Darbību izpilde";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormM_SPRunner_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormM_SPRunner_FormClosed);
            this.Load += new System.EventHandler(this.FormM_SPRunner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbTaskText;
        private System.Windows.Forms.Label lbWait;
        private System.Windows.Forms.Button btDoIt;
    }
}