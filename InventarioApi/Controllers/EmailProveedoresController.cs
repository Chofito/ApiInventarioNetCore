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
    public class EmailProveedoresController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public EmailProveedoresController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailProveedorDTO>>> Get()
        {
            var emailProveedor = await _contexto.Emailclientes.ToListAsync();
            var emailProveedorDto = _mapper.Map<List<EmailProveedorDTO>>(emailProveedor);
            return emailProveedorDto;
        }

        [HttpGet("{id}", Name = "GetEmailProveedor")]
        public async Task<ActionResult<EmailProveedorDTO>> Get(int id)
        {
            var emailProveedor = await _contexto.EmailProveedores.FirstOrDefaultAsync(x => x.CodigoEmail.Equals(id));
            if (emailProveedor == null)
            {
                return NotFound();
            }

            var emailProveedorDto = _mapper.Map<EmailProveedorDTO>(emailProveedor);
            return emailProveedorDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmailProveedorCreacionDTO emailProveedorCreacion)
        {
            var emailProveedor = _mapper.Map<EmailProveedor>(emailProveedorCreacion);
            _contexto.Add((object) emailProveedor);
            await _contexto.SaveChangesAsync();
            var emailProveedorDto = _mapper.Map<EmailProveedorDTO>(emailProveedor);
            return new CreatedAtRouteResult("GetEmailProveedor", new {id = emailProveedor.CodigoEmail},
                emailProveedorDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmailProveedorCreacionDTO emailProveedprActualizacion)
        {
            var emailProveedor = _mapper.Map<EmailProveedor>(emailProveedprActualizacion);
            emailProveedor.CodigoEmail = id;
            _contexto.Entry(emailProveedor).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmailProveedorDTO>> Delete(int id)
        {
            var emailProveedor = await _contexto.EmailProveedores.Select(x => x.CodigoEmail)
                .FirstOrDefaultAsync(x => x == id);
            if (emailProveedor == default(int))
            {
                return NotFound();
            }

            _contexto.Remove(new EmailProveedor {CodigoEmail = id});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}