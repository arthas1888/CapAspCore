using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libreria> Librerias { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.Entity<LibreriaLibro>()
                .HasKey(t => new { t.LibreriaId, t.LibroId });

            modelBuilder.Entity<LibreriaLibro>()
                .HasOne(pt => pt.Libreria)
                .WithMany(p => p.LibreriaLibros)
                .HasForeignKey(pt => pt.LibreriaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LibreriaLibro>()
                .HasOne(pt => pt.Libro)
                .WithMany(t => t.LibreriaLibros)
                .HasForeignKey(pt => pt.LibroId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Libreria>()
                .HasIndex(u => u.Nombre).IsUnique();
        }

       
    }
}
