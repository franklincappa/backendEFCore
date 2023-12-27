using EFCoreWebApi.Entidades;

namespace EFCoreWebApi.DTOs
{
    public class PeliculaActorCreacionDTO
    {
        public int ActorId { get; set; }
        public string Personaje { get; set; } = null!;
    }
}
