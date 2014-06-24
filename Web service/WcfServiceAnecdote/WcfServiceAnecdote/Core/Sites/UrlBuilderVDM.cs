using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Core.Anecdotes;
using Core.Tools;
using log4net;
using log4net.Config;

namespace Core.Sites
{
    public class UrlBuilderVDM
    {
        private const string VDM_API_URL = @"http://api.fmylife.com/view/";
        private const String VDM_API_KEY = @"53316740a4787";

        public static readonly ILog Log = LogManager.GetLogger(typeof (UrlBuilderVDM));

        public static AnecdoteVdm[] RetrieveListAnecdote(string tri = "last", int pageNumber = 1,
            string searchWord = null)
        {
            try
            {
                string url = BuildApiUrl(tri, pageNumber, searchWord);
                string xml = RetrieveWebIntel.ContentFromURL(url);
                //Changement de l'encodage
                //xml = ToolBox.Transcoding(xml, Encoding.ASCII, Encoding.UTF8);

                return TransformRawToPure(xml);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static AnecdoteVdm[] TransformRawToPure(string xml)
        {
            XDocument root = XDocument.Parse(xml);
            IEnumerable<XElement> listeRawAnecdotes = root.Descendants("items").Descendants("item");
            var listeAne = new List<AnecdoteVdm>();

            foreach (XElement item in listeRawAnecdotes)
            {
                listeAne.Add(new AnecdoteVdm(
                    item.Attribute("id").Value,
                    item.Element("author").Value,
                    item.Element("text").Value,
                    item.Element("date").Value,
                    item.Element("agree").Value,
                    item.Element("deserved").Value,
                    item.Element("comments").Value));
            }

            return listeAne.ToArray();
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

            //Ajout de la langue            
            newUrl.Append("&language=fr");
            //Ajout de la clé
            newUrl.Append("&key=" + VDM_API_KEY);

            return newUrl.ToString();
        }
    }
}