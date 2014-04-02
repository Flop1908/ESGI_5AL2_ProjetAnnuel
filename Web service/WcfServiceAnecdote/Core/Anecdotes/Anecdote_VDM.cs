using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Core.Comments;

namespace Core.Anecdotes
{
    [DataContract]
    public class AnecdoteVdm
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Author { get; set; }
        [DataMember]
        public String Contenu { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int JeValide { get; set; }
        [DataMember]
        public int BienMerite { get; set; }
        [DataMember]
        public List<CommentVdm> ListComments { get; set; }

        public AnecdoteVdm(string author, string contenu)
        {
            Author = author;
            Contenu = contenu;
        }

        public AnecdoteVdm(int id, string author, string contenu, DateTime date, int jeValide, int bienMerite, List<CommentVdm> listComments)
        {
            Id = id;
            Author = author;
            Contenu = contenu;
            Date = date;
            JeValide = jeValide;
            BienMerite = bienMerite;
            ListComments = listComments;
        }

        public AnecdoteVdm(string newId, string newAuthor, string newContenu, string newDate, string newJeValide, string newBienMerite)
        {
            Id = int.Parse(newId);
            Author = newAuthor;
            Contenu = newContenu;
            Date = DateTime.Parse(newDate);
            JeValide = int.Parse(newJeValide);
            BienMerite = int.Parse(newBienMerite);
        }
    }
}
