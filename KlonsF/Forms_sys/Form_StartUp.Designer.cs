using KlonsLIB.Components;
using KlonsF.UI;

namespace KlonsF.Forms
{
    partial class Form_StartUp
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmConnect = new System.Windows.Forms.Button();
            this.cmChange = new System.Windows.Forms.Button();
            this.cmExit = new System.Windows.Forms.Button();
            this.cmUsers = new System.Windows.Forms.Button();
            this.tbPSW = new KlonsLIB.Components.MyTextBox();
            this.tbUser = new KlonsLIB.Components.MyTextBox();
            this.lbFile = new KlonsLIB.Components.MyLabel();
            this.lbDescr = new KlonsLIB.Components.MyLabel();
            this.lbNane = new KlonsLIB.Components.MyLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Datu bāze:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Apraksts:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fials:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 157);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Lietotāja vārds:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 184);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Parole:";
            // 
            // cmConnect
            // 
            this.cmConnect.Location = new System.Drawing.Point(20, 218);
            this.cmConnect.Margin = new System.Windows.Forms.Padding(2);
            this.cmConnect.Name = "cmConnect";
            this.cmConnect.Size = new System.Drawing.Size(90, 49);
            this.cmConnect.TabIndex = 8;
            this.cmConnect.Text = "Pieslēgties";
            this.cmConnect.UseVisualStyleBackColor = false;
            this.cmConnect.Click += new System.EventHandler(this.cmConnect_Click);
            // 
            // cmChange
            // 
            this.cmChange.Location = new System.Drawing.Point(127, 218);
            this.cmChange.Margin = new System.Windows.Forms.Padding(2);
            this.cmChange.Name = "cmChange";
            this.cmChange.Size = new System.Drawing.Size(90, 49);
            this.cmChange.TabIndex = 8;
            this.cmChange.Text = "Nomainīt datubāzi";
            this.cmChange.UseVisualStyleBackColor = false;
            this.cmChange.Click += new System.EventHandler(this.cmChange_Click);
            // 
            // cmExit
            // 
            this.cmExit.Location = new System.Drawing.Point(234, 218);
            this.cmExit.Margin = new System.Windows.Forms.Padding(2);
            this.cmExit.Name = "cmExit";
            this.cmExit.Size = new System.Drawing.Size(90, 49);
            this.cmExit.TabIndex = 8;
            this.cmExit.Text = "Iziet";
            this.cmExit.UseVisualStyleBackColor = false;
            this.cmExit.Click += new System.EventHandler(this.cmExit_Click);
            // 
            // cmUsers
            // 
            this.cmUsers.AutoSize = true;
            this.cmUsers.Location = new System.Drawing.Point(267, 155);
            this.cmUsers.Margin = new System.Windows.Forms.Padding(2);
            this.cmUsers.Name = "cmUsers";
            this.cmUsers.Size = new System.Drawing.Size(34, 26);
            this.cmUsers.TabIndex = 8;
            this.cmUsers.Text = ">>";
            this.cmUsers.UseVisualStyleBackColor = false;
            this.cmUsers.Click += new System.EventHandler(this.cmUsers_Click);
            // 
            // tbPSW
            // 
            this.tbPSW.BorderColor = System.Drawing.SystemColors.ControlText;
            this.tbPSW.Location = new System.Drawing.Point(123, 182);
            this.tbPSW.Margin = new System.Windows.Forms.Padding(2);
            this.tbPSW.Name = "tbPSW";
            this.tbPSW.Size = new System.Drawing.Size(140, 22);
            this.tbPSW.TabIndex = 7;
            // 
            // tbUser
            // 
            this.tbUser.BorderColor = System.Drawing.SystemColors.ControlText;
            this.tbUser.Location = new System.Drawing.Point(123, 155);
            this.tbUser.Margin = new System.Windows.Forms.Padding(2);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(140, 22);
            this.tbUser.TabIndex = 7;
            // 
            // lbFile
            // 
            this.lbFile.BorderColor = System.Drawing.SystemColors.ControlText;
            this.lbFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbFile.Location = new System.Drawing.Point(92, 106);
            this.lbFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFile.Name = "lbFile";
            this.lbFile.Padding = new System.Windows.Forms.Padding(2);
            this.lbFile.Size = new System.Drawing.Size(245, 36);
            this.lbFile.TabIndex = 5;
            this.lbFile.Text = "asdfdas fdas";
            // 
            // lbDescr
            // 
            this.lbDescr.BorderColor = System.Drawing.SystemColors.ControlText;
            this.lbDescr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbDescr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbDescr.Location = new System.Drawing.Point(92, 53);
            this.lbDescr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDescr.Name = "lbDescr";
            this.lbDescr.Padding = new System.Windows.Forms.Padding(2);
            this.lbDescr.Size = new System.Drawing.Size(245, 36);
            this.lbDescr.TabIndex = 3;
            this.lbDescr.Text = "asdfdas fdas\r\nf dsa";
            // 
            // lbNane
            // 
            this.lbNane.BorderColor = System.Drawing.SystemColors.ControlText;
            this.lbNane.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbNane.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbNane.Location = new System.Drawing.Point(92, 15);
            this.lbNane.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNane.Name = "lbNane";
            this.lbNane.Padding = new System.Windows.Forms.Padding(2);
            this.lbNane.Size = new System.Drawing.Size(245, 20);
            this.lbNane.TabIndex = 1;
            this.lbNane.Text = "myLabel2";
            // 
            // Form_StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 275);
            this.Controls.Add(this.cmUsers);
            this.Controls.Add(this.cmExit);
            this.Controls.Add(this.cmChange);
            this.Controls.Add(this.cmConnect);
            this.Controls.Add(this.tbPSW);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbDescr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbNane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_StartUp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pieslēgties";
            this.Load += new System.EventHandler(this.FormStartUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyLabel lbNane;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MyLabel lbDescr;
        private System.Windows.Forms.Label label3;
        private MyLabel lbFile;
        private System.Windows.Forms.Label label4;
        private MyTextBox tbUser;
        private System.Windows.Forms.Label label5;
        private MyTextBox tbPSW;
        private System.Windows.Forms.Button cmConnect;
        private System.Windows.Forms.Button cmChange;
        private System.Windows.Forms.Button cmExit;
        private System.Windows.Forms.Button cmUsers;
    }
}