using System;

namespace VahtiApp
{
    internal class Hilma: Palvelut
    {
        //https://www.hankintailmoitukset.fi/fi/search?
        //top=75&nuts=FI1D&nuts=FI1C3&
        //pa=2020-06-02&of=datePublished&od=desc
        public Hilma()
        {
            uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "www.hankintailmoitukset.fi";
            uriBuilder.Path = "top=75&nuts=FI1D&nuts=FI1C3&pa=2020-06-02&of=datePublished&od=desc";
            uri = uriBuilder.Uri;
        }
        public Hilma(string inHost, string inPath)
        {
        }
    }
}