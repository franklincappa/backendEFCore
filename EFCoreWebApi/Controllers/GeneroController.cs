using AutoMapper;
using EFCoreWebApi.DTOs;
using EFCoreWebApi.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApi.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GeneroController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(GeneroCreacionDTO generoCreacion)
        {
            /*
            var genero = new Genero
            {
                Nombre = generoCreacion.Nombre
            };
            */
            var genero = _mapper.Map<Genero>(generoCreacion);
            _context.Add(genero);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("varios")]
        public async Task<ActionResult> post(GeneroCreacionDTO[] generosCreacionDTO)
        {
            var generos = _mapper.Map<Genero[]>(generosCreacionDTO);
            _context.AddRange(generos);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> Get()
        {
            return await _context.Genero.ToListAsync();
        }
    }
}
