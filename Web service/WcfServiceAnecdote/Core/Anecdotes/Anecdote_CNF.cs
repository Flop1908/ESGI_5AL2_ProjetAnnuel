using System;
using System.Runtime.Serialization;
using System.Web;

namespace Core.Anecdotes
{
    [DataContract (Name="AnecdoteCnf")]
    public class AnecdoteCnf
    {
        public AnecdoteCnf(string fact, DateTime date, int vote, int points)
        {
            Fact = fact;
            Date = date;
            Vote = vote;
            Points = points;
        }

        public AnecdoteCnf(AnecdoteCnf anecdoteCnf)
        {
            Fact = anecdoteCnf.Fact;
            Date = anecdoteCnf.Date;
            Vote = anecdoteCnf.Vote;
            Points = anecdoteCnf.Points;
        }

        [DataMember]
        public String Fact { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int Vote { get; set; }

        [DataMember]
        public int Points { get; set; }

        //No comments for CNF

        /// <summary>
        /// Create an anecdote based on only string parameters
        /// </summary>
        /// <param name="fact"></param>
        /// <param name="date"></param>
        /// <param name="vote"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        public static AnecdoteCnf AdaptatorCnf(String fact, String date, String vote, String points)
        {
            //Fact transformation
            var newFact = HttpUtility.HtmlDecode(fact);
            newFact = newFact.Replace("<br />", " ");
            //Date transformation
            var newDate = new DateTime(1970,1,1);
            newDate = newDate.AddSeconds(Double.Parse(date));
            //Vote tansformation
            var newVote = int.Parse(vote);
            //Vote tansformation
            var newPoints = int.Parse(points);

            return new AnecdoteCnf(newFact, newDate, newVote, newPoints);
        }
    }
}