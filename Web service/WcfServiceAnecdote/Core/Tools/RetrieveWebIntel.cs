using log4net;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Core.Tools
{
    public static class RetrieveWebIntel
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(RetrieveWebIntel));
        /*
        public static String ContentFromURL(String trouveMoi)
        {
            String pageContent = null;

            //construction de la requete pour isohunt
            var lienUrl = trouveMoi;

            try
            {
                //lancement de la requete
                var req = WebRequest.Create(lienUrl);
                var result = req.GetResponse();

                //flux pour lire la réponse web
                var receiveReq = result.GetResponseStream();

                //on donne le type d'encodage (utf-8)
                var encode = Encoding.GetEncoding("utf-8");

                //on créer un flux pour lire le flux web
                if (receiveReq != null)
                {
                    var sr = new StreamReader(receiveReq, encode);

                    //on place le résultat du flux dans la réponse
                    pageContent = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return pageContent;
        }
        */
        //public static String Dtc(String url)
        public static String ContentFromURL(String url)
        {
            WebClient wc = new WebClient();
            string response = wc.DownloadString(url);

            return response;
        }

        public static String Vdm(String url, String apiKey)
        {

            ///construction de la requete pour l'api VDM
            var lienUrl = new StringBuilder(url);
            //Ajout de la langue            
            lienUrl.Append("&language=fr");
            //Ajout de la clé
            lienUrl.Append("&key=" + apiKey);

            return ContentFromURL(lienUrl.ToString());
        }

        internal static string DtcSearch(string DTC_API_URL, string searchWord)
        {
            throw new NotImplementedException();
        }
    }
}
