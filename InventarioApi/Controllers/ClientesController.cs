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
    public class ClientesController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public ClientesController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var clientes = await _contexto.Clientes.ToListAsync();
            var clientesDto = _mapper.Map<List<ClienteDTO>>(clientes);
            return clientesDto;
        }

        [HttpGet("{nit}", Name = "GetClientes")]
        public async Task<ActionResult<ClienteDTO>> Get(string nit)
        {
            var cliente = await _contexto.Clientes.FirstOrDefaultAsync(x => x.Nit.Equals(nit));
            if (cliente == null)
            {
                return NotFound();
            }

            var clienteDto = _mapper.Map<ClienteDTO>(cliente);
            return clienteDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteCreacionDTO clienteCreacion)
        {
            var cliente = _mapper.Map<Cliente>(clienteCreacion);
            _contexto.Add((object) cliente);
            await _contexto.SaveChangesAsync();
            var clienteDto = _mapper.Map<ClienteDTO>(cliente);
            return new CreatedAtRouteResult("GetClientes",
                new {nit = cliente.Nit, dpi = cliente.Dpi, nombre = cliente.Nombre, direccion = cliente.Direccion},
                clienteDto);
        }

        [HttpPut("{nit}")]
        public async Task<ActionResult> Put(string nit, [FromBody] ClienteCreacionDTO clienteActualizacion)
        {
            var cliente = _mapper.Map<Cliente>(clienteActualizacion);
            cliente.Nit = nit;
            _contexto.Entry(cliente).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{nit}")]
        public async Task<ActionResult<ClienteDTO>> Delete(string nit)
        {
            var nitCliente = await _contexto.Clientes.Select(x => x.Nit)
                .FirstOrDefaultAsync(x => x == nit);
            if (nitCliente == default(string))
            {
                return NotFound();
            }

            _contexto.Remove(new Cliente {Nit = nit});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}