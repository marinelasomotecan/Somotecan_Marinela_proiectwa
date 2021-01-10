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

namespace Somotecan_Marinela_proiectwa.Pages.Movies
{
    public class EditModel : MovieCategoriesPageModel
    {
        private readonly Somotecan_Marinela_proiectwa.Data.Somotecan_Marinela_proiectwaContext _context;

        public EditModel(Somotecan_Marinela_proiectwa.Data.Somotecan_Marinela_proiectwaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie
                .Include(b => b.Launching)
                .Include(b => b.MovieCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Movie);

            ViewData["LaunchingID"] = new SelectList(_context.Set<Launching>(), "ID", "LaunchingName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)

        {
            if (id == null)
            {
                return NotFound();
            }
            if (id == null)
            {
                return NotFound();
            }
            var movieToUpdate = await _context.Movie
                .Include(i => i.Launching)
                .Include(i => i.MovieCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (movieToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Movie>(movieToUpdate, "Movie",
i => i.Title, i => i.Author,
i => i.Price, i => i.LaunchingDate, i => i.Launching))
            {
                UpdateMovieCategories(_context, selectedCategories, movieToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateMovieCategories(_context, selectedCategories, movieToUpdate);
            PopulateAssignedCategoryData(_context, movieToUpdate);
            return Page();
        }
    }
}