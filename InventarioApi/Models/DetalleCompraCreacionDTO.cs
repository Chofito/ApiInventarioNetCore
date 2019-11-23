namespace InventarioApi.Models
{
    public class DetalleCompraCreacionDTO
    {
        public int CodigoCompra { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}