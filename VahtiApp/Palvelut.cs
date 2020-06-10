using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Globalization;
using HtmlAgilityPack;
using System.Linq;

namespace VahtiApp
{
    internal class Palvelut
    {
        protected UriBuilder uriBuilder { get; set; }
        protected Uri uri { get; set; }
        protected string strEtusivu { get; set; }
        protected List<string> lstrAlasivut;
        //public string strTempClient { get; set; }
        //public string strTempRest { get; set; }
        public List<Tarjous> lstTajoukset;
        public Palvelut()
        {
            lstrAlasivut = new List<string>();
            lstTajoukset = new List<Tarjous>();
        }
        public Palvelut(string inHost, string inPath)
        {

        }
        //public void EtusivuHttpWebRequest()

        public bool GetWebPage()
        {
            strEtusivu = string.Empty;
            Console.WriteLine(uri);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);

            var data = reader.ReadToEnd();

            strEtusivu = data;
            return true;
        }
        internal int sivuja() { return lstrAlasivut.Count; }
        internal virtual bool PuraEtusivu() { return false; }
        internal virtual bool PuraAlaSivut() { return false; }
        internal virtual bool PuraTarjousSivut() { return false; }
        protected bool ListastaÄäkösetPois()
        {
            if (lstrAlasivut.Count == 0) return false;
            for (int iLoop = 0; iLoop < lstrAlasivut.Count; iLoop++)
            {

                lstrAlasivut[iLoop] = lstrAlasivut[iLoop].ToLower()
                                               .Replace("-", "")
                                               .Replace("ä", "a")
                                               .Replace("ö", "o")
                                               .Replace("å", "a")
                                               ;
            }
            return true;

        }
        public void EtusivuWebClient()

        {
            strEtusivu = string.Empty;
            var client = new WebClient();
            client.Headers.Add("User-Agent", "C# console program");


            string content = client.DownloadString(uri.ToString());

            strEtusivu = content;
        }
        public void EtusivuWebClientDLS()
        {
            strEtusivu = string.Empty;
            var client = new WebClient();

            client.DownloadStringCompleted += (sender, e) =>
            {
                strEtusivu = e.Result;
            };


            client.DownloadStringAsync(uri);

            //Console.ReadLine();
        }

        public void EtusivuRestRequest()
        {
            strEtusivu = string.Empty;
            var client = new RestClient(uri);
            var request = new RestRequest("", Method.GET);

            client.ExecuteAsync(request, response => { strEtusivu = response.Content; });

            //Console.ReadLine();
        }
        internal virtual List<string> HtmlToList(string strHtml)
        {
            List<string> lstRetVal = new List<string>();

            //var doc = new HtmlAgilityPack.HtmlDocument();
            //doc.LoadHtml(strHtml);
            //HtmlNode firstTable = doc.DocumentNode.SelectSingleNode("//table");
            //var orderedCellTexts = firstTable.Descendants("tr")
            //    .Select(row => row.SelectNodes("th|td").Take(2).ToArray())
            //    .Where(cellArr => cellArr.Length == 2)
            //    .Select(cellArr => new { Cell1 = cellArr[0].InnerText, Cell2 = cellArr[1].InnerText })
            //    .OrderBy(x => x.Cell1)
            //    .ToList();

            return lstRetVal;
        }
    }
}