using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VahtiApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hilma clHilma = new Hilma();
            //clHilma.HaeEtusivu();
            //Console.ReadLine();
            PienHankinta clPienHankinta = new PienHankinta();
            Console.WriteLine("Alku");
            string strEHWReq="Ohi";
            bool bOk=clPienHankinta.GetWebPage();
            Console.WriteLine($"GetWebPage {bOk}");
            if (bOk) bOk = clPienHankinta.PuraEtusivu();
            Console.WriteLine($"PuraEtusivu {bOk} sivuja {clPienHankinta.sivuja()}");
            if (bOk) bOk = clPienHankinta.PuraAlaSivut();
            Console.WriteLine($"PuraAlaSivut {bOk}");
            Console.WriteLine("strEHWReq");
            foreach(var clTar in clPienHankinta.lstTajoukset)
            {
                Console.WriteLine(clTar);
            }
            //string strECli = clPienHankinta.EtusivuWebClient();
            //Console.WriteLine("strECli");
            //clPienHankinta.EtusivuWebClientDLS();
            //string strECliDls = clPienHankinta.strTempClient;
            //Console.WriteLine("strECliDls");
            //clPienHankinta.EtusivuRestRequest();
            //string strERest = clPienHankinta.strTempRest;
            //Console.WriteLine("strERest");
            Console.ReadLine();
            //TarjousPalvelu clTarjousPalvelu = new TarjousPalvelu();
            //clTarjousPalvelu.HaeEtusivu();
            //Console.ReadLine();
        }
    }
}
