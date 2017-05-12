using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.Forms
{
    partial class Form_PVN_Piel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsROps1a = new KlonsLIB.Data.MyBindingSource();
            this.dgvROps1a = new KlonsLIB.Components.MyDataGridView();
            this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRegNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocTyp2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSumm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocTyp1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSummC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDocNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsROps1a)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvROps1a)).BeginInit();
            this.SuspendLayout();
            // 
            // bsROps1a
            // 
            this.bsROps1a.AutoSaveOnDelete = true;
            this.bsROps1a.DataMember = "ROps1a";
            this.bsROps1a.MyDataSource = "KlonsRep";
            this.bsROps1a.Name2 = "bsROps1a";
            // 
            // dgvROps1a
            // 
            this.dgvROps1a.AllowUserToAddRows = false;
            this.dgvROps1a.AllowUserToDeleteRows = false;
            this.dgvROps1a.AutoGenerateColumns = false;
            this.dgvROps1a.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvROps1a.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvROps1a.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcName,
            this.dgcRegNr,
            this.dgcDocTyp2,
            this.dgcSumm,
            this.dgcPVN,
            this.dgcDocTyp1,
            this.dgcCur,
            this.dgcSummC,
            this.dgcDocSt,
            this.dgcDocNr,
            this.dgcDate});
            this.dgvROps1a.DataSource = this.bsROps1a;
            this.dgvROps1a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvROps1a.Location = new System.Drawing.Point(0, 0);
            this.dgvROps1a.Name = "dgvROps1a";
            this.dgvROps1a.ReadOnly = true;
            this.dgvROps1a.RowTemplate.Height = 20;
            this.dgvROps1a.Size = new System.Drawing.Size(867, 385);
            this.dgvROps1a.TabIndex = 1;
            // 
            // dgcName
            // 
            this.dgcName.DataPropertyName = "Name";
            this.dgcName.HeaderText = "nosaukums";
            this.dgcName.Name = "dgcName";
            this.dgcName.ReadOnly = true;
            this.dgcName.Width = 160;
            // 
            // dgcRegNr
            // 
            this.dgcRegNr.DataPropertyName = "RegNr";
            this.dgcRegNr.HeaderText = "PVN reģ.nr.";
            this.dgcRegNr.Name = "dgcRegNr";
            this.dgcRegNr.ReadOnly = true;
            this.dgcRegNr.Width = 120;
            // 
            // dgcDocTyp2
            // 
            this.dgcDocTyp2.DataPropertyName = "DocTyp2";
            this.dgcDocTyp2.HeaderText = "dar.veids";
            this.dgcDocTyp2.Name = "dgcDocTyp2";
            this.dgcDocTyp2.ReadOnly = true;
            this.dgcDocTyp2.Width = 80;
            // 
            // dgcSumm
            // 
            this.dgcSumm.DataPropertyName = "Summ";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.dgcSumm.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcSumm.HeaderText = "summa";
            this.dgcSumm.Name = "dgcSumm";
            this.dgcSumm.ReadOnly = true;
            this.dgcSumm.Width = 80;
            // 
            // dgcPVN
            // 
            this.dgcPVN.DataPropertyName = "PVN";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dgcPVN.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcPVN.HeaderText = "PVN";
            this.dgcPVN.Name = "dgcPVN";
            this.dgcPVN.ReadOnly = true;
            this.dgcPVN.Width = 80;
            // 
            // dgcDocTyp1
            // 
            this.dgcDocTyp1.DataPropertyName = "DocTyp1";
            this.dgcDocTyp1.HeaderText = "dok.veids";
            this.dgcDocTyp1.Name = "dgcDocTyp1";
            this.dgcDocTyp1.ReadOnly = true;
            this.dgcDocTyp1.Width = 80;
            // 
            // dgcCur
            // 
            this.dgcCur.DataPropertyName = "Cur";
            this.dgcCur.HeaderText = "valūta";
            this.dgcCur.Name = "dgcCur";
            this.dgcCur.ReadOnly = true;
            this.dgcCur.Width = 56;
            // 
            // dgcSummC
            // 
            this.dgcSummC.DataPropertyName = "SummC";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.dgcSummC.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcSummC.HeaderText = "summa";
            this.dgcSummC.Name = "dgcSummC";
            this.dgcSummC.ReadOnly = true;
            this.dgcSummC.ToolTipText = "Summa norādītajā valūtā";
            this.dgcSummC.Width = 80;
            // 
            // dgcDocSt
            // 
            this.dgcDocSt.DataPropertyName = "DocSt";
            this.dgcDocSt.HeaderText = "sērija";
            this.dgcDocSt.Name = "dgcDocSt";
            this.dgcDocSt.ReadOnly = true;
            this.dgcDocSt.Width = 48;
            // 
            // dgcDocNr
            // 
            this.dgcDocNr.DataPropertyName = "DocNr";
            this.dgcDocNr.HeaderText = "dok.nr.";
            this.dgcDocNr.Name = "dgcDocNr";
            this.dgcDocNr.ReadOnly = true;
            this.dgcDocNr.Width = 80;
            // 
            // dgcDate
            // 
            this.dgcDate.DataPropertyName = "Dete";
            this.dgcDate.HeaderText = "datums";
            this.dgcDate.Name = "dgcDate";
            this.dgcDate.ReadOnly = true;
            this.dgcDate.Width = 88;
            // 
            // Form_PVN_Piel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 385);
            this.CloseOnEscape = true;
            this.Controls.Add(this.dgvROps1a);
            this.Name = "Form_PVN_Piel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PVN pielikums";
            this.Load += new System.EventHandler(this.Form_PVN_Piel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsROps1a)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvROps1a)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyBindingSource bsROps1a;
        private MyDataGridView dgvROps1a;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRegNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocTyp2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSumm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPVN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocTyp1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCur;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSummC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDocNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDate;
    }
}