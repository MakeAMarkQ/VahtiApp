using System;
using System.Globalization;

namespace VahtiApp
{
    internal class Tarjous : IComparable<Tarjous>
    {
        public const int LuokkaVersion = 20200610;
        public string strKunta;
        public string strTunnus { get; set; }
        public string strAlkuperainenLinkki { get; set; }
        public string strTajousDocLinkki { get; set; }
        public string strTarjousDirLinkki { get; set; }
        public string strPyynto { get; set; }
        public string strKuvaus { get; set; }
        public string strMaaraAika
        {
            get { return dtMaaraAika.ToString("yyyyMMdd_HHmm"); }
            //set { dtAika = DateTime.ParseExact(value, "dd.MM.yyyy HH:mm:ss", null); } 
            set
            {
                if (value.Contains("_"))
                {
                    dtMaaraAika = DateTime.ParseExact(value, "yyyyMMdd_HHmm", new CultureInfo("fi-FI"));
                }
                else
                if (value.Contains("."))
                {
                    if (!value.Contains("mää"))
                        dtMaaraAika = Convert.ToDateTime(value, new CultureInfo("fi-FI"));
                    else
                        dtMaaraAika = new DateTime(3000, 12, 31, 23, 59, 59);
                }
            }
        }

        public string strDataBase { get; internal set; }
        public string strJulkaistu
        {
            get { return dtJulkaistu.ToString("yyyyMMdd_HHmm"); }
            //set { dtAika = DateTime.ParseExact(value, "dd.MM.yyyy HH:mm:ss", null); } 
            set
            {
                if(value.Contains("_"))
                {
                    dtJulkaistu = DateTime.ParseExact(value, "yyyyMMdd_HHmm", new CultureInfo("fi-FI"));
                }
                else
                if (value.Contains("."))
                {
                    if (!value.Contains("jul"))
                        dtJulkaistu = Convert.ToDateTime(value, new CultureInfo("fi-FI"));
                    else
                        dtJulkaistu = DateTime.Now;
                }

            }
        }
        public string strFiltered { get { return bFiltered.ToString(); }
            internal set { bFiltered=value.ToLower().Equals("true"); } }
        public string strIlmoitusTyyppi { get; internal set; }

        private DateTime dtMaaraAika;
        private DateTime dtJulkaistu;
        private bool bFiltered;

        public Tarjous()
        {
            strKunta = "N/A";
            strTunnus = "N/A";
            strAlkuperainenLinkki = "N/A";
            strTajousDocLinkki = "N/A";
            strTarjousDirLinkki = "N/A";
            strPyynto = "N/A";
            strKuvaus = "N/A";
            strMaaraAika = "31.12.9999 23:59:00";
            strJulkaistu = DateTime.Today.ToString();
            strDataBase = "N/A";
            strFiltered = "false";
            strIlmoitusTyyppi= "N/A";


        }
        public Tarjous(string inKunta, string inTyyppi):this()
        {
            
            strKunta = inKunta;
            strIlmoitusTyyppi = inTyyppi;
        }
        public void VaihdaYksikko(string inKunta)
        {
            this.strKunta = inKunta;
        }
        public override string ToString()
        {

            return strMaaraAika + ":" + strPyynto + " (" + strKunta + ")";// + strTunnus +" = "+ strLinkki;
        }
        public int CompareTo(Tarjous other)
        {
            if (other == null) return -1;
            if (this.dtMaaraAika < other.dtMaaraAika) return -1;
            if ((this.dtMaaraAika == other.dtMaaraAika)
                && (this.strPyynto.CompareTo(other.strPyynto) == 1)) return -1;
            return 1;
        }
    }
}