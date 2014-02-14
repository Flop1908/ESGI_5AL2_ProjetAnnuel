using System;
using System.Collections.Generic;
using System.ServiceModel;
using Core.Anecdotes;

namespace WcfServiceAnecdote
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceHello" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceHello
    {

        [OperationContract]
        String SayHello(String who);

        [OperationContract]
        String Test();

        [OperationContract]
        List<AnecdoteCnf> CNF_RetreiveAnecdote(String tri, int nombreAnecdote, int pageNumber);

        [OperationContract]
        List<AnecdoteDtc> DTC_RetreiveAnecdote(String tri, int pageNumber, String searchWord);

        [OperationContract]
        void VDM_NewAnecdote(AnecdoteVdm ane);

        [OperationContract]
        void DTC_NewAnecdote(AnecdoteDtc ane);

        [OperationContract]
        void CNF_NewAnecdote(AnecdoteCnf ane);
    }
}
