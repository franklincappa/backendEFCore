using EFCoreWebApi.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
            //Cargar Configuraciones Api Fluent de las entidades
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
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
