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
    public class EmailClientesController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public EmailClientesController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailClienteDTO>>> Get()
        {
            var emailCliente = await _contexto.Emailclientes.ToListAsync();
            var emailClienteDto = _mapper.Map<List<EmailClienteDTO>>(emailCliente);
            return emailClienteDto;
        }

        [HttpGet("{id}", Name = "GetEmailCliente")]
        public async Task<ActionResult<EmailClienteDTO>> Get(int id)
        {
            var emailCliente = await _contexto.Emailclientes.FirstOrDefaultAsync(x => x.CodigoEmail.Equals(id));
            if (emailCliente == null)
            {
                return NotFound();
            }

            var emailClienteDto = _mapper.Map<EmailClienteDTO>(emailCliente);
            return emailClienteDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmailClienteCreacionDTO emailClienteCreacion)
        {
            var emailCliente = _mapper.Map<Emailcliente>(emailClienteCreacion);
            _contexto.Add((object) emailCliente);
            await _contexto.SaveChangesAsync();
            var emailClienteDto = _mapper.Map<EmailClienteDTO>(emailCliente);
            return new CreatedAtRouteResult("GetEmailCliente", new {id = emailCliente.CodigoEmail},
                emailClienteDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmailClienteCreacionDTO emailClienteActualizacion)
        {
            var emailCliente = _mapper.Map<Emailcliente>(emailClienteActualizacion);
            emailCliente.CodigoEmail = id;
            _contexto.Entry(emailCliente).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmailClienteDTO>> Delete(int id)
        {
            var codigoEmail = await _contexto.Emailclientes.Select(x => x.CodigoEmail)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoEmail == default(int))
            {
                return NotFound();
            }

            _contexto.Remove(new Emailcliente {CodigoEmail = id});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}