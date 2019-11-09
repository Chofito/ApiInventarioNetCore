namespace InventarioApi.Entities
{
    public class TelefonoProveedor
    {
        public int CodigoTelefono { get; set; }
        public string Numero { get; set; }
        public string Descripcion { get; set; }
        public int CodigoProveedor { get; set; }
        public Proveedor Proveedores { get; set; }
    }
}