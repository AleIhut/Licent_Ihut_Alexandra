using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Licent_Ihut_Alexandra.Models;

namespace Licent_Ihut_Alexandra.Data
{
    public class Licent_Ihut_AlexandraContext : DbContext
    {
        public Licent_Ihut_AlexandraContext (DbContextOptions<Licent_Ihut_AlexandraContext> options)
            : base(options)
        {
        }

        public DbSet<Licent_Ihut_Alexandra.Models.SalaEveniment> SalaEveniment { get; set; } = default!;

        public DbSet<Licent_Ihut_Alexandra.Models.Sonorizare> Sonorizare { get; set; }

        public DbSet<Licent_Ihut_Alexandra.Models.GenMuzical> GenMuzical { get; set; }

        public DbSet<Licent_Ihut_Alexandra.Models.Material> Material { get; set; }

        public DbSet<Licent_Ihut_Alexandra.Models.Decoratiune> Decoratiune { get; set; }

        public DbSet<Licent_Ihut_Alexandra.Models.Fotograf> Fotograf { get; set; }

        public DbSet<Licent_Ihut_Alexandra.Models.Artist> Artist { get; set; }

        public DbSet<Licent_Ihut_Alexandra.Models.Hostes> Hostes { get; set; }

        public DbSet<Licent_Ihut_Alexandra.Models.MaterialPirotehnic> MaterialPirotehnic { get; set; }

        public DbSet<Licent_Ihut_Alexandra.Models.Prajitura> Prajitura { get; set; }

        public DbSet<Licent_Ihut_Alexandra.Models.Judet> Judet { get; set; }
        public DbSet<Licent_Ihut_Alexandra.Models.Localitate> Localitate { get; set; }

    }
}
