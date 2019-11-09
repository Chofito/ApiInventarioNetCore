using System;

namespace InventarioApi.Models
{
    public class FacturaCreacionDTO
    {
        public string Nit { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }
}