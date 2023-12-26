using EFCoreWebApi.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreWebApi.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            //modelBuilder.Entity<Pelicula>().HasKey(x => x.Id);
            builder.Property(x => x.Titulo).HasMaxLength(150);
            builder.Property(x => x.FechaEstreno).HasColumnType("date");
        }
    }
}
