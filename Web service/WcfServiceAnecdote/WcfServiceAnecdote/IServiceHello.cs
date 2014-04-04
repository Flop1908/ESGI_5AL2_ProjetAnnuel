using System;
using System.Collections.Generic;
using System.ServiceModel;
using Core.Anecdotes;
using System.ServiceModel.Web;
using System.ComponentModel;

namespace WcfServiceAnecdote
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceHello" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceHello
    {

        [OperationContract]
        [WebGet(UriTemplate = "SayHello/{who}")]
        [Description("To say hello to the web service")]
        String SayHello(String who);

        [OperationContract]
        [WebGet(UriTemplate = "Test")]
        [Description("!! Test function : do not use !!")]
        String Test();

        [OperationContract]
        [WebGet(UriTemplate = "CNF_RetreiveAnecdote/{tri}/{nombreAnecdote}/{pageNumber}", ResponseFormat = WebMessageFormat.Json)]
        [Description("To retreive quotes from chuck norris fact")]
        List<AnecdoteCnf> CNF_RetreiveAnecdote(String tri, String nombreAnecdote, String pageNumber);

        [OperationContract]
        [WebGet(UriTemplate = "DTC_RetreiveAnecdote/{tri}/{pageNumber}", ResponseFormat = WebMessageFormat.Json)]
        [Description("To retreive quotes from Dans Ton Chat")]
        List<AnecdoteDtc> DTC_RetreiveAnecdote(String tri, String pageNumber);

        [OperationContract]
        [WebGet(UriTemplate = "DTC_SearchAnecdote/{tri}/{pageNumber}/{searchWord}", ResponseFormat = WebMessageFormat.Json)]
        [Description("To search quotes from DTC with a word")]
        List<AnecdoteDtc> DTC_SearchAnecdote(String tri, String pageNumber, String searchWord);

        [OperationContract]
        [WebGet(UriTemplate = "VDM_RetreiveAnecdote/{tri}/{pageNumber}", ResponseFormat = WebMessageFormat.Json)]
        [Description("To retreive quotes from Vie De Merde")]
        List<AnecdoteVdm> VDM_RetreiveAnecdote(String tri, String pageNumber);

        [OperationContract]
        [WebGet(UriTemplate = "VDM_SearchAnecdote/{tri}/{pageNumber}/{searchWord}", ResponseFormat = WebMessageFormat.Json)]
        [Description("To search quotes from VDM with a word")]
        List<AnecdoteVdm> VDM_SearchAnecdote(String tri, String pageNumber, String searchWord);
    }
}
