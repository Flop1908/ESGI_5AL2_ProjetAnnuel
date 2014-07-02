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
            //string response = wc.DownloadString(url);

            Byte[] pageData = wc.DownloadData(url);
            string response = Encoding.UTF8.GetString(pageData);

            //response = ToolBox.Transcoding(response, Encoding.ASCII, Encoding.UTF8);

            return response;
        }

        internal static string DtcSearch(string DTC_API_URL, string searchWord)
        {
            throw new NotImplementedException();
        }

    }
}
