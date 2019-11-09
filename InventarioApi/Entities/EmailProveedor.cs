namespace InventarioApi.Entities
{
    public class EmailProveedor
    {
        public int CodigoEmail { get; set; }
        public string Email { get; set; }
        public int CodigoProveedor { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}