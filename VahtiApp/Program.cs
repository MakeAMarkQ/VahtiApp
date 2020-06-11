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
            //PienHankinta clPienHankinta = new PienHankinta();
            TarjousPalvelu clPienHankinta = new TarjousPalvelu();
            Console.WriteLine("Alku");
            string strEHWReq="Ohi";
            bool bOk=clPienHankinta.GetWebPage();
            Console.WriteLine($"GetWebPage {bOk}");
            if (bOk) bOk = clPienHankinta.PuraEtusivu();
            Console.WriteLine($"PuraEtusivu {bOk} sivuja {clPienHankinta.sivuja()}");
            if (bOk) bOk = clPienHankinta.PuraAlaSivut();
            Console.WriteLine($"PuraAlaSivut {bOk}");
            //Console.WriteLine("strEHWReq");
            //clPienHankinta.lstTajoukset.Sort();
            //foreach (var clTar in clPienHankinta.lstTajoukset)
            //{
            //    Console.WriteLine(clTar);
            //}


            Console.ReadLine();
            
        }
    }
}
