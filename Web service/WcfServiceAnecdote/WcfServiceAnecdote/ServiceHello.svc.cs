using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Core.Anecdotes;
using Core.Sites;
using log4net;
using System.ServiceModel;


namespace WcfServiceAnecdote
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceHello" à la fois dans le code, le fichier svc et le fichier de configuration.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
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

        public List<AnecdoteVdm> Test()
        {
            return VDM.RetrieveListAnecdote("last", 1);
        }

        /// <summary>
        /// Function that retreive a list of Chuck Norris Facts
        /// </summary>
        /// <param name="tri">"last","first","top","flop","mtop","random","mflop"</param>
        /// <param name="nombreAnecdote">1 to 99</param>
        /// <param name="pageNumber">>=1</param>
        /// <returns></returns>
        public List<AnecdoteCnf> CNF_RetreiveAnecdote(String tri, String nombreAnecdote, String pageNumber)
        {
            return CNF.RetrieveListAnecdote(tri.ToLower(), int.Parse(nombreAnecdote), int.Parse(pageNumber));
        }

        public List<AnecdoteDtc> DTC_RetreiveAnecdote(String tri, String pageNumber)
        {
            return DTC.RetrieveListAnecdote(tri.ToLower(), int.Parse(pageNumber));
        }

        public List<AnecdoteDtc> DTC_SearchAnecdote(String tri, String pageNumber, String searchWord)
        {
            return DTC.RetrieveListAnecdote(tri.ToLower(), int.Parse(pageNumber), searchWord);
        }

        public List<AnecdoteVdm> VDM_RetreiveAnecdote(String tri, String pageNumber)
        {
            return VDM.RetrieveListAnecdote(tri.ToLower(), int.Parse(pageNumber));
        }

        public List<AnecdoteVdm> VDM_SearchAnecdote(String tri, String pageNumber, String searchWord)
        {
            return VDM.RetrieveListAnecdote(tri.ToLower(), int.Parse(pageNumber), searchWord);
        }

    }
}