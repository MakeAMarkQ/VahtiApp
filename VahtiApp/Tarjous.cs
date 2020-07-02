using System;
using System.Globalization;

namespace VahtiApp
{
    internal class Tarjous : IComparable<Tarjous>
    {
        public const int LuokkaVersion = 20200610;
        private string strKunta;
        public string strTunnus { get; set; }
        public string strAlkuperainenLinkki { get; set; }
        public string strTajousDocLinkki { get; set; }
        public string strTarjousDirLinkki { get; set; }
        public string strPyynto { get; set; }
        public string strKuvaus { get; set; }
        public string strAika 
        { get { return dtAika.ToString("yyyyMMdd_HHmm"); }
            //set { dtAika = DateTime.ParseExact(value, "dd.MM.yyyy HH:mm:ss", null); } 
            set {dtAika = Convert.ToDateTime(value, new CultureInfo("fi-FI"));}
        }
        private DateTime dtAika;
        public bool bFiltered;

        public Tarjous(string strKunta)
        {
            this.strKunta = strKunta;
            strTunnus = "N/A";
            strAlkuperainenLinkki = "N/A";
            strTajousDocLinkki = "N/A";
            strTarjousDirLinkki = "N/A";
            strPyynto = "N/A";
            strKuvaus = "N/A";
            strAika = "31.12.9999 23:59:00";
            bFiltered = false;
        }
        public void VaihdaYksikko(string inKunta)
        {
            this.strKunta = inKunta;
        }
        public override string ToString()
        {

            return  strAika + ":"+  strPyynto + " (" + strKunta+")";// + strTunnus +" = "+ strLinkki;
        }
        public int CompareTo(Tarjous other)
        {
            if(other == null) return -1;
            if (this.dtAika < other.dtAika) return -1;
            if ((this.dtAika == other.dtAika)
                && (this.strPyynto.CompareTo(other.strPyynto)==1)) return -1;
            return 1;
        }
    }
}