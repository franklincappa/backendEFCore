using EFCoreWebApi.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreWebApi.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {

            //modelBuilder.Entity<Genero>().HasKey(x => x.Id);
            builder.Property(x => x.Nombre).HasMaxLength(150);

            //Agregando data por migración
            var cienciaFiccion = new Genero { Id = 5, Nombre = "Ciencia Ficción" };
            var animacion = new Genero { Id = 6, Nombre = "Animación" };
            builder.HasData(cienciaFiccion, animacion);
        }
    }
}
