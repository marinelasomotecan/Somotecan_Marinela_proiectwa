using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Somotecan_Marinela_proiectwa.Models;

namespace Somotecan_Marinela_proiectwa.Data
{
    public class Somotecan_Marinela_proiectwaContext : DbContext
    {
        public Somotecan_Marinela_proiectwaContext (DbContextOptions<Somotecan_Marinela_proiectwaContext> options)
            : base(options)
        {
        }

        public DbSet<Somotecan_Marinela_proiectwa.Models.Movie> Movie { get; set; }

        public DbSet<Somotecan_Marinela_proiectwa.Models.Launching> Launching { get; set; }

        public DbSet<Somotecan_Marinela_proiectwa.Models.Category> Category { get; set; }
    }
}
