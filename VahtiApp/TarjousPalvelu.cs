using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Web.UI;

namespace VahtiApp
{
    internal class TarjousPalvelu : Palvelut
    {
        //https://tarjouspalvelu.fi/Default/Index
        //Special caset
        //https://tarjouspalvelu.fi/tarjouspyynnot.aspx?p=279&g=4255edad-e038-4620-ba0d-6c62a78a5cb8
        //https://tarjouspalvelu.fi/tarjouspyynnot.aspx?p=1701&g=9b94cbe2-fe1c-4765-a3b7-2a2e8ed680de
        private string strUriAlku = "https://tarjouspalvelu.fi/";
        public TarjousPalvelu()
        {
            uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "https";
            uriBuilder.Host = "tarjouspalvelu.fi";
            uriBuilder.Path = "Default/Index";
            uri = uriBuilder.Uri;
            strSivuTiedosto = "TPSivut.txt";
        }
        public TarjousPalvelu(string inHost, string inPath)
        {
        }
        /// <summary>
        /// https://tarjouspalvelu.fi/tarjouspyynnot.aspx?p=279&g=4255edad-e038-4620-ba0d-6c62a78a5cb8
        /// Hanki: 279 & PPY:1701 https://tarjouspalvelu.fi/tarjouspyynnot.aspx?p=1701&g=9b94cbe2-fe1c-4765-a3b7-2a2e8ed680de
        /// g= 8 hex - 4hex - 4hex - 4hex - 12hex
        /// </summary>
        /// <returns></returns>
        internal bool SuodataLista()
        {
            if (lstrAlasivut.Count == 0) return false;
            //lstrAlasivut.Clear();
            lstrAlasivut.Add("hanki,279");//Hankisivu not in frontpage
            return ListastaÄäkösetPois();



        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Uri> TeeUriLista()
        {
            List<Uri> lstUrit = new List<Uri>();
            lstrAlasivut.Sort();
            foreach (string strIterSivu in lstrAlasivut)
            {


                string[] strPalat = strIterSivu.Split(new char[] { ',' });
                Trace.WriteLine($"Käsitellään Sivua {strPalat[0]}");

                Uri uri2Builder = new Uri(strUriAlku + strPalat[0]);

                //uri2Builder.UserInfo = strIterSivu;
                //uri = uriBuilder.Uri;
                //lstUrit.Add(uri);
                lstUrit.Add(uri2Builder);
            }
            return lstUrit;
        }
        ///<table border="0" cellpadding="5" cellspacing="10" width="100%" style="font-family:Verdana;font-size:11pt;">
        ///<tr><td style = "border:1px dotted black;text-align:center;width:33%;" >
        ///        < a href="https://tarjouspalvelu.fi/2m" target="_self">
        ///        <img src = "/Default/Image/1632" alt="" border="0" />
        ///        <p style = "font-weight:bold;text-align:center;" > 2M - IT Oy</p>
        ///        </a>
        ///     </td>
        ///     ...
        /// </tr>
        /// </table> => 
        /// https://tarjouspalvelu.fi/default.aspx?p=1632&g=ed371efb-e367-4944-9801-29ffa61e089d
        /// https://tarjouspalvelu.fi/tarjouspyynnot.aspx?p=1632&g=ed371efb-e367-4944-9801-29ffa61e089d
        /// We are intrest only number of image source
        internal override bool PuraEtusivu()
        {
            string strOtsikko = "</table>";
            int iOtsikkoPit = strOtsikko.Length;
            int iTauluPaikka = strEtusivu.IndexOf("<table");
            if (-1 == iTauluPaikka)
                return false;
            //...<map id="map" name="map" >...
            strEtusivu = strEtusivu.Remove(0, iTauluPaikka);
            //name="map" >... => find first </map>" 
            iTauluPaikka = strEtusivu.IndexOf(strOtsikko) + strOtsikko.Length;
            if (-1 == iTauluPaikka)
                return false;
            //remove all letters after </map>, starting with < 
            strEtusivu = strEtusivu.Remove(iTauluPaikka);
            List<List<string>> table = new List<List<string>>();
            table.Add(HtmlToList(strEtusivu));
            lstrAlasivut.AddRange(table[0]);
            return true;

        }

        internal string HaeUriName(string inUri)
        {
            inUri = inUri.Remove(0, inUri.LastIndexOf("/") + 1);
            for (int i = 0; i < lstrAlasivut.Count; i++)
            {
                if (lstrAlasivut[i].Contains(inUri))
                    return lstrAlasivut[i];
            }
            return "N/A";
        }
        internal Uri HaeNameUri(string inName)
        {
            inName = inName.Remove(inName.LastIndexOf(","));
            return new Uri(strUriAlku + inName);

        }
        /// <summary>
        /// Table to Html
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        internal override List<string> HtmlToList(string strHtml)
        {
            string strKunta = string.Empty;
            char[] charsToTrim = { '{', ' ', '}', '\n', '\r', '\"' };
            List<string> lstRetVal = new List<string>();

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(strHtml);
            HtmlNode firstTable = doc.DocumentNode.SelectSingleNode("//table");


            //    //List<HtmlAgilityPack.HtmlNode[]>
            List<List<HtmlAgilityPack.HtmlNode>> lstTaulukonSolujenTekstit = firstTable.Descendants("tr")
                .Select(row => row.SelectNodes("th|td").ToList())
                .ToList();
            List<string> lstSarakeNimet = new List<string>();
            bool bOtsikot = false;


            foreach (var Rivi in lstTaulukonSolujenTekstit)
            {
                int i = 0;
                string strRivi = string.Empty;
                foreach (var Solu in Rivi)
                {
                    string strVal = Solu.InnerHtml.Replace(',', ' ').Replace("&#228;", "ä").Replace("&#246;", "ö").Replace("&#196;", "Ä");

                    if (-1 != strVal.IndexOf("Image/"))
                    {
                        //<img src="/Default/Image/1632" alt="" border="0" />
                        string strId = strVal.Remove(strVal.IndexOf("alt=")).Remove(0, strVal.IndexOf("Image/")).Replace("Image/", " ").Trim(charsToTrim);
                        //<a href="https://tarjouspalvelu.fi/2m" target="_self">
                        //if (strId.Contains("1295"))
                        //    i = i;
                        string strNimi = strVal.Remove(strVal.IndexOf("target=")).Remove(0, strVal.IndexOf("tarjouspalvelu.fi/")).Replace("tarjouspalvelu.fi/", " ").Trim(charsToTrim);
                        //string strNimi = strVal.Remove(strVal.IndexOf("target=")).Remove(0, strVal.IndexOf("href=")).Replace("href=", " ").Trim(charsToTrim);
                        Trace.WriteLine(strNimi + "," + strId);
                        lstRetVal.Add(strNimi + "," + strId);
                    }
                    else
                    { //pages
                        //first table colums names;
                        string strUusi = strVal.Replace("&nbsp;", " ");
                        if (strUusi.Length == 1) continue;
                        if (!bOtsikot)
                        {
                            lstSarakeNimet.Add(strUusi);
                        }
                        else
                        {
                            if (i == lstSarakeNimet.Count)
                                lstSarakeNimet.Add(i.ToString());
                            strRivi += lstSarakeNimet[i].ToLower() + ":=" + strUusi.Trim(charsToTrim);
                            if (i < Rivi.Count)
                                strRivi += "][";
                            i++;

                        }



                    }

                }
                if (bOtsikot && lstSarakeNimet.Count != 0)
                    lstRetVal.Add(strRivi);
                bOtsikot = true;


            }

            return lstRetVal;

        }
        /// <summary>
        /// there are two pages:
        /// <table width = "100%" height="100%" cellspacing="0" cellpadding="0" border="0">
        ///  <tbody><tr>
        ///   <td><img src = "/Content/images/spacer.gif" width="20" height="1"></td>
        ///   ...
        ///   <td><a id = "ctl00_PageContent_AvaaHaku".... Siirry hakuun &gt;&gt;</span></a>
        ///   ...
        ///   </table> 
        ///   Remove all before Siirry hakuun >> text. Next remofe text before first </table>. 
        /// 1. div divFoorte contains company 
        /// </summary>
        /// <returns></returns>
        internal override bool PuraAlaSivut(string strEtusivu, string strPaikka)
        {
            string strEtiEka = "divFooter";
            string strEti1ka = "KelpuuttamisJarjestelmaDivi";
            string strEti2ka = "ctl00_PageContent_DPSListaPanel";// "DPSIlmoituslista_wrapper";
            string strEti3ka = "ctl00_PageContent_GridView1_wrapper";
            string strEti4ka = "ctl00_PageContent_MuutIlmOts";
            //if (!strPaikka.Equals("caruna,p=191")) return true;
            //bool bOk = false;
            int iOnPaikalla = strEtusivu.LastIndexOf(strEtiEka);
            if (-1 == iOnPaikalla)
            {
                Trace.WriteLine($"Virhe {strEtiEka}");
                return false;
            }
            //long lLen = strEtusivu.LongCount();
            //
            strEtusivu = strEtusivu.Remove(iOnPaikalla);
            List<int> iPaikalla = new List<int>();
            if (-1 != strEtusivu.IndexOf(strEti1ka))
                iPaikalla.Add(strEtusivu.IndexOf(strEti1ka));
            if (-1 != strEtusivu.IndexOf(strEti2ka))
                iPaikalla.Add(strEtusivu.IndexOf(strEti2ka));
            if (-1 != strEtusivu.IndexOf(strEti3ka))
                iPaikalla.Add(strEtusivu.IndexOf(strEti3ka));
            if (-1 != strEtusivu.IndexOf(strEti4ka))
                iPaikalla.Add(strEtusivu.IndexOf(strEti4ka));

            if (iPaikalla.Count == 0)
            {
                Trace.WriteLine($"Ei Tarjouspyyntöjä");
                return true;
            }
            //We don't know the order
            iPaikalla.Sort();
            iPaikalla.Reverse();
            //start biggest number, remove if used
            List<string> strPala = new List<string>();
            foreach (int iVal in iPaikalla)
            {
                strPala.Add(strEtusivu.Remove(0, iVal));
                strEtusivu = strEtusivu.Remove(iVal);
            }

            String strKunta = strPaikka.Remove(strPaikka.IndexOf(","));
            char[] charsToTrim = { '{', ' ', '}', '\n', '\r' };
            List<string> table = new List<string>();
            string strTableEnd = "</table>";
            foreach (string strDiv in strPala)
            {
                if (-1 != strDiv.IndexOf(strTableEnd))
                {
                    string apuSivu = strDiv.Remove(strDiv.IndexOf(strTableEnd) + strTableEnd.Length);
                    apuSivu = apuSivu.Remove(0, apuSivu.IndexOf("<table"));
                    table.AddRange(HtmlToList(apuSivu));
                }
            }
            //tablepurku

            foreach (var strRivi in table)
            {
                string[] asOsat = strRivi.Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
                Tarjous clTarjous = new Tarjous(strKunta, "Tarjouspalvelu");
                foreach (var strOsa in asOsat)
                {
                    string[] asOppi = strOsa.Split(new string[] { ":=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (asOppi.First().ToLower().Contains("yksi"))
                    {
                        strKunta = asOppi.Last().Remove(asOppi.Last().LastIndexOf("</"));
                        strKunta = strKunta.Remove(0, strKunta.LastIndexOf(">") + 1);
                        clTarjous.VaihdaYksikko(strKunta);
                    }
                    if (asOppi.First().ToLower().Contains("tunn"))
                    {
                        string strTemp = asOppi.Last().Remove(asOppi.Last().LastIndexOf("</"));
                        strTemp = strTemp.Remove(0, strTemp.LastIndexOf(">") + 1);
                        clTarjous.strTunnus = strTemp;
                        strTemp = asOppi.Last().Remove(0, asOppi.Last().IndexOf("href=") + 6);
                        strTemp = strTemp.Remove(strTemp.IndexOf(" ") - 1);
                        strTemp = strTemp.TrimStart('/');
                        strTemp = strTemp.TrimEnd('\"');
                        strTemp = strTemp.Replace("&amp;", "&");
                        clTarjous.strAlkuperainenLinkki = strUriAlku + strTemp;
                    }
                    if (asOppi.First().ToLower().Contains("ilmo"))
                    {
                        string strTemp = asOppi.Last();
                        if (-1 != asOppi.Last().LastIndexOf("</a"))
                        {
                            strTemp = strTemp.Remove(asOppi.Last().LastIndexOf("</a"));
                            strTemp = strTemp.Remove(0, strTemp.LastIndexOf(">") + 1);
                        }
                        clTarjous.strPyynto = strTemp;
                    }
                    if (asOppi.First().ToLower().Contains("kuvaus"))
                    {
                        string strTemp = asOppi.Last();
                        if (-1 != asOppi.Last().LastIndexOf("style="))
                        {
                            strTemp = asOppi.Last().Remove(asOppi.Last().LastIndexOf("style="));
                            strTemp = strTemp.Remove(0, strTemp.LastIndexOf("title=") + "title=".Length);
                        }
                        clTarjous.strKuvaus = strTemp;

                    }
                    if (asOppi.First().ToLower().Contains("määrä"))
                    {
                        string strTemp = asOppi.Last();
                        if (strTemp.LastIndexOf("</") != -1)
                        {
                            strTemp = strTemp.Remove(strTemp.LastIndexOf("</"));
                            strTemp = strTemp.Remove(0, strTemp.LastIndexOf(">") + 1);
                        }
                        clTarjous.strMaaraAika = strTemp;
                    }

                }
                clTarjous.strDataBase = "TP";
                lstTajoukset.Add(clTarjous);

            }
            return true;

        }
        internal override string Tallenne() { return strSivuTiedosto; }
        internal virtual string GetKuvaus(string inTeksiti)
        {

            char[] charsToTrim = { '{', ' ', '}', '\n', '\r' };
            string strKuvaus = inTeksiti.Remove(0, inTeksiti.IndexOf("ctl00_PageContent_valKuvaus"));
            strKuvaus = strKuvaus.Remove(strKuvaus.IndexOf("</tr>"));
            strKuvaus = strKuvaus.Replace("</span>", " ").Replace("<br>", " ");
            strKuvaus = strKuvaus.Remove(strKuvaus.IndexOf("</td>"));
            strKuvaus = strKuvaus.Remove(0, strKuvaus.IndexOf(">") + 1);
            strKuvaus = strKuvaus.Replace("&#228;", "ä").Replace("&#246;", "ö").Replace("&#196;", "Ä").Replace("&#214", "í");
            strKuvaus = strKuvaus.Replace("\r", " ").Replace("\n", " ");
            strKuvaus = strKuvaus.Trim(charsToTrim);
            return strKuvaus;
        }

    }


}