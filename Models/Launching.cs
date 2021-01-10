using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Somotecan_Marinela_proiectwa.Models
{
    public class Launching
    {
        public int ID { get; set; }
        public string LaunchingName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
