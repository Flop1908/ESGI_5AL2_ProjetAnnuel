using log4net;
using System;
using System.Runtime.Serialization;

namespace Core.Comments
{
    [DataContract]
    public class CommentVdm
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(CommentVdm));

        [DataMember]
        String Autor { get; set; }
        [DataMember]
        String Content { get; set; }
        [DataMember]
        int Score { get; set; }

    }
}
