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
        private readonly string strSuodatin = "Suodatin.txt";
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
            Tarjous clTarTemp = new Tarjous();
            // tänne myös hakujen filterointi
            if (CBx_Hilma.Checked == true && !bHilma)
            {
                lstKaikkiTajoukset.AddRange(clTarTemp.UudetTarjoukset(lstKaikkiTajoukset, clHilma.lstTajoukset));
                bHilma = true;
            }
            if (CBx_Pien.Checked == true && !bPienhankinta)
            {
                lstKaikkiTajoukset.AddRange(clTarTemp.UudetTarjoukset(lstKaikkiTajoukset, clPienHankinta.lstTajoukset));
                bPienhankinta = true;
            }
            if (CBx_Tarjous.Checked == true && !bTarjouspalvelu)
            {
                lstKaikkiTajoukset.AddRange(clTarTemp.UudetTarjoukset(lstKaikkiTajoukset, clTarjouspalvelu.lstTajoukset));
                bTarjouspalvelu = true;
            }
            lbl_Tarjouksia.Text = lstKaikkiTajoukset.Count().ToString();
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
            //lstKaikkiTajoukset.AddRange(clHilma.lstTajoukset);
            //bHilma = true;
            CBx_Hilma.Checked = true;
        }

        private void Frm_Vahti_Main_Shown(object sender, EventArgs e)
        {
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
            Btn_Suodata_Click(sender, e);
            Btn_Erotele_Sanat_Click(sender, e);
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
                List<Tarjous> lstEiSuodatetut = lstKaikkiTajoukset.FindAll(x => x.strFiltered.ToLower().Contains("fa"));
                int iCount = lstEiSuodatetut.Count;
                foreach (Tarjous clTarj in lstEiSuodatetut)
                {
                    if (RTxtBx_Vahti.Text.ToLower().IndexOf(strSana) == -1)
                        continue;
                    bool bPyynt = clTarj.strPyynto.ToLower().Contains(strSana);
                    bool bKuva = clTarj.strKuvaus.ToLower().Contains(strSana);
                    if (bPyynt ||
                            bKuva)
                    {
                        clTarj.strFiltered = "True";
                        iCount--;
                        TsStpLbl_Vahti.Text = iCount.ToString();
                        int iLine = 0;

                        TSSttsBr_Vahti.Maximum = RTxtBx_Vahti.Lines.Count() / 100;
                        TSSttsBr_Vahti.Value = 0;
                        string strTemp = string.Empty;
                        while (iLine < RTxtBx_Vahti.Lines.Count())
                        {
                            if (RTxtBx_Vahti.Lines[iLine].Contains(clTarj.ToString()))
                            {
                                //RTxtBx_Vahti.SelectionStart = RTxtBx_Vahti.GetFirstCharIndexFromLine(iLine);
                                //RTxtBx_Vahti.SelectionLength = this.RTxtBx_Vahti.Lines[iLine].Length + 1;
                                //this.RTxtBx_Vahti.SelectedText = String.Empty;
                            }
                            else
                            {
                                strTemp += RTxtBx_Vahti.Lines[iLine] + Environment.NewLine;
                            }
                            iLine++;
                            if (iLine % 100 == 0)
                            {
                                TSSttsBr_Vahti.Value = iLine / 100;
                                Application.DoEvents();
                            }
                        }
                        RTxtBx_Vahti.Text = strTemp;
                        RTxtBx_Vahti.Refresh();
                        //continue;
                    }
                }
                Btn_Talleta_Click(sender, e);
            }
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
            List<Tarjous> lstEiSuodatetut = lstKaikkiTajoukset.FindAll(x => x.strFiltered.ToLower().Contains("fa"));
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
                    TsStsLbl_Vahti_ToDo.Text = "Suodattaa " + strSana.Substring(0, 4);
                    if (RTxtBx_Vahti.Text != string.Empty &&
                        RTxtBx_Vahti.Text.ToLower().IndexOf(strSana) == -1)
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
                    //if (clTarj.strPyynto.ToLower().Contains("vähittäismyynnistä"))
                    //    iLoop = iLoop + 0;
                    if (clTarj.strPyynto.ToLower().Contains(strSana) ||
                        clTarj.strKuvaus.ToLower().Contains(strSana))
                    {

                        clTarj.strFiltered = "True";
                        iCount--;
                        TsStpLbl_Vahti.Text = iCount.ToString();
                        int iLine = 0;
                        string strTemp = string.Empty;
                        while (iLine < RTxtBx_Vahti.Lines.Count())
                        {
                            if (RTxtBx_Vahti.Lines[iLine].Contains(clTarj.ToString())
                                || RTxtBx_Vahti.Lines[iLine].Length == 2)
                            {
                                //RTxtBx_Vahti.SelectionStart = RTxtBx_Vahti.GetFirstCharIndexFromLine(iLine);
                                //RTxtBx_Vahti.SelectionLength = this.RTxtBx_Vahti.Lines[iLine].Length + 1;
                                //this.RTxtBx_Vahti.SelectedText = String.Empty;
                            }
                            else
                            {
                                strTemp += RTxtBx_Vahti.Lines[iLine] + Environment.NewLine;
                            }
                            iLine++;
                        }
                        RTxtBx_Vahti.Text = strTemp;
                        RTxtBx_Vahti.Refresh();
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
            TsStsLbl_Vahti_ToDo.Text = "Listaa Tarjoukset";
            WBrHilma.Visible = false;
            RTxtBx_Vahti.Visible = true;
            RTxtBx_Vahti.Clear();
            lstKaikkiTajoukset.Sort();
            List<Tarjous> lstEiSuodatetut = lstKaikkiTajoukset.FindAll(x => x.strFiltered.ToLower().Contains("fa"));
            TsStpLbl_Vahti.Text = lstEiSuodatetut.Count.ToString();
            TSSttsBr_Vahti.Maximum = lstEiSuodatetut.Count / 10;
            TSSttsBr_Vahti.Value = 0;
            int iLoop = 0;
            foreach (Tarjous clTarj in lstEiSuodatetut)
            {
                RTxtBx_Vahti.Text += clTarj.ToString() + Environment.NewLine;
                if (iLoop % 10 == 0)
                {
                    TSSttsBr_Vahti.Value = iLoop / 10;
                    Application.DoEvents();
                }
                iLoop++;
            }
            TsStsLbl_Vahti_ToDo.Text = "Tarj.Valm";
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

        private void RTxtBx_Vahti_SelectionChanged(object sender, EventArgs e)
        {
            RichTextBox RTBXtemp = (RichTextBox)sender;
            TB_Kerta.Text = RTBXtemp.SelectedText;
        }

        private void Btn_Erotele_Sanat_Click(object sender, EventArgs e)
        {
            TsStsLbl_Vahti_ToDo.Text = "Erottele Sanat";
            List<string> lstTemp = new List<string>();
            char[] charsToTrim = { ',', '.', ':', ';', ' ', '/', '(', ')', '{', '}', '%', '!',
                                   '\n', '\r', '\"', '\'', '+', '-', '\u201C', '\u201D',
                                   '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                                   '€', '£', '$' };//8220 & 8221
            SortedDictionary<string, int> dctSanat = new SortedDictionary<string, int>();
            foreach (var clTarjous in lstKaikkiTajoukset)
            {
                string[] arWords = clTarjous.strPyynto.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var strIter in arWords)
                {
                    string strWord = strIter.Replace("&quot;", "!").Trim(charsToTrim).ToLower();
                    if (strWord.Contains("ervic"))
                        lstTemp.Add(strWord);
                    if (lstTemp.Count == 17)
                        continue;
                    if (dctSanat.ContainsKey(strWord))
                        dctSanat[strWord]++;
                    else
                        dctSanat.Add(strWord, 0);
                }
                arWords = clTarjous.strKuvaus.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var strIter in arWords)
                {
                    string strWord = strIter.Replace("&quot;", "!").Trim(charsToTrim).ToLower();
                    if (strWord.Contains("ervic"))
                        lstTemp.Add(strWord);
                    if (lstTemp.Count == 17)
                        continue;
                    if (dctSanat.ContainsKey(strWord))
                        dctSanat[strWord]++;
                    else
                        dctSanat.Add(strWord, 0);
                }
            }
            foreach (var s in dctSanat.Keys)
            {
                if (s.Length > 3)// && dctSanat[s] > 1)
                    chkbxlst_VahtiSanat.Items.Add(s + ":" + dctSanat[s], true);
            }
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
            TsStsLbl_Vahti_ToDo.Text = "Haetaan Kuvauksia";
            int iLoop = 0;
            while (iLoop < lstKaikkiTajoukset.Count)
            {
                if (lstKaikkiTajoukset[iLoop].strMaaraAika.CompareTo(DateTime.Now.ToString("yyyyMMdd_HHmm")) == -1)
                {
                    lstKaikkiTajoukset[iLoop].strFiltered = "True";
                    lstKaikkiTajoukset[iLoop].bPoista = true;

                }
                if (lstKaikkiTajoukset[iLoop].strMaaraAika.Contains("9999"))
                {
                    lstKaikkiTajoukset[iLoop].strFiltered = "True";
                    lstKaikkiTajoukset[iLoop].bPoista = true;
                }
                if (lstKaikkiTajoukset[iLoop].bPoista)
                {
                    lstKaikkiTajoukset.RemoveAt(iLoop);
                }
                else
                    iLoop++;
            }
            TsStpLbl_Vahti.Text = lstKaikkiTajoukset.Count.ToString();
            foreach (Tarjous clTarj in lstKaikkiTajoukset)
            {
                if (clTarj.strFiltered.ToLower().Contains("true"))
                {
                    if (clTarj.strAlkuperainenLinkki.ToLower().Contains("pienhankinta"))
                    {
                        Trace.WriteLine("C: " + clTarj.strAlkuperainenLinkki);
                        string strKuv = clPienHankinta.GetKuvaus(clTarj.strAlkuperainenLinkki);
                        clTarj.strKuvaus = strKuv;
                    }
                    else if (clTarj.strAlkuperainenLinkki.ToLower().Contains("tarjouspal"))
                    {
                        string strLinkki = clTarj.strAlkuperainenLinkki;
                        string strKuv = clPienHankinta.GetKuvaus(clTarj.strAlkuperainenLinkki);
                        ///tpTiivistelma.aspx?p=279&g=6401877d-ad30-42de-aa87-03f986c64811
                        //WebBrowser wb = new WebBrowser();
                        //wb.Name = clTarj.strPyynto;
                        //wb.Navigated += Kuvaus_Navigated;
                        //wb.DocumentCompleted += KuvausKokonaan;
                        //wb.Navigate(clTarj.strAlkuperainenLinkki);
                        break;
                    }
                    else if (clTarj.strAlkuperainenLinkki.ToLower().Contains("hankintailmoi"))
                    {

                    }
                }



            }
            TsStsLbl_Vahti_ToDo.Text = "Kuvaus.Valm";
        }
        private void Kuvaus_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            WebBrowser browser = sender as WebBrowser;
            string strSisalto = browser.DocumentText;
            //browser.Navigated -= webBrowser_Navigated;
            //browser.DocumentCompleted += KuvausKokonaan;
            //string strUri = browser.Url.ToString();
            //strUri = strUri.Replace("default.aspx", "tarjouspyynnot.aspx");
            ////if (browser.Name.Contains("p=1295&"))
            ////    strAkliniurl = strUri.ToString();
            ////if (browser.Name.Contains("p=279&"))
            ////    strHankiurl = strUri.ToString();
            //browser.Navigate(strUri);
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
            //if (clTarjouspalvelu.PuraAlaSivut(strSisalto, browser.Name))
            //{
            //    //if divfooter missing , page is not ok
            //    //detach the event handler from the browser
            //    //note: necessary to stop endlessly setting strings and clicking buttons
            //    browser.DocumentCompleted -= KuvausKokonaan;
            //    //attach second DocumentCompleted event handler to destroy browser
            //    webBrowserTuhoaKokonaisuus(sender, e);
            //}
        }
    }
}
