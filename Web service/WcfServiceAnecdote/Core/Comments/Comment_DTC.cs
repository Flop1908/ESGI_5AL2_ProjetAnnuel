using System;
using System.Runtime.Serialization;

namespace Core.Comments
{
    [DataContract]
    public class CommentDtc
    {
        [DataMember]
        String Autor { get; set; }
        [DataMember]
        String Content { get; set; }
        [DataMember]
        int Good { get; set; }
        [DataMember]
        int Bad { get; set; }
    }
}
