
namespace KlonsFM.FormsM
{
    partial class FormM_Params
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormM_Params));
            this.myGrid1 = new KlonsLIB.MySourceGrid.MyGrid();
            this.paramsMData1 = new DataObjectsFM.ParamsMData();
            this.grMainStore = new KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox();
            this.bsStores = new KlonsLIB.Data.MyBindingSource(this.components);
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsStores)).BeginInit();
            this.SuspendLayout();
            // 
            // myGrid1
            // 
            this.myGrid1.BackColor2 = System.Drawing.SystemColors.Window;
            this.myGrid1.ColumnWidth1 = 20;
            this.myGrid1.ColumnWidth2 = 200;
            this.myGrid1.ColumnWidth3 = 200;
            this.myGrid1.DefaultHeight = 27;
            this.myGrid1.EnableSort = true;
            this.myGrid1.Location = new System.Drawing.Point(12, 12);
            this.myGrid1.MyDataBC = this.paramsMData1;
            this.myGrid1.Name = "myGrid1";
            this.myGrid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.myGrid1.RowHeadersUsed = false;
            this.myGrid1.RowList.Add(this.grMainStore);
            this.myGrid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.myGrid1.Size = new System.Drawing.Size(480, 61);
            this.myGrid1.TabIndex = 0;
            this.myGrid1.TabStop = true;
            this.myGrid1.ToolTipText = "";
            // 
            // paramsMData1
            // 
            this.paramsMData1._MainnStoreCode = null;
            // 
            // grMainStore
            // 
            this.grMainStore.AllowNull = true;
            this.grMainStore.DataMember = null;
            this.grMainStore.GridPropertyName = "_MainnStoreCode";
            this.grMainStore.ListDisplayMember = "CODE";
            this.grMainStore.ListSource = this.bsStores;
            this.grMainStore.ListValueMember = "CODE";
            this.grMainStore.Name = "grMainStore";
            this.grMainStore.RowTitle = "Galvenā noliktava";
            this.grMainStore.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // bsStores
            // 
            this.bsStores.DataMember = "M_STORES";
            this.bsStores.MyDataSource = "KlonsMData";
            this.bsStores.Sort = "CODE";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(339, 245);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(127, 46);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(472, 245);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(127, 46);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Atcelt";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 89);
            this.label1.MaximumSize = new System.Drawing.Size(600, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(591, 60);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // FormM_Params
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 298);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.myGrid1);
            this.Name = "FormM_Params";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iestatijumi";
            this.Load += new System.EventHandler(this.FormM_Params_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsStores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.MySourceGrid.MyGrid myGrid1;
        private DataObjectsFM.ParamsMData paramsMData1;
        private KlonsLIB.Data.MyBindingSource bsStores;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowPickRowTextBox grMainStore;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label1;
    }
}