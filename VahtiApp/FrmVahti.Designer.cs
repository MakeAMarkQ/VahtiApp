namespace VahtiApp
{
    partial class FrmVahti
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.MS_Vahti = new System.Windows.Forms.MenuStrip();
            this.TSMI_Tiedosto = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIA_UudetTarjoukset = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIA_Etusivut = new System.Windows.Forms.ToolStripMenuItem();
            this.TSC_Vahti = new System.Windows.Forms.ToolStripContainer();
            this.RTbx_VahtiLog = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.TS_Vahti = new System.Windows.Forms.ToolStrip();
            this.CMS_Vahti = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIA_Lopeta = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Asetukset = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_Vahti.SuspendLayout();
            this.TSC_Vahti.ContentPanel.SuspendLayout();
            this.TSC_Vahti.TopToolStripPanel.SuspendLayout();
            this.TSC_Vahti.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(452, 299);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(452, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(452, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(617, 76);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(115, 260);
            this.webBrowser1.TabIndex = 3;
            // 
            // MS_Vahti
            // 
            this.MS_Vahti.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Tiedosto,
            this.TSMI_Asetukset});
            this.MS_Vahti.Location = new System.Drawing.Point(0, 0);
            this.MS_Vahti.Name = "MS_Vahti";
            this.MS_Vahti.Size = new System.Drawing.Size(785, 24);
            this.MS_Vahti.TabIndex = 4;
            this.MS_Vahti.Text = "menuStrip1";
            // 
            // TSMI_Tiedosto
            // 
            this.TSMI_Tiedosto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIA_UudetTarjoukset,
            this.TSMIA_Etusivut,
            this.TSMIA_Lopeta});
            this.TSMI_Tiedosto.Name = "TSMI_Tiedosto";
            this.TSMI_Tiedosto.Size = new System.Drawing.Size(64, 20);
            this.TSMI_Tiedosto.Text = "&Tiedosto";
            // 
            // TSMIA_UudetTarjoukset
            // 
            this.TSMIA_UudetTarjoukset.Name = "TSMIA_UudetTarjoukset";
            this.TSMIA_UudetTarjoukset.Size = new System.Drawing.Size(180, 22);
            this.TSMIA_UudetTarjoukset.Text = "&Uudet tarjoukset";
            // 
            // TSMIA_Etusivut
            // 
            this.TSMIA_Etusivut.Name = "TSMIA_Etusivut";
            this.TSMIA_Etusivut.Size = new System.Drawing.Size(180, 22);
            this.TSMIA_Etusivut.Text = "&Etusivu tarkistus";
            this.TSMIA_Etusivut.Click += new System.EventHandler(this.TSMIA_Etusivut_Click);
            // 
            // TSC_Vahti
            // 
            // 
            // TSC_Vahti.ContentPanel
            // 
            this.TSC_Vahti.ContentPanel.Controls.Add(this.RTbx_VahtiLog);
            this.TSC_Vahti.ContentPanel.Controls.Add(this.button3);
            this.TSC_Vahti.ContentPanel.Controls.Add(this.webBrowser1);
            this.TSC_Vahti.ContentPanel.Controls.Add(this.button2);
            this.TSC_Vahti.ContentPanel.Controls.Add(this.button1);
            this.TSC_Vahti.ContentPanel.Controls.Add(this.textBox1);
            this.TSC_Vahti.ContentPanel.Size = new System.Drawing.Size(785, 411);
            this.TSC_Vahti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TSC_Vahti.Location = new System.Drawing.Point(0, 24);
            this.TSC_Vahti.Name = "TSC_Vahti";
            this.TSC_Vahti.Size = new System.Drawing.Size(785, 436);
            this.TSC_Vahti.TabIndex = 5;
            this.TSC_Vahti.Text = "toolStripContainer1";
            // 
            // TSC_Vahti.TopToolStripPanel
            // 
            this.TSC_Vahti.TopToolStripPanel.Controls.Add(this.TS_Vahti);
            // 
            // RTbx_VahtiLog
            // 
            this.RTbx_VahtiLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.RTbx_VahtiLog.Location = new System.Drawing.Point(0, 0);
            this.RTbx_VahtiLog.Name = "RTbx_VahtiLog";
            this.RTbx_VahtiLog.Size = new System.Drawing.Size(282, 411);
            this.RTbx_VahtiLog.TabIndex = 4;
            this.RTbx_VahtiLog.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(452, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // TS_Vahti
            // 
            this.TS_Vahti.Dock = System.Windows.Forms.DockStyle.None;
            this.TS_Vahti.Location = new System.Drawing.Point(3, 0);
            this.TS_Vahti.Name = "TS_Vahti";
            this.TS_Vahti.Size = new System.Drawing.Size(111, 25);
            this.TS_Vahti.TabIndex = 0;
            // 
            // CMS_Vahti
            // 
            this.CMS_Vahti.Name = "CMS_Vahti";
            this.CMS_Vahti.Size = new System.Drawing.Size(61, 4);
            // 
            // TSMIA_Lopeta
            // 
            this.TSMIA_Lopeta.Name = "TSMIA_Lopeta";
            this.TSMIA_Lopeta.Size = new System.Drawing.Size(180, 22);
            this.TSMIA_Lopeta.Text = "&Lopeta";
            // 
            // TSMI_Asetukset
            // 
            this.TSMI_Asetukset.Name = "TSMI_Asetukset";
            this.TSMI_Asetukset.Size = new System.Drawing.Size(70, 20);
            this.TSMI_Asetukset.Text = "&Asetukset";
            // 
            // FrmVahti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 460);
            this.Controls.Add(this.TSC_Vahti);
            this.Controls.Add(this.MS_Vahti);
            this.MainMenuStrip = this.MS_Vahti;
            this.Name = "FrmVahti";
            this.Text = "InnoOk:n VahtiHaukka";
            this.Shown += new System.EventHandler(this.FrmVahti_Shown);
            this.MS_Vahti.ResumeLayout(false);
            this.MS_Vahti.PerformLayout();
            this.TSC_Vahti.ContentPanel.ResumeLayout(false);
            this.TSC_Vahti.ContentPanel.PerformLayout();
            this.TSC_Vahti.TopToolStripPanel.ResumeLayout(false);
            this.TSC_Vahti.TopToolStripPanel.PerformLayout();
            this.TSC_Vahti.ResumeLayout(false);
            this.TSC_Vahti.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.MenuStrip MS_Vahti;
        private System.Windows.Forms.ToolStripContainer TSC_Vahti;
        private System.Windows.Forms.ToolStrip TS_Vahti;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip CMS_Vahti;
        private System.Windows.Forms.RichTextBox RTbx_VahtiLog;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Tiedosto;
        private System.Windows.Forms.ToolStripMenuItem TSMIA_UudetTarjoukset;
        private System.Windows.Forms.ToolStripMenuItem TSMIA_Etusivut;
        private System.Windows.Forms.ToolStripMenuItem TSMIA_Lopeta;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Asetukset;
    }
}

