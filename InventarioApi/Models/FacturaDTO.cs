using System;
using System.Collections.Generic;

namespace InventarioApi.Models
{
    public class FacturaDTO
    {
        public int Numerofactura { get; set; }
        public string Nit { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public ClienteDTO Cliente { get; set; }
        public List<DetalleFacturaDTO> DetalleFacturas { get; set; }
    }
}