using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_ZOO.Models;

namespace Proiect_Medii_ZOO.Data
{
    public class Proiect_Medii_ZOOContext : DbContext
    {
        public Proiect_Medii_ZOOContext (DbContextOptions<Proiect_Medii_ZOOContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Medii_ZOO.Models.Animal> Animal { get; set; } = default!;
        public DbSet<Proiect_Medii_ZOO.Models.Keeper> Keeper { get; set; } = default!;
        public DbSet<Proiect_Medii_ZOO.Models.Enclosure> Enclosure { get; set; } = default!;
        public DbSet<Proiect_Medii_ZOO.Models.Diet> Diet { get; set; } = default!;
        public DbSet<Proiect_Medii_ZOO.Models.Employee> Employee { get; set; } = default!;
    }
}
