using System.ComponentModel.DataAnnotations;

namespace InventarioApi.Models
{
    public class CategoriaCreacionDTO
    {
        [Required] public string Descripcion { get; set; }
    }
}