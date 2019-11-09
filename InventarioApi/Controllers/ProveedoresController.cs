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
    public class ProveedoresController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public ProveedoresController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProveedorDTO>>> Get()
        {
            var proveedor = await _contexto.Proveedores.ToListAsync();
            var proveedorDto = _mapper.Map<List<ProveedorDTO>>(proveedor);
            return proveedorDto;
        }

        [HttpGet("{id}", Name = "GetProveedor")]
        public async Task<ActionResult<ProveedorDTO>> Get(int id)
        {
            var proveedor = await _contexto.Proveedores.FirstOrDefaultAsync(x => x.CodigoProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            var proveedorDto = _mapper.Map<ProveedorDTO>(proveedor);
            return proveedorDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProveedorCreacionDTO proveedorCreacion)
        {
            var proveedor = _mapper.Map<Proveedor>(proveedorCreacion);
            _contexto.Add((object) proveedor);
            await _contexto.SaveChangesAsync();
            var proveedorDto = _mapper.Map<ProveedorDTO>(proveedor);
            return new CreatedAtRouteResult("GetProveedor", new {id = proveedor.CodigoProveedor},
                proveedorDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProveedorCreacionDTO proveedorActualizacion)
        {
            var proveedor = _mapper.Map<Proveedor>(proveedorActualizacion);
            proveedor.CodigoProveedor = id;
            _contexto.Entry(proveedor).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProveedorDTO>> Delete(int id)
        {
            var codigoProveedor = await _contexto.Proveedores.Select(x => x.CodigoProveedor)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoProveedor == default)
            {
                return NotFound();
            }

            _contexto.Remove(new Proveedor {CodigoProveedor = id});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}