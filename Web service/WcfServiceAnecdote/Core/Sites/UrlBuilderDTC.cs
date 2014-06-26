using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using Core.Anecdotes;
using Core.Tools;
using HtmlAgilityPack;
using log4net;
using Newtonsoft.Json.Linq;
using System.Web;


namespace Core.Sites
{
    public class UrlBuilderDTC
    {
        private const String DTC_API_URL = @"http://danstonchat.com/";

        public static readonly ILog Log = LogManager.GetLogger(typeof (UrlBuilderDTC));

        public static AnecdoteDtc[] RetrieveListAnecdote(string tri = "last", int pageNumber = 1,
            string searchWord = null)
        {
            log4net.Config.XmlConfigurator.Configure();
            Log.Fatal("Test Log");
            string raw = "";

            if (tri == "search")
            {
                raw = RetrieveWebIntel.DtcSearch(DTC_API_URL, searchWord);
            }
            else
            {
                var url = BuildApiUrl(tri, pageNumber);
                raw = RetrieveWebIntel.ContentFromURL(url);
            }

            return TransformJsonToListAnecdoteDtc(raw);;
        }

        private static AnecdoteDtc[] TransformJsonToListAnecdoteDtc(string pageWeb)
        {
            var listAne = new List<AnecdoteDtc>();
            //
            var doc = new HtmlDocument();
            //doc.DetectEncodingHtml(pageWeb);
            doc.LoadHtml(pageWeb);
            var listRawAne = doc.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[6]/div");
            foreach (var curQuote in listRawAne)
            {
                if (curQuote.Attributes["class"].Value.Contains("item item"))
                {
                    listAne.Add(new AnecdoteDtc(curQuote));
                }
            }

            return listAne.ToArray();
        }

        private static List<XElement> Essential(string pageWeb)
        {
            //Cleaning
            pageWeb = pageWeb.Replace("&nbsp", "");
            pageWeb = pageWeb.Replace("pw:", "");
            XDocument doc = XDocument.Parse(pageWeb);
            List<XElement> returnList = doc.Descendants("body").ToList();

            //<div id="contenu">
            returnList = returnList.Descendants("div")
                .Where(node => (string) node.Attribute("id") == "contenu")
                .ToList();

            //<div class="container_12">
            returnList = returnList.Descendants("class")
                .Where(node => (string) node.Attribute("id") == "container_12")
                .ToList();

            //<div id="content" class="grid_8">
            returnList = returnList.Descendants("class")
                .Where(node => (string) node.Attribute("id") == "grid_8")
                .ToList();

            //<div class="item-listing">
            returnList = returnList.Descendants("div")
                .Where(node => (string) node.Attribute("class") == "item-listing")
                .ToList();

            //Selection de tous les div
            returnList = returnList.Descendants("div").ToList();

            return returnList;
        }

        private static String BuildApiUrl(string tri, int pageNumber)
        {
            //On commence par placer l'URL de base
            var newUrl = new StringBuilder(DTC_API_URL);
            //Ajout du type de tri
            switch (tri)
            {
                case "last":
                    newUrl.Append("latest");
                    newUrl.Append("/" + pageNumber + ".html");
                    break;
                case "first":
                    newUrl.Append("browse");
                    newUrl.Append("/" + pageNumber + ".html");
                    break;
                case "random":
                    newUrl.Append("random0.html");
                    break;
                case "top":
                    newUrl.Append("top50.html");
                    break;
                case "flop":
                    newUrl.Append("flop50.html");
                    break;
                default:
                    Console.WriteLine("Mauvais parametre de tri : " + tri);
                    break;
            }

            return newUrl.ToString();
        }
    }
}