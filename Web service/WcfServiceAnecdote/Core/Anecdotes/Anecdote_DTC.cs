using System;
using System.Runtime.Serialization;

namespace Core.Anecdotes
{
    [DataContract]
    public class AnecdoteDtc
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Content { get; set; }

        public AnecdoteDtc(int id, string content/*, DateTime parution, int good, int bad, List<CommentDtc> listComments*/)
        {
            Id = id;
            Content = content;
            /*
            Parution = parution;
            Good = good;
            Bad = bad;
            ListComments = listComments;
             * */
        }

        public AnecdoteDtc(AnecdoteDtc anecdoteDtc)
        {
            Id = anecdoteDtc.Id;
            Content = anecdoteDtc.Content;
        }

        /*
        [DataMember]
        public DateTime Parution { get; set; }
        [DataMember]
        public int Good { get; set; }
        [DataMember]
        public int Bad { get; set; }
        [DataMember]
        public List<CommentDtc> ListComments { get; set; }
         */

        public static AnecdoteDtc AdaptatorDtc(String id, String content)
        {
            //Id transformation
            var newId = int.Parse(id);
            //Content transformation
            var newContent = content.Trim();

            return new AnecdoteDtc(newId,newContent);
        }
    }
}
