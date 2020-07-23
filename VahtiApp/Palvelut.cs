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
using System.Diagnostics;

namespace VahtiApp
{
    internal class Palvelut
    {
        protected UriBuilder uriBuilder { get; set; }
        protected Uri uri { get; set; }
        protected string strEtusivu { get; set; }
        protected string strSivuTiedosto { get; set; }
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
            Trace.WriteLine(uri);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);

            var data = reader.ReadToEnd();

            strEtusivu = data;
            return true;
        }
        internal int sivuja() { return lstrAlasivut.Count; }
        internal virtual bool PuraEtusivu() { Trace.WriteLine("Virtual-PuraEtusivu"); return false; }
        internal virtual bool PuraAlaSivut() { Trace.WriteLine("Virtual-PuraAlaSivut"); return false; }
        internal virtual bool PuraAlaSivut(string strTmp, string strPK) { Trace.WriteLine("Virtual-PuraAlaSivut"); return false; }
        internal virtual bool PuraTarjousSivut() { Trace.WriteLine("Virtual-PuraTarjousSivut"); return false; }
        internal virtual bool PuraTarjousSivut(string strTmp) { Trace.WriteLine("Virtual-PuraTarjousSivut"); return false; }
        internal virtual string Tallenne() { Trace.WriteLine("Virtual-PuraTarjousSivut"); return "N/A"; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool LataaTiedot(string inSivut)
        {
            //lstrAlasivut
            if (File.Exists(inSivut))
            {
                string[] asSivut = File.ReadAllLines(inSivut);
                lstrAlasivut.AddRange(asSivut.ToList());
                return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool TallennaTiedot(string inSivut)
        {
            File.WriteAllLines(inSivut, lstrAlasivut.ToArray());
            return true;
        }
        protected bool ListastaÄäkösetPois()
        {
            if (lstrAlasivut.Count == 0) return false;
            for (int iLoop = 0; iLoop < lstrAlasivut.Count; iLoop++)
            {

                lstrAlasivut[iLoop] = lstrAlasivut[iLoop].ToLower()
                                               //.Replace("-", "")
                                               .Replace("ä", "a")
                                               .Replace("ö", "o")
                                               .Replace("å", "a")
                                               ;
            }
            return true;

        }



        internal virtual List<string> HtmlToList(string strHtml)
        {
            List<string> lstRetVal = new List<string>();

            return lstRetVal;
        }
        internal virtual string GetKuvaus(string strUri)
        {
            return string.Empty; ;
        }
    }
}