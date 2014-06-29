using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Web;
using Core.Anecdotes;
using Core.Sites;
using log4net;
using System.ServiceModel;
using Newtonsoft.Json;
using Core.Comments;


namespace WcfServiceAnecdote
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceHello" à la fois dans le code, le fichier svc et le fichier de configuration.
    [CallbackBehavior(UseSynchronizationContext = false)]
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
            Log.Info("Web Service | Consommation de SayHello avec parametres who : " + who);

            var stream = File.Create(@"E:\web\ralfesgi\app6\Log\testfile.txt");
            return (stream != null && stream.CanWrite).ToString();
            /*
            Log.Debug(who + " call the SayHello");
            return "Hello " + who + " from web service :)";
             */
            //return JsonConvert.SerializeObject(VDM.RetrieveListAnecdote("last", 1));
            return Core.Tools.RetrieveWebIntel.ContentFromURL(@"http://api.fmylife.com/view/last/?language=fr&key=53316740a4787");
        }

        public AnecdoteVdm[] Test()
        {
            Log.Info("Web Service | Consommation du test");
            return UrlBuilderVDM.RetrieveListAnecdote("last", 1);
        }

        /// <summary>
        /// Function that retreive a list of Chuck Norris Facts
        /// </summary>
        /// <param name="tri">"last","first","top","flop","mtop","random","mflop"</param>
        /// <param name="nombreAnecdote">1 to 99</param>
        /// <param name="pageNumber">>=1</param>
        /// <returns></returns>
        public AnecdoteCnf[] CNF_RetreiveAnecdote(String tri, String pageNumber)
        {
            Log.Info("Web Service | Consommation de CNF_RetreiveAnecdote");
            return UrlBuilderCNF.RetrieveListAnecdote(tri.ToLower(), int.Parse(pageNumber));
        }

        public AnecdoteDtc[] DTC_RetreiveAnecdote(String tri, String pageNumber)
        {
            Log.Info("Web Service | Consommation de DTC_RetreiveAnecdote");
            return UrlBuilderDTC.RetrieveListAnecdote(tri.ToLower(), int.Parse(pageNumber));
        }

        public AnecdoteDtc[] DTC_SearchAnecdote(String tri, String pageNumber, String searchWord)
        {
            Log.Info("Web Service | Consommation de DTC_SearchAnecdote");
            return UrlBuilderDTC.RetrieveListAnecdote(tri.ToLower(), int.Parse(pageNumber), searchWord);
        }

        public AnecdoteVdm[] VDM_RetreiveAnecdote(String tri, String pageNumber)
        {
            Log.Info("Web Service | Consommation de VDM_RetreiveAnecdote");
            return UrlBuilderVDM.RetrieveListAnecdote(tri.ToLower(), int.Parse(pageNumber));
        }

        public AnecdoteVdm[] VDM_SearchAnecdote(String pageNumber, String searchWord)
        {
            Log.Info("Web Service | Consommation de VDM_SearchAnecdote");
            return UrlBuilderVDM.RetrieveListAnecdote("search", int.Parse(pageNumber), searchWord);
        }

        public CommentVdm[] VDM_RetreiveComment(String idAnecdote)
        {
            Log.Info("Web Service | Consommation de VDM_RetreiveComment");
            return UrlBuilderVDM.RetreiveComment(idAnecdote);
        }

    }
}