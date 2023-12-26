using EFCoreWebApi.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Genero>().HasKey(x => x.Id);
            modelBuilder.Entity<Genero>().Property(x => x.Nombre).HasMaxLength(150);

            //modelBuilder.Entity<Actor>().HasKey(x => x.Id);
            modelBuilder.Entity<Actor>().Property(x => x.Nombre).HasMaxLength(150);
            modelBuilder.Entity<Actor>().Property(x => x.Fortuna).HasPrecision(18,2);
            modelBuilder.Entity<Actor>().Property(x => x.FechaNacimiento).HasColumnType("date");

            //modelBuilder.Entity<Pelicula>().HasKey(x => x.Id);
            modelBuilder.Entity<Pelicula>().Property(x => x.Titulo).HasMaxLength(150);
            modelBuilder.Entity<Pelicula>().Property(x => x.FechaEstreno).HasColumnType("date");

            modelBuilder.Entity<Comentario>().Property(x => x.Contenido).HasMaxLength(500);

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            //modificamos por defecto string Max sea 150 
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        public DbSet<Genero> Genero => Set<Genero>();
        public DbSet<Actor> Actor => Set<Actor>();
        public DbSet<Pelicula> Pelicula => Set<Pelicula>();
        public DbSet<Comentario> Comentario => Set<Comentario>();     
    }
}
