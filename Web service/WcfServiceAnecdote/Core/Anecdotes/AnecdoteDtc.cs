using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Core.Comments;
using HtmlAgilityPack;
using System.Web;

namespace Core.Anecdotes
{
    [DataContract(Name = "AnecdoteDtc")]
    public class AnecdoteDtc
    {
        [DataMember]
        public String Type = "DTC";
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Text { get; set; }
        [DataMember]
        public int Good { get; set; }
        [DataMember]
        public int Bad { get; set; }
        [DataMember]
        public int NbComments { get; set; }

        public AnecdoteDtc()
        {
            Id = 0;
            Text = "Anecdote DTC";
            Good = 0;
            Bad = 0;
            NbComments = 0;
        }

        public AnecdoteDtc(AnecdoteDtc anecdoteDtc)
        {
            Id = anecdoteDtc.Id;
            Text = anecdoteDtc.Text;
            Good = anecdoteDtc.Good;
            Bad = anecdoteDtc.Bad;
            NbComments = anecdoteDtc.NbComments;
        }

        public AnecdoteDtc(int id, string content, int good, int bad, int nbComments)
        {
            Id = id;
            Text = content;
            Good = good;
            Bad = bad;
            NbComments = nbComments;
        }

        public AnecdoteDtc(HtmlNode rawAnecdoteDtc)
        {
            int newId;
            String newContent;
            int newGood;
            int newBad;
            int newNbComments;

            newId = NumberFromString(rawAnecdoteDtc.Attributes["class"].Value);
            newContent = rawAnecdoteDtc.FirstChild.FirstChild.InnerText;
            newBad = NumberFromString(rawAnecdoteDtc.SelectSingleNode("//*[@class=\"vote voteminus\"]").InnerText);
            newGood = NumberFromString(rawAnecdoteDtc.SelectSingleNode("//*[@class=\"vote voteplus\"]").InnerText);
            newNbComments = NumberFromString(rawAnecdoteDtc.SelectSingleNode("//*[@title=\"Commentaires\"]").InnerText);

            //Suppression des caractères spéciaux
            Id = newId;
            Text = HttpUtility.HtmlDecode(newContent);
            Good = newGood;
            Bad = newBad;
            NbComments = newNbComments;
        }

        private int NumberFromString(string p)
        {
            var sbId = new StringBuilder();

            foreach (var caractere in p)
            
                if (Char.IsDigit(caractere))
                
                    sbId.Append(caractere);
                
            

            return int.Parse(sbId.ToString());
        }
    }
}