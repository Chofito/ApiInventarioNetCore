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
    public class TelefonoProveedoresController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public TelefonoProveedoresController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelefonoProveedorDTO>>> Get()
        {
            var telefonoProveedor = await _contexto.TelefonoProveedores.ToListAsync();
            var telefonoProveedoresDto = _mapper.Map<List<TelefonoProveedorDTO>>(telefonoProveedor);
            return telefonoProveedoresDto;
        }

        [HttpGet("{id}", Name = "GetTelefonoProveedor")]
        public async Task<ActionResult<TelefonoProveedorDTO>> Get(int id)
        {
            var telefonoProveedor =
                await _contexto.TelefonoProveedores.FirstOrDefaultAsync(x => x.CodigoTelefono.Equals(id));
            if (telefonoProveedor == null)
            {
                return NotFound();
            }

            var telefonoProveedorDto = _mapper.Map<TelefonoProveedorDTO>(telefonoProveedor);
            return telefonoProveedorDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TelefonoProveedorCreacionDTO telefonoProveedorCreacion)
        {
            var telefonoProveedor = _mapper.Map<TelefonoProveedor>(telefonoProveedorCreacion);
            _contexto.Add((object) telefonoProveedor);
            await _contexto.SaveChangesAsync();
            var telefonoProveedorDto = _mapper.Map<TelefonoProveedorDTO>(telefonoProveedor);
            return new CreatedAtRouteResult("GetTelefonoProveedor", new {id = telefonoProveedor.CodigoTelefono},
                telefonoProveedorDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,
            [FromBody] TelefonoProveedorCreacionDTO telefonoProveedorActualizacion)
        {
            var telefonoProveedor = _mapper.Map<TelefonoProveedor>(telefonoProveedorActualizacion);
            telefonoProveedor.CodigoTelefono = id;
            _contexto.Entry(telefonoProveedor).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TelefonoProveedorDTO>> Delete(int id)
        {
            var codigoTelefono = await _contexto.TelefonoProveedores.Select(x => x.CodigoTelefono)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoTelefono == default(int))
            {
                return NotFound();
            }

            _contexto.Remove(new TelefonoProveedor {CodigoTelefono = id});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}