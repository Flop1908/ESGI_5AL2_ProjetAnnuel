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
        int Id { get; set; }
        [DataMember]
        String Author { get; set; }
        [DataMember]
        DateTime Date { get; set; }
        [DataMember]
        String Text { get; set; }
        [DataMember]
        int Thumbs { get; set; }
        
        public CommentVdm(System.Xml.Linq.XElement item)
        {
            Id = int.Parse(item.Attribute("id").Value);
            Author = item.Element("author").Value;
            Text = item.Element("text").Value;
            Date = DateTime.Parse(item.Element("date").Value);
            Thumbs = int.Parse(item.Element("thumbs").Value);
        }

    }
}
