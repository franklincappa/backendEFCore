using EFCoreWebApi.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreWebApi.Configuraciones
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            //modelBuilder.Entity<Actor>().HasKey(x => x.Id);
            builder.Property(x => x.Nombre).HasMaxLength(150);
            builder.Property(x => x.Fortuna).HasPrecision(18, 2);
            builder.Property(x => x.FechaNacimiento).HasColumnType("date");
        }
    }
}
