using System;
using System.Runtime.Serialization;
using System.Web;

namespace Core.Anecdotes
{
    [DataContract (Name="AnecdoteCnf")]
    public class AnecdoteCnf
    {
        [DataMember] 
        public String Type = "CNF";
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Texte { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int Vote { get; set; }
        [DataMember]
        public int Points { get; set; }

        public AnecdoteCnf()
        {
            Id = 0;
            Texte = "Anecdote CNF";
            Date = DateTime.Now;
            Vote = 0;
            Points = 0;
        }

        public AnecdoteCnf(int id, string fact, DateTime date, int vote, int points)
        {
            Id = id;
            Texte = fact;
            Date = date;
            Vote = vote;
            Points = points;
        }

        public AnecdoteCnf (String id, String fact, String date, String vote, String points)
        {
            //Id transformation
            Id = int.Parse(id);
            //Fact transformation
            var newFact = HttpUtility.HtmlDecode(fact);
            Texte = newFact.Replace("<br />", " ");
            //Date transformation
            var newDate = new DateTime(1970, 1, 1);
            Date = newDate.AddSeconds(Double.Parse(date));
            //Vote tansformation
            Vote = int.Parse(vote);
            //Vote tansformation
            Points = int.Parse(points);
        }

        public AnecdoteCnf(AnecdoteCnf anecdoteCnf)
        {
            Id = anecdoteCnf.Id;
            Texte = anecdoteCnf.Texte;
            Date = anecdoteCnf.Date;
            Vote = anecdoteCnf.Vote;
            Points = anecdoteCnf.Points;
        }

    }
}