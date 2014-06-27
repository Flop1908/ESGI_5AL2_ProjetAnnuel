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
        private System.Xml.Linq.XElement item;
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Author { get; set; }
        [DataMember]
        public String Text { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
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
            Date= DateTime.Now;
            Agree = 0;
            Deserved = 0;
            NbComments = 0;
        }

        public AnecdoteVdm(AnecdoteVdm anecdoteVdm)
        {
            Id = anecdoteVdm.Id;
            Author = anecdoteVdm.Author;
            Text = anecdoteVdm.Text;
            Date = anecdoteVdm.Date;
            Agree = anecdoteVdm.Agree;
            Deserved = anecdoteVdm.Deserved;
            NbComments = anecdoteVdm.NbComments;
            
        }

        public AnecdoteVdm(int id, string author, string contenu, DateTime date, int jeValide, int bienMerite, int nbComments)
        {
            Id = id;
            Author = author;
            Text = contenu;
            Date = date;
            Agree = jeValide;
            Deserved = bienMerite;
            NbComments = nbComments;
        }

        public AnecdoteVdm(string newId, string newAuthor, string newContenu, string newDate, string newJeValide, string newBienMerite, string newNbComments)
        {
            Id = int.Parse(newId);
            Author = newAuthor;
            Text = newContenu;
            Date = DateTime.Parse(newDate);
            Agree = int.Parse(newJeValide);
            Deserved = int.Parse(newBienMerite);
            NbComments = int.Parse(newNbComments);
        }

        public AnecdoteVdm(System.Xml.Linq.XElement item)
        {
            Id = int.Parse(item.Attribute("id").Value);
            Author = item.Element("author").Value;
            Text = item.Element("text").Value;
            Date = DateTime.Parse(item.Element("date").Value);
            Agree = int.Parse(item.Element("agree").Value);
            Deserved = int.Parse(item.Element("deserved").Value);
            NbComments = int.Parse(item.Element("comments").Value);
        }
    }
}
