namespace KlonsA.Forms
{
    partial class FormRep_Zinas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRep_Zinas));
            this.dgvRep = new KlonsLIB.Components.MyDataGridView();
            this.dgcPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcOccCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsRep = new System.Windows.Forms.BindingSource(this.components);
            this.tbDate1 = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDate2 = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmTable = new System.Windows.Forms.Button();
            this.cmReport = new System.Windows.Forms.Button();
            this.tbName = new KlonsLIB.Components.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPosition = new KlonsLIB.Components.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDate = new KlonsLIB.Components.MyTextBox();
            this.tbPhoneNr = new KlonsLIB.Components.MyTextBox();
            this.cmXML = new System.Windows.Forms.Button();
            this.bnRows = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnRows)).BeginInit();
            this.bnRows.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRep
            // 
            this.dgvRep.AutoGenerateColumns = false;
            this.dgvRep.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRep.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcPK,
            this.dgcName,
            this.dgcDate,
            this.dgcCode,
            this.dgcCountry,
            this.dgcOccCode,
            this.dgcNr});
            this.dgvRep.DataSource = this.bsRep;
            this.dgvRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRep.Location = new System.Drawing.Point(0, 80);
            this.dgvRep.Name = "dgvRep";
            this.dgvRep.RowTemplate.Height = 24;
            this.dgvRep.Size = new System.Drawing.Size(692, 247);
            this.dgvRep.TabIndex = 8;
            // 
            // dgcPK
            // 
            this.dgcPK.DataPropertyName = "PK";
            this.dgcPK.HeaderText = "Personas kods";
            this.dgcPK.Name = "dgcPK";
            this.dgcPK.Width = 110;
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "Name";
            this.dgcName.HeaderText = "Vārds, uzvārds";
            this.dgcName.Name = "dgcName";
            this.dgcName.Width = 140;
            // 
            // dgcDate
            // 
            this.dgcDate.DataPropertyName = "Date";
            this.dgcDate.HeaderText = "Datums";
            this.dgcDate.Name = "dgcDate";
            this.dgcDate.Width = 90;
            // 
            // dgcCode
            // 
            this.dgcCode.DataPropertyName = "Code";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcCode.HeaderText = "Ziņu kods";
            this.dgcCode.Name = "dgcCode";
            this.dgcCode.Width = 60;
            // 
            // dgcCountry
            // 
            this.dgcCountry.DataPropertyName = "Country";
            this.dgcCountry.HeaderText = "Valsts";
            this.dgcCountry.Name = "dgcCountry";
            this.dgcCountry.Width = 60;
            // 
            // dgcOccCode
            // 
            this.dgcOccCode.DataPropertyName = "ProfessionCode";
            this.dgcOccCode.HeaderText = "Profesijas kods";
            this.dgcOccCode.Name = "dgcOccCode";
            this.dgcOccCode.Width = 80;
            // 
            // dgcNr
            // 
            this.dgcNr.DataPropertyName = "Nr";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgcNr.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcNr.HeaderText = "Npk.";
            this.dgcNr.Name = "dgcNr";
            this.dgcNr.Visible = false;
            this.dgcNr.Width = 50;
            // 
            // tbDate1
            // 
            this.tbDate1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate1.IsDate = true;
            this.tbDate1.Location = new System.Drawing.Point(136, 7);
            this.tbDate1.Name = "tbDate1";
            this.tbDate1.Size = new System.Drawing.Size(90, 22);
            this.tbDate1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Datums, no - līdz:";
            // 
            // tbDate2
            // 
            this.tbDate2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate2.IsDate = true;
            this.tbDate2.Location = new System.Drawing.Point(242, 7);
            this.tbDate2.Name = "tbDate2";
            this.tbDate2.Size = new System.Drawing.Size(90, 22);
            this.tbDate2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "-";
            // 
            // cmTable
            // 
            this.cmTable.Location = new System.Drawing.Point(414, 1);
            this.cmTable.Name = "cmTable";
            this.cmTable.Size = new System.Drawing.Size(67, 30);
            this.cmTable.TabIndex = 2;
            this.cmTable.Text = "Atlasīt";
            this.cmTable.UseVisualStyleBackColor = true;
            this.cmTable.Click += new System.EventHandler(this.cmTable_Click);
            // 
            // cmReport
            // 
            this.cmReport.Location = new System.Drawing.Point(487, 1);
            this.cmReport.Name = "cmReport";
            this.cmReport.Size = new System.Drawing.Size(67, 30);
            this.cmReport.TabIndex = 3;
            this.cmReport.Text = "Atskaite";
            this.cmReport.UseVisualStyleBackColor = true;
            this.cmReport.Click += new System.EventHandler(this.cmReport_Click);
            // 
            // tbName
            // 
            this.tbName.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbName.Location = new System.Drawing.Point(136, 31);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(126, 22);
            this.tbName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Vārds, uzvārds:";
            // 
            // tbPosition
            // 
            this.tbPosition.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbPosition.Location = new System.Drawing.Point(335, 31);
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(126, 22);
            this.tbPosition.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Amats:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Datums:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tālruņa numurs:";
            // 
            // tbDate
            // 
            this.tbDate.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDate.IsDate = true;
            this.tbDate.Location = new System.Drawing.Point(335, 55);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(90, 22);
            this.tbDate.TabIndex = 7;
            // 
            // tbPhoneNr
            // 
            this.tbPhoneNr.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbPhoneNr.Location = new System.Drawing.Point(136, 55);
            this.tbPhoneNr.Name = "tbPhoneNr";
            this.tbPhoneNr.Size = new System.Drawing.Size(105, 22);
            this.tbPhoneNr.TabIndex = 6;
            // 
            // cmXML
            // 
            this.cmXML.Location = new System.Drawing.Point(560, 1);
            this.cmXML.Name = "cmXML";
            this.cmXML.Size = new System.Drawing.Size(67, 30);
            this.cmXML.TabIndex = 3;
            this.cmXML.Text = "XML";
            this.cmXML.UseVisualStyleBackColor = true;
            this.cmXML.Click += new System.EventHandler(this.cmXML_Click);
            // 
            // bnRows
            // 
            this.bnRows.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnRows.BindingSource = this.bsRep;
            this.bnRows.CountItem = this.bindingNavigatorCountItem;
            this.bnRows.CountItemFormat = " no {0}";
            this.bnRows.DataGrid = this.dgvRep;
            this.bnRows.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnRows.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnRows.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnRows.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bnRows.Location = new System.Drawing.Point(0, 327);
            this.bnRows.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnRows.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnRows.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnRows.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnRows.Name = "bnRows";
            this.bnRows.PositionItem = this.bindingNavigatorPositionItem;
            this.bnRows.SaveItem = null;
            this.bnRows.Size = new System.Drawing.Size(692, 32);
            this.bnRows.TabIndex = 15;
            this.bnRows.Text = "myBindingNavigator1";
            this.bnRows.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnRows_ItemDeleting);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(91, 29);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(69, 29);
            this.bindingNavigatorCountItem.Text = " no {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Ierakstu skaits";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(87, 29);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMoveFirstItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMovePreviousItem.Text = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 32);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 30);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Pašreizējā pozīcija";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMoveNextItem.Text = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(25, 29);
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbDate1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbPosition);
            this.panel1.Controls.Add(this.tbDate);
            this.panel1.Controls.Add(this.tbDate2);
            this.panel1.Controls.Add(this.tbPhoneNr);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmXML);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmReport);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 80);
            this.panel1.TabIndex = 16;
            // 
            // FormRep_Zinas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 359);
            this.Controls.Add(this.dgvRep);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bnRows);
            this.Name = "FormRep_Zinas";
            this.Text = "Ziņas par darba ņēmējiem";
            this.Load += new System.EventHandler(this.FormRep_Zinas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnRows)).EndInit();
            this.bnRows.ResumeLayout(false);
            this.bnRows.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.Components.MyDataGridView dgvRep;
        private KlonsLIB.Components.MyTextBox tbDate1;
        private System.Windows.Forms.Label label1;
        private KlonsLIB.Components.MyTextBox tbDate2;
        private System.Windows.Forms.BindingSource bsRep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmTable;
        private System.Windows.Forms.Button cmReport;
        private KlonsLIB.Components.MyTextBox tbName;
        private System.Windows.Forms.Label label3;
        private KlonsLIB.Components.MyTextBox tbPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private KlonsLIB.Components.MyTextBox tbDate;
        private KlonsLIB.Components.MyTextBox tbPhoneNr;
        private System.Windows.Forms.Button cmXML;
        private KlonsLIB.Components.MyBindingNavigator bnRows;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcOccCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcNr;
    }
}