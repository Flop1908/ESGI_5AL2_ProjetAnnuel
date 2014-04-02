using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Comments
{
    [DataContract]
    class Comment_CNF
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(Comment_CNF));

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
