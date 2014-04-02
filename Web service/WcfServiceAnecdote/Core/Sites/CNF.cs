using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Anecdotes;
using Core.Tools;
using Newtonsoft.Json.Linq;

namespace Core.Sites
{
    public class CNF
    {
        private const String CNF_API_URL = @"http://chucknorrisfacts.fr/api/get?data=";

        /// <summary>
        /// Transform a json to a list of Chuck Norris Facts anecdotes
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        private static List<AnecdoteCnf> TransformJsonToListAnecdoteCnf(String json)
        {
            var deserializeJson = JArray.Parse(json);

            List<AnecdoteCnf> listAne = deserializeJson.Select(p => new AnecdoteCnf(
                AnecdoteCnf.AdaptatorCnf(
                    (string) p["fact"],
                    (string) p["date"],
                    (string) p["vote"],
                    (string) p["points"]))
                ).ToList();

            return listAne;
        }

        /// <summary>
        /// Build the URL based on the parameters
        /// </summary>
        /// <param name="tri"></param>
        /// <param name="nombreAnecdote"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        private static String BuildApiUrl(string tri, int nombreAnecdote, int pageNumber)
        {
            var newUrl = new StringBuilder(CNF_API_URL);
            //Ajout du parametre du tri
            newUrl.Append("tri:");
            switch (tri)
            {
                case "last":
                    newUrl.Append("last");
                    break;
                case "first":
                    newUrl.Append("first");
                    break;
                case "top":
                    newUrl.Append("top");
                    break;
                case "flop":
                    newUrl.Append("flop");
                    break;
                case "mtop":
                    newUrl.Append("mtop");
                    break;
                case "random":
                    newUrl.Append("alea");
                    break;
                case "mflop":
                    newUrl.Append("mflop");
                    break;
                default:
                    Console.WriteLine("Mauvais parametre de tri : " + tri);
                    break;
            }

            //Ajout du parametre du nombre d'anecdotes
            newUrl.Append(";nb:" + nombreAnecdote);

            //Ajout du parametre de la page
            newUrl.Append(";page:" + pageNumber);

            return newUrl.ToString();
        }

        /// <summary>
        /// Primary function to retrieve a list of anecdotes from the given parameters
        /// </summary>
        /// <param name="tri"></param>
        /// <param name="nombreAnecdote"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public static List<AnecdoteCnf> RetrieveListAnecdote(string tri = "last", int nombreAnecdote = 10,
            int pageNumber = 1)
        {
            var url = BuildApiUrl(tri, nombreAnecdote, pageNumber);
            var json = RetrieveWebIntel.Cnf(url);

            return TransformJsonToListAnecdoteCnf(json);
        }
    }
}