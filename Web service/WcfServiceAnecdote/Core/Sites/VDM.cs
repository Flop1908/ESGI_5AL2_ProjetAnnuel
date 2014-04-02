using System.Collections.Generic;
using Core.Anecdotes;
using System;
using System.Text;
using Core.Tools;
using log4net;
using System.Xml.Linq;

namespace Core.Sites
{
    public class VDM
    {
        private const string VDM_API_URL = @"http://api.fmylife.com/view/";
        private const String VDM_API_KEY = @"53316740a4787";

        public static readonly ILog Log = LogManager.GetLogger(typeof(VDM));

        public static List<AnecdoteVdm> RetrieveListAnecdote(string tri = "last", int pageNumber = 1, string searchWord = null)
        {
            log4net.Config.XmlConfigurator.Configure();
            Log.Fatal("Test Log");
            var url = BuildApiUrl(tri, pageNumber, searchWord);
            var xml = RetrieveWebIntel.Vdm(url, VDM_API_KEY);

            return TransformXmlToListAnecdoteVdm(xml);
        }

        private static List<AnecdoteVdm> TransformXmlToListAnecdoteVdm(string xml)
        {
            var root = XDocument.Parse(xml);
            var listeRawAnecdotes = root.Descendants("items").Descendants("item");
            var listeAne = new List<AnecdoteVdm>();
            List<string> listTest = new List<string>();

            foreach (var item in listeRawAnecdotes)
            {
                listeAne.Add(new AnecdoteVdm(
                    item.Attribute("id").Value,
                    item.Element("author").Value,
                    item.Element("text").Value,
                    item.Element("date").Value,
                    item.Element("agree").Value,
                    item.Element("deserved").Value));
            }

            return listeAne;
        }
        private static String BuildApiUrl(string tri, int pageNumber, string searchWord)
        {
            //On commence par placer l'URL de base
            var newUrl = new StringBuilder(VDM_API_URL);
            //Ajout du type de tri
            switch (tri)
            {
                case "last":
                    newUrl.Append("last");
                    newUrl.Append("/" + pageNumber);
                    break;
                case "random":
                    newUrl.Append("random");
                    newUrl.Append("/" + pageNumber);
                    break;
                case "top":
                    newUrl.Append("top");
                    newUrl.Append("/" + pageNumber);
                    break;
                case "flop":
                    newUrl.Append("flop");
                    newUrl.Append("/" + pageNumber);
                    break;
                case "search":
                    newUrl.Append("search?search=" + searchWord);
                    break;
                default:
                    Console.WriteLine("Mauvais parametre de tri : " + tri);
                    break;
            }
            return newUrl.ToString();
        }
    }
}
