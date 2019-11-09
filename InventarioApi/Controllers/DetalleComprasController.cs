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
    public class DetalleComprasController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public DetalleComprasController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleCompraDTO>>> Get()
        {
            var detalleCompra = await _contexto.DetalleCompras.ToListAsync();
            var detalleCompraDto = _mapper.Map<List<DetalleCompraDTO>>(detalleCompra);
            return detalleCompraDto;
        }

        [HttpGet("{id}", Name = "GetDetalleProducto")]
        public async Task<ActionResult<DetalleCompraDTO>> Get(int id)
        {
            var detalleCompra = await _contexto.DetalleCompras.FirstOrDefaultAsync(x => x.IdDetalle.Equals(id));
            if (detalleCompra == null)
            {
                return NotFound();
            }

            var detalleCompraDto = _mapper.Map<DetalleCompraDTO>(detalleCompra);
            return detalleCompraDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DetalleCompraCreacionDTO detalleCompraCreacion)
        {
            var detalleCompra = _mapper.Map<DetalleCompra>(detalleCompraCreacion);
            _contexto.Add((object) detalleCompra);
            await _contexto.SaveChangesAsync();
            var detalleCompraDto = _mapper.Map<DetalleCompraDTO>(detalleCompra);
            return new CreatedAtRouteResult("GetDetalleProducto", new {id = detalleCompra.IdDetalle},
                detalleCompraDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DetalleCompraCreacionDTO detalleCompraActualizacion)
        {
            var detalleCompra = _mapper.Map<DetalleCompra>(detalleCompraActualizacion);
            detalleCompra.IdDetalle = id;
            _contexto.Entry(detalleCompra).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleCompraDTO>> Delete(int id)
        {
            var idDetalle = await _contexto.DetalleCompras.Select(x => x.IdDetalle)
                .FirstOrDefaultAsync(x => x == id);
            if (idDetalle == default(int))
            {
                return NotFound();
            }

            _contexto.Remove(new DetalleCompra {IdDetalle = id});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}