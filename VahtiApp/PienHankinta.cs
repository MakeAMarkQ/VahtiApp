using RestSharp;
using System;
using System.Configuration;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace VahtiApp
{
    /// <summary>
    ///Maakunnat: 1) https://pienhankintapalvelu.fi/notfound/Default/Index
    ///Ahvenmaa, Kainuu...
    ///Itse lista: 2) https://pienhankintapalvelu.fi/lappi/HankintaYksikonPienHankinnat/PienHankintaLista
    /// lowercase & (etelä-savo=>) etelasavo 
    /// </summary>
    internal class PienHankinta : Palvelut
    {
        public string strPPalvelu = "https://pienhankintapalvelu.fi";
        //List<List<string>> table;
        /// <summary>
        /// Set uribuilder & uri
        /// </summary>
        public PienHankinta()
        {
            uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "pienhankintapalvelu.fi";
            uriBuilder.Path = "notfound/Default/Index";
            uri = uriBuilder.Uri;
            strSivuTiedosto = "PHSivut.txt";
            //table = new List<List<string>>();
        }

        /// <summary>
        /// There is several province in main page, and
        /// this collects all province pages their offers lists.
        /// </summary>
        /// <returns></returns>
        internal override bool PuraAlaSivut()
        {
            if (lstrAlasivut.Count == 0) return false;
            bool bOk = ListastaÄäkösetPois();
            foreach (string strIterSivu in lstrAlasivut)
            {
                //pienhankinta maakunnissa täytyy pistaa '-' merkit
                Trace.WriteLine($"Käsitellään maakuntaa {strIterSivu}");
                uriBuilder.Path = strIterSivu.Replace("-","") + "/HankintaYksikonPienHankinnat/PienHankintaLista";
                uri = uriBuilder.Uri;
                bOk = GetWebPage();
                if (!bOk) return false;
                bOk = PuraTarjousSivut();
                if (!bOk) return false;


            }
            return true;

        }
        /// <summary>
        /// there are two pages:
        ///     <h2>Voimassa olevat tarjouspyynn&#246;t</h2>
        ///     <div class="sivunohje"><b>Ahvenanmaa</b></div>
        /// 1. No offers => 
        ///     < span > Ei voimassa olevia pienhankintoja</span> KEYROW TO NO OFFERS
        /// 2. Offerlists=>
        ///     <table border="0" cellpadding="5" style="width:95%">
        ///     <tr>
        ///     <td><b>Oulun kaupunki</b></td> CITY
        ///     </tr>
        ///     </table>
        ///     <table id = "alaHankTable" border= "0" cellpadding= "5" style= "width:95%" >
        ///     <tr class="otsikkorivi"><th>Tunniste</th><th>Tarjouspyynt&#246;</th>
        ///     <th>Kuvaus</th><th>M&#228;&#228;r&#228;aika</th><th>&nbsp;</th></tr>
        ///     ...
        ///     <tr class="even">
        ///     <td><a class="linkki" href="/pohjoispohjanmaa/Tender/BasicInfo?tpg=8ba3a8e0-8f05-49db-b96d-c24e261410ce">300911</a>&nbsp;</td>
        ///     <td><a class="linkki" href="/pohjoispohjanmaa/Tender/BasicInfo?tpg=8ba3a8e0-8f05-49db-b96d-c24e261410ce">Saloisen koulun kotitalousluokan pienkoneet</a>&nbsp;        </td>
        ///     <td>Raahen kaupungin hankintapalvelut pyyt&#228;&#228; tarjouksia Saloisten koulun kotitalousluokan tarvikkeista.&nbsp;</td>
        ///     <td>10.06.2020 12:00</td>
        ///     <td><a class="linkki" href="/pohjoispohjanmaa/Tender/BasicInfo?tpg=8ba3a8e0-8f05-49db-b96d-c24e261410ce&amp;gen=False"><img alt = "Avaa" border="0" class="vertalignmid" src="/Content/images/bt_nuoli.gif" title="Avaa"></img></a>&nbsp;        </td>
        ///     </tr>
        ///     ...
        ///     </tbody>    </table>
        ///     All data to Class OFFERRQUEST.
        ///     IMPORTANT:Link,id,title,description,deadline. 
        ///     MORE:  City,offertime,last question day
        /// </summary>
        /// <returns></returns>
        /// 
        internal override bool PuraTarjousSivut()
        {
            string strEtiEka = "Voimassa olevat tarjouspyyn";
            string strEiPyyntöjä = "Ei voimassa olevia pienhankintoja";
            bool bOk = false;
            int iOnPaikalla = strEtusivu.IndexOf(strEiPyyntöjä);
            if (-1 < iOnPaikalla)
            {
                Trace.WriteLine($"Ei voimassa olevia pienhankintoja");
                return true; //It's a leagal state
            }
            iOnPaikalla = strEtusivu.IndexOf(strEtiEka);
            if (-1 == iOnPaikalla)
            {
                Trace.WriteLine($"Virhe {strEtiEka}");
                return false;
            }
            //
            strEtusivu = strEtusivu.Remove(0, iOnPaikalla);
            //first <table> ->
            iOnPaikalla = strEtusivu.IndexOf("<table");
            if (-1 == iOnPaikalla)
            {
                Trace.WriteLine($"Virhe <table");
                return false;
            }
            strEtusivu = strEtusivu.Remove(0, iOnPaikalla);
            //last </table> next
            iOnPaikalla = strEtusivu.LastIndexOf("</table>");
            if (-1 == iOnPaikalla)
            {
                Trace.WriteLine($"Virhe </table>");
                return false;
            }
            strEtusivu = strEtusivu.Remove(iOnPaikalla + "</table>".Length);
            List<List<string>> table = new List<List<string>>();
            String strKunta = string.Empty;
            char[] charsToTrim = { '{', ' ', '}', '\n', '\r' };
            while (true)
            {
                iOnPaikalla = strEtusivu.IndexOf("</table>");
                if (-1 == iOnPaikalla)
                {   //No more table ends
                    if (!bOk)
                    {
                        Trace.WriteLine($"Virhe </table>");
                        return false;
                    }
                    else
                    {
                        //make new lines from table.
                        foreach (List<string> tyot in table)
                        {
                            if (tyot[0].Contains("KN"))
                            {
                                strKunta = tyot[0].Remove(0, tyot[0].IndexOf("=") + 1).Replace("&#228;", "ä").Replace("&nbsp;", " ").Trim(charsToTrim);
                            }
                            else
                            {
                                tyot.RemoveAt(0);
                                foreach (string strOsa in tyot)
                                {
                                    //tyot[0].Trim(charsToTrim);

                                    string[] palat = strOsa.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                    Tarjous clTarjous = new Tarjous(strKunta,"PienHankinta");
                                    clTarjous.strAlkuperainenLinkki = palat[0].Remove(0, palat[0].LastIndexOf("=\"") + 2).Trim(charsToTrim);
                                    clTarjous.strAlkuperainenLinkki = strPPalvelu+clTarjous.strAlkuperainenLinkki.Remove(clTarjous.strAlkuperainenLinkki.IndexOf("\">"));
                                    clTarjous.strTunnus = palat[0].Remove(0, palat[0].IndexOf(">") + 1).Replace("&nbsp;", " ").Replace("</a>", " ").Trim(charsToTrim);
                                    clTarjous.strPyynto = palat[1].Remove(0, palat[1].IndexOf("=") + 1).Replace("&nbsp;", " ").Trim(charsToTrim);
                                    clTarjous.strKuvaus = palat[2].Remove(0, palat[2].IndexOf("=") + 1).Replace("&nbsp;", " ").Trim(charsToTrim);
                                    clTarjous.strMaaraAika = palat[3].Remove(0, palat[3].IndexOf("=") + 1).Replace("&nbsp;", " ").Trim(charsToTrim);
                                    //Must check if current offer is already in list
                                    clTarjous.strDataBase = "PH";
                                    lstTajoukset.Add(clTarjous);
                                }
                            }
                        }
                        return true;
                    }
                }
                string apuSivu = strEtusivu.Substring(0, iOnPaikalla + "</table>".Length);
                strEtusivu = strEtusivu.Remove(0, iOnPaikalla + "</table>".Length);
                table.Add(HtmlToList(apuSivu));
                bOk = true;
            }
            //return false; 
        }

        /// <summary>
        ///  <map id="map" name="map" >
        ///      <area alt="" title="Lappi" data-region="10" shape="poly" class="masterTooltip mapregion" coords=
        ///          ...
        ///      <area alt="" title="Ahvenanmaa" data-region="1" shape="poly" class="masterTooltip mapregion" coords="
        ///  </map>
        ///  Find first name="map"
        ///  Then next title, and its value
        ///  untill </map> is walking 
        /// </summary>
        /// <returns>
        /// List of new pages to collect data
        /// </returns>
        internal override bool PuraEtusivu()
        {
            string strOtsikko = "title =";
            int iOtsikkoPit = strOtsikko.Length;
            int iMapPaikka = strEtusivu.IndexOf("name=\"map\"");
            if (-1 == iMapPaikka)
                return false;
            //...<map id="map" name="map" >...
            strEtusivu = strEtusivu.Remove(0, iMapPaikka);
            //name="map" >... => find first </map>" 
            iMapPaikka = strEtusivu.IndexOf("</map>");
            if (-1 == iMapPaikka)
                return false;
            //remove all letters after </map>, starting with < 
            strEtusivu = strEtusivu.Remove(iMapPaikka);
            do
            {
                iMapPaikka = strEtusivu.IndexOf("title=");
                if (-1 == iMapPaikka)
                {
                    if (lstrAlasivut.Count == 0)
                        return false;
                    else
                        return true;
                }
                strEtusivu = strEtusivu.Remove(0, iMapPaikka + iOtsikkoPit);
                string strPaikka = strEtusivu.Substring(0, strEtusivu.IndexOf("\""));
                lstrAlasivut.Add(strPaikka);
            } while (true);

        }
        ///     <table border="0" cellpadding="5" style="width:95%">
        ///     <tr>
        ///     <td><b>Oulun kaupunki</b></td> CITY
        ///     </tr>
        ///     </table>
        ///     <table id = "alaHankTable" border= "0" cellpadding= "5" style= "width:95%" >
        ///     <tr class="otsikkorivi"><th>Tunniste</th><th>Tarjouspyynt&#246;</th>
        ///     <th>Kuvaus</th><th>M&#228;&#228;r&#228;aika</th><th>&nbsp;</th></tr>

        internal override List<string> HtmlToList(string strHtml)
        {
            List<string> lstRetVal = new List<string>();

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(strHtml);
            HtmlNode firstTable = doc.DocumentNode.SelectSingleNode("//table");

            if ("" == firstTable.Id)
            {
                var orderedCellTexts = firstTable.Descendants("tr")
                    .Select(row => row.SelectNodes("th|td").Take(1).ToArray())
                    .Select(cellArr => new { KN = cellArr[0].InnerText })
                    .ToList();
                foreach (var Cell in orderedCellTexts)
                    lstRetVal.Add(Cell.ToString());
            }
            else
            {
                var orderedCellTexts = firstTable.Descendants("tr")
                    .Select(row => row.SelectNodes("th|td").Take(4).ToArray())
                    .Select(cellArr => new
                    {
                        ID = cellArr[0].InnerHtml.Replace(',', ' ').Replace("&#228;", "ä").Replace("&#246;", "ö").Replace("&#196;", "Ä"),
                        TP = cellArr[1].InnerText.Replace(',', ' ').Replace("&#228;", "ä").Replace("&#246;", "ö").Replace("&#196;", "Ä"),
                        KU = cellArr[2].InnerText.Replace(',', ' ').Replace("&#228;", "ä").Replace("&#246;", "ö").Replace("&#196;", "Ä"),
                        MA = cellArr[3].InnerText.Replace(',', ' ')
                    })
                     .ToList();
                foreach (var Cell in orderedCellTexts)
                    lstRetVal.Add(Cell.ToString());
            }

            return lstRetVal;
        }
        private string puraKuvausSivut(string inTeksiti)
        {
            //<tr>
            //< td class="bold">Hankinnan kuvaus:</td>
            //<td>
            //Tarjouskilpailu koskee ruokakuljetuksia 
            //Tarjouskilpailun kohde on m&#228;&#228;ritelty tarjouskilpailuasiakirjassa: ”PALVELUKUVAUS”.                    
            //</td>
            //</tr>
            char[] charsToTrim = { '{', ' ', '}', '\n', '\r' };
            string strKuvaus = inTeksiti.Remove(0, inTeksiti.IndexOf("Hankinnan kuvaus"));
            strKuvaus = strKuvaus.Remove(strKuvaus.IndexOf("</tr>"));
            strKuvaus = strKuvaus.Remove(0, strKuvaus.IndexOf("<td"));
            strKuvaus = strKuvaus.Remove(strKuvaus.IndexOf("</td>"));
            strKuvaus = strKuvaus.Remove(0, strKuvaus.IndexOf(">")+1);
            strKuvaus = strKuvaus.Replace("&#228;", "ä").Replace("&#246;", "ö").Replace("&#196;", "Ä").Replace("&#214", "í"); ;
            strKuvaus = strKuvaus.Replace("\r", " ").Replace("\n", " ");
            strKuvaus = strKuvaus.Trim(charsToTrim);
            return strKuvaus;
        }
        internal virtual string GetKuvaus(string strUri)
        {
            string strEtusivu = string.Empty;
            Uri uri = new Uri(strUri);

            Trace.WriteLine(uri);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);

            var data = reader.ReadToEnd();

            strEtusivu = puraKuvausSivut(data);

            return strEtusivu;
        }
    }
}