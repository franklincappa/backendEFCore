using EFCoreWebApi.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreWebApi.Configuraciones
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            builder.HasKey(x => new { x.ActorId, x.PeliculaId });
        }
    }
}
