using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Core.Anecdotes;
using Core.Sites;
using log4net;


namespace WcfServiceAnecdote
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceHello" à la fois dans le code, le fichier svc et le fichier de configuration.
    public class ServiceHello : IServiceHello
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(ServiceHello));

        /// <summary>
        /// Test function which says hello
        /// </summary>
        /// <param name="who">Who's saying hello ?</param>
        /// <returns></returns>
        public String SayHello(String who)
        {
            Log.Debug(who + " call the SayHello");
            return "Hello " + who + " from web service :)";
        }

        public String Test()
        {
            var rep = new StringBuilder();
            var list = VDM.RetrieveListAnecdote("search", 1, "flop");
            var i = 0;

            foreach (var curAne in list)
            {
                rep.AppendLine(i++.ToString(CultureInfo.InvariantCulture));
                rep.AppendLine(curAne.Contenu);
            }

            return rep.ToString();
        }

        /// <summary>
        /// Function that retreive a list of Chuck Norris Facts
        /// </summary>
        /// <param name="tri">"last","first","top","flop","mtop","alea","mflop"</param>
        /// <param name="nombreAnecdote">1 to 99</param>
        /// <param name="pageNumber">>=1</param>
        /// <returns></returns>
        public List<AnecdoteCnf> CNF_RetreiveAnecdote(String tri, String nombreAnecdote, String pageNumber)
        {
            return CNF.RetrieveListAnecdote(tri, int.Parse(nombreAnecdote), int.Parse(pageNumber));
        }

        public List<AnecdoteDtc> DTC_RetreiveAnecdote(String tri, String pageNumber, String searchWord)
        {
            return DTC.RetrieveListAnecdote(tri, int.Parse(pageNumber), searchWord);
        }
    }
}