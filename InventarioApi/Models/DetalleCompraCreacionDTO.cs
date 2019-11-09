namespace InventarioApi.Models
{
    public class DetalleCompraCreacionDTO
    {
        public int IdCompra { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}