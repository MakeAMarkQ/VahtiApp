using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace VahtiApp
{
    internal class Hilma : Palvelut
    {
        //https://www.hankintailmoitukset.fi/fi/search?
        //top=75&nuts=FI1D&nuts=FI1C3&
        //pa=2020-06-02&of=datePublished&od=desc
        private string strHilma= "https://www.hankintailmoitukset.fi";
        public Hilma()
        {
            uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "www.hankintailmoitukset.fi";
            uriBuilder.Path = "top=75&nuts=FI1D&nuts=FI1C&pa=2020-06-02&of=datePublished&od=desc";
            uri = uriBuilder.Uri;
        }
        public Hilma(string inHost, string inPath)
        {

        }
        internal override bool PuraAlaSivut(string strEtusivu, string strPaikka)
        {
            string strEtiEka = "<table";
            string strEti1ka = "</table>";

            bool bOk = false;
            int iOnPaikalla = strEtusivu.LastIndexOf(strEtiEka);
            if (-1 == iOnPaikalla)
            {
                Trace.WriteLine($"Virhe {strEtiEka}");
                return false;
            }
            ////long lLen = strEtusivu.LongCount();
            //
            strEtusivu = strEtusivu.Remove(0, iOnPaikalla);
            //List<int> iPaikalla = new List<int>();
            iOnPaikalla = strEtusivu.IndexOf(strEti1ka);
            if (-1 != strEtusivu.IndexOf(strEti1ka))
                strEtusivu = strEtusivu.Remove(iOnPaikalla + strEti1ka.Length);



            char[] charsToTrim = { '{', ' ', '}', '\n', '\r','[',']' };
            List<string> table = new List<string>();

            table.AddRange(HtmlToList(strEtusivu));

            ////tablepurku
            string strKunta = strPaikka;
            foreach (var strRivi in table)
            {
                string[] asOsat = strRivi.Trim(charsToTrim).Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries); ;
                Tarjous clTarjous = new Tarjous(strKunta,"Hilma");
                foreach (var strOsa in asOsat)
                {
                    string[] asOppi = strOsa.Split(new string[] { ":=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (asOppi.First().ToLower().Contains("db"))
                    {
                        string strTemp = asOppi.Last();
                        clTarjous.strDataBase = strTemp;
                    }
                    if (asOppi.First().ToLower().Contains("lnk"))
                    {
                        string strTemp = asOppi.Last();
                        clTarjous.strAlkuperainenLinkki = strHilma+strTemp;
                    }
                    if (asOppi.First().ToLower().Contains("nimi"))
                    {
                        string strTemp = asOppi.Last();
                        clTarjous.strPyynto = strTemp;
                    }
                    if (asOppi.First().ToLower().Contains("julk"))
                    {
                        string strTemp = asOppi.Last();
                        clTarjous.strJulkaistu = strTemp;

                    }
                    if (asOppi.First().ToLower().Contains("määrä"))
                    {
                        string strTemp = asOppi.Last();
                        clTarjous.strMaaraAika = strTemp;
                    }
                    
                    if (asOppi.First().ToLower().Contains("ilmo"))
                    {
                        string strTemp = asOppi.Last();
                        clTarjous.strIlmoitusTyyppi = strTemp;
                    }
                    if (asOppi.First().ToLower().Contains("osta"))
                    {
                        strKunta = asOppi.Last();
                        
                        clTarjous.VaihdaYksikko(strKunta);
                    }


                }
                lstTajoukset.Add(clTarjous);

            }
            return false;

        }
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
                int iSoluNro = 0;
                string strRivi = string.Empty;

                foreach (var Solu in Rivi)
                {
                    string strUusi = Solu.InnerText.ToString();
                    //first table colums names;
                    if (!bOtsikot)
                    {
                        
                        strUusi = strUusi.Trim(charsToTrim);
                        if (0 == iSoluNro)
                            strUusi = "DB";
                        else if(1== iSoluNro)
                            lstSarakeNimet.Add("Lnk");
                        
                        lstSarakeNimet.Add(strUusi);
                        iSoluNro++;
                    }
                    else
                    {
                        if (iSoluNro == lstSarakeNimet.Count)
                            lstSarakeNimet.Add(iSoluNro.ToString());
                        if(1== iSoluNro)
                        {
                            string strLInkki = Solu.InnerHtml.ToString();
                            strLInkki = strLInkki.Remove(strLInkki.IndexOf(">") - 1);
                            strLInkki = strLInkki.Remove(0, strLInkki.IndexOf("=") + 1);
                            strLInkki = strLInkki.Trim('\"');
                            strRivi += "[";
                            strRivi += lstSarakeNimet[iSoluNro].ToLower() + ":=" + strLInkki;//.Trim(charsToTrim);
                            strRivi += "]";
                            iSoluNro++;
                        }
                        if (strUusi.ToLower().Contains(lstSarakeNimet[iSoluNro].ToLower()))
                            strUusi=strUusi.ToLower().Replace(lstSarakeNimet[iSoluNro].ToLower(), " ");
                        strRivi += "[";
                        strRivi += lstSarakeNimet[iSoluNro].ToLower() + ":=" + strUusi.Trim(charsToTrim);
                        strRivi += "]";
                        iSoluNro++;

                    }

                }
                if (bOtsikot && lstSarakeNimet.Count != 0)
                    lstRetVal.Add(strRivi);
                bOtsikot = true;


            }

            return lstRetVal;

        }
    }
}