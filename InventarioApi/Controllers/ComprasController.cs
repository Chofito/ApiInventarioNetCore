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
    public class ComprasController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public ComprasController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraDTO>>> Get()
        {
            var compra = await _contexto.Compras.ToListAsync();
            var compraDto = _mapper.Map<List<CompraDTO>>(compra);
            return compraDto;
        }

        [HttpGet("{id}", Name = "GetCompra")]
        public async Task<ActionResult<CompraDTO>> Get(int id)
        {
            var compra = await _contexto.Compras.FirstOrDefaultAsync(x => x.CodigoCompra.Equals(id));
            if (compra == null)
            {
                return NotFound();
            }

            var compraDto = _mapper.Map<CompraDTO>(compra);
            return compraDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CompraCreacionDTO compraCreacion)
        {
            var compra = _mapper.Map<Compra>(compraCreacion);
            _contexto.Add((object) compra);
            await _contexto.SaveChangesAsync();
            var compraDto = _mapper.Map<CompraDTO>(compra);
            return new CreatedAtRouteResult("GetCompra", new {id = compra.CodigoCompra},
                compraDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CompraCreacionDTO compraActualizacion)
        {
            var compra = _mapper.Map<Compra>(compraActualizacion);
            compra.CodigoCompra = id;
            _contexto.Entry(compra).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CompraDTO>> Delete(int id)
        {
            var compra = await _contexto.Compras.Select(x => x.CodigoCompra)
                .FirstOrDefaultAsync(x => x == id);
            if (compra == default(int))
            {
                return NotFound();
            }

            _contexto.Remove(new Compra {CodigoCompra = id});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}