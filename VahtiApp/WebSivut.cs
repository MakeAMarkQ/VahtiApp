using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VahtiApp
{
    class WebSivut
    {
        private string StrKiinnostus;
        private List<Tarjous> lstTarjous;
        private WebBrowser wb;
        private ToolStripTextBox TSTxtBx_Kommentti;
        private ToolStripDropDownButton tsDDBtn_Kiinnostus;
        private ToolStripMenuItem TSMI_0_Tuntematon;
        private ToolStripMenuItem TSMI_1_Ei;
        private ToolStripMenuItem TSMI_2_Tutki;
        private ToolStripMenuItem TSMI_3_Ehkä;
        private ToolStripMenuItem TSMI_4_Must;
        int id;
        //TarjousManager TrjMng;
        public WebSivut()
        {
            wb = new WebBrowser();
            //TrjMng = new TarjousManager();
            //lstTarjous=TrjMng.HaeLista();
        }
        public TabPage LuoSivu(List<Tarjous> inTarjous, int inTarjNro)
        {
            lstTarjous = inTarjous;
            id = lstTarjous[inTarjNro].iTarjNro;
            ToolStripButton tsbtn_Hilma = new ToolStripButton();
            tsbtn_Hilma.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tsbtn_Hilma.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbtn_Hilma.Name = "tsbtn_Hilma";
            tsbtn_Hilma.Size = new System.Drawing.Size(43, 22);
            tsbtn_Hilma.Text = "Hilma";

            tsbtn_Hilma.Click += new System.EventHandler(H_tsbtn_Hilma_Click);
            ToolStripButton tsbtn_PienT = new ToolStripButton();
            tsbtn_PienT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tsbtn_PienT.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbtn_PienT.Name = "tsbtn_PienT";
            tsbtn_PienT.Size = new System.Drawing.Size(43, 22);
            tsbtn_PienT.Text = "Pien";
            tsbtn_PienT.Click += new System.EventHandler(H_tsbtn_Pien_Click);
            ToolStripButton tsbtn_Tarjous = new ToolStripButton();
            tsbtn_Tarjous.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tsbtn_Tarjous.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbtn_Tarjous.Name = "tsbtn_Tarjous";
            tsbtn_Tarjous.Size = new System.Drawing.Size(43, 22);
            tsbtn_Tarjous.Text = "Tarjous";
            tsbtn_Tarjous.Click += new System.EventHandler(H_tsbtn_tarjous_Click);
            ToolStripButton tsbtn_EiKiinnosta = new ToolStripButton();
            tsbtn_EiKiinnosta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tsbtn_EiKiinnosta.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbtn_EiKiinnosta.Name = "tsbtn_EiKiinnosta";
            tsbtn_EiKiinnosta.Size = new System.Drawing.Size(43, 22);
            tsbtn_EiKiinnosta.Text = "EiKiinnosta";
            tsbtn_EiKiinnosta.Click += new System.EventHandler(H_tsbtn_EiKiinnosta_tarjous_Click);
            ToolStripButton tsbtn_Paste = new ToolStripButton();
            tsbtn_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tsbtn_Paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbtn_Paste.Name = "tsbtn_Paste";
            tsbtn_Paste.Size = new System.Drawing.Size(43, 22);
            tsbtn_Paste.Text = "Liitä";
            tsbtn_Paste.Click += new System.EventHandler(H_tsbtn_Paste_tarjous_Click);
            ToolStripSeparator TSSep = new ToolStripSeparator();
            TSSep.Name = "TSSep";
            TSSep.Size = new System.Drawing.Size(6, 25);
            //toolstriptextbox Kommentti

            // 
            // TSTxtBx_Kommentti
            // 
            TSTxtBx_Kommentti = new ToolStripTextBox();
            TSTxtBx_Kommentti.Font = new System.Drawing.Font("Segoe UI", 9F);
            TSTxtBx_Kommentti.Name = "TSTxtBx_Kommentti";
            TSTxtBx_Kommentti.Size = new System.Drawing.Size(100, 25);
            TSTxtBx_Kommentti.Text = "N/A";

            //Kiinnostus
            tsDDBtn_Kiinnostus = new ToolStripDropDownButton();
            TSMI_0_Tuntematon = new ToolStripMenuItem();
            TSMI_1_Ei = new ToolStripMenuItem();
            TSMI_2_Tutki = new ToolStripMenuItem();
            TSMI_3_Ehkä = new ToolStripMenuItem();
            TSMI_4_Must = new ToolStripMenuItem();
            // 
            // toolStripMenuItem1
            // 
            TSMI_0_Tuntematon.Name = "TSMI_0_Tuntematon";
            TSMI_0_Tuntematon.Size = new System.Drawing.Size(180, 22);
            TSMI_0_Tuntematon.Text = "0 - Tuntematon";

            // 
            // toolStripMenuItem1
            // 
            TSMI_1_Ei.Name = "TSMI_1_Ei";
            TSMI_1_Ei.Size = new System.Drawing.Size(180, 22);
            TSMI_1_Ei.Text = "1- Ei Kiinnsota";
            TSMI_1_Ei.Click += new System.EventHandler(TSMI_1_Ei_Click);

            // 
            // tutkiToolStripMenuItem
            // 
            TSMI_2_Tutki.Name = "TSMI_2_Tutki";
            TSMI_2_Tutki.Size = new System.Drawing.Size(180, 22);
            TSMI_2_Tutki.Text = "2- tutki";

            // 
            // kiinnostavaToolStripMenuItem
            // 
            TSMI_3_Ehkä.Name = "TSMI_3_Ehkä";
            TSMI_3_Ehkä.Size = new System.Drawing.Size(180, 22);
            TSMI_3_Ehkä.Text = "3- Ehkä";
            // 
            // TSMI_4_Must
            // 
            TSMI_4_Must.Name = "TSMI_4_Must";
            TSMI_4_Must.Size = new System.Drawing.Size(180, 22);
            TSMI_4_Must.Text = "4 - Must";
            TSMI_0_Tuntematon.Click += new System.EventHandler(TSMI_0_Tuntematon_Click);
            TSMI_1_Ei.Click += new System.EventHandler(TSMI_1_Ei_Click);
            TSMI_2_Tutki.Click += new System.EventHandler(TSMI_2_Tutki_Click);
            TSMI_3_Ehkä.Click += new System.EventHandler(TSMI_3_Ehkä_Click);
            TSMI_4_Must.Click += new System.EventHandler(TSMI_4_Must_Click);
            // 
            // tsDDBtn_Kiinnostus
            // 
            tsDDBtn_Kiinnostus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tsDDBtn_Kiinnostus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            TSMI_0_Tuntematon,
            TSMI_1_Ei,
            TSMI_2_Tutki,
            TSMI_3_Ehkä,
            TSMI_4_Must});


            tsDDBtn_Kiinnostus.Name = "tsDDBtn_Kiinnostus";
            tsDDBtn_Kiinnostus.Size = new System.Drawing.Size(80, 22);
            tsDDBtn_Kiinnostus.Text = "Kiinstavuus";
            ToolStrip ts1 = new ToolStrip();
            ts1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                tsbtn_Hilma, TSSep,tsbtn_PienT,
                TSSep,tsbtn_Tarjous, tsbtn_EiKiinnosta,
                TSSep,tsbtn_Paste,TSTxtBx_Kommentti,
                tsDDBtn_Kiinnostus});
            ts1.Location = new System.Drawing.Point(3, 3);
            ts1.Name = "ts1";
            ts1.Size = new System.Drawing.Size(458, 25);
            ts1.TabIndex = 11;
            ts1.Text = "ts1";


            wb.Dock = System.Windows.Forms.DockStyle.Fill;
            string strUri = lstTarjous[inTarjNro].strAlkuperainenLinkki;
            //if (-1 != strUri.IndexOf("TPPerustiedot")) 
            //{ 
            //    strUri = strUri.Replace("TPPerustiedot", "tpTiivistelma"); 
            //}
            wb.Navigate(strUri);

            Panel pnl = new Panel();
            pnl.Controls.Add(wb);
            pnl.Dock = System.Windows.Forms.DockStyle.Fill;

            TabPage tab1 = new TabPage();
            tab1.Controls.Add(pnl);
            tab1.Controls.Add(ts1);

            tab1.Text = lstTarjous[inTarjNro].iTarjNro.ToString();

            return tab1;
        }

        private void H_tsbtn_Hilma_Click(object sender, EventArgs e)
        {
            //string strDoc = wb.Document.DomDocument.ToString();
            string strInner = wb.Document.Body.OuterHtml;
            string strLyhKuv = "lyhyt kuvaus";
            string strhanknim = "hankintanimikkeistö";
            int iLK = strInner.ToLower().LastIndexOf(strLyhKuv);
            int iHN = strInner.ToLower().LastIndexOf(strhanknim);
            if (iHN < iLK)
            {
                iLK = strInner.ToLower().LastIndexOf(strLyhKuv, iHN);
            }
            string strUKuvaus = strInner.Substring(iLK, iHN - iLK);
            strUKuvaus = strUKuvaus.Remove(strUKuvaus.LastIndexOf("<p data"));
            strUKuvaus = strUKuvaus.Remove(0, strUKuvaus.IndexOf("<p data") );
            for (int i = 0; i < TarjousManager.lstKaikkiTajoukset.Count; i++)
            {
                if (TarjousManager.lstKaikkiTajoukset[i].iTarjNro == id)
                {
                    TarjousManager.lstKaikkiTajoukset[i].strKuvaus = strUKuvaus;
                    TarjousManager.lstKaikkiTajoukset[i].strKuvaushaettu = "true";
                    TarjousManager.lstKaikkiTajoukset[i].strKommentti = TSTxtBx_Kommentti.Text;
                    TarjousManager.lstKaikkiTajoukset[i].strKiinnostus= StrKiinnostus;
                    break;
                }
            }
        }

        private void H_tsbtn_Pien_Click(object sender, EventArgs e)
        {
            string strInner = wb.Document.Body.OuterHtml;
            string strLyhKuv = "hankinnan kuvaus";
            string strhanknim = "hankintayksikkö";
            int iLK = strInner.ToLower().LastIndexOf(strLyhKuv);
            int iHN = strInner.ToLower().LastIndexOf(strhanknim);
            string strUKuvaus = strInner.Substring(iLK, iHN - iLK);
            string strStart = "<td>";
            string strEnd = "</td>";
            iLK = strUKuvaus.ToLower().LastIndexOf(strStart);

            strUKuvaus = strUKuvaus.Remove(0, iLK + 4);
            iHN = strUKuvaus.ToLower().LastIndexOf(strEnd);
            strUKuvaus = strUKuvaus.Remove(iHN);
            for (int i = 0; i < TarjousManager.lstKaikkiTajoukset.Count; i++)
            {
                if (TarjousManager.lstKaikkiTajoukset[i].iTarjNro == id)
                {
                    TarjousManager.lstKaikkiTajoukset[i].strKuvaus = strUKuvaus;
                    TarjousManager.lstKaikkiTajoukset[i].strKuvaushaettu = "true";
                    TarjousManager.lstKaikkiTajoukset[i].strKommentti = TSTxtBx_Kommentti.Text;
                    TarjousManager.lstKaikkiTajoukset[i].strKiinnostus = StrKiinnostus;
                    break;
                }
            }

        }

        private void H_tsbtn_tarjous_Click(object sender, EventArgs e)
        {
            


        }
        private void H_tsbtn_EiKiinnosta_tarjous_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < TarjousManager.lstKaikkiTajoukset.Count; i++)
            {
                if (TarjousManager.lstKaikkiTajoukset[i].iTarjNro == id)
                {

                    TarjousManager.lstKaikkiTajoukset[i].strKuvaushaettu = "true";
                    TarjousManager.lstKaikkiTajoukset[i].strFiltered = "true";
                    TarjousManager.lstKaikkiTajoukset[i].strKommentti = TSTxtBx_Kommentti.Text;
                    TarjousManager.lstKaikkiTajoukset[i].strKiinnostus = StrKiinnostus;

                    break;
                }
            }
        }
        private void H_tsbtn_Paste_tarjous_Click(object sender, EventArgs e)
        {
            string txt = wb.DocumentText;
            string strUKuvaus = Clipboard.GetText();
            strUKuvaus = strUKuvaus.Replace("\n", "<br>\n");
            for (int i = 0; i < TarjousManager.lstKaikkiTajoukset.Count; i++)
            {
                if (TarjousManager.lstKaikkiTajoukset[i].iTarjNro == id)
                {
                    TarjousManager.lstKaikkiTajoukset[i].strKuvaus = strUKuvaus;
                    TarjousManager.lstKaikkiTajoukset[i].strKuvaushaettu = "true";
                    TarjousManager.lstKaikkiTajoukset[i].strKommentti = TSTxtBx_Kommentti.Text;
                    TarjousManager.lstKaikkiTajoukset[i].strKiinnostus = StrKiinnostus;
                    break;
                }
            }
        }
        private void TSMI_0_Tuntematon_Click(object sender, EventArgs e)
        {
            StrKiinnostus = 0.ToString();
        }
        private void TSMI_1_Ei_Click(object sender, EventArgs e)
        {
            StrKiinnostus = 1.ToString();
        }
        private void TSMI_2_Tutki_Click(object sender, EventArgs e)
        {
            StrKiinnostus = 2.ToString();
        }
        private void TSMI_3_Ehkä_Click(object sender, EventArgs e)
        {
            StrKiinnostus = 3.ToString();
        }
        private void TSMI_4_Must_Click(object sender, EventArgs e)
        {
            StrKiinnostus = 4.ToString();
        }
    }

}
