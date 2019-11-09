using System.ComponentModel.DataAnnotations;

namespace InventarioApi.Models
{
    public class TipoEmpaqueCreacionDTO
    {
        [Required] public string Descripcion { get; set; }
    }
}