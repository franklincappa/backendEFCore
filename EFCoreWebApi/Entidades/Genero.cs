using System.ComponentModel.DataAnnotations;

namespace EFCoreWebApi.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null;
    }

    //Nota: Se puede usar anotaciones de dato o por ApiFluent(Conjunto de métodos para configurar)
    //[Key], [StringLength(maximumLength:150)]

}
