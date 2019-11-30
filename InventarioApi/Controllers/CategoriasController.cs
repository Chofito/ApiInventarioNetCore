using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InventarioApi.Contexts;
using InventarioApi.Entities;
using InventarioApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriasController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public CategoriasController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await _contexto.Categorias.Include("Productos").ToListAsync();
            var categoriasDto = _mapper.Map<List<CategoriaDTO>>(categorias);
            return categoriasDto;
        }

        // TODO: PaginatorData with `Errors` field and Try/Catch.
        [HttpGet("paged")]
        public async Task<ActionResult<PaginatorData<CategoriaDTO>>> GetPaged(int pagina = 0, int cantidad = 10)
        {
            var result = new PaginatorData<CategoriaDTO>();
            var categorias = await _contexto.Categorias.Skip(cantidad * pagina).Take(cantidad).ToListAsync();
            
            var total = categorias.Count / cantidad;
            
            result.Content = _mapper.Map<List<CategoriaDTO>>(categorias);
            result.Empty = result.Content.Any();
            result.First = pagina == 0;
            result.Last = total == pagina;
            result.PageNumber = pagina;
            result.TotalPages = total;

            return result;
        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            var categoria = await _contexto.Categorias.FirstOrDefaultAsync(x => x.CodigoCategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
            return categoriaDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaCreacionDTO categoriaCreacion)
        {
            var categoria = _mapper.Map<Categoria>(categoriaCreacion);
            _contexto.Add((object) categoria);
            await _contexto.SaveChangesAsync();
            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
            return new CreatedAtRouteResult("GetCategoria", new {id = categoria.CodigoCategoria},
                categoriaDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaCreacionDTO categoriaActualizacion)
        {
            var categoria = _mapper.Map<Categoria>(categoriaActualizacion);
            categoria.CodigoCategoria = id;
            _contexto.Entry(categoria).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            var codigoCategoria = await _contexto.Categorias.Select(x => x.CodigoCategoria)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoCategoria == default(int))
            {
                return NotFound();
            }

            _contexto.Remove(new Categoria {CodigoCategoria = id});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}