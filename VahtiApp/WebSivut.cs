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
        private List<Tarjous> lstTarjous;
        private WebBrowser wb;
        private ToolStripTextBox TSTxtBx_Kommentti;
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
            ToolStripButton tsbHi = new ToolStripButton();
            tsbHi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tsbHi.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbHi.Name = "tsbHi";
            tsbHi.Size = new System.Drawing.Size(43, 22);
            tsbHi.Text = "Hilma";

            tsbHi.Click += new System.EventHandler(H_tsbtn_Hilma_Click);
            ToolStripButton tsbPi = new ToolStripButton();
            tsbPi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tsbPi.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbPi.Name = "tsbPi";
            tsbPi.Size = new System.Drawing.Size(43, 22);
            tsbPi.Text = "Pien";
            tsbPi.Click += new System.EventHandler(H_tsbtn_Pien_Click);
            ToolStripButton tsbTa = new ToolStripButton();
            tsbTa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tsbTa.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbTa.Name = "tsbHi";
            tsbTa.Size = new System.Drawing.Size(43, 22);
            tsbTa.Text = "Tarjous";
            tsbTa.Click += new System.EventHandler(H_tsbtn_tarjous_Click);
            ToolStripButton tsbTT = new ToolStripButton();
            tsbTT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tsbTT.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbTT.Name = "tsbTT";
            tsbTT.Size = new System.Drawing.Size(43, 22);
            tsbTT.Text = "Filtteröi";
            tsbTT.Click += new System.EventHandler(H_tsbTT_tarjous_Click);
            ToolStripButton tsbCP = new ToolStripButton();
            tsbCP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tsbCP.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbCP.Name = "tsbCP";
            tsbCP.Size = new System.Drawing.Size(43, 22);
            tsbCP.Text = "Kopioi";
            tsbCP.Click += new System.EventHandler(H_tsbCP_tarjous_Click);
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

            ToolStrip ts1 = new ToolStrip();
            ts1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { 
                tsbHi, TSSep,tsbPi, 
                TSSep,tsbTa, tsbTT, 
                TSSep,tsbCP,TSTxtBx_Kommentti });
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
            if(iHN < iLK)
            {
                iLK = strInner.ToLower().LastIndexOf(strLyhKuv,iHN);
            }
            string strUKuvaus = strInner.Substring(iLK, iHN - iLK);
            strUKuvaus = strUKuvaus.Remove(strUKuvaus.IndexOf("</p"));
            strUKuvaus = strUKuvaus.Remove(0, strUKuvaus.LastIndexOf(">")+1);
            for (int i = 0; i < TarjousManager.lstKaikkiTajoukset.Count; i++)
            {
                if (TarjousManager.lstKaikkiTajoukset[i].iTarjNro == id)
                {
                    TarjousManager.lstKaikkiTajoukset[i].strKuvaus = strUKuvaus;
                    TarjousManager.lstKaikkiTajoukset[i].strKuvaushaettu = "true";
                    TarjousManager.lstKaikkiTajoukset[i].strKommentti = TSTxtBx_Kommentti.Text;
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
            
            strUKuvaus=strUKuvaus.Remove(0, iLK + 4);
            iHN = strUKuvaus.ToLower().LastIndexOf(strEnd);
            strUKuvaus = strUKuvaus.Remove(iHN);
            for (int i = 0; i < TarjousManager.lstKaikkiTajoukset.Count; i++)
            {
                if (TarjousManager.lstKaikkiTajoukset[i].iTarjNro == id)
                {
                    TarjousManager.lstKaikkiTajoukset[i].strKuvaus = strUKuvaus;
                    TarjousManager.lstKaikkiTajoukset[i].strKuvaushaettu = "true";
                    TarjousManager.lstKaikkiTajoukset[i].strKommentti = TSTxtBx_Kommentti.Text;
                    break;
                }
            }

        }

        private void H_tsbtn_tarjous_Click(object sender, EventArgs e)
        {
            string strInner = wb.Document.Body.OuterHtml;
            string strLyhKuv = "kuvaus";
            string strhanknim = "hankintayksikön";
            int iLK = strInner.ToLower().LastIndexOf(strLyhKuv);
            int iHN = strInner.ToLower().LastIndexOf(strhanknim);
            string strUKuvaus = strInner.Substring(iLK, iHN - iLK);
           
            
        }
        private void H_tsbTT_tarjous_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < TarjousManager.lstKaikkiTajoukset.Count; i++)
            {
                if (TarjousManager.lstKaikkiTajoukset[i].iTarjNro == id)
                {
                    
                    TarjousManager.lstKaikkiTajoukset[i].strKuvaushaettu = "true";
                    TarjousManager.lstKaikkiTajoukset[i].strFiltered = "true";
                    TarjousManager.lstKaikkiTajoukset[i].strKommentti = TSTxtBx_Kommentti.Text;
                    break;
                }
            }
        }
        private void H_tsbCP_tarjous_Click(object sender, EventArgs e)
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
                    break;
                }
            }
        }
    }
    
}
