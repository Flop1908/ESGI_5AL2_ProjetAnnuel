using log4net;
using System;
using System.Runtime.Serialization;

namespace Core.Comments
{
    [DataContract]
    public class CommentDtc
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(CommentDtc));

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
