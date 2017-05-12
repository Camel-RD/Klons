namespace KlonsA.Forms
{
    partial class Form_PersonNewPos
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
            this.components = new System.ComponentModel.Container();
            this.bsDep = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cbDep = new KlonsLIB.Components.MyMcFlatComboBox();
            this.cmCancel = new System.Windows.Forms.Button();
            this.cmOK = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPosition = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new KlonsLIB.Components.MyTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).BeginInit();
            this.SuspendLayout();
            // 
            // bsDep
            // 
            this.bsDep.DataMember = "DEPARTMENTS";
            this.bsDep.MyDataSource = "KlonsData";
            this.bsDep.Name2 = null;
            this.bsDep.Sort = "ID";
            // 
            // cbDep
            // 
            this.cbDep._AllowSelection = true;
            this.cbDep.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbDep.ColumnNames = new string[] {
        "ID",
        "DESCR"};
            this.cbDep.ColumnWidths = "80;300";
            this.cbDep.DataSource = this.bsDep;
            this.cbDep.DisplayMember = "ID";
            this.cbDep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDep.DropDownHeight = 255;
            this.cbDep.DropDownWidth = 404;
            this.cbDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDep.FormattingEnabled = true;
            this.cbDep.GridLineColor = System.Drawing.Color.LightGray;
            this.cbDep.GridLineHorizontal = false;
            this.cbDep.GridLineVertical = false;
            this.cbDep.IntegralHeight = false;
            this.cbDep.Location = new System.Drawing.Point(143, 72);
            this.cbDep.MaxDropDownItems = 15;
            this.cbDep.Name = "cbDep";
            this.cbDep.Size = new System.Drawing.Size(162, 23);
            this.cbDep.TabIndex = 2;
            this.cbDep.ValueMember = "ID";
            this.cbDep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(293, 118);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(83, 37);
            this.cmCancel.TabIndex = 4;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            this.cmCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // cmOK
            // 
            this.cmOK.Location = new System.Drawing.Point(204, 118);
            this.cmOK.Name = "cmOK";
            this.cmOK.Size = new System.Drawing.Size(83, 37);
            this.cmOK.TabIndex = 3;
            this.cmOK.Text = "Pievienot";
            this.cmOK.UseVisualStyleBackColor = true;
            this.cmOK.Click += new System.EventHandler(this.cmOK_Click);
            this.cmOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Struktūrvienība:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Amats:";
            // 
            // tbPosition
            // 
            this.tbPosition.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbPosition.Location = new System.Drawing.Point(143, 44);
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(163, 22);
            this.tbPosition.TabIndex = 1;
            this.tbPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Darbinieks:";
            // 
            // tbName
            // 
            this.tbName.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbName.Location = new System.Drawing.Point(142, 7);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(216, 22);
            this.tbName.TabIndex = 0;
            // 
            // Form_PersonNewPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 160);
            this.Controls.Add(this.cbDep);
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmOK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbPosition);
            this.Name = "Form_PersonNewPos";
            this.Text = "Jauns amats";
            this.Load += new System.EventHandler(this.Form_PersonsNewPos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsDep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Data.MyBindingSource bsDep;
        private KlonsLIB.Components.MyMcFlatComboBox cbDep;
        private System.Windows.Forms.Button cmCancel;
        private System.Windows.Forms.Button cmOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private KlonsLIB.Components.MyTextBox tbPosition;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyTextBox tbName;
    }
}