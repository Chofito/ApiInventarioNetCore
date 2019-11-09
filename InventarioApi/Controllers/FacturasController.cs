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
    public class FacturasController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public FacturasController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaDTO>>> Get()
        {
            var facturas = await _contexto.Facturas.ToListAsync();
            var facturasDto = _mapper.Map<List<FacturaDTO>>(facturas);
            return facturasDto;
        }

        [HttpGet("{id}", Name = "GetFactura")]
        public async Task<ActionResult<FacturaDTO>> Get(int id)
        {
            var factura = await _contexto.Facturas.Include("DetalleFacturas")
                .FirstOrDefaultAsync(x => x.Numerofactura.Equals(id));
            if (factura == null)
            {
                return NotFound();
            }

            var facturaDto = _mapper.Map<FacturaDTO>(factura);
            return facturaDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FacturaCreacionDTO facturaCreacion)
        {
            var factura = _mapper.Map<Factura>(facturaCreacion);
            _contexto.Add((object) factura);
            await _contexto.SaveChangesAsync();
            var facturaDto = _mapper.Map<FacturaDTO>(factura);
            return new CreatedAtRouteResult("GetFactura", new {id = factura.Numerofactura},
                facturaDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] FacturaCreacionDTO facturaActualizacion)
        {
            var factura = _mapper.Map<Factura>(facturaActualizacion);
            factura.Numerofactura = id;
            _contexto.Entry(factura).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FacturaDTO>> Delete(int id)
        {
            var numeroFactura = await _contexto.Facturas.Select(x => x.Numerofactura)
                .FirstOrDefaultAsync(x => x == id);
            if (numeroFactura == default(int))
            {
                return NotFound();
            }

            _contexto.Remove(new Factura {Numerofactura = id});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}