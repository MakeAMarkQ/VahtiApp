using System;

namespace VahtiApp
{
    internal class Tarjous : IComparable<Tarjous>
    {
        private string strKunta;
        public string strTunnus { get; set; }
        public string strLinkki { get; set; }
        public string strPyynto { get; set; }
        public string strKuvaus { get; set; }
        public string strAika 
        { get { return dtAika.ToString("yyyyMMdd_HHmm"); }
          set { dtAika = DateTime.ParseExact(value, "dd.MM.yyyy HH:mm", null); } 
        }
        private DateTime dtAika;
        public bool bFiltered;

        public Tarjous(string strKunta)
        {
            this.strKunta = strKunta;
            strTunnus = default;
            strLinkki = default;
            strPyynto = default;
            strKuvaus = default;
            strAika = "31.12.9999 23:59";
            bFiltered = false;
        }
        public override string ToString()
        {

            return  strAika + ":"+  strPyynto + " (" + strKunta+")";// + strTunnus +" = "+ strLinkki;
        }
        public int CompareTo(Tarjous other)
        {
            if(other == null) return 1;
            if (this.dtAika < other.dtAika) return 1;
            if ((this.dtAika == other.dtAika)
                && (this.strPyynto.CompareTo(other.strPyynto)==1)) return 1;
            return -1;
        }
    }
}