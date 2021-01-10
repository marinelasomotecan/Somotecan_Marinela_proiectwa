using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Somotecan_Marinela_proiectwa.Data;
using Somotecan_Marinela_proiectwa.Models;

namespace Somotecan_Marinela_proiectwa.Pages.Movies
{
    public class CreateModel : MovieCategoriesPageModel
    {
        private readonly Somotecan_Marinela_proiectwa.Data.Somotecan_Marinela_proiectwaContext _context;

        public CreateModel(Somotecan_Marinela_proiectwa.Data.Somotecan_Marinela_proiectwaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["LaunchingID"] = new SelectList(_context.Set<Launching>(), "ID", "LaunchingName");
            var movie = new Movie();
            movie.MovieCategories = new List<MovieCategory>();
            PopulateAssignedCategoryData(_context, movie);
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newMovie = new Movie(); if (selectedCategories != null)
            {
                newMovie.MovieCategories = new List<MovieCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new MovieCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newMovie.MovieCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Movie>(
                newMovie, "Movie",
                i => i.Title, i => i.Author, i => i.Price, i => i.LaunchingDate, i => i.LaunchingID))
            {
                _context.Movie.Add(newMovie);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newMovie);
            return Page();
        }
    }
}

