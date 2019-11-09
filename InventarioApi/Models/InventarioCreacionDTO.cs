using System;

namespace InventarioApi.Models
{
    public class InventarioCreacionDTO
    {
        public int CodigoProducto { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoRegistro { get; set; }
        public decimal Precio { get; set; }
        public int Entradas { get; set; }
        public int Salidas { get; set; }
    }
}