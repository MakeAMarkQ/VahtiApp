using System;
using System.Collections.Generic;
using System.Globalization;

namespace VahtiApp
{
    internal class Tarjous : IComparable<Tarjous> , IEquatable<Tarjous>
    {
        public const int LuokkaVersion = 20200610;
        public string strKunta;
        public string strTunnus { get; set; }
        public string strAlkuperainenLinkki { get; set; }
        public string strTajousDocLinkki { get; set; }
        public string strTarjousDirLinkki { get; set; }
        private string strPrivPyynto;
        public string strPyynto 
        { get { 
                return strPrivPyynto.Replace("\r", " ").Replace("\n", " ");
            }
            set
            {
                
              strPrivPyynto = value.Replace("\r", " ").Replace("\n", " ");
                
            }
        }
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
                    {
                        dtMaaraAika = new DateTime(3000, 12, 31, 23, 59, 59);
                        strFiltered = "true";
                    }
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
        public bool bPoista;

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
            bPoista = false;


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

            return strMaaraAika + ":" + strPyynto + " (" + strKunta + ")["+strDataBase+"]";// + strTunnus +" = "+ strLinkki;
        }
        public int CompareTo(Tarjous inOther)
        {
            if (inOther == null) return -1;
            if (this.dtMaaraAika < inOther.dtMaaraAika) return -1;
            if (this.dtMaaraAika == inOther.dtMaaraAika)
                return this.strPyynto.CompareTo(inOther.strPyynto);
            return 1;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Tarjous objAsPart = obj as Tarjous;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public bool Equals(Tarjous inTarjous)
        {
            if (inTarjous == null) return false;
            if (!strMaaraAika.Equals(inTarjous.strMaaraAika))
                return false;
            else if (!strPyynto.Equals(inTarjous.strPyynto))
                return false;
            else if (!strKunta.Equals(inTarjous.strKunta))
                return false;
            else
                return true;
        }
        internal List<Tarjous> UudetTarjoukset(List<Tarjous> inKaikki, List<Tarjous> inUudet)
        {
            List<Tarjous> lstUudet = new List<Tarjous>();
            foreach(var inTarjous in inUudet)
            {
                if(!inKaikki.Contains(inTarjous))
                {
                    lstUudet.Add(inTarjous);
                }
            }
            return lstUudet;
        }

    }
}