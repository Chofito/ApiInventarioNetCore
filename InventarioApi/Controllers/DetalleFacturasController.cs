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
    public class DetalleFacturasController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public DetalleFacturasController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleFacturaDTO>>> Get()
        {
            var detalleFacturas = await _contexto.DetalleFacturas.ToListAsync();
            var detalleFacturasDto = _mapper.Map<List<DetalleFacturaDTO>>(detalleFacturas);
            return detalleFacturasDto;
        }

        [HttpGet("{id}", Name = "GetDetalleFactura")]
        public async Task<ActionResult<DetalleFacturaDTO>> Get(int id)
        {
            var detalleFactura = await _contexto.DetalleFacturas.FirstOrDefaultAsync(x => x.CodigoDetalle.Equals(id));
            if (detalleFactura == null)
            {
                return NotFound();
            }

            var detalleFacturaDto = _mapper.Map<DetalleFacturaDTO>(detalleFactura);
            return detalleFacturaDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DetalleFacturaCreacionDTO detalleFacturaCreacion)
        {
            var detalleFactura = _mapper.Map<DetalleFactura>(detalleFacturaCreacion);
            _contexto.Add((object) detalleFactura);
            await _contexto.SaveChangesAsync();
            var detalleFacturaDto = _mapper.Map<DetalleFacturaDTO>(detalleFactura);
            return new CreatedAtRouteResult("GetDetalleFactura", new {id = detalleFactura.CodigoDetalle},
                detalleFacturaDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DetalleFacturaCreacionDTO detalleFacturaActualizacion)
        {
            var detalleFactura = _mapper.Map<DetalleFactura>(detalleFacturaActualizacion);
            detalleFactura.CodigoDetalle = id;
            _contexto.Entry(detalleFactura).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleFacturaDTO>> Delete(int id)
        {
            var codigoDetalle = await _contexto.DetalleFacturas.Select(x => x.CodigoDetalle)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoDetalle == default(int))
            {
                return NotFound();
            }

            _contexto.Remove(new DetalleFactura {CodigoDetalle = id});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}