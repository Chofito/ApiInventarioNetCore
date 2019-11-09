using System.ComponentModel.DataAnnotations;

namespace InventarioApi.Models
{
    public class TipoEmpaqueDTO
    {
        public int CodigoEmpaque { get; set; }
        [Required] public string Descripcion { get; set; }
    }
}