namespace KlonsA.Forms
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
            this.companyData1 = new KlonsA.Classes.CompanyData();
            this.myGrid1 = new KlonsLIB.MySourceGrid.MyGrid();
            this.grCompanyTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grCompanyName = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grCompRegNr = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grCompRegNrPVN = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grCompVID = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grAdreseTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grCompAddr = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grCompAddrInd = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grCompAddr1 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grCompAddr2 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grCompAddr3 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grCompAddr4 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grCompAddrG = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grManTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grCompMName = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grCompMpk = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grCompPhone = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grAccTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grCompAccName = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grCompAccPh = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grBankTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grBankId = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grBankName = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grBankAcc = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grtString = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.SuspendLayout();
            // 
            // myGrid1
            // 
            this.myGrid1.BackColor2 = System.Drawing.SystemColors.Window;
            this.myGrid1.ColumnWidth1 = 15;
            this.myGrid1.ColumnWidth2 = 200;
            this.myGrid1.ColumnWidth3 = 300;
            this.myGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGrid1.EnableSort = true;
            this.myGrid1.Location = new System.Drawing.Point(0, 0);
            this.myGrid1.Margin = new System.Windows.Forms.Padding(2);
            this.myGrid1.MyDataBC = this.companyData1;
            this.myGrid1.Name = "myGrid1";
            this.myGrid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.myGrid1.RowList.Add(this.grCompanyTitle);
            this.myGrid1.RowList.Add(this.grCompanyName);
            this.myGrid1.RowList.Add(this.grCompRegNr);
            this.myGrid1.RowList.Add(this.grCompRegNrPVN);
            this.myGrid1.RowList.Add(this.grCompVID);
            this.myGrid1.RowList.Add(this.grAdreseTitle);
            this.myGrid1.RowList.Add(this.grCompAddr);
            this.myGrid1.RowList.Add(this.grCompAddrInd);
            this.myGrid1.RowList.Add(this.grCompAddr1);
            this.myGrid1.RowList.Add(this.grCompAddr2);
            this.myGrid1.RowList.Add(this.grCompAddr3);
            this.myGrid1.RowList.Add(this.grCompAddr4);
            this.myGrid1.RowList.Add(this.grCompAddrG);
            this.myGrid1.RowList.Add(this.grManTitle);
            this.myGrid1.RowList.Add(this.grCompMName);
            this.myGrid1.RowList.Add(this.grCompMpk);
            this.myGrid1.RowList.Add(this.grCompPhone);
            this.myGrid1.RowList.Add(this.grAccTitle);
            this.myGrid1.RowList.Add(this.grCompAccName);
            this.myGrid1.RowList.Add(this.grCompAccPh);
            this.myGrid1.RowList.Add(this.grBankTitle);
            this.myGrid1.RowList.Add(this.grBankId);
            this.myGrid1.RowList.Add(this.grBankName);
            this.myGrid1.RowList.Add(this.grBankAcc);
            this.myGrid1.RowTemplateList.Add(this.grtString);
            this.myGrid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.myGrid1.Size = new System.Drawing.Size(500, 347);
            this.myGrid1.TabIndex = 0;
            this.myGrid1.TabStop = true;
            this.myGrid1.ToolTipText = "";
            // 
            // grCompanyTitle
            // 
            this.grCompanyTitle.Name = "grCompanyTitle";
            this.grCompanyTitle.RowTitle = "Par uzņēmumu";
            // 
            // grCompanyName
            // 
            this.grCompanyName.DataMember = null;
            this.grCompanyName.EditorTemplateName = "grtString";
            this.grCompanyName.GridPropertyName = "_CompName";
            this.grCompanyName.Name = "grCompanyName";
            this.grCompanyName.RowTitle = "Uzņēmuma nosaukums";
            this.grCompanyName.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grCompRegNr
            // 
            this.grCompRegNr.DataMember = null;
            this.grCompRegNr.EditorTemplateName = "grtString";
            this.grCompRegNr.GridPropertyName = "_CompRegNr";
            this.grCompRegNr.Name = "grCompRegNr";
            this.grCompRegNr.RowTitle = "Reģ.nr. UR";
            this.grCompRegNr.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grCompRegNrPVN
            // 
            this.grCompRegNrPVN.DataMember = null;
            this.grCompRegNrPVN.EditorTemplateName = "grtString";
            this.grCompRegNrPVN.GridPropertyName = "_CompRegNrPVN";
            this.grCompRegNrPVN.Name = "grCompRegNrPVN";
            this.grCompRegNrPVN.RowTitle = "PVN Reģ.nr.";
            this.grCompRegNrPVN.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grCompVID
            // 
            this.grCompVID.DataMember = null;
            this.grCompVID.EditorTemplateName = "grtString";
            this.grCompVID.GridPropertyName = "_CompVID";
            this.grCompVID.Name = "grCompVID";
            this.grCompVID.RowTitle = "VID nodaļa";
            this.grCompVID.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grAdreseTitle
            // 
            this.grAdreseTitle.Name = "grAdreseTitle";
            this.grAdreseTitle.RowTitle = "Adrese";
            // 
            // grCompAddr
            // 
            this.grCompAddr.DataMember = null;
            this.grCompAddr.EditorTemplateName = "grtString";
            this.grCompAddr.GridPropertyName = "_CompAddr";
            this.grCompAddr.Name = "grCompAddr";
            this.grCompAddr.RowTitle = "Pilna adrese";
            this.grCompAddr.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grCompAddrInd
            // 
            this.grCompAddrInd.DataMember = null;
            this.grCompAddrInd.EditorTemplateName = "grtString";
            this.grCompAddrInd.GridPropertyName = "_CompAddrInd";
            this.grCompAddrInd.Name = "grCompAddrInd";
            this.grCompAddrInd.RowTitle = "Pasta indeks";
            this.grCompAddrInd.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grCompAddr1
            // 
            this.grCompAddr1.DataMember = null;
            this.grCompAddr1.EditorTemplateName = "grtString";
            this.grCompAddr1.GridPropertyName = "_CompAddr1";
            this.grCompAddr1.Name = "grCompAddr1";
            this.grCompAddr1.RowTitle = "Adrese: rinda 1";
            this.grCompAddr1.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grCompAddr2
            // 
            this.grCompAddr2.DataMember = null;
            this.grCompAddr2.EditorTemplateName = "grtString";
            this.grCompAddr2.GridPropertyName = "_CompAddr2";
            this.grCompAddr2.Name = "grCompAddr2";
            this.grCompAddr2.RowTitle = "Adrese: rinda 2";
            this.grCompAddr2.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grCompAddr3
            // 
            this.grCompAddr3.DataMember = null;
            this.grCompAddr3.EditorTemplateName = "grtString";
            this.grCompAddr3.GridPropertyName = "_CompAddr3";
            this.grCompAddr3.Name = "grCompAddr3";
            this.grCompAddr3.RowTitle = "Adrese: rinda 3";
            this.grCompAddr3.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grCompAddr4
            // 
            this.grCompAddr4.DataMember = null;
            this.grCompAddr4.EditorTemplateName = "grtString";
            this.grCompAddr4.GridPropertyName = "_CompAddr4";
            this.grCompAddr4.Name = "grCompAddr4";
            this.grCompAddr4.RowTitle = "Adrese: rinda 4";
            this.grCompAddr4.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grCompAddrG
            // 
            this.grCompAddrG.DataMember = null;
            this.grCompAddrG.EditorTemplateName = "grtString";
            this.grCompAddrG.GridPropertyName = "_CompAddrG";
            this.grCompAddrG.Name = "grCompAddrG";
            this.grCompAddrG.RowTitle = "Preču izsn. adrese";
            this.grCompAddrG.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grManTitle
            // 
            this.grManTitle.Name = "grManTitle";
            this.grManTitle.RowTitle = "Vadītājs";
            // 
            // grCompMName
            // 
            this.grCompMName.DataMember = null;
            this.grCompMName.EditorTemplateName = "grtString";
            this.grCompMName.GridPropertyName = "_CompMName";
            this.grCompMName.Name = "grCompMName";
            this.grCompMName.RowTitle = "Vārds, uzvārds";
            this.grCompMName.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grCompMpk
            // 
            this.grCompMpk.DataMember = null;
            this.grCompMpk.EditorTemplateName = "grtString";
            this.grCompMpk.GridPropertyName = "_CompMpk";
            this.grCompMpk.Name = "grCompMpk";
            this.grCompMpk.RowTitle = "Personas kods";
            this.grCompMpk.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grCompPhone
            // 
            this.grCompPhone.DataMember = null;
            this.grCompPhone.EditorTemplateName = "grtString";
            this.grCompPhone.GridPropertyName = "_CompPhone";
            this.grCompPhone.Name = "grCompPhone";
            this.grCompPhone.RowTitle = "Telefona nr.";
            this.grCompPhone.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grAccTitle
            // 
            this.grAccTitle.Name = "grAccTitle";
            this.grAccTitle.RowTitle = "Grāmatvedis";
            // 
            // grCompAccName
            // 
            this.grCompAccName.DataMember = null;
            this.grCompAccName.EditorTemplateName = "grtString";
            this.grCompAccName.GridPropertyName = "_CompAccName";
            this.grCompAccName.Name = "grCompAccName";
            this.grCompAccName.RowTitle = "Vārds, uzvārds";
            this.grCompAccName.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grCompAccPh
            // 
            this.grCompAccPh.DataMember = null;
            this.grCompAccPh.EditorTemplateName = "grtString";
            this.grCompAccPh.GridPropertyName = "_CompAccPh";
            this.grCompAccPh.Name = "grCompAccPh";
            this.grCompAccPh.RowTitle = "Telefona nr.";
            this.grCompAccPh.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grBankTitle
            // 
            this.grBankTitle.Name = "grBankTitle";
            this.grBankTitle.RowTitle = "Bankas dati";
            // 
            // grBankId
            // 
            this.grBankId.DataMember = null;
            this.grBankId.EditorTemplateName = "grtString";
            this.grBankId.GridPropertyName = "_BankId";
            this.grBankId.Name = "grBankId";
            this.grBankId.RowTitle = "Kods";
            this.grBankId.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grBankName
            // 
            this.grBankName.DataMember = null;
            this.grBankName.EditorTemplateName = "grtString";
            this.grBankName.GridPropertyName = "_BankName";
            this.grBankName.Name = "grBankName";
            this.grBankName.RowTitle = "Nosaukums";
            this.grBankName.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grBankAcc
            // 
            this.grBankAcc.DataMember = null;
            this.grBankAcc.EditorTemplateName = "grtString";
            this.grBankAcc.GridPropertyName = "_BankAcc";
            this.grBankAcc.Name = "grBankAcc";
            this.grBankAcc.RowTitle = "Konts";
            this.grBankAcc.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grtString
            // 
            this.grtString.AllowNull = true;
            this.grtString.DataMember = null;
            this.grtString.Name = "grtString";
            this.grtString.RowTitle = null;
            this.grtString.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // Form_CompanyData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 347);
            this.CloseOnEscape = true;
            this.Controls.Add(this.myGrid1);
            this.Name = "Form_CompanyData";
            this.Text = "Ziņas par uzņēmumu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCompanyData_FormClosing);
            this.Load += new System.EventHandler(this.FormCompanyData_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Classes.CompanyData companyData1;
        private KlonsLIB.MySourceGrid.MyGrid myGrid1;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grCompanyTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompanyName;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompRegNr;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompRegNrPVN;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompVID;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grAdreseTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompAddr;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompAddrInd;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompAddr1;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompAddr2;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompAddr3;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompAddr4;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompAddrG;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grManTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompMName;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompMpk;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompPhone;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grAccTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompAccName;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCompAccPh;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grBankTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grBankId;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grBankName;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grBankAcc;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grtString;
    }
}