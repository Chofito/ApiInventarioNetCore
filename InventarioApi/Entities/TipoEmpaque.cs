using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventarioApi.Entities
{
    public class TipoEmpaque
    {
        public int CodigoEmpaque { get; set; }
        [Required] public string Descripcion { get; set; }
        public List<Producto> Productos { get; set; }
    }
}