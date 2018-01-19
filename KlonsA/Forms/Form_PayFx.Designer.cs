namespace KlonsA.Forms
{
    partial class Form_PayFx
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.dgvRows = new KlonsLIB.Components.MyDataGridView();
            this.dgcCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPayNs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPayNt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDNS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIINEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcUsedIINEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcIIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcCash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 226);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 61);
            this.panel1.TabIndex = 0;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(8, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(45, 16);
            this.lbTitle.TabIndex = 36;
            this.lbTitle.Text = "label1";
            // 
            // dgvRows
            // 
            this.dgvRows.AllowUserToAddRows = false;
            this.dgvRows.AllowUserToDeleteRows = false;
            this.dgvRows.AllowUserToResizeColumns = false;
            this.dgvRows.AllowUserToResizeRows = false;
            this.dgvRows.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcCaption,
            this.dgcPay,
            this.dgcPayNs,
            this.dgcPayNt,
            this.dgcDNS,
            this.dgcIINEx,
            this.dgcUsedIINEx,
            this.dgcIIN,
            this.dgcCash});
            this.dgvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRows.Location = new System.Drawing.Point(0, 0);
            this.dgvRows.Name = "dgvRows";
            this.dgvRows.ReadOnly = true;
            this.dgvRows.RowHeadersVisible = false;
            this.dgvRows.RowTemplate.Height = 24;
            this.dgvRows.Size = new System.Drawing.Size(871, 226);
            this.dgvRows.TabIndex = 1;
            // 
            // dgcCaption
            // 
            this.dgcCaption.DataPropertyName = "Caption";
            this.dgcCaption.Frozen = true;
            this.dgcCaption.HeaderText = "apraksts";
            this.dgcCaption.Name = "dgcCaption";
            this.dgcCaption.ReadOnly = true;
            this.dgcCaption.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcCaption.Width = 200;
            // 
            // dgcPay
            // 
            this.dgcPay.DataPropertyName = "Pay";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dgcPay.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcPay.HeaderText = "bruto";
            this.dgcPay.Name = "dgcPay";
            this.dgcPay.ReadOnly = true;
            this.dgcPay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcPay.Width = 80;
            // 
            // dgcPayNs
            // 
            this.dgcPayNs.DataPropertyName = "PayNs";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dgcPayNs.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcPayNs.HeaderText = "bruto nep.SAI";
            this.dgcPayNs.Name = "dgcPayNs";
            this.dgcPayNs.ReadOnly = true;
            this.dgcPayNs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcPayNs.Width = 80;
            // 
            // dgcPayNt
            // 
            this.dgcPayNt.DataPropertyName = "PayNt";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.dgcPayNt.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcPayNt.HeaderText = "bruto nepliek";
            this.dgcPayNt.Name = "dgcPayNt";
            this.dgcPayNt.ReadOnly = true;
            this.dgcPayNt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcPayNt.Width = 80;
            // 
            // dgcDNS
            // 
            this.dgcDNS.DataPropertyName = "DNS";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dgcDNS.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcDNS.HeaderText = "d.ņ. SAI";
            this.dgcDNS.Name = "dgcDNS";
            this.dgcDNS.ReadOnly = true;
            this.dgcDNS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcDNS.Width = 80;
            // 
            // dgcIINEx
            // 
            this.dgcIINEx.DataPropertyName = "IINEx";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.dgcIINEx.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcIINEx.HeaderText = "IIN atv. kopā";
            this.dgcIINEx.Name = "dgcIINEx";
            this.dgcIINEx.ReadOnly = true;
            this.dgcIINEx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcIINEx.Width = 80;
            // 
            // dgcUsedIINEx
            // 
            this.dgcUsedIINEx.DataPropertyName = "UsedIINEx";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.dgcUsedIINEx.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcUsedIINEx.HeaderText = "IIN atv.izm.";
            this.dgcUsedIINEx.Name = "dgcUsedIINEx";
            this.dgcUsedIINEx.ReadOnly = true;
            this.dgcUsedIINEx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcUsedIINEx.Width = 80;
            // 
            // dgcIIN
            // 
            this.dgcIIN.DataPropertyName = "IIN";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.dgcIIN.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcIIN.HeaderText = "IIN";
            this.dgcIIN.Name = "dgcIIN";
            this.dgcIIN.ReadOnly = true;
            this.dgcIIN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcIIN.Width = 80;
            // 
            // dgcCash
            // 
            this.dgcCash.DataPropertyName = "Cash";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.dgcCash.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcCash.HeaderText = "Izmaksai";
            this.dgcCash.Name = "dgcCash";
            this.dgcCash.ReadOnly = true;
            this.dgcCash.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcCash.Width = 80;
            // 
            // Form_PayFx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 287);
            this.Controls.Add(this.dgvRows);
            this.Controls.Add(this.panel1);
            this.Name = "Form_PayFx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aprēķina secība";
            this.Load += new System.EventHandler(this.Form_PayFx_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private KlonsLIB.Components.MyDataGridView dgvRows;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPayNs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPayNt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDNS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIINEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcUsedIINEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcIIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcCash;
    }
}