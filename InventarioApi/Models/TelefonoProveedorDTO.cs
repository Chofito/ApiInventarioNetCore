namespace InventarioApi.Models
{
    public class TelefonoProveedorDTO
    {
        public int CodigoTelefono { get; set; }
        public string Numero { get; set; }
        public string Descripcion { get; set; }
        public int CodigoProveedor { get; set; }
        public ProveedorDTO Proveedores { get; set; }
    }
}