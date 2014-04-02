using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Core.Comments;

namespace Core.Anecdotes
{
    [DataContract]
    public class AnecdoteVdm
    {
        private AnecdoteVdm anecdoteVdm;

        public AnecdoteVdm(string author, string contenu)
        {
            Author = author;
            Contenu = contenu;
        }

        public AnecdoteVdm(int id, string author, string contenu, DateTime date, int jeValide, int bienMerite)
            : this(id, author, contenu, date, jeValide, bienMerite, null)
        {
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

        public AnecdoteVdm(AnecdoteVdm anecdoteVdm)
        {
            // TODO: Complete member initialization
            this.anecdoteVdm = anecdoteVdm;
        }

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

        internal static AnecdoteVdm AdaptatorVdm(string id, string author, string text, string date, string agree, string diserve)
        {
            int newId = int.Parse(id);
            string newAuthor = author;
            string newContenu = text;
            DateTime newDate = DateTime.Parse(date);
            int newJeValide = int.Parse(agree);
            int newBienMerite = int.Parse(diserve);

            return new AnecdoteVdm(newId, newAuthor, newContenu, newDate, newJeValide, newBienMerite);
        }

    }
}
