using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Core.Comments;

namespace Core.Anecdotes
{
    [DataContract(Name = "AnecdoteVdm")]
    public class AnecdoteVdm
    {
        [DataMember]
        public String Type = "VDM";
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Author { get; set; }
        [DataMember]
        public String Text { get; set; }
        [DataMember]
        public String Date { get; set; }
        [DataMember]
        public int Agree { get; set; }
        [DataMember]
        public int Deserved { get; set; }
        [DataMember]
        public int NbComments { get; set; }

        public AnecdoteVdm()
        {
            Id = 0;
            Author = "Flop";
            Text = "Anecdote VDM";
            Date= DateTime.Now.ToShortDateString();
            Agree = 0;
            Deserved = 0;
            NbComments = 0;
        }

        public AnecdoteVdm(System.Xml.Linq.XElement item)
        {
            Id = int.Parse(item.Attribute("id").Value);
            Author = item.Element("author").Value;
            Text = item.Element("text").Value;
            DateTime newDate = DateTime.Parse(item.Element("date").Value);
            Date = newDate.ToShortDateString() + " " + newDate.ToShortTimeString();
            Agree = int.Parse(item.Element("agree").Value);
            Deserved = int.Parse(item.Element("deserved").Value);
            NbComments = int.Parse(item.Element("comments").Value);
        }
    }
}
