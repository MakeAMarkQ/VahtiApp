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
using System.Xml.Linq;

namespace VahtiApp
{
    public partial class Frm_Vahti_Main : Form
    {

        //Hilma clHilma = new Hilma();
        public bool bHilma = false;
        public bool bPienhankinta = false;
        public bool bTarjouspalvelu = false;
        public int iIntervalinms = 1500;
        public string strFileName = "Tarjoukset.xml";
        //public string strHankiurl = string.Empty;
        //public string strAkliniurl = string.Empty;
        public Frm_Vahti_Main()
        {
            InitializeComponent();
            this.lstKaikkiTajoukset = new System.Collections.Generic.List<Tarjous>();
            clPienHankinta = new PienHankinta();
            clTarjouspalvelu = new TarjousPalvelu();
            clHilma = new Hilma();
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
            //bPienhankinta = true;
            CBx_Pien.Checked = true;
            //lstKaikkiTajoukset.AddRange(clPienHankinta.lstTajoukset);
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
            if (CBx_Hilma.Checked == true && !bHilma)
            {
                lstKaikkiTajoukset.AddRange(clHilma.lstTajoukset);
                bHilma = true;
            }
            if (CBx_Pien.Checked == true && !bPienhankinta)
            {
                lstKaikkiTajoukset.AddRange(clPienHankinta.lstTajoukset);
                bPienhankinta = true;
            }
            if (CBx_Tarjous.Checked == true && !bTarjouspalvelu)
            {
                lstKaikkiTajoukset.AddRange(clTarjouspalvelu.lstTajoukset);
                bTarjouspalvelu = true;
            }
            lbl_Tarjouksia.Text = lstKaikkiTajoukset.Count().ToString();
        }
        public List<Uri> lstTPUrit;
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
            lstTPUrit = clTarjouspalvelu.TeeUriLista();
            Tmr_Vahti.Interval = iIntervalinms;
            Tmr_Vahti.Start();
            //int i = 0;
            //char[] charsToTrim = { '{', ' ', '}', '\n', '\r', '\"' };

            //Uri strIterSivu = strUBSivu.Uri;

            //i++;
            //if (i == 2) break;


        }
        
        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            WebBrowser browser = sender as WebBrowser;
            browser.Navigated -= webBrowser_Navigated;
            browser.DocumentCompleted += webBrowserDokumenttiTaydellinen;
            string strUri = browser.Url.ToString();
            strUri = strUri.Replace("default.aspx", "tarjouspyynnot.aspx");
            //if (browser.Name.Contains("p=1295&"))
            //    strAkliniurl = strUri.ToString();
            //if (browser.Name.Contains("p=279&"))
            //    strHankiurl = strUri.ToString();
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
            if (lstBrowsers.Count == 0)
            {
                //bTarjouspalvelu = true;
                CBx_Tarjous.Checked = true;
            }
        }

        private void Btn_Hilma_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("Hilma");
            //RTbx_VahtiLog.AppendText(Environment.NewLine + "Alku");
            //WebBrowser WBrHilma = new WebBrowser();
            TB_Kerta.Text = "0";
            WBrHilma.Name = "Hilma";
            WBrHilma.DocumentCompleted += WBrHilma_DokumenttiTaydellinen;
            WBrHilma.Navigate(@"https://www.hankintailmoitukset.fi/fi/search?top=1500&other=showActive&of=tendersOrRequestsToParticipateDueDateTime&od=asc");
            //WBrHilma.Navigate(@"https://www.hankintailmoitukset.fi/fi/search?top=12&other=showActive&of=datePublished&od=desc");

        }
        private void WBrHilma_DokumenttiTaydellinen(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int iKerta;
            int.TryParse(TB_Kerta.Text, out iKerta);
            TB_Kerta.Text = (++iKerta).ToString();
            //check that the full document is finished
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;

            //get our browser reference
            WebBrowser browser = sender as WebBrowser;

            WebBrowser snd = (WebBrowser)sender;
            string strSisalto = snd.DocumentText;
            Trace.WriteLine($"Puretaan Sivua {snd.Name}");
            //if (clHilma.PuraAlaSivut(strSisalto, snd.Name))
            //{
            //    //if divfooter missing , page is not ok
            //    //detach the event handler from the browser
            //    //note: necessary to stop endlessly setting strings and clicking buttons
            //    browser.DocumentCompleted -= webBrowserDokumenttiTaydellinen;
            //    //attach second DocumentCompleted event handler to destroy browser
            //    webBrowserTuhoaKokonaisuus(sender, e);
            //}
        }

        private void Btn_HilmaData_Click(object sender, EventArgs e)
        {
            string txt = WBrHilma.Document.Body.InnerHtml;
            clHilma.PuraAlaSivut(txt, WBrHilma.Name);
            //lstKaikkiTajoukset.AddRange(clHilma.lstTajoukset);
            //bHilma = true;
            CBx_Hilma.Checked = true;
        }

        private void Frm_Vahti_Main_Shown(object sender, EventArgs e)
        {
            Btn_Hilma_Click(sender, e);
        }
        public int iPage = 0;
        private void Tmr_Vahti_Tick(object sender, EventArgs e)
        {
            int iSivuja = lstTPUrit.Count;
            if (iPage == iSivuja)
            {
                Tmr_Vahti.Stop();
                lbl_timer.Text="Timer stop";
            }
            else
            {
                Uri strIterSivu = lstTPUrit[iPage];

                WebBrowser wb = new WebBrowser();
                //string strVal = strIterSivu.ToString();
                string strNimi = clTarjouspalvelu.HaeUriName(strIterSivu.ToString());
                //if (strNimi.Contains("1295") || strNimi.Contains("hanki"))
                //{

                    wb.Name = strNimi;


                    wb.Navigated += webBrowser_Navigated;
                    wb.Navigate(strIterSivu);
                    lstBrowsers.Add(wb);
                //}
                iPage++;
                lbl_timer.Text = "Timer Running: webs opened:" +iPage+"/"+ iSivuja;
            }
        }

        private void Btn_JTarj_Click(object sender, EventArgs e)
        {
            if (lstKaikkiTajoukset.Count > 0)
            {
                   var xml = new XElement("Tarjoukset", lstKaikkiTajoukset.Select(x => new XElement("tarjous",
                                               new XAttribute("strKunta", x.strKunta),
                                               new XAttribute("strTunnus", x.strTunnus),
                                               new XAttribute("strAlkuperainenLinkki", x.strAlkuperainenLinkki),
                                               new XAttribute("strTajousDocLinkki", x.strTajousDocLinkki),
                                               new XAttribute("strTarjousDirLinkki", x.strTarjousDirLinkki),
                                               new XAttribute("strPyynto", x.strPyynto),
                                               new XAttribute("strKuvaus", x.strKuvaus),
                                               new XAttribute("strMaaraAika", x.strMaaraAika),
                                               new XAttribute("strJulkaistu", x.strJulkaistu),
                                               new XAttribute("strDataBase", x.strDataBase),
                                               new XAttribute("bFiltered", x.bFiltered),
                                               new XAttribute("strIlmoitusTyyppi", x.strIlmoitusTyyppi)
                                               )));
                xml.Save(strFileName, SaveOptions.None);
            }
        }

        private void Btn_Hanki_Click(object sender, EventArgs e)
        {
            Uri strIterSivu = new Uri("https://tarjouspalvelu.fi/hanki");
            WebBrowser wb = new WebBrowser();
            wb.Name = "hanki,279";


            wb.Navigated += webBrowser_Navigated;
            wb.Navigate(strIterSivu);
        }
    }
}
