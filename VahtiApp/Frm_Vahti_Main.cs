using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Logging;

namespace VahtiApp
{
    public partial class Frm_Vahti_Main : Form
    {

        
        //Hilma clHilma = new Hilma();
        public bool bHilma = false;
        public bool bPienhankinta = false;
        public bool bTarjouspalvelu = false;
        public int iIntervalinms = 1500;
        public int iInterKuvaus = 100;
        int apu = 0;
        public int iInterSivu = 1000;
        public string strFileName = "Tarjoukset.xml";
        public int iPage = 0;
        public int iSivu = 0;
        public List<Uri> lstTPUrit;
        private List<string> lstSuodata;
        private readonly string strSuodatin = "Suodatin.txt";
        private List<string> lstSuodin;
        public bool bHilmaLaukaistu = false;
        TextBoxTraceListener _textBoxListener;
        //TarjousManager TarMng;

        //public string strAkliniurl = string.Empty;
        public Frm_Vahti_Main()
        {
            InitializeComponent();
            TarjousManager.lstKaikkiTajoukset=new System.Collections.Generic.List<Tarjous>();
            //TarMng.TarjousManager.lstKaikkiTajoukset = new System.Collections.Generic.List<Tarjous>();
            clPienHankinta = new PienHankinta();
            clTarjouspalvelu = new TarjousPalvelu();
            clHilma = new Hilma();
            lstBrowsers = new List<WebBrowser>();
            lstHilmaWebPages = new List<string>();
            lstTPUrit = new List<Uri>();
            lstSuodata = new List<string>();
            lstSuodin = new List<string>();
            ClPrintti = new Tulostukset();


        }

        private void Btn_PienHankinta_Click(object sender, EventArgs e)
        {
            //Hilma clHilma = new Hilma();
            //clHilma.HaeEtusivu();
            //Trace.ReadLine();

            Trace.WriteLine("Pienhankinta");
            //RTbx_VahtiLog.AppendText(Environment.NewLine + "Alku");
            //string strEHWReq = "Ohi";
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
            //TarjousManager.lstKaikkiTajoukset.AddRange(clPienHankinta.lstTajoukset);
            //Trace.WriteLine("strEHWReq");
            //
            //foreach (var clTar in clPienHankinta.lstTajoukset)
            //{
            //    Trace.WriteLine(clTar);
            //}
        }



        private void btn_tarjouksia_Click(object sender, EventArgs e)
        {
            Tarjous clTarTemp = new Tarjous();
            // tänne myös hakujen filterointi
            if (CBx_Hilma.Checked == true && !bHilma)
            {
                TarjousManager.lstKaikkiTajoukset.AddRange(clTarTemp.UudetTarjoukset(TarjousManager.lstKaikkiTajoukset, clHilma.lstTajoukset));
                bHilma = true;
            }
            if (CBx_Pien.Checked == true && !bPienhankinta)
            {
                TarjousManager.lstKaikkiTajoukset.AddRange(clTarTemp.UudetTarjoukset(TarjousManager.lstKaikkiTajoukset, clPienHankinta.lstTajoukset));
                bPienhankinta = true;
            }
            if (CBx_Tarjous.Checked == true && !bTarjouspalvelu)
            {
                TarjousManager.lstKaikkiTajoukset.AddRange(clTarTemp.UudetTarjoukset(TarjousManager.lstKaikkiTajoukset, clTarjouspalvelu.lstTajoukset));
                bTarjouspalvelu = true;
            }
            lbl_Tarjouksia.Text = TarjousManager.lstKaikkiTajoukset.Count().ToString();
            //Uusi ikkuna jossa näytetään tiedot
        }


        private void Btn_Tarjouspalvelu_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("TarjousPalvelu");
            //RTbx_VahtiLog.AppendText(Environment.NewLine + "Alku");
            //string strEHWReq = "Ohi";
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

            //WebBrowser snd = (WebBrowser)sender;
            string strSisalto = browser.DocumentText;
            Trace.WriteLine($"Puretaan Sivua {browser.Name}");
            if (clTarjouspalvelu.PuraAlaSivut(strSisalto, browser.Name))
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
            string srtNavigate = $"https://www.hankintailmoitukset.fi/fi/search?top=2000&pa=" + pvm + "&other=showActive&of=datePublished&od=desc";
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
            //TarjousManager.lstKaikkiTajoukset.AddRange(clHilma.lstTajoukset);
            //bHilma = true;
            CBx_Hilma.Checked = true;
        }

