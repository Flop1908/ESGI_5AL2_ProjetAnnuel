using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Core.Anecdotes;
using Core.Tools;
using log4net;
using log4net.Config;
using Core.Comments;

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

                return TransformRawAnnecdotesToPure(xml);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static AnecdoteVdm[] TransformRawAnnecdotesToPure(string xml)
        {
            XDocument root = XDocument.Parse(xml);
            IEnumerable<XElement> listeRawAnecdotes = root.Descendants("items").Descendants("item");
            var listeAne = new List<AnecdoteVdm>();

            foreach (XElement item in listeRawAnecdotes)
            {
                /*
                listeAne.Add(new AnecdoteVdm(
                    item.Attribute("id").Value,
                    item.Element("author").Value,
                    item.Element("text").Value,
                    item.Element("date").Value,
                    item.Element("agree").Value,
                    item.Element("deserved").Value,
                    item.Element("comments").Value));
                 */
                listeAne.Add(new AnecdoteVdm(item));
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
                    newUrl.Append("/15");
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

            newUrl.Append("&language=fr&key=" + VDM_API_KEY);

            return newUrl.ToString();
        }
        
        public static CommentVdm[] RetreiveComment(string idAnecdote)
        {
            //On commence par placer l'URL de base
            var newUrl = new StringBuilder(VDM_API_URL);

            //On ajoute l'id de l'anecdote
            newUrl.Append(idAnecdote);

            //Et le suffixe obligatoire
            newUrl.Append("&language=fr&key=" + VDM_API_KEY);

            //Recup du resultat de l'api
            string xml = RetrieveWebIntel.ContentFromURL(newUrl.ToString());

            return TransformRawCommentsToPure(xml);
        }

        private static CommentVdm[] TransformRawCommentsToPure(string xml)
        {
            XDocument root = XDocument.Parse(xml);
            var listeRawComments = root.Descendants("comment");

            var listeCom = new List<CommentVdm>();

            foreach (XElement item in listeRawComments)
            {
                listeCom.Add(new CommentVdm(item));
            }

            return listeCom.ToArray();
        }
    }
}