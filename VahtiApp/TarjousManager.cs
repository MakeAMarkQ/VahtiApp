using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VahtiApp
{
    class TarjousManager
    {
        public static List<Tarjous> lstKaikkiTajoukset;
        public TarjousManager() { }
        public TarjousManager(List<Tarjous> TarMng) 
        {
            lstKaikkiTajoukset= TarMng;
        }
        public List<Tarjous> HaeLista()
        {
            return lstKaikkiTajoukset;
        }
    }
}
