

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
            this.Btn_PienHankinta = new System.Windows.Forms.Button();
            this.Btn_Tarjouspalvelu = new System.Windows.Forms.Button();
            this.Btn_Hilma = new System.Windows.Forms.Button();
            this.Btn_Sampo = new System.Windows.Forms.Button();
            this.Btn_ppy = new System.Windows.Forms.Button();
            this.Btn_Load = new System.Windows.Forms.Button();
            this.btn_tarjouksia = new System.Windows.Forms.Button();
            this.lbl_Tarjouksia = new System.Windows.Forms.Label();
            this.WBrHilma = new System.Windows.Forms.WebBrowser();
            this.TB_Kerta = new System.Windows.Forms.TextBox();
            this.Btn_HilmaData = new System.Windows.Forms.Button();
            this.CBx_Hilma = new System.Windows.Forms.CheckBox();
            this.CBx_Pien = new System.Windows.Forms.CheckBox();
            this.CBx_Tarjous = new System.Windows.Forms.CheckBox();
            this.Tmr_Vahti = new System.Windows.Forms.Timer(this.components);
            this.Btn_JTarj = new System.Windows.Forms.Button();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.Btn_Suodata = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_PienHankinta
            // 
            this.Btn_PienHankinta.Location = new System.Drawing.Point(21, 59);
            this.Btn_PienHankinta.Name = "Btn_PienHankinta";
            this.Btn_PienHankinta.Size = new System.Drawing.Size(104, 23);
            this.Btn_PienHankinta.TabIndex = 0;
            this.Btn_PienHankinta.Text = "Pienhankinta";
            this.Btn_PienHankinta.UseVisualStyleBackColor = true;
            this.Btn_PienHankinta.Click += new System.EventHandler(this.Btn_PienHankinta_Click);
            // 
            // Btn_Tarjouspalvelu
            // 
            this.Btn_Tarjouspalvelu.Location = new System.Drawing.Point(21, 88);
            this.Btn_Tarjouspalvelu.Name = "Btn_Tarjouspalvelu";
            this.Btn_Tarjouspalvelu.Size = new System.Drawing.Size(104, 23);
            this.Btn_Tarjouspalvelu.TabIndex = 1;
            this.Btn_Tarjouspalvelu.Text = "Tarjouspalvelu";
            this.Btn_Tarjouspalvelu.UseVisualStyleBackColor = true;
            this.Btn_Tarjouspalvelu.Click += new System.EventHandler(this.Btn_Tarjouspalvelu_Click);
            // 
            // Btn_Hilma
            // 
            this.Btn_Hilma.Enabled = false;
            this.Btn_Hilma.Location = new System.Drawing.Point(55, 425);
            this.Btn_Hilma.Name = "Btn_Hilma";
            this.Btn_Hilma.Size = new System.Drawing.Size(104, 23);
            this.Btn_Hilma.TabIndex = 2;
            this.Btn_Hilma.Text = "HilmaSivu";
            this.Btn_Hilma.UseVisualStyleBackColor = true;
            this.Btn_Hilma.Click += new System.EventHandler(this.Btn_Hilma_Click);
            // 
            // Btn_Sampo
            // 
            this.Btn_Sampo.Location = new System.Drawing.Point(55, 229);
            this.Btn_Sampo.Name = "Btn_Sampo";
            this.Btn_Sampo.Size = new System.Drawing.Size(104, 23);
            this.Btn_Sampo.TabIndex = 3;
            this.Btn_Sampo.Text = "HankintaSampo";
            this.Btn_Sampo.UseVisualStyleBackColor = true;
            // 
            // Btn_ppy
            // 
            this.Btn_ppy.Location = new System.Drawing.Point(55, 276);
            this.Btn_ppy.Name = "Btn_ppy";
            this.Btn_ppy.Size = new System.Drawing.Size(104, 23);
            this.Btn_ppy.TabIndex = 4;
            this.Btn_ppy.Text = "PPY";
            this.Btn_ppy.UseVisualStyleBackColor = true;
            // 
            // Btn_Load
            // 
            this.Btn_Load.Location = new System.Drawing.Point(211, 425);
            this.Btn_Load.Name = "Btn_Load";
            this.Btn_Load.Size = new System.Drawing.Size(142, 22);
            this.Btn_Load.TabIndex = 5;
            this.Btn_Load.Text = "Lataa Filters";
            this.Btn_Load.UseVisualStyleBackColor = true;
            this.Btn_Load.Click += new System.EventHandler(this.Btn_Load_Click);
            // 
            // btn_tarjouksia
            // 
            this.btn_tarjouksia.Location = new System.Drawing.Point(211, 229);
            this.btn_tarjouksia.Name = "btn_tarjouksia";
            this.btn_tarjouksia.Size = new System.Drawing.Size(142, 23);
            this.btn_tarjouksia.TabIndex = 6;
            this.btn_tarjouksia.Text = "Tarjouksia";
            this.btn_tarjouksia.UseVisualStyleBackColor = true;
            this.btn_tarjouksia.Click += new System.EventHandler(this.btn_tarjouksia_Click);
            // 
            // lbl_Tarjouksia
            // 
            this.lbl_Tarjouksia.AutoSize = true;
            this.lbl_Tarjouksia.Location = new System.Drawing.Point(208, 192);
            this.lbl_Tarjouksia.Name = "lbl_Tarjouksia";
            this.lbl_Tarjouksia.Size = new System.Drawing.Size(13, 13);
            this.lbl_Tarjouksia.TabIndex = 7;
            this.lbl_Tarjouksia.Text = "0";
            // 
            // WBrHilma
            // 
            this.WBrHilma.Location = new System.Drawing.Point(568, 151);
            this.WBrHilma.MinimumSize = new System.Drawing.Size(20, 20);
            this.WBrHilma.Name = "WBrHilma";
            this.WBrHilma.Size = new System.Drawing.Size(587, 314);
            this.WBrHilma.TabIndex = 8;
            // 
            // TB_Kerta
            // 
            this.TB_Kerta.Location = new System.Drawing.Point(456, 59);
            this.TB_Kerta.Name = "TB_Kerta";
            this.TB_Kerta.Size = new System.Drawing.Size(100, 20);
            this.TB_Kerta.TabIndex = 9;
            // 
            // Btn_HilmaData
            // 
            this.Btn_HilmaData.Location = new System.Drawing.Point(21, 30);
            this.Btn_HilmaData.Name = "Btn_HilmaData";
            this.Btn_HilmaData.Size = new System.Drawing.Size(104, 23);
            this.Btn_HilmaData.TabIndex = 10;
            this.Btn_HilmaData.Text = "Hilmalta";
            this.Btn_HilmaData.UseVisualStyleBackColor = true;
            this.Btn_HilmaData.Click += new System.EventHandler(this.Btn_HilmaData_Click);
            // 
            // CBx_Hilma
            // 
            this.CBx_Hilma.AutoSize = true;
            this.CBx_Hilma.Location = new System.Drawing.Point(131, 34);
            this.CBx_Hilma.Name = "CBx_Hilma";
            this.CBx_Hilma.Size = new System.Drawing.Size(52, 17);
            this.CBx_Hilma.TabIndex = 11;
            this.CBx_Hilma.Text = "Hilma";
            this.CBx_Hilma.UseVisualStyleBackColor = true;
            // 
            // CBx_Pien
            // 
            this.CBx_Pien.AutoSize = true;
            this.CBx_Pien.Location = new System.Drawing.Point(131, 62);
            this.CBx_Pien.Name = "CBx_Pien";
            this.CBx_Pien.Size = new System.Drawing.Size(47, 17);
            this.CBx_Pien.TabIndex = 12;
            this.CBx_Pien.Text = "Pien";
            this.CBx_Pien.UseVisualStyleBackColor = true;
            // 
            // CBx_Tarjous
            // 
            this.CBx_Tarjous.AutoSize = true;
            this.CBx_Tarjous.Location = new System.Drawing.Point(131, 92);
            this.CBx_Tarjous.Name = "CBx_Tarjous";
            this.CBx_Tarjous.Size = new System.Drawing.Size(61, 17);
            this.CBx_Tarjous.TabIndex = 13;
            this.CBx_Tarjous.Text = "Tarjous";
            this.CBx_Tarjous.UseVisualStyleBackColor = true;
            // 
            // Tmr_Vahti
            // 
            this.Tmr_Vahti.Tick += new System.EventHandler(this.Tmr_Vahti_Tick);
            // 
            // Btn_JTarj
            // 
            this.Btn_JTarj.Location = new System.Drawing.Point(211, 72);
            this.Btn_JTarj.Name = "Btn_JTarj";
            this.Btn_JTarj.Size = new System.Drawing.Size(142, 20);
            this.Btn_JTarj.TabIndex = 14;
            this.Btn_JTarj.Text = "Tallenna";
            this.Btn_JTarj.UseVisualStyleBackColor = true;
            this.Btn_JTarj.Click += new System.EventHandler(this.Btn_JTarj_Click);
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Location = new System.Drawing.Point(18, 114);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(51, 13);
            this.lbl_timer.TabIndex = 15;
            this.lbl_timer.Text = "Tirer stop";
            // 
            // Btn_Suodata
            // 
            this.Btn_Suodata.Location = new System.Drawing.Point(211, 355);
            this.Btn_Suodata.Name = "Btn_Suodata";
            this.Btn_Suodata.Size = new System.Drawing.Size(142, 22);
            this.Btn_Suodata.TabIndex = 16;
            this.Btn_Suodata.Text = "Suodata";
            this.Btn_Suodata.UseVisualStyleBackColor = true;
            this.Btn_Suodata.Click += new System.EventHandler(this.Btn_Suodata_Click);
            // 
            // Frm_Vahti_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 461);
            this.Controls.Add(this.Btn_Suodata);
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.Btn_JTarj);
            this.Controls.Add(this.CBx_Tarjous);
            this.Controls.Add(this.CBx_Pien);
            this.Controls.Add(this.CBx_Hilma);
            this.Controls.Add(this.Btn_HilmaData);
            this.Controls.Add(this.TB_Kerta);
            this.Controls.Add(this.WBrHilma);
            this.Controls.Add(this.lbl_Tarjouksia);
            this.Controls.Add(this.btn_tarjouksia);
            this.Controls.Add(this.Btn_Load);
            this.Controls.Add(this.Btn_ppy);
            this.Controls.Add(this.Btn_Sampo);
            this.Controls.Add(this.Btn_Hilma);
            this.Controls.Add(this.Btn_Tarjouspalvelu);
            this.Controls.Add(this.Btn_PienHankinta);
            this.Name = "Frm_Vahti_Main";
            this.Text = "Frm_Vahti_Main";
            this.Shown += new System.EventHandler(this.Frm_Vahti_Main_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Collections.Generic.List<Tarjous> lstKaikkiTajoukset;
        private System.Windows.Forms.Button Btn_PienHankinta;
        private System.Windows.Forms.Button Btn_Tarjouspalvelu;
        private System.Windows.Forms.Button Btn_Hilma;
        private System.Windows.Forms.Button Btn_Sampo;
        private System.Windows.Forms.Button Btn_ppy;
        private System.Windows.Forms.Button Btn_Load;
        private System.Windows.Forms.Button btn_tarjouksia;
        private System.Windows.Forms.Label lbl_Tarjouksia;
        private PienHankinta clPienHankinta;
        private TarjousPalvelu clTarjouspalvelu;
        private Hilma clHilma;
        private System.Collections.Generic.List<System.Windows.Forms.WebBrowser> lstBrowsers;
        private System.Windows.Forms.WebBrowser WBrHilma;
        private System.Windows.Forms.TextBox TB_Kerta;
        private System.Windows.Forms.Button Btn_HilmaData;
        private System.Windows.Forms.CheckBox CBx_Hilma;
        private System.Windows.Forms.CheckBox CBx_Pien;
        private System.Windows.Forms.CheckBox CBx_Tarjous;
        private System.Windows.Forms.Timer Tmr_Vahti;
        private System.Windows.Forms.Button Btn_JTarj;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Button Btn_Suodata;
    }
}