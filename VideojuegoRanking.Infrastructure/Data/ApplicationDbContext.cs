using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using VideojuegoRanking.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace VideojuegoRanking.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Videojuego> Videojuegos { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Videojuego>()
                .HasMany(v => v.Calificaciones)
                .WithOne(c => c.Videojuego)
                .HasForeignKey(c => c.VideojuegoId);


        }
    }
}
