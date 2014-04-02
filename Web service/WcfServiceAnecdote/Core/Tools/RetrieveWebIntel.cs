using log4net;
using System;
using System.IO;
using System.Net;
using System.Text;
using unirest_net.http;

namespace Core.Tools
{
    public static class RetrieveWebIntel
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(RetrieveWebIntel));

        public static String Cnf(String trouveMoi)
        {
            String chaineJson = null;

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
                var encode = Encoding.GetEncoding(0);

                //on créer un flux pour lire le flux web
                if (receiveReq != null)
                {
                    var sr = new StreamReader(receiveReq, encode);

                    //on place le résultat du flux dans la réponse
                    chaineJson = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);

            }

            return chaineJson;
        }

        public static String Dtc(String url, String apiKey)
        {

            HttpResponse<String> response = Unirest.get(url)
              .header("X-Mashape-Authorization", apiKey)
              .asString();

            return response.Body;
        }

        public static String Vdm(String url, String apiKey)
        {
            String chaineXML = null;

            ///construction de la requete pour l'api VDM
            var lienUrl = new StringBuilder(url);
            //Ajout de la langue            
            lienUrl.Append("&language=fr");
            //Ajout de la clé
            lienUrl.Append("&key=" + apiKey);

            try
            {
                //lancement de la requete
                var req = WebRequest.Create(lienUrl.ToString());
                var result = req.GetResponse();

                //flux pour lire la réponse web
                var receiveReq = result.GetResponseStream();

                //on donne le type d'encodage (utf-8)
                var encode = Encoding.GetEncoding(65001);

                //on créer un flux pour lire le flux web
                if (receiveReq != null)
                {
                    var sr = new StreamReader(receiveReq, encode);

                    //on place le résultat du flux dans la réponse
                    chaineXML = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);

            }

            return chaineXML;
        }
    }
}
