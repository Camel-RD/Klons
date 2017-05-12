namespace KlonsP.Forms
{
    partial class Form_Items_NewEvent
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbEvent = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsEvents = new KlonsLIB.Data.MyBindingSource(this.components);
            this.cmOK = new System.Windows.Forms.Button();
            this.cmCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Notikuma datums:";
            // 
            // tbDate
            // 
            this.tbDate.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate.IsDate = true;
            this.tbDate.Location = new System.Drawing.Point(138, 21);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(80, 22);
            this.tbDate.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Notikums:";
            // 
            // cbEvent
            // 
            this.cbEvent.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbEvent.ColumnNames = new string[] {
        "CODE",
        "DESCR"};
            this.cbEvent.ColumnWidths = "100;300";
            this.cbEvent.DataSource = this.bsEvents;
            this.cbEvent.DisplayMember = "DESCR";
            this.cbEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEvent.DropDownHeight = 255;
            this.cbEvent.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbEvent.DropDownWidth = 424;
            this.cbEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEvent.FormattingEnabled = true;
            this.cbEvent.GridLineColor = System.Drawing.Color.LightGray;
            this.cbEvent.GridLineHorizontal = false;
            this.cbEvent.GridLineVertical = false;
            this.cbEvent.IntegralHeight = false;
            this.cbEvent.Location = new System.Drawing.Point(138, 53);
            this.cbEvent.MaxDropDownItems = 15;
            this.cbEvent.Name = "cbEvent";
            this.cbEvent.Size = new System.Drawing.Size(258, 23);
            this.cbEvent.TabIndex = 1;
            this.cbEvent.ValueMember = "ID";
            // 
            // bsEvents
            // 
            this.bsEvents.DataMember = "EVENTS";
            this.bsEvents.Filter = "K1 = 1";
            this.bsEvents.MyDataSource = "KlonsData";
            this.bsEvents.Name2 = null;
            this.bsEvents.Sort = "ID";
            // 
            // cmOK
            // 
            this.cmOK.Location = new System.Drawing.Point(200, 97);
            this.cmOK.Name = "cmOK";
            this.cmOK.Size = new System.Drawing.Size(82, 39);
            this.cmOK.TabIndex = 2;
            this.cmOK.Text = "OK";
            this.cmOK.UseVisualStyleBackColor = true;
            this.cmOK.Click += new System.EventHandler(this.cmOK_Click);
            // 
            // cmCancel
            // 
            this.cmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmCancel.Location = new System.Drawing.Point(300, 97);
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(82, 39);
            this.cmCancel.TabIndex = 3;
            this.cmCancel.Text = "Atcelt";
            this.cmCancel.UseVisualStyleBackColor = true;
            // 
            // Form_Items_NewEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmCancel;
            this.ClientSize = new System.Drawing.Size(410, 152);
            this.CloseOnEscape = true;
            this.Controls.Add(this.cmCancel);
            this.Controls.Add(this.cmOK);
            this.Controls.Add(this.cbEvent);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Items_NewEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jauns notikums";
            this.Load += new System.EventHandler(this.Form_Items_NewEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyTextBox tbDate;
        private System.Windows.Forms.Label label2;
        private KlonsLIB.Components.MyMcFlatComboBox cbEvent;
        private System.Windows.Forms.Button cmOK;
        private System.Windows.Forms.Button cmCancel;
        private KlonsLIB.Data.MyBindingSource bsEvents;
    }
}