using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Somotecan_Marinela_proiectwa.Data;
using Somotecan_Marinela_proiectwa.Models;

namespace Somotecan_Marinela_proiectwa.Pages.Launches
{
    public class EditModel : PageModel
    {
        private readonly Somotecan_Marinela_proiectwa.Data.Somotecan_Marinela_proiectwaContext _context;

        public EditModel(Somotecan_Marinela_proiectwa.Data.Somotecan_Marinela_proiectwaContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Launching).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaunchingExists(Launching.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LaunchingExists(int id)
        {
            return _context.Launching.Any(e => e.ID == id);
        }
    }
}
