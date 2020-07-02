using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VahtiApp
{
    public partial class Frm_Vahti_Main : Form
    {

        //Hilma clHilma = new Hilma();
        

        public Frm_Vahti_Main()
        {
            InitializeComponent();
            this.lstKaikkiTajoukset = new System.Collections.Generic.List<Tarjous>();
            clPienHankinta = new PienHankinta();
            clTarjouspalvelu = new TarjousPalvelu();
            lstBrowsers = new List<WebBrowser>();
        }

        private void Btn_PienHankinta_Click(object sender, EventArgs e)
        {
            //Hilma clHilma = new Hilma();
            //clHilma.HaeEtusivu();
            //Trace.ReadLine();

            Trace.WriteLine("Pienhankinta");
            //RTbx_VahtiLog.AppendText(Environment.NewLine + "Alku");
            string strEHWReq = "Ohi";
            bool bOk = clPienHankinta.GetWebPage();
            Trace.WriteLine($"GetWebPage {bOk}");
            //RTbx_VahtiLog.AppendText(Environment.NewLine + $"GetWebPage {bOk}");
            if (bOk) bOk = clPienHankinta.PuraEtusivu();
            //RTbx_VahtiLog.AppendText(Environment.NewLine + $"PuraEtusivu {bOk} sivuja {clPienHankinta.sivuja()}");
            Trace.WriteLine($"PuraEtusivu {bOk} sivuja {clPienHankinta.sivuja()}");
            if (bOk) bOk = clPienHankinta.PuraAlaSivut();
            //RTbx_VahtiLog.AppendText(Environment.NewLine + $"PuraAlaSivut {bOk}");
            Trace.WriteLine($"PuraAlaSivut {bOk}");
            clPienHankinta.lstTajoukset.Sort();
            lstKaikkiTajoukset.AddRange(clPienHankinta.lstTajoukset);
            //Trace.WriteLine("strEHWReq");
            //
            //foreach (var clTar in clPienHankinta.lstTajoukset)
            //{
            //    Trace.WriteLine(clTar);
            //}
        }

        private void Btn_Load_Click(object sender, EventArgs e)
        {
            ///Lataa olemassaolevat kansiot
            bool bOk = clPienHankinta.LataaTiedot(clPienHankinta.Tallenne());
            Trace.WriteLine($"Pientarjoukset LataaTiedot {bOk}");
            //RTbx_VahtiLog.AppendText(Environment.NewLine + $"Pientarjoukset LataaTiedot {bOk}");
        }

        private void btn_tarjouksia_Click(object sender, EventArgs e)
        {
            lbl_Tarjouksia.Text = lstKaikkiTajoukset.Count().ToString();
        }

        private void Btn_Tarjouspalvelu_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("TarjousPalvelu");
            //RTbx_VahtiLog.AppendText(Environment.NewLine + "Alku");
            string strEHWReq = "Ohi";
            bool bOk = clTarjouspalvelu.GetWebPage();
            Trace.WriteLine($"GetWebPage {bOk}");
            //RTbx_VahtiLog.AppendText(Environment.NewLine + $"GetWebPage {bOk}");
            if (bOk) bOk = clTarjouspalvelu.PuraEtusivu();
            //RTbx_VahtiLog.AppendText(Environment.NewLine + $"PuraEtusivu {bOk} sivuja {clPienHankinta.sivuja()}");
            Trace.WriteLine($"PuraEtusivu {bOk} sivuja {clTarjouspalvelu.sivuja()}");

            if (bOk) bOk = clTarjouspalvelu.SuodataLista();
            List<Uri> lstTPUrit = clTarjouspalvelu.TeeUriLista();
            int i = 0;
            char[] charsToTrim = { '{', ' ', '}', '\n', '\r', '\"' };
            foreach (Uri strIterSivu in lstTPUrit)
            {
                //Uri strIterSivu = strUBSivu.Uri;
                WebBrowser wb = new WebBrowser();
                //string strVal = strIterSivu.ToString();
                string strNimi = clTarjouspalvelu.HaeUriName(strIterSivu.ToString());
                wb.Name = strNimi;


                wb.Navigated += webBrowser_Navigated;
                wb.Navigate(strIterSivu);
                lstBrowsers.Add(wb);
                i++;
                if (i == 2) break;
            }

        }
        private void webBrowser_Navigated(object sender,    WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            WebBrowser browser = sender as WebBrowser;
            browser.Navigated -= webBrowser_Navigated;
            browser.DocumentCompleted += webBrowserDokumenttiTaydellinen;
            string strUri = browser.Url.ToString();
            strUri = strUri.Replace("default.aspx", "tarjouspyynnot.aspx");
            browser.Navigate(strUri);
        }

        private void webBrowserDokumenttiTaydellinen(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //check that the full document is finished
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;

            //get our browser reference
            WebBrowser browser = sender as WebBrowser;

            WebBrowser snd = (WebBrowser)sender;
            string strSisalto = snd.DocumentText;
            Trace.WriteLine($"Puretaan Sivua {snd.Name}");
            if (clTarjouspalvelu.PuraAlaSivut(strSisalto, snd.Name))
            {
                //if divfooter missing , page is not ok
                //detach the event handler from the browser
                //note: necessary to stop endlessly setting strings and clicking buttons
                browser.DocumentCompleted -= webBrowserDokumenttiTaydellinen;
                //attach second DocumentCompleted event handler to destroy browser
                webBrowserTuhoaKokonaisuus(sender, e);
            }
        }

        private void webBrowserTuhoaKokonaisuus(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //check that the full document is finished
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;

            //I just destroy the WebBrowser, but you might want to do something
            //with the newly navigated page

            WebBrowser browser = sender as WebBrowser;
             Trace.WriteLine($"Poistetaan Sivua {browser.Name}, Jäljellä {lstBrowsers.Count()}");
            browser.Dispose();
            lstBrowsers.Remove(browser);
        }
    }
}
