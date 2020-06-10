using System;

namespace VahtiApp
{
    internal class TarjousPalvelu : Palvelut
    {
        //https://tarjouspalvelu.fi/Default/Index
        //Special caset
        //https://tarjouspalvelu.fi/tarjouspyynnot.aspx?p=279&g=4255edad-e038-4620-ba0d-6c62a78a5cb8
        //https://tarjouspalvelu.fi/tarjouspyynnot.aspx?p=1701&g=9b94cbe2-fe1c-4765-a3b7-2a2e8ed680de
        public TarjousPalvelu()
        {
            uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "tarjouspalvelu.fi";
            uriBuilder.Path = "Default/Index";
            uri = uriBuilder.Uri;
        }
        public TarjousPalvelu(string inHost, string inPath)
        {
        }
    }
}