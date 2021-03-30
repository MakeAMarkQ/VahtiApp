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
            strRetVal += "<script>" + Environment.NewLine;
            strRetVal += "function readMore(city)" + Environment.NewLine;
            strRetVal += "{" +Environment.NewLine;
            strRetVal += "    let dots = document.querySelector";
            strRetVal += "(`.card[data-city=\"${ city}\"] .dots`);" + Environment.NewLine;
            strRetVal += "    let moreText = document.querySelector(`.card[data - city = \"${ city}\"].more`); " + Environment.NewLine;
            strRetVal += "    let btnText = document.querySelector(`.card[data - city = \"${ city}\"].myBtn`); " + Environment.NewLine;
            strRetVal += "    if (dots.style.display === \"none\")  " + Environment.NewLine;
            strRetVal += "    {" + Environment.NewLine;
            strRetVal += "         dots.style.display = \"inline\"; " + Environment.NewLine;
            strRetVal += "         btnText.textContent = \"Read more\"; " + Environment.NewLine;
            strRetVal += "         moreText.style.display = \"none\"; " + Environment.NewLine;
            strRetVal += "    } " +Environment.NewLine;
            strRetVal += "    else " + Environment.NewLine;
            strRetVal += "    {" +Environment.NewLine;
            strRetVal += "        dots.style.display = \"none\"; " + Environment.NewLine;
            strRetVal += "        btnText.textContent = \"Read less\"; " + Environment.NewLine;
            strRetVal += "        moreText.style.display = \"inline\"; " + Environment.NewLine;
            strRetVal += "    }" +Environment.NewLine;
            strRetVal += "}" +Environment.NewLine;
            strRetVal += "</script>" + Environment.NewLine;
            strRetVal += "</head>" +Environment.NewLine;
            strRetVal += " <body>" +Environment.NewLine;
            strRetVal += "<h1> Avoimet hankinnat " + DateTime.Today.ToString("dd.MM.yyyy")+ " ("+ikpl.ToString()+"/"+ iAllkpl.ToString() + ")";
            strRetVal += "</h1>" + "<br>"+Environment.NewLine;
            strRetVal += "<b> Hiukan ohjeita alkuun, <a name = \"Lista\"> " +
                "uudet kohteet </a></b><br>" + "<br>"+Environment.NewLine;
            strRetVal += "<b><span style = \"color: red;\">Ehdoton must</span></b><br>" + Environment.NewLine;
            strRetVal += "<i><span style = \"color: red;\">Ehkä</span></i><br>" + Environment.NewLine;
            strRetVal += "<i>Vaatii tutkimista</i><br>" + Environment.NewLine;
            strRetVal += "Ei luokitusta<br>"+Environment.NewLine;
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
