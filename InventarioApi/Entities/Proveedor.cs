using System.Collections.Generic;

namespace InventarioApi.Entities
{
    public class Proveedor
    {
        public int CodigoProveedor { get; set; }
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Pagina_Web { get; set; }
        public string ContactoPrincipal { get; set; }
        public List<Compra> Compras { get; set; }
        public List<EmailProveedor> EmailProveedores { get; set; }
        public List<TelefonoProveedor> TelefonoProveedores { get; set; }
    }
}