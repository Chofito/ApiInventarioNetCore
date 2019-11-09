using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventarioApi.Models
{
    public class CategoriaDTO
    {
        public int CodigoCategoria { get; set; }
        [Required] public string Descripcion { get; set; }
        public List<ProductoDTO> Productos { get; set; }
    }
}