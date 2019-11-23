using System;

namespace InventarioApi.Models
{
    public class CompraCreacionDTO
    {
        public int NumeroDocumento { get; set; }
        public int CodigoProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }
}