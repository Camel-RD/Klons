namespace KlonsP.Forms
{
    partial class Form_ReplacePart
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbDate = new KlonsLIB.Components.MyTextBox();
            this.bsData = new KlonsLIB.Data.MyBindingSourceToObj(this.components);
            this.replacePartData1 = new DataObjectsP.ReplacePartData();
            this.label2 = new System.Windows.Forms.Label();
            this.tbValue = new KlonsLIB.Components.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDescr = new KlonsLIB.Components.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMtUsed = new KlonsLIB.Components.MyTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDeprec = new KlonsLIB.Components.MyTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbValueLeft = new KlonsLIB.Components.MyTextBox();
            this.cmCalc = new System.Windows.Forms.Button();
            this.cmAddEvent = new System.Windows.Forms.Button();
            this.cmClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDoc = new KlonsLIB.Components.MyTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Datums:";
            // 
            // tbDate
            // 
            this.tbDate.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsData, "fDATE", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "dd.MM.yyyy"));
            this.tbDate.IsDate = true;
            this.tbDate.Location = new System.Drawing.Point(88, 13);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(80, 22);
            this.tbDate.TabIndex = 0;
            this.tbDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // bsData
            // 
            this.bsData.AllowNew = false;
            this.bsData.MyDataSource = this.replacePartData1;
            this.bsData.Position = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Vērtība:";
            // 
            // tbValue
            // 
            this.tbValue.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsData, "fValue", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.tbValue.Location = new System.Drawing.Point(261, 15);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(80, 22);
            this.tbValue.TabIndex = 1;
            this.tbValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Apraksts:";
            // 
            // tbDescr
            // 
            this.tbDescr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDescr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsData, "fDescr", true));
            this.tbDescr.Location = new System.Drawing.Point(88, 68);
            this.tbDescr.Multiline = true;
            this.tbDescr.Name = "tbDescr";
            this.tbDescr.Size = new System.Drawing.Size(253, 93);
            this.tbDescr.TabIndex = 6;
            this.tbDescr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nolietojuma periods (mēneši)";
            // 
            // tbMtUsed
            // 
            this.tbMtUsed.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbMtUsed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsData, "fMtUsed", true));
            this.tbMtUsed.Location = new System.Drawing.Point(222, 167);
            this.tbMtUsed.Name = "tbMtUsed";
            this.tbMtUsed.ReadOnly = true;
            this.tbMtUsed.Size = new System.Drawing.Size(47, 22);
            this.tbMtUsed.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Perioda nolietojums:";
            // 
            // tbDeprec
            // 
            this.tbDeprec.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDeprec.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsData, "fDeprec", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.tbDeprec.Location = new System.Drawing.Point(222, 195);
            this.tbDeprec.Name = "tbDeprec";
            this.tbDeprec.ReadOnly = true;
            this.tbDeprec.Size = new System.Drawing.Size(80, 22);
            this.tbDeprec.TabIndex = 8;
            this.tbDeprec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Nenolietotā vērtība:";
            // 
            // tbValueLeft
            // 
            this.tbValueLeft.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbValueLeft.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsData, "fValueLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.tbValueLeft.Location = new System.Drawing.Point(222, 223);
            this.tbValueLeft.Name = "tbValueLeft";
            this.tbValueLeft.ReadOnly = true;
            this.tbValueLeft.Size = new System.Drawing.Size(80, 22);
            this.tbValueLeft.TabIndex = 9;
            this.tbValueLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmCalc
            // 
            this.cmCalc.Location = new System.Drawing.Point(358, 14);
            this.cmCalc.Name = "cmCalc";
            this.cmCalc.Size = new System.Drawing.Size(93, 37);
            this.cmCalc.TabIndex = 3;
            this.cmCalc.Text = "Aprēķināt";
            this.cmCalc.UseVisualStyleBackColor = true;
            this.cmCalc.Click += new System.EventHandler(this.cmCalc_Click);
            this.cmCalc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // cmAddEvent
            // 
            this.cmAddEvent.Location = new System.Drawing.Point(358, 68);
            this.cmAddEvent.Name = "cmAddEvent";
            this.cmAddEvent.Size = new System.Drawing.Size(93, 50);
            this.cmAddEvent.TabIndex = 4;
            this.cmAddEvent.Text = "Pievienot notikumu";
            this.cmAddEvent.UseVisualStyleBackColor = true;
            this.cmAddEvent.Click += new System.EventHandler(this.cmAddEvent_Click);
            this.cmAddEvent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // cmClose
            // 
            this.cmClose.Location = new System.Drawing.Point(358, 135);
            this.cmClose.Name = "cmClose";
            this.cmClose.Size = new System.Drawing.Size(93, 37);
            this.cmClose.TabIndex = 5;
            this.cmClose.Text = "Aizvērt";
            this.cmClose.UseVisualStyleBackColor = true;
            this.cmClose.Click += new System.EventHandler(this.cmClose_Click);
            this.cmClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Attaisnojuma dok.:";
            // 
            // tbDoc
            // 
            this.tbDoc.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDoc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsData, "fDoc", true));
            this.tbDoc.Location = new System.Drawing.Point(149, 41);
            this.tbDoc.Name = "tbDoc";
            this.tbDoc.Size = new System.Drawing.Size(192, 22);
            this.tbDoc.TabIndex = 2;
            this.tbDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // Form_ReplacePart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 253);
            this.Controls.Add(this.cmAddEvent);
            this.Controls.Add(this.cmClose);
            this.Controls.Add(this.cmCalc);
            this.Controls.Add(this.tbDescr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMtUsed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbValueLeft);
            this.Controls.Add(this.tbDeprec);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDoc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.label1);
            this.Name = "Form_ReplacePart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Amortizētās aizstāšanas izmaksas";
            this.Load += new System.EventHandler(this.Form_ReplacePart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyTextBox tbDate;
        private System.Windows.Forms.Label label2;
        private KlonsLIB.Components.MyTextBox tbValue;
        private System.Windows.Forms.Label label3;
        private KlonsLIB.Components.MyTextBox tbDescr;
        private System.Windows.Forms.Label label4;
        private KlonsLIB.Components.MyTextBox tbMtUsed;
        private System.Windows.Forms.Label label5;
        private KlonsLIB.Components.MyTextBox tbDeprec;
        private System.Windows.Forms.Label label6;
        private KlonsLIB.Components.MyTextBox tbValueLeft;
        private System.Windows.Forms.Button cmCalc;
        private System.Windows.Forms.Button cmAddEvent;
        private System.Windows.Forms.Button cmClose;
        private KlonsLIB.Data.MyBindingSourceToObj bsData;
        public DataObjectsP.ReplacePartData replacePartData1;
        private System.Windows.Forms.Label label7;
        private KlonsLIB.Components.MyTextBox tbDoc;
    }
}