        private void Frm_Vahti_Main_Shown(object sender, EventArgs e)
        {
            TbCnt_Vahti.Dock = DockStyle.Fill;
            WBrHilma.Dock = DockStyle.Fill;
            RchTxtBx_Vahti.Dock = DockStyle.Fill;
            Btn_Hilma_Click(sender, e);
            if (File.Exists(strFileName))
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
                    clTarjous.strKuvaushaettu = node.SelectSingleNode("Kuvaushaettu").InnerText;
                    clTarjous.strVaihtoehtoLinkki = node.SelectSingleNode("VaihtoehtoLinkki").InnerText;
                    clTarjous.strKommentti = node.SelectSingleNode("Kommentti").InnerText;
                    TarjousManager.lstKaikkiTajoukset.Add(clTarjous);
                    if (iLoop % 10 == 0)
                    {
                        try 
                        {
                            if (TSSttsBr_Vahti is null) return;
                            TSSttsBr_Vahti.Value = iLoop / 10;
                            Application.DoEvents();
                        }
                        catch (Exception eValue)
                        {
                            Trace.WriteLine("Error: " + eValue.Message.ToString());
                        }
                }
                    iLoop++;
                }
                lbl_Tarjouksia.Text = TarjousManager.lstKaikkiTajoukset.Count().ToString();

            }
            Btn_Suodata_Click(sender, e);
            Btn_Erotele_Sanat_Click(sender, e);
            Tmr_SivuVahti.Enabled = true;
            Tmr_SivuVahti.Interval = 1000;
            Tmr_SivuVahti.Start();
        }
        private void Btn_Talleta_Click(object sender, EventArgs e)
        {
            if (TarjousManager.lstKaikkiTajoukset.Count > 0)
            {

                var xml = new XElement("Tarjoukset", TarjousManager.lstKaikkiTajoukset.Select(x => new XElement("tarjous",
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
                                            new XElement("IlmoitusTyyppi", x.strIlmoitusTyyppi),
                                            new XElement("Kuvaushaettu", x.strKuvaushaettu),
                                            new XElement("VaihtoehtoLinkki", x.strVaihtoehtoLinkki),
                                            new XElement("Kommentti", x.strKommentti)

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
                lbl_timer.Text = "Timer stop";
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
                lbl_timer.Text = "Timer Running: webs opened:" + iPage + "/" + iSivuja;
            }
        }
        private void Btn_Lisaa_Click(object sender, EventArgs e)
        {
            TsStsLbl_Vahti_ToDo.Text = "Lisätään sanaa";
            string strSana = TB_Kerta.Text.ToLower();
            if (strSana == string.Empty) return;
            if (!lstSuodin.Contains(strSana))
            {
                //Btn_Suodata_Click(sender, e);
                List<Tarjous> lstEiSuodatetut = TarjousManager.lstKaikkiTajoukset.FindAll(x => x.strFiltered.ToLower().Contains("fa"));
                int iCount = lstEiSuodatetut.Count;
                foreach (Tarjous clTarj in lstEiSuodatetut)
                {

                    bool bPyynt = clTarj.strPyynto.ToLower().Contains(strSana);
                    bool bKuva = clTarj.strKuvaus.ToLower().Contains(strSana);
                    if (bPyynt ||
                            bKuva)
                    {
                        clTarj.strFiltered = "True";
                        iCount--;
                        TsStpLbl_Vahti.Text = iCount.ToString();
                        int iLine = 0;


                        //continue;
                    }
                }
                Btn_Talleta_Click(sender, e);
            }
            if (RchTxtBx_Vahti.Visible == true)
                Btn_Listaa_Click(sender, e);
            else
                btn_Rapotti_Click(sender, e);

            TB_Kerta.Clear();
            lstSuodin.Add(strSana.ToLower());
            lstSuodin.Sort();
            File.WriteAllLines(strSuodatin, lstSuodin.ToArray());

            Lbx_Vahti.Items.Clear();
            foreach (var txt in lstSuodin)
                Lbx_Vahti.Items.Add(txt.ToLower());
            TsStsLbl_Vahti_ToDo.Text = "Lisää.Valm";
        }


        private void Btn_Suodata_Click(object sender, EventArgs e)
        {
            TsStsLbl_Vahti_ToDo.Text = "Suodattaa";
            //Load filter words to list and conver all to lower
            if (File.Exists(strSuodatin))
                lstSuodin = File.ReadAllLines(strSuodatin).ToList();
            lstSuodin = lstSuodin.ConvertAll(d => d.ToLower());
            //clear listbox and fill it
            Lbx_Vahti.Items.Clear();
            foreach (var txt in lstSuodin)
                Lbx_Vahti.Items.Add(txt.ToLower());
            //take only non filtered Tarjous things
            List<Tarjous> lstEiSuodatetut = TarjousManager.lstKaikkiTajoukset.FindAll(x => x.strFiltered.ToLower().Contains("fa"));
            int iCount = lstEiSuodatetut.Count;
            TsStpLbl_Vahti.Text = iCount.ToString();
            TSSttsBr_Vahti.Maximum = lstEiSuodatetut.Count / 100;
            TSSttsBr_Vahti.Value = 0;
            int iLoop = 0;
            lstEiSuodatetut.Sort();
            Tarjous EdellinenTatjous = new Tarjous();//needed to fix double Tarjous
            //Handle all Tarjous fron nonfiltered list
            foreach (Tarjous clTarj in lstEiSuodatetut)
            {
                if (clTarj.CompareTo(EdellinenTatjous) == 0)
                {
                    clTarj.strFiltered = "True";
                    continue;
                }
                EdellinenTatjous = clTarj;
                if (clTarj.strMaaraAika.CompareTo(DateTime.Now.ToString("yyyyMMdd_HHmm")) == -1)
                {
                    clTarj.strFiltered = "True";
                    clTarj.bPoista = true;
                    continue;
                }
                if (clTarj.strMaaraAika.Contains("9999"))
                {
                    clTarj.strFiltered = "True";
                    continue;
                }
                foreach (var strSana in lstSuodin)
                {
                    TsStsLbl_Vahti_ToDo.Text = "Suod. " + strSana.Substring(0, 4);
                    if (RchTxtBx_Vahti.Text != string.Empty &&
                        RchTxtBx_Vahti.Text.ToLower().IndexOf(strSana) == -1)
                    {
                        iLoop++;
                        if (iLoop % 100 == 0)
                        {
                            if (iLoop > TSSttsBr_Vahti.Maximum)
                                TSSttsBr_Vahti.Value = TSSttsBr_Vahti.Maximum;
                            else
                                TSSttsBr_Vahti.Value = iLoop / 100;
                            Application.DoEvents();
                        }
                        continue;
                    }
                    int iPyyt = clTarj.strPyynto.ToLower().IndexOf(strSana);
                    int iKuv = clTarj.strKuvaus.ToLower().IndexOf(strSana);
                    if (iPyyt != -1 ||
                        iKuv != -1)
                    {

                     //if (clTarj.strPyynto.ToLower().Contains("studio"))
                     //   iLoop = iLoop + 0;
                       clTarj.strFiltered = "True";
                        iCount--;
                        TsStpLbl_Vahti.Text = iCount.ToString();
                        int iLine = 0;
                        string strTemp = string.Empty;
                        string strCase = string.Empty;
                        while (iLine < RchTxtBx_Vahti.Lines.Count())
                        {
                            if (RchTxtBx_Vahti.Lines[iLine].Contains("{"))
                            {
                                strCase = RchTxtBx_Vahti.Lines[iLine] + Environment.NewLine; ;
                            }
                            else if (RchTxtBx_Vahti.Lines[iLine].Contains("}"))
                            {
                                strCase += RchTxtBx_Vahti.Lines[iLine] + Environment.NewLine;
                                if (!strCase.ToLower().Contains(strSana.ToLower()))
                                {

                                    strTemp += strCase.Replace("&quot;", "'").Replace("&#214;", "í");
                                }

                            }
                            else
                                strCase += RchTxtBx_Vahti.Lines[iLine] + Environment.NewLine;
                            if (iLine % 100 == 0)
                            {
                                TSSttsBr_Vahti.Value = iLine / 100;
                                Application.DoEvents();
                            }
                            iLine++;
                        }
                        RchTxtBx_Vahti.Text = strTemp;
                        RchTxtBx_Vahti.Refresh();
                        //continue;
                    }
                    if (iLoop % 100 == 0)
                    {
                        if (iLoop / 100 < TSSttsBr_Vahti.Maximum)
                            TSSttsBr_Vahti.Value = iLoop / 100;
                        else
                            TSSttsBr_Vahti.Value = TSSttsBr_Vahti.Maximum;
                        Application.DoEvents();
                    }
                }
                iLoop++;
            }
            //var e = a.Intersect(b).Any();
            Btn_Talleta_Click(sender, e);
            TsStsLbl_Vahti_ToDo.Text = "Suod.Valm";
            Application.DoEvents();

        }

        private void Btn_Listaa_Click(object sender, EventArgs e)
        {
            Btn_TalletaRaportti.Visible = false;
            ChckBx_Uusi.Enabled = true;
            TsStsLbl_Vahti_ToDo.Text = "Listaa Tarjoukset";
            WBrHilma.Visible = false;
            TbCnt_Vahti.Visible = false;
            RchTxtBx_Vahti.Visible = true;
            RchTxtBx_Vahti.Clear();
            TarjousManager.lstKaikkiTajoukset.Sort();
            List<Tarjous> lstEiSuodatetut = TarjousManager.lstKaikkiTajoukset.FindAll(x => x.strFiltered.ToLower().Contains("fa"));
            TsStpLbl_Vahti.Text = lstEiSuodatetut.Count.ToString();
            TSSttsBr_Vahti.Maximum = lstEiSuodatetut.Count / 10;
            int iMax = TSSttsBr_Vahti.Maximum;
            TSSttsBr_Vahti.Value = 0;
            int iLoop = 0;
            foreach (Tarjous clTarj in lstEiSuodatetut)
            {
                RchTxtBx_Vahti.Text += clTarj.ToString().Replace("&quot;", "'").Replace("&#214;", "í") + Environment.NewLine;
                if (iLoop % 10 == 0)
                {
                    if (iLoop / 10 > iMax)
                        iLoop = iMax * 10 - 1;
                    try
                    {
                        TSSttsBr_Vahti.Value = iLoop / 10;
                        Application.DoEvents();
                    }
                    catch (Exception eValue)
                    {
                        Trace.WriteLine("Error: " + eValue.Message.ToString());
                    }
                }
                iLoop++;
            }
            TsStsLbl_Vahti_ToDo.Text = "Tarj.Valm";
        }

        private void Frm_Vahti_Main_SizeChanged(object sender, EventArgs e)
        {
            RchTxtBx_Vahti.Left = 590;
            WBrHilma.Left = 590;
        }

        private void btn_Rapotti_Click(object sender, EventArgs e)
        {
            ChckBx_Uusi.Enabled = true;
            Btn_TalletaRaportti.Visible = true;
            TsStsLbl_Vahti_ToDo.Text = "Listaa Tarjoukset";
            WBrHilma.Visible = true;
            TbCnt_Vahti.Visible = true;
            RchTxtBx_Vahti.Visible = false;
            RchTxtBx_Vahti.Clear();
            while (TbCnt_Vahti.TabPages.Count > 1)
            {
                TbCnt_Vahti.TabPages.RemoveAt(1);
            }
            TarjousManager.lstKaikkiTajoukset.Sort();
            List<Tarjous> lstEiSuodatetut = TarjousManager.lstKaikkiTajoukset.FindAll(x => x.strFiltered.ToLower().Contains("fa"));
            TsStpLbl_Vahti.Text = lstEiSuodatetut.Count.ToString();
            TSSttsBr_Vahti.Maximum = lstEiSuodatetut.Count / 10;
            TSSttsBr_Vahti.Value = 0;
            string strEdPvm = DateTime.Today.AddDays(-7).ToString("yyyyMMdd_HHmm");
            int iLoop = 0;
            string strHtmlDoku = ClPrintti.HTMLAlku(lstEiSuodatetut.Count, TarjousManager.lstKaikkiTajoukset.Count);
            foreach (Tarjous clTarj in lstEiSuodatetut)
            {
                if (clTarj.strJulkaistu.CompareTo(strEdPvm) == 1)
                    strHtmlDoku += clTarj.ToHtmlHakemistoString() + Environment.NewLine;
                if (iLoop % 10 == 0)
                {
                    TSSttsBr_Vahti.Value = iLoop / 10;
                    Application.DoEvents();
                }
                iLoop++;
                //break;
            }
            strHtmlDoku += ClPrintti.HTMLVanhat();
            iLoop = 0;
            foreach (Tarjous clTarj in lstEiSuodatetut)
            {
                if (clTarj.strJulkaistu.CompareTo(strEdPvm) != 1)
                    strHtmlDoku += clTarj.ToHtmlHakemistoString() + Environment.NewLine;
                if (iLoop % 10 == 0)
                {
                    TSSttsBr_Vahti.Value = iLoop / 10;
                    Application.DoEvents();
                }
                iLoop++;
                //break;
            }
            strHtmlDoku += ClPrintti.HTMLErotin();
            iLoop = 0;
            foreach (Tarjous clTarj in lstEiSuodatetut)
            {
                strHtmlDoku += clTarj.ToHtmlKokoString() + Environment.NewLine;
                if (iLoop % 10 == 0)
                {
                    TSSttsBr_Vahti.Value = iLoop / 10;
                    Application.DoEvents();
                }
                iLoop++;
                //break;
            }
            strHtmlDoku += ClPrintti.HTMLLoppu();
            WBrHilma.DocumentText = strHtmlDoku;
            TsStsLbl_Vahti_ToDo.Text = "Tarj.Valm";
        }

        private void Frm_Vahti_Main_Resize(object sender, EventArgs e)
        {
            if (SplCnt_Vahti.Width > 600)
                SplCnt_Vahti.SplitterDistance = 590;
        }

        private void RTxtBx_Vahti_SelectionChanged(object sender, EventArgs e)
        {
            RichTextBox RTBXtemp = (RichTextBox)sender;
            TB_Kerta.Text = RTBXtemp.SelectedText;
        }

        private void Btn_Erotele_Sanat_Click(object sender, EventArgs e)
        {
            TsStsLbl_Vahti_ToDo.Text = "Erottele Sanat";
            List<string> lstTemp = new List<string>();
            char[] charsToTrim = { ',', '.', ':', ';', ' ', '/', '(', ')', '{', '}', '%', '!','=','&','#',
                                   '\n', '\r','\t', '\"', '\'', '+', '-','<','>',
                                   '\u2013','\u2018', '\u201C', '\u201D','\u2022','\u202F',
                                   '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','+', '-',
                                   '€', '£', '$' };//8220 & 8221
            SortedDictionary<string, int> dctSanat = new SortedDictionary<string, int>();
            foreach (var clTarjous in TarjousManager.lstKaikkiTajoukset)
            {
                string[] arWords = clTarjous.strPyynto.Split(new string[] { " ", "\t", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var strIter in arWords)
                {
                    string strWord = strIter.Replace("&quot;", "!").Trim(charsToTrim).ToLower();
                    if (strWord.Contains("tilaaja"))
                        lstTemp.Add(strWord);
                    if (strWord.Contains("31.12.2024"))
                        lstTemp.Add(strWord);
                    if (lstTemp.Count == 17)
                        continue;
                    if (dctSanat.ContainsKey(strWord))
                        dctSanat[strWord]++;
                    else
                        dctSanat.Add(strWord, 1);
                }
                arWords = clTarjous.strKuvaus.Split(new string[] { " ", "\t", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var strIter in arWords)
                {
                    string strWord = strIter.Replace("&quot;", "!").Trim(charsToTrim).ToLower();
                    if (strWord.Contains("tilaaja"))
                        lstTemp.Add(strWord);
                    if (strWord.Contains("31.12.2024"))
                        lstTemp.Add(strWord);
                    if (lstTemp.Count == 17)
                        continue;
                    if (dctSanat.ContainsKey(strWord))
                        dctSanat[strWord]++;
                    else
                        dctSanat.Add(strWord, 1);
                }
            }
            foreach (var s in dctSanat.Keys)
            {
                if (s.Length > 3)// && dctSanat[s] > 1)
                    chkbxlst_VahtiSanat.Items.Add(s + ":" + dctSanat[s], true);
            }
            string strTemp = chkbxlst_VahtiSanat.Items[0].ToString();
            TsStsLbl_Vahti_ToDo.Text = "Erot.Valm";

        }

        private void TB_Kerta_TextChanged(object sender, EventArgs e)
        {
            string strSana = TB_Kerta.Text;
            if (strSana != string.Empty)
            {
                int i = chkbxlst_VahtiSanat.Items.IndexOf(strSana);
                if (i != -1)
                    chkbxlst_VahtiSanat.SetSelected(i, true);
            }
        }

        private void Btn_Kuvaus_Click(object sender, EventArgs e)
        {
            RchTxtBx_Vahti.Visible = false;
            TbCnt_Vahti.Visible = true;
            WBrHilma.Visible = true;
            while(TbCnt_Vahti.TabPages.Count>1)
            {
                TbCnt_Vahti.TabPages.RemoveAt(1);
            }
            Application.DoEvents();
            List<Tarjous> lstEiSuodatetut = TarjousManager.lstKaikkiTajoukset.FindAll(x => x.strFiltered.ToLower().Contains("fa"));
            List<Tarjous> lstEiKuvaushaettu = lstEiSuodatetut.FindAll(x => x.strKuvaushaettu.ToLower().Contains("fa"));
            int iHakematta = lstEiKuvaushaettu.Count;
            int iHaettu = 1;
            //foreach (Tarjous vTarj in lstEiKuvaushaettu)
             for (int i=0;i< lstEiKuvaushaettu.Count;i++)
            
            {
                
                lbl_timer.Text = $"Vuorossa {iHaettu}/{iHakematta}";
                WebSivut WebS = new WebSivut();
                TabPage tab1 = WebS.LuoSivu(lstEiKuvaushaettu,i);
                TbCnt_Vahti.Controls.Add(tab1);
                iHaettu++;
                if(iHaettu%30==1)
                {
                    TbCnt_Vahti.Refresh();
                    Application.DoEvents();
                    break;
                }
            }
            //TsStsLbl_Vahti_ToDo.Text = "Haetaan Kuvauksia";
            //int iLoop = 0;
            //while (iLoop < TarjousManager.lstKaikkiTajoukset.Count)
            //{
            //    if (TarjousManager.lstKaikkiTajoukset[iLoop].strMaaraAika.CompareTo(DateTime.Now.AddDays(1).ToString("yyyyMMdd_HHmm")) == -1)
            //    {
            //        TarjousManager.lstKaikkiTajoukset[iLoop].strFiltered = "True";
            //        TarjousManager.lstKaikkiTajoukset[iLoop].bPoista = true;

            //    }
            //    if (TarjousManager.lstKaikkiTajoukset[iLoop].strMaaraAika.Contains("9999"))
            //    {
            //        TarjousManager.lstKaikkiTajoukset[iLoop].strFiltered = "True";
            //        TarjousManager.lstKaikkiTajoukset[iLoop].bPoista = true;
            //    }
            //    if (TarjousManager.lstKaikkiTajoukset[iLoop].bPoista)
            //    {
            //        TarjousManager.lstKaikkiTajoukset.RemoveAt(iLoop);
            //    }
            //    else
            //        iLoop++;
            //}
            //Tmr_Vahti.Interval = iInterKuvaus;
            //this.Tmr_Vahti.Tick -= new System.EventHandler(this.Tmr_Vahti_Tick);
            //this.Tmr_Vahti.Tick += new System.EventHandler(this.Tmr_VahtiKuvaus_Tick);
            //Tmr_Vahti.Start();
            //Tmr_SivuVahti.Enabled = true;
            //Tmr_SivuVahti.Interval = iInterSivu;
            //Tmr_SivuVahti.Start();
            TsStsLbl_Vahti_ToDo.Text = "Kuvaus.Valm";
        }
        private void Tmr_VahtiKuvaus_Tick(object sender, EventArgs e)
        {
            int iSivuja = TarjousManager.lstKaikkiTajoukset.Count;
            if (iSivu >= iSivuja)
            {
                Tmr_Vahti.Stop();
                lbl_timer.Text = "Timer stop" + " (" + lstHilmaWebPages.Count + ")";
                if (lstHilmaWebPages.Count > 0)
                {
                    WBrHilma.Navigate(lstHilmaWebPages[0]);
                    PG_Vahti.Text = lstHilmaWebPages[0];
                }
            }
            else
            {
                Tarjous clTarj = TarjousManager.lstKaikkiTajoukset[iSivu];
                {
                    if (clTarj.strFiltered.ToLower().Contains("false")
                     && clTarj.strKuvaushaettu.ToLower().Contains("false"))
                    {
                        if (clTarj.strAlkuperainenLinkki.ToLower().Contains("tarjouspalve"))
                        {
                            Trace.WriteLine("OK");
                        }
                        Trace.WriteLine("C: " + clTarj.strAlkuperainenLinkki);
                        if (clTarj.strAlkuperainenLinkki.ToLower().Contains("pienhankinta"))
                        {
                            string strKuv = clPienHankinta.GetKuvaus(clTarj.strAlkuperainenLinkki);
                            clTarj.strKuvaus = strKuv;
                            clTarj.strKuvaushaettu = "True";
                        }
                        else if (clTarj.strAlkuperainenLinkki.ToLower().Contains("dpsIlmoitus"))
                        {
                            WebBrowser wb = new WebBrowser();
                            wb.Name = clTarj.ToString().ToLower();
                            wb.Navigated += DSP_Navigated;
                            //wb.DocumentCompleted += KuvausKokonaan;
                            wb.Navigate(clTarj.strAlkuperainenLinkki);
                            lstBrowsers.Add(wb);
                        }
                        else if (clTarj.strAlkuperainenLinkki.ToLower().Contains("tpperustie"))
                        {
                            //string strLinkki = clTarj.strAlkuperainenLinkki;TPPerustiedot
                            //string strKuv = clPienHankinta.GetKuvaus(clTarj.strAlkuperainenLinkki);
                            ///tpTiivistelma.aspx?p=279&g=6401877d-ad30-42de-aa87-03f986c64811
                            WebBrowser wb = new WebBrowser();
                            wb.Name = clTarj.ToString().ToLower();
                            wb.Navigated += Kuvaus_Navigated;
                            //wb.DocumentCompleted += KuvausKokonaan;

                            wb.Navigate(clTarj.strAlkuperainenLinkki);
                            lstBrowsers.Add(wb);
                            //lstHilmaWebPages.Add(clTarj.strAlkuperainenLinkki);

                        }
                        else if (clTarj.strAlkuperainenLinkki.ToLower().Contains("hankintailmoi"))
                        {


                            //lstHilmaWebPages.Add(clTarj.strAlkuperainenLinkki + "details");
                            lstHilmaWebPages.Add(clTarj.strAlkuperainenLinkki + "details");
                            //iSivu = iSivuja;
                        }
                        //else if (clTarj.strAlkuperainenLinkki.ToLower().Contains("tarjouspalve"))
                        //{

                        //    if (clTarj.strAlkuperainenLinkki.Contains("p=13&"))
                        //    {
                        //        int a = 0;
                        //    }
                        //    //lstHilmaWebPages.Add(clTarj.strAlkuperainenLinkki + "details");
                        //    lstHilmaWebPages.Add(clTarj.strAlkuperainenLinkki);
                        //    //iSivu = iSivuja;
                        //}

                    }
                iSivu++;
                }
                lbl_timer.Text = "Timer Running: webs opened:" + iSivu + "/" + iSivuja + " (" + lstHilmaWebPages.Count + ")";

            }
        }
        private void Hilma_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;

            //get our browser reference
            WebBrowser browser = sender as WebBrowser;

            //WebBrowser snd = (WebBrowser)sender;
            string strSisalto = browser.DocumentText;

            Trace.WriteLine($"Puretaan Sivua {browser.Url.ToString()}");
        }

        private void Kuvaus_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            WebBrowser browser = sender as WebBrowser;
            string strSisalto = browser.DocumentText;
            browser.Navigated -= Kuvaus_Navigated;
            browser.DocumentCompleted += KuvausKokonaan;
            string strUri = browser.Url.ToString();
            ///tpTiivistelma.aspx?p=279&g=6401877d-ad30-42de-aa87-03f986c64811
            strUri = strUri.Replace("TPPerustiedot", "tpTiivistelma");
            //strUri = strUri.Remove(strUri.LastIndexOf("&"));

            ////if (browser.Name.Contains("p=1295&"))
            ////    strAkliniurl = strUri.ToString();
            ////if (browser.Name.Contains("p=279&"))
            ////    strHankiurl = strUri.ToString();
            browser.Navigate(strUri);
        }
        private void KuvausAlku(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //check that the full document is finished
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;

            //get our browser reference
            WebBrowser browser = sender as WebBrowser;

            //WebBrowser snd = (WebBrowser)sender;
            string strSisalto = browser.DocumentText;
            Trace.WriteLine($"Puretaan Sivua {browser.Name}");

            //string strKuv = clTarjouspalvelu.GetKuvaus(strSisalto);
            //Tarjous clTarj = TarjousManager.lstKaikkiTajoukset.Find(x => x.ToString().ToLower().Equals(browser.Name));
            //clTarj.strKuvaus = strKuv;
            //clTarj.strKuvaushaettu = "True";
        }
        private void KuvausKokonaan(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //check that the full document is finished
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            //get our browser reference
            WebBrowser browser = sender as WebBrowser;

            //WebBrowser snd = (WebBrowser)sender;
            string strSisalto = browser.DocumentText;
            Trace.WriteLine($"Puretaan Sivua {browser.Name}");

            string strKuv = clTarjouspalvelu.GetKuvaus(strSisalto);
            Tarjous clTarj = TarjousManager.lstKaikkiTajoukset.Find(x => x.ToString().ToLower().Equals(browser.Name));
            if (clTarj is null) return;
            clTarj.strKuvaus = strKuv;
            clTarj.strKuvaushaettu = "True";
        }
        private void DSP_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;

            //get our browser reference
            WebBrowser browser = sender as WebBrowser;

            //WebBrowser snd = (WebBrowser)sender;
            string strSisalto = browser.DocumentText;
            Trace.WriteLine($"Puretaan Sivua {browser.Name}");

            string strKuv = clTarjouspalvelu.GetKuvaus(strSisalto);
            Tarjous clTarj = TarjousManager.lstKaikkiTajoukset.Find(x => x.ToString().ToLower().Equals(browser.Name));
            clTarj.strKuvaus = strKuv;
            clTarj.strKuvaushaettu = "True";
        }

        private void Tmr_SivuVahti_Tick(object sender, EventArgs e)
        {
            char[] charsToTrim = { ' ', '\"' };
            if (!bHilmaLaukaistu)
            {
                if ((WBrHilma.Document.Body != null) &&
                    (WBrHilma.Document.Body.InnerHtml != null))
                {
                    if (WBrHilma.Document.Body.InnerHtml.ToLower().IndexOf("<table") != -1)
                    {
                        Tmr_SivuVahti.Stop();
                        bHilmaLaukaistu = true;
                        //MessageBox.Show("FOUND");
                        //Tmr_SivuVahti.Enabled = false;

                    }
                }

            }
            else
            {
                //foreach(var tps in lstHilmaWebPages)
                //{
                WebBrowser wb = WBrHilma;
                Trace.WriteLine($"Sivu: {wb.Url.ToString()}");
                if (wb.Document != null &&
                    wb.Document.Body != null)
                {
                    if (wb.Document.Body.InnerHtml.ToLower().IndexOf("vertbar") > -1)
                    {
                        string strLowerText = wb.Document.Body.InnerHtml.ToLower();
                        Tarjous clNyt = null;
                        foreach (Tarjous clTar in TarjousManager.lstKaikkiTajoukset)
                        {
                            string strOsallistuminen = clTar.strAlkuperainenLinkki.ToLower();

                            if (wb.Url.ToString().ToLower().Contains(strOsallistuminen))
                            {
                                clNyt = clTar;
                                break;
                            }
                        }                    //ilmoittautumislinkki
                        if (strLowerText.IndexOf("hankinta-asiakirjat") > -1)
                        {
                            //<a data-v-06571bbd="" href="https://tarjouspalvelu.fi/jns?id=308245&amp;tpk=59add8db-e654-4ad8-aa1f-a66ba054f72d" rel="external" 
                            //take link up
                            strLowerText = strLowerText.Remove(0, strLowerText.IndexOf("hankinta-asiakirjat"));
                            int iStart = strLowerText.IndexOf("href=");
                            if (iSivu > -1)
                            {

                                strLowerText = strLowerText.Remove(0, iStart);
                                strLowerText = strLowerText.Remove(strLowerText.IndexOf(" "));
                                strLowerText = strLowerText.Replace("href=", " ");
                                strLowerText = strLowerText.Trim(charsToTrim).Replace("&amp;", "&");
                                // we must know which offer is now and is there same offer in otherlinks.

                                //EI TOIMI KOSKA EI SAMALLAINEN
                                clNyt.strVaihtoehtoLinkki = strLowerText;
                                if (strLowerText.ToLower().Contains("tarjouspalvelu.fi"))
                                    clNyt.strFiltered = "true";

                            }

                        }
                        apu++;
                        strLowerText = wb.Document.Body.InnerHtml.ToLower();
                        //if lyhyt kuvaus take that in kuvaus
                        string strLKuv = "lyhyt kuvaus";
                        if (strLowerText.IndexOf(strLKuv) > -1)
                        {
                            strLowerText = strLowerText.Remove(0, strLowerText.IndexOf(strLKuv) + strLKuv.Length);
                            strLowerText = strLowerText.Remove(0, strLowerText.IndexOf(strLKuv) + strLKuv.Length);
                            strLowerText = strLowerText.Remove(strLowerText.IndexOf("hankintanimikkeistö"));
                            while (strLowerText.IndexOf('<') > -1)
                            {
                                strLowerText = strLowerText.Remove(strLowerText.IndexOf('<'), strLowerText.IndexOf('>') - strLowerText.IndexOf('<') + 1);
                            }
                            clNyt.strKuvaushaettu = "true";
                            clNyt.strKuvaus = strLowerText;
                            if (lstHilmaWebPages.Count > 0 &&
                                wb.Document.Body.InnerHtml.ToLower().Contains(lstHilmaWebPages[0]))
                                lstHilmaWebPages.RemoveAt(0);

                        }
                        else
                        {
                            strLKuv = "ilmoituksen kohteen kuvaus";
                            if (strLowerText.IndexOf(strLKuv) > -1)
                            {
                                strLowerText = strLowerText.Remove(0, strLowerText.IndexOf(strLKuv) + strLKuv.Length);
                                strLowerText = strLowerText.Remove(0, strLowerText.IndexOf(strLKuv) + strLKuv.Length);
                                strLowerText = strLowerText.Remove(strLowerText.IndexOf("aluekoodi"));
                                while (strLowerText.IndexOf('<') > -1)
                                {
                                    strLowerText = strLowerText.Remove(strLowerText.IndexOf('<'), strLowerText.IndexOf('>') - strLowerText.IndexOf('<') + 1);
                                }
                                clNyt.strKuvaushaettu = "true";
                                clNyt.strKuvaus = strLowerText;
                                if (lstHilmaWebPages.Count > 0 &&
                                    wb.Document.Body.InnerHtml.ToLower().Contains(lstHilmaWebPages[0]))
                                    lstHilmaWebPages.RemoveAt(0);
                            }

                        }

                        //if (clNyt.strFiltered.ToLower().Contains("fa"))
                        //{
                        Tmr_SivuVahti.Stop();

                        if (lstHilmaWebPages.Count > 0)
                        {
                            if (lstHilmaWebPages.Count % 10 == 0)
                                Btn_Talleta_Click(new object(), new EventArgs());
                            Btn_Kuvaus_Click(new object(), new EventArgs());
                            //WBrHilma.Navigate(lstHilmaWebPages[0] + "details");
                            //PG_Vahti.Text = lstHilmaWebPages[0];
                        }
                        else
                            PG_Vahti.Text = "Haettu";
                        //}
                    }
                    else //if (wb.Document.Body.InnerHtml.ToLower().IndexOf("vertbar") > -1)
                    {
                        if (wb.Url.ToString().ToLower().Contains("tarjpuspal"))
                        {
                            int a = 0;
                        }
                    }
                }
                //}
            }
        }

        private void WBrHilma_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            if (bHilmaLaukaistu)
                Tmr_SivuVahti.Start();
        }

        private void ChkBx_Vahti_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox snd = sender as CheckBox;
            if (snd.Checked == true)
                btn_Kasittele.Text = "Uusi";
            else
                btn_Kasittele.Text = "Käsittele";
        }

        private void btn_Kasittele_Click(object sender, EventArgs e)
        {
            if (ChckBx_Uusi.Enabled == false)
                return;
            Tarjous clUusi = new Tarjous();
            if (btn_Kasittele.Text.Equals("Uusi"))
            {
                TarjousManager.lstKaikkiTajoukset.Add(clUusi);
                clUusi.kyseinen(clUusi);
            }
            else
            {
                if (RchTxtBx_Vahti.Visible)
                {
                    clUusi.kyseinen(clUusi);
                }
                else if (WBrHilma.Visible)
                {
                    //dynamic document = WBrHilma.Document.DomDocument;
                    //dynamic selection = document.selection;
                    //string text = selection.createRange().htmlText;
                    //string strEtsi = text.Remove(0, text.IndexOf("ink_") + "ink_".Length);
                    //strEtsi = strEtsi.Remove(strEtsi.IndexOf(">"));
                    //int inro;
                    //bool bOk = int.TryParse(strEtsi, out inro);
                    //if (!bOk) return;
                    //Tarjous clEtsi = TarjousManager.lstKaikkiTajoukset.Find(x => x.iTarjNro == inro);
                    //clUusi.kyseinen(clEtsi);
                    List<Tarjous> lstEiSuodatetut = TarjousManager.lstKaikkiTajoukset.FindAll(x => x.strFiltered.ToLower().Contains("fa"));
                    foreach (Tarjous clTar in lstEiSuodatetut)
                    {
                        string strId = clTar.iTarjNro.ToString();
                        var cl = WBrHilma.Document.GetElementById(strId).OuterHtml;
                        var cs = WBrHilma.Document.GetElementById(strId + "_S").OuterHtml;
                        if (cl.ToLower().Contains("checked") || cs.ToLower().Contains("checked"))
                        {
                            //clTar.strFiltered = "true";
                            clUusi.kyseinen(clTar);
                            break;
                        }
                    }

                }

            }
            Frm_Tarjous frm_tar = new Frm_Tarjous();
            frm_tar.Show();
        }

        private void Btn_TalletaRaportti_Click(object sender, EventArgs e)
        {
            string strTemp = WBrHilma.DocumentText;
            //Automaattiseksi päiväys (Tiistille)
            DateTime dtNyt = DateTime.Now;
            //DayOfWeek DayOfWeek = dtNyt.DayOfWeek;
            while (dtNyt.DayOfWeek != DayOfWeek.Tuesday)
                dtNyt = dtNyt.AddDays(1);
            File.WriteAllText(@"D:\InnoOk_AH\Avoimia_hankkeita " + dtNyt.ToString("yyyyMMdd") + ".html", strTemp);
        }

        private void Frm_Vahti_Main_Load(object sender, EventArgs e)
        {
            _textBoxListener = new TextBoxTraceListener(TxtTrace);
            Trace.Listeners.Add(_textBoxListener);
        }

        private void TxtTrace_TextChanged(object sender, EventArgs e)
        {
            TxtTrace.SelectionStart = TxtTrace.Text.Length;
            TxtTrace.ScrollToCaret();
        }

        private void tsbtn_Hilma_Click(object sender, EventArgs e)
        {

        }

        private void tsbtn_Pien_Click(object sender, EventArgs e)
        {
            

        }

        private void tsbtn_tarjous_Click(object sender, EventArgs e)
        {

        }

        private void TSp_Btn_TarjInfo_Click(object sender, EventArgs e)
        {

        }

        private void btn_EiKiinnosta_Click(object sender, EventArgs e)
        {

            List<Tarjous> lstEiSuodatetut = TarjousManager.lstKaikkiTajoukset.FindAll(x => x.strFiltered.ToLower().Contains("fa"));
            foreach(Tarjous clTar in lstEiSuodatetut)
            {
                string strId = clTar.iTarjNro.ToString();
                var cl = WBrHilma.Document.GetElementById(strId).OuterHtml;
                var cs = WBrHilma.Document.GetElementById(strId+"_S").OuterHtml;
                if(cl.ToLower().Contains("checked")|| cs.ToLower().Contains("checked"))
                {
                    clTar.strFiltered = "true";
                }
            }
            //var g = document.getElementById("GFG").value;
            btn_Rapotti_Click(sender, e);
        }
    }
}
