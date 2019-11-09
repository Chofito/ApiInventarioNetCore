using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InventarioApi.Contexts;
using InventarioApi.Entities;
using InventarioApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public InventariosController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventarioDTO>>> Get()
        {
            var inventarios = await _contexto.Inventarios.ToListAsync();
            var inventariosDTO = _mapper.Map<List<InventarioDTO>>(inventarios);
            return inventariosDTO;
        }

        [HttpGet("{id}", Name = "GetInventario")]
        public async Task<ActionResult<InventarioDTO>> Get(int id)
        {
            var inventario = await _contexto.Inventarios.FirstOrDefaultAsync(x => x.CodigoInventario.Equals(id));
            if (inventario == null)
            {
                return NotFound();
            }

            var inventarioDTO = _mapper.Map<InventarioDTO>(inventario);
            return inventarioDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InventarioCreacionDTO inventarioCreacion)
        {
            var inventario = _mapper.Map<Inventario>(inventarioCreacion);
            _contexto.Add((object) inventario);
            await _contexto.SaveChangesAsync();
            var inventarioDTO = _mapper.Map<InventarioDTO>(inventario);
            return new CreatedAtRouteResult("GetInventario", new {id = inventario.CodigoInventario},
                inventarioDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] InventarioCreacionDTO inventarioActualizacion)
        {
            var inventario = _mapper.Map<Inventario>(inventarioActualizacion);
            inventario.CodigoInventario = id;
            _contexto.Entry(inventario).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<InventarioDTO>> Delete(int id)
        {
            var codigoInventario = await _contexto.Inventarios.Select(x => x.CodigoInventario)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoInventario == default(int))
            {
                return NotFound();
            }

            _contexto.Remove(new Inventario {CodigoInventario = id});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}