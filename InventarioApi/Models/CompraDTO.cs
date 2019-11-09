using System;

namespace InventarioApi.Models
{
    public class CompraDTO
    {
        public int IdCompra { get; set; }
        public int NumeroDocumento { get; set; }
        public int CodigoProveedor { get; set; }
        public DateTime dateTime { get; set; }
        public decimal Total { get; set; }
        public ProveedorDTO Proveedor { get; set; }
    }
}