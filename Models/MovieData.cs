using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Somotecan_Marinela_proiectwa.Models
{
    public class MovieData
    {
        public IEnumerable<Movie> Movie { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<MovieCategory> MovieCategories { get; set; }
    }
}
