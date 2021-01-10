using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Somotecan_Marinela_proiectwa.Data;
using Somotecan_Marinela_proiectwa.Models;

namespace Somotecan_Marinela_proiectwa.Pages.Launches
{
    public class DetailsModel : PageModel
    {
        private readonly Somotecan_Marinela_proiectwa.Data.Somotecan_Marinela_proiectwaContext _context;

        public DetailsModel(Somotecan_Marinela_proiectwa.Data.Somotecan_Marinela_proiectwaContext context)
        {
            _context = context;
        }

        public Launching Launching { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Launching = await _context.Launching.FirstOrDefaultAsync(m => m.ID == id);

            if (Launching == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
