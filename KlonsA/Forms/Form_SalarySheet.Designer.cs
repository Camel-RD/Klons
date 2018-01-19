namespace KlonsA.Forms
{
    partial class Form_SalarySheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SalarySheet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.salaryData1 = new DataObjectsA.SalaryData();
            this.bsLapas = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsSarR = new KlonsLIB.Data.MyBindingSource2(this.components);
            this.bsSarR2 = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tslLabel = new System.Windows.Forms.ToolStripLabel();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tslAmati = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslPeriod = new System.Windows.Forms.ToolStripLabel();
            this.cbLapas = new KlonsLIB.Components.MyMcFlatComboBox();
            this.bsAmati = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsPapildsummasVeids = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsPapildsummaNo = new KlonsLIB.Data.MyBindingSource(this.components);
            this.bsAlgasPapildsummas = new System.Windows.Forms.BindingSource(this.components);
            this.grPersonTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grFName = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grLName = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPositionTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlanDays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlanHours = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlanHoursNight = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlanHoursOvertime = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlanWeekDays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlanWeekHours = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlanWeekHoirsNight = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlanWeekHoursOvertime = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlanHolidaysDays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlanHolidaysHours = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlanHolidaysHoursNight = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlanHolidaysHoursOvertime = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactDays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactHours = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactHoursNight = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactHoursOvertime = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactWeekDays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactWeekHours = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactWeekHoursNight = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactWeekHoursOvertime = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactHolidays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactHolidaysHours = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactHolidaysHoursNight = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactHolidaysHoursOvertime = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactAvPayFreeDays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactAvPayFreeHours = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactAvPayWorkDays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactAvPayHours = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactAvPayHoursOvertime = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactAvPayWorkInHolidays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactAvPayHolidaysHours = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactAvPayHolidaysHoursOvertime = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSalary = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSalaryDay = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSalaryNight = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSalaryOvertime = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSalaryHolidaysDay = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSalaryHolidaysNight = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSalaryHolidaysOvertime = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSalaryAvPayFreeDays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSalaryAvPayWorkDays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSalaryAvPayWorkDaysOvertime = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSalaryAvPayHolidays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSalaryAvPayHolidaysOvertime = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationDaysCurrent = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationDaysNext = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationPayCurrent = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationPayNext = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationPayPrev = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationDNSNext = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationDDSNext = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationIINNext = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationDNSPrev = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationDDSPrev = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationIINPrev = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSickDays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSickDaysPay = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grAccidentDays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grAccidentPay = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grAmountBeforeSN = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grRateDNSN = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grRateDDSN = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDNSNAmount = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDDSNAmount = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grIINExemprUntaxedMinimum = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grIINExemptDependants = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grIINExemptInvalidity = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grIINExemptRetaliation = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.geIINExemptNatMov = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grIINExemptExpenses = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grAmountBeforeIIN = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grRateIIN = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grIINAmount = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPayTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grPay = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grtInt = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grtInt16 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grtDouble = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDecimal = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grString = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDecimalProc = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSingle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.bonusData1 = new DataObjectsA.BonusData();
            this.grbTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grbIDA = new KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB();
            this.grbRate = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grbAmount = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grbRateType = new KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxA();
            this.grbIDNO = new KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB();
            this.grbTitle2 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grbDescr2 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowMultiLineTextBox();
            this.cbAmati = new KlonsLIB.Components.MyMcFlatComboBox();
            this.myAdapterManager1 = new KlonsLIB.Data.MyAdapterManager();
            this.tabControl1 = new KlonsLIB.Components.TabControlWithoutHeader();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.sgrAprekins = new KlonsLIB.MySourceGrid.MyGrid();
            this.grPlanTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grPlanMonthTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grCalendarDays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grMonthWorkDays = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grMonthWorkhours = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlanTitleA = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grPlanWorkDaysTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grPlanHolidaysTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grFactTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grCalendarDaysUse = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grFactWorkDaysTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grFactHolidaysTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grAvPayTimeTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grSalaryTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grSalaryTitle2 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grSalaryPieceWork = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSalaryAvPayTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grVacationTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grVacationHoursCurrent = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationTitleNext = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grVacationHoursNext = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationTitlePrev = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grVacationTitleAdvance = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grVacationCashNext = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationAdvancePrev = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationAdvanceCurrent = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grVacationAdvanceNext = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grSickDaysTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grVSAOITitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grIINExemptsTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grIINExemprUntaxedMinimum0 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlusMinusTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grPlusTaxed = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlusNotTaxed = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlusNoSAI = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlusAuthorsFees = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlusPFNotTaxed = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlusPFTaxed = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlusLINotTaxed = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlusLITaxed = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlusHINotTaxed = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlusHITaxed = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPlusNPNotTaxed = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grMinusBeforeIIN = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grIINTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grRateIIN2 = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grReverseTitle = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grAmountBeforeSNReverse = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDNSNAmountReverse = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grDDSNReverse = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grIINAmountReverse = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPayAdv = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grMinusAfterIIN = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPayT = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.grPayEmpty = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle();
            this.grDecimalReadOnly = new KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.sgrBonus = new KlonsLIB.MySourceGrid.MyGrid();
            this.grbIDSV = new KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB2();
            this.grbIsPaid = new KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox();
            this.grbIsInAvpay = new KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox();
            this.splitContainer2 = new KlonsLIB.Components.MySplitContainer();
            this.dgvLapa = new KlonsLIB.Components.MyDataGridView();
            this.dgvPapildsummas = new KlonsLIB.Components.MyDataGridView();
            this.dgcPsDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPsRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPsRateType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcPsAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPsIDSV = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcPsIDNO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcPsIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPsIDP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPsIDAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPsIDSX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.algasAprēķinaLapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pārrēķinātDarbiniekamToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pārrēķinātVisiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.vidējāsIzpeļņasAprēķinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slimībasNaudasAprēķinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atvaļinājumaNaudasAprēķinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darbaSamaksasAprēķinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAprekinaSeciba = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aprēķinaIzklāstsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.algasParēķinaLapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arAmatiemBezParakstiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bezAmatiemArParakstiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.miShoeBonusList = new System.Windows.Forms.ToolStripMenuItem();
            this.miRādītDarbiniekuAmatus = new System.Windows.Forms.ToolStripMenuItem();
            this.dgcSarSnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarPositionTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarFactDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarsFactHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCsARsALARY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarTotalBeforeTaxes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarDnSNAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarSNAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarIIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarAdvance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcSarPayT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsLapas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSarR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSarR2)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPapildsummasVeids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPapildsummaNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAlgasPapildsummas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPapildsummas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // salaryData1
            // 
            this.salaryData1._ACCIDENT_DAYS = 0;
            this.salaryData1._ACCIDENT_PAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._ADJUSTED_AMOUNT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._ADVANCE = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._AMOUNT_BEFORE_IIN = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._AMOUNT_BEFORE_IIN_REVERSE = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._AMOUNT_BEFORE_SN = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._AMOUNT_BEFORE_SN_REVERSE = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._AVERAGE_INCOME_DAYS = 0;
            this.salaryData1._AVERAGE_INCOME_PAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._AVPAYCALC_CALDAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._AVPAYCALC_DAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._AVPAYCALC_HOUR = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._BUSINESS_TRIP_DAYS = 0;
            this.salaryData1._BUSINESS_TRIP_PAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._CALENDAR_DAYS = 0;
            this.salaryData1._CALENDAR_DAYS_USE = 0;
            this.salaryData1._COMMENTS = null;
            this.salaryData1._DDSN_AMOUNT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._DDSN_AMOUNT_REVERSE = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._DNSN_AMOUNT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._DNSN_AMOUNT_REVERSE = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._FACT_AVPAY_FREE_DAYS = 0;
            this.salaryData1._FACT_AVPAY_FREE_HOURS = 0F;
            this.salaryData1._FACT_AVPAY_HOLIDAYS_HOURS = 0F;
            this.salaryData1._FACT_AVPAY_HOLIDAYS_HOURS_OVERT = 0F;
            this.salaryData1._FACT_AVPAY_HOURS = 0F;
            this.salaryData1._FACT_AVPAY_HOURS_OVERTIME = 0F;
            this.salaryData1._FACT_AVPAY_WORK_DAYS = 0;
            this.salaryData1._FACT_AVPAY_WORKINHOLIDAYS = 0;
            this.salaryData1._FACT_DAYS = 0;
            this.salaryData1._FACT_HOLIDAYS_DAYS = 0;
            this.salaryData1._FACT_HOLIDAYS_HOURS = 0F;
            this.salaryData1._FACT_HOLIDAYS_HOURS_NIGHT = 0F;
            this.salaryData1._FACT_HOLIDAYS_HOURS_OVERTIME = 0F;
            this.salaryData1._FACT_HOURS = 0F;
            this.salaryData1._FACT_HOURS_NIGHT = 0F;
            this.salaryData1._FACT_HOURS_OVERTIME = 0F;
            this.salaryData1._FACT_WORK_DAYS = 0;
            this.salaryData1._FACT_WORK_HOURS = 0F;
            this.salaryData1._FACT_WORK_HOURS_NIGHT = 0F;
            this.salaryData1._FACT_WORK_HOURS_OVERTIME = 0F;
            this.salaryData1._FNAME = null;
            this.salaryData1._FORAVPAYCALC_BRUTO = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._FORAVPAYCALC_DAYS = 0;
            this.salaryData1._FORAVPAYCALC_HOURS = 0F;
            this.salaryData1._FORAVPAYCALC_PAYOUT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._ID = 0;
            this.salaryData1._IDAM = null;
            this.salaryData1._IDP = 0;
            this.salaryData1._IDS = null;
            this.salaryData1._IDST = null;
            this.salaryData1._IDSX = null;
            this.salaryData1._IIN_AMOUNT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_AMOUNT_REVERSE = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_EXEMPT_2 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_EXEMPT_20 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_EXEMPT_2TP = ((short)(0));
            this.salaryData1._IIN_EXEMPT_DEPENDANTS = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_EXEMPT_DEPENDANTS0 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_EXEMPT_EXPENSES = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_EXEMPT_INVALIDITY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_EXEMPT_INVALIDITY0 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_EXEMPT_NATIONAL_MOVEMENT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_EXEMPT_NATIONAL_MOVEMENT0 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_EXEMPT_RETALIATION = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_EXEMPT_RETALIATION0 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_EXEMPT_UNTAXED_MINIMUM = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IIN_EXEMPT_UNTAXED_MINIMUM0 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._IS_TEMP = ((short)(0));
            this.salaryData1._LNAME = null;
            this.salaryData1._MINUS_AFTER_IIN = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._MINUS_BEFORE_IIN = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._MONTH_WORKDAYS = 0;
            this.salaryData1._MONTH_WORKHOURS = 0F;
            this.salaryData1._PAID_HOLIDAYS = 0;
            this.salaryData1._PAID_HOLIDAYS_PAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PAY_DATE = new System.DateTime(((long)(0)));
            this.salaryData1._PAY0 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PAYT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLAN_DAYS = 0;
            this.salaryData1._PLAN_HOLIDAYS_DAYS = 0;
            this.salaryData1._PLAN_HOLIDAYS_HOURS = 0F;
            this.salaryData1._PLAN_HOLIDAYS_HOURS_NIGHT = 0F;
            this.salaryData1._PLAN_HOLIDAYS_HOURS_OVERTIME = 0F;
            this.salaryData1._PLAN_HOURS = 0F;
            this.salaryData1._PLAN_HOURS_NIGHT = 0F;
            this.salaryData1._PLAN_HOURS_OVERTIME = 0F;
            this.salaryData1._PLAN_WORK_DAYS = 0;
            this.salaryData1._PLAN_WORK_HOURS = 0F;
            this.salaryData1._PLAN_WORK_HOURS_NIGHT = 0F;
            this.salaryData1._PLAN_WORK_HOURS_OVERTIME = 0F;
            this.salaryData1._PLUS_AUTHORS_FEES = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLUS_HI_NOTTAXED = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLUS_HI_TAXED = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLUS_LI_NOTTAXED = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLUS_LI_TAXED = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLUS_NOSAI = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLUS_NOT_PAID = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLUS_NOTTAXED = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLUS_NP_NOSAI = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLUS_NP_NOTTAXED = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLUS_NP_TAXED = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLUS_PF_NOTTAXED = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLUS_PF_TAXED = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._PLUS_TAXED = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._POSITION_TITLE = null;
            this.salaryData1._R_HR = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._R_HR_HOLIDAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._R_HR_HOLIDAY_NIGHT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._R_HR_HOLIDAY_OVERTIME = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._R_HR_NIGHT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._R_HR_OVERTIME = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._R_HR_TYPE = ((short)(0));
            this.salaryData1._R_MT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._R_MT_HOLIDAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._R_MT_HOLIDAY_NIGHT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._R_MT_HOLIDAY_NIGHT_TYPE = ((short)(0));
            this.salaryData1._R_MT_HOLIDAY_OVERTIME = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._R_MT_HOLIDAY_OVERTIME_TYPE = ((short)(0));
            this.salaryData1._R_MT_HOLIDAY_TYPE = ((short)(0));
            this.salaryData1._R_MT_NIGHT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._R_MT_NIGHT_TYPE = ((short)(0));
            this.salaryData1._R_MT_OVERTIME = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._R_MT_OVERTIME_TYPE = ((short)(0));
            this.salaryData1._R_TYPE = ((short)(0));
            this.salaryData1._RATE_DDSN = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._RATE_DNSN = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._RATE_IIN = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._RATE_IIN2 = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_AVPAY_FREE_DAYS = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_AVPAY_HOLIDAYS = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_AVPAY_HOLIDAYS_OVERTIME = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_AVPAY_WORK_DAYS = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_AVPAY_WORK_DAYS_OVERTIME = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_DAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_HOLIDAYS_DAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_HOLIDAYS_NIGHT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_HOLIDAYS_OVERTIME = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_NIGHT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_OVERTIME = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_PAID_HOLIDAYS_DAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_PAID_HOLIDAYS_NIGHT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SALARY_PIECEWORK = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SICKDAYS = 0;
            this.salaryData1._SICKDAYS_PAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SN_AMOUNT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SN_MAX_AMOUNT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._SNR = 0;
            this.salaryData1._TERRITORIAL_CODE = null;
            this.salaryData1._TOTAL_BEFORE_TAXES = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._URVN_AMAOUNT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_ADVANCE_CURRENT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_ADVANCE_NEXT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_ADVANCE_PREV = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_CASH_NEXT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_DAYS_CURRENT = 0F;
            this.salaryData1._VACATION_DAYS_NEXT = 0F;
            this.salaryData1._VACATION_DDS_NEXT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_DDS_PREV = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_DNS_NEXT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_DNS_PREV = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_HOURS_CURRENT = 0F;
            this.salaryData1._VACATION_HOURS_NEXT = 0F;
            this.salaryData1._VACATION_IIN_NEXT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_IIN_PREV = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_IIN_REDUCE_NEXT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_PAY_CURRENT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_PAY_NEXT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._VACATION_PAY_PREV = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.salaryData1._WITHHOLD_FROM_PAY = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            // 
            // bsLapas
            // 
            this.bsLapas.DataMember = "SALARY_SHEETS";
            this.bsLapas.Filter = "ISFIRSTMT = FALSE";
            this.bsLapas.MyDataSource = "KlonsData";
            this.bsLapas.Sort = "yr desc, mt desc,snr desc";
            this.bsLapas.CurrentChanged += new System.EventHandler(this.bsLapas_CurrentChanged);
            // 
            // bsSarR
            // 
            this.bsSarR.DataMember = "FK_SALARY_SHEETS_R_IDS";
            this.bsSarR.DataSource = this.bsLapas;
            this.bsSarR.CurrentChanged += new System.EventHandler(this.bsSarR_CurrentChanged);
            this.bsSarR.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsSarR_ListChanged);
            // 
            // bsSarR2
            // 
            this.bsSarR2.DataSource = this.bsSarR;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslLabel,
            this.tsbNew,
            this.tsbDelete,
            this.tsbSave,
            this.tslAmati});
            this.toolStrip2.Location = new System.Drawing.Point(0, 445);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0, 2, 1, 2);
            this.toolStrip2.Size = new System.Drawing.Size(998, 42);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tslLabel
            // 
            this.tslLabel.Name = "tslLabel";
            this.tslLabel.Size = new System.Drawing.Size(95, 35);
            this.tslLabel.Text = "Aprēķins:";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.RightToLeftAutoMirrorImage = true;
            this.tsbNew.Size = new System.Drawing.Size(91, 35);
            this.tsbNew.Text = "Jauns";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.Margin = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.RightToLeftAutoMirrorImage = true;
            this.tsbDelete.Size = new System.Drawing.Size(87, 31);
            this.tsbDelete.Text = "Dzēst";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.tsbSave.Size = new System.Drawing.Size(25, 35);
            this.tsbSave.Text = "toolStripButton1";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tslAmati
            // 
            this.tslAmati.Name = "tslAmati";
            this.tslAmati.Size = new System.Drawing.Size(89, 35);
            this.tslAmati.Text = "   Amats:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslPeriod});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 2, 1, 2);
            this.toolStrip1.Size = new System.Drawing.Size(998, 32);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslPeriod
            // 
            this.tslPeriod.Name = "tslPeriod";
            this.tslPeriod.Size = new System.Drawing.Size(84, 25);
            this.tslPeriod.Text = "Periods:";
            // 
            // cbLapas
            // 
            this.cbLapas._AllowSelection = true;
            this.cbLapas.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbLapas.ColumnNames = new string[] {
        "ID"};
            this.cbLapas.ColumnWidths = "400";
            this.cbLapas.DataSource = this.bsLapas;
            this.cbLapas.DisplayMember = "ID";
            this.cbLapas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLapas.DropDownHeight = 255;
            this.cbLapas.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbLapas.DropDownWidth = 424;
            this.cbLapas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLapas.FormattingEnabled = true;
            this.cbLapas.GridLineColor = System.Drawing.Color.LightGray;
            this.cbLapas.GridLineHorizontal = false;
            this.cbLapas.GridLineVertical = false;
            this.cbLapas.IntegralHeight = false;
            this.cbLapas.Location = new System.Drawing.Point(227, 0);
            this.cbLapas.MaxDropDownItems = 15;
            this.cbLapas.Name = "cbLapas";
            this.cbLapas.Size = new System.Drawing.Size(400, 23);
            this.cbLapas.TabIndex = 11;
            this.cbLapas.ValueMember = "ID";
            this.cbLapas.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbLapas_Format);
            this.cbLapas.Enter += new System.EventHandler(this.dgvPapildsummas_Enter);
            // 
            // bsAmati
            // 
            this.bsAmati.DataMember = "POSITIONS";
            this.bsAmati.MyDataSource = "KlonsData";
            // 
            // bsPapildsummasVeids
            // 
            this.bsPapildsummasVeids.DataMember = "PLUSMINUS_TYPES";
            this.bsPapildsummasVeids.Filter = "TP3 = 1";
            this.bsPapildsummasVeids.MyDataSource = "KlonsData";
            this.bsPapildsummasVeids.Sort = "SN";
            // 
            // bsPapildsummaNo
            // 
            this.bsPapildsummaNo.DataMember = "PLUSMINUS_FROM";
            this.bsPapildsummaNo.MyDataSource = "KlonsData";
            this.bsPapildsummaNo.Sort = "ID";
            // 
            // bsAlgasPapildsummas
            // 
            this.bsAlgasPapildsummas.DataMember = "FK_SALARY_PLUSMINUS_IDSX";
            this.bsAlgasPapildsummas.DataSource = this.bsSarR;
            this.bsAlgasPapildsummas.CurrentChanged += new System.EventHandler(this.bsAlgasPapildsummas_CurrentChanged);
            this.bsAlgasPapildsummas.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsAlgasPapildsummas_ListChanged);
            // 
            // grPersonTitle
            // 
            this.grPersonTitle.Name = "grPersonTitle";
            this.grPersonTitle.RowTitle = "Darbinieks";
            this.grPersonTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // grFName
            // 
            this.grFName.DataMember = "FNAME";
            this.grFName.DataSource = this.bsSarR2;
            this.grFName.EditorTemplateName = "grString";
            this.grFName.GridPropertyName = "_FNAME";
            this.grFName.Name = "grFName";
            this.grFName.ReadOnly = true;
            this.grFName.RowTitle = "Vārds";
            this.grFName.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grLName
            // 
            this.grLName.DataMember = "LNAME";
            this.grLName.DataSource = this.bsSarR2;
            this.grLName.EditorTemplateName = "grString";
            this.grLName.GridPropertyName = "_LNAME";
            this.grLName.Name = "grLName";
            this.grLName.ReadOnly = true;
            this.grLName.RowTitle = "Uzvārds";
            this.grLName.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grPositionTitle
            // 
            this.grPositionTitle.DataMember = "POSITION_TITLE";
            this.grPositionTitle.DataSource = this.bsSarR2;
            this.grPositionTitle.EditorTemplateName = "grString";
            this.grPositionTitle.GridPropertyName = "_POSITION_TITLE";
            this.grPositionTitle.Name = "grPositionTitle";
            this.grPositionTitle.ReadOnly = true;
            this.grPositionTitle.RowTitle = "Amats";
            this.grPositionTitle.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grPlanDays
            // 
            this.grPlanDays.DataMember = "PLAN_DAYS";
            this.grPlanDays.DataSource = this.bsSarR2;
            this.grPlanDays.EditorTemplateName = "grtInt";
            this.grPlanDays.GridPropertyName = "_PLAN_DAYS";
            this.grPlanDays.Name = "grPlanDays";
            this.grPlanDays.ReadOnly = true;
            this.grPlanDays.RowTitle = "Dienas";
            this.grPlanDays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grPlanHours
            // 
            this.grPlanHours.DataMember = "PLAN_HOURS";
            this.grPlanHours.DataSource = this.bsSarR2;
            this.grPlanHours.EditorTemplateName = "grSingle";
            this.grPlanHours.GridPropertyName = "_PLAN_HOURS";
            this.grPlanHours.Name = "grPlanHours";
            this.grPlanHours.ReadOnly = true;
            this.grPlanHours.RowTitle = "Stundas";
            this.grPlanHours.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grPlanHoursNight
            // 
            this.grPlanHoursNight.DataMember = "PLAN_HOURS_NIGHT";
            this.grPlanHoursNight.DataSource = this.bsSarR2;
            this.grPlanHoursNight.EditorTemplateName = "grSingle";
            this.grPlanHoursNight.GridPropertyName = "_PLAN_HOURS_NIGHT";
            this.grPlanHoursNight.Name = "grPlanHoursNight";
            this.grPlanHoursNight.ReadOnly = true;
            this.grPlanHoursNight.RowTitle = "Stundas naktī";
            this.grPlanHoursNight.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grPlanHoursOvertime
            // 
            this.grPlanHoursOvertime.DataMember = "PLAN_HOURS_OVERTIME";
            this.grPlanHoursOvertime.DataSource = this.bsSarR2;
            this.grPlanHoursOvertime.EditorTemplateName = "grSingle";
            this.grPlanHoursOvertime.GridPropertyName = "_PLAN_HOURS_OVERTIME";
            this.grPlanHoursOvertime.Name = "grPlanHoursOvertime";
            this.grPlanHoursOvertime.ReadOnly = true;
            this.grPlanHoursOvertime.RowTitle = "Virsstundas";
            this.grPlanHoursOvertime.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grPlanWeekDays
            // 
            this.grPlanWeekDays.DataMember = "PLAN_WORK_DAYS";
            this.grPlanWeekDays.DataSource = this.bsSarR2;
            this.grPlanWeekDays.EditorTemplateName = "grtInt";
            this.grPlanWeekDays.GridPropertyName = "_PLAN_WORK_DAYS";
            this.grPlanWeekDays.Name = "grPlanWeekDays";
            this.grPlanWeekDays.ReadOnly = true;
            this.grPlanWeekDays.RowTitle = "Dienas";
            this.grPlanWeekDays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grPlanWeekHours
            // 
            this.grPlanWeekHours.DataMember = "PLAN_WORK_HOURS";
            this.grPlanWeekHours.DataSource = this.bsSarR2;
            this.grPlanWeekHours.EditorTemplateName = "grSingle";
            this.grPlanWeekHours.GridPropertyName = "_PLAN_WORK_HOURS";
            this.grPlanWeekHours.Name = "grPlanWeekHours";
            this.grPlanWeekHours.ReadOnly = true;
            this.grPlanWeekHours.RowTitle = "Stundas";
            this.grPlanWeekHours.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grPlanWeekHoirsNight
            // 
            this.grPlanWeekHoirsNight.DataMember = "PLAN_WORK_HOURS_NIGHT";
            this.grPlanWeekHoirsNight.DataSource = this.bsSarR2;
            this.grPlanWeekHoirsNight.EditorTemplateName = "grSingle";
            this.grPlanWeekHoirsNight.FormatString = "";
            this.grPlanWeekHoirsNight.GridPropertyName = "_PLAN_WORK_HOURS_NIGHT";
            this.grPlanWeekHoirsNight.Name = "grPlanWeekHoirsNight";
            this.grPlanWeekHoirsNight.ReadOnly = true;
            this.grPlanWeekHoirsNight.RowTitle = "Stundas naktī";
            this.grPlanWeekHoirsNight.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grPlanWeekHoursOvertime
            // 
            this.grPlanWeekHoursOvertime.DataMember = "PLAN_WORK_HOURS_OVERTIME";
            this.grPlanWeekHoursOvertime.DataSource = this.bsSarR2;
            this.grPlanWeekHoursOvertime.EditorTemplateName = "grSingle";
            this.grPlanWeekHoursOvertime.GridPropertyName = "_PLAN_WORK_HOURS_OVERTIME";
            this.grPlanWeekHoursOvertime.Name = "grPlanWeekHoursOvertime";
            this.grPlanWeekHoursOvertime.ReadOnly = true;
            this.grPlanWeekHoursOvertime.RowTitle = "Virstundas";
            this.grPlanWeekHoursOvertime.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grPlanHolidaysDays
            // 
            this.grPlanHolidaysDays.DataMember = "PLAN_HOLIDAYS_DAYS";
            this.grPlanHolidaysDays.DataSource = this.bsSarR2;
            this.grPlanHolidaysDays.EditorTemplateName = "grtInt";
            this.grPlanHolidaysDays.GridPropertyName = "_PLAN_HOLIDAYS_DAYS";
            this.grPlanHolidaysDays.Name = "grPlanHolidaysDays";
            this.grPlanHolidaysDays.ReadOnly = true;
            this.grPlanHolidaysDays.RowTitle = "Dienas";
            this.grPlanHolidaysDays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grPlanHolidaysHours
            // 
            this.grPlanHolidaysHours.DataMember = "FACT_HOLIDAYS_HOURS";
            this.grPlanHolidaysHours.DataSource = this.bsSarR2;
            this.grPlanHolidaysHours.EditorTemplateName = "grSingle";
            this.grPlanHolidaysHours.GridPropertyName = "_PLAN_HOLIDAYS_HOURS";
            this.grPlanHolidaysHours.Name = "grPlanHolidaysHours";
            this.grPlanHolidaysHours.ReadOnly = true;
            this.grPlanHolidaysHours.RowTitle = "Stundas";
            this.grPlanHolidaysHours.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grPlanHolidaysHoursNight
            // 
            this.grPlanHolidaysHoursNight.DataMember = "PLAN_HOLIDAYS_HOURS_NIGHT";
            this.grPlanHolidaysHoursNight.DataSource = this.bsSarR2;
            this.grPlanHolidaysHoursNight.EditorTemplateName = "grSingle";
            this.grPlanHolidaysHoursNight.GridPropertyName = "_PLAN_HOLIDAYS_HOURS_NIGHT";
            this.grPlanHolidaysHoursNight.Name = "grPlanHolidaysHoursNight";
            this.grPlanHolidaysHoursNight.ReadOnly = true;
            this.grPlanHolidaysHoursNight.RowTitle = "Stundas naktī";
            this.grPlanHolidaysHoursNight.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grPlanHolidaysHoursOvertime
            // 
            this.grPlanHolidaysHoursOvertime.DataMember = "PLAN_HOLIDAYS_HOURS_OVERTIME";
            this.grPlanHolidaysHoursOvertime.DataSource = this.bsSarR2;
            this.grPlanHolidaysHoursOvertime.EditorTemplateName = "grSingle";
            this.grPlanHolidaysHoursOvertime.GridPropertyName = "_PLAN_HOLIDAYS_HOURS_OVERTIME";
            this.grPlanHolidaysHoursOvertime.Name = "grPlanHolidaysHoursOvertime";
            this.grPlanHolidaysHoursOvertime.ReadOnly = true;
            this.grPlanHolidaysHoursOvertime.RowTitle = "Virsstundas";
            this.grPlanHolidaysHoursOvertime.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactDays
            // 
            this.grFactDays.DataMember = "FACT_DAYS";
            this.grFactDays.DataSource = this.bsSarR2;
            this.grFactDays.EditorTemplateName = "grtInt";
            this.grFactDays.GridPropertyName = "_FACT_DAYS";
            this.grFactDays.Name = "grFactDays";
            this.grFactDays.ReadOnly = true;
            this.grFactDays.RowTitle = "Dienas";
            this.grFactDays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grFactHours
            // 
            this.grFactHours.DataMember = "FACT_HOURS";
            this.grFactHours.DataSource = this.bsSarR2;
            this.grFactHours.EditorTemplateName = "grSingle";
            this.grFactHours.GridPropertyName = "_FACT_HOURS";
            this.grFactHours.Name = "grFactHours";
            this.grFactHours.ReadOnly = true;
            this.grFactHours.RowTitle = "Stundas";
            this.grFactHours.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactHoursNight
            // 
            this.grFactHoursNight.DataMember = "FACT_HOURS_NIGHT";
            this.grFactHoursNight.DataSource = this.bsSarR2;
            this.grFactHoursNight.EditorTemplateName = "grSingle";
            this.grFactHoursNight.GridPropertyName = "_FACT_HOURS_NIGHT";
            this.grFactHoursNight.Name = "grFactHoursNight";
            this.grFactHoursNight.ReadOnly = true;
            this.grFactHoursNight.RowTitle = "Stundas naktī";
            this.grFactHoursNight.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactHoursOvertime
            // 
            this.grFactHoursOvertime.DataMember = "FACT_HOURS_OVERTIME";
            this.grFactHoursOvertime.DataSource = this.bsSarR2;
            this.grFactHoursOvertime.EditorTemplateName = "grSingle";
            this.grFactHoursOvertime.GridPropertyName = "_FACT_HOURS_OVERTIME";
            this.grFactHoursOvertime.Name = "grFactHoursOvertime";
            this.grFactHoursOvertime.ReadOnly = true;
            this.grFactHoursOvertime.RowTitle = "Virsstundas";
            this.grFactHoursOvertime.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactWeekDays
            // 
            this.grFactWeekDays.DataMember = "FACT_WORK_DAYS";
            this.grFactWeekDays.DataSource = this.bsSarR2;
            this.grFactWeekDays.EditorTemplateName = "grtInt";
            this.grFactWeekDays.GridPropertyName = "_FACT_WORK_DAYS";
            this.grFactWeekDays.Name = "grFactWeekDays";
            this.grFactWeekDays.ReadOnly = true;
            this.grFactWeekDays.RowTitle = "Dienas";
            this.grFactWeekDays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grFactWeekHours
            // 
            this.grFactWeekHours.DataMember = "FACT_WORK_HOURS";
            this.grFactWeekHours.DataSource = this.bsSarR2;
            this.grFactWeekHours.EditorTemplateName = "grSingle";
            this.grFactWeekHours.GridPropertyName = "_FACT_WORK_HOURS";
            this.grFactWeekHours.Name = "grFactWeekHours";
            this.grFactWeekHours.ReadOnly = true;
            this.grFactWeekHours.RowTitle = "Stundas";
            this.grFactWeekHours.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactWeekHoursNight
            // 
            this.grFactWeekHoursNight.DataMember = "FACT_WORK_HOURS_NIGHT";
            this.grFactWeekHoursNight.DataSource = this.bsSarR2;
            this.grFactWeekHoursNight.EditorTemplateName = "grSingle";
            this.grFactWeekHoursNight.GridPropertyName = "_FACT_WORK_HOURS_NIGHT";
            this.grFactWeekHoursNight.Name = "grFactWeekHoursNight";
            this.grFactWeekHoursNight.ReadOnly = true;
            this.grFactWeekHoursNight.RowTitle = "Stundas naktī";
            this.grFactWeekHoursNight.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactWeekHoursOvertime
            // 
            this.grFactWeekHoursOvertime.DataMember = "FACT_WORK_HOURS_OVERTIME";
            this.grFactWeekHoursOvertime.DataSource = this.bsSarR2;
            this.grFactWeekHoursOvertime.EditorTemplateName = "grSingle";
            this.grFactWeekHoursOvertime.GridPropertyName = "_FACT_WORK_HOURS_OVERTIME";
            this.grFactWeekHoursOvertime.Name = "grFactWeekHoursOvertime";
            this.grFactWeekHoursOvertime.ReadOnly = true;
            this.grFactWeekHoursOvertime.RowTitle = "Virsstundas";
            this.grFactWeekHoursOvertime.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactHolidays
            // 
            this.grFactHolidays.DataMember = "FACT_HOLIDAYS_DAYS";
            this.grFactHolidays.DataSource = this.bsSarR2;
            this.grFactHolidays.EditorTemplateName = "grtInt";
            this.grFactHolidays.GridPropertyName = "_FACT_HOLIDAYS_DAYS";
            this.grFactHolidays.Name = "grFactHolidays";
            this.grFactHolidays.ReadOnly = true;
            this.grFactHolidays.RowTitle = "Dienas";
            this.grFactHolidays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grFactHolidaysHours
            // 
            this.grFactHolidaysHours.DataMember = "FACT_HOLIDAYS_HOURS";
            this.grFactHolidaysHours.DataSource = this.bsSarR2;
            this.grFactHolidaysHours.EditorTemplateName = "grSingle";
            this.grFactHolidaysHours.GridPropertyName = "_FACT_HOLIDAYS_HOURS";
            this.grFactHolidaysHours.Name = "grFactHolidaysHours";
            this.grFactHolidaysHours.ReadOnly = true;
            this.grFactHolidaysHours.RowTitle = "Stundas";
            this.grFactHolidaysHours.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactHolidaysHoursNight
            // 
            this.grFactHolidaysHoursNight.DataMember = "FACT_HOLIDAYS_HOURS_NIGHT";
            this.grFactHolidaysHoursNight.DataSource = this.bsSarR2;
            this.grFactHolidaysHoursNight.EditorTemplateName = "grSingle";
            this.grFactHolidaysHoursNight.GridPropertyName = "_FACT_HOLIDAYS_HOURS_NIGHT";
            this.grFactHolidaysHoursNight.Name = "grFactHolidaysHoursNight";
            this.grFactHolidaysHoursNight.ReadOnly = true;
            this.grFactHolidaysHoursNight.RowTitle = "Stundas naktī";
            this.grFactHolidaysHoursNight.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactHolidaysHoursOvertime
            // 
            this.grFactHolidaysHoursOvertime.DataMember = "FACT_HOLIDAYS_HOURS_OVERTIME";
            this.grFactHolidaysHoursOvertime.DataSource = this.bsSarR2;
            this.grFactHolidaysHoursOvertime.EditorTemplateName = "grSingle";
            this.grFactHolidaysHoursOvertime.GridPropertyName = "_FACT_HOLIDAYS_HOURS_OVERTIME";
            this.grFactHolidaysHoursOvertime.Name = "grFactHolidaysHoursOvertime";
            this.grFactHolidaysHoursOvertime.ReadOnly = true;
            this.grFactHolidaysHoursOvertime.RowTitle = "Virsstundas";
            this.grFactHolidaysHoursOvertime.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactAvPayFreeDays
            // 
            this.grFactAvPayFreeDays.DataMember = "FACT_AVPAY_FREE_DAYS";
            this.grFactAvPayFreeDays.DataSource = this.bsSarR2;
            this.grFactAvPayFreeDays.EditorTemplateName = "grtInt";
            this.grFactAvPayFreeDays.FormatString = "";
            this.grFactAvPayFreeDays.GridPropertyName = "_FACT_AVPAY_FREE_DAYS";
            this.grFactAvPayFreeDays.Name = "grFactAvPayFreeDays";
            this.grFactAvPayFreeDays.ReadOnly = true;
            this.grFactAvPayFreeDays.RowTitle = "Attaisnota kavējuma dienas";
            this.grFactAvPayFreeDays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grFactAvPayFreeHours
            // 
            this.grFactAvPayFreeHours.DataMember = "FACT_AVPAY_FREE_HOURS";
            this.grFactAvPayFreeHours.DataSource = this.bsSarR2;
            this.grFactAvPayFreeHours.EditorTemplateName = "grSingle";
            this.grFactAvPayFreeHours.GridPropertyName = "_FACT_AVPAY_FREE_HOURS";
            this.grFactAvPayFreeHours.Name = "grFactAvPayFreeHours";
            this.grFactAvPayFreeHours.ReadOnly = true;
            this.grFactAvPayFreeHours.RowTitle = "Attaisnota kavējuma stundas";
            this.grFactAvPayFreeHours.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactAvPayWorkDays
            // 
            this.grFactAvPayWorkDays.DataMember = "FACT_AVPAY_WORK_DAYS";
            this.grFactAvPayWorkDays.DataSource = this.bsSarR2;
            this.grFactAvPayWorkDays.EditorTemplateName = "grtInt";
            this.grFactAvPayWorkDays.GridPropertyName = "_FACT_AVPAY_WORK_DAYS";
            this.grFactAvPayWorkDays.Name = "grFactAvPayWorkDays";
            this.grFactAvPayWorkDays.ReadOnly = true;
            this.grFactAvPayWorkDays.RowTitle = "Darba dienas ar VI";
            this.grFactAvPayWorkDays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grFactAvPayHours
            // 
            this.grFactAvPayHours.DataMember = "FACT_AVPAY_HOURS";
            this.grFactAvPayHours.DataSource = this.bsSarR2;
            this.grFactAvPayHours.EditorTemplateName = "grSingle";
            this.grFactAvPayHours.GridPropertyName = "_FACT_AVPAY_HOURS";
            this.grFactAvPayHours.Name = "grFactAvPayHours";
            this.grFactAvPayHours.ReadOnly = true;
            this.grFactAvPayHours.RowTitle = "Darba dienas ar VI: stundas";
            this.grFactAvPayHours.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactAvPayHoursOvertime
            // 
            this.grFactAvPayHoursOvertime.DataMember = "FACT_AVPAY_HOURS_OVERTIME";
            this.grFactAvPayHoursOvertime.DataSource = this.bsSarR2;
            this.grFactAvPayHoursOvertime.EditorTemplateName = "grSingle";
            this.grFactAvPayHoursOvertime.GridPropertyName = "_FACT_AVPAY_HOURS_OVERTIME";
            this.grFactAvPayHoursOvertime.Name = "grFactAvPayHoursOvertime";
            this.grFactAvPayHoursOvertime.ReadOnly = true;
            this.grFactAvPayHoursOvertime.RowTitle = "Darba dienas ar VI: virsst.";
            this.grFactAvPayHoursOvertime.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactAvPayWorkInHolidays
            // 
            this.grFactAvPayWorkInHolidays.DataMember = "FACT_AVPAY_WORKINHOLIDAYS";
            this.grFactAvPayWorkInHolidays.DataSource = this.bsSarR2;
            this.grFactAvPayWorkInHolidays.EditorTemplateName = "grtInt";
            this.grFactAvPayWorkInHolidays.GridPropertyName = "_FACT_AVPAY_WORKINHOLIDAYS";
            this.grFactAvPayWorkInHolidays.Name = "grFactAvPayWorkInHolidays";
            this.grFactAvPayWorkInHolidays.ReadOnly = true;
            this.grFactAvPayWorkInHolidays.RowSpan = 2;
            this.grFactAvPayWorkInHolidays.RowTitle = "Darba dienas svētku dienās ar VI";
            this.grFactAvPayWorkInHolidays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grFactAvPayHolidaysHours
            // 
            this.grFactAvPayHolidaysHours.DataMember = "FACT_AVPAY_HOLIDAYS_HOURS";
            this.grFactAvPayHolidaysHours.DataSource = this.bsSarR2;
            this.grFactAvPayHolidaysHours.EditorTemplateName = "grSingle";
            this.grFactAvPayHolidaysHours.GridPropertyName = "_FACT_AVPAY_HOLIDAYS_HOURS";
            this.grFactAvPayHolidaysHours.Name = "grFactAvPayHolidaysHours";
            this.grFactAvPayHolidaysHours.ReadOnly = true;
            this.grFactAvPayHolidaysHours.RowSpan = 2;
            this.grFactAvPayHolidaysHours.RowTitle = "Darba dienas svētku dienās ar VI: stundas";
            this.grFactAvPayHolidaysHours.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grFactAvPayHolidaysHoursOvertime
            // 
            this.grFactAvPayHolidaysHoursOvertime.DataMember = "FACT_AVPAY_HOLIDAYS_HOURS_OVERT";
            this.grFactAvPayHolidaysHoursOvertime.DataSource = this.bsSarR2;
            this.grFactAvPayHolidaysHoursOvertime.EditorTemplateName = "grSingle";
            this.grFactAvPayHolidaysHoursOvertime.GridPropertyName = "_FACT_AVPAY_HOLIDAYS_HOURS_OVERT";
            this.grFactAvPayHolidaysHoursOvertime.Name = "grFactAvPayHolidaysHoursOvertime";
            this.grFactAvPayHolidaysHoursOvertime.ReadOnly = true;
            this.grFactAvPayHolidaysHoursOvertime.RowSpan = 2;
            this.grFactAvPayHolidaysHoursOvertime.RowTitle = "Darba dienas svētku dienās ar VI: virstundas";
            this.grFactAvPayHolidaysHoursOvertime.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grSalary
            // 
            this.grSalary.DataMember = "SALARY";
            this.grSalary.DataSource = this.bsSarR2;
            this.grSalary.EditorTemplateName = "grDecimalReadOnly";
            this.grSalary.GridPropertyName = "_SALARY";
            this.grSalary.Name = "grSalary";
            this.grSalary.ReadOnly = true;
            this.grSalary.RowTitle = "Kopā";
            this.grSalary.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSalaryDay
            // 
            this.grSalaryDay.DataMember = "SALARY_DAY";
            this.grSalaryDay.DataSource = this.bsSarR2;
            this.grSalaryDay.EditorTemplateName = "grDecimalReadOnly";
            this.grSalaryDay.GridPropertyName = "_SALARY_DAY";
            this.grSalaryDay.Name = "grSalaryDay";
            this.grSalaryDay.ReadOnly = true;
            this.grSalaryDay.RowTitle = "Pamatsumma";
            this.grSalaryDay.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSalaryNight
            // 
            this.grSalaryNight.DataMember = "SALARY_NIGHT";
            this.grSalaryNight.DataSource = this.bsSarR2;
            this.grSalaryNight.EditorTemplateName = "grDecimalReadOnly";
            this.grSalaryNight.GridPropertyName = "_SALARY_NIGHT";
            this.grSalaryNight.Name = "grSalaryNight";
            this.grSalaryNight.ReadOnly = true;
            this.grSalaryNight.RowTitle = "Par nakts darbu";
            this.grSalaryNight.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSalaryOvertime
            // 
            this.grSalaryOvertime.DataMember = "SALARY_OVERTIME";
            this.grSalaryOvertime.DataSource = this.bsSarR2;
            this.grSalaryOvertime.EditorTemplateName = "grDecimalReadOnly";
            this.grSalaryOvertime.GridPropertyName = "_SALARY_OVERTIME";
            this.grSalaryOvertime.Name = "grSalaryOvertime";
            this.grSalaryOvertime.ReadOnly = true;
            this.grSalaryOvertime.RowTitle = "Par virsstundām";
            this.grSalaryOvertime.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSalaryHolidaysDay
            // 
            this.grSalaryHolidaysDay.DataMember = "SALARY_HOLIDAYS_DAY";
            this.grSalaryHolidaysDay.DataSource = this.bsSarR2;
            this.grSalaryHolidaysDay.EditorTemplateName = "grDecimalReadOnly";
            this.grSalaryHolidaysDay.GridPropertyName = "_SALARY_HOLIDAYS_DAY";
            this.grSalaryHolidaysDay.Name = "grSalaryHolidaysDay";
            this.grSalaryHolidaysDay.ReadOnly = true;
            this.grSalaryHolidaysDay.RowTitle = "Par darbu svētku dienās";
            this.grSalaryHolidaysDay.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSalaryHolidaysNight
            // 
            this.grSalaryHolidaysNight.DataMember = "SALARY_HOLIDAYS_NIGHT";
            this.grSalaryHolidaysNight.DataSource = this.bsSarR2;
            this.grSalaryHolidaysNight.EditorTemplateName = "grDecimalReadOnly";
            this.grSalaryHolidaysNight.GridPropertyName = "_SALARY_HOLIDAYS_NIGHT";
            this.grSalaryHolidaysNight.Name = "grSalaryHolidaysNight";
            this.grSalaryHolidaysNight.ReadOnly = true;
            this.grSalaryHolidaysNight.RowTitle = "Par darbu naktī svētku dienās";
            this.grSalaryHolidaysNight.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSalaryHolidaysOvertime
            // 
            this.grSalaryHolidaysOvertime.DataMember = "SALARY_HOLIDAYS_OVERTIME";
            this.grSalaryHolidaysOvertime.DataSource = this.bsSarR2;
            this.grSalaryHolidaysOvertime.EditorTemplateName = "grDecimalReadOnly";
            this.grSalaryHolidaysOvertime.GridPropertyName = "_SALARY_HOLIDAYS_OVERTIME";
            this.grSalaryHolidaysOvertime.Name = "grSalaryHolidaysOvertime";
            this.grSalaryHolidaysOvertime.ReadOnly = true;
            this.grSalaryHolidaysOvertime.RowTitle = "Par virsstundām svētku d.";
            this.grSalaryHolidaysOvertime.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSalaryAvPayFreeDays
            // 
            this.grSalaryAvPayFreeDays.DataMember = "SALARY_AVPAY_FREE_DAYS";
            this.grSalaryAvPayFreeDays.DataSource = this.bsSarR2;
            this.grSalaryAvPayFreeDays.EditorTemplateName = "grDecimalReadOnly";
            this.grSalaryAvPayFreeDays.GridPropertyName = "_SALARY_AVPAY_FREE_DAYS";
            this.grSalaryAvPayFreeDays.Name = "grSalaryAvPayFreeDays";
            this.grSalaryAvPayFreeDays.ReadOnly = true;
            this.grSalaryAvPayFreeDays.RowTitle = "Par attaisn. ne-darba d.";
            this.grSalaryAvPayFreeDays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSalaryAvPayWorkDays
            // 
            this.grSalaryAvPayWorkDays.DataMember = "SALARY_AVPAY_WORK_DAYS";
            this.grSalaryAvPayWorkDays.DataSource = this.bsSarR2;
            this.grSalaryAvPayWorkDays.EditorTemplateName = "grDecimalReadOnly";
            this.grSalaryAvPayWorkDays.GridPropertyName = "_SALARY_AVPAY_WORK_DAYS";
            this.grSalaryAvPayWorkDays.Name = "grSalaryAvPayWorkDays";
            this.grSalaryAvPayWorkDays.ReadOnly = true;
            this.grSalaryAvPayWorkDays.RowTitle = "Par darba d. ar vid.izp.";
            this.grSalaryAvPayWorkDays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSalaryAvPayWorkDaysOvertime
            // 
            this.grSalaryAvPayWorkDaysOvertime.DataMember = "SALARY_AVPAY_WORK_DAYS_OVERTIME";
            this.grSalaryAvPayWorkDaysOvertime.DataSource = this.bsSarR2;
            this.grSalaryAvPayWorkDaysOvertime.EditorTemplateName = "grDecimalReadOnly";
            this.grSalaryAvPayWorkDaysOvertime.GridPropertyName = "_SALARY_AVPAY_WORK_DAYS_OVERTIME";
            this.grSalaryAvPayWorkDaysOvertime.Name = "grSalaryAvPayWorkDaysOvertime";
            this.grSalaryAvPayWorkDaysOvertime.ReadOnly = true;
            this.grSalaryAvPayWorkDaysOvertime.RowTitle = "Par virsst. ar vid.izp.";
            this.grSalaryAvPayWorkDaysOvertime.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSalaryAvPayHolidays
            // 
            this.grSalaryAvPayHolidays.DataMember = "SALARY_AVPAY_HOLIDAYS";
            this.grSalaryAvPayHolidays.DataSource = this.bsSarR2;
            this.grSalaryAvPayHolidays.EditorTemplateName = "grDecimalReadOnly";
            this.grSalaryAvPayHolidays.GridPropertyName = "_SALARY_AVPAY_HOLIDAYS";
            this.grSalaryAvPayHolidays.Name = "grSalaryAvPayHolidays";
            this.grSalaryAvPayHolidays.ReadOnly = true;
            this.grSalaryAvPayHolidays.RowTitle = "Par darbu sv.d. ar vid.izp.";
            this.grSalaryAvPayHolidays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSalaryAvPayHolidaysOvertime
            // 
            this.grSalaryAvPayHolidaysOvertime.DataMember = "SALARY_AVPAY_HOLIDAYS_OVERTIME";
            this.grSalaryAvPayHolidaysOvertime.DataSource = this.bsSarR2;
            this.grSalaryAvPayHolidaysOvertime.EditorTemplateName = "grDecimalReadOnly";
            this.grSalaryAvPayHolidaysOvertime.GridPropertyName = "_SALARY_AVPAY_HOLIDAYS_OVERTIME";
            this.grSalaryAvPayHolidaysOvertime.Name = "grSalaryAvPayHolidaysOvertime";
            this.grSalaryAvPayHolidaysOvertime.ReadOnly = true;
            this.grSalaryAvPayHolidaysOvertime.RowTitle = "Par virsst. sv.d. ar vid.izp.";
            this.grSalaryAvPayHolidaysOvertime.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grVacationDaysCurrent
            // 
            this.grVacationDaysCurrent.DataMember = "VACATION_DAYS_CURRENT";
            this.grVacationDaysCurrent.DataSource = this.bsSarR2;
            this.grVacationDaysCurrent.EditorTemplateName = "grSingle";
            this.grVacationDaysCurrent.GridPropertyName = "_VACATION_DAYS_CURRENT";
            this.grVacationDaysCurrent.Name = "grVacationDaysCurrent";
            this.grVacationDaysCurrent.ReadOnly = true;
            this.grVacationDaysCurrent.RowTitle = "Dienas";
            this.grVacationDaysCurrent.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grVacationDaysNext
            // 
            this.grVacationDaysNext.DataMember = "VACATION_DAYS_NEXT";
            this.grVacationDaysNext.DataSource = this.bsSarR2;
            this.grVacationDaysNext.EditorTemplateName = "grSingle";
            this.grVacationDaysNext.GridPropertyName = "_VACATION_DAYS_NEXT";
            this.grVacationDaysNext.Name = "grVacationDaysNext";
            this.grVacationDaysNext.ReadOnly = true;
            this.grVacationDaysNext.RowTitle = "Dienas";
            this.grVacationDaysNext.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grVacationPayCurrent
            // 
            this.grVacationPayCurrent.DataMember = "VACATION_PAY_CURRENT";
            this.grVacationPayCurrent.DataSource = this.bsSarR2;
            this.grVacationPayCurrent.EditorTemplateName = "grDecimalReadOnly";
            this.grVacationPayCurrent.GridPropertyName = "_VACATION_PAY_CURRENT";
            this.grVacationPayCurrent.Name = "grVacationPayCurrent";
            this.grVacationPayCurrent.ReadOnly = true;
            this.grVacationPayCurrent.RowTitle = "Summa";
            this.grVacationPayCurrent.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grVacationPayNext
            // 
            this.grVacationPayNext.DataMember = "VACATION_PAY_NEXT";
            this.grVacationPayNext.DataSource = this.bsSarR2;
            this.grVacationPayNext.EditorTemplateName = "grDecimalReadOnly";
            this.grVacationPayNext.GridPropertyName = "_VACATION_PAY_NEXT";
            this.grVacationPayNext.Name = "grVacationPayNext";
            this.grVacationPayNext.ReadOnly = true;
            this.grVacationPayNext.RowTitle = "Summa";
            this.grVacationPayNext.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grVacationPayPrev
            // 
            this.grVacationPayPrev.DataMember = "VACATION_PAY_PREV";
            this.grVacationPayPrev.DataSource = this.bsSarR2;
            this.grVacationPayPrev.EditorTemplateName = "grDecimalReadOnly";
            this.grVacationPayPrev.GridPropertyName = "_VACATION_PAY_PREV";
            this.grVacationPayPrev.Name = "grVacationPayPrev";
            this.grVacationPayPrev.ReadOnly = true;
            this.grVacationPayPrev.RowTitle = "Summa";
            this.grVacationPayPrev.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grVacationDNSNext
            // 
            this.grVacationDNSNext.DataMember = "VACATION_DNS_NEXT";
            this.grVacationDNSNext.DataSource = this.bsSarR2;
            this.grVacationDNSNext.EditorTemplateName = "grDecimalReadOnly";
            this.grVacationDNSNext.GridPropertyName = "_VACATION_DNS_NEXT";
            this.grVacationDNSNext.Name = "grVacationDNSNext";
            this.grVacationDNSNext.ReadOnly = true;
            this.grVacationDNSNext.RowTitle = "DŅ SI";
            this.grVacationDNSNext.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grVacationDDSNext
            // 
            this.grVacationDDSNext.DataMember = "VACATION_DDS_NEXT";
            this.grVacationDDSNext.DataSource = this.bsSarR2;
            this.grVacationDDSNext.EditorTemplateName = "grDecimalReadOnly";
            this.grVacationDDSNext.GridPropertyName = "_VACATION_DDS_NEXT";
            this.grVacationDDSNext.Name = "grVacationDDSNext";
            this.grVacationDDSNext.ReadOnly = true;
            this.grVacationDDSNext.RowTitle = "DD SI";
            this.grVacationDDSNext.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grVacationIINNext
            // 
            this.grVacationIINNext.DataMember = "VACATION_IIN_NEXT";
            this.grVacationIINNext.DataSource = this.bsSarR2;
            this.grVacationIINNext.EditorTemplateName = "grDecimalReadOnly";
            this.grVacationIINNext.GridPropertyName = "_VACATION_IIN_NEXT";
            this.grVacationIINNext.Name = "grVacationIINNext";
            this.grVacationIINNext.ReadOnly = true;
            this.grVacationIINNext.RowTitle = "IIN";
            this.grVacationIINNext.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grVacationDNSPrev
            // 
            this.grVacationDNSPrev.DataMember = "VACATION_DNS_PREV";
            this.grVacationDNSPrev.DataSource = this.bsSarR2;
            this.grVacationDNSPrev.EditorTemplateName = "grDecimalReadOnly";
            this.grVacationDNSPrev.GridPropertyName = "_VACATION_DNS_PREV";
            this.grVacationDNSPrev.Name = "grVacationDNSPrev";
            this.grVacationDNSPrev.ReadOnly = true;
            this.grVacationDNSPrev.RowTitle = "DŅ SI";
            this.grVacationDNSPrev.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grVacationDDSPrev
            // 
            this.grVacationDDSPrev.DataMember = "VACATION_DDS_PREV";
            this.grVacationDDSPrev.DataSource = this.bsSarR2;
            this.grVacationDDSPrev.EditorTemplateName = "grDecimalReadOnly";
            this.grVacationDDSPrev.GridPropertyName = "_VACATION_DDS_PREV";
            this.grVacationDDSPrev.Name = "grVacationDDSPrev";
            this.grVacationDDSPrev.ReadOnly = true;
            this.grVacationDDSPrev.RowTitle = "DD SI";
            this.grVacationDDSPrev.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grVacationIINPrev
            // 
            this.grVacationIINPrev.DataMember = "VACATION_IIN_PREV";
            this.grVacationIINPrev.DataSource = this.bsSarR2;
            this.grVacationIINPrev.EditorTemplateName = "grDecimalReadOnly";
            this.grVacationIINPrev.GridPropertyName = "_VACATION_IIN_PREV";
            this.grVacationIINPrev.Name = "grVacationIINPrev";
            this.grVacationIINPrev.ReadOnly = true;
            this.grVacationIINPrev.RowTitle = "IIN";
            this.grVacationIINPrev.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSickDays
            // 
            this.grSickDays.DataMember = "SICKDAYS";
            this.grSickDays.DataSource = this.bsSarR2;
            this.grSickDays.EditorTemplateName = "grtInt";
            this.grSickDays.GridPropertyName = "_SICKDAYS";
            this.grSickDays.Name = "grSickDays";
            this.grSickDays.ReadOnly = true;
            this.grSickDays.RowTitle = "Slimības dienas";
            this.grSickDays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grSickDaysPay
            // 
            this.grSickDaysPay.DataMember = "SICKDAYS_PAY";
            this.grSickDaysPay.DataSource = this.bsSarR2;
            this.grSickDaysPay.EditorTemplateName = "grDecimalReadOnly";
            this.grSickDaysPay.GridPropertyName = "_SICKDAYS_PAY";
            this.grSickDaysPay.Name = "grSickDaysPay";
            this.grSickDaysPay.ReadOnly = true;
            this.grSickDaysPay.RowTitle = "Apr. slimības nauda";
            this.grSickDaysPay.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grAccidentDays
            // 
            this.grAccidentDays.DataMember = "ACCIDENT_DAYS";
            this.grAccidentDays.DataSource = this.bsSarR2;
            this.grAccidentDays.EditorTemplateName = "grtInt";
            this.grAccidentDays.GridPropertyName = "_ACCIDENT_DAYS";
            this.grAccidentDays.Name = "grAccidentDays";
            this.grAccidentDays.ReadOnly = true;
            this.grAccidentDays.RowTitle = "Negadijuma dienas";
            this.grAccidentDays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grAccidentPay
            // 
            this.grAccidentPay.DataMember = "ACCIDENT_PAY";
            this.grAccidentPay.DataSource = this.bsSarR2;
            this.grAccidentPay.EditorTemplateName = "grDecimalReadOnly";
            this.grAccidentPay.GridPropertyName = "_ACCIDENT_PAY";
            this.grAccidentPay.Name = "grAccidentPay";
            this.grAccidentPay.ReadOnly = true;
            this.grAccidentPay.RowTitle = "Apr. par negadijumu";
            this.grAccidentPay.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grAmountBeforeSN
            // 
            this.grAmountBeforeSN.DataMember = "AMOUNT_BEFORE_SN";
            this.grAmountBeforeSN.DataSource = this.bsSarR2;
            this.grAmountBeforeSN.EditorTemplateName = "grDecimalReadOnly";
            this.grAmountBeforeSN.GridPropertyName = "_AMOUNT_BEFORE_SN";
            this.grAmountBeforeSN.Name = "grAmountBeforeSN";
            this.grAmountBeforeSN.ReadOnly = true;
            this.grAmountBeforeSN.RowTitle = "Apliekamā summa";
            this.grAmountBeforeSN.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grRateDNSN
            // 
            this.grRateDNSN.DataMember = "RATE_DNSN";
            this.grRateDNSN.DataSource = this.bsSarR2;
            this.grRateDNSN.EditorTemplateName = "grDecimalProc";
            this.grRateDNSN.FormatString = "0%";
            this.grRateDNSN.GridPropertyName = "_RATE_DNSN";
            this.grRateDNSN.Name = "grRateDNSN";
            this.grRateDNSN.ReadOnly = true;
            this.grRateDNSN.RowTitle = "DŅ likme";
            this.grRateDNSN.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grRateDDSN
            // 
            this.grRateDDSN.DataMember = "RATE_DDSN";
            this.grRateDDSN.DataSource = this.bsSarR2;
            this.grRateDDSN.EditorTemplateName = "grDecimalProc";
            this.grRateDDSN.GridPropertyName = "_RATE_DDSN";
            this.grRateDDSN.Name = "grRateDDSN";
            this.grRateDDSN.ReadOnly = true;
            this.grRateDDSN.RowTitle = "DD likme";
            this.grRateDDSN.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grDNSNAmount
            // 
            this.grDNSNAmount.DataMember = "DNSN_AMOUNT";
            this.grDNSNAmount.DataSource = this.bsSarR2;
            this.grDNSNAmount.EditorTemplateName = "grDecimalReadOnly";
            this.grDNSNAmount.GridPropertyName = "_DNSN_AMOUNT";
            this.grDNSNAmount.Name = "grDNSNAmount";
            this.grDNSNAmount.ReadOnly = true;
            this.grDNSNAmount.RowTitle = "DŅ SI";
            this.grDNSNAmount.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grDDSNAmount
            // 
            this.grDDSNAmount.DataMember = "DDSN_AMOUNT";
            this.grDDSNAmount.DataSource = this.bsSarR2;
            this.grDDSNAmount.EditorTemplateName = "grDecimalReadOnly";
            this.grDDSNAmount.GridPropertyName = "_DDSN_AMOUNT";
            this.grDDSNAmount.Name = "grDDSNAmount";
            this.grDDSNAmount.ReadOnly = true;
            this.grDDSNAmount.RowTitle = "DD SI";
            this.grDDSNAmount.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grIINExemprUntaxedMinimum
            // 
            this.grIINExemprUntaxedMinimum.DataMember = "IIN_EXEMPT_UNTAXED_MINIMUM";
            this.grIINExemprUntaxedMinimum.DataSource = this.bsSarR2;
            this.grIINExemprUntaxedMinimum.EditorTemplateName = "grDecimalReadOnly";
            this.grIINExemprUntaxedMinimum.GridPropertyName = "_IIN_EXEMPT_UNTAXED_MINIMUM";
            this.grIINExemprUntaxedMinimum.Name = "grIINExemprUntaxedMinimum";
            this.grIINExemprUntaxedMinimum.ReadOnly = true;
            this.grIINExemprUntaxedMinimum.RowTitle = "Neapliekamais minimums";
            this.grIINExemprUntaxedMinimum.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grIINExemptDependants
            // 
            this.grIINExemptDependants.DataMember = "IIN_EXEMPT_DEPENDANTS";
            this.grIINExemptDependants.DataSource = this.bsSarR2;
            this.grIINExemptDependants.EditorTemplateName = "grDecimalReadOnly";
            this.grIINExemptDependants.GridPropertyName = "_IIN_EXEMPT_DEPENDANTS";
            this.grIINExemptDependants.Name = "grIINExemptDependants";
            this.grIINExemptDependants.ReadOnly = true;
            this.grIINExemptDependants.RowTitle = "Par apgādājamajiem";
            this.grIINExemptDependants.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grIINExemptInvalidity
            // 
            this.grIINExemptInvalidity.DataMember = "IIN_EXEMPT_INVALIDITY";
            this.grIINExemptInvalidity.DataSource = this.bsSarR2;
            this.grIINExemptInvalidity.EditorTemplateName = "grDecimalReadOnly";
            this.grIINExemptInvalidity.GridPropertyName = "_IIN_EXEMPT_INVALIDITY";
            this.grIINExemptInvalidity.Name = "grIINExemptInvalidity";
            this.grIINExemptInvalidity.ReadOnly = true;
            this.grIINExemptInvalidity.RowTitle = "Par invaliditāti";
            this.grIINExemptInvalidity.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grIINExemptRetaliation
            // 
            this.grIINExemptRetaliation.DataMember = "IIN_EXEMPT_RETALIATION";
            this.grIINExemptRetaliation.DataSource = this.bsSarR2;
            this.grIINExemptRetaliation.EditorTemplateName = "grDecimalReadOnly";
            this.grIINExemptRetaliation.GridPropertyName = "_IIN_EXEMPT_RETALIATION";
            this.grIINExemptRetaliation.Name = "grIINExemptRetaliation";
            this.grIINExemptRetaliation.ReadOnly = true;
            this.grIINExemptRetaliation.RowTitle = "Rehabilitētajām personām";
            this.grIINExemptRetaliation.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // geIINExemptNatMov
            // 
            this.geIINExemptNatMov.DataMember = "IIN_EXEMPT_NATIONAL_MOVEMENT";
            this.geIINExemptNatMov.DataSource = this.bsSarR2;
            this.geIINExemptNatMov.EditorTemplateName = "grDecimalReadOnly";
            this.geIINExemptNatMov.GridPropertyName = "_IIN_EXEMPT_NATIONAL_MOVEMENT";
            this.geIINExemptNatMov.Name = "geIINExemptNatMov";
            this.geIINExemptNatMov.ReadOnly = true;
            this.geIINExemptNatMov.RowTitle = "Nac.pret.kust.dalībn.";
            this.geIINExemptNatMov.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grIINExemptExpenses
            // 
            this.grIINExemptExpenses.DataMember = "IIN_EXEMPT_EXPENSES";
            this.grIINExemptExpenses.DataSource = this.bsSarR2;
            this.grIINExemptExpenses.EditorTemplateName = "grDecimalReadOnly";
            this.grIINExemptExpenses.GridPropertyName = "_IIN_EXEMPT_EXPENSES";
            this.grIINExemptExpenses.Name = "grIINExemptExpenses";
            this.grIINExemptExpenses.ReadOnly = true;
            this.grIINExemptExpenses.RowTitle = "Izmaksas";
            this.grIINExemptExpenses.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grAmountBeforeIIN
            // 
            this.grAmountBeforeIIN.DataMember = "AMOUNT_BEFORE_IIN";
            this.grAmountBeforeIIN.DataSource = this.bsSarR2;
            this.grAmountBeforeIIN.EditorTemplateName = "grDecimalReadOnly";
            this.grAmountBeforeIIN.GridPropertyName = "_AMOUNT_BEFORE_IIN";
            this.grAmountBeforeIIN.Name = "grAmountBeforeIIN";
            this.grAmountBeforeIIN.ReadOnly = true;
            this.grAmountBeforeIIN.RowTitle = "Apliekamā summa";
            this.grAmountBeforeIIN.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grRateIIN
            // 
            this.grRateIIN.DataMember = "RATE_IIN";
            this.grRateIIN.DataSource = this.bsSarR2;
            this.grRateIIN.EditorTemplateName = "grDecimalProc";
            this.grRateIIN.GridPropertyName = "_RATE_IIN";
            this.grRateIIN.Name = "grRateIIN";
            this.grRateIIN.ReadOnly = true;
            this.grRateIIN.RowTitle = "IIN likme";
            this.grRateIIN.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grIINAmount
            // 
            this.grIINAmount.DataMember = "IIN_AMOUNT";
            this.grIINAmount.DataSource = this.bsSarR2;
            this.grIINAmount.EditorTemplateName = "grDecimalReadOnly";
            this.grIINAmount.GridPropertyName = "_IIN_AMOUNT";
            this.grIINAmount.Name = "grIINAmount";
            this.grIINAmount.ReadOnly = true;
            this.grIINAmount.RowTitle = "IIN summa";
            this.grIINAmount.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPayTitle
            // 
            this.grPayTitle.Name = "grPayTitle";
            this.grPayTitle.RowTitle = "Izmaksai";
            // 
            // grPay
            // 
            this.grPay.DataMember = "PAY";
            this.grPay.DataSource = this.bsSarR2;
            this.grPay.EditorTemplateName = "grDecimalReadOnly";
            this.grPay.GridPropertyName = "_PAY";
            this.grPay.Name = "grPay";
            this.grPay.ReadOnly = true;
            this.grPay.RowTitle = "Izmaksai";
            this.grPay.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grtInt
            // 
            this.grtInt.Name = "grtInt";
            this.grtInt.ReadOnly = true;
            this.grtInt.RowTitle = null;
            this.grtInt.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grtInt16
            // 
            this.grtInt16.Name = "grtInt16";
            this.grtInt16.ReadOnly = true;
            this.grtInt16.RowTitle = null;
            this.grtInt16.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.ShortInt;
            // 
            // grtDouble
            // 
            this.grtDouble.Name = "grtDouble";
            this.grtDouble.ReadOnly = true;
            this.grtDouble.RowTitle = null;
            this.grtDouble.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Double;
            // 
            // grDecimal
            // 
            this.grDecimal.Name = "grDecimal";
            this.grDecimal.RowTitle = null;
            this.grDecimal.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grString
            // 
            this.grString.Name = "grString";
            this.grString.ReadOnly = true;
            this.grString.RowTitle = null;
            this.grString.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.String;
            // 
            // grDecimalProc
            // 
            this.grDecimalProc.DataMember = null;
            this.grDecimalProc.FormatString = "0.00\\%";
            this.grDecimalProc.Name = "grDecimalProc";
            this.grDecimalProc.ReadOnly = true;
            this.grDecimalProc.RowTitle = null;
            this.grDecimalProc.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSingle
            // 
            this.grSingle.Name = "grSingle";
            this.grSingle.ReadOnly = true;
            this.grSingle.RowTitle = null;
            this.grSingle.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // bonusData1
            // 
            this.bonusData1._AMOUNT = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.bonusData1._DESCR = null;
            this.bonusData1._ID = 0;
            this.bonusData1._IDA = null;
            this.bonusData1._IDAP = null;
            this.bonusData1._IDIE = null;
            this.bonusData1._IDNO = null;
            this.bonusData1._IDP = 0;
            this.bonusData1._IDSV = 1;
            this.bonusData1._IDSX = 0;
            this.bonusData1._IS_INAVPAY = ((short)(0));
            this.bonusData1._IS_PAID = ((short)(0));
            this.bonusData1._RATE = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.bonusData1._RATE_TYPE = ((short)(0));
            // 
            // grbTitle
            // 
            this.grbTitle.Name = "grbTitle";
            this.grbTitle.RowTitle = "Piemaksas, atvilkuma dati";
            this.grbTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.Static;
            // 
            // grbIDA
            // 
            this.grbIDA.AllowNull = true;
            this.grbIDA.ColumnNames = new string[] {
        "ID",
        "TITLE"};
            this.grbIDA.ColumnWidths = "0;200";
            this.grbIDA.DataMember = "IDA";
            this.grbIDA.DataSource = this.bsAlgasPapildsummas;
            this.grbIDA.GridPropertyName = "_IDA";
            this.grbIDA.ListDisplayMember = "TITLE";
            this.grbIDA.ListSource = this.bsAmati;
            this.grbIDA.ListValueMember = "ID";
            this.grbIDA.Name = "grbIDA";
            this.grbIDA.ReadOnly = true;
            this.grbIDA.RowTitle = "Amats";
            this.grbIDA.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.IntegerN;
            // 
            // grbRate
            // 
            this.grbRate.DataMember = "RATE";
            this.grbRate.DataSource = this.bsAlgasPapildsummas;
            this.grbRate.GridPropertyName = "_RATE";
            this.grbRate.Name = "grbRate";
            this.grbRate.RowTitle = "Likme";
            this.grbRate.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grbAmount
            // 
            this.grbAmount.DataMember = "AMOUNT";
            this.grbAmount.DataSource = this.bsAlgasPapildsummas;
            this.grbAmount.GridPropertyName = "_AMOUNT";
            this.grbAmount.Name = "grbAmount";
            this.grbAmount.ReadOnly = true;
            this.grbAmount.RowTitle = "Summa";
            this.grbAmount.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grbRateType
            // 
            this.grbRateType.DataMember = "RATE_TYPE";
            this.grbRateType.DataSource = this.bsAlgasPapildsummas;
            this.grbRateType.GridPropertyName = "_RATE_TYPE";
            this.grbRateType.ListStrings = new string[] {
        "0;€",
        "1;%"};
            this.grbRateType.Name = "grbRateType";
            this.grbRateType.RowTitle = "Likmes veids";
            this.grbRateType.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.ShortInt;
            // 
            // grbIDNO
            // 
            this.grbIDNO.AllowNull = true;
            this.grbIDNO.ColumnNames = new string[] {
        "ID",
        "DESCR"};
            this.grbIDNO.ColumnWidths = "0;300";
            this.grbIDNO.DataMember = "IDNO";
            this.grbIDNO.DataSource = this.bsAlgasPapildsummas;
            this.grbIDNO.GridPropertyName = "_IDNO";
            this.grbIDNO.ListDisplayMember = "DESCR";
            this.grbIDNO.ListSource = this.bsPapildsummaNo;
            this.grbIDNO.ListValueMember = "ID";
            this.grbIDNO.Name = "grbIDNO";
            this.grbIDNO.RowTitle = "No";
            this.grbIDNO.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.IntegerN;
            // 
            // grbTitle2
            // 
            this.grbTitle2.Name = "grbTitle2";
            this.grbTitle2.RowTitle = "Apraksts";
            // 
            // grbDescr2
            // 
            this.grbDescr2.AllowNull = true;
            this.grbDescr2.DataMember = "DESCR";
            this.grbDescr2.DataSource = this.bsAlgasPapildsummas;
            this.grbDescr2.GridPropertyName = "_DESCR";
            this.grbDescr2.Name = "grbDescr2";
            this.grbDescr2.RowTitle = null;
            // 
            // cbAmati
            // 
            this.cbAmati._AllowSelection = true;
            this.cbAmati.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAmati.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAmati.ColumnNames = new string[] {
        "ID",
        "POSITION_TITLE"};
            this.cbAmati.ColumnWidths = "0;150";
            this.cbAmati.DataSource = this.bsSarR2;
            this.cbAmati.DisplayMember = "POSITION_TITLE";
            this.cbAmati.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAmati.DropDownHeight = 136;
            this.cbAmati.DropDownStyle = KlonsLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbAmati.DropDownWidth = 174;
            this.cbAmati.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAmati.FormattingEnabled = true;
            this.cbAmati.GridLineColor = System.Drawing.Color.LightGray;
            this.cbAmati.GridLineHorizontal = false;
            this.cbAmati.GridLineVertical = false;
            this.cbAmati.IntegralHeight = false;
            this.cbAmati.Location = new System.Drawing.Point(641, 464);
            this.cbAmati.Name = "cbAmati";
            this.cbAmati.Size = new System.Drawing.Size(237, 23);
            this.cbAmati.TabIndex = 13;
            this.cbAmati.ValueMember = "ID";
            this.cbAmati.Visible = false;
            // 
            // myAdapterManager1
            // 
            this.myAdapterManager1.MyDataSource = "KlonsData";
            this.myAdapterManager1.TableNames = new string[] {
        "SALARY_SHEETS",
        "SALARY_SHEETS_R",
        "SALARY_PLUSMINUS",
        "POSITIONS_PLUSMINUS",
        null};
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(658, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(340, 413);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.sgrAprekins);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(332, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // sgrAprekins
            // 
            this.sgrAprekins.BackColor2 = System.Drawing.SystemColors.Window;
            this.sgrAprekins.ColumnWidth1 = 15;
            this.sgrAprekins.ColumnWidth2 = 200;
            this.sgrAprekins.ColumnWidth3 = 100;
            this.sgrAprekins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgrAprekins.EnableSort = true;
            this.sgrAprekins.Location = new System.Drawing.Point(0, 0);
            this.sgrAprekins.MyDataBC = this.salaryData1;
            this.sgrAprekins.Name = "sgrAprekins";
            this.sgrAprekins.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.sgrAprekins.RowList.Add(this.grPersonTitle);
            this.sgrAprekins.RowList.Add(this.grFName);
            this.sgrAprekins.RowList.Add(this.grLName);
            this.sgrAprekins.RowList.Add(this.grPositionTitle);
            this.sgrAprekins.RowList.Add(this.grPlanTitle);
            this.sgrAprekins.RowList.Add(this.grPlanMonthTitle);
            this.sgrAprekins.RowList.Add(this.grCalendarDays);
            this.sgrAprekins.RowList.Add(this.grMonthWorkDays);
            this.sgrAprekins.RowList.Add(this.grMonthWorkhours);
            this.sgrAprekins.RowList.Add(this.grPlanTitleA);
            this.sgrAprekins.RowList.Add(this.grPlanDays);
            this.sgrAprekins.RowList.Add(this.grPlanHours);
            this.sgrAprekins.RowList.Add(this.grPlanHoursNight);
            this.sgrAprekins.RowList.Add(this.grPlanHoursOvertime);
            this.sgrAprekins.RowList.Add(this.grPlanWorkDaysTitle);
            this.sgrAprekins.RowList.Add(this.grPlanWeekDays);
            this.sgrAprekins.RowList.Add(this.grPlanWeekHours);
            this.sgrAprekins.RowList.Add(this.grPlanWeekHoirsNight);
            this.sgrAprekins.RowList.Add(this.grPlanWeekHoursOvertime);
            this.sgrAprekins.RowList.Add(this.grPlanHolidaysTitle);
            this.sgrAprekins.RowList.Add(this.grPlanHolidaysDays);
            this.sgrAprekins.RowList.Add(this.grPlanHolidaysHours);
            this.sgrAprekins.RowList.Add(this.grPlanHolidaysHoursNight);
            this.sgrAprekins.RowList.Add(this.grPlanHolidaysHoursOvertime);
            this.sgrAprekins.RowList.Add(this.grFactTitle);
            this.sgrAprekins.RowList.Add(this.grCalendarDaysUse);
            this.sgrAprekins.RowList.Add(this.grFactDays);
            this.sgrAprekins.RowList.Add(this.grFactHours);
            this.sgrAprekins.RowList.Add(this.grFactHoursNight);
            this.sgrAprekins.RowList.Add(this.grFactHoursOvertime);
            this.sgrAprekins.RowList.Add(this.grFactWorkDaysTitle);
            this.sgrAprekins.RowList.Add(this.grFactWeekDays);
            this.sgrAprekins.RowList.Add(this.grFactWeekHours);
            this.sgrAprekins.RowList.Add(this.grFactWeekHoursNight);
            this.sgrAprekins.RowList.Add(this.grFactWeekHoursOvertime);
            this.sgrAprekins.RowList.Add(this.grFactHolidaysTitle);
            this.sgrAprekins.RowList.Add(this.grFactHolidays);
            this.sgrAprekins.RowList.Add(this.grFactHolidaysHours);
            this.sgrAprekins.RowList.Add(this.grFactHolidaysHoursNight);
            this.sgrAprekins.RowList.Add(this.grFactHolidaysHoursOvertime);
            this.sgrAprekins.RowList.Add(this.grAvPayTimeTitle);
            this.sgrAprekins.RowList.Add(this.grFactAvPayFreeDays);
            this.sgrAprekins.RowList.Add(this.grFactAvPayFreeHours);
            this.sgrAprekins.RowList.Add(this.grFactAvPayWorkDays);
            this.sgrAprekins.RowList.Add(this.grFactAvPayHours);
            this.sgrAprekins.RowList.Add(this.grFactAvPayHoursOvertime);
            this.sgrAprekins.RowList.Add(this.grFactAvPayWorkInHolidays);
            this.sgrAprekins.RowList.Add(this.grFactAvPayHolidaysHours);
            this.sgrAprekins.RowList.Add(this.grFactAvPayHolidaysHoursOvertime);
            this.sgrAprekins.RowList.Add(this.grSalaryTitle);
            this.sgrAprekins.RowList.Add(this.grSalary);
            this.sgrAprekins.RowList.Add(this.grSalaryDay);
            this.sgrAprekins.RowList.Add(this.grSalaryTitle2);
            this.sgrAprekins.RowList.Add(this.grSalaryNight);
            this.sgrAprekins.RowList.Add(this.grSalaryOvertime);
            this.sgrAprekins.RowList.Add(this.grSalaryHolidaysDay);
            this.sgrAprekins.RowList.Add(this.grSalaryHolidaysNight);
            this.sgrAprekins.RowList.Add(this.grSalaryHolidaysOvertime);
            this.sgrAprekins.RowList.Add(this.grSalaryPieceWork);
            this.sgrAprekins.RowList.Add(this.grSalaryAvPayTitle);
            this.sgrAprekins.RowList.Add(this.grSalaryAvPayFreeDays);
            this.sgrAprekins.RowList.Add(this.grSalaryAvPayWorkDays);
            this.sgrAprekins.RowList.Add(this.grSalaryAvPayWorkDaysOvertime);
            this.sgrAprekins.RowList.Add(this.grSalaryAvPayHolidays);
            this.sgrAprekins.RowList.Add(this.grSalaryAvPayHolidaysOvertime);
            this.sgrAprekins.RowList.Add(this.grVacationTitle);
            this.sgrAprekins.RowList.Add(this.grVacationDaysCurrent);
            this.sgrAprekins.RowList.Add(this.grVacationHoursCurrent);
            this.sgrAprekins.RowList.Add(this.grVacationPayCurrent);
            this.sgrAprekins.RowList.Add(this.grVacationTitleNext);
            this.sgrAprekins.RowList.Add(this.grVacationDaysNext);
            this.sgrAprekins.RowList.Add(this.grVacationHoursNext);
            this.sgrAprekins.RowList.Add(this.grVacationPayNext);
            this.sgrAprekins.RowList.Add(this.grVacationDNSNext);
            this.sgrAprekins.RowList.Add(this.grVacationDDSNext);
            this.sgrAprekins.RowList.Add(this.grVacationIINNext);
            this.sgrAprekins.RowList.Add(this.grVacationTitlePrev);
            this.sgrAprekins.RowList.Add(this.grVacationPayPrev);
            this.sgrAprekins.RowList.Add(this.grVacationDNSPrev);
            this.sgrAprekins.RowList.Add(this.grVacationDDSPrev);
            this.sgrAprekins.RowList.Add(this.grVacationIINPrev);
            this.sgrAprekins.RowList.Add(this.grVacationTitleAdvance);
            this.sgrAprekins.RowList.Add(this.grVacationCashNext);
            this.sgrAprekins.RowList.Add(this.grVacationAdvancePrev);
            this.sgrAprekins.RowList.Add(this.grVacationAdvanceCurrent);
            this.sgrAprekins.RowList.Add(this.grVacationAdvanceNext);
            this.sgrAprekins.RowList.Add(this.grSickDaysTitle);
            this.sgrAprekins.RowList.Add(this.grSickDays);
            this.sgrAprekins.RowList.Add(this.grSickDaysPay);
            this.sgrAprekins.RowList.Add(this.grAccidentDays);
            this.sgrAprekins.RowList.Add(this.grAccidentPay);
            this.sgrAprekins.RowList.Add(this.grVSAOITitle);
            this.sgrAprekins.RowList.Add(this.grAmountBeforeSN);
            this.sgrAprekins.RowList.Add(this.grRateDNSN);
            this.sgrAprekins.RowList.Add(this.grRateDDSN);
            this.sgrAprekins.RowList.Add(this.grDNSNAmount);
            this.sgrAprekins.RowList.Add(this.grDDSNAmount);
            this.sgrAprekins.RowList.Add(this.grIINExemptsTitle);
            this.sgrAprekins.RowList.Add(this.grIINExemprUntaxedMinimum0);
            this.sgrAprekins.RowList.Add(this.grIINExemprUntaxedMinimum);
            this.sgrAprekins.RowList.Add(this.grIINExemptDependants);
            this.sgrAprekins.RowList.Add(this.grIINExemptInvalidity);
            this.sgrAprekins.RowList.Add(this.grIINExemptRetaliation);
            this.sgrAprekins.RowList.Add(this.geIINExemptNatMov);
            this.sgrAprekins.RowList.Add(this.grIINExemptExpenses);
            this.sgrAprekins.RowList.Add(this.grPlusMinusTitle);
            this.sgrAprekins.RowList.Add(this.grPlusTaxed);
            this.sgrAprekins.RowList.Add(this.grPlusNotTaxed);
            this.sgrAprekins.RowList.Add(this.grPlusNoSAI);
            this.sgrAprekins.RowList.Add(this.grPlusAuthorsFees);
            this.sgrAprekins.RowList.Add(this.grPlusPFNotTaxed);
            this.sgrAprekins.RowList.Add(this.grPlusPFTaxed);
            this.sgrAprekins.RowList.Add(this.grPlusLINotTaxed);
            this.sgrAprekins.RowList.Add(this.grPlusLITaxed);
            this.sgrAprekins.RowList.Add(this.grPlusHINotTaxed);
            this.sgrAprekins.RowList.Add(this.grPlusHITaxed);
            this.sgrAprekins.RowList.Add(this.grPlusNPNotTaxed);
            this.sgrAprekins.RowList.Add(this.grMinusBeforeIIN);
            this.sgrAprekins.RowList.Add(this.grIINTitle);
            this.sgrAprekins.RowList.Add(this.grAmountBeforeIIN);
            this.sgrAprekins.RowList.Add(this.grRateIIN);
            this.sgrAprekins.RowList.Add(this.grRateIIN2);
            this.sgrAprekins.RowList.Add(this.grIINAmount);
            this.sgrAprekins.RowList.Add(this.grReverseTitle);
            this.sgrAprekins.RowList.Add(this.grAmountBeforeSNReverse);
            this.sgrAprekins.RowList.Add(this.grDNSNAmountReverse);
            this.sgrAprekins.RowList.Add(this.grDDSNReverse);
            this.sgrAprekins.RowList.Add(this.grIINAmountReverse);
            this.sgrAprekins.RowList.Add(this.grPayTitle);
            this.sgrAprekins.RowList.Add(this.grPay);
            this.sgrAprekins.RowList.Add(this.grPayAdv);
            this.sgrAprekins.RowList.Add(this.grMinusAfterIIN);
            this.sgrAprekins.RowList.Add(this.grPayT);
            this.sgrAprekins.RowList.Add(this.grPayEmpty);
            this.sgrAprekins.RowTemplateList.Add(this.grtInt);
            this.sgrAprekins.RowTemplateList.Add(this.grtInt16);
            this.sgrAprekins.RowTemplateList.Add(this.grtDouble);
            this.sgrAprekins.RowTemplateList.Add(this.grDecimal);
            this.sgrAprekins.RowTemplateList.Add(this.grDecimalReadOnly);
            this.sgrAprekins.RowTemplateList.Add(this.grString);
            this.sgrAprekins.RowTemplateList.Add(this.grDecimalProc);
            this.sgrAprekins.RowTemplateList.Add(this.grSingle);
            this.sgrAprekins.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.sgrAprekins.Size = new System.Drawing.Size(332, 384);
            this.sgrAprekins.TabIndex = 1;
            this.sgrAprekins.TabStop = true;
            this.sgrAprekins.ToolTipText = "";
            this.sgrAprekins.ValueChanged += new System.EventHandler(this.sgrAprekins_ValueChanged);
            // 
            // grPlanTitle
            // 
            this.grPlanTitle.Name = "grPlanTitle";
            this.grPlanTitle.RowTitle = "Darba laika plāns";
            this.grPlanTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.CollapsableWithValue;
            // 
            // grPlanMonthTitle
            // 
            this.grPlanMonthTitle.Name = "grPlanMonthTitle";
            this.grPlanMonthTitle.RowTitle = "Mēneša plāns";
            this.grPlanMonthTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.SubTitle;
            // 
            // grCalendarDays
            // 
            this.grCalendarDays.DataMember = "CALENDAR_DAYS";
            this.grCalendarDays.DataSource = this.bsSarR2;
            this.grCalendarDays.EditorTemplateName = "grtInt";
            this.grCalendarDays.GridPropertyName = "_CALENDAR_DAYS";
            this.grCalendarDays.Name = "grCalendarDays";
            this.grCalendarDays.ReadOnly = true;
            this.grCalendarDays.RowTitle = "Kalendāra dienas";
            this.grCalendarDays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grMonthWorkDays
            // 
            this.grMonthWorkDays.DataMember = "MONTH_WORKDAYS";
            this.grMonthWorkDays.DataSource = this.bsSarR2;
            this.grMonthWorkDays.EditorTemplateName = "grtInt";
            this.grMonthWorkDays.GridPropertyName = "_MONTH_WORKDAYS";
            this.grMonthWorkDays.Name = "grMonthWorkDays";
            this.grMonthWorkDays.ReadOnly = true;
            this.grMonthWorkDays.RowTitle = "Dienas";
            this.grMonthWorkDays.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grMonthWorkhours
            // 
            this.grMonthWorkhours.DataMember = "MONTH_WORKHOURS";
            this.grMonthWorkhours.DataSource = this.bsSarR2;
            this.grMonthWorkhours.EditorTemplateName = "grSingle";
            this.grMonthWorkhours.GridPropertyName = "_MONTH_WORKHOURS";
            this.grMonthWorkhours.Name = "grMonthWorkhours";
            this.grMonthWorkhours.ReadOnly = true;
            this.grMonthWorkhours.RowTitle = "Stundas";
            this.grMonthWorkhours.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grPlanTitleA
            // 
            this.grPlanTitleA.Name = "grPlanTitleA";
            this.grPlanTitleA.RowTitle = "Plāns";
            this.grPlanTitleA.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.SubTitle;
            // 
            // grPlanWorkDaysTitle
            // 
            this.grPlanWorkDaysTitle.Name = "grPlanWorkDaysTitle";
            this.grPlanWorkDaysTitle.RowTitle = "- t.sk. darba dienās";
            this.grPlanWorkDaysTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.SubTitle;
            // 
            // grPlanHolidaysTitle
            // 
            this.grPlanHolidaysTitle.Name = "grPlanHolidaysTitle";
            this.grPlanHolidaysTitle.RowTitle = "- t.sk. darbs svētku dienās";
            this.grPlanHolidaysTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.SubTitle;
            // 
            // grFactTitle
            // 
            this.grFactTitle.Name = "grFactTitle";
            this.grFactTitle.RowTitle = "Faktiski nostrādāts";
            this.grFactTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.CollapsableWithValue;
            // 
            // grCalendarDaysUse
            // 
            this.grCalendarDaysUse.DataMember = "CALENDAR_DAYS_USE";
            this.grCalendarDaysUse.DataSource = this.bsSarR2;
            this.grCalendarDaysUse.EditorTemplateName = "grtInt";
            this.grCalendarDaysUse.GridPropertyName = "_CALENDAR_DAYS_USE";
            this.grCalendarDaysUse.Name = "grCalendarDaysUse";
            this.grCalendarDaysUse.RowTitle = "Kalendāra dienas";
            this.grCalendarDaysUse.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grFactWorkDaysTitle
            // 
            this.grFactWorkDaysTitle.Name = "grFactWorkDaysTitle";
            this.grFactWorkDaysTitle.RowTitle = "- t.sk. darba dienās";
            this.grFactWorkDaysTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.SubTitle;
            // 
            // grFactHolidaysTitle
            // 
            this.grFactHolidaysTitle.Name = "grFactHolidaysTitle";
            this.grFactHolidaysTitle.RowTitle = "- t.sk. darbs svētku dienās";
            this.grFactHolidaysTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.SubTitle;
            // 
            // grAvPayTimeTitle
            // 
            this.grAvPayTimeTitle.Name = "grAvPayTimeTitle";
            this.grAvPayTimeTitle.RowTitle = "Vidējās izpeļņas dienas";
            this.grAvPayTimeTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.CollapsableWithValue;
            // 
            // grSalaryTitle
            // 
            this.grSalaryTitle.Name = "grSalaryTitle";
            this.grSalaryTitle.RowTitle = "Aprēķinātā darba samaksa";
            this.grSalaryTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.CollapsableWithValue;
            // 
            // grSalaryTitle2
            // 
            this.grSalaryTitle2.Name = "grSalaryTitle2";
            this.grSalaryTitle2.RowTitle = "piemaksas";
            this.grSalaryTitle2.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.SubTitle;
            // 
            // grSalaryPieceWork
            // 
            this.grSalaryPieceWork.DataMember = "SALARY_PIECEWORK";
            this.grSalaryPieceWork.DataSource = this.bsSarR2;
            this.grSalaryPieceWork.EditorTemplateName = "grDecimalReadOnly";
            this.grSalaryPieceWork.GridPropertyName = "_SALARY_PIECEWORK";
            this.grSalaryPieceWork.Name = "grSalaryPieceWork";
            this.grSalaryPieceWork.ReadOnly = true;
            this.grSalaryPieceWork.RowTitle = "Gabaldarbs";
            this.grSalaryPieceWork.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSalaryAvPayTitle
            // 
            this.grSalaryAvPayTitle.Name = "grSalaryAvPayTitle";
            this.grSalaryAvPayTitle.RowTitle = "Samaksa par VI dienām";
            this.grSalaryAvPayTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.CollapsableWithValue;
            // 
            // grVacationTitle
            // 
            this.grVacationTitle.Name = "grVacationTitle";
            this.grVacationTitle.RowTitle = "Atvaļinājums";
            this.grVacationTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.CollapsableWithValue;
            // 
            // grVacationHoursCurrent
            // 
            this.grVacationHoursCurrent.DataMember = "VACATION_HOURS_CURRENT";
            this.grVacationHoursCurrent.DataSource = this.bsSarR2;
            this.grVacationHoursCurrent.EditorTemplateName = "grSingle";
            this.grVacationHoursCurrent.GridPropertyName = "_VACATION_HOURS_CURRENT";
            this.grVacationHoursCurrent.Name = "grVacationHoursCurrent";
            this.grVacationHoursCurrent.ReadOnly = true;
            this.grVacationHoursCurrent.RowTitle = "Stundas";
            this.grVacationHoursCurrent.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grVacationTitleNext
            // 
            this.grVacationTitleNext.Name = "grVacationTitleNext";
            this.grVacationTitleNext.RowTitle = "Aprēķināts avansā";
            this.grVacationTitleNext.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.SubTitle;
            // 
            // grVacationHoursNext
            // 
            this.grVacationHoursNext.DataMember = "VACATION_HOURS_NEXT";
            this.grVacationHoursNext.DataSource = this.bsSarR2;
            this.grVacationHoursNext.EditorTemplateName = "grSingle";
            this.grVacationHoursNext.GridPropertyName = "_VACATION_HOURS_NEXT";
            this.grVacationHoursNext.Name = "grVacationHoursNext";
            this.grVacationHoursNext.ReadOnly = true;
            this.grVacationHoursNext.RowTitle = "Stundas";
            this.grVacationHoursNext.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Single;
            // 
            // grVacationTitlePrev
            // 
            this.grVacationTitlePrev.Name = "grVacationTitlePrev";
            this.grVacationTitlePrev.RowTitle = "Izmaksāts iepriekš";
            this.grVacationTitlePrev.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.SubTitle;
            // 
            // grVacationTitleAdvance
            // 
            this.grVacationTitleAdvance.Name = "grVacationTitleAdvance";
            this.grVacationTitleAdvance.RowTitle = "Avansa izmaiņas";
            this.grVacationTitleAdvance.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.SubTitle;
            // 
            // grVacationCashNext
            // 
            this.grVacationCashNext.DataMember = "VACATION_CASH_NEXT";
            this.grVacationCashNext.DataSource = this.bsSarR2;
            this.grVacationCashNext.EditorTemplateName = "grDecimalReadOnly";
            this.grVacationCashNext.GridPropertyName = "_VACATION_CASH_NEXT";
            this.grVacationCashNext.Name = "grVacationCashNext";
            this.grVacationCashNext.ReadOnly = true;
            this.grVacationCashNext.RowTitle = "Avans par nāk. mēn.";
            this.grVacationCashNext.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grVacationAdvancePrev
            // 
            this.grVacationAdvancePrev.DataMember = "VACATION_ADVANCE_PREV";
            this.grVacationAdvancePrev.DataSource = this.bsSarR2;
            this.grVacationAdvancePrev.EditorTemplateName = "grDecimalReadOnly";
            this.grVacationAdvancePrev.GridPropertyName = "_VACATION_ADVANCE_PREV";
            this.grVacationAdvancePrev.Name = "grVacationAdvancePrev";
            this.grVacationAdvancePrev.ReadOnly = true;
            this.grVacationAdvancePrev.RowTitle = "Avansa sākuma atlikums";
            this.grVacationAdvancePrev.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grVacationAdvanceCurrent
            // 
            this.grVacationAdvanceCurrent.DataMember = "VACATION_ADVANCE_CURRENT";
            this.grVacationAdvanceCurrent.DataSource = this.bsSarR2;
            this.grVacationAdvanceCurrent.EditorTemplateName = "grDecimalReadOnly";
            this.grVacationAdvanceCurrent.GridPropertyName = "_VACATION_ADVANCE_CURRENT";
            this.grVacationAdvanceCurrent.Name = "grVacationAdvanceCurrent";
            this.grVacationAdvanceCurrent.ReadOnly = true;
            this.grVacationAdvanceCurrent.RowTitle = "Avansa izmaiņas";
            this.grVacationAdvanceCurrent.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grVacationAdvanceNext
            // 
            this.grVacationAdvanceNext.DataMember = "VACATION_ADVANCE_NEXT";
            this.grVacationAdvanceNext.DataSource = this.bsSarR2;
            this.grVacationAdvanceNext.EditorTemplateName = "grDecimalReadOnly";
            this.grVacationAdvanceNext.GridPropertyName = "_VACATION_ADVANCE_NEXT";
            this.grVacationAdvanceNext.Name = "grVacationAdvanceNext";
            this.grVacationAdvanceNext.ReadOnly = true;
            this.grVacationAdvanceNext.RowTitle = "Avansa beigu atlikums";
            this.grVacationAdvanceNext.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grSickDaysTitle
            // 
            this.grSickDaysTitle.Name = "grSickDaysTitle";
            this.grSickDaysTitle.RowTitle = "Slimības lapas";
            this.grSickDaysTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.CollapsableWithValue;
            // 
            // grVSAOITitle
            // 
            this.grVSAOITitle.Name = "grVSAOITitle";
            this.grVSAOITitle.RowTitle = "VSAOI";
            this.grVSAOITitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.CollapsableWithValue;
            // 
            // grIINExemptsTitle
            // 
            this.grIINExemptsTitle.Name = "grIINExemptsTitle";
            this.grIINExemptsTitle.RowTitle = "IIN atvieglojumi";
            this.grIINExemptsTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.CollapsableWithValue;
            // 
            // grIINExemprUntaxedMinimum0
            // 
            this.grIINExemprUntaxedMinimum0.DataMember = "IIN_EXEMPT_UNTAXED_MINIMUM0";
            this.grIINExemprUntaxedMinimum0.DataSource = this.bsSarR2;
            this.grIINExemprUntaxedMinimum0.EditorTemplateName = "grDecimalReadOnly";
            this.grIINExemprUntaxedMinimum0.GridPropertyName = "_IIN_EXEMPT_UNTAXED_MINIMUM0";
            this.grIINExemprUntaxedMinimum0.Name = "grIINExemprUntaxedMinimum0";
            this.grIINExemprUntaxedMinimum0.RowTitle = "Nepliekamais min. pilns";
            this.grIINExemprUntaxedMinimum0.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPlusMinusTitle
            // 
            this.grPlusMinusTitle.Name = "grPlusMinusTitle";
            this.grPlusMinusTitle.RowTitle = "Piemaksas / atvilkumi";
            this.grPlusMinusTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.CollapsableWithValue;
            // 
            // grPlusTaxed
            // 
            this.grPlusTaxed.DataMember = "PLUS_TAXED";
            this.grPlusTaxed.DataSource = this.bsSarR2;
            this.grPlusTaxed.EditorTemplateName = "grDecimalReadOnly";
            this.grPlusTaxed.GridPropertyName = "_PLUS_TAXED";
            this.grPlusTaxed.Name = "grPlusTaxed";
            this.grPlusTaxed.ReadOnly = true;
            this.grPlusTaxed.RowTitle = "Apliek ar nodokļiem";
            this.grPlusTaxed.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPlusNotTaxed
            // 
            this.grPlusNotTaxed.DataMember = "PLUS_NOTTAXED";
            this.grPlusNotTaxed.DataSource = this.bsSarR2;
            this.grPlusNotTaxed.EditorTemplateName = "grDecimalReadOnly";
            this.grPlusNotTaxed.GridPropertyName = "_PLUS_NOTTAXED";
            this.grPlusNotTaxed.Name = "grPlusNotTaxed";
            this.grPlusNotTaxed.ReadOnly = true;
            this.grPlusNotTaxed.RowTitle = "Neapliek ar nod.";
            this.grPlusNotTaxed.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPlusNoSAI
            // 
            this.grPlusNoSAI.DataMember = "PLUS_NOSAI";
            this.grPlusNoSAI.DataSource = this.bsSarR2;
            this.grPlusNoSAI.EditorTemplateName = "grDecimalReadOnly";
            this.grPlusNoSAI.GridPropertyName = "_PLUS_NOSAI";
            this.grPlusNoSAI.Name = "grPlusNoSAI";
            this.grPlusNoSAI.ReadOnly = true;
            this.grPlusNoSAI.RowTitle = "Neapliek ar SAI";
            this.grPlusNoSAI.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPlusAuthorsFees
            // 
            this.grPlusAuthorsFees.DataMember = "PLUS_AUTHORS_FEES";
            this.grPlusAuthorsFees.DataSource = this.bsSarR2;
            this.grPlusAuthorsFees.EditorTemplateName = "grDecimalReadOnly";
            this.grPlusAuthorsFees.GridPropertyName = "_PLUS_AUTHORS_FEES";
            this.grPlusAuthorsFees.Name = "grPlusAuthorsFees";
            this.grPlusAuthorsFees.ReadOnly = true;
            this.grPlusAuthorsFees.RowTitle = "Autoratlīdzība";
            this.grPlusAuthorsFees.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPlusPFNotTaxed
            // 
            this.grPlusPFNotTaxed.DataMember = "PLUS_PF_NOTTAXED";
            this.grPlusPFNotTaxed.DataSource = this.bsSarR2;
            this.grPlusPFNotTaxed.EditorTemplateName = "grDecimalReadOnly";
            this.grPlusPFNotTaxed.GridPropertyName = "_PLUS_PF_NOTTAXED";
            this.grPlusPFNotTaxed.Name = "grPlusPFNotTaxed";
            this.grPlusPFNotTaxed.ReadOnly = true;
            this.grPlusPFNotTaxed.RowTitle = "PF iemaksas neapl.d.";
            this.grPlusPFNotTaxed.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPlusPFTaxed
            // 
            this.grPlusPFTaxed.DataMember = "PLUS_PF_TAXED";
            this.grPlusPFTaxed.DataSource = this.bsSarR2;
            this.grPlusPFTaxed.EditorTemplateName = "grDecimalReadOnly";
            this.grPlusPFTaxed.GridPropertyName = "_PLUS_PF_TAXED";
            this.grPlusPFTaxed.Name = "grPlusPFTaxed";
            this.grPlusPFTaxed.ReadOnly = true;
            this.grPlusPFTaxed.RowTitle = "PF iemaksas apl.d.";
            this.grPlusPFTaxed.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPlusLINotTaxed
            // 
            this.grPlusLINotTaxed.DataMember = "PLUS_LI_NOTTAXED";
            this.grPlusLINotTaxed.DataSource = this.bsSarR2;
            this.grPlusLINotTaxed.EditorTemplateName = "grDecimalReadOnly";
            this.grPlusLINotTaxed.GridPropertyName = "_PLUS_LI_NOTTAXED";
            this.grPlusLINotTaxed.Name = "grPlusLINotTaxed";
            this.grPlusLINotTaxed.ReadOnly = true;
            this.grPlusLINotTaxed.RowTitle = "Dzīv.apdr. neapl.d.";
            this.grPlusLINotTaxed.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPlusLITaxed
            // 
            this.grPlusLITaxed.DataMember = "PLUS_LI_TAXED";
            this.grPlusLITaxed.DataSource = this.bsSarR2;
            this.grPlusLITaxed.EditorTemplateName = "grDecimalReadOnly";
            this.grPlusLITaxed.GridPropertyName = "_PLUS_LI_TAXED";
            this.grPlusLITaxed.Name = "grPlusLITaxed";
            this.grPlusLITaxed.ReadOnly = true;
            this.grPlusLITaxed.RowTitle = "Dzīv.apdr. apiek.d.";
            this.grPlusLITaxed.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPlusHINotTaxed
            // 
            this.grPlusHINotTaxed.DataMember = "PLUS_HI_NOTTAXED";
            this.grPlusHINotTaxed.DataSource = this.bsSarR2;
            this.grPlusHINotTaxed.EditorTemplateName = "grDecimalReadOnly";
            this.grPlusHINotTaxed.GridPropertyName = "_PLUS_HI_NOTTAXED";
            this.grPlusHINotTaxed.Name = "grPlusHINotTaxed";
            this.grPlusHINotTaxed.ReadOnly = true;
            this.grPlusHINotTaxed.RowTitle = "Vesel.apdr. neapl.d.";
            this.grPlusHINotTaxed.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPlusHITaxed
            // 
            this.grPlusHITaxed.DataMember = "PLUS_HI_TAXED";
            this.grPlusHITaxed.DataSource = this.bsSarR2;
            this.grPlusHITaxed.EditorTemplateName = "grDecimalReadOnly";
            this.grPlusHITaxed.GridPropertyName = "_PLUS_HI_TAXED";
            this.grPlusHITaxed.Name = "grPlusHITaxed";
            this.grPlusHITaxed.ReadOnly = true;
            this.grPlusHITaxed.RowTitle = "Vesel.apdr. apliek.d.";
            this.grPlusHITaxed.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPlusNPNotTaxed
            // 
            this.grPlusNPNotTaxed.DataMember = "PLUS_NP_NOTTAXED";
            this.grPlusNPNotTaxed.DataSource = this.bsSarR2;
            this.grPlusNPNotTaxed.EditorTemplateName = "grDecimalReadOnly";
            this.grPlusNPNotTaxed.GridPropertyName = "_PLUS_NP_NOTTAXED";
            this.grPlusNPNotTaxed.Name = "grPlusNPNotTaxed";
            this.grPlusNPNotTaxed.RowTitle = "Neizm. neapliek.";
            this.grPlusNPNotTaxed.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grMinusBeforeIIN
            // 
            this.grMinusBeforeIIN.DataMember = "MINUS_BEFORE_IIN";
            this.grMinusBeforeIIN.DataSource = this.bsSarR2;
            this.grMinusBeforeIIN.EditorTemplateName = "grDecimalReadOnly";
            this.grMinusBeforeIIN.GridPropertyName = "_MINUS_BEFORE_IIN";
            this.grMinusBeforeIIN.Name = "grMinusBeforeIIN";
            this.grMinusBeforeIIN.ReadOnly = true;
            this.grMinusBeforeIIN.RowTitle = "Atskaitīts pirm IIN apr.";
            this.grMinusBeforeIIN.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grIINTitle
            // 
            this.grIINTitle.Name = "grIINTitle";
            this.grIINTitle.RowTitle = "IIN";
            this.grIINTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.CollapsableWithValue;
            // 
            // grRateIIN2
            // 
            this.grRateIIN2.DataMember = "RATE_IIN2";
            this.grRateIIN2.DataSource = this.bsSarR2;
            this.grRateIIN2.EditorTemplateName = "grDecimalProc";
            this.grRateIIN2.GridPropertyName = "_RATE_IIN2";
            this.grRateIIN2.Name = "grRateIIN2";
            this.grRateIIN2.ReadOnly = true;
            this.grRateIIN2.RowTitle = "IIN likme 2";
            this.grRateIIN2.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grReverseTitle
            // 
            this.grReverseTitle.Name = "grReverseTitle";
            this.grReverseTitle.RowTitle = "Korekcijas";
            this.grReverseTitle.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.CollapsableWithValue;
            // 
            // grAmountBeforeSNReverse
            // 
            this.grAmountBeforeSNReverse.DataMember = "AMOUNT_BEFORE_SN_REVERSE";
            this.grAmountBeforeSNReverse.DataSource = this.bsSarR2;
            this.grAmountBeforeSNReverse.EditorTemplateName = "grDecimal";
            this.grAmountBeforeSNReverse.GridPropertyName = "_AMOUNT_BEFORE_IIN_REVERSE";
            this.grAmountBeforeSNReverse.Name = "grAmountBeforeSNReverse";
            this.grAmountBeforeSNReverse.RowTitle = "Ienākumu korekcija";
            this.grAmountBeforeSNReverse.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grDNSNAmountReverse
            // 
            this.grDNSNAmountReverse.DataMember = "DNSN_AMOUNT_REVERSE";
            this.grDNSNAmountReverse.DataSource = this.bsSarR2;
            this.grDNSNAmountReverse.EditorTemplateName = "grDecimal";
            this.grDNSNAmountReverse.GridPropertyName = "_DNSN_AMOUNT_REVERSE";
            this.grDNSNAmountReverse.Name = "grDNSNAmountReverse";
            this.grDNSNAmountReverse.RowTitle = "DŅ SI korekcija";
            this.grDNSNAmountReverse.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grDDSNReverse
            // 
            this.grDDSNReverse.DataMember = "DDSN_AMOUNT_REVERSE";
            this.grDDSNReverse.DataSource = this.bsSarR2;
            this.grDDSNReverse.EditorTemplateName = "grDecimal";
            this.grDDSNReverse.GridPropertyName = "_DDSN_AMOUNT_REVERSE";
            this.grDDSNReverse.Name = "grDDSNReverse";
            this.grDDSNReverse.RowTitle = "DD SI korekcija";
            this.grDDSNReverse.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grIINAmountReverse
            // 
            this.grIINAmountReverse.DataMember = "IIN_AMOUNT_REVERSE";
            this.grIINAmountReverse.DataSource = this.bsSarR2;
            this.grIINAmountReverse.EditorTemplateName = "grDecimal";
            this.grIINAmountReverse.GridPropertyName = "_IIN_AMOUNT_REVERSE";
            this.grIINAmountReverse.Name = "grIINAmountReverse";
            this.grIINAmountReverse.RowTitle = "IIN korekcija";
            this.grIINAmountReverse.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPayAdv
            // 
            this.grPayAdv.DataMember = "ADVANCE";
            this.grPayAdv.DataSource = this.bsSarR2;
            this.grPayAdv.EditorTemplateName = "grDecimalReadOnly";
            this.grPayAdv.GridPropertyName = "_ADVANCE";
            this.grPayAdv.Name = "grPayAdv";
            this.grPayAdv.RowTitle = "Avansā aprēķinātais";
            this.grPayAdv.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grMinusAfterIIN
            // 
            this.grMinusAfterIIN.DataMember = "MINUS_AFTER_IIN";
            this.grMinusAfterIIN.DataSource = this.bsSarR2;
            this.grMinusAfterIIN.EditorTemplateName = "grDecimalReadOnly";
            this.grMinusAfterIIN.GridPropertyName = "_MINUS_AFTER_IIN";
            this.grMinusAfterIIN.Name = "grMinusAfterIIN";
            this.grMinusAfterIIN.ReadOnly = true;
            this.grMinusAfterIIN.RowTitle = "Ieturējumi pēc nodokļiem";
            this.grMinusAfterIIN.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPayT
            // 
            this.grPayT.DataMember = "PAYT";
            this.grPayT.DataSource = this.bsSarR2;
            this.grPayT.EditorTemplateName = "grDecimalReadOnly";
            this.grPayT.GridPropertyName = "_PAYT";
            this.grPayT.Name = "grPayT";
            this.grPayT.RowTitle = "Kopā izmaksai";
            this.grPayT.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // grPayEmpty
            // 
            this.grPayEmpty.Name = "grPayEmpty";
            this.grPayEmpty.RowTitle = null;
            this.grPayEmpty.TitleRowType = KlonsLIB.MySourceGrid.GridRows.ETitleRowType.SubTitle;
            // 
            // grDecimalReadOnly
            // 
            this.grDecimalReadOnly.Name = "grDecimalReadOnly";
            this.grDecimalReadOnly.ReadOnly = true;
            this.grDecimalReadOnly.RowTitle = null;
            this.grDecimalReadOnly.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Decimal;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.sgrBonus);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(332, 351);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // sgrBonus
            // 
            this.sgrBonus.BackColor2 = System.Drawing.SystemColors.Window;
            this.sgrBonus.ColumnWidth1 = 15;
            this.sgrBonus.ColumnWidth2 = 100;
            this.sgrBonus.ColumnWidth3 = 200;
            this.sgrBonus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgrBonus.EnableSort = true;
            this.sgrBonus.Location = new System.Drawing.Point(0, 0);
            this.sgrBonus.MyDataBC = this.bonusData1;
            this.sgrBonus.Name = "sgrBonus";
            this.sgrBonus.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.sgrBonus.RowList.Add(this.grbTitle);
            this.sgrBonus.RowList.Add(this.grbIDA);
            this.sgrBonus.RowList.Add(this.grbRateType);
            this.sgrBonus.RowList.Add(this.grbRate);
            this.sgrBonus.RowList.Add(this.grbAmount);
            this.sgrBonus.RowList.Add(this.grbIDSV);
            this.sgrBonus.RowList.Add(this.grbIDNO);
            this.sgrBonus.RowList.Add(this.grbIsPaid);
            this.sgrBonus.RowList.Add(this.grbIsInAvpay);
            this.sgrBonus.RowList.Add(this.grbTitle2);
            this.sgrBonus.RowList.Add(this.grbDescr2);
            this.sgrBonus.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.sgrBonus.Size = new System.Drawing.Size(332, 351);
            this.sgrBonus.TabIndex = 0;
            this.sgrBonus.TabStop = true;
            this.sgrBonus.ToolTipText = "";
            this.sgrBonus.EditStarting += new System.ComponentModel.CancelEventHandler(this.sgrBonus_EditStarting);
            this.sgrBonus.EditEnded += new System.EventHandler(this.sgrBonus_EditEnded);
            // 
            // grbIDSV
            // 
            this.grbIDSV.ColumnNames = new string[] {
        "ID",
        "DESCR"};
            this.grbIDSV.ColumnWidths = "0;300";
            this.grbIDSV.DataMember = "IDSV";
            this.grbIDSV.DataSource = this.bsAlgasPapildsummas;
            this.grbIDSV.GridPropertyName = "_IDSV";
            this.grbIDSV.ListDisplayMember = "DESCR";
            this.grbIDSV.ListSource = this.bsPapildsummasVeids;
            this.grbIDSV.ListValueMember = "ID";
            this.grbIDSV.Name = "grbIDSV";
            this.grbIDSV.RowTitle = "Piemaksas / atvilkuma veids";
            this.grbIDSV.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.Integer;
            // 
            // grbIsPaid
            // 
            this.grbIsPaid.DataMember = "IS_PAID";
            this.grbIsPaid.DataSource = this.bsAlgasPapildsummas;
            this.grbIsPaid.FalseValue = "0";
            this.grbIsPaid.GridPropertyName = "_IS_PAID";
            this.grbIsPaid.Name = "grbIsPaid";
            this.grbIsPaid.RowTitle = "Izmaksājams";
            this.grbIsPaid.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.ShortInt;
            this.grbIsPaid.TrueValue = "1";
            // 
            // grbIsInAvpay
            // 
            this.grbIsInAvpay.DataMember = "IS_INAVPAY";
            this.grbIsInAvpay.DataSource = this.bsAlgasPapildsummas;
            this.grbIsInAvpay.FalseValue = "0";
            this.grbIsInAvpay.GridPropertyName = "_IS_INAVPAY";
            this.grbIsInAvpay.Name = "grbIsInAvpay";
            this.grbIsInAvpay.RowTitle = "Iekļaut VI";
            this.grbIsInAvpay.RowValueType = KlonsLIB.MySourceGrid.GridRows.EMyGridRowValueType.ShortInt;
            this.grbIsInAvpay.TrueValue = "1";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 32);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvLapa);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.splitContainer2.Panel1.Enter += new System.EventHandler(this.splitContainer2_Panel1_Enter);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvPapildsummas);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.splitContainer2.Panel2.Enter += new System.EventHandler(this.splitContainer2_Panel2_Enter);
            this.splitContainer2.Size = new System.Drawing.Size(658, 413);
            this.splitContainer2.SplitterDistance = 292;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 15;
            // 
            // dgvLapa
            // 
            this.dgvLapa.AllowUserToAddRows = false;
            this.dgvLapa.AllowUserToDeleteRows = false;
            this.dgvLapa.AutoGenerateColumns = false;
            this.dgvLapa.AutoSave = false;
            this.dgvLapa.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLapa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLapa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLapa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcSarSnr,
            this.dgcSarName,
            this.dgcSarPositionTitle,
            this.dgcSarFactDays,
            this.dgcSarsFactHours,
            this.DGCsARsALARY,
            this.dgcSarTotalBeforeTaxes,
            this.dgcSarDnSNAmount,
            this.dgcSarSNAmount,
            this.dgcSarIIN,
            this.dgcSarPay,
            this.dgcSarAdvance,
            this.dgcSarPayT,
            this.iDDataGridViewTextBoxColumn});
            this.dgvLapa.DataSource = this.bsSarR;
            this.dgvLapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLapa.Location = new System.Drawing.Point(0, 0);
            this.dgvLapa.Name = "dgvLapa";
            this.dgvLapa.RowTemplate.Height = 24;
            this.dgvLapa.Size = new System.Drawing.Size(653, 292);
            this.dgvLapa.TabIndex = 1;
            this.dgvLapa.MyCheckForChanges += new System.EventHandler(this.dgvLapa_MyCheckForChanges);
            this.dgvLapa.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLapa_CellFormatting);
            this.dgvLapa.Enter += new System.EventHandler(this.dgvLapa_Enter);
            // 
            // dgvPapildsummas
            // 
            this.dgvPapildsummas.AllowUserToAddRows = false;
            this.dgvPapildsummas.AllowUserToDeleteRows = false;
            this.dgvPapildsummas.AutoGenerateColumns = false;
            this.dgvPapildsummas.AutoSave = false;
            this.dgvPapildsummas.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPapildsummas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPapildsummas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPapildsummas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcPsDescr,
            this.dgcPsRate,
            this.dgcPsRateType,
            this.dgcPsAmount,
            this.dgcPsIDSV,
            this.dgcPsIDNO,
            this.dgcPsIE,
            this.dgcPsID,
            this.dgcPsIDP,
            this.dgcPsIDAP,
            this.dgcPsIDSX});
            this.dgvPapildsummas.DataSource = this.bsAlgasPapildsummas;
            this.dgvPapildsummas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPapildsummas.Location = new System.Drawing.Point(0, 0);
            this.dgvPapildsummas.Name = "dgvPapildsummas";
            this.dgvPapildsummas.RowTemplate.Height = 24;
            this.dgvPapildsummas.Size = new System.Drawing.Size(653, 115);
            this.dgvPapildsummas.TabIndex = 0;
            this.dgvPapildsummas.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPapildsummas_CellBeginEdit);
            this.dgvPapildsummas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPapildsummas_CellEndEdit);
            this.dgvPapildsummas.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvPapildsummas_DefaultValuesNeeded);
            this.dgvPapildsummas.Enter += new System.EventHandler(this.dgvPapildsummas_Enter);
            // 
            // dgcPsDescr
            // 
            this.dgcPsDescr.DataPropertyName = "DESCR";
            this.dgcPsDescr.HeaderText = "apraksts";
            this.dgcPsDescr.Name = "dgcPsDescr";
            this.dgcPsDescr.Width = 250;
            // 
            // dgcPsRate
            // 
            this.dgcPsRate.DataPropertyName = "RATE";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.dgcPsRate.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgcPsRate.HeaderText = "likme";
            this.dgcPsRate.Name = "dgcPsRate";
            this.dgcPsRate.Visible = false;
            this.dgcPsRate.Width = 80;
            // 
            // dgcPsRateType
            // 
            this.dgcPsRateType.DataPropertyName = "RATE_TYPE";
            this.dgcPsRateType.HeaderText = "%/€";
            this.dgcPsRateType.Name = "dgcPsRateType";
            this.dgcPsRateType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcPsRateType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcPsRateType.Visible = false;
            this.dgcPsRateType.Width = 60;
            // 
            // dgcPsAmount
            // 
            this.dgcPsAmount.DataPropertyName = "AMOUNT";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            this.dgcPsAmount.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgcPsAmount.HeaderText = "summa";
            this.dgcPsAmount.Name = "dgcPsAmount";
            this.dgcPsAmount.ReadOnly = true;
            this.dgcPsAmount.Width = 80;
            // 
            // dgcPsIDSV
            // 
            this.dgcPsIDSV.DataPropertyName = "IDSV";
            this.dgcPsIDSV.DataSource = this.bsPapildsummasVeids;
            this.dgcPsIDSV.DisplayMember = "DESCR";
            this.dgcPsIDSV.DisplayStyleForCurrentCellOnly = true;
            this.dgcPsIDSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcPsIDSV.HeaderText = "piem/atv. veids";
            this.dgcPsIDSV.Name = "dgcPsIDSV";
            this.dgcPsIDSV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcPsIDSV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcPsIDSV.ValueMember = "ID";
            this.dgcPsIDSV.Visible = false;
            this.dgcPsIDSV.Width = 150;
            // 
            // dgcPsIDNO
            // 
            this.dgcPsIDNO.DataPropertyName = "IDNO";
            this.dgcPsIDNO.DataSource = this.bsPapildsummaNo;
            this.dgcPsIDNO.DisplayMember = "DESCR";
            this.dgcPsIDNO.DisplayStyleForCurrentCellOnly = true;
            this.dgcPsIDNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgcPsIDNO.HeaderText = "aprēķina no";
            this.dgcPsIDNO.Name = "dgcPsIDNO";
            this.dgcPsIDNO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcPsIDNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcPsIDNO.ValueMember = "ID";
            this.dgcPsIDNO.Visible = false;
            this.dgcPsIDNO.Width = 150;
            // 
            // dgcPsIE
            // 
            this.dgcPsIE.DataPropertyName = "IDIE";
            this.dgcPsIE.HeaderText = "IDIE";
            this.dgcPsIE.Name = "dgcPsIE";
            this.dgcPsIE.Visible = false;
            // 
            // dgcPsID
            // 
            this.dgcPsID.DataPropertyName = "ID";
            this.dgcPsID.HeaderText = "ID";
            this.dgcPsID.Name = "dgcPsID";
            this.dgcPsID.Visible = false;
            // 
            // dgcPsIDP
            // 
            this.dgcPsIDP.DataPropertyName = "IDP";
            this.dgcPsIDP.HeaderText = "IDP";
            this.dgcPsIDP.Name = "dgcPsIDP";
            this.dgcPsIDP.Visible = false;
            // 
            // dgcPsIDAP
            // 
            this.dgcPsIDAP.DataPropertyName = "IDAP";
            this.dgcPsIDAP.HeaderText = "IDAP";
            this.dgcPsIDAP.Name = "dgcPsIDAP";
            this.dgcPsIDAP.Visible = false;
            // 
            // dgcPsIDSX
            // 
            this.dgcPsIDSX.DataPropertyName = "IDSX";
            this.dgcPsIDSX.HeaderText = "IDSX";
            this.dgcPsIDSX.Name = "dgcPsIDSX";
            this.dgcPsIDSX.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algasAprēķinaLapaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(998, 33);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // algasAprēķinaLapaToolStripMenuItem
            // 
            this.algasAprēķinaLapaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pārrēķinātDarbiniekamToolStripMenuItem1,
            this.pārrēķinātVisiemToolStripMenuItem,
            this.toolStripSeparator1,
            this.vidējāsIzpeļņasAprēķinsToolStripMenuItem,
            this.slimībasNaudasAprēķinsToolStripMenuItem,
            this.atvaļinājumaNaudasAprēķinsToolStripMenuItem,
            this.darbaSamaksasAprēķinsToolStripMenuItem,
            this.miAprekinaSeciba,
            this.toolStripSeparator2,
            this.aprēķinaIzklāstsToolStripMenuItem,
            this.toolStripSeparator3,
            this.algasParēķinaLapaToolStripMenuItem,
            this.toolStripSeparator4,
            this.miShoeBonusList,
            this.miRādītDarbiniekuAmatus});
            this.algasAprēķinaLapaToolStripMenuItem.MergeIndex = 2;
            this.algasAprēķinaLapaToolStripMenuItem.Name = "algasAprēķinaLapaToolStripMenuItem";
            this.algasAprēķinaLapaToolStripMenuItem.Size = new System.Drawing.Size(196, 29);
            this.algasAprēķinaLapaToolStripMenuItem.Text = "Algas aprēķina lapa";
            // 
            // pārrēķinātDarbiniekamToolStripMenuItem1
            // 
            this.pārrēķinātDarbiniekamToolStripMenuItem1.Name = "pārrēķinātDarbiniekamToolStripMenuItem1";
            this.pārrēķinātDarbiniekamToolStripMenuItem1.Size = new System.Drawing.Size(401, 30);
            this.pārrēķinātDarbiniekamToolStripMenuItem1.Text = "Pārrēķināt darbiniekam";
            this.pārrēķinātDarbiniekamToolStripMenuItem1.Click += new System.EventHandler(this.pārrēķinātDarbiniekamToolStripMenuItem1_Click);
            // 
            // pārrēķinātVisiemToolStripMenuItem
            // 
            this.pārrēķinātVisiemToolStripMenuItem.Name = "pārrēķinātVisiemToolStripMenuItem";
            this.pārrēķinātVisiemToolStripMenuItem.Size = new System.Drawing.Size(401, 30);
            this.pārrēķinātVisiemToolStripMenuItem.Text = "Pārrēķināt sarakstu";
            this.pārrēķinātVisiemToolStripMenuItem.Click += new System.EventHandler(this.pārrēķinātVisiemToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(398, 6);
            // 
            // vidējāsIzpeļņasAprēķinsToolStripMenuItem
            // 
            this.vidējāsIzpeļņasAprēķinsToolStripMenuItem.Name = "vidējāsIzpeļņasAprēķinsToolStripMenuItem";
            this.vidējāsIzpeļņasAprēķinsToolStripMenuItem.Size = new System.Drawing.Size(401, 30);
            this.vidējāsIzpeļņasAprēķinsToolStripMenuItem.Text = "Vidējās izpeļņas aprēķins";
            this.vidējāsIzpeļņasAprēķinsToolStripMenuItem.Click += new System.EventHandler(this.vidējāsIzpeļņasAprēķinsToolStripMenuItem_Click);
            // 
            // slimībasNaudasAprēķinsToolStripMenuItem
            // 
            this.slimībasNaudasAprēķinsToolStripMenuItem.Name = "slimībasNaudasAprēķinsToolStripMenuItem";
            this.slimībasNaudasAprēķinsToolStripMenuItem.Size = new System.Drawing.Size(401, 30);
            this.slimībasNaudasAprēķinsToolStripMenuItem.Text = "Slimības naudas aprēķins";
            this.slimībasNaudasAprēķinsToolStripMenuItem.Click += new System.EventHandler(this.slimībasNaudasAprēķinsToolStripMenuItem_Click);
            // 
            // atvaļinājumaNaudasAprēķinsToolStripMenuItem
            // 
            this.atvaļinājumaNaudasAprēķinsToolStripMenuItem.Name = "atvaļinājumaNaudasAprēķinsToolStripMenuItem";
            this.atvaļinājumaNaudasAprēķinsToolStripMenuItem.Size = new System.Drawing.Size(401, 30);
            this.atvaļinājumaNaudasAprēķinsToolStripMenuItem.Text = "Atvaļinājuma naudas aprēķins";
            this.atvaļinājumaNaudasAprēķinsToolStripMenuItem.Click += new System.EventHandler(this.atvaļinājumaNaudasAprēķinsToolStripMenuItem_Click);
            // 
            // darbaSamaksasAprēķinsToolStripMenuItem
            // 
            this.darbaSamaksasAprēķinsToolStripMenuItem.Name = "darbaSamaksasAprēķinsToolStripMenuItem";
            this.darbaSamaksasAprēķinsToolStripMenuItem.Size = new System.Drawing.Size(401, 30);
            this.darbaSamaksasAprēķinsToolStripMenuItem.Text = "Darba samaksas aprēķins";
            this.darbaSamaksasAprēķinsToolStripMenuItem.Click += new System.EventHandler(this.darbaSamaksasAprēķinsToolStripMenuItem_Click);
            // 
            // miAprekinaSeciba
            // 
            this.miAprekinaSeciba.Name = "miAprekinaSeciba";
            this.miAprekinaSeciba.Size = new System.Drawing.Size(401, 30);
            this.miAprekinaSeciba.Text = "Aprēķina secība";
            this.miAprekinaSeciba.Click += new System.EventHandler(this.miAprekinaSeciba_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(398, 6);
            // 
            // aprēķinaIzklāstsToolStripMenuItem
            // 
            this.aprēķinaIzklāstsToolStripMenuItem.Name = "aprēķinaIzklāstsToolStripMenuItem";
            this.aprēķinaIzklāstsToolStripMenuItem.Size = new System.Drawing.Size(401, 30);
            this.aprēķinaIzklāstsToolStripMenuItem.Text = "Aprēķina izklāsts";
            this.aprēķinaIzklāstsToolStripMenuItem.Click += new System.EventHandler(this.aprēķinaIzklāstsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(398, 6);
            // 
            // algasParēķinaLapaToolStripMenuItem
            // 
            this.algasParēķinaLapaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arAmatiemBezParakstiemToolStripMenuItem,
            this.bezAmatiemArParakstiemToolStripMenuItem});
            this.algasParēķinaLapaToolStripMenuItem.Name = "algasParēķinaLapaToolStripMenuItem";
            this.algasParēķinaLapaToolStripMenuItem.Size = new System.Drawing.Size(401, 30);
            this.algasParēķinaLapaToolStripMenuItem.Text = "Algas aprēķina lapa";
            // 
            // arAmatiemBezParakstiemToolStripMenuItem
            // 
            this.arAmatiemBezParakstiemToolStripMenuItem.Name = "arAmatiemBezParakstiemToolStripMenuItem";
            this.arAmatiemBezParakstiemToolStripMenuItem.Size = new System.Drawing.Size(329, 30);
            this.arAmatiemBezParakstiemToolStripMenuItem.Text = "ar amatiem, bez parakstiem";
            this.arAmatiemBezParakstiemToolStripMenuItem.Click += new System.EventHandler(this.arAmatiemBezParakstiemToolStripMenuItem_Click);
            // 
            // bezAmatiemArParakstiemToolStripMenuItem
            // 
            this.bezAmatiemArParakstiemToolStripMenuItem.Name = "bezAmatiemArParakstiemToolStripMenuItem";
            this.bezAmatiemArParakstiemToolStripMenuItem.Size = new System.Drawing.Size(329, 30);
            this.bezAmatiemArParakstiemToolStripMenuItem.Text = "bez amatiem, ar parakstiem";
            this.bezAmatiemArParakstiemToolStripMenuItem.Click += new System.EventHandler(this.bezAmatiemArParakstiemToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(398, 6);
            // 
            // miShoeBonusList
            // 
            this.miShoeBonusList.Name = "miShoeBonusList";
            this.miShoeBonusList.Size = new System.Drawing.Size(401, 30);
            this.miShoeBonusList.Text = "Rādīt piemaksu / atvilkumu sarakstu";
            this.miShoeBonusList.Click += new System.EventHandler(this.miShoeBonusList_Click);
            // 
            // miRādītDarbiniekuAmatus
            // 
            this.miRādītDarbiniekuAmatus.Name = "miRādītDarbiniekuAmatus";
            this.miRādītDarbiniekuAmatus.Size = new System.Drawing.Size(401, 30);
            this.miRādītDarbiniekuAmatus.Text = "Rādīt darbinieku amatus";
            this.miRādītDarbiniekuAmatus.Click += new System.EventHandler(this.miRādītDarbiniekuAmatus_Click);
            // 
            // dgcSarSnr
            // 
            this.dgcSarSnr.DataPropertyName = "SNR";
            this.dgcSarSnr.Frozen = true;
            this.dgcSarSnr.HeaderText = "npk.";
            this.dgcSarSnr.Name = "dgcSarSnr";
            this.dgcSarSnr.ReadOnly = true;
            this.dgcSarSnr.Width = 40;
            // 
            // dgcSarName
            // 
            this.dgcSarName.DataPropertyName = "YNAME";
            this.dgcSarName.Frozen = true;
            this.dgcSarName.HeaderText = "darbineiks";
            this.dgcSarName.Name = "dgcSarName";
            this.dgcSarName.ReadOnly = true;
            this.dgcSarName.Width = 130;
            // 
            // dgcSarPositionTitle
            // 
            this.dgcSarPositionTitle.DataPropertyName = "POSITION_TITLE";
            this.dgcSarPositionTitle.HeaderText = "amats";
            this.dgcSarPositionTitle.Name = "dgcSarPositionTitle";
            this.dgcSarPositionTitle.ReadOnly = true;
            this.dgcSarPositionTitle.Width = 150;
            // 
            // dgcSarFactDays
            // 
            this.dgcSarFactDays.DataPropertyName = "FACT_DAYS";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgcSarFactDays.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcSarFactDays.HeaderText = "dienas";
            this.dgcSarFactDays.Name = "dgcSarFactDays";
            this.dgcSarFactDays.ReadOnly = true;
            this.dgcSarFactDays.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarFactDays.Width = 60;
            // 
            // dgcSarsFactHours
            // 
            this.dgcSarsFactHours.DataPropertyName = "FACT_HOURS";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgcSarsFactHours.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcSarsFactHours.HeaderText = "stundas";
            this.dgcSarsFactHours.Name = "dgcSarsFactHours";
            this.dgcSarsFactHours.ReadOnly = true;
            this.dgcSarsFactHours.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarsFactHours.Width = 60;
            // 
            // DGCsARsALARY
            // 
            this.DGCsARsALARY.DataPropertyName = "SALARY";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.DGCsARsALARY.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGCsARsALARY.HeaderText = "par darbu";
            this.DGCsARsALARY.Name = "DGCsARsALARY";
            this.DGCsARsALARY.ReadOnly = true;
            this.DGCsARsALARY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DGCsARsALARY.Width = 80;
            // 
            // dgcSarTotalBeforeTaxes
            // 
            this.dgcSarTotalBeforeTaxes.DataPropertyName = "TOTAL_BEFORE_TAXES";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dgcSarTotalBeforeTaxes.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcSarTotalBeforeTaxes.HeaderText = "ieņ. kopā";
            this.dgcSarTotalBeforeTaxes.Name = "dgcSarTotalBeforeTaxes";
            this.dgcSarTotalBeforeTaxes.ReadOnly = true;
            this.dgcSarTotalBeforeTaxes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarTotalBeforeTaxes.Width = 80;
            // 
            // dgcSarDnSNAmount
            // 
            this.dgcSarDnSNAmount.DataPropertyName = "DNSN_AMOUNT";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.dgcSarDnSNAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcSarDnSNAmount.HeaderText = "SI d.ņ.";
            this.dgcSarDnSNAmount.Name = "dgcSarDnSNAmount";
            this.dgcSarDnSNAmount.ReadOnly = true;
            this.dgcSarDnSNAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarDnSNAmount.Width = 80;
            // 
            // dgcSarSNAmount
            // 
            this.dgcSarSNAmount.DataPropertyName = "SN_AMOUNT";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.dgcSarSNAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcSarSNAmount.HeaderText = "SI";
            this.dgcSarSNAmount.Name = "dgcSarSNAmount";
            this.dgcSarSNAmount.ReadOnly = true;
            this.dgcSarSNAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarSNAmount.Width = 80;
            // 
            // dgcSarIIN
            // 
            this.dgcSarIIN.DataPropertyName = "IIN_AMOUNT";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.dgcSarIIN.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcSarIIN.HeaderText = "IIN";
            this.dgcSarIIN.Name = "dgcSarIIN";
            this.dgcSarIIN.ReadOnly = true;
            this.dgcSarIIN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarIIN.Width = 80;
            // 
            // dgcSarPay
            // 
            this.dgcSarPay.DataPropertyName = "PAY";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.dgcSarPay.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcSarPay.HeaderText = "izmaksai";
            this.dgcSarPay.Name = "dgcSarPay";
            this.dgcSarPay.ReadOnly = true;
            this.dgcSarPay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcSarPay.Width = 80;
            // 
            // dgcSarAdvance
            // 
            this.dgcSarAdvance.DataPropertyName = "ADVANCE";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "# ##0.00;-# ##0.00;\"\"";
            this.dgcSarAdvance.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgcSarAdvance.HeaderText = "avansā";
            this.dgcSarAdvance.Name = "dgcSarAdvance";
            this.dgcSarAdvance.ReadOnly = true;
            this.dgcSarAdvance.ToolTipText = "Avansā izmaksājamā summa";
            this.dgcSarAdvance.Width = 80;
            // 
            // dgcSarPayT
            // 
            this.dgcSarPayT.DataPropertyName = "PAYT";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.dgcSarPayT.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgcSarPayT.HeaderText = "kopā izm.";
            this.dgcSarPayT.Name = "dgcSarPayT";
            this.dgcSarPayT.ReadOnly = true;
            this.dgcSarPayT.Width = 80;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // Form_SalarySheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 487);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cbAmati);
            this.Controls.Add(this.cbLapas);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_SalarySheet";
            this.Text = "Algas aprēķins";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_SalarySheet_FormClosed);
            this.Load += new System.EventHandler(this.Form_SalarySheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsLapas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSarR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSarR2)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAmati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPapildsummasVeids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPapildsummaNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAlgasPapildsummas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAdapterManager1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPapildsummas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataObjectsA.SalaryData salaryData1;
        private KlonsLIB.Data.MyBindingSource bsLapas;
        private KlonsLIB.Data.MyBindingSource2 bsSarR;
        private System.Windows.Forms.BindingSource bsSarR2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslPeriod;
        private KlonsLIB.Components.MyMcFlatComboBox cbLapas;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grPersonTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFName;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grLName;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPositionTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlanDays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlanHours;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlanHoursNight;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlanHoursOvertime;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlanWeekDays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlanWeekHours;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlanWeekHoirsNight;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlanWeekHoursOvertime;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlanHolidaysDays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlanHolidaysHours;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlanHolidaysHoursNight;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlanHolidaysHoursOvertime;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grtInt;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grtInt16;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grtDouble;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDecimal;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grString;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactDays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactHours;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactHoursNight;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactHoursOvertime;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactWeekDays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactWeekHours;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactWeekHoursNight;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactWeekHoursOvertime;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactHolidays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactHolidaysHours;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactHolidaysHoursNight;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactHolidaysHoursOvertime;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSalary;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSalaryDay;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSalaryNight;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSalaryOvertime;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSalaryHolidaysDay;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSalaryHolidaysNight;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSalaryHolidaysOvertime;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationDaysCurrent;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationDaysNext;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationPayCurrent;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationPayNext;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationPayPrev;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationDNSNext;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationDDSNext;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationIINNext;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationDNSPrev;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationDDSPrev;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationIINPrev;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSickDays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSickDaysPay;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grAccidentDays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grAccidentPay;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grAmountBeforeSN;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grRateDNSN;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grRateDDSN;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDNSNAmount;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDDSNAmount;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grIINExemprUntaxedMinimum;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grIINExemptDependants;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grIINExemptInvalidity;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grIINExemptRetaliation;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA geIINExemptNatMov;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grIINExemptExpenses;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grAmountBeforeIIN;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grRateIIN;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grIINAmount;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grPayTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPay;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactAvPayFreeDays;
        private KlonsLIB.Components.MyMcFlatComboBox cbAmati;
        private System.Windows.Forms.ToolStripLabel tslAmati;
        private System.Windows.Forms.BindingSource bsAlgasPapildsummas;
        private KlonsLIB.Data.MyBindingSource bsPapildsummasVeids;
        private KlonsLIB.Data.MyBindingSource bsPapildsummaNo;
        private KlonsLIB.Data.MyBindingSource bsAmati;
        private System.Windows.Forms.ToolStripLabel tslLabel;
        private KlonsLIB.Data.MyAdapterManager myAdapterManager1;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactAvPayFreeHours;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactAvPayWorkDays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactAvPayHours;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactAvPayHoursOvertime;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactAvPayWorkInHolidays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactAvPayHolidaysHours;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grFactAvPayHolidaysHoursOvertime;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSalaryAvPayFreeDays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSalaryAvPayWorkDays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSalaryAvPayWorkDaysOvertime;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSalaryAvPayHolidays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSalaryAvPayHolidaysOvertime;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDecimalProc;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSingle;
        private DataObjectsA.BonusData bonusData1;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB grbIDA;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grbTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grbRate;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grbAmount;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxA grbRateType;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB grbIDNO;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grbTitle2;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowMultiLineTextBox grbDescr2;
        private KlonsLIB.Components.TabControlWithoutHeader tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private KlonsLIB.MySourceGrid.MyGrid sgrAprekins;
        private System.Windows.Forms.TabPage tabPage2;
        private KlonsLIB.MySourceGrid.MyGrid sgrBonus;
        private KlonsLIB.Components.MySplitContainer splitContainer2;
        private KlonsLIB.Components.MyDataGridView dgvLapa;
        private KlonsLIB.Components.MyDataGridView dgvPapildsummas;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationAdvanceCurrent;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationAdvanceNext;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationAdvancePrev;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlusTaxed;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlusNotTaxed;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlusNoSAI;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlusAuthorsFees;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlusPFNotTaxed;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlusPFTaxed;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlusLINotTaxed;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlusLITaxed;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlusHINotTaxed;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlusHITaxed;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grMinusBeforeIIN;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grMinusAfterIIN;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grPlanTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grFactTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grAvPayTimeTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grSalaryTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grSalaryAvPayTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grVacationTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grSickDaysTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grVSAOITitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grIINExemptsTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grPlusMinusTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grIINTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem algasAprēķinaLapaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pārrēķinātDarbiniekamToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pārrēķinātVisiemToolStripMenuItem;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grReverseTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grAmountBeforeSNReverse;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDNSNAmountReverse;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDDSNReverse;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grIINAmountReverse;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowComboBoxB2 grbIDSV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem vidējāsIzpeļņasAprēķinsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slimībasNaudasAprēķinsToolStripMenuItem;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationHoursCurrent;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationHoursNext;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grVacationCashNext;
        private System.Windows.Forms.ToolStripMenuItem atvaļinājumaNaudasAprēķinsToolStripMenuItem;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grVacationTitleNext;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grVacationTitlePrev;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grVacationTitleAdvance;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grPlanWorkDaysTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grPlanHolidaysTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grFactWorkDaysTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grFactHolidaysTitle;
        private System.Windows.Forms.ToolStripMenuItem darbaSamaksasAprēķinsToolStripMenuItem;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grSalaryTitle2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aprēķinaIzklāstsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem algasParēķinaLapaToolStripMenuItem;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grSalaryPieceWork;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPayAdv;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPayT;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grIINExemprUntaxedMinimum0;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grPayEmpty;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grDecimalReadOnly;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem miShoeBonusList;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grPlusNPNotTaxed;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox grbIsPaid;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowCheckBox grbIsInAvpay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPsDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPsRate;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcPsRateType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPsAmount;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcPsIDSV;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcPsIDNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPsIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPsIDP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPsIDAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPsIDSX;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grPlanMonthTitle;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grMonthWorkDays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grMonthWorkhours;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTitle grPlanTitleA;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCalendarDays;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grCalendarDaysUse;
        private System.Windows.Forms.ToolStripMenuItem arAmatiemBezParakstiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bezAmatiemArParakstiemToolStripMenuItem;
        private KlonsLIB.MySourceGrid.GridRows.MyGridRowTextBoxA grRateIIN2;
        private System.Windows.Forms.ToolStripMenuItem miAprekinaSeciba;
        private System.Windows.Forms.ToolStripMenuItem miRādītDarbiniekuAmatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarSnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarPositionTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarFactDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarsFactHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCsARsALARY;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarTotalBeforeTaxes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarDnSNAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarSNAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarIIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarAdvance;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcSarPayT;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    }
}