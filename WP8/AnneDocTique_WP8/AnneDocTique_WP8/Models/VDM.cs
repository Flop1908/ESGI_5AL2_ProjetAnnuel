using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnneDocTique_WP8.Models
{
    public class VDM 
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public int NbComments { get; set; }
        public string Type { get; set; }
        public string Agree { get; set; }
        public string Deserved { get; set; }

    }
}
