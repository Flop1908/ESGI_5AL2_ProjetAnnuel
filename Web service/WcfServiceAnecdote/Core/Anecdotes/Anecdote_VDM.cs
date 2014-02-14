using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Core.Comments;

namespace Core.Anecdotes
{
    [DataContract]
    public class AnecdoteVdm
    {
        public AnecdoteVdm(string autor, string contenu)
        {
            Autor = autor;
            Contenu = contenu;
        }

        public AnecdoteVdm(int id, string autor, string contenu, DateTime parution, int jeValide, int bienMerite)
            : this(id, autor, contenu, parution, jeValide, bienMerite, null)
        {
        }

        public AnecdoteVdm(int id, string autor, string contenu, DateTime parution, int jeValide, int bienMerite, List<CommentVdm> listComments)
        {
            Id = id;
            Autor = autor;
            Contenu = contenu;
            Parution = parution;
            JeValide = jeValide;
            BienMerite = bienMerite;
            ListComments = listComments;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Autor { get; set; }
        [DataMember]
        public String Contenu { get; set; }
        [DataMember]
        public DateTime Parution { get; set; }
        [DataMember]
        public int JeValide { get; set; }
        [DataMember]
        public int BienMerite { get; set; }
        [DataMember]
        public List<CommentVdm> ListComments { get; set; }
    }
}
