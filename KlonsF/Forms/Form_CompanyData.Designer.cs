namespace KlonsF.Forms
{
    partial class Form_CompanyData
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
            this.pgData = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // pgData
            // 
            this.pgData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pgData.BackColor = System.Drawing.SystemColors.Control;
            this.pgData.HelpVisible = false;
            this.pgData.LineColor = System.Drawing.SystemColors.ControlDark;
            this.pgData.Location = new System.Drawing.Point(0, 0);
            this.pgData.Name = "pgData";
            this.pgData.Size = new System.Drawing.Size(730, 398);
            this.pgData.TabIndex = 3;
            this.pgData.ToolbarVisible = false;
            this.pgData.ViewBackColor = System.Drawing.SystemColors.Control;
            // 
            // Form_CompanyData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 398);
            this.CloseOnEscape = true;
            this.Controls.Add(this.pgData);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_CompanyData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Ziņas par uzņēmumu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCompanyData_FormClosing);
            this.Load += new System.EventHandler(this.FormCompanyData_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgData;
    }
}