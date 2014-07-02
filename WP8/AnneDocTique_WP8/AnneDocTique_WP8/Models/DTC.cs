using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnneDocTique_WP8.Models
{
    class DTC 
    {
        public int Id { get; set; }
        public int Bad { get; set; }
        public int Good { get; set; }
        public int NbComments { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }
}
