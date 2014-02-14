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

        /// <summary>
        /// Test function which says hello
        /// </summary>
        /// <param name="who">Who's saying hello ?</param>
        /// <returns></returns>
        public String SayHello(String who)
        {
            return "Hello " + who + " from web service :)";
        }

        public String Test()
        {
            var rep = new StringBuilder();
            var list = DTC.RetrieveListAnecdote("search", 1, "flop");
            var i = 0;

            foreach (var curAne in list)
            {
                rep.AppendLine(i++.ToString(CultureInfo.InvariantCulture));
                rep.AppendLine(curAne.Content);
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
        public List<AnecdoteCnf> CNF_RetreiveAnecdote(String tri, int nombreAnecdote, int pageNumber)
        {
            return CNF.RetrieveListAnecdote(tri, nombreAnecdote, pageNumber);
        }

        public List<AnecdoteDtc> DTC_RetreiveAnecdote(String tri, int pageNumber, String searchWord)
        {
            return DTC.RetrieveListAnecdote(tri, pageNumber, searchWord);
        }

        public void VDM_NewAnecdote(AnecdoteVdm ane)
        {
            AnecdoteVdm newAne;
        }

        public void DTC_NewAnecdote(AnecdoteDtc ane)
        {
            AnecdoteDtc newAne;
        }

        public void CNF_NewAnecdote(AnecdoteCnf ane)
        {
            AnecdoteCnf newAne;
        }
    }
}