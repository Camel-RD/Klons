namespace KlonsA.Forms
{
    partial class Form_Calendar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbYR = new KlonsLIB.Components.MyMcFlatComboBox();
            this.grid = new KlonsA.Classes.SourceGridA();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbYR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 27);
            this.panel1.TabIndex = 0;
            // 
            // cbYR
            // 
            this.cbYR.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbYR.ColumnNames = new string[] {
        "Key",
        "Val"};
            this.cbYR.ColumnWidths = "0;100";
            this.cbYR.DisplayMember = "Val";
            this.cbYR.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbYR.DropDownHeight = 170;
            this.cbYR.DropDownWidth = 124;
            this.cbYR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbYR.FormattingEnabled = true;
            this.cbYR.GridLineColor = System.Drawing.Color.LightGray;
            this.cbYR.GridLineHorizontal = false;
            this.cbYR.GridLineVertical = false;
            this.cbYR.IntegralHeight = false;
            this.cbYR.Location = new System.Drawing.Point(86, 2);
            this.cbYR.MaxDropDownItems = 10;
            this.cbYR.Name = "cbYR";
            this.cbYR.Size = new System.Drawing.Size(111, 23);
            this.cbYR.TabIndex = 1;
            this.cbYR.ValueMember = "Key";
            this.cbYR.SelectedIndexChanged += new System.EventHandler(this.cbYR_SelectedIndexChanged);
            this.cbYR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbYR_KeyDown);
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EnableSort = true;
            this.grid.Location = new System.Drawing.Point(0, 27);
            this.grid.Name = "grid";
            this.grid.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid.Size = new System.Drawing.Size(800, 423);
            this.grid.TabIndex = 1;
            this.grid.TabStop = true;
            this.grid.ToolTipText = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gads:";
            // 
            // Form_Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Calendar";
            this.Text = "Kalendārs";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Components.MyMcFlatComboBox cbYR;
        private Classes.SourceGridA grid;
        private System.Windows.Forms.Label label1;
    }
}