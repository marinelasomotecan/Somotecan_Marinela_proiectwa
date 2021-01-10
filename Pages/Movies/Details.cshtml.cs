using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Somotecan_Marinela_proiectwa.Data;
using Somotecan_Marinela_proiectwa.Models;

namespace Somotecan_Marinela_proiectwa.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly Somotecan_Marinela_proiectwa.Data.Somotecan_Marinela_proiectwaContext _context;

        public DetailsModel(Somotecan_Marinela_proiectwa.Data.Somotecan_Marinela_proiectwaContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
