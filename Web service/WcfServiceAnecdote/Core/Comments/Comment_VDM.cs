using System;
using System.Runtime.Serialization;

namespace Core.Comments
{
    [DataContract]
    public class CommentVdm
    {
        [DataMember]
        String Autor { get; set; }
        [DataMember]
        String Content { get; set; }
        [DataMember]
        int Score { get; set; }

    }
}
