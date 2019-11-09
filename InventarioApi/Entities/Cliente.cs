using System.Collections.Generic;

namespace InventarioApi.Entities
{
    public class Cliente
    {
        public string Nit { get; set; }
        public string Dpi { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public List<Factura> Facturas { get; set; }
        public List<Emailcliente> Emailclientes { get; set; }
        public List<TelefonoCliente> TelefonoClientes { get; set; }
    }
}