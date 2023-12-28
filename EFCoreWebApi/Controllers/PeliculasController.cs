using AutoMapper;
using EFCoreWebApi.DTOs;
using EFCoreWebApi.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PeliculasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PeliculaCreacionDTO peliculaCreacionDTO)
        {
            var pelicula = _mapper.Map<Pelicula>(peliculaCreacionDTO);
            if (pelicula.Generos is not null)
            {
                foreach (var genero in pelicula.Generos)
                {
                    _context.Entry(genero).State = EntityState.Unchanged;                
                }
            }
            if (pelicula.PeliculasActores is not null)
            {
                for (int i = 0; i < pelicula.PeliculasActores.Count; i++)
                {
                    pelicula.PeliculasActores[i].Orden = i + 1;
                }
            }

            _context.Add(pelicula);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pelicula>> Get(int id)
        { 
            //eager loading
            var pelicula = await _context.Pelicula
                .Include(p=>p.Comentarios)
                .Include(p => p.Generos)
                .Include(p => p.PeliculasActores.OrderBy(pa => pa.Orden))
                    .ThenInclude(p => p.Actor)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return pelicula;
        }

        [HttpGet("select /{id:int}")]
        public async Task<ActionResult> GetSelect(int id)
        {
            //select loading
            var pelicula = await _context.Pelicula
                .Select(pel=> new { 
                    pel.Id,
                    pel.Titulo,
                    Genero= pel.Generos.Select(g=> g.Nombre).ToList(),
                    Actores= pel.PeliculasActores.OrderBy(pa=> pa.Orden).Select(
                        pa=> new {
                            Id= pa.ActorId,
                            pa.Actor.Nombre,
                            pa.Personaje
                        }),
                    cantidadComentarios = pel.Comentarios.Count()     
                })                
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpDelete("{id:int}/moderna")]
        public async Task<ActionResult> DeletePelicula(int id)
        {
            var filasAlteradas = await _context.Pelicula.Where(p => p.Id == id).ExecuteDeleteAsync();
            if (filasAlteradas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }



    }
}
