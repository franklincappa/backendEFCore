using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreWebApi.DTOs;
using EFCoreWebApi.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApi.Controllers
{
    [Route("api/actores")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacionDTO)
        {
            var actor = _mapper.Map<Actor>(actorCreacionDTO);
            _context.Add(actor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get() 
        {
            //return await _context.Actor.ToListAsync();
            //Ordenar
            //return await _context.Actor.OrderBy(a => a.FechaNacimiento).ToListAsync();
            return await _context.Actor.OrderByDescending(a => a.FechaNacimiento).ToListAsync();
        }

        [HttpGet("nombre")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(String nombre)
        {
            //return await _context.Actor.Where(a => a.Nombre == nombre).ToListAsync();

            return await _context.Actor
                .Where(a => a.Nombre == nombre)
                .OrderBy(a=>a.Nombre)
                    .ThenBy(a => a.FechaNacimiento)
                .ToListAsync();

        }

        [HttpGet("nombre/like")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetNombreLike(String nombre)
        {
            return await _context.Actor.Where(a => a.Nombre.Contains(nombre)).ToListAsync();
        }

        [HttpGet("fechaNacimiento/rango")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActoresFechaNacimientoRango(DateTime inicio, DateTime fin)
        {
            return await _context.Actor.Where(a => 
            a.FechaNacimiento>= inicio && a.FechaNacimiento <= fin).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> GetActorId(int id)
        {
            var actor = await _context.Actor.FirstOrDefaultAsync(a => a.Id==id);
            if (actor == null) {
                return NotFound();
            }
            return actor;
        }

        [HttpGet("idynombre")]
        public async Task<ActionResult> GetActorIdNombre()
        {
            var actores =  await _context.Actor.Select(a => new { a.Id, a.Nombre}).ToListAsync(); 
            return Ok(actores);
        }

        [HttpGet("idynombre/v2")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetActorIdNombreV2()
        {
            //return await _context.Actor
            //    .Select(a => new ActorDTO{Id= a.Id, Nombre= a.Nombre }).ToListAsync();
            //    
            return await _context.Actor
                  .ProjectTo<ActorDTO>(_mapper.ConfigurationProvider)
                  .ToListAsync();
        }

    }
}
