

namespace VahtiApp
{
    partial class Frm_Vahti_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Vahti_Main));
            this.Tmr_Vahti = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TsStsLbl_Vahti_ToDo = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSSttsBr_Vahti = new System.Windows.Forms.ToolStripProgressBar();
            this.TsStpLbl_Vahti = new System.Windows.Forms.ToolStripStatusLabel();
            this.SplCnt_Vahti = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.CBx_ID = new System.Windows.Forms.CheckBox();
            this.btn_All = new System.Windows.Forms.Button();
            this.btn_EiKiinnosta = new System.Windows.Forms.Button();
            this.Btn_TalletaRaportti = new System.Windows.Forms.Button();
            this.ChckBx_Uusi = new System.Windows.Forms.CheckBox();
            this.btn_Kasittele = new System.Windows.Forms.Button();
            this.TxtTrace = new System.Windows.Forms.TextBox();
            this.Btn_Kuvaus = new System.Windows.Forms.Button();
            this.Btn_Erotele_Sanat = new System.Windows.Forms.Button();
            this.chkbxlst_VahtiSanat = new System.Windows.Forms.CheckedListBox();
            this.btn_Rapotti = new System.Windows.Forms.Button();
            this.Btn_Listaa = new System.Windows.Forms.Button();
            this.Btn_Suodata = new System.Windows.Forms.Button();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.Btn_JTarj = new System.Windows.Forms.Button();
            this.CBx_Tarjous = new System.Windows.Forms.CheckBox();
            this.CBx_Pien = new System.Windows.Forms.CheckBox();
            this.CBx_Hilma = new System.Windows.Forms.CheckBox();
            this.Btn_HilmaData = new System.Windows.Forms.Button();
            this.lbl_Tarjouksia = new System.Windows.Forms.Label();
            this.btn_tarjouksia = new System.Windows.Forms.Button();
            this.Btn_Lisaa = new System.Windows.Forms.Button();
            this.Btn_ppy = new System.Windows.Forms.Button();
            this.Btn_Sampo = new System.Windows.Forms.Button();
            this.Btn_Hilma = new System.Windows.Forms.Button();
            this.Btn_Tarjouspalvelu = new System.Windows.Forms.Button();
            this.Btn_PienHankinta = new System.Windows.Forms.Button();
            this.Lbx_Vahti = new System.Windows.Forms.ListBox();
            this.TB_Kerta = new System.Windows.Forms.TextBox();
            this.TbCnt_Vahti = new System.Windows.Forms.TabControl();
            this.PG_Vahti = new System.Windows.Forms.TabPage();
            this.WBPanel = new System.Windows.Forms.Panel();
            this.tsWB = new System.Windows.Forms.ToolStrip();
            this.TSSep = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDDBtn_Kiinnostus = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tutkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kiinnostavaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSCmBx_Kiinnostus = new System.Windows.Forms.ToolStripComboBox();
            this.TSTXBX_Palkki = new System.Windows.Forms.ToolStripTextBox();
            this.RchTxtBx_Vahti = new System.Windows.Forms.RichTextBox();
            this.Tmr_SivuVahti = new System.Windows.Forms.Timer(this.components);
            this.WBrHilma = new System.Windows.Forms.WebBrowser();
            this.WBrHilma2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplCnt_Vahti)).BeginInit();
            this.SplCnt_Vahti.Panel1.SuspendLayout();
            this.SplCnt_Vahti.Panel2.SuspendLayout();
            this.SplCnt_Vahti.SuspendLayout();
            this.TbCnt_Vahti.SuspendLayout();
            this.PG_Vahti.SuspendLayout();
            this.WBPanel.SuspendLayout();
            this.tsWB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WBrHilma2)).BeginInit();
            this.SuspendLayout();
            // 
            // Tmr_Vahti
            // 
            this.Tmr_Vahti.Tick += new System.EventHandler(this.Tmr_Vahti_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsStsLbl_Vahti_ToDo,
            this.TSSttsBr_Vahti,
            this.TsStpLbl_Vahti});
            this.statusStrip1.Location = new System.Drawing.Point(0, 548);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1154, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TsStsLbl_Vahti_ToDo
            // 
            this.TsStsLbl_Vahti_ToDo.AutoSize = false;
            this.TsStsLbl_Vahti_ToDo.Name = "TsStsLbl_Vahti_ToDo";
            this.TsStsLbl_Vahti_ToDo.Size = new System.Drawing.Size(200, 17);
            this.TsStsLbl_Vahti_ToDo.Text = "ToDo:";
            // 
            // TSSttsBr_Vahti
            // 
            this.TSSttsBr_Vahti.Name = "TSSttsBr_Vahti";
            this.TSSttsBr_Vahti.Size = new System.Drawing.Size(300, 16);
            // 
            // TsStpLbl_Vahti
            // 
            this.TsStpLbl_Vahti.Name = "TsStpLbl_Vahti";
            this.TsStpLbl_Vahti.Size = new System.Drawing.Size(13, 17);
            this.TsStpLbl_Vahti.Text = "0";
            // 
            // SplCnt_Vahti
            // 
            this.SplCnt_Vahti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplCnt_Vahti.Location = new System.Drawing.Point(0, 0);
            this.SplCnt_Vahti.Name = "SplCnt_Vahti";
            // 
            // SplCnt_Vahti.Panel1
            // 
            this.SplCnt_Vahti.Panel1.Controls.Add(this.button1);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.CBx_ID);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.btn_All);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.btn_EiKiinnosta);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Btn_TalletaRaportti);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.ChckBx_Uusi);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.btn_Kasittele);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.TxtTrace);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Btn_Kuvaus);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Btn_Erotele_Sanat);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.chkbxlst_VahtiSanat);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.btn_Rapotti);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Btn_Listaa);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Btn_Suodata);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.lbl_timer);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Btn_JTarj);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.CBx_Tarjous);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.CBx_Pien);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.CBx_Hilma);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Btn_HilmaData);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.lbl_Tarjouksia);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.btn_tarjouksia);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Btn_Lisaa);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Btn_ppy);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Btn_Sampo);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Btn_Hilma);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Btn_Tarjouspalvelu);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Btn_PienHankinta);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.Lbx_Vahti);
            this.SplCnt_Vahti.Panel1.Controls.Add(this.TB_Kerta);
            // 
            // SplCnt_Vahti.Panel2
            // 
            this.SplCnt_Vahti.Panel2.Controls.Add(this.TbCnt_Vahti);
            this.SplCnt_Vahti.Panel2.Controls.Add(this.RchTxtBx_Vahti);
            this.SplCnt_Vahti.Size = new System.Drawing.Size(1154, 548);
            this.SplCnt_Vahti.SplitterDistance = 568;
            this.SplCnt_Vahti.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 19);
            this.button1.TabIndex = 47;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CBx_ID
            // 
            this.CBx_ID.AutoSize = true;
            this.CBx_ID.Location = new System.Drawing.Point(202, 90);
            this.CBx_ID.Name = "CBx_ID";
            this.CBx_ID.Size = new System.Drawing.Size(72, 17);
            this.CBx_ID.TabIndex = 46;
            this.CBx_ID.Text = "Show IDs";
            this.CBx_ID.UseVisualStyleBackColor = true;
            // 
            // btn_All
            // 
            this.btn_All.Location = new System.Drawing.Point(122, 416);
            this.btn_All.Name = "btn_All";
            this.btn_All.Size = new System.Drawing.Size(75, 23);
            this.btn_All.TabIndex = 45;
            this.btn_All.Text = "ListAll";
            this.btn_All.UseVisualStyleBackColor = true;
            this.btn_All.Click += new System.EventHandler(this.btn_All_Click);
            // 
            // btn_EiKiinnosta
            // 
            this.btn_EiKiinnosta.Location = new System.Drawing.Point(12, 295);
            this.btn_EiKiinnosta.Name = "btn_EiKiinnosta";
            this.btn_EiKiinnosta.Size = new System.Drawing.Size(102, 24);
            this.btn_EiKiinnosta.TabIndex = 44;
            this.btn_EiKiinnosta.Text = "Ei kiinnosta";
            this.btn_EiKiinnosta.UseVisualStyleBackColor = true;
            this.btn_EiKiinnosta.Click += new System.EventHandler(this.btn_EiKiinnosta_Click);
            // 
            // Btn_TalletaRaportti
            // 
            this.Btn_TalletaRaportti.Location = new System.Drawing.Point(12, 189);
            this.Btn_TalletaRaportti.Name = "Btn_TalletaRaportti";
            this.Btn_TalletaRaportti.Size = new System.Drawing.Size(103, 22);
            this.Btn_TalletaRaportti.TabIndex = 43;
            this.Btn_TalletaRaportti.Text = "Talleta Raportti";
            this.Btn_TalletaRaportti.UseVisualStyleBackColor = true;
            this.Btn_TalletaRaportti.Visible = false;
            this.Btn_TalletaRaportti.Click += new System.EventHandler(this.Btn_TalletaRaportti_Click);
            // 
            // ChckBx_Uusi
            // 
            this.ChckBx_Uusi.AutoSize = true;
            this.ChckBx_Uusi.Enabled = false;
            this.ChckBx_Uusi.Location = new System.Drawing.Point(14, 229);
            this.ChckBx_Uusi.Name = "ChckBx_Uusi";
            this.ChckBx_Uusi.Size = new System.Drawing.Size(47, 17);
            this.ChckBx_Uusi.TabIndex = 42;
            this.ChckBx_Uusi.Text = "Uusi";
            this.ChckBx_Uusi.UseVisualStyleBackColor = true;
            this.ChckBx_Uusi.CheckStateChanged += new System.EventHandler(this.ChkBx_Vahti_CheckStateChanged);
            // 
            // btn_Kasittele
            // 
            this.btn_Kasittele.Location = new System.Drawing.Point(14, 252);
            this.btn_Kasittele.Name = "btn_Kasittele";
            this.btn_Kasittele.Size = new System.Drawing.Size(102, 25);
            this.btn_Kasittele.TabIndex = 41;
            this.btn_Kasittele.Text = "Käsittele";
            this.btn_Kasittele.UseVisualStyleBackColor = true;
            this.btn_Kasittele.Click += new System.EventHandler(this.btn_Kasittele_Click);
            // 
            // TxtTrace
            // 
            this.TxtTrace.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtTrace.Location = new System.Drawing.Point(0, 454);
            this.TxtTrace.Multiline = true;
            this.TxtTrace.Name = "TxtTrace";
            this.TxtTrace.Size = new System.Drawing.Size(568, 94);
            this.TxtTrace.TabIndex = 40;
            this.TxtTrace.TextChanged += new System.EventHandler(this.TxtTrace_TextChanged);
            // 
            // Btn_Kuvaus
            // 
            this.Btn_Kuvaus.Location = new System.Drawing.Point(377, 41);
            this.Btn_Kuvaus.Name = "Btn_Kuvaus";
            this.Btn_Kuvaus.Size = new System.Drawing.Size(125, 23);
            this.Btn_Kuvaus.TabIndex = 39;
            this.Btn_Kuvaus.Text = "Tarkempi kuvaus";
            this.Btn_Kuvaus.UseVisualStyleBackColor = true;
            this.Btn_Kuvaus.Click += new System.EventHandler(this.Btn_Kuvaus_Click);
            // 
            // Btn_Erotele_Sanat
            // 
            this.Btn_Erotele_Sanat.Location = new System.Drawing.Point(265, 426);
            this.Btn_Erotele_Sanat.Name = "Btn_Erotele_Sanat";
            this.Btn_Erotele_Sanat.Size = new System.Drawing.Size(103, 23);
            this.Btn_Erotele_Sanat.TabIndex = 38;
            this.Btn_Erotele_Sanat.Text = "Erottele sanat";
            this.Btn_Erotele_Sanat.UseVisualStyleBackColor = true;
            this.Btn_Erotele_Sanat.Click += new System.EventHandler(this.Btn_Erotele_Sanat_Click);
            // 
            // chkbxlst_VahtiSanat
            // 
            this.chkbxlst_VahtiSanat.FormattingEnabled = true;
            this.chkbxlst_VahtiSanat.Location = new System.Drawing.Point(197, 129);
            this.chkbxlst_VahtiSanat.Name = "chkbxlst_VahtiSanat";
            this.chkbxlst_VahtiSanat.Size = new System.Drawing.Size(171, 289);
            this.chkbxlst_VahtiSanat.TabIndex = 37;
            // 
            // btn_Rapotti
            // 
            this.btn_Rapotti.Location = new System.Drawing.Point(12, 163);
            this.btn_Rapotti.Name = "btn_Rapotti";
            this.btn_Rapotti.Size = new System.Drawing.Size(104, 23);
            this.btn_Rapotti.TabIndex = 36;
            this.btn_Rapotti.Text = "Tee Raportti";
            this.btn_Rapotti.UseVisualStyleBackColor = true;
            this.btn_Rapotti.Click += new System.EventHandler(this.btn_Rapotti_Click);
            // 
            // Btn_Listaa
            // 
            this.Btn_Listaa.Location = new System.Drawing.Point(13, 136);
            this.Btn_Listaa.Name = "Btn_Listaa";
            this.Btn_Listaa.Size = new System.Drawing.Size(102, 20);
            this.Btn_Listaa.TabIndex = 35;
            this.Btn_Listaa.Text = "Listaa Hankinnat";
            this.Btn_Listaa.UseVisualStyleBackColor = true;
            this.Btn_Listaa.Click += new System.EventHandler(this.Btn_Listaa_Click);
            // 
            // Btn_Suodata
            // 
            this.Btn_Suodata.Location = new System.Drawing.Point(11, 367);
            this.Btn_Suodata.Name = "Btn_Suodata";
            this.Btn_Suodata.Size = new System.Drawing.Size(142, 22);
            this.Btn_Suodata.TabIndex = 34;
            this.Btn_Suodata.Text = "Suodata";
            this.Btn_Suodata.UseVisualStyleBackColor = true;
            this.Btn_Suodata.Click += new System.EventHandler(this.Btn_Suodata_Click);
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Location = new System.Drawing.Point(9, 106);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(51, 13);
            this.lbl_timer.TabIndex = 33;
            this.lbl_timer.Text = "Tirer stop";
            // 
            // Btn_JTarj
            // 
            this.Btn_JTarj.Location = new System.Drawing.Point(202, 64);
            this.Btn_JTarj.Name = "Btn_JTarj";
            this.Btn_JTarj.Size = new System.Drawing.Size(142, 20);
            this.Btn_JTarj.TabIndex = 32;
            this.Btn_JTarj.Text = "Tallenna";
            this.Btn_JTarj.UseVisualStyleBackColor = true;
            this.Btn_JTarj.Click += new System.EventHandler(this.Btn_Talleta_Click);
            // 
            // CBx_Tarjous
            // 
            this.CBx_Tarjous.AutoSize = true;
            this.CBx_Tarjous.Location = new System.Drawing.Point(122, 84);
            this.CBx_Tarjous.Name = "CBx_Tarjous";
            this.CBx_Tarjous.Size = new System.Drawing.Size(61, 17);
            this.CBx_Tarjous.TabIndex = 31;
            this.CBx_Tarjous.Text = "Tarjous";
            this.CBx_Tarjous.UseVisualStyleBackColor = true;
            // 
            // CBx_Pien
            // 
            this.CBx_Pien.AutoSize = true;
            this.CBx_Pien.Location = new System.Drawing.Point(122, 54);
            this.CBx_Pien.Name = "CBx_Pien";
            this.CBx_Pien.Size = new System.Drawing.Size(47, 17);
            this.CBx_Pien.TabIndex = 30;
            this.CBx_Pien.Text = "Pien";
            this.CBx_Pien.UseVisualStyleBackColor = true;
            // 
            // CBx_Hilma
            // 
            this.CBx_Hilma.AutoSize = true;
            this.CBx_Hilma.Location = new System.Drawing.Point(122, 26);
            this.CBx_Hilma.Name = "CBx_Hilma";
            this.CBx_Hilma.Size = new System.Drawing.Size(52, 17);
            this.CBx_Hilma.TabIndex = 29;
            this.CBx_Hilma.Text = "Hilma";
            this.CBx_Hilma.UseVisualStyleBackColor = true;
            // 
            // Btn_HilmaData
            // 
            this.Btn_HilmaData.Location = new System.Drawing.Point(12, 22);
            this.Btn_HilmaData.Name = "Btn_HilmaData";
            this.Btn_HilmaData.Size = new System.Drawing.Size(104, 23);
            this.Btn_HilmaData.TabIndex = 28;
            this.Btn_HilmaData.Text = "Hilmalta";
            this.Btn_HilmaData.UseVisualStyleBackColor = true;
            this.Btn_HilmaData.Click += new System.EventHandler(this.Btn_HilmaData_Click);
            // 
            // lbl_Tarjouksia
            // 
            this.lbl_Tarjouksia.AutoSize = true;
            this.lbl_Tarjouksia.Location = new System.Drawing.Point(214, 19);
            this.lbl_Tarjouksia.Name = "lbl_Tarjouksia";
            this.lbl_Tarjouksia.Size = new System.Drawing.Size(13, 13);
            this.lbl_Tarjouksia.TabIndex = 27;
            this.lbl_Tarjouksia.Text = "0";
            // 
            // btn_tarjouksia
            // 
            this.btn_tarjouksia.Location = new System.Drawing.Point(202, 35);
            this.btn_tarjouksia.Name = "btn_tarjouksia";
            this.btn_tarjouksia.Size = new System.Drawing.Size(142, 23);
            this.btn_tarjouksia.TabIndex = 26;
            this.btn_tarjouksia.Text = "Tarjouksia";
            this.btn_tarjouksia.UseVisualStyleBackColor = true;
            this.btn_tarjouksia.Click += new System.EventHandler(this.btn_tarjouksia_Click);
            // 
            // Btn_Lisaa
            // 
            this.Btn_Lisaa.Location = new System.Drawing.Point(401, 426);
            this.Btn_Lisaa.Name = "Btn_Lisaa";
            this.Btn_Lisaa.Size = new System.Drawing.Size(142, 22);
            this.Btn_Lisaa.TabIndex = 25;
            this.Btn_Lisaa.Text = "Lisää sana";
            this.Btn_Lisaa.UseVisualStyleBackColor = true;
            this.Btn_Lisaa.Click += new System.EventHandler(this.Btn_Lisaa_Click);
            // 
            // Btn_ppy
            // 
            this.Btn_ppy.Location = new System.Drawing.Point(11, 416);
            this.Btn_ppy.Name = "Btn_ppy";
            this.Btn_ppy.Size = new System.Drawing.Size(104, 23);
            this.Btn_ppy.TabIndex = 24;
            this.Btn_ppy.Text = "PPY";
            this.Btn_ppy.UseVisualStyleBackColor = true;
            // 
            // Btn_Sampo
            // 
            this.Btn_Sampo.Location = new System.Drawing.Point(11, 395);
            this.Btn_Sampo.Name = "Btn_Sampo";
            this.Btn_Sampo.Size = new System.Drawing.Size(104, 23);
            this.Btn_Sampo.TabIndex = 23;
            this.Btn_Sampo.Text = "HankintaSampo";
            this.Btn_Sampo.UseVisualStyleBackColor = true;
            // 
            // Btn_Hilma
            // 
            this.Btn_Hilma.Location = new System.Drawing.Point(459, 3);
            this.Btn_Hilma.Name = "Btn_Hilma";
            this.Btn_Hilma.Size = new System.Drawing.Size(104, 23);
            this.Btn_Hilma.TabIndex = 22;
            this.Btn_Hilma.Text = "HilmaSivu";
            this.Btn_Hilma.UseVisualStyleBackColor = true;
            this.Btn_Hilma.Click += new System.EventHandler(this.Btn_Hilma_Click);
            // 
            // Btn_Tarjouspalvelu
            // 
            this.Btn_Tarjouspalvelu.Location = new System.Drawing.Point(12, 80);
            this.Btn_Tarjouspalvelu.Name = "Btn_Tarjouspalvelu";
            this.Btn_Tarjouspalvelu.Size = new System.Drawing.Size(104, 23);
            this.Btn_Tarjouspalvelu.TabIndex = 21;
            this.Btn_Tarjouspalvelu.Text = "Tarjouspalvelu";
            this.Btn_Tarjouspalvelu.UseVisualStyleBackColor = true;
            this.Btn_Tarjouspalvelu.Click += new System.EventHandler(this.Btn_Tarjouspalvelu_Click);
            // 
            // Btn_PienHankinta
            // 
            this.Btn_PienHankinta.Location = new System.Drawing.Point(12, 51);
            this.Btn_PienHankinta.Name = "Btn_PienHankinta";
            this.Btn_PienHankinta.Size = new System.Drawing.Size(104, 23);
            this.Btn_PienHankinta.TabIndex = 20;
            this.Btn_PienHankinta.Text = "Pienhankinta";
            this.Btn_PienHankinta.UseVisualStyleBackColor = true;
            this.Btn_PienHankinta.Click += new System.EventHandler(this.Btn_PienHankinta_Click);
            // 
            // Lbx_Vahti
            // 
            this.Lbx_Vahti.FormattingEnabled = true;
            this.Lbx_Vahti.Location = new System.Drawing.Point(377, 129);
            this.Lbx_Vahti.Name = "Lbx_Vahti";
            this.Lbx_Vahti.Size = new System.Drawing.Size(186, 290);
            this.Lbx_Vahti.TabIndex = 19;
            // 
            // TB_Kerta
            // 
            this.TB_Kerta.Location = new System.Drawing.Point(379, 93);
            this.TB_Kerta.Name = "TB_Kerta";
            this.TB_Kerta.Size = new System.Drawing.Size(186, 20);
            this.TB_Kerta.TabIndex = 18;
            this.TB_Kerta.TextChanged += new System.EventHandler(this.TB_Kerta_TextChanged);
            // 
            // TbCnt_Vahti
            // 
            this.TbCnt_Vahti.Controls.Add(this.PG_Vahti);
            this.TbCnt_Vahti.Location = new System.Drawing.Point(15, 12);
            this.TbCnt_Vahti.Name = "TbCnt_Vahti";
            this.TbCnt_Vahti.SelectedIndex = 0;
            this.TbCnt_Vahti.Size = new System.Drawing.Size(472, 361);
            this.TbCnt_Vahti.TabIndex = 22;
            // 
            // PG_Vahti
            // 
            this.PG_Vahti.Controls.Add(this.WBPanel);
            this.PG_Vahti.Controls.Add(this.tsWB);
            this.PG_Vahti.Location = new System.Drawing.Point(4, 22);
            this.PG_Vahti.Name = "PG_Vahti";
            this.PG_Vahti.Padding = new System.Windows.Forms.Padding(3);
            this.PG_Vahti.Size = new System.Drawing.Size(464, 335);
            this.PG_Vahti.TabIndex = 0;
            this.PG_Vahti.Text = "WB_Hilma";
            this.PG_Vahti.UseVisualStyleBackColor = true;
            // 
            // WBPanel
            // 
            this.WBPanel.Controls.Add(this.WBrHilma2);
            this.WBPanel.Controls.Add(this.WBrHilma);
            this.WBPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WBPanel.Location = new System.Drawing.Point(3, 28);
            this.WBPanel.Name = "WBPanel";
            this.WBPanel.Size = new System.Drawing.Size(458, 304);
            this.WBPanel.TabIndex = 12;
            // 
            // tsWB
            // 
            this.tsWB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSep,
            this.toolStripSeparator2,
            this.tsDDBtn_Kiinnostus,
            this.TSCmBx_Kiinnostus,
            this.TSTXBX_Palkki});
            this.tsWB.Location = new System.Drawing.Point(3, 3);
            this.tsWB.Name = "tsWB";
            this.tsWB.Size = new System.Drawing.Size(458, 25);
            this.tsWB.TabIndex = 11;
            this.tsWB.Text = "tsTab";
            // 
            // TSSep
            // 
            this.TSSep.Name = "TSSep";
            this.TSSep.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsDDBtn_Kiinnostus
            // 
            this.tsDDBtn_Kiinnostus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDDBtn_Kiinnostus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.tutkiToolStripMenuItem,
            this.kiinnostavaToolStripMenuItem,
            this.mustToolStripMenuItem});
            this.tsDDBtn_Kiinnostus.Image = ((System.Drawing.Image)(resources.GetObject("tsDDBtn_Kiinnostus.Image")));
            this.tsDDBtn_Kiinnostus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDDBtn_Kiinnostus.Name = "tsDDBtn_Kiinnostus";
            this.tsDDBtn_Kiinnostus.Size = new System.Drawing.Size(80, 22);
            this.tsDDBtn_Kiinnostus.Text = "Kiinstavuus";
            this.tsDDBtn_Kiinnostus.Click += new System.EventHandler(this.tsDDBtn_Kiinnostus_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem1.Text = "0- Ei Kiinnsotaa";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tutkiToolStripMenuItem
            // 
            this.tutkiToolStripMenuItem.Name = "tutkiToolStripMenuItem";
            this.tutkiToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.tutkiToolStripMenuItem.Text = "1- tutki";
            // 
            // kiinnostavaToolStripMenuItem
            // 
            this.kiinnostavaToolStripMenuItem.Name = "kiinnostavaToolStripMenuItem";
            this.kiinnostavaToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.kiinnostavaToolStripMenuItem.Text = "2- kiinnostava";
            // 
            // mustToolStripMenuItem
            // 
            this.mustToolStripMenuItem.Name = "mustToolStripMenuItem";
            this.mustToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.mustToolStripMenuItem.Text = "3 - Must";
            // 
            // TSCmBx_Kiinnostus
            // 
            this.TSCmBx_Kiinnostus.Items.AddRange(new object[] {
            "0 - EiKäsitelty",
            "1 - Ei Kiinnosta",
            "2- Tutkitaan",
            "3 - Ehkä",
            "4 - Must"});
            this.TSCmBx_Kiinnostus.MaxDropDownItems = 5;
            this.TSCmBx_Kiinnostus.Name = "TSCmBx_Kiinnostus";
            this.TSCmBx_Kiinnostus.Size = new System.Drawing.Size(121, 25);
            this.TSCmBx_Kiinnostus.Sorted = true;
            this.TSCmBx_Kiinnostus.Text = "0 - EiKäsitelty";
            // 
            // TSTXBX_Palkki
            // 
            this.TSTXBX_Palkki.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TSTXBX_Palkki.Name = "TSTXBX_Palkki";
            this.TSTXBX_Palkki.Size = new System.Drawing.Size(200, 25);
            this.TSTXBX_Palkki.Text = "A";
            // 
            // RchTxtBx_Vahti
            // 
            this.RchTxtBx_Vahti.AutoWordSelection = true;
            this.RchTxtBx_Vahti.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RchTxtBx_Vahti.Location = new System.Drawing.Point(0, 64);
            this.RchTxtBx_Vahti.Name = "RchTxtBx_Vahti";
            this.RchTxtBx_Vahti.Size = new System.Drawing.Size(508, 375);
            this.RchTxtBx_Vahti.TabIndex = 21;
            this.RchTxtBx_Vahti.Text = "";
            this.RchTxtBx_Vahti.Visible = false;
            this.RchTxtBx_Vahti.SelectionChanged += new System.EventHandler(this.RTxtBx_Vahti_SelectionChanged);
            // 
            // Tmr_SivuVahti
            // 
            this.Tmr_SivuVahti.Tick += new System.EventHandler(this.Tmr_SivuVahti_Tick);
            // 
            // WBrHilma
            // 
            this.WBrHilma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WBrHilma.Location = new System.Drawing.Point(0, 0);
            this.WBrHilma.MinimumSize = new System.Drawing.Size(20, 20);
            this.WBrHilma.Name = "WBrHilma";
            this.WBrHilma.Size = new System.Drawing.Size(458, 304);
            this.WBrHilma.TabIndex = 11;
            // 
            // WBrHilma2
            // 
            this.WBrHilma2.AllowExternalDrop = true;
            this.WBrHilma2.CreationProperties = null;
            this.WBrHilma2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.WBrHilma2.Location = new System.Drawing.Point(-3, 3);
            this.WBrHilma2.Name = "WBrHilma2";
            this.WBrHilma2.Size = new System.Drawing.Size(336, 288);
            this.WBrHilma2.TabIndex = 12;
            this.WBrHilma2.ZoomFactor = 1D;
            // 
            // Frm_Vahti_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 570);
            this.Controls.Add(this.SplCnt_Vahti);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Frm_Vahti_Main";
            this.Text = "Frm_Vahti_Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Vahti_Main_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Vahti_Main_Load);
            this.Shown += new System.EventHandler(this.Frm_Vahti_Main_Shown);
            this.SizeChanged += new System.EventHandler(this.Frm_Vahti_Main_SizeChanged);
            this.Resize += new System.EventHandler(this.Frm_Vahti_Main_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.SplCnt_Vahti.Panel1.ResumeLayout(false);
            this.SplCnt_Vahti.Panel1.PerformLayout();
            this.SplCnt_Vahti.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplCnt_Vahti)).EndInit();
            this.SplCnt_Vahti.ResumeLayout(false);
            this.TbCnt_Vahti.ResumeLayout(false);
            this.PG_Vahti.ResumeLayout(false);
            this.PG_Vahti.PerformLayout();
            this.WBPanel.ResumeLayout(false);
            this.tsWB.ResumeLayout(false);
            this.tsWB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WBrHilma2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private PienHankinta clPienHankinta;
        private TarjousPalvelu clTarjouspalvelu;

        private Hilma clHilma;
        private Tulostukset ClPrintti;
        private System.Collections.Generic.List<System.Windows.Forms.WebBrowser> lstBrowsers;
        private System.Collections.Generic.List<string> lstHilmaWebPages;
        private System.Windows.Forms.Timer Tmr_Vahti;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar TSSttsBr_Vahti;
        private System.Windows.Forms.SplitContainer SplCnt_Vahti;
        private System.Windows.Forms.Button btn_Rapotti;
        private System.Windows.Forms.Button Btn_Listaa;
        private System.Windows.Forms.Button Btn_Suodata;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Button Btn_JTarj;
        private System.Windows.Forms.CheckBox CBx_Tarjous;
        private System.Windows.Forms.CheckBox CBx_Pien;
        private System.Windows.Forms.CheckBox CBx_Hilma;
        private System.Windows.Forms.Button Btn_HilmaData;
        private System.Windows.Forms.Label lbl_Tarjouksia;
        private System.Windows.Forms.Button btn_tarjouksia;
        private System.Windows.Forms.Button Btn_Lisaa;
        private System.Windows.Forms.Button Btn_ppy;
        private System.Windows.Forms.Button Btn_Sampo;
        private System.Windows.Forms.Button Btn_Hilma;
        private System.Windows.Forms.Button Btn_Tarjouspalvelu;
        private System.Windows.Forms.Button Btn_PienHankinta;
        private System.Windows.Forms.ListBox Lbx_Vahti;
        private System.Windows.Forms.TextBox TB_Kerta;
        private System.Windows.Forms.RichTextBox RchTxtBx_Vahti;
        private System.Windows.Forms.ToolStripStatusLabel TsStpLbl_Vahti;
        private System.Windows.Forms.CheckedListBox chkbxlst_VahtiSanat;
        private System.Windows.Forms.Button Btn_Erotele_Sanat;
        private System.Windows.Forms.ToolStripStatusLabel TsStsLbl_Vahti_ToDo;
        private System.Windows.Forms.Button Btn_Kuvaus;
        private System.Windows.Forms.Timer Tmr_SivuVahti;
        private System.Windows.Forms.TabControl TbCnt_Vahti;
        private System.Windows.Forms.TabPage PG_Vahti;
        private System.Windows.Forms.TextBox TxtTrace;
        private System.Windows.Forms.CheckBox ChckBx_Uusi;
        private System.Windows.Forms.Button btn_Kasittele;
        private System.Windows.Forms.Button Btn_TalletaRaportti;
        private System.Windows.Forms.Panel WBPanel;
        private System.Windows.Forms.ToolStrip tsWB;
        private System.Windows.Forms.ToolStripSeparator TSSep;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btn_EiKiinnosta;
        private System.Windows.Forms.Button btn_All;
        private System.Windows.Forms.CheckBox CBx_ID;
        private System.Windows.Forms.ToolStripDropDownButton tsDDBtn_Kiinnostus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tutkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kiinnostavaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mustToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox TSCmBx_Kiinnostus;
        private System.Windows.Forms.ToolStripTextBox TSTXBX_Palkki;
        private System.Windows.Forms.Button button1;
        private Microsoft.Web.WebView2.WinForms.WebView2 WBrHilma2;
        private System.Windows.Forms.WebBrowser WBrHilma;
    }
}