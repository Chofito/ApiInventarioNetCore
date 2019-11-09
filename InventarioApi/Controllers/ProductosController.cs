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
    public class ProductosController : ControllerBase
    {
        private readonly InventarioDBContext _contexto;
        private readonly IMapper _mapper;

        public ProductosController(InventarioDBContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> Get()
        {
            var productos = await _contexto.Productos.Include("Categoria").Include("TipoEmpaque").ToListAsync();
            var productosDto = _mapper.Map<List<ProductoDTO>>(productos);
            return productosDto;
        }

        [HttpGet("{id}", Name = "GetProducto")]
        public async Task<ActionResult<ProductoDTO>> Get(int id)
        {
            var producto = await _contexto.Productos.FirstOrDefaultAsync(x => x.CodigoProducto.Equals(id));
            if (producto == null)
            {
                return NotFound();
            }

            var productoDto = _mapper.Map<ProductoDTO>(producto);
            return productoDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductoCreacionDTO productoCreacion)
        {
            var producto = _mapper.Map<Producto>(productoCreacion);
            _contexto.Add((object) producto);
            await _contexto.SaveChangesAsync();
            var productoDto = _mapper.Map<ProductoDTO>(producto);
            return new CreatedAtRouteResult("GetProducto", new {id = producto.CodigoProducto},
                productoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductoCreacionDTO productoActualizacion)
        {
            var producto = _mapper.Map<Producto>(productoActualizacion);
            producto.CodigoProducto = id;
            _contexto.Entry(producto).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductoDTO>> Delete(int id)
        {
            var codigoProducto = await _contexto.Productos.Select(x => x.CodigoProducto)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoProducto == default)
            {
                return NotFound();
            }

            _contexto.Remove(new Producto {CodigoProducto = id});
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}