using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Somotecan_Marinela_proiectwa.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Movie Title")]
        public string Title { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele autorului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)]
        public string Author { get; set; }
        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime LaunchingDate { get; set; }
        public int LaunchingID { get; set; }
        public Launching Launching { get; set; }

        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
