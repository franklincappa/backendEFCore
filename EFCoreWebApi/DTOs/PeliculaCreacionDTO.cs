using EFCoreWebApi.Entidades;

namespace EFCoreWebApi.DTOs
{
    public class PeliculaCreacionDTO
    {
        public string Titulo { get; set; } = null;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        public List<int> Generos { get; set; } = new List<int>();
        public List<PeliculaActorCreacionDTO> peliculasActores { get; set; }
            = new List<PeliculaActorCreacionDTO>();

    }
}
