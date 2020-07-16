using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
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
        public int iPage = 0;
        public List<Uri> lstTPUrit;
        private List<string> lstSuodata;
        private readonly string strSuodatin="Suodatin.txt";
        private List<string> lstSuodin;
        //public string strAkliniurl = string.Empty;
        public Frm_Vahti_Main()
        {
            InitializeComponent();
            this.lstKaikkiTajoukset = new System.Collections.Generic.List<Tarjous>();
            clPienHankinta = new PienHankinta();
            clTarjouspalvelu = new TarjousPalvelu();
            clHilma = new Hilma();
            lstBrowsers = new List<WebBrowser>();
            lstTPUrit = new List<Uri>();
            lstSuodata = new List<string>();
            lstSuodin = new List<string>();
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

        

        private void btn_tarjouksia_Click(object sender, EventArgs e)
        {
            // tänne myös hakujen filterointi
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
            //Uusi ikkuna jossa näytetään tiedot
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
            string pvm = "2000-07-05";
            Trace.WriteLine("Hilma");
            //RTbx_VahtiLog.AppendText(Environment.NewLine + "Alku");
            //WebBrowser WBrHilma = new WebBrowser();
            //TB_Kerta.Text = "0";
            WBrHilma.Name = "Hilma";

            WBrHilma.DocumentCompleted += WBrHilma_DokumenttiTaydellinen;
            //string srtNavigate=@"https://www.hankintailmoitukset.fi/fi/search?top=1500&other=showActive&of=tendersOrRequestsToParticipateDueDateTime&od=asc";
            string srtNavigate =$"https://www.hankintailmoitukset.fi/fi/search?top=2000&pa="+pvm+"&other=showActive&of=datePublished&od=desc";
            //string srtNavigate=@"https://www.hankintailmoitukset.fi/fi/search?top=12&other=showActive&of=datePublished&od=desc";
            WBrHilma.Navigate(srtNavigate);
        }
        private void WBrHilma_DokumenttiTaydellinen(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //int iKerta;
            //int.TryParse(TB_Kerta.Text, out iKerta);
            //TB_Kerta.Text = (++iKerta).ToString();
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
            if(File.Exists(strFileName))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(strFileName);
                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Tarjoukset/tarjous");
                TSSttsBr_Vahti.Maximum = nodes.Count / 10;
                TSSttsBr_Vahti.Value = 0;
                int iLoop = 0;
                foreach (XmlNode node in nodes)
                {
                    Tarjous clTarjous = new Tarjous();

                    clTarjous.strKunta = node.SelectSingleNode("Kunta").InnerText;
                    clTarjous.strTunnus = node.SelectSingleNode("Tunnus").InnerText;
                    clTarjous.strAlkuperainenLinkki = node.SelectSingleNode("AlkuperainenLinkki").InnerText;
                    clTarjous.strTajousDocLinkki = node.SelectSingleNode("TajousDocLinkki").InnerText;
                    clTarjous.strTarjousDirLinkki = node.SelectSingleNode("TarjousDirLinkki").InnerText;
                    clTarjous.strPyynto = node.SelectSingleNode("Pyynto").InnerText;
                    clTarjous.strKuvaus = node.SelectSingleNode("Kuvaus").InnerText;
                    clTarjous.strMaaraAika = node.SelectSingleNode("MaaraAika").InnerText;
                    clTarjous.strJulkaistu = node.SelectSingleNode("Julkaistu").InnerText;
                    clTarjous.strDataBase = node.SelectSingleNode("DataBase").InnerText;
                    clTarjous.strFiltered = node.SelectSingleNode("Filtered").InnerText;
                    clTarjous.strIlmoitusTyyppi = node.SelectSingleNode("IlmoitusTyyppi").InnerText;
                    lstKaikkiTajoukset.Add(clTarjous);
                    if (iLoop % 10 == 0)
                    {
                        TSSttsBr_Vahti.Value = iLoop / 10;
                        Application.DoEvents();
                    }
                    iLoop++;
                }
                lbl_Tarjouksia.Text = lstKaikkiTajoukset.Count().ToString();

            }
        }
        private void Btn_Talleta_Click(object sender, EventArgs e)
        {
            if (lstKaikkiTajoukset.Count > 0)
            {

                var xml = new XElement("Tarjoukset", lstKaikkiTajoukset.Select(x => new XElement("tarjous",
                                            new XElement("Kunta", x.strKunta),
                                            new XElement("Tunnus", x.strTunnus),
                                            new XElement("AlkuperainenLinkki", x.strAlkuperainenLinkki),
                                            new XElement("TajousDocLinkki", x.strTajousDocLinkki),
                                            new XElement("TarjousDirLinkki", x.strTarjousDirLinkki),
                                            new XElement("Pyynto", x.strPyynto),
                                            new XElement("Kuvaus", x.strKuvaus),
                                            new XElement("MaaraAika", x.strMaaraAika),
                                            new XElement("Julkaistu", x.strJulkaistu),
                                            new XElement("DataBase", x.strDataBase),
                                            new XElement("Filtered", x.strFiltered),
                                            new XElement("IlmoitusTyyppi", x.strIlmoitusTyyppi)
                                            )));
                xml.Save(strFileName, SaveOptions.None);
            }
        }
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
        private void Btn_Lisaa_Click(object sender, EventArgs e)
        {
            if(!lstSuodin.Contains(TB_Kerta.Text))
                lstSuodin.Add(TB_Kerta.Text);
            lstSuodin.Sort();
            File.WriteAllLines(strSuodatin, lstSuodin.ToArray());
            Btn_Suodata_Click(sender,e);
        }


        private void Btn_Suodata_Click(object sender, EventArgs e)
        {
            if (File.Exists(strSuodatin))
                lstSuodin = File.ReadAllLines(strSuodatin).ToList();
            Lbx_Vahti.Items.Clear();
            foreach (var txt in lstSuodin)
                Lbx_Vahti.Items.Add(txt);
            List<Tarjous> lstEiSuodatetut = lstKaikkiTajoukset.FindAll(x => x.strFiltered.ToLower().Contains("fa"));
            int iCount = lstEiSuodatetut.Count;
            TsStpLbl_Vahti.Text = iCount.ToString();
            TSSttsBr_Vahti.Maximum = lstEiSuodatetut.Count / 100;
            TSSttsBr_Vahti.Value = 0;
            int iLoop = 0;
            foreach (Tarjous clTarj in lstEiSuodatetut)
            {
                foreach(var strSana in lstSuodin)
                {
                    if(clTarj.strPyynto.ToLower().Contains(strSana)||
                        clTarj.strKuvaus.ToLower().Contains(strSana))
                    {
                        clTarj.strFiltered = "True";
                        iCount--;
                        TsStpLbl_Vahti.Text = iCount.ToString();
                        RTxtBx_Vahti.Text = RTxtBx_Vahti.Text.Replace(clTarj.ToString() + Environment.NewLine, " ");
                    }
                    if (iLoop % 100 == 0)
                    {
                        TSSttsBr_Vahti.Value= iLoop / 100;
                        Application.DoEvents();
                    }
                }
                    iLoop++;
            }
            //var e = a.Intersect(b).Any();
            Btn_Talleta_Click(sender, e);
        }

        private void Btn_Listaa_Click(object sender, EventArgs e)
        {
            WBrHilma.Visible = false;
            RTxtBx_Vahti.Visible = true;
            RTxtBx_Vahti.Clear();
            List<Tarjous> lstEiSuodatetut = lstKaikkiTajoukset.FindAll(x => x.strFiltered.ToLower().Contains("fa"));
            TsStpLbl_Vahti.Text = lstEiSuodatetut.Count.ToString();
            TSSttsBr_Vahti.Maximum = lstEiSuodatetut.Count / 10;
            TSSttsBr_Vahti.Value = 0;
            int iLoop = 0;
            foreach (Tarjous clTarj in lstEiSuodatetut)
            {
                RTxtBx_Vahti.Text += clTarj.ToString() + Environment.NewLine;
                if(iLoop%10==0)
                {
                    TSSttsBr_Vahti.Value = iLoop / 10;
                    Application.DoEvents();
                }
                iLoop++;
            }
            
        }

        private void Frm_Vahti_Main_SizeChanged(object sender, EventArgs e)
        {
            RTxtBx_Vahti.Left = 590;
            WBrHilma.Left = 590;
        }

        private void btn_Rapotti_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Vahti_Main_Resize(object sender, EventArgs e)
        {

            SplCnt_Vahti.SplitterDistance = 590;
        }
    }
}
