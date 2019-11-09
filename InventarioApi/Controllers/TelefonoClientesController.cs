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
    public class TelefonoClientesController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public TelefonoClientesController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelefonoClienteDTO>>> Get()
        {
            var telefonoCliente = await _contexto.TelefonoClientes.ToListAsync();
            var telefonoClienteDto = _mapper.Map<List<TelefonoClienteDTO>>(telefonoCliente);
            return telefonoClienteDto;
        }

        [HttpGet("{id}", Name = "GetTelefonoCliente")]
        public async Task<ActionResult<TelefonoClienteDTO>> Get(int id)
        {
            var telefonoCliente =
                await _contexto.TelefonoClientes.FirstOrDefaultAsync(x => x.CodigoTelefono.Equals(id));
            if (telefonoCliente == null)
            {
                return NotFound();
            }

            var telefonoClienteDto = _mapper.Map<TelefonoClienteDTO>(telefonoCliente);
            return telefonoClienteDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TelefonoClienteCreacionDTO telefonoClienteCreacion)
        {
            var telefonoCliente = _mapper.Map<TelefonoCliente>(telefonoClienteCreacion);
            _contexto.Add((object) telefonoCliente);
            await _contexto.SaveChangesAsync();
            var telefonoClienteDto = _mapper.Map<TelefonoClienteDTO>(telefonoCliente);
            return new CreatedAtRouteResult("GetTelefonoCliente", new {id = telefonoCliente.CodigoTelefono},
                telefonoClienteDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TelefonoClienteCreacionDTO telefonoClienteActualizacion)
        {
            var telefonoCliente = _mapper.Map<TelefonoCliente>(telefonoClienteActualizacion);
            telefonoCliente.CodigoTelefono = id;
            _contexto.Entry(telefonoCliente).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TelefonoClienteDTO>> Delete(int id)
        {
            var codigoTelefono = await _contexto.TelefonoClientes.Select(x => x.CodigoTelefono)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoTelefono == default)
            {
                return NotFound();
            }

            _contexto.Remove(new TelefonoCliente {CodigoTelefono = id});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}