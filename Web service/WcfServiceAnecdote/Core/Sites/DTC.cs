using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Anecdotes;
using Core.Tools;
using log4net;
using Newtonsoft.Json.Linq;


namespace Core.Sites
{
    public class DTC
    {
        private const String DTC_API_URL = @"https://giyomu-dans-ton-chat.p.mashape.com/";
        private const String DTC_API_KEY = @"NV8awMWbIGImeoTnXTyUa7wV6EtxpMOx";

        public static readonly ILog Log = LogManager.GetLogger(typeof(DTC));

        public static List<AnecdoteDtc> RetrieveListAnecdote(string tri = "last", int pageNumber = 1, string searchWord = null)
        {
            log4net.Config.XmlConfigurator.Configure(); 
            Log.Fatal("Test Log");
            var url = BuildApiUrl(tri, pageNumber, searchWord);
            var json = RetrieveJson.Dtc(url,DTC_API_KEY);

            return TransformJsonToListAnecdoteDtc(json);
        }

        private static List<AnecdoteDtc> TransformJsonToListAnecdoteDtc(string json)
        {
            var deserializeJson = JObject.Parse(json);
            var rawListAne = (JArray) deserializeJson["quotes"];

            List<AnecdoteDtc> listAne = rawListAne.Select(p => new AnecdoteDtc(
                AnecdoteDtc.AdaptatorDtc(
                    (string) p["id"],
                    (string) p["quote"]))
                ).ToList();

            return listAne;
        }

        private static String BuildApiUrl(string tri, int pageNumber, string searchWord)
        {
            //On commence par placer l'URL de base
            var newUrl = new StringBuilder(DTC_API_URL);
            //Ajout du type de tri
            switch (tri)
            {
                case "browse":
                    newUrl.Append("browse");
                    newUrl.Append("/" + pageNumber);
                    break;
                case "random":
                    newUrl.Append("random0");
                    break;
                case "search":
                    newUrl.Append("search");
                    newUrl.Append("/" + searchWord);
                    newUrl.Append("/" + pageNumber);
                    break;
                case "top":
                    newUrl.Append("top50");
                    break;
                case "last":
                    newUrl.Append("latest");
                    newUrl.Append("/" + pageNumber);
                    break;
                default:
                    Console.WriteLine("Mauvais parametre de tri : " + tri);
                    break;
            }

            return newUrl.ToString();
        }
    }
}