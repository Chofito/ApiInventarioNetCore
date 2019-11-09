using System;

namespace InventarioApi.Models
{
    public class InventarioDTO
    {
        public int CodigoInventario { get; set; }
        public int CodigoProducto { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoRegistro { get; set; }
        public decimal Precio { get; set; }
        public int Entradas { get; set; }
        public int Salidas { get; set; }

        public ProductoDTO Producto { get; set; }
    }
}