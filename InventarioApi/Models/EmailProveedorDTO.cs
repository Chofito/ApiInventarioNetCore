namespace InventarioApi.Models
{
    public class EmailProveedorDTO
    {
        public int CodigoEmail { get; set; }
        public string Email { get; set; }
        public int CodigoProveedor { get; set; }
        public ProveedorDTO Proveedor { get; set; }
    }
}