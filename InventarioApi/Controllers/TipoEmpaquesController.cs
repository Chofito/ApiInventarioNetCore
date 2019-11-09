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
    public class TipoEmpaquesController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public TipoEmpaquesController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEmpaqueDTO>>> Get()
        {
            var tipoEmpaques = await _contexto.TipoEmpaques.ToListAsync();
            var tipoEmpaquesDto = _mapper.Map<List<TipoEmpaqueDTO>>(tipoEmpaques);
            return tipoEmpaquesDto;
        }

        [HttpGet("{id}", Name = "GetTipoEmpaques")]
        public async Task<ActionResult<TipoEmpaqueDTO>> Get(int id)
        {
            var tipoEmpaque = await _contexto.TipoEmpaques.FirstOrDefaultAsync(x => x.CodigoEmpaque == id);
            if (tipoEmpaque == null)
            {
                return NotFound();
            }

            var tipoEmpaqueDto = _mapper.Map<TipoEmpaqueDTO>(tipoEmpaque);
            return tipoEmpaqueDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoEmpaqueCreacionDTO tipoEmpaqueCreacion)
        {
            var tipoEmpaque = _mapper.Map<TipoEmpaque>(tipoEmpaqueCreacion);
            _contexto.Add((object) tipoEmpaque);
            await _contexto.SaveChangesAsync();
            var tipoEmpaqueDto = _mapper.Map<TipoEmpaqueDTO>(tipoEmpaque);
            return new CreatedAtRouteResult("GetTipoEmpaques", new {id = tipoEmpaque.CodigoEmpaque},
                tipoEmpaqueDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoEmpaqueCreacionDTO tipoEmpaqueActualizacion)
        {
            var tipoEmpaque = _mapper.Map<TipoEmpaque>(tipoEmpaqueActualizacion);
            tipoEmpaque.CodigoEmpaque = id;
            _contexto.Entry(tipoEmpaque).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoEmpaqueDTO>> Delete(int id)
        {
            var codigoEmpaque = await _contexto.TipoEmpaques.Select(x => x.CodigoEmpaque)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoEmpaque == default)
            {
                return NotFound();
            }

            _contexto.Remove(new TipoEmpaque {CodigoEmpaque = id});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}