using EFCoreWebApi.Entidades;

namespace EFCoreWebApi.DTOs
{
    public class ComentarioCreacionDTO
    {
        public string? Contenido { get; set; }
        public bool Recomendar { get; set; }
    }
}
