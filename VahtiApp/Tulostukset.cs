using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VahtiApp
{
    class Tulostukset
    {
        public Tulostukset()
        {

        }
        public string HTMLAlku(int ikpl,int iAllkpl)
        {
            string strRetVal = "<!DOCTYPE html PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" " + Environment.NewLine;
            strRetVal += "\"http://www.w3.org/TR/html4/transitional.dtd\">" + "<br>"+Environment.NewLine;
            strRetVal += "<html>" +Environment.NewLine;
            strRetVal += "<head>" +Environment.NewLine;
            strRetVal += " <meta http - equiv = \"content -type\" content = \"text /html; charset=utf-8\"> " +Environment.NewLine;
            strRetVal += "<title> Avoimet hankinnat jatkuvat</title>" +Environment.NewLine;
            strRetVal += "<meta name = \"generator\" content = \"Vahti 1.0.0.0 (Windows)\"> " +Environment.NewLine;
            strRetVal += "<meta name = \"created\" content = \"2020-07-30T19:55:44.123456789\"> " +Environment.NewLine;
            strRetVal += "<meta name = \"changed\" content = \"2020-07-30T19:55:44.123456789\"> " +Environment.NewLine;
            strRetVal += "</head>" +Environment.NewLine;
            strRetVal += " <body>" +Environment.NewLine;
            strRetVal += "<h1> Avoimet hankinnat " + DateTime.Today.ToString("dd.MM.yyyy")+ " ("+ikpl.ToString()+"/"+ iAllkpl.ToString() + ")";
            strRetVal += "</h1>" + "<br>"+Environment.NewLine;
            strRetVal += "<b> Hiukan ohjeita alkuun, <a href = \"#Lista\"> " +
                "uudet kohteet </a></b><br>" + "<br>"+Environment.NewLine;

            strRetVal += " Ei muuta kuin tarjouksia lisää tekemään<br> " + Environment.NewLine +
                "<ul>"+Environment.NewLine;
            
            return strRetVal;
        }

        internal string HTMLLoppu()
        {
            string strRetVal = "</ul>" +Environment.NewLine + 
                "</body>" +Environment.NewLine +
                "</html> " +Environment.NewLine;
            
            return strRetVal;
        }
        internal string HTMLErotin()
        {
            string strRetVal = "</ul>" +Environment.NewLine +
                "<hr>" +Environment.NewLine +
                "<ul> " +Environment.NewLine;

            return strRetVal;
        }
        internal string HTMLVanhat()
        {
            string strRetVal = "</ul>Edelleen auki<br>" + "<br>" + Environment.NewLine;
            strRetVal += "<ul>" + "<br>" + Environment.NewLine;

            return strRetVal;
        }
    }
}
