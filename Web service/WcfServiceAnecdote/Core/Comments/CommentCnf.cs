using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Comments
{
    [DataContract]
    class CommentCnf
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(CommentCnf));

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
