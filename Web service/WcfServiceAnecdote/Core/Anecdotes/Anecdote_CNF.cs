using System;
using System.Runtime.Serialization;
using System.Web;

namespace Core.Anecdotes
{
    [DataContract (Name="AnecdoteCnf")]
    public class AnecdoteCnf
    {
        [DataMember]
        public String Fact { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int Vote { get; set; }

        [DataMember]
        public int Points { get; set; }

        public AnecdoteCnf(string fact, DateTime date, int vote, int points)
        {
            Fact = fact;
            Date = date;
            Vote = vote;
            Points = points;
        }

        public AnecdoteCnf (String fact, String date, String vote, String points)
        {
            //Fact transformation
            var newFact = HttpUtility.HtmlDecode(fact);
            Fact = newFact.Replace("<br />", " ");
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
            Fact = anecdoteCnf.Fact;
            Date = anecdoteCnf.Date;
            Vote = anecdoteCnf.Vote;
            Points = anecdoteCnf.Points;
        }

    }
}