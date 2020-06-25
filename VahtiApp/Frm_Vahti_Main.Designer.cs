

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
            this.Btn_PienHankinta = new System.Windows.Forms.Button();
            this.Btn_Tarjouspalvelu = new System.Windows.Forms.Button();
            this.Btn_Hilma = new System.Windows.Forms.Button();
            this.Btn_Hanki = new System.Windows.Forms.Button();
            this.Btn_ppy = new System.Windows.Forms.Button();
            this.Btn_Load = new System.Windows.Forms.Button();
            this.btn_tarjouksia = new System.Windows.Forms.Button();
            this.lbl_Tarjouksia = new System.Windows.Forms.Label();
            
            this.SuspendLayout();
            // 
            // Btn_PienHankinta
            // 
            this.Btn_PienHankinta.Location = new System.Drawing.Point(55, 57);
            this.Btn_PienHankinta.Name = "Btn_PienHankinta";
            this.Btn_PienHankinta.Size = new System.Drawing.Size(104, 23);
            this.Btn_PienHankinta.TabIndex = 0;
            this.Btn_PienHankinta.Text = "Pienhankinta";
            this.Btn_PienHankinta.UseVisualStyleBackColor = true;
            this.Btn_PienHankinta.Click += new System.EventHandler(this.Btn_PienHankinta_Click);
            // 
            // Btn_Tarjouspalvelu
            // 
            this.Btn_Tarjouspalvelu.Location = new System.Drawing.Point(55, 106);
            this.Btn_Tarjouspalvelu.Name = "Btn_Tarjouspalvelu";
            this.Btn_Tarjouspalvelu.Size = new System.Drawing.Size(104, 23);
            this.Btn_Tarjouspalvelu.TabIndex = 1;
            this.Btn_Tarjouspalvelu.Text = "Tarjouspalvelu";
            this.Btn_Tarjouspalvelu.UseVisualStyleBackColor = true;
            this.Btn_Tarjouspalvelu.Click += new System.EventHandler(this.Btn_Tarjouspalvelu_Click);
            // 
            // Btn_Hilma
            // 
            this.Btn_Hilma.Location = new System.Drawing.Point(55, 155);
            this.Btn_Hilma.Name = "Btn_Hilma";
            this.Btn_Hilma.Size = new System.Drawing.Size(104, 23);
            this.Btn_Hilma.TabIndex = 2;
            this.Btn_Hilma.Text = "Hilma";
            this.Btn_Hilma.UseVisualStyleBackColor = true;
            // 
            // Btn_Hanki
            // 
            this.Btn_Hanki.Location = new System.Drawing.Point(55, 216);
            this.Btn_Hanki.Name = "Btn_Hanki";
            this.Btn_Hanki.Size = new System.Drawing.Size(104, 23);
            this.Btn_Hanki.TabIndex = 3;
            this.Btn_Hanki.Text = "Hanki";
            this.Btn_Hanki.UseVisualStyleBackColor = true;
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
            this.Btn_Load.Location = new System.Drawing.Point(211, 57);
            this.Btn_Load.Name = "Btn_Load";
            this.Btn_Load.Size = new System.Drawing.Size(139, 22);
            this.Btn_Load.TabIndex = 5;
            this.Btn_Load.Text = "Lataa";
            this.Btn_Load.UseVisualStyleBackColor = true;
            this.Btn_Load.Click += new System.EventHandler(this.Btn_Load_Click);
            // 
            // btn_tarjouksia
            // 
            this.btn_tarjouksia.Location = new System.Drawing.Point(629, 57);
            this.btn_tarjouksia.Name = "btn_tarjouksia";
            this.btn_tarjouksia.Size = new System.Drawing.Size(113, 23);
            this.btn_tarjouksia.TabIndex = 6;
            this.btn_tarjouksia.Text = "Tarjouksia";
            this.btn_tarjouksia.UseVisualStyleBackColor = true;
            this.btn_tarjouksia.Click += new System.EventHandler(this.btn_tarjouksia_Click);
            // 
            // lbl_Tarjouksia
            // 
            this.lbl_Tarjouksia.AutoSize = true;
            this.lbl_Tarjouksia.Location = new System.Drawing.Point(629, 38);
            this.lbl_Tarjouksia.Name = "lbl_Tarjouksia";
            this.lbl_Tarjouksia.Size = new System.Drawing.Size(13, 13);
            this.lbl_Tarjouksia.TabIndex = 7;
            this.lbl_Tarjouksia.Text = "0";
           
            
            // 
            // Frm_Vahti_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            
            this.Controls.Add(this.lbl_Tarjouksia);
            this.Controls.Add(this.btn_tarjouksia);
            this.Controls.Add(this.Btn_Load);
            this.Controls.Add(this.Btn_ppy);
            this.Controls.Add(this.Btn_Hanki);
            this.Controls.Add(this.Btn_Hilma);
            this.Controls.Add(this.Btn_Tarjouspalvelu);
            this.Controls.Add(this.Btn_PienHankinta);
            this.Name = "Frm_Vahti_Main";
            this.Text = "Frm_Vahti_Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Collections.Generic.List<Tarjous> lstKaikkiTajoukset;
        private System.Windows.Forms.Button Btn_PienHankinta;
        private System.Windows.Forms.Button Btn_Tarjouspalvelu;
        private System.Windows.Forms.Button Btn_Hilma;
        private System.Windows.Forms.Button Btn_Hanki;
        private System.Windows.Forms.Button Btn_ppy;
        private System.Windows.Forms.Button Btn_Load;
        private System.Windows.Forms.Button btn_tarjouksia;
        private System.Windows.Forms.Label lbl_Tarjouksia;
        private PienHankinta clPienHankinta;
        private TarjousPalvelu clTarjouspalvelu;
        private System.Collections.Generic.List<System.Windows.Forms.WebBrowser> lstBrowsers;

    }
}