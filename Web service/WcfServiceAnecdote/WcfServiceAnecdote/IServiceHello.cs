using System;
using System.Collections.Generic;
using System.ServiceModel;
using Core.Anecdotes;
using System.ServiceModel.Web;

namespace WcfServiceAnecdote
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceHello" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceHello
    {

        [OperationContract]
        [WebGet(UriTemplate = "SayHello/{who}")]
        String SayHello(String who);

        [OperationContract]
        [WebGet(UriTemplate = "Test")]
        String Test();

        [OperationContract]
        [WebGet(UriTemplate = "CNF_RetreiveAnecdote/{tri}/{nombreAnecdote}/{pageNumber}")]
        List<AnecdoteCnf> CNF_RetreiveAnecdote(String tri, String nombreAnecdote, String pageNumber);

        [OperationContract]
        [WebGet(UriTemplate = "DTC_RetreiveAnecdote/{tri}/{pageNumber}/{searchWord}")]
        List<AnecdoteDtc> DTC_RetreiveAnecdote(String tri, String pageNumber, String searchWord);
    }
}
