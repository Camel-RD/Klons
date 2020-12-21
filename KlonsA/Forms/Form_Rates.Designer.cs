namespace KlonsA.Forms
{
    partial class Form_Rates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Rates));
            this.row_Title1 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.row_OnDate = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.bsLikmes = new KlonsLIB.Data.MyBindingSource(this.components);
            this.row_IIN_Likme = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_SIDD_Pamatlikme = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.myGrid1 = new KlonsLIB.MySourceGrid.MyGrid();
            this.LikmesData1 = new DataObjectsA.LikmesData();
            this.row_MinPayMonth = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_MinPayHour = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_IIN_Likme_2 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_IIN_Likme_3 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_IIN_Slieksnis_1 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_IIN_Slieksnis_2 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_SIDN_Pamatlikme = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_SIDD_Pens = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_SIDN_Pens = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_SIDD_IzdPens = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_SIDN_IzdPens = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_SIDD_Ieslodz = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_SIDN_Ieslodz = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_SIDD_Ieslodz_Pens = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_SIDN_Ieslodz_Pens = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_Neapliek_Min = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_Apgad = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_Invalid_12 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_Invalid_3 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_Repr = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_Pret = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.row_URN = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.sharedTextBox = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.bnavLikmes = new KlonsLIB.Components.MyBindingNavigator();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.cbDates = new KlonsLIB.Components.MyMcFlatComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsLikmes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavLikmes)).BeginInit();
            this.bnavLikmes.SuspendLayout();
            this.SuspendLayout();
            // 
            // row_Title1
            // 
            this.row_Title1.Name = "row_Title1";
            this.row_Title1.RowTitle = "Likmes";
            // 
            // row_OnDate
            // 
            this.row_OnDate.DataMember = "ONDATE";
            this.row_OnDate.DataSource = this.bsLikmes;
            this.row_OnDate.GridPropertyName = "_ONDATE";
            this.row_OnDate.Name = "row_OnDate";
            this.row_OnDate.RowTitle = "Datums";
            this.row_OnDate.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Date;
            // 
            // bsLikmes
            // 
            this.bsLikmes.DataMember = "RATES";
            this.bsLikmes.MyDataSource = "KlonsData";
            this.bsLikmes.Sort = "ONDATE";
            this.bsLikmes.DataError += new System.Windows.Forms.BindingManagerDataErrorEventHandler(this.bsLikmes_DataError);
            this.bsLikmes.CurrentChanged += new System.EventHandler(this.bsLikmes_CurrentChanged);
            this.bsLikmes.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsLikmes_ListChanged);
            // 
            // row_IIN_Likme
            // 
            this.row_IIN_Likme.DataMember = "IIN_LIKME";
            this.row_IIN_Likme.DataSource = this.bsLikmes;
            this.row_IIN_Likme.EditorTemplateName = "sharedTextBox";
            this.row_IIN_Likme.GridPropertyName = "_IIN_LIKME";
            this.row_IIN_Likme.Name = "row_IIN_Likme";
            this.row_IIN_Likme.RowTitle = "IIN likme";
            this.row_IIN_Likme.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_SIDD_Pamatlikme
            // 
            this.row_SIDD_Pamatlikme.DataMember = "SIDD_PAMATLIKME";
            this.row_SIDD_Pamatlikme.DataSource = this.bsLikmes;
            this.row_SIDD_Pamatlikme.EditorTemplateName = "sharedTextBox";
            this.row_SIDD_Pamatlikme.GridPropertyName = "_SIDD_PAMATLIKME";
            this.row_SIDD_Pamatlikme.Name = "row_SIDD_Pamatlikme";
            this.row_SIDD_Pamatlikme.RowTitle = "SI: DD pamatlikme";
            this.row_SIDD_Pamatlikme.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // myGrid1
            // 
            this.myGrid1.BackColor2 = System.Drawing.SystemColors.Window;
            this.myGrid1.ColumnWidth1 = 20;
            this.myGrid1.ColumnWidth2 = 400;
            this.myGrid1.ColumnWidth3 = 100;
            this.myGrid1.DefaultHeight = 25;
            this.myGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGrid1.EnableSort = true;
            this.myGrid1.Location = new System.Drawing.Point(0, 0);
            this.myGrid1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myGrid1.MyDataBC = this.LikmesData1;
            this.myGrid1.Name = "myGrid1";
            this.myGrid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.myGrid1.RowList.Add(this.row_Title1);
            this.myGrid1.RowList.Add(this.row_OnDate);
            this.myGrid1.RowList.Add(this.row_MinPayMonth);
            this.myGrid1.RowList.Add(this.row_MinPayHour);
            this.myGrid1.RowList.Add(this.row_IIN_Likme);
            this.myGrid1.RowList.Add(this.row_IIN_Likme_2);
            this.myGrid1.RowList.Add(this.row_IIN_Likme_3);
            this.myGrid1.RowList.Add(this.row_IIN_Slieksnis_1);
            this.myGrid1.RowList.Add(this.row_IIN_Slieksnis_2);
            this.myGrid1.RowList.Add(this.row_SIDD_Pamatlikme);
            this.myGrid1.RowList.Add(this.row_SIDN_Pamatlikme);
            this.myGrid1.RowList.Add(this.row_SIDD_Pens);
            this.myGrid1.RowList.Add(this.row_SIDN_Pens);
            this.myGrid1.RowList.Add(this.row_SIDD_IzdPens);
            this.myGrid1.RowList.Add(this.row_SIDN_IzdPens);
            this.myGrid1.RowList.Add(this.row_SIDD_Ieslodz);
            this.myGrid1.RowList.Add(this.row_SIDN_Ieslodz);
            this.myGrid1.RowList.Add(this.row_SIDD_Ieslodz_Pens);
            this.myGrid1.RowList.Add(this.row_SIDN_Ieslodz_Pens);
            this.myGrid1.RowList.Add(this.row_Neapliek_Min);
            this.myGrid1.RowList.Add(this.row_Apgad);
            this.myGrid1.RowList.Add(this.row_Invalid_12);
            this.myGrid1.RowList.Add(this.row_Invalid_3);
            this.myGrid1.RowList.Add(this.row_Repr);
            this.myGrid1.RowList.Add(this.row_Pret);
            this.myGrid1.RowList.Add(this.row_URN);
            this.myGrid1.RowTemplateList.Add(this.sharedTextBox);
            this.myGrid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.myGrid1.Size = new System.Drawing.Size(796, 419);
            this.myGrid1.TabIndex = 0;
            this.myGrid1.TabStop = true;
            this.myGrid1.ToolTipText = "";
            this.myGrid1.EditEnded += new System.EventHandler(this.myGrid1_EditEnded);
            // 
            // LikmesData1
            // 
            this.LikmesData1._APGAD = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._IIN_LIKME = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._IIN_LIKME_2 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._IIN_LIKME_3 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._IIN_SLIEKSNIS_1 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._IIN_SLIEKSNIS_2 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._INVALID_12 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._INVALID_3 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._MIN_PAY_HOUR = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._MIN_PAY_MONTH = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._NEPLIEK_MIN = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._ONDATE = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.LikmesData1._PRET = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._REPR = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._SIDD_IESLODZ = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._SIDD_IESLODZ_PENS = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._SIDD_IZDPENS = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._SIDD_PAMATLIKME = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._SIDD_PENS = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._SIDN_IESLODZ = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._SIDN_IESLODZ_PENS = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._SIDN_IZDPENS = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._SIDN_PAMATLIKME = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._SIDN_PENS = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.LikmesData1._STR = null;
            this.LikmesData1._URN = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            // 
            // row_MinPayMonth
            // 
            this.row_MinPayMonth.DataMember = "MIN_PAY_MONTH";
            this.row_MinPayMonth.DataSource = this.bsLikmes;
            this.row_MinPayMonth.EditorTemplateName = "sharedTextBox";
            this.row_MinPayMonth.GridPropertyName = "_MIN_PAY_MONTH";
            this.row_MinPayMonth.Name = "row_MinPayMonth";
            this.row_MinPayMonth.RowTitle = "Minimālā mēneša alga";
            this.row_MinPayMonth.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_MinPayHour
            // 
            this.row_MinPayHour.DataMember = "MIN_PAY_HOUR";
            this.row_MinPayHour.DataSource = this.bsLikmes;
            this.row_MinPayHour.EditorTemplateName = "sharedTextBox";
            this.row_MinPayHour.FormatString = "";
            this.row_MinPayHour.GridPropertyName = "_MIN_PAY_HOUR";
            this.row_MinPayHour.Name = "row_MinPayHour";
            this.row_MinPayHour.RowTitle = "Minimālā stundas likme";
            this.row_MinPayHour.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_IIN_Likme_2
            // 
            this.row_IIN_Likme_2.DataMember = "IIN_LIKME_2";
            this.row_IIN_Likme_2.DataSource = this.bsLikmes;
            this.row_IIN_Likme_2.EditorTemplateName = "sharedTextBox";
            this.row_IIN_Likme_2.GridPropertyName = "_IIN_LIKME_2";
            this.row_IIN_Likme_2.Name = "row_IIN_Likme_2";
            this.row_IIN_Likme_2.RowTitle = "IIN likme 2";
            this.row_IIN_Likme_2.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_IIN_Likme_3
            // 
            this.row_IIN_Likme_3.DataMember = "IIN_LIKME_3";
            this.row_IIN_Likme_3.DataSource = this.bsLikmes;
            this.row_IIN_Likme_3.EditorTemplateName = "sharedTextBox";
            this.row_IIN_Likme_3.GridPropertyName = "_IIN_LIKME_3";
            this.row_IIN_Likme_3.Name = "row_IIN_Likme_3";
            this.row_IIN_Likme_3.RowTitle = "IIN likme 3";
            this.row_IIN_Likme_3.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_IIN_Slieksnis_1
            // 
            this.row_IIN_Slieksnis_1.DataMember = "IIN_SLIEKSNIS_1";
            this.row_IIN_Slieksnis_1.DataSource = this.bsLikmes;
            this.row_IIN_Slieksnis_1.EditorTemplateName = "sharedTextBox";
            this.row_IIN_Slieksnis_1.GridPropertyName = "_IIN_SLIEKSNIS_1";
            this.row_IIN_Slieksnis_1.Name = "row_IIN_Slieksnis_1";
            this.row_IIN_Slieksnis_1.RowTitle = "IIN likmes slieksnis 1";
            this.row_IIN_Slieksnis_1.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_IIN_Slieksnis_2
            // 
            this.row_IIN_Slieksnis_2.DataMember = "IIN_SLIEKSNIS_2";
            this.row_IIN_Slieksnis_2.DataSource = this.bsLikmes;
            this.row_IIN_Slieksnis_2.EditorTemplateName = "sharedTextBox";
            this.row_IIN_Slieksnis_2.GridPropertyName = "_IIN_SLIEKSNIS_2";
            this.row_IIN_Slieksnis_2.Name = "row_IIN_Slieksnis_2";
            this.row_IIN_Slieksnis_2.RowTitle = "IIN likmes slieksnis 2";
            this.row_IIN_Slieksnis_2.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_SIDN_Pamatlikme
            // 
            this.row_SIDN_Pamatlikme.DataMember = "SIDN_PAMATLIKME";
            this.row_SIDN_Pamatlikme.DataSource = this.bsLikmes;
            this.row_SIDN_Pamatlikme.EditorTemplateName = "sharedTextBox";
            this.row_SIDN_Pamatlikme.GridPropertyName = "_SIDN_PAMATLIKME";
            this.row_SIDN_Pamatlikme.Name = "row_SIDN_Pamatlikme";
            this.row_SIDN_Pamatlikme.RowTitle = "SI: DŅ pamatlikme";
            this.row_SIDN_Pamatlikme.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_SIDD_Pens
            // 
            this.row_SIDD_Pens.DataMember = "SIDD_PENS";
            this.row_SIDD_Pens.DataSource = this.bsLikmes;
            this.row_SIDD_Pens.EditorTemplateName = "sharedTextBox";
            this.row_SIDD_Pens.GridPropertyName = "_SIDD_PENS";
            this.row_SIDD_Pens.Name = "row_SIDD_Pens";
            this.row_SIDD_Pens.RowTitle = "SI: DD likme pensionāriem";
            this.row_SIDD_Pens.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_SIDN_Pens
            // 
            this.row_SIDN_Pens.DataMember = "SIDN_PENS";
            this.row_SIDN_Pens.DataSource = this.bsLikmes;
            this.row_SIDN_Pens.EditorTemplateName = "sharedTextBox";
            this.row_SIDN_Pens.GridPropertyName = "_SIDN_PENS";
            this.row_SIDN_Pens.Name = "row_SIDN_Pens";
            this.row_SIDN_Pens.RowTitle = "SI: DŅ likme pensionāriem";
            this.row_SIDN_Pens.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_SIDD_IzdPens
            // 
            this.row_SIDD_IzdPens.DataMember = "SIDD_IZDPENS";
            this.row_SIDD_IzdPens.DataSource = this.bsLikmes;
            this.row_SIDD_IzdPens.EditorTemplateName = "sharedTextBox";
            this.row_SIDD_IzdPens.GridPropertyName = "_SIDD_IZDPENS";
            this.row_SIDD_IzdPens.Name = "row_SIDD_IzdPens";
            this.row_SIDD_IzdPens.RowTitle = "SI: DD likme izdienas pensijas saņēmējiem";
            this.row_SIDD_IzdPens.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_SIDN_IzdPens
            // 
            this.row_SIDN_IzdPens.DataMember = "SIDN_IZDPENS";
            this.row_SIDN_IzdPens.DataSource = this.bsLikmes;
            this.row_SIDN_IzdPens.EditorTemplateName = "sharedTextBox";
            this.row_SIDN_IzdPens.GridPropertyName = "_SIDN_IZDPENS";
            this.row_SIDN_IzdPens.Name = "row_SIDN_IzdPens";
            this.row_SIDN_IzdPens.RowTitle = "SI: DŅ likme izdienas pensijas saņēmējiem";
            this.row_SIDN_IzdPens.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_SIDD_Ieslodz
            // 
            this.row_SIDD_Ieslodz.DataMember = "SIDD_IESLODZ";
            this.row_SIDD_Ieslodz.DataSource = this.bsLikmes;
            this.row_SIDD_Ieslodz.EditorTemplateName = "sharedTextBox";
            this.row_SIDD_Ieslodz.GridPropertyName = "_SIDD_IESLODZ";
            this.row_SIDD_Ieslodz.Name = "row_SIDD_Ieslodz";
            this.row_SIDD_Ieslodz.RowTitle = "SI: DD likme ieslodzītajiem";
            this.row_SIDD_Ieslodz.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_SIDN_Ieslodz
            // 
            this.row_SIDN_Ieslodz.DataMember = "SIDN_IESLODZ";
            this.row_SIDN_Ieslodz.DataSource = this.bsLikmes;
            this.row_SIDN_Ieslodz.EditorTemplateName = "sharedTextBox";
            this.row_SIDN_Ieslodz.GridPropertyName = "_SIDN_IESLODZ";
            this.row_SIDN_Ieslodz.Name = "row_SIDN_Ieslodz";
            this.row_SIDN_Ieslodz.RowTitle = "SI: DŅ likme ieslodzītajiem";
            this.row_SIDN_Ieslodz.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_SIDD_Ieslodz_Pens
            // 
            this.row_SIDD_Ieslodz_Pens.DataMember = "SIDD_IESLODZ_PENS";
            this.row_SIDD_Ieslodz_Pens.DataSource = this.bsLikmes;
            this.row_SIDD_Ieslodz_Pens.EditorTemplateName = "sharedTextBox";
            this.row_SIDD_Ieslodz_Pens.GridPropertyName = "_SIDD_IESLODZ_PENS";
            this.row_SIDD_Ieslodz_Pens.Name = "row_SIDD_Ieslodz_Pens";
            this.row_SIDD_Ieslodz_Pens.RowTitle = "SI: DD lime ieslodzītajiem pensionāriem";
            this.row_SIDD_Ieslodz_Pens.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_SIDN_Ieslodz_Pens
            // 
            this.row_SIDN_Ieslodz_Pens.DataMember = "SIDN_IESLODZ_PENS";
            this.row_SIDN_Ieslodz_Pens.DataSource = this.bsLikmes;
            this.row_SIDN_Ieslodz_Pens.EditorTemplateName = "sharedTextBox";
            this.row_SIDN_Ieslodz_Pens.GridPropertyName = "_SIDN_IESLODZ_PENS";
            this.row_SIDN_Ieslodz_Pens.Name = "row_SIDN_Ieslodz_Pens";
            this.row_SIDN_Ieslodz_Pens.RowTitle = "SI: DŅ lime ieslodzītajiem pensionāriem";
            this.row_SIDN_Ieslodz_Pens.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_Neapliek_Min
            // 
            this.row_Neapliek_Min.DataMember = "NEPLIEK_MIN";
            this.row_Neapliek_Min.DataSource = this.bsLikmes;
            this.row_Neapliek_Min.EditorTemplateName = "sharedTextBox";
            this.row_Neapliek_Min.GridPropertyName = "_NEPLIEK_MIN";
            this.row_Neapliek_Min.Name = "row_Neapliek_Min";
            this.row_Neapliek_Min.RowTitle = "Neapliekamais minimums";
            this.row_Neapliek_Min.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_Apgad
            // 
            this.row_Apgad.DataMember = "APGAD";
            this.row_Apgad.DataSource = this.bsLikmes;
            this.row_Apgad.EditorTemplateName = "sharedTextBox";
            this.row_Apgad.GridPropertyName = "_APGAD";
            this.row_Apgad.Name = "row_Apgad";
            this.row_Apgad.RowTitle = "Atvieglojumi par apgādājamajiem";
            this.row_Apgad.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_Invalid_12
            // 
            this.row_Invalid_12.DataMember = "INVALID_12";
            this.row_Invalid_12.DataSource = this.bsLikmes;
            this.row_Invalid_12.EditorTemplateName = "sharedTextBox";
            this.row_Invalid_12.GridPropertyName = "_INVALID_12";
            this.row_Invalid_12.Name = "row_Invalid_12";
            this.row_Invalid_12.RowTitle = "Atvieglojumi 1,2 grupas invalīdiem";
            this.row_Invalid_12.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_Invalid_3
            // 
            this.row_Invalid_3.DataMember = "INVALID_3";
            this.row_Invalid_3.DataSource = this.bsLikmes;
            this.row_Invalid_3.EditorTemplateName = "sharedTextBox";
            this.row_Invalid_3.GridPropertyName = "_INVALID_3";
            this.row_Invalid_3.Name = "row_Invalid_3";
            this.row_Invalid_3.RowTitle = "Atvieglojumi 3. grupas invalīdiem";
            this.row_Invalid_3.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_Repr
            // 
            this.row_Repr.DataMember = "REPR";
            this.row_Repr.DataSource = this.bsLikmes;
            this.row_Repr.EditorTemplateName = "sharedTextBox";
            this.row_Repr.GridPropertyName = "_REPR";
            this.row_Repr.Name = "row_Repr";
            this.row_Repr.RowTitle = "Atvieglojumi represētajiem";
            this.row_Repr.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_Pret
            // 
            this.row_Pret.DataMember = "PRET";
            this.row_Pret.DataSource = this.bsLikmes;
            this.row_Pret.EditorTemplateName = "sharedTextBox";
            this.row_Pret.GridPropertyName = "_PRET";
            this.row_Pret.Name = "row_Pret";
            this.row_Pret.RowTitle = "Atvieglojumi pretošanās kustības dalībn.";
            this.row_Pret.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // row_URN
            // 
            this.row_URN.DataMember = "URN";
            this.row_URN.DataSource = this.bsLikmes;
            this.row_URN.EditorTemplateName = "sharedTextBox";
            this.row_URN.GridPropertyName = "_URN";
            this.row_URN.Name = "row_URN";
            this.row_URN.RowTitle = "URN";
            this.row_URN.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // sharedTextBox
            // 
            this.sharedTextBox.Name = "sharedTextBox";
            this.sharedTextBox.RowTitle = null;
            this.sharedTextBox.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // bnavLikmes
            // 
            this.bnavLikmes.AddNewItem = null;
            this.bnavLikmes.BindingSource = this.bsLikmes;
            this.bnavLikmes.CountItem = null;
            this.bnavLikmes.CountItemFormat = " no {0}";
            this.bnavLikmes.DeleteItem = null;
            this.bnavLikmes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnavLikmes.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.bnavLikmes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.tsbSave});
            this.bnavLikmes.Location = new System.Drawing.Point(0, 419);
            this.bnavLikmes.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnavLikmes.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnavLikmes.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnavLikmes.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnavLikmes.Name = "bnavLikmes";
            this.bnavLikmes.PositionItem = null;
            this.bnavLikmes.SaveItem = null;
            this.bnavLikmes.Size = new System.Drawing.Size(796, 39);
            this.bnavLikmes.TabIndex = 1;
            this.bnavLikmes.Text = "myBindingNavigator1";
            this.bnavLikmes.ItemDeleting += new System.ComponentModel.CancelEventHandler(this.bnavLikmes_ItemDeleting);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 34);
            this.bindingNavigatorMoveFirstItem.Text = "Iet uz pirmo";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 34);
            this.bindingNavigatorMovePreviousItem.Text = "Iet uz iepriekšējo";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 34);
            this.bindingNavigatorMoveNextItem.Text = "Iet uz nākošo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 34);
            this.bindingNavigatorMoveLastItem.Text = "Iet uz pēdējo";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(90, 34);
            this.bindingNavigatorAddNewItem.Text = "Jauns";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(91, 34);
            this.bindingNavigatorDeleteItem.Text = "Dzēst";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(34, 34);
            this.tsbSave.Text = "toolStripButton1";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // cbDates
            // 
            this.cbDates._AllowSelection = true;
            this.cbDates.BorderColor = System.Drawing.SystemColors.Control;
            this.cbDates.ColumnNames = new string[] {
        "ONDATE"};
            this.cbDates.ColumnWidths = "100";
            this.cbDates.DataSource = this.bsLikmes;
            this.cbDates.DisplayMember = "ONDATE";
            this.cbDates.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDates.DropDownHeight = 168;
            this.cbDates.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbDates.DropDownWidth = 144;
            this.cbDates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDates.FormattingEnabled = true;
            this.cbDates.GridLineColor = System.Drawing.Color.LightGray;
            this.cbDates.GridLineHorizontal = false;
            this.cbDates.GridLineVertical = false;
            this.cbDates.IntegralHeight = false;
            this.cbDates.Location = new System.Drawing.Point(412, 425);
            this.cbDates.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDates.Name = "cbDates";
            this.cbDates.Size = new System.Drawing.Size(112, 27);
            this.cbDates.TabIndex = 13;
            this.cbDates.ValueMember = "ONDATE";
            this.cbDates.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbDates_Format);
            // 
            // Form_Rates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 458);
            this.Controls.Add(this.cbDates);
            this.Controls.Add(this.myGrid1);
            this.Controls.Add(this.bnavLikmes);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_Rates";
            this.Text = "Form_Likmes";
            this.Load += new System.EventHandler(this.Form_Rates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsLikmes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnavLikmes)).EndInit();
            this.bnavLikmes.ResumeLayout(false);
            this.bnavLikmes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KlonsLIB.MySourceGrid.MyGrid myGrid1;
        private KlonsLIB.Components.MyBindingNavigator bnavLikmes;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private KlonsLIB.Data.MyBindingSource bsLikmes;
        private DataObjectsA.LikmesData LikmesData1;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle row_Title1;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_OnDate;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_IIN_Likme;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_SIDD_Pamatlikme;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_SIDN_Pamatlikme;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_SIDD_Pens;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_SIDN_Pens;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_SIDD_IzdPens;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_SIDN_IzdPens;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_SIDD_Ieslodz;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_SIDN_Ieslodz;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_SIDD_Ieslodz_Pens;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_SIDN_Ieslodz_Pens;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_Neapliek_Min;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_Apgad;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_Invalid_12;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_Invalid_3;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_Repr;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_Pret;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_URN;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA sharedTextBox;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_MinPayMonth;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_MinPayHour;
        private KlonsLIB.Components.MyMcFlatComboBox cbDates;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_IIN_Likme_2;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_IIN_Likme_3;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_IIN_Slieksnis_1;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA row_IIN_Slieksnis_2;
    }
}