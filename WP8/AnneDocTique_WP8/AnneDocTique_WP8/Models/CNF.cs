using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnneDocTique_WP8.Models
{
    public class CNF 
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Texte { get; set; }
        public int Points { get; set; }
        public int Vote { get; set; }
        public string Type { get; set; }
    }
}
