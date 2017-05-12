using KlonsLIB.Components;
using KlonsLIB.Data;

namespace KlonsF.FormsReportParams
{
    partial class FormRep_PVNDekl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRep_PVNDekl));
            this.bsAC = new KlonsLIB.Data.MyBindingSource();
            this.tbSD = new KlonsLIB.Components.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbED = new KlonsLIB.Components.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAmats = new KlonsLIB.Components.MyTextBox();
            this.tbVards = new KlonsLIB.Components.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUzvards = new KlonsLIB.Components.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDateNow = new KlonsLIB.Components.MyTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbXSumma = new KlonsLIB.Components.MyTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.pVNDeklarācijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pVN2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.piel2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemPaDokumentiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.xMLAtskaiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLAtskaiteBezPVN2PielikumaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsAC
            // 
            this.bsAC.DataMember = "AcP21";
            this.bsAC.MyDataSource = "KlonsData";
            this.bsAC.Name2 = "bsAC";
            // 
            // tbSD
            // 
            this.tbSD.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSD.IsDate = true;
            this.tbSD.Location = new System.Drawing.Point(150, 18);
            this.tbSD.Margin = new System.Windows.Forms.Padding(2);
            this.tbSD.Name = "tbSD";
            this.tbSD.Size = new System.Drawing.Size(80, 22);
            this.tbSD.TabIndex = 0;
            this.tbSD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Datums (no - līdz):";
            // 
            // tbED
            // 
            this.tbED.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbED.IsDate = true;
            this.tbED.Location = new System.Drawing.Point(235, 18);
            this.tbED.Margin = new System.Windows.Forms.Padding(2);
            this.tbED.Name = "tbED";
            this.tbED.Size = new System.Drawing.Size(80, 22);
            this.tbED.TabIndex = 1;
            this.tbED.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Amats:";
            // 
            // tbAmats
            // 
            this.tbAmats.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbAmats.Location = new System.Drawing.Point(87, 81);
            this.tbAmats.Margin = new System.Windows.Forms.Padding(2);
            this.tbAmats.Name = "tbAmats";
            this.tbAmats.Size = new System.Drawing.Size(140, 22);
            this.tbAmats.TabIndex = 3;
            this.tbAmats.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // tbVards
            // 
            this.tbVards.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbVards.Location = new System.Drawing.Point(87, 113);
            this.tbVards.Margin = new System.Windows.Forms.Padding(2);
            this.tbVards.Name = "tbVards";
            this.tbVards.Size = new System.Drawing.Size(94, 22);
            this.tbVards.TabIndex = 4;
            this.tbVards.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Vārds:";
            // 
            // tbUzvards
            // 
            this.tbUzvards.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbUzvards.Location = new System.Drawing.Point(87, 145);
            this.tbUzvards.Margin = new System.Windows.Forms.Padding(2);
            this.tbUzvards.Name = "tbUzvards";
            this.tbUzvards.Size = new System.Drawing.Size(99, 22);
            this.tbUzvards.TabIndex = 5;
            this.tbUzvards.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Uzvārds:";
            // 
            // tbDateNow
            // 
            this.tbDateNow.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDateNow.IsDate = true;
            this.tbDateNow.Location = new System.Drawing.Point(166, 49);
            this.tbDateNow.Margin = new System.Windows.Forms.Padding(2);
            this.tbDateNow.Name = "tbDateNow";
            this.tbDateNow.Size = new System.Drawing.Size(80, 22);
            this.tbDateNow.TabIndex = 2;
            this.tbDateNow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Izrakstīšanas datums:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 178);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Dokumentu summu robeža:";
            // 
            // tbXSumma
            // 
            this.tbXSumma.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbXSumma.Location = new System.Drawing.Point(199, 176);
            this.tbXSumma.Margin = new System.Windows.Forms.Padding(2);
            this.tbXSumma.Name = "tbXSumma";
            this.tbXSumma.Size = new System.Drawing.Size(80, 22);
            this.tbXSumma.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3});
            this.toolStrip1.Location = new System.Drawing.Point(11, 215);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(307, 32);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pVNDeklarācijaToolStripMenuItem,
            this.toolStripSeparator1,
            this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem,
            this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem,
            this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(97, 29);
            this.toolStripDropDownButton1.Text = "Izdrukai";
            // 
            // pVNDeklarācijaToolStripMenuItem
            // 
            this.pVNDeklarācijaToolStripMenuItem.Name = "pVNDeklarācijaToolStripMenuItem";
            this.pVNDeklarācijaToolStripMenuItem.Size = new System.Drawing.Size(1009, 30);
            this.pVNDeklarācijaToolStripMenuItem.Text = "PVN deklarācija";
            this.pVNDeklarācijaToolStripMenuItem.Click += new System.EventHandler(this.pVNDeklarācijaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(1006, 6);
            // 
            // piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem
            // 
            this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem.Name = "piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStrip" +
    "MenuItem";
            this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem.Size = new System.Drawing.Size(1009, 30);
            this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem.Text = "Piel.1.1: Nodokļa summas par iekšzemē iegādātajām precēm un saņemtajiem pakalpoju" +
    "miem";
            this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem.Click += new System.EventHandler(this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem_Click);
            // 
            // piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem
            // 
            this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem.Name = "piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvals" +
    "tīmToolStripMenuItem";
            this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem.Size = new System.Drawing.Size(1009, 30);
            this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem.Text = "Piel.1.2: Nodokļa  summas par precēm un pakalpojumiem, kas saņemti no Eiropas Sav" +
    "ienības dalībvalstīm";
            this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem.Click += new System.EventHandler(this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem_Click);
            // 
            // piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem
            // 
            this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem.Name = "piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStrip" +
    "MenuItem";
            this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem.Size = new System.Drawing.Size(1009, 30);
            this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem.Text = "Piel.1.3: Aprēķinātais nodoklis par piegādātajām precēm un sniegtajiem pakalpojum" +
    "iem";
            this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem.Click += new System.EventHandler(this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem1,
            this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem1,
            this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem1,
            this.pVN2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemToolStripMenuItem,
            this.piel2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemPaDokumentiemToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(90, 29);
            this.toolStripDropDownButton2.Text = "Tabula";
            // 
            // piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem1
            // 
            this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem1.Name = "piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStrip" +
    "MenuItem1";
            this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem1.Size = new System.Drawing.Size(1009, 30);
            this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem1.Text = "Piel.1.1: Nodokļa summas par iekšzemē iegādātajām precēm un saņemtajiem pakalpoju" +
    "miem";
            this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem1.Click += new System.EventHandler(this.piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem1_Click);
            // 
            // piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem1
            // 
            this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem1.Name = "piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvals" +
    "tīmToolStripMenuItem1";
            this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem1.Size = new System.Drawing.Size(1009, 30);
            this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem1.Text = "Piel.1.2: Nodokļa  summas par precēm un pakalpojumiem, kas saņemti no Eiropas Sav" +
    "ienības dalībvalstīm";
            this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem1.Click += new System.EventHandler(this.piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem1_Click);
            // 
            // piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem1
            // 
            this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem1.Name = "piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStrip" +
    "MenuItem1";
            this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem1.Size = new System.Drawing.Size(1009, 30);
            this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem1.Text = "Piel.1.3: Aprēķinātais nodoklis par piegādātajām precēm un sniegtajiem pakalpojum" +
    "iem";
            this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem1.Click += new System.EventHandler(this.piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem1_Click);
            // 
            // pVN2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemToolStripMenuItem
            // 
            this.pVN2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemToolStripMenuItem.Name = "pVN2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemToolStripMenuItem";
            this.pVN2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemToolStripMenuItem.Size = new System.Drawing.Size(1009, 30);
            this.pVN2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemToolStripMenuItem.Text = "Piel. 2: Pārskats par preču piegādēm un sniegtajiem pakalpojumiem";
            this.pVN2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemToolStripMenuItem.Click += new System.EventHandler(this.pVN2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemToolStripMenuItem_Click);
            // 
            // piel2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemPaDokumentiemToolStripMenuItem
            // 
            this.piel2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemPaDokumentiemToolStripMenuItem.Name = "piel2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemPaDokumentiemToolStripMenu" +
    "Item";
            this.piel2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemPaDokumentiemToolStripMenuItem.Size = new System.Drawing.Size(1009, 30);
            this.piel2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemPaDokumentiemToolStripMenuItem.Text = "Piel. 2: Pārskats par preču piegādēm un sniegtajiem pakalpojumiem - pa dokumentie" +
    "m";
            this.piel2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemPaDokumentiemToolStripMenuItem.Click += new System.EventHandler(this.piel2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemPaDokumentiemToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMLAtskaiteToolStripMenuItem,
            this.xMLAtskaiteBezPVN2PielikumaToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(110, 29);
            this.toolStripDropDownButton3.Text = "XML fails";
            // 
            // xMLAtskaiteToolStripMenuItem
            // 
            this.xMLAtskaiteToolStripMenuItem.Name = "xMLAtskaiteToolStripMenuItem";
            this.xMLAtskaiteToolStripMenuItem.Size = new System.Drawing.Size(392, 30);
            this.xMLAtskaiteToolStripMenuItem.Text = "XML Atskaite";
            this.xMLAtskaiteToolStripMenuItem.Click += new System.EventHandler(this.xMLAtskaiteToolStripMenuItem_Click);
            // 
            // xMLAtskaiteBezPVN2PielikumaToolStripMenuItem
            // 
            this.xMLAtskaiteBezPVN2PielikumaToolStripMenuItem.Name = "xMLAtskaiteBezPVN2PielikumaToolStripMenuItem";
            this.xMLAtskaiteBezPVN2PielikumaToolStripMenuItem.Size = new System.Drawing.Size(392, 30);
            this.xMLAtskaiteBezPVN2PielikumaToolStripMenuItem.Text = "XML atskaite bez PVN 2 pielikuma";
            this.xMLAtskaiteBezPVN2PielikumaToolStripMenuItem.Click += new System.EventHandler(this.xMLAtskaiteBezPVN2PielikumaToolStripMenuItem_Click);
            // 
            // FormRep_PVNDekl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 291);
            this.CloseOnEscape = true;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbXSumma);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbED);
            this.Controls.Add(this.tbUzvards);
            this.Controls.Add(this.tbVards);
            this.Controls.Add(this.tbAmats);
            this.Controls.Add(this.tbDateNow);
            this.Controls.Add(this.tbSD);
            this.Name = "FormRep_PVNDekl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apgrozijumu pārskata parametri";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRep_PVNDekl_FormClosing);
            this.Load += new System.EventHandler(this.FormRepApgr1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsAC)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyBindingSource bsAC;
        private MyTextBox tbSD;
        private System.Windows.Forms.Label label1;
        private MyTextBox tbED;
        private System.Windows.Forms.Label label2;
        private MyTextBox tbAmats;
        private MyTextBox tbVards;
        private System.Windows.Forms.Label label3;
        private MyTextBox tbUzvards;
        private System.Windows.Forms.Label label4;
        private MyTextBox tbDateNow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private MyTextBox tbXSumma;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem pVNDeklarācijaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem piel1NodokļaSummasParIekšzemēIegādātajāmPrecēmUnSaņemtajiemPakalpojumiemToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem piel3AprēķinātaisNodoklisParPiegādātajāmPrecēmUnSniegtajiemPakalpojumiemToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pVN2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem xMLAtskaiteBezPVN2PielikumaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem piel12NodokļaSummasParPrecēmUnPakalpojumiemKasSaņemtiNoEiropasSavienībasDalībvalstīmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem xMLAtskaiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem piel2PārskatsParPrečuPiegādēmUnSniegtajiemPakalpojumiemPaDokumentiemToolStripMenuItem;
    }
}