using AutoMapper;
using EFCoreWebApi.DTOs;
using EFCoreWebApi.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

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

        [HttpPut("{id:int}/nombre2")]
        public async Task<ActionResult> Put(int id)
        {
            //módelo conectado
            var genero = await _context.Genero.FirstOrDefaultAsync(g => g.Id == id);
            if (genero is null)
            {
                return NotFound();
            }
            genero.Nombre = genero.Nombre + "2";

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, GeneroCreacionDTO generoCreacionDTO)
        {
            //módelo desconectado
            var genero = _mapper.Map<Genero>(generoCreacionDTO);
            genero.Id = id;
            _context.Update(genero);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}/moderna")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAlteradas = await _context.Genero.Where(g=> g.Id==id).ExecuteDeleteAsync();
            if (filasAlteradas == 0) 
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:int}/anterior")]
        public async Task<ActionResult> DeleteAnterior(int id)
        {
            var genero = await _context.Genero.FirstOrDefaultAsync(g => g.Id == id);
                
            if (genero is null)
            {
                return NotFound();
            }
            _context.Remove(genero);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
