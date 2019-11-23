using System;
using System.Collections.Generic;

namespace InventarioApi.Entities
{
    public class Compra
    {
        public int CodigoCompra { get; set; }
        public int NumeroDocumento { get; set; }
        public int CodigoProveedor { get; set; }
        public DateTime dateTime { get; set; }
        public decimal Total { get; set; }
        public List<DetalleCompra> DetalleCompras { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}